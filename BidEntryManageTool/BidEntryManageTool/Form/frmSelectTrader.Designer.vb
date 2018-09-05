<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSelectTrader
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSelectTrader))
		Me.GroupBox2 = New System.Windows.Forms.GroupBox()
		Me.C1FGridResult = New C1.Win.C1FlexGrid.C1FlexGrid()
		Me.Panel1 = New System.Windows.Forms.Panel()
		Me.btnCancel = New System.Windows.Forms.Button()
		Me.btnSelect = New System.Windows.Forms.Button()
		Me.GroupBox1 = New System.Windows.Forms.GroupBox()
		Me.btnSearch = New System.Windows.Forms.Button()
		Me.txtTraderName = New System.Windows.Forms.TextBox()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.cmbPrefectures = New System.Windows.Forms.ComboBox()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.GroupBox2.SuspendLayout()
		CType(Me.C1FGridResult, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.Panel1.SuspendLayout()
		Me.GroupBox1.SuspendLayout()
		Me.SuspendLayout()
		'
		'GroupBox2
		'
		Me.GroupBox2.Controls.Add(Me.C1FGridResult)
		Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
		Me.GroupBox2.Location = New System.Drawing.Point(0, 70)
		Me.GroupBox2.Name = "GroupBox2"
		Me.GroupBox2.Size = New System.Drawing.Size(1024, 434)
		Me.GroupBox2.TabIndex = 6
		Me.GroupBox2.TabStop = False
		Me.GroupBox2.Text = "自治体一覧"
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
		Me.C1FGridResult.Size = New System.Drawing.Size(1018, 411)
		Me.C1FGridResult.TabIndex = 6
		Me.C1FGridResult.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.System
		'
		'Panel1
		'
		Me.Panel1.Controls.Add(Me.btnCancel)
		Me.Panel1.Controls.Add(Me.btnSelect)
		Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
		Me.Panel1.Location = New System.Drawing.Point(0, 504)
		Me.Panel1.Name = "Panel1"
		Me.Panel1.Size = New System.Drawing.Size(1024, 35)
		Me.Panel1.TabIndex = 5
		'
		'btnCancel
		'
		Me.btnCancel.Location = New System.Drawing.Point(856, 6)
		Me.btnCancel.Name = "btnCancel"
		Me.btnCancel.Size = New System.Drawing.Size(75, 25)
		Me.btnCancel.TabIndex = 1
		Me.btnCancel.Text = "キャンセル"
		Me.btnCancel.UseVisualStyleBackColor = True
		'
		'btnSelect
		'
		Me.btnSelect.Location = New System.Drawing.Point(937, 6)
		Me.btnSelect.Name = "btnSelect"
		Me.btnSelect.Size = New System.Drawing.Size(75, 25)
		Me.btnSelect.TabIndex = 0
		Me.btnSelect.Text = "選　択"
		Me.btnSelect.UseVisualStyleBackColor = True
		'
		'GroupBox1
		'
		Me.GroupBox1.Controls.Add(Me.btnSearch)
		Me.GroupBox1.Controls.Add(Me.txtTraderName)
		Me.GroupBox1.Controls.Add(Me.Label1)
		Me.GroupBox1.Controls.Add(Me.cmbPrefectures)
		Me.GroupBox1.Controls.Add(Me.Label2)
		Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
		Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
		Me.GroupBox1.Name = "GroupBox1"
		Me.GroupBox1.Size = New System.Drawing.Size(1024, 70)
		Me.GroupBox1.TabIndex = 4
		Me.GroupBox1.TabStop = False
		Me.GroupBox1.Text = "検索"
		'
		'btnSearch
		'
		Me.btnSearch.Location = New System.Drawing.Point(937, 23)
		Me.btnSearch.Name = "btnSearch"
		Me.btnSearch.Size = New System.Drawing.Size(75, 25)
		Me.btnSearch.TabIndex = 9
		Me.btnSearch.Text = "検　索"
		Me.btnSearch.UseVisualStyleBackColor = True
		'
		'txtTraderName
		'
		Me.txtTraderName.ImeMode = System.Windows.Forms.ImeMode.Hiragana
		Me.txtTraderName.Location = New System.Drawing.Point(353, 24)
		Me.txtTraderName.Name = "txtTraderName"
		Me.txtTraderName.Size = New System.Drawing.Size(278, 24)
		Me.txtTraderName.TabIndex = 8
		'
		'Label1
		'
		Me.Label1.Location = New System.Drawing.Point(247, 23)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(100, 25)
		Me.Label1.TabIndex = 7
		Me.Label1.Text = "業者名："
		Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'cmbPrefectures
		'
		Me.cmbPrefectures.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cmbPrefectures.FormattingEnabled = True
		Me.cmbPrefectures.Location = New System.Drawing.Point(120, 23)
		Me.cmbPrefectures.Name = "cmbPrefectures"
		Me.cmbPrefectures.Size = New System.Drawing.Size(121, 25)
		Me.cmbPrefectures.TabIndex = 6
		'
		'Label2
		'
		Me.Label2.Location = New System.Drawing.Point(14, 23)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(100, 25)
		Me.Label2.TabIndex = 5
		Me.Label2.Text = "都道府県："
		Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'frmSelectTrader
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 17.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.CaptionDisplayMode = BidEntryManageTool.frmTempForm.StatusDisplayMode.ShowAll
		Me.ClientSize = New System.Drawing.Size(1024, 561)
		Me.Controls.Add(Me.GroupBox2)
		Me.Controls.Add(Me.Panel1)
		Me.Controls.Add(Me.GroupBox1)
		Me.Name = "frmSelectTrader"
		Me.Text = "frmSelectTrader"
		Me.Controls.SetChildIndex(Me.GroupBox1, 0)
		Me.Controls.SetChildIndex(Me.Panel1, 0)
		Me.Controls.SetChildIndex(Me.GroupBox2, 0)
		Me.GroupBox2.ResumeLayout(False)
		CType(Me.C1FGridResult, System.ComponentModel.ISupportInitialize).EndInit()
		Me.Panel1.ResumeLayout(False)
		Me.GroupBox1.ResumeLayout(False)
		Me.GroupBox1.PerformLayout()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	Friend WithEvents GroupBox2 As GroupBox
	Friend WithEvents C1FGridResult As C1.Win.C1FlexGrid.C1FlexGrid
	Friend WithEvents Panel1 As Panel
	Friend WithEvents btnCancel As Button
	Friend WithEvents btnSelect As Button
	Friend WithEvents GroupBox1 As GroupBox
	Friend WithEvents cmbPrefectures As ComboBox
	Friend WithEvents Label2 As Label
	Friend WithEvents Label1 As Label
	Friend WithEvents btnSearch As Button
	Friend WithEvents txtTraderName As TextBox
End Class
