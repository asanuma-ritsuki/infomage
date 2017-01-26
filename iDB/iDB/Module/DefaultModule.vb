Imports System.Text

<System.Diagnostics.DebuggerStepThrough()>
Module DefaultModule

	''' <summary>
	''' NULL判定
	''' </summary>
	''' <param name="text"></param>
	''' <returns></returns>
	Public Function IsNull(ByVal text As String) As Boolean
		'Nothing判定
		If IsNothing(text) Then
			Return True
		End If
		'空文字判定
		If text Is String.Empty Then
			Return True
		End If
		'""文字判定
		If text.Trim = "" Then
			Return True
		End If

		'何も引っかからなかったら
		Return False

	End Function

	''' <summary>
	''' 例外処理内容をログファイルに書き込む
	''' </summary>
	''' <param name="strExceptionMessage"></param>
	Public Sub OutputLogFile(ByVal strExceptionMessage As String)

		Dim strLogFile As String = Application.StartupPath & "\ExceptionLog\Exception.log"
		Dim strLogFolder As String = System.IO.Path.GetDirectoryName(strLogFile)
		Dim sw As System.IO.StreamWriter

		If Not System.IO.Directory.Exists(strLogFolder) Then
			System.IO.Directory.CreateDirectory(strLogFolder)
		End If

		sw = New System.IO.StreamWriter(strLogFile, True, System.Text.Encoding.GetEncoding("Shift-JIS"))

		sw.WriteLine("[ " & Date.Now & " ]")
		sw.WriteLine(strExceptionMessage)
		sw.Close()

	End Sub

End Module
