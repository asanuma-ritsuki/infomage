namespace NDLImperialLibrary
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
			this.btnManageData = new System.Windows.Forms.Button();
			this.txtOutputFolder = new System.Windows.Forms.TextBox();
			this.btnMetaData = new System.Windows.Forms.Button();
			this.txtImageFolder = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// btnManageData
			// 
			this.btnManageData.Location = new System.Drawing.Point(12, 12);
			this.btnManageData.Name = "btnManageData";
			this.btnManageData.Size = new System.Drawing.Size(100, 25);
			this.btnManageData.TabIndex = 4;
			this.btnManageData.Text = "管理データ作成";
			this.btnManageData.UseVisualStyleBackColor = true;
			this.btnManageData.Click += new System.EventHandler(this.btnManageData_Click);
			// 
			// txtOutputFolder
			// 
			this.txtOutputFolder.Location = new System.Drawing.Point(118, 126);
			this.txtOutputFolder.Name = "txtOutputFolder";
			this.txtOutputFolder.Size = new System.Drawing.Size(654, 24);
			this.txtOutputFolder.TabIndex = 5;
			this.txtOutputFolder.Text = "C:\\開発\\NDL帝国図書館文書\\temp\\";
			// 
			// btnMetaData
			// 
			this.btnMetaData.Location = new System.Drawing.Point(12, 43);
			this.btnMetaData.Name = "btnMetaData";
			this.btnMetaData.Size = new System.Drawing.Size(100, 25);
			this.btnMetaData.TabIndex = 6;
			this.btnMetaData.Text = "メタデータ作成";
			this.btnMetaData.UseVisualStyleBackColor = true;
			this.btnMetaData.Click += new System.EventHandler(this.btnMetaData_Click);
			// 
			// txtImageFolder
			// 
			this.txtImageFolder.Location = new System.Drawing.Point(118, 96);
			this.txtImageFolder.Name = "txtImageFolder";
			this.txtImageFolder.Size = new System.Drawing.Size(654, 24);
			this.txtImageFolder.TabIndex = 7;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(27, 99);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(85, 17);
			this.label1.TabIndex = 8;
			this.label1.Text = "画像フォルダ：";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(27, 129);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(85, 17);
			this.label2.TabIndex = 9;
			this.label2.Text = "出力フォルダ：";
			// 
			// Form1
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.ClientSize = new System.Drawing.Size(784, 561);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtImageFolder);
			this.Controls.Add(this.btnMetaData);
			this.Controls.Add(this.txtOutputFolder);
			this.Controls.Add(this.btnManageData);
			this.Font = new System.Drawing.Font("Meiryo UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnManageData;
		private System.Windows.Forms.TextBox txtOutputFolder;
		private System.Windows.Forms.Button btnMetaData;
		private System.Windows.Forms.TextBox txtImageFolder;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
	}
}

