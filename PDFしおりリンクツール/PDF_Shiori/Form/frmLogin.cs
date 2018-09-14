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

namespace PDF_Shiori
{
    public partial class frmLogin : C1.Win.C1Ribbon.C1RibbonForm
    {
        #region プロパティ
            private string m_prmButtonName;    //引き渡されたボタン名
            private frmMenu m_prmForm;  //親フォームインスタンス
            private int m_Job_ID;

            /// <summary>
            /// ボタン名プロパティ
            /// </summary>
            public string prpButtonName
            {
                get{return m_prmButtonName;}
                set{m_prmButtonName = value;}
            }
            /// <summary>
            /// フォームプロパティ
            /// </summary>
            public frmMenu prpForm
            {
                get{return m_prmForm;}
                set{m_prmForm = value;}
            }
            /// <summary>
            /// JOB_ID
            /// </summary>
            public int prpJob_ID
            {
                get { return m_Job_ID; }
                set { m_Job_ID = value; }
            }

        #endregion

        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            this.cmbSection.Text = "選択してください。";


            SQLProcess sqlProcess = new SQLProcess();
            string strSQL = "SELECT 従業員区分ID,従業員区分 FROM [DailyReport_Test].[dbo].[M_従業員区分]";
            try
            {
                DataTable dtSection = sqlProcess.DB_SELECT_DATATABLE(strSQL);

                cmbSection.ValueMember = "従業員区分ID";
                cmbSection.DisplayMember = "従業員区分";
                cmbSection.ColumnHeaders = false;

                cmbSection.DataSource = dtSection;
				cmbSection.Splits[0].DisplayColumns[0].Width = 0;
				cmbSection.Splits[0].DisplayColumns[1].Width = cmbSection.Width - 21;

				//デバッグ用
				//cmbSection.SelectedValue = 2;
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
        /// セクション選択
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbSection_SelectedValueChanged(object sender, EventArgs e)
        {
            //セクションIDが0の場合動作をスルーする(ログイン先コンボボックス選択時は必ず0となるため)
            if ((int)cmbSection.SelectedValue == 0)
            {
                return;
            }

            SQLProcess sqlProcess = new SQLProcess();
            //M_従業員から値取得
            string strSQL = "SELECT 従業員ID, 従業員名 FROM [DailyReport_Test].[dbo].[M_従業員] ";
            strSQL += "WHERE 従業員区分ID = " + cmbSection.SelectedValue + " ";
            strSQL += "AND 有効フラグ = 1 ";
            strSQL += "ORDER BY 従業員区分ID, 従業員名";
            try
            {
                DataTable dtUserName = sqlProcess.DB_SELECT_DATATABLE(strSQL);

                cmbUserName.ValueMember = "従業員ID";
                cmbUserName.DisplayMember = "従業員名";

                cmbUserName.ColumnHeaders = false;

                cmbUserName.DataSource = dtUserName;

                //ユーザー名をテキスト入力可能形式にしてオートコンプリートを実装する
                //オートコンプリートモードの設定
                cmbUserName.AutoCompletion = true;

                cmbUserName.SelectedValue = 481;
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
        /// キーダウンイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            Keys aa = e.KeyCode;
            switch (aa)
            {
                case Keys.Enter:
                    btnLogin.PerformClick();
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// ログインボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, EventArgs e)
        {

            if(cmbUserName.SelectedValue == null)
            {
                return;
            }
            int iEmployeeID = (int)cmbUserName.SelectedValue;
            string strPassword = txtPassword.Text;
            string strSQL = "";
            strSQL += "SELECT T1.従業員ID, T1.従業員名, T2.拘束時間 FROM [DailyReport_Test].[dbo].M_従業員 AS T1 INNER JOIN ";
            strSQL += "[DailyReport_Test].[dbo].M_従業員区分 AS T2 ON T1.従業員区分ID = T2.従業員区分ID ";
            strSQL += "WHERE T1.従業員ID = " + iEmployeeID + " AND ";
            strSQL += "T1.パスワード = '" + strPassword + "'";

            //管理ボタンから遷移した場合
            if (prpButtonName == "btnManage")
            {
                strSQL += " AND T2.拘束時間 = 7.92";
            }

            SQLProcess sqlProcess = new SQLProcess();
            try
            {
                DataTable dt = sqlProcess.DB_SELECT_DATATABLE(strSQL);
                if (dt.Rows.Count == 1)
                {
                    //自身を閉じる
                    this.Dispose();

                    //管理画面・入力画面を開く
                    if (prpButtonName == "btnManage") {
                        frmManage frm = new frmManage();
                        frm.Show();
                    }
                    else
                    {
                        frmMain frm = new frmMain();
                        frm.prpJob_ID = prpJob_ID;
                        frm.Show();
                    }

                    //メニューを隠す
                    prpForm.Close();
                }
                else
                {
                    MessageBox.Show("ログインに失敗しました。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        /// <summary>
        /// キャンセル
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
