<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUserManage
	Inherits frmTempForm

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
		Me.Panel1 = New System.Windows.Forms.Panel()
		Me.C1Label1 = New C1.Win.C1Input.C1Label()
		Me.Panel2 = New System.Windows.Forms.Panel()
		Me.C1Sizer1 = New C1.Win.C1Sizer.C1Sizer()
		Me.GroupBox1 = New System.Windows.Forms.GroupBox()
		Me.GroupBox2 = New System.Windows.Forms.GroupBox()
		Me.Panel1.SuspendLayout()
		CType(Me.C1Label1, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.Panel2.SuspendLayout()
		CType(Me.C1Sizer1, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.C1Sizer1.SuspendLayout()
		Me.SuspendLayout()
		'
		'Panel1
		'
		Me.Panel1.Controls.Add(Me.C1Label1)
		Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
		Me.Panel1.Location = New System.Drawing.Point(0, 0)
		Me.Panel1.Name = "Panel1"
		Me.Panel1.Size = New System.Drawing.Size(792, 50)
		Me.Panel1.TabIndex = 1
		'
		'C1Label1
		'
		Me.C1Label1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.C1Label1.Dock = System.Windows.Forms.DockStyle.Fill
		Me.C1Label1.Font = New System.Drawing.Font("Meiryo UI", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.C1Label1.Location = New System.Drawing.Point(0, 0)
		Me.C1Label1.Name = "C1Label1"
		Me.C1Label1.Size = New System.Drawing.Size(792, 50)
		Me.C1Label1.TabIndex = 0
		Me.C1Label1.Tag = Nothing
		Me.C1Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.C1Label1.Value = "ユーザー管理"
		'
		'Panel2
		'
		Me.Panel2.Controls.Add(Me.C1Sizer1)
		Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
		Me.Panel2.Location = New System.Drawing.Point(0, 50)
		Me.Panel2.Name = "Panel2"
		Me.Panel2.Size = New System.Drawing.Size(792, 495)
		Me.Panel2.TabIndex = 2
		'
		'C1Sizer1
		'
		Me.C1Sizer1.Controls.Add(Me.GroupBox2)
		Me.C1Sizer1.Controls.Add(Me.GroupBox1)
		Me.C1Sizer1.Dock = System.Windows.Forms.DockStyle.Fill
		Me.C1Sizer1.GridDefinition = "48.6868686868687:False:False;48.8888888888889:False:True;" & Global.Microsoft.VisualBasic.ChrW(9) & "98.989898989899:False:F" &
	"alse;"
		Me.C1Sizer1.Location = New System.Drawing.Point(0, 0)
		Me.C1Sizer1.Name = "C1Sizer1"
		Me.C1Sizer1.Size = New System.Drawing.Size(792, 495)
		Me.C1Sizer1.TabIndex = 0
		Me.C1Sizer1.Text = "C1Sizer1"
		'
		'GroupBox1
		'
		Me.GroupBox1.Location = New System.Drawing.Point(4, 4)
		Me.GroupBox1.Name = "GroupBox1"
		Me.GroupBox1.Size = New System.Drawing.Size(784, 241)
		Me.GroupBox1.TabIndex = 0
		Me.GroupBox1.TabStop = False
		Me.GroupBox1.Text = "GroupBox1"
		'
		'GroupBox2
		'
		Me.GroupBox2.Location = New System.Drawing.Point(4, 249)
		Me.GroupBox2.Name = "GroupBox2"
		Me.GroupBox2.Size = New System.Drawing.Size(784, 242)
		Me.GroupBox2.TabIndex = 1
		Me.GroupBox2.TabStop = False
		Me.GroupBox2.Text = "GroupBox2"
		'
		'frmUserManage
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 19.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(792, 567)
		Me.Controls.Add(Me.Panel2)
		Me.Controls.Add(Me.Panel1)
		Me.Name = "frmUserManage"
		Me.Text = "frmUserManage"
		Me.UserName = Nothing
		Me.Controls.SetChildIndex(Me.Panel1, 0)
		Me.Controls.SetChildIndex(Me.Panel2, 0)
		Me.Panel1.ResumeLayout(False)
		CType(Me.C1Label1, System.ComponentModel.ISupportInitialize).EndInit()
		Me.Panel2.ResumeLayout(False)
		CType(Me.C1Sizer1, System.ComponentModel.ISupportInitialize).EndInit()
		Me.C1Sizer1.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	Friend WithEvents Panel1 As Panel
	Friend WithEvents C1Label1 As C1.Win.C1Input.C1Label
	Friend WithEvents Panel2 As Panel
	Friend WithEvents C1Sizer1 As C1.Win.C1Sizer.C1Sizer
	Friend WithEvents GroupBox2 As GroupBox
	Friend WithEvents GroupBox1 As GroupBox
End Class
