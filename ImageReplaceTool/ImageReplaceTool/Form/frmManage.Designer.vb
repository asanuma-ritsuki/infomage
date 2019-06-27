<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmManage
	Inherits frmTempForm

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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmManage))
		Me.GroupBox1 = New System.Windows.Forms.GroupBox()
		Me.btnCreateShortcut = New System.Windows.Forms.Button()
		Me.txtShorcut = New System.Windows.Forms.TextBox()
		Me.Label6 = New System.Windows.Forms.Label()
		Me.btnLotView = New System.Windows.Forms.Button()
		Me.btnUpdate = New System.Windows.Forms.Button()
		Me.cmbName = New System.Windows.Forms.ComboBox()
		Me.txtRemarks = New System.Windows.Forms.TextBox()
		Me.Label3 = New System.Windows.Forms.Label()
		Me.txtParentFolder = New System.Windows.Forms.TextBox()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.TabControl1 = New System.Windows.Forms.TabControl()
		Me.TabPage1 = New System.Windows.Forms.TabPage()
		Me.GroupBox2 = New System.Windows.Forms.GroupBox()
		Me.C1FGrid01 = New C1.Win.C1FlexGrid.C1FlexGrid()
		Me.TabPage2 = New System.Windows.Forms.TabPage()
		Me.GroupBox3 = New System.Windows.Forms.GroupBox()
		Me.C1FGrid02 = New C1.Win.C1FlexGrid.C1FlexGrid()
		Me.Panel1 = New System.Windows.Forms.Panel()
		Me.btnUnlock = New System.Windows.Forms.Button()
		Me.TabPage3 = New System.Windows.Forms.TabPage()
		Me.GroupBox5 = New System.Windows.Forms.GroupBox()
		Me.C1FGrid03 = New C1.Win.C1FlexGrid.C1FlexGrid()
		Me.GroupBox4 = New System.Windows.Forms.GroupBox()
		Me.btnOutput = New System.Windows.Forms.Button()
		Me.txtOutputFolder = New System.Windows.Forms.TextBox()
		Me.Label5 = New System.Windows.Forms.Label()
		Me.chkItemName = New System.Windows.Forms.CheckBox()
		Me.chkIncrement = New System.Windows.Forms.CheckBox()
		Me.chkDoubleQuote = New System.Windows.Forms.CheckBox()
		Me.cmbSeparater = New System.Windows.Forms.ComboBox()
		Me.Label4 = New System.Windows.Forms.Label()
		Me.GroupBox1.SuspendLayout()
		Me.TabControl1.SuspendLayout()
		Me.TabPage1.SuspendLayout()
		Me.GroupBox2.SuspendLayout()
		CType(Me.C1FGrid01, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.TabPage2.SuspendLayout()
		Me.GroupBox3.SuspendLayout()
		CType(Me.C1FGrid02, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.Panel1.SuspendLayout()
		Me.TabPage3.SuspendLayout()
		Me.GroupBox5.SuspendLayout()
		CType(Me.C1FGrid03, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.GroupBox4.SuspendLayout()
		Me.SuspendLayout()
		'
		'GroupBox1
		'
		Me.GroupBox1.Controls.Add(Me.btnCreateShortcut)
		Me.GroupBox1.Controls.Add(Me.txtShorcut)
		Me.GroupBox1.Controls.Add(Me.Label6)
		Me.GroupBox1.Controls.Add(Me.btnLotView)
		Me.GroupBox1.Controls.Add(Me.btnUpdate)
		Me.GroupBox1.Controls.Add(Me.cmbName)
		Me.GroupBox1.Controls.Add(Me.txtRemarks)
		Me.GroupBox1.Controls.Add(Me.Label3)
		Me.GroupBox1.Controls.Add(Me.txtParentFolder)
		Me.GroupBox1.Controls.Add(Me.Label2)
		Me.GroupBox1.Controls.Add(Me.Label1)
		Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
		Me.GroupBox1.Location = New System.Drawing.Point(3, 3)
		Me.GroupBox1.Name = "GroupBox1"
		Me.GroupBox1.Size = New System.Drawing.Size(770, 146)
		Me.GroupBox1.TabIndex = 0
		Me.GroupBox1.TabStop = False
		Me.GroupBox1.Text = "案件登録"
		'
		'btnCreateShortcut
		'
		Me.btnCreateShortcut.Location = New System.Drawing.Point(420, 112)
		Me.btnCreateShortcut.Name = "btnCreateShortcut"
		Me.btnCreateShortcut.Size = New System.Drawing.Size(75, 25)
		Me.btnCreateShortcut.TabIndex = 8
		Me.btnCreateShortcut.Text = "作　成"
		Me.btnCreateShortcut.UseVisualStyleBackColor = True
		'
		'txtShorcut
		'
		Me.txtShorcut.Location = New System.Drawing.Point(120, 113)
		Me.txtShorcut.Name = "txtShorcut"
		Me.txtShorcut.Size = New System.Drawing.Size(294, 24)
		Me.txtShorcut.TabIndex = 7
		'
		'Label6
		'
		Me.Label6.Location = New System.Drawing.Point(14, 113)
		Me.Label6.Name = "Label6"
		Me.Label6.Size = New System.Drawing.Size(100, 24)
		Me.Label6.TabIndex = 6
		Me.Label6.Text = "ショートカット名："
		Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'btnLotView
		'
		Me.btnLotView.Location = New System.Drawing.Point(598, 113)
		Me.btnLotView.Name = "btnLotView"
		Me.btnLotView.Size = New System.Drawing.Size(75, 25)
		Me.btnLotView.TabIndex = 9
		Me.btnLotView.Text = "ロット表示"
		Me.btnLotView.UseVisualStyleBackColor = True
		'
		'btnUpdate
		'
		Me.btnUpdate.Location = New System.Drawing.Point(679, 113)
		Me.btnUpdate.Name = "btnUpdate"
		Me.btnUpdate.Size = New System.Drawing.Size(75, 25)
		Me.btnUpdate.TabIndex = 10
		Me.btnUpdate.Text = "登　録"
		Me.btnUpdate.UseVisualStyleBackColor = True
		'
		'cmbName
		'
		Me.cmbName.FormattingEnabled = True
		Me.cmbName.Location = New System.Drawing.Point(120, 22)
		Me.cmbName.Name = "cmbName"
		Me.cmbName.Size = New System.Drawing.Size(634, 25)
		Me.cmbName.TabIndex = 1
		'
		'txtRemarks
		'
		Me.txtRemarks.Location = New System.Drawing.Point(120, 53)
		Me.txtRemarks.Name = "txtRemarks"
		Me.txtRemarks.Size = New System.Drawing.Size(634, 24)
		Me.txtRemarks.TabIndex = 3
		'
		'Label3
		'
		Me.Label3.Location = New System.Drawing.Point(14, 52)
		Me.Label3.Name = "Label3"
		Me.Label3.Size = New System.Drawing.Size(100, 24)
		Me.Label3.TabIndex = 2
		Me.Label3.Text = "備考："
		Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'txtParentFolder
		'
		Me.txtParentFolder.AllowDrop = True
		Me.txtParentFolder.Location = New System.Drawing.Point(120, 83)
		Me.txtParentFolder.Name = "txtParentFolder"
		Me.txtParentFolder.Size = New System.Drawing.Size(634, 24)
		Me.txtParentFolder.TabIndex = 5
		'
		'Label2
		'
		Me.Label2.Location = New System.Drawing.Point(14, 82)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(100, 24)
		Me.Label2.TabIndex = 4
		Me.Label2.Text = "画像親フォルダ："
		Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'Label1
		'
		Me.Label1.Location = New System.Drawing.Point(14, 22)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(100, 24)
		Me.Label1.TabIndex = 0
		Me.Label1.Text = "案件名："
		Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'TabControl1
		'
		Me.TabControl1.Controls.Add(Me.TabPage1)
		Me.TabControl1.Controls.Add(Me.TabPage2)
		Me.TabControl1.Controls.Add(Me.TabPage3)
		Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
		Me.TabControl1.Location = New System.Drawing.Point(0, 0)
		Me.TabControl1.Name = "TabControl1"
		Me.TabControl1.SelectedIndex = 0
		Me.TabControl1.Size = New System.Drawing.Size(784, 539)
		Me.TabControl1.TabIndex = 0
		'
		'TabPage1
		'
		Me.TabPage1.Controls.Add(Me.GroupBox2)
		Me.TabPage1.Controls.Add(Me.GroupBox1)
		Me.TabPage1.Location = New System.Drawing.Point(4, 26)
		Me.TabPage1.Name = "TabPage1"
		Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
		Me.TabPage1.Size = New System.Drawing.Size(776, 509)
		Me.TabPage1.TabIndex = 0
		Me.TabPage1.Text = "案件登録・編集"
		Me.TabPage1.UseVisualStyleBackColor = True
		'
		'GroupBox2
		'
		Me.GroupBox2.Controls.Add(Me.C1FGrid01)
		Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
		Me.GroupBox2.Location = New System.Drawing.Point(3, 149)
		Me.GroupBox2.Name = "GroupBox2"
		Me.GroupBox2.Size = New System.Drawing.Size(770, 357)
		Me.GroupBox2.TabIndex = 1
		Me.GroupBox2.TabStop = False
		Me.GroupBox2.Text = "ロット一覧"
		'
		'C1FGrid01
		'
		Me.C1FGrid01.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
		Me.C1FGrid01.AllowEditing = False
		Me.C1FGrid01.AllowFiltering = True
		Me.C1FGrid01.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
		Me.C1FGrid01.AutoClipboard = True
		Me.C1FGrid01.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
		Me.C1FGrid01.ColumnInfo = resources.GetString("C1FGrid01.ColumnInfo")
		Me.C1FGrid01.Dock = System.Windows.Forms.DockStyle.Fill
		Me.C1FGrid01.ExtendLastCol = True
		Me.C1FGrid01.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid
		Me.C1FGrid01.Font = New System.Drawing.Font("Meiryo UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.C1FGrid01.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcrossOut
		Me.C1FGrid01.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcrossOut
		Me.C1FGrid01.Location = New System.Drawing.Point(3, 20)
		Me.C1FGrid01.Name = "C1FGrid01"
		Me.C1FGrid01.Rows.Count = 1
		Me.C1FGrid01.Rows.DefaultSize = 20
		Me.C1FGrid01.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
		Me.C1FGrid01.ShowCellLabels = True
		Me.C1FGrid01.Size = New System.Drawing.Size(764, 334)
		Me.C1FGrid01.TabIndex = 0
		Me.C1FGrid01.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.System
		'
		'TabPage2
		'
		Me.TabPage2.Controls.Add(Me.GroupBox3)
		Me.TabPage2.Location = New System.Drawing.Point(4, 26)
		Me.TabPage2.Name = "TabPage2"
		Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
		Me.TabPage2.Size = New System.Drawing.Size(776, 509)
		Me.TabPage2.TabIndex = 1
		Me.TabPage2.Text = "ログイン状況"
		Me.TabPage2.UseVisualStyleBackColor = True
		'
		'GroupBox3
		'
		Me.GroupBox3.Controls.Add(Me.C1FGrid02)
		Me.GroupBox3.Controls.Add(Me.Panel1)
		Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Fill
		Me.GroupBox3.Location = New System.Drawing.Point(3, 3)
		Me.GroupBox3.Name = "GroupBox3"
		Me.GroupBox3.Size = New System.Drawing.Size(770, 503)
		Me.GroupBox3.TabIndex = 0
		Me.GroupBox3.TabStop = False
		Me.GroupBox3.Text = "ログイン状況管理"
		'
		'C1FGrid02
		'
		Me.C1FGrid02.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
		Me.C1FGrid02.AllowEditing = False
		Me.C1FGrid02.AllowFiltering = True
		Me.C1FGrid02.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
		Me.C1FGrid02.AutoClipboard = True
		Me.C1FGrid02.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
		Me.C1FGrid02.ColumnInfo = resources.GetString("C1FGrid02.ColumnInfo")
		Me.C1FGrid02.Dock = System.Windows.Forms.DockStyle.Fill
		Me.C1FGrid02.ExtendLastCol = True
		Me.C1FGrid02.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid
		Me.C1FGrid02.Font = New System.Drawing.Font("Meiryo UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.C1FGrid02.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcrossOut
		Me.C1FGrid02.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcrossOut
		Me.C1FGrid02.Location = New System.Drawing.Point(3, 20)
		Me.C1FGrid02.Name = "C1FGrid02"
		Me.C1FGrid02.Rows.Count = 1
		Me.C1FGrid02.Rows.DefaultSize = 20
		Me.C1FGrid02.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
		Me.C1FGrid02.ShowCellLabels = True
		Me.C1FGrid02.Size = New System.Drawing.Size(764, 449)
		Me.C1FGrid02.TabIndex = 0
		Me.C1FGrid02.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.System
		'
		'Panel1
		'
		Me.Panel1.Controls.Add(Me.btnUnlock)
		Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
		Me.Panel1.Location = New System.Drawing.Point(3, 469)
		Me.Panel1.Name = "Panel1"
		Me.Panel1.Size = New System.Drawing.Size(764, 31)
		Me.Panel1.TabIndex = 1
		'
		'btnUnlock
		'
		Me.btnUnlock.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.btnUnlock.Location = New System.Drawing.Point(686, 3)
		Me.btnUnlock.Name = "btnUnlock"
		Me.btnUnlock.Size = New System.Drawing.Size(75, 25)
		Me.btnUnlock.TabIndex = 0
		Me.btnUnlock.Text = "解　除"
		Me.btnUnlock.UseVisualStyleBackColor = True
		'
		'TabPage3
		'
		Me.TabPage3.Controls.Add(Me.GroupBox5)
		Me.TabPage3.Controls.Add(Me.GroupBox4)
		Me.TabPage3.Location = New System.Drawing.Point(4, 26)
		Me.TabPage3.Name = "TabPage3"
		Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
		Me.TabPage3.Size = New System.Drawing.Size(776, 509)
		Me.TabPage3.TabIndex = 2
		Me.TabPage3.Text = "CSV出力"
		Me.TabPage3.UseVisualStyleBackColor = True
		'
		'GroupBox5
		'
		Me.GroupBox5.Controls.Add(Me.C1FGrid03)
		Me.GroupBox5.Dock = System.Windows.Forms.DockStyle.Fill
		Me.GroupBox5.Location = New System.Drawing.Point(3, 3)
		Me.GroupBox5.Name = "GroupBox5"
		Me.GroupBox5.Size = New System.Drawing.Size(770, 392)
		Me.GroupBox5.TabIndex = 0
		Me.GroupBox5.TabStop = False
		Me.GroupBox5.Text = "案件一覧"
		'
		'C1FGrid03
		'
		Me.C1FGrid03.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
		Me.C1FGrid03.AllowEditing = False
		Me.C1FGrid03.AllowFiltering = True
		Me.C1FGrid03.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
		Me.C1FGrid03.AutoClipboard = True
		Me.C1FGrid03.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
		Me.C1FGrid03.ColumnInfo = resources.GetString("C1FGrid03.ColumnInfo")
		Me.C1FGrid03.Dock = System.Windows.Forms.DockStyle.Fill
		Me.C1FGrid03.ExtendLastCol = True
		Me.C1FGrid03.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid
		Me.C1FGrid03.Font = New System.Drawing.Font("Meiryo UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.C1FGrid03.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcrossOut
		Me.C1FGrid03.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcrossOut
		Me.C1FGrid03.Location = New System.Drawing.Point(3, 20)
		Me.C1FGrid03.Name = "C1FGrid03"
		Me.C1FGrid03.Rows.Count = 1
		Me.C1FGrid03.Rows.DefaultSize = 20
		Me.C1FGrid03.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
		Me.C1FGrid03.ShowCellLabels = True
		Me.C1FGrid03.Size = New System.Drawing.Size(764, 369)
		Me.C1FGrid03.TabIndex = 0
		Me.C1FGrid03.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.System
		'
		'GroupBox4
		'
		Me.GroupBox4.Controls.Add(Me.btnOutput)
		Me.GroupBox4.Controls.Add(Me.txtOutputFolder)
		Me.GroupBox4.Controls.Add(Me.Label5)
		Me.GroupBox4.Controls.Add(Me.chkItemName)
		Me.GroupBox4.Controls.Add(Me.chkIncrement)
		Me.GroupBox4.Controls.Add(Me.chkDoubleQuote)
		Me.GroupBox4.Controls.Add(Me.cmbSeparater)
		Me.GroupBox4.Controls.Add(Me.Label4)
		Me.GroupBox4.Dock = System.Windows.Forms.DockStyle.Bottom
		Me.GroupBox4.Location = New System.Drawing.Point(3, 395)
		Me.GroupBox4.Name = "GroupBox4"
		Me.GroupBox4.Size = New System.Drawing.Size(770, 111)
		Me.GroupBox4.TabIndex = 1
		Me.GroupBox4.TabStop = False
		Me.GroupBox4.Text = "出力設定"
		'
		'btnOutput
		'
		Me.btnOutput.Location = New System.Drawing.Point(689, 80)
		Me.btnOutput.Name = "btnOutput"
		Me.btnOutput.Size = New System.Drawing.Size(75, 25)
		Me.btnOutput.TabIndex = 7
		Me.btnOutput.Text = "出　力"
		Me.btnOutput.UseVisualStyleBackColor = True
		'
		'txtOutputFolder
		'
		Me.txtOutputFolder.AllowDrop = True
		Me.txtOutputFolder.Location = New System.Drawing.Point(120, 81)
		Me.txtOutputFolder.Name = "txtOutputFolder"
		Me.txtOutputFolder.Size = New System.Drawing.Size(563, 24)
		Me.txtOutputFolder.TabIndex = 6
		'
		'Label5
		'
		Me.Label5.Location = New System.Drawing.Point(14, 80)
		Me.Label5.Name = "Label5"
		Me.Label5.Size = New System.Drawing.Size(100, 24)
		Me.Label5.TabIndex = 5
		Me.Label5.Text = "出力フォルダ："
		Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'chkItemName
		'
		Me.chkItemName.AutoSize = True
		Me.chkItemName.Location = New System.Drawing.Point(22, 54)
		Me.chkItemName.Name = "chkItemName"
		Me.chkItemName.Size = New System.Drawing.Size(92, 21)
		Me.chkItemName.TabIndex = 2
		Me.chkItemName.Text = "項目名付加"
		Me.chkItemName.UseVisualStyleBackColor = True
		'
		'chkIncrement
		'
		Me.chkIncrement.AutoSize = True
		Me.chkIncrement.Location = New System.Drawing.Point(120, 54)
		Me.chkIncrement.Name = "chkIncrement"
		Me.chkIncrement.Size = New System.Drawing.Size(147, 21)
		Me.chkIncrement.TabIndex = 3
		Me.chkIncrement.Text = "先頭に通し番号を付加"
		Me.chkIncrement.UseVisualStyleBackColor = True
		'
		'chkDoubleQuote
		'
		Me.chkDoubleQuote.AutoSize = True
		Me.chkDoubleQuote.Location = New System.Drawing.Point(273, 54)
		Me.chkDoubleQuote.Name = "chkDoubleQuote"
		Me.chkDoubleQuote.Size = New System.Drawing.Size(130, 21)
		Me.chkDoubleQuote.TabIndex = 4
		Me.chkDoubleQuote.Text = "ダブルクォートでくくる"
		Me.chkDoubleQuote.UseVisualStyleBackColor = True
		'
		'cmbSeparater
		'
		Me.cmbSeparater.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cmbSeparater.FormattingEnabled = True
		Me.cmbSeparater.Items.AddRange(New Object() {"カンマ", "タブ"})
		Me.cmbSeparater.Location = New System.Drawing.Point(120, 23)
		Me.cmbSeparater.Name = "cmbSeparater"
		Me.cmbSeparater.Size = New System.Drawing.Size(121, 25)
		Me.cmbSeparater.TabIndex = 1
		'
		'Label4
		'
		Me.Label4.Location = New System.Drawing.Point(14, 22)
		Me.Label4.Name = "Label4"
		Me.Label4.Size = New System.Drawing.Size(100, 24)
		Me.Label4.TabIndex = 0
		Me.Label4.Text = "区切り文字："
		Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'frmManage
		'
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
		Me.CaptionDisplayMode = ImageReplaceTool.frmTempForm.StatusDisplayMode.ShowAll
		Me.ClientSize = New System.Drawing.Size(784, 561)
		Me.Controls.Add(Me.TabControl1)
		Me.KeyPreview = True
		Me.Name = "frmManage"
		Me.Text = "frmManage"
		Me.Controls.SetChildIndex(Me.TabControl1, 0)
		Me.GroupBox1.ResumeLayout(False)
		Me.GroupBox1.PerformLayout()
		Me.TabControl1.ResumeLayout(False)
		Me.TabPage1.ResumeLayout(False)
		Me.GroupBox2.ResumeLayout(False)
		CType(Me.C1FGrid01, System.ComponentModel.ISupportInitialize).EndInit()
		Me.TabPage2.ResumeLayout(False)
		Me.GroupBox3.ResumeLayout(False)
		CType(Me.C1FGrid02, System.ComponentModel.ISupportInitialize).EndInit()
		Me.Panel1.ResumeLayout(False)
		Me.TabPage3.ResumeLayout(False)
		Me.GroupBox5.ResumeLayout(False)
		CType(Me.C1FGrid03, System.ComponentModel.ISupportInitialize).EndInit()
		Me.GroupBox4.ResumeLayout(False)
		Me.GroupBox4.PerformLayout()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	Friend WithEvents GroupBox1 As GroupBox
	Friend WithEvents Label1 As Label
	Friend WithEvents cmbName As ComboBox
	Friend WithEvents txtRemarks As TextBox
	Friend WithEvents Label3 As Label
	Friend WithEvents txtParentFolder As TextBox
	Friend WithEvents Label2 As Label
	Friend WithEvents TabControl1 As TabControl
	Friend WithEvents TabPage1 As TabPage
	Friend WithEvents TabPage2 As TabPage
	Friend WithEvents btnUpdate As Button
	Friend WithEvents btnLotView As Button
	Friend WithEvents GroupBox2 As GroupBox
	Friend WithEvents C1FGrid01 As C1.Win.C1FlexGrid.C1FlexGrid
	Friend WithEvents GroupBox3 As GroupBox
	Friend WithEvents Panel1 As Panel
	Friend WithEvents C1FGrid02 As C1.Win.C1FlexGrid.C1FlexGrid
	Friend WithEvents btnUnlock As Button
	Friend WithEvents TabPage3 As TabPage
	Friend WithEvents GroupBox5 As GroupBox
	Friend WithEvents C1FGrid03 As C1.Win.C1FlexGrid.C1FlexGrid
	Friend WithEvents GroupBox4 As GroupBox
	Friend WithEvents btnOutput As Button
	Friend WithEvents txtOutputFolder As TextBox
	Friend WithEvents Label5 As Label
	Friend WithEvents chkItemName As CheckBox
	Friend WithEvents chkIncrement As CheckBox
	Friend WithEvents chkDoubleQuote As CheckBox
	Friend WithEvents cmbSeparater As ComboBox
	Friend WithEvents Label4 As Label
	Friend WithEvents btnCreateShortcut As Button
	Friend WithEvents txtShorcut As TextBox
	Friend WithEvents Label6 As Label
End Class
