Imports C1.Win.FlexReport

Public Class frmScanLogChk

#Region "プライベート変数"
    Private BackMenuFlag As Boolean = False
    Dim iIndex As Integer = -1
    Dim htThumbnails As Hashtable = New Hashtable
    Dim ScanFolder As String = ""
    '出力フラグ
    Dim flgOutput As Boolean = True
    'shiftフラグ
    Dim flgShift As Boolean = False
    'キャンセルフラグ
    Dim flgCansel As Boolean = False

#End Region

#Region "キー操作"
    ''' <summary>
    ''' KeyDownイベントハンドラ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub KeyDown1(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown
        Me.fgrFileList.Select(iIndex, 0)
        'UP
        If e.KeyCode = Keys.Up Then
            iIndex -= 1
            If iIndex >= 1 Then
                ShowThumbnail(iIndex)
            Else
                iIndex = 1
                ShowThumbnail(iIndex)
            End If
            'スクロール
            If Me.fgrFileList.TopRow < iIndex Then
                Me.fgrFileList.Select(iIndex, 0, True)
            End If

        End If
        'Down
        If e.KeyCode = Keys.Down Then
            iIndex += 1
            If iIndex <= Me.fgrFileList.Rows.Count - 1 Then
                ShowThumbnail(iIndex)
            Else
                iIndex = Me.fgrFileList.Rows.Count - 1
                ShowThumbnail(iIndex)
            End If
            'スクロール
            If Me.fgrFileList.BottomRow >= iIndex Then
                Me.fgrFileList.Select(iIndex, 0, True)
            End If

        End If
        'PageUP
        If e.KeyCode = Keys.PageUp Then

            iIndex = iIndex - (Me.fgrThumbnail.Rows.Count * Me.fgrThumbnail.Cols.Count)
            If iIndex >= 1 Then
                ShowThumbnail(iIndex)
            Else
                iIndex = 1
                ShowThumbnail(iIndex)
            End If

            'スクロール
            If Me.fgrFileList.TopRow < iIndex Then
                Me.fgrFileList.Select(iIndex, 0, True)
            End If

        End If
        'PageDown
        If e.KeyCode = Keys.PageDown Then

            iIndex = iIndex + (Me.fgrThumbnail.Rows.Count * Me.fgrThumbnail.Cols.Count)
            If iIndex <= Me.fgrFileList.Rows.Count - 1 Then
                ShowThumbnail(iIndex)
            Else
                iIndex = Me.fgrFileList.Rows.Count - 1
                ShowThumbnail(iIndex)
            End If

            'スクロール
            If Me.fgrFileList.BottomRow >= iIndex Then
                Me.fgrFileList.Select(iIndex, 0, True)
            End If

        End If
        'Home
        If e.KeyCode = Keys.Home Then
            If fgrFileList.Rows.Count > 1 Then
                Me.fgrFileList.Select(1, 0, True)
            End If
        End If
        'End
        If e.KeyCode = Keys.End Then
            Me.fgrFileList.Select(fgrFileList.Rows.Count - 1, 0, True)
        End If

        'フラグキー
        If e.KeyCode = Keys.O Or e.KeyCode = Keys.R Or e.KeyCode = Keys.A Or e.KeyCode = Keys.D Then
            If Not Me.fgrFileList.Rows(iIndex)("No.") = "Add" Then
                Select Case e.KeyCode
                    Case Keys.O
                        Me.fgrFileList.Rows(iIndex)("OK") = Not Me.fgrFileList.Rows(iIndex)("OK")
                        DBWrite(5)
                    Case Keys.R
                        Me.fgrFileList.Rows(iIndex)("差替") = Not Me.fgrFileList.Rows(iIndex)("差替")
                        DBWrite(6)
                    Case Keys.A
                        Me.fgrFileList.Rows(iIndex)("追加") = Not Me.fgrFileList.Rows(iIndex)("追加")
                        DBWrite(7)
                    Case Keys.D
                        Me.fgrFileList.Rows(iIndex)("削除") = Not Me.fgrFileList.Rows(iIndex)("削除")
                        DBWrite(8)
                End Select
            End If
        End If
        e.Handled = True
    End Sub

#End Region

#Region "フォームイベント"
    ''' <summary>
    ''' フォームロード
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub frmAlibi_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' RasterSupport.SetLicense(Application.StartupPath & "\License\LEAD175ImgSuite.lic", "+sxwXvpT1JbgbQ7DAdF9k8WRWcBnLgwIjN2a3sVpuzOIoMTYIWPT13qYg3qhCnFE")

        Me.txtSrcPath.Text = My.Settings.LogChk_SrcPath
        Me.txtDstPath.Text = My.Settings.LogChk_DstPath
        Me.fgrFileList.Rows.Count = 1

        '行数
        Me.fgrThumbnail.Rows.Count = Me.nudThumRow.Value
        '列数
        Me.fgrThumbnail.Cols.Count = Me.nudThumCol.Value

        ' カスタムスタイルを追加
        Me.fgrFileList.Styles.Add("Normal")
        Me.fgrFileList.Styles("Normal").BackColor = Color.White
        Me.fgrFileList.Styles.Add("Warnning")
        Me.fgrFileList.Styles("Warnning").BackColor = Color.Yellow
        Me.fgrFileList.Styles.Add("Error")
        Me.fgrFileList.Styles("Error").BackColor = Color.Red

        Me.fgrFileList.Styles.Add("OK")
        Me.fgrFileList.Styles("OK").BackColor = Color.LightYellow
        Me.fgrFileList.Styles.Add("Rep")
        Me.fgrFileList.Styles("Rep").BackColor = Color.LightBlue
        Me.fgrFileList.Styles.Add("Add")
        Me.fgrFileList.Styles("Add").BackColor = Color.LightPink
        Me.fgrFileList.Styles.Add("Del")
        Me.fgrFileList.Styles("Del").BackColor = Color.LightGray

        'Me.fgrFileList.Styles.Add("Select")
        'Me.fgrFileList.Styles("Select").BackColor = Color.FromArgb(&HB7, &HDB, &HFF)

        Me.fgrThumbnail.Styles.Add("Select")
        Me.fgrThumbnail.Styles("Select").BackColor = Color.FromArgb(&HB7, &HDB, &HFF)

    End Sub
    ''' <summary>
    ''' フォームクローズ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub frmAlibi_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        My.Settings.LogChk_SrcPath = Me.txtSrcPath.Text
        My.Settings.LogChk_DstPath = Me.txtDstPath.Text
        My.Settings.Save()

        If BackMenuFlag = False Then
            If CInt(Me.txtremWarnning.Text) <> 0 Then
                If MessageBox.Show("ワーニングが残留しています。" & vbNewLine & "終了してもよろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                    e.Cancel = True
                End If
            End If
        End If
    End Sub

    Private Sub frmScanLogChk_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        If BackMenuFlag = False Then
            Application.Exit()
        End If
    End Sub

#End Region
#Region "オブジェクトイベント"
    ''' <summary>
    ''' フォルダ参照
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnOpenFolder_Click(sender As Object, e As EventArgs) Handles btnInputFolderOpen.Click, btnOutputFolderOpen.Click
        Dim cofd As New Microsoft.WindowsAPICodePack.Dialogs.CommonOpenFileDialog
        If CType(sender, Button).Name = "btnInputFolderOpen" Then
            If System.IO.Directory.Exists(Me.txtSrcPath.Text) Then
                cofd.InitialDirectory = Me.txtSrcPath.Text
            End If
        Else
            If System.IO.Directory.Exists(Me.txtDstPath.Text) Then
                cofd.InitialDirectory = Me.txtDstPath.Text
            End If
        End If

        cofd.IsFolderPicker = True
        If cofd.ShowDialog() = Microsoft.WindowsAPICodePack.Dialogs.CommonFileDialogResult.Ok Then
            If CType(sender, Button).Name = "btnInputFolderOpen" Then
                Me.txtSrcPath.Text = cofd.FileName
            Else
                Me.txtDstPath.Text = cofd.FileName
            End If
        End If
    End Sub

    ''' <summary>
    ''' テキストボックスドラッグ時
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub txtBox_DragEnter(sender As Object, e As DragEventArgs) Handles txtDstPath.DragEnter, txtSrcPath.DragEnter
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
    Private Sub txtImagePath_DragDrop(sender As Object, e As DragEventArgs) Handles txtDstPath.DragDrop, txtSrcPath.DragDrop
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
    ''' セル編集前
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub fgrFileList_BeforeEdit(sender As Object, e As C1.Win.C1FlexGrid.RowColEventArgs) Handles fgrFileList.BeforeEdit
        'Add行は編集不可
        If sender.Rows(e.Row)("No.") = "Add" Then
            e.Cancel = True
        End If
    End Sub

    ''' <summary>
    ''' チェック開始
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click
        If Not System.IO.Directory.Exists(Me.txtSrcPath.Text) Then
            MessageBox.Show("スキャンフォルダが存在しません。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If
        If MessageBox.Show("スキャンログチェックを開始します。" & vbNewLine & "よろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
            Exit Sub
        End If

        EnableSwitch(False)
        flgOutput = False

        'ドライブパスの場合ネットワークパスに置換する。
        Dim DriveName As String = GetRecoveryDrive(My.Settings.Rcv_Drive)
        ScanFolder = Me.txtSrcPath.Text.Replace(DriveName, My.Settings.LogChk_NetPath)

        iIndex = -1
        Me.fgrFileList.Rows.Count = 1
        Me.txtFileCount.Text = 0
        Me.txtremWarnning.Text = 0
        Me.txtcntWarnning.Text = 0

        Dim srcFiles As String() = GetFilesMostDeep(ScanFolder, {"*.jpg", "*.tif"})
        Dim befScanNum As Integer = 0

        'プログレス
        Me.pgbFiles.Minimum = 0
        Me.pgbFiles.Value = 0
        Me.pgbFiles.Maximum = srcFiles.Count
        Me.txtProgress.Text = Me.pgbFiles.Value & "/" & Me.pgbFiles.Maximum

        Dim FileCounter As Integer = 0
        Dim ImageCounter As Integer = 0
        Dim PageCounter As Integer = 0

        Dim befSubFoldername As String = ""
        Dim befImageCounter As Integer = 0
        '差分の累計
        Dim cumImageCounter As Integer = 0

        Dim sqlProcess As New SQLProcess
        Dim strSQL As String = "SELECT * FROM T_ScanLogChk"
        strSQL &= " WHERE ファイルパス LIKE '" & ScanFolder & "\%'"
        Dim dtImportRow As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)

        Me.fgrFileList.BeginUpdate()

        For i As Integer = 0 To srcFiles.Count - 1
            If flgCansel = True Then
                'キャンセルボタン押下時
                Me.fgrFileList.Rows.Count = 1
                Me.fgrFileList.EndUpdate()
                MessageBox.Show("チェックを中止しました。", "キャンセル", MessageBoxButtons.OK, MessageBoxIcon.Information)
                EnableSwitch(True)
                flgCansel = False
                Exit Sub
            End If

            If System.IO.Path.GetDirectoryName(srcFiles(i)) = ScanFolder Then
                ScanFolder = System.IO.Path.GetDirectoryName(ScanFolder)
            End If
            Dim SubFolderName As String = System.IO.Path.GetDirectoryName(srcFiles(i).Replace(ScanFolder & "\", ""))
            Dim ImageFileName As String = System.IO.Path.GetFileName(srcFiles(i))

            Dim splImageFileName As String() = System.IO.Path.GetFileNameWithoutExtension(ImageFileName).Split(GetFileNameDelimita(My.Settings.LogChk_FileName_delimita))
            'ファイルカウンター,読取時のカウンター（画像単位）,読取時のカウンター（原稿単位）
            Dim AcFileCounter As Integer = CInt(splImageFileName(My.Settings.LogChk_FCCol - 1))
            Dim AcImageCounter As Integer = CInt(splImageFileName(My.Settings.LogChk_ICCol - 1))
            Dim ACPageCounter As String = CInt(splImageFileName(My.Settings.LogChk_PCCol - 1))

            'フォルダ単位でファイルカウンターをリセット
            If SubFolderName <> befSubFoldername Then
                FileCounter = 0
                befImageCounter = AcImageCounter - 1
                ImageCounter = AcImageCounter - 1
                PageCounter = ACPageCounter
            Else
                'ページカウンターの増分は画像カウンターの累計が2になった場合のみ1
                '前画像カウンターとの差分
                Dim defImageCounter As Integer = AcImageCounter - befImageCounter
                '差分の累計
                cumImageCounter += defImageCounter
                If cumImageCounter = 2 Then
                    cumImageCounter = 0
                    PageCounter += 1
                End If
            End If

            'ファイルカウンターの増分は1
            FileCounter += 1
            'イメージカウンターの増分は1or2
            ImageCounter += 1


            Me.fgrFileList.Rows.Count += 1
            Me.txtFileCount.Text = CInt(Me.txtFileCount.Text) + 1

            Dim iRow As Integer = Me.fgrFileList.Rows.Count - 1

            Me.fgrFileList.Rows(iRow)("No.") = Me.fgrFileList.Rows.Count - 1
            Me.fgrFileList.Rows(iRow)("フォルダ名") = SubFolderName
            Me.fgrFileList.Rows(iRow)("ファイル名") = ImageFileName

            Dim dr() As DataRow = dtImportRow.Select("ファイルパス = '" & srcFiles(i) & "'")
            If dr.Length > 0 Then
                '既存データ
                Me.fgrFileList.Rows(iRow)("判定") = dr(0)("判定")
                Me.fgrFileList.Rows(iRow)("判定内容") = dr(0)("判定内容")
                Me.fgrFileList.Rows(iRow)("OK") = dr(0)("OK")
                Me.fgrFileList.Rows(iRow)("差替") = IIf(dr(0)("差替") = 0, False, True)
                Me.fgrFileList.Rows(iRow)("追加") = IIf(dr(0)("追加") = 0, False, True)
                Me.fgrFileList.Rows(iRow)("削除") = dr(0)("削除")
                Me.fgrFileList.Rows(iRow)("差替ID") = IIf(dr(0)("差替") = 0, "", "S" & CInt(dr(0)("差替")).ToString("D4"))
                Me.fgrFileList.Rows(iRow)("追加ID") = IIf(dr(0)("追加") = 0, "", "K" & CInt(dr(0)("追加")).ToString("D4"))
                Me.fgrFileList.Rows(iRow)("回転") = dr(0)("回転")

                SetBackColor(iRow)

                If Me.fgrFileList.Rows(iRow)("判定") <> "〇" Then
                    Me.txtcntWarnning.Text = CInt(Me.txtcntWarnning.Text) + 1
                    If Me.fgrFileList.Rows(iRow)("OK") = False Then
                        Me.txtremWarnning.Text = CInt(Me.txtremWarnning.Text) + 1
                    End If
                End If

            Else
                '新規データ
                '一致確認
                Dim WarnFlag As Boolean = False
                If AcFileCounter = FileCounter Then
                    If AcImageCounter = ImageCounter Or AcImageCounter = ImageCounter + 1 Then
                        If ACPageCounter = PageCounter Then
                            '全て一致が確認された場合
                            Me.fgrFileList.Rows(iRow)("判定") = "〇"
                            Me.fgrFileList.Rows(iRow)("判定内容") = "正常"
                            '前のレコードが△の場合□に変更する。
                            If Me.fgrFileList.Rows.Count > 2 Then
                                If Me.fgrFileList.Rows(iRow - 1)("判定") = "△" Then
                                    Me.fgrFileList.Rows(iRow)("判定") = "□"
                                    Me.fgrFileList.Rows(iRow)("判定内容") = "要検査(後)"
                                    Me.fgrFileList.Rows(iRow).Style = Me.fgrFileList.Styles("Warnning")
                                    Me.txtcntWarnning.Text = CInt(Me.txtcntWarnning.Text) + 1
                                    Me.txtremWarnning.Text = CInt(Me.txtremWarnning.Text) + 1
                                End If
                            End If
                        Else
                            Me.fgrFileList.Rows(iRow)("判定内容") = "要検査（Pカウント）"
                            WarnFlag = True
                        End If

                        '差分2の場合はイメージカウンターに+1する
                        If AcImageCounter = ImageCounter + 1 Then
                            ImageCounter += 1
                        End If
                    Else
                        Me.fgrFileList.Rows(iRow)("判定内容") = "要検査（Iカウント）"
                        WarnFlag = True
                    End If
                Else
                    Me.fgrFileList.Rows(iRow)("判定内容") = "要検査（Fカウント）"
                    WarnFlag = True
                End If

                'ワーニングがある場合
                If WarnFlag = True Then
                    Me.fgrFileList.Rows(iRow)("判定") = "△"
                    Me.fgrFileList.Rows(iRow).Style = Me.fgrFileList.Styles("Warnning")

                    '前のレコードが〇の場合前のレコードを□に変更する。
                    If Me.fgrFileList.Rows.Count > 2 Then
                        If Me.fgrFileList.Rows(iRow - 1)("判定") = "〇" Then
                            Me.fgrFileList.Rows(iRow - 1)("判定") = "□"
                            Me.fgrFileList.Rows(iRow - 1)("判定内容") = "要検査(前)"
                            Me.fgrFileList.Rows(iRow - 1).Style = Me.fgrFileList.Styles("Warnning")

                            strSQL = "UPDATE T_ScanLogChk"
                            strSQL &= " SET 判定 = '□',判定内容 = '要検査(前)' FROM T_ScanLogChk"
                            strSQL &= " WHERE ファイルパス = '" & srcFiles(i - 1) & "'"
                            sqlProcess.DB_UPDATE(strSQL)
                            Me.txtcntWarnning.Text = CInt(Me.txtcntWarnning.Text) + 1
                            Me.txtremWarnning.Text = CInt(Me.txtremWarnning.Text) + 1
                        End If
                    End If

                    FileCounter = AcFileCounter
                    ImageCounter = AcImageCounter
                    PageCounter = ACPageCounter
                    cumImageCounter = 0
                    Me.txtcntWarnning.Text = CInt(Me.txtcntWarnning.Text) + 1
                    Me.txtremWarnning.Text = CInt(Me.txtremWarnning.Text) + 1
                End If


                'DBに書き込み
                strSQL = "INSERT INTO T_ScanLogChk"
                strSQL &= " SELECT CASE WHEN MAX(ID) IS NULL THEN 1 ELSE MAX(ID) +1 END , '" & srcFiles(i) & "','" & Me.fgrFileList.Rows(iRow)("判定") & "','" & Me.fgrFileList.Rows(iRow)("判定内容") & "',0,0,0,0,0 FROM T_ScanLogChk"
                sqlProcess.DB_UPDATE(strSQL)

            End If

            befSubFoldername = SubFolderName
            befImageCounter = AcImageCounter


            Me.pgbFiles.Value += 1
            Me.txtProgress.Text = Me.pgbFiles.Value & "/" & Me.pgbFiles.Maximum
            System.Windows.Forms.Application.DoEvents()
        Next

        Me.fgrFileList.AutoSizeCols()
        Me.fgrFileList.EndUpdate()

        'DBRead(Me.fgrFileList)
        iIndex = 1
        ShowThumbnail(iIndex)
        MessageBox.Show("チェックが完了しました。", "完了", MessageBoxButtons.OK, MessageBoxIcon.Information)
        EnableSwitch(True)
    End Sub

    ''' <summary>
    ''' キャンセルボタン
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        flgCansel = True
    End Sub

    ''' <summary>
    ''' サムネイルグリッドクリック時
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub fgrThumbnail_Click(sender As Object, e As EventArgs) Handles fgrThumbnail.Click
        SelectThumbnail(Me.fgrThumbnail.Row, Me.fgrThumbnail.Col)
    End Sub

    ''' <summary>
    ''' リストグリッドクリック時
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub fgrFileList_Click(sender As System.Object, e As System.EventArgs) Handles fgrFileList.Click, fgrFileList.EnterCell
        If iIndex > 0 Then
            iIndex = Me.fgrFileList.Row   'クリックされたレコード
            ShowThumbnail(iIndex)
        End If
    End Sub

    '''' <summary>
    '''' グリッドダブルクリック時
    '''' </summary>
    '''' <param name="sender"></param>
    '''' <param name="e"></param>
    'Private Sub fgrFileList_DoubleClick(sender As System.Object, e As System.EventArgs) Handles fgrFileList.DoubleClick
    '    If iIndex > 0 Then
    '        If Me.fgrFileList.Rows(iIndex)("検査フラグ") = "検査済み" Then
    '            Me.fgrFileList.Rows(iIndex).Style = Me.fgrFileList.Styles("Done")

    '            Dim FilePath As String = Me.fgrFileList.Rows(iIndex)("フォルダ名") & "\" & Me.fgrFileList.Rows(iIndex)("ファイル名")

    '            Dim strSQL As String = "SELECT COUNT(*) FROM T_ScanLogChk_検査済み情報"
    '            strSQL &= " WHERE ファイルパス = '" & FilePath & "'"
    '            Dim sqlProcess As New SQLProcess
    '            Try
    '                Dim DBFIleCount As Integer = sqlProcess.DB_EXECUTE_SCALAR(strSQL)
    '                If DBFIleCount = 0 Then
    '                    strSQL = "INSERT INTO T_ScanLogChk_検査済み情報"
    '                    strSQL &= " SELECT CASE WHEN MAX(ID) IS NULL THEN 1 ELSE MAX(ID) +1 END , '" & FilePath & "' FROM T_ScanLogChk_検査済み情報"
    '                    sqlProcess.DB_UPDATE(strSQL)
    '                End If
    '            Catch ex As Exception
    '                MessageBox.Show(ex.Message)
    '            Finally
    '                sqlProcess.Close()
    '            End Try
    '        Else
    '            Select Case Me.fgrFileList.Rows(iIndex)("判定")
    '                Case "〇"
    '                    Me.fgrFileList.Rows(iIndex).Style = Me.fgrFileList.Styles("Normal")
    '                Case "□"
    '                    Me.fgrFileList.Rows(iIndex).Style = Me.fgrFileList.Styles("Warnning")
    '                Case "△", "×"
    '                    Me.fgrFileList.Rows(iIndex).Style = Me.fgrFileList.Styles("Error")
    '            End Select
    '        End If
    '        iIndex = Me.fgrFileList.Row   'クリックされたレコード
    '        ShowThumbnail(iIndex)
    '    End If

    '    Dim iPath As String = Me.fgrFileList.Rows(iIndex)("フォルダ名")
    '    Dim iFileName As String = Me.fgrFileList.Rows(iIndex)("ファイル名")
    '    '画像を表示する
    '    If Not iPath = Nothing Then
    '        Dim p As System.Diagnostics.Process = System.Diagnostics.Process.Start(iPath & "\" & iFileName)
    '    End If

    'End Sub

    ''' <summary>
    ''' ログ出力
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnLogOutput_Click(sender As Object, e As EventArgs) Handles btnLogOutput.Click
        If Not System.IO.Directory.Exists(Me.txtDstPath.Text) Then
            MessageBox.Show("ログフォルダが存在しません。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If
        If Me.fgrFileList.Rows.Count = 1 Then
            MessageBox.Show("スキャンログが読み込まれていません。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If

        Dim LogPath As String = Me.txtDstPath.Text & "\スキャンチェックログ_" & System.DateTime.Now.ToString("yyyyMMddHHmmdd") & ".log"

        'プログレス
        Me.pgbFiles.Minimum = 0
        Me.pgbFiles.Value = 0
        'Me.pgbFiles.Maximum = Me.fgrFileList.Rows.Count - 1
        Me.txtProgress.Text = Me.pgbFiles.Value & "/" & Me.pgbFiles.Maximum

        WriteLog(LogPath, "No." & vbTab & "ファイルパス" & vbTab & "判定" & vbTab & "判定内容" & vbTab & "OK" & vbTab & "差替" & vbTab & "追加" & vbTab & "削除" & vbTab & "差替ID" & vbTab & "追加ID" & vbTab & "回転")
        For i As Integer = 1 To Me.fgrFileList.Rows.Count - 1

            'Add行は出力しない
            If Not Me.fgrFileList.Rows(i)("No.") = "Add" Then
                WriteLog(LogPath, Me.fgrFileList.Rows(i)("No.") & vbTab &
                 ScanFolder & "\" &
                 Me.fgrFileList.Rows(i)("フォルダ名") & "\" &
                 Me.fgrFileList.Rows(i)("ファイル名") & vbTab &
                 Me.fgrFileList.Rows(i)("判定") & vbTab &
                 Me.fgrFileList.Rows(i)("判定内容") & vbTab &
                 Me.fgrFileList.Rows(i)("OK") & vbTab &
                 Me.fgrFileList.Rows(i)("差替") & vbTab &
                 Me.fgrFileList.Rows(i)("追加") & vbTab &
                 Me.fgrFileList.Rows(i)("削除") & vbTab &
                 Me.fgrFileList.Rows(i)("差替ID") & vbTab &
                 Me.fgrFileList.Rows(i)("追加ID") & vbTab &
                 Me.fgrFileList.Rows(i)("回転")
                 )
            End If
            Me.pgbFiles.Value += 1
            Me.txtProgress.Text = Me.pgbFiles.Value & "/" & Me.pgbFiles.Maximum
            System.Windows.Forms.Application.DoEvents()
        Next

        MessageBox.Show("ログの出力が完了しました。", "完了", MessageBoxButtons.OK, MessageBoxIcon.Information)
        flgOutput = True
    End Sub

    ''' <summary>
    ''' 読取オプション
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnOption_Click(sender As Object, e As EventArgs) Handles btnOption.Click
        Dim f As New frmScanLogOption()
        f.ShowDialog(Me)
        f.Dispose()
    End Sub

    ''' <summary>
    ''' セルのチェックボックスが変更されたとき
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub fgrFileList_CellChecked(sender As Object, e As C1.Win.C1FlexGrid.RowColEventArgs) Handles fgrFileList.CellChecked
        DBWrite(e.Col)
    End Sub

    ''' <summary>
    ''' 回転ボタンクリック
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnRotate_Click(sender As Object, e As EventArgs) Handles btnRotate180.Click, btnRotate270.Click, btnRotate90.Click
        Dim ImagePath As String = ScanFolder & "\" & Me.fgrFileList.Rows(iIndex)("フォルダ名") & "\" & Me.fgrFileList.Rows(iIndex)("ファイル名")

        If System.IO.File.Exists(ImagePath) Then
            Dim image As New ImageMagick.MagickImage(ImagePath)

            Select Case DirectCast(sender, Button).Name
                Case "btnRotate180"
                    Me.fgrFileList.Rows(iIndex)("回転") = (Me.fgrFileList.Rows(iIndex)("回転") + 180) Mod 360
                    image.Rotate(180)
                Case "btnRotate270"
                    Me.fgrFileList.Rows(iIndex)("回転") = (Me.fgrFileList.Rows(iIndex)("回転") + 270) Mod 360
                    image.Rotate(270)
                Case "btnRotate90"
                    Me.fgrFileList.Rows(iIndex)("回転") = (Me.fgrFileList.Rows(iIndex)("回転") + 90) Mod 360
                    image.Rotate(90)
            End Select

            image.Write(ImagePath)
            image.Dispose()
            ShowThumbnail(iIndex, True)

        End If

        DBWrite(-1)

    End Sub

    ''' <summary>
    ''' メニューに戻る
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnBackMenu_Click(sender As Object, e As EventArgs) Handles btnBackMenu.Click
        If CInt(Me.txtremWarnning.Text) <> 0 Then
            If MessageBox.Show("ワーニングが残留しています。" & vbNewLine & "終了してもよろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                Exit Sub
            End If
        End If

        Dim f As New frmMenu
        f.Show()
        BackMenuFlag = True
        Me.Close()
    End Sub

#End Region

#Region "プライベートメソッド"
    ''' <summary>
    ''' ログ書き込み
    ''' </summary>
    ''' <param name="LogPath"></param>
    ''' <param name="strWriteLog"></param>
    Private Sub WriteLog(ByVal LogPath As String, ByVal strWriteLog As String)
        Dim sw As New System.IO.StreamWriter(LogPath,
            True,
            System.Text.Encoding.GetEncoding("shift_jis"))
        sw.WriteLine(strWriteLog)
        '閉じる
        sw.Close()
    End Sub
    ''' <summary>
    ''' 有効無効切り替え
    ''' </summary>
    ''' <param name="Switch"></param>
    Private Sub EnableSwitch(ByVal Switch As Boolean)
        Me.btnBackMenu.Enabled = Switch
        Me.btnStart.Enabled = Switch
        Me.txtSrcPath.Enabled = Switch
        Me.txtDstPath.Enabled = Switch
        Me.btnLogOutput.Enabled = Switch
    End Sub

    ''' <summary>
    ''' サムネイル表示
    ''' </summary>
    ''' <param name="showIndex"></param>
    Private Sub ShowThumbnail(ByVal showIndex As Integer, Optional ByVal Reset As Boolean = False)
        If showIndex < 0 Then
            Exit Sub
        End If

        If Reset = True Then
            htThumbnails.Clear()
        End If

        Dim iPath As String = ScanFolder & "\" & Me.fgrFileList.Rows(showIndex)("フォルダ名")
        Dim iFileName As String = Me.fgrFileList.Rows(showIndex)("ファイル名")

        'すでに表示されている場合
        If htThumbnails.ContainsValue(iPath & "\" & iFileName) Then
            For iRow As Integer = 0 To Me.fgrThumbnail.Rows.Count - 1
                For iCol As Integer = 0 To Me.fgrThumbnail.Cols.Count - 1
                    If htThumbnails(iRow & "," & iCol) = iPath & "\" & iFileName Then
                        SelectThumbnail(iRow, iCol)
                        Exit Sub
                    End If
                Next
            Next
        End If

        Dim cellCount As Integer = Me.fgrThumbnail.Rows.Count * Me.fgrThumbnail.Cols.Count

        Dim modIndex As Integer = showIndex Mod cellCount
        If modIndex = 0 Then
            modIndex = cellCount
        End If

        Dim cntThumb As Integer = showIndex - modIndex + 1

        For iRow As Integer = 0 To Me.fgrThumbnail.Rows.Count - 1
            For iCol As Integer = 0 To Me.fgrThumbnail.Cols.Count - 1
                If cntThumb > Me.fgrFileList.Rows.Count - 1 Then
                    iPath = Nothing
                    iFileName = Nothing
                Else
                    iPath = ScanFolder & "\" & Me.fgrFileList.Rows(cntThumb)("フォルダ名")
                    iFileName = Me.fgrFileList.Rows(cntThumb)("ファイル名")
                End If

                If System.IO.File.Exists(iPath & "\" & iFileName) Then
                    'Dim img As Image = Image.FromFile(iPath & "\" & iFileName)
                    'Me.fgrThumbnail.SetCellImage(iRow, iCol, img)
                    'img.Dispose()

                    Using fs As System.IO.FileStream = System.IO.File.OpenRead(iPath & "\" & iFileName)
                        '画像の読み込み
                        Dim img As Image = Image.FromStream(fs, False, False)
                        'サムネイルの作成
                        Dim thumbs As Image = img.GetThumbnailImage(img.Width * 0.3, img.Height * 0.3, Nothing, IntPtr.Zero)

                        Me.fgrThumbnail.SetCellImage(iRow, iCol, thumbs)
                        img.Dispose()
                        'thumbs.Dispose()
                    End Using

                Else
                    Me.fgrThumbnail.SetCellImage(iRow, iCol, Nothing)
                End If
                htThumbnails(iRow & "," & iCol) = iPath & "\" & iFileName

                If showIndex = cntThumb Then
                    SelectThumbnail(iRow, iCol)
                End If

                cntThumb += 1

            Next
        Next

    End Sub

    ''' <summary>
    ''' サムネイル選択
    ''' </summary>
    ''' <param name="sctRow"></param>
    ''' <param name="sctCol"></param>
    Private Sub SelectThumbnail(ByVal sctRow As Integer, ByVal sctCol As Integer)
        Dim rg As C1.Win.C1FlexGrid.CellRange
        rg = fgrThumbnail.GetCellRange(0, 0, fgrThumbnail.Rows.Count - 1, fgrThumbnail.Cols.Count - 1)
        rg.Style = Nothing

        Me.fgrThumbnail.Select(sctRow, sctCol)
        rg = fgrThumbnail.GetCellRange(sctRow, sctCol)
        rg.Style = fgrThumbnail.Styles("Select")
    End Sub

    ''' <summary>
    ''' サムネイル数変更時
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub nudThumRow_ValueChanged(sender As Object, e As EventArgs) Handles nudThumRow.ValueChanged, nudThumCol.ValueChanged, fgrThumbnail.SizeChanged
        If Me.nudThumRow.Value <> 0 And Me.nudThumCol.Value <> 0 Then
            Me.fgrThumbnail.Rows.Count = Me.nudThumRow.Value
            Me.fgrThumbnail.Rows.MinSize = (Me.fgrThumbnail.Height - 6) / Me.nudThumRow.Value
            Me.fgrThumbnail.Rows.MaxSize = Me.fgrThumbnail.Rows.MinSize
            Me.fgrThumbnail.Cols.Count = Me.nudThumCol.Value
            Me.fgrThumbnail.Cols.MinSize = (Me.fgrThumbnail.Width - 6) / Me.nudThumCol.Value
            Me.fgrThumbnail.Cols.MaxSize = Me.fgrThumbnail.Cols.MinSize
        End If

        For i As Integer = 0 To Me.fgrThumbnail.Cols.Count - 1
            '列設定
            Me.fgrThumbnail.Cols(i).ImageAlign = C1.Win.C1FlexGrid.ImageAlignEnum.Scale
            Me.fgrThumbnail.Cols(i).ImageAlignFixed = C1.Win.C1FlexGrid.ImageAlignEnum.Scale
        Next

        htThumbnails.Clear()
        ShowThumbnail(iIndex)
    End Sub

    ''' <summary>
    ''' DBのフラグ情報を反映させる
    ''' </summary>
    ''' <param name="chkFlexGrid"></param>
    Private Sub DBRead(ByVal chkFlexGrid As C1.Win.C1FlexGrid.C1FlexGrid)

        Dim sqlProcess As New SQLProcess

        Try
            Me.fgrFileList.BeginUpdate()
            For iRow As Integer = 1 To chkFlexGrid.Rows.Count - 1
                Dim iPath As String = ScanFolder & "\" & Me.fgrFileList.Rows(iRow)("フォルダ名") & "\" & Me.fgrFileList.Rows(iRow)("ファイル名")
                'Dim flgOK As Integer = IIf(Me.fgrFileList.Rows(iRow)("OK"), 1, 0)
                'Dim flgRep As Integer = IIf(Me.fgrFileList.Rows(iRow)("差替"), 1, 0)
                'Dim flgAdd As Integer = IIf(Me.fgrFileList.Rows(iRow)("追加"), 1, 0)
                'Dim flgDel As Integer = IIf(Me.fgrFileList.Rows(iRow)("削除"), 1, 0)
                'Dim Rotate As Integer = Me.fgrFileList.Rows(iRow)("回転")
                Dim strSQL As String = "SELECT * FROM T_ScanLogChk"
                strSQL &= " WHERE ファイルパス = '" & iPath & "'"
                Dim DBFlag As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
                If DBFlag.Rows.Count = 1 Then
                    Me.fgrFileList.Rows(iRow)("OK") = DBFlag.Rows(0)("OK")
                    Me.fgrFileList.Rows(iRow)("差替") = IIf(DBFlag.Rows(0)("差替") = 0, False, True)
                    Me.fgrFileList.Rows(iRow)("追加") = IIf(DBFlag.Rows(0)("追加") = 0, False, True)
                    Me.fgrFileList.Rows(iRow)("削除") = DBFlag.Rows(0)("削除")
                    Me.fgrFileList.Rows(iRow)("差替ID") = IIf(DBFlag.Rows(0)("差替") = 0, "", "S" & CInt(DBFlag.Rows(0)("差替")).ToString("D4"))
                    Me.fgrFileList.Rows(iRow)("追加ID") = IIf(DBFlag.Rows(0)("追加") = 0, "", "K" & CInt(DBFlag.Rows(0)("追加")).ToString("D4"))
                    Me.fgrFileList.Rows(iRow)("回転") = DBFlag.Rows(0)("回転")
                End If

                If Me.fgrFileList.Rows(iRow)("判定") <> "〇" Then
                    'エラーカウント
                    Me.txtcntWarnning.Text = CInt(Me.txtcntWarnning.Text) + 1
                    If Me.fgrFileList.Rows(iRow)("OK") = False Then
                        '残留エラーカウント
                        Me.txtremWarnning.Text = CInt(Me.txtremWarnning.Text) + 1
                    End If
                End If

                SetBackColor(iRow)
            Next
            Me.fgrFileList.EndUpdate()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            sqlProcess.Close()
        End Try

    End Sub

    ''' <summary>
    ''' DB書込み
    ''' </summary>
    Private Sub DBWrite(ByVal chkCol As Integer)

        'OK,差替え,削除は共存させない
        If chkCol = 5 Or chkCol = 6 Or chkCol = 8 Then
            If Me.fgrFileList.Rows(iIndex)(chkCol) = True Then
                For i As Integer = 5 To 8
                    If i = 7 Then
                        Continue For
                    End If
                    If i <> chkCol Then
                        Me.fgrFileList.Rows(iIndex)(i) = False
                    End If
                Next
            End If
        End If


        Dim iPath As String = ScanFolder & "\" & Me.fgrFileList.Rows(iIndex)("フォルダ名") & "\" & Me.fgrFileList.Rows(iIndex)("ファイル名")
        Dim flgOK As Integer = IIf(Me.fgrFileList.Rows(iIndex)("OK"), 1, 0)
        Dim flgRep As Integer = IIf(Me.fgrFileList.Rows(iIndex)("差替"), 1, 0)
        Dim flgAdd As Integer = IIf(Me.fgrFileList.Rows(iIndex)("追加"), 1, 0)
        Dim flgDel As Integer = IIf(Me.fgrFileList.Rows(iIndex)("削除"), 1, 0)
        Dim Rotate As Integer = Me.fgrFileList.Rows(iIndex)("回転")



        SetBackColor(iIndex)

        Dim sqlProcess As New SQLProcess
        Try
            '差替の場合
            Dim strSQL As String = "SELECT COUNT(*) FROM T_ScanLogChk_差替リスト"
            strSQL &= " WHERE ファイルパス = '" & iPath & "'"
            Dim ExistCount As Integer = sqlProcess.DB_EXECUTE_SCALAR(strSQL)
            Dim RepID As Integer = 0
            If flgRep = 1 Then
                If ExistCount = 0 Then
                    '歯抜けのIDで追加
                    strSQL = "INSERT INTO T_ScanLogChk_差替リスト"
                    strSQL &= " SELECT ISNULL(MIN(ID + 1), 1) AS 歯抜けの番号"
                    strSQL &= " , 0"
                    strSQL &= " , '" & iPath & "'"
                    strSQL &= " FROM T_ScanLogChk_差替リスト"
                    strSQL &= " WHERE ISNULL((ID + 1), 1) NOT IN ( SELECT ID FROM T_ScanLogChk_差替リスト)"
                    sqlProcess.DB_UPDATE(strSQL)
                End If
                strSQL = "SELECT ID FROM T_ScanLogChk_差替リスト"
                strSQL &= " WHERE ファイルパス = '" & iPath & "'"
                RepID = sqlProcess.DB_EXECUTE_SCALAR(strSQL)
                Me.fgrFileList.Rows(iIndex)("差替ID") = "S" & RepID.ToString("D4")
            Else
                If ExistCount = 1 Then
                    '削除
                    strSQL = "DELETE FROM T_ScanLogChk_差替リスト"
                    strSQL &= " WHERE ファイルパス = '" & iPath & "'"
                    sqlProcess.DB_UPDATE(strSQL)
                End If
                Me.fgrFileList.Rows(iIndex)("差替ID") = ""
            End If

            '追加の場合
            strSQL = "SELECT COUNT(*) FROM T_ScanLogChk_追加リスト"
            strSQL &= " WHERE ファイルパス = '" & iPath & "'"
            ExistCount = sqlProcess.DB_EXECUTE_SCALAR(strSQL)
            Dim AddID As Integer = 0
            If flgAdd = 1 Then
                If ExistCount = 0 Then
                    '歯抜けのIDで追加
                    strSQL = "INSERT INTO T_ScanLogChk_追加リスト"
                    strSQL &= " SELECT ISNULL(MIN(ID + 1), 1) AS 歯抜けの番号"
                    strSQL &= " , 0"
                    strSQL &= " , '" & iPath & "'"
                    strSQL &= " FROM T_ScanLogChk_追加リスト"
                    strSQL &= " WHERE ISNULL((ID + 1), 1) NOT IN ( SELECT ID FROM T_ScanLogChk_追加リスト)"
                    sqlProcess.DB_UPDATE(strSQL)
                End If
                strSQL = "SELECT ID FROM T_ScanLogChk_追加リスト"
                strSQL &= " WHERE ファイルパス = '" & iPath & "'"
                AddID = sqlProcess.DB_EXECUTE_SCALAR(strSQL)
                Me.fgrFileList.Rows(iIndex)("追加ID") = "K" & AddID.ToString("D4")
            Else
                If ExistCount = 1 Then
                    '削除
                    strSQL = "DELETE FROM T_ScanLogChk_追加リスト"
                    strSQL &= " WHERE ファイルパス = '" & iPath & "'"
                    sqlProcess.DB_UPDATE(strSQL)
                    Me.fgrFileList.Rows(iIndex)("追加ID") = ""
                End If
            End If

            ''フラグテーブルを更新
            'strSQL = "SELECT COUNT(*) FROM T_ScanLogChk"
            'strSQL &= " WHERE ファイルパス = '" & iPath & "'"
            'ExistCount = sqlProcess.DB_EXECUTE_SCALAR(strSQL)
            'If ExistCount = 0 Then
            '    'DBに存在しない場合
            '    strSQL = "INSERT INTO T_ScanLogChk"
            '    strSQL &= " SELECT CASE WHEN MAX(ID) IS NULL THEN 1 ELSE MAX(ID) +1 END , '" & iPath & "'," & flgOK & "," & RepID & "," & AddID & "," & flgDel & "," & Rotate & " FROM T_ScanLogChk"
            '    sqlProcess.DB_UPDATE(strSQL)
            'Else
            'DBに存在する場合
            strSQL = "UPDATE T_ScanLogChk"
            strSQL &= " SET OK = " & flgOK & ", 差替 = " & RepID & ", 追加 = " & AddID & ", 削除 = " & flgDel & ", 回転 = " & Rotate & " FROM T_ScanLogChk"
            strSQL &= " WHERE ファイルパス = '" & iPath & "'"
            sqlProcess.DB_UPDATE(strSQL)
            'End If

            ''削除をチェックした場合選択範囲全てに反映させる
            'If chkCol = 8 Then
            '    Dim LastiIndex As Integer = Me.fgrFileList.RowSel
            '    For i As Integer = chkPathRow + 1 To LastiIndex
            '        Me.fgrFileList.Rows(i)(chkCol) = Me.fgrFileList.Rows(chkPathRow)(chkCol)
            '        iPath = ScanFolder & "\" & Me.fgrFileList.Rows(i)("フォルダ名") & "\" & Me.fgrFileList.Rows(i)("ファイル名")

            '        'フラグテーブルを更新
            '        strSQL = "SELECT COUNT(*) FROM T_ScanLogChk"
            '        strSQL &= " WHERE ファイルパス = '" & iPath & "'"
            '        ExistCount = sqlProcess.DB_EXECUTE_SCALAR(strSQL)

            '        If ExistCount = 0 Then
            '            'DBに存在しない場合
            '            strSQL = "INSERT INTO T_ScanLogChk"
            '            strSQL &= " SELECT CASE WHEN MAX(ID) IS NULL THEN 1 ELSE MAX(ID) +1 END , '" & iPath & "',0,0,0," & flgDel & " FROM T_ScanLogChk"
            '            sqlProcess.DB_UPDATE(strSQL)
            '        Else
            '            'DBに存在する場合
            '            strSQL = "UPDATE T_ScanLogChk"
            '            strSQL &= " SET 削除 = " & flgDel & " FROM T_ScanLogChk"
            '            strSQL &= " WHERE ファイルパス = '" & iPath & "'"
            '            sqlProcess.DB_UPDATE(strSQL)
            '        End If
            '    Next
            'End If

            'OK

            If Me.fgrFileList.Rows(iIndex)("判定") <> "〇" And chkCol = 5 Then
                If flgOK = 1 Then
                    Me.txtremWarnning.Text = CInt(Me.txtremWarnning.Text) - 1
                Else
                    Me.txtremWarnning.Text = CInt(Me.txtremWarnning.Text) + 1
                End If
            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            sqlProcess.Close()
        End Try

    End Sub

    ''' <summary>
    ''' セル背景色
    ''' </summary>
    ''' <param name="SetRow"></param>
    Private Sub SetBackColor(ByVal SetRow As Integer)
        Dim iPath As String = ScanFolder & "\" & Me.fgrFileList.Rows(SetRow)("フォルダ名") & "\" & Me.fgrFileList.Rows(SetRow)("ファイル名")
        Dim flgOK As Integer = IIf(Me.fgrFileList.Rows(SetRow)("OK"), 1, 0)
        Dim flgRep As Integer = IIf(Me.fgrFileList.Rows(SetRow)("差替"), 1, 0)
        Dim flgAdd As Integer = IIf(Me.fgrFileList.Rows(SetRow)("追加"), 1, 0)
        Dim flgDel As Integer = IIf(Me.fgrFileList.Rows(SetRow)("削除"), 1, 0)
        Dim Rotate As Integer = Me.fgrFileList.Rows(SetRow)("回転")
        Dim Result As String = Me.fgrFileList.Rows(SetRow)("判定")

        'セルの色変更
        If Result = "〇" Then
            Me.fgrFileList.Rows(SetRow).Style = Me.fgrFileList.Styles("Normal")
        ElseIf Result = "△" Or Result = "□" Then
            Me.fgrFileList.Rows(SetRow).Style = Me.fgrFileList.Styles("Warnning")
        Else
            Me.fgrFileList.Rows(SetRow).Style = Me.fgrFileList.Styles("Error")
        End If

        If flgOK = 1 Then
            Me.fgrFileList.Rows(SetRow).Style = Me.fgrFileList.Styles("OK")
        ElseIf flgRep = 1 Then
            Me.fgrFileList.Rows(SetRow).Style = Me.fgrFileList.Styles("Rep")
        ElseIf flgDel = 1 Then
            Me.fgrFileList.Rows(SetRow).Style = Me.fgrFileList.Styles("Del")
        End If

        '追加の場合
        If flgAdd = 1 Then
            If Not Me.fgrFileList.Rows.Count - 1 = SetRow Then
                If Not Me.fgrFileList.Rows(SetRow + 1)("No.") = "Add" Then
                    Me.fgrFileList.AddItem("", SetRow + 1)
                    Me.fgrFileList.Rows(SetRow + 1)("No.") = "Add"
                    Me.fgrFileList.Rows(SetRow + 1).Style = Me.fgrFileList.Styles("Add")
                    ShowThumbnail(SetRow, True)
                End If
            Else
                Me.fgrFileList.AddItem("", SetRow + 1)
                Me.fgrFileList.Rows(SetRow + 1)("No.") = "Add"
                Me.fgrFileList.Rows(SetRow + 1).Style = Me.fgrFileList.Styles("Add")
                ShowThumbnail(SetRow, True)
            End If

        Else
            If Not Me.fgrFileList.Rows.Count - 1 = SetRow Then
                If Me.fgrFileList.Rows(SetRow + 1)("No.") = "Add" Then
                    Me.fgrFileList.RemoveItem(SetRow + 1)
                    ShowThumbnail(SetRow, True)
                End If
            End If
        End If
    End Sub
#End Region
End Class