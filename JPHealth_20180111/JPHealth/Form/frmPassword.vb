Public Class frmPassword

    Private blnSuccess As Boolean = False

#Region "フォームイベント"

    ''' <summary>
    ''' フォームロード時
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub frmPassword_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.Text = "パスワード確認"
        Me.CaptionDisplayMode = StatusDisplayMode.None

    End Sub

    ''' <summary>
    ''' フォームが閉じられるとき
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub frmPassword_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

        If Me.DialogResult = DialogResult.OK Then

            If Not blnSuccess Then
                'OKボタンが押されて、かつパスワードが間違えていたらエラー
                MessageBox.Show("パスワードが違います", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.txtPassword.Focus()
                Me.txtPassword.SelectAll()
                e.Cancel = True
            End If

        End If

    End Sub

#End Region

#Region "オブジェクトイベント"

    ''' <summary>
    ''' OKボタン押下時
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click

        XmlSettings.LoadFromXmlFile()
        Dim strPassword As String = XmlSettings.Instance.ExcelPassword

        If strPassword = Me.txtPassword.Text Then
            blnSuccess = True
        Else
            blnSuccess = False
        End If
    End Sub

    ''' <summary>
    ''' テキストボックスエンター時
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub txtPassword_Enter(sender As Object, e As EventArgs) Handles txtPassword.Enter

        CType(sender, TextBox).BackColor = Color.LightGreen
        CType(sender, TextBox).SelectAll()

    End Sub

    ''' <summary>
    ''' テキストボックスリーブ時
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub txtPassword_Leave(sender As Object, e As EventArgs) Handles txtPassword.Leave

        CType(sender, TextBox).BackColor = System.Drawing.SystemColors.Window

    End Sub

#End Region
End Class