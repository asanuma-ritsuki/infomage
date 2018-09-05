Public Class frmOperation

#Region "フォームイベント"

	''' <summary>
	''' フォームロード時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub frmOperation_Load(sender As Object, e As EventArgs) Handles MyBase.Load

		Me.Text = My.Application.Info.ProductName & "Ver." &
			My.Application.Info.Version.ToString & " - [運用画面]"

		Initialize()

	End Sub

	''' <summary>
	''' フォームクロージング
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub frmOperation_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

		XmlSettings.LoadFromXmlFile()
		If Me.WindowState = FormWindowState.Maximized Then
			XmlSettings.Instance.State = FormWindowState.Maximized
			Me.WindowState = FormWindowState.Normal
		Else
			XmlSettings.Instance.State = FormWindowState.Normal
		End If
		XmlSettings.Instance.LocationX = Me.Location.X
		XmlSettings.Instance.LocationY = Me.Location.Y
		XmlSettings.Instance.SizeX = Me.Size.Width
		XmlSettings.Instance.SizeY = Me.Size.Height

		XmlSettings.SaveToXmlFile()

		'If MessageBox.Show("アプリケーションを終了します" & vbNewLine & "よろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
		'	e.Cancel = True
		'	Exit Sub
		'Else
		'	XmlSettings.LoadFromXmlFile()
		'	XmlSettings.Instance.LocationX = Me.Location.X
		'	XmlSettings.Instance.LocationY = Me.Location.Y
		'	XmlSettings.Instance.SizeX = Me.Size.Width
		'	XmlSettings.Instance.SizeY = Me.Size.Height
		'	If Me.WindowState = FormWindowState.Maximized Then
		'		XmlSettings.Instance.State = FormWindowState.Maximized
		'		Me.WindowState = FormWindowState.Normal
		'	Else
		'		XmlSettings.Instance.State = FormWindowState.Normal
		'	End If

		'End If
	End Sub


#End Region

#Region "オブジェクトイベント"

	''' <summary>
	''' 戻るボタン押下時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click

		Dim f As New frmMainMenu
		m_Context.SetNextContext(f)

	End Sub

	''' <summary>
	''' 都道府県コンボボックス値変更時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub cmbPrefectures_SelectedIndexChanged(sender As Object, e As EventArgs)
		SearchTrader()
	End Sub

	''' <summary>
	''' 業者コンボボックス値変更時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub cmbTrader_SelectedIndexChanged(sender As Object, e As EventArgs)
		SearchTrader()
	End Sub

	''' <summary>
	''' 業者グリッドセル移動時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub C1FGridResult_RowColChange(sender As Object, e As EventArgs) Handles C1FGridResult.RowColChange
		SearchMuni()
	End Sub

	''' <summary>
	''' 業者グリッドクリック時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub C1FGridResult_MouseDown(sender As Object, e As MouseEventArgs) Handles C1FGridResult.MouseDown

		If e.Button = MouseButtons.Left And e.Clicks > 1 Then
			'左ダブルクリックされたとき
			Dim hti As C1.Win.C1FlexGrid.HitTestInfo = Me.C1FGridResult.HitTest(e.X, e.Y)

			If hti.Row < Me.C1FGridResult.Cols.Fixed Then
				'ヘッダがダブルクリックされた
				'何もしない
			Else
				Dim iIndex As Integer = Me.C1FGridResult.Row
				Dim f As New frmTraderDetail
				f.ShowDialog(Me)
			End If
		End If
	End Sub

	''' <summary>
	''' 都道府県コンボボックスインデックス変更時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub cmbPrefectures_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles cmbPrefectures.SelectedIndexChanged

		SearchTrader()

	End Sub

	''' <summary>
	''' 業者コンボボックスインデックス変更時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub cmbTrader_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles cmbTrader.SelectedIndexChanged

		SearchTrader()

	End Sub

	''' <summary>
	''' 新規登録ボタン押下時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click

		Dim frmNextForm As New frmTraderDetail
		Me.Visible = False
		frmNextForm.ShowDialog(Me)

	End Sub


#End Region

