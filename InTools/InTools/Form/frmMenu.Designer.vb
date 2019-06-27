<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMenu
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
		Dim C1DockingTab1 As C1.Win.C1Command.C1DockingTab
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMenu))
		Me.C1DockingTabPage1 = New C1.Win.C1Command.C1DockingTabPage()
		Me.fgrMenu = New C1.Win.C1FlexGrid.C1FlexGrid()
		Me.C1DockingTabPage2 = New C1.Win.C1Command.C1DockingTabPage()
		Me.fgrChangeLog = New C1.Win.C1FlexGrid.C1FlexGrid()
		Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
		Me.C1MainMenu1 = New C1.Win.C1Command.C1MainMenu()
		Me.C1CommandHolder1 = New C1.Win.C1Command.C1CommandHolder()
		Me.C1CommandMenu1 = New C1.Win.C1Command.C1CommandMenu()
		Me.C1CommandLink2 = New C1.Win.C1Command.C1CommandLink()
		Me.C1Command1 = New C1.Win.C1Command.C1Command()
		Me.C1CommandLink1 = New C1.Win.C1Command.C1CommandLink()
		C1DockingTab1 = New C1.Win.C1Command.C1DockingTab()
		CType(C1DockingTab1, System.ComponentModel.ISupportInitialize).BeginInit()
		C1DockingTab1.SuspendLayout()
		Me.C1DockingTabPage1.SuspendLayout()
		CType(Me.fgrMenu, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.C1DockingTabPage2.SuspendLayout()
		CType(Me.fgrChangeLog, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.C1CommandHolder1, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'C1DockingTab1
		'
		C1DockingTab1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
		C1DockingTab1.BorderStyle = System.Windows.Forms.BorderStyle.None
		C1DockingTab1.Controls.Add(Me.C1DockingTabPage1)
		C1DockingTab1.Controls.Add(Me.C1DockingTabPage2)
		C1DockingTab1.Dock = System.Windows.Forms.DockStyle.Fill
		C1DockingTab1.Location = New System.Drawing.Point(0, 20)
		C1DockingTab1.Name = "C1DockingTab1"
		C1DockingTab1.Size = New System.Drawing.Size(392, 599)
		C1DockingTab1.TabAreaBorder = True
		C1DockingTab1.TabIndex = 26
		C1DockingTab1.TabsSpacing = 5
		C1DockingTab1.VisualStyle = C1.Win.C1Command.VisualStyle.Office2010Black
		C1DockingTab1.VisualStyleBase = C1.Win.C1Command.VisualStyle.Office2010Black
		'
		'C1DockingTabPage1
		'
		Me.C1DockingTabPage1.BackgroundImage = Global.InTools.My.Resources.Resources.menu_bg
		Me.C1DockingTabPage1.Controls.Add(Me.fgrMenu)
		Me.C1DockingTabPage1.Location = New System.Drawing.Point(0, 23)
		Me.C1DockingTabPage1.Name = "C1DockingTabPage1"
		Me.C1DockingTabPage1.Size = New System.Drawing.Size(392, 576)
		Me.C1DockingTabPage1.TabIndex = 0
		Me.C1DockingTabPage1.Text = "Apps"
		'
		'fgrMenu
		'
		Me.fgrMenu.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
		Me.fgrMenu.AllowEditing = False
		Me.fgrMenu.BackColor = System.Drawing.Color.Transparent
		Me.fgrMenu.ColumnInfo = resources.GetString("fgrMenu.ColumnInfo")
		Me.fgrMenu.Cursor = System.Windows.Forms.Cursors.Default
		Me.fgrMenu.Dock = System.Windows.Forms.DockStyle.Fill
		Me.fgrMenu.ForeColor = System.Drawing.SystemColors.Window
		Me.fgrMenu.Location = New System.Drawing.Point(0, 0)
		Me.fgrMenu.Name = "fgrMenu"
		Me.fgrMenu.Rows.Count = 11
		Me.fgrMenu.Rows.DefaultSize = 18
		Me.fgrMenu.Rows.Fixed = 0
		Me.fgrMenu.Rows.MinSize = 60
		Me.fgrMenu.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.fgrMenu.ScrollOptions = C1.Win.C1FlexGrid.ScrollFlags.AlwaysVisible
		Me.fgrMenu.Size = New System.Drawing.Size(392, 576)
		Me.fgrMenu.StyleInfo = resources.GetString("fgrMenu.StyleInfo")
		Me.fgrMenu.TabIndex = 24
		Me.fgrMenu.UseCompatibleTextRendering = True
		Me.fgrMenu.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2010Black
		'
		'C1DockingTabPage2
		'
		Me.C1DockingTabPage2.BackgroundImage = Global.InTools.My.Resources.Resources.menu_bg
		Me.C1DockingTabPage2.CaptionText = "更新履歴"
		Me.C1DockingTabPage2.Controls.Add(Me.fgrChangeLog)
		Me.C1DockingTabPage2.Location = New System.Drawing.Point(0, 23)
		Me.C1DockingTabPage2.Name = "C1DockingTabPage2"
		Me.C1DockingTabPage2.Size = New System.Drawing.Size(392, 576)
		Me.C1DockingTabPage2.TabIndex = 1
		Me.C1DockingTabPage2.Text = "更新履歴"
		'
		'fgrChangeLog
		'
		Me.fgrChangeLog.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
		Me.fgrChangeLog.AllowEditing = False
		Me.fgrChangeLog.BackColor = System.Drawing.Color.Transparent
		Me.fgrChangeLog.ColumnInfo = resources.GetString("fgrChangeLog.ColumnInfo")
		Me.fgrChangeLog.Cursor = System.Windows.Forms.Cursors.Default
		Me.fgrChangeLog.Dock = System.Windows.Forms.DockStyle.Fill
		Me.fgrChangeLog.ForeColor = System.Drawing.SystemColors.Window
		Me.fgrChangeLog.Location = New System.Drawing.Point(0, 0)
		Me.fgrChangeLog.Name = "fgrChangeLog"
		Me.fgrChangeLog.Rows.Count = 0
		Me.fgrChangeLog.Rows.DefaultSize = 18
		Me.fgrChangeLog.Rows.Fixed = 0
		Me.fgrChangeLog.Rows.MinSize = 60
		Me.fgrChangeLog.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.fgrChangeLog.ScrollOptions = C1.Win.C1FlexGrid.ScrollFlags.AlwaysVisible
		Me.fgrChangeLog.Size = New System.Drawing.Size(392, 576)
		Me.fgrChangeLog.StyleInfo = resources.GetString("fgrChangeLog.StyleInfo")
		Me.fgrChangeLog.TabIndex = 25
		Me.fgrChangeLog.UseCompatibleTextRendering = True
		Me.fgrChangeLog.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2010Black
		'
		'OpenFileDialog1
		'
		Me.OpenFileDialog1.FileName = "OpenFileDialog1"
		'
		'C1MainMenu1
		'
		Me.C1MainMenu1.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
		Me.C1MainMenu1.CommandHolder = Me.C1CommandHolder1
		Me.C1MainMenu1.CommandLinks.AddRange(New C1.Win.C1Command.C1CommandLink() {Me.C1CommandLink1})
		Me.C1MainMenu1.Dock = System.Windows.Forms.DockStyle.Top
		Me.C1MainMenu1.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.C1MainMenu1.Location = New System.Drawing.Point(0, 0)
		Me.C1MainMenu1.Name = "C1MainMenu1"
		Me.C1MainMenu1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
		Me.C1MainMenu1.Size = New System.Drawing.Size(392, 20)
		Me.C1MainMenu1.VisualStyle = C1.Win.C1Command.VisualStyle.Custom
		Me.C1MainMenu1.VisualStyleBase = C1.Win.C1Command.VisualStyle.Office2010Black
		'
		'C1CommandHolder1
		'
		Me.C1CommandHolder1.Commands.Add(Me.C1CommandMenu1)
		Me.C1CommandHolder1.Commands.Add(Me.C1Command1)
		Me.C1CommandHolder1.Owner = Me
		'
		'C1CommandMenu1
		'
		Me.C1CommandMenu1.CommandLinks.AddRange(New C1.Win.C1Command.C1CommandLink() {Me.C1CommandLink2})
		Me.C1CommandMenu1.HideNonRecentLinks = False
		Me.C1CommandMenu1.Name = "C1CommandMenu1"
		Me.C1CommandMenu1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
		Me.C1CommandMenu1.ShortcutText = ""
		Me.C1CommandMenu1.Text = "・・・"
		'
		'C1CommandLink2
		'
		Me.C1CommandLink2.Command = Me.C1Command1
		'
		'C1Command1
		'
		Me.C1Command1.Name = "C1Command1"
		Me.C1Command1.ShortcutText = ""
		Me.C1Command1.Text = "接続設定"
		'
		'C1CommandLink1
		'
		Me.C1CommandLink1.Command = Me.C1CommandMenu1
		'
		'frmMenu
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
		Me.ClientSize = New System.Drawing.Size(392, 619)
		Me.Controls.Add(C1DockingTab1)
		Me.Controls.Add(Me.C1MainMenu1)
		Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
		Me.MaximizeBox = False
		Me.MaximumSize = New System.Drawing.Size(400, 650)
		Me.MinimizeBox = False
		Me.MinimumSize = New System.Drawing.Size(400, 650)
		Me.Name = "frmMenu"
		Me.Text = "InTools"
		Me.VisualStyleHolder = C1.Win.C1Ribbon.VisualStyle.Office2010Black
		CType(C1DockingTab1, System.ComponentModel.ISupportInitialize).EndInit()
		C1DockingTab1.ResumeLayout(False)
		Me.C1DockingTabPage1.ResumeLayout(False)
		CType(Me.fgrMenu, System.ComponentModel.ISupportInitialize).EndInit()
		Me.C1DockingTabPage2.ResumeLayout(False)
		CType(Me.fgrChangeLog, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.C1CommandHolder1, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)

	End Sub
	Friend WithEvents C1MainMenu1 As C1.Win.C1Command.C1MainMenu
    Friend WithEvents C1CommandHolder1 As C1.Win.C1Command.C1CommandHolder
    Friend WithEvents C1CommandMenu1 As C1.Win.C1Command.C1CommandMenu
    Friend WithEvents C1CommandLink2 As C1.Win.C1Command.C1CommandLink
    Friend WithEvents C1Command1 As C1.Win.C1Command.C1Command
    Friend WithEvents C1CommandLink1 As C1.Win.C1Command.C1CommandLink
    Private WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents fgrMenu As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents C1DockingTabPage1 As C1.Win.C1Command.C1DockingTabPage
    Friend WithEvents C1DockingTabPage2 As C1.Win.C1Command.C1DockingTabPage
    Friend WithEvents fgrChangeLog As C1.Win.C1FlexGrid.C1FlexGrid
End Class
