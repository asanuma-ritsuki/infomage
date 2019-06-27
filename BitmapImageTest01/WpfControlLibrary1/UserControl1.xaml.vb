Public Class UserControl1

	Public Sub SetSource(ByVal fileName As String)
		img.Source = New BitmapImage(New Uri(fileName))
	End Sub

End Class
