using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace ProjectTemplate
{
	internal static class DefaultModule
	{
		/// <summary>
		/// リストボックス用マーク列挙体
		/// </summary>
		public enum ResultMark
		{
			InformationMark,
			DoingMark,
			WarningMark,
			ErrorMark
		}

		/// <summary>
		/// リストボックスに結果マーク込みで文字列を書き込む
		/// </summary>
		/// <param name="lstResult"></param>
		/// <param name="strLog"></param>
		/// <param name="resultmark"></param>
		public static void WriteLstResult(ListBox lstResult, string strLog, ResultMark resultmark = ResultMark.InformationMark)
		{
			try

			{
				string strMark = "";

				switch (resultmark)
				{
					case ResultMark.InformationMark:
						strMark = "○";
						break;
					case ResultMark.DoingMark:
						strMark = "→";
						break;
					case ResultMark.WarningMark:
						strMark = "△";
						break;
					case ResultMark.ErrorMark:
						strMark = "×";
						break;
					default:
						break;
				}
				//時間と文字列をリストボックスに表示
				lstResult.Items.Add(strMark + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "\t" + strLog);
				//リストボックスの最終行を選択
				lstResult.SetSelected(lstResult.Items.Count - 1, true);
				Application.DoEvents();
			}
			catch (Exception)
			{
				//エラーメッセージを表示
				throw;
			}
		}

		/// <summary>
		/// NULL判定
		/// </summary>
		/// <param name="text"></param>
		/// <returns></returns>
		public static bool IsNull(string text)
		{
			//null判定
			if (text == null)
			{
				return true;
			}
			//空文字判定
			else if (text.Trim() == "")
			{
				return true;
			}
			//何も引っかからなかったら
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 例外処理内容をログファイルに書き込む
		/// </summary>
		/// <param name="strExceptionMessage"></param>
		public static void OutputLogFile(string strExceptionMessage)
		{
			string strLogFile = Application.StartupPath + "\\ExceptionLog\\Exception.log";
			string strLogFolder = System.IO.Path.GetDirectoryName(strLogFile);
			Encoding enc = Encoding.GetEncoding("Shift-JIS");

			if (Directory.Exists(strLogFolder) == false)
			{
				Directory.CreateDirectory(strLogFolder);
			}

			using (StreamWriter sw = new StreamWriter(strLogFile, true, enc))
			{
				sw.WriteLine("[ " + DateTime.Now + " ]");
				sw.WriteLine(strExceptionMessage);
			}
		}

		/// <summary>
		/// 指定した検索パターンに一致するファイルを最下層まで検索し全てを返す
		/// </summary>
		/// <param name="strRootPath"></param>
		/// <param name="strPatterns"></param>
		/// <returns></returns>
		public static string[] GetFilesMostDeep(string strRootPath, string[] strPatterns)
		{
			var hStringCollection = new System.Collections.Specialized.StringCollection();
			//このディレクトリ内のすべてのファイルを検索する
			foreach (string strFilePath in System.IO.Directory.GetFiles(strRootPath, "*"))
			{
				foreach (string strPattern in strPatterns)
				{
					if ("*" + Path.GetExtension(strFilePath) == strPattern)
					{
						hStringCollection.Add(strFilePath);
					}
				}
			}

			//このディレクトリ内のすべてのサブディレクトリを検索する(再帰)
			foreach (string strDirPath in Directory.GetDirectories(strRootPath))
			{
				string[] strFilePathes = GetFilesMostDeep(strDirPath, strPatterns);
				//条件に合致したファイルが有った場合は、ArrayListに加える
				if (strFilePathes != null)
				{
					hStringCollection.AddRange(strFilePathes);
				}
			}
			//StringCollectionを1次元のString配列に変換して返す
			string[] strReturns = new string[hStringCollection.Count];
			hStringCollection.CopyTo(strReturns, 0);

			return strReturns;
		}

		/// <summary>
		/// リストボックスに表示されている文字列をログファイルとして保存する
		/// </summary>
		/// <param name="lstResult"></param>
		/// <param name="strOutputFolder"></param>
		/// <param name="strSign"></param>
		/// <param name="strSign2"></param>
		public static void OutputListLog(ListBox lstResult, string strOutputFolder, string strSign, string strSign2 = "")
		{
			string strDate = DateTime.Now.ToString("yyyyMMdd_HHmmss");
			string strOutputLog = strOutputFolder + "\\" + strDate + strSign + strSign2 + ".log";

			using (StreamWriter sw = new StreamWriter(strOutputLog, false, Encoding.GetEncoding("Shift-JIS")))
			{
				//テキストの書込み
				for (int j = 0; j <= lstResult.Items.Count - 1; j++)
				{
					sw.WriteLine(lstResult.Items[j]);
				}
			}

			WriteLstResult(lstResult, "ログ保存：" + strOutputLog);
		}

		/// <summary>
		/// 対象フォルダの容量を取得する
		/// </summary>
		/// <param name="dirInfo"></param>
		/// <returns></returns>
		public static long GetDirSize(DirectoryInfo dirInfo)
		{
			long fileSize = 0;

			foreach (FileInfo file in dirInfo.GetFiles())
			{
				fileSize += file.Length;
			}
			foreach (DirectoryInfo dir in dirInfo.GetDirectories())
			{
				fileSize += GetDirSize(dir);
			}
			return fileSize;
		}
	}
}
