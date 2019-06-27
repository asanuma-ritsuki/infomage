<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmImageViewer
	Inherits frmTempForm

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
		Me.C1ThumbnailGrid1 = New ImageReplaceTool.C1ThumbnailGrid()
		CType(Me.C1ThumbnailGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'C1ThumbnailGrid1
		'
		Me.C1ThumbnailGrid1.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
		Me.C1ThumbnailGrid1.ColumnInfo = "0,0,0,0,0,115,Columns:"
		Me.C1ThumbnailGrid1.Dock = System.Windows.Forms.DockStyle.Bottom
		Me.C1ThumbnailGrid1.Location = New System.Drawing.Point(0, 389)
		Me.C1ThumbnailGrid1.Name = "C1ThumbnailGrid1"
		Me.C1ThumbnailGrid1.Rows.Count = 2
		Me.C1ThumbnailGrid1.Rows.DefaultSize = 23
		Me.C1ThumbnailGrid1.Size = New System.Drawing.Size(784, 150)
		Me.C1ThumbnailGrid1.TabIndex = 1
		'
		'frmImageViewer
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 17.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.CaptionDisplayMode = ImageReplaceTool.frmTempForm.StatusDisplayMode.ShowAll
		Me.ClientSize = New System.Drawing.Size(784, 561)
		Me.Controls.Add(Me.C1ThumbnailGrid1)
		Me.KeyPreview = True
		Me.Name = "frmImageViewer"
		Me.Text = "frmImageViewer"
		Me.Controls.SetChildIndex(Me.C1ThumbnailGrid1, 0)
		CType(Me.C1ThumbnailGrid1, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	Friend WithEvents C1ThumbnailGrid1 As C1ThumbnailGrid
End Class
