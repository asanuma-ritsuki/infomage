<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProjectManage
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
		Dim PanelElement1 As C1.Win.C1Tile.PanelElement = New C1.Win.C1Tile.PanelElement()
		Dim ImageElement1 As C1.Win.C1Tile.ImageElement = New C1.Win.C1Tile.ImageElement()
		Dim TextElement1 As C1.Win.C1Tile.TextElement = New C1.Win.C1Tile.TextElement()
		Me.Panel2 = New System.Windows.Forms.Panel()
		Me.C1Sizer1 = New C1.Win.C1Sizer.C1Sizer()
		Me.GroupBox3 = New System.Windows.Forms.GroupBox()
		Me.C1TileControl1 = New C1.Win.C1Tile.C1TileControl()
		Me.Group1 = New C1.Win.C1Tile.Group()
		Me.Tile1 = New C1.Win.C1Tile.Tile()
		Me.Tile2 = New C1.Win.C1Tile.Tile()
		Me.Tile3 = New C1.Win.C1Tile.Tile()
		Me.Tile4 = New C1.Win.C1Tile.Tile()
		Me.Tile5 = New C1.Win.C1Tile.Tile()
		Me.GroupBox2 = New System.Windows.Forms.GroupBox()
		Me.GroupBox1 = New System.Windows.Forms.GroupBox()
		Me.C1FlexGrid1 = New C1.Win.C1FlexGrid.C1FlexGrid()
		Me.Panel1 = New System.Windows.Forms.Panel()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.Panel2.SuspendLayout()
		CType(Me.C1Sizer1, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.C1Sizer1.SuspendLayout()
		Me.GroupBox3.SuspendLayout()
		Me.GroupBox1.SuspendLayout()
		CType(Me.C1FlexGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.Panel1.SuspendLayout()
		Me.SuspendLayout()
		'
		'Panel2
		'
		Me.Panel2.Controls.Add(Me.C1Sizer1)
		Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
		Me.Panel2.Location = New System.Drawing.Point(0, 50)
		Me.Panel2.Name = "Panel2"
		Me.Panel2.Size = New System.Drawing.Size(1184, 711)
		Me.Panel2.TabIndex = 1
		'
		'C1Sizer1
		'
		Me.C1Sizer1.Controls.Add(Me.GroupBox3)
		Me.C1Sizer1.Controls.Add(Me.GroupBox2)
		Me.C1Sizer1.Controls.Add(Me.GroupBox1)
		Me.C1Sizer1.Dock = System.Windows.Forms.DockStyle.Fill
		Me.C1Sizer1.GridDefinition = "74.1209563994374:False:False;24.1912798874824:False:True;" & Global.Microsoft.VisualBasic.ChrW(9) & "46.6216216216216:False:" &
	"False;52.3648648648649:False:True;"
		Me.C1Sizer1.Location = New System.Drawing.Point(0, 0)
		Me.C1Sizer1.Name = "C1Sizer1"
		Me.C1Sizer1.Size = New System.Drawing.Size(1184, 711)
		Me.C1Sizer1.TabIndex = 0
		Me.C1Sizer1.Text = "C1Sizer1"
		'
		'GroupBox3
		'
		Me.GroupBox3.Controls.Add(Me.C1TileControl1)
		Me.GroupBox3.Location = New System.Drawing.Point(560, 535)
		Me.GroupBox3.Name = "GroupBox3"
		Me.GroupBox3.Size = New System.Drawing.Size(620, 172)
		Me.GroupBox3.TabIndex = 2
		Me.GroupBox3.TabStop = False
		Me.GroupBox3.Text = "ボタン関連"
		'
		'C1TileControl1
		'
		Me.C1TileControl1.AllowChecking = True
		Me.C1TileControl1.AllowRearranging = True
		Me.C1TileControl1.CellHeight = 80
		Me.C1TileControl1.CellWidth = 80
		'
		'
		'
		PanelElement1.Alignment = System.Drawing.ContentAlignment.BottomLeft
		PanelElement1.Children.Add(ImageElement1)
		PanelElement1.Children.Add(TextElement1)
		PanelElement1.Margin = New System.Windows.Forms.Padding(10, 6, 10, 6)
		Me.C1TileControl1.DefaultTemplate.Elements.Add(PanelElement1)
		Me.C1TileControl1.Dock = System.Windows.Forms.DockStyle.Fill
		Me.C1TileControl1.GroupPadding = New System.Windows.Forms.Padding(20)
		Me.C1TileControl1.Groups.Add(Me.Group1)
		Me.C1TileControl1.Location = New System.Drawing.Point(3, 20)
		Me.C1TileControl1.Name = "C1TileControl1"
		Me.C1TileControl1.Padding = New System.Windows.Forms.Padding(0)
		Me.C1TileControl1.Size = New System.Drawing.Size(614, 149)
		Me.C1TileControl1.TabIndex = 0
		'
		'Group1
		'
		Me.Group1.Name = "Group1"
		Me.Group1.Tiles.Add(Me.Tile1)
		Me.Group1.Tiles.Add(Me.Tile2)
		Me.Group1.Tiles.Add(Me.Tile3)
		Me.Group1.Tiles.Add(Me.Tile4)
		Me.Group1.Tiles.Add(Me.Tile5)
		'
		'Tile1
		'
		Me.Tile1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(81, Byte), Integer), CType(CType(148, Byte), Integer))
		Me.Tile1.Name = "Tile1"
		Me.Tile1.Text = "タイル１"
		'
		'Tile2
		'
		Me.Tile2.BackColor = System.Drawing.Color.FromArgb(CType(CType(67, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(148, Byte), Integer))
		Me.Tile2.Name = "Tile2"
		Me.Tile2.Text = "タイル２"
		'
		'Tile3
		'
		Me.Tile3.BackColor = System.Drawing.Color.FromArgb(CType(CType(148, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(81, Byte), Integer))
		Me.Tile3.Name = "Tile3"
		Me.Tile3.Text = "タイル３"
		'
		'Tile4
		'
		Me.Tile4.BackColor = System.Drawing.Color.FromArgb(CType(CType(148, Byte), Integer), CType(CType(67, Byte), Integer), CType(CType(0, Byte), Integer))
		Me.Tile4.Name = "Tile4"
		Me.Tile4.Text = "タイル ４"
		'
		'Tile5
		'
		Me.Tile5.BackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(0, Byte), Integer))
		Me.Tile5.Name = "Tile5"
		Me.Tile5.Text = "タイル ５"
		'
		'GroupBox2
		'
		Me.GroupBox2.Location = New System.Drawing.Point(4, 535)
		Me.GroupBox2.Name = "GroupBox2"
		Me.GroupBox2.Size = New System.Drawing.Size(552, 172)
		Me.GroupBox2.TabIndex = 1
		Me.GroupBox2.TabStop = False
		Me.GroupBox2.Text = "検索"
		'
		'GroupBox1
		'
		Me.GroupBox1.Controls.Add(Me.C1FlexGrid1)
		Me.GroupBox1.Location = New System.Drawing.Point(4, 4)
		Me.GroupBox1.Name = "GroupBox1"
		Me.GroupBox1.Size = New System.Drawing.Size(1176, 527)
		Me.GroupBox1.TabIndex = 0
		Me.GroupBox1.TabStop = False
		Me.GroupBox1.Text = "プロジェクト一覧"
		'
		'C1FlexGrid1
		'
		Me.C1FlexGrid1.AllowFiltering = True
		Me.C1FlexGrid1.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
		Me.C1FlexGrid1.ColumnInfo = "10,1,0,0,0,115,Columns:"
		Me.C1FlexGrid1.Dock = System.Windows.Forms.DockStyle.Fill
		Me.C1FlexGrid1.Location = New System.Drawing.Point(3, 20)
		Me.C1FlexGrid1.Name = "C1FlexGrid1"
		Me.C1FlexGrid1.Rows.DefaultSize = 23
		Me.C1FlexGrid1.Size = New System.Drawing.Size(1170, 504)
		Me.C1FlexGrid1.TabIndex = 0
		'
		'Panel1
		'
		Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
		Me.Panel1.Controls.Add(Me.Label1)
		Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
		Me.Panel1.Location = New System.Drawing.Point(0, 0)
		Me.Panel1.Name = "Panel1"
		Me.Panel1.Size = New System.Drawing.Size(1184, 50)
		Me.Panel1.TabIndex = 0
		'
		'Label1
		'
		Me.Label1.AutoSize = True
		Me.Label1.Location = New System.Drawing.Point(21, 18)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(59, 17)
		Me.Label1.TabIndex = 1
		Me.Label1.Text = "タイトル部"
		'
		'frmProjectManage
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 17.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(1184, 761)
		Me.Controls.Add(Me.Panel2)
		Me.Controls.Add(Me.Panel1)
		Me.Name = "frmProjectManage"
		Me.Text = "frmProjectManage"
		Me.Panel2.ResumeLayout(False)
		CType(Me.C1Sizer1, System.ComponentModel.ISupportInitialize).EndInit()
		Me.C1Sizer1.ResumeLayout(False)
		Me.GroupBox3.ResumeLayout(False)
		Me.GroupBox1.ResumeLayout(False)
		CType(Me.C1FlexGrid1, System.ComponentModel.ISupportInitialize).EndInit()
		Me.Panel1.ResumeLayout(False)
		Me.Panel1.PerformLayout()
		Me.ResumeLayout(False)

	End Sub

	Friend WithEvents Panel1 As Panel
	Friend WithEvents Label1 As Label
	Friend WithEvents Panel2 As Panel
	Friend WithEvents C1Sizer1 As C1.Win.C1Sizer.C1Sizer
	Friend WithEvents GroupBox3 As GroupBox
	Friend WithEvents GroupBox2 As GroupBox
	Friend WithEvents GroupBox1 As GroupBox
	Friend WithEvents C1FlexGrid1 As C1.Win.C1FlexGrid.C1FlexGrid
	Friend WithEvents C1TileControl1 As C1.Win.C1Tile.C1TileControl
	Friend WithEvents Group1 As C1.Win.C1Tile.Group
	Friend WithEvents Tile1 As C1.Win.C1Tile.Tile
	Friend WithEvents Tile2 As C1.Win.C1Tile.Tile
	Friend WithEvents Tile3 As C1.Win.C1Tile.Tile
	Friend WithEvents Tile4 As C1.Win.C1Tile.Tile
	Friend WithEvents Tile5 As C1.Win.C1Tile.Tile
End Class
