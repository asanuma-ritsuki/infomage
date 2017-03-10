Public Class frmProjectDetail
	Private Sub frmProjectDetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load

		'グリッド詳細にセルボタンを設置する
		Me.C1FlexGrid1.Cols("詳細").ComboList = "..."
		Me.C1FlexGrid1.ShowButtons = C1.Win.C1FlexGrid.ShowButtonsEnum.WithFocus
		Me.C1FlexGrid1.ShowCellLabels = True

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

	Private Sub btnItemManage_Click(sender As Object, e As EventArgs) Handles btnItemManage.Click

		Dim frmNextForm As New frmItemManage
		m_Context.SetNextContext(frmNextForm)

	End Sub

	Private Sub C1Button2_Click(sender As Object, e As EventArgs) Handles C1Button2.Click

		Dim frmNextForm As New frmGetFilePath
		m_Context.SetNextContext(frmNextForm)

	End Sub
End Class