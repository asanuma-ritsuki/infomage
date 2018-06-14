<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMaintenance
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
		Me.SuspendLayout()
		'
		'frmMaintenance
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 17.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.CaptionDisplayMode = BidEntryManageTool.frmTempForm.StatusDisplayMode.ShowAll
		Me.ClientSize = New System.Drawing.Size(784, 561)
		Me.Name = "frmMaintenance"
		Me.Text = "frmMaintenance"
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
End Class
