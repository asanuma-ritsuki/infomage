<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProjectDetail
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmProjectDetail))
		Me.Panel1 = New System.Windows.Forms.Panel()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.Panel2 = New System.Windows.Forms.Panel()
		Me.btnBack = New System.Windows.Forms.Button()
		Me.GroupBox1 = New System.Windows.Forms.GroupBox()
		Me.Label4 = New System.Windows.Forms.Label()
		Me.txtOrderID = New System.Windows.Forms.TextBox()
		Me.Label7 = New System.Windows.Forms.Label()
		Me.TextBox4 = New System.Windows.Forms.TextBox()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.Label3 = New System.Windows.Forms.Label()
		Me.TextBox2 = New System.Windows.Forms.TextBox()
		Me.Button1 = New System.Windows.Forms.Button()
		Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
		Me.Button2 = New System.Windows.Forms.Button()
		Me.GroupBox2 = New System.Windows.Forms.GroupBox()
		Me.C1FGridProcessList = New C1.Win.C1FlexGrid.C1FlexGrid()
		Me.GroupBox3 = New System.Windows.Forms.GroupBox()
		Me.GroupBox4 = New System.Windows.Forms.GroupBox()
		Me.C1FGridAdoption = New C1.Win.C1FlexGrid.C1FlexGrid()
		Me.Label5 = New System.Windows.Forms.Label()
		Me.GroupBox5 = New System.Windows.Forms.GroupBox()
		Me.Panel3 = New System.Windows.Forms.Panel()
		Me.C1FGridResult = New C1.Win.C1FlexGrid.C1FlexGrid()
		Me.Button3 = New System.Windows.Forms.Button()
		Me.Panel1.SuspendLayout()
		Me.Panel2.SuspendLayout()
		Me.GroupBox1.SuspendLayout()
		Me.GroupBox2.SuspendLayout()
		CType(Me.C1FGridProcessList, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.GroupBox3.SuspendLayout()
		Me.GroupBox4.SuspendLayout()
		CType(Me.C1FGridAdoption, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.GroupBox5.SuspendLayout()
		Me.Panel3.SuspendLayout()
		CType(Me.C1FGridResult, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'Panel1
		'
		Me.Panel1.Controls.Add(Me.Label1)
		Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
		Me.Panel1.Location = New System.Drawing.Point(0, 0)
		Me.Panel1.Name = "Panel1"
		Me.Panel1.Size = New System.Drawing.Size(1264, 50)
		Me.Panel1.TabIndex = 3
		'
		'Label1
		'
		Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
		Me.Label1.Font = New System.Drawing.Font("メイリオ", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.Label1.Location = New System.Drawing.Point(0, 0)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(1264, 50)
		Me.Label1.TabIndex = 0
		Me.Label1.Text = "案件管理"
		Me.Label1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
		'
		'Panel2
		'
		Me.Panel2.Controls.Add(Me.btnBack)
		Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
		Me.Panel2.Location = New System.Drawing.Point(0, 851)
		Me.Panel2.Name = "Panel2"
		Me.Panel2.Size = New System.Drawing.Size(1264, 38)
		Me.Panel2.TabIndex = 4
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
		Me.GroupBox1.Controls.Add(Me.Button2)
		Me.GroupBox1.Controls.Add(Me.DateTimePicker1)
		Me.GroupBox1.Controls.Add(Me.Button1)
		Me.GroupBox1.Controls.Add(Me.Label3)
		Me.GroupBox1.Controls.Add(Me.TextBox2)
		Me.GroupBox1.Controls.Add(Me.Label2)
		Me.GroupBox1.Controls.Add(Me.Label7)
		Me.GroupBox1.Controls.Add(Me.TextBox4)
		Me.GroupBox1.Controls.Add(Me.Label4)
		Me.GroupBox1.Controls.Add(Me.txtOrderID)
		Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
		Me.GroupBox1.Location = New System.Drawing.Point(0, 50)
		Me.GroupBox1.Name = "GroupBox1"
		Me.GroupBox1.Size = New System.Drawing.Size(1264, 89)
		Me.GroupBox1.TabIndex = 5
		Me.GroupBox1.TabStop = False
		Me.GroupBox1.Text = "案件情報"
		'
		'Label4
		'
		Me.Label4.Location = New System.Drawing.Point(15, 21)
		Me.Label4.Name = "Label4"
		Me.Label4.Size = New System.Drawing.Size(120, 26)
		Me.Label4.TabIndex = 6
		Me.Label4.Text = "案件ID："
		Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'txtOrderID
		'
		Me.txtOrderID.Location = New System.Drawing.Point(141, 23)
		Me.txtOrderID.Name = "txtOrderID"
		Me.txtOrderID.ReadOnly = True
		Me.txtOrderID.Size = New System.Drawing.Size(204, 24)
		Me.txtOrderID.TabIndex = 7
		'
		'Label7
		'
		Me.Label7.Location = New System.Drawing.Point(15, 51)
		Me.Label7.Name = "Label7"
		Me.Label7.Size = New System.Drawing.Size(120, 26)
		Me.Label7.TabIndex = 18
		Me.Label7.Text = "案件名："
		Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'TextBox4
		'
		Me.TextBox4.Location = New System.Drawing.Point(141, 53)
		Me.TextBox4.Name = "TextBox4"
		Me.TextBox4.Size = New System.Drawing.Size(204, 24)
		Me.TextBox4.TabIndex = 19
		'
		'Label2
		'
		Me.Label2.Location = New System.Drawing.Point(353, 21)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(120, 26)
		Me.Label2.TabIndex = 20
		Me.Label2.Text = "納品予定日："
		Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'Label3
		'
		Me.Label3.Location = New System.Drawing.Point(353, 51)
		Me.Label3.Name = "Label3"
		Me.Label3.Size = New System.Drawing.Size(120, 26)
		Me.Label3.TabIndex = 22
		Me.Label3.Text = "備考："
		Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'TextBox2
		'
		Me.TextBox2.Location = New System.Drawing.Point(479, 53)
		Me.TextBox2.Name = "TextBox2"
		Me.TextBox2.Size = New System.Drawing.Size(687, 24)
		Me.TextBox2.TabIndex = 23
		'
		'Button1
		'
		Me.Button1.Location = New System.Drawing.Point(1172, 51)
		Me.Button1.Name = "Button1"
		Me.Button1.Size = New System.Drawing.Size(80, 26)
		Me.Button1.TabIndex = 24
		Me.Button1.Text = "登　録"
		Me.Button1.UseVisualStyleBackColor = True
		'
		'DateTimePicker1
		'
		Me.DateTimePicker1.Location = New System.Drawing.Point(479, 23)
		Me.DateTimePicker1.Name = "DateTimePicker1"
		Me.DateTimePicker1.Size = New System.Drawing.Size(200, 24)
		Me.DateTimePicker1.TabIndex = 25
		'
		'Button2
		'
		Me.Button2.Location = New System.Drawing.Point(1172, 21)
		Me.Button2.Name = "Button2"
		Me.Button2.Size = New System.Drawing.Size(80, 26)
		Me.Button2.TabIndex = 26
		Me.Button2.Text = "ショートカット"
		Me.Button2.UseVisualStyleBackColor = True
		'
		'GroupBox2
		'
		Me.GroupBox2.Controls.Add(Me.Label5)
		Me.GroupBox2.Controls.Add(Me.GroupBox4)
		Me.GroupBox2.Controls.Add(Me.GroupBox3)
		Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Left
		Me.GroupBox2.Location = New System.Drawing.Point(0, 139)
		Me.GroupBox2.Name = "GroupBox2"
		Me.GroupBox2.Size = New System.Drawing.Size(495, 712)
		Me.GroupBox2.TabIndex = 6
		Me.GroupBox2.TabStop = False
		Me.GroupBox2.Text = "処理工程"
		'
		'C1FGridProcessList
		'
		Me.C1FGridProcessList.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
		Me.C1FGridProcessList.AllowEditing = False
		Me.C1FGridProcessList.AllowFiltering = True
		Me.C1FGridProcessList.ColumnInfo = "2,0,0,0,0,100,Columns:0{Name:""処理工程"";Caption:""処理工程"";Style:""DataType:System.String;" &
	"TextAlign:LeftCenter;"";}" & Global.Microsoft.VisualBasic.ChrW(9) & "1{Name:""説明"";Caption:""説明"";Style:""DataType:System.String;" &
	"TextAlign:LeftCenter;"";}" & Global.Microsoft.VisualBasic.ChrW(9)
		Me.C1FGridProcessList.Dock = System.Windows.Forms.DockStyle.Fill
		Me.C1FGridProcessList.ExtendLastCol = True
		Me.C1FGridProcessList.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid
		Me.C1FGridProcessList.Font = New System.Drawing.Font("Meiryo UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.C1FGridProcessList.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcrossOut
		Me.C1FGridProcessList.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcrossOut
		Me.C1FGridProcessList.Location = New System.Drawing.Point(3, 20)
		Me.C1FGridProcessList.Name = "C1FGridProcessList"
		Me.C1FGridProcessList.Rows.Count = 1
		Me.C1FGridProcessList.Rows.DefaultSize = 20
		Me.C1FGridProcessList.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
		Me.C1FGridProcessList.Size = New System.Drawing.Size(471, 277)
		Me.C1FGridProcessList.TabIndex = 1
		Me.C1FGridProcessList.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.System
		'
		'GroupBox3
		'
		Me.GroupBox3.Controls.Add(Me.C1FGridProcessList)
		Me.GroupBox3.Location = New System.Drawing.Point(12, 23)
		Me.GroupBox3.Name = "GroupBox3"
		Me.GroupBox3.Size = New System.Drawing.Size(477, 300)
		Me.GroupBox3.TabIndex = 2
		Me.GroupBox3.TabStop = False
		Me.GroupBox3.Text = "処理工程一覧"
		'
		'GroupBox4
		'
		Me.GroupBox4.Controls.Add(Me.C1FGridAdoption)
		Me.GroupBox4.Location = New System.Drawing.Point(12, 362)
		Me.GroupBox4.Name = "GroupBox4"
		Me.GroupBox4.Size = New System.Drawing.Size(477, 300)
		Me.GroupBox4.TabIndex = 3
		Me.GroupBox4.TabStop = False
		Me.GroupBox4.Text = "採用処理工程"
		'
		'C1FGridAdoption
		'
		Me.C1FGridAdoption.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
		Me.C1FGridAdoption.AllowEditing = False
		Me.C1FGridAdoption.AllowFiltering = True
		Me.C1FGridAdoption.ColumnInfo = "2,0,0,0,0,100,Columns:0{Name:""処理工程"";Caption:""処理工程"";Style:""DataType:System.String;" &
	"TextAlign:LeftCenter;"";}" & Global.Microsoft.VisualBasic.ChrW(9) & "1{Name:""説明"";Caption:""説明"";Style:""DataType:System.String;" &
	"TextAlign:LeftCenter;"";}" & Global.Microsoft.VisualBasic.ChrW(9)
		Me.C1FGridAdoption.Dock = System.Windows.Forms.DockStyle.Fill
		Me.C1FGridAdoption.ExtendLastCol = True
		Me.C1FGridAdoption.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid
		Me.C1FGridAdoption.Font = New System.Drawing.Font("Meiryo UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.C1FGridAdoption.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcrossOut
		Me.C1FGridAdoption.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcrossOut
		Me.C1FGridAdoption.Location = New System.Drawing.Point(3, 20)
		Me.C1FGridAdoption.Name = "C1FGridAdoption"
		Me.C1FGridAdoption.Rows.Count = 1
		Me.C1FGridAdoption.Rows.DefaultSize = 20
		Me.C1FGridAdoption.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
		Me.C1FGridAdoption.Size = New System.Drawing.Size(471, 277)
		Me.C1FGridAdoption.TabIndex = 1
		Me.C1FGridAdoption.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.System
		'
		'Label5
		'
		Me.Label5.AutoSize = True
		Me.Label5.Location = New System.Drawing.Point(236, 337)
		Me.Label5.Name = "Label5"
		Me.Label5.Size = New System.Drawing.Size(21, 17)
		Me.Label5.TabIndex = 4
		Me.Label5.Text = "↓"
		'
		'GroupBox5
		'
		Me.GroupBox5.Controls.Add(Me.C1FGridResult)
		Me.GroupBox5.Controls.Add(Me.Panel3)
		Me.GroupBox5.Dock = System.Windows.Forms.DockStyle.Fill
		Me.GroupBox5.Location = New System.Drawing.Point(495, 139)
		Me.GroupBox5.Name = "GroupBox5"
		Me.GroupBox5.Size = New System.Drawing.Size(769, 712)
		Me.GroupBox5.TabIndex = 7
		Me.GroupBox5.TabStop = False
		Me.GroupBox5.Text = "進捗詳細"
		'
		'Panel3
		'
		Me.Panel3.Controls.Add(Me.Button3)
		Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
		Me.Panel3.Location = New System.Drawing.Point(3, 671)
		Me.Panel3.Name = "Panel3"
		Me.Panel3.Size = New System.Drawing.Size(763, 38)
		Me.Panel3.TabIndex = 0
		'
		'C1FGridResult
		'
		Me.C1FGridResult.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
		Me.C1FGridResult.AllowEditing = False
		Me.C1FGridResult.AllowFiltering = True
		Me.C1FGridResult.ColumnInfo = resources.GetString("C1FGridResult.ColumnInfo")
		Me.C1FGridResult.Dock = System.Windows.Forms.DockStyle.Fill
		Me.C1FGridResult.ExtendLastCol = True
		Me.C1FGridResult.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid
		Me.C1FGridResult.Font = New System.Drawing.Font("Meiryo UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.C1FGridResult.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcrossOut
		Me.C1FGridResult.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcrossOut
		Me.C1FGridResult.Location = New System.Drawing.Point(3, 20)
		Me.C1FGridResult.Name = "C1FGridResult"
		Me.C1FGridResult.Rows.Count = 1
		Me.C1FGridResult.Rows.DefaultSize = 20
		Me.C1FGridResult.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
		Me.C1FGridResult.Size = New System.Drawing.Size(763, 651)
		Me.C1FGridResult.TabIndex = 1
		Me.C1FGridResult.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.System
		'
		'Button3
		'
		Me.Button3.Location = New System.Drawing.Point(674, 6)
		Me.Button3.Name = "Button3"
		Me.Button3.Size = New System.Drawing.Size(80, 26)
		Me.Button3.TabIndex = 12
		Me.Button3.Text = "ロット設定"
		Me.Button3.UseVisualStyleBackColor = True
		'
		'frmProjectDetail
		'
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
		Me.ClientSize = New System.Drawing.Size(1264, 911)
		Me.Controls.Add(Me.GroupBox5)
		Me.Controls.Add(Me.GroupBox2)
		Me.Controls.Add(Me.GroupBox1)
		Me.Controls.Add(Me.Panel2)
		Me.Controls.Add(Me.Panel1)
		Me.KeyPreview = True
		Me.Name = "frmProjectDetail"
		Me.Text = "frmProjectDetail"
		Me.UserName = Nothing
		Me.Controls.SetChildIndex(Me.Panel1, 0)
		Me.Controls.SetChildIndex(Me.Panel2, 0)
		Me.Controls.SetChildIndex(Me.GroupBox1, 0)
		Me.Controls.SetChildIndex(Me.GroupBox2, 0)
		Me.Controls.SetChildIndex(Me.GroupBox5, 0)
		Me.Panel1.ResumeLayout(False)
		Me.Panel2.ResumeLayout(False)
		Me.GroupBox1.ResumeLayout(False)
		Me.GroupBox1.PerformLayout()
		Me.GroupBox2.ResumeLayout(False)
		Me.GroupBox2.PerformLayout()
		CType(Me.C1FGridProcessList, System.ComponentModel.ISupportInitialize).EndInit()
		Me.GroupBox3.ResumeLayout(False)
		Me.GroupBox4.ResumeLayout(False)
		CType(Me.C1FGridAdoption, System.ComponentModel.ISupportInitialize).EndInit()
		Me.GroupBox5.ResumeLayout(False)
		Me.Panel3.ResumeLayout(False)
		CType(Me.C1FGridResult, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	Friend WithEvents Panel1 As Panel
	Friend WithEvents Label1 As Label
	Friend WithEvents Panel2 As Panel
	Friend WithEvents btnBack As Button
	Friend WithEvents GroupBox1 As GroupBox
	Friend WithEvents Label4 As Label
	Friend WithEvents txtOrderID As TextBox
	Friend WithEvents Label7 As Label
	Friend WithEvents TextBox4 As TextBox
	Friend WithEvents Button2 As Button
	Friend WithEvents DateTimePicker1 As DateTimePicker
	Friend WithEvents Button1 As Button
	Friend WithEvents Label3 As Label
	Friend WithEvents TextBox2 As TextBox
	Friend WithEvents Label2 As Label
	Friend WithEvents GroupBox2 As GroupBox
	Friend WithEvents Label5 As Label
	Friend WithEvents GroupBox4 As GroupBox
	Friend WithEvents C1FGridAdoption As C1.Win.C1FlexGrid.C1FlexGrid
	Friend WithEvents GroupBox3 As GroupBox
	Friend WithEvents C1FGridProcessList As C1.Win.C1FlexGrid.C1FlexGrid
	Friend WithEvents GroupBox5 As GroupBox
	Friend WithEvents Panel3 As Panel
	Friend WithEvents C1FGridResult As C1.Win.C1FlexGrid.C1FlexGrid
	Friend WithEvents Button3 As Button
End Class
