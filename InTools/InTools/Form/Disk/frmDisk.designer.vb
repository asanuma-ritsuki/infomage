<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDisk
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDisk))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnInput = New System.Windows.Forms.Button()
        Me.txtInputPath = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnOutput = New System.Windows.Forms.Button()
        Me.txtOutputPath = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btnExtension = New System.Windows.Forms.Button()
        Me.btnDiskSize = New System.Windows.Forms.Button()
        Me.cmbFormula = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbDiskType = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lstResult = New System.Windows.Forms.ListBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnStart = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblDiskSize = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.C1StatusBar = New C1.Win.C1Ribbon.C1StatusBar()
        Me.tsLabel = New C1.Win.C1Ribbon.RibbonLabel()
        Me.tsProgressBar = New C1.Win.C1Ribbon.RibbonProgressBar()
        Me.btnBackMenu = New C1.Win.C1Ribbon.RibbonButton()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.C1StatusBar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnInput)
        Me.GroupBox1.Controls.Add(Me.txtInputPath)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(760, 59)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "読込フォルダ"
        '
        'btnInput
        '
        Me.btnInput.Location = New System.Drawing.Point(717, 22)
        Me.btnInput.Name = "btnInput"
        Me.btnInput.Size = New System.Drawing.Size(37, 23)
        Me.btnInput.TabIndex = 1
        Me.btnInput.Text = "..."
        Me.btnInput.UseVisualStyleBackColor = True
        '
        'txtInputPath
        '
        Me.txtInputPath.AccessibleDescription = ""
        Me.txtInputPath.AllowDrop = True
        Me.txtInputPath.Location = New System.Drawing.Point(6, 22)
        Me.txtInputPath.Name = "txtInputPath"
        Me.txtInputPath.ReadOnly = True
        Me.txtInputPath.Size = New System.Drawing.Size(705, 24)
        Me.txtInputPath.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.txtInputPath, "ここに読込フォルダをドラッグ&ドロップしてください。")
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnOutput)
        Me.GroupBox2.Controls.Add(Me.txtOutputPath)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 77)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(760, 59)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "出力フォルダ"
        '
        'btnOutput
        '
        Me.btnOutput.Location = New System.Drawing.Point(717, 24)
        Me.btnOutput.Name = "btnOutput"
        Me.btnOutput.Size = New System.Drawing.Size(37, 23)
        Me.btnOutput.TabIndex = 1
        Me.btnOutput.Text = "..."
        Me.btnOutput.UseVisualStyleBackColor = True
        '
        'txtOutputPath
        '
        Me.txtOutputPath.AllowDrop = True
        Me.txtOutputPath.Location = New System.Drawing.Point(6, 23)
        Me.txtOutputPath.Name = "txtOutputPath"
        Me.txtOutputPath.ReadOnly = True
        Me.txtOutputPath.Size = New System.Drawing.Size(705, 24)
        Me.txtOutputPath.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.txtOutputPath, "ここに出力フォルダをドラッグ&ドロップしてください。")
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btnExtension)
        Me.GroupBox3.Controls.Add(Me.btnDiskSize)
        Me.GroupBox3.Controls.Add(Me.cmbFormula)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.cmbDiskType)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 142)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(760, 50)
        Me.GroupBox3.TabIndex = 1
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "設定"
        '
        'btnExtension
        '
        Me.btnExtension.Location = New System.Drawing.Point(538, 16)
        Me.btnExtension.Name = "btnExtension"
        Me.btnExtension.Size = New System.Drawing.Size(105, 25)
        Me.btnExtension.TabIndex = 3
        Me.btnExtension.Text = "書き込み拡張子"
        Me.ToolTip1.SetToolTip(Me.btnExtension, "書き込む対象となるファイルの拡張子を選択します。")
        Me.btnExtension.UseVisualStyleBackColor = True
        '
        'btnDiskSize
        '
        Me.btnDiskSize.Location = New System.Drawing.Point(649, 16)
        Me.btnDiskSize.Name = "btnDiskSize"
        Me.btnDiskSize.Size = New System.Drawing.Size(105, 25)
        Me.btnDiskSize.TabIndex = 3
        Me.btnDiskSize.Text = "ディスクサイズ"
        Me.ToolTip1.SetToolTip(Me.btnDiskSize, "各ディスクサイズを指定します。")
        Me.btnDiskSize.UseVisualStyleBackColor = True
        '
        'cmbFormula
        '
        Me.cmbFormula.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFormula.FormattingEnabled = True
        Me.cmbFormula.Items.AddRange(New Object() {"ディスクサイズ優先", "フォルダ区切り優先"})
        Me.cmbFormula.Location = New System.Drawing.Point(256, 17)
        Me.cmbFormula.Name = "cmbFormula"
        Me.cmbFormula.Size = New System.Drawing.Size(137, 25)
        Me.cmbFormula.TabIndex = 1
        Me.ToolTip1.SetToolTip(Me.cmbFormula, "振り分け方式を選択します。")
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(171, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(85, 17)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "振り分け方式:"
        '
        'cmbDiskType
        '
        Me.cmbDiskType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDiskType.FormattingEnabled = True
        Me.cmbDiskType.Items.AddRange(New Object() {"CD-R", "DVD-R", "BD-R"})
        Me.cmbDiskType.Location = New System.Drawing.Point(91, 17)
        Me.cmbDiskType.Name = "cmbDiskType"
        Me.cmbDiskType.Size = New System.Drawing.Size(74, 25)
        Me.cmbDiskType.TabIndex = 1
        Me.ToolTip1.SetToolTip(Me.cmbDiskType, "ディスクタイプを選択します。")
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "ディスクタイプ:"
        '
        'lstResult
        '
        Me.lstResult.Font = New System.Drawing.Font("Meiryo UI", 7.0!)
        Me.lstResult.FormattingEnabled = True
        Me.lstResult.ItemHeight = 12
        Me.lstResult.Location = New System.Drawing.Point(12, 198)
        Me.lstResult.Name = "lstResult"
        Me.lstResult.Size = New System.Drawing.Size(760, 304)
        Me.lstResult.TabIndex = 2
        Me.ToolTip1.SetToolTip(Me.lstResult, "進捗状況")
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(697, 508)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 28)
        Me.btnCancel.TabIndex = 3
        Me.btnCancel.Text = "キャンセル"
        Me.ToolTip1.SetToolTip(Me.btnCancel, "処理を中断します。")
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnStart
        '
        Me.btnStart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnStart.Location = New System.Drawing.Point(616, 508)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(75, 28)
        Me.btnStart.TabIndex = 3
        Me.btnStart.Text = "開始"
        Me.ToolTip1.SetToolTip(Me.btnStart, "処理を開始します。")
        Me.btnStart.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Meiryo UI", 9.75!)
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(12, 519)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(89, 17)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "ディスクサイズ："
        '
        'lblDiskSize
        '
        Me.lblDiskSize.Font = New System.Drawing.Font("Meiryo UI", 9.75!)
        Me.lblDiskSize.ForeColor = System.Drawing.Color.Black
        Me.lblDiskSize.Location = New System.Drawing.Point(100, 519)
        Me.lblDiskSize.Name = "lblDiskSize"
        Me.lblDiskSize.Size = New System.Drawing.Size(129, 17)
        Me.lblDiskSize.TabIndex = 5
        Me.lblDiskSize.Text = "000000000000"
        Me.lblDiskSize.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Meiryo UI", 9.75!)
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(231, 519)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(37, 17)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "バイト"
        '
        'C1StatusBar
        '
        Me.C1StatusBar.AutoSizeElement = C1.Framework.AutoSizeElement.Width
        Me.C1StatusBar.LeftPaneItems.Add(Me.tsLabel)
        Me.C1StatusBar.Location = New System.Drawing.Point(0, 548)
        Me.C1StatusBar.Name = "C1StatusBar"
        Me.C1StatusBar.RightPaneItems.Add(Me.tsProgressBar)
        Me.C1StatusBar.RightPaneItems.Add(Me.btnBackMenu)
        Me.C1StatusBar.Size = New System.Drawing.Size(792, 23)
        '
        'tsLabel
        '
        Me.tsLabel.Name = "tsLabel"
        Me.tsLabel.Text = "指定のディスクサイズでフォルダ分けをします。"
        '
        'tsProgressBar
        '
        Me.tsProgressBar.Name = "tsProgressBar"
        Me.tsProgressBar.Width = 300
        '
        'btnBackMenu
        '
        Me.btnBackMenu.LargeImage = CType(resources.GetObject("btnBackMenu.LargeImage"), System.Drawing.Image)
        Me.btnBackMenu.Name = "btnBackMenu"
        Me.btnBackMenu.SmallImage = CType(resources.GetObject("btnBackMenu.SmallImage"), System.Drawing.Image)
        Me.btnBackMenu.Text = "戻る"
        '
        'frmDisk
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(792, 571)
        Me.Controls.Add(Me.C1StatusBar)
        Me.Controls.Add(Me.lblDiskSize)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btnStart)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.lstResult)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Meiryo UI", 9.75!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(800, 600)
        Me.MinimumSize = New System.Drawing.Size(800, 600)
        Me.Name = "frmDisk"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "DiskMaker"
        Me.VisualStyleHolder = C1.Win.C1Ribbon.VisualStyle.Office2010Black
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.C1StatusBar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnInput As System.Windows.Forms.Button
    Friend WithEvents txtInputPath As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnOutput As System.Windows.Forms.Button
    Friend WithEvents txtOutputPath As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbDiskType As System.Windows.Forms.ComboBox
    Friend WithEvents cmbFormula As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lstResult As System.Windows.Forms.ListBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnStart As System.Windows.Forms.Button
    Friend WithEvents btnDiskSize As System.Windows.Forms.Button
    Friend WithEvents btnExtension As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblDiskSize As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents C1StatusBar As C1.Win.C1Ribbon.C1StatusBar
    Friend WithEvents tsLabel As C1.Win.C1Ribbon.RibbonLabel
    Friend WithEvents tsProgressBar As C1.Win.C1Ribbon.RibbonProgressBar
    Friend WithEvents btnBackMenu As C1.Win.C1Ribbon.RibbonButton
End Class
