Imports C1.Win.FlexReport

Public Class frmRemove
#Region "プライベート変数"
    Private BackMenuFlag As Boolean = False
    Dim iIndex As Integer = -1
    Dim htThumbnails As Hashtable = New Hashtable

#End Region
#Region "フォームイベント"
    ''' <summary>
    ''' フォームロード
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub frmAlibi_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.txtSrcPath.Text = My.Settings.LogChk_SrcPath
        Me.txtDstPath.Text = My.Settings.LogChk_DstPath
        Me.fgrFileList.Rows.Count = 1

        '行数
        Me.fgrThumbnail.Rows.Count = 3
        '列数
        Me.fgrThumbnail.Cols.Count = 2
        '行幅
        Me.fgrThumbnail.Rows.DefaultSize = CInt(Me.SplitContainer1.Height / 3 - 1)
        '列幅
        Me.fgrThumbnail.Cols.DefaultSize = CInt(Me.SplitContainer1.Panel2.Width / 2 - 2)


        For i As Integer = 0 To Me.fgrThumbnail.Cols.Count - 1
            '列設定
            Me.fgrThumbnail.Cols(i).ImageAlign = C1.Win.C1FlexGrid.ImageAlignEnum.Scale
            Me.fgrThumbnail.Cols(i).ImageAlignFixed = C1.Win.C1FlexGrid.ImageAlignEnum.Scale
        Next

        ' カスタムスタイルを追加
        Me.fgrFileList.Styles.Add("Normal")
        Me.fgrFileList.Styles("Normal").BackColor = Color.White
        Me.fgrFileList.Styles.Add("Warnning")
        Me.fgrFileList.Styles("Warnning").BackColor = Color.Yellow
        Me.fgrFileList.Styles.Add("Error")
        Me.fgrFileList.Styles("Error").BackColor = Color.Red
        Me.fgrFileList.Styles.Add("Done")
        Me.fgrFileList.Styles("Done").BackColor = Color.LightGray
        Me.fgrFileList.Styles.Add("Select")
        Me.fgrFileList.Styles("Select").BackColor = Color.FromArgb(&HB7, &HDB, &HFF)

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
    ''' チェック開始
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnConvert_Click(sender As Object, e As EventArgs) Handles btnStart.Click
        If Not System.IO.Directory.Exists(Me.txtSrcPath.Text) Then
            MessageBox.Show("スキャンフォルダが存在しません。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If
        If MessageBox.Show("スキャンログチェックを開始します。" & vbNewLine & "よろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
            Exit Sub
        End If

        EnableSwitch(False)

        iIndex = -1
        Me.fgrFileList.Rows.Count = 1
        Me.txtFileCount.Text = 0
        Me.txtErrorCount.Text = 0
        Me.txtWarnningCount.Text = 0
        Dim befScanNum As Integer = 0
        Dim srcDirectories As String() = System.IO.Directory.GetDirectories(Me.txtSrcPath.Text, "*", System.IO.SearchOption.AllDirectories)

        'ディレクトリが0の場合親フォルダを配列に入れる
        If srcDirectories.Count = 0 Then
            ReDim srcDirectories(0)
            srcDirectories(0) = Me.txtSrcPath.Text
        End If

        'プログレス
        Me.pgbFiles.Minimum = 0
        Me.pgbFiles.Value = 0
        Me.pgbFiles.Maximum = srcDirectories.Count
        Me.txtProgress.Text = Me.pgbFiles.Value & "/" & Me.pgbFiles.Maximum
        Me.txtErrorCount.Text = 0
        For i As Integer = 0 To srcDirectories.Count - 1

            Dim IndexTextPath As String() = System.IO.Directory.GetFiles(srcDirectories(i), "index.txt", System.IO.SearchOption.TopDirectoryOnly)
            If IndexTextPath.Count = 0 Then
                Me.fgrFileList.Rows.Count += 1
                Me.fgrFileList.Rows(Me.fgrFileList.Rows.Count - 1)("No.") = Me.fgrFileList.Rows.Count - 1
                Me.fgrFileList.Rows(Me.fgrFileList.Rows.Count - 1)("フォルダパス") = srcDirectories(i)
                Me.fgrFileList.Rows(Me.fgrFileList.Rows.Count - 1)("判定") = "×"
                Me.fgrFileList.Rows(Me.fgrFileList.Rows.Count - 1)("判定内容") = "index.txtが存在しません。"
                Me.txtErrorCount.Text = CInt(Me.txtErrorCount.Text) + 1
                Me.fgrFileList.Rows(Me.fgrFileList.Rows.Count - 1).Style = Me.fgrFileList.Styles("Error")
            Else
                Dim sr As New System.IO.StreamReader(IndexTextPath(0), System.Text.Encoding.GetEncoding("shift_jis"))
                '内容を一行ずつ読み込む
                While sr.Peek() > -1
                    Dim Row As String = sr.ReadLine()
                    Dim splRow As String() = Row.Split(",")
                    Dim ImageFileName As String = splRow(4)
                    Dim splImageFileName As String() = System.IO.Path.GetFileNameWithoutExtension(ImageFileName).Split("_")
                    Dim ScanNum As Integer = CInt(splImageFileName(CInt(Me.nudScanNumCol.Value) - 1))

                    Me.fgrFileList.Rows.Count += 1
                    Me.txtFileCount.Text = CInt(Me.txtFileCount.Text) + 1
                    If System.IO.File.Exists(srcDirectories(i) & "\" & ImageFileName) Then
                        If befScanNum + 1 = ScanNum Then
                            Me.fgrFileList.Rows(Me.fgrFileList.Rows.Count - 1)("No.") = Me.fgrFileList.Rows.Count - 1
                            Me.fgrFileList.Rows(Me.fgrFileList.Rows.Count - 1)("フォルダパス") = srcDirectories(i)
                            Me.fgrFileList.Rows(Me.fgrFileList.Rows.Count - 1)("ファイル名") = ImageFileName
                            Me.fgrFileList.Rows(Me.fgrFileList.Rows.Count - 1)("判定") = "〇"
                            Me.fgrFileList.Rows(Me.fgrFileList.Rows.Count - 1)("判定内容") = "正常"
                        Else
                            Me.fgrFileList.Rows(Me.fgrFileList.Rows.Count - 1)("No.") = Me.fgrFileList.Rows.Count - 1
                            Me.fgrFileList.Rows(Me.fgrFileList.Rows.Count - 1)("フォルダパス") = srcDirectories(i)
                            Me.fgrFileList.Rows(Me.fgrFileList.Rows.Count - 1)("ファイル名") = ImageFileName
                            Me.fgrFileList.Rows(Me.fgrFileList.Rows.Count - 1)("判定") = "△"
                            Me.fgrFileList.Rows(Me.fgrFileList.Rows.Count - 1)("判定内容") = "再スキャン画像"
                            Me.txtWarnningCount.Text = CInt(Me.txtWarnningCount.Text) + 1
                            Me.fgrFileList.Rows(Me.fgrFileList.Rows.Count - 1).Style = Me.fgrFileList.Styles("Warnning")
                        End If
                    Else
                        Me.fgrFileList.Rows(Me.fgrFileList.Rows.Count - 1)("No.") = Me.fgrFileList.Rows.Count - 1
                        Me.fgrFileList.Rows(Me.fgrFileList.Rows.Count - 1)("フォルダパス") = srcDirectories(i)
                        Me.fgrFileList.Rows(Me.fgrFileList.Rows.Count - 1)("ファイル名") = ImageFileName
                        Me.fgrFileList.Rows(Me.fgrFileList.Rows.Count - 1)("判定") = "×"
                        Me.fgrFileList.Rows(Me.fgrFileList.Rows.Count - 1)("判定内容") = "画像ファイル無し"
                        Me.txtErrorCount.Text = CInt(Me.txtErrorCount.Text) + 1
                        Me.fgrFileList.Rows(Me.fgrFileList.Rows.Count - 1).Style = Me.fgrFileList.Styles("Error")
                    End If

                    befScanNum = ScanNum

                End While
                sr.Close()
            End If
            Me.fgrFileList.AutoSizeCols()
            Me.pgbFiles.Value += 1
            Me.txtProgress.Text = Me.pgbFiles.Value & "/" & Me.pgbFiles.Maximum

            System.Windows.Forms.Application.DoEvents()
        Next

        MessageBox.Show("チェックが完了しました。", "完了", MessageBoxButtons.OK, MessageBoxIcon.Information)
        EnableSwitch(True)
    End Sub

    ''' <summary>
    ''' SplitContainerサイズ変更時
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub SplitContainer_SizeChanged(sender As Object, e As EventArgs) Handles SplitContainer1.Panel2.SizeChanged
        '行高さ
        Me.fgrThumbnail.Rows.DefaultSize = CInt(Me.SplitContainer1.Height / 3 - 2)
        '行幅
        Me.fgrThumbnail.Cols.DefaultSize = CInt(Me.SplitContainer1.Panel2.Width / 2 - 2.5)
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
            If Me.fgrFileList.Rows(iIndex)("検査フラグ") = "チェック済み" Then
                Me.fgrFileList.Rows(iIndex).Style = Me.fgrFileList.Styles("Done")
            Else
                Select Case Me.fgrFileList.Rows(iIndex)("判定")
                    Case "〇"
                        Me.fgrFileList.Rows(iIndex).Style = Me.fgrFileList.Styles("Normal")
                    Case "△"
                        Me.fgrFileList.Rows(iIndex).Style = Me.fgrFileList.Styles("Warnning")
                    Case "×"
                        Me.fgrFileList.Rows(iIndex).Style = Me.fgrFileList.Styles("Error")
                End Select
            End If
        End If
        iIndex = Me.fgrFileList.Row   'クリックされたレコード

        ShowThumbnail(iIndex)

    End Sub

    ''' <summary>
    ''' グリッドダブルクリック時
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub fgrFileList_DoubleClick(sender As System.Object, e As System.EventArgs) Handles fgrFileList.DoubleClick
        If iIndex > 0 Then
            If Me.fgrFileList.Rows(iIndex)("検査フラグ") = "チェック済み" Then
                Me.fgrFileList.Rows(iIndex).Style = Me.fgrFileList.Styles("Done")
            Else
                Select Case Me.fgrFileList.Rows(iIndex)("判定")
                    Case "〇"
                        Me.fgrFileList.Rows(iIndex).Style = Me.fgrFileList.Styles("Normal")
                    Case "△"
                        Me.fgrFileList.Rows(iIndex).Style = Me.fgrFileList.Styles("Warnning")
                    Case "×"
                        Me.fgrFileList.Rows(iIndex).Style = Me.fgrFileList.Styles("Error")
                End Select
            End If
        End If
        iIndex = Me.fgrFileList.Row   'クリックされたレコード

        ShowThumbnail(iIndex)

        Dim iPath As String = Me.fgrFileList.Rows(iIndex)("フォルダパス")
        Dim iFileName As String = Me.fgrFileList.Rows(iIndex)("ファイル名")
        '画像を表示する
        If Not iPath = Nothing Then
            Dim p As System.Diagnostics.Process = System.Diagnostics.Process.Start(iPath & "\" & iFileName)
        End If

    End Sub

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
        For i As Integer = 1 To Me.fgrFileList.Rows.Count - 1
            WriteLog(LogPath, Me.fgrFileList.Rows(i)("No.") & vbTab &
                     Me.fgrFileList.Rows(i)("フォルダパス") & "\" &
                     Me.fgrFileList.Rows(i)("ファイル名") & vbTab &
                     Me.fgrFileList.Rows(i)("判定") & vbTab &
                     Me.fgrFileList.Rows(i)("判定内容") & vbTab &
                     Me.fgrFileList.Rows(i)("検査フラグ"))
        Next

        MessageBox.Show("ログの出力が完了しました。", "完了", MessageBoxButtons.OK, MessageBoxIcon.Information)

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
        Me.nudScanNumCol.Enabled = Switch
    End Sub

    ''' <summary>
    ''' サムネイル表示
    ''' </summary>
    ''' <param name="iIndex"></param>
    Private Sub ShowThumbnail(ByVal iIndex As Integer)
        If iIndex < 0 Then
            Exit Sub
        End If

        If Me.fgrFileList.Rows(iIndex)("判定") = "△" Then
            Me.fgrFileList.Rows(iIndex)("検査フラグ") = "チェック済み"
            Me.fgrFileList.Rows(iIndex).Style = Me.fgrFileList.Styles("Done")
        Else
            Me.fgrFileList.Rows(iIndex).Style = Me.fgrFileList.Styles("Select")
        End If

        Dim iPath As String = Me.fgrFileList.Rows(iIndex)("フォルダパス")
        Dim iFileName As String = Me.fgrFileList.Rows(iIndex)("ファイル名")

        'すでに表示されている場合
        If htThumbnails.ContainsValue(iPath & "\" & iFileName) Then
            For iRow As Integer = 0 To 2
                For iCol As Integer = 0 To 1
                    If htThumbnails(iRow & "," & iCol) = iPath & "\" & iFileName Then
                        SelectThumbnail(iRow, iCol)
                        Exit Sub
                    End If
                Next
            Next
        End If

        Dim modIndex As Integer = iIndex Mod 6
        If modIndex = 0 Then
            modIndex = 6
        End If

        Dim cntThumb As Integer = iIndex - modIndex + 1

        For iRow As Integer = 0 To 2
            For iCol As Integer = 0 To 1
                If cntThumb > Me.fgrFileList.Rows.Count - 1 Then
                    iPath = Nothing
                    iFileName = Nothing
                Else
                    iPath = Me.fgrFileList.Rows(cntThumb)("フォルダパス")
                    iFileName = Me.fgrFileList.Rows(cntThumb)("ファイル名")
                End If

                If System.IO.File.Exists(iPath & "\" & iFileName) Then
                    Me.fgrThumbnail.SetCellImage(iRow, iCol, Image.FromFile(iPath & "\" & iFileName))
                Else
                    Me.fgrThumbnail.SetCellImage(iRow, iCol, Nothing)
                End If
                htThumbnails(iRow & "," & iCol) = iPath & "\" & iFileName

                If iIndex = cntThumb Then
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
        rg = fgrThumbnail.GetCellRange(0, 0, 2, 1)
        rg.Style = Nothing

        Me.fgrThumbnail.Select(sctRow, sctCol)
        rg = fgrThumbnail.GetCellRange(sctRow, sctCol)
        rg.Style = fgrThumbnail.Styles("Select")
    End Sub
#End Region
End Class