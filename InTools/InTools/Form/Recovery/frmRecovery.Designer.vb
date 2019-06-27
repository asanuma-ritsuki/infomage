<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmRecovery
    Inherits C1.Win.C1Ribbon.C1RibbonForm

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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRecovery))
        Me.C1StatusBar1 = New C1.Win.C1Ribbon.C1StatusBar()
        Me.RibbonLabel3 = New C1.Win.C1Ribbon.RibbonLabel()
        Me.txtFileCount = New C1.Win.C1Ribbon.RibbonTextBox()
        Me.RibbonSeparator21 = New C1.Win.C1Ribbon.RibbonSeparator()
        Me.RibbonLabel4 = New C1.Win.C1Ribbon.RibbonLabel()
        Me.pgbFiles = New C1.Win.C1Ribbon.RibbonProgressBar()
        Me.txtProgress = New C1.Win.C1Ribbon.RibbonLabel()
        Me.RibbonSeparator211 = New C1.Win.C1Ribbon.RibbonSeparator()
        Me.btnBackMenu = New C1.Win.C1Ribbon.RibbonButton()
        Me.PrintDialog = New System.Windows.Forms.PrintDialog()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnSearchOption = New C1.Win.C1Input.C1Button()
        Me.btnOutput = New C1.Win.C1Input.C1Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtResultDir = New System.Windows.Forms.TextBox()
        Me.btnSearch = New C1.Win.C1Input.C1Button()
        Me.lblParentDir = New System.Windows.Forms.Label()
        Me.txtParentDir = New System.Windows.Forms.TextBox()
        Me.btnReplace = New C1.Win.C1Input.C1Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtReplace_DstDir = New System.Windows.Forms.TextBox()
        Me.txtReplace_SrcDir = New System.Windows.Forms.TextBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.txtAddDir = New System.Windows.Forms.TextBox()
        Me.txtRemoveDir = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.tabResult = New C1.Win.C1Command.C1DockingTab()
        Me.tabpgAll = New C1.Win.C1Command.C1DockingTabPage()
        Me.fgrAll = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.tabpgError = New C1.Win.C1Command.C1DockingTabPage()
        Me.fgrError = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.tabpgReplace = New C1.Win.C1Command.C1DockingTabPage()
        Me.fgrReplace = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.tabpgAdd = New C1.Win.C1Command.C1DockingTabPage()
        Me.fgrAdd = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnAdd = New C1.Win.C1Input.C1Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tabpgRemove = New C1.Win.C1Command.C1DockingTabPage()
        Me.fgrRemove = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.btnRemove = New C1.Win.C1Input.C1Button()
        Me.Label6 = New System.Windows.Forms.Label()
        CType(Me.C1StatusBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.btnSearchOption, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnOutput, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnSearch, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnReplace, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.tabResult, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabResult.SuspendLayout()
        Me.tabpgAll.SuspendLayout()
        CType(Me.fgrAll, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabpgError.SuspendLayout()
        CType(Me.fgrError, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabpgReplace.SuspendLayout()
        CType(Me.fgrReplace, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.tabpgAdd.SuspendLayout()
        CType(Me.fgrAdd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.btnAdd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabpgRemove.SuspendLayout()
        CType(Me.fgrRemove, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        CType(Me.btnRemove, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'C1StatusBar1
        '
        Me.C1StatusBar1.AutoSizeElement = C1.Framework.AutoSizeElement.Width
        Me.C1StatusBar1.LeftPaneItems.Add(Me.RibbonLabel3)
        Me.C1StatusBar1.LeftPaneItems.Add(Me.txtFileCount)
        Me.C1StatusBar1.LeftPaneItems.Add(Me.RibbonSeparator21)
        Me.C1StatusBar1.Location = New System.Drawing.Point(0, 748)
        Me.C1StatusBar1.Name = "C1StatusBar1"
        Me.C1StatusBar1.RightPaneItems.Add(Me.RibbonLabel4)
        Me.C1StatusBar1.RightPaneItems.Add(Me.pgbFiles)
        Me.C1StatusBar1.RightPaneItems.Add(Me.txtProgress)
        Me.C1StatusBar1.RightPaneItems.Add(Me.RibbonSeparator211)
        Me.C1StatusBar1.RightPaneItems.Add(Me.btnBackMenu)
        Me.C1StatusBar1.Size = New System.Drawing.Size(992, 23)
        Me.C1StatusBar1.SizingGrip = False
        '
        'RibbonLabel3
        '
        Me.RibbonLabel3.Name = "RibbonLabel3"
        Me.RibbonLabel3.Text = "検索ファイル数"
        '
        'txtFileCount
        '
        Me.txtFileCount.Enabled = False
        Me.txtFileCount.Name = "txtFileCount"
        Me.txtFileCount.Text = "0/0"
        '
        'RibbonSeparator21
        '
        Me.RibbonSeparator21.Name = "RibbonSeparator21"
        '
        'RibbonLabel4
        '
        Me.RibbonLabel4.Name = "RibbonLabel4"
        Me.RibbonLabel4.Text = "進捗"
        '
        'pgbFiles
        '
        Me.pgbFiles.Height = 20
        Me.pgbFiles.Name = "pgbFiles"
        Me.pgbFiles.Width = 400
        '
        'txtProgress
        '
        Me.txtProgress.Name = "txtProgress"
        Me.txtProgress.Text = "00000/00000"
        '
        'RibbonSeparator211
        '
        Me.RibbonSeparator211.Name = "RibbonSeparator211"
        '
        'btnBackMenu
        '
        Me.btnBackMenu.LargeImage = CType(resources.GetObject("btnBackMenu.LargeImage"), System.Drawing.Image)
        Me.btnBackMenu.Name = "btnBackMenu"
        Me.btnBackMenu.SmallImage = CType(resources.GetObject("btnBackMenu.SmallImage"), System.Drawing.Image)
        Me.btnBackMenu.Text = "戻る"
        '
        'PrintDialog
        '
        Me.PrintDialog.UseEXDialog = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnSearchOption)
        Me.GroupBox1.Controls.Add(Me.btnOutput)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtResultDir)
        Me.GroupBox1.Controls.Add(Me.btnSearch)
        Me.GroupBox1.Controls.Add(Me.lblParentDir)
        Me.GroupBox1.Controls.Add(Me.txtParentDir)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(992, 80)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "検索"
        '
        'btnSearchOption
        '
        Me.btnSearchOption.Location = New System.Drawing.Point(885, 18)
        Me.btnSearchOption.Name = "btnSearchOption"
        Me.btnSearchOption.Size = New System.Drawing.Size(87, 23)
        Me.btnSearchOption.TabIndex = 19
        Me.btnSearchOption.Text = "検索オプション"
        Me.btnSearchOption.UseVisualStyleBackColor = True
        Me.btnSearchOption.VisualStyle = C1.Win.C1Input.VisualStyle.System
        '
        'btnOutput
        '
        Me.btnOutput.Location = New System.Drawing.Point(804, 47)
        Me.btnOutput.Name = "btnOutput"
        Me.btnOutput.Size = New System.Drawing.Size(75, 23)
        Me.btnOutput.TabIndex = 18
        Me.btnOutput.Text = "出力"
        Me.btnOutput.UseVisualStyleBackColor = True
        Me.btnOutput.VisualStyle = C1.Win.C1Input.VisualStyle.System
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 54)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(118, 12)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "検索結果出力フォルダ："
        '
        'txtResultDir
        '
        Me.txtResultDir.AllowDrop = True
        Me.txtResultDir.Font = New System.Drawing.Font("MS UI Gothic", 12.0!)
        Me.txtResultDir.Location = New System.Drawing.Point(130, 47)
        Me.txtResultDir.Name = "txtResultDir"
        Me.txtResultDir.Size = New System.Drawing.Size(668, 23)
        Me.txtResultDir.TabIndex = 16
        Me.ToolTip1.SetToolTip(Me.txtResultDir, "ログ・アリバイ画像を出力するフォルダをドラッグ＆ドロップしてください。")
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(804, 18)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(75, 23)
        Me.btnSearch.TabIndex = 14
        Me.btnSearch.Text = "検索"
        Me.btnSearch.UseVisualStyleBackColor = True
        Me.btnSearch.VisualStyle = C1.Win.C1Input.VisualStyle.System
        '
        'lblParentDir
        '
        Me.lblParentDir.AutoSize = True
        Me.lblParentDir.Location = New System.Drawing.Point(66, 23)
        Me.lblParentDir.Name = "lblParentDir"
        Me.lblParentDir.Size = New System.Drawing.Size(58, 12)
        Me.lblParentDir.TabIndex = 3
        Me.lblParentDir.Text = "親フォルダ："
        '
        'txtParentDir
        '
        Me.txtParentDir.AllowDrop = True
        Me.txtParentDir.Font = New System.Drawing.Font("MS UI Gothic", 12.0!)
        Me.txtParentDir.Location = New System.Drawing.Point(130, 18)
        Me.txtParentDir.Name = "txtParentDir"
        Me.txtParentDir.Size = New System.Drawing.Size(668, 23)
        Me.txtParentDir.TabIndex = 0
        '
        'btnReplace
        '
        Me.btnReplace.Location = New System.Drawing.Point(901, 40)
        Me.btnReplace.Name = "btnReplace"
        Me.btnReplace.Size = New System.Drawing.Size(75, 23)
        Me.btnReplace.TabIndex = 15
        Me.btnReplace.Text = "差し替え"
        Me.btnReplace.UseVisualStyleBackColor = True
        Me.btnReplace.VisualStyle = C1.Win.C1Input.VisualStyle.System
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(32, 47)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(88, 12)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "抜き出しフォルダ："
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(26, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(94, 12)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "再スキャンフォルダ："
        '
        'txtReplace_DstDir
        '
        Me.txtReplace_DstDir.AllowDrop = True
        Me.txtReplace_DstDir.Font = New System.Drawing.Font("MS UI Gothic", 12.0!)
        Me.txtReplace_DstDir.Location = New System.Drawing.Point(126, 40)
        Me.txtReplace_DstDir.Name = "txtReplace_DstDir"
        Me.txtReplace_DstDir.Size = New System.Drawing.Size(769, 23)
        Me.txtReplace_DstDir.TabIndex = 2
        Me.ToolTip1.SetToolTip(Me.txtReplace_DstDir, "ログ・アリバイ画像を出力するフォルダをドラッグ＆ドロップしてください。")
        '
        'txtReplace_SrcDir
        '
        Me.txtReplace_SrcDir.AllowDrop = True
        Me.txtReplace_SrcDir.Font = New System.Drawing.Font("MS UI Gothic", 12.0!)
        Me.txtReplace_SrcDir.Location = New System.Drawing.Point(126, 12)
        Me.txtReplace_SrcDir.Name = "txtReplace_SrcDir"
        Me.txtReplace_SrcDir.Size = New System.Drawing.Size(769, 23)
        Me.txtReplace_SrcDir.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.txtReplace_SrcDir, "アリバイ用紙画像が含まれているフォルダをドラッグ＆ドロップしてください。")
        '
        'ToolTip1
        '
        Me.ToolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        '
        'txtAddDir
        '
        Me.txtAddDir.AllowDrop = True
        Me.txtAddDir.Font = New System.Drawing.Font("MS UI Gothic", 12.0!)
        Me.txtAddDir.Location = New System.Drawing.Point(126, 12)
        Me.txtAddDir.Name = "txtAddDir"
        Me.txtAddDir.Size = New System.Drawing.Size(769, 23)
        Me.txtAddDir.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.txtAddDir, "アリバイ用紙画像が含まれているフォルダをドラッグ＆ドロップしてください。")
        '
        'txtRemoveDir
        '
        Me.txtRemoveDir.AllowDrop = True
        Me.txtRemoveDir.Font = New System.Drawing.Font("MS UI Gothic", 12.0!)
        Me.txtRemoveDir.Location = New System.Drawing.Point(126, 12)
        Me.txtRemoveDir.Name = "txtRemoveDir"
        Me.txtRemoveDir.Size = New System.Drawing.Size(769, 23)
        Me.txtRemoveDir.TabIndex = 2
        Me.ToolTip1.SetToolTip(Me.txtRemoveDir, "ログ・アリバイ画像を出力するフォルダをドラッグ＆ドロップしてください。")
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.tabResult)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox3.Location = New System.Drawing.Point(0, 80)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(992, 668)
        Me.GroupBox3.TabIndex = 4
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "検索結果"
        '
        'tabResult
        '
        Me.tabResult.Controls.Add(Me.tabpgAll)
        Me.tabResult.Controls.Add(Me.tabpgError)
        Me.tabResult.Controls.Add(Me.tabpgReplace)
        Me.tabResult.Controls.Add(Me.tabpgAdd)
        Me.tabResult.Controls.Add(Me.tabpgRemove)
        Me.tabResult.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabResult.Location = New System.Drawing.Point(3, 15)
        Me.tabResult.Name = "tabResult"
        Me.tabResult.Size = New System.Drawing.Size(986, 650)
        Me.tabResult.TabIndex = 0
        Me.tabResult.TabsSpacing = 5
        Me.tabResult.TabStyle = C1.Win.C1Command.TabStyleEnum.Office2010
        Me.tabResult.VisualStyleBase = C1.Win.C1Command.VisualStyle.Office2010Black
        '
        'tabpgAll
        '
        Me.tabpgAll.Controls.Add(Me.fgrAll)
        Me.tabpgAll.Location = New System.Drawing.Point(1, 23)
        Me.tabpgAll.Name = "tabpgAll"
        Me.tabpgAll.Size = New System.Drawing.Size(984, 626)
        Me.tabpgAll.TabIndex = 4
        Me.tabpgAll.Text = "全データ"
        '
        'fgrAll
        '
        Me.fgrAll.AllowFiltering = True
        Me.fgrAll.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.fgrAll.AutoResize = True
        Me.fgrAll.ColumnInfo = resources.GetString("fgrAll.ColumnInfo")
        Me.fgrAll.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fgrAll.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid
        Me.fgrAll.Location = New System.Drawing.Point(0, 0)
        Me.fgrAll.Name = "fgrAll"
        Me.fgrAll.Rows.DefaultSize = 18
        Me.fgrAll.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.fgrAll.Size = New System.Drawing.Size(984, 626)
        Me.fgrAll.TabIndex = 1
        '
        'tabpgError
        '
        Me.tabpgError.Controls.Add(Me.fgrError)
        Me.tabpgError.Location = New System.Drawing.Point(1, 23)
        Me.tabpgError.Name = "tabpgError"
        Me.tabpgError.Size = New System.Drawing.Size(984, 626)
        Me.tabpgError.TabIndex = 3
        Me.tabpgError.Text = "残留エラー"
        '
        'fgrError
        '
        Me.fgrError.AllowFiltering = True
        Me.fgrError.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.fgrError.AutoResize = True
        Me.fgrError.ColumnInfo = resources.GetString("fgrError.ColumnInfo")
        Me.fgrError.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fgrError.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid
        Me.fgrError.Location = New System.Drawing.Point(0, 0)
        Me.fgrError.Name = "fgrError"
        Me.fgrError.Rows.DefaultSize = 18
        Me.fgrError.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.fgrError.Size = New System.Drawing.Size(984, 626)
        Me.fgrError.TabIndex = 2
        '
        'tabpgReplace
        '
        Me.tabpgReplace.Controls.Add(Me.fgrReplace)
        Me.tabpgReplace.Controls.Add(Me.Panel1)
        Me.tabpgReplace.Location = New System.Drawing.Point(1, 23)
        Me.tabpgReplace.Name = "tabpgReplace"
        Me.tabpgReplace.Size = New System.Drawing.Size(984, 626)
        Me.tabpgReplace.TabIndex = 0
        Me.tabpgReplace.Text = "差し替え"
        '
        'fgrReplace
        '
        Me.fgrReplace.AllowFiltering = True
        Me.fgrReplace.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.fgrReplace.AutoResize = True
        Me.fgrReplace.ColumnInfo = resources.GetString("fgrReplace.ColumnInfo")
        Me.fgrReplace.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fgrReplace.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid
        Me.fgrReplace.Location = New System.Drawing.Point(0, 72)
        Me.fgrReplace.Name = "fgrReplace"
        Me.fgrReplace.Rows.DefaultSize = 18
        Me.fgrReplace.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.fgrReplace.Size = New System.Drawing.Size(984, 554)
        Me.fgrReplace.TabIndex = 18
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.txtReplace_SrcDir)
        Me.Panel1.Controls.Add(Me.txtReplace_DstDir)
        Me.Panel1.Controls.Add(Me.btnReplace)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(984, 72)
        Me.Panel1.TabIndex = 17
        '
        'tabpgAdd
        '
        Me.tabpgAdd.Controls.Add(Me.fgrAdd)
        Me.tabpgAdd.Controls.Add(Me.Panel2)
        Me.tabpgAdd.Location = New System.Drawing.Point(1, 23)
        Me.tabpgAdd.Name = "tabpgAdd"
        Me.tabpgAdd.Size = New System.Drawing.Size(984, 626)
        Me.tabpgAdd.TabIndex = 1
        Me.tabpgAdd.Text = "コマ抜け"
        '
        'fgrAdd
        '
        Me.fgrAdd.AllowFiltering = True
        Me.fgrAdd.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.fgrAdd.AutoResize = True
        Me.fgrAdd.ColumnInfo = resources.GetString("fgrAdd.ColumnInfo")
        Me.fgrAdd.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fgrAdd.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid
        Me.fgrAdd.Location = New System.Drawing.Point(0, 46)
        Me.fgrAdd.Name = "fgrAdd"
        Me.fgrAdd.Rows.DefaultSize = 18
        Me.fgrAdd.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.fgrAdd.Size = New System.Drawing.Size(984, 580)
        Me.fgrAdd.TabIndex = 20
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.txtAddDir)
        Me.Panel2.Controls.Add(Me.btnAdd)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(984, 46)
        Me.Panel2.TabIndex = 19
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(901, 12)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(75, 23)
        Me.btnAdd.TabIndex = 15
        Me.btnAdd.Text = "追加"
        Me.btnAdd.UseVisualStyleBackColor = True
        Me.btnAdd.VisualStyle = C1.Win.C1Input.VisualStyle.System
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(26, 19)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(94, 12)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "再スキャンフォルダ："
        '
        'tabpgRemove
        '
        Me.tabpgRemove.Controls.Add(Me.fgrRemove)
        Me.tabpgRemove.Controls.Add(Me.Panel3)
        Me.tabpgRemove.Location = New System.Drawing.Point(1, 23)
        Me.tabpgRemove.Name = "tabpgRemove"
        Me.tabpgRemove.Size = New System.Drawing.Size(984, 626)
        Me.tabpgRemove.TabIndex = 2
        Me.tabpgRemove.Text = "削除対象"
        '
        'fgrRemove
        '
        Me.fgrRemove.AllowFiltering = True
        Me.fgrRemove.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.fgrRemove.AutoResize = True
        Me.fgrRemove.ColumnInfo = resources.GetString("fgrRemove.ColumnInfo")
        Me.fgrRemove.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fgrRemove.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid
        Me.fgrRemove.Location = New System.Drawing.Point(0, 46)
        Me.fgrRemove.Name = "fgrRemove"
        Me.fgrRemove.Rows.DefaultSize = 18
        Me.fgrRemove.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.fgrRemove.Size = New System.Drawing.Size(984, 580)
        Me.fgrRemove.TabIndex = 20
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.txtRemoveDir)
        Me.Panel3.Controls.Add(Me.btnRemove)
        Me.Panel3.Controls.Add(Me.Label6)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(984, 46)
        Me.Panel3.TabIndex = 19
        '
        'btnRemove
        '
        Me.btnRemove.Location = New System.Drawing.Point(901, 12)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(75, 23)
        Me.btnRemove.TabIndex = 15
        Me.btnRemove.Text = "移動"
        Me.btnRemove.UseVisualStyleBackColor = True
        Me.btnRemove.VisualStyle = C1.Win.C1Input.VisualStyle.System
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(50, 19)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(70, 12)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "削除フォルダ："
        '
        'frmRecovery
        '
        Me.AllowDrop = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(992, 771)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.C1StatusBar1)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(1000, 800)
        Me.MinimumSize = New System.Drawing.Size(1000, 800)
        Me.Name = "frmRecovery"
        Me.Text = "リカバリー"
        Me.VisualStyleHolder = C1.Win.C1Ribbon.VisualStyle.Office2010Black
        CType(Me.C1StatusBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.btnSearchOption, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnOutput, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnSearch, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnReplace, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.tabResult, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabResult.ResumeLayout(False)
        Me.tabpgAll.ResumeLayout(False)
        CType(Me.fgrAll, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabpgError.ResumeLayout(False)
        CType(Me.fgrError, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabpgReplace.ResumeLayout(False)
        CType(Me.fgrReplace, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.tabpgAdd.ResumeLayout(False)
        CType(Me.fgrAdd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.btnAdd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabpgRemove.ResumeLayout(False)
        CType(Me.fgrRemove, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.btnRemove, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents C1StatusBar1 As C1.Win.C1Ribbon.C1StatusBar
    Friend WithEvents RibbonLabel3 As C1.Win.C1Ribbon.RibbonLabel
    Friend WithEvents txtFileCount As C1.Win.C1Ribbon.RibbonTextBox
    Friend WithEvents RibbonLabel4 As C1.Win.C1Ribbon.RibbonLabel
    Friend WithEvents pgbFiles As C1.Win.C1Ribbon.RibbonProgressBar
    Friend WithEvents txtProgress As C1.Win.C1Ribbon.RibbonLabel
    Friend WithEvents PrintDialog As PrintDialog
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btnSearch As C1.Win.C1Input.C1Button
    Friend WithEvents lblParentDir As Label
    Friend WithEvents txtParentDir As TextBox
    Friend WithEvents btnReplace As C1.Win.C1Input.C1Button
    Friend WithEvents Label5 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtReplace_DstDir As TextBox
    Friend WithEvents txtReplace_SrcDir As TextBox
    Friend WithEvents btnBackMenu As C1.Win.C1Ribbon.RibbonButton
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents RibbonSeparator21 As C1.Win.C1Ribbon.RibbonSeparator
    Friend WithEvents RibbonSeparator211 As C1.Win.C1Ribbon.RibbonSeparator
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents tabResult As C1.Win.C1Command.C1DockingTab
    Friend WithEvents tabpgReplace As C1.Win.C1Command.C1DockingTabPage
    Friend WithEvents tabpgAdd As C1.Win.C1Command.C1DockingTabPage
    Friend WithEvents tabpgRemove As C1.Win.C1Command.C1DockingTabPage
    Friend WithEvents tabpgError As C1.Win.C1Command.C1DockingTabPage
    Friend WithEvents btnOutput As C1.Win.C1Input.C1Button
    Friend WithEvents Label1 As Label
    Friend WithEvents txtResultDir As TextBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents txtAddDir As TextBox
    Friend WithEvents btnAdd As C1.Win.C1Input.C1Button
    Friend WithEvents Label4 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents txtRemoveDir As TextBox
    Friend WithEvents btnRemove As C1.Win.C1Input.C1Button
    Friend WithEvents Label6 As Label
    Friend WithEvents tabpgAll As C1.Win.C1Command.C1DockingTabPage
    Friend WithEvents fgrAll As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents fgrReplace As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents fgrAdd As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents fgrRemove As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents fgrError As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents btnSearchOption As C1.Win.C1Input.C1Button
End Class
