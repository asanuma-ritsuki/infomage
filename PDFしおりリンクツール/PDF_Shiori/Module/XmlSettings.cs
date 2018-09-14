using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDF_Shiori
{
	[Serializable]
	[DebuggerStepThrough]
	public class XmlSettings
	{
		#region プライベート変数
		//設定を保存するフィールド
		//フォーム全般
		private static int _LocationX;
		private static int _LocationY;
		private static int _SizeX;
		private static int _SizeY;
		private static int _State;
		private static string _ApplicationName;
		//SQL Server関連
		private static string _DataSource;
		private static string _InitialCatalog;
		private static string _UserID;
		private static string _Password;

		#endregion

		#region プロパティ

		/*==============================*/
		//フォーム全般
		/*==============================*/

		/// <summary>
		/// フォーム位置X
		/// </summary>
		public int LocationX
		{
			get
			{
				return _LocationX;
			}
			set
			{
				_LocationX = value;
			}
		}

		/// <summary>
		/// フォーム位置Y
		/// </summary>
		public int LocationY
		{
			get
			{
				return _LocationY;
			}
			set
			{
				_LocationY = value;	
			}
		}

		/// <summary>
		/// サイズ幅
		/// </summary>
		public int SizeX
		{
			get
			{
				return _SizeX;
			}
			set
			{
				_SizeX = value;	
			}
		}

		/// <summary>
		/// サイズ高さ
		/// </summary>
		public int SizeY
		{
			get
			{
				return _SizeY;
			}
			set
			{
				_SizeY = value;	
			}
		}

		/// <summary>
		/// 最大化・最小化状態
		/// </summary>
		public int State
		{
			get
			{
				return _State;
			}
			set
			{
				_State = value;
			}
		}

		/// <summary>
		/// アプリケーション名
		/// </summary>
		public string ApplicationName
		{
			get
			{
				return _ApplicationName;
			}
			set
			{
				_ApplicationName = value;
			}
		}

		/*==============================*/
		//SQL Server関連
		/*==============================*/

		/// <summary>
		/// DataSource
		/// </summary>
		public string DataSource
		{
			get
			{
				return _DataSource;
			}
			set
			{
				_DataSource = value;	
			}
		}

		/// <summary>
		/// InitialCatalog
		/// </summary>
		public string InirialCatalog
		{
			get
			{
				return _InitialCatalog;
			}
			set
			{
				_InitialCatalog = value;	
			}
		}

		/// <summary>
		/// UserID
		/// </summary>
		public string UserID
		{
			get
			{
				return _UserID;
			}
			set
			{
				_UserID = value;	
			}
		}

		/// <summary>
		/// Password
		/// </summary>
		public string Password
		{
			get
			{
				return _Password;
			}
			set
			{
				_Password = value;
			}
		}
		#endregion

		#region コンストラクタ

		public XmlSettings()
		{
			//フォーム全般
			_LocationX = 0;
			_LocationY = 0;
			_SizeX = 1024;
			_SizeY = 768;
			_ApplicationName = "なんちゃらツール";
			//SQL Server関連
			_DataSource = "INTRA-PDC00\\INTRASQL";
			_InitialCatalog = "InTools";
			_UserID = "sa";
			_Password = "intra_intra";
		}
		#endregion

		#region インスタンス

		//XmlSettingsクラスのただひとつのインスタンス
		[NonSerialized]
		private static XmlSettings _instance;

		[System.Xml.Serialization.XmlIgnore]
		public static XmlSettings Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new XmlSettings();
				}
				return _instance;
			}
			set
			{
				_instance = value;
			}
		}

		#endregion

		#region 設定の読み書き

		/// <summary>
		/// 設定をXMLファイルから読み込み復元する
		/// </summary>
		public static void LoadFromXmlFile()
		{
			string p = GetSettingPath();
			if (File.Exists(p) == false)
			{
				return;
			}
			StreamReader sr = new StreamReader(p, new UTF8Encoding(false));
			System.Xml.Serialization.XmlSerializer xs = new System.Xml.Serialization.XmlSerializer(typeof(XmlSettings));
			//読み込んでシリアル化する
			object obj = xs.Deserialize(sr);
			sr.Close();

			Instance = (XmlSettings)obj;
		}

		/// <summary>
		/// 現在の設定をXMLファイルに保存する
		/// </summary>
		public static void SaveToXmlFile()
		{
			string p = GetSettingPath();
			if (Directory.Exists(Path.GetDirectoryName(p)) == false)
			{
				DirectoryInfo di = Directory.CreateDirectory(System.IO.Path.GetDirectoryName(p));
			}
			StreamWriter sw = new StreamWriter(p, false, new UTF8Encoding(false));
			System.Xml.Serialization.XmlSerializer xs = new System.Xml.Serialization.XmlSerializer(typeof(XmlSettings));
			//シリアル化して書き込む
			xs.Serialize(sw, Instance);
			sw.Close();
		}

		/// <summary>
		/// インスタンスの内容を保存して解放する
		/// </summary>
		public static void Dispose()
		{
			SaveToXmlFile();
			Instance = null;
		}
		#endregion

		#region プライベートメソッド
		
		/// <summary>
		/// XMLファイルの保存先を取得する
		/// </summary>
		/// <returns></returns>
		private static string GetSettingPath()
		{
			string p = Application.StartupPath + "\\Settings.xml";
			return p;
		}
		#endregion
	}
}
