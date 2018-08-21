<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
		Me.btnPrint = New System.Windows.Forms.Button()
		Me.Panel1 = New System.Windows.Forms.Panel()
		Me.C1FlexViewer1 = New C1.Win.FlexViewer.C1FlexViewer()
		Me.Panel2 = New System.Windows.Forms.Panel()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.cmbBDVol = New System.Windows.Forms.ComboBox()
		Me.Panel1.SuspendLayout()
		CType(Me.C1FlexViewer1, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.Panel2.SuspendLayout()
		Me.SuspendLayout()
		'
		'btnPrint
		'
		Me.btnPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.btnPrint.Location = New System.Drawing.Point(697, 9)
		Me.btnPrint.Name = "btnPrint"
		Me.btnPrint.Size = New System.Drawing.Size(75, 25)
		Me.btnPrint.TabIndex = 0
		Me.btnPrint.Text = "印　刷"
		Me.btnPrint.UseVisualStyleBackColor = True
		'
		'Panel1
		'
		Me.Panel1.Controls.Add(Me.C1FlexViewer1)
		Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
		Me.Panel1.Location = New System.Drawing.Point(0, 0)
		Me.Panel1.Name = "Panel1"
		Me.Panel1.Size = New System.Drawing.Size(784, 515)
		Me.Panel1.TabIndex = 1
		'
		'C1FlexViewer1
		'
		Me.C1FlexViewer1.AutoScrollMargin = New System.Drawing.Size(0, 0)
		Me.C1FlexViewer1.AutoScrollMinSize = New System.Drawing.Size(0, 0)
		Me.C1FlexViewer1.Dock = System.Windows.Forms.DockStyle.Fill
		Me.C1FlexViewer1.Location = New System.Drawing.Point(0, 0)
		Me.C1FlexViewer1.Name = "C1FlexViewer1"
		Me.C1FlexViewer1.Size = New System.Drawing.Size(784, 515)
		Me.C1FlexViewer1.TabIndex = 0
		'
		'Panel2
		'
		Me.Panel2.Controls.Add(Me.Label1)
		Me.Panel2.Controls.Add(Me.cmbBDVol)
		Me.Panel2.Controls.Add(Me.btnPrint)
		Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
		Me.Panel2.Location = New System.Drawing.Point(0, 515)
		Me.Panel2.Name = "Panel2"
		Me.Panel2.Size = New System.Drawing.Size(784, 46)
		Me.Panel2.TabIndex = 2
		'
		'Label1
		'
		Me.Label1.AutoSize = True
		Me.Label1.Location = New System.Drawing.Point(8, 14)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(54, 17)
		Me.Label1.TabIndex = 2
		Me.Label1.Text = "BD_Vol"
		'
		'cmbBDVol
		'
		Me.cmbBDVol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cmbBDVol.FormattingEnabled = True
		Me.cmbBDVol.Location = New System.Drawing.Point(68, 10)
		Me.cmbBDVol.Name = "cmbBDVol"
		Me.cmbBDVol.Size = New System.Drawing.Size(121, 25)
		Me.cmbBDVol.TabIndex = 1
		'
		'Form1
		'
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
		Me.ClientSize = New System.Drawing.Size(784, 561)
		Me.Controls.Add(Me.Panel1)
		Me.Controls.Add(Me.Panel2)
		Me.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.Name = "Form1"
		Me.Text = "Form1"
		Me.Panel1.ResumeLayout(False)
		CType(Me.C1FlexViewer1, System.ComponentModel.ISupportInitialize).EndInit()
		Me.Panel2.ResumeLayout(False)
		Me.Panel2.PerformLayout()
		Me.ResumeLayout(False)

	End Sub

	Friend WithEvents btnPrint As Button
	Friend WithEvents Panel1 As Panel
	Friend WithEvents C1FlexViewer1 As C1.Win.FlexViewer.C1FlexViewer
	Friend WithEvents Panel2 As Panel
	Friend WithEvents Label1 As Label
	Friend WithEvents cmbBDVol As ComboBox
End Class
