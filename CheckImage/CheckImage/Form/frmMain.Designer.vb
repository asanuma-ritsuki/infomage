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
		Me.GroupBox1 = New System.Windows.Forms.GroupBox()
		Me.Label9 = New System.Windows.Forms.Label()
		Me.numSerialFrom = New System.Windows.Forms.NumericUpDown()
		Me.Label8 = New System.Windows.Forms.Label()
		Me.numSerialDigit = New System.Windows.Forms.NumericUpDown()
		Me.GroupBox4 = New System.Windows.Forms.GroupBox()
		Me.checkedList = New System.Windows.Forms.CheckedListBox()
		Me.btnCancel = New System.Windows.Forms.Button()
		Me.btnStart = New System.Windows.Forms.Button()
		Me.Label6 = New System.Windows.Forms.Label()
		Me.numJpegSizeTo = New System.Windows.Forms.NumericUpDown()
		Me.Label5 = New System.Windows.Forms.Label()
		Me.numJpegSizeFrom = New System.Windows.Forms.NumericUpDown()
		Me.Label4 = New System.Windows.Forms.Label()
		Me.txtOutFolder = New System.Windows.Forms.TextBox()
		Me.Label3 = New System.Windows.Forms.Label()
		Me.txtOfferCSV = New System.Windows.Forms.TextBox()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.txtSrcFolder = New System.Windows.Forms.TextBox()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.GroupBox2 = New System.Windows.Forms.GroupBox()
		Me.lstResult = New System.Windows.Forms.ListBox()
		Me.GroupBox3 = New System.Windows.Forms.GroupBox()
		Me.TabControl1 = New System.Windows.Forms.TabControl()
		Me.TabPage1 = New System.Windows.Forms.TabPage()
		Me.C1FGridResult = New C1.Win.C1FlexGrid.C1FlexGrid()
		Me.TabPage2 = New System.Windows.Forms.TabPage()
		Me.C1FGridFolder = New C1.Win.C1FlexGrid.C1FlexGrid()
		Me.TabPage3 = New System.Windows.Forms.TabPage()
		Me.C1FGridOffer = New C1.Win.C1FlexGrid.C1FlexGrid()
		Me.TabPage4 = New System.Windows.Forms.TabPage()
		Me.C1FGridCamera = New C1.Win.C1FlexGrid.C1FlexGrid()
		Me.C1StatusBar1 = New C1.Win.C1Ribbon.C1StatusBar()
		Me.lblProgress = New C1.Win.C1Ribbon.RibbonLabel()
		Me.RibbonSeparator1 = New C1.Win.C1Ribbon.RibbonSeparator()
		Me.ProgressBar1 = New C1.Win.C1Ribbon.RibbonProgressBar()
		Me.chkFileSerial = New System.Windows.Forms.CheckBox()
		Me.GroupBox1.SuspendLayout()
		CType(Me.numSerialFrom, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.numSerialDigit, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.GroupBox4.SuspendLayout()
		CType(Me.numJpegSizeTo, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.numJpegSizeFrom, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.GroupBox2.SuspendLayout()
		Me.GroupBox3.SuspendLayout()
		Me.TabControl1.SuspendLayout()
		Me.TabPage1.SuspendLayout()
		CType(Me.C1FGridResult, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.TabPage2.SuspendLayout()
		CType(Me.C1FGridFolder, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.TabPage3.SuspendLayout()
		CType(Me.C1FGridOffer, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.TabPage4.SuspendLayout()
		CType(Me.C1FGridCamera, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.C1StatusBar1, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'GroupBox1
		'
		Me.GroupBox1.Controls.Add(Me.chkFileSerial)
		Me.GroupBox1.Controls.Add(Me.Label9)
		Me.GroupBox1.Controls.Add(Me.numSerialFrom)
		Me.GroupBox1.Controls.Add(Me.Label8)
		Me.GroupBox1.Controls.Add(Me.numSerialDigit)
		Me.GroupBox1.Controls.Add(Me.GroupBox4)
		Me.GroupBox1.Controls.Add(Me.btnCancel)
		Me.GroupBox1.Controls.Add(Me.btnStart)
		Me.GroupBox1.Controls.Add(Me.Label6)
		Me.GroupBox1.Controls.Add(Me.numJpegSizeTo)
		Me.GroupBox1.Controls.Add(Me.Label5)
		Me.GroupBox1.Controls.Add(Me.numJpegSizeFrom)
		Me.GroupBox1.Controls.Add(Me.Label4)
		Me.GroupBox1.Controls.Add(Me.txtOutFolder)
		Me.GroupBox1.Controls.Add(Me.Label3)
		Me.GroupBox1.Controls.Add(Me.txtOfferCSV)
		Me.GroupBox1.Controls.Add(Me.Label2)
		Me.GroupBox1.Controls.Add(Me.txtSrcFolder)
		Me.GroupBox1.Controls.Add(Me.Label1)
		Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
		Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
		Me.GroupBox1.Name = "GroupBox1"
		Me.GroupBox1.Size = New System.Drawing.Size(984, 173)
		Me.GroupBox1.TabIndex = 0
		Me.GroupBox1.TabStop = False
		Me.GroupBox1.Text = "検証条件設定"
		'
		'Label9
		'
		Me.Label9.Location = New System.Drawing.Point(320, 143)
		Me.Label9.Name = "Label9"
		Me.Label9.Size = New System.Drawing.Size(61, 24)
		Me.Label9.TabIndex = 18
		Me.Label9.Text = "から始まる"
		Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'numSerialFrom
		'
		Me.numSerialFrom.Location = New System.Drawing.Point(257, 143)
		Me.numSerialFrom.Maximum = New Decimal(New Integer() {999999999, 0, 0, 0})
		Me.numSerialFrom.Name = "numSerialFrom"
		Me.numSerialFrom.Size = New System.Drawing.Size(57, 24)
		Me.numSerialFrom.TabIndex = 17
		Me.numSerialFrom.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me.numSerialFrom.ThousandsSeparator = True
		'
		'Label8
		'
		Me.Label8.Location = New System.Drawing.Point(216, 143)
		Me.Label8.Name = "Label8"
		Me.Label8.Size = New System.Drawing.Size(35, 24)
		Me.Label8.TabIndex = 16
		Me.Label8.Text = "桁で"
		Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'numSerialDigit
		'
		Me.numSerialDigit.Location = New System.Drawing.Point(153, 143)
		Me.numSerialDigit.Maximum = New Decimal(New Integer() {999999999, 0, 0, 0})
		Me.numSerialDigit.Name = "numSerialDigit"
		Me.numSerialDigit.Size = New System.Drawing.Size(57, 24)
		Me.numSerialDigit.TabIndex = 15
		Me.numSerialDigit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me.numSerialDigit.ThousandsSeparator = True
		'
		'GroupBox4
		'
		Me.GroupBox4.Controls.Add(Me.checkedList)
		Me.GroupBox4.Location = New System.Drawing.Point(778, 12)
		Me.GroupBox4.Name = "GroupBox4"
		Me.GroupBox4.Size = New System.Drawing.Size(200, 155)
		Me.GroupBox4.TabIndex = 13
		Me.GroupBox4.TabStop = False
		Me.GroupBox4.Text = "使用カメラ"
		'
		'checkedList
		'
		Me.checkedList.Dock = System.Windows.Forms.DockStyle.Fill
		Me.checkedList.FormattingEnabled = True
		Me.checkedList.Location = New System.Drawing.Point(3, 20)
		Me.checkedList.Name = "checkedList"
		Me.checkedList.Size = New System.Drawing.Size(194, 132)
		Me.checkedList.TabIndex = 0
		'
		'btnCancel
		'
		Me.btnCancel.Location = New System.Drawing.Point(619, 143)
		Me.btnCancel.Name = "btnCancel"
		Me.btnCancel.Size = New System.Drawing.Size(75, 25)
		Me.btnCancel.TabIndex = 12
		Me.btnCancel.Text = "キャンセル"
		Me.btnCancel.UseVisualStyleBackColor = True
		'
		'btnStart
		'
		Me.btnStart.Location = New System.Drawing.Point(700, 143)
		Me.btnStart.Name = "btnStart"
		Me.btnStart.Size = New System.Drawing.Size(75, 25)
		Me.btnStart.TabIndex = 11
		Me.btnStart.Text = "開　始"
		Me.btnStart.UseVisualStyleBackColor = True
		'
		'Label6
		'
		Me.Label6.Location = New System.Drawing.Point(434, 113)
		Me.Label6.Name = "Label6"
		Me.Label6.Size = New System.Drawing.Size(38, 24)
		Me.Label6.TabIndex = 10
		Me.Label6.Text = "Byte"
		Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'numJpegSizeTo
		'
		Me.numJpegSizeTo.Location = New System.Drawing.Point(308, 113)
		Me.numJpegSizeTo.Maximum = New Decimal(New Integer() {999999999, 0, 0, 0})
		Me.numJpegSizeTo.Name = "numJpegSizeTo"
		Me.numJpegSizeTo.Size = New System.Drawing.Size(120, 24)
		Me.numJpegSizeTo.TabIndex = 9
		Me.numJpegSizeTo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me.numJpegSizeTo.ThousandsSeparator = True
		Me.numJpegSizeTo.Value = New Decimal(New Integer() {999999999, 0, 0, 0})
		'
		'Label5
		'
		Me.Label5.Location = New System.Drawing.Point(279, 113)
		Me.Label5.Name = "Label5"
		Me.Label5.Size = New System.Drawing.Size(23, 24)
		Me.Label5.TabIndex = 8
		Me.Label5.Text = "～"
		Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'numJpegSizeFrom
		'
		Me.numJpegSizeFrom.Location = New System.Drawing.Point(153, 113)
		Me.numJpegSizeFrom.Maximum = New Decimal(New Integer() {999999999, 0, 0, 0})
		Me.numJpegSizeFrom.Name = "numJpegSizeFrom"
		Me.numJpegSizeFrom.Size = New System.Drawing.Size(120, 24)
		Me.numJpegSizeFrom.TabIndex = 7
		Me.numJpegSizeFrom.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me.numJpegSizeFrom.ThousandsSeparator = True
		'
		'Label4
		'
		Me.Label4.Location = New System.Drawing.Point(24, 113)
		Me.Label4.Name = "Label4"
		Me.Label4.Size = New System.Drawing.Size(123, 24)
		Me.Label4.TabIndex = 6
		Me.Label4.Text = "JPEGサイズ："
		Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'txtOutFolder
		'
		Me.txtOutFolder.AllowDrop = True
		Me.txtOutFolder.Location = New System.Drawing.Point(153, 83)
		Me.txtOutFolder.Name = "txtOutFolder"
		Me.txtOutFolder.Size = New System.Drawing.Size(619, 24)
		Me.txtOutFolder.TabIndex = 5
		'
		'Label3
		'
		Me.Label3.Location = New System.Drawing.Point(24, 83)
		Me.Label3.Name = "Label3"
		Me.Label3.Size = New System.Drawing.Size(123, 24)
		Me.Label3.TabIndex = 4
		Me.Label3.Text = "出力フォルダ："
		Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'txtOfferCSV
		'
		Me.txtOfferCSV.AllowDrop = True
		Me.txtOfferCSV.Location = New System.Drawing.Point(153, 53)
		Me.txtOfferCSV.Name = "txtOfferCSV"
		Me.txtOfferCSV.Size = New System.Drawing.Size(619, 24)
		Me.txtOfferCSV.TabIndex = 3
		'
		'Label2
		'
		Me.Label2.Location = New System.Drawing.Point(24, 53)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(123, 24)
		Me.Label2.TabIndex = 2
		Me.Label2.Text = "提供データCSV："
		Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'txtSrcFolder
		'
		Me.txtSrcFolder.AllowDrop = True
		Me.txtSrcFolder.Location = New System.Drawing.Point(153, 23)
		Me.txtSrcFolder.Name = "txtSrcFolder"
		Me.txtSrcFolder.Size = New System.Drawing.Size(619, 24)
		Me.txtSrcFolder.TabIndex = 1
		'
		'Label1
		'
		Me.Label1.Location = New System.Drawing.Point(24, 23)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(123, 24)
		Me.Label1.TabIndex = 0
		Me.Label1.Text = "対象フォルダ："
		Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'GroupBox2
		'
		Me.GroupBox2.Controls.Add(Me.lstResult)
		Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Bottom
		Me.GroupBox2.Location = New System.Drawing.Point(0, 583)
		Me.GroupBox2.Name = "GroupBox2"
		Me.GroupBox2.Size = New System.Drawing.Size(984, 156)
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
		Me.lstResult.Size = New System.Drawing.Size(978, 133)
		Me.lstResult.TabIndex = 0
		'
		'GroupBox3
		'
		Me.GroupBox3.Controls.Add(Me.TabControl1)
		Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Fill
		Me.GroupBox3.Location = New System.Drawing.Point(0, 173)
		Me.GroupBox3.Name = "GroupBox3"
		Me.GroupBox3.Size = New System.Drawing.Size(984, 410)
		Me.GroupBox3.TabIndex = 2
		Me.GroupBox3.TabStop = False
		Me.GroupBox3.Text = "イメージ情報"
		'
		'TabControl1
		'
		Me.TabControl1.Controls.Add(Me.TabPage1)
		Me.TabControl1.Controls.Add(Me.TabPage2)
		Me.TabControl1.Controls.Add(Me.TabPage3)
		Me.TabControl1.Controls.Add(Me.TabPage4)
		Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
		Me.TabControl1.Location = New System.Drawing.Point(3, 20)
		Me.TabControl1.Name = "TabControl1"
		Me.TabControl1.SelectedIndex = 0
		Me.TabControl1.Size = New System.Drawing.Size(978, 387)
		Me.TabControl1.TabIndex = 1
		'
		'TabPage1
		'
		Me.TabPage1.Controls.Add(Me.C1FGridResult)
		Me.TabPage1.Location = New System.Drawing.Point(4, 26)
		Me.TabPage1.Name = "TabPage1"
		Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
		Me.TabPage1.Size = New System.Drawing.Size(970, 357)
		Me.TabPage1.TabIndex = 0
		Me.TabPage1.Text = "ファイル情報"
		Me.TabPage1.UseVisualStyleBackColor = True
		'
		'C1FGridResult
		'
		Me.C1FGridResult.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
		Me.C1FGridResult.AllowEditing = False
		Me.C1FGridResult.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
		Me.C1FGridResult.AutoClipboard = True
		Me.C1FGridResult.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
		Me.C1FGridResult.ColumnInfo = resources.GetString("C1FGridResult.ColumnInfo")
		Me.C1FGridResult.Dock = System.Windows.Forms.DockStyle.Fill
		Me.C1FGridResult.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid
		Me.C1FGridResult.Font = New System.Drawing.Font("Meiryo UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.C1FGridResult.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcrossOut
		Me.C1FGridResult.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcrossOut
		Me.C1FGridResult.Location = New System.Drawing.Point(3, 3)
		Me.C1FGridResult.Name = "C1FGridResult"
		Me.C1FGridResult.Rows.Count = 1
		Me.C1FGridResult.Rows.DefaultSize = 20
		Me.C1FGridResult.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
		Me.C1FGridResult.ShowCellLabels = True
		Me.C1FGridResult.Size = New System.Drawing.Size(964, 351)
		Me.C1FGridResult.TabIndex = 0
		Me.C1FGridResult.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.System
		'
		'TabPage2
		'
		Me.TabPage2.Controls.Add(Me.C1FGridFolder)
		Me.TabPage2.Location = New System.Drawing.Point(4, 22)
		Me.TabPage2.Name = "TabPage2"
		Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
		Me.TabPage2.Size = New System.Drawing.Size(970, 366)
		Me.TabPage2.TabIndex = 1
		Me.TabPage2.Text = "フォルダ情報"
		Me.TabPage2.UseVisualStyleBackColor = True
		'
		'C1FGridFolder
		'
		Me.C1FGridFolder.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
		Me.C1FGridFolder.AllowEditing = False
		Me.C1FGridFolder.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
		Me.C1FGridFolder.AutoClipboard = True
		Me.C1FGridFolder.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
		Me.C1FGridFolder.ColumnInfo = resources.GetString("C1FGridFolder.ColumnInfo")
		Me.C1FGridFolder.Dock = System.Windows.Forms.DockStyle.Fill
		Me.C1FGridFolder.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid
		Me.C1FGridFolder.Font = New System.Drawing.Font("Meiryo UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.C1FGridFolder.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcrossOut
		Me.C1FGridFolder.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcrossOut
		Me.C1FGridFolder.Location = New System.Drawing.Point(3, 3)
		Me.C1FGridFolder.Name = "C1FGridFolder"
		Me.C1FGridFolder.Rows.Count = 1
		Me.C1FGridFolder.Rows.DefaultSize = 20
		Me.C1FGridFolder.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
		Me.C1FGridFolder.ShowCellLabels = True
		Me.C1FGridFolder.Size = New System.Drawing.Size(964, 360)
		Me.C1FGridFolder.TabIndex = 1
		Me.C1FGridFolder.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.System
		'
		'TabPage3
		'
		Me.TabPage3.Controls.Add(Me.C1FGridOffer)
		Me.TabPage3.Location = New System.Drawing.Point(4, 26)
		Me.TabPage3.Name = "TabPage3"
		Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
		Me.TabPage3.Size = New System.Drawing.Size(970, 357)
		Me.TabPage3.TabIndex = 2
		Me.TabPage3.Text = "提供データ"
		Me.TabPage3.UseVisualStyleBackColor = True
		'
		'C1FGridOffer
		'
		Me.C1FGridOffer.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
		Me.C1FGridOffer.AllowEditing = False
		Me.C1FGridOffer.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
		Me.C1FGridOffer.AutoClipboard = True
		Me.C1FGridOffer.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
		Me.C1FGridOffer.ColumnInfo = resources.GetString("C1FGridOffer.ColumnInfo")
		Me.C1FGridOffer.Dock = System.Windows.Forms.DockStyle.Fill
		Me.C1FGridOffer.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid
		Me.C1FGridOffer.Font = New System.Drawing.Font("Meiryo UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.C1FGridOffer.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcrossOut
		Me.C1FGridOffer.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcrossOut
		Me.C1FGridOffer.Location = New System.Drawing.Point(3, 3)
		Me.C1FGridOffer.Name = "C1FGridOffer"
		Me.C1FGridOffer.Rows.Count = 1
		Me.C1FGridOffer.Rows.DefaultSize = 20
		Me.C1FGridOffer.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
		Me.C1FGridOffer.ShowCellLabels = True
		Me.C1FGridOffer.Size = New System.Drawing.Size(964, 351)
		Me.C1FGridOffer.TabIndex = 1
		Me.C1FGridOffer.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.System
		'
		'TabPage4
		'
		Me.TabPage4.Controls.Add(Me.C1FGridCamera)
		Me.TabPage4.Location = New System.Drawing.Point(4, 22)
		Me.TabPage4.Name = "TabPage4"
		Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
		Me.TabPage4.Size = New System.Drawing.Size(970, 366)
		Me.TabPage4.TabIndex = 3
		Me.TabPage4.Text = "カメラ情報"
		Me.TabPage4.UseVisualStyleBackColor = True
		'
		'C1FGridCamera
		'
		Me.C1FGridCamera.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
		Me.C1FGridCamera.AllowEditing = False
		Me.C1FGridCamera.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
		Me.C1FGridCamera.AutoClipboard = True
		Me.C1FGridCamera.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
		Me.C1FGridCamera.ColumnInfo = resources.GetString("C1FGridCamera.ColumnInfo")
		Me.C1FGridCamera.Dock = System.Windows.Forms.DockStyle.Fill
		Me.C1FGridCamera.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid
		Me.C1FGridCamera.Font = New System.Drawing.Font("Meiryo UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.C1FGridCamera.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcrossOut
		Me.C1FGridCamera.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcrossOut
		Me.C1FGridCamera.Location = New System.Drawing.Point(3, 3)
		Me.C1FGridCamera.Name = "C1FGridCamera"
		Me.C1FGridCamera.Rows.Count = 1
		Me.C1FGridCamera.Rows.DefaultSize = 20
		Me.C1FGridCamera.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
		Me.C1FGridCamera.ShowCellLabels = True
		Me.C1FGridCamera.Size = New System.Drawing.Size(964, 360)
		Me.C1FGridCamera.TabIndex = 2
		Me.C1FGridCamera.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.System
		'
		'C1StatusBar1
		'
		Me.C1StatusBar1.AutoSizeElement = C1.Framework.AutoSizeElement.Width
		Me.C1StatusBar1.LeftPaneItems.Add(Me.lblProgress)
		Me.C1StatusBar1.LeftPaneItems.Add(Me.RibbonSeparator1)
		Me.C1StatusBar1.LeftPaneItems.Add(Me.ProgressBar1)
		Me.C1StatusBar1.Location = New System.Drawing.Point(0, 739)
		Me.C1StatusBar1.Name = "C1StatusBar1"
		Me.C1StatusBar1.Size = New System.Drawing.Size(984, 22)
		Me.C1StatusBar1.VisualStyle = C1.Win.C1Ribbon.VisualStyle.Windows7
		'
		'lblProgress
		'
		Me.lblProgress.Name = "lblProgress"
		Me.lblProgress.Text = "99999 / 99999"
		'
		'RibbonSeparator1
		'
		Me.RibbonSeparator1.Name = "RibbonSeparator1"
		'
		'ProgressBar1
		'
		Me.ProgressBar1.Name = "ProgressBar1"
		'
		'chkFileSerial
		'
		Me.chkFileSerial.AutoSize = True
		Me.chkFileSerial.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.chkFileSerial.Location = New System.Drawing.Point(57, 143)
		Me.chkFileSerial.Name = "chkFileSerial"
		Me.chkFileSerial.Size = New System.Drawing.Size(90, 21)
		Me.chkFileSerial.TabIndex = 19
		Me.chkFileSerial.Text = "ファイル連番"
		Me.chkFileSerial.UseVisualStyleBackColor = True
		'
		'frmMain
		'
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
		Me.ClientSize = New System.Drawing.Size(984, 761)
		Me.Controls.Add(Me.GroupBox3)
		Me.Controls.Add(Me.GroupBox2)
		Me.Controls.Add(Me.GroupBox1)
		Me.Controls.Add(Me.C1StatusBar1)
		Me.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
		Me.MinimumSize = New System.Drawing.Size(1000, 800)
		Me.Name = "frmMain"
		Me.Text = "frmMain"
		Me.GroupBox1.ResumeLayout(False)
		Me.GroupBox1.PerformLayout()
		CType(Me.numSerialFrom, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.numSerialDigit, System.ComponentModel.ISupportInitialize).EndInit()
		Me.GroupBox4.ResumeLayout(False)
		CType(Me.numJpegSizeTo, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.numJpegSizeFrom, System.ComponentModel.ISupportInitialize).EndInit()
		Me.GroupBox2.ResumeLayout(False)
		Me.GroupBox3.ResumeLayout(False)
		Me.TabControl1.ResumeLayout(False)
		Me.TabPage1.ResumeLayout(False)
		CType(Me.C1FGridResult, System.ComponentModel.ISupportInitialize).EndInit()
		Me.TabPage2.ResumeLayout(False)
		CType(Me.C1FGridFolder, System.ComponentModel.ISupportInitialize).EndInit()
		Me.TabPage3.ResumeLayout(False)
		CType(Me.C1FGridOffer, System.ComponentModel.ISupportInitialize).EndInit()
		Me.TabPage4.ResumeLayout(False)
		CType(Me.C1FGridCamera, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.C1StatusBar1, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	Friend WithEvents GroupBox1 As GroupBox
	Friend WithEvents btnCancel As Button
	Friend WithEvents btnStart As Button
	Friend WithEvents Label6 As Label
	Friend WithEvents numJpegSizeTo As NumericUpDown
	Friend WithEvents Label5 As Label
	Friend WithEvents numJpegSizeFrom As NumericUpDown
	Friend WithEvents Label4 As Label
	Friend WithEvents txtOutFolder As TextBox
	Friend WithEvents Label3 As Label
	Friend WithEvents txtOfferCSV As TextBox
	Friend WithEvents Label2 As Label
	Friend WithEvents txtSrcFolder As TextBox
	Friend WithEvents Label1 As Label
	Friend WithEvents GroupBox2 As GroupBox
	Friend WithEvents lstResult As ListBox
	Friend WithEvents GroupBox3 As GroupBox
	Friend WithEvents C1FGridResult As C1.Win.C1FlexGrid.C1FlexGrid
	Friend WithEvents C1StatusBar1 As C1.Win.C1Ribbon.C1StatusBar
	Friend WithEvents lblProgress As C1.Win.C1Ribbon.RibbonLabel
	Friend WithEvents RibbonSeparator1 As C1.Win.C1Ribbon.RibbonSeparator
	Friend WithEvents ProgressBar1 As C1.Win.C1Ribbon.RibbonProgressBar
	Friend WithEvents GroupBox4 As GroupBox
	Friend WithEvents TabControl1 As TabControl
	Friend WithEvents TabPage1 As TabPage
	Friend WithEvents TabPage2 As TabPage
	Friend WithEvents C1FGridFolder As C1.Win.C1FlexGrid.C1FlexGrid
	Friend WithEvents TabPage3 As TabPage
	Friend WithEvents C1FGridOffer As C1.Win.C1FlexGrid.C1FlexGrid
	Friend WithEvents checkedList As CheckedListBox
	Friend WithEvents TabPage4 As TabPage
	Friend WithEvents C1FGridCamera As C1.Win.C1FlexGrid.C1FlexGrid
	Friend WithEvents Label9 As Label
	Friend WithEvents numSerialFrom As NumericUpDown
	Friend WithEvents Label8 As Label
	Friend WithEvents numSerialDigit As NumericUpDown
	Friend WithEvents chkFileSerial As CheckBox
End Class
