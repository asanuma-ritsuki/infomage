Public Class frmOCR
#Region "フォームイベント"
    ''' <summary>
    ''' フォームロード
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub frmOCR_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.fgrFileList.Rows.Count = 1
    End Sub
#End Region
#Region "ボタンイベント"
    ''' <summary>
    ''' OCR実行
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnRun_Click(sender As Object, e As EventArgs) Handles btnRun.Click
        'エラーファイル数
        Dim ErrorCount As Integer = 0
        'OCR処理
        'Initialize an instance of OcrEngine 
        Dim OcrEngine As New Aspose.OCR.OcrEngine

        'OCR言語
        '自動回転
        OcrEngine.Config.AdjustRotation = False
        '読取順序操作
        OcrEngine.Config.DetectReadingOrder = False
        'スペルチェック
        OcrEngine.Config.DoSpellingCorrection = False
        '背景均一化
        OcrEngine.Config.ProcessColoredBackground = False
        '通知をクリア
        OcrEngine.ClearNotifies()
        '認識範囲
        OcrEngine.Config.ClearRecognitionBlocks()

        OcrEngine.Config.Whitelist = {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"}

        OcrEngine.Config.AddRecognitionBlock(Aspose.OCR.RecognitionBlock.CreateTextBlock(1890, 2830, 470, 75))
        'Dim Block1 As Aspose.OCR.IRecognitionBlock = Aspose.OCR.RecognitionBlock.CreateTextBlock(1890, 2830, 100, 75)
        'Block1.Whitelist = {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9"}
        'Dim Block2 As Aspose.OCR.IRecognitionBlock = Aspose.OCR.RecognitionBlock.CreateTextBlock(1985, 2830, 50, 75)
        'Block2.Whitelist = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"}
        'Dim Block3 As Aspose.OCR.IRecognitionBlock = Aspose.OCR.RecognitionBlock.CreateTextBlock(2030, 2830, 260, 75)
        'Block3.Whitelist = {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9"}
        'Dim Block4 As Aspose.OCR.IRecognitionBlock = Aspose.OCR.RecognitionBlock.CreateTextBlock(2285, 2830, 50, 75)
        'Block4.Whitelist = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"}
        'OcrEngine.Config.AddRecognitionBlock(Block1)
        'OcrEngine.Config.AddRecognitionBlock(Block2)
        'OcrEngine.Config.AddRecognitionBlock(Block3)
        'OcrEngine.Config.AddRecognitionBlock(Block4)
        'テキスト領域の自動検出
        OcrEngine.Config.DetectTextRegions = False

        For iRow As Integer = 1 To Me.fgrFileList.Rows.Count - 1
            'ファイルパス
            Dim FilePath As String = Me.lblLoadFolderName.Text & "\" & Me.fgrFileList.Rows(iRow)("ファイルパス")

            Try
                '画像読み込み
                OcrEngine.Image = Aspose.OCR.ImageStream.FromFile(FilePath)

                'Process the image 
                If OcrEngine.Process() Then
                    'Me.fgrFileList.Rows(iRow)("OCR結果") = OcrEngine.Text.ToString()
                    Dim blocks = OcrEngine.Config.RecognitionBlocks
                    Dim OCRText As String = ""
                    Dim BlockNum As Integer = 0
                    For Each block In blocks
                        'Check if block has recognition data
                        If block.RecognitionData Is Nothing Then
                            Continue For
                        End If
                        If TypeOf block.RecognitionData Is Aspose.OCR.IRecognizedTextPartInfo Then
                            'Display the recognition results
                            Dim textPartInfo As Aspose.OCR.IRecognizedTextPartInfo = CType(block.RecognitionData, Aspose.OCR.IRecognizedTextPartInfo)
                            'Select Case BlockNum
                            '    Case "0"
                            '        block.Whitelist = {"1", "2", "3", "4", "5", "6", "7", "8", "9"}
                            '    Case "1"
                            '        block.Whitelist = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"}
                            '    Case "2"
                            '        block.Whitelist = {"1", "2", "3", "4", "5", "6", "7", "8", "9"}
                            '    Case "3"
                            '        block.Whitelist = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"}
                            'End Select
                            OCRText &= textPartInfo.Text
                            BlockNum += 1
                        End If
                    Next block
                    Me.fgrFileList.Rows(iRow)("OCR結果") = OCRText
                    Me.fgrFileList.Rows(iRow)("進捗") = "OK"
                    Me.fgrFileList.Rows(iRow)("完了時刻") = System.DateTime.Now
                    System.Windows.Forms.Application.DoEvents()
                Else
                    Me.fgrFileList.Rows(iRow)("進捗") = "NG"
                    Me.fgrFileList.Rows(iRow)("完了時刻") = System.DateTime.Now
                    System.Windows.Forms.Application.DoEvents()
                End If


            Catch ex As Exception
                ErrorCount += 1
            End Try
        Next

        Me.txtErrorCount.Text = ErrorCount
    End Sub

    ''' <summary>
    ''' メニューに戻る
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnBackMenu_Click(sender As Object, e As EventArgs) Handles btnBackMenu.Click
        Dim f As New frmMenu
        f.Show()
        Me.Close()
    End Sub
#End Region

End Class