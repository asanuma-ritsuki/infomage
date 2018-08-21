<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLogin
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLogin))
		Me.PictureBox1 = New System.Windows.Forms.PictureBox()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.cmbUserName = New System.Windows.Forms.ComboBox()
		Me.btnLogin = New System.Windows.Forms.Button()
		Me.btnConnectionSetting = New System.Windows.Forms.Button()
		CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'PictureBox1
		'
		Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
		Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
		Me.PictureBox1.Name = "PictureBox1"
		Me.PictureBox1.Size = New System.Drawing.Size(457, 97)
		Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
		Me.PictureBox1.TabIndex = 0
		Me.PictureBox1.TabStop = False
		'
		'Label1
		'
		Me.Label1.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 30.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(204, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(1, Byte), Integer))
		Me.Label1.Location = New System.Drawing.Point(116, 64)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(353, 45)
		Me.Label1.TabIndex = 1
		Me.Label1.Text = "手封入チェッカー"
		'
		'Label2
		'
		Me.Label2.AutoSize = True
		Me.Label2.Location = New System.Drawing.Point(170, 147)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(60, 17)
		Me.Label2.TabIndex = 2
		Me.Label2.Text = "作業者："
		'
		'cmbUserName
		'
		Me.cmbUserName.FormattingEnabled = True
		Me.cmbUserName.ImeMode = System.Windows.Forms.ImeMode.Hiragana
		Me.cmbUserName.Location = New System.Drawing.Point(236, 144)
		Me.cmbUserName.Name = "cmbUserName"
		Me.cmbUserName.Size = New System.Drawing.Size(152, 25)
		Me.cmbUserName.TabIndex = 3
		'
		'btnLogin
		'
		Me.btnLogin.Location = New System.Drawing.Point(394, 143)
		Me.btnLogin.Name = "btnLogin"
		Me.btnLogin.Size = New System.Drawing.Size(75, 25)
		Me.btnLogin.TabIndex = 4
		Me.btnLogin.Text = "ログイン"
		Me.btnLogin.UseVisualStyleBackColor = True
		'
		'btnConnectionSetting
		'
		Me.btnConnectionSetting.Location = New System.Drawing.Point(394, 174)
		Me.btnConnectionSetting.Name = "btnConnectionSetting"
		Me.btnConnectionSetting.Size = New System.Drawing.Size(75, 25)
		Me.btnConnectionSetting.TabIndex = 5
		Me.btnConnectionSetting.Text = "接続設定"
		Me.btnConnectionSetting.UseVisualStyleBackColor = True
		'
		'frmLogin
		'
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
		Me.ClientSize = New System.Drawing.Size(481, 211)
		Me.Controls.Add(Me.btnConnectionSetting)
		Me.Controls.Add(Me.btnLogin)
		Me.Controls.Add(Me.cmbUserName)
		Me.Controls.Add(Me.Label2)
		Me.Controls.Add(Me.Label1)
		Me.Controls.Add(Me.PictureBox1)
		Me.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
		Me.Margin = New System.Windows.Forms.Padding(4)
		Me.Name = "frmLogin"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "frmLogin"
		CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	Friend WithEvents PictureBox1 As PictureBox
	Friend WithEvents Label1 As Label
	Friend WithEvents Label2 As Label
	Friend WithEvents cmbUserName As ComboBox
	Friend WithEvents btnLogin As Button
	Friend WithEvents btnConnectionSetting As Button
End Class
