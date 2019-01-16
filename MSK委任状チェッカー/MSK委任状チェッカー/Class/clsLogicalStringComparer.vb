Public Class clsLogicalStringComparer
    Implements System.Collections.IComparer
    Implements System.Collections.Generic.IComparer(Of String)

    <System.Runtime.InteropServices.DllImport("shlwapi.dll",
        CharSet:=System.Runtime.InteropServices.CharSet.Unicode,
        ExactSpelling:=True)>
    Private Shared Function StrCmpLogicalW(x As String, y As String) As Integer
    End Function

    Public Function Compare(x As String, y As String) As Integer _
        Implements System.Collections.Generic.IComparer(Of String).Compare
        Return StrCmpLogicalW(x, y)
    End Function

    Public Function Compare(x As Object, y As Object) As Integer _
        Implements System.Collections.IComparer.Compare
        Return Me.Compare(x.ToString(), y.ToString())
    End Function
End Class
