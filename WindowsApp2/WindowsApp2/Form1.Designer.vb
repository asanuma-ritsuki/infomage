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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
		Me.Panel1 = New System.Windows.Forms.Panel()
		Me.C1FlexGrid1 = New C1.Win.C1FlexGrid.C1FlexGrid()
		Me.YuShoDoPSDataSet1 = New WindowsApp2.YuShoDoPSDataSet1()
		Me.T目次DUPBindingSource = New System.Windows.Forms.BindingSource(Me.components)
		Me.T_目次DUPTableAdapter = New WindowsApp2.YuShoDoPSDataSet1TableAdapters.T_目次DUPTableAdapter()
		CType(Me.C1FlexGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.YuShoDoPSDataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.T目次DUPBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'Panel1
		'
		Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
		Me.Panel1.Location = New System.Drawing.Point(0, 935)
		Me.Panel1.Name = "Panel1"
		Me.Panel1.Size = New System.Drawing.Size(1323, 62)
		Me.Panel1.TabIndex = 0
		'
		'C1FlexGrid1
		'
		Me.C1FlexGrid1.ColumnInfo = resources.GetString("C1FlexGrid1.ColumnInfo")
		Me.C1FlexGrid1.DataSource = Me.T目次DUPBindingSource
		Me.C1FlexGrid1.Dock = System.Windows.Forms.DockStyle.Fill
		Me.C1FlexGrid1.Location = New System.Drawing.Point(0, 0)
		Me.C1FlexGrid1.Name = "C1FlexGrid1"
		Me.C1FlexGrid1.Rows.Count = 1
		Me.C1FlexGrid1.Rows.DefaultSize = 18
		Me.C1FlexGrid1.Size = New System.Drawing.Size(1323, 935)
		Me.C1FlexGrid1.TabIndex = 1
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
		'Form1
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(1323, 997)
		Me.Controls.Add(Me.C1FlexGrid1)
		Me.Controls.Add(Me.Panel1)
		Me.Name = "Form1"
		Me.Text = "Form1"
		CType(Me.C1FlexGrid1, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.YuShoDoPSDataSet1, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.T目次DUPBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)

	End Sub

	Friend WithEvents Panel1 As Panel
	Friend WithEvents C1FlexGrid1 As C1.Win.C1FlexGrid.C1FlexGrid
	Friend WithEvents YuShoDoPSDataSet1 As YuShoDoPSDataSet1
	Friend WithEvents T目次DUPBindingSource As BindingSource
	Friend WithEvents T_目次DUPTableAdapter As YuShoDoPSDataSet1TableAdapters.T_目次DUPTableAdapter
End Class
