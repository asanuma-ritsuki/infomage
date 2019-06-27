Public Class frmRename
#Region "プライベート変数"
    Private BackMenuFlag As Boolean = False
#End Region
#Region "フォームイベント"
    ''' <summary>
    ''' クローズ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub frmRename_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If BackMenuFlag = False Then
            Application.Exit()
        End If
    End Sub
#End Region
#Region "オブジェクトイベント"
    ''' <summary>
    ''' メニューに戻る
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnBackMenu_Click(sender As Object, e As EventArgs) Handles btnBackMenu.Click
        Dim f As New frmMenu
        f.Show()
        BackMenuFlag = True
        Me.Close()
    End Sub


#End Region

#Region "プライベートメソッド"

#End Region
End Class