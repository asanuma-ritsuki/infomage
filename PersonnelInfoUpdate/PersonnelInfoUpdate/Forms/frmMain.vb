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
		f.ShowDialog(Me)
		SearchGrid()
		SearchSum()

	End Sub

	''' <summary>
	''' CSV出力ボタン押下時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub btnCSVOut_Click(sender As Object, e As EventArgs) Handles btnCSVOut.Click

	End Sub

	''' <summary>
	''' 更新後処理ボタン押下時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub btnAfterUpdate_Click(sender As Object, e As EventArgs) Handles btnAfterUpdate.Click

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
				Me.C1FGridResult(iRecCount, "削除フラグ") = IIf(dt.Rows(iRow)("削除フラグ") = 1, True, False)
			Next

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
			strSQL &= "ISNULL(SUM(CASE WHEN T2.辞令 = '退職' THEN 1 ELSE 0 END), 0) AS 削除 "
			strSQL &= "FROM T_ロット管理 AS T1 INNER JOIN "
			strSQL &= "T_異動情報 AS T2 ON T1.ロットID = T2.ロットID "
			strSQL &= "WHERE T1.削除フラグ = 0 "
			strSQL &= "GROUP BY T1.処理日"
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