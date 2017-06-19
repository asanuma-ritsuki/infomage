<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
		Me.components = New System.ComponentModel.Container()
		Me.DataGridView1 = New System.Windows.Forms.DataGridView()
		Me.Button1 = New System.Windows.Forms.Button()
		Me.YuShoDoPSDataSet = New WindowsApp1.YuShoDoPSDataSet()
		Me.MユーザーBindingSource = New System.Windows.Forms.BindingSource(Me.components)
		Me.M_ユーザーTableAdapter = New WindowsApp1.YuShoDoPSDataSetTableAdapters.M_ユーザーTableAdapter()
		Me.YuShoDoPSDataSet1 = New WindowsApp1.YuShoDoPSDataSet1()
		Me.T目次DUPBindingSource = New System.Windows.Forms.BindingSource(Me.components)
		Me.T_目次DUPTableAdapter = New WindowsApp1.YuShoDoPSDataSet1TableAdapters.T_目次DUPTableAdapter()
		Me.管理IDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.連番DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.レコード番号DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.表示用DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.行番号DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.県名DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.資料名DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.副題DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.対象年DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.刊行者名DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.刊行年月DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.分類1DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.分類2DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.分類番号DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.項目DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.番号1DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.タイトル1DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.番号2DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.タイトル2DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.番号3DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.タイトル3DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.番号4DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.タイトル4DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.番号5DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.タイトル5DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.フォルダ名DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.リンクDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.リンクTODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.備考DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.フラグIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.Panel1 = New System.Windows.Forms.Panel()
		CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.YuShoDoPSDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.MユーザーBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.YuShoDoPSDataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.T目次DUPBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.Panel1.SuspendLayout()
		Me.SuspendLayout()
		'
		'DataGridView1
		'
		Me.DataGridView1.AutoGenerateColumns = False
		Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.管理IDDataGridViewTextBoxColumn, Me.連番DataGridViewTextBoxColumn, Me.レコード番号DataGridViewTextBoxColumn, Me.表示用DataGridViewTextBoxColumn, Me.行番号DataGridViewTextBoxColumn, Me.県名DataGridViewTextBoxColumn, Me.資料名DataGridViewTextBoxColumn, Me.副題DataGridViewTextBoxColumn, Me.対象年DataGridViewTextBoxColumn, Me.刊行者名DataGridViewTextBoxColumn, Me.刊行年月DataGridViewTextBoxColumn, Me.分類1DataGridViewTextBoxColumn, Me.分類2DataGridViewTextBoxColumn, Me.分類番号DataGridViewTextBoxColumn, Me.項目DataGridViewTextBoxColumn, Me.番号1DataGridViewTextBoxColumn, Me.タイトル1DataGridViewTextBoxColumn, Me.番号2DataGridViewTextBoxColumn, Me.タイトル2DataGridViewTextBoxColumn, Me.番号3DataGridViewTextBoxColumn, Me.タイトル3DataGridViewTextBoxColumn, Me.番号4DataGridViewTextBoxColumn, Me.タイトル4DataGridViewTextBoxColumn, Me.番号5DataGridViewTextBoxColumn, Me.タイトル5DataGridViewTextBoxColumn, Me.フォルダ名DataGridViewTextBoxColumn, Me.リンクDataGridViewTextBoxColumn, Me.リンクTODataGridViewTextBoxColumn, Me.備考DataGridViewTextBoxColumn, Me.フラグIDDataGridViewTextBoxColumn})
		Me.DataGridView1.DataSource = Me.T目次DUPBindingSource
		Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
		Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
		Me.DataGridView1.Name = "DataGridView1"
		Me.DataGridView1.RowTemplate.Height = 21
		Me.DataGridView1.Size = New System.Drawing.Size(744, 653)
		Me.DataGridView1.TabIndex = 0
		'
		'Button1
		'
		Me.Button1.Location = New System.Drawing.Point(12, 3)
		Me.Button1.Name = "Button1"
		Me.Button1.Size = New System.Drawing.Size(75, 23)
		Me.Button1.TabIndex = 1
		Me.Button1.Text = "Button1"
		Me.Button1.UseVisualStyleBackColor = True
		'
		'YuShoDoPSDataSet
		'
		Me.YuShoDoPSDataSet.DataSetName = "YuShoDoPSDataSet"
		Me.YuShoDoPSDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
		'
		'MユーザーBindingSource
		'
		Me.MユーザーBindingSource.DataMember = "M_ユーザー"
		Me.MユーザーBindingSource.DataSource = Me.YuShoDoPSDataSet
		'
		'M_ユーザーTableAdapter
		'
		Me.M_ユーザーTableAdapter.ClearBeforeFill = True
		'
		'YuShoDoPSDataSet1
		'
		Me.YuShoDoPSDataSet1.DataSetName = "YuShoDoPSDataSet1"
		Me.YuShoDoPSDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
		'
		'T目次DUPBindingSource
		'
		Me.T目次DUPBindingSource.DataMember = "T_目次DUP"
		Me.T目次DUPBindingSource.DataSource = Me.YuShoDoPSDataSet1
		'
		'T_目次DUPTableAdapter
		'
		Me.T_目次DUPTableAdapter.ClearBeforeFill = True
		'
		'管理IDDataGridViewTextBoxColumn
		'
		Me.管理IDDataGridViewTextBoxColumn.DataPropertyName = "管理ID"
		Me.管理IDDataGridViewTextBoxColumn.HeaderText = "管理ID"
		Me.管理IDDataGridViewTextBoxColumn.Name = "管理IDDataGridViewTextBoxColumn"
		'
		'連番DataGridViewTextBoxColumn
		'
		Me.連番DataGridViewTextBoxColumn.DataPropertyName = "連番"
		Me.連番DataGridViewTextBoxColumn.HeaderText = "連番"
		Me.連番DataGridViewTextBoxColumn.Name = "連番DataGridViewTextBoxColumn"
		'
		'レコード番号DataGridViewTextBoxColumn
		'
		Me.レコード番号DataGridViewTextBoxColumn.DataPropertyName = "レコード番号"
		Me.レコード番号DataGridViewTextBoxColumn.HeaderText = "レコード番号"
		Me.レコード番号DataGridViewTextBoxColumn.Name = "レコード番号DataGridViewTextBoxColumn"
		'
		'表示用DataGridViewTextBoxColumn
		'
		Me.表示用DataGridViewTextBoxColumn.DataPropertyName = "表示用"
		Me.表示用DataGridViewTextBoxColumn.HeaderText = "表示用"
		Me.表示用DataGridViewTextBoxColumn.Name = "表示用DataGridViewTextBoxColumn"
		'
		'行番号DataGridViewTextBoxColumn
		'
		Me.行番号DataGridViewTextBoxColumn.DataPropertyName = "行番号"
		Me.行番号DataGridViewTextBoxColumn.HeaderText = "行番号"
		Me.行番号DataGridViewTextBoxColumn.Name = "行番号DataGridViewTextBoxColumn"
		'
		'県名DataGridViewTextBoxColumn
		'
		Me.県名DataGridViewTextBoxColumn.DataPropertyName = "県名"
		Me.県名DataGridViewTextBoxColumn.HeaderText = "県名"
		Me.県名DataGridViewTextBoxColumn.Name = "県名DataGridViewTextBoxColumn"
		'
		'資料名DataGridViewTextBoxColumn
		'
		Me.資料名DataGridViewTextBoxColumn.DataPropertyName = "資料名"
		Me.資料名DataGridViewTextBoxColumn.HeaderText = "資料名"
		Me.資料名DataGridViewTextBoxColumn.Name = "資料名DataGridViewTextBoxColumn"
		'
		'副題DataGridViewTextBoxColumn
		'
		Me.副題DataGridViewTextBoxColumn.DataPropertyName = "副題"
		Me.副題DataGridViewTextBoxColumn.HeaderText = "副題"
		Me.副題DataGridViewTextBoxColumn.Name = "副題DataGridViewTextBoxColumn"
		'
		'対象年DataGridViewTextBoxColumn
		'
		Me.対象年DataGridViewTextBoxColumn.DataPropertyName = "対象年"
		Me.対象年DataGridViewTextBoxColumn.HeaderText = "対象年"
		Me.対象年DataGridViewTextBoxColumn.Name = "対象年DataGridViewTextBoxColumn"
		'
		'刊行者名DataGridViewTextBoxColumn
		'
		Me.刊行者名DataGridViewTextBoxColumn.DataPropertyName = "刊行者名"
		Me.刊行者名DataGridViewTextBoxColumn.HeaderText = "刊行者名"
		Me.刊行者名DataGridViewTextBoxColumn.Name = "刊行者名DataGridViewTextBoxColumn"
		'
		'刊行年月DataGridViewTextBoxColumn
		'
		Me.刊行年月DataGridViewTextBoxColumn.DataPropertyName = "刊行年月"
		Me.刊行年月DataGridViewTextBoxColumn.HeaderText = "刊行年月"
		Me.刊行年月DataGridViewTextBoxColumn.Name = "刊行年月DataGridViewTextBoxColumn"
		'
		'分類1DataGridViewTextBoxColumn
		'
		Me.分類1DataGridViewTextBoxColumn.DataPropertyName = "分類1"
		Me.分類1DataGridViewTextBoxColumn.HeaderText = "分類1"
		Me.分類1DataGridViewTextBoxColumn.Name = "分類1DataGridViewTextBoxColumn"
		'
		'分類2DataGridViewTextBoxColumn
		'
		Me.分類2DataGridViewTextBoxColumn.DataPropertyName = "分類2"
		Me.分類2DataGridViewTextBoxColumn.HeaderText = "分類2"
		Me.分類2DataGridViewTextBoxColumn.Name = "分類2DataGridViewTextBoxColumn"
		'
		'分類番号DataGridViewTextBoxColumn
		'
		Me.分類番号DataGridViewTextBoxColumn.DataPropertyName = "分類番号"
		Me.分類番号DataGridViewTextBoxColumn.HeaderText = "分類番号"
		Me.分類番号DataGridViewTextBoxColumn.Name = "分類番号DataGridViewTextBoxColumn"
		'
		'項目DataGridViewTextBoxColumn
		'
		Me.項目DataGridViewTextBoxColumn.DataPropertyName = "項目"
		Me.項目DataGridViewTextBoxColumn.HeaderText = "項目"
		Me.項目DataGridViewTextBoxColumn.Name = "項目DataGridViewTextBoxColumn"
		'
		'番号1DataGridViewTextBoxColumn
		'
		Me.番号1DataGridViewTextBoxColumn.DataPropertyName = "番号1"
		Me.番号1DataGridViewTextBoxColumn.HeaderText = "番号1"
		Me.番号1DataGridViewTextBoxColumn.Name = "番号1DataGridViewTextBoxColumn"
		'
		'タイトル1DataGridViewTextBoxColumn
		'
		Me.タイトル1DataGridViewTextBoxColumn.DataPropertyName = "タイトル1"
		Me.タイトル1DataGridViewTextBoxColumn.HeaderText = "タイトル1"
		Me.タイトル1DataGridViewTextBoxColumn.Name = "タイトル1DataGridViewTextBoxColumn"
		'
		'番号2DataGridViewTextBoxColumn
		'
		Me.番号2DataGridViewTextBoxColumn.DataPropertyName = "番号2"
		Me.番号2DataGridViewTextBoxColumn.HeaderText = "番号2"
		Me.番号2DataGridViewTextBoxColumn.Name = "番号2DataGridViewTextBoxColumn"
		'
		'タイトル2DataGridViewTextBoxColumn
		'
		Me.タイトル2DataGridViewTextBoxColumn.DataPropertyName = "タイトル2"
		Me.タイトル2DataGridViewTextBoxColumn.HeaderText = "タイトル2"
		Me.タイトル2DataGridViewTextBoxColumn.Name = "タイトル2DataGridViewTextBoxColumn"
		'
		'番号3DataGridViewTextBoxColumn
		'
		Me.番号3DataGridViewTextBoxColumn.DataPropertyName = "番号3"
		Me.番号3DataGridViewTextBoxColumn.HeaderText = "番号3"
		Me.番号3DataGridViewTextBoxColumn.Name = "番号3DataGridViewTextBoxColumn"
		'
		'タイトル3DataGridViewTextBoxColumn
		'
		Me.タイトル3DataGridViewTextBoxColumn.DataPropertyName = "タイトル3"
		Me.タイトル3DataGridViewTextBoxColumn.HeaderText = "タイトル3"
		Me.タイトル3DataGridViewTextBoxColumn.Name = "タイトル3DataGridViewTextBoxColumn"
		'
		'番号4DataGridViewTextBoxColumn
		'
		Me.番号4DataGridViewTextBoxColumn.DataPropertyName = "番号4"
		Me.番号4DataGridViewTextBoxColumn.HeaderText = "番号4"
		Me.番号4DataGridViewTextBoxColumn.Name = "番号4DataGridViewTextBoxColumn"
		'
		'タイトル4DataGridViewTextBoxColumn
		'
		Me.タイトル4DataGridViewTextBoxColumn.DataPropertyName = "タイトル4"
		Me.タイトル4DataGridViewTextBoxColumn.HeaderText = "タイトル4"
		Me.タイトル4DataGridViewTextBoxColumn.Name = "タイトル4DataGridViewTextBoxColumn"
		'
		'番号5DataGridViewTextBoxColumn
		'
		Me.番号5DataGridViewTextBoxColumn.DataPropertyName = "番号5"
		Me.番号5DataGridViewTextBoxColumn.HeaderText = "番号5"
		Me.番号5DataGridViewTextBoxColumn.Name = "番号5DataGridViewTextBoxColumn"
		'
		'タイトル5DataGridViewTextBoxColumn
		'
		Me.タイトル5DataGridViewTextBoxColumn.DataPropertyName = "タイトル5"
		Me.タイトル5DataGridViewTextBoxColumn.HeaderText = "タイトル5"
		Me.タイトル5DataGridViewTextBoxColumn.Name = "タイトル5DataGridViewTextBoxColumn"
		'
		'フォルダ名DataGridViewTextBoxColumn
		'
		Me.フォルダ名DataGridViewTextBoxColumn.DataPropertyName = "フォルダ名"
		Me.フォルダ名DataGridViewTextBoxColumn.HeaderText = "フォルダ名"
		Me.フォルダ名DataGridViewTextBoxColumn.Name = "フォルダ名DataGridViewTextBoxColumn"
		'
		'リンクDataGridViewTextBoxColumn
		'
		Me.リンクDataGridViewTextBoxColumn.DataPropertyName = "リンク"
		Me.リンクDataGridViewTextBoxColumn.HeaderText = "リンク"
		Me.リンクDataGridViewTextBoxColumn.Name = "リンクDataGridViewTextBoxColumn"
		'
		'リンクTODataGridViewTextBoxColumn
		'
		Me.リンクTODataGridViewTextBoxColumn.DataPropertyName = "リンクTO"
		Me.リンクTODataGridViewTextBoxColumn.HeaderText = "リンクTO"
		Me.リンクTODataGridViewTextBoxColumn.Name = "リンクTODataGridViewTextBoxColumn"
		'
		'備考DataGridViewTextBoxColumn
		'
		Me.備考DataGridViewTextBoxColumn.DataPropertyName = "備考"
		Me.備考DataGridViewTextBoxColumn.HeaderText = "備考"
		Me.備考DataGridViewTextBoxColumn.Name = "備考DataGridViewTextBoxColumn"
		'
		'フラグIDDataGridViewTextBoxColumn
		'
		Me.フラグIDDataGridViewTextBoxColumn.DataPropertyName = "フラグID"
		Me.フラグIDDataGridViewTextBoxColumn.HeaderText = "フラグID"
		Me.フラグIDDataGridViewTextBoxColumn.Name = "フラグIDDataGridViewTextBoxColumn"
		'
		'Panel1
		'
		Me.Panel1.Controls.Add(Me.Button1)
		Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
		Me.Panel1.Location = New System.Drawing.Point(0, 653)
		Me.Panel1.Name = "Panel1"
		Me.Panel1.Size = New System.Drawing.Size(744, 42)
		Me.Panel1.TabIndex = 2
		'
		'Form1
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(744, 695)
		Me.Controls.Add(Me.DataGridView1)
		Me.Controls.Add(Me.Panel1)
		Me.Name = "Form1"
		Me.Text = "Form1"
		CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.YuShoDoPSDataSet, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.MユーザーBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.YuShoDoPSDataSet1, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.T目次DUPBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
		Me.Panel1.ResumeLayout(False)
		Me.ResumeLayout(False)

	End Sub

	Friend WithEvents DataGridView1 As DataGridView
	Friend WithEvents Button1 As Button
	Friend WithEvents YuShoDoPSDataSet As YuShoDoPSDataSet
	Friend WithEvents MユーザーBindingSource As BindingSource
	Friend WithEvents M_ユーザーTableAdapter As YuShoDoPSDataSetTableAdapters.M_ユーザーTableAdapter
	Friend WithEvents YuShoDoPSDataSet1 As YuShoDoPSDataSet1
	Friend WithEvents T目次DUPBindingSource As BindingSource
	Friend WithEvents T_目次DUPTableAdapter As YuShoDoPSDataSet1TableAdapters.T_目次DUPTableAdapter
	Friend WithEvents 管理IDDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
	Friend WithEvents 連番DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
	Friend WithEvents レコード番号DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
	Friend WithEvents 表示用DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
	Friend WithEvents 行番号DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
	Friend WithEvents 県名DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
	Friend WithEvents 資料名DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
	Friend WithEvents 副題DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
	Friend WithEvents 対象年DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
	Friend WithEvents 刊行者名DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
	Friend WithEvents 刊行年月DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
	Friend WithEvents 分類1DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
	Friend WithEvents 分類2DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
	Friend WithEvents 分類番号DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
	Friend WithEvents 項目DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
	Friend WithEvents 番号1DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
	Friend WithEvents タイトル1DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
	Friend WithEvents 番号2DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
	Friend WithEvents タイトル2DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
	Friend WithEvents 番号3DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
	Friend WithEvents タイトル3DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
	Friend WithEvents 番号4DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
	Friend WithEvents タイトル4DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
	Friend WithEvents 番号5DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
	Friend WithEvents タイトル5DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
	Friend WithEvents フォルダ名DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
	Friend WithEvents リンクDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
	Friend WithEvents リンクTODataGridViewTextBoxColumn As DataGridViewTextBoxColumn
	Friend WithEvents 備考DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
	Friend WithEvents フラグIDDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
	Friend WithEvents Panel1 As Panel
End Class
