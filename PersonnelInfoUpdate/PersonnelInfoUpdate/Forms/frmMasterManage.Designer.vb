<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMasterManage
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMasterManage))
		Me.C1DockingTab1 = New C1.Win.C1Command.C1DockingTab()
		Me.tabOrg = New C1.Win.C1Command.C1DockingTabPage()
		Me.GroupBox2 = New System.Windows.Forms.GroupBox()
		Me.C1FGridOrg = New C1.Win.C1FlexGrid.C1FlexGrid()
		Me.Panel1 = New System.Windows.Forms.Panel()
		Me.GroupBox1 = New System.Windows.Forms.GroupBox()
		Me.btnOrgImport = New C1.Win.C1Input.C1Button()
		Me.C1Label6 = New C1.Win.C1Input.C1Label()
		Me.btnOrgBrowse = New C1.Win.C1Input.C1Button()
		Me.txtOrg = New C1.Win.C1Input.C1TextBox()
		Me.tabPost = New C1.Win.C1Command.C1DockingTabPage()
		Me.GroupBox4 = New System.Windows.Forms.GroupBox()
		Me.C1FGridPost = New C1.Win.C1FlexGrid.C1FlexGrid()
		Me.Panel2 = New System.Windows.Forms.Panel()
		Me.GroupBox3 = New System.Windows.Forms.GroupBox()
		Me.btnPostImport = New C1.Win.C1Input.C1Button()
		Me.C1Label1 = New C1.Win.C1Input.C1Label()
		Me.btnPostBrowse = New C1.Win.C1Input.C1Button()
		Me.txtPost = New C1.Win.C1Input.C1TextBox()
		Me.tabOffice = New C1.Win.C1Command.C1DockingTabPage()
		Me.GroupBox6 = New System.Windows.Forms.GroupBox()
		Me.C1FGridOffice = New C1.Win.C1FlexGrid.C1FlexGrid()
		Me.Panel3 = New System.Windows.Forms.Panel()
		Me.GroupBox5 = New System.Windows.Forms.GroupBox()
		Me.btnNew = New C1.Win.C1Input.C1Button()
		Me.btnDelete = New C1.Win.C1Input.C1Button()
		Me.txtOffice = New C1.Win.C1Input.C1TextBox()
		Me.C1Label2 = New C1.Win.C1Input.C1Label()
		Me.btnUpdate = New C1.Win.C1Input.C1Button()
		Me.txtOfficeID = New C1.Win.C1Input.C1TextBox()
		CType(Me.C1DockingTab1, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.C1DockingTab1.SuspendLayout()
		Me.tabOrg.SuspendLayout()
		Me.GroupBox2.SuspendLayout()
		CType(Me.C1FGridOrg, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.Panel1.SuspendLayout()
		Me.GroupBox1.SuspendLayout()
		CType(Me.btnOrgImport, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.C1Label6, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.btnOrgBrowse, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.txtOrg, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.tabPost.SuspendLayout()
		Me.GroupBox4.SuspendLayout()
		CType(Me.C1FGridPost, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.Panel2.SuspendLayout()
		Me.GroupBox3.SuspendLayout()
		CType(Me.btnPostImport, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.C1Label1, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.btnPostBrowse, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.txtPost, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.tabOffice.SuspendLayout()
		Me.GroupBox6.SuspendLayout()
		CType(Me.C1FGridOffice, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.Panel3.SuspendLayout()
		Me.GroupBox5.SuspendLayout()
		CType(Me.btnNew, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.btnDelete, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.txtOffice, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.C1Label2, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.btnUpdate, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.txtOfficeID, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'C1DockingTab1
		'
		Me.C1DockingTab1.Controls.Add(Me.tabOrg)
		Me.C1DockingTab1.Controls.Add(Me.tabPost)
		Me.C1DockingTab1.Controls.Add(Me.tabOffice)
		Me.C1DockingTab1.Dock = System.Windows.Forms.DockStyle.Fill
		Me.C1DockingTab1.Location = New System.Drawing.Point(0, 0)
		Me.C1DockingTab1.Name = "C1DockingTab1"
		Me.C1DockingTab1.Size = New System.Drawing.Size(792, 548)
		Me.C1DockingTab1.TabIndex = 1
		Me.C1DockingTab1.TabsSpacing = 5
		Me.C1DockingTab1.VisualStyleBase = C1.Win.C1Command.VisualStyle.Office2010Black
		'
		'tabOrg
		'
		Me.tabOrg.Controls.Add(Me.GroupBox2)
		Me.tabOrg.Controls.Add(Me.Panel1)
		Me.tabOrg.Location = New System.Drawing.Point(1, 28)
		Me.tabOrg.Name = "tabOrg"
		Me.tabOrg.Size = New System.Drawing.Size(790, 519)
		Me.tabOrg.TabIndex = 0
		Me.tabOrg.Text = "組織情報"
		'
		'GroupBox2
		'
		Me.GroupBox2.Controls.Add(Me.C1FGridOrg)
		Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
		Me.GroupBox2.Location = New System.Drawing.Point(0, 63)
		Me.GroupBox2.Name = "GroupBox2"
		Me.GroupBox2.Size = New System.Drawing.Size(790, 456)
		Me.GroupBox2.TabIndex = 1
		Me.GroupBox2.TabStop = False
		Me.GroupBox2.Text = "組織情報一覧"
		'
		'C1FGridOrg
		'
		Me.C1FGridOrg.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
		Me.C1FGridOrg.AllowEditing = False
		Me.C1FGridOrg.AllowFiltering = True
		Me.C1FGridOrg.AutoClipboard = True
		Me.C1FGridOrg.AutoResize = True
		Me.C1FGridOrg.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
		Me.C1FGridOrg.ColumnInfo = resources.GetString("C1FGridOrg.ColumnInfo")
		Me.C1FGridOrg.Dock = System.Windows.Forms.DockStyle.Fill
		Me.C1FGridOrg.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid
		Me.C1FGridOrg.Font = New System.Drawing.Font("Meiryo UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.C1FGridOrg.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcrossOut
		Me.C1FGridOrg.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcrossOut
		Me.C1FGridOrg.Location = New System.Drawing.Point(3, 20)
		Me.C1FGridOrg.Name = "C1FGridOrg"
		Me.C1FGridOrg.Rows.Count = 1
		Me.C1FGridOrg.Rows.DefaultSize = 20
		Me.C1FGridOrg.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
		Me.C1FGridOrg.ShowCellLabels = True
		Me.C1FGridOrg.Size = New System.Drawing.Size(784, 433)
		Me.C1FGridOrg.StyleInfo = resources.GetString("C1FGridOrg.StyleInfo")
		Me.C1FGridOrg.SubtotalPosition = C1.Win.C1FlexGrid.SubtotalPositionEnum.BelowData
		Me.C1FGridOrg.TabIndex = 1
		Me.C1FGridOrg.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2010Black
		'
		'Panel1
		'
		Me.Panel1.Controls.Add(Me.GroupBox1)
		Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
		Me.Panel1.Location = New System.Drawing.Point(0, 0)
		Me.Panel1.Name = "Panel1"
		Me.Panel1.Size = New System.Drawing.Size(790, 63)
		Me.Panel1.TabIndex = 0
		'
		'GroupBox1
		'
		Me.GroupBox1.Controls.Add(Me.btnOrgImport)
		Me.GroupBox1.Controls.Add(Me.C1Label6)
		Me.GroupBox1.Controls.Add(Me.btnOrgBrowse)
		Me.GroupBox1.Controls.Add(Me.txtOrg)
		Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
		Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
		Me.GroupBox1.Name = "GroupBox1"
		Me.GroupBox1.Size = New System.Drawing.Size(790, 63)
		Me.GroupBox1.TabIndex = 0
		Me.GroupBox1.TabStop = False
		Me.GroupBox1.Text = "インポート"
		'
		'btnOrgImport
		'
		Me.btnOrgImport.Location = New System.Drawing.Point(704, 23)
		Me.btnOrgImport.Name = "btnOrgImport"
		Me.btnOrgImport.Size = New System.Drawing.Size(75, 25)
		Me.btnOrgImport.TabIndex = 21
		Me.btnOrgImport.Text = "インポート"
		Me.btnOrgImport.UseVisualStyleBackColor = True
		'
		'C1Label6
		'
		Me.C1Label6.BackColor = System.Drawing.Color.Transparent
		Me.C1Label6.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.C1Label6.ForeColor = System.Drawing.Color.Black
		Me.C1Label6.Location = New System.Drawing.Point(7, 21)
		Me.C1Label6.Name = "C1Label6"
		Me.C1Label6.Size = New System.Drawing.Size(124, 25)
		Me.C1Label6.TabIndex = 18
		Me.C1Label6.Tag = Nothing
		Me.C1Label6.Text = "組織情報CSV："
		Me.C1Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.C1Label6.TextDetached = True
		Me.C1Label6.Value = ""
		'
		'btnOrgBrowse
		'
		Me.btnOrgBrowse.Location = New System.Drawing.Point(655, 23)
		Me.btnOrgBrowse.Name = "btnOrgBrowse"
		Me.btnOrgBrowse.Size = New System.Drawing.Size(30, 25)
		Me.btnOrgBrowse.TabIndex = 20
		Me.btnOrgBrowse.Text = "..."
		Me.btnOrgBrowse.UseVisualStyleBackColor = True
		'
		'txtOrg
		'
		Me.txtOrg.AllowDrop = True
		Me.txtOrg.AutoSize = False
		Me.txtOrg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.txtOrg.Location = New System.Drawing.Point(137, 23)
		Me.txtOrg.Name = "txtOrg"
		Me.txtOrg.Size = New System.Drawing.Size(512, 25)
		Me.txtOrg.TabIndex = 19
		Me.txtOrg.Tag = Nothing
		Me.txtOrg.TextDetached = True
		'
		'tabPost
		'
		Me.tabPost.Controls.Add(Me.GroupBox4)
		Me.tabPost.Controls.Add(Me.Panel2)
		Me.tabPost.Location = New System.Drawing.Point(1, 28)
		Me.tabPost.Name = "tabPost"
		Me.tabPost.Size = New System.Drawing.Size(790, 519)
		Me.tabPost.TabIndex = 1
		Me.tabPost.Text = "役職情報"
		'
		'GroupBox4
		'
		Me.GroupBox4.Controls.Add(Me.C1FGridPost)
		Me.GroupBox4.Dock = System.Windows.Forms.DockStyle.Fill
		Me.GroupBox4.Location = New System.Drawing.Point(0, 63)
		Me.GroupBox4.Name = "GroupBox4"
		Me.GroupBox4.Size = New System.Drawing.Size(790, 456)
		Me.GroupBox4.TabIndex = 2
		Me.GroupBox4.TabStop = False
		Me.GroupBox4.Text = "組織情報一覧"
		'
		'C1FGridPost
		'
		Me.C1FGridPost.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
		Me.C1FGridPost.AllowEditing = False
		Me.C1FGridPost.AllowFiltering = True
		Me.C1FGridPost.AutoClipboard = True
		Me.C1FGridPost.AutoResize = True
		Me.C1FGridPost.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
		Me.C1FGridPost.ColumnInfo = resources.GetString("C1FGridPost.ColumnInfo")
		Me.C1FGridPost.Dock = System.Windows.Forms.DockStyle.Fill
		Me.C1FGridPost.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid
		Me.C1FGridPost.Font = New System.Drawing.Font("Meiryo UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.C1FGridPost.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcrossOut
		Me.C1FGridPost.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcrossOut
		Me.C1FGridPost.Location = New System.Drawing.Point(3, 20)
		Me.C1FGridPost.Name = "C1FGridPost"
		Me.C1FGridPost.Rows.Count = 1
		Me.C1FGridPost.Rows.DefaultSize = 20
		Me.C1FGridPost.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
		Me.C1FGridPost.ShowCellLabels = True
		Me.C1FGridPost.Size = New System.Drawing.Size(784, 433)
		Me.C1FGridPost.StyleInfo = resources.GetString("C1FGridPost.StyleInfo")
		Me.C1FGridPost.SubtotalPosition = C1.Win.C1FlexGrid.SubtotalPositionEnum.BelowData
		Me.C1FGridPost.TabIndex = 1
		Me.C1FGridPost.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2010Black
		'
		'Panel2
		'
		Me.Panel2.Controls.Add(Me.GroupBox3)
		Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
		Me.Panel2.Location = New System.Drawing.Point(0, 0)
		Me.Panel2.Name = "Panel2"
		Me.Panel2.Size = New System.Drawing.Size(790, 63)
		Me.Panel2.TabIndex = 1
		'
		'GroupBox3
		'
		Me.GroupBox3.Controls.Add(Me.btnPostImport)
		Me.GroupBox3.Controls.Add(Me.C1Label1)
		Me.GroupBox3.Controls.Add(Me.btnPostBrowse)
		Me.GroupBox3.Controls.Add(Me.txtPost)
		Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Fill
		Me.GroupBox3.Location = New System.Drawing.Point(0, 0)
		Me.GroupBox3.Name = "GroupBox3"
		Me.GroupBox3.Size = New System.Drawing.Size(790, 63)
		Me.GroupBox3.TabIndex = 0
		Me.GroupBox3.TabStop = False
		Me.GroupBox3.Text = "インポート"
		'
		'btnPostImport
		'
		Me.btnPostImport.Location = New System.Drawing.Point(704, 23)
		Me.btnPostImport.Name = "btnPostImport"
		Me.btnPostImport.Size = New System.Drawing.Size(75, 25)
		Me.btnPostImport.TabIndex = 21
		Me.btnPostImport.Text = "インポート"
		Me.btnPostImport.UseVisualStyleBackColor = True
		'
		'C1Label1
		'
		Me.C1Label1.BackColor = System.Drawing.Color.Transparent
		Me.C1Label1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.C1Label1.ForeColor = System.Drawing.Color.Black
		Me.C1Label1.Location = New System.Drawing.Point(7, 21)
		Me.C1Label1.Name = "C1Label1"
		Me.C1Label1.Size = New System.Drawing.Size(124, 25)
		Me.C1Label1.TabIndex = 18
		Me.C1Label1.Tag = Nothing
		Me.C1Label1.Text = "役職情報CSV："
		Me.C1Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.C1Label1.TextDetached = True
		Me.C1Label1.Value = ""
		'
		'btnPostBrowse
		'
		Me.btnPostBrowse.Location = New System.Drawing.Point(655, 23)
		Me.btnPostBrowse.Name = "btnPostBrowse"
		Me.btnPostBrowse.Size = New System.Drawing.Size(30, 25)
		Me.btnPostBrowse.TabIndex = 20
		Me.btnPostBrowse.Text = "..."
		Me.btnPostBrowse.UseVisualStyleBackColor = True
		'
		'txtPost
		'
		Me.txtPost.AllowDrop = True
		Me.txtPost.AutoSize = False
		Me.txtPost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.txtPost.Location = New System.Drawing.Point(137, 23)
		Me.txtPost.Name = "txtPost"
		Me.txtPost.Size = New System.Drawing.Size(512, 25)
		Me.txtPost.TabIndex = 19
		Me.txtPost.Tag = Nothing
		Me.txtPost.TextDetached = True
		'
		'tabOffice
		'
		Me.tabOffice.Controls.Add(Me.GroupBox6)
		Me.tabOffice.Controls.Add(Me.Panel3)
		Me.tabOffice.Location = New System.Drawing.Point(1, 28)
		Me.tabOffice.Name = "tabOffice"
		Me.tabOffice.Size = New System.Drawing.Size(790, 519)
		Me.tabOffice.TabIndex = 2
		Me.tabOffice.Text = "事業所"
		'
		'GroupBox6
		'
		Me.GroupBox6.Controls.Add(Me.C1FGridOffice)
		Me.GroupBox6.Dock = System.Windows.Forms.DockStyle.Fill
		Me.GroupBox6.Location = New System.Drawing.Point(0, 0)
		Me.GroupBox6.Name = "GroupBox6"
		Me.GroupBox6.Size = New System.Drawing.Size(790, 460)
		Me.GroupBox6.TabIndex = 3
		Me.GroupBox6.TabStop = False
		Me.GroupBox6.Text = "事業所一覧"
		'
		'C1FGridOffice
		'
		Me.C1FGridOffice.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
		Me.C1FGridOffice.AllowEditing = False
		Me.C1FGridOffice.AllowFiltering = True
		Me.C1FGridOffice.AutoClipboard = True
		Me.C1FGridOffice.AutoResize = True
		Me.C1FGridOffice.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
		Me.C1FGridOffice.ColumnInfo = resources.GetString("C1FGridOffice.ColumnInfo")
		Me.C1FGridOffice.Dock = System.Windows.Forms.DockStyle.Fill
		Me.C1FGridOffice.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid
		Me.C1FGridOffice.Font = New System.Drawing.Font("Meiryo UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.C1FGridOffice.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcrossOut
		Me.C1FGridOffice.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcrossOut
		Me.C1FGridOffice.Location = New System.Drawing.Point(3, 20)
		Me.C1FGridOffice.Name = "C1FGridOffice"
		Me.C1FGridOffice.Rows.Count = 1
		Me.C1FGridOffice.Rows.DefaultSize = 20
		Me.C1FGridOffice.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
		Me.C1FGridOffice.ShowCellLabels = True
		Me.C1FGridOffice.Size = New System.Drawing.Size(784, 437)
		Me.C1FGridOffice.StyleInfo = resources.GetString("C1FGridOffice.StyleInfo")
		Me.C1FGridOffice.SubtotalPosition = C1.Win.C1FlexGrid.SubtotalPositionEnum.BelowData
		Me.C1FGridOffice.TabIndex = 1
		Me.C1FGridOffice.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2010Black
		'
		'Panel3
		'
		Me.Panel3.Controls.Add(Me.GroupBox5)
		Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
		Me.Panel3.Location = New System.Drawing.Point(0, 460)
		Me.Panel3.Name = "Panel3"
		Me.Panel3.Size = New System.Drawing.Size(790, 59)
		Me.Panel3.TabIndex = 0
		'
		'GroupBox5
		'
		Me.GroupBox5.Controls.Add(Me.btnNew)
		Me.GroupBox5.Controls.Add(Me.btnDelete)
		Me.GroupBox5.Controls.Add(Me.txtOffice)
		Me.GroupBox5.Controls.Add(Me.C1Label2)
		Me.GroupBox5.Controls.Add(Me.btnUpdate)
		Me.GroupBox5.Controls.Add(Me.txtOfficeID)
		Me.GroupBox5.Dock = System.Windows.Forms.DockStyle.Fill
		Me.GroupBox5.Location = New System.Drawing.Point(0, 0)
		Me.GroupBox5.Name = "GroupBox5"
		Me.GroupBox5.Size = New System.Drawing.Size(790, 59)
		Me.GroupBox5.TabIndex = 26
		Me.GroupBox5.TabStop = False
		Me.GroupBox5.Text = "事業所登録"
		'
		'btnNew
		'
		Me.btnNew.Location = New System.Drawing.Point(345, 23)
		Me.btnNew.Name = "btnNew"
		Me.btnNew.Size = New System.Drawing.Size(75, 25)
		Me.btnNew.TabIndex = 24
		Me.btnNew.Text = "新規登録"
		Me.btnNew.UseVisualStyleBackColor = True
		'
		'btnDelete
		'
		Me.btnDelete.Location = New System.Drawing.Point(687, 23)
		Me.btnDelete.Name = "btnDelete"
		Me.btnDelete.Size = New System.Drawing.Size(75, 25)
		Me.btnDelete.TabIndex = 25
		Me.btnDelete.Text = "削　除"
		Me.btnDelete.UseVisualStyleBackColor = True
		'
		'txtOffice
		'
		Me.txtOffice.AllowDrop = True
		Me.txtOffice.AutoSize = False
		Me.txtOffice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.txtOffice.Location = New System.Drawing.Point(97, 23)
		Me.txtOffice.Name = "txtOffice"
		Me.txtOffice.Size = New System.Drawing.Size(115, 25)
		Me.txtOffice.TabIndex = 21
		Me.txtOffice.Tag = Nothing
		Me.txtOffice.TextDetached = True
		'
		'C1Label2
		'
		Me.C1Label2.BackColor = System.Drawing.Color.Transparent
		Me.C1Label2.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.C1Label2.ForeColor = System.Drawing.Color.Black
		Me.C1Label2.Location = New System.Drawing.Point(15, 21)
		Me.C1Label2.Name = "C1Label2"
		Me.C1Label2.Size = New System.Drawing.Size(76, 25)
		Me.C1Label2.TabIndex = 20
		Me.C1Label2.Tag = Nothing
		Me.C1Label2.Text = "事業所："
		Me.C1Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.C1Label2.TextDetached = True
		Me.C1Label2.Value = ""
		'
		'btnUpdate
		'
		Me.btnUpdate.Location = New System.Drawing.Point(264, 23)
		Me.btnUpdate.Name = "btnUpdate"
		Me.btnUpdate.Size = New System.Drawing.Size(75, 25)
		Me.btnUpdate.TabIndex = 23
		Me.btnUpdate.Text = "更　新"
		Me.btnUpdate.UseVisualStyleBackColor = True
		'
		'txtOfficeID
		'
		Me.txtOfficeID.AllowDrop = True
		Me.txtOfficeID.AutoSize = False
		Me.txtOfficeID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.txtOfficeID.Enabled = False
		Me.txtOfficeID.Location = New System.Drawing.Point(218, 23)
		Me.txtOfficeID.Name = "txtOfficeID"
		Me.txtOfficeID.Size = New System.Drawing.Size(40, 25)
		Me.txtOfficeID.TabIndex = 22
		Me.txtOfficeID.Tag = Nothing
		Me.txtOfficeID.TextDetached = True
		'
		'frmMasterManage
		'
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
		Me.ClientSize = New System.Drawing.Size(792, 571)
		Me.Controls.Add(Me.C1DockingTab1)
		Me.Name = "frmMasterManage"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "frmMasterManage"
		Me.Controls.SetChildIndex(Me.C1DockingTab1, 0)
		CType(Me.C1DockingTab1, System.ComponentModel.ISupportInitialize).EndInit()
		Me.C1DockingTab1.ResumeLayout(False)
		Me.tabOrg.ResumeLayout(False)
		Me.GroupBox2.ResumeLayout(False)
		CType(Me.C1FGridOrg, System.ComponentModel.ISupportInitialize).EndInit()
		Me.Panel1.ResumeLayout(False)
		Me.GroupBox1.ResumeLayout(False)
		CType(Me.btnOrgImport, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.C1Label6, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.btnOrgBrowse, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.txtOrg, System.ComponentModel.ISupportInitialize).EndInit()
		Me.tabPost.ResumeLayout(False)
		Me.GroupBox4.ResumeLayout(False)
		CType(Me.C1FGridPost, System.ComponentModel.ISupportInitialize).EndInit()
		Me.Panel2.ResumeLayout(False)
		Me.GroupBox3.ResumeLayout(False)
		CType(Me.btnPostImport, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.C1Label1, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.btnPostBrowse, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.txtPost, System.ComponentModel.ISupportInitialize).EndInit()
		Me.tabOffice.ResumeLayout(False)
		Me.GroupBox6.ResumeLayout(False)
		CType(Me.C1FGridOffice, System.ComponentModel.ISupportInitialize).EndInit()
		Me.Panel3.ResumeLayout(False)
		Me.GroupBox5.ResumeLayout(False)
		CType(Me.btnNew, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.btnDelete, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.txtOffice, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.C1Label2, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.btnUpdate, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.txtOfficeID, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	Friend WithEvents C1DockingTab1 As C1.Win.C1Command.C1DockingTab
	Friend WithEvents tabOrg As C1.Win.C1Command.C1DockingTabPage
	Friend WithEvents Panel1 As Panel
	Friend WithEvents GroupBox1 As GroupBox
	Friend WithEvents tabPost As C1.Win.C1Command.C1DockingTabPage
	Friend WithEvents C1Label6 As C1.Win.C1Input.C1Label
	Friend WithEvents btnOrgBrowse As C1.Win.C1Input.C1Button
	Friend WithEvents txtOrg As C1.Win.C1Input.C1TextBox
	Friend WithEvents btnOrgImport As C1.Win.C1Input.C1Button
	Friend WithEvents GroupBox2 As GroupBox
	Friend WithEvents C1FGridOrg As C1.Win.C1FlexGrid.C1FlexGrid
	Friend WithEvents GroupBox4 As GroupBox
	Friend WithEvents C1FGridPost As C1.Win.C1FlexGrid.C1FlexGrid
	Friend WithEvents Panel2 As Panel
	Friend WithEvents GroupBox3 As GroupBox
	Friend WithEvents btnPostImport As C1.Win.C1Input.C1Button
	Friend WithEvents C1Label1 As C1.Win.C1Input.C1Label
	Friend WithEvents btnPostBrowse As C1.Win.C1Input.C1Button
	Friend WithEvents txtPost As C1.Win.C1Input.C1TextBox
	Friend WithEvents tabOffice As C1.Win.C1Command.C1DockingTabPage
	Friend WithEvents Panel3 As Panel
	Friend WithEvents GroupBox5 As GroupBox
	Friend WithEvents btnNew As C1.Win.C1Input.C1Button
	Friend WithEvents btnDelete As C1.Win.C1Input.C1Button
	Friend WithEvents txtOffice As C1.Win.C1Input.C1TextBox
	Friend WithEvents C1Label2 As C1.Win.C1Input.C1Label
	Friend WithEvents btnUpdate As C1.Win.C1Input.C1Button
	Friend WithEvents txtOfficeID As C1.Win.C1Input.C1TextBox
	Friend WithEvents GroupBox6 As GroupBox
	Friend WithEvents C1FGridOffice As C1.Win.C1FlexGrid.C1FlexGrid
End Class
