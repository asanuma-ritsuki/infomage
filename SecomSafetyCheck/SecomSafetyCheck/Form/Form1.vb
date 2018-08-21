Imports C1.Win.C1Themes
Imports System.Text.RegularExpressions.Regex

Public Class Form1

#Region "フォームイベント"

	''' <summary>
	''' フォームロード時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

		Me.Text = My.Application.Info.ProductName & " Ver." &
			My.Application.Info.Version.ToString

		Initialize()

	End Sub

	''' <summary>
	''' フォームクロージング
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

		If MessageBox.Show("アプリケーションを終了します" & vbNewLine & "よろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
			e.Cancel = True
		Else
			OptimisationDB()
		End If

	End Sub

#End Region

#Region "メニューオブジェクトイベント"

	''' <summary>
	''' [ファイル][終了]
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub menuExit_Click(sender As Object, e As C1.Win.C1Command.ClickEventArgs) Handles menuExit.Click

		If MessageBox.Show("アプリケーションを終了します" & vbNewLine & "よろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
			OptimisationDB()
			Application.Exit()
		End If

	End Sub

	''' <summary>
	''' [ツール][接続設定]
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub menuConnection_Click(sender As Object, e As C1.Win.C1Command.ClickEventArgs) Handles menuConnection.Click

		Dim f As New frmConnectionProperty
		f.showdialog(Me)

	End Sub

#End Region

#Region "オブジェクトイベント"

	''' <summary>
	''' テキストボックスDragEnter
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub txtFolder_DragEnter(sender As Object, e As DragEventArgs) Handles txtImportFolder.DragEnter, txtLogFolder.DragEnter

		If e.Data.GetDataPresent(DataFormats.FileDrop) Then
			e.Effect = DragDropEffects.Copy
		Else
			e.Effect = DragDropEffects.None
		End If

	End Sub

	''' <summary>
	''' テキストボックスDragDrop
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub txtImportFolder_DragDrop(sender As Object, e As DragEventArgs) Handles txtImportFolder.DragDrop, txtLogFolder.DragDrop

		Dim strFiles As String() = CType(e.Data.GetData(DataFormats.FileDrop, False), String())
		Dim txtFile As TextBox = CType(sender, TextBox)

		If System.IO.File.Exists(strFiles(0)) Then
			txtFile.Text = System.IO.Path.GetDirectoryName(strFiles(0))
		Else
			If System.IO.Directory.Exists(strFiles(0)) Then
				txtFile.Text = strFiles(0)
			End If
		End If

	End Sub

	''' <summary>
	''' 開始ボタン押下時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click

		If Not System.IO.Directory.Exists(Me.txtImportFolder.Text) Then
			MessageBox.Show("存在するインポートフォルダを指定してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Exit Sub
		End If
		If Not System.IO.Directory.Exists(Me.txtLogFolder.Text) Then
			MessageBox.Show("存在するログフォルダを指定してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Exit Sub
		End If
		If MessageBox.Show("料金按分処理を開始します" & vbNewLine & "よろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
			Exit Sub
		End If
		EnableControls(False)
		ClearValue()

		WriteLstResult(Me.lstResult, "==================================================")
		WriteLstResult(Me.lstResult, "インポート処理開始")
		WriteLstResult(Me.lstResult, "インポートフォルダ：" & Me.txtImportFolder.Text)
		WriteLstResult(Me.lstResult, "ログフォルダ：" & Me.txtLogFolder.Text)
		Dim strFile As String = ""
		XmlSettings.LoadFromXmlFile()
		Dim strAccessFile As String = XmlSettings.Instance.AccessFile
		Dim strSQL As String = ""
		Dim sqlProcess As New SQLProcess(strAccessFile)
		Dim strDateTime As String = Date.Now.ToString("yyyyMMddHHmmss")

		Try

			WriteLstResult(Me.lstResult, "==================================================")
			WriteLstResult(Me.lstResult, "ファイル存在チェック開始")
			Dim strFiles As String() = GetFilesMostDeep(Me.txtImportFolder.Text, {"*.csv"})
			Dim strSearchWord As String() = {"_usr.csv", "_org.csv", "ManagerSearchlist_", "usrSearchlist_"}

			For i As Integer = 0 To strSearchWord.Length - 1
				For j As Integer = 0 To strFiles.Length - 1
					Dim iIndex As Integer = strFiles(j).IndexOf(strSearchWord(i))
					If iIndex >= 0 Then
						'ヒットした
						Select Case i
							Case 0
								'社員数
								Me.txtUsr.Text = System.IO.Path.GetFileName(strFiles(j))
								WriteLstResult(Me.lstResult, "社員数CSV：" & System.IO.Path.GetFileName(strFiles(j)))
							Case 1
								'事業所数
								Me.txtOrg.Text = System.IO.Path.GetFileName(strFiles(j))
								WriteLstResult(Me.lstResult, "事業所数CSV：" & System.IO.Path.GetFileName(strFiles(j)))
							Case 2
								'管理者数
								Me.txtManagerSearchlist.Text = System.IO.Path.GetFileName(strFiles(j))
								WriteLstResult(Me.lstResult, "管理者数CSV：" & System.IO.Path.GetFileName(strFiles(j)))
							Case 3
								'あんぴくん
								Me.txtUsrSearchlist.Text = System.IO.Path.GetFileName(strFiles(j))
								WriteLstResult(Me.lstResult, "あんぴくんCSV：" & System.IO.Path.GetFileName(strFiles(j)))
						End Select
						Exit For
					End If
				Next
			Next
			'CSVファイルが1つでも存在しなかったらアボート
			If IsNull(Me.txtUsr.Text) Or IsNull(Me.txtUsr.Text) Or IsNull(Me.txtManagerSearchlist.Text) Or IsNull(Me.txtUsrSearchlist.Text) Then
				MessageBox.Show("CSVファイルが見つかりませんでした", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
				WriteLstResult(Me.lstResult, "1つ以上のCSVファイルが見つかりませんでした", ResultMark.ErrorMark)
				Exit Sub
			End If

			WriteLstResult(Me.lstResult, "ファイル存在チェック終了")

			'==================================================
			'インポート処理
			'==================================================
			'テーブル初期化
			WriteLstResult(Me.lstResult, "==================================================")
			WriteLstResult(Me.lstResult, "テンポラリテーブルの削除開始")
			strSQL = "DELETE FROM [T_社員数]"
			sqlProcess.DB_UPDATE(strSQL)
			strSQL = "DELETE FROM [T_事業所数]"
			sqlProcess.DB_UPDATE(strSQL)
			strSQL = "DELETE FROM [T_管理者数]"
			sqlProcess.DB_UPDATE(strSQL)
			strSQL = "DELETE FROM [T_あんぴくん]"
			sqlProcess.DB_UPDATE(strSQL)
			strSQL = "DELETE FROM [T_件数]"
			sqlProcess.DB_UPDATE(strSQL)
			strSQL = "DELETE FROM [T_CSV情報]"
			sqlProcess.DB_UPDATE(strSQL)
			WriteLstResult(Me.lstResult, "テンポラリテーブルの削除終了")

			Dim iRecCount As Integer = 0
			'==================================================
			'社員数
			WriteLstResult(Me.lstResult, "==================================================")
			WriteLstResult(Me.lstResult, "==================================================")
			WriteLstResult(Me.lstResult, "社員数CSVインポート処理開始")
			Me.lblView.Text = "社員数CSVインポート"
			Application.DoEvents()

			ImportSrc(Me.txtImportFolder.Text & "\" & Me.txtUsr.Text, strAccessFile, iRecCount)
			Me.txtUsrCount.Text = iRecCount.ToString("#,##0")

			WriteLstResult(Me.lstResult, "社員数CSVインポート処理終了")
			Application.DoEvents()
			'==================================================
			'事業所数
			WriteLstResult(Me.lstResult, "==================================================")
			WriteLstResult(Me.lstResult, "事業所数CSVインポート処理開始")
			Me.lblView.Text = "事業所数CSVインポート"
			Application.DoEvents()

			ImportOrg(Me.txtImportFolder.Text & "\" & Me.txtOrg.Text, strAccessFile, iRecCount)
			Me.txtOrgCount.Text = iRecCount.ToString("#,##0")

			WriteLstResult(Me.lstResult, "事業所数CSVインポート処理終了")
			Application.DoEvents()
			'==================================================
			'管理者数
			WriteLstResult(Me.lstResult, "==================================================")
			WriteLstResult(Me.lstResult, "管理者数CSVインポート処理開始")
			Me.lblView.Text = "管理者数CSVインポート"
			Application.DoEvents()

			ImportManagerSearchlist(Me.txtImportFolder.Text & "\" & Me.txtManagerSearchlist.Text, strAccessFile, iRecCount)
			Me.txtManagerSearchlistCount.Text = iRecCount.ToString("#,##0")

			WriteLstResult(Me.lstResult, "管理者数CSVインポート処理終了")
			Application.DoEvents()
			'==================================================
			'あんぴくん
			WriteLstResult(Me.lstResult, "==================================================")
			WriteLstResult(Me.lstResult, "あんぴくんCSVインポート処理開始")
			Me.lblView.Text = "あんぴくんCSVインポート"
			Application.DoEvents()

			ImportUsrSearchlist(Me.txtImportFolder.Text & "\" & Me.txtUsrSearchlist.Text, strAccessFile, iRecCount)
			Me.txtUsrSearchlistCount.Text = iRecCount.ToString("#,##0")

			WriteLstResult(Me.lstResult, "あんぴくんCSVインポート処理終了")
			Application.DoEvents()
			WriteLstResult(Me.lstResult, "==================================================")
			WriteLstResult(Me.lstResult, "インポート件数：社員数：" & Me.txtUsrCount.Text & "件")
			WriteLstResult(Me.lstResult, "インポート件数：事業所数：" & Me.txtOrgCount.Text & "件")
			WriteLstResult(Me.lstResult, "インポート件数：管理者数：" & Me.txtManagerSearchlistCount.Text & "件")
			WriteLstResult(Me.lstResult, "インポート件数：あんぴくん：" & Me.txtUsrSearchlistCount.Text & "件")

			'==================================================
			'件数取得、エラーチェック
			'==================================================
			'社員数
			WriteLstResult(Me.lstResult, "==================================================")
			WriteLstResult(Me.lstResult, "==================================================")
			WriteLstResult(Me.lstResult, "社員数：件数取得開始")
			Me.lblView.Text = "社員数：件数取得"
			strSQL = "SELECT [社員番号] FROM [T_社員数] "
			strSQL &= "ORDER BY [社員番号]"
			Application.DoEvents()
			System.Threading.Thread.Sleep(CInt(Me.numWait.Value) * 1000)
			Dim dt As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
			Dim iMSH As Integer = 0
			Dim iMSC As Integer = 0
			Dim iMCBP As Integer = 0
			Dim iMSE As Integer = 0
			Dim iMSL As Integer = 0
			Dim iMSCS As Integer = 0
			Dim iMST As Integer = 0
			'プログレスバー処理
			Me.ProgressBar1.Maximum = dt.Rows.Count
			Me.ProgressBar1.Value = 0
			Me.lblProgress.Text = "0 / " & Me.ProgressBar1.Maximum

			For iRow As Integer = 0 To dt.Rows.Count - 1
				strSQL = "SELECT [事業会社] FROM [M_事業所] "
				strSQL &= "WHERE [事業所コード] = '" & Microsoft.VisualBasic.Left(dt.Rows(iRow)("社員番号").ToString, 3) & "' "
				strSQL &= "AND [事業所フラグ] = 0"
				Dim strReturn As String = sqlProcess.DB_EXECUTE_SCALAR(strSQL)
				Select Case strReturn
					Case "MSH"
						iMSH += 1
					Case "MSC"
						iMSC += 1
					Case "MCBP"
						iMCBP += 1
					Case "MSE"
						iMSE += 1
					Case "MSL"
						iMSL += 1
					Case "MSCS"
						iMSCS += 1
					Case "MST"
						iMST += 1
					Case Else
						iMSH += 1
				End Select

				Me.ProgressBar1.Value = iRow + 1
				Me.lblProgress.Text = iRow + 1 & " / " & Me.ProgressBar1.Maximum
			Next
			'件数が揃ったところでINSERT
			strSQL = "INSERT INTO [T_件数] ([ID], [料金項目], [MSH], [MSC], [MCBP], [MSE], [MSL], [MSCS], [MST]) VALUES ( "
			strSQL &= "1"
			strSQL &= ", '社員数', " & iMSH & ", " & iMSC & ", " & iMCBP & ", " & iMSE & ", " & iMSL & ", " & iMSCS & ", " & iMST & ")"
			sqlProcess.DB_UPDATE(strSQL)
			WriteLstResult(Me.lstResult, "社員数：件数取得終了：" & (iMSH + iMSC + iMCBP + iMSE + iMSL + iMSCS + iMST).ToString("#,##0") & "件")
			'==================================================
			'事業所数
			WriteLstResult(Me.lstResult, "==================================================")
			WriteLstResult(Me.lstResult, "事業所数：件数取得、エラーチェック開始")
			Me.lblView.Text = "事業所数：件数取得、エラーチェック"
			strSQL = "SELECT [ID], [組織コード], [第１階層組織コード], [組織名称] FROM [T_事業所数] "
			strSQL &= "WHERE [報告確認対象フラグ] = '1' "
			strSQL &= "ORDER BY [組織コード]"
			Application.DoEvents()
			System.Threading.Thread.Sleep(CInt(Me.numWait.Value) * 1000)
			dt = sqlProcess.DB_SELECT_DATATABLE(strSQL)
			iMSH = 0
			iMSC = 0
			iMCBP = 0
			iMSE = 0
			iMSL = 0
			iMSCS = 0
			iMST = 0
			'プログレスバー処理
			Me.ProgressBar1.Maximum = dt.Rows.Count
			Me.ProgressBar1.Value = 0
			Me.lblProgress.Text = "0 / " & Me.ProgressBar1.Maximum

			Dim iErrorCount As Integer = 0
			For iRow As Integer = 0 To dt.Rows.Count - 1
				'組織コードから数値を全て削除する
				Dim strSystemCode As String = Replace(dt.Rows(iRow)("組織コード").ToString, "\d", "")
				Dim strSystemCode1 As String = Replace(dt.Rows(iRow)("第１階層組織コード").ToString, "\d", "")

				strSQL = "SELECT [事業会社] FROM [M_事業所] "
				strSQL &= "WHERE [事業会社] = '" & strSystemCode & "'"
				Dim dtSystemCode As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
				If dtSystemCode.Rows.Count > 0 Then
					'組織コードにヒット
					Dim strReturn As String = dtSystemCode.Rows(0)("事業会社")
					Select Case strReturn
						Case "MSH"
							iMSH += 1
						Case "MSC"
							iMSH += 1
						Case "MCBP"
							iMSH += 1
						Case "MSE"
							iMSE += 1
						Case "MSL"
							iMSL += 1
						Case "MSCS"
							iMSCS += 1
						Case "MST"
							iMST += 1
						Case Else
							iMSH += 1
					End Select
				Else
					'組織コードにヒットしなかった
					'第１階層組織コードとマッチングを行う
					strSQL = "SELECT [事業会社] FROM [M_事業所] "
					strSQL &= "WHERE [事業会社] = '" & strSystemCode1 & "'"
					Dim dtSystemCode1 As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
					If dtSystemCode1.Rows.Count > 0 Then
						'第１階層組織コードにヒット
						Dim strReturn As String = dtSystemCode1.Rows(0)("事業会社")
						Select Case strReturn
							Case "MSH"
								iMSH += 1
							Case "MSC"
								iMSH += 1
							Case "MCBP"
								iMSH += 1
							Case "MSE"
								iMSE += 1
							Case "MSL"
								iMSL += 1
							Case "MSCS"
								iMSCS += 1
							Case "MST"
								iMST += 1
							Case Else
								iMSH += 1
						End Select
					Else
						'第１階層組織コードにヒットしなかった
						'組織名称とマッチングを行う
						strSQL = "SELECT [事業会社] FROM [M_事業所] "
						strSQL &= "WHERE [事業所名] = '" & dt.Rows(iRow)("組織名称") & "'"
						Dim dtSystemName As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
						If dtSystemName.Rows.Count > 0 Then
							'組織名称にヒット
							Dim strReturn As String = dtSystemName.Rows(0)("事業会社")
							Select Case strReturn
								Case "MSH"
									iMSH += 1
								Case "MSC"
									iMSH += 1
								Case "MCBP"
									iMSH += 1
								Case "MSE"
									iMSE += 1
								Case "MSL"
									iMSL += 1
								Case "MSCS"
									iMSCS += 1
								Case "MST"
									iMST += 1
								Case Else
									iMSH += 1
							End Select
						Else
							'いずれもヒットしなかった
							'該当レコードにエラーフラグを立てる
							strSQL = "UPDATE [T_事業所数] SET [エラーフラグ] = 1 "
							strSQL &= "WHERE ID = " & dt.Rows(iRow)("ID")
							sqlProcess.DB_UPDATE(strSQL)
							iErrorCount += 1
							WriteLstResult(Me.lstResult, "マッチングエラー：" & dt.Rows(iRow)("組織コード") & "：" & dt.Rows(iRow)("第１階層組織コード") & "：" & dt.Rows(iRow)("組織名称"), ResultMark.ErrorMark)
							'エラーログに出力する
							Using sw As New System.IO.StreamWriter(Me.txtLogFolder.Text & "\事業所マッチングエラー_" & strDateTime & ".log", True, System.Text.Encoding.GetEncoding("Shift-JIS"))
								Dim strWriteLine As String = Chr(34) & dt.Rows(iRow)("組織コード") & Chr(34) & "," & Chr(34) & dt.Rows(iRow)("第１階層組織コード") & Chr(34) & "," & Chr(34) & dt.Rows(iRow)("組織名称") & Chr(34)
								sw.WriteLine(strWriteLine)
							End Using
						End If
					End If
				End If

				Me.ProgressBar1.Value = iRow + 1
				Me.lblProgress.Text = iRow + 1 & " / " & Me.ProgressBar1.Maximum
			Next
			'件数が揃ったところでINSERT
			strSQL = "INSERT INTO [T_件数] ([ID], [料金項目], [MSH], [MSC], [MCBP], [MSE], [MSL], [MSCS], [MST]) VALUES ( "
			strSQL &= "2"
			strSQL &= ", '事業所数', " & iMSH & ", " & iMSC & ", " & iMCBP & ", " & iMSE & ", " & iMSL & ", " & iMSCS & ", " & iMST & ")"
			sqlProcess.DB_UPDATE(strSQL)
			WriteLstResult(Me.lstResult, "事業所数：件数取得終了：" & (iMSH + iMSC + iMCBP + iMSE + iMSL + iMSCS + iMST).ToString("#,##0") & "件、エラー：" & iErrorCount & "件")
			Me.txtOrgError.Text = iErrorCount.ToString("#,##0")
			'==================================================
			'管理者数、部門管理者数
			WriteLstResult(Me.lstResult, "==================================================")
			WriteLstResult(Me.lstResult, "管理者、部門管理者数：件数取得開始")
			Me.lblView.Text = "管理者、部門管理者数：件数取得"
			strSQL = "SELECT [ユーザーＩＤ], [利用者種別] FROM [T_管理者数] "
			strSQL &= "ORDER BY [ユーザーＩＤ]"
			Application.DoEvents()
			System.Threading.Thread.Sleep(CInt(Me.numWait.Value) * 1000)
			dt = sqlProcess.DB_SELECT_DATATABLE(strSQL)
			'変数の初期化
			iMSH = 0
			iMSC = 0
			iMCBP = 0
			iMSE = 0
			iMSL = 0
			iMSCS = 0
			iMST = 0
			'部門管理者用変数
			Dim ibuMSH As Integer = 0
			Dim ibuMSC As Integer = 0
			Dim ibuMCBP As Integer = 0
			Dim ibuMSE As Integer = 0
			Dim ibuMSL As Integer = 0
			Dim ibuMSCS As Integer = 0
			Dim ibuMST As Integer = 0
			'プログレスバー処理
			Me.ProgressBar1.Maximum = dt.Rows.Count
			Me.ProgressBar1.Value = 0
			Me.lblProgress.Text = "0 / " & Me.ProgressBar1.Maximum

			For iRow As Integer = 0 To dt.Rows.Count - 1
				strSQL = "SELECT [事業会社] FROM [M_事業所] "
				strSQL &= "WHERE [事業所コード] = '" & Microsoft.VisualBasic.Left(dt.Rows(iRow)("ユーザーＩＤ").ToString, 3) & "' "
				strSQL &= "AND [事業所フラグ] = 0"
				Dim strReturn As String = sqlProcess.DB_EXECUTE_SCALAR(strSQL)
				Dim strManager As String = dt.Rows(iRow)("利用者種別")
				If strManager.StartsWith("管理者") Then
					'管理者だった
					Select Case strReturn
						Case "MSH"
							iMSH += 1
						Case "MSC"
							iMSC += 1
						Case "MCBP"
							iMCBP += 1
						Case "MSE"
							iMSE += 1
						Case "MSL"
							iMSL += 1
						Case "MSCS"
							iMSCS += 1
						Case "MST"
							iMST += 1
						Case Else
							iMSH += 1
					End Select

				Else
					'部門管理者だった
					Select Case strReturn
						Case "MSH"
							ibuMSH += 1
						Case "MSC"
							ibuMSC += 1
						Case "MCBP"
							ibuMCBP += 1
						Case "MSE"
							ibuMSE += 1
						Case "MSL"
							ibuMSL += 1
						Case "MSCS"
							ibuMSCS += 1
						Case "MST"
							ibuMST += 1
						Case Else
							ibuMSH += 1
					End Select

				End If

				Me.ProgressBar1.Value = iRow + 1
				Me.lblProgress.Text = iRow + 1 & " / " & Me.ProgressBar1.Maximum
			Next
			'件数が揃ったところでINSERT
			'管理者数
			strSQL = "INSERT INTO [T_件数] ([ID], [料金項目], [MSH], [MSC], [MCBP], [MSE], [MSL], [MSCS], [MST]) VALUES ( "
			strSQL &= "3"
			strSQL &= ", '管理者数', " & iMSH & ", " & iMSC & ", " & iMCBP & ", " & iMSE & ", " & iMSL & ", " & iMSCS & ", " & iMST & ")"
			sqlProcess.DB_UPDATE(strSQL)
			WriteLstResult(Me.lstResult, "管理者数：件数取得終了：" & (iMSH + iMSC + iMCBP + iMSE + iMSL + iMSCS + iMST).ToString("#,##0") & "件")
			'部門管理者数
			strSQL = "INSERT INTO [T_件数] ([ID], [料金項目], [MSH], [MSC], [MCBP], [MSE], [MSL], [MSCS], [MST]) VALUES ( "
			strSQL &= "4"
			strSQL &= ", '部門管理者数', " & ibuMSH & ", " & ibuMSC & ", " & ibuMCBP & ", " & ibuMSE & ", " & ibuMSL & ", " & ibuMSCS & ", " & ibuMST & ")"
			sqlProcess.DB_UPDATE(strSQL)
			WriteLstResult(Me.lstResult, "部門管理者数：件数取得終了：" & (ibuMSH + ibuMSC + ibuMCBP + ibuMSE + ibuMSL + ibuMSCS + ibuMST).ToString("#,##0") & "件")
			'==================================================
			'あんぴくん
			WriteLstResult(Me.lstResult, "==================================================")
			WriteLstResult(Me.lstResult, "あんぴくん：件数取得、エラーチェック開始")
			Me.lblView.Text = "あんぴくん：件数取得、エラーチェック"
			strSQL = "SELECT [ユーザーＩＤ], [ご利用者名] FROM [T_あんぴくん] "
			strSQL &= "ORDER BY [ユーザーＩＤ]"
			Application.DoEvents()
			System.Threading.Thread.Sleep(CInt(Me.numWait.Value) * 1000)
			dt = sqlProcess.DB_SELECT_DATATABLE(strSQL)
			'変数の初期化
			iMSH = 0
			iMSC = 0
			iMCBP = 0
			iMSE = 0
			iMSL = 0
			iMSCS = 0
			iMST = 0
			'プログレスバー処理
			Me.ProgressBar1.Maximum = dt.Rows.Count
			Me.ProgressBar1.Value = 0
			Me.lblProgress.Text = "0 / " & Me.ProgressBar1.Maximum

			Dim iErrorCountAnpi = 0
			For iRow As Integer = 0 To dt.Rows.Count - 1
				strSQL = "SELECT [事業会社] FROM [M_事業所] "
				strSQL &= "WHERE [事業所コード] = '" & Microsoft.VisualBasic.Left(dt.Rows(iRow)("ユーザーＩＤ").ToString, 3) & "' "
				strSQL &= "AND [事業所フラグ] = 0"
				Dim dtReturn As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
				If dtReturn.Rows.Count > 0 Then
					'何かしらヒットした
					Dim strReturn As String = dtReturn.Rows(0)("事業会社")
					Select Case strReturn
						Case "MSH"
							iMSH += 1
						Case "MSC"
							iMSC += 1
						Case "MCBP"
							iMCBP += 1
						Case "MSE"
							iMSE += 1
						Case "MSL"
							iMSL += 1
						Case "MSCS"
							iMSCS += 1
						Case "MST"
							iMST += 1
					End Select
				Else
					'ヒットしなかったらエラーログを出力
					WriteLstResult(Me.lstResult, "マッチングエラー：" & dt.Rows(iRow)("ユーザーＩＤ") & "：" & dt.Rows(iRow)("ご利用者名"), ResultMark.ErrorMark)
					Using sw As New System.IO.StreamWriter(Me.txtLogFolder.Text & "\あんぴくんマッチングエラー_" & strDateTime & ".log", True, System.Text.Encoding.GetEncoding("Shift-JIS"))
						Dim strWriteLine As String = Chr(34) & dt.Rows(iRow)("ユーザーＩＤ") & Chr(34) & "," & Chr(34) & dt.Rows(iRow)("ご利用者名") & Chr(34)
						sw.WriteLine(strWriteLine)
					End Using
					iErrorCountAnpi += 1
				End If
				Me.ProgressBar1.Value = iRow + 1
				Me.lblProgress.Text = iRow + 1 & " / " & Me.ProgressBar1.Maximum
			Next
			'件数が揃ったところでINSERT
			strSQL = "INSERT INTO [T_件数] ([ID], [料金項目], [MSH], [MSC], [MCBP], [MSE], [MSL], [MSCS], [MST]) VALUES ( "
			strSQL &= "5"
			strSQL &= ", 'あんぴくん', " & iMSH & ", " & iMSC & ", " & iMCBP & ", " & iMSE & ", " & iMSL & ", " & iMSCS & ", " & iMST & ")"
			sqlProcess.DB_UPDATE(strSQL)
			'あんぴくん代行送信
			strSQL = "INSERT INTO [T_件数] ([ID], [料金項目], [MSH], [MSC], [MCBP], [MSE], [MSL], [MSCS], [MST]) VALUES ( "
			strSQL &= "6"
			strSQL &= ", 'あんぴくん代行送信', " & iMSH & ", " & iMSC & ", " & iMCBP & ", " & iMSE & ", " & iMSL & ", " & iMSCS & ", " & iMST & ")"
			sqlProcess.DB_UPDATE(strSQL)

			WriteLstResult(Me.lstResult, "あんぴくん：件数取得終了：" & (iMSH + iMSC + iMCBP + iMSE + iMSL + iMSCS + iMST).ToString("#,##0") & "件、エラー：" & iErrorCountAnpi & "件")
			Me.txtUsrSearchlistError.Text = iErrorCountAnpi.ToString("#,##0")

			WriteLstResult(Me.lstResult, "==================================================")
			WriteLstResult(Me.lstResult, "==================================================")
			'事業所数マッチング時のエラーが存在した場合は、事業会社特定処理を促す
			If iErrorCount > 0 Then
				WriteLstResult(Me.lstResult, "事業所数マッチングでエラーが発生しています")
				WriteLstResult(Me.lstResult, "処理結果タブで事業会社特定処理を行ってください")
			End If
			WriteLstResult(Me.lstResult, "料金按分処理終了")
			MessageBox.Show("処理が終了しました", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information)
			OutputImportLog(Me.lstResult, Me.txtLogFolder.Text, "料金按分処理ログ")

			SearchResult()
			SaveCSVInfo()

			Me.lblView.Text = ""
			Me.ProgressBar1.Value = 0
			Me.lblProgress.Text = "0 / 0"

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & ex.StackTrace)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		Finally

			sqlProcess.Close()
			EnableControls(True)

		End Try

	End Sub

	''' <summary>
	''' 更新ボタン押下時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click

		If Me.C1FGridRecovery.Rows.Count = 1 Then
			MessageBox.Show("アンマッチレコードが1件もありません", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Exit Sub
		End If
		'全てのレコードで事業会社が選択されているか確認
		For iRow As Integer = 0 To Me.C1FGridRecovery.Rows.Count - 1
			'レコード目はヘッダなのでスルー
			If iRow = 0 Then
				Continue For
			End If
			If Me.C1FGridRecovery.Rows(iRow)("事業会社") = "" Then
				MessageBox.Show("全てのレコードの事業会社を選択してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
				Exit Sub
			End If

		Next

		If MessageBox.Show("選択された事業会社で更新します" & vbNewLine & "よろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
			Exit Sub
		End If

		'M_事業所にデータの蓄積させる
		XmlSettings.LoadFromXmlFile()
		Dim strSQL As String = ""
		Dim sqlProcess As New SQLProcess(XmlSettings.Instance.AccessFile)

		Try
			For iRow As Integer = 1 To Me.C1FGridRecovery.Rows.Count - 1

				Dim strCompany As String = Me.C1FGridRecovery(iRow, "事業会社")
				If strCompany = "MSC" Then
					strCompany = "MSH"
				End If
				'既に同一の事業所名が登録されていた場合は新たにINSERTしない
				strSQL = "SELECT COUNT(*) FROM [M_事業所] "
				strSQL &= "WHERE [事業所名] = '" & Me.C1FGridRecovery(iRow, "組織名称") & "'"
				Dim iDup As Integer = sqlProcess.DB_EXECUTE_SCALAR(strSQL)
				If iDup = 0 Then
					strSQL = "SELECT MAX([事業所ID]) + 1 FROM M_事業所"
					Dim iMaxID As Integer = sqlProcess.DB_EXECUTE_SCALAR(strSQL)
					strSQL = "INSERT INTO [M_事業所] ([事業所ID], [事業所コード], [事業所名], [事業会社], [事業所フラグ]) VALUES ("
					strSQL &= iMaxID    '事業所ID
					strSQL &= ", ''"    '事業所コード
					strSQL &= ", '" & Me.C1FGridRecovery(iRow, "組織名称") & "'"    '事業所名
					strSQL &= ", '" & strCompany & "'"    '事業会社
					strSQL &= ", 1)"    '事業所フラグ
					sqlProcess.DB_UPDATE(strSQL)
				End If

				'T_事業所数のエラーフラグを取り下げる
				strSQL = "UPDATE [T_事業所数] SET [エラーフラグ] = 0 "
				strSQL &= "WHERE [ID] = " & Me.C1FGridRecovery(iRow, "ID")
				sqlProcess.DB_UPDATE(strSQL)
				'T_件数内の事業所数項目の該当の事業会社の件数をインクリメントする
				strSQL = "SELECT [" & strCompany & "] + 1 FROM [T_件数] "
				strSQL &= "WHERE [ID] = 2"
				Dim iMaxCount As Integer = sqlProcess.DB_EXECUTE_SCALAR(strSQL)
				strSQL = "UPDATE [T_件数] SET [" & strCompany & "] = " & iMaxCount & " "
				strSQL &= "WHERE [ID] = 2"
				sqlProcess.DB_UPDATE(strSQL)
			Next
			'T_CSV情報のエラーを0件にする
			strSQL = "UPDATE [T_CSV情報] SET エラー件数 = 0 "
			strSQL &= "WHERE ID = 2"
			sqlProcess.DB_UPDATE(strSQL)

			MessageBox.Show("更新作業が終了しました", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information)
			SearchResult()
			SearchCSVInfo()

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & ex.StackTrace)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		Finally

			sqlProcess.Close()

		End Try

	End Sub

	''' <summary>
	''' 出力ボタン押下時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub btnOutput_Click(sender As Object, e As EventArgs) Handles btnOutput.Click

		'エラーチェック
		If Not CInt(Me.txtOrgError.Text) = 0 Then
			MessageBox.Show("事業所数のエラーを解消してから出力してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Exit Sub
		End If

		Dim dtDate As Date = Date.Now
		Dim sfd As New SaveFileDialog()
		'はじめのファイル名を指定する
		sfd.FileName = "料金按分表_" & dtDate.ToString("yyyyMMddHHmmss") & ".xlsx"
		sfd.Filter = "Excel ブック(*xlsx)|*.xlsx"
		sfd.FilterIndex = 1
		sfd.RestoreDirectory = True

		If sfd.ShowDialog() = DialogResult.OK Then

			If MessageBox.Show("料金按分表を出力します" & vbNewLine & "よろしいですか？" & vbNewLine & vbNewLine & sfd.FileName, "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
				Exit Sub
			End If
			Dim strSQL As String = ""
			XmlSettings.LoadFromXmlFile()
			Dim sqlProcess As New SQLProcess(XmlSettings.Instance.AccessFile)

			Try
				strSQL = "SELECT [ID], [料金項目], [MSH], [MSC], [MCBP], [MSE], [MSL], [MSCS], [MST] FROM [T_件数] "
				strSQL &= "ORDER BY ID"
				Dim dt As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)

				'OKボタンが押されたときエクセルの出力を実行する
				If WriteExcel(sfd.FileName, dt, dtDate) Then
					MessageBox.Show("料金按分表の出力が終了しました", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information)
				Else
					MessageBox.Show("料金按分表出力時にエラーが発生しました", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Information)
				End If

			Catch ex As Exception

				Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & ex.StackTrace)
				MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

			Finally

				sqlProcess.Close()

			End Try

		End If
	End Sub

#End Region

#Region "プライベートメソッド"

	''' <summary>
	''' ステータスバーに時刻を表示する
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
		Me.lblDate.Text = Date.Now.ToString("yyyy/MM/dd HH:mm:ss")
	End Sub

	''' <summary>
	''' 初期化処理
	''' </summary>
	Private Sub Initialize()

		'For Each themeName As String In C1ThemeController.GetThemes()
		'	Me.ComboBox1.Items.Add(themeName)
		'Next
		'Me.ComboBox1.SelectedIndex = 0

		Dim theme As C1Theme = C1ThemeController.GetThemeByName("Office2010Black", False)
		C1ThemeController.ApplyThemeToControlTree(Me, theme)

		'日付の取得
		Me.Timer1.Start()
		Me.lblUser.Text = My.Computer.Name
		Me.lblView.Text = ""

		'前回の件数が存在したら反映するかどうかのダイアログを表示する
		XmlSettings.LoadFromXmlFile()
		If System.IO.File.Exists(XmlSettings.Instance.AccessFile) Then
			Dim strSQL As String = ""
			Dim sqlProcess As New SQLProcess(XmlSettings.Instance.AccessFile)

			Try
				strSQL = "SELECT COUNT(*) FROM T_件数"
				If sqlProcess.DB_EXECUTE_SCALAR(strSQL) > 0 Then
					If MessageBox.Show("前回の処理結果を表示しますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
						SearchResult()
						SearchCSVInfo()
					End If

				End If
			Catch ex As Exception

				Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & ex.StackTrace)
				MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

			Finally

				sqlProcess.Close()

			End Try

		End If

	End Sub

	''' <summary>
	''' 値の初期化
	''' </summary>
	Private Sub ClearValue()
		Me.lstResult.Items.Clear()
		Me.txtUsr.Text = ""
		Me.txtUsrCount.Text = "0"
		Me.txtUsrError.Text = "0"
		Me.txtOrg.Text = ""
		Me.txtOrgCount.Text = "0"
		Me.txtOrgError.Text = "0"
		Me.txtManagerSearchlist.Text = ""
		Me.txtManagerSearchlistCount.Text = "0"
		Me.txtManagerSearchlistError.Text = "0"
		Me.txtUsrSearchlist.Text = ""
		Me.txtUsrSearchlistCount.Text = "0"
		Me.txtUsrSearchlistError.Text = "0"
		Me.ProgressBar1.Value = 0
		Me.lblProgress.Text = "0 / 0"
		Me.lblView.Text = ""
	End Sub

	''' <summary>
	''' コントロールを有効または無効にする
	''' </summary>
	''' <param name="blnEnabled"></param>
	Private Sub EnableControls(ByVal blnEnabled As Boolean)
		Me.txtImportFolder.Enabled = blnEnabled
		Me.txtLogFolder.Enabled = blnEnabled
		Me.btnStart.Enabled = blnEnabled
		Me.btnOutput.Enabled = blnEnabled
		Me.numWait.Enabled = blnEnabled
	End Sub

	''' <summary>
	''' AccessDBを最適化する
	''' </summary>
	Private Sub OptimisationDB()
		XmlSettings.LoadFromXmlFile()

		Dim jroEngine As JRO.JetEngine = Nothing
		Dim CompactPath As String = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source={0};Jet OLEDB:Engine Type=5"
		Dim MDB_DIR As String = System.IO.Path.GetDirectoryName(XmlSettings.Instance.AccessFile)
		Dim MDB_NAME As String = System.IO.Path.GetFileName(XmlSettings.Instance.AccessFile)

		Try
			'バックアップファイルの作成
			Dim originalMDB As String = MDB_DIR & "\" & MDB_NAME
			Dim cloneMDB As String = originalMDB & ".Backup"
			System.IO.File.Copy(originalMDB, cloneMDB, True)
			'最適化条件作成
			jroEngine = New JRO.JetEngine
			Dim beforeCompact As String = String.Format(CompactPath, originalMDB)
			Dim afterCompact As String = String.Format(CompactPath, originalMDB.Replace(MDB_NAME, "New_" & MDB_NAME))

			'New_...が存在するとエラーが出るので事前に削除する
			If System.IO.File.Exists(originalMDB.Replace(MDB_NAME, "New_" & MDB_NAME)) Then
				System.IO.File.Delete(originalMDB.Replace(MDB_NAME, "New_" & MDB_NAME))
			End If

			'最適化
			jroEngine.CompactDatabase(beforeCompact, afterCompact)
			jroEngine = Nothing

			'最適化されたファイルに置き換える
			System.IO.File.Replace(originalMDB.Replace(MDB_NAME, "New_" & MDB_NAME), originalMDB, originalMDB & ".bk")

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & ex.StackTrace)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		End Try

	End Sub

	''' <summary>
	''' T_CSV情報にデータを格納する
	''' </summary>
	Private Sub SaveCSVInfo()

		XmlSettings.LoadFromXmlFile()
		Dim strSQL As String = ""
		Dim sqlProcess As New SQLProcess(XmlSettings.Instance.AccessFile)

		Try
			'社員数
			strSQL = "INSERT INTO [T_CSV情報] ([ID], [料金項目], [CSVファイル名], [読込件数], [エラー件数]) VALUES ("
			strSQL &= "1"   'ID
			strSQL &= ", '社員数'" '料金項目
			strSQL &= ", '" & Me.txtUsr.Text & "'"   'CSVファイル名
			strSQL &= ", " & CInt(Me.txtUsrCount.Text)  '読込件数
			strSQL &= ", " & CInt(Me.txtUsrError.Text) & ")"  'エラー件数
			sqlProcess.DB_UPDATE(strSQL)
			'事業所数
			strSQL = "INSERT INTO [T_CSV情報] ([ID], [料金項目], [CSVファイル名], [読込件数], [エラー件数]) VALUES ("
			strSQL &= "2"   'ID
			strSQL &= ", '事業所数'" '料金項目
			strSQL &= ", '" & Me.txtOrg.Text & "'"   'CSVファイル名
			strSQL &= ", " & CInt(Me.txtOrgCount.Text)  '読込件数
			strSQL &= ", " & CInt(Me.txtOrgError.Text) & ")"  'エラー件数
			sqlProcess.DB_UPDATE(strSQL)
			'管理者数
			strSQL = "INSERT INTO [T_CSV情報] ([ID], [料金項目], [CSVファイル名], [読込件数], [エラー件数]) VALUES ("
			strSQL &= "3"   'ID
			strSQL &= ", '管理者数'" '料金項目
			strSQL &= ", '" & Me.txtManagerSearchlist.Text & "'"   'CSVファイル名
			strSQL &= ", " & CInt(Me.txtManagerSearchlistCount.Text)  '読込件数
			strSQL &= ", " & CInt(Me.txtManagerSearchlistError.Text) & ")"  'エラー件数
			sqlProcess.DB_UPDATE(strSQL)
			'あんぴくん
			strSQL = "INSERT INTO [T_CSV情報] ([ID], [料金項目], [CSVファイル名], [読込件数], [エラー件数]) VALUES ("
			strSQL &= "4"   'ID
			strSQL &= ", 'あんぴくん'" '料金項目
			strSQL &= ", '" & Me.txtUsrSearchlist.Text & "'"   'CSVファイル名
			strSQL &= ", " & CInt(Me.txtUsrSearchlistCount.Text)  '読込件数
			strSQL &= ", " & CInt(Me.txtUsrSearchlistError.Text) & ")"  'エラー件数
			sqlProcess.DB_UPDATE(strSQL)

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & ex.StackTrace)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		Finally

			sqlProcess.Close()

		End Try

	End Sub

	''' <summary>
	''' マッチング結果をグリッドにセットする
	''' </summary>
	Private Sub SearchResult()

		XmlSettings.LoadFromXmlFile()

		Dim strSQL As String = ""
		Dim sqlProcess As New SQLProcess(XmlSettings.Instance.AccessFile)
		Me.C1FGridRecovery.Rows.Count = 1

		Try
			'件数表
			strSQL = "SELECT [ID], [料金項目], [MSH], [MSC], [MCBP], [MSE], [MSL], [MSCS], [MST] "
			strSQL &= "FROM [T_件数] "
			strSQL &= "ORDER BY [ID]"
			Dim dt As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)

			For iRow As Integer = 0 To dt.Rows.Count - 1
				Me.C1FGridCount(iRow + 1, "No") = dt.Rows(iRow)("ID")
				Me.C1FGridCount(iRow + 1, "料金項目") = dt.Rows(iRow)("料金項目")
				Me.C1FGridCount(iRow + 1, "MSH") = dt.Rows(iRow)("MSH")
				Me.C1FGridCount(iRow + 1, "MSC") = dt.Rows(iRow)("MSC")
				Me.C1FGridCount(iRow + 1, "MCBP") = dt.Rows(iRow)("MCBP")
				Me.C1FGridCount(iRow + 1, "MSE") = dt.Rows(iRow)("MSE")
				Me.C1FGridCount(iRow + 1, "MSL") = dt.Rows(iRow)("MSL")
				Me.C1FGridCount(iRow + 1, "MSCS") = dt.Rows(iRow)("MSCS")
				Me.C1FGridCount(iRow + 1, "MST") = dt.Rows(iRow)("MST")
			Next

			'事業所数アンマッチリカバリ
			strSQL = "SELECT [ID], [組織コード], [第１階層組織コード], [第２階層組織コード], [第３階層組織コード], [組織名称] "
			strSQL &= "FROM [T_事業所数] "
			strSQL &= "WHERE [エラーフラグ] = True "
			strSQL &= "ORDER BY [ID]"
			dt = sqlProcess.DB_SELECT_DATATABLE(strSQL)

			For iRow As Integer = 0 To dt.Rows.Count - 1
				Me.C1FGridRecovery.Rows.Count = iRow + 2
				Me.C1FGridRecovery(iRow + 1, "No") = iRow + 1
				Me.C1FGridRecovery(iRow + 1, "ID") = dt.Rows(iRow)("ID")
				Me.C1FGridRecovery(iRow + 1, "組織コード") = dt.Rows(iRow)("組織コード")
				Me.C1FGridRecovery(iRow + 1, "第１階層組織コード") = dt.Rows(iRow)("第１階層組織コード")
				Me.C1FGridRecovery(iRow + 1, "第２階層組織コード") = dt.Rows(iRow)("第２階層組織コード")
				Me.C1FGridRecovery(iRow + 1, "第３階層組織コード") = dt.Rows(iRow)("第３階層組織コード")
				Me.C1FGridRecovery(iRow + 1, "組織名称") = dt.Rows(iRow)("組織名称")
			Next

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & ex.StackTrace)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		Finally

			sqlProcess.Close()

		End Try

	End Sub

	''' <summary>
	''' CSV情報取得
	''' </summary>
	Private Sub SearchCSVInfo()

		XmlSettings.LoadFromXmlFile()
		Dim strSQL As String = ""
		Dim sqlProcess As New SQLProcess(XmlSettings.Instance.AccessFile)

		Try
			strSQL = "SELECT [ID], [CSVファイル名], [読込件数], [エラー件数] FROM [T_CSV情報] "
			strSQL &= "ORDER BY [ID]"
			Dim dt As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
			If dt.Rows.Count = 0 Then
				Exit Sub
			End If

			For iRow As Integer = 0 To dt.Rows.Count - 1
				Select Case iRow
					Case 0
						'社員数
						Me.txtUsr.Text = dt.Rows(iRow)("CSVファイル名")
						Me.txtUsrCount.Text = CInt(dt.Rows(iRow)("読込件数")).ToString("#,##0")
						Me.txtUsrError.Text = CInt(dt.Rows(iRow)("エラー件数")).ToString("#,##0")
					Case 1
						'事業所数
						Me.txtOrg.Text = dt.Rows(iRow)("CSVファイル名")
						Me.txtOrgCount.Text = CInt(dt.Rows(iRow)("読込件数")).ToString("#,##0")
						Me.txtOrgError.Text = CInt(dt.Rows(iRow)("エラー件数")).ToString("#,##0")
					Case 2
						'管理者数
						Me.txtManagerSearchlist.Text = dt.Rows(iRow)("CSVファイル名")
						Me.txtManagerSearchlistCount.Text = CInt(dt.Rows(iRow)("読込件数")).ToString("#,##0")
						Me.txtManagerSearchlistError.Text = CInt(dt.Rows(iRow)("エラー件数")).ToString("#,##0")
					Case 3
						'あんぴくん
						Me.txtUsrSearchlist.Text = dt.Rows(iRow)("CSVファイル名")
						Me.txtUsrSearchlistCount.Text = CInt(dt.Rows(iRow)("読込件数")).ToString("#,##0")
						Me.txtUsrSearchlistError.Text = CInt(dt.Rows(iRow)("エラー件数")).ToString("#,##0")
				End Select
			Next

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & ex.StackTrace)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		Finally

			sqlProcess.Close()

		End Try

	End Sub

#End Region

End Class
