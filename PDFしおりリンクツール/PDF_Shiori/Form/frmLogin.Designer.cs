namespace PDF_Shiori
{
    partial class frmLogin
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.txtPassword = new System.Windows.Forms.TextBox();
			this.btnCancel = new C1.Win.C1Input.C1Button();
			this.btnLogin = new C1.Win.C1Input.C1Button();
			this.label3 = new System.Windows.Forms.Label();
			this.cmbSection = new C1.Win.C1List.C1Combo();
			this.cmbUserName = new C1.Win.C1List.C1Combo();
			((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.btnLogin)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbSection)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbUserName)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			resources.ApplyResources(this.label1, "label1");
			this.label1.ForeColor = System.Drawing.Color.White;
			this.label1.Name = "label1";
			// 
			// label2
			// 
			resources.ApplyResources(this.label2, "label2");
			this.label2.ForeColor = System.Drawing.Color.White;
			this.label2.Name = "label2";
			// 
			// txtPassword
			// 
			this.txtPassword.BackColor = System.Drawing.SystemColors.Info;
			resources.ApplyResources(this.txtPassword, "txtPassword");
			this.txtPassword.Name = "txtPassword";
			this.txtPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPassword_KeyDown);
			// 
			// btnCancel
			// 
			resources.ApplyResources(this.btnCancel, "btnCancel");
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnLogin
			// 
			resources.ApplyResources(this.btnLogin, "btnLogin");
			this.btnLogin.Name = "btnLogin";
			this.btnLogin.UseVisualStyleBackColor = true;
			this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
			// 
			// label3
			// 
			resources.ApplyResources(this.label3, "label3");
			this.label3.ForeColor = System.Drawing.Color.White;
			this.label3.Name = "label3";
			// 
			// cmbSection
			// 
			this.cmbSection.AddItemSeparator = ';';
			this.cmbSection.AllowColSelect = true;
			resources.ApplyResources(this.cmbSection, "cmbSection");
			this.cmbSection.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
			this.cmbSection.ComboStyle = C1.Win.C1List.ComboStyleEnum.DropdownList;
			this.cmbSection.DeadAreaBackColor = System.Drawing.Color.Empty;
			this.cmbSection.EditorBackColor = System.Drawing.SystemColors.Window;
			this.cmbSection.EditorFont = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.cmbSection.EditorForeColor = System.Drawing.SystemColors.WindowText;
			this.cmbSection.Images.Add(((System.Drawing.Image)(resources.GetObject("cmbSection.Images"))));
			this.cmbSection.MatchEntryTimeout = ((long)(2000));
			this.cmbSection.MaxDropDownItems = ((short)(5));
			this.cmbSection.MaxLength = 32767;
			this.cmbSection.MouseCursor = System.Windows.Forms.Cursors.Default;
			this.cmbSection.Name = "cmbSection";
			this.cmbSection.PropBag = resources.GetString("cmbSection.PropBag");
			this.cmbSection.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
			this.cmbSection.RowSubDividerColor = System.Drawing.Color.DarkGray;
			this.cmbSection.SelectedValueChanged += new System.EventHandler(this.cmbSection_SelectedValueChanged);
			// 
			// cmbUserName
			// 
			this.cmbUserName.AddItemSeparator = ';';
			resources.ApplyResources(this.cmbUserName, "cmbUserName");
			this.cmbUserName.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
			this.cmbUserName.ComboStyle = C1.Win.C1List.ComboStyleEnum.DropdownList;
			this.cmbUserName.DeadAreaBackColor = System.Drawing.Color.Empty;
			this.cmbUserName.EditorBackColor = System.Drawing.SystemColors.Window;
			this.cmbUserName.EditorFont = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.cmbUserName.EditorForeColor = System.Drawing.SystemColors.WindowText;
			this.cmbUserName.MatchEntryTimeout = ((long)(2000));
			this.cmbUserName.MaxDropDownItems = ((short)(5));
			this.cmbUserName.MaxLength = 32767;
			this.cmbUserName.MouseCursor = System.Windows.Forms.Cursors.Default;
			this.cmbUserName.Name = "cmbUserName";
			this.cmbUserName.PropBag = resources.GetString("cmbUserName.PropBag");
			this.cmbUserName.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
			this.cmbUserName.RowSubDividerColor = System.Drawing.Color.DarkGray;
			// 
			// frmLogin
			// 
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ControlBox = false;
			this.Controls.Add(this.cmbUserName);
			this.Controls.Add(this.cmbSection);
			this.Controls.Add(this.btnLogin);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.txtPassword);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label1);
			this.Name = "frmLogin";
			this.VisualStyleHolder = C1.Win.C1Ribbon.VisualStyle.Office2007Black;
			this.Load += new System.EventHandler(this.frmLogin_Load);
			((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.btnLogin)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbSection)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbUserName)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPassword;
        private C1.Win.C1Input.C1Button btnCancel;
        private C1.Win.C1Input.C1Button btnLogin;
        private System.Windows.Forms.Label label3;
        private C1.Win.C1List.C1Combo cmbSection;
        private C1.Win.C1List.C1Combo cmbUserName;
	}
}

