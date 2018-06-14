<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
	Inherits System.Windows.Forms.Form

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
		Me.txtTargetFolder = New System.Windows.Forms.TextBox()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.C1FGridResult = New C1.Win.C1FlexGrid.C1FlexGrid()
		Me.btnStart = New System.Windows.Forms.Button()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.txtOutFolder = New System.Windows.Forms.TextBox()
		CType(Me.C1FGridResult, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'txtTargetFolder
		'
		Me.txtTargetFolder.Location = New System.Drawing.Point(115, 12)
		Me.txtTargetFolder.Name = "txtTargetFolder"
		Me.txtTargetFolder.Size = New System.Drawing.Size(497, 24)
		Me.txtTargetFolder.TabIndex = 0
		Me.txtTargetFolder.Text = "\\hydra\01_制作Gr\04_スポット案件\20180205_180141001_日立DS_森永乳業\99_納品\最終納品データ"
		'
		'Label1
		'
		Me.Label1.Location = New System.Drawing.Point(9, 12)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(100, 24)
		Me.Label1.TabIndex = 1
		Me.Label1.Text = "対象フォルダ："
		Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'C1FGridResult
		'
		Me.C1FGridResult.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
		Me.C1FGridResult.AllowEditing = False
		Me.C1FGridResult.AllowFiltering = True
		Me.C1FGridResult.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
		Me.C1FGridResult.AutoClipboard = True
		Me.C1FGridResult.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
		Me.C1FGridResult.ColumnInfo = "1,1,0,0,0,100,Columns:0{Width:30;Name:""No"";Caption:""No."";Style:""DataType:System.I" &
	"nt32;TextAlign:GeneralCenter;"";}" & Global.Microsoft.VisualBasic.ChrW(9)
		Me.C1FGridResult.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid
		Me.C1FGridResult.Font = New System.Drawing.Font("Meiryo UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.C1FGridResult.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcrossOut
		Me.C1FGridResult.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcrossOut
		Me.C1FGridResult.Location = New System.Drawing.Point(12, 228)
		Me.C1FGridResult.Name = "C1FGridResult"
		Me.C1FGridResult.Rows.Count = 1
		Me.C1FGridResult.Rows.DefaultSize = 20
		Me.C1FGridResult.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
		Me.C1FGridResult.ShowCellLabels = True
		Me.C1FGridResult.Size = New System.Drawing.Size(600, 170)
		Me.C1FGridResult.TabIndex = 5
		Me.C1FGridResult.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.System
		'
		'btnStart
		'
		Me.btnStart.Location = New System.Drawing.Point(537, 404)
		Me.btnStart.Name = "btnStart"
		Me.btnStart.Size = New System.Drawing.Size(75, 25)
		Me.btnStart.TabIndex = 6
		Me.btnStart.Text = "開　始"
		Me.btnStart.UseVisualStyleBackColor = True
		'
		'Label2
		'
		Me.Label2.Location = New System.Drawing.Point(9, 42)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(100, 24)
		Me.Label2.TabIndex = 8
		Me.Label2.Text = "出力フォルダ："
		Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'txtOutFolder
		'
		Me.txtOutFolder.Location = New System.Drawing.Point(115, 42)
		Me.txtOutFolder.Name = "txtOutFolder"
		Me.txtOutFolder.Size = New System.Drawing.Size(497, 24)
		Me.txtOutFolder.TabIndex = 7
		Me.txtOutFolder.Text = "C:\temp\Morinaga"
		'
		'Form1
		'
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
		Me.ClientSize = New System.Drawing.Size(624, 441)
		Me.Controls.Add(Me.Label2)
		Me.Controls.Add(Me.txtOutFolder)
		Me.Controls.Add(Me.btnStart)
		Me.Controls.Add(Me.C1FGridResult)
		Me.Controls.Add(Me.Label1)
		Me.Controls.Add(Me.txtTargetFolder)
		Me.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Name = "Form1"
		Me.Text = "Form1"
		CType(Me.C1FGridResult, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	Friend WithEvents txtTargetFolder As TextBox
	Friend WithEvents Label1 As Label
	Friend WithEvents C1FGridResult As C1.Win.C1FlexGrid.C1FlexGrid
	Friend WithEvents btnStart As Button
	Friend WithEvents Label2 As Label
	Friend WithEvents txtOutFolder As TextBox
End Class
