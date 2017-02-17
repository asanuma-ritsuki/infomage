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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmProjectManage))
		Me.Panel2 = New System.Windows.Forms.Panel()
		Me.C1Sizer1 = New C1.Win.C1Sizer.C1Sizer()
		Me.Panel3 = New System.Windows.Forms.Panel()
		Me.GroupBox4 = New System.Windows.Forms.GroupBox()
		Me.C1FlexGrid2 = New C1.Win.C1FlexGrid.C1FlexGrid()
		Me.GroupBox1 = New System.Windows.Forms.GroupBox()
		Me.C1FlexGrid1 = New C1.Win.C1FlexGrid.C1FlexGrid()
		Me.GroupBox3 = New System.Windows.Forms.GroupBox()
		Me.C1Button1 = New C1.Win.C1Input.C1Button()
		Me.btnExit = New C1.Win.C1Input.C1Button()
		Me.GroupBox2 = New System.Windows.Forms.GroupBox()
		Me.btnSearch = New C1.Win.C1Input.C1Button()
		Me.Panel1 = New System.Windows.Forms.Panel()
		Me.C1Label1 = New C1.Win.C1Input.C1Label()
		Me.Panel2.SuspendLayout()
		CType(Me.C1Sizer1, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.C1Sizer1.SuspendLayout()
		Me.Panel3.SuspendLayout()
		Me.GroupBox4.SuspendLayout()
		CType(Me.C1FlexGrid2, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.GroupBox1.SuspendLayout()
		CType(Me.C1FlexGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.GroupBox3.SuspendLayout()
		CType(Me.C1Button1, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.btnExit, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.GroupBox2.SuspendLayout()
		CType(Me.btnSearch, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.Panel1.SuspendLayout()
		CType(Me.C1Label1, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'Panel2
		'
		Me.Panel2.Controls.Add(Me.C1Sizer1)
		Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
		Me.Panel2.Location = New System.Drawing.Point(0, 50)
		Me.Panel2.Name = "Panel2"
		Me.Panel2.Size = New System.Drawing.Size(1184, 689)
		Me.Panel2.TabIndex = 1
		'
		'C1Sizer1
		'
		Me.C1Sizer1.Controls.Add(Me.Panel3)
		Me.C1Sizer1.Controls.Add(Me.GroupBox3)
		Me.C1Sizer1.Controls.Add(Me.GroupBox2)
		Me.C1Sizer1.Dock = System.Windows.Forms.DockStyle.Fill
		Me.C1Sizer1.GridDefinition = "79.9709724238026:False:False;18.2873730043541:False:True;" & Global.Microsoft.VisualBasic.ChrW(9) & "46.6216216216216:False:" &
	"False;52.3648648648649:False:True;"
		Me.C1Sizer1.Location = New System.Drawing.Point(0, 0)
		Me.C1Sizer1.Name = "C1Sizer1"
		Me.C1Sizer1.Size = New System.Drawing.Size(1184, 689)
		Me.C1Sizer1.TabIndex = 0
		Me.C1Sizer1.Text = "C1Sizer1"
		'
		'Panel3
		'
		Me.Panel3.Controls.Add(Me.GroupBox4)
		Me.Panel3.Controls.Add(Me.GroupBox1)
		Me.Panel3.Location = New System.Drawing.Point(4, 4)
		Me.Panel3.Name = "Panel3"
		Me.Panel3.Size = New System.Drawing.Size(1176, 551)
		Me.Panel3.TabIndex = 3
		'
		'GroupBox4
		'
		Me.GroupBox4.Controls.Add(Me.C1FlexGrid2)
		Me.GroupBox4.Dock = System.Windows.Forms.DockStyle.Fill
		Me.GroupBox4.Location = New System.Drawing.Point(0, 0)
		Me.GroupBox4.Name = "GroupBox4"
		Me.GroupBox4.Size = New System.Drawing.Size(803, 551)
		Me.GroupBox4.TabIndex = 1
		Me.GroupBox4.TabStop = False
		Me.GroupBox4.Text = "プロジェクト一覧"
		'
		'C1FlexGrid2
		'
		Me.C1FlexGrid2.AllowEditing = False
		Me.C1FlexGrid2.AllowFiltering = True
		Me.C1FlexGrid2.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
		Me.C1FlexGrid2.ColumnInfo = resources.GetString("C1FlexGrid2.ColumnInfo")
		Me.C1FlexGrid2.Dock = System.Windows.Forms.DockStyle.Fill
		Me.C1FlexGrid2.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.C1FlexGrid2.Location = New System.Drawing.Point(3, 23)
		Me.C1FlexGrid2.Name = "C1FlexGrid2"
		Me.C1FlexGrid2.Rows.DefaultSize = 23
		Me.C1FlexGrid2.Size = New System.Drawing.Size(797, 525)
		Me.C1FlexGrid2.TabIndex = 1
		'
		'GroupBox1
		'
		Me.GroupBox1.Controls.Add(Me.C1FlexGrid1)
		Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Right
		Me.GroupBox1.Location = New System.Drawing.Point(803, 0)
		Me.GroupBox1.Name = "GroupBox1"
		Me.GroupBox1.Size = New System.Drawing.Size(373, 551)
		Me.GroupBox1.TabIndex = 0
		Me.GroupBox1.TabStop = False
		Me.GroupBox1.Text = "進捗"
		'
		'C1FlexGrid1
		'
		Me.C1FlexGrid1.AllowEditing = False
		Me.C1FlexGrid1.AllowFiltering = True
		Me.C1FlexGrid1.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
		Me.C1FlexGrid1.ColumnInfo = resources.GetString("C1FlexGrid1.ColumnInfo")
		Me.C1FlexGrid1.Dock = System.Windows.Forms.DockStyle.Fill
		Me.C1FlexGrid1.ExtendLastCol = True
		Me.C1FlexGrid1.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.C1FlexGrid1.Location = New System.Drawing.Point(3, 23)
		Me.C1FlexGrid1.Name = "C1FlexGrid1"
		Me.C1FlexGrid1.Rows.DefaultSize = 23
		Me.C1FlexGrid1.Size = New System.Drawing.Size(367, 525)
		Me.C1FlexGrid1.TabIndex = 0
		'
		'GroupBox3
		'
		Me.GroupBox3.Controls.Add(Me.C1Button1)
		Me.GroupBox3.Controls.Add(Me.btnExit)
		Me.GroupBox3.Location = New System.Drawing.Point(560, 559)
		Me.GroupBox3.Name = "GroupBox3"
		Me.GroupBox3.Size = New System.Drawing.Size(620, 126)
		Me.GroupBox3.TabIndex = 2
		Me.GroupBox3.TabStop = False
		Me.GroupBox3.Text = "ボタン関連"
		'
		'C1Button1
		'
		Me.C1Button1.Location = New System.Drawing.Point(6, 26)
		Me.C1Button1.Name = "C1Button1"
		Me.C1Button1.Size = New System.Drawing.Size(100, 26)
		Me.C1Button1.TabIndex = 10
		Me.C1Button1.Text = "ユーザー管理"
		Me.C1Button1.UseVisualStyleBackColor = True
		'
		'btnExit
		'
		Me.btnExit.Location = New System.Drawing.Point(532, 94)
		Me.btnExit.Name = "btnExit"
		Me.btnExit.Size = New System.Drawing.Size(80, 26)
		Me.btnExit.TabIndex = 9
		Me.btnExit.Text = "終　了"
		Me.btnExit.UseVisualStyleBackColor = True
		'
		'GroupBox2
		'
		Me.GroupBox2.Controls.Add(Me.btnSearch)
		Me.GroupBox2.Location = New System.Drawing.Point(4, 559)
		Me.GroupBox2.Name = "GroupBox2"
		Me.GroupBox2.Size = New System.Drawing.Size(552, 126)
		Me.GroupBox2.TabIndex = 1
		Me.GroupBox2.TabStop = False
		Me.GroupBox2.Text = "検索"
		'
		'btnSearch
		'
		Me.btnSearch.Location = New System.Drawing.Point(466, 26)
		Me.btnSearch.Name = "btnSearch"
		Me.btnSearch.Size = New System.Drawing.Size(80, 26)
		Me.btnSearch.TabIndex = 10
		Me.btnSearch.Text = "検　索"
		Me.btnSearch.UseVisualStyleBackColor = True
		'
		'Panel1
		'
		Me.Panel1.BackColor = System.Drawing.Color.Transparent
		Me.Panel1.Controls.Add(Me.C1Label1)
		Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
		Me.Panel1.Location = New System.Drawing.Point(0, 0)
		Me.Panel1.Name = "Panel1"
		Me.Panel1.Size = New System.Drawing.Size(1184, 50)
		Me.Panel1.TabIndex = 0
		'
		'C1Label1
		'
		Me.C1Label1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.C1Label1.Dock = System.Windows.Forms.DockStyle.Fill
		Me.C1Label1.Font = New System.Drawing.Font("Meiryo UI", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.C1Label1.Location = New System.Drawing.Point(0, 0)
		Me.C1Label1.Name = "C1Label1"
		Me.C1Label1.Size = New System.Drawing.Size(1184, 50)
		Me.C1Label1.TabIndex = 1
		Me.C1Label1.Tag = Nothing
		Me.C1Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.C1Label1.Value = "プロジェクト一覧"
		'
		'frmProjectManage
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 19.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(1184, 761)
		Me.Controls.Add(Me.Panel2)
		Me.Controls.Add(Me.Panel1)
		Me.Name = "frmProjectManage"
		Me.Text = "frmProjectManage"
		Me.UserName = Nothing
		Me.Controls.SetChildIndex(Me.Panel1, 0)
		Me.Controls.SetChildIndex(Me.Panel2, 0)
		Me.Panel2.ResumeLayout(False)
		CType(Me.C1Sizer1, System.ComponentModel.ISupportInitialize).EndInit()
		Me.C1Sizer1.ResumeLayout(False)
		Me.Panel3.ResumeLayout(False)
		Me.GroupBox4.ResumeLayout(False)
		CType(Me.C1FlexGrid2, System.ComponentModel.ISupportInitialize).EndInit()
		Me.GroupBox1.ResumeLayout(False)
		CType(Me.C1FlexGrid1, System.ComponentModel.ISupportInitialize).EndInit()
		Me.GroupBox3.ResumeLayout(False)
		CType(Me.C1Button1, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.btnExit, System.ComponentModel.ISupportInitialize).EndInit()
		Me.GroupBox2.ResumeLayout(False)
		CType(Me.btnSearch, System.ComponentModel.ISupportInitialize).EndInit()
		Me.Panel1.ResumeLayout(False)
		CType(Me.C1Label1, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	Friend WithEvents Panel1 As Panel
	Friend WithEvents Panel2 As Panel
	Friend WithEvents C1Sizer1 As C1.Win.C1Sizer.C1Sizer
	Friend WithEvents GroupBox3 As GroupBox
	Friend WithEvents GroupBox2 As GroupBox
	Friend WithEvents C1Label1 As C1.Win.C1Input.C1Label
	Friend WithEvents Panel3 As Panel
	Friend WithEvents GroupBox4 As GroupBox
	Friend WithEvents GroupBox1 As GroupBox
	Friend WithEvents C1FlexGrid2 As C1.Win.C1FlexGrid.C1FlexGrid
	Friend WithEvents C1FlexGrid1 As C1.Win.C1FlexGrid.C1FlexGrid
	Friend WithEvents C1Button1 As C1.Win.C1Input.C1Button
	Friend WithEvents btnExit As C1.Win.C1Input.C1Button
	Friend WithEvents btnSearch As C1.Win.C1Input.C1Button
End Class
