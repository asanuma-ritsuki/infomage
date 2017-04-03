Public Class frmProjectManage

#Region "プライベート変数"

	Private m_BackFormID As String = "frmMainMenu"

#End Region

#Region "フォームイベント"

	''' <summary>
	''' フォームロード時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub frmProjectManage_Load(sender As Object, e As EventArgs) Handles MyBase.Load

		Me.Text = My.Application.Info.ProductName & " Ver." &
			My.Application.Info.Version.ToString & " - [案件管理]"

		CaptionDisplayMode = StatusDisplayMode.ShowAll

		SearchGrid()

	End Sub

#End Region

#Region "オブジェクトイベント"

	''' <summary>
	''' 終了ボタン押下時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click

		If MessageBox.Show("アプリケーションを終了します" & vbNewLine & "よろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
			Application.Exit()
		End If

	End Sub

	''' <summary>
	''' グリッド内マウスホイール動作時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	''' <remarks></remarks>
	Private Sub C1FGridResult_MouseWheel(sender As Object, e As MouseEventArgs) Handles C1FGridResult.MouseWheel

		Me.C1FGridResult.Focus()

	End Sub

	Private Sub btnCSVOutput_Click(sender As Object, e As EventArgs) Handles btnCSVOutput.Click

		If Me.C1FGridResult.Rows.Count <= 1 Then
			'1件もない

		End If
		OutputCSVFile(Me.C1FGridResult, "案件一覧_" & Date.Now.ToString("yyyyMMdd") & ".csv")

	End Sub

#End Region

#Region "プライベートメソッド"

	''' <summary>
	''' 案件一覧をグリッドにセットする
	''' </summary>
	Private Sub SearchGrid()

		Dim strSQL As String = ""
		Dim sqlProcess As New SQLProcess
		Dim iRecordCount As Integer = 0
		Try
			strSQL = "SELECT T1.案件ID, T1.案件名, T1.作番コード, T1.顧客名, T1.エンドユーザー, ISNULL(T1.納品日, '1900/01/01') AS 納品日, "
			strSQL &= "ISNULL(T1.終了日, '1900/01/01') AS 終了日, T1.備考, T2.従業員名 "
			strSQL &= "FROM T_案件管理 AS T1 INNER JOIN "
			strSQL &= "M_従業員 AS T2 ON T1.従業員ID = T2.従業員ID"
			Dim dt As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)

			Me.C1FGridResult.BeginUpdate()

			For iRow As Integer = 0 To dt.Rows.Count - 1
				iRecordCount += 1
				Me.C1FGridResult.Rows.Count = iRecordCount + 1
				Me.C1FGridResult(iRecordCount, "No") = iRecordCount
				Me.C1FGridResult(iRecordCount, "案件ID") = dt.Rows(iRow)("案件ID")
				Me.C1FGridResult(iRecordCount, "案件名") = dt.Rows(iRow)("案件名")
				Me.C1FGridResult(iRecordCount, "作番コード") = dt.Rows(iRow)("作番コード")
				Me.C1FGridResult(iRecordCount, "顧客名") = dt.Rows(iRow)("顧客名")
				Me.C1FGridResult(iRecordCount, "エンドユーザー") = dt.Rows(iRow)("エンドユーザー")
				Me.C1FGridResult(iRecordCount, "納品日") = IIf(CDate(dt.Rows(iRow)("納品日")) = "1900/01/01", "", CDate(dt.Rows(iRow)("納品日")).ToString("yyyy/MM/dd"))
				Me.C1FGridResult(iRecordCount, "終了日") = IIf(CDate(dt.Rows(iRow)("終了日")) = "1900/01/01", "", CDate(dt.Rows(iRow)("終了日")).ToString("yyyy/MM/dd"))
				Me.C1FGridResult(iRecordCount, "備考") = dt.Rows(iRow)("備考")
				Me.C1FGridResult(iRecordCount, "登録者") = dt.Rows(iRow)("従業員名")
			Next

			Me.C1FGridResult.AutoSizeCols()
			Me.C1FGridResult.EndUpdate()

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		Finally

			sqlProcess.Close()
			ChangeBackColor()

		End Try

	End Sub

	''' <summary>
	''' 本日、納品予定日の兼ね合いで背景色を変更する
	''' </summary>
	''' <remarks></remarks>
	Private Sub ChangeBackColor()

		Try
			Dim iCount As Integer = Me.C1FGridResult.Rows.Count - 1
			Dim i As Integer = 0
			Dim dtToday As Date = DateTime.Today    '本日
			Dim dtDeliveryDate As Date  '納品日

			Me.C1FGridResult.BeginUpdate()
			For i = 1 To iCount
				'納品予定日がNULLでなければ
				If Not IsNull(Me.C1FGridResult(i, "納品日")) Then
					dtDeliveryDate = CDate(Me.C1FGridResult(i, "納品日"))    '納品日の取得
					'本日と納品予定日の差を算出する
					If DateDiff("d", dtToday, dtDeliveryDate) <= 0 Then
						'納品予定日当日か納品予定を過ぎていたら
						Me.C1FGridResult.Rows(i).StyleNew.BackColor = Color.Red
						Me.C1FGridResult.Rows(i).Style.ForeColor = Color.White
					ElseIf DateDiff("d", dtToday, dtDeliveryDate) >= 1 And
						DateDiff("d", dtToday, dtDeliveryDate) <= 5 Then
						'納品予定日まで1～5日以内なら
						Me.C1FGridResult.Rows(i).StyleNew.BackColor = Color.Pink
					End If
				End If
			Next
			Me.C1FGridResult.EndUpdate()

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		End Try

	End Sub

#End Region

End Class