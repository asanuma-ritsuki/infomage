<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmRemove
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRemove))
        Me.C1StatusBar1 = New C1.Win.C1Ribbon.C1StatusBar()
        Me.RibbonLabel2111 = New C1.Win.C1Ribbon.RibbonLabel()
        Me.txtFileCount = New C1.Win.C1Ribbon.RibbonTextBox()
        Me.RibbonLabel211 = New C1.Win.C1Ribbon.RibbonLabel()
        Me.txtWarnningCount = New C1.Win.C1Ribbon.RibbonTextBox()
        Me.RibbonLabel21 = New C1.Win.C1Ribbon.RibbonLabel()
        Me.txtErrorCount = New C1.Win.C1Ribbon.RibbonTextBox()
        Me.RibbonLabel4 = New C1.Win.C1Ribbon.RibbonLabel()
        Me.pgbFiles = New C1.Win.C1Ribbon.RibbonProgressBar()
        Me.txtProgress = New C1.Win.C1Ribbon.RibbonLabel()
        Me.RibbonSeparator211 = New C1.Win.C1Ribbon.RibbonSeparator()
        Me.btnBackMenu = New C1.Win.C1Ribbon.RibbonButton()
        Me.PrintDialog = New System.Windows.Forms.PrintDialog()
        Me.fgrFileList = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.nudScanNumCol = New System.Windows.Forms.NumericUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtSrcPath = New System.Windows.Forms.TextBox()
        Me.btnStart = New C1.Win.C1Input.C1Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtDstPath = New System.Windows.Forms.TextBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnLogOutput = New C1.Win.C1Input.C1Button()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.fgrThumbnail = New C1.Win.C1FlexGrid.C1FlexGrid()
        CType(Me.C1StatusBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.fgrFileList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.nudScanNumCol, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnStart, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.btnLogOutput, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.fgrThumbnail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'C1StatusBar1
        '
        Me.C1StatusBar1.AutoSizeElement = C1.Framework.AutoSizeElement.Width
        Me.C1StatusBar1.LeftPaneItems.Add(Me.RibbonLabel2111)
        Me.C1StatusBar1.LeftPaneItems.Add(Me.txtFileCount)
        Me.C1StatusBar1.LeftPaneItems.Add(Me.RibbonLabel211)
        Me.C1StatusBar1.LeftPaneItems.Add(Me.txtWarnningCount)
        Me.C1StatusBar1.LeftPaneItems.Add(Me.RibbonLabel21)
        Me.C1StatusBar1.LeftPaneItems.Add(Me.txtErrorCount)
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
        'RibbonLabel2111
        '
        Me.RibbonLabel2111.Name = "RibbonLabel2111"
        Me.RibbonLabel2111.Text = "件数："
        '
        'txtFileCount
        '
        Me.txtFileCount.Enabled = False
        Me.txtFileCount.Name = "txtFileCount"
        Me.txtFileCount.Text = "0"
        '
        'RibbonLabel211
        '
        Me.RibbonLabel211.Name = "RibbonLabel211"
        Me.RibbonLabel211.Text = "ワーニング件数："
        '
        'txtWarnningCount
        '
        Me.txtWarnningCount.Enabled = False
        Me.txtWarnningCount.Name = "txtWarnningCount"
        Me.txtWarnningCount.Text = "0"
        '
        'RibbonLabel21
        '
        Me.RibbonLabel21.Name = "RibbonLabel21"
        Me.RibbonLabel21.Text = "エラー件数："
        '
        'txtErrorCount
        '
        Me.txtErrorCount.Enabled = False
        Me.txtErrorCount.Name = "txtErrorCount"
        Me.txtErrorCount.Text = "0"
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
        Me.pgbFiles.Width = 350
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
        Me.fgrFileList.Location = New System.Drawing.Point(0, 0)
        Me.fgrFileList.Name = "fgrFileList"
        Me.fgrFileList.Rows.DefaultSize = 18
        Me.fgrFileList.Size = New System.Drawing.Size(583, 583)
        Me.fgrFileList.TabIndex = 2
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.nudScanNumCol)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.txtSrcPath)
        Me.GroupBox2.Controls.Add(Me.btnStart)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox2.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(992, 82)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "白紙削除"
        '
        'nudScanNumCol
        '
        Me.nudScanNumCol.Font = New System.Drawing.Font("MS UI Gothic", 12.0!)
        Me.nudScanNumCol.Location = New System.Drawing.Point(808, 46)
        Me.nudScanNumCol.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.nudScanNumCol.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudScanNumCol.Name = "nudScanNumCol"
        Me.nudScanNumCol.Size = New System.Drawing.Size(59, 23)
        Me.nudScanNumCol.TabIndex = 18
        Me.nudScanNumCol.Value = New Decimal(New Integer() {3, 0, 0, 0})
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(23, 23)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(83, 12)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "イメージフォルダ："
        '
        'txtSrcPath
        '
        Me.txtSrcPath.AllowDrop = True
        Me.txtSrcPath.Font = New System.Drawing.Font("MS UI Gothic", 12.0!)
        Me.txtSrcPath.Location = New System.Drawing.Point(111, 16)
        Me.txtSrcPath.Name = "txtSrcPath"
        Me.txtSrcPath.Size = New System.Drawing.Size(869, 23)
        Me.txtSrcPath.TabIndex = 1
        Me.ToolTip1.SetToolTip(Me.txtSrcPath, "変換元のフォルダをドラッグ＆ドロップしてください。")
        '
        'btnStart
        '
        Me.btnStart.Location = New System.Drawing.Point(873, 45)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(107, 27)
        Me.btnStart.TabIndex = 17
        Me.btnStart.Text = "開始"
        Me.btnStart.UseVisualStyleBackColor = True
        Me.btnStart.VisualStyle = C1.Win.C1Input.VisualStyle.System
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(40, 22)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 12)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "ログ出力先："
        '
        'txtDstPath
        '
        Me.txtDstPath.AllowDrop = True
        Me.txtDstPath.Font = New System.Drawing.Font("MS UI Gothic", 12.0!)
        Me.txtDstPath.Location = New System.Drawing.Point(111, 16)
        Me.txtDstPath.Name = "txtDstPath"
        Me.txtDstPath.Size = New System.Drawing.Size(869, 23)
        Me.txtDstPath.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.txtDstPath, "変換先のフォルダをドラッグ＆ドロップしてください。")
        '
        'ToolTip1
        '
        Me.ToolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(992, 165)
        Me.Panel1.TabIndex = 19
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.btnLogOutput)
        Me.GroupBox1.Controls.Add(Me.txtDstPath)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 82)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(992, 82)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "ログ出力"
        '
        'btnLogOutput
        '
        Me.btnLogOutput.Location = New System.Drawing.Point(873, 45)
        Me.btnLogOutput.Name = "btnLogOutput"
        Me.btnLogOutput.Size = New System.Drawing.Size(107, 27)
        Me.btnLogOutput.TabIndex = 17
        Me.btnLogOutput.Text = "出力"
        Me.btnLogOutput.UseVisualStyleBackColor = True
        Me.btnLogOutput.VisualStyle = C1.Win.C1Input.VisualStyle.System
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 165)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.fgrFileList)
        Me.SplitContainer1.Panel1MinSize = 580
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.fgrThumbnail)
        Me.SplitContainer1.Panel2MinSize = 400
        Me.SplitContainer1.Size = New System.Drawing.Size(992, 583)
        Me.SplitContainer1.SplitterDistance = 583
        Me.SplitContainer1.TabIndex = 21
        '
        'fgrThumbnail
        '
        Me.fgrThumbnail.BackColor = System.Drawing.Color.Silver
        Me.fgrThumbnail.ColumnInfo = "2,0,0,0,0,90,Columns:0{AllowSorting:False;AllowDragging:False;AllowResizing:False" &
    ";AllowEditing:False;}" & Global.Microsoft.VisualBasic.ChrW(9) & "1{AllowSorting:False;AllowDragging:False;AllowResizing:Fal" &
    "se;AllowEditing:False;}" & Global.Microsoft.VisualBasic.ChrW(9)
        Me.fgrThumbnail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fgrThumbnail.Location = New System.Drawing.Point(0, 0)
        Me.fgrThumbnail.Name = "fgrThumbnail"
        Me.fgrThumbnail.Rows.DefaultSize = 18
        Me.fgrThumbnail.Rows.Fixed = 0
        Me.fgrThumbnail.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.fgrThumbnail.Size = New System.Drawing.Size(405, 583)
        Me.fgrThumbnail.StyleInfo = resources.GetString("fgrThumbnail.StyleInfo")
        Me.fgrThumbnail.TabIndex = 0
        '
        'frmRemove
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(992, 771)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.C1StatusBar1)
        Me.MinimumSize = New System.Drawing.Size(1000, 800)
        Me.Name = "frmRemove"
        Me.Text = "白紙削除"
        Me.VisualStyleHolder = C1.Win.C1Ribbon.VisualStyle.Office2010Black
        CType(Me.C1StatusBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.fgrFileList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.nudScanNumCol, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnStart, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.btnLogOutput, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.fgrThumbnail, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents btnBackMenu As C1.Win.C1Ribbon.RibbonButton
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents RibbonLabel21 As C1.Win.C1Ribbon.RibbonLabel
    Friend WithEvents RibbonSeparator211 As C1.Win.C1Ribbon.RibbonSeparator
    Friend WithEvents btnStart As C1.Win.C1Input.C1Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents txtErrorCount As C1.Win.C1Ribbon.RibbonTextBox
    Friend WithEvents RibbonLabel2111 As C1.Win.C1Ribbon.RibbonLabel
    Friend WithEvents txtFileCount As C1.Win.C1Ribbon.RibbonTextBox
    Friend WithEvents RibbonLabel211 As C1.Win.C1Ribbon.RibbonLabel
    Friend WithEvents txtWarnningCount As C1.Win.C1Ribbon.RibbonTextBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btnLogOutput As C1.Win.C1Input.C1Button
    Friend WithEvents nudScanNumCol As NumericUpDown
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents fgrThumbnail As C1.Win.C1FlexGrid.C1FlexGrid
End Class
