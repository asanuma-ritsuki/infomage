using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Leadtools;
using Leadtools.Codecs;
using Leadtools.WinForms;
using Leadtools.Drawing;
using Leadtools.ImageProcessing;

namespace PDF_Shiori
{
    public partial class frmMain : C1.Win.C1Ribbon.C1RibbonForm
    {
		#region プライベート変数

		private int _initialAngle = 0;
		private RotateCommandFlags _initialFlags  = RotateCommandFlags.None;
		private RasterColor _initialFillColor  = new RasterColor(0, 0, 0);
		private RasterCodecs codecs = new RasterCodecs();
		private ImageProperty ip = new ImageProperty();
		private bool key_flag = false;
		private int LinkCount = 0;

		#endregion

		#region プロパティ

		private int m_Job_ID;
		private string ParentImagePath;
		private string SearchExtension;

		/// <summary>
		/// 作番
		/// </summary>
		public int prpJob_ID
		{
			get { return m_Job_ID; }
			set { m_Job_ID = value; }
		}

		//Rasterイメージプロパティ構造体
		struct ImageProperty
		{

			private Single _sngZoom; //拡大率
			private int _idegrees; //角度
			private int _Angle;     //角度×100
			private RotateCommandFlags _Flags;  //Rotateコマンド内容
			private RasterColor _FillColor; //余白塗りつぶし色
			private int _CurrentPage; //現在のページ
			private int _TotalPages;   //総ページ数

			public Single sngZoom
			{
				get { return _sngZoom; }
				set { _sngZoom = value; }
			}
			public int Degrees
			{
				get { return _idegrees; }
				set { _idegrees = value; }
			}
			public int Angle
			{
				get { return _Angle; }
				set { _Angle = value; }
			}
			public RotateCommandFlags Flags
			{
				get { return _Flags; }
				set { _Flags = value; }
			}
			public RasterColor FillColor
			{
				get { return _FillColor; }
				set { _FillColor = value; }
			}
			public int CurrentPage
			{
				get { return _CurrentPage; }
				set { _CurrentPage = value; }
			}
			public int TotalPages
			{
				get { return _TotalPages; }
				set { _TotalPages = value; }
			}
		}

		#endregion

		#region フォームイベント

		public frmMain()
		{
			InitializeComponent();
		}

