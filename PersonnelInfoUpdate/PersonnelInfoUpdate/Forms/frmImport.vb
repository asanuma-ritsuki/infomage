Public Class frmImport

#Region "フォームイベント"

	''' <summary>
	''' フォームロード時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub frmImport_Load(sender As Object, e As EventArgs) Handles MyBase.Load

		Me.Text = My.Application.Info.ProductName & " Ver." &
			My.Application.Info.Version.ToString & " - [インポート画面]"
		Me.KeyPreview = True
		CaptionDisplayMode = StatusDisplayMode.TitleOnly

		Initialize()

	End Sub

	''' <summary>
	''' フォームクロージング
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub frmImport_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

		XmlSettings.LoadFromXmlFile()
		XmlSettings.Instance.ImportExcelFile = Me.txtImportExcel.Text
		XmlSettings.Instance.ImportSaveFolder = Me.txtSaveFolder.Text
		XmlSettings.Instance.ImportLogFolder = Me.txtLogFolder.Text
		XmlSettings.SaveToXmlFile()

	End Sub


#End Region

#Region "オブジェクトイベント"

	''' <summary>
	''' 閉じるボタン押下時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
		Me.Close()
	End Sub

	''' <summary>
	''' テキストボックスドラッグエンター時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub TextBox_DragEnter(sender As Object, e As DragEventArgs) Handles txtImportExcel.DragEnter, txtImportUsr.DragEnter, txtSaveFolder.DragEnter, txtLogFolder.DragEnter

		If e.Data.GetDataPresent(DataFormats.FileDrop) Then
			e.Effect = DragDropEffects.Copy
		Else
			e.Effect = DragDropEffects.None
		End If

	End Sub

	''' <summary>
	''' インポートエクセルドラッグドロップ時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub txtImportExcel_DragDrop(sender As Object, e As DragEventArgs) Handles txtImportExcel.DragDrop

		Dim strFiles As String() = CType(e.Data.GetData(DataFormats.FileDrop, False), String())

		If System.IO.File.Exists(strFiles(0)) And System.IO.Path.GetExtension(strFiles(0)) = ".xlsx" Then
			Me.txtImportExcel.Text = strFiles(0)
		End If

	End Sub

	''' <summary>
	''' インポート利用者情報ドラッグドロップ時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub txtImportUsr_DragDrop(sender As Object, e As DragEventArgs) Handles txtImportUsr.DragDrop

		Dim strFiles As String() = CType(e.Data.GetData(DataFormats.FileDrop, False), String())

		If System.IO.File.Exists(strFiles(0)) And System.IO.Path.GetExtension(strFiles(0)) = ".csv" Then
			Me.txtImportUsr.Text = strFiles(0)
		End If

	End Sub

	''' <summary>
	''' テキストボックスドラッグドロップ時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub TextBox_DragDrop(sender As Object, e As DragEventArgs) Handles txtSaveFolder.DragDrop, txtLogFolder.DragDrop

		Dim strFiles As String() = CType(e.Data.GetData(DataFormats.FileDrop, False), String())
		Dim txtFolder As TextBox = CType(sender, TextBox)

		If System.IO.File.Exists(strFiles(0)) Then
			txtFolder.Text = System.IO.Path.GetDirectoryName(strFiles(0))
		Else
			If System.IO.Directory.Exists(strFiles(0)) Then
				txtFolder.Text = strFiles(0)
			End If
		End If

	End Sub

	''' <summary>
	''' インポートエクセルブラウズボタン押下時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub btnImportExcelBrowse_Click(sender As Object, e As EventArgs) Handles btnImportExcelBrowse.Click

		Dim strFilter As String = "Excelファイル(*.xlsx)|*.xlsx"
		Me.txtImportExcel.Text = FileBrowse(Me.txtImportExcel, strFilter)

	End Sub

	''' <summary>
	''' インポート利用者情報ブラウズボタン押下時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub btnImportUsrBrowse_Click(sender As Object, e As EventArgs) Handles btnImportUsrBrowse.Click

		Dim strFilter As String = "CSVファイル(*.csv)|*.csv"
		Me.txtImportExcel.Text = FileBrowse(Me.txtImportExcel, strFilter)

	End Sub

	''' <summary>
	''' 保存先フォルダブラウズボタン押下時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub btnSaveFolderBrowse_Click(sender As Object, e As EventArgs) Handles btnSaveFolderBrowse.Click

		Me.txtSaveFolder.Text = FolderBrowse(Me.txtSaveFolder)

	End Sub

	''' <summary>
	''' ログフォルダブラウズボタン押下時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub btnLogFolderBrowse_Click(sender As Object, e As EventArgs) Handles btnLogFolderBrowse.Click

		Me.txtLogFolder.Text = FolderBrowse(Me.txtLogFolder)

	End Sub

	''' <summary>
	''' インポートボタン押下時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub btnImport_Click(sender As Object, e As EventArgs) Handles btnImport.Click

		'ファイル、フォルダチェック
		If Not System.IO.File.Exists(Me.txtImportExcel.Text) Then
			MessageBox.Show("インポートエクセルファイルを指定してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Exit Sub
		End If
		If Not System.IO.Directory.Exists(Me.txtSaveFolder.Text) Then
			MessageBox.Show("保存先フォルダを指定してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Exit Sub
		End If
		If Not System.IO.Directory.Exists(Me.txtLogFolder.Text) Then
			MessageBox.Show("ログフォルダを指定してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Exit Sub
		End If
		If Me.cmbOffice.SelectedIndex < 0 Then
			MessageBox.Show("事業所を選択してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Exit Sub
		End If
		If IsNull(Me.numStart.Value) Then
			MessageBox.Show("エクセルファイルの開始行を指定してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Exit Sub
		End If

		If MessageBox.Show("インポートを開始します" & vbNewLine & "よろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
			Exit Sub
		End If

		EnableControls(Me, False)
		Me.lstResult.Items.Clear()

		'インポート日時を取得
		Dim dateImportDate As DateTime = DateTime.Now
		Dim strImportDateTime As String = dateImportDate.ToString("yyyy/MM/dd HH:mm:ss")
		'保存フォルダ作成用
		Dim strImportDate As String = Date.Now.ToString("yyyyMMdd")
		'インポートエクセルファイル
		Dim strImportExcel As String = Me.txtImportExcel.Text
		'利用者情報CSV
		Dim strImportUsr As String = Me.txtImportUsr.Text
		'開始行
		Dim iStartRec As Integer = Me.numStart.Value
		'保存先フォルダ
		Dim strSaveFolder As String = Me.txtSaveFolder.Text & "\" & strImportDate
		'ログ保存先フォルダ
		Dim strLogFolder As String = Me.txtLogFolder.Text & "\" & strImportDate

		'インポート開始
		WriteLstResult(Me.lstResult, "インポート開始")
		WriteLstResult(Me.lstResult, "インポートエクセルファイル：" & strImportExcel)
		WriteLstResult(Me.lstResult, Me.numStart.Value & "行目からインポート")
		WriteLstResult(Me.lstResult, "保存先フォルダ：" & strSaveFolder)
		If Not System.IO.Directory.Exists(strSaveFolder) Then
			System.IO.Directory.CreateDirectory(strSaveFolder)
			WriteLstResult(Me.lstResult, "フォルダ作成：" & strSaveFolder)
		End If
		WriteLstResult(Me.lstResult, "ログフォルダ：" & strLogFolder)

		Dim iCount As Integer = 0
		Dim iRecCount As Integer = 0
		Dim strSQL As String = ""
		Dim sqlProcess As New SQLProcess
		Dim dt As DataTable = Nothing
		Dim strLotID As String = dateImportDate.ToString("yyyyMMddHHmmss")  'ロットIDを作成
		WriteLstResult(Me.lstResult, "ロットID：" & strLotID)

		Try
			'==================================================
			'ロット管理テーブルへのINSERT
			'==================================================
			'すでに取り込み済みのエクセルファイルかどうかをチェックする
			WriteLstResult(Me.lstResult, "ロット管理テーブルへのINSERT：" & strLotID)
			strSQL = "SELECT COUNT(*) FROM T_ロット管理 "
			strSQL &= "WHERE エクセルファイル = '" & System.IO.Path.GetFileName(strImportExcel) & "'"
			Dim iExist As Integer = sqlProcess.DB_EXECUTE_SCALAR(strSQL)
			If iExist > 0 Then
				MessageBox.Show("取り込み済みのエクセルファイルです" & vbNewLine & "内容を確認してファイル名を変更してからインポートしてください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
				WriteLstResult(Me.lstResult, "取り込み済のエクセルファイル：" & strImportExcel)
				Exit Sub
			End If
			strSQL = "INSERT INTO T_ロット管理(ロットID, 処理日, エクセルファイル, 事業所ID, インポート日時, 削除フラグ) VALUES("
			strSQL &= "'" & strLotID & "'"
			strSQL &= ", '" & dateImportDate.ToString("yyyy/MM/dd") & "'"
			strSQL &= ", '" & System.IO.Path.GetFileName(strImportExcel) & "'"
			strSQL &= ", " & Me.cmbOffice.Value
			strSQL &= ", '" & dateImportDate.ToString("yyyy/MM/dd HH:mm:ss") & "'"
			strSQL &= ", 0)"
			sqlProcess.DB_UPDATE(strSQL)
			'==================================================
			'対象エクセルから値を取り出してT_異動情報に書き込む
			'==================================================
			WriteLstResult(Me.lstResult, "エクセルファイルの読み込み開始：" & System.IO.Path.GetFileName(strImportExcel))
			dt = ReadExcel(strImportExcel, iStartRec)
			strSQL = "SELECT ISNULL(MAX(レコード番号), 0) + 1 AS レコード番号 "
			strSQL &= "FROM T_異動情報 "
			strSQL &= "WHERE ロットID = '" & strLotID & "'"
			Dim iRecNumber As Integer = sqlProcess.DB_EXECUTE_SCALAR(strSQL)
			For iRow As Integer = 0 To dt.Rows.Count - 1
				strSQL = "INSERT INTO T_異動情報(ロットID, レコード番号, 発令日, 辞令, ユーザーID, 利用者名称, 利用者名称カナ, "
				strSQL &= "役職コード, 組織コード1, 組織コード2, 組織コード3, 組織コード4, 組織コード5, 海外, 管理者権限, 部門管理者権限) VALUES("
				strSQL &= "'" & strLotID & "'"
				strSQL &= ", " & iRecNumber
				strSQL &= ", '" & IIf(IsDate(dt.Rows(iRow)("発令日")), CDate(dt.Rows(iRow)("発令日")).ToString("yyyy/MM/dd"), dt.Rows(iRow)("発令日")) & "'"
				strSQL &= ", '" & dt.Rows(iRow)("辞令").ToString.Trim(" ").Trim("　") & "'"
				strSQL &= ", '" & dt.Rows(iRow)("ユーザーID").ToString.Trim(" ").Trim("　") & "'"
				strSQL &= ", '" & dt.Rows(iRow)("利用者名称").ToString.Trim(" ").Trim("　") & "'"
				strSQL &= ", '" & dt.Rows(iRow)("利用者名称カナ").ToString.Trim(" ").Trim("　") & "'"
				strSQL &= ", '" & dt.Rows(iRow)("役職コード").ToString.Trim(" ").Trim("　") & "'"
				strSQL &= ", '" & dt.Rows(iRow)("組織コード1").ToString.Trim(" ").Trim("　") & "'"
				strSQL &= ", '" & dt.Rows(iRow)("組織コード2").ToString.Trim(" ").Trim("　") & "'"
				strSQL &= ", '" & dt.Rows(iRow)("組織コード3").ToString.Trim(" ").Trim("　") & "'"
				strSQL &= ", '" & dt.Rows(iRow)("組織コード4").ToString.Trim(" ").Trim("　") & "'"
				strSQL &= ", '" & dt.Rows(iRow)("組織コード5").ToString.Trim(" ").Trim("　") & "'"
				strSQL &= ", " & IIf(dt.Rows(iRow)("海外").ToString.Trim(" ").Trim("　") = "○", 1, 0)
				strSQL &= ", " & IIf(dt.Rows(iRow)("管理者権限").ToString.Trim(" ").Trim("　") = "○", 1, 0)
				strSQL &= ", " & IIf(dt.Rows(iRow)("部門管理者権限").ToString.Trim(" ").Trim("　") = "○", 1, 0) & ")"
				sqlProcess.DB_UPDATE(strSQL)
				iRecNumber += 1
			Next
			WriteLstResult(Me.lstResult, "エクセルファイルの読み込み終了：" & System.IO.Path.GetFileName(strImportExcel))
			'==================================================
			'利用者情報CSVを読み込んでT_利用者情報に書き込む
			'==================================================
			WriteLstResult(Me.lstResult, "利用者情報CSVの読み込み開始：" & System.IO.Path.GetFileName(strImportUsr))

			Using parser As New CSVParser(strImportUsr, System.Text.Encoding.GetEncoding("Shift-JIS"))
				parser.Delimiter = ","  'カンマ区切り

				parser.HasFieldsEnclosedInQuotes = True 'データ内にデリミタがあっても区切らない
				parser.TrimWhiteSpace = False   '空白を削除しない

				iRecCount = 0

				parser.ReadFields() 'ヘッダ業を読み飛ばす
				'最終行まで読み込み
				While Not parser.EndOfData
					'レコード番号の最大値を取得
					strSQL = "SELECT ISNULL(MAX(レコード番号), 0) + 1 FROM T_利用者情報 "
					strSQL &= "WHERE ロットID = '" & strLotID & "'"
					iRecNumber = sqlProcess.DB_EXECUTE_SCALAR(strSQL)

					Dim row As String() = parser.ReadFields()   '1行読み込み、項目を配列に代入

					'T_利用者情報テーブルに書き込み
					strSQL = "INSERT INTO T_利用者情報(ロットID, レコード番号, 更新区分, 社員番号, 利用者名称, 利用者名称カナ, "
					strSQL &= "役職コード別名, 所属組織コード1, 有効期間From, 有効期間To, 連絡優先フラグ, IVR有りフラグ, "
					strSQL &= "所属組織コード2, 所属組織コード3, 所属組織コード4, 所属組織コード5, メールアドレス1, メールアドレス2, "
					strSQL &= "電話番号1, 電話番号2, 都道府県コード, 勤務地都道府県コード) VALUES("
					strSQL &= "'" & strLotID & "'"
					strSQL &= ", " & iRecNumber
					strSQL &= ", '" & row(0).Trim(" ").Trim("　") & "'"  '更新区分
					strSQL &= ", '" & row(1).Trim(" ").Trim("　") & "'"  '社員番号
					strSQL &= ", N'" & row(2).Trim(" ").Trim("　") & "'"  '利用者名称
					strSQL &= ", N'" & row(3).Trim(" ").Trim("　") & "'"  '利用者名称カナ
					strSQL &= ", '" & row(4).Trim(" ").Trim("　") & "'"  '役職コード別名
					strSQL &= ", '" & row(5).Trim(" ").Trim("　") & "'"  '所属組織コード1
					strSQL &= ", '" & row(6).Trim(" ").Trim("　") & "'"  '有効期間From
					strSQL &= ", '" & row(7).Trim(" ").Trim("　") & "'"  '有効期間To
					strSQL &= ", '" & row(8).Trim(" ").Trim("　") & "'"  '連絡優先フラグ
					strSQL &= ", '" & row(9).Trim(" ").Trim("　") & "'"  'IVR有りフラグ
					strSQL &= ", '" & row(10).Trim(" ").Trim("　") & "'" '所属組織コード2
					strSQL &= ", '" & row(11).Trim(" ").Trim("　") & "'" '所属組織コード3
					strSQL &= ", '" & row(12).Trim(" ").Trim("　") & "'" '所属組織コード4
					strSQL &= ", '" & row(13).Trim(" ").Trim("　") & "'" '所属組織コード5
					strSQL &= ", '" & row(14).Trim(" ").Trim("　") & "'" 'メールアドレス1
					strSQL &= ", '" & row(15).Trim(" ").Trim("　") & "'" 'メールアドレス2
					strSQL &= ", '" & row(16).Trim(" ").Trim("　") & "'" '電話番号1
					strSQL &= ", '" & row(17).Trim(" ").Trim("　") & "'" '電話番号2
					strSQL &= ", '" & row(18).Trim(" ").Trim("　") & "'" '都道府県コード
					strSQL &= ", '" & row(19).Trim(" ").Trim("　") & "')"    '勤務地都道府県コード
					sqlProcess.DB_UPDATE(strSQL)
				End While

			End Using
			WriteLstResult(Me.lstResult, "利用者情報CSVの読み込み終了：" & System.IO.Path.GetFileName(strImportUsr))
			'==================================================
			'データマッチング処理
			'==================================================
			WriteLstResult(Me.lstResult, "データマッチング処理開始")

			WriteLstResult(Me.lstResult, "データマッチング処理終了")

			MessageBox.Show("インポート処理が終了しました", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information)

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & ex.StackTrace)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		Finally

			sqlProcess.Close()
			EnableControls(Me, True)

		End Try

	End Sub

#End Region

#Region "プライベートメソッド"

	''' <summary>
	''' 初期化処理
	''' </summary>
	Private Sub Initialize()

		Me.btnBack.Text = "閉じる"
		XmlSettings.LoadFromXmlFile()
		Me.txtImportExcel.Text = XmlSettings.Instance.ImportExcelFile
		Me.txtSaveFolder.Text = XmlSettings.Instance.ImportSaveFolder
		Me.txtLogFolder.Text = XmlSettings.Instance.ImportLogFolder

		Dim strSQL As String = ""
		Dim sqlProcess As New SQLProcess

		Try
			strSQL = "SELECT 事業所ID, 事業所 FROM M_事業所 "
			strSQL &= "ORDER BY 事業所ID"
			Dim dt As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
			Me.cmbOffice.ItemsDataSource = dt
			Me.cmbOffice.ItemsDisplayMember = "事業所"
			Me.cmbOffice.ItemsValueMember = "事業所ID"

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & ex.StackTrace)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		Finally

			sqlProcess.Close()

		End Try

	End Sub

	''' <summary>
	''' データベース削除(テスト用)
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click

		If MessageBox.Show("利用者情報と異動情報を削除します" & vbNewLine & "よろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
			Exit Sub
		End If

		Dim strSQL As String = ""
		Dim sqlProcess As New SQLProcess

		Try
			strSQL = "DELETE FROM T_利用者情報"
			sqlProcess.DB_UPDATE(strSQL)
			strSQL = "DELETE FROM T_異動情報"
			sqlProcess.DB_UPDATE(strSQL)
			strSQL = "DELETE FROM T_ロット管理"
			sqlProcess.DB_UPDATE(strSQL)

			MessageBox.Show("該当テーブルを削除しました", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information)

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & ex.StackTrace)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		Finally

			sqlProcess.Close()

		End Try

	End Sub

#End Region

End Class