<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmCheckupManage
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCheckupManage))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnOfficeOut = New System.Windows.Forms.Button()
        Me.btnWeightOut = New System.Windows.Forms.Button()
        Me.btnIncompleteOut = New System.Windows.Forms.Button()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.btnImport = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnOutputFolderBrowse = New System.Windows.Forms.Button()
        Me.txtOutputFolder = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lblCheckProgress = New System.Windows.Forms.Label()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btnListOutput = New System.Windows.Forms.Button()
        Me.chkSuccessDate = New System.Windows.Forms.CheckBox()
        Me.chkFacilityCountDate = New System.Windows.Forms.CheckBox()
        Me.chkOfficeListDate = New System.Windows.Forms.CheckBox()
        Me.chkTargetListDate = New System.Windows.Forms.CheckBox()
        Me.txtTargetListDate = New System.Windows.Forms.TextBox()
        Me.txtSuccessDate = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtFacilityCountDate = New System.Windows.Forms.TextBox()
        Me.txtOfficeListDate = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtLeafletCSV = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtCheckupCSV = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnSendDateUpdate = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dtpSendDate = New System.Windows.Forms.DateTimePicker()
        Me.cmbLotID = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.C1FGridResult = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.C1FGridHeader = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.C1FGridDefect = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnExcelFileBrowse = New System.Windows.Forms.Button()
        Me.txtExcelFile = New System.Windows.Forms.TextBox()
        Me.btnExcelImport = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.btnCopy = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.C1FGridResult, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        CType(Me.C1FGridHeader, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        CType(Me.C1FGridDefect, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnOfficeOut)
        Me.GroupBox1.Controls.Add(Me.btnWeightOut)
        Me.GroupBox1.Controls.Add(Me.btnIncompleteOut)
        Me.GroupBox1.Controls.Add(Me.btnPrint)
        Me.GroupBox1.Controls.Add(Me.btnImport)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.txtLeafletCSV)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtCheckupCSV)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.btnSendDateUpdate)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.dtpSendDate)
        Me.GroupBox1.Controls.Add(Me.cmbLotID)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(574, 245)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "インポート日時選択"
        '
        'btnOfficeOut
        '
        Me.btnOfficeOut.Location = New System.Drawing.Point(9, 216)
        Me.btnOfficeOut.Name = "btnOfficeOut"
        Me.btnOfficeOut.Size = New System.Drawing.Size(100, 25)
        Me.btnOfficeOut.TabIndex = 51
        Me.btnOfficeOut.Text = "事業所別出力"
        Me.btnOfficeOut.UseVisualStyleBackColor = True
        '
        'btnWeightOut
        '
        Me.btnWeightOut.Location = New System.Drawing.Point(115, 216)
        Me.btnWeightOut.Name = "btnWeightOut"
        Me.btnWeightOut.Size = New System.Drawing.Size(100, 25)
        Me.btnWeightOut.TabIndex = 52
        Me.btnWeightOut.Text = "重量ヘッダ出力"
        Me.btnWeightOut.UseVisualStyleBackColor = True
        '
        'btnIncompleteOut
        '
        Me.btnIncompleteOut.Location = New System.Drawing.Point(221, 216)
        Me.btnIncompleteOut.Name = "btnIncompleteOut"
        Me.btnIncompleteOut.Size = New System.Drawing.Size(100, 25)
        Me.btnIncompleteOut.TabIndex = 53
        Me.btnIncompleteOut.Text = "不備内容出力"
        Me.btnIncompleteOut.UseVisualStyleBackColor = True
        '
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(485, 216)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(75, 25)
        Me.btnPrint.TabIndex = 55
        Me.btnPrint.Text = "印　刷"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'btnImport
        '
        Me.btnImport.Location = New System.Drawing.Point(404, 216)
        Me.btnImport.Name = "btnImport"
        Me.btnImport.Size = New System.Drawing.Size(75, 25)
        Me.btnImport.TabIndex = 53
        Me.btnImport.Text = "インポート"
        Me.btnImport.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnOutputFolderBrowse)
        Me.GroupBox2.Controls.Add(Me.txtOutputFolder)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.lblCheckProgress)
        Me.GroupBox2.Controls.Add(Me.ProgressBar1)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.btnListOutput)
        Me.GroupBox2.Controls.Add(Me.chkSuccessDate)
        Me.GroupBox2.Controls.Add(Me.chkFacilityCountDate)
        Me.GroupBox2.Controls.Add(Me.chkOfficeListDate)
        Me.GroupBox2.Controls.Add(Me.chkTargetListDate)
        Me.GroupBox2.Controls.Add(Me.txtTargetListDate)
        Me.GroupBox2.Controls.Add(Me.txtSuccessDate)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.txtFacilityCountDate)
        Me.GroupBox2.Controls.Add(Me.txtOfficeListDate)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 84)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(562, 126)
        Me.GroupBox2.TabIndex = 52
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "各種帳票出力"
        '
        'btnOutputFolderBrowse
        '
        Me.btnOutputFolderBrowse.Location = New System.Drawing.Point(441, 81)
        Me.btnOutputFolderBrowse.Name = "btnOutputFolderBrowse"
        Me.btnOutputFolderBrowse.Size = New System.Drawing.Size(32, 26)
        Me.btnOutputFolderBrowse.TabIndex = 64
        Me.btnOutputFolderBrowse.Text = "..."
        Me.btnOutputFolderBrowse.UseVisualStyleBackColor = True
        '
        'txtOutputFolder
        '
        Me.txtOutputFolder.AllowDrop = True
        Me.txtOutputFolder.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtOutputFolder.Location = New System.Drawing.Point(109, 83)
        Me.txtOutputFolder.Name = "txtOutputFolder"
        Me.txtOutputFolder.Size = New System.Drawing.Size(326, 24)
        Me.txtOutputFolder.TabIndex = 63
        Me.txtOutputFolder.Text = "E:\JPTemp\02_Out"
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(13, 84)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(90, 20)
        Me.Label10.TabIndex = 65
        Me.Label10.Text = "保存フォルダ："
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCheckProgress
        '
        Me.lblCheckProgress.BackColor = System.Drawing.SystemColors.Control
        Me.lblCheckProgress.Font = New System.Drawing.Font("Meiryo UI", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblCheckProgress.Location = New System.Drawing.Point(429, 61)
        Me.lblCheckProgress.Name = "lblCheckProgress"
        Me.lblCheckProgress.Size = New System.Drawing.Size(125, 13)
        Me.lblCheckProgress.TabIndex = 62
        Me.lblCheckProgress.Text = "99999 / 99999"
        Me.lblCheckProgress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(429, 46)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(125, 15)
        Me.ProgressBar1.TabIndex = 61
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(429, 23)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(125, 20)
        Me.Label9.TabIndex = 60
        Me.Label9.Text = "QRチェック"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnListOutput
        '
        Me.btnListOutput.Location = New System.Drawing.Point(479, 82)
        Me.btnListOutput.Name = "btnListOutput"
        Me.btnListOutput.Size = New System.Drawing.Size(75, 25)
        Me.btnListOutput.TabIndex = 56
        Me.btnListOutput.Text = "帳票出力"
        Me.btnListOutput.UseVisualStyleBackColor = True
        '
        'chkSuccessDate
        '
        Me.chkSuccessDate.AutoSize = True
        Me.chkSuccessDate.Location = New System.Drawing.Point(405, 58)
        Me.chkSuccessDate.Name = "chkSuccessDate"
        Me.chkSuccessDate.Size = New System.Drawing.Size(15, 14)
        Me.chkSuccessDate.TabIndex = 59
        Me.chkSuccessDate.UseVisualStyleBackColor = True
        '
        'chkFacilityCountDate
        '
        Me.chkFacilityCountDate.AutoSize = True
        Me.chkFacilityCountDate.Location = New System.Drawing.Point(405, 28)
        Me.chkFacilityCountDate.Name = "chkFacilityCountDate"
        Me.chkFacilityCountDate.Size = New System.Drawing.Size(15, 14)
        Me.chkFacilityCountDate.TabIndex = 58
        Me.chkFacilityCountDate.UseVisualStyleBackColor = True
        '
        'chkOfficeListDate
        '
        Me.chkOfficeListDate.AutoSize = True
        Me.chkOfficeListDate.Location = New System.Drawing.Point(199, 58)
        Me.chkOfficeListDate.Name = "chkOfficeListDate"
        Me.chkOfficeListDate.Size = New System.Drawing.Size(15, 14)
        Me.chkOfficeListDate.TabIndex = 57
        Me.chkOfficeListDate.UseVisualStyleBackColor = True
        '
        'chkTargetListDate
        '
        Me.chkTargetListDate.AutoSize = True
        Me.chkTargetListDate.Location = New System.Drawing.Point(199, 28)
        Me.chkTargetListDate.Name = "chkTargetListDate"
        Me.chkTargetListDate.Size = New System.Drawing.Size(15, 14)
        Me.chkTargetListDate.TabIndex = 56
        Me.chkTargetListDate.UseVisualStyleBackColor = True
        '
        'txtTargetListDate
        '
        Me.txtTargetListDate.Location = New System.Drawing.Point(109, 23)
        Me.txtTargetListDate.Name = "txtTargetListDate"
        Me.txtTargetListDate.ReadOnly = True
        Me.txtTargetListDate.Size = New System.Drawing.Size(84, 24)
        Me.txtTargetListDate.TabIndex = 45
        Me.txtTargetListDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtSuccessDate
        '
        Me.txtSuccessDate.Location = New System.Drawing.Point(315, 53)
        Me.txtSuccessDate.Name = "txtSuccessDate"
        Me.txtSuccessDate.ReadOnly = True
        Me.txtSuccessDate.Size = New System.Drawing.Size(84, 24)
        Me.txtSuccessDate.TabIndex = 51
        Me.txtSuccessDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(13, 24)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(90, 20)
        Me.Label5.TabIndex = 44
        Me.Label5.Text = "対象者一覧："
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(219, 54)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(90, 20)
        Me.Label7.TabIndex = 50
        Me.Label7.Text = "後納票："
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(13, 54)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(90, 20)
        Me.Label4.TabIndex = 46
        Me.Label4.Text = "事業所一覧："
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtFacilityCountDate
        '
        Me.txtFacilityCountDate.Location = New System.Drawing.Point(315, 23)
        Me.txtFacilityCountDate.Name = "txtFacilityCountDate"
        Me.txtFacilityCountDate.ReadOnly = True
        Me.txtFacilityCountDate.Size = New System.Drawing.Size(84, 24)
        Me.txtFacilityCountDate.TabIndex = 49
        Me.txtFacilityCountDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtOfficeListDate
        '
        Me.txtOfficeListDate.Location = New System.Drawing.Point(109, 53)
        Me.txtOfficeListDate.Name = "txtOfficeListDate"
        Me.txtOfficeListDate.ReadOnly = True
        Me.txtOfficeListDate.Size = New System.Drawing.Size(84, 24)
        Me.txtOfficeListDate.TabIndex = 47
        Me.txtOfficeListDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(219, 24)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(90, 20)
        Me.Label8.TabIndex = 48
        Me.Label8.Text = "施設別件数："
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtLeafletCSV
        '
        Me.txtLeafletCSV.Location = New System.Drawing.Point(428, 53)
        Me.txtLeafletCSV.Name = "txtLeafletCSV"
        Me.txtLeafletCSV.ReadOnly = True
        Me.txtLeafletCSV.Size = New System.Drawing.Size(139, 24)
        Me.txtLeafletCSV.TabIndex = 43
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(317, 54)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(105, 20)
        Me.Label3.TabIndex = 42
        Me.Label3.Text = "リーフレットCSV："
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtCheckupCSV
        '
        Me.txtCheckupCSV.Location = New System.Drawing.Point(428, 23)
        Me.txtCheckupCSV.Name = "txtCheckupCSV"
        Me.txtCheckupCSV.ReadOnly = True
        Me.txtCheckupCSV.Size = New System.Drawing.Size(139, 24)
        Me.txtCheckupCSV.TabIndex = 41
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(317, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(105, 20)
        Me.Label2.TabIndex = 40
        Me.Label2.Text = "判定票CSV："
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnSendDateUpdate
        '
        Me.btnSendDateUpdate.Location = New System.Drawing.Point(263, 53)
        Me.btnSendDateUpdate.Name = "btnSendDateUpdate"
        Me.btnSendDateUpdate.Size = New System.Drawing.Size(50, 25)
        Me.btnSendDateUpdate.TabIndex = 39
        Me.btnSendDateUpdate.Text = "更新"
        Me.btnSendDateUpdate.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(12, 55)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(97, 20)
        Me.Label6.TabIndex = 38
        Me.Label6.Text = "発送日："
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dtpSendDate
        '
        Me.dtpSendDate.Location = New System.Drawing.Point(115, 54)
        Me.dtpSendDate.Name = "dtpSendDate"
        Me.dtpSendDate.Size = New System.Drawing.Size(142, 24)
        Me.dtpSendDate.TabIndex = 37
        '
        'cmbLotID
        '
        Me.cmbLotID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbLotID.FormattingEnabled = True
        Me.cmbLotID.Location = New System.Drawing.Point(115, 23)
        Me.cmbLotID.Name = "cmbLotID"
        Me.cmbLotID.Size = New System.Drawing.Size(198, 25)
        Me.cmbLotID.TabIndex = 22
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(12, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(97, 20)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "インポート日時："
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.C1FGridResult)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 263)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(633, 458)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "事業所別インポート内容"
        '
        'C1FGridResult
        '
        Me.C1FGridResult.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.C1FGridResult.AllowEditing = False
        Me.C1FGridResult.AllowFiltering = True
        Me.C1FGridResult.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.C1FGridResult.AutoClipboard = True
        Me.C1FGridResult.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
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
        Me.C1FGridResult.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.C1FGridResult.ShowCellLabels = True
        Me.C1FGridResult.Size = New System.Drawing.Size(627, 435)
        Me.C1FGridResult.TabIndex = 3
        Me.C1FGridResult.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.System
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.C1FGridHeader)
        Me.GroupBox4.Location = New System.Drawing.Point(592, 12)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(730, 245)
        Me.GroupBox4.TabIndex = 3
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "重量ヘッダ単位件数"
        '
        'C1FGridHeader
        '
        Me.C1FGridHeader.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.C1FGridHeader.AllowEditing = False
        Me.C1FGridHeader.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.C1FGridHeader.AutoClipboard = True
        Me.C1FGridHeader.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.C1FGridHeader.ColumnInfo = resources.GetString("C1FGridHeader.ColumnInfo")
        Me.C1FGridHeader.Dock = System.Windows.Forms.DockStyle.Fill
        Me.C1FGridHeader.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid
        Me.C1FGridHeader.Font = New System.Drawing.Font("Meiryo UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.C1FGridHeader.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcrossOut
        Me.C1FGridHeader.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcrossOut
        Me.C1FGridHeader.Location = New System.Drawing.Point(3, 20)
        Me.C1FGridHeader.Name = "C1FGridHeader"
        Me.C1FGridHeader.Rows.Count = 10
        Me.C1FGridHeader.Rows.DefaultSize = 20
        Me.C1FGridHeader.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.C1FGridHeader.ShowCellLabels = True
        Me.C1FGridHeader.Size = New System.Drawing.Size(724, 222)
        Me.C1FGridHeader.SubtotalPosition = C1.Win.C1FlexGrid.SubtotalPositionEnum.BelowData
        Me.C1FGridHeader.TabIndex = 4
        Me.C1FGridHeader.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.System
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.C1FGridDefect)
        Me.GroupBox5.Controls.Add(Me.Panel2)
        Me.GroupBox5.Location = New System.Drawing.Point(654, 263)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(668, 458)
        Me.GroupBox5.TabIndex = 5
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "データ不備内容"
        '
        'C1FGridDefect
        '
        Me.C1FGridDefect.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.C1FGridDefect.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.C1FGridDefect.AutoClipboard = True
        Me.C1FGridDefect.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.C1FGridDefect.ColumnInfo = resources.GetString("C1FGridDefect.ColumnInfo")
        Me.C1FGridDefect.Dock = System.Windows.Forms.DockStyle.Fill
        Me.C1FGridDefect.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid
        Me.C1FGridDefect.Font = New System.Drawing.Font("Meiryo UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.C1FGridDefect.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcrossOut
        Me.C1FGridDefect.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcrossOut
        Me.C1FGridDefect.Location = New System.Drawing.Point(3, 20)
        Me.C1FGridDefect.Name = "C1FGridDefect"
        Me.C1FGridDefect.Rows.Count = 1
        Me.C1FGridDefect.Rows.DefaultSize = 20
        Me.C1FGridDefect.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.C1FGridDefect.ShowCellLabels = True
        Me.C1FGridDefect.Size = New System.Drawing.Size(662, 402)
        Me.C1FGridDefect.TabIndex = 4
        Me.C1FGridDefect.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.System
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.btnExcelFileBrowse)
        Me.Panel2.Controls.Add(Me.txtExcelFile)
        Me.Panel2.Controls.Add(Me.btnExcelImport)
        Me.Panel2.Controls.Add(Me.btnUpdate)
        Me.Panel2.Controls.Add(Me.btnCopy)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(3, 422)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(662, 33)
        Me.Panel2.TabIndex = 0
        '
        'btnExcelFileBrowse
        '
        Me.btnExcelFileBrowse.Location = New System.Drawing.Point(416, 4)
        Me.btnExcelFileBrowse.Name = "btnExcelFileBrowse"
        Me.btnExcelFileBrowse.Size = New System.Drawing.Size(32, 26)
        Me.btnExcelFileBrowse.TabIndex = 66
        Me.btnExcelFileBrowse.Text = "..."
        Me.btnExcelFileBrowse.UseVisualStyleBackColor = True
        '
        'txtExcelFile
        '
        Me.txtExcelFile.AllowDrop = True
        Me.txtExcelFile.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtExcelFile.Location = New System.Drawing.Point(84, 6)
        Me.txtExcelFile.Name = "txtExcelFile"
        Me.txtExcelFile.Size = New System.Drawing.Size(326, 24)
        Me.txtExcelFile.TabIndex = 65
        '
        'btnExcelImport
        '
        Me.btnExcelImport.Location = New System.Drawing.Point(454, 5)
        Me.btnExcelImport.Name = "btnExcelImport"
        Me.btnExcelImport.Size = New System.Drawing.Size(75, 25)
        Me.btnExcelImport.TabIndex = 56
        Me.btnExcelImport.Text = "インポート"
        Me.btnExcelImport.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        Me.btnUpdate.Location = New System.Drawing.Point(584, 5)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(75, 25)
        Me.btnUpdate.TabIndex = 55
        Me.btnUpdate.Text = "更　新"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'btnCopy
        '
        Me.btnCopy.Location = New System.Drawing.Point(3, 5)
        Me.btnCopy.Name = "btnCopy"
        Me.btnCopy.Size = New System.Drawing.Size(75, 25)
        Me.btnCopy.TabIndex = 54
        Me.btnCopy.Text = "値コピー"
        Me.btnCopy.UseVisualStyleBackColor = True
        '
        'frmCheckupManage
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.CaptionDisplayMode = JPHealth.frmTempForm.StatusDisplayMode.ShowAll
        Me.ClientSize = New System.Drawing.Size(1334, 749)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmCheckupManage"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmCheckupManage"
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox3, 0)
        Me.Controls.SetChildIndex(Me.GroupBox4, 0)
        Me.Controls.SetChildIndex(Me.GroupBox5, 0)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.C1FGridResult, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.C1FGridHeader, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        CType(Me.C1FGridDefect, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
	Friend WithEvents cmbLotID As ComboBox
	Friend WithEvents Label1 As Label
	Friend WithEvents Label6 As Label
	Friend WithEvents dtpSendDate As DateTimePicker
	Friend WithEvents GroupBox2 As GroupBox
	Friend WithEvents txtTargetListDate As TextBox
	Friend WithEvents txtSuccessDate As TextBox
	Friend WithEvents Label5 As Label
	Friend WithEvents Label7 As Label
	Friend WithEvents Label4 As Label
	Friend WithEvents txtFacilityCountDate As TextBox
	Friend WithEvents txtOfficeListDate As TextBox
	Friend WithEvents Label8 As Label
	Friend WithEvents txtLeafletCSV As TextBox
	Friend WithEvents Label3 As Label
	Friend WithEvents txtCheckupCSV As TextBox
	Friend WithEvents Label2 As Label
	Friend WithEvents btnSendDateUpdate As Button
	Friend WithEvents GroupBox3 As GroupBox
	Friend WithEvents C1FGridResult As C1.Win.C1FlexGrid.C1FlexGrid
	Friend WithEvents GroupBox4 As GroupBox
	Friend WithEvents C1FGridHeader As C1.Win.C1FlexGrid.C1FlexGrid
	Friend WithEvents btnIncompleteOut As Button
	Friend WithEvents btnWeightOut As Button
	Friend WithEvents btnOfficeOut As Button
	Friend WithEvents GroupBox5 As GroupBox
	Friend WithEvents C1FGridDefect As C1.Win.C1FlexGrid.C1FlexGrid
	Friend WithEvents Panel2 As Panel
	Friend WithEvents btnUpdate As Button
	Friend WithEvents btnCopy As Button
	Friend WithEvents btnPrint As Button
	Friend WithEvents btnImport As Button
	Friend WithEvents btnListOutput As Button
	Friend WithEvents chkSuccessDate As CheckBox
	Friend WithEvents chkFacilityCountDate As CheckBox
	Friend WithEvents chkOfficeListDate As CheckBox
	Friend WithEvents chkTargetListDate As CheckBox
	Friend WithEvents ProgressBar1 As ProgressBar
	Friend WithEvents Label9 As Label
	Friend WithEvents lblCheckProgress As Label
	Friend WithEvents btnOutputFolderBrowse As Button
	Friend WithEvents txtOutputFolder As TextBox
	Friend WithEvents Label10 As Label
    Friend WithEvents btnExcelFileBrowse As Button
    Friend WithEvents txtExcelFile As TextBox
    Friend WithEvents btnExcelImport As Button
End Class
