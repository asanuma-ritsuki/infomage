Public Class frmBCRead

#Region "プライベート変数"
    Private BackMenuFlag As Boolean = False
#End Region
#Region "フォームイベント"
    ''' <summary>
    ''' フォームロード時
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub frmOpenCheck_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.txtInputFolderName.Text = My.Settings.BCRead_SrcPath
        Me.txtOutputFolderName.Text = My.Settings.BCRead_DstPath
        Me.fgrFileList.Rows.Count = 1
        Me.fgrFileList.AutoSizeCols()
        Me.cmbBCType.DataSource = BCReadProcess.GetBCType()
        Me.cmbBCType.SelectedIndex = My.Settings.BCRead_BCType

    End Sub
    ''' <summary>
    ''' フォームクロージング
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub frmOpenCheck_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        My.Settings.BCRead_SrcPath = Me.txtInputFolderName.Text
        My.Settings.BCRead_DstPath = Me.txtOutputFolderName.Text
        My.Settings.BCRead_BCType = Me.cmbBCType.SelectedIndex
        My.Settings.Save()

        If BackMenuFlag = False Then
            Application.Exit()
        End If
    End Sub
#End Region
#Region "オブジェクトイベント"
    ''' <summary>
    ''' テキストボックスドラッグ時
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub txtBox_DragEnter(sender As Object, e As DragEventArgs) Handles txtInputFolderName.DragEnter, txtOutputFolderName.DragEnter
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
    Private Sub txtImagePath_DragDrop(sender As Object, e As DragEventArgs) Handles txtInputFolderName.DragDrop, txtOutputFolderName.DragDrop
        'コントロール内にドロップされた時実行される
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
    ''' フォルダ参照
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnOpenFolder_Click(sender As Object, e As EventArgs) Handles btnInputFolderOpen.Click, btnOutputFolderOpen.Click
        Dim cofd As New Microsoft.WindowsAPICodePack.Dialogs.CommonOpenFileDialog
        If CType(sender, Button).Name = "btnInputFolderOpen" Then
            If System.IO.Directory.Exists(Me.txtInputFolderName.Text) Then
                cofd.InitialDirectory = Me.txtInputFolderName.Text
            End If
        Else
            If System.IO.Directory.Exists(Me.txtOutputFolderName.Text) Then
                cofd.InitialDirectory = Me.txtOutputFolderName.Text
            End If
        End If

        cofd.IsFolderPicker = True
        If cofd.ShowDialog() = Microsoft.WindowsAPICodePack.Dialogs.CommonFileDialogResult.Ok Then
            If CType(sender, Button).Name = "btnInputFolderOpen" Then
                Me.txtInputFolderName.Text = cofd.FileName
            Else
                Me.txtOutputFolderName.Text = cofd.FileName
            End If
        End If
    End Sub

    ''' <summary>
    ''' BC種別が変更された場合
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub cmbBCType_TextChanged(sender As Object, e As EventArgs) Handles cmbBCType.TextChanged
        If Me.cmbBCType.Text = "QR_CODE" Then
            Me.chkAutoRotate.Checked = False
            Me.chkAutoRotate.Enabled = False
        Else
            Me.chkAutoRotate.Enabled = True
        End If
    End Sub

    ''' <summary>
    ''' BCチェックボタン
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click
        If Me.txtInputFolderName.Text = "" Then
            MessageBox.Show("BCを読み取るフォルダを指定してください。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        If Me.txtOutputFolderName.Text = "" Then
            MessageBox.Show("ログ保存先を指定してください。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        EnableSwitch(True)

        'イメージパス取得
        Dim Extensions As String() = New String() {"*.jpg", "*.tif"}
        Dim files As String() = GetFilesMostDeep(Me.txtInputFolderName.Text, Extensions)

        Me.fgrFileList.Rows.Count = 1

        'ファイル数
        Me.txtFileCount.Text = files.Count
        'エラーファイル数
        Me.txtErrorCount.Text = 0

        'プログレス
        Me.pgbFiles.Maximum = files.Count
        Me.pgbFiles.Value = 0
        Me.txtProgress.Text = Me.pgbFiles.Value & "/" & Me.pgbFiles.Maximum

        '書き込み先のテキストファイル 
        Dim LogPath As String = Me.txtOutputFolderName.Text & "\BC読取_" & System.IO.Path.GetFileName(Me.txtInputFolderName.Text) & "_" & System.DateTime.Now.ToString("yyyyMMddHHmmss") & ".txt"


        For iRow As Integer = 1 To files.Count
            Me.fgrFileList.Rows.Count += 1
            Dim FilePath As String = files(iRow - 1)

            Me.fgrFileList.Rows(iRow)("No.") = iRow
            Me.fgrFileList.Rows(iRow)("ファイルパス") = FilePath

            Dim BCResult As String() = BCReadProcess.BarcodeRead(FilePath, Math.Pow(2, Me.cmbBCType.SelectedIndex), Me.chkAutoRotate.Checked, Me.chkBin.Checked)

            Me.fgrFileList.Rows(iRow)("BC値") = BCResult(0)
            Me.fgrFileList.Rows(iRow)("BCタイプ") = BCResult(1)

            'ログ書込み
            '文字コード(ここでは、Shift JIS) 
            Dim enc As System.Text.Encoding = System.Text.Encoding.GetEncoding("shift_jis")
            'ファイルの末尾にTextBox1の内容を書き加える 
            System.IO.File.AppendAllText(LogPath, iRow & vbTab & FilePath & vbTab & BCResult(0) & vbTab & BCResult(1) & vbNewLine, enc)

            Me.pgbFiles.Value += 1
            Me.txtProgress.Text = Me.pgbFiles.Value & "/" & Me.pgbFiles.Maximum
            Me.fgrFileList.ShowCell(Me.fgrFileList.Rows.Count - 1, 0)
            '列の幅を最大桁数に合わせる
            Me.fgrFileList.AutoSizeCols()
            System.Windows.Forms.Application.DoEvents()
        Next

        MessageBox.Show("BC読取が完了しました。", "完了", MessageBoxButtons.OK, MessageBoxIcon.Information)

        EnableSwitch(False)
    End Sub

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
    ''' <summary>
    ''' オブジェクトの有効切り替え
    ''' </summary>
    ''' <param name="DoingFlag"></param>
    Private Sub EnableSwitch(ByVal DoingFlag As Boolean)
        Me.txtInputFolderName.Enabled = Not DoingFlag
        Me.txtOutputFolderName.Enabled = Not DoingFlag
        Me.btnStart.Enabled = Not DoingFlag
        Me.btnInputFolderOpen.Enabled = Not DoingFlag
        Me.btnOutputFolderOpen.Enabled = Not DoingFlag
        Me.btnBackMenu.Enabled = Not DoingFlag
        Me.cmbBCType.Enabled = Not DoingFlag

    End Sub

#End Region
End Class