Public Class Form2
	Private Sub Form2_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize

		If Me.Width > 2 And Me.Height > 2 Then
			'四角形と円形を描画のコードを流用
			Dim meRect As Rectangle = New Rectangle(New Point(2, 2), New Size(Me.Width - 4, Me.Height - 4))
			Dim bmp As Bitmap = New Bitmap(Me.Width, Me.Height)
			Using g As Graphics = Graphics.FromImage(bmp)
				'Formの外形に赤枠(四角形)を表示
				g.DrawRectangle(New Pen(Color.Red, 3), meRect)
			End Using
			Me.BackgroundImage = bmp
			'Formの背景色を透明に設定(コントロールの背景を透明にする)
			Me.TransparencyKey = ColorTranslator.FromWin32(Microsoft.VisualBasic.RGB(254, 254, 254))
			Me.BackColor = ColorTranslator.FromWin32(Microsoft.VisualBasic.RGB(254, 254, 254))
			Me.TopMost = True
		End If
	End Sub

	'複数のフォームの上下(Zオーダー)を保つ方法
	Private Declare Function GetForegroundWindow Lib "user32" () As IntPtr

	Protected Overrides Sub WndProc(ByRef m As Message)
		Select Case m.Msg
			Case &H6, &H1C
				Dim hActv As IntPtr = GetForegroundWindow()
				If hActv = Form1.Handle Or hActv = Me.Handle Then
					Me.TopMost = True
				Else
					Me.TopMost = False
				End If
			Case Else

		End Select
		MyBase.WndProc(m)
	End Sub

End Class