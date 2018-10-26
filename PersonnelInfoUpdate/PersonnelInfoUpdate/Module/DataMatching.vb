Module DataMatching

	Public Function DataCheck(ByVal strLotID As String, ByVal lstResult As ListBox) As Boolean

		Dim strSQL As String = ""
		Dim sqlProcess As New SQLProcess

		Try
			'異動情報テーブルを取得して1レコードずつ回す
			strSQL = "SELECT T1.ロットID, T1.レコード番号, T1.発令日, T1.辞令, T1.ユーザーID, T1.利用者名称, T1.利用者名称カナ, "
			strSQL &= "T1.役職コード, T1.組織コード1, T1.組織コード2, T1.組織コード3, T1.組織コード4, T1.組織コード5, T1.海外, "
			strSQL &= "T1.管理者権限, T1.部門管理者権限, ISNULL(T2.更新区分, 0) AS 更新区分 "
			strSQL &= "FROM T_異動情報 AS T1 LEFT OUTER JOIN "
			strSQL &= "M_辞令 AS T2 ON T1.辞令 = T2.辞令 "
			strSQL &= "WHERE T1.ロットID = '" & strLotID & "' "
			strSQL &= "ORDER BY T1.レコード番号"
			Dim dt As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)

			For iRow As Integer = 0 To dt.Rows.Count - 1

				WriteLstResult(lstResult, "==================================================")
				WriteLstResult(lstResult, "データチェック：" & dt.Rows(iRow)("ユーザーID") & "：" & dt.Rows(iRow)("利用者名称"))
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
					WriteLstResult(lstResult, "ユーザーID：利用者情報に存在しない：" & dt.Rows(iRow)("ユーザーID"), ResultMark.ErrorMark)
					WriteUnmatch(dt.Rows(iRow)("ロットID"), dt.Rows(iRow)("レコード番号"), "ユーザーID", "利用者情報に存在しない", dt.Rows(iRow)("ユーザーID"))
					Continue For
				End If
				'==================================================
				'更新区分が「2」の場合は、ユーザーID以外のデータチェックは行わない
				'==================================================
				If dt.Rows(iRow)("更新区分") = 2 Then
					Continue For
				End If
				'同一ロットで異動情報内に同一ユーザーIDが重複して登録されていたおり、
				'「発令日」「辞令」「利用者名称」「利用者名称カナ」「役職コード」「海外」「管理者権限」「部門管理者権限」の
				'いずれかの内容が相違している場合は不備とする
				strSQL = "SELECT ロットID, ユーザーID, 発令日, 辞令, 利用者名称, 利用者名称カナ, 役職コード, "
				strSQL &= "管理者権限, 部門管理者権限 "
				strSQL &= "FROM T_異動情報 "
				strSQL &= "WHERE ロットID = '" & strLotID & "' "
				strSQL &= "AND ユーザーID = '" & dt.Rows(iRow)("ユーザーID") & "' "
				strSQL &= "GROUP BY ロットID, ユーザーID, 発令日, 辞令, 利用者名称, 利用者名称カナ, 役職コード, "
				strSQL &= "管理者権限, 部門管理者権限"
				Dim dtCount As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
				If dtCount.Rows.Count > 1 Then
					'２件以上同一ユーザーIDがあった
					'不備内容に書き込む
					WriteLstResult(lstResult, "ユーザーID：同一ユーザーID、値相違あり：" & dt.Rows(iRow)("ユーザーID"), ResultMark.ErrorMark)
					WriteUnmatch(dt.Rows(iRow)("ロットID"), dt.Rows(iRow)("レコード番号"), "ユーザーID", "同一ユーザーIDあり、値相違あり", dt.Rows(iRow)("ユーザーID"))
				End If
				'発令日が存在する日付かどうか調べる
				Dim dtDate As DateTime
				If Not DateTime.TryParse(dt.Rows(iRow)("発令日"), dtDate) Or IsNull(dt.Rows(iRow)("発令日")) Then
					'発令日が日付型に変換できなかったためエラー
					'不備内容に書き込む
					WriteLstResult(lstResult, "発令日：日付不備：" & dt.Rows(iRow)("発令日"), ResultMark.ErrorMark)
					WriteUnmatch(dt.Rows(iRow)("ロットID"), dt.Rows(iRow)("レコード番号"), "発令日", "日付不備", dt.Rows(iRow)("発令日"))
					'Continue For
				End If
				'利用者名称が利用者情報のレコードと合致するか調べる
				Dim strName1 As String = dt.Rows(iRow)("利用者名称").ToString.Replace(" ", "").Replace("　", "")
				Dim strName2 As String = dtOrg.Rows(0)("利用者名称").ToString.Replace(" ", "").Replace("　", "")
				If Not strName1 = strName2 Or IsNull(strName1) Then
					'利用者指名が相違している
					'不備内容に書き込む
					WriteLstResult(lstResult, "利用者名称：氏名相違：" & strName1 & "(" & strName2 & ")", ResultMark.ErrorMark)
					WriteUnmatch(dt.Rows(iRow)("ロットID"), dt.Rows(iRow)("レコード番号"), "利用者名称", "氏名相違", strName1 & "(" & strName2 & ")")
					'Continue For
				End If
				'辞令(更新区分)のチェック
				'NULL(0)であった場合エラー
				If dt.Rows(iRow)("更新区分") = 0 Then
					WriteLstResult(lstResult, "利用者名称：辞令が空欄", ResultMark.ErrorMark)
					WriteUnmatch(dt.Rows(iRow)("ロットID"), dt.Rows(iRow)("レコード番号"), "辞令", "辞令が空欄", "")
				End If

				'利用者名称カナが利用者情報のレコードと合致するか調べる
				'==================================================
				'辞令が「人事異動」であった場合はカナチェックを行わない
				'==================================================
				If Not dt.Rows(iRow)("辞令") = "人事異動" Then
					Dim strNameKana1 As String = dt.Rows(iRow)("利用者名称カナ").ToString.Replace(" ", "").Replace("　", "")
					Dim strNameKana2 As String = dtOrg.Rows(0)("利用者名称カナ").ToString.Replace(" ", "").Replace("　", "")
					If Not strNameKana1 = strNameKana2 Or IsNull(strNameKana1) Then
						'利用者指名が相違している
						'不備内容に書き込む
						WriteLstResult(lstResult, "利用者名称：氏名相違：" & strNameKana1 & "(" & strNameKana2 & ")", ResultMark.ErrorMark)
						WriteUnmatch(dt.Rows(iRow)("ロットID"), dt.Rows(iRow)("レコード番号"), "利用者名称カナ", "氏名相違", strNameKana1 & "(" & strNameKana2 & ")")
						'Continue For
					End If
				End If
				'役職コードがマスタに存在するか調べる
				'NULLなら不備ではない
				If Not IsNull(dt.Rows(iRow)("役職コード")) Then
					'NULLではない場合は、役職マスタに登録されているか確認
					'アンダースコアで分割して最後の要素を採用
					Dim strItems As String() = dt.Rows(iRow)("役職コード").ToString.Split("_")
					Dim strItem As String = strItems(strItems.Count - 1)    '最後の要素
					strSQL = "SELECT COUNT(*) FROM M_役職 "
					strSQL &= "WHERE 役職コード = '" & strItem & "'"
					If sqlProcess.DB_EXECUTE_SCALAR(strSQL) = 0 Then
						'役職コードが存在しなかったらエラー
						'不備内容に書き込む
						WriteLstResult(lstResult, "役職コード：マスタに存在しない：" & dt.Rows(iRow)("役職コード"), ResultMark.ErrorMark)
						WriteUnmatch(dt.Rows(iRow)("ロットID"), dt.Rows(iRow)("レコード番号"), "役職コード", "マスタに存在しない", dt.Rows(iRow)("役職コード"))
					End If
				End If
				'組織コード1～5がマスタに存在するか調べる
				'組織コード1はNULLの場合はエラー
				'組織コード1
				If IsNull(dt.Rows(iRow)("組織コード1")) Then
					'組織コード1がNULLなのでエラー
					'不備内容に書き込む
					WriteLstResult(lstResult, "組織コード1：NULLエラー", ResultMark.ErrorMark)
					WriteUnmatch(dt.Rows(iRow)("ロットID"), dt.Rows(iRow)("レコード番号"), "組織コード1", "NULLエラー", "")
				Else
					'NULLではない場合
					'組織情報に存在するか調べる
					'アンダースコアで分割して最後の要素を採用
					Dim strItems As String() = dt.Rows(iRow)("組織コード1").ToString.Split("_")
					Dim strItem As String = strItems(strItems.Count - 1)    '最後の要素
					strSQL = "SELECT COUNT(*) FROM M_組織情報 "
					strSQL &= "WHERE 第1階層組織コード = '" & strItem & "' "
					strSQL &= "OR 第2階層組織コード = '" & strItem & "' "
					strSQL &= "OR 第3階層組織コード = '" & strItem & "'"
					If sqlProcess.DB_EXECUTE_SCALAR(strSQL) = 0 Then
						'組織コードが存在しなかったらエラー
						'不備内容に書き込む
						WriteLstResult(lstResult, "組織コード1：マスタに存在しない：" & dt.Rows(iRow)("組織コード1"), ResultMark.ErrorMark)
						WriteUnmatch(dt.Rows(iRow)("ロットID"), dt.Rows(iRow)("レコード番号"), "組織コード1", "マスタに存在しない", dt.Rows(iRow)("組織コード1"))
					End If
				End If
				'組織コード2
				'NULLなら不備ではない
				If Not IsNull(dt.Rows(iRow)("組織コード2")) Then
					'NULLではない場合は、組織情報に登録されているか確認
					'アンダースコアで分割して最後の要素を採用
					Dim strItems As String() = dt.Rows(iRow)("組織コード2").ToString.Split("_")
					Dim strItem As String = strItems(strItems.Count - 1)    '最後の要素
					strSQL = "SELECT COUNT(*) FROM M_組織情報 "
					strSQL &= "WHERE 第1階層組織コード = '" & strItem & "' "
					strSQL &= "OR 第2階層組織コード = '" & strItem & "' "
					strSQL &= "OR 第3階層組織コード = '" & strItem & "'"
					If sqlProcess.DB_EXECUTE_SCALAR(strSQL) = 0 Then
						'組織コードが存在しなかったらエラー
						'不備内容に書き込む
						WriteLstResult(lstResult, "組織コード2：マスタに存在しない：" & dt.Rows(iRow)("組織コード2"), ResultMark.ErrorMark)
						WriteUnmatch(dt.Rows(iRow)("ロットID"), dt.Rows(iRow)("レコード番号"), "組織コード2", "マスタに存在しない", dt.Rows(iRow)("組織コード2"))
					End If
				End If
				'組織コード3
				'NULLなら不備ではない
				If Not IsNull(dt.Rows(iRow)("組織コード3")) Then
					'NULLではない場合は、組織情報に登録されているか確認
					'アンダースコアで分割して最後の要素を採用
					Dim strItems As String() = dt.Rows(iRow)("組織コード3").ToString.Split("_")
					Dim strItem As String = strItems(strItems.Count - 1)    '最後の要素
					strSQL = "SELECT COUNT(*) FROM M_組織情報 "
					strSQL &= "WHERE 第1階層組織コード = '" & strItem & "' "
					strSQL &= "OR 第2階層組織コード = '" & strItem & "' "
					strSQL &= "OR 第3階層組織コード = '" & strItem & "'"
					If sqlProcess.DB_EXECUTE_SCALAR(strSQL) = 0 Then
						'組織コードが存在しなかったらエラー
						'不備内容に書き込む
						WriteLstResult(lstResult, "組織コード3：マスタに存在しない：" & dt.Rows(iRow)("組織コード3"), ResultMark.ErrorMark)
						WriteUnmatch(dt.Rows(iRow)("ロットID"), dt.Rows(iRow)("レコード番号"), "組織コード3", "マスタに存在しない", dt.Rows(iRow)("組織コード3"))
					End If
				End If
				'組織コード4
				'NULLなら不備ではない
				If Not IsNull(dt.Rows(iRow)("組織コード4")) Then
					'NULLではない場合は、組織情報に登録されているか確認
					'アンダースコアで分割して最後の要素を採用
					Dim strItems As String() = dt.Rows(iRow)("組織コード4").ToString.Split("_")
					Dim strItem As String = strItems(strItems.Count - 1)    '最後の要素
					strSQL = "SELECT COUNT(*) FROM M_組織情報 "
					strSQL &= "WHERE 第1階層組織コード = '" & strItem & "' "
					strSQL &= "OR 第2階層組織コード = '" & strItem & "' "
					strSQL &= "OR 第3階層組織コード = '" & strItem & "'"
					If sqlProcess.DB_EXECUTE_SCALAR(strSQL) = 0 Then
						'組織コードが存在しなかったらエラー
						'不備内容に書き込む
						WriteLstResult(lstResult, "組織コード4：マスタに存在しない：" & dt.Rows(iRow)("組織コード4"), ResultMark.ErrorMark)
						WriteUnmatch(dt.Rows(iRow)("ロットID"), dt.Rows(iRow)("レコード番号"), "組織コード4", "マスタに存在しない", dt.Rows(iRow)("組織コード4"))
					End If
				End If
				'組織コード5
				'NULLなら不備ではない
				If Not IsNull(dt.Rows(iRow)("組織コード5")) Then
					'NULLではない場合は、組織情報に登録されているか確認
					'アンダースコアで分割して最後の要素を採用
					Dim strItems As String() = dt.Rows(iRow)("組織コード5").ToString.Split("_")
					Dim strItem As String = strItems(strItems.Count - 1)    '最後の要素
					strSQL = "SELECT COUNT(*) FROM M_組織情報 "
					strSQL &= "WHERE 第1階層組織コード = '" & strItem & "' "
					strSQL &= "OR 第2階層組織コード = '" & strItem & "' "
					strSQL &= "OR 第3階層組織コード = '" & strItem & "'"
					If sqlProcess.DB_EXECUTE_SCALAR(strSQL) = 0 Then
						'組織コードが存在しなかったらエラー
						'不備内容に書き込む
						WriteLstResult(lstResult, "組織コード5：マスタに存在しない：" & dt.Rows(iRow)("組織コード5"), ResultMark.ErrorMark)
						WriteUnmatch(dt.Rows(iRow)("ロットID"), dt.Rows(iRow)("レコード番号"), "組織コード5", "マスタに存在しない", dt.Rows(iRow)("組織コード5"))
					End If
				End If

				WriteLstResult(lstResult, "==================================================")
			Next

			Return True

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & ex.StackTrace)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Return False

		Finally

			sqlProcess.Close()

		End Try

	End Function

	''' <summary>
	''' アンマッチ項目を書き込む
	''' </summary>
	''' <param name="strLotID">ロットID</param>
	''' <param name="iRecordNumber">レコード番号</param>
	''' <param name="strUnmatchItem">不備項目</param>
	''' <param name="strUnmatchRemarks">不備説明</param>
	''' <param name="strUnmatchContents">不備内容</param>
	Public Sub WriteUnmatch(ByVal strLotID As String, ByVal iRecordNumber As Integer, ByVal strUnmatchItem As String,
							ByVal strUnmatchRemarks As String, ByVal strUnmatchContents As String)

		Dim strSQL As String = ""
		Dim sqlProcess As New SQLProcess

		Try
			'シーケンスの最終連番を取得する
			strSQL = "SELECT MAX(ISNULL(シーケンス, 0)) + 1 FROM T_不備内容 "
			strSQL = "WHERE ロットID = '" & strLotID & "' "
			strSQL &= "AND レコード番号 = " & iRecordNumber
			Dim iSeq As Integer = sqlProcess.DB_EXECUTE_SCALAR(strSQL)
			'異動情報を取得
			strSQL = "SELECT ロットID, レコード番号, 発令日, 辞令, ユーザーID, 利用者名称, 利用者名称カナ, 役職コード, "
			strSQL &= "組織コード1, 組織コード2, 組織コード3, 組織コード4, 組織コード5 "
			strSQL &= "FROM T_異動情報 "
			strSQL &= "WHERE ロットID = '" & strLotID & "' "
			strSQL &= "AND レコード番号 = " & iRecordNumber
			Dim dt As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
			'不備情報をINSERT
			strSQL = "INSERT INTO T_不備内容(ロットID, レコード番号, シーケンス, 発令日, 辞令, ユーザーID, 利用者名称, 利用者名称カナ, "
			strSQL &= "役職コード, 組織コード1, 組織コード2, 組織コード3, 組織コード4, 組織コード5, 不備項目, 不備説明, 不備内容, "
			strSQL &= "修正内容, 修正済フラグ) VALUES("
			strSQL &= "'" & strLotID & "'"
			strSQL &= ", " & iRecordNumber
			strSQL &= ", " & iSeq
			strSQL &= ", '" & dt.Rows(0)("発令日") & "'"
			strSQL &= ", '" & dt.Rows(0)("辞令") & "'"
			strSQL &= ", '" & dt.Rows(0)("ユーザーID") & "'"
			strSQL &= ", '" & dt.Rows(0)("利用者名称") & "'"
			strSQL &= ", '" & dt.Rows(0)("利用者名称カナ") & "'"
			strSQL &= ", '" & dt.Rows(0)("役職コード") & "'"
			strSQL &= ", '" & dt.Rows(0)("組織コード1") & "'"
			strSQL &= ", '" & dt.Rows(0)("組織コード2") & "'"
			strSQL &= ", '" & dt.Rows(0)("組織コード3") & "'"
			strSQL &= ", '" & dt.Rows(0)("組織コード4") & "'"
			strSQL &= ", '" & dt.Rows(0)("組織コード5") & "'"
			strSQL &= ", '" & strUnmatchItem & "'"  '不備項目
			strSQL &= ", '" & strUnmatchRemarks & "'"   '不備説明
			strSQL &= ", '" & strUnmatchContents & "'"  '不備内容
			strSQL &= ", ''"    '修正内容
			strSQL &= ", 0)"    '修正済フラグ
			sqlProcess.DB_UPDATE(strSQL)

			'ロット管理テーブルに要修正日時を書き込む
			strSQL = "UPDATE T_ロット管理 SET 要修正日時 = '" & Date.Now.ToString("yyyy/MM/dd HH:mm:ss") & "'"
			strSQL &= "WHERE ロットID = '" & strLotID & "'"
			sqlProcess.DB_UPDATE(strSQL)

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & ex.StackTrace)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		Finally

			sqlProcess.Close()

		End Try

	End Sub

	''' <summary>
	''' T_利用者情報出力にデータを書き込む
	''' </summary>
	''' <param name="strLotID"></param>
	''' <param name="lstResult"></param>
	''' <returns></returns>
	Public Function OutputData(ByVal strLotID As String, ByVal lstResult As ListBox) As Boolean

		Dim strSQL As String = ""
		Dim sqlProcess As New SQLProcess

		Try
			WriteLstResult(lstResult, "出力テーブル作成開始：" & strLotID)
			strSQL = "SELECT T1.ロットID, T1.レコード番号, T1.発令日, T1.辞令, T1.ユーザーID, T1.利用者名称, T1.利用者名称カナ, "
			strSQL &= "T1.役職コード, T1.組織コード1, T1.組織コード2, T1.組織コード3, T1.組織コード4, T1.組織コード5, T1.海外, "
			strSQL &= "T1.管理者権限, T1.部門管理者権限, ISNULL(T2.更新区分, 0) AS 更新区分 "
			strSQL &= "FROM T_異動情報 AS T1 LEFT OUTER JOIN "
			strSQL &= "M_辞令 AS T2 ON T1.辞令 = T2.辞令 "
			strSQL &= "WHERE T1.ロットID = '" & strLotID & "' "
			strSQL &= "ORDER BY T1.レコード番号"
			Dim dt As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
			For iRow As Integer = 0 To dt.Rows.Count - 1
				WriteLstResult(lstResult, "=== ユーザーID(利用者名称)：" & dt.Rows(iRow)("ユーザーID") & "(" & dt.Rows(iRow)("利用者名称") & "===")
				'あらかじめ最下位の組織コードを取得しておく
				'組織コード5からNULLチェックを行い、NULLじゃなかったらその値を登録する
				Dim strOrgCode As String = ""   '組織コード格納用
				Dim strItems As String() = Nothing
				If IsNull(dt.Rows(iRow)("組織コード5").ToString) Then
					If IsNull(dt.Rows(iRow)("組織コード4").ToString) Then
						If IsNull(dt.Rows(iRow)("組織コード3").ToString) Then
							If IsNull(dt.Rows(iRow)("組織コード2").ToString) Then
								'組織コード1を採用
								strItems = dt.Rows(iRow)("組織コード1").ToString.Split("_")
							Else
								'組織コード2を採用
								strItems = dt.Rows(iRow)("組織コード2").ToString.Split("_")
							End If
						Else
							'組織コード3を採用
							strItems = dt.Rows(iRow)("組織コード3").ToString.Split("_")
						End If
					Else
						'組織コード4を採用
						strItems = dt.Rows(iRow)("組織コード4").ToString.Split("_")
					End If
				Else
					'組織コード5を採用
					strItems = dt.Rows(iRow)("組織コード5").ToString.Split("_")
				End If
				strOrgCode = strItems(strItems.Count - 1)

				'利用者情報を取得しておく
				strSQL = "SELECT 利用者名称カナ, 役職コード, 有効期間From, 有効期間To, 連絡優先フラグ, 音声自動発信フラグ, "
				strSQL &= "都道府県コード, 勤務地都道府県コード "
				strSQL &= "FROM T_利用者情報 "
				strSQL &= "WHERE ロットID = '" & strLotID & "' "
				strSQL &= "AND 社員番号 = '" & dt.Rows(iRow)("ユーザーID") & "'"
				Dim dtOrg As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)

				'既に同一ユーザーIDが利用者情報出力に登録されていたら兼務として登録する
				strSQL = "SELECT COUNT(*) FROM T_利用者情報出力 "
				strSQL &= "WHERE ロットID = '" & strLotID & "' "
				strSQL &= "AND 社員番号 = '" & dt.Rows(iRow)("ユーザーID") & "'"
				'利用者情報にユーザーIDが必ず存在する前提
				If sqlProcess.DB_EXECUTE_SCALAR(strSQL) > 0 Then
					'既に登録されていた
					'組織コードの2～5を若い順から値が入っているかチェックして入っていない項目に値をセットする
					strSQL = "UPDATE T_利用者情報出力 SET "
					If Not IsNull(dt.Rows(iRow)("組織コード2").ToString) Then
						If Not IsNull(dt.Rows(iRow)("組織コード3").ToString) Then
							If Not IsNull(dt.Rows(iRow)("組織コード4").ToString) Then
								'組織コード5
								strSQL &= "組織コード5 = '" & strOrgCode & "' "
								WriteLstResult(lstResult, "重複レコードあり、組織コード5に書き込み：" & strOrgCode)
							Else
								'組織コード4
								strSQL &= "組織コード4 = '" & strOrgCode & "' "
								WriteLstResult(lstResult, "重複レコードあり、組織コード4に書き込み：" & strOrgCode)
							End If
						Else
							'組織コード3
							strSQL &= "組織コード3 = '" & strOrgCode & "' "
							WriteLstResult(lstResult, "重複レコードあり、組織コード3に書き込み：" & strOrgCode)
						End If
					Else
						'組織コード2
						strSQL &= "組織コード2 = '" & strOrgCode & "' "
						WriteLstResult(lstResult, "重複レコードあり、組織コード2に書き込み：" & strOrgCode)
					End If
					strSQL &= "WHERE ロットID = '" & strLotID & "' "
					strSQL &= "AND ユーザーID = '" & dt.Rows(iRow)("ユーザーID") & "'"
					sqlProcess.DB_UPDATE(strSQL)
				Else
					'新規
					'更新区分で分岐
					If dt.Rows(iRow)("更新区分") = 1 Then
						'新規、更新
						If dt.Rows(iRow)("辞令") = "採用" Then
							WriteLstResult(lstResult, "更新区分：新規追加")
						Else
							WriteLstResult(lstResult, "更新区分：更新")
						End If

						'正規
						'異動情報の値を登録する
						'足りない項目は利用者情報から取得する
						strSQL = "INSERT INTO T_利用者情報出力(ロットID, レコード番号, 更新区分, 社員番号, 利用者名称, 利用者名称カナ, "
						strSQL &= "役職コード別名, 所属組織コード1, 有効期間From, 有効期間To, 連絡優先フラグ, IVR有りフラグ, "
						strSQL &= "所属組織コード2, 所属組織コード3, 所属組織コード4, 所属組織コード5, メールアドレス1, メールアドレス2, "
						strSQL &= "電話番号1, 電話番号2, 都道府県コード, 勤務地都道府県コード) VALUES("
						strSQL &= "'" & strLotID & "'"
						strSQL &= ", '" & dt.Rows(iRow)("レコード番号") & "'"
						strSQL &= ", '" & dt.Rows(iRow)("更新区分") & "'"
						strSQL &= ", '" & dt.Rows(iRow)("ユーザーID") & "'"
						strSQL &= ", '" & dt.Rows(iRow)("利用者名称") & "'"
						If IsNull(dt.Rows(iRow)("利用者名称カナ").ToString) Then
							'移動情報がNULLの場合は利用者情報から取得する
							strSQL &= ", '" & dtOrg.Rows(0)("利用者名称カナ") & "'"
						Else
							strSQL &= ", '" & dt.Rows(iRow)("利用者名称カナ") & "'"
						End If
						If IsNull(dt.Rows(iRow)("役職コード").ToString) Then
							If IsNull(dtOrg.Rows(0)("役職コード別名").ToString) Then
								strSQL &= ", ''"
							Else
								strSQL &= ", '" & dtOrg.Rows(0)("役職コード別名") & "'"
							End If
						Else
							If IsNull(dt.Rows(iRow)("役職コード").ToString) Then
								strSQL &= ", ''"
							Else
								strItems = dt.Rows(iRow)("役職コード").ToString.Split("_")
								strSQL &= ", '" & strItems(strItems.Count - 1) & "'"
							End If
						End If
						strSQL &= ", '" & strOrgCode & "'"  '組織コード1
						'有効期間Fromは辞令が「採用」か「人事異動」で分岐する
						If dt.Rows(iRow)("辞令") = "採用" Then
							'移動情報の発令日を登録
							strSQL &= ", '" & dt.Rows(iRow)("発令日") & "'"
						Else
							strSQL &= ", '" & dtOrg.Rows(0)("有効期間From") & "'"
						End If
						strSQL &= ", '" & dtOrg.Rows(0)("有効期間To") & "'"
						strSQL &= ", '" & dtOrg.Rows(0)("連絡優先フラグ") & "'"
						strSQL &= ", '" & dtOrg.Rows(0)("音声自動発信フラグ") & "'"
						strSQL &= ", ''"    '組織コード2
						strSQL &= ", ''"    '組織コード3
						strSQL &= ", ''"    '組織コード4
						strSQL &= ", ''"    '組織コード5
						strSQL &= ", ''"    'メールアドレス1
						strSQL &= ", ''"    'メールアドレス2
						strSQL &= ", ''"    '電話番号1
						strSQL &= ", ''"    '電話番号2
						'都道府県コード、勤務地都道府県コードは「海外」に「○」がついている場合、空欄、それ以外は利用者情報から取得する
						If dt.Rows(iRow)("海外") = "○" Then
							strSQL &= ", ''"    '都道府県コード
							strSQL &= ", ''"    '勤務地都道府県コード
						Else
							strSQL &= ", '" & dtOrg.Rows(0)("都道府県コード") & "'"
							strSQL &= ", '" & dtOrg.Rows(0)("勤務地都道府県コード") & "')"
						End If
						sqlProcess.DB_UPDATE(strSQL)
					Else
						'削除
						WriteLstResult(lstResult, "削除")
						If dtOrg.Rows.Count > 0 Then
							'利用者情報をINSERT
							strSQL = "INSERT INTO T_利用者情報出力(ロットID, レコード番号, 更新区分, 社員番号, 利用者名称, 利用者名称カナ, "
							strSQL &= "役職コード別名, 所属組織コード1, 有効期間From, 有効期間To, 連絡優先フラグ, IVR有りフラグ, "
							strSQL &= "所属組織コード2, 所属組織コード3, 所属組織コード4, 所属組織コード5, メールアドレス1, メールアドレス2, "
							strSQL &= "電話番号1, 電話番号2, 都道府県コード, 勤務地都道府県コード) VALUES("
							strSQL &= "'" & strLotID & "'"
							strSQL &= ", '" & dt.Rows(iRow)("レコード番号") & "'"
							strSQL &= ", '" & dt.Rows(iRow)("更新区分") & "'"
							strSQL &= ", '" & dtOrg.Rows(0)("社員番号") & "'"
							strSQL &= ", '" & dtOrg.Rows(0)("利用者情報") & "'"
							strSQL &= ", '" & dtOrg.Rows(0)("利用者情報カナ") & "'"
							strSQL &= ", '" & dtOrg.Rows(0)("役職コード別名") & "'"
							strSQL &= ", '" & dtOrg.Rows(0)("所属組織コード1") & "'"
							strSQL &= ", '" & dtOrg.Rows(0)("有効期間From") & "'"
							strSQL &= ", '" & dtOrg.Rows(0)("有効期間To") & "'"
							strSQL &= ", '" & dtOrg.Rows(0)("連絡優先フラグ") & "'"
							strSQL &= ", '" & dtOrg.Rows(0)("IVR有りフラグ") & "'"
							strSQL &= ", '" & dtOrg.Rows(0)("所属組織コード2") & "'"
							strSQL &= ", '" & dtOrg.Rows(0)("所属組織コード3") & "'"
							strSQL &= ", '" & dtOrg.Rows(0)("所属組織コード4") & "'"
							strSQL &= ", '" & dtOrg.Rows(0)("所属組織コード5") & "'"
							strSQL &= ", ''"    'メールアドレス1
							strSQL &= ", ''"    'メールアドレス2
							strSQL &= ", ''"    '電話番号1
							strSQL &= ", ''"    '電話番号2
							strSQL &= ", '" & dtOrg.Rows(0)("都道府県コード") & "'"
							strSQL &= ", '" & dtOrg.Rows(0)("勤務地都道府県コード") & "')"
							sqlProcess.DB_UPDATE(strSQL)

						End If
					End If
				End If
			Next
			WriteLstResult(lstResult, "出力テーブル作成終了：" & strLotID)

			WriteLstResult(lstResult, "CSVファイル作成開始：" & strLotID)
			strSQL = "SELECT ロットID, レコード番号, 更新区分, 社員番号, 利用者名称, 利用者名称カナ, 役職コード別名, 所属組織コード1, "
			strSQL &= "有効期限From, 有効期限To, 連絡優先フラグ, IVR有りフラグ, 所属組織コード2, 所属組織コード3, 所属組織コード4, 所属組織コード5, "
			strSQL &= ""
			WriteLstResult(lstResult, "CSVファイル作成開始：" & strLotID)

			Return True

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & ex.StackTrace)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Return False

		Finally

			sqlProcess.Close()

		End Try

	End Function

	''' <summary>
	''' T_利用者情報出力をもとにCSVファイルを出力する
	''' </summary>
	''' <param name="strLotID"></param>
	''' <param name="strOutputFolder"></param>
	Public Sub OutputCSV(ByVal strLotID As String, ByVal strOutputFolder As String)

	End Sub

End Module
