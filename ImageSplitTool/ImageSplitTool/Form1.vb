Imports ImageMagick
Public Class Form1

    ''' <summary>
    ''' 開始ボタン押下時
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click

        If Not System.IO.Directory.Exists(Me.txtTargetFolder.Text) Then
            MessageBox.Show("対象フォルダを指定してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        If Not System.IO.Directory.Exists(Me.txtSaveFolder.Text) Then
            MessageBox.Show("保存フォルダを指定してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        If Me.cmbExt.SelectedIndex < 0 Then
            MessageBox.Show("画像フォーマットを選択してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Me.lstResult.Items.Clear()

        If MessageBox.Show("対象フォルダ内の指定の画像フォーマットの分割処理を行います" & vbNewLine & "よろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
            Exit Sub
        End If

        Try

            Dim strTargetFolder As String = Me.txtTargetFolder.Text
            Dim strSaveFolder As String = Me.txtSaveFolder.Text
            Dim strExt As String() = {Me.cmbExt.SelectedItem.ToString}

            '対象ファイルの列挙
            Dim strFiles As String() = GetFilesMostDeep(strTargetFolder, strExt)
            WriteLstResult(Me.lstResult, strFiles.Count & "個の画像ファイルを確認")

            Dim listWidth As New List(Of Integer)   '横方向の起点を格納するコレクション
            Dim listHeight As New List(Of Integer)  '縦号校の起点を格納するコレクション

            Me.ProgressBar1.Maximum = strFiles.Count
            Me.ProgressBar1.Value = 0
            Me.lblProgress.Text = Me.ProgressBar1.Value & " / " & Me.ProgressBar1.Maximum

            For Each strFile As String In strFiles

                'Listの初期化
                listWidth.Clear()
                listHeight.Clear()

                '画像ファイル単位のログを出力する
                Dim strLog As String = System.IO.Path.GetDirectoryName(strFile.Replace(strTargetFolder, strSaveFolder)) & "\" & System.IO.Path.GetFileNameWithoutExtension(strFile) & "_" & Date.Now.ToString("yyyyMMdd_HHmmss") & ".log"
                If Not System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(strLog)) Then
                    My.Computer.FileSystem.CreateDirectory(System.IO.Path.GetDirectoryName(strLog))
                End If

                Using sw As New System.IO.StreamWriter(strLog, False, System.Text.Encoding.GetEncoding("Shift-JIS"))

                    '各画像ファイル単位の処理
                    WriteLstResult(Me.lstResult, "==================================================")
                    WriteLstResult(Me.lstResult, "==================================================")
                    WriteLstResult(Me.lstResult, System.IO.Path.GetFileName(strFile) & "の処理を開始")
                    sw.WriteLine("処理開始：" & Date.Now.ToString("yyyy/MM/dd HH:mm:ss"))
                    Dim img As New MagickImage(strFile)
                    Dim idpi As Integer = img.Density.X
                    Dim iWidth As Integer = img.Width
                    Dim iHeight As Integer = img.Height
                    img.Dispose()
                    Dim iCropX As Integer = Me.numCropX.Value   'A2画像横ピクセル
                    Dim iCropY As Integer = Me.numCropY.Value   'A2画像縦ピクセル
                    If iWidth < iCropX Or iHeight < iCropY Then
                        WriteLstResult(Me.lstResult, "分割サイズ：(" & iCropX & ", " & iCropY & ")より、原本サイズ：(" & iWidth & ", " & iHeight & ")のほうが小さいため単純コピー")
                        My.Computer.FileSystem.CopyFile(strFile, System.IO.Path.GetDirectoryName(strLog) & "\" & System.IO.Path.GetFileName(strFile))
                        Continue For
                    End If
                    sw.WriteLine("==================================================")
                    sw.WriteLine("ファイル名：" & System.IO.Path.GetFileName(strFile))
                    sw.WriteLine("原本横：" & iWidth)
                    sw.WriteLine("原本縦：" & iHeight)
                    sw.WriteLine("DPI：" & idpi)

                    WriteLstResult(Me.lstResult, "DPI：" & idpi & " 横：" & iWidth & " 縦：" & iHeight)
                    WriteLstResult(Me.lstResult, "==================================================")
                    WriteLstResult(Me.lstResult, "横方向の処理")
                    '1.原本に対して横方向に「A2画像」の必要枚数を算出
                    Dim iSheets As Integer = Math.Ceiling(iWidth / iCropX)   '切り上げ
                    WriteLstResult(Me.lstResult, "横方向必要枚数：" & iSheets)
                    '2.重複部分の算出
                    Dim iTotalOverlap As Integer = (iCropX * iSheets) - iWidth  '重複部分の総ピクセル数
                    WriteLstResult(Me.lstResult, "重複部分の総ピクセル数：" & iTotalOverlap)
                    Dim iRelated As Integer = iTotalOverlap / (iSheets - 1) '隣接部分の重複ピクセル数
                    WriteLstResult(Me.lstResult, "隣接部分の重複ピクセル数：" & iRelated)
                    Dim iRelatedRemainder As Integer = iTotalOverlap Mod (iSheets - 1)  '重複ピクセル数の余り
                    WriteLstResult(Me.lstResult, "重複ピクセル数の余り：" & iRelatedRemainder)
                    'iRelatedが800未満の場合は、A2画像を1枚足して再計算
                    If iRelated < 800 Then
                        WriteLstResult(Me.lstResult, "隣接部分の重複ピクセル数が800ピクセル未満のため再計算します")
                        sw.WriteLine("隣接部分の重複ピクセル数が800ピクセル未満のため再計算：" & iRelated)
                        iSheets += 1
                        WriteLstResult(Me.lstResult, "横方向必要枚数：" & iSheets)
                        '2.重複部分の算出
                        iTotalOverlap = (iCropX * iSheets) - iWidth  '重複部分の総ピクセル数
                        WriteLstResult(Me.lstResult, "重複部分の総ピクセル数：" & iTotalOverlap)
                        iRelated = iTotalOverlap / (iSheets - 1) '隣接部分の重複ピクセル数
                        WriteLstResult(Me.lstResult, "隣接部分の重複ピクセル数：" & iRelated)
                        iRelatedRemainder = iTotalOverlap Mod (iSheets - 1)  '重複ピクセル数の余り
                        WriteLstResult(Me.lstResult, "重複ピクセル数の余り：" & iRelatedRemainder)
                    End If

                    sw.WriteLine("==================================================")
                    sw.WriteLine("横方向必要枚数：" & iSheets)
                    sw.WriteLine("重複部分の総ピクセル数：" & iTotalOverlap)
                    sw.WriteLine("隣接部分の重複ピクセル数：" & iRelated)
                    sw.WriteLine("重複ピクセル数の余り：" & iRelatedRemainder)

                    '3.各「A2画像」の起点を重複部分を考慮して算出
                    Dim iStartPoint As Integer = 0
                    For iSheet As Integer = 1 To iSheets
                        If iSheet = 1 Then
                            '1回目は起点0が確定
                            listWidth.Add(iStartPoint)
                            Continue For
                        ElseIf iSheet = 2 Then
                            '2回目の起点から重複ピクセルの余りを減算する
                            iStartPoint = (iStartPoint + iCropX) - iRelated - iRelatedRemainder
                            listWidth.Add(iStartPoint)
                        Else
                            '3回目以降
                            iStartPoint = (iStartPoint + iCropX) - iRelated
                            listWidth.Add(iStartPoint)
                        End If
                    Next
                    '4.それぞれの「A2画像」に対応する起点のx軸が確定する
                    For i As Integer = 0 To listWidth.Count - 1
                        WriteLstResult(Me.lstResult, i + 1 & "枚目の起点X：" & listWidth(i))
                        sw.WriteLine("横方向" & i + 1 & "枚目の起点：" & listWidth(i))
                    Next

                    WriteLstResult(Me.lstResult, "==================================================")
                    WriteLstResult(Me.lstResult, "縦方向の処理")
                    '5.原本に対して縦方向に「A2画像」の必要枚数を算出
                    iSheets = Math.Ceiling(iHeight / iCropY)   '切り上げ
                    WriteLstResult(Me.lstResult, "縦方向必要枚数：" & iSheets)
                    '6.重複部分の算出
                    iTotalOverlap = (iCropY * iSheets) - iHeight  '重複部分の総ピクセル数
                    WriteLstResult(Me.lstResult, "重複部分の総ピクセル数：" & iTotalOverlap)
                    iRelated = iTotalOverlap / (iSheets - 1) '隣接部分の重複ピクセル数
                    WriteLstResult(Me.lstResult, "隣接部分の重複ピクセル数：" & iRelated)
                    iRelatedRemainder = iTotalOverlap Mod (iSheets - 1)  '重複ピクセル数の余り
                    WriteLstResult(Me.lstResult, "重複ピクセル数の余り：" & iRelatedRemainder)
                    'iRelatedが800未満の場合は、A2画像を1枚足して再計算
                    If iRelated < 800 Then
                        WriteLstResult(Me.lstResult, "隣接部分の重複ピクセル数が800ピクセル未満のため再計算します")
                        sw.WriteLine("隣接部分の重複ピクセル数が800ピクセル未満のため再計算：" & iRelated)
                        iSheets += 1
                        WriteLstResult(Me.lstResult, "縦方向必要枚数：" & iSheets)
                        '6.重複部分の算出
                        iTotalOverlap = (iCropY * iSheets) - iHeight  '重複部分の総ピクセル数
                        WriteLstResult(Me.lstResult, "重複部分の総ピクセル数：" & iTotalOverlap)
                        iRelated = iTotalOverlap / (iSheets - 1) '隣接部分の重複ピクセル数
                        WriteLstResult(Me.lstResult, "隣接部分の重複ピクセル数：" & iRelated)
                        iRelatedRemainder = iTotalOverlap Mod (iSheets - 1)  '重複ピクセル数の余り
                        WriteLstResult(Me.lstResult, "重複ピクセル数の余り：" & iRelatedRemainder)
                    End If

                    sw.WriteLine("==================================================")
                    sw.WriteLine("縦方向必要枚数：" & iSheets)
                    sw.WriteLine("重複部分の総ピクセル数：" & iTotalOverlap)
                    sw.WriteLine("隣接部分の重複ピクセル数：" & iRelated)
                    sw.WriteLine("重複ピクセル数の余り：" & iRelatedRemainder)

                    '7.各「A2画像」の起点を重複部分を考慮して算出
                    iStartPoint = 0
                    For iSheet As Integer = 1 To iSheets
                        If iSheet = 1 Then
                            '1回目は起点0が確定
                            listHeight.Add(iStartPoint)
                            Continue For
                        ElseIf iSheet = 2 Then
                            '2回目の起点から重複ピクセルの余りを減算する
                            iStartPoint = (iStartPoint + iCropY) - iRelated - iRelatedRemainder
                            listHeight.Add(iStartPoint)
                        Else
                            '3回目以降
                            iStartPoint = (iStartPoint + iCropY) - iRelated
                            listHeight.Add(iStartPoint)
                        End If
                    Next
                    '4.それぞれの「A2画像」に対応する起点のx軸が確定する
                    For i As Integer = 0 To listHeight.Count - 1
                        WriteLstResult(Me.lstResult, i + 1 & "枚目の起点Y：" & listHeight(i))
                        sw.WriteLine("縦方向" & i + 1 & "枚目の起点：" & listHeight(i))
                    Next

                    WriteLstResult(Me.lstResult, "==================================================")
                    WriteLstResult(Me.lstResult, "切り出し処理")

                    sw.WriteLine("==================================================")
                    sw.WriteLine("画像分割情報")
                    sw.WriteLine("※画像ファイル名：(起点X, 起点Y, 幅, 高さ)")
                    '縦方向、横方向の順でループ
                    For iRow As Integer = 0 To listHeight.Count - 1
                        '縦ループ

                        For iCol As Integer = 0 To listWidth.Count - 1
                            '横ループ
                            Dim strNumber As String = (iRow + 1).ToString("00") & "-" & (iCol + 1).ToString("00")
                            WriteLstResult(Me.lstResult, "画像：" & strNumber & "の切り出し(" & listWidth(iCol) & ", " & listHeight(iRow) & ", " & iCropX & ", " & iCropY & ")")
                            sw.WriteLine(System.IO.Path.GetFileNameWithoutExtension(strFile) & strNumber & System.IO.Path.GetExtension(strFile) & "：(" & listWidth(iCol) & ", " & listHeight(iRow) & ", " & iCropX & ", " & iCropY & ")")
                            img = New MagickImage(strFile)
                            img.Crop(listWidth(iCol), listHeight(iRow), iCropX, iCropY)

                            Dim strOutFile As String = System.IO.Path.GetDirectoryName(strFile.Replace(strTargetFolder, strSaveFolder)) & "\" & System.IO.Path.GetFileNameWithoutExtension(strFile) & strNumber & System.IO.Path.GetExtension(strFile)
                            If Not System.IO.Directory.Exists(System.IO.Directory.Exists(strOutFile)) Then
                                My.Computer.FileSystem.CreateDirectory(System.IO.Path.GetDirectoryName(strOutFile))
                            End If

                            img.Write(strOutFile)
                            img.Dispose()

                        Next
                    Next
                    WriteLstResult(Me.lstResult, "画像分割処理完了：" & System.IO.Path.GetFileName(strFile))
                    WriteLstResult(Me.lstResult, "==================================================")
                    sw.WriteLine("画像分割完了")
                    sw.WriteLine("==================================================")
                    sw.WriteLine("処理終了：" & Date.Now.ToString("yyyy/MM/dd HH:mm:ss"))

                End Using

                Me.ProgressBar1.Value += 1
                Me.lblProgress.Text = Me.ProgressBar1.Value & " / " & Me.ProgressBar1.Maximum
                Application.DoEvents()

            Next

            MessageBox.Show("画像分割処理が完了しました", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information)
            OutputImportLog(Me.lstResult, strSaveFolder, "処理ログ")
            Me.ProgressBar1.Value = 0
            Me.lblProgress.Text = "0 / 0"

        Catch ex As Exception

            Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message)
            MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub

    Private Sub txt_DragEnter(sender As Object, e As DragEventArgs) Handles txtTargetFolder.DragEnter, txtSaveFolder.DragEnter

        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub txt_DragDrop(sender As Object, e As DragEventArgs) Handles txtTargetFolder.DragDrop, txtSaveFolder.DragDrop

        Dim txtText As TextBox = CType(sender, TextBox)
        Dim strFileName As String() = CType(e.Data.GetData(DataFormats.FileDrop, False), String())
        Dim strFolderName As String = ""
        If System.IO.Directory.Exists(strFileName(0)) Then
            txtText.Text = strFileName(0)
        Else
            txtText.Text = System.IO.Path.GetDirectoryName(strFileName(0))
        End If

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.cmbExt.SelectedIndex = 0
        Me.lblProgress.Text = "0 / 0"

    End Sub

    Private Sub btnTargetBrowse_Click(sender As Object, e As EventArgs) Handles btnTargetBrowse.Click

        Me.txtTargetFolder.Text = FolderBrowse(Me.txtTargetFolder)

    End Sub

    Private Sub btnSaveBrowse_Click(sender As Object, e As EventArgs) Handles btnSaveBrowse.Click

        Me.txtSaveFolder.Text = FolderBrowse(Me.txtSaveFolder)

    End Sub
End Class
