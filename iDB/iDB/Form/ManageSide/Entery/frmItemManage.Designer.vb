<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmItemManage
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmItemManage))
		Me.Panel1 = New System.Windows.Forms.Panel()
		Me.C1Label1 = New C1.Win.C1Input.C1Label()
		Me.Panel2 = New System.Windows.Forms.Panel()
		Me.GroupBox2 = New System.Windows.Forms.GroupBox()
		Me.C1InputPanel1 = New C1.Win.C1InputPanel.C1InputPanel()
		Me.InputLabel1 = New C1.Win.C1InputPanel.InputLabel()
		Me.InputComboBox1 = New C1.Win.C1InputPanel.InputComboBox()
		Me.InputLabel2 = New C1.Win.C1InputPanel.InputLabel()
		Me.InputTextBox1 = New C1.Win.C1InputPanel.InputTextBox()
		Me.InputLabel3 = New C1.Win.C1InputPanel.InputLabel()
		Me.InputComboBox2 = New C1.Win.C1InputPanel.InputComboBox()
		Me.InputLabel4 = New C1.Win.C1InputPanel.InputLabel()
		Me.InputComboBox3 = New C1.Win.C1InputPanel.InputComboBox()
		Me.InputLabel5 = New C1.Win.C1InputPanel.InputLabel()
		Me.InputComboBox4 = New C1.Win.C1InputPanel.InputComboBox()
		Me.InputLabel6 = New C1.Win.C1InputPanel.InputLabel()
		Me.InputComboBox5 = New C1.Win.C1InputPanel.InputComboBox()
		Me.InputLabel9 = New C1.Win.C1InputPanel.InputLabel()
		Me.InputTextBox2 = New C1.Win.C1InputPanel.InputTextBox()
		Me.InputLabel10 = New C1.Win.C1InputPanel.InputLabel()
		Me.InputCheckBox2 = New C1.Win.C1InputPanel.InputCheckBox()
		Me.InputLabel8 = New C1.Win.C1InputPanel.InputLabel()
		Me.InputTextBox3 = New C1.Win.C1InputPanel.InputTextBox()
		Me.InputLabel13 = New C1.Win.C1InputPanel.InputLabel()
		Me.InputCheckBox5 = New C1.Win.C1InputPanel.InputCheckBox()
		Me.InputLabel12 = New C1.Win.C1InputPanel.InputLabel()
		Me.InputCheckBox4 = New C1.Win.C1InputPanel.InputCheckBox()
		Me.InputLabel11 = New C1.Win.C1InputPanel.InputLabel()
		Me.InputCheckBox3 = New C1.Win.C1InputPanel.InputCheckBox()
		Me.InputLabel7 = New C1.Win.C1InputPanel.InputLabel()
		Me.InputCheckBox1 = New C1.Win.C1InputPanel.InputCheckBox()
		Me.InputButton1 = New C1.Win.C1InputPanel.InputButton()
		Me.InputButton2 = New C1.Win.C1InputPanel.InputButton()
		Me.InputButton3 = New C1.Win.C1InputPanel.InputButton()
		Me.Panel3 = New System.Windows.Forms.Panel()
		Me.btnExport = New C1.Win.C1Input.C1Button()
		Me.btnBack = New C1.Win.C1Input.C1Button()
		Me.btnImport = New C1.Win.C1Input.C1Button()
		Me.btnCreate = New C1.Win.C1Input.C1Button()
		Me.GroupBox1 = New System.Windows.Forms.GroupBox()
		Me.C1FlexGrid2 = New C1.Win.C1FlexGrid.C1FlexGrid()
		Me.Panel1.SuspendLayout()
		CType(Me.C1Label1, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.Panel2.SuspendLayout()
		Me.GroupBox2.SuspendLayout()
		CType(Me.C1InputPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.Panel3.SuspendLayout()
		CType(Me.btnExport, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.btnBack, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.btnImport, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.btnCreate, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.GroupBox1.SuspendLayout()
		CType(Me.C1FlexGrid2, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'Panel1
		'
		Me.Panel1.Controls.Add(Me.C1Label1)
		Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
		Me.Panel1.Location = New System.Drawing.Point(0, 0)
		Me.Panel1.Name = "Panel1"
		Me.Panel1.Size = New System.Drawing.Size(1016, 50)
		Me.Panel1.TabIndex = 7
		'
		'C1Label1
		'
		Me.C1Label1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.C1Label1.Dock = System.Windows.Forms.DockStyle.Fill
		Me.C1Label1.Font = New System.Drawing.Font("Meiryo UI", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.C1Label1.Location = New System.Drawing.Point(0, 0)
		Me.C1Label1.Name = "C1Label1"
		Me.C1Label1.Size = New System.Drawing.Size(1016, 50)
		Me.C1Label1.TabIndex = 1
		Me.C1Label1.Tag = Nothing
		Me.C1Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.C1Label1.Value = "項目設定"
		'
		'Panel2
		'
		Me.Panel2.Controls.Add(Me.GroupBox2)
		Me.Panel2.Controls.Add(Me.Panel3)
		Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
		Me.Panel2.Location = New System.Drawing.Point(0, 533)
		Me.Panel2.Name = "Panel2"
		Me.Panel2.Size = New System.Drawing.Size(1016, 180)
		Me.Panel2.TabIndex = 8
		'
		'GroupBox2
		'
		Me.GroupBox2.Controls.Add(Me.C1InputPanel1)
		Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
		Me.GroupBox2.Location = New System.Drawing.Point(0, 0)
		Me.GroupBox2.Name = "GroupBox2"
		Me.GroupBox2.Size = New System.Drawing.Size(1016, 142)
		Me.GroupBox2.TabIndex = 9
		Me.GroupBox2.TabStop = False
		Me.GroupBox2.Text = "登録"
		'
		'C1InputPanel1
		'
		Me.C1InputPanel1.AutoSizeElement = C1.Framework.AutoSizeElement.Both
		Me.C1InputPanel1.Dock = System.Windows.Forms.DockStyle.Fill
		Me.C1InputPanel1.Font = New System.Drawing.Font("Yu Gothic UI", 9.0!)
		Me.C1InputPanel1.Items.Add(Me.InputLabel1)
		Me.C1InputPanel1.Items.Add(Me.InputComboBox1)
		Me.C1InputPanel1.Items.Add(Me.InputLabel2)
		Me.C1InputPanel1.Items.Add(Me.InputTextBox1)
		Me.C1InputPanel1.Items.Add(Me.InputLabel3)
		Me.C1InputPanel1.Items.Add(Me.InputComboBox2)
		Me.C1InputPanel1.Items.Add(Me.InputLabel4)
		Me.C1InputPanel1.Items.Add(Me.InputComboBox3)
		Me.C1InputPanel1.Items.Add(Me.InputLabel5)
		Me.C1InputPanel1.Items.Add(Me.InputComboBox4)
		Me.C1InputPanel1.Items.Add(Me.InputLabel6)
		Me.C1InputPanel1.Items.Add(Me.InputComboBox5)
		Me.C1InputPanel1.Items.Add(Me.InputLabel9)
		Me.C1InputPanel1.Items.Add(Me.InputTextBox2)
		Me.C1InputPanel1.Items.Add(Me.InputLabel10)
		Me.C1InputPanel1.Items.Add(Me.InputCheckBox2)
		Me.C1InputPanel1.Items.Add(Me.InputLabel8)
		Me.C1InputPanel1.Items.Add(Me.InputTextBox3)
		Me.C1InputPanel1.Items.Add(Me.InputLabel13)
		Me.C1InputPanel1.Items.Add(Me.InputCheckBox5)
		Me.C1InputPanel1.Items.Add(Me.InputLabel12)
		Me.C1InputPanel1.Items.Add(Me.InputCheckBox4)
		Me.C1InputPanel1.Items.Add(Me.InputLabel11)
		Me.C1InputPanel1.Items.Add(Me.InputCheckBox3)
		Me.C1InputPanel1.Items.Add(Me.InputLabel7)
		Me.C1InputPanel1.Items.Add(Me.InputCheckBox1)
		Me.C1InputPanel1.Items.Add(Me.InputButton1)
		Me.C1InputPanel1.Items.Add(Me.InputButton2)
		Me.C1InputPanel1.Items.Add(Me.InputButton3)
		Me.C1InputPanel1.Location = New System.Drawing.Point(3, 20)
		Me.C1InputPanel1.Name = "C1InputPanel1"
		Me.C1InputPanel1.Size = New System.Drawing.Size(1010, 119)
		Me.C1InputPanel1.TabIndex = 0
		'
		'InputLabel1
		'
		Me.InputLabel1.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.InputLabel1.Height = 26
		Me.InputLabel1.HorizontalAlign = C1.Win.C1InputPanel.InputContentAlignment.Far
		Me.InputLabel1.Name = "InputLabel1"
		Me.InputLabel1.Text = "テーブル区分："
		Me.InputLabel1.VerticalAlign = C1.Win.C1InputPanel.InputContentAlignment.Center
		Me.InputLabel1.Width = 80
		'
		'InputComboBox1
		'
		Me.InputComboBox1.Height = 26
		Me.InputComboBox1.Name = "InputComboBox1"
		Me.InputComboBox1.Width = 150
		'
		'InputLabel2
		'
		Me.InputLabel2.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.InputLabel2.Height = 26
		Me.InputLabel2.HorizontalAlign = C1.Win.C1InputPanel.InputContentAlignment.Far
		Me.InputLabel2.Name = "InputLabel2"
		Me.InputLabel2.Text = "項目名："
		Me.InputLabel2.VerticalAlign = C1.Win.C1InputPanel.InputContentAlignment.Center
		Me.InputLabel2.Width = 80
		'
		'InputTextBox1
		'
		Me.InputTextBox1.Height = 26
		Me.InputTextBox1.Name = "InputTextBox1"
		Me.InputTextBox1.Width = 150
		'
		'InputLabel3
		'
		Me.InputLabel3.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.InputLabel3.Height = 26
		Me.InputLabel3.HorizontalAlign = C1.Win.C1InputPanel.InputContentAlignment.Far
		Me.InputLabel3.Name = "InputLabel3"
		Me.InputLabel3.Text = "文字種："
		Me.InputLabel3.VerticalAlign = C1.Win.C1InputPanel.InputContentAlignment.Center
		Me.InputLabel3.Width = 80
		'
		'InputComboBox2
		'
		Me.InputComboBox2.Break = C1.Win.C1InputPanel.BreakType.Column
		Me.InputComboBox2.Height = 26
		Me.InputComboBox2.Name = "InputComboBox2"
		Me.InputComboBox2.Width = 150
		'
		'InputLabel4
		'
		Me.InputLabel4.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.InputLabel4.Height = 26
		Me.InputLabel4.HorizontalAlign = C1.Win.C1InputPanel.InputContentAlignment.Far
		Me.InputLabel4.Name = "InputLabel4"
		Me.InputLabel4.Text = "制限1："
		Me.InputLabel4.VerticalAlign = C1.Win.C1InputPanel.InputContentAlignment.Center
		Me.InputLabel4.Width = 80
		'
		'InputComboBox3
		'
		Me.InputComboBox3.Height = 26
		Me.InputComboBox3.Name = "InputComboBox3"
		Me.InputComboBox3.Width = 150
		'
		'InputLabel5
		'
		Me.InputLabel5.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.InputLabel5.Height = 26
		Me.InputLabel5.HorizontalAlign = C1.Win.C1InputPanel.InputContentAlignment.Far
		Me.InputLabel5.Name = "InputLabel5"
		Me.InputLabel5.Text = "制限2："
		Me.InputLabel5.VerticalAlign = C1.Win.C1InputPanel.InputContentAlignment.Center
		Me.InputLabel5.Width = 80
		'
		'InputComboBox4
		'
		Me.InputComboBox4.Break = C1.Win.C1InputPanel.BreakType.Column
		Me.InputComboBox4.Height = 26
		Me.InputComboBox4.Name = "InputComboBox4"
		Me.InputComboBox4.Width = 150
		'
		'InputLabel6
		'
		Me.InputLabel6.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.InputLabel6.Height = 26
		Me.InputLabel6.HorizontalAlign = C1.Win.C1InputPanel.InputContentAlignment.Far
		Me.InputLabel6.Name = "InputLabel6"
		Me.InputLabel6.Text = "IME状態："
		Me.InputLabel6.VerticalAlign = C1.Win.C1InputPanel.InputContentAlignment.Center
		Me.InputLabel6.Width = 80
		'
		'InputComboBox5
		'
		Me.InputComboBox5.Height = 26
		Me.InputComboBox5.Name = "InputComboBox5"
		Me.InputComboBox5.Width = 150
		'
		'InputLabel9
		'
		Me.InputLabel9.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.InputLabel9.Height = 26
		Me.InputLabel9.HorizontalAlign = C1.Win.C1InputPanel.InputContentAlignment.Far
		Me.InputLabel9.Name = "InputLabel9"
		Me.InputLabel9.Text = "文字数："
		Me.InputLabel9.VerticalAlign = C1.Win.C1InputPanel.InputContentAlignment.Center
		Me.InputLabel9.Width = 80
		'
		'InputTextBox2
		'
		Me.InputTextBox2.Height = 26
		Me.InputTextBox2.Name = "InputTextBox2"
		Me.InputTextBox2.Width = 150
		'
		'InputLabel10
		'
		Me.InputLabel10.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.InputLabel10.Height = 26
		Me.InputLabel10.HorizontalAlign = C1.Win.C1InputPanel.InputContentAlignment.Far
		Me.InputLabel10.Name = "InputLabel10"
		Me.InputLabel10.Text = "文字数固定："
		Me.InputLabel10.VerticalAlign = C1.Win.C1InputPanel.InputContentAlignment.Center
		Me.InputLabel10.Width = 80
		'
		'InputCheckBox2
		'
		Me.InputCheckBox2.Name = "InputCheckBox2"
		'
		'InputLabel8
		'
		Me.InputLabel8.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.InputLabel8.Height = 26
		Me.InputLabel8.HorizontalAlign = C1.Win.C1InputPanel.InputContentAlignment.Far
		Me.InputLabel8.Name = "InputLabel8"
		Me.InputLabel8.Text = "既定値："
		Me.InputLabel8.VerticalAlign = C1.Win.C1InputPanel.InputContentAlignment.Center
		Me.InputLabel8.Width = 80
		'
		'InputTextBox3
		'
		Me.InputTextBox3.Break = C1.Win.C1InputPanel.BreakType.Column
		Me.InputTextBox3.Height = 26
		Me.InputTextBox3.Name = "InputTextBox3"
		Me.InputTextBox3.Width = 150
		'
		'InputLabel13
		'
		Me.InputLabel13.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.InputLabel13.Height = 26
		Me.InputLabel13.HorizontalAlign = C1.Win.C1InputPanel.InputContentAlignment.Far
		Me.InputLabel13.Name = "InputLabel13"
		Me.InputLabel13.Text = "パディング："
		Me.InputLabel13.VerticalAlign = C1.Win.C1InputPanel.InputContentAlignment.Center
		Me.InputLabel13.Width = 80
		'
		'InputCheckBox5
		'
		Me.InputCheckBox5.Name = "InputCheckBox5"
		'
		'InputLabel12
		'
		Me.InputLabel12.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.InputLabel12.Height = 26
		Me.InputLabel12.HorizontalAlign = C1.Win.C1InputPanel.InputContentAlignment.Far
		Me.InputLabel12.Name = "InputLabel12"
		Me.InputLabel12.Text = "未入力許容："
		Me.InputLabel12.VerticalAlign = C1.Win.C1InputPanel.InputContentAlignment.Center
		Me.InputLabel12.Width = 80
		'
		'InputCheckBox4
		'
		Me.InputCheckBox4.Name = "InputCheckBox4"
		'
		'InputLabel11
		'
		Me.InputLabel11.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.InputLabel11.Height = 26
		Me.InputLabel11.HorizontalAlign = C1.Win.C1InputPanel.InputContentAlignment.Far
		Me.InputLabel11.Name = "InputLabel11"
		Me.InputLabel11.Text = "重複許容："
		Me.InputLabel11.VerticalAlign = C1.Win.C1InputPanel.InputContentAlignment.Center
		Me.InputLabel11.Width = 80
		'
		'InputCheckBox3
		'
		Me.InputCheckBox3.Name = "InputCheckBox3"
		'
		'InputLabel7
		'
		Me.InputLabel7.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.InputLabel7.Height = 26
		Me.InputLabel7.HorizontalAlign = C1.Win.C1InputPanel.InputContentAlignment.Far
		Me.InputLabel7.Name = "InputLabel7"
		Me.InputLabel7.Text = "継承禁止："
		Me.InputLabel7.VerticalAlign = C1.Win.C1InputPanel.InputContentAlignment.Center
		Me.InputLabel7.Width = 80
		'
		'InputCheckBox1
		'
		Me.InputCheckBox1.Break = C1.Win.C1InputPanel.BreakType.Column
		Me.InputCheckBox1.Name = "InputCheckBox1"
		'
		'InputButton1
		'
		Me.InputButton1.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.InputButton1.Height = 26
		Me.InputButton1.Name = "InputButton1"
		Me.InputButton1.Text = "追　加"
		Me.InputButton1.Width = 80
		'
		'InputButton2
		'
		Me.InputButton2.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.InputButton2.Height = 26
		Me.InputButton2.Name = "InputButton2"
		Me.InputButton2.Text = "更　新"
		Me.InputButton2.Width = 80
		'
		'InputButton3
		'
		Me.InputButton3.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.InputButton3.Height = 26
		Me.InputButton3.Name = "InputButton3"
		Me.InputButton3.Text = "削　除"
		Me.InputButton3.Width = 80
		'
		'Panel3
		'
		Me.Panel3.Controls.Add(Me.btnExport)
		Me.Panel3.Controls.Add(Me.btnBack)
		Me.Panel3.Controls.Add(Me.btnImport)
		Me.Panel3.Controls.Add(Me.btnCreate)
		Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
		Me.Panel3.Location = New System.Drawing.Point(0, 142)
		Me.Panel3.Name = "Panel3"
		Me.Panel3.Size = New System.Drawing.Size(1016, 38)
		Me.Panel3.TabIndex = 8
		'
		'btnExport
		'
		Me.btnExport.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.btnExport.Location = New System.Drawing.Point(184, 6)
		Me.btnExport.Name = "btnExport"
		Me.btnExport.Size = New System.Drawing.Size(80, 26)
		Me.btnExport.TabIndex = 16
		Me.btnExport.Text = "エクスポート"
		Me.btnExport.UseVisualStyleBackColor = True
		'
		'btnBack
		'
		Me.btnBack.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.btnBack.Location = New System.Drawing.Point(933, 6)
		Me.btnBack.Name = "btnBack"
		Me.btnBack.Size = New System.Drawing.Size(80, 26)
		Me.btnBack.TabIndex = 13
		Me.btnBack.Text = "戻　る"
		Me.btnBack.UseVisualStyleBackColor = True
		'
		'btnImport
		'
		Me.btnImport.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.btnImport.Location = New System.Drawing.Point(98, 6)
		Me.btnImport.Name = "btnImport"
		Me.btnImport.Size = New System.Drawing.Size(80, 26)
		Me.btnImport.TabIndex = 15
		Me.btnImport.Text = "インポート"
		Me.btnImport.UseVisualStyleBackColor = True
		'
		'btnCreate
		'
		Me.btnCreate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.btnCreate.Location = New System.Drawing.Point(12, 6)
		Me.btnCreate.Name = "btnCreate"
		Me.btnCreate.Size = New System.Drawing.Size(80, 26)
		Me.btnCreate.TabIndex = 14
		Me.btnCreate.Text = "項目作成"
		Me.btnCreate.UseVisualStyleBackColor = True
		'
		'GroupBox1
		'
		Me.GroupBox1.Controls.Add(Me.C1FlexGrid2)
		Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
		Me.GroupBox1.Location = New System.Drawing.Point(0, 50)
		Me.GroupBox1.Name = "GroupBox1"
		Me.GroupBox1.Size = New System.Drawing.Size(1016, 483)
		Me.GroupBox1.TabIndex = 9
		Me.GroupBox1.TabStop = False
		Me.GroupBox1.Text = "項目設定一覧"
		'
		'C1FlexGrid2
		'
		Me.C1FlexGrid2.AllowEditing = False
		Me.C1FlexGrid2.AllowFiltering = True
		Me.C1FlexGrid2.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
		Me.C1FlexGrid2.ColumnInfo = resources.GetString("C1FlexGrid2.ColumnInfo")
		Me.C1FlexGrid2.Dock = System.Windows.Forms.DockStyle.Fill
		Me.C1FlexGrid2.ExtendLastCol = True
		Me.C1FlexGrid2.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.C1FlexGrid2.Location = New System.Drawing.Point(3, 20)
		Me.C1FlexGrid2.Name = "C1FlexGrid2"
		Me.C1FlexGrid2.Rows.DefaultSize = 23
		Me.C1FlexGrid2.Size = New System.Drawing.Size(1010, 460)
		Me.C1FlexGrid2.TabIndex = 4
		'
		'frmItemManage
		'
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
		Me.ClientSize = New System.Drawing.Size(1016, 735)
		Me.Controls.Add(Me.GroupBox1)
		Me.Controls.Add(Me.Panel2)
		Me.Controls.Add(Me.Panel1)
		Me.Name = "frmItemManage"
		Me.Text = "frmItemManage"
		Me.UserName = Nothing
		Me.Controls.SetChildIndex(Me.Panel1, 0)
		Me.Controls.SetChildIndex(Me.Panel2, 0)
		Me.Controls.SetChildIndex(Me.GroupBox1, 0)
		Me.Panel1.ResumeLayout(False)
		CType(Me.C1Label1, System.ComponentModel.ISupportInitialize).EndInit()
		Me.Panel2.ResumeLayout(False)
		Me.GroupBox2.ResumeLayout(False)
		CType(Me.C1InputPanel1, System.ComponentModel.ISupportInitialize).EndInit()
		Me.Panel3.ResumeLayout(False)
		CType(Me.btnExport, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.btnBack, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.btnImport, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.btnCreate, System.ComponentModel.ISupportInitialize).EndInit()
		Me.GroupBox1.ResumeLayout(False)
		CType(Me.C1FlexGrid2, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	Friend WithEvents Panel1 As Panel
	Friend WithEvents C1Label1 As C1.Win.C1Input.C1Label
	Friend WithEvents Panel2 As Panel
	Friend WithEvents GroupBox1 As GroupBox
	Friend WithEvents C1FlexGrid2 As C1.Win.C1FlexGrid.C1FlexGrid
	Friend WithEvents Panel3 As Panel
	Friend WithEvents btnExport As C1.Win.C1Input.C1Button
	Friend WithEvents btnBack As C1.Win.C1Input.C1Button
	Friend WithEvents btnImport As C1.Win.C1Input.C1Button
	Friend WithEvents btnCreate As C1.Win.C1Input.C1Button
	Friend WithEvents GroupBox2 As GroupBox
	Friend WithEvents C1InputPanel1 As C1.Win.C1InputPanel.C1InputPanel
	Friend WithEvents InputLabel1 As C1.Win.C1InputPanel.InputLabel
	Friend WithEvents InputComboBox1 As C1.Win.C1InputPanel.InputComboBox
	Friend WithEvents InputLabel2 As C1.Win.C1InputPanel.InputLabel
	Friend WithEvents InputTextBox1 As C1.Win.C1InputPanel.InputTextBox
	Friend WithEvents InputLabel3 As C1.Win.C1InputPanel.InputLabel
	Friend WithEvents InputComboBox2 As C1.Win.C1InputPanel.InputComboBox
	Friend WithEvents InputLabel4 As C1.Win.C1InputPanel.InputLabel
	Friend WithEvents InputComboBox3 As C1.Win.C1InputPanel.InputComboBox
	Friend WithEvents InputLabel5 As C1.Win.C1InputPanel.InputLabel
	Friend WithEvents InputComboBox4 As C1.Win.C1InputPanel.InputComboBox
	Friend WithEvents InputLabel6 As C1.Win.C1InputPanel.InputLabel
	Friend WithEvents InputComboBox5 As C1.Win.C1InputPanel.InputComboBox
	Friend WithEvents InputLabel9 As C1.Win.C1InputPanel.InputLabel
	Friend WithEvents InputTextBox2 As C1.Win.C1InputPanel.InputTextBox
	Friend WithEvents InputLabel10 As C1.Win.C1InputPanel.InputLabel
	Friend WithEvents InputCheckBox2 As C1.Win.C1InputPanel.InputCheckBox
	Friend WithEvents InputLabel8 As C1.Win.C1InputPanel.InputLabel
	Friend WithEvents InputTextBox3 As C1.Win.C1InputPanel.InputTextBox
	Friend WithEvents InputLabel13 As C1.Win.C1InputPanel.InputLabel
	Friend WithEvents InputCheckBox5 As C1.Win.C1InputPanel.InputCheckBox
	Friend WithEvents InputLabel12 As C1.Win.C1InputPanel.InputLabel
	Friend WithEvents InputCheckBox4 As C1.Win.C1InputPanel.InputCheckBox
	Friend WithEvents InputLabel11 As C1.Win.C1InputPanel.InputLabel
	Friend WithEvents InputCheckBox3 As C1.Win.C1InputPanel.InputCheckBox
	Friend WithEvents InputLabel7 As C1.Win.C1InputPanel.InputLabel
	Friend WithEvents InputCheckBox1 As C1.Win.C1InputPanel.InputCheckBox
	Friend WithEvents InputButton1 As C1.Win.C1InputPanel.InputButton
	Friend WithEvents InputButton2 As C1.Win.C1InputPanel.InputButton
	Friend WithEvents InputButton3 As C1.Win.C1InputPanel.InputButton
End Class
