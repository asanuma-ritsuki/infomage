namespace ImageCorruptionCheck.Forms
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
            this.txtSrcFolder = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.cpTargetColor = new C1.Win.C1Input.C1ColorPicker();
            this.label1 = new System.Windows.Forms.Label();
            this.chkExt = new System.Windows.Forms.CheckedListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtLogFolder = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbDirection = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numPixel = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lstResult = new System.Windows.Forms.ListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.numPointX = new System.Windows.Forms.NumericUpDown();
            this.numPointY = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.btnAbort = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.cpTargetColor)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPixel)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPointX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPointY)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSrcFolder
            // 
            this.txtSrcFolder.AllowDrop = true;
            this.txtSrcFolder.Location = new System.Drawing.Point(120, 23);
            this.txtSrcFolder.Name = "txtSrcFolder";
            this.txtSrcFolder.Size = new System.Drawing.Size(652, 24);
            this.txtSrcFolder.TabIndex = 0;
            this.txtSrcFolder.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtFolder_DragDrop);
            this.txtSrcFolder.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtFolder_DragEnter);
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.Location = new System.Drawing.Point(692, 105);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(80, 25);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "開　始";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // cpTargetColor
            // 
            this.cpTargetColor.AllowEmpty = false;
            this.cpTargetColor.AutoSize = false;
            this.cpTargetColor.Color = System.Drawing.Color.Transparent;
            this.cpTargetColor.ImagePadding = new System.Windows.Forms.Padding(0);
            this.cpTargetColor.Location = new System.Drawing.Point(120, 87);
            this.cpTargetColor.Name = "cpTargetColor";
            this.cpTargetColor.Size = new System.Drawing.Size(166, 25);
            this.cpTargetColor.TabIndex = 2;
            this.cpTargetColor.Tag = null;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(14, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "対象フォルダ：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkExt
            // 
            this.chkExt.FormattingEnabled = true;
            this.chkExt.Items.AddRange(new object[] {
            "*.tif",
            "*.jpg"});
            this.chkExt.Location = new System.Drawing.Point(120, 118);
            this.chkExt.Name = "chkExt";
            this.chkExt.Size = new System.Drawing.Size(120, 42);
            this.chkExt.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAbort);
            this.groupBox1.Controls.Add(this.numPointY);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.numPointX);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtLogFolder);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cmbDirection);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.numPixel);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.chkExt);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtSrcFolder);
            this.groupBox1.Controls.Add(this.cpTargetColor);
            this.groupBox1.Controls.Add(this.btnStart);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(784, 170);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "設定";
            // 
            // txtLogFolder
            // 
            this.txtLogFolder.AllowDrop = true;
            this.txtLogFolder.Location = new System.Drawing.Point(120, 53);
            this.txtLogFolder.Name = "txtLogFolder";
            this.txtLogFolder.Size = new System.Drawing.Size(652, 24);
            this.txtLogFolder.TabIndex = 10;
            this.txtLogFolder.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtFolder_DragDrop);
            this.txtLogFolder.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtFolder_DragEnter);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(14, 52);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 25);
            this.label6.TabIndex = 11;
            this.label6.Text = "ログフォルダ：";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbDirection
            // 
            this.cmbDirection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDirection.FormattingEnabled = true;
            this.cmbDirection.Items.AddRange(new object[] {
            "縦",
            "横"});
            this.cmbDirection.Location = new System.Drawing.Point(352, 119);
            this.cmbDirection.Name = "cmbDirection";
            this.cmbDirection.Size = new System.Drawing.Size(50, 25);
            this.cmbDirection.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(246, 118);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 25);
            this.label5.TabIndex = 8;
            this.label5.Text = "走査方向：";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(358, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(162, 25);
            this.label4.TabIndex = 7;
            this.label4.Text = "ピクセル連続していたらエラー";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numPixel
            // 
            this.numPixel.Location = new System.Drawing.Point(292, 87);
            this.numPixel.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numPixel.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numPixel.Name = "numPixel";
            this.numPixel.Size = new System.Drawing.Size(60, 24);
            this.numPixel.TabIndex = 6;
            this.numPixel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numPixel.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(14, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "画像形式：";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(14, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "対象色：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lstResult);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 170);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(784, 391);
            this.groupBox2.TabIndex = 6;
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
            this.lstResult.Size = new System.Drawing.Size(778, 368);
            this.lstResult.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(523, 87);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 25);
            this.label7.TabIndex = 12;
            this.label7.Text = "起点横：";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // numPointX
            // 
            this.numPointX.Location = new System.Drawing.Point(592, 89);
            this.numPointX.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numPointX.Name = "numPointX";
            this.numPointX.Size = new System.Drawing.Size(60, 24);
            this.numPointX.TabIndex = 13;
            this.numPointX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // numPointY
            // 
            this.numPointY.Location = new System.Drawing.Point(592, 119);
            this.numPointY.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numPointY.Name = "numPointY";
            this.numPointY.Size = new System.Drawing.Size(60, 24);
            this.numPointY.TabIndex = 15;
            this.numPointY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(523, 117);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 25);
            this.label8.TabIndex = 14;
            this.label8.Text = "起点縦：";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnAbort
            // 
            this.btnAbort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAbort.Location = new System.Drawing.Point(692, 139);
            this.btnAbort.Name = "btnAbort";
            this.btnAbort.Size = new System.Drawing.Size(80, 25);
            this.btnAbort.TabIndex = 16;
            this.btnAbort.Text = "中　断";
            this.btnAbort.UseVisualStyleBackColor = true;
            this.btnAbort.Click += new System.EventHandler(this.btnAbort_Click);
            // 
            // frmMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Meiryo UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmMain";
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cpTargetColor)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPixel)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numPointX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPointY)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtSrcFolder;
        private System.Windows.Forms.Button btnStart;
        private C1.Win.C1Input.C1ColorPicker cpTargetColor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox chkExt;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numPixel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtLogFolder;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbDirection;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox lstResult;
        private System.Windows.Forms.NumericUpDown numPointY;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown numPointX;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnAbort;
    }
}