'OpenCVSharpをインポート
Imports OpenCvSharp
'Imports OpenCvSharp.Extensions

Public Class frmMain
#Region "プライベート変数"
    'キャンセルボタンがクリックされたかを示すフラグ
    Private canceled As Boolean = False
    '実行中かを示すフラグ
    Private Doing As Boolean = False
    '入力チャート画像パス
    Private strInputFilePath As String = ""
    'カラーチャート読込
    Private src_img As New IplImage
    'カラーチャート解像度
    Private Resolution As Integer = 0
    '解像度から縮率計算
    Private Reduction As Double = 1
    '読込フラグ
    Private LoadFlag As Boolean = False

    Private Enum Lab
        L
        a
        b
    End Enum

#End Region
#Region "フォームイベント"
    ''' <summary>
    ''' ロード時
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub frmMain_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'フォーム名
        Me.Text = My.Application.Info.ProductName.ToString & " Ver." & My.Application.Info.Version.ToString

        'ピクチャーボックスの表示形式を中央揃えにする。
        PictureBoxIpl1.SizeMode = PictureBoxSizeMode.CenterImage
        PictureBoxIpl1.AllowDrop = True
        'キャンセルを無効にする
        btnCancel.Enabled = False
        '出力フォルダのデフォルトをデスクトップにする。
        Me.txtOutputFolder.Text = System.Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)
        Me.txtDEab.Text = "-"
        Me.txtDE00.Text = "-"
        'ラジオボタン初期選択
        Me.rbChartCL.Checked = True
        Me.rbsRGB.Checked = True

        'fgr
        Me.fgrResult.Rows.Count = 1

    End Sub
    ''' <summary>
    ''' 終了時
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub frmMain_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If MessageBox.Show("終了します。" & vbNewLine & "よろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
            e.Cancel = True
        End If
    End Sub

    ''' <summary>
    ''' サイズ変更時
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub frmMain_SizeChanged(sender As Object, e As EventArgs) Handles MyBase.SizeChanged
        If LoadFlag = True Then
            PreviewImage(src_img)
            Me.PictureBoxIpl1.SizeMode = PictureBoxSizeMode.Zoom
        End If
    End Sub
#End Region

#Region "オブジェクトイベント"
    ''' <summary>
    ''' ピクチャーボックスドラッグ時
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TIFF_DragEnter(sender As System.Object, e As System.Windows.Forms.DragEventArgs) Handles PictureBoxIpl1.DragEnter
        'コントロール内にドロップされた時実行される
        Dim strFile As String() = CType(e.Data.GetData(DataFormats.FileDrop, False), String())

        If System.IO.File.Exists(strFile(0)) And (System.IO.Path.GetExtension(strFile(0)).ToLower() = ".tif" Or System.IO.Path.GetExtension(strFile(0)).ToLower() = ".tiff" Or System.IO.Path.GetExtension(strFile(0)).ToLower() = ".jp2") Then
            'ドラッグされたデータ形式を調べ、ファイル・フォルダの時はコピーとする
            e.Effect = DragDropEffects.Copy
        Else
            'ファイル以外は受け付けない
            e.Effect = DragDropEffects.None
        End If
    End Sub
    ''' <summary>
    ''' ピクチャーボックスドロップ時
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TIFF_DragDrop(sender As System.Object, e As System.Windows.Forms.DragEventArgs) Handles PictureBoxIpl1.DragDrop
        'コントロール内にドロップされた時実行される
        Dim strFile As String() = CType(e.Data.GetData(DataFormats.FileDrop, False), String())
        '取得した文字列のフォルダが存在するか確認する
        If System.IO.File.Exists(strFile(0)) And (System.IO.Path.GetExtension(strFile(0)).ToLower() = ".tif" Or System.IO.Path.GetExtension(strFile(0)).ToLower() = ".tiff" Or System.IO.Path.GetExtension(strFile(0)).ToLower() = ".jp2") Then
            'フォルダが存在していたらテキストボックスに値を表示させる
            strInputFilePath = strFile(0)
            'カラーチャート読込
            src_img = Cv.LoadImage(strInputFilePath)
            '画像表示
            Try
                PreviewImage(src_img)
                Me.PictureBoxIpl1.SizeMode = PictureBoxSizeMode.Zoom
                LoadFlag = True
            Catch ex As Exception
                MessageBox.Show(ex.Message, "読込エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        Else
            'ファイルが存在しなかったら何もしない
            MessageBox.Show("ドロップされたオブジェクトはTIFFファイルではありません")
        End If
    End Sub

    ''' <summary>
    ''' 出力参照ボタン押下時
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnOutputBrowse_Click(sender As System.Object, e As System.EventArgs) Handles btnOutputBrowse.Click
        'FolderBrowserDialogクラスのインスタンスを作成
        Dim fbd As New FolderBrowserDialog
        fbd.Description = "フォルダを指定してください。"
        fbd.RootFolder = Environment.SpecialFolder.Desktop
        fbd.ShowNewFolderButton = True

        If fbd.ShowDialog(Me) = DialogResult.OK Then
            Me.txtOutputFolder.Text = fbd.SelectedPath
        End If
    End Sub

    ''' <summary>
    ''' 出力フォルダドラッグ時
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub OutputFolder_DragEnter(sender As System.Object, e As System.Windows.Forms.DragEventArgs) Handles txtOutputFolder.DragEnter
        'コントロール内にドロップされた時実行される
        Dim strFile As String() = CType(e.Data.GetData(DataFormats.FileDrop, False), String())

        If System.IO.Directory.Exists(strFile(0)) Then
            'ドラッグされたデータ形式を調べ、フォルダの時はコピーとする
            e.Effect = DragDropEffects.Copy
        Else
            'ファイル以外は受け付けない
            e.Effect = DragDropEffects.None
        End If
    End Sub
    ''' <summary>
    ''' 出力フォルダドロップ時
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub OutputFolder_DragDrop(sender As System.Object, e As System.Windows.Forms.DragEventArgs) Handles txtOutputFolder.DragDrop
        'コントロール内にドロップされた時実行される
        Dim strFile As String() = CType(e.Data.GetData(DataFormats.FileDrop, False), String())
        'フォルダが存在するか確認する
        If System.IO.Directory.Exists(strFile(0)) Then
            'フォルダが存在していたらテキストボックスに値を表示させる
            Me.txtOutputFolder.Text = strFile(0)
        Else
            'フォルダが存在しなかったら何もしない
            MessageBox.Show("ドロップされたオブジェクトはフォルダではありません")
        End If
    End Sub

    ''' <summary>
    ''' スタートボタン押下時
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnStart_Click(sender As System.Object, e As System.EventArgs) Handles btnStart.Click
        If MessageBox.Show("読み取りを開始します。" & vbNewLine & "よろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
            ChangeState(False)
            Exit Sub
        End If
        If Not System.IO.File.Exists(strInputFilePath) Then
            If MessageBox.Show("読込カラーチャートが存在しません。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.OK Then
                ChangeState(False)
                Exit Sub
            End If
        End If
        If txtOutputFolder.Text = "" Then
            If MessageBox.Show("出力フォルダパスが無効です。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.OK Then
                ChangeState(False)
                Exit Sub
            End If
        Else
            If Not System.IO.Directory.Exists(txtOutputFolder.Text) Then
                If MessageBox.Show("出力フォルダパスが無効です。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.OK Then
                    ChangeState(False)
                    Exit Sub
                End If
            End If
        End If

        'fgrをクリア
        Me.fgrResult.Rows.Count = 1
        '平均色差の値をクリア
        Me.txtDEab.Text = "-"
        Me.txtDE00.Text = "-"
        ChangeState(True)
        'ステータス変更
        Me.tsStatusLabel.Text = "処理開始"
        '待機中のイベントを処理する
        Application.DoEvents()

        '解像度取得
        Dim bmpOrg As Bitmap = Bitmap.FromFile(strInputFilePath)
        Resolution = bmpOrg.HorizontalResolution
        Reduction = 400 / Resolution

        '頂点検出
        Dim arCrossPoint As New ArrayList '十字の座標
        src_img = Cv.LoadImage(strInputFilePath) 'カラーチャート読込
        '塗りつぶし用
        Dim src_img2 As IplImage = Cv.LoadImage(strInputFilePath)
        Dim min_val As Double = 0
        Dim max_val As Double = 0
        Dim min_loc As CvPoint
        Dim max_loc As CvPoint
        Dim TmpPath As String = Application.StartupPath & "\TempImage\"
        If Me.rbChartIT8.Checked = True Then
            TmpPath &= "Lshaped.tif"
        ElseIf Me.rbChartIT8Trans.Checked = True Then
            '2018/12/17
            TmpPath &= "Lshaped2.tif"
        Else
            TmpPath &= "cross.tif"
        End If
        'テンプレート読込
        Dim tmp_img As IplImage = Cv.LoadImage(TmpPath)
        'テンプレートサイズを読み込んだチャートの解像度に合わせる
        Dim tmp_img2 As IplImage = Cv.CreateImage(Cv.Size(tmp_img.Width / Reduction, tmp_img.Height / Reduction), tmp_img.Depth, tmp_img.ElemChannels)

        Cv.Resize(tmp_img, tmp_img2, Interpolation.Lanczos4)
        Cv.ReleaseImage(tmp_img)

        '画像表示チェック用
        'Cv.NamedWindow("Image", WindowMode.AutoSize)
        'Cv.ShowImage("Image", tmp_img2)
        'Cv.WaitKey(0)
        'Cv.DestroyWindow("Image")

        Dim tmpRadius As Integer = tmp_img2.Width / 2

        '試行回数10回
        For i As Integer = 1 To 10
            Me.tsStatusLabel.Text = "マークを検出しています..."

            'テンプレートマッチ
            Dim dst_img As IplImage = TemprateMatch(src_img2, tmp_img2)
            'PreviewImage(dst_img)
            Cv.MinMaxLoc(dst_img, min_val, max_val, min_loc, max_loc)

            Dim ExistMatch As Boolean = False

            '2つめ以降のマッチングの場合
            If arCrossPoint.Count > 0 Then
                For Each CrossPoint As String In arCrossPoint
                    Dim splCrossPoint As String() = CrossPoint.Split(",")
                    Dim CrossPointX As Integer = CInt(splCrossPoint(0))
                    Dim CrossPointY As Integer = CInt(splCrossPoint(1))
                    '既存のマッチポイントの周囲（元画像の半径以内）の場合はスルーさせる。
                    If CrossPointX - (src_img2.Width / 2) < max_loc.X And CrossPointX + (src_img2.Width / 2) > max_loc.X Then
                        If CrossPointY - (src_img2.Height / 2) < max_loc.Y And CrossPointY + (src_img2.Height / 2) > max_loc.Y Then
                            ExistMatch = True
                            Exit For
                        End If
                    End If
                Next
            End If

            If ExistMatch = False Then
                Dim tmpW As Integer = tmp_img2.Width
                Dim tmpH As Integer = tmp_img2.Height

                arCrossPoint.Add(max_loc.X & "," & max_loc.Y)
                '塗りつぶし
                Cv.Rectangle(src_img2, max_loc, Cv.Point(max_loc.X + tmpW, max_loc.Y + tmpH), Cv.RGB(255, 0, 0), Cv.FILLED)
                '表示用
                Cv.Rectangle(src_img, max_loc, Cv.Point(max_loc.X + tmpW, max_loc.Y + tmpH), Cv.RGB(255, 0, 0), 3)
                PreviewImage(src_img)
                Cv.ReleaseImage(dst_img)

                'IT8チャートの場合テンプレート画像を90度回転させる
                If Me.rbChartIT8.Checked = True Or Me.rbChartIT8Trans.Checked = True Then
                    Dim center As CvPoint = Cv.Point((tmp_img2.Width / 2), (tmp_img2.Height / 2))
                    Dim affine As CvMat = Cv.GetRotationMatrix2D(center, 90.0, 1.0)
                    Cv.WarpAffine(tmp_img2, tmp_img2, affine)
                End If
            End If

            If arCrossPoint.Count = 4 Then
                Exit For
            End If

            'キャンセルボタンがクリックされたか調べる
            If canceled Then
                'キャンセルされた時
                MessageBox.Show("処理を中止しました。")
                'ステータス変更
                Me.tsStatusLabel.Text = "処理を中止しました。"
                ChangeState(False)
                Exit Sub
            End If
        Next

        '4つ見つからなかった場合終了する
        If arCrossPoint.Count < 4 Then
            MessageBox.Show("頂点を検出することができませんでした。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'ステータス変更
            Me.tsStatusLabel.Text = "処理を中止しました。"
            ChangeState(False)
            Exit Sub
        End If

        Cv.ReleaseImage(tmp_img2)

        '取得した座標(中心点)
        Dim pntA As CvPoint
        Dim pntB As CvPoint
        Dim pntC As CvPoint
        Dim pntD As CvPoint

        '読み込んだ画像の縦横のピクセルを取得
        Dim src_img_height As Integer = src_img.Height
        Dim src_img_width As Integer = src_img.Width

        For Each Point As String In arCrossPoint
            Dim splPoint As String() = Point.Split(",")
            Dim pntX As Integer = CInt(splPoint(0)) + tmpRadius
            Dim pntY As Integer = CInt(splPoint(1)) + tmpRadius
            If src_img_width / 2 > pntX And src_img_height / 2 > pntY Then
                pntA = Cv.Point(pntX, pntY)
            ElseIf src_img_width / 2 < pntX And src_img_height / 2 > pntY Then
                pntB = Cv.Point(pntX, pntY)
            ElseIf src_img_width / 2 > pntX And src_img_height / 2 < pntY Then
                pntC = Cv.Point(pntX, pntY)
            ElseIf src_img_width / 2 < pntX And src_img_height / 2 < pntY Then
                pntD = Cv.Point(pntX, pntY)
            Else
                MessageBox.Show("頂点が正しく検出できませんでした。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
                'ステータス変更
                Me.tsStatusLabel.Text = "処理を中止しました。"
                ChangeState(False)
                Exit Sub
            End If
        Next

        '取得した四つ角からパッチ座標を求める
        Dim difAB As Integer = pntB.X - pntA.X  '検出ポイントの横間隔
        Dim difAC As Integer = pntC.Y - pntA.Y  '検出ポイントの縦間隔
        Dim PatchSide As Integer = 0 'パッチの辺の長さ
        Dim Margin As Integer = 0
        Dim cReader As System.IO.StreamReader '基準値テキストを読み込む

        Dim arYList As New ArrayList  'Y座標リスト
        Dim arXList As New ArrayList  'X座標リスト

        If Me.rbChartCL.Checked = True Then
            'クラシックチャート
            Dim MarginInit As Integer = difAB * 0.002  '検出ポイントからパッチまでのマージン
            Dim difAB_M As Integer = difAB - (MarginInit * 2) 'マージンを引いた横間隔
            Dim difAC_M As Integer = difAC - (MarginInit * 2) 'マージンを引いた縦間隔
            Dim detX As Integer = pntA.X + MarginInit
            Dim detY As Integer = pntA.Y + MarginInit
            cReader = New System.IO.StreamReader(Application.StartupPath & "\reference_value\CL.txt", System.Text.Encoding.Default)
            PatchSide = difAB * 0.147
            For numX As Integer = 1 To 6
                detX += (difAB_M / 6)
                arXList.Add((detX - (difAB_M / 12)))
            Next
            For numY As Integer = 1 To 4
                detY += (difAC_M / 4)
                arYList.Add((detY - (difAC_M / 8)))
            Next

        ElseIf Me.rbChartSG.Checked = True Then
            'SGチャート
            Dim MarginInitX As Integer = difAB * 0.0055  '検出ポイントからパッチまでのマージン
            Dim MarginInitY As Integer = difAB * 0.005
            Dim difAB_M As Integer = difAB - (MarginInitX * 2) 'マージンを引いた横間隔
            Dim difAC_M As Integer = difAC - (MarginInitY * 2) 'マージンを引いた縦間隔
            Dim detX As Integer = pntA.X + (difAB * 0.003)
            Dim detY As Integer = pntA.Y + MarginInitY
            cReader = New System.IO.StreamReader(Application.StartupPath & "\reference_value\SG.txt", System.Text.Encoding.Default)
            PatchSide = difAB * 0.055
            Margin = difAB * 0.017
            difAB_M += Margin
            difAC_M += Margin
            detX -= Margin / 2
            detY -= Margin / 2

            For numX As Integer = 1 To 14
                detX += (difAB_M / 14)
                arXList.Add((detX - (difAB_M / 28)))
            Next
            For numY As Integer = 1 To 10
                detY += (difAC_M / 10)
                arYList.Add((detY - (difAC_M / 20)))
            Next
        ElseIf Me.rbChartIT8.Checked = True Then
            'IT8チャート
            Dim MarginInit As Integer = difAB * 0.03  '検出ポイントからパッチまでのマージン
            Dim difAB_M As Integer = difAB - (MarginInit * 2) 'マージンを引いた横間隔
            Dim difAC_M As Integer = difAC - (MarginInit * 2) 'マージンを引いた縦間隔
            Dim detX As Integer = pntA.X + MarginInit
            Dim detY As Integer = pntA.Y + MarginInit
            cReader = New System.IO.StreamReader(Application.StartupPath & "\reference_value\IT8_20140801.txt", System.Text.Encoding.Default)
            PatchSide = difAB * 0.043
            Margin = 0
            difAB_M += Margin
            difAC_M += Margin
            detX -= Margin / 2
            detY -= Margin / 2

            '01-22
            For numX As Integer = 1 To 22
                detX += (difAB_M / 22)
                arXList.Add((detX - (difAB_M / 44)))
            Next
            'A-L
            For numY As Integer = 1 To 12
                detY += (difAC_M / 12)
                arYList.Add((detY - (difAC_M / 24)))
            Next
            'Gray01-24
            detY += (difAC_M / 5)
            arYList.Add((detY - (difAC_M / 24)))

        Else
            '2018/12/17
            'IT8(透過)チャート
            Dim MarginInit As Integer = difAB * 0.03  '検出ポイントからパッチまでのマージン
            Dim difAB_M As Integer = difAB - (MarginInit * 2) 'マージンを引いた横間隔
            Dim difAC_M As Integer = difAC - (MarginInit * 2) 'マージンを引いた縦間隔
            Dim detX As Integer = pntA.X + MarginInit
            Dim detY As Integer = pntA.Y + MarginInit
            cReader = New System.IO.StreamReader(Application.StartupPath & "\reference_value\MONT45.2016.05.txt", System.Text.Encoding.Default)
            PatchSide = difAB * 0.043
            Margin = 0
            difAB_M += Margin
            difAC_M += Margin
            detX -= Margin / 2
            detY -= Margin / 2

            '01-22
            For numX As Integer = 1 To 22
                detX += (difAB_M / 22)
                arXList.Add((detX - (difAB_M / 44)))
            Next
            'A-L
            For numY As Integer = 1 To 12
                detY += (difAC_M / 12)
                arYList.Add((detY - (difAC_M / 24)))
            Next
            'Gray01-24
            detY += (difAC_M / 5)
            arYList.Add((detY - (difAC_M / 24)))

        End If

        '内容を配列に代入
        Dim refText As String() = Split(cReader.ReadToEnd(), vbCrLf)
        ' cReader を閉じる
        cReader.Close()

        '取得したX座標とY座標のそれぞれの交点に四角形を描画し、範囲内のピクセルのRGB平均を算出する。
        Dim cntTip As Integer = 0
        Dim SumDeltaEab As Double = 0
        Dim SumDeltaE00 As Double = 0
        Dim arOutputlist As New ArrayList

        '出力用変数
        Dim OutLine As String() = New String() {"パッチNo", "L*基準値", "a*基準値", "b*基準値", "L*測定値", "a*測定値", "b*測定値", "⊿E*ab", "⊿E00"}
        '出力用配列に追加
        arOutputlist.Add(Join(OutLine, ","))

        'ステータス変更
        Me.tsStatusLabel.Text = "Lab値を検出しています..."

        Dim cntYList As Integer = 0
        For Each y As Integer In arYList
            cntYList += 1

            Dim cntXList As Integer = 0
            'IT8の最終行の場合arXListを1-24に変更する。
            If (Me.rbChartIT8.Checked = True And cntYList = 13) Or (Me.rbChartIT8Trans.Checked = True And cntYList = 13) Then
                arXList.Clear()
                Dim difAB_M As Integer = difAB + (difAB * 0.022)
                Dim detX As Integer = pntA.X - (difAB * 0.012)
                For numX As Integer = 1 To 24
                    detX += (difAB_M / 24)
                    arXList.Add((detX - (difAB_M / 48)))
                Next
            End If

            For Each x As Integer In arXList
                cntXList += 1

                cntTip += 1
                Dim Radius As Integer = (PatchSide / 2)
                Dim Lab As String() = GetLab(x, y, Radius, 0.7)
                Dim L As String = Lab(0)
                Dim a As String = Lab(1)
                Dim b As String = Lab(2)

                '色差を計算し、配列に代入
                Dim stRef As String = refText(cntTip - 1)
                Dim arRef As String() = Split(stRef, vbTab)
                Dim DeltaL As Double = arRef(1) - L
                Dim Deltaa As Double = arRef(2) - a
                Dim Deltab As Double = arRef(3) - b
                Dim DeltaEab As Double = Math.Sqrt(DeltaL ^ 2 + Deltaa ^ 2 + Deltab ^ 2)
                Dim DeltaE00 As Double = GetDE00(CDbl(arRef(1)), CDbl(arRef(2)), CDbl(arRef(3)), L, a, b)

                '⊿Eのの合計を求める
                SumDeltaEab += DeltaEab
                SumDeltaE00 += DeltaE00

                '出力用変数
                OutLine = New String() {arRef(0), arRef(1), arRef(2), arRef(3), L, a, b, Format(DeltaEab, "0.00"), Format(DeltaE00, "0.00")}
                Me.fgrResult.Rows.Count += 1
                Me.fgrResult(cntTip, "パッチNo") = arRef(0)
                Me.fgrResult(cntTip, "L*測定値") = L
                Me.fgrResult(cntTip, "a*測定値") = a
                Me.fgrResult(cntTip, "b*測定値") = b
                Me.fgrResult(cntTip, "⊿E*ab") = Format(DeltaEab, "0.00")
                Me.fgrResult(cntTip, "⊿E00") = Format(DeltaE00, "0.00")

                '出力用配列に追加
                arOutputlist.Add(Join(OutLine, ","))

                '待機中のイベントを処理する
                Application.DoEvents()
                'キャンセルボタンがクリックされたか調べる
                If canceled Then
                    'キャンセルされた時
                    MessageBox.Show("処理を中止しました。")
                    'ステータス変更
                    Me.tsStatusLabel.Text = "処理を中止しました。"
                    ChangeState(False)
                    Exit Sub
                End If

            Next
        Next


        'ステータス変更
        Me.tsStatusLabel.Text = "⊿Eを算出しました。"
        'イメージを表示
        PreviewImage(src_img)

        '平均色差を表示
        Dim AvgDeltaEab As Double = SumDeltaEab / CDbl(cntTip)
        Dim AvgDeltaE00 As Double = SumDeltaE00 / CDbl(cntTip)
        Dim stAvgDeltaEab As String = Format(AvgDeltaEab, "0.00")
        Dim stAvgDeltaE00 As String = Format(AvgDeltaE00, "0.00")
        Me.txtDEab.Text = stAvgDeltaEab
        Me.txtDE00.Text = stAvgDeltaE00

        'ソースイメージの解放
        'Cv.ReleaseImage(src_img)

        '出力用配列に追加
        arOutputlist.Add("平均色差,,,,,,," & stAvgDeltaEab & "," & stAvgDeltaE00)

        '結果をCSVに出力
        Using st As New System.IO.StreamWriter(Me.txtOutputFolder.Text & "\計測Lab値_" & IO.Path.GetFileName(strInputFilePath) & "_" & Date.Now.ToString("yyyyMMddHHmmss") & ".csv", False, System.Text.Encoding.Default)
            For i As Integer = 0 To arOutputlist.Count - 1
                'ファイルへ書込み
                st.WriteLine(arOutputlist(i).ToString())
            Next
            'ファイル閉じる
        End Using

        ChangeState(False)

    End Sub

    ''' <summary>
    ''' キャンセルボタン
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
        If MessageBox.Show("処理を中止します。" & vbNewLine & "よろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
            Exit Sub
        End If
        '実行中フラグをFalseにする。
        Doing = False
        'キャンセルのフラグを立てる
        canceled = True

    End Sub

#End Region


#Region "プライベートメソッド"
    ''' <summary>
    ''' Labを検出
    ''' </summary>
    ''' <param name="x"></param>
    ''' <param name="y"></param>
    ''' <param name="Radius"></param>
    ''' <param name="rect_rate"></param>
    ''' <returns></returns>
    Private Function GetLab(ByVal x As Integer, ByVal y As Integer, ByVal Radius As Integer, ByVal rect_rate As Double) As String()
        '枠内を画像として格納し、平滑化処理（ガウシアン）をした後、中央のピクセルのRGBを取得
        Dim patch_img As IplImage = Cv.LoadImage(strInputFilePath) 'カラーチャート読込(Lab値取得用)
        Dim Diameter As Integer = Radius * 2 * rect_rate
        Dim rectPoint As CvPoint = Cv.Point(x - (Diameter / 2), y - (Diameter / 2))
        Dim rectSize As CvSize = Cv.Size(Diameter, Diameter)
        Dim rectPS As CvRect = New CvRect(rectPoint, rectSize)   '矩形の位置とサイズを宣言
        Cv.SetImageROI(patch_img, rectPS)  '宣言した矩形でトリミング

        '交点を中心に緑枠を描画
        Cv.Rectangle(src_img, rectPS, Cv.RGB(0, 255, 0), 3)

        'RGBのバラツキをなくすため平滑化処理
        Dim gaus_img As IplImage = Cv.CreateImage(rectSize, patch_img.Depth, patch_img.NChannels)
        Cv.Smooth(patch_img, gaus_img, SmoothType.Gaussian, 19, 19, 7, 7)

        'イメージを表示
        PreviewImage(src_img)

        Dim gausRGB As CvScalar = Cv.Get2D(gaus_img, Radius, Radius)    '中央ピクセルのRGB値取得
        Dim gausLab As String() = rgb2lab(gausRGB)  '取得したRGB値からLab値を取得

        Dim varL As Double = gausLab(0)
        Dim vara As Double = gausLab(1)
        Dim varb As Double = gausLab(2)

        Dim L As String = Format(varL, "0.00")
        Dim a As String = Format(vara, "0.00")
        Dim b As String = Format(varb, "0.00")

        Cv.ReleaseImage(patch_img)
        Cv.ReleaseImage(gaus_img)

        Return New String() {L, a, b}
    End Function

    ''' <summary>
    ''' RGB値からLab値への変換(D50で計算)
    ''' </summary>
    ''' <param name="rgb"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function rgb2lab(ByVal rgb As CvScalar)
        Dim threshold As Double = 0.008856

        Dim R As Double = rgb(2) / 255
        Dim G As Double = rgb(1) / 255
        Dim B As Double = rgb(0) / 255
        Dim X As Double = 0
        Dim Y As Double = 0
        Dim Z As Double = 0

        If Me.rbsRGB.Checked = True Then
            '色空間sRGB(D50)
            R = If(R > 0.04045, Math.Pow((R + 0.055) / 1.055, 2.4), R / 12.92)
            G = If(G > 0.04045, Math.Pow((G + 0.055) / 1.055, 2.4), G / 12.92)
            B = If(B > 0.04045, Math.Pow((B + 0.055) / 1.055, 2.4), B / 12.92)
            R = R * 100
            G = G * 100
            B = B * 100
            X = R * 0.4360747 + G * 0.3850649 + B * 0.1430804
            Y = R * 0.2225045 + G * 0.7168786 + B * 0.0606169
            Z = R * 0.0139322 + G * 0.0971045 + B * 0.7141733

        Else
            '色空間adobeRGB(D50)
            R = If(R > 0.0556, Math.Pow(R, 2.2), R / 32)
            G = If(G > 0.0556, Math.Pow(G, 2.2), G / 32)
            B = If(B > 0.0556, Math.Pow(B, 2.2), B / 32)
            R = R * 100
            G = G * 100
            B = B * 100
            X = R * 0.609741 + G * 0.205273 + B * 0.149187
            Y = R * 0.311113 + G * 0.625675 + B * 0.063212
            Z = R * 0.019465 + G * 0.060874 + B * 0.74456
        End If

        '白色点座標(D50)
        Dim ref_x As Double = 0.9642
        Dim ref_y As Double = 1.0
        Dim ref_z As Double = 0.8249

        X = X / (ref_x * 100)
        Y = Y / (ref_y * 100)
        Z = Z / (ref_z * 100)

        X = If(X > threshold, Math.Pow(X, 1 / 3), (7.787 * X) + (16 / 116))
        Y = If(Y > threshold, Math.Pow(Y, 1 / 3), (7.787 * Y) + (16 / 116))
        Z = If(Z > threshold, Math.Pow(Z, 1 / 3), (7.787 * Z) + (16 / 116))

        Dim sL As Double = (116 * Y) - 16
        Dim sA As Double = 500 * (X - Y)
        Dim sB As Double = 200 * (Y - Z)

        Dim lab As String() = New String() {sL, sA, sB}

        Return lab

    End Function

    ''' <summary>
    ''' テンプレートマッチング
    ''' </summary>
    ''' <param name="src_img"></param>
    ''' <param name="tmp_img"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function TemprateMatch(ByVal src_img As IplImage, ByVal tmp_img As IplImage)
        'マッチング用画像作成
        Dim size As CvSize = New CvSize(src_img.Width - tmp_img.Width + 1, src_img.Height - tmp_img.Height + 1)
        Dim dst_img As IplImage = Cv.CreateImage(size, CvConst.IPL_DEPTH_32F, 1)

        'マッチングさせて、最良値の箇所に赤枠を描画
        Cv.MatchTemplate(src_img, tmp_img, dst_img, MatchTemplateMethod.CCoeff)
        Return dst_img

    End Function

    ''' <summary>
    ''' 画像表示
    ''' </summary>
    ''' <param name="src_img"></param>
    ''' <remarks></remarks>
    Private Sub PreviewImage(ByVal src_img As IplImage)
        '最小化時は処理しない
        If MyBase.Size.Height < MyBase.MinimumSize.Height Then
            Exit Sub
        End If

        '補間方法を指定して画像を縮小してpictureboxに描画する(バイキュービック)

        '長辺から縮率を計算する。
        Dim PictureBoxSize As Integer = If(src_img.Width > src_img.Width, PictureBoxIpl1.Width, PictureBoxIpl1.Height)
        Dim LongSide As Integer = If(src_img.Width > src_img.Height, src_img.Width, src_img.Height)
        Dim Reduction As Double = LongSide / PictureBoxSize

        Dim result_size As CvSize = Cv.Size(src_img.Width / Reduction, src_img.Height / Reduction)
        Dim result_img As IplImage = Cv.CreateImage(result_size, src_img.Depth, src_img.NChannels)
        Cv.Resize(src_img, result_img, Interpolation.Cubic)

        'ピクチャーボックスに結果を表示
        PictureBoxIpl1.ImageIpl = result_img
        '待機中のイベントを処理する
        Application.DoEvents()
        'イメージの解放
        Cv.ReleaseImage(result_img)

    End Sub

    ''' <summary>
    ''' オブジェクトステータス変更
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ChangeState(ByVal StateFlag As Boolean)
        Doing = StateFlag
        canceled = Not StateFlag

        Me.btnCancel.Enabled = StateFlag
        Me.btnStart.Enabled = Not StateFlag
        Me.btnOutputBrowse.Enabled = Not StateFlag
        Me.rbAdobeRGB.Enabled = Not StateFlag
        Me.rbsRGB.Enabled = Not StateFlag
        Me.rbChartCL.Enabled = Not StateFlag
        Me.rbChartSG.Enabled = Not StateFlag
        Me.rbChartIT8.Enabled = Not StateFlag
        Me.rbChartIT8Trans.Enabled = Not StateFlag
        Me.txtOutputFolder.Enabled = Not StateFlag

    End Sub

    ''' <summary>
    ''' ラジアン変換
    ''' </summary>
    ''' <param name="Degrees"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function ToRadian(ByVal Degrees As Double) As Double
        Return (Math.PI / 180) * Degrees
    End Function

    ''' <summary>
    ''' 2乗和の平方根
    ''' </summary>
    ''' <param name="dbl1"></param>
    ''' <param name="dbl2"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function hypot(ByVal dbl1 As Double, ByVal dbl2 As Double)
        Return Math.Sqrt(Math.Pow(dbl1, 2) + Math.Pow(dbl2, 2))
    End Function

    ''' <summary>
    ''' CIE2000色差式
    ''' </summary>
    ''' <remarks></remarks>
    Private Function GetDE00(ByVal l1 As Double, ByVal a1 As Double, ByVal b1 As Double, ByVal l2 As Double, ByVal a2 As Double, ByVal b2 As Double)
        Dim Delta As Double = 0

        'パラメトリック係数
        Dim kL As Double = 1
        Dim kC As Double = 1
        Dim kH As Double = 1

        Dim dld As Double = l2 - l1
        Dim lb As Double = (l1 + l2) / 2
        Dim cs1 As Double = hypot(a1, b1)
        Dim cs2 As Double = hypot(a2, b2)
        Dim cb As Double = (cs1 + cs2) / 2
        Dim cb7 As Double = Math.Pow(cb, 7)
        Dim ad1 As Double = a1 + (a1 / 2) * (1 - Math.Sqrt(cb7 / (cb7 + Math.Pow(25, 7))))
        Dim ad2 As Double = a2 + (a2 / 2) * (1 - Math.Sqrt(cb7 / (cb7 + Math.Pow(25, 7))))
        Dim cd1 As Double = hypot(ad1, b1)
        Dim cd2 As Double = hypot(ad2, b2)
        Dim cbd As Double = (cd1 + cd2) / 2
        Dim dcd As Double = cd2 - cd1
        Dim hd1 As Double = IIf(b1 = 0 And ad1 = 0, 0, Math.Atan2(b1, ad1))
        If hd1 < 0 Then
            hd1 += 360
        End If
        Dim hd2 As Double = IIf(b2 = 0 And ad2 = 0, 0, Math.Atan2(b2, ad2))
        If hd2 < 0 Then
            hd2 += 360
        End If

        Dim dhd As Double = 0
        Dim hd1_hd2 As Double = hd1 - hd2
        hd1_hd2 = Math.Abs(hd1_hd2)
        If cd1 = 0 And cd2 = 0 Then
            dhd = 0
        ElseIf hd1_hd2 <= 180 Then
            dhd = hd2 - hd1
        ElseIf hd1_hd2 > 180 And hd2 <= hd1 Then
            dhd = hd2 - hd1 + 360
        Else
            dhd = hd2 - hd1 - 360
        End If

        Dim dhhd As Double = 2 * Math.Sqrt(cd1 * cd2) * Math.Sin(dhd / 2)
        Dim hhbd As Double = 0
        If cd1 = 0 And cd2 = 0 Then
            hhbd = hd1 + hd2
        ElseIf hd1_hd2 <= 180 Then
            hhbd = (hd1 + hd2) / 2
        ElseIf hd1_hd2 > 180 And (hd1 + hd2) < 360 Then
            hhbd = (hd1 + hd2 + 360) / 2
        Else
            hhbd = (hd1 + hd2 - 360) / 2
        End If

        Dim t As Double = 1 - 0.17 * Math.Cos(hhbd - ToRadian(30)) + 0.24 * Math.Cos(2 * hhbd) + 0.32 * Math.Cos(3 * hhbd + ToRadian(6)) - 0.2 * Math.Cos(4 * hhbd - ToRadian(63))
        Dim sl As Double = 1 + ((0.015 * Math.Pow((lb - 50), 2)) / Math.Sqrt(20 + Math.Pow((lb - 50), 2)))
        Dim sc As Double = 1 + 0.045 * cbd
        Dim sh As Double = 1 + 0.015 * cbd * t

        Dim cbd7 As Double = Math.Pow(cbd, 7)
        Dim rt As Double = -2 * Math.Sqrt((cbd7 / cbd7 + Math.Pow(25, 7))) * Math.Sin(ToRadian(60) * Math.Exp(-1 * Math.Pow(((hhbd - ToRadian(275)) / ToRadian(25)), 2)))

        Delta = Math.Sqrt(Math.Pow((dld / (kL * sl)), 2) + Math.Pow((dcd / (kC * sc)), 2) + Math.Pow((dhd / (kH * sh)), 2) + rt * (dcd / (kC * sh)) * (dhhd / (kH * sh)))

        Return Delta
    End Function

#End Region
End Class
