<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTraderDetail
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTraderDetail))
		Me.GroupBox1 = New System.Windows.Forms.GroupBox()
		Me.C1FGridHistory = New C1.Win.C1FlexGrid.C1FlexGrid()
		Me.GroupBox2 = New System.Windows.Forms.GroupBox()
		Me.C1FlexGrid1 = New C1.Win.C1FlexGrid.C1FlexGrid()
		Me.Panel1 = New System.Windows.Forms.Panel()
		Me.Button2 = New System.Windows.Forms.Button()
		Me.Button1 = New System.Windows.Forms.Button()
		Me.GroupBox4 = New System.Windows.Forms.GroupBox()
		Me.btnUpdate = New System.Windows.Forms.Button()
		Me.Button3 = New System.Windows.Forms.Button()
		Me.dtpCertification = New C1.Win.Calendar.C1DateEdit()
		Me.dtpApplication = New C1.Win.Calendar.C1DateEdit()
		Me.dtpApplicationTo = New C1.Win.Calendar.C1DateEdit()
		Me.dtpApplicationFrom = New C1.Win.Calendar.C1DateEdit()
		Me.dtpEffectiveTo = New C1.Win.Calendar.C1DateEdit()
		Me.dtpEffectiveFrom = New C1.Win.Calendar.C1DateEdit()
		Me.btnDelete = New System.Windows.Forms.Button()
		Me.btnRegist = New System.Windows.Forms.Button()
		Me.txtInnerNumber = New System.Windows.Forms.TextBox()
		Me.txtRemarks = New System.Windows.Forms.TextBox()
		Me.Label19 = New System.Windows.Forms.Label()
		Me.Label18 = New System.Windows.Forms.Label()
		Me.Label17 = New System.Windows.Forms.Label()
		Me.Label15 = New System.Windows.Forms.Label()
		Me.Label16 = New System.Windows.Forms.Label()
		Me.Label14 = New System.Windows.Forms.Label()
		Me.Label13 = New System.Windows.Forms.Label()
		Me.Label12 = New System.Windows.Forms.Label()
		Me.cmbYear = New C1.Win.Input.C1MultiSelect()
		Me.Label11 = New System.Windows.Forms.Label()
		Me.txtEmail = New System.Windows.Forms.TextBox()
		Me.Label10 = New System.Windows.Forms.Label()
		Me.txtUrl = New System.Windows.Forms.TextBox()
		Me.Label9 = New System.Windows.Forms.Label()
		Me.txtFax = New System.Windows.Forms.TextBox()
		Me.Label8 = New System.Windows.Forms.Label()
		Me.txtTel = New System.Windows.Forms.TextBox()
		Me.Label7 = New System.Windows.Forms.Label()
		Me.txtAddress2 = New System.Windows.Forms.TextBox()
		Me.Label6 = New System.Windows.Forms.Label()
		Me.txtAddress1 = New System.Windows.Forms.TextBox()
		Me.Label5 = New System.Windows.Forms.Label()
		Me.txtZipCode = New System.Windows.Forms.TextBox()
		Me.Label4 = New System.Windows.Forms.Label()
		Me.txtTraderNameKana = New System.Windows.Forms.TextBox()
		Me.Label3 = New System.Windows.Forms.Label()
		Me.txtTraderName = New System.Windows.Forms.TextBox()
		Me.cmbPrefectures = New System.Windows.Forms.ComboBox()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.txtTraderNumber = New System.Windows.Forms.TextBox()
		Me.btnTraderSelect = New System.Windows.Forms.Button()
		Me.GroupBox1.SuspendLayout()
		CType(Me.C1FGridHistory, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.GroupBox2.SuspendLayout()
		CType(Me.C1FlexGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.Panel1.SuspendLayout()
		Me.GroupBox4.SuspendLayout()
		CType(Me.dtpCertification, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.dtpApplication, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.dtpApplicationTo, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.dtpApplicationFrom, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.dtpEffectiveTo, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.dtpEffectiveFrom, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'GroupBox1
		'
		Me.GroupBox1.Controls.Add(Me.C1FGridHistory)
		Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Left
		Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
		Me.GroupBox1.Name = "GroupBox1"
		Me.GroupBox1.Size = New System.Drawing.Size(200, 739)
		Me.GroupBox1.TabIndex = 1
		Me.GroupBox1.TabStop = False
		Me.GroupBox1.Text = "履歴情報"
		'
		'C1FGridHistory
		'
		Me.C1FGridHistory.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
		Me.C1FGridHistory.AllowEditing = False
		Me.C1FGridHistory.AllowFiltering = True
		Me.C1FGridHistory.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
		Me.C1FGridHistory.AutoClipboard = True
		Me.C1FGridHistory.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
		Me.C1FGridHistory.ColumnInfo = resources.GetString("C1FGridHistory.ColumnInfo")
		Me.C1FGridHistory.Dock = System.Windows.Forms.DockStyle.Fill
		Me.C1FGridHistory.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid
		Me.C1FGridHistory.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.C1FGridHistory.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcrossOut
		Me.C1FGridHistory.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcrossOut
		Me.C1FGridHistory.Location = New System.Drawing.Point(3, 20)
		Me.C1FGridHistory.Name = "C1FGridHistory"
		Me.C1FGridHistory.Rows.Count = 1
		Me.C1FGridHistory.Rows.DefaultSize = 23
		Me.C1FGridHistory.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
		Me.C1FGridHistory.ShowCellLabels = True
		Me.C1FGridHistory.Size = New System.Drawing.Size(194, 716)
		Me.C1FGridHistory.TabIndex = 6
		Me.C1FGridHistory.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.System
		'
		'GroupBox2
		'
		Me.GroupBox2.Controls.Add(Me.C1FlexGrid1)
		Me.GroupBox2.Controls.Add(Me.Panel1)
		Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Right
		Me.GroupBox2.Location = New System.Drawing.Point(643, 0)
		Me.GroupBox2.Name = "GroupBox2"
		Me.GroupBox2.Size = New System.Drawing.Size(444, 739)
		Me.GroupBox2.TabIndex = 2
		Me.GroupBox2.TabStop = False
		Me.GroupBox2.Text = "自治体情報"
		'
		'C1FlexGrid1
		'
		Me.C1FlexGrid1.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
		Me.C1FlexGrid1.AllowEditing = False
		Me.C1FlexGrid1.AllowFiltering = True
		Me.C1FlexGrid1.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
		Me.C1FlexGrid1.AutoClipboard = True
		Me.C1FlexGrid1.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
		Me.C1FlexGrid1.ColumnInfo = resources.GetString("C1FlexGrid1.ColumnInfo")
		Me.C1FlexGrid1.Dock = System.Windows.Forms.DockStyle.Fill
		Me.C1FlexGrid1.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid
		Me.C1FlexGrid1.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.C1FlexGrid1.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcrossOut
		Me.C1FlexGrid1.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcrossOut
		Me.C1FlexGrid1.Location = New System.Drawing.Point(3, 20)
		Me.C1FlexGrid1.Name = "C1FlexGrid1"
		Me.C1FlexGrid1.Rows.Count = 1
		Me.C1FlexGrid1.Rows.DefaultSize = 23
		Me.C1FlexGrid1.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
		Me.C1FlexGrid1.ShowCellLabels = True
		Me.C1FlexGrid1.Size = New System.Drawing.Size(438, 685)
		Me.C1FlexGrid1.TabIndex = 7
		Me.C1FlexGrid1.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.System
		'
		'Panel1
		'
		Me.Panel1.Controls.Add(Me.Button2)
		Me.Panel1.Controls.Add(Me.Button1)
		Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
		Me.Panel1.Location = New System.Drawing.Point(3, 705)
		Me.Panel1.Name = "Panel1"
		Me.Panel1.Size = New System.Drawing.Size(438, 31)
		Me.Panel1.TabIndex = 0
		'
		'Button2
		'
		Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.Button2.Location = New System.Drawing.Point(273, 3)
		Me.Button2.Name = "Button2"
		Me.Button2.Size = New System.Drawing.Size(75, 25)
		Me.Button2.TabIndex = 2
		Me.Button2.Text = "削　除"
		Me.Button2.UseVisualStyleBackColor = True
		'
		'Button1
		'
		Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.Button1.Location = New System.Drawing.Point(354, 3)
		Me.Button1.Name = "Button1"
		Me.Button1.Size = New System.Drawing.Size(75, 25)
		Me.Button1.TabIndex = 1
		Me.Button1.Text = "選　択"
		Me.Button1.UseVisualStyleBackColor = True
		'
		'GroupBox4
		'
		Me.GroupBox4.Controls.Add(Me.btnUpdate)
		Me.GroupBox4.Controls.Add(Me.Button3)
		Me.GroupBox4.Controls.Add(Me.dtpCertification)
		Me.GroupBox4.Controls.Add(Me.dtpApplication)
		Me.GroupBox4.Controls.Add(Me.dtpApplicationTo)
		Me.GroupBox4.Controls.Add(Me.dtpApplicationFrom)
		Me.GroupBox4.Controls.Add(Me.dtpEffectiveTo)
		Me.GroupBox4.Controls.Add(Me.dtpEffectiveFrom)
		Me.GroupBox4.Controls.Add(Me.btnDelete)
		Me.GroupBox4.Controls.Add(Me.btnRegist)
		Me.GroupBox4.Controls.Add(Me.txtInnerNumber)
		Me.GroupBox4.Controls.Add(Me.txtRemarks)
		Me.GroupBox4.Controls.Add(Me.Label19)
		Me.GroupBox4.Controls.Add(Me.Label18)
		Me.GroupBox4.Controls.Add(Me.Label17)
		Me.GroupBox4.Controls.Add(Me.Label15)
		Me.GroupBox4.Controls.Add(Me.Label16)
		Me.GroupBox4.Controls.Add(Me.Label14)
		Me.GroupBox4.Controls.Add(Me.Label13)
		Me.GroupBox4.Controls.Add(Me.Label12)
		Me.GroupBox4.Controls.Add(Me.cmbYear)
		Me.GroupBox4.Controls.Add(Me.Label11)
		Me.GroupBox4.Controls.Add(Me.txtEmail)
		Me.GroupBox4.Controls.Add(Me.Label10)
		Me.GroupBox4.Controls.Add(Me.txtUrl)
		Me.GroupBox4.Controls.Add(Me.Label9)
		Me.GroupBox4.Controls.Add(Me.txtFax)
		Me.GroupBox4.Controls.Add(Me.Label8)
		Me.GroupBox4.Controls.Add(Me.txtTel)
		Me.GroupBox4.Controls.Add(Me.Label7)
		Me.GroupBox4.Controls.Add(Me.txtAddress2)
		Me.GroupBox4.Controls.Add(Me.Label6)
		Me.GroupBox4.Controls.Add(Me.txtAddress1)
		Me.GroupBox4.Controls.Add(Me.Label5)
		Me.GroupBox4.Controls.Add(Me.txtZipCode)
		Me.GroupBox4.Controls.Add(Me.Label4)
		Me.GroupBox4.Controls.Add(Me.txtTraderNameKana)
		Me.GroupBox4.Controls.Add(Me.Label3)
		Me.GroupBox4.Controls.Add(Me.txtTraderName)
		Me.GroupBox4.Controls.Add(Me.cmbPrefectures)
		Me.GroupBox4.Controls.Add(Me.Label2)
		Me.GroupBox4.Controls.Add(Me.Label1)
		Me.GroupBox4.Controls.Add(Me.txtTraderNumber)
		Me.GroupBox4.Controls.Add(Me.btnTraderSelect)
		Me.GroupBox4.Dock = System.Windows.Forms.DockStyle.Fill
		Me.GroupBox4.Location = New System.Drawing.Point(200, 0)
		Me.GroupBox4.Name = "GroupBox4"
		Me.GroupBox4.Size = New System.Drawing.Size(443, 739)
		Me.GroupBox4.TabIndex = 6
		Me.GroupBox4.TabStop = False
		Me.GroupBox4.Text = "業者情報"
		'
		'btnUpdate
		'
		Me.btnUpdate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.btnUpdate.Location = New System.Drawing.Point(281, 708)
		Me.btnUpdate.Name = "btnUpdate"
		Me.btnUpdate.Size = New System.Drawing.Size(75, 25)
		Me.btnUpdate.TabIndex = 56
		Me.btnUpdate.Text = "更　新"
		Me.btnUpdate.UseVisualStyleBackColor = True
		'
		'Button3
		'
		Me.Button3.Location = New System.Drawing.Point(295, 517)
		Me.Button3.Name = "Button3"
		Me.Button3.Size = New System.Drawing.Size(75, 25)
		Me.Button3.TabIndex = 48
		Me.Button3.Text = "業者選択"
		Me.Button3.UseVisualStyleBackColor = True
		'
		'dtpCertification
		'
		Me.dtpCertification.AllowSpinLoop = False
		Me.dtpCertification.AutoSize = False
		Me.dtpCertification.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.dtpCertification.Calendar.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
		Me.dtpCertification.DisplayFormat.CustomFormat = "yyyy年MM月dd日"
		Me.dtpCertification.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
		Me.dtpCertification.DisplayFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
			Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
			Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
		Me.dtpCertification.EditFormat.CustomFormat = "yyyy年MM月dd日"
		Me.dtpCertification.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
		Me.dtpCertification.EditFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
			Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
			Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
		Me.dtpCertification.ImagePadding = New System.Windows.Forms.Padding(0)
		Me.dtpCertification.Location = New System.Drawing.Point(118, 537)
		Me.dtpCertification.Name = "dtpCertification"
		Me.dtpCertification.Size = New System.Drawing.Size(140, 24)
		Me.dtpCertification.TabIndex = 47
		Me.dtpCertification.Tag = Nothing
		Me.dtpCertification.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
		'
		'dtpApplication
		'
		Me.dtpApplication.AllowSpinLoop = False
		Me.dtpApplication.AutoSize = False
		Me.dtpApplication.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.dtpApplication.Calendar.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
		Me.dtpApplication.DisplayFormat.CustomFormat = "yyyy年MM月dd日"
		Me.dtpApplication.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
		Me.dtpApplication.DisplayFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
			Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
			Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
		Me.dtpApplication.EditFormat.CustomFormat = "yyyy年MM月dd日"
		Me.dtpApplication.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
		Me.dtpApplication.EditFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
			Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
			Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
		Me.dtpApplication.ImagePadding = New System.Windows.Forms.Padding(0)
		Me.dtpApplication.Location = New System.Drawing.Point(118, 507)
		Me.dtpApplication.Name = "dtpApplication"
		Me.dtpApplication.Size = New System.Drawing.Size(140, 24)
		Me.dtpApplication.TabIndex = 46
		Me.dtpApplication.Tag = Nothing
		Me.dtpApplication.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
		'
		'dtpApplicationTo
		'
		Me.dtpApplicationTo.AllowSpinLoop = False
		Me.dtpApplicationTo.AutoSize = False
		Me.dtpApplicationTo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.dtpApplicationTo.Calendar.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
		Me.dtpApplicationTo.DisplayFormat.CustomFormat = "yyyy年MM月dd日"
		Me.dtpApplicationTo.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
		Me.dtpApplicationTo.DisplayFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
			Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
			Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
		Me.dtpApplicationTo.EditFormat.CustomFormat = "yyyy年MM月dd日"
		Me.dtpApplicationTo.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
		Me.dtpApplicationTo.EditFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
			Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
			Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
		Me.dtpApplicationTo.ImagePadding = New System.Windows.Forms.Padding(0)
		Me.dtpApplicationTo.Location = New System.Drawing.Point(295, 478)
		Me.dtpApplicationTo.Name = "dtpApplicationTo"
		Me.dtpApplicationTo.Size = New System.Drawing.Size(140, 24)
		Me.dtpApplicationTo.TabIndex = 45
		Me.dtpApplicationTo.Tag = Nothing
		Me.dtpApplicationTo.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
		'
		'dtpApplicationFrom
		'
		Me.dtpApplicationFrom.AllowSpinLoop = False
		Me.dtpApplicationFrom.AutoSize = False
		Me.dtpApplicationFrom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.dtpApplicationFrom.Calendar.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
		Me.dtpApplicationFrom.DisplayFormat.CustomFormat = "yyyy年MM月dd日"
		Me.dtpApplicationFrom.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
		Me.dtpApplicationFrom.DisplayFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
			Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
			Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
		Me.dtpApplicationFrom.EditFormat.CustomFormat = "yyyy年MM月dd日"
		Me.dtpApplicationFrom.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
		Me.dtpApplicationFrom.EditFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
			Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
			Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
		Me.dtpApplicationFrom.ImagePadding = New System.Windows.Forms.Padding(0)
		Me.dtpApplicationFrom.Location = New System.Drawing.Point(118, 478)
		Me.dtpApplicationFrom.Name = "dtpApplicationFrom"
		Me.dtpApplicationFrom.Size = New System.Drawing.Size(140, 24)
		Me.dtpApplicationFrom.TabIndex = 44
		Me.dtpApplicationFrom.Tag = Nothing
		Me.dtpApplicationFrom.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
		'
		'dtpEffectiveTo
		'
		Me.dtpEffectiveTo.AllowSpinLoop = False
		Me.dtpEffectiveTo.AutoSize = False
		Me.dtpEffectiveTo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.dtpEffectiveTo.Calendar.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
		Me.dtpEffectiveTo.DisplayFormat.CustomFormat = "yyyy年MM月dd日"
		Me.dtpEffectiveTo.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
		Me.dtpEffectiveTo.DisplayFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
			Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
			Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
		Me.dtpEffectiveTo.EditFormat.CustomFormat = "yyyy年MM月dd日"
		Me.dtpEffectiveTo.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
		Me.dtpEffectiveTo.EditFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
			Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
			Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
		Me.dtpEffectiveTo.ImagePadding = New System.Windows.Forms.Padding(0)
		Me.dtpEffectiveTo.Location = New System.Drawing.Point(295, 447)
		Me.dtpEffectiveTo.Name = "dtpEffectiveTo"
		Me.dtpEffectiveTo.Size = New System.Drawing.Size(140, 24)
		Me.dtpEffectiveTo.TabIndex = 43
		Me.dtpEffectiveTo.Tag = Nothing
		Me.dtpEffectiveTo.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
		'
		'dtpEffectiveFrom
		'
		Me.dtpEffectiveFrom.AllowSpinLoop = False
		Me.dtpEffectiveFrom.AutoSize = False
		Me.dtpEffectiveFrom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.dtpEffectiveFrom.Calendar.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
		Me.dtpEffectiveFrom.DisplayFormat.CustomFormat = "yyyy年MM月dd日"
		Me.dtpEffectiveFrom.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
		Me.dtpEffectiveFrom.DisplayFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
			Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
			Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
		Me.dtpEffectiveFrom.EditFormat.CustomFormat = "yyyy年MM月dd日"
		Me.dtpEffectiveFrom.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
		Me.dtpEffectiveFrom.EditFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
			Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
			Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
		Me.dtpEffectiveFrom.ImagePadding = New System.Windows.Forms.Padding(0)
		Me.dtpEffectiveFrom.Location = New System.Drawing.Point(118, 447)
		Me.dtpEffectiveFrom.Name = "dtpEffectiveFrom"
		Me.dtpEffectiveFrom.Size = New System.Drawing.Size(140, 24)
		Me.dtpEffectiveFrom.TabIndex = 42
		Me.dtpEffectiveFrom.Tag = Nothing
		Me.dtpEffectiveFrom.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
		'
		'btnDelete
		'
		Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.btnDelete.Location = New System.Drawing.Point(6, 708)
		Me.btnDelete.Name = "btnDelete"
		Me.btnDelete.Size = New System.Drawing.Size(75, 25)
		Me.btnDelete.TabIndex = 41
		Me.btnDelete.Text = "削　除"
		Me.btnDelete.UseVisualStyleBackColor = True
		'
		'btnRegist
		'
		Me.btnRegist.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.btnRegist.Location = New System.Drawing.Point(362, 708)
		Me.btnRegist.Name = "btnRegist"
		Me.btnRegist.Size = New System.Drawing.Size(75, 25)
		Me.btnRegist.TabIndex = 40
		Me.btnRegist.Text = "新規登録"
		Me.btnRegist.UseVisualStyleBackColor = True
		'
		'txtInnerNumber
		'
		Me.txtInnerNumber.Location = New System.Drawing.Point(118, 23)
		Me.txtInnerNumber.Name = "txtInnerNumber"
		Me.txtInnerNumber.ReadOnly = True
		Me.txtInnerNumber.Size = New System.Drawing.Size(121, 24)
		Me.txtInnerNumber.TabIndex = 39
		'
		'txtRemarks
		'
		Me.txtRemarks.Location = New System.Drawing.Point(118, 567)
		Me.txtRemarks.Multiline = True
		Me.txtRemarks.Name = "txtRemarks"
		Me.txtRemarks.Size = New System.Drawing.Size(317, 135)
		Me.txtRemarks.TabIndex = 38
		'
		'Label19
		'
		Me.Label19.Location = New System.Drawing.Point(12, 566)
		Me.Label19.Name = "Label19"
		Me.Label19.Size = New System.Drawing.Size(100, 25)
		Me.Label19.TabIndex = 37
		Me.Label19.Text = "備考："
		Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'Label18
		'
		Me.Label18.Location = New System.Drawing.Point(12, 534)
		Me.Label18.Name = "Label18"
		Me.Label18.Size = New System.Drawing.Size(100, 25)
		Me.Label18.TabIndex = 35
		Me.Label18.Text = "認定日："
		Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'Label17
		'
		Me.Label17.Location = New System.Drawing.Point(12, 504)
		Me.Label17.Name = "Label17"
		Me.Label17.Size = New System.Drawing.Size(100, 25)
		Me.Label17.TabIndex = 33
		Me.Label17.Text = "申請日："
		Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'Label15
		'
		Me.Label15.Location = New System.Drawing.Point(264, 475)
		Me.Label15.Name = "Label15"
		Me.Label15.Size = New System.Drawing.Size(25, 25)
		Me.Label15.TabIndex = 32
		Me.Label15.Text = "～"
		Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'Label16
		'
		Me.Label16.Location = New System.Drawing.Point(12, 474)
		Me.Label16.Name = "Label16"
		Me.Label16.Size = New System.Drawing.Size(100, 25)
		Me.Label16.TabIndex = 29
		Me.Label16.Text = "申請期間："
		Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'Label14
		'
		Me.Label14.Location = New System.Drawing.Point(264, 445)
		Me.Label14.Name = "Label14"
		Me.Label14.Size = New System.Drawing.Size(25, 25)
		Me.Label14.TabIndex = 28
		Me.Label14.Text = "～"
		Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'Label13
		'
		Me.Label13.Location = New System.Drawing.Point(12, 444)
		Me.Label13.Name = "Label13"
		Me.Label13.Size = New System.Drawing.Size(100, 25)
		Me.Label13.TabIndex = 25
		Me.Label13.Text = "有効期間："
		Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'Label12
		'
		Me.Label12.Location = New System.Drawing.Point(12, 385)
		Me.Label12.Name = "Label12"
		Me.Label12.Size = New System.Drawing.Size(100, 25)
		Me.Label12.TabIndex = 24
		Me.Label12.Text = "有効年度："
		Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'cmbYear
		'
		Me.cmbYear.Location = New System.Drawing.Point(118, 385)
		Me.cmbYear.Name = "cmbYear"
		Me.cmbYear.ShowSelectAll = True
		Me.cmbYear.Size = New System.Drawing.Size(317, 50)
		Me.cmbYear.TabIndex = 23
		Me.cmbYear.TagWrap = True
		'
		'Label11
		'
		Me.Label11.Location = New System.Drawing.Point(12, 355)
		Me.Label11.Name = "Label11"
		Me.Label11.Size = New System.Drawing.Size(100, 25)
		Me.Label11.TabIndex = 22
		Me.Label11.Text = "E-Mail："
		Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'txtEmail
		'
		Me.txtEmail.Location = New System.Drawing.Point(118, 355)
		Me.txtEmail.Name = "txtEmail"
		Me.txtEmail.ReadOnly = True
		Me.txtEmail.Size = New System.Drawing.Size(278, 24)
		Me.txtEmail.TabIndex = 21
		'
		'Label10
		'
		Me.Label10.Location = New System.Drawing.Point(12, 325)
		Me.Label10.Name = "Label10"
		Me.Label10.Size = New System.Drawing.Size(100, 25)
		Me.Label10.TabIndex = 20
		Me.Label10.Text = "URL："
		Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'txtUrl
		'
		Me.txtUrl.Location = New System.Drawing.Point(118, 325)
		Me.txtUrl.Name = "txtUrl"
		Me.txtUrl.ReadOnly = True
		Me.txtUrl.Size = New System.Drawing.Size(278, 24)
		Me.txtUrl.TabIndex = 19
		'
		'Label9
		'
		Me.Label9.Location = New System.Drawing.Point(12, 295)
		Me.Label9.Name = "Label9"
		Me.Label9.Size = New System.Drawing.Size(100, 25)
		Me.Label9.TabIndex = 18
		Me.Label9.Text = "FAX番号："
		Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'txtFax
		'
		Me.txtFax.Location = New System.Drawing.Point(118, 295)
		Me.txtFax.Name = "txtFax"
		Me.txtFax.ReadOnly = True
		Me.txtFax.Size = New System.Drawing.Size(121, 24)
		Me.txtFax.TabIndex = 17
		'
		'Label8
		'
		Me.Label8.Location = New System.Drawing.Point(12, 265)
		Me.Label8.Name = "Label8"
		Me.Label8.Size = New System.Drawing.Size(100, 25)
		Me.Label8.TabIndex = 16
		Me.Label8.Text = "電話番号："
		Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'txtTel
		'
		Me.txtTel.Location = New System.Drawing.Point(118, 265)
		Me.txtTel.Name = "txtTel"
		Me.txtTel.ReadOnly = True
		Me.txtTel.Size = New System.Drawing.Size(121, 24)
		Me.txtTel.TabIndex = 15
		'
		'Label7
		'
		Me.Label7.Location = New System.Drawing.Point(12, 235)
		Me.Label7.Name = "Label7"
		Me.Label7.Size = New System.Drawing.Size(100, 25)
		Me.Label7.TabIndex = 14
		Me.Label7.Text = "住所2："
		Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'txtAddress2
		'
		Me.txtAddress2.Location = New System.Drawing.Point(118, 235)
		Me.txtAddress2.Name = "txtAddress2"
		Me.txtAddress2.ReadOnly = True
		Me.txtAddress2.Size = New System.Drawing.Size(278, 24)
		Me.txtAddress2.TabIndex = 13
		'
		'Label6
		'
		Me.Label6.Location = New System.Drawing.Point(12, 205)
		Me.Label6.Name = "Label6"
		Me.Label6.Size = New System.Drawing.Size(100, 25)
		Me.Label6.TabIndex = 12
		Me.Label6.Text = "住所1："
		Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'txtAddress1
		'
		Me.txtAddress1.Location = New System.Drawing.Point(118, 205)
		Me.txtAddress1.Name = "txtAddress1"
		Me.txtAddress1.ReadOnly = True
		Me.txtAddress1.Size = New System.Drawing.Size(278, 24)
		Me.txtAddress1.TabIndex = 11
		'
		'Label5
		'
		Me.Label5.Location = New System.Drawing.Point(12, 174)
		Me.Label5.Name = "Label5"
		Me.Label5.Size = New System.Drawing.Size(100, 25)
		Me.Label5.TabIndex = 10
		Me.Label5.Text = "郵便番号："
		Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'txtZipCode
		'
		Me.txtZipCode.Location = New System.Drawing.Point(118, 175)
		Me.txtZipCode.Name = "txtZipCode"
		Me.txtZipCode.ReadOnly = True
		Me.txtZipCode.Size = New System.Drawing.Size(121, 24)
		Me.txtZipCode.TabIndex = 9
		'
		'Label4
		'
		Me.Label4.Location = New System.Drawing.Point(12, 145)
		Me.Label4.Name = "Label4"
		Me.Label4.Size = New System.Drawing.Size(100, 25)
		Me.Label4.TabIndex = 8
		Me.Label4.Text = "業者名かな："
		Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'txtTraderNameKana
		'
		Me.txtTraderNameKana.Location = New System.Drawing.Point(118, 145)
		Me.txtTraderNameKana.Name = "txtTraderNameKana"
		Me.txtTraderNameKana.Size = New System.Drawing.Size(278, 24)
		Me.txtTraderNameKana.TabIndex = 7
		'
		'Label3
		'
		Me.Label3.Location = New System.Drawing.Point(12, 115)
		Me.Label3.Name = "Label3"
		Me.Label3.Size = New System.Drawing.Size(100, 25)
		Me.Label3.TabIndex = 6
		Me.Label3.Text = "業者名："
		Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'txtTraderName
		'
		Me.txtTraderName.Location = New System.Drawing.Point(118, 115)
		Me.txtTraderName.Name = "txtTraderName"
		Me.txtTraderName.Size = New System.Drawing.Size(278, 24)
		Me.txtTraderName.TabIndex = 5
		'
		'cmbPrefectures
		'
		Me.cmbPrefectures.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cmbPrefectures.Enabled = False
		Me.cmbPrefectures.FormattingEnabled = True
		Me.cmbPrefectures.Location = New System.Drawing.Point(118, 84)
		Me.cmbPrefectures.Name = "cmbPrefectures"
		Me.cmbPrefectures.Size = New System.Drawing.Size(121, 25)
		Me.cmbPrefectures.TabIndex = 4
		'
		'Label2
		'
		Me.Label2.Location = New System.Drawing.Point(12, 84)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(100, 25)
		Me.Label2.TabIndex = 3
		Me.Label2.Text = "都道府県："
		Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'Label1
		'
		Me.Label1.Location = New System.Drawing.Point(12, 54)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(100, 25)
		Me.Label1.TabIndex = 2
		Me.Label1.Text = "業者番号："
		Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'txtTraderNumber
		'
		Me.txtTraderNumber.Location = New System.Drawing.Point(118, 54)
		Me.txtTraderNumber.Name = "txtTraderNumber"
		Me.txtTraderNumber.ReadOnly = True
		Me.txtTraderNumber.Size = New System.Drawing.Size(278, 24)
		Me.txtTraderNumber.TabIndex = 1
		'
		'btnTraderSelect
		'
		Me.btnTraderSelect.Location = New System.Drawing.Point(37, 22)
		Me.btnTraderSelect.Name = "btnTraderSelect"
		Me.btnTraderSelect.Size = New System.Drawing.Size(75, 25)
		Me.btnTraderSelect.TabIndex = 0
		Me.btnTraderSelect.Text = "業者選択"
		Me.btnTraderSelect.UseVisualStyleBackColor = True
		'
		'frmTraderDetail
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 17.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.CaptionDisplayMode = BidEntryManageTool.frmTempForm.StatusDisplayMode.ShowAll
		Me.ClientSize = New System.Drawing.Size(1087, 761)
		Me.Controls.Add(Me.GroupBox4)
		Me.Controls.Add(Me.GroupBox2)
		Me.Controls.Add(Me.GroupBox1)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Name = "frmTraderDetail"
		Me.Text = "frmTraderDetail"
		Me.Controls.SetChildIndex(Me.GroupBox1, 0)
		Me.Controls.SetChildIndex(Me.GroupBox2, 0)
		Me.Controls.SetChildIndex(Me.GroupBox4, 0)
		Me.GroupBox1.ResumeLayout(False)
		CType(Me.C1FGridHistory, System.ComponentModel.ISupportInitialize).EndInit()
		Me.GroupBox2.ResumeLayout(False)
		CType(Me.C1FlexGrid1, System.ComponentModel.ISupportInitialize).EndInit()
		Me.Panel1.ResumeLayout(False)
		Me.GroupBox4.ResumeLayout(False)
		Me.GroupBox4.PerformLayout()
		CType(Me.dtpCertification, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.dtpApplication, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.dtpApplicationTo, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.dtpApplicationFrom, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.dtpEffectiveTo, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.dtpEffectiveFrom, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	Friend WithEvents GroupBox1 As GroupBox
	Friend WithEvents C1FGridHistory As C1.Win.C1FlexGrid.C1FlexGrid
	Friend WithEvents GroupBox2 As GroupBox
	Friend WithEvents C1FlexGrid1 As C1.Win.C1FlexGrid.C1FlexGrid
	Friend WithEvents Panel1 As Panel
	Friend WithEvents Button2 As Button
	Friend WithEvents Button1 As Button
	Friend WithEvents GroupBox4 As GroupBox
	Friend WithEvents dtpEffectiveFrom As C1.Win.Calendar.C1DateEdit
	Friend WithEvents btnDelete As Button
	Friend WithEvents btnRegist As Button
	Friend WithEvents txtInnerNumber As TextBox
	Friend WithEvents txtRemarks As TextBox
	Friend WithEvents Label19 As Label
	Friend WithEvents Label18 As Label
	Friend WithEvents Label17 As Label
	Friend WithEvents Label15 As Label
	Friend WithEvents Label16 As Label
	Friend WithEvents Label14 As Label
	Friend WithEvents Label13 As Label
	Friend WithEvents Label12 As Label
	Friend WithEvents cmbYear As C1.Win.Input.C1MultiSelect
	Friend WithEvents Label11 As Label
	Friend WithEvents txtEmail As TextBox
	Friend WithEvents Label10 As Label
	Friend WithEvents txtUrl As TextBox
	Friend WithEvents Label9 As Label
	Friend WithEvents txtFax As TextBox
	Friend WithEvents Label8 As Label
	Friend WithEvents txtTel As TextBox
	Friend WithEvents Label7 As Label
	Friend WithEvents txtAddress2 As TextBox
	Friend WithEvents Label6 As Label
	Friend WithEvents txtAddress1 As TextBox
	Friend WithEvents Label5 As Label
	Friend WithEvents txtZipCode As TextBox
	Friend WithEvents Label4 As Label
	Friend WithEvents txtTraderNameKana As TextBox
	Friend WithEvents Label3 As Label
	Friend WithEvents txtTraderName As TextBox
	Friend WithEvents cmbPrefectures As ComboBox
	Friend WithEvents Label2 As Label
	Friend WithEvents Label1 As Label
	Friend WithEvents txtTraderNumber As TextBox
	Friend WithEvents btnTraderSelect As Button
	Friend WithEvents dtpEffectiveTo As C1.Win.Calendar.C1DateEdit
	Friend WithEvents dtpCertification As C1.Win.Calendar.C1DateEdit
	Friend WithEvents dtpApplication As C1.Win.Calendar.C1DateEdit
	Friend WithEvents dtpApplicationTo As C1.Win.Calendar.C1DateEdit
	Friend WithEvents dtpApplicationFrom As C1.Win.Calendar.C1DateEdit
	Friend WithEvents btnUpdate As Button
	Friend WithEvents Button3 As Button
End Class
