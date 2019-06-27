
Public Class frmGetPath

#Region "プライベート変数"
    Private BackMenuFlag As Boolean = False
    Private CancelFlag As Boolean = False
#End Region
#Region "フォームイベント"
    ''' <summary>
    ''' フォームロード時
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub frmOpenCheck_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.btnCancel.Enabled = False
        Me.cmbMojiCode.Items.AddRange(GetMojiCode)

        Me.cmbMojiCode.SelectedIndex = My.Settings.GetPath_MojiCode
        Me.txtInputFolderName.Text = My.Settings.GetPath_SrcPath
        Me.txtOutputFileName.Text = My.Settings.GetPath_DstPath
        Me.rbFolder.Checked = My.Settings.GetPath_rbFolder
        Me.rbFile.Checked = Not My.Settings.GetPath_rbFolder
        Me.rbComma.Checked = My.Settings.GetPath_rbComma
        Me.rbTab.Checked = Not My.Settings.GetPath_rbComma
        Me.chkExt.Checked = My.Settings.GetPath_chkExt
        Me.cmbExt.Text = My.Settings.GetPath_txtExt
        Me.chkFileSize.Checked = My.Settings.GetPath_chkFileSize
        Me.chkFileCount.Checked = My.Settings.GetPath_chkFileCount
        Me.chkSkipEmpFolder.Checked = My.Settings.GetPath_chkSkipEmpFolder
        Me.chkNotFindHidden.Checked = My.Settings.GetPath_chkFindHidden
        Me.chkPathSplit.Checked = My.Settings.GetPath_chkPathSplit

    End Sub
    ''' <summary>
    ''' フォームクロージング
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub frmOpenCheck_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        My.Settings.GetPath_MojiCode = Me.cmbMojiCode.SelectedIndex
        My.Settings.GetPath_SrcPath = Me.txtInputFolderName.Text
        My.Settings.GetPath_DstPath = Me.txtOutputFileName.Text
        My.Settings.GetPath_rbFolder = Me.rbFolder.Checked
        My.Settings.GetPath_rbComma = Me.rbComma.Checked
        My.Settings.GetPath_chkExt = Me.chkExt.Checked
        My.Settings.GetPath_txtExt = Me.cmbExt.Text
        My.Settings.GetPath_chkFileSize = Me.chkFileSize.Checked
        My.Settings.GetPath_chkFileCount = Me.chkFileCount.Checked
        My.Settings.GetPath_chkSkipEmpFolder = Me.chkSkipEmpFolder.Checked
        My.Settings.GetPath_chkFindHidden = Me.chkNotFindHidden.Checked
        My.Settings.GetPath_chkPathSplit = Me.chkPathSplit.Checked
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
    Private Sub txtBox_DragEnter(sender As Object, e As DragEventArgs) Handles txtInputFolderName.DragEnter, txtOutputFileName.DragEnter
        e.Effect = DragDropEffects.Copy
    End Sub

    ''' <summary>
    ''' テキストボックスドロップ時
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub txtImagePath_DragDrop(sender As Object, e As DragEventArgs) Handles txtInputFolderName.DragDrop, txtOutputFileName.DragDrop
        'コントロール内にドロップされた時実行される
        Dim strFile As String() = CType(e.Data.GetData(DataFormats.FileDrop, False), String())
        Dim txtControl As TextBox = CType(sender, TextBox)

        If txtControl.Name = "txtInputFolderName" Then
            If System.IO.Directory.Exists(strFile(0)) Then
                txtControl.Text = strFile(0)
            Else
                MessageBox.Show("エラー", "ドロップされたオブジェクトはフォルダではありません", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            If System.IO.File.Exists(strFile(0)) And (System.IO.Path.GetExtension(strFile(0)) = ".txt" Or System.IO.Path.GetExtension(strFile(0)) = ".csv") Then
                txtControl.Text = strFile(0)
            Else
                MessageBox.Show("エラー", "ドロップされたオブジェクトはテキストファイルではありません", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    ''' <summary>
    ''' フォルダ参照
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnOpenFolder_Click(sender As Object, e As EventArgs) Handles btnInputFolderOpen.Click
        Dim cofd As New Microsoft.WindowsAPICodePack.Dialogs.CommonOpenFileDialog

        If System.IO.Directory.Exists(Me.txtInputFolderName.Text) Then
            cofd.InitialDirectory = Me.txtInputFolderName.Text
        End If

        cofd.IsFolderPicker = True
        If cofd.ShowDialog() = Microsoft.WindowsAPICodePack.Dialogs.CommonFileDialogResult.Ok Then
            Me.txtInputFolderName.Text = cofd.FileName
        End If
    End Sub
    ''' <summary>
    ''' ファイル参照
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnOpenFile_Click(sender As Object, e As EventArgs) Handles btnOutputFileOpen.Click
        'SaveFileDialogクラスのインスタンスを作成
        Dim sfd As New SaveFileDialog()

        If Me.txtOutputFileName.Text <> "" Then
            If System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(Me.txtOutputFileName.Text)) Then
                sfd.InitialDirectory = System.IO.Path.GetDirectoryName(Me.txtOutputFileName.Text)
                sfd.FileName = System.IO.Path.GetFileName(Me.txtOutputFileName.Text)
            End If
        End If

        '[ファイルの種類]に表示される選択肢を指定する
        sfd.Filter = "CSVファイル(*.csv)|*.csv|TXTファイル(*.txt)|*.txt"
        sfd.FilterIndex = 1
        'タイトルを設定する
        sfd.Title = "保存先のファイルを選択してください"
        sfd.RestoreDirectory = True
        sfd.OverwritePrompt = True
        sfd.CheckPathExists = True

        'ダイアログを表示する
        If sfd.ShowDialog() = DialogResult.OK Then
            Me.txtOutputFileName.Text = sfd.FileName
        End If
    End Sub

    ''' <summary>
    ''' 開始ボタン
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnOpenCheck_Click(sender As Object, e As EventArgs) Handles btnStart.Click
        If Me.txtOutputFileName.Text = "" Or Me.txtInputFolderName.Text = "" Then
            MessageBox.Show("検索フォルダと出力ファイルを指定してください。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        EnableSwitch(True)

        Me.lblState.Text = "パスを取得しています。"

        'パス取得
        Dim Extensions As String() = New String() {}
        If Me.chkExt.Checked = True And Me.cmbExt.Text <> "" Then
            Dim orgExtensions As String() = Me.cmbExt.Text.Split(",")
            For i As Integer = 0 To orgExtensions.Count - 1
                ReDim Preserve Extensions(i + 1)
                Extensions(i) = "*." & orgExtensions(i)
            Next
        End If

        Dim Paths As String() = New String() {}

        If Me.rbFile.Checked = True Then
            Paths = GetFilesMostDeep(Me.txtInputFolderName.Text, Extensions)
        Else
            Paths = System.IO.Directory.GetDirectories(Me.txtInputFolderName.Text, "*", System.IO.SearchOption.AllDirectories).OrderBy(Function(fs) fs, New clsLogicalStringComparer()).ToArray()
        End If

        'プログレス
        Me.pgbFiles.Maximum = Paths.Count
        Me.pgbFiles.Value = 0
        Me.txtProgress.Text = Me.pgbFiles.Value & "/" & Me.pgbFiles.Maximum

        If Paths.Count = 0 Then
            MessageBox.Show("対象のパスが見つかりませんでした。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.lblState.Text = "対象のパスが見つかりませんでした。"
            EnableSwitch(False)
            Exit Sub
        End If

        If System.IO.File.Exists(Me.txtOutputFileName.Text) Then
            If MessageBox.Show("同名の出力ファイルが存在しています。上書きしてよろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.No Then
                Me.lblState.Text = "中止しました。"
                EnableSwitch(False)
                Exit Sub
            Else
                System.IO.File.Delete(Me.txtOutputFileName.Text)
            End If
        End If

        'デリミタ
        Dim Delimiter As String = IIf(Me.rbComma.Checked, ",", vbTab)

        Me.lblState.Text = "出力中です。"

        For iRow As Integer = 1 To Paths.Count
            System.Windows.Forms.Application.DoEvents()

            Dim FilePath As String = Paths(iRow - 1)

            Dim enc As System.Text.Encoding = System.Text.Encoding.GetEncoding(Me.cmbMojiCode.Text)

            'パスと分けて出力
            Dim strOutputPath As String
            If chkPathSplit.Checked = True Then
                strOutputPath = System.IO.Path.GetDirectoryName(FilePath) & Delimiter & System.IO.Path.GetFileName(FilePath)
            Else
                strOutputPath = FilePath
            End If

            '隠し属性チェック
            If chkNotFindHidden.Checked = True Then
                If Me.rbFile.Checked = True Then
                    'ファイルの場合
                    Dim attr As System.IO.FileAttributes = System.IO.File.GetAttributes(FilePath)
                    If (attr And System.IO.FileAttributes.Hidden) = System.IO.FileAttributes.Hidden Then
                        Me.pgbFiles.Maximum -= 1
                        Me.txtProgress.Text = Me.pgbFiles.Value & "/" & Me.pgbFiles.Maximum
                        Continue For
                    End If
                Else
                    'フォルダの場合
                    Dim attr As New System.IO.DirectoryInfo(FilePath)
                    If (attr.Attributes And System.IO.FileAttributes.Hidden) = System.IO.FileAttributes.Hidden Then
                        Me.pgbFiles.Maximum -= 1
                        Me.txtProgress.Text = Me.pgbFiles.Value & "/" & Me.pgbFiles.Maximum
                        Continue For
                    End If
                End If
            End If

            If Me.rbFile.Checked = True Then
                'ファイルのサイズを取得
                If Me.chkFileSize.Checked = True Then
                    Dim fi As New System.IO.FileInfo(FilePath)
                    Dim l As Long = fi.Length
                    System.IO.File.AppendAllText(Me.txtOutputFileName.Text, strOutputPath & Delimiter & Math.Ceiling(l / 1024) & " KB" & vbNewLine, enc)
                Else
                    System.IO.File.AppendAllText(Me.txtOutputFileName.Text, strOutputPath & vbNewLine, enc)
                End If
            Else
                'フォルダ単位のファイル数取得
                Dim FileCount As Integer = System.IO.Directory.GetFiles(FilePath, "*", System.IO.SearchOption.TopDirectoryOnly).Length
                '空フォルダスキップ
                If Me.chkSkipEmpFolder.Checked = False Or FileCount <> 0 Then
                    If chkFileCount.Checked = True Then
                        System.IO.File.AppendAllText(Me.txtOutputFileName.Text, strOutputPath & Delimiter & FileCount & vbNewLine, enc)
                    Else
                        System.IO.File.AppendAllText(Me.txtOutputFileName.Text, strOutputPath & vbNewLine, enc)
                    End If
                Else
                    Me.pgbFiles.Maximum -= 1
                    Me.txtProgress.Text = Me.pgbFiles.Value & "/" & Me.pgbFiles.Maximum
                    Continue For
                End If
            End If

            Me.pgbFiles.Value += 1
            Me.txtProgress.Text = Me.pgbFiles.Value & "/" & Me.pgbFiles.Maximum

            If CancelFlag = True Then
                MessageBox.Show("出力を中止しました。", "中止", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Me.lblState.Text = "中止しました。"
                CancelFlag = False
                EnableSwitch(False)
                Exit Sub
            End If

        Next

        MessageBox.Show("出力が完了しました。", "完了", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.lblState.Text = "完了"
        EnableSwitch(False)
    End Sub

    ''' <summary>
    ''' ファイル・フォルダの選択
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub RadioButton_CheckedChanged(sender As Object, e As EventArgs) Handles rbFile.CheckedChanged, MyBase.Load, rbComma.CheckedChanged, chkExt.CheckedChanged
        SearchOptionEnable()
    End Sub

    ''' <summary>
    ''' キャンセルボタン
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        CancelFlag = True
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
        Me.btnCancel.Enabled = DoingFlag
        Me.txtInputFolderName.Enabled = Not DoingFlag
        Me.txtOutputFileName.Enabled = Not DoingFlag
        Me.btnStart.Enabled = Not DoingFlag
        Me.btnInputFolderOpen.Enabled = Not DoingFlag
        Me.btnOutputFileOpen.Enabled = Not DoingFlag

        Me.cmbExt.Enabled = Not DoingFlag
        Me.chkExt.Enabled = Not DoingFlag
        Me.rbFile.Enabled = Not DoingFlag
        Me.rbFolder.Enabled = Not DoingFlag
        Me.rbComma.Enabled = Not DoingFlag
        Me.rbTab.Enabled = Not DoingFlag
        Me.chkFileSize.Enabled = Not DoingFlag
        Me.chkFileCount.Enabled = Not DoingFlag

        Me.chkSkipEmpFolder.Enabled = Not DoingFlag
        Me.cmbMojiCode.Enabled = Not DoingFlag

        Me.btnBackMenu.Enabled = Not DoingFlag

        SearchOptionEnable()
    End Sub

    ''' <summary>
    ''' 検索オプションの有効無効
    ''' </summary>
    Private Sub SearchOptionEnable()
        If Me.rbFile.Checked = True Then
            Me.chkFileCount.Enabled = False
            Me.chkExt.Enabled = True
            Me.chkFileSize.Enabled = True
            Me.chkSkipEmpFolder.Enabled = False
            If Me.chkExt.Checked = True Then
                Me.cmbExt.Enabled = True
            Else
                Me.cmbExt.Enabled = False
            End If
        Else
            Me.chkFileCount.Enabled = True
            Me.chkExt.Enabled = False
            Me.cmbExt.Enabled = False
            Me.chkFileSize.Enabled = False
            Me.chkSkipEmpFolder.Enabled = True
        End If
    End Sub

#End Region
End Class