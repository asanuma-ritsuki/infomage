<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmTempForm
	Inherits C1.Win.C1Ribbon.C1RibbonForm

	'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
	<System.Diagnostics.DebuggerNonUserCode()>
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
	<System.Diagnostics.DebuggerStepThrough()>
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
		Me.C1StatusBar1.Location = New System.Drawing.Point(0, 545)
		Me.C1StatusBar1.Name = "C1StatusBar1"
		Me.C1StatusBar1.RightPaneItems.Add(Me.lblDate)
		Me.C1StatusBar1.Size = New System.Drawing.Size(792, 22)
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
		Me.ClientSize = New System.Drawing.Size(792, 567)
		Me.Controls.Add(Me.C1StatusBar1)
		Me.Font = New System.Drawing.Font("Meiryo UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
		Me.KeyPreview = True
		Me.Name = "frmTempForm"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "frmTempForm"
		Me.VisualStyleHolder = C1.Win.C1Ribbon.VisualStyle.Custom
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
