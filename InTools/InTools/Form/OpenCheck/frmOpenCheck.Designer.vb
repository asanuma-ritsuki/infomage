<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmOpenCheck
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmOpenCheck))
        Me.C1StatusBar1 = New C1.Win.C1Ribbon.C1StatusBar()
        Me.RibbonLabel3 = New C1.Win.C1Ribbon.RibbonLabel()
        Me.txtFileCount = New C1.Win.C1Ribbon.RibbonTextBox()
        Me.RibbonSeparator2 = New C1.Win.C1Ribbon.RibbonSeparator()
        Me.RibbonLabel2 = New C1.Win.C1Ribbon.RibbonLabel()
        Me.txtErrorCount = New C1.Win.C1Ribbon.RibbonTextBox()
        Me.RibbonLabel4 = New C1.Win.C1Ribbon.RibbonLabel()
        Me.pgbFiles = New C1.Win.C1Ribbon.RibbonProgressBar()
        Me.txtProgress = New C1.Win.C1Ribbon.RibbonLabel()
        Me.btnBackMenu = New C1.Win.C1Ribbon.RibbonButton()
        Me.fgrFileList = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.nudMargin = New System.Windows.Forms.NumericUpDown()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbMojiCode = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnOutputFolderOpen = New C1.Win.C1Input.C1Button()
        Me.btnInputFolderOpen = New C1.Win.C1Input.C1Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtOutputFolderName = New System.Windows.Forms.TextBox()
        Me.cmbHash = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtInputFolderName = New System.Windows.Forms.TextBox()
        Me.btnStart = New C1.Win.C1Input.C1Button()
        CType(Me.C1StatusBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.fgrFileList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.nudMargin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnOutputFolderOpen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnInputFolderOpen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnStart, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'C1StatusBar1
        '
        Me.C1StatusBar1.AutoSizeElement = C1.Framework.AutoSizeElement.Width
        Me.C1StatusBar1.LeftPaneItems.Add(Me.RibbonLabel3)
        Me.C1StatusBar1.LeftPaneItems.Add(Me.txtFileCount)
        Me.C1StatusBar1.LeftPaneItems.Add(Me.RibbonSeparator2)
        Me.C1StatusBar1.LeftPaneItems.Add(Me.RibbonLabel2)
        Me.C1StatusBar1.LeftPaneItems.Add(Me.txtErrorCount)
        Me.C1StatusBar1.Location = New System.Drawing.Point(0, 771)
        Me.C1StatusBar1.Name = "C1StatusBar1"
        Me.C1StatusBar1.RightPaneItems.Add(Me.RibbonLabel4)
        Me.C1StatusBar1.RightPaneItems.Add(Me.pgbFiles)
        Me.C1StatusBar1.RightPaneItems.Add(Me.txtProgress)
        Me.C1StatusBar1.RightPaneItems.Add(Me.btnBackMenu)
        Me.C1StatusBar1.Size = New System.Drawing.Size(992, 23)
        Me.C1StatusBar1.SizingGrip = False
        '
        'RibbonLabel3
        '
        Me.RibbonLabel3.Name = "RibbonLabel3"
        Me.RibbonLabel3.Text = "ファイル数："
        '
        'txtFileCount
        '
        Me.txtFileCount.Enabled = False
        Me.txtFileCount.Name = "txtFileCount"
        '
        'RibbonSeparator2
        '
        Me.RibbonSeparator2.Name = "RibbonSeparator2"
        '
        'RibbonLabel2
        '
        Me.RibbonLabel2.Name = "RibbonLabel2"
        Me.RibbonLabel2.Text = "エラーファイル数："
        '
        'txtErrorCount
        '
        Me.txtErrorCount.Enabled = False
        Me.txtErrorCount.Name = "txtErrorCount"
        '
        'RibbonLabel4
        '
        Me.RibbonLabel4.Name = "RibbonLabel4"
        Me.RibbonLabel4.Text = "進捗"
        '
        'pgbFiles
        '
        Me.pgbFiles.Height = 20
        Me.pgbFiles.Name = "pgbFiles"
        Me.pgbFiles.Width = 400
        '
        'txtProgress
        '
        Me.txtProgress.Name = "txtProgress"
        Me.txtProgress.Text = "0000/0000"
        '
        'btnBackMenu
        '
        Me.btnBackMenu.LargeImage = CType(resources.GetObject("btnBackMenu.LargeImage"), System.Drawing.Image)
        Me.btnBackMenu.Name = "btnBackMenu"
        Me.btnBackMenu.SmallImage = CType(resources.GetObject("btnBackMenu.SmallImage"), System.Drawing.Image)
        Me.btnBackMenu.Text = "戻る"
        '
        'fgrFileList
        '
        Me.fgrFileList.AllowEditing = False
        Me.fgrFileList.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.fgrFileList.AutoResize = True
        Me.fgrFileList.ColumnInfo = resources.GetString("fgrFileList.ColumnInfo")
        Me.fgrFileList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fgrFileList.Location = New System.Drawing.Point(0, 100)
        Me.fgrFileList.Name = "fgrFileList"
        Me.fgrFileList.Rows.DefaultSize = 18
        Me.fgrFileList.Size = New System.Drawing.Size(992, 671)
        Me.fgrFileList.TabIndex = 2
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.nudMargin)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.cmbMojiCode)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.btnOutputFolderOpen)
        Me.GroupBox2.Controls.Add(Me.btnInputFolderOpen)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.txtOutputFolderName)
        Me.GroupBox2.Controls.Add(Me.cmbHash)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.txtInputFolderName)
        Me.GroupBox2.Controls.Add(Me.btnStart)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox2.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(992, 100)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "フォルダ指定・オプション"
        '
        'nudMargin
        '
        Me.nudMargin.Font = New System.Drawing.Font("MS UI Gothic", 10.0!)
        Me.nudMargin.Location = New System.Drawing.Point(398, 74)
        Me.nudMargin.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.nudMargin.Name = "nudMargin"
        Me.nudMargin.Size = New System.Drawing.Size(52, 21)
        Me.nudMargin.TabIndex = 27
        Me.nudMargin.Value = New Decimal(New Integer() {5, 0, 0, 0})
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(254, 77)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(138, 12)
        Me.Label5.TabIndex = 25
        Me.Label5.Text = "用紙サイズのマージン(mm)："
        '
        'cmbMojiCode
        '
        Me.cmbMojiCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMojiCode.Font = New System.Drawing.Font("MS UI Gothic", 10.0!)
        Me.cmbMojiCode.FormattingEnabled = True
        Me.cmbMojiCode.Location = New System.Drawing.Point(556, 74)
        Me.cmbMojiCode.Name = "cmbMojiCode"
        Me.cmbMojiCode.Size = New System.Drawing.Size(107, 21)
        Me.cmbMojiCode.TabIndex = 26
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(464, 77)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(86, 12)
        Me.Label4.TabIndex = 25
        Me.Label4.Text = "出力文字コード："
        '
        'btnOutputFolderOpen
        '
        Me.btnOutputFolderOpen.Font = New System.Drawing.Font("MS UI Gothic", 10.0!)
        Me.btnOutputFolderOpen.Location = New System.Drawing.Point(922, 45)
        Me.btnOutputFolderOpen.Name = "btnOutputFolderOpen"
        Me.btnOutputFolderOpen.Size = New System.Drawing.Size(64, 23)
        Me.btnOutputFolderOpen.TabIndex = 24
        Me.btnOutputFolderOpen.Text = "..."
        Me.btnOutputFolderOpen.UseVisualStyleBackColor = True
        Me.btnOutputFolderOpen.VisualStyle = C1.Win.C1Input.VisualStyle.System
        '
        'btnInputFolderOpen
        '
        Me.btnInputFolderOpen.Font = New System.Drawing.Font("MS UI Gothic", 10.0!)
        Me.btnInputFolderOpen.Location = New System.Drawing.Point(922, 16)
        Me.btnInputFolderOpen.Name = "btnInputFolderOpen"
        Me.btnInputFolderOpen.Size = New System.Drawing.Size(64, 23)
        Me.btnInputFolderOpen.TabIndex = 23
        Me.btnInputFolderOpen.Text = "..."
        Me.btnInputFolderOpen.UseVisualStyleBackColor = True
        Me.btnInputFolderOpen.VisualStyle = C1.Win.C1Input.VisualStyle.System
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(23, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 12)
        Me.Label2.TabIndex = 22
        Me.Label2.Text = "ログ出力フォルダ："
        '
        'txtOutputFolderName
        '
        Me.txtOutputFolderName.AllowDrop = True
        Me.txtOutputFolderName.Font = New System.Drawing.Font("MS UI Gothic", 12.0!)
        Me.txtOutputFolderName.Location = New System.Drawing.Point(111, 45)
        Me.txtOutputFolderName.Name = "txtOutputFolderName"
        Me.txtOutputFolderName.Size = New System.Drawing.Size(805, 23)
        Me.txtOutputFolderName.TabIndex = 21
        '
        'cmbHash
        '
        Me.cmbHash.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbHash.Font = New System.Drawing.Font("MS UI Gothic", 10.0!)
        Me.cmbHash.FormattingEnabled = True
        Me.cmbHash.Location = New System.Drawing.Point(766, 74)
        Me.cmbHash.Name = "cmbHash"
        Me.cmbHash.Size = New System.Drawing.Size(107, 21)
        Me.cmbHash.TabIndex = 20
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(678, 77)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 12)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "ハッシュ値種類："
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(23, 23)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(77, 12)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "チェックフォルダ："
        '
        'txtInputFolderName
        '
        Me.txtInputFolderName.AllowDrop = True
        Me.txtInputFolderName.Font = New System.Drawing.Font("MS UI Gothic", 12.0!)
        Me.txtInputFolderName.Location = New System.Drawing.Point(111, 16)
        Me.txtInputFolderName.Name = "txtInputFolderName"
        Me.txtInputFolderName.Size = New System.Drawing.Size(805, 23)
        Me.txtInputFolderName.TabIndex = 1
        '
        'btnStart
        '
        Me.btnStart.Font = New System.Drawing.Font("MS UI Gothic", 10.0!)
        Me.btnStart.Location = New System.Drawing.Point(879, 73)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(107, 22)
        Me.btnStart.TabIndex = 17
        Me.btnStart.Text = "開始"
        Me.btnStart.UseVisualStyleBackColor = True
        Me.btnStart.VisualStyle = C1.Win.C1Input.VisualStyle.System
        '
        'frmOpenCheck
        '
        Me.AllowDrop = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(992, 794)
        Me.Controls.Add(Me.fgrFileList)
        Me.Controls.Add(Me.C1StatusBar1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmOpenCheck"
        Me.Text = "画像情報出力"
        Me.VisualStyleHolder = C1.Win.C1Ribbon.VisualStyle.Office2010Black
        CType(Me.C1StatusBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.fgrFileList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.nudMargin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnOutputFolderOpen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnInputFolderOpen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnStart, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents C1StatusBar1 As C1.Win.C1Ribbon.C1StatusBar
    Friend WithEvents fgrFileList As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents RibbonLabel3 As C1.Win.C1Ribbon.RibbonLabel
    Friend WithEvents txtFileCount As C1.Win.C1Ribbon.RibbonTextBox
    Friend WithEvents RibbonSeparator2 As C1.Win.C1Ribbon.RibbonSeparator
    Friend WithEvents RibbonLabel2 As C1.Win.C1Ribbon.RibbonLabel
    Friend WithEvents txtErrorCount As C1.Win.C1Ribbon.RibbonTextBox
    Friend WithEvents RibbonLabel4 As C1.Win.C1Ribbon.RibbonLabel
    Friend WithEvents pgbFiles As C1.Win.C1Ribbon.RibbonProgressBar
    Friend WithEvents txtProgress As C1.Win.C1Ribbon.RibbonLabel
    Friend WithEvents btnBackMenu As C1.Win.C1Ribbon.RibbonButton
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtInputFolderName As TextBox
    Friend WithEvents btnStart As C1.Win.C1Input.C1Button
    Friend WithEvents cmbHash As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtOutputFolderName As TextBox
    Friend WithEvents btnOutputFolderOpen As C1.Win.C1Input.C1Button
    Friend WithEvents btnInputFolderOpen As C1.Win.C1Input.C1Button
    Friend WithEvents cmbMojiCode As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents nudMargin As NumericUpDown
End Class
