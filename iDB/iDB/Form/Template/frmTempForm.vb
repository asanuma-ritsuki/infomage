Imports C1.Win.C1Themes

Public Class frmTempForm
	Private Sub frmTempForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

		Dim theme As C1Theme = C1ThemeController.GetThemeByName("Windows8Gray", False)
		C1ThemeController.ApplyThemeToControlTree(Me, theme)

	End Sub
End Class