		/// <summary>
		/// ロード時
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void frmMain_Load(object sender, EventArgs e)
		{
			Initialize();

			//ジョブのロット一覧を取得
			string strSQL = "";
			SQLProcess sqlProcess = new SQLProcess();
			try
			{
				strSQL = "SELECT DISTINCT(ロット名) FROM T_しおりツール_しおりリスト";
				strSQL += " WHERE JOB_ID = " + m_Job_ID;
				strSQL += " ORDER BY ロット名";
				DataTable dtLot = sqlProcess.DB_SELECT_DATATABLE(strSQL);
				cmbLot.ColumnHeaders = false;
				cmbLot.DataSource = dtLot;
				cmbLot.SelectedIndex = 0;

				strSQL = "SELECT イメージ親フォルダ,検索拡張子,項目の結合文字 FROM T_しおりツール_ジョブリスト";
				strSQL += " WHERE JOB_ID = " + m_Job_ID;
				DataTable dtImagePath = sqlProcess.DB_SELECT_DATATABLE(strSQL);
				ParentImagePath = dtImagePath.Rows[0]["イメージ親フォルダ"].ToString();
				SearchExtension = dtImagePath.Rows[0]["検索拡張子"].ToString();

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
		/// ショートカットキー
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void frmMain_KeyDown(object sender, KeyEventArgs e)
		{
			ShortcutProcess(e.KeyCode);
		}

		/// <summary>
		/// コントロール上で特殊キーが押下された場合の処理
		/// 方向キーの特殊動作をキャンセルして通常のKeyDownイベントを発生させる
		/// </summary>
		/// <param name="keyData"></param>
		/// <returns></returns>
		protected override bool ProcessDialogKey(Keys keyData)
		{
			switch (keyData)
			{
				case Keys.Down:
				case Keys.Right:
				case Keys.Up:
				case Keys.Left:
					break;
				default:
					return base.ProcessDialogKey(keyData);
			}
			return false;
		}

		#endregion

		#region オブジェクトイベント	

		private void btnBackMenu_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
		{
			if(btnLoad.Enabled == false)
			{
				MessageBox.Show("閉じる場合はロットを終了させてください。","警告",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
				e.Cancel = true;
				return;
			}
			frmMenu frm = new frmMenu();
			frm.Show();
		}

		/// <summary>
		/// 開始ボタン
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnLoad_Click(object sender, EventArgs e)
		{
            
			//選択したロットのフォルダを読込
			string LotDir = ParentImagePath + "\\" + this.cmbLot.Text;
			if (System.IO.Directory.Exists(LotDir))
			{
				string[] Extensions = SearchExtension.Split('&');
				string[] Paths = DefaultModule.GetFilesMostDeep(LotDir,Extensions);

				if(Paths.Length == 0)
				{
					MessageBox.Show("指定された拡張子のファイルが存在しませんでした。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}

				for (int i = 0; i <= Paths.Length - 1; i++)
				{
					this.fgrFilelist.Rows.Count++;
					this.fgrFilelist.Rows[i+1]["No."] = i+1;
					this.fgrFilelist.Rows[i+1]["ファイル名"] = System.IO.Path.GetFileName(Paths[i]);
				}
			}
			else
			{
				MessageBox.Show("対象のロット名のフォルダが見つかりませんでした。\n" + "対象フォルダ：" + LotDir,"エラー",MessageBoxButtons.OK,MessageBoxIcon.Error);
				return;
			}

			EnableChange(true);
			//確定、中止ボタンは使用不可とする
			btnConfirm.Enabled = false;
			btnAbort.Enabled = false;

			string strSQL = "";
			SQLProcess sqlProcess = new SQLProcess();
			try
			{
				//イベントリムーブ
				fgrIndexlist.RowColChange -= new EventHandler(fgrIndexlist_RowColChange);
				fgrIndexlist.CellChanged -= new C1.Win.C1FlexGrid.RowColEventHandler(fgrIndexlist_CellChanged);

				strSQL = "SELECT * FROM T_しおりツール_しおりリスト";
				strSQL += " WHERE JOB_ID = " + m_Job_ID;
				strSQL += " AND ロット名 = '" + this.cmbLot.Text + "'";

				DataTable dtIndex = sqlProcess.DB_SELECT_DATATABLE(strSQL);


				//// 固定列
				//fgrIndexlist.Cols.Fixed = 2;
				//// ツリー列
				//fgrIndexlist.Tree.Column = 2;
				//// ツリースタイルを設定
				//fgrIndexlist.Tree.Style = C1.Win.C1FlexGrid.TreeStyleFlags.SimpleLeaf;

				for (int i = 0; i <= dtIndex.Rows.Count - 1; i++)
				{
					this.fgrIndexlist.Rows.Count++;
					this.fgrIndexlist.Rows[i + 1]["No."] = i + 1;
					this.fgrIndexlist.Rows[i + 1]["Shiori_ID"] = dtIndex.Rows[i]["Shiori_ID"];
					this.fgrIndexlist.Rows[i + 1]["階層"] = dtIndex.Rows[i]["階層"];
					this.fgrIndexlist.Rows[i + 1]["しおり"] = dtIndex.Rows[i]["しおり"];
					this.fgrIndexlist.Rows[i + 1]["リンクファイル名"] = dtIndex.Rows[i]["リンクファイル名"];
					this.fgrIndexlist.Rows[i + 1]["削除"] = dtIndex.Rows[i]["削除フラグ"];
					this.fgrIndexlist.Rows[i + 1]["備考"] = dtIndex.Rows[i]["備考"];

					//if ((int)dtIndex.Rows[i]["階層"] == 1)
					//{
					//    // ノード行に設定
					//    fgrIndexlist.Rows[i + 1].IsNode = true;
					//    // 階層レベルを設定
					//    fgrIndexlist.Rows[i + 1].Node.Level = 0;
					//}
					//else
					//{

					//}
					//fgrIndexlist.Rows[i + 1].Node.Level = (int)dtIndex.Rows[i]["階層"] - 1;
				}

				LinkCount = CountLinkedRow();
				txtFileCount.Text = (fgrFilelist.Rows.Count - 1).ToString();
				txtLinkCount.Text = LinkCount + "/" + (fgrIndexlist.Rows.Count - 1).ToString();

				//１つ目の画像表示
				fgrFilelist.Row = 1;
				fgrIndexlist.Row = 1;
				this.txtSelectKaisou.Text = this.fgrIndexlist.Rows[fgrIndexlist.Row]["階層"].ToString();
				this.txtSelectIndex.Text = this.fgrIndexlist.Rows[fgrIndexlist.Row]["しおり"].ToString();
				ViewImage();

				//イベント復活
				fgrIndexlist.RowColChange += new EventHandler(fgrIndexlist_RowColChange);
				fgrIndexlist.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(fgrIndexlist_CellChanged);
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
		/// 終了ボタン
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnEnd_Click(object sender, EventArgs e)
		{
			fgrIndexlist.RowColChange -= new EventHandler(fgrIndexlist_RowColChange);
			EnableChange(false);
			txtSelectKaisou.Text = "";
			txtSelectIndex.Text = "";
			fgrFilelist.Rows.Count = 1;
			fgrIndexlist.Rows.Count = 1;
			rivImage.Image = null;
			txtFileCount.Text = "0000";
			txtLinkCount.Text = "0000/0000";
		}

		/// <summary>
		/// ファイル一覧選択時
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void fgrFilelist_Click(object sender, EventArgs e)
		{
			ViewImage();
		}

		/// <summary>
		/// 改行禁止
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void fgrIndexlist_KeyDownEdit(object sender, C1.Win.C1FlexGrid.KeyEditEventArgs e)
		{
			//[Alt]+[Enter]のキー入力を無効にする
			if (e.Alt == true && e.KeyCode == Keys.Enter)
			{
				e.Handled = true;
			}
			if (e.Shift == true && e.KeyCode == Keys.Enter
				|| e.Control == true && e.KeyCode == Keys.Enter
				|| e.Control == true && e.KeyCode == Keys.J
				|| e.Control == true && e.KeyCode == Keys.J && e.Shift == true
				)
			{
				key_flag = true;
			}
		}

		/// <summary>
		/// しおりリスト編集前
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void fgrIndexlist_StartEdit(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
		{
			//キーが押された場合のみ編集状態にならないようにする
			if (key_flag)
			{
				e.Cancel = true;
				key_flag = false;
			}
		}

		private void fgrIndexlist_KeyPressEdit(object sender, C1.Win.C1FlexGrid.KeyPressEditEventArgs e)
		{
			if (key_flag)
			{
				e.Handled = true;
				key_flag = false;
			}
		}

		/// <summary>
		/// 左回転
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnLeftRotate_Click(object sender, EventArgs e)
		{
			ImageRotate(270, true);
		}
		/// <summary>
		/// 右回転
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnRightRotate_Click(object sender, EventArgs e)
		{
			ImageRotate(90, true);
		}
		/// <summary>
		/// 拡大
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnZoomIn_Click(object sender, EventArgs e)
		{
			rivImage.ScaleFactor *= 1.1F;
		}
		/// <summary>
		/// 縮小
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnZoomOut_Click(object sender, EventArgs e)
		{
			rivImage.ScaleFactor *= 0.9F;
		}
		/// <summary>
		/// 全体表示
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnZoomFit_Click(object sender, EventArgs e)
		{
			rivImage.ScaleFactor = 1.0F;
			rivImage.SizeMode = RasterPaintSizeMode.Fit;
		}

		/// <summary>
		/// しおり選択行変更時
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void fgrIndexlist_RowColChange(object sender, EventArgs e)
		{
			if (this.fgrIndexlist.Row <= 0)
			{
				return;
			}

			this.txtSelectKaisou.Text = this.fgrIndexlist.Rows[fgrIndexlist.Row]["階層"].ToString();
			this.txtSelectIndex.Text = this.fgrIndexlist.Rows[fgrIndexlist.Row]["しおり"].ToString();
		}

		/// <summary>
		/// セルのカーソル移動無効
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void FlexGrid_KeyDown(object sender, KeyEventArgs e)
		{
			key_flag = true;
			e.Handled = true;
		}

		/// <summary>
		/// セル編集後
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void fgrIndexlist_CellChanged(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
		{
			int Shiori_ID = (int)fgrIndexlist.Rows[fgrIndexlist.Row]["Shiori_ID"];
			int Kaisou = (int)fgrIndexlist.Rows[fgrIndexlist.Row]["階層"];
			string Shiori = fgrIndexlist.Rows[fgrIndexlist.Row]["しおり"].ToString();
			string LinkFileName = fgrIndexlist.Rows[fgrIndexlist.Row]["リンクファイル名"].ToString();
			bool DeleteFlag = (bool)fgrIndexlist.Rows[fgrIndexlist.Row]["削除"];
			string Bikou = fgrIndexlist.Rows[fgrIndexlist.Row]["備考"].ToString();
			string EditColName = fgrIndexlist.Cols[e.Col].Caption;

			//リンクファイル名が入力されている状態で削除フラグがたった場合
			if (EditColName == "削除" && DeleteFlag == true && LinkFileName != "")
			{
				fgrIndexlist.CellChanged -= new C1.Win.C1FlexGrid.RowColEventHandler(fgrIndexlist_CellChanged);
				if (MessageBox.Show("リンク済みのしおりです。\n削除しますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
				{
					fgrIndexlist.Rows[e.Row]["リンクファイル名"] = "";
					LinkFileName = "";
				}
				else
				{
					fgrIndexlist.Rows[e.Row]["削除"] = false;
					DeleteFlag = false;
				}
				fgrIndexlist.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(fgrIndexlist_CellChanged);
			}
			//削除フラグがたっているしおりにリンクされた場合
			if (EditColName == "リンクファイル名" && DeleteFlag == true && LinkFileName != "")
			{
				fgrIndexlist.CellChanged -= new C1.Win.C1FlexGrid.RowColEventHandler(fgrIndexlist_CellChanged);
				if (MessageBox.Show("削除フラグが入っているしおりです。\n削除フラグを解除しますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
				{
					fgrIndexlist.Rows[e.Row]["削除"] = false;
					DeleteFlag = false;
				}
				else
				{
					fgrIndexlist.Rows[e.Row]["リンクファイル名"] = "";
					LinkFileName = "";
				}
				fgrIndexlist.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(fgrIndexlist_CellChanged);
			}

			string strSQL = "";
			SQLProcess sqlProcess = new SQLProcess();
			try
			{
				strSQL = "UPDATE T_しおりツール_しおりリスト";
				strSQL += " SET 階層 = '" + Kaisou + "'";
				strSQL += " , しおり = '" + Shiori + "'";
				strSQL += " , リンクファイル名 = '" + LinkFileName + "'";
				strSQL += " , 削除フラグ = '" + DeleteFlag + "'";
				strSQL += " , 備考 = '" + Bikou + "'";
				strSQL += " WHERE JOB_ID = " + m_Job_ID;
				strSQL += " AND Shiori_ID = '" + Shiori_ID + "'";

				sqlProcess.DB_UPDATE(strSQL);
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

		private void fgrIndexlist_KeyPress(object sender, KeyPressEventArgs e)
		{
			//スペースキーの動作をさせない
			if (e.KeyChar == ' ')
			{
				e.Handled = true;
			}
		}

		/// <summary>
		/// しおり名の編集
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnEditIndex_Click(object sender, EventArgs e)
		{
			txtSelectIndex.Enabled = true;
			btnEditIndex.Enabled = false;
			btnConfirm.Enabled = true;
			btnAbort.Enabled = true;
		}

		/// <summary>
		/// しおり名の確定
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnConfirm_Click(object sender, EventArgs e)
		{
			fgrIndexlist.Rows[fgrIndexlist.Row]["しおり"] = txtSelectIndex.Text;
			txtSelectIndex.Enabled = false;
			btnEditIndex.Enabled = true;
			btnConfirm.Enabled = false;
			btnAbort.Enabled = false;
		}

		/// <summary>
		/// しおり名編集の中断
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnAbort_Click(object sender, EventArgs e)
		{
			txtSelectIndex.Text = fgrIndexlist.Rows[fgrIndexlist.Row]["しおり"].ToString();
			txtSelectIndex.Enabled = false;
			btnEditIndex.Enabled = true;
			btnConfirm.Enabled = false;
			btnAbort.Enabled = false;
		}

		private void fgrIndexlist_RowValidating(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
		{
			Control c = this.ActiveControl;

			if (txtSelectIndex.Enabled == true && c.Name != txtSelectIndex.Name && c.Name != btnConfirm.Name)
			{
				MessageBox.Show("しおり名を確定させてください。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				e.Cancel = true;
			}
		}

		/// <summary>
		/// RasterImageViewerダブルクリック時
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void rivImage_DoubleClick(object sender, EventArgs e)
		{
			rivImage.ScaleFactor = 1.0F;
			rivImage.SizeMode = RasterPaintSizeMode.Fit;
		}

		///// <summary>
		///// RasterImageViewerキーダウン時
		///// </summary>
		///// <param name="sender"></param>
		///// <param name="e"></param>
		//private void rivImage_KeyDown(object sender, KeyEventArgs e)
		//{
		//	ShortcutProcess(e.KeyCode);
		//}

		#endregion

		#region プライベートメソッド

		/// <summary>
		/// 画像表示
		/// </summary>
		/// <param name="ImagePath"></param>
		private void ViewImage()
		{
			if (fgrFilelist.Row <= 0)
			{
				return;
			}
			string ImagePath = ParentImagePath + "\\" + this.cmbLot.Text + "\\" + fgrFilelist.Rows[fgrFilelist.Row]["ファイル名"];
			//構造体を作成
			ImageProperty ip = new ImageProperty();
			//前回の画像のスクロール位置を取得
			Point ptScrollPosition = rivImage.ScrollPosition;
			//前回の画像の倍率を取得する
			ip.sngZoom = (float)rivImage.ScaleFactor;
			rivImage.Image = codecs.Load(ImagePath);
			//前回の画像の倍率を反映する
			rivImage.ScaleFactor = ip.sngZoom;
			//現在の画像に前回のスクロール位置を反映する
			rivImage.ScrollPosition = ptScrollPosition;
			//前回の回転角度を反映させる
			ImageRotate(ip.Degrees);
			//2値の表示を鮮明にする
			ColorResolutionCommand CRcommand = new ColorResolutionCommand();
			if (rivImage.Image.BitsPerPixel == 1)
			{
				CRcommand.BitsPerPixel = 2;
			}
            
			CRcommand.Run(rivImage.Image);
		}

		/// <summary>
		/// 画像回転
		/// </summary>
		/// <param name="degrees"></param>
		/// <param name="degreesCheck"></param>
		private void ImageRotate(int degrees,bool degreesCheck = false)
		{
			//アングルの指定(90度)
			ip.Angle = degrees * 100;    //角度×100
			//Flagsの初期化
			ip.Flags = RotateCommandFlags.None;
			//回転することによってキャンバスをリサイズする
				ip.Flags = ip.Flags | RotateCommandFlags.Resize;
			//バイキュービック法で回転
			ip.Flags = ip.Flags | RotateCommandFlags.Bicubic;
			ip.FillColor = new RasterColor(255, 255, 255);

			_initialAngle = ip.Angle;
			_initialFlags = ip.Flags;
			_initialFillColor = ip.FillColor;
			//コマンドオブジェクトの作成
			IRasterCommand command  = null;
			command = new RotateCommand(ip.Angle, ip.Flags, ip.FillColor);
			//角度変数に加算する
			if (degreesCheck == true)
			{
				ip.Degrees += degrees;
			}

			if(command != null)
			{
				RunCommand(command);
			}
		}

		/// <summary>
		/// コマンド実行
		/// </summary>
		/// <param name="command"></param>
		private void RunCommand(IRasterCommand command)
		{
			try
			{
				//中心を保持できるように、フロータの位置を保存する
				Point oldFloaterCenter = new Point(0, 0);
				if (rivImage.FloaterVisible && rivImage.FloaterImage != null)
				{
					oldFloaterCenter = rivImage.FloaterPosition;
					System.Drawing.Rectangle rect = ConvertRect(rivImage.FloaterImage.GetRegionBounds(null));
					oldFloaterCenter.Offset((int)rect.Right / 2, (int)rect.Bottom / 2);
				}

				command.Run(rivImage.Image);

				if (rivImage.FloaterVisible && rivImage.FloaterImage != null)
				{
					Point newFloaterCenter = rivImage.FloaterPosition;
					newFloaterCenter.Offset((int)rivImage.FloaterImage.Width / 2, (int)rivImage.FloaterImage.Height / 2);
					// 中心を保持するようにフロータの位置を移動します。
					Point FloaterPosition = rivImage.FloaterPosition;
					FloaterPosition.Offset(oldFloaterCenter.X - newFloaterCenter.X, oldFloaterCenter.Y - newFloaterCenter.Y);
					rivImage.FloaterPosition = FloaterPosition;
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

		private Rectangle ConvertRect(LeadRect rc)
		{
			return Rectangle.FromLTRB(rc.Left, rc.Top, rc.Right, rc.Bottom);
		}

		/// <summary>
		/// オブジェクト有効無効変更
		/// </summary>
		/// <param name="Flag"></param>
		private void EnableChange(bool Flag)
		{
			cmbLot.Enabled = !Flag;
			btnEnd.Enabled = Flag;
			btnLoad.Enabled = !Flag;
			btnConfirm.Enabled = Flag;
			btnEditIndex.Enabled = Flag;
			btnAbort.Enabled = Flag;
			btnBackMenu.Enabled = !Flag;
			btnLeftRotate.Enabled = Flag;
			btnRightRotate.Enabled = Flag;
			btnZoomIn.Enabled = Flag;
			btnZoomOut.Enabled = Flag;
			btnZoomFit.Enabled = Flag;
		}

		/// <summary>
		/// 初期化
		/// </summary>
		private void Initialize()
		{
			//LEADTOOLS 17.5のライセンスキー組み込み
			string strKey = "3liBV81SI91aeV5H7+e0vaPL7hqFf/eLBTniOyLZj4Uv1HlTF71YaoFWKVcPrqDCpWk5zxXR2hMir+2ZFQ1EQSEnwb5gKGNo+FBFdazmsxoEe12eqr1owzFilmLkzEKl3XYa4kw+DdwyGNsZwBoMtxyGU7zmEdqsDv32aaKCGmnlEeoFMgFEW8JVpUfu/qOUJUcLM0cUl8+AbKkk7S1eunK7V/yRxAsG3kQMjswgxuNfXj5Bbh8oERBwK6L3V1pa9gQMXJe25QVcROot3usMKGiTRAGTM9nVy4t4OLAFp/jNPbHS8le41XnxSjwPcSfZJ48xAnZObPuh8FKKw7uizTWPPL+3rEvHS0/LH5JYiLMiJQCY0fBjoOpAng/KK1tVrsyANvomxsKoOKCx1kI7WZGU4enysmSHXJDwK3YhJOu0zK/lT9LrVtlop0Ig166ycOfg1fXhbaKxZVvjh+6F5w==";
			RasterSupport.SetLicense(Properties.Resources.LEAD175ImgSuite, strKey);
			//入出力ライブラリの起動に必要なデータを初期化する
			codecs = new RasterCodecs();

			//ディスプレイモードをバイキュービック法でアンチエイリアス処理をして描画プロパティに適用
			RasterPaintProperties properties = new RasterPaintProperties();
			properties = RasterPaintProperties.Default;
			properties.PaintDisplayMode = RasterPaintDisplayModeFlags.Bicubic;
			rivImage.PaintProperties = properties;
			rivImage.ScaleFactor = 1.0F;
			rivImage.SizeMode = RasterPaintSizeMode.Fit;

			EnableChange(false);
			btnConfirm.Enabled = false;
		}

		private int CountLinkedRow()
		{
			int iLinkCount = 0;
			for (int i = 1; i <= fgrIndexlist.Rows.Count - 1; i++)
			{
				if (this.fgrIndexlist.Rows[i]["リンクファイル名"].ToString() != "")
				{
					iLinkCount++;
				}
			}
			return iLinkCount;
		}

		/// <summary>
		/// 全体的なショートカットを処理するメソッド
		/// </summary>
		private void ShortcutProcess(System.Windows.Forms.Keys keys)
		{
			if (fgrIndexlist.Editor != null)
			{
				return;
			}

			int FilelistRow = fgrFilelist.Row;
			int IndexlistRow = fgrIndexlist.Row;

			switch (keys)
			{
				case Keys.NumPad1:
				case Keys.D1:
					if (FilelistRow <= 0 || IndexlistRow <= 0)
					{
						return;
					}
					this.fgrIndexlist.Rows[fgrIndexlist.Row]["階層"] = 1;
					break;
				case Keys.NumPad2:
				case Keys.D2:
					if (FilelistRow <= 0 || IndexlistRow <= 0)
					{
						return;
					}
					this.fgrIndexlist.Rows[fgrIndexlist.Row]["階層"] = 2;
					break;
				//case Keys.NumPad3:
				//case Keys.D3:
				//    if (FilelistRow <= 0 || IndexlistRow <= 0)
				//    {
				//        return;
				//    }
				//    this.fgrIndexlist.Rows[fgrIndexlist.Row]["階層"] = 3;
				//    break;
				//Deleteキーでリンクファイル名削除
				case Keys.Delete:
					if (FilelistRow <= 0 || IndexlistRow <= 0 || this.fgrIndexlist.Rows[fgrIndexlist.Row]["リンクファイル名"].ToString() == "")
					{
						return;
					}
					if (MessageBox.Show("リンクファイル名を削除します。\nよろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.No)
					{
						return;
					}
					this.fgrIndexlist.Rows[fgrIndexlist.Row]["リンクファイル名"] = "";
					break;
				//Spaceキー押下時
				case Keys.Space:
					if (FilelistRow <= 0 || IndexlistRow <= 0)
					{
						return;
					}

					//選択中のファイルを選択しているしおりのリンクファイル名に入れる
					string FileName = this.fgrFilelist.Rows[fgrFilelist.Row]["ファイル名"].ToString();
					string LinkFileName = this.fgrIndexlist.Rows[fgrIndexlist.Row]["リンクファイル名"].ToString();

					//同じファイルをリンク済みの場合
					if (LinkFileName == FileName)
					{
						return;
					}

					//他のファイルでリンク済みの場合
					if (LinkFileName != "")
					{
						if (MessageBox.Show("リンク済みのしおりです。\n上書きしますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.No)
						{
							return;
						}
					}

					//他のしおりにリンク済みのファイルの場合
					for (int i = 1; i <= fgrIndexlist.Rows.Count - 1; i++)
					{
						if (FileName == this.fgrIndexlist.Rows[i]["リンクファイル名"].ToString())
						{
							if (MessageBox.Show("他のしおりにリンクされたファイルです。\n付け替えますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.No)
							{
								return;
							}
							else
							{
								this.fgrIndexlist.Rows[i]["リンクファイル名"] = "";
								//LinkCount -= 1;
							}
						}
					}

					this.fgrIndexlist.Rows[fgrIndexlist.Row]["リンクファイル名"] = FileName;
					LinkCount = CountLinkedRow();

					//次のレコードに移動
					if (this.fgrIndexlist.Row == this.fgrIndexlist.Rows.Count - 1)
					{
						if (MessageBox.Show("最後のしおりです。\nこのロットを終了しますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
						{
							//ロット終了
							btnEnd.PerformClick();
						}
					}
					else
					{
						this.fgrIndexlist.Row = this.fgrIndexlist.Row + 1;
					}

					if (this.fgrFilelist.Row != this.fgrFilelist.Rows.Count - 1)
					{
						this.fgrFilelist.Row = this.fgrFilelist.Row + 1;
					}

					txtLinkCount.Text = LinkCount + "/" + (fgrIndexlist.Rows.Count - 1).ToString();
					ViewImage();
					break;
				case Keys.PageUp:
					if (this.fgrFilelist.Row >= 2)
					{
						this.fgrFilelist.Row = this.fgrFilelist.Row - 1;
					}
					ViewImage();
					break;
				case Keys.PageDown:
					if (this.fgrFilelist.Row != this.fgrFilelist.Rows.Count - 1)
					{
						this.fgrFilelist.Row = this.fgrFilelist.Row + 1;
					}
					ViewImage();
					break;
				case Keys.Up:
					if (this.fgrIndexlist.Row >= 2)
					{
						this.fgrIndexlist.Row = this.fgrIndexlist.Row - 1;
					}
					break;
				case Keys.Down:
					if (this.fgrIndexlist.Row != this.fgrIndexlist.Rows.Count - 1)
					{
						this.fgrIndexlist.Row = this.fgrIndexlist.Row + 1;
					}
					break;
			}

		}

		#endregion

	}
}
