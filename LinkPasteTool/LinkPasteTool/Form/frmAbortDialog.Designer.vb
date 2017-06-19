<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAbortDialog
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
		Me.Label2 = New System.Windows.Forms.Label()
		Me.cmbFlag = New System.Windows.Forms.ComboBox()
		Me.btnCancel = New System.Windows.Forms.Button()
		Me.btnOK = New System.Windows.Forms.Button()
		Me.SuspendLayout()
		'
		'Label2
		'
		Me.Label2.Location = New System.Drawing.Point(3, 7)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(478, 25)
		Me.Label2.TabIndex = 16
		Me.Label2.Text = "中断理由を選択してください"
		Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'cmbFlag
		'
		Me.cmbFlag.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cmbFlag.FormattingEnabled = True
		Me.cmbFlag.Location = New System.Drawing.Point(3, 35)
		Me.cmbFlag.Name = "cmbFlag"
		Me.cmbFlag.Size = New System.Drawing.Size(478, 25)
		Me.cmbFlag.TabIndex = 15
		'
		'btnCancel
		'
		Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.btnCancel.Location = New System.Drawing.Point(397, 66)
		Me.btnCancel.Name = "btnCancel"
		Me.btnCancel.Size = New System.Drawing.Size(75, 25)
		Me.btnCancel.TabIndex = 14
		Me.btnCancel.Text = "キャンセル"
		Me.btnCancel.UseVisualStyleBackColor = True
		'
		'btnOK
		'
		Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
		Me.btnOK.Location = New System.Drawing.Point(316, 66)
		Me.btnOK.Name = "btnOK"
		Me.btnOK.Size = New System.Drawing.Size(75, 25)
		Me.btnOK.TabIndex = 13
		Me.btnOK.Text = "O　K"
		Me.btnOK.UseVisualStyleBackColor = True
		'
		'frmAbortDialog
		'
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
		Me.ClientSize = New System.Drawing.Size(484, 98)
		Me.Controls.Add(Me.Label2)
		Me.Controls.Add(Me.cmbFlag)
		Me.Controls.Add(Me.btnCancel)
		Me.Controls.Add(Me.btnOK)
		Me.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
		Me.Name = "frmAbortDialog"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "frmAbortDialog"
		Me.ResumeLayout(False)

	End Sub

	Friend WithEvents Label2 As Label
    Friend WithEvents cmbFlag As ComboBox
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnOK As Button
End Class
