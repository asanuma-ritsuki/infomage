Public Class frmProjectManage
	Private Sub frmProjectManage_Load(sender As Object, e As EventArgs) Handles MyBase.Load

	End Sub

	Private Sub C1Button1_Click(sender As Object, e As EventArgs) Handles C1Button1.Click

		Dim frmNextForm As New frmUserManage
		m_Context.SetNextContext(frmNextForm)
	End Sub
End Class