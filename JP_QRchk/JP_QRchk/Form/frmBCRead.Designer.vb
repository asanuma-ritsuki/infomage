<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBCRead
    Inherits System.Windows.Forms.Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBCRead))
        Me.txtScan = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btnEnd = New C1.Win.C1Input.C1Button()
        Me.btnStart = New C1.Win.C1Input.C1Button()
        Me.lblTotal_l = New C1.Win.C1Ribbon.RibbonLabel()
        Me.RibbonLabel7 = New C1.Win.C1Ribbon.RibbonLabel()
        Me.RibbonSeparator12 = New C1.Win.C1Ribbon.RibbonSeparator()
        Me.lblTotal_r = New C1.Win.C1Ribbon.RibbonLabel()
        Me.RibbonLabel5 = New C1.Win.C1Ribbon.RibbonLabel()
        Me.RibbonSeparator11 = New C1.Win.C1Ribbon.RibbonSeparator()
        Me.lblTotal_ll = New C1.Win.C1Ribbon.RibbonLabel()
        Me.RibbonLabel3 = New C1.Win.C1Ribbon.RibbonLabel()
        Me.RibbonSeparator1 = New C1.Win.C1Ribbon.RibbonSeparator()
        Me.lblTotal_rl = New C1.Win.C1Ribbon.RibbonLabel()
        Me.RibbonLabel1 = New C1.Win.C1Ribbon.RibbonLabel()
        Me.C1StatusBar1 = New C1.Win.C1Ribbon.C1StatusBar()
        Me.lblCount_rl = New C1.Win.C1Ribbon.RibbonLabel()
        Me.lblCntResultList2 = New C1.Win.C1Ribbon.RibbonLabel()
        Me.lblCount_ll = New C1.Win.C1Ribbon.RibbonLabel()
        Me.lblCntResultList4 = New C1.Win.C1Ribbon.RibbonLabel()
        Me.lblCount_r = New C1.Win.C1Ribbon.RibbonLabel()
        Me.lblCntResultList6 = New C1.Win.C1Ribbon.RibbonLabel()
        Me.lblCount_l = New C1.Win.C1Ribbon.RibbonLabel()
        Me.lblCntResultList8 = New C1.Win.C1Ribbon.RibbonLabel()
        Me.btnSQL = New C1.Win.C1Ribbon.RibbonButton()
        Me.cmbLotSelect = New System.Windows.Forms.ComboBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtLotProgress = New System.Windows.Forms.TextBox()
        Me.txtLabelProgress = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.prgLot = New System.Windows.Forms.ProgressBar()
        Me.prgLabel = New System.Windows.Forms.ProgressBar()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.fgrLabel = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.fgrBCRead = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.GroupBox3.SuspendLayout()
        CType(Me.btnEnd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnStart, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1StatusBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        CType(Me.fgrLabel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.fgrBCRead, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtScan
        '
        Me.txtScan.BackColor = System.Drawing.SystemColors.Info
        Me.txtScan.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtScan.Font = New System.Drawing.Font("Meiryo UI", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtScan.Location = New System.Drawing.Point(3, 15)
        Me.txtScan.Name = "txtScan"
        Me.txtScan.Size = New System.Drawing.Size(424, 34)
        Me.txtScan.TabIndex = 6
        Me.txtScan.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txtScan)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox3.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(430, 55)
        Me.GroupBox3.TabIndex = 8
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "QR読取り"
        '
        'btnEnd
        '
        Me.btnEnd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEnd.Location = New System.Drawing.Point(334, 8)
        Me.btnEnd.Name = "btnEnd"
        Me.btnEnd.Size = New System.Drawing.Size(75, 29)
        Me.btnEnd.TabIndex = 11
        Me.btnEnd.Text = "終了"
        Me.btnEnd.UseVisualStyleBackColor = True
        '
        'btnStart
        '
        Me.btnStart.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnStart.Location = New System.Drawing.Point(253, 8)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(75, 29)
        Me.btnStart.TabIndex = 12
        Me.btnStart.Text = "開始"
        Me.btnStart.UseVisualStyleBackColor = True
        '
        'lblTotal_l
        '
        Me.lblTotal_l.Name = "lblTotal_l"
        Me.lblTotal_l.Text = "0000"
        '
        'RibbonLabel7
        '
        Me.RibbonLabel7.Name = "RibbonLabel7"
        Me.RibbonLabel7.Text = "リーフレット："
        '
        'RibbonSeparator12
        '
        Me.RibbonSeparator12.Name = "RibbonSeparator12"
        '
        'lblTotal_r
        '
        Me.lblTotal_r.Name = "lblTotal_r"
        Me.lblTotal_r.Text = "0000"
        '
        'RibbonLabel5
        '
        Me.RibbonLabel5.Name = "RibbonLabel5"
        Me.RibbonLabel5.Text = "判定票："
        '
        'RibbonSeparator11
        '
        Me.RibbonSeparator11.Name = "RibbonSeparator11"
        '
        'lblTotal_ll
        '
        Me.lblTotal_ll.Name = "lblTotal_ll"
        Me.lblTotal_ll.Text = "0000"
        '
        'RibbonLabel3
        '
        Me.RibbonLabel3.Name = "RibbonLabel3"
        Me.RibbonLabel3.Text = "保健指導対象名簿："
        '
        'RibbonSeparator1
        '
        Me.RibbonSeparator1.Name = "RibbonSeparator1"
        '
        'lblTotal_rl
        '
        Me.lblTotal_rl.Name = "lblTotal_rl"
        Me.lblTotal_rl.Text = "0000"
        '
        'RibbonLabel1
        '
        Me.RibbonLabel1.Name = "RibbonLabel1"
        Me.RibbonLabel1.Text = "対象者一覧："
        '
        'C1StatusBar1
        '
        Me.C1StatusBar1.AutoSizeElement = C1.Framework.AutoSizeElement.Width
        Me.C1StatusBar1.LeftPaneItems.Add(Me.RibbonLabel1)
        Me.C1StatusBar1.LeftPaneItems.Add(Me.lblCount_rl)
        Me.C1StatusBar1.LeftPaneItems.Add(Me.lblCntResultList2)
        Me.C1StatusBar1.LeftPaneItems.Add(Me.lblTotal_rl)
        Me.C1StatusBar1.LeftPaneItems.Add(Me.RibbonSeparator1)
        Me.C1StatusBar1.LeftPaneItems.Add(Me.RibbonLabel3)
        Me.C1StatusBar1.LeftPaneItems.Add(Me.lblCount_ll)
        Me.C1StatusBar1.LeftPaneItems.Add(Me.lblCntResultList4)
        Me.C1StatusBar1.LeftPaneItems.Add(Me.lblTotal_ll)
        Me.C1StatusBar1.LeftPaneItems.Add(Me.RibbonSeparator11)
        Me.C1StatusBar1.LeftPaneItems.Add(Me.RibbonLabel5)
        Me.C1StatusBar1.LeftPaneItems.Add(Me.lblCount_r)
        Me.C1StatusBar1.LeftPaneItems.Add(Me.lblCntResultList6)
        Me.C1StatusBar1.LeftPaneItems.Add(Me.lblTotal_r)
        Me.C1StatusBar1.LeftPaneItems.Add(Me.RibbonSeparator12)
        Me.C1StatusBar1.LeftPaneItems.Add(Me.RibbonLabel7)
        Me.C1StatusBar1.LeftPaneItems.Add(Me.lblCount_l)
        Me.C1StatusBar1.LeftPaneItems.Add(Me.lblCntResultList8)
        Me.C1StatusBar1.LeftPaneItems.Add(Me.lblTotal_l)
        Me.C1StatusBar1.Location = New System.Drawing.Point(0, 540)
        Me.C1StatusBar1.Name = "C1StatusBar1"
        Me.C1StatusBar1.RightPaneItems.Add(Me.btnSQL)
        Me.C1StatusBar1.Size = New System.Drawing.Size(884, 22)
        Me.C1StatusBar1.VisualStyle = C1.Win.C1Ribbon.VisualStyle.Windows7
        '
        'lblCount_rl
        '
        Me.lblCount_rl.Name = "lblCount_rl"
        Me.lblCount_rl.Text = "0000"
        '
        'lblCntResultList2
        '
        Me.lblCntResultList2.Name = "lblCntResultList2"
        Me.lblCntResultList2.Text = "/"
        '
        'lblCount_ll
        '
        Me.lblCount_ll.Name = "lblCount_ll"
        Me.lblCount_ll.Text = "0000"
        '
        'lblCntResultList4
        '
        Me.lblCntResultList4.Name = "lblCntResultList4"
        Me.lblCntResultList4.Text = "/"
        '
        'lblCount_r
        '
        Me.lblCount_r.Name = "lblCount_r"
        Me.lblCount_r.Text = "0000"
        '
        'lblCntResultList6
        '
        Me.lblCntResultList6.Name = "lblCntResultList6"
        Me.lblCntResultList6.Text = "/"
        '
        'lblCount_l
        '
        Me.lblCount_l.Name = "lblCount_l"
        Me.lblCount_l.Text = "0000"
        '
        'lblCntResultList8
        '
        Me.lblCntResultList8.Name = "lblCntResultList8"
        Me.lblCntResultList8.Text = "/"
        '
        'btnSQL
        '
        Me.btnSQL.Name = "btnSQL"
        Me.btnSQL.SmallImage = CType(resources.GetObject("btnSQL.SmallImage"), System.Drawing.Image)
        Me.btnSQL.Text = "接続設定"
        '
        'cmbLotSelect
        '
        Me.cmbLotSelect.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbLotSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbLotSelect.Font = New System.Drawing.Font("MS UI Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbLotSelect.FormattingEnabled = True
        Me.cmbLotSelect.Location = New System.Drawing.Point(12, 8)
        Me.cmbLotSelect.Name = "cmbLotSelect"
        Me.cmbLotSelect.Size = New System.Drawing.Size(235, 29)
        Me.cmbLotSelect.TabIndex = 14
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Panel5)
        Me.GroupBox2.Controls.Add(Me.TableLayoutPanel1)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox2.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(450, 122)
        Me.GroupBox2.TabIndex = 16
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "ロット情報"
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.cmbLotSelect)
        Me.Panel5.Controls.Add(Me.btnStart)
        Me.Panel5.Controls.Add(Me.btnEnd)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel5.Location = New System.Drawing.Point(3, 15)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(444, 40)
        Me.Panel5.TabIndex = 15
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.73491!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 79.26509!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 83.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.txtLotProgress, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.txtLabelProgress, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.prgLot, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.prgLabel, 1, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 70)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 51.02041!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 48.97959!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(444, 49)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.Location = New System.Drawing.Point(3, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 24)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "帳票進捗："
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtLotProgress
        '
        Me.txtLotProgress.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtLotProgress.Enabled = False
        Me.txtLotProgress.Location = New System.Drawing.Point(363, 3)
        Me.txtLotProgress.Name = "txtLotProgress"
        Me.txtLotProgress.Size = New System.Drawing.Size(78, 19)
        Me.txtLotProgress.TabIndex = 1
        Me.txtLotProgress.Text = "0/0"
        Me.txtLotProgress.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtLabelProgress
        '
        Me.txtLabelProgress.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtLabelProgress.Enabled = False
        Me.txtLabelProgress.Location = New System.Drawing.Point(363, 28)
        Me.txtLabelProgress.Name = "txtLabelProgress"
        Me.txtLabelProgress.Size = New System.Drawing.Size(78, 19)
        Me.txtLabelProgress.TabIndex = 2
        Me.txtLabelProgress.Text = "0/0"
        Me.txtLabelProgress.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 25)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "封筒進捗："
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'prgLot
        '
        Me.prgLot.Dock = System.Windows.Forms.DockStyle.Fill
        Me.prgLot.Location = New System.Drawing.Point(77, 3)
        Me.prgLot.Name = "prgLot"
        Me.prgLot.Size = New System.Drawing.Size(280, 19)
        Me.prgLot.TabIndex = 4
        '
        'prgLabel
        '
        Me.prgLabel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.prgLabel.Location = New System.Drawing.Point(77, 28)
        Me.prgLabel.Name = "prgLabel"
        Me.prgLabel.Size = New System.Drawing.Size(280, 18)
        Me.prgLabel.TabIndex = 4
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.fgrLabel)
        Me.GroupBox5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox5.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(450, 418)
        Me.GroupBox5.TabIndex = 17
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "ロット内ラベル一覧"
        '
        'fgrLabel
        '
        Me.fgrLabel.AllowEditing = False
        Me.fgrLabel.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.fgrLabel.BackColor = System.Drawing.Color.White
        Me.fgrLabel.ColumnInfo = resources.GetString("fgrLabel.ColumnInfo")
        Me.fgrLabel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fgrLabel.Location = New System.Drawing.Point(3, 15)
        Me.fgrLabel.Name = "fgrLabel"
        Me.fgrLabel.Rows.DefaultSize = 18
        Me.fgrLabel.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.fgrLabel.ShowCellLabels = True
        Me.fgrLabel.Size = New System.Drawing.Size(444, 400)
        Me.fgrLabel.StyleInfo = resources.GetString("fgrLabel.StyleInfo")
        Me.fgrLabel.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.fgrBCRead)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(430, 478)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "封筒内QRリスト"
        '
        'fgrBCRead
        '
        Me.fgrBCRead.ColumnInfo = resources.GetString("fgrBCRead.ColumnInfo")
        Me.fgrBCRead.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fgrBCRead.Location = New System.Drawing.Point(3, 15)
        Me.fgrBCRead.Name = "fgrBCRead"
        Me.fgrBCRead.Rows.DefaultSize = 18
        Me.fgrBCRead.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.fgrBCRead.Size = New System.Drawing.Size(424, 460)
        Me.fgrBCRead.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.GroupBox5)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 122)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(450, 418)
        Me.Panel1.TabIndex = 22
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.GroupBox2)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(450, 122)
        Me.Panel2.TabIndex = 23
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.GroupBox3)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(430, 62)
        Me.Panel3.TabIndex = 24
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.GroupBox1)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(0, 62)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(430, 478)
        Me.Panel4.TabIndex = 25
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.Panel1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Panel2)
        Me.SplitContainer1.Panel1MinSize = 450
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.Panel4)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Panel3)
        Me.SplitContainer1.Panel2MinSize = 430
        Me.SplitContainer1.Size = New System.Drawing.Size(884, 540)
        Me.SplitContainer1.SplitterDistance = 450
        Me.SplitContainer1.TabIndex = 26
        '
        'frmBCRead
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(884, 562)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.C1StatusBar1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(900, 600)
        Me.Name = "frmBCRead"
        Me.Text = "JP QRチェック"
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.btnEnd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnStart, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1StatusBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        CType(Me.fgrLabel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.fgrBCRead, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtScan As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents btnEnd As C1.Win.C1Input.C1Button
    Friend WithEvents btnStart As C1.Win.C1Input.C1Button
    Friend WithEvents lblTotal_l As C1.Win.C1Ribbon.RibbonLabel
    Friend WithEvents RibbonLabel7 As C1.Win.C1Ribbon.RibbonLabel
    Friend WithEvents RibbonSeparator12 As C1.Win.C1Ribbon.RibbonSeparator
    Friend WithEvents lblTotal_r As C1.Win.C1Ribbon.RibbonLabel
    Friend WithEvents RibbonLabel5 As C1.Win.C1Ribbon.RibbonLabel
    Friend WithEvents RibbonSeparator11 As C1.Win.C1Ribbon.RibbonSeparator
    Friend WithEvents lblTotal_ll As C1.Win.C1Ribbon.RibbonLabel
    Friend WithEvents RibbonLabel3 As C1.Win.C1Ribbon.RibbonLabel
    Friend WithEvents RibbonSeparator1 As C1.Win.C1Ribbon.RibbonSeparator
    Friend WithEvents lblTotal_rl As C1.Win.C1Ribbon.RibbonLabel
    Friend WithEvents RibbonLabel1 As C1.Win.C1Ribbon.RibbonLabel
    Friend WithEvents C1StatusBar1 As C1.Win.C1Ribbon.C1StatusBar
    Friend WithEvents cmbLotSelect As System.Windows.Forms.ComboBox
    Friend WithEvents lblCount_rl As C1.Win.C1Ribbon.RibbonLabel
    Friend WithEvents lblCntResultList2 As C1.Win.C1Ribbon.RibbonLabel
    Friend WithEvents lblCount_ll As C1.Win.C1Ribbon.RibbonLabel
    Friend WithEvents lblCntResultList4 As C1.Win.C1Ribbon.RibbonLabel
    Friend WithEvents lblCount_r As C1.Win.C1Ribbon.RibbonLabel
    Friend WithEvents lblCntResultList6 As C1.Win.C1Ribbon.RibbonLabel
    Friend WithEvents lblCount_l As C1.Win.C1Ribbon.RibbonLabel
    Friend WithEvents lblCntResultList8 As C1.Win.C1Ribbon.RibbonLabel
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents fgrLabel As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents btnSQL As C1.Win.C1Ribbon.RibbonButton
    Friend WithEvents txtLabelProgress As System.Windows.Forms.TextBox
    Friend WithEvents txtLotProgress As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents prgLabel As System.Windows.Forms.ProgressBar
    Friend WithEvents prgLot As System.Windows.Forms.ProgressBar
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents fgrBCRead As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
End Class
