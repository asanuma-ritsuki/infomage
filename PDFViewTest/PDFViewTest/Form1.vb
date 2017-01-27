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

		Me.WebBrowser1.Url = Nothing

	End Sub
End Class
