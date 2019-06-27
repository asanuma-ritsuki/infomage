Imports C1.Win.FlexReport

Public Class frmRecovery

#Region "プライベート変数"
    Private BackMenuFlag As Boolean = False
#End Region
#Region "フォームイベント"
    ''' <summary>
    ''' フォームロード
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub frmAlibi_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.fgrAll.Rows.Count = 1
        Me.fgrError.Rows.Count = 1
        Me.fgrReplace.Rows.Count = 1
        Me.fgrAdd.Rows.Count = 1
        Me.fgrRemove.Rows.Count = 1
    End Sub
    ''' <summary>
    ''' フォームクローズ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub frmAlibi_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        My.Settings.Alibi_WorkName = Me.txtParentDir.Text

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
    Private Sub txtBox_DragEnter(sender As Object, e As DragEventArgs) Handles txtParentDir.DragEnter, txtResultDir.DragEnter, txtReplace_SrcDir.DragEnter, txtReplace_DstDir.DragEnter, txtAddDir.DragEnter, txtRemoveDir.DragEnter
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
    Private Sub txtImagePath_DragDrop(sender As Object, e As DragEventArgs) Handles txtParentDir.DragDrop, txtResultDir.DragDrop, txtReplace_SrcDir.DragDrop, txtReplace_DstDir.DragDrop, txtAddDir.DragDrop, txtRemoveDir.DragDrop
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
    ''' 検索オプション
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnSearchOption_Click(sender As Object, e As EventArgs) Handles btnSearchOption.Click
        Dim f As New frmSearchOption
        f.ShowDialog()
    End Sub

    ''' <summary>
    ''' 検索ボタン
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click

        If Me.txtParentDir.Text = "" Then
            MessageBox.Show("検索パスを指定してください。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Me.fgrAll.Rows.Count = 1
        Me.fgrError.Rows.Count = 1
        Me.fgrReplace.Rows.Count = 1
        Me.fgrAdd.Rows.Count = 1
        Me.fgrRemove.Rows.Count = 1


        Dim SearchParentPath As String = Me.txtParentDir.Text
        Dim sqlProcess As New SQLProcess
        Dim strSQL As String = "SELECT T1.ID, T1.ファイルパス, T1.OK, T1.差替, T1.追加, T1.削除, T1.回転, T2.差替フラグ, T3.追加フラグ, T4.削除フラグ"
        strSQL &= " FROM T_ScanLogChk_Flag AS T1"
        strSQL &= " LEFT OUTER JOIN T_ScanLogChk_差替リスト AS T2 ON T1.差替 = T2.ID"
        strSQL &= " LEFT OUTER JOIN T_ScanLogChk_追加リスト AS T3 ON T1.追加 = T3.ID"
        strSQL &= " LEFT OUTER JOIN T_ScanLogChk_削除リスト AS T4 ON T1.ファイルパス = T4.ファイルパス"
        strSQL &= " WHERE T1.ファイルパス LIKE '" & SearchParentPath & "\%'"

        Dim DriveName As String = GetRecoveryDrive(My.Settings.Rcv_Drive)
        If SearchParentPath.Substring(0, 2) = DriveName Then
            strSQL &= " OR T1.ファイルパス LIKE '" & My.Settings.Rcv_NetPath & SearchParentPath.Substring(2) & "\%'"
        ElseIf SearchParentPath.Substring(0, My.Settings.Rcv_NetPath.Length) = My.Settings.Rcv_NetPath Then
            strSQL &= " OR T1.ファイルパス LIKE '" & DriveName & SearchParentPath.Substring(My.Settings.Rcv_NetPath.Length) & "\%'"
        End If


        Try
            Dim tblScanLogChk As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)

            'プログレス
            Me.pgbFiles.Minimum = 0
            Me.pgbFiles.Value = 0
            Me.pgbFiles.Maximum = tblScanLogChk.Rows.Count
            Me.txtProgress.Text = Me.pgbFiles.Value & "/" & Me.pgbFiles.Maximum

            Me.fgrAll.BeginUpdate()

            For i As Integer = 0 To tblScanLogChk.Rows.Count - 1
                Me.fgrAll.Rows.Count += 1
                Dim iRow As Integer = Me.fgrAll.Rows.Count - 1
                Me.fgrAll.Rows(iRow)("No.") = iRow
                Me.fgrAll.Rows(iRow)("ファイルパス") = tblScanLogChk.Rows(i)("ファイルパス")
                Me.fgrAll.Rows(iRow)("OK") = tblScanLogChk.Rows(i)("OK")
                Me.fgrAll.Rows(iRow)("差替ID") = IIf(tblScanLogChk.Rows(i)("差替") = 0, "", "S" & CInt(tblScanLogChk.Rows(i)("差替")).ToString("D4"))
                Me.fgrAll.Rows(iRow)("追加ID") = IIf(tblScanLogChk.Rows(i)("追加") = 0, "", "K" & CInt(tblScanLogChk.Rows(i)("追加")).ToString("D4"))
                Me.fgrAll.Rows(iRow)("削除") = tblScanLogChk.Rows(i)("削除")
                Me.fgrAll.Rows(iRow)("回転") = tblScanLogChk.Rows(i)("回転")
                Me.pgbFiles.Value = iRow
                Me.txtProgress.Text = Me.pgbFiles.Value & "/" & Me.pgbFiles.Maximum
                System.Windows.Forms.Application.DoEvents()

                '差し替え
                If Not Me.fgrAll.Rows(iRow)("差替ID") = "" Then
                    Me.fgrReplace.Rows.Count += 1
                    Dim iRow2 As Integer = Me.fgrReplace.Rows.Count - 1
                    Me.fgrReplace.Rows(iRow2)("No.") = iRow2
                    Me.fgrReplace.Rows(iRow2)("ファイルパス") = tblScanLogChk.Rows(i)("ファイルパス")
                    Me.fgrReplace.Rows(iRow2)("差替ID") = IIf(tblScanLogChk.Rows(i)("差替") = 0, "", "S" & CInt(tblScanLogChk.Rows(i)("差替")).ToString("D4"))
                    Me.fgrReplace.Rows(iRow2)("完了") = tblScanLogChk.Rows(i)("差替フラグ")
                End If
                'コマ抜け
                If Not Me.fgrAll.Rows(iRow)("追加ID") = "" Then
                    Me.fgrAdd.Rows.Count += 1
                    Dim iRow2 As Integer = Me.fgrAdd.Rows.Count - 1
                    Me.fgrAdd.Rows(iRow2)("No.") = iRow2
                    Me.fgrAdd.Rows(iRow2)("ファイルパス") = tblScanLogChk.Rows(i)("ファイルパス")
                    Me.fgrAdd.Rows(iRow2)("追加ID") = IIf(tblScanLogChk.Rows(i)("追加") = 0, "", "K" & CInt(tblScanLogChk.Rows(i)("追加")).ToString("D4"))
                    Me.fgrAdd.Rows(iRow2)("完了") = tblScanLogChk.Rows(i)("追加フラグ")
                End If
                '削除
                If Me.fgrAll.Rows(iRow)("削除") = True Then
                    Me.fgrRemove.Rows.Count += 1
                    Dim iRow2 As Integer = Me.fgrRemove.Rows.Count - 1
                    Me.fgrRemove.Rows(iRow2)("No.") = iRow2
                    Me.fgrRemove.Rows(iRow2)("ファイルパス") = tblScanLogChk.Rows(i)("ファイルパス")
                    Me.fgrRemove.Rows(iRow2)("完了") = tblScanLogChk.Rows(i)("削除フラグ")
                End If
            Next

            Me.fgrAll.EndUpdate()
            MessageBox.Show("読み込みが完了しました。", "完了", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            sqlProcess.Close()
        End Try

    End Sub

    ''' <summary>
    ''' ログ出力ボタン
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnOutput_Click(sender As Object, e As EventArgs) Handles btnOutput.Click
        If Not System.IO.Directory.Exists(Me.txtResultDir.Text) Then
            MessageBox.Show("ログフォルダが存在しません。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If
        If Me.fgrAll.Rows.Count = 1 Then
            MessageBox.Show("スキャンログが読み込まれていません。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If

        Dim LogPathAll As String = Me.txtResultDir.Text & "\スキャンチェックログ_" & System.DateTime.Now.ToString("yyyyMMddHHmmdd") & ".log"
        Dim LogPathErr As String = Me.txtResultDir.Text & "\スキャンチェックログ_残留エラー_" & System.DateTime.Now.ToString("yyyyMMddHHmmdd") & ".log"
        Dim LogPathRep As String = Me.txtResultDir.Text & "\スキャンチェックログ_差替え_" & System.DateTime.Now.ToString("yyyyMMddHHmmdd") & ".log"
        Dim LogPathAdd As String = Me.txtResultDir.Text & "\スキャンチェックログ_コマ抜け_" & System.DateTime.Now.ToString("yyyyMMddHHmmdd") & ".log"
        Dim LogPathDel As String = Me.txtResultDir.Text & "\スキャンチェックログ_削除_" & System.DateTime.Now.ToString("yyyyMMddHHmmdd") & ".log"

        'プログレス
        Me.pgbFiles.Minimum = 0
        Me.pgbFiles.Value = 0
        'Me.pgbFiles.Maximum = Me.fgrFileList.Rows.Count - 1
        Me.txtProgress.Text = Me.pgbFiles.Value & "/" & Me.pgbFiles.Maximum

        For i As Integer = 0 To Me.fgrAll.Rows.Count - 1

            WriteLog(LogPathAll, Me.fgrAll.Rows(i)("No.") & vbTab &
                 Me.fgrAll.Rows(i)("ファイルパス") & vbTab &
                 Me.fgrAll.Rows(i)("判定") & vbTab &
                 Me.fgrAll.Rows(i)("判定内容") & vbTab &
                 Me.fgrAll.Rows(i)("OK") & vbTab &
                 Me.fgrAll.Rows(i)("差替ID") & vbTab &
                 Me.fgrAll.Rows(i)("追加ID") & vbTab &
                 Me.fgrAll.Rows(i)("削除") & vbTab &
                 Me.fgrAll.Rows(i)("回転")
                 )
            Me.pgbFiles.Value += 1
            Me.txtProgress.Text = Me.pgbFiles.Value & "/" & Me.pgbFiles.Maximum
            System.Windows.Forms.Application.DoEvents()
        Next

        MessageBox.Show("ログの出力が完了しました。", "完了", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    ''' <summary>
    ''' 削除ボタン
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click
        If Me.txtRemoveDir.Text = "" Then
            MessageBox.Show("削除フォルダを指定してください。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        If Me.fgrRemove.Rows.Count = 1 Then
            MessageBox.Show("削除対象が存在しません。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If MessageBox.Show("削除フォルダに移動を開始してもよろしいですか?", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.No Then
            Exit Sub
        End If

        Dim RemoveCount As Integer = 0
        For iRow As Integer = 1 To Me.fgrRemove.Rows.Count - 1
            If Me.fgrRemove.Rows(iRow)("完了") = False Then
                Dim DriveName As String = GetRecoveryDrive(My.Settings.Rcv_Drive)
                Dim srcPath As String = Me.fgrRemove.Rows(iRow)("ファイルパス")
                Dim DstFileName As String = ""
                If srcPath.Substring(0, 2) = DriveName Then
                    DstFileName = srcPath.Replace(DriveName & Me.txtParentDir.Text.Substring(My.Settings.Rcv_NetPath.Length) & "\", "")
                ElseIf srcPath.Substring(0, My.Settings.Rcv_NetPath.Length) = My.Settings.Rcv_NetPath Then
                    DstFileName = srcPath.Replace(My.Settings.Rcv_NetPath & Me.txtParentDir.Text.Substring(2) & "\", "")
                End If
                DstFileName = DstFileName.Replace("\", "@")

                Dim sqlProcess As New SQLProcess
                Dim strSQL As String = ""
                Try

                    System.IO.File.Move(Me.fgrRemove.Rows(iRow)("ファイルパス"), Me.txtRemoveDir.Text & "\" & DstFileName)
                    strSQL = "INSERT INTO T_ScanLogChk_削除リスト VALUES("
                    strSQL &= "'" & srcPath & "',1)"
                    sqlProcess.DB_UPDATE(strSQL)

                    Me.fgrRemove.Rows(iRow)("完了") = 1

                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                Finally
                    sqlProcess.Close()
                End Try

                RemoveCount += 1

            End If
        Next

        If RemoveCount = 0 Then
            MessageBox.Show("削除対象が存在しません。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub

    ''' <summary>
    ''' 差替えボタン
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnReplace_Click(sender As Object, e As EventArgs) Handles btnReplace.Click
        If Me.txtReplace_SrcDir.Text = "" Then
            MessageBox.Show("再スキャンフォルダを指定してください。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        If Me.txtReplace_DstDir.Text = "" Then
            MessageBox.Show("抜き出しフォルダを指定してください。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        If Me.fgrReplace.Rows.Count = 1 Then
            MessageBox.Show("差替え対象が存在しません。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If MessageBox.Show("差替えを開始してもよろしいですか?", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.No Then
            Exit Sub
        End If

        Dim ReplaceCount As Integer = 0
        Dim NotReplaceCount As Integer = 0
        For iRow As Integer = 1 To Me.fgrReplace.Rows.Count - 1
            If Me.fgrReplace.Rows(iRow)("完了") = False Then
                Dim DriveName As String = GetRecoveryDrive(My.Settings.Rcv_Drive)
                Dim srcPath As String = Me.fgrReplace.Rows(iRow)("ファイルパス")
                '差替ID
                Dim ReplaceID As String = Me.fgrReplace.Rows(iRow)("差替ID")
                '差替IDフォルダの存在確認
                If Not System.IO.Directory.Exists(Me.txtReplace_SrcDir.Text & "\" & ReplaceID) Then
                    NotReplaceCount += 1
                    Continue For
                End If


                Dim DstFileName As String = ""
                If srcPath.Substring(0, 2) = DriveName Then
                    DstFileName = srcPath.Replace(DriveName & Me.txtParentDir.Text.Substring(My.Settings.Rcv_NetPath.Length) & "\", "")
                ElseIf srcPath.Substring(0, My.Settings.Rcv_NetPath.Length) = My.Settings.Rcv_NetPath Then
                    DstFileName = srcPath.Replace(My.Settings.Rcv_NetPath & Me.txtParentDir.Text.Substring(2) & "\", "")
                End If
                DstFileName = DstFileName.Replace("\", "@")

                Dim sqlProcess As New SQLProcess
                Dim strSQL As String = ""
                Try
                    System.IO.File.Move(Me.fgrReplace.Rows(iRow)("ファイルパス"), Me.txtReplace_DstDir.Text & "\" & DstFileName)
                    Dim aryReplaceFiles As String() = GetFilesMostDeep(Me.txtReplace_SrcDir.Text & "\" & ReplaceID, {".tif", ".jpg"})
                    For i As Integer = 0 To aryReplaceFiles.Count - 1
                        Dim repFilePath As String = System.IO.Path.GetDirectoryName(Me.fgrReplace.Rows(iRow)("ファイルパス")) & "\" & System.IO.Path.GetFileNameWithoutExtension(Me.fgrReplace.Rows(iRow)("ファイルパス"))
                        repFilePath &= "_" & System.IO.Path.GetFileName(aryReplaceFiles(i))
                        System.IO.File.Copy(aryReplaceFiles(i), repFilePath)
                    Next
                    strSQL = "UPDATE T_ScanLogChk_差替リスト"
                    strSQL &= " SET 差替フラグ = 1"
                    strSQL &= " WHERE ファイルパス = '" & srcPath & "'"
                    sqlProcess.DB_UPDATE(strSQL)

                    Me.fgrReplace.Rows(iRow)("完了") = 1

                Catch ex As Exception
                    NotReplaceCount += 1
                    MessageBox.Show(ex.Message)
                Finally
                    sqlProcess.Close()
                End Try

                ReplaceCount += 1

            End If
        Next

        If NotReplaceCount <> 0 Then
            MessageBox.Show("差替え出来なかったレコードが" & NotReplaceCount & "件存在します。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        If ReplaceCount = 0 Then
            MessageBox.Show("差替え対象が存在しません。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    ''' <summary>
    ''' 追加ボタン
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If Me.txtAddDir.Text = "" Then
            MessageBox.Show("追加フォルダを指定してください。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        If Me.fgrAdd.Rows.Count = 1 Then
            MessageBox.Show("コマ抜け対象が存在しません。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If MessageBox.Show("差し込みを開始してもよろしいですか?", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.No Then
            Exit Sub
        End If

        Dim AddCount As Integer = 0
        Dim NotAddCount As Integer = 0
        For iRow As Integer = 1 To Me.fgrAdd.Rows.Count - 1
            If Me.fgrAdd.Rows(iRow)("完了") = False Then
                Dim DriveName As String = GetRecoveryDrive(My.Settings.Rcv_Drive)
                Dim srcPath As String = Me.fgrAdd.Rows(iRow)("ファイルパス")
                '追加ID
                Dim AddID As String = Me.fgrAdd.Rows(iRow)("追加ID")
                '追加IDフォルダの存在確認
                If Not System.IO.Directory.Exists(Me.txtAddDir.Text & "\" & AddID) Then
                    NotAddCount += 1
                    Continue For
                End If


                Dim DstFileName As String = ""
                If srcPath.Substring(0, 2) = DriveName Then
                    DstFileName = srcPath.Replace(DriveName & Me.txtParentDir.Text.Substring(My.Settings.Rcv_NetPath.Length) & "\", "")
                ElseIf srcPath.Substring(0, My.Settings.Rcv_NetPath.Length) = My.Settings.Rcv_NetPath Then
                    DstFileName = srcPath.Replace(My.Settings.Rcv_NetPath & Me.txtParentDir.Text.Substring(2) & "\", "")
                End If
                DstFileName = DstFileName.Replace("\", "@")

                Dim sqlProcess As New SQLProcess
                Dim strSQL As String = ""
                Try
                    Dim aryAddFiles As String() = GetFilesMostDeep(Me.txtAddDir.Text & "\" & AddID, {".tif", ".jpg"})
                    For i As Integer = 0 To aryAddFiles.Count - 1
                        Dim addFilePath As String = System.IO.Path.GetDirectoryName(Me.fgrReplace.Rows(iRow)("ファイルパス")) & "\" & System.IO.Path.GetFileNameWithoutExtension(Me.fgrReplace.Rows(iRow)("ファイルパス"))
                        addFilePath &= "_" & System.IO.Path.GetFileName(aryAddFiles(i))
                        System.IO.File.Copy(aryAddFiles(i), addFilePath)
                        Me.fgrAdd.Rows(iRow)("完了") = 1
                    Next
                    strSQL = "UPDATE T_ScanLogChk_追加リスト"
                    strSQL &= " SET 追加フラグ = 1"
                    strSQL &= " WHERE ファイルパス = '" & srcPath & "'"
                    sqlProcess.DB_UPDATE(strSQL)

                Catch ex As Exception
                    NotAddCount += 1
                    MessageBox.Show(ex.Message)
                Finally
                    sqlProcess.Close()
                End Try

                AddCount += 1

            End If
        Next

        If NotAddCount <> 0 Then
            MessageBox.Show("追加出来なかったレコードが" & NotAddCount & "件存在します。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        If AddCount = 0 Then
            MessageBox.Show("コマ抜け対象が存在しません。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
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

#End Region
End Class