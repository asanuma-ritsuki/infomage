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
		Me.Panel1 = New System.Windows.Forms.Panel()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.Panel2 = New System.Windows.Forms.Panel()
		Me.btnBack = New System.Windows.Forms.Button()
		Me.Panel3 = New System.Windows.Forms.Panel()
		Me.GroupBox1 = New System.Windows.Forms.GroupBox()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.cmbUser = New System.Windows.Forms.ComboBox()
		Me.TextBox2 = New System.Windows.Forms.TextBox()
		Me.TextBox1 = New System.Windows.Forms.TextBox()
		Me.Label4 = New System.Windows.Forms.Label()
		Me.Label3 = New System.Windows.Forms.Label()
		Me.Button1 = New System.Windows.Forms.Button()
		Me.GroupBox2 = New System.Windows.Forms.GroupBox()
		Me.C1FlexGrid2 = New C1.Win.C1FlexGrid.C1FlexGrid()
		Me.Panel1.SuspendLayout()
		Me.Panel2.SuspendLayout()
		Me.Panel3.SuspendLayout()
		Me.GroupBox1.SuspendLayout()
		Me.GroupBox2.SuspendLayout()
		CType(Me.C1FlexGrid2, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'Panel1
		'
		Me.Panel1.Controls.Add(Me.Label1)
		Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
		Me.Panel1.Location = New System.Drawing.Point(0, 0)
		Me.Panel1.Name = "Panel1"
		Me.Panel1.Size = New System.Drawing.Size(1264, 50)
		Me.Panel1.TabIndex = 7
		'
		'Label1
		'
		Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
		Me.Label1.Font = New System.Drawing.Font("メイリオ", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.Label1.Location = New System.Drawing.Point(0, 0)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(1264, 50)
		Me.Label1.TabIndex = 0
		Me.Label1.Text = "マスタデータ管理"
		Me.Label1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
		'
		'Panel2
		'
		Me.Panel2.Controls.Add(Me.btnBack)
		Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
		Me.Panel2.Location = New System.Drawing.Point(0, 851)
		Me.Panel2.Name = "Panel2"
		Me.Panel2.Size = New System.Drawing.Size(1264, 38)
		Me.Panel2.TabIndex = 8
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
		'Panel3
		'
		Me.Panel3.Controls.Add(Me.GroupBox1)
		Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
		Me.Panel3.Location = New System.Drawing.Point(0, 50)
		Me.Panel3.Name = "Panel3"
		Me.Panel3.Size = New System.Drawing.Size(1264, 64)
		Me.Panel3.TabIndex = 9
		'
		'GroupBox1
		'
		Me.GroupBox1.Controls.Add(Me.Button1)
		Me.GroupBox1.Controls.Add(Me.TextBox2)
		Me.GroupBox1.Controls.Add(Me.TextBox1)
		Me.GroupBox1.Controls.Add(Me.Label4)
		Me.GroupBox1.Controls.Add(Me.Label3)
		Me.GroupBox1.Controls.Add(Me.Label2)
		Me.GroupBox1.Controls.Add(Me.cmbUser)
		Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
		Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
		Me.GroupBox1.Name = "GroupBox1"
		Me.GroupBox1.Size = New System.Drawing.Size(1264, 64)
		Me.GroupBox1.TabIndex = 0
		Me.GroupBox1.TabStop = False
		Me.GroupBox1.Text = "マスタデータ情報"
		'
		'Label2
		'
		Me.Label2.Location = New System.Drawing.Point(14, 21)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(120, 26)
		Me.Label2.TabIndex = 25
		Me.Label2.Text = "定義名："
		Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'cmbUser
		'
		Me.cmbUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cmbUser.FormattingEnabled = True
		Me.cmbUser.Location = New System.Drawing.Point(143, 23)
		Me.cmbUser.Name = "cmbUser"
		Me.cmbUser.Size = New System.Drawing.Size(204, 25)
		Me.cmbUser.TabIndex = 24
		'
		'TextBox2
		'
		Me.TextBox2.Location = New System.Drawing.Point(644, 23)
		Me.TextBox2.Name = "TextBox2"
		Me.TextBox2.ReadOnly = True
		Me.TextBox2.Size = New System.Drawing.Size(111, 24)
		Me.TextBox2.TabIndex = 32
		'
		'TextBox1
		'
		Me.TextBox1.Location = New System.Drawing.Point(441, 23)
		Me.TextBox1.Name = "TextBox1"
		Me.TextBox1.ReadOnly = True
		Me.TextBox1.Size = New System.Drawing.Size(111, 24)
		Me.TextBox1.TabIndex = 31
		'
		'Label4
		'
		Me.Label4.Location = New System.Drawing.Point(558, 21)
		Me.Label4.Name = "Label4"
		Me.Label4.Size = New System.Drawing.Size(80, 26)
		Me.Label4.TabIndex = 30
		Me.Label4.Text = "レコード数："
		Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'Label3
		'
		Me.Label3.Location = New System.Drawing.Point(355, 21)
		Me.Label3.Name = "Label3"
		Me.Label3.Size = New System.Drawing.Size(80, 26)
		Me.Label3.TabIndex = 29
		Me.Label3.Text = "項目数："
		Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'Button1
		'
		Me.Button1.Location = New System.Drawing.Point(1172, 21)
		Me.Button1.Name = "Button1"
		Me.Button1.Size = New System.Drawing.Size(80, 26)
		Me.Button1.TabIndex = 33
		Me.Button1.Text = "インポート"
		Me.Button1.UseVisualStyleBackColor = True
		'
		'GroupBox2
		'
		Me.GroupBox2.Controls.Add(Me.C1FlexGrid2)
		Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
		Me.GroupBox2.Location = New System.Drawing.Point(0, 114)
		Me.GroupBox2.Name = "GroupBox2"
		Me.GroupBox2.Size = New System.Drawing.Size(1264, 737)
		Me.GroupBox2.TabIndex = 10
		Me.GroupBox2.TabStop = False
		Me.GroupBox2.Text = "マスタデータ詳細"
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
		Me.C1FlexGrid2.Size = New System.Drawing.Size(1258, 714)
		Me.C1FlexGrid2.TabIndex = 5
		Me.C1FlexGrid2.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.System
		'
		'frmMasterManage
		'
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
		Me.ClientSize = New System.Drawing.Size(1264, 911)
		Me.Controls.Add(Me.GroupBox2)
		Me.Controls.Add(Me.Panel3)
		Me.Controls.Add(Me.Panel2)
		Me.Controls.Add(Me.Panel1)
		Me.KeyPreview = True
		Me.Name = "frmMasterManage"
		Me.Text = "frmMasterManage"
		Me.UserName = Nothing
		Me.Controls.SetChildIndex(Me.Panel1, 0)
		Me.Controls.SetChildIndex(Me.Panel2, 0)
		Me.Controls.SetChildIndex(Me.Panel3, 0)
		Me.Controls.SetChildIndex(Me.GroupBox2, 0)
		Me.Panel1.ResumeLayout(False)
		Me.Panel2.ResumeLayout(False)
		Me.Panel3.ResumeLayout(False)
		Me.GroupBox1.ResumeLayout(False)
		Me.GroupBox1.PerformLayout()
		Me.GroupBox2.ResumeLayout(False)
		CType(Me.C1FlexGrid2, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	Friend WithEvents Panel1 As Panel
	Friend WithEvents Label1 As Label
	Friend WithEvents Panel2 As Panel
	Friend WithEvents btnBack As Button
	Friend WithEvents Panel3 As Panel
	Friend WithEvents GroupBox1 As GroupBox
	Friend WithEvents Label2 As Label
	Friend WithEvents cmbUser As ComboBox
	Friend WithEvents TextBox2 As TextBox
	Friend WithEvents TextBox1 As TextBox
	Friend WithEvents Label4 As Label
	Friend WithEvents Label3 As Label
	Friend WithEvents Button1 As Button
	Friend WithEvents GroupBox2 As GroupBox
	Friend WithEvents C1FlexGrid2 As C1.Win.C1FlexGrid.C1FlexGrid
End Class
