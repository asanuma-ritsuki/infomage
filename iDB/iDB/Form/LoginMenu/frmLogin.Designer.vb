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
		Me.components = New System.ComponentModel.Container()
		Me.C1ApplicationZoom1 = New C1.Win.TouchToolKit.C1ApplicationZoom(Me.components)
		Me.Panel1 = New System.Windows.Forms.Panel()
		Me.C1Label1 = New C1.Win.C1Input.C1Label()
		Me.C1Label2 = New C1.Win.C1Input.C1Label()
		Me.txtPassword = New C1.Win.C1Input.C1TextBox()
		Me.C1Label3 = New C1.Win.C1Input.C1Label()
		Me.C1Label4 = New C1.Win.C1Input.C1Label()
		Me.btnUpdateHistory = New C1.Win.C1Input.C1Button()
		Me.btnConnectionProperty = New C1.Win.C1Input.C1Button()
		Me.btnExit = New C1.Win.C1Input.C1Button()
		Me.btnLogin = New C1.Win.C1Input.C1Button()
		Me.cmbUserID = New C1.Win.C1Input.C1ComboBox()
		Me.cmbGroup = New C1.Win.C1Input.C1ComboBox()
		Me.Panel1.SuspendLayout()
		CType(Me.C1Label1, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.C1Label2, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.txtPassword, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.C1Label3, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.C1Label4, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.btnUpdateHistory, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.btnConnectionProperty, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.btnExit, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.btnLogin, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.cmbUserID, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.cmbGroup, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'Panel1
		'
		Me.Panel1.Controls.Add(Me.C1Label1)
		Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
		Me.Panel1.Location = New System.Drawing.Point(0, 0)
		Me.Panel1.Name = "Panel1"
		Me.Panel1.Size = New System.Drawing.Size(472, 50)
		Me.Panel1.TabIndex = 1
		'
		'C1Label1
		'
		Me.C1Label1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.C1Label1.Dock = System.Windows.Forms.DockStyle.Fill
		Me.C1Label1.Font = New System.Drawing.Font("Meiryo UI", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.C1Label1.Location = New System.Drawing.Point(0, 0)
		Me.C1Label1.Name = "C1Label1"
		Me.C1Label1.Size = New System.Drawing.Size(472, 50)
		Me.C1Label1.TabIndex = 0
		Me.C1Label1.Tag = Nothing
		Me.C1Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.C1Label1.Value = "画像データベースツール(仮)"
		'
		'C1Label2
		'
		Me.C1Label2.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.C1Label2.Location = New System.Drawing.Point(95, 56)
		Me.C1Label2.Name = "C1Label2"
		Me.C1Label2.Size = New System.Drawing.Size(120, 26)
		Me.C1Label2.TabIndex = 0
		Me.C1Label2.Tag = Nothing
		Me.C1Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.C1Label2.Value = "生産グループ："
		'
		'txtPassword
		'
		Me.txtPassword.AutoSize = False
		Me.txtPassword.Location = New System.Drawing.Point(221, 121)
		Me.txtPassword.Name = "txtPassword"
		Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(9679)
		Me.txtPassword.Size = New System.Drawing.Size(200, 26)
		Me.txtPassword.TabIndex = 6
		Me.txtPassword.Tag = Nothing
		'
		'C1Label3
		'
		Me.C1Label3.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.C1Label3.Location = New System.Drawing.Point(95, 89)
		Me.C1Label3.Name = "C1Label3"
		Me.C1Label3.Size = New System.Drawing.Size(120, 26)
		Me.C1Label3.TabIndex = 3
		Me.C1Label3.Tag = Nothing
		Me.C1Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.C1Label3.Value = "ユーザー名："
		'
		'C1Label4
		'
		Me.C1Label4.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.C1Label4.Location = New System.Drawing.Point(95, 121)
		Me.C1Label4.Name = "C1Label4"
		Me.C1Label4.Size = New System.Drawing.Size(120, 26)
		Me.C1Label4.TabIndex = 5
		Me.C1Label4.Tag = Nothing
		Me.C1Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.C1Label4.Value = "パスワード："
		'
		'btnUpdateHistory
		'
		Me.btnUpdateHistory.Location = New System.Drawing.Point(12, 180)
		Me.btnUpdateHistory.Name = "btnUpdateHistory"
		Me.btnUpdateHistory.Size = New System.Drawing.Size(80, 26)
		Me.btnUpdateHistory.TabIndex = 10
		Me.btnUpdateHistory.Text = "更新履歴"
		Me.btnUpdateHistory.UseVisualStyleBackColor = True
		'
		'btnConnectionProperty
		'
		Me.btnConnectionProperty.Location = New System.Drawing.Point(12, 148)
		Me.btnConnectionProperty.Name = "btnConnectionProperty"
		Me.btnConnectionProperty.Size = New System.Drawing.Size(80, 26)
		Me.btnConnectionProperty.TabIndex = 9
		Me.btnConnectionProperty.Text = "接続設定"
		Me.btnConnectionProperty.UseVisualStyleBackColor = True
		'
		'btnExit
		'
		Me.btnExit.Location = New System.Drawing.Point(380, 180)
		Me.btnExit.Name = "btnExit"
		Me.btnExit.Size = New System.Drawing.Size(80, 26)
		Me.btnExit.TabIndex = 8
		Me.btnExit.Text = "終　了"
		Me.btnExit.UseVisualStyleBackColor = True
		'
		'btnLogin
		'
		Me.btnLogin.Location = New System.Drawing.Point(294, 180)
		Me.btnLogin.Name = "btnLogin"
		Me.btnLogin.Size = New System.Drawing.Size(80, 26)
		Me.btnLogin.TabIndex = 7
		Me.btnLogin.Text = "ログイン"
		Me.btnLogin.UseVisualStyleBackColor = True
		'
		'cmbUserID
		'
		Me.cmbUserID.AllowSpinLoop = False
		Me.cmbUserID.AutoSize = False
		Me.cmbUserID.Cursor = System.Windows.Forms.Cursors.Arrow
		Me.cmbUserID.DropDownStyle = C1.Win.C1Input.DropDownStyle.DropDownList
		Me.cmbUserID.GapHeight = 0
		Me.cmbUserID.ImagePadding = New System.Windows.Forms.Padding(0)
		Me.cmbUserID.ItemsDisplayMember = ""
		Me.cmbUserID.ItemsValueMember = ""
		Me.cmbUserID.Location = New System.Drawing.Point(221, 89)
		Me.cmbUserID.Name = "cmbUserID"
		Me.cmbUserID.Size = New System.Drawing.Size(200, 26)
		Me.cmbUserID.TabIndex = 4
		Me.cmbUserID.Tag = Nothing
		Me.cmbUserID.TextDetached = True
		'
		'cmbGroup
		'
		Me.cmbGroup.AllowSpinLoop = False
		Me.cmbGroup.AutoSize = False
		Me.cmbGroup.Cursor = System.Windows.Forms.Cursors.Arrow
		Me.cmbGroup.DropDownStyle = C1.Win.C1Input.DropDownStyle.DropDownList
		Me.cmbGroup.GapHeight = 0
		Me.cmbGroup.ImagePadding = New System.Windows.Forms.Padding(0)
		Me.cmbGroup.ItemsDisplayMember = ""
		Me.cmbGroup.ItemsValueMember = ""
		Me.cmbGroup.Location = New System.Drawing.Point(221, 56)
		Me.cmbGroup.Name = "cmbGroup"
		Me.cmbGroup.Size = New System.Drawing.Size(200, 26)
		Me.cmbGroup.TabIndex = 2
		Me.cmbGroup.Tag = Nothing
		Me.cmbGroup.TextDetached = True
		'
		'frmLogin
		'
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
		Me.ClientSize = New System.Drawing.Size(472, 234)
		Me.Controls.Add(Me.cmbGroup)
		Me.Controls.Add(Me.cmbUserID)
		Me.Controls.Add(Me.btnLogin)
		Me.Controls.Add(Me.btnExit)
		Me.Controls.Add(Me.btnConnectionProperty)
		Me.Controls.Add(Me.btnUpdateHistory)
		Me.Controls.Add(Me.C1Label4)
		Me.Controls.Add(Me.C1Label3)
		Me.Controls.Add(Me.txtPassword)
		Me.Controls.Add(Me.C1Label2)
		Me.Controls.Add(Me.Panel1)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Margin = New System.Windows.Forms.Padding(2)
		Me.MaximizeBox = False
		Me.Name = "frmLogin"
		Me.Text = "frmLogin"
		Me.UserName = Nothing
		Me.Controls.SetChildIndex(Me.Panel1, 0)
		Me.Controls.SetChildIndex(Me.C1Label2, 0)
		Me.Controls.SetChildIndex(Me.txtPassword, 0)
		Me.Controls.SetChildIndex(Me.C1Label3, 0)
		Me.Controls.SetChildIndex(Me.C1Label4, 0)
		Me.Controls.SetChildIndex(Me.btnUpdateHistory, 0)
		Me.Controls.SetChildIndex(Me.btnConnectionProperty, 0)
		Me.Controls.SetChildIndex(Me.btnExit, 0)
		Me.Controls.SetChildIndex(Me.btnLogin, 0)
		Me.Controls.SetChildIndex(Me.cmbUserID, 0)
		Me.Controls.SetChildIndex(Me.cmbGroup, 0)
		Me.Panel1.ResumeLayout(False)
		CType(Me.C1Label1, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.C1Label2, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.txtPassword, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.C1Label3, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.C1Label4, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.btnUpdateHistory, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.btnConnectionProperty, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.btnExit, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.btnLogin, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.cmbUserID, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.cmbGroup, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
	Friend WithEvents C1ApplicationZoom1 As C1.Win.TouchToolKit.C1ApplicationZoom
	Friend WithEvents Panel1 As Panel
	Friend WithEvents C1Label1 As C1.Win.C1Input.C1Label
	Friend WithEvents C1Label2 As C1.Win.C1Input.C1Label
	Friend WithEvents txtPassword As C1.Win.C1Input.C1TextBox
	Friend WithEvents C1Label3 As C1.Win.C1Input.C1Label
	Friend WithEvents C1Label4 As C1.Win.C1Input.C1Label
	Friend WithEvents btnUpdateHistory As C1.Win.C1Input.C1Button
	Friend WithEvents btnConnectionProperty As C1.Win.C1Input.C1Button
	Friend WithEvents btnExit As C1.Win.C1Input.C1Button
	Friend WithEvents btnLogin As C1.Win.C1Input.C1Button
	Friend WithEvents cmbUserID As C1.Win.C1Input.C1ComboBox
	Friend WithEvents cmbGroup As C1.Win.C1Input.C1ComboBox
End Class
