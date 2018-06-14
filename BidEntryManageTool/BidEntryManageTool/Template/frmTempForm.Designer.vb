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
		Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
		Me.C1StatusBar1 = New C1.Win.C1Ribbon.C1StatusBar()
		Me.RibbonSeparator1 = New C1.Win.C1Ribbon.RibbonSeparator()
		Me.lblProgress = New C1.Win.C1Ribbon.RibbonLabel()
		Me.lblUser = New C1.Win.C1Ribbon.RibbonLabel()
		Me.lblDate = New C1.Win.C1Ribbon.RibbonLabel()
		Me.RibbonSeparator2 = New C1.Win.C1Ribbon.RibbonSeparator()
		Me.btnBack = New C1.Win.C1Ribbon.RibbonButton()
		CType(Me.C1StatusBar1, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'Timer1
		'
		'
		'C1StatusBar1
		'
		Me.C1StatusBar1.AutoSizeElement = C1.Framework.AutoSizeElement.Width
		Me.C1StatusBar1.LeftPaneItems.Add(Me.lblProgress)
		Me.C1StatusBar1.Location = New System.Drawing.Point(0, 539)
		Me.C1StatusBar1.Name = "C1StatusBar1"
		Me.C1StatusBar1.RightPaneItems.Add(Me.lblUser)
		Me.C1StatusBar1.RightPaneItems.Add(Me.RibbonSeparator1)
		Me.C1StatusBar1.RightPaneItems.Add(Me.lblDate)
		Me.C1StatusBar1.RightPaneItems.Add(Me.RibbonSeparator2)
		Me.C1StatusBar1.RightPaneItems.Add(Me.btnBack)
		Me.C1StatusBar1.Size = New System.Drawing.Size(784, 22)
		Me.C1StatusBar1.VisualStyle = C1.Win.C1Ribbon.VisualStyle.Office2010Silver
		'
		'RibbonSeparator1
		'
		Me.RibbonSeparator1.Name = "RibbonSeparator1"
		'
		'lblProgress
		'
		Me.lblProgress.Name = "lblProgress"
		Me.lblProgress.SmallImage = Global.BidEntryManageTool.My.Resources.Resources.comment
		Me.lblProgress.Text = "lblProgress"
		'
		'lblUser
		'
		Me.lblUser.Name = "lblUser"
		Me.lblUser.SmallImage = Global.BidEntryManageTool.My.Resources.Resources.xfn
		Me.lblUser.Text = "lblUser"
		'
		'lblDate
		'
		Me.lblDate.Name = "lblDate"
		Me.lblDate.SmallImage = Global.BidEntryManageTool.My.Resources.Resources.clock
		Me.lblDate.Text = "lblDate"
		'
		'RibbonSeparator2
		'
		Me.RibbonSeparator2.Name = "RibbonSeparator2"
		'
		'btnBack
		'
		Me.btnBack.Name = "btnBack"
		Me.btnBack.SmallImage = Global.BidEntryManageTool.My.Resources.Resources.house_go
		Me.btnBack.Text = "終了"
		'
		'frmTempForm
		'
		Me.AllowDrop = True
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
		Me.ClientSize = New System.Drawing.Size(784, 561)
		Me.Controls.Add(Me.C1StatusBar1)
		Me.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
		Me.KeyPreview = True
		Me.Name = "frmTempForm"
		Me.Text = "frmTempForm"
		CType(Me.C1StatusBar1, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	Friend WithEvents Timer1 As Timer
	Friend WithEvents C1StatusBar1 As C1.Win.C1Ribbon.C1StatusBar
	Friend WithEvents lblProgress As C1.Win.C1Ribbon.RibbonLabel
	Friend WithEvents lblUser As C1.Win.C1Ribbon.RibbonLabel
	Friend WithEvents RibbonSeparator1 As C1.Win.C1Ribbon.RibbonSeparator
	Friend WithEvents lblDate As C1.Win.C1Ribbon.RibbonLabel
	Friend WithEvents RibbonSeparator2 As C1.Win.C1Ribbon.RibbonSeparator
	Friend WithEvents btnBack As C1.Win.C1Ribbon.RibbonButton
End Class
