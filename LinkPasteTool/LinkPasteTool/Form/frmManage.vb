Imports Microsoft.VisualBasic.FileIO
Imports System.Text
Imports C1.Win.C1FlexGrid
Imports C1.C1Excel

Public Class frmManage

#Region "プライベート変数"

	''' <summary>
	''' スタイル列挙体
	''' </summary>
	''' <remarks></remarks>
	Friend Enum GridStyleName
		StyleDefault
		StyleFinish
		StyleCheck
	End Enum

#End Region

#Region "フォームイベント"

	''' <summary>
	''' フォームロード時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub frmManage_Load(sender As Object, e As EventArgs) Handles MyBase.Load

		Me.Text = My.Application.Info.ProductName.ToString & " Ver." &
			My.Application.Info.Version.ToString
		Me.KeyPreview = True

		Initialize()

	End Sub

#End Region

#Region "オブジェクトイベント"

	Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click

		If MessageBox.Show("アプリケーションを終了します" & vbNewLine & "よろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
			Exit Sub
		End If

		Dim strSQL As String = ""
		Dim sqlProcess As New SQLProcess

		Try
			strSQL = "UPDATE M_ユーザー SET ログインフラグ = 0 "
			strSQL &= "WHERE ユーザーID = " & m_LoginUser.UserID
			sqlProcess.DB_UPDATE(strSQL)

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		Finally

			sqlProcess.Close()

		End Try

		XmlSettings.LoadFromXmlFile()
		If Me.WindowState = FormWindowState.Normal Then
			'ウィンドウ状態：通常
			XmlSettings.Instance.LocManageX = Me.Left
			XmlSettings.Instance.LocManageY = Me.Top
			XmlSettings.Instance.SizeManageX = Me.Width
			XmlSettings.Instance.SizeManageY = Me.Height
		Else
			'ウィンドウ状態：最大化または最小化
			XmlSettings.Instance.LocManageX = Me.RestoreBounds.Left
			XmlSettings.Instance.LocManageY = Me.RestoreBounds.Top
			XmlSettings.Instance.SizeManageX = Me.RestoreBounds.Width
			XmlSettings.Instance.SizeManageY = Me.RestoreBounds.Height
		End If
		XmlSettings.Instance.StateManage = Me.WindowState
		XmlSettings.Instance.OutputFolder = Me.txtOutputFolder.Text

		XmlSettings.SaveToXmlFile()

		Application.Exit()

		'm_LoginUser.BackFormID = "frmManage"
		'Dim frm As New frmMain
		'm_Context.SetNextContext(frm)

	End Sub

#End Region

#Region "オブジェクトイベント(目次データ)"

	''' <summary>
	''' ブラウズボタン押下時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub btnContentsBrowse_Click(sender As Object, e As EventArgs) Handles btnContentsBrowse.Click

		Me.txtContentsFile.Text = FileBrowse(Me.txtContentsFile, "CSVファイル(*.csv)|*.csv")

	End Sub


	''' <summary>
	''' 目次データ検索ボタン押下時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub btnContentsSearch_Click(sender As Object, e As EventArgs) Handles btnContentsSearch.Click

		ContentsSearch()

	End Sub

	''' <summary>
	''' 目次インポートボタン押下時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub btnContentsImport_Click(sender As Object, e As EventArgs) Handles btnContentsImport.Click

		If Not System.IO.File.Exists(Me.txtContentsFile.Text) Then
			MessageBox.Show("目次データのCSVファイルを指定してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Exit Sub
		End If

		If MessageBox.Show("指定された目次データCSVファイルをインポートします" & vbNewLine & "既にインポートされているデータは新たなデータに上書きされます" & vbNewLine & "よろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
			Exit Sub
		End If

		EnableControls(Me, False)

		Dim strCSVFile As String = Me.txtContentsFile.Text
		Dim iRecordCount As Integer = 0
		Dim iInsert As Integer = 0  '新規レコード
		Dim iUpdate As Integer = 0  '更新レコード

		Using parser As New TextFieldParser(strCSVFile, Encoding.GetEncoding("Shift-JIS"))

			parser.TextFieldType = FieldType.Delimited
			parser.SetDelimiters(","c) '区切り文字はカンマ

			parser.HasFieldsEnclosedInQuotes = True 'データ内にデリミタがあっても区切らない
			parser.TrimWhiteSpace = False   '空白文字を削除しない

			Dim strSQL As String = ""
			Dim sqlProcess As New SQLProcess
			Dim dt As DataTable = Nothing

			Try
				'T_目次インポート内のレコードを削除
				strSQL = "DELETE FROM T_目次インポート"
				sqlProcess.DB_UPDATE(strSQL)

				While Not parser.EndOfData
					Application.DoEvents()
					iRecordCount += 1

					Dim row As String() = parser.ReadFields()   '1行読み込み、項目を配列に代入

					'フィールドが26未満の場合はエラーとする
					If row.Length < 26 Then
						MessageBox.Show("インポートする項目が足りません" & vbNewLine & "CSVファイルを確認してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
						Exit Sub
					End If

					If iRecordCount = 1 Then
						'ヘッダを読み飛ばす
						Continue While
					End If

					'管理IDの取得
					strSQL = "SELECT 管理ID FROM M_管理表 "
					strSQL &= "WHERE 納品フォルダ = '" & Microsoft.VisualBasic.Strings.Left(row(0), 8) & "'"
					dt = sqlProcess.DB_SELECT_DATATABLE(strSQL)
					If dt.Rows.Count = 0 Then
						MessageBox.Show("納品フォルダが管理表に存在しませんでした" & vbNewLine & "納品フォルダ：" & Microsoft.VisualBasic.Strings.Left(row(0), 8), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
						Exit Sub
					End If
					Dim iManageID As Integer = dt.Rows(0)("管理ID")

					'該当納品フォルダの連番を取得
					strSQL = "SELECT ISNULL(MAX(連番), 0) + 1 FROM T_目次インポート "
					strSQL &= "WHERE 管理ID = " & iManageID
					Dim iSerial As Integer = CInt(sqlProcess.DB_EXECUTE_SCALAR(strSQL))

					'納品フォルダを付加してT_目次インポートにINSERT
					strSQL = "INSERT INTO T_目次インポート (管理ID, 連番, レコード番号, 表示用, 行番号, 県名, 資料名, "
					strSQL &= "副題, 対象年, 刊行者名, 刊行年月, 分類1, 分類2, 分類番号, 項目, 番号1, タイトル1, 番号2, タイトル2, "
					strSQL &= "番号3, タイトル3, 番号4, タイトル4, 番号5, タイトル5) VALUES("
					strSQL &= iManageID    '管理ID
					strSQL &= ", " & iSerial    '連番
					strSQL &= ", N'" & row(0) & "'" 'レコード番号
					strSQL &= ", N'" & row(1) & "'" '表示用
					strSQL &= ", " & row(2) '行番号
					strSQL &= ", N'" & row(3) & "'" '県名
					strSQL &= ", N'" & row(4) & "'" '資料名
					strSQL &= ", N'" & row(5) & "'" '副題
					strSQL &= ", N'" & row(6) & "'" '対象年
					strSQL &= ", N'" & row(7) & "'" '刊行者名
					strSQL &= ", N'" & row(8) & "'" '刊行年月
					strSQL &= ", N'" & row(9) & "'" '分類1
					strSQL &= ", N'" & row(10) & "'"    '分類2
					strSQL &= ", N'" & row(11) & "'"    '分類番号
					strSQL &= ", N'" & row(12) & "'"    '項目
					strSQL &= ", N'" & row(13) & "'"    '番号1
					strSQL &= ", N'" & row(14) & "'"    'タイトル1
					strSQL &= ", N'" & row(15) & "'"    '番号2
					strSQL &= ", N'" & row(16) & "'"    'タイトル2
					strSQL &= ", N'" & row(17) & "'"    '番号3
					strSQL &= ", N'" & row(18) & "'"    'タイトル3
					strSQL &= ", N'" & row(19) & "'"    '番号4
					strSQL &= ", N'" & row(20) & "'"    'タイトル4
					strSQL &= ", N'" & row(21) & "'"    '番号5
					strSQL &= ", N'" & row(22) & "')"    'タイトル5
					sqlProcess.DB_UPDATE(strSQL)

				End While

				'T_目次インポートより納品フォルダをグルーピングして該当する納品フォルダをT_目次から削除する
				strSQL = "SELECT 管理ID FROM T_目次インポート "
				strSQL &= "GROUP BY 管理ID "
				strSQL &= "ORDER BY 管理ID"
				dt = sqlProcess.DB_SELECT_DATATABLE(strSQL)

				For iRow As Integer = 0 To dt.Rows.Count - 1
					'該当管理IDの削除
					strSQL = "DELETE FROM T_目次 "
					strSQL &= "WHERE 管理ID = " & dt.Rows(iRow)("管理ID")
					sqlProcess.DB_UPDATE(strSQL)
					'T_フラグから該当管理IDのレコードを削除
					strSQL = "DELETE FROM T_フラグ "
					strSQL &= "WHERE 管理ID = " & dt.Rows(iRow)("管理ID")
					sqlProcess.DB_UPDATE(strSQL)
					'該当管理IDのデータをT_目次インポートからT_目次にINSERTする
					strSQL = "INSERT INTO T_目次 "
					strSQL &= "SELECT 管理ID, 連番, レコード番号, 表示用, 行番号, 県名, 資料名, 副題, 対象年, 刊行者名, 刊行年月, "
					strSQL &= "分類1, 分類2, 分類番号, 項目, 番号1, タイトル1, 番号2, タイトル2, 番号3, タイトル3, 番号4, タイトル4, 番号5, タイトル5, "
					strSQL &= "N'' AS フォルダ名, N'' AS リンク, N'' AS リンクTO, N'' AS 備考, 0 AS フラグID "
					strSQL &= "FROM T_目次インポート "
					strSQL &= "WHERE 管理ID = " & dt.Rows(iRow)("管理ID")
					sqlProcess.DB_UPDATE(strSQL)
					'M_管理表のステータスを削除する
					strSQL = "UPDATE M_管理表 SET 処理端末 = N'', 開始日時 = NULL, 終了日時 = NULL, 終了日時2次 = NULL, 処理ユーザー = N'' "
					strSQL &= "WHERE 管理ID = " & dt.Rows(iRow)("管理ID")
					sqlProcess.DB_UPDATE(strSQL)
				Next

				MessageBox.Show("目次データのインポート処理が完了しました", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information)

			Catch ex As Exception

				Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message)
				MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

			Finally

				sqlProcess.Close()
				EnableControls(Me, True)

			End Try

		End Using

	End Sub

	''' <summary>
	''' グリッドマウンスダウン前
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub C1FGridContents_BeforeMouseDown(sender As Object, e As BeforeMouseDownEventArgs) Handles C1FGridContents.BeforeMouseDown

		If e.Button = MouseButtons.Left And e.Clicks > 1 Then
			'左ダブルクリックされたとき
			Dim hti As C1.Win.C1FlexGrid.HitTestInfo = Me.C1FGridContents.HitTest(e.X, e.Y)

			If hti.Row < Me.C1FGridContents.Cols.Fixed Then
				'ヘッダがダブルクリックされた
				'何もしない
			ElseIf hti.Column = 3 Then
				'仮フォルダ項目がダブルクリックされた
				'現在のレコードを記憶する
				Dim iIndex As Integer = Me.C1FGridContents.Row

				'他端末で使用中か調べる
				Dim strSQL As String = ""
				Dim sqlProcess As New SQLProcess

				Try
					strSQL = "SELECT 処理端末 FROM M_管理表 "
					strSQL &= "WHERE 管理ID = " & Me.C1FGridContents(iIndex, "管理ID")
					Dim strProcessPC As String = sqlProcess.DB_EXECUTE_SCALAR(strSQL)
					If Not IsNull(strProcessPC) And Not strProcessPC = My.Computer.Name Then
						'端末名がNULLでない、もしくは端末名が自身の端末でなかった場合警告を表示する
						If MessageBox.Show("該当フォルダは他の端末で処理中です。" & vbNewLine & "処理端末：" & strProcessPC & vbNewLine & "続行しますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
							Exit Sub
						End If
					End If

					Dim frm As New frmMain
					frm.IsAdmin = True
					frm.ManageID = Me.C1FGridContents(hti.Row, "管理ID")
					Me.Visible = False
					frm.ShowDialog(Me)

					'ウィンドウ復帰後の動作
					ContentsSearch()
					'フォーカス行の復帰
					If Me.C1FGridContents.Rows.Count < iIndex Then
						Me.C1FGridContents.Row = Me.C1FGridContents.Rows.Count - 1
					Else
						Me.C1FGridContents.Row = iIndex
					End If

				Catch ex As Exception

					Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message)
					MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

				Finally

					sqlProcess.Close()

				End Try

			End If
		End If

	End Sub

	'''' <summary>
	'''' グリッドセル内マウスエンター時
	'''' </summary>
	'''' <param name="sender"></param>
	'''' <param name="e"></param>
	'Private Sub C1FGridContents_MouseEnterCell(sender As Object, e As RowColEventArgs) Handles C1FGridContents.MouseEnterCell
	'	'セル内にマウスポインタが入ればスタイルを設定
	'	Me.C1FGridContents.SetCellStyle(e.Row, e.Col, Me.C1FGridContents.Styles("track"))

	'End Sub

	'''' <summary>
	'''' グリッドセル内マウスリーブ時
	'''' </summary>
	'''' <param name="sender"></param>
	'''' <param name="e"></param>
	'Private Sub C1FGridContents_MouseLeaveCell(sender As Object, e As RowColEventArgs) Handles C1FGridContents.MouseLeaveCell
	'	'セルからでた際にスタイルを削除
	'	Me.C1FGridContents.SetCellStyle(e.Row, e.Col, CType(Nothing, C1.Win.C1FlexGrid.CellStyle))
	'End Sub

	''' <summary>
	''' セル単位の編集データ検証時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub C1FGridContents_ValidateEdit(sender As Object, e As ValidateEditEventArgs) Handles C1FGridContents.ValidateEdit

		If Me.C1FGridContents.Cols(e.Col).Name = "確認" Then
			'値を変更したのが確認項目だった
			If Me.C1FGridContents(e.Row, "フラグID") = 0 And IsNull(Me.C1FGridContents(e.Row, "変更")) = True Then
				'フラグIDが0で変更フラグも立っていなかったらキャンセル
				e.Cancel = True
				Exit Sub
			End If

		End If

		If Me.C1FGridContents.Editor Is Nothing Then
			'セルエディターがNULLの場合は文字列貼り付けなので無条件に背景色を変える
			LinkPasteProcess.ChangeCellBackColor(Me.C1FGridContents, e.Row, e.Col, LinkPasteProcess.GridStyleName.StyleUpdate)
		Else
			'編集中のデータとセル内のデータが相違していたらセルの背景色を変更する
			If Me.C1FGridContents.Editor.Text <> Me.C1FGridContents(e.Row, e.Col) Then
				LinkPasteProcess.ChangeCellBackColor(Me.C1FGridContents, e.Row, e.Col, LinkPasteProcess.GridStyleName.StyleUpdate)
			End If
		End If
	End Sub

	''' <summary>
	''' 更新ボタン押下時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub btnContentsUpdate_Click(sender As Object, e As EventArgs) Handles btnContentsUpdate.Click

		If MessageBox.Show("値が変更された箇所を更新します" & vbNewLine & "よろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
			Exit Sub
		End If

		Dim strSQL As String = ""
		Dim sqlProcess As New SQLProcess

		Try
			For iRow As Integer = 1 To Me.C1FGridContents.Rows.Count - 1
				'検索結果の全レコードに対して、所定の全項目を更新する
				strSQL = "UPDATE T_目次 SET "
				strSQL &= "表示用 = N'" & Me.C1FGridContents(iRow, "表示用") & "'"
				strSQL &= ", 行番号 = " & IIf(IsNull(Me.C1FGridContents(iRow, "行番号")), 0, Me.C1FGridContents(iRow, "行番号"))
				strSQL &= ", 県名 = N'" & Me.C1FGridContents(iRow, "県名") & "'"
				strSQL &= ", 資料名 = N'" & Me.C1FGridContents(iRow, "資料名") & "'"
				strSQL &= ", 副題 = N'" & Me.C1FGridContents(iRow, "副題") & "'"
				strSQL &= ", 対象年 = N'" & Me.C1FGridContents(iRow, "対象年") & "'"
				strSQL &= ", 刊行者名 = N'" & Me.C1FGridContents(iRow, "刊行者名") & "'"
				strSQL &= ", 刊行年月 = N'" & Me.C1FGridContents(iRow, "刊行年月") & "'"
				strSQL &= ", 分類1 = N'" & Me.C1FGridContents(iRow, "分類1") & "'"
				strSQL &= ", 分類2 = N'" & Me.C1FGridContents(iRow, "分類2") & "'"
				strSQL &= ", 分類番号 = N'" & Me.C1FGridContents(iRow, "分類番号") & "' "
				strSQL &= "WHERE 管理ID = " & Me.C1FGridContents(iRow, "管理ID") & " "
				strSQL &= "AND 連番 = " & Me.C1FGridContents(iRow, "連番")
				sqlProcess.DB_UPDATE(strSQL)
				'管理者確認フラグの更新
				If Me.C1FGridContents(iRow, "確認") = True Then
					'確認フラグが立っている
					'目次関連のフラグに全て管理者確認フラグを立てる
					strSQL = "UPDATE T_フラグ SET "
					strSQL &= "管理者確認 = 1 "
					strSQL &= "WHERE 管理ID = " & Me.C1FGridContents(iRow, "管理ID") & " "
					strSQL &= "AND 連番 = " & Me.C1FGridContents(iRow, "連番") & " "
					strSQL &= "AND 種別ID = 20"
					sqlProcess.DB_UPDATE(strSQL)
					'変更フラグが立っていた場合の更新
					If Me.C1FGridContents(iRow, "変更") = "変更あり" Then
						'変更フラグに管理者確認フラグを立てる
						strSQL = "UPDATE T_フラグ SET "
						strSQL &= "管理者確認 = 1 "
						strSQL &= "WHERE 管理ID = " & Me.C1FGridContents(iRow, "管理ID") & " "
						strSQL &= "AND 連番 = " & Me.C1FGridContents(iRow, "連番") & " "
						strSQL &= "AND 種別ID = 40"
						sqlProcess.DB_UPDATE(strSQL)
					End If
				End If
			Next

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		Finally

			sqlProcess.Close()

		End Try

	End Sub

	''' <summary>
	''' CSV出力ボタン押下時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub btnContentsCSVOutput_Click(sender As Object, e As EventArgs) Handles btnContentsCSVOutput.Click

		OutputCSVFile(Me.C1FGridContents, "")

	End Sub

#End Region

#Region "オブジェクトイベント(管理表)"

	''' <summary>
	''' ブラウズボタン押下時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub btnManageBrowse_Click(sender As Object, e As EventArgs) Handles btnManageBrowse.Click

		Me.txtManageFile.Text = FileBrowse(Me.txtManageFile, "CSVファイル(*.csv)|*.csv")

	End Sub

	''' <summary>
	''' 管理表検索ボタン押下時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub btnManageSearch_Click(sender As Object, e As EventArgs) Handles btnManageSearch.Click

		'納品フォルダチェック
		If Me.cmbManageDelivFolderName.SelectedIndex < 0 Then
			MessageBox.Show("該当する納品フォルダがリストに存在しません", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Exit Sub
		End If
		'仮フォルダチェック
		If Me.cmbManageProvFolderName.SelectedIndex < 0 Then
			MessageBox.Show("該当する仮フォルダがリストに存在しません", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Exit Sub
		End If

		Dim strSQL As String = ""
		Dim sqlProcess As New SQLProcess
		Dim strWhere As String = " WHERE "

		Try
			strSQL = "SELECT 管理ID, M番号, 県名, 仮フォルダ, 納品フォルダ, エクセルファイル名, スキャン, レコード, ISNULL(備考, '') AS 備考, "
			strSQL &= "ISNULL(処理端末, '') AS 処理端末, ISNULL(開始日時, '') AS 開始日時, ISNULL(終了日時, '') AS 終了日時, ISNULL(終了日時2次, '') AS 終了日時2次, 処理ユーザー "
			strSQL &= "FROM M_管理表 "

			'M番号 
			If Me.cmbManageMNo.SelectedIndex > 0 Then
				strSQL &= strWhere & "M番号 = '" & Me.cmbManageMNo.SelectedValue & "' "
				strWhere = " AND "
			End If
			'県名
			If Me.cmbManagePrefecture.SelectedIndex > 0 Then
				strSQL &= strWhere & "県名 LIKE '%" & Me.cmbManagePrefecture.SelectedValue & "%' "
				strWhere = " AND "
			End If
			'仮フォルダ
			If Me.cmbManageProvFolderName.SelectedIndex > 0 Or IsNull(Me.cmbContentsProvFolderName.SelectedValue) Then
				strSQL &= strWhere & "仮フォルダ LIKE '%" & Me.cmbManageProvFolderName.SelectedValue & "%' "
				strWhere = " AND "
			End If
			'納品フォルダ
			If Me.cmbManageDelivFolderName.SelectedIndex > 0 Or IsNull(Me.cmbContentsProvFolderName.SelectedValue) Then
				strSQL &= strWhere & "納品フォルダ LIKE '%" & Me.cmbManageDelivFolderName.SelectedValue & "%' "
				strWhere = " AND "
			End If
			'エクセルファイル名
			If Not IsNull(Me.txtManageExcelName.Text) Then
				strSQL &= strWhere & "エクセルファイル名 LIKE '%" & Me.txtManageExcelName.Text & "%' "
				strWhere = " AND "
			End If
			strSQL &= "ORDER BY 管理ID"
			Dim dt As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)

			Dim iRecordCount As Integer = 0

			Me.C1FGridManage.BeginUpdate()
			Me.C1FGridManage.Rows.Count = dt.Rows.Count + 1

			For iRow As Integer = 0 To dt.Rows.Count - 1
				iRecordCount += 1
				Me.C1FGridManage(iRecordCount, "No") = iRecordCount
				Me.C1FGridManage(iRecordCount, "管理ID") = dt.Rows(iRow)("管理ID")
				Me.C1FGridManage(iRecordCount, "M番号") = dt.Rows(iRow)("M番号")
				Me.C1FGridManage(iRecordCount, "県名") = dt.Rows(iRow)("県名")
				Me.C1FGridManage(iRecordCount, "仮フォルダ") = dt.Rows(iRow)("仮フォルダ")
				Me.C1FGridManage(iRecordCount, "納品フォルダ") = dt.Rows(iRow)("納品フォルダ")
				Me.C1FGridManage(iRecordCount, "エクセルファイル名") = dt.Rows(iRow)("エクセルファイル名")
				Me.C1FGridManage(iRecordCount, "スキャン") = dt.Rows(iRow)("スキャン")
				Me.C1FGridManage(iRecordCount, "レコード") = dt.Rows(iRow)("レコード")
				Me.C1FGridManage(iRecordCount, "処理端末") = dt.Rows(iRow)("処理端末")
				Me.C1FGridManage(iRecordCount, "開始日時") = IIf(dt.Rows(iRow)("開始日時") = "1900/01/01", Nothing, dt.Rows(iRow)("開始日時"))
				Me.C1FGridManage(iRecordCount, "終了日時") = IIf(dt.Rows(iRow)("終了日時") = "1900/01/01", Nothing, dt.Rows(iRow)("終了日時"))
				Me.C1FGridManage(iRecordCount, "終了日時2次") = IIf(dt.Rows(iRow)("終了日時2次") = "1900/01/01", Nothing, dt.Rows(iRow)("終了日時2次"))
				Me.C1FGridManage(iRecordCount, "処理ユーザー") = dt.Rows(iRow)("処理ユーザー")
			Next
			Me.C1FGridManage.EndUpdate()

			Me.C1FGridManage.AutoSizeCols()

			If Me.C1FGridManage.Rows.Count > 1 Then
				Me.C1FGridManage.Row = 1
			End If

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		Finally

			sqlProcess.Close()

		End Try

	End Sub

	''' <summary>
	''' 管理表インポートボタン押下時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub btnManageImport_Click(sender As Object, e As EventArgs) Handles btnManageImport.Click

		If Not System.IO.File.Exists(Me.txtManageFile.Text) Then
			MessageBox.Show("管理表のCSVファイルを指定してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Exit Sub
		End If

		If MessageBox.Show("指定された管理表CSVファイルをインポートします" & vbNewLine & "よろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
			Exit Sub
		End If

		EnableControls(Me, False)

		Dim strCSVFile As String = Me.txtManageFile.Text
		Dim iRecordCount As Integer = 0
		Dim iInsert As Integer = 0  '新規レコード
		Dim iUpdate As Integer = 0  '更新レコード

		Using parser As New TextFieldParser(strCSVFile, Encoding.GetEncoding("Shift-JIS"))

			parser.TextFieldType = FieldType.Delimited
			parser.SetDelimiters(","c) '区切り文字はカンマ

			parser.HasFieldsEnclosedInQuotes = True 'データ内にデリミタがあっても区切らない
			parser.TrimWhiteSpace = False   '空白文字を削除しない

			Dim strSQL As String = ""
			Dim sqlProcess As New SQLProcess

			Try

				While Not parser.EndOfData
					Application.DoEvents()
					iRecordCount += 1

					Dim row As String() = parser.ReadFields()   '1行読み込み、項目を配列に代入

					'フィールドが7未満の場合はエラーとする
					If row.Length < 7 Then
						MessageBox.Show("インポートする項目が足りません" & vbNewLine & "CSVファイルを確認してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
						Exit Sub
					End If

					If iRecordCount = 1 Then
						'ヘッダを読み飛ばす
						Continue While
					End If

					'納品フォルダ(4項目目)がDBに既に存在するか確認
					'存在した場合はUPDATE、それ以外は管理IDを新たにインクリメントしてINSERT
					strSQL = "SELECT 管理ID FROM M_管理表 "
					strSQL &= "WHERE 納品フォルダ = '" & row(3) & "'"
					Dim dt As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)

					If dt.Rows.Count = 0 Then
						'存在しなかった場合INSERT
						'管理IDの最大値＋１を取得
						strSQL = "SELECT ISNULL(MAX(管理ID), 0) + 1 FROM M_管理表"
						Dim iMax As Integer = sqlProcess.DB_EXECUTE_SCALAR(strSQL)
						strSQL = "INSERT INTO M_管理表 (管理ID, M番号, 県名, 仮フォルダ, 納品フォルダ, エクセルファイル名, スキャン, レコード, 処理端末, "
						strSQL &= "開始日時, 終了日時, 終了日時2次, 備考, 処理ユーザー) VALUES("
						strSQL &= iMax  '管理ID
						strSQL &= ", N'" & row(0) & "'"  'M番号
						strSQL &= ", N'" & row(1) & "'"  '県名
						strSQL &= ", N'" & row(2) & "'"  '仮フォルダ
						strSQL &= ", N'" & row(3) & "'"  '納品フォルダ
						strSQL &= ", N'" & row(4) & "'"  'エクセルファイル名
						strSQL &= ", " & row(5) 'スキャン
						strSQL &= ", " & row(6) 'レコード
						strSQL &= ", N''"   '処理端末
						strSQL &= ", NULL"  '開始日時
						strSQL &= ", NULL"  '終了日時
						strSQL &= ", NULL"  '終了日時2次
						strSQL &= ", N''"   '備考
						strSQL &= ", N'')"   '処理ユーザー
						sqlProcess.DB_UPDATE(strSQL)
						iInsert += 1
					Else
						'存在したらUPDATE
						'ステータス関係はUPDATEしない
						strSQL = "UPDATE M_管理表 SET "
						strSQL &= "M番号 = N'" & row(0) & "'"
						strSQL &= ", 県名 = N'" & row(1) & "'"
						strSQL &= ", 仮フォルダ = N'" & row(2) & "'"
						strSQL &= ", エクセルファイル名 = N'" & row(4) & "'"
						strSQL &= ", スキャン = " & row(5)
						strSQL &= ", レコード = " & row(6) & " "
						strSQL &= "WHERE 管理ID = " & dt.Rows(0)("管理ID")
						sqlProcess.DB_UPDATE(strSQL)
						iUpdate += 1
					End If

				End While

				MessageBox.Show("管理表のインポート処理が完了しました" & vbNewLine & "インポートレコード数：" & iRecordCount - 1 & vbNewLine & "新規レコード数：" & iInsert & vbNewLine & "更新レコード数：" & iUpdate, "確認", MessageBoxButtons.OK, MessageBoxIcon.Information)

			Catch ex As Exception

				Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message)
				MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

			Finally

				sqlProcess.Close()
				EnableControls(Me, True)

			End Try

		End Using

	End Sub

	''' <summary>
	''' CSV出力ボタン押下時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub btnCSVOutput_Click(sender As Object, e As EventArgs) Handles btnCSVOutput.Click

		OutputCSVFile(Me.C1FGridManage, "")

	End Sub

#End Region

#Region "オブジェクトイベント(画像)"

	''' <summary>
	''' 検索ボタン押下時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub btnImageSearch_Click(sender As Object, e As EventArgs) Handles btnImageSearch.Click

		ImageSearch()

	End Sub

	''' <summary>
	''' グリッドマウスダウン前
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub C1FGridImage_BeforeMouseDown(sender As Object, e As BeforeMouseDownEventArgs) Handles C1FGridImage.BeforeMouseDown

		If e.Button = MouseButtons.Left And e.Clicks > 1 Then
			'左ダブルクリックされたとき
			Dim hti As C1.Win.C1FlexGrid.HitTestInfo = Me.C1FGridImage.HitTest(e.X, e.Y)

			If hti.Row < Me.C1FGridImage.Cols.Fixed Then
				'ヘッダがダブルクリックされた
				'何もしない
			ElseIf hti.Column = 2 Then
				'M番号項目がダブルクリックされた
				'現在のレコードを記憶する
				Dim iIndex As Integer = Me.C1FGridImage.Row

				Dim frm As New frmMain
				frm.IsAdmin = True
				frm.ManageID = Me.C1FGridImage(hti.Row, "管理ID")
				Me.Visible = False
				frm.ShowDialog(Me)

				'ウィンドウ復帰後の動作
				ImageSearch()
				'フォーカス行の復帰
				If Me.C1FGridImage.Rows.Count < iIndex Then
					Me.C1FGridImage.Row = Me.C1FGridImage.Rows.Count - 1
				Else
					Me.C1FGridImage.Row = iIndex
				End If

			End If
		End If

	End Sub

#End Region

#Region "オブジェクトイベント(出力)"

	''' <summary>
	''' 更新ボタン押下時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub btnOutputUpdate_Click(sender As Object, e As EventArgs) Handles btnOutputUpdate.Click

		OutputUpdate()

	End Sub

	''' <summary>
	''' 県名コンボボックスインデックス変更時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub cmbOutputPrefecture_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbOutputPrefecture.SelectedIndexChanged

		PrefectureSelect()

	End Sub

	''' <summary>
	''' フラグコンボボックスインデックス変更時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub cmbOutputFlag_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbOutputFlag.SelectedIndexChanged

		PrefectureSelect()

	End Sub

	''' <summary>
	''' 変更フラグコンボボックスインデックス変更時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub cmbOutputUpdateFlag_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbOutputUpdateFlag.SelectedIndexChanged

		PrefectureSelect()

	End Sub

	''' <summary>
	''' FROMグリッドダブルクリック時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub C1FGridOutputFrom_DoubleClick(sender As Object, e As EventArgs) Handles C1FGridOutputFrom.DoubleClick
		'TOグリッドへレコードをコピーしてFROMから削除する
		'コンボボックス変更時にFROM側はリセットされてしまうので、同一管理IDをTO側へコピーさせないようにする
		Dim iIndex As Integer = Me.C1FGridOutputFrom.Row
		'フラグ数と確認数が同一か調べる
		If Not Me.C1FGridOutputFrom(iIndex, "フラグ") = Me.C1FGridOutputFrom(iIndex, "確認") Then
			'MessageBox.Show("全てのフラグの確認作業を行ってください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
			If MessageBox.Show("全てのフラグの確認が済んでいません" & vbNewLine & "続行しますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
				Exit Sub
			End If
		End If

		MoveRecord(iIndex)

	End Sub

	''' <summary>
	''' 全レコード移動ボタン押下時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub btnOutputMove_Click(sender As Object, e As EventArgs) Handles btnOutputMove.Click

		'全レコードがフラグ数＝確認数となっているか確認
		'エラーが発生したらフラグを立てて抜ける
		Dim blnFlag As Boolean = False
		For iIndex As Integer = 1 To Me.C1FGridOutputFrom.Rows.Count - 1
			'フラグ数と確認数が同一か調べる
			If Not Me.C1FGridOutputFrom(iIndex, "フラグ") = Me.C1FGridOutputFrom(iIndex, "確認") Then
				'MessageBox.Show("全てのフラグの確認作業を行ってください：" & vbNewLine & Me.C1FGridOutputFrom(iIndex, "納品フォルダ"), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
				blnFlag = True
				Exit For
			End If
		Next

		If blnFlag Then
			If MessageBox.Show("すべてのフラグの確認が済んでいません" & vbNewLine & "続行しますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
				Exit Sub
			End If
		End If

		If MessageBox.Show("表示されている全てのフォルダを移動しますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
			Exit Sub
		End If

		MoveAllRecord()

	End Sub

	''' <summary>
	''' TOグリッドクリアボタン押下時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub btnOutputClear_Click(sender As Object, e As EventArgs) Handles btnOutputClear.Click

		If MessageBox.Show("出力候補のフォルダを全てクリアしますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
			Exit Sub
		End If

		Me.C1FGridOutputTo.Rows.Count = 1
		PrefectureSelect()  'グリッドFROMの再検索

	End Sub

	''' <summary>
	''' フォルダブラウズボタン押下時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub btnOutputFolderBrowse_Click(sender As Object, e As EventArgs) Handles btnOutputFolderBrowse.Click

		Me.txtOutputFolder.Text = FolderBrowse(Me.txtOutputFolder)

	End Sub

	''' <summary>
	''' 参照フォルダブラウズボタン押下時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub btnOutputSrcFolderBrowse_Click(sender As Object, e As EventArgs) Handles btnOutputSrcFolderBrowse.Click

		Me.txtOutputSrcFolder.Text = FolderBrowse(Me.txtOutputSrcFolder)

	End Sub


	''' <summary>
	''' 出力ボタン押下時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub btnOutput_Click(sender As Object, e As EventArgs) Handles btnOutput.Click

		If Not System.IO.Directory.Exists(Me.txtOutputFolder.Text) Then
			MessageBox.Show("出力フォルダを指定してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Exit Sub
		End If

		If Me.C1FGridOutputTo.Rows.Count = 1 Then
			MessageBox.Show("出力対象が1件もありません", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Exit Sub
		End If

		If Not Me.chkOutputImage.Checked And Not Me.chkOutputExcel.Checked Then
			MessageBox.Show("出力したい対象にチェックを付けてください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Exit Sub
		End If

		If MessageBox.Show("出力を開始します" & vbNewLine & "よろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
			Exit Sub
		End If

		'ログファイルの作成
		Dim strDateTime As String = Date.Now.ToString("yyyyMMdd_HHmmss")
		Dim strImageLogFile As String = Me.txtOutputFolder.Text & "\" & strDateTime & "_イメージ.log"
		Dim strExcelLogFile As String = Me.txtOutputFolder.Text & "\" & strDateTime & "_エクセル.log"

		If Me.chkOutputImage.Checked And Me.chkOutputExcel.Checked Then
			'イメージ、エクセル共に出力
			'イメージ出力
			If Not OutputImage(strImageLogFile, False) Then
				MessageBox.Show("イメージ出力中にエラーが発生しました", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
				Exit Sub
			End If
			'エクセル出力
			If Not OutputExcel(strExcelLogFile) Then
				MessageBox.Show("エクセルファイル出力中にエラーが発生しました", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
				Exit Sub
			End If
			MessageBox.Show("出力処理が完了しました" & vbNewLine & "ログを確認してください" & vbNewLine & strImageLogFile & vbNewLine & strExcelLogFile, "確認", MessageBoxButtons.OK, MessageBoxIcon.Information)

		ElseIf Me.chkOutputImage.Checked And Not Me.chkOutputExcel.Checked Then
			'イメージのみ出力
			'イメージ出力
			If Not OutputImage(strImageLogFile, False) Then
				MessageBox.Show("イメージ出力中にエラーが発生しました", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
				Exit Sub
			End If
			MessageBox.Show("出力処理が完了しました" & vbNewLine & "ログを確認してください" & vbNewLine & strImageLogFile, "確認", MessageBoxButtons.OK, MessageBoxIcon.Information)

		ElseIf Not Me.chkOutputImage.Checked And Me.chkOutputExcel.Checked Then
			'エクセルのみ出力
			'T_出力ファイルの更新
			If Not OutputImage(strImageLogFile, True) Then
				MessageBox.Show("ファイル情報取得中にエラーが発生しました", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
				Exit Sub
			End If
			'エクセル出力
			If Not OutputExcel(strExcelLogFile) Then
				MessageBox.Show("エクセルファイル出力中にエラーが発生しました", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
				Exit Sub
			End If
			MessageBox.Show("出力処理が完了しました" & vbNewLine & "ログを確認してください" & vbNewLine & strExcelLogFile, "確認", MessageBoxButtons.OK, MessageBoxIcon.Information)

		End If

		'グリッドTOの値をクリア
		Me.C1FGridOutputTo.Rows.Count = 1

	End Sub

	''' <summary>
	''' イメージ出力
	''' </summary>
	''' <param name="strLogFile"></param>
	''' <param name="DoNotExport"></param>
	''' <returns>エクセル出力のみのときはDoNotExportをTrueにしてT_出力ファイルのみ更新する</returns>
	Private Function OutputImage(ByVal strLogFile As String, ByVal DoNotExport As Boolean) As Boolean

		Dim strSQL As String = ""
		Dim sqlProcess As New SQLProcess

		Try
			Using sw As New System.IO.StreamWriter(strLogFile, False, System.Text.Encoding.GetEncoding("Shift-JIS"))
				'プログレスバーの初期化
				Me.ProgressBar1.Maximum = C1FGridOutputTo.Rows.Count - 1
				Me.ProgressBar1.Value = 0
				Me.lblOutputProgress.Text = "0 / " & Me.ProgressBar1.Maximum

				'TOグリッドで回す
				For iRow As Integer = 1 To Me.C1FGridOutputTo.Rows.Count - 1

					strSQL = "SELECT 管理ID, 仮フォルダ, 納品フォルダ, M番号 FROM M_管理表 "
					strSQL &= "WHERE 管理ID = " & Me.C1FGridOutputTo(iRow, "管理ID")
					Dim dtManage As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
					sw.WriteLine("==================================================")
					sw.WriteLine("仮フォルダ：" & dtManage.Rows(0)("仮フォルダ"))
					sw.WriteLine("納品フォルダ：" & dtManage.Rows(0)("納品フォルダ"))
					'元フォルダを特定
					Dim strSrcFolder As String = Me.txtOutputSrcFolder.Text & "\" & dtManage.Rows(0)("M番号") & "\" & dtManage.Rows(0)("仮フォルダ")
					'出力フォルダ特定
					Dim strDestFolder As String = Me.txtOutputFolder.Text & "\" & dtManage.Rows(0)("M番号") & "\" & dtManage.Rows(0)("納品フォルダ")
					'イメージパスの取得
					Dim strFiles As String() = GetFilesMostDeep(strSrcFolder, {"*.jpg"})
					'削除対象を列挙
					strSQL = "SELECT T1.ファイル名, T2.フラグ FROM T_フラグ AS T1 INNER JOIN "
					strSQL &= "M_フラグ AS T2 ON T1.種別ID = T2.種別ID AND T1.フラグID = T2.フラグID "
					strSQL &= "WHERE T1.種別ID = 30 "
					strSQL &= "AND 管理ID = " & Me.C1FGridOutputTo(iRow, "管理ID")
					Dim dt As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
					'削除対象リストの作成
					Dim listDelete As String() = Nothing
					If dt.Rows.Count > 0 Then
						'レコードがあったらログに出力
						ReDim listDelete(dt.Rows.Count - 1)
						For i As Integer = 0 To dt.Rows.Count - 1
							sw.WriteLine("削除対象ファイル：" & dt.Rows(i)("ファイル名") & "：" & dt.Rows(i)("フラグ"))
							listDelete(i) = dt.Rows(i)("ファイル名")
						Next
					End If
					sw.WriteLine("元フォルダ：" & strSrcFolder)
					sw.WriteLine("出力フォルダ：" & strDestFolder)

					strSQL = "DELETE FROM T_出力ファイル "
					strSQL &= "WHERE 管理ID = " & dtManage.Rows(0)("管理ID")
					sqlProcess.DB_UPDATE(strSQL)

					'ファイルリストで回す
					Dim iFileCount As Integer = 0
					For Each strFile As String In strFiles
						'削除対象になっていたらログに出力して次のループへ
						If Not listDelete Is Nothing Then
							If Array.IndexOf(listDelete, System.IO.Path.GetFileNameWithoutExtension(strFile)) >= 0 Then
								'削除対象だった
								sw.WriteLine("削除対象：" & System.IO.Path.GetFileNameWithoutExtension(strFile))
								Continue For
							End If
						End If
						iFileCount += 1
						'出力ファイル名
						Dim strOutFile As String = strDestFolder & "\" & dtManage.Rows(0)("納品フォルダ") & "P" & iFileCount.ToString("0000") & ".jpg"
						'T_出力ファイルにINSERT
						strSQL = "INSERT INTO T_出力ファイル (管理ID, 連番, フォルダ名, ファイル名, 出力ファイル名) "
						strSQL &= "VALUES(" & dtManage.Rows(0)("管理ID")  '管理ID
						strSQL &= ", " & iFileCount '連番
						strSQL &= ", N'" & dtManage.Rows(0)("M番号") & "/" & dtManage.Rows(0)("納品フォルダ") & "'" 'フォルダ名(エクセル用)
						strSQL &= ", N'" & System.IO.Path.GetFileNameWithoutExtension(strFile) & "'"    'ファイル名
						strSQL &= ", N'" & dtManage.Rows(0)("納品フォルダ") & "P" & iFileCount.ToString("0000") & "')"   '出力ファイル名
						sqlProcess.DB_UPDATE(strSQL)

						'エクセル出力のみのときはファイルコピーを行わない
						If Not DoNotExport Then
							'ファイルコピー
							'フォルダの存在確認
							If Not System.IO.Directory.Exists(strDestFolder) Then
								'存在しなかったらフォルダ作成
								My.Computer.FileSystem.CreateDirectory(strDestFolder)
							End If
							My.Computer.FileSystem.CopyFile(strFile, strOutFile)

							sw.WriteLine("ファイルコピー：" & System.IO.Path.GetFileNameWithoutExtension(strFile) & "→" & dtManage.Rows(0)("M番号") & "\" & dtManage.Rows(0)("納品フォルダ") & "\" & System.IO.Path.GetFileNameWithoutExtension(strOutFile))
							'出力日時の記録
							strSQL = "UPDATE M_管理表 SET 出力日時 = '" & Date.Now.ToString("yyyy/MM/dd HH:mm:ss") & "' "
							strSQL &= " WHERE 管理ID = " & dtManage.Rows(0)("管理ID")
							sqlProcess.DB_UPDATE(strSQL)

						End If
					Next

					Me.ProgressBar1.Value = iRow
					Me.lblOutputProgress.Text = iRow & " / " & Me.ProgressBar1.Maximum
					Application.DoEvents()
				Next

			End Using

			Return True

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Return False

		Finally

			sqlProcess.Close()

		End Try

	End Function

	''' <summary>
	''' エクセル出力
	''' </summary>
	''' <param name="strLogFile"></param>
	''' <returns></returns>
	Private Function OutputExcel(ByVal strLogFile As String) As Boolean

		Dim strSQL As String = ""
		Dim sqlProcess As New SQLProcess

		Try
			Using sw As New System.IO.StreamWriter(strLogFile, False, System.Text.Encoding.GetEncoding("Shift-JIS"))
				'プログレスバーの初期化
				Me.ProgressBar1.Maximum = C1FGridOutputTo.Rows.Count - 1
				Me.ProgressBar1.Value = 0
				Me.lblOutputProgress.Text = "0 / " & Me.ProgressBar1.Maximum

				sw.WriteLine("エクセル出力前の調査開始")
				'TOグリッドで回す
				For iRow As Integer = 1 To Me.C1FGridOutputTo.Rows.Count - 1
					strSQL = "DELETE FROM T_出力 "
					strSQL &= "WHERE 管理ID = " & Me.C1FGridOutputTo(iRow, "管理ID")
					sqlProcess.DB_UPDATE(strSQL)

					sw.WriteLine("==================================================")
					sw.WriteLine("仮フォルダ：" & Me.C1FGridOutputTo(iRow, "仮フォルダ"))
					sw.WriteLine("納品フォルダ：" & Me.C1FGridOutputTo(iRow, "納品フォルダ"))
					'削除フラグレコードがあったらログに残す
					strSQL = "SELECT 連番, レコード番号, タイトル1 FROM T_目次 "
					strSQL &= "WHERE 管理ID = " & Me.C1FGridOutputTo(iRow, "管理ID") & " "
					strSQL &= "AND フラグID = 2"
					Dim dt As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
					If dt.Rows.Count > 0 Then
						For i As Integer = 0 To dt.Rows.Count - 1
							sw.WriteLine("削除レコード：" & dt.Rows(i)("連番") & "：" & dt.Rows(i)("レコード番号") & "：" & dt.Rows(i)("タイトル1"))
						Next
					End If

					'レコード番号用フォルダ名をM_管理表から取得
					strSQL = "SELECT 納品フォルダ FROM M_管理表 "
					strSQL &= "WHERE 管理ID = " & Me.C1FGridOutputTo(iRow, "管理ID")
					Dim strRecordNo As String = sqlProcess.DB_EXECUTE_SCALAR(strSQL)

					'T_目次から該当管理IDを「削除」フラグを除外して抽出する
					'連番は振り直す
					'抽出したレコードは順次T_出力に書き込む
					strSQL = "SELECT 管理ID, 連番, レコード番号, 表示用, 行番号, 県名, 資料名, 副題, 対象年, 刊行者名, 刊行年月, "
					strSQL &= "分類1, 分類2, 分類番号, 項目, 番号1, タイトル1, 番号2, タイトル2, 番号3, タイトル3, 番号4, タイトル4, 番号5, タイトル5, "
					strSQL &= "リンク, リンクTO "
					strSQL &= "FROM T_目次 "
					strSQL &= "WHERE 管理ID = " & Me.C1FGridOutputTo(iRow, "管理ID") & " "
					strSQL &= "AND フラグID != 2"
					dt = sqlProcess.DB_SELECT_DATATABLE(strSQL)
					For i As Integer = 0 To dt.Rows.Count - 1
						'連番、レコード番号(納品フォルダ＋3桁連番)、行番号を書き換えながらT_出力に書き込む
						'T_出力ファイルからフォルダ名、ファイル名を取得する
						'リンク始め
						Dim strLinkFrom As String = ""
						Dim strLinkFolder As String = ""
						If Not IsNull(dt.Rows(i)("リンク")) Then
							strSQL = "SELECT 出力ファイル名, フォルダ名 FROM T_出力ファイル "
							strSQL &= "WHERE 管理ID = " & dt.Rows(i)("管理ID") & " "
							strSQL &= "AND ファイル名 = '" & dt.Rows(i)("リンク") & "'"
							'フォルダ名も一緒に取得
							Dim dtLinkFrom As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
							strLinkFrom = dtLinkFrom.Rows(0)("出力ファイル名")
							strLinkFolder = dtLinkFrom.Rows(0)("フォルダ名")
						Else
							'2017/05/19
							'リンクがない場合も、フォルダ名は取得する
							strSQL = "SELECT フォルダ名 FROM T_出力ファイル "
							strSQL &= "WHERE 管理ID = " & dt.Rows(i)("管理ID") & " "
							strSQL &= "GROUP BY フォルダ名"
							Dim dtFolder As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
							strLinkFolder = dtFolder.Rows(0)("フォルダ名")
						End If
						'リンク終り
						Dim strLinkTo As String = ""
						If Not IsNull(dt.Rows(i)("リンクTO")) Then
							strSQL = "SELECT 出力ファイル名 FROM T_出力ファイル "
							strSQL &= "WHERE 管理ID = " & dt.Rows(i)("管理ID") & " "
							strSQL &= "AND ファイル名 = '" & dt.Rows(i)("リンクTO") & "'"
							Dim dtLinkTo As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
							strLinkTo = dtLinkTo.Rows(0)("出力ファイル名")
						End If
						'============================================================
						strSQL = "INSERT INTO T_出力 (管理ID, 連番, レコード番号, 表示用, 行番号, 県名, 資料名, 副題, 対象年, 刊行者名, 刊行年月, "
						strSQL &= "分類1, 分類2, 分類番号, 項目, 番号1, タイトル1, 番号2, タイトル2, 番号3, タイトル3, 番号4, タイトル4, 番号5, タイトル5, "
						strSQL &= "フォルダ名, リンク, リンクTO) VALUES("
						strSQL &= dt.Rows(i)("管理ID")
						strSQL &= ", " & dt.Rows(i)("連番")
						strSQL &= ", N'P" & strRecordNo & (i + 1).ToString("000") & "'"   'P＋フォルダ名＋3桁連番
						strSQL &= ", N'" & dt.Rows(i)("表示用") & "'"
						strSQL &= ", " & (i + 1).ToString   '行番号
						strSQL &= ", N'" & dt.Rows(i)("県名") & "'"
						strSQL &= ", N'" & dt.Rows(i)("資料名") & "'"
						strSQL &= ", N'" & dt.Rows(i)("副題") & "'"
						strSQL &= ", N'" & dt.Rows(i)("対象年") & "'"
						strSQL &= ", N'" & dt.Rows(i)("刊行者名") & "'"
						strSQL &= ", N'" & dt.Rows(i)("刊行年月") & "'"
						strSQL &= ", N'" & dt.Rows(i)("分類1") & "'"
						strSQL &= ", N'" & dt.Rows(i)("分類2") & "'"
						strSQL &= ", N'" & dt.Rows(i)("分類番号") & "'"
						strSQL &= ", N'" & dt.Rows(i)("項目") & "'"
						strSQL &= ", N'" & dt.Rows(i)("番号1") & "'"
						strSQL &= ", N'" & dt.Rows(i)("タイトル1") & "'"
						strSQL &= ", N'" & dt.Rows(i)("番号2") & "'"
						strSQL &= ", N'" & dt.Rows(i)("タイトル2") & "'"
						strSQL &= ", N'" & dt.Rows(i)("番号3") & "'"
						strSQL &= ", N'" & dt.Rows(i)("タイトル3") & "'"
						strSQL &= ", N'" & dt.Rows(i)("番号4") & "'"
						strSQL &= ", N'" & dt.Rows(i)("タイトル4") & "'"
						strSQL &= ", N'" & dt.Rows(i)("番号5") & "'"
						strSQL &= ", N'" & dt.Rows(i)("タイトル5") & "'"
						strSQL &= ", N'" & strLinkFolder & "'"  'フォルダ名
						strSQL &= ", N'" & strLinkFrom & "'"    'リンク
						strSQL &= ", N'" & strLinkTo & "')"  'リンクTO
						sqlProcess.DB_UPDATE(strSQL)
					Next
				Next
				sw.WriteLine("エクセル出力前の調査完了")
				sw.WriteLine("==================================================")
				sw.WriteLine("エクセルの出力開始")

				Dim strExcelFolder As String = Me.txtOutputFolder.Text & "\" & "Excel_" & Microsoft.VisualBasic.Strings.Left(System.IO.Path.GetFileNameWithoutExtension(strLogFile), 15)  'エクセルファイルの保存先(ログファイルの日時を流用)
				If Not System.IO.Directory.Exists(strExcelFolder) Then
					'フォルダが存在しなかったら作成する
					My.Computer.FileSystem.CreateDirectory(strExcelFolder)
				End If
				'エクセルテンプレートの指定
				Dim strExcelTemplate As String = Application.StartupPath & "\Template\Template.xlsx"

				'グリッドTOの管理IDで回して各エクセルファイルにレコードを保存する
				For iRow As Integer = 1 To Me.C1FGridOutputTo.Rows.Count - 1
					'エクセルファイル名を取得
					strSQL = "SELECT エクセルファイル名 FROM M_管理表 "
					strSQL &= "WHERE 管理ID = " & Me.C1FGridOutputTo(iRow, "管理ID")
					Dim strExcelFile As String = strExcelFolder & "\" & sqlProcess.DB_EXECUTE_SCALAR(strSQL)
					'拡張子をXLSXで統一する
					strExcelFile = System.IO.Path.GetDirectoryName(strExcelFile) & "\" & System.IO.Path.GetFileNameWithoutExtension(strExcelFile) & ".xlsx"

					strSQL = "SELECT レコード番号, 表示用, 行番号, 県名, 資料名, 副題, 対象年, 刊行者名, 刊行年月, 分類1, 分類2, 分類番号, 項目, "
					strSQL &= "番号1, タイトル1, 番号2, タイトル2, 番号3, タイトル3, 番号4, タイトル4, 番号5, タイトル5, フォルダ名, リンク, リンクTO "
					strSQL &= "FROM T_出力 "
					strSQL &= "WHERE 管理ID = " & Me.C1FGridOutputTo(iRow, "管理ID") & " "
					strSQL &= "ORDER BY 連番"
					Dim dt As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
					'エクセル出力
					If Not WriteExcelFile(strExcelTemplate, strExcelFile, dt) Then
						MessageBox.Show("エクセルファイル出力中にエラーが発生しました" & vbNewLine & strExcelFile, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
						Return False
						Exit Function
					End If

					'出力日時の記録
					strSQL = "UPDATE M_管理表 SET 出力日時エクセル = '" & Date.Now.ToString("yyyy/MM/dd HH:mm:ss") & "' "
					strSQL &= " WHERE 管理ID = " & Me.C1FGridOutputTo(iRow, "管理ID")
					sqlProcess.DB_UPDATE(strSQL)

				Next

				sw.WriteLine("エクセルの出力完了")
				sw.WriteLine("==================================================")
				sw.WriteLine("出力結果")
				'グリッドTOの管理IDに対してT_出力内のレコード数を列挙する
				For iRow As Integer = 1 To Me.C1FGridOutputTo.Rows.Count - 1
					strSQL = "SELECT T2.M番号, T2.県名, T2.納品フォルダ, T2.エクセルファイル名, "
					strSQL &= "COUNT(T1.管理ID) AS レコード数 "
					strSQL &= "FROM T_出力 AS T1 INNER JOIN "
					strSQL &= "M_管理表 AS T2 ON T1.管理ID = T2.管理ID "
					strSQL &= "WHERE T1.管理ID = " & Me.C1FGridOutputTo(iRow, "管理ID") & " "
					strSQL &= "GROUP BY T2.M番号, T2.県名, T2.納品フォルダ, T2.エクセルファイル名"
					Dim dt As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
					If dt.Rows.Count > 0 Then
						sw.WriteLine(dt.Rows(0)("M番号") & vbTab & dt.Rows(0)("県名") & vbTab & dt.Rows(0)("納品フォルダ") & vbTab &
									 dt.Rows(0)("エクセルファイル名") & vbTab & dt.Rows(0)("レコード数"))
					End If
				Next

			End Using

			Return True

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Return False

		Finally

			sqlProcess.Close()

		End Try

	End Function

#End Region

#Region "オブジェクトイベント(集計)"

	''' <summary>
	''' 更新ボタン押下時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub btnSummaryUpdate_Click(sender As Object, e As EventArgs) Handles btnSummaryUpdate.Click

		InitializeSummary()

	End Sub

	''' <summary>
	''' CSV出力ボタン押下時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub btnSummaryCSCOutput_Click(sender As Object, e As EventArgs) Handles btnSummaryCSCOutput.Click

		OutputCSVFile(Me.C1FGridSummary, "")

	End Sub

#End Region

#Region "プライベートメソッド"

	''' <summary>
	''' 初期化処理
	''' </summary>
	Private Sub Initialize()

		Dim strSQL As String = ""
		Dim sqlProcess As New SQLProcess

		Try
			'フォーム位置、サイズの設定
			XmlSettings.LoadFromXmlFile()
			Me.Left = XmlSettings.Instance.LocManageX
			Me.Top = XmlSettings.Instance.LocManageY
			Me.Width = XmlSettings.Instance.SizeManageX
			Me.Height = XmlSettings.Instance.SizeManageY

			Me.WindowState = FormWindowState.Normal

			'ステータスバーの初期化
			'Me.btnBack.Text = "戻る"
			Me.lblBookletID.Visible = False
			Me.lblImageCount.Visible = False
			Me.btnFit.Visible = False
			Me.btnImageBottom.Visible = False
			Me.btnImageNext.Visible = False
			Me.btnImagePrev.Visible = False
			Me.btnImageTop.Visible = False
			Me.btnMagnification.Visible = False
			Me.btnReduction.Visible = False
			Me.btnRotateLeft.Visible = False
			Me.btnRotateRight.Visible = False

			Me.lblUser.Text = m_LoginUser.User

			'各コンボボックスに値を設定する
			Dim dt As DataTable = Nothing
			'=====================================================================================
			'目次データ
			'=====================================================================================
			'納品フォルダ名
			strSQL = "SELECT T1.納品フォルダ, T1.納品フォルダ FROM M_管理表 AS T1 INNER JOIN "
			strSQL &= "M_管理表 AS T2 ON T1.納品フォルダ = T2.納品フォルダ "
			strSQL &= "GROUP BY T1.納品フォルダ, T2.納品フォルダ "
			strSQL &= "ORDER BY T1.納品フォルダ"
			dt = sqlProcess.DB_SELECT_DATATABLE(strSQL)

			SetComboValue(Me.cmbContentsDelivFolderName, dt)
			'オートコンプリート
			Me.cmbContentsDelivFolderName.AutoCompleteMode = AutoCompleteMode.SuggestAppend
			Me.cmbContentsDelivFolderName.AutoCompleteSource = AutoCompleteSource.ListItems
			Me.cmbContentsDelivFolderName.SelectedIndex = 0
			'=====================================================================================
			'仮フォルダ
			strSQL = "SELECT T1.仮フォルダ, T2.仮フォルダ FROM M_管理表 AS T1 INNER JOIN "
			strSQL &= "M_管理表 AS T2 ON T1.仮フォルダ = T2.仮フォルダ "
			strSQL &= "GROUP BY T1.仮フォルダ, T2.仮フォルダ "
			strSQL &= "ORDER BY T1.仮フォルダ"
			dt = sqlProcess.DB_SELECT_DATATABLE(strSQL)

			SetComboValue(Me.cmbContentsProvFolderName, dt)
			'オートコンプリート
			Me.cmbContentsProvFolderName.AutoCompleteMode = AutoCompleteMode.SuggestAppend
			Me.cmbContentsProvFolderName.AutoCompleteSource = AutoCompleteSource.ListItems
			Me.cmbContentsProvFolderName.SelectedIndex = 0
			'=====================================================================================
			'県名コンボボックス
			strSQL = "SELECT T1.都道府県名, T2.都道府県名 FROM M_都道府県 AS T1 INNER JOIN "
			strSQL &= "M_都道府県 AS T2 ON T1.都道府県番号 = T2.都道府県番号 "
			strSQL &= "ORDER BY T1.都道府県番号"
			dt = sqlProcess.DB_SELECT_DATATABLE(strSQL)

			SetComboValue(Me.cmbContentsPrefecture, dt)
			Me.cmbContentsPrefecture.SelectedIndex = 0
			'=====================================================================================
			'対象年
			strSQL = "SELECT T1.対象年, T2.対象年 FROM T_目次 AS T1 INNER JOIN "
			strSQL &= "T_目次 AS T2 ON T1.対象年 = T2.対象年 "
			strSQL &= "GROUP BY T1.対象年, T2.対象年 "
			strSQL &= "ORDER BY T1.対象年"
			dt = sqlProcess.DB_SELECT_DATATABLE(strSQL)

			SetComboValue(Me.cmbContentsTargetYear, dt)
			Me.cmbContentsTargetYear.SelectedIndex = 0
			'=====================================================================================
			'フラグ
			strSQL = "SELECT フラグID, フラグ FROM M_フラグ "
			strSQL &= "WHERE 種別ID = 20 "
			strSQL &= "ORDER BY フラグID"
			dt = sqlProcess.DB_SELECT_DATATABLE(strSQL)

			SetComboValue(Me.cmbContentsFlag, dt)
			Me.cmbContentsFlag.SelectedIndex = 0
			'=====================================================================================
			'変更フラグ
			strSQL = "SELECT フラグID, フラグ FROM M_フラグ "
			strSQL &= "WHERE 種別ID = 40 "
			strSQL &= "ORDER BY フラグID"
			dt = sqlProcess.DB_SELECT_DATATABLE(strSQL)

			SetComboValue(Me.cmbContentsUpdateFlag, dt)
			Me.cmbContentsUpdateFlag.SelectedIndex = 0
			'=====================================================================================
			'確認フラグ
			strSQL = "SELECT フラグID, フラグ FROM M_フラグ "
			strSQL &= "WHERE 種別ID = 50 "
			strSQL &= "ORDER BY フラグID"
			dt = sqlProcess.DB_SELECT_DATATABLE(strSQL)

			SetComboValue(Me.cmbContentsConfirm, dt)
			Me.cmbContentsConfirm.SelectedIndex = 0

			'ハイライトスタイルの設定
			'カスタムスタイルを作成
			Me.C1FGridContents.Styles.Add("track")
			Me.C1FGridContents.Styles("track").BackColor = Color.Gold
			'カレント行カーソルの表示
			Me.C1FGridContents.ShowCursor = True
			''エラー情報を表示する(管理者用変更フラグに使用)
			'Me.C1FGridContents.ShowErrors = True

			'=====================================================================================
			'管理表
			'=====================================================================================
			'M番号コンボボックス
			strSQL = "SELECT T1.M番号, T2.M番号 FROM M_管理表 AS T1 INNER JOIN "
			strSQL &= "M_管理表 AS T2 ON T1.M番号 = T2.M番号 "
			strSQL &= "GROUP BY T1.M番号, T2.M番号 "
			strSQL &= "ORDER BY T1.M番号"
			dt = sqlProcess.DB_SELECT_DATATABLE(strSQL)

			SetComboValue(Me.cmbManageMNo, dt)
			Me.cmbManageMNo.SelectedIndex = 0
			'=====================================================================================
			'県名コンボボックス
			strSQL = "SELECT T1.都道府県名, T2.都道府県名 FROM M_都道府県 AS T1 INNER JOIN "
			strSQL &= "M_都道府県 AS T2 ON T1.都道府県番号 = T2.都道府県番号 "
			strSQL &= "ORDER BY T1.都道府県番号"
			dt = sqlProcess.DB_SELECT_DATATABLE(strSQL)

			SetComboValue(Me.cmbManagePrefecture, dt)
			Me.cmbManagePrefecture.SelectedIndex = 0
			'=====================================================================================
			'納品フォルダ名
			strSQL = "SELECT T1.納品フォルダ, T1.納品フォルダ FROM M_管理表 AS T1 INNER JOIN "
			strSQL &= "M_管理表 AS T2 ON T1.納品フォルダ = T2.納品フォルダ "
			strSQL &= "GROUP BY T1.納品フォルダ, T2.納品フォルダ "
			strSQL &= "ORDER BY T1.納品フォルダ"
			dt = sqlProcess.DB_SELECT_DATATABLE(strSQL)

			SetComboValue(Me.cmbManageDelivFolderName, dt)
			'オートコンプリート
			Me.cmbManageDelivFolderName.AutoCompleteMode = AutoCompleteMode.SuggestAppend
			Me.cmbManageDelivFolderName.AutoCompleteSource = AutoCompleteSource.ListItems
			Me.cmbManageDelivFolderName.SelectedIndex = 0
			'=====================================================================================
			'仮フォルダ
			strSQL = "SELECT T1.仮フォルダ, T2.仮フォルダ FROM M_管理表 AS T1 INNER JOIN "
			strSQL &= "M_管理表 AS T2 ON T1.仮フォルダ = T2.仮フォルダ "
			strSQL &= "GROUP BY T1.仮フォルダ, T2.仮フォルダ "
			strSQL &= "ORDER BY T1.仮フォルダ"
			dt = sqlProcess.DB_SELECT_DATATABLE(strSQL)

			SetComboValue(Me.cmbManageProvFolderName, dt)
			'オートコンプリート
			Me.cmbManageProvFolderName.AutoCompleteMode = AutoCompleteMode.SuggestAppend
			Me.cmbManageProvFolderName.AutoCompleteSource = AutoCompleteSource.ListItems
			Me.cmbManageProvFolderName.SelectedIndex = 0
			'=====================================================================================
			''フラグ
			'strSQL = "SELECT フラグID, フラグ FROM M_フラグ "
			'strSQL &= "WHERE 種別ID = 10 "
			'strSQL &= "ORDER BY フラグID"
			'dt = sqlProcess.DB_SELECT_DATATABLE(strSQL)

			'SetComboValue(Me.cmbManageFlag, dt)
			'Me.cmbManageFlag.SelectedIndex = 0

			'=====================================================================================
			'画像
			'=====================================================================================
			'M番号コンボボックス
			strSQL = "SELECT T1.M番号, T2.M番号 FROM M_管理表 AS T1 INNER JOIN "
			strSQL &= "M_管理表 AS T2 ON T1.M番号 = T2.M番号 "
			strSQL &= "GROUP BY T1.M番号, T2.M番号 "
			strSQL &= "ORDER BY T1.M番号"
			dt = sqlProcess.DB_SELECT_DATATABLE(strSQL)

			SetComboValue(Me.cmbImageMNo, dt)
			Me.cmbImageMNo.SelectedIndex = 0
			'=====================================================================================
			'県名コンボボックス
			strSQL = "SELECT T1.都道府県名, T2.都道府県名 FROM M_都道府県 AS T1 INNER JOIN "
			strSQL &= "M_都道府県 AS T2 ON T1.都道府県番号 = T2.都道府県番号 "
			strSQL &= "ORDER BY T1.都道府県番号"
			dt = sqlProcess.DB_SELECT_DATATABLE(strSQL)

			SetComboValue(Me.cmbImagePrefecture, dt)
			Me.cmbImagePrefecture.SelectedIndex = 0
			'=====================================================================================
			'フラグ
			strSQL = "SELECT フラグID, フラグ FROM M_フラグ "
			strSQL &= "WHERE 種別ID = 30 "
			strSQL &= "ORDER BY フラグID"
			dt = sqlProcess.DB_SELECT_DATATABLE(strSQL)

			SetComboValue(Me.cmbImageFlag, dt)
			Me.cmbImageFlag.SelectedIndex = 0
			'=====================================================================================

			'=====================================================================================
			'出力
			'=====================================================================================
			'イベントを殺す
			RemoveHandler cmbOutputPrefecture.SelectedIndexChanged, AddressOf cmbOutputPrefecture_SelectedIndexChanged
			RemoveHandler cmbOutputFlag.SelectedIndexChanged, AddressOf cmbOutputFlag_SelectedIndexChanged
			RemoveHandler cmbOutputUpdateFlag.SelectedIndexChanged, AddressOf cmbOutputUpdateFlag_SelectedIndexChanged

			'フラグ情報の取得
			InitializeOutput()
			'県名コンボボックス
			strSQL = "SELECT T1.都道府県名, T2.都道府県名 FROM M_都道府県 AS T1 INNER JOIN "
			strSQL &= "M_都道府県 AS T2 ON T1.都道府県番号 = T2.都道府県番号 "
			strSQL &= "ORDER BY T1.都道府県番号"
			dt = sqlProcess.DB_SELECT_DATATABLE(strSQL)

			SetComboValue(Me.cmbOutputPrefecture, dt)
			Me.cmbOutputPrefecture.SelectedIndex = 0
			'=====================================================================================
			'フラグ
			strSQL = "SELECT フラグID, フラグ FROM M_フラグ "
			strSQL &= "WHERE 種別ID = 20 "
			strSQL &= "ORDER BY フラグID"
			dt = sqlProcess.DB_SELECT_DATATABLE(strSQL)

			SetComboValue(Me.cmbOutputFlag, dt)
			Me.cmbOutputFlag.SelectedIndex = 0
			'=====================================================================================
			'変更フラグ
			strSQL = "SELECT フラグID, フラグ FROM M_フラグ "
			strSQL &= "WHERE 種別ID = 40 "
			strSQL &= "ORDER BY フラグID"
			dt = sqlProcess.DB_SELECT_DATATABLE(strSQL)

			SetComboValue(Me.cmbOutputUpdateFlag, dt)
			Me.cmbOutputUpdateFlag.SelectedIndex = 0
			'=====================================================================================

			'参照フォルダの取得
			Me.txtOutputSrcFolder.Text = XmlSettings.Instance.ImagePath
			Me.txtOutputFolder.Text = XmlSettings.Instance.OutputFolder

			'イベントを活性化
			AddHandler cmbOutputPrefecture.SelectedIndexChanged, AddressOf cmbOutputPrefecture_SelectedIndexChanged
			AddHandler cmbOutputFlag.SelectedIndexChanged, AddressOf cmbOutputFlag_SelectedIndexChanged
			AddHandler cmbOutputUpdateFlag.SelectedIndexChanged, AddressOf cmbOutputUpdateFlag_SelectedIndexChanged
			Me.cmbOutputPrefecture.SelectedIndex = 0

			'=====================================================================================
			'集計
			'=====================================================================================
			InitializeSummary()

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		Finally

			sqlProcess.Close()

		End Try
	End Sub

	''' <summary>
	''' ファイルテキストボックスドラッグエンター時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub txtFile_DragEnter(sender As Object, e As DragEventArgs) Handles txtContentsFile.DragEnter, txtManageFile.DragEnter
		'コントロール内にドラッグされた時実行される
		If e.Data.GetDataPresent(DataFormats.FileDrop) Then
			'ドラッグされたデータ形式を調べ、ファイルの時はコピーとする
			e.Effect = DragDropEffects.Copy
		Else
			'ファイル以外は受け付けない
			e.Effect = DragDropEffects.None
		End If

	End Sub

	''' <summary>
	''' ファイルテキストボックスドラッグドロップ時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub txtFile_DragDrop(sender As Object, e As DragEventArgs) Handles txtContentsFile.DragDrop, txtManageFile.DragDrop
		'コントロール内にドロップされた時実行される
		'ドロップされたファイル名を取得する
		Dim strFiles As String() = CType(e.Data.GetData(DataFormats.FileDrop, False), String())
		Dim txtFile As TextBox = CType(sender, TextBox)
		'第一要素をテキストボックスにセットする
		'CSVファイルのみ
		If System.IO.Path.GetExtension(strFiles(0)) = ".csv" Then

			txtFile.Text = strFiles(0)

		End If

	End Sub

	''' <summary>
	''' フォルダドラッグエンター時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub txtFolder_DragEnter(sender As Object, e As DragEventArgs) Handles txtOutputFolder.DragEnter, txtOutputSrcFolder.DragEnter
		'コントロール内にドラッグされた時実行される
		If e.Data.GetDataPresent(DataFormats.FileDrop) Then
			'ドラッグされたデータ形式を調べ、ファイルの時はコピーとする
			e.Effect = DragDropEffects.Copy
		Else
			'ファイル以外は受け付けない
			e.Effect = DragDropEffects.None
		End If

	End Sub

	''' <summary>
	''' フォルダドラッグドロップ時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub txtFolderDrop(sender As Object, e As DragEventArgs) Handles txtOutputFolder.DragDrop, txtOutputSrcFolder.DragDrop

		Dim strFolder As String() = CType(e.Data.GetData(DataFormats.FileDrop, False), String())
		Dim txtFolder As TextBox = CType(sender, TextBox)
		'第一要素をテキストボックスにセットする
		'フォルダが存在していたら
		If System.IO.Directory.Exists(strFolder(0)) Then

			txtFolder.Text = strFolder(0)

		End If

	End Sub

	''' <summary>
	''' 集計タブの初期化
	''' </summary>
	Private Sub InitializeSummary()

		Dim strSQL As String = ""
		Dim sqlProcess As New SQLProcess

		Try
			'セル結合
			Me.C1FGridSummary.Rows(0).AllowMerging = True   '行ヘッダのマージの許可※隣接したヘッダ名を同一文言にするとマージされる
			'Dim rng As C1.Win.C1FlexGrid.CellRange = Me.C1FGridSummary.GetCellRange(0, 1, 0, 2)
			'rng.Data = "Y01"

			'列ヘッダの作成
			Me.C1FGridSummary.Cols(0).AllowMerging = True
			Dim rng As C1.Win.C1FlexGrid.CellRange = Me.C1FGridSummary.GetCellRange(0, 0, 1, 0)
			rng.Data = "作業日／ユーザー"
			For i As Integer = 1 To Me.C1FGridSummary.Cols.Count - 1 Step 2
				Me.C1FGridSummary(1, i) = "ロット"
				Me.C1FGridSummary(1, i + 1) = "レコード"
			Next

			'進捗グリッドへのセット
			strSQL = "SELECT 'ロット' AS カテゴリ, COUNT(管理ID) AS 総数, "
			strSQL &= "SUM(CASE WHEN ISNULL(終了日時, '') != '1900/01/01' THEN 1 ELSE 0 END) AS 終了数, "
			strSQL &= "SUM(CASE WHEN ISNULL(終了日時, '') = '1900/01/01' THEN 1 ELSE 0 END) AS 残数, "
			strSQL &= "ROUND((CONVERT(FLOAT, SUM(CASE WHEN ISNULL(終了日時, '') != '1900/01/01' THEN 1 ELSE 0 END)) / CONVERT(FLOAT, COUNT(管理ID))) * 100, 1) AS 進捗率 "
			strSQL &= "FROM M_管理表 UNION ALL ("
			strSQL &= "SELECT 'イメージ' AS カテゴリ, SUM(スキャン) AS 総数, "
			strSQL &= "SUM(CASE WHEN ISNULL(終了日時, '') != '1900/01/01' THEN スキャン ELSE 0 END) AS 終了数, "
			strSQL &= "SUM(CASE WHEN ISNULL(終了日時, '') = '1900/01/01' THEN スキャン ELSE 0 END) AS 残数, "
			strSQL &= "ROUND((CONVERT(FLOAT, SUM(CASE WHEN ISNULL(終了日時, '') != '1900/01/01' THEN スキャン ELSE 0 END)) / CONVERT(FLOAT, SUM(スキャン))) * 100, 1) AS 進捗率 "
			strSQL &= "FROM M_管理表) UNION ALL ("
			strSQL &= "SELECT 'レコード' AS カテゴリ, SUM(T2.カウント) AS 総数, "
			strSQL &= "SUM(CASE WHEN ISNULL(T1.終了日時, '') != '1900/01/01' THEN T2.カウント ELSE 0 END) AS 終了数, "
			strSQL &= "SUM(CASE WHEN ISNULL(T1.終了日時, '') = '1900/01/01' THEN T2.カウント ELSE 0 END) AS 残数, "
			strSQL &= "ROUND((CONVERT(FLOAT, SUM(CASE WHEN ISNULL(T1.終了日時, '') != '1900/01/01' THEN T2.カウント ELSE 0 END)) / CONVERT(FLOAT, SUM(T2.カウント))) * 100, 1) AS 進捗率 "
			strSQL &= "FROM M_管理表 AS T1 INNER JOIN "
			strSQL &= "(SELECT 管理ID, COUNT(管理ID) AS カウント FROM T_目次 GROUP BY 管理ID) AS T2 ON T1.管理ID = T2.管理ID)"
			Dim dt As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)

			For iRow As Integer = 0 To dt.Rows.Count - 1
				Me.C1FGridProgress(iRow + 1, "カテゴリ") = dt.Rows(iRow)("カテゴリ")
				Me.C1FGridProgress(iRow + 1, "総数") = dt.Rows(iRow)("総数")
				Me.C1FGridProgress(iRow + 1, "終了数") = dt.Rows(iRow)("終了数")
				Me.C1FGridProgress(iRow + 1, "残数") = dt.Rows(iRow)("残数")
				Me.C1FGridProgress(iRow + 1, "進捗率") = dt.Rows(iRow)("進捗率")
			Next

			'総進捗率を表示
			Dim dblAvg As Double = Math.Round((CDbl(Me.C1FGridProgress(1, "進捗率")) + CDbl(Me.C1FGridProgress(2, "進捗率")) + CDbl(Me.C1FGridProgress(3, "進捗率"))) / 3, 1)
			Me.lblProgress.Text = dblAvg.ToString & "%"

			'作業日／ユーザー単位の実績表示
			strSQL = "SELECT A1.作業日, "
			strSQL &= "SUM(CASE WHEN A1.処理ユーザー = 'ユーザー01' THEN 1 ELSE 0 END) AS Y01ロット, "
			strSQL &= "SUM(CASE WHEN A1.処理ユーザー = 'ユーザー01' THEN A1.レコード ELSE 0 END) AS Y01レコード, "
			strSQL &= "SUM(CASE WHEN A1.処理ユーザー = 'ユーザー02' THEN 1 ELSE 0 END) AS Y02ロット, "
			strSQL &= "SUM(CASE WHEN A1.処理ユーザー = 'ユーザー02' THEN A1.レコード ELSE 0 END) AS Y02レコード, "
			strSQL &= "SUM(CASE WHEN A1.処理ユーザー = 'ユーザー03' THEN 1 ELSE 0 END) AS Y03ロット, "
			strSQL &= "SUM(CASE WHEN A1.処理ユーザー = 'ユーザー03' THEN A1.レコード ELSE 0 END) AS Y03レコード, "
			strSQL &= "SUM(CASE WHEN A1.処理ユーザー = 'ユーザー04' THEN 1 ELSE 0 END) AS Y04ロット, "
			strSQL &= "SUM(CASE WHEN A1.処理ユーザー = 'ユーザー04' THEN A1.レコード ELSE 0 END) AS Y04レコード, "
			strSQL &= "SUM(CASE WHEN A1.処理ユーザー = 'ユーザー05' THEN 1 ELSE 0 END) AS Y05ロット, "
			strSQL &= "SUM(CASE WHEN A1.処理ユーザー = 'ユーザー05' THEN A1.レコード ELSE 0 END) AS Y05レコード, "
			strSQL &= "SUM(CASE WHEN A1.処理ユーザー = 'ユーザー06' THEN 1 ELSE 0 END) AS Y06ロット, "
			strSQL &= "SUM(CASE WHEN A1.処理ユーザー = 'ユーザー06' THEN A1.レコード ELSE 0 END) AS Y06レコード, "
			strSQL &= "SUM(CASE WHEN A1.処理ユーザー = 'ユーザー07' THEN 1 ELSE 0 END) AS Y07ロット, "
			strSQL &= "SUM(CASE WHEN A1.処理ユーザー = 'ユーザー07' THEN A1.レコード ELSE 0 END) AS Y07レコード, "
			strSQL &= "SUM(CASE WHEN A1.処理ユーザー = 'ユーザー08' THEN 1 ELSE 0 END) AS Y08ロット, "
			strSQL &= "SUM(CASE WHEN A1.処理ユーザー = 'ユーザー08' THEN A1.レコード ELSE 0 END) AS Y08レコード, "
			strSQL &= "SUM(CASE WHEN A1.処理ユーザー = 'ユーザー09' THEN 1 ELSE 0 END) AS Y09ロット, "
			strSQL &= "SUM(CASE WHEN A1.処理ユーザー = 'ユーザー09' THEN A1.レコード ELSE 0 END) AS Y09レコード, "
			strSQL &= "SUM(CASE WHEN A1.処理ユーザー = 'ユーザー10' THEN 1 ELSE 0 END) AS Y10ロット, "
			strSQL &= "SUM(CASE WHEN A1.処理ユーザー = 'ユーザー10' THEN A1.レコード ELSE 0 END) AS Y10レコード, "
			strSQL &= "SUM(CASE WHEN A1.処理ユーザー = 'ユーザー11' THEN 1 ELSE 0 END) AS Y11ロット, "
			strSQL &= "SUM(CASE WHEN A1.処理ユーザー = 'ユーザー11' THEN A1.レコード ELSE 0 END) AS Y11レコード, "
			strSQL &= "SUM(CASE WHEN A1.処理ユーザー = 'ユーザー12' THEN 1 ELSE 0 END) AS Y12ロット, "
			strSQL &= "SUM(CASE WHEN A1.処理ユーザー = 'ユーザー12' THEN A1.レコード ELSE 0 END) AS Y12レコード, "
			strSQL &= "SUM(CASE WHEN A1.処理ユーザー = 'ユーザー13' THEN 1 ELSE 0 END) AS Y13ロット, "
			strSQL &= "SUM(CASE WHEN A1.処理ユーザー = 'ユーザー13' THEN A1.レコード ELSE 0 END) AS Y13レコード, "
			strSQL &= "SUM(CASE WHEN A1.処理ユーザー = 'ユーザー14' THEN 1 ELSE 0 END) AS Y14ロット, "
			strSQL &= "SUM(CASE WHEN A1.処理ユーザー = 'ユーザー14' THEN A1.レコード ELSE 0 END) AS Y14レコード, "
			strSQL &= "SUM(CASE WHEN A1.処理ユーザー = 'ユーザー15' THEN 1 ELSE 0 END) AS Y15ロット, "
			strSQL &= "SUM(CASE WHEN A1.処理ユーザー = 'ユーザー15' THEN A1.レコード ELSE 0 END) AS Y15レコード, "
			strSQL &= "SUM(CASE WHEN A1.処理ユーザー = 'ユーザー16' THEN 1 ELSE 0 END) AS Y16ロット, "
			strSQL &= "SUM(CASE WHEN A1.処理ユーザー = 'ユーザー16' THEN A1.レコード ELSE 0 END) AS Y16レコード, "
			strSQL &= "SUM(CASE WHEN A1.処理ユーザー = 'ユーザー17' THEN 1 ELSE 0 END) AS Y17ロット, "
			strSQL &= "SUM(CASE WHEN A1.処理ユーザー = 'ユーザー17' THEN A1.レコード ELSE 0 END) AS Y17レコード, "
			strSQL &= "SUM(CASE WHEN A1.処理ユーザー = 'ユーザー18' THEN 1 ELSE 0 END) AS Y18ロット, "
			strSQL &= "SUM(CASE WHEN A1.処理ユーザー = 'ユーザー18' THEN A1.レコード ELSE 0 END) AS Y18レコード, "
			strSQL &= "SUM(CASE WHEN A1.処理ユーザー = 'ユーザー19' THEN 1 ELSE 0 END) AS Y19ロット, "
			strSQL &= "SUM(CASE WHEN A1.処理ユーザー = 'ユーザー19' THEN A1.レコード ELSE 0 END) AS Y19レコード, "
			strSQL &= "SUM(CASE WHEN A1.処理ユーザー = 'ユーザー20' THEN 1 ELSE 0 END) AS Y20ロット, "
			strSQL &= "SUM(CASE WHEN A1.処理ユーザー = 'ユーザー20' THEN A1.レコード ELSE 0 END) AS Y20レコード "
			strSQL &= "FROM (SELECT T1.管理ID, T1.処理ユーザー, CONVERT(VARCHAR(20), T1.終了日時, 111) AS 作業日, "
			strSQL &= "COUNT(T2.管理ID) AS レコード "
			strSQL &= "FROM M_管理表 AS T1 INNER JOIN "
			strSQL &= "T_目次 AS T2 ON T1.管理ID = T2.管理ID "
			strSQL &= "WHERE ISNULL(T1.処理ユーザー, '') != '' "
			strSQL &= "AND ISNULL(T1.終了日時, '') != '1900/01/01' "
			strSQL &= "GROUP BY T1.管理ID, T1.処理ユーザー, CONVERT(VARCHAR(20), T1.終了日時, 111), T1.スキャン, T2.管理ID "
			strSQL &= ") AS A1 "
			strSQL &= "GROUP BY A1.作業日 "
			strSQL &= "ORDER BY A1.作業日"
			dt = sqlProcess.DB_SELECT_DATATABLE(strSQL)

			Me.C1FGridSummary.Rows.Count = dt.Rows.Count + 2    'ヘッダ行が2レコードあるため＋２
			For iRow As Integer = 0 To dt.Rows.Count - 1
				Me.C1FGridSummary(iRow + 2, "作業日") = dt.Rows(iRow)("作業日")
				Me.C1FGridSummary(iRow + 2, "Y01ロット") = dt.Rows(iRow)("Y01ロット")
				Me.C1FGridSummary(iRow + 2, "Y01レコード") = dt.Rows(iRow)("Y01レコード")
				Me.C1FGridSummary(iRow + 2, "Y02ロット") = dt.Rows(iRow)("Y02ロット")
				Me.C1FGridSummary(iRow + 2, "Y02レコード") = dt.Rows(iRow)("Y02レコード")
				Me.C1FGridSummary(iRow + 2, "Y03ロット") = dt.Rows(iRow)("Y03ロット")
				Me.C1FGridSummary(iRow + 2, "Y03レコード") = dt.Rows(iRow)("Y03レコード")
				Me.C1FGridSummary(iRow + 2, "Y04ロット") = dt.Rows(iRow)("Y04ロット")
				Me.C1FGridSummary(iRow + 2, "Y04レコード") = dt.Rows(iRow)("Y04レコード")
				Me.C1FGridSummary(iRow + 2, "Y05ロット") = dt.Rows(iRow)("Y05ロット")
				Me.C1FGridSummary(iRow + 2, "Y05レコード") = dt.Rows(iRow)("Y05レコード")
				Me.C1FGridSummary(iRow + 2, "Y06ロット") = dt.Rows(iRow)("Y06ロット")
				Me.C1FGridSummary(iRow + 2, "Y06レコード") = dt.Rows(iRow)("Y06レコード")
				Me.C1FGridSummary(iRow + 2, "Y07ロット") = dt.Rows(iRow)("Y07ロット")
				Me.C1FGridSummary(iRow + 2, "Y07レコード") = dt.Rows(iRow)("Y07レコード")
				Me.C1FGridSummary(iRow + 2, "Y08ロット") = dt.Rows(iRow)("Y08ロット")
				Me.C1FGridSummary(iRow + 2, "Y08レコード") = dt.Rows(iRow)("Y08レコード")
				Me.C1FGridSummary(iRow + 2, "Y09ロット") = dt.Rows(iRow)("Y09ロット")
				Me.C1FGridSummary(iRow + 2, "Y09レコード") = dt.Rows(iRow)("Y09レコード")
				Me.C1FGridSummary(iRow + 2, "Y10ロット") = dt.Rows(iRow)("Y10ロット")
				Me.C1FGridSummary(iRow + 2, "Y10レコード") = dt.Rows(iRow)("Y10レコード")
				Me.C1FGridSummary(iRow + 2, "Y11ロット") = dt.Rows(iRow)("Y11ロット")
				Me.C1FGridSummary(iRow + 2, "Y11レコード") = dt.Rows(iRow)("Y11レコード")
				Me.C1FGridSummary(iRow + 2, "Y12ロット") = dt.Rows(iRow)("Y12ロット")
				Me.C1FGridSummary(iRow + 2, "Y12レコード") = dt.Rows(iRow)("Y12レコード")
				Me.C1FGridSummary(iRow + 2, "Y13ロット") = dt.Rows(iRow)("Y13ロット")
				Me.C1FGridSummary(iRow + 2, "Y13レコード") = dt.Rows(iRow)("Y13レコード")
				Me.C1FGridSummary(iRow + 2, "Y14ロット") = dt.Rows(iRow)("Y14ロット")
				Me.C1FGridSummary(iRow + 2, "Y14レコード") = dt.Rows(iRow)("Y14レコード")
				Me.C1FGridSummary(iRow + 2, "Y15ロット") = dt.Rows(iRow)("Y15ロット")
				Me.C1FGridSummary(iRow + 2, "Y15レコード") = dt.Rows(iRow)("Y15レコード")
				Me.C1FGridSummary(iRow + 2, "Y16ロット") = dt.Rows(iRow)("Y16ロット")
				Me.C1FGridSummary(iRow + 2, "Y16レコード") = dt.Rows(iRow)("Y16レコード")
				Me.C1FGridSummary(iRow + 2, "Y17ロット") = dt.Rows(iRow)("Y17ロット")
				Me.C1FGridSummary(iRow + 2, "Y17レコード") = dt.Rows(iRow)("Y17レコード")
				Me.C1FGridSummary(iRow + 2, "Y18ロット") = dt.Rows(iRow)("Y18ロット")
				Me.C1FGridSummary(iRow + 2, "Y18レコード") = dt.Rows(iRow)("Y18レコード")
				Me.C1FGridSummary(iRow + 2, "Y19ロット") = dt.Rows(iRow)("Y19ロット")
				Me.C1FGridSummary(iRow + 2, "Y19レコード") = dt.Rows(iRow)("Y19レコード")
				Me.C1FGridSummary(iRow + 2, "Y20ロット") = dt.Rows(iRow)("Y20ロット")
				Me.C1FGridSummary(iRow + 2, "Y20レコード") = dt.Rows(iRow)("Y20レコード")

			Next

			'その日の合計値
			For iRow As Integer = 2 To Me.C1FGridSummary.Rows.Count - 1

				'集計グリッド内の合計と進捗率の表示
				Dim iTotalLot As Integer = 0
				Dim iTotalRecord As Integer = 0

				For iCol As Integer = 5 To Me.C1FGridSummary.Cols.Count - 1 Step 2
					iTotalLot += Me.C1FGridSummary(iRow, iCol)  'ロット
					iTotalRecord += Me.C1FGridSummary(iRow, iCol + 1)   'レコード
				Next

				Me.C1FGridSummary(iRow, "合計ロット") = iTotalLot
				Me.C1FGridSummary(iRow, "合計レコード") = iTotalRecord
				'全体に対するその日の進捗率
				Me.C1FGridSummary(iRow, "進捗率ロット") = Math.Round(iTotalLot / Me.C1FGridProgress(1, "総数") * 100, 1)
				Me.C1FGridSummary(iRow, "進捗率レコード") = Math.Round(iTotalRecord / Me.C1FGridProgress(3, "総数") * 100, 1)
			Next

			'合計を表示する
			'合計のスタイルを設定する
			Dim cs As CellStyle
			cs = Me.C1FGridSummary.Styles(CellStyleEnum.GrandTotal)
			cs.BackColor = Color.Beige
			cs.ForeColor = Color.Black

			'規定の合計をクリアする
			Me.C1FGridSummary.Subtotal(AggregateEnum.Clear)
			'全ての項目の合計を行うためカラム数で回す
			For iCol As Integer = 1 To Me.C1FGridSummary.Cols.Count - 1
				Me.C1FGridSummary.Subtotal(AggregateEnum.Sum, -1, -1, iCol, "合計")
			Next
			Me.C1FGridSummary(Me.C1FGridSummary.Rows.Count - 1, 0) = "合計"

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		Finally

			sqlProcess.Close()

		End Try

	End Sub

	''' <summary>
	''' 目次データ検索時
	''' </summary>
	Private Sub ContentsSearch()

		'納品フォルダチェック
		If Me.cmbContentsDelivFolderName.SelectedIndex < 0 Then
			MessageBox.Show("該当する納品フォルダがリストに存在しません", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Exit Sub
		End If
		'仮フォルダチェック
		If Me.cmbContentsProvFolderName.SelectedIndex < 0 Then
			MessageBox.Show("該当する仮フォルダがリストに存在しません", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Exit Sub
		End If

		Dim strSQL As String = ""
		Dim sqlProcess As New SQLProcess
		Dim strWhere As String = " WHERE "
		Me.C1FGridContents.Rows.Count = 1

		Try
			'strSQL = "SELECT T1.管理ID, T1.連番, T1.レコード番号, T1.表示用, T1.行番号, T1.県名, T1.資料名, T1.副題, T1.対象年, T1.刊行者名, T1.刊行年月, "
			'strSQL &= "T1.分類1, T1.分類2, T1.分類番号, T1.項目, T1.番号1, T1.タイトル1, T1.番号2, T1.タイトル2, T1.番号3, T1.タイトル3, "
			'strSQL &= "T1.番号4, T1.タイトル4, T1.番号5, T1.タイトル5, T1.フォルダ名, T1.リンク, T1.リンクTO, T1.備考, T1.フラグID, T2.フラグ "
			'strSQL &= "FROM T_目次 AS T1 INNER JOIN "
			'strSQL &= "M_フラグ AS T2 ON T1.フラグID = T2.フラグID INNER JOIN "
			'strSQL &= "M_管理表 AS T3 ON T1.管理ID = T3.管理ID "
			'strSQL &= "WHERE T2.種別ID = 20 "

			'strSQL = "SELECT A1.管理ID, A1.連番, A4.仮フォルダ, A4.納品フォルダ, A1.レコード番号, A1.表示用, A1.行番号, A1.県名, A1.資料名, A1.副題, A1.対象年, "
			'strSQL &= "A1.刊行者名, A1.刊行年月, A1.分類1, A1.分類2, A1.分類番号, A1.項目, "
			'strSQL &= "A1.番号1, A1.タイトル1, A1.番号2, A1.タイトル2, A1.番号3, A1.タイトル3, A1.番号4, A1.タイトル4, A1.番号5, A1.タイトル5, "
			'strSQL &= "A1.フォルダ名, A1.リンク, A1.リンクTO, A1.備考, A1.フラグID, A3.フラグ, ISNULL(A2.フラグ, '') AS 変更 "
			'strSQL &= "FROM T_目次 AS A1 LEFT OUTER JOIN "
			'strSQL &= "(SELECT T1.管理ID, T1.連番, T1.フラグID, T2.フラグ "
			'strSQL &= "FROM T_フラグ AS T1 INNER JOIN "
			'strSQL &= "M_フラグ AS T2 ON T1.種別ID = T2.種別ID AND T1.フラグID = T2.フラグID "
			'strSQL &= "WHERE T1.種別ID = 40 "
			'strSQL &= ") AS A2 ON A1.管理ID = A2.管理ID AND A1.連番 = A2.連番 INNER JOIN "
			'strSQL &= "M_フラグ AS A3 ON A3.種別ID = 20 AND A1.フラグID = A3.フラグID INNER JOIN "
			'strSQL &= "M_管理表 AS A4 ON A1.管理ID = A4.管理ID "

			'2017/04/24
			'管理者確認フラグの追加
			strSQL = "SELECT A1.管理ID, A1.連番, A4.仮フォルダ, A4.納品フォルダ, A1.レコード番号, A1.表示用, A1.行番号, A1.県名, A1.資料名, "
			strSQL &= "A1.副題, A1.対象年, A1.刊行者名, A1.刊行年月, A1.分類1, A1.分類2, A1.分類番号, A1.項目, A1.番号1, A1.タイトル1, "
			strSQL &= "A1.番号2, A1.タイトル2, A1.番号3, A1.タイトル3, A1.番号4, A1.タイトル4, A1.番号5, A1.タイトル5, "
			strSQL &= "A1.フォルダ名, A1.リンク, A1.リンクTO, A1.備考, A1.フラグID, A3.フラグ, ISNULL(A2.フラグ, '') AS 変更, "
			strSQL &= "ISNULL(A5.管理者確認, 0) AS 確認 "
			strSQL &= "FROM T_目次 AS A1 LEFT OUTER JOIN "
			strSQL &= "(SELECT T1.管理ID, T1.連番, T1.フラグID, T2.フラグ "
			strSQL &= "FROM T_フラグ AS T1 INNER JOIN "
			strSQL &= "M_フラグ AS T2 ON T1.種別ID = T2.種別ID AND T1.フラグID = T2.フラグID "
			strSQL &= "WHERE (T1.種別ID = 40) "
			strSQL &= ") AS A2 ON A1.管理ID = A2.管理ID AND A1.連番 = A2.連番 INNER JOIN "
			strSQL &= "M_フラグ AS A3 ON A3.種別ID = 20 AND A1.フラグID = A3.フラグID INNER JOIN "
			strSQL &= "M_管理表 AS A4 ON A1.管理ID = A4.管理ID LEFT OUTER JOIN "
			strSQL &= "T_フラグ AS A5 ON A1.管理ID = A5.管理ID AND A1.連番 = A5.連番 "
			'strWhere = " AND "

			'納品フォルダ名
			If Me.cmbContentsDelivFolderName.SelectedIndex > 0 Then
				strSQL &= strWhere & "A4.納品フォルダ LIKE '%" & Me.cmbContentsDelivFolderName.SelectedValue & "%' "
				strWhere = " AND "
			End If
			'仮フォルダ
			If Me.cmbContentsProvFolderName.SelectedIndex > 0 Then
				strSQL &= strWhere & "A4.仮フォルダ LIKE '%" & Me.cmbContentsProvFolderName.SelectedValue & "%' "
				strWhere = " AND "
			End If
			'県名
			If Me.cmbContentsPrefecture.SelectedIndex > 0 Then
				strSQL &= strWhere & "A4.県名 LIKE '%" & Me.cmbContentsPrefecture.SelectedValue & "%' "
				strWhere = " AND "
			End If
			'対象年
			If Me.cmbContentsTargetYear.SelectedIndex > 0 Then
				strSQL &= strWhere & "A1.対象年 = '" & Me.cmbContentsTargetYear.SelectedValue & "' "
				strWhere = " AND "
			End If
			'資料名
			If Not IsNull(Me.txtContentsDocumentName.Text) Then
				strSQL &= strWhere & "A1.資料名 LIKE '%" & Me.txtContentsDocumentName.Text & "' "
				strWhere = " AND "
			End If
			'副題
			If Not IsNull(Me.txtContentsSubTitle.Text) Then
				strSQL &= strWhere & "A1.副題 LIKE '%" & Me.txtContentsSubTitle.Text & "' "
				strWhere = " AND "
			End If
			'フラグ
			If Me.cmbContentsFlag.SelectedIndex > 0 Then
				strSQL &= strWhere & "A1.フラグID = " & Me.cmbContentsFlag.SelectedValue & " "
				strWhere = " AND "
			End If
			'変更フラグ
			If Me.cmbContentsUpdateFlag.SelectedIndex > 0 Then

				If Me.cmbContentsUpdateFlag.SelectedItem.ToString = "変更あり" Then
					strSQL &= strWhere & "A2.フラグID = 1 "
				Else
					strSQL &= strWhere & "A2.フラグID = 0 "
				End If
				strWhere = " AND "
			End If
			'確認フラグ
			If Me.cmbContentsConfirm.SelectedIndex > 0 Then

				If Me.cmbContentsConfirm.SelectedItem.ToString = "確認済" Then
					strSQL &= strWhere & "A5.管理者確認 = 1 "
				Else
					strSQL &= strWhere & "A5.管理者確認 = 0 "
				End If
				strWhere = " AND "
			End If

			strSQL &= "ORDER BY A1.管理ID, A1.連番"
			Dim dt As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)

			Dim iRecordCount As Integer = 0

			Me.C1FGridContents.BeginUpdate()
			Me.C1FGridContents.Rows.Count = dt.Rows.Count + 1

			For iRow As Integer = 0 To dt.Rows.Count - 1
				iRecordCount += 1
				Me.C1FGridContents(iRecordCount, "No") = iRecordCount
				Me.C1FGridContents(iRecordCount, "管理ID") = dt.Rows(iRow)("管理ID")
				Me.C1FGridContents(iRecordCount, "連番") = dt.Rows(iRow)("連番")
				Me.C1FGridContents(iRecordCount, "仮フォルダ") = dt.Rows(iRow)("仮フォルダ")
				Me.C1FGridContents(iRecordCount, "納品フォルダ") = dt.Rows(iRow)("納品フォルダ")
				Me.C1FGridContents(iRecordCount, "レコード番号") = dt.Rows(iRow)("レコード番号")
				Me.C1FGridContents(iRecordCount, "表示用") = dt.Rows(iRow)("表示用")
				Me.C1FGridContents(iRecordCount, "行番号") = dt.Rows(iRow)("行番号")
				Me.C1FGridContents(iRecordCount, "県名") = dt.Rows(iRow)("県名")
				Me.C1FGridContents(iRecordCount, "資料名") = dt.Rows(iRow)("資料名")
				Me.C1FGridContents(iRecordCount, "副題") = dt.Rows(iRow)("副題")
				Me.C1FGridContents(iRecordCount, "対象年") = dt.Rows(iRow)("対象年")
				Me.C1FGridContents(iRecordCount, "刊行者名") = dt.Rows(iRow)("刊行者名")
				Me.C1FGridContents(iRecordCount, "刊行年月") = dt.Rows(iRow)("刊行年月")
				Me.C1FGridContents(iRecordCount, "分類1") = dt.Rows(iRow)("分類1")
				Me.C1FGridContents(iRecordCount, "分類2") = dt.Rows(iRow)("分類2")
				Me.C1FGridContents(iRecordCount, "分類番号") = dt.Rows(iRow)("分類番号")
				Me.C1FGridContents(iRecordCount, "項目") = dt.Rows(iRow)("項目")
				Me.C1FGridContents(iRecordCount, "番号1") = dt.Rows(iRow)("番号1")
				Me.C1FGridContents(iRecordCount, "タイトル1") = dt.Rows(iRow)("タイトル1")
				Me.C1FGridContents(iRecordCount, "番号2") = dt.Rows(iRow)("番号2")
				Me.C1FGridContents(iRecordCount, "タイトル2") = dt.Rows(iRow)("タイトル2")
				Me.C1FGridContents(iRecordCount, "番号3") = dt.Rows(iRow)("番号3")
				Me.C1FGridContents(iRecordCount, "タイトル3") = dt.Rows(iRow)("タイトル3")
				Me.C1FGridContents(iRecordCount, "番号4") = dt.Rows(iRow)("番号4")
				Me.C1FGridContents(iRecordCount, "タイトル4") = dt.Rows(iRow)("タイトル4")
				Me.C1FGridContents(iRecordCount, "番号5") = dt.Rows(iRow)("番号5")
				Me.C1FGridContents(iRecordCount, "タイトル5") = dt.Rows(iRow)("タイトル5")
				Me.C1FGridContents(iRecordCount, "フォルダ名") = dt.Rows(iRow)("フォルダ名")
				Me.C1FGridContents(iRecordCount, "リンク") = dt.Rows(iRow)("リンク")
				Me.C1FGridContents(iRecordCount, "リンクTO") = dt.Rows(iRow)("リンクTO")
				Me.C1FGridContents(iRecordCount, "備考") = dt.Rows(iRow)("備考")
				Me.C1FGridContents(iRecordCount, "フラグID") = dt.Rows(iRow)("フラグID")
				Me.C1FGridContents(iRecordCount, "フラグ") = dt.Rows(iRow)("フラグ")
				Me.C1FGridContents(iRecordCount, "変更") = dt.Rows(iRow)("変更")
				Me.C1FGridContents(iRecordCount, "確認") = dt.Rows(iRow)("確認")
				'条件によって背景色を変更する
				If (Me.C1FGridContents(iRecordCount, "フラグID") <> 0 Or IsNull(Me.C1FGridContents(iRecordCount, "変更")) = False) And Me.C1FGridContents(iRecordCount, "確認") = False Then
					'いずれかのフラグが立っており、確認がされていないものをリンク色
					LinkPasteProcess.ChangeBackColor(Me.C1FGridContents, iRecordCount, LinkPasteProcess.GridStyleName.StyleLink)
				ElseIf Me.C1FGridContents(iRecordCount, "確認") = True Then
					'確認済みのものをターゲット色
					LinkPasteProcess.ChangeBackColor(Me.C1FGridContents, iRecordCount, LinkPasteProcess.GridStyleName.StyleFinish)
				Else
					'デフォルト
					LinkPasteProcess.ChangeBackColor(Me.C1FGridContents, iRecordCount, LinkPasteProcess.GridStyleName.StyleDefault)
				End If
			Next
			Me.C1FGridContents.EndUpdate()

			'Me.C1FGridContents.DataSource = dt
			Me.C1FGridContents.AutoSizeCols()

			'For iRow As Integer = 1 To Me.C1FGridContents.Rows.Count - 1
			'	Me.C1FGridContents(iRow, "No") = iRow
			'Next

			If Me.C1FGridContents.Rows.Count > 1 Then
				Me.C1FGridContents.Row = 1
			End If

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		Finally

			sqlProcess.Close()

		End Try

	End Sub

	''' <summary>
	''' 画像タブ検索
	''' </summary>
	Private Sub ImageSearch()

		Dim strSQL As String = ""
		Dim sqlProcess As New SQLProcess
		Dim strWhere As String = " WHERE "

		Try
			strSQL = "SELECT T1.管理ID, T1.M番号, T1.県名, T1.仮フォルダ, T1.納品フォルダ, T1.エクセルファイル名, "
			strSQL &= "T2.ファイル名, T3.フラグ, T1.備考, T2.管理者確認 "
			strSQL &= "FROM M_管理表 AS T1 INNER JOIN "
			strSQL &= "T_フラグ AS T2 ON T1.管理ID = T2.管理ID INNER JOIN "
			strSQL &= "M_フラグ AS T3 ON T2.種別ID = T3.種別ID AND T2.フラグID = T3.フラグID "
			strSQL &= "WHERE T2.種別ID = 30 "
			strWhere = " AND "

			'M番号 
			If Me.cmbImageMNo.SelectedIndex > 0 Then
				strSQL &= strWhere & "T1.M番号 = '" & Me.cmbImageMNo.SelectedValue & "' "
				strWhere = " AND "
			End If
			'県名
			If Me.cmbImagePrefecture.SelectedIndex > 0 Then
				strSQL &= strWhere & "T1.県名 LIKE '%" & Me.cmbImagePrefecture.SelectedValue & "%' "
				strWhere = " AND "
			End If
			''仮フォルダ
			'If Me.cmbManageProvFolderName.SelectedIndex > 0 Then
			'	strSQL &= strWhere & "仮フォルダ LIKE '%" & Me.cmbManageProvFolderName.SelectedValue & "%' "
			'	strWhere = " AND "
			'End If
			''納品フォルダ
			'If Me.cmbManageDelivFolderName.SelectedIndex > 0 Then
			'	strSQL &= strWhere & "納品フォルダ LIKE '%" & Me.cmbManageDelivFolderName.SelectedValue & "%' "
			'	strWhere = " AND "
			'End If
			'エクセルファイル名
			If Not IsNull(Me.txtImageExcelName.Text) Then
				strSQL &= strWhere & "T1.エクセルファイル名 LIKE '%" & Me.txtImageExcelName.Text & "%' "
				strWhere = " AND "
			End If
			'フラグ
			If Me.cmbImageFlag.SelectedIndex > 0 Then
				strSQL &= strWhere & "T2.フラグID = " & Me.cmbImageFlag.SelectedValue & " "
			End If
			strSQL &= "ORDER BY T1.仮フォルダ, T2.ファイル名"
			Dim dt As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)

			Dim iRecordCount As Integer = 0

			Me.C1FGridImage.BeginUpdate()
			Me.C1FGridImage.Rows.Count = dt.Rows.Count + 1

			For iRow As Integer = 0 To dt.Rows.Count - 1
				iRecordCount += 1
				Me.C1FGridImage(iRecordCount, "No") = iRecordCount
				Me.C1FGridImage(iRecordCount, "管理ID") = dt.Rows(iRow)("管理ID")
				Me.C1FGridImage(iRecordCount, "M番号") = dt.Rows(iRow)("M番号")
				Me.C1FGridImage(iRecordCount, "県名") = dt.Rows(iRow)("県名")
				Me.C1FGridImage(iRecordCount, "仮フォルダ") = dt.Rows(iRow)("仮フォルダ")
				Me.C1FGridImage(iRecordCount, "納品フォルダ") = dt.Rows(iRow)("納品フォルダ")
				Me.C1FGridImage(iRecordCount, "エクセルファイル名") = dt.Rows(iRow)("エクセルファイル名")
				Me.C1FGridImage(iRecordCount, "ファイル名") = dt.Rows(iRow)("ファイル名")
				Me.C1FGridImage(iRecordCount, "フラグ") = dt.Rows(iRow)("フラグ")
				Me.C1FGridImage(iRecordCount, "備考") = dt.Rows(iRow)("備考")
				Me.C1FGridImage(iRecordCount, "確認") = IIf(dt.Rows(iRow)("管理者確認") = 0, False, True)
				'確認済みか否かによって背景色を変更する
				If Me.C1FGridImage(iRecordCount, "確認") = True Then
					LinkPasteProcess.ChangeBackColor(Me.C1FGridImage, iRecordCount, LinkPasteProcess.GridStyleName.StyleFinish)
				Else
					LinkPasteProcess.ChangeBackColor(Me.C1FGridImage, iRecordCount, LinkPasteProcess.GridStyleName.StyleDefault)
				End If
			Next
			Me.C1FGridImage.EndUpdate()

			Me.C1FGridImage.AutoSizeCols()

			If Me.C1FGridImage.Rows.Count > 1 Then
				Me.C1FGridImage.Row = 1
			End If

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		Finally

			sqlProcess.Close()

		End Try

	End Sub

	''' <summary>
	''' フラグ集計更新
	''' </summary>
	Private Sub OutputUpdate()

		Dim strSQL As String = ""
		Dim sqlProcess As New SQLProcess
		Me.C1FGridOutput.Rows.Count = 1

		Try
			strSQL = "SELECT CASE WHEN T1.種別ID = 20 OR T1.種別ID = 40 THEN 1 ELSE 2 END AS 種別連番, "
			strSQL &= "CASE WHEN T1.種別ID　=20 OR T1.種別ID = 40 THEN '目次' ELSE '画像' END AS 種別, "
			strSQL &= "T2.フラグ, "
			strSQL &= "COUNT(T1.フラグID) AS フラグ数, "
			strSQL &= "SUM(CASE WHEN T1.管理者確認 = 1 THEN 1 ELSE 0 END) AS 確認数, "
			strSQL &= "COUNT(T1.フラグID) - SUM(CASE WHEN T1.管理者確認 = 1 THEN 1 ELSE 0 END) AS 残数, "
			strSQL &= "T1.種別ID, T1.フラグID "
			strSQL &= "FROM T_フラグ AS T1 INNER JOIN "
			strSQL &= "M_フラグ AS T2 ON T1.種別ID = T2.種別ID AND T1.フラグID = T2.フラグID "
			strSQL &= "GROUP BY T1.種別ID, T1.フラグID, T2.フラグ "
			strSQL &= "ORDER BY CASE WHEN T1.種別ID = 20 OR T1.種別ID = 40 THEN 1 ELSE 2 END, "
			strSQL &= "T1.種別ID, T1.フラグID"
			Dim dt As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
			Dim iRecordCount As Integer = 0
			Me.C1FGridOutput.Rows.Count = dt.Rows.Count + 1

			For iRow As Integer = 0 To dt.Rows.Count - 1
				iRecordCount += 1
				Me.C1FGridOutput(iRecordCount, "種別") = dt.Rows(iRow)("種別")
				Me.C1FGridOutput(iRecordCount, "フラグ") = dt.Rows(iRow)("フラグ")
				Me.C1FGridOutput(iRecordCount, "フラグ数") = dt.Rows(iRow)("フラグ数")
				Me.C1FGridOutput(iRecordCount, "確認数") = dt.Rows(iRow)("確認数")
				Me.C1FGridOutput(iRecordCount, "残数") = dt.Rows(iRow)("残数")
			Next

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		Finally

			sqlProcess.Close()

		End Try

	End Sub

	''' <summary>
	''' 出力タブの初期化
	''' </summary>
	Private Sub InitializeOutput()

		'セル結合
		Me.C1FGridOutput.Cols(0).AllowMerging = True   '列ヘッダのマージの許可※隣接したヘッダ名を同一文言にするとマージされる
		OutputUpdate()

	End Sub

	''' <summary>
	''' 出力タブのFROMグリッドからTOグリッドへレコードを移動させる
	''' </summary>
	''' <param name="iIndex"></param>
	Private Sub MoveRecord(ByVal iIndex As Integer)
		'TOグリッドを検索して既に登録されていないかチェックを行う
		Dim iSearch As Integer = Me.C1FGridOutputTo.FindRow(Me.C1FGridOutputFrom(iIndex, "管理ID"), 1, 1, False)
		If iSearch >= 0 Then
			'見つかった
			MessageBox.Show("既に移動されているフォルダです", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Exit Sub
		End If
		'TOグリッドの最終行に追加
		Me.C1FGridOutputTo.Rows.Count += 1
		Me.C1FGridOutputTo(Me.C1FGridOutputTo.Rows.Count - 1, "No") = Me.C1FGridOutputTo.Rows.Count - 1
		Me.C1FGridOutputTo(Me.C1FGridOutputTo.Rows.Count - 1, "管理ID") = Me.C1FGridOutputFrom(iIndex, "管理ID")
		Me.C1FGridOutputTo(Me.C1FGridOutputTo.Rows.Count - 1, "仮フォルダ") = Me.C1FGridOutputFrom(iIndex, "仮フォルダ")
		Me.C1FGridOutputTo(Me.C1FGridOutputTo.Rows.Count - 1, "納品フォルダ") = Me.C1FGridOutputFrom(iIndex, "納品フォルダ")
		Me.C1FGridOutputTo(Me.C1FGridOutputTo.Rows.Count - 1, "出力日時") = Me.C1FGridOutputFrom(iIndex, "出力日時")
		Me.C1FGridOutputTo(Me.C1FGridOutputTo.Rows.Count - 1, "出力日時エクセル") = Me.C1FGridOutputFrom(iIndex, "出力日時エクセル")
		'FROMグリッドから削除
		Me.C1FGridOutputFrom.Rows.Remove(iIndex)
		If Not IsNull(Me.C1FGridOutputTo(Me.C1FGridOutputTo.Rows.Count - 1, "出力日時")) And Not IsNull(Me.C1FGridOutputTo(Me.C1FGridOutputTo.Rows.Count - 1, "出力日時エクセル")) Then
			'イメージ出力、エクセル出力のどちらもNULLでなかったら(出力済みだったら)背景色を終了とする
			LinkPasteProcess.ChangeBackColor(Me.C1FGridOutputTo, Me.C1FGridOutputTo.Rows.Count - 1, LinkPasteProcess.GridStyleName.StyleFinish)
		End If
		'TOグリッドの追加されたレコードを選択
		Me.C1FGridOutputTo.Row = Me.C1FGridOutputTo.Rows.Count - 1

	End Sub

	''' <summary>
	''' 出力タブのFROMグリッドから全てのフォルダをTOグリッドに移動する
	''' </summary>
	Private Sub MoveAllRecord()

		Me.C1FGridOutputTo.BeginUpdate()
		For iIndex As Integer = 1 To Me.C1FGridOutputFrom.Rows.Count - 1
			'TOグリッドの最終行に追加
			Me.C1FGridOutputTo.Rows.Count += 1
			Me.C1FGridOutputTo(Me.C1FGridOutputTo.Rows.Count - 1, "No") = Me.C1FGridOutputTo.Rows.Count - 1
			Me.C1FGridOutputTo(Me.C1FGridOutputTo.Rows.Count - 1, "管理ID") = Me.C1FGridOutputFrom(iIndex, "管理ID")
			Me.C1FGridOutputTo(Me.C1FGridOutputTo.Rows.Count - 1, "仮フォルダ") = Me.C1FGridOutputFrom(iIndex, "仮フォルダ")
			Me.C1FGridOutputTo(Me.C1FGridOutputTo.Rows.Count - 1, "納品フォルダ") = Me.C1FGridOutputFrom(iIndex, "納品フォルダ")
			Me.C1FGridOutputTo(Me.C1FGridOutputTo.Rows.Count - 1, "出力日時") = Me.C1FGridOutputFrom(iIndex, "出力日時")
			Me.C1FGridOutputTo(Me.C1FGridOutputTo.Rows.Count - 1, "出力日時エクセル") = Me.C1FGridOutputFrom(iIndex, "出力日時エクセル")
			If Not IsNull(Me.C1FGridOutputTo(Me.C1FGridOutputTo.Rows.Count - 1, "出力日時")) And Not IsNull(Me.C1FGridOutputTo(Me.C1FGridOutputTo.Rows.Count - 1, "出力日時エクセル")) Then
				'イメージ出力、エクセル出力のどちらもNULLでなかったら(出力済みだったら)背景色を終了とする
				LinkPasteProcess.ChangeBackColor(Me.C1FGridOutputTo, Me.C1FGridOutputTo.Rows.Count - 1, LinkPasteProcess.GridStyleName.StyleFinish)
			End If
		Next
		Me.C1FGridOutputTo.EndUpdate()
		'FROMグリッドを空にする
		Me.C1FGridOutputFrom.Rows.Count = 1
		'TOグリッドの追加されたレコードを選択
		Me.C1FGridOutputTo.Row = Me.C1FGridOutputTo.Rows.Count - 1

	End Sub

	''' <summary>
	''' データテーブルの内容を書き込んで指定されたエクセルファイル名で保存する
	''' </summary>
	''' <param name="strTemplate">テンプレートエクセルファイル</param>
	''' <param name="strSaveFile">保存ファイル名のパス</param>
	''' <param name="dt">データが格納されたデータテーブル</param>
	''' <returns></returns>
	Private Function WriteExcelFile(ByVal strTemplate As String, ByVal strSaveFile As String, ByVal dt As DataTable) As Boolean

		Try

			Dim wb As New C1XLBook  'ワークブックのインスタンス
			wb.Load(strTemplate)    'テンプレートエクセルを読み込む
			Dim sheet As XLSheet = wb.Sheets(0) '先頭のシートを指定
			Dim i As Integer    'TryParse用変数

			For iRow As Integer = 0 To dt.Rows.Count - 1
				sheet(iRow + 1, 0).Value = dt.Rows(iRow)("レコード番号")
				sheet(iRow + 1, 1).Value = dt.Rows(iRow)("表示用")
				If Integer.TryParse(dt.Rows(iRow)("行番号"), i) Then
					sheet(iRow + 1, 2).Value = CInt(dt.Rows(iRow)("行番号"))
				Else
					sheet(iRow + 1, 2).Value = dt.Rows(iRow)("行番号")
				End If
				sheet(iRow + 1, 3).Value = dt.Rows(iRow)("県名")
				sheet(iRow + 1, 4).Value = dt.Rows(iRow)("資料名")
				sheet(iRow + 1, 5).Value = dt.Rows(iRow)("副題")
				sheet(iRow + 1, 6).Value = dt.Rows(iRow)("対象年")
				sheet(iRow + 1, 7).Value = dt.Rows(iRow)("刊行者名")
				sheet(iRow + 1, 8).Value = dt.Rows(iRow)("刊行年月")
				If Integer.TryParse(dt.Rows(iRow)("分類1"), i) Then
					sheet(iRow + 1, 9).Value = CInt(dt.Rows(iRow)("分類1"))
				Else
					sheet(iRow + 1, 9).Value = dt.Rows(iRow)("分類1")
				End If
				If Integer.TryParse(dt.Rows(iRow)("分類2"), i) Then
					sheet(iRow + 1, 10).Value = CInt(dt.Rows(iRow)("分類2"))
				Else
					sheet(iRow + 1, 10).Value = dt.Rows(iRow)("分類2")
				End If
				If Integer.TryParse(dt.Rows(iRow)("分類番号"), i) Then
					sheet(iRow + 1, 11).Value = CInt(dt.Rows(iRow)("分類番号"))
				Else
					sheet(iRow + 1, 11).Value = dt.Rows(iRow)("分類番号")
				End If
				sheet(iRow + 1, 12).Value = dt.Rows(iRow)("項目")
				If Integer.TryParse(dt.Rows(iRow)("番号1"), i) Then
					sheet(iRow + 1, 13).Value = CInt(dt.Rows(iRow)("番号1"))
				Else
					sheet(iRow + 1, 13).Value = dt.Rows(iRow)("番号1")
				End If
				sheet(iRow + 1, 14).Value = dt.Rows(iRow)("タイトル1")
				If Integer.TryParse(dt.Rows(iRow)("番号2"), i) Then
					sheet(iRow + 1, 15).Value = CInt(dt.Rows(iRow)("番号2"))
				Else
					sheet(iRow + 1, 15).Value = dt.Rows(iRow)("番号2")
				End If
				sheet(iRow + 1, 16).Value = dt.Rows(iRow)("タイトル2")
				If Integer.TryParse(dt.Rows(iRow)("番号3"), i) Then
					sheet(iRow + 1, 17).Value = CInt(dt.Rows(iRow)("番号3"))
				Else
					sheet(iRow + 1, 17).Value = dt.Rows(iRow)("番号3")
				End If
				sheet(iRow + 1, 18).Value = dt.Rows(iRow)("タイトル3")
				If Integer.TryParse(dt.Rows(iRow)("番号4"), i) Then
					sheet(iRow + 1, 19).Value = CInt(dt.Rows(iRow)("番号4"))
				Else
					sheet(iRow + 1, 19).Value = dt.Rows(iRow)("番号4")
				End If
				sheet(iRow + 1, 20).Value = dt.Rows(iRow)("タイトル4")
				If Integer.TryParse(dt.Rows(iRow)("番号5"), i) Then
					sheet(iRow + 1, 21).Value = CInt(dt.Rows(iRow)("番号5"))
				Else
					sheet(iRow + 1, 21).Value = dt.Rows(iRow)("番号5")
				End If
				sheet(iRow + 1, 22).Value = dt.Rows(iRow)("タイトル5")
				sheet(iRow + 1, 23).Value = dt.Rows(iRow)("フォルダ名")
				sheet(iRow + 1, 24).Value = dt.Rows(iRow)("リンク")
				sheet(iRow + 1, 25).Value = dt.Rows(iRow)("リンクTO")

			Next

			wb.Save(strSaveFile, FileFormat.OpenXml)
			Return True

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Return False

		End Try

	End Function

	''' <summary>
	''' 県名コンボボックスの値をもとに検索結果をグリッドFROMにセットする
	''' </summary>
	Private Sub PrefectureSelect()

		Dim strSQL As String = ""
		Dim sqlProcess As New SQLProcess
		Me.C1FGridOutputFrom.Rows.Count = 1 'グリッドの初期化

		Try
			strSQL = "SELECT A1.管理ID, A1.仮フォルダ, A1.納品フォルダ, A1.出力日時, A1.出力日時エクセル, A1.目次, A1.フラグ, A1.確認 "
			strSQL &= "FROM (SELECT T1.管理ID, T1.仮フォルダ, T1.納品フォルダ, "
			strSQL &= "ISNULL(T1.出力日時, '') AS 出力日時, ISNULL(T1.出力日時エクセル, '') AS 出力日時エクセル, "
			strSQL &= "COUNT(T2.管理ID) AS 目次, COUNT(T3.管理ID) AS フラグ, "
			strSQL &= "SUM(CASE WHEN T3.管理者確認 = 1 THEN 1 ELSE 0 END) AS 確認, "

			'2017/05/10
			'==============================================================
			'種別ID＝20のフラグID＝0(コンボボックスのインデックスは1)は選択肢が空欄のため、フラグ無しのレコードの代用とする
			'==============================================================
			'フラグ、変更フラグを考慮する
			If Me.cmbOutputFlag.SelectedIndex > 1 And Me.cmbOutputUpdateFlag.SelectedIndex > 0 Then
				'フラグ、変更フラグ共に「全て」以外
				strSQL &= "SUM(CASE WHEN (T3.種別ID = 20 AND T3.フラグID = " & Me.cmbOutputFlag.SelectedValue & ") OR (T3.種別ID = 40 AND T3.フラグID = " & Me.cmbOutputUpdateFlag.SelectedValue & ") THEN 1 ELSE 0 END) AS 特定フラグ, "

			ElseIf Me.cmbOutputFlag.SelectedIndex <= 1 And Me.cmbOutputUpdateFlag.SelectedIndex > 0 Then
				'フラグコンボボックスの対象は「全て」と「空欄」
				'フラグが「全て」、変更フラグが「全て」以外
				strSQL &= "SUM(CASE WHEN T3.種別ID = 40 AND T3.フラグID = " & Me.cmbOutputUpdateFlag.SelectedValue & " THEN 1 ELSE 0 END) AS 特定フラグ, "

			ElseIf Me.cmbOutputFlag.SelectedIndex > 1 And Me.cmbOutputUpdateFlag.SelectedIndex = 0 Then
				'フラグが「全て」以外、変更フラグが「全て」
				strSQL &= "SUM(CASE WHEN T3.種別ID = 20 AND T3.フラグID = " & Me.cmbOutputFlag.SelectedValue & " THEN 1 ELSE 0 END) AS 特定フラグ, "

			Else
				'全てのコンボボックスが「全て」
				strSQL &= "COUNT(T2.管理ID) AS 特定フラグ, "

			End If
			strSQL &= "T1.県名 "
			strSQL &= "FROM M_管理表 AS T1 INNER JOIN "
			strSQL &= "T_目次 AS T2 ON T1.管理ID = T2.管理ID LEFT OUTER JOIN "
			strSQL &= "T_フラグ AS T3 ON T2.管理ID = T3.管理ID AND T2.連番 = T3.連番 "
			strSQL &= "GROUP BY T1.管理ID, T1.仮フォルダ, T1.納品フォルダ, T1.出力日時, T1.出力日時エクセル, T1.県名) AS A1 "

			'strSQL = "SELECT T1.管理ID, T1.仮フォルダ, T1.納品フォルダ, "
			'strSQL &= "ISNULL(T1.出力日時, '') AS 出力日時, "
			'strSQL &= "ISNULL(T1.出力日時エクセル, '') AS 出力日時エクセル, "
			'strSQL &= "COUNT(T2.管理ID) AS 目次, "
			'strSQL &= "COUNT(T3.管理ID) AS フラグ, "
			'strSQL &= "SUM(CASE WHEN T3.管理者確認 = 1 THEN 1 ELSE 0 END) AS 確認 "
			'strSQL &= "FROM M_管理表 AS T1 INNER JOIN "
			'strSQL &= "T_目次 AS T2 ON T1.管理ID = T2.管理ID LEFT OUTER JOIN "
			'strSQL &= "T_フラグ AS T3 ON T2.管理ID = T3.管理ID And T2.連番 = T3.連番 "
			strSQL &= "WHERE A1.特定フラグ > 0 "
			'フラグコンボボックスのインデックスが1だった場合は、フラグカウントが0のもののみ抽出する
			If Me.cmbOutputFlag.SelectedIndex = 1 Then
				strSQL &= "AND A1.フラグ = 0 "
			End If
			'県名コンボボックスのインデックスが0だった場合
			If Not Me.cmbOutputPrefecture.SelectedIndex = 0 Then
				strSQL &= "AND A1.県名 LIKE '%" & Me.cmbOutputPrefecture.SelectedValue & "%' "
			End If
			strSQL &= "ORDER BY A1.管理ID"
			Dim dt As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
			Dim iRecordCount As Integer = 0
			Me.C1FGridOutputFrom.Rows.Count = dt.Rows.Count + 1

			For iRow As Integer = 0 To dt.Rows.Count - 1
				iRecordCount += 1
				Me.C1FGridOutputFrom(iRecordCount, "No") = iRecordCount
				Me.C1FGridOutputFrom(iRecordCount, "管理ID") = dt.Rows(iRow)("管理ID")
				Me.C1FGridOutputFrom(iRecordCount, "仮フォルダ") = dt.Rows(iRow)("仮フォルダ")
				Me.C1FGridOutputFrom(iRecordCount, "納品フォルダ") = dt.Rows(iRow)("納品フォルダ")
				Me.C1FGridOutputFrom(iRecordCount, "出力日時") = IIf(CDate(dt.Rows(iRow)("出力日時")).ToString("yyyy/MM/dd") = "1900/01/01", "", CDate(dt.Rows(iRow)("出力日時")).ToString("yyyy/MM/dd"))
				Me.C1FGridOutputFrom(iRecordCount, "出力日時エクセル") = IIf(CDate(dt.Rows(iRow)("出力日時エクセル")).ToString("yyyy/MM/dd") = "1900/01/01", "", CDate(dt.Rows(iRow)("出力日時エクセル")).ToString("yyyy/MM/dd"))
				Me.C1FGridOutputFrom(iRecordCount, "目次") = dt.Rows(iRow)("目次")
				Me.C1FGridOutputFrom(iRecordCount, "フラグ") = dt.Rows(iRow)("フラグ")
				Me.C1FGridOutputFrom(iRecordCount, "確認") = dt.Rows(iRow)("確認")
				If Not IsNull(Me.C1FGridOutputFrom(iRecordCount, "出力日時")) And Not IsNull(Me.C1FGridOutputFrom(iRecordCount, "出力日時エクセル")) Then
					LinkPasteProcess.ChangeBackColor(Me.C1FGridOutputFrom, iRecordCount, LinkPasteProcess.GridStyleName.StyleFinish)
				Else
					LinkPasteProcess.ChangeBackColor(Me.C1FGridOutputFrom, iRecordCount, LinkPasteProcess.GridStyleName.StyleDefault)
				End If
			Next

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		Finally

			sqlProcess.Close()

		End Try

	End Sub

#End Region

End Class