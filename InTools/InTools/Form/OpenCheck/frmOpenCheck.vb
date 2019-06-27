Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports Leadtools
Imports Leadtools.Codecs
Imports C1.Win.C1FlexGrid

Public Class frmOpenCheck

#Region "プライベート変数"
    Private BackMenuFlag As Boolean = False
    Private Enum HashType
        off
        md5
        sha1
        sha256
    End Enum
#End Region
#Region "フォームイベント"
    ''' <summary>
    ''' フォームロード時
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub frmOpenCheck_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'ImageMagick.MagickNET.SetGhostscriptDirectory(Application.StartupPath & "\GhostScript")
        RasterSupport.SetLicense(Application.StartupPath & "\License\LEAD175ImgSuite.lic", "+sxwXvpT1JbgbQ7DAdF9k8WRWcBnLgwIjN2a3sVpuzOIoMTYIWPT13qYg3qhCnFE")


        Me.cmbHash.Items.Add("OFF")
        Me.cmbHash.Items.Add("md5")
        Me.cmbHash.Items.Add("sha1")
        Me.cmbHash.Items.Add("sha256")

        Me.cmbMojiCode.Items.AddRange(GetMojiCode)

        Me.cmbMojiCode.SelectedIndex = My.Settings.OpenCheck_MojiCode
        Me.cmbHash.SelectedIndex = My.Settings.OpenCheck_HashType
        Me.txtInputFolderName.Text = My.Settings.OpenCheck_InputFolder
        Me.txtOutputFolderName.Text = My.Settings.OpenCheck_OutputFolder
        Me.nudMargin.Value = My.Settings.OpenCheck_nudMargin
        Me.fgrFileList.Rows.Count = 1
        Me.fgrFileList.AutoSizeCols()
    End Sub
    ''' <summary>
    ''' フォームクロージング
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub frmOpenCheck_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        My.Settings.OpenCheck_MojiCode = Me.cmbMojiCode.SelectedIndex
        My.Settings.OpenCheck_InputFolder = Me.txtInputFolderName.Text
        My.Settings.OpenCheck_OutputFolder = Me.txtOutputFolderName.Text
        My.Settings.OpenCheck_HashType = Me.cmbHash.SelectedIndex
        My.Settings.OpenCheck_nudMargin = Me.nudMargin.Value
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
    ''' オープンチェックボタン
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnOpenCheck_Click(sender As Object, e As EventArgs) Handles btnStart.Click
        If Me.txtOutputFolderName.Text = "" Then
            MessageBox.Show("ログ保存先を指定してください。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        EnableSwitch(True)

        '書き込み先のテキストファイル 
        Dim LogPath As String = Me.txtOutputFolderName.Text & "\画像情報ログ_" & System.IO.Path.GetFileName(Me.txtInputFolderName.Text) & "_" & System.DateTime.Now.ToString("yyyyMMddHHmmss")
        Dim enc As System.Text.Encoding = System.Text.Encoding.GetEncoding(Me.cmbMojiCode.Text)

        'イメージパス取得
        Dim Extensions As String() = New String() {"*.jpg", "*.jp2", "*.tif", "*.tiff", "*.pdf", "*.gif", "*.png", "*.bmp"}
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

        'グリッド背景色
        Me.fgrFileList.Styles.Add("NG")
        Me.fgrFileList.Styles("NG").BackColor = Color.Red

        If files.Count = 0 Then
            MessageBox.Show("検査対象画像が見つかりませんでした。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
            EnableSwitch(False)
            Exit Sub
        End If

        Dim codecs As New RasterCodecs

        'ログ出力
        Dim RowData(Me.fgrFileList.Cols.Count - 1) As String
        For col As Integer = 0 To Me.fgrFileList.Cols.Count - 1
            RowData(col) = Me.fgrFileList.Rows(0)(col)
        Next
        System.IO.File.AppendAllText(LogPath & ".log", String.Join(vbTab, RowData) & vbNewLine, enc)

        For iRow As Integer = 1 To files.Count
            Me.fgrFileList.Rows.Count += 1
            Dim FilePath As String = files(iRow - 1)

            Me.fgrFileList.Rows(iRow)("No.") = iRow
            Me.fgrFileList.Rows(iRow)("ファイルパス") = FilePath

            Select Case Me.cmbHash.SelectedIndex
                Case 0
                    Me.fgrFileList.Rows(iRow)(12) = "-"
                Case 1
                    Me.fgrFileList.Rows(iRow)(12) = GetHash(FilePath, HashType.md5)
                Case 2
                    Me.fgrFileList.Rows(iRow)(12) = GetHash(FilePath, HashType.sha1)
                Case 3
                    Me.fgrFileList.Rows(iRow)(12) = GetHash(FilePath, HashType.sha256)
            End Select

            Try
                Dim FileInfo As CodecsImageInfo = codecs.GetInformation(FilePath, False)
                Dim Ext As String = System.IO.Path.GetExtension(FilePath)
                Me.fgrFileList.Rows(iRow)("ファイルサイズ(KB)") = Math.Ceiling(CInt(FileInfo.SizeDisk.ToString) / 1024)
                Me.fgrFileList.Rows(iRow)("フォーマット") = FileInfo.Format.ToString
                Me.fgrFileList.Rows(iRow)("ページ数") = FileInfo.TotalPages
                If FileInfo.TotalPages = 1 And FileInfo.Format.ToString <> "RasPdf" Then
                    Me.fgrFileList.Rows(iRow)("ビット深度") = FileInfo.BitsPerPixel.ToString
                    Me.fgrFileList.Rows(iRow)("解像度(x * y)") = FileInfo.XResolution.ToString & "*" & FileInfo.YResolution.ToString
                    Me.fgrFileList.Rows(iRow)("ピクセル数(w * h)") = FileInfo.Width.ToString & "*" & FileInfo.Height.ToString

                    Dim width As Double = Math.Ceiling(FileInfo.Width / FileInfo.XResolution * 254) / 100
                    Dim height As Double = Math.Ceiling(FileInfo.Height / FileInfo.YResolution * 254) / 100
                    Me.fgrFileList.Rows(iRow)("大きさcm(w * h)") = width & "*" & height
                    Me.fgrFileList.Rows(iRow)("用紙サイズ") = PaperSizeJudge(width * 10, height * 10, Me.nudMargin.Value, width >= height)
                    Me.fgrFileList.Rows(iRow)("縦横") = IIf(width >= height, "横", "縦")
                Else
                    Me.fgrFileList.Rows(iRow)("ビット深度") = "-"
                    Me.fgrFileList.Rows(iRow)("解像度(x * y)") = "-"
                    Me.fgrFileList.Rows(iRow)("ピクセル数(w * h)") = "-"
                    Me.fgrFileList.Rows(iRow)("大きさcm(w * h)") = "-"
                    Me.fgrFileList.Rows(iRow)("用紙サイズ") = "-"
                    Me.fgrFileList.Rows(iRow)("縦横") = "-"
                End If

                FileInfo.Dispose()

            Catch ex As Exception
                MessageBox.Show(ex.Message)
                Me.txtErrorCount.Text = CInt(Me.txtErrorCount.Text) + 1
                Me.fgrFileList.Rows(iRow)("No.") = iRow
                Me.fgrFileList.Rows(iRow)("オープンchk") = "NG"
                Me.fgrFileList.Rows(iRow).Style = Me.fgrFileList.Styles("NG")
            End Try

            Me.fgrFileList.Rows(iRow)("オープンchk") = "OK"

            'ログ出力
            For col As Integer = 0 To Me.fgrFileList.Cols.Count - 1
                RowData(col) = Me.fgrFileList.Rows(iRow)(col)
            Next
            System.IO.File.AppendAllText(LogPath & ".log", String.Join(vbTab, RowData) & vbNewLine, enc)

            Me.fgrFileList.ShowCell(Me.fgrFileList.Rows.Count - 1, 0)
            Me.pgbFiles.Value += 1
            Me.txtProgress.Text = Me.pgbFiles.Value & "/" & Me.pgbFiles.Maximum

            System.Windows.Forms.Application.DoEvents()
        Next

        '列の幅を最大桁数に合わせる
        Me.fgrFileList.AutoSizeCols()

        ' NGログの出力
        Me.fgrFileList.AllowFiltering = True
        ' 新しいValueFilterを作成します
        Dim f As New C1.Win.C1FlexGrid.ValueFilter

        If Not CInt(Me.txtErrorCount.Text) = 0 Then
            'NGのみフィルター
            f.ShowValues = New Object() {"NG"}
            ' 新しいフィルタを1列目に割り当てます
            Me.fgrFileList.Cols("オープンchk").Filter = f
			' フィルタ条件を適用します
			Me.fgrFileList.ApplyFilters()
			Me.fgrFileList.SaveGrid(LogPath & "_NG.log", C1.Win.C1FlexGrid.FileFormatEnum.TextTab, C1.Win.C1FlexGrid.FileFlags.IncludeFixedCells + C1.Win.C1FlexGrid.FileFlags.VisibleOnly, System.Text.Encoding.GetEncoding(Me.cmbMojiCode.Text))
        End If

        'フィルター解除
        Me.fgrFileList.AllowFiltering = False

        If CInt(Me.txtErrorCount.Text) = 0 Then
            MessageBox.Show("チェックとログの出力が完了しました。" & "エラーファイルは存在しませんでした。", "完了", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("エラーファイルが" & CInt(Me.txtErrorCount.Text) & "件が存在します。" & vbNewLine & "NGログを確認してください。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If

        EnableSwitch(False)
    End Sub
    ''' <summary>
    ''' ハッシュタイプ変更
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub cmbHash_TextChanged(sender As Object, e As EventArgs) Handles cmbHash.SelectedIndexChanged
        Me.fgrFileList.Cols(12).Caption = "ハッシュ値(" & Me.cmbHash.Text & ")"
        Me.fgrFileList.Cols(12).Name = "ハッシュ値(" & Me.cmbHash.Text & ")"
        Me.fgrFileList.AutoSizeCols()
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
        Me.cmbHash.Enabled = Not DoingFlag
        Me.btnInputFolderOpen.Enabled = Not DoingFlag
        Me.btnOutputFolderOpen.Enabled = Not DoingFlag
        Me.btnBackMenu.Enabled = Not DoingFlag
    End Sub

    Private Function GetHash(ByVal Path As String, ByVal HashType As HashType) As String
        'MD5ハッシュ値を計算するファイル 
        Dim fileName As String = Path
        'ファイルを開く
        Dim fs As New System.IO.FileStream(
            fileName,
            System.IO.FileMode.Open,
            System.IO.FileAccess.Read,
            System.IO.FileShare.Read)

        'CryptoServiceProviderオブジェクトを作成
        Dim hash As New Object

        Select Case HashType
            Case 1
                hash = New System.Security.Cryptography.MD5CryptoServiceProvider()
            Case 2
                hash = New System.Security.Cryptography.SHA1CryptoServiceProvider()
            Case 3
                hash = New System.Security.Cryptography.SHA256CryptoServiceProvider()
        End Select

        'ハッシュ値を計算する
        Dim bs As Byte() = hash.ComputeHash(fs)

        'リソースを解放する
        hash.Clear()
        'ファイルを閉じる 
        fs.Close()

        'byte型配列を16進数の文字列に変換 
        Dim result As New System.Text.StringBuilder()
        For Each b As Byte In bs
            result.Append(b.ToString("x2"))
        Next
        Return result.ToString
    End Function

    ''' <summary>
    ''' 用紙サイズ判定
    ''' </summary>
    ''' <param name="width"></param>
    ''' <param name="height"></param>
    ''' <param name="iMargin"></param>
    ''' <param name="landscape"></param>
    ''' <returns></returns>
    Private Function PaperSizeJudge(ByVal width As Double, ByVal height As Double, ByVal iMargin As Integer, ByVal landscape As Boolean) As String
        Dim iLongSide As Double = 0
        Dim iShortSide As Double = 0
        If landscape = True Then
            iLongSide = width
            iShortSide = height
        Else
            iLongSide = height
            iShortSide = width
        End If

        If (iLongSide > (1189 + iMargin)) Or (iShortSide > (840 + iMargin)) Then
            'A0超
            Return "A0超"
        ElseIf (iLongSide >= (1189 - iMargin) And iLongSide <= (1189 + iMargin)) And (iShortSide >= (840 - iMargin) And iShortSide <= (840 + iMargin)) Then
            'A0
            Return "A0"
        ElseIf (iLongSide > (1030 + iMargin)) Or (iShortSide > (728 + iMargin)) Then
            'A0未満B1以上
            Return "不定形(A0未満B1以上)"
        ElseIf (iLongSide >= (1030 - iMargin) And iLongSide <= (1030 + iMargin)) And (iShortSide >= (728 - iMargin) And iShortSide <= (728 + iMargin)) Then
            'B1
            Return "B1"
        ElseIf (iLongSide > (840 + iMargin)) Or (iShortSide > (594 + iMargin)) Then
            'B1未満A1以上
            Return "不定形(B1未満A1以上)"
        ElseIf (iLongSide >= (840 - iMargin) And iLongSide <= (840 + iMargin)) And (iShortSide >= (594 - iMargin) And iShortSide <= (594 + iMargin)) Then
            'A1
            Return "A1"
        ElseIf (iLongSide > (728 + iMargin)) Or (iShortSide > (515 + iMargin)) Then
            'A1未満B2以上
            Return "不定形(A1未満B2以上)"
        ElseIf (iLongSide >= (728 - iMargin) And iLongSide <= (728 + iMargin)) And (iShortSide >= (515 - iMargin) And iShortSide <= (515 + iMargin)) Then
            'B2
            Return "B2"
        ElseIf (iLongSide > (594 + iMargin)) Or (iShortSide > (420 + iMargin)) Then
            'B2未満A2以上
            Return "不定形(B2未満A2以上)"
        ElseIf (iLongSide >= (594 - iMargin) And iLongSide <= (594 + iMargin)) And (iShortSide >= (420 - iMargin) And iShortSide <= (420 + iMargin)) Then
            'A2
            Return "A2"
        ElseIf (iLongSide > (515 + iMargin)) Or (iShortSide > (364 + iMargin)) Then
            'A2未満B3以上
            Return "不定形(A2未満B3以上)"
        ElseIf (iLongSide >= (515 - iMargin) And iLongSide <= (515 + iMargin)) And (iShortSide >= (364 - iMargin) And iShortSide <= (364 + iMargin)) Then
            'B3
            Return "B3"
        ElseIf (iLongSide > (420 + iMargin)) Or (iShortSide > (297 + iMargin)) Then
            'B3未満A3以上
            Return "不定形(B3未満A3以上)"
        ElseIf (iLongSide >= (420 - iMargin) And iLongSide <= (420 + iMargin)) And (iShortSide >= (297 - iMargin) And iShortSide <= (297 + iMargin)) Then
            'A3
            Return "A3"
        ElseIf (iLongSide > (364 + iMargin)) Or (iShortSide > (257 + iMargin)) Then
            'A3未満B4以上
            Return "不定形(A3未満B4以上)"
        ElseIf (iLongSide >= (364 - iMargin) And iLongSide <= (364 + iMargin)) And (iShortSide >= (257 - iMargin) And iShortSide <= (257 + iMargin)) Then
            'B4
            Return "B4"
        ElseIf (iLongSide > (297 + iMargin)) Or (iShortSide > (210 + iMargin)) Then
            'B4未満A4以上
            Return "不定形(B4未満A4以上)"
        ElseIf (iLongSide >= (297 - iMargin) And iLongSide <= (297 + iMargin)) And (iShortSide >= (210 - iMargin) And iShortSide <= (210 + iMargin)) Then
            'A4
            Return "A4"
        ElseIf (iLongSide < (297 - iMargin)) And (iShortSide < (210 - iMargin)) Then
            'A4未満
            Return "A4未満"
        Else
            'それ以外
            Return "不定形"
        End If

    End Function
#End Region
End Class