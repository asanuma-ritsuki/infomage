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

namespace MetroDataCheck
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		/// <summary>
		/// フォルダ単位で図面番号のグルーピングを行う
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		/// <remarks>図面番号の先頭2文字（ない場合は1文字または空文字）を比較して合致したら同一グループとみなす</remarks>
		private void btnStart_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("グルーピング処理を行います" + Environment.NewLine + "よろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
			{
				return;
			}
			string strSQL = "";
			Class.SQLProcess sqlProcess = new Class.SQLProcess();

			try
			{
				// フォルダグループのDATATABLEの作成
				strSQL = "SELECT フォルダグループ FROM T_警視庁データ ";
				strSQL += "WHERE 不要フラグ = 0 ";
				strSQL += "GROUP BY フォルダグループ ";
				strSQL += "ORDER BY フォルダグループ";
				DataTable dt = sqlProcess.DB_SELECT_DATATABLE(strSQL);

				for (int iRow = 0; iRow <= dt.Rows.Count - 1; iRow++)
				{
					// フォルダグループ単位の必要項目でDATATABLEを作成する
					strSQL = "SELECT ID, 図面番号 FROM T_警視庁データ ";
					strSQL += "WHERE フォルダグループ = '" + dt.Rows[iRow]["フォルダグループ"] + "' ";
					strSQL += "AND 不要フラグ = 0 ";
					strSQL += "ORDER BY ID";
					DataTable dtDetail = sqlProcess.DB_SELECT_DATATABLE(strSQL);
					int iFolderCounter = 0; // フォルダ内の「図面番号」の先頭2文字でグルーピング
					string strBeforeZumen = null;   // 前回レコードの図面番号の先頭2文字

					for (int iFolderRow = 0; iFolderRow <= dtDetail.Rows.Count - 1; iFolderRow++)
					{
						string strTarget = "";
						if (Class.DefaultModule.IsNull(((string)dtDetail.Rows[iFolderRow]["図面番号"])))
						{
							// NULLまたは空文字
							strTarget = "";
						}
						else if (((string)dtDetail.Rows[iFolderRow]["図面番号"]).Length == 1)
						{
							strTarget = ((string)dtDetail.Rows[iFolderRow]["図面番号"]).Substring(0, 1);
						}
						else
						{
							strTarget = ((string)dtDetail.Rows[iFolderRow]["図面番号"]).Substring(0, 2);
						}

						if (strBeforeZumen == null || strBeforeZumen != strTarget)
						{
							// 図面番号の先頭2文字が相違、またはNULLの場合、カウンタをインクリメントして値をUPDATE
							iFolderCounter++;
						}
						else
						{
							// 図面番号の先頭2文字が合致していた場合は何もしないでカウンタをUPDATE
						}

						strSQL = "UPDATE T_警視庁データ ";
						strSQL += "SET グルーピング = " + iFolderCounter + " ";
						strSQL += "WHERE ID = " + dtDetail.Rows[iFolderRow]["ID"];
						sqlProcess.DB_UPDATE(strSQL);
						// 前回の図面番号の2文字として変数に退避する
						if (Class.DefaultModule.IsNull(strTarget))
						{
							// 前回図面番号がNULLまたは空文字だった場合、空文字をセットする
							strBeforeZumen = "";
						}
						else
						{
							strBeforeZumen = strTarget;
						}

					}

				}
				MessageBox.Show("処理が終了しました", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information);

			}
			catch (Exception ex)
			{
				Class.DefaultModule.OutputLogFile("発生場所：" + System.Reflection.MethodBase.GetCurrentMethod() + Environment.NewLine + ex.Message + Environment.NewLine + ex.StackTrace);
				MessageBox.Show("発生場所：" + System.Reflection.MethodBase.GetCurrentMethod() + Environment.NewLine + ex.Message + Environment.NewLine + ex.StackTrace, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally
			{
				sqlProcess.Close();
			}
		}

		/// <summary>
		/// フォルダ内のグルーピング番号単位でソートして新連番を付与する
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnStart02_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("グループ連番を付与します" + Environment.NewLine + "よろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
			{
				return;
			}

			string strSQL = "";
			Class.SQLProcess sqlProcess = new Class.SQLProcess();

			try
			{
				// フォルダグループのDATATABLEの作成
				strSQL = "SELECT フォルダグループ FROM T_警視庁データ ";
				strSQL += "WHERE 不要フラグ = 0 ";
				strSQL += "GROUP BY フォルダグループ ";
				strSQL += "ORDER BY フォルダグループ";
				DataTable dt = sqlProcess.DB_SELECT_DATATABLE(strSQL);
				int iGroupSerial = 0;   // グループ連番用カウンタ

				for (int iRow = 0; iRow <= dt.Rows.Count - 1; iRow++)
				{
					// グルーピング項目単位でグルーピングする
					strSQL = "SELECT グルーピング FROM T_警視庁データ ";
					strSQL += "WHERE フォルダグループ = '" + dt.Rows[iRow]["フォルダグループ"] + "' ";
					strSQL += "AND 不要フラグ = 0 ";
					strSQL += "GROUP BY グルーピング ";
					strSQL += "ORDER BY グルーピング";
					DataTable dtGrouping = sqlProcess.DB_SELECT_DATATABLE(strSQL);

					for (int iGroupingRow = 0; iGroupingRow <= dtGrouping.Rows.Count - 1; iGroupingRow++)
					{
						// フォルダグループ、グルーピング項目内で図面番号にてソートを行う
						// ソートの出現順でグループ連番を付与する
						strSQL = "SELECT ID FROM T_警視庁データ ";
						strSQL += "WHERE フォルダグループ = '" + dt.Rows[iRow]["フォルダグループ"] + "' ";
						strSQL += "AND グルーピング = " + dtGrouping.Rows[iGroupingRow]["グルーピング"] + " ";
						strSQL += "AND 不要フラグ = 0 ";
						strSQL += "ORDER BY LEN(図面番号), 図面番号, ID";
						DataTable dtSort = sqlProcess.DB_SELECT_DATATABLE(strSQL);

						// ソート後のDATATABLEを走査してフォルダグループ単位の連番を付与し直す
						for (int iSortRow = 0; iSortRow <= dtSort.Rows.Count - 1; iSortRow++)
						{
							iGroupSerial++;
							strSQL = "UPDATE T_警視庁データ SET グループ連番 = " + iGroupSerial + " ";
							strSQL += "WHERE ID = " + dtSort.Rows[iSortRow]["ID"];
							sqlProcess.DB_UPDATE(strSQL);
						}
					}
				}

				MessageBox.Show("連番付与処理が終了しました", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information);

			}
			catch (Exception ex)
			{
				Class.DefaultModule.OutputLogFile("発生場所：" + System.Reflection.MethodBase.GetCurrentMethod() + Environment.NewLine + ex.Message + Environment.NewLine + ex.StackTrace);
				MessageBox.Show("発生場所：" + System.Reflection.MethodBase.GetCurrentMethod() + Environment.NewLine + ex.Message + Environment.NewLine + ex.StackTrace, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally
			{
				sqlProcess.Close();
			}
		}

		/// <summary>
		/// インポート処理
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnImport_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("インポート処理を行います" + Environment.NewLine + "よろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
			{
				return;
			}

			string strSQL = "";
			Class.SQLProcess sqlProcess = new Class.SQLProcess();

			try
			{
				// T_警視庁データの削除
				strSQL = "DELETE FROM T_警視庁データ";
				sqlProcess.DB_UPDATE(strSQL);
				// インポートデータの読み込み
				using (TextFieldParser parser = new TextFieldParser(this.txtImport.Text, Encoding.GetEncoding("Shift-JIS")))
				{
					parser.TextFieldType = FieldType.Delimited;
					parser.SetDelimiters("\t");
					parser.HasFieldsEnclosedInQuotes = true;
					parser.TrimWhiteSpace = false;

					int iRecCount = 0;

					while (parser.EndOfData == false)
					{
						// 最終行まで読み込み
						iRecCount += 1;
						string[] row = parser.ReadFields();
						strSQL = "INSERT INTO T_警視庁データ(ID, フォルダグループ, イメージパス, ファイル名, 方面, ";
						strSQL += "施設番号, 施設名, 種別, 工事件名, 図面番号, 枝番, 図面名称, 表紙目次, 図面フラグ, 不要フラグ, ";
						strSQL += "冊種別, グルーピング, グループ連番, 先イメージパス, 先ファイル名) VALUES(";
						strSQL += iRecCount.ToString();
						strSQL += ", '" + row[0] + "'"; // フォルダグループ
						strSQL += ", '" + row[1] + "'"; // イメージパス
						strSQL += ", '" + row[2] + "'"; // ファイル名
						strSQL += ", '" + row[3] + "'"; // 方面
						strSQL += ", '" + row[4] + "'"; // 施設番号
						strSQL += ", '" + row[5] + "'"; // 施設名
						strSQL += ", '" + row[6] + "'"; // 種別
						strSQL += ", '" + row[7] + "'"; // 工事件名
						strSQL += ", '" + row[8] + "'"; // 図面番号
						strSQL += ", " + row[9];    // 枝番
						strSQL += ", '" + row[10] + "'"; // 図面名称
						strSQL += ", " + row[11];   // 表紙目次
						strSQL += ", '" + row[12] + "'"; // 図面フラグ
						strSQL += ", " + row[13];   // 不要フラグ
						strSQL += ", " + row[14];   // 冊種別
						strSQL += ", NULL, NULL, '', '')"; //グルーピング、グループ番号、先イメージパス、先ファイル名
						sqlProcess.DB_UPDATE(strSQL);
					}
				}


				//using (Class.CSVPaeser parser = new Class.CSVPaeser(this.txtImport.Text, System.Text.Encoding.GetEncoding("Shift-JIS")))
				//{
				//	parser.Delimiter = "\t";
				//	parser.HasFieldsEnclosedInQuotes = true;
				//	parser.TrimWhiteSpace = false;

				//	int iRecCount = 0;

				//	while(parser.EndOfData == false)
				//	{
				//		// 最終行まで読み込み
				//		iRecCount += 1;
				//		string[] row = parser.ReadFields();
				//		strSQL = "INSERT INTO T_警視庁データ(ID, フォルダグループ, イメージパス, ファイル名, 方面, ";
				//		strSQL += "施設番号, 施設名, 種別, 工事件名, 図面番号, 図面名称, 不要フラグ, 図面名称不明, ";
				//		strSQL += "グルーピング, グループ連番, 先イメージパス, 先ファイル名) VALUES(";
				//		strSQL += iRecCount.ToString();
				//		strSQL += ", '" + row[0] + "'"; // フォルダグループ
				//		strSQL += ", '" + row[1] + "'"; // イメージパス
				//		strSQL += ", '" + row[2] + "'"; // ファイル名
				//		strSQL += ", '" + row[3] + "'"; // 方面
				//		strSQL += ", '" + row[4] + "'"; // 施設番号
				//		strSQL += ", '" + row[5] + "'"; // 施設名
				//		strSQL += ", '" + row[6] + "'"; // 種別
				//		strSQL += ", '" + row[7] + "'"; // 工事件名
				//		strSQL += ", '" + row[8] + "'"; // 図面番号
				//		strSQL += ", '" + row[9] + "'"; // 図面名称
				//		strSQL += ", '" + row[10] + "'"; // 不要フラグ
				//		strSQL += ", '" + row[11] + "'"; // 図面名称不明
				//		strSQL += ", NULL, NULL, '', '')"; //グルーピング、グループ番号、先イメージパス、先ファイル名
				//		sqlProcess.DB_UPDATE(strSQL);
				//	}
				//}
				MessageBox.Show("インポート処理が終了しました", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			catch (Exception ex)
			{
				Class.DefaultModule.OutputLogFile("発生場所：" + System.Reflection.MethodBase.GetCurrentMethod() + Environment.NewLine + ex.Message + Environment.NewLine + ex.StackTrace);
				MessageBox.Show("発生場所：" + System.Reflection.MethodBase.GetCurrentMethod() + Environment.NewLine + ex.Message + Environment.NewLine + ex.StackTrace, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally
			{
				sqlProcess.Close();
			}

		}

		/// <summary>
		/// ファイル名特定ボタン押下時
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		/// <remarks>冊種別単位でループさせる</remarks>
		private void btnFileName_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("フォルダ名を付与します" + Environment.NewLine + "よろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
			{
				return;
			}

			string strSQL = "";
			Class.SQLProcess sqlProcess = new Class.SQLProcess();

			try
			{
				// フォルダパスの作成
				strSQL = "SELECT ID, 方面, 施設番号, 施設名, 種別, 工事件名, 図面番号, 図面名称 FROM T_警視庁データ ";
				strSQL += "WHERE 不要フラグ = 0 ";
				//strSQL += "AND 冊種別 = 1";
				DataTable dt = sqlProcess.DB_SELECT_DATATABLE(strSQL);
				for (int iRow = 0; iRow < dt.Rows.Count; iRow++)
				{
					// フォルダパスの作成
					string strFolderPath = dt.Rows[iRow]["方面"] + "\\" +
						dt.Rows[iRow]["施設番号"] + "；" + dt.Rows[iRow]["施設名"] + "\\" +
						dt.Rows[iRow]["種別"] + "\\" + dt.Rows[iRow]["工事件名"];
					//// ファイル名の作成（枝番考慮しない）
					//string strFileName = dt.Rows[iRow]["図面番号"] + "；" + dt.Rows[iRow]["図面名称"] + ".jpg";
					//// データベースに書き込み
					//strSQL = "UPDATE T_警視庁データ SET 先イメージパス = '" + strFolderPath + "'";
					//strSQL += ", 先ファイル名 = '" + strFileName + "' ";
					//strSQL += "WHERE ID = " + dt.Rows[iRow]["ID"];
					//sqlProcess.DB_UPDATE(strSQL);
					strSQL = "UPDATE T_警視庁データ SET 先イメージパス = '" + strFolderPath + "' ";
					strSQL += "WHERE ID = " + dt.Rows[iRow]["ID"];
					sqlProcess.DB_UPDATE(strSQL);
				}

				MessageBox.Show("フォルダ名付与が完了しました", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information);

			}
			catch (Exception ex)
			{
				Class.DefaultModule.OutputLogFile("発生場所：" + System.Reflection.MethodBase.GetCurrentMethod() + Environment.NewLine + ex.Message + Environment.NewLine + ex.StackTrace);
				MessageBox.Show("発生場所：" + System.Reflection.MethodBase.GetCurrentMethod() + Environment.NewLine + ex.Message + Environment.NewLine + ex.StackTrace, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally
			{
				sqlProcess.Close();
			}

		}

		/// <summary>
		/// ファイル名特定
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnFileName02_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("ファイル名を付与します" + Environment.NewLine + "よろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
			{
				return;
			}

			string strSQL = "";
			Class.SQLProcess sqlProcess = new Class.SQLProcess();

			try
			{
				//// 図面
				//strSQL = "SELECT ID, 方面, 施設番号, 施設名, 種別, 工事件名, 図面番号, 図面名称 FROM T_警視庁データ ";
				//strSQL += "WHERE 不要フラグ = 0 ";
				//strSQL += "AND 冊種別 = 1";
				//DataTable dt = sqlProcess.DB_SELECT_DATATABLE(strSQL);
				//for (int iRow = 0; iRow < dt.Rows.Count; iRow++)
				//{
				//	// ファイル名の作成（枝番考慮しない）
				//	string strFileName = dt.Rows[iRow]["図面番号"] + "；" + dt.Rows[iRow]["図面名称"] + ".jpg";
				//	// データベースに書き込み
				//	strSQL = "UPDATE T_警視庁データ SET 先ファイル名 = '" + strFileName + "' ";
				//	strSQL += "WHERE ID = " + dt.Rows[iRow]["ID"];
				//	sqlProcess.DB_UPDATE(strSQL);
				//}
				DataTable dt = null;
				// 観音折込
				// フォルダ単位で0からの連番
				strSQL = "SELECT 先イメージパス FROM T_警視庁データ ";
				strSQL += "WHERE 不要フラグ = 0 ";
				strSQL += "AND 冊種別 = 2 ";
				strSQL += "GROUP BY 先イメージパス";
				DataTable dtPath = sqlProcess.DB_SELECT_DATATABLE(strSQL);
				for (int iPath = 0; iPath < dtPath.Rows.Count; iPath++)
				{
					strSQL = "SELECT ID, ISNULL(図面番号, '') AS 図面番号, ISNULL(図面名称,'') AS 図面名称, 先イメージパス FROM T_警視庁データ ";
					strSQL += "WHERE 不要フラグ = 0 ";
					strSQL += "AND 冊種別 = 2 ";
					strSQL += "AND 先イメージパス = '" + dtPath.Rows[iPath]["先イメージパス"] + "' ";
					strSQL += "ORDER BY ID";
					dt = sqlProcess.DB_SELECT_DATATABLE(strSQL);
					// ファイル名の作成
					// 頭0から連番を降る
					// 0002；1階平面図.jpg
					// 図面名称がない場合は数字4桁のみ
					for (int iRow = 0; iRow < dt.Rows.Count; iRow++)
					{
						string strFileName = iRow.ToString("0000");
						//if ((string)dt.Rows[iRow]["図面番号"] != "")
						//{
						//	// 図面名称に値が入っていたら結合
						//	strFileName += "；" + (string)dt.Rows[iRow]["図面番号"];
						//}
						if ((string)dt.Rows[iRow]["図面名称"] != "")
						{
							// 図面名称に値が入っていたら結合
							strFileName += "；" + (string)dt.Rows[iRow]["図面名称"];
						}
						strFileName += ".jpg";
						// データベースに書き込み
						strSQL = "UPDATE T_警視庁データ SET 先ファイル名 = '" + strFileName + "' ";
						strSQL += "WHERE ID = " + dt.Rows[iRow]["ID"];
						sqlProcess.DB_UPDATE(strSQL);
					}
				}

				//// 書類
				//// フォルダ単位で0からの連番
				//strSQL = "SELECT 先イメージパス FROM T_警視庁データ ";
				//strSQL += "WHERE 不要フラグ = 0 ";
				//strSQL += "AND 冊種別 = 3 ";
				//strSQL += "GROUP BY 先イメージパス";
				//dtPath = sqlProcess.DB_SELECT_DATATABLE(strSQL);
				//for (int iPath = 0; iPath < dtPath.Rows.Count; iPath++)
				//{
				//	strSQL = "SELECT ID, ISNULL(図面名称,'') AS 図面名称, 先イメージパス FROM T_警視庁データ ";
				//	strSQL += "WHERE 不要フラグ = 0 ";
				//	strSQL += "AND 冊種別 = 3 ";
				//	strSQL += "AND 先イメージパス = '" + dtPath.Rows[iPath]["先イメージパス"] + "' ";
				//	strSQL += "ORDER BY ID";
				//	dt = sqlProcess.DB_SELECT_DATATABLE(strSQL);
				//	// ファイル名の作成
				//	// 頭0から連番を降る
				//	// 0002.jpg
				//	for (int iRow = 0; iRow < dt.Rows.Count; iRow++)
				//	{
				//		string strFileName = iRow.ToString("0000");
				//		strFileName += ".jpg";
				//		// データベースに書き込み
				//		strSQL = "UPDATE T_警視庁データ SET 先ファイル名 = '" + strFileName + "' ";
				//		strSQL += "WHERE ID = " + dt.Rows[iRow]["ID"];
				//		sqlProcess.DB_UPDATE(strSQL);
				//	}
				//}


				MessageBox.Show("ファイル名付与が完了しました", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information);

			}
			catch (Exception ex)
			{
				Class.DefaultModule.OutputLogFile("発生場所：" + System.Reflection.MethodBase.GetCurrentMethod() + Environment.NewLine + ex.Message + Environment.NewLine + ex.StackTrace);
				MessageBox.Show("発生場所：" + System.Reflection.MethodBase.GetCurrentMethod() + Environment.NewLine + ex.Message + Environment.NewLine + ex.StackTrace, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
				MessageBox.Show("SQL文：" + strSQL, "確認", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			finally
			{
				sqlProcess.Close();
			}

		}

		/// <summary>
		/// 工事件名特定ボタン押下時
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnKouji_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("工事件名を特定します" + Environment.NewLine + "よろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
			{
				return;
			}

			string strSQL = "";
			Class.SQLProcess sqlProcess = new Class.SQLProcess();

			try
			{
				strSQL = "SELECT ID, 工事件名元, 工事件名先 FROM T_工事件名集約 ";
				strSQL += "ORDER BY ID";
				DataTable dt = sqlProcess.DB_SELECT_DATATABLE(strSQL);

				for (int iRow = 0; iRow < dt.Rows.Count; iRow++)
				{
					// 更新処理
					strSQL = "UPDATE T_警視庁データ SET 工事件名 = '" + dt.Rows[iRow]["工事件名先"] + "' ";
					strSQL += "WHERE 工事件名 = '" + dt.Rows[iRow]["工事件名元"] + "'";
					sqlProcess.DB_UPDATE(strSQL);
				}

				MessageBox.Show("工事件名特定処理が終了しました", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information);

			}
			catch (Exception ex)
			{
				Class.DefaultModule.OutputLogFile("発生場所：" + System.Reflection.MethodBase.GetCurrentMethod() + Environment.NewLine + ex.Message + Environment.NewLine + ex.StackTrace);
				MessageBox.Show("発生場所：" + System.Reflection.MethodBase.GetCurrentMethod() + Environment.NewLine + ex.Message + Environment.NewLine + ex.StackTrace, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally
			{
				sqlProcess.Close();
			}

		}

		private void btnEda_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("枝番付与を開始します" + Environment.NewLine + "よろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
			{
				return;
			}

			string strSQL = "";
			Class.SQLProcess sqlProcess = new Class.SQLProcess();

			try
			{
				strSQL = "SELECT 先イメージパス FROM T_警視庁データ ";
				strSQL += "WHERE 不要フラグ = 0 ";
				strSQL += "AND 冊種別 = 1 ";
				strSQL += "GROUP BY 先イメージパス";
				DataTable dtPath = sqlProcess.DB_SELECT_DATATABLE(strSQL);
				for (int iPath = 0; iPath < dtPath.Rows.Count; iPath++)
				{
					// フォルダ単位でファイル名に重複がないか確認する
					// 先ファイル名でグルーピングしてID順に枝番をふる
					strSQL = "SELECT 先ファイル名 FROM T_警視庁データ ";
					strSQL += "WHERE 不要フラグ = 0 ";
					strSQL += "AND 冊種別 = 1 ";
					strSQL += "AND 先イメージパス = '" + dtPath.Rows[iPath]["先イメージパス"] + "' ";
					strSQL += "GROUP BY 先ファイル名";
					DataTable dtFile = sqlProcess.DB_SELECT_DATATABLE(strSQL);
					for (int iFile = 0; iFile < dtFile.Rows.Count; iFile++)
					{
						// ファイル名を検索する
						strSQL = "SELECT ID, 図面番号, 図面名称 FROM T_警視庁データ ";
						strSQL += "WHERE 不要フラグ = 0 ";
						strSQL += "AND 冊種別 = 1 ";
						strSQL += "AND 先イメージパス = '" + dtPath.Rows[iPath]["先イメージパス"] + "' ";
						strSQL += "AND 先ファイル名 = '" + dtFile.Rows[iFile]["先ファイル名"] + "' ";
						strSQL += "ORDER BY ID";
						DataTable dtFiles = sqlProcess.DB_SELECT_DATATABLE(strSQL);
						if (dtFiles.Rows.Count == 1)
						{
							// 1レコードだった場合は枝番なし
							// 枝番項目に0を付与
							strSQL = "UPDATE T_警視庁データ SET 枝番 = 0 ";
							strSQL += "WHERE ID = " + dtFiles.Rows[0]["ID"];
							sqlProcess.DB_UPDATE(strSQL);
						}
						else
						{
							// 複数レコードあった場合
							// 頭から連番を降ってファイル名を作成する
							for (int iFiles = 0; iFiles < dtFiles.Rows.Count; iFiles++)
							{
								// 1レコード目は何もしない
								if (iFiles == 0)
								{
									strSQL = "UPDATE T_警視庁データ SET 枝番 = 1 ";
									strSQL += "WHERE ID = " + dtFiles.Rows[0]["ID"];
									sqlProcess.DB_UPDATE(strSQL);
								}
								else
								{
									string strFileName = dtFiles.Rows[iFiles]["図面番号"] +
										"-" + (iFiles + 1).ToString() + "；" +
										dtFiles.Rows[iFiles]["図面名称"] + ".jpg";
									// データベースに書き込み
									strSQL = "UPDATE T_警視庁データ SET 枝番 = " + (iFiles + 1).ToString() + ", ";
									strSQL += "先ファイル名 = '" + strFileName + "' ";
									strSQL += "WHERE ID = " + dtFiles.Rows[iFiles]["ID"];
									sqlProcess.DB_UPDATE(strSQL);
								}
							}
						}
					}
				}

				MessageBox.Show("枝番付与が終了しました", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information);

			}
			catch (Exception ex)
			{
				Class.DefaultModule.OutputLogFile("発生場所：" + System.Reflection.MethodBase.GetCurrentMethod() + Environment.NewLine + ex.Message + Environment.NewLine + ex.StackTrace);
				MessageBox.Show("発生場所：" + System.Reflection.MethodBase.GetCurrentMethod() + Environment.NewLine + ex.Message + Environment.NewLine + ex.StackTrace, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
				MessageBox.Show("SQL文：" + strSQL, "確認", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			finally
			{
				sqlProcess.Close();
			}

		}

		private void btnExist_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("ファイルの存在チェックを行います" + Environment.NewLine + "よろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
			{
				return;
			}

			string strSQL = "";
			Class.SQLProcess sqlProcess = new Class.SQLProcess();

			try
			{
				strSQL = "DELETE FROM T_ファイル存在チェック";
				sqlProcess.DB_UPDATE(strSQL);

				strSQL = "SELECT ID, 先イメージパス, 先ファイル名 FROM T_警視庁データ ";
				strSQL += "WHERE 不要フラグ = 0";
				DataTable dt = sqlProcess.DB_SELECT_DATATABLE(strSQL);

				using (System.IO.StreamWriter sw = new System.IO.StreamWriter(this.txtOutPath.Text + "\\Log.log", false, System.Text.Encoding.GetEncoding("Shift-JIS")))
				{

					//for (int iRow = 0; iRow < dt.Rows.Count; iRow++)
					//{
					//	string strFileName = this.txtDrive.Text + dt.Rows[iRow]["先イメージパス"] + "\\" + dt.Rows[iRow]["先ファイル名"];
					//	if (System.IO.File.Exists(strFileName) == false)
					//	{
					//		string strWriteLine = "ファイルが存在しない\t" + dt.Rows[iRow]["ID"] + strFileName;
					//		sw.WriteLine(strWriteLine);
					//		//strSQL = "INSERT INTO T_ファイル存在チェック(ID, イメージパス, ファイル名) VALUES(";
					//		//strSQL += dt.Rows[iRow]["ID"];
					//		//strSQL += ", '" + dt.Rows[iRow]["先イメージパス"] + "'";
					//		//strSQL += ", '" + dt.Rows[iRow]["先ファイル名"] + "')";
					//		//sqlProcess.DB_UPDATE(strSQL);
					//	}
					//}

					using (System.IO.StreamReader sr = new System.IO.StreamReader(this.txtOutPath.Text + "\\input.txt", System.Text.Encoding.GetEncoding("Shift-JIS")))
					{
						while (sr.Peek() >= 0)
						{

							string strReadLine = sr.ReadLine();
							if (System.IO.File.Exists(strReadLine) == false)
							{
								string strWriteLine = "ファイルが存在しない\t" + strReadLine;
								sw.WriteLine(strWriteLine);
							}
						}
					}
				}
				MessageBox.Show("終了しました", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			catch (Exception ex)
			{
				Class.DefaultModule.OutputLogFile("発生場所：" + System.Reflection.MethodBase.GetCurrentMethod() + Environment.NewLine + ex.Message + Environment.NewLine + ex.StackTrace);
				MessageBox.Show("発生場所：" + System.Reflection.MethodBase.GetCurrentMethod() + Environment.NewLine + ex.Message + Environment.NewLine + ex.StackTrace, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
				MessageBox.Show("SQL文：" + strSQL, "確認", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			finally
			{
				sqlProcess.Close();
			}
		}

		private void btnPickup_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("ファイルの存在チェックを行います" + Environment.NewLine + "よろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
			{
				return;
			}

			string strSQL = "";
			Class.SQLProcess sqlProcess = new Class.SQLProcess();

			try
			{
				strSQL = "DELETE FROM T_ファイル存在チェック";
				sqlProcess.DB_UPDATE(strSQL);

				strSQL = "SELECT ID, 先イメージパス, 先ファイル名 FROM T_警視庁データ ";
				strSQL += "WHERE 不要フラグ = 0";
				DataTable dt = sqlProcess.DB_SELECT_DATATABLE(strSQL);

				using (System.IO.StreamWriter sw = new System.IO.StreamWriter(this.txtOutPath.Text + "\\Log.log", false, System.Text.Encoding.GetEncoding("Shift-JIS")))
				{

					//for (int iRow = 0; iRow < dt.Rows.Count; iRow++)
					//{
					//	string strFileName = this.txtDrive.Text + dt.Rows[iRow]["先イメージパス"] + "\\" + dt.Rows[iRow]["先ファイル名"];
					//	if (System.IO.File.Exists(strFileName) == false)
					//	{
					//		string strWriteLine = "ファイルが存在しない\t" + dt.Rows[iRow]["ID"] + strFileName;
					//		sw.WriteLine(strWriteLine);
					//		//strSQL = "INSERT INTO T_ファイル存在チェック(ID, イメージパス, ファイル名) VALUES(";
					//		//strSQL += dt.Rows[iRow]["ID"];
					//		//strSQL += ", '" + dt.Rows[iRow]["先イメージパス"] + "'";
					//		//strSQL += ", '" + dt.Rows[iRow]["先ファイル名"] + "')";
					//		//sqlProcess.DB_UPDATE(strSQL);
					//	}
					//}

					using (System.IO.StreamReader sr = new System.IO.StreamReader(this.txtOutPath.Text + "\\input.txt", System.Text.Encoding.GetEncoding("Shift-JIS")))
					{
						while (sr.Peek() >= 0)
						{

							string strReadLine = sr.ReadLine();
							if (System.IO.File.Exists(strReadLine) == false)
							{
								string strWriteLine = "ファイルが存在しない\t" + strReadLine;
								sw.WriteLine(strWriteLine);
							}
						}
					}
				}
				MessageBox.Show("終了しました", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			catch (Exception ex)
			{
				Class.DefaultModule.OutputLogFile("発生場所：" + System.Reflection.MethodBase.GetCurrentMethod() + Environment.NewLine + ex.Message + Environment.NewLine + ex.StackTrace);
				MessageBox.Show("発生場所：" + System.Reflection.MethodBase.GetCurrentMethod() + Environment.NewLine + ex.Message + Environment.NewLine + ex.StackTrace, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
				MessageBox.Show("SQL文：" + strSQL, "確認", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			finally
			{
				sqlProcess.Close();
			}
		}

		private void btnCSVParser_Click(object sender, EventArgs e)
		{
			string strFile = @"C:\開発\NDL帝国図書館文書\temp\管理データ\kanri_1_3010.tsv";
			System.Text.Encoding enc = System.Text.Encoding.GetEncoding("Shift-JIS");

			var parser = new Class.CSVPaeser(strFile, enc);
			using (parser)
			{
				parser.Delimiter = "\t";

				while (!parser.EndOfData)
				{
					string[] row = parser.ReadFields();
					foreach (string field in row)
					{
						Console.WriteLine(field + "\t");
					}
					Console.WriteLine();
				}
			}
		}
	}
}
