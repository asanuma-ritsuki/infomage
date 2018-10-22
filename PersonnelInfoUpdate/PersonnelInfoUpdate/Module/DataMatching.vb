Module DataMatching

	Public Function DataCheck(ByVal strLotID As String) As Boolean

		Dim strSQL As String = ""
		Dim sqlProcess As New SQLProcess

		Try
			'異動情報テーブルを取得して1レコードずつ回す
			strSQL = "SELECT ロットID, レコード番号, 発令日, 辞令, ユーザーID, 利用者名称, 利用者名称カナ, "
			strSQL &= "役職コード, 組織コード1, 組織コード2, 組織コード3, 組織コード4, 組織コード5, 海外, 管理者権限, 部門管理者権限 "
			strSQL &= "FROM T_異動情報 "
			strSQL &= "WHERE ロットID = '" & strLotID & "' "
			strSQL &= "ORDER BY レコード番号"
			Dim dt As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)

			For iRow As Integer = 0 To dt.Rows.Count - 1
				'ユーザーIDのチェック
				'利用者情報に該当ユーザーIDが存在したらレコードを取得する
				strSQL = "SELECT ロットID, レコード番号, 更新区分, 社員番号, 利用者名称, 利用者名称カナ, "
				strSQL &= "役職コード別名, 所属組織コード1, 有効期間From, 有効期間To, 連絡先フラグ, IVR有りフラグ, "
				strSQL &= "所属組織コード2, 所属組織コード3, 所属組織コード4, 所属組織コード5, "
				strSQL &= "都道府県コード, 勤務地都道府県コード "
				strSQL &= "FROM T_利用者情報 "
				strSQL &= "WHERE ロットID = '" & strLotID & "' "
				strSQL &= "AND 社員番号 = '" & dt.Rows(iRow)("ユーザーID") & "'"
				Dim dtOrg As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
				If dtOrg.Rows.Count = 0 Then
					'ユーザーIDが存在しなかったらエラー
					'不備内容に書き込む

					Continue For
				End If
				'発令日が存在する日付かどうか調べる
				Dim dtDate As DateTime
				If Not DateTime.TryParse(dt.Rows(iRow)("発令日"), dtDate) Or IsNull(dt.Rows(iRow)("発令日")) Then
					'発令日が日付型に変換できなかったためエラー
					'不備内容に書き込む

					'Continue For
				End If
				'利用者名称が利用者情報のレコードと合致するか調べる
				Dim strName1 As String = dt.Rows(iRow)("利用者名称").ToString.Replace(" ", "").Replace("　", "")
				Dim strName2 As String = dtOrg.Rows(0)("利用者名称").ToString.Replace(" ", "").Replace("　", "")
				If Not strName1 = strName2 Or IsNull(strName1) Then
					'利用者指名が相違している
					'不備内容に書き込む

					'Continue For
				End If
				'利用者名称カナが利用者情報のレコードと合致するか調べる
				Dim strNameKana1 As String = dt.Rows(iRow)("利用者名称カナ").ToString.Replace(" ", "").Replace("　", "")
				Dim strNameKana2 As String = dtOrg.Rows(0)("利用者名称カナ").ToString.Replace(" ", "").Replace("　", "")
				If Not strNameKana1 = strNameKana2 Or IsNull(strNameKana1) Then
					'利用者指名が相違している
					'不備内容に書き込む

					'Continue For
				End If
				'役職コードがマスタに存在するか調べる
				'NULLなら不備ではない
				If Not IsNull(dt.Rows(iRow)("役職コード")) Then
					'NULLではない場合は、役職マスタに登録されているか確認
					strSQL = "SELECT COUNT(*) FROM M_役職 "
					strSQL &= "WHERE 役職コード = '" & dt.Rows(iRow)("役職コード") & "'"
					If sqlProcess.DB_EXECUTE_SCALAR(strSQL) = 0 Then
						'役職コードが存在しなかったらエラー
						'不備内容に書き込む

					End If
				End If
				'組織コード1～5がマスタに存在するか調べる
				'組織コード1はNULLの場合はエラー
				'組織コード1
				If IsNull(dt.Rows(iRow)("組織コード1")) Then
					'組織コード1がNULLなのでえらー
					'不備内容に書き込む

				Else
					'NULLではない場合
					'組織情報に存在するか調べる
					strSQL = "SELECT COUNT(*) FROM M_組織情報 "
					strSQL &= "WHERE 第1階層組織コード = '" & dt.Rows(iRow)("組織コード1") & "' "
					strSQL &= "OR 第2階層組織コード = '" & dt.Rows(iRow)("組織コード1") & "' "
					strSQL &= "OR 第3階層組織コード = '" & dt.Rows(iRow)("組織コード1") & "'"
					If sqlProcess.DB_EXECUTE_SCALAR(strSQL) = 0 Then
						'組織コードが存在しなかったらエラー
						'不備内容に書き込む

					End If
				End If
				'組織コード2
				'NULLなら不備ではない
				If Not IsNull(dt.Rows(iRow)("組織コード2")) Then
					'NULLではない場合は、組織情報に登録されているか確認
					strSQL = "SELECT COUNT(*) FROM M_組織情報 "
					strSQL &= "WHERE 第1階層組織コード = '" & dt.Rows(iRow)("組織コード2") & "' "
					strSQL &= "OR 第2階層組織コード = '" & dt.Rows(iRow)("組織コード2") & "' "
					strSQL &= "OR 第3階層組織コード = '" & dt.Rows(iRow)("組織コード2") & "'"
					If sqlProcess.DB_EXECUTE_SCALAR(strSQL) = 0 Then
						'組織コードが存在しなかったらエラー
						'不備内容に書き込む

					End If
				End If
				'組織コード3
				'NULLなら不備ではない
				If Not IsNull(dt.Rows(iRow)("組織コード3")) Then
					'NULLではない場合は、組織情報に登録されているか確認
					strSQL = "SELECT COUNT(*) FROM M_組織情報 "
					strSQL &= "WHERE 第1階層組織コード = '" & dt.Rows(iRow)("組織コード3") & "' "
					strSQL &= "OR 第2階層組織コード = '" & dt.Rows(iRow)("組織コード3") & "' "
					strSQL &= "OR 第3階層組織コード = '" & dt.Rows(iRow)("組織コード3") & "'"
					If sqlProcess.DB_EXECUTE_SCALAR(strSQL) = 0 Then
						'組織コードが存在しなかったらエラー
						'不備内容に書き込む

					End If
				End If
				'組織コード4
				'NULLなら不備ではない
				If Not IsNull(dt.Rows(iRow)("組織コード4")) Then
					'NULLではない場合は、組織情報に登録されているか確認
					strSQL = "SELECT COUNT(*) FROM M_組織情報 "
					strSQL &= "WHERE 第1階層組織コード = '" & dt.Rows(iRow)("組織コード4") & "' "
					strSQL &= "OR 第2階層組織コード = '" & dt.Rows(iRow)("組織コード4") & "' "
					strSQL &= "OR 第3階層組織コード = '" & dt.Rows(iRow)("組織コード4") & "'"
					If sqlProcess.DB_EXECUTE_SCALAR(strSQL) = 0 Then
						'組織コードが存在しなかったらエラー
						'不備内容に書き込む

					End If
				End If
				'組織コード5
				'NULLなら不備ではない
				If Not IsNull(dt.Rows(iRow)("組織コード5")) Then
					'NULLではない場合は、組織情報に登録されているか確認
					strSQL = "SELECT COUNT(*) FROM M_組織情報 "
					strSQL &= "WHERE 第1階層組織コード = '" & dt.Rows(iRow)("組織コード5") & "' "
					strSQL &= "OR 第2階層組織コード = '" & dt.Rows(iRow)("組織コード5") & "' "
					strSQL &= "OR 第3階層組織コード = '" & dt.Rows(iRow)("組織コード5") & "'"
					If sqlProcess.DB_EXECUTE_SCALAR(strSQL) = 0 Then
						'組織コードが存在しなかったらエラー
						'不備内容に書き込む

					End If
				End If

			Next

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & ex.StackTrace)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Return False

		Finally

			sqlProcess.Close()

		End Try

	End Function

End Module
