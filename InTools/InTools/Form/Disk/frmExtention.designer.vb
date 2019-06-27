<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmExtension
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmExtension))
        Me.txtAdd = New System.Windows.Forms.TextBox()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lstInExtension = New System.Windows.Forms.ListBox()
        Me.btnIn = New System.Windows.Forms.Button()
        Me.btnOut = New System.Windows.Forms.Button()
        Me.grb1 = New System.Windows.Forms.GroupBox()
        Me.grb2 = New System.Windows.Forms.GroupBox()
        Me.lstOutExtension = New System.Windows.Forms.ListBox()
        Me.btnDel = New System.Windows.Forms.Button()
        Me.btnExtensionOK = New System.Windows.Forms.Button()
        Me.grb1.SuspendLayout()
        Me.grb2.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtAdd
        '
        Me.txtAdd.Location = New System.Drawing.Point(56, 216)
        Me.txtAdd.Name = "txtAdd"
        Me.txtAdd.Size = New System.Drawing.Size(63, 24)
        Me.txtAdd.TabIndex = 0
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(125, 217)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(46, 23)
        Me.btnAdd.TabIndex = 1
        Me.btnAdd.Text = "追加"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 219)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 17)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "追加："
        '
        'lstInExtension
        '
        Me.lstInExtension.FormattingEnabled = True
        Me.lstInExtension.ItemHeight = 17
        Me.lstInExtension.Location = New System.Drawing.Point(8, 23)
        Me.lstInExtension.Name = "lstInExtension"
        Me.lstInExtension.Size = New System.Drawing.Size(120, 174)
        Me.lstInExtension.TabIndex = 3
        '
        'btnIn
        '
        Me.btnIn.Font = New System.Drawing.Font("Meiryo UI", 9.75!)
        Me.btnIn.Location = New System.Drawing.Point(164, 84)
        Me.btnIn.Name = "btnIn"
        Me.btnIn.Size = New System.Drawing.Size(52, 23)
        Me.btnIn.TabIndex = 4
        Me.btnIn.Text = "→"
        Me.btnIn.UseVisualStyleBackColor = True
        '
        'btnOut
        '
        Me.btnOut.Location = New System.Drawing.Point(164, 113)
        Me.btnOut.Name = "btnOut"
        Me.btnOut.Size = New System.Drawing.Size(52, 23)
        Me.btnOut.TabIndex = 4
        Me.btnOut.Text = "←"
        Me.btnOut.UseVisualStyleBackColor = True
        '
        'grb1
        '
        Me.grb1.Controls.Add(Me.lstInExtension)
        Me.grb1.Location = New System.Drawing.Point(12, 1)
        Me.grb1.Name = "grb1"
        Me.grb1.Size = New System.Drawing.Size(139, 209)
        Me.grb1.TabIndex = 5
        Me.grb1.TabStop = False
        Me.grb1.Text = "拡張子"
        '
        'grb2
        '
        Me.grb2.Controls.Add(Me.lstOutExtension)
        Me.grb2.Location = New System.Drawing.Point(229, 1)
        Me.grb2.Name = "grb2"
        Me.grb2.Size = New System.Drawing.Size(143, 209)
        Me.grb2.TabIndex = 5
        Me.grb2.TabStop = False
        Me.grb2.Text = "検索拡張子"
        '
        'lstOutExtension
        '
        Me.lstOutExtension.FormattingEnabled = True
        Me.lstOutExtension.ItemHeight = 17
        Me.lstOutExtension.Location = New System.Drawing.Point(8, 23)
        Me.lstOutExtension.Name = "lstOutExtension"
        Me.lstOutExtension.Size = New System.Drawing.Size(120, 174)
        Me.lstOutExtension.TabIndex = 3
        '
        'btnDel
        '
        Me.btnDel.Font = New System.Drawing.Font("Meiryo UI", 7.0!)
        Me.btnDel.Location = New System.Drawing.Point(164, 175)
        Me.btnDel.Name = "btnDel"
        Me.btnDel.Size = New System.Drawing.Size(52, 23)
        Me.btnDel.TabIndex = 4
        Me.btnDel.Text = "Delete"
        Me.btnDel.UseVisualStyleBackColor = True
        '
        'btnExtensionOK
        '
        Me.btnExtensionOK.Location = New System.Drawing.Point(297, 216)
        Me.btnExtensionOK.Name = "btnExtensionOK"
        Me.btnExtensionOK.Size = New System.Drawing.Size(75, 23)
        Me.btnExtensionOK.TabIndex = 6
        Me.btnExtensionOK.Text = "OK"
        Me.btnExtensionOK.UseVisualStyleBackColor = True
        '
        'frmExtension
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(384, 261)
        Me.Controls.Add(Me.btnExtensionOK)
        Me.Controls.Add(Me.grb2)
        Me.Controls.Add(Me.grb1)
        Me.Controls.Add(Me.btnDel)
        Me.Controls.Add(Me.btnOut)
        Me.Controls.Add(Me.btnIn)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.txtAdd)
        Me.Font = New System.Drawing.Font("Meiryo UI", 9.75!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(400, 300)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(400, 300)
        Me.Name = "frmExtension"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "書き込み拡張子"
        Me.grb1.ResumeLayout(False)
        Me.grb2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtAdd As System.Windows.Forms.TextBox
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lstInExtension As System.Windows.Forms.ListBox
    Friend WithEvents btnIn As System.Windows.Forms.Button
    Friend WithEvents btnOut As System.Windows.Forms.Button
    Friend WithEvents grb1 As System.Windows.Forms.GroupBox
    Friend WithEvents grb2 As System.Windows.Forms.GroupBox
    Friend WithEvents lstOutExtension As System.Windows.Forms.ListBox
    Friend WithEvents btnDel As System.Windows.Forms.Button
    Friend WithEvents btnExtensionOK As System.Windows.Forms.Button
End Class
