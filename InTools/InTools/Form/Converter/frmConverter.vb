Imports C1.Win.FlexReport
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports iFont = iTextSharp.text.Font

Public Class frmConverter

#Region "プライベート変数"
    Private BackMenuFlag As Boolean = False
    Private Enum InFormat
        TIFF
        JPEG
        TIFFJPEG
        PDF
    End Enum
    Private Enum OutFormat
        TIFF
        JPEG
        PDF
    End Enum

    Private CancelFlag As Boolean = False

#End Region
#Region "フォームイベント"
    ''' <summary>
    ''' フォームロード
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub frmAlibi_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ImageMagick.MagickNET.SetGhostscriptDirectory(Application.StartupPath & "\GhostScript")
        System.IO.Directory.CreateDirectory(Application.StartupPath & "\Cnv_Temp")
        ImageMagick.MagickNET.SetTempDirectory(Application.StartupPath & "\Cnv_Temp")


        Me.fgrFileList.Rows.Count = 1

        Me.txtSrcPath.Text = My.Settings.Cnv_SrcPath
        Me.cmbSrcFormat.SelectedIndex = My.Settings.Cnv_SrcFormat
        Me.txtDstPath.Text = My.Settings.Cnv_DstPath
        Me.cmbDstFormat.SelectedIndex = My.Settings.Cnv_DstFormat

        Me.cmbCompress.DataSource = GetCompress(My.Settings.Cnv_DstFormat)
        Me.cmbCompress.SelectedIndex = My.Settings.Cnv_DstCompress
        Me.rbSingle.Checked = Not My.Settings.Cnv_Multi
        Me.rbMulti.Checked = My.Settings.Cnv_Multi

        If Not System.IO.Directory.Exists(My.Settings.Cnv_LF) Then
            My.Settings.Cnv_LF = System.Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)
            My.Settings.Save()
        End If

        Me.cmbDPI.DataSource = GetDPI()
        Me.cmbDPI.SelectedIndex = My.Settings.Cnv_DPI

        EnableSwitch(True)
        ChangeFormat()

    End Sub
    ''' <summary>
    ''' フォームクローズ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub frmAlibi_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

        My.Settings.Cnv_SrcPath = Me.txtSrcPath.Text
        My.Settings.Cnv_SrcFormat = Me.cmbSrcFormat.SelectedIndex
        My.Settings.Cnv_DstPath = Me.txtDstPath.Text
        My.Settings.Cnv_DstFormat = Me.cmbDstFormat.SelectedIndex
        My.Settings.Cnv_DstCompress = Me.cmbCompress.SelectedIndex
        My.Settings.Cnv_Multi = Not Me.rbSingle.Checked
        My.Settings.Cnv_DPI = Me.cmbDPI.SelectedIndex
        My.Settings.Save()
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
    ''' 入出力フォーマット変更時
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub cmbSrcFormat_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSrcFormat.SelectedIndexChanged, cmbDstFormat.SelectedIndexChanged
        ChangeFormat()
    End Sub

    ''' <summary>
    ''' 変換
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnConvert_Click(sender As Object, e As EventArgs) Handles btnConvert.Click
        If Not System.IO.Directory.Exists(My.Settings.Cnv_LF) Then
            MessageBox.Show("ログフォルダが存在しません。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If
        If Not System.IO.Directory.Exists(Me.txtSrcPath.Text) Then
            MessageBox.Show("変換元フォルダが存在しません。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If
        If Not System.IO.Directory.Exists(Me.txtDstPath.Text) Then
            MessageBox.Show("変換先フォルダが存在しません。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If
        If MessageBox.Show("画像の変換を開始します。" & vbNewLine & "よろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
            Exit Sub
        End If

        EnableSwitch(False)
        Me.fgrFileList.Rows.Count = 1
        Dim dstFolder As String = ""
        Dim LogPath As String = My.Settings.Cnv_LF & "\InToolsConvertLog_" & System.DateTime.Now.ToString("yyyyMMddHHmmss") & ".log"
        Dim DoneTime As String = ""
        Dim DstExtention As String = GetExtention(Me.cmbDstFormat.SelectedIndex)
        Me.txtErrorCount1.Text = 0

        '変換設定
        Dim imgMagick As New ImageMagick.MagickImage

        System.Windows.Forms.Application.DoEvents()

        '自然順ソートで並び替えられた配列を取得する
        Dim Extensions As String()
        Select Case Me.cmbSrcFormat.SelectedIndex
            Case InFormat.TIFF
                ReDim Extensions(1)
                Extensions(0) = "*.tif"
                Extensions(1) = "*.tiff"
            Case InFormat.JPEG
                ReDim Extensions(0)
                Extensions(0) = "*.jpg"
            Case InFormat.TIFFJPEG
                ReDim Extensions(2)
                Extensions(0) = "*.tif"
                Extensions(1) = "*.tiff"
                Extensions(2) = "*.jpg"
            Case Else
                ReDim Extensions(0)
                Extensions(0) = "*.pdf"
        End Select

        Me.Label.Text = "画像パスを取得しています。"
        '自然順ソートで並び替えられた配列を取得する
        Dim ordFiles As String() = GetFilesMostDeep(Me.txtSrcPath.Text, Extensions)
        Me.Label.Text = "変換中です。"


        Dim OutPageCount As Integer = 0
        '書き出し
        If Me.rbSingle.Checked = True Then
            'シングル
            'プログレス
            Me.pgbFiles.Minimum = 0
            Me.pgbFiles.Value = 0
            Me.pgbFiles.Maximum = ordFiles.Count
            Me.txtProgress.Text = Me.pgbFiles.Value & "/" & Me.pgbFiles.Maximum
            Me.txtErrorCount1.Text = 0

            System.Windows.Forms.Application.DoEvents()

            If ordFiles.Count = 0 Then
                MessageBox.Show("変換対象ファイルが見つかりませんでした。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                EnableSwitch(True)
                Exit Sub
            End If



            For i As Integer = 0 To ordFiles.Count - 1
                Dim ErrorFlag As Boolean = False
                Dim srcPath As String = ordFiles(i)
                Dim imgFileName As String = System.IO.Path.GetFileNameWithoutExtension(srcPath)
                Dim srcDirPath As String = System.IO.Path.GetDirectoryName(srcPath)
                OutPageCount = 1
                If srcDirPath = Me.txtSrcPath.Text Then
                    dstFolder = Me.txtDstPath.Text & "\" & System.IO.Path.GetFileName(srcDirPath)
                Else
                    dstFolder = srcDirPath.Replace(Me.txtSrcPath.Text, Me.txtDstPath.Text)
                End If

                '書き出し
                Try

                    If Me.cmbSrcFormat.SelectedIndex = InFormat.PDF Then
                        OutPageCount = BurstMultiPDF(srcPath, dstFolder & "\" & imgFileName)
                        '存在確認
                        ErrorFlag = Not System.IO.Directory.Exists(dstFolder & "\" & imgFileName)
                    ElseIf DstExtention = ".pdf" Then
                        'シングルPDF変換
                        System.IO.Directory.CreateDirectory(dstFolder)
                        Dim doc As Document = New Document()
                        Dim pcb As New PdfContentByte(Nothing)

                        '画像読み込み
                        Dim Image As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(New Uri(ordFiles(i)))

                        Dim cmbDPIX As Integer = Image.DpiX
                        Dim cmbDPIY As Integer = Image.DpiY

                        Dim ImageX As Single = (Image.PlainWidth / cmbDPIX) * 25.4F * 2.834F
                        Dim ImageY As Single = (Image.PlainHeight / cmbDPIY) * 25.4F * 2.834F

                        Dim rect As iTextSharp.text.Rectangle = New iTextSharp.text.Rectangle(ImageX, ImageY)
                        '新規PDF作成
                        doc = New Document()
                        Dim pw As PdfWriter = PdfWriter.GetInstance(doc, New System.IO.FileStream(dstFolder & "\" & imgFileName & DstExtention, System.IO.FileMode.Create))

                        'ページサイズ設定
                        doc.SetPageSize(rect)
                        doc.Open()

                        pcb = pw.DirectContent

                        '画像配置位置
                        Image.SetAbsolutePosition(0.0F, 0.0F)

                        '縮尺(72dpi計算のため、スケール補正)
                        Dim prcScale As Long = (72 / cmbDPIX) * 100
                        Image.ScalePercent(prcScale)
                        '画像追加
                        pcb.AddImage(Image)

                        doc.Close()
                        pw.Dispose()
                        '存在確認
                        ErrorFlag = Not System.IO.File.Exists(dstFolder & "\" & imgFileName & DstExtention)
                    ElseIf Me.cmbSrcFormat.SelectedIndex = InFormat.TIFF Then
                        Dim MultiTiff As New ImageMagick.MagickImageCollection(srcPath)

                        If MultiTiff.Count = 1 Then
                            MultiTiff.Dispose()
                            System.IO.Directory.CreateDirectory(dstFolder)
                            imgMagick = ConvertLoad(srcPath)
                            imgMagick.Write(dstFolder & "\" & imgFileName & DstExtention)
                            imgMagick.Dispose()
                            '存在確認
                            ErrorFlag = Not System.IO.File.Exists(dstFolder & "\" & imgFileName & DstExtention)
                        Else
                            'マルチtifの場合
                            dstFolder = dstFolder & "\" & imgFileName
                            System.IO.Directory.CreateDirectory(dstFolder)
                            For p As Integer = 0 To MultiTiff.Count - 1
                                Dim tif As ImageMagick.MagickImage = MultiTiff(p)
                                imgMagick = ConvertLoad(tif)
                                imgMagick.Write(dstFolder & "\" & String.Format("{0:D4}", p + 1) & DstExtention)
                                imgMagick.Dispose()
                            Next
                            '存在確認
                            ErrorFlag = Not System.IO.Directory.Exists(dstFolder)
                            OutPageCount = MultiTiff.Count
                        End If
                    Else
                        System.IO.Directory.CreateDirectory(dstFolder)
                        imgMagick = ConvertLoad(srcPath)
                        imgMagick.Write(dstFolder & "\" & imgFileName & DstExtention)
                        imgMagick.Dispose()
                        '存在確認
                        ErrorFlag = Not System.IO.File.Exists(dstFolder & "\" & imgFileName & DstExtention)
                    End If

                Catch ex As Exception
                    ErrorFlag = True
                End Try




                '進捗表示
                DoneTime = System.DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss")

                Me.fgrFileList.Rows.Count += 1
                Me.fgrFileList.Rows(Me.fgrFileList.Rows.Count - 1)("No.") = Me.fgrFileList.Rows.Count - 1
                Me.fgrFileList.Rows(Me.fgrFileList.Rows.Count - 1)("変換パス") = dstFolder & "\" & imgFileName & DstExtention
                Me.fgrFileList.Rows(Me.fgrFileList.Rows.Count - 1)("進捗") = IIf(ErrorFlag = False, "完了", "変換エラー")
                Me.fgrFileList.Rows(Me.fgrFileList.Rows.Count - 1)("入力ページ数") = OutPageCount
                Me.fgrFileList.Rows(Me.fgrFileList.Rows.Count - 1)("出力ページ数") = IIf(ErrorFlag = False, OutPageCount, 0)
                Me.fgrFileList.Rows(Me.fgrFileList.Rows.Count - 1)("完了時刻") = DoneTime
                WriteLog(LogPath, dstFolder & DstExtention & vbTab & IIf(ErrorFlag = False, "完了", "変換エラー") & vbTab & DoneTime)

                If ErrorFlag = True Then
                    Me.txtErrorCount1.Text = CInt(Me.txtErrorCount1.Text) + 1
                End If

                'キャンセルボタンが押された場合
                If CancelFlag = True Then
                    Me.fgrFileList.Rows(Me.fgrFileList.Rows.Count - 1)("進捗") = "中断"
                    DoneTime = System.DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss")
                    Me.fgrFileList.Rows(Me.fgrFileList.Rows.Count - 1)("完了時刻") = DoneTime
                    WriteLog(LogPath, "" & vbTab & "中断" & vbTab & DoneTime)
                    Exit For
                End If

                Me.fgrFileList.AutoSizeCols(0, 1, 0)
                Me.pgbFiles.Value += 1
                Me.txtProgress.Text = Me.pgbFiles.Value & "/" & Me.pgbFiles.Maximum

                Me.fgrFileList.ShowCell(Me.fgrFileList.Rows.Count - 1, 0)

                System.Windows.Forms.Application.DoEvents()
            Next
        ElseIf Me.rbMulti.Checked = True Then
            'マルチ
            'ファイル配列からフォルダ配列を作成する。
            Dim aryDirectory As New ArrayList
            Dim htMultiPageCount As New Hashtable
            For i As Integer = 0 To ordFiles.Count - 1
                Dim DirName As String = System.IO.Path.GetDirectoryName(ordFiles(i))
                If aryDirectory.IndexOf(DirName) = -1 Then
                    aryDirectory.Add(DirName)
                End If
                htMultiPageCount(DirName) += 1
            Next

            'プログレス
            Me.pgbFiles.Minimum = 0
            Me.pgbFiles.Value = 0
            Me.pgbFiles.Maximum = aryDirectory.Count
            Me.txtProgress.Text = Me.pgbFiles.Value & "/" & Me.pgbFiles.Maximum
            Me.txtErrorCount1.Text = 0

            Dim dstMultiFile As String = ""
            Dim srcDirPath As String = ""
            Dim PageCount As Integer = 0
            Dim closeFlag As Boolean = True

            'PDF用
            Dim doc As Document = New Document()
            Dim pcb As New PdfContentByte(Nothing)
            Dim objPDFCopy As PdfCopy = Nothing
            'TIFF用
            Dim MultiTiff As ImageMagick.MagickImageCollection = Nothing
            Dim TIFFReadImage As New ImageMagick.MagickImage


            For i As Integer = 0 To ordFiles.Count - 1
                '画像読み込み
                Dim PDFReadImage As iTextSharp.text.Image = Nothing
                Dim ImageY As Single = 0
                Dim ImageX As Single = 0
                Dim cmbDPIX As Integer = 0
                Dim cmbDPIY As Integer = 0

                Dim rect As iTextSharp.text.Rectangle = Nothing

                If Me.cmbDstFormat.Items(Me.cmbDstFormat.SelectedIndex) = "PDF" Then
                    If Not Me.cmbSrcFormat.SelectedIndex = InFormat.PDF Then
                        PDFReadImage = iTextSharp.text.Image.GetInstance(New Uri(ordFiles(i)))
                        cmbDPIX = PDFReadImage.DpiX
                        cmbDPIY = PDFReadImage.DpiY
                        ImageX = (PDFReadImage.PlainWidth / cmbDPIX) * 25.4F * 2.834F
                        ImageY = (PDFReadImage.PlainHeight / cmbDPIY) * 25.4F * 2.834F
                        rect = New iTextSharp.text.Rectangle(ImageX, ImageY)
                    End If
                End If

                '前ファイルのフォルダと異なる場合
                If Not srcDirPath = System.IO.Path.GetDirectoryName(ordFiles(i)) Then
                    PageCount = 1
                    srcDirPath = System.IO.Path.GetDirectoryName(ordFiles(i))

                    '出力フォルダ設定
                    If srcDirPath = Me.txtSrcPath.Text Then
                        dstFolder = Me.txtDstPath.Text & "\" & System.IO.Path.GetFileName(srcDirPath)
                    Else
                        dstFolder = srcDirPath.Replace(Me.txtSrcPath.Text, Me.txtDstPath.Text)
                    End If

                    '出力フォルダ作成
                    System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(dstFolder))

                    If Me.cmbDstFormat.Items(Me.cmbDstFormat.SelectedIndex) = "PDF" Then
                        '新規PDF作成
                        dstMultiFile = System.IO.Path.GetDirectoryName(dstFolder) & "\" & System.IO.Path.GetFileName(dstFolder) & ".pdf"
                        doc = New Document()

                        If Me.cmbSrcFormat.SelectedIndex = InFormat.PDF Then
                            objPDFCopy = New PdfCopy(doc, New System.IO.FileStream(dstMultiFile, System.IO.FileMode.Create, System.IO.FileAccess.Write))
                            doc.Open()
                        Else

                            Dim pw As PdfWriter = PdfWriter.GetInstance(doc, New System.IO.FileStream(dstMultiFile, System.IO.FileMode.Create))

                            'ページサイズ設定
                            doc.SetPageSize(rect)
                            doc.Open()
                            pcb = pw.DirectContent
                        End If
                    Else
                        '新規TIFF作成
                        MultiTiff = New ImageMagick.MagickImageCollection
                    End If


                    closeFlag = False

                    Me.fgrFileList.Rows.Count += 1
                    Me.fgrFileList.Rows(Me.fgrFileList.Rows.Count - 1)("No.") = Me.fgrFileList.Rows.Count - 1
                    Me.fgrFileList.Rows(Me.fgrFileList.Rows.Count - 1)("変換パス") = dstFolder & DstExtention
                    Me.fgrFileList.Rows(Me.fgrFileList.Rows.Count - 1)("進捗") = "書込み中...(" & PageCount & "/" & htMultiPageCount(srcDirPath) & ")"
                    Me.fgrFileList.AutoSizeCols(0, 1, 0)
                Else
                    If Me.cmbDstFormat.Items(Me.cmbDstFormat.SelectedIndex) = "PDF" Then
                        If Not Me.cmbSrcFormat.SelectedIndex = InFormat.PDF Then
                            'ページサイズ設定
                            doc.SetPageSize(rect)
                            doc.NewPage()
                        End If
                    End If

                    PageCount += 1
                    Me.fgrFileList.Rows(Me.fgrFileList.Rows.Count - 1)("進捗") = "書込み中...(" & PageCount & "/" & htMultiPageCount(srcDirPath) & ")"
                End If

                If Me.cmbDstFormat.Items(Me.cmbDstFormat.SelectedIndex) = "PDF" Then
                    If Me.cmbSrcFormat.SelectedIndex = InFormat.PDF Then
                        Dim objPdfReader As PdfReader = New PdfReader(ordFiles(i))
                        objPDFCopy.AddDocument(objPdfReader)
                        objPdfReader.Close()
                    Else
                        '画像配置位置
                        PDFReadImage.SetAbsolutePosition(0.0F, 0.0F)

                        '縮尺(72dpi計算のため、スケール補正)
                        Dim prcScale As Long = (72 / cmbDPIX) * 100
                        PDFReadImage.ScalePercent(prcScale)

                        '画像追加
                        pcb.AddImage(PDFReadImage)
                    End If
                Else
                    TIFFReadImage = ConvertLoad(ordFiles(i))
                    MultiTiff.Add(TIFFReadImage)
                    MultiTiff.RePage()
                End If


                'クローズ処理
                If PageCount = htMultiPageCount(srcDirPath) Then
                    Dim PageChk As Boolean = False
                    OutPageCount = 0

                    If Me.cmbDstFormat.Items(Me.cmbDstFormat.SelectedIndex) = "PDF" Then
                        If Me.cmbSrcFormat.SelectedIndex = InFormat.PDF Then
                            objPDFCopy.Close()
                        End If
                        doc.Close()
                    Else
                        dstMultiFile = System.IO.Path.GetDirectoryName(dstFolder) & "\" & System.IO.Path.GetFileName(dstFolder) & ".tif"
                        MultiTiff.Write(dstMultiFile)
                        OutPageCount = MultiTiff.Count
                        MultiTiff.Dispose()
                    End If

                    closeFlag = True

                    '存在確認
                    Dim ExistsFlag As Boolean = System.IO.File.Exists(dstMultiFile)

                    'ページ数確認
                    If ExistsFlag = True Then
                        If Me.cmbDstFormat.Items(Me.cmbDstFormat.SelectedIndex) = "PDF" Then
                            Dim PDFInfo As PdfReader = New PdfReader(dstMultiFile)
                            OutPageCount = PDFInfo.NumberOfPages
                            PDFInfo.Dispose()
                        End If
                        PageChk = IIf(OutPageCount = PageCount, True, False)
                    End If

                    DoneTime = System.DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss")

                    Me.fgrFileList.Rows(Me.fgrFileList.Rows.Count - 1)("進捗") = IIf(PageChk = True, "完了", "変換エラー")
                    Me.fgrFileList.Rows(Me.fgrFileList.Rows.Count - 1)("入力ページ数") = PageCount
                    Me.fgrFileList.Rows(Me.fgrFileList.Rows.Count - 1)("出力ページ数") = OutPageCount
                    Me.fgrFileList.Rows(Me.fgrFileList.Rows.Count - 1)("完了時刻") = DoneTime
                    WriteLog(LogPath, dstFolder & DstExtention & vbTab & IIf(PageChk = True, "完了", "変換エラー") & vbTab & "入力:" & PageCount & vbTab & "出力:" & OutPageCount & vbTab & DoneTime)

                    'エラーカウント
                    If PageChk = False Then
                        Me.txtErrorCount1.Text = CInt(Me.txtErrorCount1.Text) + 1
                    End If

                    '表示更新
                    Me.fgrFileList.AutoSizeCols(0, 1, 0)
                    Me.pgbFiles.Value += 1
                    Me.txtProgress.Text = Me.pgbFiles.Value & "/" & Me.pgbFiles.Maximum
                    Me.fgrFileList.ShowCell(Me.fgrFileList.Rows.Count - 1, 0)

                End If

                'キャンセルボタンが押された場合
                If CancelFlag = True Then
                    Me.fgrFileList.Rows(Me.fgrFileList.Rows.Count - 1)("進捗") = "中断"
                    DoneTime = System.DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss")
                    Me.fgrFileList.Rows(Me.fgrFileList.Rows.Count - 1)("完了時刻") = DoneTime
                    WriteLog(LogPath, "" & vbTab & "中断" & vbTab & DoneTime)
                    Exit For
                End If

                System.Windows.Forms.Application.DoEvents()
            Next

        End If

        If CancelFlag = True Then
            CancelFlag = False
            MessageBox.Show("処理を中断しました。", "中断", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Label.Text = "中断しました。"
        ElseIf CInt(Me.txtErrorCount1.Text) > 0 Then
            MessageBox.Show("エラーファイルが存在します。" & vbNewLine & "ログを確認してください。", "完了", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Label.Text = "完了しました。（エラーあり）"
        Else
            MessageBox.Show("変換が完了しました。", "完了", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Label.Text = "完了しました。"
        End If

        EnableSwitch(True)
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
    ''' オプション
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnOption_Click(sender As Object, e As EventArgs) Handles btnOption.Click
        Dim f As New frmOption
        f.ShowDialog()
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
    ''' 変換画像ロード
    ''' </summary>
    ''' <param name="ImagePath"></param>
    ''' <returns></returns>
    Private Overloads Function ConvertLoad(ByVal ImagePath As String) As ImageMagick.MagickImage
        '変換設定
        Dim imgMagick As New ImageMagick.MagickImage
        Dim curCompress As String = Me.cmbCompress.SelectedItem
        Dim imgSetting As New ImageMagick.MagickReadSettings

        '解像度設定
        If Not cmbDPI.SelectedIndex = 0 Then
            Dim Density As Double = CDbl(GetDPI(cmbDPI.SelectedIndex))
            imgSetting.Density = New ImageMagick.Density(Density)
        End If

        'タイムスタンプが存在しない場合付与する。
        '存在しないときは、UTCの 1601/01/01 9:00:00 を返す
        If System.IO.File.GetCreationTime(ImagePath) <= CDate("2000/01/01") Or System.IO.File.GetCreationTime(ImagePath) > DateTime.Now Then
            'ファイル各日時の設定（今の時間にする）
            System.IO.File.SetCreationTime(ImagePath, DateTime.Now)
            System.IO.File.SetLastWriteTime(ImagePath, DateTime.Now)
            System.IO.File.SetLastAccessTime(ImagePath, DateTime.Now)
        End If

        Select Case curCompress
            Case "変更しない"
                imgMagick.Read(ImagePath, imgSetting)
            Case "非圧縮"
                imgMagick.Read(ImagePath, imgSetting)
                imgMagick.CompressionMethod = ImageMagick.CompressionMethod.NoCompression
            Case "JPEG"

                If My.Settings.Cnv_SelectJPEGQuality = False Then
                    imgSetting.SetDefine(ImageMagick.MagickFormat.Jpg, "extent", My.Settings.Cnv_JPEGSize & "kb")
                    imgMagick.Read(ImagePath, imgSetting)
                Else
                    imgMagick.Read(ImagePath, imgSetting)
                    imgMagick.Quality = My.Settings.Cnv_JPEGQuality
                End If

                imgMagick.CompressionMethod = ImageMagick.CompressionMethod.JPEG

            Case "LZW"
                imgMagick.Read(ImagePath, imgSetting)
                imgMagick.CompressionMethod = ImageMagick.CompressionMethod.LZW
            Case "Group4"
                imgSetting.UseMonochrome = True
                imgMagick.Read(ImagePath, imgSetting)
                imgMagick.CompressionMethod = ImageMagick.CompressionMethod.Group4
                imgMagick.Depth = 1
                If My.Settings.Cnv_SelectBinDither = False Then
                    Dim Threshold As Integer = Math.Round(My.Settings.Cnv_Threshold / 2.55, MidpointRounding.AwayFromZero)
                    imgMagick.Threshold(Threshold)
                End If
        End Select

        Return imgMagick
    End Function

    Private Overloads Function ConvertLoad(ByVal MagickImage As ImageMagick.MagickImage) As ImageMagick.MagickImage
        '変換設定
        Dim imgMagick As New ImageMagick.MagickImage
        Dim curCompress As String = Me.cmbCompress.SelectedItem
        Dim imgSetting As New ImageMagick.MagickReadSettings

        '解像度設定
        If Not cmbDPI.SelectedIndex = 0 Then
            Dim Density As Double = CDbl(GetDPI(cmbDPI.SelectedIndex))
            imgSetting.Density = New ImageMagick.Density(Density)
        End If

        Select Case curCompress
            Case "変更しない"
                imgMagick.Read(MagickImage, imgSetting)
            Case "非圧縮"
                imgMagick.Read(MagickImage, imgSetting)
                imgMagick.CompressionMethod = ImageMagick.CompressionMethod.NoCompression
            Case "JPEG"

                If My.Settings.Cnv_SelectJPEGQuality = False Then
                    imgSetting.SetDefine(ImageMagick.MagickFormat.Jpg, "extent", My.Settings.Cnv_JPEGSize & "kb")
                    imgMagick.Read(MagickImage, imgSetting)
                Else
                    imgMagick.Read(MagickImage, imgSetting)
                    imgMagick.Quality = My.Settings.Cnv_JPEGQuality
                End If

                imgMagick.CompressionMethod = ImageMagick.CompressionMethod.JPEG

            Case "LZW"
                imgMagick.Read(MagickImage, imgSetting)
                imgMagick.CompressionMethod = ImageMagick.CompressionMethod.LZW
            Case "Group4"
                imgSetting.UseMonochrome = True
                imgMagick.Read(MagickImage, imgSetting)
                imgMagick.CompressionMethod = ImageMagick.CompressionMethod.Group4
                imgMagick.Depth = 1
                If My.Settings.Cnv_SelectBinDither = False Then
                    Dim Threshold As Integer = Math.Round(My.Settings.Cnv_Threshold / 2.55, MidpointRounding.AwayFromZero)
                    imgMagick.Threshold(Threshold)
                End If
        End Select

        Return imgMagick
    End Function

    ''' <summary>
    ''' 有効無効切り替え
    ''' </summary>
    ''' <param name="Switch"></param>
    Private Sub EnableSwitch(ByVal Switch As Boolean)
        Me.btnBackMenu.Enabled = Switch
        Me.btnConvert.Enabled = Switch
        Me.btnOption.Enabled = Switch
        Me.cmbSrcFormat.Enabled = Switch
        Me.cmbDstFormat.Enabled = Switch
        Me.cmbCompress.Enabled = Switch
        Me.txtSrcPath.Enabled = Switch
        Me.txtDstPath.Enabled = Switch
        Me.rbMulti.Enabled = Switch
        Me.rbSingle.Enabled = Switch

        Me.btnCancel.Enabled = Not Switch

    End Sub

    ''' <summary>
    ''' マルチPDF分割
    ''' </summary>
    ''' <param name="sOrigPDFPath"></param>
    ''' <param name="sOutputPath"></param>
    ''' <returns></returns>
    Private Function BurstMultiPDF(ByVal sOrigPDFPath As String, ByVal sOutputPath As String) As Integer
        Dim PageCount = 0

        Dim objPdfReader As PdfReader = New PdfReader(sOrigPDFPath)
        PageCount = objPdfReader.NumberOfPages

        For i As Integer = 1 To objPdfReader.NumberOfPages
            Dim objITextDoc As Document = Nothing
            Dim objPDFWriter As PdfWriter = Nothing
            Dim objPDFContByte As PdfContentByte = Nothing
            Dim objPDFImpPage As PdfImportedPage = Nothing

            Try
                Dim sNewPDFPath As String = sOutputPath & "\" & i.ToString("D4") & ".pdf"

                System.IO.Directory.CreateDirectory(sOutputPath)
                objITextDoc = New Document(objPdfReader.GetPageSize(i))
                objPDFWriter = PdfWriter.GetInstance(objITextDoc, New System.IO.FileStream(sNewPDFPath, System.IO.FileMode.OpenOrCreate))
                objITextDoc.Open()
                objPDFContByte = objPDFWriter.DirectContent
                objITextDoc.NewPage()
                objPDFImpPage = objPDFWriter.GetImportedPage(objPdfReader, i)
                objPDFContByte.AddTemplate(objPDFImpPage, 0, 0)

            Catch ex As Exception
                MessageBox.Show(ex.Message)
            Finally
                objITextDoc.Close()
                objPDFWriter.Close()
            End Try
        Next

        objPdfReader.Close()

        Return PageCount
    End Function

    ''' <summary>
    ''' 入出力フォーマット変更時
    ''' </summary>
    Private Sub ChangeFormat()
        Me.cmbDPI.DataSource = GetDPI()

        If Me.cmbSrcFormat.Items(Me.cmbSrcFormat.SelectedIndex) = "PDF" Then
            Me.cmbCompress.SelectedIndex = 0
            Me.cmbCompress.Enabled = False
            Me.cmbDstFormat.SelectedIndex = OutFormat.PDF
            Me.cmbDstFormat.Enabled = False
        Else
            Me.cmbCompress.Enabled = True
            Me.cmbDstFormat.Enabled = True
        End If

        If Not Me.cmbDstFormat.SelectedIndex < 0 Then
            Me.cmbCompress.DataSource = GetCompress(Me.cmbDstFormat.SelectedIndex)
            Me.cmbCompress.SelectedIndex = 0
            Me.cmbDPI.Enabled = True

            If Me.cmbDstFormat.Items(Me.cmbDstFormat.SelectedIndex) = "PDF" Or Me.cmbDstFormat.Items(Me.cmbDstFormat.SelectedIndex) = "TIFF" Then
                Me.rbSingle.Enabled = True
                Me.rbMulti.Enabled = True
                If Me.cmbDstFormat.Items(Me.cmbDstFormat.SelectedIndex) = "PDF" Then
                    Me.cmbDPI.SelectedIndex = 0
                    Me.cmbDPI.Enabled = False
                End If
            Else
                Me.rbSingle.Checked = True
                Me.rbSingle.Enabled = False
                Me.rbMulti.Enabled = False
            End If
        End If
    End Sub

#End Region
End Class