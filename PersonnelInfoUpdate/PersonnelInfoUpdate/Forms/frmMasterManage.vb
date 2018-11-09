Public Class frmMasterManage

#Region "フォームイベント"

	''' <summary>
	''' フォームロード時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load

		Me.Text = My.Application.Info.ProductName & " Ver." &
			My.Application.Info.Version.ToString & " - [マスタ管理画面]"

		'キー入力を受け付ける
		Me.KeyPreview = True
		CaptionDisplayMode = StatusDisplayMode.TitleOnly

		Initialize()

	End Sub

#End Region

#Region "オブジェクトイベント"

	''' <summary>
	''' 戻るボタン押下時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click

		If MessageBox.Show("メインメニューへ戻ります" & vbNewLine & "よろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
			Dim frmNextForm As New frmMainMenu
			m_Context.SetNextContext(frmNextForm)
		End If

	End Sub

	''' <summary>
	''' テキストボックスドラッグエンター時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub TextBox_DragEnter(sender As Object, e As DragEventArgs) Handles txtOrg.DragEnter, txtPost.DragEnter

		If e.Data.GetDataPresent(DataFormats.FileDrop) Then
			e.Effect = DragDropEffects.Copy
		Else
			e.Effect = DragDropEffects.None
		End If

	End Sub


	''' <summary>
	''' インポート組織情報ドラッグドロップ時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub txtOrg_DragDrop(sender As Object, e As DragEventArgs) Handles txtOrg.DragDrop

		Dim strFiles As String() = CType(e.Data.GetData(DataFormats.FileDrop, False), String())

		If System.IO.File.Exists(strFiles(0)) And System.IO.Path.GetExtension(strFiles(0)) = ".csv" Then
			Me.txtOrg.Text = strFiles(0)
		End If

	End Sub

	''' <summary>
	''' インポート役職情報ドラッグドロップ時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub txtPost_DragDrop(sender As Object, e As DragEventArgs) Handles txtPost.DragDrop

		Dim strFiles As String() = CType(e.Data.GetData(DataFormats.FileDrop, False), String())

		If System.IO.File.Exists(strFiles(0)) And System.IO.Path.GetExtension(strFiles(0)) = ".csv" Then
			Me.txtPost.Text = strFiles(0)
		End If

	End Sub

	''' <summary>
	''' インポート組織情報ブラウズボタン押下時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub btnOrgBrowse_Click(sender As Object, e As EventArgs) Handles btnOrgBrowse.Click

		Dim strFilter As String = "CSVファイル(*.csv)|*.csv"
		Me.txtOrg.Text = FileBrowse(Me.txtOrg, strFilter)

	End Sub

	''' <summary>
	''' インポート利用者情報ブラウズボタン押下時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub btnPostBrowse_Click(sender As Object, e As EventArgs) Handles btnPostBrowse.Click

		Dim strFilter As String = "CSVファイル(*.csv)|*.csv"
		Me.txtPost.Text = FileBrowse(Me.txtPost, strFilter)

	End Sub

	''' <summary>
	''' 組織情報インポートボタン押下時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub btnOrgImport_Click(sender As Object, e As EventArgs) Handles btnOrgImport.Click

		If Not System.IO.File.Exists(Me.txtOrg.Text) Then
			MessageBox.Show("組織情報CSVが指定されていません", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Exit Sub
		End If

		If MessageBox.Show("組織情報を一度削除して、組織情報CSVをインポートします" & vbNewLine & "よろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
			Exit Sub
		End If

		Dim strSQL As String = ""
		Dim sqlProcess As New SQLProcess

		Try
			Dim iRecCount As Integer = 0
			'M_組織情報の削除
			strSQL &= "DELETE FROM M_組織情報"
			sqlProcess.DB_UPDATE(strSQL)

			Using parser As New CSVParser(Me.txtOrg.Text, System.Text.Encoding.GetEncoding("Shift-JIS"))
				parser.Delimiter = ","  'カンマ区切り

				parser.HasFieldsEnclosedInQuotes = True 'データ内にデリミタがあっても区切らない
				parser.TrimWhiteSpace = False   '空白を削除しない

				iRecCount = 0

				parser.ReadFields() 'ヘッダ行を読み飛ばす
				'最終行まで読み込み
				While Not parser.EndOfData
					iRecCount += 1
					Dim row As String() = parser.ReadFields()   '1行読み込み、項目を配列に代入
					'M_組織情報に書き込み
					strSQL = "INSERT INTO M_組織情報 (組織コード, 第1階層組織コード, 第2階層組織コード, 第3階層組織コード, "
					strSQL &= "組織名称, 都道府県コード, 現地状況報告対象フラグ) VALUES("
					strSQL &= "'" & row(1).Trim(" ").Trim("　") & "'"    '組織コード
					strSQL &= ", '" & row(2).Trim(" ").Trim("　") & "'"  '第1階層組織コード
					strSQL &= ", '" & row(3).Trim(" ").Trim("　") & "'"  '第2階層組織コード
					strSQL &= ", '" & row(4).Trim(" ").Trim("　") & "'"  '第3階層組織コード
					strSQL &= ", '" & row(5).Trim(" ").Trim("　") & "'"  '組織名称
					strSQL &= ", '" & row(6).Trim(" ").Trim("　") & "'"  '都道府県コード
					strSQL &= ", '" & row(7).Trim(" ").Trim("　") & "')"  '現地状況報告対象フラグ
					sqlProcess.DB_UPDATE(strSQL)
				End While
			End Using

			SearchGridOrg()
			MessageBox.Show("組織情報のインポートが完了しました" & vbNewLine & iRecCount & "レコード", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information)

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & ex.StackTrace)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		Finally

			sqlProcess.Close()

		End Try

	End Sub

	''' <summary>
	''' 役職情報インポートボタン押下時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub btnPostImport_Click(sender As Object, e As EventArgs) Handles btnPostImport.Click

		If Not System.IO.File.Exists(Me.txtPost.Text) Then
			MessageBox.Show("役職情報CSVが指定されていません", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Exit Sub
		End If

		If MessageBox.Show("役職情報を一度削除して、役職情報CSVをインポートします" & vbNewLine & "よろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
			Exit Sub
		End If

		Dim strSQL As String = ""
		Dim sqlProcess As New SQLProcess

		Try
			Dim iRecCount As Integer = 0
			'M_役職の削除
			strSQL = "DELETE FROM M_役職"
			sqlProcess.DB_UPDATE(strSQL)

			Using parser As New CSVParser(Me.txtPost.Text, System.Text.Encoding.GetEncoding("Shift-JIS"))
				parser.Delimiter = ","  'カンマ区切り

				parser.HasFieldsEnclosedInQuotes = True 'データ内にデリミタがあっても区切らない
				parser.TrimWhiteSpace = False   '空白を削除しない

				iRecCount = 0

				parser.ReadFields() 'ヘッダ行を読み飛ばす
				'最終行まで読み込み
				While Not parser.EndOfData
					iRecCount += 1
					Dim row As String() = parser.ReadFields()   '1行読み込み、項目を配列に代入
					'M_役職に書き込み
					strSQL = "INSERT INTO M_役職 (役職コード, 役職名称) VALUES("
					strSQL &= "'" & row(1).Trim(" ", "").Trim("　", "") & "'"    '役職コード
					strSQL &= ", '" & row(2).Trim(" ", "").Trim("　", "") & "')" '役職名称
					sqlProcess.DB_UPDATE(strSQL)
				End While
			End Using

			SearchGridPost()
			MessageBox.Show("役職情報のインポートが完了しました" & vbNewLine & iRecCount & "レコード", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information)

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & ex.StackTrace)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		Finally

			sqlProcess.Close()

		End Try

	End Sub

	''' <summary>
	''' 事業所グリッドクリック時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub C1FGridOffice_Click(sender As Object, e As EventArgs) Handles C1FGridOffice.Click

		Dim iIndex As Integer = Me.C1FGridOffice.Row
		If iIndex >= 1 Then
			Me.txtOfficeID.Text = Me.C1FGridOffice(iIndex, "事業所ID")
			Me.txtOffice.Text = Me.C1FGridOffice(iIndex, "事業所")
		End If

	End Sub

	''' <summary>
	''' 更新ボタン押下時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click

		If IsNull(Me.txtOfficeID.Text) Or IsNull(Me.txtOffice.Text) Then
			MessageBox.Show("事業所が指定されていません", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Exit Sub
		End If
		If MessageBox.Show("選択された事業所の名称を変更します" & vbNewLine & "よろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
			Exit Sub
		End If

		Dim strSQL As String = ""
		Dim sqlProcess As New SQLProcess

		Try
			strSQL = "UPDATE M_事業所 SET 事業所 = '" & Me.txtOffice.Text & "' "
			strSQL &= "WHERE 事業所ID = " & Me.txtOfficeID.Text
			sqlProcess.DB_UPDATE(strSQL)

			SearchOffice()

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & ex.StackTrace)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		Finally

			sqlProcess.Close()

		End Try

	End Sub

	''' <summary>
	''' 削除ボタン押下時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click

		If IsNull(Me.txtOffice.Text) Then
			MessageBox.Show("事業所が指定されていません", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Exit Sub
		End If
		If MessageBox.Show("選択された事業所を削除します" & vbNewLine & "よろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
			Exit Sub
		End If

		Dim strSQL As String = ""
		Dim sqlProcess As New SQLProcess

		Try
			strSQL = "DELETE FROM M_事業所 "
			strSQL &= "WHERE 事業所ID = " & Me.txtOfficeID.Text
			sqlProcess.DB_UPDATE(strSQL)

			SearchOffice()

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & ex.StackTrace)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		Finally

			sqlProcess.Close()

		End Try

	End Sub

	''' <summary>
	''' 新規登録ボタン押下時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click

		If IsNull(Me.txtOffice.Text) Then
			MessageBox.Show("事業所が指定されていません", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Exit Sub
		End If

		Dim strSQL As String = ""
		Dim sqlProcess As New SQLProcess

		Try
			strSQL = "SELECT COUNT(*) FROM M_事業所 "
			strSQL &= "WHERE 事業所 = '" & Me.txtOffice.Text & "'"
			If sqlProcess.DB_EXECUTE_SCALAR(strSQL) > 0 Then
				MessageBox.Show("既に登録されている事業所です", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
				Exit Sub
			End If
			If MessageBox.Show("入力された事業所を登録します" & vbNewLine & "よろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
				Exit Sub
			End If
			strSQL = "SELECT ISNULL(MAX(事業所ID), 0) + 1 FROM M_事業所"
			Dim iRecNumber As Integer = sqlProcess.DB_EXECUTE_SCALAR(strSQL)

			strSQL = "INSERT INTO M_事業所(事業所ID, 事業所) VALUES("
			strSQL &= iRecNumber
			strSQL &= ", '" & Me.txtOffice.Text & "')"
			sqlProcess.DB_UPDATE(strSQL)

			SearchOffice()

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & ex.StackTrace)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

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

		SearchGridOrg()
		SearchGridPost()
		SearchOffice()

		Me.C1DockingTab1.SelectedIndex = 0

	End Sub

	''' <summary>
	''' 組織情報をグリッドにセットする
	''' </summary>
	Private Sub SearchGridOrg()

		Dim strSQL As String = ""
		Dim sqlProcess As New SQLProcess

		Try
			strSQL = "SELECT 組織コード, 第1階層組織コード, 第2階層組織コード, 第3階層組織コード, 組織名称, 都道府県コード, "
			strSQL &= "現地状況報告対象フラグ AS フラグ "
			strSQL &= "FROM M_組織情報 "
			strSQL &= "ORDER BY 組織コード"
			Dim dt As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
			Dim iRecCount As Integer = 0

			For iRow As Integer = 0 To dt.Rows.Count - 1
				iRecCount += 1
				Me.C1FGridOrg.Rows.Count = iRecCount + 1
				Me.C1FGridOrg(iRecCount, "No") = iRecCount
				Me.C1FGridOrg(iRecCount, "組織コード") = dt.Rows(iRow)("組織コード")
				Me.C1FGridOrg(iRecCount, "第1階層組織コード") = dt.Rows(iRow)("第1階層組織コード")
				Me.C1FGridOrg(iRecCount, "第2階層組織コード") = dt.Rows(iRow)("第2階層組織コード")
				Me.C1FGridOrg(iRecCount, "第3階層組織コード") = dt.Rows(iRow)("第3階層組織コード")
				Me.C1FGridOrg(iRecCount, "組織名称") = dt.Rows(iRow)("組織名称")
				Me.C1FGridOrg(iRecCount, "都道府県コード") = dt.Rows(iRow)("都道府県コード")
				Me.C1FGridOrg(iRecCount, "フラグ") = dt.Rows(iRow)("フラグ")
			Next

			Me.C1FGridOrg.Row = -1

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & ex.StackTrace)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		Finally

			sqlProcess.Close()

		End Try

	End Sub

	''' <summary>
	''' 役職情報をグリッドにセットする
	''' </summary>
	Private Sub SearchGridPost()

		Dim strSQL As String = ""
		Dim sqlProcess As New SQLProcess

		Try
			strSQL = "SELECT 役職コード, 役職名称 "
			strSQL &= "FROM M_役職 "
			strSQL &= "ORDER BY 役職コード"
			Dim dt As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
			Dim iRecCount As Integer = 0

			For iRow As Integer = 0 To dt.Rows.Count - 1
				iRecCount += 1
				Me.C1FGridPost.Rows.Count = iRecCount + 1
				Me.C1FGridPost(iRecCount, "No") = iRecCount
				Me.C1FGridPost(iRecCount, "役職コード") = dt.Rows(iRow)("役職コード")
				Me.C1FGridPost(iRecCount, "役職名称") = dt.Rows(iRow)("役職名称")
			Next

			Me.C1FGridPost.Row = -1

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & ex.StackTrace)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		Finally

			sqlProcess.Close()

		End Try

	End Sub

	''' <summary>
	''' 事業所一覧をグリッドにセットする
	''' </summary>
	Private Sub SearchOffice()

		Dim strSQL As String = ""
		Dim sqlProcess As New SQLProcess

		Try
			strSQL = "SELECT 事業所ID, 事業所 FROM M_事業所 "
			strSQL &= "ORDER BY 事業所ID"
			Dim dt As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
			Dim iRecCount As Integer = 0

			For iRow As Integer = 0 To dt.Rows.Count - 1
				iRecCount += 1
				Me.C1FGridOffice.Rows.Count = iRecCount + 1
				Me.C1FGridOffice(iRecCount, "No") = iRecCount
				Me.C1FGridOffice(iRecCount, "事業所ID") = dt.Rows(iRow)("事業所ID")
				Me.C1FGridOffice(iRecCount, "事業所") = dt.Rows(iRow)("事業所")
			Next

			Me.C1FGridOffice.Row = -1
			Me.txtOfficeID.Text = ""
			Me.txtOffice.Text = ""

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & ex.StackTrace)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		Finally

			sqlProcess.Close()

		End Try

	End Sub

#End Region

End Class