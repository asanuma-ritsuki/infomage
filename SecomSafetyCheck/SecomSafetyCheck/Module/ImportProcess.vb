Module ImportProcess

	Public Sub ImportSrc(ByVal strImportFile As String, ByVal strAccessFile As String, ByRef iRecCount As Integer)

		Dim strSQL As String = ""
		Dim sqlProcess As New SQLProcess(strAccessFile)

		Try
			Using parser As New CSVParser(strImportFile, System.Text.Encoding.GetEncoding("Shift-JIS"))
				parser.Delimiter = ","
				parser.HasFieldsEnclosedInQuotes = True
				parser.TrimWhiteSpace = False

				iRecCount = 0
				parser.ReadFields() 'ヘッダ行を読み飛ばす
				'最終行まで読み込み
				While Not parser.EndOfData
					Application.DoEvents()
					'レコードの最大値を取得
					strSQL = "SELECT IIF(ISNULL(MAX([ID])), 0, MAX([ID])) + 1 FROM [T_社員数] "
					Dim iID As Integer = sqlProcess.DB_EXECUTE_SCALAR(strSQL)

					Dim row As String() = parser.ReadFields()   '1行読み込み、項目を配列に代入

					'T_社員数に書き込み
					strSQL = "INSERT INTO [T_社員数] ([ID], [更新区分], [社員番号], [利用者名称], [利用者名称カナ], [役職コード別名], [所属組織コード1], [有効期間(From)], [有効期間(To)], "
					strSQL &= "[連絡優先フラグ], [IVR有りフラグ], [所属組織コード2], [所属組織コード3], [所属組織コード4], [所属組織コード5], [メールアドレス１], [メールアドレス２], "
					strSQL &= "[電話番号１], [電話番号２], [都道府県コード], [勤務地都道府県コード], [エラーフラグ]) VALUES ("
					strSQL &= iID   'ID
					strSQL &= ", '" & row(0) & "'"  '更新区分
					strSQL &= ", '" & row(1) & "'"  '社員番号
					strSQL &= ", '" & row(2) & "'"  '利用者名称
					strSQL &= ", '" & row(3) & "'"  '利用者名称カナ
					strSQL &= ", '" & row(4) & "'"  '役職コード別名
					strSQL &= ", '" & row(5) & "'"  '所属組織コード1
					strSQL &= ", '" & row(6) & "'"  '有効期間(From)
					strSQL &= ", '" & row(7) & "'"  '有効期間(To)
					strSQL &= ", '" & row(8) & "'"  '連絡優先フラグ
					strSQL &= ", '" & row(9) & "'"  'IVR有りフラグ
					strSQL &= ", '" & row(10) & "'"  '所属組織コード2
					strSQL &= ", '" & row(11) & "'"  '所属組織コード3
					strSQL &= ", '" & row(12) & "'"  '所属組織コード4
					strSQL &= ", '" & row(13) & "'"  '所属組織コード5
					strSQL &= ", '" & row(14) & "'"  'メールアドレス１
					strSQL &= ", '" & row(15) & "'"  'メールアドレス２
					strSQL &= ", '" & row(16) & "'"  '電話番号１
					strSQL &= ", '" & row(17) & "'"  '電話番号２
					strSQL &= ", '" & row(18) & "'"  '都道府県コード
					strSQL &= ", '" & row(19) & "'"  '勤務地都道府県コード
					strSQL &= ", 0)"  'エラーフラグ
					sqlProcess.DB_UPDATE(strSQL)
					iRecCount += 1
				End While

			End Using

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & ex.StackTrace)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		Finally

			sqlProcess.Close()

		End Try

	End Sub

	Public Sub ImportOrg(ByVal strImportFile As String, ByVal strAccessFile As String, ByRef iRecCount As Integer)

		Dim strSQL As String = ""
		Dim sqlProcess As New SQLProcess(strAccessFile)

		Try
			Using parser As New CSVParser(strImportFile, System.Text.Encoding.GetEncoding("Shift-JIS"))
				parser.Delimiter = ","
				parser.HasFieldsEnclosedInQuotes = True
				parser.TrimWhiteSpace = False

				iRecCount = 0
				parser.ReadFields() 'ヘッダ行を読み飛ばす
				'最終行まで読み込み
				While Not parser.EndOfData
					Application.DoEvents()
					'レコードの最大値を取得
					strSQL = "SELECT IIF(ISNULL(MAX([ID])), 0, MAX([ID])) + 1 FROM [T_事業所数] "
					Dim iID As Integer = sqlProcess.DB_EXECUTE_SCALAR(strSQL)

					Dim row As String() = parser.ReadFields()   '1行読み込み、項目を配列に代入

					'T_社員数に書き込み
					strSQL = "INSERT INTO [T_事業所数] ([ID], [更新区分], [組織コード], [第１階層組織コード], [第２階層組織コード], [第３階層組織コード], "
					strSQL &= "[組織名称], [都道府県コード], [報告確認対象フラグ], [エラーフラグ]) VALUES ("
					strSQL &= iID   'ID
					strSQL &= ", '" & row(0) & "'"  '更新区分
					strSQL &= ", '" & row(1) & "'"  '組織コード
					strSQL &= ", '" & row(2) & "'"  '第１階層組織コード
					strSQL &= ", '" & row(3) & "'"  '第２階層組織コード
					strSQL &= ", '" & row(4) & "'"  '第３階層組織コード
					strSQL &= ", '" & row(5) & "'"  '組織名称
					strSQL &= ", '" & row(6) & "'"  '都道府県コード
					strSQL &= ", '" & row(7) & "'"  '報告確認対象フラグ
					strSQL &= ", 0)"  'エラーフラグ
					sqlProcess.DB_UPDATE(strSQL)
					iRecCount += 1
				End While

			End Using

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & ex.StackTrace)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		Finally

			sqlProcess.Close()

		End Try

	End Sub

	Public Sub ImportManagerSearchlist(ByVal strImportFile As String, ByVal strAccessFile As String, ByRef iRecCount As Integer)

		Dim strSQL As String = ""
		Dim sqlProcess As New SQLProcess(strAccessFile)

		Try
			Using parser As New CSVParser(strImportFile, System.Text.Encoding.GetEncoding("Shift-JIS"))
				parser.Delimiter = ","
				parser.HasFieldsEnclosedInQuotes = True
				parser.TrimWhiteSpace = False

				iRecCount = 0
				parser.ReadFields() 'ヘッダ行を読み飛ばす
				'最終行まで読み込み
				While Not parser.EndOfData
					Application.DoEvents()
					'レコードの最大値を取得
					strSQL = "SELECT IIF(ISNULL(MAX([ID])), 0, MAX([ID])) + 1 FROM [T_管理者数] "
					Dim iID As Integer = sqlProcess.DB_EXECUTE_SCALAR(strSQL)

					Dim row As String() = parser.ReadFields()   '1行読み込み、項目を配列に代入

					'T_社員数に書き込み
					strSQL = "INSERT INTO [T_管理者数] ([ID], [ユーザーＩＤ], [ご利用者名], [役職], [利用者種別], [優先順位], "
					strSQL &= "[メール登録数], [ＴＥＬ登録数], [災害変更通知], [アクセス制御権限], [機能制限], "
					strSQL &= "[所属部署１], [所属部署２], [所属部署３], [所属部署４], [所属部署５], [エラーフラグ]) VALUES ("
					strSQL &= iID   'ID
					strSQL &= ", '" & row(0) & "'"  'ユーザーＩＤ
					strSQL &= ", '" & row(1) & "'"  'ご利用者名
					strSQL &= ", '" & row(2) & "'"  '役職
					strSQL &= ", '" & row(3) & "'"  '利用者種別
					strSQL &= ", '" & row(4) & "'"  '優先順位
					strSQL &= ", '" & row(5) & "'"  'メール登録数
					strSQL &= ", '" & row(6) & "'"  'ＴＥＬ登録数
					strSQL &= ", '" & row(7) & "'"  '災害変更通知
					strSQL &= ", '" & row(8) & "'"  'アクセス制御権限
					strSQL &= ", '" & row(9) & "'"  '機能制限
					strSQL &= ", '" & row(10) & "'"  '所属部署１
					strSQL &= ", '" & row(11) & "'"  '所属部署２
					strSQL &= ", '" & row(12) & "'"  '所属部署３
					strSQL &= ", '" & row(13) & "'"  '所属部署４
					strSQL &= ", '" & row(14) & "'"  '所属部署５
					strSQL &= ", 0)"  'エラーフラグ
					sqlProcess.DB_UPDATE(strSQL)
					iRecCount += 1
				End While

			End Using

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & ex.StackTrace)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		Finally

			SQLProcess.Close()

		End Try

	End Sub

	Public Sub ImportUsrSearchlist(ByVal strImportFile As String, ByVal strAccessFile As String, ByRef iRecCount As Integer)

		Dim strSQL As String = ""
		Dim sqlProcess As New SQLProcess(strAccessFile)

		Try
			Using parser As New CSVParser(strImportFile, System.Text.Encoding.GetEncoding("Shift-JIS"))
				parser.Delimiter = ","
				parser.HasFieldsEnclosedInQuotes = True
				parser.TrimWhiteSpace = False

				iRecCount = 0
				parser.ReadFields() 'ヘッダ行を読み飛ばす
				'最終行まで読み込み
				While Not parser.EndOfData
					Application.DoEvents()
					'レコードの最大値を取得
					'strSQL = "SELECT IIF(ISNULL(MAX([ID])), 0, MAX([ID])) + 1 FROM [T_あんぴくん] "
					'Dim iID As Integer = sqlProcess.DB_EXECUTE_SCALAR(strSQL)

					Dim row As String() = parser.ReadFields()   '1行読み込み、項目を配列に代入

					'T_社員数に書き込み
					'strSQL = "INSERT INTO [T_あんぴくん] ([ID], [ユーザーＩＤ], [音声自動応答ＩＤ], [ご利用者名], [ご利用者名(カナ)], [有効期間], "
					'strSQL &= "[パスワード], [役職], [所属部署１], [所属部署２], [所属部署３], [所属部署４], [所属部署５], "
					'strSQL &= "[エラーフラグ]) VALUES ("
					''strSQL &= iID   'ID
					'strSQL &= iRecCount + 1
					'strSQL &= ", '" & row(0) & "'"  'ユーザーＩＤ
					'strSQL &= ", '" & row(1) & "'"  '音声自動応答ＩＤ
					'strSQL &= ", '" & row(2) & "'"  'ご利用者名
					'strSQL &= ", '" & row(3) & "'"  'ご利用者名(カナ)
					'strSQL &= ", '" & row(4) & "'"  '有効期間
					'strSQL &= ", '" & row(5) & "'"  'パスワード
					'strSQL &= ", '" & row(6) & "'"  '役職
					'strSQL &= ", '" & row(7) & "'"  '所属部署１
					'strSQL &= ", '" & row(8) & "'"  '所属部署２
					'strSQL &= ", '" & row(9) & "'"  '所属部署３
					'strSQL &= ", '" & row(10) & "'"  '所属部署４
					'strSQL &= ", '" & row(11) & "'"  '所属部署５
					'strSQL &= ", 0)"  'エラーフラグ
					strSQL = "INSERT INTO [T_あんぴくん] ([ID], [ユーザーＩＤ], [ご利用者名], [エラーフラグ]) VALUES ("
					strSQL &= iRecCount + 1
					strSQL &= ", '" & row(0) & "'"  'ユーザーＩＤ
					strSQL &= ", '" & row(2) & "'"  'ご利用者名
					strSQL &= ", 0)"  'エラーフラグ

					sqlProcess.DB_UPDATE(strSQL)
					iRecCount += 1
				End While

			End Using

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & ex.StackTrace)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		Finally

			sqlProcess.Close()

		End Try

	End Sub
End Module