#Region "プライベートメソッド"

	Private Sub Initialize()

		'設定ファイルの読み込み
		XmlSettings.LoadFromXmlFile()
		Me.Location = New Point(XmlSettings.Instance.LocationX, XmlSettings.Instance.LocationY)
		Me.Size = New Size(XmlSettings.Instance.SizeX, XmlSettings.Instance.SizeY)
		Me.WindowState = XmlSettings.Instance.State
		Dim strSQL As String = ""
		Dim sqlProcess As New SQLProcess

		Try
			'都道府県名の取得
			strSQL = "SELECT T2.都道府県コード, T2.都道府県名 "
			strSQL &= "FROM M_自治体 AS T1 INNER JOIN "
			strSQL &= "M_都道府県 AS T2 ON T1.都道府県コード = T2.都道府県コード "
			strSQL &= "WHERE T1.業者フラグ = 1 "
			strSQL &= "GROUP BY T2.都道府県コード, T2.都道府県名 "
			strSQL &= "ORDER BY T2.都道府県コード"
			Dim dt As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
			SetComboValue(Me.cmbPrefectures, dt, True, True)
			'業者の取得
			strSQL = "SELECT 内部番号, 自治体名 AS 業者名 FROM M_自治体 "
			strSQL &= "ORDER BY 内部番号"
			dt = sqlProcess.DB_SELECT_DATATABLE(strSQL)
			SetComboValue(Me.cmbTrader, dt, True, False)

			Me.cmbPrefectures.SelectedIndex = 0
			Me.cmbTrader.SelectedIndex = 0

			Me.btnBack.Text = "戻る"

			'コンボボックスインデックス変更イベントの活性化
			AddHandler cmbPrefectures.SelectedIndexChanged, AddressOf cmbPrefectures_SelectedIndexChanged
			AddHandler cmbTrader.SelectedIndexChanged, AddressOf cmbTrader_SelectedIndexChanged

			SearchTrader()

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & ex.StackTrace)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		Finally

			sqlProcess.Close()

		End Try

	End Sub

	''' <summary>
	''' 業者一覧を特定条件でグリッドに表示する
	''' </summary>
	Private Sub SearchTrader()

		RemoveHandler C1FGridResult.RowColChange, AddressOf C1FGridResult_RowColChange
		Dim strSQL As String = ""
		Dim sqlProcess As New SQLProcess
		Dim strWhere As String = " WHERE "

		Try
			strSQL = "SELECT T1.内部番号, T1.履歴連番, T3.業者番号, T3.都道府県コード, T4.都道府県名, T3.自治体名, "
			strSQL &= "T1.有効年度, ISNULL(T1.有効期間From, '1900/01/01') AS 有効期間From, ISNULL(T1.有効期間To, '1900/01/01') AS 有効期間To, "
			strSQL &= "ISNULL(T1.申請期間From, '1900/01/01') AS 申請期間From, ISNULL(T1.申請期間To, '1900/01/01') AS 申請期間To, "
			strSQL &= "ISNULL(T1.申請日, '1900/01/01') AS 申請日, ISNULL(T1.認定日, '1900/01/01') AS 認定日, T1.備考 "
			strSQL &= "FROM T_業者登録 AS T1 INNER JOIN "
			strSQL &= "(SELECT 内部番号, MAX(履歴連番) AS 最大値 "
			strSQL &= "FROM T_業者登録 "
			strSQL &= "GROUP BY 内部番号) AS T2 ON T1.内部番号 = T2.内部番号 "
			strSQL &= "AND T1.履歴連番 = T2.最大値 INNER JOIN "
			strSQL &= "M_自治体 AS T3 ON T1.内部番号 = T3.内部番号 INNER JOIN "
			strSQL &= "M_都道府県 AS T4 ON T3.都道府県コード = T4.都道府県コード "
			'都道府県名検索
			If Not Me.cmbPrefectures.SelectedValue = "00" Then
				'「全て」以外の場合は検索条件に加える
				strSQL &= strWhere & "T3.都道府県コード = '" & Me.cmbPrefectures.SelectedValue & "'"
				strWhere = " AND "
			End If
			'業者検索
			If Not Me.cmbTrader.SelectedValue = "00" Then
				strSQL &= strWhere & "T1.内部番号 = '" & Me.cmbTrader.SelectedValue & "' "
				strWhere = " AND "
			End If
			strSQL &= "ORDER BY T1.内部番号"

			Dim dt As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
			Dim iRecCount As Integer = 0
			Me.C1FGridResult.Rows.Count = 1
			For iRow As Integer = 0 To dt.Rows.Count - 1
				iRecCount += 1
				Me.C1FGridResult.Rows.Count = iRecCount + 1
				Me.C1FGridResult(iRecCount, "No") = iRecCount
				Me.C1FGridResult(iRecCount, "内部番号") = dt.Rows(iRow)("内部番号")
				Me.C1FGridResult(iRecCount, "履歴連番") = dt.Rows(iRow)("履歴連番")
				Me.C1FGridResult(iRecCount, "業者番号") = dt.Rows(iRow)("業者番号")
				Me.C1FGridResult(iRecCount, "都道府県コード") = dt.Rows(iRow)("都道府県コード")
				Me.C1FGridResult(iRecCount, "都道府県名") = dt.Rows(iRow)("都道府県名")
				Me.C1FGridResult(iRecCount, "業者名") = dt.Rows(iRow)("自治体名")
				Me.C1FGridResult(iRecCount, "有効年度") = dt.Rows(iRow)("有効年度")
				Me.C1FGridResult(iRecCount, "有効期間From") = IIf(dt.Rows(iRow)("有効期間From") = "1900/01/01", "", CDate(dt.Rows(iRow)("有効期間From")).ToString("yyyy/MM/dd"))
				Me.C1FGridResult(iRecCount, "有効期間To") = IIf(dt.Rows(iRow)("有効期間To") = "1900/01/01", "", CDate(dt.Rows(iRow)("有効期間To")).ToString("yyyy/MM/dd"))
				Me.C1FGridResult(iRecCount, "申請期間From") = IIf(dt.Rows(iRow)("申請期間From") = "1900/01/01", "", CDate(dt.Rows(iRow)("申請期間From")).ToString("yyyy/MM/dd"))
				Me.C1FGridResult(iRecCount, "申請期間To") = IIf(dt.Rows(iRow)("申請期間To") = "1900/01/01", "", CDate(dt.Rows(iRow)("申請期間To")).ToString("yyyy/MM/dd"))
				Me.C1FGridResult(iRecCount, "申請日") = IIf(dt.Rows(iRow)("申請日") = "1900/01/01", "", CDate(dt.Rows(iRow)("申請日")).ToString("yyyy/MM/dd"))
				Me.C1FGridResult(iRecCount, "認定日") = IIf(dt.Rows(iRow)("認定日") = "1900/01/01", "", CDate(dt.Rows(iRow)("認定日")).ToString("yyyy/MM/dd"))
				Me.C1FGridResult(iRecCount, "備考") = dt.Rows(iRow)("備考")
			Next

			AddHandler C1FGridResult.RowColChange, AddressOf C1FGridResult_RowColChange
			Me.C1FGridResult.Row = 0

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & ex.StackTrace)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		Finally

			sqlProcess.Close()

		End Try

	End Sub

	''' <summary>
	''' 自治体一覧を特定条件でグリッドに表示する
	''' </summary>
	Private Sub SearchMuni()

		Dim strSQL As String = ""
		Dim sqlProcess As New SQLProcess
		Dim iIndex As Integer = Me.C1FGridResult.Row

		Try
			strSQL = "SELECT T1.レコード番号, T2.団体コード, T1.自治体名, ISNULL(T1.書類到着日, '1900/01/01') AS 書類到着日, T1.備考 "
			strSQL &= "FROM T_自治体登録 AS T1 INNER JOIN "
			strSQL &= "M_自治体 AS T2 ON T1.内部番号 = T2.内部番号 "
			strSQL &= "WHERE T1.内部番号 = '" & Me.C1FGridResult(iIndex, "内部番号") & "' "
			strSQL &= "AND T1.履歴連番 = " & Me.C1FGridResult(iIndex, "履歴連番") & " "
			strSQL &= "ORDER BY T1.レコード番号"
			Dim dt As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
			Dim iRecCount As Integer = 0
			For iRow As Integer = 0 To dt.Rows.Count - 1
				iRecCount += 1
				Me.C1FGridMuni.Rows.Count = iRecCount + 1
				Me.C1FGridMuni(iRecCount, "No") = dt.Rows(iRow)("レコード番号")
				Me.C1FGridMuni(iRecCount, "団体コード") = dt.Rows(iRow)("団体コード")
				Me.C1FGridMuni(iRecCount, "自治体名") = dt.Rows(iRow)("自治体名")
				Me.C1FGridMuni(iRecCount, "書類到着日") = IIf(dt.Rows(iRow)("書類到着日") = "1900/01/01", "", CDate(dt.Rows(iRow)("書類到着日")).ToString("yyyy/MM/dd"))
				Me.C1FGridMuni(iRecCount, "備考") = dt.Rows(iRow)("備考")
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