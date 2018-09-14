namespace PDF_Shiori
{
    partial class frmMain
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
			this.c1MainMenu1 = new C1.Win.C1Command.C1MainMenu();
			this.c1CommandHolder1 = new C1.Win.C1Command.C1CommandHolder();
			this.c1CommandLink1 = new C1.Win.C1Command.C1CommandLink();
			this.imvSelectedImage = new Leadtools.WinForms.RasterImageViewer();
			this.c1SplitContainer1 = new C1.Win.C1SplitContainer.C1SplitContainer();
			this.c1SplitterPanel1 = new C1.Win.C1SplitContainer.C1SplitterPanel();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.fgrFilelist = new C1.Win.C1FlexGrid.C1FlexGrid();
			this.panel1 = new System.Windows.Forms.Panel();
			this.cmbLot = new C1.Win.C1List.C1Combo();
			this.btnEnd = new C1.Win.C1Input.C1Button();
			this.btnLoad = new C1.Win.C1Input.C1Button();
			this.c1SplitterPanel2 = new C1.Win.C1SplitContainer.C1SplitterPanel();
			this.rivImage = new Leadtools.WinForms.RasterImageViewer();
			this.panel3 = new System.Windows.Forms.Panel();
			this.btnZoomFit = new C1.Win.C1Input.C1Button();
			this.btnZoomOut = new C1.Win.C1Input.C1Button();
			this.btnZoomIn = new C1.Win.C1Input.C1Button();
			this.btnRightRotate = new C1.Win.C1Input.C1Button();
			this.btnLeftRotate = new C1.Win.C1Input.C1Button();
			this.panel2 = new System.Windows.Forms.Panel();
			this.txtSelectIndex = new C1.Win.C1Input.C1TextBox();
			this.txtSelectKaisou = new C1.Win.C1Input.C1TextBox();
			this.btnEditIndex = new C1.Win.C1Input.C1Button();
			this.btnConfirm = new C1.Win.C1Input.C1Button();
			this.c1SplitterPanel3 = new C1.Win.C1SplitContainer.C1SplitterPanel();
			this.fgrIndexlist = new C1.Win.C1FlexGrid.C1FlexGrid();
			this.c1StatusBar1 = new C1.Win.C1Ribbon.C1StatusBar();
			this.txtFileCount = new C1.Win.C1Ribbon.RibbonTextBox();
			this.txtLinkCount = new C1.Win.C1Ribbon.RibbonTextBox();
			this.btnBackMenu = new C1.Win.C1Ribbon.RibbonButton();
			this.btnAbort = new C1.Win.C1Input.C1Button();
			((System.ComponentModel.ISupportInitialize)(this.c1CommandHolder1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.c1SplitContainer1)).BeginInit();
			this.c1SplitContainer1.SuspendLayout();
			this.c1SplitterPanel1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.fgrFilelist)).BeginInit();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.cmbLot)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.btnEnd)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.btnLoad)).BeginInit();
			this.c1SplitterPanel2.SuspendLayout();
			this.panel3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.btnZoomFit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.btnZoomOut)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.btnZoomIn)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.btnRightRotate)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.btnLeftRotate)).BeginInit();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.txtSelectIndex)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtSelectKaisou)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.btnEditIndex)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.btnConfirm)).BeginInit();
			this.c1SplitterPanel3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.fgrIndexlist)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.c1StatusBar1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.btnAbort)).BeginInit();
			this.SuspendLayout();
			// 
			// c1MainMenu1
			// 
			this.c1MainMenu1.CommandHolder = this.c1CommandHolder1;
			this.c1MainMenu1.CommandLinks.AddRange(new C1.Win.C1Command.C1CommandLink[] {
            this.c1CommandLink1});
			resources.ApplyResources(this.c1MainMenu1, "c1MainMenu1");
			this.c1MainMenu1.Name = "c1MainMenu1";
			this.c1MainMenu1.VisualStyleBase = C1.Win.C1Command.VisualStyle.Office2007Black;
			// 
			// c1CommandHolder1
			// 
			this.c1CommandHolder1.Owner = this;
			// 
			// c1CommandLink1
			// 
			resources.ApplyResources(this.c1CommandLink1, "c1CommandLink1");
			// 
			// imvSelectedImage
			// 
			resources.ApplyResources(this.imvSelectedImage, "imvSelectedImage");
			this.imvSelectedImage.Name = "imvSelectedImage";
			// 
			// c1SplitContainer1
			// 
			this.c1SplitContainer1.AutoSizeElement = C1.Framework.AutoSizeElement.Both;
			this.c1SplitContainer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
			resources.ApplyResources(this.c1SplitContainer1, "c1SplitContainer1");
			this.c1SplitContainer1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.c1SplitContainer1.Name = "c1SplitContainer1";
			this.c1SplitContainer1.Panels.Add(this.c1SplitterPanel1);
			this.c1SplitContainer1.Panels.Add(this.c1SplitterPanel2);
			this.c1SplitContainer1.Panels.Add(this.c1SplitterPanel3);
			this.c1SplitContainer1.ToolTipGradient = C1.Win.C1SplitContainer.ToolTipGradient.Vista;
			this.c1SplitContainer1.UseParentVisualStyle = false;
			// 
			// c1SplitterPanel1
			// 
			this.c1SplitterPanel1.Controls.Add(this.groupBox1);
			this.c1SplitterPanel1.Controls.Add(this.panel1);
			resources.ApplyResources(this.c1SplitterPanel1, "c1SplitterPanel1");
			this.c1SplitterPanel1.Location = new System.Drawing.Point(0, 21);
			this.c1SplitterPanel1.Name = "c1SplitterPanel1";
			this.c1SplitterPanel1.Size = new System.Drawing.Size(200, 700);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.fgrFilelist);
			resources.ApplyResources(this.groupBox1, "groupBox1");
			this.groupBox1.ForeColor = System.Drawing.Color.White;
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.TabStop = false;
			// 
			// fgrFilelist
			// 
			resources.ApplyResources(this.fgrFilelist, "fgrFilelist");
			this.fgrFilelist.ExtendLastCol = true;
			this.fgrFilelist.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
			this.fgrFilelist.Name = "fgrFilelist";
			this.fgrFilelist.Rows.Count = 1;
			this.fgrFilelist.Rows.DefaultSize = 18;
			this.fgrFilelist.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row;
			this.fgrFilelist.Click += new System.EventHandler(this.fgrFilelist_Click);
			this.fgrFilelist.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FlexGrid_KeyDown);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.cmbLot);
			this.panel1.Controls.Add(this.btnEnd);
			this.panel1.Controls.Add(this.btnLoad);
			resources.ApplyResources(this.panel1, "panel1");
			this.panel1.Name = "panel1";
			// 
			// cmbLot
			// 
			this.cmbLot.AddItemSeparator = ';';
			resources.ApplyResources(this.cmbLot, "cmbLot");
			this.cmbLot.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
			this.cmbLot.ComboStyle = C1.Win.C1List.ComboStyleEnum.DropdownList;
			this.cmbLot.DeadAreaBackColor = System.Drawing.Color.Empty;
			this.cmbLot.EditorBackColor = System.Drawing.SystemColors.Window;
			this.cmbLot.EditorFont = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.cmbLot.EditorForeColor = System.Drawing.SystemColors.WindowText;
			this.cmbLot.MatchEntryTimeout = ((long)(2000));
			this.cmbLot.MaxDropDownItems = ((short)(5));
			this.cmbLot.MaxLength = 32767;
			this.cmbLot.MouseCursor = System.Windows.Forms.Cursors.Default;
			this.cmbLot.Name = "cmbLot";
			this.cmbLot.PropBag = resources.GetString("cmbLot.PropBag");
			this.cmbLot.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
			this.cmbLot.RowSubDividerColor = System.Drawing.Color.DarkGray;
			this.cmbLot.VisualStyle = C1.Win.C1List.VisualStyle.Office2007Black;
			// 
			// btnEnd
			// 
			resources.ApplyResources(this.btnEnd, "btnEnd");
			this.btnEnd.Name = "btnEnd";
			this.btnEnd.UseVisualStyleBackColor = true;
			this.btnEnd.Click += new System.EventHandler(this.btnEnd_Click);
			// 
			// btnLoad
			// 
			resources.ApplyResources(this.btnLoad, "btnLoad");
			this.btnLoad.Name = "btnLoad";
			this.btnLoad.UseVisualStyleBackColor = true;
			this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
			// 
			// c1SplitterPanel2
			// 
			this.c1SplitterPanel2.Controls.Add(this.rivImage);
			this.c1SplitterPanel2.Controls.Add(this.panel3);
			this.c1SplitterPanel2.Controls.Add(this.imvSelectedImage);
			this.c1SplitterPanel2.Controls.Add(this.panel2);
			resources.ApplyResources(this.c1SplitterPanel2, "c1SplitterPanel2");
			this.c1SplitterPanel2.Location = new System.Drawing.Point(204, 21);
			this.c1SplitterPanel2.Name = "c1SplitterPanel2";
			this.c1SplitterPanel2.Size = new System.Drawing.Size(788, 467);
			// 
			// rivImage
			// 
			this.rivImage.Cursor = System.Windows.Forms.Cursors.Default;
			resources.ApplyResources(this.rivImage, "rivImage");
			this.rivImage.InteractiveMode = Leadtools.WinForms.RasterViewerInteractiveMode.ZoomTo;
			this.rivImage.Name = "rivImage";
			this.rivImage.DoubleClick += new System.EventHandler(this.rivImage_DoubleClick);
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.btnZoomFit);
			this.panel3.Controls.Add(this.btnZoomOut);
			this.panel3.Controls.Add(this.btnZoomIn);
			this.panel3.Controls.Add(this.btnRightRotate);
			this.panel3.Controls.Add(this.btnLeftRotate);
			resources.ApplyResources(this.panel3, "panel3");
			this.panel3.Name = "panel3";
			// 
			// btnZoomFit
			// 
			resources.ApplyResources(this.btnZoomFit, "btnZoomFit");
			this.btnZoomFit.Name = "btnZoomFit";
			this.btnZoomFit.UseVisualStyleBackColor = true;
			this.btnZoomFit.Click += new System.EventHandler(this.btnZoomFit_Click);
			// 
			// btnZoomOut
			// 
			resources.ApplyResources(this.btnZoomOut, "btnZoomOut");
			this.btnZoomOut.Name = "btnZoomOut";
			this.btnZoomOut.UseVisualStyleBackColor = true;
			this.btnZoomOut.Click += new System.EventHandler(this.btnZoomOut_Click);
			// 
			// btnZoomIn
			// 
			resources.ApplyResources(this.btnZoomIn, "btnZoomIn");
			this.btnZoomIn.Name = "btnZoomIn";
			this.btnZoomIn.UseVisualStyleBackColor = true;
			this.btnZoomIn.Click += new System.EventHandler(this.btnZoomIn_Click);
			// 
			// btnRightRotate
			// 
			resources.ApplyResources(this.btnRightRotate, "btnRightRotate");
			this.btnRightRotate.Name = "btnRightRotate";
			this.btnRightRotate.UseVisualStyleBackColor = true;
			this.btnRightRotate.Click += new System.EventHandler(this.btnRightRotate_Click);
			// 
			// btnLeftRotate
			// 
			resources.ApplyResources(this.btnLeftRotate, "btnLeftRotate");
			this.btnLeftRotate.Name = "btnLeftRotate";
			this.btnLeftRotate.UseVisualStyleBackColor = true;
			this.btnLeftRotate.Click += new System.EventHandler(this.btnLeftRotate_Click);
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.txtSelectIndex);
			this.panel2.Controls.Add(this.txtSelectKaisou);
			this.panel2.Controls.Add(this.btnAbort);
			this.panel2.Controls.Add(this.btnEditIndex);
			this.panel2.Controls.Add(this.btnConfirm);
			resources.ApplyResources(this.panel2, "panel2");
			this.panel2.Name = "panel2";
			// 
			// txtSelectIndex
			// 
			resources.ApplyResources(this.txtSelectIndex, "txtSelectIndex");
			this.txtSelectIndex.Name = "txtSelectIndex";
			// 
			// txtSelectKaisou
			// 
			resources.ApplyResources(this.txtSelectKaisou, "txtSelectKaisou");
			this.txtSelectKaisou.Name = "txtSelectKaisou";
			// 
			// btnEditIndex
			// 
			resources.ApplyResources(this.btnEditIndex, "btnEditIndex");
			this.btnEditIndex.Name = "btnEditIndex";
			this.btnEditIndex.UseVisualStyleBackColor = true;
			this.btnEditIndex.Click += new System.EventHandler(this.btnEditIndex_Click);
			// 
			// btnConfirm
			// 
			resources.ApplyResources(this.btnConfirm, "btnConfirm");
			this.btnConfirm.Name = "btnConfirm";
			this.btnConfirm.UseVisualStyleBackColor = true;
			this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
			// 
			// c1SplitterPanel3
			// 
			this.c1SplitterPanel3.Controls.Add(this.fgrIndexlist);
			resources.ApplyResources(this.c1SplitterPanel3, "c1SplitterPanel3");
			this.c1SplitterPanel3.Location = new System.Drawing.Point(204, 513);
			this.c1SplitterPanel3.Name = "c1SplitterPanel3";
			this.c1SplitterPanel3.Size = new System.Drawing.Size(788, 208);
			// 
			// fgrIndexlist
			// 
			resources.ApplyResources(this.fgrIndexlist, "fgrIndexlist");
			this.fgrIndexlist.ExtendLastCol = true;
			this.fgrIndexlist.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
			this.fgrIndexlist.Name = "fgrIndexlist";
			this.fgrIndexlist.Rows.Count = 1;
			this.fgrIndexlist.Rows.DefaultSize = 18;
			this.fgrIndexlist.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row;
			this.fgrIndexlist.UseCompatibleTextRendering = true;
			this.fgrIndexlist.RowColChange += new System.EventHandler(this.fgrIndexlist_RowColChange);
			this.fgrIndexlist.StartEdit += new C1.Win.C1FlexGrid.RowColEventHandler(this.fgrIndexlist_StartEdit);
			this.fgrIndexlist.KeyDownEdit += new C1.Win.C1FlexGrid.KeyEditEventHandler(this.fgrIndexlist_KeyDownEdit);
			this.fgrIndexlist.KeyPressEdit += new C1.Win.C1FlexGrid.KeyPressEditEventHandler(this.fgrIndexlist_KeyPressEdit);
			this.fgrIndexlist.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.fgrIndexlist_CellChanged);
			this.fgrIndexlist.RowValidating += new C1.Win.C1FlexGrid.RowColEventHandler(this.fgrIndexlist_RowValidating);
			this.fgrIndexlist.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FlexGrid_KeyDown);
			this.fgrIndexlist.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.fgrIndexlist_KeyPress);
			// 
			// c1StatusBar1
			// 
			this.c1StatusBar1.AutoSizeElement = C1.Framework.AutoSizeElement.Width;
			this.c1StatusBar1.LeftPaneItems.Add(this.txtFileCount);
			this.c1StatusBar1.LeftPaneItems.Add(this.txtLinkCount);
			this.c1StatusBar1.Location = new System.Drawing.Point(0, 748);
			this.c1StatusBar1.Name = "c1StatusBar1";
			this.c1StatusBar1.RightPaneItems.Add(this.btnBackMenu);
			this.c1StatusBar1.Size = new System.Drawing.Size(992, 23);
			// 
			// txtFileCount
			// 
			this.txtFileCount.Enabled = false;
			resources.ApplyResources(this.txtFileCount, "txtFileCount");
			this.txtFileCount.Name = "txtFileCount";
			// 
			// txtLinkCount
			// 
			this.txtLinkCount.Enabled = false;
			resources.ApplyResources(this.txtLinkCount, "txtLinkCount");
			this.txtLinkCount.Name = "txtLinkCount";
			// 
			// btnBackMenu
			// 
			this.btnBackMenu.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnBackMenu.LargeImage")));
			this.btnBackMenu.Name = "btnBackMenu";
			this.btnBackMenu.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnBackMenu.SmallImage")));
			resources.ApplyResources(this.btnBackMenu, "btnBackMenu");
			this.btnBackMenu.Click += new System.EventHandler(this.btnBackMenu_Click);
			// 
			// btnAbort
			// 
			resources.ApplyResources(this.btnAbort, "btnAbort");
			this.btnAbort.Name = "btnAbort";
			this.btnAbort.UseVisualStyleBackColor = true;
			this.btnAbort.Click += new System.EventHandler(this.btnAbort_Click);
			// 
			// frmMain
			// 
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.c1SplitContainer1);
			this.Controls.Add(this.c1StatusBar1);
			this.Controls.Add(this.c1MainMenu1);
			this.KeyPreview = true;
			this.Name = "frmMain";
			this.VisualStyleHolder = C1.Win.C1Ribbon.VisualStyle.Office2007Black;
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
			this.Load += new System.EventHandler(this.frmMain_Load);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmMain_KeyDown);
			((System.ComponentModel.ISupportInitialize)(this.c1CommandHolder1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.c1SplitContainer1)).EndInit();
			this.c1SplitContainer1.ResumeLayout(false);
			this.c1SplitterPanel1.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.fgrFilelist)).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.cmbLot)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.btnEnd)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.btnLoad)).EndInit();
			this.c1SplitterPanel2.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.btnZoomFit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.btnZoomOut)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.btnZoomIn)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.btnRightRotate)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.btnLeftRotate)).EndInit();
			this.panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.txtSelectIndex)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtSelectKaisou)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.btnEditIndex)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.btnConfirm)).EndInit();
			this.c1SplitterPanel3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.fgrIndexlist)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.c1StatusBar1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.btnAbort)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
        private C1.Win.C1Command.C1MainMenu c1MainMenu1;
        private C1.Win.C1Command.C1CommandHolder c1CommandHolder1;
        private Leadtools.WinForms.RasterImageViewer imvSelectedImage;
        private C1.Win.C1Command.C1CommandLink c1CommandLink1;
        private C1.Win.C1SplitContainer.C1SplitContainer c1SplitContainer1;
        private C1.Win.C1SplitContainer.C1SplitterPanel c1SplitterPanel1;
        private C1.Win.C1SplitContainer.C1SplitterPanel c1SplitterPanel2;
        private C1.Win.C1SplitContainer.C1SplitterPanel c1SplitterPanel3;
        private C1.Win.C1Input.C1Button btnLoad;
        private System.Windows.Forms.GroupBox groupBox1;
        private C1.Win.C1FlexGrid.C1FlexGrid fgrIndexlist;
        private C1.Win.C1FlexGrid.C1FlexGrid fgrFilelist;
        private C1.Win.C1Ribbon.C1StatusBar c1StatusBar1;
        private C1.Win.C1Ribbon.RibbonButton btnBackMenu;
        private C1.Win.C1List.C1Combo cmbLot;
        private System.Windows.Forms.Panel panel1;
        private C1.Win.C1Input.C1Button btnEnd;
        private Leadtools.WinForms.RasterImageViewer rivImage;
        private System.Windows.Forms.Panel panel2;
        private C1.Win.C1Input.C1TextBox txtSelectIndex;
        private C1.Win.C1Input.C1TextBox txtSelectKaisou;
        private C1.Win.C1Input.C1Button btnEditIndex;
        private C1.Win.C1Input.C1Button btnConfirm;
        private C1.Win.C1Ribbon.RibbonTextBox txtFileCount;
        private C1.Win.C1Ribbon.RibbonTextBox txtLinkCount;
        private System.Windows.Forms.Panel panel3;
        private C1.Win.C1Input.C1Button btnZoomFit;
        private C1.Win.C1Input.C1Button btnZoomOut;
        private C1.Win.C1Input.C1Button btnZoomIn;
        private C1.Win.C1Input.C1Button btnRightRotate;
        private C1.Win.C1Input.C1Button btnLeftRotate;
		private C1.Win.C1Input.C1Button btnAbort;
	}
}

