<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmGetPath
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmGetPath))
        Me.C1StatusBar1 = New C1.Win.C1Ribbon.C1StatusBar()
        Me.lblState = New C1.Win.C1Ribbon.RibbonLabel()
        Me.RibbonLabel4 = New C1.Win.C1Ribbon.RibbonLabel()
        Me.pgbFiles = New C1.Win.C1Ribbon.RibbonProgressBar()
        Me.txtProgress = New C1.Win.C1Ribbon.RibbonLabel()
        Me.RibbonSeparator1 = New C1.Win.C1Ribbon.RibbonSeparator()
        Me.btnBackMenu = New C1.Win.C1Ribbon.RibbonButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.rbFolder = New System.Windows.Forms.RadioButton()
        Me.rbFile = New System.Windows.Forms.RadioButton()
        Me.btnInputFolderOpen = New C1.Win.C1Input.C1Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.chkSkipEmpFolder = New System.Windows.Forms.CheckBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.chkFileCount = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cmbExt = New System.Windows.Forms.ComboBox()
        Me.chkFileSize = New System.Windows.Forms.CheckBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.chkExt = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtInputFolderName = New System.Windows.Forms.TextBox()
        Me.chkNotFindHidden = New System.Windows.Forms.CheckBox()
        Me.btnOutputFileOpen = New C1.Win.C1Input.C1Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtOutputFileName = New System.Windows.Forms.TextBox()
        Me.cmbMojiCode = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnStart = New C1.Win.C1Input.C1Button()
        Me.btnCancel = New C1.Win.C1Input.C1Button()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.chkPathSplit = New System.Windows.Forms.CheckBox()
        Me.rbTab = New System.Windows.Forms.RadioButton()
        Me.rbComma = New System.Windows.Forms.RadioButton()
        Me.Label8 = New System.Windows.Forms.Label()
        CType(Me.C1StatusBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.btnInputFolderOpen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.btnOutputFileOpen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnStart, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnCancel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'C1StatusBar1
        '
        Me.C1StatusBar1.AutoSizeElement = C1.Framework.AutoSizeElement.Width
        Me.C1StatusBar1.LeftPaneItems.Add(Me.lblState)
        Me.C1StatusBar1.Location = New System.Drawing.Point(0, 348)
        Me.C1StatusBar1.Name = "C1StatusBar1"
        Me.C1StatusBar1.RightPaneItems.Add(Me.RibbonLabel4)
        Me.C1StatusBar1.RightPaneItems.Add(Me.pgbFiles)
        Me.C1StatusBar1.RightPaneItems.Add(Me.txtProgress)
        Me.C1StatusBar1.RightPaneItems.Add(Me.RibbonSeparator1)
        Me.C1StatusBar1.RightPaneItems.Add(Me.btnBackMenu)
        Me.C1StatusBar1.Size = New System.Drawing.Size(552, 23)
        Me.C1StatusBar1.SizingGrip = False
        '
        'lblState
        '
        Me.lblState.Name = "lblState"
        Me.lblState.Text = "検索フォルダ内のパスを取得します。"
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
        Me.pgbFiles.Width = 150
        '
        'txtProgress
        '
        Me.txtProgress.Name = "txtProgress"
        Me.txtProgress.Text = "000000/000000"
        '
        'RibbonSeparator1
        '
        Me.RibbonSeparator1.Name = "RibbonSeparator1"
        '
        'btnBackMenu
        '
        Me.btnBackMenu.LargeImage = CType(resources.GetObject("btnBackMenu.LargeImage"), System.Drawing.Image)
        Me.btnBackMenu.Name = "btnBackMenu"
        Me.btnBackMenu.SmallImage = CType(resources.GetObject("btnBackMenu.SmallImage"), System.Drawing.Image)
        Me.btnBackMenu.Text = "戻る"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rbFolder)
        Me.GroupBox2.Controls.Add(Me.rbFile)
        Me.GroupBox2.Controls.Add(Me.btnInputFolderOpen)
        Me.GroupBox2.Controls.Add(Me.GroupBox3)
        Me.GroupBox2.Controls.Add(Me.GroupBox1)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.txtInputFolderName)
        Me.GroupBox2.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(543, 145)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "検索設定"
        '
        'rbFolder
        '
        Me.rbFolder.AutoSize = True
        Me.rbFolder.Location = New System.Drawing.Point(306, 48)
        Me.rbFolder.Name = "rbFolder"
        Me.rbFolder.Size = New System.Drawing.Size(82, 16)
        Me.rbFolder.TabIndex = 27
        Me.rbFolder.TabStop = True
        Me.rbFolder.Text = "フォルダ検索"
        Me.rbFolder.UseVisualStyleBackColor = True
        '
        'rbFile
        '
        Me.rbFile.AutoSize = True
        Me.rbFile.Location = New System.Drawing.Point(10, 48)
        Me.rbFile.Name = "rbFile"
        Me.rbFile.Size = New System.Drawing.Size(81, 16)
        Me.rbFile.TabIndex = 27
        Me.rbFile.TabStop = True
        Me.rbFile.Text = "ファイル検索"
        Me.rbFile.UseVisualStyleBackColor = True
        '
        'btnInputFolderOpen
        '
        Me.btnInputFolderOpen.Font = New System.Drawing.Font("MS UI Gothic", 10.0!)
        Me.btnInputFolderOpen.Location = New System.Drawing.Point(482, 16)
        Me.btnInputFolderOpen.Name = "btnInputFolderOpen"
        Me.btnInputFolderOpen.Size = New System.Drawing.Size(58, 23)
        Me.btnInputFolderOpen.TabIndex = 23
        Me.btnInputFolderOpen.Text = "..."
        Me.btnInputFolderOpen.UseVisualStyleBackColor = True
        Me.btnInputFolderOpen.VisualStyle = C1.Win.C1Input.VisualStyle.System
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.chkSkipEmpFolder)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.chkFileCount)
        Me.GroupBox3.Location = New System.Drawing.Point(302, 58)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(235, 82)
        Me.GroupBox3.TabIndex = 29
        Me.GroupBox3.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 46)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(120, 12)
        Me.Label1.TabIndex = 29
        Me.Label1.Text = "空フォルダを出力しない："
        '
        'chkSkipEmpFolder
        '
        Me.chkSkipEmpFolder.AutoSize = True
        Me.chkSkipEmpFolder.Location = New System.Drawing.Point(133, 45)
        Me.chkSkipEmpFolder.Name = "chkSkipEmpFolder"
        Me.chkSkipEmpFolder.Size = New System.Drawing.Size(48, 16)
        Me.chkSkipEmpFolder.TabIndex = 30
        Me.chkSkipEmpFolder.Text = "有効"
        Me.chkSkipEmpFolder.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(46, 22)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(81, 12)
        Me.Label7.TabIndex = 25
        Me.Label7.Text = "ファイル数出力："
        '
        'chkFileCount
        '
        Me.chkFileCount.AutoSize = True
        Me.chkFileCount.Location = New System.Drawing.Point(133, 20)
        Me.chkFileCount.Name = "chkFileCount"
        Me.chkFileCount.Size = New System.Drawing.Size(48, 16)
        Me.chkFileCount.TabIndex = 28
        Me.chkFileCount.Text = "有効"
        Me.chkFileCount.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.cmbExt)
        Me.GroupBox1.Controls.Add(Me.chkFileSize)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.chkExt)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 58)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(290, 82)
        Me.GroupBox1.TabIndex = 27
        Me.GroupBox1.TabStop = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("MS UI Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label9.Location = New System.Drawing.Point(84, 41)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(200, 11)
        Me.Label9.TabIndex = 30
        Me.Label9.Text = "※複数指定する場合はカンマ(,)区切りで入力"
        '
        'cmbExt
        '
        Me.cmbExt.FormattingEnabled = True
        Me.cmbExt.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.cmbExt.Items.AddRange(New Object() {"jpg", "tif", "jpg,tif", "pdf"})
        Me.cmbExt.Location = New System.Drawing.Point(169, 18)
        Me.cmbExt.Name = "cmbExt"
        Me.cmbExt.Size = New System.Drawing.Size(115, 20)
        Me.cmbExt.TabIndex = 29
        '
        'chkFileSize
        '
        Me.chkFileSize.AutoSize = True
        Me.chkFileSize.Location = New System.Drawing.Point(115, 57)
        Me.chkFileSize.Name = "chkFileSize"
        Me.chkFileSize.Size = New System.Drawing.Size(48, 16)
        Me.chkFileSize.TabIndex = 28
        Me.chkFileSize.Text = "有効"
        Me.chkFileSize.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 59)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(98, 12)
        Me.Label6.TabIndex = 25
        Me.Label6.Text = "ファイルサイズ出力："
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(39, 22)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(71, 12)
        Me.Label5.TabIndex = 25
        Me.Label5.Text = "検索拡張子："
        '
        'chkExt
        '
        Me.chkExt.AutoSize = True
        Me.chkExt.Location = New System.Drawing.Point(116, 20)
        Me.chkExt.Name = "chkExt"
        Me.chkExt.Size = New System.Drawing.Size(48, 16)
        Me.chkExt.TabIndex = 28
        Me.chkExt.Text = "有効"
        Me.chkExt.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(11, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 12)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "検索フォルダ："
        '
        'txtInputFolderName
        '
        Me.txtInputFolderName.AllowDrop = True
        Me.txtInputFolderName.Font = New System.Drawing.Font("MS UI Gothic", 12.0!)
        Me.txtInputFolderName.Location = New System.Drawing.Point(87, 16)
        Me.txtInputFolderName.Name = "txtInputFolderName"
        Me.txtInputFolderName.Size = New System.Drawing.Size(389, 23)
        Me.txtInputFolderName.TabIndex = 1
        '
        'chkNotFindHidden
        '
        Me.chkNotFindHidden.AutoSize = True
        Me.chkNotFindHidden.Location = New System.Drawing.Point(13, 98)
        Me.chkNotFindHidden.Name = "chkNotFindHidden"
        Me.chkNotFindHidden.Size = New System.Drawing.Size(217, 16)
        Me.chkNotFindHidden.TabIndex = 30
        Me.chkNotFindHidden.Text = "隠し属性のファイル・フォルダは出力しない"
        Me.chkNotFindHidden.UseVisualStyleBackColor = True
        '
        'btnOutputFileOpen
        '
        Me.btnOutputFileOpen.Font = New System.Drawing.Font("MS UI Gothic", 10.0!)
        Me.btnOutputFileOpen.Location = New System.Drawing.Point(479, 18)
        Me.btnOutputFileOpen.Name = "btnOutputFileOpen"
        Me.btnOutputFileOpen.Size = New System.Drawing.Size(58, 23)
        Me.btnOutputFileOpen.TabIndex = 24
        Me.btnOutputFileOpen.Text = "..."
        Me.btnOutputFileOpen.UseVisualStyleBackColor = True
        Me.btnOutputFileOpen.VisualStyle = C1.Win.C1Input.VisualStyle.System
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 12)
        Me.Label2.TabIndex = 22
        Me.Label2.Text = "出力ファイル："
        '
        'txtOutputFileName
        '
        Me.txtOutputFileName.AllowDrop = True
        Me.txtOutputFileName.Font = New System.Drawing.Font("MS UI Gothic", 12.0!)
        Me.txtOutputFileName.Location = New System.Drawing.Point(87, 18)
        Me.txtOutputFileName.Name = "txtOutputFileName"
        Me.txtOutputFileName.Size = New System.Drawing.Size(386, 23)
        Me.txtOutputFileName.TabIndex = 21
        '
        'cmbMojiCode
        '
        Me.cmbMojiCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMojiCode.Font = New System.Drawing.Font("MS UI Gothic", 10.0!)
        Me.cmbMojiCode.FormattingEnabled = True
        Me.cmbMojiCode.Location = New System.Drawing.Point(369, 47)
        Me.cmbMojiCode.Name = "cmbMojiCode"
        Me.cmbMojiCode.Size = New System.Drawing.Size(104, 21)
        Me.cmbMojiCode.TabIndex = 26
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(269, 51)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(86, 12)
        Me.Label4.TabIndex = 25
        Me.Label4.Text = "出力文字コード："
        '
        'btnStart
        '
        Me.btnStart.Font = New System.Drawing.Font("MS UI Gothic", 10.0!)
        Me.btnStart.Location = New System.Drawing.Point(333, 307)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(99, 22)
        Me.btnStart.TabIndex = 17
        Me.btnStart.Text = "開始"
        Me.btnStart.UseVisualStyleBackColor = True
        Me.btnStart.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        '
        'btnCancel
        '
        Me.btnCancel.Font = New System.Drawing.Font("MS UI Gothic", 10.0!)
        Me.btnCancel.Location = New System.Drawing.Point(438, 307)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(99, 22)
        Me.btnCancel.TabIndex = 18
        Me.btnCancel.Text = "キャンセル"
        Me.btnCancel.UseVisualStyleBackColor = True
        Me.btnCancel.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.chkNotFindHidden)
        Me.GroupBox4.Controls.Add(Me.chkPathSplit)
        Me.GroupBox4.Controls.Add(Me.btnOutputFileOpen)
        Me.GroupBox4.Controls.Add(Me.Label2)
        Me.GroupBox4.Controls.Add(Me.txtOutputFileName)
        Me.GroupBox4.Controls.Add(Me.Label4)
        Me.GroupBox4.Controls.Add(Me.cmbMojiCode)
        Me.GroupBox4.Controls.Add(Me.rbTab)
        Me.GroupBox4.Controls.Add(Me.rbComma)
        Me.GroupBox4.Controls.Add(Me.Label8)
        Me.GroupBox4.Location = New System.Drawing.Point(0, 151)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(543, 125)
        Me.GroupBox4.TabIndex = 30
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "出力設定"
        '
        'chkPathSplit
        '
        Me.chkPathSplit.AutoSize = True
        Me.chkPathSplit.Location = New System.Drawing.Point(13, 76)
        Me.chkPathSplit.Name = "chkPathSplit"
        Me.chkPathSplit.Size = New System.Drawing.Size(224, 16)
        Me.chkPathSplit.TabIndex = 31
        Me.chkPathSplit.Text = "パスとファイル・フォルダ名の列を分けて出力"
        Me.chkPathSplit.UseVisualStyleBackColor = True
        '
        'rbTab
        '
        Me.rbTab.AutoSize = True
        Me.rbTab.Location = New System.Drawing.Point(150, 49)
        Me.rbTab.Name = "rbTab"
        Me.rbTab.Size = New System.Drawing.Size(64, 16)
        Me.rbTab.TabIndex = 27
        Me.rbTab.TabStop = True
        Me.rbTab.Text = "タブ(    )"
        Me.rbTab.UseVisualStyleBackColor = True
        '
        'rbComma
        '
        Me.rbComma.AutoSize = True
        Me.rbComma.Location = New System.Drawing.Point(87, 49)
        Me.rbComma.Name = "rbComma"
        Me.rbComma.Size = New System.Drawing.Size(60, 16)
        Me.rbComma.TabIndex = 27
        Me.rbComma.TabStop = True
        Me.rbComma.Text = "カンマ(,)"
        Me.rbComma.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(14, 51)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(67, 12)
        Me.Label8.TabIndex = 25
        Me.Label8.Text = "区切り文字："
        '
        'frmGetPath
        '
        Me.AllowDrop = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(552, 371)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.C1StatusBar1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnStart)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximumSize = New System.Drawing.Size(560, 400)
        Me.MinimumSize = New System.Drawing.Size(560, 400)
        Me.Name = "frmGetPath"
        Me.Text = "パス取得"
        Me.VisualStyleHolder = C1.Win.C1Ribbon.VisualStyle.Office2010Black
        CType(Me.C1StatusBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.btnInputFolderOpen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.btnOutputFileOpen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnStart, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnCancel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents C1StatusBar1 As C1.Win.C1Ribbon.C1StatusBar
    Friend WithEvents pgbFiles As C1.Win.C1Ribbon.RibbonProgressBar
    Friend WithEvents txtProgress As C1.Win.C1Ribbon.RibbonLabel
    Friend WithEvents btnBackMenu As C1.Win.C1Ribbon.RibbonButton
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtInputFolderName As TextBox
    Friend WithEvents btnStart As C1.Win.C1Input.C1Button
    Friend WithEvents Label2 As Label
    Friend WithEvents txtOutputFileName As TextBox
    Friend WithEvents btnOutputFileOpen As C1.Win.C1Input.C1Button
    Friend WithEvents btnInputFolderOpen As C1.Win.C1Input.C1Button
    Friend WithEvents cmbMojiCode As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btnCancel As C1.Win.C1Input.C1Button
    Friend WithEvents chkFileSize As CheckBox
    Friend WithEvents chkExt As CheckBox
    Friend WithEvents rbFile As RadioButton
    Friend WithEvents rbFolder As RadioButton
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents chkFileCount As CheckBox
    Friend WithEvents Label7 As Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents rbTab As RadioButton
    Friend WithEvents rbComma As RadioButton
    Friend WithEvents Label8 As Label
    Friend WithEvents RibbonLabel4 As C1.Win.C1Ribbon.RibbonLabel
    Friend WithEvents RibbonSeparator1 As C1.Win.C1Ribbon.RibbonSeparator
    Friend WithEvents lblState As C1.Win.C1Ribbon.RibbonLabel
    Friend WithEvents cmbExt As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents chkSkipEmpFolder As CheckBox
    Friend WithEvents chkNotFindHidden As CheckBox
    Friend WithEvents chkPathSplit As CheckBox
    Friend WithEvents Label9 As Label
End Class
