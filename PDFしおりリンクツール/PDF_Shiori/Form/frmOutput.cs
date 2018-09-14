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
using System.Collections;
using static PDF_Shiori.DefaultModule;

//ファイルIO関連の名前空間
using System.IO;

//iTextSharp関連の名前空間
using iTextSharp.text;
using iTextSharp.text.pdf;
using iFont = iTextSharp.text.Font;

//LeadTools
using Leadtools;
using Leadtools.Codecs;

namespace PDF_Shiori
{
    public partial class frmOutput : C1.Win.C1Ribbon.C1RibbonForm
    {
        public frmOutput()
        {
            InitializeComponent();
        }

        #region プロパティ
        private string m_JOB_ID;
        /// <summary>
        /// JOB_ID
        /// </summary>
        public string prpJOB_ID
        {
            get { return m_JOB_ID; }
            set { m_JOB_ID = value; }
        }
        #endregion


        /// <summary>
        /// ロード時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmOutput_Load(object sender, EventArgs e)
        {
            //LEADTOOLS 17.5のライセンスキー組み込み
            string strKey = "3liBV81SI91aeV5H7+e0vaPL7hqFf/eLBTniOyLZj4Uv1HlTF71YaoFWKVcPrqDCpWk5zxXR2hMir+2ZFQ1EQSEnwb5gKGNo+FBFdazmsxoEe12eqr1owzFilmLkzEKl3XYa4kw+DdwyGNsZwBoMtxyGU7zmEdqsDv32aaKCGmnlEeoFMgFEW8JVpUfu/qOUJUcLM0cUl8+AbKkk7S1eunK7V/yRxAsG3kQMjswgxuNfXj5Bbh8oERBwK6L3V1pa9gQMXJe25QVcROot3usMKGiTRAGTM9nVy4t4OLAFp/jNPbHS8le41XnxSjwPcSfZJ48xAnZObPuh8FKKw7uizTWPPL+3rEvHS0/LH5JYiLMiJQCY0fBjoOpAng/KK1tVrsyANvomxsKoOKCx1kI7WZGU4enysmSHXJDwK3YhJOu0zK/lT9LrVtlop0Ig166ycOfg1fXhbaKxZVvjh+6F5w==";
            RasterSupport.SetLicense(Properties.Resources.LEAD175ImgSuite, strKey);

            string strSQL = "";
            SQLProcess sqlProcess = new SQLProcess();
            try
            {
                strSQL = "SELECT T1.JOB_ID,T1.作番,T4.名称 AS 顧客名,T3.エンドユーザー1 + T3.エンドユーザー2 AS エンドユーザー,T2.案件名1 + T2.案件名2 AS 案件名,T1.ジョブ名,T1.出力日時,T1.更新日時,T1.削除フラグ," +
         "T1.イメージ親フォルダ,T1.検索拡張子,T1.項目の結合文字,項目列番号1,項目列番号2,項目列番号3,項目列番号4,項目列番号5,ロット列番号";
                strSQL += " FROM T_しおりツール_ジョブリスト AS T1";
                strSQL += " INNER JOIN DailyReport_Test.dbo.T_案件管理 AS T2 ON T1.作番 = T2.作番コード";
                strSQL += " INNER JOIN DailyReport_Test.dbo.M_顧客 AS T3 ON T2.顧客ID = T3.顧客ID";
                strSQL += " INNER JOIN DailyReport_Test.dbo.M_顧客マスタ AS T4 ON T3.コード = T4.コード";
                strSQL += " INNER JOIN T_しおりツール_項目情報 AS T5 ON T1.JOB_ID = T5.JOB_ID";
                strSQL += " WHERE T1.JOB_ID = " + prpJOB_ID;
                DataTable dtUpdateJob = sqlProcess.DB_SELECT_DATATABLE(strSQL);

                this.txtSakuban.Text = dtUpdateJob.Rows[0]["作番"].ToString();
                this.txtAnkenName.Text = dtUpdateJob.Rows[0]["案件名"].ToString();
                this.txtCustomerName.Text = dtUpdateJob.Rows[0]["顧客名"].ToString();
                this.txtEndUser.Text = dtUpdateJob.Rows[0]["エンドユーザー"].ToString();
                this.txtJobName.Text = dtUpdateJob.Rows[0]["ジョブ名"].ToString();
            }
            catch (InvalidCastException ex) when (ex.Data != null)
            {
                MessageBox.Show(ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                SQLProcess.Close();
            }

            cmbMojiCode.DataSource = GetMojiCode();
            cmbPDFOpenSetting.DataSource = GetPDFOpenType();

            cmbMojiCode.SelectedIndex = 0;
            cmbPDFOpenSetting.SelectedIndex = 0;
            rbPDF.Checked = true;
        }

        /// <summary>
        /// 戻るボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// ドラッグ時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        /// <summary>
        /// ドラッグドロップ時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_DragDrop(object sender, DragEventArgs e)
        {
            string[] strFile = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            TextBox txtControl = (TextBox)sender;

            if (System.IO.Directory.Exists(strFile[0]))
            {
                txtControl.Text = strFile[0];
            }
            else
            {
                MessageBox.Show("エラー", "ドロップされたオブジェクトはフォルダではありません", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// フォルダオープン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpenFolder_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            TextBox txt = btn.Name == "btnOpenFolder" ? this.txtOutputFolder : this.txtOutputFolder;
            Microsoft.WindowsAPICodePack.Dialogs.CommonOpenFileDialog cofd = new Microsoft.WindowsAPICodePack.Dialogs.CommonOpenFileDialog();

            cofd.IsFolderPicker = true;

            if (System.IO.Directory.Exists(txt.Text))
            {
                cofd.InitialDirectory = txt.Text;
            }

            if (cofd.ShowDialog() == Microsoft.WindowsAPICodePack.Dialogs.CommonFileDialogResult.Ok)
            {
                txt.Text = cofd.FileName;
            }
        }

        /// <summary>
        /// 出力種別変更時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbPDF_CheckedChanged(object sender, EventArgs e)
        {
            if(rbPDF.Checked == true)
            {
                cmbPDFOpenSetting.Enabled = true;
                cmbMojiCode.Enabled = false;
            }
            else
            {
                cmbPDFOpenSetting.Enabled = false;
                cmbMojiCode.Enabled = true;
            }
        }

        /// <summary>
        /// 出力ボタン押下時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (!System.IO.Directory.Exists(txtOutputFolder.Text))
            {
                MessageBox.Show("指定された出力フォルダが存在しません。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (MessageBox.Show("出力を開始します。\nよろしいですか?","確認",MessageBoxButtons.YesNo,MessageBoxIcon.Information) == DialogResult.No)
            {
                return;
            }
            
            if(rbPDF.Checked == true)
            {
                SQLProcess sqlProcess = new SQLProcess();
                string strSQL = "";
                try
                {
                    //ロット取得
                    strSQL = "SELECT ロット名 FROM T_しおりツール_ジョブリスト";
                    strSQL += " WHERE JOB_ID = " + prpJOB_ID;
                    strSQL += " GROUP BY ロット名";
                    DataTable dtLot = sqlProcess.DB_SELECT_DATATABLE(strSQL);

                    RasterCodecs codecs = new RasterCodecs();

                    for (int i = 0; i<=dtLot.Rows.Count - 1; i++)
                    {
                        string LotName = dtLot.Rows[i]["ロット名"].ToString();

                        fgrResult.Rows.Count += 1;
                        fgrResult.Rows[i + 1]["No."] = i + 1;
                        fgrResult.Rows[i + 1]["ロット名"] = LotName;
                        fgrResult.Rows[i + 1]["進捗"] = "パス取得中";
                        System.Windows.Forms.Application.DoEvents();

                        strSQL = "SELECT イメージ親フォルダ,検索拡張子,項目の結合文字 FROM T_しおりツール_ジョブリスト";
                        strSQL += " WHERE JOB_ID = " + prpJOB_ID;
                        strSQL += " AND ロット名 = '" + LotName + "'";
                        DataTable dtImagePath = sqlProcess.DB_SELECT_DATATABLE(strSQL);

                        string ParentImagePath = dtImagePath.Rows[0]["イメージ親フォルダ"].ToString();
                        string SearchExtension = dtImagePath.Rows[0]["検索拡張子"].ToString();
                        string[] Extensions = SearchExtension.Split('&');
                        string[] Paths = DefaultModule.GetFilesMostDeep(ParentImagePath, Extensions);
                        string OutputPath = txtOutputFolder.Text + "\\" + dtLot.Rows[i]["ロット名"] + ".pdf";

                        fgrResult.Rows[i + 1]["進捗"] = "変換中";
                        System.Windows.Forms.Application.DoEvents();
                        //PDF出力
                        bool MergeSuccess = MergeMultiPDF(OutputPath, Paths);
                        CodecsImageInfo FileInfo = codecs.GetInformation(OutputPath, false);
                        int PageCount = FileInfo.TotalPages;

                        if (Paths.Length != PageCount)
                        {
                            fgrResult.Rows[i + 1]["進捗"] = "ページ数不一致 ページ数:" + PageCount;
                        }

                        fgrResult.Rows[i + 1]["進捗"] = "完了 ページ数:" + PageCount;
                        System.Windows.Forms.Application.DoEvents();
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message,"エラー",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
                finally
                {
                    SQLProcess.Close();
                }

            }
            else
            {
                //テキスト出力
            }
        }

        /// <summary>
        /// マルチPDF作成
        /// </summary>
        /// <param name="sOutPDFPath"></param>
        /// <param name="srcFiles"></param>
        /// <returns></returns>
        public bool MergeMultiPDF(String sOutPDFPath, string[] srcFiles)
        {
            bool bRet = true;

            //iTextオブジェクト
            Document objITextDoc = null;
            PdfCopy objPDFCopy = null;
            PdfContentByte pcb = new PdfContentByte(null);
            objITextDoc = new Document();

            SQLProcess sqlProcess = new SQLProcess();
            string strSQL = "";

            try
            {
                List<Dictionary<string, object>> root = new List<Dictionary<string, object>>();
                string OpenCommand = GetPDFOpenTypeCommand()[cmbPDFOpenSetting.SelectedIndex];

                for (int i = 0; i <= srcFiles.Length - 1; ++i)
                {
                    //ファイル名
                    string FileName = Path.GetFileName(srcFiles[i]);
                    //ロット（フォルダ）名
                    string LotName = Path.GetFileName(Path.GetDirectoryName(srcFiles[i]));
                    //拡張子
                    string Extension = Path.GetExtension(FileName);


                        //画像読み込み
                        if (Extension == ".pdf")
                        {
                            if (i == 0)
                            {
                                objPDFCopy = new PdfCopy(objITextDoc, new FileStream(sOutPDFPath, FileMode.Create, FileAccess.Write));
                                objITextDoc.Open();
                            }
                            else
                            {
                                //画像追加
                                PdfReader objPdfReader = new PdfReader(srcFiles[i]);
                                objPDFCopy.AddDocument(objPdfReader);
                                objPdfReader.Close();
                            }
                        }
                        else
                        {
                            iTextSharp.text.Image PDFReadImage = iTextSharp.text.Image.GetInstance(new Uri(srcFiles[i]));
                            int DPIX = PDFReadImage.DpiX;
                            int DPIY = PDFReadImage.DpiY;
                            Single ImageX = (PDFReadImage.PlainWidth / DPIX) * 25.4F * 2.834F;
                            Single ImageY = (PDFReadImage.PlainHeight / DPIY) * 25.4F * 2.834F;
                            iTextSharp.text.Rectangle Rect = new iTextSharp.text.Rectangle(ImageX, ImageY);

                            if (i == 0)
                            {
                                PdfWriter pw = PdfWriter.GetInstance(objITextDoc, new FileStream(sOutPDFPath, FileMode.Create));
                                //ページサイズ設定
                                objITextDoc.SetPageSize(Rect);
                                objITextDoc.Open();
                                pcb = pw.DirectContent;
                            }
                            else
                            {
                                //画像配置位置
                                PDFReadImage.SetAbsolutePosition(0.0F, 0.0F);
                                //縮尺(72dpi計算のため、スケール補正)
                                long prcScale = (72 / DPIX) * 100;
                                PDFReadImage.ScalePercent(prcScale);
                                //画像追加
                                pcb.AddImage(PDFReadImage);
                            }
                        }

                    strSQL = "SELECT * FROM T_しおりツール_しおりリスト";
                    strSQL += " WHERE JOB_ID = " + prpJOB_ID;
                    strSQL += " AND ロット名 = " + LotName;
                    strSQL += " AND リンクファイル名 = '" + FileName + "'";
                    strSQL += " AND 削除フラグ = 0";
                    DataTable dtIndex = sqlProcess.DB_SELECT_DATATABLE(strSQL);

                    if(dtIndex.Rows.Count == 1)
                    {
                        //しおりがある場合
                        Dictionary<string, object> bookmark;
                        List<Dictionary<string, object>> outlines;

                        outlines = new List<Dictionary<string, object>>();
                        bookmark = new Dictionary<string, object>();
                        bookmark.Add("Title", dtIndex.Rows[0]["しおり"]);
                        bookmark.Add("Page", (i+1) + " " + OpenCommand);//ページ番号と開き方※スペース区切り
                        bookmark.Add("Action", "GoTo");
                        if ((int)dtIndex.Rows[0]["階層"] == 1)
                        {
                            bookmark.Add("Kids", outlines);
                        }
                        root.Add(bookmark);
                    }

                }

                //しおりを追加
                objPDFCopy.Outlines = root;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bRet = false;
            }
            finally
            {
                objITextDoc.Close();
                objPDFCopy.Close();
                SQLProcess.Close();
            }

            return bRet;
        }
    }
}
