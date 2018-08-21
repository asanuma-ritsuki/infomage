<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmConnectionProperty
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConnectionProperty))
		Me.C1Label1 = New C1.Win.C1Input.C1Label()
		Me.txtAccessFile = New C1.Win.C1Input.C1TextBox()
		Me.btnOK = New C1.Win.C1Input.C1Button()
		Me.btnCancel = New C1.Win.C1Input.C1Button()
		CType(Me.C1Label1, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.txtAccessFile, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.btnOK, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.btnCancel, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'C1Label1
		'
		Me.C1Label1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.C1Label1.Location = New System.Drawing.Point(12, 15)
		Me.C1Label1.Name = "C1Label1"
		Me.C1Label1.Size = New System.Drawing.Size(108, 25)
		Me.C1Label1.TabIndex = 0
		Me.C1Label1.Tag = Nothing
		Me.C1Label1.Text = "Accessファイル："
		Me.C1Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.C1Label1.TextDetached = True
		Me.C1Label1.Value = "Accessファイル："
		'
		'txtAccessFile
		'
		Me.txtAccessFile.AllowDrop = True
		Me.txtAccessFile.AutoSize = False
		Me.txtAccessFile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.txtAccessFile.Location = New System.Drawing.Point(126, 17)
		Me.txtAccessFile.Name = "txtAccessFile"
		Me.txtAccessFile.Size = New System.Drawing.Size(335, 25)
		Me.txtAccessFile.TabIndex = 1
		Me.txtAccessFile.Tag = Nothing
		Me.txtAccessFile.TextDetached = True
		Me.txtAccessFile.VerticalAlign = C1.Win.C1Input.VerticalAlignEnum.Middle
		'
		'btnOK
		'
		Me.btnOK.Location = New System.Drawing.Point(386, 50)
		Me.btnOK.Name = "btnOK"
		Me.btnOK.Size = New System.Drawing.Size(75, 25)
		Me.btnOK.TabIndex = 2
		Me.btnOK.Text = "適　用"
		Me.btnOK.UseVisualStyleBackColor = True
		'
		'btnCancel
		'
		Me.btnCancel.Location = New System.Drawing.Point(305, 50)
		Me.btnCancel.Name = "btnCancel"
		Me.btnCancel.Size = New System.Drawing.Size(75, 25)
		Me.btnCancel.TabIndex = 3
		Me.btnCancel.Text = "キャンセル"
		Me.btnCancel.UseVisualStyleBackColor = True
		'
		'frmConnectionProperty
		'
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
		Me.ClientSize = New System.Drawing.Size(473, 87)
		Me.Controls.Add(Me.btnCancel)
		Me.Controls.Add(Me.btnOK)
		Me.Controls.Add(Me.txtAccessFile)
		Me.Controls.Add(Me.C1Label1)
		Me.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
		Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
		Me.Name = "frmConnectionProperty"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "frmConnectionProperty"
		CType(Me.C1Label1, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.txtAccessFile, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.btnOK, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.btnCancel, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)

	End Sub

	Friend WithEvents C1Label1 As C1.Win.C1Input.C1Label
	Friend WithEvents txtAccessFile As C1.Win.C1Input.C1TextBox
	Friend WithEvents btnOK As C1.Win.C1Input.C1Button
	Friend WithEvents btnCancel As C1.Win.C1Input.C1Button
End Class
