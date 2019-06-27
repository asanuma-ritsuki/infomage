<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmSearchOption
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
        Me.components = New System.ComponentModel.Container()
        Me.grpDPI = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtNetPath = New System.Windows.Forms.TextBox()
        Me.cmbDrive = New System.Windows.Forms.ComboBox()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.grpDPI.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpDPI
        '
        Me.grpDPI.Controls.Add(Me.Label1)
        Me.grpDPI.Controls.Add(Me.txtNetPath)
        Me.grpDPI.Controls.Add(Me.cmbDrive)
        Me.grpDPI.Location = New System.Drawing.Point(12, 12)
        Me.grpDPI.Name = "grpDPI"
        Me.grpDPI.Size = New System.Drawing.Size(560, 65)
        Me.grpDPI.TabIndex = 1
        Me.grpDPI.TabStop = False
        Me.grpDPI.Text = "ドライブ設定"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(17, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(84, 17)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "検索ドライブ："
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
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(376, 125)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(88, 24)
        Me.btnOK.TabIndex = 2
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(470, 125)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(88, 24)
        Me.btnCancel.TabIndex = 3
        Me.btnCancel.Text = "キャンセル"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'frmSearchOption
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(584, 161)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.grpDPI)
        Me.Font = New System.Drawing.Font("Meiryo UI", 9.75!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(600, 200)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(600, 200)
        Me.Name = "frmSearchOption"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "検索オプション"
        Me.grpDPI.ResumeLayout(False)
        Me.grpDPI.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grpDPI As System.Windows.Forms.GroupBox
    Friend WithEvents cmbDrive As System.Windows.Forms.ComboBox
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents btnCancel As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents txtNetPath As TextBox
End Class
