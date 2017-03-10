<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLogin
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
		Me.Label1 = New System.Windows.Forms.Label()
		Me.cmbGroup = New System.Windows.Forms.ComboBox()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.Label3 = New System.Windows.Forms.Label()
		Me.cmbUser = New System.Windows.Forms.ComboBox()
		Me.txtPassword = New System.Windows.Forms.TextBox()
		Me.Label4 = New System.Windows.Forms.Label()
		Me.btnLogin = New System.Windows.Forms.Button()
		Me.btnExit = New System.Windows.Forms.Button()
		Me.btnConnectionProperty = New System.Windows.Forms.Button()
		Me.btnUpdateHistory = New System.Windows.Forms.Button()
		Me.Panel1.SuspendLayout()
		Me.SuspendLayout()
		'
		'Panel1
		'
		Me.Panel1.Controls.Add(Me.Label1)
		Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
		Me.Panel1.Location = New System.Drawing.Point(0, 0)
		Me.Panel1.Name = "Panel1"
		Me.Panel1.Size = New System.Drawing.Size(464, 50)
		Me.Panel1.TabIndex = 1
		'
		'Label1
		'
		Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
		Me.Label1.Font = New System.Drawing.Font("メイリオ", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.Label1.Location = New System.Drawing.Point(0, 0)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(464, 50)
		Me.Label1.TabIndex = 0
		Me.Label1.Text = "画像データベースツール(仮)"
		Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'cmbGroup
		'
		Me.cmbGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cmbGroup.FormattingEnabled = True
		Me.cmbGroup.Location = New System.Drawing.Point(195, 56)
		Me.cmbGroup.Name = "cmbGroup"
		Me.cmbGroup.Size = New System.Drawing.Size(204, 25)
		Me.cmbGroup.TabIndex = 1
		'
		'Label2
		'
		Me.Label2.Location = New System.Drawing.Point(69, 54)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(120, 26)
		Me.Label2.TabIndex = 0
		Me.Label2.Text = "拠点："
		Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'Label3
		'
		Me.Label3.Location = New System.Drawing.Point(69, 85)
		Me.Label3.Name = "Label3"
		Me.Label3.Size = New System.Drawing.Size(120, 26)
		Me.Label3.TabIndex = 2
		Me.Label3.Text = "ユーザー名："
		Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'cmbUser
		'
		Me.cmbUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cmbUser.FormattingEnabled = True
		Me.cmbUser.Location = New System.Drawing.Point(195, 87)
		Me.cmbUser.Name = "cmbUser"
		Me.cmbUser.Size = New System.Drawing.Size(204, 25)
		Me.cmbUser.TabIndex = 3
		'
		'txtPassword
		'
		Me.txtPassword.Location = New System.Drawing.Point(195, 118)
		Me.txtPassword.Name = "txtPassword"
		Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(9679)
		Me.txtPassword.Size = New System.Drawing.Size(204, 24)
		Me.txtPassword.TabIndex = 5
		'
		'Label4
		'
		Me.Label4.Location = New System.Drawing.Point(69, 116)
		Me.Label4.Name = "Label4"
		Me.Label4.Size = New System.Drawing.Size(120, 26)
		Me.Label4.TabIndex = 4
		Me.Label4.Text = "パスワード："
		Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'btnLogin
		'
		Me.btnLogin.Location = New System.Drawing.Point(286, 177)
		Me.btnLogin.Name = "btnLogin"
		Me.btnLogin.Size = New System.Drawing.Size(80, 26)
		Me.btnLogin.TabIndex = 7
		Me.btnLogin.Text = "ログイン"
		Me.btnLogin.UseVisualStyleBackColor = True
		'
		'btnExit
		'
		Me.btnExit.Location = New System.Drawing.Point(372, 177)
		Me.btnExit.Name = "btnExit"
		Me.btnExit.Size = New System.Drawing.Size(80, 26)
		Me.btnExit.TabIndex = 8
		Me.btnExit.Text = "終　了"
		Me.btnExit.UseVisualStyleBackColor = True
		'
		'btnConnectionProperty
		'
		Me.btnConnectionProperty.Location = New System.Drawing.Point(12, 145)
		Me.btnConnectionProperty.Name = "btnConnectionProperty"
		Me.btnConnectionProperty.Size = New System.Drawing.Size(80, 26)
		Me.btnConnectionProperty.TabIndex = 9
		Me.btnConnectionProperty.Text = "接続設定"
		Me.btnConnectionProperty.UseVisualStyleBackColor = True
		'
		'btnUpdateHistory
		'
		Me.btnUpdateHistory.Location = New System.Drawing.Point(12, 177)
		Me.btnUpdateHistory.Name = "btnUpdateHistory"
		Me.btnUpdateHistory.Size = New System.Drawing.Size(80, 26)
		Me.btnUpdateHistory.TabIndex = 0
		Me.btnUpdateHistory.Text = "更新履歴"
		Me.btnUpdateHistory.UseVisualStyleBackColor = True
		'
		'frmLogin
		'
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
		Me.ClientSize = New System.Drawing.Size(464, 231)
		Me.Controls.Add(Me.btnUpdateHistory)
		Me.Controls.Add(Me.btnConnectionProperty)
		Me.Controls.Add(Me.btnExit)
		Me.Controls.Add(Me.btnLogin)
		Me.Controls.Add(Me.Label4)
		Me.Controls.Add(Me.txtPassword)
		Me.Controls.Add(Me.Label3)
		Me.Controls.Add(Me.cmbUser)
		Me.Controls.Add(Me.Label2)
		Me.Controls.Add(Me.cmbGroup)
		Me.Controls.Add(Me.Panel1)
		Me.KeyPreview = True
		Me.Name = "frmLogin"
		Me.Text = "frmLogin"
		Me.UserName = Nothing
		Me.Controls.SetChildIndex(Me.Panel1, 0)
		Me.Controls.SetChildIndex(Me.cmbGroup, 0)
		Me.Controls.SetChildIndex(Me.Label2, 0)
		Me.Controls.SetChildIndex(Me.cmbUser, 0)
		Me.Controls.SetChildIndex(Me.Label3, 0)
		Me.Controls.SetChildIndex(Me.txtPassword, 0)
		Me.Controls.SetChildIndex(Me.Label4, 0)
		Me.Controls.SetChildIndex(Me.btnLogin, 0)
		Me.Controls.SetChildIndex(Me.btnExit, 0)
		Me.Controls.SetChildIndex(Me.btnConnectionProperty, 0)
		Me.Controls.SetChildIndex(Me.btnUpdateHistory, 0)
		Me.Panel1.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	Friend WithEvents Panel1 As Panel
	Friend WithEvents Label1 As Label
	Friend WithEvents cmbGroup As ComboBox
	Friend WithEvents Label2 As Label
	Friend WithEvents Label3 As Label
	Friend WithEvents cmbUser As ComboBox
	Friend WithEvents txtPassword As TextBox
	Friend WithEvents Label4 As Label
	Friend WithEvents btnLogin As Button
	Friend WithEvents btnExit As Button
	Friend WithEvents btnConnectionProperty As Button
	Friend WithEvents btnUpdateHistory As Button
End Class
