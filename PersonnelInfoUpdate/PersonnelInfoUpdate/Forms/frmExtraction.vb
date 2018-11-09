Public Class frmExtraction

#Region "フォームイベント"

	''' <summary>
	''' フォームロード時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub frmOutput_Load(sender As Object, e As EventArgs) Handles MyBase.Load

		Me.Text = My.Application.Info.ProductName & " Ver." &
			My.Application.Info.Version.ToString & " - [データ抽出画面]"
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
		'XmlSettings.Instance.ImportExcelFile = Me.txtImportExcel.Text
		'XmlSettings.Instance.ImportSaveFolder = Me.txtSaveFolder.Text
		XmlSettings.Instance.OutputFolder = Me.txtOutputFolder.Text
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
	Private Sub txtOutputFolder_DragEnter(sender As Object, e As DragEventArgs) Handles txtOutputFolder.DragEnter, txtLogFolder.DragEnter, txtImportUsr.DragEnter, txtImportManager.DragEnter
		If e.Data.GetDataPresent(DataFormats.FileDrop) Then
			e.Effect = DragDropEffects.Copy
		Else
			e.Effect = DragDropEffects.None
		End If
	End Sub

	''' <summary>
	''' 出力フォルダドラッグドロップ時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub txtOutputFolder_DragDrop(sender As Object, e As DragEventArgs) Handles txtOutputFolder.DragDrop

		Dim strFiles As String() = CType(e.Data.GetData(DataFormats.FileDrop, False), String())
		If System.IO.Directory.Exists(strFiles(0)) Then
			Me.txtOutputFolder.Text = strFiles(0)
		End If

	End Sub

	''' <summary>
	''' ログフォルダドラッグドロップ時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub txtLogFolder_DragDrop(sender As Object, e As DragEventArgs) Handles txtLogFolder.DragDrop

		Dim strFiles As String() = CType(e.Data.GetData(DataFormats.FileDrop, False), String())
		If System.IO.Directory.Exists(strFiles(0)) Then
			Me.txtLogFolder.Text = strFiles(0)
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
	''' インポート管理者情報ドラッグドロップ時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub txtImportManager_DragDrop(sender As Object, e As DragEventArgs) Handles txtImportManager.DragDrop

		Dim strFiles As String() = CType(e.Data.GetData(DataFormats.FileDrop, False), String())

		If System.IO.File.Exists(strFiles(0)) And System.IO.Path.GetExtension(strFiles(0)) = ".csv" Then
			Me.txtImportManager.Text = strFiles(0)
		End If

	End Sub

	''' <summary>
	''' 出力フォルダブラウズボタン押下時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub btnOutputFolderBrowse_Click(sender As Object, e As EventArgs) Handles btnOutputFolderBrowse.Click

		Me.txtOutputFolder.Text = FolderBrowse(Me.txtOutputFolder.Text)

	End Sub

	''' <summary>
	''' ログ保存先フォルダブラウズボタン押下時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub btnLogFolderBrowse_Click(sender As Object, e As EventArgs) Handles btnLogFolderBrowse.Click

		Me.txtLogFolder.Text = FolderBrowse(Me.txtLogFolder.Text)

	End Sub

	''' <summary>
	''' インポート利用者情報ブラウズボタン押下時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub btnImportUsrBrowse_Click(sender As Object, e As EventArgs) Handles btnImportUsrBrowse.Click

		Dim strFilter As String = "CSVファイル(*.csv)|*.csv"
		Me.txtImportUsr.Text = FileBrowse(Me.txtImportUsr, strFilter)

	End Sub

	''' <summary>
	''' インポート利用者情報ブラウズボタン押下時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub btnImportManagerBrowse_Click(sender As Object, e As EventArgs) Handles btnImportManagerBrowse.Click

		Dim strFilter As String = "CSVファイル(*.csv)|*.csv"
		Me.txtImportManager.Text = FileBrowse(Me.txtImportManager, strFilter)

	End Sub

	''' <summary>
	''' 実行ボタン押下時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub btnOutput_Click(sender As Object, e As EventArgs) Handles btnOutput.Click

		'ファイル、フォルダチェック
		If Not System.IO.File.Exists(Me.txtImportUsr.Text) Then
			MessageBox.Show("利用者情報CSVファイルを指定してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Exit Sub
		End If
		'2018/11/08
		'管理者情報CSVはなくても動作させるように変更
		'If Not System.IO.File.Exists(Me.txtImportManager.Text) Then
		'	MessageBox.Show("管理者情報CSVファイルを指定してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
		'	Exit Sub
		'End If
		If Not System.IO.Directory.Exists(Me.txtOutputFolder.Text) Then
			MessageBox.Show("CSVファイルを出力するフォルダを指定してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Exit Sub
		End If
		If Not System.IO.Directory.Exists(Me.txtLogFolder.Text) Then
			MessageBox.Show("ログを保存するフォルダを指定してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Exit Sub
		End If
		If MessageBox.Show("該当ロットIDの利用者情報、管理者情報をCSVファイルより抽出します" & vbNewLine & "よろしいですか？" & vbNewLine & "ロットID：" & Me.txtLotID.Text, "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
			Exit Sub
		End If

		EnableControls(Me, False)
		Me.lstResult.Items.Clear()
		WriteLstResult(Me.lstResult, "データ抽出処理開始")

		Dim strLotID As String = Me.txtLotID.Text
		Dim strImportUsr As String = Me.txtImportUsr.Text
		Dim strImportManager As String = Me.txtImportManager.Text
		Dim strOutputFolder As String = Me.txtOutputFolder.Text & "\" & strLotID
		Dim strLogFolder As String = Me.txtLogFolder.Text & "\" & strLotID

		'インポート開始
		WriteLstResult(Me.lstResult, "インポート開始")
		WriteLstResult(Me.lstResult, "利用者情報CSV：" & strImportUsr)
		WriteLstResult(Me.lstResult, "管理者情報CSV：" & strImportManager)
		WriteLstResult(Me.lstResult, "出力フォルダ：" & strOutputFolder)
		WriteLstResult(Me.lstResult, "ログ保存フォルダ：" & strLogFolder)
		WriteLstResult(Me.lstResult, "ロットID：" & strLotID)

		Dim iRecCount As Integer = 0
		Dim strSQL As String = ""
		Dim sqlProcess As New SQLProcess

		Try

			'==================================================
			'利用者情報CSVを読み込んでT_利用者情報抽出に書き込む
			'==================================================
			WriteLstResult(Me.lstResult, "利用者情報CSVの読み込み開始：" & System.IO.Path.GetFileName(strImportUsr))

			strSQL = "DELETE FROM T_利用者情報抽出 "
			strSQL &= "WHERE ロットID = '" & strLotID & "'"
			sqlProcess.DB_UPDATE(strSQL)

			Using parser As New CSVParser(strImportUsr, System.Text.Encoding.GetEncoding("Shift-JIS"))
				parser.Delimiter = ","  'カンマ区切り
				parser.HasFieldsEnclosedInQuotes = True
				parser.TrimWhiteSpace = False

				iRecCount = 0

				parser.ReadFields() 'ヘッダ行を読み飛ばす
				'最終行まで読み込み
				While Not parser.EndOfData
					iRecCount += 1
					Dim row As String() = parser.ReadFields()   '1行読み込み、項目を配列に代入
					'T_利用者情報抽出に書き込み
					strSQL = "INSERT INTO T_利用者情報抽出(ロットID, レコード番号, 更新区分, 社員番号, 利用者名称, 利用者名称カナ, "
					strSQL &= "役職コード別名, 所属組織コード1, 有効期間From, 有効期間To, 連絡優先フラグ, IVR有りフラグ, "
					strSQL &= "所属組織コード2, 所属組織コード3, 所属組織コード4, 所属組織コード5, メールアドレス1, メールアドレス2, "
					strSQL &= "電話番号1, 電話番号2, 都道府県コード, 勤務地都道府県コード) VALUES("
					strSQL &= "'" & strLotID & "'"
					strSQL &= ", " & iRecCount
					strSQL &= ", '" & row(0).Trim(" ").Trim("　") & "'"  '更新区分
					strSQL &= ", '" & row(1).Trim(" ").Trim("　") & "'"  '社員番号
					strSQL &= ", '" & row(2).Trim(" ").Trim("　") & "'"  '利用者名称
					strSQL &= ", '" & row(3).Trim(" ").Trim("　") & "'"  '利用者名称カナ
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
			WriteLstResult(Me.lstResult, "利用者情報CSVの読み込み完了：" & iRecCount & "レコード")

			strSQL = "DELETE FROM T_管理者情報抽出 "
			strSQL &= "WHERE ロットID = '" & strLotID & "'"
			sqlProcess.DB_UPDATE(strSQL)

			If Not IsNull(Me.txtImportManager.Text) Then
				WriteLstResult(Me.lstResult, "管理者情報CSVの読み込み開始：" & System.IO.Path.GetFileName(strImportManager))

				Using parser As New CSVParser(strImportManager, System.Text.Encoding.GetEncoding("Shift-JIS"))
					parser.Delimiter = ","  'カンマ区切り
					parser.HasFieldsEnclosedInQuotes = True
					parser.TrimWhiteSpace = False

					iRecCount = 0

					parser.ReadFields() 'ヘッダ行を読み飛ばす
					'最終行まで読み込み
					While Not parser.EndOfData
						iRecCount += 1
						Dim row As String() = parser.ReadFields()   '1行読み込み、項目を配列に代入
						'T_管理者情報抽出に書き込み
						strSQL = "INSERT INTO T_管理者情報抽出(ロットID, レコード番号, ユーザーID, ご利用者名, 役職, 利用者種別, "
						strSQL &= "優先順位, メール登録数, TEL登録数, 災害変更通知, アクセス制御権限, 機能制限, "
						strSQL &= "所属部署1, 所属部署2, 所属部署3, 所属部署4, 所属部署5) VALUES("
						strSQL &= "'" & strLotID & "'"
						strSQL &= ", " & iRecCount
						strSQL &= ", '" & row(0).Trim(" ").Trim("　") & "'"  'ユーザーID
						strSQL &= ", '" & row(1).Trim(" ").Trim("　") & "'"  'ご利用者名
						strSQL &= ", '" & row(2).Trim(" ").Trim("　") & "'"  '役職
						strSQL &= ", '" & row(3).Trim(" ").Trim("　") & "'"  '利用者種別
						strSQL &= ", '" & row(4).Trim(" ").Trim("　") & "'"  '優先順位
						strSQL &= ", '" & row(5).Trim(" ").Trim("　") & "'"  'メール登録数
						strSQL &= ", '" & row(6).Trim(" ").Trim("　") & "'"  'TEL登録数
						strSQL &= ", '" & row(7).Trim(" ").Trim("　") & "'"  '災害変更通知
						strSQL &= ", '" & row(8).Trim(" ").Trim("　") & "'"  'アクセス制御権限
						strSQL &= ", '" & row(9).Trim(" ").Trim("　") & "'"  '機能制限
						strSQL &= ", '" & row(10).Trim(" ").Trim("　") & "'" '所属部署1
						strSQL &= ", '" & row(11).Trim(" ").Trim("　") & "'" '所属部署2
						strSQL &= ", '" & row(12).Trim(" ").Trim("　") & "'" '所属部署3
						strSQL &= ", '" & row(13).Trim(" ").Trim("　") & "'" '所属部署4
						strSQL &= ", '" & row(14).Trim(" ").Trim("　") & "')" '所属部署5
						sqlProcess.DB_UPDATE(strSQL)

					End While

				End Using
				WriteLstResult(Me.lstResult, "管理者情報CSVの読み込み完了：" & iRecCount & "レコード")
			Else
				WriteLstResult(Me.lstResult, "管理者情報CSV：なし")
			End If

			WriteLstResult(Me.lstResult, "利用者情報の抽出開始")
			strSQL = "SELECT 更新区分, 社員番号, 利用者名称, 利用者名称カナ, 役職コード別名, 所属組織コード1, "
			strSQL &= "有効期間From, 有効期間To, 連絡優先フラグ, IVR有りフラグ, 所属組織コード2, 所属組織コード3, "
			strSQL &= "所属組織コード4, 所属組織コード5, メールアドレス1, メールアドレス2, 電話番号1, 電話番号2, "
			strSQL &= "都道府県コード, 勤務地都道府県コード "
			strSQL &= "FROM T_利用者情報抽出 "
			strSQL &= "WHERE ロットID = '" & strLotID & "' "
			strSQL &= "AND 社員番号 IN ("
			strSQL &= "SELECT T1.社員番号 "
			strSQL &= "FROM T_利用者情報出力 AS T1 LEFT OUTER JOIN "
			strSQL &= "(SELECT ロットID, レコード番号, ユーザーID, 対象外 FROM T_不備内容 "
			strSQL &= "WHERE ロットID = '" & strLotID & "' "
			strSQL &= "GROUP BY ロットID, レコード番号, ユーザーID, 対象外) AS T2 ON T1.ロットID = T2.ロットID "
			strSQL &= "AND T1.レコード番号 = T2.レコード番号 "
			strSQL &= "WHERE T1.ロットID = '" & strLotID & "' "
			strSQL &= "AND ISNULL(T2.対象外, 0) = 0 "
			strSQL &= "AND T1.更新区分 = 1) "
			strSQL &= "ORDER BY レコード番号"
			Dim dt As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
			Dim strHeader As String = Chr(34) & "更新区分" & Chr(34) & "," & Chr(34) & "社員番号" & Chr(34) & "," & Chr(34) & "利用者名称" & Chr(34) & "," & Chr(34) & "利用者名称カナ" & Chr(34)
			strHeader &= "," & Chr(34) & "役職コード別名" & Chr(34) & "," & Chr(34) & "所属組織コード1" & Chr(34) & "," & Chr(34) & "有効期間(From)" & Chr(34) & "," & Chr(34) & "有効期間(To)" & Chr(34)
			strHeader &= "," & Chr(34) & "連絡優先フラグ" & Chr(34) & "," & Chr(34) & "IVR有りフラグ" & Chr(34) & "," & Chr(34) & "所属組織コード2" & Chr(34) & "," & Chr(34) & "所属組織コード3" & Chr(34)
			strHeader &= "," & Chr(34) & "所属組織コード4" & Chr(34) & "," & Chr(34) & "所属組織コード5" & Chr(34) & "," & Chr(34) & "メールアドレス１" & Chr(34) & "," & Chr(34) & "メールアドレス２" & Chr(34)
			strHeader &= "," & Chr(34) & "電話番号１" & Chr(34) & "," & Chr(34) & "電話番号２" & Chr(34) & "," & Chr(34) & "都道府県コード" & Chr(34) & "," & Chr(34) & "勤務地都道府県コード" & Chr(34)

			iRecCount = 0
			Dim strDate As String = Date.Now.ToString("yyyyMMdd")
			Dim strOutputFile As String = strOutputFolder & "\更新情報_利用者情報_" & Me.txtOffice.Text & "_" & strDate & ".csv"
			Using sw As New System.IO.StreamWriter(strOutputFile, False, System.Text.Encoding.GetEncoding("Shift-JIS"))
				'ヘッダの書き込み
				sw.WriteLine(strHeader)
				Dim strWriteLine As String = ""
				For iRow As Integer = 0 To dt.Rows.Count - 1
					iRecCount += 1
					strWriteLine = Chr(34) & dt.Rows(iRow)("更新区分") & Chr(34)
					strWriteLine &= "," & Chr(34) & dt.Rows(iRow)("社員番号") & Chr(34)
					strWriteLine &= "," & Chr(34) & dt.Rows(iRow)("利用者名称") & Chr(34)
					strWriteLine &= "," & Chr(34) & dt.Rows(iRow)("利用者名称カナ") & Chr(34)
					strWriteLine &= "," & Chr(34) & dt.Rows(iRow)("役職コード別名") & Chr(34)
					strWriteLine &= "," & Chr(34) & dt.Rows(iRow)("所属組織コード1") & Chr(34)
					strWriteLine &= "," & Chr(34) & dt.Rows(iRow)("有効期間From") & Chr(34)
					strWriteLine &= "," & Chr(34) & dt.Rows(iRow)("有効期間To") & Chr(34)
					strWriteLine &= "," & Chr(34) & dt.Rows(iRow)("連絡優先フラグ") & Chr(34)
					strWriteLine &= "," & Chr(34) & dt.Rows(iRow)("IVR有りフラグ") & Chr(34)
					strWriteLine &= "," & Chr(34) & dt.Rows(iRow)("所属組織コード2") & Chr(34)
					strWriteLine &= "," & Chr(34) & dt.Rows(iRow)("所属組織コード3") & Chr(34)
					strWriteLine &= "," & Chr(34) & dt.Rows(iRow)("所属組織コード4") & Chr(34)
					strWriteLine &= "," & Chr(34) & dt.Rows(iRow)("所属組織コード5") & Chr(34)
					strWriteLine &= "," & Chr(34) & dt.Rows(iRow)("メールアドレス1") & Chr(34)
					strWriteLine &= "," & Chr(34) & dt.Rows(iRow)("メールアドレス2") & Chr(34)
					strWriteLine &= "," & Chr(34) & dt.Rows(iRow)("電話番号1") & Chr(34)
					strWriteLine &= "," & Chr(34) & dt.Rows(iRow)("電話番号2") & Chr(34)
					strWriteLine &= "," & Chr(34) & dt.Rows(iRow)("都道府県コード") & Chr(34)
					strWriteLine &= "," & Chr(34) & dt.Rows(iRow)("勤務地都道府県コード") & Chr(34)
					sw.WriteLine(strWriteLine)
				Next

			End Using
			WriteLstResult(Me.lstResult, "利用者情報の抽出完了：" & iRecCount & "レコード")

			WriteLstResult(Me.lstResult, "管理者情報の抽出開始")
			strSQL = "SELECT ユーザーID, ご利用者名, 役職, 利用者種別, 優先順位, メール登録数, TEL登録数, 災害変更通知, "
			strSQL &= "アクセス制御権限, 機能制限, 所属部署1, 所属部署2, 所属部署3, 所属部署4, 所属部署5 "
			strSQL &= "FROM T_管理者情報抽出 "
			strSQL &= "WHERE ロットID = '" & strLotID & "' "
			strSQL &= "AND ユーザーID IN ("
			strSQL &= "SELECT T1.社員番号 FROM T_利用者情報出力 AS T1 LEFT OUTER JOIN "
			strSQL &= "(SELECT ロットID, レコード番号, ユーザーID, 対象外 FROM T_不備内容 "
			strSQL &= "WHERE ロットID = '" & strLotID & "' "
			strSQL &= "GROUP BY ロットID, レコード番号, ユーザーID, 対象外) AS T2 ON T1.ロットID = T2.ロットID "
			strSQL &= "AND T1.レコード番号 = T2.レコード番号 "
			strSQL &= "WHERE T1.ロットID = '" & strLotID & "' "
			strSQL &= "AND ISNULL(T2.対象外, 0) = 0 "
			strSQL &= "AND T1.更新区分 = 1 "
			strSQL &= "AND T1.役職コード別名 != '') "
			strSQL &= "ORDER BY レコード番号"
			dt = sqlProcess.DB_SELECT_DATATABLE(strSQL)

			strHeader = Chr(34) & "ユーザーＩＤ" & Chr(34) & "," & Chr(34) & "ご利用者名" & Chr(34) & "," & Chr(34) & "役職" & Chr(34) & "," & Chr(34) & "利用者種別" & Chr(34)
			strHeader &= "," & Chr(34) & "優先順位" & Chr(34) & "," & Chr(34) & "メール登録数" & Chr(34) & "," & Chr(34) & "TEL登録数" & Chr(34) & "," & Chr(34) & "災害変更通知" & Chr(34)
			strHeader &= "," & Chr(34) & "アクセス制御権限" & Chr(34) & "," & Chr(34) & "機能制限" & Chr(34) & "," & Chr(34) & "所属部署１" & Chr(34) & "," & Chr(34) & "所属部署２" & Chr(34)
			strHeader &= "," & Chr(34) & "所属部署３" & Chr(34) & "," & Chr(34) & "所属部署４" & Chr(34) & "," & Chr(34) & "所属部署５" & Chr(34)

			iRecCount = 0
			strOutputFile = strOutputFolder & "\更新情報_管理者情報_" & Me.txtOffice.Text & "_" & strDate & ".csv"
			Using sw As New System.IO.StreamWriter(strOutputFile, False, System.Text.Encoding.GetEncoding("Shift-JIS"))
				'ヘッダの書き込み
				sw.WriteLine(strHeader)
				Dim strWriteLine As String = ""
				For iRow As Integer = 0 To dt.Rows.Count - 1
					iRecCount += 1
					strWriteLine = Chr(34) & dt.Rows(iRow)("ユーザーID") & Chr(34)
					strWriteLine &= "," & Chr(34) & dt.Rows(iRow)("ご利用者名") & Chr(34)
					strWriteLine &= "," & Chr(34) & dt.Rows(iRow)("役職") & Chr(34)
					strWriteLine &= "," & Chr(34) & dt.Rows(iRow)("利用者種別") & Chr(34)
					strWriteLine &= "," & Chr(34) & dt.Rows(iRow)("優先順位") & Chr(34)
					strWriteLine &= "," & Chr(34) & dt.Rows(iRow)("メール登録数") & Chr(34)
					strWriteLine &= "," & Chr(34) & dt.Rows(iRow)("TEL登録数") & Chr(34)
					strWriteLine &= "," & Chr(34) & dt.Rows(iRow)("災害変更通知") & Chr(34)
					strWriteLine &= "," & Chr(34) & dt.Rows(iRow)("アクセス制御権限") & Chr(34)
					strWriteLine &= "," & Chr(34) & dt.Rows(iRow)("機能制限") & Chr(34)
					strWriteLine &= "," & Chr(34) & dt.Rows(iRow)("所属部署1") & Chr(34)
					strWriteLine &= "," & Chr(34) & dt.Rows(iRow)("所属部署2") & Chr(34)
					strWriteLine &= "," & Chr(34) & dt.Rows(iRow)("所属部署3") & Chr(34)
					strWriteLine &= "," & Chr(34) & dt.Rows(iRow)("所属部署4") & Chr(34)
					strWriteLine &= "," & Chr(34) & dt.Rows(iRow)("所属部署5") & Chr(34)
					sw.WriteLine(strWriteLine)
				Next

			End Using

			'納品日時を更新
			strSQL = "UPDATE T_ロット管理 SET 納品日時 = '" & Date.Now.ToString("yyyy/MM/dd HH:mm:ss") & "' "
			strSQL &= "WHERE ロットID = '" & strLotID & "'"
			sqlProcess.DB_UPDATE(strSQL)

			WriteLstResult(Me.lstResult, "管理者情報の抽出完了：" & iRecCount & "レコード")
			WriteLstResult(Me.lstResult, "データ抽出処理完了")

			OutputListLog(Me.lstResult, strLogFolder, "データ抽出", Me.txtOffice.Text, Me.txtLotID.Text)

			If MessageBox.Show("不要なデータを削除しますか？" & vbNewLine & "※利用者情報を削除するため抽出データは再出力できなくなります", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
				'不要なデータを削除
				strSQL = "DELETE FROM T_利用者情報 "
				strSQL &= "WHERE ロットID = '" & strLotID & "'"
				sqlProcess.DB_UPDATE(strSQL)
				strSQL = "DELETE FROM T_管理者情報抽出 "
				strSQL &= "WHERE ロットID = '" & strLotID & "'"
				sqlProcess.DB_UPDATE(strSQL)
				strSQL = "DELETE FROM T_利用者情報抽出 "
				strSQL &= "WHERE ロットID = '" & strLotID & "'"
				sqlProcess.DB_UPDATE(strSQL)
			End If

			MessageBox.Show("データ抽出処理が完了しました", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information)

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
		'Me.txtImportExcel.Text = XmlSettings.Instance.ImportExcelFile
		Me.txtOutputFolder.Text = XmlSettings.Instance.OutputFolder
		Me.txtLogFolder.Text = XmlSettings.Instance.ImportLogFolder

	End Sub

#End Region
End Class