<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmImport
	Inherits frmTempForm

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
		Me.Panel1 = New System.Windows.Forms.Panel()
		Me.txtLotID = New System.Windows.Forms.TextBox()
		Me.btnPrint = New System.Windows.Forms.Button()
		Me.btnDeleteTest = New System.Windows.Forms.Button()
		Me.btnClose = New System.Windows.Forms.Button()
		Me.Panel2 = New System.Windows.Forms.Panel()
		Me.GroupBox1 = New System.Windows.Forms.GroupBox()
		Me.btnLogFolderBrowse = New System.Windows.Forms.Button()
		Me.txtLogFolder = New System.Windows.Forms.TextBox()
		Me.Label3 = New System.Windows.Forms.Label()
		Me.btnImportToBrowse = New System.Windows.Forms.Button()
		Me.btnImportFromBrowse = New System.Windows.Forms.Button()
		Me.btnImport = New System.Windows.Forms.Button()
		Me.txtImportTo = New System.Windows.Forms.TextBox()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.txtImportFrom = New System.Windows.Forms.TextBox()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.Panel3 = New System.Windows.Forms.Panel()
		Me.lstResult = New System.Windows.Forms.ListBox()
		Me.Panel1.SuspendLayout()
		Me.Panel2.SuspendLayout()
		Me.GroupBox1.SuspendLayout()
		Me.Panel3.SuspendLayout()
		Me.SuspendLayout()
		'
		'Panel1
		'
		Me.Panel1.Controls.Add(Me.txtLotID)
		Me.Panel1.Controls.Add(Me.btnPrint)
		Me.Panel1.Controls.Add(Me.btnDeleteTest)
		Me.Panel1.Controls.Add(Me.btnClose)
		Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
		Me.Panel1.Location = New System.Drawing.Point(0, 489)
		Me.Panel1.Name = "Panel1"
		Me.Panel1.Size = New System.Drawing.Size(784, 50)
		Me.Panel1.TabIndex = 1
		'
		'txtLotID
		'
		Me.txtLotID.AllowDrop = True
		Me.txtLotID.ImeMode = System.Windows.Forms.ImeMode.Disable
		Me.txtLotID.Location = New System.Drawing.Point(174, 13)
		Me.txtLotID.Name = "txtLotID"
		Me.txtLotID.Size = New System.Drawing.Size(213, 24)
		Me.txtLotID.TabIndex = 32
		Me.txtLotID.Text = "20170615162052"
		'
		'btnPrint
		'
		Me.btnPrint.Location = New System.Drawing.Point(93, 12)
		Me.btnPrint.Name = "btnPrint"
		Me.btnPrint.Size = New System.Drawing.Size(75, 26)
		Me.btnPrint.TabIndex = 31
		Me.btnPrint.Text = "インポート"
		Me.btnPrint.UseVisualStyleBackColor = True
		'
		'btnDeleteTest
		'
		Me.btnDeleteTest.Location = New System.Drawing.Point(12, 15)
		Me.btnDeleteTest.Name = "btnDeleteTest"
		Me.btnDeleteTest.Size = New System.Drawing.Size(75, 23)
		Me.btnDeleteTest.TabIndex = 30
		Me.btnDeleteTest.Text = "削除"
		Me.btnDeleteTest.UseVisualStyleBackColor = True
		'
		'btnClose
		'
		Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.btnClose.Location = New System.Drawing.Point(697, 13)
		Me.btnClose.Name = "btnClose"
		Me.btnClose.Size = New System.Drawing.Size(75, 25)
		Me.btnClose.TabIndex = 29
		Me.btnClose.Text = "閉じる"
		Me.btnClose.UseVisualStyleBackColor = True
		'
		'Panel2
		'
		Me.Panel2.Controls.Add(Me.GroupBox1)
		Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
		Me.Panel2.Location = New System.Drawing.Point(0, 0)
		Me.Panel2.Name = "Panel2"
		Me.Panel2.Size = New System.Drawing.Size(784, 119)
		Me.Panel2.TabIndex = 2
		'
		'GroupBox1
		'
		Me.GroupBox1.Controls.Add(Me.btnLogFolderBrowse)
		Me.GroupBox1.Controls.Add(Me.txtLogFolder)
		Me.GroupBox1.Controls.Add(Me.Label3)
		Me.GroupBox1.Controls.Add(Me.btnImportToBrowse)
		Me.GroupBox1.Controls.Add(Me.btnImportFromBrowse)
		Me.GroupBox1.Controls.Add(Me.btnImport)
		Me.GroupBox1.Controls.Add(Me.txtImportTo)
		Me.GroupBox1.Controls.Add(Me.Label2)
		Me.GroupBox1.Controls.Add(Me.txtImportFrom)
		Me.GroupBox1.Controls.Add(Me.Label1)
		Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
		Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
		Me.GroupBox1.Name = "GroupBox1"
		Me.GroupBox1.Size = New System.Drawing.Size(784, 119)
		Me.GroupBox1.TabIndex = 0
		Me.GroupBox1.TabStop = False
		Me.GroupBox1.Text = "インポート設定"
		'
		'btnLogFolderBrowse
		'
		Me.btnLogFolderBrowse.Location = New System.Drawing.Point(647, 81)
		Me.btnLogFolderBrowse.Name = "btnLogFolderBrowse"
		Me.btnLogFolderBrowse.Size = New System.Drawing.Size(32, 26)
		Me.btnLogFolderBrowse.TabIndex = 22
		Me.btnLogFolderBrowse.Text = "..."
		Me.btnLogFolderBrowse.UseVisualStyleBackColor = True
		'
		'txtLogFolder
		'
		Me.txtLogFolder.AllowDrop = True
		Me.txtLogFolder.ImeMode = System.Windows.Forms.ImeMode.Disable
		Me.txtLogFolder.Location = New System.Drawing.Point(148, 83)
		Me.txtLogFolder.Name = "txtLogFolder"
		Me.txtLogFolder.Size = New System.Drawing.Size(493, 24)
		Me.txtLogFolder.TabIndex = 21
		'
		'Label3
		'
		Me.Label3.Location = New System.Drawing.Point(12, 84)
		Me.Label3.Name = "Label3"
		Me.Label3.Size = New System.Drawing.Size(130, 20)
		Me.Label3.TabIndex = 25
		Me.Label3.Text = "ログ保存先フォルダ："
		Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'btnImportToBrowse
		'
		Me.btnImportToBrowse.Location = New System.Drawing.Point(647, 51)
		Me.btnImportToBrowse.Name = "btnImportToBrowse"
		Me.btnImportToBrowse.Size = New System.Drawing.Size(32, 26)
		Me.btnImportToBrowse.TabIndex = 20
		Me.btnImportToBrowse.Text = "..."
		Me.btnImportToBrowse.UseVisualStyleBackColor = True
		'
		'btnImportFromBrowse
		'
		Me.btnImportFromBrowse.Location = New System.Drawing.Point(647, 21)
		Me.btnImportFromBrowse.Name = "btnImportFromBrowse"
		Me.btnImportFromBrowse.Size = New System.Drawing.Size(32, 26)
		Me.btnImportFromBrowse.TabIndex = 17
		Me.btnImportFromBrowse.Text = "..."
		Me.btnImportFromBrowse.UseVisualStyleBackColor = True
		'
		'btnImport
		'
		Me.btnImport.Location = New System.Drawing.Point(697, 81)
		Me.btnImport.Name = "btnImport"
		Me.btnImport.Size = New System.Drawing.Size(75, 26)
		Me.btnImport.TabIndex = 23
		Me.btnImport.Text = "インポート"
		Me.btnImport.UseVisualStyleBackColor = True
		'
		'txtImportTo
		'
		Me.txtImportTo.AllowDrop = True
		Me.txtImportTo.ImeMode = System.Windows.Forms.ImeMode.Disable
		Me.txtImportTo.Location = New System.Drawing.Point(148, 53)
		Me.txtImportTo.Name = "txtImportTo"
		Me.txtImportTo.Size = New System.Drawing.Size(493, 24)
		Me.txtImportTo.TabIndex = 19
		'
		'Label2
		'
		Me.Label2.Location = New System.Drawing.Point(12, 54)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(130, 20)
		Me.Label2.TabIndex = 24
		Me.Label2.Text = "保存先フォルダ："
		Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'txtImportFrom
		'
		Me.txtImportFrom.AllowDrop = True
		Me.txtImportFrom.ImeMode = System.Windows.Forms.ImeMode.Disable
		Me.txtImportFrom.Location = New System.Drawing.Point(148, 23)
		Me.txtImportFrom.Name = "txtImportFrom"
		Me.txtImportFrom.Size = New System.Drawing.Size(493, 24)
		Me.txtImportFrom.TabIndex = 16
		'
		'Label1
		'
		Me.Label1.Location = New System.Drawing.Point(12, 24)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(130, 20)
		Me.Label1.TabIndex = 18
		Me.Label1.Text = "インポート元フォルダ："
		Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'Panel3
		'
		Me.Panel3.Controls.Add(Me.lstResult)
		Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
		Me.Panel3.Location = New System.Drawing.Point(0, 119)
		Me.Panel3.Name = "Panel3"
		Me.Panel3.Size = New System.Drawing.Size(784, 370)
		Me.Panel3.TabIndex = 3
		'
		'lstResult
		'
		Me.lstResult.Dock = System.Windows.Forms.DockStyle.Fill
		Me.lstResult.FormattingEnabled = True
		Me.lstResult.ItemHeight = 17
		Me.lstResult.Location = New System.Drawing.Point(0, 0)
		Me.lstResult.Name = "lstResult"
		Me.lstResult.Size = New System.Drawing.Size(784, 370)
		Me.lstResult.TabIndex = 0
		'
		'frmImport
		'
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
		Me.CaptionDisplayMode = JPHealth.frmTempForm.StatusDisplayMode.ShowAll
		Me.ClientSize = New System.Drawing.Size(784, 561)
		Me.Controls.Add(Me.Panel3)
		Me.Controls.Add(Me.Panel2)
		Me.Controls.Add(Me.Panel1)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.KeyPreview = True
		Me.MaximizeBox = False
		Me.Name = "frmImport"
		Me.ShowInTaskbar = False
		Me.Text = "frmImport"
		Me.Controls.SetChildIndex(Me.Panel1, 0)
		Me.Controls.SetChildIndex(Me.Panel2, 0)
		Me.Controls.SetChildIndex(Me.Panel3, 0)
		Me.Panel1.ResumeLayout(False)
		Me.Panel1.PerformLayout()
		Me.Panel2.ResumeLayout(False)
		Me.GroupBox1.ResumeLayout(False)
		Me.GroupBox1.PerformLayout()
		Me.Panel3.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	Friend WithEvents Panel1 As Panel
	Friend WithEvents Panel2 As Panel
	Friend WithEvents GroupBox1 As GroupBox
	Friend WithEvents Panel3 As Panel
	Friend WithEvents btnDeleteTest As Button
	Friend WithEvents btnClose As Button
	Friend WithEvents btnLogFolderBrowse As Button
	Friend WithEvents txtLogFolder As TextBox
	Friend WithEvents Label3 As Label
	Friend WithEvents btnImportToBrowse As Button
	Friend WithEvents btnImportFromBrowse As Button
	Friend WithEvents btnImport As Button
	Friend WithEvents txtImportTo As TextBox
	Friend WithEvents Label2 As Label
	Friend WithEvents txtImportFrom As TextBox
	Friend WithEvents Label1 As Label
	Friend WithEvents lstResult As ListBox
	Friend WithEvents txtLotID As TextBox
	Friend WithEvents btnPrint As Button
End Class
