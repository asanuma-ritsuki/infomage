Public Class Form1
	Private Sub btnRun_Click(sender As Object, e As EventArgs) Handles btnRun.Click

		If MessageBox.Show("実行します" & "よろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
			Exit Sub
		End If

		Dim strEntry As String = Me.txtEntryData.Text
		Dim strShubetsu As String = Me.txtShubetsuData.Text
		Dim strOutputFileName As String = Date.Now.ToString("yyyyMMddHHmmss")
		Dim OutputData As String = Me.txtOutFolder.Text & "\" & strOutputFileName & "_出力.txt"
		Dim strLog As String = Me.txtOutFolder.Text & "\" & strOutputFileName & "_ログ.txt"

		Dim iRecCount As Integer = 0
		Dim iRecCountS As Integer = 0
		Dim strWriteLine As String = ""

		Using swLog As New System.IO.StreamWriter(strLog, False, System.Text.Encoding.GetEncoding("Shift-JIS"))

			Using parser As New CSVParser(strEntry, System.Text.Encoding.GetEncoding("Shift-JIS"))
				parser.Delimiter = vbTab
				parser.HasFieldsEnclosedInQuotes = True
				parser.TrimWhiteSpace = False

				iRecCount = 0

				Using sw As New System.IO.StreamWriter(OutputData, False, System.Text.Encoding.GetEncoding("Shift-JIS"))

					While Not parser.EndOfData

						iRecCount += 1
						Dim row As String() = parser.ReadFields()
						''ファイルの存在チェック
						'Dim strImageFile As String = row(0) & row(1)
						'If Not My.Computer.FileSystem.FileExists(strImageFile) Then
						'	swLog.WriteLine(row(0) & vbTab & row(1) & vbTab & "ファイルが存在しない")
						'End If
						Using parserS As New CSVParser(strShubetsu, System.Text.Encoding.GetEncoding("Shift-JIS"))
							parserS.Delimiter = vbTab
							parserS.HasFieldsEnclosedInQuotes = True
							parserS.TrimWhiteSpace = False

							iRecCountS = 0
							Dim blnHit As Boolean = False

							While Not parserS.EndOfData
								Dim rowS As String() = parserS.ReadFields()
								If row(2).IndexOf(rowS(0)) >= 0 Then
									'ヒットした
									strWriteLine = row(0) & vbTab & row(1) & vbTab & row(2) & vbTab & rowS(1)
									sw.WriteLine(strWriteLine)

									swLog.WriteLine(row(0) & vbTab & row(1) & vbTab & row(2) & vbTab & rowS(1) & vbTab & "ヒットした")
									blnHit = True
									Exit While
								End If
								iRecCountS += 1
							End While
							If Not blnHit Then
								'ヒットしなかった
								strWriteLine = row(0) & vbTab & row(1) & vbTab & row(2) & vbTab & ""
								sw.WriteLine(strWriteLine)

								swLog.WriteLine(row(0) & vbTab & row(1) & vbTab & row(2) & vbTab & "" & vbTab & "ヒットしなかった")

							End If
						End Using

					End While

				End Using

			End Using

		End Using

		MessageBox.Show("終了しました", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information)

	End Sub
End Class
