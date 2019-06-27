<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmBCRead
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBCRead))
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
        Me.chkBin = New System.Windows.Forms.CheckBox()
        Me.chkAutoRotate = New System.Windows.Forms.CheckBox()
        Me.cmbBCType = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnOutputFolderOpen = New C1.Win.C1Input.C1Button()
        Me.btnInputFolderOpen = New C1.Win.C1Input.C1Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtOutputFolderName = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtInputFolderName = New System.Windows.Forms.TextBox()
        Me.btnStart = New C1.Win.C1Input.C1Button()
        CType(Me.C1StatusBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.fgrFileList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
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
        Me.GroupBox2.Controls.Add(Me.chkBin)
        Me.GroupBox2.Controls.Add(Me.chkAutoRotate)
        Me.GroupBox2.Controls.Add(Me.cmbBCType)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.btnOutputFolderOpen)
        Me.GroupBox2.Controls.Add(Me.btnInputFolderOpen)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.txtOutputFolderName)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.txtInputFolderName)
        Me.GroupBox2.Controls.Add(Me.btnStart)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox2.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(992, 100)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "BC読取"
        '
        'chkBin
        '
        Me.chkBin.AutoSize = True
        Me.chkBin.Checked = True
        Me.chkBin.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkBin.Location = New System.Drawing.Point(287, 78)
        Me.chkBin.Name = "chkBin"
        Me.chkBin.Size = New System.Drawing.Size(150, 16)
        Me.chkBin.TabIndex = 29
        Me.chkBin.Text = "2値変換読取（低速処理）"
        Me.chkBin.UseVisualStyleBackColor = True
        '
        'chkAutoRotate
        '
        Me.chkAutoRotate.AutoSize = True
        Me.chkAutoRotate.Location = New System.Drawing.Point(449, 78)
        Me.chkAutoRotate.Name = "chkAutoRotate"
        Me.chkAutoRotate.Size = New System.Drawing.Size(156, 16)
        Me.chkAutoRotate.TabIndex = 28
        Me.chkAutoRotate.Text = "自動回転読取（低速処理）"
        Me.chkAutoRotate.UseVisualStyleBackColor = True
        '
        'cmbBCType
        '
        Me.cmbBCType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBCType.FormattingEnabled = True
        Me.cmbBCType.Location = New System.Drawing.Point(703, 74)
        Me.cmbBCType.Name = "cmbBCType"
        Me.cmbBCType.Size = New System.Drawing.Size(170, 20)
        Me.cmbBCType.TabIndex = 27
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(620, 79)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 12)
        Me.Label1.TabIndex = 26
        Me.Label1.Text = "検出BCタイプ："
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
        Me.Label2.Location = New System.Drawing.Point(17, 51)
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
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(28, 23)
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
        'frmBCRead
        '
        Me.AllowDrop = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(992, 794)
        Me.Controls.Add(Me.fgrFileList)
        Me.Controls.Add(Me.C1StatusBar1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmBCRead"
        Me.Text = "BC読取"
        Me.VisualStyleHolder = C1.Win.C1Ribbon.VisualStyle.Office2010Black
        CType(Me.C1StatusBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.fgrFileList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
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
    Friend WithEvents Label3 As Label
    Friend WithEvents txtInputFolderName As TextBox
    Friend WithEvents btnStart As C1.Win.C1Input.C1Button
    Friend WithEvents Label2 As Label
    Friend WithEvents txtOutputFolderName As TextBox
    Friend WithEvents btnOutputFolderOpen As C1.Win.C1Input.C1Button
    Friend WithEvents btnInputFolderOpen As C1.Win.C1Input.C1Button
    Friend WithEvents Label1 As Label
    Friend WithEvents cmbBCType As ComboBox
    Friend WithEvents chkAutoRotate As CheckBox
    Friend WithEvents chkBin As CheckBox
End Class
