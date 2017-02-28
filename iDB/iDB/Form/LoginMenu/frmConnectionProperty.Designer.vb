<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConnectionProperty
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
		Me.C1Label1 = New C1.Win.C1Input.C1Label()
		Me.txtServer = New C1.Win.C1Input.C1TextBox()
		Me.btnTest = New C1.Win.C1Input.C1Button()
		Me.Panel1 = New System.Windows.Forms.Panel()
		Me.C1Label2 = New C1.Win.C1Input.C1Label()
		Me.C1Label3 = New C1.Win.C1Input.C1Label()
		Me.C1Label4 = New C1.Win.C1Input.C1Label()
		Me.C1Label5 = New C1.Win.C1Input.C1Label()
		Me.txtInitialCatalog = New C1.Win.C1Input.C1TextBox()
		Me.txtUser = New C1.Win.C1Input.C1TextBox()
		Me.txtPassword = New C1.Win.C1Input.C1TextBox()
		Me.btnOK = New C1.Win.C1Input.C1Button()
		Me.btnCancel = New C1.Win.C1Input.C1Button()
		Me.C1Label6 = New C1.Win.C1Input.C1Label()
		Me.txtResult = New C1.Win.C1Input.C1TextBox()
		CType(Me.C1Label1, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.txtServer, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.btnTest, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.Panel1.SuspendLayout()
		CType(Me.C1Label2, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.C1Label3, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.C1Label4, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.C1Label5, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.txtInitialCatalog, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.txtUser, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.txtPassword, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.btnOK, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.btnCancel, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.C1Label6, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.txtResult, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'C1Label1
		'
		Me.C1Label1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.C1Label1.Location = New System.Drawing.Point(12, 53)
		Me.C1Label1.Name = "C1Label1"
		Me.C1Label1.Size = New System.Drawing.Size(120, 26)
		Me.C1Label1.TabIndex = 0
		Me.C1Label1.Tag = Nothing
		Me.C1Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.C1Label1.Value = "サーバー名："
		'
		'txtServer
		'
		Me.txtServer.AutoSize = False
		Me.txtServer.Location = New System.Drawing.Point(138, 54)
		Me.txtServer.Name = "txtServer"
		Me.txtServer.Size = New System.Drawing.Size(300, 26)
		Me.txtServer.TabIndex = 1
		Me.txtServer.Tag = Nothing
		'
		'btnTest
		'
		Me.btnTest.Location = New System.Drawing.Point(12, 286)
		Me.btnTest.Name = "btnTest"
		Me.btnTest.Size = New System.Drawing.Size(80, 26)
		Me.btnTest.TabIndex = 10
		Me.btnTest.Text = "接続テスト"
		Me.btnTest.UseVisualStyleBackColor = True
		'
		'Panel1
		'
		Me.Panel1.Controls.Add(Me.C1Label2)
		Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
		Me.Panel1.Location = New System.Drawing.Point(0, 0)
		Me.Panel1.Name = "Panel1"
		Me.Panel1.Size = New System.Drawing.Size(450, 50)
		Me.Panel1.TabIndex = 4
		'
		'C1Label2
		'
		Me.C1Label2.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.C1Label2.Dock = System.Windows.Forms.DockStyle.Fill
		Me.C1Label2.Font = New System.Drawing.Font("Meiryo UI", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.C1Label2.Location = New System.Drawing.Point(0, 0)
		Me.C1Label2.Name = "C1Label2"
		Me.C1Label2.Size = New System.Drawing.Size(450, 50)
		Me.C1Label2.TabIndex = 0
		Me.C1Label2.Tag = Nothing
		Me.C1Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.C1Label2.Value = "接続設定"
		'
		'C1Label3
		'
		Me.C1Label3.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.C1Label3.Location = New System.Drawing.Point(12, 85)
		Me.C1Label3.Name = "C1Label3"
		Me.C1Label3.Size = New System.Drawing.Size(120, 26)
		Me.C1Label3.TabIndex = 2
		Me.C1Label3.Tag = Nothing
		Me.C1Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.C1Label3.Value = "データベース："
		'
		'C1Label4
		'
		Me.C1Label4.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.C1Label4.Location = New System.Drawing.Point(12, 117)
		Me.C1Label4.Name = "C1Label4"
		Me.C1Label4.Size = New System.Drawing.Size(120, 26)
		Me.C1Label4.TabIndex = 4
		Me.C1Label4.Tag = Nothing
		Me.C1Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.C1Label4.Value = "ユーザー："
		'
		'C1Label5
		'
		Me.C1Label5.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.C1Label5.Location = New System.Drawing.Point(12, 149)
		Me.C1Label5.Name = "C1Label5"
		Me.C1Label5.Size = New System.Drawing.Size(120, 26)
		Me.C1Label5.TabIndex = 6
		Me.C1Label5.Tag = Nothing
		Me.C1Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.C1Label5.Value = "パスワード："
		'
		'txtInitialCatalog
		'
		Me.txtInitialCatalog.AutoSize = False
		Me.txtInitialCatalog.Location = New System.Drawing.Point(138, 86)
		Me.txtInitialCatalog.Name = "txtInitialCatalog"
		Me.txtInitialCatalog.Size = New System.Drawing.Size(300, 26)
		Me.txtInitialCatalog.TabIndex = 3
		Me.txtInitialCatalog.Tag = Nothing
		'
		'txtUser
		'
		Me.txtUser.AutoSize = False
		Me.txtUser.Location = New System.Drawing.Point(138, 118)
		Me.txtUser.Name = "txtUser"
		Me.txtUser.Size = New System.Drawing.Size(300, 26)
		Me.txtUser.TabIndex = 5
		Me.txtUser.Tag = Nothing
		'
		'txtPassword
		'
		Me.txtPassword.AutoSize = False
		Me.txtPassword.Location = New System.Drawing.Point(138, 150)
		Me.txtPassword.Name = "txtPassword"
		Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(9679)
		Me.txtPassword.Size = New System.Drawing.Size(300, 26)
		Me.txtPassword.TabIndex = 7
		Me.txtPassword.Tag = Nothing
		'
		'btnOK
		'
		Me.btnOK.Location = New System.Drawing.Point(272, 286)
		Me.btnOK.Name = "btnOK"
		Me.btnOK.Size = New System.Drawing.Size(80, 26)
		Me.btnOK.TabIndex = 11
		Me.btnOK.Text = "O　K"
		Me.btnOK.UseVisualStyleBackColor = True
		'
		'btnCancel
		'
		Me.btnCancel.Location = New System.Drawing.Point(358, 286)
		Me.btnCancel.Name = "btnCancel"
		Me.btnCancel.Size = New System.Drawing.Size(80, 26)
		Me.btnCancel.TabIndex = 12
		Me.btnCancel.Text = "キャンセル"
		Me.btnCancel.UseVisualStyleBackColor = True
		'
		'C1Label6
		'
		Me.C1Label6.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.C1Label6.Location = New System.Drawing.Point(12, 179)
		Me.C1Label6.Name = "C1Label6"
		Me.C1Label6.Size = New System.Drawing.Size(426, 26)
		Me.C1Label6.TabIndex = 8
		Me.C1Label6.Tag = Nothing
		Me.C1Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.C1Label6.Value = "接続文字列サンプル"
		'
		'txtResult
		'
		Me.txtResult.AutoSize = False
		Me.txtResult.Location = New System.Drawing.Point(12, 208)
		Me.txtResult.Multiline = True
		Me.txtResult.Name = "txtResult"
		Me.txtResult.ReadOnly = True
		Me.txtResult.Size = New System.Drawing.Size(426, 72)
		Me.txtResult.TabIndex = 9
		Me.txtResult.Tag = Nothing
		Me.txtResult.TextDetached = True
		'
		'frmConnectionProperty
		'
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
		Me.ClientSize = New System.Drawing.Size(450, 340)
		Me.Controls.Add(Me.txtResult)
		Me.Controls.Add(Me.C1Label6)
		Me.Controls.Add(Me.btnCancel)
		Me.Controls.Add(Me.btnOK)
		Me.Controls.Add(Me.txtPassword)
		Me.Controls.Add(Me.txtUser)
		Me.Controls.Add(Me.txtInitialCatalog)
		Me.Controls.Add(Me.C1Label5)
		Me.Controls.Add(Me.C1Label4)
		Me.Controls.Add(Me.C1Label3)
		Me.Controls.Add(Me.Panel1)
		Me.Controls.Add(Me.btnTest)
		Me.Controls.Add(Me.txtServer)
		Me.Controls.Add(Me.C1Label1)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.MaximizeBox = False
		Me.Name = "frmConnectionProperty"
		Me.Text = "frmConnectionProperty"
		Me.UserName = Nothing
		Me.Controls.SetChildIndex(Me.C1Label1, 0)
		Me.Controls.SetChildIndex(Me.txtServer, 0)
		Me.Controls.SetChildIndex(Me.btnTest, 0)
		Me.Controls.SetChildIndex(Me.Panel1, 0)
		Me.Controls.SetChildIndex(Me.C1Label3, 0)
		Me.Controls.SetChildIndex(Me.C1Label4, 0)
		Me.Controls.SetChildIndex(Me.C1Label5, 0)
		Me.Controls.SetChildIndex(Me.txtInitialCatalog, 0)
		Me.Controls.SetChildIndex(Me.txtUser, 0)
		Me.Controls.SetChildIndex(Me.txtPassword, 0)
		Me.Controls.SetChildIndex(Me.btnOK, 0)
		Me.Controls.SetChildIndex(Me.btnCancel, 0)
		Me.Controls.SetChildIndex(Me.C1Label6, 0)
		Me.Controls.SetChildIndex(Me.txtResult, 0)
		CType(Me.C1Label1, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.txtServer, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.btnTest, System.ComponentModel.ISupportInitialize).EndInit()
		Me.Panel1.ResumeLayout(False)
		CType(Me.C1Label2, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.C1Label3, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.C1Label4, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.C1Label5, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.txtInitialCatalog, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.txtUser, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.txtPassword, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.btnOK, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.btnCancel, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.C1Label6, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.txtResult, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	Friend WithEvents C1Label1 As C1.Win.C1Input.C1Label
	Friend WithEvents txtServer As C1.Win.C1Input.C1TextBox
	Friend WithEvents btnTest As C1.Win.C1Input.C1Button
	Friend WithEvents Panel1 As Panel
	Friend WithEvents C1Label2 As C1.Win.C1Input.C1Label
	Friend WithEvents C1Label3 As C1.Win.C1Input.C1Label
	Friend WithEvents C1Label4 As C1.Win.C1Input.C1Label
	Friend WithEvents C1Label5 As C1.Win.C1Input.C1Label
	Friend WithEvents txtInitialCatalog As C1.Win.C1Input.C1TextBox
	Friend WithEvents txtUser As C1.Win.C1Input.C1TextBox
	Friend WithEvents txtPassword As C1.Win.C1Input.C1TextBox
	Friend WithEvents btnOK As C1.Win.C1Input.C1Button
	Friend WithEvents btnCancel As C1.Win.C1Input.C1Button
	Friend WithEvents C1Label6 As C1.Win.C1Input.C1Label
	Friend WithEvents txtResult As C1.Win.C1Input.C1TextBox
End Class
