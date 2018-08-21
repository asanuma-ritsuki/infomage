<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSelectGroup
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSelectGroup))
		Me.GroupBox1 = New System.Windows.Forms.GroupBox()
		Me.Panel1 = New System.Windows.Forms.Panel()
		Me.btnSelect = New System.Windows.Forms.Button()
		Me.btnCancel = New System.Windows.Forms.Button()
		Me.cmbPrefectures = New System.Windows.Forms.ComboBox()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.GroupBox2 = New System.Windows.Forms.GroupBox()
		Me.C1FGridMuni = New C1.Win.C1FlexGrid.C1FlexGrid()
		Me.btnSelectAll = New System.Windows.Forms.Button()
		Me.GroupBox1.SuspendLayout()
		Me.Panel1.SuspendLayout()
		Me.GroupBox2.SuspendLayout()
		CType(Me.C1FGridMuni, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'GroupBox1
		'
		Me.GroupBox1.Controls.Add(Me.cmbPrefectures)
		Me.GroupBox1.Controls.Add(Me.Label2)
		Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
		Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
		Me.GroupBox1.Name = "GroupBox1"
		Me.GroupBox1.Size = New System.Drawing.Size(1024, 70)
		Me.GroupBox1.TabIndex = 1
		Me.GroupBox1.TabStop = False
		Me.GroupBox1.Text = "検索"
		'
		'Panel1
		'
		Me.Panel1.Controls.Add(Me.btnSelectAll)
		Me.Panel1.Controls.Add(Me.btnCancel)
		Me.Panel1.Controls.Add(Me.btnSelect)
		Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
		Me.Panel1.Location = New System.Drawing.Point(0, 526)
		Me.Panel1.Name = "Panel1"
		Me.Panel1.Size = New System.Drawing.Size(1024, 35)
		Me.Panel1.TabIndex = 2
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
		'btnCancel
		'
		Me.btnCancel.Location = New System.Drawing.Point(856, 6)
		Me.btnCancel.Name = "btnCancel"
		Me.btnCancel.Size = New System.Drawing.Size(75, 25)
		Me.btnCancel.TabIndex = 1
		Me.btnCancel.Text = "キャンセル"
		Me.btnCancel.UseVisualStyleBackColor = True
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
		'GroupBox2
		'
		Me.GroupBox2.Controls.Add(Me.C1FGridMuni)
		Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
		Me.GroupBox2.Location = New System.Drawing.Point(0, 70)
		Me.GroupBox2.Name = "GroupBox2"
		Me.GroupBox2.Size = New System.Drawing.Size(1024, 456)
		Me.GroupBox2.TabIndex = 3
		Me.GroupBox2.TabStop = False
		Me.GroupBox2.Text = "自治体一覧"
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
		Me.C1FGridMuni.Size = New System.Drawing.Size(1018, 433)
		Me.C1FGridMuni.TabIndex = 6
		Me.C1FGridMuni.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.System
		'
		'btnSelectAll
		'
		Me.btnSelectAll.Location = New System.Drawing.Point(12, 6)
		Me.btnSelectAll.Name = "btnSelectAll"
		Me.btnSelectAll.Size = New System.Drawing.Size(75, 25)
		Me.btnSelectAll.TabIndex = 2
		Me.btnSelectAll.Text = "全て選択"
		Me.btnSelectAll.UseVisualStyleBackColor = True
		'
		'frmSelectGroup
		'
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
		Me.ClientSize = New System.Drawing.Size(1024, 561)
		Me.Controls.Add(Me.GroupBox2)
		Me.Controls.Add(Me.Panel1)
		Me.Controls.Add(Me.GroupBox1)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Name = "frmSelectGroup"
		Me.Text = "frmSelectGroup"
		Me.Controls.SetChildIndex(Me.GroupBox1, 0)
		Me.Controls.SetChildIndex(Me.Panel1, 0)
		Me.Controls.SetChildIndex(Me.GroupBox2, 0)
		Me.GroupBox1.ResumeLayout(False)
		Me.Panel1.ResumeLayout(False)
		Me.GroupBox2.ResumeLayout(False)
		CType(Me.C1FGridMuni, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	Friend WithEvents GroupBox1 As GroupBox
	Friend WithEvents Panel1 As Panel
	Friend WithEvents btnCancel As Button
	Friend WithEvents btnSelect As Button
	Friend WithEvents cmbPrefectures As ComboBox
	Friend WithEvents Label2 As Label
	Friend WithEvents GroupBox2 As GroupBox
	Friend WithEvents C1FGridMuni As C1.Win.C1FlexGrid.C1FlexGrid
	Friend WithEvents btnSelectAll As Button
End Class
