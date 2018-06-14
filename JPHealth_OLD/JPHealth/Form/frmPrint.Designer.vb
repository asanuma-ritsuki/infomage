<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPrint
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPrint))
		Me.Panel1 = New System.Windows.Forms.Panel()
		Me.btnClose = New System.Windows.Forms.Button()
		Me.Panel2 = New System.Windows.Forms.Panel()
		Me.GroupBox1 = New System.Windows.Forms.GroupBox()
		Me.Label16 = New System.Windows.Forms.Label()
		Me.txtCountLeaflet6 = New System.Windows.Forms.TextBox()
		Me.Label17 = New System.Windows.Forms.Label()
		Me.GroupBox3 = New System.Windows.Forms.GroupBox()
		Me.btnPrint = New System.Windows.Forms.Button()
		Me.cmbPrintClass = New System.Windows.Forms.ComboBox()
		Me.btnPDFPathBrowse = New System.Windows.Forms.Button()
		Me.txtPDFPath = New System.Windows.Forms.TextBox()
		Me.Label15 = New System.Windows.Forms.Label()
		Me.Label14 = New System.Windows.Forms.Label()
		Me.Label13 = New System.Windows.Forms.Label()
		Me.Label12 = New System.Windows.Forms.Label()
		Me.Label11 = New System.Windows.Forms.Label()
		Me.Label10 = New System.Windows.Forms.Label()
		Me.txtCountLeaflet = New System.Windows.Forms.TextBox()
		Me.Label9 = New System.Windows.Forms.Label()
		Me.txtCountCheckup = New System.Windows.Forms.TextBox()
		Me.Label8 = New System.Windows.Forms.Label()
		Me.txtCountLeafletList = New System.Windows.Forms.TextBox()
		Me.Label7 = New System.Windows.Forms.Label()
		Me.txtCountCheckupList = New System.Windows.Forms.TextBox()
		Me.Label6 = New System.Windows.Forms.Label()
		Me.txtCountLabel = New System.Windows.Forms.TextBox()
		Me.Label5 = New System.Windows.Forms.Label()
		Me.GroupBox2 = New System.Windows.Forms.GroupBox()
		Me.txtSentlist = New System.Windows.Forms.TextBox()
		Me.txtLeaflet = New System.Windows.Forms.TextBox()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.txtResult = New System.Windows.Forms.TextBox()
		Me.Label3 = New System.Windows.Forms.Label()
		Me.Label4 = New System.Windows.Forms.Label()
		Me.cmbLotID = New System.Windows.Forms.ComboBox()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.Panel3 = New System.Windows.Forms.Panel()
		Me.lstResult = New System.Windows.Forms.ListBox()
		Me.C1FlexReport1 = New C1.Win.FlexReport.C1FlexReport()
		Me.Panel1.SuspendLayout()
		Me.Panel2.SuspendLayout()
		Me.GroupBox1.SuspendLayout()
		Me.GroupBox3.SuspendLayout()
		Me.GroupBox2.SuspendLayout()
		Me.Panel3.SuspendLayout()
		Me.SuspendLayout()
		'
		'Panel1
		'
		Me.Panel1.Controls.Add(Me.btnClose)
		Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
		Me.Panel1.Location = New System.Drawing.Point(0, 656)
		Me.Panel1.Name = "Panel1"
		Me.Panel1.Size = New System.Drawing.Size(984, 33)
		Me.Panel1.TabIndex = 1
		'
		'btnClose
		'
		Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.btnClose.Location = New System.Drawing.Point(906, 5)
		Me.btnClose.Name = "btnClose"
		Me.btnClose.Size = New System.Drawing.Size(75, 25)
		Me.btnClose.TabIndex = 30
		Me.btnClose.Text = "閉じる"
		Me.btnClose.UseVisualStyleBackColor = True
		'
		'Panel2
		'
		Me.Panel2.Controls.Add(Me.GroupBox1)
		Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
		Me.Panel2.Location = New System.Drawing.Point(0, 0)
		Me.Panel2.Name = "Panel2"
		Me.Panel2.Size = New System.Drawing.Size(984, 182)
		Me.Panel2.TabIndex = 2
		'
		'GroupBox1
		'
		Me.GroupBox1.Controls.Add(Me.Label16)
		Me.GroupBox1.Controls.Add(Me.txtCountLeaflet6)
		Me.GroupBox1.Controls.Add(Me.Label17)
		Me.GroupBox1.Controls.Add(Me.GroupBox3)
		Me.GroupBox1.Controls.Add(Me.btnPDFPathBrowse)
		Me.GroupBox1.Controls.Add(Me.txtPDFPath)
		Me.GroupBox1.Controls.Add(Me.Label15)
		Me.GroupBox1.Controls.Add(Me.Label14)
		Me.GroupBox1.Controls.Add(Me.Label13)
		Me.GroupBox1.Controls.Add(Me.Label12)
		Me.GroupBox1.Controls.Add(Me.Label11)
		Me.GroupBox1.Controls.Add(Me.Label10)
		Me.GroupBox1.Controls.Add(Me.txtCountLeaflet)
		Me.GroupBox1.Controls.Add(Me.Label9)
		Me.GroupBox1.Controls.Add(Me.txtCountCheckup)
		Me.GroupBox1.Controls.Add(Me.Label8)
		Me.GroupBox1.Controls.Add(Me.txtCountLeafletList)
		Me.GroupBox1.Controls.Add(Me.Label7)
		Me.GroupBox1.Controls.Add(Me.txtCountCheckupList)
		Me.GroupBox1.Controls.Add(Me.Label6)
		Me.GroupBox1.Controls.Add(Me.txtCountLabel)
		Me.GroupBox1.Controls.Add(Me.Label5)
		Me.GroupBox1.Controls.Add(Me.GroupBox2)
		Me.GroupBox1.Controls.Add(Me.cmbLotID)
		Me.GroupBox1.Controls.Add(Me.Label1)
		Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
		Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
		Me.GroupBox1.Name = "GroupBox1"
		Me.GroupBox1.Size = New System.Drawing.Size(984, 182)
		Me.GroupBox1.TabIndex = 0
		Me.GroupBox1.TabStop = False
		Me.GroupBox1.Text = "印刷設定"
		'
		'Label16
		'
		Me.Label16.Location = New System.Drawing.Point(471, 115)
		Me.Label16.Name = "Label16"
		Me.Label16.Size = New System.Drawing.Size(23, 20)
		Me.Label16.TabIndex = 51
		Me.Label16.Text = "件"
		Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'txtCountLeaflet6
		'
		Me.txtCountLeaflet6.Location = New System.Drawing.Point(368, 114)
		Me.txtCountLeaflet6.Name = "txtCountLeaflet6"
		Me.txtCountLeaflet6.ReadOnly = True
		Me.txtCountLeaflet6.Size = New System.Drawing.Size(97, 24)
		Me.txtCountLeaflet6.TabIndex = 50
		Me.txtCountLeaflet6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		'
		'Label17
		'
		Me.Label17.Location = New System.Drawing.Point(269, 115)
		Me.Label17.Name = "Label17"
		Me.Label17.Size = New System.Drawing.Size(93, 20)
		Me.Label17.TabIndex = 49
		Me.Label17.Text = "リーフレット6："
		Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'GroupBox3
		'
		Me.GroupBox3.Controls.Add(Me.btnPrint)
		Me.GroupBox3.Controls.Add(Me.cmbPrintClass)
		Me.GroupBox3.Location = New System.Drawing.Point(778, 23)
		Me.GroupBox3.Name = "GroupBox3"
		Me.GroupBox3.Size = New System.Drawing.Size(194, 115)
		Me.GroupBox3.TabIndex = 48
		Me.GroupBox3.TabStop = False
		Me.GroupBox3.Text = "印刷処理"
		'
		'btnPrint
		'
		Me.btnPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.btnPrint.Location = New System.Drawing.Point(113, 84)
		Me.btnPrint.Name = "btnPrint"
		Me.btnPrint.Size = New System.Drawing.Size(75, 25)
		Me.btnPrint.TabIndex = 48
		Me.btnPrint.Text = "印　刷"
		Me.btnPrint.UseVisualStyleBackColor = True
		'
		'cmbPrintClass
		'
		Me.cmbPrintClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cmbPrintClass.FormattingEnabled = True
		Me.cmbPrintClass.Items.AddRange(New Object() {"ラベル", "就業判定票", "リーフレット"})
		Me.cmbPrintClass.Location = New System.Drawing.Point(6, 23)
		Me.cmbPrintClass.Name = "cmbPrintClass"
		Me.cmbPrintClass.Size = New System.Drawing.Size(182, 25)
		Me.cmbPrintClass.TabIndex = 47
		'
		'btnPDFPathBrowse
		'
		Me.btnPDFPathBrowse.Location = New System.Drawing.Point(625, 142)
		Me.btnPDFPathBrowse.Name = "btnPDFPathBrowse"
		Me.btnPDFPathBrowse.Size = New System.Drawing.Size(32, 26)
		Me.btnPDFPathBrowse.TabIndex = 44
		Me.btnPDFPathBrowse.Text = "..."
		Me.btnPDFPathBrowse.UseVisualStyleBackColor = True
		'
		'txtPDFPath
		'
		Me.txtPDFPath.AllowDrop = True
		Me.txtPDFPath.ImeMode = System.Windows.Forms.ImeMode.Disable
		Me.txtPDFPath.Location = New System.Drawing.Point(126, 144)
		Me.txtPDFPath.Name = "txtPDFPath"
		Me.txtPDFPath.Size = New System.Drawing.Size(493, 24)
		Me.txtPDFPath.TabIndex = 43
		'
		'Label15
		'
		Me.Label15.Location = New System.Drawing.Point(3, 145)
		Me.Label15.Name = "Label15"
		Me.Label15.Size = New System.Drawing.Size(117, 20)
		Me.Label15.TabIndex = 45
		Me.Label15.Text = "PDF出力フォルダ："
		Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'Label14
		'
		Me.Label14.Location = New System.Drawing.Point(471, 85)
		Me.Label14.Name = "Label14"
		Me.Label14.Size = New System.Drawing.Size(23, 20)
		Me.Label14.TabIndex = 42
		Me.Label14.Text = "件"
		Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'Label13
		'
		Me.Label13.Location = New System.Drawing.Point(471, 55)
		Me.Label13.Name = "Label13"
		Me.Label13.Size = New System.Drawing.Size(23, 20)
		Me.Label13.TabIndex = 41
		Me.Label13.Text = "件"
		Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'Label12
		'
		Me.Label12.Location = New System.Drawing.Point(229, 115)
		Me.Label12.Name = "Label12"
		Me.Label12.Size = New System.Drawing.Size(23, 20)
		Me.Label12.TabIndex = 40
		Me.Label12.Text = "件"
		Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'Label11
		'
		Me.Label11.Location = New System.Drawing.Point(229, 85)
		Me.Label11.Name = "Label11"
		Me.Label11.Size = New System.Drawing.Size(23, 20)
		Me.Label11.TabIndex = 39
		Me.Label11.Text = "件"
		Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'Label10
		'
		Me.Label10.Location = New System.Drawing.Point(229, 55)
		Me.Label10.Name = "Label10"
		Me.Label10.Size = New System.Drawing.Size(23, 20)
		Me.Label10.TabIndex = 38
		Me.Label10.Text = "件"
		Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'txtCountLeaflet
		'
		Me.txtCountLeaflet.Location = New System.Drawing.Point(368, 84)
		Me.txtCountLeaflet.Name = "txtCountLeaflet"
		Me.txtCountLeaflet.ReadOnly = True
		Me.txtCountLeaflet.Size = New System.Drawing.Size(97, 24)
		Me.txtCountLeaflet.TabIndex = 37
		Me.txtCountLeaflet.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		'
		'Label9
		'
		Me.Label9.Location = New System.Drawing.Point(269, 85)
		Me.Label9.Name = "Label9"
		Me.Label9.Size = New System.Drawing.Size(93, 20)
		Me.Label9.TabIndex = 36
		Me.Label9.Text = "リーフレット："
		Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'txtCountCheckup
		'
		Me.txtCountCheckup.Location = New System.Drawing.Point(368, 54)
		Me.txtCountCheckup.Name = "txtCountCheckup"
		Me.txtCountCheckup.ReadOnly = True
		Me.txtCountCheckup.Size = New System.Drawing.Size(97, 24)
		Me.txtCountCheckup.TabIndex = 35
		Me.txtCountCheckup.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		'
		'Label8
		'
		Me.Label8.Location = New System.Drawing.Point(269, 55)
		Me.Label8.Name = "Label8"
		Me.Label8.Size = New System.Drawing.Size(93, 20)
		Me.Label8.TabIndex = 34
		Me.Label8.Text = "就業判定票："
		Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'txtCountLeafletList
		'
		Me.txtCountLeafletList.Location = New System.Drawing.Point(126, 114)
		Me.txtCountLeafletList.Name = "txtCountLeafletList"
		Me.txtCountLeafletList.ReadOnly = True
		Me.txtCountLeafletList.Size = New System.Drawing.Size(97, 24)
		Me.txtCountLeafletList.TabIndex = 33
		Me.txtCountLeafletList.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		'
		'Label7
		'
		Me.Label7.Location = New System.Drawing.Point(15, 115)
		Me.Label7.Name = "Label7"
		Me.Label7.Size = New System.Drawing.Size(105, 20)
		Me.Label7.TabIndex = 32
		Me.Label7.Text = "保健指導名簿："
		Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'txtCountCheckupList
		'
		Me.txtCountCheckupList.Location = New System.Drawing.Point(126, 84)
		Me.txtCountCheckupList.Name = "txtCountCheckupList"
		Me.txtCountCheckupList.ReadOnly = True
		Me.txtCountCheckupList.Size = New System.Drawing.Size(97, 24)
		Me.txtCountCheckupList.TabIndex = 31
		Me.txtCountCheckupList.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		'
		'Label6
		'
		Me.Label6.Location = New System.Drawing.Point(15, 85)
		Me.Label6.Name = "Label6"
		Me.Label6.Size = New System.Drawing.Size(105, 20)
		Me.Label6.TabIndex = 30
		Me.Label6.Text = "対象者一覧："
		Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'txtCountLabel
		'
		Me.txtCountLabel.Location = New System.Drawing.Point(126, 54)
		Me.txtCountLabel.Name = "txtCountLabel"
		Me.txtCountLabel.ReadOnly = True
		Me.txtCountLabel.Size = New System.Drawing.Size(97, 24)
		Me.txtCountLabel.TabIndex = 29
		Me.txtCountLabel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		'
		'Label5
		'
		Me.Label5.Location = New System.Drawing.Point(15, 55)
		Me.Label5.Name = "Label5"
		Me.Label5.Size = New System.Drawing.Size(105, 20)
		Me.Label5.TabIndex = 28
		Me.Label5.Text = "ラベル："
		Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'GroupBox2
		'
		Me.GroupBox2.Controls.Add(Me.txtSentlist)
		Me.GroupBox2.Controls.Add(Me.txtLeaflet)
		Me.GroupBox2.Controls.Add(Me.Label2)
		Me.GroupBox2.Controls.Add(Me.txtResult)
		Me.GroupBox2.Controls.Add(Me.Label3)
		Me.GroupBox2.Controls.Add(Me.Label4)
		Me.GroupBox2.Location = New System.Drawing.Point(507, 19)
		Me.GroupBox2.Name = "GroupBox2"
		Me.GroupBox2.Size = New System.Drawing.Size(265, 119)
		Me.GroupBox2.TabIndex = 27
		Me.GroupBox2.TabStop = False
		Me.GroupBox2.Text = "プリンタドライバ設定"
		'
		'txtSentlist
		'
		Me.txtSentlist.Location = New System.Drawing.Point(117, 23)
		Me.txtSentlist.Name = "txtSentlist"
		Me.txtSentlist.Size = New System.Drawing.Size(133, 24)
		Me.txtSentlist.TabIndex = 24
		'
		'txtLeaflet
		'
		Me.txtLeaflet.Location = New System.Drawing.Point(117, 83)
		Me.txtLeaflet.Name = "txtLeaflet"
		Me.txtLeaflet.Size = New System.Drawing.Size(133, 24)
		Me.txtLeaflet.TabIndex = 26
		'
		'Label2
		'
		Me.Label2.Location = New System.Drawing.Point(12, 84)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(99, 20)
		Me.Label2.TabIndex = 21
		Me.Label2.Text = "リーフレット："
		Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'txtResult
		'
		Me.txtResult.Location = New System.Drawing.Point(117, 53)
		Me.txtResult.Name = "txtResult"
		Me.txtResult.Size = New System.Drawing.Size(133, 24)
		Me.txtResult.TabIndex = 25
		'
		'Label3
		'
		Me.Label3.Location = New System.Drawing.Point(12, 54)
		Me.Label3.Name = "Label3"
		Me.Label3.Size = New System.Drawing.Size(99, 20)
		Me.Label3.TabIndex = 22
		Me.Label3.Text = "就業判定票："
		Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'Label4
		'
		Me.Label4.Location = New System.Drawing.Point(12, 24)
		Me.Label4.Name = "Label4"
		Me.Label4.Size = New System.Drawing.Size(99, 20)
		Me.Label4.TabIndex = 23
		Me.Label4.Text = "対象者一覧："
		Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'cmbLotID
		'
		Me.cmbLotID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cmbLotID.FormattingEnabled = True
		Me.cmbLotID.Location = New System.Drawing.Point(126, 23)
		Me.cmbLotID.Name = "cmbLotID"
		Me.cmbLotID.Size = New System.Drawing.Size(196, 25)
		Me.cmbLotID.TabIndex = 20
		'
		'Label1
		'
		Me.Label1.Location = New System.Drawing.Point(15, 24)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(105, 20)
		Me.Label1.TabIndex = 19
		Me.Label1.Text = "インポート日時："
		Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'Panel3
		'
		Me.Panel3.Controls.Add(Me.lstResult)
		Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
		Me.Panel3.Location = New System.Drawing.Point(0, 182)
		Me.Panel3.Name = "Panel3"
		Me.Panel3.Size = New System.Drawing.Size(984, 474)
		Me.Panel3.TabIndex = 2
		'
		'lstResult
		'
		Me.lstResult.Dock = System.Windows.Forms.DockStyle.Fill
		Me.lstResult.FormattingEnabled = True
		Me.lstResult.ItemHeight = 17
		Me.lstResult.Location = New System.Drawing.Point(0, 0)
		Me.lstResult.Name = "lstResult"
		Me.lstResult.Size = New System.Drawing.Size(984, 474)
		Me.lstResult.TabIndex = 1
		'
		'C1FlexReport1
		'
		Me.C1FlexReport1.ReportDefinition = resources.GetString("C1FlexReport1.ReportDefinition")
		Me.C1FlexReport1.ReportName = "C1FlexReport1"
		'
		'frmPrint
		'
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
		Me.CaptionDisplayMode = JPHealth.frmTempForm.StatusDisplayMode.ShowAll
		Me.ClientSize = New System.Drawing.Size(984, 711)
		Me.Controls.Add(Me.Panel3)
		Me.Controls.Add(Me.Panel2)
		Me.Controls.Add(Me.Panel1)
		Me.KeyPreview = True
		Me.Name = "frmPrint"
		Me.ShowInTaskbar = False
		Me.Text = "frmPrint"
		Me.Controls.SetChildIndex(Me.Panel1, 0)
		Me.Controls.SetChildIndex(Me.Panel2, 0)
		Me.Controls.SetChildIndex(Me.Panel3, 0)
		Me.Panel1.ResumeLayout(False)
		Me.Panel2.ResumeLayout(False)
		Me.GroupBox1.ResumeLayout(False)
		Me.GroupBox1.PerformLayout()
		Me.GroupBox3.ResumeLayout(False)
		Me.GroupBox2.ResumeLayout(False)
		Me.GroupBox2.PerformLayout()
		Me.Panel3.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	Friend WithEvents Panel1 As Panel
	Friend WithEvents Panel2 As Panel
	Friend WithEvents GroupBox1 As GroupBox
	Friend WithEvents Panel3 As Panel
	Friend WithEvents btnClose As Button
	Friend WithEvents lstResult As ListBox
	Friend WithEvents GroupBox2 As GroupBox
	Friend WithEvents txtSentlist As TextBox
	Friend WithEvents txtLeaflet As TextBox
	Friend WithEvents Label2 As Label
	Friend WithEvents txtResult As TextBox
	Friend WithEvents Label3 As Label
	Friend WithEvents Label4 As Label
	Friend WithEvents cmbLotID As ComboBox
	Friend WithEvents Label1 As Label
	Friend WithEvents txtCountCheckup As TextBox
	Friend WithEvents Label8 As Label
	Friend WithEvents txtCountLeafletList As TextBox
	Friend WithEvents Label7 As Label
	Friend WithEvents txtCountCheckupList As TextBox
	Friend WithEvents Label6 As Label
	Friend WithEvents txtCountLabel As TextBox
	Friend WithEvents Label5 As Label
	Friend WithEvents Label14 As Label
	Friend WithEvents Label13 As Label
	Friend WithEvents Label12 As Label
	Friend WithEvents Label11 As Label
	Friend WithEvents Label10 As Label
	Friend WithEvents txtCountLeaflet As TextBox
	Friend WithEvents Label9 As Label
	Friend WithEvents btnPDFPathBrowse As Button
	Friend WithEvents txtPDFPath As TextBox
	Friend WithEvents Label15 As Label
	Friend WithEvents GroupBox3 As GroupBox
	Friend WithEvents btnPrint As Button
	Friend WithEvents cmbPrintClass As ComboBox
	Friend WithEvents Label16 As Label
	Friend WithEvents txtCountLeaflet6 As TextBox
	Friend WithEvents Label17 As Label
	Friend WithEvents C1FlexReport1 As C1.Win.FlexReport.C1FlexReport
End Class
