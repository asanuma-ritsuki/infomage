Public Class frmMain

#Region "プロパティ"

	Dim _UserName As String = ""
	''' <summary>
	''' 作業者
	''' </summary>
	''' <returns></returns>
	Public Property UserName()
		Get
			Return _UserName
		End Get
		Set(value)
			_UserName = value
		End Set
	End Property

#End Region

#Region "プライベート変数"

	Private CloseEnable As Boolean = True
	Private Lot As String = ""
	Private Enum DocuTypes
		ラベル
		封筒
		対象者一覧
		保健指導対象者名簿
		判定票
		リーフレット
	End Enum

	Private LabelQR As String = ""
	'現在行
	Private CurrentRow As Integer = 0
	'重量ヘッダリスト
	Private aryWeightList As String() = {"A", "B", "C", "D", "E", "F", "G", "H"}

#End Region

#Region "フォームイベント"

	''' <summary>
	''' フォームロード時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load

		Me.Text = My.Application.Info.ProductName & " Ver." &
			My.Application.Info.Version.ToString & " - [メイン]"

		Initialize()

	End Sub

#End Region

#Region "オブジェクトイベント"

	''' <summary>
	''' キー操作
	''' </summary>
	''' <param name="keyData"></param>
	''' <returns></returns>
	''' <remarks></remarks>
	Protected Overrides Function ProcessDialogKey(keyData As Keys) As Boolean
		Try
			'Returnキーが押されているか調べる
			'AltかCtrlキーが押されている時は、本来の動作をさせる
			If ((keyData And Keys.KeyCode) = Keys.Return) AndAlso
				((keyData And (Keys.Alt Or Keys.Control)) = Keys.None) Then
				'Tabキーを押した時と同じ動作をさせる
				'Shiftキーが押されている時は、逆順にする
				Me.ProcessTabKey((keyData And Keys.Shift) <> Keys.Shift)
				'本来の処理はさせない
				Return True
			End If

		Catch ex As Exception
			MessageBox.Show(ex.Message)
		End Try

		Return MyBase.ProcessDialogKey(keyData)

	End Function

	''' <summary>
	''' 開始ボタン
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	''' <remarks></remarks>
	Private Sub btnStart_Click(sender As System.Object, e As System.EventArgs) Handles btnStart.Click
		If Me.cmbLotID.Text = "" Then
			MessageBox.Show("ロットが選択されていません", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Exit Sub
		End If
		If MessageBox.Show("ロット" & Me.cmbLotID.Text & "の読取を開始します" & vbNewLine & "よろしいですか。", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1) = DialogResult.Yes Then
			StartMethod(True)
		End If
		Me.txtScan.Focus()
	End Sub
	''' <summary>
	''' 終了ボタン
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	''' <remarks></remarks>
	Private Sub btnClear_Click(sender As System.Object, e As System.EventArgs) Handles btnEnd.Click
		If Me.C1FGridLeafDetail.Rows.Count > 1 Then
			Dim NextRow As Integer = Me.C1FGridLeafDetail.FindRow(0, CurrentRow, 5, True, True, False)
			If NextRow < 0 Then
				Confirm(True, LabelQR)
				StartMethod(False)
			Else
				If MessageBox.Show("最後まで読み取られていないリーフレットの値は破棄されます。" & vbNewLine & "よろしいですか。", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
					StartMethod(False)
				End If
			End If
		Else
			StartMethod(False)
		End If

		Me.txtScan.Focus()
	End Sub

	''' <summary>
	''' 社員進捗ラベル値変更時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub lblEmployee_TextChanged(sender As Object, e As EventArgs) Handles lblEmployee.TextChanged

		If Me.prgEmployee.Value = Me.prgEmployee.Maximum And Me.prgEmployee.Maximum <> 0 Then
			Me.lblEmployee.BackColor = Color.LightGreen
		Else
			Me.lblEmployee.BackColor = Color.White
		End If

	End Sub

	''' <summary>
	''' QRコード読み取り時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub txtScan_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtScan.Validating

		Dim strSQL As String = ""
		Dim sqlProcess As New SQLProcess

		Try

			Me.txtScan.BackColor = Color.MistyRose
			If Not IsNull(Me.txtScan.Text) Then
				Dim QR As String = Me.txtScan.Text  'QRコード
				Dim QRLength As Integer = Me.txtScan.TextLength 'QR桁数
				Dim DocuType As String = 0  '帳票種別
				Dim ScanTime As String = System.DateTime.Now
				Dim CurrentSeq As Integer = 0

				'次の突合レコード
				Dim NextRow As Integer = Me.C1FGridLeafDetail.FindRow(0, CurrentRow, 5, True, True, False)
				'QRコードの桁数は24桁以外は全てエラーとする(24桁はリーフレットの桁数)
				Select Case QRLength
					Case 24
						'リーフレット
						DocuType = QR.Substring(15, 1)
						CurrentSeq = CInt(QR.Substring(QR.Length - 1, 1)) 'カレントSEQ
					Case Else
						'それ以外は全てエラー
						Me.txtScan.BackColor = Color.Red
						MessageBox.Show("桁数エラーです" & vbNewLine & "再度QRコードを読み込んでください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
						Me.txtScan.BackColor = Color.MistyRose
						Me.txtScan.Text = ""
						Me.txtScan.Focus()
						Exit Select
				End Select

				Select Case CurrentSeq
					Case 1
						'先頭
						If QR = LabelQR Then
							Me.txtScan.BackColor = Color.Red
							MessageBox.Show("現在読み込み中の先頭QRコードです", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
							Me.txtScan.BackColor = Color.MistyRose
							Me.txtScan.Text = ""
							Me.txtScan.Focus()
							Exit Sub
						End If

						Dim CompanyCode As String = ""
						Dim EnvelopeNo As String = ""
						Dim EnvelopeTotal As String = ""
						Dim OfficeCode As String = ""

						Dim ResQR As Boolean = splitQR(QR, CompanyCode, EnvelopeNo, EnvelopeTotal, OfficeCode)
						If Not ResQR Then
							Exit Sub
						End If

						Dim ResultListCount As Integer = 0
						Dim ResultCount As Integer = 0
						Dim LeafletListCount As Integer = 0
						Dim LeafletCount As Integer = 0
						'該当QRコードのレコード番号を取得する
						strSQL = "SELECT レコード番号 FROM T_リーフ6チェック "
						strSQL &= "WHERE ロットID = '" & Me.cmbLotID.Text & "' "
						strSQL &= "AND QRコード = '" & QR & "'"
						Dim dtQR As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
						Dim iRecordNumber As Integer = 0
						If dtQR.Rows.Count = 0 Then
							Me.txtScan.BackColor = Color.Red
							MessageBox.Show("該当しないリーフレットです" & vbNewLine & "管理者に報告してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
							Me.txtScan.BackColor = Color.MistyRose
							Me.txtScan.Text = ""
							Me.txtScan.Focus()
							Exit Sub
						Else
							iRecordNumber = dtQR.Rows(0)("レコード番号")
						End If

						strSQL = "SELECT COUNT(*) FROM T_リーフ6チェック "
						strSQL &= "WHERE ロットID = '" & Me.cmbLotID.Text & "' "
						strSQL &= "AND レコード番号 = " & iRecordNumber & " "
						LeafletCount = sqlProcess.DB_EXECUTE_SCALAR(strSQL) 'リーフレット枚数
						strSQL &= "AND カレントSEQ = 1"
						LeafletListCount = sqlProcess.DB_EXECUTE_SCALAR(strSQL) 'リーフレット件数

						'リーフレット6枚以上に該当しないものの場合
						If LeafletCount = 0 Then
							Me.txtScan.BackColor = Color.Red
							MessageBox.Show("該当しないリーフレットです" & vbNewLine & "管理者に報告してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
							Me.txtScan.BackColor = Color.MistyRose
							Me.txtScan.Text = ""
							Me.txtScan.Focus()
							Exit Sub
						End If
						'読み込んでいる状態で別リーフレットのシーケンス1を読んだ場合
						If Me.C1FGridLeafDetail.Rows.Count > 1 Then
							If NextRow < 0 Then
								Confirm(True, LabelQR)
							ElseIf NextRow > 0 Then
								Me.txtScan.BackColor = Color.Red
								If MessageBox.Show("読み込んでいないレコードが存在します" & vbNewLine & "現在の情報を破棄して先頭から読み込みますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
									Me.txtScan.BackColor = Color.MistyRose
								Else
									Me.txtScan.BackColor = Color.MistyRose
									Me.txtScan.Text = ""
									Me.txtScan.Focus()
									Exit Sub
								End If

							End If
						End If
						'社員のリーフレット詳細を取得
						strSQL = "SELECT T1.レコード番号, T1.QRコード, T1.帳票タイプ, T2.氏名姓 + ' ' + T2.氏名名 AS 氏名, "
						strSQL &= "T1.チェックフラグ, T1.チェック日時 "
						strSQL &= "FROM T_リーフ6チェック AS T1 INNER JOIN "
						strSQL &= "T_判定票 AS T2 ON T1.ロットID = T2.ロットID "
						strSQL &= "AND T1.レコード番号 = T2.レコード番号 "
						strSQL &= "WHERE T1.ロットID = '" & Me.cmbLotID.Text & "' "
						strSQL &= "AND T1.レコード番号 = " & iRecordNumber
						Dim dt As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
						Dim DoneCount As Integer = 0

						For iRow As Integer = 0 To dt.Rows.Count - 1
							If dt.Rows(iRow)("チェックフラグ") = True Then
								DoneCount += 1
							End If
						Next

						'既に読み取り済みの社員の場合
						If dt.Rows.Count = DoneCount Then
							Me.txtScan.BackColor = Color.Red
							If MessageBox.Show("読み込み済みのリーフレットです" & vbNewLine & "データを破棄して再度読み込み直しますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
								Me.txtScan.BackColor = Color.MistyRose
								Confirm(False, QR)
							Else
								Me.txtScan.BackColor = Color.MistyRose
								Me.txtScan.Text = ""
								Me.txtScan.Focus()
								Exit Sub
							End If
						End If

						ProgressClear()

						'グリッドの更新
						Me.C1FGridLeafDetail.BeginUpdate()
						For iRow As Integer = 0 To dt.Rows.Count - 1
							Me.C1FGridLeafDetail.Rows.Count += 1

							Dim iRecCount As Integer = Me.C1FGridLeafDetail.Rows.Count - 1
							Me.C1FGridLeafDetail(iRecCount, "No") = iRecCount
							Me.C1FGridLeafDetail(iRecCount, "レコード番号") = dt.Rows(iRow)("レコード番号")
							Me.C1FGridLeafDetail(iRecCount, "QRコード") = dt.Rows(iRow)("QRコード")
							Me.C1FGridLeafDetail(iRecCount, "帳票タイプ") = dt.Rows(iRow)("帳票タイプ")
							Me.C1FGridLeafDetail(iRecCount, "氏名") = dt.Rows(iRow)("氏名")
							Me.C1FGridLeafDetail(iRecCount, "読込チェック") = 0
							Me.C1FGridLeafDetail(iRecCount, "チェック日時") = ""
						Next
						Me.C1FGridLeafDetail.EndUpdate()

						'ラベルQRを確定
						LabelQR = QR

						'列幅を最大桁にあわせる
						Me.C1FGridLeafDetail.AutoSizeCol(0)
						Me.C1FGridLeafDetail.AutoSizeCol(1)
						Me.C1FGridLeafDetail.AutoSizeCol(2)
						Me.C1FGridLeafDetail.AutoSizeCol(3)
						Me.C1FGridLeafDetail.AutoSizeCol(4)

						Me.prgEmployee.Maximum = dt.Rows.Count
						Me.lblEmployee.Text = "0 / " & Me.prgEmployee.Maximum

						LotInfoUpdate()
						WeightInfoUpdate()
						ProgressUpdate()

						'==================================================
						'先頭のリーフレットをチェック済みにする
						NextRow = 1
						Me.C1FGridLeafDetail.Select(1, 1)
						Me.C1FGridLeafDetail(NextRow, "読込チェック") = 1
						Me.C1FGridLeafDetail(NextRow, "チェック日時") = ScanTime
						Me.C1FGridLeafDetail.Rows(NextRow).Style = Me.C1FGridLeafDetail.Styles("Done")
						Me.prgEmployee.Value += 1
						Me.lblEmployee.Text = Me.prgEmployee.Value & " / " & Me.prgEmployee.Maximum

						'スクロール
						Me.C1FGridLeafDetail.TopRow = NextRow - 10
						If NextRow = Me.C1FGridLeafDetail.Rows.Count - 1 Then
							'最終レコードの場合選択解除
							Me.C1FGridLeafDetail.Select(-1, 0)
						Else
							Me.C1FGridLeafDetail.Select(NextRow + 1, 0)
						End If

						Application.DoEvents()
						'==================================================

					Case Else
						'先頭以外
						If Me.C1FGridLeafDetail.Rows.Count = 1 Then
							MessageBox.Show("先頭のリーフレットを読み込んでください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
							Me.txtScan.Text = ""
							Me.txtScan.Focus()
							Exit Sub
						Else
							Dim LoopFlag As Boolean = True
							While LoopFlag = True
								If NextRow < 0 Then

									Me.txtScan.BackColor = Color.Red
									PlaySound.Main2()
									If MessageBox.Show("リフト外のQRコードです" & vbNewLine & "管理者に報告し、「はい」を押下してください", "エラー", MessageBoxButtons.YesNo, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
										Me.txtScan.Text = ""
										Me.txtScan.Focus()
										LoopFlag = False
										Me.txtScan.BackColor = Color.MistyRose
										Exit Sub
									End If
								Else
									LoopFlag = False
								End If
							End While

							Dim NextQR As String = Me.C1FGridLeafDetail(NextRow, "QRコード")
							'読み込んだQRとリストを突合する
							If NextQR = Me.txtScan.Text Then
								Me.C1FGridLeafDetail(NextRow, "読込チェック") = 1
								Me.C1FGridLeafDetail(NextRow, "チェック日時") = ScanTime
								Me.C1FGridLeafDetail.Rows(NextRow).Style = Me.C1FGridLeafDetail.Styles("Done")
								Me.prgEmployee.Value += 1
								Me.lblEmployee.Text = Me.prgEmployee.Value & " / " & Me.prgEmployee.Maximum

								'スクロール
								Me.C1FGridLeafDetail.TopRow = NextRow - 10
								If NextRow = Me.C1FGridLeafDetail.Rows.Count - 1 Then
									'最終レコードの場合選択解除
									Me.C1FGridLeafDetail.Select(-1, 0)
								Else
									Me.C1FGridLeafDetail.Select(NextRow + 1, 0)
								End If

								Application.DoEvents()

							Else
								Me.txtScan.BackColor = Color.Red
								PlaySound.Main2()

								LoopFlag = True
								While LoopFlag = True
									If MessageBox.Show("リストと一致しないQRコードです" & vbNewLine & "管理者に報告し、「はい」を押下してください", "エラー", MessageBoxButtons.YesNo, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
										Me.txtScan.Text = ""
										Me.txtScan.Focus()
										LoopFlag = False
										Me.txtScan.BackColor = Color.MistyRose
										Exit Sub
									End If
								End While
							End If
						End If
				End Select

				Me.txtScan.Text = ""
				Me.txtScan.Focus()
				IIf(NextRow = -1, CurrentRow = 0, CurrentRow = NextRow)

			End If

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & strSQL)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & strSQL, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		Finally

			sqlProcess.Close()

		End Try
	End Sub

#End Region

#Region "プライベートメソッド"

	''' <summary>
	''' 初期化処理
	''' </summary>
	Private Sub Initialize()

		XmlSettings.LoadFromXmlFile()
		Me.Left = XmlSettings.Instance.LocationX
		Me.Top = XmlSettings.Instance.LocationY
		Me.Width = XmlSettings.Instance.SizeX
		Me.Height = XmlSettings.Instance.SizeY
		Me.WindowState = XmlSettings.Instance.State

		' カスタムスタイルを追加
		Me.C1FGridLeafInfo.Styles.Add("Doing")
		Me.C1FGridLeafInfo.Styles("Doing").BackColor = Color.LightYellow
		Me.C1FGridLeafInfo.Styles.Add("Done")
		Me.C1FGridLeafInfo.Styles("Done").BackColor = Color.LightGray
		Me.C1FGridLeafDetail.Styles.Add("Done")
		Me.C1FGridLeafDetail.Styles("Done").BackColor = Color.LightGray

		Me.prgLeafNumber.Style = ProgressBarStyle.Continuous
		Me.prgLeafSheets.Style = ProgressBarStyle.Continuous
		Me.prgEmployee.Style = ProgressBarStyle.Continuous
		'重量ヘッダ単位件数更新
		Me.C1FGridWeightHeader.Rows.Count = aryWeightList.Count + 1
		For iRow As Integer = 1 To Me.C1FGridWeightHeader.Rows.Count - 1
			Me.C1FGridWeightHeader.Rows(iRow)("重量") = aryWeightList(iRow - 1)
			Me.C1FGridWeightHeader.Rows(iRow)("合計件数") = 0
			Me.C1FGridWeightHeader.Rows(iRow)("合計枚数") = 0
			Me.C1FGridWeightHeader.Rows(iRow)("完了件数") = 0
			Me.C1FGridWeightHeader.Rows(iRow)("完了枚数") = 0
			Me.C1FGridWeightHeader.Rows(iRow)("残り件数") = 0
			Me.C1FGridWeightHeader.Rows(iRow)("残り枚数") = 0
		Next

		ComboBoxUpdate()
		Me.txtScan.Focus()
		StartMethod(False)

		'ユーザーネームを表示
		Me.lblUserName.Text = UserName

	End Sub

	''' <summary>
	''' フォームクローズ時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub frmMain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

		If CloseEnable = False Then
			MessageBox.Show("ロットを終了させてください", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
			e.Cancel = True
		ElseIf MessageBox.Show("終了します" & vbNewLine & "よろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button2) = DialogResult.No Then
			e.Cancel = True
		End If

		XmlSettings.LoadFromXmlFile()
		XmlSettings.Instance.LocationX = Me.Left
		XmlSettings.Instance.LocationY = Me.Top
		XmlSettings.Instance.SizeX = Me.Width
		XmlSettings.Instance.SizeY = Me.Height
		XmlSettings.Instance.State = Me.WindowState
		XmlSettings.SaveToXmlFile()

	End Sub

	''' <summary>
	''' フォームクローズ後
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub frmMain_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed

		Application.Exit()

	End Sub

	''' <summary>
	''' ロット開始・終了
	''' </summary>
	''' <param name="StartEnd"></param>
	Private Sub StartMethod(ByVal StartEnd As Boolean)

		Me.txtScan.Enabled = StartEnd
		Me.btnEnd.Enabled = StartEnd
		Me.cmbLotID.Enabled = Not StartEnd
		Me.btnStart.Enabled = Not StartEnd
		CloseEnable = Not StartEnd
		Lot = Me.cmbLotID.Text

		If Not StartEnd Then
			Me.txtScan.BackColor = Color.LightGray
			Me.C1FGridLeafInfo.Rows.Count = 1
			Me.lblLeafNumber.Text = "0 / 0"
			Me.lblLeafSheets.Text = "0 / 0"
			Me.lblEmployee.Text = "0 / 0"

			Me.prgLeafNumber.Maximum = 0
			Me.prgLeafNumber.Minimum = 0
			Me.prgLeafNumber.Value = 0
			Me.prgLeafSheets.Maximum = 0
			Me.prgLeafSheets.Minimum = 0
			Me.prgLeafSheets.Value = 0
			Me.prgEmployee.Maximum = 0
			Me.prgEmployee.Minimum = 0
			Me.prgEmployee.Value = 0
			Me.lblEmployee.BackColor = Color.White

			'重量ヘッダ単位件数更新
			Me.C1FGridWeightHeader.Rows.Count = aryWeightList.Count + 1
			For iRow As Integer = 1 To Me.C1FGridWeightHeader.Rows.Count - 1
				Me.C1FGridWeightHeader.Rows(iRow)("重量") = aryWeightList(iRow - 1)
				Me.C1FGridWeightHeader.Rows(iRow)("合計件数") = 0
				Me.C1FGridWeightHeader.Rows(iRow)("合計枚数") = 0
				Me.C1FGridWeightHeader.Rows(iRow)("完了件数") = 0
				Me.C1FGridWeightHeader.Rows(iRow)("完了枚数") = 0
				Me.C1FGridWeightHeader.Rows(iRow)("残り件数") = 0
				Me.C1FGridWeightHeader.Rows(iRow)("残り枚数") = 0
			Next

			LabelQR = ""
			CurrentRow = 0
		Else
			Me.txtScan.BackColor = Color.MistyRose
			ProgressUpdate()
			LotInfoUpdate()
			WeightInfoUpdate()

		End If

		ProgressClear()

	End Sub

	''' <summary>
	''' DB書き込み
	''' </summary>
	''' <param name="chkFlag"></param>
	''' <param name="labelQR"></param>
	Private Sub Confirm(ByVal chkFlag As Boolean, ByVal labelQR As String)
		'T_リーフ6チェックの該当レコードのチェックフラグを立てる
		Dim CompanyCode As String = ""
		Dim EnvelopeNo As String = ""
		Dim EnvelopeTotal As String = ""
		Dim OfficeCode As String = ""

		Dim ResQR As Boolean = splitQR(labelQR, CompanyCode, EnvelopeNo, EnvelopeTotal, OfficeCode)
		If Not ResQR Then
			Exit Sub
		End If

		Dim strSQL As String = ""
		Dim sqlProcess As New SQLProcess

		Try
			If chkFlag Then
				Dim chkTime As String = ""
				For iRow As Integer = 1 To Me.C1FGridLeafDetail.Rows.Count - 1
					strSQL = "UPDATE T_リーフ6チェック "
					strSQL &= "SET チェックフラグ = 1 "
					strSQL &= ", チェック日時 = '" & Me.C1FGridLeafDetail(iRow, "チェック日時") & "' "
					strSQL &= ", 作業者 = '" & Me.lblUserName.Text & "' "
					strSQL &= "WHERE ロットID = '" & Me.cmbLotID.Text & "' "
					strSQL &= "AND レコード番号 = " & Me.C1FGridLeafDetail(iRow, "レコード番号") & " "
					strSQL &= "AND 帳票タイプ = '" & Me.C1FGridLeafDetail(iRow, "帳票タイプ") & "' "
					strSQL &= "AND QRコード = '" & Me.C1FGridLeafDetail(iRow, "QRコード") & "'"
					sqlProcess.DB_UPDATE(strSQL)
					chkTime = Me.C1FGridLeafDetail(iRow, "チェック日時")
				Next
			Else
				'LeafDetailグリッドは空のためQRコードからレコード番号を取り出す
				strSQL = "SELECT レコード番号 FROM T_リーフ6チェック "
				strSQL &= "WHERE ロットID = '" & Me.cmbLotID.Text & "' "
				strSQL &= "AND QRコード = '" & labelQR & "'"
				Dim iRecNumber As Integer = CInt(sqlProcess.DB_EXECUTE_SCALAR(strSQL))

				strSQL = "UPDATE T_リーフ6チェック "
				strSQL &= "SET チェックフラグ = 0 "
				strSQL &= ", チェック日時 = NULL "
				strSQL &= ", 作業者 = '' "
				strSQL &= "WHERE ロットID = '" & Me.cmbLotID.Text & "' "
				strSQL &= "AND レコード番号 = " & iRecNumber   '先頭行のレコード番号を取得
				sqlProcess.DB_UPDATE(strSQL)
			End If

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & strSQL)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & strSQL, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		Finally

			sqlProcess.Close()

		End Try

	End Sub

	''' <summary>
	''' QRコードから各値を取得(20180613)
	''' </summary>
	''' <param name="QR"></param>
	''' <param name="CompanyCode"></param>
	''' <param name="EnvelopeNo"></param>
	''' <param name="EnvelopeTotal"></param>
	''' <param name="OfficeCode"></param>
	''' <returns></returns>
	Private Function splitQR(ByVal QR As String, ByRef CompanyCode As String, ByRef EnvelopeNo As String, ByRef EnvelopeTotal As String, ByRef OfficeCode As String) As Boolean
		Dim Result As Boolean = True
		CompanyCode = QR.Substring(0, 4)
		Try
			EnvelopeNo = CInt(QR.Substring(11, 2))
		Catch ex As Exception
			Me.txtScan.BackColor = Color.Red
			MessageBox.Show("不正なQRコードです。" & vbNewLine & "管理者に報告してください。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Me.txtScan.BackColor = Color.MistyRose
			Me.txtScan.Text = ""
			Me.txtScan.Focus()
			Result = False
		End Try
		EnvelopeTotal = QR.Substring(13, 2)
		OfficeCode = QR.Substring(15)    'インデックス15から最後まで

		Return Result
	End Function

	''' <summary>
	''' 進捗ラベルの値を初期化
	''' </summary>
	Private Sub ProgressClear()

		Me.C1FGridLeafDetail.Rows.Count = 1
		Me.prgEmployee.Maximum = 0
		Me.prgEmployee.Value = 0
		Me.lblEmployee.Text = "0 / 0"

	End Sub

	''' <summary>
	''' ロット内先頭リーフレット情報
	''' </summary>
	Private Sub LotInfoUpdate()

		Dim strSQL As String = ""
		Dim sqlProcess As New SQLProcess

		Try
			strSQL = "SELECT T1.チェックフラグ, T1.QRコード, T1.重量ヘッダ AS 重量, T3.会社名, T3.局所名 AS 事業所名, T1.印刷ID "
			strSQL &= "FROM T_リーフ6チェック AS T1 INNER JOIN "
			strSQL &= "T_判定票 AS T2 ON T1.ロットID = T2.ロットID "
			strSQL &= "AND T1.レコード番号 = T2.レコード番号 INNER JOIN "
			strSQL &= "M_局所 AS T3 ON T2.会社コード = T3.会社コード "
			strSQL &= "AND T2.所属事業所コード = T3.局所コード "
			strSQL &= "WHERE T1.ロットID = '" & Me.cmbLotID.Text & "' "
			strSQL &= "AND T1.カレントSEQ = 1 "
			strSQL &= "GROUP BY T1.チェックフラグ, T1.QRコード, T1.重量ヘッダ, T3.会社名, T3.局所名, T1.印刷ID, T1.ラベル連番 "
			strSQL &= "ORDER BY T1.ラベル連番"
			Dim dt As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)

			Me.C1FGridLeafInfo.Rows.Count = 1
			Me.C1FGridLeafInfo.BeginUpdate()
			For iRow As Integer = 0 To dt.Rows.Count - 1
				Me.C1FGridLeafInfo.Rows.Count += 1
				Dim iRecCount As Integer = Me.C1FGridLeafInfo.Rows.Count - 1
				Me.C1FGridLeafInfo(iRecCount, "No") = iRecCount
				Me.C1FGridLeafInfo(iRecCount, "CHK") = dt.Rows(iRow)("チェックフラグ")
				Me.C1FGridLeafInfo(iRecCount, "QRコード") = dt.Rows(iRow)("QRコード")
				Me.C1FGridLeafInfo(iRecCount, "重量") = dt.Rows(iRow)("重量")
				Me.C1FGridLeafInfo(iRecCount, "会社名") = dt.Rows(iRow)("会社名")
				Me.C1FGridLeafInfo(iRecCount, "事業所名") = dt.Rows(iRow)("事業所名")
				Me.C1FGridLeafInfo(iRecCount, "印刷ID") = dt.Rows(iRow)("印刷ID")

				'読み込み中の社員
				If dt.Rows(iRow)("QRコード") = LabelQR Then
					Me.C1FGridLeafInfo.Rows(iRecCount).Style = Me.C1FGridLeafInfo.Styles("Doing")
				End If
				'終了した社員
				If IIf(dt.Rows(iRow)("チェックフラグ") Is DBNull.Value, 0, dt.Rows(iRow)("チェックフラグ")) = 1 Then
					Me.C1FGridLeafInfo.Rows(iRecCount).Style = Me.C1FGridLeafInfo.Styles("Done")
				End If
			Next
			Me.C1FGridLeafInfo.EndUpdate()
			'列幅を最大桁にあわせる
			Me.C1FGridLeafInfo.AutoSizeCol(0)
			Me.C1FGridLeafInfo.AutoSizeCol(1)
			Me.C1FGridLeafInfo.AutoSizeCol(2)
			Me.C1FGridLeafInfo.AutoSizeCol(3)
			Me.C1FGridLeafInfo.AutoSizeCol(4)
			Me.C1FGridLeafInfo.AutoSizeCol(5)
			Me.C1FGridLeafInfo.AutoSizeCol(6)
			'スクロール
			Dim LabelRow As Integer = Me.C1FGridLeafInfo.FindRow(LabelQR, 1, 2, True, True, False)
			Me.C1FGridLeafInfo.TopRow = LabelRow
			Me.C1FGridLeafInfo.Select(LabelRow, 0)

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & strSQL)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & strSQL, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		Finally

			sqlProcess.Close()

		End Try

	End Sub

	''' <summary>
	''' 進捗更新
	''' </summary>
	Private Sub ProgressUpdate()

		Dim strSQL As String = ""
		Dim sqlProcess As New SQLProcess

		Try
			strSQL = "SELECT ISNULL(SUM(CASE WHEN カレントSEQ = 1 THEN 1 ELSE 0 END), 0) AS 合計件数, "
			strSQL &= "ISNULL(COUNT(ロットID), 0) AS 合計枚数, "
			strSQL &= "ISNULL(SUM(CASE WHEN カレントSEQ = 1 AND チェックフラグ = 1 THEN 1 ELSE 0 END), 0) AS 完了件数, "
			strSQL &= "ISNULL(SUM(CASE WHEN チェックフラグ = 1 THEN 1 ELSE 0 END), 0) AS 完了枚数 "
			strSQL &= "FROM T_リーフ6チェック "
			strSQL &= "WHERE ロットID = '" & Me.cmbLotID.Text & "'"
			Dim dt As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
			Me.lblLeafNumber.Text = dt.Rows(0)("完了件数") & " / " & dt.Rows(0)("合計件数")
			Me.lblLeafSheets.Text = dt.Rows(0)("完了枚数") & " / " & dt.Rows(0)("合計枚数")

			Me.prgLeafNumber.Maximum = dt.Rows(0)("合計件数")
			Me.prgLeafNumber.Minimum = 0
			Me.prgLeafNumber.Value = dt.Rows(0)("完了件数")

			Me.prgLeafSheets.Maximum = dt.Rows(0)("合計枚数")
			Me.prgLeafSheets.Minimum = 0
			Me.prgLeafSheets.Value = dt.Rows(0)("完了枚数")

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & strSQL)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & strSQL, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		Finally

			sqlProcess.Close()

		End Try

	End Sub

	''' <summary>
	''' ロット選択用コンボボックスの更新
	''' </summary>
	Private Sub ComboBoxUpdate()

		Dim strSQL As String = ""
		Dim sqlProcess As New SQLProcess

		Try
			'コンボボックスにロットIDをセット
			strSQL = "SELECT T1.ロットID "
			strSQL &= "FROM T_リーフ6チェック AS T1 INNER JOIN "
			strSQL &= "T_ロット管理 AS T2 ON T1.ロットID = T2.ロットID "
			strSQL &= "WHERE T2.削除フラグ = 0 "
			strSQL &= "GROUP BY T1.ロットID, T2.削除フラグ "
			strSQL &= "ORDER BY T1.ロットID DESC"
			Dim dt As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
			For iRow As Integer = 0 To dt.Rows.Count - 1
				Me.cmbLotID.Items.Add(dt.Rows(iRow)("ロットID"))
			Next
			Me.cmbLotID.SelectedIndex = 0

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & strSQL)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & strSQL, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		Finally

			sqlProcess.Close()

		End Try

	End Sub

	''' <summary>
	''' ロット内の重量ヘッダ単位件数更新
	''' </summary>
	Private Sub WeightInfoUpdate()

		Dim strSQL As String = ""
		Dim sqlProcess As New SQLProcess

		Try
			Me.C1FGridWeightHeader.Rows.Count = aryWeightList.Count + 1
			For iRow As Integer = 1 To Me.C1FGridWeightHeader.Rows.Count - 1
				strSQL = "SELECT ISNULL(SUM(CASE WHEN カレントSEQ = 1 THEN 1 ELSE 0 END), 0) AS 合計件数, "
				strSQL &= "ISNULL(COUNT(ロットID), 0) AS 合計枚数, "
				strSQL &= "ISNULL(SUM(CASE WHEN カレントSEQ = 1 AND チェックフラグ = 1 THEN 1 ELSE 0 END), 0) AS 完了件数, "
				strSQL &= "ISNULL(SUM(CASE WHEN チェックフラグ = 1 THEN 1 ELSE 0 END), 0) AS 完了枚数, "
				strSQL &= "ISNULL(SUM(CASE WHEN カレントSEQ = 1 AND チェックフラグ = 0 THEN 1 ELSE 0 END), 0) AS 残り件数, "
				strSQL &= "ISNULL(SUM(CASE WHEN チェックフラグ = 0 THEN 1 ELSE 0 END), 0) AS 残り枚数 "
				strSQL &= "FROM T_リーフ6チェック "
				strSQL &= "WHERE ロットID = '" & Me.cmbLotID.Text & "' "
				strSQL &= "AND 重量ヘッダ = '" & aryWeightList(iRow - 1) & "'"
				Dim dt As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)

				Me.C1FGridWeightHeader(iRow, "重量") = aryWeightList(iRow - 1)
				Me.C1FGridWeightHeader(iRow, "合計件数") = dt.Rows(0)("合計件数")
				Me.C1FGridWeightHeader(iRow, "合計枚数") = dt.Rows(0)("合計枚数")
				Me.C1FGridWeightHeader(iRow, "完了件数") = dt.Rows(0)("完了件数")
				Me.C1FGridWeightHeader(iRow, "完了枚数") = dt.Rows(0)("完了枚数")
				Me.C1FGridWeightHeader(iRow, "残り件数") = dt.Rows(0)("残り件数")
				Me.C1FGridWeightHeader(iRow, "残り枚数") = dt.Rows(0)("残り枚数")
			Next

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & strSQL)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & strSQL, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		Finally

			sqlProcess.Close()

		End Try

	End Sub

#End Region


End Class