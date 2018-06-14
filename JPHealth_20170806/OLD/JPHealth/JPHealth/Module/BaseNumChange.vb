Module BaseNumChange

	''' <summary>
	''' 16進数の文字列を整数に変換
	''' </summary>
	''' <param name="Hex"></param>
	''' <returns></returns>
	Public Function HexToDec(ByVal Hex As String) As Integer

		Dim Dec As Integer

		'ConvertクラスのToInt32メソッド
		Dec = Convert.ToInt32(Hex, 16)
		Return Dec

	End Function

	''' <summary>
	''' 整数を16進数の文字列に変換
	''' </summary>
	''' <param name="Dec"></param>
	''' <returns></returns>
	Public Function DecToHex(ByVal Dec As Integer) As String

		Dim Hex As String

		'ConvertクラスのToStringメソッド
		Hex = Convert.ToString(Dec, 16)
		Return Hex

	End Function

	''' <summary>
	''' 8進数の文字列を整数に変換
	''' </summary>
	''' <param name="Oct"></param>
	''' <returns></returns>
	Public Function OctToDec(ByVal Oct As String) As Integer

		Dim Dec As Integer

		'ConvertクラスのToInt32メソッド
		Dec = Convert.ToInt32(Oct, 8)
		Return Dec

	End Function

	''' <summary>
	''' 整数を8進数の文字列に変換
	''' </summary>
	''' <param name="Dec"></param>
	''' <returns></returns>
	Public Function DecToOct(ByVal Dec As Integer) As String

		Dim Oct As String

		'ConvertクラスのToStringメソッド
		Oct = Convert.ToString(Dec, 8)
		Return Oct

	End Function

	''' <summary>
	''' 2進数の文字列を整数に変換
	''' </summary>
	''' <param name="Bin"></param>
	''' <returns></returns>
	Public Function BinToDec(ByVal Bin As String) As Integer

		Dim Dec As Integer

		'ConvertクラスのToInt32メソッド
		Dec = Convert.ToInt32(Bin, 2)
		Return Dec

	End Function

	''' <summary>
	''' 整数を2進数の文字列に変換
	''' </summary>
	''' <param name="Dec"></param>
	''' <returns></returns>
	Public Function DecToBin(ByVal Dec As Integer) As String

		Dim Bin As String

		'ConvertクラスのToStringメソッド
		Bin = Convert.ToString(Dec, 2)
		Bin = Bin.PadLeft(6, "0")   '6桁で揃える

		Return Bin

	End Function

End Module
