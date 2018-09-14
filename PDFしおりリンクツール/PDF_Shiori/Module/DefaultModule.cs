using System;
using System.IO;
using System.Data;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using static System.Console;

namespace PDF_Shiori
{
    public static class DefaultModule
    {
        /// <summary>
        /// リストボックス用マーク列挙体
        /// </summary>
        public enum ResultMark
        {
            InformationMark,
            DoingMark,
            WarningMark,
            ErrorMark
        }

        /// <summary>
        /// リストボックスに結果マーク込みで文字列を書き込む
        /// </summary>
        /// <param name="lstResult"></param>
        /// <param name="strLog"></param>
        /// <param name="resultmark"></param>
        public static void WriteLstResult(ListBox lstResult, string strLog, ResultMark resultmark = ResultMark.InformationMark)
        {
            try

            {
                string strMark = "";

                switch (resultmark)
                {
                    case ResultMark.InformationMark:
                        strMark = "○";
                        break;
                    case ResultMark.DoingMark:
                        strMark = "→";
                        break;
                    case ResultMark.WarningMark:
                        strMark = "△";
                        break;
                    case ResultMark.ErrorMark:
                        strMark = "×";
                        break;
                    default:
                        break;
                }
                //時間と文字列をリストボックスに表示
                lstResult.Items.Add(strMark + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "\t" + strLog);
                //リストボックスの最終行を選択
                lstResult.SetSelected(lstResult.Items.Count - 1, true);
                Application.DoEvents();
            }
            catch (Exception)
            {
                //エラーメッセージを表示
                throw;
            }
        }

