using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Permissions;
using System.Collections;
using static PDF_Shiori.DefaultModule;

namespace PDF_Shiori
{
    public partial class frmJobEdit : C1.Win.C1Ribbon.C1RibbonForm
    {

        public frmJobEdit()
        {
            InitializeComponent();
        }

        #region プロパティ
        private string m_JOB_ID;
        private string m_Sakuban;
        private string m_Anken;
        private string m_Customer;
        private string m_EndUser;
        private string m_Sagyou;

        /// <summary>
        /// JOB_ID
        /// </summary>
        public string prpJOB_ID
        {
            get { return m_JOB_ID; }
            set { m_JOB_ID = value; }
        }
        /// <summary>
        /// 作番
        /// </summary>
        public string prpSakuban
        {
            get { return m_Sakuban; }
            set { m_Sakuban = value; }
        }
        /// <summary>
        /// 案件名
        /// </summary>
        public string prpAnken
        {
            get { return m_Anken; }
            set { m_Anken = value; }
        }
        /// <summary>
        /// 顧客名
        /// </summary>
        public string prpCustomer
        {
            get { return m_Customer; }
            set { m_Customer = value; }
        }
        /// <summary>
        /// エンドユーザー
        /// </summary>
        public string prpEndUser
        {
            get { return m_EndUser; }
            set { m_EndUser = value; }
        }
        /// <summary>
        /// 作業名
        /// </summary>
        public string prpJob
        {
            get { return m_Sagyou; }
            set { m_Sagyou = value; }
        }
        #endregion

