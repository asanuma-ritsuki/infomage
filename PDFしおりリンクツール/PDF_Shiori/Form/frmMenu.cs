using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static PDF_Shiori.DefaultModule;
using C1.Win.C1FlexGrid;

namespace PDF_Shiori
{
    public partial class frmMenu : C1.Win.C1Ribbon.C1RibbonForm
    {
        public frmMenu()
        {
            InitializeComponent();
        }

        private void frmMenu_Load(object sender, EventArgs e)
        {
            fgrJobList_Update();
        }

        /// <summary>
        /// 管理画面表示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnManage_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        {
            C1.Win.C1Command.C1Command btnClick = (C1.Win.C1Command.C1Command)sender;
            //frmLogin.ShowMiniForm(param);

            frmLogin frm = new frmLogin();
            frm.prpButtonName = btnClick.Name;
            frm.prpForm = this;
            frm.ShowDialog();
        }

        /// <summary>
        /// DB接続設定画面表示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSQLSetting_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        {
            frmSqlSetting frm = new frmSqlSetting();
            frm.ShowDialog();
        }

        #region "プライベートメソッド"
        private void fgrJobList_Update()
        {
            string strSQL = "";
            SQLProcess sqlProcess = new SQLProcess();
			/*T1.出力日時,*/
            strSQL = "SELECT T1.JOB_ID,T1.作番,T4.名称 AS 顧客名,T3.エンドユーザー1 + T3.エンドユーザー2 AS エンドユーザー,T2.案件名1 + T2.案件名2 AS 案件名,T1.ジョブ名,T5.ロット総数,T5.ロット総数 - T5.ロット完了数 AS ロット完了数,T1.更新日時,T1.削除フラグ";
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
                for (int i = 0; i <= dtJobList.Rows.Count - 1; i++)
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
                        // 行の高さを設定
                        fgrJobList.Rows[this.fgrJobList.Rows.Count - 1].Height = 30;
                    }
                }

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
        #endregion

        /// <summary>
        /// セルダブルクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fgrJobList_DoubleClick(object sender, MouseEventArgs e)
        {
            var Row = fgrJobList.MouseRow;
            if (Row <= 0)
            {
                return;
            }

            frmLogin frm = new frmLogin();

            frm.prpButtonName = "fgrJobList";
            frm.prpForm = this;
            frm.prpJob_ID = (int)fgrJobList[Row, "JOB_ID"];
            frm.ShowDialog();
        }
    }
}
