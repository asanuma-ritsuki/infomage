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

namespace MitsuiCSVTool.Forms
{
	public partial class frmMain : Form
	{
		public frmMain()
		{
			InitializeComponent();
		}

		/// <summary>
		/// 開始ボタン押下時
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void btnRun2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("開始します" + Environment.NewLine + "よろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

			// 出力ファイル名の取得
			string strDate = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            string strOutFile = this.txtOutFolder.Text + "\\out_" + strDate + ".txt";
            // エラーログ
            string strErrLog = this.txtOutFolder.Text + "\\err.txt";
            var enc = System.Text.Encoding.GetEncoding("Shift-JIS");

            string strSQL = "";
            var sqlProcess = new SQLProcess();

            try
            {
				strSQL = "DELETE FROM T_IDPDF";
				sqlProcess.DB_UPDATE(strSQL);
				strSQL = "DELETE FROM T_提供データ";
				sqlProcess.DB_UPDATE(strSQL);
				strSQL = "DELETE FROM T_出力データ";
                sqlProcess.DB_UPDATE(strSQL);

				// pdf_pathのインポート
				using (var parser = new TextFieldParser(this.txtCSV.Text, enc))
				{
					parser.Delimiters = new string[] { "\t" };

					while (!parser.EndOfData)
					{
						var rows = parser.ReadFields();
						//各要素を読み込む
						string strID = rows[0];
						string strFileName = rows[7];
						// INSERT
						strSQL = "INSERT INTO T_IDPDF(ID, PDFファイル名) VALUES(";
						strSQL += "'" + strID + "'";
						strSQL += ", '" + strFileName + "')";
						sqlProcess.DB_UPDATE(strSQL);
					}
				}
				// 提供データのインポート
				using (var parser = new TextFieldParser(this.txtrename.Text, enc))
				{
					parser.Delimiters = new string[] { "\t" };

					while (!parser.EndOfData)
					{
						var rows = parser.ReadFields();
						// 各要素を読み込む
						string strID = rows[0];
						string strKeiyaku = rows[2];
						string strBukken = rows[4];
						string strRoom = rows[5];
						// INSERT
						strSQL = "INSERT INTO T_提供データ(ID, 賃貸借契約番号, 物件コード, 部屋コード) VALUES(";
						strSQL += "'" + strID + "'";
						strSQL += ", '" + strKeiyaku + "'";
						strSQL += ", '" + strBukken + "'";
						strSQL += ", '" + strRoom + "')";
						sqlProcess.DB_UPDATE(strSQL);
					}
				}

				// データの作成
				strSQL = "SELECT T1.ID, T2.賃貸借契約番号, T2.物件コード, T2.部屋コード, T1.PDFファイル名 ";
                strSQL += "FROM T_IDPDF AS T1 INNER JOIN ";
                strSQL += "T_提供データ AS T2 ON T1.ID = T2.ID ";
                strSQL += "ORDER BY T1.ID, T1.PDFファイル名";
                var dt = sqlProcess.DB_SELECT_DATATABLE(strSQL);
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("該当レコードなし", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                // PDFファイル名で回す
                for (int iRow = 0; iRow < dt.Rows.Count; iRow++)
                {
                    var strFileItems = dt.Rows[iRow]["PDFファイル名"].ToString().Split(new char[] { '_' });
                    // ３番目の要素の頭２桁を数値化する
                    int iNo = int.Parse(strFileItems[2].Substring(0, 2));
                    // T_出力データに該当の賃貸借契約番号があるか
                    // また、既に添付_基本、添付_その他に値が存在するか確認する
                    strSQL = "SELECT ID, 賃貸借契約番号, ISNULL(添付_基本, '') AS 添付_基本, ISNULL(添付_その他, '') AS 添付_その他 FROM T_出力データ ";
                    strSQL += "WHERE ID = '" + dt.Rows[iRow]["ID"].ToString() + "'";
                    var dtOut = sqlProcess.DB_SELECT_DATATABLE(strSQL);
                    if (dtOut.Rows.Count == 0)
                    {
                        // 新規追加
                        switch (iNo)
                        {
                            case 1:
                            case 2:
                            case 3:
                            case 4:
                            case 5:
                            case 6:
                            case 7:
                            case 13:
                            case 14:
                            case 15:
                            case 16:
                                // 添付_基本を参照
                                strSQL = "INSERT INTO T_出力データ(ID, 賃貸借契約番号, 添付_基本, 添付_その他) VALUES(";
                                strSQL += "'" + dt.Rows[iRow]["ID"].ToString() + "'";
                                strSQL += ", '" + dt.Rows[iRow]["賃貸借契約番号"].ToString() + "'";
                                strSQL += ", '" + dt.Rows[iRow]["PDFファイル名"].ToString() + "'";
                                strSQL += ", '')";
                                sqlProcess.DB_UPDATE(strSQL);
                                break;

                            case 8:
                            case 9:
                            case 10:
                            case 11:
                            case 12:
                            case 17:
                                // 添付_その他を参照
                                strSQL = "INSERT INTO T_出力データ(ID, 賃貸借契約番号, 添付_基本, 添付_その他) VALUES(";
                                strSQL += "'" + dt.Rows[iRow]["ID"].ToString() + "'";
                                strSQL += ", '" + dt.Rows[iRow]["賃貸借契約番号"].ToString() + "'";
                                strSQL += ", ''";
                                strSQL += ", '" + dt.Rows[iRow]["PDFファイル名"].ToString() + "')";
                                sqlProcess.DB_UPDATE(strSQL);
                                break;
                        }
                    }
                    else
                    {
                        // 追記のため添付項目を確認してUPDATE
                        string strAdd = "";
                        switch (iNo)
                        {
                            case 1:
                            case 2:
                            case 3:
                            case 4:
                            case 5:
                            case 6:
                            case 7:
                            case 13:
                            case 14:
                            case 15:
                            case 16:
                                // 添付_基本を参照
                                if (DefaultModule.IsNull(dtOut.Rows[0]["添付_基本"].ToString()))
                                {
                                    // NULLの場合、項目の先頭
                                    strAdd = dt.Rows[iRow]["PDFファイル名"].ToString();
                                }
                                else
                                {
                                    // 追記
                                    strAdd = dtOut.Rows[0]["添付_基本"].ToString() + "@" + dt.Rows[iRow]["PDFファイル名"].ToString();
                                }
                                strSQL = "UPDATE T_出力データ SET 添付_基本 = '" + strAdd + "' ";
                                strSQL += "WHERE ID = '" + dt.Rows[iRow]["ID"].ToString() + "'";
                                sqlProcess.DB_UPDATE(strSQL);

                                break;

                            case 8:
                            case 9:
                            case 10:
                            case 11:
                            case 12:
                            case 17:
                                // 添付_その他を参照
                                // 添付_基本を参照
                                if (DefaultModule.IsNull(dtOut.Rows[0]["添付_その他"].ToString()))
                                {
                                    // NULLの場合、項目の先頭
                                    strAdd = dt.Rows[iRow]["PDFファイル名"].ToString();
                                }
                                else
                                {
                                    // 追記
                                    strAdd = dtOut.Rows[0]["添付_その他"].ToString() + "@" + dt.Rows[iRow]["PDFファイル名"].ToString();
                                }
                                strSQL = "UPDATE T_出力データ SET 添付_その他 = '" + strAdd + "' ";
                                strSQL += "WHERE ID = '" + dt.Rows[iRow]["ID"].ToString() + "'";
                                sqlProcess.DB_UPDATE(strSQL);

                                break;
                        }
                    }
                }

				string strWriteLine = "";
				// データ出力
				using (var sw = new System.IO.StreamWriter(strOutFile, false, enc))
				{
					// ヘッダ書き込み
					strWriteLine = "ID\t賃貸借契約番号\t添付_基本\t添付_その他";
					sw.WriteLine(strWriteLine);
					// 実データ取得及び書き込み
					strSQL = "SELECT ID, 賃貸借契約番号, 添付_基本, 添付_その他 ";
					strSQL += "FROM T_出力データ ";
					strSQL += "ORDER BY ID";
					var dtOut = sqlProcess.DB_SELECT_DATATABLE(strSQL);

					for (int i = 0; i < dtOut.Rows.Count; i++)
					{
						strWriteLine = dtOut.Rows[i]["ID"].ToString();
						strWriteLine += "\t" + dtOut.Rows[i]["賃貸借契約番号"].ToString();
						strWriteLine += "\t" + dtOut.Rows[i]["添付_基本"].ToString();
						strWriteLine += "\t" + dtOut.Rows[i]["添付_その他"].ToString();
						sw.WriteLine(strWriteLine);
					}
				}

					MessageBox.Show("処理が終了しました", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
		/// テキストボックスドラッグイベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void txtCSV_DragEnter(object sender, DragEventArgs e)
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
		/// テキストボックスフォルダドロップイベント
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
		/// テキストボックスフォルダドロップイベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void txtCSV_DragDrop(object sender, DragEventArgs e)
		{
			string[] strFiles = (string[])e.Data.GetData(DataFormats.FileDrop, false);
			TextBox txtFile = (TextBox)sender;

			if (System.IO.Path.GetExtension(strFiles[0]) == ".txt")
			{
				txtFile.Text = strFiles[0];
			}
			else
			{
				txtFile.Text = "";
			}
		}

	}
}
