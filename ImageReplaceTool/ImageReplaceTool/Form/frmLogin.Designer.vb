<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmLogin
	Inherits frmTempForm

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
		Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
		Me.ファイルFToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.menuExit = New System.Windows.Forms.ToolStripMenuItem()
		Me.ツールTToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.menuConnection = New System.Windows.Forms.ToolStripMenuItem()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.Label3 = New System.Windows.Forms.Label()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.PictureBox1 = New System.Windows.Forms.PictureBox()
		Me.cmbCategory = New System.Windows.Forms.ComboBox()
		Me.cmbName = New System.Windows.Forms.ComboBox()
		Me.Label4 = New System.Windows.Forms.Label()
		Me.Label5 = New System.Windows.Forms.Label()
		Me.btnExit = New System.Windows.Forms.Button()
		Me.btnLogin = New System.Windows.Forms.Button()
		Me.Label6 = New System.Windows.Forms.Label()
		Me.txtPassword = New System.Windows.Forms.TextBox()
		Me.MenuStrip1.SuspendLayout()
		CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'MenuStrip1
		'
		Me.MenuStrip1.BackColor = System.Drawing.Color.Transparent
		Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ファイルFToolStripMenuItem, Me.ツールTToolStripMenuItem})
		Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
		Me.MenuStrip1.Name = "MenuStrip1"
		Me.MenuStrip1.Size = New System.Drawing.Size(464, 24)
		Me.MenuStrip1.TabIndex = 0
		Me.MenuStrip1.Text = "MenuStrip1"
		'
		'ファイルFToolStripMenuItem
		'
		Me.ファイルFToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuExit})
		Me.ファイルFToolStripMenuItem.Name = "ファイルFToolStripMenuItem"
		Me.ファイルFToolStripMenuItem.Size = New System.Drawing.Size(67, 20)
		Me.ファイルFToolStripMenuItem.Text = "ファイル(&F)"
		'
		'menuExit
		'
		Me.menuExit.Name = "menuExit"
		Me.menuExit.Size = New System.Drawing.Size(113, 22)
		Me.menuExit.Text = "終了(&X)"
		'
		'ツールTToolStripMenuItem
		'
		Me.ツールTToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuConnection})
		Me.ツールTToolStripMenuItem.Name = "ツールTToolStripMenuItem"
		Me.ツールTToolStripMenuItem.Size = New System.Drawing.Size(60, 20)
		Me.ツールTToolStripMenuItem.Text = "ツール(&T)"
		'
		'menuConnection
		'
		Me.menuConnection.Name = "menuConnection"
		Me.menuConnection.Size = New System.Drawing.Size(137, 22)
		Me.menuConnection.Text = "接続設定(&C)"
		'
		'Label2
		'
		Me.Label2.AutoSize = True
		Me.Label2.Font = New System.Drawing.Font("メイリオ", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(196, Byte), Integer), CType(CType(15, Byte), Integer), CType(CType(57, Byte), Integer))
		Me.Label2.Location = New System.Drawing.Point(205, 109)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(207, 41)
		Me.Label2.TabIndex = 8
		Me.Label2.Text = "処理準備ツール"
		'
		'Label3
		'
		Me.Label3.AutoSize = True
		Me.Label3.Font = New System.Drawing.Font("メイリオ", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(196, Byte), Integer), CType(CType(15, Byte), Integer), CType(CType(57, Byte), Integer))
		Me.Label3.Location = New System.Drawing.Point(164, 68)
		Me.Label3.Name = "Label3"
		Me.Label3.Size = New System.Drawing.Size(288, 41)
		Me.Label3.TabIndex = 7
		Me.Label3.Text = "画像差替え・コマ抜け"
		'
		'Label1
		'
		Me.Label1.AutoSize = True
		Me.Label1.Font = New System.Drawing.Font("メイリオ", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(196, Byte), Integer), CType(CType(15, Byte), Integer), CType(CType(57, Byte), Integer))
		Me.Label1.Location = New System.Drawing.Point(236, 27)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(145, 41)
		Me.Label1.TabIndex = 6
		Me.Label1.Text = "Infomage"
		'
		'PictureBox1
		'
		Me.PictureBox1.Image = Global.ImageReplaceTool.My.Resources.Resources.f_f_object_128_s512_f_object_128_2nbg
		Me.PictureBox1.InitialImage = Nothing
		Me.PictureBox1.Location = New System.Drawing.Point(12, 27)
		Me.PictureBox1.Name = "PictureBox1"
		Me.PictureBox1.Size = New System.Drawing.Size(146, 143)
		Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
		Me.PictureBox1.TabIndex = 13
		Me.PictureBox1.TabStop = False
		'
		'cmbCategory
		'
		Me.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cmbCategory.Font = New System.Drawing.Font("Meiryo UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.cmbCategory.FormattingEnabled = True
		Me.cmbCategory.Location = New System.Drawing.Point(142, 173)
		Me.cmbCategory.Name = "cmbCategory"
		Me.cmbCategory.Size = New System.Drawing.Size(310, 32)
		Me.cmbCategory.TabIndex = 1
		'
		'cmbName
		'
		Me.cmbName.Font = New System.Drawing.Font("Meiryo UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.cmbName.FormattingEnabled = True
		Me.cmbName.Location = New System.Drawing.Point(142, 211)
		Me.cmbName.Name = "cmbName"
		Me.cmbName.Size = New System.Drawing.Size(310, 32)
		Me.cmbName.TabIndex = 2
		'
		'Label4
		'
		Me.Label4.Font = New System.Drawing.Font("Meiryo UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.Label4.Location = New System.Drawing.Point(8, 173)
		Me.Label4.Name = "Label4"
		Me.Label4.Size = New System.Drawing.Size(128, 32)
		Me.Label4.TabIndex = 9
		Me.Label4.Text = "従業員区分："
		Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'Label5
		'
		Me.Label5.Font = New System.Drawing.Font("Meiryo UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.Label5.Location = New System.Drawing.Point(8, 211)
		Me.Label5.Name = "Label5"
		Me.Label5.Size = New System.Drawing.Size(128, 32)
		Me.Label5.TabIndex = 10
		Me.Label5.Text = "従業員名："
		Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'btnExit
		'
		Me.btnExit.Font = New System.Drawing.Font("Meiryo UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.btnExit.Location = New System.Drawing.Point(362, 287)
		Me.btnExit.Name = "btnExit"
		Me.btnExit.Size = New System.Drawing.Size(90, 32)
		Me.btnExit.TabIndex = 5
		Me.btnExit.Text = "終　了"
		Me.btnExit.UseVisualStyleBackColor = True
		'
		'btnLogin
		'
		Me.btnLogin.Font = New System.Drawing.Font("Meiryo UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.btnLogin.Location = New System.Drawing.Point(266, 287)
		Me.btnLogin.Name = "btnLogin"
		Me.btnLogin.Size = New System.Drawing.Size(90, 32)
		Me.btnLogin.TabIndex = 4
		Me.btnLogin.Text = "ログイン"
		Me.btnLogin.UseVisualStyleBackColor = True
		'
		'Label6
		'
		Me.Label6.Font = New System.Drawing.Font("Meiryo UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.Label6.Location = New System.Drawing.Point(8, 249)
		Me.Label6.Name = "Label6"
		Me.Label6.Size = New System.Drawing.Size(128, 32)
		Me.Label6.TabIndex = 11
		Me.Label6.Text = "パスワード："
		Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'txtPassword
		'
		Me.txtPassword.Font = New System.Drawing.Font("Meiryo UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.txtPassword.Location = New System.Drawing.Point(142, 250)
		Me.txtPassword.Name = "txtPassword"
		Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(9679)
		Me.txtPassword.Size = New System.Drawing.Size(310, 32)
		Me.txtPassword.TabIndex = 3
		'
		'frmLogin
		'
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
		Me.BackColor = System.Drawing.Color.White
		Me.CaptionDisplayMode = ImageReplaceTool.frmTempForm.StatusDisplayMode.ShowAll
		Me.ClientSize = New System.Drawing.Size(464, 331)
		Me.Controls.Add(Me.txtPassword)
		Me.Controls.Add(Me.Label6)
		Me.Controls.Add(Me.btnLogin)
		Me.Controls.Add(Me.btnExit)
		Me.Controls.Add(Me.Label5)
		Me.Controls.Add(Me.Label4)
		Me.Controls.Add(Me.cmbName)
		Me.Controls.Add(Me.cmbCategory)
		Me.Controls.Add(Me.Label2)
		Me.Controls.Add(Me.Label3)
		Me.Controls.Add(Me.Label1)
		Me.Controls.Add(Me.PictureBox1)
		Me.Controls.Add(Me.MenuStrip1)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.KeyPreview = True
		Me.MainMenuStrip = Me.MenuStrip1
		Me.Margin = New System.Windows.Forms.Padding(4)
		Me.MaximizeBox = False
		Me.Name = "frmLogin"
		Me.Text = "frmLogin"
		Me.Controls.SetChildIndex(Me.MenuStrip1, 0)
		Me.Controls.SetChildIndex(Me.PictureBox1, 0)
		Me.Controls.SetChildIndex(Me.Label1, 0)
		Me.Controls.SetChildIndex(Me.Label3, 0)
		Me.Controls.SetChildIndex(Me.Label2, 0)
		Me.Controls.SetChildIndex(Me.cmbCategory, 0)
		Me.Controls.SetChildIndex(Me.cmbName, 0)
		Me.Controls.SetChildIndex(Me.Label4, 0)
		Me.Controls.SetChildIndex(Me.Label5, 0)
		Me.Controls.SetChildIndex(Me.btnExit, 0)
		Me.Controls.SetChildIndex(Me.btnLogin, 0)
		Me.Controls.SetChildIndex(Me.Label6, 0)
		Me.Controls.SetChildIndex(Me.txtPassword, 0)
		Me.MenuStrip1.ResumeLayout(False)
		Me.MenuStrip1.PerformLayout()
		CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	Friend WithEvents MenuStrip1 As MenuStrip
	Friend WithEvents Label2 As Label
	Friend WithEvents Label3 As Label
	Friend WithEvents Label1 As Label
	Friend WithEvents PictureBox1 As PictureBox
	Friend WithEvents ファイルFToolStripMenuItem As ToolStripMenuItem
	Friend WithEvents menuExit As ToolStripMenuItem
	Friend WithEvents ツールTToolStripMenuItem As ToolStripMenuItem
	Friend WithEvents menuConnection As ToolStripMenuItem
	Friend WithEvents cmbCategory As ComboBox
	Friend WithEvents cmbName As ComboBox
	Friend WithEvents Label4 As Label
	Friend WithEvents Label5 As Label
	Friend WithEvents btnExit As Button
	Friend WithEvents btnLogin As Button
	Friend WithEvents Label6 As Label
	Friend WithEvents txtPassword As TextBox
End Class
