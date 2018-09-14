namespace PDF_Shiori
{
    partial class frmManage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManage));
            this.label1 = new System.Windows.Forms.Label();
            this.txtSakuban = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtJOBName = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.txtEndUser = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnRegister = new C1.Win.C1Input.C1Button();
            this.btnSearch = new C1.Win.C1Input.C1Button();
            this.txtAnkenName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.fgrJobList = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.c1StatusBar1 = new C1.Win.C1Ribbon.C1StatusBar();
            this.btnBackMenu = new C1.Win.C1Ribbon.RibbonButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnRegister)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fgrJobList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1StatusBar1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Name = "label1";
            // 
            // txtSakuban
            // 
            resources.ApplyResources(this.txtSakuban, "txtSakuban");
            this.txtSakuban.Name = "txtSakuban";
            this.txtSakuban.TextChanged += new System.EventHandler(this.txtSakuban_TextChanged);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Name = "label4";
            // 
            // txtJOBName
            // 
            resources.ApplyResources(this.txtJOBName, "txtJOBName");
            this.txtJOBName.Name = "txtJOBName";
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtCustomerName, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtEndUser, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label5, 2, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Name = "label2";
            // 
            // txtCustomerName
            // 
            resources.ApplyResources(this.txtCustomerName, "txtCustomerName");
            this.txtCustomerName.BackColor = System.Drawing.SystemColors.ControlDark;
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.ReadOnly = true;
            // 
            // txtEndUser
            // 
            resources.ApplyResources(this.txtEndUser, "txtEndUser");
            this.txtEndUser.BackColor = System.Drawing.SystemColors.ControlDark;
            this.txtEndUser.Name = "txtEndUser";
            this.txtEndUser.ReadOnly = true;
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Name = "label5";
            // 
            // btnRegister
            // 
            resources.ApplyResources(this.btnRegister, "btnRegister");
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // btnSearch
            // 
            resources.ApplyResources(this.btnSearch, "btnSearch");
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtAnkenName
            // 
            resources.ApplyResources(this.txtAnkenName, "txtAnkenName");
            this.txtAnkenName.BackColor = System.Drawing.SystemColors.ControlDark;
            this.txtAnkenName.Name = "txtAnkenName";
            this.txtAnkenName.ReadOnly = true;
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Name = "label3";
            // 
            // fgrJobList
            // 
            this.fgrJobList.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.fgrJobList, "fgrJobList");
            this.fgrJobList.Name = "fgrJobList";
            this.fgrJobList.Rows.Count = 1;
            this.fgrJobList.Rows.DefaultSize = 18;
            this.fgrJobList.StyleInfo = resources.GetString("fgrJobList.StyleInfo");
            this.fgrJobList.MouseEnterCell += new C1.Win.C1FlexGrid.RowColEventHandler(this.flex_MouseEnterCell);
            // 
            // c1StatusBar1
            // 
            this.c1StatusBar1.AutoSizeElement = C1.Framework.AutoSizeElement.Width;
            this.c1StatusBar1.Location = new System.Drawing.Point(0, 748);
            this.c1StatusBar1.Name = "c1StatusBar1";
            this.c1StatusBar1.RightPaneItems.Add(this.btnBackMenu);
            this.c1StatusBar1.Size = new System.Drawing.Size(1302, 23);
            // 
            // btnBackMenu
            // 
            this.btnBackMenu.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnBackMenu.LargeImage")));
            this.btnBackMenu.Name = "btnBackMenu";
            this.btnBackMenu.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnBackMenu.SmallImage")));
            resources.ApplyResources(this.btnBackMenu, "btnBackMenu");
            this.btnBackMenu.Click += new System.EventHandler(this.btnBackMenu_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.txtSakuban);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Controls.Add(this.txtAnkenName);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btnRegister);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtJOBName);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.fgrJobList);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // frmManage
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.c1StatusBar1);
            this.Name = "frmManage";
            this.VisualStyleHolder = C1.Win.C1Ribbon.VisualStyle.Office2007Black;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmManage_FormClosing);
            this.Load += new System.EventHandler(this.frmManage_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnRegister)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fgrJobList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1StatusBar1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSakuban;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtJOBName;
        private C1.Win.C1FlexGrid.C1FlexGrid fgrJobList;
        private System.Windows.Forms.TextBox txtAnkenName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.Label label2;
        private C1.Win.C1Ribbon.C1StatusBar c1StatusBar1;
        private C1.Win.C1Ribbon.RibbonButton btnBackMenu;
        private C1.Win.C1Input.C1Button btnSearch;
        private System.Windows.Forms.TextBox txtEndUser;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private C1.Win.C1Input.C1Button btnRegister;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}

