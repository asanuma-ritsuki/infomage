﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
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
		Me.lblBookletID = New C1.Win.C1Ribbon.RibbonLabel()
		Me.RibbonSeparator1 = New C1.Win.C1Ribbon.RibbonSeparator()
		Me.lblImageCount = New C1.Win.C1Ribbon.RibbonLabel()
		Me.RibbonSeparator2 = New C1.Win.C1Ribbon.RibbonSeparator()
		Me.btnImageTop = New C1.Win.C1Ribbon.RibbonButton()
		Me.btnImagePrev = New C1.Win.C1Ribbon.RibbonButton()
		Me.btnImageNext = New C1.Win.C1Ribbon.RibbonButton()
		Me.btnImageBottom = New C1.Win.C1Ribbon.RibbonButton()
		Me.RibbonSeparator3 = New C1.Win.C1Ribbon.RibbonSeparator()
		Me.btnRotateLeft = New C1.Win.C1Ribbon.RibbonButton()
		Me.btnRotateRight = New C1.Win.C1Ribbon.RibbonButton()
		Me.RibbonSeparator4 = New C1.Win.C1Ribbon.RibbonSeparator()
		Me.btnReduction = New C1.Win.C1Ribbon.RibbonButton()
		Me.btnMagnification = New C1.Win.C1Ribbon.RibbonButton()
		Me.btnFit = New C1.Win.C1Ribbon.RibbonButton()
		Me.RibbonSeparator5 = New C1.Win.C1Ribbon.RibbonSeparator()
		Me.lblDate = New C1.Win.C1Ribbon.RibbonLabel()
		Me.RibbonSeparator6 = New C1.Win.C1Ribbon.RibbonSeparator()
		Me.btnBack = New C1.Win.C1Ribbon.RibbonButton()
		Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
		CType(Me.C1StatusBar1, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'C1StatusBar1
		'
		Me.C1StatusBar1.AutoSizeElement = C1.Framework.AutoSizeElement.Width
		Me.C1StatusBar1.LeftPaneItems.Add(Me.lblBookletID)
		Me.C1StatusBar1.LeftPaneItems.Add(Me.RibbonSeparator1)
		Me.C1StatusBar1.LeftPaneItems.Add(Me.lblImageCount)
		Me.C1StatusBar1.LeftPaneItems.Add(Me.RibbonSeparator2)
		Me.C1StatusBar1.LeftPaneItems.Add(Me.btnImageTop)
		Me.C1StatusBar1.LeftPaneItems.Add(Me.btnImagePrev)
		Me.C1StatusBar1.LeftPaneItems.Add(Me.btnImageNext)
		Me.C1StatusBar1.LeftPaneItems.Add(Me.btnImageBottom)
		Me.C1StatusBar1.LeftPaneItems.Add(Me.RibbonSeparator3)
		Me.C1StatusBar1.LeftPaneItems.Add(Me.btnRotateLeft)
		Me.C1StatusBar1.LeftPaneItems.Add(Me.btnRotateRight)
		Me.C1StatusBar1.LeftPaneItems.Add(Me.RibbonSeparator4)
		Me.C1StatusBar1.LeftPaneItems.Add(Me.btnReduction)
		Me.C1StatusBar1.LeftPaneItems.Add(Me.btnMagnification)
		Me.C1StatusBar1.LeftPaneItems.Add(Me.btnFit)
		Me.C1StatusBar1.LeftPaneItems.Add(Me.RibbonSeparator5)
		Me.C1StatusBar1.Location = New System.Drawing.Point(0, 539)
		Me.C1StatusBar1.Name = "C1StatusBar1"
		Me.C1StatusBar1.RightPaneItems.Add(Me.lblDate)
		Me.C1StatusBar1.RightPaneItems.Add(Me.RibbonSeparator6)
		Me.C1StatusBar1.RightPaneItems.Add(Me.btnBack)
		Me.C1StatusBar1.Size = New System.Drawing.Size(784, 22)
		Me.C1StatusBar1.VisualStyle = C1.Win.C1Ribbon.VisualStyle.Office2010Silver
		'
		'lblBookletID
		'
		Me.lblBookletID.Name = "lblBookletID"
		Me.lblBookletID.Text = "0000"
		'
		'RibbonSeparator1
		'
		Me.RibbonSeparator1.Name = "RibbonSeparator1"
		'
		'lblImageCount
		'
		Me.lblImageCount.Name = "lblImageCount"
		Me.lblImageCount.Text = "999Images"
		'
		'RibbonSeparator2
		'
		Me.RibbonSeparator2.Name = "RibbonSeparator2"
		'
		'btnImageTop
		'
		Me.btnImageTop.Name = "btnImageTop"
		Me.btnImageTop.SmallImage = Global.FujiIS.My.Resources.Resources.actions_go_first_3_22x22
		'
		'btnImagePrev
		'
		Me.btnImagePrev.Name = "btnImagePrev"
		Me.btnImagePrev.SmallImage = Global.FujiIS.My.Resources.Resources.actions_go_previous_5_22x22
		'
		'btnImageNext
		'
		Me.btnImageNext.Name = "btnImageNext"
		Me.btnImageNext.SmallImage = Global.FujiIS.My.Resources.Resources.actions_go_next_5_22x22
		'
		'btnImageBottom
		'
		Me.btnImageBottom.Name = "btnImageBottom"
		Me.btnImageBottom.SmallImage = Global.FujiIS.My.Resources.Resources.actions_go_last_3_22x22
		'
		'RibbonSeparator3
		'
		Me.RibbonSeparator3.Name = "RibbonSeparator3"
		'
		'btnRotateLeft
		'
		Me.btnRotateLeft.Enabled = False
		Me.btnRotateLeft.Name = "btnRotateLeft"
		Me.btnRotateLeft.SmallImage = Global.FujiIS.My.Resources.Resources.arrow_rotate_anticlockwise
		'
		'btnRotateRight
		'
		Me.btnRotateRight.Enabled = False
		Me.btnRotateRight.Name = "btnRotateRight"
		Me.btnRotateRight.SmallImage = Global.FujiIS.My.Resources.Resources.arrow_rotate_clockwise
		'
		'RibbonSeparator4
		'
		Me.RibbonSeparator4.Name = "RibbonSeparator4"
		'
		'btnReduction
		'
		Me.btnReduction.Name = "btnReduction"
		Me.btnReduction.SmallImage = Global.FujiIS.My.Resources.Resources.ZoomOut
		'
		'btnMagnification
		'
		Me.btnMagnification.Name = "btnMagnification"
		Me.btnMagnification.SmallImage = Global.FujiIS.My.Resources.Resources.ZoomIn
		'
		'btnFit
		'
		Me.btnFit.Name = "btnFit"
		Me.btnFit.SmallImage = Global.FujiIS.My.Resources.Resources.Zoom
		'
		'RibbonSeparator5
		'
		Me.RibbonSeparator5.Name = "RibbonSeparator5"
		'
		'lblDate
		'
		Me.lblDate.Name = "lblDate"
		Me.lblDate.SmallImage = CType(resources.GetObject("lblDate.SmallImage"), System.Drawing.Image)
		Me.lblDate.Text = "Date"
		'
		'RibbonSeparator6
		'
		Me.RibbonSeparator6.Name = "RibbonSeparator6"
		'
		'btnBack
		'
		Me.btnBack.Name = "btnBack"
		Me.btnBack.SmallImage = Global.FujiIS.My.Resources.Resources.Back
		Me.btnBack.Text = "終了"
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
		Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
		Me.Name = "frmTempForm"
		Me.Text = "frmTempForm"
		CType(Me.C1StatusBar1, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	Friend WithEvents C1StatusBar1 As C1.Win.C1Ribbon.C1StatusBar
	Friend WithEvents lblDate As C1.Win.C1Ribbon.RibbonLabel
	Friend WithEvents Timer1 As Timer
	Friend WithEvents lblBookletID As C1.Win.C1Ribbon.RibbonLabel
	Friend WithEvents RibbonSeparator1 As C1.Win.C1Ribbon.RibbonSeparator
	Friend WithEvents lblImageCount As C1.Win.C1Ribbon.RibbonLabel
	Friend WithEvents RibbonSeparator2 As C1.Win.C1Ribbon.RibbonSeparator
	Friend WithEvents btnImageTop As C1.Win.C1Ribbon.RibbonButton
	Friend WithEvents btnImagePrev As C1.Win.C1Ribbon.RibbonButton
	Friend WithEvents btnImageNext As C1.Win.C1Ribbon.RibbonButton
	Friend WithEvents btnImageBottom As C1.Win.C1Ribbon.RibbonButton
	Friend WithEvents RibbonSeparator3 As C1.Win.C1Ribbon.RibbonSeparator
	Friend WithEvents btnRotateLeft As C1.Win.C1Ribbon.RibbonButton
	Friend WithEvents btnRotateRight As C1.Win.C1Ribbon.RibbonButton
	Friend WithEvents RibbonSeparator4 As C1.Win.C1Ribbon.RibbonSeparator
	Friend WithEvents btnReduction As C1.Win.C1Ribbon.RibbonButton
	Friend WithEvents btnMagnification As C1.Win.C1Ribbon.RibbonButton
	Friend WithEvents btnFit As C1.Win.C1Ribbon.RibbonButton
	Friend WithEvents RibbonSeparator5 As C1.Win.C1Ribbon.RibbonSeparator
	Friend WithEvents RibbonSeparator6 As C1.Win.C1Ribbon.RibbonSeparator
	Friend WithEvents btnBack As C1.Win.C1Ribbon.RibbonButton
End Class
