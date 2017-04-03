Imports System
Imports Microsoft.VisualBasic.FileIO

Public Class Form1
	Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

		If MessageBox.Show("処理を開始します" & vbNewLine & "よろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
			Exit Sub
		End If

		Dim strSQL As String = ""
		Dim sqlProcess As New SQLProcess
		Dim strCSVFile As String = Me.TextBox1.Text

		Try
			'strSQL = "DELETE FROM T_目次"
			'sqlProcess.DB_UPDATE(strSQL)

			Using parser As New TextFieldParser(strCSVFile, System.Text.Encoding.UTF8)

				parser.TextFieldType = FieldType.Delimited
				parser.SetDelimiters(vbTab)

				parser.HasFieldsEnclosedInQuotes = True
				parser.TrimWhiteSpace = False

				Dim strOldKey As String = ""
				Dim iRecordCount As Integer = 0

				While Not parser.EndOfData

					Dim row As String() = parser.ReadFields()
					strSQL = "SELECT ID FROM M_冊子 "
					strSQL &= "WHERE 年号 = '" & row(0) & "' AND Vol = '" & row(1) & "' AND No = '" & row(2) & "'"
					Dim dtID As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
					If dtID.Rows.Count = 0 Then
						MessageBox.Show("該当の年号、Vol、Noがマスタデータに見つかりませんでした" & vbNewLine & "[" & row(0) & "][" & row(1) & "][" & row(2) & "]")
						Exit Sub
					End If
					If strOldKey = dtID.Rows(0)("ID") Then
						'キーが全て合致したらインクリメント
						iRecordCount += 1
						strSQL = "INSERT INTO T_目次 (ID, レコード番号, 目次タイトル, 著者名, リンク, リンクTO, 備考) "
						strSQL &= "VALUES(N'" & dtID.Rows(0)("ID") & "', " & iRecordCount & ", N'" & row(3).Replace("'", "''") & "', N'" & row(4).Replace("'", "''") & "', N'', N'', N'')"
						sqlProcess.DB_UPDATE(strSQL)
					Else
						'キーが変わったら、strOldKeyの最終レコードに「広告」、現在のキーの先頭レコードに「表紙」「広告」のレコードを追加する
						'レコード番号はインクリメントして最終レコード書き込み後、リセット
						'strOldKeyの内容が全てから文字だった場合、一番先頭のレコード
						If IsNull(strOldKey) Then
							'「表紙」「広告」レコードを挿入
							iRecordCount = 1
							strSQL = "INSERT INTO T_目次 (ID, レコード番号, 目次タイトル, 著者名, リンク, リンクTO, 備考) "
							strSQL &= "VALUES(N'" & dtID.Rows(0)("ID") & "', " & iRecordCount & ", N'表紙', N'', N'', N'', N'')"
							sqlProcess.DB_UPDATE(strSQL)
							iRecordCount += 1
							strSQL = "INSERT INTO T_目次 (ID, レコード番号, 目次タイトル, 著者名, リンク, リンクTO, 備考) "
							strSQL &= "VALUES(N'" & dtID.Rows(0)("ID") & "', " & iRecordCount & ", N'広告', N'', N'', N'', N'')"
							sqlProcess.DB_UPDATE(strSQL)
							'実データの書き込み
							iRecordCount += 1
							strSQL = "INSERT INTO T_目次 (ID, レコード番号, 目次タイトル, 著者名, リンク, リンクTO, 備考) "
							strSQL &= "VALUES(N'" & dtID.Rows(0)("ID") & "', " & iRecordCount & ", N'" & row(3).Replace("'", "''") & "', N'" & row(4).Replace("'", "''") & "', N'', N'', N'')"
							sqlProcess.DB_UPDATE(strSQL)
						Else
							'純粋にキーが違う
							'最終レコードを書き込む
							iRecordCount += 1
							strSQL = "INSERT INTO T_目次 (ID, レコード番号, 目次タイトル, 著者名, リンク, リンクTO, 備考) "
							strSQL &= "VALUES(N'" & strOldKey & "', " & iRecordCount & ", N'広告', N'', N'', N'', N'')"
							sqlProcess.DB_UPDATE(strSQL)
							'現在キーの先頭レコードを書き込む
							iRecordCount = 1
							strSQL = "INSERT INTO T_目次 (ID, レコード番号, 目次タイトル, 著者名, リンク, リンクTO, 備考) "
							strSQL &= "VALUES(N'" & dtID.Rows(0)("ID") & "', " & iRecordCount & ", N'表紙', N'', N'', N'', N'')"
							sqlProcess.DB_UPDATE(strSQL)
							iRecordCount += 1
							strSQL = "INSERT INTO T_目次 (ID, レコード番号, 目次タイトル, 著者名, リンク, リンクTO, 備考) "
							strSQL &= "VALUES(N'" & dtID.Rows(0)("ID") & "', " & iRecordCount & ", N'広告', N'', N'', N'', N'')"
							sqlProcess.DB_UPDATE(strSQL)
							'実データの書き込み
							iRecordCount += 1
							strSQL = "INSERT INTO T_目次 (ID, レコード番号, 目次タイトル, 著者名, リンク, リンクTO, 備考) "
							strSQL &= "VALUES(N'" & dtID.Rows(0)("ID") & "', " & iRecordCount & ", N'" & row(3).Replace("'", "''") & "', N'" & row(4).Replace("'", "''") & "', N'', N'', N'')"
							sqlProcess.DB_UPDATE(strSQL)
						End If
					End If
					'現在のキーを旧キーとして保持する
					strOldKey = dtID.Rows(0)("ID")
				End While
				'最終冊子の「広告」を挿入する
				strSQL = "INSERT INTO T_目次 (ID, レコード番号, 目次タイトル, 著者名, リンク, リンクTO, 備考) "
				strSQL &= "VALUES(N'" & strOldKey & "', " & iRecordCount + 1 & ", N'広告', N'', N'', N'', N'')"
				sqlProcess.DB_UPDATE(strSQL)

			End Using

			MessageBox.Show("処理が終了しました", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information)

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		Finally

			sqlProcess.Close()

		End Try
	End Sub
End Class
