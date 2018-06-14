<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMainMenu
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMainMenu))
		Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
		Me.ファイルFToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.menuExit = New System.Windows.Forms.ToolStripMenuItem()
		Me.ツールTToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.menuConnection = New System.Windows.Forms.ToolStripMenuItem()
		Me.PictureBox1 = New System.Windows.Forms.PictureBox()
		Me.Label3 = New System.Windows.Forms.Label()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.btnOperation = New System.Windows.Forms.Button()
		Me.btnExit = New System.Windows.Forms.Button()
		Me.btnMaintenance = New System.Windows.Forms.Button()
		Me.MenuStrip1.SuspendLayout()
		CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'MenuStrip1
		'
		Me.MenuStrip1.BackColor = System.Drawing.Color.White
		Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ファイルFToolStripMenuItem, Me.ツールTToolStripMenuItem})
		Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
		Me.MenuStrip1.Name = "MenuStrip1"
		Me.MenuStrip1.Size = New System.Drawing.Size(454, 24)
		Me.MenuStrip1.TabIndex = 1
		Me.MenuStrip1.Text = "MenuStrip1"
		'
		'ファイルFToolStripMenuItem
		'
		Me.ファイルFToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuExit})
		Me.ファイルFToolStripMenuItem.Name = "ファイルFToolStripMenuItem"
		Me.ファイルFToolStripMenuItem.Size = New System.Drawing.Size(67, 20)
		Me.ファイルFToolStripMenuItem.Text = "ファイル(&F)"
		'
		'menuExit
		'
		Me.menuExit.Name = "menuExit"
		Me.menuExit.Size = New System.Drawing.Size(152, 22)
		Me.menuExit.Text = "終了(&X)"
		'
		'ツールTToolStripMenuItem
		'
		Me.ツールTToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuConnection})
		Me.ツールTToolStripMenuItem.Name = "ツールTToolStripMenuItem"
		Me.ツールTToolStripMenuItem.Size = New System.Drawing.Size(60, 20)
		Me.ツールTToolStripMenuItem.Text = "ツール(&T)"
		'
		'menuConnection
		'
		Me.menuConnection.Name = "menuConnection"
		Me.menuConnection.Size = New System.Drawing.Size(152, 22)
		Me.menuConnection.Text = "接続設定(&C)"
		'
		'PictureBox1
		'
		Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
		Me.PictureBox1.InitialImage = Nothing
		Me.PictureBox1.Location = New System.Drawing.Point(12, 27)
		Me.PictureBox1.Name = "PictureBox1"
		Me.PictureBox1.Size = New System.Drawing.Size(162, 160)
		Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
		Me.PictureBox1.TabIndex = 10
		Me.PictureBox1.TabStop = False
		'
		'Label3
		'
		Me.Label3.Font = New System.Drawing.Font("メイリオ", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(196, Byte), Integer), CType(CType(15, Byte), Integer), CType(CType(57, Byte), Integer))
		Me.Label3.Location = New System.Drawing.Point(180, 27)
		Me.Label3.Name = "Label3"
		Me.Label3.Size = New System.Drawing.Size(262, 41)
		Me.Label3.TabIndex = 11
		Me.Label3.Text = "入札参加資格"
		Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'Label1
		'
		Me.Label1.Font = New System.Drawing.Font("メイリオ", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(196, Byte), Integer), CType(CType(15, Byte), Integer), CType(CType(57, Byte), Integer))
		Me.Label1.Location = New System.Drawing.Point(180, 68)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(262, 41)
		Me.Label1.TabIndex = 12
		Me.Label1.Text = "情報管理ツール"
		Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'Label2
		'
		Me.Label2.Font = New System.Drawing.Font("メイリオ", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(196, Byte), Integer), CType(CType(15, Byte), Integer), CType(CType(57, Byte), Integer))
		Me.Label2.Location = New System.Drawing.Point(180, 109)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(262, 41)
		Me.Label2.TabIndex = 13
		Me.Label2.Text = "n-system"
		Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'btnOperation
		'
		Me.btnOperation.Font = New System.Drawing.Font("Meiryo UI", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.btnOperation.Location = New System.Drawing.Point(192, 157)
		Me.btnOperation.Name = "btnOperation"
		Me.btnOperation.Size = New System.Drawing.Size(250, 50)
		Me.btnOperation.TabIndex = 14
		Me.btnOperation.Text = "運　用　画　面"
		Me.btnOperation.UseVisualStyleBackColor = True
		'
		'btnExit
		'
		Me.btnExit.Font = New System.Drawing.Font("Meiryo UI", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.btnExit.Location = New System.Drawing.Point(192, 269)
		Me.btnExit.Name = "btnExit"
		Me.btnExit.Size = New System.Drawing.Size(250, 50)
		Me.btnExit.TabIndex = 16
		Me.btnExit.Text = "終　了"
		Me.btnExit.UseVisualStyleBackColor = True
		'
		'btnMaintenance
		'
		Me.btnMaintenance.Font = New System.Drawing.Font("Meiryo UI", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.btnMaintenance.Location = New System.Drawing.Point(192, 213)
		Me.btnMaintenance.Name = "btnMaintenance"
		Me.btnMaintenance.Size = New System.Drawing.Size(250, 50)
		Me.btnMaintenance.TabIndex = 15
		Me.btnMaintenance.Text = "各種メンテナンス"
		Me.btnMaintenance.UseVisualStyleBackColor = True
		'
		'frmMainMenu
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 17.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.SystemColors.Window
		Me.CaptionDisplayMode = BidEntryManageTool.frmTempForm.StatusDisplayMode.ShowAll
		Me.ClientSize = New System.Drawing.Size(454, 331)
		Me.Controls.Add(Me.btnExit)
		Me.Controls.Add(Me.btnMaintenance)
		Me.Controls.Add(Me.btnOperation)
		Me.Controls.Add(Me.Label2)
		Me.Controls.Add(Me.Label1)
		Me.Controls.Add(Me.Label3)
		Me.Controls.Add(Me.PictureBox1)
		Me.Controls.Add(Me.MenuStrip1)
		Me.MainMenuStrip = Me.MenuStrip1
		Me.Name = "frmMainMenu"
		Me.Text = "frmMainMenu"
		Me.Controls.SetChildIndex(Me.MenuStrip1, 0)
		Me.Controls.SetChildIndex(Me.PictureBox1, 0)
		Me.Controls.SetChildIndex(Me.Label3, 0)
		Me.Controls.SetChildIndex(Me.Label1, 0)
		Me.Controls.SetChildIndex(Me.Label2, 0)
		Me.Controls.SetChildIndex(Me.btnOperation, 0)
		Me.Controls.SetChildIndex(Me.btnMaintenance, 0)
		Me.Controls.SetChildIndex(Me.btnExit, 0)
		Me.MenuStrip1.ResumeLayout(False)
		Me.MenuStrip1.PerformLayout()
		CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	Friend WithEvents MenuStrip1 As MenuStrip
	Friend WithEvents ファイルFToolStripMenuItem As ToolStripMenuItem
	Friend WithEvents menuExit As ToolStripMenuItem
	Friend WithEvents ツールTToolStripMenuItem As ToolStripMenuItem
	Friend WithEvents menuConnection As ToolStripMenuItem
	Friend WithEvents PictureBox1 As PictureBox
	Friend WithEvents Label3 As Label
	Friend WithEvents Label1 As Label
	Friend WithEvents Label2 As Label
	Friend WithEvents btnOperation As Button
	Friend WithEvents btnExit As Button
	Friend WithEvents btnMaintenance As Button
End Class
