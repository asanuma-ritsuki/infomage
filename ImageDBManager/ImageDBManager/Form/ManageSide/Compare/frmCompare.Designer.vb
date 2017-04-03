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
		Me.Label1 = New System.Windows.Forms.Label()
		Me.Panel2 = New System.Windows.Forms.Panel()
		Me.btnBack = New System.Windows.Forms.Button()
		Me.GroupBox1 = New System.Windows.Forms.GroupBox()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.cmbUser = New System.Windows.Forms.ComboBox()
		Me.Label3 = New System.Windows.Forms.Label()
		Me.ComboBox1 = New System.Windows.Forms.ComboBox()
		Me.Panel3 = New System.Windows.Forms.Panel()
		Me.Button1 = New System.Windows.Forms.Button()
		Me.C1FlexGrid2 = New C1.Win.C1FlexGrid.C1FlexGrid()
		Me.Panel1.SuspendLayout()
		Me.Panel2.SuspendLayout()
		Me.GroupBox1.SuspendLayout()
		Me.Panel3.SuspendLayout()
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
		Me.Panel1.TabIndex = 8
		'
		'Label1
		'
		Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
		Me.Label1.Font = New System.Drawing.Font("メイリオ", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.Label1.Location = New System.Drawing.Point(0, 0)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(1264, 50)
		Me.Label1.TabIndex = 0
		Me.Label1.Text = "コンペア"
		Me.Label1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
		'
		'Panel2
		'
		Me.Panel2.Controls.Add(Me.btnBack)
		Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
		Me.Panel2.Location = New System.Drawing.Point(0, 851)
		Me.Panel2.Name = "Panel2"
		Me.Panel2.Size = New System.Drawing.Size(1264, 38)
		Me.Panel2.TabIndex = 9
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
		'GroupBox1
		'
		Me.GroupBox1.Controls.Add(Me.C1FlexGrid2)
		Me.GroupBox1.Controls.Add(Me.Panel3)
		Me.GroupBox1.Controls.Add(Me.Label3)
		Me.GroupBox1.Controls.Add(Me.ComboBox1)
		Me.GroupBox1.Controls.Add(Me.Label2)
		Me.GroupBox1.Controls.Add(Me.cmbUser)
		Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Left
		Me.GroupBox1.Location = New System.Drawing.Point(0, 50)
		Me.GroupBox1.Name = "GroupBox1"
		Me.GroupBox1.Size = New System.Drawing.Size(375, 801)
		Me.GroupBox1.TabIndex = 10
		Me.GroupBox1.TabStop = False
		Me.GroupBox1.Text = "コンペア設定"
		'
		'Label2
		'
		Me.Label2.Location = New System.Drawing.Point(17, 21)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(120, 26)
		Me.Label2.TabIndex = 27
		Me.Label2.Text = "コンペアパターン："
		Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'cmbUser
		'
		Me.cmbUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cmbUser.FormattingEnabled = True
		Me.cmbUser.Items.AddRange(New Object() {"エントリ1＝エントリ2", "マスタデータ＝エントリ1"})
		Me.cmbUser.Location = New System.Drawing.Point(146, 23)
		Me.cmbUser.Name = "cmbUser"
		Me.cmbUser.Size = New System.Drawing.Size(204, 25)
		Me.cmbUser.TabIndex = 26
		'
		'Label3
		'
		Me.Label3.Location = New System.Drawing.Point(17, 52)
		Me.Label3.Name = "Label3"
		Me.Label3.Size = New System.Drawing.Size(120, 26)
		Me.Label3.TabIndex = 29
		Me.Label3.Text = "定義名："
		Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'ComboBox1
		'
		Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.ComboBox1.FormattingEnabled = True
		Me.ComboBox1.Location = New System.Drawing.Point(146, 54)
		Me.ComboBox1.Name = "ComboBox1"
		Me.ComboBox1.Size = New System.Drawing.Size(204, 25)
		Me.ComboBox1.TabIndex = 28
		'
		'Panel3
		'
		Me.Panel3.Controls.Add(Me.Button1)
		Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
		Me.Panel3.Location = New System.Drawing.Point(3, 760)
		Me.Panel3.Name = "Panel3"
		Me.Panel3.Size = New System.Drawing.Size(369, 38)
		Me.Panel3.TabIndex = 30
		'
		'Button1
		'
		Me.Button1.Location = New System.Drawing.Point(286, 6)
		Me.Button1.Name = "Button1"
		Me.Button1.Size = New System.Drawing.Size(80, 26)
		Me.Button1.TabIndex = 9
		Me.Button1.Text = "コンペア"
		Me.Button1.UseVisualStyleBackColor = True
		'
		'C1FlexGrid2
		'
		Me.C1FlexGrid2.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
		Me.C1FlexGrid2.AllowEditing = False
		Me.C1FlexGrid2.AllowFiltering = True
		Me.C1FlexGrid2.ColumnInfo = resources.GetString("C1FlexGrid2.ColumnInfo")
		Me.C1FlexGrid2.Dock = System.Windows.Forms.DockStyle.Bottom
		Me.C1FlexGrid2.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid
		Me.C1FlexGrid2.Font = New System.Drawing.Font("Meiryo UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.C1FlexGrid2.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcrossOut
		Me.C1FlexGrid2.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcrossOut
		Me.C1FlexGrid2.Location = New System.Drawing.Point(3, 389)
		Me.C1FlexGrid2.Name = "C1FlexGrid2"
		Me.C1FlexGrid2.Rows.Count = 1
		Me.C1FlexGrid2.Rows.DefaultSize = 20
		Me.C1FlexGrid2.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
		Me.C1FlexGrid2.Size = New System.Drawing.Size(369, 371)
		Me.C1FlexGrid2.TabIndex = 31
		Me.C1FlexGrid2.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.System
		'
		'frmCompare
		'
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
		Me.ClientSize = New System.Drawing.Size(1264, 911)
		Me.Controls.Add(Me.GroupBox1)
		Me.Controls.Add(Me.Panel2)
		Me.Controls.Add(Me.Panel1)
		Me.KeyPreview = True
		Me.Name = "frmCompare"
		Me.Text = "frmCompare"
		Me.UserName = Nothing
		Me.Controls.SetChildIndex(Me.Panel1, 0)
		Me.Controls.SetChildIndex(Me.Panel2, 0)
		Me.Controls.SetChildIndex(Me.GroupBox1, 0)
		Me.Panel1.ResumeLayout(False)
		Me.Panel2.ResumeLayout(False)
		Me.GroupBox1.ResumeLayout(False)
		Me.Panel3.ResumeLayout(False)
		CType(Me.C1FlexGrid2, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	Friend WithEvents Panel1 As Panel
	Friend WithEvents Label1 As Label
	Friend WithEvents Panel2 As Panel
	Friend WithEvents btnBack As Button
	Friend WithEvents GroupBox1 As GroupBox
	Friend WithEvents Label2 As Label
	Friend WithEvents cmbUser As ComboBox
	Friend WithEvents Panel3 As Panel
	Friend WithEvents Button1 As Button
	Friend WithEvents Label3 As Label
	Friend WithEvents ComboBox1 As ComboBox
	Friend WithEvents C1FlexGrid2 As C1.Win.C1FlexGrid.C1FlexGrid
End Class
