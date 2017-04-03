<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMasterImport
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMasterImport))
		Me.Panel2 = New System.Windows.Forms.Panel()
		Me.btnBack = New System.Windows.Forms.Button()
		Me.Panel1 = New System.Windows.Forms.Panel()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.GroupBox1 = New System.Windows.Forms.GroupBox()
		Me.Button2 = New System.Windows.Forms.Button()
		Me.Button1 = New System.Windows.Forms.Button()
		Me.TextBox2 = New System.Windows.Forms.TextBox()
		Me.TextBox1 = New System.Windows.Forms.TextBox()
		Me.Label4 = New System.Windows.Forms.Label()
		Me.Label3 = New System.Windows.Forms.Label()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.cmbUser = New System.Windows.Forms.ComboBox()
		Me.Label7 = New System.Windows.Forms.Label()
		Me.TextBox4 = New System.Windows.Forms.TextBox()
		Me.GroupBox2 = New System.Windows.Forms.GroupBox()
		Me.C1FGridProcessList = New C1.Win.C1FlexGrid.C1FlexGrid()
		Me.Panel4 = New System.Windows.Forms.Panel()
		Me.Panel5 = New System.Windows.Forms.Panel()
		Me.Panel3 = New System.Windows.Forms.Panel()
		Me.GroupBox3 = New System.Windows.Forms.GroupBox()
		Me.Panel6 = New System.Windows.Forms.Panel()
		Me.Button3 = New System.Windows.Forms.Button()
		Me.C1FlexGrid1 = New C1.Win.C1FlexGrid.C1FlexGrid()
		Me.GroupBox4 = New System.Windows.Forms.GroupBox()
		Me.C1FlexGrid2 = New C1.Win.C1FlexGrid.C1FlexGrid()
		Me.Label5 = New System.Windows.Forms.Label()
		Me.TextBox3 = New System.Windows.Forms.TextBox()
		Me.Panel2.SuspendLayout()
		Me.Panel1.SuspendLayout()
		Me.GroupBox1.SuspendLayout()
		Me.GroupBox2.SuspendLayout()
		CType(Me.C1FGridProcessList, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.Panel4.SuspendLayout()
		Me.Panel5.SuspendLayout()
		Me.Panel3.SuspendLayout()
		Me.GroupBox3.SuspendLayout()
		Me.Panel6.SuspendLayout()
		CType(Me.C1FlexGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.GroupBox4.SuspendLayout()
		CType(Me.C1FlexGrid2, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'Panel2
		'
		Me.Panel2.Controls.Add(Me.btnBack)
		Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
		Me.Panel2.Location = New System.Drawing.Point(0, 851)
		Me.Panel2.Name = "Panel2"
		Me.Panel2.Size = New System.Drawing.Size(1264, 38)
		Me.Panel2.TabIndex = 5
		'
		'btnBack
		'
		Me.btnBack.Location = New System.Drawing.Point(1172, 6)
		Me.btnBack.Name = "btnBack"
		Me.btnBack.Size = New System.Drawing.Size(80, 26)
		Me.btnBack.TabIndex = 8
		Me.btnBack.Text = "戻　る"
		Me.btnBack.UseVisualStyleBackColor = True
		'
		'Panel1
		'
		Me.Panel1.Controls.Add(Me.Label1)
		Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
		Me.Panel1.Location = New System.Drawing.Point(0, 0)
		Me.Panel1.Name = "Panel1"
		Me.Panel1.Size = New System.Drawing.Size(1264, 50)
		Me.Panel1.TabIndex = 6
		'
		'Label1
		'
		Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
		Me.Label1.Font = New System.Drawing.Font("メイリオ", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.Label1.Location = New System.Drawing.Point(0, 0)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(1264, 50)
		Me.Label1.TabIndex = 0
		Me.Label1.Text = "マスタデータインポート"
		Me.Label1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
		'
		'GroupBox1
		'
		Me.GroupBox1.Controls.Add(Me.Label5)
		Me.GroupBox1.Controls.Add(Me.TextBox3)
		Me.GroupBox1.Controls.Add(Me.Button2)
		Me.GroupBox1.Controls.Add(Me.Button1)
		Me.GroupBox1.Controls.Add(Me.TextBox2)
		Me.GroupBox1.Controls.Add(Me.TextBox1)
		Me.GroupBox1.Controls.Add(Me.Label4)
		Me.GroupBox1.Controls.Add(Me.Label3)
		Me.GroupBox1.Controls.Add(Me.Label2)
		Me.GroupBox1.Controls.Add(Me.cmbUser)
		Me.GroupBox1.Controls.Add(Me.Label7)
		Me.GroupBox1.Controls.Add(Me.TextBox4)
		Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
		Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
		Me.GroupBox1.Name = "GroupBox1"
		Me.GroupBox1.Size = New System.Drawing.Size(782, 115)
		Me.GroupBox1.TabIndex = 0
		Me.GroupBox1.TabStop = False
		Me.GroupBox1.Text = "インポートファイル情報"
		'
		'Button2
		'
		Me.Button2.Location = New System.Drawing.Point(610, 83)
		Me.Button2.Name = "Button2"
		Me.Button2.Size = New System.Drawing.Size(80, 26)
		Me.Button2.TabIndex = 30
		Me.Button2.Text = "再読込"
		Me.Button2.UseVisualStyleBackColor = True
		'
		'Button1
		'
		Me.Button1.Location = New System.Drawing.Point(696, 83)
		Me.Button1.Name = "Button1"
		Me.Button1.Size = New System.Drawing.Size(80, 26)
		Me.Button1.TabIndex = 29
		Me.Button1.Text = "インポート"
		Me.Button1.UseVisualStyleBackColor = True
		'
		'TextBox2
		'
		Me.TextBox2.Location = New System.Drawing.Point(665, 53)
		Me.TextBox2.Name = "TextBox2"
		Me.TextBox2.ReadOnly = True
		Me.TextBox2.Size = New System.Drawing.Size(111, 24)
		Me.TextBox2.TabIndex = 28
		'
		'TextBox1
		'
		Me.TextBox1.Location = New System.Drawing.Point(462, 53)
		Me.TextBox1.Name = "TextBox1"
		Me.TextBox1.ReadOnly = True
		Me.TextBox1.Size = New System.Drawing.Size(111, 24)
		Me.TextBox1.TabIndex = 27
		'
		'Label4
		'
		Me.Label4.Location = New System.Drawing.Point(579, 51)
		Me.Label4.Name = "Label4"
		Me.Label4.Size = New System.Drawing.Size(80, 26)
		Me.Label4.TabIndex = 26
		Me.Label4.Text = "レコード数："
		Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'Label3
		'
		Me.Label3.Location = New System.Drawing.Point(376, 51)
		Me.Label3.Name = "Label3"
		Me.Label3.Size = New System.Drawing.Size(80, 26)
		Me.Label3.TabIndex = 25
		Me.Label3.Text = "項目数："
		Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'Label2
		'
		Me.Label2.Location = New System.Drawing.Point(12, 51)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(120, 26)
		Me.Label2.TabIndex = 23
		Me.Label2.Text = "対象シート："
		Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'cmbUser
		'
		Me.cmbUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cmbUser.FormattingEnabled = True
		Me.cmbUser.Location = New System.Drawing.Point(141, 53)
		Me.cmbUser.Name = "cmbUser"
		Me.cmbUser.Size = New System.Drawing.Size(204, 25)
		Me.cmbUser.TabIndex = 22
		'
		'Label7
		'
		Me.Label7.Location = New System.Drawing.Point(15, 21)
		Me.Label7.Name = "Label7"
		Me.Label7.Size = New System.Drawing.Size(120, 26)
		Me.Label7.TabIndex = 20
		Me.Label7.Text = "インポートファイル："
		Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'TextBox4
		'
		Me.TextBox4.Location = New System.Drawing.Point(141, 23)
		Me.TextBox4.Name = "TextBox4"
		Me.TextBox4.Size = New System.Drawing.Size(635, 24)
		Me.TextBox4.TabIndex = 21
		'
		'GroupBox2
		'
		Me.GroupBox2.Controls.Add(Me.C1FGridProcessList)
		Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
		Me.GroupBox2.Location = New System.Drawing.Point(0, 0)
		Me.GroupBox2.Name = "GroupBox2"
		Me.GroupBox2.Size = New System.Drawing.Size(482, 115)
		Me.GroupBox2.TabIndex = 24
		Me.GroupBox2.TabStop = False
		Me.GroupBox2.Text = "インポート済情報"
		'
		'C1FGridProcessList
		'
		Me.C1FGridProcessList.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
		Me.C1FGridProcessList.AllowEditing = False
		Me.C1FGridProcessList.AllowFiltering = True
		Me.C1FGridProcessList.ColumnInfo = resources.GetString("C1FGridProcessList.ColumnInfo")
		Me.C1FGridProcessList.Dock = System.Windows.Forms.DockStyle.Fill
		Me.C1FGridProcessList.ExtendLastCol = True
		Me.C1FGridProcessList.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid
		Me.C1FGridProcessList.Font = New System.Drawing.Font("Meiryo UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.C1FGridProcessList.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcrossOut
		Me.C1FGridProcessList.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcrossOut
		Me.C1FGridProcessList.Location = New System.Drawing.Point(3, 20)
		Me.C1FGridProcessList.Name = "C1FGridProcessList"
		Me.C1FGridProcessList.Rows.Count = 1
		Me.C1FGridProcessList.Rows.DefaultSize = 20
		Me.C1FGridProcessList.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
		Me.C1FGridProcessList.Size = New System.Drawing.Size(476, 92)
		Me.C1FGridProcessList.TabIndex = 3
		Me.C1FGridProcessList.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.System
		'
		'Panel4
		'
		Me.Panel4.Controls.Add(Me.GroupBox4)
		Me.Panel4.Controls.Add(Me.GroupBox3)
		Me.Panel4.Dock = System.Windows.Forms.DockStyle.Bottom
		Me.Panel4.Location = New System.Drawing.Point(0, 165)
		Me.Panel4.Name = "Panel4"
		Me.Panel4.Size = New System.Drawing.Size(1264, 686)
		Me.Panel4.TabIndex = 25
		'
		'Panel5
		'
		Me.Panel5.Controls.Add(Me.GroupBox2)
		Me.Panel5.Dock = System.Windows.Forms.DockStyle.Right
		Me.Panel5.Location = New System.Drawing.Point(782, 50)
		Me.Panel5.Name = "Panel5"
		Me.Panel5.Size = New System.Drawing.Size(482, 115)
		Me.Panel5.TabIndex = 26
		'
		'Panel3
		'
		Me.Panel3.Controls.Add(Me.GroupBox1)
		Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
		Me.Panel3.Location = New System.Drawing.Point(0, 50)
		Me.Panel3.Name = "Panel3"
		Me.Panel3.Size = New System.Drawing.Size(782, 115)
		Me.Panel3.TabIndex = 27
		'
		'GroupBox3
		'
		Me.GroupBox3.Controls.Add(Me.C1FlexGrid1)
		Me.GroupBox3.Controls.Add(Me.Panel6)
		Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Left
		Me.GroupBox3.Location = New System.Drawing.Point(0, 0)
		Me.GroupBox3.Name = "GroupBox3"
		Me.GroupBox3.Size = New System.Drawing.Size(284, 686)
		Me.GroupBox3.TabIndex = 0
		Me.GroupBox3.TabStop = False
		Me.GroupBox3.Text = "項目設定"
		'
		'Panel6
		'
		Me.Panel6.Controls.Add(Me.Button3)
		Me.Panel6.Dock = System.Windows.Forms.DockStyle.Bottom
		Me.Panel6.Location = New System.Drawing.Point(3, 645)
		Me.Panel6.Name = "Panel6"
		Me.Panel6.Size = New System.Drawing.Size(278, 38)
		Me.Panel6.TabIndex = 0
		'
		'Button3
		'
		Me.Button3.Location = New System.Drawing.Point(195, 6)
		Me.Button3.Name = "Button3"
		Me.Button3.Size = New System.Drawing.Size(80, 26)
		Me.Button3.TabIndex = 9
		Me.Button3.Text = "検　証"
		Me.Button3.UseVisualStyleBackColor = True
		'
		'C1FlexGrid1
		'
		Me.C1FlexGrid1.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
		Me.C1FlexGrid1.AllowEditing = False
		Me.C1FlexGrid1.AllowFiltering = True
		Me.C1FlexGrid1.ColumnInfo = resources.GetString("C1FlexGrid1.ColumnInfo")
		Me.C1FlexGrid1.Dock = System.Windows.Forms.DockStyle.Fill
		Me.C1FlexGrid1.ExtendLastCol = True
		Me.C1FlexGrid1.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid
		Me.C1FlexGrid1.Font = New System.Drawing.Font("Meiryo UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.C1FlexGrid1.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcrossOut
		Me.C1FlexGrid1.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcrossOut
		Me.C1FlexGrid1.Location = New System.Drawing.Point(3, 20)
		Me.C1FlexGrid1.Name = "C1FlexGrid1"
		Me.C1FlexGrid1.Rows.Count = 1
		Me.C1FlexGrid1.Rows.DefaultSize = 20
		Me.C1FlexGrid1.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
		Me.C1FlexGrid1.Size = New System.Drawing.Size(278, 625)
		Me.C1FlexGrid1.TabIndex = 4
		Me.C1FlexGrid1.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.System
		'
		'GroupBox4
		'
		Me.GroupBox4.Controls.Add(Me.C1FlexGrid2)
		Me.GroupBox4.Dock = System.Windows.Forms.DockStyle.Fill
		Me.GroupBox4.Location = New System.Drawing.Point(284, 0)
		Me.GroupBox4.Name = "GroupBox4"
		Me.GroupBox4.Size = New System.Drawing.Size(980, 686)
		Me.GroupBox4.TabIndex = 1
		Me.GroupBox4.TabStop = False
		Me.GroupBox4.Text = "インポートデータ"
		'
		'C1FlexGrid2
		'
		Me.C1FlexGrid2.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
		Me.C1FlexGrid2.AllowEditing = False
		Me.C1FlexGrid2.AllowFiltering = True
		Me.C1FlexGrid2.ColumnInfo = resources.GetString("C1FlexGrid2.ColumnInfo")
		Me.C1FlexGrid2.Dock = System.Windows.Forms.DockStyle.Fill
		Me.C1FlexGrid2.ExtendLastCol = True
		Me.C1FlexGrid2.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid
		Me.C1FlexGrid2.Font = New System.Drawing.Font("Meiryo UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.C1FlexGrid2.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcrossOut
		Me.C1FlexGrid2.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcrossOut
		Me.C1FlexGrid2.Location = New System.Drawing.Point(3, 20)
		Me.C1FlexGrid2.Name = "C1FlexGrid2"
		Me.C1FlexGrid2.Rows.Count = 1
		Me.C1FlexGrid2.Rows.DefaultSize = 20
		Me.C1FlexGrid2.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
		Me.C1FlexGrid2.Size = New System.Drawing.Size(974, 663)
		Me.C1FlexGrid2.TabIndex = 4
		Me.C1FlexGrid2.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.System
		'
		'Label5
		'
		Me.Label5.Location = New System.Drawing.Point(15, 82)
		Me.Label5.Name = "Label5"
		Me.Label5.Size = New System.Drawing.Size(120, 26)
		Me.Label5.TabIndex = 31
		Me.Label5.Text = "定義名："
		Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'TextBox3
		'
		Me.TextBox3.Location = New System.Drawing.Point(141, 84)
		Me.TextBox3.Name = "TextBox3"
		Me.TextBox3.Size = New System.Drawing.Size(204, 24)
		Me.TextBox3.TabIndex = 32
		'
		'frmMasterImport
		'
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
		Me.ClientSize = New System.Drawing.Size(1264, 911)
		Me.Controls.Add(Me.Panel3)
		Me.Controls.Add(Me.Panel5)
		Me.Controls.Add(Me.Panel4)
		Me.Controls.Add(Me.Panel1)
		Me.Controls.Add(Me.Panel2)
		Me.KeyPreview = True
		Me.Name = "frmMasterImport"
		Me.Text = "frmMasterImport"
		Me.UserName = Nothing
		Me.Controls.SetChildIndex(Me.Panel2, 0)
		Me.Controls.SetChildIndex(Me.Panel1, 0)
		Me.Controls.SetChildIndex(Me.Panel4, 0)
		Me.Controls.SetChildIndex(Me.Panel5, 0)
		Me.Controls.SetChildIndex(Me.Panel3, 0)
		Me.Panel2.ResumeLayout(False)
		Me.Panel1.ResumeLayout(False)
		Me.GroupBox1.ResumeLayout(False)
		Me.GroupBox1.PerformLayout()
		Me.GroupBox2.ResumeLayout(False)
		CType(Me.C1FGridProcessList, System.ComponentModel.ISupportInitialize).EndInit()
		Me.Panel4.ResumeLayout(False)
		Me.Panel5.ResumeLayout(False)
		Me.Panel3.ResumeLayout(False)
		Me.GroupBox3.ResumeLayout(False)
		Me.Panel6.ResumeLayout(False)
		CType(Me.C1FlexGrid1, System.ComponentModel.ISupportInitialize).EndInit()
		Me.GroupBox4.ResumeLayout(False)
		CType(Me.C1FlexGrid2, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	Friend WithEvents Panel2 As Panel
	Friend WithEvents btnBack As Button
	Friend WithEvents Panel1 As Panel
	Friend WithEvents Label1 As Label
	Friend WithEvents GroupBox1 As GroupBox
	Friend WithEvents Label7 As Label
	Friend WithEvents TextBox4 As TextBox
	Friend WithEvents cmbUser As ComboBox
	Friend WithEvents Label4 As Label
	Friend WithEvents Label3 As Label
	Friend WithEvents GroupBox2 As GroupBox
	Friend WithEvents Label2 As Label
	Friend WithEvents TextBox1 As TextBox
	Friend WithEvents TextBox2 As TextBox
	Friend WithEvents Panel4 As Panel
	Friend WithEvents Button1 As Button
	Friend WithEvents Panel5 As Panel
	Friend WithEvents Panel3 As Panel
	Friend WithEvents Button2 As Button
	Friend WithEvents C1FGridProcessList As C1.Win.C1FlexGrid.C1FlexGrid
	Friend WithEvents GroupBox3 As GroupBox
	Friend WithEvents GroupBox4 As GroupBox
	Friend WithEvents C1FlexGrid2 As C1.Win.C1FlexGrid.C1FlexGrid
	Friend WithEvents C1FlexGrid1 As C1.Win.C1FlexGrid.C1FlexGrid
	Friend WithEvents Panel6 As Panel
	Friend WithEvents Button3 As Button
	Friend WithEvents Label5 As Label
	Friend WithEvents TextBox3 As TextBox
End Class
