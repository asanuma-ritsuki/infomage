<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMain
	Inherits System.Windows.Forms.Form

	'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
	<System.Diagnostics.DebuggerNonUserCode()>
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
	<System.Diagnostics.DebuggerStepThrough()>
	Private Sub InitializeComponent()
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
		Me.C1StatusBar1 = New C1.Win.C1Ribbon.C1StatusBar()
		Me.lblUserName = New C1.Win.C1Ribbon.RibbonLabel()
		Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
		Me.GroupBox2 = New System.Windows.Forms.GroupBox()
		Me.C1FGridLeafInfo = New C1.Win.C1FlexGrid.C1FlexGrid()
		Me.GroupBox1 = New System.Windows.Forms.GroupBox()
		Me.C1FGridWeightHeader = New C1.Win.C1FlexGrid.C1FlexGrid()
		Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
		Me.Label4 = New System.Windows.Forms.Label()
		Me.prgLeafSheets = New System.Windows.Forms.ProgressBar()
		Me.lblLeafSheets = New System.Windows.Forms.Label()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.prgLeafNumber = New System.Windows.Forms.ProgressBar()
		Me.lblLeafNumber = New System.Windows.Forms.Label()
		Me.Panel1 = New System.Windows.Forms.Panel()
		Me.btnEnd = New System.Windows.Forms.Button()
		Me.btnStart = New System.Windows.Forms.Button()
		Me.cmbLotID = New System.Windows.Forms.ComboBox()
		Me.GroupBox4 = New System.Windows.Forms.GroupBox()
		Me.C1FGridLeafDetail = New C1.Win.C1FlexGrid.C1FlexGrid()
		Me.GroupBox3 = New System.Windows.Forms.GroupBox()
		Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
		Me.lblEmployee = New System.Windows.Forms.Label()
		Me.prgEmployee = New System.Windows.Forms.ProgressBar()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.txtScan = New System.Windows.Forms.TextBox()
		CType(Me.C1StatusBar1, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SplitContainer1.Panel1.SuspendLayout()
		Me.SplitContainer1.Panel2.SuspendLayout()
		Me.SplitContainer1.SuspendLayout()
		Me.GroupBox2.SuspendLayout()
		CType(Me.C1FGridLeafInfo, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.GroupBox1.SuspendLayout()
		CType(Me.C1FGridWeightHeader, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.TableLayoutPanel1.SuspendLayout()
		Me.Panel1.SuspendLayout()
		Me.GroupBox4.SuspendLayout()
		CType(Me.C1FGridLeafDetail, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.GroupBox3.SuspendLayout()
		Me.TableLayoutPanel2.SuspendLayout()
		Me.SuspendLayout()
		'
		'C1StatusBar1
		'
		Me.C1StatusBar1.AutoSizeElement = C1.Framework.AutoSizeElement.Width
		Me.C1StatusBar1.Location = New System.Drawing.Point(0, 639)
		Me.C1StatusBar1.Name = "C1StatusBar1"
		Me.C1StatusBar1.RightPaneItems.Add(Me.lblUserName)
		Me.C1StatusBar1.Size = New System.Drawing.Size(884, 22)
		Me.C1StatusBar1.VisualStyle = C1.Win.C1Ribbon.VisualStyle.Office2010Silver
		'
		'lblUserName
		'
		Me.lblUserName.Name = "lblUserName"
		Me.lblUserName.Text = "作業者"
		'
		'SplitContainer1
		'
		Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
		Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
		Me.SplitContainer1.Name = "SplitContainer1"
		'
		'SplitContainer1.Panel1
		'
		Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox2)
		Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox1)
		'
		'SplitContainer1.Panel2
		'
		Me.SplitContainer1.Panel2.Controls.Add(Me.GroupBox4)
		Me.SplitContainer1.Panel2.Controls.Add(Me.GroupBox3)
		Me.SplitContainer1.Size = New System.Drawing.Size(884, 639)
		Me.SplitContainer1.SplitterDistance = 451
		Me.SplitContainer1.TabIndex = 1
		'
		'GroupBox2
		'
		Me.GroupBox2.Controls.Add(Me.C1FGridLeafInfo)
		Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
		Me.GroupBox2.Location = New System.Drawing.Point(0, 327)
		Me.GroupBox2.Name = "GroupBox2"
		Me.GroupBox2.Size = New System.Drawing.Size(451, 312)
		Me.GroupBox2.TabIndex = 1
		Me.GroupBox2.TabStop = False
		Me.GroupBox2.Text = "ロット内先頭リーフレット情報"
		'
		'C1FGridLeafInfo
		'
		Me.C1FGridLeafInfo.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
		Me.C1FGridLeafInfo.AllowEditing = False
		Me.C1FGridLeafInfo.AutoClipboard = True
		Me.C1FGridLeafInfo.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
		Me.C1FGridLeafInfo.ColumnInfo = resources.GetString("C1FGridLeafInfo.ColumnInfo")
		Me.C1FGridLeafInfo.Dock = System.Windows.Forms.DockStyle.Fill
		Me.C1FGridLeafInfo.Font = New System.Drawing.Font("Meiryo UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.C1FGridLeafInfo.Location = New System.Drawing.Point(3, 20)
		Me.C1FGridLeafInfo.Name = "C1FGridLeafInfo"
		Me.C1FGridLeafInfo.Rows.DefaultSize = 20
		Me.C1FGridLeafInfo.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
		Me.C1FGridLeafInfo.Size = New System.Drawing.Size(445, 289)
		Me.C1FGridLeafInfo.TabIndex = 3
		Me.C1FGridLeafInfo.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.System
		'
		'GroupBox1
		'
		Me.GroupBox1.Controls.Add(Me.C1FGridWeightHeader)
		Me.GroupBox1.Controls.Add(Me.TableLayoutPanel1)
		Me.GroupBox1.Controls.Add(Me.Panel1)
		Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
		Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
		Me.GroupBox1.Name = "GroupBox1"
		Me.GroupBox1.Size = New System.Drawing.Size(451, 327)
		Me.GroupBox1.TabIndex = 0
		Me.GroupBox1.TabStop = False
		Me.GroupBox1.Text = "ロット情報"
		'
		'C1FGridWeightHeader
		'
		Me.C1FGridWeightHeader.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
		Me.C1FGridWeightHeader.AllowEditing = False
		Me.C1FGridWeightHeader.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
		Me.C1FGridWeightHeader.ColumnInfo = resources.GetString("C1FGridWeightHeader.ColumnInfo")
		Me.C1FGridWeightHeader.Dock = System.Windows.Forms.DockStyle.Fill
		Me.C1FGridWeightHeader.Font = New System.Drawing.Font("Meiryo UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.C1FGridWeightHeader.Location = New System.Drawing.Point(3, 118)
		Me.C1FGridWeightHeader.Name = "C1FGridWeightHeader"
		Me.C1FGridWeightHeader.Rows.Count = 9
		Me.C1FGridWeightHeader.Rows.DefaultSize = 20
		Me.C1FGridWeightHeader.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
		Me.C1FGridWeightHeader.Size = New System.Drawing.Size(445, 206)
		Me.C1FGridWeightHeader.TabIndex = 2
		Me.C1FGridWeightHeader.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.System
		'
		'TableLayoutPanel1
		'
		Me.TableLayoutPanel1.ColumnCount = 3
		Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 117.0!))
		Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
		Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 102.0!))
		Me.TableLayoutPanel1.Controls.Add(Me.Label4, 0, 1)
		Me.TableLayoutPanel1.Controls.Add(Me.prgLeafSheets, 1, 1)
		Me.TableLayoutPanel1.Controls.Add(Me.lblLeafSheets, 2, 1)
		Me.TableLayoutPanel1.Controls.Add(Me.Label2, 0, 0)
		Me.TableLayoutPanel1.Controls.Add(Me.prgLeafNumber, 1, 0)
		Me.TableLayoutPanel1.Controls.Add(Me.lblLeafNumber, 2, 0)
		Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top
		Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 66)
		Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
		Me.TableLayoutPanel1.RowCount = 2
		Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
		Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
		Me.TableLayoutPanel1.Size = New System.Drawing.Size(445, 52)
		Me.TableLayoutPanel1.TabIndex = 1
		'
		'Label4
		'
		Me.Label4.AutoSize = True
		Me.Label4.Dock = System.Windows.Forms.DockStyle.Fill
		Me.Label4.Location = New System.Drawing.Point(3, 26)
		Me.Label4.Name = "Label4"
		Me.Label4.Size = New System.Drawing.Size(111, 26)
		Me.Label4.TabIndex = 4
		Me.Label4.Text = "リーフレット枚数："
		Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'prgLeafSheets
		'
		Me.prgLeafSheets.Dock = System.Windows.Forms.DockStyle.Fill
		Me.prgLeafSheets.Location = New System.Drawing.Point(120, 29)
		Me.prgLeafSheets.Name = "prgLeafSheets"
		Me.prgLeafSheets.Size = New System.Drawing.Size(220, 20)
		Me.prgLeafSheets.TabIndex = 5
		'
		'lblLeafSheets
		'
		Me.lblLeafSheets.AutoSize = True
		Me.lblLeafSheets.Dock = System.Windows.Forms.DockStyle.Fill
		Me.lblLeafSheets.Location = New System.Drawing.Point(346, 26)
		Me.lblLeafSheets.Name = "lblLeafSheets"
		Me.lblLeafSheets.Size = New System.Drawing.Size(96, 26)
		Me.lblLeafSheets.TabIndex = 6
		Me.lblLeafSheets.Text = "9999 / 9999"
		Me.lblLeafSheets.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'Label2
		'
		Me.Label2.AutoSize = True
		Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
		Me.Label2.Location = New System.Drawing.Point(3, 0)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(111, 26)
		Me.Label2.TabIndex = 0
		Me.Label2.Text = "リーフレット件数："
		Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'prgLeafNumber
		'
		Me.prgLeafNumber.Dock = System.Windows.Forms.DockStyle.Fill
		Me.prgLeafNumber.Location = New System.Drawing.Point(120, 3)
		Me.prgLeafNumber.Name = "prgLeafNumber"
		Me.prgLeafNumber.Size = New System.Drawing.Size(220, 20)
		Me.prgLeafNumber.TabIndex = 2
		'
		'lblLeafNumber
		'
		Me.lblLeafNumber.AutoSize = True
		Me.lblLeafNumber.Dock = System.Windows.Forms.DockStyle.Fill
		Me.lblLeafNumber.Location = New System.Drawing.Point(346, 0)
		Me.lblLeafNumber.Name = "lblLeafNumber"
		Me.lblLeafNumber.Size = New System.Drawing.Size(96, 26)
		Me.lblLeafNumber.TabIndex = 3
		Me.lblLeafNumber.Text = "9999 / 9999"
		Me.lblLeafNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'Panel1
		'
		Me.Panel1.Controls.Add(Me.btnEnd)
		Me.Panel1.Controls.Add(Me.btnStart)
		Me.Panel1.Controls.Add(Me.cmbLotID)
		Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
		Me.Panel1.Location = New System.Drawing.Point(3, 20)
		Me.Panel1.Name = "Panel1"
		Me.Panel1.Size = New System.Drawing.Size(445, 46)
		Me.Panel1.TabIndex = 0
		'
		'btnEnd
		'
		Me.btnEnd.Location = New System.Drawing.Point(316, 10)
		Me.btnEnd.Name = "btnEnd"
		Me.btnEnd.Size = New System.Drawing.Size(75, 25)
		Me.btnEnd.TabIndex = 2
		Me.btnEnd.Text = "終　了"
		Me.btnEnd.UseVisualStyleBackColor = True
		'
		'btnStart
		'
		Me.btnStart.Location = New System.Drawing.Point(235, 10)
		Me.btnStart.Name = "btnStart"
		Me.btnStart.Size = New System.Drawing.Size(75, 25)
		Me.btnStart.TabIndex = 1
		Me.btnStart.Text = "開　始"
		Me.btnStart.UseVisualStyleBackColor = True
		'
		'cmbLotID
		'
		Me.cmbLotID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cmbLotID.FormattingEnabled = True
		Me.cmbLotID.Location = New System.Drawing.Point(9, 10)
		Me.cmbLotID.Name = "cmbLotID"
		Me.cmbLotID.Size = New System.Drawing.Size(220, 25)
		Me.cmbLotID.TabIndex = 0
		'
		'GroupBox4
		'
		Me.GroupBox4.Controls.Add(Me.C1FGridLeafDetail)
		Me.GroupBox4.Dock = System.Windows.Forms.DockStyle.Fill
		Me.GroupBox4.Location = New System.Drawing.Point(0, 89)
		Me.GroupBox4.Name = "GroupBox4"
		Me.GroupBox4.Size = New System.Drawing.Size(429, 550)
		Me.GroupBox4.TabIndex = 1
		Me.GroupBox4.TabStop = False
		Me.GroupBox4.Text = "社員のリーフレット詳細"
		'
		'C1FGridLeafDetail
		'
		Me.C1FGridLeafDetail.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
		Me.C1FGridLeafDetail.AllowEditing = False
		Me.C1FGridLeafDetail.AutoClipboard = True
		Me.C1FGridLeafDetail.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
		Me.C1FGridLeafDetail.ColumnInfo = resources.GetString("C1FGridLeafDetail.ColumnInfo")
		Me.C1FGridLeafDetail.Dock = System.Windows.Forms.DockStyle.Fill
		Me.C1FGridLeafDetail.Font = New System.Drawing.Font("Meiryo UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.C1FGridLeafDetail.Location = New System.Drawing.Point(3, 20)
		Me.C1FGridLeafDetail.Name = "C1FGridLeafDetail"
		Me.C1FGridLeafDetail.Rows.DefaultSize = 20
		Me.C1FGridLeafDetail.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
		Me.C1FGridLeafDetail.Size = New System.Drawing.Size(423, 527)
		Me.C1FGridLeafDetail.TabIndex = 3
		Me.C1FGridLeafDetail.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.System
		'
		'GroupBox3
		'
		Me.GroupBox3.Controls.Add(Me.TableLayoutPanel2)
		Me.GroupBox3.Controls.Add(Me.txtScan)
		Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Top
		Me.GroupBox3.Location = New System.Drawing.Point(0, 0)
		Me.GroupBox3.Name = "GroupBox3"
		Me.GroupBox3.Size = New System.Drawing.Size(429, 89)
		Me.GroupBox3.TabIndex = 0
		Me.GroupBox3.TabStop = False
		Me.GroupBox3.Text = "QR読取り"
		'
		'TableLayoutPanel2
		'
		Me.TableLayoutPanel2.ColumnCount = 3
		Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
		Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 155.0!))
		Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 103.0!))
		Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
		Me.TableLayoutPanel2.Controls.Add(Me.lblEmployee, 2, 0)
		Me.TableLayoutPanel2.Controls.Add(Me.prgEmployee, 1, 0)
		Me.TableLayoutPanel2.Controls.Add(Me.Label1, 0, 0)
		Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
		Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 58)
		Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
		Me.TableLayoutPanel2.RowCount = 1
		Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
		Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
		Me.TableLayoutPanel2.Size = New System.Drawing.Size(423, 28)
		Me.TableLayoutPanel2.TabIndex = 1
		'
		'lblEmployee
		'
		Me.lblEmployee.AutoSize = True
		Me.lblEmployee.Dock = System.Windows.Forms.DockStyle.Fill
		Me.lblEmployee.Location = New System.Drawing.Point(323, 0)
		Me.lblEmployee.Name = "lblEmployee"
		Me.lblEmployee.Size = New System.Drawing.Size(97, 28)
		Me.lblEmployee.TabIndex = 4
		Me.lblEmployee.Text = "9999 / 9999"
		Me.lblEmployee.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'prgEmployee
		'
		Me.prgEmployee.Dock = System.Windows.Forms.DockStyle.Fill
		Me.prgEmployee.Location = New System.Drawing.Point(168, 3)
		Me.prgEmployee.Name = "prgEmployee"
		Me.prgEmployee.Size = New System.Drawing.Size(149, 22)
		Me.prgEmployee.TabIndex = 2
		'
		'Label1
		'
		Me.Label1.AutoSize = True
		Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
		Me.Label1.Location = New System.Drawing.Point(3, 0)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(159, 28)
		Me.Label1.TabIndex = 1
		Me.Label1.Text = "社員単位の進捗："
		Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'txtScan
		'
		Me.txtScan.BackColor = System.Drawing.Color.MistyRose
		Me.txtScan.Dock = System.Windows.Forms.DockStyle.Top
		Me.txtScan.Font = New System.Drawing.Font("Meiryo UI", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.txtScan.Location = New System.Drawing.Point(3, 20)
		Me.txtScan.Name = "txtScan"
		Me.txtScan.Size = New System.Drawing.Size(423, 38)
		Me.txtScan.TabIndex = 0
		Me.txtScan.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
		'
		'frmMain
		'
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
		Me.ClientSize = New System.Drawing.Size(884, 661)
		Me.Controls.Add(Me.SplitContainer1)
		Me.Controls.Add(Me.C1StatusBar1)
		Me.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
		Me.MinimumSize = New System.Drawing.Size(900, 700)
		Me.Name = "frmMain"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "frmMain"
		CType(Me.C1StatusBar1, System.ComponentModel.ISupportInitialize).EndInit()
		Me.SplitContainer1.Panel1.ResumeLayout(False)
		Me.SplitContainer1.Panel2.ResumeLayout(False)
		CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
		Me.SplitContainer1.ResumeLayout(False)
		Me.GroupBox2.ResumeLayout(False)
		CType(Me.C1FGridLeafInfo, System.ComponentModel.ISupportInitialize).EndInit()
		Me.GroupBox1.ResumeLayout(False)
		CType(Me.C1FGridWeightHeader, System.ComponentModel.ISupportInitialize).EndInit()
		Me.TableLayoutPanel1.ResumeLayout(False)
		Me.TableLayoutPanel1.PerformLayout()
		Me.Panel1.ResumeLayout(False)
		Me.GroupBox4.ResumeLayout(False)
		CType(Me.C1FGridLeafDetail, System.ComponentModel.ISupportInitialize).EndInit()
		Me.GroupBox3.ResumeLayout(False)
		Me.GroupBox3.PerformLayout()
		Me.TableLayoutPanel2.ResumeLayout(False)
		Me.TableLayoutPanel2.PerformLayout()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	Friend WithEvents C1StatusBar1 As C1.Win.C1Ribbon.C1StatusBar
	Friend WithEvents lblUserName As C1.Win.C1Ribbon.RibbonLabel
	Friend WithEvents SplitContainer1 As SplitContainer
	Friend WithEvents GroupBox2 As GroupBox
	Friend WithEvents GroupBox1 As GroupBox
	Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
	Friend WithEvents Label2 As Label
	Friend WithEvents Panel1 As Panel
	Friend WithEvents Label1 As Label
	Friend WithEvents prgEmployee As ProgressBar
	Friend WithEvents GroupBox3 As GroupBox
	Friend WithEvents txtScan As TextBox
	Friend WithEvents C1FGridLeafInfo As C1.Win.C1FlexGrid.C1FlexGrid
	Friend WithEvents C1FGridWeightHeader As C1.Win.C1FlexGrid.C1FlexGrid
	Friend WithEvents Label4 As Label
	Friend WithEvents prgLeafSheets As ProgressBar
	Friend WithEvents lblLeafSheets As Label
	Friend WithEvents prgLeafNumber As ProgressBar
	Friend WithEvents lblLeafNumber As Label
	Friend WithEvents btnEnd As Button
	Friend WithEvents btnStart As Button
	Friend WithEvents cmbLotID As ComboBox
	Friend WithEvents GroupBox4 As GroupBox
	Friend WithEvents C1FGridLeafDetail As C1.Win.C1FlexGrid.C1FlexGrid
	Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
	Friend WithEvents lblEmployee As Label
End Class
