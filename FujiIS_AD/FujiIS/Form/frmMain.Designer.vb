<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
		Me.components = New System.ComponentModel.Container()
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
		Me.toolRotateLeft = New System.Windows.Forms.ToolStripMenuItem()
		Me.toolRotateRight = New System.Windows.Forms.ToolStripMenuItem()
		Me.編集EToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.toolInsert = New System.Windows.Forms.ToolStripMenuItem()
		Me.toolDelete = New System.Windows.Forms.ToolStripMenuItem()
		Me.toolAdd = New System.Windows.Forms.ToolStripMenuItem()
		Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
		Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
		Me.リンク削除ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
		Me.toolEdit = New System.Windows.Forms.ToolStripMenuItem()
		Me.管理MToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.toolManage = New System.Windows.Forms.ToolStripMenuItem()
		Me.Panel1 = New System.Windows.Forms.Panel()
		Me.GroupBox1 = New System.Windows.Forms.GroupBox()
		Me.C1FGridMokuji = New C1.Win.C1FlexGrid.C1FlexGrid()
		Me.ContextMokuji = New System.Windows.Forms.ContextMenuStrip(Me.components)
		Me.toolSetLink = New System.Windows.Forms.ToolStripMenuItem()
		Me.toolDelLink = New System.Windows.Forms.ToolStripMenuItem()
		Me.Panel5 = New System.Windows.Forms.Panel()
		Me.txtBookletName = New System.Windows.Forms.TextBox()
		Me.Label3 = New System.Windows.Forms.Label()
		Me.Panel2 = New System.Windows.Forms.Panel()
		Me.GroupBox3 = New System.Windows.Forms.GroupBox()
		Me.C1FGridResult = New C1.Win.C1FlexGrid.C1FlexGrid()
		Me.Panel3 = New System.Windows.Forms.Panel()
		Me.GroupBox2 = New System.Windows.Forms.GroupBox()
		Me.lblLinkProcess = New System.Windows.Forms.Label()
		Me.btnAbort = New System.Windows.Forms.Button()
		Me.btnFinish = New System.Windows.Forms.Button()
		Me.btnStart = New System.Windows.Forms.Button()
		Me.cmbBookletID = New System.Windows.Forms.ComboBox()
		Me.Panel4 = New System.Windows.Forms.Panel()
		Me.GroupBox4 = New System.Windows.Forms.GroupBox()
		Me.rivImage = New Leadtools.WinForms.RasterImageViewer()
		Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
		Me.MenuStrip1.SuspendLayout()
		Me.Panel1.SuspendLayout()
		Me.GroupBox1.SuspendLayout()
		CType(Me.C1FGridMokuji, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.ContextMokuji.SuspendLayout()
		Me.Panel5.SuspendLayout()
		Me.Panel2.SuspendLayout()
		Me.GroupBox3.SuspendLayout()
		CType(Me.C1FGridResult, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.Panel3.SuspendLayout()
		Me.GroupBox2.SuspendLayout()
		Me.Panel4.SuspendLayout()
		Me.GroupBox4.SuspendLayout()
		CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SplitContainer1.Panel1.SuspendLayout()
		Me.SplitContainer1.Panel2.SuspendLayout()
		Me.SplitContainer1.SuspendLayout()
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
		Me.toolReference.Image = Global.FujiIS.My.Resources.Resources.wrench
		Me.toolReference.Name = "toolReference"
		Me.toolReference.Size = New System.Drawing.Size(133, 22)
		Me.toolReference.Text = "参照フォルダ"
		'
		'toolBack
		'
		Me.toolBack.Image = Global.FujiIS.My.Resources.Resources.Back
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
		Me.toolTop.Image = Global.FujiIS.My.Resources.Resources.actions_go_first_3_22x22
		Me.toolTop.Name = "toolTop"
		Me.toolTop.ShortcutKeyDisplayString = ""
		Me.toolTop.Size = New System.Drawing.Size(129, 22)
		Me.toolTop.Text = "先頭画像"
		'
		'toolPrev
		'
		Me.toolPrev.Image = Global.FujiIS.My.Resources.Resources.actions_go_previous_5_22x22
		Me.toolPrev.Name = "toolPrev"
		Me.toolPrev.ShortcutKeyDisplayString = ""
		Me.toolPrev.ShortcutKeys = System.Windows.Forms.Keys.F1
		Me.toolPrev.Size = New System.Drawing.Size(129, 22)
		Me.toolPrev.Text = "前画像"
		'
		'toolNext
		'
		Me.toolNext.Image = Global.FujiIS.My.Resources.Resources.actions_go_next_5_22x22
		Me.toolNext.Name = "toolNext"
		Me.toolNext.ShortcutKeyDisplayString = ""
		Me.toolNext.ShortcutKeys = System.Windows.Forms.Keys.F2
		Me.toolNext.Size = New System.Drawing.Size(129, 22)
		Me.toolNext.Text = "次画像"
		'
		'toolBottom
		'
		Me.toolBottom.Image = Global.FujiIS.My.Resources.Resources.actions_go_last_3_22x22
		Me.toolBottom.Name = "toolBottom"
		Me.toolBottom.ShortcutKeyDisplayString = ""
		Me.toolBottom.Size = New System.Drawing.Size(129, 22)
		Me.toolBottom.Text = "最終画像"
		'
		'表示VToolStripMenuItem
		'
		Me.表示VToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolReduction, Me.toolMagnification, Me.toolFit, Me.toolRotateLeft, Me.toolRotateRight})
		Me.表示VToolStripMenuItem.Name = "表示VToolStripMenuItem"
		Me.表示VToolStripMenuItem.Size = New System.Drawing.Size(58, 20)
		Me.表示VToolStripMenuItem.Text = "表示(&V)"
		'
		'toolReduction
		'
		Me.toolReduction.Image = Global.FujiIS.My.Resources.Resources.ZoomOut
		Me.toolReduction.Name = "toolReduction"
		Me.toolReduction.ShortcutKeyDisplayString = "Ctrl+[-]"
		Me.toolReduction.Size = New System.Drawing.Size(147, 22)
		Me.toolReduction.Text = "縮小"
		'
		'toolMagnification
		'
		Me.toolMagnification.Image = Global.FujiIS.My.Resources.Resources.ZoomIn
		Me.toolMagnification.Name = "toolMagnification"
		Me.toolMagnification.ShortcutKeyDisplayString = "Ctrl+[+]"
		Me.toolMagnification.Size = New System.Drawing.Size(147, 22)
		Me.toolMagnification.Text = "拡大"
		'
		'toolFit
		'
		Me.toolFit.Image = Global.FujiIS.My.Resources.Resources.Zoom
		Me.toolFit.Name = "toolFit"
		Me.toolFit.ShortcutKeyDisplayString = ""
		Me.toolFit.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F), System.Windows.Forms.Keys)
		Me.toolFit.Size = New System.Drawing.Size(147, 22)
		Me.toolFit.Text = "フィット"
		'
		'toolRotateLeft
		'
		Me.toolRotateLeft.Enabled = False
		Me.toolRotateLeft.Image = Global.FujiIS.My.Resources.Resources.arrow_rotate_anticlockwise
		Me.toolRotateLeft.Name = "toolRotateLeft"
		Me.toolRotateLeft.Size = New System.Drawing.Size(147, 22)
		Me.toolRotateLeft.Text = "左回転"
		'
		'toolRotateRight
		'
		Me.toolRotateRight.Enabled = False
		Me.toolRotateRight.Image = Global.FujiIS.My.Resources.Resources.arrow_rotate_clockwise
		Me.toolRotateRight.Name = "toolRotateRight"
		Me.toolRotateRight.Size = New System.Drawing.Size(147, 22)
		Me.toolRotateRight.Text = "右回転"
		'
		'編集EToolStripMenuItem
		'
		Me.編集EToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolInsert, Me.toolDelete, Me.toolAdd, Me.ToolStripSeparator1, Me.ToolStripMenuItem1, Me.リンク削除ToolStripMenuItem, Me.ToolStripSeparator2, Me.toolEdit})
		Me.編集EToolStripMenuItem.Name = "編集EToolStripMenuItem"
		Me.編集EToolStripMenuItem.Size = New System.Drawing.Size(57, 20)
		Me.編集EToolStripMenuItem.Text = "編集(&E)"
		'
		'toolInsert
		'
		Me.toolInsert.Enabled = False
		Me.toolInsert.Image = Global.FujiIS.My.Resources.Resources.table_row_insert
		Me.toolInsert.Name = "toolInsert"
		Me.toolInsert.Size = New System.Drawing.Size(152, 22)
		Me.toolInsert.Text = "行の挿入"
		'
		'toolDelete
		'
		Me.toolDelete.Enabled = False
		Me.toolDelete.Image = Global.FujiIS.My.Resources.Resources.table_row_delete
		Me.toolDelete.Name = "toolDelete"
		Me.toolDelete.Size = New System.Drawing.Size(177, 22)
		Me.toolDelete.Text = "行の削除"
		'
		'toolAdd
		'
		Me.toolAdd.Enabled = False
		Me.toolAdd.Image = Global.FujiIS.My.Resources.Resources.table_lightning
		Me.toolAdd.Name = "toolAdd"
		Me.toolAdd.Size = New System.Drawing.Size(152, 22)
		Me.toolAdd.Text = "行の追加"
		'
		'ToolStripSeparator1
		'
		Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
		Me.ToolStripSeparator1.Size = New System.Drawing.Size(174, 6)
		'
		'ToolStripMenuItem1
		'
		Me.ToolStripMenuItem1.Image = Global.FujiIS.My.Resources.Resources.link_add
		Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
		Me.ToolStripMenuItem1.ShortcutKeys = System.Windows.Forms.Keys.F3
		Me.ToolStripMenuItem1.Size = New System.Drawing.Size(177, 22)
		Me.ToolStripMenuItem1.Text = "リンク設定"
		'
		'リンク削除ToolStripMenuItem
		'
		Me.リンク削除ToolStripMenuItem.Image = Global.FujiIS.My.Resources.Resources.link_unchain
		Me.リンク削除ToolStripMenuItem.Name = "リンク削除ToolStripMenuItem"
		Me.リンク削除ToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F4
		Me.リンク削除ToolStripMenuItem.Size = New System.Drawing.Size(177, 22)
		Me.リンク削除ToolStripMenuItem.Text = "リンク削除"
		'
		'ToolStripSeparator2
		'
		Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
		Me.ToolStripSeparator2.Size = New System.Drawing.Size(174, 6)
		'
		'toolEdit
		'
		Me.toolEdit.Image = Global.FujiIS.My.Resources.Resources.table_edit
		Me.toolEdit.Name = "toolEdit"
		Me.toolEdit.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.E), System.Windows.Forms.Keys)
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
		Me.toolManage.Image = Global.FujiIS.My.Resources.Resources.account_functions
		Me.toolManage.Name = "toolManage"
		Me.toolManage.Size = New System.Drawing.Size(122, 22)
		Me.toolManage.Text = "管理画面"
		'
		'Panel1
		'
		Me.Panel1.Controls.Add(Me.GroupBox1)
		Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
		Me.Panel1.Location = New System.Drawing.Point(0, 0)
		Me.Panel1.Name = "Panel1"
		Me.Panel1.Size = New System.Drawing.Size(1008, 330)
		Me.Panel1.TabIndex = 2
		'
		'GroupBox1
		'
		Me.GroupBox1.Controls.Add(Me.C1FGridMokuji)
		Me.GroupBox1.Controls.Add(Me.Panel5)
		Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
		Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
		Me.GroupBox1.Name = "GroupBox1"
		Me.GroupBox1.Size = New System.Drawing.Size(1008, 330)
		Me.GroupBox1.TabIndex = 0
		Me.GroupBox1.TabStop = False
		Me.GroupBox1.Text = "目次部"
		'
		'C1FGridMokuji
		'
		Me.C1FGridMokuji.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
		Me.C1FGridMokuji.AllowEditing = False
		Me.C1FGridMokuji.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
		Me.C1FGridMokuji.ColumnInfo = resources.GetString("C1FGridMokuji.ColumnInfo")
		Me.C1FGridMokuji.ContextMenuStrip = Me.ContextMokuji
		Me.C1FGridMokuji.Dock = System.Windows.Forms.DockStyle.Fill
		Me.C1FGridMokuji.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid
		Me.C1FGridMokuji.Font = New System.Drawing.Font("Meiryo UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.C1FGridMokuji.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcrossOut
		Me.C1FGridMokuji.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcrossOut
		Me.C1FGridMokuji.Location = New System.Drawing.Point(3, 58)
		Me.C1FGridMokuji.Name = "C1FGridMokuji"
		Me.C1FGridMokuji.Rows.Count = 1
		Me.C1FGridMokuji.Rows.DefaultSize = 27
		Me.C1FGridMokuji.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
		Me.C1FGridMokuji.ShowCellLabels = True
		Me.C1FGridMokuji.Size = New System.Drawing.Size(1002, 269)
		Me.C1FGridMokuji.TabIndex = 33
		Me.C1FGridMokuji.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.System
		'
		'ContextMokuji
		'
		Me.ContextMokuji.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolSetLink, Me.toolDelLink})
		Me.ContextMokuji.Name = "ContextMenuStrip1"
		Me.ContextMokuji.Size = New System.Drawing.Size(144, 48)
		'
		'toolSetLink
		'
		Me.toolSetLink.Image = Global.FujiIS.My.Resources.Resources.link_add
		Me.toolSetLink.Name = "toolSetLink"
		Me.toolSetLink.ShortcutKeys = System.Windows.Forms.Keys.F3
		Me.toolSetLink.Size = New System.Drawing.Size(143, 22)
		Me.toolSetLink.Text = "リンク設定"
		'
		'toolDelLink
		'
		Me.toolDelLink.Image = Global.FujiIS.My.Resources.Resources.link_unchain
		Me.toolDelLink.Name = "toolDelLink"
		Me.toolDelLink.ShortcutKeys = System.Windows.Forms.Keys.F4
		Me.toolDelLink.Size = New System.Drawing.Size(143, 22)
		Me.toolDelLink.Text = "リンク削除"
		'
		'Panel5
		'
		Me.Panel5.Controls.Add(Me.txtBookletName)
		Me.Panel5.Controls.Add(Me.Label3)
		Me.Panel5.Dock = System.Windows.Forms.DockStyle.Top
		Me.Panel5.Location = New System.Drawing.Point(3, 20)
		Me.Panel5.Name = "Panel5"
		Me.Panel5.Size = New System.Drawing.Size(1002, 38)
		Me.Panel5.TabIndex = 0
		'
		'txtBookletName
		'
		Me.txtBookletName.Location = New System.Drawing.Point(93, 7)
		Me.txtBookletName.Name = "txtBookletName"
		Me.txtBookletName.ReadOnly = True
		Me.txtBookletName.Size = New System.Drawing.Size(900, 24)
		Me.txtBookletName.TabIndex = 33
		'
		'Label3
		'
		Me.Label3.Location = New System.Drawing.Point(7, 6)
		Me.Label3.Name = "Label3"
		Me.Label3.Size = New System.Drawing.Size(80, 26)
		Me.Label3.TabIndex = 32
		Me.Label3.Text = "冊子名："
		Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'Panel2
		'
		Me.Panel2.Controls.Add(Me.GroupBox3)
		Me.Panel2.Controls.Add(Me.Panel3)
		Me.Panel2.Dock = System.Windows.Forms.DockStyle.Left
		Me.Panel2.Location = New System.Drawing.Point(0, 0)
		Me.Panel2.Name = "Panel2"
		Me.Panel2.Size = New System.Drawing.Size(260, 349)
		Me.Panel2.TabIndex = 3
		'
		'GroupBox3
		'
		Me.GroupBox3.Controls.Add(Me.C1FGridResult)
		Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Fill
		Me.GroupBox3.Location = New System.Drawing.Point(0, 100)
		Me.GroupBox3.Name = "GroupBox3"
		Me.GroupBox3.Size = New System.Drawing.Size(260, 249)
		Me.GroupBox3.TabIndex = 1
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
		Me.C1FGridResult.Size = New System.Drawing.Size(254, 226)
		Me.C1FGridResult.TabIndex = 32
		Me.C1FGridResult.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.System
		'
		'Panel3
		'
		Me.Panel3.Controls.Add(Me.GroupBox2)
		Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
		Me.Panel3.Location = New System.Drawing.Point(0, 0)
		Me.Panel3.Name = "Panel3"
		Me.Panel3.Size = New System.Drawing.Size(260, 100)
		Me.Panel3.TabIndex = 0
		'
		'GroupBox2
		'
		Me.GroupBox2.Controls.Add(Me.lblLinkProcess)
		Me.GroupBox2.Controls.Add(Me.btnAbort)
		Me.GroupBox2.Controls.Add(Me.btnFinish)
		Me.GroupBox2.Controls.Add(Me.btnStart)
		Me.GroupBox2.Controls.Add(Me.cmbBookletID)
		Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
		Me.GroupBox2.Location = New System.Drawing.Point(0, 0)
		Me.GroupBox2.Name = "GroupBox2"
		Me.GroupBox2.Size = New System.Drawing.Size(260, 100)
		Me.GroupBox2.TabIndex = 0
		Me.GroupBox2.TabStop = False
		Me.GroupBox2.Text = "冊子ID選択"
		'
		'lblLinkProcess
		'
		Me.lblLinkProcess.BackColor = System.Drawing.Color.LightCoral
		Me.lblLinkProcess.Font = New System.Drawing.Font("Meiryo UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.lblLinkProcess.Location = New System.Drawing.Point(200, 23)
		Me.lblLinkProcess.Name = "lblLinkProcess"
		Me.lblLinkProcess.Size = New System.Drawing.Size(49, 25)
		Me.lblLinkProcess.TabIndex = 4
		Me.lblLinkProcess.Text = "1次"
		Me.lblLinkProcess.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'btnAbort
		'
		Me.btnAbort.Location = New System.Drawing.Point(93, 61)
		Me.btnAbort.Name = "btnAbort"
		Me.btnAbort.Size = New System.Drawing.Size(75, 25)
		Me.btnAbort.TabIndex = 3
		Me.btnAbort.Text = "中　断"
		Me.btnAbort.UseVisualStyleBackColor = True
		'
		'btnFinish
		'
		Me.btnFinish.Location = New System.Drawing.Point(174, 61)
		Me.btnFinish.Name = "btnFinish"
		Me.btnFinish.Size = New System.Drawing.Size(75, 25)
		Me.btnFinish.TabIndex = 2
		Me.btnFinish.Text = "完　了"
		Me.btnFinish.UseVisualStyleBackColor = True
		'
		'btnStart
		'
		Me.btnStart.Location = New System.Drawing.Point(12, 61)
		Me.btnStart.Name = "btnStart"
		Me.btnStart.Size = New System.Drawing.Size(75, 25)
		Me.btnStart.TabIndex = 1
		Me.btnStart.Text = "開　始"
		Me.btnStart.UseVisualStyleBackColor = True
		'
		'cmbBookletID
		'
		Me.cmbBookletID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cmbBookletID.FormattingEnabled = True
		Me.cmbBookletID.Location = New System.Drawing.Point(12, 23)
		Me.cmbBookletID.Name = "cmbBookletID"
		Me.cmbBookletID.Size = New System.Drawing.Size(182, 25)
		Me.cmbBookletID.TabIndex = 0
		'
		'Panel4
		'
		Me.Panel4.Controls.Add(Me.GroupBox4)
		Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
		Me.Panel4.Location = New System.Drawing.Point(260, 0)
		Me.Panel4.Name = "Panel4"
		Me.Panel4.Size = New System.Drawing.Size(748, 349)
		Me.Panel4.TabIndex = 4
		'
		'GroupBox4
		'
		Me.GroupBox4.Controls.Add(Me.rivImage)
		Me.GroupBox4.Dock = System.Windows.Forms.DockStyle.Fill
		Me.GroupBox4.Location = New System.Drawing.Point(0, 0)
		Me.GroupBox4.Name = "GroupBox4"
		Me.GroupBox4.Size = New System.Drawing.Size(748, 349)
		Me.GroupBox4.TabIndex = 1
		Me.GroupBox4.TabStop = False
		Me.GroupBox4.Text = "画像部"
		'
		'rivImage
		'
		Me.rivImage.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.rivImage.Cursor = System.Windows.Forms.Cursors.Default
		Me.rivImage.Dock = System.Windows.Forms.DockStyle.Fill
		Me.rivImage.InteractiveMode = Leadtools.WinForms.RasterViewerInteractiveMode.ZoomTo
		Me.rivImage.Location = New System.Drawing.Point(3, 20)
		Me.rivImage.Name = "rivImage"
		Me.rivImage.Size = New System.Drawing.Size(742, 326)
		Me.rivImage.SizeMode = Leadtools.RasterPaintSizeMode.Fit
		Me.rivImage.TabIndex = 0
		'
		'SplitContainer1
		'
		Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
		Me.SplitContainer1.Location = New System.Drawing.Point(0, 24)
		Me.SplitContainer1.Name = "SplitContainer1"
		Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
		'
		'SplitContainer1.Panel1
		'
		Me.SplitContainer1.Panel1.Controls.Add(Me.Panel4)
		Me.SplitContainer1.Panel1.Controls.Add(Me.Panel2)
		'
		'SplitContainer1.Panel2
		'
		Me.SplitContainer1.Panel2.Controls.Add(Me.Panel1)
		Me.SplitContainer1.Size = New System.Drawing.Size(1008, 683)
		Me.SplitContainer1.SplitterDistance = 349
		Me.SplitContainer1.TabIndex = 5
		'
		'frmMain
		'
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
		Me.CaptionDisplayMode = FujiIS.frmTempForm.StatusDisplayMode.ShowAll
		Me.ClientSize = New System.Drawing.Size(1008, 729)
		Me.Controls.Add(Me.SplitContainer1)
		Me.Controls.Add(Me.MenuStrip1)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable
		Me.KeyPreview = True
		Me.MainMenuStrip = Me.MenuStrip1
		Me.Name = "frmMain"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "frmMain"
		Me.Controls.SetChildIndex(Me.MenuStrip1, 0)
		Me.Controls.SetChildIndex(Me.SplitContainer1, 0)
		Me.MenuStrip1.ResumeLayout(False)
		Me.MenuStrip1.PerformLayout()
		Me.Panel1.ResumeLayout(False)
		Me.GroupBox1.ResumeLayout(False)
		CType(Me.C1FGridMokuji, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ContextMokuji.ResumeLayout(False)
		Me.Panel5.ResumeLayout(False)
		Me.Panel5.PerformLayout()
		Me.Panel2.ResumeLayout(False)
		Me.GroupBox3.ResumeLayout(False)
		CType(Me.C1FGridResult, System.ComponentModel.ISupportInitialize).EndInit()
		Me.Panel3.ResumeLayout(False)
		Me.GroupBox2.ResumeLayout(False)
		Me.Panel4.ResumeLayout(False)
		Me.GroupBox4.ResumeLayout(False)
		Me.SplitContainer1.Panel1.ResumeLayout(False)
		Me.SplitContainer1.Panel2.ResumeLayout(False)
		CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
		Me.SplitContainer1.ResumeLayout(False)
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
	Friend WithEvents toolEdit As ToolStripMenuItem
	Friend WithEvents Panel1 As Panel
	Friend WithEvents GroupBox1 As GroupBox
	Friend WithEvents Panel5 As Panel
	Friend WithEvents txtBookletName As TextBox
	Friend WithEvents Label3 As Label
	Friend WithEvents Panel2 As Panel
	Friend WithEvents GroupBox3 As GroupBox
	Friend WithEvents C1FGridResult As C1.Win.C1FlexGrid.C1FlexGrid
	Friend WithEvents Panel3 As Panel
	Friend WithEvents GroupBox2 As GroupBox
	Friend WithEvents btnFinish As Button
	Friend WithEvents btnStart As Button
	Friend WithEvents cmbBookletID As ComboBox
	Friend WithEvents Panel4 As Panel
	Friend WithEvents GroupBox4 As GroupBox
	Friend WithEvents rivImage As Leadtools.WinForms.RasterImageViewer
	Friend WithEvents C1FGridMokuji As C1.Win.C1FlexGrid.C1FlexGrid
	Friend WithEvents ContextMokuji As ContextMenuStrip
	Friend WithEvents toolSetLink As ToolStripMenuItem
	Friend WithEvents toolDelLink As ToolStripMenuItem
	Friend WithEvents 管理MToolStripMenuItem As ToolStripMenuItem
	Friend WithEvents toolManage As ToolStripMenuItem
	Friend WithEvents SplitContainer1 As SplitContainer
	Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
	Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
	Friend WithEvents リンク削除ToolStripMenuItem As ToolStripMenuItem
	Friend WithEvents btnAbort As Button
	Friend WithEvents lblLinkProcess As Label
End Class
