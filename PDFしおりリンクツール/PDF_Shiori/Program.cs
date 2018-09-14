using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PDF_Shiori
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new frmMenu());

            (new frmMenu()).Show();

            // フォームが全て閉じられるまでプログラム実行を継続
            var oTimer = new System.Windows.Forms.Timer();
            oTimer.Interval = 1000;
            oTimer.Tick += delegate (object sender, EventArgs e)
            {
                if (Application.OpenForms.Count == 0)
                {
                    Application.Exit();
                }
            };
            oTimer.Start();
            Application.Run();
        }
    }
}
