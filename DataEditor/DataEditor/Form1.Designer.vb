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
		Me.GroupBox1 = New System.Windows.Forms.GroupBox()
		Me.GroupBox2 = New System.Windows.Forms.GroupBox()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.txtEntryData = New System.Windows.Forms.TextBox()
		Me.Label3 = New System.Windows.Forms.Label()
		Me.txtShubetsuData = New System.Windows.Forms.TextBox()
		Me.Label4 = New System.Windows.Forms.Label()
		Me.txtOutFolder = New System.Windows.Forms.TextBox()
		Me.btnRun = New System.Windows.Forms.Button()
		Me.GroupBox1.SuspendLayout()
		Me.GroupBox2.SuspendLayout()
		Me.SuspendLayout()
		'
		'GroupBox1
		'
		Me.GroupBox1.Controls.Add(Me.GroupBox2)
		Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
		Me.GroupBox1.Name = "GroupBox1"
		Me.GroupBox1.Size = New System.Drawing.Size(750, 363)
		Me.GroupBox1.TabIndex = 0
		Me.GroupBox1.TabStop = False
		Me.GroupBox1.Text = "警視庁データ精査"
		'
		'GroupBox2
		'
		Me.GroupBox2.Controls.Add(Me.btnRun)
		Me.GroupBox2.Controls.Add(Me.Label4)
		Me.GroupBox2.Controls.Add(Me.txtOutFolder)
		Me.GroupBox2.Controls.Add(Me.Label3)
		Me.GroupBox2.Controls.Add(Me.txtShubetsuData)
		Me.GroupBox2.Controls.Add(Me.Label2)
		Me.GroupBox2.Controls.Add(Me.txtEntryData)
		Me.GroupBox2.Location = New System.Drawing.Point(6, 23)
		Me.GroupBox2.Name = "GroupBox2"
		Me.GroupBox2.Size = New System.Drawing.Size(738, 117)
		Me.GroupBox2.TabIndex = 0
		Me.GroupBox2.TabStop = False
		Me.GroupBox2.Text = "種別特定"
		'
		'Label2
		'
		Me.Label2.Location = New System.Drawing.Point(6, 23)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(100, 24)
		Me.Label2.TabIndex = 3
		Me.Label2.Text = "エントリーデータ："
		Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'txtEntryData
		'
		Me.txtEntryData.Location = New System.Drawing.Point(112, 23)
		Me.txtEntryData.Name = "txtEntryData"
		Me.txtEntryData.Size = New System.Drawing.Size(539, 24)
		Me.txtEntryData.TabIndex = 2
		Me.txtEntryData.Text = "C:\開発\20190207_警視庁データ精査\01_エントリーデータ.txt"
		'
		'Label3
		'
		Me.Label3.Location = New System.Drawing.Point(6, 53)
		Me.Label3.Name = "Label3"
		Me.Label3.Size = New System.Drawing.Size(100, 24)
		Me.Label3.TabIndex = 5
		Me.Label3.Text = "種別データ："
		Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'txtShubetsuData
		'
		Me.txtShubetsuData.Location = New System.Drawing.Point(112, 53)
		Me.txtShubetsuData.Name = "txtShubetsuData"
		Me.txtShubetsuData.Size = New System.Drawing.Size(539, 24)
		Me.txtShubetsuData.TabIndex = 4
		Me.txtShubetsuData.Text = "C:\開発\20190207_警視庁データ精査\02_種別データ.txt"
		'
		'Label4
		'
		Me.Label4.Location = New System.Drawing.Point(6, 83)
		Me.Label4.Name = "Label4"
		Me.Label4.Size = New System.Drawing.Size(100, 24)
		Me.Label4.TabIndex = 8
		Me.Label4.Text = "出力フォルダ："
		Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'txtOutFolder
		'
		Me.txtOutFolder.Location = New System.Drawing.Point(112, 83)
		Me.txtOutFolder.Name = "txtOutFolder"
		Me.txtOutFolder.Size = New System.Drawing.Size(539, 24)
		Me.txtOutFolder.TabIndex = 7
		Me.txtOutFolder.Text = "C:\開発\20190207_警視庁データ精査"
		'
		'btnRun
		'
		Me.btnRun.Location = New System.Drawing.Point(657, 82)
		Me.btnRun.Name = "btnRun"
		Me.btnRun.Size = New System.Drawing.Size(75, 25)
		Me.btnRun.TabIndex = 9
		Me.btnRun.Text = "実　行"
		Me.btnRun.UseVisualStyleBackColor = True
		'
		'Form1
		'
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
		Me.ClientSize = New System.Drawing.Size(784, 561)
		Me.Controls.Add(Me.GroupBox1)
		Me.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.Name = "Form1"
		Me.Text = "Form1"
		Me.GroupBox1.ResumeLayout(False)
		Me.GroupBox2.ResumeLayout(False)
		Me.GroupBox2.PerformLayout()
		Me.ResumeLayout(False)

	End Sub

	Friend WithEvents GroupBox1 As GroupBox
	Friend WithEvents GroupBox2 As GroupBox
	Friend WithEvents btnRun As Button
	Friend WithEvents Label4 As Label
	Friend WithEvents txtOutFolder As TextBox
	Friend WithEvents Label3 As Label
	Friend WithEvents txtShubetsuData As TextBox
	Friend WithEvents Label2 As Label
	Friend WithEvents txtEntryData As TextBox
End Class
