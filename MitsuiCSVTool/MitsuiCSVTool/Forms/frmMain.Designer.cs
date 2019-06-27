namespace MitsuiCSVTool.Forms
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
			this.txtCSV = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.txtOutFolder = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtrename = new System.Windows.Forms.TextBox();
			this.btnRun2 = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// txtCSV
			// 
			this.txtCSV.AllowDrop = true;
			this.txtCSV.Location = new System.Drawing.Point(118, 12);
			this.txtCSV.Name = "txtCSV";
			this.txtCSV.Size = new System.Drawing.Size(518, 24);
			this.txtCSV.TabIndex = 0;
			this.txtCSV.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtCSV_DragDrop);
			this.txtCSV.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtCSV_DragEnter);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(12, 12);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 25);
			this.label1.TabIndex = 2;
			this.label1.Text = "pdf_path：";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(12, 72);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 25);
			this.label2.TabIndex = 4;
			this.label2.Text = "出力フォルダ：";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtOutFolder
			// 
			this.txtOutFolder.AllowDrop = true;
			this.txtOutFolder.Location = new System.Drawing.Point(118, 72);
			this.txtOutFolder.Name = "txtOutFolder";
			this.txtOutFolder.Size = new System.Drawing.Size(573, 24);
			this.txtOutFolder.TabIndex = 3;
			this.txtOutFolder.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtFolder_DragDrop);
			this.txtOutFolder.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtCSV_DragEnter);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(12, 42);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(100, 25);
			this.label3.TabIndex = 7;
			this.label3.Text = "rename：";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtrename
			// 
			this.txtrename.AllowDrop = true;
			this.txtrename.Location = new System.Drawing.Point(118, 42);
			this.txtrename.Name = "txtrename";
			this.txtrename.Size = new System.Drawing.Size(518, 24);
			this.txtrename.TabIndex = 6;
			this.txtrename.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtCSV_DragDrop);
			this.txtrename.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtCSV_DragEnter);
			// 
			// btnRun2
			// 
			this.btnRun2.Location = new System.Drawing.Point(616, 102);
			this.btnRun2.Name = "btnRun2";
			this.btnRun2.Size = new System.Drawing.Size(75, 25);
			this.btnRun2.TabIndex = 8;
			this.btnRun2.Text = "開　始";
			this.btnRun2.UseVisualStyleBackColor = true;
			this.btnRun2.Click += new System.EventHandler(this.btnRun2_Click);
			// 
			// label4
			// 
			this.label4.ForeColor = System.Drawing.Color.Red;
			this.label4.Location = new System.Drawing.Point(643, 11);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(48, 25);
			this.label4.TabIndex = 9;
			this.label4.Text = "8項目";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label5
			// 
			this.label5.ForeColor = System.Drawing.Color.Red;
			this.label5.Location = new System.Drawing.Point(642, 41);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(48, 25);
			this.label5.TabIndex = 10;
			this.label5.Text = "7項目";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label6
			// 
			this.label6.ForeColor = System.Drawing.Color.Red;
			this.label6.Location = new System.Drawing.Point(115, 102);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(382, 25);
			this.label6.TabIndex = 11;
			this.label6.Text = "入力ファイルはヘッダなし、タブ区切りで作成してください";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// frmMain
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.ClientSize = new System.Drawing.Size(702, 136);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.btnRun2);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txtrename);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtOutFolder);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtCSV);
			this.Font = new System.Drawing.Font("Meiryo UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "frmMain";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "三井ホームツール";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txtCSV;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtOutFolder;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtrename;
        private System.Windows.Forms.Button btnRun2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
	}
}