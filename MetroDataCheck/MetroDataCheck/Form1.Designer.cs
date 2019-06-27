namespace MetroDataCheck
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
			this.btnStart = new System.Windows.Forms.Button();
			this.btnStart02 = new System.Windows.Forms.Button();
			this.btnImport = new System.Windows.Forms.Button();
			this.txtImport = new System.Windows.Forms.TextBox();
			this.btnFileName = new System.Windows.Forms.Button();
			this.btnEda = new System.Windows.Forms.Button();
			this.btnKouji = new System.Windows.Forms.Button();
			this.txtOutPath = new System.Windows.Forms.TextBox();
			this.btnFileName02 = new System.Windows.Forms.Button();
			this.btnExist = new System.Windows.Forms.Button();
			this.txtDrive = new System.Windows.Forms.TextBox();
			this.btnPickup = new System.Windows.Forms.Button();
			this.btnCSVParser = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btnStart
			// 
			this.btnStart.Location = new System.Drawing.Point(12, 79);
			this.btnStart.Name = "btnStart";
			this.btnStart.Size = new System.Drawing.Size(100, 25);
			this.btnStart.TabIndex = 1;
			this.btnStart.Text = "グルーピング";
			this.btnStart.UseVisualStyleBackColor = true;
			this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
			// 
			// btnStart02
			// 
			this.btnStart02.Location = new System.Drawing.Point(12, 110);
			this.btnStart02.Name = "btnStart02";
			this.btnStart02.Size = new System.Drawing.Size(100, 25);
			this.btnStart02.TabIndex = 2;
			this.btnStart02.Text = "連番付与";
			this.btnStart02.UseVisualStyleBackColor = true;
			this.btnStart02.Click += new System.EventHandler(this.btnStart02_Click);
			// 
			// btnImport
			// 
			this.btnImport.Location = new System.Drawing.Point(12, 12);
			this.btnImport.Name = "btnImport";
			this.btnImport.Size = new System.Drawing.Size(100, 25);
			this.btnImport.TabIndex = 3;
			this.btnImport.Text = "インポート";
			this.btnImport.UseVisualStyleBackColor = true;
			this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
			// 
			// txtImport
			// 
			this.txtImport.Location = new System.Drawing.Point(118, 13);
			this.txtImport.Name = "txtImport";
			this.txtImport.Size = new System.Drawing.Size(654, 24);
			this.txtImport.TabIndex = 4;
			this.txtImport.Text = "C:\\開発\\20190207_警視庁データ精査\\20190207_種別特定(DataEditor使用)\\20190227\\03_インポートデータ.txt";
			// 
			// btnFileName
			// 
			this.btnFileName.Location = new System.Drawing.Point(12, 141);
			this.btnFileName.Name = "btnFileName";
			this.btnFileName.Size = new System.Drawing.Size(100, 25);
			this.btnFileName.TabIndex = 5;
			this.btnFileName.Text = "フォルダ名特定";
			this.btnFileName.UseVisualStyleBackColor = true;
			this.btnFileName.Click += new System.EventHandler(this.btnFileName_Click);
			// 
			// btnEda
			// 
			this.btnEda.Location = new System.Drawing.Point(12, 213);
			this.btnEda.Name = "btnEda";
			this.btnEda.Size = new System.Drawing.Size(100, 25);
			this.btnEda.TabIndex = 6;
			this.btnEda.Text = "枝番付与";
			this.btnEda.UseVisualStyleBackColor = true;
			this.btnEda.Click += new System.EventHandler(this.btnEda_Click);
			// 
			// btnKouji
			// 
			this.btnKouji.Location = new System.Drawing.Point(12, 48);
			this.btnKouji.Name = "btnKouji";
			this.btnKouji.Size = new System.Drawing.Size(100, 25);
			this.btnKouji.TabIndex = 7;
			this.btnKouji.Text = "工事件名特定";
			this.btnKouji.UseVisualStyleBackColor = true;
			this.btnKouji.Click += new System.EventHandler(this.btnKouji_Click);
			// 
			// txtOutPath
			// 
			this.txtOutPath.Location = new System.Drawing.Point(118, 245);
			this.txtOutPath.Name = "txtOutPath";
			this.txtOutPath.Size = new System.Drawing.Size(654, 24);
			this.txtOutPath.TabIndex = 8;
			this.txtOutPath.Text = "C:\\tmp\\output";
			// 
			// btnFileName02
			// 
			this.btnFileName02.Location = new System.Drawing.Point(12, 172);
			this.btnFileName02.Name = "btnFileName02";
			this.btnFileName02.Size = new System.Drawing.Size(100, 25);
			this.btnFileName02.TabIndex = 9;
			this.btnFileName02.Text = "ファイル名特定";
			this.btnFileName02.UseVisualStyleBackColor = true;
			this.btnFileName02.Click += new System.EventHandler(this.btnFileName02_Click);
			// 
			// btnExist
			// 
			this.btnExist.Location = new System.Drawing.Point(12, 244);
			this.btnExist.Name = "btnExist";
			this.btnExist.Size = new System.Drawing.Size(100, 25);
			this.btnExist.TabIndex = 10;
			this.btnExist.Text = "存在チェック";
			this.btnExist.UseVisualStyleBackColor = true;
			this.btnExist.Click += new System.EventHandler(this.btnExist_Click);
			// 
			// txtDrive
			// 
			this.txtDrive.Location = new System.Drawing.Point(118, 214);
			this.txtDrive.Name = "txtDrive";
			this.txtDrive.Size = new System.Drawing.Size(131, 24);
			this.txtDrive.TabIndex = 11;
			this.txtDrive.Text = "E:\\";
			// 
			// btnPickup
			// 
			this.btnPickup.Location = new System.Drawing.Point(12, 301);
			this.btnPickup.Name = "btnPickup";
			this.btnPickup.Size = new System.Drawing.Size(100, 25);
			this.btnPickup.TabIndex = 12;
			this.btnPickup.Text = "抽出";
			this.btnPickup.UseVisualStyleBackColor = true;
			this.btnPickup.Click += new System.EventHandler(this.btnPickup_Click);
			// 
			// btnCSVParser
			// 
			this.btnCSVParser.Location = new System.Drawing.Point(12, 332);
			this.btnCSVParser.Name = "btnCSVParser";
			this.btnCSVParser.Size = new System.Drawing.Size(100, 25);
			this.btnCSVParser.TabIndex = 13;
			this.btnCSVParser.Text = "CSVParser";
			this.btnCSVParser.UseVisualStyleBackColor = true;
			this.btnCSVParser.Click += new System.EventHandler(this.btnCSVParser_Click);
			// 
			// Form1
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.ClientSize = new System.Drawing.Size(784, 561);
			this.Controls.Add(this.btnCSVParser);
			this.Controls.Add(this.btnPickup);
			this.Controls.Add(this.txtDrive);
			this.Controls.Add(this.btnExist);
			this.Controls.Add(this.btnFileName02);
			this.Controls.Add(this.txtOutPath);
			this.Controls.Add(this.btnKouji);
			this.Controls.Add(this.btnEda);
			this.Controls.Add(this.btnFileName);
			this.Controls.Add(this.txtImport);
			this.Controls.Add(this.btnImport);
			this.Controls.Add(this.btnStart02);
			this.Controls.Add(this.btnStart);
			this.Font = new System.Drawing.Font("Meiryo UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Button btnStart;
		private System.Windows.Forms.Button btnStart02;
		private System.Windows.Forms.Button btnImport;
		private System.Windows.Forms.TextBox txtImport;
		private System.Windows.Forms.Button btnFileName;
		private System.Windows.Forms.Button btnEda;
		private System.Windows.Forms.Button btnKouji;
		private System.Windows.Forms.TextBox txtOutPath;
		private System.Windows.Forms.Button btnFileName02;
		private System.Windows.Forms.Button btnExist;
		private System.Windows.Forms.TextBox txtDrive;
		private System.Windows.Forms.Button btnPickup;
		private System.Windows.Forms.Button btnCSVParser;
	}
}

