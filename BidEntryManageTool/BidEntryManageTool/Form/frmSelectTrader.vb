Public Class frmSelectTrader

#Region "フォームイベント"

	''' <summary>
	''' フォームロード時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub frmSelectTrader_Load(sender As Object, e As EventArgs) Handles MyBase.Load

		Me.Text = My.Application.Info.ProductName & " Ver." &
			My.Application.Info.Version.ToString & " - [業者選択]"

		'キー入力を受け付ける
		Me.KeyPreview = True

		Initialize()

	End Sub

#End Region

#Region "プライベートメソッド"

	''' <summary>
	''' 初期化処理	
	''' </summary>
	Private Sub Initialize()

		CaptionDisplayMode = StatusDisplayMode.None
		Dim strSQL As String = ""
		Dim sqlProcess As New SQLProcess

		Try
			strSQL = "SELECT 都道府県コード, 都道府県名 FROM M_都道府県 "
			strSQL &= "ORDER BY 都道府県コード"
			Dim dt As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)

			SetComboValue(Me.cmbPrefectures, dt, True, True)
			Me.cmbPrefectures.SelectedIndex = 0
			SearchGrid()

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & ex.StackTrace)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		Finally

			sqlProcess.Close()

		End Try

	End Sub

	''' <summary>
	''' 都道府県、業者名を指定して検索した値をグリッドにセットする
	''' </summary>
	Private Sub SearchGrid()

		Dim strSQL As String = ""
		Dim sqlProcess As New SQLProcess

		Try
			Dim strWhere As String = " WHERE "
			strSQL = "SELECT 内部番号, 業者番号, 自治体名 AS 業者名, 郵便番号, 住所1, 住所2, 電話番号, FAX番号 "
			strSQL &= "FROM M_自治体 "
			strSQL &= strWhere & "業者フラグ = 1 "
			strWhere = " AND "
			'都道府県名検索
			If Not Me.cmbPrefectures.SelectedValue = "00" Then
				'「全て」以外の場合は検索条件に加える
				strSQL &= strWhere & "都道府県コード = '" & Me.cmbPrefectures.SelectedValue & "' "
				strWhere = " AND "
			End If
			'業者名検索
			If Not IsNull(Me.txtTraderName.Text) Then
				strSQL &= strWhere & "自治体名 LIKE '%" & Me.txtTraderName.Text & "%' "
				strWhere = " AND "
			End If
			strSQL &= "ORDER BY 内部番号"
			Dim dt As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
			Dim iRecCount As Integer = 0
			Me.C1FGridResult.Rows.Count = 1
			For iRow As Integer = 0 To dt.Rows.Count - 1
				iRecCount += 1
				Me.C1FGridResult.Rows.Count = iRecCount + 1
				Me.C1FGridResult(iRecCount, "No") = iRecCount
				Me.C1FGridResult(iRecCount, "内部番号") = dt.Rows(iRow)("内部番号")
				Me.C1FGridResult(iRecCount, "業者番号") = dt.Rows(iRow)("業者番号")
				Me.C1FGridResult(iRecCount, "業者名") = dt.Rows(iRow)("業者名")
				Me.C1FGridResult(iRecCount, "郵便番号") = dt.Rows(iRow)("郵便番号")
				Me.C1FGridResult(iRecCount, "住所1") = dt.Rows(iRow)("住所1")
				Me.C1FGridResult(iRecCount, "住所2") = dt.Rows(iRow)("住所2")
				Me.C1FGridResult(iRecCount, "電話番号") = dt.Rows(iRow)("電話番号")
				Me.C1FGridResult(iRecCount, "FAX番号") = dt.Rows(iRow)("FAX番号")
			Next

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & ex.StackTrace)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		Finally

			sqlProcess.Close()

		End Try

	End Sub

	''' <summary>
	''' 業者選択時動作
	''' </summary>
	Private Sub SelectTrader()

		Dim strSQL As String = ""
		Dim sqlProcess As New SQLProcess
		Dim f As frmTraderDetail = CType(Me.Owner, frmTraderDetail)

		Try
			strSQL = "SELECT 内部番号, 業者番号, 都道府県コード, 自治体名 AS 業者名, 自治体名かな AS 業者名かな, "
			strSQL &= "郵便番号, 住所1, 住所2, 電話番号, FAX番号, URL, EMail "
			strSQL &= "FROM M_自治体 "
			strSQL &= "WHERE 内部番号 = '" & Me.C1FGridResult(Me.C1FGridResult.Row, "内部番号") & "'"
			Dim dt As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
			If dt.Rows.Count = 1 Then
				f.txtInnerNumber.Text = dt.Rows(0)("内部番号")
				f.txtTraderNumber.Text = dt.Rows(0)("業者番号")
				f.cmbPrefectures.SelectedValue = dt.Rows(0)("都道府県コード")
				f.txtTraderName.Text = dt.Rows(0)("業者名")
				f.txtTraderNameKana.Text = dt.Rows(0)("業者名かな")
				f.txtZipCode.Text = dt.Rows(0)("郵便番号")
				f.txtAddress1.Text = dt.Rows(0)("住所1")
				f.txtAddress2.Text = dt.Rows(0)("住所2")
				f.txtTel.Text = dt.Rows(0)("電話番号")
				f.txtFax.Text = dt.Rows(0)("FAX番号")
				f.txtUrl.Text = dt.Rows(0)("URL")
				f.txtEmail.Text = dt.Rows(0)("EMail")
			Else
				MessageBox.Show("予期せぬエラーが発生しました", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
				Exit Sub
			End If

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & ex.StackTrace)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		Finally

			sqlProcess.Close()

		End Try

	End Sub

#End Region

#Region "オブジェクトイベント"

	''' <summary>
	''' 検索ボタン押下時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click

		SearchGrid()

	End Sub

	''' <summary>
	''' キャンセルボタン押下時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click

		Me.Close()

	End Sub

	''' <summary>
	''' 選択ボタン押下時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub btnSelect_Click(sender As Object, e As EventArgs) Handles btnSelect.Click

		SelectTrader()
		Me.Close()

	End Sub

	''' <summary>
	''' グリッドダブルクリック時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub C1FGridResult_DoubleClick(sender As Object, e As EventArgs) Handles C1FGridResult.DoubleClick

		SelectTrader()
		Me.Close()

	End Sub

#End Region

End Class