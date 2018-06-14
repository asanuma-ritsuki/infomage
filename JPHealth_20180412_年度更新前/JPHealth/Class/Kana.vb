'
' * kanaxs VB.NET 1.0.0
' * Copyright (c) 2011, DOBON! <http://dobon.net>
' * All rights reserved.
' * 
' * New BSD License（修正BSDライセンス）
' * http://wiki.dobon.net/index.php?free%2FkanaxsVB.NET%2Flicense
' * 
' * このクラスは、以下のライブラリを参考にして作成しました。
' * kanaxs Kana.JS (kana-1.0.5.js)
' * Copyright (c) shogo4405 <shogo4405 at gmail.com>
' * http://code.google.com/p/kanaxs/
'

Imports System
Imports Microsoft.VisualBasic

Namespace VisualBasic.Japanese.Kanaxs
	''' <summary>
	''' ひらがなとカタカナ、半角と全角の文字変換を行うメソッドを提供します。
	''' </summary>
	Public NotInheritable Class Kana
		Private Sub New()
		End Sub

		''' <summary>
		''' 全角カタカナを全角ひらがなに変換します。
		''' </summary>
		''' <param name="str">変換する String。</param>
		''' <returns>変換された String。</returns>
		Public Shared Function ToHiragana(ByVal str As String) As String
			If str Is Nothing OrElse str.Length = 0 Then
				Return str
			End If

			Dim cs As Char() = str.ToCharArray()
			Dim f As Integer = cs.Length

			Dim i As Integer
			For i = 0 To f - 1
				Dim c As Char = cs(i)
				' ァ(0x30A1) ～ ヶ(0x30F6)
				If "ァ"c <= c AndAlso c <= "ヶ"c Then
					cs(i) = ChrW(AscW(c) - &H60)
				End If
			Next

			Return New String(cs)
		End Function

		''' <summary>
		''' 全角ひらがなを全角カタカナに変換します。
		''' </summary>
		''' <param name="str">変換する String。</param>
		''' <returns>変換された String。</returns>
		Public Shared Function ToKatakana(ByVal str As String) As String
			If str Is Nothing OrElse str.Length = 0 Then
				Return str
			End If

			Dim cs As Char() = str.ToCharArray()
			Dim f As Integer = cs.Length

			Dim i As Integer
			For i = 0 To f - 1
				Dim c As Char = cs(i)
				' ぁ(0x3041) ～ ゖ(0x3096)
				If "ぁ"c <= c AndAlso c <= "ゖ"c Then
					cs(i) = ChrW(AscW(c) + &H60)
				End If
			Next

			Return New String(cs)
		End Function

		''' <summary>
		''' 全角英数字および記号を半角に変換します。
		''' </summary>
		''' <param name="str">変換する String。</param>
		''' <returns>変換された String。</returns>
		Public Shared Function ToHankaku(ByVal str As String) As String
			If str Is Nothing OrElse str.Length = 0 Then
				Return str
			End If

			Dim cs As Char() = str.ToCharArray()
			Dim f As Integer = cs.Length

			Dim i As Integer
			For i = 0 To f - 1
				Dim c As Char = cs(i)
				' ！(0xFF01) ～ ～(0xFF5E)
				If "！"c <= c AndAlso c <= "～"c Then
					cs(i) = ChrW(AscW(c) - &HFEE0)
					' 全角スペース(0x3000) -> 半角スペース(0x0020)
				ElseIf c = "　"c Then
					cs(i) = " "c
				End If
			Next

			Return New String(cs)
		End Function

		''' <summary>
		''' 半角英数字および記号を全角に変換します。
		''' </summary>
		''' <param name="str">変換する String。</param>
		''' <returns>変換された String。</returns>
		Public Shared Function ToZenkaku(ByVal str As String) As String
			If str Is Nothing OrElse str.Length = 0 Then
				Return str
			End If

			Dim cs As Char() = str.ToCharArray()
			Dim f As Integer = cs.Length

			Dim i As Integer
			For i = 0 To f - 1
				Dim c As Char = cs(i)
				' !(0x0021) ～ ~(0x007E)
				If "!"c <= c AndAlso c <= "~"c Then
					cs(i) = ChrW(AscW(c) + &HFEE0)
					' 半角スペース(0x0020) -> 全角スペース(0x3000)
				ElseIf c = " "c Then
					cs(i) = "　"c
				End If
			Next

			Return New String(cs)
		End Function

		''' <summary>
		''' 「は゛」を「ば」のように、濁点や半濁点を前の文字と合わせて1つの文字に変換します。
		''' </summary>
		''' <param name="str">変換する String。</param>
		''' <returns>変換された String。</returns>
		Public Shared Function ToPadding(ByVal str As String) As String
			If str Is Nothing OrElse str.Length = 0 Then
				Return str
			End If

			Dim cs As Char() = New Char(str.Length - 1) {}
			Dim pos As Integer = str.Length - 1

			Dim f As Integer = str.Length - 1

			Dim i As Integer
			For i = f To 0 Step -1
				Dim c As Char = str.Chars(i)

				' ゛(0x309B) 濁点
				If c = "゛"c AndAlso 0 < i Then
					Dim c2 As Char = str.Chars(i - 1)
					Dim mod2 As Integer = AscW(c2) Mod 2
					Dim mod3 As Integer = AscW(c2) Mod 3

					' か(0x304B) ～ ぢ(0x3062)
					' カ(0x30AB) ～ ヂ(0x30C2)
					' つ(0x3064) ～ ど(0x3069)
					' ツ(0x30C4) ～ ド(0x30C9)
					' は(0x306F) ～ ぽ(0x307D)
					' ハ(0x30CF) ～ ポ(0x30DD)
					If ("か"c <= c2 AndAlso c2 <= "ぢ"c AndAlso mod2 = 1) OrElse
						("カ"c <= c2 AndAlso c2 <= "ヂ"c AndAlso mod2 = 1) OrElse
						("つ"c <= c2 AndAlso c2 <= "ど"c AndAlso mod2 = 0) OrElse
						("ツ"c <= c2 AndAlso c2 <= "ド"c AndAlso mod2 = 0) OrElse
						("は"c <= c2 AndAlso c2 <= "ぽ"c AndAlso mod3 = 0) OrElse
						("ハ"c <= c2 AndAlso c2 <= "ポ"c AndAlso mod3 = 0) Then
						cs(pos) = ChrW(AscW(c2) + 1)
						pos -= 1
						i -= 1
					Else
						cs(pos) = c
						pos -= 1
					End If
					' ゜(0x309C) 半濁点
				ElseIf c = "゜"c AndAlso 0 < i Then
					Dim c2 As Char = str.Chars(i - 1)
					Dim mod3 As Integer = AscW(c2) Mod 3

					' は(0x306F) ～ ぽ(0x307D)
					' ハ(0x30CF) ～ ポ(0x30DD)
					If ("は"c <= c2 AndAlso c2 <= "ぽ"c AndAlso mod3 = 0) OrElse
						("ハ"c <= c2 AndAlso c2 <= "ポ"c AndAlso mod3 = 0) Then
						cs(pos) = ChrW(AscW(c2) + 2)
						pos -= 1
						i -= 1
					Else
						cs(pos) = c
						pos -= 1
					End If
				Else
					cs(pos) = c
					pos -= 1
				End If
			Next

			Return New String(cs, pos + 1, cs.Length - pos - 1)
		End Function

		''' <summary>
		''' 全角カタカナを半角カタカナに変換します。
		''' </summary>
		''' <param name="str">変換する String。</param>
		''' <returns>変換された String。</returns>
		Public Shared Function ToHankakuKana(ByVal str As String) As String
			If str Is Nothing OrElse str.Length = 0 Then
				Return str
			End If

			Dim cs As Char() = New Char(str.Length * 2 - 1) {}
			Dim len As Integer = 0

			Dim f As Integer = str.Length

			Dim i As Integer
			For i = 0 To f - 1
				Dim c As Char = str.Chars(i)
				' ァ(0x30A1) ～ ー(0x30FC)
				If "ァ"c <= c AndAlso c <= "ー"c Then
					Dim m As Char = ConvertToHankakuKanaChar(c)
					If m <> ControlChars.NullChar Then
						cs(len) = m
						len += 1
						' カ(0x30AB) ～ ド(0x30C9)
					ElseIf "カ"c <= c AndAlso c <= "ド"c Then
						cs(len) = ConvertToHankakuKanaChar(ChrW(AscW(c) - 1))
						len += 1
						cs(len) = "ﾞ"c
						len += 1
						' ハ(0x30CF) ～ ポ(0x30DD)
					ElseIf "ハ"c <= c AndAlso c <= "ポ"c Then
						Dim mod3 As Integer = AscW(c) Mod 3
						cs(len) = ConvertToHankakuKanaChar(ChrW(AscW(c) - mod3))
						len += 1
						If mod3 = 1 Then
							cs(len) = "ﾞ"c
						Else
							cs(len) = "ﾟ"c
						End If
						len += 1
					Else
						cs(len) = c
						len += 1
					End If
				Else
					cs(len) = c
					len += 1
				End If
			Next

			Return New String(cs, 0, len)
		End Function

		''' <summary>
		''' 半角カタカナを全角カタカナに変換します。
		''' </summary>
		''' <param name="str">変換する String。</param>
		''' <returns>変換された String。</returns>
		Public Shared Function ToZenkakuKana(ByVal str As String) As String
			If str Is Nothing OrElse str.Length = 0 Then
				Return str
			End If

			Dim cs As Char() = str.ToCharArray()
			Dim f As Integer = str.Length

			Dim i As Integer
			For i = 0 To f - 1
				Dim c As Char = cs(i)
				' ｦ(0xFF66) ～ ﾟ(0xFF9F)
				If "ｦ"c <= c AndAlso c <= "ﾟ"c Then
					Dim m As Char = ConvertToZenkakuKanaChar(c)
					If m <> ControlChars.NullChar Then
						cs(i) = m
					End If
				End If
			Next

			Return New String(cs)
		End Function

		Private Shared Function ConvertToHankakuKanaChar(ByVal zenkakuChar As Char) As Char
			Select Case zenkakuChar
				Case "ァ"c
					Return "ｧ"c
				Case "ィ"c
					Return "ｨ"c
				Case "ゥ"c
					Return "ｩ"c
				Case "ェ"c
					Return "ｪ"c
				Case "ォ"c
					Return "ｫ"c
				Case "ー"c
					Return "ｰ"c
				Case "ア"c
					Return "ｱ"c
				Case "イ"c
					Return "ｲ"c
				Case "ウ"c
					Return "ｳ"c
				Case "エ"c
					Return "ｴ"c
				Case "オ"c
					Return "ｵ"c
				Case "カ"c
					Return "ｶ"c
				Case "キ"c
					Return "ｷ"c
				Case "ク"c
					Return "ｸ"c
				Case "ケ"c
					Return "ｹ"c
				Case "コ"c
					Return "ｺ"c
				Case "サ"c
					Return "ｻ"c
				Case "シ"c
					Return "ｼ"c
				Case "ス"c
					Return "ｽ"c
				Case "セ"c
					Return "ｾ"c
				Case "ソ"c
					Return "ｿ"c
				Case "タ"c
					Return "ﾀ"c
				Case "チ"c
					Return "ﾁ"c
				Case "ツ"c
					Return "ﾂ"c
				Case "テ"c
					Return "ﾃ"c
				Case "ト"c
					Return "ﾄ"c
				Case "ナ"c
					Return "ﾅ"c
				Case "ニ"c
					Return "ﾆ"c
				Case "ヌ"c
					Return "ﾇ"c
				Case "ネ"c
					Return "ﾈ"c
				Case "ノ"c
					Return "ﾉ"c
				Case "ハ"c
					Return "ﾊ"c
				Case "ヒ"c
					Return "ﾋ"c
				Case "フ"c
					Return "ﾌ"c
				Case "ヘ"c
					Return "ﾍ"c
				Case "ホ"c
					Return "ﾎ"c
				Case "マ"c
					Return "ﾏ"c
				Case "ミ"c
					Return "ﾐ"c
				Case "ム"c
					Return "ﾑ"c
				Case "メ"c
					Return "ﾒ"c
				Case "モ"c
					Return "ﾓ"c
				Case "ヤ"c
					Return "ﾔ"c
				Case "ユ"c
					Return "ﾕ"c
				Case "ヨ"c
					Return "ﾖ"c
				Case "ラ"c
					Return "ﾗ"c
				Case "リ"c
					Return "ﾘ"c
				Case "ル"c
					Return "ﾙ"c
				Case "レ"c
					Return "ﾚ"c
				Case "ロ"c
					Return "ﾛ"c
				Case "ワ"c
					Return "ﾜ"c
				Case "ヲ"c
					Return "ｦ"c
				Case "ン"c
					Return "ﾝ"c
				Case "ッ"c
					Return "ｯ"c

					'ャュョ を追加
				Case "ャ"c
					Return "ｬ"c
				Case "ュ"c
					Return "ｭ"c
				Case "ョ"c
					Return "ｮ"c

				Case Else
					Return ControlChars.NullChar
			End Select
		End Function

		Private Shared Function ConvertToZenkakuKanaChar(ByVal hankakuChar As Char) As Char
			Select Case hankakuChar
				Case "ｦ"c
					Return "ヲ"c
				Case "ｧ"c
					Return "ァ"c
				Case "ｨ"c
					Return "ィ"c
				Case "ｩ"c
					Return "ゥ"c
				Case "ｪ"c
					Return "ェ"c
				Case "ｫ"c
					Return "ォ"c
				Case "ｰ"c
					Return "ー"c
				Case "ｱ"c
					Return "ア"c
				Case "ｲ"c
					Return "イ"c
				Case "ｳ"c
					Return "ウ"c
				Case "ｴ"c
					Return "エ"c
				Case "ｵ"c
					Return "オ"c
				Case "ｶ"c
					Return "カ"c
				Case "ｷ"c
					Return "キ"c
				Case "ｸ"c
					Return "ク"c
				Case "ｹ"c
					Return "ケ"c
				Case "ｺ"c
					Return "コ"c
				Case "ｻ"c
					Return "サ"c
				Case "ｼ"c
					Return "シ"c
				Case "ｽ"c
					Return "ス"c
				Case "ｾ"c
					Return "セ"c
				Case "ｿ"c
					Return "ソ"c
				Case "ﾀ"c
					Return "タ"c
				Case "ﾁ"c
					Return "チ"c
				Case "ﾂ"c
					Return "ツ"c
				Case "ﾃ"c
					Return "テ"c
				Case "ﾄ"c
					Return "ト"c
				Case "ﾅ"c
					Return "ナ"c
				Case "ﾆ"c
					Return "ニ"c
				Case "ﾇ"c
					Return "ヌ"c
				Case "ﾈ"c
					Return "ネ"c
				Case "ﾉ"c
					Return "ノ"c
				Case "ﾊ"c
					Return "ハ"c
				Case "ﾋ"c
					Return "ヒ"c
				Case "ﾌ"c
					Return "フ"c
				Case "ﾍ"c
					Return "ヘ"c
				Case "ﾎ"c
					Return "ホ"c
				Case "ﾏ"c
					Return "マ"c
				Case "ﾐ"c
					Return "ミ"c
				Case "ﾑ"c
					Return "ム"c
				Case "ﾒ"c
					Return "メ"c
				Case "ﾓ"c
					Return "モ"c
				Case "ﾔ"c
					Return "ヤ"c
				Case "ﾕ"c
					Return "ユ"c
				Case "ﾖ"c
					Return "ヨ"c
				Case "ﾗ"c
					Return "ラ"c
				Case "ﾘ"c
					Return "リ"c
				Case "ﾙ"c
					Return "ル"c
				Case "ﾚ"c
					Return "レ"c
				Case "ﾛ"c
					Return "ロ"c
				Case "ﾜ"c
					Return "ワ"c
				Case "ﾝ"c
					Return "ン"c
				Case "ﾞ"c
					Return "゛"c
				Case "ﾟ"c
					Return "゜"c

					' ｬｭｮｯ を追加
				Case "ｬ"c
					Return "ャ"c
				Case "ｭ"c
					Return "ュ"c
				Case "ｮ"c
					Return "ョ"c
				Case "ｯ"c
					Return "ッ"c

				Case Else
					Return ControlChars.NullChar
			End Select
		End Function
	End Class
End Namespace