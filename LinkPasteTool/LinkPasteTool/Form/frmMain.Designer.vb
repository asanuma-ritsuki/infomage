<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMain
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ファイルFToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolReference = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolBack = New System.Windows.Forms.ToolStripMenuItem()
        Me.移動MToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolTop = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolPrev = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolNext = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolBottom = New System.Windows.Forms.ToolStripMenuItem()
        Me.表示VToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolReduction = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolMagnification = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolFit = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolRotateLeft = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolRotateRight = New System.Windows.Forms.ToolStripMenuItem()
        Me.編集EToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolInsert = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolDelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolAdd = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolSetLink = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolDelLink = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolSetLinkTo = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolDelLinkTo = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolEdit = New System.Windows.Forms.ToolStripMenuItem()
        Me.管理MToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolManage = New System.Windows.Forms.ToolStripMenuItem()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.C1FGridFlag = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.C1FGridResult = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbPrefecture = New System.Windows.Forms.ComboBox()
        Me.lblLinkProcess = New System.Windows.Forms.Label()
        Me.btnAbort = New System.Windows.Forms.Button()
        Me.btnFinish = New System.Windows.Forms.Button()
        Me.btnStart = New System.Windows.Forms.Button()
        Me.cmbBookletID = New System.Windows.Forms.ComboBox()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.rivImage = New Leadtools.WinForms.RasterImageViewer()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.txtRemarks = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.C1FGridDoc = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.C1FGridFlag, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.C1FGridResult, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.C1FGridDoc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ファイルFToolStripMenuItem, Me.移動MToolStripMenuItem, Me.表示VToolStripMenuItem, Me.編集EToolStripMenuItem, Me.管理MToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1008, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ファイルFToolStripMenuItem
        '
        Me.ファイルFToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolReference, Me.toolBack})
        Me.ファイルFToolStripMenuItem.Name = "ファイルFToolStripMenuItem"
        Me.ファイルFToolStripMenuItem.Size = New System.Drawing.Size(66, 20)
        Me.ファイルFToolStripMenuItem.Text = "ファイル(&F)"
        '
        'toolReference
        '
        Me.toolReference.Image = Global.LinkPasteTool.My.Resources.Resources.wrench
        Me.toolReference.Name = "toolReference"
        Me.toolReference.Size = New System.Drawing.Size(133, 22)
        Me.toolReference.Text = "参照フォルダ"
        '
        'toolBack
        '
        Me.toolBack.Image = Global.LinkPasteTool.My.Resources.Resources.Back
        Me.toolBack.Name = "toolBack"
        Me.toolBack.Size = New System.Drawing.Size(133, 22)
        Me.toolBack.Text = "終了(&X)"
        '
        '移動MToolStripMenuItem
        '
        Me.移動MToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolTop, Me.toolPrev, Me.toolNext, Me.toolBottom})
        Me.移動MToolStripMenuItem.Name = "移動MToolStripMenuItem"
        Me.移動MToolStripMenuItem.Size = New System.Drawing.Size(62, 20)
        Me.移動MToolStripMenuItem.Text = "移動(&M)"
        '
        'toolTop
        '
        Me.toolTop.Image = Global.LinkPasteTool.My.Resources.Resources.actions_go_first_3_22x22
        Me.toolTop.Name = "toolTop"
        Me.toolTop.Size = New System.Drawing.Size(129, 22)
        Me.toolTop.Text = "先頭画像"
        '
        'toolPrev
        '
        Me.toolPrev.Image = Global.LinkPasteTool.My.Resources.Resources.actions_go_previous_5_22x22
        Me.toolPrev.Name = "toolPrev"
        Me.toolPrev.ShortcutKeys = System.Windows.Forms.Keys.F1
        Me.toolPrev.Size = New System.Drawing.Size(129, 22)
        Me.toolPrev.Text = "前画像"
        '
        'toolNext
        '
        Me.toolNext.Image = Global.LinkPasteTool.My.Resources.Resources.actions_go_next_5_22x22
        Me.toolNext.Name = "toolNext"
        Me.toolNext.ShortcutKeys = System.Windows.Forms.Keys.F2
        Me.toolNext.Size = New System.Drawing.Size(129, 22)
        Me.toolNext.Text = "次画像"
        '
        'toolBottom
        '
        Me.toolBottom.Image = Global.LinkPasteTool.My.Resources.Resources.actions_go_last_3_22x22
        Me.toolBottom.Name = "toolBottom"
        Me.toolBottom.Size = New System.Drawing.Size(129, 22)
        Me.toolBottom.Text = "最終画像"
        '
        '表示VToolStripMenuItem
        '
        Me.表示VToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolReduction, Me.toolMagnification, Me.toolFit, Me.ToolStripSeparator3, Me.toolRotateLeft, Me.toolRotateRight})
        Me.表示VToolStripMenuItem.Name = "表示VToolStripMenuItem"
        Me.表示VToolStripMenuItem.Size = New System.Drawing.Size(58, 20)
        Me.表示VToolStripMenuItem.Text = "表示(&V)"
        '
        'toolReduction
        '
        Me.toolReduction.Image = Global.LinkPasteTool.My.Resources.Resources.ZoomOut
        Me.toolReduction.Name = "toolReduction"
        Me.toolReduction.ShortcutKeyDisplayString = "Ctrl+[-]"
        Me.toolReduction.Size = New System.Drawing.Size(147, 22)
        Me.toolReduction.Text = "縮小"
        '
        'toolMagnification
        '
        Me.toolMagnification.Image = Global.LinkPasteTool.My.Resources.Resources.ZoomIn
        Me.toolMagnification.Name = "toolMagnification"
        Me.toolMagnification.ShortcutKeyDisplayString = "Ctrl+[+]"
        Me.toolMagnification.Size = New System.Drawing.Size(147, 22)
        Me.toolMagnification.Text = "拡大"
        '
        'toolFit
        '
        Me.toolFit.Image = Global.LinkPasteTool.My.Resources.Resources.Zoom
        Me.toolFit.Name = "toolFit"
        Me.toolFit.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F), System.Windows.Forms.Keys)
        Me.toolFit.Size = New System.Drawing.Size(147, 22)
        Me.toolFit.Text = "フィット"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(144, 6)
        '
        'toolRotateLeft
        '
        Me.toolRotateLeft.Enabled = False
        Me.toolRotateLeft.Image = Global.LinkPasteTool.My.Resources.Resources.arrow_rotate_anticlockwise
        Me.toolRotateLeft.Name = "toolRotateLeft"
        Me.toolRotateLeft.Size = New System.Drawing.Size(147, 22)
        Me.toolRotateLeft.Text = "左回転"
        '
        'toolRotateRight
        '
        Me.toolRotateRight.Enabled = False
        Me.toolRotateRight.Image = Global.LinkPasteTool.My.Resources.Resources.arrow_rotate_clockwise
        Me.toolRotateRight.Name = "toolRotateRight"
        Me.toolRotateRight.Size = New System.Drawing.Size(147, 22)
        Me.toolRotateRight.Text = "右回転"
        '
        '編集EToolStripMenuItem
        '
        Me.編集EToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolInsert, Me.toolDelete, Me.toolAdd, Me.ToolStripSeparator1, Me.toolSetLink, Me.toolDelLink, Me.ToolStripSeparator4, Me.toolSetLinkTo, Me.toolDelLinkTo, Me.ToolStripSeparator2, Me.toolEdit})
        Me.編集EToolStripMenuItem.Name = "編集EToolStripMenuItem"
        Me.編集EToolStripMenuItem.Size = New System.Drawing.Size(57, 20)
        Me.編集EToolStripMenuItem.Text = "編集(&E)"
        '
        'toolInsert
        '
        Me.toolInsert.Image = Global.LinkPasteTool.My.Resources.Resources.table_row_insert
        Me.toolInsert.Name = "toolInsert"
        Me.toolInsert.ShortcutKeys = CType((System.Windows.Forms.Keys.Shift Or System.Windows.Forms.Keys.Insert), System.Windows.Forms.Keys)
        Me.toolInsert.Size = New System.Drawing.Size(177, 22)
        Me.toolInsert.Text = "行の挿入"
        '
        'toolDelete
        '
        Me.toolDelete.Enabled = False
        Me.toolDelete.Image = Global.LinkPasteTool.My.Resources.Resources.table_row_delete
        Me.toolDelete.Name = "toolDelete"
        Me.toolDelete.Size = New System.Drawing.Size(177, 22)
        Me.toolDelete.Text = "行の削除"
        '
        'toolAdd
        '
        Me.toolAdd.Image = Global.LinkPasteTool.My.Resources.Resources.table_lightning
        Me.toolAdd.Name = "toolAdd"
        Me.toolAdd.ShortcutKeys = CType((System.Windows.Forms.Keys.Shift Or System.Windows.Forms.Keys.F12), System.Windows.Forms.Keys)
        Me.toolAdd.Size = New System.Drawing.Size(177, 22)
        Me.toolAdd.Text = "行の追加"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(174, 6)
        '
        'toolSetLink
        '
        Me.toolSetLink.Image = Global.LinkPasteTool.My.Resources.Resources.link_add
        Me.toolSetLink.Name = "toolSetLink"
        Me.toolSetLink.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.toolSetLink.Size = New System.Drawing.Size(177, 22)
        Me.toolSetLink.Text = "リンクFROM設定"
        '
        'toolDelLink
        '
        Me.toolDelLink.Image = Global.LinkPasteTool.My.Resources.Resources.link_delete
        Me.toolDelLink.Name = "toolDelLink"
        Me.toolDelLink.ShortcutKeys = System.Windows.Forms.Keys.F6
        Me.toolDelLink.Size = New System.Drawing.Size(177, 22)
        Me.toolDelLink.Text = "リンクFROM削除"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(174, 6)
        '
        'toolSetLinkTo
        '
        Me.toolSetLinkTo.Image = Global.LinkPasteTool.My.Resources.Resources.link_go
        Me.toolSetLinkTo.Name = "toolSetLinkTo"
        Me.toolSetLinkTo.ShortcutKeys = System.Windows.Forms.Keys.F9
        Me.toolSetLinkTo.Size = New System.Drawing.Size(177, 22)
        Me.toolSetLinkTo.Text = "リンクTO設定"
        '
        'toolDelLinkTo
        '
        Me.toolDelLinkTo.Image = Global.LinkPasteTool.My.Resources.Resources.link_break
        Me.toolDelLinkTo.Name = "toolDelLinkTo"
        Me.toolDelLinkTo.ShortcutKeys = System.Windows.Forms.Keys.F10
        Me.toolDelLinkTo.Size = New System.Drawing.Size(177, 22)
        Me.toolDelLinkTo.Text = "リンクTO削除"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(174, 6)
        '
        'toolEdit
        '
        Me.toolEdit.Enabled = False
        Me.toolEdit.Image = Global.LinkPasteTool.My.Resources.Resources.table_edit
        Me.toolEdit.Name = "toolEdit"
        Me.toolEdit.Size = New System.Drawing.Size(177, 22)
        Me.toolEdit.Text = "修正"
        '
        '管理MToolStripMenuItem
        '
        Me.管理MToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolManage})
        Me.管理MToolStripMenuItem.Name = "管理MToolStripMenuItem"
        Me.管理MToolStripMenuItem.Size = New System.Drawing.Size(62, 20)
        Me.管理MToolStripMenuItem.Text = "管理(&M)"
        '
        'toolManage
        '
        Me.toolManage.Image = Global.LinkPasteTool.My.Resources.Resources.account_functions
        Me.toolManage.Name = "toolManage"
        Me.toolManage.Size = New System.Drawing.Size(152, 22)
        Me.toolManage.Text = "管理画面"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 24)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox4)
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox3)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Panel1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.SplitContainer2)
        Me.SplitContainer1.Size = New System.Drawing.Size(1008, 683)
        Me.SplitContainer1.SplitterDistance = 260
        Me.SplitContainer1.TabIndex = 2
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.C1FGridFlag)
        Me.GroupBox4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox4.Location = New System.Drawing.Point(0, 445)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(260, 238)
        Me.GroupBox4.TabIndex = 3
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "フラグ情報"
        '
        'C1FGridFlag
        '
        Me.C1FGridFlag.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.C1FGridFlag.AllowEditing = False
        Me.C1FGridFlag.ColumnInfo = resources.GetString("C1FGridFlag.ColumnInfo")
        Me.C1FGridFlag.Dock = System.Windows.Forms.DockStyle.Fill
        Me.C1FGridFlag.ExtendLastCol = True
        Me.C1FGridFlag.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid
        Me.C1FGridFlag.Font = New System.Drawing.Font("Meiryo UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.C1FGridFlag.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcrossOut
        Me.C1FGridFlag.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcrossOut
        Me.C1FGridFlag.Location = New System.Drawing.Point(3, 20)
        Me.C1FGridFlag.Name = "C1FGridFlag"
        Me.C1FGridFlag.Rows.Count = 1
        Me.C1FGridFlag.Rows.DefaultSize = 20
        Me.C1FGridFlag.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.C1FGridFlag.Size = New System.Drawing.Size(254, 215)
        Me.C1FGridFlag.TabIndex = 1
        Me.C1FGridFlag.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.System
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.C1FGridResult)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox3.Location = New System.Drawing.Point(0, 118)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(260, 565)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "ファイル情報"
        '
        'C1FGridResult
        '
        Me.C1FGridResult.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.C1FGridResult.AllowEditing = False
        Me.C1FGridResult.ColumnInfo = resources.GetString("C1FGridResult.ColumnInfo")
        Me.C1FGridResult.Dock = System.Windows.Forms.DockStyle.Fill
        Me.C1FGridResult.ExtendLastCol = True
        Me.C1FGridResult.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid
        Me.C1FGridResult.Font = New System.Drawing.Font("Meiryo UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.C1FGridResult.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcrossOut
        Me.C1FGridResult.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcrossOut
        Me.C1FGridResult.Location = New System.Drawing.Point(3, 20)
        Me.C1FGridResult.Name = "C1FGridResult"
        Me.C1FGridResult.Rows.Count = 1
        Me.C1FGridResult.Rows.DefaultSize = 20
        Me.C1FGridResult.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.C1FGridResult.Size = New System.Drawing.Size(254, 542)
        Me.C1FGridResult.TabIndex = 0
        Me.C1FGridResult.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.System
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(260, 118)
        Me.Panel1.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cmbPrefecture)
        Me.GroupBox1.Controls.Add(Me.lblLinkProcess)
        Me.GroupBox1.Controls.Add(Me.btnAbort)
        Me.GroupBox1.Controls.Add(Me.btnFinish)
        Me.GroupBox1.Controls.Add(Me.btnStart)
        Me.GroupBox1.Controls.Add(Me.cmbBookletID)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(260, 118)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "フォルダ選択"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(6, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 25)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "県名："
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbPrefecture
        '
        Me.cmbPrefecture.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPrefecture.FormattingEnabled = True
        Me.cmbPrefecture.Location = New System.Drawing.Point(73, 23)
        Me.cmbPrefecture.Name = "cmbPrefecture"
        Me.cmbPrefecture.Size = New System.Drawing.Size(121, 25)
        Me.cmbPrefecture.TabIndex = 10
        '
        'lblLinkProcess
        '
        Me.lblLinkProcess.BackColor = System.Drawing.Color.LightCoral
        Me.lblLinkProcess.Font = New System.Drawing.Font("Meiryo UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblLinkProcess.Location = New System.Drawing.Point(200, 23)
        Me.lblLinkProcess.Name = "lblLinkProcess"
        Me.lblLinkProcess.Size = New System.Drawing.Size(49, 25)
        Me.lblLinkProcess.TabIndex = 9
        Me.lblLinkProcess.Text = "1次"
        Me.lblLinkProcess.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnAbort
        '
        Me.btnAbort.Location = New System.Drawing.Point(93, 85)
        Me.btnAbort.Name = "btnAbort"
        Me.btnAbort.Size = New System.Drawing.Size(75, 25)
        Me.btnAbort.TabIndex = 8
        Me.btnAbort.Text = "中　断"
        Me.btnAbort.UseVisualStyleBackColor = True
        '
        'btnFinish
        '
        Me.btnFinish.Location = New System.Drawing.Point(174, 85)
        Me.btnFinish.Name = "btnFinish"
        Me.btnFinish.Size = New System.Drawing.Size(75, 25)
        Me.btnFinish.TabIndex = 7
        Me.btnFinish.Text = "完　了"
        Me.btnFinish.UseVisualStyleBackColor = True
        '
        'btnStart
        '
        Me.btnStart.Location = New System.Drawing.Point(12, 85)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(75, 25)
        Me.btnStart.TabIndex = 6
        Me.btnStart.Text = "開　始"
        Me.btnStart.UseVisualStyleBackColor = True
        '
        'cmbBookletID
        '
        Me.cmbBookletID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBookletID.FormattingEnabled = True
        Me.cmbBookletID.Location = New System.Drawing.Point(12, 54)
        Me.cmbBookletID.Name = "cmbBookletID"
        Me.cmbBookletID.Size = New System.Drawing.Size(182, 25)
        Me.cmbBookletID.TabIndex = 5
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.GroupBox6)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.GroupBox5)
        Me.SplitContainer2.Panel2.Controls.Add(Me.GroupBox2)
        Me.SplitContainer2.Size = New System.Drawing.Size(744, 683)
        Me.SplitContainer2.SplitterDistance = 450
        Me.SplitContainer2.TabIndex = 0
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.rivImage)
        Me.GroupBox6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox6.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(450, 683)
        Me.GroupBox6.TabIndex = 2
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "画像部"
        '
        'rivImage
        '
        Me.rivImage.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.rivImage.Cursor = System.Windows.Forms.Cursors.Default
        Me.rivImage.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rivImage.InteractiveMode = Leadtools.WinForms.RasterViewerInteractiveMode.ZoomTo
        Me.rivImage.Location = New System.Drawing.Point(3, 20)
        Me.rivImage.Name = "rivImage"
        Me.rivImage.Size = New System.Drawing.Size(444, 660)
        Me.rivImage.SizeMode = Leadtools.RasterPaintSizeMode.Fit
        Me.rivImage.TabIndex = 0
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.txtRemarks)
        Me.GroupBox5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox5.Location = New System.Drawing.Point(0, 420)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(290, 263)
        Me.GroupBox5.TabIndex = 1
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "備考"
        '
        'txtRemarks
        '
        Me.txtRemarks.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtRemarks.Location = New System.Drawing.Point(3, 20)
        Me.txtRemarks.Multiline = True
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(284, 240)
        Me.txtRemarks.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.C1FGridDoc)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox2.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(290, 420)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "資料情報"
        '
        'C1FGridDoc
        '
        Me.C1FGridDoc.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.C1FGridDoc.AllowEditing = False
        Me.C1FGridDoc.ColumnInfo = resources.GetString("C1FGridDoc.ColumnInfo")
        Me.C1FGridDoc.Dock = System.Windows.Forms.DockStyle.Fill
        Me.C1FGridDoc.ExtendLastCol = True
        Me.C1FGridDoc.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid
        Me.C1FGridDoc.Font = New System.Drawing.Font("Meiryo UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.C1FGridDoc.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcrossOut
        Me.C1FGridDoc.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcrossOut
        Me.C1FGridDoc.Location = New System.Drawing.Point(3, 20)
        Me.C1FGridDoc.Name = "C1FGridDoc"
        Me.C1FGridDoc.Rows.Count = 1
        Me.C1FGridDoc.Rows.DefaultSize = 20
        Me.C1FGridDoc.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.C1FGridDoc.Size = New System.Drawing.Size(284, 397)
        Me.C1FGridDoc.TabIndex = 2
        Me.C1FGridDoc.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.System
        '
        'frmMain
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.CaptionDisplayMode = LinkPasteTool.frmTempForm.StatusDisplayMode.ShowAll
        Me.ClientSize = New System.Drawing.Size(1008, 729)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.KeyPreview = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "frmMain"
        Me.Text = "frmMain"
        Me.Controls.SetChildIndex(Me.MenuStrip1, 0)
        Me.Controls.SetChildIndex(Me.SplitContainer1, 0)
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.C1FGridFlag, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.C1FGridResult, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.C1FGridDoc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents ファイルFToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents toolReference As ToolStripMenuItem
    Friend WithEvents toolBack As ToolStripMenuItem
    Friend WithEvents 移動MToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents toolTop As ToolStripMenuItem
    Friend WithEvents toolPrev As ToolStripMenuItem
    Friend WithEvents toolNext As ToolStripMenuItem
    Friend WithEvents toolBottom As ToolStripMenuItem
    Friend WithEvents 表示VToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents toolReduction As ToolStripMenuItem
    Friend WithEvents toolMagnification As ToolStripMenuItem
    Friend WithEvents toolFit As ToolStripMenuItem
    Friend WithEvents toolRotateLeft As ToolStripMenuItem
    Friend WithEvents toolRotateRight As ToolStripMenuItem
    Friend WithEvents 編集EToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents toolInsert As ToolStripMenuItem
    Friend WithEvents toolDelete As ToolStripMenuItem
    Friend WithEvents toolAdd As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents toolSetLink As ToolStripMenuItem
    Friend WithEvents toolDelLink As ToolStripMenuItem
    Friend WithEvents toolSetLinkTo As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents toolEdit As ToolStripMenuItem
    Friend WithEvents 管理MToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents toolManage As ToolStripMenuItem
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents C1FGridResult As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents Panel1 As Panel
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents lblLinkProcess As Label
    Friend WithEvents btnAbort As Button
    Friend WithEvents btnFinish As Button
    Friend WithEvents btnStart As Button
    Friend WithEvents cmbBookletID As ComboBox
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents C1FGridFlag As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents SplitContainer2 As SplitContainer
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents txtRemarks As TextBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents C1FGridDoc As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents GroupBox6 As GroupBox
    Friend WithEvents rivImage As Leadtools.WinForms.RasterImageViewer
    Friend WithEvents cmbPrefecture As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents toolDelLinkTo As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
End Class
