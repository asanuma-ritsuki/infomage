using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Leadtools;
using Leadtools.Codecs;
using Leadtools.WinForms;
using Leadtools.Drawing;
using Leadtools.ImageProcessing;

namespace ImageCorruptionCheck.Forms
{
    public partial class frmMain : Form
    {
        #region プライベート変数
        private RasterCodecs codecs;
        private bool blnAbort = false;
        #endregion

        public frmMain()
        {
            InitializeComponent();
        }

        #region  フォームイベント

        /// <summary>
        /// フォームロード時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMain_Load(object sender, EventArgs e)
        {
            this.Text = Application.ProductName + " Ver.";
            this.Text += Application.ProductVersion.ToString();

            Initialization();
        }

        #endregion

        #region オブジェクトイベント

        /// <summary>
        /// 開始ボタン押下時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.chkExt.CheckedItems.Count == 0)
                {
                    MessageBox.Show("検証する拡張子を1つ以上選択してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (System.IO.Directory.Exists(this.txtSrcFolder.Text) == false)
                {
                    MessageBox.Show("対象の画像フォルダを指定してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (System.IO.Directory.Exists(this.txtLogFolder.Text) == false)
                {
                    MessageBox.Show("対象のログフォルダを指定してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (MessageBox.Show("イメージ破損チェックを開始します" + Environment.NewLine + "よろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                {
                    return;
                }
                EnableControl(false);

                this.lstResult.Items.Clear();
                DefaultModule.WriteLstResult(this.lstResult, "画像フォルダ：" + this.txtSrcFolder.Text);
                DefaultModule.WriteLstResult(this.lstResult, "ログフォルダ：" + this.txtLogFolder.Text);
                DefaultModule.WriteLstResult(this.lstResult, "対象色：" + this.cpTargetColor.Value.ToString());
                DefaultModule.WriteLstResult(this.lstResult, "エラーとするピクセル数：" + this.numPixel.Value);
                DefaultModule.WriteLstResult(this.lstResult, "走査方向：" + this.cmbDirection.SelectedItem);
                if (this.cmbDirection.SelectedIndex == 0)
                {
                    // 縦
                    DefaultModule.WriteLstResult(this.lstResult, "起点横：" + this.numPointX.Value);
                }
                else
                {
                    // 縦
                    DefaultModule.WriteLstResult(this.lstResult, "起点縦：" + this.numPointY.Value);
                }
                DefaultModule.WriteLstResult(this.lstResult, "イメージ破損チェック開始：" + this.txtLogFolder.Text);
                string dtDateTime = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                string strLogFile = this.txtLogFolder.Text + "\\" + dtDateTime + ".log";

                string[] strExts = new string[0];
                int iCount = 0;
                foreach (var strExt in this.chkExt.CheckedItems)
                {
                    // CheckedListbox内のチェックの付いた値のみ配列に代入する
                    iCount += 1;
                    Array.Resize(ref strExts, iCount);
                    strExts[iCount - 1] = (string)strExt;
                    DefaultModule.WriteLstResult(this.lstResult, "対象画像形式：" + (string)strExt);
                }

                var strFiles = DefaultModule.GetFilesMostDeep(this.txtSrcFolder.Text, strExts);
                DefaultModule.WriteLstResult(this.lstResult, strFiles.Count() + "ファイル存在確認");
                foreach (var strFile in strFiles)
                {
                    Application.DoEvents();
                    if (blnAbort == true)
                    {
                        if (MessageBox.Show("処理を中止しますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                        {
                            blnAbort = false;
                            DefaultModule.WriteLstResult(this.lstResult, "処理中断");
                            DefaultModule.OutputListLog(this.lstResult, strLogFile, System.Text.Encoding.GetEncoding("Shift-JIS"));

                            return;
                        }
                        else
                        {
                            blnAbort = false;
                        }
                    }
                    if (CheckCorrupt(strFile) == false)
                    {
                        DefaultModule.WriteLstResult(this.lstResult, "破損している可能性あり：" + strFile, DefaultModule.ResultMark.ErrorMark);
                        continue;
                    }
                    else
                    {
                        DefaultModule.WriteLstResult(this.lstResult, "正常：" + strFile);
                    }
                }

                DefaultModule.WriteLstResult(this.lstResult, "イメージ破損チェック終了");
                DefaultModule.OutputListLog(this.lstResult, strLogFile, System.Text.Encoding.GetEncoding("Shift-JIS"));
                MessageBox.Show("イメージ破損チェックが終了しました", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information);
                EnableControl(true);
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
        /// 中止ボタン押下時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAbort_Click(object sender, EventArgs e)
        {
            blnAbort = true;
        }

        #endregion

        #region プライベートメソッド

        /// <summary>
        /// 縦、又は横を走査して指定色が所定のカウント数分連続していたらエラーとする
        /// </summary>
        /// <param name="strFile"></param>
        /// <returns></returns>
        private bool CheckCorrupt(string strFile)
        {
            int iPointX = (int)this.numPointX.Value;
            int iPointY = (int)this.numPointY.Value;

            using (var tempImage = codecs.Load(strFile))
            {
                int iCorruptCount = 0;  // 対象色の連続カウント
                int iLimitCount = (int)this.numPixel.Value; // 連続カウントの限界値
                // ターゲットカラー(System.Drawing.ColorをLeadtools.RasterColorに変換)
                RasterColor targetColor = RasterColorConverter.FromColor(cpTargetColor.Color);
                if (this.cmbDirection.SelectedIndex == 0)
                {
                    // 縦方向に走査
                    int iHeight = tempImage.Height;
                    for (int i = 0; i < iHeight; i++)
                    {
                        //RasterColor sourceColor = tempImage.GetPixel(i, 0);
                        if (RasterColor.Equals(targetColor, tempImage.GetPixel(i, iPointX)) == true)
                        {
                            iCorruptCount += 1;
                        }
                        else
                        {
                            iCorruptCount = 0;
                        }
                        if (iCorruptCount == iLimitCount)
                        {
                            // 限界値に達したらエラーとする
                            return false;
                        }
                    }
                }
                else
                {
                    // 横方向に走査
                    int iWidth = tempImage.Width;
                    for (int i = 0; i < iWidth; i++)
                    {
                        //RasterColor sourceColor = tempImage.GetPixel(0, i);
                        if (RasterColor.Equals(targetColor, tempImage.GetPixel(iPointY, i)) == true)
                        {
                            iCorruptCount += 1;
                        }
                        else
                        {
                            iCorruptCount = 0;
                        }
                        if (iCorruptCount == iLimitCount)
                        {
                            // 限界値に達したらエラーとする
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// 初期化処理
        /// </summary>
        private void Initialization()
        {
            RasterSupport.SetLicense(Application.StartupPath + "\\LEAD175ImgSuite.lic", "+sxwXvpT1JbgbQ7DAdF9k8WRWcBnLgwIjN2a3sVpuzOIoMTYIWPT13qYg3qhCnFE");
            RasterSupport.SetLicense(Application.StartupPath + "\\LEAD175PDFRead.lic", "GL/iTglRN/ENEQvqOhAf1Z9QTPE2TPnSKBIV46X+rLrYLjpOwntMtnq5nDOWh+skhCe196Z5xK/6f/eatnC7zYlWLKBkYEdBuTw3Kd5JE66jNVn08HpvVdJjz9YAT+77V8P70s5whFv4rFKlzZ/zN3CUmyNeEpoav9oOfSTE2s4heejvh/VZ3BMI8dnR4SRdHumqwebWJSeee9zhTWmU1ubSjEjJSG/HHgfAExQHiKUc5SiwTe2MMBCDdagF3yz10sD8WhkQ/PiIAh5cD+GSUmXHdY3VgW/I6LlwY8vXQfqH/a8a9+79ite7Hye71P6Aqmw3fYX4jJgHioqMxatL2A8NJz5rPzgqPBc817V1qZ8AcaM/LIWnGPHGVqBeIgCjydQlvEjknm9i2Jny83+T3ETq2Sg5YBY1P8+3ccQcY+Xae/KdK6/L7EoYFeq3NAf6mHLN3rK5zOT7uBfHTfVNJQ==");
            codecs = new RasterCodecs();

            // すべてのチェックボックスにチェックする
            for (int i = 0; i < chkExt.Items.Count; i++)
            {
                chkExt.SetItemChecked(i, true);
            }
            // デフォルト縦
            this.cmbDirection.SelectedIndex = 0;
            // デフォルトWhite
            this.cpTargetColor.Value = Color.White;
            // デフォルト4ピクセル
            this.numPixel.Value = 4;
            // 中止ボタン使用不可
            this.btnAbort.Enabled = false;
        }

        /// <summary>
        /// 使用可否を変更する
        /// </summary>
        /// <param name="blnEnable"></param>
        private void EnableControl(bool blnEnable)
        {
            this.txtSrcFolder.Enabled = blnEnable;
            this.txtLogFolder.Enabled = blnEnable;
            this.cpTargetColor.Enabled = blnEnable;
            this.numPixel.Enabled = blnEnable;
            this.chkExt.Enabled = blnEnable;
            this.cmbDirection.Enabled = blnEnable;
            this.numPointX.Enabled = blnEnable;
            this.numPointY.Enabled = blnEnable;
            this.btnStart.Enabled = blnEnable;
            this.btnAbort.Enabled = !blnEnable;
        }

        #endregion

    }
}
