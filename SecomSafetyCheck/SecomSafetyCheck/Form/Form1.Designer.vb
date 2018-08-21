<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
		Me.C1MainMenu1 = New C1.Win.C1Command.C1MainMenu()
		Me.C1CommandHolder1 = New C1.Win.C1Command.C1CommandHolder()
		Me.c1CommandMenu1 = New C1.Win.C1Command.C1CommandMenu()
		Me.C1CommandLink3 = New C1.Win.C1Command.C1CommandLink()
		Me.menuExit = New C1.Win.C1Command.C1Command()
		Me.menuConnection = New C1.Win.C1Command.C1Command()
		Me.c1CommandMenu2 = New C1.Win.C1Command.C1CommandMenu()
		Me.C1CommandLink4 = New C1.Win.C1Command.C1CommandLink()
		Me.C1CommandLink1 = New C1.Win.C1Command.C1CommandLink()
		Me.C1CommandLink2 = New C1.Win.C1Command.C1CommandLink()
		Me.C1StatusBar1 = New C1.Win.C1Ribbon.C1StatusBar()
		Me.ProgressBar1 = New C1.Win.C1Ribbon.RibbonProgressBar()
		Me.lblProgress = New C1.Win.C1Ribbon.RibbonLabel()
		Me.RibbonSeparator1 = New C1.Win.C1Ribbon.RibbonSeparator()
		Me.lblView = New C1.Win.C1Ribbon.RibbonLabel()
		Me.lblUser = New C1.Win.C1Ribbon.RibbonLabel()
		Me.RibbonSeparator2 = New C1.Win.C1Ribbon.RibbonSeparator()
		Me.lblDate = New C1.Win.C1Ribbon.RibbonLabel()
		Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
		Me.C1DockingTab1 = New C1.Win.C1Command.C1DockingTab()
		Me.C1DockingTabPage1 = New C1.Win.C1Command.C1DockingTabPage()
		Me.Panel2 = New System.Windows.Forms.Panel()
		Me.GroupBox2 = New System.Windows.Forms.GroupBox()
		Me.lstResult = New System.Windows.Forms.ListBox()
		Me.Panel1 = New System.Windows.Forms.Panel()
		Me.GroupBox1 = New System.Windows.Forms.GroupBox()
		Me.btnOutput = New C1.Win.C1Input.C1Button()
		Me.btnStart = New C1.Win.C1Input.C1Button()
		Me.txtUsrSearchlistError = New System.Windows.Forms.TextBox()
		Me.txtUsrSearchlistCount = New System.Windows.Forms.TextBox()
		Me.Label12 = New System.Windows.Forms.Label()
		Me.Label13 = New System.Windows.Forms.Label()
		Me.Label14 = New System.Windows.Forms.Label()
		Me.txtUsrSearchlist = New System.Windows.Forms.TextBox()
		Me.txtManagerSearchlistError = New System.Windows.Forms.TextBox()
		Me.txtManagerSearchlistCount = New System.Windows.Forms.TextBox()
		Me.Label9 = New System.Windows.Forms.Label()
		Me.Label10 = New System.Windows.Forms.Label()
		Me.Label11 = New System.Windows.Forms.Label()
		Me.txtManagerSearchlist = New System.Windows.Forms.TextBox()
		Me.txtOrgError = New System.Windows.Forms.TextBox()
		Me.txtOrgCount = New System.Windows.Forms.TextBox()
		Me.Label6 = New System.Windows.Forms.Label()
		Me.Label7 = New System.Windows.Forms.Label()
		Me.Label8 = New System.Windows.Forms.Label()
		Me.txtOrg = New System.Windows.Forms.TextBox()
		Me.txtUsrError = New System.Windows.Forms.TextBox()
		Me.txtUsrCount = New System.Windows.Forms.TextBox()
		Me.Label5 = New System.Windows.Forms.Label()
		Me.Label4 = New System.Windows.Forms.Label()
		Me.Label3 = New System.Windows.Forms.Label()
		Me.txtUsr = New System.Windows.Forms.TextBox()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.txtLogFolder = New System.Windows.Forms.TextBox()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.txtImportFolder = New System.Windows.Forms.TextBox()
		Me.C1DockingTabPage2 = New C1.Win.C1Command.C1DockingTabPage()
		Me.Panel4 = New System.Windows.Forms.Panel()
		Me.GroupBox4 = New System.Windows.Forms.GroupBox()
		Me.C1FGridRecovery = New C1.Win.C1FlexGrid.C1FlexGrid()
		Me.Panel5 = New System.Windows.Forms.Panel()
		Me.btnUpdate = New C1.Win.C1Input.C1Button()
		Me.Panel3 = New System.Windows.Forms.Panel()
		Me.GroupBox3 = New System.Windows.Forms.GroupBox()
		Me.C1FGridCount = New C1.Win.C1FlexGrid.C1FlexGrid()
		Me.numWait = New System.Windows.Forms.NumericUpDown()
		Me.Label15 = New System.Windows.Forms.Label()
		CType(Me.C1CommandHolder1, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.C1StatusBar1, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.C1DockingTab1, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.C1DockingTab1.SuspendLayout()
		Me.C1DockingTabPage1.SuspendLayout()
		Me.Panel2.SuspendLayout()
		Me.GroupBox2.SuspendLayout()
		Me.Panel1.SuspendLayout()
		Me.GroupBox1.SuspendLayout()
		CType(Me.btnOutput, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.btnStart, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.C1DockingTabPage2.SuspendLayout()
		Me.Panel4.SuspendLayout()
		Me.GroupBox4.SuspendLayout()
		CType(Me.C1FGridRecovery, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.Panel5.SuspendLayout()
		CType(Me.btnUpdate, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.Panel3.SuspendLayout()
		Me.GroupBox3.SuspendLayout()
		CType(Me.C1FGridCount, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.numWait, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'C1MainMenu1
		'
		Me.C1MainMenu1.CommandHolder = Me.C1CommandHolder1
		Me.C1MainMenu1.CommandLinks.AddRange(New C1.Win.C1Command.C1CommandLink() {Me.C1CommandLink1, Me.C1CommandLink2})
		Me.C1MainMenu1.Dock = System.Windows.Forms.DockStyle.Top
		Me.C1MainMenu1.Location = New System.Drawing.Point(0, 0)
		Me.C1MainMenu1.Name = "C1MainMenu1"
		Me.C1MainMenu1.Size = New System.Drawing.Size(784, 27)
		Me.C1MainMenu1.VisualStyleBase = C1.Win.C1Command.VisualStyle.Office2007Blue
		'
		'C1CommandHolder1
		'
		Me.C1CommandHolder1.Commands.Add(Me.c1CommandMenu1)
		Me.C1CommandHolder1.Commands.Add(Me.menuConnection)
		Me.C1CommandHolder1.Commands.Add(Me.c1CommandMenu2)
		Me.C1CommandHolder1.Commands.Add(Me.menuExit)
		Me.C1CommandHolder1.Owner = Me
		'
		'c1CommandMenu1
		'
		Me.c1CommandMenu1.CommandLinks.AddRange(New C1.Win.C1Command.C1CommandLink() {Me.C1CommandLink3})
		Me.c1CommandMenu1.HideNonRecentLinks = False
		Me.c1CommandMenu1.Name = "c1CommandMenu1"
		Me.c1CommandMenu1.ShortcutText = ""
		Me.c1CommandMenu1.Text = "ファイル(&F)"
		Me.c1CommandMenu1.VisualStyle = C1.Win.C1Command.VisualStyle.Office2007Blue
		Me.c1CommandMenu1.VisualStyleBase = C1.Win.C1Command.VisualStyle.Office2007Blue
		'
		'C1CommandLink3
		'
		Me.C1CommandLink3.Command = Me.menuExit
		'
		'menuExit
		'
		Me.menuExit.Name = "menuExit"
		Me.menuExit.ShortcutText = ""
		Me.menuExit.Text = "終了(&X)"
		'
		'menuConnection
		'
		Me.menuConnection.Name = "menuConnection"
		Me.menuConnection.ShortcutText = ""
		Me.menuConnection.Text = "接続設定(&C)"
		'
		'c1CommandMenu2
		'
		Me.c1CommandMenu2.CommandLinks.AddRange(New C1.Win.C1Command.C1CommandLink() {Me.C1CommandLink4})
		Me.c1CommandMenu2.HideNonRecentLinks = False
		Me.c1CommandMenu2.Name = "c1CommandMenu2"
		Me.c1CommandMenu2.ShortcutText = ""
		Me.c1CommandMenu2.Text = "編集(&E)"
		Me.c1CommandMenu2.VisualStyle = C1.Win.C1Command.VisualStyle.Office2007Blue
		Me.c1CommandMenu2.VisualStyleBase = C1.Win.C1Command.VisualStyle.Office2007Blue
		'
		'C1CommandLink4
		'
		Me.C1CommandLink4.Command = Me.menuConnection
		Me.C1CommandLink4.Text = "接続設定(&C)"
		'
		'C1CommandLink1
		'
		Me.C1CommandLink1.Command = Me.c1CommandMenu1
		Me.C1CommandLink1.Text = "ファイル(&F)"
		'
		'C1CommandLink2
		'
		Me.C1CommandLink2.Command = Me.c1CommandMenu2
		Me.C1CommandLink2.SortOrder = 1
		Me.C1CommandLink2.Text = "ツール(&T)"
		'
		'C1StatusBar1
		'
		Me.C1StatusBar1.AutoSizeElement = C1.Framework.AutoSizeElement.Width
		Me.C1StatusBar1.LeftPaneItems.Add(Me.ProgressBar1)
		Me.C1StatusBar1.LeftPaneItems.Add(Me.lblProgress)
		Me.C1StatusBar1.LeftPaneItems.Add(Me.RibbonSeparator1)
		Me.C1StatusBar1.LeftPaneItems.Add(Me.lblView)
		Me.C1StatusBar1.Location = New System.Drawing.Point(0, 538)
		Me.C1StatusBar1.Name = "C1StatusBar1"
		Me.C1StatusBar1.RightPaneItems.Add(Me.lblUser)
		Me.C1StatusBar1.RightPaneItems.Add(Me.RibbonSeparator2)
		Me.C1StatusBar1.RightPaneItems.Add(Me.lblDate)
		Me.C1StatusBar1.Size = New System.Drawing.Size(784, 23)
		'
		'ProgressBar1
		'
		Me.ProgressBar1.Name = "ProgressBar1"
		'
		'lblProgress
		'
		Me.lblProgress.Name = "lblProgress"
		Me.lblProgress.Text = "00000 / 00000"
		'
		'RibbonSeparator1
		'
		Me.RibbonSeparator1.Name = "RibbonSeparator1"
		'
		'lblView
		'
		Me.lblView.Name = "lblView"
		Me.lblView.Text = "進捗表示"
		'
		'lblUser
		'
		Me.lblUser.Name = "lblUser"
		Me.lblUser.SmallImage = CType(resources.GetObject("lblUser.SmallImage"), System.Drawing.Image)
		Me.lblUser.Text = "User"
		'
		'RibbonSeparator2
		'
		Me.RibbonSeparator2.Name = "RibbonSeparator2"
		'
		'lblDate
		'
		Me.lblDate.Name = "lblDate"
		Me.lblDate.SmallImage = CType(resources.GetObject("lblDate.SmallImage"), System.Drawing.Image)
		Me.lblDate.Text = "Date"
		'
		'Timer1
		'
		'
		'C1DockingTab1
		'
		Me.C1DockingTab1.Controls.Add(Me.C1DockingTabPage1)
		Me.C1DockingTab1.Controls.Add(Me.C1DockingTabPage2)
		Me.C1DockingTab1.Dock = System.Windows.Forms.DockStyle.Fill
		Me.C1DockingTab1.Location = New System.Drawing.Point(0, 27)
		Me.C1DockingTab1.Name = "C1DockingTab1"
		Me.C1DockingTab1.Size = New System.Drawing.Size(784, 511)
		Me.C1DockingTab1.TabIndex = 5
		Me.C1DockingTab1.TabsSpacing = 5
		Me.C1DockingTab1.TabStyle = C1.Win.C1Command.TabStyleEnum.Office2007
		Me.C1DockingTab1.VisualStyle = C1.Win.C1Command.VisualStyle.Office2007Silver
		Me.C1DockingTab1.VisualStyleBase = C1.Win.C1Command.VisualStyle.Office2007Blue
		'
		'C1DockingTabPage1
		'
		Me.C1DockingTabPage1.Controls.Add(Me.Panel2)
		Me.C1DockingTabPage1.Controls.Add(Me.Panel1)
		Me.C1DockingTabPage1.Location = New System.Drawing.Point(1, 28)
		Me.C1DockingTabPage1.Name = "C1DockingTabPage1"
		Me.C1DockingTabPage1.Size = New System.Drawing.Size(782, 482)
		Me.C1DockingTabPage1.TabIndex = 0
		Me.C1DockingTabPage1.Text = "インポート"
		'
		'Panel2
		'
		Me.Panel2.Controls.Add(Me.GroupBox2)
		Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
		Me.Panel2.Location = New System.Drawing.Point(0, 239)
		Me.Panel2.Name = "Panel2"
		Me.Panel2.Size = New System.Drawing.Size(782, 243)
		Me.Panel2.TabIndex = 1
		'
		'GroupBox2
		'
		Me.GroupBox2.Controls.Add(Me.lstResult)
		Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
		Me.GroupBox2.Location = New System.Drawing.Point(0, 0)
		Me.GroupBox2.Name = "GroupBox2"
		Me.GroupBox2.Size = New System.Drawing.Size(782, 243)
		Me.GroupBox2.TabIndex = 0
		Me.GroupBox2.TabStop = False
		Me.GroupBox2.Text = "進捗"
		'
		'lstResult
		'
		Me.lstResult.Dock = System.Windows.Forms.DockStyle.Fill
		Me.lstResult.FormattingEnabled = True
		Me.lstResult.ItemHeight = 17
		Me.lstResult.Location = New System.Drawing.Point(3, 20)
		Me.lstResult.Name = "lstResult"
		Me.lstResult.Size = New System.Drawing.Size(776, 220)
		Me.lstResult.TabIndex = 1
		'
		'Panel1
		'
		Me.Panel1.Controls.Add(Me.GroupBox1)
		Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
		Me.Panel1.Location = New System.Drawing.Point(0, 0)
		Me.Panel1.Name = "Panel1"
		Me.Panel1.Size = New System.Drawing.Size(782, 239)
		Me.Panel1.TabIndex = 0
		'
		'GroupBox1
		'
		Me.GroupBox1.Controls.Add(Me.Label15)
		Me.GroupBox1.Controls.Add(Me.numWait)
		Me.GroupBox1.Controls.Add(Me.btnOutput)
		Me.GroupBox1.Controls.Add(Me.btnStart)
		Me.GroupBox1.Controls.Add(Me.txtUsrSearchlistError)
		Me.GroupBox1.Controls.Add(Me.txtUsrSearchlistCount)
		Me.GroupBox1.Controls.Add(Me.Label12)
		Me.GroupBox1.Controls.Add(Me.Label13)
		Me.GroupBox1.Controls.Add(Me.Label14)
		Me.GroupBox1.Controls.Add(Me.txtUsrSearchlist)
		Me.GroupBox1.Controls.Add(Me.txtManagerSearchlistError)
		Me.GroupBox1.Controls.Add(Me.txtManagerSearchlistCount)
		Me.GroupBox1.Controls.Add(Me.Label9)
		Me.GroupBox1.Controls.Add(Me.Label10)
		Me.GroupBox1.Controls.Add(Me.Label11)
		Me.GroupBox1.Controls.Add(Me.txtManagerSearchlist)
		Me.GroupBox1.Controls.Add(Me.txtOrgError)
		Me.GroupBox1.Controls.Add(Me.txtOrgCount)
		Me.GroupBox1.Controls.Add(Me.Label6)
		Me.GroupBox1.Controls.Add(Me.Label7)
		Me.GroupBox1.Controls.Add(Me.Label8)
		Me.GroupBox1.Controls.Add(Me.txtOrg)
		Me.GroupBox1.Controls.Add(Me.txtUsrError)
		Me.GroupBox1.Controls.Add(Me.txtUsrCount)
		Me.GroupBox1.Controls.Add(Me.Label5)
		Me.GroupBox1.Controls.Add(Me.Label4)
		Me.GroupBox1.Controls.Add(Me.Label3)
		Me.GroupBox1.Controls.Add(Me.txtUsr)
		Me.GroupBox1.Controls.Add(Me.Label2)
		Me.GroupBox1.Controls.Add(Me.txtLogFolder)
		Me.GroupBox1.Controls.Add(Me.Label1)
		Me.GroupBox1.Controls.Add(Me.txtImportFolder)
		Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
		Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
		Me.GroupBox1.Name = "GroupBox1"
		Me.GroupBox1.Size = New System.Drawing.Size(782, 239)
		Me.GroupBox1.TabIndex = 0
		Me.GroupBox1.TabStop = False
		Me.GroupBox1.Text = "インポート"
		'
		'btnOutput
		'
		Me.btnOutput.Location = New System.Drawing.Point(11, 204)
		Me.btnOutput.Name = "btnOutput"
		Me.btnOutput.Size = New System.Drawing.Size(75, 25)
		Me.btnOutput.TabIndex = 29
		Me.btnOutput.Text = "出　力"
		Me.btnOutput.UseVisualStyleBackColor = True
		'
		'btnStart
		'
		Me.btnStart.Location = New System.Drawing.Point(696, 204)
		Me.btnStart.Name = "btnStart"
		Me.btnStart.Size = New System.Drawing.Size(75, 25)
		Me.btnStart.TabIndex = 28
		Me.btnStart.Text = "開　始"
		Me.btnStart.UseVisualStyleBackColor = True
		'
		'txtUsrSearchlistError
		'
		Me.txtUsrSearchlistError.Location = New System.Drawing.Point(671, 174)
		Me.txtUsrSearchlistError.Name = "txtUsrSearchlistError"
		Me.txtUsrSearchlistError.ReadOnly = True
		Me.txtUsrSearchlistError.Size = New System.Drawing.Size(100, 24)
		Me.txtUsrSearchlistError.TabIndex = 27
		Me.txtUsrSearchlistError.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		'
		'txtUsrSearchlistCount
		'
		Me.txtUsrSearchlistCount.Location = New System.Drawing.Point(502, 173)
		Me.txtUsrSearchlistCount.Name = "txtUsrSearchlistCount"
		Me.txtUsrSearchlistCount.ReadOnly = True
		Me.txtUsrSearchlistCount.Size = New System.Drawing.Size(100, 24)
		Me.txtUsrSearchlistCount.TabIndex = 26
		Me.txtUsrSearchlistCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		'
		'Label12
		'
		Me.Label12.Location = New System.Drawing.Point(417, 173)
		Me.Label12.Name = "Label12"
		Me.Label12.Size = New System.Drawing.Size(79, 25)
		Me.Label12.TabIndex = 25
		Me.Label12.Text = "読込件数："
		Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'Label13
		'
		Me.Label13.Location = New System.Drawing.Point(608, 173)
		Me.Label13.Name = "Label13"
		Me.Label13.Size = New System.Drawing.Size(60, 25)
		Me.Label13.TabIndex = 24
		Me.Label13.Text = "エラー："
		Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'Label14
		'
		Me.Label14.Location = New System.Drawing.Point(6, 173)
		Me.Label14.Name = "Label14"
		Me.Label14.Size = New System.Drawing.Size(120, 25)
		Me.Label14.TabIndex = 23
		Me.Label14.Text = "あんぴくん："
		Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'txtUsrSearchlist
		'
		Me.txtUsrSearchlist.Location = New System.Drawing.Point(132, 173)
		Me.txtUsrSearchlist.Name = "txtUsrSearchlist"
		Me.txtUsrSearchlist.ReadOnly = True
		Me.txtUsrSearchlist.Size = New System.Drawing.Size(279, 24)
		Me.txtUsrSearchlist.TabIndex = 22
		'
		'txtManagerSearchlistError
		'
		Me.txtManagerSearchlistError.Location = New System.Drawing.Point(671, 144)
		Me.txtManagerSearchlistError.Name = "txtManagerSearchlistError"
		Me.txtManagerSearchlistError.ReadOnly = True
		Me.txtManagerSearchlistError.Size = New System.Drawing.Size(100, 24)
		Me.txtManagerSearchlistError.TabIndex = 21
		Me.txtManagerSearchlistError.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		'
		'txtManagerSearchlistCount
		'
		Me.txtManagerSearchlistCount.Location = New System.Drawing.Point(502, 143)
		Me.txtManagerSearchlistCount.Name = "txtManagerSearchlistCount"
		Me.txtManagerSearchlistCount.ReadOnly = True
		Me.txtManagerSearchlistCount.Size = New System.Drawing.Size(100, 24)
		Me.txtManagerSearchlistCount.TabIndex = 20
		Me.txtManagerSearchlistCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		'
		'Label9
		'
		Me.Label9.Location = New System.Drawing.Point(417, 143)
		Me.Label9.Name = "Label9"
		Me.Label9.Size = New System.Drawing.Size(79, 25)
		Me.Label9.TabIndex = 19
		Me.Label9.Text = "読込件数："
		Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'Label10
		'
		Me.Label10.Location = New System.Drawing.Point(608, 143)
		Me.Label10.Name = "Label10"
		Me.Label10.Size = New System.Drawing.Size(60, 25)
		Me.Label10.TabIndex = 18
		Me.Label10.Text = "エラー："
		Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'Label11
		'
		Me.Label11.Location = New System.Drawing.Point(6, 143)
		Me.Label11.Name = "Label11"
		Me.Label11.Size = New System.Drawing.Size(120, 25)
		Me.Label11.TabIndex = 17
		Me.Label11.Text = "管理者数："
		Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'txtManagerSearchlist
		'
		Me.txtManagerSearchlist.Location = New System.Drawing.Point(132, 143)
		Me.txtManagerSearchlist.Name = "txtManagerSearchlist"
		Me.txtManagerSearchlist.ReadOnly = True
		Me.txtManagerSearchlist.Size = New System.Drawing.Size(279, 24)
		Me.txtManagerSearchlist.TabIndex = 16
		'
		'txtOrgError
		'
		Me.txtOrgError.Location = New System.Drawing.Point(671, 114)
		Me.txtOrgError.Name = "txtOrgError"
		Me.txtOrgError.ReadOnly = True
		Me.txtOrgError.Size = New System.Drawing.Size(100, 24)
		Me.txtOrgError.TabIndex = 15
		Me.txtOrgError.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		'
		'txtOrgCount
		'
		Me.txtOrgCount.Location = New System.Drawing.Point(502, 113)
		Me.txtOrgCount.Name = "txtOrgCount"
		Me.txtOrgCount.ReadOnly = True
		Me.txtOrgCount.Size = New System.Drawing.Size(100, 24)
		Me.txtOrgCount.TabIndex = 14
		Me.txtOrgCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		'
		'Label6
		'
		Me.Label6.Location = New System.Drawing.Point(417, 113)
		Me.Label6.Name = "Label6"
		Me.Label6.Size = New System.Drawing.Size(79, 25)
		Me.Label6.TabIndex = 13
		Me.Label6.Text = "読込件数："
		Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'Label7
		'
		Me.Label7.Location = New System.Drawing.Point(608, 113)
		Me.Label7.Name = "Label7"
		Me.Label7.Size = New System.Drawing.Size(60, 25)
		Me.Label7.TabIndex = 12
		Me.Label7.Text = "エラー："
		Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'Label8
		'
		Me.Label8.Location = New System.Drawing.Point(6, 113)
		Me.Label8.Name = "Label8"
		Me.Label8.Size = New System.Drawing.Size(120, 25)
		Me.Label8.TabIndex = 11
		Me.Label8.Text = "事業所数："
		Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'txtOrg
		'
		Me.txtOrg.Location = New System.Drawing.Point(132, 113)
		Me.txtOrg.Name = "txtOrg"
		Me.txtOrg.ReadOnly = True
		Me.txtOrg.Size = New System.Drawing.Size(279, 24)
		Me.txtOrg.TabIndex = 10
		'
		'txtUsrError
		'
		Me.txtUsrError.Location = New System.Drawing.Point(671, 84)
		Me.txtUsrError.Name = "txtUsrError"
		Me.txtUsrError.ReadOnly = True
		Me.txtUsrError.Size = New System.Drawing.Size(100, 24)
		Me.txtUsrError.TabIndex = 9
		Me.txtUsrError.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		'
		'txtUsrCount
		'
		Me.txtUsrCount.Location = New System.Drawing.Point(502, 83)
		Me.txtUsrCount.Name = "txtUsrCount"
		Me.txtUsrCount.ReadOnly = True
		Me.txtUsrCount.Size = New System.Drawing.Size(100, 24)
		Me.txtUsrCount.TabIndex = 8
		Me.txtUsrCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		'
		'Label5
		'
		Me.Label5.Location = New System.Drawing.Point(417, 83)
		Me.Label5.Name = "Label5"
		Me.Label5.Size = New System.Drawing.Size(79, 25)
		Me.Label5.TabIndex = 7
		Me.Label5.Text = "読込件数："
		Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'Label4
		'
		Me.Label4.Location = New System.Drawing.Point(608, 83)
		Me.Label4.Name = "Label4"
		Me.Label4.Size = New System.Drawing.Size(60, 25)
		Me.Label4.TabIndex = 6
		Me.Label4.Text = "エラー："
		Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'Label3
		'
		Me.Label3.Location = New System.Drawing.Point(6, 83)
		Me.Label3.Name = "Label3"
		Me.Label3.Size = New System.Drawing.Size(120, 25)
		Me.Label3.TabIndex = 5
		Me.Label3.Text = "社員数："
		Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'txtUsr
		'
		Me.txtUsr.Location = New System.Drawing.Point(132, 83)
		Me.txtUsr.Name = "txtUsr"
		Me.txtUsr.ReadOnly = True
		Me.txtUsr.Size = New System.Drawing.Size(279, 24)
		Me.txtUsr.TabIndex = 4
		'
		'Label2
		'
		Me.Label2.Location = New System.Drawing.Point(6, 53)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(120, 25)
		Me.Label2.TabIndex = 3
		Me.Label2.Text = "ログフォルダ："
		Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'txtLogFolder
		'
		Me.txtLogFolder.AllowDrop = True
		Me.txtLogFolder.Location = New System.Drawing.Point(132, 53)
		Me.txtLogFolder.Name = "txtLogFolder"
		Me.txtLogFolder.Size = New System.Drawing.Size(639, 24)
		Me.txtLogFolder.TabIndex = 2
		'
		'Label1
		'
		Me.Label1.Location = New System.Drawing.Point(6, 23)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(120, 25)
		Me.Label1.TabIndex = 1
		Me.Label1.Text = "インポートフォルダ："
		Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'txtImportFolder
		'
		Me.txtImportFolder.AllowDrop = True
		Me.txtImportFolder.Location = New System.Drawing.Point(132, 23)
		Me.txtImportFolder.Name = "txtImportFolder"
		Me.txtImportFolder.Size = New System.Drawing.Size(639, 24)
		Me.txtImportFolder.TabIndex = 0
		'
		'C1DockingTabPage2
		'
		Me.C1DockingTabPage2.Controls.Add(Me.Panel4)
		Me.C1DockingTabPage2.Controls.Add(Me.Panel3)
		Me.C1DockingTabPage2.Location = New System.Drawing.Point(1, 28)
		Me.C1DockingTabPage2.Name = "C1DockingTabPage2"
		Me.C1DockingTabPage2.Size = New System.Drawing.Size(782, 482)
		Me.C1DockingTabPage2.TabIndex = 1
		Me.C1DockingTabPage2.Text = "処理結果"
		'
		'Panel4
		'
		Me.Panel4.Controls.Add(Me.GroupBox4)
		Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
		Me.Panel4.Location = New System.Drawing.Point(0, 169)
		Me.Panel4.Name = "Panel4"
		Me.Panel4.Size = New System.Drawing.Size(782, 313)
		Me.Panel4.TabIndex = 1
		'
		'GroupBox4
		'
		Me.GroupBox4.Controls.Add(Me.C1FGridRecovery)
		Me.GroupBox4.Controls.Add(Me.Panel5)
		Me.GroupBox4.Dock = System.Windows.Forms.DockStyle.Fill
		Me.GroupBox4.Location = New System.Drawing.Point(0, 0)
		Me.GroupBox4.Name = "GroupBox4"
		Me.GroupBox4.Size = New System.Drawing.Size(782, 313)
		Me.GroupBox4.TabIndex = 0
		Me.GroupBox4.TabStop = False
		Me.GroupBox4.Text = "事業所数アンマッチリカバリ"
		'
		'C1FGridRecovery
		'
		Me.C1FGridRecovery.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
		Me.C1FGridRecovery.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
		Me.C1FGridRecovery.AutoClipboard = True
		Me.C1FGridRecovery.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
		Me.C1FGridRecovery.ColumnInfo = resources.GetString("C1FGridRecovery.ColumnInfo")
		Me.C1FGridRecovery.Dock = System.Windows.Forms.DockStyle.Fill
		Me.C1FGridRecovery.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid
		Me.C1FGridRecovery.Font = New System.Drawing.Font("Meiryo UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.C1FGridRecovery.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcrossOut
		Me.C1FGridRecovery.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcrossOut
		Me.C1FGridRecovery.Location = New System.Drawing.Point(3, 20)
		Me.C1FGridRecovery.Name = "C1FGridRecovery"
		Me.C1FGridRecovery.Rows.Count = 1
		Me.C1FGridRecovery.Rows.DefaultSize = 20
		Me.C1FGridRecovery.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
		Me.C1FGridRecovery.ShowCellLabels = True
		Me.C1FGridRecovery.Size = New System.Drawing.Size(776, 253)
		Me.C1FGridRecovery.SubtotalPosition = C1.Win.C1FlexGrid.SubtotalPositionEnum.BelowData
		Me.C1FGridRecovery.TabIndex = 7
		Me.C1FGridRecovery.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.System
		'
		'Panel5
		'
		Me.Panel5.Controls.Add(Me.btnUpdate)
		Me.Panel5.Dock = System.Windows.Forms.DockStyle.Bottom
		Me.Panel5.Location = New System.Drawing.Point(3, 273)
		Me.Panel5.Name = "Panel5"
		Me.Panel5.Size = New System.Drawing.Size(776, 37)
		Me.Panel5.TabIndex = 0
		'
		'btnUpdate
		'
		Me.btnUpdate.Location = New System.Drawing.Point(693, 7)
		Me.btnUpdate.Name = "btnUpdate"
		Me.btnUpdate.Size = New System.Drawing.Size(75, 25)
		Me.btnUpdate.TabIndex = 29
		Me.btnUpdate.Text = "更　新"
		Me.btnUpdate.UseVisualStyleBackColor = True
		'
		'Panel3
		'
		Me.Panel3.Controls.Add(Me.GroupBox3)
		Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
		Me.Panel3.Location = New System.Drawing.Point(0, 0)
		Me.Panel3.Name = "Panel3"
		Me.Panel3.Size = New System.Drawing.Size(782, 169)
		Me.Panel3.TabIndex = 0
		'
		'GroupBox3
		'
		Me.GroupBox3.Controls.Add(Me.C1FGridCount)
		Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Fill
		Me.GroupBox3.Location = New System.Drawing.Point(0, 0)
		Me.GroupBox3.Name = "GroupBox3"
		Me.GroupBox3.Size = New System.Drawing.Size(782, 169)
		Me.GroupBox3.TabIndex = 0
		Me.GroupBox3.TabStop = False
		Me.GroupBox3.Text = "件数表"
		'
		'C1FGridCount
		'
		Me.C1FGridCount.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
		Me.C1FGridCount.AllowEditing = False
		Me.C1FGridCount.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
		Me.C1FGridCount.AutoClipboard = True
		Me.C1FGridCount.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
		Me.C1FGridCount.ColumnInfo = resources.GetString("C1FGridCount.ColumnInfo")
		Me.C1FGridCount.Dock = System.Windows.Forms.DockStyle.Fill
		Me.C1FGridCount.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid
		Me.C1FGridCount.Font = New System.Drawing.Font("Meiryo UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.C1FGridCount.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcrossOut
		Me.C1FGridCount.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcrossOut
		Me.C1FGridCount.Location = New System.Drawing.Point(3, 20)
		Me.C1FGridCount.Name = "C1FGridCount"
		Me.C1FGridCount.Rows.Count = 7
		Me.C1FGridCount.Rows.DefaultSize = 20
		Me.C1FGridCount.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
		Me.C1FGridCount.ShowCellLabels = True
		Me.C1FGridCount.Size = New System.Drawing.Size(776, 146)
		Me.C1FGridCount.SubtotalPosition = C1.Win.C1FlexGrid.SubtotalPositionEnum.BelowData
		Me.C1FGridCount.TabIndex = 6
		Me.C1FGridCount.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.System
		'
		'numWait
		'
		Me.numWait.Location = New System.Drawing.Point(502, 206)
		Me.numWait.Maximum = New Decimal(New Integer() {5, 0, 0, 0})
		Me.numWait.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
		Me.numWait.Name = "numWait"
		Me.numWait.Size = New System.Drawing.Size(100, 24)
		Me.numWait.TabIndex = 30
		Me.numWait.Value = New Decimal(New Integer() {2, 0, 0, 0})
		'
		'Label15
		'
		Me.Label15.Location = New System.Drawing.Point(417, 206)
		Me.Label15.Name = "Label15"
		Me.Label15.Size = New System.Drawing.Size(79, 25)
		Me.Label15.TabIndex = 31
		Me.Label15.Text = "ウェイト："
		Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'Form1
		'
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
		Me.ClientSize = New System.Drawing.Size(784, 561)
		Me.Controls.Add(Me.C1DockingTab1)
		Me.Controls.Add(Me.C1StatusBar1)
		Me.Controls.Add(Me.C1MainMenu1)
		Me.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
		Me.Name = "Form1"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "Form1"
		CType(Me.C1CommandHolder1, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.C1StatusBar1, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.C1DockingTab1, System.ComponentModel.ISupportInitialize).EndInit()
		Me.C1DockingTab1.ResumeLayout(False)
		Me.C1DockingTabPage1.ResumeLayout(False)
		Me.Panel2.ResumeLayout(False)
		Me.GroupBox2.ResumeLayout(False)
		Me.Panel1.ResumeLayout(False)
		Me.GroupBox1.ResumeLayout(False)
		Me.GroupBox1.PerformLayout()
		CType(Me.btnOutput, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.btnStart, System.ComponentModel.ISupportInitialize).EndInit()
		Me.C1DockingTabPage2.ResumeLayout(False)
		Me.Panel4.ResumeLayout(False)
		Me.GroupBox4.ResumeLayout(False)
		CType(Me.C1FGridRecovery, System.ComponentModel.ISupportInitialize).EndInit()
		Me.Panel5.ResumeLayout(False)
		CType(Me.btnUpdate, System.ComponentModel.ISupportInitialize).EndInit()
		Me.Panel3.ResumeLayout(False)
		Me.GroupBox3.ResumeLayout(False)
		CType(Me.C1FGridCount, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.numWait, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	Friend WithEvents C1MainMenu1 As C1.Win.C1Command.C1MainMenu
	Friend WithEvents C1CommandHolder1 As C1.Win.C1Command.C1CommandHolder
	Friend WithEvents C1CommandLink1 As C1.Win.C1Command.C1CommandLink
	Friend WithEvents c1CommandMenu1 As C1.Win.C1Command.C1CommandMenu
	Friend WithEvents menuConnection As C1.Win.C1Command.C1Command
	Friend WithEvents c1CommandMenu2 As C1.Win.C1Command.C1CommandMenu
	Friend WithEvents C1CommandLink4 As C1.Win.C1Command.C1CommandLink
	Friend WithEvents C1CommandLink2 As C1.Win.C1Command.C1CommandLink
	Friend WithEvents C1CommandLink3 As C1.Win.C1Command.C1CommandLink
	Friend WithEvents menuExit As C1.Win.C1Command.C1Command
	Friend WithEvents C1StatusBar1 As C1.Win.C1Ribbon.C1StatusBar
	Friend WithEvents ProgressBar1 As C1.Win.C1Ribbon.RibbonProgressBar
	Friend WithEvents lblProgress As C1.Win.C1Ribbon.RibbonLabel
	Friend WithEvents RibbonSeparator1 As C1.Win.C1Ribbon.RibbonSeparator
	Friend WithEvents lblView As C1.Win.C1Ribbon.RibbonLabel
	Friend WithEvents Timer1 As Timer
	Friend WithEvents lblUser As C1.Win.C1Ribbon.RibbonLabel
	Friend WithEvents RibbonSeparator2 As C1.Win.C1Ribbon.RibbonSeparator
	Friend WithEvents lblDate As C1.Win.C1Ribbon.RibbonLabel
	Friend WithEvents C1DockingTab1 As C1.Win.C1Command.C1DockingTab
	Friend WithEvents C1DockingTabPage1 As C1.Win.C1Command.C1DockingTabPage
	Friend WithEvents C1DockingTabPage2 As C1.Win.C1Command.C1DockingTabPage
	Friend WithEvents Panel2 As Panel
	Friend WithEvents GroupBox2 As GroupBox
	Friend WithEvents Panel1 As Panel
	Friend WithEvents GroupBox1 As GroupBox
	Friend WithEvents lstResult As ListBox
	Friend WithEvents txtImportFolder As TextBox
	Friend WithEvents Label1 As Label
	Friend WithEvents Label2 As Label
	Friend WithEvents txtLogFolder As TextBox
	Friend WithEvents txtUsrCount As TextBox
	Friend WithEvents Label5 As Label
	Friend WithEvents Label4 As Label
	Friend WithEvents Label3 As Label
	Friend WithEvents txtUsr As TextBox
	Friend WithEvents txtUsrError As TextBox
	Friend WithEvents txtUsrSearchlistError As TextBox
	Friend WithEvents txtUsrSearchlistCount As TextBox
	Friend WithEvents Label12 As Label
	Friend WithEvents Label13 As Label
	Friend WithEvents Label14 As Label
	Friend WithEvents txtUsrSearchlist As TextBox
	Friend WithEvents txtManagerSearchlistError As TextBox
	Friend WithEvents txtManagerSearchlistCount As TextBox
	Friend WithEvents Label9 As Label
	Friend WithEvents Label10 As Label
	Friend WithEvents Label11 As Label
	Friend WithEvents txtManagerSearchlist As TextBox
	Friend WithEvents txtOrgError As TextBox
	Friend WithEvents txtOrgCount As TextBox
	Friend WithEvents Label6 As Label
	Friend WithEvents Label7 As Label
	Friend WithEvents Label8 As Label
	Friend WithEvents txtOrg As TextBox
	Friend WithEvents btnOutput As C1.Win.C1Input.C1Button
	Friend WithEvents btnStart As C1.Win.C1Input.C1Button
	Friend WithEvents Panel4 As Panel
	Friend WithEvents GroupBox4 As GroupBox
	Friend WithEvents Panel3 As Panel
	Friend WithEvents GroupBox3 As GroupBox
	Friend WithEvents C1FGridRecovery As C1.Win.C1FlexGrid.C1FlexGrid
	Friend WithEvents Panel5 As Panel
	Friend WithEvents btnUpdate As C1.Win.C1Input.C1Button
	Friend WithEvents C1FGridCount As C1.Win.C1FlexGrid.C1FlexGrid
	Friend WithEvents Label15 As Label
	Friend WithEvents numWait As NumericUpDown
End Class
