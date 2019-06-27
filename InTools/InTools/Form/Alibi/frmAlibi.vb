Imports C1.Win.FlexReport

Public Class frmAlibi

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
        Me.fgrFileList.Rows.Count = 1
        Me.fgrFileList.AutoSizeCols()
        Me.txtWorkName.Text = My.Settings.Alibi_WorkName
        Me.nudFrom.Value = My.Settings.Alibi_prtFrom
        Me.nudTo.Value = My.Settings.Alibi_prtTo
        Me.txtDstPath.Text = My.Settings.Alibi_DstPath
        Me.txtSrcPath.Text = My.Settings.Alibi_SrcPath
        Me.txtLogPath.Text = My.Settings.Alibi_LogPath
        Me.chkA4harf.Checked = True

        ImageMagick.MagickNET.SetTempDirectory(Application.StartupPath & "\Alibi_Temp")

    End Sub
    ''' <summary>
    ''' フォームクローズ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub frmAlibi_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        My.Settings.Alibi_WorkName = Me.txtWorkName.Text
        My.Settings.Alibi_prtFrom = Me.nudFrom.Value
        My.Settings.Alibi_prtTo = Me.nudTo.Value
        My.Settings.Alibi_DstPath = Me.txtDstPath.Text
        My.Settings.Alibi_SrcPath = Me.txtSrcPath.Text
        My.Settings.Alibi_LogPath = Me.txtLogPath.Text
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
    Private Sub txtBox_DragEnter(sender As Object, e As DragEventArgs) Handles txtDstPath.DragEnter, txtSrcPath.DragEnter, txtLogPath.DragEnter
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
    Private Sub txtImagePath_DragDrop(sender As Object, e As DragEventArgs) Handles txtDstPath.DragDrop, txtSrcPath.DragDrop, txtLogPath.DragDrop
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
    ''' 印刷ボタン
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        If Me.txtWorkName.Text = "" Then
            MessageBox.Show("案件名を入力してください。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        'SQL定義(SQLサーバー)
        Dim strSQL As String = ""
        Dim sqlProcess As New SQLProcess
        Try
            'アリバイNoテーブルを削除
            strSQL = "DELETE FROM T_アリバイNo"
            sqlProcess.DB_UPDATE(strSQL)

            '新規でアリバイNoを書き込み
            For i As Integer = Me.nudFrom.Value To Me.nudTo.Value
                strSQL = "INSERT INTO T_アリバイNo "
                strSQL &= "VALUES(" & i & ",'" & Me.txtWorkName.Text & "'" & ")"
                sqlProcess.DB_UPDATE(strSQL)
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "システムエラー")
        Finally
            sqlProcess.Close()
        End Try

        '印刷
        Dim Alibi_Report As New C1FlexReport
        Dim strConnectionString As String = ""
        strSQL = "SELECT AlibiNo, WorkName FROM T_アリバイNo ORDER BY AlibiNo"

        Try
            '接続文字列を作成する
            Alibi_Report.Load(Application.StartupPath & "\Report\Report_Alibi.flxr", "レポート")
            'SQL構文で指定できるようにレコードソースタイプをオートに変更
            Alibi_Report.DataSource.RecordSourceType = RecordSourceType.Auto
            Alibi_Report.DataSource.RecordSource = strSQL
            Alibi_Report.Render()
            'Alibi_Report.Print()

            'プリンターの設定
            If Me.PrintDialog.ShowDialog() = DialogResult.OK Then
                'SetDefaultPrinter(Me.PrintDialog.PrinterSettings.PrinterName)
                Dim print_option As C1.Win.C1Document.C1PrintOptions = New C1.Win.C1Document.C1PrintOptions()
                print_option.PrinterSettings = New System.Drawing.Printing.PrinterSettings()
                'print_option.PrinterSettings.DefaultPageSettings.PrinterSettings = print_option.PrinterSettings
                print_option.PrinterSettings = Me.PrintDialog.PrinterSettings
                'print_option.PrinterSettings.PrinterName = Me.PrintDialog.PrinterSettings.PrinterName
                Alibi_Report.Print(print_option)

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            Alibi_Report.Dispose()
        End Try


    End Sub

    ''' <summary>
    ''' 差し替え
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnReplace_Click(sender As Object, e As EventArgs) Handles btnReplace.Click
        If Not System.IO.Directory.Exists(Me.txtDstPath.Text) Then
            MessageBox.Show("差し替え先フォルダが存在しません。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If
        If Not System.IO.Directory.Exists(Me.txtSrcPath.Text) Then
            MessageBox.Show("差し替え元フォルダが存在しません。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If
        If Not System.IO.Directory.Exists(Me.txtLogPath.Text) Then
            MessageBox.Show("ログフォルダが存在しません。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If

        If MessageBox.Show("差し替え元フォルダ内の画像をアリバイ画像と差替えます。" & vbNewLine & "よろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
            Exit Sub
        End If

        '差し替え先フォルダ内の画像パスを取得。
        Dim Extensions As String() = New String() {"*.jpg", "*.tif"}
        Dim DstFilePath As String() = GetFilesMostDeep(Me.txtDstPath.Text, Extensions)
        '差し替え元のサブフォルダ名を取得
        Dim SrcFolderPath As String() = System.IO.Directory.GetDirectories(Me.txtSrcPath.Text, "*", System.IO.SearchOption.TopDirectoryOnly)
        '大判フォルダの余り検索用にアレイリストにサブフォルダ名を代入
        Dim arSrcFolderPath As New ArrayList(SrcFolderPath)

        'ログファイル名
        Dim LogFileName As String = Me.txtLogPath.Text & "\" & System.DateTime.Now.ToString("yyyyMMddHHmmss") & ".log"
        'カウント
        Dim cntNG As Integer = 0
        Dim cntOK As Integer = 0
        Me.pgbFiles.Minimum = 0
        Me.pgbFiles.Maximum = CInt(SrcFolderPath.Count)
        Me.pgbFiles.Value = 0
        Me.txtProgress.Text = Me.pgbFiles.Value & "/" & Me.pgbFiles.Maximum
        Me.txtFileCount.Text = "0/" & DstFilePath.Count
        Me.txtErrorCount1.Text = 0
        'フレックスグリッド
        Me.fgrFileList.Rows.Count = SrcFolderPath.Count + 1
        For iRow As Integer = 1 To Me.fgrFileList.Rows.Count - 1
            Me.fgrFileList.Rows(iRow)("No.") = iRow
            Me.fgrFileList.Rows(iRow)("アリバイNo") = System.IO.Path.GetFileName(SrcFolderPath(iRow - 1))
        Next
        System.Windows.Forms.Application.DoEvents()
        Dim FileCount As Integer = 0

        '差し替え先画像の画角を取得
        For i As Integer = 0 To DstFilePath.Count - 1
			Dim FilePath As String = DstFilePath(i)
			'==================================================
			'作成日、アクセス日などが20000年などとなる場合があるので
			'過去1年前以上の日付は本日に上書きする
			'==================================================
			Dim dtDate As Date = System.IO.File.GetCreationTime(FilePath)
			Dim dtNow As Date = Date.Now


			Dim ReadBCResult As String() = {"", ""}
            Dim ReadBC As String = ""
            If chkA4harf.Checked = True Then
                Dim ImageInfo As New ImageMagick.MagickImageInfo
                Dim inchW As Double = 0
                Dim inchH As Double = 0
                Try
                    ImageInfo.Read(FilePath)
                    Dim rslX As Integer = ImageInfo.Density.X
                    Dim rslY As Integer = ImageInfo.Density.Y
                    Dim pixW As Integer = ImageInfo.Width
                    Dim pixH As Integer = ImageInfo.Height
                    inchH = pixH / rslY
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try
                Dim LongSide As Integer = IIf(inchW > inchH, inchW, inchH)
                Dim ShortSide As Integer = IIf(inchW < inchH, inchW, inchH)
                'A4縦の場合バーコードを読み取る
                If 11.5 <= LongSide And LongSide <= 12.5 And 3.8 <= ShortSide And ShortSide <= 4.2 Then
                    ReadBCResult = BCReadProcess.BarcodeRead(FilePath, ZXing.BarcodeFormat.QR_CODE, False, Me.chkBin.Checked)
                End If
            Else
                ReadBCResult = BCReadProcess.BarcodeRead(FilePath, ZXing.BarcodeFormat.QR_CODE)
            End If

            ReadBC = ReadBCResult(0)

            '差し替え(4桁かつAはじまりの場合)
            Dim flgReplace As Boolean = False
            If ReadBC.Length = 4 And ReadBC.StartsWith("A") Then
                For j As Integer = 0 To arSrcFolderPath.Count - 1
                    Dim FolderName As String = System.IO.Path.GetFileName(arSrcFolderPath(j))
                    If ReadBC = FolderName Then
                        '一致した場合
                        Dim FileName As String = System.IO.Path.GetFileName(DstFilePath(i))
                        '差替元サブフォルダ内のファイルパスを取得
                        Dim ObanExtensions As String() = New String() {"*.jpg", "*.tif"}
                        Dim ObanFilePath As String() = GetFilesMostDeep(arSrcFolderPath(j), ObanExtensions)
                        Try
                            For k As Integer = 0 To ObanFilePath.Count - 1
                                '差替元画像のファイル名を取得
                                Dim ObanFileName As String = System.IO.Path.GetFileName(ObanFilePath(k))
                                '差替元画像をアリバイ用紙の箇所にコピー（ファイル名：アリバイ用紙画像ファイル名_大判画像ファイル名）
                                System.IO.File.Copy(ObanFilePath(k),
                                                System.IO.Path.GetDirectoryName(DstFilePath(i)) & "\" & System.IO.Path.GetFileNameWithoutExtension(DstFilePath(i)) & "_" & ObanFileName)
                            Next

                            '出力アリバイ用紙画像ファイル名
                            Dim OutAlibiFileName As String = System.IO.Path.GetDirectoryName(DstFilePath(i))
                            OutAlibiFileName = OutAlibiFileName.Replace(Me.txtDstPath.Text, "")
                            OutAlibiFileName = OutAlibiFileName.Replace("\", "_")
                            'アリバイ用紙画像をログフォルダへ移動
                            System.IO.Directory.CreateDirectory(Me.txtLogPath.Text & "\アリバイ画像")
                            System.IO.File.Move(DstFilePath(i), Me.txtLogPath.Text & "\アリバイ画像\" & ReadBC & OutAlibiFileName & "_" & FileName)
                            'サブフォルダの配列から差替えたアリバイNoの要素を削除する。
                            Dim iIndex As Integer = arSrcFolderPath.IndexOf(Me.txtSrcPath.Text & "\" & FolderName)
                            arSrcFolderPath.RemoveAt(iIndex)
                            flgReplace = True
                            Exit For
                        Catch ex As Exception
                            MessageBox.Show(ex.Message)
                        End Try
                    End If
                Next

                If flgReplace = True Then
                    '同じ名前のフォルダが存在した場合
                    WriteLog(LogFileName, ReadBC & vbTab & FilePath & vbTab & "OK")
                    Dim fndRow As Integer = Me.fgrFileList.FindRow(ReadBC, 1, 1, False)
                    Me.fgrFileList.Rows(fndRow)("検出ファイルパス") = FilePath
                    Me.fgrFileList.Rows(fndRow)("差し替え") = "OK"
                    cntOK += 1
                Else
                    '同じ名前のフォルダが存在しなかった場合
                    Me.fgrFileList.Rows.Count += 1
                    Me.fgrFileList.Rows(Me.fgrFileList.Rows.Count - 1)("No.") = Me.fgrFileList.Rows.Count - 1
                    Me.fgrFileList.Rows(Me.fgrFileList.Rows.Count - 1)("アリバイNo") = ReadBC
                    Me.fgrFileList.Rows(Me.fgrFileList.Rows.Count - 1)("検出ファイルパス") = FilePath
                    Me.fgrFileList.Rows(Me.fgrFileList.Rows.Count - 1)("差し替え") = "NG(差替元フォルダが存在しません)"
                    WriteLog(LogFileName, ReadBC & vbTab & FilePath & vbTab & "NG(差替元フォルダが存在しません)")
                    Me.pgbFiles.Maximum += 1
                    cntNG += 1
                End If

            End If

            '進捗
            FileCount += 1

            Me.pgbFiles.Value = cntOK + cntNG
            Me.txtProgress.Text = Me.pgbFiles.Value & "/" & Me.pgbFiles.Maximum
            Me.txtFileCount.Text = FileCount & "/" & DstFilePath.Count
            Me.txtErrorCount1.Text = cntNG

            Me.fgrFileList.AutoSizeCols()
            System.Windows.Forms.Application.DoEvents()

            '差替元要素がない場合終了する
            If arSrcFolderPath.Count = 0 Then
                Exit For
            End If
        Next

        '残留した大判フォルダをログに書き出す
        For i As Integer = 0 To arSrcFolderPath.Count - 1
            WriteLog(LogFileName, arSrcFolderPath(i) & vbTab & "-" & vbTab & "NG(差替先アリバイ画像が見つかりません)")
            Dim fndRow As Integer = Me.fgrFileList.FindRow(System.IO.Path.GetFileName(arSrcFolderPath(i)), 1, 1, False)
            Me.fgrFileList.Rows(fndRow)("検出ファイルパス") = "-"
            Me.fgrFileList.Rows(fndRow)("差し替え") = "NG(差替先アリバイ画像が見つかりません)"
            cntNG += 1
        Next

        If cntNG = 0 Then
            MessageBox.Show(cntOK & "件の差し替えが完了しました。", "完了", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show(cntOK & "件の差し替えが完了しました。" & vbNewLine &
                            cntNG & "件は差し替えが出来ませんでした。" &
                            "ログを確認してください。", "完了", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

        '進捗
        Me.txtErrorCount1.Text = cntNG
        Me.fgrFileList.AutoSizeCols()
        System.Windows.Forms.Application.DoEvents()

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
    ''' <param name="LogFileName"></param>
    ''' <param name="strWriteLog"></param>
    Private Sub WriteLog(ByVal LogFileName As String, ByVal strWriteLog As String)
        Dim sw As New System.IO.StreamWriter(LogFileName,
            True,
            System.Text.Encoding.GetEncoding("shift_jis"))
        sw.WriteLine(strWriteLog)
        '閉じる
        sw.Close()
    End Sub
#End Region
End Class