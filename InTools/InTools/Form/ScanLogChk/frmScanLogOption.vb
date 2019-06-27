Public Class frmScanLogOption
    'ロード時
    Private Sub frmExtension_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        '区切り文字設定
        Me.cmbFileNameDelimita.SelectedIndex = My.Settings.LogChk_FileName_delimita
        '各読み込み項目数
        Me.nudFileCounter.Value = My.Settings.LogChk_FCCol
        Me.nudImageCounter.Value = My.Settings.LogChk_ICCol
        Me.nudPageCounter.Value = My.Settings.LogChk_PCCol

        Me.cmbDrive.DataSource = GetRecoveryDrive()
        Me.cmbDrive.SelectedIndex = My.Settings.LogChk_Drive
        Me.txtNetPath.Text = My.Settings.LogChk_NetPath

    End Sub
    'OK押下時
    Private Sub btnExtensionOk_Click(sender As System.Object, e As System.EventArgs) Handles btnExtensionOK.Click

        '区切り文字設定
        My.Settings.LogChk_FileName_delimita = Me.cmbFileNameDelimita.SelectedIndex
        My.Settings.LogChk_FCCol = Me.nudFileCounter.Value
        My.Settings.LogChk_ICCol = Me.nudImageCounter.Value
        My.Settings.LogChk_PCCol = Me.nudPageCounter.Value
        My.Settings.LogChk_Drive = Me.cmbDrive.SelectedIndex
        My.Settings.LogChk_NetPath = Me.txtNetPath.Text

        My.Settings.Save()
        Close()

    End Sub
End Class