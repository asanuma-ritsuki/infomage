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
		Me.lblProgress = New C1.Win.C1Ribbon.RibbonLabel()
		Me.RibbonSeparator1 = New C1.Win.C1Ribbon.RibbonSeparator()
		Me.lblUser = New C1.Win.C1Ribbon.RibbonLabel()
		Me.RibbonSeparator2 = New C1.Win.C1Ribbon.RibbonSeparator()
		Me.lblDate = New C1.Win.C1Ribbon.RibbonLabel()
		Me.RibbonSeparator3 = New C1.Win.C1Ribbon.RibbonSeparator()
		Me.btnBack = New C1.Win.C1Ribbon.RibbonButton()
		Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
		Me.LabelHost1 = New JPHealth.LabelHost()
		Me.RibbonLabel1 = New C1.Win.C1Ribbon.RibbonLabel()
		Me.RibbonSeparator4 = New C1.Win.C1Ribbon.RibbonSeparator()
		Me.LabelHost2 = New JPHealth.LabelHost()
		Me.RibbonLabel2 = New C1.Win.C1Ribbon.RibbonLabel()
		Me.RibbonSeparator5 = New C1.Win.C1Ribbon.RibbonSeparator()
		Me.LabelHost3 = New JPHealth.LabelHost()
		Me.RibbonLabel3 = New C1.Win.C1Ribbon.RibbonLabel()
		Me.RibbonSeparator6 = New C1.Win.C1Ribbon.RibbonSeparator()
		Me.LabelHost4 = New JPHealth.LabelHost()
		Me.RibbonLabel4 = New C1.Win.C1Ribbon.RibbonLabel()
		Me.RibbonSeparator7 = New C1.Win.C1Ribbon.RibbonSeparator()
		Me.LabelHost5 = New JPHealth.LabelHost()
		Me.RibbonLabel5 = New C1.Win.C1Ribbon.RibbonLabel()
		Me.RibbonSeparator8 = New C1.Win.C1Ribbon.RibbonSeparator()
		CType(Me.C1StatusBar1, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'C1StatusBar1
		'
		Me.C1StatusBar1.AutoSizeElement = C1.Framework.AutoSizeElement.Width
		Me.C1StatusBar1.LeftPaneItems.Add(Me.lblProgress)
		Me.C1StatusBar1.LeftPaneItems.Add(Me.RibbonSeparator1)
		Me.C1StatusBar1.LeftPaneItems.Add(Me.LabelHost1)
		Me.C1StatusBar1.LeftPaneItems.Add(Me.RibbonLabel1)
		Me.C1StatusBar1.LeftPaneItems.Add(Me.RibbonSeparator4)
		Me.C1StatusBar1.LeftPaneItems.Add(Me.LabelHost2)
		Me.C1StatusBar1.LeftPaneItems.Add(Me.RibbonLabel2)
		Me.C1StatusBar1.LeftPaneItems.Add(Me.RibbonSeparator5)
		Me.C1StatusBar1.LeftPaneItems.Add(Me.LabelHost3)
		Me.C1StatusBar1.LeftPaneItems.Add(Me.RibbonLabel3)
		Me.C1StatusBar1.LeftPaneItems.Add(Me.RibbonSeparator6)
		Me.C1StatusBar1.LeftPaneItems.Add(Me.LabelHost4)
		Me.C1StatusBar1.LeftPaneItems.Add(Me.RibbonLabel4)
		Me.C1StatusBar1.LeftPaneItems.Add(Me.RibbonSeparator7)
		Me.C1StatusBar1.LeftPaneItems.Add(Me.LabelHost5)
		Me.C1StatusBar1.LeftPaneItems.Add(Me.RibbonLabel5)
		Me.C1StatusBar1.LeftPaneItems.Add(Me.RibbonSeparator8)
		Me.C1StatusBar1.Location = New System.Drawing.Point(0, 707)
		Me.C1StatusBar1.Name = "C1StatusBar1"
		Me.C1StatusBar1.RightPaneItems.Add(Me.lblUser)
		Me.C1StatusBar1.RightPaneItems.Add(Me.RibbonSeparator2)
		Me.C1StatusBar1.RightPaneItems.Add(Me.lblDate)
		Me.C1StatusBar1.RightPaneItems.Add(Me.RibbonSeparator3)
		Me.C1StatusBar1.RightPaneItems.Add(Me.btnBack)
		Me.C1StatusBar1.Size = New System.Drawing.Size(1008, 22)
		Me.C1StatusBar1.VisualStyle = C1.Win.C1Ribbon.VisualStyle.Office2010Silver
		'
		'lblProgress
		'
		Me.lblProgress.Name = "lblProgress"
		Me.lblProgress.SmallImage = Global.JPHealth.My.Resources.Resources.comment
		Me.lblProgress.Text = "lblProgress"
		'
		'RibbonSeparator1
		'
		Me.RibbonSeparator1.Name = "RibbonSeparator1"
		'
		'lblUser
		'
		Me.lblUser.Name = "lblUser"
		Me.lblUser.SmallImage = Global.JPHealth.My.Resources.Resources.xfn
		Me.lblUser.Text = "User"
		'
		'RibbonSeparator2
		'
		Me.RibbonSeparator2.Name = "RibbonSeparator2"
		'
		'lblDate
		'
		Me.lblDate.Name = "lblDate"
		Me.lblDate.SmallImage = Global.JPHealth.My.Resources.Resources.clock
		Me.lblDate.Text = "Date"
		'
		'RibbonSeparator3
		'
		Me.RibbonSeparator3.Name = "RibbonSeparator3"
		'
		'btnBack
		'
		Me.btnBack.Name = "btnBack"
		Me.btnBack.SmallImage = Global.JPHealth.My.Resources.Resources.house_go
		Me.btnBack.Text = "終了"
		'
		'LabelHost1
		'
		Me.LabelHost1.BackColor = System.Drawing.Color.White
		Me.LabelHost1.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.LabelHost1.Height = 16
		Me.LabelHost1.Name = "LabelHost1"
		Me.LabelHost1.Text = "サンプル"
		Me.LabelHost1.Width = 50
		'
		'RibbonLabel1
		'
		Me.RibbonLabel1.Name = "RibbonLabel1"
		Me.RibbonLabel1.Text = "…印刷可能"
		'
		'RibbonSeparator4
		'
		Me.RibbonSeparator4.Name = "RibbonSeparator4"
		'
		'LabelHost2
		'
		Me.LabelHost2.BackColor = System.Drawing.Color.Yellow
		Me.LabelHost2.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.LabelHost2.Height = 16
		Me.LabelHost2.Name = "LabelHost2"
		Me.LabelHost2.Text = "サンプル"
		Me.LabelHost2.Width = 50
		'
		'RibbonLabel2
		'
		Me.RibbonLabel2.Name = "RibbonLabel2"
		Me.RibbonLabel2.Text = "…要修正"
		'
		'RibbonSeparator5
		'
		Me.RibbonSeparator5.Name = "RibbonSeparator5"
		'
		'LabelHost3
		'
		Me.LabelHost3.BackColor = System.Drawing.Color.LightGreen
		Me.LabelHost3.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.LabelHost3.Height = 16
		Me.LabelHost3.Name = "LabelHost3"
		Me.LabelHost3.Text = "サンプル"
		Me.LabelHost3.Width = 50
		'
		'RibbonLabel3
		'
		Me.RibbonLabel3.Name = "RibbonLabel3"
		Me.RibbonLabel3.Text = "…印刷済"
		'
		'RibbonSeparator6
		'
		Me.RibbonSeparator6.Name = "RibbonSeparator6"
		'
		'LabelHost4
		'
		Me.LabelHost4.BackColor = System.Drawing.Color.DeepSkyBlue
		Me.LabelHost4.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.LabelHost4.Height = 16
		Me.LabelHost4.Name = "LabelHost4"
		Me.LabelHost4.Text = "サンプル"
		Me.LabelHost4.Width = 50
		'
		'RibbonLabel4
		'
		Me.RibbonLabel4.Name = "RibbonLabel4"
		Me.RibbonLabel4.Text = "…完了"
		'
		'RibbonSeparator7
		'
		Me.RibbonSeparator7.Name = "RibbonSeparator7"
		'
		'LabelHost5
		'
		Me.LabelHost5.BackColor = System.Drawing.Color.LightSlateGray
		Me.LabelHost5.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.LabelHost5.ForeColor = System.Drawing.Color.White
		Me.LabelHost5.Height = 16
		Me.LabelHost5.Name = "LabelHost5"
		Me.LabelHost5.Text = "サンプル"
		Me.LabelHost5.Width = 50
		'
		'RibbonLabel5
		'
		Me.RibbonLabel5.Name = "RibbonLabel5"
		Me.RibbonLabel5.Text = "…削除"
		'
		'RibbonSeparator8
		'
		Me.RibbonSeparator8.Name = "RibbonSeparator8"
		'
		'frmTempForm
		'
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
		Me.ClientSize = New System.Drawing.Size(1008, 729)
		Me.Controls.Add(Me.C1StatusBar1)
		Me.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
		Me.Name = "frmTempForm"
		Me.Text = "frmTempForm"
		CType(Me.C1StatusBar1, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	Friend WithEvents C1StatusBar1 As C1.Win.C1Ribbon.C1StatusBar
	Friend WithEvents lblProgress As C1.Win.C1Ribbon.RibbonLabel
	Friend WithEvents RibbonSeparator1 As C1.Win.C1Ribbon.RibbonSeparator
	Friend WithEvents lblUser As C1.Win.C1Ribbon.RibbonLabel
	Friend WithEvents RibbonSeparator2 As C1.Win.C1Ribbon.RibbonSeparator
	Friend WithEvents lblDate As C1.Win.C1Ribbon.RibbonLabel
	Friend WithEvents RibbonSeparator3 As C1.Win.C1Ribbon.RibbonSeparator
	Friend WithEvents btnBack As C1.Win.C1Ribbon.RibbonButton
	Friend WithEvents Timer1 As Timer
	Friend WithEvents LabelHost1 As LabelHost
	Friend WithEvents RibbonLabel1 As C1.Win.C1Ribbon.RibbonLabel
	Friend WithEvents RibbonSeparator4 As C1.Win.C1Ribbon.RibbonSeparator
	Friend WithEvents LabelHost2 As LabelHost
	Friend WithEvents RibbonLabel2 As C1.Win.C1Ribbon.RibbonLabel
	Friend WithEvents RibbonSeparator5 As C1.Win.C1Ribbon.RibbonSeparator
	Friend WithEvents LabelHost3 As LabelHost
	Friend WithEvents RibbonLabel3 As C1.Win.C1Ribbon.RibbonLabel
	Friend WithEvents RibbonSeparator6 As C1.Win.C1Ribbon.RibbonSeparator
	Friend WithEvents LabelHost4 As LabelHost
	Friend WithEvents RibbonLabel4 As C1.Win.C1Ribbon.RibbonLabel
	Friend WithEvents RibbonSeparator7 As C1.Win.C1Ribbon.RibbonSeparator
	Friend WithEvents LabelHost5 As LabelHost
	Friend WithEvents RibbonLabel5 As C1.Win.C1Ribbon.RibbonLabel
	Friend WithEvents RibbonSeparator8 As C1.Win.C1Ribbon.RibbonSeparator
End Class
