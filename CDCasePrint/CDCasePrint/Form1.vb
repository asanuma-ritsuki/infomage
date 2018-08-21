Imports C1.Win.FlexReport

Public Class Form1
	Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

		Initialize()

	End Sub

	Private Sub Initialize()

		Dim strSQL As String = ""
		Dim sqlProcess As New SQLProcess

		Try
			strSQL = "SELECT BD_Vol FROM T_Case_Label "
			strSQL &= "GROUP BY BD_Vol "
			strSQL &= "ORDER BY BD_Vol"
			Dim dt As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)

			For i As Integer = 0 To dt.Rows.Count - 1
				Me.cmbBDVol.Items.Add(dt.Rows(i)("BD_Vol"))
			Next

		Catch ex As Exception
			MessageBox.Show(ex.Message)
		End Try
	End Sub

	Private Sub cmbBDVol_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbBDVol.SelectedIndexChanged

		Dim strConnectionString As String = ""
		XmlSettings.LoadFromXmlFile()
		Dim C1FlexReport1 As New C1FlexReport

		Dim strSQL As String = "SELECT Doc_No, Doc_Name FROM T_Case_Label "
		strSQL &= "WHERE BD_Vol = '" & Me.cmbBDVol.SelectedItem & "' "
		strSQL &= "ORDER BY Doc_No"

		Try
			'接続文字列を作成する
			strConnectionString = "Provider=SQLOLEDB.1;"
			strConnectionString &= "Password=" & XmlSettings.Instance.Password & ";"
			strConnectionString &= "Persist Security Info=True;"
			strConnectionString &= "User ID=" & XmlSettings.Instance.UserID & ";"
			strConnectionString &= "Initial Catalog=" & XmlSettings.Instance.InitialCatalog & ";"
			strConnectionString &= "Data Source=" & XmlSettings.Instance.DataSource

			C1FlexReport1.Load(Application.StartupPath & "\" & "CDラベル.flxr", "CDCaseLabel_Child")
			C1FlexReport1.DataSource.ConnectionString = strConnectionString
			C1FlexReport1.DataSource.RecordSource = strSQL

			Me.C1FlexViewer1.DocumentSource = C1FlexReport1

		Catch ex As Exception
			MessageBox.Show(ex.Message)
		End Try
	End Sub

	Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click

		If MessageBox.Show("印刷を開始します" & vbNewLine & "よろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
			Exit Sub
		End If

		Dim strSQL As String = ""
		Dim sqlProcess As New SQLProcess

		Try
			strSQL = "SELECT BD_Vol FROM T_Case_Label "
			strSQL &= "GROUP BY BD_Vol "
			strSQL &= "ORDER BY BD_Vol"
			Dim dt As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)

			For i As Integer = 0 To dt.Rows.Count - 1
				Me.cmbBDVol.Items.Add(dt.Rows(i)("BD_Vol"))
				Print(Me.cmbBDVol.SelectedItem)
			Next

		Catch ex As Exception
			MessageBox.Show(ex.Message)
		End Try

	End Sub

	Private Sub Print(ByVal BD_Vol As String)

		Dim strConnectionString As String = ""
		XmlSettings.LoadFromXmlFile()
		Dim C1FlexReport1 As New C1FlexReport

		Dim strSQL As String = "SELECT Doc_No, Doc_Name FROM T_Case_Label "
		strSQL &= "WHERE BD_Vol = '" & BD_Vol & "' "
		strSQL &= "ORDER BY Doc_No"

		Try
			'接続文字列を作成する
			strConnectionString = "Provider=SQLOLEDB.1;"
			strConnectionString &= "Password=" & XmlSettings.Instance.Password & ";"
			strConnectionString &= "Persist Security Info=True;"
			strConnectionString &= "User ID=" & XmlSettings.Instance.UserID & ";"
			strConnectionString &= "Initial Catalog=" & XmlSettings.Instance.InitialCatalog & ";"
			strConnectionString &= "Data Source=" & XmlSettings.Instance.DataSource

			C1FlexReport1.Load(Application.StartupPath & "\" & "CDラベル.flxr", "CDCaseLabel_Child")
			C1FlexReport1.DataSource.ConnectionString = strConnectionString
			C1FlexReport1.DataSource.RecordSource = strSQL
			C1FlexReport1.Render()

			C1FlexReport1.Print()

		Catch ex As Exception
			MessageBox.Show(ex.Message)
		End Try

	End Sub
End Class
