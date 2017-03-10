<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCompare
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCompare))
		Me.Panel1 = New System.Windows.Forms.Panel()
		Me.C1Label2 = New C1.Win.C1Input.C1Label()
		Me.Panel2 = New System.Windows.Forms.Panel()
		Me.btnBack = New C1.Win.C1Input.C1Button()
		Me.Panel3 = New System.Windows.Forms.Panel()
		Me.GroupBox1 = New System.Windows.Forms.GroupBox()
		Me.C1FlexGrid2 = New C1.Win.C1FlexGrid.C1FlexGrid()
		Me.Panel6 = New System.Windows.Forms.Panel()
		Me.btnCompare = New C1.Win.C1Input.C1Button()
		Me.Panel5 = New System.Windows.Forms.Panel()
		Me.cmbCompareTarget02 = New C1.Win.C1Input.C1ComboBox()
		Me.C1Label1 = New C1.Win.C1Input.C1Label()
		Me.cmbCompareTarget01 = New C1.Win.C1Input.C1ComboBox()
		Me.C1Label4 = New C1.Win.C1Input.C1Label()
		Me.Panel4 = New System.Windows.Forms.Panel()
		Me.GroupBox2 = New System.Windows.Forms.GroupBox()
		Me.C1FlexGrid1 = New C1.Win.C1FlexGrid.C1FlexGrid()
		Me.Panel1.SuspendLayout()
		CType(Me.C1Label2, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.Panel2.SuspendLayout()
		CType(Me.btnBack, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.Panel3.SuspendLayout()
		Me.GroupBox1.SuspendLayout()
		CType(Me.C1FlexGrid2, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.Panel6.SuspendLayout()
		CType(Me.btnCompare, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.Panel5.SuspendLayout()
		CType(Me.cmbCompareTarget02, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.C1Label1, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.cmbCompareTarget01, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.C1Label4, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.Panel4.SuspendLayout()
		Me.GroupBox2.SuspendLayout()
		CType(Me.C1FlexGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'Panel1
		'
		Me.Panel1.Controls.Add(Me.C1Label2)
		Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
		Me.Panel1.Location = New System.Drawing.Point(0, 0)
		Me.Panel1.Name = "Panel1"
		Me.Panel1.Size = New System.Drawing.Size(1016, 50)
		Me.Panel1.TabIndex = 6
		'
		'C1Label2
		'
		Me.C1Label2.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.C1Label2.Dock = System.Windows.Forms.DockStyle.Fill
		Me.C1Label2.Font = New System.Drawing.Font("Meiryo UI", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.C1Label2.Location = New System.Drawing.Point(0, 0)
		Me.C1Label2.Name = "C1Label2"
		Me.C1Label2.Size = New System.Drawing.Size(1016, 50)
		Me.C1Label2.TabIndex = 0
		Me.C1Label2.Tag = Nothing
		Me.C1Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.C1Label2.Value = "コンペア"
		'
		'Panel2
		'
		Me.Panel2.Controls.Add(Me.btnBack)
		Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
		Me.Panel2.Location = New System.Drawing.Point(0, 675)
		Me.Panel2.Name = "Panel2"
		Me.Panel2.Size = New System.Drawing.Size(1016, 38)
		Me.Panel2.TabIndex = 7
		'
		'btnBack
		'
		Me.btnBack.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.btnBack.Location = New System.Drawing.Point(924, 6)
		Me.btnBack.Name = "btnBack"
		Me.btnBack.Size = New System.Drawing.Size(80, 26)
		Me.btnBack.TabIndex = 13
		Me.btnBack.Text = "戻　る"
		Me.btnBack.UseVisualStyleBackColor = True
		'
		'Panel3
		'
		Me.Panel3.Controls.Add(Me.GroupBox1)
		Me.Panel3.Dock = System.Windows.Forms.DockStyle.Left
		Me.Panel3.Location = New System.Drawing.Point(0, 50)
		Me.Panel3.Name = "Panel3"
		Me.Panel3.Size = New System.Drawing.Size(500, 625)
		Me.Panel3.TabIndex = 8
		'
		'GroupBox1
		'
		Me.GroupBox1.Controls.Add(Me.C1FlexGrid2)
		Me.GroupBox1.Controls.Add(Me.Panel6)
		Me.GroupBox1.Controls.Add(Me.Panel5)
		Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
		Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
		Me.GroupBox1.Name = "GroupBox1"
		Me.GroupBox1.Size = New System.Drawing.Size(500, 625)
		Me.GroupBox1.TabIndex = 20
		Me.GroupBox1.TabStop = False
		Me.GroupBox1.Text = "コンペア設定"
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
		Me.C1FlexGrid2.Location = New System.Drawing.Point(3, 100)
		Me.C1FlexGrid2.Name = "C1FlexGrid2"
		Me.C1FlexGrid2.Rows.DefaultSize = 23
		Me.C1FlexGrid2.Size = New System.Drawing.Size(494, 484)
		Me.C1FlexGrid2.TabIndex = 21
		'
		'Panel6
		'
		Me.Panel6.Controls.Add(Me.btnCompare)
		Me.Panel6.Dock = System.Windows.Forms.DockStyle.Bottom
		Me.Panel6.Location = New System.Drawing.Point(3, 584)
		Me.Panel6.Name = "Panel6"
		Me.Panel6.Size = New System.Drawing.Size(494, 38)
		Me.Panel6.TabIndex = 21
		'
		'btnCompare
		'
		Me.btnCompare.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.btnCompare.Location = New System.Drawing.Point(411, 6)
		Me.btnCompare.Name = "btnCompare"
		Me.btnCompare.Size = New System.Drawing.Size(80, 26)
		Me.btnCompare.TabIndex = 14
		Me.btnCompare.Text = "コンペア"
		Me.btnCompare.UseVisualStyleBackColor = True
		'
		'Panel5
		'
		Me.Panel5.Controls.Add(Me.cmbCompareTarget02)
		Me.Panel5.Controls.Add(Me.C1Label1)
		Me.Panel5.Controls.Add(Me.cmbCompareTarget01)
		Me.Panel5.Controls.Add(Me.C1Label4)
		Me.Panel5.Dock = System.Windows.Forms.DockStyle.Top
		Me.Panel5.Location = New System.Drawing.Point(3, 20)
		Me.Panel5.Name = "Panel5"
		Me.Panel5.Size = New System.Drawing.Size(494, 80)
		Me.Panel5.TabIndex = 20
		'
		'cmbCompareTarget02
		'
		Me.cmbCompareTarget02.AllowSpinLoop = False
		Me.cmbCompareTarget02.AutoSize = False
		Me.cmbCompareTarget02.Cursor = System.Windows.Forms.Cursors.Arrow
		Me.cmbCompareTarget02.DropDownStyle = C1.Win.C1Input.DropDownStyle.DropDownList
		Me.cmbCompareTarget02.GapHeight = 0
		Me.cmbCompareTarget02.ImagePadding = New System.Windows.Forms.Padding(0)
		Me.cmbCompareTarget02.ItemsDisplayMember = ""
		Me.cmbCompareTarget02.ItemsValueMember = ""
		Me.cmbCompareTarget02.Location = New System.Drawing.Point(203, 44)
		Me.cmbCompareTarget02.Name = "cmbCompareTarget02"
		Me.cmbCompareTarget02.Size = New System.Drawing.Size(200, 26)
		Me.cmbCompareTarget02.TabIndex = 21
		Me.cmbCompareTarget02.Tag = Nothing
		Me.cmbCompareTarget02.TextDetached = True
		'
		'C1Label1
		'
		Me.C1Label1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.C1Label1.Location = New System.Drawing.Point(77, 44)
		Me.C1Label1.Name = "C1Label1"
		Me.C1Label1.Size = New System.Drawing.Size(120, 26)
		Me.C1Label1.TabIndex = 20
		Me.C1Label1.Tag = Nothing
		Me.C1Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.C1Label1.Value = "比較対象2："
		'
		'cmbCompareTarget01
		'
		Me.cmbCompareTarget01.AllowSpinLoop = False
		Me.cmbCompareTarget01.AutoSize = False
		Me.cmbCompareTarget01.Cursor = System.Windows.Forms.Cursors.Arrow
		Me.cmbCompareTarget01.DropDownStyle = C1.Win.C1Input.DropDownStyle.DropDownList
		Me.cmbCompareTarget01.GapHeight = 0
		Me.cmbCompareTarget01.ImagePadding = New System.Windows.Forms.Padding(0)
		Me.cmbCompareTarget01.ItemsDisplayMember = ""
		Me.cmbCompareTarget01.ItemsValueMember = ""
		Me.cmbCompareTarget01.Location = New System.Drawing.Point(203, 12)
		Me.cmbCompareTarget01.Name = "cmbCompareTarget01"
		Me.cmbCompareTarget01.Size = New System.Drawing.Size(200, 26)
		Me.cmbCompareTarget01.TabIndex = 19
		Me.cmbCompareTarget01.Tag = Nothing
		Me.cmbCompareTarget01.TextDetached = True
		'
		'C1Label4
		'
		Me.C1Label4.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.C1Label4.Location = New System.Drawing.Point(77, 12)
		Me.C1Label4.Name = "C1Label4"
		Me.C1Label4.Size = New System.Drawing.Size(120, 26)
		Me.C1Label4.TabIndex = 18
		Me.C1Label4.Tag = Nothing
		Me.C1Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.C1Label4.Value = "比較対象1："
		'
		'Panel4
		'
		Me.Panel4.Controls.Add(Me.GroupBox2)
		Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
		Me.Panel4.Location = New System.Drawing.Point(500, 50)
		Me.Panel4.Name = "Panel4"
		Me.Panel4.Size = New System.Drawing.Size(516, 625)
		Me.Panel4.TabIndex = 9
		'
		'GroupBox2
		'
		Me.GroupBox2.Controls.Add(Me.C1FlexGrid1)
		Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
		Me.GroupBox2.Location = New System.Drawing.Point(0, 0)
		Me.GroupBox2.Name = "GroupBox2"
		Me.GroupBox2.Size = New System.Drawing.Size(516, 625)
		Me.GroupBox2.TabIndex = 0
		Me.GroupBox2.TabStop = False
		Me.GroupBox2.Text = "コンペア結果"
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
		Me.C1FlexGrid1.Location = New System.Drawing.Point(3, 20)
		Me.C1FlexGrid1.Name = "C1FlexGrid1"
		Me.C1FlexGrid1.Rows.DefaultSize = 23
		Me.C1FlexGrid1.Size = New System.Drawing.Size(510, 602)
		Me.C1FlexGrid1.TabIndex = 22
		'
		'frmCompare
		'
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
		Me.ClientSize = New System.Drawing.Size(1016, 735)
		Me.Controls.Add(Me.Panel4)
		Me.Controls.Add(Me.Panel3)
		Me.Controls.Add(Me.Panel2)
		Me.Controls.Add(Me.Panel1)
		Me.Name = "frmCompare"
		Me.Text = "frmCompare"
		Me.UserName = Nothing
		Me.Controls.SetChildIndex(Me.Panel1, 0)
		Me.Controls.SetChildIndex(Me.Panel2, 0)
		Me.Controls.SetChildIndex(Me.Panel3, 0)
		Me.Controls.SetChildIndex(Me.Panel4, 0)
		Me.Panel1.ResumeLayout(False)
		CType(Me.C1Label2, System.ComponentModel.ISupportInitialize).EndInit()
		Me.Panel2.ResumeLayout(False)
		CType(Me.btnBack, System.ComponentModel.ISupportInitialize).EndInit()
		Me.Panel3.ResumeLayout(False)
		Me.GroupBox1.ResumeLayout(False)
		CType(Me.C1FlexGrid2, System.ComponentModel.ISupportInitialize).EndInit()
		Me.Panel6.ResumeLayout(False)
		CType(Me.btnCompare, System.ComponentModel.ISupportInitialize).EndInit()
		Me.Panel5.ResumeLayout(False)
		CType(Me.cmbCompareTarget02, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.C1Label1, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.cmbCompareTarget01, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.C1Label4, System.ComponentModel.ISupportInitialize).EndInit()
		Me.Panel4.ResumeLayout(False)
		Me.GroupBox2.ResumeLayout(False)
		CType(Me.C1FlexGrid1, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	Friend WithEvents Panel1 As Panel
	Friend WithEvents C1Label2 As C1.Win.C1Input.C1Label
	Friend WithEvents Panel2 As Panel
	Friend WithEvents btnBack As C1.Win.C1Input.C1Button
	Friend WithEvents Panel3 As Panel
	Friend WithEvents GroupBox1 As GroupBox
	Friend WithEvents cmbCompareTarget01 As C1.Win.C1Input.C1ComboBox
	Friend WithEvents C1Label4 As C1.Win.C1Input.C1Label
	Friend WithEvents Panel4 As Panel
	Friend WithEvents GroupBox2 As GroupBox
	Friend WithEvents Panel5 As Panel
	Friend WithEvents cmbCompareTarget02 As C1.Win.C1Input.C1ComboBox
	Friend WithEvents C1Label1 As C1.Win.C1Input.C1Label
	Friend WithEvents C1FlexGrid2 As C1.Win.C1FlexGrid.C1FlexGrid
	Friend WithEvents Panel6 As Panel
	Friend WithEvents btnCompare As C1.Win.C1Input.C1Button
	Friend WithEvents C1FlexGrid1 As C1.Win.C1FlexGrid.C1FlexGrid
End Class
