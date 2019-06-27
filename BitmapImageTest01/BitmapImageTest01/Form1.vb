Imports System.Windows.Media.Imaging

Public Class Form1

	Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

	End Sub

	Private Sub test()
		Dim newImage As Image = Nothing

		'画像ソース
		Dim src As New BitmapImage()
		src.BeginInit()
		src.UriSource = New Uri("\\intra-pdc01\20181101_181041002_警視庁\01_image\03_panasonic\0125\0125_0001_0001_0001_F.jpg", UriKind.Absolute)
		'サムネイル作成
		src.DecodePixelWidth = 200
		src.CacheOption = BitmapCacheOption.OnLoad

		src.EndInit()
		'Me.PictureBox1.Image = src
		Me.ElementHost1.BackgroundImage. = src

	End Sub

	Public Function GetFilesMostDeep(ByVal strRootPath As String, ByVal strPatterns() As String) As String()

		Dim hStringCollection As New System.Collections.Specialized.StringCollection()

		'このディレクトリ内のすべてのファイルを検索する
		For Each strFilePath As String In System.IO.Directory.GetFiles(strRootPath, "*")
			For Each strPattern As String In strPatterns

				If "*" & System.IO.Path.GetExtension(strFilePath) = strPattern Then
					hStringCollection.Add(strFilePath)
				End If
			Next

		Next strFilePath

		'このディレクトリ内のすべてのサブディレクトリを検索する(再帰)
		For Each strDirPath As String In System.IO.Directory.GetDirectories(strRootPath)
			Dim strFilePathes As String() = GetFilesMostDeep(strDirPath, strPatterns)

			'条件に合致したファイルがあった場合は、ArrayListに加える
			If Not strFilePathes Is Nothing Then
				hStringCollection.AddRange(strFilePathes)
			End If
		Next strDirPath

		'StringCollectionを1次元のString配列にして返す
		Dim strReturns As String() = New String(hStringCollection.Count - 1) {}
		hStringCollection.CopyTo(strReturns, 0)

		Return strReturns

	End Function

End Class
