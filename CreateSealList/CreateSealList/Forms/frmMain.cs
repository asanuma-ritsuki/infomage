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

namespace CreateSealList.Forms
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        #region フォームイベント

        /// <summary>
        /// フォームロード
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMain_Load(object sender, EventArgs e)
        {
            this.Text = Application.ProductName + " Ver.";
            this.Text += Application.ProductVersion.ToString();

            Initialization();
        }

        /// <summary>
        /// フォームクローズ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            XmlSettings.LoadFromXmlFile();
            XmlSettings.Instance.TextFile = this.txtCSV.Text;
            XmlSettings.Instance.OutFolder = this.txtOutFolder.Text;
            XmlSettings.SaveToXmlFile();
        }

        #endregion

        #region オブジェクトイベント

        /// <summary>
        /// テキストボックスドラッグイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtFolder_DragEnter(object sender, DragEventArgs e)
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

        /// <summary>
        /// 開始ボタン押下時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRun_Click(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(this.txtCSV.Text) == false)
            {
                MessageBox.Show("リストファイルを指定してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (System.IO.Directory.Exists(this.txtOutFolder.Text) == false)
            {
                MessageBox.Show("存在する出力フォルダを指定してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show("シールリストを作成します" + Environment.NewLine + "よろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            //出力ファイル名の命名
            string strDt = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            string strOutFile = this.txtOutFolder.Text + "\\シール用_" + strDt + ".txt";
            var enc = System.Text.Encoding.GetEncoding("Shift-JIS");
            int iCount = 0;

            using (var sw = new System.IO.StreamWriter(strOutFile, false, enc))
            {

                using (var parser = new TextFieldParser(this.txtCSV.Text, enc))
                {
                    parser.Delimiters = new string[] { "\t" };

                    while (!parser.EndOfData)
                    {
                        var rows = parser.ReadFields();
                        //各要素を読み込む
                        var iSeq1 = int.Parse(rows[0]);
                        var iSeq2 = int.Parse(rows[3]);
                        var iTotal = int.Parse(rows[4]);
                        var iReturn = int.Parse(rows[5]);
                        //要素4の指定回数分繰り返す
                        for (int i = 0; i < iTotal; i++)
                        {
                            iCount += 1;
                            string strWriteLine = iSeq1 + "_" + iSeq2 + "," + iCount.ToString("0000") + ",";
                            if (iReturn != 0)
                            {
                                strWriteLine += "返却";
                                iReturn -= 1;
                            }
                            sw.WriteLine(strWriteLine);
                        }
                    }
                }
            }
            MessageBox.Show("シールリストの作成が完了しました", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion

        #region プライベートメソッド

        /// <summary>
        /// 初期化処理
        /// </summary>
        private void Initialization()
        {
            XmlSettings.LoadFromXmlFile();
            this.txtCSV.Text = XmlSettings.Instance.TextFile;
            this.txtOutFolder.Text = XmlSettings.Instance.OutFolder;
        }
        #endregion
    }
}
