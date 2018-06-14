Imports System
Imports System.IO
Imports System.Text
Imports System.Runtime.Serialization
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Windows.Forms
Imports Microsoft.Win32

<Serializable()>
<System.Diagnostics.DebuggerStepThrough()>
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

	Private _SrcFolder As String    '対象フォルダ
	Private _OfferCSV As String     '提供データCSV
	Private _OutFolder As String    '出力フォルダ

	Private _JpegSizeFrom As Long    'JPEGサイズFrom
	Private _JpegSizeTo As Long  'JPEGサイズTo

	Private _Camera As String   '使用カメラ(コロンで区切った数値を格納)

	Private _SerialDigit As Integer '連番桁数
	Private _SerialFrom As Integer  '連番開始番号

#End Region

#Region "プロパティ"

	''' <summary>
	''' フォーム位置X
	''' </summary>
	''' <returns></returns>
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
	''' <returns></returns>
	Public Property LocationY() As Integer
		Get
			Return _LocationY
		End Get
		Set(value As Integer)
			_LocationY = value
		End Set
	End Property

	''' <summary>
	''' サイズ幅
	''' </summary>
	''' <returns></returns>
	Public Property SizeX() As Integer
		Get
			Return _SizeX
		End Get
		Set(value As Integer)
			_SizeX = value
		End Set
	End Property

	''' <summary>
	''' サイズ高さ
	''' </summary>
	''' <returns></returns>
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
	''' <returns></returns>
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
	''' <returns></returns>
	Public Property ApplicationName() As String
		Get
			Return _ApplicationName
		End Get
		Set(value As String)
			_ApplicationName = value
		End Set
	End Property

	''' <summary>
	''' 対象フォルダ
	''' </summary>
	''' <returns></returns>
	Public Property SrcFolder() As String
		Get
			Return _SrcFolder
		End Get
		Set(value As String)
			_SrcFolder = value
		End Set
	End Property

	''' <summary>
	''' 提供データCSV
	''' </summary>
	''' <returns></returns>
	Public Property OfferCSV() As String
		Get
			Return _OfferCSV
		End Get
		Set(value As String)
			_OfferCSV = value
		End Set
	End Property

	''' <summary>
	''' 出力フォルダ
	''' </summary>
	''' <returns></returns>
	Public Property OutFolder() As String
		Get
			Return _OutFolder
		End Get
		Set(value As String)
			_OutFolder = value
		End Set
	End Property

	''' <summary>
	''' JPEGサイズFrom
	''' </summary>
	''' <returns></returns>
	Public Property JpegSizeFrom() As Long
		Get
			Return _JpegSizeFrom
		End Get
		Set(value As Long)
			_JpegSizeFrom = value
		End Set
	End Property

	''' <summary>
	''' JPEGサイズTo
	''' </summary>
	''' <returns></returns>
	Public Property JpegSizeTo() As Long
		Get
			Return _JpegSizeTo
		End Get
		Set(value As Long)
			_JpegSizeTo = value
		End Set
	End Property

	''' <summary>
	''' 使用カメラ
	''' </summary>
	''' <returns></returns>
	Public Property Camera() As String
		Get
			Return _Camera
		End Get
		Set(value As String)
			_Camera = value
		End Set
	End Property

	''' <summary>
	''' 連番桁数
	''' </summary>
	''' <returns></returns>
	Public Property SerialDigit() As Integer
		Get
			Return _SerialDigit
		End Get
		Set(value As Integer)
			_SerialDigit = value
		End Set
	End Property

	''' <summary>
	''' 連番開始番号
	''' </summary>
	''' <returns></returns>
	Public Property SerialFrom() As Integer
		Get
			Return _SerialFrom
		End Get
		Set(value As Integer)
			_SerialFrom = value
		End Set
	End Property

#End Region

#Region "コンストラクタ"

	Public Sub New()

		'フォーム全般
		_LocationX = 0
		_LocationY = 0
		_SizeX = 1000
		_SizeY = 800
		_ApplicationName = "画像チェックツール"
		_SrcFolder = "C:\"
		_OfferCSV = "C:\test.csv"
		_OutFolder = "C:\"
		_JpegSizeFrom = 0
		_JpegSizeTo = 999999999
		_Camera = "0"
		_SerialDigit = 5
		_SerialFrom = 0

	End Sub

#End Region

#Region "インスタンス"

	'XmlSettingsクラスのただ一つのインスタンス
	<NonSerialized()>
	Private Shared _instance As XmlSettings

	<System.Xml.Serialization.XmlIgnore()>
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

		'Dim p As String = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
		'							   Application.CompanyName + "\" + Application.ProductName _
		'							   + "\" + "Settings.xml")
		Dim p As String = Application.StartupPath & "\" + "Settings.xml"

		Return p

	End Function

	''' <summary>
	''' レジストリの保存先キーを取得する
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Private Shared Function GetSettingRegistry() As RegistryKey

		Dim reg As RegistryKey = Registry.CurrentUser.CreateSubKey(("Software\" + Application.CompanyName +
																	"\" + Application.ProductName))
		Return reg

	End Function

#End Region

End Class
