Imports Leadtools
Imports Leadtools.Codecs
Imports Leadtools.WinForms
Imports Leadtools.Drawing
Imports Leadtools.ImageProcessing
Imports Leadtools.ColorConversion

Public Class frmMain

#Region "プライベート変数"

	'画像の入出力するためのRasterCodecsオブジェクト
	Private codecs As RasterCodecs
	Private _cancel As Boolean = False

#End Region

#Region "フォームイベント"

	''' <summary>
	''' フォームロード時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load

		Me.Text = My.Application.Info.ProductName & " Ver." &
			My.Application.Info.Version.ToString

		XmlSettings.LoadFromXmlFile()
		Me.txtCSVFile.Text = XmlSettings.Instance.CSVFile
		Me.txtParentFolder.Text = XmlSettings.Instance.ParentFolder
		Me.txtOutputFolder.Text = XmlSettings.Instance.OutputFolder
		Me.txtLogFolder.Text = XmlSettings.Instance.LogFolder

		Initialize()

	End Sub

	''' <summary>
	''' フォームクロージング
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub frmMain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

		If MessageBox.Show("アプリケーションを終了します" & vbNewLine & "よろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
			e.Cancel = True
		Else
			XmlSettings.LoadFromXmlFile()
			XmlSettings.Instance.CSVFile = Me.txtCSVFile.Text
			XmlSettings.Instance.ParentFolder = Me.txtParentFolder.Text
			XmlSettings.Instance.OutputFolder = Me.txtOutputFolder.Text
			XmlSettings.Instance.LogFolder = Me.txtLogFolder.Text
			XmlSettings.SaveToXmlFile()
		End If

	End Sub

#End Region

#Region "オブジェクトイベント"

	''' <summary>
	''' テキストボックスドラッグエンター時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub txt_DragEnter(sender As Object, e As DragEventArgs) Handles txtCSVFile.DragEnter, txtParentFolder.DragEnter, txtOutputFolder.DragEnter, txtLogFolder.DragEnter

		If e.Data.GetDataPresent(DataFormats.FileDrop) Then
			e.Effect = DragDropEffects.Copy
		Else
			e.Effect = DragDropEffects.None
		End If

	End Sub

	''' <summary>
	''' CSVファイルドロップ時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub txtCSVFile_DragDrop(sender As Object, e As DragEventArgs) Handles txtCSVFile.DragDrop

		Dim strFiles As String() = CType(e.Data.GetData(DataFormats.FileDrop, False), String())
		If System.IO.File.Exists(strFiles(0)) Then
			Me.txtCSVFile.Text = strFiles(0)
		End If

	End Sub

	''' <summary>
	''' 親フォルダドロップ時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub txtParentFolder_DragDrop(sender As Object, e As DragEventArgs) Handles txtParentFolder.DragDrop

		Dim strFiles As String() = CType(e.Data.GetData(DataFormats.FileDrop, False), String())
		If System.IO.Directory.Exists(strFiles(0)) Then
			Me.txtParentFolder.Text = strFiles(0)
		End If

	End Sub

	''' <summary>
	''' 出力フォルダドロップ時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub txtOutputFolder_DragDrop(sender As Object, e As DragEventArgs) Handles txtOutputFolder.DragDrop

		Dim strFiles As String() = CType(e.Data.GetData(DataFormats.FileDrop, False), String())
		If System.IO.Directory.Exists(strFiles(0)) Then
			Me.txtOutputFolder.Text = strFiles(0)
		End If

	End Sub

	''' <summary>
	''' ログフォルダドロップ時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub txtLogFolder_DragDrop(sender As Object, e As DragEventArgs) Handles txtLogFolder.DragDrop

		Dim strFiles As String() = CType(e.Data.GetData(DataFormats.FileDrop, False), String())
		If System.IO.Directory.Exists(strFiles(0)) Then
			Me.txtLogFolder.Text = strFiles(0)
		End If

	End Sub

	''' <summary>
	''' 実行ボタン押下時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub btnRun_Click(sender As Object, e As EventArgs) Handles btnRun.Click

		If Not System.IO.File.Exists(Me.txtCSVFile.Text) Then
			MessageBox.Show("CSVファイルが指定されていません", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Exit Sub
		End If
		If Not System.IO.Directory.Exists(Me.txtParentFolder.Text) Then
			MessageBox.Show("親フォルダが指定されていません", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Exit Sub
		End If
		If Not System.IO.Directory.Exists(Me.txtOutputFolder.Text) Then
			MessageBox.Show("出力フォルダが指定されていません", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Exit Sub
		End If
		If Not System.IO.Directory.Exists(Me.txtLogFolder.Text) Then
			MessageBox.Show("ログ保存フォルダが指定されていません", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Exit Sub
		End If

		If MessageBox.Show("キャプション挿入処理を開始します" & vbNewLine & "よろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
			Exit Sub
		End If

		EnableControls(False)

		Dim strCSVFile As String = Me.txtCSVFile.Text
		Dim strParentFolder As String = Me.txtParentFolder.Text
		Dim strOutputFolder As String = Me.txtOutputFolder.Text
		Dim strLogFolder As String = Me.txtLogFolder.Text

		Try
			Me.lstResult.Items.Clear()
			WriteLstResult(Me.lstResult, "キャプション挿入処理開始")
			WriteLstResult(Me.lstResult, "CSVファイル：" & System.IO.Path.GetFileName(strCSVFile))
			WriteLstResult(Me.lstResult, "親フォルダ：" & strParentFolder)
			WriteLstResult(Me.lstResult, "出力フォルダ：" & strOutputFolder)
			WriteLstResult(Me.lstResult, "ログフォルダ：" & strLogFolder)
			If Me.chkEnableSerial.Checked Then
				WriteLstResult(Me.lstResult, "連番付与：する")
				WriteLstResult(Me.lstResult, "開始連番：" & Me.numSerialStart.Value)
				WriteLstResult(Me.lstResult, "結合文字列：[" & Me.txtMergeString.Text & "]")
			Else
				WriteLstResult(Me.lstResult, "連番付与：しない")
			End If

			Dim iRecCount As Integer = 0
			Dim encEncode As System.Text.Encoding
			If Me.cmbEncode.SelectedIndex = 0 Then
				encEncode = System.Text.Encoding.UTF8
			Else
				encEncode = System.Text.Encoding.GetEncoding("Shift_JIS")
			End If

			Using parser As New CSVParser(strCSVFile, encEncode)
				parser.Delimiter = ","  'カンマ区切り
				parser.HasFieldsEnclosedInQuotes = True
				parser.TrimWhiteSpace = False

				iRecCount = 0

				parser.ReadFields() 'ヘッダ業を読み飛ばす
				'最終行まで読み込み
				While Not parser.EndOfData

					iRecCount += 1
					Dim row As String() = parser.ReadFields()
					'子フォルダ以下の画像ファイルをすべて配列に列挙する
					If Not System.IO.Directory.Exists(strParentFolder & "\" & row(0)) Then
						WriteLstResult(Me.lstResult, "該当のフォルダが存在しないか、ファイルがありません：" & row(0), ResultMark.ErrorMark)
						Continue While
					End If
					Dim strFiles As String() = GetFilesMostDeep(strParentFolder & "\" & row(0), {"*.tif"})
					WriteLstResult(Me.lstResult, "フォルダ名：" & row(0))
					WriteLstResult(Me.lstResult, "項目1：" & row(1))
					WriteLstResult(Me.lstResult, "項目2：" & row(2))
					WriteLstResult(Me.lstResult, "項目3：" & row(3))
					WriteLstResult(Me.lstResult, "項目4：" & row(4))
					WriteLstResult(Me.lstResult, "項目5：" & row(5))
					WriteLstResult(Me.lstResult, "X座標：" & row(6))
					WriteLstResult(Me.lstResult, "Y座標：" & row(7))

					Dim iFileCount As Integer = Me.numSerialStart.Value
					For Each strFile As String In strFiles
						Application.DoEvents()
						'キャンセルフラグが立っていた場合は中断する
						If _cancel Then
							If MessageBox.Show("処理を中断します" & vbNewLine & "よろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
								WriteLstResult(Me.lstResult, "処理を中断しました")
								OutputListLog(Me.lstResult, strLogFolder, "キャプション挿入(中断)", Date.Now.ToString("yyyyMMddHHmmss"))
								_cancel = False
								Exit Sub
							End If
						End If
						'JudgeStart(strFile, Me.numYStart.Value)
						WriteLstResult(Me.lstResult, "ファイル名：" & System.IO.Path.GetFileName(strFile))
						InsertString(strFile, New Point(row(6), row(7)), row, iFileCount)
						iFileCount += 1
					Next
				End While
			End Using

			WriteLstResult(Me.lstResult, "キャプション挿入処理終了")
			OutputListLog(Me.lstResult, strLogFolder, "キャプション挿入", Date.Now.ToString("yyyyMMddHHmmss"))

			MessageBox.Show("キャプション挿入処理が終了しました", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information)

		Catch ex As Exception

			MessageBox.Show(ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		Finally

			EnableControls(True)

		End Try
	End Sub

	''' <summary>
	''' 中断ボタン押下時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub btnAbort_Click(sender As Object, e As EventArgs) Handles btnAbort.Click

		_cancel = True

	End Sub

	''' <summary>
	''' チェックボックス状態変更時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub chkEnableSerial_CheckedChanged(sender As Object, e As EventArgs) Handles chkEnableSerial.CheckedChanged

		Me.numSerialStart.Enabled = Me.chkEnableSerial.Checked
		Me.txtMergeString.Enabled = Me.chkEnableSerial.Checked

	End Sub

#End Region

#Region "プライベートメソッド"

	''' <summary>
	''' 初期化処理
	''' </summary>
	Private Sub Initialize()

		'LEADTOOLS17.5のライセンスキー組み込み
		Dim developerKey As String = "+sxwXvpT1JbgbQ7DAdF9k8WRWcBnLgwIjN2a3sVpuzOIoMTYIWPT13qYg3qhCnFE"
		RasterSupport.SetLicense(Application.StartupPath & "\LEAD175ImgSuite.lic", developerKey)
		codecs = New RasterCodecs
		Me.cmbEncode.SelectedIndex = 0
		Me.btnAbort.Enabled = False

	End Sub

	''' <summary>
	''' Y軸の起点を頼りに起点ポイントを探す
	''' </summary>
	''' <param name="strImageFile"></param>
	''' <param name="iYStart"></param>
	Private Sub JudgeStart(ByVal strImageFile As String, ByVal iYStart As Integer)
		'ファイルのロード
		Dim tempImage As RasterImage = codecs.Load(strImageFile)
		Dim rasColor As RasterColor = tempImage.GetPixelColor(1, 1)

	End Sub

	''' <summary>
	''' 起点から順に画像に文字列を埋め込む
	''' </summary>
	''' <param name="strImageFile">対象イメージ</param>
	''' <param name="pntStart">XY起点</param>
	''' <param name="row">テキストから読み取った文字列配列</param>
	Private Sub InsertString(ByVal strImageFile As String, ByVal pntStart As Point, ByVal row() As String, Optional ByVal iSerial As Integer = 0)

		'日付文字列Y軸格納用変数
		Dim iDatePositionY As Integer = 0
		'レコードの最大幅
		Dim dblMaxWidth As Double = 0

		'ファイルのロード
		codecs.Options.Load.Comments = True 'コメント(EXIF情報)を読み込む
		codecs.Options.Load.Markers = True  'カラープロファイル(その他？)を読み込む
		Dim tempImage As RasterImage = codecs.Load(strImageFile)
		'画像のグラフィックコンテナを作成し、文字列を描画する
		Dim container As New Leadtools.Drawing.RasterImageGdiPlusGraphicsContainer(tempImage)
		'フォント、サイズ、色を設定する
		Dim drawFont As New Font("ＭＳ ゴシック", 16)
		Dim drawBrush As New SolidBrush(Color.Black)
		Dim szSize As SizeF

		'連番を付与するか否かで分岐
		If Me.chkEnableSerial.Checked Then
			'付与する
			'==================================================
			Dim strMergeString As String = Me.txtMergeString.Text
			'項目でループ
			For i As Integer = 1 To 6

				If IsNull(row(i)) Then
					Continue For
				End If

				Select Case i
					Case 1
						'1段目
						'2～4項目目まですべてNULLだった場合連番を付与する
						If IsNull(row(2)) And IsNull(row(3)) And IsNull(row(4)) Then
							'すべてNULLなので連番付与
							Dim strItem As String = row(1) & strMergeString & iSerial.ToString("0000")
							szSize = container.Graphics.MeasureString(strItem, drawFont)
							container.Graphics.FillRectangle(Brushes.White, pntStart.X, pntStart.Y, szSize.Width, szSize.Height)
							container.Graphics.DrawString(strItem, drawFont, drawBrush, pntStart)
						Else
							'連番なし
							'背景色の変更
							'文字列に対応した境界サイズを取得
							szSize = container.Graphics.MeasureString(row(i), drawFont)
							container.Graphics.FillRectangle(Brushes.White, pntStart.X, pntStart.Y, szSize.Width, szSize.Height)
							'文字列を描画する
							container.Graphics.DrawString(row(i), drawFont, drawBrush, pntStart)
						End If
						'Y軸を日付文字列用に退避する
						iDatePositionY = pntStart.Y
					Case 2
						'2段目
						'3～4項目目がNULLだったら連番を付与する
						If IsNull(row(3)) And IsNull(row(4)) Then
							'NULLなので連番付与
							Dim strItem As String = row(2) & strMergeString & iSerial.ToString("0000")
							szSize = container.Graphics.MeasureString(strItem, drawFont)
							container.Graphics.FillRectangle(Brushes.White, pntStart.X, pntStart.Y, szSize.Width, szSize.Height)
							container.Graphics.DrawString(strItem, drawFont, drawBrush, pntStart)
						Else
							'連番なし
							'文字列に対応した境界サイズを取得
							szSize = container.Graphics.MeasureString(row(i), drawFont)
							container.Graphics.FillRectangle(Brushes.White, pntStart.X, pntStart.Y, szSize.Width, szSize.Height)
							container.Graphics.DrawString(row(i), drawFont, drawBrush, pntStart)
						End If
					Case 3
						'3段目
						'4段目がなかったら最終項目を結合する
						If IsNull(row(4)) Then
							'4段目なし
							Dim strItem As String = row(3) & strMergeString & iSerial.ToString("0000")
							szSize = container.Graphics.MeasureString(strItem, drawFont)
							container.Graphics.FillRectangle(Brushes.White, pntStart.X, pntStart.Y, szSize.Width, szSize.Height)
							container.Graphics.DrawString(strItem, drawFont, drawBrush, pntStart)
						Else
							'4段目あり
							'文字列に対応した境界サイズを取得
							szSize = container.Graphics.MeasureString(row(i), drawFont)
							container.Graphics.FillRectangle(Brushes.White, pntStart.X, pntStart.Y, szSize.Width, szSize.Height)
							container.Graphics.DrawString(row(i), drawFont, drawBrush, pntStart)
						End If
					Case 4
						'4段目
						Dim strItem As String = row(4) & strMergeString & iSerial.ToString("0000")
						szSize = container.Graphics.MeasureString(strItem, drawFont)
						container.Graphics.FillRectangle(Brushes.White, pntStart.X, pntStart.Y, szSize.Width, szSize.Height)
						container.Graphics.DrawString(strItem, drawFont, drawBrush, pntStart)
					Case 5
						'日付
						'文字列に対応した境界サイズを取得
						szSize = container.Graphics.MeasureString(row(i), drawFont)
						'レコード最大幅から日付文字列幅を引いたものを起点に足した値がX起点
						Dim iDatePositionX As Integer = pntStart.X + dblMaxWidth - szSize.Width
						Dim drawBrush2 As New SolidBrush(Color.White)
						container.Graphics.FillRectangle(Brushes.Black, iDatePositionX, iDatePositionY, szSize.Width, szSize.Height)
						container.Graphics.DrawString(row(i), drawFont, drawBrush2, New Point(iDatePositionX, iDatePositionY))
					Case Else

				End Select

				pntStart.Y += szSize.Height
				If szSize.Width > dblMaxWidth Then
					dblMaxWidth = szSize.Width
				End If

			Next
			'==================================================

		Else
			'付与しない
			'==================================================
			'項目でループ
			For i As Integer = 1 To 6

				If IsNull(row(i)) Then
					Continue For
				End If
				'文字列に対応した境界サイズを取得
				szSize = container.Graphics.MeasureString(row(i), drawFont)

				Select Case i
					Case 1
						'1段目
						'
						'背景色の変更
						container.Graphics.FillRectangle(Brushes.White, pntStart.X, pntStart.Y, szSize.Width, szSize.Height)
						'文字列を描画する
						container.Graphics.DrawString(row(i), drawFont, drawBrush, pntStart)
						'Y軸を日付文字列用に退避する
						iDatePositionY = pntStart.Y
					Case 2, 3, 4
						'2段目
						container.Graphics.FillRectangle(Brushes.White, pntStart.X, pntStart.Y, szSize.Width, szSize.Height)
						container.Graphics.DrawString(row(i), drawFont, drawBrush, pntStart)
					Case 5
						'日付
						'レコード最大幅から日付文字列幅を引いたものを起点に足した値がX起点
						Dim iDatePositionX As Integer = pntStart.X + dblMaxWidth - szSize.Width
						Dim drawBrush2 As New SolidBrush(Color.White)
						container.Graphics.FillRectangle(Brushes.Black, iDatePositionX, iDatePositionY, szSize.Width, szSize.Height)
						container.Graphics.DrawString(row(i), drawFont, drawBrush2, New Point(iDatePositionX, iDatePositionY))
					Case Else

				End Select

				pntStart.Y += szSize.Height
				If szSize.Width > dblMaxWidth Then
					dblMaxWidth = szSize.Width
				End If

			Next
			'==================================================

		End If


		''1段目
		'Dim strSize As SizeF = container.Graphics.MeasureString(row(1), drawFont)
		'container.Graphics.FillRectangle(Brushes.White, pntStart.X, pntStart.Y, strSize.Width, strSize.Height)
		''文字列を描画する
		'container.Graphics.DrawString(row(1), drawFont, drawBrush, pntStart)
		''Y軸を日付文字列用に退避する
		'dblDatePositionY = pntStart.Y
		'pntStart.Y += strSize.Height
		'dblMaxWidth = strSize.Width
		''2段目
		'strSize = container.Graphics.MeasureString(row(2), drawFont)
		'container.Graphics.FillRectangle(Brushes.White, pntStart.X, pntStart.Y, strSize.Width, strSize.Height)
		'container.Graphics.DrawString(row(2), drawFont, drawBrush, pntStart)
		'pntStart.Y += strSize.Height
		'If strSize.Width > dblMaxWidth Then
		'	dblMaxWidth = strSize.Width
		'End If
		''3段目
		''4段目がなかったら最終項目を付与する
		'If Not IsNull(row(4)) Then
		'	'4段目あり
		'	strSize = container.Graphics.MeasureString(row(3), drawFont)
		'	container.Graphics.FillRectangle(Brushes.White, pntStart.X, pntStart.Y, strSize.Width, strSize.Height)
		'	container.Graphics.DrawString(row(3), drawFont, drawBrush, pntStart)
		'	pntStart.Y += strSize.Height
		'Else
		'	'4段目なし
		'	strSize = container.Graphics.MeasureString(row(3) & row(5), drawFont)
		'	container.Graphics.FillRectangle(Brushes.White, pntStart.X, pntStart.Y, strSize.Width, strSize.Height)
		'	container.Graphics.DrawString(row(3) & row(5), drawFont, drawBrush, pntStart)
		'	pntStart.Y += strSize.Height
		'End If
		'If strSize.Width > dblMaxWidth Then
		'	dblMaxWidth = strSize.Width
		'End If
		''4段目
		'If Not IsNull(row(4)) Then
		'	'4段目がある場合だけ書き込み
		'	strSize = container.Graphics.MeasureString(row(4) & row(5), drawFont)
		'	container.Graphics.FillRectangle(Brushes.White, pntStart.X, pntStart.Y, strSize.Width, strSize.Height)
		'	container.Graphics.DrawString(row(4) & row(5), drawFont, drawBrush, pntStart)
		'	pntStart.Y += strSize.Height
		'	If strSize.Width > dblMaxWidth Then
		'		dblMaxWidth = strSize.Width
		'	End If
		'End If
		''日付
		'strSize = container.Graphics.MeasureString(row(6), drawFont)
		''レコード最大幅から日付文字列幅を引いたものを起点に足した値がX起点
		'Dim dblDateXStart As Double = pntStart.X + dblMaxWidth - strSize.Width
		'Dim drawBrush2 As New SolidBrush(Color.White)
		'container.Graphics.FillRectangle(Brushes.Black, pntStart.X, pntStart.Y, strSize.Width, strSize.Height)
		'container.Graphics.DrawString(row(6), drawFont, drawBrush2, New Point(dblDateXStart, dblDatePositionY))

		'画像を保存
		Dim _format As RasterImageFormat = tempImage.OriginalFormat
		Dim _bitsPerPixel As Integer = tempImage.BitsPerPixel
		If Not System.IO.Directory.Exists(Me.txtOutputFolder.Text & "\" & row(0)) Then
			My.Computer.FileSystem.CreateDirectory(Me.txtOutputFolder.Text & "\" & row(0))
		End If
		codecs.Options.Save.Comments = True 'コメント(EXIF情報)を引き継いで保存する
		codecs.Options.Save.Markers = True  'カラープロファイル(その他？)を引き継いで保存する
		Dim strDestImage As String = Me.txtOutputFolder.Text & "\" & row(0) & "\" & System.IO.Path.GetFileName(strImageFile)
		codecs.Save(tempImage, strDestImage, _format, _bitsPerPixel)

		'ExifID:ColorProfileを書き換える
		Dim strCommandLine As String = Application.StartupPath & "\exiftool.exe -overwrite_original -ColorSpace=Uncalibrated "
		strCommandLine &= """" & strDestImage & """"
		RunCommand(strCommandLine)

		''ICCプロファイル(AdobeRGB(1998))の埋め込み
		'WriteICCProfile(strDestImage, Application.StartupPath & "\AdobeRGB1998.icc")

	End Sub

	''' <summary>
	''' プロファイルの埋め込み
	''' </summary>
	''' <param name="strImageFile"></param>
	''' <param name="strICCFile"></param>
	Private Sub WriteICCProfile(ByVal strImageFile As String, ByVal strICCFile As String)

		'Dim iccProfile As New IccProfileExtended(strICCFile)
		'iccProfile.WriteToImage(strImageFile, 1)

		'Using myMagick As New ImageMagick.MagickImage(strImageFile)
		'	myMagick.RemoveProfile("icc")
		'	myMagick.Write(strImageFile)
		'End Using
		'Using myMagick As New ImageMagick.MagickImage(strImageFile)
		'	If myMagick.GetColorProfile() Is Nothing Then
		'		myMagick.AddProfile(ImageMagick.ColorProfile.SRGB)
		'	End If
		'	myMagick.AddProfile(ImageMagick.ColorProfile.AdobeRGB1998)
		'	myMagick.Write(strImageFile)
		'	'Dim pro As ImageMagick.ColorProfile = myMagick.GetColorProfile()
		'	'MessageBox.Show(pro.ColorSpace & vbTab & pro.Name)
		'End Using
	End Sub

	''' <summary>
	''' コマンドライン実行
	''' </summary>
	''' <param name="strCmd"></param>
	Private Sub RunCommand(ByVal strCmd As String)

		'Processオブジェクトを作成
		Dim p As New System.Diagnostics.Process()
		'ComSpec(cmd.exe)のパスを取得して、FileNameプロパティに設定
		p.StartInfo.FileName = System.Environment.GetEnvironmentVariable("ComSpec")
		'出力を読み取れるようにする
		p.StartInfo.UseShellExecute = False
		p.StartInfo.RedirectStandardOutput = True
		p.StartInfo.RedirectStandardInput = False
		'ウィンドウを表示しないようにする
		p.StartInfo.CreateNoWindow = True
		'コマンドラインを指定("/c"は実行後閉じるために必要)
		p.StartInfo.Arguments = "/c " & strCmd

		'起動
		p.Start()
		'出力を読み取る
		Dim results As String = p.StandardOutput.ReadToEnd()

		'プロセス終了まで待機する
		'WaitForExitはReadToEndのあとである必要がある
		'(親プロセス、子プロセスでブロック防止の為)
		p.WaitForExit()
		p.Close()

		'出力された結果を表示
		'Console.WriteLine(results)

	End Sub

	''' <summary>
	''' コントロールの仕様可否を切り替える
	''' </summary>
	''' <param name="blnEnabled"></param>
	Private Sub EnableControls(ByVal blnEnabled As Boolean)

		Me.txtCSVFile.Enabled = blnEnabled
		Me.txtParentFolder.Enabled = blnEnabled
		Me.txtOutputFolder.Enabled = blnEnabled
		Me.txtLogFolder.Enabled = blnEnabled
		Me.chkEnableSerial.Enabled = blnEnabled
		Me.numSerialStart.Enabled = blnEnabled
		Me.txtMergeString.Enabled = blnEnabled
		Me.cmbEncode.Enabled = blnEnabled
		Me.btnRun.Enabled = blnEnabled
		Me.btnAbort.Enabled = Not blnEnabled

	End Sub

#End Region

End Class
