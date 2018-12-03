<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMain
	Inherits System.Windows.Forms.Form

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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
		Me.GroupBox1 = New System.Windows.Forms.GroupBox()
		Me.txtFlagString = New System.Windows.Forms.TextBox()
		Me.Label7 = New System.Windows.Forms.Label()
		Me.txtLogFolder = New System.Windows.Forms.TextBox()
		Me.Label6 = New System.Windows.Forms.Label()
		Me.Label5 = New System.Windows.Forms.Label()
		Me.Label4 = New System.Windows.Forms.Label()
		Me.numPercent = New System.Windows.Forms.NumericUpDown()
		Me.btnRun = New System.Windows.Forms.Button()
		Me.txtOutputFolder = New System.Windows.Forms.TextBox()
		Me.Label3 = New System.Windows.Forms.Label()
		Me.txtWorkFolder = New System.Windows.Forms.TextBox()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.txtHeaderFile = New System.Windows.Forms.TextBox()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.GroupBox2 = New System.Windows.Forms.GroupBox()
		Me.lstResult = New System.Windows.Forms.ListBox()
		Me.GroupBox1.SuspendLayout()
		CType(Me.numPercent, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.GroupBox2.SuspendLayout()
		Me.SuspendLayout()
		'
		'GroupBox1
		'
		Me.GroupBox1.Controls.Add(Me.txtFlagString)
		Me.GroupBox1.Controls.Add(Me.Label7)
		Me.GroupBox1.Controls.Add(Me.txtLogFolder)
		Me.GroupBox1.Controls.Add(Me.Label6)
		Me.GroupBox1.Controls.Add(Me.Label5)
		Me.GroupBox1.Controls.Add(Me.Label4)
		Me.GroupBox1.Controls.Add(Me.numPercent)
		Me.GroupBox1.Controls.Add(Me.btnRun)
		Me.GroupBox1.Controls.Add(Me.txtOutputFolder)
		Me.GroupBox1.Controls.Add(Me.Label3)
		Me.GroupBox1.Controls.Add(Me.txtWorkFolder)
		Me.GroupBox1.Controls.Add(Me.Label2)
		Me.GroupBox1.Controls.Add(Me.txtHeaderFile)
		Me.GroupBox1.Controls.Add(Me.Label1)
		Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
		Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
		Me.GroupBox1.Name = "GroupBox1"
		Me.GroupBox1.Size = New System.Drawing.Size(784, 171)
		Me.GroupBox1.TabIndex = 0
		Me.GroupBox1.TabStop = False
		Me.GroupBox1.Text = "出力設定"
		'
		'txtFlagString
		'
		Me.txtFlagString.AllowDrop = True
		Me.txtFlagString.Location = New System.Drawing.Point(361, 141)
		Me.txtFlagString.MaxLength = 1
		Me.txtFlagString.Name = "txtFlagString"
		Me.txtFlagString.Size = New System.Drawing.Size(23, 24)
		Me.txtFlagString.TabIndex = 13
		Me.txtFlagString.Text = "A"
		Me.txtFlagString.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
		'
		'Label7
		'
		Me.Label7.Location = New System.Drawing.Point(235, 140)
		Me.Label7.Name = "Label7"
		Me.Label7.Size = New System.Drawing.Size(120, 25)
		Me.Label7.TabIndex = 12
		Me.Label7.Text = "フラグ文字："
		Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'txtLogFolder
		'
		Me.txtLogFolder.AllowDrop = True
		Me.txtLogFolder.Location = New System.Drawing.Point(138, 111)
		Me.txtLogFolder.Name = "txtLogFolder"
		Me.txtLogFolder.Size = New System.Drawing.Size(528, 24)
		Me.txtLogFolder.TabIndex = 11
		'
		'Label6
		'
		Me.Label6.Location = New System.Drawing.Point(12, 110)
		Me.Label6.Name = "Label6"
		Me.Label6.Size = New System.Drawing.Size(120, 25)
		Me.Label6.TabIndex = 10
		Me.Label6.Text = "ログフォルダ："
		Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'Label5
		'
		Me.Label5.Location = New System.Drawing.Point(204, 141)
		Me.Label5.Name = "Label5"
		Me.Label5.Size = New System.Drawing.Size(26, 25)
		Me.Label5.TabIndex = 9
		Me.Label5.Text = "％"
		Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'Label4
		'
		Me.Label4.Location = New System.Drawing.Point(12, 141)
		Me.Label4.Name = "Label4"
		Me.Label4.Size = New System.Drawing.Size(120, 25)
		Me.Label4.TabIndex = 8
		Me.Label4.Text = "拡大率："
		Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'numPercent
		'
		Me.numPercent.Location = New System.Drawing.Point(138, 141)
		Me.numPercent.Maximum = New Decimal(New Integer() {200, 0, 0, 0})
		Me.numPercent.Name = "numPercent"
		Me.numPercent.Size = New System.Drawing.Size(60, 24)
		Me.numPercent.TabIndex = 7
		Me.numPercent.Value = New Decimal(New Integer() {120, 0, 0, 0})
		'
		'btnRun
		'
		Me.btnRun.Location = New System.Drawing.Point(697, 139)
		Me.btnRun.Name = "btnRun"
		Me.btnRun.Size = New System.Drawing.Size(75, 25)
		Me.btnRun.TabIndex = 6
		Me.btnRun.Text = "実　行"
		Me.btnRun.UseVisualStyleBackColor = True
		'
		'txtOutputFolder
		'
		Me.txtOutputFolder.AllowDrop = True
		Me.txtOutputFolder.Location = New System.Drawing.Point(138, 81)
		Me.txtOutputFolder.Name = "txtOutputFolder"
		Me.txtOutputFolder.Size = New System.Drawing.Size(528, 24)
		Me.txtOutputFolder.TabIndex = 5
		'
		'Label3
		'
		Me.Label3.Location = New System.Drawing.Point(12, 80)
		Me.Label3.Name = "Label3"
		Me.Label3.Size = New System.Drawing.Size(120, 25)
		Me.Label3.TabIndex = 4
		Me.Label3.Text = "出力フォルダ："
		Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'txtWorkFolder
		'
		Me.txtWorkFolder.AllowDrop = True
		Me.txtWorkFolder.Location = New System.Drawing.Point(138, 51)
		Me.txtWorkFolder.Name = "txtWorkFolder"
		Me.txtWorkFolder.Size = New System.Drawing.Size(528, 24)
		Me.txtWorkFolder.TabIndex = 3
		'
		'Label2
		'
		Me.Label2.Location = New System.Drawing.Point(12, 50)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(120, 25)
		Me.Label2.TabIndex = 2
		Me.Label2.Text = "作業フォルダ："
		Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'txtHeaderFile
		'
		Me.txtHeaderFile.AllowDrop = True
		Me.txtHeaderFile.Location = New System.Drawing.Point(138, 21)
		Me.txtHeaderFile.Name = "txtHeaderFile"
		Me.txtHeaderFile.Size = New System.Drawing.Size(528, 24)
		Me.txtHeaderFile.TabIndex = 1
		'
		'Label1
		'
		Me.Label1.Location = New System.Drawing.Point(12, 20)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(120, 25)
		Me.Label1.TabIndex = 0
		Me.Label1.Text = "ヘッダ情報ファイル："
		Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'GroupBox2
		'
		Me.GroupBox2.Controls.Add(Me.lstResult)
		Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
		Me.GroupBox2.Location = New System.Drawing.Point(0, 171)
		Me.GroupBox2.Name = "GroupBox2"
		Me.GroupBox2.Size = New System.Drawing.Size(784, 390)
		Me.GroupBox2.TabIndex = 1
		Me.GroupBox2.TabStop = False
		Me.GroupBox2.Text = "進捗状況"
		'
		'lstResult
		'
		Me.lstResult.Dock = System.Windows.Forms.DockStyle.Fill
		Me.lstResult.FormattingEnabled = True
		Me.lstResult.ItemHeight = 17
		Me.lstResult.Location = New System.Drawing.Point(3, 20)
		Me.lstResult.Name = "lstResult"
		Me.lstResult.Size = New System.Drawing.Size(778, 367)
		Me.lstResult.TabIndex = 0
		'
		'frmMain
		'
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
		Me.ClientSize = New System.Drawing.Size(784, 561)
		Me.Controls.Add(Me.GroupBox2)
		Me.Controls.Add(Me.GroupBox1)
		Me.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
		Me.Name = "frmMain"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "中央大学PDF出力ツール"
		Me.GroupBox1.ResumeLayout(False)
		Me.GroupBox1.PerformLayout()
		CType(Me.numPercent, System.ComponentModel.ISupportInitialize).EndInit()
		Me.GroupBox2.ResumeLayout(False)
		Me.ResumeLayout(False)

	End Sub

	Friend WithEvents GroupBox1 As GroupBox
	Friend WithEvents txtLogFolder As TextBox
	Friend WithEvents Label6 As Label
	Friend WithEvents Label5 As Label
	Friend WithEvents Label4 As Label
	Friend WithEvents numPercent As NumericUpDown
	Friend WithEvents btnRun As Button
	Friend WithEvents txtOutputFolder As TextBox
	Friend WithEvents Label3 As Label
	Friend WithEvents txtWorkFolder As TextBox
	Friend WithEvents Label2 As Label
	Friend WithEvents txtHeaderFile As TextBox
	Friend WithEvents Label1 As Label
	Friend WithEvents GroupBox2 As GroupBox
	Friend WithEvents lstResult As ListBox
	Friend WithEvents txtFlagString As TextBox
	Friend WithEvents Label7 As Label
End Class
