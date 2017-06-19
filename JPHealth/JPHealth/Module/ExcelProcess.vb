Imports C1.C1Excel

Module ExcelProcess

	Public Enum ExcelOutputCategory
		DataImcomplete = 1  '判定票データ不備内容
		MailingLabel = 2    '判定票宛名ラベル
		CorrectionRecord = 3    '判定票修正記録
		CheckList = 4   '判定票送付先チェックリスト
		CheckupTargetList = 5   '判定票対象者一覧
		PlantList = 6   '判定票発送先事業所一覧
	End Enum

	''' <summary>
	''' DATATABLEの内容を指定テンプレートに書き込んで指定エクセルファイルに出力する
	''' </summary>
	''' <param name="strTemplate"></param>
	''' <param name="strSaveFile"></param>
	''' <param name="dt"></param>
	''' <returns></returns>
	Private Function WriteExcelFile(ByVal strTemplate As String, ByVal strSaveFile As String, ByVal dt As DataTable) As Boolean

		Try

			Dim wb As New C1XLBook  'ワークブックのインスタンス
			wb.Load(strTemplate)    'テンプレートエクセルを読み込む
			Dim sheet As XLSheet = wb.Sheets(0) '先頭のシートを指定
			Dim i As Integer    'TryParse用変数

			For iRow As Integer = 0 To dt.Rows.Count - 1
				sheet(iRow + 1, 0).Value = dt.Rows(iRow)("レコード番号")
				sheet(iRow + 1, 1).Value = dt.Rows(iRow)("表示用")
				If Integer.TryParse(dt.Rows(iRow)("行番号"), i) Then
					sheet(iRow + 1, 2).Value = CInt(dt.Rows(iRow)("行番号"))
				Else
					sheet(iRow + 1, 2).Value = dt.Rows(iRow)("行番号")
				End If
				sheet(iRow + 1, 3).Value = dt.Rows(iRow)("県名")
				sheet(iRow + 1, 4).Value = dt.Rows(iRow)("資料名")
				sheet(iRow + 1, 5).Value = dt.Rows(iRow)("副題")
				sheet(iRow + 1, 6).Value = dt.Rows(iRow)("対象年")
				sheet(iRow + 1, 7).Value = dt.Rows(iRow)("刊行者名")
				sheet(iRow + 1, 8).Value = dt.Rows(iRow)("刊行年月")
				If Integer.TryParse(dt.Rows(iRow)("分類1"), i) Then
					sheet(iRow + 1, 9).Value = CInt(dt.Rows(iRow)("分類1"))
				Else
					sheet(iRow + 1, 9).Value = dt.Rows(iRow)("分類1")
				End If
				If Integer.TryParse(dt.Rows(iRow)("分類2"), i) Then
					sheet(iRow + 1, 10).Value = CInt(dt.Rows(iRow)("分類2"))
				Else
					sheet(iRow + 1, 10).Value = dt.Rows(iRow)("分類2")
				End If
				If Integer.TryParse(dt.Rows(iRow)("分類番号"), i) Then
					sheet(iRow + 1, 11).Value = CInt(dt.Rows(iRow)("分類番号"))
				Else
					sheet(iRow + 1, 11).Value = dt.Rows(iRow)("分類番号")
				End If
				sheet(iRow + 1, 12).Value = dt.Rows(iRow)("項目")
				If Integer.TryParse(dt.Rows(iRow)("番号1"), i) Then
					sheet(iRow + 1, 13).Value = CInt(dt.Rows(iRow)("番号1"))
				Else
					sheet(iRow + 1, 13).Value = dt.Rows(iRow)("番号1")
				End If
				sheet(iRow + 1, 14).Value = dt.Rows(iRow)("タイトル1")
				If Integer.TryParse(dt.Rows(iRow)("番号2"), i) Then
					sheet(iRow + 1, 15).Value = CInt(dt.Rows(iRow)("番号2"))
				Else
					sheet(iRow + 1, 15).Value = dt.Rows(iRow)("番号2")
				End If
				sheet(iRow + 1, 16).Value = dt.Rows(iRow)("タイトル2")
				If Integer.TryParse(dt.Rows(iRow)("番号3"), i) Then
					sheet(iRow + 1, 17).Value = CInt(dt.Rows(iRow)("番号3"))
				Else
					sheet(iRow + 1, 17).Value = dt.Rows(iRow)("番号3")
				End If
				sheet(iRow + 1, 18).Value = dt.Rows(iRow)("タイトル3")
				If Integer.TryParse(dt.Rows(iRow)("番号4"), i) Then
					sheet(iRow + 1, 19).Value = CInt(dt.Rows(iRow)("番号4"))
				Else
					sheet(iRow + 1, 19).Value = dt.Rows(iRow)("番号4")
				End If
				sheet(iRow + 1, 20).Value = dt.Rows(iRow)("タイトル4")
				If Integer.TryParse(dt.Rows(iRow)("番号5"), i) Then
					sheet(iRow + 1, 21).Value = CInt(dt.Rows(iRow)("番号5"))
				Else
					sheet(iRow + 1, 21).Value = dt.Rows(iRow)("番号5")
				End If
				sheet(iRow + 1, 22).Value = dt.Rows(iRow)("タイトル5")
				sheet(iRow + 1, 23).Value = dt.Rows(iRow)("フォルダ名")
				sheet(iRow + 1, 24).Value = dt.Rows(iRow)("リンク")
				sheet(iRow + 1, 25).Value = dt.Rows(iRow)("リンクTO")

			Next

			wb.Save(strSaveFile, FileFormat.OpenXml)
			Return True

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Return False

		End Try

	End Function

End Module
