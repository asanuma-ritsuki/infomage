﻿'------------------------------------------------------------------------------
' <auto-generated>
'     このコードはツールによって生成されました。
'     ランタイム バージョン:4.0.30319.42000
'
'     このファイルへの変更は、以下の状況下で不正な動作の原因になったり、
'     コードが再生成されるときに損失したりします。
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On


Namespace My
    
    <Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute(),  _
     Global.System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "15.1.0.0"),  _
     Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
    Partial Friend NotInheritable Class MySettings
        Inherits Global.System.Configuration.ApplicationSettingsBase
        
        Private Shared defaultInstance As MySettings = CType(Global.System.Configuration.ApplicationSettingsBase.Synchronized(New MySettings()),MySettings)
        
#Region "My.Settings 自動保存機能"
#If _MyType = "WindowsForms" Then
    Private Shared addedHandler As Boolean

    Private Shared addedHandlerLockObject As New Object

    <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)> _
    Private Shared Sub AutoSaveSettings(sender As Global.System.Object, e As Global.System.EventArgs)
        If My.Application.SaveMySettingsOnExit Then
            My.Settings.Save()
        End If
    End Sub
#End If
#End Region
        
        Public Shared ReadOnly Property [Default]() As MySettings
            Get
                
#If _MyType = "WindowsForms" Then
               If Not addedHandler Then
                    SyncLock addedHandlerLockObject
                        If Not addedHandler Then
                            AddHandler My.Application.Shutdown, AddressOf AutoSaveSettings
                            addedHandler = True
                        End If
                    End SyncLock
                End If
