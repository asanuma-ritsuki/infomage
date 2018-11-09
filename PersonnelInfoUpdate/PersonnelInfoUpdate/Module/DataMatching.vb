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
				WriteLstResult(lstResult, "データチェック：" & dt.Rows(iRow)("ユーザーID") & "：" & dt.Rows(iRow)("利用者名称") & "：" & dt.Rows(iRow)("辞令"))
				'ユーザーIDのチェック
				'利用者情報に該当ユーザーIDが存在したらレコードを取得する
				strSQL = "SELECT ロットID, 社員番号, 利用者名称, 利用者名称カナ, "
				strSQL &= "役職コード別名, 所属組織コード1, 有効期間From, 有効期間To, 連絡優先フラグ, IVR有りフラグ, "
				strSQL &= "所属組織コード2, 所属組織コード3, 所属組織コード4, 所属組織コード5, "
				strSQL &= "都道府県コード, 勤務地都道府県コード "
				strSQL &= "FROM T_利用者情報 "
				strSQL &= "WHERE ロットID = '" & strLotID & "' "
				strSQL &= "AND 社員番号 = '" & dt.Rows(iRow)("ユーザーID") & "'"
				Dim dtOrg As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
				'2018/10/31
				'辞令が「採用」だった場合は利用者情報にデータがないため、比較するデータチェックは行わない
				If Not dt.Rows(iRow)("辞令") = "採用" Then
					If dtOrg.Rows.Count = 0 Then
						'ユーザーIDが存在しなかったらエラー
						'不備内容に書き込む
						WriteLstResult(lstResult, "ユーザーID：利用者情報に存在しない：" & dt.Rows(iRow)("ユーザーID"), ResultMark.ErrorMark)
						WriteUnmatch(dt.Rows(iRow)("ロットID"), dt.Rows(iRow)("レコード番号"), "ユーザーID", "利用者情報に存在しない", dt.Rows(iRow)("ユーザーID"))
						Continue For
					End If
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
				'2018/10/31
				'辞令が「採用」だった場合は利用者情報にデータがないため、比較するデータチェックは行わない
				If Not dt.Rows(iRow)("辞令") = "採用" Then
					Dim strName1 As String = dt.Rows(iRow)("利用者名称").ToString.Replace(" ", "").Replace("　", "").Replace(vbTab, "")
					Dim strName2 As String = dtOrg.Rows(0)("利用者名称").ToString.Replace(" ", "").Replace("　", "").Replace(vbTab, "")
					If Not strName1 = strName2 Or IsNull(strName1) Then
						'利用者名称が相違している
						'不備内容に書き込む
						WriteLstResult(lstResult, "利用者名称：氏名相違：" & strName1 & "(" & strName2 & ")", ResultMark.ErrorMark)
						WriteUnmatch(dt.Rows(iRow)("ロットID"), dt.Rows(iRow)("レコード番号"), "利用者名称", "氏名相違", strName1 & "(" & strName2 & ")")
						'Continue For
					End If
				End If
				'辞令(更新区分)のチェック
				'NULL(0)であった場合エラー
				If dt.Rows(iRow)("更新区分") = 0 Then
					WriteLstResult(lstResult, "利用者名称：辞令が空欄", ResultMark.ErrorMark)
					WriteUnmatch(dt.Rows(iRow)("ロットID"), dt.Rows(iRow)("レコード番号"), "辞令", "辞令が空欄", "")
				End If

				'利用者名称カナが利用者情報のレコードと合致するか調べる
				'==================================================
				'辞令が「人事異動」であった場合はカナチェックを行う→行わない
				'辞令が「採用」であった場合はNULLチェックを行う
				'==================================================
				If dt.Rows(iRow)("辞令") = "人事異動" Then
					'Dim strNameKana1 As String = dt.Rows(iRow)("利用者名称カナ").ToString.Replace(" ", "").Replace("　", "").Replace(vbTab, "")
					'Dim strNameKana2 As String = dtOrg.Rows(0)("利用者名称カナ").ToString.Replace(" ", "").Replace("　", "").Replace(vbTab, "")
					'If Not strNameKana1 = strNameKana2 Or IsNull(strNameKana1) Then
					'	'利用者指名が相違している
					'	'不備内容に書き込む
					'	WriteLstResult(lstResult, "利用者名称：氏名相違：" & strNameKana1 & "(" & strNameKana2 & ")", ResultMark.ErrorMark)
					'	WriteUnmatch(dt.Rows(iRow)("ロットID"), dt.Rows(iRow)("レコード番号"), "利用者名称カナ", "氏名相違", strNameKana1 & "(" & strNameKana2 & ")")
					'	'Continue For
					'End If
				Else
					'採用
					If IsNull(dt.Rows(iRow)("利用者名称カナ")) Then
						'利用者名称カナがNULL
						'不備内容に書き込む
						WriteLstResult(lstResult, "利用者名称カナ：氏名空欄(採用)")
						WriteUnmatch(dt.Rows(iRow)("ロットID"), dt.Rows(iRow)("レコード番号"), "利用者名称カナ", "氏名空欄", "")
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
					WriteUnmatch(dt.Rows(iRow)("ロットID"), dt.Rows(iRow)("レコード番号"), "組織コード1", "組織コード1が空欄", "")
				Else
					'NULLではない場合
					'組織情報に存在するか調べる
					'アンダースコアで分割して最後の要素を採用
					Dim strItems As String() = dt.Rows(iRow)("組織コード1").ToString.Split("_")
					Dim strItem As String = strItems(strItems.Count - 1)    '最後の要素
					strSQL = "SELECT COUNT(*) FROM M_組織情報 "
					strSQL &= "WHERE 組織コード = '" & strItem & "' "
					strSQL &= "OR 第1階層組織コード = '" & strItem & "' "
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
					strSQL &= "WHERE 組織コード = '" & strItem & "' "
					strSQL &= "OR 第1階層組織コード = '" & strItem & "' "
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
					strSQL &= "WHERE 組織コード = '" & strItem & "' "
					strSQL &= "OR 第1階層組織コード = '" & strItem & "' "
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
					strSQL &= "WHERE 組織コード = '" & strItem & "' "
					strSQL &= "OR 第1階層組織コード = '" & strItem & "' "
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
					strSQL &= "WHERE 組織コード = '" & strItem & "' "
					strSQL &= "OR 第1階層組織コード = '" & strItem & "' "
					strSQL &= "OR 第2階層組織コード = '" & strItem & "' "
					strSQL &= "OR 第3階層組織コード = '" & strItem & "'"
					If sqlProcess.DB_EXECUTE_SCALAR(strSQL) = 0 Then
						'組織コードが存在しなかったらエラー
						'不備内容に書き込む
						WriteLstResult(lstResult, "組織コード5：マスタに存在しない：" & dt.Rows(iRow)("組織コード5"), ResultMark.ErrorMark)
						WriteUnmatch(dt.Rows(iRow)("ロットID"), dt.Rows(iRow)("レコード番号"), "組織コード5", "マスタに存在しない", dt.Rows(iRow)("組織コード5"))
					End If
				End If

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
	''' 不備修正時のデータチェック
	''' </summary>
	''' <param name="frm">不備修正画面</param>
	''' <param name="strLotID">ロットID</param>
	''' <param name="iRecordNumber">レコード番号</param>
	''' <param name="iSeq">シーケンス</param>
	''' <returns></returns>
	Public Function DataCheckCorrection(ByVal frm As frmCorrection, ByVal strLotID As String, ByVal iRecordNumber As Integer, ByVal iSeq As Integer) As Boolean

		Dim strSQL As String = ""
		Dim sqlProcess As New SQLProcess

		frm.dtpDate.BorderColor = SystemColors.WindowFrame
		frm.cmbResignation.BorderColor = SystemColors.WindowFrame
		frm.txtUserID.BorderColor = SystemColors.WindowFrame
		frm.txtName.BorderColor = SystemColors.WindowFrame
		frm.txtNameKana.BorderColor = SystemColors.WindowFrame
		frm.cmbPostCode.BorderColor = SystemColors.WindowFrame
		frm.cmbOrg1.BorderColor = SystemColors.WindowFrame
		frm.cmbOrg2.BorderColor = SystemColors.WindowFrame
		frm.cmbOrg3.BorderColor = SystemColors.WindowFrame
		frm.cmbOrg4.BorderColor = SystemColors.WindowFrame
		frm.cmbOrg5.BorderColor = SystemColors.WindowFrame

		Try
			'ユーザーIDのチェック
			'利用者情報に該当ユーザーIDが存在したらレコードを取得する
			strSQL = "SELECT ロットID, 社員番号, 利用者名称, 利用者名称カナ, "
			strSQL &= "役職コード別名, 所属組織コード1, 有効期間From, 有効期間To, 連絡優先フラグ, IVR有りフラグ, "
			strSQL &= "所属組織コード2, 所属組織コード3, 所属組織コード4, 所属組織コード5, "
			strSQL &= "都道府県コード, 勤務地都道府県コード "
			strSQL &= "FROM T_利用者情報 "
			strSQL &= "WHERE ロットID = '" & strLotID & "' "
			strSQL &= "AND 社員番号 = '" & frm.txtUserID.Text & "'"
			Dim dtOrg As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
			If Not frm.cmbResignation.Text = "採用" Then
				If dtOrg.Rows.Count = 0 Then
					'ユーザーID存在エラー
					MessageBox.Show("ユーザーIDが利用者情報に存在しません", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
					frm.txtUserID.BorderColor = Color.Red
					Return False
				Else
					If frm.cmbResignation.Text = "人事異動" Then
						'ユーザーIDが存在していた場合、利用者名称、カナのデータ比較を行う
						Dim strName1 As String = frm.txtName.Text.Replace(" ", "").Replace("　", "").Replace(vbTab, "")
						Dim strName2 As String = dtOrg.Rows(0)("利用者名称").Replace(" ", "").Replace("　", "").Replace(vbTab, "")
						If Not strName1 = strName2 Or IsNull(strName1) Then
							'利用者名称が相違している
							MessageBox.Show("利用者名称が利用者情報のデータと一致しません", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
							frm.txtName.BorderColor = Color.Red
							Return False
						End If
						'2018/11/08
						'人事異動の場合は利用者名称カナのチェックは行わない
						''辞令が「人事異動」であった場合はカナチェックを行う
						'Dim strNameKana1 As String = frm.txtNameKana.Text.Replace(" ", "").Replace("　", "").Replace(vbTab, "")
						'Dim strNameKana2 As String = dtOrg.Rows(0)("利用者名称カナ").Replace(" ", "").Replace("　", "").Replace(vbTab, "")
						'If Not strNameKana1 = strNameKana2 Or IsNull(strNameKana1) Then
						'	'利用者名称カナが相違している
						'	MessageBox.Show("利用者名称カナが利用者情報のデータと一致しません", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
						'	frm.txtNameKana.BorderColor = Color.Red
						'	Return False
						'End If
					End If
				End If
			Else
				'採用
				If IsNull(frm.txtNameKana.Text) Then
					'利用者名称カナがNULL
					MessageBox.Show("利用者名称カナが空欄です", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
					frm.txtNameKana.BorderColor = Color.Red
					Return False
				End If
			End If
			'辞令が「退職」の場合はユーザーID以外のチェックは行わない
			If frm.cmbResignation.Text = "退職" Then
				Return True
			End If
			'発令日が存在する日付かどうか調べる
			Dim dtDate As DateTime
			If Not DateTime.TryParse(frm.dtpDate.Text, dtDate) Or IsNull(frm.dtpDate.Text) Then
				MessageBox.Show("発令日が存在する日付ではありません", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
				frm.dtpDate.BorderColor = Color.Red
				Return False
			End If
			'利用者名称、利用者名称カナに関しては利用者情報と相違していることがあり得るのでエラーチェックを行わない
			'辞令のNULLチェック
			If IsNull(frm.cmbResignation.Text) Then
				MessageBox.Show("辞令が空欄です", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
				frm.cmbResignation.BorderColor = Color.Red
				Return False
			End If


			'役職コードはNULLもあり得るのでチェックしない
			'組織コード1～5は入力内容を信じる
			'組織コード1のみNULLチェックを行う
			If IsNull(frm.cmbOrg1.Text) Then
				MessageBox.Show("組織コード1が空欄です", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
				Return False
			End If

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
			strSQL = "SELECT ISNULL(MAX(シーケンス), 0) + 1 FROM T_不備内容 "
			strSQL &= "WHERE ロットID = '" & strLotID & "' "
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
			strSQL &= "修正内容, 修正済フラグ, 対象外) VALUES("
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
			strSQL &= ", 0, 0)"    '修正済フラグ、対象外
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
			strSQL = "DELETE FROM T_利用者情報出力 "
			strSQL &= "WHERE ロットID = '" & strLotID & "'"
			sqlProcess.DB_UPDATE(strSQL)

			strSQL = "SELECT T1.ロットID, T1.レコード番号, T1.発令日, T1.辞令, T1.ユーザーID, T1.利用者名称, T1.利用者名称カナ, "
			strSQL &= "T1.役職コード, T1.組織コード1, T1.組織コード2, T1.組織コード3, T1.組織コード4, T1.組織コード5, T1.海外, "
			strSQL &= "T1.管理者権限, T1.部門管理者権限, ISNULL(T2.更新区分, 0) AS 更新区分 "
			strSQL &= "FROM T_異動情報 AS T1 LEFT OUTER JOIN "
			strSQL &= "M_辞令 AS T2 ON T1.辞令 = T2.辞令 "
			strSQL &= "WHERE T1.ロットID = '" & strLotID & "' "
			strSQL &= "ORDER BY T1.レコード番号"
			Dim dt As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
			For iRow As Integer = 0 To dt.Rows.Count - 1

				WriteLstResult(lstResult, "=== ユーザーID(利用者名称)：" & dt.Rows(iRow)("ユーザーID") & "(" & dt.Rows(iRow)("利用者名称") & ")===")
				'対象外のレコードは出力対象から除外する
				strSQL = "SELECT 対象外 FROM T_不備内容 "
				strSQL &= "WHERE ロットID = '" & strLotID & "' "
				strSQL &= "AND レコード番号 = " & dt.Rows(iRow)("レコード番号") & " "
				strSQL &= "GROUP BY 対象外"
				If sqlProcess.DB_EXECUTE_SCALAR(strSQL) Then
					'対象外のため出力しない
					WriteLstResult(lstResult, "対象外のため出力しない")
					Continue For
				End If

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
				strSQL = "SELECT 社員番号, 利用者名称, 利用者名称カナ, 役職コード別名, 所属組織コード1, 有効期間From, 有効期間To, "
				strSQL &= "連絡優先フラグ, IVR有りフラグ, 所属組織コード2, 所属組織コード3, 所属組織コード4, 所属組織コード5, "
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
					If Not IsNull(dtOrg.Rows(0)("所属組織コード2").ToString) Then
						If Not IsNull(dtOrg.Rows(0)("所属組織コード3").ToString) Then
							If Not IsNull(dtOrg.Rows(0)("所属組織コード4").ToString) Then
								'組織コード5
								strSQL &= "所属組織コード5 = '" & strOrgCode & "' "
								WriteLstResult(lstResult, "重複レコードあり、所属組織コード5に書き込み：" & strOrgCode)
							Else
								'組織コード4
								strSQL &= "所属組織コード4 = '" & strOrgCode & "' "
								WriteLstResult(lstResult, "重複レコードあり、所属組織コード4に書き込み：" & strOrgCode)
							End If
						Else
							'組織コード3
							strSQL &= "所属組織コード3 = '" & strOrgCode & "' "
							WriteLstResult(lstResult, "重複レコードあり、所属組織コード3に書き込み：" & strOrgCode)
						End If
					Else
						'組織コード2
						strSQL &= "所属組織コード2 = '" & strOrgCode & "' "
						WriteLstResult(lstResult, "重複レコードあり、所属組織コード2に書き込み：" & strOrgCode)
					End If
					strSQL &= "WHERE ロットID = '" & strLotID & "' "
					strSQL &= "AND 社員番号 = '" & dt.Rows(iRow)("ユーザーID") & "'"
					sqlProcess.DB_UPDATE(strSQL)
				Else
					'新規
					'更新区分で分岐
					If dt.Rows(iRow)("更新区分") = 1 Then
						'新規、更新
						If dt.Rows(iRow)("辞令") = "採用" Then
							WriteLstResult(lstResult, "更新区分：新規追加")
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
							strSQL &= ", '" & dt.Rows(iRow)("利用者名称カナ") & "'"
							If IsNull(dt.Rows(iRow)("役職コード").ToString) Then
								strSQL &= ", ''"
							Else
								strItems = dt.Rows(iRow)("役職コード").ToString.Split("_")
								strSQL &= ", '" & strItems(strItems.Count - 1) & "'"
							End If
							strSQL &= ", '" & strOrgCode & "'"  '組織コード1
							'有効期間Fromは移動情報の発令日を登録
							strSQL &= ", '" & CDate(dt.Rows(iRow)("発令日")).ToString("yyyyMMdd") & "'"    '有効期間From
							strSQL &= ", ''"    '有効期間To
							strSQL &= ", '0'"    '連絡先フラグ
							strSQL &= ", '0'"    'IVR有りフラグ
							strSQL &= ", ''"    '組織コード2
							strSQL &= ", ''"    '組織コード3
							strSQL &= ", ''"    '組織コード4
							strSQL &= ", ''"    '組織コード5
							strSQL &= ", ''"    'メールアドレス1
							strSQL &= ", ''"    'メールアドレス2
							strSQL &= ", ''"    '電話番号1
							strSQL &= ", ''"    '電話番号2
							strSQL &= ", ''"    '都道府県コード
							strSQL &= ", '')"    '勤務地都道府県コード
							sqlProcess.DB_UPDATE(strSQL)
						Else
							WriteLstResult(lstResult, "更新区分：更新")
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
								'異動情報がNULLの場合は利用者情報から取得する
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
							strSQL &= ", '" & dtOrg.Rows(0)("有効期間From") & "'"
							strSQL &= ", '" & dtOrg.Rows(0)("有効期間To") & "'"
							strSQL &= ", '" & dtOrg.Rows(0)("連絡優先フラグ") & "'"
							strSQL &= ", '" & dtOrg.Rows(0)("IVR有りフラグ") & "'"
							strSQL &= ", ''"    '組織コード2
							strSQL &= ", ''"    '組織コード3
							strSQL &= ", ''"    '組織コード4
							strSQL &= ", ''"    '組織コード5
							strSQL &= ", ''"    'メールアドレス1
							strSQL &= ", ''"    'メールアドレス2
							strSQL &= ", ''"    '電話番号1
							strSQL &= ", ''"    '電話番号2
							'都道府県コード、勤務地都道府県コードは「海外」が1だった場合、空欄、それ以外は利用者情報から取得する
							If dt.Rows(iRow)("海外") = 1 Then
								strSQL &= ", ''"    '都道府県コード
								strSQL &= ", ''"    '勤務地都道府県コード
							Else
								strSQL &= ", '" & dtOrg.Rows(0)("都道府県コード") & "'"
								strSQL &= ", '" & dtOrg.Rows(0)("勤務地都道府県コード") & "')"
							End If
							sqlProcess.DB_UPDATE(strSQL)
						End If

					Else
						'削除
						WriteLstResult(lstResult, "更新区分：削除")
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
							strSQL &= ", '" & dtOrg.Rows(0)("利用者名称") & "'"
							strSQL &= ", '" & dtOrg.Rows(0)("利用者名称カナ") & "'"
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
	Public Sub OutputCSV(ByVal strLotID As String, ByVal lstResult As ListBox, ByVal strOutputFolder As String)

		Dim strSQL As String = ""
		Dim sqlProcess As New SQLProcess

		Try
			WriteLstResult(lstResult, "CSVファイル作成開始：" & strLotID)
			strSQL = "SELECT ロットID, レコード番号, 更新区分, 社員番号, 利用者名称, 利用者名称カナ, 役職コード別名, 所属組織コード1, "
			strSQL &= "有効期間From, 有効期間To, 連絡優先フラグ, IVR有りフラグ, 所属組織コード2, 所属組織コード3, 所属組織コード4, 所属組織コード5, "
			strSQL &= "メールアドレス1, メールアドレス2, 電話番号1, 電話番号2, 都道府県コード, 勤務地都道府県コード "
			strSQL &= "FROM T_利用者情報出力 "
			strSQL &= "WHERE ロットID = '" & strLotID & "' "
			strSQL &= "ORDER BY レコード番号"
			Dim dtOut As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
			'CSVファイルの出力開始
			'出力フォルダ＋(異動情報)_事業所＋_ロットID.csv
			strSQL = "SELECT T2.事業所 FROM T_ロット管理 AS T1 INNER JOIN "
			strSQL &= "M_事業所 AS T2 ON T1.事業所ID = T2.事業所ID "
			strSQL &= "WHERE ロットID = '" & strLotID & "'"
			Dim strOffice As String = sqlProcess.DB_EXECUTE_SCALAR(strSQL)
			Dim strOutFile As String = strOutputFolder & "\" & "異動情報_" & strOffice & "_" & strLotID & ".csv"
			Using sw As New System.IO.StreamWriter(strOutFile, False, System.Text.Encoding.GetEncoding("Shift-JIS"))
				For iRow As Integer = 0 To dtOut.Rows.Count - 1
					Dim strWriteLine As String = ""
					strWriteLine = Chr(34) & dtOut.Rows(iRow)("更新区分") & Chr(34)
					strWriteLine &= "," & Chr(34) & dtOut.Rows(iRow)("社員番号") & Chr(34)
					strWriteLine &= "," & Chr(34) & dtOut.Rows(iRow)("利用者名称") & Chr(34)
					strWriteLine &= "," & Chr(34) & dtOut.Rows(iRow)("利用者名称カナ") & Chr(34)
					strWriteLine &= "," & Chr(34) & dtOut.Rows(iRow)("役職コード別名") & Chr(34)
					strWriteLine &= "," & Chr(34) & dtOut.Rows(iRow)("所属組織コード1") & Chr(34)
					strWriteLine &= "," & Chr(34) & dtOut.Rows(iRow)("有効期間From") & Chr(34)
					strWriteLine &= "," & Chr(34) & dtOut.Rows(iRow)("有効期間To") & Chr(34)
					strWriteLine &= "," & Chr(34) & dtOut.Rows(iRow)("連絡優先フラグ") & Chr(34)
					strWriteLine &= "," & Chr(34) & dtOut.Rows(iRow)("IVR有りフラグ") & Chr(34)
					strWriteLine &= "," & Chr(34) & dtOut.Rows(iRow)("所属組織コード2") & Chr(34)
					strWriteLine &= "," & Chr(34) & dtOut.Rows(iRow)("所属組織コード3") & Chr(34)
					strWriteLine &= "," & Chr(34) & dtOut.Rows(iRow)("所属組織コード4") & Chr(34)
					strWriteLine &= "," & Chr(34) & dtOut.Rows(iRow)("所属組織コード5") & Chr(34)
					strWriteLine &= "," & Chr(34) & dtOut.Rows(iRow)("メールアドレス1") & Chr(34)
					strWriteLine &= "," & Chr(34) & dtOut.Rows(iRow)("メールアドレス2") & Chr(34)
					strWriteLine &= "," & Chr(34) & dtOut.Rows(iRow)("電話番号1") & Chr(34)
					strWriteLine &= "," & Chr(34) & dtOut.Rows(iRow)("電話番号2") & Chr(34)
					strWriteLine &= "," & Chr(34) & dtOut.Rows(iRow)("都道府県コード") & Chr(34)
					strWriteLine &= "," & Chr(34) & dtOut.Rows(iRow)("勤務地都道府県コード") & Chr(34)
					sw.WriteLine(strWriteLine)
				Next
			End Using
			WriteLstResult(lstResult, "異動情報出力完了：" & strLotID)
			'海外、管理者権限、部門管理者権限に○がついているリストを出力
			strSQL = "SELECT ユーザーID, 利用者名称, 海外, 管理者権限, 部門管理者権限 "
			strSQL &= "FROM T_異動情報 "
			strSQL &= "WHERE ロットID = '" & strLotID & "' "
			strSQL &= "AND (海外 = 1 OR 管理者権限 = 1 OR 部門管理者権限 = 1) "
			strSQL &= "ORDER BY レコード番号"
			Dim dt As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
			If dt.Rows.Count > 0 Then
				strOutFile = strOutputFolder & "\" & "権限情報_" & strOffice & "_" & strLotID & ".csv"
				Using sw As New System.IO.StreamWriter(strOutFile, False, System.Text.Encoding.GetEncoding("Shift-JIS"))
					For iRow As Integer = 0 To dt.Rows.Count - 1
						Dim strWriteLine As String = ""
						strWriteLine = Chr(34) & dt.Rows(iRow)("ユーザーID") & Chr(34)
						strWriteLine &= "," & Chr(34) & dt.Rows(iRow)("利用者名称") & Chr(34)
						strWriteLine &= "," & Chr(34) & IIf(dt.Rows(iRow)("海外") = True, "○", "") & Chr(34)
						strWriteLine &= "," & Chr(34) & IIf(dt.Rows(iRow)("管理者権限") = True, "○", "") & Chr(34)
						strWriteLine &= "," & Chr(34) & IIf(dt.Rows(iRow)("部門管理者権限") = True, "○", "") & Chr(34)
						sw.WriteLine(strWriteLine)
					Next
				End Using
			End If
			WriteLstResult(lstResult, "権限情報出力完了：" & strLotID)

			WriteLstResult(lstResult, "CSVファイル作成完了：" & strLotID)
			'CSV出力日時を書き込む
			strSQL = "UPDATE T_ロット管理 SET "
			strSQL &= "CSV出力日時 = '" & Date.Now & "' "
			strSQL &= "WHERE ロットID = '" & strLotID & "'"
			sqlProcess.DB_UPDATE(strSQL)

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & ex.StackTrace)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		Finally

			sqlProcess.Close()

		End Try

	End Sub

End Module
