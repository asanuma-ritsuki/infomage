using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PDF_Shiori
{
    public partial class frmSqlSetting : C1.Win.C1Ribbon.C1RibbonForm
    {
        string initDataSource = Properties.Settings.Default.SQL_DataSource;
        string initDataBase = Properties.Settings.Default.SQL_DataBase;
        string initUserID = Properties.Settings.Default.SQL_UserID;
        string initPassword = Properties.Settings.Default.SQL_PassWord;

        public frmSqlSetting()
        {
            InitializeComponent();
        }
        /// <summary>
        /// ロード時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmSQLSrtting_Load(object sender, EventArgs e)
        {
            txtDataSource.Text = Properties.Settings.Default.SQL_DataSource;
            txtDataBase.Text = Properties.Settings.Default.SQL_DataBase;
            txtUserID.Text = Properties.Settings.Default.SQL_UserID;
            txtPassword.Text = Properties.Settings.Default.SQL_PassWord;
        }

        /// <summary>
        /// キャンセルボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.SQL_DataSource = initDataSource;
            Properties.Settings.Default.SQL_DataBase = initDataBase;
            Properties.Settings.Default.SQL_UserID = initUserID;
            Properties.Settings.Default.SQL_PassWord = initPassword;
            Properties.Settings.Default.Save();
            this.Close();
        }

        /// <summary>
        /// 接続テスト
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTest_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.SQL_DataSource = txtDataSource.Text;
            Properties.Settings.Default.SQL_DataBase = txtDataBase.Text;
            Properties.Settings.Default.SQL_UserID = txtUserID.Text;
            Properties.Settings.Default.SQL_PassWord = txtPassword.Text;
            Properties.Settings.Default.Save();

            System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection();
            try
            {
                con.ConnectionString = "Data Source=" + Properties.Settings.Default.SQL_DataSource + ";" +
                                        "Initial Catalog=" + Properties.Settings.Default.SQL_DataBase + ";" +
                                        "Persist Security Info=True" + ";" +
                                        "User ID=" + Properties.Settings.Default.SQL_UserID + ";" +
                                        "Password=" + Properties.Settings.Default.SQL_PassWord + ";";
                con.Open();
                con.Close();
                MessageBox.Show("接続に成功しました。", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (InvalidCastException ex) when (ex.Data != null)
            {
                MessageBox.Show(ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// OKボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e) { 
            Properties.Settings.Default.SQL_DataSource = txtDataSource.Text;
            Properties.Settings.Default.SQL_DataBase = txtDataBase.Text;
            Properties.Settings.Default.SQL_UserID = txtUserID.Text;
            Properties.Settings.Default.SQL_PassWord = txtPassword.Text;
            Properties.Settings.Default.Save();
            this.Close();
        }
    }
}
