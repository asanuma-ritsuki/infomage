<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmImport
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
		Me.Panel1 = New System.Windows.Forms.Panel()
		Me.GroupBox1 = New System.Windows.Forms.GroupBox()
		Me.C1Label5 = New C1.Win.C1Input.C1Label()
		Me.numStart = New System.Windows.Forms.NumericUpDown()
		Me.cmbOffice = New C1.Win.C1Input.C1ComboBox()
		Me.C1Label4 = New C1.Win.C1Input.C1Label()
		Me.txtImportExcel = New C1.Win.C1Input.C1TextBox()
		Me.btnImport = New C1.Win.C1Input.C1Button()
		Me.C1Label1 = New C1.Win.C1Input.C1Label()
		Me.btnLogFolderBrowse = New C1.Win.C1Input.C1Button()
		Me.C1Label2 = New C1.Win.C1Input.C1Label()
		Me.btnSaveFolderBrowse = New C1.Win.C1Input.C1Button()
		Me.C1Label3 = New C1.Win.C1Input.C1Label()
		Me.btnImportExcelBrowse = New C1.Win.C1Input.C1Button()
		Me.txtSaveFolder = New C1.Win.C1Input.C1TextBox()
		Me.txtLogFolder = New C1.Win.C1Input.C1TextBox()
		Me.lstResult = New System.Windows.Forms.ListBox()
		Me.Panel1.SuspendLayout()
		Me.GroupBox1.SuspendLayout()
		CType(Me.C1Label5, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.numStart, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.cmbOffice, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.C1Label4, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.txtImportExcel, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.btnImport, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.C1Label1, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.btnLogFolderBrowse, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.C1Label2, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.btnSaveFolderBrowse, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.C1Label3, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.btnImportExcelBrowse, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.txtSaveFolder, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.txtLogFolder, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'Panel1
		'
		Me.Panel1.Controls.Add(Me.GroupBox1)
		Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
		Me.Panel1.Location = New System.Drawing.Point(0, 0)
		Me.Panel1.Name = "Panel1"
		Me.Panel1.Size = New System.Drawing.Size(792, 148)
		Me.Panel1.TabIndex = 1
		'
		'GroupBox1
		'
		Me.GroupBox1.Controls.Add(Me.C1Label5)
		Me.GroupBox1.Controls.Add(Me.numStart)
		Me.GroupBox1.Controls.Add(Me.cmbOffice)
		Me.GroupBox1.Controls.Add(Me.C1Label4)
		Me.GroupBox1.Controls.Add(Me.txtImportExcel)
		Me.GroupBox1.Controls.Add(Me.btnImport)
		Me.GroupBox1.Controls.Add(Me.C1Label1)
		Me.GroupBox1.Controls.Add(Me.btnLogFolderBrowse)
		Me.GroupBox1.Controls.Add(Me.C1Label2)
		Me.GroupBox1.Controls.Add(Me.btnSaveFolderBrowse)
		Me.GroupBox1.Controls.Add(Me.C1Label3)
		Me.GroupBox1.Controls.Add(Me.btnImportExcelBrowse)
		Me.GroupBox1.Controls.Add(Me.txtSaveFolder)
		Me.GroupBox1.Controls.Add(Me.txtLogFolder)
		Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
		Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
		Me.GroupBox1.Name = "GroupBox1"
		Me.GroupBox1.Size = New System.Drawing.Size(792, 148)
		Me.GroupBox1.TabIndex = 11
		Me.GroupBox1.TabStop = False
		Me.GroupBox1.Text = "インポート設定"
		'
		'C1Label5
		'
		Me.C1Label5.BackColor = System.Drawing.Color.Transparent
		Me.C1Label5.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.C1Label5.ForeColor = System.Drawing.Color.Black
		Me.C1Label5.Location = New System.Drawing.Point(434, 116)
		Me.C1Label5.Name = "C1Label5"
		Me.C1Label5.Size = New System.Drawing.Size(128, 25)
		Me.C1Label5.TabIndex = 14
		Me.C1Label5.Tag = Nothing
		Me.C1Label5.Text = "行目からインポートする"
		Me.C1Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.C1Label5.TextDetached = True
		Me.C1Label5.Value = ""
		'
		'numStart
		'
		Me.numStart.Location = New System.Drawing.Point(375, 116)
		Me.numStart.Name = "numStart"
		Me.numStart.Size = New System.Drawing.Size(53, 24)
		Me.numStart.TabIndex = 13
		Me.numStart.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me.numStart.Value = New Decimal(New Integer() {2, 0, 0, 0})
		'
		'cmbOffice
		'
		Me.cmbOffice.AllowSpinLoop = False
		Me.cmbOffice.AutoSize = False
		Me.cmbOffice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.cmbOffice.Cursor = System.Windows.Forms.Cursors.Arrow
		Me.cmbOffice.DropDownStyle = C1.Win.C1Input.DropDownStyle.DropDownList
		Me.cmbOffice.GapHeight = 0
		Me.cmbOffice.ImagePadding = New System.Windows.Forms.Padding(0)
		Me.cmbOffice.ItemsDisplayMember = ""
		Me.cmbOffice.ItemsValueMember = ""
		Me.cmbOffice.Location = New System.Drawing.Point(142, 116)
		Me.cmbOffice.Name = "cmbOffice"
		Me.cmbOffice.Size = New System.Drawing.Size(200, 25)
		Me.cmbOffice.TabIndex = 12
		Me.cmbOffice.Tag = Nothing
		Me.cmbOffice.TextDetached = True
		Me.cmbOffice.TranslateValue = True
		'
		'C1Label4
		'
		Me.C1Label4.BackColor = System.Drawing.Color.Transparent
		Me.C1Label4.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.C1Label4.ForeColor = System.Drawing.Color.Black
		Me.C1Label4.Location = New System.Drawing.Point(12, 116)
		Me.C1Label4.Name = "C1Label4"
		Me.C1Label4.Size = New System.Drawing.Size(124, 25)
		Me.C1Label4.TabIndex = 11
		Me.C1Label4.Tag = Nothing
		Me.C1Label4.Text = "対象事業所："
		Me.C1Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.C1Label4.TextDetached = True
		Me.C1Label4.Value = ""
		'
		'txtImportExcel
		'
		Me.txtImportExcel.AllowDrop = True
		Me.txtImportExcel.AutoSize = False
		Me.txtImportExcel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.txtImportExcel.Location = New System.Drawing.Point(142, 23)
		Me.txtImportExcel.Name = "txtImportExcel"
		Me.txtImportExcel.Size = New System.Drawing.Size(512, 25)
		Me.txtImportExcel.TabIndex = 4
		Me.txtImportExcel.Tag = Nothing
		Me.txtImportExcel.TextDetached = True
		'
		'btnImport
		'
		Me.btnImport.Location = New System.Drawing.Point(705, 26)
		Me.btnImport.Name = "btnImport"
		Me.btnImport.Size = New System.Drawing.Size(75, 25)
		Me.btnImport.TabIndex = 10
		Me.btnImport.Text = "インポート"
		Me.btnImport.UseVisualStyleBackColor = True
		'
		'C1Label1
		'
		Me.C1Label1.BackColor = System.Drawing.Color.Transparent
		Me.C1Label1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.C1Label1.ForeColor = System.Drawing.Color.Black
		Me.C1Label1.Location = New System.Drawing.Point(12, 21)
		Me.C1Label1.Name = "C1Label1"
		Me.C1Label1.Size = New System.Drawing.Size(124, 25)
		Me.C1Label1.TabIndex = 1
		Me.C1Label1.Tag = Nothing
		Me.C1Label1.Text = "インポートエクセル："
		Me.C1Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.C1Label1.TextDetached = True
		Me.C1Label1.Value = ""
		'
		'btnLogFolderBrowse
		'
		Me.btnLogFolderBrowse.Location = New System.Drawing.Point(660, 85)
		Me.btnLogFolderBrowse.Name = "btnLogFolderBrowse"
		Me.btnLogFolderBrowse.Size = New System.Drawing.Size(30, 25)
		Me.btnLogFolderBrowse.TabIndex = 9
		Me.btnLogFolderBrowse.Text = "..."
		Me.btnLogFolderBrowse.UseVisualStyleBackColor = True
		'
		'C1Label2
		'
		Me.C1Label2.BackColor = System.Drawing.Color.Transparent
		Me.C1Label2.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.C1Label2.ForeColor = System.Drawing.Color.Black
		Me.C1Label2.Location = New System.Drawing.Point(12, 52)
		Me.C1Label2.Name = "C1Label2"
		Me.C1Label2.Size = New System.Drawing.Size(124, 25)
		Me.C1Label2.TabIndex = 2
		Me.C1Label2.Tag = Nothing
		Me.C1Label2.Text = "保存先フォルダ："
		Me.C1Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.C1Label2.TextDetached = True
		Me.C1Label2.Value = ""
		'
		'btnSaveFolderBrowse
		'
		Me.btnSaveFolderBrowse.Location = New System.Drawing.Point(660, 54)
		Me.btnSaveFolderBrowse.Name = "btnSaveFolderBrowse"
		Me.btnSaveFolderBrowse.Size = New System.Drawing.Size(30, 25)
		Me.btnSaveFolderBrowse.TabIndex = 8
		Me.btnSaveFolderBrowse.Text = "..."
		Me.btnSaveFolderBrowse.UseVisualStyleBackColor = True
		'
		'C1Label3
		'
		Me.C1Label3.BackColor = System.Drawing.Color.Transparent
		Me.C1Label3.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.C1Label3.ForeColor = System.Drawing.Color.Black
		Me.C1Label3.Location = New System.Drawing.Point(12, 83)
		Me.C1Label3.Name = "C1Label3"
		Me.C1Label3.Size = New System.Drawing.Size(124, 25)
		Me.C1Label3.TabIndex = 3
		Me.C1Label3.Tag = Nothing
		Me.C1Label3.Text = "ログ保存先フォルダ："
		Me.C1Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.C1Label3.TextDetached = True
		Me.C1Label3.Value = ""
		'
		'btnImportExcelBrowse
		'
		Me.btnImportExcelBrowse.Location = New System.Drawing.Point(660, 23)
		Me.btnImportExcelBrowse.Name = "btnImportExcelBrowse"
		Me.btnImportExcelBrowse.Size = New System.Drawing.Size(30, 25)
		Me.btnImportExcelBrowse.TabIndex = 7
		Me.btnImportExcelBrowse.Text = "..."
		Me.btnImportExcelBrowse.UseVisualStyleBackColor = True
		'
		'txtSaveFolder
		'
		Me.txtSaveFolder.AllowDrop = True
		Me.txtSaveFolder.AutoSize = False
		Me.txtSaveFolder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.txtSaveFolder.Location = New System.Drawing.Point(142, 54)
		Me.txtSaveFolder.Name = "txtSaveFolder"
		Me.txtSaveFolder.Size = New System.Drawing.Size(512, 25)
		Me.txtSaveFolder.TabIndex = 5
		Me.txtSaveFolder.Tag = Nothing
		Me.txtSaveFolder.TextDetached = True
		'
		'txtLogFolder
		'
		Me.txtLogFolder.AllowDrop = True
		Me.txtLogFolder.AutoSize = False
		Me.txtLogFolder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.txtLogFolder.Location = New System.Drawing.Point(142, 85)
		Me.txtLogFolder.Name = "txtLogFolder"
		Me.txtLogFolder.Size = New System.Drawing.Size(512, 25)
		Me.txtLogFolder.TabIndex = 6
		Me.txtLogFolder.Tag = Nothing
		Me.txtLogFolder.TextDetached = True
		'
		'lstResult
		'
		Me.lstResult.Dock = System.Windows.Forms.DockStyle.Fill
		Me.lstResult.FormattingEnabled = True
		Me.lstResult.ItemHeight = 17
		Me.lstResult.Location = New System.Drawing.Point(0, 148)
		Me.lstResult.Name = "lstResult"
		Me.lstResult.Size = New System.Drawing.Size(792, 400)
		Me.lstResult.TabIndex = 2
		'
		'frmImport
		'
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
		Me.ClientSize = New System.Drawing.Size(792, 571)
		Me.Controls.Add(Me.lstResult)
		Me.Controls.Add(Me.Panel1)
		Me.Name = "frmImport"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "frmImport"
		Me.Controls.SetChildIndex(Me.Panel1, 0)
		Me.Controls.SetChildIndex(Me.lstResult, 0)
		Me.Panel1.ResumeLayout(False)
		Me.GroupBox1.ResumeLayout(False)
		CType(Me.C1Label5, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.numStart, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.cmbOffice, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.C1Label4, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.txtImportExcel, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.btnImport, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.C1Label1, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.btnLogFolderBrowse, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.C1Label2, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.btnSaveFolderBrowse, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.C1Label3, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.btnImportExcelBrowse, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.txtSaveFolder, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.txtLogFolder, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	Friend WithEvents Panel1 As Panel
	Friend WithEvents lstResult As ListBox
	Friend WithEvents GroupBox1 As GroupBox
	Friend WithEvents C1Label4 As C1.Win.C1Input.C1Label
	Friend WithEvents txtImportExcel As C1.Win.C1Input.C1TextBox
	Friend WithEvents btnImport As C1.Win.C1Input.C1Button
	Friend WithEvents C1Label1 As C1.Win.C1Input.C1Label
	Friend WithEvents btnLogFolderBrowse As C1.Win.C1Input.C1Button
	Friend WithEvents C1Label2 As C1.Win.C1Input.C1Label
	Friend WithEvents btnSaveFolderBrowse As C1.Win.C1Input.C1Button
	Friend WithEvents C1Label3 As C1.Win.C1Input.C1Label
	Friend WithEvents btnImportExcelBrowse As C1.Win.C1Input.C1Button
	Friend WithEvents txtSaveFolder As C1.Win.C1Input.C1TextBox
	Friend WithEvents txtLogFolder As C1.Win.C1Input.C1TextBox
	Friend WithEvents cmbOffice As C1.Win.C1Input.C1ComboBox
	Friend WithEvents C1Label5 As C1.Win.C1Input.C1Label
	Friend WithEvents numStart As NumericUpDown
End Class
