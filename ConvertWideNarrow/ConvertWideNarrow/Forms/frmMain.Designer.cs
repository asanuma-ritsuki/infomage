namespace ConvertWideNarrow.Forms
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
			this.txtSrcFolder = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.chkExt = new System.Windows.Forms.CheckedListBox();
			this.btnStart = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// txtSrcFolder
			// 
			this.txtSrcFolder.AllowDrop = true;
			this.txtSrcFolder.Location = new System.Drawing.Point(120, 12);
			this.txtSrcFolder.Name = "txtSrcFolder";
			this.txtSrcFolder.Size = new System.Drawing.Size(502, 24);
			this.txtSrcFolder.TabIndex = 4;
			this.txtSrcFolder.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtFolder_DragDrop);
			this.txtSrcFolder.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtFolder_DragEnter);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(14, 11);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 25);
			this.label1.TabIndex = 5;
			this.label1.Text = "対象フォルダ：";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(14, 42);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(100, 25);
			this.label3.TabIndex = 7;
			this.label3.Text = "対象拡張子：";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// chkExt
			// 
			this.chkExt.FormattingEnabled = true;
			this.chkExt.Items.AddRange(new object[] {
            "*.bat",
            "*.txt",
            "*.csv"});
			this.chkExt.Location = new System.Drawing.Point(120, 42);
			this.chkExt.Name = "chkExt";
			this.chkExt.Size = new System.Drawing.Size(120, 61);
			this.chkExt.TabIndex = 6;
			// 
			// btnStart
			// 
			this.btnStart.Location = new System.Drawing.Point(542, 78);
			this.btnStart.Name = "btnStart";
			this.btnStart.Size = new System.Drawing.Size(80, 25);
			this.btnStart.TabIndex = 8;
			this.btnStart.Text = "開　始";
			this.btnStart.UseVisualStyleBackColor = true;
			this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.ForeColor = System.Drawing.Color.Red;
			this.label2.Location = new System.Drawing.Point(246, 46);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(344, 17);
			this.label2.TabIndex = 9;
			this.label2.Text = "半角に置換：「０-９Ａ-Ｚａ-ｚ（）」 ⇒ 「0-9 A-Z a-z ()」";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.ForeColor = System.Drawing.Color.Red;
			this.label4.Location = new System.Drawing.Point(246, 69);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(288, 17);
			this.label4.TabIndex = 10;
			this.label4.Text = "全角に置換：「/:*?\"<>|」 ⇒ 「／：＊？”＜＞｜」";
			// 
			// frmMain
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.ClientSize = new System.Drawing.Size(634, 111);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.btnStart);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.chkExt);
			this.Controls.Add(this.txtSrcFolder);
			this.Controls.Add(this.label1);
			this.Font = new System.Drawing.Font("Meiryo UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmMain";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "frmMain";
			this.Load += new System.EventHandler(this.frmMain_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSrcFolder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckedListBox chkExt;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label4;
	}
}