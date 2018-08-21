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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLogin))
        Me.btnOK = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbUser = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ファイルFToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.ツールTToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuConnection = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupBox1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(329, 23)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 25)
        Me.btnOK.TabIndex = 4
        Me.btnOK.Text = "ログイン"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(10, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(91, 25)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "ユーザー名："
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbUser
        '
        Me.cmbUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbUser.FormattingEnabled = True
        Me.cmbUser.Location = New System.Drawing.Point(107, 23)
        Me.cmbUser.Name = "cmbUser"
        Me.cmbUser.Size = New System.Drawing.Size(216, 25)
        Me.cmbUser.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("メイリオ", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label1.Location = New System.Drawing.Point(12, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(216, 41)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "雄松堂 府県統計"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("メイリオ", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label3.Location = New System.Drawing.Point(188, 67)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(234, 41)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "データ精査ツール"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnExit)
        Me.GroupBox1.Controls.Add(Me.txtPassword)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cmbUser)
        Me.GroupBox1.Controls.Add(Me.btnOK)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 113)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(410, 86)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "ログイン"
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(329, 54)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 25)
        Me.btnExit.TabIndex = 5
        Me.btnExit.Text = "終　了"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(107, 54)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(9679)
        Me.txtPassword.Size = New System.Drawing.Size(216, 24)
        Me.txtPassword.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(10, 53)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(91, 25)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "パスワード："
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ファイルFToolStripMenuItem, Me.ツールTToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(434, 24)
        Me.MenuStrip1.TabIndex = 3
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ファイルFToolStripMenuItem
        '
        Me.ファイルFToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuExit})
        Me.ファイルFToolStripMenuItem.Name = "ファイルFToolStripMenuItem"
        Me.ファイルFToolStripMenuItem.Size = New System.Drawing.Size(66, 20)
        Me.ファイルFToolStripMenuItem.Text = "ファイル(&F)"
        '
        'menuExit
        '
        Me.menuExit.Name = "menuExit"
        Me.menuExit.Size = New System.Drawing.Size(152, 22)
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
        Me.menuConnection.Size = New System.Drawing.Size(152, 22)
        Me.menuConnection.Text = "接続設定(&C)"
        '
        'frmLogin
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.CaptionDisplayMode = LinkPasteTool.frmTempForm.StatusDisplayMode.ShowAll
        Me.ClientSize = New System.Drawing.Size(434, 211)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "frmLogin"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmLogin"
        Me.Controls.SetChildIndex(Me.MenuStrip1, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnOK As Button
	Friend WithEvents Label2 As Label
	Friend WithEvents cmbUser As ComboBox
	Friend WithEvents Label1 As Label
	Friend WithEvents Label3 As Label
	Friend WithEvents GroupBox1 As GroupBox
	Friend WithEvents Label4 As Label
	Friend WithEvents btnExit As Button
	Friend WithEvents txtPassword As TextBox
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents ファイルFToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents menuExit As ToolStripMenuItem
    Friend WithEvents ツールTToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents menuConnection As ToolStripMenuItem
End Class
