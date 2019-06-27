<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmVariousOutput
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmVariousOutput))
		Me.Panel1 = New System.Windows.Forms.Panel()
		Me.btnClose = New System.Windows.Forms.Button()
		Me.GroupBox1 = New System.Windows.Forms.GroupBox()
		Me.txtLeafletCount = New System.Windows.Forms.TextBox()
		Me.txtCheckupCount = New System.Windows.Forms.TextBox()
		Me.Label3 = New System.Windows.Forms.Label()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.cmbLotID = New System.Windows.Forms.ComboBox()
		Me.C1FGridNumber = New C1.Win.C1FlexGrid.C1FlexGrid()
		Me.GroupBox2 = New System.Windows.Forms.GroupBox()
		Me.GroupBox3 = New System.Windows.Forms.GroupBox()
		Me.C1FGridOffice = New C1.Win.C1FlexGrid.C1FlexGrid()
		Me.GroupBox4 = New System.Windows.Forms.GroupBox()
		Me.btnPostponement = New System.Windows.Forms.Button()
		Me.btnTarget = New System.Windows.Forms.Button()
		Me.btnOffice = New System.Windows.Forms.Button()
		Me.btnCheck = New System.Windows.Forms.Button()
		Me.btnInadequacy = New System.Windows.Forms.Button()
		Me.btnPDFPathBrowse = New System.Windows.Forms.Button()
		Me.txtOutputFolder = New System.Windows.Forms.TextBox()
		Me.Label15 = New System.Windows.Forms.Label()
		Me.Panel1.SuspendLayout()
		Me.GroupBox1.SuspendLayout()
		CType(Me.C1FGridNumber, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.GroupBox2.SuspendLayout()
		Me.GroupBox3.SuspendLayout()
		CType(Me.C1FGridOffice, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.GroupBox4.SuspendLayout()
		Me.SuspendLayout()
		'
		'Panel1
		'
		Me.Panel1.Controls.Add(Me.btnClose)
		Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
		Me.Panel1.Location = New System.Drawing.Point(0, 673)
		Me.Panel1.Name = "Panel1"
		Me.Panel1.Size = New System.Drawing.Size(1008, 33)
		Me.Panel1.TabIndex = 2
		'
		'btnClose
		'
		Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.btnClose.Location = New System.Drawing.Point(930, 5)
		Me.btnClose.Name = "btnClose"
		Me.btnClose.Size = New System.Drawing.Size(75, 25)
		Me.btnClose.TabIndex = 30
		Me.btnClose.Text = "閉じる"
		Me.btnClose.UseVisualStyleBackColor = True
		'
		'GroupBox1
		'
		Me.GroupBox1.Controls.Add(Me.txtLeafletCount)
		Me.GroupBox1.Controls.Add(Me.txtCheckupCount)
		Me.GroupBox1.Controls.Add(Me.Label3)
		Me.GroupBox1.Controls.Add(Me.Label2)
		Me.GroupBox1.Controls.Add(Me.Label1)
		Me.GroupBox1.Controls.Add(Me.cmbLotID)
		Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
		Me.GroupBox1.Name = "GroupBox1"
		Me.GroupBox1.Size = New System.Drawing.Size(984, 68)
		Me.GroupBox1.TabIndex = 3
		Me.GroupBox1.TabStop = False
		Me.GroupBox1.Text = "ロット情報"
		'
		'txtLeafletCount
		'
		Me.txtLeafletCount.Location = New System.Drawing.Point(605, 23)
		Me.txtLeafletCount.Name = "txtLeafletCount"
		Me.txtLeafletCount.Size = New System.Drawing.Size(100, 24)
		Me.txtLeafletCount.TabIndex = 5
		'
		'txtCheckupCount
		'
		Me.txtCheckupCount.Location = New System.Drawing.Point(398, 24)
		Me.txtCheckupCount.Name = "txtCheckupCount"
		Me.txtCheckupCount.Size = New System.Drawing.Size(100, 24)
		Me.txtCheckupCount.TabIndex = 4
		'
		'Label3
		'
		Me.Label3.Location = New System.Drawing.Point(504, 24)
		Me.Label3.Name = "Label3"
		Me.Label3.Size = New System.Drawing.Size(95, 24)
		Me.Label3.TabIndex = 3
		Me.Label3.Text = "リーフレット："
		Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'Label2
		'
		Me.Label2.Location = New System.Drawing.Point(297, 24)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(95, 24)
		Me.Label2.TabIndex = 2
		Me.Label2.Text = "判定票："
		Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'Label1
		'
		Me.Label1.Location = New System.Drawing.Point(10, 22)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(100, 24)
		Me.Label1.TabIndex = 1
		Me.Label1.Text = "インポート日時："
		Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'cmbLotID
		'
		Me.cmbLotID.FormattingEnabled = True
		Me.cmbLotID.Location = New System.Drawing.Point(116, 23)
		Me.cmbLotID.Name = "cmbLotID"
		Me.cmbLotID.Size = New System.Drawing.Size(175, 25)
		Me.cmbLotID.TabIndex = 0
		'
		'C1FGridNumber
		'
		Me.C1FGridNumber.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
		Me.C1FGridNumber.AllowEditing = False
		Me.C1FGridNumber.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
		Me.C1FGridNumber.AutoClipboard = True
		Me.C1FGridNumber.ColumnInfo = resources.GetString("C1FGridNumber.ColumnInfo")
		Me.C1FGridNumber.Dock = System.Windows.Forms.DockStyle.Fill
		Me.C1FGridNumber.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid
		Me.C1FGridNumber.Font = New System.Drawing.Font("Meiryo UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.C1FGridNumber.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcrossOut
		Me.C1FGridNumber.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcrossOut
		Me.C1FGridNumber.Location = New System.Drawing.Point(3, 20)
		Me.C1FGridNumber.Name = "C1FGridNumber"
		Me.C1FGridNumber.Rows.Count = 1
		Me.C1FGridNumber.Rows.DefaultSize = 20
		Me.C1FGridNumber.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.CellRange
		Me.C1FGridNumber.ShowCellLabels = True
		Me.C1FGridNumber.Size = New System.Drawing.Size(978, 146)
		Me.C1FGridNumber.TabIndex = 3
		Me.C1FGridNumber.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.System
		'
		'GroupBox2
		'
		Me.GroupBox2.Controls.Add(Me.C1FGridNumber)
		Me.GroupBox2.Location = New System.Drawing.Point(12, 86)
		Me.GroupBox2.Name = "GroupBox2"
		Me.GroupBox2.Size = New System.Drawing.Size(984, 169)
		Me.GroupBox2.TabIndex = 4
		Me.GroupBox2.TabStop = False
		Me.GroupBox2.Text = "発送通数情報"
		'
		'GroupBox3
		'
		Me.GroupBox3.Controls.Add(Me.C1FGridOffice)
		Me.GroupBox3.Location = New System.Drawing.Point(12, 261)
		Me.GroupBox3.Name = "GroupBox3"
		Me.GroupBox3.Size = New System.Drawing.Size(984, 325)
		Me.GroupBox3.TabIndex = 5
		Me.GroupBox3.TabStop = False
		Me.GroupBox3.Text = "発送先事業所一覧情報"
		'
		'C1FGridOffice
		'
		Me.C1FGridOffice.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
		Me.C1FGridOffice.AllowEditing = False
		Me.C1FGridOffice.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
		Me.C1FGridOffice.AutoClipboard = True
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
		Me.C1FGridOffice.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.CellRange
		Me.C1FGridOffice.ShowCellLabels = True
		Me.C1FGridOffice.Size = New System.Drawing.Size(978, 302)
		Me.C1FGridOffice.TabIndex = 3
		Me.C1FGridOffice.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.System
		'
		'GroupBox4
		'
		Me.GroupBox4.Controls.Add(Me.btnPostponement)
		Me.GroupBox4.Controls.Add(Me.btnTarget)
		Me.GroupBox4.Controls.Add(Me.btnOffice)
		Me.GroupBox4.Controls.Add(Me.btnCheck)
		Me.GroupBox4.Controls.Add(Me.btnInadequacy)
		Me.GroupBox4.Controls.Add(Me.btnPDFPathBrowse)
		Me.GroupBox4.Controls.Add(Me.txtOutputFolder)
		Me.GroupBox4.Controls.Add(Me.Label15)
		Me.GroupBox4.Location = New System.Drawing.Point(12, 592)
		Me.GroupBox4.Name = "GroupBox4"
		Me.GroupBox4.Size = New System.Drawing.Size(806, 98)
		Me.GroupBox4.TabIndex = 6
		Me.GroupBox4.TabStop = False
		Me.GroupBox4.Text = "出力設定"
		'
		'btnPostponement
		'
		Me.btnPostponement.Location = New System.Drawing.Point(509, 53)
		Me.btnPostponement.Name = "btnPostponement"
		Me.btnPostponement.Size = New System.Drawing.Size(75, 25)
		Me.btnPostponement.TabIndex = 52
		Me.btnPostponement.Text = "後納票"
		Me.btnPostponement.UseVisualStyleBackColor = True
		'
		'btnTarget
		'
		Me.btnTarget.Location = New System.Drawing.Point(403, 53)
		Me.btnTarget.Name = "btnTarget"
		Me.btnTarget.Size = New System.Drawing.Size(100, 25)
		Me.btnTarget.TabIndex = 51
		Me.btnTarget.Text = "対象者一覧"
		Me.btnTarget.UseVisualStyleBackColor = True
		'
		'btnOffice
		'
		Me.btnOffice.Location = New System.Drawing.Point(297, 53)
		Me.btnOffice.Name = "btnOffice"
		Me.btnOffice.Size = New System.Drawing.Size(100, 25)
		Me.btnOffice.TabIndex = 50
		Me.btnOffice.Text = "事業所一覧"
		Me.btnOffice.UseVisualStyleBackColor = True
		'
		'btnCheck
		'
		Me.btnCheck.Location = New System.Drawing.Point(216, 53)
		Me.btnCheck.Name = "btnCheck"
		Me.btnCheck.Size = New System.Drawing.Size(75, 25)
		Me.btnCheck.TabIndex = 49
		Me.btnCheck.Text = "チェック表"
		Me.btnCheck.UseVisualStyleBackColor = True
		'
		'btnInadequacy
		'
		Me.btnInadequacy.Location = New System.Drawing.Point(135, 53)
		Me.btnInadequacy.Name = "btnInadequacy"
		Me.btnInadequacy.Size = New System.Drawing.Size(75, 25)
		Me.btnInadequacy.TabIndex = 31
		Me.btnInadequacy.Text = "不備リスト"
		Me.btnInadequacy.UseVisualStyleBackColor = True
		'
		'btnPDFPathBrowse
		'
		Me.btnPDFPathBrowse.Location = New System.Drawing.Point(480, 21)
		Me.btnPDFPathBrowse.Name = "btnPDFPathBrowse"
		Me.btnPDFPathBrowse.Size = New System.Drawing.Size(32, 26)
		Me.btnPDFPathBrowse.TabIndex = 47
		Me.btnPDFPathBrowse.Text = "..."
		Me.btnPDFPathBrowse.UseVisualStyleBackColor = True
		'
		'txtOutputFolder
		'
		Me.txtOutputFolder.AllowDrop = True
		Me.txtOutputFolder.ImeMode = System.Windows.Forms.ImeMode.Disable
		Me.txtOutputFolder.Location = New System.Drawing.Point(135, 23)
		Me.txtOutputFolder.Name = "txtOutputFolder"
		Me.txtOutputFolder.Size = New System.Drawing.Size(339, 24)
		Me.txtOutputFolder.TabIndex = 46
		'
		'Label15
		'
		Me.Label15.Location = New System.Drawing.Point(12, 24)
		Me.Label15.Name = "Label15"
		Me.Label15.Size = New System.Drawing.Size(117, 20)
		Me.Label15.TabIndex = 48
		Me.Label15.Text = "出力フォルダ："
		Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'frmVariousOutput
		'
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
		Me.CaptionDisplayMode = JPHealth.frmTempForm.StatusDisplayMode.ShowAll
		Me.ClientSize = New System.Drawing.Size(1008, 729)
		Me.Controls.Add(Me.GroupBox4)
		Me.Controls.Add(Me.GroupBox3)
		Me.Controls.Add(Me.GroupBox2)
		Me.Controls.Add(Me.GroupBox1)
		Me.Controls.Add(Me.Panel1)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.KeyPreview = True
		Me.Name = "frmVariousOutput"
		Me.ShowInTaskbar = False
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "frmVariousOutput"
		Me.Controls.SetChildIndex(Me.Panel1, 0)
		Me.Controls.SetChildIndex(Me.GroupBox1, 0)
		Me.Controls.SetChildIndex(Me.GroupBox2, 0)
		Me.Controls.SetChildIndex(Me.GroupBox3, 0)
		Me.Controls.SetChildIndex(Me.GroupBox4, 0)
		Me.Panel1.ResumeLayout(False)
		Me.GroupBox1.ResumeLayout(False)
		Me.GroupBox1.PerformLayout()
		CType(Me.C1FGridNumber, System.ComponentModel.ISupportInitialize).EndInit()
		Me.GroupBox2.ResumeLayout(False)
		Me.GroupBox3.ResumeLayout(False)
		CType(Me.C1FGridOffice, System.ComponentModel.ISupportInitialize).EndInit()
		Me.GroupBox4.ResumeLayout(False)
		Me.GroupBox4.PerformLayout()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	Friend WithEvents Panel1 As Panel
	Friend WithEvents btnClose As Button
	Friend WithEvents GroupBox1 As GroupBox
	Friend WithEvents cmbLotID As ComboBox
	Friend WithEvents Label1 As Label
	Friend WithEvents txtLeafletCount As TextBox
	Friend WithEvents txtCheckupCount As TextBox
	Friend WithEvents Label3 As Label
	Friend WithEvents Label2 As Label
	Friend WithEvents C1FGridNumber As C1.Win.C1FlexGrid.C1FlexGrid
	Friend WithEvents GroupBox2 As GroupBox
	Friend WithEvents GroupBox3 As GroupBox
	Friend WithEvents C1FGridOffice As C1.Win.C1FlexGrid.C1FlexGrid
	Friend WithEvents GroupBox4 As GroupBox
	Friend WithEvents btnInadequacy As Button
	Friend WithEvents btnPDFPathBrowse As Button
	Friend WithEvents txtOutputFolder As TextBox
	Friend WithEvents Label15 As Label
	Friend WithEvents btnPostponement As Button
	Friend WithEvents btnTarget As Button
	Friend WithEvents btnOffice As Button
	Friend WithEvents btnCheck As Button
End Class
