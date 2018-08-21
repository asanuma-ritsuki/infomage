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

	Private _TargetPath As String
	Private _OutPath As String
	Private _Title As String
	Private _Author As String
	Private _SubTitle As String
	Private _Keywords As String
	Private _CSVFile As String
	Private _TIFTargetPath As String
	Private _TIFSubject As String
	Private _TIFAuthor As String

	'SQLServer接続用
	Private _DataSource As String
	Private _InitialCatalog As String
	Private _UserID As String
	Private _Password As String
	Private _TablePrefix As String

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

	''' <summary>
	''' INTRA-PDC00接続時の接頭語入出力
	''' </summary>
	''' <returns></returns>
	Public Property TablePrefix() As String
		Get
			Return _TablePrefix
		End Get
		Set(value As String)
			_TablePrefix = value
		End Set
	End Property

	''' <summary>
	''' PDF対象フォルダ
	''' </summary>
	''' <returns></returns>
	Public Property TargetPath() As String
		Get
			Return _TargetPath
		End Get
		Set(value As String)
			_TargetPath = value
		End Set
	End Property

	''' <summary>
	''' PDF出力フォルダ
	''' </summary>
	''' <returns></returns>
	Public Property OutPath() As String
		Get
			Return _OutPath
		End Get
		Set(value As String)
			_OutPath = value
		End Set
	End Property

	''' <summary>
	''' PDFタイトル
	''' </summary>
	''' <returns></returns>
	Public Property Title() As String
		Get
			Return _Title
		End Get
		Set(value As String)
			_Title = value
		End Set
	End Property

	''' <summary>
	''' PDF作成者
	''' </summary>
	''' <returns></returns>
	Public Property Author() As String
		Get
			Return _Author
		End Get
		Set(value As String)
			_Author = value
		End Set
	End Property

	''' <summary>
	''' サブタイトル
	''' </summary>
	''' <returns></returns>
	Public Property SubTitle() As String
		Get
			Return _SubTitle
		End Get
		Set(value As String)
			_SubTitle = value
		End Set
	End Property

	''' <summary>
	''' PDFキーワード
	''' </summary>
	''' <returns></returns>
	Public Property Keywords() As String
		Get
			Return _Keywords
		End Get
		Set(value As String)
			_Keywords = value
		End Set
	End Property

	''' <summary>
	''' CSVファイル
	''' </summary>
	''' <returns></returns>
	Public Property CSVFile() As String
		Get
			Return _CSVFile
		End Get
		Set(value As String)
			_CSVFile = value
		End Set
	End Property

	''' <summary>
	''' TIF対象フォルダ
	''' </summary>
	''' <returns></returns>
	Public Property TIFTargetPath() As String
		Get
			Return _TIFTargetPath
		End Get
		Set(value As String)
			_TIFTargetPath = value
		End Set
	End Property

	''' <summary>
	''' 件名
	''' </summary>
	''' <returns></returns>
	Public Property TIFSubject() As String
		Get
			Return _TIFSubject
		End Get
		Set(value As String)
			_TIFSubject = value
		End Set
	End Property

	''' <summary>
	''' TIF作成者
	''' </summary>
	''' <returns></returns>
	Public Property TIFAuthor() As String
		Get
			Return _TIFAuthor
		End Get
		Set(value As String)
			_TIFAuthor = value
		End Set
	End Property

#End Region

#Region "コンストラクタ"

	Public Sub New()

		'フォーム全般
		_LocationX = 0
		_LocationY = 0
		_SizeX = 1024
		_SizeY = 768
		_ApplicationName = "JP健診 就業判定票発送業務支援ツール"

		_TargetPath = ""
		_OutPath = ""
		_Title = ""
		_Author = ""
		_SubTitle = ""
		_Keywords = ""
		_CSVFile = ""
		_TIFTargetPath = ""
		_TIFSubject = "国民所得推計研究会資料"
		_TIFAuthor = "一橋大学経済研究所附属社会科学統計情報研究センター"

		'SQLServer接続用
		_DataSource = "JPSERV\INTRASQL"
		_InitialCatalog = "JPHealth"
		_UserID = "sa"
		_Password = "intra_intra"
		_TablePrefix = "[DailyReport_Test].[dbo]."

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
