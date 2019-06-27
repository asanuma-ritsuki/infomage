Imports C1.Win.C1FlexGrid
Imports System.Globalization

Public Class frmMainMenu

#Region "フォームイベント"

	''' <summary>
	''' フォームロード時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub frmMainMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load

		Me.Text = My.Application.Info.ProductName & " Ver." &
			My.Application.Info.Version.ToString & " - [メインメニュー]"

		Initialize()

	End Sub

#End Region

#Region "オブジェクトイベント"

	'''' <summary>
	'''' C1FlexGridオーナー描画時
	'''' </summary>
	'''' <param name="sender"></param>
	'''' <param name="e"></param>
	'Private Sub C1FGridResult_OwnerDrawCell(sender As Object, e As OwnerDrawCellEventArgs) Handles C1FGridResult.OwnerDrawCell

	'	If Not Me.C1FGridResult.Cols(e.Col).UserData Is Nothing AndAlso e.Row >= Me.C1FGridResult.Rows.Fixed Then
	'		Dim value As Double
	'		If Double.TryParse(Me.C1FGridResult.GetDataDisplay(e.Row, e.Col), NumberStyles.Any, CultureInfo.CurrentCulture, value) Then
	'			'バーの拡張幅を計算する
	'			Dim rc As Rectangle = e.Bounds
	'			Dim max As Double = CType(Me.C1FGridResult.Cols(e.Col).UserData, Double)
	'			rc.Width = CType((System.Math.Floor(Me.C1FGridResult.Cols(e.Col).WidthDisplay * value / max)), Integer)

	'			'背景を描画する
	'			e.DrawCell(DrawCellFlags.Background Or DrawCellFlags.Border)

	'			'バーを描画する
	'			rc.Inflate(-2, -2)
	'			e.Graphics.FillRectangle(Brushes.Gold, rc)
	'			rc.Inflate(-1, -1)
	'			e.Graphics.FillRectangle(Brushes.LightGoldenrodYellow, rc)

	'			'セルの内容を描画する
	'			e.DrawCell(DrawCellFlags.Content)
	'		End If
	'	End If
	'   End Sub

	''' <summary>
	''' 案件名コンボボックスインデックス変更時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub cmbName_SelectedIndexChanged(sender As Object, e As EventArgs)

		Dim strSQL As String = ""
		Dim sqlProcess As New SQLProcess

		Try
			strSQL = "SELECT 備考 FROM M_案件管理 "
			strSQL &= "WHERE 受付ID = '" & Me.cmbName.SelectedValue & "'"
			Me.txtRemarks.Text = sqlProcess.DB_EXECUTE_SCALAR(strSQL)
			SearchGrid()

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & ex.StackTrace)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		Finally

			sqlProcess.Close()

		End Try

	End Sub

	''' <summary>
	''' 戻るボタン押下時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click

		If MessageBox.Show("アプリケーションを終了します" & vbNewLine & "よろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
			Application.Exit()
		End If
		'If MessageBox.Show("ログイン画面に戻ります" & vbNewLine & "よろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

		'	Dim frmNextForm As New frmLogin
		'	m_Context.SetNextContext(frmNextForm)

		'End If

	End Sub

	''' <summary>
	''' 管理画面ボタン押下時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub btnManage_Click(sender As Object, e As EventArgs) Handles btnManage.Click

		Dim frmNextForm As New frmManage
		m_Context.SetNextContext(frmNextForm)

	End Sub


#End Region

#Region "プライベートメソッド"

	''' <summary>
	''' 初期化処理
	''' </summary>
	Private Sub Initialize()
		''==================================================
		''棒グラフ描画準備
		''各数値列にスケール情報をアタッチする
		'Dim r1 As Integer = Me.C1FGridResult.Rows.Fixed
		'Dim r2 As Integer = Me.C1FGridResult.Rows.Count - 1
		'Dim s As String = Nothing
		'Dim barCols() As String = New String() {"進捗状況"}

		'For Each s In barCols
		'	Dim col As Column = Me.C1FGridResult.Cols(s)
		'	Dim max As Double = Me.C1FGridResult.Aggregate(AggregateEnum.Max, r1, col.Index, r2, col.Index)
		'	col.UserData = max
		'Next
		''オーナー描画モードにする
		'Me.C1FGridResult.DrawMode = DrawModeEnum.OwnerDraw
		''==================================================
		Me.lblUser.Text = m_LoginUser.UserName
		Me.lblManage.Text = IIf(m_LoginUser.ManageFlag = True, "管理者", "入力者")
		Me.btnBack.Text = "終了"

		Dim strSQL As String = ""
		Dim sqlProcess As New SQLProcess
		Dim dt As DataTable

		Try
			'案件情報が存在していた場合は、案件名を検索してコンボボックスをロックする
			'管理者関係のオブジェクトを使用不可とする
			If Not IsNull(m_LoginUser.LoginItem) Then
				'案件情報が存在した
				'案件一覧をコンボボックスにセットする
				strSQL = "SELECT 受付ID, 案件名 "
				strSQL &= "FROM M_案件管理 "
				strSQL &= "WHERE ISNULL(終了日, '2050/01/01') > '" & Date.Now.ToString("yyyy/MM/dd") & "' "
				strSQL &= "AND 受付ID = '" & m_LoginUser.LoginItem & "'"
				dt = sqlProcess.DB_SELECT_DATATABLE(strSQL)
				If dt.Rows.Count = 0 Then
					MessageBox.Show("案件が存在しないか終了しています" & vbNewLine & "管理者に問い合わせてください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
					Exit Sub
				End If
				SetComboValue(Me.cmbName, dt, False)
				Me.cmbName.SelectedIndex = 0
				Me.cmbName.Enabled = False
				Me.btnManage.Visible = False
				SearchGrid()
			Else
				'案件情報が存在しない
				'案件一覧をコンボボックスにセットする
				strSQL = "SELECT 受付ID, 案件名 "
				strSQL &= "FROM M_案件管理 "
				strSQL &= "WHERE 終了日 > '" & Date.Now.ToString("yyyy/MM/dd") & "' "
				strSQL &= "ORDER BY 受付ID DESC"
				dt = sqlProcess.DB_SELECT_DATATABLE(strSQL)
				SetComboValue(Me.cmbName, dt, True)
				Me.cmbName.SelectedIndex = 0
				Me.cmbName.Enabled = True
				'オートコンプリートモードの設定
				Me.cmbName.AutoCompleteMode = AutoCompleteMode.SuggestAppend
				Me.cmbName.AutoCompleteSource = AutoCompleteSource.ListItems
				Me.btnManage.Enabled = True

			End If

			'セットし終わってからコンボボックスのイベントを有効にする
			AddHandler cmbName.SelectedIndexChanged, AddressOf cmbName_SelectedIndexChanged

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & ex.StackTrace)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		Finally

			sqlProcess.Close()

		End Try

	End Sub

	''' <summary>
	''' グリッド表示
	''' </summary>
	Private Sub SearchGrid()

		Dim strSQL As String = ""
		Dim sqlProcess As New SQLProcess

		Try
			strSQL = "SELECT 受付ID, ロットID, フルパス, イメージ数, 入力数, 差替え数, コマ抜け数, 正常数, 最終入力者, 入力中, 進捗状況 "
			strSQL &= "FROM T_ロット管理 "
			strSQL &= "WHERE 受付ID = '" & Me.cmbName.SelectedValue & "' "
			strSQL &= "ORDER BY ロットID"
			Dim dt As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
			Me.C1FGridResult.Rows.Count = 1
			Dim iRecCount As Integer = 0
			'==========
			'値参照用変数
			Dim iImage As Integer = 0
			Dim iEntry As Integer = 0
			Dim iReplace As Integer = 0
			Dim iKoma As Integer = 0
			Dim iNormal As Integer = 0
			'==========
			For iRow As Integer = 0 To dt.Rows.Count - 1
				'カウント
				CountItems(dt.Rows(iRow)("受付ID"), dt.Rows(iRow)("ロットID"), dt.Rows(iRow)("フルパス"),
						   iImage, iEntry, iReplace, iKoma, iNormal)
				iRecCount += 1
				Me.C1FGridResult.Rows.Count += 1
				Me.C1FGridResult(iRecCount, "No") = iRecCount
				Me.C1FGridResult(iRecCount, "ロットID") = dt.Rows(iRow)("ロットID")
				Me.C1FGridResult(iRecCount, "フルパス") = dt.Rows(iRow)("フルパス")
				Me.C1FGridResult(iRecCount, "イメージ数") = iImage
				Me.C1FGridResult(iRecCount, "入力数") = iEntry
				Me.C1FGridResult(iRecCount, "差替え数") = iReplace
				Me.C1FGridResult(iRecCount, "コマ抜け数") = iKoma
				Me.C1FGridResult(iRecCount, "正常数") = iNormal
				Me.C1FGridResult(iRecCount, "最終入力者") = dt.Rows(iRow)("最終入力者")
				Me.C1FGridResult(iRecCount, "入力中") = dt.Rows(iRow)("入力中")
				Me.C1FGridResult(iRecCount, "進捗状況") = dt.Rows(iRow)("進捗状況")
			Next

			ChangeBackColor()

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & ex.StackTrace)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		Finally

			sqlProcess.Close()

		End Try

	End Sub

	''' <summary>
	''' ロット単位で各数量をカウントして参照変数に格納する
	''' </summary>
	''' <param name="strReceiptID"></param>
	''' <param name="strLotID"></param>
	''' <param name="strFullPath"></param>
	''' <param name="iImage"></param>
	''' <param name="iEntry"></param>
	''' <param name="iReplace"></param>
	''' <param name="iKoma"></param>
	''' <param name="iNormal"></param>
	Private Sub CountItems(ByVal strReceiptID As String, ByVal strLotID As String, ByVal strFullPath As String,
						   ByRef iImage As Integer, ByRef iEntry As Integer, ByRef iReplace As Integer,
						   ByRef iKoma As Integer, ByRef iNormal As Integer)

		Dim strSQL As String = ""
		Dim sqlProcess As New SQLProcess

		Try
			Dim strPatterns As String() = {"*.jpg", "*.tif", "*.pdf"}
			Dim strFiles As String() = GetFilesMostDeep(strFullPath, strPatterns)
			iImage = strFiles.Count

			strSQL = "SELECT COUNT(ロットID) AS 入力数, ISNULL(MAX(差替え), 0) AS 差替え数, ISNULL(MAX(コマ抜け), 0) AS コマ抜け数, "
			strSQL &= "ISNULL(SUM(正常), 0) AS 正常数 "
			strSQL &= "FROM T_エントリー "
			strSQL &= "WHERE 受付ID = '" & strReceiptID & "' "
			strSQL &= "AND ロットID = '" & strLotID & "'"
			Dim dt As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
			If dt.Rows.Count > 0 Then
				iEntry = dt.Rows(0)("入力数")
				iReplace = dt.Rows(0)("差替え数")
				iKoma = dt.Rows(0)("コマ抜け数")
				iNormal = dt.Rows(0)("正常数")
			Else
				iEntry = 0
				iReplace = 0
				iKoma = 0
				iNormal = 0
			End If

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & ex.StackTrace)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		Finally

			sqlProcess.Close()

		End Try

	End Sub

	''' <summary>
	''' グリッドの進捗状況によって背景色を変える
	''' </summary>
	Private Sub ChangeBackColor()

		'カスタムスタイルを作成する
		With Me.C1FGridResult
			'開始前スタイル
			.Styles.Add("StyleStart")
			.Styles("StyleStart").BackColor = Color.White
			.Styles("StyleStart").ForeColor = Color.Black
			'中断スタイル
			.Styles.Add("StyleAbort")
			.Styles("StyleAbort").BackColor = Color.LightCoral
			.Styles("StyleAbort").ForeColor = Color.Black
			'入力中スタイル
			.Styles.Add("StyleInput")
			.Styles("StyleInput").BackColor = Color.LightSkyBlue
			.Styles("StyleInput").ForeColor = Color.Black
			'終了スタイル
			.Styles.Add("StyleFinish")
			.Styles("StyleFinish").BackColor = Color.LightSlateGray
			.Styles("StyleFinish").ForeColor = Color.White
		End With

		Me.C1FGridResult.BeginUpdate()

		For iRow As Integer = 1 To Me.C1FGridResult.Rows.Count - 1

			Select Case Me.C1FGridResult(iRow, "進捗状況")
				Case "開始前"
					Me.C1FGridResult.Rows(iRow).Style = Me.C1FGridResult.Styles("StyleStart")
				Case "中断"
					Me.C1FGridResult.Rows(iRow).Style = Me.C1FGridResult.Styles("StyleAbort")
				Case "入力中"
					Me.C1FGridResult.Rows(iRow).Style = Me.C1FGridResult.Styles("StyleInput")
				Case "終了"
					Me.C1FGridResult.Rows(iRow).Style = Me.C1FGridResult.Styles("StyleFinish")
			End Select
		Next

		Me.C1FGridResult.EndUpdate()

	End Sub

#End Region

End Class