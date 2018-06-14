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
		Me.btnBackup.Text = "バクアップ"
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
End Class
