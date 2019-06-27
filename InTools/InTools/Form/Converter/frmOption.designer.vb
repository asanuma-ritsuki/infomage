<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOption
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmOption))
        Me.grpFileSize = New System.Windows.Forms.GroupBox()
        Me.rbJPEGSize = New System.Windows.Forms.RadioButton()
        Me.nudJPEGQuality = New System.Windows.Forms.NumericUpDown()
        Me.rbJPEGQuality = New System.Windows.Forms.RadioButton()
        Me.nudJPEGSize = New System.Windows.Forms.NumericUpDown()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.nudThreshold = New System.Windows.Forms.NumericUpDown()
        Me.rbThreshold = New System.Windows.Forms.RadioButton()
        Me.rbDither = New System.Windows.Forms.RadioButton()
        Me.trbThreshold = New System.Windows.Forms.TrackBar()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnLFDialog = New System.Windows.Forms.Button()
        Me.txtLogFolder = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.grpFileSize.SuspendLayout()
        CType(Me.nudJPEGQuality, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudJPEGSize, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.nudThreshold, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.trbThreshold, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpFileSize
        '
        Me.grpFileSize.Controls.Add(Me.rbJPEGSize)
        Me.grpFileSize.Controls.Add(Me.nudJPEGQuality)
        Me.grpFileSize.Controls.Add(Me.rbJPEGQuality)
        Me.grpFileSize.Controls.Add(Me.nudJPEGSize)
        Me.grpFileSize.Location = New System.Drawing.Point(288, 12)
        Me.grpFileSize.Name = "grpFileSize"
        Me.grpFileSize.Size = New System.Drawing.Size(270, 135)
        Me.grpFileSize.TabIndex = 1
        Me.grpFileSize.TabStop = False
        Me.grpFileSize.Text = "JPEG仕様"
        '
        'rbJPEGSize
        '
        Me.rbJPEGSize.AutoSize = True
        Me.rbJPEGSize.Location = New System.Drawing.Point(6, 50)
        Me.rbJPEGSize.Name = "rbJPEGSize"
        Me.rbJPEGSize.Size = New System.Drawing.Size(110, 21)
        Me.rbJPEGSize.TabIndex = 8
        Me.rbJPEGSize.TabStop = True
        Me.rbJPEGSize.Text = "サイズ指定(kb)"
        Me.rbJPEGSize.UseVisualStyleBackColor = True
        '
        'nudJPEGQuality
        '
        Me.nudJPEGQuality.Location = New System.Drawing.Point(146, 23)
        Me.nudJPEGQuality.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudJPEGQuality.Name = "nudJPEGQuality"
        Me.nudJPEGQuality.Size = New System.Drawing.Size(106, 24)
        Me.nudJPEGQuality.TabIndex = 5
        Me.nudJPEGQuality.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'rbJPEGQuality
        '
        Me.rbJPEGQuality.AutoSize = True
        Me.rbJPEGQuality.Location = New System.Drawing.Point(6, 23)
        Me.rbJPEGQuality.Name = "rbJPEGQuality"
        Me.rbJPEGQuality.Size = New System.Drawing.Size(78, 21)
        Me.rbJPEGQuality.TabIndex = 7
        Me.rbJPEGQuality.TabStop = True
        Me.rbJPEGQuality.Text = "品質指定"
        Me.rbJPEGQuality.UseVisualStyleBackColor = True
        '
        'nudJPEGSize
        '
        Me.nudJPEGSize.Location = New System.Drawing.Point(146, 50)
        Me.nudJPEGSize.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.nudJPEGSize.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudJPEGSize.Name = "nudJPEGSize"
        Me.nudJPEGSize.Size = New System.Drawing.Size(106, 24)
        Me.nudJPEGSize.TabIndex = 3
        Me.nudJPEGSize.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(376, 223)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(88, 24)
        Me.btnOK.TabIndex = 2
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(470, 223)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(88, 24)
        Me.btnCancel.TabIndex = 3
        Me.btnCancel.Text = "キャンセル"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.nudThreshold)
        Me.GroupBox1.Controls.Add(Me.rbThreshold)
        Me.GroupBox1.Controls.Add(Me.rbDither)
        Me.GroupBox1.Controls.Add(Me.trbThreshold)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(270, 135)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "2値仕様"
        '
        'nudThreshold
        '
        Me.nudThreshold.Location = New System.Drawing.Point(207, 85)
        Me.nudThreshold.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me.nudThreshold.Name = "nudThreshold"
        Me.nudThreshold.Size = New System.Drawing.Size(57, 24)
        Me.nudThreshold.TabIndex = 7
        Me.nudThreshold.Value = New Decimal(New Integer() {128, 0, 0, 0})
        '
        'rbThreshold
        '
        Me.rbThreshold.AutoSize = True
        Me.rbThreshold.Location = New System.Drawing.Point(12, 50)
        Me.rbThreshold.Name = "rbThreshold"
        Me.rbThreshold.Size = New System.Drawing.Size(118, 21)
        Me.rbThreshold.TabIndex = 6
        Me.rbThreshold.TabStop = True
        Me.rbThreshold.Text = "スレッショルド変換"
        Me.rbThreshold.UseVisualStyleBackColor = True
        '
        'rbDither
        '
        Me.rbDither.AutoSize = True
        Me.rbDither.Location = New System.Drawing.Point(12, 23)
        Me.rbDither.Name = "rbDither"
        Me.rbDither.Size = New System.Drawing.Size(81, 21)
        Me.rbDither.TabIndex = 5
        Me.rbDither.TabStop = True
        Me.rbDither.Text = "ディザ変換"
        Me.rbDither.UseVisualStyleBackColor = True
        '
        'trbThreshold
        '
        Me.trbThreshold.LargeChange = 10
        Me.trbThreshold.Location = New System.Drawing.Point(6, 85)
        Me.trbThreshold.Maximum = 255
        Me.trbThreshold.Name = "trbThreshold"
        Me.trbThreshold.Size = New System.Drawing.Size(195, 45)
        Me.trbThreshold.TabIndex = 2
        Me.trbThreshold.TickFrequency = 5
        Me.trbThreshold.Value = 128
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnLFDialog)
        Me.GroupBox2.Controls.Add(Me.txtLogFolder)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 153)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(546, 64)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "ログ"
        '
        'btnLFDialog
        '
        Me.btnLFDialog.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLFDialog.Location = New System.Drawing.Point(498, 23)
        Me.btnLFDialog.Name = "btnLFDialog"
        Me.btnLFDialog.Size = New System.Drawing.Size(42, 24)
        Me.btnLFDialog.TabIndex = 5
        Me.btnLFDialog.Text = "..."
        Me.btnLFDialog.UseVisualStyleBackColor = True
        '
        'txtLogFolder
        '
        Me.txtLogFolder.AllowDrop = True
        Me.txtLogFolder.Location = New System.Drawing.Point(100, 23)
        Me.txtLogFolder.Name = "txtLogFolder"
        Me.txtLogFolder.Size = New System.Drawing.Size(402, 24)
        Me.txtLogFolder.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(9, 26)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(78, 17)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "ログフォルダ："
        '
        'frmOption
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(584, 261)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.grpFileSize)
        Me.Font = New System.Drawing.Font("Meiryo UI", 9.75!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(600, 300)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(600, 300)
        Me.Name = "frmOption"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "詳細設定"
        Me.grpFileSize.ResumeLayout(False)
        Me.grpFileSize.PerformLayout()
        CType(Me.nudJPEGQuality, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudJPEGSize, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.nudThreshold, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.trbThreshold, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grpFileSize As System.Windows.Forms.GroupBox
    Friend WithEvents nudJPEGSize As System.Windows.Forms.NumericUpDown
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents btnCancel As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents trbThreshold As TrackBar
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents txtLogFolder As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents nudJPEGQuality As NumericUpDown
    Friend WithEvents rbThreshold As RadioButton
    Friend WithEvents rbDither As RadioButton
    Friend WithEvents rbJPEGSize As RadioButton
    Friend WithEvents rbJPEGQuality As RadioButton
    Friend WithEvents nudThreshold As NumericUpDown
    Friend WithEvents btnLFDialog As Button
End Class
