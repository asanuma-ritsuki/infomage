<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmExtraction
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
		Me.btnImportManagerBrowse = New C1.Win.C1Input.C1Button()
		Me.txtImportManager = New C1.Win.C1Input.C1TextBox()
		Me.C1Label6 = New C1.Win.C1Input.C1Label()
		Me.btnImportUsrBrowse = New C1.Win.C1Input.C1Button()
		Me.txtImportUsr = New C1.Win.C1Input.C1TextBox()
		Me.C1Label4 = New C1.Win.C1Input.C1Label()
		Me.txtOffice = New C1.Win.C1Input.C1TextBox()
		Me.txtLotID = New C1.Win.C1Input.C1TextBox()
		Me.C1Label1 = New C1.Win.C1Input.C1Label()
		Me.btnOutput = New C1.Win.C1Input.C1Button()
		Me.btnLogFolderBrowse = New C1.Win.C1Input.C1Button()
		Me.C1Label2 = New C1.Win.C1Input.C1Label()
		Me.btnOutputFolderBrowse = New C1.Win.C1Input.C1Button()
		Me.C1Label3 = New C1.Win.C1Input.C1Label()
		Me.txtOutputFolder = New C1.Win.C1Input.C1TextBox()
		Me.txtLogFolder = New C1.Win.C1Input.C1TextBox()
		Me.lstResult = New System.Windows.Forms.ListBox()
		Me.Panel1.SuspendLayout()
		Me.GroupBox1.SuspendLayout()
		CType(Me.C1Label5, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.btnImportManagerBrowse, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.txtImportManager, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.C1Label6, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.btnImportUsrBrowse, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.txtImportUsr, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.C1Label4, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.txtOffice, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.txtLotID, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.C1Label1, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.btnOutput, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.btnLogFolderBrowse, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.C1Label2, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.btnOutputFolderBrowse, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.C1Label3, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.txtOutputFolder, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.txtLogFolder, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'Panel1
		'
		Me.Panel1.Controls.Add(Me.GroupBox1)
		Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
		Me.Panel1.Location = New System.Drawing.Point(0, 0)
		Me.Panel1.Name = "Panel1"
		Me.Panel1.Size = New System.Drawing.Size(784, 187)
		Me.Panel1.TabIndex = 3
		'
		'GroupBox1
		'
		Me.GroupBox1.Controls.Add(Me.C1Label5)
		Me.GroupBox1.Controls.Add(Me.btnImportManagerBrowse)
		Me.GroupBox1.Controls.Add(Me.txtImportManager)
		Me.GroupBox1.Controls.Add(Me.C1Label6)
		Me.GroupBox1.Controls.Add(Me.btnImportUsrBrowse)
		Me.GroupBox1.Controls.Add(Me.txtImportUsr)
		Me.GroupBox1.Controls.Add(Me.C1Label4)
		Me.GroupBox1.Controls.Add(Me.txtOffice)
		Me.GroupBox1.Controls.Add(Me.txtLotID)
		Me.GroupBox1.Controls.Add(Me.C1Label1)
		Me.GroupBox1.Controls.Add(Me.btnOutput)
		Me.GroupBox1.Controls.Add(Me.btnLogFolderBrowse)
		Me.GroupBox1.Controls.Add(Me.C1Label2)
		Me.GroupBox1.Controls.Add(Me.btnOutputFolderBrowse)
		Me.GroupBox1.Controls.Add(Me.C1Label3)
		Me.GroupBox1.Controls.Add(Me.txtOutputFolder)
		Me.GroupBox1.Controls.Add(Me.txtLogFolder)
		Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
		Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
		Me.GroupBox1.Name = "GroupBox1"
		Me.GroupBox1.Size = New System.Drawing.Size(784, 187)
		Me.GroupBox1.TabIndex = 11
		Me.GroupBox1.TabStop = False
		Me.GroupBox1.Text = "インポート設定"
		'
		'C1Label5
		'
		Me.C1Label5.BackColor = System.Drawing.Color.Transparent
		Me.C1Label5.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.C1Label5.ForeColor = System.Drawing.Color.Black
		Me.C1Label5.Location = New System.Drawing.Point(12, 88)
		Me.C1Label5.Name = "C1Label5"
		Me.C1Label5.Size = New System.Drawing.Size(124, 25)
		Me.C1Label5.TabIndex = 21
		Me.C1Label5.Tag = Nothing
		Me.C1Label5.Text = "管理者情報CSV："
		Me.C1Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.C1Label5.TextDetached = True
		Me.C1Label5.Value = ""
		'
		'btnImportManagerBrowse
		'
		Me.btnImportManagerBrowse.Location = New System.Drawing.Point(660, 90)
		Me.btnImportManagerBrowse.Name = "btnImportManagerBrowse"
		Me.btnImportManagerBrowse.Size = New System.Drawing.Size(30, 25)
		Me.btnImportManagerBrowse.TabIndex = 23
		Me.btnImportManagerBrowse.Text = "..."
		Me.btnImportManagerBrowse.UseVisualStyleBackColor = True
		'
		'txtImportManager
		'
		Me.txtImportManager.AllowDrop = True
		Me.txtImportManager.AutoSize = False
		Me.txtImportManager.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.txtImportManager.Location = New System.Drawing.Point(142, 90)
		Me.txtImportManager.Name = "txtImportManager"
		Me.txtImportManager.Size = New System.Drawing.Size(512, 25)
		Me.txtImportManager.TabIndex = 22
		Me.txtImportManager.Tag = Nothing
		Me.txtImportManager.TextDetached = True
		'
		'C1Label6
		'
		Me.C1Label6.BackColor = System.Drawing.Color.Transparent
		Me.C1Label6.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.C1Label6.ForeColor = System.Drawing.Color.Black
		Me.C1Label6.Location = New System.Drawing.Point(12, 57)
		Me.C1Label6.Name = "C1Label6"
		Me.C1Label6.Size = New System.Drawing.Size(124, 25)
		Me.C1Label6.TabIndex = 18
		Me.C1Label6.Tag = Nothing
		Me.C1Label6.Text = "利用者情報CSV："
		Me.C1Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.C1Label6.TextDetached = True
		Me.C1Label6.Value = ""
		'
		'btnImportUsrBrowse
		'
		Me.btnImportUsrBrowse.Location = New System.Drawing.Point(660, 59)
		Me.btnImportUsrBrowse.Name = "btnImportUsrBrowse"
		Me.btnImportUsrBrowse.Size = New System.Drawing.Size(30, 25)
		Me.btnImportUsrBrowse.TabIndex = 20
		Me.btnImportUsrBrowse.Text = "..."
		Me.btnImportUsrBrowse.UseVisualStyleBackColor = True
		'
		'txtImportUsr
		'
		Me.txtImportUsr.AllowDrop = True
		Me.txtImportUsr.AutoSize = False
		Me.txtImportUsr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.txtImportUsr.Location = New System.Drawing.Point(142, 59)
		Me.txtImportUsr.Name = "txtImportUsr"
		Me.txtImportUsr.Size = New System.Drawing.Size(512, 25)
		Me.txtImportUsr.TabIndex = 19
		Me.txtImportUsr.Tag = Nothing
		Me.txtImportUsr.TextDetached = True
		'
		'C1Label4
		'
		Me.C1Label4.BackColor = System.Drawing.Color.Transparent
		Me.C1Label4.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.C1Label4.ForeColor = System.Drawing.Color.Black
		Me.C1Label4.Location = New System.Drawing.Point(309, 28)
		Me.C1Label4.Name = "C1Label4"
		Me.C1Label4.Size = New System.Drawing.Size(124, 25)
		Me.C1Label4.TabIndex = 14
		Me.C1Label4.Tag = Nothing
		Me.C1Label4.Text = "事業所："
		Me.C1Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.C1Label4.TextDetached = True
		Me.C1Label4.Value = ""
		'
		'txtOffice
		'
		Me.txtOffice.AllowDrop = True
		Me.txtOffice.AutoSize = False
		Me.txtOffice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.txtOffice.Location = New System.Drawing.Point(441, 28)
		Me.txtOffice.Name = "txtOffice"
		Me.txtOffice.ReadOnly = True
		Me.txtOffice.Size = New System.Drawing.Size(161, 25)
		Me.txtOffice.TabIndex = 13
		Me.txtOffice.Tag = Nothing
		Me.txtOffice.TextDetached = True
		'
		'txtLotID
		'
		Me.txtLotID.AllowDrop = True
		Me.txtLotID.AutoSize = False
		Me.txtLotID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.txtLotID.Location = New System.Drawing.Point(142, 28)
		Me.txtLotID.Name = "txtLotID"
		Me.txtLotID.ReadOnly = True
		Me.txtLotID.Size = New System.Drawing.Size(161, 25)
		Me.txtLotID.TabIndex = 12
		Me.txtLotID.Tag = Nothing
		Me.txtLotID.TextDetached = True
		'
		'C1Label1
		'
		Me.C1Label1.BackColor = System.Drawing.Color.Transparent
		Me.C1Label1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.C1Label1.ForeColor = System.Drawing.Color.Black
		Me.C1Label1.Location = New System.Drawing.Point(12, 26)
		Me.C1Label1.Name = "C1Label1"
		Me.C1Label1.Size = New System.Drawing.Size(124, 25)
		Me.C1Label1.TabIndex = 11
		Me.C1Label1.Tag = Nothing
		Me.C1Label1.Text = "ロットID："
		Me.C1Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.C1Label1.TextDetached = True
		Me.C1Label1.Value = ""
		'
		'btnOutput
		'
		Me.btnOutput.Location = New System.Drawing.Point(705, 26)
		Me.btnOutput.Name = "btnOutput"
		Me.btnOutput.Size = New System.Drawing.Size(75, 25)
		Me.btnOutput.TabIndex = 10
		Me.btnOutput.Text = "実　行"
		Me.btnOutput.UseVisualStyleBackColor = True
		'
		'btnLogFolderBrowse
		'
		Me.btnLogFolderBrowse.Location = New System.Drawing.Point(660, 152)
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
		Me.C1Label2.Location = New System.Drawing.Point(12, 119)
		Me.C1Label2.Name = "C1Label2"
		Me.C1Label2.Size = New System.Drawing.Size(124, 25)
		Me.C1Label2.TabIndex = 2
		Me.C1Label2.Tag = Nothing
		Me.C1Label2.Text = "出力フォルダ："
		Me.C1Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.C1Label2.TextDetached = True
		Me.C1Label2.Value = ""
		'
		'btnOutputFolderBrowse
		'
		Me.btnOutputFolderBrowse.Location = New System.Drawing.Point(660, 121)
		Me.btnOutputFolderBrowse.Name = "btnOutputFolderBrowse"
		Me.btnOutputFolderBrowse.Size = New System.Drawing.Size(30, 25)
		Me.btnOutputFolderBrowse.TabIndex = 8
		Me.btnOutputFolderBrowse.Text = "..."
		Me.btnOutputFolderBrowse.UseVisualStyleBackColor = True
		'
		'C1Label3
		'
		Me.C1Label3.BackColor = System.Drawing.Color.Transparent
		Me.C1Label3.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.C1Label3.ForeColor = System.Drawing.Color.Black
		Me.C1Label3.Location = New System.Drawing.Point(12, 150)
		Me.C1Label3.Name = "C1Label3"
		Me.C1Label3.Size = New System.Drawing.Size(124, 25)
		Me.C1Label3.TabIndex = 3
		Me.C1Label3.Tag = Nothing
		Me.C1Label3.Text = "ログ保存先フォルダ："
		Me.C1Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.C1Label3.TextDetached = True
		Me.C1Label3.Value = ""
		'
		'txtOutputFolder
		'
		Me.txtOutputFolder.AllowDrop = True
		Me.txtOutputFolder.AutoSize = False
		Me.txtOutputFolder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.txtOutputFolder.Location = New System.Drawing.Point(142, 121)
		Me.txtOutputFolder.Name = "txtOutputFolder"
		Me.txtOutputFolder.Size = New System.Drawing.Size(512, 25)
		Me.txtOutputFolder.TabIndex = 5
		Me.txtOutputFolder.Tag = Nothing
		Me.txtOutputFolder.TextDetached = True
		'
		'txtLogFolder
		'
		Me.txtLogFolder.AllowDrop = True
		Me.txtLogFolder.AutoSize = False
		Me.txtLogFolder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.txtLogFolder.Location = New System.Drawing.Point(142, 152)
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
		Me.lstResult.Location = New System.Drawing.Point(0, 187)
		Me.lstResult.Name = "lstResult"
		Me.lstResult.Size = New System.Drawing.Size(784, 351)
		Me.lstResult.TabIndex = 4
		'
		'frmExtraction
		'
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
		Me.ClientSize = New System.Drawing.Size(784, 561)
		Me.Controls.Add(Me.lstResult)
		Me.Controls.Add(Me.Panel1)
		Me.Name = "frmExtraction"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "frmExtraction"
		Me.Controls.SetChildIndex(Me.Panel1, 0)
		Me.Controls.SetChildIndex(Me.lstResult, 0)
		Me.Panel1.ResumeLayout(False)
		Me.GroupBox1.ResumeLayout(False)
		CType(Me.C1Label5, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.btnImportManagerBrowse, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.txtImportManager, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.C1Label6, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.btnImportUsrBrowse, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.txtImportUsr, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.C1Label4, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.txtOffice, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.txtLotID, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.C1Label1, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.btnOutput, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.btnLogFolderBrowse, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.C1Label2, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.btnOutputFolderBrowse, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.C1Label3, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.txtOutputFolder, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.txtLogFolder, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	Friend WithEvents Panel1 As Panel
	Friend WithEvents GroupBox1 As GroupBox
	Friend WithEvents C1Label4 As C1.Win.C1Input.C1Label
	Friend WithEvents txtOffice As C1.Win.C1Input.C1TextBox
	Friend WithEvents txtLotID As C1.Win.C1Input.C1TextBox
	Friend WithEvents C1Label1 As C1.Win.C1Input.C1Label
	Friend WithEvents btnOutput As C1.Win.C1Input.C1Button
	Friend WithEvents btnLogFolderBrowse As C1.Win.C1Input.C1Button
	Friend WithEvents C1Label2 As C1.Win.C1Input.C1Label
	Friend WithEvents btnOutputFolderBrowse As C1.Win.C1Input.C1Button
	Friend WithEvents C1Label3 As C1.Win.C1Input.C1Label
	Friend WithEvents txtOutputFolder As C1.Win.C1Input.C1TextBox
	Friend WithEvents txtLogFolder As C1.Win.C1Input.C1TextBox
	Friend WithEvents lstResult As ListBox
	Friend WithEvents C1Label5 As C1.Win.C1Input.C1Label
	Friend WithEvents btnImportManagerBrowse As C1.Win.C1Input.C1Button
	Friend WithEvents txtImportManager As C1.Win.C1Input.C1TextBox
	Friend WithEvents C1Label6 As C1.Win.C1Input.C1Label
	Friend WithEvents btnImportUsrBrowse As C1.Win.C1Input.C1Button
	Friend WithEvents txtImportUsr As C1.Win.C1Input.C1TextBox
End Class
