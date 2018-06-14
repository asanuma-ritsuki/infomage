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

        frmBCRead.cmbLotSelect.Items.Clear()
        frmBCRead.cmbLotSelect.SelectedIndex = -1
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

        XmlSettings.Instance.DataSource = initDataSource
        XmlSettings.Instance.InitialCatalog = initDataBase
        XmlSettings.Instance.UserID = initUserID
        XmlSettings.Instance.Password = initPassword

        XmlSettings.SaveToXmlFile()
        XmlSettings.LoadFromXmlFile()
        frmBCRead.sqlProcess_SER.Initialize()
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

        XmlSettings.Instance.DataSource = Me.txtDataSource.Text
        XmlSettings.Instance.InitialCatalog = Me.txtDataBase.Text
        XmlSettings.Instance.UserID = Me.txtUserID.Text
        XmlSettings.Instance.Password = Me.txtPW.Text

        XmlSettings.SaveToXmlFile()
        XmlSettings.LoadFromXmlFile()
        frmBCRead.sqlProcess_SER.Initialize()

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

        XmlSettings.Instance.DataSource = Me.txtDataSource.Text
        XmlSettings.Instance.InitialCatalog = Me.txtDataBase.Text
        XmlSettings.Instance.UserID = Me.txtUserID.Text
        XmlSettings.Instance.Password = Me.txtPW.Text

        XmlSettings.SaveToXmlFile()
        XmlSettings.LoadFromXmlFile()
        frmBCRead.sqlProcess_SER.Initialize()

        'コンボボックスにロット情報を入力
        frmBCRead.strSQL_SER = "SELECT count(*) FROM T_印刷ソート"
        frmBCRead.strSQL_SER &= " GROUP BY ロットID"
        Dim dtLot As Integer = frmBCRead.sqlProcess_SER.DB_EXECUTE_SCALAR(frmBCRead.strSQL_SER)

        If Not dtLot = 0 Then
            MessageBox.Show("接続に成功しました", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("接続に失敗しました", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub
#End Region
End Class