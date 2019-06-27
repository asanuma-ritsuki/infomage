using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace MetaDataOutput_TMA
{
	[Serializable]
	public class XmlSettings
	{
		// 全般
		public int LocationX { get; set; }
		public int LocationY { get; set; }
		public int SizeX { get; set; }
		public int SizeY { get; set; }
		public int State { get; set; }
		public string ImageFolder { get; set; }
		public string TableData { get; set; }
		public string InputData { get; set; }
		public string OutputFolder { get; set; }
		public string HDDNo { get; set; }
		public string ShootYear { get; set; }
		public string ShootTarget { get; set; }
		public string MediaClass { get; set; }
		public string LinkClass { get; set; }
		public int ImageClass { get; set; }
		// SQL Server接続関連
		public string DataSource { get; set; }
		public string InitialCatalog { get; set; }
		public string UserID { get; set; }
		public string Password { get; set; }

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public XmlSettings()
		{
			LocationX = 0;
			LocationY = 0;
			SizeX = 800;
			SizeY = 600;
			ImageFolder = @"C:\temp\InputFolder";
			TableData = @"C:\temp\TableData.csv";
			InputData = @"C:\temp\InputData.csv";
			OutputFolder = @"C:\temp\OutputFolder\";
			HDDNo = "H2018-02";
			ShootYear = "2018";
			ShootTarget = "江戸町方史料一覧";
			MediaClass = "media_02";
			LinkClass = "collection_01";
			ImageClass = 0;

			DataSource = "INTRA-PDC00\\INTRASQL";
			InitialCatalog = "TokyoMetropolitan";
			UserID = "sa";
			Password = "intra_intra";
		}

		// XmlSettingsクラスのただ一つのインスタンス
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
