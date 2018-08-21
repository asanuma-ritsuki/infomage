<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEntry
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEntry))
		Me.GroupBox2 = New System.Windows.Forms.GroupBox()
		Me.C1FGridMokuji = New C1.Win.C1FlexGrid.C1FlexGrid()
		Me.ContextMokuji = New System.Windows.Forms.ContextMenuStrip(Me.components)
		Me.toolSetLink = New System.Windows.Forms.ToolStripMenuItem()
		Me.toolDelLink = New System.Windows.Forms.ToolStripMenuItem()
		Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
		Me.toolSetLinkTo = New System.Windows.Forms.ToolStripMenuItem()
		Me.toolDelLinkTo = New System.Windows.Forms.ToolStripMenuItem()
		Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
		Me.ファイルFToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.toolTop = New System.Windows.Forms.ToolStripMenuItem()
		Me.toolPrev = New System.Windows.Forms.ToolStripMenuItem()
		Me.toolNext = New System.Windows.Forms.ToolStripMenuItem()
		Me.toolBottom = New System.Windows.Forms.ToolStripMenuItem()
		Me.表示VToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.toolReduction = New System.Windows.Forms.ToolStripMenuItem()
		Me.toolMagnification = New System.Windows.Forms.ToolStripMenuItem()
		Me.toolFit = New System.Windows.Forms.ToolStripMenuItem()
		Me.編集EToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.toolInsert = New System.Windows.Forms.ToolStripMenuItem()
		Me.toolAdd = New System.Windows.Forms.ToolStripMenuItem()
		Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
		Me.menuSetLink = New System.Windows.Forms.ToolStripMenuItem()
		Me.menuDelLink = New System.Windows.Forms.ToolStripMenuItem()
		Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
		Me.menuSetLinkTo = New System.Windows.Forms.ToolStripMenuItem()
		Me.menuDelLinkTo = New System.Windows.Forms.ToolStripMenuItem()
		Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
		Me.toolEdit = New System.Windows.Forms.ToolStripMenuItem()
		Me.GroupBox1 = New System.Windows.Forms.GroupBox()
		Me.C1FGridOriginal = New C1.Win.C1FlexGrid.C1FlexGrid()
		Me.GroupBox2.SuspendLayout()
		CType(Me.C1FGridMokuji, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.ContextMokuji.SuspendLayout()
		Me.MenuStrip1.SuspendLayout()
		Me.GroupBox1.SuspendLayout()
		CType(Me.C1FGridOriginal, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'GroupBox2
		'
		Me.GroupBox2.Controls.Add(Me.C1FGridMokuji)
		Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
		Me.GroupBox2.Location = New System.Drawing.Point(0, 24)
		Me.GroupBox2.Name = "GroupBox2"
		Me.GroupBox2.Size = New System.Drawing.Size(708, 315)
		Me.GroupBox2.TabIndex = 1
		Me.GroupBox2.TabStop = False
		Me.GroupBox2.Text = "目次部"
		'
		'C1FGridMokuji
		'
		Me.C1FGridMokuji.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
		Me.C1FGridMokuji.AllowEditing = False
		Me.C1FGridMokuji.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
		Me.C1FGridMokuji.ColumnInfo = resources.GetString("C1FGridMokuji.ColumnInfo")
		Me.C1FGridMokuji.ContextMenuStrip = Me.ContextMokuji
		Me.C1FGridMokuji.Dock = System.Windows.Forms.DockStyle.Fill
		Me.C1FGridMokuji.ExtendLastCol = True
		Me.C1FGridMokuji.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid
		Me.C1FGridMokuji.Font = New System.Drawing.Font("Meiryo UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.C1FGridMokuji.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcrossOut
		Me.C1FGridMokuji.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcrossOut
		Me.C1FGridMokuji.Location = New System.Drawing.Point(3, 20)
		Me.C1FGridMokuji.Name = "C1FGridMokuji"
		Me.C1FGridMokuji.Rows.Count = 1
		Me.C1FGridMokuji.Rows.DefaultSize = 27
		Me.C1FGridMokuji.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
		Me.C1FGridMokuji.ShowCellLabels = True
		Me.C1FGridMokuji.Size = New System.Drawing.Size(702, 292)
		Me.C1FGridMokuji.TabIndex = 34
		Me.C1FGridMokuji.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.System
		'
		'ContextMokuji
		'
		Me.ContextMokuji.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolSetLink, Me.toolDelLink, Me.ToolStripSeparator1, Me.toolSetLinkTo, Me.toolDelLinkTo})
		Me.ContextMokuji.Name = "ContextMokuji"
		Me.ContextMokuji.Size = New System.Drawing.Size(177, 98)
		'
		'toolSetLink
		'
		Me.toolSetLink.Image = Global.LinkPasteTool.My.Resources.Resources.link_add
		Me.toolSetLink.Name = "toolSetLink"
		Me.toolSetLink.ShortcutKeys = System.Windows.Forms.Keys.F5
		Me.toolSetLink.Size = New System.Drawing.Size(176, 22)
		Me.toolSetLink.Text = "リンクFROM設定"
		'
		'toolDelLink
		'
		Me.toolDelLink.Image = Global.LinkPasteTool.My.Resources.Resources.link_delete
		Me.toolDelLink.Name = "toolDelLink"
		Me.toolDelLink.ShortcutKeys = System.Windows.Forms.Keys.F6
		Me.toolDelLink.Size = New System.Drawing.Size(176, 22)
		Me.toolDelLink.Text = "リンクFROM削除"
		'
		'ToolStripSeparator1
		'
		Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
		Me.ToolStripSeparator1.Size = New System.Drawing.Size(173, 6)
		'
		'toolSetLinkTo
		'
		Me.toolSetLinkTo.Image = Global.LinkPasteTool.My.Resources.Resources.link_go
		Me.toolSetLinkTo.Name = "toolSetLinkTo"
		Me.toolSetLinkTo.ShortcutKeys = System.Windows.Forms.Keys.F9
		Me.toolSetLinkTo.Size = New System.Drawing.Size(176, 22)
		Me.toolSetLinkTo.Text = "リンクTO設定"
		'
		'toolDelLinkTo
		'
		Me.toolDelLinkTo.Image = Global.LinkPasteTool.My.Resources.Resources.link_break
		Me.toolDelLinkTo.Name = "toolDelLinkTo"
		Me.toolDelLinkTo.ShortcutKeys = System.Windows.Forms.Keys.F10
		Me.toolDelLinkTo.Size = New System.Drawing.Size(176, 22)
		Me.toolDelLinkTo.Text = "リンクTO削除"
		'
		'MenuStrip1
		'
		Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ファイルFToolStripMenuItem, Me.表示VToolStripMenuItem, Me.編集EToolStripMenuItem})
		Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
		Me.MenuStrip1.Name = "MenuStrip1"
		Me.MenuStrip1.Size = New System.Drawing.Size(1008, 24)
		Me.MenuStrip1.TabIndex = 2
		Me.MenuStrip1.Text = "MenuStrip1"
		'
		'ファイルFToolStripMenuItem
		'
		Me.ファイルFToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolTop, Me.toolPrev, Me.toolNext, Me.toolBottom})
		Me.ファイルFToolStripMenuItem.Name = "ファイルFToolStripMenuItem"
		Me.ファイルFToolStripMenuItem.Size = New System.Drawing.Size(62, 20)
		Me.ファイルFToolStripMenuItem.Text = "移動(&M)"
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
		Me.表示VToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolReduction, Me.toolMagnification, Me.toolFit})
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
		'編集EToolStripMenuItem
		'
		Me.編集EToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolInsert, Me.toolAdd, Me.ToolStripSeparator2, Me.menuSetLink, Me.menuDelLink, Me.ToolStripSeparator3, Me.menuSetLinkTo, Me.menuDelLinkTo, Me.ToolStripSeparator4, Me.toolEdit})
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
		'toolAdd
		'
		Me.toolAdd.Image = Global.LinkPasteTool.My.Resources.Resources.table_lightning
		Me.toolAdd.Name = "toolAdd"
		Me.toolAdd.ShortcutKeys = CType((System.Windows.Forms.Keys.Shift Or System.Windows.Forms.Keys.F12), System.Windows.Forms.Keys)
		Me.toolAdd.Size = New System.Drawing.Size(177, 22)
		Me.toolAdd.Text = "行の追加"
		'
		'ToolStripSeparator2
		'
		Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
		Me.ToolStripSeparator2.Size = New System.Drawing.Size(174, 6)
		'
		'menuSetLink
		'
		Me.menuSetLink.Image = Global.LinkPasteTool.My.Resources.Resources.link_add
		Me.menuSetLink.Name = "menuSetLink"
		Me.menuSetLink.ShortcutKeys = System.Windows.Forms.Keys.F5
		Me.menuSetLink.Size = New System.Drawing.Size(177, 22)
		Me.menuSetLink.Text = "リンクFROM設定"
		'
		'menuDelLink
		'
		Me.menuDelLink.Image = Global.LinkPasteTool.My.Resources.Resources.link_delete
		Me.menuDelLink.Name = "menuDelLink"
		Me.menuDelLink.ShortcutKeys = System.Windows.Forms.Keys.F6
		Me.menuDelLink.Size = New System.Drawing.Size(177, 22)
		Me.menuDelLink.Text = "リンクFROM削除"
		'
		'ToolStripSeparator3
		'
		Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
		Me.ToolStripSeparator3.Size = New System.Drawing.Size(174, 6)
		'
		'menuSetLinkTo
		'
		Me.menuSetLinkTo.Image = Global.LinkPasteTool.My.Resources.Resources.link_go
		Me.menuSetLinkTo.Name = "menuSetLinkTo"
		Me.menuSetLinkTo.ShortcutKeys = System.Windows.Forms.Keys.F9
		Me.menuSetLinkTo.Size = New System.Drawing.Size(177, 22)
		Me.menuSetLinkTo.Text = "リンクTO設定"
		'
		'menuDelLinkTo
		'
		Me.menuDelLinkTo.Image = Global.LinkPasteTool.My.Resources.Resources.link_break
		Me.menuDelLinkTo.Name = "menuDelLinkTo"
		Me.menuDelLinkTo.ShortcutKeys = System.Windows.Forms.Keys.F10
		Me.menuDelLinkTo.Size = New System.Drawing.Size(177, 22)
		Me.menuDelLinkTo.Text = "リンクTO削除"
		'
		'ToolStripSeparator4
		'
		Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
		Me.ToolStripSeparator4.Size = New System.Drawing.Size(174, 6)
		'
		'toolEdit
		'
		Me.toolEdit.Image = Global.LinkPasteTool.My.Resources.Resources.table_edit
		Me.toolEdit.Name = "toolEdit"
		Me.toolEdit.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.E), System.Windows.Forms.Keys)
		Me.toolEdit.Size = New System.Drawing.Size(177, 22)
		Me.toolEdit.Text = "修正"
		'
		'GroupBox1
		'
		Me.GroupBox1.Controls.Add(Me.C1FGridOriginal)
		Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Right
		Me.GroupBox1.Location = New System.Drawing.Point(708, 24)
		Me.GroupBox1.Name = "GroupBox1"
		Me.GroupBox1.Size = New System.Drawing.Size(300, 315)
		Me.GroupBox1.TabIndex = 3
		Me.GroupBox1.TabStop = False
		Me.GroupBox1.Text = "元データ"
		'
		'C1FGridOriginal
		'
		Me.C1FGridOriginal.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
		Me.C1FGridOriginal.AllowEditing = False
		Me.C1FGridOriginal.AutoClipboard = True
		Me.C1FGridOriginal.ColumnInfo = resources.GetString("C1FGridOriginal.ColumnInfo")
		Me.C1FGridOriginal.Dock = System.Windows.Forms.DockStyle.Fill
		Me.C1FGridOriginal.ExtendLastCol = True
		Me.C1FGridOriginal.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid
		Me.C1FGridOriginal.Font = New System.Drawing.Font("Meiryo UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.C1FGridOriginal.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcrossOut
		Me.C1FGridOriginal.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcrossOut
		Me.C1FGridOriginal.Location = New System.Drawing.Point(3, 20)
		Me.C1FGridOriginal.Name = "C1FGridOriginal"
		Me.C1FGridOriginal.Rows.Count = 1
		Me.C1FGridOriginal.Rows.DefaultSize = 20
		Me.C1FGridOriginal.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Cell
		Me.C1FGridOriginal.ShowCellLabels = True
		Me.C1FGridOriginal.Size = New System.Drawing.Size(294, 292)
		Me.C1FGridOriginal.TabIndex = 3
		Me.C1FGridOriginal.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.System
		'
		'frmEntry
		'
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
		Me.CaptionDisplayMode = LinkPasteTool.frmTempForm.StatusDisplayMode.ShowAll
		Me.ClientSize = New System.Drawing.Size(1008, 361)
		Me.ControlBox = False
		Me.Controls.Add(Me.GroupBox2)
		Me.Controls.Add(Me.GroupBox1)
		Me.Controls.Add(Me.MenuStrip1)
		Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
		Me.KeyPreview = True
		Me.MainMenuStrip = Me.MenuStrip1
		Me.Margin = New System.Windows.Forms.Padding(4)
		Me.Name = "frmEntry"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "frmEntry"
		Me.Controls.SetChildIndex(Me.MenuStrip1, 0)
		Me.Controls.SetChildIndex(Me.GroupBox1, 0)
		Me.Controls.SetChildIndex(Me.GroupBox2, 0)
		Me.GroupBox2.ResumeLayout(False)
		CType(Me.C1FGridMokuji, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ContextMokuji.ResumeLayout(False)
		Me.MenuStrip1.ResumeLayout(False)
		Me.MenuStrip1.PerformLayout()
		Me.GroupBox1.ResumeLayout(False)
		CType(Me.C1FGridOriginal, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
	Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents C1FGridMokuji As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents ContextMokuji As ContextMenuStrip
    Friend WithEvents toolSetLink As ToolStripMenuItem
    Friend WithEvents toolDelLink As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents toolSetLinkTo As ToolStripMenuItem
    Friend WithEvents toolDelLinkTo As ToolStripMenuItem
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents ファイルFToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents toolTop As ToolStripMenuItem
    Friend WithEvents toolPrev As ToolStripMenuItem
    Friend WithEvents toolNext As ToolStripMenuItem
    Friend WithEvents toolBottom As ToolStripMenuItem
    Friend WithEvents 表示VToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents toolReduction As ToolStripMenuItem
    Friend WithEvents toolMagnification As ToolStripMenuItem
    Friend WithEvents toolFit As ToolStripMenuItem
    Friend WithEvents 編集EToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents toolInsert As ToolStripMenuItem
    Friend WithEvents toolAdd As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents menuSetLink As ToolStripMenuItem
    Friend WithEvents menuDelLink As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents menuSetLinkTo As ToolStripMenuItem
    Friend WithEvents menuDelLinkTo As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents toolEdit As ToolStripMenuItem
	Friend WithEvents GroupBox1 As GroupBox
	Friend WithEvents C1FGridOriginal As C1.Win.C1FlexGrid.C1FlexGrid
End Class
