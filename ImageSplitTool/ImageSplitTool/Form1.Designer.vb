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
        Me.numCropY = New System.Windows.Forms.NumericUpDown()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.numCropX = New System.Windows.Forms.NumericUpDown()
        Me.lstResult = New System.Windows.Forms.ListBox()
        Me.lblProgress = New System.Windows.Forms.Label()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbExt = New System.Windows.Forms.ComboBox()
        Me.btnStart = New System.Windows.Forms.Button()
        Me.btnSaveBrowse = New System.Windows.Forms.Button()
        Me.btnTargetBrowse = New System.Windows.Forms.Button()
        Me.txtSaveFolder = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtTargetFolder = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        CType(Me.numCropY, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numCropX, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.numCropY)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.numCropX)
        Me.GroupBox1.Controls.Add(Me.lstResult)
        Me.GroupBox1.Controls.Add(Me.lblProgress)
        Me.GroupBox1.Controls.Add(Me.ProgressBar1)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.cmbExt)
        Me.GroupBox1.Controls.Add(Me.btnStart)
        Me.GroupBox1.Controls.Add(Me.btnSaveBrowse)
        Me.GroupBox1.Controls.Add(Me.btnTargetBrowse)
        Me.GroupBox1.Controls.Add(Me.txtSaveFolder)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtTargetFolder)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(760, 537)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "画像分割"
        '
        'numCropY
        '
        Me.numCropY.Location = New System.Drawing.Point(180, 114)
        Me.numCropY.Maximum = New Decimal(New Integer() {99999, 0, 0, 0})
        Me.numCropY.Name = "numCropY"
        Me.numCropY.Size = New System.Drawing.Size(71, 24)
        Me.numCropY.TabIndex = 14
        Me.numCropY.Value = New Decimal(New Integer() {6614, 0, 0, 0})
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(9, 116)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(88, 17)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "クロップサイズ："
        '
        'numCropX
        '
        Me.numCropX.Location = New System.Drawing.Point(103, 114)
        Me.numCropX.Maximum = New Decimal(New Integer() {99999, 0, 0, 0})
        Me.numCropX.Name = "numCropX"
        Me.numCropX.Size = New System.Drawing.Size(71, 24)
        Me.numCropX.TabIndex = 12
        Me.numCropX.Value = New Decimal(New Integer() {9354, 0, 0, 0})
        '
        'lstResult
        '
        Me.lstResult.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lstResult.FormattingEnabled = True
        Me.lstResult.ItemHeight = 17
        Me.lstResult.Location = New System.Drawing.Point(3, 156)
        Me.lstResult.Name = "lstResult"
        Me.lstResult.Size = New System.Drawing.Size(754, 378)
        Me.lstResult.TabIndex = 11
        '
        'lblProgress
        '
        Me.lblProgress.Location = New System.Drawing.Point(553, 84)
        Me.lblProgress.Name = "lblProgress"
        Me.lblProgress.Size = New System.Drawing.Size(120, 24)
        Me.lblProgress.TabIndex = 10
        Me.lblProgress.Text = "99999 / 99999"
        Me.lblProgress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(180, 84)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(367, 24)
        Me.ProgressBar1.TabIndex = 9
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(20, 87)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(77, 17)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "フォーマット："
        '
        'cmbExt
        '
        Me.cmbExt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbExt.FormattingEnabled = True
        Me.cmbExt.Items.AddRange(New Object() {"*.tif"})
        Me.cmbExt.Location = New System.Drawing.Point(103, 83)
        Me.cmbExt.Name = "cmbExt"
        Me.cmbExt.Size = New System.Drawing.Size(71, 25)
        Me.cmbExt.TabIndex = 7
        '
        'btnStart
        '
        Me.btnStart.Location = New System.Drawing.Point(679, 83)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(75, 25)
        Me.btnStart.TabIndex = 6
        Me.btnStart.Text = "開　始"
        Me.btnStart.UseVisualStyleBackColor = True
        '
        'btnSaveBrowse
        '
        Me.btnSaveBrowse.Location = New System.Drawing.Point(722, 53)
        Me.btnSaveBrowse.Name = "btnSaveBrowse"
        Me.btnSaveBrowse.Size = New System.Drawing.Size(32, 24)
        Me.btnSaveBrowse.TabIndex = 5
        Me.btnSaveBrowse.Text = "..."
        Me.btnSaveBrowse.UseVisualStyleBackColor = True
        '
        'btnTargetBrowse
        '
        Me.btnTargetBrowse.Location = New System.Drawing.Point(722, 23)
        Me.btnTargetBrowse.Name = "btnTargetBrowse"
        Me.btnTargetBrowse.Size = New System.Drawing.Size(32, 24)
        Me.btnTargetBrowse.TabIndex = 4
        Me.btnTargetBrowse.Text = "..."
        Me.btnTargetBrowse.UseVisualStyleBackColor = True
        '
        'txtSaveFolder
        '
        Me.txtSaveFolder.AllowDrop = True
        Me.txtSaveFolder.Location = New System.Drawing.Point(103, 53)
        Me.txtSaveFolder.Name = "txtSaveFolder"
        Me.txtSaveFolder.Size = New System.Drawing.Size(613, 24)
        Me.txtSaveFolder.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(85, 17)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "保存フォルダ："
        '
        'txtTargetFolder
        '
        Me.txtTargetFolder.AllowDrop = True
        Me.txtTargetFolder.Location = New System.Drawing.Point(103, 23)
        Me.txtTargetFolder.Name = "txtTargetFolder"
        Me.txtTargetFolder.Size = New System.Drawing.Size(613, 24)
        Me.txtTargetFolder.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(85, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "対象フォルダ："
        '
        'Form1
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(784, 561)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "画像分割ツール"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.numCropY, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numCropX, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label3 As Label
    Friend WithEvents cmbExt As ComboBox
    Friend WithEvents btnStart As Button
    Friend WithEvents btnSaveBrowse As Button
    Friend WithEvents btnTargetBrowse As Button
    Friend WithEvents txtSaveFolder As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtTargetFolder As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents lstResult As ListBox
    Friend WithEvents lblProgress As Label
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents numCropY As NumericUpDown
    Friend WithEvents Label4 As Label
    Friend WithEvents numCropX As NumericUpDown
End Class
