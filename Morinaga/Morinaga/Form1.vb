Public Class Form1
	Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click

		If MessageBox.Show("処理を開始します", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
			Exit Sub
		End If

		Dim strFiles As String() = GetFilesMostDeep(Me.txtTargetFolder.Text, {"*.csv"})

		For Each strFile As String In strFiles
			'出力ファイルを作成
			Dim strOutFile As String = Me.txtOutFolder.Text & "\" & System.IO.Path.GetFileName(System.IO.Path.GetDirectoryName(strFile)) & "_" & System.IO.Path.GetFileNameWithoutExtension(strFile) & "_カウント.txt"

			Using sw As New System.IO.StreamWriter(strOutFile, False, System.Text.Encoding.GetEncoding("Shift-JIS"))

				Dim strWriteLine As String = ""
				Dim iRecordCount As Integer = 0

				Using parser As New CSVParser(strFile, System.Text.Encoding.GetEncoding("Shift-JIS"))
					parser.Delimiter = ","  'カンマ区切り

					parser.HasFieldsEnclosedInQuotes = True 'データ内にデリミタがあっても区切らない
					parser.TrimWhiteSpace = False   '空白を削除しない
					Dim strHeader As String() = parser.ReadFields() 'ヘッダ行を格納
					'件数格納用配列を作成
					Dim iStringCount(strHeader.Length - 1) As Integer

					strWriteLine = "CSVファイル名" & vbTab & "レコード数"
					For Each strHead As String In strHeader
						strWriteLine &= vbTab & strHead

					Next
					sw.WriteLine(strWriteLine)

					While Not parser.EndOfData

						Dim row As String() = parser.ReadFields()
						iRecordCount += 1
						For iCol As Integer = 0 To strHeader.Count - 1
							Dim iLen As Integer = row(iCol).Length
							If IsNull(iStringCount(iCol)) Then
								iStringCount(iCol) = iLen
							Else
								iStringCount(iCol) += iLen
							End If
						Next
					End While
					'書き込み
					strWriteLine = System.IO.Path.GetFileName(strFile) & vbTab & iRecordCount
					For i As Integer = 0 To strHeader.Count - 1
						strWriteLine &= vbTab & iStringCount(i)
					Next
					sw.WriteLine(strWriteLine)

				End Using

			End Using
		Next

		MessageBox.Show("処理が終了しました", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information)

	End Sub
End Class
