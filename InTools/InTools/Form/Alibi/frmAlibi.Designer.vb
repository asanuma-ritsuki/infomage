<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmAlibi
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAlibi))
        Me.C1StatusBar1 = New C1.Win.C1Ribbon.C1StatusBar()
        Me.RibbonLabel3 = New C1.Win.C1Ribbon.RibbonLabel()
        Me.txtFileCount = New C1.Win.C1Ribbon.RibbonTextBox()
        Me.RibbonSeparator21 = New C1.Win.C1Ribbon.RibbonSeparator()
        Me.RibbonLabel21 = New C1.Win.C1Ribbon.RibbonLabel()
        Me.txtErrorCount1 = New C1.Win.C1Ribbon.RibbonTextBox()
        Me.RibbonLabel4 = New C1.Win.C1Ribbon.RibbonLabel()
        Me.pgbFiles = New C1.Win.C1Ribbon.RibbonProgressBar()
        Me.txtProgress = New C1.Win.C1Ribbon.RibbonLabel()
        Me.RibbonSeparator211 = New C1.Win.C1Ribbon.RibbonSeparator()
        Me.btnBackMenu = New C1.Win.C1Ribbon.RibbonButton()
        Me.PrintDialog = New System.Windows.Forms.PrintDialog()
        Me.fgrFileList = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnPrint = New C1.Win.C1Input.C1Button()
        Me.nudTo = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.nudFrom = New System.Windows.Forms.NumericUpDown()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblAnken = New System.Windows.Forms.Label()
        Me.txtWorkName = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.chkBin = New System.Windows.Forms.CheckBox()
        Me.chkA4harf = New System.Windows.Forms.CheckBox()
        Me.btnReplace = New C1.Win.C1Input.C1Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtLogPath = New System.Windows.Forms.TextBox()
        Me.txtSrcPath = New System.Windows.Forms.TextBox()
        Me.txtDstPath = New System.Windows.Forms.TextBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.C1StatusBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.fgrFileList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.btnPrint, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudTo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudFrom, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.btnReplace, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'C1StatusBar1
        '
        Me.C1StatusBar1.AutoSizeElement = C1.Framework.AutoSizeElement.Width
        Me.C1StatusBar1.LeftPaneItems.Add(Me.RibbonLabel3)
        Me.C1StatusBar1.LeftPaneItems.Add(Me.txtFileCount)
        Me.C1StatusBar1.LeftPaneItems.Add(Me.RibbonSeparator21)
        Me.C1StatusBar1.LeftPaneItems.Add(Me.RibbonLabel21)
        Me.C1StatusBar1.LeftPaneItems.Add(Me.txtErrorCount1)
        Me.C1StatusBar1.Location = New System.Drawing.Point(0, 748)
        Me.C1StatusBar1.Name = "C1StatusBar1"
        Me.C1StatusBar1.RightPaneItems.Add(Me.RibbonLabel4)
        Me.C1StatusBar1.RightPaneItems.Add(Me.pgbFiles)
        Me.C1StatusBar1.RightPaneItems.Add(Me.txtProgress)
        Me.C1StatusBar1.RightPaneItems.Add(Me.RibbonSeparator211)
        Me.C1StatusBar1.RightPaneItems.Add(Me.btnBackMenu)
        Me.C1StatusBar1.Size = New System.Drawing.Size(992, 23)
        Me.C1StatusBar1.SizingGrip = False
        '
        'RibbonLabel3
        '
        Me.RibbonLabel3.Name = "RibbonLabel3"
        Me.RibbonLabel3.Text = "検索ファイル数"
        '
        'txtFileCount
        '
        Me.txtFileCount.Enabled = False
        Me.txtFileCount.Name = "txtFileCount"
        Me.txtFileCount.Text = "0/0"
        '
        'RibbonSeparator21
        '
        Me.RibbonSeparator21.Name = "RibbonSeparator21"
        '
        'RibbonLabel21
        '
        Me.RibbonLabel21.Name = "RibbonLabel21"
        Me.RibbonLabel21.Text = "エラー"
        '
        'txtErrorCount1
        '
        Me.txtErrorCount1.Enabled = False
        Me.txtErrorCount1.Name = "txtErrorCount1"
        Me.txtErrorCount1.Text = "0"
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
        Me.txtProgress.Text = "00000/00000"
        '
        'RibbonSeparator211
        '
        Me.RibbonSeparator211.Name = "RibbonSeparator211"
        '
        'btnBackMenu
        '
        Me.btnBackMenu.LargeImage = CType(resources.GetObject("btnBackMenu.LargeImage"), System.Drawing.Image)
        Me.btnBackMenu.Name = "btnBackMenu"
        Me.btnBackMenu.SmallImage = CType(resources.GetObject("btnBackMenu.SmallImage"), System.Drawing.Image)
        Me.btnBackMenu.Text = "戻る"
        '
        'PrintDialog
        '
        Me.PrintDialog.UseEXDialog = True
        '
        'fgrFileList
        '
        Me.fgrFileList.AllowEditing = False
        Me.fgrFileList.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.fgrFileList.AutoResize = True
        Me.fgrFileList.ColumnInfo = resources.GetString("fgrFileList.ColumnInfo")
        Me.fgrFileList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fgrFileList.Location = New System.Drawing.Point(0, 205)
        Me.fgrFileList.Name = "fgrFileList"
        Me.fgrFileList.Rows.DefaultSize = 18
        Me.fgrFileList.Size = New System.Drawing.Size(992, 543)
        Me.fgrFileList.TabIndex = 2
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnPrint)
        Me.GroupBox1.Controls.Add(Me.nudTo)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.nudFrom)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.lblAnken)
        Me.GroupBox1.Controls.Add(Me.txtWorkName)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(992, 54)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "印刷"
        '
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(905, 20)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(75, 23)
        Me.btnPrint.TabIndex = 14
        Me.btnPrint.Text = "印刷"
        Me.btnPrint.UseVisualStyleBackColor = True
        Me.btnPrint.VisualStyle = C1.Win.C1Input.VisualStyle.System
        '
        'nudTo
        '
        Me.nudTo.Font = New System.Drawing.Font("MS UI Gothic", 12.0!)
        Me.nudTo.Location = New System.Drawing.Point(809, 18)
        Me.nudTo.Maximum = New Decimal(New Integer() {999, 0, 0, 0})
        Me.nudTo.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudTo.Name = "nudTo"
        Me.nudTo.Size = New System.Drawing.Size(72, 23)
        Me.nudTo.TabIndex = 7
        Me.nudTo.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(786, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(17, 12)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "～"
        '
        'nudFrom
        '
        Me.nudFrom.Font = New System.Drawing.Font("MS UI Gothic", 12.0!)
        Me.nudFrom.Location = New System.Drawing.Point(708, 18)
        Me.nudFrom.Maximum = New Decimal(New Integer() {999, 0, 0, 0})
        Me.nudFrom.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudFrom.Name = "nudFrom"
        Me.nudFrom.Size = New System.Drawing.Size(72, 23)
        Me.nudFrom.TabIndex = 5
        Me.nudFrom.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(643, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 12)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "印刷範囲："
        '
        'lblAnken
        '
        Me.lblAnken.AutoSize = True
        Me.lblAnken.Location = New System.Drawing.Point(23, 25)
        Me.lblAnken.Name = "lblAnken"
        Me.lblAnken.Size = New System.Drawing.Size(47, 12)
        Me.lblAnken.TabIndex = 3
        Me.lblAnken.Text = "案件名："
        '
        'txtWorkName
        '
        Me.txtWorkName.Font = New System.Drawing.Font("MS UI Gothic", 12.0!)
        Me.txtWorkName.Location = New System.Drawing.Point(76, 18)
        Me.txtWorkName.Name = "txtWorkName"
        Me.txtWorkName.Size = New System.Drawing.Size(460, 23)
        Me.txtWorkName.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.chkBin)
        Me.GroupBox2.Controls.Add(Me.chkA4harf)
        Me.GroupBox2.Controls.Add(Me.btnReplace)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.txtLogPath)
        Me.GroupBox2.Controls.Add(Me.txtSrcPath)
        Me.GroupBox2.Controls.Add(Me.txtDstPath)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox2.Location = New System.Drawing.Point(0, 54)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(992, 151)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "差し替え"
        '
        'chkBin
        '
        Me.chkBin.AutoSize = True
        Me.chkBin.Checked = True
        Me.chkBin.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkBin.Location = New System.Drawing.Point(580, 125)
        Me.chkBin.Name = "chkBin"
        Me.chkBin.Size = New System.Drawing.Size(150, 16)
        Me.chkBin.TabIndex = 30
        Me.chkBin.Text = "2値変換読取（低速処理）"
        Me.chkBin.UseVisualStyleBackColor = True
        '
        'chkA4harf
        '
        Me.chkA4harf.AutoSize = True
        Me.chkA4harf.Location = New System.Drawing.Point(736, 125)
        Me.chkA4harf.Name = "chkA4harf"
        Me.chkA4harf.Size = New System.Drawing.Size(152, 16)
        Me.chkA4harf.TabIndex = 16
        Me.chkA4harf.Text = "A4縦ハーフサイズのみ検知"
        Me.chkA4harf.UseVisualStyleBackColor = True
        '
        'btnReplace
        '
        Me.btnReplace.Location = New System.Drawing.Point(905, 121)
        Me.btnReplace.Name = "btnReplace"
        Me.btnReplace.Size = New System.Drawing.Size(75, 23)
        Me.btnReplace.TabIndex = 15
        Me.btnReplace.Text = "差し替え"
        Me.btnReplace.UseVisualStyleBackColor = True
        Me.btnReplace.VisualStyle = C1.Win.C1Input.VisualStyle.System
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(41, 99)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(29, 12)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "ログ："
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(5, 61)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 12)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "差し替え元："
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(5, 23)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 12)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "差し替え先："
        '
        'txtLogPath
        '
        Me.txtLogPath.AllowDrop = True
        Me.txtLogPath.Font = New System.Drawing.Font("MS UI Gothic", 12.0!)
        Me.txtLogPath.Location = New System.Drawing.Point(76, 92)
        Me.txtLogPath.Name = "txtLogPath"
        Me.txtLogPath.Size = New System.Drawing.Size(904, 23)
        Me.txtLogPath.TabIndex = 2
        Me.ToolTip1.SetToolTip(Me.txtLogPath, "ログ・アリバイ画像を出力するフォルダをドラッグ＆ドロップしてください。")
        '
        'txtSrcPath
        '
        Me.txtSrcPath.AllowDrop = True
        Me.txtSrcPath.Font = New System.Drawing.Font("MS UI Gothic", 12.0!)
        Me.txtSrcPath.Location = New System.Drawing.Point(76, 54)
        Me.txtSrcPath.Name = "txtSrcPath"
        Me.txtSrcPath.Size = New System.Drawing.Size(904, 23)
        Me.txtSrcPath.TabIndex = 1
        Me.ToolTip1.SetToolTip(Me.txtSrcPath, "差し込みたい画像が含まれているフォルダをドラッグ＆ドロップしてください。")
        '
        'txtDstPath
        '
        Me.txtDstPath.AllowDrop = True
        Me.txtDstPath.Font = New System.Drawing.Font("MS UI Gothic", 12.0!)
        Me.txtDstPath.Location = New System.Drawing.Point(76, 16)
        Me.txtDstPath.Name = "txtDstPath"
        Me.txtDstPath.Size = New System.Drawing.Size(904, 23)
        Me.txtDstPath.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.txtDstPath, "アリバイ用紙画像が含まれているフォルダをドラッグ＆ドロップしてください。")
        '
        'ToolTip1
        '
        Me.ToolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        '
        'frmAlibi
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(992, 771)
        Me.Controls.Add(Me.fgrFileList)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.C1StatusBar1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(1000, 800)
        Me.MinimumSize = New System.Drawing.Size(1000, 800)
        Me.Name = "frmAlibi"
        Me.Text = "アリバイ用紙"
        Me.VisualStyleHolder = C1.Win.C1Ribbon.VisualStyle.Office2010Black
        CType(Me.C1StatusBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.fgrFileList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.btnPrint, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudTo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudFrom, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.btnReplace, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents C1StatusBar1 As C1.Win.C1Ribbon.C1StatusBar
    Friend WithEvents RibbonLabel3 As C1.Win.C1Ribbon.RibbonLabel
    Friend WithEvents txtFileCount As C1.Win.C1Ribbon.RibbonTextBox
    Friend WithEvents RibbonLabel4 As C1.Win.C1Ribbon.RibbonLabel
    Friend WithEvents pgbFiles As C1.Win.C1Ribbon.RibbonProgressBar
    Friend WithEvents txtProgress As C1.Win.C1Ribbon.RibbonLabel
    Friend WithEvents PrintDialog As PrintDialog
    Friend WithEvents fgrFileList As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btnPrint As C1.Win.C1Input.C1Button
    Friend WithEvents nudTo As NumericUpDown
    Friend WithEvents Label2 As Label
    Friend WithEvents nudFrom As NumericUpDown
    Friend WithEvents Label1 As Label
    Friend WithEvents lblAnken As Label
    Friend WithEvents txtWorkName As TextBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents btnReplace As C1.Win.C1Input.C1Button
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtLogPath As TextBox
    Friend WithEvents txtSrcPath As TextBox
    Friend WithEvents txtDstPath As TextBox
    Friend WithEvents btnBackMenu As C1.Win.C1Ribbon.RibbonButton
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents RibbonSeparator21 As C1.Win.C1Ribbon.RibbonSeparator
    Friend WithEvents RibbonLabel21 As C1.Win.C1Ribbon.RibbonLabel
    Friend WithEvents txtErrorCount1 As C1.Win.C1Ribbon.RibbonTextBox
    Friend WithEvents RibbonSeparator211 As C1.Win.C1Ribbon.RibbonSeparator
    Friend WithEvents chkA4harf As CheckBox
    Friend WithEvents chkBin As CheckBox
End Class
