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
	Private _LocEntryX As Integer   'エントリフォーム位置X
	Private _LocEntryY As Integer   'エントリフォーム位置Y
	Private _SizeEntryX As Integer  'エントリフォーム幅
	Private _SizeEntryY As Integer  'エントリフォーム高さ
	Private _LocManageX As Integer  '管理フォーム位置X
	Private _LocManageY As Integer  '管理フォーム位置Y
	Private _SizeManageX As Integer '管理フォーム幅
	Private _SizeManageY As Integer '管理フォーム高さ
	Private _StateManage As Integer '管理フォーム最大化・最小化状態
	'インポート画面
	Private _ImportFromFolder As String 'インポート元フォルダ
	Private _ImportToFolder As String   '保存先フォルダ
	Private _ImportLogFolder As String  'ログ保存先フォルダ
	Private _ZipPassword As String  'ZIP解凍用パスワード
	'不備内容項目
	Private _DataDupe As String '重複レコード
	Private _DataRequired As String '必須項目不備
	Private _DataDigit As String    '桁数不備
	Private _DataShiftJIS As String 'データ不備(SJISで表現できない)
	Private _SJISErrorCheck As String   '?？･・

	'イメージ関連
	Private _ImagePath As String    '画像ファイル親パス

	'SQLServer接続用
	Private _DataSource As String
	Private _InitialCatalog As String
	Private _UserID As String
	Private _Password As String
	Private _TablePrefix As String

	'出力関連
	Private _OutputFolder As String '出力フォルダ

	'印刷関連
	Private _CheckupList As Integer '対象者一覧1ページあたりの件数
	Private _LeafletList As Integer '保健指導対象者名簿1ページあたりの件数
	Private _Sentlist As String 'プラインタドライバ名(対象者一覧、保健指導対象者名簿)
	Private _Result As String   'プリンタドライバ名(判定票)
	Private _Leaflet As String  'プリンタドライバ名(リーフレット)

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
	''' エントリフォーム位置X
	''' </summary>
	''' <returns></returns>
	Public Property LocEntryX() As Integer
		Get
			Return _LocEntryX
		End Get
		Set(value As Integer)
			_LocEntryX = value
		End Set
	End Property

	''' <summary>
	''' エントリフォーム位置Y
	''' </summary>
	''' <returns></returns>
	Public Property LocEntryY() As Integer
		Get
			Return _LocEntryY
		End Get
		Set(value As Integer)
			_LocEntryY = value
		End Set
	End Property

	''' <summary>
	''' エントリフォーム幅
	''' </summary>
	''' <returns></returns>
	Public Property SizeEntryX() As Integer
		Get
			Return _SizeEntryX
		End Get
		Set(value As Integer)
			_SizeEntryX = value
		End Set
	End Property

	''' <summary>
	''' エントリフォーム高さ
	''' </summary>
	''' <returns></returns>
	Public Property SizeEntryY() As Integer
		Get
			Return _SizeEntryY
		End Get
		Set(value As Integer)
			_SizeEntryY = value
		End Set
	End Property

	''' <summary>
	''' 管理フォーム位置X
	''' </summary>
	''' <returns></returns>
	Public Property LocManageX() As Integer
		Get
			Return _LocManageX
		End Get
		Set(value As Integer)
			_LocManageX = value
		End Set
	End Property

	''' <summary>
	''' 管理フォーム位置Y
	''' </summary>
	''' <returns></returns>
	Public Property LocManageY() As Integer
		Get
			Return _LocManageY
		End Get
		Set(value As Integer)
			_LocManageY = value
		End Set
	End Property

	''' <summary>
	''' 管理フォーム幅
	''' </summary>
	''' <returns></returns>
	Public Property SizeManageX() As Integer
		Get
			Return _SizeManageX
		End Get
		Set(value As Integer)
			_SizeManageX = value
		End Set
	End Property

	''' <summary>
	''' 管理フォーム高さ
	''' </summary>
	''' <returns></returns>
	Public Property SizeManageY() As Integer
		Get
			Return _SizeManageY
		End Get
		Set(value As Integer)
			_SizeManageY = value
		End Set
	End Property

	''' <summary>
	''' 管理フォーム最大化・最小化状態
	''' </summary>
	''' <returns></returns>
	Public Property StateManage() As Integer
		Get
			Return _StateManage
		End Get
		Set(value As Integer)
			_StateManage = value
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

	'==================================================
	'インポート画面

	''' <summary>
	''' インポート元フォルダ
	''' </summary>
	''' <returns></returns>
	Public Property ImportFromFolder() As String
		Get
			Return _ImportFromFolder
		End Get
		Set(value As String)
			_ImportFromFolder = value
		End Set
	End Property

	''' <summary>
	''' 保存先フォルダ
	''' </summary>
	''' <returns></returns>
	Public Property ImportToFolder() As String
		Get
			Return _ImportToFolder
		End Get
		Set(value As String)
			_ImportToFolder = value
		End Set
	End Property

	''' <summary>
	''' ログ保存先フォルダ
	''' </summary>
	''' <returns></returns>
	Public Property ImportLogFolder() As String
		Get
			Return _ImportLogFolder
		End Get
		Set(value As String)
			_ImportLogFolder = value
		End Set
	End Property

	''' <summary>
	''' ZIP解凍用パスワード
	''' </summary>
	''' <returns></returns>
	Public Property ZipPassword() As String
		Get
			Return _ZipPassword
		End Get
		Set(value As String)
			_ZipPassword = value
		End Set
	End Property

	''' <summary>
	''' 重複レコード
	''' </summary>
	''' <returns></returns>
	Public Property DataDupe() As String
		Get
			Return _DataDupe
		End Get
		Set(value As String)
			_DataDupe = value
		End Set
	End Property

	''' <summary>
	''' 必須項目不備
	''' </summary>
	''' <returns></returns>
	Public Property DataRequired() As String
		Get
			Return _DataRequired
		End Get
		Set(value As String)
			_DataRequired = value
		End Set
	End Property

	''' <summary>
	''' 桁数不備
	''' </summary>
	''' <returns></returns>
	Public Property DataDigit() As String
		Get
			Return _DataDigit
		End Get
		Set(value As String)
			_DataDigit = value
		End Set
	End Property

	''' <summary>
	''' データ不備(SJISで表現できない)
	''' </summary>
	''' <returns></returns>
	Public Property DataShiftJIS() As String
		Get
			Return _DataShiftJIS
		End Get
		Set(value As String)
			_DataShiftJIS = value
		End Set
	End Property

	''' <summary>
	''' SJISで表現できない文言
	''' </summary>
	''' <returns></returns>
	Public Property SJISErrorCheck() As String
		Get
			Return _SJISErrorCheck
		End Get
		Set(value As String)
			_SJISErrorCheck = value
		End Set
	End Property
	'==================================================
	''' <summary>
	''' 画像ファイル親パス
	''' </summary>
	''' <returns></returns>
	Public Property ImagePath() As String
		Get
			Return _ImagePath
		End Get
		Set(value As String)
			_ImagePath = value
		End Set
	End Property

	''' <summary>
	''' 出力フォルダ
	''' </summary>
	''' <returns></returns>
	Public Property OutputFolder() As String
		Get
			Return _OutputFolder
		End Get
		Set(value As String)
			_OutputFolder = value
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

	'==================================================
	'印刷関連
	'==================================================
	''' <summary>
	''' 対象者一覧1ページあたりの件数
	''' </summary>
	''' <returns></returns>
	Public Property CheckupList() As Integer
		Get
			Return _CheckupList
		End Get
		Set(value As Integer)
			_CheckupList = value
		End Set
	End Property

	''' <summary>
	''' 保健指導対象者名簿1ページあたりの件数
	''' </summary>
	''' <returns></returns>
	Public Property LeafletList() As Integer
		Get
			Return _LeafletList
		End Get
		Set(value As Integer)
			_LeafletList = value
		End Set
	End Property

	''' <summary>
	''' プリンタドライバ名(対象者一覧、保健指導対象者名簿)の入出力
	''' </summary>
	''' <returns></returns>
	Public Property Printer_Sentlist() As String
		Get
			Return _Sentlist
		End Get
		Set(value As String)
			_Sentlist = value
		End Set
	End Property

	''' <summary>
	''' プリンタドライバ名(判定票)
	''' </summary>
	''' <returns></returns>
	Public Property Printer_Result() As String
		Get
			Return _Result
		End Get
		Set(value As String)
			_Result = value
		End Set
	End Property

	''' <summary>
	''' プリンタドライバ名(リーフレット)
	''' </summary>
	''' <returns></returns>
	Public Property Printer_Leaflet() As String
		Get
			Return _Leaflet
		End Get
		Set(value As String)
			_Leaflet = value
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
		_LocEntryX = 100
		_LocEntryY = 100
		_SizeEntryX = 1024
		_SizeEntryY = 400
		_ApplicationName = "雄松堂 府県統計資料 リンク付けツール"
		'インポート画面
		_ImportFromFolder = "C:\JPTemp\01_Import"
		_ImportToFolder = "C:\JPTemp\02_Out"
		_ImportLogFolder = "C:\JPTemp\03_Log"
		_ZipPassword = "kenkan"
		_DataDupe = "重複レコード"
		_DataRequired = "必須項目不備"
		_DataDigit = "桁数不備"
		_DataShiftJIS = "データ不備(SJISで表現できない)"
		_SJISErrorCheck = "?,？,･,・"

		'イメージ関連
		_ImagePath = "\\192.168.1.210\02_スチールGr\02_スポット案件\2013-2016_141032021_雄松堂_府県統計資料\99_Entry\01_image"

		'SQLServer接続用
		_DataSource = "INTRA-PDC00\INTRASQL"
		_InitialCatalog = "JPHealth"
		_UserID = "sa"
		_Password = "intra_intra"
		_TablePrefix = "[DailyReport_Test].[dbo]."

		'印刷関連
		_CheckupList = 50
		_LeafletList = 15
		_Sentlist = "JP_Sentlist"
		_Result = "JP_Result"
		_Leaflet = "JP_Leaflet"

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
