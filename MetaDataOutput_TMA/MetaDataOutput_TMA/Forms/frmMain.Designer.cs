namespace MetaDataOutput_TMA.Forms
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtInputData = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtTableData = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnCheck = new System.Windows.Forms.Button();
            this.btnOutput = new System.Windows.Forms.Button();
            this.txtOutputFolder = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbImageClass = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtLinkClass = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtMediaClass = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtShootTarget = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtShootYear = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtHDDNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtImageFolder = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lstResult = new System.Windows.Forms.ListBox();
            this.btnReRun = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnReRun);
            this.groupBox1.Controls.Add(this.txtInputData);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.txtTableData);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.btnCheck);
            this.groupBox1.Controls.Add(this.btnOutput);
            this.groupBox1.Controls.Add(this.txtOutputFolder);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cmbImageClass);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtLinkClass);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtMediaClass);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtShootTarget);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtShootYear);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtHDDNo);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtImageFolder);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(784, 240);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "インポート情報";
            // 
            // txtInputData
            // 
            this.txtInputData.AllowDrop = true;
            this.txtInputData.Location = new System.Drawing.Point(118, 83);
            this.txtInputData.Name = "txtInputData";
            this.txtInputData.Size = new System.Drawing.Size(654, 24);
            this.txtInputData.TabIndex = 5;
            this.txtInputData.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtFile_DragDrop);
            this.txtInputData.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtFile_DragEnter);
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(12, 82);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(100, 24);
            this.label12.TabIndex = 4;
            this.label12.Text = "入力データ：";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTableData
            // 
            this.txtTableData.AllowDrop = true;
            this.txtTableData.Location = new System.Drawing.Point(118, 53);
            this.txtTableData.Name = "txtTableData";
            this.txtTableData.Size = new System.Drawing.Size(654, 24);
            this.txtTableData.TabIndex = 3;
            this.txtTableData.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtFile_DragDrop);
            this.txtTableData.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtFile_DragEnter);
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(12, 52);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(100, 24);
            this.label11.TabIndex = 2;
            this.label11.Text = "テーブルデータ：";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnCheck
            // 
            this.btnCheck.Location = new System.Drawing.Point(616, 207);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(75, 25);
            this.btnCheck.TabIndex = 22;
            this.btnCheck.Text = "チェック";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // btnOutput
            // 
            this.btnOutput.Location = new System.Drawing.Point(697, 207);
            this.btnOutput.Name = "btnOutput";
            this.btnOutput.Size = new System.Drawing.Size(75, 25);
            this.btnOutput.TabIndex = 23;
            this.btnOutput.Text = "出　力";
            this.btnOutput.UseVisualStyleBackColor = true;
            this.btnOutput.Click += new System.EventHandler(this.btnOutput_Click);
            // 
            // txtOutputFolder
            // 
            this.txtOutputFolder.AllowDrop = true;
            this.txtOutputFolder.Location = new System.Drawing.Point(118, 113);
            this.txtOutputFolder.Name = "txtOutputFolder";
            this.txtOutputFolder.Size = new System.Drawing.Size(654, 24);
            this.txtOutputFolder.TabIndex = 7;
            this.txtOutputFolder.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtFolder_DragDrop);
            this.txtOutputFolder.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtFolder_DragEnter);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(12, 112);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 24);
            this.label5.TabIndex = 6;
            this.label5.Text = "出力フォルダ：";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbImageClass
            // 
            this.cmbImageClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbImageClass.FormattingEnabled = true;
            this.cmbImageClass.Items.AddRange(new object[] {
            "TIFF",
            "JPEG"});
            this.cmbImageClass.Location = new System.Drawing.Point(422, 203);
            this.cmbImageClass.Name = "cmbImageClass";
            this.cmbImageClass.Size = new System.Drawing.Size(121, 25);
            this.cmbImageClass.TabIndex = 21;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(316, 203);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(100, 24);
            this.label10.TabIndex = 20;
            this.label10.Text = "画像種別：";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(618, 173);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(154, 24);
            this.label9.TabIndex = 19;
            this.label9.Text = "※例：collection_01";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(618, 143);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(154, 24);
            this.label8.TabIndex = 18;
            this.label8.Text = "※例：media_02";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtLinkClass
            // 
            this.txtLinkClass.Location = new System.Drawing.Point(422, 173);
            this.txtLinkClass.Name = "txtLinkClass";
            this.txtLinkClass.Size = new System.Drawing.Size(190, 24);
            this.txtLinkClass.TabIndex = 17;
            this.txtLinkClass.Text = "collection_01";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(316, 172);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 24);
            this.label7.TabIndex = 16;
            this.label7.Text = "リンク先分類：";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtMediaClass
            // 
            this.txtMediaClass.Location = new System.Drawing.Point(422, 143);
            this.txtMediaClass.Name = "txtMediaClass";
            this.txtMediaClass.Size = new System.Drawing.Size(190, 24);
            this.txtMediaClass.TabIndex = 15;
            this.txtMediaClass.Text = "media_02";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(316, 142);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 24);
            this.label6.TabIndex = 14;
            this.label6.Text = "分類：";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtShootTarget
            // 
            this.txtShootTarget.Location = new System.Drawing.Point(118, 203);
            this.txtShootTarget.Name = "txtShootTarget";
            this.txtShootTarget.Size = new System.Drawing.Size(190, 24);
            this.txtShootTarget.TabIndex = 13;
            this.txtShootTarget.Text = "江戸町方史料一覧";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(12, 202);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 24);
            this.label4.TabIndex = 12;
            this.label4.Text = "備考：";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtShootYear
            // 
            this.txtShootYear.Location = new System.Drawing.Point(118, 173);
            this.txtShootYear.Name = "txtShootYear";
            this.txtShootYear.Size = new System.Drawing.Size(190, 24);
            this.txtShootYear.TabIndex = 11;
            this.txtShootYear.Text = "2018";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(12, 172);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 24);
            this.label3.TabIndex = 10;
            this.label3.Text = "撮影年：";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtHDDNo
            // 
            this.txtHDDNo.Location = new System.Drawing.Point(118, 143);
            this.txtHDDNo.Name = "txtHDDNo";
            this.txtHDDNo.Size = new System.Drawing.Size(190, 24);
            this.txtHDDNo.TabIndex = 9;
            this.txtHDDNo.Text = "H2018-02";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(12, 142);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 24);
            this.label2.TabIndex = 8;
            this.label2.Text = "HDD番号：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtImageFolder
            // 
            this.txtImageFolder.AllowDrop = true;
            this.txtImageFolder.Location = new System.Drawing.Point(118, 23);
            this.txtImageFolder.Name = "txtImageFolder";
            this.txtImageFolder.Size = new System.Drawing.Size(654, 24);
            this.txtImageFolder.TabIndex = 1;
            this.txtImageFolder.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtFolder_DragDrop);
            this.txtImageFolder.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtFolder_DragEnter);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "画像フォルダ：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lstResult);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 240);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(784, 321);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "進捗状況";
            // 
            // lstResult
            // 
            this.lstResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstResult.FormattingEnabled = true;
            this.lstResult.ItemHeight = 17;
            this.lstResult.Location = new System.Drawing.Point(3, 20);
            this.lstResult.Name = "lstResult";
            this.lstResult.Size = new System.Drawing.Size(778, 298);
            this.lstResult.TabIndex = 0;
            // 
            // btnReRun
            // 
            this.btnReRun.Location = new System.Drawing.Point(549, 207);
            this.btnReRun.Name = "btnReRun";
            this.btnReRun.Size = new System.Drawing.Size(63, 25);
            this.btnReRun.TabIndex = 24;
            this.btnReRun.Text = "再作成";
            this.btnReRun.UseVisualStyleBackColor = true;
            this.btnReRun.Click += new System.EventHandler(this.btnReRun_Click);
            // 
            // frmMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Meiryo UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmMain";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button btnCheck;
		private System.Windows.Forms.Button btnOutput;
		private System.Windows.Forms.TextBox txtOutputFolder;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ComboBox cmbImageClass;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox txtLinkClass;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox txtMediaClass;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox txtShootTarget;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtShootYear;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtHDDNo;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtImageFolder;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.ListBox lstResult;
		private System.Windows.Forms.TextBox txtInputData;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.TextBox txtTableData;
		private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnReRun;
    }
}