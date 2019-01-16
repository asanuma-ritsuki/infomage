Imports System
Imports System.IO
Imports System.Text
Imports System.Runtime.Serialization
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Windows.Forms
Imports Microsoft.Win32

<System.Diagnostics.DebuggerStepThrough()> _
<Serializable()> _
Public Class XmlSettings

#Region "プライベート変数"

    '設定を保存するフィールド
    'フォーム全般
    Private _LocationX As Integer   'フォーム位置X
    Private _LocationY As Integer   'フォーム位置Y
    Private _SizeX As Integer   'フォーム幅
    Private _SizeY As Integer   'フォーム高さ
    Private _State As Integer   '最大化・最小化状態
    Private _ApplicationName As String  'アプリケーション名
    Private _LoginCategory As Integer   '作業工程のインデックス格納用
    '同期
    Private _ManageTable As String  '管理テーブル名
    Private _AccessFilePath As String   '管理データパス
    Private _ManageSynchroOutputFolder As String    '管理データ同期出力フォルダ
    '目次準備
    Private _PreparationFolder As String    '目次準備参照フォルダ
    Private _PreparationOutputFolder As String  '目次準備出力フォルダ
    '目次入力・インポート
    Private _InputFolder As String    '目次入力フォルダ
    Private _MokujiImportFile As String '目次データファイル
    Private _MokujiImportOutputFolder As String   '目次データ用ログフォルダ
    '目次検品
    Private _InspectionFolder As String   '目次検品フォルダ
    Private _BookmarkFolder As String   'しおりフォルダ
    'サムネイル
    Private _ThumbnailFolder As String    'サムネイル参照フォルダ
    Private _ThumbnailOutputFolder As String    'サムネイル出力フォルダ
    'サムネイル作製
    Private _ThumbCreateFolder As String    'サムネイル作製参照フォルダ
    Private _ThumbCreateOutputFolder As String  'サムネイル作製出力フォルダ
    '目次出力
    Private _MokujiExportOutputFolder As String '目次出力用フォルダ
    'コードチェック
    Private _CodeCheckFile As String    'コードチェック対象ファイル
    Private _CodeCheckOutputFolder As String    'コードチェック用出力フォルダ
    'SQLServer接続用
    Private _DataSource As String
    Private _InitialCatalog As String
    Private _UserID As String
    Private _Password As String

#End Region

