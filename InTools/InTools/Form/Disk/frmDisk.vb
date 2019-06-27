Public Class frmDisk
    'キャンセルフラグ
    Private canceled As Boolean = False
    'メニュー戻りフラグ
    Private BackMenuFlag As Boolean = False

    'ロード時
    Private Sub frmMain_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Me.txtInputPath.Text = My.Settings.Disk_InputPath
        Me.txtOutputPath.Text = My.Settings.Disk_OutputPath
        Me.cmbDiskType.SelectedIndex = My.Settings.Disk_DiskType
        Me.cmbFormula.SelectedIndex = My.Settings.Disk_Formula

        Select Case Me.cmbDiskType.Text
            Case "BD-R"
                My.Settings.Disk_DiskSize = 50050629632
            Case "DVD-R"
                My.Settings.Disk_DiskSize = 4706074624
            Case "CD-R"
                My.Settings.Disk_DiskSize = 736958464
        End Select

        Dim stDiskSize As String = String.Format("{0:#,0}", Long.Parse(My.Settings.Disk_DiskSize))
        Me.lblDiskSize.Text = stDiskSize
        Me.tsLabel.Text = "指定のディスクサイズでフォルダ分けをします。"

        'キャンセルボタンを無効
        Me.btnCancel.Enabled = False


    End Sub

    '終了時
    Private Sub frmMain_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing

        My.Settings.Disk_InputPath = Me.txtInputPath.Text
        My.Settings.Disk_OutputPath = Me.txtOutputPath.Text
        My.Settings.Disk_DiskType = Me.cmbDiskType.SelectedIndex
        My.Settings.Disk_Formula = Me.cmbFormula.SelectedIndex
        My.Settings.Save()
        If BackMenuFlag = False Then
            Application.Exit()
        End If

    End Sub

    ''' <summary>
    ''' フォルダ参照
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnOpenFolder_Click(sender As Object, e As EventArgs) Handles btnInput.Click, btnOutput.Click
        Dim cofd As New Microsoft.WindowsAPICodePack.Dialogs.CommonOpenFileDialog
        If CType(sender, Button).Name = "btnInput" Then
            If System.IO.Directory.Exists(Me.txtInputPath.Text) Then
                cofd.InitialDirectory = Me.txtInputPath.Text
            End If
        Else
            If System.IO.Directory.Exists(Me.txtOutputPath.Text) Then
                cofd.InitialDirectory = Me.txtOutputPath.Text
            End If
        End If

        cofd.IsFolderPicker = True
        If cofd.ShowDialog() = Microsoft.WindowsAPICodePack.Dialogs.CommonFileDialogResult.Ok Then
            If CType(sender, Button).Name = "btnInput" Then
                Me.txtInputPath.Text = cofd.FileName
            Else
                Me.txtOutputPath.Text = cofd.FileName
            End If
        End If
    End Sub

    'ドラッグドロップ処理
    Private Sub txtInCombine_DragEnter(sender As System.Object, e As System.Windows.Forms.DragEventArgs) Handles txtInputPath.DragEnter, txtOutputPath.DragEnter
        'コントロール内にドロップされた時実行される
        Dim strFile As String() = CType(e.Data.GetData(DataFormats.FileDrop, False), String())

        If System.IO.Directory.Exists(strFile(0)) Then
            'ドラッグされたデータ形式を調べ、ファイル・フォルダの時はコピーとする
            e.Effect = DragDropEffects.Copy
        Else
            'ファイル以外は受け付けない
            e.Effect = DragDropEffects.None
        End If

    End Sub

    Private Sub txtInCombine_DragDrop(sender As System.Object, e As System.Windows.Forms.DragEventArgs) Handles txtInputPath.DragDrop, txtOutputPath.DragDrop
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

    '処理開始
    Private Sub btnStart_Click(sender As System.Object, e As System.EventArgs) Handles btnStart.Click
        'リストボックスをリセット
        Me.lstResult.Items.Clear()

        If Not System.IO.Directory.Exists(Me.txtInputPath.Text) Then
            MessageBox.Show("   読込フォルダが存在しません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'ステータスバーに進捗状況出力
            Me.C1StatusBar.Text = "処理中断"
            Exit Sub
        End If
        If Not System.IO.Directory.Exists(Me.txtOutputPath.Text) Then
            MessageBox.Show("出力フォルダが存在しません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'ステータスバーに進捗状況出力
            Me.C1StatusBar.Text = "処理中断"
            Exit Sub
        End If
        If Me.cmbDiskType.Text = "" Then
            MessageBox.Show("ディスクタイプを選択してください。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'ステータスバーに進捗状況出力
            Me.C1StatusBar.Text = "処理中断"
            Exit Sub
        End If
        If Me.cmbFormula.Text = "" Then
            MessageBox.Show("振り分け方式を選択してください。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'ステータスバーに進捗状況出力
            Me.C1StatusBar.Text = "処理中断"
            Exit Sub
        End If

        If MessageBox.Show("振り分け処理を開始します" & vbNewLine & "よろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
            'ステータスバーに進捗状況出力
            Me.C1StatusBar.Text = "処理中断"
            Exit Sub
        End If
        '読込フォルダ内ファイルパス取得
        Dim aryOutExtensions As String() = My.Settings.Disk_OutExtension.Split(","c)
        '検索拡張子が指定されていない場合終了する。
        If aryOutExtensions(0) = "" Then
            MessageBox.Show("書き込み拡張子を指定してください。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            'ステータスバーに進捗状況出力
            Me.C1StatusBar.Text = "処理中断"
            Exit Sub
        End If

        EnableSwitch(True)

        'ボリュームフォルダ名（カウント）
        Dim VolFolder As Integer = 1
        '合計ファイルサイズ
        Dim VolFolderSize As Long = 0
        'ディスクサイズ
        Dim DiskSize As Long = My.Settings.Disk_DiskSize

        'ステータスバーに進捗状況出力
        Me.C1StatusBar.Text = "読込中..."
        '待機中のイベントを処理する
        Application.DoEvents()

        If Me.cmbFormula.Text = "ディスクサイズ優先" Then
            Dim InputFilePath As String() = GetFilesMostDeep(Me.txtInputPath.Text, aryOutExtensions)
            'プログレスバーを初期化する。
            Me.tsProgressBar.Maximum = InputFilePath.Length
            Me.tsProgressBar.Value = 0
            Me.tsProgressBar.Minimum = 0

            'ステータスバーに進捗状況出力
            Me.C1StatusBar.Text = "処理中(" & tsProgressBar.Value & "/" & tsProgressBar.Maximum & ")"
            For i As Integer = 0 To InputFilePath.Length - 1

                'ファイルサイズ取得
                Dim fi As New System.IO.FileInfo(InputFilePath(i))
                    Dim FileSize As Long = fi.Length

                    Dim SubFolder As String = System.IO.Path.GetDirectoryName(InputFilePath(i))
                    SubFolder = SubFolder.Replace(Me.txtInputPath.Text, "")
                    VolFolderSize += FileSize
                    Dim DestFolder As String = Me.txtOutputPath.Text & "\" & VolFolder.ToString("D4") & "\" & SubFolder

                Try
                    If VolFolderSize <= DiskSize Then
                        'ボリュームフォルダがディスクサイズ以下の場合
                        System.IO.Directory.CreateDirectory(DestFolder)
                        System.IO.File.Copy(InputFilePath(i), DestFolder & "\" & System.IO.Path.GetFileName(InputFilePath(i)))

                    Else
                        'ボリュームフォルダがディスクサイズ以上の場合
                        VolFolder += 1
                        VolFolderSize = FileSize
                        DestFolder = Me.txtOutputPath.Text & "\" & VolFolder.ToString("D4") & "\" & SubFolder
                        System.IO.Directory.CreateDirectory(DestFolder)
                        System.IO.File.Copy(InputFilePath(i), DestFolder & "\" & System.IO.Path.GetFileName(InputFilePath(i)))

                    End If

                    'リストボックスに進捗状況出力
                    WriteLstResult(lstResult, "コピー完了" & vbTab & ".." & InputFilePath(i).Replace(Me.txtInputPath.Text, ""), ResultMark.InformationMark)

                Catch ex As Exception
                    MessageBox.Show(ex.Message, "システムエラー")
                    'リストボックスに進捗状況出力
                    WriteLstResult(lstResult, "コピーエラー" & vbTab & ".." & InputFilePath(i).Replace(Me.txtInputPath.Text, ""), ResultMark.ErrorMark)
                End Try
                If canceled = True Then
                    'キャンセルされた時
                    MessageBox.Show("変換をキャンセルしました。")
                    Me.C1StatusBar.Text = "処理中断"
                    EnableSwitch(False)
                    Exit Sub
                End If

                'プログレスバーカウント
                Me.tsProgressBar.Value += 1
                Me.C1StatusBar.Text = "処理完了(" & tsProgressBar.Value & "/" & tsProgressBar.Maximum & ")"

            Next

        ElseIf Me.cmbFormula.Text = "フォルダ区切り優先" Then
            '読込フォルダ直下のフォルダを読み込む
            Dim subFolders As String() = System.IO.Directory.GetDirectories(Me.txtInputPath.Text, "*", System.IO.SearchOption.TopDirectoryOnly)
            Dim ordFolders As String() = subFolders.OrderBy(Function(fs) fs, New clsLogicalStringComparer()).ToArray()
            '読込フォルダ内のファイルをすべて読み込む
            Dim allFiles As String() = GetFilesMostDeep(Me.txtInputPath.Text, aryOutExtensions)
            '初回フラグ
            Dim FirstFlag As Boolean = True
            'プログレスバーを初期化する。
            Me.tsProgressBar.Maximum = allFiles.Length
            Me.tsProgressBar.Value = 0
            Me.tsProgressBar.Minimum = 0


            'ステータスバーに進捗状況出力
            Me.C1StatusBar.Text = "処理中(" & tsProgressBar.Value & "/" & tsProgressBar.Maximum & ")"

            For i As Integer = 0 To ordFolders.Length - 1


                'フォルダサイズ取得
                Dim FolderSize As Long = 0
                    Dim Files As String() = GetFilesMostDeep(ordFolders(i), aryOutExtensions)
                    For j As Integer = 0 To Files.Length - 1
                        Dim fi As New System.IO.FileInfo(Files(j))
                        Dim FileSize As Long = fi.Length
                        FolderSize += FileSize
                    Next
                'Dim subFolder As String = subFolders(i).Replace(Me.txtInputPath.Text, "")
                'Dim DestFolder As String = Me.txtOutputPath.Text & "\" & VolFolder.ToString("D4") & "\" & subFolder

                If FolderSize <= DiskSize Then
                    'サブフォルダサイズがディスクサイズ以下の場合
                    VolFolderSize += FolderSize
                    If VolFolderSize <= DiskSize Then
                        'ボリュームフォルダがディスクサイズ以下の場合
                        For l As Integer = 0 To Files.Length - 1
                            Try
                                Dim subFolder As String = System.IO.Path.GetDirectoryName(Files(l)).Replace(Me.txtInputPath.Text, "")
                                Dim DestFolder As String = Me.txtOutputPath.Text & "\" & VolFolder.ToString("D4") & "\" & subFolder
                                System.IO.Directory.CreateDirectory(DestFolder)
                                System.IO.File.Copy(Files(l), DestFolder & "\" & System.IO.Path.GetFileName(Files(l)))
                                'リストボックスに進捗状況出力
                                WriteLstResult(lstResult, "コピー完了" & vbTab & ".." & Files(l).Replace(Me.txtInputPath.Text, ""), ResultMark.InformationMark)
                                tsProgressBar.Value += 1
                                Me.C1StatusBar.Text = "処理中(" & tsProgressBar.Value & "/" & tsProgressBar.Maximum & ")"
                            Catch ex As Exception
                                MessageBox.Show(ex.Message, "システムエラー")
                                'リストボックスに進捗状況出力
                                WriteLstResult(lstResult, "コピーエラー" & vbTab & ".." & Files(l).Replace(Me.txtInputPath.Text, ""), ResultMark.ErrorMark)
                            End Try

                        Next


                    Else
                        'ボリュームフォルダがディスクサイズ以上の場合
                        VolFolder += 1
                        VolFolderSize = FolderSize

                        'My.Computer.FileSystem.CopyDirectory(subFolders(i), DestFolder)
                        For l As Integer = 0 To Files.Length - 1
                            Try
                                Dim subFolder As String = System.IO.Path.GetDirectoryName(Files(l)).Replace(Me.txtInputPath.Text, "")
                                Dim DestFolder As String = Me.txtOutputPath.Text & "\" & VolFolder.ToString("D4") & "\" & subFolder
                                System.IO.Directory.CreateDirectory(DestFolder)
                                System.IO.File.Copy(Files(l), DestFolder & "\" & System.IO.Path.GetFileName(Files(l)))
                                'リストボックスに進捗状況出力
                                WriteLstResult(lstResult, "コピー完了" & vbTab & ".." & Files(l).Replace(Me.txtInputPath.Text, ""), ResultMark.InformationMark)
                                tsProgressBar.Value += 1
                                Me.C1StatusBar.Text = "処理中(" & tsProgressBar.Value & "/" & tsProgressBar.Maximum & ")"
                            Catch ex As Exception
                                MessageBox.Show(ex.Message, "システムエラー")
                                'リストボックスに進捗状況出力
                                WriteLstResult(lstResult, "コピーエラー" & vbTab & ".." & Files(l).Replace(Me.txtInputPath.Text, ""), ResultMark.ErrorMark)
                            End Try

                        Next


                    End If
                    '初回フラグをFalseにする。
                    FirstFlag = False
                Else
                    'サブフォルダサイズがディスクサイズ以上の場合
                    If FirstFlag = False Then
                        '初回フラグが立っていない場合
                        VolFolder += 1
                        VolFolderSize = 0
                    End If

                    For k As Integer = 0 To Files.Length - 1
                        Dim fi As New System.IO.FileInfo(Files(k))
                        Dim FileSize As Long = fi.Length
                        VolFolderSize += FileSize
                        Dim subFolder As String = System.IO.Path.GetDirectoryName(Files(k)).Replace(Me.txtInputPath.Text, "")
                        Dim DestFolder As String = Me.txtOutputPath.Text & "\" & VolFolder.ToString("D4") & "\" & subFolder
                        Try
                            If VolFolderSize <= DiskSize Then
                                'ボリュームフォルダがディスクサイズ以下の場合
                                System.IO.Directory.CreateDirectory(DestFolder)
                                System.IO.File.Copy(Files(k), DestFolder & "\" & System.IO.Path.GetFileName(Files(k)))
                                'リストボックスに進捗状況出力
                                WriteLstResult(lstResult, "コピー完了" & vbTab & ".." & Files(k).Replace(Me.txtInputPath.Text, ""), ResultMark.InformationMark)
                                tsProgressBar.Value += 1
                                Me.C1StatusBar.Text = "処理中(" & tsProgressBar.Value & "/" & tsProgressBar.Maximum & ")"
                            Else
                                'ボリュームフォルダがディスクサイズ以上の場合
                                VolFolder += 1
                                VolFolderSize = FileSize
                                DestFolder = Me.txtOutputPath.Text & "\" & VolFolder.ToString("D4") & "\" & subFolder
                                System.IO.Directory.CreateDirectory(DestFolder)
                                System.IO.File.Copy(Files(k), DestFolder & "\" & System.IO.Path.GetFileName(Files(k)))
                                'リストボックスに進捗状況出力
                                WriteLstResult(lstResult, "コピー完了" & vbTab & ".." & Files(k).Replace(Me.txtInputPath.Text, ""), ResultMark.InformationMark)
                                tsProgressBar.Value += 1
                                Me.C1StatusBar.Text = "処理中(" & tsProgressBar.Value & "/" & tsProgressBar.Maximum & ")"

                            End If

                        Catch ex As Exception
                            MessageBox.Show(ex.Message, "システムエラー")
                            'リストボックスに進捗状況出力
                            WriteLstResult(lstResult, "コピーエラー" & vbTab & ".." & Files(k).Replace(Me.txtInputPath.Text, ""), ResultMark.ErrorMark)
                        End Try
                    Next
                    '次のフォルダは必ず次のボリュームフォルダに格納する。
                    VolFolder += 1
                    VolFolderSize = 0

                    '初回フラグをTrueにする。
                    FirstFlag = True
                End If

                If canceled = True Then
                    'キャンセルされた時
                    MessageBox.Show("変換をキャンセルしました。")
                    Me.C1StatusBar.Text = "処理中断"
                    EnableSwitch(False)
                    Exit Sub
                End If
            Next
        End If

        lstResult.TopIndex = lstResult.Items.Count - 1
        lstResult.SelectedIndex = lstResult.Items.Count - 1
        EnableSwitch(False)
        'ステータスバーに進捗状況出力
        Me.C1StatusBar.Text = "処理完了(" & tsProgressBar.Value & "/" & tsProgressBar.Maximum & ")"
        MessageBox.Show("処理が完了しました。", "完了", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

    End Sub

    '検索拡張子
    Private Sub btnExtension_Click(sender As System.Object, e As System.EventArgs) Handles btnExtension.Click

        'Form2クラスのインスタンスを作成する
        Dim f As New frmExtension()
        'Form2を表示する
        'ここではモーダルダイアログボックスとして表示する
        'オーナーウィンドウにMeを指定する
        f.ShowDialog(Me)
        'フォームが必要なくなったところで、Disposeを呼び出す
        f.Dispose()
    End Sub

    'ディスクサイズ設定
    Private Sub btnDiskSize_Click(sender As System.Object, e As System.EventArgs) Handles btnDiskSize.Click
        'Form2クラスのインスタンスを作成する
        Dim f As New frmDiskSize()
        'Form2を表示する
        'ここではモーダルダイアログボックスとして表示する
        'オーナーウィンドウにMeを指定する
        f.ShowDialog(Me)
        'フォームが必要なくなったところで、Disposeを呼び出す
        f.Dispose()
    End Sub

    'キャンセルボタン押下時
    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        If MessageBox.Show("処理を中断します。" & vbNewLine & "よろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
            canceled = True
        End If

    End Sub

    '終了時処理
    Private Sub EnableSwitch(ByVal DoingFlag As Boolean)
        btnCancel.Enabled = DoingFlag
        btnStart.Enabled = Not DoingFlag
        btnInput.Enabled = Not DoingFlag
        btnOutput.Enabled = Not DoingFlag
        btnDiskSize.Enabled = Not DoingFlag
        btnExtension.Enabled = Not DoingFlag
        cmbDiskType.Enabled = Not DoingFlag
        cmbFormula.Enabled = Not DoingFlag
        btnBackMenu.Enabled = Not DoingFlag
    End Sub


    'ディスクタイプ変更時
    Private Sub cmbDiskType_TextChanged(sender As System.Object, e As System.EventArgs) Handles cmbDiskType.TextChanged
        My.Settings.Disk_DiskType = Me.cmbDiskType.SelectedIndex
        My.Settings.Disk_DiskSize = 100
        Select Case Me.cmbDiskType.Text
            Case "BD-R"
                My.Settings.Disk_DiskSize = 50050629632
            Case "DVD-R"
                My.Settings.Disk_DiskSize = 4706074624
            Case "CD-R"
                My.Settings.Disk_DiskSize = 736958464
        End Select

        Dim stDiskSize As String = String.Format("{0:#,0}", Long.Parse(My.Settings.Disk_DiskSize))
        Me.lblDiskSize.Text = stDiskSize
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
End Class
