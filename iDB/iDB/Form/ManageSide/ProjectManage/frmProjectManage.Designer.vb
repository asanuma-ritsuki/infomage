<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmProjectManage
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmProjectManage))
		Me.Panel2 = New System.Windows.Forms.Panel()
		Me.C1Sizer1 = New C1.Win.C1Sizer.C1Sizer()
		Me.Panel3 = New System.Windows.Forms.Panel()
		Me.GroupBox4 = New System.Windows.Forms.GroupBox()
		Me.C1FlexGrid2 = New C1.Win.C1FlexGrid.C1FlexGrid()
		Me.GroupBox3 = New System.Windows.Forms.GroupBox()
		Me.btnProjectDetail = New C1.Win.C1Input.C1Button()
		Me.btnNewProject = New C1.Win.C1Input.C1Button()
		Me.C1Button1 = New C1.Win.C1Input.C1Button()
		Me.btnExit = New C1.Win.C1Input.C1Button()
		Me.Panel1 = New System.Windows.Forms.Panel()
		Me.C1Label1 = New C1.Win.C1Input.C1Label()
		Me.Panel2.SuspendLayout()
		CType(Me.C1Sizer1, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.C1Sizer1.SuspendLayout()
		Me.Panel3.SuspendLayout()
		Me.GroupBox4.SuspendLayout()
		CType(Me.C1FlexGrid2, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.GroupBox3.SuspendLayout()
		CType(Me.btnProjectDetail, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.btnNewProject, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.C1Button1, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.btnExit, System.ComponentModel.ISupportInitialize).BeginInit()
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
		Me.C1Sizer1.Dock = System.Windows.Forms.DockStyle.Fill
		Me.C1Sizer1.GridDefinition = "89.8403483309144:False:False;8.41799709724238:False:True;" & Global.Microsoft.VisualBasic.ChrW(9) & "99.3243243243243:False:" &
	"False;"
		Me.C1Sizer1.Location = New System.Drawing.Point(0, 0)
		Me.C1Sizer1.Name = "C1Sizer1"
		Me.C1Sizer1.Size = New System.Drawing.Size(1184, 689)
		Me.C1Sizer1.TabIndex = 0
		Me.C1Sizer1.Text = "C1Sizer1"
		'
		'Panel3
		'
		Me.Panel3.Controls.Add(Me.GroupBox4)
		Me.Panel3.Location = New System.Drawing.Point(4, 4)
		Me.Panel3.Name = "Panel3"
		Me.Panel3.Size = New System.Drawing.Size(1176, 619)
		Me.Panel3.TabIndex = 3
		'
		'GroupBox4
		'
		Me.GroupBox4.Controls.Add(Me.C1FlexGrid2)
		Me.GroupBox4.Dock = System.Windows.Forms.DockStyle.Fill
		Me.GroupBox4.Location = New System.Drawing.Point(0, 0)
		Me.GroupBox4.Name = "GroupBox4"
		Me.GroupBox4.Size = New System.Drawing.Size(1176, 619)
		Me.GroupBox4.TabIndex = 1
		Me.GroupBox4.TabStop = False
		Me.GroupBox4.Text = "案件一覧"
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
		Me.C1FlexGrid2.Size = New System.Drawing.Size(1170, 593)
		Me.C1FlexGrid2.TabIndex = 1
		'
		'GroupBox3
		'
		Me.GroupBox3.Controls.Add(Me.btnProjectDetail)
		Me.GroupBox3.Controls.Add(Me.btnNewProject)
		Me.GroupBox3.Controls.Add(Me.C1Button1)
		Me.GroupBox3.Controls.Add(Me.btnExit)
		Me.GroupBox3.Location = New System.Drawing.Point(4, 627)
		Me.GroupBox3.Name = "GroupBox3"
		Me.GroupBox3.Size = New System.Drawing.Size(1176, 58)
		Me.GroupBox3.TabIndex = 2
		Me.GroupBox3.TabStop = False
		Me.GroupBox3.Text = "ボタン関連"
		'
		'btnProjectDetail
		'
		Me.btnProjectDetail.Location = New System.Drawing.Point(218, 26)
		Me.btnProjectDetail.Name = "btnProjectDetail"
		Me.btnProjectDetail.Size = New System.Drawing.Size(100, 26)
		Me.btnProjectDetail.TabIndex = 12
		Me.btnProjectDetail.Text = "案件詳細"
		Me.btnProjectDetail.UseVisualStyleBackColor = True
		'
		'btnNewProject
		'
		Me.btnNewProject.Location = New System.Drawing.Point(112, 26)
		Me.btnNewProject.Name = "btnNewProject"
		Me.btnNewProject.Size = New System.Drawing.Size(100, 26)
		Me.btnNewProject.TabIndex = 11
		Me.btnNewProject.Text = "新規案件"
		Me.btnNewProject.UseVisualStyleBackColor = True
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
		Me.btnExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.btnExit.Location = New System.Drawing.Point(1090, 26)
		Me.btnExit.Name = "btnExit"
		Me.btnExit.Size = New System.Drawing.Size(80, 26)
		Me.btnExit.TabIndex = 9
		Me.btnExit.Text = "終　了"
		Me.btnExit.UseVisualStyleBackColor = True
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
		Me.C1Label1.Value = "案件一覧"
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
		Me.GroupBox3.ResumeLayout(False)
		CType(Me.btnProjectDetail, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.btnNewProject, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.C1Button1, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.btnExit, System.ComponentModel.ISupportInitialize).EndInit()
		Me.Panel1.ResumeLayout(False)
		CType(Me.C1Label1, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	Friend WithEvents Panel1 As Panel
	Friend WithEvents Panel2 As Panel
	Friend WithEvents C1Sizer1 As C1.Win.C1Sizer.C1Sizer
	Friend WithEvents GroupBox3 As GroupBox
	Friend WithEvents C1Label1 As C1.Win.C1Input.C1Label
	Friend WithEvents Panel3 As Panel
	Friend WithEvents GroupBox4 As GroupBox
	Friend WithEvents C1FlexGrid2 As C1.Win.C1FlexGrid.C1FlexGrid
	Friend WithEvents C1Button1 As C1.Win.C1Input.C1Button
	Friend WithEvents btnExit As C1.Win.C1Input.C1Button
	Friend WithEvents btnNewProject As C1.Win.C1Input.C1Button
	Friend WithEvents btnProjectDetail As C1.Win.C1Input.C1Button
End Class
