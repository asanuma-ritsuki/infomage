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
using C1.Win.C1FlexGrid;

namespace PDF_Shiori
{
    public partial class frmManage : C1.Win.C1Ribbon.C1RibbonForm
    {
        public frmManage()
        {
            InitializeComponent();
        }

        ///// <summary>
        ///// 閉じる無効
        ///// </summary>
        ///// <param name="m"></param>
        //[SecurityPermission(SecurityAction.Demand,Flags = SecurityPermissionFlag.UnmanagedCode)]
        //protected override void WndProc(ref Message m)
        //{
        //    const int WM_SYSCOMMAND = 0x112;
        //    const long SC_CLOSE = 0xF060L;

        //    if (m.Msg == WM_SYSCOMMAND &&
        //        (m.WParam.ToInt64() & 0xFFF0L) == SC_CLOSE)
        //    {
        //        return;
        //    }

        //    base.WndProc(ref m);
        //}

        private void frmManage_Load(object sender, EventArgs e)
        {
            fgrJobList_Update();
        }

        /// <summary>
        /// メニューに戻る
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBackMenu_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 作番から案件検索
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string strSQL = "";
            SQLProcess sqlProcess = new SQLProcess();

            try
            {
                strSQL = "SELECT T_案件管理.案件名1 + T_案件管理.案件名2 AS 案件名, M_顧客.エンドユーザー1 +  M_顧客.エンドユーザー2 AS エンドユーザー, M_顧客マスタ.名称";
                strSQL += " FROM [DailyReport_Test].[dbo].T_案件管理";
                strSQL += " INNER JOIN [DailyReport_Test].[dbo].M_顧客 ON T_案件管理.顧客ID = M_顧客.顧客ID";
                strSQL += " INNER JOIN [DailyReport_Test].[dbo].M_顧客マスタ ON M_顧客.コード = M_顧客マスタ.コード";
                strSQL += " WHERE T_案件管理.作番コード = '" + this.txtSakuban.Text +  "'";

                DataTable dtCustomerInfo = sqlProcess.DB_SELECT_DATATABLE(strSQL);

                if (dtCustomerInfo.Rows.Count == 0)
                {
                    MessageBox.Show("入力された作番は見つかりませんでした。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                this.txtCustomerName.Text = dtCustomerInfo.Rows[0]["名称"].ToString();
                this.txtEndUser.Text = dtCustomerInfo.Rows[0]["エンドユーザー"].ToString();
                this.txtAnkenName.Text = dtCustomerInfo.Rows[0]["案件名"].ToString();
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
        /// 新規登録
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRegister_Click(object sender, EventArgs e)
        {
            if(txtSakuban.Text == "")
            {
                MessageBox.Show("作番を入力してください。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtAnkenName.Text == "" && txtEndUser.Text == "" && txtCustomerName.Text == "")
            {
                MessageBox.Show("作番検索ボタンで案件名を確定させてください。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtJOBName.Text == "")
            {
                MessageBox.Show("作業名を入力してください。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //すでに登録されているかチェック
            string strSQL = "";
            strSQL = "SELECT COUNT(*) FROM T_しおりツール_ジョブリスト";
            strSQL += " WHERE 作番 = '" + this.txtSakuban.Text + "'";
            strSQL += " AND ジョブ名 = '" + this.txtJOBName.Text + "'";
            SQLProcess sqlProcess = new SQLProcess();
            try
            {
                int JobCount = (int)sqlProcess.DB_EXECUTE_SCALAR(strSQL);
                if (JobCount >= 1)
                {
                    MessageBox.Show("既に登録されているジョブです。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (InvalidCastException ex) when(ex.Data != null)
            {
                MessageBox.Show(ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                SQLProcess.Close();
            }


            frmJobEdit frm = new frmJobEdit();

            frm.prpSakuban = this.txtSakuban.Text;
            frm.prpAnken = this.txtAnkenName.Text;
            frm.prpCustomer = this.txtCustomerName.Text;
            frm.prpEndUser = this.txtEndUser.Text;
            frm.prpJob = this.txtJOBName.Text;

            frm.FormClosed += new FormClosedEventHandler(frmJobEdit_FormClosed);
            frm.ShowDialog();
        }

        //閉じた時
        private void frmJobEdit_FormClosed(object sender, FormClosedEventArgs e)
        {
            fgrJobList_Update();
        }

        /// <summary>
        /// クローズ処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmManage_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmMenu frm = new frmMenu();
            frm.Show();
        }

        #region "プライベートメソッド"
        private void fgrJobList_Update()
        {
            string strSQL = "";
            SQLProcess sqlProcess = new SQLProcess();

            strSQL = "SELECT T1.JOB_ID,T1.作番,T4.名称 AS 顧客名,T3.エンドユーザー1 + T3.エンドユーザー2 AS エンドユーザー,T2.案件名1 + T2.案件名2 AS 案件名,T1.ジョブ名,T5.ロット総数,T5.ロット総数 - T5.ロット完了数 AS ロット完了数,T1.出力日時,T1.更新日時,T1.削除フラグ";
            strSQL += " FROM T_しおりツール_ジョブリスト AS T1";
            strSQL += " INNER JOIN DailyReport_Test.dbo.T_案件管理 AS T2 ON T1.作番 = T2.作番コード";
            strSQL += " INNER JOIN DailyReport_Test.dbo.M_顧客 AS T3 ON T2.顧客ID = T3.顧客ID";
            strSQL += " INNER JOIN DailyReport_Test.dbo.M_顧客マスタ AS T4 ON T3.コード = T4.コード";
            strSQL += " INNER JOIN (SELECT A1.JOB_ID,A1.ロット数 AS ロット総数,A2.ロット数 AS ロット完了数";
            strSQL += " FROM(SELECT JOB_ID,COUNT(DISTINCT ロット名) AS ロット数";
            strSQL += " FROM T_しおりツール_しおりリスト";
            strSQL += " GROUP BY JOB_ID) AS A1";
            strSQL += " INNER JOIN(SELECT JOB_ID,COUNT(DISTINCT ロット名) AS ロット数";
            strSQL += " FROM T_しおりツール_しおりリスト";
            strSQL += " GROUP BY JOB_ID,リンクファイル名";
            strSQL += " HAVING リンクファイル名 = '') AS A2 ON A1.JOB_ID = A2.JOB_ID) AS T5 ON T1.JOB_ID = T5.JOB_ID";

            try
            {
                this.fgrJobList.Rows.Count = 1;

                DataTable dtJobList = sqlProcess.DB_SELECT_DATATABLE(strSQL);
                for (int i = 0; i <= dtJobList.Rows.Count -1; i++)
                {
                    if ((bool)dtJobList.Rows[i]["削除フラグ"] == false)
                    {
                        this.fgrJobList.Rows.Count += 1;
                        this.fgrJobList[this.fgrJobList.Rows.Count - 1, "No."] = this.fgrJobList.Rows.Count - 1;
                        this.fgrJobList[this.fgrJobList.Rows.Count - 1, "JOB_ID"] = dtJobList.Rows[i]["JOB_ID"];
                        this.fgrJobList[this.fgrJobList.Rows.Count - 1, "作番"] = dtJobList.Rows[i]["作番"];
                        this.fgrJobList[this.fgrJobList.Rows.Count - 1, "顧客名"] = dtJobList.Rows[i]["顧客名"];
                        this.fgrJobList[this.fgrJobList.Rows.Count - 1, "エンドユーザー"] = dtJobList.Rows[i]["エンドユーザー"];
                        this.fgrJobList[this.fgrJobList.Rows.Count - 1, "案件名"] = dtJobList.Rows[i]["案件名"];
                        this.fgrJobList[this.fgrJobList.Rows.Count - 1, "ジョブ名"] = dtJobList.Rows[i]["ジョブ名"];
                        this.fgrJobList[this.fgrJobList.Rows.Count - 1, "進捗"] = dtJobList.Rows[i]["ロット完了数"] + "/" + dtJobList.Rows[i]["ロット総数"];
                        this.fgrJobList[this.fgrJobList.Rows.Count - 1, "出力"] = "出力";
                        this.fgrJobList[this.fgrJobList.Rows.Count - 1, "更新"] = "更新";
                        this.fgrJobList[this.fgrJobList.Rows.Count - 1, "削除"] = "削除";
                        // 行の高さを設定
                        fgrJobList.Rows[this.fgrJobList.Rows.Count - 1].Height = 30;
                    }
                }

                // ボタンの通常時の背景画像を設定
                fgrJobList.Cols["出力"].StyleNew.BackgroundImage = Properties.Resources.Buttons;
                fgrJobList.Cols["出力"].Style.BackgroundImageLayout = ImageAlignEnum.Stretch;
                fgrJobList.Cols["出力"].Style.TextAlign = TextAlignEnum.CenterCenter;
                fgrJobList.Cols["更新"].StyleNew.BackgroundImage = Properties.Resources.Buttons;
                fgrJobList.Cols["更新"].Style.BackgroundImageLayout = ImageAlignEnum.Stretch;
                fgrJobList.Cols["更新"].Style.TextAlign = TextAlignEnum.CenterCenter;

                fgrJobList.Cols["削除"].StyleNew.BackgroundImage = Properties.Resources.Buttons;
                fgrJobList.Cols["削除"].Style.BackgroundImageLayout = ImageAlignEnum.Stretch;
                fgrJobList.Cols["削除"].Style.TextAlign = TextAlignEnum.CenterCenter;

                // Buttonコントロールを設定
                Button btn1 = new Button();
                btn1.Click += new System.EventHandler(btn1_Click);
                btn1.BackColor = SystemColors.Control;
                btn1.TextAlign = ContentAlignment.MiddleCenter;
                fgrJobList.Cols["出力"].Editor = btn1;
                fgrJobList.Cols["更新"].Editor = btn1;
                fgrJobList.Cols["削除"].Editor = btn1;

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

        private void flex_MouseEnterCell(object sender, RowColEventArgs e)
        {
            // データ行の場合、マウスポインタが
            // セル上に置かれたら、セルを編集状態にし、
            // カスタムエディタのボタンを表示
            if ((e.Col >= 8) && (e.Row >= 1))
            {
                fgrJobList.StartEditing(e.Row, e.Col);
            }
        }

        private void btn1_Click(object sender, System.EventArgs e)
        {
            // Buttonコントロールがクリックされた時
            string JOB_ID = this.fgrJobList.GetData(fgrJobList.Row, "JOB_ID").ToString();
            int No = (int)this.fgrJobList.GetData(fgrJobList.Row, "No.");
            string ColName = (string)this.fgrJobList.GetData(0, fgrJobList.Col);

            SQLProcess sqlProcess = new SQLProcess();
            string strSQL = "";

            switch (ColName)
            {
                case "出力":
                    frmOutput frmO = new frmOutput();

                    frmO.prpJOB_ID = JOB_ID;

                    frmO.FormClosed += new FormClosedEventHandler(frmJobEdit_FormClosed);
                    frmO.ShowDialog();
                    break;
                case "更新":
                    frmJobEdit frmE = new frmJobEdit();

                    frmE.prpJOB_ID = JOB_ID;

                    frmE.FormClosed += new FormClosedEventHandler(frmJobEdit_FormClosed);
                    frmE.ShowDialog();
                    break;
                case "削除":
                    if(MessageBox.Show("No." + No + "のジョブを削除します。\nよろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
                    {
                        break;
                    }
                    else
                    {
                        try
                        {
                            strSQL = "UPDATE T_しおりツール_ジョブリスト";
                            strSQL += " SET 削除フラグ = 1";
                            strSQL += " WHERE JOB_ID = " + JOB_ID;
                            sqlProcess.DB_UPDATE(strSQL);
                            fgrJobList_Update();
                            MessageBox.Show("ジョブを1件削除しました。", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        catch (InvalidCastException ex) when (ex.Data != null)
                        {
                            MessageBox.Show(ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            SQLProcess.Close();
                        }
                        break;
                    }

            }
        }
        #endregion

        /// <summary>
        /// 作番変更時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSakuban_TextChanged(object sender, EventArgs e)
        {
            this.txtAnkenName.Text = "";
            this.txtCustomerName.Text = "";
            this.txtEndUser.Text = "";
        }
    }
}
