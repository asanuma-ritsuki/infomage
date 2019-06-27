<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDiskSize
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDiskSize))
        Me.lblUnit = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtVisualByte = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblByte = New System.Windows.Forms.Label()
        Me.gbDiskSize = New System.Windows.Forms.GroupBox()
        Me.txtFreeSpace = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.nudPercentage = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnDiskSizeOK = New System.Windows.Forms.Button()
        Me.gbDiskSize.SuspendLayout()
        CType(Me.nudPercentage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblUnit
        '
        Me.lblUnit.AutoSize = True
        Me.lblUnit.Font = New System.Drawing.Font("Meiryo UI", 14.0!)
        Me.lblUnit.Location = New System.Drawing.Point(304, 89)
        Me.lblUnit.Name = "lblUnit"
        Me.lblUnit.Size = New System.Drawing.Size(39, 24)
        Me.lblUnit.TabIndex = 1
        Me.lblUnit.Text = "MB"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(311, 122)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 17)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Byte)"
        '
        'txtVisualByte
        '
        Me.txtVisualByte.Font = New System.Drawing.Font("Meiryo UI", 14.0!)
        Me.txtVisualByte.Location = New System.Drawing.Point(237, 82)
        Me.txtVisualByte.Name = "txtVisualByte"
        Me.txtVisualByte.ReadOnly = True
        Me.txtVisualByte.Size = New System.Drawing.Size(61, 31)
        Me.txtVisualByte.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(200, 122)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(14, 17)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "("
        '
        'lblByte
        '
        Me.lblByte.AutoSize = True
        Me.lblByte.Location = New System.Drawing.Point(210, 122)
        Me.lblByte.Name = "lblByte"
        Me.lblByte.Size = New System.Drawing.Size(104, 17)
        Me.lblByte.TabIndex = 4
        Me.lblByte.Text = "000000000000"
        '
        'gbDiskSize
        '
        Me.gbDiskSize.Controls.Add(Me.txtFreeSpace)
        Me.gbDiskSize.Controls.Add(Me.Label8)
        Me.gbDiskSize.Controls.Add(Me.Label1)
        Me.gbDiskSize.Controls.Add(Me.lblByte)
        Me.gbDiskSize.Controls.Add(Me.Label6)
        Me.gbDiskSize.Controls.Add(Me.Label4)
        Me.gbDiskSize.Controls.Add(Me.Label7)
        Me.gbDiskSize.Controls.Add(Me.Label3)
        Me.gbDiskSize.Controls.Add(Me.txtVisualByte)
        Me.gbDiskSize.Controls.Add(Me.nudPercentage)
        Me.gbDiskSize.Controls.Add(Me.Label2)
        Me.gbDiskSize.Controls.Add(Me.lblUnit)
        Me.gbDiskSize.Location = New System.Drawing.Point(12, 12)
        Me.gbDiskSize.Name = "gbDiskSize"
        Me.gbDiskSize.Size = New System.Drawing.Size(360, 152)
        Me.gbDiskSize.TabIndex = 5
        Me.gbDiskSize.TabStop = False
        Me.gbDiskSize.Text = "DiskType"
        '
        'txtFreeSpace
        '
        Me.txtFreeSpace.Font = New System.Drawing.Font("Meiryo UI", 9.75!)
        Me.txtFreeSpace.Location = New System.Drawing.Point(87, 31)
        Me.txtFreeSpace.Name = "txtFreeSpace"
        Me.txtFreeSpace.ReadOnly = True
        Me.txtFreeSpace.Size = New System.Drawing.Size(114, 24)
        Me.txtFreeSpace.TabIndex = 8
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(10, 91)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(95, 17)
        Me.Label8.TabIndex = 5
        Me.Label8.Text = "書き込み容量："
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(84, 17)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "ディスク容量："
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(184, 96)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(21, 17)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "％"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(205, 39)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(37, 17)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "Byte"
        '
        'nudPercentage
        '
        Me.nudPercentage.Location = New System.Drawing.Point(111, 89)
        Me.nudPercentage.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudPercentage.Name = "nudPercentage"
        Me.nudPercentage.Size = New System.Drawing.Size(67, 24)
        Me.nudPercentage.TabIndex = 3
        Me.nudPercentage.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Meiryo UI", 14.0!)
        Me.Label2.Location = New System.Drawing.Point(206, 89)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(25, 24)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "="
        '
        'btnDiskSizeOK
        '
        Me.btnDiskSizeOK.Location = New System.Drawing.Point(297, 170)
        Me.btnDiskSizeOK.Name = "btnDiskSizeOK"
        Me.btnDiskSizeOK.Size = New System.Drawing.Size(75, 23)
        Me.btnDiskSizeOK.TabIndex = 6
        Me.btnDiskSizeOK.Text = "OK"
        Me.btnDiskSizeOK.UseVisualStyleBackColor = True
        '
        'frmDiskSize
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(384, 211)
        Me.Controls.Add(Me.btnDiskSizeOK)
        Me.Controls.Add(Me.gbDiskSize)
        Me.Font = New System.Drawing.Font("Meiryo UI", 9.75!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(400, 250)
        Me.MinimumSize = New System.Drawing.Size(400, 250)
        Me.Name = "frmDiskSize"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "振り分けディスクサイズ"
        Me.gbDiskSize.ResumeLayout(False)
        Me.gbDiskSize.PerformLayout()
        CType(Me.nudPercentage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtVisualByte As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblUnit As System.Windows.Forms.Label
    Friend WithEvents lblByte As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents gbDiskSize As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents nudPercentage As System.Windows.Forms.NumericUpDown
    Friend WithEvents btnDiskSizeOK As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtFreeSpace As System.Windows.Forms.TextBox
End Class
