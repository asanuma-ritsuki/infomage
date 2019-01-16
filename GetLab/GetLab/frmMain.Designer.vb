<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits C1.Win.C1Ribbon.C1RibbonForm

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnOutputBrowse = New System.Windows.Forms.Button()
        Me.txtOutputFolder = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.PictureBoxIpl1 = New OpenCvSharp.UserInterface.PictureBoxIpl()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.rbChartIT8 = New System.Windows.Forms.RadioButton()
        Me.rbChartSG = New System.Windows.Forms.RadioButton()
        Me.rbChartCL = New System.Windows.Forms.RadioButton()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.rbAdobeRGB = New System.Windows.Forms.RadioButton()
        Me.rbsRGB = New System.Windows.Forms.RadioButton()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.fgrResult = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtDE00 = New System.Windows.Forms.TextBox()
        Me.txtDEab = New System.Windows.Forms.TextBox()
        Me.btnCancel = New C1.Win.C1Input.C1Button()
        Me.btnStart = New C1.Win.C1Input.C1Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.C1StatusBar1 = New C1.Win.C1Ribbon.C1StatusBar()
        Me.tsStatusLabel = New C1.Win.C1Ribbon.RibbonLabel()
        Me.rbChartIT8Trans = New System.Windows.Forms.RadioButton()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel5.SuspendLayout()
        CType(Me.PictureBoxIpl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox8.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.Panel7.SuspendLayout()
        CType(Me.fgrResult, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel6.SuspendLayout()
        CType(Me.btnCancel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnStart, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.C1StatusBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnOutputBrowse)
        Me.GroupBox2.Controls.Add(Me.txtOutputFolder)
        Me.GroupBox2.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(668, 68)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "出力フォルダ"
        '
        'btnOutputBrowse
        '
        Me.btnOutputBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOutputBrowse.Location = New System.Drawing.Point(608, 27)
        Me.btnOutputBrowse.Name = "btnOutputBrowse"
        Me.btnOutputBrowse.Size = New System.Drawing.Size(50, 24)
        Me.btnOutputBrowse.TabIndex = 1
        Me.btnOutputBrowse.Text = "..."
        Me.btnOutputBrowse.UseVisualStyleBackColor = True
        '
        'txtOutputFolder
        '
        Me.txtOutputFolder.AllowDrop = True
        Me.txtOutputFolder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtOutputFolder.Font = New System.Drawing.Font("Meiryo UI", 9.75!)
        Me.txtOutputFolder.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtOutputFolder.Location = New System.Drawing.Point(8, 27)
        Me.txtOutputFolder.Name = "txtOutputFolder"
        Me.txtOutputFolder.ReadOnly = True
        Me.txtOutputFolder.Size = New System.Drawing.Size(602, 24)
        Me.txtOutputFolder.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Panel5)
        Me.GroupBox1.Controls.Add(Me.GroupBox8)
        Me.GroupBox1.Controls.Add(Me.GroupBox4)
        Me.GroupBox1.Controls.Add(Me.Panel4)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(668, 532)
        Me.GroupBox1.TabIndex = 30
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "読込カラーチャート"
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.PictureBoxIpl1)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Location = New System.Drawing.Point(3, 80)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(662, 449)
        Me.Panel5.TabIndex = 29
        '
        'PictureBoxIpl1
        '
        Me.PictureBoxIpl1.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.PictureBoxIpl1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBoxIpl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBoxIpl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBoxIpl1.Image = CType(resources.GetObject("PictureBoxIpl1.Image"), System.Drawing.Image)
        Me.PictureBoxIpl1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBoxIpl1.Name = "PictureBoxIpl1"
        Me.PictureBoxIpl1.Size = New System.Drawing.Size(662, 449)
        Me.PictureBoxIpl1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBoxIpl1.TabIndex = 16
        Me.PictureBoxIpl1.TabStop = False
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.rbChartIT8Trans)
        Me.GroupBox8.Controls.Add(Me.rbChartIT8)
        Me.GroupBox8.Controls.Add(Me.rbChartSG)
        Me.GroupBox8.Controls.Add(Me.rbChartCL)
        Me.GroupBox8.Location = New System.Drawing.Point(8, 19)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(433, 55)
        Me.GroupBox8.TabIndex = 34
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "計測チャート"
        '
        'rbChartIT8
        '
        Me.rbChartIT8.AutoSize = True
        Me.rbChartIT8.Location = New System.Drawing.Point(242, 23)
        Me.rbChartIT8.Name = "rbChartIT8"
        Me.rbChartIT8.Size = New System.Drawing.Size(83, 21)
        Me.rbChartIT8.TabIndex = 2
        Me.rbChartIT8.TabStop = True
        Me.rbChartIT8.Text = "IT8(288)"
        Me.rbChartIT8.UseVisualStyleBackColor = True
        '
        'rbChartSG
        '
        Me.rbChartSG.AutoSize = True
        Me.rbChartSG.Location = New System.Drawing.Point(113, 23)
        Me.rbChartSG.Name = "rbChartSG"
        Me.rbChartSG.Size = New System.Drawing.Size(123, 21)
        Me.rbChartSG.TabIndex = 1
        Me.rbChartSG.TabStop = True
        Me.rbChartSG.Text = "Digital SG(140)"
        Me.rbChartSG.UseVisualStyleBackColor = True
        '
        'rbChartCL
        '
        Me.rbChartCL.AutoSize = True
        Me.rbChartCL.Location = New System.Drawing.Point(11, 23)
        Me.rbChartCL.Name = "rbChartCL"
        Me.rbChartCL.Size = New System.Drawing.Size(96, 21)
        Me.rbChartCL.TabIndex = 0
        Me.rbChartCL.TabStop = True
        Me.rbChartCL.Text = "Classic(24)"
        Me.rbChartCL.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.rbAdobeRGB)
        Me.GroupBox4.Controls.Add(Me.rbsRGB)
        Me.GroupBox4.Location = New System.Drawing.Point(478, 19)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(180, 55)
        Me.GroupBox4.TabIndex = 35
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "カラープロファイル"
        '
        'rbAdobeRGB
        '
        Me.rbAdobeRGB.AutoSize = True
        Me.rbAdobeRGB.Location = New System.Drawing.Point(76, 23)
        Me.rbAdobeRGB.Name = "rbAdobeRGB"
        Me.rbAdobeRGB.Size = New System.Drawing.Size(94, 21)
        Me.rbAdobeRGB.TabIndex = 1
        Me.rbAdobeRGB.TabStop = True
        Me.rbAdobeRGB.Text = "AdobeRGB"
        Me.rbAdobeRGB.UseVisualStyleBackColor = True
        '
        'rbsRGB
        '
        Me.rbsRGB.AutoSize = True
        Me.rbsRGB.Location = New System.Drawing.Point(11, 23)
        Me.rbsRGB.Name = "rbsRGB"
        Me.rbsRGB.Size = New System.Drawing.Size(59, 21)
        Me.rbsRGB.TabIndex = 0
        Me.rbsRGB.TabStop = True
        Me.rbsRGB.Text = "sRGB"
        Me.rbsRGB.UseVisualStyleBackColor = True
        '
        'Panel4
        '
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(3, 20)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(662, 60)
        Me.Panel4.TabIndex = 36
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Panel7)
        Me.GroupBox3.Controls.Add(Me.Panel6)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox3.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(444, 532)
        Me.GroupBox3.TabIndex = 31
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "検出結果"
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.fgrResult)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel7.Location = New System.Drawing.Point(3, 81)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(438, 448)
        Me.Panel7.TabIndex = 33
        '
        'fgrResult
        '
        Me.fgrResult.ColumnInfo = resources.GetString("fgrResult.ColumnInfo")
        Me.fgrResult.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fgrResult.Location = New System.Drawing.Point(0, 0)
        Me.fgrResult.Name = "fgrResult"
        Me.fgrResult.Rows.DefaultSize = 27
        Me.fgrResult.Size = New System.Drawing.Size(438, 448)
        Me.fgrResult.TabIndex = 17
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.Label1)
        Me.Panel6.Controls.Add(Me.Label3)
        Me.Panel6.Controls.Add(Me.txtDE00)
        Me.Panel6.Controls.Add(Me.txtDEab)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel6.Location = New System.Drawing.Point(3, 20)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(438, 61)
        Me.Panel6.TabIndex = 32
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Meiryo UI", 18.0!)
        Me.Label1.Location = New System.Drawing.Point(3, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(110, 30)
        Me.Label1.TabIndex = 28
        Me.Label1.Text = "⊿E*ab="
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Meiryo UI", 18.0!)
        Me.Label3.Location = New System.Drawing.Point(230, 11)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(96, 30)
        Me.Label3.TabIndex = 29
        Me.Label3.Text = "⊿E00="
        '
        'txtDE00
        '
        Me.txtDE00.Enabled = False
        Me.txtDE00.Font = New System.Drawing.Font("Meiryo UI", 18.0!)
        Me.txtDE00.Location = New System.Drawing.Point(326, 10)
        Me.txtDE00.Name = "txtDE00"
        Me.txtDE00.ReadOnly = True
        Me.txtDE00.Size = New System.Drawing.Size(105, 38)
        Me.txtDE00.TabIndex = 31
        '
        'txtDEab
        '
        Me.txtDEab.Enabled = False
        Me.txtDEab.Font = New System.Drawing.Font("Meiryo UI", 18.0!)
        Me.txtDEab.Location = New System.Drawing.Point(113, 10)
        Me.txtDEab.Name = "txtDEab"
        Me.txtDEab.ReadOnly = True
        Me.txtDEab.Size = New System.Drawing.Size(105, 38)
        Me.txtDEab.TabIndex = 30
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnCancel.Font = New System.Drawing.Font("Meiryo UI", 12.0!)
        Me.btnCancel.Location = New System.Drawing.Point(960, 12)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(140, 56)
        Me.btnCancel.TabIndex = 28
        Me.btnCancel.Text = "中断"
        Me.btnCancel.UseVisualStyleBackColor = True
        Me.btnCancel.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        Me.btnCancel.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        '
        'btnStart
        '
        Me.btnStart.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnStart.Font = New System.Drawing.Font("Meiryo UI", 12.0!)
        Me.btnStart.Location = New System.Drawing.Point(814, 12)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(140, 56)
        Me.btnStart.TabIndex = 28
        Me.btnStart.Text = "計測開始"
        Me.btnStart.UseVisualStyleBackColor = True
        Me.btnStart.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        Me.btnStart.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Controls.Add(Me.btnStart)
        Me.Panel1.Controls.Add(Me.btnCancel)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1112, 76)
        Me.Panel1.TabIndex = 32
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.GroupBox1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 76)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(668, 532)
        Me.Panel2.TabIndex = 33
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.GroupBox3)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel3.Location = New System.Drawing.Point(668, 76)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(444, 532)
        Me.Panel3.TabIndex = 34
        '
        'C1StatusBar1
        '
        Me.C1StatusBar1.AutoSizeElement = C1.Framework.AutoSizeElement.Width
        Me.C1StatusBar1.LeftPaneItems.Add(Me.tsStatusLabel)
        Me.C1StatusBar1.Location = New System.Drawing.Point(0, 608)
        Me.C1StatusBar1.Name = "C1StatusBar1"
        Me.C1StatusBar1.Size = New System.Drawing.Size(1112, 23)
        '
        'tsStatusLabel
        '
        Me.tsStatusLabel.Name = "tsStatusLabel"
        Me.tsStatusLabel.Text = "Lab値を検出し⊿Eを算出します。（カラーチャートと出力フォルダを指定して開始ボタンを押してください。）"
        '
        'rbChartIT8Trans
        '
        Me.rbChartIT8Trans.AutoSize = True
        Me.rbChartIT8Trans.Location = New System.Drawing.Point(331, 23)
        Me.rbChartIT8Trans.Name = "rbChartIT8Trans"
        Me.rbChartIT8Trans.Size = New System.Drawing.Size(85, 21)
        Me.rbChartIT8Trans.TabIndex = 3
        Me.rbChartIT8Trans.TabStop = True
        Me.rbChartIT8Trans.Text = "IT8(透過)"
        Me.rbChartIT8Trans.UseVisualStyleBackColor = True
        '
        'frmMain
        '
        Me.AllowDrop = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1112, 631)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.C1StatusBar1)
        Me.Font = New System.Drawing.Font("Meiryo UI", 9.75!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MinimumSize = New System.Drawing.Size(1120, 660)
        Me.Name = "frmMain"
        Me.Text = "GetLab"
        Me.VisualStyleHolder = C1.Win.C1Ribbon.VisualStyle.Office2010Black
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        CType(Me.PictureBoxIpl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        CType(Me.fgrResult, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        CType(Me.btnCancel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnStart, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        CType(Me.C1StatusBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtOutputFolder As System.Windows.Forms.TextBox
    Friend WithEvents btnOutputBrowse As System.Windows.Forms.Button
    Friend WithEvents btnCancel As C1.Win.C1Input.C1Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents rbChartSG As System.Windows.Forms.RadioButton
    Friend WithEvents rbChartCL As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents rbAdobeRGB As System.Windows.Forms.RadioButton
    Friend WithEvents rbsRGB As System.Windows.Forms.RadioButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtDE00 As System.Windows.Forms.TextBox
    Friend WithEvents txtDEab As System.Windows.Forms.TextBox
    Friend WithEvents PictureBoxIpl1 As OpenCvSharp.UserInterface.PictureBoxIpl
    Friend WithEvents btnStart As C1.Win.C1Input.C1Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel7 As Panel
    Friend WithEvents Panel6 As Panel
    Friend WithEvents C1StatusBar1 As C1.Win.C1Ribbon.C1StatusBar
    Friend WithEvents rbChartIT8 As RadioButton
    Friend WithEvents rbChartIT8Trans As System.Windows.Forms.RadioButton
    Private WithEvents fgrResult As C1.Win.C1FlexGrid.C1FlexGrid
    Private WithEvents tsStatusLabel As C1.Win.C1Ribbon.RibbonLabel
End Class
