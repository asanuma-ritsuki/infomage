﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
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
		Me.btnClear = New System.Windows.Forms.Button()
		Me.Panel1 = New System.Windows.Forms.Panel()
		Me.Panel1.SuspendLayout()
		Me.SuspendLayout()
		'
		'txtPage
		'
		Me.txtPage.Location = New System.Drawing.Point(3, 3)
		Me.txtPage.Name = "txtPage"
		Me.txtPage.Size = New System.Drawing.Size(100, 19)
		Me.txtPage.TabIndex = 0
		'
		'btnMove
		'
		Me.btnMove.Location = New System.Drawing.Point(109, 1)
		Me.btnMove.Name = "btnMove"
		Me.btnMove.Size = New System.Drawing.Size(75, 23)
		Me.btnMove.TabIndex = 1
		Me.btnMove.Text = "ページ移動"
		Me.btnMove.UseVisualStyleBackColor = True
		'
		'WebBrowser1
		'
		Me.WebBrowser1.Dock = System.Windows.Forms.DockStyle.Fill
		Me.WebBrowser1.Location = New System.Drawing.Point(0, 28)
		Me.WebBrowser1.MinimumSize = New System.Drawing.Size(20, 20)
		Me.WebBrowser1.Name = "WebBrowser1"
		Me.WebBrowser1.Size = New System.Drawing.Size(1008, 701)
		Me.WebBrowser1.TabIndex = 2
		'
		'btnClear
		'
		Me.btnClear.Location = New System.Drawing.Point(190, 1)
		Me.btnClear.Name = "btnClear"
		Me.btnClear.Size = New System.Drawing.Size(75, 23)
		Me.btnClear.TabIndex = 3
		Me.btnClear.Text = "クリア"
		Me.btnClear.UseVisualStyleBackColor = True
		'
		'Panel1
		'
		Me.Panel1.Controls.Add(Me.txtPage)
		Me.Panel1.Controls.Add(Me.btnClear)
		Me.Panel1.Controls.Add(Me.btnMove)
		Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
		Me.Panel1.Location = New System.Drawing.Point(0, 0)
		Me.Panel1.Name = "Panel1"
		Me.Panel1.Size = New System.Drawing.Size(1008, 28)
		Me.Panel1.TabIndex = 4
		'
		'Form1
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(1008, 729)
		Me.Controls.Add(Me.WebBrowser1)
		Me.Controls.Add(Me.Panel1)
		Me.Name = "Form1"
		Me.Text = "Form1"
		Me.Panel1.ResumeLayout(False)
		Me.Panel1.PerformLayout()
		Me.ResumeLayout(False)

	End Sub

	Friend WithEvents txtPage As TextBox
	Friend WithEvents btnMove As Button
	Friend WithEvents WebBrowser1 As WebBrowser
	Friend WithEvents btnClear As Button
	Friend WithEvents Panel1 As Panel
End Class
