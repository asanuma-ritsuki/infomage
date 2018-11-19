Public Class Form1
	Private Sub btnRun_Click(sender As Object, e As EventArgs) Handles btnRun.Click

		Dim bytesData As Byte()
		Dim str As String = Me.txtTarget.Text
		'文字をシフトJISとしてバイト型配列に格納する
		bytesData = System.Text.Encoding.GetEncoding("Shift-JIS").GetBytes(str)

		'バイト型配列を16進数に変換して結合
		Dim strHex As String = ""
		For i = 0 To bytesData.Length - 1
			strHex &= bytesData(i).ToString("X")    '10進数を16進数表記
		Next
		Me.txt16Code.Text = strHex

		'結合した16進数を10進数に戻す
		Dim iDec As Integer = Convert.ToInt32(strHex, 16)
		Me.txt10Code.Text = iDec

		'第1水準の範囲(33088～39026)
		If iDec >= 33088 And iDec <= 39026 Then
			Me.txtResult.Text = "第1水準"
		ElseIf iDec >= 39071 And iDec <= 60068 Then
			Me.txtResult.Text = "第2水準"
		Else
			Me.txtResult.Text = "範囲外"
		End If

	End Sub

	Private Sub RichTextBox1_LinkClicked(sender As Object, e As LinkClickedEventArgs) Handles RichTextBox1.LinkClicked
		'クリックされたリンクをWebブラウザで開く
		System.Diagnostics.Process.Start(e.LinkText)
	End Sub
End Class
