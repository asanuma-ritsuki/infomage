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

Imports System

Namespace My.Resources
    
    'このクラスは StronglyTypedResourceBuilder クラスが ResGen
    'または Visual Studio のようなツールを使用して自動生成されました。
    'メンバーを追加または削除するには、.ResX ファイルを編集して、/str オプションと共に
    'ResGen を実行し直すか、または VS プロジェクトをビルドし直します。
    '''<summary>
    '''  ローカライズされた文字列などを検索するための、厳密に型指定されたリソース クラスです。
    '''</summary>
    <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0"),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute(),  _
     Global.Microsoft.VisualBasic.HideModuleNameAttribute()>  _
    Friend Module Resources
        
        Private resourceMan As Global.System.Resources.ResourceManager
        
        Private resourceCulture As Global.System.Globalization.CultureInfo
        
        '''<summary>
        '''  このクラスで使用されているキャッシュされた ResourceManager インスタンスを返します。
        '''</summary>
        <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Friend ReadOnly Property ResourceManager() As Global.System.Resources.ResourceManager
            Get
                If Object.ReferenceEquals(resourceMan, Nothing) Then
                    Dim temp As Global.System.Resources.ResourceManager = New Global.System.Resources.ResourceManager("InTools.Resources", GetType(Resources).Assembly)
                    resourceMan = temp
                End If
                Return resourceMan
            End Get
        End Property
        
        '''<summary>
        '''  厳密に型指定されたこのリソース クラスを使用して、すべての検索リソースに対し、
        '''  現在のスレッドの CurrentUICulture プロパティをオーバーライドします。
        '''</summary>
        <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Friend Property Culture() As Global.System.Globalization.CultureInfo
            Get
                Return resourceCulture
            End Get
            Set
                resourceCulture = value
            End Set
        End Property
        
        '''<summary>
        '''  型 System.Drawing.Bitmap のローカライズされたリソースを検索します。
        '''</summary>
        Friend ReadOnly Property barcode() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("barcode", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  型 System.Drawing.Bitmap のローカライズされたリソースを検索します。
        '''</summary>
        Friend ReadOnly Property Check() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("Check", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  型 System.Drawing.Bitmap のローカライズされたリソースを検索します。
        '''</summary>
        Friend ReadOnly Property convert() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("convert", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  型 System.Drawing.Bitmap のローカライズされたリソースを検索します。
        '''</summary>
        Friend ReadOnly Property DiskMaker_ICON() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("DiskMaker_ICON", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  型 System.Drawing.Bitmap のローカライズされたリソースを検索します。
        '''</summary>
        Friend ReadOnly Property entry() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("entry", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  型 System.Drawing.Bitmap のローカライズされたリソースを検索します。
        '''</summary>
        Friend ReadOnly Property Flag_red() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("Flag_red", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  型 System.Drawing.Bitmap のローカライズされたリソースを検索します。
        '''</summary>
        Friend ReadOnly Property GetPath() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("GetPath", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  型 System.Drawing.Bitmap のローカライズされたリソースを検索します。
        '''</summary>
        Friend ReadOnly Property Inspection() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("Inspection", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  (アイコン) に類似した型 System.Drawing.Icon のローカライズされたリソースを検索します。
        '''</summary>
        Friend ReadOnly Property InTools() As System.Drawing.Icon
            Get
                Dim obj As Object = ResourceManager.GetObject("InTools", resourceCulture)
                Return CType(obj,System.Drawing.Icon)
            End Get
        End Property
        
        '''<summary>
        '''  型 System.Drawing.Bitmap のローカライズされたリソースを検索します。
        '''</summary>
        Friend ReadOnly Property menu_bg() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("menu_bg", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  型 System.Drawing.Bitmap のローカライズされたリソースを検索します。
        '''</summary>
        Friend ReadOnly Property OCR() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("OCR", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  型 System.Drawing.Bitmap のローカライズされたリソースを検索します。
        '''</summary>
        Friend ReadOnly Property Recover() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("Recover", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  型 System.Drawing.Bitmap のローカライズされたリソースを検索します。
        '''</summary>
        Friend ReadOnly Property Remove() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("Remove", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  型 System.Drawing.Bitmap のローカライズされたリソースを検索します。
        '''</summary>
        Friend ReadOnly Property Rename() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("Rename", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  型 System.Drawing.Bitmap のローカライズされたリソースを検索します。
        '''</summary>
        Friend ReadOnly Property Replace() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("Replace", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  型 System.Drawing.Bitmap のローカライズされたリソースを検索します。
        '''</summary>
        Friend ReadOnly Property rotate() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("rotate", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  型 System.Drawing.Bitmap のローカライズされたリソースを検索します。
        '''</summary>
        Friend ReadOnly Property transform_rotate_180() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("transform_rotate_180", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  型 System.Drawing.Bitmap のローカライズされたリソースを検索します。
        '''</summary>
        Friend ReadOnly Property transform_rotate_270() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("transform_rotate_270", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  型 System.Drawing.Bitmap のローカライズされたリソースを検索します。
        '''</summary>
        Friend ReadOnly Property transform_rotate_90() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("transform_rotate_90", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  型 System.Drawing.Bitmap のローカライズされたリソースを検索します。
        '''</summary>
        Friend ReadOnly Property under_arrow() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("under_arrow", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  2018.6.19 1.0.3.3 画像変換:マルチPDFに変換する際にエラーになる問題を修正
        '''2018.6.19 1.0.3.3 画像変換:マルチTIFFの結合・分割に対応
        '''2018.6.19 1.0.3.3 画像変換:マルチPDFを分割した際ログの表示がエラーになる問題を修正
        '''2018.6.19 1.0.3.3 画像変換:UIを一部変更
        '''2018.6.18 1.0.3.2 オープンチェック:leadtoolsに修正、大文字拡張子に対応
        '''2018.6.18 1.0.3.2 画像変換:シングルPDFをマルチPDFに変換する際にエラーになる問題を修正
        '''2018.6.13 1.0.3.1 画像変換:PDF変換処理速度を改善
        '''2018.6.13 1.0.3.1 オープンチェック:leadtoolsからiTextsharpに移行
        '''2018.6.6  1.0.3.0 スキャンログチェック:回転処理、サムネイル表示速度を改善
        '''2018.6.6  1.0.2.9 スキャンログチェック:処理速度を改善
        '''2018.5.30 1.0.2.8 スキャンログチェック:サムネイルが表示されないバグを修正
        '''2018 [残りの文字列は切り詰められました]&quot;; に類似しているローカライズされた文字列を検索します。
        '''</summary>
        Friend ReadOnly Property 更新履歴() As String
            Get
                Return ResourceManager.GetString("更新履歴", resourceCulture)
            End Get
        End Property
    End Module
End Namespace
