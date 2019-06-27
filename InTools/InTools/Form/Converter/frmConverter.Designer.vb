<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmConverter
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConverter))
        Me.C1StatusBar1 = New C1.Win.C1Ribbon.C1StatusBar()
        Me.Label = New C1.Win.C1Ribbon.RibbonLabel()
        Me.RibbonLabel4 = New C1.Win.C1Ribbon.RibbonLabel()
        Me.pgbFiles = New C1.Win.C1Ribbon.RibbonProgressBar()
        Me.txtProgress = New C1.Win.C1Ribbon.RibbonLabel()
        Me.RibbonSeparator211 = New C1.Win.C1Ribbon.RibbonSeparator()
        Me.RibbonLabel1 = New C1.Win.C1Ribbon.RibbonLabel()
        Me.txtErrorCount1 = New C1.Win.C1Ribbon.RibbonTextBox()
        Me.RibbonSeparator1 = New C1.Win.C1Ribbon.RibbonSeparator()
        Me.btnBackMenu = New C1.Win.C1Ribbon.RibbonButton()
        Me.PrintDialog = New System.Windows.Forms.PrintDialog()
        Me.fgrFileList = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnOutputFolderOpen = New C1.Win.C1Input.C1Button()
        Me.btnInputFolderOpen = New C1.Win.C1Input.C1Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.rbSingle = New System.Windows.Forms.RadioButton()
        Me.rbMulti = New System.Windows.Forms.RadioButton()
        Me.cmbCompress = New System.Windows.Forms.ComboBox()
        Me.cmbSrcFormat = New System.Windows.Forms.ComboBox()
        Me.cmbDstFormat = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtSrcPath = New System.Windows.Forms.TextBox()
        Me.txtDstPath = New System.Windows.Forms.TextBox()
        Me.btnOption = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnConvert = New C1.Win.C1Input.C1Button()
        Me.btnCancel = New C1.Win.C1Input.C1Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cmbDPI = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        CType(Me.C1StatusBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.fgrFileList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.btnOutputFolderOpen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnInputFolderOpen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnConvert, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnCancel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'C1StatusBar1
        '
        Me.C1StatusBar1.AutoSizeElement = C1.Framework.AutoSizeElement.Width
        Me.C1StatusBar1.LeftPaneItems.Add(Me.Label)
        Me.C1StatusBar1.Location = New System.Drawing.Point(0, 748)
        Me.C1StatusBar1.Name = "C1StatusBar1"
        Me.C1StatusBar1.RightPaneItems.Add(Me.RibbonLabel4)
        Me.C1StatusBar1.RightPaneItems.Add(Me.pgbFiles)
        Me.C1StatusBar1.RightPaneItems.Add(Me.txtProgress)
        Me.C1StatusBar1.RightPaneItems.Add(Me.RibbonSeparator211)
        Me.C1StatusBar1.RightPaneItems.Add(Me.RibbonLabel1)
        Me.C1StatusBar1.RightPaneItems.Add(Me.txtErrorCount1)
        Me.C1StatusBar1.RightPaneItems.Add(Me.RibbonSeparator1)
        Me.C1StatusBar1.RightPaneItems.Add(Me.btnBackMenu)
        Me.C1StatusBar1.Size = New System.Drawing.Size(992, 23)
        Me.C1StatusBar1.SizingGrip = False
        '
        'Label
        '
        Me.Label.Name = "Label"
        Me.Label.Text = "画像を指定のフォーマットに変換します。"
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
        'RibbonLabel1
        '
        Me.RibbonLabel1.Name = "RibbonLabel1"
        Me.RibbonLabel1.Text = "エラー"
        '
        'txtErrorCount1
        '
        Me.txtErrorCount1.Enabled = False
        Me.txtErrorCount1.Name = "txtErrorCount1"
        Me.txtErrorCount1.Text = "0"
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
        Me.fgrFileList.Location = New System.Drawing.Point(0, 185)
        Me.fgrFileList.Name = "fgrFileList"
        Me.fgrFileList.Rows.DefaultSize = 18
        Me.fgrFileList.Size = New System.Drawing.Size(992, 563)
        Me.fgrFileList.TabIndex = 2
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.cmbDPI)
        Me.GroupBox2.Controls.Add(Me.btnOption)
        Me.GroupBox2.Controls.Add(Me.btnOutputFolderOpen)
        Me.GroupBox2.Controls.Add(Me.btnInputFolderOpen)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.rbSingle)
        Me.GroupBox2.Controls.Add(Me.rbMulti)
        Me.GroupBox2.Controls.Add(Me.cmbCompress)
        Me.GroupBox2.Controls.Add(Me.cmbSrcFormat)
        Me.GroupBox2.Controls.Add(Me.cmbDstFormat)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.txtSrcPath)
        Me.GroupBox2.Controls.Add(Me.txtDstPath)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox2.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(992, 127)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "変換設定"
        '
        'btnOutputFolderOpen
        '
        Me.btnOutputFolderOpen.Font = New System.Drawing.Font("MS UI Gothic", 10.0!)
        Me.btnOutputFolderOpen.Location = New System.Drawing.Point(794, 50)
        Me.btnOutputFolderOpen.Name = "btnOutputFolderOpen"
        Me.btnOutputFolderOpen.Size = New System.Drawing.Size(59, 24)
        Me.btnOutputFolderOpen.TabIndex = 26
        Me.btnOutputFolderOpen.Text = "..."
        Me.btnOutputFolderOpen.UseVisualStyleBackColor = True
        Me.btnOutputFolderOpen.VisualStyle = C1.Win.C1Input.VisualStyle.System
        '
        'btnInputFolderOpen
        '
        Me.btnInputFolderOpen.Font = New System.Drawing.Font("MS UI Gothic", 10.0!)
        Me.btnInputFolderOpen.Location = New System.Drawing.Point(794, 15)
        Me.btnInputFolderOpen.Name = "btnInputFolderOpen"
        Me.btnInputFolderOpen.Size = New System.Drawing.Size(59, 24)
        Me.btnInputFolderOpen.TabIndex = 25
        Me.btnInputFolderOpen.Text = "..."
        Me.btnInputFolderOpen.UseVisualStyleBackColor = True
        Me.btnInputFolderOpen.VisualStyle = C1.Win.C1Input.VisualStyle.System
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 95)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 12)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "圧縮方式："
        '
        'rbSingle
        '
        Me.rbSingle.AutoSize = True
        Me.rbSingle.Location = New System.Drawing.Point(492, 93)
        Me.rbSingle.Name = "rbSingle"
        Me.rbSingle.Size = New System.Drawing.Size(61, 16)
        Me.rbSingle.TabIndex = 19
        Me.rbSingle.TabStop = True
        Me.rbSingle.Text = "シングル"
        Me.rbSingle.UseVisualStyleBackColor = True
        '
        'rbMulti
        '
        Me.rbMulti.AutoSize = True
        Me.rbMulti.Location = New System.Drawing.Point(559, 93)
        Me.rbMulti.Name = "rbMulti"
        Me.rbMulti.Size = New System.Drawing.Size(51, 16)
        Me.rbMulti.TabIndex = 20
        Me.rbMulti.TabStop = True
        Me.rbMulti.Text = "マルチ"
        Me.rbMulti.UseVisualStyleBackColor = True
        '
        'cmbCompress
        '
        Me.cmbCompress.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCompress.Font = New System.Drawing.Font("MS UI Gothic", 12.0!)
        Me.cmbCompress.FormattingEnabled = True
        Me.cmbCompress.Items.AddRange(New Object() {"変更しない", "非圧縮", "JPEG", "LZW", "Group4"})
        Me.cmbCompress.Location = New System.Drawing.Point(76, 88)
        Me.cmbCompress.Name = "cmbCompress"
        Me.cmbCompress.Size = New System.Drawing.Size(118, 24)
        Me.cmbCompress.TabIndex = 19
        '
        'cmbSrcFormat
        '
        Me.cmbSrcFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSrcFormat.Font = New System.Drawing.Font("MS UI Gothic", 12.0!)
        Me.cmbSrcFormat.FormattingEnabled = True
        Me.cmbSrcFormat.Items.AddRange(New Object() {"TIFF", "JPEG", "TIFF&JPEG", "PDF"})
        Me.cmbSrcFormat.Location = New System.Drawing.Point(859, 15)
        Me.cmbSrcFormat.Name = "cmbSrcFormat"
        Me.cmbSrcFormat.Size = New System.Drawing.Size(118, 24)
        Me.cmbSrcFormat.TabIndex = 12
        '
        'cmbDstFormat
        '
        Me.cmbDstFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDstFormat.Font = New System.Drawing.Font("MS UI Gothic", 12.0!)
        Me.cmbDstFormat.FormattingEnabled = True
        Me.cmbDstFormat.Items.AddRange(New Object() {"TIFF", "JPEG", "PDF"})
        Me.cmbDstFormat.Location = New System.Drawing.Point(859, 50)
        Me.cmbDstFormat.Name = "cmbDstFormat"
        Me.cmbDstFormat.Size = New System.Drawing.Size(118, 24)
        Me.cmbDstFormat.TabIndex = 11
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(23, 58)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(47, 12)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "変換先："
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(23, 23)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(47, 12)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "変換元："
        '
        'txtSrcPath
        '
        Me.txtSrcPath.AllowDrop = True
        Me.txtSrcPath.Font = New System.Drawing.Font("MS UI Gothic", 12.0!)
        Me.txtSrcPath.Location = New System.Drawing.Point(76, 16)
        Me.txtSrcPath.Name = "txtSrcPath"
        Me.txtSrcPath.Size = New System.Drawing.Size(712, 23)
        Me.txtSrcPath.TabIndex = 1
        Me.ToolTip1.SetToolTip(Me.txtSrcPath, "変換元のフォルダをドラッグ＆ドロップしてください。")
        '
        'txtDstPath
        '
        Me.txtDstPath.AllowDrop = True
        Me.txtDstPath.Font = New System.Drawing.Font("MS UI Gothic", 12.0!)
        Me.txtDstPath.Location = New System.Drawing.Point(76, 51)
        Me.txtDstPath.Name = "txtDstPath"
        Me.txtDstPath.Size = New System.Drawing.Size(712, 23)
        Me.txtDstPath.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.txtDstPath, "変換先のフォルダをドラッグ＆ドロップしてください。")
        '
        'btnOption
        '
        Me.btnOption.Font = New System.Drawing.Font("MS UI Gothic", 10.0!)
        Me.btnOption.Location = New System.Drawing.Point(859, 88)
        Me.btnOption.Name = "btnOption"
        Me.btnOption.Size = New System.Drawing.Size(118, 25)
        Me.btnOption.TabIndex = 13
        Me.btnOption.Text = "オプション"
        Me.btnOption.UseVisualStyleBackColor = True
        '
        'ToolTip1
        '
        Me.ToolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        '
        'btnConvert
        '
        Me.btnConvert.Location = New System.Drawing.Point(760, 133)
        Me.btnConvert.Name = "btnConvert"
        Me.btnConvert.Size = New System.Drawing.Size(107, 43)
        Me.btnConvert.TabIndex = 17
        Me.btnConvert.Text = "変換"
        Me.btnConvert.UseVisualStyleBackColor = True
        Me.btnConvert.VisualStyle = C1.Win.C1Input.VisualStyle.System
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(873, 133)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(107, 43)
        Me.btnCancel.TabIndex = 18
        Me.btnCancel.Text = "中断"
        Me.btnCancel.UseVisualStyleBackColor = True
        Me.btnCancel.VisualStyle = C1.Win.C1Input.VisualStyle.System
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Controls.Add(Me.btnCancel)
        Me.Panel1.Controls.Add(Me.btnConvert)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(992, 185)
        Me.Panel1.TabIndex = 19
        '
        'cmbDPI
        '
        Me.cmbDPI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDPI.Font = New System.Drawing.Font("MS UI Gothic", 12.0!)
        Me.cmbDPI.FormattingEnabled = True
        Me.cmbDPI.Location = New System.Drawing.Point(280, 88)
        Me.cmbDPI.Name = "cmbDPI"
        Me.cmbDPI.Size = New System.Drawing.Size(118, 24)
        Me.cmbDPI.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(227, 95)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 12)
        Me.Label2.TabIndex = 21
        Me.Label2.Text = "解像度："
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(433, 95)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(51, 12)
        Me.Label5.TabIndex = 27
        Me.Label5.Text = "マルチ化："
        '
        'frmConverter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(992, 771)
        Me.Controls.Add(Me.fgrFileList)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.C1StatusBar1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(1000, 800)
        Me.MinimumSize = New System.Drawing.Size(1000, 800)
        Me.Name = "frmConverter"
        Me.Text = "変換"
        Me.VisualStyleHolder = C1.Win.C1Ribbon.VisualStyle.Office2010Black
        CType(Me.C1StatusBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.fgrFileList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.btnOutputFolderOpen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnInputFolderOpen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnConvert, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnCancel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents C1StatusBar1 As C1.Win.C1Ribbon.C1StatusBar
    Friend WithEvents RibbonLabel4 As C1.Win.C1Ribbon.RibbonLabel
    Friend WithEvents pgbFiles As C1.Win.C1Ribbon.RibbonProgressBar
    Friend WithEvents txtProgress As C1.Win.C1Ribbon.RibbonLabel
    Friend WithEvents PrintDialog As PrintDialog
    Friend WithEvents fgrFileList As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtSrcPath As TextBox
    Friend WithEvents txtDstPath As TextBox
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents Label As C1.Win.C1Ribbon.RibbonLabel
    Friend WithEvents RibbonSeparator211 As C1.Win.C1Ribbon.RibbonSeparator
    Friend WithEvents cmbSrcFormat As ComboBox
    Friend WithEvents cmbDstFormat As ComboBox
    Friend WithEvents btnOption As Button
    Friend WithEvents btnConvert As C1.Win.C1Input.C1Button
    Friend WithEvents btnCancel As C1.Win.C1Input.C1Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents cmbCompress As ComboBox
    Friend WithEvents rbSingle As RadioButton
    Friend WithEvents rbMulti As RadioButton
    Friend WithEvents Label1 As Label
    Friend WithEvents RibbonLabel1 As C1.Win.C1Ribbon.RibbonLabel
    Friend WithEvents txtErrorCount1 As C1.Win.C1Ribbon.RibbonTextBox
    Friend WithEvents RibbonSeparator1 As C1.Win.C1Ribbon.RibbonSeparator
    Friend WithEvents btnBackMenu As C1.Win.C1Ribbon.RibbonButton
    Friend WithEvents btnOutputFolderOpen As C1.Win.C1Input.C1Button
    Friend WithEvents btnInputFolderOpen As C1.Win.C1Input.C1Button
    Friend WithEvents cmbDPI As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label5 As Label
End Class
