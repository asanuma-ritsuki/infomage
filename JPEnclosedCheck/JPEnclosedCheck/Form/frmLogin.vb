Public Class frmLogin

#Region "フォームイベント"

	''' <summary>
	''' フォームロード時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load

		Me.Text = My.Application.Info.ProductName & " Ver." &
			My.Application.Info.Version.ToString & " - [ログイン]"

		Initialize()

	End Sub

#End Region

#Region "オブジェクトイベント"

	''' <summary>
	''' ログインボタン押下時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
		'作業者名を確定し入力フォームに移動
		If Me.cmbUserName.Text = "" Then
			MessageBox.Show("ユーザー名を選択または入力してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Exit Sub
		End If

		Dim frm As New frmMain
		frm.UserName = Me.cmbUserName.Text
		frm.Show()
		Me.Hide()

	End Sub

	''' <summary>
	''' コンボボックスエンターキー押下時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub cmbUserName_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbUserName.KeyPress

		If e.KeyChar = Chr(13) Then
			btnLogin_Click(Me, EventArgs.Empty)
		End If

	End Sub

	''' <summary>
	''' 接続設定ボタン押下時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub btnConnectionSetting_Click(sender As Object, e As EventArgs) Handles btnConnectionSetting.Click

		Dim frm As New frmConnectionSetting
		AddHandler frm.FormClosed, AddressOf frmConnectionSetting_FormClosed
		frm.ShowDialog()

	End Sub

	''' <summary>
	''' 接続設定画面が閉じたとき
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub frmConnectionSetting_FormClosed(sender As Object, e As FormClosedEventArgs)

		Dim frm As frmConnectionSetting = DirectCast(sender, frmConnectionSetting)
		Me.cmbUserName.Items.Clear()
		frmLogin_Load(Me, EventArgs.Empty)
		Me.cmbUserName.Focus()

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
			strSQL = "SELECT 作業者 FROM T_リーフ6チェック "
			strSQL &= "GROUP BY 作業者 "
			strSQL &= "ORDER BY 作業者"
			Dim dt As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
			For iRow As Integer = 0 To dt.Rows.Count - 1
				If Not IsNull(dt.Rows(iRow)("作業者")) Then
					Me.cmbUserName.Items.Add(dt.Rows(iRow)("作業者"))
				End If
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