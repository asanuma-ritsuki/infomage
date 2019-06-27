Imports System
Imports System.IO
Imports OpenCvSharp

Module BCReadProcess
    ''' <summary>
    ''' BC読み取り
    ''' </summary>
    ''' <param name="stImagePath">検出画像フルパス</param>
    ''' <returns>読み取ったBC値</returns>
    ''' <remarks></remarks>
    Public Function ZbarReadBC(ByVal stImagePath As String) As String()
        'バーコード情報を取得するバッチを作成、実行する。
        Dim BC As String = ""
        Dim barcodeResult As String()
        ReDim barcodeResult(1)
        barcodeResult(0) = ""
        barcodeResult(1) = ""
        Dim p As New System.Diagnostics.Process()
        Try
            'ComSpec(cmd.exe)のパスを取得して、FileNameプロパティに指定
            p.StartInfo.FileName = System.Environment.GetEnvironmentVariable("ComSpec")
            '出力を読み取れるようにする
            p.StartInfo.UseShellExecute = False
            p.StartInfo.RedirectStandardOutput = True
            p.StartInfo.RedirectStandardInput = False
            p.StartInfo.RedirectStandardError = False
            'ウィンドウを表示しないようにする
            p.StartInfo.CreateNoWindow = True
            'コマンド設定

            p.StartInfo.Arguments = "/c " & Chr(34) & Application.StartupPath & "\Dll\Zbar\zbarimg.exe" & Chr(34) & " " & stImagePath

            'p.StartInfo.Arguments = "/c " & Chr(34) & Application.StartupPath & "\Zbar\zbarimg.exe" & Chr(34) & " " & stImagePath
            '実行
            p.Start()
            BC = p.StandardOutput.ReadToEnd()
            BC = BC.Replace(vbCrLf, "")
            Dim splBC As String() = BC.Split(":")

            If splBC.Count = 2 Then
                barcodeResult(0) = splBC(1)
                barcodeResult(1) = splBC(0)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "zbarエラー", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            'Processオブジェクトを終了
            p.WaitForExit()
            p.Close()
        End Try
        Return barcodeResult

    End Function

    ''' <summary>
    ''' 変換画像ロード
    ''' </summary>
    ''' <param name="ImagePath"></param>
    ''' <returns></returns>
    Private Function ConvertLoad(ByVal ImagePath As String) As ImageMagick.MagickImage
        '変換設定
        Dim imgMagick As New ImageMagick.MagickImage
        Dim imgSetting As New ImageMagick.MagickReadSettings

        imgSetting.UseMonochrome = True
        imgMagick.Read(ImagePath, imgSetting)
        imgMagick.Threshold(50)
        imgMagick.Depth = 1
        imgMagick.Threshold(New ImageMagick.Percentage(50.0))
        imgMagick.CompressionMethod = ImageMagick.CompressionMethod.Group4

        Return imgMagick
    End Function

    ''' <summary>
    ''' バーコード読み取り
    ''' </summary>
    ''' <param name="imgPath"></param>
    ''' <param name="BarcodeType"></param>
    ''' <returns></returns>
    Public Function BarcodeRead(ByVal imgPath As String, Optional ByVal BarcodeType As ZXing.BarcodeFormat = 0, Optional ByVal AutoRotate As Boolean = False, Optional ByVal BinConvert As Boolean = False) As String()

        Dim barcodeResult As String()
        ReDim barcodeResult(1)
        barcodeResult(0) = ""
        barcodeResult(1) = ""

        Dim imgMagick As New ImageMagick.MagickImage
        Dim Temp_img As String = Application.StartupPath & "\BCRead_Temp\temp.tif"

        If BinConvert = True Then
            If System.IO.File.Exists(Temp_img) Then
                System.IO.File.Delete(Temp_img)
            End If

            imgMagick = ConvertLoad(imgPath)
            imgMagick.Write(Temp_img)
            imgMagick.Dispose()

            imgPath = Temp_img
        End If

        '2値変換
        'Dim Temp_img As String = Application.StartupPath & "\BCRead_Temp\temp.tif"

        'Dim srcImg = Cv2.ImRead(imgPath, ImreadModes.GrayScale)
        'Dim binImg = srcImg.Clone
        'Cv2.Threshold(srcImg, binImg, 0, 255, ThresholdTypes.Binary)
        'Cv2.ImWrite(Temp_img, binImg)

        Dim img As Image = System.Drawing.Image.FromFile(imgPath)

        Dim barcodeReader As New ZXing.BarcodeReader
        barcodeReader.AutoRotate = AutoRotate
        barcodeReader.TryInverted = True
        barcodeReader.Options.TryHarder = True

        If BarcodeType > 0 Then
            Dim BarcodeList As New List(Of ZXing.BarcodeFormat)
            BarcodeList.Add(BarcodeType)
            barcodeReader.Options = New ZXing.Common.DecodingOptions With {.PossibleFormats = BarcodeList}
        End If



        Dim ZxingResult As ZXing.Result = Nothing
        ZxingResult = barcodeReader.Decode(img)
        img.Dispose()

        If Not IsNothing(ZxingResult) Then
            barcodeResult(0) = ZxingResult.Text
            barcodeResult(1) = ZxingResult.BarcodeFormat
        End If
        'If barcodeResult(0) = "" Then
        '    'Zbar方式
        '    If Not System.IO.Directory.Exists(Application.StartupPath & "\BCRead_Temp") Then
        '        System.IO.Directory.CreateDirectory(Application.StartupPath & "\BCRead_Temp")
        '    End If
        '    Dim Zbar As String() = BCReadProcess.ZbarReadBC(imgPath)
        '    barcodeResult(0) = Zbar(0)
        '    barcodeResult(1) = Zbar(1)
        'End If

        If Not barcodeResult(0) = "" Then
            If IsNumeric(barcodeResult(1)) = True Then
                barcodeResult(1) = GetBCType(Math.Log(CDbl(barcodeResult(1)), 2))
            End If
            barcodeResult(0) = barcodeResult(0).ToString.Replace(vbNewLine, "")
        End If

        Return barcodeResult
    End Function

    ''' <summary>
    ''' BCタイプ
    ''' </summary>
    ''' <returns></returns>
    Public Function GetBCType() As String()
        Return {
            "AZTEC",
            "CODABAR",
            "CODE_39",
            "CODE_93",
            "CODE_128",
            "DATA_MATRIX",
            "EAN_8",
            "EAN_13",
            "ITF",
            "MAXICODE",
            "PDF_417",
            "QR_CODE",
            "RSS_14",
            "RSS_EXPANDED",
            "UPC_A",
            "UPC_E",
            "All_1D",
            "UPC_EAN_EXTENSION",
            "MSI",
            "PLESSEY",
            "IMB"
        }
    End Function

End Module
