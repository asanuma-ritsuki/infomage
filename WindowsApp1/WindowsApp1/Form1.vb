Public Class Form1
	Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		'TODO: このコード行はデータを 'YuShoDoPSDataSet1.T_目次DUP' テーブルに読み込みます。必要に応じて移動、または削除をしてください。
		Me.T_目次DUPTableAdapter.Fill(Me.YuShoDoPSDataSet1.T_目次DUP)
		''TODO: このコード行はデータを 'YuShoDoPSDataSet.M_ユーザー' テーブルに読み込みます。必要に応じて移動、または削除をしてください。
		'Me.M_ユーザーTableAdapter.Fill(Me.YuShoDoPSDataSet.M_ユーザー)

	End Sub

	Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

		Me.T_目次DUPTableAdapter.Update(YuShoDoPSDataSet1)
		MessageBox.Show("完了")
		Me.DataGridView1.Update()
		Dim dt As DataTable = Nothing

	End Sub
End Class
