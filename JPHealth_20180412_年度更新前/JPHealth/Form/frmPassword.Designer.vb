<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPassword
    Inherits frmTempForm

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPassword))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(260, 40)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "選択ロットの削除対象を変更するにはパスワードの入力が必要です"
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(95, 74)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(9679)
        Me.txtPassword.Size = New System.Drawing.Size(164, 24)
        Me.txtPassword.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(9, 73)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 24)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "パスワード："
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Location = New System.Drawing.Point(116, 106)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 25)
        Me.btnOK.TabIndex = 4
        Me.btnOK.Text = "O　K"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(197, 106)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 25)
        Me.btnCancel.TabIndex = 5
        Me.btnCancel.Text = "キャンセル"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.ForeColor = System.Drawing.Color.Red
        Me.Label3.Location = New System.Drawing.Point(12, 49)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(260, 22)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "※削除対象を変更する際は2者で確認すること"
        '
        'frmPassword
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.CaptionDisplayMode = JPHealth.frmTempForm.StatusDisplayMode.ShowAll
        Me.ClientSize = New System.Drawing.Size(284, 140)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmPassword"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmPassword"
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.txtPassword, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.btnOK, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents btnOK As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents Label3 As Label
End Class
