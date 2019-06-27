<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMaintenance
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMaintenance))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tabGeneral = New System.Windows.Forms.TabPage()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnBackup = New System.Windows.Forms.Button()
        Me.txtBackupFolder = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnBackupBrowse = New System.Windows.Forms.Button()
        Me.tabOffice = New System.Windows.Forms.TabPage()
        Me.C1FGridOffice = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.C1FGridExclusion = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.txtOfficeCSV = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.btnImport = New System.Windows.Forms.Button()
        Me.btnOutputFolderBrowse = New System.Windows.Forms.Button()
        Me.tabFacility = New System.Windows.Forms.TabPage()
        Me.C1FGridFacility = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.tabMedicalEx = New System.Windows.Forms.TabPage()
        Me.C1FGridFormType = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.C1FGridMedicalEx = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.tabWeight = New System.Windows.Forms.TabPage()
        Me.C1FGridWeight = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.tabWeightHeader = New System.Windows.Forms.TabPage()
        Me.C1FGridWeightHeader = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.tabHoliday = New System.Windows.Forms.TabPage()
        Me.C1FGridHoliday = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.btnNew = New System.Windows.Forms.Button()
        Me.txtHolidayRemarks = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpHoliday = New System.Windows.Forms.DateTimePicker()
        Me.tabFormEx = New System.Windows.Forms.TabPage()
        Me.C1FGridFormEx = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.tabLotManage = New System.Windows.Forms.TabPage()
        Me.C1FGridLotManage = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.btnLotUpdate = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtLotID = New System.Windows.Forms.TextBox()
        Me.chkDeleteFlag = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tabSangyou = New System.Windows.Forms.TabPage()
        Me.C1FGridSangyou = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btnSangyouImport = New System.Windows.Forms.Button()
        Me.txtSangyouCSV = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.picSangyou = New System.Windows.Forms.PictureBox()
        Me.txtSangyouImagePath = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtSangyouDoctor = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtSangyouFacility = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtSangyouArea = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.numSangyou = New System.Windows.Forms.NumericUpDown()
        Me.btnSangyouDelete = New System.Windows.Forms.Button()
        Me.btnSangyouUpdate = New System.Windows.Forms.Button()
        Me.btnSangyouNew = New System.Windows.Forms.Button()
        Me.txtSangyouRemarks = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.tabHantei = New System.Windows.Forms.TabPage()
        Me.C1FGridHantei = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.btnHanteiImport = New System.Windows.Forms.Button()
        Me.txtHanteiCSV = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.picHantei = New System.Windows.Forms.PictureBox()
        Me.txtHanteiImagePath = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtHanteiDoctor = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtHanteiMedical = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.numHantei = New System.Windows.Forms.NumericUpDown()
        Me.btnHanteiDelete = New System.Windows.Forms.Button()
        Me.btnHanteiUpdate = New System.Windows.Forms.Button()
        Me.btnHanteiNew = New System.Windows.Forms.Button()
        Me.txtHanteiRemarks = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.tabGeneral.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.tabOffice.SuspendLayout()
        CType(Me.C1FGridOffice, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1FGridExclusion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.tabFacility.SuspendLayout()
        CType(Me.C1FGridFacility, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabMedicalEx.SuspendLayout()
        CType(Me.C1FGridFormType, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1FGridMedicalEx, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabWeight.SuspendLayout()
        CType(Me.C1FGridWeight, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabWeightHeader.SuspendLayout()
        CType(Me.C1FGridWeightHeader, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabHoliday.SuspendLayout()
        CType(Me.C1FGridHoliday, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.tabFormEx.SuspendLayout()
        CType(Me.C1FGridFormEx, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabLotManage.SuspendLayout()
        CType(Me.C1FGridLotManage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.tabSangyou.SuspendLayout()
        CType(Me.C1FGridSangyou, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.picSangyou, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numSangyou, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabHantei.SuspendLayout()
        CType(Me.C1FGridHantei, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        CType(Me.picHantei, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numHantei, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnClose)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 674)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1008, 33)
        Me.Panel1.TabIndex = 2
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.Location = New System.Drawing.Point(930, 5)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 25)
        Me.btnClose.TabIndex = 30
        Me.btnClose.Text = "戻　る"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tabGeneral)
        Me.TabControl1.Controls.Add(Me.tabOffice)
        Me.TabControl1.Controls.Add(Me.tabFacility)
        Me.TabControl1.Controls.Add(Me.tabMedicalEx)
        Me.TabControl1.Controls.Add(Me.tabWeight)
        Me.TabControl1.Controls.Add(Me.tabWeightHeader)
        Me.TabControl1.Controls.Add(Me.tabHoliday)
        Me.TabControl1.Controls.Add(Me.tabFormEx)
        Me.TabControl1.Controls.Add(Me.tabLotManage)
        Me.TabControl1.Controls.Add(Me.tabSangyou)
        Me.TabControl1.Controls.Add(Me.tabHantei)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1008, 674)
        Me.TabControl1.TabIndex = 3
        '
        'tabGeneral
        '
        Me.tabGeneral.Controls.Add(Me.GroupBox2)
        Me.tabGeneral.Location = New System.Drawing.Point(4, 26)
        Me.tabGeneral.Name = "tabGeneral"
        Me.tabGeneral.Size = New System.Drawing.Size(1000, 644)
        Me.tabGeneral.TabIndex = 8
        Me.tabGeneral.Text = "全般"
        Me.tabGeneral.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnBackup)
        Me.GroupBox2.Controls.Add(Me.txtBackupFolder)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.btnBackupBrowse)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox2.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1000, 66)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "DBバックアップ"
        '
        'btnBackup
        '
        Me.btnBackup.Location = New System.Drawing.Point(917, 22)
        Me.btnBackup.Name = "btnBackup"
        Me.btnBackup.Size = New System.Drawing.Size(75, 25)
        Me.btnBackup.TabIndex = 72
        Me.btnBackup.Text = "バックアップ"
        Me.btnBackup.UseVisualStyleBackColor = True
        '
        'txtBackupFolder
        '
        Me.txtBackupFolder.AllowDrop = True
        Me.txtBackupFolder.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtBackupFolder.Location = New System.Drawing.Point(106, 23)
        Me.txtBackupFolder.Name = "txtBackupFolder"
        Me.txtBackupFolder.Size = New System.Drawing.Size(446, 24)
        Me.txtBackupFolder.TabIndex = 69
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(10, 24)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(90, 20)
        Me.Label5.TabIndex = 71
        Me.Label5.Text = "保存フォルダ："
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnBackupBrowse
        '
        Me.btnBackupBrowse.Location = New System.Drawing.Point(558, 21)
        Me.btnBackupBrowse.Name = "btnBackupBrowse"
        Me.btnBackupBrowse.Size = New System.Drawing.Size(32, 26)
        Me.btnBackupBrowse.TabIndex = 70
        Me.btnBackupBrowse.Text = "..."
        Me.btnBackupBrowse.UseVisualStyleBackColor = True
        '
        'tabOffice
        '
        Me.tabOffice.Controls.Add(Me.C1FGridOffice)
        Me.tabOffice.Controls.Add(Me.C1FGridExclusion)
        Me.tabOffice.Controls.Add(Me.Panel2)
        Me.tabOffice.Location = New System.Drawing.Point(4, 26)
        Me.tabOffice.Name = "tabOffice"
        Me.tabOffice.Padding = New System.Windows.Forms.Padding(3)
        Me.tabOffice.Size = New System.Drawing.Size(1000, 644)
        Me.tabOffice.TabIndex = 0
        Me.tabOffice.Text = "局所マスタ"
        Me.tabOffice.UseVisualStyleBackColor = True
        '
        'C1FGridOffice
        '
        Me.C1FGridOffice.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.C1FGridOffice.AllowEditing = False
        Me.C1FGridOffice.AllowFiltering = True
        Me.C1FGridOffice.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.C1FGridOffice.AutoClipboard = True
        Me.C1FGridOffice.ColumnInfo = resources.GetString("C1FGridOffice.ColumnInfo")
        Me.C1FGridOffice.Dock = System.Windows.Forms.DockStyle.Fill
        Me.C1FGridOffice.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid
        Me.C1FGridOffice.Font = New System.Drawing.Font("Meiryo UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.C1FGridOffice.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcrossOut
        Me.C1FGridOffice.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcrossOut
        Me.C1FGridOffice.Location = New System.Drawing.Point(3, 3)
        Me.C1FGridOffice.Name = "C1FGridOffice"
        Me.C1FGridOffice.Rows.Count = 1
        Me.C1FGridOffice.Rows.DefaultSize = 20
        Me.C1FGridOffice.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.ListBox
        Me.C1FGridOffice.ShowCellLabels = True
        Me.C1FGridOffice.Size = New System.Drawing.Size(994, 412)
        Me.C1FGridOffice.TabIndex = 4
        Me.C1FGridOffice.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.System
        '
        'C1FGridExclusion
        '
        Me.C1FGridExclusion.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.C1FGridExclusion.AllowEditing = False
        Me.C1FGridExclusion.AllowFiltering = True
        Me.C1FGridExclusion.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.C1FGridExclusion.AutoClipboard = True
        Me.C1FGridExclusion.ColumnInfo = resources.GetString("C1FGridExclusion.ColumnInfo")
        Me.C1FGridExclusion.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.C1FGridExclusion.ExtendLastCol = True
        Me.C1FGridExclusion.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid
        Me.C1FGridExclusion.Font = New System.Drawing.Font("Meiryo UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.C1FGridExclusion.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcrossOut
        Me.C1FGridExclusion.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcrossOut
        Me.C1FGridExclusion.Location = New System.Drawing.Point(3, 415)
        Me.C1FGridExclusion.Name = "C1FGridExclusion"
        Me.C1FGridExclusion.Rows.Count = 1
        Me.C1FGridExclusion.Rows.DefaultSize = 20
        Me.C1FGridExclusion.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.ListBox
        Me.C1FGridExclusion.ShowCellLabels = True
        Me.C1FGridExclusion.Size = New System.Drawing.Size(994, 197)
        Me.C1FGridExclusion.TabIndex = 70
        Me.C1FGridExclusion.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.System
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.txtOfficeCSV)
        Me.Panel2.Controls.Add(Me.Label10)
        Me.Panel2.Controls.Add(Me.btnImport)
        Me.Panel2.Controls.Add(Me.btnOutputFolderBrowse)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(3, 612)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(994, 29)
        Me.Panel2.TabIndex = 71
        '
        'txtOfficeCSV
        '
        Me.txtOfficeCSV.AllowDrop = True
        Me.txtOfficeCSV.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtOfficeCSV.Location = New System.Drawing.Point(100, 3)
        Me.txtOfficeCSV.Name = "txtOfficeCSV"
        Me.txtOfficeCSV.Size = New System.Drawing.Size(446, 24)
        Me.txtOfficeCSV.TabIndex = 66
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(4, 4)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(90, 20)
        Me.Label10.TabIndex = 68
        Me.Label10.Text = "局所CSV："
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnImport
        '
        Me.btnImport.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnImport.Location = New System.Drawing.Point(914, 2)
        Me.btnImport.Name = "btnImport"
        Me.btnImport.Size = New System.Drawing.Size(75, 25)
        Me.btnImport.TabIndex = 69
        Me.btnImport.Text = "インポート"
        Me.btnImport.UseVisualStyleBackColor = True
        '
        'btnOutputFolderBrowse
        '
        Me.btnOutputFolderBrowse.Location = New System.Drawing.Point(552, 1)
        Me.btnOutputFolderBrowse.Name = "btnOutputFolderBrowse"
        Me.btnOutputFolderBrowse.Size = New System.Drawing.Size(32, 26)
        Me.btnOutputFolderBrowse.TabIndex = 67
        Me.btnOutputFolderBrowse.Text = "..."
        Me.btnOutputFolderBrowse.UseVisualStyleBackColor = True
        '
        'tabFacility
        '
        Me.tabFacility.Controls.Add(Me.C1FGridFacility)
        Me.tabFacility.Location = New System.Drawing.Point(4, 26)
        Me.tabFacility.Name = "tabFacility"
        Me.tabFacility.Padding = New System.Windows.Forms.Padding(3)
        Me.tabFacility.Size = New System.Drawing.Size(1000, 644)
        Me.tabFacility.TabIndex = 1
        Me.tabFacility.Text = "健康管理施設マスタ"
        Me.tabFacility.UseVisualStyleBackColor = True
        '
        'C1FGridFacility
        '
        Me.C1FGridFacility.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.C1FGridFacility.AllowEditing = False
        Me.C1FGridFacility.AllowFiltering = True
        Me.C1FGridFacility.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.C1FGridFacility.AutoClipboard = True
        Me.C1FGridFacility.ColumnInfo = resources.GetString("C1FGridFacility.ColumnInfo")
        Me.C1FGridFacility.Dock = System.Windows.Forms.DockStyle.Fill
        Me.C1FGridFacility.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid
        Me.C1FGridFacility.Font = New System.Drawing.Font("Meiryo UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.C1FGridFacility.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcrossOut
        Me.C1FGridFacility.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcrossOut
        Me.C1FGridFacility.Location = New System.Drawing.Point(3, 3)
        Me.C1FGridFacility.Name = "C1FGridFacility"
        Me.C1FGridFacility.Rows.Count = 1
        Me.C1FGridFacility.Rows.DefaultSize = 20
        Me.C1FGridFacility.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.ListBox
        Me.C1FGridFacility.ShowCellLabels = True
        Me.C1FGridFacility.Size = New System.Drawing.Size(994, 638)
        Me.C1FGridFacility.TabIndex = 5
        Me.C1FGridFacility.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.System
        '
        'tabMedicalEx
        '
        Me.tabMedicalEx.Controls.Add(Me.C1FGridFormType)
        Me.tabMedicalEx.Controls.Add(Me.C1FGridMedicalEx)
        Me.tabMedicalEx.Location = New System.Drawing.Point(4, 26)
        Me.tabMedicalEx.Name = "tabMedicalEx"
        Me.tabMedicalEx.Size = New System.Drawing.Size(1000, 644)
        Me.tabMedicalEx.TabIndex = 2
        Me.tabMedicalEx.Text = "健診種別、帳票タイプ"
        Me.tabMedicalEx.UseVisualStyleBackColor = True
        '
        'C1FGridFormType
        '
        Me.C1FGridFormType.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.C1FGridFormType.AllowEditing = False
        Me.C1FGridFormType.AllowFiltering = True
        Me.C1FGridFormType.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.C1FGridFormType.AutoClipboard = True
        Me.C1FGridFormType.ColumnInfo = resources.GetString("C1FGridFormType.ColumnInfo")
        Me.C1FGridFormType.Dock = System.Windows.Forms.DockStyle.Fill
        Me.C1FGridFormType.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid
        Me.C1FGridFormType.Font = New System.Drawing.Font("Meiryo UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.C1FGridFormType.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcrossOut
        Me.C1FGridFormType.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcrossOut
        Me.C1FGridFormType.Location = New System.Drawing.Point(388, 0)
        Me.C1FGridFormType.Name = "C1FGridFormType"
        Me.C1FGridFormType.Rows.Count = 1
        Me.C1FGridFormType.Rows.DefaultSize = 20
        Me.C1FGridFormType.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.C1FGridFormType.ShowCellLabels = True
        Me.C1FGridFormType.Size = New System.Drawing.Size(612, 644)
        Me.C1FGridFormType.TabIndex = 6
        Me.C1FGridFormType.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.System
        '
        'C1FGridMedicalEx
        '
        Me.C1FGridMedicalEx.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.C1FGridMedicalEx.AllowEditing = False
        Me.C1FGridMedicalEx.AllowFiltering = True
        Me.C1FGridMedicalEx.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.C1FGridMedicalEx.AutoClipboard = True
        Me.C1FGridMedicalEx.ColumnInfo = resources.GetString("C1FGridMedicalEx.ColumnInfo")
        Me.C1FGridMedicalEx.Dock = System.Windows.Forms.DockStyle.Left
        Me.C1FGridMedicalEx.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid
        Me.C1FGridMedicalEx.Font = New System.Drawing.Font("Meiryo UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.C1FGridMedicalEx.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcrossOut
        Me.C1FGridMedicalEx.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcrossOut
        Me.C1FGridMedicalEx.Location = New System.Drawing.Point(0, 0)
        Me.C1FGridMedicalEx.Name = "C1FGridMedicalEx"
        Me.C1FGridMedicalEx.Rows.Count = 1
        Me.C1FGridMedicalEx.Rows.DefaultSize = 20
        Me.C1FGridMedicalEx.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.C1FGridMedicalEx.ShowCellLabels = True
        Me.C1FGridMedicalEx.Size = New System.Drawing.Size(388, 644)
        Me.C1FGridMedicalEx.TabIndex = 5
        Me.C1FGridMedicalEx.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.System
        '
        'tabWeight
        '
        Me.tabWeight.Controls.Add(Me.C1FGridWeight)
        Me.tabWeight.Location = New System.Drawing.Point(4, 26)
        Me.tabWeight.Name = "tabWeight"
        Me.tabWeight.Size = New System.Drawing.Size(1000, 644)
        Me.tabWeight.TabIndex = 3
        Me.tabWeight.Text = "重量マスタ"
        Me.tabWeight.UseVisualStyleBackColor = True
        '
        'C1FGridWeight
        '
        Me.C1FGridWeight.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.C1FGridWeight.AllowEditing = False
        Me.C1FGridWeight.AllowFiltering = True
        Me.C1FGridWeight.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.C1FGridWeight.AutoClipboard = True
        Me.C1FGridWeight.ColumnInfo = resources.GetString("C1FGridWeight.ColumnInfo")
        Me.C1FGridWeight.Dock = System.Windows.Forms.DockStyle.Fill
        Me.C1FGridWeight.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid
        Me.C1FGridWeight.Font = New System.Drawing.Font("Meiryo UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.C1FGridWeight.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcrossOut
        Me.C1FGridWeight.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcrossOut
        Me.C1FGridWeight.Location = New System.Drawing.Point(0, 0)
        Me.C1FGridWeight.Name = "C1FGridWeight"
        Me.C1FGridWeight.Rows.Count = 1
        Me.C1FGridWeight.Rows.DefaultSize = 20
        Me.C1FGridWeight.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.C1FGridWeight.ShowCellLabels = True
        Me.C1FGridWeight.Size = New System.Drawing.Size(1000, 644)
        Me.C1FGridWeight.TabIndex = 6
        Me.C1FGridWeight.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.System
        '
        'tabWeightHeader
        '
        Me.tabWeightHeader.Controls.Add(Me.C1FGridWeightHeader)
        Me.tabWeightHeader.Location = New System.Drawing.Point(4, 26)
        Me.tabWeightHeader.Name = "tabWeightHeader"
        Me.tabWeightHeader.Size = New System.Drawing.Size(1000, 644)
        Me.tabWeightHeader.TabIndex = 4
        Me.tabWeightHeader.Text = "重量ヘッダマスタ"
        Me.tabWeightHeader.UseVisualStyleBackColor = True
        '
        'C1FGridWeightHeader
        '
        Me.C1FGridWeightHeader.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.C1FGridWeightHeader.AllowEditing = False
        Me.C1FGridWeightHeader.AllowFiltering = True
        Me.C1FGridWeightHeader.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.C1FGridWeightHeader.AutoClipboard = True
        Me.C1FGridWeightHeader.ColumnInfo = resources.GetString("C1FGridWeightHeader.ColumnInfo")
        Me.C1FGridWeightHeader.Dock = System.Windows.Forms.DockStyle.Fill
        Me.C1FGridWeightHeader.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid
        Me.C1FGridWeightHeader.Font = New System.Drawing.Font("Meiryo UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.C1FGridWeightHeader.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcrossOut
        Me.C1FGridWeightHeader.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcrossOut
        Me.C1FGridWeightHeader.Location = New System.Drawing.Point(0, 0)
        Me.C1FGridWeightHeader.Name = "C1FGridWeightHeader"
        Me.C1FGridWeightHeader.Rows.Count = 1
        Me.C1FGridWeightHeader.Rows.DefaultSize = 20
        Me.C1FGridWeightHeader.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.C1FGridWeightHeader.ShowCellLabels = True
        Me.C1FGridWeightHeader.Size = New System.Drawing.Size(1000, 644)
        Me.C1FGridWeightHeader.TabIndex = 7
        Me.C1FGridWeightHeader.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.System
        '
        'tabHoliday
        '
        Me.tabHoliday.Controls.Add(Me.C1FGridHoliday)
        Me.tabHoliday.Controls.Add(Me.GroupBox1)
        Me.tabHoliday.Location = New System.Drawing.Point(4, 26)
        Me.tabHoliday.Name = "tabHoliday"
        Me.tabHoliday.Size = New System.Drawing.Size(1000, 644)
        Me.tabHoliday.TabIndex = 5
        Me.tabHoliday.Text = "祝日マスタ"
        Me.tabHoliday.UseVisualStyleBackColor = True
        '
        'C1FGridHoliday
        '
        Me.C1FGridHoliday.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.C1FGridHoliday.AllowEditing = False
        Me.C1FGridHoliday.AllowFiltering = True
        Me.C1FGridHoliday.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.C1FGridHoliday.AutoClipboard = True
        Me.C1FGridHoliday.ColumnInfo = resources.GetString("C1FGridHoliday.ColumnInfo")
        Me.C1FGridHoliday.Dock = System.Windows.Forms.DockStyle.Fill
        Me.C1FGridHoliday.ExtendLastCol = True
        Me.C1FGridHoliday.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid
        Me.C1FGridHoliday.Font = New System.Drawing.Font("Meiryo UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.C1FGridHoliday.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcrossOut
        Me.C1FGridHoliday.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcrossOut
        Me.C1FGridHoliday.Location = New System.Drawing.Point(0, 0)
        Me.C1FGridHoliday.Name = "C1FGridHoliday"
        Me.C1FGridHoliday.Rows.Count = 1
        Me.C1FGridHoliday.Rows.DefaultSize = 20
        Me.C1FGridHoliday.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.C1FGridHoliday.ShowCellLabels = True
        Me.C1FGridHoliday.Size = New System.Drawing.Size(589, 644)
        Me.C1FGridHoliday.TabIndex = 6
        Me.C1FGridHoliday.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.System
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnDelete)
        Me.GroupBox1.Controls.Add(Me.btnUpdate)
        Me.GroupBox1.Controls.Add(Me.btnNew)
        Me.GroupBox1.Controls.Add(Me.txtHolidayRemarks)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.dtpHoliday)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.GroupBox1.Location = New System.Drawing.Point(589, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(411, 644)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "祝日登録"
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(271, 108)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(75, 25)
        Me.btnDelete.TabIndex = 70
        Me.btnDelete.Text = "削　除"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        Me.btnUpdate.Location = New System.Drawing.Point(190, 108)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(75, 25)
        Me.btnUpdate.TabIndex = 69
        Me.btnUpdate.Text = "更　新"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'btnNew
        '
        Me.btnNew.Location = New System.Drawing.Point(109, 108)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(75, 25)
        Me.btnNew.TabIndex = 68
        Me.btnNew.Text = "新　規"
        Me.btnNew.UseVisualStyleBackColor = True
        '
        'txtHolidayRemarks
        '
        Me.txtHolidayRemarks.AllowDrop = True
        Me.txtHolidayRemarks.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtHolidayRemarks.Location = New System.Drawing.Point(109, 67)
        Me.txtHolidayRemarks.Name = "txtHolidayRemarks"
        Me.txtHolidayRemarks.Size = New System.Drawing.Size(259, 24)
        Me.txtHolidayRemarks.TabIndex = 66
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(13, 68)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(90, 20)
        Me.Label2.TabIndex = 67
        Me.Label2.Text = "備考："
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(6, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(97, 20)
        Me.Label1.TabIndex = 22
        Me.Label1.Text = "祝日："
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dtpHoliday
        '
        Me.dtpHoliday.Location = New System.Drawing.Point(109, 37)
        Me.dtpHoliday.Name = "dtpHoliday"
        Me.dtpHoliday.Size = New System.Drawing.Size(144, 24)
        Me.dtpHoliday.TabIndex = 0
        '
        'tabFormEx
        '
        Me.tabFormEx.Controls.Add(Me.C1FGridFormEx)
        Me.tabFormEx.Location = New System.Drawing.Point(4, 26)
        Me.tabFormEx.Name = "tabFormEx"
        Me.tabFormEx.Size = New System.Drawing.Size(1000, 644)
        Me.tabFormEx.TabIndex = 6
        Me.tabFormEx.Text = "帳票種別マスタ"
        Me.tabFormEx.UseVisualStyleBackColor = True
        '
        'C1FGridFormEx
        '
        Me.C1FGridFormEx.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.C1FGridFormEx.AllowEditing = False
        Me.C1FGridFormEx.AllowFiltering = True
        Me.C1FGridFormEx.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.C1FGridFormEx.AutoClipboard = True
        Me.C1FGridFormEx.ColumnInfo = resources.GetString("C1FGridFormEx.ColumnInfo")
        Me.C1FGridFormEx.Dock = System.Windows.Forms.DockStyle.Fill
        Me.C1FGridFormEx.ExtendLastCol = True
        Me.C1FGridFormEx.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid
        Me.C1FGridFormEx.Font = New System.Drawing.Font("Meiryo UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.C1FGridFormEx.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcrossOut
        Me.C1FGridFormEx.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcrossOut
        Me.C1FGridFormEx.Location = New System.Drawing.Point(0, 0)
        Me.C1FGridFormEx.Name = "C1FGridFormEx"
        Me.C1FGridFormEx.Rows.Count = 1
        Me.C1FGridFormEx.Rows.DefaultSize = 20
        Me.C1FGridFormEx.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.C1FGridFormEx.ShowCellLabels = True
        Me.C1FGridFormEx.Size = New System.Drawing.Size(1000, 644)
        Me.C1FGridFormEx.TabIndex = 8
        Me.C1FGridFormEx.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.System
        '
        'tabLotManage
        '
        Me.tabLotManage.Controls.Add(Me.C1FGridLotManage)
        Me.tabLotManage.Controls.Add(Me.Panel3)
        Me.tabLotManage.Location = New System.Drawing.Point(4, 26)
        Me.tabLotManage.Name = "tabLotManage"
        Me.tabLotManage.Size = New System.Drawing.Size(1000, 644)
        Me.tabLotManage.TabIndex = 7
        Me.tabLotManage.Text = "ロット管理"
        Me.tabLotManage.UseVisualStyleBackColor = True
        '
        'C1FGridLotManage
        '
        Me.C1FGridLotManage.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.C1FGridLotManage.AllowEditing = False
        Me.C1FGridLotManage.AllowFiltering = True
        Me.C1FGridLotManage.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.C1FGridLotManage.AutoClipboard = True
        Me.C1FGridLotManage.ColumnInfo = resources.GetString("C1FGridLotManage.ColumnInfo")
        Me.C1FGridLotManage.Dock = System.Windows.Forms.DockStyle.Fill
        Me.C1FGridLotManage.ExtendLastCol = True
        Me.C1FGridLotManage.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid
        Me.C1FGridLotManage.Font = New System.Drawing.Font("Meiryo UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.C1FGridLotManage.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcrossOut
        Me.C1FGridLotManage.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcrossOut
        Me.C1FGridLotManage.Location = New System.Drawing.Point(0, 0)
        Me.C1FGridLotManage.Name = "C1FGridLotManage"
        Me.C1FGridLotManage.Rows.Count = 1
        Me.C1FGridLotManage.Rows.DefaultSize = 20
        Me.C1FGridLotManage.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.C1FGridLotManage.ShowCellLabels = True
        Me.C1FGridLotManage.Size = New System.Drawing.Size(1000, 615)
        Me.C1FGridLotManage.TabIndex = 9
        Me.C1FGridLotManage.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.System
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.btnLotUpdate)
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Controls.Add(Me.txtLotID)
        Me.Panel3.Controls.Add(Me.chkDeleteFlag)
        Me.Panel3.Controls.Add(Me.Label3)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 615)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1000, 29)
        Me.Panel3.TabIndex = 72
        '
        'btnLotUpdate
        '
        Me.btnLotUpdate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLotUpdate.Location = New System.Drawing.Point(917, 3)
        Me.btnLotUpdate.Name = "btnLotUpdate"
        Me.btnLotUpdate.Size = New System.Drawing.Size(75, 25)
        Me.btnLotUpdate.TabIndex = 31
        Me.btnLotUpdate.Text = "更　新"
        Me.btnLotUpdate.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(286, 5)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(90, 20)
        Me.Label4.TabIndex = 69
        Me.Label4.Text = "削除フラグ："
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtLotID
        '
        Me.txtLotID.AllowDrop = True
        Me.txtLotID.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtLotID.Location = New System.Drawing.Point(102, 4)
        Me.txtLotID.Name = "txtLotID"
        Me.txtLotID.ReadOnly = True
        Me.txtLotID.Size = New System.Drawing.Size(178, 24)
        Me.txtLotID.TabIndex = 66
        '
        'chkDeleteFlag
        '
        Me.chkDeleteFlag.AutoSize = True
        Me.chkDeleteFlag.Location = New System.Drawing.Point(382, 9)
        Me.chkDeleteFlag.Name = "chkDeleteFlag"
        Me.chkDeleteFlag.Size = New System.Drawing.Size(15, 14)
        Me.chkDeleteFlag.TabIndex = 68
        Me.chkDeleteFlag.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(6, 5)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(90, 20)
        Me.Label3.TabIndex = 67
        Me.Label3.Text = "ロットID："
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tabSangyou
        '
        Me.tabSangyou.Controls.Add(Me.C1FGridSangyou)
        Me.tabSangyou.Controls.Add(Me.GroupBox3)
        Me.tabSangyou.Location = New System.Drawing.Point(4, 26)
        Me.tabSangyou.Name = "tabSangyou"
        Me.tabSangyou.Padding = New System.Windows.Forms.Padding(3)
        Me.tabSangyou.Size = New System.Drawing.Size(1000, 644)
        Me.tabSangyou.TabIndex = 9
        Me.tabSangyou.Text = "産業医"
        Me.tabSangyou.UseVisualStyleBackColor = True
        '
        'C1FGridSangyou
        '
        Me.C1FGridSangyou.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.C1FGridSangyou.AllowEditing = False
        Me.C1FGridSangyou.AllowFiltering = True
        Me.C1FGridSangyou.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.C1FGridSangyou.AutoClipboard = True
        Me.C1FGridSangyou.ColumnInfo = resources.GetString("C1FGridSangyou.ColumnInfo")
        Me.C1FGridSangyou.Dock = System.Windows.Forms.DockStyle.Fill
        Me.C1FGridSangyou.ExtendLastCol = True
        Me.C1FGridSangyou.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid
        Me.C1FGridSangyou.Font = New System.Drawing.Font("Meiryo UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.C1FGridSangyou.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcrossOut
        Me.C1FGridSangyou.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcrossOut
        Me.C1FGridSangyou.Location = New System.Drawing.Point(3, 3)
        Me.C1FGridSangyou.Name = "C1FGridSangyou"
        Me.C1FGridSangyou.Rows.Count = 1
        Me.C1FGridSangyou.Rows.DefaultSize = 20
        Me.C1FGridSangyou.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.C1FGridSangyou.ShowCellLabels = True
        Me.C1FGridSangyou.Size = New System.Drawing.Size(583, 638)
        Me.C1FGridSangyou.TabIndex = 9
        Me.C1FGridSangyou.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.System
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btnSangyouImport)
        Me.GroupBox3.Controls.Add(Me.txtSangyouCSV)
        Me.GroupBox3.Controls.Add(Me.Label15)
        Me.GroupBox3.Controls.Add(Me.picSangyou)
        Me.GroupBox3.Controls.Add(Me.txtSangyouImagePath)
        Me.GroupBox3.Controls.Add(Me.Label14)
        Me.GroupBox3.Controls.Add(Me.txtSangyouDoctor)
        Me.GroupBox3.Controls.Add(Me.Label13)
        Me.GroupBox3.Controls.Add(Me.txtSangyouFacility)
        Me.GroupBox3.Controls.Add(Me.Label12)
        Me.GroupBox3.Controls.Add(Me.txtSangyouArea)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Controls.Add(Me.numSangyou)
        Me.GroupBox3.Controls.Add(Me.btnSangyouDelete)
        Me.GroupBox3.Controls.Add(Me.btnSangyouUpdate)
        Me.GroupBox3.Controls.Add(Me.btnSangyouNew)
        Me.GroupBox3.Controls.Add(Me.txtSangyouRemarks)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Right
        Me.GroupBox3.Location = New System.Drawing.Point(586, 3)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(411, 638)
        Me.GroupBox3.TabIndex = 8
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "産業医登録・編集"
        '
        'btnSangyouImport
        '
        Me.btnSangyouImport.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSangyouImport.Location = New System.Drawing.Point(330, 606)
        Me.btnSangyouImport.Name = "btnSangyouImport"
        Me.btnSangyouImport.Size = New System.Drawing.Size(75, 25)
        Me.btnSangyouImport.TabIndex = 83
        Me.btnSangyouImport.Text = "インポート"
        Me.btnSangyouImport.UseVisualStyleBackColor = True
        '
        'txtSangyouCSV
        '
        Me.txtSangyouCSV.AllowDrop = True
        Me.txtSangyouCSV.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSangyouCSV.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtSangyouCSV.Location = New System.Drawing.Point(6, 576)
        Me.txtSangyouCSV.Name = "txtSangyouCSV"
        Me.txtSangyouCSV.Size = New System.Drawing.Size(399, 24)
        Me.txtSangyouCSV.TabIndex = 81
        '
        'Label15
        '
        Me.Label15.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label15.Location = New System.Drawing.Point(6, 553)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(90, 20)
        Me.Label15.TabIndex = 82
        Me.Label15.Text = "産業医CSV："
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'picSangyou
        '
        Me.picSangyou.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picSangyou.Location = New System.Drawing.Point(109, 203)
        Me.picSangyou.Name = "picSangyou"
        Me.picSangyou.Size = New System.Drawing.Size(100, 100)
        Me.picSangyou.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picSangyou.TabIndex = 80
        Me.picSangyou.TabStop = False
        '
        'txtSangyouImagePath
        '
        Me.txtSangyouImagePath.AllowDrop = True
        Me.txtSangyouImagePath.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.txtSangyouImagePath.Location = New System.Drawing.Point(109, 173)
        Me.txtSangyouImagePath.Name = "txtSangyouImagePath"
        Me.txtSangyouImagePath.Size = New System.Drawing.Size(296, 24)
        Me.txtSangyouImagePath.TabIndex = 78
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(6, 174)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(97, 20)
        Me.Label14.TabIndex = 79
        Me.Label14.Text = "画像パス："
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtSangyouDoctor
        '
        Me.txtSangyouDoctor.AllowDrop = True
        Me.txtSangyouDoctor.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.txtSangyouDoctor.Location = New System.Drawing.Point(109, 113)
        Me.txtSangyouDoctor.Name = "txtSangyouDoctor"
        Me.txtSangyouDoctor.Size = New System.Drawing.Size(296, 24)
        Me.txtSangyouDoctor.TabIndex = 76
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(6, 114)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(97, 20)
        Me.Label13.TabIndex = 77
        Me.Label13.Text = "医師名："
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtSangyouFacility
        '
        Me.txtSangyouFacility.AllowDrop = True
        Me.txtSangyouFacility.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.txtSangyouFacility.Location = New System.Drawing.Point(109, 83)
        Me.txtSangyouFacility.Name = "txtSangyouFacility"
        Me.txtSangyouFacility.Size = New System.Drawing.Size(296, 24)
        Me.txtSangyouFacility.TabIndex = 74
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(6, 84)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(97, 20)
        Me.Label12.TabIndex = 75
        Me.Label12.Text = "施設名："
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtSangyouArea
        '
        Me.txtSangyouArea.AllowDrop = True
        Me.txtSangyouArea.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.txtSangyouArea.Location = New System.Drawing.Point(109, 53)
        Me.txtSangyouArea.Name = "txtSangyouArea"
        Me.txtSangyouArea.Size = New System.Drawing.Size(296, 24)
        Me.txtSangyouArea.TabIndex = 72
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(6, 54)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(97, 20)
        Me.Label11.TabIndex = 73
        Me.Label11.Text = "エリア名："
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'numSangyou
        '
        Me.numSangyou.Location = New System.Drawing.Point(109, 23)
        Me.numSangyou.Maximum = New Decimal(New Integer() {500, 0, 0, 0})
        Me.numSangyou.Name = "numSangyou"
        Me.numSangyou.Size = New System.Drawing.Size(56, 24)
        Me.numSangyou.TabIndex = 71
        '
        'btnSangyouDelete
        '
        Me.btnSangyouDelete.Location = New System.Drawing.Point(330, 321)
        Me.btnSangyouDelete.Name = "btnSangyouDelete"
        Me.btnSangyouDelete.Size = New System.Drawing.Size(75, 25)
        Me.btnSangyouDelete.TabIndex = 70
        Me.btnSangyouDelete.Text = "削　除"
        Me.btnSangyouDelete.UseVisualStyleBackColor = True
        '
        'btnSangyouUpdate
        '
        Me.btnSangyouUpdate.Location = New System.Drawing.Point(249, 321)
        Me.btnSangyouUpdate.Name = "btnSangyouUpdate"
        Me.btnSangyouUpdate.Size = New System.Drawing.Size(75, 25)
        Me.btnSangyouUpdate.TabIndex = 69
        Me.btnSangyouUpdate.Text = "更　新"
        Me.btnSangyouUpdate.UseVisualStyleBackColor = True
        '
        'btnSangyouNew
        '
        Me.btnSangyouNew.Location = New System.Drawing.Point(168, 321)
        Me.btnSangyouNew.Name = "btnSangyouNew"
        Me.btnSangyouNew.Size = New System.Drawing.Size(75, 25)
        Me.btnSangyouNew.TabIndex = 68
        Me.btnSangyouNew.Text = "新　規"
        Me.btnSangyouNew.UseVisualStyleBackColor = True
        '
        'txtSangyouRemarks
        '
        Me.txtSangyouRemarks.AllowDrop = True
        Me.txtSangyouRemarks.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.txtSangyouRemarks.Location = New System.Drawing.Point(109, 143)
        Me.txtSangyouRemarks.Name = "txtSangyouRemarks"
        Me.txtSangyouRemarks.Size = New System.Drawing.Size(296, 24)
        Me.txtSangyouRemarks.TabIndex = 66
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(6, 144)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(97, 20)
        Me.Label6.TabIndex = 67
        Me.Label6.Text = "備考："
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(6, 23)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(97, 20)
        Me.Label7.TabIndex = 22
        Me.Label7.Text = "No.："
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tabHantei
        '
        Me.tabHantei.Controls.Add(Me.C1FGridHantei)
        Me.tabHantei.Controls.Add(Me.GroupBox4)
        Me.tabHantei.Location = New System.Drawing.Point(4, 26)
        Me.tabHantei.Name = "tabHantei"
        Me.tabHantei.Padding = New System.Windows.Forms.Padding(3)
        Me.tabHantei.Size = New System.Drawing.Size(1000, 644)
        Me.tabHantei.TabIndex = 10
        Me.tabHantei.Text = "判定医"
        Me.tabHantei.UseVisualStyleBackColor = True
        '
        'C1FGridHantei
        '
        Me.C1FGridHantei.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.C1FGridHantei.AllowEditing = False
        Me.C1FGridHantei.AllowFiltering = True
        Me.C1FGridHantei.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.C1FGridHantei.AutoClipboard = True
        Me.C1FGridHantei.ColumnInfo = resources.GetString("C1FGridHantei.ColumnInfo")
        Me.C1FGridHantei.Dock = System.Windows.Forms.DockStyle.Fill
        Me.C1FGridHantei.ExtendLastCol = True
        Me.C1FGridHantei.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid
        Me.C1FGridHantei.Font = New System.Drawing.Font("Meiryo UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.C1FGridHantei.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcrossOut
        Me.C1FGridHantei.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcrossOut
        Me.C1FGridHantei.Location = New System.Drawing.Point(3, 3)
        Me.C1FGridHantei.Name = "C1FGridHantei"
        Me.C1FGridHantei.Rows.Count = 1
        Me.C1FGridHantei.Rows.DefaultSize = 20
        Me.C1FGridHantei.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.C1FGridHantei.ShowCellLabels = True
        Me.C1FGridHantei.Size = New System.Drawing.Size(583, 638)
        Me.C1FGridHantei.TabIndex = 9
        Me.C1FGridHantei.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.System
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.btnHanteiImport)
        Me.GroupBox4.Controls.Add(Me.txtHanteiCSV)
        Me.GroupBox4.Controls.Add(Me.Label19)
        Me.GroupBox4.Controls.Add(Me.picHantei)
        Me.GroupBox4.Controls.Add(Me.txtHanteiImagePath)
        Me.GroupBox4.Controls.Add(Me.Label8)
        Me.GroupBox4.Controls.Add(Me.txtHanteiDoctor)
        Me.GroupBox4.Controls.Add(Me.Label9)
        Me.GroupBox4.Controls.Add(Me.txtHanteiMedical)
        Me.GroupBox4.Controls.Add(Me.Label16)
        Me.GroupBox4.Controls.Add(Me.numHantei)
        Me.GroupBox4.Controls.Add(Me.btnHanteiDelete)
        Me.GroupBox4.Controls.Add(Me.btnHanteiUpdate)
        Me.GroupBox4.Controls.Add(Me.btnHanteiNew)
        Me.GroupBox4.Controls.Add(Me.txtHanteiRemarks)
        Me.GroupBox4.Controls.Add(Me.Label17)
        Me.GroupBox4.Controls.Add(Me.Label18)
        Me.GroupBox4.Dock = System.Windows.Forms.DockStyle.Right
        Me.GroupBox4.Location = New System.Drawing.Point(586, 3)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(411, 638)
        Me.GroupBox4.TabIndex = 8
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "判定医登録・編集"
        '
        'btnHanteiImport
        '
        Me.btnHanteiImport.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnHanteiImport.Location = New System.Drawing.Point(330, 607)
        Me.btnHanteiImport.Name = "btnHanteiImport"
        Me.btnHanteiImport.Size = New System.Drawing.Size(75, 25)
        Me.btnHanteiImport.TabIndex = 99
        Me.btnHanteiImport.Text = "インポート"
        Me.btnHanteiImport.UseVisualStyleBackColor = True
        '
        'txtHanteiCSV
        '
        Me.txtHanteiCSV.AllowDrop = True
        Me.txtHanteiCSV.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtHanteiCSV.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtHanteiCSV.Location = New System.Drawing.Point(6, 577)
        Me.txtHanteiCSV.Name = "txtHanteiCSV"
        Me.txtHanteiCSV.Size = New System.Drawing.Size(399, 24)
        Me.txtHanteiCSV.TabIndex = 97
        '
        'Label19
        '
        Me.Label19.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label19.Location = New System.Drawing.Point(6, 554)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(90, 20)
        Me.Label19.TabIndex = 98
        Me.Label19.Text = "判定医CSV："
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'picHantei
        '
        Me.picHantei.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picHantei.Location = New System.Drawing.Point(109, 173)
        Me.picHantei.Name = "picHantei"
        Me.picHantei.Size = New System.Drawing.Size(100, 100)
        Me.picHantei.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picHantei.TabIndex = 96
        Me.picHantei.TabStop = False
        '
        'txtHanteiImagePath
        '
        Me.txtHanteiImagePath.AllowDrop = True
        Me.txtHanteiImagePath.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.txtHanteiImagePath.Location = New System.Drawing.Point(109, 143)
        Me.txtHanteiImagePath.Name = "txtHanteiImagePath"
        Me.txtHanteiImagePath.Size = New System.Drawing.Size(296, 24)
        Me.txtHanteiImagePath.TabIndex = 94
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(6, 144)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(97, 20)
        Me.Label8.TabIndex = 95
        Me.Label8.Text = "画像パス："
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtHanteiDoctor
        '
        Me.txtHanteiDoctor.AllowDrop = True
        Me.txtHanteiDoctor.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.txtHanteiDoctor.Location = New System.Drawing.Point(109, 83)
        Me.txtHanteiDoctor.Name = "txtHanteiDoctor"
        Me.txtHanteiDoctor.Size = New System.Drawing.Size(296, 24)
        Me.txtHanteiDoctor.TabIndex = 92
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(6, 84)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(97, 20)
        Me.Label9.TabIndex = 93
        Me.Label9.Text = "医師名："
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtHanteiMedical
        '
        Me.txtHanteiMedical.AllowDrop = True
        Me.txtHanteiMedical.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.txtHanteiMedical.Location = New System.Drawing.Point(109, 53)
        Me.txtHanteiMedical.Name = "txtHanteiMedical"
        Me.txtHanteiMedical.Size = New System.Drawing.Size(296, 24)
        Me.txtHanteiMedical.TabIndex = 88
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(6, 54)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(97, 20)
        Me.Label16.TabIndex = 89
        Me.Label16.Text = "医療機関名："
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'numHantei
        '
        Me.numHantei.Location = New System.Drawing.Point(109, 23)
        Me.numHantei.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.numHantei.Name = "numHantei"
        Me.numHantei.Size = New System.Drawing.Size(56, 24)
        Me.numHantei.TabIndex = 87
        '
        'btnHanteiDelete
        '
        Me.btnHanteiDelete.Location = New System.Drawing.Point(330, 291)
        Me.btnHanteiDelete.Name = "btnHanteiDelete"
        Me.btnHanteiDelete.Size = New System.Drawing.Size(75, 25)
        Me.btnHanteiDelete.TabIndex = 86
        Me.btnHanteiDelete.Text = "削　除"
        Me.btnHanteiDelete.UseVisualStyleBackColor = True
        '
        'btnHanteiUpdate
        '
        Me.btnHanteiUpdate.Location = New System.Drawing.Point(249, 291)
        Me.btnHanteiUpdate.Name = "btnHanteiUpdate"
        Me.btnHanteiUpdate.Size = New System.Drawing.Size(75, 25)
        Me.btnHanteiUpdate.TabIndex = 85
        Me.btnHanteiUpdate.Text = "更　新"
        Me.btnHanteiUpdate.UseVisualStyleBackColor = True
        '
        'btnHanteiNew
        '
        Me.btnHanteiNew.Location = New System.Drawing.Point(168, 291)
        Me.btnHanteiNew.Name = "btnHanteiNew"
        Me.btnHanteiNew.Size = New System.Drawing.Size(75, 25)
        Me.btnHanteiNew.TabIndex = 84
        Me.btnHanteiNew.Text = "新　規"
        Me.btnHanteiNew.UseVisualStyleBackColor = True
        '
        'txtHanteiRemarks
        '
        Me.txtHanteiRemarks.AllowDrop = True
        Me.txtHanteiRemarks.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.txtHanteiRemarks.Location = New System.Drawing.Point(109, 113)
        Me.txtHanteiRemarks.Name = "txtHanteiRemarks"
        Me.txtHanteiRemarks.Size = New System.Drawing.Size(296, 24)
        Me.txtHanteiRemarks.TabIndex = 82
        '
        'Label17
        '
        Me.Label17.Location = New System.Drawing.Point(6, 114)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(97, 20)
        Me.Label17.TabIndex = 83
        Me.Label17.Text = "備考："
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label18
        '
        Me.Label18.Location = New System.Drawing.Point(6, 23)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(97, 20)
        Me.Label18.TabIndex = 81
        Me.Label18.Text = "No.："
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmMaintenance
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.CaptionDisplayMode = JPHealth.frmTempForm.StatusDisplayMode.ShowAll
        Me.ClientSize = New System.Drawing.Size(1008, 729)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.Panel1)
        Me.KeyPreview = True
        Me.Name = "frmMaintenance"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmMaintenance"
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.TabControl1, 0)
        Me.Panel1.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.tabGeneral.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.tabOffice.ResumeLayout(False)
        CType(Me.C1FGridOffice, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1FGridExclusion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.tabFacility.ResumeLayout(False)
        CType(Me.C1FGridFacility, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabMedicalEx.ResumeLayout(False)
        CType(Me.C1FGridFormType, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1FGridMedicalEx, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabWeight.ResumeLayout(False)
        CType(Me.C1FGridWeight, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabWeightHeader.ResumeLayout(False)
        CType(Me.C1FGridWeightHeader, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabHoliday.ResumeLayout(False)
        CType(Me.C1FGridHoliday, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.tabFormEx.ResumeLayout(False)
        CType(Me.C1FGridFormEx, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabLotManage.ResumeLayout(False)
        CType(Me.C1FGridLotManage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.tabSangyou.ResumeLayout(False)
        CType(Me.C1FGridSangyou, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.picSangyou, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numSangyou, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabHantei.ResumeLayout(False)
        CType(Me.C1FGridHantei, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.picHantei, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numHantei, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
	Friend WithEvents btnClose As Button
	Friend WithEvents TabControl1 As TabControl
	Friend WithEvents tabOffice As TabPage
	Friend WithEvents tabFacility As TabPage
	Friend WithEvents tabMedicalEx As TabPage
	Friend WithEvents tabWeight As TabPage
	Friend WithEvents tabWeightHeader As TabPage
	Friend WithEvents tabHoliday As TabPage
	Friend WithEvents tabFormEx As TabPage
	Friend WithEvents C1FGridOffice As C1.Win.C1FlexGrid.C1FlexGrid
	Friend WithEvents btnOutputFolderBrowse As Button
	Friend WithEvents txtOfficeCSV As TextBox
	Friend WithEvents Label10 As Label
	Friend WithEvents btnImport As Button
	Friend WithEvents tabLotManage As TabPage
	Friend WithEvents C1FGridExclusion As C1.Win.C1FlexGrid.C1FlexGrid
	Friend WithEvents Panel2 As Panel
	Friend WithEvents C1FGridFacility As C1.Win.C1FlexGrid.C1FlexGrid
	Friend WithEvents C1FGridFormType As C1.Win.C1FlexGrid.C1FlexGrid
	Friend WithEvents C1FGridMedicalEx As C1.Win.C1FlexGrid.C1FlexGrid
	Friend WithEvents C1FGridWeight As C1.Win.C1FlexGrid.C1FlexGrid
	Friend WithEvents C1FGridWeightHeader As C1.Win.C1FlexGrid.C1FlexGrid
	Friend WithEvents GroupBox1 As GroupBox
	Friend WithEvents dtpHoliday As DateTimePicker
	Friend WithEvents C1FGridHoliday As C1.Win.C1FlexGrid.C1FlexGrid
	Friend WithEvents Label1 As Label
	Friend WithEvents txtHolidayRemarks As TextBox
	Friend WithEvents Label2 As Label
	Friend WithEvents btnDelete As Button
	Friend WithEvents btnUpdate As Button
	Friend WithEvents btnNew As Button
	Friend WithEvents C1FGridFormEx As C1.Win.C1FlexGrid.C1FlexGrid
	Friend WithEvents C1FGridLotManage As C1.Win.C1FlexGrid.C1FlexGrid
	Friend WithEvents btnLotUpdate As Button
	Friend WithEvents Label4 As Label
	Friend WithEvents chkDeleteFlag As CheckBox
	Friend WithEvents txtLotID As TextBox
	Friend WithEvents Label3 As Label
	Friend WithEvents Panel3 As Panel
	Friend WithEvents tabGeneral As TabPage
	Friend WithEvents GroupBox2 As GroupBox
	Friend WithEvents txtBackupFolder As TextBox
	Friend WithEvents Label5 As Label
	Friend WithEvents btnBackupBrowse As Button
	Friend WithEvents btnBackup As Button
    Friend WithEvents tabSangyou As TabPage
    Friend WithEvents C1FGridSangyou As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents picSangyou As PictureBox
    Friend WithEvents txtSangyouImagePath As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents txtSangyouDoctor As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents txtSangyouFacility As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents txtSangyouArea As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents numSangyou As NumericUpDown
    Friend WithEvents btnSangyouDelete As Button
    Friend WithEvents btnSangyouUpdate As Button
    Friend WithEvents btnSangyouNew As Button
    Friend WithEvents txtSangyouRemarks As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents tabHantei As TabPage
    Friend WithEvents C1FGridHantei As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents picHantei As PictureBox
    Friend WithEvents txtHanteiImagePath As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txtHanteiDoctor As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txtHanteiMedical As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents numHantei As NumericUpDown
    Friend WithEvents btnHanteiDelete As Button
    Friend WithEvents btnHanteiUpdate As Button
    Friend WithEvents btnHanteiNew As Button
    Friend WithEvents txtHanteiRemarks As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents btnSangyouImport As Button
    Friend WithEvents txtSangyouCSV As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents btnHanteiImport As Button
    Friend WithEvents txtHanteiCSV As TextBox
    Friend WithEvents Label19 As Label
End Class
