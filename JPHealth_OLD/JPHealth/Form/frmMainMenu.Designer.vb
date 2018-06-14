<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMainMenu
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMainMenu))
		Me.Label1 = New System.Windows.Forms.Label()
		Me.Label3 = New System.Windows.Forms.Label()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.btnOperation = New System.Windows.Forms.Button()
		Me.btnMaintenance = New System.Windows.Forms.Button()
		Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
		Me.ファイルFToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.menuExit = New System.Windows.Forms.ToolStripMenuItem()
		Me.ツールTToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.menuConnection = New System.Windows.Forms.ToolStripMenuItem()
		Me.btnExit = New System.Windows.Forms.Button()
		Me.PictureBox1 = New System.Windows.Forms.PictureBox()
		Me.MenuStrip1.SuspendLayout()
		CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'Label1
		'
		Me.Label1.AutoSize = True
		Me.Label1.Font = New System.Drawing.Font("メイリオ", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(196, Byte), Integer), CType(CType(15, Byte), Integer), CType(CType(57, Byte), Integer))
		Me.Label1.Location = New System.Drawing.Point(261, 30)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(126, 41)
		Me.Label1.TabIndex = 2
		Me.Label1.Text = "日本郵便"
		'
		'Label3
		'
		Me.Label3.AutoSize = True
		Me.Label3.Font = New System.Drawing.Font("メイリオ", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(196, Byte), Integer), CType(CType(15, Byte), Integer), CType(CType(57, Byte), Integer))
		Me.Label3.Location = New System.Drawing.Point(194, 71)
		Me.Label3.Name = "Label3"
		Me.Label3.Size = New System.Drawing.Size(261, 41)
		Me.Label3.TabIndex = 3
		Me.Label3.Text = "就業判定票発送業務"
		'
		'Label2
		'
		Me.Label2.AutoSize = True
		Me.Label2.Font = New System.Drawing.Font("メイリオ", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(196, Byte), Integer), CType(CType(15, Byte), Integer), CType(CType(57, Byte), Integer))
		Me.Label2.Location = New System.Drawing.Point(248, 112)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(153, 41)
		Me.Label2.TabIndex = 4
		Me.Label2.Text = "支援ツール"
		'
		'btnOperation
		'
		Me.btnOperation.Font = New System.Drawing.Font("Meiryo UI", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.btnOperation.Location = New System.Drawing.Point(199, 156)
		Me.btnOperation.Name = "btnOperation"
		Me.btnOperation.Size = New System.Drawing.Size(250, 50)
		Me.btnOperation.TabIndex = 5
		Me.btnOperation.Text = "運　用　画　面"
		Me.btnOperation.UseVisualStyleBackColor = True
		'
		'btnMaintenance
		'
		Me.btnMaintenance.Font = New System.Drawing.Font("Meiryo UI", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.btnMaintenance.Location = New System.Drawing.Point(199, 212)
		Me.btnMaintenance.Name = "btnMaintenance"
		Me.btnMaintenance.Size = New System.Drawing.Size(250, 50)
		Me.btnMaintenance.TabIndex = 6
		Me.btnMaintenance.Text = "各種メンテナンス"
		Me.btnMaintenance.UseVisualStyleBackColor = True
		'
		'MenuStrip1
		'
		Me.MenuStrip1.BackColor = System.Drawing.Color.White
		Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ファイルFToolStripMenuItem, Me.ツールTToolStripMenuItem})
		Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
		Me.MenuStrip1.Name = "MenuStrip1"
		Me.MenuStrip1.Size = New System.Drawing.Size(461, 24)
		Me.MenuStrip1.TabIndex = 7
		Me.MenuStrip1.Text = "MenuStrip1"
		'
		'ファイルFToolStripMenuItem
		'
		Me.ファイルFToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuExit})
		Me.ファイルFToolStripMenuItem.Name = "ファイルFToolStripMenuItem"
		Me.ファイルFToolStripMenuItem.Size = New System.Drawing.Size(66, 20)
		Me.ファイルFToolStripMenuItem.Text = "ファイル(&F)"
		'
		'menuExit
		'
		Me.menuExit.Name = "menuExit"
		Me.menuExit.Size = New System.Drawing.Size(113, 22)
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
		Me.menuConnection.Size = New System.Drawing.Size(137, 22)
		Me.menuConnection.Text = "接続設定(&C)"
		'
		'btnExit
		'
		Me.btnExit.Font = New System.Drawing.Font("Meiryo UI", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.btnExit.Location = New System.Drawing.Point(199, 268)
		Me.btnExit.Name = "btnExit"
		Me.btnExit.Size = New System.Drawing.Size(250, 50)
		Me.btnExit.TabIndex = 8
		Me.btnExit.Text = "終　了"
		Me.btnExit.UseVisualStyleBackColor = True
		'
		'PictureBox1
		'
		Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
		Me.PictureBox1.InitialImage = Nothing
		Me.PictureBox1.Location = New System.Drawing.Point(12, 27)
		Me.PictureBox1.Name = "PictureBox1"
		Me.PictureBox1.Size = New System.Drawing.Size(176, 160)
		Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
		Me.PictureBox1.TabIndex = 9
		Me.PictureBox1.TabStop = False
		'
		'frmMainMenu
		'
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
		Me.BackColor = System.Drawing.SystemColors.Window
		Me.CaptionDisplayMode = JPHealth.frmTempForm.StatusDisplayMode.ShowAll
		Me.ClientSize = New System.Drawing.Size(461, 331)
		Me.Controls.Add(Me.btnExit)
		Me.Controls.Add(Me.btnMaintenance)
		Me.Controls.Add(Me.btnOperation)
		Me.Controls.Add(Me.Label2)
		Me.Controls.Add(Me.Label3)
		Me.Controls.Add(Me.Label1)
		Me.Controls.Add(Me.MenuStrip1)
		Me.Controls.Add(Me.PictureBox1)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.KeyPreview = True
		Me.MainMenuStrip = Me.MenuStrip1
		Me.MaximizeBox = False
		Me.Name = "frmMainMenu"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "frmMainMenu"
		Me.Controls.SetChildIndex(Me.PictureBox1, 0)
		Me.Controls.SetChildIndex(Me.MenuStrip1, 0)
		Me.Controls.SetChildIndex(Me.Label1, 0)
		Me.Controls.SetChildIndex(Me.Label3, 0)
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

	Friend WithEvents Label1 As Label
	Friend WithEvents Label3 As Label
	Friend WithEvents Label2 As Label
	Friend WithEvents btnOperation As Button
	Friend WithEvents btnMaintenance As Button
	Friend WithEvents MenuStrip1 As MenuStrip
	Friend WithEvents ファイルFToolStripMenuItem As ToolStripMenuItem
	Friend WithEvents menuExit As ToolStripMenuItem
	Friend WithEvents ツールTToolStripMenuItem As ToolStripMenuItem
	Friend WithEvents menuConnection As ToolStripMenuItem
	Friend WithEvents btnExit As Button
	Friend WithEvents PictureBox1 As PictureBox
End Class
