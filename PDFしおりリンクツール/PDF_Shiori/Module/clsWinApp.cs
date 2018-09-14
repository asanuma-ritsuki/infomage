using System;
using System.IO;
using System.Globalization;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDF_Shiori
{
    public class AppContext : ApplicationContext
    {
		private static AppContext instance_ = new AppContext();

		private static void Main(string[] args)
		{
			
		}

		public static AppContext GetInstance()
		{
			return instance_;
		}

		/// <summary>
		/// 画面遷移時の動作
		/// </summary>
		/// <param name="mainForm"></param>
		/// <param name="toHide"></param>
		public void SetNextContext(System.Windows.Forms.Form mainForm, bool toHide = false)
		{
			System.Windows.Forms.Form tempForm = this.MainForm;
			Cursor orgCur = Cursor.Current;
			Cursor.Current = Cursors.WaitCursor;

			this.MainForm = mainForm;

			if (toHide == true)
			{
				try
				{
					if (tempForm != null)
					{
						tempForm.Hide();
					}
				}
				catch (Exception)
				{

					throw;
					//エラーメッセージを追記する
				}
			}
			else
			{
				try
				{
					tempForm.Close();
				}
				catch (Exception)
				{

					throw;
					//エラーメッセージを追記する
				}
			}

			this.MainForm.Show();
			tempForm = null;
			Cursor.Current = orgCur;
		}

    }

	/// <summary>
	/// メインルーチン
	/// </summary>
    public class clsWinApp
    {
		private static System.Threading.Mutex MyMutex;

		[STAThread]
		public static void Main()
		{
			//ビジュアルスタイルを有効にする
			Application.EnableVisualStyles();

			Initialize();
		}

		/// <summary>
		/// 例外ハンドラ
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public static void OnThreadException(Object sender, System.Threading.ThreadExceptionEventArgs e)
		{
			CatchException(e.Exception);
			Application.Exit();
		}

		/// <summary>
		/// 意図的にキャッチしない例外を全て処理する
		/// </summary>
		/// <param name="ex"></param>
		public static void CatchException(Exception ex)
		{
			string message;
			XmlSettings.LoadFromXmlFile();

			message = "システムエラーが発生しました\n\n" + "Exception=" + ex.GetType().ToString() + "\nMessage=" + ex.Message;
			MessageBox.Show(message, XmlSettings.Instance.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		public static void Initialize()
		{
			XmlSettings.LoadFromXmlFile();

			MyMutex = new System.Threading.Mutex(false, XmlSettings.Instance.ApplicationName);

			if (MyMutex.WaitOne(0, false) == false)
			{
				MessageBox.Show("多重起動はできません", XmlSettings.Instance.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			AppContext context = AppContext.GetInstance();
			context.MainForm = new frmMenu();
			Application.Run(context);
		}
    }
}
