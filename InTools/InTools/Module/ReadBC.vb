Imports System
Imports System.IO
Imports OpenCvSharp

Module BCReadProcess
    ''' <summary>
    ''' BC�ǂݎ��
    ''' </summary>
    ''' <param name="stImagePath">���o�摜�t���p�X</param>
    ''' <returns>�ǂݎ����BC�l</returns>
    ''' <remarks></remarks>
    Public Function ZbarReadBC(ByVal stImagePath As String) As String()
        '�o�[�R�[�h�����擾����o�b�`���쐬�A���s����B
        Dim BC As String = ""
        Dim barcodeResult As String()
        ReDim barcodeResult(1)
        barcodeResult(0) = ""
        barcodeResult(1) = ""
        Dim p As New System.Diagnostics.Process()
        Try
            'ComSpec(cmd.exe)�̃p�X���擾���āAFileName�v���p�e�B�Ɏw��
            p.StartInfo.FileName = System.Environment.GetEnvironmentVariable("ComSpec")
            '�o�͂�ǂݎ���悤�ɂ���
            p.StartInfo.UseShellExecute = False
            p.StartInfo.RedirectStandardOutput = True
            p.StartInfo.RedirectStandardInput = False
            p.StartInfo.RedirectStandardError = False
            '�E�B���h�E��\�����Ȃ��悤�ɂ���
            p.StartInfo.CreateNoWindow = True
            '�R�}���h�ݒ�

            p.StartInfo.Arguments = "/c " & Chr(34) & Application.StartupPath & "\Dll\Zbar\zbarimg.exe" & Chr(34) & " " & stImagePath

            'p.StartInfo.Arguments = "/c " & Chr(34) & Application.StartupPath & "\Zbar\zbarimg.exe" & Chr(34) & " " & stImagePath
            '���s
            p.Start()
            BC = p.StandardOutput.ReadToEnd()
            BC = BC.Replace(vbCrLf, "")
            Dim splBC As String() = BC.Split(":")

            If splBC.Count = 2 Then
                barcodeResult(0) = splBC(1)
                barcodeResult(1) = splBC(0)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "zbar�G���[", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            'Process�I�u�W�F�N�g���I��
            p.WaitForExit()
            p.Close()
        End Try
        Return barcodeResult

    End Function

    ''' <summary>
    ''' �ϊ��摜���[�h
    ''' </summary>
    ''' <param name="ImagePath"></param>
    ''' <returns></returns>
    Private Function ConvertLoad(ByVal ImagePath As String) As ImageMagick.MagickImage
        '�ϊ��ݒ�
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
    ''' �o�[�R�[�h�ǂݎ��
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

        '2�l�ϊ�
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
        '    'Zbar����
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
    ''' BC�^�C�v
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
