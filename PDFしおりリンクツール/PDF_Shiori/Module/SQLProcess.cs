using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDF_Shiori
{
	[System.Diagnostics.DebuggerStepThrough]
    
	public class SQLProcess
	{
		#region パブリック宣言
		private static SqlConnection con;
		private static SqlCommand cmd;
		private static SqlDataReader dr = null;
		#endregion

		#region インスタンス

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public SQLProcess()///クラス名と同じにすることでコンストラクタになる
		{
			//SQLServer接続確認
			Initialize();
		}

		/// <summary>
		/// デストラクタ
		/// </summary>
		public static void Close()
		{
			if (cmd != null)
			{
				cmd.Dispose();
			}
			if (dr != null)
			{
				dr.Close();
			}
			con.Close();
		}
		#endregion

		#region プライベートメソッド

		/// <summary>
		/// コネクション確立
		/// </summary>
		private static void Initialize()
		{
			XmlSettings.LoadFromXmlFile();

			try
			{
				con = new SqlConnection();
				//接続文字列の設定
				con.ConnectionString =
					"Data Source=" + Properties.Settings.Default.SQL_DataSource + ";" +
					"Initial Catalog=" + Properties.Settings.Default.SQL_DataBase + ";" +
					"Persist Security Info=True;" +
					"User ID=" + Properties.Settings.Default.SQL_UserID + ";" +
                    "Password = " + Properties.Settings.Default.SQL_PassWord + ";" +
					"Connection Timeout=600;";

				/*
				//Windows認証の場合
				con.ConnectionString =
					"Data Source=" + XmlSettings.Instance.DataSource + ";" +
					"Initial Catalog=" + XmlSettings.Instance.InirialCatalog + ";" +
					"Integrated Security=SSPI";
				*/
				con.Open();
			}
			catch (Exception)
			{
				//エラーメッセージを表示
				throw;
			}
		}
		#endregion

		#region パブリックメソッド

		/// <summary>
		/// SELECT文発行用関数(DATATABLE)
		/// </summary>
		/// <param name="strSQL"></param>
		/// <returns></returns>
		public DataTable DB_SELECT_DATATABLE(string strSQL)
		{
            //try
            //{
            //             cmd = new SqlCommand(strSQL, con);
            //             cmd.CommandTimeout = 600;
            //             SqlDataAdapter da = new SqlDataAdapter(cmd);
            //             DataTable dt = new DataTable();

            //             da.Fill(dt);

            //             return dt;

            //         }
            //catch (Exception)
            //{
            //	//エラーメッセージを表示
            //	throw;
            //}
            cmd = new SqlCommand(strSQL, con);
            cmd.CommandTimeout = 600;
            DataTable dt = new DataTable();
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                //da.SelectCommand = cmd;
                da.Fill(dt);
            }

            return dt;
        }

		/// <summary>
		/// SQL文の結果より単一の値を取得
		/// </summary>
		/// <param name="strSQL"></param>
		/// <returns></returns>
		public object DB_EXECUTE_SCALAR(string strSQL)
		{
			try
			{
				cmd = new SqlCommand(strSQL, con);
				cmd.CommandTimeout = 600;

				return cmd.ExecuteScalar();
			}
			catch (Exception)
			{
				//エラーメッセージを表示
				throw;
			}
		}

		/// <summary>
		/// INSERT、DELETE、UPDATE文発行用関数
		/// </summary>
		/// <param name="strSQL"></param>
		public void DB_UPDATE(string strSQL)
		{
			SqlTransaction sqlTran = con.BeginTransaction();    //トランザクション
			cmd = new SqlCommand(strSQL, con);
			cmd.Transaction = sqlTran;
			cmd.CommandTimeout = 600;

			try
			{
				cmd.ExecuteNonQuery();
				sqlTran.Commit();	//コミット
			}
			catch (Exception)
			{
				//エラーメッセージを表示
				throw;
			}
		}
		
		#endregion
	}
}
