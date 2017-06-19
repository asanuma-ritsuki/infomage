Public Class Form1
	Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		'TODO: このコード行はデータを 'YuShoDoPSDataSet1.T_目次DUP' テーブルに読み込みます。必要に応じて移動、または削除をしてください。
		Me.T_目次DUPTableAdapter.Fill(Me.YuShoDoPSDataSet1.T_目次DUP)

	End Sub
End Class
