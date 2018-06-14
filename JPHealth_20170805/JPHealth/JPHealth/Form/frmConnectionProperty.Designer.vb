<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConnectionProperty
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
		Me.Label5 = New System.Windows.Forms.Label()
		Me.txtInitialCatalog = New System.Windows.Forms.TextBox()
		Me.Label4 = New System.Windows.Forms.Label()
		Me.txtResult = New System.Windows.Forms.TextBox()
		Me.btnTest = New System.Windows.Forms.Button()
		Me.btnOK = New System.Windows.Forms.Button()
		Me.btnCancel = New System.Windows.Forms.Button()
		Me.txtPassword = New System.Windows.Forms.TextBox()
		Me.txtLogin = New System.Windows.Forms.TextBox()
		Me.Label3 = New System.Windows.Forms.Label()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.txtServer = New System.Windows.Forms.TextBox()
		Me.SuspendLayout()
		'
		'Label5
		'
		Me.Label5.AutoSize = True
		Me.Label5.Location = New System.Drawing.Point(12, 138)
		Me.Label5.Name = "Label5"
		Me.Label5.Size = New System.Drawing.Size(224, 14)
		Me.Label5.TabIndex = 75
		Me.Label5.Text = "接続文字列サンプル(パスワードは伏せてあります):"
		'
		'txtInitialCatalog
		'
		Me.txtInitialCatalog.Location = New System.Drawing.Point(157, 33)
		Me.txtInitialCatalog.Name = "txtInitialCatalog"
		Me.txtInitialCatalog.Size = New System.Drawing.Size(221, 21)
		Me.txtInitialCatalog.TabIndex = 64
		'
		'Label4
		'
		Me.Label4.AutoSize = True
		Me.Label4.Location = New System.Drawing.Point(12, 35)
		Me.Label4.Name = "Label4"
		Me.Label4.Size = New System.Drawing.Size(144, 14)
		Me.Label4.TabIndex = 74
		Me.Label4.Text = "データベース(InitialCatalog):"
		'
		'txtResult
		'
		Me.txtResult.Enabled = False
		Me.txtResult.Location = New System.Drawing.Point(12, 158)
		Me.txtResult.Multiline = True
		Me.txtResult.Name = "txtResult"
		Me.txtResult.Size = New System.Drawing.Size(366, 68)
		Me.txtResult.TabIndex = 67
		'
		'btnTest
		'
		Me.btnTest.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.btnTest.Location = New System.Drawing.Point(12, 232)
		Me.btnTest.Name = "btnTest"
		Me.btnTest.Size = New System.Drawing.Size(87, 27)
		Me.btnTest.TabIndex = 68
		Me.btnTest.Text = "接続テスト"
		Me.btnTest.UseVisualStyleBackColor = True
		'
		'btnOK
		'
		Me.btnOK.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.btnOK.Location = New System.Drawing.Point(198, 232)
		Me.btnOK.Name = "btnOK"
		Me.btnOK.Size = New System.Drawing.Size(87, 27)
		Me.btnOK.TabIndex = 69
		Me.btnOK.Text = "OK"
		Me.btnOK.UseVisualStyleBackColor = True
		'
		'btnCancel
		'
		Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.btnCancel.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.btnCancel.Location = New System.Drawing.Point(291, 232)
		Me.btnCancel.Name = "btnCancel"
		Me.btnCancel.Size = New System.Drawing.Size(87, 27)
		Me.btnCancel.TabIndex = 70
		Me.btnCancel.Text = "キャンセル"
		Me.btnCancel.UseVisualStyleBackColor = True
		'
		'txtPassword
		'
		Me.txtPassword.Location = New System.Drawing.Point(157, 87)
		Me.txtPassword.Name = "txtPassword"
		Me.txtPassword.Size = New System.Drawing.Size(221, 21)
		Me.txtPassword.TabIndex = 66
		Me.txtPassword.UseSystemPasswordChar = True
		'
		'txtLogin
		'
		Me.txtLogin.Location = New System.Drawing.Point(157, 60)
		Me.txtLogin.Name = "txtLogin"
		Me.txtLogin.Size = New System.Drawing.Size(221, 21)
		Me.txtLogin.TabIndex = 65
		'
		'Label3
		'
		Me.Label3.AutoSize = True
		Me.Label3.Location = New System.Drawing.Point(12, 90)
		Me.Label3.Name = "Label3"
		Me.Label3.Size = New System.Drawing.Size(115, 14)
		Me.Label3.TabIndex = 73
		Me.Label3.Text = "パスワード(Password):"
		'
		'Label2
		'
		Me.Label2.AutoSize = True
		Me.Label2.Location = New System.Drawing.Point(12, 62)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(90, 14)
		Me.Label2.TabIndex = 72
		Me.Label2.Text = "ログイン(UserID):"
		'
		'Label1
		'
		Me.Label1.AutoSize = True
		Me.Label1.Location = New System.Drawing.Point(12, 9)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(131, 14)
		Me.Label1.TabIndex = 71
		Me.Label1.Text = "サーバー名(DataSource):"
		'
		'txtServer
		'
		Me.txtServer.Location = New System.Drawing.Point(157, 6)
		Me.txtServer.Name = "txtServer"
		Me.txtServer.Size = New System.Drawing.Size(221, 21)
		Me.txtServer.TabIndex = 63
		'
		'frmConnectionProperty
		'
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
		Me.ClientSize = New System.Drawing.Size(389, 266)
		Me.Controls.Add(Me.Label5)
		Me.Controls.Add(Me.txtInitialCatalog)
		Me.Controls.Add(Me.Label4)
		Me.Controls.Add(Me.txtResult)
		Me.Controls.Add(Me.btnTest)
		Me.Controls.Add(Me.btnOK)
		Me.Controls.Add(Me.btnCancel)
		Me.Controls.Add(Me.txtPassword)
		Me.Controls.Add(Me.txtLogin)
		Me.Controls.Add(Me.Label3)
		Me.Controls.Add(Me.Label2)
		Me.Controls.Add(Me.Label1)
		Me.Controls.Add(Me.txtServer)
		Me.Font = New System.Drawing.Font("Meiryo UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.Name = "frmConnectionProperty"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "frmConnectionProperty"
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	Friend WithEvents Label5 As Label
	Friend WithEvents txtInitialCatalog As TextBox
	Friend WithEvents Label4 As Label
	Friend WithEvents txtResult As TextBox
	Friend WithEvents btnTest As Button
	Friend WithEvents btnOK As Button
	Friend WithEvents btnCancel As Button
	Friend WithEvents txtPassword As TextBox
	Friend WithEvents txtLogin As TextBox
	Friend WithEvents Label3 As Label
	Friend WithEvents Label2 As Label
	Friend WithEvents Label1 As Label
	Friend WithEvents txtServer As TextBox
End Class
