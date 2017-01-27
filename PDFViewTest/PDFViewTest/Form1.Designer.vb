<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
	Inherits System.Windows.Forms.Form

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
		Me.txtPage = New System.Windows.Forms.TextBox()
		Me.btnMove = New System.Windows.Forms.Button()
		Me.WebBrowser1 = New System.Windows.Forms.WebBrowser()
		Me.SuspendLayout()
		'
		'txtPage
		'
		Me.txtPage.Location = New System.Drawing.Point(12, 12)
		Me.txtPage.Name = "txtPage"
		Me.txtPage.Size = New System.Drawing.Size(100, 19)
		Me.txtPage.TabIndex = 0
		'
		'btnMove
		'
		Me.btnMove.Location = New System.Drawing.Point(118, 10)
		Me.btnMove.Name = "btnMove"
		Me.btnMove.Size = New System.Drawing.Size(75, 23)
		Me.btnMove.TabIndex = 1
		Me.btnMove.Text = "ページ移動"
		Me.btnMove.UseVisualStyleBackColor = True
		'
		'WebBrowser1
		'
		Me.WebBrowser1.Location = New System.Drawing.Point(12, 39)
		Me.WebBrowser1.MinimumSize = New System.Drawing.Size(20, 20)
		Me.WebBrowser1.Name = "WebBrowser1"
		Me.WebBrowser1.Size = New System.Drawing.Size(984, 678)
		Me.WebBrowser1.TabIndex = 2
		'
		'Form1
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(1008, 729)
		Me.Controls.Add(Me.WebBrowser1)
		Me.Controls.Add(Me.btnMove)
		Me.Controls.Add(Me.txtPage)
		Me.Name = "Form1"
		Me.Text = "Form1"
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	Friend WithEvents txtPage As TextBox
	Friend WithEvents btnMove As Button
	Friend WithEvents WebBrowser1 As WebBrowser
End Class
