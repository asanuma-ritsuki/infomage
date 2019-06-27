<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmOCR
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmOCR))
        Me.C1Ribbon1 = New C1.Win.C1Ribbon.C1Ribbon()
        Me.RibbonApplicationMenu1 = New C1.Win.C1Ribbon.RibbonApplicationMenu()
        Me.RibbonBottomToolBar1 = New C1.Win.C1Ribbon.RibbonBottomToolBar()
        Me.RibbonConfigToolBar1 = New C1.Win.C1Ribbon.RibbonConfigToolBar()
        Me.RibbonQat1 = New C1.Win.C1Ribbon.RibbonQat()
        Me.RibbonTab1 = New C1.Win.C1Ribbon.RibbonTab()
        Me.RibbonGroup1 = New C1.Win.C1Ribbon.RibbonGroup()
        Me.btnInputFolder = New C1.Win.C1Ribbon.RibbonButton()
        Me.btnLogFolder = New C1.Win.C1Ribbon.RibbonGroup()
        Me.btnOutputFolder = New C1.Win.C1Ribbon.RibbonButton()
        Me.RibbonGroup3 = New C1.Win.C1Ribbon.RibbonGroup()
        Me.btnRun = New C1.Win.C1Ribbon.RibbonButton()
        Me.RibbonTopToolBar1 = New C1.Win.C1Ribbon.RibbonTopToolBar()
        Me.C1StatusBar1 = New C1.Win.C1Ribbon.C1StatusBar()
        Me.RibbonLabel1 = New C1.Win.C1Ribbon.RibbonLabel()
        Me.lblLoadFolderName = New C1.Win.C1Ribbon.RibbonLabel()
        Me.RibbonSeparator1 = New C1.Win.C1Ribbon.RibbonSeparator()
        Me.RibbonLabel3 = New C1.Win.C1Ribbon.RibbonLabel()
        Me.txtFileCount = New C1.Win.C1Ribbon.RibbonTextBox()
        Me.RibbonSeparator2 = New C1.Win.C1Ribbon.RibbonSeparator()
        Me.RibbonLabel2 = New C1.Win.C1Ribbon.RibbonLabel()
        Me.txtErrorCount = New C1.Win.C1Ribbon.RibbonTextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.fgrFileList = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.picSelect = New System.Windows.Forms.PictureBox()
        Me.btnBackMenu = New C1.Win.C1Ribbon.RibbonButton()
        CType(Me.C1Ribbon1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1StatusBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.fgrFileList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picSelect, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'C1Ribbon1
        '
        Me.C1Ribbon1.ApplicationMenuHolder = Me.RibbonApplicationMenu1
        Me.C1Ribbon1.AutoSizeElement = C1.Framework.AutoSizeElement.Width
        Me.C1Ribbon1.BottomToolBarHolder = Me.RibbonBottomToolBar1
        Me.C1Ribbon1.ConfigToolBarHolder = Me.RibbonConfigToolBar1
        Me.C1Ribbon1.Location = New System.Drawing.Point(0, 0)
        Me.C1Ribbon1.Name = "C1Ribbon1"
        Me.C1Ribbon1.QatHolder = Me.RibbonQat1
        Me.C1Ribbon1.Size = New System.Drawing.Size(992, 152)
        Me.C1Ribbon1.Tabs.Add(Me.RibbonTab1)
        Me.C1Ribbon1.TopToolBarHolder = Me.RibbonTopToolBar1
        '
        'RibbonApplicationMenu1
        '
        Me.RibbonApplicationMenu1.Name = "RibbonApplicationMenu1"
        Me.RibbonApplicationMenu1.Visible = False
        '
        'RibbonBottomToolBar1
        '
        Me.RibbonBottomToolBar1.Name = "RibbonBottomToolBar1"
        Me.RibbonBottomToolBar1.Visible = False
        '
        'RibbonConfigToolBar1
        '
        Me.RibbonConfigToolBar1.Name = "RibbonConfigToolBar1"
        Me.RibbonConfigToolBar1.Visible = False
        '
        'RibbonQat1
        '
        Me.RibbonQat1.Name = "RibbonQat1"
        Me.RibbonQat1.Visible = False
        '
        'RibbonTab1
        '
        Me.RibbonTab1.Groups.Add(Me.RibbonGroup1)
        Me.RibbonTab1.Groups.Add(Me.btnLogFolder)
        Me.RibbonTab1.Groups.Add(Me.RibbonGroup3)
        Me.RibbonTab1.Name = "RibbonTab1"
        Me.RibbonTab1.Text = "操作"
        '
        'RibbonGroup1
        '
        Me.RibbonGroup1.Items.Add(Me.btnInputFolder)
        Me.RibbonGroup1.Name = "RibbonGroup1"
        Me.RibbonGroup1.Text = "読み込み先"
        '
        'btnInputFolder
        '
        Me.btnInputFolder.LargeImage = CType(resources.GetObject("btnInputFolder.LargeImage"), System.Drawing.Image)
        Me.btnInputFolder.Name = "btnInputFolder"
        Me.btnInputFolder.SmallImage = CType(resources.GetObject("btnInputFolder.SmallImage"), System.Drawing.Image)
        Me.btnInputFolder.Text = "フォルダ選択"
        '
        'btnLogFolder
        '
        Me.btnLogFolder.Items.Add(Me.btnOutputFolder)
        Me.btnLogFolder.Name = "btnLogFolder"
        Me.btnLogFolder.Text = "ログ保存先"
        '
        'btnOutputFolder
        '
        Me.btnOutputFolder.LargeImage = CType(resources.GetObject("btnOutputFolder.LargeImage"), System.Drawing.Image)
        Me.btnOutputFolder.Name = "btnOutputFolder"
        Me.btnOutputFolder.SmallImage = CType(resources.GetObject("btnOutputFolder.SmallImage"), System.Drawing.Image)
        Me.btnOutputFolder.Text = "フォルダ選択"
        '
        'RibbonGroup3
        '
        Me.RibbonGroup3.Items.Add(Me.btnRun)
        Me.RibbonGroup3.Name = "RibbonGroup3"
        Me.RibbonGroup3.Text = "実行"
        '
        'btnRun
        '
        Me.btnRun.LargeImage = CType(resources.GetObject("btnRun.LargeImage"), System.Drawing.Image)
        Me.btnRun.Name = "btnRun"
        Me.btnRun.SmallImage = CType(resources.GetObject("btnRun.SmallImage"), System.Drawing.Image)
        Me.btnRun.Text = "OCR実行"
        '
        'RibbonTopToolBar1
        '
        Me.RibbonTopToolBar1.Name = "RibbonTopToolBar1"
        Me.RibbonTopToolBar1.Visible = False
        '
        'C1StatusBar1
        '
        Me.C1StatusBar1.AutoSizeElement = C1.Framework.AutoSizeElement.Width
        Me.C1StatusBar1.LeftPaneItems.Add(Me.RibbonLabel1)
        Me.C1StatusBar1.LeftPaneItems.Add(Me.lblLoadFolderName)
        Me.C1StatusBar1.LeftPaneItems.Add(Me.RibbonSeparator1)
        Me.C1StatusBar1.LeftPaneItems.Add(Me.RibbonLabel3)
        Me.C1StatusBar1.LeftPaneItems.Add(Me.txtFileCount)
        Me.C1StatusBar1.LeftPaneItems.Add(Me.RibbonSeparator2)
        Me.C1StatusBar1.LeftPaneItems.Add(Me.RibbonLabel2)
        Me.C1StatusBar1.LeftPaneItems.Add(Me.txtErrorCount)
        Me.C1StatusBar1.Location = New System.Drawing.Point(0, 771)
        Me.C1StatusBar1.Name = "C1StatusBar1"
        Me.C1StatusBar1.RightPaneItems.Add(Me.btnBackMenu)
        Me.C1StatusBar1.Size = New System.Drawing.Size(992, 23)
        '
        'RibbonLabel1
        '
        Me.RibbonLabel1.Name = "RibbonLabel1"
        Me.RibbonLabel1.Text = "読み込みフォルダ："
        '
        'lblLoadFolderName
        '
        Me.lblLoadFolderName.Name = "lblLoadFolderName"
        Me.lblLoadFolderName.Text = "未選択"
        '
        'RibbonSeparator1
        '
        Me.RibbonSeparator1.Name = "RibbonSeparator1"
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
        'Panel1
        '
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 152)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(269, 619)
        Me.Panel1.TabIndex = 4
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.fgrFileList)
        Me.Panel2.Controls.Add(Me.picSelect)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(269, 152)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(723, 619)
        Me.Panel2.TabIndex = 5
        '
        'fgrFileList
        '
        Me.fgrFileList.ColumnInfo = "5,1,0,0,0,90,Columns:1{Name:""ファイルパス"";Caption:""ファイルパス"";}" & Global.Microsoft.VisualBasic.ChrW(9) & "2{Name:""OCR結果"";Caption:""O" &
    "CR結果"";}" & Global.Microsoft.VisualBasic.ChrW(9) & "3{Name:""進捗"";Caption:""進捗"";}" & Global.Microsoft.VisualBasic.ChrW(9) & "4{Name:""完了時刻"";Caption:""完了時刻"";}" & Global.Microsoft.VisualBasic.ChrW(9)
        Me.fgrFileList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fgrFileList.Location = New System.Drawing.Point(0, 0)
        Me.fgrFileList.Name = "fgrFileList"
        Me.fgrFileList.Rows.DefaultSize = 18
        Me.fgrFileList.Size = New System.Drawing.Size(723, 619)
        Me.fgrFileList.TabIndex = 3
        '
        'picSelect
        '
        Me.picSelect.Dock = System.Windows.Forms.DockStyle.Fill
        Me.picSelect.Location = New System.Drawing.Point(0, 0)
        Me.picSelect.Name = "picSelect"
        Me.picSelect.Size = New System.Drawing.Size(723, 619)
        Me.picSelect.TabIndex = 0
        Me.picSelect.TabStop = False
        '
        'btnBackMenu
        '
        Me.btnBackMenu.LargeImage = CType(resources.GetObject("btnBackMenu.LargeImage"), System.Drawing.Image)
        Me.btnBackMenu.Name = "btnBackMenu"
        Me.btnBackMenu.SmallImage = CType(resources.GetObject("btnBackMenu.SmallImage"), System.Drawing.Image)
        Me.btnBackMenu.Text = "戻る"
        '
        'frmOCR
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(992, 794)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.C1StatusBar1)
        Me.Controls.Add(Me.C1Ribbon1)
        Me.MinimumSize = New System.Drawing.Size(1000, 800)
        Me.Name = "frmOCR"
        Me.Text = "OCR"
        Me.VisualStyleHolder = C1.Win.C1Ribbon.VisualStyle.Office2010Black
        CType(Me.C1Ribbon1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1StatusBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        CType(Me.fgrFileList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picSelect, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents C1Ribbon1 As C1.Win.C1Ribbon.C1Ribbon
    Friend WithEvents RibbonApplicationMenu1 As C1.Win.C1Ribbon.RibbonApplicationMenu
    Friend WithEvents RibbonBottomToolBar1 As C1.Win.C1Ribbon.RibbonBottomToolBar
    Friend WithEvents RibbonConfigToolBar1 As C1.Win.C1Ribbon.RibbonConfigToolBar
    Friend WithEvents RibbonQat1 As C1.Win.C1Ribbon.RibbonQat
    Friend WithEvents RibbonTab1 As C1.Win.C1Ribbon.RibbonTab
    Friend WithEvents RibbonGroup1 As C1.Win.C1Ribbon.RibbonGroup
    Friend WithEvents btnInputFolder As C1.Win.C1Ribbon.RibbonButton
    Friend WithEvents btnLogFolder As C1.Win.C1Ribbon.RibbonGroup
    Friend WithEvents btnOutputFolder As C1.Win.C1Ribbon.RibbonButton
    Friend WithEvents RibbonGroup3 As C1.Win.C1Ribbon.RibbonGroup
    Friend WithEvents btnRun As C1.Win.C1Ribbon.RibbonButton
    Friend WithEvents RibbonTopToolBar1 As C1.Win.C1Ribbon.RibbonTopToolBar
    Friend WithEvents C1StatusBar1 As C1.Win.C1Ribbon.C1StatusBar
    Friend WithEvents RibbonLabel1 As C1.Win.C1Ribbon.RibbonLabel
    Friend WithEvents lblLoadFolderName As C1.Win.C1Ribbon.RibbonLabel
    Friend WithEvents RibbonSeparator1 As C1.Win.C1Ribbon.RibbonSeparator
    Friend WithEvents RibbonLabel3 As C1.Win.C1Ribbon.RibbonLabel
    Friend WithEvents txtFileCount As C1.Win.C1Ribbon.RibbonTextBox
    Friend WithEvents RibbonSeparator2 As C1.Win.C1Ribbon.RibbonSeparator
    Friend WithEvents RibbonLabel2 As C1.Win.C1Ribbon.RibbonLabel
    Friend WithEvents txtErrorCount As C1.Win.C1Ribbon.RibbonTextBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents picSelect As PictureBox
    Friend WithEvents fgrFileList As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents btnBackMenu As C1.Win.C1Ribbon.RibbonButton
End Class
