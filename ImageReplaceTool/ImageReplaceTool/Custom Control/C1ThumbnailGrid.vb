Imports System.IO
Imports Leadtools
Imports Leadtools.Codecs
Imports Leadtools.WinForms
Imports Leadtools.Drawing
Imports Leadtools.ImageProcessing

Public Class C1ThumbnailGrid

	Private codecs As RasterCodecs

	Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
		MyBase.OnPaint(e)

		'カスタム描画コードをここに追加します。
	End Sub

#Region "インスタンス"

	Public Sub New()

		' この呼び出しはデザイナーで必要です。
		InitializeComponent()

		' InitializeComponent() 呼び出しの後で初期化を追加します。
		'RasterCodecsの初期化
		'入出力ライブラリの起動に必要なデータを初期化する
		codecs = New RasterCodecs

		Me.Rows.Count = 2
		Me.Cols.Count = 0
		Me.Rows(1).Height = 120

	End Sub

#End Region

#Region "パブリックメソッド"

	''' <summary>
	''' 対象フォルダから該当拡張子の画像ファイルをサムネイル表示する
	''' </summary>
	''' <param name="strFullPath"></param>
	''' <param name="strPatterns"></param>
	''' <param name="blnTopLevelOnly"></param>
	Public Async Sub ViewThumbs(ByVal strFullPath As String, ByVal strPatterns() As String, ByVal blnTopLevelOnly As Boolean)

		Dim strFiles As String() = GetFilesMostDeep(strFullPath, strPatterns, blnTopLevelOnly)

		Dim iCol As Integer = 0
		Dim img As Image = Nothing
		Dim thumbs As Image = Nothing

		'LEADTOOLS17.5のライセンスキー組み込み
		RasterSupport.SetLicense(Application.StartupPath & "\LEAD175ImgSuite.lic", "+sxwXvpT1JbgbQ7DAdF9k8WRWcBnLgwIjN2a3sVpuzOIoMTYIWPT13qYg3qhCnFE")
		RasterSupport.SetLicense(Application.StartupPath & "\LEAD175PDFRead.lic", "GL/iTglRN/ENEQvqOhAf1Z9QTPE2TPnSKBIV46X+rLrYLjpOwntMtnq5nDOWh+skhCe196Z5xK/6f/eatnC7zYlWLKBkYEdBuTw3Kd5JE66jNVn08HpvVdJjz9YAT+77V8P70s5whFv4rFKlzZ/zN3CUmyNeEpoav9oOfSTE2s4heejvh/VZ3BMI8dnR4SRdHumqwebWJSeee9zhTWmU1ubSjEjJSG/HHgfAExQHiKUc5SiwTe2MMBCDdagF3yz10sD8WhkQ/PiIAh5cD+GSUmXHdY3VgW/I6LlwY8vXQfqH/a8a9+79ite7Hye71P6Aqmw3fYX4jJgHioqMxatL2A8NJz5rPzgqPBc817V1qZ8AcaM/LIWnGPHGVqBeIgCjydQlvEjknm9i2Jny83+T3ETq2Sg5YBY1P8+3ccQcY+Xae/KdK6/L7EoYFeq3NAf6mHLN3rK5zOT7uBfHTfVNJQ==")

		'ファイル数分カラムを作成する
		Me.Cols.Count = strFiles.Length

		For Each strFile As String In strFiles

			Await Task.Run(Sub()
							   If System.IO.Path.GetExtension(strFile) = ".pdf" Then
								   Dim tempImage As RasterImage = codecs.Load(strFile, 0, CodecsLoadByteOrder.BgrOrGray, 1, 1)
								   img = RasterImageConverter.ConvertToImage(tempImage, ConvertToImageOptions.None)
							   Else
								   Using fs As FileStream = File.OpenRead(strFile)
									   '画像の読み込み
									   img = Image.FromStream(fs, False, False)
								   End Using
							   End If
							   'サムネイルの作成
							   thumbs = img.GetThumbnailImage(img.Width * 0.5, img.Height * 0.5, Nothing, IntPtr.Zero)
							   'thumbs = img.GetThumbnailImage(img.Width, img.Height, Nothing, IntPtr.Zero)
							   img.Dispose()
						   End Sub)
			'Me.Cols.Count = iCol + 1
			Me.Rows(0)(iCol) = Path.GetFileName(strFile)
			Me.SetCellImage(1, iCol, thumbs)
			iCol += 1
		Next

	End Sub

#End Region

#Region "プライベートメソッド"

	''' <summary>
	''' 指定した検索パターンに一致するファイルを最下層まで検索しすべて返す
	''' </summary>
	''' <param name="strRootPath"></param>
	''' <param name="strPatterns"></param>
	''' <returns></returns>
	Private Function GetFilesMostDeep(ByVal strRootPath As String, ByVal strPatterns() As String, Optional ByVal blnTopLevelOnly As Boolean = False) As String()

		Dim hStringCollection As New System.Collections.Specialized.StringCollection()

		'このディレクトリ内のすべてのファイルを検索する
		For Each strFilePath As String In System.IO.Directory.GetFiles(strRootPath, "*")
			For Each strPattern As String In strPatterns

				If "*" & System.IO.Path.GetExtension(strFilePath) = strPattern Then
					hStringCollection.Add(strFilePath)
				End If
			Next
		Next strFilePath

		If blnTopLevelOnly = False Then
			'最下層までファイルを取得する
			'このディレクトリ内のすべてのサブディレクトリを検索する(再帰)
			For Each strDirPath As String In System.IO.Directory.GetDirectories(strRootPath)
				Dim strFilePathes As String() = GetFilesMostDeep(strDirPath, strPatterns)

				'条件に合致したファイルが有った場合は、ArrayListに加える
				If Not strFilePathes Is Nothing Then
					hStringCollection.AddRange(strFilePathes)
				End If
			Next strDirPath
		End If

		'StringCollectionを1次元のString配列にして返す
		Dim strReturns As String() = New String(hStringCollection.Count - 1) {}
		hStringCollection.CopyTo(strReturns, 0)

		Return strReturns

	End Function

#End Region

End Class
