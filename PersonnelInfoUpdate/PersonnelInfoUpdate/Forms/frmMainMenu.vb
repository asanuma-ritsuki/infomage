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

		'Dim f As New frmMaintenance
		'm_Context.SetNextContext(f)

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

#End Region

End Class