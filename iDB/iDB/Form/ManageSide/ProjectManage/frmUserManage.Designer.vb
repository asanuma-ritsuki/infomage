<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUserManage
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmUserManage))
		Me.Panel1 = New System.Windows.Forms.Panel()
		Me.C1Label1 = New C1.Win.C1Input.C1Label()
		Me.Panel2 = New System.Windows.Forms.Panel()
		Me.C1Sizer1 = New C1.Win.C1Sizer.C1Sizer()
		Me.GroupBox3 = New System.Windows.Forms.GroupBox()
		Me.C1FlexGrid1 = New C1.Win.C1FlexGrid.C1FlexGrid()
		Me.GroupBox2 = New System.Windows.Forms.GroupBox()
		Me.C1FlexGrid2 = New C1.Win.C1FlexGrid.C1FlexGrid()
		Me.GroupBox1 = New System.Windows.Forms.GroupBox()
		Me.chkValidFlag = New C1.Win.C1Input.C1CheckBox()
		Me.chkManageFlag = New C1.Win.C1Input.C1CheckBox()
		Me.C1Label7 = New C1.Win.C1Input.C1Label()
		Me.C1Label6 = New C1.Win.C1Input.C1Label()
		Me.cmbSection = New C1.Win.C1Input.C1ComboBox()
		Me.C1Label3 = New C1.Win.C1Input.C1Label()
		Me.cmbEmployeeClass = New C1.Win.C1Input.C1ComboBox()
		Me.C1Label4 = New C1.Win.C1Input.C1Label()
		Me.txtPassword = New C1.Win.C1Input.C1TextBox()
		Me.C1Label2 = New C1.Win.C1Input.C1Label()
		Me.btnSearch = New C1.Win.C1Input.C1Button()
		Me.txtEmployee = New C1.Win.C1Input.C1TextBox()
		Me.C1Label5 = New C1.Win.C1Input.C1Label()
		Me.Panel3 = New System.Windows.Forms.Panel()
		Me.btnBack = New C1.Win.C1Input.C1Button()
		Me.Panel1.SuspendLayout()
		CType(Me.C1Label1, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.Panel2.SuspendLayout()
		CType(Me.C1Sizer1, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.C1Sizer1.SuspendLayout()
		Me.GroupBox3.SuspendLayout()
		CType(Me.C1FlexGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.GroupBox2.SuspendLayout()
		CType(Me.C1FlexGrid2, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.GroupBox1.SuspendLayout()
		CType(Me.chkValidFlag, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.chkManageFlag, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.C1Label7, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.C1Label6, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.cmbSection, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.C1Label3, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.cmbEmployeeClass, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.C1Label4, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.txtPassword, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.C1Label2, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.btnSearch, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.txtEmployee, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.C1Label5, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.Panel3.SuspendLayout()
		CType(Me.btnBack, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'Panel1
		'
		Me.Panel1.Controls.Add(Me.C1Label1)
		Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
		Me.Panel1.Location = New System.Drawing.Point(0, 0)
		Me.Panel1.Name = "Panel1"
		Me.Panel1.Size = New System.Drawing.Size(792, 50)
		Me.Panel1.TabIndex = 1
		'
		'C1Label1
		'
		Me.C1Label1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.C1Label1.Dock = System.Windows.Forms.DockStyle.Fill
		Me.C1Label1.Font = New System.Drawing.Font("Meiryo UI", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.C1Label1.Location = New System.Drawing.Point(0, 0)
		Me.C1Label1.Name = "C1Label1"
		Me.C1Label1.Size = New System.Drawing.Size(792, 50)
		Me.C1Label1.TabIndex = 0
		Me.C1Label1.Tag = Nothing
		Me.C1Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.C1Label1.Value = "ユーザー管理"
		'
		'Panel2
		'
		Me.Panel2.Controls.Add(Me.C1Sizer1)
		Me.Panel2.Controls.Add(Me.Panel3)
		Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
		Me.Panel2.Location = New System.Drawing.Point(0, 50)
		Me.Panel2.Name = "Panel2"
		Me.Panel2.Size = New System.Drawing.Size(792, 495)
		Me.Panel2.TabIndex = 2
		'
		'C1Sizer1
		'
		Me.C1Sizer1.Controls.Add(Me.GroupBox3)
		Me.C1Sizer1.Controls.Add(Me.GroupBox2)
		Me.C1Sizer1.Controls.Add(Me.GroupBox1)
		Me.C1Sizer1.Dock = System.Windows.Forms.DockStyle.Fill
		Me.C1Sizer1.GridDefinition = "52.7352297592998:False:True;44.6389496717724:False:False;" & Global.Microsoft.VisualBasic.ChrW(9) & "49.4949494949495:False:" &
	"True;48.989898989899:False:False;"
		Me.C1Sizer1.Location = New System.Drawing.Point(0, 0)
		Me.C1Sizer1.Name = "C1Sizer1"
		Me.C1Sizer1.Size = New System.Drawing.Size(792, 457)
		Me.C1Sizer1.TabIndex = 0
		Me.C1Sizer1.Text = "C1Sizer1"
		'
		'GroupBox3
		'
		Me.GroupBox3.Controls.Add(Me.C1FlexGrid1)
		Me.GroupBox3.Location = New System.Drawing.Point(400, 4)
		Me.GroupBox3.Name = "GroupBox3"
		Me.GroupBox3.Size = New System.Drawing.Size(388, 241)
		Me.GroupBox3.TabIndex = 2
		Me.GroupBox3.TabStop = False
		Me.GroupBox3.Text = "処理工程権限"
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
		Me.C1FlexGrid1.Size = New System.Drawing.Size(382, 215)
		Me.C1FlexGrid1.TabIndex = 3
		'
		'GroupBox2
		'
		Me.GroupBox2.Controls.Add(Me.C1FlexGrid2)
		Me.GroupBox2.Location = New System.Drawing.Point(4, 249)
		Me.GroupBox2.Name = "GroupBox2"
		Me.GroupBox2.Size = New System.Drawing.Size(784, 204)
		Me.GroupBox2.TabIndex = 1
		Me.GroupBox2.TabStop = False
		Me.GroupBox2.Text = "ユーザー一覧"
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
		Me.C1FlexGrid2.Size = New System.Drawing.Size(778, 178)
		Me.C1FlexGrid2.TabIndex = 4
		'
		'GroupBox1
		'
		Me.GroupBox1.Controls.Add(Me.chkValidFlag)
		Me.GroupBox1.Controls.Add(Me.chkManageFlag)
		Me.GroupBox1.Controls.Add(Me.C1Label7)
		Me.GroupBox1.Controls.Add(Me.C1Label6)
		Me.GroupBox1.Controls.Add(Me.cmbSection)
		Me.GroupBox1.Controls.Add(Me.C1Label3)
		Me.GroupBox1.Controls.Add(Me.cmbEmployeeClass)
		Me.GroupBox1.Controls.Add(Me.C1Label4)
		Me.GroupBox1.Controls.Add(Me.txtPassword)
		Me.GroupBox1.Controls.Add(Me.C1Label2)
		Me.GroupBox1.Controls.Add(Me.btnSearch)
		Me.GroupBox1.Controls.Add(Me.txtEmployee)
		Me.GroupBox1.Controls.Add(Me.C1Label5)
		Me.GroupBox1.Location = New System.Drawing.Point(4, 4)
		Me.GroupBox1.Name = "GroupBox1"
		Me.GroupBox1.Size = New System.Drawing.Size(392, 241)
		Me.GroupBox1.TabIndex = 0
		Me.GroupBox1.TabStop = False
		Me.GroupBox1.Text = "登録"
		'
		'chkValidFlag
		'
		Me.chkValidFlag.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.chkValidFlag.Location = New System.Drawing.Point(276, 152)
		Me.chkValidFlag.Name = "chkValidFlag"
		Me.chkValidFlag.Size = New System.Drawing.Size(30, 26)
		Me.chkValidFlag.TabIndex = 32
		Me.chkValidFlag.UseVisualStyleBackColor = False
		Me.chkValidFlag.Value = Nothing
		'
		'chkManageFlag
		'
		Me.chkManageFlag.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.chkManageFlag.Location = New System.Drawing.Point(124, 152)
		Me.chkManageFlag.Name = "chkManageFlag"
		Me.chkManageFlag.Size = New System.Drawing.Size(30, 26)
		Me.chkManageFlag.TabIndex = 31
		Me.chkManageFlag.UseVisualStyleBackColor = False
		Me.chkManageFlag.Value = Nothing
		'
		'C1Label7
		'
		Me.C1Label7.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.C1Label7.Location = New System.Drawing.Point(160, 152)
		Me.C1Label7.Name = "C1Label7"
		Me.C1Label7.Size = New System.Drawing.Size(110, 26)
		Me.C1Label7.TabIndex = 30
		Me.C1Label7.Tag = Nothing
		Me.C1Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.C1Label7.Value = "有効："
		'
		'C1Label6
		'
		Me.C1Label6.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.C1Label6.Location = New System.Drawing.Point(8, 152)
		Me.C1Label6.Name = "C1Label6"
		Me.C1Label6.Size = New System.Drawing.Size(110, 26)
		Me.C1Label6.TabIndex = 29
		Me.C1Label6.Tag = Nothing
		Me.C1Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.C1Label6.Value = "管理者："
		'
		'cmbSection
		'
		Me.cmbSection.AllowSpinLoop = False
		Me.cmbSection.AutoSize = False
		Me.cmbSection.Cursor = System.Windows.Forms.Cursors.Arrow
		Me.cmbSection.DropDownStyle = C1.Win.C1Input.DropDownStyle.DropDownList
		Me.cmbSection.GapHeight = 0
		Me.cmbSection.ImagePadding = New System.Windows.Forms.Padding(0)
		Me.cmbSection.ItemsDisplayMember = ""
		Me.cmbSection.ItemsValueMember = ""
		Me.cmbSection.Location = New System.Drawing.Point(124, 120)
		Me.cmbSection.Name = "cmbSection"
		Me.cmbSection.Size = New System.Drawing.Size(200, 26)
		Me.cmbSection.TabIndex = 28
		Me.cmbSection.Tag = Nothing
		Me.cmbSection.TextDetached = True
		'
		'C1Label3
		'
		Me.C1Label3.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.C1Label3.Location = New System.Drawing.Point(8, 120)
		Me.C1Label3.Name = "C1Label3"
		Me.C1Label3.Size = New System.Drawing.Size(110, 26)
		Me.C1Label3.TabIndex = 27
		Me.C1Label3.Tag = Nothing
		Me.C1Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.C1Label3.Value = "生産グループ："
		'
		'cmbEmployeeClass
		'
		Me.cmbEmployeeClass.AllowSpinLoop = False
		Me.cmbEmployeeClass.AutoSize = False
		Me.cmbEmployeeClass.Cursor = System.Windows.Forms.Cursors.Arrow
		Me.cmbEmployeeClass.DropDownStyle = C1.Win.C1Input.DropDownStyle.DropDownList
		Me.cmbEmployeeClass.GapHeight = 0
		Me.cmbEmployeeClass.ImagePadding = New System.Windows.Forms.Padding(0)
		Me.cmbEmployeeClass.ItemsDisplayMember = ""
		Me.cmbEmployeeClass.ItemsValueMember = ""
		Me.cmbEmployeeClass.Location = New System.Drawing.Point(124, 88)
		Me.cmbEmployeeClass.Name = "cmbEmployeeClass"
		Me.cmbEmployeeClass.Size = New System.Drawing.Size(200, 26)
		Me.cmbEmployeeClass.TabIndex = 26
		Me.cmbEmployeeClass.Tag = Nothing
		Me.cmbEmployeeClass.TextDetached = True
		'
		'C1Label4
		'
		Me.C1Label4.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.C1Label4.Location = New System.Drawing.Point(8, 88)
		Me.C1Label4.Name = "C1Label4"
		Me.C1Label4.Size = New System.Drawing.Size(110, 26)
		Me.C1Label4.TabIndex = 25
		Me.C1Label4.Tag = Nothing
		Me.C1Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.C1Label4.Value = "従業員区分："
		'
		'txtPassword
		'
		Me.txtPassword.AutoSize = False
		Me.txtPassword.Location = New System.Drawing.Point(124, 56)
		Me.txtPassword.Name = "txtPassword"
		Me.txtPassword.Size = New System.Drawing.Size(256, 26)
		Me.txtPassword.TabIndex = 24
		Me.txtPassword.Tag = Nothing
		Me.txtPassword.TextDetached = True
		'
		'C1Label2
		'
		Me.C1Label2.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.C1Label2.Location = New System.Drawing.Point(8, 55)
		Me.C1Label2.Name = "C1Label2"
		Me.C1Label2.Size = New System.Drawing.Size(110, 26)
		Me.C1Label2.TabIndex = 23
		Me.C1Label2.Tag = Nothing
		Me.C1Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.C1Label2.Value = "パスワード："
		'
		'btnSearch
		'
		Me.btnSearch.Location = New System.Drawing.Point(330, 24)
		Me.btnSearch.Name = "btnSearch"
		Me.btnSearch.Size = New System.Drawing.Size(50, 26)
		Me.btnSearch.TabIndex = 22
		Me.btnSearch.Text = "検索"
		Me.btnSearch.UseVisualStyleBackColor = True
		'
		'txtEmployee
		'
		Me.txtEmployee.AutoSize = False
		Me.txtEmployee.Location = New System.Drawing.Point(124, 24)
		Me.txtEmployee.Name = "txtEmployee"
		Me.txtEmployee.Size = New System.Drawing.Size(200, 26)
		Me.txtEmployee.TabIndex = 21
		Me.txtEmployee.Tag = Nothing
		Me.txtEmployee.TextDetached = True
		'
		'C1Label5
		'
		Me.C1Label5.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.C1Label5.Location = New System.Drawing.Point(8, 23)
		Me.C1Label5.Name = "C1Label5"
		Me.C1Label5.Size = New System.Drawing.Size(110, 26)
		Me.C1Label5.TabIndex = 20
		Me.C1Label5.Tag = Nothing
		Me.C1Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.C1Label5.Value = "従業員名："
		'
		'Panel3
		'
		Me.Panel3.Controls.Add(Me.btnBack)
		Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
		Me.Panel3.Location = New System.Drawing.Point(0, 457)
		Me.Panel3.Name = "Panel3"
		Me.Panel3.Size = New System.Drawing.Size(792, 38)
		Me.Panel3.TabIndex = 1
		'
		'btnBack
		'
		Me.btnBack.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.btnBack.Location = New System.Drawing.Point(709, 6)
		Me.btnBack.Name = "btnBack"
		Me.btnBack.Size = New System.Drawing.Size(80, 26)
		Me.btnBack.TabIndex = 14
		Me.btnBack.Text = "戻　る"
		Me.btnBack.UseVisualStyleBackColor = True
		'
		'frmUserManage
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 19.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(792, 567)
		Me.Controls.Add(Me.Panel2)
		Me.Controls.Add(Me.Panel1)
		Me.Name = "frmUserManage"
		Me.Text = "frmUserManage"
		Me.UserName = Nothing
		Me.Controls.SetChildIndex(Me.Panel1, 0)
		Me.Controls.SetChildIndex(Me.Panel2, 0)
		Me.Panel1.ResumeLayout(False)
		CType(Me.C1Label1, System.ComponentModel.ISupportInitialize).EndInit()
		Me.Panel2.ResumeLayout(False)
		CType(Me.C1Sizer1, System.ComponentModel.ISupportInitialize).EndInit()
		Me.C1Sizer1.ResumeLayout(False)
		Me.GroupBox3.ResumeLayout(False)
		CType(Me.C1FlexGrid1, System.ComponentModel.ISupportInitialize).EndInit()
		Me.GroupBox2.ResumeLayout(False)
		CType(Me.C1FlexGrid2, System.ComponentModel.ISupportInitialize).EndInit()
		Me.GroupBox1.ResumeLayout(False)
		CType(Me.chkValidFlag, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.chkManageFlag, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.C1Label7, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.C1Label6, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.cmbSection, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.C1Label3, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.cmbEmployeeClass, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.C1Label4, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.txtPassword, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.C1Label2, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.btnSearch, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.txtEmployee, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.C1Label5, System.ComponentModel.ISupportInitialize).EndInit()
		Me.Panel3.ResumeLayout(False)
		CType(Me.btnBack, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	Friend WithEvents Panel1 As Panel
	Friend WithEvents C1Label1 As C1.Win.C1Input.C1Label
	Friend WithEvents Panel2 As Panel
	Friend WithEvents C1Sizer1 As C1.Win.C1Sizer.C1Sizer
	Friend WithEvents GroupBox2 As GroupBox
	Friend WithEvents GroupBox1 As GroupBox
	Friend WithEvents C1FlexGrid2 As C1.Win.C1FlexGrid.C1FlexGrid
	Friend WithEvents txtEmployee As C1.Win.C1Input.C1TextBox
	Friend WithEvents C1Label5 As C1.Win.C1Input.C1Label
	Friend WithEvents btnSearch As C1.Win.C1Input.C1Button
	Friend WithEvents txtPassword As C1.Win.C1Input.C1TextBox
	Friend WithEvents C1Label2 As C1.Win.C1Input.C1Label
	Friend WithEvents GroupBox3 As GroupBox
	Friend WithEvents cmbSection As C1.Win.C1Input.C1ComboBox
	Friend WithEvents C1Label3 As C1.Win.C1Input.C1Label
	Friend WithEvents cmbEmployeeClass As C1.Win.C1Input.C1ComboBox
	Friend WithEvents C1Label4 As C1.Win.C1Input.C1Label
	Friend WithEvents Panel3 As Panel
	Friend WithEvents C1FlexGrid1 As C1.Win.C1FlexGrid.C1FlexGrid
	Friend WithEvents chkValidFlag As C1.Win.C1Input.C1CheckBox
	Friend WithEvents chkManageFlag As C1.Win.C1Input.C1CheckBox
	Friend WithEvents C1Label7 As C1.Win.C1Input.C1Label
	Friend WithEvents C1Label6 As C1.Win.C1Input.C1Label
	Friend WithEvents btnBack As C1.Win.C1Input.C1Button
End Class