#Region "プロパティ"

    '設定のプロパティ
    ''' <summary>
    ''' フォーム位置X
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property LocationX() As Integer
        Get
            Return _LocationX
        End Get
        Set(value As Integer)
            _LocationX = value
        End Set
    End Property
    ''' <summary>
    ''' フォーム位置Y
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property LocationY() As Integer
        Get
            Return _LocationY
        End Get
        Set(value As Integer)
            _LocationY = value
        End Set
    End Property
    ''' <summary>
    ''' フォーム幅
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SizeX() As Integer
        Get
            Return _SizeX
        End Get
        Set(value As Integer)
            _SizeX = value
        End Set
    End Property
    ''' <summary>
    ''' フォーム高さ
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SizeY() As Integer
        Get
            Return _SizeY
        End Get
        Set(value As Integer)
            _SizeY = value
        End Set
    End Property
    ''' <summary>
    ''' 最大化・最小化状態
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property State() As Integer
        Get
            Return _State
        End Get
        Set(value As Integer)
            _State = value
        End Set
    End Property
    ''' <summary>
    ''' アプリケーション名
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ApplicationName() As String
        Get
            Return _ApplicationName
        End Get
        Set(value As String)
            _ApplicationName = value
        End Set
    End Property
    ''' <summary>
    ''' 作業工程のインデックス
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property LoginCategory() As Integer
        Get
            Return _LoginCategory
        End Get
        Set(value As Integer)
            _LoginCategory = value
        End Set
    End Property
    ''' <summary>
    ''' 管理テーブル名
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ManageTable() As String
        Get
            Return _ManageTable
        End Get
        Set(value As String)
            _ManageTable = value
        End Set
    End Property
    ''' <summary>
    ''' 管理データパス
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property AccessFilePath() As String
        Get
            Return _AccessFilePath
        End Get
        Set(value As String)
            _AccessFilePath = value
        End Set
    End Property
    ''' <summary>
    ''' 管理データ同期出力フォルダ
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ManageSynchroOutputFolder() As String
        Get
            Return _ManageSynchroOutputFolder
        End Get
        Set(value As String)
            _ManageSynchroOutputFolder = value
        End Set
    End Property
    ''' <summary>
    ''' 目次準備参照フォルダ
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property PreparationFolder() As String
        Get
            Return _PreparationFolder
        End Get
        Set(value As String)
            _PreparationFolder = value
        End Set
    End Property
    ''' <summary>
    ''' 目次準備出力フォルダ
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property PreparationOutputFolder() As String
        Get
            Return _PreparationOutputFolder
        End Get
        Set(value As String)
            _PreparationOutputFolder = value
        End Set
    End Property
    ''' <summary>
    ''' 目次入力フォルダ
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property InputFolder() As String
        Get
            Return _InputFolder
        End Get
        Set(value As String)
            _InputFolder = value
        End Set
    End Property
    ''' <summary>
    ''' 目次データファイル
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property MokujiImportFile() As String
        Get
            Return _MokujiImportFile
        End Get
        Set(value As String)
            _MokujiImportFile = value
        End Set
    End Property
    ''' <summary>
    ''' 目次データ出力フォルダ
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property MokujiImportOutputFolder() As String
        Get
            Return _MokujiImportOutputFolder
        End Get
        Set(value As String)
            _MokujiImportOutputFolder = value
        End Set
    End Property
    ''' <summary>
    ''' 目次検品フォルダ
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property InspectionFolder() As String
        Get
            Return _InspectionFolder
        End Get
        Set(value As String)
            _InspectionFolder = value
        End Set
    End Property
    ''' <summary>
    ''' しおりフォルダ
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property BookmarkFolder() As String
        Get
            Return _BookmarkFolder
        End Get
        Set(value As String)
            _BookmarkFolder = value
        End Set
    End Property
    ''' <summary>
    ''' サムネイル参照フォルダ
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ThumbnailFolder() As String
        Get
            Return _ThumbnailFolder
        End Get
        Set(value As String)
            _ThumbnailFolder = value
        End Set
    End Property
    ''' <summary>
    ''' サムネイル出力フォルダ
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ThumbnailOutputFolder() As String
        Get
            Return _ThumbnailOutputFolder
        End Get
        Set(value As String)
            _ThumbnailOutputFolder = value
        End Set
    End Property
    ''' <summary>
    ''' サムネイル作製参照フォルダ
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ThumbCreateFolder() As String
        Get
            Return _ThumbCreateFolder
        End Get
        Set(value As String)
            _ThumbCreateFolder = value
        End Set
    End Property
    ''' <summary>
    ''' サムネイル作製出力フォルダ
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ThumbCreateOutputFolder() As String
        Get
            Return _ThumbCreateOutputFolder
        End Get
        Set(value As String)
            _ThumbCreateOutputFolder = value
        End Set
    End Property
    ''' <summary>
    ''' 目次出力
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property MokujiExportOutputFolder() As String
        Get
            Return _MokujiExportOutputFolder
        End Get
        Set(value As String)
            _MokujiExportOutputFolder = value
        End Set
    End Property
    ''' <summary>
    ''' コードチェック対象ファイル
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property CodeCheckFile() As String
        Get
            Return _CodeCheckFile
        End Get
        Set(value As String)
            _CodeCheckFile = value
        End Set
    End Property
    ''' <summary>
    ''' コードチェック用出力フォルダ
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property CodeCheckOutputFolder() As String
        Get
            Return _CodeCheckOutputFolder
        End Get
        Set(value As String)
            _CodeCheckOutputFolder = value
        End Set
    End Property
    ''' <summary>
    ''' DataSource
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property DataSource() As String
        Get
            Return _DataSource
        End Get
        Set(value As String)
            _DataSource = value
        End Set
    End Property
    ''' <summary>
    ''' InitialCatalog
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property InitialCatalog() As String
        Get
            Return _InitialCatalog
        End Get
        Set(value As String)
            _InitialCatalog = value
        End Set
    End Property
    ''' <summary>
    ''' UserID
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property UserID() As String
        Get
            Return _UserID
        End Get
        Set(value As String)
            _UserID = value
        End Set
    End Property
    ''' <summary>
    ''' Password
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Password() As String
        Get
            Return _Password
        End Get
        Set(value As String)
            _Password = value
        End Set
    End Property

#End Region

#Region "コンストラクタ"

    Public Sub New()

        'SQLServer接続用
        _DataSource = My.Settings.DataSource
        _InitialCatalog = My.Settings.DataBase
        _UserID = My.Settings.UserID
        _Password = My.Settings.PW

        'XMLファイルが存在していたら読み込む
        'LoadFromXmlFile()

    End Sub

#End Region

