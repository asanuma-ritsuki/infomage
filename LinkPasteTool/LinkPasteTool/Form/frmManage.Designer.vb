<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmManage
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmManage))
		Me.TabControl1 = New System.Windows.Forms.TabControl()
		Me.TabPage5 = New System.Windows.Forms.TabPage()
		Me.GroupBox10 = New System.Windows.Forms.GroupBox()
		Me.C1FGridSummary = New C1.Win.C1FlexGrid.C1FlexGrid()
		Me.Panel6 = New System.Windows.Forms.Panel()
		Me.GroupBox11 = New System.Windows.Forms.GroupBox()
		Me.lblProgress = New System.Windows.Forms.Label()
		Me.btnSummaryUpdate = New System.Windows.Forms.Button()
		Me.Panel7 = New System.Windows.Forms.Panel()
		Me.GroupBox9 = New System.Windows.Forms.GroupBox()
		Me.C1FGridProgress = New C1.Win.C1FlexGrid.C1FlexGrid()
		Me.Panel5 = New System.Windows.Forms.Panel()
		Me.btnSummaryCSCOutput = New System.Windows.Forms.Button()
		Me.TabPage1 = New System.Windows.Forms.TabPage()
		Me.GroupBox2 = New System.Windows.Forms.GroupBox()
		Me.C1FGridContents = New C1.Win.C1FlexGrid.C1FlexGrid()
		Me.Panel8 = New System.Windows.Forms.Panel()
		Me.btnContentsCSVOutput = New System.Windows.Forms.Button()
		Me.btnContentsUpdate = New System.Windows.Forms.Button()
		Me.GroupBox5 = New System.Windows.Forms.GroupBox()
		Me.btnContentsImport = New System.Windows.Forms.Button()
		Me.btnContentsBrowse = New System.Windows.Forms.Button()
		Me.txtContentsFile = New System.Windows.Forms.TextBox()
		Me.Label7 = New System.Windows.Forms.Label()
		Me.Panel1 = New System.Windows.Forms.Panel()
		Me.GroupBox1 = New System.Windows.Forms.GroupBox()
		Me.cmbContentsConfirm = New System.Windows.Forms.ComboBox()
		Me.Label20 = New System.Windows.Forms.Label()
		Me.cmbContentsUpdateFlag = New System.Windows.Forms.ComboBox()
		Me.Label8 = New System.Windows.Forms.Label()
		Me.cmbContentsProvFolderName = New System.Windows.Forms.ComboBox()
		Me.Label18 = New System.Windows.Forms.Label()
		Me.cmbContentsDelivFolderName = New System.Windows.Forms.ComboBox()
		Me.Label19 = New System.Windows.Forms.Label()
		Me.cmbContentsFlag = New System.Windows.Forms.ComboBox()
		Me.Label6 = New System.Windows.Forms.Label()
		Me.btnContentsSearch = New System.Windows.Forms.Button()
		Me.cmbContentsTargetYear = New System.Windows.Forms.ComboBox()
		Me.Label5 = New System.Windows.Forms.Label()
		Me.txtContentsSubTitle = New System.Windows.Forms.TextBox()
		Me.Label4 = New System.Windows.Forms.Label()
		Me.txtContentsDocumentName = New System.Windows.Forms.TextBox()
		Me.Label3 = New System.Windows.Forms.Label()
		Me.cmbContentsPrefecture = New System.Windows.Forms.ComboBox()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.TabPage2 = New System.Windows.Forms.TabPage()
		Me.GroupBox4 = New System.Windows.Forms.GroupBox()
		Me.C1FGridManage = New C1.Win.C1FlexGrid.C1FlexGrid()
		Me.Panel4 = New System.Windows.Forms.Panel()
		Me.btnCSVOutput = New System.Windows.Forms.Button()
		Me.GroupBox8 = New System.Windows.Forms.GroupBox()
		Me.btnManageImport = New System.Windows.Forms.Button()
		Me.btnManageBrowse = New System.Windows.Forms.Button()
		Me.txtManageFile = New System.Windows.Forms.TextBox()
		Me.Label17 = New System.Windows.Forms.Label()
		Me.Panel2 = New System.Windows.Forms.Panel()
		Me.GroupBox3 = New System.Windows.Forms.GroupBox()
		Me.cmbManageProvFolderName = New System.Windows.Forms.ComboBox()
		Me.Label16 = New System.Windows.Forms.Label()
		Me.cmbManageDelivFolderName = New System.Windows.Forms.ComboBox()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.btnManageSearch = New System.Windows.Forms.Button()
		Me.txtManageExcelName = New System.Windows.Forms.TextBox()
		Me.Label10 = New System.Windows.Forms.Label()
		Me.cmbManagePrefecture = New System.Windows.Forms.ComboBox()
		Me.Label11 = New System.Windows.Forms.Label()
		Me.cmbManageMNo = New System.Windows.Forms.ComboBox()
		Me.Label12 = New System.Windows.Forms.Label()
		Me.TabPage3 = New System.Windows.Forms.TabPage()
		Me.GroupBox7 = New System.Windows.Forms.GroupBox()
		Me.C1FGridImage = New C1.Win.C1FlexGrid.C1FlexGrid()
		Me.Panel3 = New System.Windows.Forms.Panel()
		Me.GroupBox6 = New System.Windows.Forms.GroupBox()
		Me.cmbImageFlag = New System.Windows.Forms.ComboBox()
		Me.Label9 = New System.Windows.Forms.Label()
		Me.btnImageSearch = New System.Windows.Forms.Button()
		Me.txtImageExcelName = New System.Windows.Forms.TextBox()
		Me.Label13 = New System.Windows.Forms.Label()
		Me.cmbImagePrefecture = New System.Windows.Forms.ComboBox()
		Me.Label14 = New System.Windows.Forms.Label()
		Me.cmbImageMNo = New System.Windows.Forms.ComboBox()
		Me.Label15 = New System.Windows.Forms.Label()
		Me.TabPage4 = New System.Windows.Forms.TabPage()
		Me.GroupBox13 = New System.Windows.Forms.GroupBox()
		Me.Panel15 = New System.Windows.Forms.Panel()
		Me.C1FGridOutputTo = New C1.Win.C1FlexGrid.C1FlexGrid()
		Me.Panel14 = New System.Windows.Forms.Panel()
		Me.btnOutputMove = New System.Windows.Forms.Button()
		Me.btnOutputClear = New System.Windows.Forms.Button()
		Me.Panel13 = New System.Windows.Forms.Panel()
		Me.C1FGridOutputFrom = New C1.Win.C1FlexGrid.C1FlexGrid()
		Me.Panel12 = New System.Windows.Forms.Panel()
		Me.lblOutputProgress = New System.Windows.Forms.Label()
		Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
		Me.cmbOutputPrefecture = New System.Windows.Forms.ComboBox()
		Me.chkOutputExcel = New System.Windows.Forms.CheckBox()
		Me.Label21 = New System.Windows.Forms.Label()
		Me.chkOutputImage = New System.Windows.Forms.CheckBox()
		Me.Panel10 = New System.Windows.Forms.Panel()
		Me.GroupBox12 = New System.Windows.Forms.GroupBox()
		Me.C1FGridOutput = New C1.Win.C1FlexGrid.C1FlexGrid()
		Me.Panel11 = New System.Windows.Forms.Panel()
		Me.btnOutputUpdate = New System.Windows.Forms.Button()
		Me.Panel9 = New System.Windows.Forms.Panel()
		Me.btnOutputSrcFolderBrowse = New System.Windows.Forms.Button()
		Me.txtOutputSrcFolder = New System.Windows.Forms.TextBox()
		Me.Label24 = New System.Windows.Forms.Label()
		Me.btnOutputFolderBrowse = New System.Windows.Forms.Button()
		Me.txtOutputFolder = New System.Windows.Forms.TextBox()
		Me.Label22 = New System.Windows.Forms.Label()
		Me.btnOutput = New System.Windows.Forms.Button()
		Me.C1XLBook1 = New C1.C1Excel.C1XLBook()
		Me.cmbOutputFlag = New System.Windows.Forms.ComboBox()
		Me.Label23 = New System.Windows.Forms.Label()
		Me.cmbOutputUpdateFlag = New System.Windows.Forms.ComboBox()
		Me.Label25 = New System.Windows.Forms.Label()
		Me.TabControl1.SuspendLayout()
		Me.TabPage5.SuspendLayout()
		Me.GroupBox10.SuspendLayout()
		CType(Me.C1FGridSummary, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.Panel6.SuspendLayout()
		Me.GroupBox11.SuspendLayout()
		Me.Panel7.SuspendLayout()
		Me.GroupBox9.SuspendLayout()
		CType(Me.C1FGridProgress, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.Panel5.SuspendLayout()
		Me.TabPage1.SuspendLayout()
		Me.GroupBox2.SuspendLayout()
		CType(Me.C1FGridContents, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.Panel8.SuspendLayout()
		Me.GroupBox5.SuspendLayout()
		Me.Panel1.SuspendLayout()
		Me.GroupBox1.SuspendLayout()
		Me.TabPage2.SuspendLayout()
		Me.GroupBox4.SuspendLayout()
		CType(Me.C1FGridManage, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.Panel4.SuspendLayout()
		Me.GroupBox8.SuspendLayout()
		Me.Panel2.SuspendLayout()
		Me.GroupBox3.SuspendLayout()
		Me.TabPage3.SuspendLayout()
		Me.GroupBox7.SuspendLayout()
		CType(Me.C1FGridImage, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.Panel3.SuspendLayout()
		Me.GroupBox6.SuspendLayout()
		Me.TabPage4.SuspendLayout()
		Me.GroupBox13.SuspendLayout()
		Me.Panel15.SuspendLayout()
		CType(Me.C1FGridOutputTo, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.Panel14.SuspendLayout()
		Me.Panel13.SuspendLayout()
		CType(Me.C1FGridOutputFrom, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.Panel12.SuspendLayout()
		Me.Panel10.SuspendLayout()
		Me.GroupBox12.SuspendLayout()
		CType(Me.C1FGridOutput, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.Panel11.SuspendLayout()
		Me.Panel9.SuspendLayout()
		Me.SuspendLayout()
		'
		'TabControl1
		'
		Me.TabControl1.Controls.Add(Me.TabPage5)
		Me.TabControl1.Controls.Add(Me.TabPage1)
		Me.TabControl1.Controls.Add(Me.TabPage2)
		Me.TabControl1.Controls.Add(Me.TabPage3)
		Me.TabControl1.Controls.Add(Me.TabPage4)
		Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
		Me.TabControl1.Location = New System.Drawing.Point(0, 0)
		Me.TabControl1.Name = "TabControl1"
		Me.TabControl1.SelectedIndex = 0
		Me.TabControl1.Size = New System.Drawing.Size(1584, 939)
		Me.TabControl1.TabIndex = 1
		'
		'TabPage5
		'
		Me.TabPage5.Controls.Add(Me.GroupBox10)
		Me.TabPage5.Controls.Add(Me.Panel6)
		Me.TabPage5.Controls.Add(Me.Panel5)
		Me.TabPage5.Location = New System.Drawing.Point(4, 26)
		Me.TabPage5.Name = "TabPage5"
		Me.TabPage5.Padding = New System.Windows.Forms.Padding(3)
		Me.TabPage5.Size = New System.Drawing.Size(1576, 909)
		Me.TabPage5.TabIndex = 4
		Me.TabPage5.Text = "集計"
		Me.TabPage5.UseVisualStyleBackColor = True
		'
		'GroupBox10
		'
		Me.GroupBox10.Controls.Add(Me.C1FGridSummary)
		Me.GroupBox10.Dock = System.Windows.Forms.DockStyle.Fill
		Me.GroupBox10.Location = New System.Drawing.Point(3, 199)
		Me.GroupBox10.Name = "GroupBox10"
		Me.GroupBox10.Size = New System.Drawing.Size(1570, 673)
		Me.GroupBox10.TabIndex = 2
		Me.GroupBox10.TabStop = False
		Me.GroupBox10.Text = "日付別・ユーザー別集計"
		'
		'C1FGridSummary
		'
		Me.C1FGridSummary.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
		Me.C1FGridSummary.AllowEditing = False
		Me.C1FGridSummary.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.FixedOnly
		Me.C1FGridSummary.ColumnInfo = resources.GetString("C1FGridSummary.ColumnInfo")
		Me.C1FGridSummary.Dock = System.Windows.Forms.DockStyle.Fill
		Me.C1FGridSummary.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid
		Me.C1FGridSummary.Font = New System.Drawing.Font("Meiryo UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.C1FGridSummary.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcrossOut
		Me.C1FGridSummary.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcrossOut
		Me.C1FGridSummary.Location = New System.Drawing.Point(3, 20)
		Me.C1FGridSummary.Name = "C1FGridSummary"
		Me.C1FGridSummary.Rows.Count = 2
		Me.C1FGridSummary.Rows.DefaultSize = 20
		Me.C1FGridSummary.Rows.Fixed = 2
		Me.C1FGridSummary.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
		Me.C1FGridSummary.ShowCellLabels = True
		Me.C1FGridSummary.Size = New System.Drawing.Size(1564, 650)
		Me.C1FGridSummary.SubtotalPosition = C1.Win.C1FlexGrid.SubtotalPositionEnum.BelowData
		Me.C1FGridSummary.TabIndex = 2
		Me.C1FGridSummary.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.System
		'
		'Panel6
		'
		Me.Panel6.Controls.Add(Me.GroupBox11)
		Me.Panel6.Controls.Add(Me.btnSummaryUpdate)
		Me.Panel6.Controls.Add(Me.Panel7)
		Me.Panel6.Dock = System.Windows.Forms.DockStyle.Top
		Me.Panel6.Location = New System.Drawing.Point(3, 3)
		Me.Panel6.Name = "Panel6"
		Me.Panel6.Size = New System.Drawing.Size(1570, 196)
		Me.Panel6.TabIndex = 1
		'
		'GroupBox11
		'
		Me.GroupBox11.Controls.Add(Me.lblProgress)
		Me.GroupBox11.Dock = System.Windows.Forms.DockStyle.Left
		Me.GroupBox11.Location = New System.Drawing.Point(985, 0)
		Me.GroupBox11.Name = "GroupBox11"
		Me.GroupBox11.Size = New System.Drawing.Size(455, 196)
		Me.GroupBox11.TabIndex = 12
		Me.GroupBox11.TabStop = False
		Me.GroupBox11.Text = "総進捗率"
		'
		'lblProgress
		'
		Me.lblProgress.Dock = System.Windows.Forms.DockStyle.Fill
		Me.lblProgress.Font = New System.Drawing.Font("Meiryo UI", 72.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.lblProgress.ForeColor = System.Drawing.Color.Red
		Me.lblProgress.Location = New System.Drawing.Point(3, 20)
		Me.lblProgress.Name = "lblProgress"
		Me.lblProgress.Size = New System.Drawing.Size(449, 173)
		Me.lblProgress.TabIndex = 1
		Me.lblProgress.Text = "100%"
		Me.lblProgress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'btnSummaryUpdate
		'
		Me.btnSummaryUpdate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.btnSummaryUpdate.Location = New System.Drawing.Point(1490, 165)
		Me.btnSummaryUpdate.Name = "btnSummaryUpdate"
		Me.btnSummaryUpdate.Size = New System.Drawing.Size(75, 25)
		Me.btnSummaryUpdate.TabIndex = 11
		Me.btnSummaryUpdate.Text = "更　新"
		Me.btnSummaryUpdate.UseVisualStyleBackColor = True
		'
		'Panel7
		'
		Me.Panel7.Controls.Add(Me.GroupBox9)
		Me.Panel7.Dock = System.Windows.Forms.DockStyle.Left
		Me.Panel7.Location = New System.Drawing.Point(0, 0)
		Me.Panel7.Name = "Panel7"
		Me.Panel7.Size = New System.Drawing.Size(985, 196)
		Me.Panel7.TabIndex = 0
		'
		'GroupBox9
		'
		Me.GroupBox9.Controls.Add(Me.C1FGridProgress)
		Me.GroupBox9.Dock = System.Windows.Forms.DockStyle.Fill
		Me.GroupBox9.Location = New System.Drawing.Point(0, 0)
		Me.GroupBox9.Name = "GroupBox9"
		Me.GroupBox9.Size = New System.Drawing.Size(985, 196)
		Me.GroupBox9.TabIndex = 0
		Me.GroupBox9.TabStop = False
		Me.GroupBox9.Text = "進捗"
		'
		'C1FGridProgress
		'
		Me.C1FGridProgress.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
		Me.C1FGridProgress.AllowEditing = False
		Me.C1FGridProgress.ColumnInfo = resources.GetString("C1FGridProgress.ColumnInfo")
		Me.C1FGridProgress.Dock = System.Windows.Forms.DockStyle.Fill
		Me.C1FGridProgress.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid
		Me.C1FGridProgress.Font = New System.Drawing.Font("Meiryo UI", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.C1FGridProgress.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcrossOut
		Me.C1FGridProgress.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcrossOut
		Me.C1FGridProgress.Location = New System.Drawing.Point(3, 20)
		Me.C1FGridProgress.Name = "C1FGridProgress"
		Me.C1FGridProgress.Rows.Count = 4
		Me.C1FGridProgress.Rows.DefaultSize = 41
		Me.C1FGridProgress.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
		Me.C1FGridProgress.ShowCellLabels = True
		Me.C1FGridProgress.Size = New System.Drawing.Size(979, 173)
		Me.C1FGridProgress.TabIndex = 3
		Me.C1FGridProgress.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.System
		'
		'Panel5
		'
		Me.Panel5.Controls.Add(Me.btnSummaryCSCOutput)
		Me.Panel5.Dock = System.Windows.Forms.DockStyle.Bottom
		Me.Panel5.Location = New System.Drawing.Point(3, 872)
		Me.Panel5.Name = "Panel5"
		Me.Panel5.Size = New System.Drawing.Size(1570, 34)
		Me.Panel5.TabIndex = 0
		'
		'btnSummaryCSCOutput
		'
		Me.btnSummaryCSCOutput.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.btnSummaryCSCOutput.Location = New System.Drawing.Point(1490, 6)
		Me.btnSummaryCSCOutput.Name = "btnSummaryCSCOutput"
		Me.btnSummaryCSCOutput.Size = New System.Drawing.Size(75, 25)
		Me.btnSummaryCSCOutput.TabIndex = 12
		Me.btnSummaryCSCOutput.Text = "CSV出力"
		Me.btnSummaryCSCOutput.UseVisualStyleBackColor = True
		'
		'TabPage1
		'
		Me.TabPage1.Controls.Add(Me.GroupBox2)
		Me.TabPage1.Controls.Add(Me.GroupBox5)
		Me.TabPage1.Controls.Add(Me.Panel1)
		Me.TabPage1.Location = New System.Drawing.Point(4, 26)
		Me.TabPage1.Name = "TabPage1"
		Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
		Me.TabPage1.Size = New System.Drawing.Size(1576, 909)
		Me.TabPage1.TabIndex = 0
		Me.TabPage1.Text = "目次データ"
		Me.TabPage1.UseVisualStyleBackColor = True
		'
		'GroupBox2
		'
		Me.GroupBox2.Controls.Add(Me.C1FGridContents)
		Me.GroupBox2.Controls.Add(Me.Panel8)
		Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
		Me.GroupBox2.Location = New System.Drawing.Point(3, 184)
		Me.GroupBox2.Name = "GroupBox2"
		Me.GroupBox2.Size = New System.Drawing.Size(1570, 722)
		Me.GroupBox2.TabIndex = 1
		Me.GroupBox2.TabStop = False
		Me.GroupBox2.Text = "目次データ"
		'
		'C1FGridContents
		'
		Me.C1FGridContents.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
		Me.C1FGridContents.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
		Me.C1FGridContents.AutoClipboard = True
		Me.C1FGridContents.ColumnInfo = resources.GetString("C1FGridContents.ColumnInfo")
		Me.C1FGridContents.Dock = System.Windows.Forms.DockStyle.Fill
		Me.C1FGridContents.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid
		Me.C1FGridContents.Font = New System.Drawing.Font("Meiryo UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.C1FGridContents.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcrossOut
		Me.C1FGridContents.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcrossOut
		Me.C1FGridContents.Location = New System.Drawing.Point(3, 20)
		Me.C1FGridContents.Name = "C1FGridContents"
		Me.C1FGridContents.Rows.Count = 1
		Me.C1FGridContents.Rows.DefaultSize = 20
		Me.C1FGridContents.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.CellRange
		Me.C1FGridContents.ShowCellLabels = True
		Me.C1FGridContents.Size = New System.Drawing.Size(1564, 665)
		Me.C1FGridContents.TabIndex = 1
		Me.C1FGridContents.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.System
		'
		'Panel8
		'
		Me.Panel8.Controls.Add(Me.btnContentsCSVOutput)
		Me.Panel8.Controls.Add(Me.btnContentsUpdate)
		Me.Panel8.Dock = System.Windows.Forms.DockStyle.Bottom
		Me.Panel8.Location = New System.Drawing.Point(3, 685)
		Me.Panel8.Name = "Panel8"
		Me.Panel8.Size = New System.Drawing.Size(1564, 34)
		Me.Panel8.TabIndex = 2
		'
		'btnContentsCSVOutput
		'
		Me.btnContentsCSVOutput.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.btnContentsCSVOutput.Location = New System.Drawing.Point(1486, 6)
		Me.btnContentsCSVOutput.Name = "btnContentsCSVOutput"
		Me.btnContentsCSVOutput.Size = New System.Drawing.Size(75, 25)
		Me.btnContentsCSVOutput.TabIndex = 13
		Me.btnContentsCSVOutput.Text = "CSV出力"
		Me.btnContentsCSVOutput.UseVisualStyleBackColor = True
		'
		'btnContentsUpdate
		'
		Me.btnContentsUpdate.Location = New System.Drawing.Point(3, 6)
		Me.btnContentsUpdate.Name = "btnContentsUpdate"
		Me.btnContentsUpdate.Size = New System.Drawing.Size(75, 25)
		Me.btnContentsUpdate.TabIndex = 12
		Me.btnContentsUpdate.Text = "更　新"
		Me.btnContentsUpdate.UseVisualStyleBackColor = True
		'
		'GroupBox5
		'
		Me.GroupBox5.Controls.Add(Me.btnContentsImport)
		Me.GroupBox5.Controls.Add(Me.btnContentsBrowse)
		Me.GroupBox5.Controls.Add(Me.txtContentsFile)
		Me.GroupBox5.Controls.Add(Me.Label7)
		Me.GroupBox5.Dock = System.Windows.Forms.DockStyle.Top
		Me.GroupBox5.Location = New System.Drawing.Point(3, 120)
		Me.GroupBox5.Name = "GroupBox5"
		Me.GroupBox5.Size = New System.Drawing.Size(1570, 64)
		Me.GroupBox5.TabIndex = 2
		Me.GroupBox5.TabStop = False
		Me.GroupBox5.Text = "インポート"
		'
		'btnContentsImport
		'
		Me.btnContentsImport.Location = New System.Drawing.Point(913, 23)
		Me.btnContentsImport.Name = "btnContentsImport"
		Me.btnContentsImport.Size = New System.Drawing.Size(75, 25)
		Me.btnContentsImport.TabIndex = 13
		Me.btnContentsImport.Text = "インポート"
		Me.btnContentsImport.UseVisualStyleBackColor = True
		'
		'btnContentsBrowse
		'
		Me.btnContentsBrowse.Location = New System.Drawing.Point(872, 23)
		Me.btnContentsBrowse.Name = "btnContentsBrowse"
		Me.btnContentsBrowse.Size = New System.Drawing.Size(35, 25)
		Me.btnContentsBrowse.TabIndex = 13
		Me.btnContentsBrowse.Text = "..."
		Me.btnContentsBrowse.UseVisualStyleBackColor = True
		'
		'txtContentsFile
		'
		Me.txtContentsFile.AllowDrop = True
		Me.txtContentsFile.Location = New System.Drawing.Point(114, 23)
		Me.txtContentsFile.Name = "txtContentsFile"
		Me.txtContentsFile.Size = New System.Drawing.Size(752, 24)
		Me.txtContentsFile.TabIndex = 7
		'
		'Label7
		'
		Me.Label7.Location = New System.Drawing.Point(8, 22)
		Me.Label7.Name = "Label7"
		Me.Label7.Size = New System.Drawing.Size(100, 25)
		Me.Label7.TabIndex = 6
		Me.Label7.Tag = "ファイル名"
		Me.Label7.Text = "ファイル名："
		Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'Panel1
		'
		Me.Panel1.Controls.Add(Me.GroupBox1)
		Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
		Me.Panel1.Location = New System.Drawing.Point(3, 3)
		Me.Panel1.Name = "Panel1"
		Me.Panel1.Size = New System.Drawing.Size(1570, 117)
		Me.Panel1.TabIndex = 0
		'
		'GroupBox1
		'
		Me.GroupBox1.Controls.Add(Me.cmbContentsConfirm)
		Me.GroupBox1.Controls.Add(Me.Label20)
		Me.GroupBox1.Controls.Add(Me.cmbContentsUpdateFlag)
		Me.GroupBox1.Controls.Add(Me.Label8)
		Me.GroupBox1.Controls.Add(Me.cmbContentsProvFolderName)
		Me.GroupBox1.Controls.Add(Me.Label18)
		Me.GroupBox1.Controls.Add(Me.cmbContentsDelivFolderName)
		Me.GroupBox1.Controls.Add(Me.Label19)
		Me.GroupBox1.Controls.Add(Me.cmbContentsFlag)
		Me.GroupBox1.Controls.Add(Me.Label6)
		Me.GroupBox1.Controls.Add(Me.btnContentsSearch)
		Me.GroupBox1.Controls.Add(Me.cmbContentsTargetYear)
		Me.GroupBox1.Controls.Add(Me.Label5)
		Me.GroupBox1.Controls.Add(Me.txtContentsSubTitle)
		Me.GroupBox1.Controls.Add(Me.Label4)
		Me.GroupBox1.Controls.Add(Me.txtContentsDocumentName)
		Me.GroupBox1.Controls.Add(Me.Label3)
		Me.GroupBox1.Controls.Add(Me.cmbContentsPrefecture)
		Me.GroupBox1.Controls.Add(Me.Label2)
		Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
		Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
		Me.GroupBox1.Name = "GroupBox1"
		Me.GroupBox1.Size = New System.Drawing.Size(1570, 117)
		Me.GroupBox1.TabIndex = 0
		Me.GroupBox1.TabStop = False
		Me.GroupBox1.Text = "検索"
		'
		'cmbContentsConfirm
		'
		Me.cmbContentsConfirm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cmbContentsConfirm.FormattingEnabled = True
		Me.cmbContentsConfirm.Location = New System.Drawing.Point(822, 85)
		Me.cmbContentsConfirm.Name = "cmbContentsConfirm"
		Me.cmbContentsConfirm.Size = New System.Drawing.Size(121, 25)
		Me.cmbContentsConfirm.TabIndex = 26
		'
		'Label20
		'
		Me.Label20.Location = New System.Drawing.Point(716, 84)
		Me.Label20.Name = "Label20"
		Me.Label20.Size = New System.Drawing.Size(100, 25)
		Me.Label20.TabIndex = 25
		Me.Label20.Text = "確認フラグ："
		Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'cmbContentsUpdateFlag
		'
		Me.cmbContentsUpdateFlag.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cmbContentsUpdateFlag.FormattingEnabled = True
		Me.cmbContentsUpdateFlag.Location = New System.Drawing.Point(584, 84)
		Me.cmbContentsUpdateFlag.Name = "cmbContentsUpdateFlag"
		Me.cmbContentsUpdateFlag.Size = New System.Drawing.Size(121, 25)
		Me.cmbContentsUpdateFlag.TabIndex = 24
		'
		'Label8
		'
		Me.Label8.Location = New System.Drawing.Point(478, 83)
		Me.Label8.Name = "Label8"
		Me.Label8.Size = New System.Drawing.Size(100, 25)
		Me.Label8.TabIndex = 23
		Me.Label8.Text = "変更フラグ："
		Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'cmbContentsProvFolderName
		'
		Me.cmbContentsProvFolderName.FormattingEnabled = True
		Me.cmbContentsProvFolderName.Location = New System.Drawing.Point(351, 23)
		Me.cmbContentsProvFolderName.Name = "cmbContentsProvFolderName"
		Me.cmbContentsProvFolderName.Size = New System.Drawing.Size(121, 25)
		Me.cmbContentsProvFolderName.TabIndex = 22
		'
		'Label18
		'
		Me.Label18.Location = New System.Drawing.Point(245, 22)
		Me.Label18.Name = "Label18"
		Me.Label18.Size = New System.Drawing.Size(100, 25)
		Me.Label18.TabIndex = 21
		Me.Label18.Text = "仮フォルダ名："
		Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'cmbContentsDelivFolderName
		'
		Me.cmbContentsDelivFolderName.FormattingEnabled = True
		Me.cmbContentsDelivFolderName.Location = New System.Drawing.Point(114, 23)
		Me.cmbContentsDelivFolderName.Name = "cmbContentsDelivFolderName"
		Me.cmbContentsDelivFolderName.Size = New System.Drawing.Size(121, 25)
		Me.cmbContentsDelivFolderName.TabIndex = 20
		'
		'Label19
		'
		Me.Label19.Location = New System.Drawing.Point(8, 22)
		Me.Label19.Name = "Label19"
		Me.Label19.Size = New System.Drawing.Size(100, 25)
		Me.Label19.TabIndex = 19
		Me.Label19.Text = "納品フォルダ名："
		Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'cmbContentsFlag
		'
		Me.cmbContentsFlag.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cmbContentsFlag.FormattingEnabled = True
		Me.cmbContentsFlag.Location = New System.Drawing.Point(351, 85)
		Me.cmbContentsFlag.Name = "cmbContentsFlag"
		Me.cmbContentsFlag.Size = New System.Drawing.Size(121, 25)
		Me.cmbContentsFlag.TabIndex = 12
		'
		'Label6
		'
		Me.Label6.Location = New System.Drawing.Point(245, 84)
		Me.Label6.Name = "Label6"
		Me.Label6.Size = New System.Drawing.Size(100, 25)
		Me.Label6.TabIndex = 11
		Me.Label6.Text = "フラグ："
		Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'btnContentsSearch
		'
		Me.btnContentsSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.btnContentsSearch.Location = New System.Drawing.Point(1489, 86)
		Me.btnContentsSearch.Name = "btnContentsSearch"
		Me.btnContentsSearch.Size = New System.Drawing.Size(75, 25)
		Me.btnContentsSearch.TabIndex = 10
		Me.btnContentsSearch.Text = "検　索"
		Me.btnContentsSearch.UseVisualStyleBackColor = True
		'
		'cmbContentsTargetYear
		'
		Me.cmbContentsTargetYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cmbContentsTargetYear.FormattingEnabled = True
		Me.cmbContentsTargetYear.Location = New System.Drawing.Point(351, 54)
		Me.cmbContentsTargetYear.Name = "cmbContentsTargetYear"
		Me.cmbContentsTargetYear.Size = New System.Drawing.Size(121, 25)
		Me.cmbContentsTargetYear.TabIndex = 9
		'
		'Label5
		'
		Me.Label5.Location = New System.Drawing.Point(245, 53)
		Me.Label5.Name = "Label5"
		Me.Label5.Size = New System.Drawing.Size(100, 25)
		Me.Label5.TabIndex = 8
		Me.Label5.Text = "対象年："
		Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'txtContentsSubTitle
		'
		Me.txtContentsSubTitle.Location = New System.Drawing.Point(584, 54)
		Me.txtContentsSubTitle.Name = "txtContentsSubTitle"
		Me.txtContentsSubTitle.Size = New System.Drawing.Size(250, 24)
		Me.txtContentsSubTitle.TabIndex = 7
		'
		'Label4
		'
		Me.Label4.Location = New System.Drawing.Point(478, 53)
		Me.Label4.Name = "Label4"
		Me.Label4.Size = New System.Drawing.Size(100, 25)
		Me.Label4.TabIndex = 6
		Me.Label4.Text = "副題："
		Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'txtContentsDocumentName
		'
		Me.txtContentsDocumentName.Location = New System.Drawing.Point(584, 23)
		Me.txtContentsDocumentName.Name = "txtContentsDocumentName"
		Me.txtContentsDocumentName.Size = New System.Drawing.Size(250, 24)
		Me.txtContentsDocumentName.TabIndex = 5
		'
		'Label3
		'
		Me.Label3.Location = New System.Drawing.Point(478, 22)
		Me.Label3.Name = "Label3"
		Me.Label3.Size = New System.Drawing.Size(100, 25)
		Me.Label3.TabIndex = 4
		Me.Label3.Text = "資料名："
		Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'cmbContentsPrefecture
		'
		Me.cmbContentsPrefecture.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cmbContentsPrefecture.FormattingEnabled = True
		Me.cmbContentsPrefecture.Location = New System.Drawing.Point(114, 54)
		Me.cmbContentsPrefecture.Name = "cmbContentsPrefecture"
		Me.cmbContentsPrefecture.Size = New System.Drawing.Size(121, 25)
		Me.cmbContentsPrefecture.TabIndex = 3
		'
		'Label2
		'
		Me.Label2.Location = New System.Drawing.Point(8, 53)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(100, 25)
		Me.Label2.TabIndex = 2
		Me.Label2.Text = "県名："
		Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'TabPage2
		'
		Me.TabPage2.Controls.Add(Me.GroupBox4)
		Me.TabPage2.Controls.Add(Me.Panel4)
		Me.TabPage2.Controls.Add(Me.GroupBox8)
		Me.TabPage2.Controls.Add(Me.Panel2)
		Me.TabPage2.Location = New System.Drawing.Point(4, 26)
		Me.TabPage2.Name = "TabPage2"
		Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
		Me.TabPage2.Size = New System.Drawing.Size(1576, 909)
		Me.TabPage2.TabIndex = 1
		Me.TabPage2.Text = "管理表"
		Me.TabPage2.UseVisualStyleBackColor = True
		'
		'GroupBox4
		'
		Me.GroupBox4.Controls.Add(Me.C1FGridManage)
		Me.GroupBox4.Dock = System.Windows.Forms.DockStyle.Fill
		Me.GroupBox4.Location = New System.Drawing.Point(3, 155)
		Me.GroupBox4.Name = "GroupBox4"
		Me.GroupBox4.Size = New System.Drawing.Size(1570, 717)
		Me.GroupBox4.TabIndex = 2
		Me.GroupBox4.TabStop = False
		Me.GroupBox4.Text = "目次データ"
		'
		'C1FGridManage
		'
		Me.C1FGridManage.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
		Me.C1FGridManage.AllowEditing = False
		Me.C1FGridManage.ColumnInfo = resources.GetString("C1FGridManage.ColumnInfo")
		Me.C1FGridManage.Dock = System.Windows.Forms.DockStyle.Fill
		Me.C1FGridManage.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid
		Me.C1FGridManage.Font = New System.Drawing.Font("Meiryo UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.C1FGridManage.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcrossOut
		Me.C1FGridManage.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcrossOut
		Me.C1FGridManage.Location = New System.Drawing.Point(3, 20)
		Me.C1FGridManage.Name = "C1FGridManage"
		Me.C1FGridManage.Rows.Count = 1
		Me.C1FGridManage.Rows.DefaultSize = 20
		Me.C1FGridManage.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
		Me.C1FGridManage.ShowCellLabels = True
		Me.C1FGridManage.Size = New System.Drawing.Size(1564, 694)
		Me.C1FGridManage.TabIndex = 1
		Me.C1FGridManage.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.System
		'
		'Panel4
		'
		Me.Panel4.Controls.Add(Me.btnCSVOutput)
		Me.Panel4.Dock = System.Windows.Forms.DockStyle.Bottom
		Me.Panel4.Location = New System.Drawing.Point(3, 872)
		Me.Panel4.Name = "Panel4"
		Me.Panel4.Size = New System.Drawing.Size(1570, 34)
		Me.Panel4.TabIndex = 4
		'
		'btnCSVOutput
		'
		Me.btnCSVOutput.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.btnCSVOutput.Location = New System.Drawing.Point(1489, 6)
		Me.btnCSVOutput.Name = "btnCSVOutput"
		Me.btnCSVOutput.Size = New System.Drawing.Size(75, 25)
		Me.btnCSVOutput.TabIndex = 11
		Me.btnCSVOutput.Text = "CSV出力"
		Me.btnCSVOutput.UseVisualStyleBackColor = True
		'
		'GroupBox8
		'
		Me.GroupBox8.Controls.Add(Me.btnManageImport)
		Me.GroupBox8.Controls.Add(Me.btnManageBrowse)
		Me.GroupBox8.Controls.Add(Me.txtManageFile)
		Me.GroupBox8.Controls.Add(Me.Label17)
		Me.GroupBox8.Dock = System.Windows.Forms.DockStyle.Top
		Me.GroupBox8.Location = New System.Drawing.Point(3, 91)
		Me.GroupBox8.Name = "GroupBox8"
		Me.GroupBox8.Size = New System.Drawing.Size(1570, 64)
		Me.GroupBox8.TabIndex = 3
		Me.GroupBox8.TabStop = False
		Me.GroupBox8.Text = "インポート"
		'
		'btnManageImport
		'
		Me.btnManageImport.Location = New System.Drawing.Point(913, 23)
		Me.btnManageImport.Name = "btnManageImport"
		Me.btnManageImport.Size = New System.Drawing.Size(75, 25)
		Me.btnManageImport.TabIndex = 13
		Me.btnManageImport.Text = "インポート"
		Me.btnManageImport.UseVisualStyleBackColor = True
		'
		'btnManageBrowse
		'
		Me.btnManageBrowse.Location = New System.Drawing.Point(872, 23)
		Me.btnManageBrowse.Name = "btnManageBrowse"
		Me.btnManageBrowse.Size = New System.Drawing.Size(35, 25)
		Me.btnManageBrowse.TabIndex = 13
		Me.btnManageBrowse.Text = "..."
		Me.btnManageBrowse.UseVisualStyleBackColor = True
		'
		'txtManageFile
		'
		Me.txtManageFile.AllowDrop = True
		Me.txtManageFile.Location = New System.Drawing.Point(114, 23)
		Me.txtManageFile.Name = "txtManageFile"
		Me.txtManageFile.Size = New System.Drawing.Size(752, 24)
		Me.txtManageFile.TabIndex = 7
		'
		'Label17
		'
		Me.Label17.Location = New System.Drawing.Point(8, 22)
		Me.Label17.Name = "Label17"
		Me.Label17.Size = New System.Drawing.Size(100, 25)
		Me.Label17.TabIndex = 6
		Me.Label17.Tag = "ファイル名"
		Me.Label17.Text = "ファイル名："
		Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'Panel2
		'
		Me.Panel2.Controls.Add(Me.GroupBox3)
		Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
		Me.Panel2.Location = New System.Drawing.Point(3, 3)
		Me.Panel2.Name = "Panel2"
		Me.Panel2.Size = New System.Drawing.Size(1570, 88)
		Me.Panel2.TabIndex = 1
		'
		'GroupBox3
		'
		Me.GroupBox3.Controls.Add(Me.cmbManageProvFolderName)
		Me.GroupBox3.Controls.Add(Me.Label16)
		Me.GroupBox3.Controls.Add(Me.cmbManageDelivFolderName)
		Me.GroupBox3.Controls.Add(Me.Label1)
		Me.GroupBox3.Controls.Add(Me.btnManageSearch)
		Me.GroupBox3.Controls.Add(Me.txtManageExcelName)
		Me.GroupBox3.Controls.Add(Me.Label10)
		Me.GroupBox3.Controls.Add(Me.cmbManagePrefecture)
		Me.GroupBox3.Controls.Add(Me.Label11)
		Me.GroupBox3.Controls.Add(Me.cmbManageMNo)
		Me.GroupBox3.Controls.Add(Me.Label12)
		Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Fill
		Me.GroupBox3.Location = New System.Drawing.Point(0, 0)
		Me.GroupBox3.Name = "GroupBox3"
		Me.GroupBox3.Size = New System.Drawing.Size(1570, 88)
		Me.GroupBox3.TabIndex = 0
		Me.GroupBox3.TabStop = False
		Me.GroupBox3.Text = "検索"
		'
		'cmbManageProvFolderName
		'
		Me.cmbManageProvFolderName.FormattingEnabled = True
		Me.cmbManageProvFolderName.Location = New System.Drawing.Point(351, 54)
		Me.cmbManageProvFolderName.Name = "cmbManageProvFolderName"
		Me.cmbManageProvFolderName.Size = New System.Drawing.Size(121, 25)
		Me.cmbManageProvFolderName.TabIndex = 18
		'
		'Label16
		'
		Me.Label16.Location = New System.Drawing.Point(245, 53)
		Me.Label16.Name = "Label16"
		Me.Label16.Size = New System.Drawing.Size(100, 25)
		Me.Label16.TabIndex = 17
		Me.Label16.Text = "仮フォルダ名："
		Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'cmbManageDelivFolderName
		'
		Me.cmbManageDelivFolderName.FormattingEnabled = True
		Me.cmbManageDelivFolderName.Location = New System.Drawing.Point(114, 54)
		Me.cmbManageDelivFolderName.Name = "cmbManageDelivFolderName"
		Me.cmbManageDelivFolderName.Size = New System.Drawing.Size(121, 25)
		Me.cmbManageDelivFolderName.TabIndex = 16
		'
		'Label1
		'
		Me.Label1.Location = New System.Drawing.Point(8, 53)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(100, 25)
		Me.Label1.TabIndex = 15
		Me.Label1.Text = "納品フォルダ名："
		Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'btnManageSearch
		'
		Me.btnManageSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.btnManageSearch.Location = New System.Drawing.Point(1489, 57)
		Me.btnManageSearch.Name = "btnManageSearch"
		Me.btnManageSearch.Size = New System.Drawing.Size(75, 25)
		Me.btnManageSearch.TabIndex = 10
		Me.btnManageSearch.Text = "検　索"
		Me.btnManageSearch.UseVisualStyleBackColor = True
		'
		'txtManageExcelName
		'
		Me.txtManageExcelName.Location = New System.Drawing.Point(591, 23)
		Me.txtManageExcelName.Name = "txtManageExcelName"
		Me.txtManageExcelName.Size = New System.Drawing.Size(250, 24)
		Me.txtManageExcelName.TabIndex = 5
		'
		'Label10
		'
		Me.Label10.Location = New System.Drawing.Point(485, 22)
		Me.Label10.Name = "Label10"
		Me.Label10.Size = New System.Drawing.Size(100, 25)
		Me.Label10.TabIndex = 4
		Me.Label10.Text = "エクセル名："
		Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'cmbManagePrefecture
		'
		Me.cmbManagePrefecture.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cmbManagePrefecture.FormattingEnabled = True
		Me.cmbManagePrefecture.Location = New System.Drawing.Point(351, 23)
		Me.cmbManagePrefecture.Name = "cmbManagePrefecture"
		Me.cmbManagePrefecture.Size = New System.Drawing.Size(121, 25)
		Me.cmbManagePrefecture.TabIndex = 3
		'
		'Label11
		'
		Me.Label11.Location = New System.Drawing.Point(245, 22)
		Me.Label11.Name = "Label11"
		Me.Label11.Size = New System.Drawing.Size(100, 25)
		Me.Label11.TabIndex = 2
		Me.Label11.Text = "県名："
		Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'cmbManageMNo
		'
		Me.cmbManageMNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cmbManageMNo.FormattingEnabled = True
		Me.cmbManageMNo.Location = New System.Drawing.Point(114, 23)
		Me.cmbManageMNo.Name = "cmbManageMNo"
		Me.cmbManageMNo.Size = New System.Drawing.Size(121, 25)
		Me.cmbManageMNo.TabIndex = 1
		'
		'Label12
		'
		Me.Label12.Location = New System.Drawing.Point(8, 22)
		Me.Label12.Name = "Label12"
		Me.Label12.Size = New System.Drawing.Size(100, 25)
		Me.Label12.TabIndex = 0
		Me.Label12.Text = "M番号："
		Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'TabPage3
		'
		Me.TabPage3.Controls.Add(Me.GroupBox7)
		Me.TabPage3.Controls.Add(Me.Panel3)
		Me.TabPage3.Location = New System.Drawing.Point(4, 26)
		Me.TabPage3.Name = "TabPage3"
		Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
		Me.TabPage3.Size = New System.Drawing.Size(1576, 909)
		Me.TabPage3.TabIndex = 2
		Me.TabPage3.Text = "画像"
		Me.TabPage3.UseVisualStyleBackColor = True
		'
		'GroupBox7
		'
		Me.GroupBox7.Controls.Add(Me.C1FGridImage)
		Me.GroupBox7.Dock = System.Windows.Forms.DockStyle.Fill
		Me.GroupBox7.Location = New System.Drawing.Point(3, 90)
		Me.GroupBox7.Name = "GroupBox7"
		Me.GroupBox7.Size = New System.Drawing.Size(1570, 816)
		Me.GroupBox7.TabIndex = 3
		Me.GroupBox7.TabStop = False
		Me.GroupBox7.Text = "目次データ"
		'
		'C1FGridImage
		'
		Me.C1FGridImage.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
		Me.C1FGridImage.AllowEditing = False
		Me.C1FGridImage.ColumnInfo = resources.GetString("C1FGridImage.ColumnInfo")
		Me.C1FGridImage.Dock = System.Windows.Forms.DockStyle.Fill
		Me.C1FGridImage.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid
		Me.C1FGridImage.Font = New System.Drawing.Font("Meiryo UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.C1FGridImage.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcrossOut
		Me.C1FGridImage.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcrossOut
		Me.C1FGridImage.Location = New System.Drawing.Point(3, 20)
		Me.C1FGridImage.Name = "C1FGridImage"
		Me.C1FGridImage.Rows.Count = 1
		Me.C1FGridImage.Rows.DefaultSize = 20
		Me.C1FGridImage.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
		Me.C1FGridImage.ShowCellLabels = True
		Me.C1FGridImage.Size = New System.Drawing.Size(1564, 793)
		Me.C1FGridImage.TabIndex = 1
		Me.C1FGridImage.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.System
		'
		'Panel3
		'
		Me.Panel3.Controls.Add(Me.GroupBox6)
		Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
		Me.Panel3.Location = New System.Drawing.Point(3, 3)
		Me.Panel3.Name = "Panel3"
		Me.Panel3.Size = New System.Drawing.Size(1570, 87)
		Me.Panel3.TabIndex = 2
		'
		'GroupBox6
		'
		Me.GroupBox6.Controls.Add(Me.cmbImageFlag)
		Me.GroupBox6.Controls.Add(Me.Label9)
		Me.GroupBox6.Controls.Add(Me.btnImageSearch)
		Me.GroupBox6.Controls.Add(Me.txtImageExcelName)
		Me.GroupBox6.Controls.Add(Me.Label13)
		Me.GroupBox6.Controls.Add(Me.cmbImagePrefecture)
		Me.GroupBox6.Controls.Add(Me.Label14)
		Me.GroupBox6.Controls.Add(Me.cmbImageMNo)
		Me.GroupBox6.Controls.Add(Me.Label15)
		Me.GroupBox6.Dock = System.Windows.Forms.DockStyle.Fill
		Me.GroupBox6.Location = New System.Drawing.Point(0, 0)
		Me.GroupBox6.Name = "GroupBox6"
		Me.GroupBox6.Size = New System.Drawing.Size(1570, 87)
		Me.GroupBox6.TabIndex = 0
		Me.GroupBox6.TabStop = False
		Me.GroupBox6.Text = "検索"
		'
		'cmbImageFlag
		'
		Me.cmbImageFlag.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cmbImageFlag.FormattingEnabled = True
		Me.cmbImageFlag.Location = New System.Drawing.Point(351, 54)
		Me.cmbImageFlag.Name = "cmbImageFlag"
		Me.cmbImageFlag.Size = New System.Drawing.Size(250, 25)
		Me.cmbImageFlag.TabIndex = 14
		'
		'Label9
		'
		Me.Label9.Location = New System.Drawing.Point(245, 53)
		Me.Label9.Name = "Label9"
		Me.Label9.Size = New System.Drawing.Size(100, 25)
		Me.Label9.TabIndex = 13
		Me.Label9.Text = "フラグ："
		Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'btnImageSearch
		'
		Me.btnImageSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.btnImageSearch.Location = New System.Drawing.Point(1489, 56)
		Me.btnImageSearch.Name = "btnImageSearch"
		Me.btnImageSearch.Size = New System.Drawing.Size(75, 25)
		Me.btnImageSearch.TabIndex = 10
		Me.btnImageSearch.Text = "検　索"
		Me.btnImageSearch.UseVisualStyleBackColor = True
		'
		'txtImageExcelName
		'
		Me.txtImageExcelName.Location = New System.Drawing.Point(351, 23)
		Me.txtImageExcelName.Name = "txtImageExcelName"
		Me.txtImageExcelName.Size = New System.Drawing.Size(250, 24)
		Me.txtImageExcelName.TabIndex = 5
		'
		'Label13
		'
		Me.Label13.Location = New System.Drawing.Point(245, 22)
		Me.Label13.Name = "Label13"
		Me.Label13.Size = New System.Drawing.Size(100, 25)
		Me.Label13.TabIndex = 4
		Me.Label13.Text = "エクセル名："
		Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'cmbImagePrefecture
		'
		Me.cmbImagePrefecture.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cmbImagePrefecture.FormattingEnabled = True
		Me.cmbImagePrefecture.Location = New System.Drawing.Point(114, 54)
		Me.cmbImagePrefecture.Name = "cmbImagePrefecture"
		Me.cmbImagePrefecture.Size = New System.Drawing.Size(121, 25)
		Me.cmbImagePrefecture.TabIndex = 3
		'
		'Label14
		'
		Me.Label14.Location = New System.Drawing.Point(8, 53)
		Me.Label14.Name = "Label14"
		Me.Label14.Size = New System.Drawing.Size(100, 25)
		Me.Label14.TabIndex = 2
		Me.Label14.Text = "県名："
		Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'cmbImageMNo
		'
		Me.cmbImageMNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cmbImageMNo.FormattingEnabled = True
		Me.cmbImageMNo.Location = New System.Drawing.Point(114, 23)
		Me.cmbImageMNo.Name = "cmbImageMNo"
		Me.cmbImageMNo.Size = New System.Drawing.Size(121, 25)
		Me.cmbImageMNo.TabIndex = 1
		'
		'Label15
		'
		Me.Label15.Location = New System.Drawing.Point(8, 22)
		Me.Label15.Name = "Label15"
		Me.Label15.Size = New System.Drawing.Size(100, 25)
		Me.Label15.TabIndex = 0
		Me.Label15.Text = "M番号："
		Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'TabPage4
		'
		Me.TabPage4.Controls.Add(Me.GroupBox13)
		Me.TabPage4.Controls.Add(Me.Panel10)
		Me.TabPage4.Controls.Add(Me.Panel9)
		Me.TabPage4.Location = New System.Drawing.Point(4, 26)
		Me.TabPage4.Name = "TabPage4"
		Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
		Me.TabPage4.Size = New System.Drawing.Size(1576, 909)
		Me.TabPage4.TabIndex = 3
		Me.TabPage4.Text = "出力"
		Me.TabPage4.UseVisualStyleBackColor = True
		'
		'GroupBox13
		'
		Me.GroupBox13.Controls.Add(Me.Panel15)
		Me.GroupBox13.Controls.Add(Me.Panel14)
		Me.GroupBox13.Controls.Add(Me.Panel13)
		Me.GroupBox13.Controls.Add(Me.Panel12)
		Me.GroupBox13.Dock = System.Windows.Forms.DockStyle.Fill
		Me.GroupBox13.Location = New System.Drawing.Point(3, 332)
		Me.GroupBox13.Name = "GroupBox13"
		Me.GroupBox13.Size = New System.Drawing.Size(1570, 497)
		Me.GroupBox13.TabIndex = 8
		Me.GroupBox13.TabStop = False
		Me.GroupBox13.Text = "出力"
		'
		'Panel15
		'
		Me.Panel15.Controls.Add(Me.C1FGridOutputTo)
		Me.Panel15.Dock = System.Windows.Forms.DockStyle.Left
		Me.Panel15.Location = New System.Drawing.Point(700, 54)
		Me.Panel15.Name = "Panel15"
		Me.Panel15.Size = New System.Drawing.Size(516, 440)
		Me.Panel15.TabIndex = 19
		'
		'C1FGridOutputTo
		'
		Me.C1FGridOutputTo.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
		Me.C1FGridOutputTo.AllowEditing = False
		Me.C1FGridOutputTo.ColumnInfo = resources.GetString("C1FGridOutputTo.ColumnInfo")
		Me.C1FGridOutputTo.Dock = System.Windows.Forms.DockStyle.Fill
		Me.C1FGridOutputTo.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid
		Me.C1FGridOutputTo.Font = New System.Drawing.Font("Meiryo UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.C1FGridOutputTo.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcrossOut
		Me.C1FGridOutputTo.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcrossOut
		Me.C1FGridOutputTo.Location = New System.Drawing.Point(0, 0)
		Me.C1FGridOutputTo.Name = "C1FGridOutputTo"
		Me.C1FGridOutputTo.Rows.Count = 1
		Me.C1FGridOutputTo.Rows.DefaultSize = 20
		Me.C1FGridOutputTo.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
		Me.C1FGridOutputTo.ShowCellLabels = True
		Me.C1FGridOutputTo.Size = New System.Drawing.Size(516, 440)
		Me.C1FGridOutputTo.TabIndex = 3
		Me.C1FGridOutputTo.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.System
		'
		'Panel14
		'
		Me.Panel14.Controls.Add(Me.btnOutputMove)
		Me.Panel14.Controls.Add(Me.btnOutputClear)
		Me.Panel14.Dock = System.Windows.Forms.DockStyle.Left
		Me.Panel14.Location = New System.Drawing.Point(613, 54)
		Me.Panel14.Name = "Panel14"
		Me.Panel14.Size = New System.Drawing.Size(87, 440)
		Me.Panel14.TabIndex = 18
		'
		'btnOutputMove
		'
		Me.btnOutputMove.Image = Global.LinkPasteTool.My.Resources.Resources.database_go
		Me.btnOutputMove.Location = New System.Drawing.Point(6, 106)
		Me.btnOutputMove.Name = "btnOutputMove"
		Me.btnOutputMove.Size = New System.Drawing.Size(75, 53)
		Me.btnOutputMove.TabIndex = 12
		Me.btnOutputMove.UseVisualStyleBackColor = True
		'
		'btnOutputClear
		'
		Me.btnOutputClear.Image = Global.LinkPasteTool.My.Resources.Resources.cross
		Me.btnOutputClear.Location = New System.Drawing.Point(6, 322)
		Me.btnOutputClear.Name = "btnOutputClear"
		Me.btnOutputClear.Size = New System.Drawing.Size(75, 53)
		Me.btnOutputClear.TabIndex = 13
		Me.btnOutputClear.UseVisualStyleBackColor = True
		'
		'Panel13
		'
		Me.Panel13.Controls.Add(Me.C1FGridOutputFrom)
		Me.Panel13.Dock = System.Windows.Forms.DockStyle.Left
		Me.Panel13.Location = New System.Drawing.Point(3, 54)
		Me.Panel13.Name = "Panel13"
		Me.Panel13.Size = New System.Drawing.Size(610, 440)
		Me.Panel13.TabIndex = 17
		'
		'C1FGridOutputFrom
		'
		Me.C1FGridOutputFrom.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
		Me.C1FGridOutputFrom.AllowEditing = False
		Me.C1FGridOutputFrom.ColumnInfo = resources.GetString("C1FGridOutputFrom.ColumnInfo")
		Me.C1FGridOutputFrom.Dock = System.Windows.Forms.DockStyle.Fill
		Me.C1FGridOutputFrom.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid
		Me.C1FGridOutputFrom.Font = New System.Drawing.Font("Meiryo UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.C1FGridOutputFrom.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcrossOut
		Me.C1FGridOutputFrom.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcrossOut
		Me.C1FGridOutputFrom.Location = New System.Drawing.Point(0, 0)
		Me.C1FGridOutputFrom.Name = "C1FGridOutputFrom"
		Me.C1FGridOutputFrom.Rows.Count = 1
		Me.C1FGridOutputFrom.Rows.DefaultSize = 20
		Me.C1FGridOutputFrom.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
		Me.C1FGridOutputFrom.ShowCellLabels = True
		Me.C1FGridOutputFrom.Size = New System.Drawing.Size(610, 440)
		Me.C1FGridOutputFrom.TabIndex = 2
		Me.C1FGridOutputFrom.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.System
		'
		'Panel12
		'
		Me.Panel12.Controls.Add(Me.cmbOutputUpdateFlag)
		Me.Panel12.Controls.Add(Me.Label25)
		Me.Panel12.Controls.Add(Me.cmbOutputFlag)
		Me.Panel12.Controls.Add(Me.Label23)
		Me.Panel12.Controls.Add(Me.lblOutputProgress)
		Me.Panel12.Controls.Add(Me.ProgressBar1)
		Me.Panel12.Controls.Add(Me.cmbOutputPrefecture)
		Me.Panel12.Controls.Add(Me.Label21)
		Me.Panel12.Dock = System.Windows.Forms.DockStyle.Top
		Me.Panel12.Location = New System.Drawing.Point(3, 20)
		Me.Panel12.Name = "Panel12"
		Me.Panel12.Size = New System.Drawing.Size(1564, 34)
		Me.Panel12.TabIndex = 16
		'
		'lblOutputProgress
		'
		Me.lblOutputProgress.Location = New System.Drawing.Point(1113, 6)
		Me.lblOutputProgress.Name = "lblOutputProgress"
		Me.lblOutputProgress.Size = New System.Drawing.Size(100, 23)
		Me.lblOutputProgress.TabIndex = 17
		Me.lblOutputProgress.Text = "0 / 0"
		Me.lblOutputProgress.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'ProgressBar1
		'
		Me.ProgressBar1.Location = New System.Drawing.Point(697, 6)
		Me.ProgressBar1.Name = "ProgressBar1"
		Me.ProgressBar1.Size = New System.Drawing.Size(410, 23)
		Me.ProgressBar1.TabIndex = 16
		'
		'cmbOutputPrefecture
		'
		Me.cmbOutputPrefecture.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cmbOutputPrefecture.FormattingEnabled = True
		Me.cmbOutputPrefecture.Location = New System.Drawing.Point(84, 5)
		Me.cmbOutputPrefecture.Name = "cmbOutputPrefecture"
		Me.cmbOutputPrefecture.Size = New System.Drawing.Size(121, 25)
		Me.cmbOutputPrefecture.TabIndex = 5
		'
		'chkOutputExcel
		'
		Me.chkOutputExcel.AutoSize = True
		Me.chkOutputExcel.Location = New System.Drawing.Point(1091, 43)
		Me.chkOutputExcel.Name = "chkOutputExcel"
		Me.chkOutputExcel.Size = New System.Drawing.Size(94, 21)
		Me.chkOutputExcel.TabIndex = 15
		Me.chkOutputExcel.Text = "エクセル出力"
		Me.chkOutputExcel.UseVisualStyleBackColor = True
		'
		'Label21
		'
		Me.Label21.Location = New System.Drawing.Point(10, 4)
		Me.Label21.Name = "Label21"
		Me.Label21.Size = New System.Drawing.Size(68, 25)
		Me.Label21.TabIndex = 4
		Me.Label21.Text = "県名："
		Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'chkOutputImage
		'
		Me.chkOutputImage.AutoSize = True
		Me.chkOutputImage.Location = New System.Drawing.Point(995, 43)
		Me.chkOutputImage.Name = "chkOutputImage"
		Me.chkOutputImage.Size = New System.Drawing.Size(93, 21)
		Me.chkOutputImage.TabIndex = 14
		Me.chkOutputImage.Text = "イメージ出力"
		Me.chkOutputImage.UseVisualStyleBackColor = True
		'
		'Panel10
		'
		Me.Panel10.Controls.Add(Me.GroupBox12)
		Me.Panel10.Dock = System.Windows.Forms.DockStyle.Top
		Me.Panel10.Location = New System.Drawing.Point(3, 3)
		Me.Panel10.Name = "Panel10"
		Me.Panel10.Size = New System.Drawing.Size(1570, 329)
		Me.Panel10.TabIndex = 7
		'
		'GroupBox12
		'
		Me.GroupBox12.Controls.Add(Me.C1FGridOutput)
		Me.GroupBox12.Controls.Add(Me.Panel11)
		Me.GroupBox12.Dock = System.Windows.Forms.DockStyle.Fill
		Me.GroupBox12.Location = New System.Drawing.Point(0, 0)
		Me.GroupBox12.Name = "GroupBox12"
		Me.GroupBox12.Size = New System.Drawing.Size(1570, 329)
		Me.GroupBox12.TabIndex = 6
		Me.GroupBox12.TabStop = False
		Me.GroupBox12.Text = "フラグ情報"
		'
		'C1FGridOutput
		'
		Me.C1FGridOutput.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
		Me.C1FGridOutput.AllowEditing = False
		Me.C1FGridOutput.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.FixedOnly
		Me.C1FGridOutput.ColumnInfo = resources.GetString("C1FGridOutput.ColumnInfo")
		Me.C1FGridOutput.Dock = System.Windows.Forms.DockStyle.Fill
		Me.C1FGridOutput.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid
		Me.C1FGridOutput.Font = New System.Drawing.Font("Meiryo UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.C1FGridOutput.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcrossOut
		Me.C1FGridOutput.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcrossOut
		Me.C1FGridOutput.Location = New System.Drawing.Point(3, 20)
		Me.C1FGridOutput.Name = "C1FGridOutput"
		Me.C1FGridOutput.Rows.Count = 1
		Me.C1FGridOutput.Rows.DefaultSize = 31
		Me.C1FGridOutput.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
		Me.C1FGridOutput.ShowCellLabels = True
		Me.C1FGridOutput.Size = New System.Drawing.Size(1564, 272)
		Me.C1FGridOutput.TabIndex = 2
		Me.C1FGridOutput.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.System
		'
		'Panel11
		'
		Me.Panel11.Controls.Add(Me.btnOutputUpdate)
		Me.Panel11.Dock = System.Windows.Forms.DockStyle.Bottom
		Me.Panel11.Location = New System.Drawing.Point(3, 292)
		Me.Panel11.Name = "Panel11"
		Me.Panel11.Size = New System.Drawing.Size(1564, 34)
		Me.Panel11.TabIndex = 3
		'
		'btnOutputUpdate
		'
		Me.btnOutputUpdate.Location = New System.Drawing.Point(3, 6)
		Me.btnOutputUpdate.Name = "btnOutputUpdate"
		Me.btnOutputUpdate.Size = New System.Drawing.Size(75, 25)
		Me.btnOutputUpdate.TabIndex = 12
		Me.btnOutputUpdate.Text = "更　新"
		Me.btnOutputUpdate.UseVisualStyleBackColor = True
		'
		'Panel9
		'
		Me.Panel9.Controls.Add(Me.btnOutputSrcFolderBrowse)
		Me.Panel9.Controls.Add(Me.txtOutputSrcFolder)
		Me.Panel9.Controls.Add(Me.Label24)
		Me.Panel9.Controls.Add(Me.btnOutputFolderBrowse)
		Me.Panel9.Controls.Add(Me.txtOutputFolder)
		Me.Panel9.Controls.Add(Me.chkOutputExcel)
		Me.Panel9.Controls.Add(Me.Label22)
		Me.Panel9.Controls.Add(Me.btnOutput)
		Me.Panel9.Controls.Add(Me.chkOutputImage)
		Me.Panel9.Dock = System.Windows.Forms.DockStyle.Bottom
		Me.Panel9.Location = New System.Drawing.Point(3, 829)
		Me.Panel9.Name = "Panel9"
		Me.Panel9.Size = New System.Drawing.Size(1570, 77)
		Me.Panel9.TabIndex = 5
		'
		'btnOutputSrcFolderBrowse
		'
		Me.btnOutputSrcFolderBrowse.Location = New System.Drawing.Point(873, 11)
		Me.btnOutputSrcFolderBrowse.Name = "btnOutputSrcFolderBrowse"
		Me.btnOutputSrcFolderBrowse.Size = New System.Drawing.Size(35, 25)
		Me.btnOutputSrcFolderBrowse.TabIndex = 21
		Me.btnOutputSrcFolderBrowse.Text = "..."
		Me.btnOutputSrcFolderBrowse.UseVisualStyleBackColor = True
		'
		'txtOutputSrcFolder
		'
		Me.txtOutputSrcFolder.AllowDrop = True
		Me.txtOutputSrcFolder.Location = New System.Drawing.Point(115, 11)
		Me.txtOutputSrcFolder.Name = "txtOutputSrcFolder"
		Me.txtOutputSrcFolder.Size = New System.Drawing.Size(752, 24)
		Me.txtOutputSrcFolder.TabIndex = 20
		'
		'Label24
		'
		Me.Label24.Location = New System.Drawing.Point(9, 10)
		Me.Label24.Name = "Label24"
		Me.Label24.Size = New System.Drawing.Size(100, 25)
		Me.Label24.TabIndex = 19
		Me.Label24.Tag = "ファイル名"
		Me.Label24.Text = "参照フォルダ："
		Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'btnOutputFolderBrowse
		'
		Me.btnOutputFolderBrowse.Location = New System.Drawing.Point(873, 41)
		Me.btnOutputFolderBrowse.Name = "btnOutputFolderBrowse"
		Me.btnOutputFolderBrowse.Size = New System.Drawing.Size(35, 25)
		Me.btnOutputFolderBrowse.TabIndex = 17
		Me.btnOutputFolderBrowse.Text = "..."
		Me.btnOutputFolderBrowse.UseVisualStyleBackColor = True
		'
		'txtOutputFolder
		'
		Me.txtOutputFolder.AllowDrop = True
		Me.txtOutputFolder.Location = New System.Drawing.Point(115, 41)
		Me.txtOutputFolder.Name = "txtOutputFolder"
		Me.txtOutputFolder.Size = New System.Drawing.Size(752, 24)
		Me.txtOutputFolder.TabIndex = 15
		'
		'Label22
		'
		Me.Label22.Location = New System.Drawing.Point(9, 40)
		Me.Label22.Name = "Label22"
		Me.Label22.Size = New System.Drawing.Size(100, 25)
		Me.Label22.TabIndex = 14
		Me.Label22.Tag = "ファイル名"
		Me.Label22.Text = "出力フォルダ："
		Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'btnOutput
		'
		Me.btnOutput.Location = New System.Drawing.Point(914, 41)
		Me.btnOutput.Name = "btnOutput"
		Me.btnOutput.Size = New System.Drawing.Size(75, 25)
		Me.btnOutput.TabIndex = 11
		Me.btnOutput.Text = "出　力"
		Me.btnOutput.UseVisualStyleBackColor = True
		'
		'cmbOutputFlag
		'
		Me.cmbOutputFlag.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cmbOutputFlag.FormattingEnabled = True
		Me.cmbOutputFlag.Location = New System.Drawing.Point(285, 5)
		Me.cmbOutputFlag.Name = "cmbOutputFlag"
		Me.cmbOutputFlag.Size = New System.Drawing.Size(121, 25)
		Me.cmbOutputFlag.TabIndex = 19
		'
		'Label23
		'
		Me.Label23.Location = New System.Drawing.Point(211, 4)
		Me.Label23.Name = "Label23"
		Me.Label23.Size = New System.Drawing.Size(68, 25)
		Me.Label23.TabIndex = 18
		Me.Label23.Text = "フラグ："
		Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'cmbOutputUpdateFlag
		'
		Me.cmbOutputUpdateFlag.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cmbOutputUpdateFlag.FormattingEnabled = True
		Me.cmbOutputUpdateFlag.Location = New System.Drawing.Point(509, 5)
		Me.cmbOutputUpdateFlag.Name = "cmbOutputUpdateFlag"
		Me.cmbOutputUpdateFlag.Size = New System.Drawing.Size(121, 25)
		Me.cmbOutputUpdateFlag.TabIndex = 21
		'
		'Label25
		'
		Me.Label25.Location = New System.Drawing.Point(412, 4)
		Me.Label25.Name = "Label25"
		Me.Label25.Size = New System.Drawing.Size(91, 25)
		Me.Label25.TabIndex = 20
		Me.Label25.Text = "変更フラグ："
		Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'frmManage
		'
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
		Me.CaptionDisplayMode = LinkPasteTool.frmTempForm.StatusDisplayMode.ShowAll
		Me.ClientSize = New System.Drawing.Size(1584, 961)
		Me.Controls.Add(Me.TabControl1)
		Me.KeyPreview = True
		Me.MinimumSize = New System.Drawing.Size(1024, 768)
		Me.Name = "frmManage"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "frmManage"
		Me.Controls.SetChildIndex(Me.TabControl1, 0)
		Me.TabControl1.ResumeLayout(False)
		Me.TabPage5.ResumeLayout(False)
		Me.GroupBox10.ResumeLayout(False)
		CType(Me.C1FGridSummary, System.ComponentModel.ISupportInitialize).EndInit()
		Me.Panel6.ResumeLayout(False)
		Me.GroupBox11.ResumeLayout(False)
		Me.Panel7.ResumeLayout(False)
		Me.GroupBox9.ResumeLayout(False)
		CType(Me.C1FGridProgress, System.ComponentModel.ISupportInitialize).EndInit()
		Me.Panel5.ResumeLayout(False)
		Me.TabPage1.ResumeLayout(False)
		Me.GroupBox2.ResumeLayout(False)
		CType(Me.C1FGridContents, System.ComponentModel.ISupportInitialize).EndInit()
		Me.Panel8.ResumeLayout(False)
		Me.GroupBox5.ResumeLayout(False)
		Me.GroupBox5.PerformLayout()
		Me.Panel1.ResumeLayout(False)
		Me.GroupBox1.ResumeLayout(False)
		Me.GroupBox1.PerformLayout()
		Me.TabPage2.ResumeLayout(False)
		Me.GroupBox4.ResumeLayout(False)
		CType(Me.C1FGridManage, System.ComponentModel.ISupportInitialize).EndInit()
		Me.Panel4.ResumeLayout(False)
		Me.GroupBox8.ResumeLayout(False)
		Me.GroupBox8.PerformLayout()
		Me.Panel2.ResumeLayout(False)
		Me.GroupBox3.ResumeLayout(False)
		Me.GroupBox3.PerformLayout()
		Me.TabPage3.ResumeLayout(False)
		Me.GroupBox7.ResumeLayout(False)
		CType(Me.C1FGridImage, System.ComponentModel.ISupportInitialize).EndInit()
		Me.Panel3.ResumeLayout(False)
		Me.GroupBox6.ResumeLayout(False)
		Me.GroupBox6.PerformLayout()
		Me.TabPage4.ResumeLayout(False)
		Me.GroupBox13.ResumeLayout(False)
		Me.Panel15.ResumeLayout(False)
		CType(Me.C1FGridOutputTo, System.ComponentModel.ISupportInitialize).EndInit()
		Me.Panel14.ResumeLayout(False)
		Me.Panel13.ResumeLayout(False)
		CType(Me.C1FGridOutputFrom, System.ComponentModel.ISupportInitialize).EndInit()
		Me.Panel12.ResumeLayout(False)
		Me.Panel10.ResumeLayout(False)
		Me.GroupBox12.ResumeLayout(False)
		CType(Me.C1FGridOutput, System.ComponentModel.ISupportInitialize).EndInit()
		Me.Panel11.ResumeLayout(False)
		Me.Panel9.ResumeLayout(False)
		Me.Panel9.PerformLayout()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents GroupBox1 As GroupBox
	Friend WithEvents TabPage2 As TabPage
	Friend WithEvents cmbContentsTargetYear As ComboBox
	Friend WithEvents Label5 As Label
	Friend WithEvents txtContentsSubTitle As TextBox
	Friend WithEvents Label4 As Label
	Friend WithEvents txtContentsDocumentName As TextBox
	Friend WithEvents Label3 As Label
	Friend WithEvents cmbContentsPrefecture As ComboBox
	Friend WithEvents Label2 As Label
	Friend WithEvents btnContentsSearch As Button
	Friend WithEvents cmbContentsFlag As ComboBox
	Friend WithEvents Label6 As Label
	Friend WithEvents C1FGridContents As C1.Win.C1FlexGrid.C1FlexGrid
	Friend WithEvents GroupBox4 As GroupBox
	Friend WithEvents C1FGridManage As C1.Win.C1FlexGrid.C1FlexGrid
	Friend WithEvents Panel2 As Panel
	Friend WithEvents GroupBox3 As GroupBox
	Friend WithEvents btnManageSearch As Button
	Friend WithEvents txtManageExcelName As TextBox
	Friend WithEvents Label10 As Label
	Friend WithEvents cmbManagePrefecture As ComboBox
	Friend WithEvents Label11 As Label
	Friend WithEvents cmbManageMNo As ComboBox
	Friend WithEvents Label12 As Label
	Friend WithEvents GroupBox5 As GroupBox
	Friend WithEvents btnContentsImport As Button
	Friend WithEvents btnContentsBrowse As Button
	Friend WithEvents txtContentsFile As TextBox
	Friend WithEvents Label7 As Label
	Friend WithEvents TabPage3 As TabPage
	Friend WithEvents GroupBox7 As GroupBox
	Friend WithEvents C1FGridImage As C1.Win.C1FlexGrid.C1FlexGrid
	Friend WithEvents Panel3 As Panel
	Friend WithEvents GroupBox6 As GroupBox
	Friend WithEvents cmbImageFlag As ComboBox
	Friend WithEvents Label9 As Label
	Friend WithEvents btnImageSearch As Button
	Friend WithEvents txtImageExcelName As TextBox
	Friend WithEvents Label13 As Label
	Friend WithEvents cmbImagePrefecture As ComboBox
	Friend WithEvents Label14 As Label
	Friend WithEvents cmbImageMNo As ComboBox
	Friend WithEvents Label15 As Label
	Friend WithEvents TabPage4 As TabPage
	Friend WithEvents GroupBox8 As GroupBox
	Friend WithEvents btnManageImport As Button
	Friend WithEvents btnManageBrowse As Button
	Friend WithEvents txtManageFile As TextBox
	Friend WithEvents Label17 As Label
	Friend WithEvents cmbContentsProvFolderName As ComboBox
	Friend WithEvents Label18 As Label
	Friend WithEvents cmbContentsDelivFolderName As ComboBox
	Friend WithEvents Label19 As Label
	Friend WithEvents cmbManageProvFolderName As ComboBox
	Friend WithEvents Label16 As Label
	Friend WithEvents cmbManageDelivFolderName As ComboBox
	Friend WithEvents Label1 As Label
	Friend WithEvents cmbContentsUpdateFlag As ComboBox
	Friend WithEvents Label8 As Label
	Friend WithEvents Panel4 As Panel
	Friend WithEvents btnCSVOutput As Button
	Friend WithEvents TabPage5 As TabPage
	Friend WithEvents Panel5 As Panel
	Friend WithEvents Panel6 As Panel
	Friend WithEvents GroupBox9 As GroupBox
	Friend WithEvents GroupBox10 As GroupBox
	Friend WithEvents lblProgress As Label
	Friend WithEvents Panel7 As Panel
	Friend WithEvents C1FGridProgress As C1.Win.C1FlexGrid.C1FlexGrid
	Friend WithEvents C1FGridSummary As C1.Win.C1FlexGrid.C1FlexGrid
	Friend WithEvents btnSummaryUpdate As Button
	Friend WithEvents GroupBox11 As GroupBox
	Friend WithEvents btnSummaryCSCOutput As Button
	Friend WithEvents Panel8 As Panel
	Friend WithEvents btnContentsUpdate As Button
	Friend WithEvents cmbContentsConfirm As ComboBox
	Friend WithEvents Label20 As Label
	Friend WithEvents btnContentsCSVOutput As Button
	Friend WithEvents Panel10 As Panel
	Friend WithEvents GroupBox12 As GroupBox
	Friend WithEvents C1FGridOutput As C1.Win.C1FlexGrid.C1FlexGrid
	Friend WithEvents Panel11 As Panel
	Friend WithEvents btnOutputUpdate As Button
	Friend WithEvents Panel9 As Panel
	Friend WithEvents btnOutput As Button
	Friend WithEvents GroupBox13 As GroupBox
	Friend WithEvents btnOutputMove As Button
	Friend WithEvents cmbOutputPrefecture As ComboBox
	Friend WithEvents Label21 As Label
	Friend WithEvents C1FGridOutputTo As C1.Win.C1FlexGrid.C1FlexGrid
	Friend WithEvents C1FGridOutputFrom As C1.Win.C1FlexGrid.C1FlexGrid
	Friend WithEvents btnOutputClear As Button
	Friend WithEvents btnOutputFolderBrowse As Button
	Friend WithEvents txtOutputFolder As TextBox
	Friend WithEvents Label22 As Label
	Friend WithEvents chkOutputExcel As CheckBox
	Friend WithEvents chkOutputImage As CheckBox
	Friend WithEvents Panel15 As Panel
	Friend WithEvents Panel14 As Panel
	Friend WithEvents Panel13 As Panel
	Friend WithEvents Panel12 As Panel
	Friend WithEvents lblOutputProgress As Label
	Friend WithEvents ProgressBar1 As ProgressBar
	Friend WithEvents btnOutputSrcFolderBrowse As Button
	Friend WithEvents txtOutputSrcFolder As TextBox
	Friend WithEvents Label24 As Label
	Friend WithEvents C1XLBook1 As C1.C1Excel.C1XLBook
	Friend WithEvents cmbOutputFlag As ComboBox
	Friend WithEvents Label23 As Label
	Friend WithEvents cmbOutputUpdateFlag As ComboBox
	Friend WithEvents Label25 As Label
End Class
