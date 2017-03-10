Public Class frmItemManage
	Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click

		Dim frmNextForm As New frmProjectDetail
		m_Context.SetNextContext(frmNextForm)

	End Sub
End Class