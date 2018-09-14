namespace PDF_Shiori
{
    partial class frmOutput
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOutput));
            this.label4 = new System.Windows.Forms.Label();
            this.fgrResult = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.c1StatusBar1 = new C1.Win.C1Ribbon.C1StatusBar();
            this.ProgressBar = new C1.Win.C1Ribbon.RibbonProgressBar();
            this.txtProgressBar = new C1.Win.C1Ribbon.RibbonLabel();
            this.btnBackMenu = new C1.Win.C1Ribbon.RibbonButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtSakuban = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.txtEndUser = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtJobName = new System.Windows.Forms.TextBox();
            this.txtAnkenName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtOutputFolder = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cmbMojiCode = new System.Windows.Forms.ComboBox();
            this.cmbPDFOpenSetting = new System.Windows.Forms.ComboBox();
            this.rbPDF = new System.Windows.Forms.RadioButton();
            this.rbText = new System.Windows.Forms.RadioButton();
            this.btnOpenFolder = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancel = new C1.Win.C1Input.C1Button();
            this.btnStart = new C1.Win.C1Input.C1Button();
            ((System.ComponentModel.ISupportInitialize)(this.fgrResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1StatusBar1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnStart)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Name = "label4";
            // 
            // fgrResult
            // 
            this.fgrResult.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.fgrResult, "fgrResult");
            this.fgrResult.Name = "fgrResult";
            this.fgrResult.Rows.Count = 1;
            this.fgrResult.Rows.DefaultSize = 18;
            this.fgrResult.StyleInfo = resources.GetString("fgrResult.StyleInfo");
            // 
            // c1StatusBar1
            // 
            this.c1StatusBar1.AutoSizeElement = C1.Framework.AutoSizeElement.Width;
            this.c1StatusBar1.LeftPaneItems.Add(this.ProgressBar);
            this.c1StatusBar1.LeftPaneItems.Add(this.txtProgressBar);
            this.c1StatusBar1.Location = new System.Drawing.Point(0, 748);
            this.c1StatusBar1.Name = "c1StatusBar1";
            this.c1StatusBar1.RightPaneItems.Add(this.btnBackMenu);
            this.c1StatusBar1.Size = new System.Drawing.Size(792, 23);
            // 
            // ProgressBar
            // 
            this.ProgressBar.Name = "ProgressBar";
            resources.ApplyResources(this.ProgressBar, "ProgressBar");
            // 
            // txtProgressBar
            // 
            this.txtProgressBar.Name = "txtProgressBar";
            resources.ApplyResources(this.txtProgressBar, "txtProgressBar");
            // 
            // btnBackMenu
            // 
            this.btnBackMenu.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnBackMenu.LargeImage")));
            this.btnBackMenu.Name = "btnBackMenu";
            this.btnBackMenu.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnBackMenu.SmallImage")));
            resources.ApplyResources(this.btnBackMenu, "btnBackMenu");
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtSakuban);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Controls.Add(this.txtJobName);
            this.groupBox1.Controls.Add(this.txtAnkenName);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // txtSakuban
            // 
            this.txtSakuban.BackColor = System.Drawing.SystemColors.ControlDark;
            resources.ApplyResources(this.txtSakuban, "txtSakuban");
            this.txtSakuban.Name = "txtSakuban";
            this.txtSakuban.ReadOnly = true;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Name = "label1";
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
            // txtJobName
            // 
            resources.ApplyResources(this.txtJobName, "txtJobName");
            this.txtJobName.BackColor = System.Drawing.SystemColors.ControlDark;
            this.txtJobName.Name = "txtJobName";
            this.txtJobName.ReadOnly = true;
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
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.fgrResult);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // txtOutputFolder
            // 
            this.txtOutputFolder.AllowDrop = true;
            resources.ApplyResources(this.txtOutputFolder, "txtOutputFolder");
            this.txtOutputFolder.Name = "txtOutputFolder";
            this.txtOutputFolder.DragDrop += new System.Windows.Forms.DragEventHandler(this.TextBox_DragDrop);
            this.txtOutputFolder.DragEnter += new System.Windows.Forms.DragEventHandler(this.TextBox_DragEnter);
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Name = "label6";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cmbMojiCode);
            this.groupBox3.Controls.Add(this.cmbPDFOpenSetting);
            this.groupBox3.Controls.Add(this.rbPDF);
            this.groupBox3.Controls.Add(this.rbText);
            this.groupBox3.Controls.Add(this.btnOpenFolder);
            this.groupBox3.Controls.Add(this.txtOutputFolder);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label6);
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.ForeColor = System.Drawing.Color.White;
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            // 
            // cmbMojiCode
            // 
            this.cmbMojiCode.FormattingEnabled = true;
            resources.ApplyResources(this.cmbMojiCode, "cmbMojiCode");
            this.cmbMojiCode.Name = "cmbMojiCode";
            // 
            // cmbPDFOpenSetting
            // 
            this.cmbPDFOpenSetting.FormattingEnabled = true;
            resources.ApplyResources(this.cmbPDFOpenSetting, "cmbPDFOpenSetting");
            this.cmbPDFOpenSetting.Name = "cmbPDFOpenSetting";
            // 
            // rbPDF
            // 
            resources.ApplyResources(this.rbPDF, "rbPDF");
            this.rbPDF.Checked = true;
            this.rbPDF.Name = "rbPDF";
            this.rbPDF.TabStop = true;
            this.rbPDF.UseVisualStyleBackColor = true;
            this.rbPDF.CheckedChanged += new System.EventHandler(this.rbPDF_CheckedChanged);
            // 
            // rbText
            // 
            resources.ApplyResources(this.rbText, "rbText");
            this.rbText.Name = "rbText";
            this.rbText.UseVisualStyleBackColor = true;
            // 
            // btnOpenFolder
            // 
            resources.ApplyResources(this.btnOpenFolder, "btnOpenFolder");
            this.btnOpenFolder.ForeColor = System.Drawing.Color.Black;
            this.btnOpenFolder.Name = "btnOpenFolder";
            this.btnOpenFolder.UseVisualStyleBackColor = true;
            this.btnOpenFolder.Click += new System.EventHandler(this.btnOpenFolder_Click);
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Name = "label9";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Name = "label8";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Name = "label7";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnStart);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Black;
            // 
            // btnStart
            // 
            resources.ApplyResources(this.btnStart, "btnStart");
            this.btnStart.Name = "btnStart";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Black;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // frmOutput
            // 
            this.AllowDrop = true;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.c1StatusBar1);
            this.Name = "frmOutput";
            this.VisualStyleHolder = C1.Win.C1Ribbon.VisualStyle.Office2007Black;
            this.Load += new System.EventHandler(this.frmOutput_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fgrResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1StatusBar1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnStart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label4;
        private C1.Win.C1FlexGrid.C1FlexGrid fgrResult;
        private C1.Win.C1Ribbon.C1StatusBar c1StatusBar1;
        private C1.Win.C1Ribbon.RibbonButton btnBackMenu;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtSakuban;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.TextBox txtEndUser;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtAnkenName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtJobName;
        private System.Windows.Forms.TextBox txtOutputFolder;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnOpenFolder;
        private System.Windows.Forms.RadioButton rbPDF;
        private System.Windows.Forms.RadioButton rbText;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbPDFOpenSetting;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbMojiCode;
        private System.Windows.Forms.Label label9;
        private C1.Win.C1Ribbon.RibbonProgressBar ProgressBar;
        private C1.Win.C1Ribbon.RibbonLabel txtProgressBar;
        private System.Windows.Forms.Panel panel1;
        private C1.Win.C1Input.C1Button btnCancel;
        private C1.Win.C1Input.C1Button btnStart;
    }
}

