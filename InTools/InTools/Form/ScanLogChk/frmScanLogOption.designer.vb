<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmScanLogOption
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
        Me.btnExtensionOK = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.nudPageCounter = New System.Windows.Forms.NumericUpDown()
        Me.nudImageCounter = New System.Windows.Forms.NumericUpDown()
        Me.nudFileCounter = New System.Windows.Forms.NumericUpDown()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbFileNameDelimita = New System.Windows.Forms.ComboBox()
        Me.grpDPI = New System.Windows.Forms.GroupBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtNetPath = New System.Windows.Forms.TextBox()
        Me.cmbDrive = New System.Windows.Forms.ComboBox()
        Me.GroupBox1.SuspendLayout()
        CType(Me.nudPageCounter, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudImageCounter, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudFileCounter, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpDPI.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnExtensionOK
        '
        Me.btnExtensionOK.Location = New System.Drawing.Point(497, 242)
        Me.btnExtensionOK.Name = "btnExtensionOK"
        Me.btnExtensionOK.Size = New System.Drawing.Size(75, 23)
        Me.btnExtensionOK.TabIndex = 6
        Me.btnExtensionOK.Text = "OK"
        Me.btnExtensionOK.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.nudPageCounter)
        Me.GroupBox1.Controls.Add(Me.nudImageCounter)
        Me.GroupBox1.Controls.Add(Me.nudFileCounter)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cmbFileNameDelimita)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 1)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(560, 164)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "ファイル名設定"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(255, 117)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(47, 17)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "項目目"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(255, 90)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(47, 17)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "項目目"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(255, 63)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(47, 17)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "項目目"
        '
        'nudPageCounter
        '
        Me.nudPageCounter.Location = New System.Drawing.Point(210, 115)
        Me.nudPageCounter.Name = "nudPageCounter"
        Me.nudPageCounter.Size = New System.Drawing.Size(42, 24)
        Me.nudPageCounter.TabIndex = 12
        Me.nudPageCounter.Value = New Decimal(New Integer() {4, 0, 0, 0})
        '
        'nudImageCounter
        '
        Me.nudImageCounter.Location = New System.Drawing.Point(210, 88)
        Me.nudImageCounter.Name = "nudImageCounter"
        Me.nudImageCounter.Size = New System.Drawing.Size(42, 24)
        Me.nudImageCounter.TabIndex = 12
        Me.nudImageCounter.Value = New Decimal(New Integer() {3, 0, 0, 0})
        '
        'nudFileCounter
        '
        Me.nudFileCounter.Location = New System.Drawing.Point(210, 61)
        Me.nudFileCounter.Name = "nudFileCounter"
        Me.nudFileCounter.Size = New System.Drawing.Size(42, 24)
        Me.nudFileCounter.TabIndex = 12
        Me.nudFileCounter.Value = New Decimal(New Integer() {2, 0, 0, 0})
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(9, 117)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(198, 17)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "読取時のカウンター（原稿単位）："
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 90)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(198, 17)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "読取時のカウンター（画像単位）："
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(126, 36)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 17)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "区切り文字："
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(100, 63)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(107, 17)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "ファイルカウンター："
        '
        'cmbFileNameDelimita
        '
        Me.cmbFileNameDelimita.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbFileNameDelimita.FormattingEnabled = True
        Me.cmbFileNameDelimita.Items.AddRange(New Object() {"アンダースコア(_)", "ハイフン(-)"})
        Me.cmbFileNameDelimita.Location = New System.Drawing.Point(210, 34)
        Me.cmbFileNameDelimita.Name = "cmbFileNameDelimita"
        Me.cmbFileNameDelimita.Size = New System.Drawing.Size(134, 23)
        Me.cmbFileNameDelimita.TabIndex = 6
        '
        'grpDPI
        '
        Me.grpDPI.Controls.Add(Me.Label9)
        Me.grpDPI.Controls.Add(Me.txtNetPath)
        Me.grpDPI.Controls.Add(Me.cmbDrive)
        Me.grpDPI.Location = New System.Drawing.Point(12, 171)
        Me.grpDPI.Name = "grpDPI"
        Me.grpDPI.Size = New System.Drawing.Size(560, 65)
        Me.grpDPI.TabIndex = 15
        Me.grpDPI.TabStop = False
        Me.grpDPI.Text = "ドライブ設定"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(17, 26)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(84, 17)
        Me.Label9.TabIndex = 4
        Me.Label9.Text = "検索ドライブ："
        '
        'txtNetPath
        '
        Me.txtNetPath.Location = New System.Drawing.Point(197, 23)
        Me.txtNetPath.Name = "txtNetPath"
        Me.txtNetPath.Size = New System.Drawing.Size(349, 24)
        Me.txtNetPath.TabIndex = 2
        '
        'cmbDrive
        '
        Me.cmbDrive.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDrive.FormattingEnabled = True
        Me.cmbDrive.Items.AddRange(New Object() {""})
        Me.cmbDrive.Location = New System.Drawing.Point(103, 23)
        Me.cmbDrive.Name = "cmbDrive"
        Me.cmbDrive.Size = New System.Drawing.Size(88, 25)
        Me.cmbDrive.TabIndex = 1
        '
        'frmScanLogOption
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(584, 276)
        Me.Controls.Add(Me.grpDPI)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnExtensionOK)
        Me.Font = New System.Drawing.Font("Meiryo UI", 9.75!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(600, 315)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(600, 315)
        Me.Name = "frmScanLogOption"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "読み込み設定"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.nudPageCounter, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudImageCounter, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudFileCounter, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpDPI.ResumeLayout(False)
        Me.grpDPI.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnExtensionOK As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents cmbFileNameDelimita As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents nudPageCounter As NumericUpDown
    Friend WithEvents nudImageCounter As NumericUpDown
    Friend WithEvents nudFileCounter As NumericUpDown
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents grpDPI As GroupBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txtNetPath As TextBox
    Friend WithEvents cmbDrive As ComboBox
End Class
