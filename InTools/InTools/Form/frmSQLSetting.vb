Public Class frmSQLSetting

    Private initDataSource As String = ""
    Private initDataBase As String = ""
    Private initUserID As String = ""
    Private initPassword As String = ""

#Region "フォームイベント"
    ''' <summary>
    ''' ロード時
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub frmSQLSetting_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        '設定から読込
        Me.txtDataSource.Text = My.Settings.DataSource
        Me.txtDataBase.Text = My.Settings.DataBase
        Me.txtUserID.Text = My.Settings.UserID
        Me.txtPW.Text = My.Settings.PW
        initDataSource = My.Settings.DataSource
        initDataBase = My.Settings.DataBase
        initUserID = My.Settings.UserID
        initPassword = My.Settings.PW

    End Sub
#End Region
#Region "オブジェクトイベント"
    ''' <summary>
    ''' キャンセルボタン
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        My.Settings.DataSource = initDataSource
        My.Settings.DataBase = initDataBase
        My.Settings.UserID = initUserID
        My.Settings.PW = initPassword
        My.Settings.Save()

        Me.Close()
    End Sub
    ''' <summary>
    ''' OKボタン
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOK.Click
        My.Settings.DataSource = Me.txtDataSource.Text
        My.Settings.DataBase = Me.txtDataBase.Text
        My.Settings.UserID = Me.txtUserID.Text
        My.Settings.PW = Me.txtPW.Text
        My.Settings.Save()

        Me.Close()
    End Sub
    ''' <summary>
    ''' 接続テスト
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnTest_Click(sender As System.Object, e As System.EventArgs) Handles btnTest.Click
        My.Settings.DataSource = Me.txtDataSource.Text
        My.Settings.DataBase = Me.txtDataBase.Text
        My.Settings.UserID = Me.txtUserID.Text
        My.Settings.PW = Me.txtPW.Text
        My.Settings.Save()

        '接続テスト

        Dim con As New System.Data.SqlClient.SqlConnection

        Try
            con.ConnectionString =
                "Data Source=" & My.Settings.DataSource & ";" &
                "Initial Catalog=" & My.Settings.DataBase & ";" &
                "Persist Security Info=True;" &
                "User ID=" & My.Settings.UserID & ";" &
                "Password=" & My.Settings.PW
            con.Open()
            con.Close()
            MessageBox.Show("接続に成功しました", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("接続に失敗しました", "失敗", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
#End Region
End Class