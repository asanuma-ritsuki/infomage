Imports Leadtools
Imports Leadtools.Codecs
Imports Leadtools.WinForms
Imports Leadtools.Drawing
Imports Leadtools.ImageProcessing

Public Class frmMain

#Region "プライベート変数"

	'画像の入出力するためのRasterCodecsオブジェクト
	Private codecs As RasterCodecs

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
		Me.numYStart.Value = XmlSettings.Instance.YStart

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
			XmlSettings.Instance.YStart = Me.numYStart.Value
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

		EnableControls(Me, False)

		Dim strCSVFile As String = Me.txtCSVFile.Text
		Dim strParentFolder As String = Me.txtParentFolder.Text
		Dim strOutputFolder As String = Me.txtOutputFolder.Text
		Dim strLogFolder As String = Me.txtLogFolder.Text

		Try
			Me.lstResult.Items.Clear()
			WriteLstResult(Me.lstResult, "CSVファイル：" & System.IO.Path.GetFileName(strCSVFile))
			WriteLstResult(Me.lstResult, "親フォルダ：" & strParentFolder)
			WriteLstResult(Me.lstResult, "出力フォルダ：" & strOutputFolder)
			WriteLstResult(Me.lstResult, "ログフォルダ：" & strLogFolder)
			WriteLstResult(Me.lstResult, "Y軸起点：" & Me.numYStart.Value)

			Dim iRecCount As Integer = 0
			Using parser As New CSVParser(strCSVFile, System.Text.Encoding.GetEncoding("Shift_JIS"))
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
					Dim strFiles As String() = GetFilesMostDeep(strParentFolder & "\" & row(0), {"*.tif"})

					For Each strFile As String In strFiles
						'JudgeStart(strFile, Me.numYStart.Value)
						InsertString(strFile, New Point(4296, 362), row)
					Next
				End While
			End Using

		Catch ex As Exception

			MessageBox.Show(ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		Finally

			EnableControls(Me, True)

		End Try
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
		MessageBox.Show("あいうえお")

	End Sub

	''' <summary>
	''' 起点から順に画像に文字列を埋め込む
	''' </summary>
	''' <param name="strImageFile">対象イメージ</param>
	''' <param name="pntStart">XY起点</param>
	''' <param name="row">テキストから読み取った文字列配列</param>
	Private Sub InsertString(ByVal strImageFile As String, ByVal pntStart As Point, ByVal row() As String)

		'日付文字列Y軸格納用変数
		Dim dblDatePositionY As Double = 0
		'レコードの最大幅
		Dim dblMaxWidth As Double = 0

		'ファイルのロード
		Dim tempImage As RasterImage = codecs.Load(strImageFile)
		'画像のグラフィックコンテナを作成し、文字列を描画する
		Dim container As New Leadtools.Drawing.RasterImageGdiPlusGraphicsContainer(tempImage)
		'フォント、サイズ、色を設定する
		Dim drawFont As New Font("ＭＳ ゴシック", 16)
		Dim drawBrush As New SolidBrush(Color.Black)
		'1段目
		Dim strSize As SizeF = container.Graphics.MeasureString(row(1), drawFont)
		container.Graphics.FillRectangle(Brushes.White, pntStart.X, pntStart.Y, strSize.Width, strSize.Height)
		'文字列を描画する
		container.Graphics.DrawString(row(1), drawFont, drawBrush, pntStart)
		'Y軸を日付文字列用に退避する
		dblDatePositionY = pntStart.Y
		pntStart.Y += strSize.Height
		dblMaxWidth = strSize.Width
		'2段目
		strSize = container.Graphics.MeasureString(row(2), drawFont)
		container.Graphics.FillRectangle(Brushes.White, pntStart.X, pntStart.Y, strSize.Width, strSize.Height)
		container.Graphics.DrawString(row(2), drawFont, drawBrush, pntStart)
		pntStart.Y += strSize.Height
		If strSize.Width > dblMaxWidth Then
			dblMaxWidth = strSize.Width
		End If
		'3段目
		'4段目がなかったら最終項目を付与する
		If Not IsNull(row(4)) Then
			'4段目あり
			strSize = container.Graphics.MeasureString(row(3), drawFont)
			container.Graphics.FillRectangle(Brushes.White, pntStart.X, pntStart.Y, strSize.Width, strSize.Height)
			container.Graphics.DrawString(row(3), drawFont, drawBrush, pntStart)
			pntStart.Y += strSize.Height
		Else
			'4段目なし
			strSize = container.Graphics.MeasureString(row(3) & row(5), drawFont)
			container.Graphics.FillRectangle(Brushes.White, pntStart.X, pntStart.Y, strSize.Width, strSize.Height)
			container.Graphics.DrawString(row(3) & row(5), drawFont, drawBrush, pntStart)
			pntStart.Y += strSize.Height
		End If
		If strSize.Width > dblMaxWidth Then
			dblMaxWidth = strSize.Width
		End If
		'4段目
		If Not IsNull(row(4)) Then
			'4段目がある場合だけ書き込み
			strSize = container.Graphics.MeasureString(row(4) & row(5), drawFont)
			container.Graphics.FillRectangle(Brushes.White, pntStart.X, pntStart.Y, strSize.Width, strSize.Height)
			container.Graphics.DrawString(row(4) & row(5), drawFont, drawBrush, pntStart)
			pntStart.Y += strSize.Height
			If strSize.Width > dblMaxWidth Then
				dblMaxWidth = strSize.Width
			End If
		End If
		'日付
		strSize = container.Graphics.MeasureString(row(6), drawFont)
		'レコード最大幅から日付文字列幅を引いたものを起点に足した値がX起点
		Dim dblDateXStart As Double = pntStart.X + dblMaxWidth - strSize.Width
		Dim drawBrush2 As New SolidBrush(Color.White)
		container.Graphics.FillRectangle(Brushes.Black, pntStart.X, pntStart.Y, strSize.Width, strSize.Height)
		container.Graphics.DrawString(row(6), drawFont, drawBrush2, New Point(dblDateXStart, dblDatePositionY))

		'画像を保存
		Dim _format As RasterImageFormat = tempImage.OriginalFormat
		Dim _bitsPerPixel As Integer = tempImage.BitsPerPixel
		If Not System.IO.Directory.Exists(Me.txtOutputFolder.Text & "\" & row(0)) Then
			My.Computer.FileSystem.CreateDirectory(Me.txtOutputFolder.Text & "\" & row(0))
		End If
		codecs.Save(tempImage, Me.txtOutputFolder.Text & "\" & row(0) & "\" & System.IO.Path.GetFileName(strImageFile), _format, _bitsPerPixel)

	End Sub

#End Region
End Class
