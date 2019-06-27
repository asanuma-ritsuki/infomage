namespace CreateDateCheckTool
{
	partial class Form1
	{
		/// <summary>
		/// 必要なデザイナー変数です。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 使用中のリソースをすべてクリーンアップします。
		/// </summary>
		/// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
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
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btnStart = new System.Windows.Forms.Button();
			this.txtLogFolder = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtTargetFolder = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.lstResult = new System.Windows.Forms.ListBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.btnStart);
			this.groupBox1.Controls.Add(this.txtLogFolder);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.txtTargetFolder);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(784, 144);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "設定";
			// 
			// btnStart
			// 
			this.btnStart.Location = new System.Drawing.Point(697, 83);
			this.btnStart.Name = "btnStart";
			this.btnStart.Size = new System.Drawing.Size(75, 25);
			this.btnStart.TabIndex = 4;
			this.btnStart.Text = "開　始";
			this.btnStart.UseVisualStyleBackColor = true;
			this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
			// 
			// txtLogFolder
			// 
			this.txtLogFolder.AllowDrop = true;
			this.txtLogFolder.Location = new System.Drawing.Point(121, 53);
			this.txtLogFolder.Name = "txtLogFolder";
			this.txtLogFolder.Size = new System.Drawing.Size(651, 24);
			this.txtLogFolder.TabIndex = 3;
			this.txtLogFolder.DragDrop += new System.Windows.Forms.DragEventHandler(this.txt_DragDrop);
			this.txtLogFolder.DragEnter += new System.Windows.Forms.DragEventHandler(this.txt_DragEnter);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(15, 52);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 24);
			this.label2.TabIndex = 2;
			this.label2.Text = "ログフォルダ：";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtTargetFolder
			// 
			this.txtTargetFolder.AllowDrop = true;
			this.txtTargetFolder.Location = new System.Drawing.Point(121, 23);
			this.txtTargetFolder.Name = "txtTargetFolder";
			this.txtTargetFolder.Size = new System.Drawing.Size(651, 24);
			this.txtTargetFolder.TabIndex = 1;
			this.txtTargetFolder.DragDrop += new System.Windows.Forms.DragEventHandler(this.txt_DragDrop);
			this.txtTargetFolder.DragEnter += new System.Windows.Forms.DragEventHandler(this.txt_DragEnter);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(15, 22);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 24);
			this.label1.TabIndex = 0;
			this.label1.Text = "対象フォルダ：";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.lstResult);
			this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox2.Location = new System.Drawing.Point(0, 144);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(784, 417);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "進捗";
			// 
			// lstResult
			// 
			this.lstResult.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lstResult.FormattingEnabled = true;
			this.lstResult.ItemHeight = 17;
			this.lstResult.Location = new System.Drawing.Point(3, 20);
			this.lstResult.Name = "lstResult";
			this.lstResult.Size = new System.Drawing.Size(778, 394);
			this.lstResult.TabIndex = 0;
			// 
			// label3
			// 
			this.label3.ForeColor = System.Drawing.Color.Red;
			this.label3.Location = new System.Drawing.Point(15, 83);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(676, 24);
			this.label3.TabIndex = 5;
			this.label3.Text = "※対象フォルダ以下の全ての階層の画像ファイル(*.jpg;*.tif;*.pdf)の作成日、更新日、最終アクセス日をチェックします。";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label4
			// 
			this.label4.ForeColor = System.Drawing.Color.Red;
			this.label4.Location = new System.Drawing.Point(15, 107);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(676, 24);
			this.label4.TabIndex = 6;
			this.label4.Text = "※未来日、及び過去1年以上前の日付を本日に上書きます。";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// Form1
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.ClientSize = new System.Drawing.Size(784, 561);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Font = new System.Drawing.Font("Meiryo UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "不正日時チェックツール";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button btnStart;
		private System.Windows.Forms.TextBox txtLogFolder;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtTargetFolder;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.ListBox lstResult;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
	}
}

