<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOperation
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmOperation))
		Me.GroupBox1 = New System.Windows.Forms.GroupBox()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.cmbTrader = New System.Windows.Forms.ComboBox()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.cmbPrefectures = New System.Windows.Forms.ComboBox()
		Me.C1FGridMuni = New C1.Win.C1FlexGrid.C1FlexGrid()
		Me.GroupBox3 = New System.Windows.Forms.GroupBox()
		Me.C1FGridResult = New C1.Win.C1FlexGrid.C1FlexGrid()
		Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
		Me.GroupBox2 = New System.Windows.Forms.GroupBox()
		Me.GroupBox1.SuspendLayout()
		CType(Me.C1FGridMuni, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.GroupBox3.SuspendLayout()
		CType(Me.C1FGridResult, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SplitContainer1.Panel1.SuspendLayout()
		Me.SplitContainer1.Panel2.SuspendLayout()
		Me.SplitContainer1.SuspendLayout()
		Me.GroupBox2.SuspendLayout()
		Me.SuspendLayout()
		'
		'GroupBox1
		'
		Me.GroupBox1.Controls.Add(Me.Label2)
		Me.GroupBox1.Controls.Add(Me.cmbTrader)
		Me.GroupBox1.Controls.Add(Me.Label1)
		Me.GroupBox1.Controls.Add(Me.cmbPrefectures)
		Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
		Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
		Me.GroupBox1.Name = "GroupBox1"
		Me.GroupBox1.Size = New System.Drawing.Size(1264, 100)
		Me.GroupBox1.TabIndex = 1
		Me.GroupBox1.TabStop = False
		Me.GroupBox1.Text = "検索"
		'
		'Label2
		'
		Me.Label2.Location = New System.Drawing.Point(11, 54)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(100, 25)
		Me.Label2.TabIndex = 3
		Me.Label2.Text = "業者："
		Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'cmbTrader
		'
		Me.cmbTrader.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cmbTrader.FormattingEnabled = True
		Me.cmbTrader.Location = New System.Drawing.Point(117, 54)
		Me.cmbTrader.Name = "cmbTrader"
		Me.cmbTrader.Size = New System.Drawing.Size(300, 25)
		Me.cmbTrader.TabIndex = 2
		'
		'Label1
		'
		Me.Label1.Location = New System.Drawing.Point(11, 23)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(100, 25)
		Me.Label1.TabIndex = 1
		Me.Label1.Text = "都道府県："
		Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'cmbPrefectures
		'
		Me.cmbPrefectures.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cmbPrefectures.FormattingEnabled = True
		Me.cmbPrefectures.Location = New System.Drawing.Point(117, 23)
		Me.cmbPrefectures.Name = "cmbPrefectures"
		Me.cmbPrefectures.Size = New System.Drawing.Size(121, 25)
		Me.cmbPrefectures.TabIndex = 0
		'
		'C1FGridMuni
		'
		Me.C1FGridMuni.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
		Me.C1FGridMuni.AllowEditing = False
		Me.C1FGridMuni.AllowFiltering = True
		Me.C1FGridMuni.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
		Me.C1FGridMuni.AutoClipboard = True
		Me.C1FGridMuni.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
		Me.C1FGridMuni.ColumnInfo = resources.GetString("C1FGridMuni.ColumnInfo")
		Me.C1FGridMuni.Dock = System.Windows.Forms.DockStyle.Fill
		Me.C1FGridMuni.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid
		Me.C1FGridMuni.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.C1FGridMuni.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcrossOut
		Me.C1FGridMuni.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcrossOut
		Me.C1FGridMuni.Location = New System.Drawing.Point(3, 20)
		Me.C1FGridMuni.Name = "C1FGridMuni"
		Me.C1FGridMuni.Rows.Count = 1
		Me.C1FGridMuni.Rows.DefaultSize = 23
		Me.C1FGridMuni.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
		Me.C1FGridMuni.ShowCellLabels = True
		Me.C1FGridMuni.Size = New System.Drawing.Size(322, 583)
		Me.C1FGridMuni.TabIndex = 5
		Me.C1FGridMuni.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.System
		'
		'GroupBox3
		'
		Me.GroupBox3.Controls.Add(Me.C1FGridResult)
		Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Fill
		Me.GroupBox3.Location = New System.Drawing.Point(0, 0)
		Me.GroupBox3.Name = "GroupBox3"
		Me.GroupBox3.Size = New System.Drawing.Size(932, 606)
		Me.GroupBox3.TabIndex = 3
		Me.GroupBox3.TabStop = False
		Me.GroupBox3.Text = "電子調達システム・業者"
		'
		'C1FGridResult
		'
		Me.C1FGridResult.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
		Me.C1FGridResult.AllowEditing = False
		Me.C1FGridResult.AllowFiltering = True
		Me.C1FGridResult.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
		Me.C1FGridResult.AutoClipboard = True
		Me.C1FGridResult.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
		Me.C1FGridResult.ColumnInfo = resources.GetString("C1FGridResult.ColumnInfo")
		Me.C1FGridResult.Dock = System.Windows.Forms.DockStyle.Fill
		Me.C1FGridResult.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid
		Me.C1FGridResult.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.C1FGridResult.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcrossOut
		Me.C1FGridResult.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcrossOut
		Me.C1FGridResult.Location = New System.Drawing.Point(3, 20)
		Me.C1FGridResult.Name = "C1FGridResult"
		Me.C1FGridResult.Rows.Count = 1
		Me.C1FGridResult.Rows.DefaultSize = 23
		Me.C1FGridResult.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
		Me.C1FGridResult.ShowCellLabels = True
		Me.C1FGridResult.Size = New System.Drawing.Size(926, 583)
		Me.C1FGridResult.TabIndex = 4
		Me.C1FGridResult.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.System
		'
		'SplitContainer1
		'
		Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
		Me.SplitContainer1.Location = New System.Drawing.Point(0, 100)
		Me.SplitContainer1.Name = "SplitContainer1"
		'
		'SplitContainer1.Panel1
		'
		Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox3)
		'
		'SplitContainer1.Panel2
		'
		Me.SplitContainer1.Panel2.Controls.Add(Me.GroupBox2)
		Me.SplitContainer1.Size = New System.Drawing.Size(1264, 606)
		Me.SplitContainer1.SplitterDistance = 932
		Me.SplitContainer1.TabIndex = 3
		'
		'GroupBox2
		'
		Me.GroupBox2.Controls.Add(Me.C1FGridMuni)
		Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
		Me.GroupBox2.Location = New System.Drawing.Point(0, 0)
		Me.GroupBox2.Name = "GroupBox2"
		Me.GroupBox2.Size = New System.Drawing.Size(328, 606)
		Me.GroupBox2.TabIndex = 0
		Me.GroupBox2.TabStop = False
		Me.GroupBox2.Text = "自治体登録"
		'
		'frmOperation
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 17.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.CaptionDisplayMode = BidEntryManageTool.frmTempForm.StatusDisplayMode.ShowAll
		Me.ClientSize = New System.Drawing.Size(1264, 729)
		Me.Controls.Add(Me.SplitContainer1)
		Me.Controls.Add(Me.GroupBox1)
		Me.Name = "frmOperation"
		Me.Text = "frmOperation"
		Me.Controls.SetChildIndex(Me.GroupBox1, 0)
		Me.Controls.SetChildIndex(Me.SplitContainer1, 0)
		Me.GroupBox1.ResumeLayout(False)
		CType(Me.C1FGridMuni, System.ComponentModel.ISupportInitialize).EndInit()
		Me.GroupBox3.ResumeLayout(False)
		CType(Me.C1FGridResult, System.ComponentModel.ISupportInitialize).EndInit()
		Me.SplitContainer1.Panel1.ResumeLayout(False)
		Me.SplitContainer1.Panel2.ResumeLayout(False)
		CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
		Me.SplitContainer1.ResumeLayout(False)
		Me.GroupBox2.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	Friend WithEvents GroupBox1 As GroupBox
	Friend WithEvents GroupBox3 As GroupBox
	Friend WithEvents C1FGridMuni As C1.Win.C1FlexGrid.C1FlexGrid
	Friend WithEvents C1FGridResult As C1.Win.C1FlexGrid.C1FlexGrid
	Friend WithEvents Label2 As Label
	Friend WithEvents cmbTrader As ComboBox
	Friend WithEvents Label1 As Label
	Friend WithEvents cmbPrefectures As ComboBox
	Friend WithEvents SplitContainer1 As SplitContainer
	Friend WithEvents GroupBox2 As GroupBox
End Class
