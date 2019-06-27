<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmScanLogChk
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmScanLogChk))
        Me.C1StatusBar1 = New C1.Win.C1Ribbon.C1StatusBar()
        Me.RibbonLabel2111 = New C1.Win.C1Ribbon.RibbonLabel()
        Me.txtFileCount = New C1.Win.C1Ribbon.RibbonTextBox()
        Me.RibbonLabel211 = New C1.Win.C1Ribbon.RibbonLabel()
        Me.txtcntWarnning = New C1.Win.C1Ribbon.RibbonTextBox()
        Me.RibbonLabel21 = New C1.Win.C1Ribbon.RibbonLabel()
        Me.txtremWarnning = New C1.Win.C1Ribbon.RibbonTextBox()
        Me.RibbonLabel4 = New C1.Win.C1Ribbon.RibbonLabel()
        Me.pgbFiles = New C1.Win.C1Ribbon.RibbonProgressBar()
        Me.txtProgress = New C1.Win.C1Ribbon.RibbonLabel()
        Me.RibbonSeparator211 = New C1.Win.C1Ribbon.RibbonSeparator()
        Me.btnBackMenu = New C1.Win.C1Ribbon.RibbonButton()
        Me.PrintDialog = New System.Windows.Forms.PrintDialog()
        Me.fgrFileList = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnInputFolderOpen = New C1.Win.C1Input.C1Button()
        Me.btnLogOutput = New C1.Win.C1Input.C1Button()
        Me.txtSrcPath = New System.Windows.Forms.TextBox()
        Me.btnStart = New C1.Win.C1Input.C1Button()
        Me.btnOutputFolderOpen = New C1.Win.C1Input.C1Button()
        Me.txtDstPath = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnOption = New C1.Win.C1Input.C1Button()
        Me.btnCancel = New C1.Win.C1Input.C1Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnRotate180 = New System.Windows.Forms.Button()
        Me.btnRotate270 = New System.Windows.Forms.Button()
        Me.btnRotate90 = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.nudQuality = New System.Windows.Forms.NumericUpDown()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.nudThumRow = New System.Windows.Forms.NumericUpDown()
        Me.nudThumCol = New System.Windows.Forms.NumericUpDown()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.fgrThumbnail = New C1.Win.C1FlexGrid.C1FlexGrid()
        CType(Me.C1StatusBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.fgrFileList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.btnInputFolderOpen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnLogOutput, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnStart, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnOutputFolderOpen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnOption, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnCancel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.nudQuality, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.nudThumRow, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudThumCol, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.fgrThumbnail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'C1StatusBar1
        '
        Me.C1StatusBar1.AutoSizeElement = C1.Framework.AutoSizeElement.Width
        Me.C1StatusBar1.LeftPaneItems.Add(Me.RibbonLabel2111)
        Me.C1StatusBar1.LeftPaneItems.Add(Me.txtFileCount)
        Me.C1StatusBar1.LeftPaneItems.Add(Me.RibbonLabel211)
        Me.C1StatusBar1.LeftPaneItems.Add(Me.txtcntWarnning)
        Me.C1StatusBar1.LeftPaneItems.Add(Me.RibbonLabel21)
        Me.C1StatusBar1.LeftPaneItems.Add(Me.txtremWarnning)
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
        'RibbonLabel2111
        '
        Me.RibbonLabel2111.Name = "RibbonLabel2111"
        Me.RibbonLabel2111.Text = "件数："
        '
        'txtFileCount
        '
        Me.txtFileCount.Enabled = False
        Me.txtFileCount.Name = "txtFileCount"
        Me.txtFileCount.Text = "0"
        '
        'RibbonLabel211
        '
        Me.RibbonLabel211.Name = "RibbonLabel211"
        Me.RibbonLabel211.Text = "ワーニング件数："
        '
        'txtcntWarnning
        '
        Me.txtcntWarnning.Enabled = False
        Me.txtcntWarnning.Name = "txtcntWarnning"
        Me.txtcntWarnning.Text = "0"
        '
        'RibbonLabel21
        '
        Me.RibbonLabel21.Name = "RibbonLabel21"
        Me.RibbonLabel21.Text = "残留ワーニング件数："
        '
        'txtremWarnning
        '
        Me.txtremWarnning.Enabled = False
        Me.txtremWarnning.Name = "txtremWarnning"
        Me.txtremWarnning.Text = "0"
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
        Me.pgbFiles.Width = 350
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
        'fgrFileList
        '
        Me.fgrFileList.AllowFiltering = True
        Me.fgrFileList.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.fgrFileList.AutoResize = True
        Me.fgrFileList.ColumnInfo = resources.GetString("fgrFileList.ColumnInfo")
        Me.fgrFileList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fgrFileList.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid
        Me.fgrFileList.Location = New System.Drawing.Point(0, 49)
        Me.fgrFileList.Name = "fgrFileList"
        Me.fgrFileList.Rows.DefaultSize = 18
        Me.fgrFileList.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.fgrFileList.Size = New System.Drawing.Size(583, 614)
        Me.fgrFileList.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.TableLayoutPanel1)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox2.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(992, 82)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "参照"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 6
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Label4, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.btnInputFolderOpen, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnLogOutput, 4, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.txtSrcPath, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnStart, 4, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnOutputFolderOpen, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.txtDstPath, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label3, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnOption, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnCancel, 5, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 15)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(986, 64)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label4.Location = New System.Drawing.Point(3, 32)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(94, 32)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "ログフォルダ："
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnInputFolderOpen
        '
        Me.btnInputFolderOpen.Font = New System.Drawing.Font("MS UI Gothic", 10.0!)
        Me.btnInputFolderOpen.Location = New System.Drawing.Point(669, 3)
        Me.btnInputFolderOpen.Name = "btnInputFolderOpen"
        Me.btnInputFolderOpen.Size = New System.Drawing.Size(54, 26)
        Me.btnInputFolderOpen.TabIndex = 3
        Me.btnInputFolderOpen.TabStop = False
        Me.btnInputFolderOpen.Text = "..."
        Me.btnInputFolderOpen.UseVisualStyleBackColor = True
        Me.btnInputFolderOpen.VisualStyle = C1.Win.C1Input.VisualStyle.System
        '
        'btnLogOutput
        '
        Me.btnLogOutput.Location = New System.Drawing.Point(789, 35)
        Me.btnLogOutput.Name = "btnLogOutput"
        Me.btnLogOutput.Size = New System.Drawing.Size(94, 26)
        Me.btnLogOutput.TabIndex = 7
        Me.btnLogOutput.TabStop = False
        Me.btnLogOutput.Text = "出力"
        Me.btnLogOutput.UseVisualStyleBackColor = True
        Me.btnLogOutput.VisualStyle = C1.Win.C1Input.VisualStyle.System
        '
        'txtSrcPath
        '
        Me.txtSrcPath.AllowDrop = True
        Me.txtSrcPath.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtSrcPath.Font = New System.Drawing.Font("MS UI Gothic", 13.0!)
        Me.txtSrcPath.Location = New System.Drawing.Point(103, 3)
        Me.txtSrcPath.Name = "txtSrcPath"
        Me.txtSrcPath.Size = New System.Drawing.Size(560, 25)
        Me.txtSrcPath.TabIndex = 1
        Me.txtSrcPath.TabStop = False
        Me.ToolTip1.SetToolTip(Me.txtSrcPath, "変換元のフォルダをドラッグ＆ドロップしてください。")
        '
        'btnStart
        '
        Me.btnStart.Location = New System.Drawing.Point(789, 3)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(94, 26)
        Me.btnStart.TabIndex = 6
        Me.btnStart.TabStop = False
        Me.btnStart.Text = "開始"
        Me.btnStart.UseVisualStyleBackColor = True
        Me.btnStart.VisualStyle = C1.Win.C1Input.VisualStyle.System
        '
        'btnOutputFolderOpen
        '
        Me.btnOutputFolderOpen.Font = New System.Drawing.Font("MS UI Gothic", 10.0!)
        Me.btnOutputFolderOpen.Location = New System.Drawing.Point(669, 35)
        Me.btnOutputFolderOpen.Name = "btnOutputFolderOpen"
        Me.btnOutputFolderOpen.Size = New System.Drawing.Size(54, 26)
        Me.btnOutputFolderOpen.TabIndex = 4
        Me.btnOutputFolderOpen.TabStop = False
        Me.btnOutputFolderOpen.Text = "..."
        Me.btnOutputFolderOpen.UseVisualStyleBackColor = True
        Me.btnOutputFolderOpen.VisualStyle = C1.Win.C1Input.VisualStyle.System
        '
        'txtDstPath
        '
        Me.txtDstPath.AllowDrop = True
        Me.txtDstPath.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtDstPath.Font = New System.Drawing.Font("MS UI Gothic", 13.0!)
        Me.txtDstPath.Location = New System.Drawing.Point(103, 35)
        Me.txtDstPath.Name = "txtDstPath"
        Me.txtDstPath.Size = New System.Drawing.Size(560, 25)
        Me.txtDstPath.TabIndex = 2
        Me.txtDstPath.TabStop = False
        Me.ToolTip1.SetToolTip(Me.txtDstPath, "変換先のフォルダをドラッグ＆ドロップしてください。")
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label3.Location = New System.Drawing.Point(3, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(94, 32)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "スキャンフォルダ："
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnOption
        '
        Me.btnOption.Font = New System.Drawing.Font("MS UI Gothic", 9.0!)
        Me.btnOption.Location = New System.Drawing.Point(729, 3)
        Me.btnOption.Name = "btnOption"
        Me.btnOption.Size = New System.Drawing.Size(54, 26)
        Me.btnOption.TabIndex = 5
        Me.btnOption.TabStop = False
        Me.btnOption.Text = "設定"
        Me.btnOption.UseVisualStyleBackColor = True
        Me.btnOption.VisualStyle = C1.Win.C1Input.VisualStyle.System
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(889, 3)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(94, 26)
        Me.btnCancel.TabIndex = 6
        Me.btnCancel.TabStop = False
        Me.btnCancel.Text = "キャンセル"
        Me.btnCancel.UseVisualStyleBackColor = True
        Me.btnCancel.VisualStyle = C1.Win.C1Input.VisualStyle.System
        '
        'ToolTip1
        '
        Me.ToolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(992, 85)
        Me.Panel1.TabIndex = 19
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 5
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.btnRotate180, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.btnRotate270, 3, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.btnRotate90, 4, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Panel2, 1, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(583, 49)
        Me.TableLayoutPanel2.TabIndex = 21
        '
        'btnRotate180
        '
        Me.btnRotate180.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnRotate180.Image = CType(resources.GetObject("btnRotate180.Image"), System.Drawing.Image)
        Me.btnRotate180.Location = New System.Drawing.Point(436, 3)
        Me.btnRotate180.Name = "btnRotate180"
        Me.btnRotate180.Size = New System.Drawing.Size(44, 43)
        Me.btnRotate180.TabIndex = 8
        Me.btnRotate180.TabStop = False
        Me.btnRotate180.UseVisualStyleBackColor = True
        '
        'btnRotate270
        '
        Me.btnRotate270.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnRotate270.Image = CType(resources.GetObject("btnRotate270.Image"), System.Drawing.Image)
        Me.btnRotate270.Location = New System.Drawing.Point(486, 3)
        Me.btnRotate270.Name = "btnRotate270"
        Me.btnRotate270.Size = New System.Drawing.Size(44, 43)
        Me.btnRotate270.TabIndex = 9
        Me.btnRotate270.TabStop = False
        Me.btnRotate270.UseVisualStyleBackColor = True
        '
        'btnRotate90
        '
        Me.btnRotate90.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnRotate90.Image = CType(resources.GetObject("btnRotate90.Image"), System.Drawing.Image)
        Me.btnRotate90.Location = New System.Drawing.Point(536, 3)
        Me.btnRotate90.Name = "btnRotate90"
        Me.btnRotate90.Size = New System.Drawing.Size(44, 43)
        Me.btnRotate90.TabIndex = 10
        Me.btnRotate90.TabStop = False
        Me.btnRotate90.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.nudQuality)
        Me.Panel2.Location = New System.Drawing.Point(316, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(114, 43)
        Me.Panel2.TabIndex = 12
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(2, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 12)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "保存品質："
        '
        'nudQuality
        '
        Me.nudQuality.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.nudQuality.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.nudQuality.Location = New System.Drawing.Point(67, 10)
        Me.nudQuality.Name = "nudQuality"
        Me.nudQuality.Size = New System.Drawing.Size(44, 23)
        Me.nudQuality.TabIndex = 13
        Me.nudQuality.TabStop = False
        Me.nudQuality.Value = New Decimal(New Integer() {85, 0, 0, 0})
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.nudThumRow)
        Me.GroupBox3.Controls.Add(Me.nudThumCol)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox3.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(405, 49)
        Me.GroupBox3.TabIndex = 20
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "ビューア設定"
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(140, 20)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(84, 12)
        Me.Label5.TabIndex = 19
        Me.Label5.Text = "サムネイル行数："
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(84, 12)
        Me.Label2.TabIndex = 19
        Me.Label2.Text = "サムネイル列数："
        '
        'nudThumRow
        '
        Me.nudThumRow.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.nudThumRow.Font = New System.Drawing.Font("MS UI Gothic", 12.0!)
        Me.nudThumRow.Location = New System.Drawing.Point(230, 14)
        Me.nudThumRow.Maximum = New Decimal(New Integer() {6, 0, 0, 0})
        Me.nudThumRow.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudThumRow.Name = "nudThumRow"
        Me.nudThumRow.Size = New System.Drawing.Size(38, 23)
        Me.nudThumRow.TabIndex = 12
        Me.nudThumRow.TabStop = False
        Me.nudThumRow.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'nudThumCol
        '
        Me.nudThumCol.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.nudThumCol.Font = New System.Drawing.Font("MS UI Gothic", 12.0!)
        Me.nudThumCol.Location = New System.Drawing.Point(96, 14)
        Me.nudThumCol.Maximum = New Decimal(New Integer() {6, 0, 0, 0})
        Me.nudThumCol.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudThumCol.Name = "nudThumCol"
        Me.nudThumCol.Size = New System.Drawing.Size(38, 23)
        Me.nudThumCol.TabIndex = 11
        Me.nudThumCol.TabStop = False
        Me.nudThumCol.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 85)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.fgrFileList)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TableLayoutPanel2)
        Me.SplitContainer1.Panel1MinSize = 580
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.fgrThumbnail)
        Me.SplitContainer1.Panel2.Controls.Add(Me.GroupBox3)
        Me.SplitContainer1.Panel2MinSize = 400
        Me.SplitContainer1.Size = New System.Drawing.Size(992, 663)
        Me.SplitContainer1.SplitterDistance = 583
        Me.SplitContainer1.TabIndex = 21
        '
        'fgrThumbnail
        '
        Me.fgrThumbnail.BackColor = System.Drawing.Color.Silver
        Me.fgrThumbnail.ColumnInfo = "1,0,0,200,200,90,Columns:0{AllowSorting:False;AllowDragging:False;AllowResizing:F" &
    "alse;AllowEditing:False;}" & Global.Microsoft.VisualBasic.ChrW(9)
        Me.fgrThumbnail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fgrThumbnail.Location = New System.Drawing.Point(0, 49)
        Me.fgrThumbnail.Name = "fgrThumbnail"
        Me.fgrThumbnail.Rows.Count = 3
        Me.fgrThumbnail.Rows.DefaultSize = 18
        Me.fgrThumbnail.Rows.Fixed = 0
        Me.fgrThumbnail.Rows.MaxSize = 192
        Me.fgrThumbnail.Rows.MinSize = 192
        Me.fgrThumbnail.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.fgrThumbnail.Size = New System.Drawing.Size(405, 614)
        Me.fgrThumbnail.StyleInfo = resources.GetString("fgrThumbnail.StyleInfo")
        Me.fgrThumbnail.TabIndex = 14
        Me.fgrThumbnail.TabStop = False
        '
        'frmScanLogChk
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(992, 771)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.C1StatusBar1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MinimumSize = New System.Drawing.Size(1000, 800)
        Me.Name = "frmScanLogChk"
        Me.Text = "スキャンログ検査"
        Me.VisualStyleHolder = C1.Win.C1Ribbon.VisualStyle.Office2010Black
        CType(Me.C1StatusBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.fgrFileList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.btnInputFolderOpen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnLogOutput, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnStart, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnOutputFolderOpen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnOption, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnCancel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.nudQuality, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.nudThumRow, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudThumCol, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.fgrThumbnail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents C1StatusBar1 As C1.Win.C1Ribbon.C1StatusBar
    Friend WithEvents RibbonLabel4 As C1.Win.C1Ribbon.RibbonLabel
    Friend WithEvents pgbFiles As C1.Win.C1Ribbon.RibbonProgressBar
    Friend WithEvents txtProgress As C1.Win.C1Ribbon.RibbonLabel
    Friend WithEvents PrintDialog As PrintDialog
    Friend WithEvents fgrFileList As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtSrcPath As TextBox
    Friend WithEvents txtDstPath As TextBox
    Friend WithEvents btnBackMenu As C1.Win.C1Ribbon.RibbonButton
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents RibbonLabel21 As C1.Win.C1Ribbon.RibbonLabel
    Friend WithEvents RibbonSeparator211 As C1.Win.C1Ribbon.RibbonSeparator
    Friend WithEvents btnStart As C1.Win.C1Input.C1Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents txtremWarnning As C1.Win.C1Ribbon.RibbonTextBox
    Friend WithEvents RibbonLabel2111 As C1.Win.C1Ribbon.RibbonLabel
    Friend WithEvents txtFileCount As C1.Win.C1Ribbon.RibbonTextBox
    Friend WithEvents RibbonLabel211 As C1.Win.C1Ribbon.RibbonLabel
    Friend WithEvents txtcntWarnning As C1.Win.C1Ribbon.RibbonTextBox
    Friend WithEvents btnLogOutput As C1.Win.C1Input.C1Button
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents fgrThumbnail As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents btnInputFolderOpen As C1.Win.C1Input.C1Button
    Friend WithEvents btnOutputFolderOpen As C1.Win.C1Input.C1Button
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Label5 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents nudThumRow As NumericUpDown
    Friend WithEvents nudThumCol As NumericUpDown
    Friend WithEvents btnOption As C1.Win.C1Input.C1Button
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents btnRotate180 As Button
    Friend WithEvents btnRotate270 As Button
    Friend WithEvents btnRotate90 As Button
    Friend WithEvents btnCancel As C1.Win.C1Input.C1Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents nudQuality As NumericUpDown
End Class
