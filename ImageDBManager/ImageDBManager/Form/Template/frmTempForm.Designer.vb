<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTempForm
	Inherits System.Windows.Forms.Form

	'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
	<System.Diagnostics.DebuggerNonUserCode()> _
	Protected Overrides Sub Dispose(ByVal disposing As Boolean)
		Try
			If disposing AndAlso components IsNot Nothing Then
				components.Dispose()
			End If
		Finally
			MyBase.Dispose(disposing)
		End Try
	End Sub

	'Windows フォーム デザイナーで必要です。
	Private components As System.ComponentModel.IContainer

	'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
	'Windows フォーム デザイナーを使用して変更できます。  
	'コード エディターを使って変更しないでください。
	<System.Diagnostics.DebuggerStepThrough()> _
	Private Sub InitializeComponent()
		Me.components = New System.ComponentModel.Container()
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTempForm))
		Me.C1StatusBar1 = New C1.Win.C1Ribbon.C1StatusBar()
		Me.lblScreenName = New C1.Win.C1Ribbon.RibbonLabel()
		Me.lblUserName = New C1.Win.C1Ribbon.RibbonLabel()
		Me.lblDate = New C1.Win.C1Ribbon.RibbonLabel()
		Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
		CType(Me.C1StatusBar1, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'C1StatusBar1
		'
		Me.C1StatusBar1.AutoSizeElement = C1.Framework.AutoSizeElement.Width
		Me.C1StatusBar1.LeftPaneItems.Add(Me.lblScreenName)
		Me.C1StatusBar1.LeftPaneItems.Add(Me.lblUserName)
		Me.C1StatusBar1.Location = New System.Drawing.Point(0, 539)
		Me.C1StatusBar1.Name = "C1StatusBar1"
		Me.C1StatusBar1.RightPaneItems.Add(Me.lblDate)
		Me.C1StatusBar1.Size = New System.Drawing.Size(784, 22)
		Me.C1StatusBar1.VisualStyle = C1.Win.C1Ribbon.VisualStyle.Office2010Silver
		'
		'lblScreenName
		'
		Me.lblScreenName.Name = "lblScreenName"
		Me.lblScreenName.SmallImage = CType(resources.GetObject("lblScreenName.SmallImage"), System.Drawing.Image)
		Me.lblScreenName.Text = "ScreenName"
		'
		'lblUserName
		'
		Me.lblUserName.Name = "lblUserName"
		Me.lblUserName.SmallImage = CType(resources.GetObject("lblUserName.SmallImage"), System.Drawing.Image)
		Me.lblUserName.Text = "UserName"
		'
		'lblDate
		'
		Me.lblDate.Name = "lblDate"
		Me.lblDate.SmallImage = CType(resources.GetObject("lblDate.SmallImage"), System.Drawing.Image)
		Me.lblDate.Text = "Date"
		'
		'Timer1
		'
		Me.Timer1.Interval = 1000
		'
		'frmTempForm
		'
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
		Me.ClientSize = New System.Drawing.Size(784, 561)
		Me.Controls.Add(Me.C1StatusBar1)
		Me.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.MaximizeBox = False
		Me.Name = "frmTempForm"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "frmTempForm"
		CType(Me.C1StatusBar1, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	Friend WithEvents C1StatusBar1 As C1.Win.C1Ribbon.C1StatusBar
	Friend WithEvents lblScreenName As C1.Win.C1Ribbon.RibbonLabel
	Friend WithEvents lblUserName As C1.Win.C1Ribbon.RibbonLabel
	Friend WithEvents lblDate As C1.Win.C1Ribbon.RibbonLabel
	Friend WithEvents Timer1 As Timer
End Class
