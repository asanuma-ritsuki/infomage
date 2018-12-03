<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
		Me.GroupBox2 = New System.Windows.Forms.GroupBox()
		Me.lstResult = New System.Windows.Forms.ListBox()
		Me.GroupBox1 = New System.Windows.Forms.GroupBox()
		Me.cmbEncode = New System.Windows.Forms.ComboBox()
		Me.txtLogFolder = New System.Windows.Forms.TextBox()
		Me.Label6 = New System.Windows.Forms.Label()
		Me.btnRun = New System.Windows.Forms.Button()
		Me.txtOutputFolder = New System.Windows.Forms.TextBox()
		Me.Label3 = New System.Windows.Forms.Label()
		Me.txtParentFolder = New System.Windows.Forms.TextBox()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.txtCSVFile = New System.Windows.Forms.TextBox()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.chkEnableSerial = New System.Windows.Forms.CheckBox()
		Me.Label4 = New System.Windows.Forms.Label()
		Me.numSerialStart = New System.Windows.Forms.NumericUpDown()
		Me.btnAbort = New System.Windows.Forms.Button()
		Me.Label5 = New System.Windows.Forms.Label()
		Me.txtMergeString = New System.Windows.Forms.TextBox()
		Me.GroupBox3 = New System.Windows.Forms.GroupBox()
		Me.GroupBox2.SuspendLayout()
		Me.GroupBox1.SuspendLayout()
		CType(Me.numSerialStart, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.GroupBox3.SuspendLayout()
		Me.SuspendLayout()
		'
		'GroupBox2
		'
		Me.GroupBox2.Controls.Add(Me.lstResult)
		Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
		Me.GroupBox2.Location = New System.Drawing.Point(0, 212)
		Me.GroupBox2.Name = "GroupBox2"
		Me.GroupBox2.Size = New System.Drawing.Size(784, 349)
		Me.GroupBox2.TabIndex = 3
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
		Me.lstResult.Size = New System.Drawing.Size(778, 326)
		Me.lstResult.TabIndex = 0
		'
		'GroupBox1
		'
		Me.GroupBox1.Controls.Add(Me.GroupBox3)
		Me.GroupBox1.Controls.Add(Me.btnAbort)
		Me.GroupBox1.Controls.Add(Me.cmbEncode)
		Me.GroupBox1.Controls.Add(Me.txtLogFolder)
		Me.GroupBox1.Controls.Add(Me.Label6)
		Me.GroupBox1.Controls.Add(Me.btnRun)
		Me.GroupBox1.Controls.Add(Me.txtOutputFolder)
		Me.GroupBox1.Controls.Add(Me.Label3)
		Me.GroupBox1.Controls.Add(Me.txtParentFolder)
		Me.GroupBox1.Controls.Add(Me.Label2)
		Me.GroupBox1.Controls.Add(Me.txtCSVFile)
		Me.GroupBox1.Controls.Add(Me.Label1)
		Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
		Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
		Me.GroupBox1.Name = "GroupBox1"
		Me.GroupBox1.Size = New System.Drawing.Size(784, 212)
		Me.GroupBox1.TabIndex = 2
		Me.GroupBox1.TabStop = False
		Me.GroupBox1.Text = "出力設定"
		'
		'cmbEncode
		'
		Me.cmbEncode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cmbEncode.FormattingEnabled = True
		Me.cmbEncode.Items.AddRange(New Object() {"UTF-8", "Shift-JIS"})
		Me.cmbEncode.Location = New System.Drawing.Point(672, 21)
		Me.cmbEncode.Name = "cmbEncode"
		Me.cmbEncode.Size = New System.Drawing.Size(100, 25)
		Me.cmbEncode.TabIndex = 12
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
		'btnRun
		'
		Me.btnRun.Location = New System.Drawing.Point(697, 149)
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
		'txtParentFolder
		'
		Me.txtParentFolder.AllowDrop = True
		Me.txtParentFolder.Location = New System.Drawing.Point(138, 51)
		Me.txtParentFolder.Name = "txtParentFolder"
		Me.txtParentFolder.Size = New System.Drawing.Size(528, 24)
		Me.txtParentFolder.TabIndex = 3
		'
		'Label2
		'
		Me.Label2.Location = New System.Drawing.Point(12, 50)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(120, 25)
		Me.Label2.TabIndex = 2
		Me.Label2.Text = "親フォルダ："
		Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'txtCSVFile
		'
		Me.txtCSVFile.AllowDrop = True
		Me.txtCSVFile.Location = New System.Drawing.Point(138, 21)
		Me.txtCSVFile.Name = "txtCSVFile"
		Me.txtCSVFile.Size = New System.Drawing.Size(528, 24)
		Me.txtCSVFile.TabIndex = 1
		'
		'Label1
		'
		Me.Label1.Location = New System.Drawing.Point(12, 20)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(120, 25)
		Me.Label1.TabIndex = 0
		Me.Label1.Text = "CSVファイル："
		Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'chkEnableSerial
		'
		Me.chkEnableSerial.AutoSize = True
		Me.chkEnableSerial.Checked = True
		Me.chkEnableSerial.CheckState = System.Windows.Forms.CheckState.Checked
		Me.chkEnableSerial.Location = New System.Drawing.Point(46, 25)
		Me.chkEnableSerial.Name = "chkEnableSerial"
		Me.chkEnableSerial.Size = New System.Drawing.Size(159, 21)
		Me.chkEnableSerial.TabIndex = 13
		Me.chkEnableSerial.Text = "最終行に連番を付与する"
		Me.chkEnableSerial.UseVisualStyleBackColor = True
		'
		'Label4
		'
		Me.Label4.Location = New System.Drawing.Point(211, 22)
		Me.Label4.Name = "Label4"
		Me.Label4.Size = New System.Drawing.Size(81, 25)
		Me.Label4.TabIndex = 14
		Me.Label4.Text = "開始連番："
		Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'numSerialStart
		'
		Me.numSerialStart.Location = New System.Drawing.Point(298, 23)
		Me.numSerialStart.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
		Me.numSerialStart.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
		Me.numSerialStart.Name = "numSerialStart"
		Me.numSerialStart.Size = New System.Drawing.Size(56, 24)
		Me.numSerialStart.TabIndex = 15
		Me.numSerialStart.Value = New Decimal(New Integer() {1, 0, 0, 0})
		'
		'btnAbort
		'
		Me.btnAbort.Location = New System.Drawing.Point(697, 180)
		Me.btnAbort.Name = "btnAbort"
		Me.btnAbort.Size = New System.Drawing.Size(75, 25)
		Me.btnAbort.TabIndex = 16
		Me.btnAbort.Text = "中　断"
		Me.btnAbort.UseVisualStyleBackColor = True
		'
		'Label5
		'
		Me.Label5.Location = New System.Drawing.Point(360, 21)
		Me.Label5.Name = "Label5"
		Me.Label5.Size = New System.Drawing.Size(90, 25)
		Me.Label5.TabIndex = 17
		Me.Label5.Text = "結合文字列："
		Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'txtMergeString
		'
		Me.txtMergeString.AllowDrop = True
		Me.txtMergeString.Location = New System.Drawing.Point(456, 23)
		Me.txtMergeString.Name = "txtMergeString"
		Me.txtMergeString.Size = New System.Drawing.Size(98, 24)
		Me.txtMergeString.TabIndex = 18
		Me.txtMergeString.Text = " - "
		'
		'GroupBox3
		'
		Me.GroupBox3.Controls.Add(Me.txtMergeString)
		Me.GroupBox3.Controls.Add(Me.chkEnableSerial)
		Me.GroupBox3.Controls.Add(Me.Label5)
		Me.GroupBox3.Controls.Add(Me.Label4)
		Me.GroupBox3.Controls.Add(Me.numSerialStart)
		Me.GroupBox3.Location = New System.Drawing.Point(39, 142)
		Me.GroupBox3.Name = "GroupBox3"
		Me.GroupBox3.Size = New System.Drawing.Size(627, 63)
		Me.GroupBox3.TabIndex = 19
		Me.GroupBox3.TabStop = False
		Me.GroupBox3.Text = "連番付与設定"
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
		Me.Text = "Form1"
		Me.GroupBox2.ResumeLayout(False)
		Me.GroupBox1.ResumeLayout(False)
		Me.GroupBox1.PerformLayout()
		CType(Me.numSerialStart, System.ComponentModel.ISupportInitialize).EndInit()
		Me.GroupBox3.ResumeLayout(False)
		Me.GroupBox3.PerformLayout()
		Me.ResumeLayout(False)

	End Sub

	Friend WithEvents GroupBox2 As GroupBox
	Friend WithEvents lstResult As ListBox
	Friend WithEvents GroupBox1 As GroupBox
	Friend WithEvents txtLogFolder As TextBox
	Friend WithEvents Label6 As Label
	Friend WithEvents btnRun As Button
	Friend WithEvents txtOutputFolder As TextBox
	Friend WithEvents Label3 As Label
	Friend WithEvents txtParentFolder As TextBox
	Friend WithEvents Label2 As Label
	Friend WithEvents txtCSVFile As TextBox
	Friend WithEvents Label1 As Label
	Friend WithEvents cmbEncode As ComboBox
	Friend WithEvents numSerialStart As NumericUpDown
	Friend WithEvents Label4 As Label
	Friend WithEvents chkEnableSerial As CheckBox
	Friend WithEvents btnAbort As Button
	Friend WithEvents GroupBox3 As GroupBox
	Friend WithEvents txtMergeString As TextBox
	Friend WithEvents Label5 As Label
End Class
