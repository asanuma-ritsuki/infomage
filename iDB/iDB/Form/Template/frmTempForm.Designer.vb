<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTempForm
	Inherits C1.Win.C1Ribbon.C1RibbonForm

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
		Me.panelHeader = New System.Windows.Forms.Panel()
		Me.C1StatusBar1 = New C1.Win.C1Ribbon.C1StatusBar()
		Me.C1LabelHeader = New C1.Win.C1Input.C1Label()
		Me.panelHeader.SuspendLayout()
		CType(Me.C1StatusBar1, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.C1LabelHeader, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'panelHeader
		'
		Me.panelHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
		Me.panelHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.panelHeader.Controls.Add(Me.C1LabelHeader)
		Me.panelHeader.Dock = System.Windows.Forms.DockStyle.Top
		Me.panelHeader.Location = New System.Drawing.Point(0, 0)
		Me.panelHeader.Name = "panelHeader"
		Me.panelHeader.Size = New System.Drawing.Size(784, 50)
		Me.panelHeader.TabIndex = 0
		'
		'C1StatusBar1
		'
		Me.C1StatusBar1.AutoSizeElement = C1.Framework.AutoSizeElement.Width
		Me.C1StatusBar1.Location = New System.Drawing.Point(0, 538)
		Me.C1StatusBar1.Name = "C1StatusBar1"
		Me.C1StatusBar1.Size = New System.Drawing.Size(784, 23)
		'
		'C1LabelHeader
		'
		Me.C1LabelHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
		Me.C1LabelHeader.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.C1LabelHeader.Dock = System.Windows.Forms.DockStyle.Fill
		Me.C1LabelHeader.Font = New System.Drawing.Font("Meiryo UI", 20.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.C1LabelHeader.ForeColor = System.Drawing.Color.Black
		Me.C1LabelHeader.Location = New System.Drawing.Point(0, 0)
		Me.C1LabelHeader.Margin = New System.Windows.Forms.Padding(10, 0, 3, 0)
		Me.C1LabelHeader.Name = "C1LabelHeader"
		Me.C1LabelHeader.Size = New System.Drawing.Size(782, 48)
		Me.C1LabelHeader.TabIndex = 0
		Me.C1LabelHeader.Tag = Nothing
		Me.C1LabelHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.C1LabelHeader.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
		'
		'frmTempForm
		'
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
		Me.ClientSize = New System.Drawing.Size(784, 561)
		Me.Controls.Add(Me.C1StatusBar1)
		Me.Controls.Add(Me.panelHeader)
		Me.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.KeyPreview = True
		Me.Name = "frmTempForm"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "frmTempForm"
		Me.panelHeader.ResumeLayout(False)
		CType(Me.C1StatusBar1, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.C1LabelHeader, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	Friend WithEvents panelHeader As Panel
	Friend WithEvents C1StatusBar1 As C1.Win.C1Ribbon.C1StatusBar
	Friend WithEvents C1LabelHeader As C1.Win.C1Input.C1Label
End Class