#End If
                Return defaultInstance
            End Get
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property OpenCheck_InputFolder() As String
            Get
                Return CType(Me("OpenCheck_InputFolder"),String)
            End Get
            Set
                Me("OpenCheck_InputFolder") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property OpenCheck_OutputFolder() As String
            Get
                Return CType(Me("OpenCheck_OutputFolder"),String)
            End Get
            Set
                Me("OpenCheck_OutputFolder") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("0")>  _
        Public Property OpenCheck_HashType() As Integer
            Get
                Return CType(Me("OpenCheck_HashType"),Integer)
            End Get
            Set
                Me("OpenCheck_HashType") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("InTools")>  _
        Public Property DataBase() As String
            Get
                Return CType(Me("DataBase"),String)
            End Get
            Set
                Me("DataBase") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("sa")>  _
        Public Property UserID() As String
            Get
                Return CType(Me("UserID"),String)
            End Get
            Set
                Me("UserID") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("intra_intra")>  _
        Public Property PW() As String
            Get
                Return CType(Me("PW"),String)
            End Get
            Set
                Me("PW") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("INTRA-PDC00\INTRASQL")>  _
        Public Property DataSource() As String
            Get
                Return CType(Me("DataSource"),String)
            End Get
            Set
                Me("DataSource") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property Alibi_DstPath() As String
            Get
                Return CType(Me("Alibi_DstPath"),String)
            End Get
            Set
                Me("Alibi_DstPath") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property Alibi_SrcPath() As String
            Get
                Return CType(Me("Alibi_SrcPath"),String)
            End Get
            Set
                Me("Alibi_SrcPath") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property Alibi_LogPath() As String
            Get
                Return CType(Me("Alibi_LogPath"),String)
            End Get
            Set
                Me("Alibi_LogPath") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property Alibi_WorkName() As String
            Get
                Return CType(Me("Alibi_WorkName"),String)
            End Get
            Set
                Me("Alibi_WorkName") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("1")>  _
        Public Property Alibi_prtFrom() As Integer
            Get
                Return CType(Me("Alibi_prtFrom"),Integer)
            End Get
            Set
                Me("Alibi_prtFrom") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("1")>  _
        Public Property Alibi_prtTo() As Integer
            Get
                Return CType(Me("Alibi_prtTo"),Integer)
            End Get
            Set
                Me("Alibi_prtTo") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property Disk_InputPath() As String
            Get
                Return CType(Me("Disk_InputPath"),String)
            End Get
            Set
                Me("Disk_InputPath") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property Disk_OutputPath() As String
            Get
                Return CType(Me("Disk_OutputPath"),String)
            End Get
            Set
                Me("Disk_OutputPath") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("0")>  _
        Public Property Disk_DiskType() As Integer
            Get
                Return CType(Me("Disk_DiskType"),Integer)
            End Get
            Set
                Me("Disk_DiskType") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("0")>  _
        Public Property Disk_Formula() As Integer
            Get
                Return CType(Me("Disk_Formula"),Integer)
            End Get
            Set
                Me("Disk_Formula") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property Disk_OutExtension() As String
            Get
                Return CType(Me("Disk_OutExtension"),String)
            End Get
            Set
                Me("Disk_OutExtension") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("100")>  _
        Public Property Disk_Parcentage() As Integer
            Get
                Return CType(Me("Disk_Parcentage"),Integer)
            End Get
            Set
                Me("Disk_Parcentage") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("0")>  _
        Public Property Disk_DiskSize() As Long
            Get
                Return CType(Me("Disk_DiskSize"),Long)
            End Get
            Set
                Me("Disk_DiskSize") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("*.tif,*.jpg,*.pdf")>  _
        Public Property Disk_InExtension() As String
            Get
                Return CType(Me("Disk_InExtension"),String)
            End Get
            Set
                Me("Disk_InExtension") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("0")>  _
        Public Property Cnv_DPI() As Integer
            Get
                Return CType(Me("Cnv_DPI"),Integer)
            End Get
            Set
                Me("Cnv_DPI") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("0")>  _
        Public Property Cnv_DstCompress() As Integer
            Get
                Return CType(Me("Cnv_DstCompress"),Integer)
            End Get
            Set
                Me("Cnv_DstCompress") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("True")>  _
        Public Property Cnv_SelectJPEGQuality() As Boolean
            Get
                Return CType(Me("Cnv_SelectJPEGQuality"),Boolean)
            End Get
            Set
                Me("Cnv_SelectJPEGQuality") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("128")>  _
        Public Property Cnv_Threshold() As Integer
            Get
                Return CType(Me("Cnv_Threshold"),Integer)
            End Get
            Set
                Me("Cnv_Threshold") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property Cnv_LF() As String
            Get
                Return CType(Me("Cnv_LF"),String)
            End Get
            Set
                Me("Cnv_LF") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property Cnv_SrcPath() As String
            Get
                Return CType(Me("Cnv_SrcPath"),String)
            End Get
            Set
                Me("Cnv_SrcPath") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("0")>  _
        Public Property Cnv_SrcFormat() As Integer
            Get
                Return CType(Me("Cnv_SrcFormat"),Integer)
            End Get
            Set
                Me("Cnv_SrcFormat") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property Cnv_DstPath() As String
            Get
                Return CType(Me("Cnv_DstPath"),String)
            End Get
            Set
                Me("Cnv_DstPath") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("0")>  _
        Public Property Cnv_DstFormat() As Integer
            Get
                Return CType(Me("Cnv_DstFormat"),Integer)
            End Get
            Set
                Me("Cnv_DstFormat") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("True")>  _
        Public Property Cnv_SelectBinDither() As Boolean
            Get
                Return CType(Me("Cnv_SelectBinDither"),Boolean)
            End Get
            Set
                Me("Cnv_SelectBinDither") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("95")>  _
        Public Property Cnv_JPEGQuality() As Integer
            Get
                Return CType(Me("Cnv_JPEGQuality"),Integer)
            End Get
            Set
                Me("Cnv_JPEGQuality") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("2000")>  _
        Public Property Cnv_JPEGSize() As Integer
            Get
                Return CType(Me("Cnv_JPEGSize"),Integer)
            End Get
            Set
                Me("Cnv_JPEGSize") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property LogChk_SrcPath() As String
            Get
                Return CType(Me("LogChk_SrcPath"),String)
            End Get
            Set
                Me("LogChk_SrcPath") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property LogChk_DstPath() As String
            Get
                Return CType(Me("LogChk_DstPath"),String)
            End Get
            Set
                Me("LogChk_DstPath") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property BCRead_SrcPath() As String
            Get
                Return CType(Me("BCRead_SrcPath"),String)
            End Get
            Set
                Me("BCRead_SrcPath") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property BCRead_DstPath() As String
            Get
                Return CType(Me("BCRead_DstPath"),String)
            End Get
            Set
                Me("BCRead_DstPath") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("0")>  _
        Public Property LogChk_FileName_delimita() As String
            Get
                Return CType(Me("LogChk_FileName_delimita"),String)
            End Get
            Set
                Me("LogChk_FileName_delimita") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("0.0.2.5")>  _
        Public Property Ver_ScanLogChk() As String
            Get
                Return CType(Me("Ver_ScanLogChk"),String)
            End Get
            Set
                Me("Ver_ScanLogChk") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("1.0.0.7")>  _
        Public Property Ver_BCRead() As String
            Get
                Return CType(Me("Ver_BCRead"),String)
            End Get
            Set
                Me("Ver_BCRead") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("0.0.0.0")>  _
        Public Property Ver_Recovery() As String
            Get
                Return CType(Me("Ver_Recovery"),String)
            End Get
            Set
                Me("Ver_Recovery") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("-")>  _
        Public Property Ver_Rotate() As String
            Get
                Return CType(Me("Ver_Rotate"),String)
            End Get
            Set
                Me("Ver_Rotate") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("1.0.0.5")>  _
        Public Property Ver_Replace() As String
            Get
                Return CType(Me("Ver_Replace"),String)
            End Get
            Set
                Me("Ver_Replace") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("1.0.0.8")>  _
        Public Property Ver_Convert() As String
            Get
                Return CType(Me("Ver_Convert"),String)
            End Get
            Set
                Me("Ver_Convert") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("-")>  _
        Public Property Ver_Entry() As String
            Get
                Return CType(Me("Ver_Entry"),String)
            End Get
            Set
                Me("Ver_Entry") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("-")>  _
        Public Property Ver_Rename() As String
            Get
                Return CType(Me("Ver_Rename"),String)
            End Get
            Set
                Me("Ver_Rename") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("1.0.0.2")>  _
        Public Property Ver_Disk() As String
            Get
                Return CType(Me("Ver_Disk"),String)
            End Get
            Set
                Me("Ver_Disk") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("1.0.1.7")>  _
        Public Property Ver_OpenCheck() As String
            Get
                Return CType(Me("Ver_OpenCheck"),String)
            End Get
            Set
                Me("Ver_OpenCheck") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("1")>  _
        Public Property LogChk_FCCol() As Integer
            Get
                Return CType(Me("LogChk_FCCol"),Integer)
            End Get
            Set
                Me("LogChk_FCCol") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("1")>  _
        Public Property LogChk_ICCol() As Integer
            Get
                Return CType(Me("LogChk_ICCol"),Integer)
            End Get
            Set
                Me("LogChk_ICCol") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("1")>  _
        Public Property LogChk_PCCol() As Integer
            Get
                Return CType(Me("LogChk_PCCol"),Integer)
            End Get
            Set
                Me("LogChk_PCCol") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("22")>  _
        Public Property Rcv_Drive() As Integer
            Get
                Return CType(Me("Rcv_Drive"),Integer)
            End Get
            Set
                Me("Rcv_Drive") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("\\hydra\01_制作Gr")>  _
        Public Property Rcv_NetPath() As String
            Get
                Return CType(Me("Rcv_NetPath"),String)
            End Get
            Set
                Me("Rcv_NetPath") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("0")>  _
        Public Property OpenCheck_MojiCode() As Integer
            Get
                Return CType(Me("OpenCheck_MojiCode"),Integer)
            End Get
            Set
                Me("OpenCheck_MojiCode") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("0")>  _
        Public Property BCRead_BCType() As Integer
            Get
                Return CType(Me("BCRead_BCType"),Integer)
            End Get
            Set
                Me("BCRead_BCType") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("22")>  _
        Public Property LogChk_Drive() As Integer
            Get
                Return CType(Me("LogChk_Drive"),Integer)
            End Get
            Set
                Me("LogChk_Drive") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("\\hydra\01_制作Gr")>  _
        Public Property LogChk_NetPath() As String
            Get
                Return CType(Me("LogChk_NetPath"),String)
            End Get
            Set
                Me("LogChk_NetPath") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public Property Cnv_Multi() As Boolean
            Get
                Return CType(Me("Cnv_Multi"),Boolean)
            End Get
            Set
                Me("Cnv_Multi") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("0.0.0.2")>  _
        Public Property Ver_GetPath() As String
            Get
                Return CType(Me("Ver_GetPath"),String)
            End Get
            Set
                Me("Ver_GetPath") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property GetPath_SrcPath() As String
            Get
                Return CType(Me("GetPath_SrcPath"),String)
            End Get
            Set
                Me("GetPath_SrcPath") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property GetPath_DstPath() As String
            Get
                Return CType(Me("GetPath_DstPath"),String)
            End Get
            Set
                Me("GetPath_DstPath") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public Property GetPath_rbFolder() As Boolean
            Get
                Return CType(Me("GetPath_rbFolder"),Boolean)
            End Get
            Set
                Me("GetPath_rbFolder") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property GetPath_txtExt() As String
            Get
                Return CType(Me("GetPath_txtExt"),String)
            End Get
            Set
                Me("GetPath_txtExt") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public Property GetPath_chkExt() As Boolean
            Get
                Return CType(Me("GetPath_chkExt"),Boolean)
            End Get
            Set
                Me("GetPath_chkExt") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public Property GetPath_chkFileSize() As Boolean
            Get
                Return CType(Me("GetPath_chkFileSize"),Boolean)
            End Get
            Set
                Me("GetPath_chkFileSize") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("0")>  _
        Public Property GetPath_MojiCode() As Integer
            Get
                Return CType(Me("GetPath_MojiCode"),Integer)
            End Get
            Set
                Me("GetPath_MojiCode") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public Property GetPath_chkFileCount() As Boolean
            Get
                Return CType(Me("GetPath_chkFileCount"),Boolean)
            End Get
            Set
                Me("GetPath_chkFileCount") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("5")>  _
        Public Property OpenCheck_nudMargin() As Integer
            Get
                Return CType(Me("OpenCheck_nudMargin"),Integer)
            End Get
            Set
                Me("OpenCheck_nudMargin") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("True")>  _
        Public Property GetPath_rbComma() As Boolean
            Get
                Return CType(Me("GetPath_rbComma"),Boolean)
            End Get
            Set
                Me("GetPath_rbComma") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public Property GetPath_chkSkipEmpFolder() As Boolean
            Get
                Return CType(Me("GetPath_chkSkipEmpFolder"),Boolean)
            End Get
            Set
                Me("GetPath_chkSkipEmpFolder") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public Property GetPath_chkFindHidden() As Boolean
            Get
                Return CType(Me("GetPath_chkFindHidden"),Boolean)
            End Get
            Set
                Me("GetPath_chkFindHidden") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public Property GetPath_chkPathSplit() As Boolean
            Get
                Return CType(Me("GetPath_chkPathSplit"),Boolean)
            End Get
            Set
                Me("GetPath_chkPathSplit") = value
            End Set
        End Property
    End Class
End Namespace

Namespace My
    
    <Global.Microsoft.VisualBasic.HideModuleNameAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute()>  _
    Friend Module MySettingsProperty
        
        <Global.System.ComponentModel.Design.HelpKeywordAttribute("My.Settings")>  _
        Friend ReadOnly Property Settings() As Global.InTools.My.MySettings
            Get
                Return Global.InTools.My.MySettings.Default
            End Get
        End Property
    End Module
End Namespace
