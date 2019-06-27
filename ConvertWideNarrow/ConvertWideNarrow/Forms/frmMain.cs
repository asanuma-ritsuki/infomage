using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.FileIO;

namespace ConvertWideNarrow.Forms
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        #region フォームイベント
        private void frmMain_Load(object sender, EventArgs e)
        {
            this.Text = Application.ProductName + " Ver.";
            this.Text += Application.ProductVersion.ToString();

            // すべてのチェックボックスにチェックする
            for (int i = 0; i < chkExt.Items.Count; i++)
            {
                chkExt.SetItemChecked(i, true);
            }

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
        /// テキストボックスドロップイベント
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
        /// 開始ボタン押下時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (this.chkExt.CheckedItems.Count == 0)
            {
                MessageBox.Show("検証する拡張子を1つ以上選択してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (System.IO.Directory.Exists(this.txtSrcFolder.Text) == false)
            {
                MessageBox.Show("対象のフォルダを指定してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show("テキストファイル内の全角・半角変換を行います" + Environment.NewLine + "(０～９→0～9、Ａ～Ｚ→A～Z、（）→()、/→／)" + Environment.NewLine + "よろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                return;
            }
            EnableControl(false);

            try
            {
                DateTime dtDate = DateTime.Now;
                string[] strExts = new string[0];
                int iCount = 0;
                foreach (var strExt in this.chkExt.CheckedItems)
                {
                    // CheckedListbox内のチェックの付いた値のみ配列に代入する
                    iCount += 1;
                    Array.Resize(ref strExts, iCount);
                    strExts[iCount - 1] = (string)strExt;
                }
                var strFiles = DefaultModule.GetFilesMostDeep(this.txtSrcFolder.Text, strExts);

                foreach (var strFile in strFiles)
                {
                    Application.DoEvents();
                    string strOutFile = System.IO.Path.GetDirectoryName(strFile) + "\\" + System.IO.Path.GetFileNameWithoutExtension(strFile) + "_" + dtDate.ToString("yyyyMMdd_HHmmss") + System.IO.Path.GetExtension(strFile);

                    using (var sr = new System.IO.StreamReader(strFile, System.Text.Encoding.GetEncoding("Shift-JIS")))
                    {
                        string strValue = sr.ReadToEnd();
                        using (var sw = new System.IO.StreamWriter(strOutFile, false, System.Text.Encoding.GetEncoding("Shift-JIS")))
                        {
                            sw.Write(ConvertToNarrow(strValue));
                        }
                    }
                }

                MessageBox.Show("テキストファイル内の全角・半角変換が終了しました", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                DefaultModule.OutputLogFile("発生場所：" + System.Reflection.MethodBase.GetCurrentMethod() + Environment.NewLine + ex.Message + Environment.NewLine + ex.StackTrace);
                MessageBox.Show("発生場所：" + System.Reflection.MethodBase.GetCurrentMethod() + Environment.NewLine + ex.Message + Environment.NewLine + ex.StackTrace, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                EnableControl(true);
            }
        }
        #endregion

        #region プライベートメソッド

        /// <summary>
        /// 使用可否を変更する
        /// </summary>
        /// <param name="blnEnable"></param>
        private void EnableControl(bool blnEnable)
        {
            this.txtSrcFolder.Enabled = blnEnable;
            //this.txtLogFolder.Enabled = blnEnable;
            //this.cpTargetColor.Enabled = blnEnable;
            //this.numPixel.Enabled = blnEnable;
            this.chkExt.Enabled = blnEnable;
            //this.cmbDirection.Enabled = blnEnable;
            //this.numPointX.Enabled = blnEnable;
            //this.numPointY.Enabled = blnEnable;
            this.btnStart.Enabled = blnEnable;
            //this.btnAbort.Enabled = !blnEnable;
        }

        /// <summary>
        /// 全角英数を半角に変換する(正規表現を使用)
        /// </summary>
        /// <param name="strValue"></param>
        /// <returns></returns>
        private string ConvertToNarrow(string strValue)
        {
            Regex re = new Regex("[０-９Ａ-Ｚａ-ｚ（）]+");
            string output = re.Replace(strValue, WideToNarrow);
            // 「/」を「／」に変換
            string output2 = output.Replace("/", "／");
			// 2019/06/24
			// 「/」の他に「:*?"<>|」を置換対象とする
			output2 = output2.Replace(":", "：");
			output2 = output2.Replace("*", "＊");
			output2 = output2.Replace("?", "？");
			output2 = output2.Replace("\"", "”");
			output2 = output2.Replace("<", "＜");
			output2 = output2.Replace(">", "＞");
			output2 = output2.Replace("|", "｜");
			return output2;
        }

        /// <summary>
        /// 正規表現でマッチした文字列内の全角を半角に変換する
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        static string WideToNarrow(Match m)
        {
            return Strings.StrConv(m.Value, VbStrConv.Narrow, 0);
        }
        #endregion

    }
}
