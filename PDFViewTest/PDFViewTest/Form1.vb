Public Class Form1

	Dim strFileName As String = ""
	Dim iPage As Integer = 1

	Private Sub btnMove_Click(sender As Object, e As EventArgs) Handles btnMove.Click

		Try

			Me.iPage = Convert.ToInt32(txtPage.Text)
			viewPage()

		Catch ex As Exception

		End Try
	End Sub

	Private Sub PdfView(ByVal strFileName As String)

		Me.WebBrowser1.AllowWebBrowserDrop = False
		Me.WebBrowser1.IsWebBrowserContextMenuEnabled = False
		Me.WebBrowser1.WebBrowserShortcutsEnabled = False

		Me.strFileName = strFileName
		viewPage()

	End Sub

	Private Sub viewPage()

		Me.WebBrowser1.Url = New Uri(Me.strFileName + "#toolbar=0&navpanes=0&view=FitH&scrollbar=1&page=" + Me.strFileName)
		Me.WebBrowser1.Refresh()

	End Sub

End Class
