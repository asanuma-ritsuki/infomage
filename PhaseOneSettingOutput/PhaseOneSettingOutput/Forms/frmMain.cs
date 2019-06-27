using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace PhaseOneSettingOutput.Forms
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            this.Text = Application.ProductName + " Ver.";
            this.Text += Application.ProductVersion.ToString();
        }

        #region オブジェクトイベント

        /// <summary>
        /// フォルダドラッグイベント
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
        /// フォルダドロップイベント
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
        private void btnOutput_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("処理を開始します" + Environment.NewLine + "よろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            string strOutFile = this.txtOutFolder.Text + "\\Out_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".txt";
            string strHeader1 = "\t\t" + "DL" + "\t\t\t\t\t\t\t\t\t\t\t" + "AL" + "\t\t\t\t\t\t\t\t\t\t";
            string strHeader2 = "フォルダ名\tファイル名\tノイズ除去ディテール\tノイズ除去ルミナンス\tシャープニング量\tシャープニングハロ抑制\tシャープニング半径\tシャープニングしきい値\tホワイトバランス\tノイズ除去ピクセル\tノイズ除去カラー\tカーブ（基本特性内）\tICCプロファイル\tノイズ除去ディテール\tノイズ除去ルミナンス\tシャープニング量\tシャープニングハロ抑制\tシャープニング半径\tシャープニングしきい値\tホワイトバランス\tノイズ除去ピクセル\tノイズ除去カラー\tカーブ（基本特性内）\tICCプロファイル";
            string strHeader3 = "\t\tNoiseDetailsAmount\tNrAmount\tUsmAmount\tUsmHaloControl\tUsmRadius\tUsmThreshold\tWhiteBalance\tCleanLongExposureAmount\tCnrAmount\tFilmCurve\tICCProfile\tNoiseDetailsAmount\tNrAmount\tUsmAmount\tUsmHaloControl\tUsmRadius\tUsmThreshold\tWhiteBalance\tCleanLongExposureAmount\tCnrAmount\tFilmCurve\tICCProfile";
            var strExt = new string[] { "*.cos" };
            string[] strFiles = DefaultModule.GetFilesMostDeep(this.txtTargetFolder.Text, strExt);

            using (var sw = new System.IO.StreamWriter(strOutFile, false, System.Text.Encoding.GetEncoding("Shift-JIS")))
            {
                sw.WriteLine(strHeader1);
                sw.WriteLine(strHeader2);
                sw.WriteLine(strHeader3);
                foreach (var strFile in strFiles)
                {
                    //string strValue = "";
                    string strWriteLine = System.IO.Path.GetDirectoryName(strFile) + "\t" + System.IO.Path.GetFileName(strFile);

                    var xmlDoc = new XmlDocument();
                    xmlDoc.PreserveWhitespace = true;
                    xmlDoc.Load(strFile);

                    // ALは項目がない可能性があるので存在しなかった場合はタブだけ活かす
                    int iCount = 0;
                    // DL範囲の値の取得
                    var NoiseDetailsAmount = xmlDoc.SelectNodes("IMG/VAR/DL/E[@K='NoiseDetailsAmount']");
                    iCount = 0;
                    foreach (XmlNode node in NoiseDetailsAmount)
                    {
                        var str = node.Attributes.GetNamedItem("V");
                        strWriteLine += "\t" + str.Value;
                        iCount += 1;
                    }
                    if (iCount == 0) { strWriteLine += "\t"; }
                    var NrAmount = xmlDoc.SelectNodes("IMG/VAR/DL/E[@K='NrAmount']");
                    iCount = 0;
                    foreach (XmlNode node in NrAmount)
                    {
                        var str = node.Attributes.GetNamedItem("V");
                        strWriteLine += "\t" + str.Value;
                        iCount += 1;
                    }
                    if (iCount == 0) { strWriteLine += "\t"; }
                    var UsmAmount = xmlDoc.SelectNodes("IMG/VAR/DL/E[@K='UsmAmount']");
                    iCount = 0;
                    foreach (XmlNode node in UsmAmount)
                    {
                        var str = node.Attributes.GetNamedItem("V");
                        strWriteLine += "\t" + str.Value;
                        iCount += 1;
                    }
                    if (iCount == 0) { strWriteLine += "\t"; }
                    var UsmHaloControl = xmlDoc.SelectNodes("IMG/VAR/DL/E[@K='UsmHaloControl']");
                    iCount = 0;
                    foreach (XmlNode node in UsmHaloControl)
                    {
                        var str = node.Attributes.GetNamedItem("V");
                        strWriteLine += "\t" + str.Value;
                        iCount += 1;
                    }
                    if (iCount == 0) { strWriteLine += "\t"; }
                    var UsmRadius = xmlDoc.SelectNodes("IMG/VAR/DL/E[@K='UsmRadius']");
                    iCount = 0;
                    foreach (XmlNode node in UsmRadius)
                    {
                        var str = node.Attributes.GetNamedItem("V");
                        strWriteLine += "\t" + str.Value;
                        iCount += 1;
                    }
                    if (iCount == 0) { strWriteLine += "\t"; }
                    var UsmThreshold = xmlDoc.SelectNodes("IMG/VAR/DL/E[@K='UsmThreshold']");
                    iCount = 0;
                    foreach (XmlNode node in UsmThreshold)
                    {
                        var str = node.Attributes.GetNamedItem("V");
                        strWriteLine += "\t" + str.Value;
                        iCount += 1;
                    }
                    if (iCount == 0) { strWriteLine += "\t"; }
                    var WhiteBalance = xmlDoc.SelectNodes("IMG/VAR/DL/E[@K='WhiteBalance']");
                    iCount = 0;
                    foreach (XmlNode node in WhiteBalance)
                    {
                        var str = node.Attributes.GetNamedItem("V");
                        strWriteLine += "\t" + str.Value;
                        iCount += 1;
                    }
                    if (iCount == 0) { strWriteLine += "\t"; }
                    var CleanLongExposureAmount = xmlDoc.SelectNodes("IMG/VAR/DL/E[@K='CleanLongExposureAmount']");
                    iCount = 0;
                    foreach (XmlNode node in CleanLongExposureAmount)
                    {
                        var str = node.Attributes.GetNamedItem("V");
                        strWriteLine += "\t" + str.Value;
                        iCount += 1;
                    }
                    if (iCount == 0) { strWriteLine += "\t"; }
                    var CnrAmount = xmlDoc.SelectNodes("IMG/VAR/DL/E[@K='CnrAmount']");
                    iCount = 0;
                    foreach (XmlNode node in CnrAmount)
                    {
                        var str = node.Attributes.GetNamedItem("V");
                        strWriteLine += "\t" + str.Value;
                        iCount += 1;
                    }
                    if (iCount == 0) { strWriteLine += "\t"; }
                    var FilmCurve = xmlDoc.SelectNodes("IMG/VAR/DL/E[@K='FilmCurve']");
                    iCount = 0;
                    foreach (XmlNode node in FilmCurve)
                    {
                        var str = node.Attributes.GetNamedItem("V");
                        strWriteLine += "\t" + str.Value;
                        iCount += 1;
                    }
                    if (iCount == 0) { strWriteLine += "\t"; }
                    var ICCProfile = xmlDoc.SelectNodes("IMG/VAR/DL/E[@K='ICCProfile']");
                    iCount = 0;
                    foreach (XmlNode node in ICCProfile)
                    {
                        var str = node.Attributes.GetNamedItem("V");
                        strWriteLine += "\t" + str.Value;
                        iCount += 1;
                    }
                    if (iCount == 0) { strWriteLine += "\t"; }
                    // AL
                    var ALNoiseDetailsAmount = xmlDoc.SelectNodes("IMG/VAR/AL/E[@K='NoiseDetailsAmount']");
                    iCount = 0;
                    foreach (XmlNode node in ALNoiseDetailsAmount)
                    {
                        var str = node.Attributes.GetNamedItem("V");
                        strWriteLine += "\t" + str.Value;
                        iCount += 1;
                    }
                    if (iCount == 0) { strWriteLine += "\t"; }
                    var ALNrAmount = xmlDoc.SelectNodes("IMG/VAR/AL/E[@K='NrAmount']");
                    iCount = 0;
                    foreach (XmlNode node in ALNrAmount)
                    {
                        var str = node.Attributes.GetNamedItem("V");
                        strWriteLine += "\t" + str.Value;
                        iCount += 1;
                    }
                    if (iCount == 0) { strWriteLine += "\t"; }
                    var ALUsmAmount = xmlDoc.SelectNodes("IMG/VAR/AL/E[@K='UsmAmount']");
                    iCount = 0;
                    foreach (XmlNode node in ALUsmAmount)
                    {
                        var str = node.Attributes.GetNamedItem("V");
                        strWriteLine += "\t" + str.Value;
                        iCount += 1;
                    }
                    if (iCount == 0) { strWriteLine += "\t"; }
                    var ALUsmHaloControl = xmlDoc.SelectNodes("IMG/VAR/AL/E[@K='UsmHaloControl']");
                    iCount = 0;
                    foreach (XmlNode node in ALUsmHaloControl)
                    {
                        var str = node.Attributes.GetNamedItem("V");
                        strWriteLine += "\t" + str.Value;
                        iCount += 1;
                    }
                    if (iCount == 0) { strWriteLine += "\t"; }
                    var ALUsmRadius = xmlDoc.SelectNodes("IMG/VAR/AL/E[@K='UsmRadius']");
                    iCount = 0;
                    foreach (XmlNode node in ALUsmRadius)
                    {
                        var str = node.Attributes.GetNamedItem("V");
                        strWriteLine += "\t" + str.Value;
                        iCount += 1;
                    }
                    if (iCount == 0) { strWriteLine += "\t"; }
                    var ALUsmThreshold = xmlDoc.SelectNodes("IMG/VAR/AL/E[@K='UsmThreshold']");
                    iCount = 0;
                    foreach (XmlNode node in ALUsmThreshold)
                    {
                        var str = node.Attributes.GetNamedItem("V");
                        strWriteLine += "\t" + str.Value;
                        iCount += 1;
                    }
                    if (iCount == 0) { strWriteLine += "\t"; }
                    var ALWhiteBalance = xmlDoc.SelectNodes("IMG/VAR/AL/E[@K='WhiteBalance']");
                    iCount = 0;
                    foreach (XmlNode node in ALWhiteBalance)
                    {
                        var str = node.Attributes.GetNamedItem("V");
                        strWriteLine += "\t" + str.Value;
                        iCount += 1;
                    }
                    if (iCount == 0) { strWriteLine += "\t"; }
                    var ALCleanLongExposureAmount = xmlDoc.SelectNodes("IMG/VAR/AL/E[@K='CleanLongExposureAmount']");
                    iCount = 0;
                    foreach (XmlNode node in ALCleanLongExposureAmount)
                    {
                        var str = node.Attributes.GetNamedItem("V");
                        strWriteLine += "\t" + str.Value;
                        iCount += 1;
                    }
                    if (iCount == 0) { strWriteLine += "\t"; }
                    var ALCnrAmount = xmlDoc.SelectNodes("IMG/VAR/AL/E[@K='CnrAmount']");
                    iCount = 0;
                    foreach (XmlNode node in ALCnrAmount)
                    {
                        var str = node.Attributes.GetNamedItem("V");
                        strWriteLine += "\t" + str.Value;
                        iCount += 1;
                    }
                    if (iCount == 0) { strWriteLine += "\t"; }
                    var ALFilmCurve = xmlDoc.SelectNodes("IMG/VAR/AL/E[@K='FilmCurve']");
                    iCount = 0;
                    foreach (XmlNode node in ALFilmCurve)
                    {
                        var str = node.Attributes.GetNamedItem("V");
                        strWriteLine += "\t" + str.Value;
                        iCount += 1;
                    }
                    if (iCount == 0) { strWriteLine += "\t"; }
                    var ALICCProfile = xmlDoc.SelectNodes("IMG/VAR/AL/E[@K='ICCProfile']");
                    iCount = 0;
                    foreach (XmlNode node in ALICCProfile)
                    {
                        var str = node.Attributes.GetNamedItem("V");
                        strWriteLine += "\t" + str.Value;
                        iCount += 1;
                    }
                    if (iCount == 0) { strWriteLine += "\t"; }

                    sw.WriteLine(strWriteLine);
                }
            }
            MessageBox.Show("処理が終了しました", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    var xmlDoc = new XmlDocument();
        //    xmlDoc.PreserveWhitespace = true;
        //    xmlDoc.Load(@"C:\開発\20190411_スチール_pahseone設定出力\sample_raw\_20190218_o_01_SG\CaptureOne\Settings100\_20190218_o_01_SG_0001.IIQ.cos");
        //    var employees = xmlDoc.SelectNodes("IMG/VAR/DL/E[@K='NoiseDetailsAmount']");

        //    foreach (XmlNode emp in employees)
        //    {
        //        //var fname = emp.SelectSingleNode("V").InnerText;
        //        var str = emp.Attributes.GetNamedItem("V");
        //        //var lname = emp.SelectSingleNode("name/last").InnerText;
        //        //var age = emp.Attributes["age"].InnerText;
        //        //Console.WriteLine($"{fname} {lname} ({age})");
        //        Console.WriteLine($"{str.Value}");
        //    }
        //}

    }
}
