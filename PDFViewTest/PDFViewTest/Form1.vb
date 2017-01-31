Imports System.IO

Imports Apitron.PDF.Controls
Imports Apitron.PDF.Rasterizer
Imports Apitron.PDF.Rasterizer.Configuration
Imports Apitron.PDF.Rasterizer.Navigation
Imports Apitron.PDF.Rasterizer.Search

Public Class Form1

	Dim strFileName As String = "C:\開発\その他\機関リポジトリ\フェリス女学院大学\02_CiNiiデータ加工分\CD内容\AA11323958\img\11\KJ00005073204.pdf"
	Dim iPage As Integer = 5

	Private Sub btnMove_Click(sender As Object, e As EventArgs) Handles btnMove.Click

		Try

			Me.iPage = Convert.ToInt32(txtPage.Text)
			viewPage()

		Catch ex As Exception

		End Try
	End Sub

	Private Sub PdfView(ByVal strFileName As String)

		Me.WebBrowser1.AllowWebBrowserDrop = True
		Me.WebBrowser1.IsWebBrowserContextMenuEnabled = False
		Me.WebBrowser1.WebBrowserShortcutsEnabled = False

		Me.strFileName = strFileName
		viewPage()

	End Sub

	Private Sub viewPage()
		'Me.WebBrowser1.Url = Nothing
		'Me.WebBrowser1.Url = New Uri(Me.strFileName + "#toolbar=0&navpanes=0&view=FitH&scrollbar=1&page=" + iPage)
		'Me.WebBrowser1.Url = New Uri(Me.strFileName & "#page=5")
		Me.WebBrowser1.Navigate("about:blank")
		Me.WebBrowser1.Navigate(Me.strFileName & "#toolbar=0&navpanes=0&zoom=50&page=2")
		Me.WebBrowser1.Refresh()

	End Sub

	Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

		Me.WebBrowser1.AllowWebBrowserDrop = True
		Me.WebBrowser1.IsWebBrowserContextMenuEnabled = False
		Me.WebBrowser1.WebBrowserShortcutsEnabled = False

		'Me.strFileName = strFileName
		'viewPage()

	End Sub

	Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click

		Me.WebBrowser1.Navigate("about:blank")

	End Sub

	Private Sub PdfViewer1_DragEnter(sender As Object, e As DragEventArgs) Handles PdfViewer1.DragEnter

		'コントロール内にドラッグされた時実行される
		If e.Data.GetDataPresent(DataFormats.FileDrop) Then
			'ドラッグされたデータ形式を調べ、ファイルの時はコピーとする
			e.Effect = DragDropEffects.Copy
		Else
			'ファイル以外は受け付けない
			e.Effect = DragDropEffects.None
		End If

	End Sub

	Private Sub PdfViewer1_DragDrop(sender As Object, e As DragEventArgs) Handles PdfViewer1.DragDrop

		'コントロール内にドロップされた時実行される
		'ドロップされたファイル名を取得する
		Dim strFolders As String() = CType(e.Data.GetData(DataFormats.FileDrop, False), String())
		'第一要素をテキストボックスにセットする
		'CSVファイルのみ
		If System.IO.File.Exists(strFolders(0)) Then

			LoadFile(strFolders(0))

		End If

	End Sub

	Private Sub LoadFile(ByVal strFileName As String)

		Using fs As New FileStream(strFileName, FileMode.Open, FileAccess.Read)

			Dim doc As New Document(fs)

			'doc.Navigator.Navigated += New Apitron.PDF.Rasterizer.Navigation.NavigatedDelegate(AddressOf Navigator_Navigated)

			PdfViewer1.Document = doc

		End Using
	End Sub

	Private Sub Navigator_Navigated(sender As Object, eventArgs As Apitron.PDF.Rasterizer.Navigation.NavigatedEventArgs)

		Dim navigator As DocumentNavigator = TryCast(sender, DocumentNavigator)

		Console.WriteLine("Top level navigation occured " + navigator.CurrentIndex)

	End Sub

End Class
