using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CreateDateCheckTool
{
	public partial class Form1 : Form
	{
		#region フォームイベント

		public Form1()
		{
			InitializeComponent();
		}

		/// <summary>
		/// フォームロード時
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Form1_Load(object sender, EventArgs e)
		{
			System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
			System.Reflection.AssemblyName asmName = assembly.GetName();
			System.Version version = asmName.Version;

			this.Text = Application.ProductName + " Ver." + version.ToString();
		}

		#endregion

		#region オブジェクトイベント

		/// <summary>
		/// テキストボックスドラッグエンター時
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void txt_DragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
			{
				e.Effect = DragDropEffects.Copy;
			}
			else
			{
				e.Effect = DragDropEffects.None;
			}
		}

		/// <summary>
		/// テキストボックスドラッグドロップ時
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void txt_DragDrop(object sender, DragEventArgs e)
		{
			string[] strFiles = (string[])e.Data.GetData(DataFormats.FileDrop, false);
			TextBox txtFile = (TextBox)sender;

			if (System.IO.Directory.Exists(strFiles[0]))
			{
				txtFile.Text = strFiles[0];
			}
			else if (System.IO.File.Exists(strFiles[0]))
			{
				txtFile.Text = System.IO.Path.GetDirectoryName(strFiles[0]);
			}
		}

		/// <summary>
		/// 開始ボタン押下時
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnStart_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("不正日付を本日に変更します\nよろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
			{
				return;
			}
			else
			{
				// リストボックスの初期化
				this.lstResult.Items.Clear();
			}

			DefaultModule dm = new DefaultModule();
			dm.WriteLstResult(this.lstResult, "不正日付チェック開始");

			string[] exts = new string[3] { "*.jpg", "*.tif", "*.pdf" };
			string[] strFiles = dm.GetFilesMostDeep(this.txtTargetFolder.Text, exts);
			int iCount = 0;
			foreach (string strFile in strFiles)
			{
				iCount += 1;
				// 作成日、更新日、アクセス日を取得する
				CheckDate(strFile, 1);  // 作成日
				CheckDate(strFile, 2);  // 更新日
				CheckDate(strFile, 3);	// 最終アクセス日

			}

			dm.WriteLstResult(this.lstResult, "不正日付チェック終了");
			dm.WriteLstResult(this.lstResult, iCount + "件のファイルをチェックしました");
			MessageBox.Show("処理が終了しました", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information);
			dm.OutputListLog(this.lstResult, this.txtLogFolder.Text, "出力_");
		}

		#endregion

		#region プライベートメソッド

		/// <summary>
		/// 日付のチェック
		/// 未来日だった場合は本日を設定する
		/// 過去1年以上前の日付だった場合は本日を設定する
		/// </summary>
		/// <param name="strFile"></param>
		/// <param name="iDateDiv">1：作成日、2：更新日、3：最終アクセス日</param>
		private void CheckDate(string strFile, int iDateDiv)
		{
			DefaultModule dm = new DefaultModule();

			string msg = "";
			switch (iDateDiv)
			{
				case 1:
					msg = "作成日";
					try
					{
						// 作成日を取得する
						DateTime dtDate = System.IO.File.GetCreationTime(strFile);
						// 取得した日付が未来日かどうか
						if (dtDate > DateTime.Now)
						{
							// 未来日だった場合は本日を設定する
							System.IO.File.SetCreationTime(strFile, DateTime.Now);
							dm.WriteLstResult(this.lstResult, strFile, DefaultModule.ResultMark.WarningMark);
							dm.WriteLstResult(this.lstResult, "「" + msg + "」が未来日[" + dtDate.ToString("yyyy/MM/dd") + "]", DefaultModule.ResultMark.WarningMark);
						}
						else if (dtDate < DateTime.Now.AddYears(-1))
						{
							// 過去1年以上前の日付だった場合本日を設定する
							System.IO.File.SetCreationTime(strFile, DateTime.Now);
							dm.WriteLstResult(this.lstResult, strFile, DefaultModule.ResultMark.WarningMark);
							dm.WriteLstResult(this.lstResult, "「" + msg + "」が過去1年以上経過[" + dtDate.ToString("yyyy/MM/dd") + "]", DefaultModule.ResultMark.WarningMark);
						}
					}
					catch (System.ArgumentOutOfRangeException)
					{
						// エラーが発生したら作成日を本日に設定する
						System.IO.File.SetCreationTime(strFile, DateTime.Now);
						dm.WriteLstResult(this.lstResult, strFile, DefaultModule.ResultMark.WarningMark);
						dm.WriteLstResult(this.lstResult, "「" + msg + "」が読み取れないため本日に設定", DefaultModule.ResultMark.WarningMark);
					}
					break;
				case 2:
					msg = "更新日";
					try
					{
						// 作成日を取得する
						DateTime dtDate = System.IO.File.GetLastWriteTime(strFile);
						// 取得した日付が未来日かどうか
						if (dtDate > DateTime.Now)
						{
							// 未来日だった場合は本日を設定する
							System.IO.File.SetLastWriteTime(strFile, DateTime.Now);
							dm.WriteLstResult(this.lstResult, strFile, DefaultModule.ResultMark.WarningMark);
							dm.WriteLstResult(this.lstResult, "「" + msg + "」が未来日[" + dtDate.ToString("yyyy/MM/dd") + "]", DefaultModule.ResultMark.WarningMark);
						}
						else if (dtDate < DateTime.Now.AddYears(-1))
						{
							// 過去1年以上前の日付だった場合本日を設定する
							System.IO.File.SetLastWriteTime(strFile, DateTime.Now);
							dm.WriteLstResult(this.lstResult, strFile, DefaultModule.ResultMark.WarningMark);
							dm.WriteLstResult(this.lstResult, "「" + msg + "」が過去1年以上経過[" + dtDate.ToString("yyyy/MM/dd") + "]", DefaultModule.ResultMark.WarningMark);
						}
					}
					catch (System.ArgumentOutOfRangeException)
					{
						// エラーが発生したら作成日を本日に設定する
						System.IO.File.SetLastWriteTime(strFile, DateTime.Now);
						dm.WriteLstResult(this.lstResult, strFile, DefaultModule.ResultMark.WarningMark);
						dm.WriteLstResult(this.lstResult, "「" + msg + "」が読み取れないため本日に設定", DefaultModule.ResultMark.WarningMark);
					}
					break;
				case 3:
					msg = "最終アクセス日";
					try
					{
						// 作成日を取得する
						DateTime dtDate = System.IO.File.GetLastAccessTime(strFile);
						// 取得した日付が未来日かどうか
						if (dtDate > DateTime.Now)
						{
							// 未来日だった場合は本日を設定する
							System.IO.File.SetLastAccessTime(strFile, DateTime.Now);
							dm.WriteLstResult(this.lstResult, strFile, DefaultModule.ResultMark.WarningMark);
							dm.WriteLstResult(this.lstResult, "「" + msg + "」が未来日[" + dtDate.ToString("yyyy/MM/dd") + "]", DefaultModule.ResultMark.WarningMark);
						}
						else if (dtDate < DateTime.Now.AddYears(-1))
						{
							// 過去1年以上前の日付だった場合本日を設定する
							System.IO.File.SetLastAccessTime(strFile, DateTime.Now);
							dm.WriteLstResult(this.lstResult, strFile, DefaultModule.ResultMark.WarningMark);
							dm.WriteLstResult(this.lstResult, "「" + msg + "」が過去1年以上経過[" + dtDate.ToString("yyyy/MM/dd") + "]", DefaultModule.ResultMark.WarningMark);
						}
					}
					catch (System.ArgumentOutOfRangeException)
					{
						// エラーが発生したら作成日を本日に設定する
						System.IO.File.SetLastAccessTime(strFile, DateTime.Now);
						dm.WriteLstResult(this.lstResult, strFile, DefaultModule.ResultMark.WarningMark);
						dm.WriteLstResult(this.lstResult, "「" + msg + "」が読み取れないため本日に設定", DefaultModule.ResultMark.WarningMark);
					}
					break;
			}

		}

		#endregion

	}
}
