namespace PDF_Shiori
{
    partial class frmMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMenu));
            this.c1StatusBar1 = new C1.Win.C1Ribbon.C1StatusBar();
            this.c1MainMenu1 = new C1.Win.C1Command.C1MainMenu();
            this.c1CommandHolder1 = new C1.Win.C1Command.C1CommandHolder();
            this.btnMenu = new C1.Win.C1Command.C1CommandMenu();
            this.c1CommandLink2 = new C1.Win.C1Command.C1CommandLink();
            this.btnManage = new C1.Win.C1Command.C1Command();
            this.c1CommandLink3 = new C1.Win.C1Command.C1CommandLink();
            this.btnSQLSetting = new C1.Win.C1Command.C1Command();
            this.c1Command1 = new C1.Win.C1Command.C1Command();
            this.c1CommandLink1 = new C1.Win.C1Command.C1CommandLink();
            this.fgrJobList = new C1.Win.C1FlexGrid.C1FlexGrid();
            ((System.ComponentModel.ISupportInitialize)(this.c1StatusBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1CommandHolder1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fgrJobList)).BeginInit();
            this.SuspendLayout();
            // 
            // c1StatusBar1
            // 
            this.c1StatusBar1.AutoSizeElement = C1.Framework.AutoSizeElement.Width;
            this.c1StatusBar1.Location = new System.Drawing.Point(0, 548);
            this.c1StatusBar1.Name = "c1StatusBar1";
            this.c1StatusBar1.Size = new System.Drawing.Size(1032, 23);
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
            this.c1CommandHolder1.Commands.Add(this.btnMenu);
            this.c1CommandHolder1.Commands.Add(this.btnManage);
            this.c1CommandHolder1.Commands.Add(this.c1Command1);
            this.c1CommandHolder1.Commands.Add(this.btnSQLSetting);
            this.c1CommandHolder1.Owner = this;
            // 
            // btnMenu
            // 
            this.btnMenu.CommandLinks.AddRange(new C1.Win.C1Command.C1CommandLink[] {
            this.c1CommandLink2,
            this.c1CommandLink3});
            this.btnMenu.HideNonRecentLinks = false;
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            resources.ApplyResources(this.btnMenu, "btnMenu");
            // 
            // c1CommandLink2
            // 
            this.c1CommandLink2.Command = this.btnManage;
            // 
            // btnManage
            // 
            this.btnManage.Name = "btnManage";
            resources.ApplyResources(this.btnManage, "btnManage");
            this.btnManage.Click += new C1.Win.C1Command.ClickEventHandler(this.btnManage_Click);
            // 
            // c1CommandLink3
            // 
            this.c1CommandLink3.Command = this.btnSQLSetting;
            this.c1CommandLink3.SortOrder = 1;
            // 
            // btnSQLSetting
            // 
            this.btnSQLSetting.Name = "btnSQLSetting";
            resources.ApplyResources(this.btnSQLSetting, "btnSQLSetting");
            this.btnSQLSetting.Click += new C1.Win.C1Command.ClickEventHandler(this.btnSQLSetting_Click);
            // 
            // c1Command1
            // 
            this.c1Command1.Name = "c1Command1";
            resources.ApplyResources(this.c1Command1, "c1Command1");
            // 
            // c1CommandLink1
            // 
            this.c1CommandLink1.Command = this.btnMenu;
            // 
            // fgrJobList
            // 
            this.fgrJobList.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.fgrJobList, "fgrJobList");
            this.fgrJobList.Name = "fgrJobList";
            this.fgrJobList.Rows.Count = 1;
            this.fgrJobList.Rows.DefaultSize = 18;
            this.fgrJobList.StyleInfo = resources.GetString("fgrJobList.StyleInfo");
            this.fgrJobList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.fgrJobList_DoubleClick);
            // 
            // frmMenu
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.fgrJobList);
            this.Controls.Add(this.c1StatusBar1);
            this.Controls.Add(this.c1MainMenu1);
            this.Name = "frmMenu";
            this.VisualStyleHolder = C1.Win.C1Ribbon.VisualStyle.Office2007Black;
            this.Load += new System.EventHandler(this.frmMenu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.c1StatusBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1CommandHolder1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fgrJobList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private C1.Win.C1Ribbon.C1StatusBar c1StatusBar1;
        private C1.Win.C1Command.C1MainMenu c1MainMenu1;
        private C1.Win.C1Command.C1CommandHolder c1CommandHolder1;
        private C1.Win.C1Command.C1CommandLink c1CommandLink1;
        private C1.Win.C1Command.C1CommandMenu btnMenu;
        private C1.Win.C1Command.C1CommandLink c1CommandLink2;
        private C1.Win.C1Command.C1Command btnManage;
        private C1.Win.C1Command.C1Command c1Command1;
        private C1.Win.C1Command.C1CommandLink c1CommandLink3;
        private C1.Win.C1Command.C1Command btnSQLSetting;
        private C1.Win.C1FlexGrid.C1FlexGrid fgrJobList;
    }
}