#Region "インスタンス"

    'XmlSettingsクラスのただひとつのインスタンス
    <NonSerialized()> _
    Private Shared _instance As XmlSettings
    <System.Xml.Serialization.XmlIgnore()> _
    Public Shared Property Instance() As XmlSettings
        Get
            If _instance Is Nothing Then
                _instance = New XmlSettings
            End If
            Return _instance
        End Get
        Set(value As XmlSettings)
            _instance = value
        End Set
    End Property

#End Region

#Region "設定の読み書き"

    ''' <summary>
    ''' 設定をXMLファイルから読み込み復元する
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Sub LoadFromXmlFile()

        Dim p As String = GetSettingPath()
        If Not System.IO.File.Exists(p) Then
            Exit Sub
        End If
        Dim sr As New StreamReader(p, New UTF8Encoding(False))
        Dim xs As New System.Xml.Serialization.XmlSerializer(GetType(XmlSettings))
        '読み込んで逆シリアル化する
        Dim obj As Object = xs.Deserialize(sr)
        sr.Close()

        Instance = CType(obj, XmlSettings)

    End Sub

    ''' <summary>
    ''' 現在の設定をXMLファイルに保存する
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Sub SaveToXmlFile()

        Dim p As String = GetSettingPath()
        If Not System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(p)) Then
            My.Computer.FileSystem.CreateDirectory(System.IO.Path.GetDirectoryName(p))
        End If
        Dim sw As New StreamWriter(p, False, New UTF8Encoding(False))
        Dim xs As New System.Xml.Serialization.XmlSerializer(GetType(XmlSettings))
        'シリアル化して書き込む
        xs.Serialize(sw, Instance)
        sw.Close()

    End Sub


    ''' <summary>
    ''' 設定をバイナリファイルから読み込み復元する
    ''' </summary>
    Public Shared Sub LoadFromBinaryFile()
        Dim p As String = GetSettingPath()

        Dim fs As New FileStream(p, FileMode.Open, FileAccess.Read)
        Dim bf As New BinaryFormatter
        '読み込んで逆シリアル化する
        Dim obj As Object = bf.Deserialize(fs)
        fs.Close()

        Instance = CType(obj, XmlSettings)
    End Sub

    ''' <summary>
    ''' 現在の設定をバイナリファイルに保存する
    ''' </summary>
    Public Shared Sub SaveToBinaryFile()
        Dim p As String = GetSettingPath()

        Dim fs As New FileStream(p, FileMode.Create, FileAccess.Write)
        Dim bf As New BinaryFormatter
        'シリアル化して書き込む
        bf.Serialize(fs, Instance)
        fs.Close()
    End Sub

    ''' <summary>
    ''' 設定をレジストリから読み込み復元する
    ''' </summary>
    Public Shared Sub LoadFromRegistry()
        Dim bf As New BinaryFormatter
        'レジストリから読み込む
        Dim reg As RegistryKey = GetSettingRegistry()
        Dim bs As Byte() = CType(reg.GetValue(""), Byte())
        '逆シリアル化して復元
        Dim ms As New MemoryStream(bs, False)
        Instance = CType(bf.Deserialize(ms), XmlSettings)
        '閉じる
        ms.Close()
        reg.Close()
    End Sub

    ''' <summary>
    ''' 現在の設定をレジストリに保存する
    ''' </summary>
    Public Shared Sub SaveToRegistry()
        Dim ms As New MemoryStream
        Dim bf As New BinaryFormatter
        'シリアル化してMemoryStreamに書き込む
        bf.Serialize(ms, Instance)
        'レジストリへ保存する
        Dim reg As RegistryKey = GetSettingRegistry()
        reg.SetValue("", ms.ToArray())
        '閉じる
        ms.Close()
        reg.Close()
    End Sub

    ''' <summary>
    ''' インスタンスの内容を保存して解放する
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Sub Dispose()

        SaveToXmlFile()
        Instance = Nothing

    End Sub

#End Region

#Region "プライベートメソッド"

    ''' <summary>
    ''' XMLファイルの保存先を取得する
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function GetSettingPath() As String

        'Dim p As String = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), _
        '                               Application.CompanyName + "\" + Application.ProductName _
        '                               + "\" + "Settings.xml")
        Dim p As String = Application.StartupPath & "\Settings.xml"

        Return p

    End Function

    ''' <summary>
    ''' レジストリの保存先キーを取得する
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function GetSettingRegistry() As RegistryKey

        Dim reg As RegistryKey = Registry.CurrentUser.CreateSubKey(("Software\" + Application.CompanyName + _
                                                                    "\" + Application.ProductName))
        Return reg

    End Function

#End Region

End Class
