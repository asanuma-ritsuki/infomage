using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic.FileIO;
using ImageMagick;

namespace MetaDataOutput_TMA.Forms
{
	public partial class frmMain : Form
	{
		public frmMain()
		{
			InitializeComponent();
		}

		#region フォームイベント

		/// <summary>
		/// フォームロード時
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void frmMain_Load(object sender, EventArgs e)
		{
			this.Text = Application.ProductName + " Ver.";
			this.Text += Application.ProductVersion.ToString();

			Initialization();
		}

		/// <summary>
		/// フォームクロージング
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (MessageBox.Show("アプリケーションを終了します" + Environment.NewLine + "よろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
			{
				e.Cancel = true;
			}
			else
			{
				Finalization();
			}
		}

		#endregion

		#region オブジェクトイベント

		/// <summary>
		/// フォルダドラッグイベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void txtFolder_DragEnter(object sender, DragEventArgs e)
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
		/// ファイルドラッグイベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void txtFile_DragEnter(object sender, DragEventArgs e)
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
		/// フォルダドロップイベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void txtFolder_DragDrop(object sender, DragEventArgs e)
		{
			string[] strFiles = (string[])e.Data.GetData(DataFormats.FileDrop, false);
			TextBox txtFile = (TextBox)sender;

			if (System.IO.File.Exists(strFiles[0]))
			{
				txtFile.Text = System.IO.Path.GetDirectoryName(strFiles[0]);
			}
			else
			{
				if (System.IO.Directory.Exists(strFiles[0]))
				{
					txtFile.Text = strFiles[0];
				}
			}
		}

		/// <summary>
		/// ファイルドロップイベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void txtFile_DragDrop(object sender, DragEventArgs e)
		{
			string[] strFiles = (string[])e.Data.GetData(DataFormats.FileDrop, false);
			TextBox txtFile = (TextBox)sender;

			if (System.IO.File.Exists(strFiles[0]))
			{
				if (System.IO.Path.GetExtension(strFiles[0]) == ".csv")
				{
					txtFile.Text = strFiles[0];
				}
			}
		}

		/// <summary>
		/// チェックボタン押下時
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnCheck_Click(object sender, EventArgs e)
		{
			if (InputCheck() == false)
			{
				return;
			}

			if (MessageBox.Show("データチェックを開始します" + Environment.NewLine + "よろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
			{
				return;
			}

			// 事前情報の列挙
			DefaultModule.WriteLstResult(this.lstResult, "画像フォルダ：" + this.txtImageFolder.Text);
			DefaultModule.WriteLstResult(this.lstResult, "テーブルデータ：" + this.txtTableData.Text);
			DefaultModule.WriteLstResult(this.lstResult, "入力データ：" + this.txtInputData.Text);
			DefaultModule.WriteLstResult(this.lstResult, "出力フォルダ：" + this.txtOutputFolder.Text);
			DefaultModule.WriteLstResult(this.lstResult, "HDD番号：" + this.txtHDDNo.Text);
			DefaultModule.WriteLstResult(this.lstResult, "撮影年：" + this.txtShootYear.Text);
			DefaultModule.WriteLstResult(this.lstResult, "撮影対象：" + this.txtShootTarget.Text);
			DefaultModule.WriteLstResult(this.lstResult, "分類：" + this.txtMediaClass.Text);
			DefaultModule.WriteLstResult(this.lstResult, "リンク先分類：" + this.txtLinkClass.Text);
			string ext = "";
			if (this.cmbImageClass.SelectedIndex == 0){	ext = "TIFF"; }
			else { ext = "JPEG"; }
			DefaultModule.WriteLstResult(this.lstResult, "画像種別：" + ext);

			string strSQL = "";
			SQLProcess sqlProcess = new SQLProcess();
			DateTime dtNow = DateTime.Now;
			string strProgressLog = this.txtOutputFolder.Text + "\\データチェック_進捗ログ_" + dtNow.ToString("yyyyMMdd_HHmmss") + ".log";
			string strErrorLog = this.txtOutputFolder.Text + "\\データチェック_エラーログ_" + dtNow.ToString("yyyyMMdd_HHmmss") + ".log";
			var enc = new System.Text.UTF8Encoding(false);	// UTF-8 BOMなし指定

			try
			{
				// DBテーブルの初期化
				strSQL = "DELETE FROM T_テーブルデータ";
				sqlProcess.DB_UPDATE(strSQL);
				DefaultModule.WriteLstResult(this.lstResult, "テーブルデータ：削除完了");
				strSQL = "DELETE FROM T_入力データ";
				sqlProcess.DB_UPDATE(strSQL);
				DefaultModule.WriteLstResult(this.lstResult, "入力データ：削除完了");
				strSQL = "DELETE FROM T_ファイル一覧";
				sqlProcess.DB_UPDATE(strSQL);
				DefaultModule.WriteLstResult(this.lstResult, "ファイル一覧：削除完了");

				// テーブルデータインポート
				DefaultModule.WriteLstResult(this.lstResult, "[テーブルデータ]インポート開始");

				using (var parser = new TextFieldParser(this.txtTableData.Text, Encoding.UTF8, false))
				{
					parser.Delimiters = new string[] { "\t" };
					// 先頭行（ヘッダ）を読み飛ばす
					parser.ReadFields();

					int iTDID = 0;
					while (!parser.EndOfData)
					{
						iTDID += 1;
						strSQL = "INSERT INTO T_テーブルデータ(TDID, 資料ID, 請求番号, 資料名, 撮影コマ数) VALUES(";
						int iCount = 0;
						var rows = parser.ReadFields();
						foreach (var row in rows)
						{
							if (iCount == 0)
							{
								strSQL += iTDID.ToString(); // TDID
								strSQL += ", N'" + row + "'";	// 資料ID
							}
							else if(iCount == rows.Length - 1)
							{
								// 最終カラム
								strSQL += ", " + row + ")";
							}
							else
							{
								strSQL += ", N'" + row + "'";
							}
							iCount += 1;
						}
						sqlProcess.DB_UPDATE(strSQL);
					}
					DefaultModule.WriteLstResult(this.lstResult, "インポートレコード：" + iTDID.ToString());
				}
				DefaultModule.WriteLstResult(this.lstResult, "[テーブルデータ]インポート完了");

				// 入力データインポート
				DefaultModule.WriteLstResult(this.lstResult, "[入力データ]インポート開始");

				using (var parser = new TextFieldParser(this.txtInputData.Text, Encoding.UTF8, false))
				{
					parser.Delimiters = new string[] { "\t" };
					// 先頭行（ヘッダ）を読み飛ばす
					parser.ReadFields();

					int iInputID = 0;
					while (!parser.EndOfData)
					{
						iInputID += 1;
						strSQL = "INSERT INTO T_入力データ(入力ID, ファイル名, 分割撮影の有無, 部分撮影の有無, 付属物, 解体等の処置の有無, ";
						strSQL += "ターゲットの有無, 備考, ファイルID) VALUES(";
						int iCount = 0;
						var rows = parser.ReadFields();
						foreach (var row in rows)
						{
							if (iCount == 0)
							{
								strSQL += iInputID.ToString();  // 入力ID
								strSQL += ", N'" + row + "'";	// ファイル名
							}
							else if (iCount == rows.Length - 1)
							{
								// 最終カラム（ファイルID）
								strSQL += ", N'" + row + "', 0)";
							}
							else
							{
								strSQL += ", N'" + row + "'";
							}
							iCount += 1;
						}
						sqlProcess.DB_UPDATE(strSQL);
					}
					DefaultModule.WriteLstResult(this.lstResult, "インポートレコード：" + iInputID.ToString());
				}
				DefaultModule.WriteLstResult(this.lstResult, "[入力データ]インポート完了");

				// ファイル一覧取得
				DefaultModule.WriteLstResult(this.lstResult, "[ファイル一覧]取得開始");
				string[] strExt = null;
				if (this.cmbImageClass.SelectedIndex == 0) { strExt = new string[] { "*.tif" }; }
				else { strExt = new string[] { "*.jpg" }; }
				string[] strFiles = DefaultModule.GetFilesMostDeep(this.txtImageFolder.Text, strExt);
				int iFileID = 0;
				// 取得したフルパスを\マークでバラバラにして配列に格納する
				foreach (var strFile in strFiles)
				{
					iFileID += 1;
					// 親パスを除去
					string strFileWithoutParent = strFile.Replace(this.txtImageFolder.Text + "\\", "");
					string[] strFolders = strFileWithoutParent.Split(new char[] { '\\' });
					strSQL = "INSERT INTO T_ファイル一覧(ファイルID, ファイルパス, 第1階層, 最終階層, ファイル名, TDID) VALUES(";
					strSQL += iFileID.ToString();
					strSQL += ", N'" + strFile + "'";
					strSQL += ", N'" + strFolders[0] + "'";  // 第1階層
					strSQL += ", N'" + strFolders[strFolders.Length - 2] + "'";  // 最終階層
					strSQL += ", N'" + strFolders[strFolders.Length - 1] + "'";  // ファイル名
					strSQL += ", 0)";
					sqlProcess.DB_UPDATE(strSQL);
				}
				DefaultModule.WriteLstResult(this.lstResult, "インポートレコード：" + iFileID.ToString());
				DefaultModule.WriteLstResult(this.lstResult, "[ファイル一覧]取得完了");

				string strWriteLine = "";
				using (var swErrLog = new System.IO.StreamWriter(strErrorLog, false, enc))
				{
					// テーブルデータとファイル一覧の紐付け、及びファイル連番の妥当性確認
					// 資料ID、請求番号でファイル一覧と当てる
					bool blnError = false;	// エラー検知用フラグ
					DefaultModule.WriteLstResult(this.lstResult, "[ファイル一覧]ファイル存在確認、連番チェック開始");
					strSQL = "SELECT TDID, 資料ID, 請求番号, 撮影コマ数 FROM T_テーブルデータ ";
					strSQL += "ORDER BY TDID";
					DataTable dt = sqlProcess.DB_SELECT_DATATABLE(strSQL);
					for (int iRow = 0; iRow < dt.Rows.Count; iRow++)
					{
						strSQL = "SELECT ファイルID, 最終階層, ファイル名 FROM T_ファイル一覧 ";
						strSQL += "WHERE ファイル名 LIKE '" + dt.Rows[iRow]["資料ID"].ToString() + "_%' ";
						strSQL += "AND 最終階層 = '" + dt.Rows[iRow]["請求番号"].ToString() + "' ";
						strSQL += "ORDER BY ファイル名";
						DataTable dtFileList = sqlProcess.DB_SELECT_DATATABLE(strSQL);
						// 資料ID、請求番号でファイルが1件も当たらなかったらエラー
						if (dtFileList.Rows.Count == 0)
						{
							DefaultModule.WriteLstResult(this.lstResult, "[" + dt.Rows[iRow]["資料ID"].ToString() + "][" + dt.Rows[iRow]["請求番号"].ToString() + "] ×該当ファイルなし", DefaultModule.ResultMark.ErrorMark);
							strWriteLine = "該当ファイルなし：" + "[" + dt.Rows[iRow]["資料ID"].ToString() + "][" + dt.Rows[iRow]["請求番号"].ToString() + "]";
							swErrLog.WriteLine(strWriteLine);
							blnError = true;
							continue;
						}

						// ファイル数の確認
						if ((int)dt.Rows[iRow]["撮影コマ数"] == dtFileList.Rows.Count)
						{
							// 合致していたらファイル一覧にTDIDを付与
							DefaultModule.WriteLstResult(this.lstResult, "[" + dt.Rows[iRow]["資料ID"].ToString() + "][" + dt.Rows[iRow]["請求番号"].ToString() + "] ○ファイル総数合致：" + dt.Rows[iRow]["撮影コマ数"].ToString());
							strSQL = "UPDATE T_ファイル一覧 SET TDID = " + dt.Rows[iRow]["TDID"].ToString() + " ";
							strSQL += "WHERE ファイル名 LIKE '" + dt.Rows[iRow]["資料ID"].ToString() + "_%' ";
							strSQL += "AND 最終階層 = '" + dt.Rows[iRow]["請求番号"].ToString() + "'";
							sqlProcess.DB_UPDATE(strSQL);
							for (int iFileList = 0; iFileList < dtFileList.Rows.Count; iFileList++)
							{
								// ファイル名をバラバラにして4桁数値を取り出す
								string[] strFileItems = dtFileList.Rows[iFileList]["ファイル名"].ToString().Split(new char[] { '_', '.' });
								// 取り出した4桁数値をint化してiFileList + 1を比較
								if ((iFileList + 1) != int.Parse(strFileItems[1]))
								{
									// 数値が合致しなかったらエラー
									DefaultModule.WriteLstResult(this.lstResult, "[" + dt.Rows[iRow]["資料ID"].ToString() + "][" + dt.Rows[iRow]["請求番号"].ToString() + "] ×連番チェック不備：" + dtFileList.Rows[iFileList]["ファイル名"].ToString(), DefaultModule.ResultMark.ErrorMark);
									strWriteLine = "連番チェック不備：" + "[" + dt.Rows[iRow]["資料ID"].ToString() + "][" + dt.Rows[iRow]["請求番号"].ToString() + "]" + dtFileList.Rows[iFileList]["ファイル名"].ToString();
									swErrLog.WriteLine(strWriteLine);
									// 2019/03/25
									// 連番エラーログは出力するがそのまま流せるようにする
									//blnError = true;
								}
							}
						}
						else
						{
							// 合致しなかったらスキップ
							DefaultModule.WriteLstResult(this.lstResult, "[" + dt.Rows[iRow]["資料ID"].ToString() + "][" + dt.Rows[iRow]["請求番号"].ToString() + "] ×ファイル総数相違：撮影コマ数" + dt.Rows[iRow]["撮影コマ数"].ToString(), DefaultModule.ResultMark.ErrorMark);
							DefaultModule.WriteLstResult(this.lstResult, "連番チェックをスキップします", DefaultModule.ResultMark.ErrorMark);
							strWriteLine = "撮影コマ数相違：" + "[" + dt.Rows[iRow]["資料ID"].ToString() + "][" + dt.Rows[iRow]["請求番号"].ToString() + "]撮影コマ数：" + dt.Rows[iRow]["撮影コマ数"].ToString();
							swErrLog.WriteLine(strWriteLine);
							blnError = true;
						}
					}
					if (blnError)
					{
						// ファイル数、ファイル連番不備
						// 処理中断
						MessageBox.Show("撮影コマ数の相違、またはファイル連番の不備が発生しています" + Environment.NewLine + "エラーログを参照して修正後、再度データチェックを行ってください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
						DefaultModule.WriteLstResult(this.lstResult, "撮影コマ数、ファイル連番の不備発生", DefaultModule.ResultMark.ErrorMark);
						DefaultModule.OutputListLog(this.lstResult, strProgressLog, Encoding.GetEncoding("Shift-JIS"));
						return;
					}
					blnError = false;
					DefaultModule.WriteLstResult(this.lstResult, "[ファイル一覧]ファイル存在確認、連番チェック完了");

					DefaultModule.WriteLstResult(this.lstResult, "[入力データ]ファイル存在チェック開始");
					// 入力データとファイル一覧の紐付け
					strSQL = "SELECT 入力ID, ファイル名 FROM T_入力データ ";
					strSQL += "ORDER BY 入力ID";
					dt = sqlProcess.DB_SELECT_DATATABLE(strSQL);

					for (int iRow = 0; iRow < dt.Rows.Count; iRow++)
					{
						// ファイル名はユニークのはずなので1レコードのみ引っかかるはず
						strSQL = "SELECT ファイルID FROM T_ファイル一覧 ";
						strSQL += "WHERE ファイル名 LIKE '" + dt.Rows[iRow]["ファイル名"].ToString() + "%'";
						var dtFileID = sqlProcess.DB_SELECT_DATATABLE(strSQL);
						if (dtFileID.Rows.Count == 0)
						{
							// 引っかからなかった場合はエラー
							DefaultModule.WriteLstResult(this.lstResult, "入力データ内ファイル存在エラー：" + dt.Rows[iRow]["ファイル名"].ToString(), DefaultModule.ResultMark.ErrorMark);
							strWriteLine = "入力データ内ファイル存在エラー：" + dt.Rows[iRow]["ファイル名"].ToString();
							swErrLog.WriteLine(strWriteLine);
							blnError = true;
						}
						else
						{
							// 引っかかった場合は、入力データにファイルIDを書き込む
							strSQL = "UPDATE T_入力データ SET ファイルID = " + dtFileID.Rows[0]["ファイルID"].ToString() + " ";
							strSQL += "WHERE 入力ID = " + dt.Rows[iRow]["入力ID"].ToString();
							sqlProcess.DB_UPDATE(strSQL);
						}
					}

					// T_入力データ内のファイルIDが0のレコードが合った場合はエラーとして処理を中断する
					strSQL = "SELECT COUNT(入力ID) FROM T_入力データ ";
					strSQL += "WHERE ファイルID = 0";
					if ((int)sqlProcess.DB_EXECUTE_SCALAR(strSQL) > 0)
					{
						// 1つ以上のエラーがあるので処理中断
						MessageBox.Show("入力データ内のファイルが存在しません" + Environment.NewLine + "エラーログを参照して修正後、再度データチェックを行ってください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
						DefaultModule.WriteLstResult(this.lstResult, "入力データ内ファイル存在不備", DefaultModule.ResultMark.ErrorMark);
						DefaultModule.OutputListLog(this.lstResult, strProgressLog, Encoding.GetEncoding("Shift-JIS"));
						return;
					}
					DefaultModule.WriteLstResult(this.lstResult, "[入力データ]ファイル存在チェック完了");
				}

				DefaultModule.WriteLstResult(this.lstResult, "データチェック完了");
				MessageBox.Show("データチェックが完了しました" + Environment.NewLine + "出力処理を行ってください", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information);
				DefaultModule.OutputListLog(this.lstResult, strProgressLog, Encoding.GetEncoding("Shift-JIS"));

			}
			catch (Exception ex)
			{
				DefaultModule.OutputLogFile("発生場所：" + System.Reflection.MethodBase.GetCurrentMethod() + Environment.NewLine + ex.Message + Environment.NewLine + ex.StackTrace);
				MessageBox.Show("発生場所：" + System.Reflection.MethodBase.GetCurrentMethod() + Environment.NewLine + ex.Message + Environment.NewLine + ex.StackTrace, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
				MessageBox.Show("SQL文：" + strSQL, "確認", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			finally
			{
				sqlProcess.Close();
			}

		}

		/// <summary>
		/// 出力ボタン押下時
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnOutput_Click(object sender, EventArgs e)
		{
			if (InputCheck() == false)
			{
				return;
			}

			if (MessageBox.Show("データの出力を開始します" + Environment.NewLine + "よろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
			{
				return;
			}

			// 事前情報の列挙
			DefaultModule.WriteLstResult(this.lstResult, "画像フォルダ：" + this.txtImageFolder.Text);
			DefaultModule.WriteLstResult(this.lstResult, "テーブルデータ：" + this.txtTableData.Text);
			DefaultModule.WriteLstResult(this.lstResult, "入力データ：" + this.txtInputData.Text);
			DefaultModule.WriteLstResult(this.lstResult, "出力フォルダ：" + this.txtOutputFolder.Text);
			DefaultModule.WriteLstResult(this.lstResult, "HDD番号：" + this.txtHDDNo.Text);
			DefaultModule.WriteLstResult(this.lstResult, "撮影年：" + this.txtShootYear.Text);
			DefaultModule.WriteLstResult(this.lstResult, "撮影対象：" + this.txtShootTarget.Text);
			DefaultModule.WriteLstResult(this.lstResult, "分類：" + this.txtMediaClass.Text);
			DefaultModule.WriteLstResult(this.lstResult, "リンク先分類：" + this.txtLinkClass.Text);
			string ext = "";
			if (this.cmbImageClass.SelectedIndex == 0) { ext = "TIFF"; }
			else { ext = "JPEG"; }
			DefaultModule.WriteLstResult(this.lstResult, "画像種別：" + ext);

			string strSQL = "";
			SQLProcess sqlProcess = new SQLProcess();
			DateTime dtNow = DateTime.Now;
			string strProgressLog = this.txtOutputFolder.Text + "\\CSV出力_進捗ログ_" + dtNow.ToString("yyyyMMdd_HHmmss") + ".log";
			var enc = new System.Text.UTF8Encoding(false);  // UTF-8 BOMなし指定

			try
			{
				// T_管理データの削除
				strSQL = "DELETE FROM T_管理データ";
				sqlProcess.DB_UPDATE(strSQL);
				DefaultModule.WriteLstResult(this.lstResult, "管理データ削除完了");
				DefaultModule.WriteLstResult(this.lstResult, "CSVファイル作成開始");

				// 必要な情報を、テーブルデータ、ファイル一覧、入力データより取得する
				strSQL = "SELECT T1.TDID, T2.ファイルID, T2.ファイルパス, T2.第１階層 AS 'BD-R DLボリューム', T2.ファイル名 AS オリジナルファイル名, ";
				strSQL += "T1.請求番号, T1.資料名 AS タイトル, T1.資料ID AS リンクキー項目1, ";
				strSQL += "ISNULL(T3.分割撮影の有無, '') AS 分割撮影の有無, ";
				strSQL += "ISNULL(T3.部分撮影の有無, '') AS 部分撮影の有無, ";
				strSQL += "ISNULL(T3.付属物, '') AS 付属物, ";
				strSQL += "ISNULL(T3.解体等の処置の有無, '') AS 解体等の処置の有無, ";
				strSQL += "ISNULL(T3.ターゲットの有無, '') AS ターゲットの有無, ";
				strSQL += "ISNULL(T3.備考, '') AS 備考 ";
				strSQL += "FROM T_テーブルデータ AS T1 INNER JOIN ";
				strSQL += "T_ファイル一覧 AS T2 ON T1.TDID = T2. TDID LEFT OUTER JOIN ";
				strSQL += "T_入力データ AS T3 ON T2.ファイルID = T3.ファイルID ";
				strSQL += "ORDER BY T1.TDID, T2.ファイルID";
				DataTable dt = sqlProcess.DB_SELECT_DATATABLE(strSQL);

				string strBeforeCSVPath = "";   // 一つ前のCSVファイルパスを保持してループごとに同一ならインクリメント、相違なら初期化を行う
				string strOutputCSVPath = "";
				int iCount = 0;
				int iFileCount = 0;

				for (int iRow = 0; iRow < dt.Rows.Count; iRow++)
				{
					string strOutputFolder = this.txtOutputFolder.Text + "\\" + ext;
					if (System.IO.Directory.Exists(strOutputFolder) == false)
					{
						// 保存フォルダが存在しなかったら作成する
						DefaultModule.WriteLstResult(this.lstResult, "フォルダ作成：" + strOutputFolder);
						System.IO.Directory.CreateDirectory(strOutputFolder);
					}
					string strOutputCSV = "";
					if (ext == "TIFF") { strOutputCSV = "01"; }
					else { strOutputCSV = "02"; }
					strOutputCSV += dt.Rows[iRow]["BD-R DLボリューム"].ToString() + ".csv";
					// 画像情報取得
					int iFileSize = 0;
					int iWidth = 0;
					int iHeight = 0;
					GetImageSize(dt.Rows[iRow]["ファイルパス"].ToString(), ref iFileSize, ref iWidth, ref iHeight);
					// CSVファイルに書き込み
					// カウンタの運用
					strOutputCSVPath = strOutputFolder + "\\" + strOutputCSV;
					if (strOutputCSVPath == strBeforeCSVPath)
					{
						// 同一ならインクリメント
						iCount += 1;
					}
					else
					{
						// 相違なら件数を出力して１に初期化
						// ループ１回目は出力しない
						if (iRow != 0)
						{
							// 最終レコードの場合に出力
							DefaultModule.WriteLstResult(this.lstResult, strBeforeCSVPath + "：" + iCount + "レコード");
						}
						// ヘッダ情報を新規CSVファイルに書き込む
						string strHeader = "HDD番号,BD-R DLボリューム名,システムID,版数,区分,分類,登録日時,更新日時,登録者,更新者,ステータス,オリジナルファイル名,ファイルタイプ,コメント,";
						strHeader += "管理番号,メディア分類,請求番号,タイトル,撮影年(西暦),著作権情報,備考,ファイルサイズ,寸法(縦),寸法(横),公開フラグ,リンク先分類名,リンクキー項目1,";
						strHeader += "分割撮影の有無,部分撮影の有無,付属物,解体等の処置の有無,ターゲットの有無,備考";
						using (var sw = new System.IO.StreamWriter(strOutputCSVPath, true, enc))
						{
							sw.WriteLine(strHeader);
						}
						iFileCount += 1;
						iCount = 1;
					}

					using (var sw = new System.IO.StreamWriter(strOutputCSVPath, true, enc))
					{
						string strWriteLine = "";
						strWriteLine += this.txtHDDNo.Text;	// HDD番号
						strWriteLine += "," + dt.Rows[iRow]["BD-R DLボリューム"].ToString();
						strWriteLine += ",,1,media";    // システムID、版数、区分
						strWriteLine += "," + this.txtMediaClass.Text;  // 分類
						strWriteLine += ",,,,,本登録"; // 登録日時、更新日時、登録者、更新者、ステータス
						strWriteLine += "," + dt.Rows[iRow]["オリジナルファイル名"].ToString();
						strWriteLine += ",,,";  // ファイルタイプ、コメント、管理番号
						strWriteLine += ",静止画像";    // メディア分類
						strWriteLine += "," + dt.Rows[iRow]["請求番号"].ToString();
						strWriteLine += "," + dt.Rows[iRow]["タイトル"].ToString();
						strWriteLine += "," + this.txtShootYear.Text;
						strWriteLine += ",";    // 著作権情報
						strWriteLine += "," + this.txtShootTarget.Text; // 備考（撮影対象）
						strWriteLine += "," + iFileSize.ToString(); // ファイルサイズ
						strWriteLine += "," + iHeight.ToString();   // 高さ
						strWriteLine += "," + iWidth.ToString();    // 幅
						strWriteLine += ",インターネット公開";   // 公開フラグ
						strWriteLine += "," + this.txtLinkClass.Text;   // リンク先分類名
						strWriteLine += "," + dt.Rows[iRow]["リンクキー項目1"].ToString();
						strWriteLine += "," + dt.Rows[iRow]["分割撮影の有無"].ToString();
						strWriteLine += "," + dt.Rows[iRow]["部分撮影の有無"].ToString();
						strWriteLine += "," + dt.Rows[iRow]["付属物"].ToString();
						strWriteLine += "," + dt.Rows[iRow]["解体等の処置の有無"].ToString();
						strWriteLine += "," + dt.Rows[iRow]["ターゲットの有無"].ToString();
						strWriteLine += "," + dt.Rows[iRow]["備考"].ToString();
						sw.WriteLine(strWriteLine);
					}
					// 今回のCSVパスを前回CSVパスに上書き
					strBeforeCSVPath = strOutputCSVPath;
				}
				// 最終のCSVの件数を出力
				DefaultModule.WriteLstResult(this.lstResult, strOutputCSVPath + "：" + iCount + "レコード");

				DefaultModule.WriteLstResult(this.lstResult, "CSVファイル作成完了");
				DefaultModule.OutputListLog(this.lstResult, strProgressLog, Encoding.GetEncoding("Shift-JIS"));
				MessageBox.Show("CSVファイルの作成が完了しました", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information);

			}
			catch (Exception ex)
			{
				DefaultModule.OutputLogFile("発生場所：" + System.Reflection.MethodBase.GetCurrentMethod() + Environment.NewLine + ex.Message + Environment.NewLine + ex.StackTrace);
				MessageBox.Show("発生場所：" + System.Reflection.MethodBase.GetCurrentMethod() + Environment.NewLine + ex.Message + Environment.NewLine + ex.StackTrace, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
				MessageBox.Show("SQL文：" + strSQL, "確認", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			finally
			{
				sqlProcess.Close();
			}
		}

        /// <summary>
        /// 再作成ボタン押下時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReRun_Click(object sender, EventArgs e)
        {
            // 入力データ、出力フォルダの存在チェック
            if (System.IO.File.Exists(this.txtInputData.Text) == false)
            {
                MessageBox.Show("存在する入力データを指定してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (System.IO.Directory.Exists(this.txtOutputFolder.Text) == false)
            {
                MessageBox.Show("存在する出力フォルダを指定してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show("CSVファイルの再作成を開始します" + Environment.NewLine + "よろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            // 事前情報の列挙
            DefaultModule.WriteLstResult(this.lstResult, "入力データ：" + this.txtInputData.Text);
            DefaultModule.WriteLstResult(this.lstResult, "出力フォルダ：" + this.txtOutputFolder.Text);
            string ext = "";
            string extNo = "";  // ファイル名の先頭不付与する2桁数値
            if (this.cmbImageClass.SelectedIndex == 0) { ext = "TIFF"; extNo = "01"; }
            else { ext = "JPEG"; extNo = "02"; }
            DefaultModule.WriteLstResult(this.lstResult, "画像種別：" + ext);

            var enc = new System.Text.UTF8Encoding(false);  // UTF-8 BOMなし指定

            try
            {
                // 入力データの2項目目(BD-R DLボリューム名)単位でCSVファイルを作成する
                using (var parser = new TextFieldParser(this.txtInputData.Text, Encoding.UTF8, false))
                {
                    parser.Delimiters = new string[] { "\t" };
                    var rows = parser.ReadFields();
                    string strHeader = "";
                    string strWriteLine = "";
                    // ヘッダは実データより取得する
                    int iCol = 0;
                    foreach (var row in rows)
                    {
                        if (iCol == 0)
                        {
                            strHeader = row;
                            iCol += 1;
                        }
                        else
                        {
                            strHeader += "," + row;
                            iCol += 1;
                        }
                    }

                    int iCount = 0;
                    while (!parser.EndOfData)
                    {
                        iCount += 1;
                        rows = parser.ReadFields();
                        // レコード単位で書き込み先のファイル名を作成して、存在していなかった場合はヘッダを書き込む
                        string strOutCSV = this.txtOutputFolder.Text + "\\" + extNo + rows[1] + ".csv";
                        if (System.IO.File.Exists(strOutCSV) == false)
                        {
                            // 存在していなかった
                            using (var sw = new System.IO.StreamWriter(strOutCSV, true, enc))
                            {
                                sw.WriteLine(strHeader);
                            }
                        }
                        // 実データの書き込み
                        using (var sw = new System.IO.StreamWriter(strOutCSV, true, enc))
                        {
                            iCol = 0;
                            foreach (var row in rows)
                            {
                                if (iCol == 0)
                                {
                                    strWriteLine = row;
                                    iCol += 1;
                                }
                                else
                                {
                                    strWriteLine += "," + row;
                                    iCol += 1;
                                }
                            }
                            sw.WriteLine(strWriteLine);
                        }
                    }
                    DefaultModule.WriteLstResult(this.lstResult, iCount + "レコードを処理しました");
                    MessageBox.Show("CSV出力が完了しました", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                DefaultModule.OutputLogFile("発生場所：" + System.Reflection.MethodBase.GetCurrentMethod() + Environment.NewLine + ex.Message + Environment.NewLine + ex.StackTrace);
                MessageBox.Show("発生場所：" + System.Reflection.MethodBase.GetCurrentMethod() + Environment.NewLine + ex.Message + Environment.NewLine + ex.StackTrace, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        #endregion

        #region プライベートメソッド

        /// <summary>
        /// チェック処理前入力チェック
        /// </summary>
        /// <returns></returns>
        private bool InputCheck()
		{
			// 入力内容チェック
			if (System.IO.Directory.Exists(this.txtImageFolder.Text) == false)
			{
				MessageBox.Show("存在する画像フォルダを指定してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
			if (System.IO.File.Exists(this.txtTableData.Text) == false)
			{
				MessageBox.Show("存在するテーブルデータを指定してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
			if (System.IO.File.Exists(this.txtInputData.Text) == false)
			{
				MessageBox.Show("存在する入力データを指定してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
			if (System.IO.Directory.Exists(this.txtOutputFolder.Text) == false)
			{
				MessageBox.Show("存在する出力フォルダを指定してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
			if (DefaultModule.IsNull(this.txtHDDNo.Text))
			{
				MessageBox.Show("HDD番号を入力してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
			if (DefaultModule.IsNull(this.txtShootYear.Text))
			{
				MessageBox.Show("撮影年を入力してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
			if (DefaultModule.IsNull(this.txtShootTarget.Text))
			{
				MessageBox.Show("撮影対象を入力してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
			if (DefaultModule.IsNull(this.txtMediaClass.Text))
			{
				MessageBox.Show("分類を入力してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
			if (DefaultModule.IsNull(this.txtLinkClass.Text))
			{
				MessageBox.Show("リンク先分類を入力してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}

			return true;
		}

		/// <summary>
		/// 初期化処理
		/// </summary>
		private void Initialization()
		{
			XmlSettings.LoadFromXmlFile();

			this.txtImageFolder.Text = XmlSettings.Instance.ImageFolder;
			this.txtTableData.Text = XmlSettings.Instance.TableData;
			this.txtInputData.Text = XmlSettings.Instance.InputData;
			this.txtOutputFolder.Text = XmlSettings.Instance.OutputFolder;
			this.txtHDDNo.Text = XmlSettings.Instance.HDDNo;
			this.txtShootYear.Text = XmlSettings.Instance.ShootYear;
			this.txtShootTarget.Text = XmlSettings.Instance.ShootTarget;
			this.txtMediaClass.Text = XmlSettings.Instance.MediaClass;
			this.txtLinkClass.Text = XmlSettings.Instance.LinkClass;
			this.cmbImageClass.SelectedIndex = XmlSettings.Instance.ImageClass;
		}

		/// <summary>
		/// 終了処理
		/// </summary>
		private void Finalization()
		{
			XmlSettings.LoadFromXmlFile();

			XmlSettings.Instance.ImageFolder = this.txtImageFolder.Text;
			XmlSettings.Instance.TableData = this.txtTableData.Text;
			XmlSettings.Instance.InputData = this.txtInputData.Text;
			XmlSettings.Instance.OutputFolder = this.txtOutputFolder.Text;
			XmlSettings.Instance.HDDNo = this.txtHDDNo.Text;
			XmlSettings.Instance.ShootYear = this.txtShootYear.Text;
			XmlSettings.Instance.ShootTarget = this.txtShootTarget.Text;
			XmlSettings.Instance.MediaClass = this.txtMediaClass.Text;
			XmlSettings.Instance.LinkClass = this.txtLinkClass.Text;
			XmlSettings.Instance.ImageClass = this.cmbImageClass.SelectedIndex;

			XmlSettings.SaveToXmlFile();
		}

		/// <summary>
		/// 画像の容量(KB)、幅、高さを取得する
		/// </summary>
		/// <param name="strImageFile"></param>
		/// <param name="iFileSize"></param>
		/// <param name="iWidth"></param>
		/// <param name="iHeight"></param>
		private void GetImageSize(string strImageFile, ref int iFileSize, ref int iWidth, ref int iHeight)
		{
			// ファイルの容量を取得
			var fi = new System.IO.FileInfo(strImageFile);
			iFileSize = (int)(fi.Length / 1024);
			// Magick.NETで幅、高さを取得
			var img = new MagickImage(strImageFile);
			iWidth = img.Width;
			iHeight = img.Height;
			img.Dispose();
		}

        #endregion
    }
}
