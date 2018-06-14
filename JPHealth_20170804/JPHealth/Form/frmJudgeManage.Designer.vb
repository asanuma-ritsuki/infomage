<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmJudgeManage
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmJudgeManage))
		Me.Panel1 = New System.Windows.Forms.Panel()
		Me.GroupBox1 = New System.Windows.Forms.GroupBox()
		Me.cmbLeafletPrinted = New System.Windows.Forms.ComboBox()
		Me.Label13 = New System.Windows.Forms.Label()
		Me.btnSearch = New System.Windows.Forms.Button()
		Me.btnOutputCSV = New System.Windows.Forms.Button()
		Me.cmbDeleted = New System.Windows.Forms.ComboBox()
		Me.Label12 = New System.Windows.Forms.Label()
		Me.cmbCompleted = New System.Windows.Forms.ComboBox()
		Me.Label11 = New System.Windows.Forms.Label()
		Me.cmbCheckupPrinted = New System.Windows.Forms.ComboBox()
		Me.Label10 = New System.Windows.Forms.Label()
		Me.cmbCorrected = New System.Windows.Forms.ComboBox()
		Me.Label9 = New System.Windows.Forms.Label()
		Me.cmbDoEdit = New System.Windows.Forms.ComboBox()
		Me.Label8 = New System.Windows.Forms.Label()
		Me.txtLeafCSV = New System.Windows.Forms.TextBox()
		Me.Label7 = New System.Windows.Forms.Label()
		Me.txtJudgeCSV = New System.Windows.Forms.TextBox()
		Me.Label6 = New System.Windows.Forms.Label()
		Me.txtEmployeeCode = New System.Windows.Forms.TextBox()
		Me.txtLimitedCode = New System.Windows.Forms.TextBox()
		Me.cmbCompanyCode = New System.Windows.Forms.ComboBox()
		Me.btnClear = New System.Windows.Forms.Button()
		Me.txtImportTo = New System.Windows.Forms.TextBox()
		Me.dtpImportTo = New System.Windows.Forms.DateTimePicker()
		Me.Label5 = New System.Windows.Forms.Label()
		Me.txtImportFrom = New System.Windows.Forms.TextBox()
		Me.dtpImportFrom = New System.Windows.Forms.DateTimePicker()
		Me.Label4 = New System.Windows.Forms.Label()
		Me.Label3 = New System.Windows.Forms.Label()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.Panel2 = New System.Windows.Forms.Panel()
		Me.btnPrint = New System.Windows.Forms.Button()
		Me.btnVariousOutput = New System.Windows.Forms.Button()
		Me.btnImport = New System.Windows.Forms.Button()
		Me.Panel3 = New System.Windows.Forms.Panel()
		Me.GroupBox2 = New System.Windows.Forms.GroupBox()
		Me.Panel5 = New System.Windows.Forms.Panel()
		Me.C1FGridResult = New C1.Win.C1FlexGrid.C1FlexGrid()
		Me.Panel4 = New System.Windows.Forms.Panel()
		Me.C1FGridCount = New C1.Win.C1FlexGrid.C1FlexGrid()
		Me.Panel1.SuspendLayout()
		Me.GroupBox1.SuspendLayout()
		Me.Panel2.SuspendLayout()
		Me.Panel3.SuspendLayout()
		Me.GroupBox2.SuspendLayout()
		Me.Panel5.SuspendLayout()
		CType(Me.C1FGridResult, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.Panel4.SuspendLayout()
		CType(Me.C1FGridCount, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'Panel1
		'
		Me.Panel1.Controls.Add(Me.GroupBox1)
		Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
		Me.Panel1.Location = New System.Drawing.Point(0, 0)
		Me.Panel1.Name = "Panel1"
		Me.Panel1.Size = New System.Drawing.Size(1184, 145)
		Me.Panel1.TabIndex = 1
		'
		'GroupBox1
		'
		Me.GroupBox1.Controls.Add(Me.cmbLeafletPrinted)
		Me.GroupBox1.Controls.Add(Me.Label13)
		Me.GroupBox1.Controls.Add(Me.btnSearch)
		Me.GroupBox1.Controls.Add(Me.btnOutputCSV)
		Me.GroupBox1.Controls.Add(Me.cmbDeleted)
		Me.GroupBox1.Controls.Add(Me.Label12)
		Me.GroupBox1.Controls.Add(Me.cmbCompleted)
		Me.GroupBox1.Controls.Add(Me.Label11)
		Me.GroupBox1.Controls.Add(Me.cmbCheckupPrinted)
		Me.GroupBox1.Controls.Add(Me.Label10)
		Me.GroupBox1.Controls.Add(Me.cmbCorrected)
		Me.GroupBox1.Controls.Add(Me.Label9)
		Me.GroupBox1.Controls.Add(Me.cmbDoEdit)
		Me.GroupBox1.Controls.Add(Me.Label8)
		Me.GroupBox1.Controls.Add(Me.txtLeafCSV)
		Me.GroupBox1.Controls.Add(Me.Label7)
		Me.GroupBox1.Controls.Add(Me.txtJudgeCSV)
		Me.GroupBox1.Controls.Add(Me.Label6)
		Me.GroupBox1.Controls.Add(Me.txtEmployeeCode)
		Me.GroupBox1.Controls.Add(Me.txtLimitedCode)
		Me.GroupBox1.Controls.Add(Me.cmbCompanyCode)
		Me.GroupBox1.Controls.Add(Me.btnClear)
		Me.GroupBox1.Controls.Add(Me.txtImportTo)
		Me.GroupBox1.Controls.Add(Me.dtpImportTo)
		Me.GroupBox1.Controls.Add(Me.Label5)
		Me.GroupBox1.Controls.Add(Me.txtImportFrom)
		Me.GroupBox1.Controls.Add(Me.dtpImportFrom)
		Me.GroupBox1.Controls.Add(Me.Label4)
		Me.GroupBox1.Controls.Add(Me.Label3)
		Me.GroupBox1.Controls.Add(Me.Label2)
		Me.GroupBox1.Controls.Add(Me.Label1)
		Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
		Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
		Me.GroupBox1.Name = "GroupBox1"
		Me.GroupBox1.Size = New System.Drawing.Size(1184, 145)
		Me.GroupBox1.TabIndex = 0
		Me.GroupBox1.TabStop = False
		Me.GroupBox1.Text = "検索"
		'
		'cmbLeafletPrinted
		'
		Me.cmbLeafletPrinted.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cmbLeafletPrinted.FormattingEnabled = True
		Me.cmbLeafletPrinted.Items.AddRange(New Object() {"対象外", "あり", "なし"})
		Me.cmbLeafletPrinted.Location = New System.Drawing.Point(970, 52)
		Me.cmbLeafletPrinted.Name = "cmbLeafletPrinted"
		Me.cmbLeafletPrinted.Size = New System.Drawing.Size(117, 25)
		Me.cmbLeafletPrinted.TabIndex = 30
		'
		'Label13
		'
		Me.Label13.Location = New System.Drawing.Point(848, 52)
		Me.Label13.Name = "Label13"
		Me.Label13.Size = New System.Drawing.Size(116, 24)
		Me.Label13.TabIndex = 29
		Me.Label13.Text = "リーフレット印刷済："
		Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'btnSearch
		'
		Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.btnSearch.Location = New System.Drawing.Point(1103, 114)
		Me.btnSearch.Name = "btnSearch"
		Me.btnSearch.Size = New System.Drawing.Size(75, 25)
		Me.btnSearch.TabIndex = 28
		Me.btnSearch.Text = "検　索"
		Me.btnSearch.UseVisualStyleBackColor = True
		'
		'btnOutputCSV
		'
		Me.btnOutputCSV.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.btnOutputCSV.Location = New System.Drawing.Point(1103, 83)
		Me.btnOutputCSV.Name = "btnOutputCSV"
		Me.btnOutputCSV.Size = New System.Drawing.Size(75, 25)
		Me.btnOutputCSV.TabIndex = 27
		Me.btnOutputCSV.Text = "CSV出力"
		Me.btnOutputCSV.UseVisualStyleBackColor = True
		'
		'cmbDeleted
		'
		Me.cmbDeleted.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cmbDeleted.FormattingEnabled = True
		Me.cmbDeleted.Items.AddRange(New Object() {"対象外", "あり", "なし"})
		Me.cmbDeleted.Location = New System.Drawing.Point(970, 83)
		Me.cmbDeleted.Name = "cmbDeleted"
		Me.cmbDeleted.Size = New System.Drawing.Size(117, 25)
		Me.cmbDeleted.TabIndex = 26
		'
		'Label12
		'
		Me.Label12.Location = New System.Drawing.Point(848, 83)
		Me.Label12.Name = "Label12"
		Me.Label12.Size = New System.Drawing.Size(116, 24)
		Me.Label12.TabIndex = 25
		Me.Label12.Text = "削除："
		Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'cmbCompleted
		'
		Me.cmbCompleted.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cmbCompleted.FormattingEnabled = True
		Me.cmbCompleted.Items.AddRange(New Object() {"対象外", "あり", "なし"})
		Me.cmbCompleted.Location = New System.Drawing.Point(698, 83)
		Me.cmbCompleted.Name = "cmbCompleted"
		Me.cmbCompleted.Size = New System.Drawing.Size(117, 25)
		Me.cmbCompleted.TabIndex = 24
		'
		'Label11
		'
		Me.Label11.Location = New System.Drawing.Point(597, 83)
		Me.Label11.Name = "Label11"
		Me.Label11.Size = New System.Drawing.Size(95, 24)
		Me.Label11.TabIndex = 23
		Me.Label11.Text = "完了："
		Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'cmbCheckupPrinted
		'
		Me.cmbCheckupPrinted.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cmbCheckupPrinted.FormattingEnabled = True
		Me.cmbCheckupPrinted.Items.AddRange(New Object() {"対象外", "あり", "なし"})
		Me.cmbCheckupPrinted.Location = New System.Drawing.Point(970, 21)
		Me.cmbCheckupPrinted.Name = "cmbCheckupPrinted"
		Me.cmbCheckupPrinted.Size = New System.Drawing.Size(117, 25)
		Me.cmbCheckupPrinted.TabIndex = 22
		'
		'Label10
		'
		Me.Label10.Location = New System.Drawing.Point(848, 21)
		Me.Label10.Name = "Label10"
		Me.Label10.Size = New System.Drawing.Size(116, 24)
		Me.Label10.TabIndex = 21
		Me.Label10.Text = "判定票印刷済："
		Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'cmbCorrected
		'
		Me.cmbCorrected.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cmbCorrected.FormattingEnabled = True
		Me.cmbCorrected.Items.AddRange(New Object() {"対象外", "あり", "なし"})
		Me.cmbCorrected.Location = New System.Drawing.Point(698, 52)
		Me.cmbCorrected.Name = "cmbCorrected"
		Me.cmbCorrected.Size = New System.Drawing.Size(117, 25)
		Me.cmbCorrected.TabIndex = 20
		'
		'Label9
		'
		Me.Label9.Location = New System.Drawing.Point(597, 52)
		Me.Label9.Name = "Label9"
		Me.Label9.Size = New System.Drawing.Size(95, 24)
		Me.Label9.TabIndex = 19
		Me.Label9.Text = "修正済："
		Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'cmbDoEdit
		'
		Me.cmbDoEdit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cmbDoEdit.FormattingEnabled = True
		Me.cmbDoEdit.Items.AddRange(New Object() {"対象外", "あり", "なし"})
		Me.cmbDoEdit.Location = New System.Drawing.Point(698, 21)
		Me.cmbDoEdit.Name = "cmbDoEdit"
		Me.cmbDoEdit.Size = New System.Drawing.Size(117, 25)
		Me.cmbDoEdit.TabIndex = 18
		'
		'Label8
		'
		Me.Label8.Location = New System.Drawing.Point(597, 21)
		Me.Label8.Name = "Label8"
		Me.Label8.Size = New System.Drawing.Size(95, 24)
		Me.Label8.TabIndex = 17
		Me.Label8.Text = "要修正："
		Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'txtLeafCSV
		'
		Me.txtLeafCSV.Location = New System.Drawing.Point(365, 113)
		Me.txtLeafCSV.Name = "txtLeafCSV"
		Me.txtLeafCSV.Size = New System.Drawing.Size(224, 24)
		Me.txtLeafCSV.TabIndex = 16
		'
		'Label7
		'
		Me.Label7.Location = New System.Drawing.Point(266, 113)
		Me.Label7.Name = "Label7"
		Me.Label7.Size = New System.Drawing.Size(93, 24)
		Me.Label7.TabIndex = 15
		Me.Label7.Text = "リーフレット："
		Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'txtJudgeCSV
		'
		Me.txtJudgeCSV.Location = New System.Drawing.Point(365, 83)
		Me.txtJudgeCSV.Name = "txtJudgeCSV"
		Me.txtJudgeCSV.Size = New System.Drawing.Size(224, 24)
		Me.txtJudgeCSV.TabIndex = 14
		'
		'Label6
		'
		Me.Label6.Location = New System.Drawing.Point(266, 83)
		Me.Label6.Name = "Label6"
		Me.Label6.Size = New System.Drawing.Size(93, 24)
		Me.Label6.TabIndex = 13
		Me.Label6.Text = "判定票："
		Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'txtEmployeeCode
		'
		Me.txtEmployeeCode.Location = New System.Drawing.Point(113, 112)
		Me.txtEmployeeCode.Name = "txtEmployeeCode"
		Me.txtEmployeeCode.Size = New System.Drawing.Size(117, 24)
		Me.txtEmployeeCode.TabIndex = 12
		'
		'txtLimitedCode
		'
		Me.txtLimitedCode.Location = New System.Drawing.Point(113, 82)
		Me.txtLimitedCode.Name = "txtLimitedCode"
		Me.txtLimitedCode.Size = New System.Drawing.Size(117, 24)
		Me.txtLimitedCode.TabIndex = 11
		'
		'cmbCompanyCode
		'
		Me.cmbCompanyCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cmbCompanyCode.FormattingEnabled = True
		Me.cmbCompanyCode.Location = New System.Drawing.Point(113, 51)
		Me.cmbCompanyCode.Name = "cmbCompanyCode"
		Me.cmbCompanyCode.Size = New System.Drawing.Size(117, 25)
		Me.cmbCompanyCode.TabIndex = 10
		'
		'btnClear
		'
		Me.btnClear.Location = New System.Drawing.Point(389, 20)
		Me.btnClear.Name = "btnClear"
		Me.btnClear.Size = New System.Drawing.Size(75, 25)
		Me.btnClear.TabIndex = 9
		Me.btnClear.Text = "クリア"
		Me.btnClear.UseVisualStyleBackColor = True
		'
		'txtImportTo
		'
		Me.txtImportTo.Location = New System.Drawing.Point(266, 21)
		Me.txtImportTo.Name = "txtImportTo"
		Me.txtImportTo.ReadOnly = True
		Me.txtImportTo.Size = New System.Drawing.Size(100, 24)
		Me.txtImportTo.TabIndex = 8
		'
		'dtpImportTo
		'
		Me.dtpImportTo.Location = New System.Drawing.Point(365, 21)
		Me.dtpImportTo.Name = "dtpImportTo"
		Me.dtpImportTo.Size = New System.Drawing.Size(18, 24)
		Me.dtpImportTo.TabIndex = 7
		Me.dtpImportTo.TabStop = False
		'
		'Label5
		'
		Me.Label5.Location = New System.Drawing.Point(236, 20)
		Me.Label5.Name = "Label5"
		Me.Label5.Size = New System.Drawing.Size(24, 24)
		Me.Label5.TabIndex = 6
		Me.Label5.Text = "～"
		Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'txtImportFrom
		'
		Me.txtImportFrom.Location = New System.Drawing.Point(113, 21)
		Me.txtImportFrom.Name = "txtImportFrom"
		Me.txtImportFrom.ReadOnly = True
		Me.txtImportFrom.Size = New System.Drawing.Size(100, 24)
		Me.txtImportFrom.TabIndex = 5
		'
		'dtpImportFrom
		'
		Me.dtpImportFrom.Location = New System.Drawing.Point(212, 21)
		Me.dtpImportFrom.Name = "dtpImportFrom"
		Me.dtpImportFrom.Size = New System.Drawing.Size(18, 24)
		Me.dtpImportFrom.TabIndex = 4
		Me.dtpImportFrom.TabStop = False
		'
		'Label4
		'
		Me.Label4.Location = New System.Drawing.Point(12, 112)
		Me.Label4.Name = "Label4"
		Me.Label4.Size = New System.Drawing.Size(95, 24)
		Me.Label4.TabIndex = 3
		Me.Label4.Text = "社員コード："
		Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'Label3
		'
		Me.Label3.Location = New System.Drawing.Point(12, 82)
		Me.Label3.Name = "Label3"
		Me.Label3.Size = New System.Drawing.Size(95, 24)
		Me.Label3.TabIndex = 2
		Me.Label3.Text = "局所コード："
		Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'Label2
		'
		Me.Label2.Location = New System.Drawing.Point(12, 51)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(95, 24)
		Me.Label2.TabIndex = 1
		Me.Label2.Text = "会社コード："
		Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'Label1
		'
		Me.Label1.Location = New System.Drawing.Point(12, 20)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(95, 24)
		Me.Label1.TabIndex = 0
		Me.Label1.Text = "インポート日："
		Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'Panel2
		'
		Me.Panel2.Controls.Add(Me.btnPrint)
		Me.Panel2.Controls.Add(Me.btnVariousOutput)
		Me.Panel2.Controls.Add(Me.btnImport)
		Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
		Me.Panel2.Location = New System.Drawing.Point(0, 801)
		Me.Panel2.Name = "Panel2"
		Me.Panel2.Size = New System.Drawing.Size(1184, 38)
		Me.Panel2.TabIndex = 2
		'
		'btnPrint
		'
		Me.btnPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
		Me.btnPrint.Location = New System.Drawing.Point(174, 7)
		Me.btnPrint.Name = "btnPrint"
		Me.btnPrint.Size = New System.Drawing.Size(75, 25)
		Me.btnPrint.TabIndex = 12
		Me.btnPrint.Text = "印　刷"
		Me.btnPrint.UseVisualStyleBackColor = True
		'
		'btnVariousOutput
		'
		Me.btnVariousOutput.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
		Me.btnVariousOutput.Location = New System.Drawing.Point(93, 7)
		Me.btnVariousOutput.Name = "btnVariousOutput"
		Me.btnVariousOutput.Size = New System.Drawing.Size(75, 25)
		Me.btnVariousOutput.TabIndex = 11
		Me.btnVariousOutput.Text = "各種出力"
		Me.btnVariousOutput.UseVisualStyleBackColor = True
		'
		'btnImport
		'
		Me.btnImport.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
		Me.btnImport.Location = New System.Drawing.Point(12, 7)
		Me.btnImport.Name = "btnImport"
		Me.btnImport.Size = New System.Drawing.Size(75, 25)
		Me.btnImport.TabIndex = 10
		Me.btnImport.Text = "インポート"
		Me.btnImport.UseVisualStyleBackColor = True
		'
		'Panel3
		'
		Me.Panel3.Controls.Add(Me.GroupBox2)
		Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
		Me.Panel3.Location = New System.Drawing.Point(0, 145)
		Me.Panel3.Name = "Panel3"
		Me.Panel3.Size = New System.Drawing.Size(1184, 656)
		Me.Panel3.TabIndex = 3
		'
		'GroupBox2
		'
		Me.GroupBox2.Controls.Add(Me.Panel5)
		Me.GroupBox2.Controls.Add(Me.Panel4)
		Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
		Me.GroupBox2.Location = New System.Drawing.Point(0, 0)
		Me.GroupBox2.Name = "GroupBox2"
		Me.GroupBox2.Size = New System.Drawing.Size(1184, 656)
		Me.GroupBox2.TabIndex = 0
		Me.GroupBox2.TabStop = False
		Me.GroupBox2.Text = "検索結果"
		'
		'Panel5
		'
		Me.Panel5.Controls.Add(Me.C1FGridResult)
		Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
		Me.Panel5.Location = New System.Drawing.Point(3, 67)
		Me.Panel5.Name = "Panel5"
		Me.Panel5.Size = New System.Drawing.Size(1178, 586)
		Me.Panel5.TabIndex = 1
		'
		'C1FGridResult
		'
		Me.C1FGridResult.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
		Me.C1FGridResult.AllowEditing = False
		Me.C1FGridResult.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
		Me.C1FGridResult.AutoClipboard = True
		Me.C1FGridResult.ColumnInfo = resources.GetString("C1FGridResult.ColumnInfo")
		Me.C1FGridResult.Dock = System.Windows.Forms.DockStyle.Fill
		Me.C1FGridResult.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid
		Me.C1FGridResult.Font = New System.Drawing.Font("Meiryo UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.C1FGridResult.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcrossOut
		Me.C1FGridResult.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcrossOut
		Me.C1FGridResult.Location = New System.Drawing.Point(0, 0)
		Me.C1FGridResult.Name = "C1FGridResult"
		Me.C1FGridResult.Rows.Count = 1
		Me.C1FGridResult.Rows.DefaultSize = 20
		Me.C1FGridResult.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.CellRange
		Me.C1FGridResult.ShowCellLabels = True
		Me.C1FGridResult.Size = New System.Drawing.Size(1178, 586)
		Me.C1FGridResult.TabIndex = 2
		Me.C1FGridResult.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.System
		'
		'Panel4
		'
		Me.Panel4.Controls.Add(Me.C1FGridCount)
		Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
		Me.Panel4.Location = New System.Drawing.Point(3, 20)
		Me.Panel4.Name = "Panel4"
		Me.Panel4.Size = New System.Drawing.Size(1178, 47)
		Me.Panel4.TabIndex = 0
		'
		'C1FGridCount
		'
		Me.C1FGridCount.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
		Me.C1FGridCount.AllowEditing = False
		Me.C1FGridCount.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
		Me.C1FGridCount.AutoClipboard = True
		Me.C1FGridCount.ColumnInfo = resources.GetString("C1FGridCount.ColumnInfo")
		Me.C1FGridCount.Dock = System.Windows.Forms.DockStyle.Fill
		Me.C1FGridCount.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid
		Me.C1FGridCount.Font = New System.Drawing.Font("Meiryo UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.C1FGridCount.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcrossOut
		Me.C1FGridCount.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcrossOut
		Me.C1FGridCount.Location = New System.Drawing.Point(0, 0)
		Me.C1FGridCount.Name = "C1FGridCount"
		Me.C1FGridCount.Rows.Count = 1
		Me.C1FGridCount.Rows.DefaultSize = 20
		Me.C1FGridCount.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.CellRange
		Me.C1FGridCount.ShowCellLabels = True
		Me.C1FGridCount.Size = New System.Drawing.Size(1178, 47)
		Me.C1FGridCount.TabIndex = 2
		Me.C1FGridCount.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.System
		'
		'frmJudgeManage
		'
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
		Me.CaptionDisplayMode = JPHealth.frmTempForm.StatusDisplayMode.ShowAll
		Me.ClientSize = New System.Drawing.Size(1184, 861)
		Me.Controls.Add(Me.Panel3)
		Me.Controls.Add(Me.Panel2)
		Me.Controls.Add(Me.Panel1)
		Me.KeyPreview = True
		Me.Name = "frmJudgeManage"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "frmJudgeManage"
		Me.Controls.SetChildIndex(Me.Panel1, 0)
		Me.Controls.SetChildIndex(Me.Panel2, 0)
		Me.Controls.SetChildIndex(Me.Panel3, 0)
		Me.Panel1.ResumeLayout(False)
		Me.GroupBox1.ResumeLayout(False)
		Me.GroupBox1.PerformLayout()
		Me.Panel2.ResumeLayout(False)
		Me.Panel3.ResumeLayout(False)
		Me.GroupBox2.ResumeLayout(False)
		Me.Panel5.ResumeLayout(False)
		CType(Me.C1FGridResult, System.ComponentModel.ISupportInitialize).EndInit()
		Me.Panel4.ResumeLayout(False)
		CType(Me.C1FGridCount, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	Friend WithEvents Panel1 As Panel
	Friend WithEvents GroupBox1 As GroupBox
	Friend WithEvents Panel2 As Panel
	Friend WithEvents Panel3 As Panel
	Friend WithEvents btnSearch As Button
	Friend WithEvents btnOutputCSV As Button
	Friend WithEvents cmbDeleted As ComboBox
	Friend WithEvents Label12 As Label
	Friend WithEvents cmbCompleted As ComboBox
	Friend WithEvents Label11 As Label
	Friend WithEvents cmbCheckupPrinted As ComboBox
	Friend WithEvents Label10 As Label
	Friend WithEvents cmbCorrected As ComboBox
	Friend WithEvents Label9 As Label
	Friend WithEvents cmbDoEdit As ComboBox
	Friend WithEvents Label8 As Label
	Friend WithEvents txtLeafCSV As TextBox
	Friend WithEvents Label7 As Label
	Friend WithEvents txtJudgeCSV As TextBox
	Friend WithEvents Label6 As Label
	Friend WithEvents txtEmployeeCode As TextBox
	Friend WithEvents txtLimitedCode As TextBox
	Friend WithEvents cmbCompanyCode As ComboBox
	Friend WithEvents btnClear As Button
	Friend WithEvents txtImportTo As TextBox
	Friend WithEvents dtpImportTo As DateTimePicker
	Friend WithEvents Label5 As Label
	Friend WithEvents txtImportFrom As TextBox
	Friend WithEvents dtpImportFrom As DateTimePicker
	Friend WithEvents Label4 As Label
	Friend WithEvents Label3 As Label
	Friend WithEvents Label2 As Label
	Friend WithEvents Label1 As Label
	Friend WithEvents GroupBox2 As GroupBox
	Friend WithEvents Panel5 As Panel
	Friend WithEvents C1FGridResult As C1.Win.C1FlexGrid.C1FlexGrid
	Friend WithEvents Panel4 As Panel
	Friend WithEvents C1FGridCount As C1.Win.C1FlexGrid.C1FlexGrid
	Friend WithEvents btnPrint As Button
	Friend WithEvents btnVariousOutput As Button
	Friend WithEvents btnImport As Button
	Friend WithEvents cmbLeafletPrinted As ComboBox
	Friend WithEvents Label13 As Label
End Class
