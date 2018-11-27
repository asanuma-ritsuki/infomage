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
		Me.GroupBox2 = New System.Windows.Forms.GroupBox()
		Me.lstResult = New System.Windows.Forms.ListBox()
		Me.GroupBox1 = New System.Windows.Forms.GroupBox()
		Me.Label7 = New System.Windows.Forms.Label()
		Me.numYStart = New System.Windows.Forms.NumericUpDown()
		Me.Label5 = New System.Windows.Forms.Label()
		Me.C1ColorPicker1 = New C1.Win.C1Input.C1ColorPicker()
		Me.txtLogFolder = New System.Windows.Forms.TextBox()
		Me.Label6 = New System.Windows.Forms.Label()
		Me.Label4 = New System.Windows.Forms.Label()
		Me.btnRun = New System.Windows.Forms.Button()
		Me.txtOutputFolder = New System.Windows.Forms.TextBox()
		Me.Label3 = New System.Windows.Forms.Label()
		Me.txtParentFolder = New System.Windows.Forms.TextBox()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.txtCSVFile = New System.Windows.Forms.TextBox()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.GroupBox2.SuspendLayout()
		Me.GroupBox1.SuspendLayout()
		CType(Me.numYStart, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.C1ColorPicker1, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'GroupBox2
		'
		Me.GroupBox2.Controls.Add(Me.lstResult)
		Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
		Me.GroupBox2.Location = New System.Drawing.Point(0, 171)
		Me.GroupBox2.Name = "GroupBox2"
		Me.GroupBox2.Size = New System.Drawing.Size(784, 390)
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
		Me.lstResult.Size = New System.Drawing.Size(778, 367)
		Me.lstResult.TabIndex = 0
		'
		'GroupBox1
		'
		Me.GroupBox1.Controls.Add(Me.Label7)
		Me.GroupBox1.Controls.Add(Me.numYStart)
		Me.GroupBox1.Controls.Add(Me.Label5)
		Me.GroupBox1.Controls.Add(Me.C1ColorPicker1)
		Me.GroupBox1.Controls.Add(Me.txtLogFolder)
		Me.GroupBox1.Controls.Add(Me.Label6)
		Me.GroupBox1.Controls.Add(Me.Label4)
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
		Me.GroupBox1.Size = New System.Drawing.Size(784, 171)
		Me.GroupBox1.TabIndex = 2
		Me.GroupBox1.TabStop = False
		Me.GroupBox1.Text = "出力設定"
		'
		'Label7
		'
		Me.Label7.Location = New System.Drawing.Point(541, 141)
		Me.Label7.Name = "Label7"
		Me.Label7.Size = New System.Drawing.Size(41, 25)
		Me.Label7.TabIndex = 17
		Me.Label7.Text = "Pixel"
		Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'numYStart
		'
		Me.numYStart.Location = New System.Drawing.Point(482, 143)
		Me.numYStart.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
		Me.numYStart.Name = "numYStart"
		Me.numYStart.Size = New System.Drawing.Size(53, 24)
		Me.numYStart.TabIndex = 16
		Me.numYStart.Value = New Decimal(New Integer() {400, 0, 0, 0})
		'
		'Label5
		'
		Me.Label5.Location = New System.Drawing.Point(356, 141)
		Me.Label5.Name = "Label5"
		Me.Label5.Size = New System.Drawing.Size(120, 25)
		Me.Label5.TabIndex = 15
		Me.Label5.Text = "Y座標起点："
		Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'C1ColorPicker1
		'
		Me.C1ColorPicker1.AllowEmpty = False
		Me.C1ColorPicker1.AutoSize = False
		Me.C1ColorPicker1.Color = System.Drawing.Color.Gray
		Me.C1ColorPicker1.ImagePadding = New System.Windows.Forms.Padding(0)
		Me.C1ColorPicker1.Location = New System.Drawing.Point(138, 141)
		Me.C1ColorPicker1.Name = "C1ColorPicker1"
		Me.C1ColorPicker1.Size = New System.Drawing.Size(212, 25)
		Me.C1ColorPicker1.TabIndex = 14
		Me.C1ColorPicker1.Tag = Nothing
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
		'Label4
		'
		Me.Label4.Location = New System.Drawing.Point(12, 141)
		Me.Label4.Name = "Label4"
		Me.Label4.Size = New System.Drawing.Size(120, 25)
		Me.Label4.TabIndex = 8
		Me.Label4.Text = "色しきい値："
		Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
		'frmMain
		'
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
		Me.ClientSize = New System.Drawing.Size(784, 561)
		Me.Controls.Add(Me.GroupBox2)
		Me.Controls.Add(Me.GroupBox1)
		Me.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Name = "frmMain"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "Form1"
		Me.GroupBox2.ResumeLayout(False)
		Me.GroupBox1.ResumeLayout(False)
		Me.GroupBox1.PerformLayout()
		CType(Me.numYStart, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.C1ColorPicker1, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)

	End Sub

	Friend WithEvents GroupBox2 As GroupBox
	Friend WithEvents lstResult As ListBox
	Friend WithEvents GroupBox1 As GroupBox
	Friend WithEvents C1ColorPicker1 As C1.Win.C1Input.C1ColorPicker
	Friend WithEvents txtLogFolder As TextBox
	Friend WithEvents Label6 As Label
	Friend WithEvents Label4 As Label
	Friend WithEvents btnRun As Button
	Friend WithEvents txtOutputFolder As TextBox
	Friend WithEvents Label3 As Label
	Friend WithEvents txtParentFolder As TextBox
	Friend WithEvents Label2 As Label
	Friend WithEvents txtCSVFile As TextBox
	Friend WithEvents Label1 As Label
	Friend WithEvents Label7 As Label
	Friend WithEvents numYStart As NumericUpDown
	Friend WithEvents Label5 As Label
End Class