        /// <summary>
        /// NULL判定
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool IsNull(string text)
        {
            //null判定
            if (text == null)
            {
                return true;
            }
            //空文字判定
            else if (text.Trim() == "")
            {
                return true;
            }
            //何も引っかからなかったら
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 例外処理内容をログファイルに書き込む
        /// </summary>
        /// <param name="strExceptionMessage"></param>
        public static void OutputLogFile(string strExceptionMessage)
        {
            string strLogFile = Application.StartupPath + "\\ExceptionLog\\Exception.log";
            string strLogFolder = System.IO.Path.GetDirectoryName(strLogFile);
            Encoding enc = Encoding.GetEncoding("Shift-JIS");

            if (Directory.Exists(strLogFolder) == false)
            {
                Directory.CreateDirectory(strLogFolder);
            }

            using (StreamWriter sw = new StreamWriter(strLogFile, true, enc))
            {
                sw.WriteLine("[ " + DateTime.Now + " ]");
                sw.WriteLine(strExceptionMessage);
            }
        }

        /// <summary>
        /// ファイルのレコード数をカウントする
        /// </summary>
        /// <param name="strFileName"></param>
        /// <returns></returns>
        public static int GetLinesOfTextFile(string strFileName)
        {
            int iLineCount = 0;
            using (StreamReader sr = new StreamReader(strFileName))
            {
                while (sr.Peek() >= 0)
                {
                    sr.ReadLine();
                    iLineCount += 1;
                }
            }

            return iLineCount;
        }

        /// <summary>
        /// Shift-JISで表現できるか判断する
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool IsShiftJISOnlyText(string text)
        {
            EncoderExceptionFallback encoderFallback = new EncoderExceptionFallback();
            DecoderExceptionFallback decoderFallback = new DecoderExceptionFallback();
            Encoding sjis = Encoding.GetEncoding("Shift-JIS", encoderFallback, decoderFallback);

            try
            {
                byte[] bytes = sjis.GetBytes(text);
            }
            catch (EncoderFallbackException fbex)
            {
                //Shift-JISで表現できなかった場合、ここに飛ぶ
                return false;
            }
            catch (Exception ex)
            {
                OutputLogFile("発生場所：" + System.Reflection.MethodBase.GetCurrentMethod() + Environment.NewLine + ex.Message + Environment.NewLine + ex.StackTrace);
                MessageBox.Show("発生場所：" + System.Reflection.MethodBase.GetCurrentMethod() + Environment.NewLine + ex.Message + Environment.NewLine + ex.StackTrace, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        /// <summary>
        /// ファイルを開くダイアログボックス
        /// </summary>
        /// <param name="txtFile"></param>
        /// <param name="strFilter">フィルタの記述例：JPEGイメージ(*.jpg)|*.jpg|すべてのファイル(*.*)|*.*</param>
        /// <returns></returns>
        public static string FileBrowse(TextBox txtFile, string strFilter)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            //初めに「ファイル名」で表示される文字列を指定する
            if (IsNull(txtFile.Text) == true)
            {
                ofd.FileName = "";
            }
            else
            {
                ofd.FileName = Path.GetFileName(txtFile.Text);
            }
            //初めに表示されるフォルダを指定する
            if (IsNull(txtFile.Text) == true)
            {
                ofd.FileName = "";
            }
            else
            {
                ofd.InitialDirectory = Path.GetDirectoryName(txtFile.Text);
            }

            //[ファイルの種類]に表示される選択肢を指定する
            //指定しないとすべてのファイルが表示される
            ofd.Filter = strFilter;
            ofd.FilterIndex = 1;
            //タイトルを設定する
            ofd.Title = "ファイルを選択して下さい";
            //ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする
            ofd.RestoreDirectory = true;
            //存在しないファイルの名前が指定されたとき警告を表示する
            //デフォルトでtrue
            ofd.CheckFileExists = true;
            //存在しないパスが指定されたとき警告を表示する
            //デフォルトでtrue
            ofd.CheckPathExists = true;

            //ダイアログを表示する
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                //OKボタンがクリックされたとき
                return ofd.FileName;
            }
            else
            {
                return txtFile.Text;
            }
        }

        /// <summary>
        /// フォルダ選択ダイアログ
        /// WindowsAPICodePackを使用
        /// </summary>
        /// <param name="txtFolder"></param>
        /// <returns></returns>
        public static string FolderBrowse(TextBox txtFolder)
        {
            var ofd = new Microsoft.WindowsAPICodePack.Dialogs.CommonOpenFileDialog("フォルダ選択");
            //フォルダ選択モードにする
            ofd.IsFolderPicker = true;
            //初期フォルダ
            ofd.InitialDirectory = txtFolder.Text;

            if (ofd.ShowDialog() == Microsoft.WindowsAPICodePack.Dialogs.CommonFileDialogResult.Ok)
            {
                return ofd.FileName;
            }
            else
            {
                if (IsNull(txtFolder.Text) == true)
                {
                    return "";
                }
                else
                {
                    return txtFolder.Text;
                }
            }
        }

        /// <summary>
        /// 指定した検索パターンに一致するファイルを最下層まで検索し全てを返す
        /// </summary>
        /// <param name="strRootPath"></param>
        /// <param name="strPatterns"></param>
        /// <returns></returns>
        public static string[] GetFilesMostDeep(string strRootPath, string[] strPatterns)
        {
            var hStringCollection = new System.Collections.Specialized.StringCollection();
            //このディレクトリ内のすべてのファイルを検索する
            foreach (string strFilePath in System.IO.Directory.GetFiles(strRootPath, "*"))
            {
                foreach (string strPattern in strPatterns)
                {
                    if ("*" + Path.GetExtension(strFilePath) == strPattern)
                    {
                        hStringCollection.Add(strFilePath);
                    }
                }
            }

            //このディレクトリ内のすべてのサブディレクトリを検索する(再帰)
            foreach (string strDirPath in Directory.GetDirectories(strRootPath))
            {
                string[] strFilePathes = GetFilesMostDeep(strDirPath, strPatterns);
                //条件に合致したファイルが有った場合は、ArrayListに加える
                if (strFilePathes != null)
                {
                    hStringCollection.AddRange(strFilePathes);
                }
            }
            //StringCollectionを1次元のString配列に変換して返す
            string[] strReturns = new string[hStringCollection.Count];
            hStringCollection.CopyTo(strReturns, 0);

            return strReturns;
        }

        /// <summary>
        /// リストボックスに表示されている文字列をログファイルとして保存する
        /// </summary>
        /// <param name="lstResult"></param>
        /// <param name="strOutputFolder"></param>
        /// <param name="strSign"></param>
        /// <param name="strSign2"></param>
        public static void OutputListLog(ListBox lstResult, string strOutputFolder, string strSign, string strSign2 = "")
        {
            string strDate = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            string strOutputLog = strOutputFolder + "\\" + strDate + strSign + strSign2 + ".log";

            using (StreamWriter sw = new StreamWriter(strOutputLog, false, Encoding.GetEncoding("Shift-JIS")))
            {
                //テキストの書込み
                for (int j = 0; j <= lstResult.Items.Count - 1; j++)
                {
                    sw.WriteLine(lstResult.Items[j]);
                }
            }

            WriteLstResult(lstResult, "ログ保存：" + strOutputLog);
        }

        /// <summary>
        /// コンボボックスにDATATABLEの値をセットする
        /// </summary>
        /// <param name="cmb">対象コンボボックス</param>
        /// <param name="dt">DATATABLE(カラム0：ID、カラム1：NAME</param>
        /// <param name="IsAll">全て項目を追加するか</param>
        public static void SetComboValue(ComboBox cmb, DataTable dt, bool IsAll = true)
        {
            List<CElement> elm = null;
            //CElement[] elm = null;
            if (IsAll == true)
            {
                elm.Add(new CElement());
                elm[0].ID = "0";
                elm[1].NAME = "全て";

                for (int iRow = 0; iRow <= dt.Rows.Count - 1; iRow++)
                {
                    elm.Add(new CElement());
                    elm[iRow + 1].ID = dt.Rows[iRow][0].ToString();
                    elm[iRow + 1].NAME = dt.Rows[iRow][1].ToString();
                }
            }
            else
            {
                //「全て」なし
                for (int iRow = 0; iRow <= dt.Rows.Count - 1; iRow++)
                {
                    elm.Add(new CElement());
                    elm[iRow].ID = dt.Rows[iRow][0].ToString();
                    elm[iRow].NAME = dt.Rows[iRow][1].ToString();
                }
            }

            cmb.DisplayMember = "NAME";
            cmb.ValueMember = "ID";
            cmb.DataSource = elm;

            cmb.SelectedIndex = -1;
        }

        public static void EnableControls(System.Windows.Forms.Form frmForm, bool ControlEnabled)
        {

        }

        /// <summary>
        /// 排他的論理和暗号化
        /// </summary>
        /// <param name="Text"></param>
        /// <param name="Key"></param>
        /// <returns></returns>
        public static string GetEncryptionString(string Text, string Key)
        {
            byte[] bytText = Encoding.ASCII.GetBytes(Text);
            byte[] bytKey = Encoding.ASCII.GetBytes(Key);
            int j = 0;
            for (int i = 0; i < bytText.Length; i++)
            {
                if (j < bytKey.Length)
                {
                    j++;
                }
                else
                {
                    j = 1;
                }
                bytText[i] = (byte)(bytText[i] ^ bytKey[j - 1]); //排他的論理和（ＸＯＲ）を使って暗号化
                if (bytText[i] < 33)
                {
                    bytText[i] += 33;
                }
                if (bytText[i] > 126)
                {
                    bytText[i] -= 126;
                }
            }
            return Encoding.ASCII.GetString(bytText);
        }

        /// <summary>
        /// デリミタ種類
        /// </summary>
        /// <returns></returns>
        public static char[] GetDelimita()
        {
            return new char[] { ',', '\t', '\0', '_', '-', ' ' };
        }
        /// <summary>
        /// 文字コード種類
        /// </summary>
        /// <returns></returns>
        public static string[] GetMojiCode()
        {
            return new string[] { "UTF-8", "Shift-JIS" };
        }

        /// <summary>
        /// PDF開き方設定
        /// </summary>
        /// <returns></returns>
        public static string[] GetPDFOpenType()
        {
            return new string[] { "全体表示", "100%表示", "幅に合わせる", "描画領域の幅に合わせる", "ズーム設定維持" };
        }

        /// <summary>
        /// PDF開き方設定Command
        /// </summary>
        /// <returns></returns>
        public static string[] GetPDFOpenTypeCommand()
        {
            return new string[] { "Fit", "100%", "FitH", "FitBH", "XYZ" };
        }

        /// <summary>
        /// 値を取得、keyがなければデフォルト値を設定し、デフォルト値を取得
        /// </summary>
        public static TV GetOrDefault<TK, TV>(this Dictionary<TK, TV> dic, TK key, TV defaultValue = default(TV))
        {
            TV result;
            return dic.TryGetValue(key, out result) ? result : defaultValue;
        }
    }
}
