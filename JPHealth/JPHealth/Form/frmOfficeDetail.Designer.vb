<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOfficeDetail
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmOfficeDetail))
		Me.GroupBox1 = New System.Windows.Forms.GroupBox()
		Me.txtLabelNumber = New System.Windows.Forms.TextBox()
		Me.Label5 = New System.Windows.Forms.Label()
		Me.btnPrint = New System.Windows.Forms.Button()
		Me.txtPrintID = New System.Windows.Forms.TextBox()
		Me.Label4 = New System.Windows.Forms.Label()
		Me.txtOffice = New System.Windows.Forms.TextBox()
		Me.txtCompany = New System.Windows.Forms.TextBox()
		Me.txtOfficeCode = New System.Windows.Forms.TextBox()
		Me.Label3 = New System.Windows.Forms.Label()
		Me.txtCompanyCode = New System.Windows.Forms.TextBox()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.txtLotID = New System.Windows.Forms.TextBox()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.Panel1 = New System.Windows.Forms.Panel()
		Me.btnSelectCheck = New System.Windows.Forms.Button()
		Me.btnAllUnSelect = New System.Windows.Forms.Button()
		Me.btnAllSelect = New System.Windows.Forms.Button()
		Me.btnClose = New System.Windows.Forms.Button()
		Me.GroupBox2 = New System.Windows.Forms.GroupBox()
		Me.C1FGridResult = New C1.Win.C1FlexGrid.C1FlexGrid()
		Me.GroupBox1.SuspendLayout()
		Me.Panel1.SuspendLayout()
		Me.GroupBox2.SuspendLayout()
		CType(Me.C1FGridResult, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'GroupBox1
		'
		Me.GroupBox1.Controls.Add(Me.txtLabelNumber)
		Me.GroupBox1.Controls.Add(Me.Label5)
		Me.GroupBox1.Controls.Add(Me.btnPrint)
		Me.GroupBox1.Controls.Add(Me.txtPrintID)
		Me.GroupBox1.Controls.Add(Me.Label4)
		Me.GroupBox1.Controls.Add(Me.txtOffice)
		Me.GroupBox1.Controls.Add(Me.txtCompany)
		Me.GroupBox1.Controls.Add(Me.txtOfficeCode)
		Me.GroupBox1.Controls.Add(Me.Label3)
		Me.GroupBox1.Controls.Add(Me.txtCompanyCode)
		Me.GroupBox1.Controls.Add(Me.Label2)
		Me.GroupBox1.Controls.Add(Me.txtLotID)
		Me.GroupBox1.Controls.Add(Me.Label1)
		Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
		Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
		Me.GroupBox1.Name = "GroupBox1"
		Me.GroupBox1.Size = New System.Drawing.Size(664, 121)
		Me.GroupBox1.TabIndex = 1
		Me.GroupBox1.TabStop = False
		Me.GroupBox1.Text = "事業所情報"
		'
		'txtLabelNumber
		'
		Me.txtLabelNumber.Location = New System.Drawing.Point(585, 29)
		Me.txtLabelNumber.Name = "txtLabelNumber"
		Me.txtLabelNumber.ReadOnly = True
		Me.txtLabelNumber.Size = New System.Drawing.Size(67, 24)
		Me.txtLabelNumber.TabIndex = 33
		Me.txtLabelNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		'
		'Label5
		'
		Me.Label5.Location = New System.Drawing.Point(481, 30)
		Me.Label5.Name = "Label5"
		Me.Label5.Size = New System.Drawing.Size(98, 20)
		Me.Label5.TabIndex = 32
		Me.Label5.Text = "ラベル連番："
		Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'btnPrint
		'
		Me.btnPrint.Location = New System.Drawing.Point(577, 87)
		Me.btnPrint.Name = "btnPrint"
		Me.btnPrint.Size = New System.Drawing.Size(75, 25)
		Me.btnPrint.TabIndex = 31
		Me.btnPrint.Text = "印　刷"
		Me.btnPrint.UseVisualStyleBackColor = True
		'
		'txtPrintID
		'
		Me.txtPrintID.Location = New System.Drawing.Point(408, 28)
		Me.txtPrintID.Name = "txtPrintID"
		Me.txtPrintID.ReadOnly = True
		Me.txtPrintID.Size = New System.Drawing.Size(67, 24)
		Me.txtPrintID.TabIndex = 29
		Me.txtPrintID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		'
		'Label4
		'
		Me.Label4.Location = New System.Drawing.Point(334, 29)
		Me.Label4.Name = "Label4"
		Me.Label4.Size = New System.Drawing.Size(68, 20)
		Me.Label4.TabIndex = 28
		Me.Label4.Text = "印刷ID："
		Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'txtOffice
		'
		Me.txtOffice.Location = New System.Drawing.Point(156, 88)
		Me.txtOffice.Name = "txtOffice"
		Me.txtOffice.ReadOnly = True
		Me.txtOffice.Size = New System.Drawing.Size(415, 24)
		Me.txtOffice.TabIndex = 27
		'
		'txtCompany
		'
		Me.txtCompany.Location = New System.Drawing.Point(156, 58)
		Me.txtCompany.Name = "txtCompany"
		Me.txtCompany.ReadOnly = True
		Me.txtCompany.Size = New System.Drawing.Size(415, 24)
		Me.txtCompany.TabIndex = 26
		'
		'txtOfficeCode
		'
		Me.txtOfficeCode.Location = New System.Drawing.Point(83, 88)
		Me.txtOfficeCode.Name = "txtOfficeCode"
		Me.txtOfficeCode.ReadOnly = True
		Me.txtOfficeCode.Size = New System.Drawing.Size(67, 24)
		Me.txtOfficeCode.TabIndex = 25
		'
		'Label3
		'
		Me.Label3.Location = New System.Drawing.Point(12, 89)
		Me.Label3.Name = "Label3"
		Me.Label3.Size = New System.Drawing.Size(65, 20)
		Me.Label3.TabIndex = 24
		Me.Label3.Text = "局所："
		Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'txtCompanyCode
		'
		Me.txtCompanyCode.Location = New System.Drawing.Point(83, 58)
		Me.txtCompanyCode.Name = "txtCompanyCode"
		Me.txtCompanyCode.ReadOnly = True
		Me.txtCompanyCode.Size = New System.Drawing.Size(67, 24)
		Me.txtCompanyCode.TabIndex = 23
		'
		'Label2
		'
		Me.Label2.Location = New System.Drawing.Point(12, 59)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(65, 20)
		Me.Label2.TabIndex = 22
		Me.Label2.Text = "会社："
		Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'txtLotID
		'
		Me.txtLotID.Location = New System.Drawing.Point(83, 28)
		Me.txtLotID.Name = "txtLotID"
		Me.txtLotID.ReadOnly = True
		Me.txtLotID.Size = New System.Drawing.Size(180, 24)
		Me.txtLotID.TabIndex = 21
		'
		'Label1
		'
		Me.Label1.Location = New System.Drawing.Point(12, 29)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(65, 20)
		Me.Label1.TabIndex = 20
		Me.Label1.Text = "ロットID："
		Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'Panel1
		'
		Me.Panel1.Controls.Add(Me.btnSelectCheck)
		Me.Panel1.Controls.Add(Me.btnAllUnSelect)
		Me.Panel1.Controls.Add(Me.btnAllSelect)
		Me.Panel1.Controls.Add(Me.btnClose)
		Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
		Me.Panel1.Location = New System.Drawing.Point(0, 556)
		Me.Panel1.Name = "Panel1"
		Me.Panel1.Size = New System.Drawing.Size(664, 33)
		Me.Panel1.TabIndex = 2
		'
		'btnSelectCheck
		'
		Me.btnSelectCheck.Location = New System.Drawing.Point(165, 5)
		Me.btnSelectCheck.Name = "btnSelectCheck"
		Me.btnSelectCheck.Size = New System.Drawing.Size(80, 25)
		Me.btnSelectCheck.TabIndex = 53
		Me.btnSelectCheck.Text = "選択チェック"
		Me.btnSelectCheck.UseVisualStyleBackColor = True
		'
		'btnAllUnSelect
		'
		Me.btnAllUnSelect.Location = New System.Drawing.Point(84, 5)
		Me.btnAllUnSelect.Name = "btnAllUnSelect"
		Me.btnAllUnSelect.Size = New System.Drawing.Size(75, 25)
		Me.btnAllUnSelect.TabIndex = 52
		Me.btnAllUnSelect.Text = "全解除"
		Me.btnAllUnSelect.UseVisualStyleBackColor = True
		'
		'btnAllSelect
		'
		Me.btnAllSelect.Location = New System.Drawing.Point(3, 5)
		Me.btnAllSelect.Name = "btnAllSelect"
		Me.btnAllSelect.Size = New System.Drawing.Size(75, 25)
		Me.btnAllSelect.TabIndex = 51
		Me.btnAllSelect.Text = "全チェック"
		Me.btnAllSelect.UseVisualStyleBackColor = True
		'
		'btnClose
		'
		Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.btnClose.Location = New System.Drawing.Point(586, 5)
		Me.btnClose.Name = "btnClose"
		Me.btnClose.Size = New System.Drawing.Size(75, 25)
		Me.btnClose.TabIndex = 30
		Me.btnClose.Text = "閉じる"
		Me.btnClose.UseVisualStyleBackColor = True
		'
		'GroupBox2
		'
		Me.GroupBox2.Controls.Add(Me.C1FGridResult)
		Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
		Me.GroupBox2.Location = New System.Drawing.Point(0, 121)
		Me.GroupBox2.Name = "GroupBox2"
		Me.GroupBox2.Size = New System.Drawing.Size(664, 435)
		Me.GroupBox2.TabIndex = 3
		Me.GroupBox2.TabStop = False
		Me.GroupBox2.Text = "帳票情報"
		'
		'C1FGridResult
		'
		Me.C1FGridResult.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
		Me.C1FGridResult.AllowFiltering = True
		Me.C1FGridResult.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
		Me.C1FGridResult.AutoClipboard = True
		Me.C1FGridResult.ColumnInfo = resources.GetString("C1FGridResult.ColumnInfo")
		Me.C1FGridResult.Dock = System.Windows.Forms.DockStyle.Fill
		Me.C1FGridResult.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid
		Me.C1FGridResult.Font = New System.Drawing.Font("Meiryo UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.C1FGridResult.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcrossOut
		Me.C1FGridResult.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcrossOut
		Me.C1FGridResult.Location = New System.Drawing.Point(3, 20)
		Me.C1FGridResult.Name = "C1FGridResult"
		Me.C1FGridResult.Rows.Count = 1
		Me.C1FGridResult.Rows.DefaultSize = 20
		Me.C1FGridResult.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.ListBox
		Me.C1FGridResult.ShowCellLabels = True
		Me.C1FGridResult.Size = New System.Drawing.Size(658, 412)
		Me.C1FGridResult.TabIndex = 4
		Me.C1FGridResult.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.System
		'
		'frmOfficeDetail
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 17.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.CaptionDisplayMode = JPHealth.frmTempForm.StatusDisplayMode.ShowAll
		Me.ClientSize = New System.Drawing.Size(664, 611)
		Me.Controls.Add(Me.GroupBox2)
		Me.Controls.Add(Me.Panel1)
		Me.Controls.Add(Me.GroupBox1)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.KeyPreview = True
		Me.MaximizeBox = False
		Me.Name = "frmOfficeDetail"
		Me.ShowInTaskbar = False
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "frmOfficeDetail"
		Me.Controls.SetChildIndex(Me.GroupBox1, 0)
		Me.Controls.SetChildIndex(Me.Panel1, 0)
		Me.Controls.SetChildIndex(Me.GroupBox2, 0)
		Me.GroupBox1.ResumeLayout(False)
		Me.GroupBox1.PerformLayout()
		Me.Panel1.ResumeLayout(False)
		Me.GroupBox2.ResumeLayout(False)
		CType(Me.C1FGridResult, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	Friend WithEvents GroupBox1 As GroupBox
	Friend WithEvents Panel1 As Panel
	Friend WithEvents btnSelectCheck As Button
	Friend WithEvents btnAllUnSelect As Button
	Friend WithEvents btnAllSelect As Button
	Friend WithEvents btnClose As Button
	Friend WithEvents GroupBox2 As GroupBox
	Friend WithEvents txtLotID As TextBox
	Friend WithEvents Label1 As Label
	Friend WithEvents txtPrintID As TextBox
	Friend WithEvents Label4 As Label
	Friend WithEvents txtOffice As TextBox
	Friend WithEvents txtCompany As TextBox
	Friend WithEvents txtOfficeCode As TextBox
	Friend WithEvents Label3 As Label
	Friend WithEvents txtCompanyCode As TextBox
	Friend WithEvents Label2 As Label
	Friend WithEvents C1FGridResult As C1.Win.C1FlexGrid.C1FlexGrid
	Friend WithEvents btnPrint As Button
	Friend WithEvents txtLabelNumber As TextBox
	Friend WithEvents Label5 As Label
End Class
