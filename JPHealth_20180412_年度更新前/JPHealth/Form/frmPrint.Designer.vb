<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPrint
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPrint))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnSelectCheck = New System.Windows.Forms.Button()
        Me.btnAllUnSelect = New System.Windows.Forms.Button()
        Me.btnAllSelect = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnPDFOutput = New System.Windows.Forms.Button()
        Me.txtPDFPath = New System.Windows.Forms.TextBox()
        Me.btnPDFPathBrowse = New System.Windows.Forms.Button()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.numLabelTo = New System.Windows.Forms.NumericUpDown()
        Me.numLabelFrom = New System.Windows.Forms.NumericUpDown()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.chkSelectedPrint = New System.Windows.Forms.CheckBox()
        Me.cmbPrintClass = New System.Windows.Forms.ComboBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.cmbWeightHeader = New System.Windows.Forms.ComboBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtCountLeaflet6 = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
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
        Me.cmbPrinterSentLeaflet = New System.Windows.Forms.ComboBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.cmbSentLeafletTray = New System.Windows.Forms.ComboBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.cmbPrinterLeaflet = New System.Windows.Forms.ComboBox()
        Me.cmbPrinterResult = New System.Windows.Forms.ComboBox()
        Me.cmbPrinterSentlist = New System.Windows.Forms.ComboBox()
        Me.cmbPrinterLabel = New System.Windows.Forms.ComboBox()
        Me.cmbPrinterHeader = New System.Windows.Forms.ComboBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.cmbHeaderTray = New System.Windows.Forms.ComboBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.cmbLabelTray = New System.Windows.Forms.ComboBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.cmbLeafletTray = New System.Windows.Forms.ComboBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.cmbResultTray = New System.Windows.Forms.ComboBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.cmbSentlistTray = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbLotID = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.C1FGridResult = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.C1FlexReport1 = New C1.Win.FlexReport.C1FlexReport()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        CType(Me.numLabelTo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numLabelFrom, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.C1FGridResult, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnSelectCheck)
        Me.Panel1.Controls.Add(Me.btnAllUnSelect)
        Me.Panel1.Controls.Add(Me.btnAllSelect)
        Me.Panel1.Controls.Add(Me.btnClose)
        Me.Panel1.Controls.Add(Me.btnPDFOutput)
        Me.Panel1.Controls.Add(Me.txtPDFPath)
        Me.Panel1.Controls.Add(Me.btnPDFPathBrowse)
        Me.Panel1.Controls.Add(Me.Label15)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 828)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1184, 33)
        Me.Panel1.TabIndex = 1
        '
        'btnSelectCheck
        '
        Me.btnSelectCheck.Location = New System.Drawing.Point(165, 5)
        Me.btnSelectCheck.Name = "btnSelectCheck"
        Me.btnSelectCheck.Size = New System.Drawing.Size(80, 25)
        Me.btnSelectCheck.TabIndex = 53
        Me.btnSelectCheck.Text = "選択チェック"
        Me.btnSelectCheck.UseVisualStyleBackColor = True
        '
        'btnAllUnSelect
        '
        Me.btnAllUnSelect.Location = New System.Drawing.Point(84, 5)
        Me.btnAllUnSelect.Name = "btnAllUnSelect"
        Me.btnAllUnSelect.Size = New System.Drawing.Size(75, 25)
        Me.btnAllUnSelect.TabIndex = 52
        Me.btnAllUnSelect.Text = "全解除"
        Me.btnAllUnSelect.UseVisualStyleBackColor = True
        '
        'btnAllSelect
        '
        Me.btnAllSelect.Location = New System.Drawing.Point(3, 5)
        Me.btnAllSelect.Name = "btnAllSelect"
        Me.btnAllSelect.Size = New System.Drawing.Size(75, 25)
        Me.btnAllSelect.TabIndex = 51
        Me.btnAllSelect.Text = "全チェック"
        Me.btnAllSelect.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.Location = New System.Drawing.Point(1106, 5)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 25)
        Me.btnClose.TabIndex = 30
        Me.btnClose.Text = "閉じる"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnPDFOutput
        '
        Me.btnPDFOutput.Enabled = False
        Me.btnPDFOutput.Location = New System.Drawing.Point(819, 5)
        Me.btnPDFOutput.Name = "btnPDFOutput"
        Me.btnPDFOutput.Size = New System.Drawing.Size(75, 25)
        Me.btnPDFOutput.TabIndex = 50
        Me.btnPDFOutput.Text = "PDF出力"
        Me.btnPDFOutput.UseVisualStyleBackColor = True
        Me.btnPDFOutput.Visible = False
        '
        'txtPDFPath
        '
        Me.txtPDFPath.AllowDrop = True
        Me.txtPDFPath.Enabled = False
        Me.txtPDFPath.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtPDFPath.Location = New System.Drawing.Point(385, 6)
        Me.txtPDFPath.Name = "txtPDFPath"
        Me.txtPDFPath.Size = New System.Drawing.Size(390, 24)
        Me.txtPDFPath.TabIndex = 43
        Me.txtPDFPath.Visible = False
        '
        'btnPDFPathBrowse
        '
        Me.btnPDFPathBrowse.Enabled = False
        Me.btnPDFPathBrowse.Location = New System.Drawing.Point(781, 4)
        Me.btnPDFPathBrowse.Name = "btnPDFPathBrowse"
        Me.btnPDFPathBrowse.Size = New System.Drawing.Size(32, 26)
        Me.btnPDFPathBrowse.TabIndex = 44
        Me.btnPDFPathBrowse.Text = "..."
        Me.btnPDFPathBrowse.UseVisualStyleBackColor = True
        Me.btnPDFPathBrowse.Visible = False
        '
        'Label15
        '
        Me.Label15.Enabled = False
        Me.Label15.Location = New System.Drawing.Point(262, 7)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(117, 20)
        Me.Label15.TabIndex = 45
        Me.Label15.Text = "PDF出力フォルダ："
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label15.Visible = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.GroupBox1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1184, 245)
        Me.Panel2.TabIndex = 2
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GroupBox5)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.txtCountLeaflet6)
        Me.GroupBox1.Controls.Add(Me.Label17)
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
        Me.GroupBox1.Size = New System.Drawing.Size(1184, 245)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "ロット単位情報"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.Label31)
        Me.GroupBox5.Controls.Add(Me.numLabelTo)
        Me.GroupBox5.Controls.Add(Me.numLabelFrom)
        Me.GroupBox5.Controls.Add(Me.Label30)
        Me.GroupBox5.Controls.Add(Me.Label23)
        Me.GroupBox5.Controls.Add(Me.btnPrint)
        Me.GroupBox5.Controls.Add(Me.chkSelectedPrint)
        Me.GroupBox5.Controls.Add(Me.cmbPrintClass)
        Me.GroupBox5.Controls.Add(Me.Label21)
        Me.GroupBox5.Controls.Add(Me.cmbWeightHeader)
        Me.GroupBox5.Controls.Add(Me.Label22)
        Me.GroupBox5.Location = New System.Drawing.Point(12, 144)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(646, 95)
        Me.GroupBox5.TabIndex = 52
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "印刷設定"
        '
        'Label31
        '
        Me.Label31.Location = New System.Drawing.Point(194, 57)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(28, 20)
        Me.Label31.TabIndex = 57
        Me.Label31.Text = "～"
        Me.Label31.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'numLabelTo
        '
        Me.numLabelTo.Location = New System.Drawing.Point(228, 54)
        Me.numLabelTo.Name = "numLabelTo"
        Me.numLabelTo.Size = New System.Drawing.Size(60, 24)
        Me.numLabelTo.TabIndex = 56
        Me.numLabelTo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'numLabelFrom
        '
        Me.numLabelFrom.Location = New System.Drawing.Point(128, 54)
        Me.numLabelFrom.Name = "numLabelFrom"
        Me.numLabelFrom.Size = New System.Drawing.Size(60, 24)
        Me.numLabelFrom.TabIndex = 55
        Me.numLabelFrom.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label30
        '
        Me.Label30.Location = New System.Drawing.Point(8, 57)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(114, 20)
        Me.Label30.TabIndex = 54
        Me.Label30.Text = "ラベル印刷範囲："
        Me.Label30.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label23
        '
        Me.Label23.Location = New System.Drawing.Point(511, 24)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(99, 20)
        Me.Label23.TabIndex = 53
        Me.Label23.Text = "選択印刷："
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(562, 55)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(75, 25)
        Me.btnPrint.TabIndex = 48
        Me.btnPrint.Text = "印　刷"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'chkSelectedPrint
        '
        Me.chkSelectedPrint.AutoSize = True
        Me.chkSelectedPrint.Location = New System.Drawing.Point(616, 28)
        Me.chkSelectedPrint.Name = "chkSelectedPrint"
        Me.chkSelectedPrint.Size = New System.Drawing.Size(15, 14)
        Me.chkSelectedPrint.TabIndex = 52
        Me.chkSelectedPrint.UseVisualStyleBackColor = True
        '
        'cmbPrintClass
        '
        Me.cmbPrintClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPrintClass.FormattingEnabled = True
        Me.cmbPrintClass.Items.AddRange(New Object() {"ラベル", "就業判定票", "リーフレット"})
        Me.cmbPrintClass.Location = New System.Drawing.Point(128, 23)
        Me.cmbPrintClass.Name = "cmbPrintClass"
        Me.cmbPrintClass.Size = New System.Drawing.Size(182, 25)
        Me.cmbPrintClass.TabIndex = 47
        '
        'Label21
        '
        Me.Label21.Location = New System.Drawing.Point(23, 24)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(99, 20)
        Me.Label21.TabIndex = 33
        Me.Label21.Text = "印刷種別："
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbWeightHeader
        '
        Me.cmbWeightHeader.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbWeightHeader.FormattingEnabled = True
        Me.cmbWeightHeader.Location = New System.Drawing.Point(423, 23)
        Me.cmbWeightHeader.Name = "cmbWeightHeader"
        Me.cmbWeightHeader.Size = New System.Drawing.Size(82, 25)
        Me.cmbWeightHeader.TabIndex = 49
        '
        'Label22
        '
        Me.Label22.Location = New System.Drawing.Point(318, 24)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(99, 20)
        Me.Label22.TabIndex = 48
        Me.Label22.Text = "重量ヘッダ："
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
        Me.GroupBox2.Controls.Add(Me.cmbPrinterSentLeaflet)
        Me.GroupBox2.Controls.Add(Me.Label28)
        Me.GroupBox2.Controls.Add(Me.cmbSentLeafletTray)
        Me.GroupBox2.Controls.Add(Me.Label29)
        Me.GroupBox2.Controls.Add(Me.cmbPrinterLeaflet)
        Me.GroupBox2.Controls.Add(Me.cmbPrinterResult)
        Me.GroupBox2.Controls.Add(Me.cmbPrinterSentlist)
        Me.GroupBox2.Controls.Add(Me.cmbPrinterLabel)
        Me.GroupBox2.Controls.Add(Me.cmbPrinterHeader)
        Me.GroupBox2.Controls.Add(Me.Label26)
        Me.GroupBox2.Controls.Add(Me.cmbHeaderTray)
        Me.GroupBox2.Controls.Add(Me.Label27)
        Me.GroupBox2.Controls.Add(Me.Label24)
        Me.GroupBox2.Controls.Add(Me.cmbLabelTray)
        Me.GroupBox2.Controls.Add(Me.Label25)
        Me.GroupBox2.Controls.Add(Me.Label20)
        Me.GroupBox2.Controls.Add(Me.cmbLeafletTray)
        Me.GroupBox2.Controls.Add(Me.Label19)
        Me.GroupBox2.Controls.Add(Me.cmbResultTray)
        Me.GroupBox2.Controls.Add(Me.Label18)
        Me.GroupBox2.Controls.Add(Me.cmbSentlistTray)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Location = New System.Drawing.Point(664, 19)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(508, 220)
        Me.GroupBox2.TabIndex = 27
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "プリンタドライバ設定"
        '
        'cmbPrinterSentLeaflet
        '
        Me.cmbPrinterSentLeaflet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPrinterSentLeaflet.FormattingEnabled = True
        Me.cmbPrinterSentLeaflet.Location = New System.Drawing.Point(117, 124)
        Me.cmbPrinterSentLeaflet.Name = "cmbPrinterSentLeaflet"
        Me.cmbPrinterSentLeaflet.Size = New System.Drawing.Size(176, 25)
        Me.cmbPrinterSentLeaflet.TabIndex = 62
        '
        'Label28
        '
        Me.Label28.Location = New System.Drawing.Point(299, 126)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(59, 20)
        Me.Label28.TabIndex = 61
        Me.Label28.Text = "トレイ："
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbSentLeafletTray
        '
        Me.cmbSentLeafletTray.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSentLeafletTray.FormattingEnabled = True
        Me.cmbSentLeafletTray.Items.AddRange(New Object() {"0", "1", "2", "3", "4"})
        Me.cmbSentLeafletTray.Location = New System.Drawing.Point(364, 124)
        Me.cmbSentLeafletTray.Name = "cmbSentLeafletTray"
        Me.cmbSentLeafletTray.Size = New System.Drawing.Size(122, 25)
        Me.cmbSentLeafletTray.TabIndex = 60
        '
        'Label29
        '
        Me.Label29.Location = New System.Drawing.Point(12, 125)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(99, 20)
        Me.Label29.TabIndex = 59
        Me.Label29.Text = "保健指導名簿："
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbPrinterLeaflet
        '
        Me.cmbPrinterLeaflet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPrinterLeaflet.FormattingEnabled = True
        Me.cmbPrinterLeaflet.Location = New System.Drawing.Point(117, 186)
        Me.cmbPrinterLeaflet.Name = "cmbPrinterLeaflet"
        Me.cmbPrinterLeaflet.Size = New System.Drawing.Size(176, 25)
        Me.cmbPrinterLeaflet.TabIndex = 58
        '
        'cmbPrinterResult
        '
        Me.cmbPrinterResult.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPrinterResult.FormattingEnabled = True
        Me.cmbPrinterResult.Location = New System.Drawing.Point(117, 155)
        Me.cmbPrinterResult.Name = "cmbPrinterResult"
        Me.cmbPrinterResult.Size = New System.Drawing.Size(176, 25)
        Me.cmbPrinterResult.TabIndex = 57
        '
        'cmbPrinterSentlist
        '
        Me.cmbPrinterSentlist.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPrinterSentlist.FormattingEnabled = True
        Me.cmbPrinterSentlist.Location = New System.Drawing.Point(117, 93)
        Me.cmbPrinterSentlist.Name = "cmbPrinterSentlist"
        Me.cmbPrinterSentlist.Size = New System.Drawing.Size(176, 25)
        Me.cmbPrinterSentlist.TabIndex = 56
        '
        'cmbPrinterLabel
        '
        Me.cmbPrinterLabel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPrinterLabel.FormattingEnabled = True
        Me.cmbPrinterLabel.Location = New System.Drawing.Point(117, 62)
        Me.cmbPrinterLabel.Name = "cmbPrinterLabel"
        Me.cmbPrinterLabel.Size = New System.Drawing.Size(176, 25)
        Me.cmbPrinterLabel.TabIndex = 55
        '
        'cmbPrinterHeader
        '
        Me.cmbPrinterHeader.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPrinterHeader.FormattingEnabled = True
        Me.cmbPrinterHeader.Location = New System.Drawing.Point(117, 31)
        Me.cmbPrinterHeader.Name = "cmbPrinterHeader"
        Me.cmbPrinterHeader.Size = New System.Drawing.Size(176, 25)
        Me.cmbPrinterHeader.TabIndex = 54
        '
        'Label26
        '
        Me.Label26.Location = New System.Drawing.Point(299, 32)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(59, 20)
        Me.Label26.TabIndex = 40
        Me.Label26.Text = "トレイ："
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbHeaderTray
        '
        Me.cmbHeaderTray.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbHeaderTray.FormattingEnabled = True
        Me.cmbHeaderTray.Items.AddRange(New Object() {"0", "1", "2", "3", "4"})
        Me.cmbHeaderTray.Location = New System.Drawing.Point(364, 30)
        Me.cmbHeaderTray.Name = "cmbHeaderTray"
        Me.cmbHeaderTray.Size = New System.Drawing.Size(122, 25)
        Me.cmbHeaderTray.TabIndex = 39
        '
        'Label27
        '
        Me.Label27.Location = New System.Drawing.Point(12, 31)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(99, 20)
        Me.Label27.TabIndex = 37
        Me.Label27.Text = "重量ヘッダ："
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label24
        '
        Me.Label24.Location = New System.Drawing.Point(299, 64)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(59, 20)
        Me.Label24.TabIndex = 36
        Me.Label24.Text = "トレイ："
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbLabelTray
        '
        Me.cmbLabelTray.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbLabelTray.FormattingEnabled = True
        Me.cmbLabelTray.Items.AddRange(New Object() {"0", "1", "2", "3", "4"})
        Me.cmbLabelTray.Location = New System.Drawing.Point(364, 62)
        Me.cmbLabelTray.Name = "cmbLabelTray"
        Me.cmbLabelTray.Size = New System.Drawing.Size(122, 25)
        Me.cmbLabelTray.TabIndex = 35
        '
        'Label25
        '
        Me.Label25.Location = New System.Drawing.Point(12, 63)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(99, 20)
        Me.Label25.TabIndex = 33
        Me.Label25.Text = "宛名ラベル："
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label20
        '
        Me.Label20.Location = New System.Drawing.Point(299, 188)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(59, 20)
        Me.Label20.TabIndex = 32
        Me.Label20.Text = "トレイ："
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbLeafletTray
        '
        Me.cmbLeafletTray.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbLeafletTray.FormattingEnabled = True
        Me.cmbLeafletTray.Items.AddRange(New Object() {"0", "1", "2", "3", "4"})
        Me.cmbLeafletTray.Location = New System.Drawing.Point(364, 186)
        Me.cmbLeafletTray.Name = "cmbLeafletTray"
        Me.cmbLeafletTray.Size = New System.Drawing.Size(122, 25)
        Me.cmbLeafletTray.TabIndex = 31
        '
        'Label19
        '
        Me.Label19.Location = New System.Drawing.Point(299, 157)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(59, 20)
        Me.Label19.TabIndex = 30
        Me.Label19.Text = "トレイ："
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbResultTray
        '
        Me.cmbResultTray.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbResultTray.FormattingEnabled = True
        Me.cmbResultTray.Items.AddRange(New Object() {"0", "1", "2", "3", "4"})
        Me.cmbResultTray.Location = New System.Drawing.Point(364, 155)
        Me.cmbResultTray.Name = "cmbResultTray"
        Me.cmbResultTray.Size = New System.Drawing.Size(122, 25)
        Me.cmbResultTray.TabIndex = 29
        '
        'Label18
        '
        Me.Label18.Location = New System.Drawing.Point(299, 95)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(59, 20)
        Me.Label18.TabIndex = 28
        Me.Label18.Text = "トレイ："
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbSentlistTray
        '
        Me.cmbSentlistTray.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSentlistTray.FormattingEnabled = True
        Me.cmbSentlistTray.Items.AddRange(New Object() {"0", "1", "2", "3", "4"})
        Me.cmbSentlistTray.Location = New System.Drawing.Point(364, 93)
        Me.cmbSentlistTray.Name = "cmbSentlistTray"
        Me.cmbSentlistTray.Size = New System.Drawing.Size(122, 25)
        Me.cmbSentlistTray.TabIndex = 27
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(12, 187)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(99, 20)
        Me.Label2.TabIndex = 21
        Me.Label2.Text = "リーフレット："
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(12, 156)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(99, 20)
        Me.Label3.TabIndex = 22
        Me.Label3.Text = "就業判定票："
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(12, 94)
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
        Me.Panel3.Controls.Add(Me.GroupBox4)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 245)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1184, 583)
        Me.Panel3.TabIndex = 2
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.C1FGridResult)
        Me.GroupBox4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox4.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(1184, 583)
        Me.GroupBox4.TabIndex = 1
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "印刷内容"
        '
        'C1FGridResult
        '
        Me.C1FGridResult.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.C1FGridResult.AllowFiltering = True
        Me.C1FGridResult.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.C1FGridResult.AutoClipboard = True
        Me.C1FGridResult.ColumnInfo = resources.GetString("C1FGridResult.ColumnInfo")
        Me.C1FGridResult.Dock = System.Windows.Forms.DockStyle.Fill
        Me.C1FGridResult.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid
        Me.C1FGridResult.Font = New System.Drawing.Font("Meiryo UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.C1FGridResult.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcrossOut
        Me.C1FGridResult.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcrossOut
        Me.C1FGridResult.Location = New System.Drawing.Point(3, 20)
        Me.C1FGridResult.Name = "C1FGridResult"
        Me.C1FGridResult.Rows.Count = 1
        Me.C1FGridResult.Rows.DefaultSize = 20
        Me.C1FGridResult.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.ListBox
        Me.C1FGridResult.ShowCellLabels = True
        Me.C1FGridResult.Size = New System.Drawing.Size(1178, 560)
        Me.C1FGridResult.TabIndex = 3
        Me.C1FGridResult.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.System
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
        Me.ClientSize = New System.Drawing.Size(1184, 861)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Name = "frmPrint"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmPrint"
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.Panel2, 0)
        Me.Controls.SetChildIndex(Me.Panel3, 0)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        CType(Me.numLabelTo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numLabelFrom, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.C1FGridResult, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Panel3 As Panel
    Friend WithEvents btnClose As Button
    Friend WithEvents GroupBox2 As GroupBox
	Friend WithEvents Label2 As Label
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
	Friend WithEvents btnPrint As Button
	Friend WithEvents cmbPrintClass As ComboBox
	Friend WithEvents Label16 As Label
	Friend WithEvents txtCountLeaflet6 As TextBox
	Friend WithEvents Label17 As Label
	Friend WithEvents C1FlexReport1 As C1.Win.FlexReport.C1FlexReport
	Friend WithEvents Label20 As Label
	Friend WithEvents cmbLeafletTray As ComboBox
	Friend WithEvents Label19 As Label
	Friend WithEvents cmbResultTray As ComboBox
	Friend WithEvents Label18 As Label
	Friend WithEvents cmbSentlistTray As ComboBox
	Friend WithEvents Label21 As Label
	Friend WithEvents GroupBox4 As GroupBox
	Friend WithEvents btnPDFOutput As Button
	Friend WithEvents Label22 As Label
	Friend WithEvents cmbWeightHeader As ComboBox
	Friend WithEvents btnSelectCheck As Button
	Friend WithEvents btnAllUnSelect As Button
	Friend WithEvents btnAllSelect As Button
	Friend WithEvents GroupBox5 As GroupBox
	Friend WithEvents Label23 As Label
	Friend WithEvents chkSelectedPrint As CheckBox
	Friend WithEvents C1FGridResult As C1.Win.C1FlexGrid.C1FlexGrid
	Friend WithEvents Label24 As Label
	Friend WithEvents cmbLabelTray As ComboBox
	Friend WithEvents Label25 As Label
	Friend WithEvents cmbPrinterLeaflet As ComboBox
	Friend WithEvents cmbPrinterResult As ComboBox
	Friend WithEvents cmbPrinterSentlist As ComboBox
	Friend WithEvents cmbPrinterLabel As ComboBox
	Friend WithEvents cmbPrinterHeader As ComboBox
	Friend WithEvents Label26 As Label
	Friend WithEvents cmbHeaderTray As ComboBox
	Friend WithEvents Label27 As Label
	Friend WithEvents cmbPrinterSentLeaflet As ComboBox
	Friend WithEvents Label28 As Label
	Friend WithEvents cmbSentLeafletTray As ComboBox
	Friend WithEvents Label29 As Label
	Friend WithEvents Label31 As Label
	Friend WithEvents numLabelTo As NumericUpDown
	Friend WithEvents numLabelFrom As NumericUpDown
	Friend WithEvents Label30 As Label
End Class
