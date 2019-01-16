<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMain
    Inherits C1.Win.C1Ribbon.C1RibbonForm

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtImageFolder = New System.Windows.Forms.TextBox()
        Me.txtLogFolder = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnStart = New System.Windows.Forms.Button()
        Me.ProgressBar = New C1.Win.C1Ribbon.RibbonProgressBar()
        Me.C1StatusBar1 = New C1.Win.C1Ribbon.C1StatusBar()
        Me.lblValue = New C1.Win.C1Ribbon.RibbonLabel()
        Me.RibbonLabel2 = New C1.Win.C1Ribbon.RibbonLabel()
        Me.lblMax = New C1.Win.C1Ribbon.RibbonLabel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtProvideData = New System.Windows.Forms.TextBox()
        Me.txtOutputFolder = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtpIraibi = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtIkkatsu = New System.Windows.Forms.TextBox()
        Me.txtParentFolder = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtEntryData = New System.Windows.Forms.TextBox()
        CType(Me.C1StatusBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("MS UI Gothic", 12.0!)
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(31, 167)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(112, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "イメージフォルダ："
        '
        'txtImageFolder
        '
        Me.txtImageFolder.AllowDrop = True
        Me.txtImageFolder.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.txtImageFolder.Font = New System.Drawing.Font("MS UI Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtImageFolder.Location = New System.Drawing.Point(149, 167)
        Me.txtImageFolder.Name = "txtImageFolder"
        Me.txtImageFolder.ReadOnly = True
        Me.txtImageFolder.Size = New System.Drawing.Size(423, 18)
        Me.txtImageFolder.TabIndex = 1
        Me.txtImageFolder.Text = "11_image"
        '
        'txtLogFolder
        '
        Me.txtLogFolder.AllowDrop = True
        Me.txtLogFolder.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.txtLogFolder.Font = New System.Drawing.Font("MS UI Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtLogFolder.Location = New System.Drawing.Point(149, 277)
        Me.txtLogFolder.Name = "txtLogFolder"
        Me.txtLogFolder.ReadOnly = True
        Me.txtLogFolder.Size = New System.Drawing.Size(423, 18)
        Me.txtLogFolder.TabIndex = 3
        Me.txtLogFolder.Text = "zz_log"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("MS UI Gothic", 12.0!)
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(24, 277)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(119, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "ログ出力フォルダ："
        '
        'btnStart
        '
        Me.btnStart.Font = New System.Drawing.Font("MS UI Gothic", 12.0!)
        Me.btnStart.Location = New System.Drawing.Point(429, 308)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(143, 28)
        Me.btnStart.TabIndex = 5
        Me.btnStart.Text = "実行"
        Me.btnStart.UseVisualStyleBackColor = True
        '
        'ProgressBar
        '
        Me.ProgressBar.Height = 18
        Me.ProgressBar.Name = "ProgressBar"
        Me.ProgressBar.Width = 480
        '
        'C1StatusBar1
        '
        Me.C1StatusBar1.AutoSizeElement = C1.Framework.AutoSizeElement.Width
        Me.C1StatusBar1.LeftPaneItems.Add(Me.ProgressBar)
        Me.C1StatusBar1.Location = New System.Drawing.Point(0, 348)
        Me.C1StatusBar1.Name = "C1StatusBar1"
        Me.C1StatusBar1.RightPaneItems.Add(Me.lblValue)
        Me.C1StatusBar1.RightPaneItems.Add(Me.RibbonLabel2)
        Me.C1StatusBar1.RightPaneItems.Add(Me.lblMax)
        Me.C1StatusBar1.Size = New System.Drawing.Size(592, 23)
        Me.C1StatusBar1.SizingGrip = False
        '
        'lblValue
        '
        Me.lblValue.Name = "lblValue"
        Me.lblValue.Text = "00000"
        '
        'RibbonLabel2
        '
        Me.RibbonLabel2.Name = "RibbonLabel2"
        Me.RibbonLabel2.Text = "/"
        '
        'lblMax
        '
        Me.lblMax.Name = "lblMax"
        Me.lblMax.Text = "00000"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("MS UI Gothic", 12.0!)
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(58, 89)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(85, 16)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "提供データ："
        '
        'txtProvideData
        '
        Me.txtProvideData.AllowDrop = True
        Me.txtProvideData.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.txtProvideData.Font = New System.Drawing.Font("MS UI Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtProvideData.Location = New System.Drawing.Point(149, 89)
        Me.txtProvideData.Name = "txtProvideData"
        Me.txtProvideData.ReadOnly = True
        Me.txtProvideData.Size = New System.Drawing.Size(423, 18)
        Me.txtProvideData.TabIndex = 1
        Me.txtProvideData.Text = "00_提供データ\yyyyMMdd三井倉庫様提供データ.TXT"
        '
        'txtOutputFolder
        '
        Me.txtOutputFolder.AllowDrop = True
        Me.txtOutputFolder.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.txtOutputFolder.Font = New System.Drawing.Font("MS UI Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtOutputFolder.Location = New System.Drawing.Point(149, 238)
        Me.txtOutputFolder.Name = "txtOutputFolder"
        Me.txtOutputFolder.ReadOnly = True
        Me.txtOutputFolder.Size = New System.Drawing.Size(423, 18)
        Me.txtOutputFolder.TabIndex = 8
        Me.txtOutputFolder.Text = "99_納品"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("MS UI Gothic", 12.0!)
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(-1, 238)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(144, 16)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "イメージ出力フォルダ："
        '
        'dtpIraibi
        '
        Me.dtpIraibi.Font = New System.Drawing.Font("MS UI Gothic", 12.0!)
        Me.dtpIraibi.Location = New System.Drawing.Point(149, 36)
        Me.dtpIraibi.Name = "dtpIraibi"
        Me.dtpIraibi.Size = New System.Drawing.Size(154, 23)
        Me.dtpIraibi.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("MS UI Gothic", 12.0!)
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(79, 41)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(64, 16)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "依頼日："
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("MS UI Gothic", 12.0!)
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(16, 128)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(127, 16)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "一括登録フォルダ："
        '
        'txtIkkatsu
        '
        Me.txtIkkatsu.AllowDrop = True
        Me.txtIkkatsu.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.txtIkkatsu.Font = New System.Drawing.Font("MS UI Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtIkkatsu.Location = New System.Drawing.Point(149, 128)
        Me.txtIkkatsu.Name = "txtIkkatsu"
        Me.txtIkkatsu.ReadOnly = True
        Me.txtIkkatsu.Size = New System.Drawing.Size(423, 18)
        Me.txtIkkatsu.TabIndex = 1
        Me.txtIkkatsu.Text = "00_提供データ\一括登録リスト"
        '
        'txtParentFolder
        '
        Me.txtParentFolder.AllowDrop = True
        Me.txtParentFolder.Font = New System.Drawing.Font("MS UI Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtParentFolder.Location = New System.Drawing.Point(149, 12)
        Me.txtParentFolder.Name = "txtParentFolder"
        Me.txtParentFolder.Size = New System.Drawing.Size(423, 18)
        Me.txtParentFolder.TabIndex = 1
        Me.txtParentFolder.Text = "\\hydra\01_制作Gr\05_定期案件\□三井住友海上運送保険\02_作業フォルダ"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("MS UI Gothic", 12.0!)
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(58, 14)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(79, 16)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "親フォルダ："
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("MS UI Gothic", 12.0!)
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(40, 203)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(97, 16)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "エントリデータ："
        '
        'txtEntryData
        '
        Me.txtEntryData.AllowDrop = True
        Me.txtEntryData.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.txtEntryData.Font = New System.Drawing.Font("MS UI Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtEntryData.Location = New System.Drawing.Point(149, 203)
        Me.txtEntryData.Name = "txtEntryData"
        Me.txtEntryData.ReadOnly = True
        Me.txtEntryData.Size = New System.Drawing.Size(423, 18)
        Me.txtEntryData.TabIndex = 1
        Me.txtEntryData.Text = "21_entry\出力データ\yyyyMMdd.csv"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(592, 371)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.dtpIraibi)
        Me.Controls.Add(Me.txtOutputFolder)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btnStart)
        Me.Controls.Add(Me.C1StatusBar1)
        Me.Controls.Add(Me.txtLogFolder)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtParentFolder)
        Me.Controls.Add(Me.txtEntryData)
        Me.Controls.Add(Me.txtProvideData)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtIkkatsu)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtImageFolder)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(600, 400)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(600, 400)
        Me.Name = "frmMain"
        Me.Tag = "s"
        Me.Text = "MSK委任状チェッカー"
        Me.VisualStyleHolder = C1.Win.C1Ribbon.VisualStyle.Office2007Black
        CType(Me.C1StatusBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents txtImageFolder As TextBox
    Friend WithEvents txtLogFolder As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents btnStart As Button
    Friend WithEvents ProgressBar As C1.Win.C1Ribbon.RibbonProgressBar
    Friend WithEvents C1StatusBar1 As C1.Win.C1Ribbon.C1StatusBar
    Friend WithEvents lblValue As C1.Win.C1Ribbon.RibbonLabel
    Friend WithEvents RibbonLabel2 As C1.Win.C1Ribbon.RibbonLabel
    Friend WithEvents lblMax As C1.Win.C1Ribbon.RibbonLabel
    Friend WithEvents Label3 As Label
    Friend WithEvents txtProvideData As TextBox
    Friend WithEvents txtOutputFolder As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents dtpIraibi As DateTimePicker
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents txtIkkatsu As TextBox
    Friend WithEvents txtParentFolder As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents txtEntryData As TextBox
End Class
