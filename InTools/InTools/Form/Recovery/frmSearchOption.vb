Public Class frmSearchOption
#Region "フォームイベント"
    ''' <summary>
    ''' ロード時
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub frmOption_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.cmbDrive.DataSource = GetRecoveryDrive()
        Me.cmbDrive.SelectedIndex = My.Settings.Rcv_Drive
        Me.txtNetPath.Text = My.Settings.Rcv_NetPath
    End Sub
#End Region
#Region "オブジェクトイベント"
    ''' <summary>
    ''' OKボタン押下時
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        My.Settings.Rcv_Drive = Me.cmbDrive.SelectedIndex
        My.Settings.Rcv_NetPath = Me.txtNetPath.Text
        My.Settings.Save()
        Me.Close()
    End Sub
    ''' <summary>
    ''' キャンセル
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
#End Region
End Class