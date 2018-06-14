Module CheckDigit

	''' <summary>
	''' モジュラス10ウェイト3にて計算したチェックデジット値を返す
	''' </summary>
	''' <param name="strNumber">チェックデジットを求める数値</param>
	''' <param name="iFormCategory">帳票種別ID</param>
	''' <param name="strReturn">参照型：チェックデジットの一桁の数値</param>
	''' <returns>TRUE：成功、FALSE：失敗</returns>
	'''	<remarks>
	'''		1.右から奇数桁に3をかけて加算
	'''		2.偶数桁を加算
	'''		3.(1)+(2)する
	'''		4.一桁目を10から引いた数値
	'''		5.一桁目が0の場合は0
	'''	</remarks>
	Public Function Modulus10(ByVal strNumber As String, ByVal iFormCategory As Integer, ByRef strReturn As String) As Boolean

		Dim iOddTotal As Integer = 0    '奇数桁の加算値
		Dim iEvenTotal As Integer = 0   '偶数桁の加算値

		'帳票種別によって枝分かれ
		Select Case iFormCategory
			Case 0
				'ラベル
				'11桁
				'文字列長チェック
				If Not strNumber.Length = 15 Then
					Return False
				End If

			Case 2, 3
				'対象者一覧、保健指導対象者名簿
				'15桁
				'文字列長チェック
				If Not strNumber.Length = 15 Then
					Return False
				End If

            Case 4
                '判定票
                '16桁
                '文字列長チェック
                If Not strNumber.Length = 17 Then
                    Return False
                End If
            Case 5
                'リーフレット
                '17桁
                '文字列長チェック
                If Not strNumber.Length = 18 Then
                    Return False
                End If
        End Select

		'末尾から奇数桁を3をかけながら加算していく
		For i As Integer = strNumber.Length To 1 Step -2

			iOddTotal += CInt(Strings.Mid(strNumber, i, 1)) * 3
			'加算した後に値が1以下だった場合For文を抜ける
			If i <= 1 Then
				Exit For
			End If
		Next
		'末尾の一つ前から偶数桁を加算していく
		For j As Integer = strNumber.Length - 1 To 1 Step -2

			iEvenTotal += CInt(Strings.Mid(strNumber, j, 1))
			'加算した後に値が1以下だった場合For文を抜ける
			If j <= 1 Then
				Exit For
			End If
		Next

		'最終桁を文字列化してひとけた目を取得し数値化して10を減算する
		'ひとけた目が0の場合は0を返す
		Dim iTotal As Integer = iOddTotal + iEvenTotal
		Dim iBeforeCD As Integer = CInt(Strings.Right(iTotal.ToString, 1))

		If iBeforeCD = 0 Then
			strReturn = "0"
		Else
			strReturn = (10 - iBeforeCD).ToString
		End If

		Return True

	End Function

End Module
