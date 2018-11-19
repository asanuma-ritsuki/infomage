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
		Me.txtTarget = New System.Windows.Forms.TextBox()
		Me.txt16Code = New System.Windows.Forms.TextBox()
		Me.btnRun = New System.Windows.Forms.Button()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.txt10Code = New System.Windows.Forms.TextBox()
		Me.Label3 = New System.Windows.Forms.Label()
		Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
		Me.Label4 = New System.Windows.Forms.Label()
		Me.Label5 = New System.Windows.Forms.Label()
		Me.Label6 = New System.Windows.Forms.Label()
		Me.Label7 = New System.Windows.Forms.Label()
		Me.Label8 = New System.Windows.Forms.Label()
		Me.Label9 = New System.Windows.Forms.Label()
		Me.txtResult = New System.Windows.Forms.TextBox()
		Me.SuspendLayout()
		'
		'txtTarget
		'
		Me.txtTarget.Font = New System.Drawing.Font("Meiryo UI", 48.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.txtTarget.Location = New System.Drawing.Point(16, 64)
		Me.txtTarget.Margin = New System.Windows.Forms.Padding(4)
		Me.txtTarget.Name = "txtTarget"
		Me.txtTarget.Size = New System.Drawing.Size(89, 89)
		Me.txtTarget.TabIndex = 0
		'
		'txt16Code
		'
		Me.txt16Code.Location = New System.Drawing.Point(264, 188)
		Me.txt16Code.Name = "txt16Code"
		Me.txt16Code.Size = New System.Drawing.Size(100, 24)
		Me.txt16Code.TabIndex = 1
		'
		'btnRun
		'
		Me.btnRun.Location = New System.Drawing.Point(370, 188)
		Me.btnRun.Name = "btnRun"
		Me.btnRun.Size = New System.Drawing.Size(75, 25)
		Me.btnRun.TabIndex = 2
		Me.btnRun.Text = "実　行"
		Me.btnRun.UseVisualStyleBackColor = True
		'
		'Label1
		'
		Me.Label1.AutoSize = True
		Me.Label1.Location = New System.Drawing.Point(195, 192)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(63, 17)
		Me.Label1.TabIndex = 3
		Me.Label1.Text = "16進数："
		Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'Label2
		'
		Me.Label2.AutoSize = True
		Me.Label2.Location = New System.Drawing.Point(159, 238)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(99, 17)
		Me.Label2.TabIndex = 5
		Me.Label2.Text = "10進数に変換："
		Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'txt10Code
		'
		Me.txt10Code.Location = New System.Drawing.Point(264, 235)
		Me.txt10Code.Name = "txt10Code"
		Me.txt10Code.Size = New System.Drawing.Size(100, 24)
		Me.txt10Code.TabIndex = 4
		'
		'Label3
		'
		Me.Label3.AutoSize = True
		Me.Label3.Location = New System.Drawing.Point(303, 215)
		Me.Label3.Name = "Label3"
		Me.Label3.Size = New System.Drawing.Size(21, 17)
		Me.Label3.TabIndex = 6
		Me.Label3.Text = "↓"
		'
		'RichTextBox1
		'
		Me.RichTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.RichTextBox1.Location = New System.Drawing.Point(112, 17)
		Me.RichTextBox1.Name = "RichTextBox1"
		Me.RichTextBox1.Size = New System.Drawing.Size(500, 29)
		Me.RichTextBox1.TabIndex = 7
		Me.RichTextBox1.Text = "https://www.eonet.ne.jp/~kotobukispace/ddt/jisx0213/sjis8xxx.html"
		Me.RichTextBox1.WordWrap = False
		'
		'Label4
		'
		Me.Label4.AutoSize = True
		Me.Label4.Location = New System.Drawing.Point(112, 59)
		Me.Label4.Name = "Label4"
		Me.Label4.Size = New System.Drawing.Size(236, 17)
		Me.Label4.TabIndex = 8
		Me.Label4.Text = "第1水準の範囲：8140～9872(16進数)"
		'
		'Label5
		'
		Me.Label5.AutoSize = True
		Me.Label5.Location = New System.Drawing.Point(112, 83)
		Me.Label5.Name = "Label5"
		Me.Label5.Size = New System.Drawing.Size(252, 17)
		Me.Label5.TabIndex = 9
		Me.Label5.Text = "第1水準の範囲：33088～39026(10進数)"
		'
		'Label6
		'
		Me.Label6.AutoSize = True
		Me.Label6.Location = New System.Drawing.Point(112, 136)
		Me.Label6.Name = "Label6"
		Me.Label6.Size = New System.Drawing.Size(252, 17)
		Me.Label6.TabIndex = 11
		Me.Label6.Text = "第2水準の範囲：39071～60068(10進数)"
		'
		'Label7
		'
		Me.Label7.AutoSize = True
		Me.Label7.Location = New System.Drawing.Point(112, 112)
		Me.Label7.Name = "Label7"
		Me.Label7.Size = New System.Drawing.Size(237, 17)
		Me.Label7.TabIndex = 10
		Me.Label7.Text = "第2水準の範囲：989F～EAA4(16進数)"
		'
		'Label8
		'
		Me.Label8.AutoSize = True
		Me.Label8.Location = New System.Drawing.Point(303, 262)
		Me.Label8.Name = "Label8"
		Me.Label8.Size = New System.Drawing.Size(21, 17)
		Me.Label8.TabIndex = 14
		Me.Label8.Text = "↓"
		'
		'Label9
		'
		Me.Label9.AutoSize = True
		Me.Label9.Location = New System.Drawing.Point(58, 285)
		Me.Label9.Name = "Label9"
		Me.Label9.Size = New System.Drawing.Size(200, 17)
		Me.Label9.TabIndex = 13
		Me.Label9.Text = "10進数の範囲によって水準を判断："
		Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'txtResult
		'
		Me.txtResult.Location = New System.Drawing.Point(264, 282)
		Me.txtResult.Name = "txtResult"
		Me.txtResult.Size = New System.Drawing.Size(100, 24)
		Me.txtResult.TabIndex = 12
		'
		'Form1
		'
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
		Me.ClientSize = New System.Drawing.Size(624, 441)
		Me.Controls.Add(Me.Label8)
		Me.Controls.Add(Me.Label9)
		Me.Controls.Add(Me.txtResult)
		Me.Controls.Add(Me.Label6)
		Me.Controls.Add(Me.Label7)
		Me.Controls.Add(Me.Label5)
		Me.Controls.Add(Me.Label4)
		Me.Controls.Add(Me.RichTextBox1)
		Me.Controls.Add(Me.Label3)
		Me.Controls.Add(Me.Label2)
		Me.Controls.Add(Me.txt10Code)
		Me.Controls.Add(Me.Label1)
		Me.Controls.Add(Me.btnRun)
		Me.Controls.Add(Me.txt16Code)
		Me.Controls.Add(Me.txtTarget)
		Me.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.Margin = New System.Windows.Forms.Padding(4)
		Me.Name = "Form1"
		Me.Text = "Form1"
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	Friend WithEvents txtTarget As TextBox
	Friend WithEvents txt16Code As TextBox
	Friend WithEvents btnRun As Button
	Friend WithEvents Label1 As Label
	Friend WithEvents Label2 As Label
	Friend WithEvents txt10Code As TextBox
	Friend WithEvents Label3 As Label
	Friend WithEvents RichTextBox1 As RichTextBox
	Friend WithEvents Label4 As Label
	Friend WithEvents Label5 As Label
	Friend WithEvents Label6 As Label
	Friend WithEvents Label7 As Label
	Friend WithEvents Label8 As Label
	Friend WithEvents Label9 As Label
	Friend WithEvents txtResult As TextBox
End Class
