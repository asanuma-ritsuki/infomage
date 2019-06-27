using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NDLImperialLibrary
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		/// <summary>
		/// 管理データ作成ボタン押下時
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnManageData_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("管理データを作成します" + Environment.NewLine + "よろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
			{
				return;
			}

			string strOutPath = this.txtOutputFolder.Text;
			string strOutputFile = strOutPath + "\\" + "kanri_1_3010.tsv";
			string strParentImagePath = this.txtImageFolder.Text;

			string strSQL = "";
			SQLProcess sqlProcess = new SQLProcess();

			try
			{
				strSQL = "DELETE FROM T_管理データ";
				sqlProcess.DB_UPDATE(strSQL);

				strSQL = "SELECT T2.ボリューム名, T1.文書番号ID, T1.請求記号, T1.タイトル, T1.分冊ディレクトリ名, ";
				strSQL += "T1.巻次, T1.分割有無, T1.ガラス有無, T1.解体有無, T1.付属物, ";
				strSQL += "T1.サイズ提供用, T1.サイズ保存用, 画像ファイル総数, T1.納品アイテム番号 ";
				strSQL += "FROM T_元データ AS T1 INNER JOIN ";
				strSQL += "T_BDVOL AS T2 ON T1.文書番号ID = T2.文書番号ID AND ";
				strSQL += "T1.分冊ディレクトリ名 = T2.分冊ディレクトリ名 ";
				strSQL += "ORDER BY T1.文書番号ID, T1.分冊ディレクトリ名";
				DataTable dt = sqlProcess.DB_SELECT_DATATABLE(strSQL);

				for (int iRow = 0; iRow < dt.Rows.Count;iRow++)
				{
					//// 画像フォルダの特定
					//string strDocID = dt.Rows[iRow]["文書番号ID"].ToString();
					//string strBunsatsu = dt.Rows[iRow]["分冊ディレクトリ名"].ToString();
					//string strTargetImageSave = "";
					//string strTargetImageOffer = "";
					//int iFileCount = 0;

					//// 画像フォルダがNULLの場合は処理を行わない
					//if (DefaultModule.IsNull(this.txtImageFolder.Text) == false)
					//{
					//	// 分冊ディレクトリ名が「00000」だった場合はフォルダなし
					//	if (strBunsatsu == "00000")
					//	{
					//		strTargetImageSave = strParentImagePath + "\\保存用\\" + strDocID;
					//		strTargetImageOffer = strParentImagePath + "\\提供用\\" + strDocID;
					//	}
					//	else
					//	{
					//		strTargetImageSave = strParentImagePath + "\\保存用\\" + strDocID + "\\" + strBunsatsu;
					//		strTargetImageOffer = strParentImagePath + "\\提供用\\" + strDocID + "\\" + strBunsatsu;
					//	}
					//	// 保存用のサイズ取得
					//	DirectoryInfo dir = new DirectoryInfo(strTargetImageSave);
					//	string strSaveSize = (DefaultModule.GetDirSize(dir) / 1024).ToString();
					//	// 提供用のサイズ取得
					//	dir = new DirectoryInfo(strTargetImageOffer);
					//	string strOfferSize = (DefaultModule.GetDirSize(dir) / 1024).ToString();
					//	// 画像ファイル総数
					//	// 保存用フォルダを対象とする
					//	iFileCount = Directory.GetFiles(strTargetImageSave, "*.jp2", SearchOption.AllDirectories).Length;
					//}

					// 備考項目を成形する
					strSQL = "SELECT フラグID, 備考詳細 FROM T_備考詳細 ";
					strSQL += "WHERE 文書番号ID = '" + dt.Rows[iRow]["文書番号ID"].ToString() + "' ";
					strSQL += "AND 分冊ディレクトリ名 = '" + dt.Rows[iRow]["分冊ディレクトリ名"].ToString() + "' ";
					strSQL += "ORDER BY 文書番号ID, 分冊ディレクトリ名, レコード番号";
					DataTable dtRemarks = sqlProcess.DB_SELECT_DATATABLE(strSQL);
					string strRemarks = "";
					string strTemp = "";

					for (int iRemarks = 0; iRemarks < dtRemarks.Rows.Count; iRemarks++)
					{
						// フラグIDで分岐
						switch (dtRemarks.Rows[iRemarks]["フラグID"])
						{
							// 備考詳細に何も表記がなかった場合は固定文言
							case 1:
								// 乱丁
								if (DefaultModule.IsNull(dtRemarks.Rows[iRemarks]["備考詳細"].ToString()))
								{
									// 固定文言
									strTemp = "[乱丁あり]";
								}
								else
								{
									strTemp = "[乱丁あり：" + dtRemarks.Rows[iRemarks]["備考詳細"].ToString() + "]";
								}
								break;

							case 2:
								// 落丁
								if (DefaultModule.IsNull(dtRemarks.Rows[iRemarks]["備考詳細"].ToString()))
								{
									// 固定文言
									strTemp = "[落丁あり]";
								}
								else
								{
									strTemp = "[落丁あり：" + dtRemarks.Rows[iRemarks]["備考詳細"].ToString() + "]";
								}
								break;

							case 3:
								// 汚損
								if (DefaultModule.IsNull(dtRemarks.Rows[iRemarks]["備考詳細"].ToString()))
								{
									// 固定文言
									strTemp = "[汚損あり]";
								}
								else
								{
									strTemp = "[汚損あり：" + dtRemarks.Rows[iRemarks]["備考詳細"].ToString() + "]";
								}
								break;

							case 4:
								// 一部判読不能
								if (DefaultModule.IsNull(dtRemarks.Rows[iRemarks]["備考詳細"].ToString()))
								{
									// 固定文言
									strTemp = "[一部判読不能あり]";
								}
								else
								{
									strTemp = "[一部判読不能：" + dtRemarks.Rows[iRemarks]["備考詳細"].ToString() + "]";
								}
								break;

							default:
								break;
						}

						if (iRemarks == 0)
						{
							strRemarks = strTemp;
						}
						else
						{
							strRemarks += "||" + strTemp;
						}
					}

					// 管理データテーブルに書き込み(UNICODE)
					strSQL = "INSERT INTO T_管理データ(ボリューム名, 文書番号ID, 請求記号, タイトル, 分冊ディレクトリ名, ";
					strSQL += "巻次, サイズ保存用, サイズ提供用, 画像ファイル総数, 分割有無, ガラス有無, 解体有無, 付属物, ";
					strSQL += "備考, 納品アイテム番号) VALUES(";
					strSQL += "N'" + dt.Rows[iRow]["ボリューム名"].ToString() + "'";
					strSQL += ", N'" + dt.Rows[iRow]["文書番号ID"].ToString() + "'";
					strSQL += ", N'" + dt.Rows[iRow]["請求記号"].ToString() + "'";
					strSQL += ", N'" + dt.Rows[iRow]["タイトル"].ToString() + "'";
					strSQL += ", N'" + dt.Rows[iRow]["分冊ディレクトリ名"].ToString() + "'";
					strSQL += ", N'" + dt.Rows[iRow]["巻次"].ToString() + "'";
					strSQL += ", N'" + dt.Rows[iRow]["サイズ保存用"].ToString() + "'";    // サイズ保存用
					strSQL += ", N'" + dt.Rows[iRow]["サイズ提供用"].ToString() + "'";   // サイズ提供用
					strSQL += ", N'" + dt.Rows[iRow]["画像ファイル総数"].ToString() + "'"; // 画像ファイル総数
					strSQL += ", N'" + dt.Rows[iRow]["分割有無"].ToString() + "'";
					strSQL += ", N'" + dt.Rows[iRow]["ガラス有無"].ToString() + "'";
					strSQL += ", N'" + dt.Rows[iRow]["解体有無"].ToString() + "'";
					strSQL += ", N'" + dt.Rows[iRow]["付属物"].ToString() + "'";
					strSQL += ", N'" + strRemarks + "'";
					strSQL += ", N'" + dt.Rows[iRow]["納品アイテム番号"].ToString() + "')";
					sqlProcess.DB_UPDATE(strSQL);
				}

				MessageBox.Show("管理データ作成が完了しました", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

		private void btnMetaData_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("メタデータを作成します" + Environment.NewLine + "よろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
			{
				return;
			}

			string strOutPath = this.txtOutputFolder.Text;
			string strOutputFileA = strOutPath + "\\" + "metadata_3010_A.tsv";  // 1分冊
			string strOutputFileB = strOutPath + "\\" + "metadata_3010_B.tsv";	// 複数分冊
			string strParentImagePath = this.txtImageFolder.Text;

			string strSQL = "";
			SQLProcess sqlProcess = new SQLProcess();

			try
			{
				strSQL = "DELETE FROM T_メタデータ";
				sqlProcess.DB_UPDATE(strSQL);

				strSQL = "SELECT T1.文書番号ID, T1.分冊ディレクトリ名, T1.請求記号, T1.タイトル, T1.巻次, T1.巻次よみ, ";
				strSQL += "T1.作成者, T1.年月日, T1.出版日, T1.数量, T1.注記, T1.表紙の方向, T1.ファイル名, T1.サムファイル名, ";
				strSQL += "T1.製作者, T1.製作年月日, T1.フォーマット, T1.納品アイテム番号, T2.指示 ";
				strSQL += "FROM T_元データ AS T1 INNER JOIN ";
				strSQL += "T_指示 AS T2 ON T1.文書番号ID = T2.文書番号ID ";
				strSQL += "AND T1.分冊ディレクトリ名 = T2.分冊ディレクトリ名 ";
				strSQL += "ORDER BY T1.文書番号ID, ";
				strSQL += "T1.分冊ディレクトリ名";
				DataTable dt = sqlProcess.DB_SELECT_DATATABLE(strSQL);

				for (int iRow = 0; iRow < dt.Rows.Count; iRow++)
				{
					//// 画像フォルダの特定
					//string strDocID = dt.Rows[iRow]["文書番号ID"].ToString();
					//string strBunsatsu = dt.Rows[iRow]["分冊ディレクトリ名"].ToString();
					//string strTargetImage = "";
					//bool blnBunsatsu = false;   // 分冊かどうか
					//string strFileName = "";	// ファイル名項目の変数

					//// 画像フォルダがNULLの場合は処理を行わない
					//if (DefaultModule.IsNull(this.txtImageFolder.Text) == false)
					//{
					//	// 分冊ディレクトリが「00000」だった場合はフォルダなし
					//	if (strBunsatsu == "00000")
					//	{
					//		strTargetImage = strParentImagePath + "\\保存用\\" + strDocID;
					//		blnBunsatsu = false;
					//	}
					//	else
					//	{
					//		strTargetImage = strParentImagePath + "\\保存用\\" + strDocID + "\\" + strBunsatsu;
					//		blnBunsatsu = true;
					//	}
					//	// 該当フォルダの先頭と末尾のファイル名をハイフンで結合する
					//	//string[] exts = new string[1] { "*.jp2" };
					//	string[] strFiles = DefaultModule.GetFilesMostDeep(strTargetImage, new string[1]{ "*.jp2"});
					//	strFileName = System.IO.Path.GetFileNameWithoutExtension(strFiles[0]) + "-";
					//	strFileName += System.IO.Path.GetFileNameWithoutExtension(strFiles[strFiles.Length - 1]);

					//}
					// データベースに書き込み
					strSQL = "INSERT INTO T_メタデータ(文書番号ID, 分冊ディレクトリ名, 請求記号, タイトル, 巻次, 巻次よみ, ";
					strSQL += "作成者, 年月日, 出版日, 数量, 注記, 表紙の方向, ファイル名, サムファイル名, 製作者, ";
					strSQL += "製作年月日, フォーマット, 納品アイテム番号, 指示) VALUES(";
					strSQL += "N'" + dt.Rows[iRow]["文書番号ID"].ToString() + "'";
					strSQL += ", N'" + dt.Rows[iRow]["分冊ディレクトリ名"].ToString() + "'";
					strSQL += ", N'" + dt.Rows[iRow]["請求記号"].ToString() + "'";
					strSQL += ", N'" + dt.Rows[iRow]["タイトル"].ToString() + "'";
					strSQL += ", N'" + dt.Rows[iRow]["巻次"].ToString() + "'";
					strSQL += ", N'" + dt.Rows[iRow]["巻次よみ"].ToString() + "'";
					strSQL += ", N'" + dt.Rows[iRow]["作成者"].ToString() + "'";
					strSQL += ", N'" + dt.Rows[iRow]["年月日"].ToString() + "'";
					strSQL += ", N'" + dt.Rows[iRow]["出版日"].ToString() + "'";
					strSQL += ", N'" + dt.Rows[iRow]["数量"].ToString() + "'";
					strSQL += ", N'" + dt.Rows[iRow]["注記"].ToString() + "'";
					strSQL += ", N'" + dt.Rows[iRow]["表紙の方向"].ToString() + "'";
					strSQL += ", N'" + dt.Rows[iRow]["ファイル名"].ToString() + "'";   // ファイル名
					strSQL += ", N'" + dt.Rows[iRow]["サムファイル名"].ToString() + "'";
					strSQL += ", N'" + dt.Rows[iRow]["製作者"].ToString() + "'";
					strSQL += ", N'" + dt.Rows[iRow]["製作年月日"].ToString() + "'";
					strSQL += ", N'" + dt.Rows[iRow]["フォーマット"].ToString() + "'";
					strSQL += ", N'" + dt.Rows[iRow]["納品アイテム番号"].ToString() + "'";
					strSQL += ", N'" + dt.Rows[iRow]["指示"].ToString() + "')";
					sqlProcess.DB_UPDATE(strSQL);
				}

				MessageBox.Show("メタデータ作成が完了しました", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
	}
}
 