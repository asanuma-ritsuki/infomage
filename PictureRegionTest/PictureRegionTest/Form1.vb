Public Class Form1

	Private f2 As Form2
	'下記ドラッグ中の赤枠の表示のコードは、マウスのドラッグで範囲を選択し画像を取得して
	'他のピクチャーボックスに表示
	Private sPos As MouseEventArgs  'マウスのドラッグ開始点
	Private ePos As MouseEventArgs  'マウスのドラッグ終了点
	Private oPos As MouseEventArgs  '前回のマウス位置

	Private Sub PictureBox1_MouseDown(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseDown

		If e.Button = System.Windows.Forms.MouseButtons.Left Then
			If Not (f2 Is Nothing) Then
				f2.Close()
			End If
			'開始店の取得
			sPos = e
			ePos = e
			oPos = e
		End If
	End Sub

	Private Sub PictureBox1_MouseMove(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseMove
		'マウスのドラッグで線を引く
		If e.Button = System.Windows.Forms.MouseButtons.Left Then
			Using g As Graphics = PictureBox1.CreateGraphics()
				Using BPen As New Pen(Color.Red, 1)
					BPen.DashStyle = Drawing2D.DashStyle.Solid
					If (oPos.X <> e.X) Or (oPos.Y <> e.Y) Then
						Dim nLoca As New Point
						Dim nSize As New Size
						'Location Pointを返還(どの方向から描画しても表示できるように)
						If sPos.X <= e.X Then
							nLoca.X = sPos.X
						Else
							nLoca.X = e.X
						End If
						If sPos.Y <= e.Y Then
							nLoca.Y = sPos.Y
						Else
							nLoca.Y = e.Y
						End If
						nSize = New Size(Math.Abs(e.X - sPos.X), Math.Abs(e.Y - sPos.Y))

						'赤枠を描画する代わりにForm2を表示する
						'PictureBox1のスクリーン座標を求める
						Dim Cpos As Point = PictureBox1.ClientRectangle.Location
						Dim SCpos As Point = PictureBox1.PointToScreen(Cpos)
						'f2が複数起動されないようにする
						If f2 Is Nothing OrElse f2.IsDisposed Then
							'f2 = New myShape1
							f2 = New Form2
						End If
						f2.FormBorderStyle = Windows.Forms.FormBorderStyle.None
						f2.ShowInTaskbar = False
						f2.Show()
						'f2を表示してから位置とサイズを指定のこと
						f2.Location = New Point(SCpos.X + nLoca.X, SCpos.Y + nLoca.Y)
						f2.Size = nSize

						ePos = e
						oPos = e
					End If
				End Using
			End Using
		End If
	End Sub

	Private Sub Form1_Move(sender As Object, e As EventArgs) Handles MyBase.Move
		'Form1が移動された場合、f2を閉じる
		If Not (f2 Is Nothing) Then
			f2.Close()
		End If
	End Sub

End Class
