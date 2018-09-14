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

	End Sub

	''' <summary>
	''' インポートボタン押下時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub btnImport_Click(sender As Object, e As EventArgs) Handles btnImport.Click

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

	End Sub

	''' <summary>
	''' 検索処理
	''' </summary>
	Private Sub SearchGrid()

		Dim strSQL As String = ""
		Dim sqlProcess As New SQLProcess
		Dim strWhere As String = " WHERE "

		Try
			strSQL = "SELECT ロットID, 処理日, エクセルファイル, 事業所ID, "
			strSQL &= "ISNULL(インポート日時, '1900/01/01') AS インポート日時, "
			strSQL &= "ISNULL(要修正日時, '1900/01/01') AS 要修正日時, "
			strSQL &= "ISNULL(修正済日時, '1900/01/01') AS 修正済日時,"
			strSQL &= "ISNULL(CSV出力日時, '1900/01/01') AS CSV出力日時, "
			strSQL &= "ISNULL(納品日時, '1900/01/01') AS 納品日時, "
			strSQL &= "削除フラグ "
			strSQL &= "FROM T_ロット管理 "
			If Not IsDBNull(Me.dtpProcessDate.Value) Then
				strSQL &= strWhere & "処理日 = '" & Me.dtpProcessDate.Value & "'"
				strWhere = " AND "
			End If
			If Not IsNull(Me.cmbOffice.Text) Then
				strSQL &= strWhere & "事業所ID = '" & Me.cmbOffice.Text & "' "
			End If
			strSQL &= "ORDER BY ロットID DESC"
			Dim dt As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)

			Dim iRecCount As Integer = 0
			For iRow As Integer = 0 To dt.Rows.Count - 1
				iRecCount += 1
				Me.C1FGridResult.Rows.Count = iRecCount + 1
				Me.C1FGridResult(iRecCount, "No") = iRecCount
				Me.C1FGridResult(iRecCount, "ロットID") = dt.Rows(iRow)("ロットID")
				Me.C1FGridResult(iRecCount, "処理日") = dt.Rows(iRow)("処理日")
				Me.C1FGridResult(iRecCount, "エクセルファイル") = dt.Rows(iRow)("エクセルファイル")
				Me.C1FGridResult(iRecCount, "事業所") = dt.Rows(iRow)("事業所ID")
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

	End Sub

#End Region

End Class