        /// <summary>
        /// ロード時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmJobEdit_Load(object sender, EventArgs e)
        {
            this.cmbMojicode.Items.AddRange(DefaultModule.GetMojiCode());
            this.cmbMojicode.SelectedIndex = 0;

            if (prpJOB_ID == null)
            {
                //新規登録の場合
                this.txtSakuban.Text = prpSakuban;
                this.txtAnkenName.Text = prpAnken;
                this.txtCustomerName.Text = prpCustomer;
                this.txtEndUser.Text = prpEndUser;
                this.txtJobName.Text = prpJob;

                this.btnRegister.Text = "新規登録";
                this.btnRegister.Enabled = false;
            }
            else
            {
                //更新の場合
                string strSQL = "";
                SQLProcess sqlProcess = new SQLProcess();
                try
                {
                    strSQL = "SELECT T1.JOB_ID,T1.作番,T4.名称 AS 顧客名,T3.エンドユーザー1 + T3.エンドユーザー2 AS エンドユーザー,T2.案件名1 + T2.案件名2 AS 案件名,T1.ジョブ名,T1.出力日時,T1.更新日時,T1.削除フラグ," +
                             "T1.イメージ親フォルダ,T1.検索拡張子,T1.項目の結合文字,項目列番号1,項目列番号2,項目列番号3,項目列番号4,項目列番号5,ロット列番号";
                    strSQL += " FROM T_しおりツール_ジョブリスト AS T1";
                    strSQL += " INNER JOIN DailyReport_Test.dbo.T_案件管理 AS T2 ON T1.作番 = T2.作番コード";
                    strSQL += " INNER JOIN DailyReport_Test.dbo.M_顧客 AS T3 ON T2.顧客ID = T3.顧客ID";
                    strSQL += " INNER JOIN DailyReport_Test.dbo.M_顧客マスタ AS T4 ON T3.コード = T4.コード";
                    strSQL += " INNER JOIN T_しおりツール_項目情報 AS T5 ON T1.JOB_ID = T5.JOB_ID";
                    strSQL += " WHERE T1.JOB_ID = " + prpJOB_ID;
                    DataTable dtUpdateJob = sqlProcess.DB_SELECT_DATATABLE(strSQL);

                    this.txtSakuban.Text = dtUpdateJob.Rows[0]["作番"].ToString();
                    this.txtAnkenName.Text = dtUpdateJob.Rows[0]["案件名"].ToString();
                    this.txtCustomerName.Text = dtUpdateJob.Rows[0]["顧客名"].ToString();
                    this.txtEndUser.Text = dtUpdateJob.Rows[0]["エンドユーザー"].ToString();
                    this.txtJobName.Text = dtUpdateJob.Rows[0]["ジョブ名"].ToString();
                    this.txtImageFolder.Text = dtUpdateJob.Rows[0]["イメージ親フォルダ"].ToString();
                    this.cmbExtension.Text = dtUpdateJob.Rows[0]["検索拡張子"].ToString();
                    this.cmbJoinchar.SelectedIndex = (int)dtUpdateJob.Rows[0]["項目の結合文字"] - 2;


                    fgrColSetting.BeginUpdate();
                    //列数確定
                    string[] ColNo = new string[6] { "ロット列番号", "項目列番号1", "項目列番号2", "項目列番号3", "項目列番号4", "項目列番号5" };
                    string[] ColName = new string[6] { "ロット名", "項目1", "項目2", "項目3", "項目4", "項目5" };

                    for (int i = 0; i <= ColNo.Length - 1; i++)
                    {
                        if(dtUpdateJob.Rows[0][ColNo[i]].ToString() != "")
                        {
                            fgrColSetting.Cols.Count += 1;
                            fgrColSetting.Rows.Count = 2;
                            fgrColSetting.Cols[fgrColSetting.Cols.Count - 1].Name = ColName[i];
                            fgrColSetting.Cols[fgrColSetting.Cols.Count - 1].AllowEditing = false;
                            fgrColSetting.Cols[fgrColSetting.Cols.Count - 1].AllowDragging = false;
                            fgrColSetting.Cols[fgrColSetting.Cols.Count - 1].AllowSorting = false;
                            fgrColSetting.Rows[0][ColName[i]] = ColName[i];
                            fgrColSetting.Rows[1][ColName[i]] = dtUpdateJob.Rows[0][ColNo[i]].ToString() + "列目";
                        }
                    }
                    fgrColSetting.Rows.Fixed = 2;

                    strSQL = "SELECT * FROM T_しおりツール_しおりリスト";
                    strSQL += " WHERE JOB_ID = " + prpJOB_ID;
                    DataTable dtShiori = sqlProcess.DB_SELECT_DATATABLE(strSQL);

                    //行読込
                    for (int i = 0; i <= dtShiori.Rows.Count - 1; ++i)
                    {
                        fgrColSetting.Rows.Count += 1;
                        for (int j = 0; j <= fgrColSetting.Cols.Count - 1; j++)
                        {
                            fgrColSetting.Rows[i+2][j] = dtShiori.Rows[i][fgrColSetting.Rows[0][j].ToString()].ToString();
                        }
                    }
                    fgrColSetting.Cols.DefaultSize = 120;

                }
                catch (InvalidCastException ex) when (ex.Data != null)
                {
                    MessageBox.Show(ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    SQLProcess.Close();
                    fgrColSetting.EndUpdate();
                }

                this.btnLoad.Text = "追加";
                this.btnRegister.Text = "更新";
            }

        }

        /// <summary>
        /// 戻るボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// ドラッグ時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        /// <summary>
        /// ドラッグドロップ時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_DragDrop(object sender, DragEventArgs e)
        {
            string[] strFile = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            TextBox txtControl = (TextBox)sender;

            if (txtControl.Name == "txtShioriFile")
            {
                if (System.IO.File.Exists(strFile[0]) && (System.IO.Path.GetExtension(strFile[0]) == ".txt" || System.IO.Path.GetExtension(strFile[0]) == ".csv" || System.IO.Path.GetExtension(strFile[0]) == ".tsv"))
                {
                    txtControl.Text = strFile[0];
                }
                else
                {
                    MessageBox.Show("エラー", "ドロップされたオブジェクトはテキストファイルではありません", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                if (System.IO.Directory.Exists(strFile[0]))
                {
                    txtControl.Text = strFile[0];
                }
                else
                {
                    MessageBox.Show("エラー", "ドロップされたオブジェクトはフォルダではありません", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// フォルダオープン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFolderOpen_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            TextBox txt = btn.Name == "btnOpenImageFolder" ? this.txtImageFolder : this.txtLogFolder;
            Microsoft.WindowsAPICodePack.Dialogs.CommonOpenFileDialog cofd = new Microsoft.WindowsAPICodePack.Dialogs.CommonOpenFileDialog();

            cofd.IsFolderPicker = true;
            
            if (System.IO.Directory.Exists(txt.Text))
            {
                cofd.InitialDirectory = txt.Text;
            }
            
            if (cofd.ShowDialog() == Microsoft.WindowsAPICodePack.Dialogs.CommonFileDialogResult.Ok)
            {
                txt.Text = cofd.FileName;
            }
        }

        /// <summary>
        /// ファイルオープン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFileOpen_Click(object sender, EventArgs e)
        {
            string txt = this.txtShioriFile.Text;
            OpenFileDialog ofd = new OpenFileDialog();
            if (txt != "")
            {
                if (System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(txt)))
                {
                    ofd.InitialDirectory = System.IO.Path.GetDirectoryName(txt);
                    ofd.FileName = System.IO.Path.GetFileName(txt);
                }
            }
            ofd.Filter = "CSVファイル(*.csv)|*.csv|TSVファイル(*.tsv)|*.tsv|TXTファイル(*.txt)|*.txt";
            ofd.FilterIndex = 1;
            ofd.Title = "読み込むしおりファイルを選択してください。";
            ofd.RestoreDirectory = true;
            ofd.CheckPathExists = true;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                this.txtShioriFile.Text = ofd.FileName;
            }
        }

        /// <summary>
        /// 読み込みチェック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLoadCheck_Click(object sender, EventArgs e)
        {
            if (this.txtShioriFile.Text == "")
            {
                MessageBox.Show("しおりファイルを指定してください。","エラー",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            if(MessageBox.Show("読込チェックを開始します。よろしいですか。", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
            {
                return;
            }

            try
            {
                string line = "";
                string[] al = new string[0];
                int cntline = 0;

                //しおりテキスト読込
                using (System.IO.StreamReader sr = new System.IO.StreamReader(this.txtShioriFile.Text, Encoding.GetEncoding(this.cmbMojicode.Text)))
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        cntline++;
                        Array.Resize(ref al, cntline);
                        al[cntline - 1] = this.rbComma.Checked ? line.Replace(",","\t") : line;
                    }
                }

                //区切り文字
                char Delimita = DefaultModule.GetDelimita()[this.rbComma.Checked ? 0 : 1];

                //列数確定
                string[] header = al[0].Split(Delimita);
                fgrColSetting.Rows.Count = 2;
                fgrColSetting.Rows.Fixed = 1;
                fgrColSetting.Rows.Frozen = 1;
                fgrColSetting.Cols.Count = header.Length;
                fgrColSetting.Rows[1].ComboList = "-|ロット名|項目1|項目2|項目3|項目4|項目5";
                fgrColSetting.ShowButtons = C1.Win.C1FlexGrid.ShowButtonsEnum.Always;
                for (int i = 0; i <= header.Length - 1; ++i)
                {
                    fgrColSetting.Cols[i].Caption = this.chkHeader.Checked ? header[i] : string.Format("{0}列目", i + 1);
                    fgrColSetting.Cols[i].Name = string.Format("{0}列目", i + 1);
                    fgrColSetting.Cols[i].AllowSorting = false;
                    fgrColSetting.Cols[i].AllowDragging = false;
                    //fgrColSetting.Cols[i].AllowEditing = false;
                    //fgrColSetting.Rows[1].AllowEditing = true;//2行目のみ編集可能
                    fgrColSetting[1,i] = "-";
                }

                fgrColSetting.Cols.DefaultSize = 120;

                //行数確定
                int startRow = this.chkHeader.Checked ? 1 : 0;

                //プログレス
                this.ProgressBar.Minimum = 0;
                this.ProgressBar.Maximum = al.Length;

                this.ProgressBar.Value = startRow;
                this.lblProgress.Text = String.Format("{0:D6}", this.ProgressBar.Value) + "/" + String.Format("{0:D6}", this.ProgressBar.Maximum);

                fgrColSetting.BeginUpdate();
                for (int i = startRow; i <= al.Length - 1; ++i)
                {
                    // データを設定
                    fgrColSetting.AddItem(al[i]);

                    fgrColSetting.Rows[i+1].AllowEditing = false;
                    ++this.ProgressBar.Value;
                    this.lblProgress.Text = String.Format("{0:D6}", this.ProgressBar.Value) + "/" + String.Format("{0:D6}", this.ProgressBar.Maximum);
                    System.Windows.Forms.Application.DoEvents();
                }
                fgrColSetting.EndUpdate();
                MessageBox.Show("読込チェックが完了しました。", "完了", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "読込形式とファイル形式が一致しません。", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 登録・更新ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("この内容で登録または更新を行います。よろしいですか。", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
            {
                return;
            }
            string strSQL = "";
            SQLProcess sqlProcess = new SQLProcess();
            //プログレス
            this.ProgressBar.Minimum = 0;
            this.ProgressBar.Maximum = fgrColSetting.Rows.Count - 2;

            this.ProgressBar.Value = 0;
            this.lblProgress.Text = String.Format("{0:D6}", this.ProgressBar.Value) + "/" + String.Format("{0:D6}", this.ProgressBar.Maximum);

            try
            {
                //ジョブリスト書き込み
                int JoinChrNo = (int)this.cmbJoinchar.SelectedIndex + 2;
                strSQL = "INSERT INTO T_しおりツール_ジョブリスト";
                strSQL += " SELECT ISNULL(MAX(JOB_ID), 0)+1";
                strSQL += ",'" + this.txtSakuban.Text + "'";
                strSQL += ",'" + this.txtJobName.Text.Replace("'","''") + "'";
                strSQL += ",'" + this.txtImageFolder.Text.Replace("'", "''") + "'";
                strSQL += ",'" + this.cmbExtension.Text + "'";
                strSQL += ",'" + JoinChrNo + "'";
                strSQL += ",''";
                strSQL += ",'" + DateTime.Now + "'";
                strSQL += ",0";
                strSQL += " FROM T_しおりツール_ジョブリスト";
                sqlProcess.DB_UPDATE(strSQL);

                strSQL = "SELECT JOB_ID FROM T_しおりツール_ジョブリスト";
                strSQL += " WHERE 作番 = '" + this.txtSakuban.Text + "'";
                strSQL += " AND ジョブ名 = '" + this.txtJobName.Text.Replace("'", "''") + "'";
                int JobID = (int)sqlProcess.DB_EXECUTE_SCALAR(strSQL);


                Dictionary<string, int> dcKoumoku = new Dictionary<string, int> { };
                for (int i = 0; i <= fgrColSetting.Cols.Count - 1; ++i)
                {
                    if((string)this.fgrColSetting[1, i] != "-")
                    {
                        dcKoumoku.Add((string)this.fgrColSetting[1, i], i);
                    }
                }

                //項目情報書き込み
                strSQL = "INSERT INTO T_しおりツール_項目情報";
                strSQL += " VALUES(" + JobID;
                strSQL += ",'" + dcKoumoku["項目1"] + "'";
                strSQL += ",'" + (dcKoumoku.ContainsKey("項目2") ? dcKoumoku["項目2"].ToString() : "") + "'";
                strSQL += ",'" + (dcKoumoku.ContainsKey("項目3") ? dcKoumoku["項目3"].ToString() : "") + "'";
                strSQL += ",'" + (dcKoumoku.ContainsKey("項目4") ? dcKoumoku["項目4"].ToString() : "") + "'";
                strSQL += ",'" + (dcKoumoku.ContainsKey("項目5") ? dcKoumoku["項目5"].ToString() : "") + "'";
                strSQL += ",'" + dcKoumoku["ロット名"] + "')";
                sqlProcess.DB_UPDATE(strSQL);

                char c = DefaultModule.GetDelimita()[this.cmbJoinchar.SelectedIndex + 2];
                string MergeChr = c.ToString().Replace("\0", "");
                //しおりリスト書き込み
                for (int i = 2; i <= fgrColSetting.Rows.Count - 1; i++)
                {
                    //項目値
                    string Koumoku1 = fgrColSetting[i, dcKoumoku["項目1"]].ToString();
                    string Koumoku2 = (dcKoumoku.ContainsKey("項目2") ? fgrColSetting[i, dcKoumoku["項目2"]].ToString().Replace("'", "''") : "");
                    string Koumoku3 = (dcKoumoku.ContainsKey("項目3") ? fgrColSetting[i, dcKoumoku["項目3"]].ToString().Replace("'", "''") : "");
                    string Koumoku4 = (dcKoumoku.ContainsKey("項目4") ? fgrColSetting[i, dcKoumoku["項目4"]].ToString().Replace("'", "''") : "");
                    string Koumoku5 = (dcKoumoku.ContainsKey("項目5") ? fgrColSetting[i, dcKoumoku["項目5"]].ToString().Replace("'", "''") : "");

                    string[] aryKoumoku = new string[] { Koumoku1,Koumoku2,Koumoku3,Koumoku4,Koumoku5 };
                    //しおり結合
                    string Shiori = "";
                    for (int j = 0; j <= aryKoumoku.Length -1; j++)
                    {
                        string Merge = j == 0 ? "" : MergeChr.ToString();
                        Shiori += aryKoumoku[j] == "" ? "" : Merge + aryKoumoku[j];
                    }

                    strSQL = "INSERT INTO T_しおりツール_しおりリスト";
                    strSQL += " SELECT " + JobID;
                    strSQL += ", ISNULL(MAX(Shiori_ID), 0)+1";
                    strSQL += ",'" + fgrColSetting[i, dcKoumoku["ロット名"]] + "'";
                    strSQL += ",'" + Koumoku1 + "'";
                    strSQL += ",'" + Koumoku2 + "'";
                    strSQL += ",'" + Koumoku3 +"'";
                    strSQL += ",'" + Koumoku4 + "'";
                    strSQL += ",'" + Koumoku5 + "'";
                    strSQL += ",1";
                    strSQL += ",'" + Shiori +"'";
                    strSQL += ",'',0,''";
                    strSQL += " FROM T_しおりツール_しおりリスト";
                    strSQL += " WHERE JOB_ID = " + JobID;
                    sqlProcess.DB_UPDATE(strSQL);
                    ++this.ProgressBar.Value;
                    this.lblProgress.Text = String.Format("{0:D6}", this.ProgressBar.Value) + "/" + String.Format("{0:D6}", this.ProgressBar.Maximum);
                    System.Windows.Forms.Application.DoEvents();
                }

                MessageBox.Show("登録が完了しました。", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (InvalidCastException ex) when (ex.Data != null)
            {
                MessageBox.Show(ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                SQLProcess.Close();
            }
        }

        /// <summary>
        /// 項目編集後
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fgrColSetting_BeforeEdit_1(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            if (fgrColSetting.Row <= 0)
            {
                return;
            }
            //項目設定フラグ
            bool flgKoumokuSetting = false;
            //ロット設定フラグ
            bool flgLotSetting = false;
            //編集されたセル
            string selectCell = (string)this.fgrColSetting.GetData(1, fgrColSetting.Col);
            for (int i = 0; i <= fgrColSetting.Cols.Count - 1; ++i)
            {
                if (i != fgrColSetting.Col && selectCell == (string)this.fgrColSetting.GetData(1, i))
                {
                    this.fgrColSetting[1, i] = "-";
                }
                if ((string)this.fgrColSetting.GetData(1, i) == "項目1")
                {
                    flgKoumokuSetting = true;
                }
                if ((string)this.fgrColSetting.GetData(1, i) == "ロット名")
                {
                    flgLotSetting = true;
                }
            }
            if (flgKoumokuSetting == true && flgLotSetting == true)
            {
                this.btnRegister.Enabled = true;
            }
            else
            {
                this.btnRegister.Enabled = false;
            }
        }
    }
}
