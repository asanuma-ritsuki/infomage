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
		Me.C1MainMenu1 = New C1.Win.C1Command.C1MainMenu()
		Me.C1CommandHolder1 = New C1.Win.C1Command.C1CommandHolder()
		Me.c1CommandMenu1 = New C1.Win.C1Command.C1CommandMenu()
		Me.C1CommandLink3 = New C1.Win.C1Command.C1CommandLink()
		Me.menuExit = New C1.Win.C1Command.C1Command()
		Me.C1CommandMenu2 = New C1.Win.C1Command.C1CommandMenu()
		Me.C1CommandLink5 = New C1.Win.C1Command.C1CommandLink()
		Me.menuConnection = New C1.Win.C1Command.C1Command()
		Me.C1CommandLink1 = New C1.Win.C1Command.C1CommandLink()
		Me.C1CommandLink4 = New C1.Win.C1Command.C1CommandLink()
		Me.PictureBox1 = New System.Windows.Forms.PictureBox()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.Label3 = New System.Windows.Forms.Label()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.btnExit = New System.Windows.Forms.Button()
		Me.btnMaintenance = New System.Windows.Forms.Button()
		Me.btnOperation = New System.Windows.Forms.Button()
		CType(Me.C1CommandHolder1, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'C1MainMenu1
		'
		Me.C1MainMenu1.CommandHolder = Me.C1CommandHolder1
		Me.C1MainMenu1.CommandLinks.AddRange(New C1.Win.C1Command.C1CommandLink() {Me.C1CommandLink1, Me.C1CommandLink4})
		Me.C1MainMenu1.Dock = System.Windows.Forms.DockStyle.Top
		Me.C1MainMenu1.Location = New System.Drawing.Point(0, 0)
		Me.C1MainMenu1.Name = "C1MainMenu1"
		Me.C1MainMenu1.Size = New System.Drawing.Size(469, 27)
		Me.C1MainMenu1.VisualStyleBase = C1.Win.C1Command.VisualStyle.Office2010Black
		'
		'C1CommandHolder1
		'
		Me.C1CommandHolder1.Commands.Add(Me.c1CommandMenu1)
		Me.C1CommandHolder1.Commands.Add(Me.menuExit)
		Me.C1CommandHolder1.Commands.Add(Me.C1CommandMenu2)
		Me.C1CommandHolder1.Commands.Add(Me.menuConnection)
		Me.C1CommandHolder1.Owner = Me
		'
		'c1CommandMenu1
		'
		Me.c1CommandMenu1.CommandLinks.AddRange(New C1.Win.C1Command.C1CommandLink() {Me.C1CommandLink3})
		Me.c1CommandMenu1.HideNonRecentLinks = False
		Me.c1CommandMenu1.Name = "c1CommandMenu1"
		Me.c1CommandMenu1.ShortcutText = ""
		Me.c1CommandMenu1.Text = "ファイル(&F)"
		Me.c1CommandMenu1.VisualStyle = C1.Win.C1Command.VisualStyle.Office2010Black
		Me.c1CommandMenu1.VisualStyleBase = C1.Win.C1Command.VisualStyle.Office2010Black
		'
		'C1CommandLink3
		'
		Me.C1CommandLink3.Command = Me.menuExit
		'
		'menuExit
		'
		Me.menuExit.Name = "menuExit"
		Me.menuExit.ShortcutText = ""
		Me.menuExit.Text = "終了(&X)"
		'
		'C1CommandMenu2
		'
		Me.C1CommandMenu2.CommandLinks.AddRange(New C1.Win.C1Command.C1CommandLink() {Me.C1CommandLink5})
		Me.C1CommandMenu2.HideNonRecentLinks = False
		Me.C1CommandMenu2.Name = "C1CommandMenu2"
		Me.C1CommandMenu2.ShortcutText = ""
		Me.C1CommandMenu2.Text = "ツール(&T)"
		Me.C1CommandMenu2.VisualStyle = C1.Win.C1Command.VisualStyle.Office2010Black
		Me.C1CommandMenu2.VisualStyleBase = C1.Win.C1Command.VisualStyle.Office2010Black
		'
		'C1CommandLink5
		'
		Me.C1CommandLink5.Command = Me.menuConnection
		'
		'menuConnection
		'
		Me.menuConnection.Name = "menuConnection"
		Me.menuConnection.ShortcutText = ""
		Me.menuConnection.Text = "接続設定(&C)"
		'
		'C1CommandLink1
		'
		Me.C1CommandLink1.Command = Me.c1CommandMenu1
		'
		'C1CommandLink4
		'
		Me.C1CommandLink4.Command = Me.C1CommandMenu2
		Me.C1CommandLink4.SortOrder = 1
		'
		'PictureBox1
		'
		Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
		Me.PictureBox1.InitialImage = Nothing
		Me.PictureBox1.Location = New System.Drawing.Point(12, 74)
		Me.PictureBox1.Name = "PictureBox1"
		Me.PictureBox1.Size = New System.Drawing.Size(176, 160)
		Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
		Me.PictureBox1.TabIndex = 10
		Me.PictureBox1.TabStop = False
		'
		'Label2
		'
		Me.Label2.AutoSize = True
		Me.Label2.Font = New System.Drawing.Font("メイリオ", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.Label2.ForeColor = System.Drawing.Color.White
		Me.Label2.Location = New System.Drawing.Point(224, 115)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(207, 41)
		Me.Label2.TabIndex = 13
		Me.Label2.Text = "チェックツール"
		'
		'Label3
		'
		Me.Label3.AutoSize = True
		Me.Label3.Font = New System.Drawing.Font("メイリオ", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.Label3.ForeColor = System.Drawing.Color.White
		Me.Label3.Location = New System.Drawing.Point(210, 74)
		Me.Label3.Name = "Label3"
		Me.Label3.Size = New System.Drawing.Size(234, 41)
		Me.Label3.TabIndex = 12
		Me.Label3.Text = "人事情報更新作業"
		'
		'Label1
		'
		Me.Label1.AutoSize = True
		Me.Label1.Font = New System.Drawing.Font("メイリオ", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.Label1.ForeColor = System.Drawing.Color.White
		Me.Label1.Location = New System.Drawing.Point(264, 33)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(126, 41)
		Me.Label1.TabIndex = 11
		Me.Label1.Text = "三井倉庫"
		'
		'btnExit
		'
		Me.btnExit.Font = New System.Drawing.Font("Meiryo UI", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.btnExit.Location = New System.Drawing.Point(207, 277)
		Me.btnExit.Name = "btnExit"
		Me.btnExit.Size = New System.Drawing.Size(250, 50)
		Me.btnExit.TabIndex = 16
		Me.btnExit.Text = "終　了"
		Me.btnExit.UseVisualStyleBackColor = True
		'
		'btnMaintenance
		'
		Me.btnMaintenance.Font = New System.Drawing.Font("Meiryo UI", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.btnMaintenance.Location = New System.Drawing.Point(207, 221)
		Me.btnMaintenance.Name = "btnMaintenance"
		Me.btnMaintenance.Size = New System.Drawing.Size(250, 50)
		Me.btnMaintenance.TabIndex = 15
		Me.btnMaintenance.Text = "各種メンテナンス"
		Me.btnMaintenance.UseVisualStyleBackColor = True
		'
		'btnOperation
		'
		Me.btnOperation.Font = New System.Drawing.Font("Meiryo UI", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.btnOperation.Location = New System.Drawing.Point(207, 165)
		Me.btnOperation.Name = "btnOperation"
		Me.btnOperation.Size = New System.Drawing.Size(250, 50)
		Me.btnOperation.TabIndex = 14
		Me.btnOperation.Text = "運　用　画　面"
		Me.btnOperation.UseVisualStyleBackColor = True
		'
		'frmMainMenu
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 17.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(469, 339)
		Me.Controls.Add(Me.btnExit)
		Me.Controls.Add(Me.btnMaintenance)
		Me.Controls.Add(Me.btnOperation)
		Me.Controls.Add(Me.Label2)
		Me.Controls.Add(Me.Label3)
		Me.Controls.Add(Me.Label1)
		Me.Controls.Add(Me.PictureBox1)
		Me.Controls.Add(Me.C1MainMenu1)
		Me.Name = "frmMainMenu"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "frmMainMenu"
		Me.Controls.SetChildIndex(Me.C1MainMenu1, 0)
		Me.Controls.SetChildIndex(Me.PictureBox1, 0)
		Me.Controls.SetChildIndex(Me.Label1, 0)
		Me.Controls.SetChildIndex(Me.Label3, 0)
		Me.Controls.SetChildIndex(Me.Label2, 0)
		Me.Controls.SetChildIndex(Me.btnOperation, 0)
		Me.Controls.SetChildIndex(Me.btnMaintenance, 0)
		Me.Controls.SetChildIndex(Me.btnExit, 0)
		CType(Me.C1CommandHolder1, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	Friend WithEvents C1MainMenu1 As C1.Win.C1Command.C1MainMenu
	Friend WithEvents C1CommandHolder1 As C1.Win.C1Command.C1CommandHolder
	Friend WithEvents c1CommandMenu1 As C1.Win.C1Command.C1CommandMenu
	Friend WithEvents C1CommandLink3 As C1.Win.C1Command.C1CommandLink
	Friend WithEvents menuExit As C1.Win.C1Command.C1Command
	Friend WithEvents C1CommandMenu2 As C1.Win.C1Command.C1CommandMenu
	Friend WithEvents C1CommandLink5 As C1.Win.C1Command.C1CommandLink
	Friend WithEvents menuConnection As C1.Win.C1Command.C1Command
	Friend WithEvents btnExit As Button
	Friend WithEvents btnMaintenance As Button
	Friend WithEvents btnOperation As Button
	Friend WithEvents Label2 As Label
	Friend WithEvents Label3 As Label
	Friend WithEvents Label1 As Label
	Friend WithEvents PictureBox1 As PictureBox
	Friend WithEvents C1CommandLink1 As C1.Win.C1Command.C1CommandLink
	Friend WithEvents C1CommandLink4 As C1.Win.C1Command.C1CommandLink
End Class
