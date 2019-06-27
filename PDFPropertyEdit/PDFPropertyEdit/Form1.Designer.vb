<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
		Me.GroupBox1 = New System.Windows.Forms.GroupBox()
		Me.Label14 = New System.Windows.Forms.Label()
		Me.txtTIFTargetPath = New System.Windows.Forms.TextBox()
		Me.Label13 = New System.Windows.Forms.Label()
		Me.cmbTIFTitle = New System.Windows.Forms.ComboBox()
		Me.txtTIFAuthor = New System.Windows.Forms.TextBox()
		Me.Label12 = New System.Windows.Forms.Label()
		Me.txtTIFSubject = New System.Windows.Forms.TextBox()
		Me.Label10 = New System.Windows.Forms.Label()
		Me.Label11 = New System.Windows.Forms.Label()
		Me.RadioButton3 = New System.Windows.Forms.RadioButton()
		Me.Label9 = New System.Windows.Forms.Label()
		Me.Label8 = New System.Windows.Forms.Label()
		Me.txtOutPath = New System.Windows.Forms.TextBox()
		Me.Label7 = New System.Windows.Forms.Label()
		Me.txtTargetPath = New System.Windows.Forms.TextBox()
		Me.Label6 = New System.Windows.Forms.Label()
		Me.btnStop = New System.Windows.Forms.Button()
		Me.btnStart = New System.Windows.Forms.Button()
		Me.Label5 = New System.Windows.Forms.Label()
		Me.txtCSVFile = New System.Windows.Forms.TextBox()
		Me.txtKeyword = New System.Windows.Forms.TextBox()
		Me.Label4 = New System.Windows.Forms.Label()
		Me.txtSubTitle = New System.Windows.Forms.TextBox()
		Me.Label3 = New System.Windows.Forms.Label()
		Me.txtAuthor = New System.Windows.Forms.TextBox()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.txtTitle = New System.Windows.Forms.TextBox()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.RadioButton2 = New System.Windows.Forms.RadioButton()
		Me.RadioButton1 = New System.Windows.Forms.RadioButton()
		Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
		Me.ProgressBar1 = New System.Windows.Forms.ToolStripProgressBar()
		Me.lblProgress = New System.Windows.Forms.ToolStripStatusLabel()
		Me.cmbExtension = New System.Windows.Forms.ComboBox()
		Me.GroupBox1.SuspendLayout()
		Me.StatusStrip1.SuspendLayout()
		Me.SuspendLayout()
		'
		'GroupBox1
		'
		Me.GroupBox1.Controls.Add(Me.cmbExtension)
		Me.GroupBox1.Controls.Add(Me.Label14)
		Me.GroupBox1.Controls.Add(Me.txtTIFTargetPath)
		Me.GroupBox1.Controls.Add(Me.Label13)
		Me.GroupBox1.Controls.Add(Me.cmbTIFTitle)
		Me.GroupBox1.Controls.Add(Me.txtTIFAuthor)
		Me.GroupBox1.Controls.Add(Me.Label12)
		Me.GroupBox1.Controls.Add(Me.txtTIFSubject)
		Me.GroupBox1.Controls.Add(Me.Label10)
		Me.GroupBox1.Controls.Add(Me.Label11)
		Me.GroupBox1.Controls.Add(Me.RadioButton3)
		Me.GroupBox1.Controls.Add(Me.Label9)
		Me.GroupBox1.Controls.Add(Me.Label8)
		Me.GroupBox1.Controls.Add(Me.txtOutPath)
		Me.GroupBox1.Controls.Add(Me.Label7)
		Me.GroupBox1.Controls.Add(Me.txtTargetPath)
		Me.GroupBox1.Controls.Add(Me.Label6)
		Me.GroupBox1.Controls.Add(Me.btnStop)
		Me.GroupBox1.Controls.Add(Me.btnStart)
		Me.GroupBox1.Controls.Add(Me.Label5)
		Me.GroupBox1.Controls.Add(Me.txtCSVFile)
		Me.GroupBox1.Controls.Add(Me.txtKeyword)
		Me.GroupBox1.Controls.Add(Me.Label4)
		Me.GroupBox1.Controls.Add(Me.txtSubTitle)
		Me.GroupBox1.Controls.Add(Me.Label3)
		Me.GroupBox1.Controls.Add(Me.txtAuthor)
		Me.GroupBox1.Controls.Add(Me.Label2)
		Me.GroupBox1.Controls.Add(Me.txtTitle)
		Me.GroupBox1.Controls.Add(Me.Label1)
		Me.GroupBox1.Controls.Add(Me.RadioButton2)
		Me.GroupBox1.Controls.Add(Me.RadioButton1)
		Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
		Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
		Me.GroupBox1.Name = "GroupBox1"
		Me.GroupBox1.Size = New System.Drawing.Size(628, 572)
		Me.GroupBox1.TabIndex = 0
		Me.GroupBox1.TabStop = False
		Me.GroupBox1.Text = "設定"
		'
		'Label14
		'
		Me.Label14.AutoSize = True
		Me.Label14.ForeColor = System.Drawing.Color.Red
		Me.Label14.Location = New System.Drawing.Point(204, 390)
		Me.Label14.Name = "Label14"
		Me.Label14.Size = New System.Drawing.Size(274, 17)
		Me.Label14.TabIndex = 30
		Me.Label14.Text = "※対象フォルダは日本語を含まないようにしてください"
		'
		'txtTIFTargetPath
		'
		Me.txtTIFTargetPath.AllowDrop = True
		Me.txtTIFTargetPath.Location = New System.Drawing.Point(140, 415)
		Me.txtTIFTargetPath.Name = "txtTIFTargetPath"
		Me.txtTIFTargetPath.Size = New System.Drawing.Size(472, 24)
		Me.txtTIFTargetPath.TabIndex = 10
		'
		'Label13
		'
		Me.Label13.Location = New System.Drawing.Point(34, 415)
		Me.Label13.Name = "Label13"
		Me.Label13.Size = New System.Drawing.Size(100, 24)
		Me.Label13.TabIndex = 28
		Me.Label13.Text = "対象フォルダ："
		Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'cmbTIFTitle
		'
		Me.cmbTIFTitle.FormattingEnabled = True
		Me.cmbTIFTitle.Items.AddRange(New Object() {"上位フォルダ名を採用"})
		Me.cmbTIFTitle.Location = New System.Drawing.Point(140, 445)
		Me.cmbTIFTitle.Name = "cmbTIFTitle"
		Me.cmbTIFTitle.Size = New System.Drawing.Size(472, 25)
		Me.cmbTIFTitle.TabIndex = 11
		'
		'txtTIFAuthor
		'
		Me.txtTIFAuthor.Location = New System.Drawing.Point(140, 506)
		Me.txtTIFAuthor.Name = "txtTIFAuthor"
		Me.txtTIFAuthor.Size = New System.Drawing.Size(472, 24)
		Me.txtTIFAuthor.TabIndex = 13
		Me.txtTIFAuthor.Text = "一橋大学経済研究所附属社会科学統計情報研究センター"
		'
		'Label12
		'
		Me.Label12.Location = New System.Drawing.Point(34, 506)
		Me.Label12.Name = "Label12"
		Me.Label12.Size = New System.Drawing.Size(100, 24)
		Me.Label12.TabIndex = 25
		Me.Label12.Text = "作成者："
		Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'txtTIFSubject
		'
		Me.txtTIFSubject.Location = New System.Drawing.Point(140, 476)
		Me.txtTIFSubject.Name = "txtTIFSubject"
		Me.txtTIFSubject.Size = New System.Drawing.Size(472, 24)
		Me.txtTIFSubject.TabIndex = 12
		Me.txtTIFSubject.Text = "国民所得推計研究会資料"
		'
		'Label10
		'
		Me.Label10.Location = New System.Drawing.Point(34, 476)
		Me.Label10.Name = "Label10"
		Me.Label10.Size = New System.Drawing.Size(100, 24)
		Me.Label10.TabIndex = 23
		Me.Label10.Text = "件名："
		Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'Label11
		'
		Me.Label11.Location = New System.Drawing.Point(34, 446)
		Me.Label11.Name = "Label11"
		Me.Label11.Size = New System.Drawing.Size(100, 24)
		Me.Label11.TabIndex = 21
		Me.Label11.Text = "タイトル："
		Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'RadioButton3
		'
		Me.RadioButton3.AutoSize = True
		Me.RadioButton3.Location = New System.Drawing.Point(12, 388)
		Me.RadioButton3.Name = "RadioButton3"
		Me.RadioButton3.Size = New System.Drawing.Size(186, 21)
		Me.RadioButton3.TabIndex = 9
		Me.RadioButton3.TabStop = True
		Me.RadioButton3.Text = "TIF画像にプロパティを設定する"
		Me.RadioButton3.UseVisualStyleBackColor = True
		'
		'Label9
		'
		Me.Label9.AutoSize = True
		Me.Label9.ForeColor = System.Drawing.Color.Red
		Me.Label9.Location = New System.Drawing.Point(172, 328)
		Me.Label9.Name = "Label9"
		Me.Label9.Size = New System.Drawing.Size(142, 17)
		Me.Label9.TabIndex = 19
		Me.Label9.Text = "※ヘッダは削除してください"
		'
		'Label8
		'
		Me.Label8.AutoSize = True
		Me.Label8.ForeColor = System.Drawing.Color.Red
		Me.Label8.Location = New System.Drawing.Point(172, 307)
		Me.Label8.Name = "Label8"
		Me.Label8.Size = New System.Drawing.Size(423, 17)
		Me.Label8.TabIndex = 18
		Me.Label8.Text = "※""元ファイル"",""保存先フォルダ"",""タイトル"",""作成者"",""サブタイトル"",""キーワード"""
		'
		'txtOutPath
		'
		Me.txtOutPath.AllowDrop = True
		Me.txtOutPath.Location = New System.Drawing.Point(140, 79)
		Me.txtOutPath.Name = "txtOutPath"
		Me.txtOutPath.Size = New System.Drawing.Size(472, 24)
		Me.txtOutPath.TabIndex = 2
		'
		'Label7
		'
		Me.Label7.Location = New System.Drawing.Point(34, 79)
		Me.Label7.Name = "Label7"
		Me.Label7.Size = New System.Drawing.Size(100, 24)
		Me.Label7.TabIndex = 16
		Me.Label7.Text = "出力フォルダ："
		Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'txtTargetPath
		'
		Me.txtTargetPath.AllowDrop = True
		Me.txtTargetPath.Location = New System.Drawing.Point(140, 49)
		Me.txtTargetPath.Name = "txtTargetPath"
		Me.txtTargetPath.Size = New System.Drawing.Size(472, 24)
		Me.txtTargetPath.TabIndex = 1
		'
		'Label6
		'
		Me.Label6.Location = New System.Drawing.Point(34, 49)
		Me.Label6.Name = "Label6"
		Me.Label6.Size = New System.Drawing.Size(100, 24)
		Me.Label6.TabIndex = 14
		Me.Label6.Text = "対象フォルダ："
		Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'btnStop
		'
		Me.btnStop.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.btnStop.Location = New System.Drawing.Point(466, 540)
		Me.btnStop.Name = "btnStop"
		Me.btnStop.Size = New System.Drawing.Size(75, 25)
		Me.btnStop.TabIndex = 14
		Me.btnStop.Text = "中　断"
		Me.btnStop.UseVisualStyleBackColor = True
		'
		'btnStart
		'
		Me.btnStart.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.btnStart.Location = New System.Drawing.Point(547, 540)
		Me.btnStart.Name = "btnStart"
		Me.btnStart.Size = New System.Drawing.Size(75, 25)
		Me.btnStart.TabIndex = 15
		Me.btnStart.Text = "開　始"
		Me.btnStart.UseVisualStyleBackColor = True
		'
		'Label5
		'
		Me.Label5.Location = New System.Drawing.Point(38, 348)
		Me.Label5.Name = "Label5"
		Me.Label5.Size = New System.Drawing.Size(100, 24)
		Me.Label5.TabIndex = 11
		Me.Label5.Text = "CSVファイル："
		Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'txtCSVFile
		'
		Me.txtCSVFile.AllowDrop = True
		Me.txtCSVFile.Location = New System.Drawing.Point(144, 348)
		Me.txtCSVFile.Name = "txtCSVFile"
		Me.txtCSVFile.Size = New System.Drawing.Size(366, 24)
		Me.txtCSVFile.TabIndex = 8
		'
		'txtKeyword
		'
		Me.txtKeyword.Location = New System.Drawing.Point(140, 227)
		Me.txtKeyword.Multiline = True
		Me.txtKeyword.Name = "txtKeyword"
		Me.txtKeyword.Size = New System.Drawing.Size(472, 72)
		Me.txtKeyword.TabIndex = 6
		'
		'Label4
		'
		Me.Label4.Location = New System.Drawing.Point(34, 227)
		Me.Label4.Name = "Label4"
		Me.Label4.Size = New System.Drawing.Size(100, 24)
		Me.Label4.TabIndex = 8
		Me.Label4.Text = "キーワード："
		Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'txtSubTitle
		'
		Me.txtSubTitle.Location = New System.Drawing.Point(140, 197)
		Me.txtSubTitle.Name = "txtSubTitle"
		Me.txtSubTitle.Size = New System.Drawing.Size(472, 24)
		Me.txtSubTitle.TabIndex = 5
		'
		'Label3
		'
		Me.Label3.Location = New System.Drawing.Point(34, 197)
		Me.Label3.Name = "Label3"
		Me.Label3.Size = New System.Drawing.Size(100, 24)
		Me.Label3.TabIndex = 6
		Me.Label3.Text = "サブタイトル："
		Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'txtAuthor
		'
		Me.txtAuthor.Location = New System.Drawing.Point(140, 167)
		Me.txtAuthor.Name = "txtAuthor"
		Me.txtAuthor.Size = New System.Drawing.Size(472, 24)
		Me.txtAuthor.TabIndex = 4
		'
		'Label2
		'
		Me.Label2.Location = New System.Drawing.Point(34, 167)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(100, 24)
		Me.Label2.TabIndex = 4
		Me.Label2.Text = "作成者："
		Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'txtTitle
		'
		Me.txtTitle.Location = New System.Drawing.Point(140, 137)
		Me.txtTitle.Name = "txtTitle"
		Me.txtTitle.Size = New System.Drawing.Size(472, 24)
		Me.txtTitle.TabIndex = 3
		'
		'Label1
		'
		Me.Label1.Location = New System.Drawing.Point(34, 137)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(100, 24)
		Me.Label1.TabIndex = 2
		Me.Label1.Text = "タイトル："
		Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'RadioButton2
		'
		Me.RadioButton2.AutoSize = True
		Me.RadioButton2.Location = New System.Drawing.Point(12, 305)
		Me.RadioButton2.Name = "RadioButton2"
		Me.RadioButton2.Size = New System.Drawing.Size(154, 21)
		Me.RadioButton2.TabIndex = 7
		Me.RadioButton2.TabStop = True
		Me.RadioButton2.Text = "CSVを参照して設定する"
		Me.RadioButton2.UseVisualStyleBackColor = True
		'
		'RadioButton1
		'
		Me.RadioButton1.AutoSize = True
		Me.RadioButton1.Location = New System.Drawing.Point(12, 23)
		Me.RadioButton1.Name = "RadioButton1"
		Me.RadioButton1.Size = New System.Drawing.Size(122, 21)
		Me.RadioButton1.TabIndex = 0
		Me.RadioButton1.TabStop = True
		Me.RadioButton1.Text = "固定値を設定する"
		Me.RadioButton1.UseVisualStyleBackColor = True
		'
		'StatusStrip1
		'
		Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ProgressBar1, Me.lblProgress})
		Me.StatusStrip1.Location = New System.Drawing.Point(0, 572)
		Me.StatusStrip1.Name = "StatusStrip1"
		Me.StatusStrip1.Size = New System.Drawing.Size(628, 22)
		Me.StatusStrip1.SizingGrip = False
		Me.StatusStrip1.TabIndex = 1
		Me.StatusStrip1.Text = "StatusStrip1"
		'
		'ProgressBar1
		'
		Me.ProgressBar1.Name = "ProgressBar1"
		Me.ProgressBar1.Size = New System.Drawing.Size(100, 16)
		'
		'lblProgress
		'
		Me.lblProgress.Name = "lblProgress"
		Me.lblProgress.Size = New System.Drawing.Size(78, 17)
		Me.lblProgress.Text = "99999 / 99999"
		'
		'cmbExtension
		'
		Me.cmbExtension.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cmbExtension.FormattingEnabled = True
		Me.cmbExtension.Items.AddRange(New Object() {"pdf", "tif"})
		Me.cmbExtension.Location = New System.Drawing.Point(516, 348)
		Me.cmbExtension.Name = "cmbExtension"
		Me.cmbExtension.Size = New System.Drawing.Size(96, 25)
		Me.cmbExtension.TabIndex = 31
		'
		'Form1
		'
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
		Me.ClientSize = New System.Drawing.Size(628, 594)
		Me.Controls.Add(Me.GroupBox1)
		Me.Controls.Add(Me.StatusStrip1)
		Me.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
		Me.MaximizeBox = False
		Me.Name = "Form1"
		Me.Text = "Form1"
		Me.GroupBox1.ResumeLayout(False)
		Me.GroupBox1.PerformLayout()
		Me.StatusStrip1.ResumeLayout(False)
		Me.StatusStrip1.PerformLayout()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	Friend WithEvents GroupBox1 As GroupBox
	Friend WithEvents txtTargetPath As TextBox
	Friend WithEvents Label6 As Label
	Friend WithEvents btnStop As Button
	Friend WithEvents btnStart As Button
	Friend WithEvents Label5 As Label
	Friend WithEvents txtCSVFile As TextBox
	Friend WithEvents txtKeyword As TextBox
	Friend WithEvents Label4 As Label
	Friend WithEvents txtSubTitle As TextBox
	Friend WithEvents Label3 As Label
	Friend WithEvents txtAuthor As TextBox
	Friend WithEvents Label2 As Label
	Friend WithEvents txtTitle As TextBox
	Friend WithEvents Label1 As Label
	Friend WithEvents RadioButton2 As RadioButton
	Friend WithEvents RadioButton1 As RadioButton
	Friend WithEvents StatusStrip1 As StatusStrip
	Friend WithEvents ProgressBar1 As ToolStripProgressBar
	Friend WithEvents lblProgress As ToolStripStatusLabel
	Friend WithEvents txtOutPath As TextBox
	Friend WithEvents Label7 As Label
	Friend WithEvents Label9 As Label
	Friend WithEvents Label8 As Label
	Friend WithEvents cmbTIFTitle As ComboBox
	Friend WithEvents txtTIFAuthor As TextBox
	Friend WithEvents Label12 As Label
	Friend WithEvents txtTIFSubject As TextBox
	Friend WithEvents Label10 As Label
	Friend WithEvents Label11 As Label
	Friend WithEvents RadioButton3 As RadioButton
	Friend WithEvents txtTIFTargetPath As TextBox
	Friend WithEvents Label13 As Label
	Friend WithEvents Label14 As Label
	Friend WithEvents cmbExtension As ComboBox
End Class
