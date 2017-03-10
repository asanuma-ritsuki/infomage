Imports Microsoft.VisualBasic.FileIO

Public Class frmProjectManage
	Private Sub frmProjectManage_Load(sender As Object, e As EventArgs) Handles MyBase.Load

	End Sub

	Private Sub C1Button1_Click(sender As Object, e As EventArgs) Handles C1Button1.Click

		Dim frmNextForm As New frmUserManage
		m_Context.SetNextContext(frmNextForm)

	End Sub

	Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click

		If MessageBox.Show("アプリケーションを終了します" & vbNewLine & "よろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
			Me.Close()
		End If

	End Sub

	Private Sub btnNewProject_Click(sender As Object, e As EventArgs) Handles btnNewProject.Click

		Dim frmNextForm As New frmProjectDetail
		m_Context.SetNextContext(frmNextForm)

	End Sub

	Private Sub btnProjectDetail_Click(sender As Object, e As EventArgs) Handles btnProjectDetail.Click

		Dim frmNextForm As New frmProjectDetail
		m_Context.SetNextContext(frmNextForm)

	End Sub

	'Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

	'	If MessageBox.Show("開始します", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
	'		Exit Sub
	'	End If

	'	Using parser As New TextFieldParser(Me.TextBox1.Text, System.Text.Encoding.GetEncoding("Shift-JIS"))

	'		parser.TextFieldType = FieldType.Delimited
	'		parser.SetDelimiters(vbTab)
	'		parser.HasFieldsEnclosedInQuotes = True    'データ内にデリミタがあっても区切らない
	'		parser.TrimWhiteSpace = False   '空白文字を削除しない

	'		While Not parser.EndOfData

	'			Dim row As String() = parser.ReadFields()
	'			Dim strOutputFile As String = System.IO.Path.GetDirectoryName(Me.TextBox1.Text) & "\" & IIf(IsNull(row(5)) = True, row(4), row(4) & "-" & row(5)) & ".csv"
	'			Dim blnExist As Boolean = System.IO.File.Exists(strOutputFile)

	'			Using sw As New System.IO.StreamWriter(strOutputFile, True, System.Text.Encoding.GetEncoding("Shift-JIS"))
	'				If Not blnExist Then
	'					sw.WriteLine("1," & Chr(34) & "表紙" & Chr(34) & ",KW_PAGE,0")
	'					sw.WriteLine("1," & Chr(34) & "目次" & Chr(34) & ",KW_PAGE,0")
	'				End If
	'				Dim strWriteLine As String = row(0) & "," & Chr(34) & row(1) & Chr(34) & "," & row(2) & "," & row(3)
	'				sw.WriteLine(strWriteLine)
	'			End Using

	'		End While

	'	End Using

	'	'レコードカウント
	'	Dim strFiles As String() = GetFilesMostDeep(System.IO.Path.GetDirectoryName(Me.TextBox1.Text), {"*.csv"})
	'	Using sw As New System.IO.StreamWriter(System.IO.Path.GetDirectoryName(Me.TextBox1.Text) & "\Result.txt", False, System.Text.Encoding.GetEncoding("Shift-JIS"))

	'		Dim iTotalCount As Integer = 0

	'		For Each strFile As String In strFiles
	'			Dim iRecCount As Integer = GetLinesOfTextFile(strFile)
	'			Dim strWriteLine As String = System.IO.Path.GetFileName(strFile) & vbTab & iRecCount
	'			sw.WriteLine(strWriteLine)
	'			iTotalCount += iRecCount
	'		Next

	'		sw.WriteLine("レコード合計：" & iTotalCount)

	'	End Using


	'	MessageBox.Show("終了しました", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information)

	'End Sub
End Class