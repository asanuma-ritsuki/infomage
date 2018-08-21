''' <summary>
''' Microsoft.VisualBasic.Stringsをカバーした静的クラス
''' </summary>
Public Class VBStrings

	''' <summary>
	''' 文字列の左端から指定したバイト数分の文字列を返す
	''' </summary>
	''' <param name="strTarget">取り出す元になる文字列</param>
	''' <param name="iByte">取り出すバイト数</param>
	''' <returns>左端から指定されたバイト数分の文字列</returns>
	Public Shared Function LeftB(ByVal strTarget As String, ByVal iByte As Integer) As String

		Return MidB(strTarget, 1, iByte)

	End Function

	''' <summary>
	''' 文字列の指定されたバイト位置以降のすべての文字列を返す
	''' </summary>
	''' <param name="strTarget">取り出す元になる文字列</param>
	''' <param name="iStart">取り出しを開始する位置</param>
	''' <returns>指定されたバイト位置以降のすべての文字列</returns>
	Public Shared Function MidB(ByVal strTarget As String, ByVal iStart As Integer) As String

		Dim enc As System.Text.Encoding = System.Text.Encoding.GetEncoding("Shift-JIS")
		Dim bt As Byte() = enc.GetBytes(strTarget)

		Return enc.GetString(bt, iStart - 1, bt.Length - iStart + 1)

	End Function

	''' <summary>
	''' 文字列の指定されたバイト位置から、指定されたバイト数分の文字列を返す
	''' </summary>
	''' <param name="strTarget">取り出す元になる文字列</param>
	''' <param name="iStart">取り出しを開始する位置</param>
	''' <param name="iByte">取り出すバイト数</param>
	''' <returns></returns>
	Public Shared Function MidB(ByVal strTarget As String, ByVal iStart As Integer, iByte As Integer) As String

		Dim enc As System.Text.Encoding = System.Text.Encoding.GetEncoding("Shift-JIS")
		Dim bt As Byte() = enc.GetBytes(strTarget)

		Return enc.GetString(bt, iStart - 1, iByte)

	End Function

	''' <summary>
	''' 文字列の右端から指定されたバイト数分の文字列を返す
	''' </summary>
	''' <param name="strTarget">取り出す元になる文字列</param>
	''' <param name="iByte">取り出すバイト数</param>
	''' <returns>右端から指定されたバイト数分の文字列</returns>
	Public Shared Function RightB(ByVal strTarget As String, ByVal iByte As Integer) As String

		Dim enc As System.Text.Encoding = System.Text.Encoding.GetEncoding("Shift-JIS")
		Dim bt As Byte() = enc.GetBytes(strTarget)

		Return enc.GetString(bt, bt.Length - iByte, iByte)

	End Function

	''' <summary>
	''' 文字列のバイト数を返す(Shift-JISのみ)
	''' </summary>
	''' <param name="str"></param>
	''' <returns></returns>
	Public Shared Function LenB(ByVal str As String) As Integer
		'Shift-JISに変換したときに必要なバイト数を返す
		Return System.Text.Encoding.GetEncoding("Shift-JIS").GetByteCount(str)
	End Function

	''' <summary>
	''' 全角文字の１バイト目かどうか判定する
	''' </summary>
	''' <param name="arr">Shift-JIS文字列のByte配列</param>
	''' <param name="number">判定するバイト位置(先頭は0)</param>
	''' <returns>TRUE：全角の１文字目、FALSE：全角の１文字目ではない</returns>
	Public Shared Function CheckFullFront(ByVal arr As Byte(), ByVal number As Integer) As Boolean

		Dim errMessage As String = "指定されたバイト数が文字列のバイト数を超えているか、あるいは０未満です"
		Dim blnFull As Boolean = False  '全角の１文字目かどうか
		Dim iPoint As Integer   '現在見ている文字列(配列)の位置

		'配列よりnumberのほうが長いか0以下の場合
		If number < 0 OrElse arr.Length <= number Then
			Throw New ArgumentOutOfRangeException("number", errMessage)
		End If

		For iPoint = 0 To number
			If blnFull Then
				blnFull = False
			Else
				If (arr(iPoint) >= &H80 And arr(iPoint) <= &H9F) Or
						(arr(iPoint) >= &HE0 And arr(iPoint) <= &HFF) Then
					blnFull = True
				End If
			End If
		Next

		Return blnFull

	End Function

	''' <summary>
	''' ある文字の先頭から指定されたバイト数分以降の文字を切り捨てる
	''' </summary>
	''' <param name="strTarget"></param>
	''' <param name="iByte"></param>
	''' <returns>全角半角を考慮し、切り出すバイトの最後のバイトが全角の1バイト目だった場合文字化けを起こすので切り捨てる</returns>
	Public Shared Function TruncString(ByVal strTarget As String, ByVal iByte As Integer) As String
		'このメソッドに来る文字列はiByteの文字数を超えていることが前提
		Dim enc As System.Text.Encoding = System.Text.Encoding.GetEncoding("Shift-JIS")
		Dim byteTarget As Byte() = enc.GetBytes(strTarget)
		Dim strReturn As String = ""
		If CheckFullFront(byteTarget, iByte - 1) Then
			'1バイト目
			'最終バイトがいらないため、削ってから再度文字列に戻す
			strReturn = LeftB(strTarget, iByte - 1)
		Else
			'2バイト目
			'そのまま切り出す
			strReturn = LeftB(strTarget, iByte)
		End If

		Return strReturn

	End Function

End Class
