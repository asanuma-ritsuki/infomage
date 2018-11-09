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

		'キー入力を受け付ける
		Me.KeyPreview = True
		CaptionDisplayMode = StatusDisplayMode.None

	End Sub

#End Region

#Region "メニューオブジェクトイベント"

	''' <summary>
	''' [ファイル][終了]
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub menuExit_Click(sender As Object, e As EventArgs) Handles menuExit.Click

		If MessageBox.Show("アプリケーションを終了します" & vbNewLine & "よろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
			Application.Exit()
		End If

	End Sub

	''' <summary>
	''' [ツール][接続設定]
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub menuConnection_Click(sender As Object, e As EventArgs) Handles menuConnection.Click

		Dim f As New frmConnectionProperty
		f.ShowDialog(Me)

	End Sub

#End Region

#Region "オブジェクトイベント"

	''' <summary>
	''' 運用画面ボタン押下時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub btnOperation_Click(sender As Object, e As EventArgs) Handles btnOperation.Click

		Dim frmNextForm As New frmMain
		m_Context.SetNextContext(frmNextForm)

	End Sub

	''' <summary>
	''' 各種メンテナンスボタン押下時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub btnMaintenance_Click(sender As Object, e As EventArgs) Handles btnMaintenance.Click

		Dim f As New frmMasterManage
		m_Context.SetNextContext(f)

	End Sub

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

	'Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

	'	Dim strSQL As String = ""
	'	Dim sqlProcess As New SQLProcess

	'	Try
	'		strSQL = "SELECT JOB_ID, Shiori_ID, 項目1, 項目2, 項目3, 項目4, しおり "
	'		strSQL &= "FROM T_しおりツール_しおりリスト "
	'		strSQL &= "WHERE JOB_ID = 4"
	'		Dim dt As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
	'		Dim iCount As Integer = 0

	'		For iRow As Integer = 0 To dt.Rows.Count - 1
	'			iCount += 1
	'			Dim strShiori As String = dt.Rows(iRow)("しおり").Replace("'", "''")
	'			Dim strItem1 As String = dt.Rows(iRow)("項目1").Replace("'", "''")
	'			Dim strItem2 As String = dt.Rows(iRow)("項目2").Replace("'", "''")
	'			Dim strItem3 As String = dt.Rows(iRow)("項目3").Replace("'", "''")
	'			Dim strItem4 As String = dt.Rows(iRow)("項目4").Replace("'", "''")

	'			If Not IsNull(strItem4) Then
	'				strShiori = strShiori.Replace(strItem4, "_" & strItem4)
	'			End If
	'			If Not IsNull(strItem3) Then
	'				strShiori = strShiori.Replace(strItem3, "_" & strItem3)
	'			End If
	'			If Not IsNull(strItem2) Then
	'				strShiori = strShiori.Replace(strItem2, "_" & strItem2)
	'			End If
	'			If Not IsNull(strItem1) Then
	'				strShiori = strShiori.Replace(strItem1, "_" & strItem1)
	'			End If
	'			If Strings.Left(strShiori, 1) = "_" Then
	'				strShiori = strShiori.Remove(0, 1)
	'			End If
	'			strSQL = "INSERT INTO T_しおりリストTEMP(JOB_ID, Shiori_ID, しおり) VALUES("
	'			strSQL &= dt.Rows(iRow)("JOB_ID")
	'			strSQL &= ", " & dt.Rows(iRow)("Shiori_ID")
	'			strSQL &= ", '" & strShiori & "')"
	'			sqlProcess.DB_UPDATE(strSQL)

	'			strSQL = "UPDATE T_しおりツール_しおりリスト SET しおり = '" & strShiori & "' "
	'			strSQL &= "WHERE JOB_ID = " & dt.Rows(iRow)("JOB_ID") & " "
	'			strSQL &= "AND Shiori_ID = " & dt.Rows(iRow)("Shiori_ID")
	'			sqlProcess.DB_UPDATE(strSQL)
	'		Next

	'		MessageBox.Show("終了しました" & vbNewLine & iCount & "件", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information)

	'	Catch ex As Exception

	'		MessageBox.Show(ex.Message)

	'	Finally

	'		sqlProcess.Close()

	'	End Try

	'End Sub

#End Region

End Class