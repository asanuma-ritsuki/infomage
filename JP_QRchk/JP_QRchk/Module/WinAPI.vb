Imports System
Imports System.Text
Imports System.Runtime.InteropServices

Module WinAPI

    'iniファイルを読み込むAPI(String)(AUTO版)
    Public Declare Auto Function GetPrivateProfileString Lib "kernel32" _
    Alias "GetPrivateProfileString" ( _
    <MarshalAs(UnmanagedType.LPTStr)> ByVal lpAppName As String, _
    <MarshalAs(UnmanagedType.LPTStr)> ByVal lpKeyName As String, _
    <MarshalAs(UnmanagedType.LPTStr)> ByVal lpDefault As String, _
    <MarshalAs(UnmanagedType.LPTStr)> ByVal lpReturnedString As StringBuilder, _
    ByVal nSize As Integer, _
    <MarshalAs(UnmanagedType.LPTStr)> ByVal lpFileName As String) As Integer

    'iniファイルを読み込むAPI(Integer)
    Public Declare Auto Function GetPrivateProfileInt Lib "kernel32" _
        Alias "GetPrivateProfileInt" ( _
        <MarshalAs(UnmanagedType.LPTStr)> ByVal lpAppName As String, _
        <MarshalAs(UnmanagedType.LPTStr)> ByVal lpKeyName As String, _
        ByVal nDefault As Integer, _
        <MarshalAs(UnmanagedType.LPTStr)> ByVal lpFileName As String) As Integer

    'iniファイルを書き込むAPI
    Public Declare Auto Function WritePrivateProfileString Lib "kernel32" _
        Alias "WritePrivateProfileString" ( _
        <MarshalAs(UnmanagedType.LPTStr)> ByVal lpAppName As String, _
        <MarshalAs(UnmanagedType.LPTStr)> ByVal lpKeyName As String, _
        <MarshalAs(UnmanagedType.LPTStr)> ByVal lpString As String, _
        <MarshalAs(UnmanagedType.LPTStr)> ByVal lpFileName As String) As Integer

End Module
