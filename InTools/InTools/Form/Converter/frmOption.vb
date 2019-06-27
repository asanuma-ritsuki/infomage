Public Class frmOption
#Region "フォームイベント"
    ''' <summary>
    ''' ロード時
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub frmOption_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If My.Settings.Cnv_SelectBinDither = True Then
            Me.rbDither.Checked = True
            Me.rbThreshold.Checked = False
            Me.trbThreshold.Enabled = False
            Me.nudThreshold.Enabled = False
        Else
            Me.rbDither.Checked = False
            Me.rbThreshold.Checked = True
            Me.trbThreshold.Enabled = True
            Me.nudThreshold.Enabled = True
        End If
        Me.trbThreshold.Value = My.Settings.Cnv_Threshold
        Me.rbJPEGQuality.Checked = My.Settings.Cnv_SelectJPEGQuality
        If My.Settings.Cnv_SelectJPEGQuality = True Then
            Me.rbJPEGQuality.Checked = True
            Me.rbJPEGSize.Checked = False
            Me.nudJPEGQuality.Enabled = True
            Me.nudJPEGSize.Enabled = False
        Else
            Me.rbJPEGQuality.Checked = False
            Me.rbJPEGSize.Checked = True
            Me.nudJPEGQuality.Enabled = False
            Me.nudJPEGSize.Enabled = True
        End If

        Me.nudJPEGQuality.Value = My.Settings.Cnv_JPEGQuality
        Me.nudJPEGSize.Value = My.Settings.Cnv_JPEGSize
        Me.txtLogFolder.Text = My.Settings.Cnv_LF

    End Sub
#End Region
#Region "オブジェクトイベント"
    ''' <summary>
    ''' OKボタン押下時
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        My.Settings.Cnv_SelectBinDither = Me.rbDither.Checked
        My.Settings.Cnv_Threshold = Me.trbThreshold.Value
        My.Settings.Cnv_SelectJPEGQuality = Me.rbJPEGQuality.Checked
        My.Settings.Cnv_JPEGQuality = Me.nudJPEGQuality.Value
        My.Settings.Cnv_JPEGSize = Me.nudJPEGSize.Value
        My.Settings.Cnv_LF = Me.txtLogFolder.Text
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

    ''' <summary>
    ''' ディザチェック変更時
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub rbDither_CheckedChanged(sender As Object, e As EventArgs) Handles rbDither.CheckedChanged
        If Me.rbDither.Checked = True Then
            Me.trbThreshold.Enabled = False
            Me.nudThreshold.Enabled = False
        Else
            Me.trbThreshold.Enabled = True
            Me.nudThreshold.Enabled = True
        End If
    End Sub

    ''' <summary>
    ''' JPEG圧縮方式変更時
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub rbJPEGQuality_CheckedChanged(sender As Object, e As EventArgs) Handles rbJPEGQuality.CheckedChanged
        If Me.rbJPEGQuality.Checked = True Then
            Me.nudJPEGQuality.Enabled = True
            Me.nudJPEGSize.Enabled = False
        Else
            Me.nudJPEGQuality.Enabled = False
            Me.nudJPEGSize.Enabled = True
        End If
    End Sub

    ''' <summary>
    ''' スレッショルドバー変更時
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub trbThreshold_ValueChanged(sender As Object, e As EventArgs) Handles trbThreshold.ValueChanged
        Me.nudThreshold.Value = Me.trbThreshold.Value
    End Sub
    ''' <summary>
    ''' スレッショルド値変更時
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub nudThreshold_ValueChanged(sender As Object, e As EventArgs) Handles nudThreshold.ValueChanged
        Me.trbThreshold.Value = Me.nudThreshold.Value
    End Sub
    ''' <summary>
    ''' テキストボックスドラッグ時
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub txtBox_DragEnter(sender As Object, e As DragEventArgs) Handles txtLogFolder.DragEnter
        Dim strFile As String() = CType(e.Data.GetData(DataFormats.FileDrop, False), String())

        If System.IO.Directory.Exists(strFile(0)) Then
            'ドラッグされたデータ形式を調べ、フォルダの時はコピーとする
            e.Effect = DragDropEffects.Copy
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    ''' <summary>
    ''' テキストボックスドロップ時
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub txtImagePath_DragDrop(sender As Object, e As DragEventArgs) Handles txtLogFolder.DragDrop
        Dim strFile As String() = CType(e.Data.GetData(DataFormats.FileDrop, False), String())
        Dim txtControl As TextBox = CType(sender, TextBox)

        'フォルダが存在するか確認する
        If System.IO.Directory.Exists(strFile(0)) Then
            'フォルダが存在していたらテキストボックスに値を表示させる
            txtControl.Text = strFile(0)
        Else
            'フォルダが存在しなかったら何もしない
            MessageBox.Show("ドロップされたオブジェクトはフォルダではありません")
        End If
    End Sub
    ''' <summary>
    ''' ログフォルダダイアログ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnLFDialog_Click(sender As Object, e As EventArgs) Handles btnLFDialog.Click
        Dim fbd As New FolderBrowserDialog
        fbd.Description = "フォルダを指定してください。"
        fbd.RootFolder = Environment.SpecialFolder.Desktop
        fbd.SelectedPath = Environment.SpecialFolder.Desktop
        fbd.ShowNewFolderButton = True
        If fbd.ShowDialog(Me) = DialogResult.OK Then
            '選択されたフォルダを表示する
            Me.txtLogFolder.Text = fbd.SelectedPath
        End If
    End Sub
#End Region
End Class