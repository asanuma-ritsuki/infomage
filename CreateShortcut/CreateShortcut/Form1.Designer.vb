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
		Me.txtAccessFile = New System.Windows.Forms.TextBox()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.txtShortcut = New System.Windows.Forms.TextBox()
		Me.Button1 = New System.Windows.Forms.Button()
		Me.Label3 = New System.Windows.Forms.Label()
		Me.txtSaveFolder = New System.Windows.Forms.TextBox()
		Me.SuspendLayout()
		'
		'txtAccessFile
		'
		Me.txtAccessFile.Location = New System.Drawing.Point(116, 12)
		Me.txtAccessFile.Name = "txtAccessFile"
		Me.txtAccessFile.Size = New System.Drawing.Size(600, 24)
		Me.txtAccessFile.TabIndex = 0
		'
		'Label1
		'
		Me.Label1.AutoSize = True
		Me.Label1.Location = New System.Drawing.Point(9, 15)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(101, 17)
		Me.Label1.TabIndex = 1
		Me.Label1.Text = "Accessファイル："
		'
		'Label2
		'
		Me.Label2.AutoSize = True
		Me.Label2.Location = New System.Drawing.Point(12, 75)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(98, 17)
		Me.Label2.TabIndex = 3
		Me.Label2.Text = "ショートカット名："
		'
		'txtShortcut
		'
		Me.txtShortcut.Location = New System.Drawing.Point(116, 72)
		Me.txtShortcut.Name = "txtShortcut"
		Me.txtShortcut.Size = New System.Drawing.Size(151, 24)
		Me.txtShortcut.TabIndex = 2
		'
		'Button1
		'
		Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.Button1.Location = New System.Drawing.Point(641, 104)
		Me.Button1.Name = "Button1"
		Me.Button1.Size = New System.Drawing.Size(75, 25)
		Me.Button1.TabIndex = 4
		Me.Button1.Text = "作　成"
		Me.Button1.UseVisualStyleBackColor = True
		'
		'Label3
		'
		Me.Label3.AutoSize = True
		Me.Label3.Location = New System.Drawing.Point(25, 45)
		Me.Label3.Name = "Label3"
		Me.Label3.Size = New System.Drawing.Size(85, 17)
		Me.Label3.TabIndex = 6
		Me.Label3.Text = "保存フォルダ："
		'
		'txtSaveFolder
		'
		Me.txtSaveFolder.Location = New System.Drawing.Point(116, 42)
		Me.txtSaveFolder.Name = "txtSaveFolder"
		Me.txtSaveFolder.Size = New System.Drawing.Size(600, 24)
		Me.txtSaveFolder.TabIndex = 5
		'
		'Form1
		'
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
		Me.ClientSize = New System.Drawing.Size(728, 138)
		Me.Controls.Add(Me.Label3)
		Me.Controls.Add(Me.txtSaveFolder)
		Me.Controls.Add(Me.Button1)
		Me.Controls.Add(Me.Label2)
		Me.Controls.Add(Me.txtShortcut)
		Me.Controls.Add(Me.Label1)
		Me.Controls.Add(Me.txtAccessFile)
		Me.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.Name = "Form1"
		Me.Text = "Form1"
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	Friend WithEvents txtAccessFile As TextBox
	Friend WithEvents Label1 As Label
	Friend WithEvents Label2 As Label
	Friend WithEvents txtShortcut As TextBox
	Friend WithEvents Button1 As Button
	Friend WithEvents Label3 As Label
	Friend WithEvents txtSaveFolder As TextBox
End Class
