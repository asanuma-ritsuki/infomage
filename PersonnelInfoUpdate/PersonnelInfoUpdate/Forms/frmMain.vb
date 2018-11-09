Public Class frmMain

#Region "フォームイベント"

	''' <summary>
	''' フォームロード時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load

		Me.Text = My.Application.Info.ProductName & " Ver." &
			My.Application.Info.Version.ToString & " - [運用画面]"

		'キー入力を受け付ける
		Me.KeyPreview = True
		CaptionDisplayMode = StatusDisplayMode.ShowAll

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
	''' 検索ボタン押下時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click

		SearchGrid()

	End Sub

	''' <summary>
	''' インポートボタン押下時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub btnImport_Click(sender As Object, e As EventArgs) Handles btnImport.Click

		Dim f As New frmImport
		Me.Visible = False
		f.ShowDialog()
		Me.Visible = True

		SearchGrid()
		SearchSum()

	End Sub

	''' <summary>
	''' 不備修正ボタン押下時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub btnCorrection_Click(sender As Object, e As EventArgs) Handles btnCorrection.Click

		If IsNull(Me.txtLotID.Text) Then
			MessageBox.Show("ロットを選択してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Exit Sub
		End If

		Dim strSQL As String = ""
		Dim sqlProcess As New SQLProcess

		Try
			''不備が残っているかチェックして残っていたら画面遷移
			'strSQL = "SELECT COUNT(*) FROM T_不備内容 "
			'strSQL &= "WHERE ロットID = '" & Me.txtLotID.Text & "' "
			'strSQL &= "AND 修正済フラグ = 0 And 対象外 = 0 "
			'Dim iCorrection As Integer = sqlProcess.DB_EXECUTE_SCALAR(strSQL)
			'If iCorrection = 0 Then
			'	'全て修正済または対象外だったら遷移させない
			'	MessageBox.Show("不備レコードは1件もありません", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information)
			'	Exit Sub
			'End If

			Dim f As New frmCorrection
			f.txtLotID.Text = Me.txtLotID.Text
			f.txtOffice.Text = Me.txtOffice.Text
			Me.Visible = False
			f.ShowDialog()
			Me.Visible = True

			SearchGrid()
			SearchSum()

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & ex.StackTrace)
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
	Private Sub btnCSVOut_Click(sender As Object, e As EventArgs) Handles btnCSVOut.Click

		If IsNull(Me.txtLotID.Text) Then
			MessageBox.Show("ロットを選択してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Exit Sub
		End If

		Dim strSQL As String = ""
		Dim sqlProcess As New SQLProcess

		Try
			'対象ロットについて全ての不備内容のレコードの修正済フラグまたは対象外がTRUEの場合のみ出力可能
			strSQL = "SELECT COUNT(*) FROM T_不備内容 "
			strSQL &= "WHERE ロットID = '" & Me.txtLotID.Text & "' "
			strSQL &= "AND 修正済フラグ = 0 AND 対象外 = 0"
			Dim iCount As Integer = sqlProcess.DB_EXECUTE_SCALAR(strSQL)
			If iCount > 0 Then
				MessageBox.Show("不備内容が全て修正されていません" & vbNewLine & "全て修正してからCSV出力を行ってください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
				Exit Sub
			End If

			Dim f As New frmOutput
			f.txtLotID.Text = Me.txtLotID.Text
			f.txtOffice.Text = Me.txtOffice.Text
			Me.Visible = False
			f.ShowDialog()
			Me.Visible = True

			SearchGrid()
			SearchSum()

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & ex.StackTrace)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		Finally

			sqlProcess.Close()

		End Try

	End Sub

	''' <summary>
	''' 更新後処理ボタン押下時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub btnAfterUpdate_Click(sender As Object, e As EventArgs) Handles btnAfterUpdate.Click

		If IsNull(Me.txtLotID.Text) Then
			MessageBox.Show("ロットを選択してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Exit Sub
		End If

		Dim strSQL As String = ""
		Dim sqlProcess As New SQLProcess

		Try
			'T_ロット管理内の「CSV出力日時」がNULLだった場合、エラーとする
			strSQL = "SELECT COUNT(*) FROM T_ロット管理 "
			strSQL &= "WHERE ロットID = '" & Me.txtLotID.Text & "' "
			strSQL &= "AND ISNULL(CSV出力日時, '1900/01/01') != '1900/01/01'"
			Dim iCount As Integer = sqlProcess.DB_EXECUTE_SCALAR(strSQL)
			If iCount = 0 Then
				MessageBox.Show("CSVが出力されていません" & vbNewLine & "CSV出力をして、e-革新を更新してからデータ抽出作業を行ってください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
				Exit Sub
			End If

			Dim f As New frmExtraction
			f.txtLotID.Text = Me.txtLotID.Text
			f.txtOffice.Text = Me.txtOffice.Text
			Me.Visible = False
			f.ShowDialog()
			Me.Visible = True

			SearchGrid()
			SearchSum()

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & ex.StackTrace)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		Finally

			sqlProcess.Close()

		End Try

	End Sub

	''' <summary>
	''' グリッドクリック時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub C1FGridResult_Click(sender As Object, e As EventArgs) Handles C1FGridResult.Click

		Dim iIndex As Integer = Me.C1FGridResult.Row
		If iIndex > 0 Then
			Me.txtLotID.Text = Me.C1FGridResult(iIndex, "ロットID")
			Me.txtOffice.Text = Me.C1FGridResult(iIndex, "事業所")
		End If

	End Sub

	''' <summary>
	''' 削除ボタン押下時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click

		If IsNull(Me.txtLotID.Text) Then
			MessageBox.Show("ロットを選択してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Exit Sub
		End If
		If MessageBox.Show("選択したロットを削除対象とします" & vbNewLine & "よろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
			Exit Sub
		End If

		Dim strSQL As String = ""
		Dim sqlProcess As New SQLProcess
		Dim strLotID As String = Me.txtLotID.Text

		Try
			strSQL = "UPDATE T_ロット管理 SET 削除フラグ = 1 "
			strSQL &= "WHERE ロットID = '" & strLotID & "'"
			sqlProcess.DB_UPDATE(strSQL)
			'strSQL = "DELETE FROM T_ロット管理 "
			'strSQL &= "WHERE ロットID = '" & Me.txtLotID.Text & "'"
			'sqlProcess.DB_UPDATE(strSQL)
			'strSQL = "DELETE FROM T_異動情報 "
			'strSQL &= "WHERE ロットID = '" & Me.txtLotID.Text & "'"
			'sqlProcess.DB_UPDATE(strSQL)
			'strSQL = "DELETE FROM T_不備内容 "
			'strSQL &= "WHERE ロットID = '" & Me.txtLotID.Text & "'"
			'sqlProcess.DB_UPDATE(strSQL)
			'strSQL = "DELETE FROM T_利用者情報 "
			'strSQL &= "WHERE ロットID = '" & Me.txtLotID.Text & "'"
			'sqlProcess.DB_UPDATE(strSQL)
			'strSQL = "DELETE FROM T_利用者情報出力 "
			'strSQL &= "WHERE ロットID = '" & Me.txtLotID.Text & "'"
			'sqlProcess.DB_UPDATE(strSQL)

			SearchGrid()
			SearchSum()
			Me.C1FGridResult.Row = 0
			MessageBox.Show("該当ロットを削除対象としました" & vbNewLine & "ロットID：" & strLotID, "確認", MessageBoxButtons.OK, MessageBoxIcon.Information)

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

		Me.C1Label1.Text = "処理日："
		Me.C1Label2.Text = "事業所："
		Dim strSQL As String = ""
		Dim sqlProcess As New SQLProcess

		Try
			strSQL = "SELECT 事業所ID, 事業所 FROM M_事業所 "
			strSQL &= "ORDER BY 事業所ID"
			Dim dt As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
			Me.cmbOffice.ItemsDataSource = dt
			Me.cmbOffice.ItemsDisplayMember = "事業所"
			Me.cmbOffice.ItemsValueMember = "事業所ID"

			SearchGrid()
			SearchSum()

			Me.C1FGridResult.Row = 0

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & ex.StackTrace)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		Finally

			sqlProcess.Close()

		End Try

	End Sub

	''' <summary>
	''' 検索処理
	''' </summary>
	Private Sub SearchGrid()

		Dim strSQL As String = ""
		Dim sqlProcess As New SQLProcess
		Dim strWhere As String = " WHERE "

		Try
			strSQL = "SELECT T1.ロットID, T1.処理日, T1.エクセルファイル, T2.事業所, "
			strSQL &= "ISNULL(T1.インポート日時, '1900/01/01') AS インポート日時, "
			strSQL &= "ISNULL(T1.要修正日時, '1900/01/01') AS 要修正日時, "
			strSQL &= "ISNULL(T1.修正済日時, '1900/01/01') AS 修正済日時,"
			strSQL &= "ISNULL(T1.CSV出力日時, '1900/01/01') AS CSV出力日時, "
			strSQL &= "ISNULL(T1.納品日時, '1900/01/01') AS 納品日時, "
			strSQL &= "T1.削除フラグ "
			strSQL &= "FROM T_ロット管理 AS T1 INNER JOIN "
			strSQL &= "M_事業所 AS T2 ON T1.事業所ID = T2.事業所ID "
			If Not IsDBNull(Me.dtpProcessDate.Value) Then
				strSQL &= strWhere & "T1.処理日 = '" & Me.dtpProcessDate.Value & "' "
				strWhere = " AND "
			End If
			If Not IsNull(Me.cmbOffice.Text) Then
				strSQL &= strWhere & "T1.事業所ID = '" & Me.cmbOffice.Value & "' "
				strWhere = " AND "
			End If
			If Not Me.chkDeleted.Checked Then
				'チェックが入っていなかったら削除済みは除外する
				strSQL &= strWhere & "T1.削除フラグ = 0 "
			End If
			strSQL &= "ORDER BY T1.ロットID DESC"
			Dim dt As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)

			Dim iRecCount As Integer = 0
			Me.C1FGridResult.Rows.Count = 1
			For iRow As Integer = 0 To dt.Rows.Count - 1
				iRecCount += 1
				Me.C1FGridResult.Rows.Count = iRecCount + 1
				Me.C1FGridResult(iRecCount, "No") = iRecCount
				Me.C1FGridResult(iRecCount, "ロットID") = dt.Rows(iRow)("ロットID")
				Me.C1FGridResult(iRecCount, "処理日") = CDate(dt.Rows(iRow)("処理日")).ToString("yyyy/MM/dd")
				Me.C1FGridResult(iRecCount, "エクセルファイル") = dt.Rows(iRow)("エクセルファイル")
				Me.C1FGridResult(iRecCount, "事業所") = dt.Rows(iRow)("事業所")
				Me.C1FGridResult(iRecCount, "インポート日時") = IIf(dt.Rows(iRow)("インポート日時") = "1900/01/01", "", dt.Rows(iRow)("インポート日時"))
				Me.C1FGridResult(iRecCount, "要修正日時") = IIf(dt.Rows(iRow)("要修正日時") = "1900/01/01", "", dt.Rows(iRow)("要修正日時"))
				Me.C1FGridResult(iRecCount, "修正済日時") = IIf(dt.Rows(iRow)("修正済日時") = "1900/01/01", "", dt.Rows(iRow)("修正済日時"))
				Me.C1FGridResult(iRecCount, "CSV出力日時") = IIf(dt.Rows(iRow)("CSV出力日時") = "1900/01/01", "", dt.Rows(iRow)("CSV出力日時"))
				Me.C1FGridResult(iRecCount, "納品日時") = IIf(dt.Rows(iRow)("納品日時") = "1900/01/01", "", dt.Rows(iRow)("納品日時"))
				Me.C1FGridResult(iRecCount, "削除フラグ") = dt.Rows(iRow)("削除フラグ")
			Next

			Me.txtLotID.Text = ""
			Me.txtOffice.Text = ""

			ChangeBackColor()

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & ex.StackTrace)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		Finally

			sqlProcess.Close()

		End Try

	End Sub

	''' <summary>
	''' 集計処理
	''' </summary>
	Private Sub SearchSum()

		Dim strSQL As String = ""
		Dim sqlProcess As New SQLProcess

		Try
			Dim iRecCount As Integer = 0
			strSQL = "SELECT T1.処理日, COUNT(T1.処理日) AS 処理数, "
			strSQL &= "ISNULL(SUM(CASE WHEN T2.辞令 = '採用' THEN 1 ELSE 0 END), 0) AS 新規追加, "
			strSQL &= "ISNULL(SUM(CASE WHEN T2.辞令 = '人事異動' THEN 1 ELSE 0 END), 0) AS 更新, "
			strSQL &= "ISNULL(SUM(CASE WHEN T2.辞令 = '退職' THEN 1 ELSE 0 END), 0) AS 削除, "
			strSQL &= "T3.要修正, T3.修正済, T3.対象外 "
			strSQL &= "FROM T_ロット管理 AS T1 INNER JOIN "
			strSQL &= "T_異動情報 AS T2 ON T1.ロットID = T2.ロットID INNER JOIN "
			strSQL &= "(SELECT ロットID, "
			strSQL &= "ISNULL(SUM(CASE WHEN 修正済フラグ = 0 AND 対象外 = 0 THEN 1 ELSE 0 END), 0) AS 要修正, "
			strSQL &= "ISNULL(SUM(CASE WHEN 修正済フラグ = 1 AND 対象外 = 0 THEN 1 ELSE 0 END), 0) AS 修正済, "
			strSQL &= "ISNULL(SUM(CASE WHEN 対象外 = 1 THEN 1 ELSE 0 END), 0) AS 対象外 "
			strSQL &= "FROM T_不備内容 "
			strSQL &= "GROUP BY ロットID) AS T3 ON T1.ロットID = T3.ロットID "
			strSQL &= "WHERE T1.削除フラグ = 0 "
			strSQL &= "GROUP BY T1.処理日, T3.要修正, T3.修正済, T3.対象外"
			Dim dt As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
			Me.C1FGridSum.Rows.Count = 1
			For iRow As Integer = 0 To dt.Rows.Count - 1
				iRecCount += 1
				Me.C1FGridSum.Rows.Count = iRecCount + 1
				Me.C1FGridSum(iRecCount, "No") = iRecCount
				Me.C1FGridSum(iRecCount, "処理日") = CDate(dt.Rows(iRow)("処理日")).ToString("yyyy/MM/dd")
				Me.C1FGridSum(iRecCount, "処理数") = dt.Rows(iRow)("処理数")
				Me.C1FGridSum(iRecCount, "新規追加") = dt.Rows(iRow)("新規追加")
				Me.C1FGridSum(iRecCount, "更新") = dt.Rows(iRow)("更新")
				Me.C1FGridSum(iRecCount, "削除") = dt.Rows(iRow)("削除")
				Me.C1FGridSum(iRecCount, "要修正") = dt.Rows(iRow)("要修正")
				Me.C1FGridSum(iRecCount, "修正済") = dt.Rows(iRow)("修正済")
				Me.C1FGridSum(iRecCount, "対象外") = dt.Rows(iRow)("対象外")
			Next

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & ex.StackTrace)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		Finally

			sqlProcess.Close()

		End Try

	End Sub

	''' <summary>
	''' グリッドの背景色を条件によって変更する
	''' </summary>
	Private Sub ChangeBackColor()
		'カスタムスタイルを作成する
		With Me.C1FGridResult
			'出力可能スタイル
			.Styles.Add("StyleChange")
			.Styles("StyleChange").BackColor = Color.White
			.Styles("StyleChange").ForeColor = Color.Black
			'要修正スタイル
			.Styles.Add("StyleIncomplete")
			.Styles("StyleIncomplete").BackColor = Color.Yellow
			.Styles("StyleIncomplete").ForeColor = Color.Black
			'出力済スタイル
			.Styles.Add("StyleOutput")
			.Styles("StyleOutput").BackColor = Color.LightGreen
			.Styles("StyleOutput").ForeColor = Color.Black
			'納品済スタイル
			.Styles.Add("StyleComplete")
			.Styles("StyleComplete").BackColor = Color.DeepSkyBlue
			.Styles("StyleComplete").ForeColor = Color.Black
			'削除スタイル
			.Styles.Add("StyleDelete")
			.Styles("StyleDelete").BackColor = Color.LightSlateGray
			.Styles("StyleDelete").ForeColor = Color.White

			Me.C1FGridResult.BeginUpdate()

			For i As Integer = 1 To Me.C1FGridResult.Rows.Count - 1
				'削除フラグがチェックされているか
				If Not Me.C1FGridResult(i, "削除フラグ") Then
					'納品日時がNULL
					If IsNull(Me.C1FGridResult(i, "納品日時")) Then
						'CSV出力日時がNULL
						If IsNull(Me.C1FGridResult(i, "CSV出力日時")) Then
							'修正済日時がNULL
							If IsNull(Me.C1FGridResult(i, "修正済日時")) Then
								'要修正日時がNULL
								If IsNull(Me.C1FGridResult(i, "要修正日時")) Then
									'全てNULL
									Me.C1FGridResult.Rows(i).Style = Me.C1FGridResult.Styles("StyleChange")
								Else
									'修正済
									Me.C1FGridResult.Rows(i).Style = Me.C1FGridResult.Styles("StyleIncomplete")
								End If
							Else
								'修正済
								Me.C1FGridResult.Rows(i).Style = Me.C1FGridResult.Styles("StyleChange")
							End If
						Else
							'CSV出力済
							Me.C1FGridResult.Rows(i).Style = Me.C1FGridResult.Styles("StyleOutput")
						End If
					Else
						'納品済み
						Me.C1FGridResult.Rows(i).Style = Me.C1FGridResult.Styles("StyleComplete")
					End If
				Else
					'削除済み
					Me.C1FGridResult.Rows(i).Style = Me.C1FGridResult.Styles("StyleDelete")
				End If
			Next

			Me.C1FGridResult.EndUpdate()
		End With

	End Sub

#End Region

End Class