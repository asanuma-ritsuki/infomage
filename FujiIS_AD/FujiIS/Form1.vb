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

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        If MessageBox.Show("ファイルコピーを開始します" & vbNewLine & "よろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
            Exit Sub
        End If

        Dim strSrcFolder As String = Me.txtInput.Text
        Dim strOutFolder As String = Me.txtOutput.Text

        Dim strSQL As String = ""
        Dim sqlProcess As New SQLProcess

        Try

            Using sw As New System.IO.StreamWriter(strOutFolder & "\" & Date.Now.ToString("yyyyMMdd_HHmmss") & "_出力.log", False, System.Text.Encoding.GetEncoding("Shift-JIS"))

                Dim iCount As Integer = 0
                Dim iCount2 As Integer = 0
                Dim iCount3 As Integer = 0
                Dim dt As DataTable = Nothing
                '広告フォルダをコピー
                'strSQL = "SELECT フォルダ番号, ファイル名 FROM T_広告振分 "
                'strSQL &= "WHERE 目次タイトル LIKE '%広告%' AND ファイル名 != '' "
                'strSQL &= "ORDER BY ID"
                'dt = sqlProcess.DB_SELECT_DATATABLE(strSQL)

                'For i As Integer = 0 To dt.Rows.Count - 1
                '    Dim strTargetFile As String = strSrcFolder & "\" & dt.Rows(i)("フォルダ番号") & "\" & dt.Rows(i)("ファイル名") & ".pdf"
                '    Dim strOutFile As String = strOutFolder & "\01広告\" & dt.Rows(i)("ファイル名") & ".pdf"
                '    'If Not System.IO.File.Exists(strTargetFile) Then
                '    '    MessageBox.Show("ファイルが存在しません" & vbNewLine & strTargetFile)
                '    '    Exit Sub
                '    'End If
                '    My.Computer.FileSystem.CopyFile(strTargetFile, strOutFile)
                '    sw.WriteLine("広告：" & strTargetFile & vbTab & strOutFile)
                '    iCount += 1
                'Next
                ''MessageBox.Show("広告：" & iCount, "確認", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'sw.WriteLine("==================================================" & vbNewLine)
                'sw.WriteLine("広告：コピー数：" & iCount & vbNewLine)
                'sw.WriteLine("==================================================" & vbNewLine)

                strSQL = "SELECT フォルダ番号, ファイル名 FROM T_広告振分 "
                strSQL &= "WHERE 目次タイトル NOT LIKE '%広告%' AND ファイル名 != '' AND 目次タイトル LIKE '%表紙%' "
                strSQL &= "ORDER BY ID"
                dt = sqlProcess.DB_SELECT_DATATABLE(strSQL)

                For i As Integer = 0 To dt.Rows.Count - 1
                    Dim strTargetFile As String = strSrcFolder & "\" & dt.Rows(i)("フォルダ番号") & "\" & dt.Rows(i)("ファイル名") & ".pdf"
                    Dim strOutFile As String = strOutFolder & "\02広告以外\01表紙\" & dt.Rows(i)("ファイル名") & ".pdf"
                    'If Not System.IO.File.Exists(strTargetFile) Then
                    '    MessageBox.Show("ファイルが存在しません" & vbNewLine & strTargetFile)
                    '    Exit Sub
                    'End If
                    My.Computer.FileSystem.CopyFile(strTargetFile, strOutFile)
                    sw.WriteLine("広告以外表紙：" & strTargetFile & vbTab & strOutFile)
                    iCount2 += 1
                Next
                'MessageBox.Show("広告以外：" & iCount2, "確認", MessageBoxButtons.OK, MessageBoxIcon.Information)
                sw.WriteLine("==================================================" & vbNewLine)
                sw.WriteLine("広告以外：表紙：コピー数：" & iCount2 & vbNewLine)
                sw.WriteLine("==================================================" & vbNewLine)

                strSQL = "SELECT フォルダ番号, ファイル名 FROM T_広告振分 "
                strSQL &= "WHERE 目次タイトル NOT LIKE '%広告%' AND ファイル名 != '' AND 目次タイトル NOT LIKE '%表紙%' "
                strSQL &= "ORDER BY ID"
                dt = sqlProcess.DB_SELECT_DATATABLE(strSQL)

                For i As Integer = 0 To dt.Rows.Count - 1
                    Dim strTargetFile As String = strSrcFolder & "\" & dt.Rows(i)("フォルダ番号") & "\" & dt.Rows(i)("ファイル名") & ".pdf"
                    Dim strOutFile As String = strOutFolder & "\02広告以外\02表紙以外\" & dt.Rows(i)("ファイル名") & ".pdf"
                    'If Not System.IO.File.Exists(strTargetFile) Then
                    '    MessageBox.Show("ファイルが存在しません" & vbNewLine & strTargetFile)
                    '    Exit Sub
                    'End If
                    My.Computer.FileSystem.CopyFile(strTargetFile, strOutFile)
                    sw.WriteLine("広告以外表紙以外：" & strTargetFile & vbTab & strOutFile)
                    iCount3 += 1
                Next
                'MessageBox.Show("広告以外：" & iCount2, "確認", MessageBoxButtons.OK, MessageBoxIcon.Information)
                sw.WriteLine("==================================================" & vbNewLine)
                sw.WriteLine("広告以外：表紙以外：コピー数：" & iCount3 & vbNewLine)
                sw.WriteLine("==================================================" & vbNewLine)

                MessageBox.Show("全てのファイルをコピーしました", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End Using

        Catch ex As Exception

            Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message)
            MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally

            sqlProcess.Close()

        End Try

    End Sub

End Class
