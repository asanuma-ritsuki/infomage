Public Class frmProjectDetail
	Private Sub frmProjectDetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load

	End Sub

	Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click

		Dim frmNextForm As New frmProjectManage
		m_Context.SetNextContext(frmNextForm)

	End Sub

	Private Sub btnMasterManage_Click(sender As Object, e As EventArgs) Handles btnMasterManage.Click

		Dim frmNextForm As New frmMasterManage
		m_Context.SetNextContext(frmNextForm)

	End Sub

	Private Sub btnCompare_Click(sender As Object, e As EventArgs) Handles btnCompare.Click

		Dim frmNextForm As New frmCompare
		m_Context.SetNextContext(frmNextForm)

	End Sub

End Class