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
		Me.C1FlexViewer1 = New C1.Win.FlexViewer.C1FlexViewer()
		Me.C1FlexReport1 = New C1.Win.FlexReport.C1FlexReport()
		Me.C1PdfDocumentSource1 = New C1.Win.C1Document.C1PdfDocumentSource(Me.components)
		CType(Me.C1FlexViewer1, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'C1FlexViewer1
		'
		Me.C1FlexViewer1.AutoScrollMargin = New System.Drawing.Size(0, 0)
		Me.C1FlexViewer1.AutoScrollMinSize = New System.Drawing.Size(0, 0)
		Me.C1FlexViewer1.Dock = System.Windows.Forms.DockStyle.Fill
		Me.C1FlexViewer1.DocumentSource = Me.C1PdfDocumentSource1
		Me.C1FlexViewer1.Location = New System.Drawing.Point(0, 0)
		Me.C1FlexViewer1.Name = "C1FlexViewer1"
		Me.C1FlexViewer1.Size = New System.Drawing.Size(784, 561)
		Me.C1FlexViewer1.TabIndex = 0
		'
		'C1FlexReport1
		'
		Me.C1FlexReport1.ReportDefinition = resources.GetString("C1FlexReport1.ReportDefinition")
		Me.C1FlexReport1.ReportName = "C1FlexReport1"
		'
		'C1PdfDocumentSource1
		'
		Me.C1PdfDocumentSource1.DocumentLocation = "C:\JPTemp\06_印刷\20180817_リーフレット\0002.pdf"
		'
		'Form1
		'
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
		Me.ClientSize = New System.Drawing.Size(784, 561)
		Me.Controls.Add(Me.C1FlexViewer1)
		Me.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.Name = "Form1"
		Me.Text = "Form1"
		CType(Me.C1FlexViewer1, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)

	End Sub

	Friend WithEvents C1FlexViewer1 As C1.Win.FlexViewer.C1FlexViewer
	Friend WithEvents C1FlexReport1 As C1.Win.FlexReport.C1FlexReport
	Friend WithEvents C1PdfDocumentSource1 As C1.Win.C1Document.C1PdfDocumentSource
End Class
