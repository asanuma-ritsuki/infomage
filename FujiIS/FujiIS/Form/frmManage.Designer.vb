<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmManage
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
		Me.btnCancel = New System.Windows.Forms.Button()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.btnBrowse = New System.Windows.Forms.Button()
		Me.txtImagePath = New System.Windows.Forms.TextBox()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.Button1 = New System.Windows.Forms.Button()
		Me.txtSaveFolder = New System.Windows.Forms.TextBox()
		Me.btnRun = New System.Windows.Forms.Button()
		Me.cmbExt = New System.Windows.Forms.ComboBox()
		Me.Label3 = New System.Windows.Forms.Label()
		Me.lblResult = New System.Windows.Forms.Label()
		Me.btnOutput = New System.Windows.Forms.Button()
		Me.txtSubFolder = New System.Windows.Forms.TextBox()
		Me.Panel1.SuspendLayout()
		Me.SuspendLayout()
		'
		'Panel1
		'
		Me.Panel1.Controls.Add(Me.btnCancel)
		Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
		Me.Panel1.Location = New System.Drawing.Point(0, 507)
		Me.Panel1.Name = "Panel1"
		Me.Panel1.Size = New System.Drawing.Size(784, 32)
		Me.Panel1.TabIndex = 2
		'
		'btnCancel
		'
		Me.btnCancel.Location = New System.Drawing.Point(697, 4)
		Me.btnCancel.Name = "btnCancel"
		Me.btnCancel.Size = New System.Drawing.Size(75, 25)
		Me.btnCancel.TabIndex = 1
		Me.btnCancel.Text = "戻　る"
		Me.btnCancel.UseVisualStyleBackColor = True
		'
		'Label1
		'
		Me.Label1.AutoSize = True
		Me.Label1.Location = New System.Drawing.Point(27, 15)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(72, 17)
		Me.Label1.TabIndex = 15
		Me.Label1.Text = "元フォルダ："
		'
		'btnBrowse
		'
		Me.btnBrowse.Location = New System.Drawing.Point(737, 11)
		Me.btnBrowse.Name = "btnBrowse"
		Me.btnBrowse.Size = New System.Drawing.Size(35, 25)
		Me.btnBrowse.TabIndex = 14
		Me.btnBrowse.Text = "..."
		Me.btnBrowse.UseVisualStyleBackColor = True
		'
		'txtImagePath
		'
		Me.txtImagePath.AllowDrop = True
		Me.txtImagePath.Location = New System.Drawing.Point(105, 12)
		Me.txtImagePath.Name = "txtImagePath"
		Me.txtImagePath.Size = New System.Drawing.Size(626, 24)
		Me.txtImagePath.TabIndex = 13
		Me.txtImagePath.Text = "\\hydra\01_制作Gr\04_スポット案件\20170201_161241005_富士フィルムIS\31_PDF変換"
		'
		'Label2
		'
		Me.Label2.AutoSize = True
		Me.Label2.Location = New System.Drawing.Point(14, 45)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(85, 17)
		Me.Label2.TabIndex = 18
		Me.Label2.Text = "保存フォルダ："
		'
		'Button1
		'
		Me.Button1.Location = New System.Drawing.Point(737, 41)
		Me.Button1.Name = "Button1"
		Me.Button1.Size = New System.Drawing.Size(35, 25)
		Me.Button1.TabIndex = 17
		Me.Button1.Text = "..."
		Me.Button1.UseVisualStyleBackColor = True
		'
		'txtSaveFolder
		'
		Me.txtSaveFolder.AllowDrop = True
		Me.txtSaveFolder.Location = New System.Drawing.Point(105, 42)
		Me.txtSaveFolder.Name = "txtSaveFolder"
		Me.txtSaveFolder.Size = New System.Drawing.Size(626, 24)
		Me.txtSaveFolder.TabIndex = 16
		Me.txtSaveFolder.Text = "\\hydra\01_制作Gr\04_スポット案件\20170201_161241005_富士フィルムIS\41_納品"
		'
		'btnRun
		'
		Me.btnRun.Location = New System.Drawing.Point(697, 72)
		Me.btnRun.Name = "btnRun"
		Me.btnRun.Size = New System.Drawing.Size(75, 25)
		Me.btnRun.TabIndex = 19
		Me.btnRun.Text = "情報収集"
		Me.btnRun.UseVisualStyleBackColor = True
		'
		'cmbExt
		'
		Me.cmbExt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cmbExt.FormattingEnabled = True
		Me.cmbExt.Items.AddRange(New Object() {".pdf", ".jpg"})
		Me.cmbExt.Location = New System.Drawing.Point(105, 72)
		Me.cmbExt.Name = "cmbExt"
		Me.cmbExt.Size = New System.Drawing.Size(121, 25)
		Me.cmbExt.TabIndex = 20
		'
		'Label3
		'
		Me.Label3.AutoSize = True
		Me.Label3.Location = New System.Drawing.Point(39, 75)
		Me.Label3.Name = "Label3"
		Me.Label3.Size = New System.Drawing.Size(60, 17)
		Me.Label3.TabIndex = 21
		Me.Label3.Text = "拡張子："
		'
		'lblResult
		'
		Me.lblResult.AutoSize = True
		Me.lblResult.Location = New System.Drawing.Point(102, 109)
		Me.lblResult.Name = "lblResult"
		Me.lblResult.Size = New System.Drawing.Size(50, 17)
		Me.lblResult.TabIndex = 22
		Me.lblResult.Text = "Label4"
		'
		'btnOutput
		'
		Me.btnOutput.Location = New System.Drawing.Point(697, 105)
		Me.btnOutput.Name = "btnOutput"
		Me.btnOutput.Size = New System.Drawing.Size(75, 25)
		Me.btnOutput.TabIndex = 23
		Me.btnOutput.Text = "出　力"
		Me.btnOutput.UseVisualStyleBackColor = True
		'
		'txtSubFolder
		'
		Me.txtSubFolder.AllowDrop = True
		Me.txtSubFolder.Location = New System.Drawing.Point(256, 72)
		Me.txtSubFolder.Name = "txtSubFolder"
		Me.txtSubFolder.Size = New System.Drawing.Size(88, 24)
		Me.txtSubFolder.TabIndex = 24
		Me.txtSubFolder.Text = "image"
		'
		'frmManage
		'
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
		Me.CaptionDisplayMode = FujiIS.frmTempForm.StatusDisplayMode.ShowAll
		Me.ClientSize = New System.Drawing.Size(784, 561)
		Me.Controls.Add(Me.txtSubFolder)
		Me.Controls.Add(Me.btnOutput)
		Me.Controls.Add(Me.lblResult)
		Me.Controls.Add(Me.Label3)
		Me.Controls.Add(Me.cmbExt)
		Me.Controls.Add(Me.btnRun)
		Me.Controls.Add(Me.Label2)
		Me.Controls.Add(Me.Button1)
		Me.Controls.Add(Me.txtSaveFolder)
		Me.Controls.Add(Me.Label1)
		Me.Controls.Add(Me.btnBrowse)
		Me.Controls.Add(Me.txtImagePath)
		Me.Controls.Add(Me.Panel1)
		Me.KeyPreview = True
		Me.Margin = New System.Windows.Forms.Padding(2)
		Me.Name = "frmManage"
		Me.Text = "frmManage"
		Me.Controls.SetChildIndex(Me.Panel1, 0)
		Me.Controls.SetChildIndex(Me.txtImagePath, 0)
		Me.Controls.SetChildIndex(Me.btnBrowse, 0)
		Me.Controls.SetChildIndex(Me.Label1, 0)
		Me.Controls.SetChildIndex(Me.txtSaveFolder, 0)
		Me.Controls.SetChildIndex(Me.Button1, 0)
		Me.Controls.SetChildIndex(Me.Label2, 0)
		Me.Controls.SetChildIndex(Me.btnRun, 0)
		Me.Controls.SetChildIndex(Me.cmbExt, 0)
		Me.Controls.SetChildIndex(Me.Label3, 0)
		Me.Controls.SetChildIndex(Me.lblResult, 0)
		Me.Controls.SetChildIndex(Me.btnOutput, 0)
		Me.Controls.SetChildIndex(Me.txtSubFolder, 0)
		Me.Panel1.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	Friend WithEvents Panel1 As Panel
	Friend WithEvents btnCancel As Button
	Friend WithEvents Label1 As Label
	Friend WithEvents btnBrowse As Button
	Friend WithEvents txtImagePath As TextBox
	Friend WithEvents Label2 As Label
	Friend WithEvents Button1 As Button
	Friend WithEvents txtSaveFolder As TextBox
	Friend WithEvents btnRun As Button
	Friend WithEvents cmbExt As ComboBox
	Friend WithEvents Label3 As Label
	Friend WithEvents lblResult As Label
	Friend WithEvents btnOutput As Button
	Friend WithEvents txtSubFolder As TextBox
End Class
