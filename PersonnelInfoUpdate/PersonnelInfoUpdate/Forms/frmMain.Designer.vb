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
		Me.Panel1 = New System.Windows.Forms.Panel()
		Me.GroupBox2 = New System.Windows.Forms.GroupBox()
		Me.C1FGridSum = New C1.Win.C1FlexGrid.C1FlexGrid()
		Me.GroupBox1 = New System.Windows.Forms.GroupBox()
		Me.btnDelete = New C1.Win.C1Input.C1Button()
		Me.txtOffice = New C1.Win.C1Input.C1TextBox()
		Me.txtLotID = New C1.Win.C1Input.C1TextBox()
		Me.C1Label3 = New C1.Win.C1Input.C1Label()
		Me.btnCorrection = New C1.Win.C1Input.C1Button()
		Me.chkDeleted = New C1.Win.C1Input.C1CheckBox()
		Me.btnAfterUpdate = New C1.Win.C1Input.C1Button()
		Me.btnCSVOut = New C1.Win.C1Input.C1Button()
		Me.btnImport = New C1.Win.C1Input.C1Button()
		Me.cmbOffice = New C1.Win.C1Input.C1ComboBox()
		Me.C1Label2 = New C1.Win.C1Input.C1Label()
		Me.btnSearch = New C1.Win.C1Input.C1Button()
		Me.dtpProcessDate = New C1.Win.Calendar.C1DateEdit()
		Me.C1Label1 = New C1.Win.C1Input.C1Label()
		Me.Panel2 = New System.Windows.Forms.Panel()
		Me.GroupBox3 = New System.Windows.Forms.GroupBox()
		Me.C1FGridResult = New C1.Win.C1FlexGrid.C1FlexGrid()
		Me.Panel1.SuspendLayout()
		Me.GroupBox2.SuspendLayout()
		CType(Me.C1FGridSum, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.GroupBox1.SuspendLayout()
		CType(Me.btnDelete, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.txtOffice, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.txtLotID, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.C1Label3, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.btnCorrection, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.chkDeleted, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.btnAfterUpdate, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.btnCSVOut, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.btnImport, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.cmbOffice, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.C1Label2, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.btnSearch, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.dtpProcessDate, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.C1Label1, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.Panel2.SuspendLayout()
		Me.GroupBox3.SuspendLayout()
		CType(Me.C1FGridResult, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'Panel1
		'
		Me.Panel1.Controls.Add(Me.GroupBox2)
		Me.Panel1.Controls.Add(Me.GroupBox1)
		Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
		Me.Panel1.Location = New System.Drawing.Point(0, 0)
		Me.Panel1.Name = "Panel1"
		Me.Panel1.Size = New System.Drawing.Size(1156, 192)
		Me.Panel1.TabIndex = 1
		'
		'GroupBox2
		'
		Me.GroupBox2.Controls.Add(Me.C1FGridSum)
		Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
		Me.GroupBox2.Location = New System.Drawing.Point(447, 0)
		Me.GroupBox2.Name = "GroupBox2"
		Me.GroupBox2.Size = New System.Drawing.Size(709, 192)
		Me.GroupBox2.TabIndex = 1
		Me.GroupBox2.TabStop = False
		Me.GroupBox2.Text = "集計"
		'
		'C1FGridSum
		'
		Me.C1FGridSum.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
		Me.C1FGridSum.AllowEditing = False
		Me.C1FGridSum.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
		Me.C1FGridSum.AutoClipboard = True
		Me.C1FGridSum.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
		Me.C1FGridSum.ColumnInfo = resources.GetString("C1FGridSum.ColumnInfo")
		Me.C1FGridSum.Dock = System.Windows.Forms.DockStyle.Fill
		Me.C1FGridSum.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid
		Me.C1FGridSum.Font = New System.Drawing.Font("Meiryo UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.C1FGridSum.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcrossOut
		Me.C1FGridSum.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcrossOut
		Me.C1FGridSum.Location = New System.Drawing.Point(3, 20)
		Me.C1FGridSum.Name = "C1FGridSum"
		Me.C1FGridSum.Rows.Count = 1
		Me.C1FGridSum.Rows.DefaultSize = 20
		Me.C1FGridSum.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
		Me.C1FGridSum.ShowCellLabels = True
		Me.C1FGridSum.Size = New System.Drawing.Size(703, 169)
		Me.C1FGridSum.StyleInfo = resources.GetString("C1FGridSum.StyleInfo")
		Me.C1FGridSum.SubtotalPosition = C1.Win.C1FlexGrid.SubtotalPositionEnum.BelowData
		Me.C1FGridSum.TabIndex = 1
		Me.C1FGridSum.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2010Black
		'
		'GroupBox1
		'
		Me.GroupBox1.Controls.Add(Me.btnDelete)
		Me.GroupBox1.Controls.Add(Me.txtOffice)
		Me.GroupBox1.Controls.Add(Me.txtLotID)
		Me.GroupBox1.Controls.Add(Me.C1Label3)
		Me.GroupBox1.Controls.Add(Me.btnCorrection)
		Me.GroupBox1.Controls.Add(Me.chkDeleted)
		Me.GroupBox1.Controls.Add(Me.btnAfterUpdate)
		Me.GroupBox1.Controls.Add(Me.btnCSVOut)
		Me.GroupBox1.Controls.Add(Me.btnImport)
		Me.GroupBox1.Controls.Add(Me.cmbOffice)
		Me.GroupBox1.Controls.Add(Me.C1Label2)
		Me.GroupBox1.Controls.Add(Me.btnSearch)
		Me.GroupBox1.Controls.Add(Me.dtpProcessDate)
		Me.GroupBox1.Controls.Add(Me.C1Label1)
		Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Left
		Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
		Me.GroupBox1.Name = "GroupBox1"
		Me.GroupBox1.Size = New System.Drawing.Size(447, 192)
		Me.GroupBox1.TabIndex = 0
		Me.GroupBox1.TabStop = False
		Me.GroupBox1.Text = "検索・各種処理"
		'
		'btnDelete
		'
		Me.btnDelete.Location = New System.Drawing.Point(349, 125)
		Me.btnDelete.Name = "btnDelete"
		Me.btnDelete.Size = New System.Drawing.Size(75, 25)
		Me.btnDelete.TabIndex = 14
		Me.btnDelete.Text = "削　除"
		Me.btnDelete.UseVisualStyleBackColor = True
		'
		'txtOffice
		'
		Me.txtOffice.AllowDrop = True
		Me.txtOffice.AutoSize = False
		Me.txtOffice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.txtOffice.Location = New System.Drawing.Point(242, 125)
		Me.txtOffice.Name = "txtOffice"
		Me.txtOffice.ReadOnly = True
		Me.txtOffice.Size = New System.Drawing.Size(89, 25)
		Me.txtOffice.TabIndex = 13
		Me.txtOffice.Tag = Nothing
		Me.txtOffice.TextDetached = True
		'
		'txtLotID
		'
		Me.txtLotID.AllowDrop = True
		Me.txtLotID.AutoSize = False
		Me.txtLotID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.txtLotID.Location = New System.Drawing.Point(96, 125)
		Me.txtLotID.Name = "txtLotID"
		Me.txtLotID.ReadOnly = True
		Me.txtLotID.Size = New System.Drawing.Size(140, 25)
		Me.txtLotID.TabIndex = 12
		Me.txtLotID.Tag = Nothing
		Me.txtLotID.TextDetached = True
		'
		'C1Label3
		'
		Me.C1Label3.BackColor = System.Drawing.Color.Transparent
		Me.C1Label3.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.C1Label3.ForeColor = System.Drawing.Color.Black
		Me.C1Label3.Location = New System.Drawing.Point(10, 123)
		Me.C1Label3.Name = "C1Label3"
		Me.C1Label3.Size = New System.Drawing.Size(80, 25)
		Me.C1Label3.TabIndex = 11
		Me.C1Label3.Tag = Nothing
		Me.C1Label3.Text = "選択ロット："
		Me.C1Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.C1Label3.TextDetached = True
		Me.C1Label3.Value = "選択ロット："
		'
		'btnCorrection
		'
		Me.btnCorrection.Location = New System.Drawing.Point(112, 161)
		Me.btnCorrection.Name = "btnCorrection"
		Me.btnCorrection.Size = New System.Drawing.Size(100, 25)
		Me.btnCorrection.TabIndex = 9
		Me.btnCorrection.Text = "不備修正"
		Me.btnCorrection.UseVisualStyleBackColor = True
		'
		'chkDeleted
		'
		Me.chkDeleted.BackColor = System.Drawing.Color.Transparent
		Me.chkDeleted.BorderColor = System.Drawing.Color.Transparent
		Me.chkDeleted.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.chkDeleted.ForeColor = System.Drawing.Color.Black
		Me.chkDeleted.Location = New System.Drawing.Point(96, 95)
		Me.chkDeleted.Name = "chkDeleted"
		Me.chkDeleted.Padding = New System.Windows.Forms.Padding(1)
		Me.chkDeleted.Size = New System.Drawing.Size(200, 24)
		Me.chkDeleted.TabIndex = 8
		Me.chkDeleted.Text = "削除済みロットを表示する"
		Me.chkDeleted.UseVisualStyleBackColor = False
		Me.chkDeleted.Value = Nothing
		Me.chkDeleted.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Black
		'
		'btnAfterUpdate
		'
		Me.btnAfterUpdate.Location = New System.Drawing.Point(324, 161)
		Me.btnAfterUpdate.Name = "btnAfterUpdate"
		Me.btnAfterUpdate.Size = New System.Drawing.Size(100, 25)
		Me.btnAfterUpdate.TabIndex = 7
		Me.btnAfterUpdate.Text = "データ抽出"
		Me.btnAfterUpdate.UseVisualStyleBackColor = True
		'
		'btnCSVOut
		'
		Me.btnCSVOut.Location = New System.Drawing.Point(218, 161)
		Me.btnCSVOut.Name = "btnCSVOut"
		Me.btnCSVOut.Size = New System.Drawing.Size(100, 25)
		Me.btnCSVOut.TabIndex = 6
		Me.btnCSVOut.Text = "CSV出力"
		Me.btnCSVOut.UseVisualStyleBackColor = True
		'
		'btnImport
		'
		Me.btnImport.Location = New System.Drawing.Point(6, 161)
		Me.btnImport.Name = "btnImport"
		Me.btnImport.Size = New System.Drawing.Size(100, 25)
		Me.btnImport.TabIndex = 5
		Me.btnImport.Text = "インポート"
		Me.btnImport.UseVisualStyleBackColor = True
		'
		'cmbOffice
		'
		Me.cmbOffice.AllowSpinLoop = False
		Me.cmbOffice.AutoSize = False
		Me.cmbOffice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.cmbOffice.Cursor = System.Windows.Forms.Cursors.Arrow
		Me.cmbOffice.DropDownStyle = C1.Win.C1Input.DropDownStyle.DropDownList
		Me.cmbOffice.GapHeight = 0
		Me.cmbOffice.ImagePadding = New System.Windows.Forms.Padding(0)
		Me.cmbOffice.ItemsDisplayMember = ""
		Me.cmbOffice.ItemsValueMember = ""
		Me.cmbOffice.Location = New System.Drawing.Point(96, 64)
		Me.cmbOffice.Name = "cmbOffice"
		Me.cmbOffice.Size = New System.Drawing.Size(200, 25)
		Me.cmbOffice.TabIndex = 4
		Me.cmbOffice.Tag = Nothing
		Me.cmbOffice.TextDetached = True
		Me.cmbOffice.TranslateValue = True
		'
		'C1Label2
		'
		Me.C1Label2.BackColor = System.Drawing.Color.Transparent
		Me.C1Label2.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.C1Label2.ForeColor = System.Drawing.Color.Black
		Me.C1Label2.Location = New System.Drawing.Point(10, 64)
		Me.C1Label2.Name = "C1Label2"
		Me.C1Label2.Size = New System.Drawing.Size(80, 25)
		Me.C1Label2.TabIndex = 3
		Me.C1Label2.Tag = Nothing
		Me.C1Label2.Text = "事業所："
		Me.C1Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.C1Label2.TextDetached = True
		Me.C1Label2.Value = "事業所："
		'
		'btnSearch
		'
		Me.btnSearch.Location = New System.Drawing.Point(366, 31)
		Me.btnSearch.Name = "btnSearch"
		Me.btnSearch.Size = New System.Drawing.Size(75, 25)
		Me.btnSearch.TabIndex = 2
		Me.btnSearch.Text = "検　索"
		Me.btnSearch.UseVisualStyleBackColor = True
		'
		'dtpProcessDate
		'
		Me.dtpProcessDate.AllowSpinLoop = False
		Me.dtpProcessDate.AutoSize = False
		Me.dtpProcessDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.dtpProcessDate.Calendar.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
		Me.dtpProcessDate.Calendar.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Black
		Me.dtpProcessDate.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Black
		Me.dtpProcessDate.DisplayFormat.CustomFormat = "yyyy年MM月dd日"
		Me.dtpProcessDate.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
		Me.dtpProcessDate.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
			Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
			Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
			Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
		Me.dtpProcessDate.EditFormat.CustomFormat = "yyyy年MM月dd日"
		Me.dtpProcessDate.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
		Me.dtpProcessDate.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
			Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
			Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
			Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
		Me.dtpProcessDate.ImagePadding = New System.Windows.Forms.Padding(0)
		Me.dtpProcessDate.Location = New System.Drawing.Point(96, 33)
		Me.dtpProcessDate.Name = "dtpProcessDate"
		Me.dtpProcessDate.Size = New System.Drawing.Size(140, 25)
		Me.dtpProcessDate.TabIndex = 1
		Me.dtpProcessDate.Tag = Nothing
		Me.dtpProcessDate.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
		'
		'C1Label1
		'
		Me.C1Label1.BackColor = System.Drawing.Color.Transparent
		Me.C1Label1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.C1Label1.ForeColor = System.Drawing.Color.Black
		Me.C1Label1.Location = New System.Drawing.Point(10, 31)
		Me.C1Label1.Name = "C1Label1"
		Me.C1Label1.Size = New System.Drawing.Size(80, 25)
		Me.C1Label1.TabIndex = 0
		Me.C1Label1.Tag = Nothing
		Me.C1Label1.Text = "処理日："
		Me.C1Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.C1Label1.TextDetached = True
		Me.C1Label1.Value = "処理日："
		'
		'Panel2
		'
		Me.Panel2.Controls.Add(Me.GroupBox3)
		Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
		Me.Panel2.Location = New System.Drawing.Point(0, 192)
		Me.Panel2.Name = "Panel2"
		Me.Panel2.Size = New System.Drawing.Size(1156, 556)
		Me.Panel2.TabIndex = 2
		'
		'GroupBox3
		'
		Me.GroupBox3.Controls.Add(Me.C1FGridResult)
		Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Fill
		Me.GroupBox3.Location = New System.Drawing.Point(0, 0)
		Me.GroupBox3.Name = "GroupBox3"
		Me.GroupBox3.Size = New System.Drawing.Size(1156, 556)
		Me.GroupBox3.TabIndex = 0
		Me.GroupBox3.TabStop = False
		Me.GroupBox3.Text = "ロット一覧"
		'
		'C1FGridResult
		'
		Me.C1FGridResult.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
		Me.C1FGridResult.AllowEditing = False
		Me.C1FGridResult.AllowFiltering = True
		Me.C1FGridResult.AutoClipboard = True
		Me.C1FGridResult.AutoResize = True
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
		Me.C1FGridResult.Size = New System.Drawing.Size(1150, 533)
		Me.C1FGridResult.StyleInfo = resources.GetString("C1FGridResult.StyleInfo")
		Me.C1FGridResult.SubtotalPosition = C1.Win.C1FlexGrid.SubtotalPositionEnum.BelowData
		Me.C1FGridResult.TabIndex = 0
		Me.C1FGridResult.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2010Black
		'
		'frmMain
		'
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
		Me.ClientSize = New System.Drawing.Size(1156, 771)
		Me.Controls.Add(Me.Panel2)
		Me.Controls.Add(Me.Panel1)
		Me.Name = "frmMain"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "frmMain"
		Me.Controls.SetChildIndex(Me.Panel1, 0)
		Me.Controls.SetChildIndex(Me.Panel2, 0)
		Me.Panel1.ResumeLayout(False)
		Me.GroupBox2.ResumeLayout(False)
		CType(Me.C1FGridSum, System.ComponentModel.ISupportInitialize).EndInit()
		Me.GroupBox1.ResumeLayout(False)
		CType(Me.btnDelete, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.txtOffice, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.txtLotID, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.C1Label3, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.btnCorrection, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.chkDeleted, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.btnAfterUpdate, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.btnCSVOut, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.btnImport, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.cmbOffice, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.C1Label2, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.btnSearch, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.dtpProcessDate, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.C1Label1, System.ComponentModel.ISupportInitialize).EndInit()
		Me.Panel2.ResumeLayout(False)
		Me.GroupBox3.ResumeLayout(False)
		CType(Me.C1FGridResult, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	Friend WithEvents Panel1 As Panel
	Friend WithEvents GroupBox2 As GroupBox
	Friend WithEvents C1FGridSum As C1.Win.C1FlexGrid.C1FlexGrid
	Friend WithEvents GroupBox1 As GroupBox
	Friend WithEvents btnAfterUpdate As C1.Win.C1Input.C1Button
	Friend WithEvents btnCSVOut As C1.Win.C1Input.C1Button
	Friend WithEvents btnImport As C1.Win.C1Input.C1Button
	Friend WithEvents cmbOffice As C1.Win.C1Input.C1ComboBox
	Friend WithEvents C1Label2 As C1.Win.C1Input.C1Label
	Friend WithEvents btnSearch As C1.Win.C1Input.C1Button
	Friend WithEvents dtpProcessDate As C1.Win.Calendar.C1DateEdit
	Friend WithEvents C1Label1 As C1.Win.C1Input.C1Label
	Friend WithEvents Panel2 As Panel
	Friend WithEvents GroupBox3 As GroupBox
	Friend WithEvents C1FGridResult As C1.Win.C1FlexGrid.C1FlexGrid
	Friend WithEvents chkDeleted As C1.Win.C1Input.C1CheckBox
	Friend WithEvents btnCorrection As C1.Win.C1Input.C1Button
	Friend WithEvents C1Label3 As C1.Win.C1Input.C1Label
	Friend WithEvents txtLotID As C1.Win.C1Input.C1TextBox
	Friend WithEvents txtOffice As C1.Win.C1Input.C1TextBox
	Friend WithEvents btnDelete As C1.Win.C1Input.C1Button
End Class
