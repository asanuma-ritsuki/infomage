<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSQLSetting
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
        Me.btnTest = New System.Windows.Forms.Button()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.txtDataSource = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtDataBase = New System.Windows.Forms.TextBox()
        Me.txtUserID = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtPW = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnTest
        '
        Me.btnTest.Location = New System.Drawing.Point(12, 127)
        Me.btnTest.Name = "btnTest"
        Me.btnTest.Size = New System.Drawing.Size(75, 23)
        Me.btnTest.TabIndex = 0
        Me.btnTest.Text = "接続テスト"
        Me.btnTest.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(216, 127)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 1
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(297, 127)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 2
        Me.btnCancel.Text = "キャンセル"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'txtDataSource
        '
        Me.txtDataSource.Location = New System.Drawing.Point(84, 13)
        Me.txtDataSource.Name = "txtDataSource"
        Me.txtDataSource.Size = New System.Drawing.Size(288, 19)
        Me.txtDataSource.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 12)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "DataSource"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(23, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 12)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "DataBase"
        '
        'txtDataBase
        '
        Me.txtDataBase.Location = New System.Drawing.Point(84, 39)
        Me.txtDataBase.Name = "txtDataBase"
        Me.txtDataBase.Size = New System.Drawing.Size(288, 19)
        Me.txtDataBase.TabIndex = 6
        '
        'txtUserID
        '
        Me.txtUserID.Location = New System.Drawing.Point(84, 65)
        Me.txtUserID.Name = "txtUserID"
        Me.txtUserID.Size = New System.Drawing.Size(288, 19)
        Me.txtUserID.TabIndex = 8
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(38, 68)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 12)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "UserID"
        '
        'txtPW
        '
        Me.txtPW.Location = New System.Drawing.Point(84, 91)
        Me.txtPW.Name = "txtPW"
        Me.txtPW.Size = New System.Drawing.Size(288, 19)
        Me.txtPW.TabIndex = 10
        Me.txtPW.UseSystemPasswordChar = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(24, 94)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(54, 12)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Password"
        '
        'frmSQLSetting
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(384, 162)
        Me.ControlBox = False
        Me.Controls.Add(Me.txtPW)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtUserID)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtDataBase)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtDataSource)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnTest)
        Me.MaximumSize = New System.Drawing.Size(400, 200)
        Me.MinimumSize = New System.Drawing.Size(400, 200)
        Me.Name = "frmSQLSetting"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "SQL接続設定"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnTest As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents txtDataSource As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtDataBase As System.Windows.Forms.TextBox
    Friend WithEvents txtUserID As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtPW As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
