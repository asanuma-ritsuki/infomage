﻿Public Class frmCompare
	Private Sub frmCompare_Load(sender As Object, e As EventArgs) Handles MyBase.Load

		Dim f As New frmImageViewer
		f.Show(Me)

	End Sub

	Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click

		Dim frmNextForm As New frmProjectDetail
		m_Context.SetNextContext(frmNextForm)

	End Sub
End Class