Module modulus
    ''' <summary>
    ''' モジュラス11(ウェイト2-8)
    ''' </summary>
    ''' <param name="strNumber"></param>
    ''' <param name="strReturn"></param>
    ''' <returns></returns>
    Public Function Modulus11(ByVal strNumber As String, ByRef strReturn As String) As Boolean

        '11桁に満たない場合
        If strNumber.Length < 11 Then
            Return False
        End If

        Dim prodNumTotal As Integer = 0

        '1桁ずつウェイトを掛ける
        For i As Integer = 0 To 10
            Dim modNumber As Integer = i Mod 8 + 2
            Dim Num As Integer = CInt(strNumber.Substring(strNumber.Length - (i + 1), 1))

            Dim prodNum As Integer = Num * modNumber
            prodNumTotal += prodNum
        Next

        '11で割ったあまりに対して以下の計算を行う
        Dim CheckDegit As Integer = prodNumTotal Mod 11
        If CheckDegit = 0 Then
            strReturn = 1
        ElseIf CheckDegit = 1 Then
            strReturn = 0
        Else
            strReturn = 11 - CheckDegit
        End If

        Return True

    End Function

End Module
