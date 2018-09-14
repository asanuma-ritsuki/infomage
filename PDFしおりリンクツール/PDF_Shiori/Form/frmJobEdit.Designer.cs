namespace PDF_Shiori
{
    partial class frmJobEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmJobEdit));
            this.label1 = new System.Windows.Forms.Label();
            this.txtEndUser = new System.Windows.Forms.TextBox();
            this.btnRegister = new C1.Win.C1Input.C1Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtJobName = new System.Windows.Forms.TextBox();
            this.txtSakuban = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAnkenName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.fgrColSetting = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cmbJoinchar = new C1.Win.C1Input.C1ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.txtImageFolder = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnOpenImageFolder = new C1.Win.C1Input.C1Button();
            this.label9 = new System.Windows.Forms.Label();
            this.txtShioriFile = new System.Windows.Forms.TextBox();
            this.cmbMojicode = new C1.Win.C1Input.C1ComboBox();
            this.btnOpenShioriFolder = new C1.Win.C1Input.C1Button();
            this.cmbExtension = new C1.Win.C1Input.C1ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.chkHeader = new System.Windows.Forms.CheckBox();
            this.btnLoad = new C1.Win.C1Input.C1Button();
            this.rbTab = new System.Windows.Forms.RadioButton();
            this.rbComma = new System.Windows.Forms.RadioButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtUnknown = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.btnMojiChk = new C1.Win.C1Input.C1Button();
            this.txtLogFolder = new System.Windows.Forms.TextBox();
            this.btnOpenLogFolder = new C1.Win.C1Input.C1Button();
            this.label12 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.c1StatusBar1 = new C1.Win.C1Ribbon.C1StatusBar();
            this.ProgressBar = new C1.Win.C1Ribbon.RibbonProgressBar();
            this.lblProgress = new C1.Win.C1Ribbon.RibbonLabel();
            this.btnBackMenu = new C1.Win.C1Ribbon.RibbonButton();
            ((System.ComponentModel.ISupportInitialize)(this.btnRegister)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fgrColSetting)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbJoinchar)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnOpenImageFolder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbMojicode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOpenShioriFolder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbExtension)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnLoad)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnMojiChk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOpenLogFolder)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c1StatusBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Name = "label1";
            // 
            // txtEndUser
            // 
            resources.ApplyResources(this.txtEndUser, "txtEndUser");
            this.txtEndUser.BackColor = System.Drawing.SystemColors.ControlDark;
            this.txtEndUser.Name = "txtEndUser";
            this.txtEndUser.ReadOnly = true;
            // 
            // btnRegister
            // 
            resources.ApplyResources(this.btnRegister, "btnRegister");
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Name = "label4";
            // 
            // txtJobName
            // 
            resources.ApplyResources(this.txtJobName, "txtJobName");
            this.txtJobName.BackColor = System.Drawing.SystemColors.ControlDark;
            this.txtJobName.Name = "txtJobName";
            this.txtJobName.ReadOnly = true;
            // 
            // txtSakuban
            // 
            resources.ApplyResources(this.txtSakuban, "txtSakuban");
            this.txtSakuban.BackColor = System.Drawing.SystemColors.ControlDark;
            this.txtSakuban.Name = "txtSakuban";
            this.txtSakuban.ReadOnly = true;
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Name = "label5";
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
            // txtCustomerName
            // 
            resources.ApplyResources(this.txtCustomerName, "txtCustomerName");
            this.txtCustomerName.BackColor = System.Drawing.SystemColors.ControlDark;
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.ReadOnly = true;
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Name = "label2";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Controls.Add(this.txtJobName);
            this.groupBox1.Controls.Add(this.label4);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtSakuban, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtAnkenName, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtCustomerName, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtEndUser, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 2, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.panel3);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.fgrColSetting);
            this.groupBox3.Controls.Add(this.panel2);
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.ForeColor = System.Drawing.Color.White;
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            // 
            // fgrColSetting
            // 
            resources.ApplyResources(this.fgrColSetting, "fgrColSetting");
            this.fgrColSetting.Name = "fgrColSetting";
            this.fgrColSetting.Rows.Count = 0;
            this.fgrColSetting.Rows.DefaultSize = 18;
            this.fgrColSetting.Rows.Fixed = 0;
            this.fgrColSetting.BeforeEdit += new C1.Win.C1FlexGrid.RowColEventHandler(this.fgrColSetting_BeforeEdit_1);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cmbJoinchar);
            this.panel2.Controls.Add(this.label11);
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // cmbJoinchar
            // 
            this.cmbJoinchar.AllowSpinLoop = false;
            resources.ApplyResources(this.cmbJoinchar, "cmbJoinchar");
            this.cmbJoinchar.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.cmbJoinchar.DropDownStyle = C1.Win.C1Input.DropDownStyle.DropDownList;
            this.cmbJoinchar.ImagePadding = new System.Windows.Forms.Padding(0);
            this.cmbJoinchar.InitialSelectedIndex = 0;
            this.cmbJoinchar.Items.Add("なし");
            this.cmbJoinchar.Items.Add("アンダースコア(_)");
            this.cmbJoinchar.Items.Add("ハイフン(-)");
            this.cmbJoinchar.Items.Add("スペース( )");
            this.cmbJoinchar.ItemsDisplayMember = "";
            this.cmbJoinchar.ItemsValueMember = "";
            this.cmbJoinchar.Name = "cmbJoinchar";
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Name = "label11";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.txtImageFolder);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.btnOpenImageFolder);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.txtShioriFile);
            this.panel3.Controls.Add(this.cmbMojicode);
            this.panel3.Controls.Add(this.btnOpenShioriFolder);
            this.panel3.Controls.Add(this.cmbExtension);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.chkHeader);
            this.panel3.Controls.Add(this.btnLoad);
            this.panel3.Controls.Add(this.rbTab);
            this.panel3.Controls.Add(this.rbComma);
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.Name = "panel3";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Name = "label6";
            // 
            // txtImageFolder
            // 
            this.txtImageFolder.AllowDrop = true;
            resources.ApplyResources(this.txtImageFolder, "txtImageFolder");
            this.txtImageFolder.Name = "txtImageFolder";
            this.txtImageFolder.ReadOnly = true;
            this.txtImageFolder.DragDrop += new System.Windows.Forms.DragEventHandler(this.TextBox_DragDrop);
            this.txtImageFolder.DragEnter += new System.Windows.Forms.DragEventHandler(this.TextBox_DragEnter);
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Name = "label10";
            // 
            // btnOpenImageFolder
            // 
            resources.ApplyResources(this.btnOpenImageFolder, "btnOpenImageFolder");
            this.btnOpenImageFolder.Name = "btnOpenImageFolder";
            this.btnOpenImageFolder.UseVisualStyleBackColor = true;
            this.btnOpenImageFolder.Click += new System.EventHandler(this.btnFolderOpen_Click);
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Name = "label9";
            // 
            // txtShioriFile
            // 
            this.txtShioriFile.AllowDrop = true;
            resources.ApplyResources(this.txtShioriFile, "txtShioriFile");
            this.txtShioriFile.Name = "txtShioriFile";
            this.txtShioriFile.ReadOnly = true;
            this.txtShioriFile.DragDrop += new System.Windows.Forms.DragEventHandler(this.TextBox_DragDrop);
            this.txtShioriFile.DragEnter += new System.Windows.Forms.DragEventHandler(this.TextBox_DragEnter);
            // 
            // cmbMojicode
            // 
            this.cmbMojicode.AllowSpinLoop = false;
            resources.ApplyResources(this.cmbMojicode, "cmbMojicode");
            this.cmbMojicode.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.cmbMojicode.DropDownStyle = C1.Win.C1Input.DropDownStyle.DropDownList;
            this.cmbMojicode.ImagePadding = new System.Windows.Forms.Padding(0);
            this.cmbMojicode.InitialSelectedIndex = 0;
            this.cmbMojicode.ItemsDisplayMember = "";
            this.cmbMojicode.ItemsValueMember = "";
            this.cmbMojicode.Name = "cmbMojicode";
            // 
            // btnOpenShioriFolder
            // 
            resources.ApplyResources(this.btnOpenShioriFolder, "btnOpenShioriFolder");
            this.btnOpenShioriFolder.Name = "btnOpenShioriFolder";
            this.btnOpenShioriFolder.UseVisualStyleBackColor = true;
            this.btnOpenShioriFolder.Click += new System.EventHandler(this.btnFileOpen_Click);
            // 
            // cmbExtension
            // 
            this.cmbExtension.AllowSpinLoop = false;
            resources.ApplyResources(this.cmbExtension, "cmbExtension");
            this.cmbExtension.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.cmbExtension.DropDownStyle = C1.Win.C1Input.DropDownStyle.DropDownList;
            this.cmbExtension.ImagePadding = new System.Windows.Forms.Padding(0);
            this.cmbExtension.InitialSelectedIndex = 0;
            this.cmbExtension.Items.Add("*.tif");
            this.cmbExtension.Items.Add("*.jpg");
            this.cmbExtension.Items.Add("*.tif&*.jpg");
            this.cmbExtension.Items.Add("*.pdf");
            this.cmbExtension.ItemsDisplayMember = "";
            this.cmbExtension.ItemsValueMember = "";
            this.cmbExtension.Name = "cmbExtension";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Name = "label7";
            // 
            // chkHeader
            // 
            resources.ApplyResources(this.chkHeader, "chkHeader");
            this.chkHeader.Checked = true;
            this.chkHeader.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkHeader.Name = "chkHeader";
            this.chkHeader.UseVisualStyleBackColor = true;
            // 
            // btnLoad
            // 
            resources.ApplyResources(this.btnLoad, "btnLoad");
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoadCheck_Click);
            // 
            // rbTab
            // 
            resources.ApplyResources(this.rbTab, "rbTab");
            this.rbTab.Checked = true;
            this.rbTab.Name = "rbTab";
            this.rbTab.TabStop = true;
            this.rbTab.UseVisualStyleBackColor = true;
            // 
            // rbComma
            // 
            resources.ApplyResources(this.rbComma, "rbComma");
            this.rbComma.Name = "rbComma";
            this.rbComma.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtUnknown);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.btnMojiChk);
            this.groupBox4.Controls.Add(this.txtLogFolder);
            this.groupBox4.Controls.Add(this.btnOpenLogFolder);
            this.groupBox4.Controls.Add(this.label12);
            resources.ApplyResources(this.groupBox4, "groupBox4");
            this.groupBox4.ForeColor = System.Drawing.Color.White;
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.TabStop = false;
            // 
            // txtUnknown
            // 
            resources.ApplyResources(this.txtUnknown, "txtUnknown");
            this.txtUnknown.Name = "txtUnknown";
            // 
            // label13
            // 
            resources.ApplyResources(this.label13, "label13");
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Name = "label13";
            // 
            // btnMojiChk
            // 
            resources.ApplyResources(this.btnMojiChk, "btnMojiChk");
            this.btnMojiChk.Name = "btnMojiChk";
            this.btnMojiChk.UseVisualStyleBackColor = true;
            // 
            // txtLogFolder
            // 
            this.txtLogFolder.AllowDrop = true;
            resources.ApplyResources(this.txtLogFolder, "txtLogFolder");
            this.txtLogFolder.Name = "txtLogFolder";
            this.txtLogFolder.ReadOnly = true;
            this.txtLogFolder.DragDrop += new System.Windows.Forms.DragEventHandler(this.TextBox_DragDrop);
            this.txtLogFolder.DragEnter += new System.Windows.Forms.DragEventHandler(this.TextBox_DragEnter);
            // 
            // btnOpenLogFolder
            // 
            resources.ApplyResources(this.btnOpenLogFolder, "btnOpenLogFolder");
            this.btnOpenLogFolder.Name = "btnOpenLogFolder";
            this.btnOpenLogFolder.UseVisualStyleBackColor = true;
            this.btnOpenLogFolder.Click += new System.EventHandler(this.btnFolderOpen_Click);
            // 
            // label12
            // 
            resources.ApplyResources(this.label12, "label12");
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Name = "label12";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnRegister);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // c1StatusBar1
            // 
            this.c1StatusBar1.AutoSizeElement = C1.Framework.AutoSizeElement.Width;
            this.c1StatusBar1.LeftPaneItems.Add(this.ProgressBar);
            this.c1StatusBar1.LeftPaneItems.Add(this.lblProgress);
            this.c1StatusBar1.Location = new System.Drawing.Point(0, 548);
            this.c1StatusBar1.Name = "c1StatusBar1";
            this.c1StatusBar1.RightPaneItems.Add(this.btnBackMenu);
            this.c1StatusBar1.Size = new System.Drawing.Size(792, 23);
            // 
            // ProgressBar
            // 
            this.ProgressBar.Name = "ProgressBar";
            resources.ApplyResources(this.ProgressBar, "ProgressBar");
            // 
            // lblProgress
            // 
            this.lblProgress.Name = "lblProgress";
            resources.ApplyResources(this.lblProgress, "lblProgress");
            // 
            // btnBackMenu
            // 
            this.btnBackMenu.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnBackMenu.LargeImage")));
            this.btnBackMenu.Name = "btnBackMenu";
            this.btnBackMenu.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnBackMenu.SmallImage")));
            resources.ApplyResources(this.btnBackMenu, "btnBackMenu");
            this.btnBackMenu.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // frmJobEdit
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.c1StatusBar1);
            this.Name = "frmJobEdit";
            this.VisualStyleHolder = C1.Win.C1Ribbon.VisualStyle.Office2007Black;
            this.Load += new System.EventHandler(this.frmJobEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btnRegister)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fgrColSetting)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbJoinchar)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnOpenImageFolder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbMojicode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOpenShioriFolder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbExtension)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnLoad)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnMojiChk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOpenLogFolder)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c1StatusBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtEndUser;
        private C1.Win.C1Input.C1Button btnRegister;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtJobName;
        private System.Windows.Forms.TextBox txtAnkenName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSakuban;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox chkHeader;
        private System.Windows.Forms.RadioButton rbTab;
        private System.Windows.Forms.RadioButton rbComma;
        private C1.Win.C1Input.C1Button btnLoad;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private C1.Win.C1Input.C1Button btnOpenShioriFolder;
        private System.Windows.Forms.TextBox txtShioriFile;
        private C1.Win.C1Input.C1Button btnOpenImageFolder;
        private System.Windows.Forms.TextBox txtImageFolder;
        private C1.Win.C1Input.C1ComboBox cmbExtension;
        private System.Windows.Forms.TextBox txtLogFolder;
        private C1.Win.C1Input.C1Button btnOpenLogFolder;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private C1.Win.C1Input.C1ComboBox cmbMojicode;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private C1.Win.C1Input.C1Button btnMojiChk;
        private System.Windows.Forms.TextBox txtUnknown;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private C1.Win.C1Ribbon.C1StatusBar c1StatusBar1;
        private C1.Win.C1Ribbon.RibbonButton btnBackMenu;
        private C1.Win.C1Ribbon.RibbonProgressBar ProgressBar;
        private C1.Win.C1Ribbon.RibbonLabel lblProgress;
        private System.Windows.Forms.GroupBox groupBox3;
        private C1.Win.C1FlexGrid.C1FlexGrid fgrColSetting;
        private System.Windows.Forms.Panel panel2;
        private C1.Win.C1Input.C1ComboBox cmbJoinchar;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel3;
    }
}

