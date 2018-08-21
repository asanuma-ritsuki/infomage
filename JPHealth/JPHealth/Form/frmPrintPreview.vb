Public Class frmPrintPreview

#Region "プライベート変数"

	Private _tabPageManager As TabPageManager

#End Region

#Region "フォームイベント"

	''' <summary>
	''' フォームロード時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub frmPrintPreview_Load(sender As Object, e As EventArgs) Handles MyBase.Load

		Me.Text = My.Application.Info.ProductName & " Ver." &
			My.Application.Info.Version.ToString & " - [印刷プレビュー]"

		Initialize()

	End Sub

#End Region

#Region "オブジェクトイベント"

	Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click

		Me.Close()

	End Sub

#End Region

#Region "プライベートメソッド"

	Private Sub Initialize()

		Me.lblProgress.Visible = False
		Me.LabelHost1.Visible = False
		Me.LabelHost2.Visible = False
		Me.LabelHost3.Visible = False
		Me.LabelHost4.Visible = False
		Me.RibbonLabel1.Visible = False
		Me.RibbonLabel2.Visible = False
		Me.RibbonLabel3.Visible = False
		Me.RibbonLabel4.Visible = False
		Me.RibbonSeparator1.Visible = False
		Me.RibbonSeparator4.Visible = False
		Me.RibbonSeparator5.Visible = False
		Me.RibbonSeparator6.Visible = False
		Me.RibbonSeparator7.Visible = False

		Me.btnBack.Text = "閉じる"

		'CaptionDisplayMode = StatusDisplayMode.None

		'一般以外のTabPageを非表示にする
		_tabPageManager = New TabPageManager(Me.TabControl1)
		For i As Integer = 1 To Me.TabControl1.TabPages.Count - 1
			_tabPageManager.ChangeTabPageVisible(i, False)
		Next

	End Sub

#End Region

End Class