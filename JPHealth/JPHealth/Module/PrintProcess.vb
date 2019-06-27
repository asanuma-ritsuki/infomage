Imports C1.Win.FlexReport
Imports System.Printing

Module PrintProcess

#Region "パブリック変数"

	''' <summary>
	''' 印刷種別
	''' </summary>
	Public Enum PrintCategory
		Label
		WeightHeader
		WeightHeaderHand
		CheckupList
		LeafletList
		Checkup
		Leaflet
		CheckupListIndividual
		LeafletListIndividual
	End Enum

#End Region

#Region "プライベート変数"

	Private isPrinting As Boolean = False
    Private pd As New System.Drawing.Printing.PrintDocument

#End Region

	''' <summary>
	''' 印刷準備
	''' 重量ヘッダ紐付け、ソート
	''' </summary>
	''' <param name="strLotID"></param>
	Public Sub PrintPreparation(ByVal strLotID As String, ByVal lstResult As ListBox, ByVal strOutputFolder As String)

		'ロットIDで抽出し、会社コード・所属事業所コードでグルーピングする
		Dim sqlProcess As New SQLProcess
		Dim strSQL As String = ""
		XmlSettings.LoadFromXmlFile()
		Dim iCheckupList As Integer = XmlSettings.Instance.CheckupList  '対象者一覧1ページあたりの件数
		Dim iLeafletList As Integer = XmlSettings.Instance.LeafletList  '保健指導対象者名簿1ページあたりの件数
		Dim dt As DataTable = Nothing

        Try
            WriteLstResult(lstResult, "テンポラリテーブルの削除開始")
            '==================================================
            'T_印刷管理、T_印刷ソート、T_判定票印刷、T_リーフレット印刷から対象ロットIDのレコードを削除する
            strSQL = "DELETE FROM T_印刷管理 "
            strSQL &= "WHERE ロットID = '" & strLotID & "'"
            sqlProcess.DB_UPDATE(strSQL)
            strSQL = "DELETE FROM T_印刷ソート "
            strSQL &= "WHERE ロットID = '" & strLotID & "'"
            sqlProcess.DB_UPDATE(strSQL)
            strSQL = "DELETE FROM T_判定票印刷 "
            strSQL &= "WHERE ロットID = '" & strLotID & "'"
            sqlProcess.DB_UPDATE(strSQL)
            strSQL = "DELETE FROM T_リーフレット印刷 "
            strSQL &= "WHERE ロットID = '" & strLotID & "'"
            sqlProcess.DB_UPDATE(strSQL)
            strSQL = "DELETE FROM T_対象者一覧印刷 "
            strSQL &= "WHERE ロットID = '" & strLotID & "'"
            sqlProcess.DB_UPDATE(strSQL)
            strSQL = "DELETE FROM T_保健指導名簿印刷 "
            strSQL &= "WHERE ロットID = '" & strLotID & "'"
            sqlProcess.DB_UPDATE(strSQL)
            strSQL &= "DELETE FROM T_複数封筒計算 "
            strSQL &= "WHERE ロットID = '" & strLotID & "'"
            sqlProcess.DB_UPDATE(strSQL)
            '==================================================
            WriteLstResult(lstResult, "テンポラリテーブルの削除完了")

			'==================================================
			'2018/01/16
			'判定票、リーフレット共に文字数チェックを行い、超過しているものに関しては
			'強制的にM_文字数テーブル内のバイト数に従って文字を削る
			WriteLstResult(lstResult, "判定票文字数チェック開始")
			'エラーチェック用にT_判定票の項目名を全て取得しておく
			strSQL = "SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS "
			strSQL &= "WHERE TABLE_NAME = 'T_判定票' "
			strSQL &= "ORDER BY ORDINAL_POSITION"
			dt = sqlProcess.DB_SELECT_DATATABLE(strSQL)
			Dim strColumnName As String() = Nothing
			For i As Integer = 0 To dt.Rows.Count - 1
				ReDim Preserve strColumnName(i)
				strColumnName(i) = dt.Rows(i)("COLUMN_NAME")
			Next

			strSQL = "SELECT システムID, 社員コード, 会社コード, 所属事業所コード, 会社, 所属事業所, 所属部名, 所属課名, 役職名, "
			strSQL &= "氏名セイ, 氏名メイ, 氏名姓, 氏名名, 性別, 採用年月日, 生年月日, 健診種別, 受診日, 身長, 体重コード, "
			strSQL &= "体重, 体重単位, 体重上限, 体重下限, BMIコード, BMI, BMI単位, BMI上限, BMI下限, 腹囲コード, 腹囲, "
			strSQL &= "腹囲単位, 腹囲上限, 腹囲下限, 視力裸眼右, 視力裸眼左, 視力矯正右, 視力矯正左, 聴力右1000, 聴力右4000, "
			strSQL &= "聴力左1000, 聴力左4000, 聴力その他, 血圧2回収縮期コード, 血圧2回収縮期, 血圧2回収縮期単位, 血圧2回収縮期上限, "
			strSQL &= "血圧2回収縮期下限, 血圧2回拡張期コード, 血圧2回拡張期, 血圧2回拡張期単位, 血圧2回拡張期上限, 血圧2回拡張期下限, "
			strSQL &= "血圧1回収縮期コード, 血圧1回収縮期, 血圧1回収縮期単位, 血圧1回収縮期上限, 血圧1回収縮期下限, 血圧1回拡張期コード, "
			strSQL &= "血圧1回拡張期, 血圧1回拡張期単位, 血圧1回拡張期上限, 血圧1回拡張期下限, 尿糖定性, 尿蛋白定性, "
			strSQL &= "総コレステロールコード, 総コレステロール, 総コレステロール単位, 総コレステロール上限, 総コレステロール下限, "
			strSQL &= "HDLコレステロールコード, HDLコレステロール, HDLコレステロール単位, HDLコレステロール上限, "
			strSQL &= "HDLコレステロール下限, 中性脂肪コード, 中性脂肪, 中性脂肪単位, 中性脂肪上限, 中性脂肪下限, "
			strSQL &= "LDLコレステロールコード, LDLコレステロール, LDLコレステロール単位, LDLコレステロール上限, "
			strSQL &= "LDLコレステロール下限, GOTコード, GOT, GOT単位, GOT上限, GOT下限, GPTコード, GPT, GPT単位, "
			strSQL &= "GPT上限, GPT下限, ガンマGTPコード, ガンマGTP, ガンマGTP単位, ガンマGTP上限, ガンマGTP下限, "
			strSQL &= "クレアチニンコード, クレアチニン, クレアチニン単位, クレアチニン上限, クレアチニン下限, "
			strSQL &= "尿酸コード, 尿酸, 尿酸単位, 尿酸上限, 尿酸下限, 赤血球コード, 赤血球, 赤血球単位, 赤血球上限, 赤血球下限, "
			strSQL &= "血色素量コード, 血色素量, 血色素量単位, 血色素量上限, 血色素量下限, 空腹時血糖コード, 空腹時血糖,"
			strSQL &= "空腹時血糖単位, 空腹時血糖上限, 空腹時血糖下限, 随時血糖コード, 随時血糖, 随時血糖単位, 随時血糖上限, "
			strSQL &= "随時血糖下限, HbA1cコード, HbA1c, HbA1c単位, HbA1c上限, HbA1c下限, 受診検査機関番号, 受診検査機関名称, "
			strSQL &= "会場局コード, 会場局名称, 総合判定コード, 総合判定, 健診実施医師名, 意見を述べた医師, "
			strSQL &= "判定医師名, 判定日付, 視力判定コード, 視力判定, 聴力判定コード, 聴力判定, 血圧判定コード, 血圧判定, "
			strSQL &= "尿糖判定コード, 尿糖判定, 尿蛋白判定コード, 尿蛋白判定, 血中脂質判定コード, 血中脂質判定, "
			strSQL &= "肝機能判定コード, 肝機能判定, 腎機能判定コード, 腎機能判定, 尿酸判定コード, 尿酸判定,"
			strSQL &= "血液判定コード, 血液判定, 血糖判定コード, 血糖判定, 胸部X線判定コード, 胸部X線判定結果, "
			strSQL &= "心電図判定コード, 心電図判定結果, 総合成績判定コード, 総合成績判定, 就業区分コード, 就業区分, "
			strSQL &= "服薬血圧コード, 服薬血圧, 服薬血糖コード, 服薬血糖, 服薬脂質コード, 服薬脂質, 健診データ登録日, "
			strSQL &= "胸部X線所見, 胸部X線判定, 心電図所見, 心電図判定, 既往歴, 自覚症状, "
			strSQL &= "診察所見, 総合コメント, 産業医の意見, レコード番号 "   '項目IDを崩さないようにするためレコード番号を末尾にセット
			strSQL &= "FROM T_判定票 "
			strSQL &= "WHERE ロットID = '" & strLotID & "' "
			strSQL &= "ORDER BY ロットID, レコード番号"
			Dim dtExceed As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)

			'M_文字数テーブルをDATATABLEに保持しておく
			strSQL = "SELECT 項目ID, バイト数 FROM M_文字数 "
			strSQL &= "WHERE 項目種別 = 1 " '項目種別：1＝判定票
			strSQL &= "ORDER BY 項目ID"
			Dim dtStringLen As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)

			'T_判定票のレコードで回す
			For iRow As Integer = 0 To dtExceed.Rows.Count - 1
				'カラムで回す
				For iCol As Integer = 0 To dtExceed.Columns.Count - 1
					'NULLの場合はスルー
					If IsNull(dtExceed.Rows(iRow)(iCol)) Then
						Continue For
					End If
					Dim blnError As Boolean = False
					'T_判定票データのカラムで回して該当する要素(項目ID)が存在した場合に文字数チェックを行う
					'バイト数が0の場合はスルーする
					Dim iLength As Integer = 0
					Dim strFilter As String = "項目ID = " & iCol
					Dim foundRows As DataRow() = dtStringLen.Select(strFilter)
					For i As Integer = 0 To foundRows.Length - 1
						'複数ヒットすることはないが念のためi=0のときのみ処理する
						If i = 0 Then
							iLength = foundRows(i)(1)
							If iLength > 0 Then
								'取得した文字数が0より大きい
								If VBStrings.LenB(dtExceed.Rows(iRow)(iCol)) > iLength Then
									'指定バイトより文字列数が大きい場合はエラー
									blnError = True
								End If
							Else
								Exit For
							End If
						Else
							'1レコード目以外はすべてループを抜ける
							Exit For
						End If
					Next

					If blnError Then
						'エラーが発生した場合
						WriteLstResult(lstResult, "指定文字数を超過したため文字を切り捨てます", ResultMark.WarningMark)
						WriteLstResult(lstResult, "会社コード：" & dtExceed.Rows(iRow)(2) & "：所属事業所コード：" & dtExceed.Rows(iRow)(3) & "：社員コード：" & dtExceed.Rows(iRow)(1) & "：項目名：" & strColumnName(iCol + 2), ResultMark.WarningMark)
						Dim strResult As String = VBStrings.TruncString(dtExceed.Rows(iRow)(iCol), iLength)
						WriteLstResult(lstResult, "切り捨て前：" & dtExceed.Rows(iRow)(iCol), ResultMark.WarningMark)
						WriteLstResult(lstResult, "切り捨て後：" & strResult, ResultMark.WarningMark)
						'実際のT_判定票のデータを切り捨て後の文字列で更新する
						strSQL = "UPDATE T_判定票 SET " & strColumnName(iCol + 2) & " = '" & strResult & "' "
						strSQL &= "WHERE ロットID = '" & strLotID & "' "
						strSQL &= "AND レコード番号 = " & dtExceed.Rows(iRow)("レコード番号")
						sqlProcess.DB_UPDATE(strSQL)
					End If
				Next
			Next
			WriteLstResult(lstResult, "判定票文字数チェック完了")

			WriteLstResult(lstResult, "リーフレット文字数チェック開始")
			'エラーチェック用にT_リーフレットの項目名を全て取得しておく
			strSQL = "SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS "
			strSQL &= "WHERE TABLE_NAME = 'T_リーフレット' "
			strSQL &= "ORDER BY ORDINAL_POSITION"
			dt = sqlProcess.DB_SELECT_DATATABLE(strSQL)
			strColumnName = Nothing
			For i As Integer = 0 To dt.Rows.Count - 1
				ReDim Preserve strColumnName(i)
				strColumnName(i) = dt.Rows(i)("COLUMN_NAME")
			Next
			'2018/07/30
			'BMI項目の追加
			strSQL = "SELECT システムID, 社員コード, 会社コード, 所属事業所コード, 会社, 所属事業所, "
			strSQL &= "所属部名, 所属課名, 役職名, 氏名セイ, 氏名メイ, 氏名姓, 氏名名, 性別, 採用年月日, 生年月日, 健診種別, 受診日, "
			strSQL &= "血圧1回収縮期コード, 血圧1回収縮期, 血圧1回収縮期単位, 血圧1回収縮期上限, 血圧1回収縮期下限, "
			strSQL &= "血圧1回拡張期コード, 血圧1回拡張期, 血圧1回拡張期単位, 血圧1回拡張期上限, 血圧1回拡張期下限, "
			strSQL &= "HDLコレステロールコード, HDLコレステロール, HDLコレステロール単位, HDLコレステロール上限, "
			strSQL &= "HDLコレステロール下限, 中性脂肪コード, 中性脂肪, 中性脂肪単位, 中性脂肪上限, 中性脂肪下限, "
			strSQL &= "LDLコレステロールコード, LDLコレステロール, LDLコレステロール単位, LDLコレステロール上限, "
			strSQL &= "LDLコレステロール下限, GOTコード, GOT, GOT単位, GOT上限, GOT下限, GPTコード, GPT, GPT単位, GPT上限, "
			strSQL &= "GPT下限, ガンマGTPコード, ガンマGTP, ガンマGTP単位, ガンマGTP上限, ガンマGTP下限, クレアチニンコード, "
			strSQL &= "クレアチニン, クレアチニン単位, クレアチニン上限, クレアチニン下限, 尿酸コード, 尿酸, 尿酸単位, 尿酸上限, "
			strSQL &= "尿酸下限, 赤血球コード, 赤血球, 赤血球単位, 赤血球上限, 赤血球下限, 血色素量コード, 血色素量, 血色素量単位, "
			strSQL &= "血色素量上限, 血色素量下限, 空腹時血糖コード, 空腹時血糖, 空腹時血糖単位, 空腹時血糖上限, 空腹時血糖下限, "
			strSQL &= "随時血糖コード, 随時血糖, 随時血糖単位, 随時血糖上限, 随時血糖下限, HbA1cコード, HbA1c, HbA1c単位, "
			strSQL &= "HbA1c上限, HbA1c下限, 胸部X線判定コード, 胸部X線判定結果, 心電図判定コード, 心電図判定結果, 服薬血圧コード,"
			strSQL &= "服薬血圧, 服薬血糖コード, 服薬血糖, 服薬脂質コード, 服薬脂質, 健診データ登録日, 胸部X線所見, 胸部X線判定, "
			strSQL &= "心電図所見, 心電図判定, 帳票タイプ, BMI, レコード番号 "
			strSQL &= "FROM T_リーフレット "
			strSQL &= "WHERE ロットID = '" & strLotID & "' "
			strSQL &= "ORDER BY ロットID, レコード番号"
			dtExceed = sqlProcess.DB_SELECT_DATATABLE(strSQL)

			'M_文字数テーブルをDATATABLEに保持しておく
			strSQL = "SELECT 項目ID, バイト数 FROM M_文字数 "
			strSQL &= "WHERE 項目種別 = 2 " '項目種別：2＝リーフレット
			strSQL &= "ORDER BY 項目ID"
			dtStringLen = sqlProcess.DB_SELECT_DATATABLE(strSQL)

			'T_リーフレットのレコードで回す
			For iRow As Integer = 0 To dtExceed.Rows.Count - 1
				'カラムで回す
				For iCol As Integer = 0 To dtExceed.Columns.Count - 1
					'NULLの場合はスルー
					If IsNull(dtExceed.Rows(iRow)(iCol)) Then
						Continue For
					End If
					Dim blnError As Boolean = False
					'T_リーフレットのカラムで回して該当する要素(項目ID)が存在した場合に文字数チェックを行う
					'バイト数が0の場合はスルーする
					Dim iLength As Integer = 0
					Dim strFilter As String = "項目ID = " & iCol
					Dim foundRows As DataRow() = dtStringLen.Select(strFilter)
					For i As Integer = 0 To foundRows.Length - 1
						'複数ヒットすることはないが念のためi=0のときのみ処理する
						If i = 0 Then
							iLength = foundRows(i)(1)
							If iLength > 0 Then
								'取得した文字数が0より大きい
								If VBStrings.LenB(dtExceed.Rows(iRow)(iCol)) > iLength Then
									'指定バイトより文字数が大きい場合はエラー
									blnError = True
								End If
							Else
								Exit For
							End If
						Else
							'1レコード目以外は全てループを抜ける
							Exit For
						End If
					Next

					If blnError Then
						'エラーが発生した場合
						WriteLstResult(lstResult, "指定文字数を超過したため文字を切り捨てます", ResultMark.WarningMark)
						WriteLstResult(lstResult, "会社コード：" & dtExceed.Rows(iRow)(2) & "：所属事業所コード：" & dtExceed.Rows(iRow)(3) & "：社員コード：" & dtExceed.Rows(iRow)(1) & "：項目名：" & strColumnName(iCol + 2), ResultMark.WarningMark)
						Dim strResult As String = VBStrings.TruncString(dtExceed.Rows(iRow)(iCol), iLength)
						WriteLstResult(lstResult, "切り捨て前：" & dtExceed.Rows(iRow)(iCol), ResultMark.WarningMark)
						WriteLstResult(lstResult, "切り捨て後：" & strResult, ResultMark.WarningMark)
						'実際のT_リーフレットのデータを切り捨て後の文字列で更新する
						strSQL = "UPDATE T_リーフレット SET " & strColumnName(iCol + 2) & " = '" & strResult & "' "
						strSQL &= "WHERE ロットID = '" & strLotID & "' "
						strSQL &= "AND レコード番号 = " & dtExceed.Rows(iRow)("レコード番号")
						sqlProcess.DB_UPDATE(strSQL)
					End If
				Next
			Next
			WriteLstResult(lstResult, "リーフレット文字数チェック完了")
            '==================================================

            strSQL = "SELECT ロットID, 会社コード, 所属事業所コード FROM T_判定票管理 "
            strSQL &= "WHERE ロットID = '" & strLotID & "' "
            strSQL &= "GROUP BY ロットID, 会社コード, 所属事業所コード "
            strSQL &= "ORDER BY 会社コード, 所属事業所コード"
            ''2019/04/23
            ''[T_医師].[有効フラグ]が1またはNULLの場合のみ
            'strSQL = "SELECT T1.ロットID, T1.会社コード, T1.所属事業所コード, T2.有効フラグ "
            'strSQL &= "FROM T_判定票管理 AS T1 LEFT OUTER JOIN "
            'strSQL &= "T_医師 AS T2 ON T1.ロットID = T2.ロットID AND T1.レコード番号 = T2.レコード番号 "
            'strSQL &= "WHERE T1.ロットID = '" & strLotID & "' "
            'strSQL &= "AND (T2.有効フラグ = 1 OR T2.有効フラグ IS NULL) "
            'strSQL &= "GROUP BY T1.ロットID, T1.会社コード, T1.所属事業所コード, T2.有効フラグ "
            'strSQL &= "ORDER BY T1.会社コード, T1.所属事業所コード"
            Dim dtOffice As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
			Dim dblTemp As Decimal = 0
			Dim iLeafletSeq As Integer = 0 'リーフレットシーケンス(0～63)で各リーフレットを回す

            WriteLstResult(lstResult, "対象事業所数：" & dtOffice.Rows.Count & "件")
            WriteLstResult(lstResult, "重量ヘッダ付与処理開始")

            For iRow As Integer = 0 To dtOffice.Rows.Count - 1

                WriteLstResult(lstResult, "会社コード：" & dtOffice.Rows(iRow)("会社コード") & "：所属事業所コード：" & dtOffice.Rows(iRow)("所属事業所コード"))

                Application.DoEvents()
				'事業所単位で回す
				'はじめに事業所単位の判定票のレコード数、重量を算出する
				Dim dblCheckupWeight As Decimal = 0
				Dim iCheckupCount As Integer = 0
                Dim iLeafletCount As Integer = 0

                strSQL = "SELECT SUM(重量) AS 総重量, COUNT(社員コード) AS 判定票件数 "
                strSQL &= "FROM T_判定票管理 "
                strSQL &= "WHERE ロットID = '" & strLotID & "' "
                strSQL &= "AND 会社コード = '" & dtOffice.Rows(iRow)("会社コード") & "' "
                strSQL &= "AND 所属事業所コード = '" & dtOffice.Rows(iRow)("所属事業所コード") & "'"
                dt = sqlProcess.DB_SELECT_DATATABLE(strSQL)
                dblCheckupWeight = dt.Rows(0)("総重量")    '判定票＋リーフレット総重量
                iCheckupCount = dt.Rows(0)("判定票件数") '判定票件数

                'リーフレットの件数算出時は「リーフレット無効」が立っている社員コードは除外する
                strSQL = "SELECT COUNT(T2.社員コード) AS リーフレット件数 "
                strSQL &= "FROM T_判定票管理 AS T1 LEFT OUTER JOIN "
                strSQL &= "T_リーフレット AS T2 ON T1.ロットID = T2.ロットID "
                strSQL &= "AND T1.会社コード = T2.会社コード "
                strSQL &= "AND T1.所属事業所コード = T2.所属事業所コード "
                strSQL &= "AND T1.社員コード = T2.社員コード "
                strSQL &= "WHERE T1.ロットID = '" & strLotID & "' "
                strSQL &= "AND T1.会社コード = '" & dtOffice.Rows(iRow)("会社コード") & "' "
                strSQL &= "AND T1.所属事業所コード = '" & dtOffice.Rows(iRow)("所属事業所コード") & "' "
                strSQL &= "AND T1.リーフレット無効 = 0"
                iLeafletCount = sqlProcess.DB_EXECUTE_SCALAR(strSQL)

                '全ての重量を足してみる
                'ラベルの重量を取得
                strSQL = "SELECT 重量 FROM M_重量 "
                strSQL &= "WHERE 帳票種別ID = 0 "
                strSQL &= "AND 帳票種別詳細 = 1"
				Dim dblLabelWeight As Decimal = sqlProcess.DB_EXECUTE_SCALAR(strSQL) 'ラベルの重量
				'対象者一覧のページ数を取得して総重量を取得
				dblTemp = iCheckupCount / iCheckupList
                Dim iCheckupSheet As Integer = Math.Ceiling(dblTemp)   '切り上げ(判定票件数 / 1ページあたりの件数)
                strSQL = "SELECT 重量 FROM M_重量 "
                strSQL &= "WHERE 帳票種別ID = 2 "
                strSQL &= "AND 帳票種別詳細 = 1"
				Dim dblCheckupListWeight As Decimal = sqlProcess.DB_EXECUTE_SCALAR(strSQL)   '対象者一覧1ページあたりの重量
				Dim dblCheckupListTotalWeight As Decimal = dblCheckupListWeight * iCheckupSheet  '対象者一覧の総重量
				'保健指導対象者名簿のページ数を取得して総重量を取得
				dblTemp = iLeafletCount / iLeafletList
                Dim iLeafletSheet As Integer = Math.Ceiling(dblTemp)   '切り上げ(保健指導対象者名簿件数 / 1ページあたりの件数)
                strSQL = "SELECT 重量 FROM M_重量 "
                strSQL &= "WHERE 帳票種別ID = 3 "
                strSQL &= "AND 帳票種別詳細 = 1"
				Dim dblLeafletListWeight As Decimal = sqlProcess.DB_EXECUTE_SCALAR(strSQL)   '保健指導対象者名簿1ページあたりの重量
				Dim dblLeafletListTotalWeight As Decimal = dblLeafletListWeight * iLeafletSheet  '保健指導対象者名簿の総重量
				'ラベル＋対象者一覧＋保健指導対象者名簿＋(判定票＋リーフレット)の総重量を取得
				Dim dblOfficeTotalWeight As Decimal = dblLabelWeight + dblCheckupListTotalWeight + dblLeafletListTotalWeight + dblCheckupWeight

				'重量ヘッダに該当するか調べる
				strSQL = "SELECT 重量ヘッダ, 封筒種別 FROM M_重量ヘッダ "
                strSQL &= "WHERE " & dblOfficeTotalWeight & " BETWEEN 重量FROM AND 重量TO"
                Dim dtWeightHeader As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)

                'XmlSettings.LoadFromXmlFile()
                'Dim strQRCodeWithoutCD As String = ""   'チェックデジットを求めたい数値
                'Dim strCD As String = ""    'チェックデジット
                Dim blnResult As Boolean = False    'チェックデジット算出時の成功可否
                Dim strQRCode As String = ""    'チェックデジット込みの数値

                '==================================================
                '↓ここから
                '2017/07/10
                '※テスト
                '複数封筒に別れる処理
                WriteLstResult(lstResult, "該当事業所 総重量：" & dblOfficeTotalWeight)
                'WriteLstResult(lstResult, "重量が最大封筒の上限を超えたため複数封筒となります")

                'T_複数封筒計算テーブル
                '毎回T_複数封筒計算テーブル内の該当ロットIDを削除する
                strSQL = "DELETE FROM T_複数封筒計算 "
                'strSQL &= "WHERE ロットID = '" & strLotID & "'"
                sqlProcess.DB_UPDATE(strSQL)

                strSQL = "SELECT ロットID, レコード番号, リーフレット無効, 重量 FROM T_判定票管理 "
                strSQL &= "WHERE ロットID = '" & strLotID & "' "
                strSQL &= "AND 会社コード = '" & dtOffice.Rows(iRow)("会社コード") & "' "
                strSQL &= "AND 所属事業所コード = '" & dtOffice.Rows(iRow)("所属事業所コード") & "' "
                strSQL &= "ORDER BY CASE WHEN ISNULL(所属部名, '') = '' THEN 1 ELSE 0 END, "
                strSQL &= "所属部名, "
                strSQL &= "CASE WHEN ISNULL(所属課名, '') = '' THEN 1 ELSE 0 END, "
                strSQL &= "所属課名, "
                strSQL &= "社員コード"
                Dim dtMultiEnvelope As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
                Dim iPrintID As Integer = 0 '印刷ID
				Dim dblTotalWeight As Decimal = 0    '累積重量用
				Dim iSeq As Integer = 0 'シーケンス
                Dim iNowCheckupCount As Integer = 1 '対象者一覧の現在のレコード数。対象者一覧の限度レコード数に達したらレコード追加する
                Dim iNowLeafletCount As Integer = 1 '対象者名簿の現在のレコード数。対象者名簿の限度レコード数に達したらレコードを追加する

                For iMulti As Integer = 0 To dtMultiEnvelope.Rows.Count - 1
                    If iMulti = 0 Then
                        iPrintID += 1
                        iSeq += 1
                        '初回ループは必ずラベルレコードを追加
                        MultiEnvelopeInsert(strLotID, 0, iSeq, iPrintID, 0, dblLabelWeight, 0, 0, 0, dblLabelWeight)
                        dblTotalWeight += dblLabelWeight
                        '1件目の判定票
                        '対象者一覧レコードを追加
                        iSeq += 1
                        MultiEnvelopeInsert(strLotID, 0, iSeq, iPrintID, 2, 0, dblCheckupListWeight, 0, 0, dblTotalWeight + dblCheckupListWeight)
                        dblTotalWeight += dblCheckupListWeight
                        'リーフレットが無効かどうか調べて無効でなかった場合対象者名簿レコードを追加する
                        If dtMultiEnvelope.Rows(iMulti)("リーフレット無効") = 0 Then
                            'リーフレットがあった
                            iSeq += 1
                            MultiEnvelopeInsert(strLotID, 0, iSeq, iPrintID, 3, 0, 0, dblLeafletListWeight, 0, dblTotalWeight + dblLeafletListWeight)
                            dblTotalWeight += dblLeafletListWeight
                            iNowLeafletCount += 1
                            '==================================================
                            '2017/07/10
                            'リーフレットレコードのINSERT
                            '※重量は判定票部分に含まれるため加算しない
                            iSeq += 1
                            MultiEnvelopeInsert(strLotID, dtMultiEnvelope.Rows(iMulti)("レコード番号"), iSeq, iPrintID, 5, 0, 0, 0, 0, dblTotalWeight)
                            '==================================================
                        End If
                        '判定票のレコードを追加
                        iSeq += 1
                        MultiEnvelopeInsert(strLotID, dtMultiEnvelope.Rows(iMulti)("レコード番号"), iSeq, iPrintID, 4, 0, 0, 0, dtMultiEnvelope.Rows(iMulti)("重量"), dblTotalWeight + dtMultiEnvelope.Rows(iMulti)("重量"))
                        dblTotalWeight += dtMultiEnvelope.Rows(iMulti)("重量")
                        iNowCheckupCount += 1

                    Else
						'2レコード目以降
						'重量チェック
						'当該レコードの重量を足したdblTotalWeightが重量ヘッダ「H」の重量TOを超えていたら
						'印刷IDをインクリメントしてラベルレコードから再開する
						'iNowCheckupCount、iNowLeafletCountのリセット
						'dblTotalWeightのリセット
						'If dtOffice.Rows(iRow)("所属事業所コード") = "017970" Then
						'	MessageBox.Show(dtOffice.Rows(iRow)("所属事業所コード"))
						'End If
						'最大重量の取得
						strSQL = "SELECT 重量TO FROM M_重量ヘッダ "
                        strSQL &= "WHERE 重量ヘッダ = 'H'"
						Dim dblMaxWeight As Decimal = sqlProcess.DB_EXECUTE_SCALAR(strSQL)

						If dblTotalWeight + dtMultiEnvelope.Rows(iMulti)("重量") + dblCheckupListWeight + dblLeafletListWeight > dblMaxWeight Then
							'最大重量を超えていた
							iPrintID += 1
							iNowCheckupCount = 1
							iNowLeafletCount = 1
							dblTotalWeight = 0
							'ラベルのレコード追加
							iSeq += 1
							MultiEnvelopeInsert(strLotID, 0, iSeq, iPrintID, 0, dblLabelWeight, 0, 0, 0, dblLabelWeight)
							dblTotalWeight += dblLabelWeight
							'対象者一覧レコードを追加
							iSeq += 1
							MultiEnvelopeInsert(strLotID, 0, iSeq, iPrintID, 2, 0, dblCheckupListWeight, 0, 0, dblTotalWeight + dblCheckupListWeight)
							dblTotalWeight += dblCheckupListWeight
							'リーフレットが無効かどうか調べて無効でなかった場合対象者名簿レコードを追加する
							If dtMultiEnvelope.Rows(iMulti)("リーフレット無効") = 0 Then
								'リーフレットがあった
								iSeq += 1
								MultiEnvelopeInsert(strLotID, 0, iSeq, iPrintID, 3, 0, 0, dblLeafletListWeight, 0, dblTotalWeight + dblLeafletListWeight)
								dblTotalWeight += dblLeafletListWeight
								iNowLeafletCount += 1
								'==================================================
								'2017/07/14
								'リーフレットレコードのINSERT
								'※重量は判定票部分に含まれるため加算しない
								iSeq += 1
								MultiEnvelopeInsert(strLotID, dtMultiEnvelope.Rows(iMulti)("レコード番号"), iSeq, iPrintID, 5, 0, 0, 0, 0, dblTotalWeight)
								'==================================================
							End If
							'判定票のレコードを追加
							iSeq += 1
							MultiEnvelopeInsert(strLotID, dtMultiEnvelope.Rows(iMulti)("レコード番号"), iSeq, iPrintID, 4, 0, 0, 0, dtMultiEnvelope.Rows(iMulti)("重量"), dblTotalWeight + dtMultiEnvelope.Rows(iMulti)("重量"))
							dblTotalWeight += dtMultiEnvelope.Rows(iMulti)("重量")
							iNowCheckupCount += 1

						Else
							'超えていなかった
							'対象者一覧チェック
							If iNowCheckupCount = iCheckupList + 1 Then
                                '限度数を超えていたら対象者一覧をレコード追加し、iNowCheckCountをリセットする
                                iSeq += 1
                                MultiEnvelopeInsert(strLotID, 0, iSeq, iPrintID, 2, 0, dblCheckupListWeight, 0, 0, dblTotalWeight + dblCheckupListWeight)
                                dblTotalWeight += dblCheckupListWeight
                                iNowCheckupCount = 1
                            End If
                            '保健指導名簿チェック
                            If dtMultiEnvelope.Rows(iMulti)("リーフレット無効") = 0 Then
                                'リーフレットがあった
                                '限度数を超えていたら保健指導名簿をレコード追加し、iNowLeafletCountをリセットする
                                If iNowLeafletCount = iLeafletList + 1 Then
                                    iSeq += 1
                                    MultiEnvelopeInsert(strLotID, 0, iSeq, iPrintID, 3, 0, 0, dblLeafletListWeight, 0, dblTotalWeight + dblLeafletListWeight)
                                    dblTotalWeight += dblLeafletListWeight
                                    iNowLeafletCount = 1
                                Else
                                    '限度数を超えていなかったらインクリメント
                                    iNowLeafletCount += 1
                                End If
                                '==================================================
                                '2017/07/10
                                'リーフレットレコードのINSERT
                                '※重量は判定票部分に含まれるため加算しない
                                iSeq += 1
                                MultiEnvelopeInsert(strLotID, dtMultiEnvelope.Rows(iMulti)("レコード番号"), iSeq, iPrintID, 5, 0, 0, 0, 0, dblTotalWeight)
                                '==================================================
                            End If
                            '判定票のレコードを追加
                            iSeq += 1
                            MultiEnvelopeInsert(strLotID, dtMultiEnvelope.Rows(iMulti)("レコード番号"), iSeq, iPrintID, 4, 0, 0, 0, dtMultiEnvelope.Rows(iMulti)("重量"), dblTotalWeight + dtMultiEnvelope.Rows(iMulti)("重量"))
                            dblTotalWeight += dtMultiEnvelope.Rows(iMulti)("重量")
                            iNowCheckupCount += 1

                        End If

                    End If

                Next iMulti

				'T_複数封筒計算を起点にして各テーブルより以下のテーブルを成型する
				'T_印刷管理
				'T_印刷ソート
				'T_対象者一覧印刷
				'T_保健指導名簿印刷
				'T_判定票印刷
				'T_リーフレット印刷

				'==================================================
				'T_印刷管理
				'2017/06/30
				'ラベル連番(0固定)、判定票枚数、リーフレット枚数項目の追加
				'==================================================
				'印刷IDでグルーピングして各最終レコードの累積重量を参照し、M_重量ヘッダから該当の重量ヘッダを取得する
				'※T_複数封筒計算テーブルは事業所単位での計算を前提としたテーブル
				strSQL = "SELECT 印刷ID, "
				strSQL &= "SUM(CASE WHEN 帳票種別ID = 4 THEN 1 ELSE 0 END) AS 判定票枚数, "
                strSQL &= "SUM(CASE WHEN 帳票種別ID = 5 THEN 1 ELSE 0 END) AS リーフレット枚数 "
                strSQL &= "FROM T_複数封筒計算 "
                strSQL &= "WHERE ロットID = '" & strLotID & "' "
                strSQL &= "GROUP BY 印刷ID "
                strSQL &= "ORDER BY 印刷ID"
                Dim dtPrintID As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
                WriteLstResult(lstResult, "封筒分割数：" & dtPrintID.Rows.Count)
                '全体を印刷IDで回す
                For i As Integer = 0 To dtPrintID.Rows.Count - 1
                    '該当印刷IDの累積重量を取得しておく
                    strSQL = "SELECT MAX(累積重量) FROM T_複数封筒計算 "
                    strSQL &= "WHERE 印刷ID = " & dtPrintID.Rows(i)("印刷ID")
					Dim dblPrintIDWeight As Decimal = sqlProcess.DB_EXECUTE_SCALAR(strSQL)
					'累積重量から重量ヘッダを取得する
					strSQL = "SELECT 重量ヘッダ FROM M_重量ヘッダ "
                    strSQL &= "WHERE " & dblPrintIDWeight & " BETWEEN 重量FROM AND 重量TO"
                    '必ず重量ヘッダは引っかかる
                    Dim strWeightHeader As String = sqlProcess.DB_EXECUTE_SCALAR(strSQL)
                    WriteLstResult(lstResult, i + 1 & "封筒目重量ヘッダ：" & strWeightHeader)
                    strSQL = "INSERT INTO T_印刷管理 (ロットID, 会社コード, 所属事業所コード, 印刷ID, 重量ヘッダ, ラベル連番, 判定票枚数, リーフレット枚数) VALUES("
                    strSQL &= "'" & strLotID & "'"  'ロットID
                    strSQL &= ", '" & dtOffice.Rows(iRow)("会社コード") & "'"
                    strSQL &= ", '" & dtOffice.Rows(iRow)("所属事業所コード") & "'"
                    strSQL &= ", " & dtPrintID.Rows(i)("印刷ID")
                    strSQL &= ", '" & strWeightHeader & "'" '重量ヘッダ
                    strSQL &= ", 0" 'ラベル連番(ひとまず固定で0)
                    strSQL &= ", " & dtPrintID.Rows(i)("判定票枚数") '判定票枚数
                    strSQL &= ", " & dtPrintID.Rows(i)("リーフレット枚数")  'リーフレット枚数
                    strSQL &= ")"
                    sqlProcess.DB_UPDATE(strSQL)

                    '==================================================
                    'ラベル
                    'T_印刷ソートにINSERT
                    '==================================================
                    strSQL = "INSERT INTO T_印刷ソート (ロットID, 会社コード, 所属事業所コード, 印刷ID, ページ数, レコード番号, システムID, "
                    strSQL &= "帳票種別ID, 帳票種別詳細, 分数, QR, 枚数, シーケンス, チェックフラグ, チェック日時, 作業者) VALUES("
                    strSQL &= "'" & strLotID & "'"  'ロットID
                    strSQL &= ", '" & dtOffice.Rows(iRow)("会社コード") & "'"    '会社コード
                    strSQL &= ", '" & dtOffice.Rows(iRow)("所属事業所コード") & "'" '所属事業所コード
                    strSQL &= ", " & dtPrintID.Rows(i)("印刷ID")  '印刷ID
                    strSQL &= ", 0" 'ページ数(0固定)
                    strSQL &= ", 0" 'レコード番号(0固定)
                    strSQL &= ", ''"    'システムID(NULL固定)
                    strSQL &= ", 0" '帳票種別ID(0＝ラベル)
                    strSQL &= ", 1" '帳票種別詳細
                    strSQL &= ", '" & dtPrintID.Rows(i)("印刷ID") & " / " & dtPrintID.Rows.Count & "'"    '分数(印刷ID/印刷ID件数)
                    'QRコードの算出(会社コード(4)＋封筒番号(2)＋封筒総数(2)＋帳票種別ID(1)＋所属事業所コード(4～6))
                    '封筒番号(印刷ID)、封筒総数(印刷ID件数)
                    '               'QRコードの算出(会社コード(4)＋所属事業所コード(6)＋封筒番号(2)＋封筒総数(2)＋帳票種別ID(1))
                    '               '封筒番号、封筒総数は「01」固定
                    '               strQRCodeWithoutCD = dtOffice.Rows(iRow)("会社コード") & dtOffice.Rows(iRow)("所属事業所コード") & "0" & "0101"
                    strQRCode = dtOffice.Rows(iRow)("会社コード") & "0" & CInt(dtPrintID.Rows(i)("印刷ID")).ToString("00") & dtPrintID.Rows.Count.ToString("00") & dtOffice.Rows(iRow)("所属事業所コード")
                    '2017/07/13
                    'チェックデジット付与を取りやめ
                    'strCD = ""
                    'blnResult = Modulus10(strQRCodeWithoutCD, 0, strCD)
                    'strQRCode = strQRCodeWithoutCD & strCD

                    strSQL &= ", '" & strQRCode & "'"   'QRコード
                    strSQL &= ", 0, 0, 0" '枚数、シーケンス、チェックフラグは0固定
                    strSQL &= ", NULL, '')" 'チェック日時、作業者
                    sqlProcess.DB_UPDATE(strSQL)

                    '==================================================
                    '対象者一覧
                    '該当システムIDを「T_対象者一覧印刷」にもINSERT
                    '指定レコード数を超えた場合は分数に「1/2」「2/2」等を記述する
                    '==================================================
                    strSQL = "SELECT T1.ロットID, T1.レコード番号, T1.システムID, T2.会社, T2.所属事業所, T1.所属部名, T1.所属課名, T2.氏名姓 + ' ' + T2.氏名名 AS 氏名, "
                    strSQL &= "T2.受診日, T3.変換健診種別 AS 健診種別, T2.就業区分, T4.印刷ID, T1.判定票CSV, T1.リーフレットCSV, "
                    strSQL &= "ISNULL(T1.要修正日時, '1900/01/01') AS 要修正日時, ISNULL(T1.修正済日時, '1900/01/01') AS 修正済日時 "
                    strSQL &= "FROM T_判定票管理 AS T1 INNER JOIN "
                    strSQL &= "T_判定票 AS T2 ON T1.ロットID = T2.ロットID AND T1.レコード番号 = T2.レコード番号 INNER JOIN "
                    strSQL &= "M_健診種別 AS T3 ON T1.健診種別 = T3.健診種別 INNER JOIN "
                    strSQL &= "T_複数封筒計算 AS T4 ON T1.ロットID = T4.ロットID AND T1.レコード番号 = T4.レコード番号 "
                    strSQL &= "WHERE T1.ロットID = '" & strLotID & "' "
                    strSQL &= "AND T1.会社コード = '" & dtOffice.Rows(iRow)("会社コード") & "' "
                    strSQL &= "AND T1.所属事業所コード = '" & dtOffice.Rows(iRow)("所属事業所コード") & "' "
                    strSQL &= "AND T4.印刷ID = " & dtPrintID.Rows(i)("印刷ID") & " "
                    strSQL &= "AND T4.帳票種別ID = 4 "  '判定票を対象にする
                    strSQL &= "ORDER BY CASE WHEN ISNULL(T1.所属部名, '') = '' THEN 1 ELSE 0 END, "
                    strSQL &= "T1.所属部名, "
                    strSQL &= "CASE WHEN ISNULL(T1.所属課名, '') = '' THEN 1 ELSE 0 END, "
                    strSQL &= "T1.所属課名, T1.社員コード"
                    Dim dtCheckupList As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
                    dblTemp = dtCheckupList.Rows.Count / iCheckupList
                    Dim iCheckupListPage As Integer = Math.Ceiling(dblTemp) '切り上げてページ数を算出
                    'ページで回してそれぞれのレコードをINSERT
                    For iPage As Integer = 1 To iCheckupListPage
                        '==================================================
                        'T_印刷ソートへのINSERT
                        strSQL = "INSERT INTO T_印刷ソート (ロットID, 会社コード, 所属事業所コード, 印刷ID, ページ数, レコード番号, システムID, "
                        strSQL &= "帳票種別ID, 帳票種別詳細, 分数, QR, 枚数, シーケンス, チェックフラグ, チェック日時, 作業者) VALUES("
                        strSQL &= "'" & strLotID & "'"  'ロットID
                        strSQL &= ", '" & dtOffice.Rows(iRow)("会社コード") & "'"    '会社コード
                        strSQL &= ", '" & dtOffice.Rows(iRow)("所属事業所コード") & "'" '所属事業所コード
                        strSQL &= ", " & dtPrintID.Rows(i)("印刷ID")  '印刷ID
                        strSQL &= ", " & iPage  'ページ数
                        strSQL &= ", 0" 'レコード番号(0固定)
                        strSQL &= ", ''"    'システムID(NULL固定)
                        strSQL &= ", 2" '帳票種別ID(2＝対象者一覧)
                        strSQL &= ", 1" '帳票種別詳細
                        strSQL &= ", '" & iPage.ToString & " / " & iCheckupListPage.ToString & "'"    '分数(1ページの場合はNULL)
                        'QRコードの算出(会社コード(4)＋帳票種別ID(1)＋ページ数(4)＋所属事業所コード(4～6))
                        strQRCode = dtOffice.Rows(iRow)("会社コード") & "2" & iPage.ToString("0000") & dtOffice.Rows(iRow)("所属事業所コード")
                        '2017/07/13
                        'チェックデジット付与を取りやめ
                        'strCD = ""
                        'blnResult = Modulus10(strQRCodeWithoutCD, 2, strCD)
                        'strQRCode = strQRCodeWithoutCD & strCD

                        strSQL &= ", '" & strQRCode & "'"   'QRコード
                        strSQL &= ", 0, 0, 0" '枚数、シーケンス、チェックフラグは0固定
                        strSQL &= ", NULL, '')" 'チェック日時、作業者
                        sqlProcess.DB_UPDATE(strSQL)

                        '==================================================
                        'T_対象者一覧へのINSERT
                        '開始ページ
                        '(ページ区切り数×現在ページ)ーページ区切り数
                        '1ページのときは(50×1)ー50＝0：開始要素
                        '2ページのときは(50×2)ー50＝50：開始要素
                        Dim iStartRec As Integer = (iCheckupList * iPage) - iCheckupList
                        '終了ページ
                        '(ページ区切り数×現在ページ)ー1
                        '1ページのときは(50×1)ー1＝49：終了要素
                        '2ページのときは(50×2)ー1＝99：終了要素
                        Dim iEndRec As Integer = (iCheckupList * iPage) - 1
                        '算出した最終レコードが実レコードより多かったら実レコードを代入する
                        If iEndRec > dtCheckupList.Rows.Count - 1 Then
                            iEndRec = dtCheckupList.Rows.Count - 1
                        End If
                        '開始要素と終了要素間で回す
                        For iRec As Integer = iStartRec To iEndRec

                            strSQL = "INSERT INTO T_対象者一覧印刷 (ロットID, 会社コード, 所属事業所コード, 印刷ID, ページ数, レコード番号, "
                            strSQL &= "会社, 所属事業所, 所属部名, 所属課名, 氏名, 受診日, 健診種別, 意見書発行, 判定票要押印) VALUES("
                            strSQL &= "'" & strLotID & "'"  'ロットID
                            strSQL &= ", '" & dtOffice.Rows(iRow)("会社コード") & "'"    '会社コード
                            strSQL &= ", '" & dtOffice.Rows(iRow)("所属事業所コード") & "'" '所属事業所コード
                            strSQL &= ", " & dtPrintID.Rows(i)("印刷ID") '印刷ID
                            strSQL &= ", " & iPage  'ページ数
                            strSQL &= ", " & dtCheckupList.Rows(iRec)("レコード番号") 'レコード番号
                            strSQL &= ", '" & dtCheckupList.Rows(iRec)("会社") & "'"  '会社
                            strSQL &= ", '" & dtCheckupList.Rows(iRec)("所属事業所") & "'"   '所属事業所
                            strSQL &= ", '" & dtCheckupList.Rows(iRec)("所属部名") & "'"    '所属部名
                            strSQL &= ", '" & dtCheckupList.Rows(iRec)("所属課名") & "'"    '所属課名
                            strSQL &= ", '" & dtCheckupList.Rows(iRec)("氏名") & "'"  '氏名
                            strSQL &= ", '" & dtCheckupList.Rows(iRec)("受診日") & "'" '受診日
                            strSQL &= ", '" & dtCheckupList.Rows(iRec)("健診種別") & "'"    '健診種別
                            '意見書発行、判定要要押印に「○」を印字するか否かを判断する
                            Dim strMark As String = ""
                            If dtCheckupList.Rows(iRec)("就業区分") = "就業制限" Or dtCheckupList.Rows(iRec)("就業区分") = "要休業" Or dtCheckupList.Rows(iRec)("就業区分") = "就業困難" Then
                                strMark = "○"
                            End If
                            strSQL &= ", '" & strMark & "'" '意見書発行
                            strSQL &= ", '" & strMark & "')"    '判定要要押印
                            sqlProcess.DB_UPDATE(strSQL)

                        Next iRec

                    Next iPage
                    '==================================================
                    '保健指導対象者名簿
                    '該当システムIDを「T_保健指導名簿印刷」にINSERT
                    '指定レコード数を超えた場合は分数に「1/2」「2/2」等を記述する
                    '==================================================
                    '※リーフレットは1社員で複数枚ある場合があるので、保健指導のレコード数はリーフレットの件数となる
                    'ため、別にグルーピングしてカウントする
                    strSQL = "SELECT T1.ロットID, T1.会社コード, T1.所属事業所コード, T1.レコード番号, T1.会社, "
                    strSQL &= "T1.所属事業所, T1.所属部名, T1.所属課名, T1.社員コード, T1.氏名姓 + ' ' + T1.氏名名 AS 氏名, "
                    strSQL &= "COUNT(T1.レコード番号) AS カウント, T3.印刷ID "
                    strSQL &= "FROM T_リーフレット AS T1 INNER JOIN "
                    strSQL &= "T_判定票管理 AS T2 ON T1.ロットID = T2.ロットID "
                    strSQL &= "AND T1.レコード番号 = T2.レコード番号 INNER JOIN "
                    strSQL &= "T_複数封筒計算 AS T3 ON T2.ロットID = T3.ロットID "
                    strSQL &= "AND T2.レコード番号 = T3.レコード番号 "
                    strSQL &= "WHERE T1.ロットID = '" & strLotID & "' "
                    strSQL &= "AND T1.会社コード = '" & dtOffice.Rows(iRow)("会社コード") & "' "
                    strSQL &= "AND T1.所属事業所コード = '" & dtOffice.Rows(iRow)("所属事業所コード") & "' "
                    strSQL &= "AND T2.リーフレット無効 != 1 "
                    strSQL &= "AND T3.印刷ID = " & dtPrintID.Rows(i)("印刷ID") & " "
                    strSQL &= "AND T3.帳票種別ID = 5 "  'リーフレットを対象にする
                    strSQL &= "GROUP BY T1.ロットID, T1.会社コード, T1.所属事業所コード, T1.レコード番号, T1.会社, "
                    strSQL &= "T1.所属事業所, T1.所属部名, T1.所属課名, T1.社員コード, T1.氏名姓, T1.氏名名, T3.印刷ID "
                    strSQL &= "ORDER BY CASE WHEN ISNULL(T1.所属部名, '') = '' THEN 1 ELSE 0 END, "
                    strSQL &= "T1.所属部名, "
                    strSQL &= "CASE WHEN ISNULL(T1.所属課名, '') = '' THEN 1 ELSE 0 END, "
                    strSQL &= "T1.所属課名, T1.社員コード"
                    '社員一人あたり1レコードのDATATABLE
                    Dim dtLeafletRec As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)

                    Dim iLeafletRec As Integer = dtLeafletRec.Rows.Count
                    dblTemp = iLeafletRec / iLeafletList
                    Dim iLeafletListPage As Integer = Math.Ceiling(dblTemp)   '切り上げてページ数を算出

                    'dblTemp = dtLeafletList.Rows.Count / iLeafletList
                    'ページで回してそれぞれのレコードをINSERT
                    For iPage As Integer = 1 To iLeafletListPage
                        '==================================================
                        'T_印刷ソートへのINSERT
                        strSQL = "INSERT INTO T_印刷ソート (ロットID, 会社コード, 所属事業所コード, 印刷ID, ページ数, レコード番号, システムID, "
                        strSQL &= "帳票種別ID, 帳票種別詳細, 分数, QR, 枚数, シーケンス, チェックフラグ, チェック日時, 作業者) VALUES("
                        strSQL &= "'" & strLotID & "'"  'ロットID
                        strSQL &= ", '" & dtOffice.Rows(iRow)("会社コード") & "'"    '会社コード
                        strSQL &= ", '" & dtOffice.Rows(iRow)("所属事業所コード") & "'" '所属事業所コード
                        strSQL &= ", " & dtPrintID.Rows(i)("印刷ID") '印刷ID
                        strSQL &= ", " & iPage  'ページ数
                        strSQL &= ", 0" 'レコード番号(0固定)
                        strSQL &= ", ''"    'システムID(NULL固定)
                        strSQL &= ", 3" '帳票種別ID(3＝保健指導対象者名簿)
                        strSQL &= ", 1" '帳票種別詳細
                        strSQL &= ", '" & iPage.ToString & " / " & iLeafletListPage.ToString & "'"    '分数(1ページの場合はNULL)
                        'QRコードの算出(会社コード(4)＋帳票種別ID(1)＋ページ数(4)＋所属事業所コード(4～6))
                        strQRCode = dtOffice.Rows(iRow)("会社コード") & "3" & iPage.ToString("0000") & dtOffice.Rows(iRow)("所属事業所コード")
                        '2017/07/13
                        'チェックデジット付与を取りやめ
                        'strCD = ""
                        'blnResult = Modulus10(strQRCodeWithoutCD, 3, strCD)
                        'strQRCode = strQRCodeWithoutCD & strCD

                        strSQL &= ", '" & strQRCode & "'"   'QRコード
                        strSQL &= ", 0, 0, 0" '枚数、シーケンス、チェックフラグは0固定
                        strSQL &= ", NULL, '')" 'チェック日時、作業者
                        sqlProcess.DB_UPDATE(strSQL)

                        '==================================================
                        'T_保健指導名簿印刷へのINSERT
                        '一人あたり1レコードのDATATABLEを使用する
                        '開始ページ
                        Dim iStartRec As Integer = (iLeafletList * iPage) - iLeafletList
                        '終了ページ
                        Dim iEndRec As Integer = (iLeafletList * iPage) - 1
                        '算出した最終レコードが実レコードより多かったら実レコードを代入する
                        If iEndRec > dtLeafletRec.Rows.Count - 1 Then
                            iEndRec = dtLeafletRec.Rows.Count - 1
                        End If
                        '開始要素と終了要素で回す
                        '一度テンポラリに入れて複数帳票タイプがある(レコード番号が同一)システムIDもそのままINSERT
                        'T_保健指導名簿TEMPへのINSERT
                        strSQL = "DELETE FROM T_保健指導名簿TEMP" 'T_保健指導名簿の削除
                        sqlProcess.DB_UPDATE(strSQL)

                        Dim iRecNumber As Integer = 0
                        'Dim iSeq As Integer = 0
                        iSeq = 0
                        For iRec As Integer = iStartRec To iEndRec  '一人あたり1レコードのインデックス
                            'レコード番号単位でレコードを抽出して順次INSERTする
                            '帳票タイプもキーに入っているDATATABLE(一人あたり複数レコードあり)
                            strSQL = "SELECT T1.ロットID, T1.レコード番号, T1.会社, T1.所属事業所, T1.所属部名, T1.所属課名, "
                            strSQL &= "T1.社員コード, T1.氏名姓 + ' ' + T1.氏名名 AS 氏名, T3.変換帳票タイプ AS 帳票タイプ "
                            strSQL &= "FROM T_判定票 AS T1 INNER JOIN "
                            strSQL &= "T_リーフレット AS T2 ON T1.ロットID = T2.ロットID AND T1.レコード番号 = T2.レコード番号 INNER JOIN "
                            strSQL &= "M_帳票タイプ AS T3 ON T2.帳票タイプ = T3.帳票タイプ INNER JOIN "
                            strSQL &= "T_判定票管理 AS T4 ON T1.ロットID = T4.ロットID AND T1.レコード番号 = T4.レコード番号 "
                            strSQL &= "WHERE T1.ロットID = '" & strLotID & "' "
                            strSQL &= "AND T1.会社コード = '" & dtOffice.Rows(iRow)("会社コード") & "' "
                            strSQL &= "AND T1.所属事業所コード = '" & dtOffice.Rows(iRow)("所属事業所コード") & "' "
                            strSQL &= "AND T1.レコード番号 = " & dtLeafletRec.Rows(iRec)("レコード番号") & " "
							strSQL &= "AND T4.リーフレット無効 != 1 "   'リーフレット無効が立っていたら出力しない
							'2018/07/31
							'帳票タイプが「BMIMAP」の際は除外する
							strSQL &= "AND T2.帳票タイプ != 'BMIMAP' "
							strSQL &= "ORDER BY CASE WHEN ISNULL(T1.所属部名, '') = '' THEN 1 ELSE 0 END, "
                            strSQL &= "T1.所属部名, "
                            strSQL &= "CASE WHEN ISNULL(T1.所属課名, '') = '' THEN 1 ELSE 0 END, "
                            strSQL &= "T1.所属課名, T1.社員コード"
                            Dim dtLeafletList As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)

                            For j As Integer = 0 To dtLeafletList.Rows.Count - 1

                                strSQL = "INSERT INTO T_保健指導名簿TEMP (ロットID, 会社コード, 所属事業所コード, 印刷ID, ページ数, レコード番号, "
                                strSQL &= "シーケンス, 会社, 所属事業所, 所属部名, 所属課名, 社員コード, 氏名, 帳票タイプ) VALUES("
                                strSQL &= "'" & strLotID & "'"  'ロットID
                                strSQL &= ", '" & dtOffice.Rows(iRow)("会社コード") & "'"    '会社コード
                                strSQL &= ", '" & dtOffice.Rows(iRow)("所属事業所コード") & "'" '所属事業所コード
                                strSQL &= ", " & dtPrintID.Rows(i)("印刷ID") '印刷ID(1固定)
                                strSQL &= ", " & iPage  'ページ数
                                strSQL &= ", " & dtLeafletList.Rows(j)("レコード番号") 'レコード番号
                                If iRecNumber = dtLeafletList.Rows(j)("レコード番号") Then
                                    iSeq += 1
                                Else
                                    iSeq = 1
                                End If
                                strSQL &= ", " & iSeq   'シーケンス
                                '現在のレコード番号を記憶
                                iRecNumber = dtLeafletList.Rows(j)("レコード番号")

                                strSQL &= ", '" & dtLeafletList.Rows(j)("会社") & "'"    '会社
                                strSQL &= ", '" & dtLeafletList.Rows(j)("所属事業所") & "'"   '所属事業所
                                strSQL &= ", '" & dtLeafletList.Rows(j)("所属部名") & "'"    '所属部名
                                strSQL &= ", '" & dtLeafletList.Rows(j)("所属課名") & "'"    '所属課名
                                strSQL &= ", '" & dtLeafletList.Rows(j)("社員コード") & "'"    '社員コード
                                strSQL &= ", '" & dtLeafletList.Rows(j)("氏名") & "'"    '氏名
                                strSQL &= ", '" & dtLeafletList.Rows(j)("帳票タイプ") & "')"    '帳票タイプ
                                sqlProcess.DB_UPDATE(strSQL)

                            Next

                        Next iRec

                        'T_保健指導名簿へのINSERT
                        strSQL = "INSERT INTO T_保健指導名簿印刷 "
                        strSQL &= "SELECT ロットID, 会社コード, 所属事業所コード, 印刷ID, ページ数, レコード番号, "
                        strSQL &= "会社, 所属事業所, 所属部名, 所属課名, 社員コード, 氏名, "
                        strSQL &= "(SELECT A1.帳票タイプ + '　' FROM T_保健指導名簿TEMP AS A1 "
                        strSQL &= "WHERE A1.レコード番号 = T1.レコード番号 "
                        strSQL &= "ORDER BY A1.レコード番号 "
                        strSQL &= "FOR XML PATH(''), TYPE).value('.', 'VARCHAR(MAX)') AS 帳票タイプ, "
                        strSQL &= "'' AS QRコード "
                        strSQL &= "FROM T_保健指導名簿TEMP AS T1 "
                        strSQL &= "GROUP BY ロットID, 会社コード, 所属事業所コード, 印刷ID, ページ数, レコード番号, "
                        strSQL &= "会社, 所属事業所, 所属部名, 所属課名, 社員コード, 氏名"
                        sqlProcess.DB_UPDATE(strSQL)

                    Next iPage

                    'strSQL = "SELECT T1.ロットID, T1.レコード番号, T1.会社, T1.所属事業所, T1.所属部名, T1.所属課名, "
                    'strSQL &= "T1.社員コード, T1.氏名姓 + ' ' + T1.氏名名 AS 氏名, T3.変換帳票タイプ AS 帳票タイプ "
                    'strSQL &= "FROM T_判定票 AS T1 INNER JOIN "
                    'strSQL &= "T_リーフレット AS T2 ON T1.ロットID = T2.ロットID AND T1.レコード番号 = T2.レコード番号 INNER JOIN "
                    'strSQL &= "M_帳票タイプ AS T3 ON T2.帳票タイプ = T3.帳票タイプ INNER JOIN "
                    'strSQL &= "T_判定票管理 AS T4 ON T1.ロットID = T4.ロットID AND T1.レコード番号 = T4.レコード番号 INNER JOIN  "
                    'strSQL &= "T_複数封筒計算 AS T5 ON T1.ロットID = T5.ロットID AND T1.レコード番号 = T5.ロットID "
                    'strSQL &= "WHERE T1.ロットID = '" & strLotID & "' "
                    'strSQL &= "AND T1.会社コード = '" & dtOffice.Rows(iRow)("会社コード") & "' "
                    'strSQL &= "AND T1.所属事業所コード = '" & dtOffice.Rows(iRow)("所属事業所コード") & "' "
                    'strSQL &= "AND T4.リーフレット無効 != 1 "   'リーフレット無効が立っていたら出力しない
                    'strSQL &= "AND T5.印刷ID = " & dtPrintID.Rows(i)("印刷ID") & " "
                    'strSQL &= "AND T5.帳票種別ID = 5 "  'リーフレットを対象にする
                    'strSQL &= "ORDER BY CASE WHEN ISNULL(T1.所属部名, '') = '' THEN 1 ELSE 0 END, "
                    'strSQL &= "T1.所属部名, "
                    'strSQL &= "CASE WHEN ISNULL(T1.所属課名, '') = '' THEN 1 ELSE 0 END, "
                    'strSQL &= "T1.所属課名, T1.社員コード"
                    'Dim dtLeafletList As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
                    'dblTemp = dtLeafletList.Rows.Count / iLeafletList
                    'Dim iLeafletListPage As Integer = Math.Ceiling(dblTemp)   '切り上げてページ数を算出
                    ''ページで回してそれぞれのレコードをINSERT
                    'For iPage As Integer = 1 To iLeafletListPage
                    '	'==================================================
                    '	'T_印刷ソートへのINSERT
                    '	strSQL = "INSERT INTO T_印刷ソート (ロットID, 会社コード, 所属事業所コード, 印刷ID, ページ数, レコード番号, システムID, "
                    '	strSQL &= "帳票種別ID, 帳票種別詳細, 分数, QR, 枚数, シーケンス, チェックフラグ) VALUES("
                    '	strSQL &= "'" & strLotID & "'"  'ロットID
                    '	strSQL &= ", '" & dtOffice.Rows(iRow)("会社コード") & "'"    '会社コード
                    '	strSQL &= ", '" & dtOffice.Rows(iRow)("所属事業所コード") & "'" '所属事業所コード
                    '	strSQL &= ", " & dtPrintID.Rows(i)("印刷ID") '印刷ID
                    '	strSQL &= ", " & iPage  'ページ数
                    '	strSQL &= ", 0" 'レコード番号(0固定)
                    '	strSQL &= ", ''"    'システムID(NULL固定)
                    '	strSQL &= ", 3" '帳票種別ID(3＝保健指導対象者名簿)
                    '	strSQL &= ", 1" '帳票種別詳細
                    '	strSQL &= ", '" & iPage.ToString & "/" & iLeafletListPage.ToString & "'"    '分数(1ページの場合はNULL)
                    '	'QRコードの算出(会社コード(4)＋所属事業所コード(6)＋帳票種別ID(1)＋ページ数(4))
                    '	strQRCodeWithoutCD = dtOffice.Rows(iRow)("会社コード") & dtOffice.Rows(iRow)("所属事業所コード") & "3" & iPage.ToString("0000")
                    '	strCD = ""
                    '	blnResult = Modulus10(strQRCodeWithoutCD, 3, strCD)
                    '	strQRCode = strQRCodeWithoutCD & strCD

                    '	strSQL &= ", '" & strQRCode & "'"   'QRコード
                    '	strSQL &= ", 0, 0, 0)" '枚数、シーケンス、チェックフラグは0固定
                    '	sqlProcess.DB_UPDATE(strSQL)

                    '	'==================================================
                    '	'T_保健指導名簿印刷へのINSERT
                    '	'開始ページ
                    '	Dim iStartRec As Integer = (XmlSettings.Instance.LeafletList * iPage) - XmlSettings.Instance.LeafletList
                    '	'終了ページ
                    '	Dim iEndRec As Integer = (XmlSettings.Instance.LeafletList * iPage) - 1
                    '	'算出した最終レコードが実レコードより多かったら実レコードを代入する
                    '	If iEndRec > dtLeafletList.Rows.Count - 1 Then
                    '		iEndRec = dtLeafletList.Rows.Count - 1
                    '	End If
                    '	'開始要素と終了要素で回す
                    '	'一度テンポラリに入れて複数帳票タイプがある(レコード番号が同一)システムIDもそのままINSERT
                    '	'T_保健指導名簿TEMPへのINSERT
                    '	strSQL = "DELETE FROM T_保健指導名簿TEMP" 'T_保健指導名簿の削除
                    '	sqlProcess.DB_UPDATE(strSQL)

                    '	Dim iRecNumber As Integer = 0
                    '	iSeq = 0
                    '	For iRec As Integer = iStartRec To iEndRec
                    '		strSQL = "INSERT INTO T_保健指導名簿TEMP (ロットID, 会社コード, 所属事業所コード, 印刷ID, ページ数, レコード番号, "
                    '		strSQL &= "シーケンス, 会社, 所属事業所, 所属部名, 所属課名, 社員コード, 氏名, 帳票タイプ) VALUES("
                    '		strSQL &= "'" & strLotID & "'"  'ロットID
                    '		strSQL &= ", '" & dtOffice.Rows(iRow)("会社コード") & "'"    '会社コード
                    '		strSQL &= ", '" & dtOffice.Rows(iRow)("所属事業所コード") & "'" '所属事業所コード
                    '		strSQL &= ", " & dtPrintID.Rows(i)("印刷ID") '印刷ID
                    '		strSQL &= ", " & iPage  'ページ数
                    '		strSQL &= ", " & dtLeafletList.Rows(iRec)("レコード番号") 'レコード番号
                    '		If iRecNumber = dtLeafletList.Rows(iRec)("レコード番号") Then
                    '			iSeq += 1
                    '		Else
                    '			iSeq = 1
                    '		End If
                    '		strSQL &= ", " & iSeq   'シーケンス
                    '		'現在のレコード番号を記憶
                    '		iRecNumber = dtLeafletList.Rows(iRec)("レコード番号")

                    '		strSQL &= ", '" & dtLeafletList.Rows(iRec)("会社") & "'"    '会社
                    '		strSQL &= ", '" & dtLeafletList.Rows(iRec)("所属事業所") & "'"   '所属事業所
                    '		strSQL &= ", '" & dtLeafletList.Rows(iRec)("所属部名") & "'"    '所属部名
                    '		strSQL &= ", '" & dtLeafletList.Rows(iRec)("所属課名") & "'"    '所属課名
                    '		strSQL &= ", '" & dtLeafletList.Rows(iRec)("社員コード") & "'"    '社員コード
                    '		strSQL &= ", '" & dtLeafletList.Rows(iRec)("氏名") & "'"    '氏名
                    '		strSQL &= ", '" & dtLeafletList.Rows(iRec)("帳票タイプ") & "')"    '帳票タイプ
                    '		sqlProcess.DB_UPDATE(strSQL)
                    '	Next iRec

                    '	'T_保健指導名簿へのINSERT
                    '	strSQL = "INSERT INTO T_保健指導名簿印刷 "
                    '	strSQL &= "SELECT ロットID, 会社コード, 所属事業所コード, 印刷ID, ページ数, レコード番号, "
                    '	strSQL &= "会社, 所属事業所, 所属部名, 所属課名, 社員コード, 氏名, "
                    '	strSQL &= "(SELECT A1.帳票タイプ + '　' FROM T_保健指導名簿TEMP AS A1 "
                    '	strSQL &= "WHERE A1.レコード番号 = T1.レコード番号 "
                    '	strSQL &= "ORDER BY A1.レコード番号 "
                    '	strSQL &= "FOR XML PATH(''), TYPE).value('.', 'VARCHAR(MAX)') AS 帳票タイプ, "
                    '	strSQL &= "'' AS QRコード "
                    '	strSQL &= "FROM T_保健指導名簿TEMP AS T1 "
                    '	strSQL &= "GROUP BY ロットID, 会社コード, 所属事業所コード, 印刷ID, ページ数, レコード番号, "
                    '	strSQL &= "会社, 所属事業所, 所属部名, 所属課名, 社員コード, 氏名"
                    '	sqlProcess.DB_UPDATE(strSQL)

                    'Next iPage

                    '==================================================
                    '判定票
                    'ここではT_印刷ソートにのみINSERT
                    '==================================================
                    'T_対象者一覧のデータ作成時に使用したDATATABLEを再利用
                    For j As Integer = 0 To dtCheckupList.Rows.Count - 1

                        '==================================================
                        '要修正日時に日付が入っていて、修正済日時に日付が入っていないものはエラーフラグ＝1としてQRコードにセットする
                        'それ以外はエラーフラグ＝0
                        Dim iErrorFlag As Integer = 0
                        If dtCheckupList.Rows(j)("要修正日時") <> "1900/01/01" And dtCheckupList.Rows(j)("修正済日時") = "1900/01/01" Then
                            '要修正日時に日付が入っていて、修正済日時に日付が入っていない場合は、エラーが解消されていない
                            '更に「T_判定票_不備内容」のCSVファイル項目にリーフレットのCSVファイル名があるか調べて1件でも存在すればエラーフラグを立てる
                            strSQL = "SELECT COUNT(*) FROM T_判定票_不備内容 "
                            strSQL &= "WHERE ロットID = '" & strLotID & "' "
                            strSQL &= "AND レコード番号 = " & dtCheckupList.Rows(j)("レコード番号") & " "
                            strSQL &= "AND CSVファイル = '" & dtCheckupList.Rows(j)("判定票CSV") & "'"
                            If sqlProcess.DB_EXECUTE_SCALAR(strSQL) > 0 Then
                                '不備内容にレコードがあった
                                iErrorFlag = 1
                            Else
                                iErrorFlag = 0
                            End If

                        Else
                            iErrorFlag = 0
                        End If
                        '==================================================
                        strSQL = "INSERT INTO T_印刷ソート (ロットID, 会社コード, 所属事業所コード, 印刷ID, ページ数, レコード番号, システムID, "
                        strSQL &= "帳票種別ID, 帳票種別詳細, 分数, QR, 枚数, シーケンス, チェックフラグ, チェック日時, 作業者) VALUES("
                        strSQL &= "'" & strLotID & "'"  'ロットID
                        strSQL &= ", '" & dtOffice.Rows(iRow)("会社コード") & "'"    '会社コード
                        strSQL &= ", '" & dtOffice.Rows(iRow)("所属事業所コード") & "'" '所属事業所コード
                        strSQL &= ", " & dtPrintID.Rows(i)("印刷ID") '印刷ID
                        strSQL &= ", " & j + 1 'ページ数(事業所内の連番)
                        strSQL &= ", " & dtCheckupList.Rows(j)("レコード番号")    'レコード番号
                        strSQL &= ", '" & dtCheckupList.Rows(j)("システムID") & "'"    'システムID
                        strSQL &= ", 4" '帳票種別ID(4＝判定票)
                        strSQL &= ", 1" '帳票種別詳細
                        strSQL &= ", ''"    '分数(NULL)
                        'QRコードの算出(システムID(15)＋帳票種別ID(1)＋エラーフラグ(1))
                        strQRCode = dtCheckupList.Rows(j)("システムID") & "4" & iErrorFlag.ToString
                        '2017/07/13
                        'チェックデジット付与を取りやめ
                        'strCD = ""
                        'blnResult = Modulus10(strQRCodeWithoutCD, 4, strCD)
                        'strQRCode = strQRCodeWithoutCD & strCD
                        strSQL &= ", '" & strQRCode & "'"
                        strSQL &= ", 0, 0, 0" '枚数、シーケンス、チェックフラグは0固定
                        strSQL &= ", NULL, '')" 'チェック日時、作業者
                        sqlProcess.DB_UPDATE(strSQL)

                    Next j
                    '==================================================
                    'リーフレット
                    'ここではT_印刷ソートにのみINSERT
                    '==================================================
                    'システムID単位のレコードを取得し、システムID内でのページ数も取得する
                    strSQL = "SELECT T1.ロットID, T1.レコード番号, T3.判定票CSV, T3.リーフレットCSV, "
                    strSQL &= "ISNULL(要修正日時, '1900/01/01') AS 要修正日時, ISNULL(修正済日時, '1900/01/01') AS 修正済日時 "
                    strSQL &= "FROM T_判定票 AS T1 INNER JOIN "
                    strSQL &= "T_リーフレット AS T2 ON T1.ロットID = T2.ロットID AND T1.レコード番号 = T2.レコード番号 INNER JOIN "
                    strSQL &= "T_判定票管理 AS T3 ON T1.ロットID = T3.ロットID AND T1.レコード番号 = T3.レコード番号 INNER JOIN  "
                    strSQL &= "T_複数封筒計算 AS T4 ON T1.ロットID = T4.ロットID AND T1.レコード番号 = T4.レコード番号 "
                    strSQL &= "WHERE T1.ロットID = '" & strLotID & "' "
                    strSQL &= "AND T1.会社コード = '" & dtOffice.Rows(iRow)("会社コード") & "' "
                    strSQL &= "AND T1.所属事業所コード = '" & dtOffice.Rows(iRow)("所属事業所コード") & "' "
                    strSQL &= "AND T3.リーフレット無効 != 1 "   'リーフレット無効が立っていたら出力しない
                    strSQL &= "AND T4.印刷ID = " & dtPrintID.Rows(i)("印刷ID") & " "
                    strSQL &= "ORDER BY CASE WHEN ISNULL(T1.所属部名, '') = '' THEN 1 ELSE 0 END, "
                    strSQL &= "T1.所属部名, "
                    strSQL &= "CASE WHEN ISNULL(T1.所属課名, '') = '' THEN 1 ELSE 0 END, "
                    strSQL &= "T1.所属課名, T1.社員コード"
                    Dim dtLeaf As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)

                    Dim iLeafPage As Integer = 1

                    For k As Integer = 0 To dtLeaf.Rows.Count - 1
                        'システムID単位で回す
                        strSQL = "SELECT ロットID, 会社コード, 所属事業所コード, レコード番号, システムID "
                        strSQL &= "FROM T_リーフレット "
                        strSQL &= "WHERE ロットID = '" & strLotID & "' "
                        strSQL &= "AND レコード番号 = " & dtLeaf.Rows(k)("レコード番号")
                        Dim dtLeafSystemID As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
                        For j As Integer = 0 To dtLeafSystemID.Rows.Count - 1
                            '==================================================
                            '2017/07/01
                            '※同一システムIDで複数のリーフレットが存在した場合はT_印刷ソートテーブルには上位1レコードしかINSERTさせない
                            '==================================================
                            '要修正日時に日付が入っていて、修正済日時に日付が入っていないものはエラーフラグ＝1としてQRコードにセットする
                            'それ以外はエラーフラグ＝0
                            Dim iErrorFlag As Integer = 0
                            If dtLeaf.Rows(k)("要修正日時") <> "1900/01/01" And dtLeaf.Rows(k)("修正済日時") = "1900/01/01" Then
                                '要修正日時に日付が入っていて、修正済日時に日付が入っていない場合は、エラーが解消されていない
                                '更に「T_判定票_不備内容」のCSVファイル項目にリーフレットのCSVファイル名があるか調べて1件でも存在すればエラーフラグを立てる
                                strSQL = "SELECT COUNT(*) FROM T_判定票_不備内容 "
                                strSQL &= "WHERE ロットID = '" & strLotID & "' "
                                strSQL &= "AND レコード番号 = " & dtLeaf.Rows(k)("レコード番号") & " "
                                strSQL &= "AND CSVファイル = '" & dtLeaf.Rows(k)("リーフレットCSV") & "'"
                                If sqlProcess.DB_EXECUTE_SCALAR(strSQL) > 0 Then
                                    '不備内容にレコードがあった
                                    iErrorFlag = 1
                                Else
                                    iErrorFlag = 0
                                End If

                            Else
                                iErrorFlag = 0
                            End If
                            '==================================================
                            '枚数とシーケンスを取得しながらINSERTする
                            '==================================================
                            strSQL = "SELECT COUNT(*) FROM T_印刷ソート "
                            strSQL &= "WHERE ロットID = '" & strLotID & "' "
                            strSQL &= "AND 会社コード = '" & dtLeafSystemID.Rows(j)("会社コード") & "' "
                            strSQL &= "AND 所属事業所コード = '" & dtLeafSystemID.Rows(j)("所属事業所コード") & "' "
                            strSQL &= "AND 印刷ID = " & dtPrintID.Rows(i)("印刷ID") & " "
                            'strSQL &= "AND ページ数 = " & k + 1 'ページ数(リーフレットに関しては事業所単位のシーケンスを記録する)
                            strSQL &= "AND レコード番号 = " & dtLeafSystemID.Rows(j)("レコード番号") & " "
                            strSQL &= "AND 帳票種別ID = 5"
                            If sqlProcess.DB_EXECUTE_SCALAR(strSQL) = 0 Then
                                '存在していなかったらINSERT
                                strSQL = "INSERT INTO T_印刷ソート (ロットID, 会社コード, 所属事業所コード, 印刷ID, ページ数, レコード番号, システムID, "
                                strSQL &= "帳票種別ID, 帳票種別詳細, 分数, QR, 枚数, シーケンス, チェックフラグ, チェック日時, 作業者) VALUES("
                                strSQL &= "'" & strLotID & "'"  'ロットID
                                strSQL &= ", '" & dtLeafSystemID.Rows(j)("会社コード") & "'" '会社コード
                                strSQL &= ", '" & dtLeafSystemID.Rows(j)("所属事業所コード") & "'"  '所属事業所コード
                                strSQL &= ", " & dtPrintID.Rows(i)("印刷ID") '印刷ID
                                strSQL &= ", " & iLeafPage 'ページ数
                                iLeafPage += 1
                                strSQL &= ", " & dtLeafSystemID.Rows(j)("レコード番号")   'レコード番号
                                strSQL &= ", '" & dtLeafSystemID.Rows(j)("システムID") & "'"    'システムID
                                strSQL &= ", 5" '帳票種別ID(5＝リーフレット)
                                strSQL &= ", 1"  '帳票種別詳細(1～6まで)
                                strSQL &= ", ''"    '分数(NULL)
                                'QRコードの算出(システムID(15)＋帳票種別ID(1)＋エラーフラグ(1))
                                strQRCode = dtLeafSystemID.Rows(j)("システムID") & "5" & iErrorFlag.ToString & "1" 'カレントSEQの「1」を追加※印刷ソートは1固定
                                '2017/07/13
                                'チェックデジット付与を取りやめ
                                'strCD = ""
                                'blnResult = Modulus10(strQRCodeWithoutCD, 5, strCD)
                                'strQRCode = strQRCodeWithoutCD & strCD
                                strSQL &= ", '" & strQRCode & "'"
                                strSQL &= ", " & dtLeafSystemID.Rows.Count  '枚数
                                strSQL &= ", 0" 'シーケンス
                                strSQL &= ", 0"    'チェックフラグ
                                strSQL &= ", NULL, '')" 'チェック日時、作業者
                                sqlProcess.DB_UPDATE(strSQL)
                            End If

                        Next j

                    Next k

                Next i
                '↑ここまで
                '==================================================

#Region "没コード"

                '           If dtWeightHeader.Rows.Count > 0 Then

                '               WriteLstResult(lstResult, "該当事業所 総重量：" & dblOfficeTotalWeight)
                '               WriteLstResult(lstResult, "重量ヘッダ：" & dtWeightHeader.Rows(0)("重量ヘッダ"))

                '               'レコードがあったので１事業所で１封筒
                '               '==================================================
                '               'T_印刷管理テーブルにINSERT
                '               '2017/06/30
                '               'ラベル連番(0固定)、判定票枚数、リーフレット枚数項目の追加
                '               '==================================================
                '               strSQL = "INSERT INTO T_印刷管理 (ロットID, 会社コード, 所属事業所コード, 印刷ID, 重量ヘッダ, ラベル連番, 判定票枚数, リーフレット枚数) VALUES("
                '               strSQL &= "'" & strLotID & "'"  'ロットID
                '               strSQL &= ", '" & dtOffice.Rows(iRow)("会社コード") & "'"  '会社コード
                '               strSQL &= ", '" & dtOffice.Rows(iRow)("所属事業所コード") & "'"   '所属事業所コード
                '               strSQL &= ", 1" '印刷ID(１事業所１封筒の場合は必ず1)
                '               strSQL &= ", '" & dtWeightHeader.Rows(0)("重量ヘッダ") & "'"
                '               strSQL &= ", 0" 'ラベル連番(ひとまず固定で0をINSERT)
                '               strSQL &= ", " & iCheckupCount  '判定票枚数
                '               strSQL &= ", " & iLeafletCount  'リーフレット枚数
                '               strSQL &= ")"
                '               sqlProcess.DB_UPDATE(strSQL)
                '               '==================================================
                '               'T_印刷ソートテーブルにINSERT
                '               '==================================================
                '               'ラベル
                '               '==================================================
                '               strSQL = "INSERT INTO T_印刷ソート (ロットID, 会社コード, 所属事業所コード, 印刷ID, ページ数, レコード番号, システムID, "
                '               strSQL &= "帳票種別ID, 帳票種別詳細, 分数, QR, 枚数, シーケンス, チェックフラグ) VALUES("
                '               strSQL &= "'" & strLotID & "'"  'ロットID
                '               strSQL &= ", '" & dtOffice.Rows(iRow)("会社コード") & "'"    '会社コード
                '               strSQL &= ", '" & dtOffice.Rows(iRow)("所属事業所コード") & "'" '所属事業所コード
                '               strSQL &= ", 1" '印刷ID(1固定)
                '               strSQL &= ", 0" 'ページ数(0固定)
                '               strSQL &= ", 0" 'レコード番号(0固定)
                '               strSQL &= ", ''"    'システムID(NULL固定)
                '               strSQL &= ", 0" '帳票種別ID(0＝ラベル)
                '               strSQL &= ", 1" '帳票種別詳細
                '               strSQL &= ", ''"    '分数(別れないのでNULL)
                '               'QRコードの算出(会社コード(4)＋所属事業所コード(6)＋封筒番号(2)＋封筒総数(2)＋帳票種別ID(1))
                '               '封筒番号、封筒総数は「01」固定
                '               strQRCodeWithoutCD = dtOffice.Rows(iRow)("会社コード") & dtOffice.Rows(iRow)("所属事業所コード") & "0" & "0101"
                '               strCD = ""
                '               blnResult = Modulus10(strQRCodeWithoutCD, 0, strCD)
                '               strQRCode = strQRCodeWithoutCD & strCD

                '               strSQL &= ", '" & strQRCode & "'"   'QRコード
                '               strSQL &= ", 0, 0, 0)" '枚数、シーケンス、チェックフラグは0固定
                '               sqlProcess.DB_UPDATE(strSQL)
                '               '==================================================
                '               '対象者一覧
                '               '該当システムIDを「T_対象者一覧印刷」にもINSERT
                '               '指定レコード数を超えた場合は分数に「1/2」「2/2」等を記述する
                '               '==================================================
                '               strSQL = "SELECT T1.ロットID, T1.レコード番号, T1.システムID, T2.会社, T2.所属事業所, T1.所属部名, T1.所属課名, T2.氏名姓 + ' ' + T2.氏名名 AS 氏名, "
                '               strSQL &= "T2.受診日, T3.変換健診種別 AS 健診種別, T2.就業区分, "
                '               strSQL &= "T1.判定票CSV, T1.リーフレットCSV, ISNULL(T1.要修正日時, '1900/01/01') AS 要修正日時, ISNULL(修正済日時, '1900/01/01') AS 修正済日時 "
                '               strSQL &= "FROM T_判定票管理 AS T1 INNER JOIN "
                '               strSQL &= "T_判定票 AS T2 ON T1.ロットID = T2.ロットID AND T1.レコード番号 = T2.レコード番号 INNER JOIN "
                '               strSQL &= "M_健診種別 AS T3 ON T1.健診種別 = T3.健診種別 "
                '               strSQL &= "WHERE T1.ロットID = '" & strLotID & "' "
                '               strSQL &= "AND T1.会社コード = '" & dtOffice.Rows(iRow)("会社コード") & "' "
                '               strSQL &= "AND T1.所属事業所コード = '" & dtOffice.Rows(iRow)("所属事業所コード") & "' "
                '               strSQL &= "ORDER BY CASE WHEN ISNULL(T1.所属部名, '') = '' THEN 1 ELSE 0 END, "
                '               strSQL &= "T1.所属部名, "
                '               strSQL &= "CASE WHEN ISNULL(T1.所属課名, '') = '' THEN 1 ELSE 0 END, "
                '               strSQL &= "T1.所属課名, T1.社員コード"
                '               Dim dtCheckupList As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
                '               dblTemp = dtCheckupList.Rows.Count / iCheckupList
                '               Dim iCheckupListPage As Integer = Math.Ceiling(dblTemp) '切り上げてページ数を算出
                '               'ページで回してそれぞれのレコードをINSERT
                '               For iPage As Integer = 1 To iCheckupListPage
                '                   '==================================================
                '                   'T_印刷ソートへのINSERT
                '                   strSQL = "INSERT INTO T_印刷ソート (ロットID, 会社コード, 所属事業所コード, 印刷ID, ページ数, レコード番号, システムID, "
                '                   strSQL &= "帳票種別ID, 帳票種別詳細, 分数, QR, 枚数, シーケンス, チェックフラグ) VALUES("
                '                   strSQL &= "'" & strLotID & "'"  'ロットID
                '                   strSQL &= ", '" & dtOffice.Rows(iRow)("会社コード") & "'"    '会社コード
                '                   strSQL &= ", '" & dtOffice.Rows(iRow)("所属事業所コード") & "'" '所属事業所コード
                '                   strSQL &= ", 1" '印刷ID(1固定)
                '                   strSQL &= ", " & iPage  'ページ数
                '                   strSQL &= ", 0" 'レコード番号(0固定)
                '                   strSQL &= ", ''"    'システムID(NULL固定)
                '                   strSQL &= ", 2" '帳票種別ID(2＝対象者一覧)
                '                   strSQL &= ", 1" '帳票種別詳細
                '                   strSQL &= ", '" & iPage.ToString & "/" & iCheckupListPage.ToString & "'"    '分数(1ページの場合はNULL)
                '                   'QRコードの算出(会社コード(4)＋所属事業所コード(6)＋帳票種別ID(1)＋ページ数(4))
                '                   strQRCodeWithoutCD = dtOffice.Rows(iRow)("会社コード") & dtOffice.Rows(iRow)("所属事業所コード") & "2" & iPage.ToString("0000")
                '                   strCD = ""
                '                   blnResult = Modulus10(strQRCodeWithoutCD, 2, strCD)
                '                   strQRCode = strQRCodeWithoutCD & strCD

                '                   strSQL &= ", '" & strQRCode & "'"   'QRコード
                '                   strSQL &= ", 0, 0, 0)" '枚数、シーケンス、チェックフラグは0固定
                '                   sqlProcess.DB_UPDATE(strSQL)

                '                   '==================================================
                '                   'T_対象者一覧印刷へのINSERT
                '                   '開始ページ
                '                   '(ページ区切り数×現在ページ)ーページ区切り数
                '                   '1ページのときは(50×1)ー50＝0：開始要素
                '                   '2ページのときは(50×2)ー50＝50：開始要素
                '                   Dim iStartRec As Integer = (iCheckupList * iPage) - iCheckupList
                '                   '終了ページ
                '                   '(ページ区切り数×現在ページ)ー1
                '                   '1ページのときは(50×1)ー1＝49：終了要素
                '                   '2ページのときは(50×2)ー1＝99：終了要素
                '                   Dim iEndRec As Integer = (iCheckupList * iPage) - 1
                '                   '算出した最終レコードが実レコードより多かったら実レコードを代入する
                '                   If iEndRec > dtCheckupList.Rows.Count - 1 Then
                '                       iEndRec = dtCheckupList.Rows.Count - 1
                '                   End If
                '                   '開始要素と終了要素間で回す
                '                   For iRec As Integer = iStartRec To iEndRec

                '                       strSQL = "INSERT INTO T_対象者一覧印刷 (ロットID, 会社コード, 所属事業所コード, 印刷ID, ページ数, レコード番号, "
                '                       strSQL &= "会社, 所属事業所, 所属部名, 所属課名, 氏名, 受診日, 健診種別, 意見書発行, 判定票要押印) VALUES("
                '                       strSQL &= "'" & strLotID & "'"  'ロットID
                '                       strSQL &= ", '" & dtOffice.Rows(iRow)("会社コード") & "'"    '会社コード
                '                       strSQL &= ", '" & dtOffice.Rows(iRow)("所属事業所コード") & "'" '所属事業所コード
                '                       strSQL &= ", 1" '印刷ID(1固定)
                '                       strSQL &= ", " & iPage  'ページ数
                '                       strSQL &= ", " & dtCheckupList.Rows(iRec)("レコード番号") 'レコード番号
                '                       strSQL &= ", '" & dtCheckupList.Rows(iRec)("会社") & "'"  '会社
                '                       strSQL &= ", '" & dtCheckupList.Rows(iRec)("所属事業所") & "'"   '所属事業所
                '                       strSQL &= ", '" & dtCheckupList.Rows(iRec)("所属部名") & "'"    '所属部名
                '                       strSQL &= ", '" & dtCheckupList.Rows(iRec)("所属課名") & "'"    '所属課名
                '                       strSQL &= ", '" & dtCheckupList.Rows(iRec)("氏名") & "'"  '氏名
                '                       strSQL &= ", '" & dtCheckupList.Rows(iRec)("受診日") & "'" '受診日
                '                       strSQL &= ", '" & dtCheckupList.Rows(iRec)("健診種別") & "'"    '健診種別
                '                       '意見書発行、判定要要押印に「○」を印字するか否かを判断する
                '                       Dim strMark As String = ""
                '                       If dtCheckupList.Rows(iRec)("就業区分") = "就業制限" Or dtCheckupList.Rows(iRec)("就業区分") = "要休業" Or dtCheckupList.Rows(iRec)("就業区分") = "就業困難" Then
                '                           strMark = "○"
                '                       End If
                '                       strSQL &= ", '" & strMark & "'" '意見書発行
                '                       strSQL &= ", '" & strMark & "')"    '判定要要押印
                '                       sqlProcess.DB_UPDATE(strSQL)

                '                   Next iRec

                '               Next iPage
                '               '==================================================
                '               '保健指導対象者名簿
                '               '該当システムIDを「T_保健指導名簿印刷」にINSERT
                '               '指定レコード数を超えた場合は分数に「1/2」「2/2」等を記述する
                '               '==================================================
                '               '※リーフレットは1社員で複数枚ある場合があるので、保健指導のレコード数はリーフレットの件数となる
                '               'ため、別にグルーピングしてカウントする
                '               'strSQL = "SELECT COUNT(A1.カウント) AS カウント "
                '               'strSQL &= "FROM (SELECT COUNT(T1.レコード番号) AS カウント "
                '               'strSQL &= "FROM T_リーフレット AS T1 INNER JOIN "
                '               'strSQL &= "T_判定票管理 AS T2 ON T1.ロットID = T2.ロットID "
                '               'strSQL &= "AND T1.レコード番号 = T2.レコード番号 "
                '               'strSQL &= "WHERE T1.ロットID = '" & strLotID & "' "
                '               'strSQL &= "AND T1.会社コード = '" & dtOffice.Rows(iRow)("会社コード") & "' "
                '               'strSQL &= "AND T1.所属事業所コード = '" & dtOffice.Rows(iRow)("所属事業所コード") & "' "
                '               'strSQL &= "AND T2.リーフレット無効 != 1 "   'リーフレット無効が立っていたら出力しない
                '               'strSQL &= "GROUP BY T1.レコード番号) AS A1"
                '               strSQL = "SELECT T1.ロットID, T1.会社コード, T1.所属事業所コード, T1.レコード番号, T1.会社, "
                '               strSQL &= "T1.所属事業所, T1.所属部名, T1.所属課名, T1.社員コード, T1.氏名姓 + ' ' + T1.氏名名 AS 氏名, "
                '               strSQL &= "COUNT(T1.レコード番号) AS カウント "
                '               strSQL &= "FROM T_リーフレット AS T1 INNER JOIN "
                '               strSQL &= "T_判定票管理 AS T2 ON T1.ロットID = T2.ロットID "
                '               strSQL &= "AND T1.レコード番号 = T2.レコード番号 "
                '               strSQL &= "WHERE T1.ロットID = '" & strLotID & "' "
                '               strSQL &= "AND T1.会社コード = '" & dtOffice.Rows(iRow)("会社コード") & "' "
                '               strSQL &= "AND T1.所属事業所コード = '" & dtOffice.Rows(iRow)("所属事業所コード") & "' "
                '               strSQL &= "AND T2.リーフレット無効 != 1 "
                '               strSQL &= "GROUP BY T1.ロットID, T1.会社コード, T1.所属事業所コード, T1.レコード番号, T1.会社, "
                '               strSQL &= "T1.所属事業所, T1.所属部名, T1.所属課名, T1.社員コード, T1.氏名姓, T1.氏名名"
                '               '社員一人あたり1レコードのDATATABLE
                '               Dim dtLeafletRec As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)

                '               Dim iLeafletRec As Integer = dtLeafletRec.Rows.Count
                '               dblTemp = iLeafletRec / iLeafletList
                '               Dim iLeafletListPage As Integer = Math.Ceiling(dblTemp)   '切り上げてページ数を算出

                '               'dblTemp = dtLeafletList.Rows.Count / iLeafletList
                '               'ページで回してそれぞれのレコードをINSERT
                '               For iPage As Integer = 1 To iLeafletListPage
                '                   '==================================================
                '                   'T_印刷ソートへのINSERT
                '                   strSQL = "INSERT INTO T_印刷ソート (ロットID, 会社コード, 所属事業所コード, 印刷ID, ページ数, レコード番号, システムID, "
                '                   strSQL &= "帳票種別ID, 帳票種別詳細, 分数, QR, 枚数, シーケンス, チェックフラグ) VALUES("
                '                   strSQL &= "'" & strLotID & "'"  'ロットID
                '                   strSQL &= ", '" & dtOffice.Rows(iRow)("会社コード") & "'"    '会社コード
                '                   strSQL &= ", '" & dtOffice.Rows(iRow)("所属事業所コード") & "'" '所属事業所コード
                '                   strSQL &= ", 1" '印刷ID(1固定)
                '                   strSQL &= ", " & iPage  'ページ数
                '                   strSQL &= ", 0" 'レコード番号(0固定)
                '                   strSQL &= ", ''"    'システムID(NULL固定)
                '                   strSQL &= ", 3" '帳票種別ID(3＝保健指導対象者名簿)
                '                   strSQL &= ", 1" '帳票種別詳細
                '                   strSQL &= ", '" & iPage.ToString & "/" & iLeafletListPage.ToString & "'"    '分数(1ページの場合はNULL)
                '                   'QRコードの算出(会社コード(4)＋所属事業所コード(6)＋帳票種別ID(1)＋ページ数(4))
                '                   strQRCodeWithoutCD = dtOffice.Rows(iRow)("会社コード") & dtOffice.Rows(iRow)("所属事業所コード") & "3" & iPage.ToString("0000")
                '                   strCD = ""
                '                   blnResult = Modulus10(strQRCodeWithoutCD, 3, strCD)
                '                   strQRCode = strQRCodeWithoutCD & strCD

                '                   strSQL &= ", '" & strQRCode & "'"   'QRコード
                '                   strSQL &= ", 0, 0, 0)" '枚数、シーケンス、チェックフラグは0固定
                '                   sqlProcess.DB_UPDATE(strSQL)

                '                   '==================================================
                '                   'T_保健指導名簿印刷へのINSERT
                '                   '一人あたり1レコードのDATATABLEを使用する
                '                   '開始ページ
                '                   Dim iStartRec As Integer = (iLeafletList * iPage) - iLeafletList
                '                   '終了ページ
                '                   Dim iEndRec As Integer = (iLeafletList * iPage) - 1
                '                   '算出した最終レコードが実レコードより多かったら実レコードを代入する
                '                   If iEndRec > dtLeafletRec.Rows.Count - 1 Then
                '                       iEndRec = dtLeafletRec.Rows.Count - 1
                '                   End If
                '                   '開始要素と終了要素で回す
                '                   '一度テンポラリに入れて複数帳票タイプがある(レコード番号が同一)システムIDもそのままINSERT
                '                   'T_保健指導名簿TEMPへのINSERT
                '                   strSQL = "DELETE FROM T_保健指導名簿TEMP" 'T_保健指導名簿の削除
                '                   sqlProcess.DB_UPDATE(strSQL)

                '                   Dim iRecNumber As Integer = 0
                '                   Dim iSeq As Integer = 0
                '                   For iRec As Integer = iStartRec To iEndRec  '一人あたり1レコードのインデックス
                '                       'レコード番号単位でレコードを抽出して順次INSERTする
                '                       '帳票タイプもキーに入っているDATATABLE(一人あたり複数レコードあり)
                '                       strSQL = "SELECT T1.ロットID, T1.レコード番号, T1.会社, T1.所属事業所, T1.所属部名, T1.所属課名, "
                '                       strSQL &= "T1.社員コード, T1.氏名姓 + ' ' + T1.氏名名 AS 氏名, T3.変換帳票タイプ AS 帳票タイプ "
                '                       strSQL &= "FROM T_判定票 AS T1 INNER JOIN "
                '                       strSQL &= "T_リーフレット AS T2 ON T1.ロットID = T2.ロットID AND T1.レコード番号 = T2.レコード番号 INNER JOIN "
                '                       strSQL &= "M_帳票タイプ AS T3 ON T2.帳票タイプ = T3.帳票タイプ INNER JOIN "
                '                       strSQL &= "T_判定票管理 AS T4 ON T1.ロットID = T4.ロットID AND T1.レコード番号 = T4.レコード番号 "
                '                       strSQL &= "WHERE T1.ロットID = '" & strLotID & "' "
                '                       strSQL &= "AND T1.会社コード = '" & dtOffice.Rows(iRow)("会社コード") & "' "
                '                       strSQL &= "AND T1.所属事業所コード = '" & dtOffice.Rows(iRow)("所属事業所コード") & "' "
                '                       strSQL &= "AND T1.レコード番号 = " & dtLeafletRec.Rows(iRec)("レコード番号") & " "
                '                       strSQL &= "AND T4.リーフレット無効 != 1 "   'リーフレット無効が立っていたら出力しない
                '                       strSQL &= "ORDER BY CASE WHEN ISNULL(T1.所属部名, '') = '' THEN 1 ELSE 0 END, "
                '                       strSQL &= "T1.所属部名, "
                '                       strSQL &= "CASE WHEN ISNULL(T1.所属課名, '') = '' THEN 1 ELSE 0 END, "
                '                       strSQL &= "T1.所属課名, T1.社員コード"
                '                       Dim dtLeafletList As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)

                '                       For i As Integer = 0 To dtLeafletList.Rows.Count - 1

                '                           strSQL = "INSERT INTO T_保健指導名簿TEMP (ロットID, 会社コード, 所属事業所コード, 印刷ID, ページ数, レコード番号, "
                '                           strSQL &= "シーケンス, 会社, 所属事業所, 所属部名, 所属課名, 社員コード, 氏名, 帳票タイプ) VALUES("
                '                           strSQL &= "'" & strLotID & "'"  'ロットID
                '                           strSQL &= ", '" & dtOffice.Rows(iRow)("会社コード") & "'"    '会社コード
                '                           strSQL &= ", '" & dtOffice.Rows(iRow)("所属事業所コード") & "'" '所属事業所コード
                '                           strSQL &= ", 1" '印刷ID(1固定)
                '                           strSQL &= ", " & iPage  'ページ数
                '                           strSQL &= ", " & dtLeafletList.Rows(i)("レコード番号") 'レコード番号
                '                           If iRecNumber = dtLeafletList.Rows(i)("レコード番号") Then
                '                               iSeq += 1
                '                           Else
                '                               iSeq = 1
                '                           End If
                '                           strSQL &= ", " & iSeq   'シーケンス
                '                           '現在のレコード番号を記憶
                '                           iRecNumber = dtLeafletList.Rows(i)("レコード番号")

                '                           strSQL &= ", '" & dtLeafletList.Rows(i)("会社") & "'"    '会社
                '                           strSQL &= ", '" & dtLeafletList.Rows(i)("所属事業所") & "'"   '所属事業所
                '                           strSQL &= ", '" & dtLeafletList.Rows(i)("所属部名") & "'"    '所属部名
                '                           strSQL &= ", '" & dtLeafletList.Rows(i)("所属課名") & "'"    '所属課名
                '                           strSQL &= ", '" & dtLeafletList.Rows(i)("社員コード") & "'"    '社員コード
                '                           strSQL &= ", '" & dtLeafletList.Rows(i)("氏名") & "'"    '氏名
                '                           strSQL &= ", '" & dtLeafletList.Rows(i)("帳票タイプ") & "')"    '帳票タイプ
                '                           sqlProcess.DB_UPDATE(strSQL)

                '                       Next

                '                   Next iRec

                '                   'T_保健指導名簿へのINSERT
                '                   strSQL = "INSERT INTO T_保健指導名簿印刷 "
                '                   strSQL &= "SELECT ロットID, 会社コード, 所属事業所コード, 印刷ID, ページ数, レコード番号, "
                '                   strSQL &= "会社, 所属事業所, 所属部名, 所属課名, 社員コード, 氏名, "
                '                   strSQL &= "(SELECT A1.帳票タイプ + '　' FROM T_保健指導名簿TEMP AS A1 "
                '                   strSQL &= "WHERE A1.レコード番号 = T1.レコード番号 "
                '                   strSQL &= "ORDER BY A1.レコード番号 "
                '                   strSQL &= "FOR XML PATH(''), TYPE).value('.', 'VARCHAR(MAX)') AS 帳票タイプ, "
                '                   strSQL &= "'' AS QRコード "
                '                   strSQL &= "FROM T_保健指導名簿TEMP AS T1 "
                '                   strSQL &= "GROUP BY ロットID, 会社コード, 所属事業所コード, 印刷ID, ページ数, レコード番号, "
                '                   strSQL &= "会社, 所属事業所, 所属部名, 所属課名, 社員コード, 氏名"
                '                   sqlProcess.DB_UPDATE(strSQL)

                '               Next iPage

                '               '==================================================
                '               '判定票
                '               'ここではT_印刷ソートにのみINSERT
                '               '==================================================
                '               'T_対象者一覧のデータ作成時に使用したDATATABLEを再利用
                '               For i As Integer = 0 To dtCheckupList.Rows.Count - 1

                '                   '==================================================
                '                   '要修正日時に日付が入っていて、修正済日時に日付が入っていないものはエラーフラグ＝1としてQRコードにセットする
                '                   'それ以外はエラーフラグ＝0
                '                   Dim iErrorFlag As Integer = 0
                '                   If dtCheckupList.Rows(i)("要修正日時") <> "1900/01/01" And dtCheckupList.Rows(i)("修正済日時") = "1900/01/01" Then
                '                       '要修正日時に日付が入っていて、修正済日時に日付が入っていない場合は、エラーが解消されていない
                '                       '更に「T_判定票_不備内容」のCSVファイル項目にリーフレットのCSVファイル名があるか調べて1件でも存在すればエラーフラグを立てる
                '                       strSQL = "SELECT COUNT(*) FROM T_判定票_不備内容 "
                '                       strSQL &= "WHERE ロットID = '" & strLotID & "' "
                '                       strSQL &= "AND レコード番号 = " & dtCheckupList.Rows(i)("レコード番号") & " "
                '                       strSQL &= "AND CSVファイル = '" & dtCheckupList.Rows(i)("判定票CSV") & "'"
                '                       If sqlProcess.DB_EXECUTE_SCALAR(strSQL) > 0 Then
                '                           '不備内容にレコードがあった
                '                           iErrorFlag = 1
                '                       Else
                '                           iErrorFlag = 0
                '                       End If

                '                   Else
                '                       iErrorFlag = 0
                '                   End If
                '                   '==================================================

                '                   strSQL = "INSERT INTO T_印刷ソート (ロットID, 会社コード, 所属事業所コード, 印刷ID, ページ数, レコード番号, システムID, "
                '                   strSQL &= "帳票種別ID, 帳票種別詳細, 分数, QR, 枚数, シーケンス, チェックフラグ) VALUES("
                '                   strSQL &= "'" & strLotID & "'"  'ロットID
                '                   strSQL &= ", '" & dtOffice.Rows(iRow)("会社コード") & "'"    '会社コード
                '                   strSQL &= ", '" & dtOffice.Rows(iRow)("所属事業所コード") & "'" '所属事業所コード
                '                   strSQL &= ", 1" '印刷ID(1固定)
                '                   strSQL &= ", " & i + 1 'ページ数(事業所内の連番)
                '                   strSQL &= ", " & dtCheckupList.Rows(i)("レコード番号")    'レコード番号
                '                   strSQL &= ", '" & dtCheckupList.Rows(i)("システムID") & "'"    'システムID
                '                   strSQL &= ", 4" '帳票種別ID(4＝判定票)
                '                   strSQL &= ", 1" '帳票種別詳細
                '                   strSQL &= ", ''"    '分数(NULL)
                '                   'QRコードの算出(システムID(15)＋帳票種別ID(1)＋エラーフラグ(1))
                '                   strQRCodeWithoutCD = dtCheckupList.Rows(i)("システムID") & "4" & iErrorFlag.ToString
                '                   strCD = ""
                '                   blnResult = Modulus10(strQRCodeWithoutCD, 4, strCD)
                '                   strQRCode = strQRCodeWithoutCD & strCD
                '                   strSQL &= ", '" & strQRCode & "'"
                '                   strSQL &= ", 0, 0, 0)" '枚数、シーケンス、チェックフラグは0固定
                '                   sqlProcess.DB_UPDATE(strSQL)

                '               Next i
                '               '==================================================
                '               'リーフレット
                '               'ここではT_印刷ソートにのみINSERT
                '               '==================================================
                '               'システムID単位のレコードを取得し、システムID内でのページ数も取得する
                '               strSQL = "SELECT T1.ロットID, T1.レコード番号, T3.判定票CSV, T3.リーフレットCSV, "
                '               strSQL &= "ISNULL(T3.要修正日時, '1900/01/01') AS 要修正日時, ISNULL(T3.修正済日時, '1900/01/01') AS 修正済日時 "
                '               strSQL &= "FROM T_判定票 AS T1 INNER JOIN "
                '               strSQL &= "T_リーフレット AS T2 ON T1.ロットID = T2.ロットID AND T1.レコード番号 = T2.レコード番号 INNER JOIN "
                '               strSQL &= "T_判定票管理 AS T3 ON T1.ロットID = T3.ロットID AND T1.レコード番号 = T3.レコード番号 "
                '               strSQL &= "WHERE T1.ロットID = '" & strLotID & "' "
                '               strSQL &= "AND T1.会社コード = '" & dtOffice.Rows(iRow)("会社コード") & "' "
                '               strSQL &= "AND T1.所属事業所コード = '" & dtOffice.Rows(iRow)("所属事業所コード") & "' "
                '               strSQL &= "AND T3.リーフレット無効 != 1 "   'リーフレット無効が立っていたら出力しない
                '               strSQL &= "ORDER BY CASE WHEN ISNULL(T1.所属部名, '') = '' THEN 1 ELSE 0 END, "
                '               strSQL &= "T1.所属部名, "
                '               strSQL &= "CASE WHEN ISNULL(T1.所属課名, '') = '' THEN 1 ELSE 0 END, "
                '               strSQL &= "T1.所属課名, T1.社員コード"
                '               Dim dtLeaf As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
                '               For i As Integer = 0 To dtLeaf.Rows.Count - 1
                '                   'システムID単位で回す
                '                   strSQL = "SELECT ロットID, 会社コード, 所属事業所コード, レコード番号, システムID "
                '                   strSQL &= "FROM T_リーフレット "
                '                   strSQL &= "WHERE ロットID = '" & strLotID & "' "
                '                   strSQL &= "AND レコード番号 = " & dtLeaf.Rows(i)("レコード番号")
                '                   Dim dtLeafSystemID As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
                '                   For j As Integer = 0 To dtLeafSystemID.Rows.Count - 1
                '                       '2017/07/01
                '                       '※同一システムIDで複数のリーフレットが存在した場合はT_印刷ソートテーブルには上位1レコードしかINSERTさせない
                '                       '==================================================
                '                       '要修正日時に日付が入っていて、修正済日時に日付が入っていないものはエラーフラグ＝1としてQRコードにセットする
                '                       'それ以外はエラーフラグ＝0
                '                       Dim iErrorFlag As Integer = 0
                '                       If dtLeaf.Rows(i)("要修正日時") <> "1900/01/01" And dtLeaf.Rows(i)("修正済日時") = "1900/01/01" Then
                '                           '要修正日時に日付が入っていて、修正済日時に日付が入っていない場合は、エラーが解消されていない
                '                           '更に「T_判定票_不備内容」のCSVファイル項目にリーフレットのCSVファイル名があるか調べて1件でも存在すればエラーフラグを立てる
                '                           strSQL = "SELECT COUNT(*) FROM T_判定票_不備内容 "
                '                           strSQL &= "WHERE ロットID = '" & strLotID & "' "
                '                           strSQL &= "AND レコード番号 = " & dtLeaf.Rows(i)("レコード番号") & " "
                '                           strSQL &= "AND CSVファイル = '" & dtLeaf.Rows(i)("リーフレットCSV") & "'"
                '                           If sqlProcess.DB_EXECUTE_SCALAR(strSQL) > 0 Then
                '                               '不備内容にレコードがあった
                '                               iErrorFlag = 1
                '                           Else
                '                               iErrorFlag = 0
                '                           End If

                '                       Else
                '                           iErrorFlag = 0
                '                       End If
                '                       '==================================================
                '                       '枚数とシーケンスを取得しながらINSERTする
                '                       '==================================================
                '                       strSQL = "SELECT COUNT(*) FROM T_印刷ソート "
                '                       strSQL &= "WHERE ロットID = '" & strLotID & "' "
                '                       strSQL &= "AND 会社コード = '" & dtLeafSystemID.Rows(j)("会社コード") & "' "
                '                       strSQL &= "AND 所属事業所コード = '" & dtLeafSystemID.Rows(j)("所属事業所コード") & "' "
                '                       strSQL &= "AND 印刷ID = 1 "
                '                       strSQL &= "AND ページ数 = 0 "
                '                       strSQL &= "AND レコード番号 = " & dtLeafSystemID.Rows(j)("レコード番号") & " "
                '                       strSQL &= "AND 帳票種別ID = 5"
                '                       If sqlProcess.DB_EXECUTE_SCALAR(strSQL) = 0 Then
                '                           '存在していなかったらINSERT
                '                           strSQL = "INSERT INTO T_印刷ソート (ロットID, 会社コード, 所属事業所コード, 印刷ID, ページ数, レコード番号, システムID, "
                '                           strSQL &= "帳票種別ID, 帳票種別詳細, 分数, QR, 枚数, シーケンス, チェックフラグ) VALUES("
                '                           strSQL &= "'" & strLotID & "'"  'ロットID
                '                           strSQL &= ", '" & dtLeafSystemID.Rows(j)("会社コード") & "'" '会社コード
                '                           strSQL &= ", '" & dtLeafSystemID.Rows(j)("所属事業所コード") & "'"  '所属事業所コード
                '                           strSQL &= ", 1" '印刷ID(1固定")
                '                           strSQL &= ", 0" 'ページ数(0固定)
                '                           strSQL &= ", " & dtLeafSystemID.Rows(j)("レコード番号")   'レコード番号
                '                           strSQL &= ", '" & dtLeafSystemID.Rows(j)("システムID") & "'"    'システムID
                '                           strSQL &= ", 5" '帳票種別ID(5＝リーフレット)
                '                           strSQL &= ", 1"  '帳票種別詳細(1～6まで)
                '                           strSQL &= ", ''"    '分数(NULL)
                '                           'QRコードの算出(システムID(15)＋帳票種別ID(1)＋エラーフラグ(1))
                '                           strQRCodeWithoutCD = dtLeafSystemID.Rows(j)("システムID") & "5" & iErrorFlag.ToString & "1" 'カレントSEQの「1」を追加※印刷ソートは1固定
                '                           strCD = ""
                '                           blnResult = Modulus10(strQRCodeWithoutCD, 5, strCD)
                '                           strQRCode = strQRCodeWithoutCD & strCD
                '                           strSQL &= ", '" & strQRCode & "'"
                '                           strSQL &= ", " & dtLeafSystemID.Rows.Count  '枚数
                '                           strSQL &= ", 0"  'シーケンス
                '                           strSQL &= ", 0)"    'チェックフラグ
                '                           sqlProcess.DB_UPDATE(strSQL)

                '                       End If

                '                   Next j

                '               Next i

                '           Else
                '               '複数封筒に別れる処理
                '               WriteLstResult(lstResult, "該当事業所 総重量：" & dblOfficeTotalWeight)
                '               WriteLstResult(lstResult, "重量が最大封筒の上限を超えたため複数封筒となります")

                '               'T_複数封筒計算テーブル
                '               '毎回T_複数封筒計算テーブル内の該当ロットIDを削除する
                '               strSQL = "DELETE FROM T_複数封筒計算 "
                '               strSQL &= "WHERE ロットID = '" & strLotID & "'"
                '               sqlProcess.DB_UPDATE(strSQL)

                'strSQL = "SELECT ロットID, レコード番号, リーフレット無効, 重量 FROM T_判定票管理 "
                'strSQL &= "WHERE ロットID = '" & strLotID & "' "
                'strSQL &= "AND 会社コード = '" & dtOffice.Rows(iRow)("会社コード") & "' "
                'strSQL &= "AND 所属事業所コード = '" & dtOffice.Rows(iRow)("所属事業所コード") & "' "
                '               strSQL &= "ORDER BY CASE WHEN ISNULL(所属部名, '') = '' THEN 1 ELSE 0 END, "
                '               strSQL &= "所属部名, "
                '               strSQL &= "CASE WHEN ISNULL(所属課名, '') = '' THEN 1 ELSE 0 END, "
                '               strSQL &= "所属課名, "
                '               strSQL &= "社員コード"
                '               Dim dtMultiEnvelope As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
                '               Dim iPrintID As Integer = 0 '印刷ID
                '               Dim dblTotalWeight As Double = 0    '累積重量用
                '               Dim iSeq As Integer = 0 'シーケンス
                '               Dim iNowCheckupCount As Integer = 1 '対象者一覧の現在のレコード数。対象者一覧の限度レコード数に達したらレコード追加する
                '               Dim iNowLeafletCount As Integer = 1 '対象者名簿の現在のレコード数。対象者名簿の限度レコード数に達したらレコードを追加する

                '               For iMulti As Integer = 0 To dtMultiEnvelope.Rows.Count - 1
                '                   If iMulti = 0 Then
                '                       iPrintID += 1
                '                       iSeq += 1
                '                       '初回ループは必ずラベルレコードを追加
                '                       MultiEnvelopeInsert(strLotID, 0, iSeq, iPrintID, 0, dblLabelWeight, 0, 0, 0, dblLabelWeight)
                '                       dblTotalWeight += dblLabelWeight
                '                       '1件目の判定票
                '                       '対象者一覧レコードを追加
                '                       iSeq += 1
                '                       MultiEnvelopeInsert(strLotID, 0, iSeq, iPrintID, 2, 0, dblCheckupListWeight, 0, 0, dblTotalWeight + dblCheckupListWeight)
                '                       dblTotalWeight += dblCheckupListWeight
                '                       'リーフレットが無効かどうか調べて無効でなかった場合対象者名簿レコードを追加する
                '                       If dtMultiEnvelope.Rows(iMulti)("リーフレット無効") = 0 Then
                '                           'リーフレットがあった
                '                           iSeq += 1
                '                           MultiEnvelopeInsert(strLotID, 0, iSeq, iPrintID, 3, 0, 0, dblLeafletListWeight, 0, dblTotalWeight + dblLeafletListWeight)
                '                           dblTotalWeight += dblLeafletListWeight
                '			iNowLeafletCount += 1
                '			'==================================================
                '			'2017/07/10
                '			'リーフレットレコードのINSERT
                '			'※重量は判定票部分に含まれるため加算しない
                '			iSeq += 1
                '			MultiEnvelopeInsert(strLotID, dtMultiEnvelope.Rows(iMulti)("レコード番号"), iSeq, iPrintID, 5, 0, 0, 0, 0, dblTotalWeight)
                '			'==================================================
                '		End If
                '		'判定票のレコードを追加
                '		iSeq += 1
                '                       MultiEnvelopeInsert(strLotID, dtMultiEnvelope.Rows(iMulti)("レコード番号"), iSeq, iPrintID, 4, 0, 0, 0, dtMultiEnvelope.Rows(iMulti)("重量"), dblTotalWeight + dtMultiEnvelope.Rows(iMulti)("重量"))
                '                       dblTotalWeight += dtMultiEnvelope.Rows(iMulti)("重量")
                '                       iNowCheckupCount += 1

                '                   Else
                '                       '2レコード目以降
                '                       '重量チェック
                '                       '当該レコードの重量を足したdblTotalWeightが重量ヘッダ「H」の重量TOを超えていたら
                '                       '印刷IDをインクリメントしてラベルレコードから再開する
                '                       'iNowCheckupCount、iNowLeafletCountのリセット
                '                       'dblTotalWeightのリセット

                '                       '最大重量の取得
                '                       strSQL = "SELECT 重量TO FROM M_重量ヘッダ "
                '                       strSQL &= "WHERE 重量ヘッダ = 'H'"
                '                       Dim dblMaxWeight As Double = sqlProcess.DB_EXECUTE_SCALAR(strSQL)

                '                       If dblTotalWeight + dtMultiEnvelope.Rows(iMulti)("重量") > dblMaxWeight Then
                '                           '最大重量を超えていた
                '                           iPrintID += 1
                '                           iNowCheckupCount = 1
                '                           iNowLeafletCount = 1
                '                           dblTotalWeight = 0
                '                           'ラベルのレコード追加
                '                           iSeq += 1
                '                           MultiEnvelopeInsert(strLotID, 0, iSeq, iPrintID, 0, dblLabelWeight, 0, 0, 0, dblLabelWeight)
                '                           dblTotalWeight += dblLabelWeight
                '                           '対象者一覧レコードを追加
                '                           iSeq += 1
                '                           MultiEnvelopeInsert(strLotID, 0, iSeq, iPrintID, 2, 0, dblCheckupListWeight, 0, 0, dblTotalWeight + dblCheckupListWeight)
                '                           dblTotalWeight += dblCheckupListWeight
                '                           'リーフレットが無効かどうか調べて無効でなかった場合対象者名簿レコードを追加する
                '                           If dtMultiEnvelope.Rows(iMulti)("リーフレット無効") = 0 Then
                '                               'リーフレットがあった
                '                               iSeq += 1
                '                               MultiEnvelopeInsert(strLotID, 0, iSeq, iPrintID, 3, 0, 0, dblLeafletListWeight, 0, dblTotalWeight + dblLeafletListWeight)
                '                               dblTotalWeight += dblLeafletListWeight
                '                               iNowLeafletCount += 1
                '                           End If
                '                           '判定票のレコードを追加
                '                           iSeq += 1
                '                           MultiEnvelopeInsert(strLotID, dtMultiEnvelope.Rows(iMulti)("レコード番号"), iSeq, iPrintID, 4, 0, 0, 0, dtMultiEnvelope.Rows(iMulti)("重量"), dblTotalWeight + dtMultiEnvelope.Rows(iMulti)("重量"))
                '                           dblTotalWeight += dtMultiEnvelope.Rows(iMulti)("重量")
                '                           iNowCheckupCount += 1

                '                       Else
                '			'超えていなかった
                '			'対象者一覧チェック
                '			If iNowCheckupCount = iCheckupList + 1 Then
                '				'限度数を超えていたら対象者一覧をレコード追加し、iNowCheckCountをリセットする
                '				iSeq += 1
                '				MultiEnvelopeInsert(strLotID, 0, iSeq, iPrintID, 2, 0, dblCheckupListWeight, 0, 0, dblTotalWeight + dblCheckupListWeight)
                '				dblTotalWeight += dblCheckupListWeight
                '				iNowCheckupCount = 1
                '			End If
                '			'保健指導名簿チェック
                '			If dtMultiEnvelope.Rows(iMulti)("リーフレット無効") = 0 Then
                '				'リーフレットがあった
                '				'限度数を超えていたら保健指導名簿をレコード追加し、iNowLeafletCountをリセットする
                '				If iNowLeafletCount = iLeafletList + 1 Then
                '					iSeq += 1
                '					MultiEnvelopeInsert(strLotID, 0, iSeq, iPrintID, 3, 0, 0, dblLeafletListWeight, 0, dblTotalWeight + dblLeafletListWeight)
                '					dblTotalWeight += dblLeafletListWeight
                '					iNowLeafletCount = 1
                '				Else
                '					'限度数を超えていなかったらインクリメント
                '					iNowLeafletCount += 1
                '                               End If
                '				'==================================================
                '				'2017/07/10
                '				'リーフレットレコードのINSERT
                '				'※重量は判定票部分に含まれるため加算しない
                '				iSeq += 1
                '				MultiEnvelopeInsert(strLotID, dtMultiEnvelope.Rows(iMulti)("レコード番号"), iSeq, iPrintID, 5, 0, 0, 0, 0, dblTotalWeight)
                '				'==================================================
                '			End If
                '			'判定票のレコードを追加
                '			iSeq += 1
                '                           MultiEnvelopeInsert(strLotID, dtMultiEnvelope.Rows(iMulti)("レコード番号"), iSeq, iPrintID, 4, 0, 0, 0, dtMultiEnvelope.Rows(iMulti)("重量"), dblTotalWeight + dtMultiEnvelope.Rows(iMulti)("重量"))
                '                           dblTotalWeight += dtMultiEnvelope.Rows(iMulti)("重量")
                '                           iNowCheckupCount += 1

                '                       End If

                '                   End If

                '               Next iMulti

                ''T_複数封筒計算を起点にして各テーブルより以下のテーブルを成型する
                ''T_印刷管理
                ''T_印刷ソート
                ''T_対象者一覧印刷
                ''T_保健指導名簿印刷
                ''T_判定票印刷
                ''T_リーフレット印刷

                ''==================================================
                ''T_印刷管理
                ''2017/06/30
                ''ラベル連番(0固定)、判定票枚数、リーフレット枚数項目の追加
                ''==================================================
                ''印刷IDでグルーピングして各最終レコードの累積重量を参照し、M_重量ヘッダから該当の重量ヘッダを取得する
                ''※T_複数封筒計算テーブルは事業所単位での計算を前提としたテーブル
                'strSQL = "SELECT 印刷ID, "
                '               strSQL &= "SUM(CASE WHEN 帳票種別ID = 4 THEN 1 ELSE 0 END) AS 判定票枚数, "
                '               strSQL &= "SUM(CASE WHEN 帳票種別ID = 5 THEN 1 ELSE 0 END) AS リーフレット枚数 "
                '               strSQL &= "FROM T_複数封筒計算 "
                '               strSQL &= "WHERE ロットID = '" & strLotID & "' "
                '               strSQL &= "GROUP BY 印刷ID "
                '               strSQL &= "ORDER BY 印刷ID"
                '               Dim dtPrintID As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
                '               WriteLstResult(lstResult, "封筒分割数：" & dtPrintID.Rows.Count)
                '               '全体を印刷IDで回す
                '               For i As Integer = 0 To dtPrintID.Rows.Count - 1
                '                   '該当印刷IDの累積重量を取得しておく
                '                   strSQL = "SELECT MAX(累積重量) FROM T_複数封筒計算 "
                '                   strSQL &= "WHERE 印刷ID = " & dtPrintID.Rows(i)("印刷ID")
                '                   Dim dblPrintIDWeight As Double = sqlProcess.DB_EXECUTE_SCALAR(strSQL)
                '                   '累積重量から重量ヘッダを取得する
                '                   strSQL = "SELECT 重量ヘッダ FROM M_重量ヘッダ "
                '	strSQL &= "WHERE " & dblPrintIDWeight & " BETWEEN 重量FROM AND 重量TO"
                '	'必ず重量ヘッダは引っかかる
                '	Dim strWeightHeader As String = sqlProcess.DB_EXECUTE_SCALAR(strSQL)
                '                   WriteLstResult(lstResult, i + 1 & "封筒目重量ヘッダ：" & strWeightHeader)
                '                   strSQL = "INSERT INTO T_印刷管理 (ロットID, 会社コード, 所属事業所コード, 印刷ID, 重量ヘッダ, ラベル連番, 判定票枚数, リーフレット枚数) VALUES("
                '                   strSQL &= "'" & strLotID & "'"  'ロットID
                '                   strSQL &= ", '" & dtOffice.Rows(iRow)("会社コード") & "'"
                '                   strSQL &= ", '" & dtOffice.Rows(iRow)("所属事業所コード") & "'"
                '                   strSQL &= ", " & dtPrintID.Rows(i)("印刷ID")
                '                   strSQL &= ", '" & strWeightHeader & "'" '重量ヘッダ
                '                   strSQL &= ", 0" 'ラベル連番(ひとまず固定で0)
                '                   strSQL &= ", " & dtPrintID.Rows(i)("判定票枚数") '判定票枚数
                '                   strSQL &= ", " & dtPrintID.Rows(i)("リーフレット枚数")  'リーフレット枚数
                '                   strSQL &= ")"
                '                   sqlProcess.DB_UPDATE(strSQL)

                '                   '==================================================
                '                   'ラベル
                '                   'T_印刷ソートにINSERT
                '                   '==================================================
                '                   strSQL = "INSERT INTO T_印刷ソート (ロットID, 会社コード, 所属事業所コード, 印刷ID, ページ数, レコード番号, システムID, "
                '                   strSQL &= "帳票種別ID, 帳票種別詳細, 分数, QR, 枚数, シーケンス, チェックフラグ) VALUES("
                '                   strSQL &= "'" & strLotID & "'"  'ロットID
                '                   strSQL &= ", '" & dtOffice.Rows(iRow)("会社コード") & "'"    '会社コード
                '                   strSQL &= ", '" & dtOffice.Rows(iRow)("所属事業所コード") & "'" '所属事業所コード
                '                   strSQL &= ", " & dtPrintID.Rows(i)("印刷ID")  '印刷ID
                '                   strSQL &= ", 0" 'ページ数(0固定)
                '                   strSQL &= ", 0" 'レコード番号(0固定)
                '                   strSQL &= ", ''"    'システムID(NULL固定)
                '                   strSQL &= ", 0" '帳票種別ID(0＝ラベル)
                '                   strSQL &= ", 1" '帳票種別詳細
                '                   strSQL &= ", '" & dtPrintID.Rows(i)("印刷ID") & "/" & dtPrintID.Rows.Count & "'"    '分数(印刷ID/印刷ID件数)
                '                   'QRコードの算出(会社コード(4)＋所属事業所コード(6)＋封筒番号(2)＋封筒総数(2)＋帳票種別ID(1))
                '                   '封筒番号(印刷ID)、封筒総数(印刷ID件数)
                '                   strQRCodeWithoutCD = dtOffice.Rows(iRow)("会社コード") & dtOffice.Rows(iRow)("所属事業所コード") & "0" & dtPrintID.Rows(i)("印刷ID").ToString("00") & dtPrintID.Rows.Count.ToString("00")
                '                   strCD = ""
                '                   blnResult = Modulus10(strQRCodeWithoutCD, 0, strCD)
                '                   strQRCode = strQRCodeWithoutCD & strCD

                '                   strSQL &= ", '" & strQRCode & "'"   'QRコード
                '                   strSQL &= ", 0, 0, 0)" '枚数、シーケンス、チェックフラグは0固定
                '                   sqlProcess.DB_UPDATE(strSQL)

                '                   '==================================================
                '                   '対象者一覧
                '                   '該当システムIDを「T_対象者一覧印刷」にもINSERT
                '                   '指定レコード数を超えた場合は分数に「1/2」「2/2」等を記述する
                '                   '==================================================
                '                   strSQL = "SELECT T1.ロットID, T1.レコード番号, T1.システムID, T2.会社, T2.所属事業所, T1.所属部名, T1.所属課名, T2.氏名姓 + ' ' + T2.氏名名 AS 氏名, "
                '                   strSQL &= "T2.受診日, T3.変換健診種別 AS 健診種別, T2.就業区分, T4.印刷ID, T1.判定票CSV, T1.リーフレットCSV, "
                '                   strSQL &= "ISNULL(T1.要修正日時, '1900/01/01') AS 要修正日時, ISNULL(T1.修正済日時, '1900/01/01') AS 修正済日時 "
                '                   strSQL &= "FROM T_判定票管理 AS T1 INNER JOIN "
                '                   strSQL &= "T_判定票 AS T2 ON T1.ロットID = T2.ロットID AND T1.レコード番号 = T2.レコード番号 INNER JOIN "
                '                   strSQL &= "M_健診種別 AS T3 ON T1.健診種別 = T3.健診種別 INNER JOIN "
                '                   strSQL &= "T_複数封筒計算 AS T4 ON T1.ロットID = T4.ロットID AND T1.レコード番号 = T4.レコード番号 "
                '                   strSQL &= "WHERE T1.ロットID = '" & strLotID & "' "
                '                   strSQL &= "AND T1.会社コード = '" & dtOffice.Rows(iRow)("会社コード") & "' "
                '                   strSQL &= "AND T1.所属事業所コード = '" & dtOffice.Rows(iRow)("所属事業所コード") & "' "
                '                   strSQL &= "AND T4.印刷ID = " & dtPrintID.Rows(i)("印刷ID") & " "
                '                   strSQL &= "AND T4.帳票種別ID = 4 "  '判定票を対象にする
                '                   strSQL &= "ORDER BY CASE WHEN ISNULL(T1.所属部名, '') = '' THEN 1 ELSE 0 END, "
                '                   strSQL &= "T1.所属部名, "
                '                   strSQL &= "CASE WHEN ISNULL(T1.所属課名, '') = '' THEN 1 ELSE 0 END, "
                '                   strSQL &= "T1.所属課名, T1.社員コード"
                '                   Dim dtCheckupList As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
                '                   dblTemp = dtCheckupList.Rows.Count / XmlSettings.Instance.CheckupList
                '                   Dim iCheckupListPage As Integer = Math.Ceiling(dblTemp) '切り上げてページ数を算出
                '                   'ページで回してそれぞれのレコードをINSERT
                '                   For iPage As Integer = 1 To iCheckupListPage
                '                       '==================================================
                '                       'T_印刷ソートへのINSERT
                '                       strSQL = "INSERT INTO T_印刷ソート (ロットID, 会社コード, 所属事業所コード, 印刷ID, ページ数, レコード番号, システムID, "
                '                       strSQL &= "帳票種別ID, 帳票種別詳細, 分数, QR, 枚数, シーケンス, チェックフラグ) VALUES("
                '                       strSQL &= "'" & strLotID & "'"  'ロットID
                '                       strSQL &= ", '" & dtOffice.Rows(iRow)("会社コード") & "'"    '会社コード
                '                       strSQL &= ", '" & dtOffice.Rows(iRow)("所属事業所コード") & "'" '所属事業所コード
                '                       strSQL &= ", " & dtPrintID.Rows(i)("印刷ID")  '印刷I
                '                       strSQL &= ", " & iPage  'ページ数
                '                       strSQL &= ", 0" 'レコード番号(0固定)
                '                       strSQL &= ", ''"    'システムID(NULL固定)
                '                       strSQL &= ", 2" '帳票種別ID(2＝対象者一覧)
                '                       strSQL &= ", 1" '帳票種別詳細
                '                       strSQL &= ", '" & iPage.ToString & "/" & iCheckupListPage.ToString & "'"    '分数(1ページの場合はNULL)
                '                       'QRコードの算出(会社コード(4)＋所属事業所コード(6)＋帳票種別ID(1)＋ページ数(4))
                '                       strQRCodeWithoutCD = dtOffice.Rows(iRow)("会社コード") & dtOffice.Rows(iRow)("所属事業所コード") & "2" & iPage.ToString("0000")
                '                       strCD = ""
                '                       blnResult = Modulus10(strQRCodeWithoutCD, 2, strCD)
                '                       strQRCode = strQRCodeWithoutCD & strCD

                '                       strSQL &= ", '" & strQRCode & "'"   'QRコード
                '                       strSQL &= ", 0, 0, 0)" '枚数、シーケンス、チェックフラグは0固定
                '                       sqlProcess.DB_UPDATE(strSQL)

                '                       '==================================================
                '                       'T_対象者一覧へのINSERT
                '                       '開始ページ
                '                       '(ページ区切り数×現在ページ)ーページ区切り数
                '                       '1ページのときは(50×1)ー50＝0：開始要素
                '                       '2ページのときは(50×2)ー50＝50：開始要素
                '                       Dim iStartRec As Integer = (iCheckupList * iPage) - iCheckupList
                '                       '終了ページ
                '                       '(ページ区切り数×現在ページ)ー1
                '                       '1ページのときは(50×1)ー1＝49：終了要素
                '                       '2ページのときは(50×2)ー1＝99：終了要素
                '                       Dim iEndRec As Integer = (iCheckupList * iPage) - 1
                '                       '算出した最終レコードが実レコードより多かったら実レコードを代入する
                '                       If iEndRec > dtCheckupList.Rows.Count - 1 Then
                '                           iEndRec = dtCheckupList.Rows.Count - 1
                '                       End If
                '                       '開始要素と終了要素間で回す
                '                       For iRec As Integer = iStartRec To iEndRec

                '                           strSQL = "INSERT INTO T_対象者一覧印刷 (ロットID, 会社コード, 所属事業所コード, 印刷ID, ページ数, レコード番号, "
                '                           strSQL &= "会社, 所属事業所, 所属部名, 所属課名, 氏名, 受診日, 健診種別, 意見書発行, 判定票要押印) VALUES("
                '                           strSQL &= "'" & strLotID & "'"  'ロットID
                '                           strSQL &= ", '" & dtOffice.Rows(iRow)("会社コード") & "'"    '会社コード
                '                           strSQL &= ", '" & dtOffice.Rows(iRow)("所属事業所コード") & "'" '所属事業所コード
                '                           strSQL &= ", " & dtPrintID.Rows(i)("印刷ID") '印刷ID
                '                           strSQL &= ", " & iPage  'ページ数
                '                           strSQL &= ", " & dtCheckupList.Rows(iRec)("レコード番号") 'レコード番号
                '                           strSQL &= ", '" & dtCheckupList.Rows(iRec)("会社") & "'"  '会社
                '                           strSQL &= ", '" & dtCheckupList.Rows(iRec)("所属事業所") & "'"   '所属事業所
                '                           strSQL &= ", '" & dtCheckupList.Rows(iRec)("所属部名") & "'"    '所属部名
                '                           strSQL &= ", '" & dtCheckupList.Rows(iRec)("所属課名") & "'"    '所属課名
                '                           strSQL &= ", '" & dtCheckupList.Rows(iRec)("氏名") & "'"  '氏名
                '                           strSQL &= ", '" & dtCheckupList.Rows(iRec)("受診日") & "'" '受診日
                '                           strSQL &= ", '" & dtCheckupList.Rows(iRec)("健診種別") & "'"    '健診種別
                '                           '意見書発行、判定要要押印に「○」を印字するか否かを判断する
                '                           Dim strMark As String = ""
                '                           If dtCheckupList.Rows(iRec)("就業区分") = "就業制限" Or dtCheckupList.Rows(iRec)("就業区分") = "要休業" Or dtCheckupList.Rows(iRec)("就業区分") = "就業困難" Then
                '                               strMark = "○"
                '                           End If
                '                           strSQL &= ", '" & strMark & "'" '意見書発行
                '                           strSQL &= ", '" & strMark & "')"    '判定要要押印
                '                           sqlProcess.DB_UPDATE(strSQL)

                '                       Next iRec

                '                   Next iPage
                '                   '==================================================
                '                   '保健指導対象者名簿
                '                   '該当システムIDを「T_保健指導名簿印刷」にINSERT
                '                   '指定レコード数を超えた場合は分数に「1/2」「2/2」等を記述する
                '                   '==================================================
                '                   strSQL = "SELECT T1.ロットID, T1.レコード番号, T1.会社, T1.所属事業所, T1.所属部名, T1.所属課名, "
                '                   strSQL &= "T1.社員コード, T1.氏名姓 + ' ' + T1.氏名名 AS 氏名, T3.変換帳票タイプ AS 帳票タイプ "
                '                   strSQL &= "FROM T_判定票 AS T1 INNER JOIN "
                '                   strSQL &= "T_リーフレット AS T2 ON T1.ロットID = T2.ロットID AND T1.レコード番号 = T2.レコード番号 INNER JOIN "
                '                   strSQL &= "M_帳票タイプ AS T3 ON T2.帳票タイプ = T3.帳票タイプ INNER JOIN "
                '                   strSQL &= "T_判定票管理 AS T4 ON T1.ロットID = T4.ロットID AND T1.レコード番号 = T4.レコード番号 INNER JOIN  "
                '                   strSQL &= "T_複数封筒計算 AS T5 ON T1.ロットID = T5.ロットID AND T1.レコード番号 = T5.ロットID "
                '                   strSQL &= "WHERE T1.ロットID = '" & strLotID & "' "
                '                   strSQL &= "AND T1.会社コード = '" & dtOffice.Rows(iRow)("会社コード") & "' "
                '                   strSQL &= "AND T1.所属事業所コード = '" & dtOffice.Rows(iRow)("所属事業所コード") & "' "
                '                   strSQL &= "AND T4.リーフレット無効 != 1 "   'リーフレット無効が立っていたら出力しない
                '                   strSQL &= "AND T5.印刷ID = " & dtPrintID.Rows(i)("印刷ID") & " "
                '                   strSQL &= "AND T5.帳票種別ID = 5 "  'リーフレットを対象にする
                '                   strSQL &= "ORDER BY CASE WHEN ISNULL(T1.所属部名, '') = '' THEN 1 ELSE 0 END, "
                '                   strSQL &= "T1.所属部名, "
                '                   strSQL &= "CASE WHEN ISNULL(T1.所属課名, '') = '' THEN 1 ELSE 0 END, "
                '                   strSQL &= "T1.所属課名, T1.社員コード"
                '                   Dim dtLeafletList As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
                '                   dblTemp = dtLeafletList.Rows.Count / iLeafletList
                '                   Dim iLeafletListPage As Integer = Math.Ceiling(dblTemp)   '切り上げてページ数を算出
                '                   'ページで回してそれぞれのレコードをINSERT
                '                   For iPage As Integer = 1 To iLeafletListPage
                '                       '==================================================
                '                       'T_印刷ソートへのINSERT
                '                       strSQL = "INSERT INTO T_印刷ソート (ロットID, 会社コード, 所属事業所コード, 印刷ID, ページ数, レコード番号, システムID, "
                '                       strSQL &= "帳票種別ID, 帳票種別詳細, 分数, QR, 枚数, シーケンス, チェックフラグ) VALUES("
                '                       strSQL &= "'" & strLotID & "'"  'ロットID
                '                       strSQL &= ", '" & dtOffice.Rows(iRow)("会社コード") & "'"    '会社コード
                '                       strSQL &= ", '" & dtOffice.Rows(iRow)("所属事業所コード") & "'" '所属事業所コード
                '                       strSQL &= ", " & dtPrintID.Rows(i)("印刷ID") '印刷ID
                '                       strSQL &= ", " & iPage  'ページ数
                '                       strSQL &= ", 0" 'レコード番号(0固定)
                '                       strSQL &= ", ''"    'システムID(NULL固定)
                '                       strSQL &= ", 3" '帳票種別ID(3＝保健指導対象者名簿)
                '                       strSQL &= ", 1" '帳票種別詳細
                '                       strSQL &= ", '" & iPage.ToString & "/" & iLeafletListPage.ToString & "'"    '分数(1ページの場合はNULL)
                '                       'QRコードの算出(会社コード(4)＋所属事業所コード(6)＋帳票種別ID(1)＋ページ数(4))
                '                       strQRCodeWithoutCD = dtOffice.Rows(iRow)("会社コード") & dtOffice.Rows(iRow)("所属事業所コード") & "3" & iPage.ToString("0000")
                '                       strCD = ""
                '                       blnResult = Modulus10(strQRCodeWithoutCD, 3, strCD)
                '                       strQRCode = strQRCodeWithoutCD & strCD

                '                       strSQL &= ", '" & strQRCode & "'"   'QRコード
                '                       strSQL &= ", 0, 0, 0)" '枚数、シーケンス、チェックフラグは0固定
                '                       sqlProcess.DB_UPDATE(strSQL)

                '                       '==================================================
                '                       'T_保健指導名簿印刷へのINSERT
                '                       '開始ページ
                '                       Dim iStartRec As Integer = (XmlSettings.Instance.LeafletList * iPage) - XmlSettings.Instance.LeafletList
                '                       '終了ページ
                '                       Dim iEndRec As Integer = (XmlSettings.Instance.LeafletList * iPage) - 1
                '                       '算出した最終レコードが実レコードより多かったら実レコードを代入する
                '                       If iEndRec > dtLeafletList.Rows.Count - 1 Then
                '                           iEndRec = dtLeafletList.Rows.Count - 1
                '                       End If
                '                       '開始要素と終了要素で回す
                '                       '一度テンポラリに入れて複数帳票タイプがある(レコード番号が同一)システムIDもそのままINSERT
                '                       'T_保健指導名簿TEMPへのINSERT
                '                       strSQL = "DELETE FROM T_保健指導名簿TEMP" 'T_保健指導名簿の削除
                '                       sqlProcess.DB_UPDATE(strSQL)

                '                       Dim iRecNumber As Integer = 0
                '                       iSeq = 0
                '                       For iRec As Integer = iStartRec To iEndRec
                '                           strSQL = "INSERT INTO T_保健指導名簿TEMP (ロットID, 会社コード, 所属事業所コード, 印刷ID, ページ数, レコード番号, "
                '                           strSQL &= "シーケンス, 会社, 所属事業所, 所属部名, 所属課名, 社員コード, 氏名, 帳票タイプ) VALUES("
                '                           strSQL &= "'" & strLotID & "'"  'ロットID
                '                           strSQL &= ", '" & dtOffice.Rows(iRow)("会社コード") & "'"    '会社コード
                '                           strSQL &= ", '" & dtOffice.Rows(iRow)("所属事業所コード") & "'" '所属事業所コード
                '                           strSQL &= ", " & dtPrintID.Rows(i)("印刷ID") '印刷ID
                '                           strSQL &= ", " & iPage  'ページ数
                '                           strSQL &= ", " & dtLeafletList.Rows(iRec)("レコード番号") 'レコード番号
                '                           If iRecNumber = dtLeafletList.Rows(iRec)("レコード番号") Then
                '                               iSeq += 1
                '                           Else
                '                               iSeq = 1
                '                           End If
                '                           strSQL &= ", " & iSeq   'シーケンス
                '                           '現在のレコード番号を記憶
                '                           iRecNumber = dtLeafletList.Rows(iRec)("レコード番号")

                '                           strSQL &= ", '" & dtLeafletList.Rows(iRec)("会社") & "'"    '会社
                '                           strSQL &= ", '" & dtLeafletList.Rows(iRec)("所属事業所") & "'"   '所属事業所
                '                           strSQL &= ", '" & dtLeafletList.Rows(iRec)("所属部名") & "'"    '所属部名
                '                           strSQL &= ", '" & dtLeafletList.Rows(iRec)("所属課名") & "'"    '所属課名
                '                           strSQL &= ", '" & dtLeafletList.Rows(iRec)("社員コード") & "'"    '社員コード
                '                           strSQL &= ", '" & dtLeafletList.Rows(iRec)("氏名") & "'"    '氏名
                '                           strSQL &= ", '" & dtLeafletList.Rows(iRec)("帳票タイプ") & "')"    '帳票タイプ
                '                           sqlProcess.DB_UPDATE(strSQL)
                '                       Next iRec

                '                       'T_保健指導名簿へのINSERT
                '                       strSQL = "INSERT INTO T_保健指導名簿印刷 "
                '                       strSQL &= "SELECT ロットID, 会社コード, 所属事業所コード, 印刷ID, ページ数, レコード番号, "
                '                       strSQL &= "会社, 所属事業所, 所属部名, 所属課名, 社員コード, 氏名, "
                '                       strSQL &= "(SELECT A1.帳票タイプ + '　' FROM T_保健指導名簿TEMP AS A1 "
                '                       strSQL &= "WHERE A1.レコード番号 = T1.レコード番号 "
                '                       strSQL &= "ORDER BY A1.レコード番号 "
                '                       strSQL &= "FOR XML PATH(''), TYPE).value('.', 'VARCHAR(MAX)') AS 帳票タイプ, "
                '                       strSQL &= "'' AS QRコード "
                '                       strSQL &= "FROM T_保健指導名簿TEMP AS T1 "
                '                       strSQL &= "GROUP BY ロットID, 会社コード, 所属事業所コード, 印刷ID, ページ数, レコード番号, "
                '                       strSQL &= "会社, 所属事業所, 所属部名, 所属課名, 社員コード, 氏名"
                '                       sqlProcess.DB_UPDATE(strSQL)

                '                   Next iPage

                '                   '==================================================
                '                   '判定票
                '                   'ここではT_印刷ソートにのみINSERT
                '                   '==================================================
                '                   'T_対象者一覧のデータ作成時に使用したDATATABLEを再利用
                '                   For j As Integer = 0 To dtCheckupList.Rows.Count - 1

                '                       '==================================================
                '                       '要修正日時に日付が入っていて、修正済日時に日付が入っていないものはエラーフラグ＝1としてQRコードにセットする
                '                       'それ以外はエラーフラグ＝0
                '                       Dim iErrorFlag As Integer = 0
                '                       If dtCheckupList.Rows(i)("要修正日時") <> "1900/01/01" And dtCheckupList.Rows(i)("修正済日時") = "1900/01/01" Then
                '                           '要修正日時に日付が入っていて、修正済日時に日付が入っていない場合は、エラーが解消されていない
                '                           '更に「T_判定票_不備内容」のCSVファイル項目にリーフレットのCSVファイル名があるか調べて1件でも存在すればエラーフラグを立てる
                '                           strSQL = "SELECT COUNT(*) FROM T_判定票_不備内容 "
                '                           strSQL &= "WHERE ロットID = '" & strLotID & "' "
                '                           strSQL &= "AND レコード番号 = " & dtCheckupList.Rows(i)("レコード番号") & " "
                '                           strSQL &= "AND CSVファイル = '" & dtCheckupList.Rows(i)("判定票CSV") & "'"
                '                           If sqlProcess.DB_EXECUTE_SCALAR(strSQL) > 0 Then
                '                               '不備内容にレコードがあった
                '                               iErrorFlag = 1
                '                           Else
                '                               iErrorFlag = 0
                '                           End If

                '                       Else
                '                           iErrorFlag = 0
                '                       End If
                '                       '==================================================
                '                       strSQL = "INSERT INTO T_印刷ソート (ロットID, 会社コード, 所属事業所コード, 印刷ID, ページ数, レコード番号, システムID, "
                '                       strSQL &= "帳票種別ID, 帳票種別詳細, 分数, QR, 枚数, シーケンス, チェックフラグ) VALUES("
                '                       strSQL &= "'" & strLotID & "'"  'ロットID
                '                       strSQL &= ", '" & dtOffice.Rows(iRow)("会社コード") & "'"    '会社コード
                '                       strSQL &= ", '" & dtOffice.Rows(iRow)("所属事業所コード") & "'" '所属事業所コード
                '                       strSQL &= ", " & dtPrintID.Rows(i)("印刷ID") '印刷ID
                '                       strSQL &= ", " & j + 1 'ページ数(事業所内の連番)
                '                       strSQL &= ", " & dtCheckupList.Rows(j)("レコード番号")    'レコード番号
                '                       strSQL &= ", '" & dtCheckupList.Rows(j)("システムID") & "'"    'システムID
                '                       strSQL &= ", 4" '帳票種別ID(4＝判定票)
                '                       strSQL &= ", 1" '帳票種別詳細
                '                       strSQL &= ", ''"    '分数(NULL)
                '                       'QRコードの算出(システムID(15)＋帳票種別ID(1)＋エラーフラグ(1))
                '                       strQRCodeWithoutCD = dtCheckupList.Rows(j)("システムID") & "4" & iErrorFlag.ToString
                '                       strCD = ""
                '                       blnResult = Modulus10(strQRCodeWithoutCD, 4, strCD)
                '                       strQRCode = strQRCodeWithoutCD & strCD
                '                       strSQL &= ", '" & strQRCode & "'"
                '                       strSQL &= ", 0, 0, 0)" '枚数、シーケンス、チェックフラグは0固定
                '                       sqlProcess.DB_UPDATE(strSQL)

                '                   Next j
                '                   '==================================================
                '                   'リーフレット
                '                   'ここではT_印刷ソートにのみINSERT
                '                   '==================================================
                '                   'システムID単位のレコードを取得し、システムID内でのページ数も取得する
                '                   strSQL = "SELECT T1.ロットID, T1.レコード番号, T3.判定票CSV, T3.リーフレットCSV, "
                '                   strSQL &= "ISNULL(要修正日時, '1900/01/01') AS 要修正日時, ISNULL(修正済日時, '1900/01/01') AS 修正済日時 "
                '                   strSQL &= "FROM T_判定票 AS T1 INNER JOIN "
                '                   strSQL &= "T_リーフレット AS T2 ON T1.ロットID = T2.ロットID AND T1.レコード番号 = T2.レコード番号 INNER JOIN "
                '                   strSQL &= "T_判定票管理 AS T3 ON T1.ロットID = T3.ロットID AND T1.レコード番号 = T3.レコード番号 INNER JOIN  "
                '                   strSQL &= "T_複数封筒計算 AS T4 ON T1.ロットID = T4.ロットID AND T1.レコード番号 = T4.レコード番号 "
                '                   strSQL &= "WHERE T1.ロットID = '" & strLotID & "' "
                '                   strSQL &= "AND T1.会社コード = '" & dtOffice.Rows(iRow)("会社コード") & "' "
                '                   strSQL &= "AND T1.所属事業所コード = '" & dtOffice.Rows(iRow)("所属事業所コード") & "' "
                '                   strSQL &= "AND T3.リーフレット無効 != 1 "   'リーフレット無効が立っていたら出力しない
                '                   strSQL &= "AND T4.印刷ID = " & dtPrintID.Rows(i)("印刷ID") & " "
                '                   strSQL &= "ORDER BY CASE WHEN ISNULL(T1.所属部名, '') = '' THEN 1 ELSE 0 END, "
                '                   strSQL &= "T1.所属部名, "
                '                   strSQL &= "CASE WHEN ISNULL(T1.所属課名, '') = '' THEN 1 ELSE 0 END, "
                '                   strSQL &= "T1.所属課名, T1.社員コード"
                '                   Dim dtLeaf As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
                '                   For k As Integer = 0 To dtLeaf.Rows.Count - 1
                '                       'システムID単位で回す
                '                       strSQL = "SELECT ロットID, 会社コード, 所属事業所コード, レコード番号, システムID "
                '                       strSQL &= "FROM T_リーフレット "
                '                       strSQL &= "WHERE ロットID = '" & strLotID & "' "
                '                       strSQL &= "AND レコード番号 = " & dtLeaf.Rows(k)("レコード番号")
                '                       Dim dtLeafSystemID As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
                '                       For j As Integer = 0 To dtLeafSystemID.Rows.Count - 1
                '                           '==================================================
                '                           '2017/07/01
                '                           '※同一システムIDで複数のリーフレットが存在した場合はT_印刷ソートテーブルには上位1レコードしかINSERTさせない
                '                           '==================================================
                '                           '要修正日時に日付が入っていて、修正済日時に日付が入っていないものはエラーフラグ＝1としてQRコードにセットする
                '                           'それ以外はエラーフラグ＝0
                '                           Dim iErrorFlag As Integer = 0
                '                           If dtLeaf.Rows(k)("要修正日時") <> "1900/01/01" And dtLeaf.Rows(k)("修正済日時") = "1900/01/01" Then
                '                               '要修正日時に日付が入っていて、修正済日時に日付が入っていない場合は、エラーが解消されていない
                '                               '更に「T_判定票_不備内容」のCSVファイル項目にリーフレットのCSVファイル名があるか調べて1件でも存在すればエラーフラグを立てる
                '                               strSQL = "SELECT COUNT(*) FROM T_判定票_不備内容 "
                '                               strSQL &= "WHERE ロットID = '" & strLotID & "' "
                '                               strSQL &= "AND レコード番号 = " & dtLeaf.Rows(k)("レコード番号") & " "
                '                               strSQL &= "AND CSVファイル = '" & dtLeaf.Rows(k)("リーフレットCSV") & "'"
                '                               If sqlProcess.DB_EXECUTE_SCALAR(strSQL) > 0 Then
                '                                   '不備内容にレコードがあった
                '                                   iErrorFlag = 1
                '                               Else
                '                                   iErrorFlag = 0
                '                               End If

                '                           Else
                '                               iErrorFlag = 0
                '                           End If
                '                           '==================================================
                '                           '枚数とシーケンスを取得しながらINSERTする
                '                           '==================================================
                '                           strSQL = "SELECT COUNT(*) FROM T_印刷ソート "
                '                           strSQL &= "WHERE ロットID = '" & strLotID & "' "
                '                           strSQL &= "AND 会社コード = '" & dtLeafSystemID.Rows(j)("会社コード") & "' "
                '                           strSQL &= "AND 所属事業所コード = '" & dtLeafSystemID.Rows(j)("所属事業所コード") & "' "
                '                           strSQL &= "AND 印刷ID = " & dtPrintID.Rows(i)("印刷ID") & " "
                '                           strSQL &= "AND ページ数 = 0 "
                '                           strSQL &= "AND レコード番号 = " & dtLeafSystemID.Rows(j)("レコード番号") & " "
                '                           strSQL &= "AND 帳票種別ID = 5"
                '                           If sqlProcess.DB_EXECUTE_SCALAR(strSQL) = 0 Then
                '                               '存在していなかったらINSERT
                '                               strSQL = "INSERT INTO T_印刷ソート (ロットID, 会社コード, 所属事業所コード, 印刷ID, ページ数, レコード番号, システムID, "
                '                               strSQL &= "帳票種別ID, 帳票種別詳細, 分数, QR, 枚数, シーケンス, チェックフラグ) VALUES("
                '                               strSQL &= "'" & strLotID & "'"  'ロットID
                '                               strSQL &= ", '" & dtLeafSystemID.Rows(j)("会社コード") & "'" '会社コード
                '                               strSQL &= ", '" & dtLeafSystemID.Rows(j)("所属事業所コード") & "'"  '所属事業所コード
                '                               strSQL &= ", " & dtPrintID.Rows(i)("印刷ID") '印刷ID
                '                               strSQL &= ", 0" 'ページ数(0固定)
                '                               strSQL &= ", " & dtLeafSystemID.Rows(j)("レコード番号")   'レコード番号
                '                               strSQL &= ", '" & dtLeafSystemID.Rows(j)("システムID") & "'"    'システムID
                '                               strSQL &= ", 5" '帳票種別ID(5＝リーフレット)
                '                               strSQL &= ", 1"  '帳票種別詳細(1～6まで)
                '                               strSQL &= ", ''"    '分数(NULL)
                '                               'QRコードの算出(システムID(15)＋帳票種別ID(1)＋エラーフラグ(1))
                '                               strQRCodeWithoutCD = dtLeafSystemID.Rows(j)("システムID") & "5" & iErrorFlag.ToString & "1" 'カレントSEQの「1」を追加※印刷ソートは1固定
                '                               strCD = ""
                '                               blnResult = Modulus10(strQRCodeWithoutCD, 5, strCD)
                '                               strQRCode = strQRCodeWithoutCD & strCD
                '                               strSQL &= ", '" & strQRCode & "'"
                '                               strSQL &= ", " & dtLeafSystemID.Rows.Count  '枚数
                '                               strSQL &= ", 0"  'シーケンス
                '                               strSQL &= ", 0)"    'チェックフラグ
                '                               sqlProcess.DB_UPDATE(strSQL)
                '                           End If

                '                       Next j

                '                   Next k

                '               Next i

                'End If

#End Region

                '事業所単位でT_判定票印刷、T_リーフレット印刷にINSERTする
                '==================================================
                '判定票印刷
                '==================================================
                WriteLstResult(lstResult, "判定票印刷へのINSERT開始")
                strSQL = "SELECT T1.ロットID, T1.レコード番号, T1.システムID, T1.氏名セイ + ' ' + T1.氏名メイ AS 氏名カナ, T1.氏名姓 + ' ' + T1.氏名名 AS 氏名, "
                strSQL &= "T2.受診年齢, T1.会社, T1.所属事業所, T1.所属部名, T1.所属課名, T1.役職名, T1.性別, T1.採用年月日, T1.生年月日, T3.変換健診種別 AS 健診種別, T1.受診日, "
                strSQL &= "T1.身長, T1.体重, T1.体重上限, T1.体重下限, T1.BMI, T1.BMI上限, T1.BMI下限, T1.腹囲, T1.腹囲上限, T1.腹囲下限, T1.視力裸眼右, T1.視力裸眼左, "
                strSQL &= "T1.視力矯正右, T1.視力矯正左, T1.聴力右1000, T1.聴力右4000, T1.聴力左1000, T1.聴力左4000, T1.聴力その他, T1.血圧1回収縮期, T1.血圧1回収縮期上限, "
                strSQL &= "T1.血圧1回収縮期下限, T1.血圧1回拡張期, T1.血圧1回拡張期上限, T1.血圧1回拡張期下限, T1.尿糖定性, T1.尿蛋白定性, T1.総コレステロール, "
                strSQL &= "T1.総コレステロール上限, T1.総コレステロール下限, T1.HDLコレステロール, T1.HDLコレステロール上限, T1.HDLコレステロール下限, "
                strSQL &= "T1.中性脂肪, T1.中性脂肪上限, T1.中性脂肪下限, T1.LDLコレステロール, T1.LDLコレステロール上限, T1.LDLコレステロール下限, "
                strSQL &= "T1.GOT, T1.GOT上限, T1.GOT下限, T1.GPT, T1.GPT上限, T1.GPT下限, T1.ガンマGTP, T1.ガンマGTP上限, T1.ガンマGTP下限, "
                strSQL &= "T1.クレアチニン, T1.クレアチニン上限, T1.クレアチニン下限, T1.尿酸, T1.尿酸上限, T1.尿酸下限, T1.赤血球, T1.赤血球上限, T1.赤血球下限, "
                strSQL &= "T1.血色素量, T1.血色素量上限, T1.血色素量下限, T1.空腹時血糖, T1.空腹時血糖上限, T1.空腹時血糖下限, T1.随時血糖, T1.随時血糖上限, T1.随時血糖下限, "
                strSQL &= "T1.HbA1c, T1.HbA1c上限, T1.HbA1c下限, 受診検査機関名称, T1.会場局名称, T1.総合判定, 健診実施医師名, T1.判定医師名, T1.判定日付, "
                strSQL &= "T1.視力判定, T1.聴力判定, T1.血圧判定, T1.尿糖判定, T1.尿蛋白判定, T1.血中脂質判定, T1.肝機能判定, T1.腎機能判定, T1.尿酸判定, T1.血液判定, "
                strSQL &= "T1.血糖判定, T1.胸部X線判定結果, T1.心電図判定結果, T1.総合成績判定, T1.就業区分, T1.胸部X線所見, T1.胸部X線判定, T1.心電図所見, T1.心電図判定, "
                strSQL &= "T1.既往歴, T1.自覚症状, T1.診察所見, T1.総合コメント, T1.産業医の意見, "
                strSQL &= "T2.判定票CSV, T2.リーフレットCSV, ISNULL(T2.要修正日時, '1900/01/01') AS 要修正日時, ISNULL(T2.修正済日時, '1900/01/01') AS 修正済日時 "
                strSQL &= "FROM T_判定票 AS T1 INNER JOIN "
                strSQL &= "T_判定票管理 AS T2 ON T1.ロットID = T2.ロットID AND T1.レコード番号 = T2.レコード番号 INNER JOIN "
                strSQL &= "M_健診種別 AS T3 ON T1.健診種別 = T3.健診種別 "
                strSQL &= "WHERE T1.ロットID = '" & strLotID & "'"
                strSQL &= "AND T1.会社コード = '" & dtOffice.Rows(iRow)("会社コード") & "'"
                strSQL &= "AND T1.所属事業所コード = '" & dtOffice.Rows(iRow)("所属事業所コード") & "' "
                strSQL &= "ORDER BY CASE WHEN ISNULL(T1.所属部名, '') = '' THEN 1 ELSE 0 END, "
                strSQL &= "T1.所属部名, "
                strSQL &= "CASE WHEN ISNULL(T1.所属課名, '') = '' THEN 1 ELSE 0 END, "
                strSQL &= "T1.所属課名, T1.社員コード"
                Dim dtCheckupPrint As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)

                For i As Integer = 0 To dtCheckupPrint.Rows.Count - 1

                    '==================================================
                    '要修正日時に日付が入っていて、修正済日時に日付が入っていないものはエラーフラグ＝1としてQRコードにセットする
                    'それ以外はエラーフラグ＝0
                    Dim iErrorFlag As Integer = 0
                    If dtCheckupPrint.Rows(i)("要修正日時") <> "1900/01/01" And dtCheckupPrint.Rows(i)("修正済日時") = "1900/01/01" Then
                        '要修正日時に日付が入っていて、修正済日時に日付が入っていない場合は、エラーが解消されていない
                        '更に「T_判定票_不備内容」のCSVファイル項目にリーフレットのCSVファイル名があるか調べて1件でも存在すればエラーフラグを立てる
                        strSQL = "SELECT COUNT(*) FROM T_判定票_不備内容 "
                        strSQL &= "WHERE ロットID = '" & strLotID & "' "
                        strSQL &= "AND レコード番号 = " & dtCheckupPrint.Rows(i)("レコード番号") & " "
                        strSQL &= "AND CSVファイル = '" & dtCheckupPrint.Rows(i)("判定票CSV") & "'"
                        If sqlProcess.DB_EXECUTE_SCALAR(strSQL) > 0 Then
                            '不備内容にレコードがあった
                            iErrorFlag = 1
                        Else
                            iErrorFlag = 0
                        End If

                    Else
                        iErrorFlag = 0
                    End If
                    '==================================================

                    '==================================================
                    '各項目を成形しながらT_判定票印刷にINSERTしていく
                    '2017/07/19 すべての項目に対してシングルクォート「'」を「''」に変換する
                    strSQL = "INSERT INTO T_判定票印刷 (ロットID, レコード番号, システムID, 氏名カナ, 氏名, 受診年齢, 会社, 所属事業所, 所属部名, 所属課名, 役職名, 性別, 採用年月日, "
                    strSQL &= "生年月日, 健診種別, 受診日, 身長, 体重, 体重記号, 体重上限, 体重下限, BMI, BMI記号, BMI上限, BMI下限, 腹囲, 腹囲記号, 腹囲上限, 腹囲下限, "
                    strSQL &= "視力裸眼右, 視力裸眼左, 視力矯正右, 視力矯正左, 聴力右1000, 聴力右4000, 聴力左1000, 聴力左4000, 聴力その他, 血圧1回収縮期, 血圧1回収縮期記号, "
                    strSQL &= "血圧1回収縮期上限, 血圧1回収縮期下限, 血圧1回拡張期, 血圧1回拡張期記号, 血圧1回拡張期上限, 血圧1回拡張期下限, 尿糖定性, 尿蛋白定性, "
                    strSQL &= "総コレステロール, 総コレステロール記号, 総コレステロール上限, 総コレステロール下限, HDLコレステロール, HDLコレステロール記号, HDLコレステロール上限, "
                    strSQL &= "HDLコレステロール下限, 中性脂肪, 中性脂肪記号, 中性脂肪上限, 中性脂肪下限, LDLコレステロール, LDLコレステロール記号, LDLコレステロール上限, "
                    strSQL &= "LDLコレステロール下限, GOT, GOT記号, GOT上限, GOT下限, GPT, GPT記号, GPT上限, GPT下限, ガンマGTP, ガンマGTP記号, ガンマGTP上限, ガンマGTP下限, "
                    strSQL &= "クレアチニン, クレアチニン記号, クレアチニン上限, クレアチニン下限, 尿酸, 尿酸記号, 尿酸上限, 尿酸下限, 赤血球, 赤血球記号, 赤血球上限, 赤血球下限, "
                    strSQL &= "血色素量, 血色素量記号, 血色素量上限, 血色素量下限, 空腹時血糖, 空腹時血糖記号, 空腹時血糖上限, 空腹時血糖下限, 随時血糖, 随時血糖記号, 随時血糖上限, "
                    strSQL &= "随時血糖下限, HbA1c, HbA1c記号, HbA1c上限, HbA1c下限, 受診検査機関名称, 会場局名称, 総合判定, 健診実施医師名, 判定医師名, 判定日付, "
                    strSQL &= "視力判定, 聴力判定, 血圧判定, 尿糖判定, 尿蛋白判定, 血中脂質判定, 肝機能判定, 腎機能判定, 尿酸判定, 血液判定, 血糖判定, 胸部X線判定結果, 心電図判定結果, "
                    strSQL &= "総合成績判定, 就業区分, 胸部X線所見, 胸部X線判定, 心電図所見, 心電図判定, 既往歴, 自覚症状, 診察所見, 総合コメント, 産業医の意見, QRコード) VALUES("
                    strSQL &= "'" & strLotID & "'"  'ロットID
                    strSQL &= ", " & dtCheckupPrint.Rows(i)("レコード番号").ToString.Replace("'", "''")  'レコード番号
                    strSQL &= ", '" & dtCheckupPrint.Rows(i)("システムID").ToString.Replace("'", "''") & "'"    'システムID
                    strSQL &= ", '" & VisualBasic.Japanese.Kanaxs.Kana.ToHankakuKana(dtCheckupPrint.Rows(i)("氏名カナ")).ToString.Replace("'", "''") & "'"    '氏名カナ、半角カナに変換
                    strSQL &= ", '" & dtCheckupPrint.Rows(i)("氏名").ToString.Replace("'", "''") & "'"    '氏名
                    strSQL &= ", '" & dtCheckupPrint.Rows(i)("受診年齢").ToString.Replace("'", "''") & "歳'"
                    strSQL &= ", '" & dtCheckupPrint.Rows(i)("会社").ToString.Replace("'", "''") & "'"
                    strSQL &= ", '" & dtCheckupPrint.Rows(i)("所属事業所").ToString.Replace("'", "''") & "'"
                    strSQL &= ", '" & dtCheckupPrint.Rows(i)("所属部名").ToString.Replace("'", "''") & "'"
                    strSQL &= ", '" & dtCheckupPrint.Rows(i)("所属課名").ToString.Replace("'", "''") & "'"
                    strSQL &= ", '" & dtCheckupPrint.Rows(i)("役職名").ToString.Replace("'", "''") & "'"
                    strSQL &= ", '" & dtCheckupPrint.Rows(i)("性別").ToString.Replace("'", "''") & "'"
                    strSQL &= ", '" & dtCheckupPrint.Rows(i)("採用年月日").ToString.Replace("'", "''") & "'"
                    strSQL &= ", '" & dtCheckupPrint.Rows(i)("生年月日").ToString.Replace("'", "''") & "'"
                    strSQL &= ", '" & dtCheckupPrint.Rows(i)("健診種別").ToString.Replace("'", "''") & "'"
                    strSQL &= ", '" & dtCheckupPrint.Rows(i)("受診日").ToString.Replace("'", "''") & "'"
                    strSQL &= ", '" & PeriodCheck(dtCheckupPrint.Rows(i)("身長"), 1) & "'"
                    '==================================================
                    '体重
                    '==================================================
                    strSQL &= ", '" & PeriodCheck(dtCheckupPrint.Rows(i)("体重"), 1) & "'"
                    strSQL &= ", '" & WhichUpDown(dtCheckupPrint.Rows(i)("体重"), dtCheckupPrint.Rows(i)("体重上限"), dtCheckupPrint.Rows(i)("体重下限")) & "'"
                    strSQL &= ", '" & PeriodCheck(dtCheckupPrint.Rows(i)("体重上限"), 1) & "'"
                    strSQL &= ", '" & PeriodCheck(dtCheckupPrint.Rows(i)("体重下限"), 1) & "'"
                    '==================================================
                    'BMI
                    '==================================================
                    strSQL &= ", '" & PeriodCheck(dtCheckupPrint.Rows(i)("BMI"), 1) & "'"
                    strSQL &= ", '" & WhichUpDown(dtCheckupPrint.Rows(i)("BMI"), dtCheckupPrint.Rows(i)("BMI上限"), dtCheckupPrint.Rows(i)("BMI下限")) & "'"
                    strSQL &= ", '" & PeriodCheck(dtCheckupPrint.Rows(i)("BMI上限"), 1) & "'"
                    strSQL &= ", '" & PeriodCheck(dtCheckupPrint.Rows(i)("BMI下限"), 1) & "'"
                    '==================================================
                    '腹囲
                    '==================================================
                    strSQL &= ", '" & PeriodCheck(dtCheckupPrint.Rows(i)("腹囲"), 1) & "'"
                    strSQL &= ", '" & WhichUpDown(dtCheckupPrint.Rows(i)("腹囲"), dtCheckupPrint.Rows(i)("腹囲上限"), dtCheckupPrint.Rows(i)("腹囲下限")) & "'"
                    strSQL &= ", '" & PeriodCheck(dtCheckupPrint.Rows(i)("腹囲上限"), 1) & "'"
                    strSQL &= ", '" & PeriodCheck(dtCheckupPrint.Rows(i)("腹囲下限"), 1) & "'"
                    '==================================================
                    '視力
                    '==================================================
                    strSQL &= ", '" & PeriodCheck(dtCheckupPrint.Rows(i)("視力裸眼右"), 1) & "'"
                    strSQL &= ", '" & PeriodCheck(dtCheckupPrint.Rows(i)("視力裸眼左"), 1) & "'"
                    strSQL &= ", '" & PeriodCheck(dtCheckupPrint.Rows(i)("視力矯正右"), 1) & "'"
                    strSQL &= ", '" & PeriodCheck(dtCheckupPrint.Rows(i)("視力矯正左"), 1) & "'"
                    '==================================================
                    '聴力
                    '==================================================
                    strSQL &= ", '" & dtCheckupPrint.Rows(i)("聴力右1000") & "'"
                    strSQL &= ", '" & dtCheckupPrint.Rows(i)("聴力右4000") & "'"
                    strSQL &= ", '" & dtCheckupPrint.Rows(i)("聴力左1000") & "'"
                    strSQL &= ", '" & dtCheckupPrint.Rows(i)("聴力左4000") & "'"
                    strSQL &= ", '" & dtCheckupPrint.Rows(i)("聴力その他") & "'"
                    '==================================================
                    '血圧
                    '==================================================
                    strSQL &= ", '" & dtCheckupPrint.Rows(i)("血圧1回収縮期") & "'"
                    strSQL &= ", '" & WhichUpDown(dtCheckupPrint.Rows(i)("血圧1回収縮期"), dtCheckupPrint.Rows(i)("血圧1回収縮期上限"), dtCheckupPrint.Rows(i)("血圧1回収縮期下限")) & "'"
                    strSQL &= ", '" & dtCheckupPrint.Rows(i)("血圧1回収縮期上限") & "'"
                    strSQL &= ", '" & dtCheckupPrint.Rows(i)("血圧1回収縮期下限") & "'"

                    strSQL &= ", '" & dtCheckupPrint.Rows(i)("血圧1回拡張期") & "'"
                    strSQL &= ", '" & WhichUpDown(dtCheckupPrint.Rows(i)("血圧1回拡張期"), dtCheckupPrint.Rows(i)("血圧1回拡張期上限"), dtCheckupPrint.Rows(i)("血圧1回拡張期下限")) & "'"
                    strSQL &= ", '" & dtCheckupPrint.Rows(i)("血圧1回拡張期上限") & "'"
                    strSQL &= ", '" & dtCheckupPrint.Rows(i)("血圧1回拡張期下限") & "'"
                    '==================================================
                    '尿
                    '==================================================
                    strSQL &= ", '" & dtCheckupPrint.Rows(i)("尿糖定性").ToString.Replace("'", "''") & "'"
                    strSQL &= ", '" & dtCheckupPrint.Rows(i)("尿蛋白定性").ToString.Replace("'", "''") & "'"
                    '==================================================
                    '総コレステロール
                    '==================================================
                    strSQL &= ", '" & dtCheckupPrint.Rows(i)("総コレステロール") & "'"
                    strSQL &= ", '" & WhichUpDown(dtCheckupPrint.Rows(i)("総コレステロール"), dtCheckupPrint.Rows(i)("総コレステロール上限"), dtCheckupPrint.Rows(i)("総コレステロール下限")) & "'"
                    strSQL &= ", '" & dtCheckupPrint.Rows(i)("総コレステロール上限") & "'"
                    strSQL &= ", '" & dtCheckupPrint.Rows(i)("総コレステロール下限") & "'"
                    '==================================================
                    'HDLコレステロール
                    '==================================================
                    strSQL &= ", '" & dtCheckupPrint.Rows(i)("HDLコレステロール") & "'"
                    strSQL &= ", '" & WhichUpDown(dtCheckupPrint.Rows(i)("HDLコレステロール"), dtCheckupPrint.Rows(i)("HDLコレステロール上限"), dtCheckupPrint.Rows(i)("HDLコレステロール下限")) & "'"
                    strSQL &= ", '" & dtCheckupPrint.Rows(i)("HDLコレステロール上限") & "'"
                    strSQL &= ", '" & dtCheckupPrint.Rows(i)("HDLコレステロール下限") & "'"
                    '==================================================
                    '中性脂肪
                    '==================================================
                    strSQL &= ", '" & dtCheckupPrint.Rows(i)("中性脂肪") & "'"
                    strSQL &= ", '" & WhichUpDown(dtCheckupPrint.Rows(i)("中性脂肪"), dtCheckupPrint.Rows(i)("中性脂肪上限"), dtCheckupPrint.Rows(i)("中性脂肪下限")) & "'"
                    strSQL &= ", '" & dtCheckupPrint.Rows(i)("中性脂肪上限") & "'"
                    strSQL &= ", '" & dtCheckupPrint.Rows(i)("中性脂肪下限") & "'"
                    '==================================================
                    'LDLコレステロール
                    '==================================================
                    strSQL &= ", '" & dtCheckupPrint.Rows(i)("LDLコレステロール") & "'"
                    strSQL &= ", '" & WhichUpDown(dtCheckupPrint.Rows(i)("LDLコレステロール"), dtCheckupPrint.Rows(i)("LDLコレステロール上限"), dtCheckupPrint.Rows(i)("LDLコレステロール下限")) & "'"
                    strSQL &= ", '" & dtCheckupPrint.Rows(i)("LDLコレステロール上限") & "'"
                    strSQL &= ", '" & dtCheckupPrint.Rows(i)("LDLコレステロール下限") & "'"
                    '==================================================
                    'GOT
                    '==================================================
                    strSQL &= ", '" & dtCheckupPrint.Rows(i)("GOT") & "'"
                    strSQL &= ", '" & WhichUpDown(dtCheckupPrint.Rows(i)("GOT"), dtCheckupPrint.Rows(i)("GOT上限"), dtCheckupPrint.Rows(i)("GOT下限")) & "'"
                    strSQL &= ", '" & dtCheckupPrint.Rows(i)("GOT上限") & "'"
                    strSQL &= ", '" & dtCheckupPrint.Rows(i)("GOT下限") & "'"
                    '==================================================
                    'GPT
                    '==================================================
                    strSQL &= ", '" & dtCheckupPrint.Rows(i)("GPT") & "'"
                    strSQL &= ", '" & WhichUpDown(dtCheckupPrint.Rows(i)("GPT"), dtCheckupPrint.Rows(i)("GPT上限"), dtCheckupPrint.Rows(i)("GPT下限")) & "'"
                    strSQL &= ", '" & dtCheckupPrint.Rows(i)("GPT上限") & "'"
                    strSQL &= ", '" & dtCheckupPrint.Rows(i)("GPT下限") & "'"
                    '==================================================
                    'ガンマGTP
                    '==================================================
                    strSQL &= ", '" & dtCheckupPrint.Rows(i)("ガンマGTP") & "'"
                    strSQL &= ", '" & WhichUpDown(dtCheckupPrint.Rows(i)("ガンマGTP"), dtCheckupPrint.Rows(i)("ガンマGTP上限"), dtCheckupPrint.Rows(i)("ガンマGTP下限")) & "'"
                    strSQL &= ", '" & dtCheckupPrint.Rows(i)("ガンマGTP上限") & "'"
                    strSQL &= ", '" & dtCheckupPrint.Rows(i)("ガンマGTP下限") & "'"
                    '==================================================
                    'クレアチニン
                    '==================================================
                    strSQL &= ", '" & PeriodCheck(dtCheckupPrint.Rows(i)("クレアチニン"), 2) & "'"
                    strSQL &= ", '" & WhichUpDown(dtCheckupPrint.Rows(i)("クレアチニン"), dtCheckupPrint.Rows(i)("クレアチニン上限"), dtCheckupPrint.Rows(i)("クレアチニン下限")) & "'"
                    strSQL &= ", '" & PeriodCheck(dtCheckupPrint.Rows(i)("クレアチニン上限"), 2) & "'"
                    strSQL &= ", '" & PeriodCheck(dtCheckupPrint.Rows(i)("クレアチニン下限"), 2) & "'"
                    '==================================================
                    '尿酸
                    '==================================================
                    strSQL &= ", '" & PeriodCheck(dtCheckupPrint.Rows(i)("尿酸"), 1) & "'"
                    strSQL &= ", '" & WhichUpDown(dtCheckupPrint.Rows(i)("尿酸"), dtCheckupPrint.Rows(i)("尿酸上限"), dtCheckupPrint.Rows(i)("尿酸下限")) & "'"
                    strSQL &= ", '" & PeriodCheck(dtCheckupPrint.Rows(i)("尿酸上限"), 1) & "'"
                    strSQL &= ", '" & PeriodCheck(dtCheckupPrint.Rows(i)("尿酸下限"), 1) & "'"
                    '==================================================
                    '赤血球
                    '==================================================
                    strSQL &= ", '" & dtCheckupPrint.Rows(i)("赤血球") & "'"
                    strSQL &= ", '" & WhichUpDown(dtCheckupPrint.Rows(i)("赤血球"), dtCheckupPrint.Rows(i)("赤血球上限"), dtCheckupPrint.Rows(i)("赤血球下限")) & "'"
                    strSQL &= ", '" & dtCheckupPrint.Rows(i)("赤血球上限") & "'"
                    strSQL &= ", '" & dtCheckupPrint.Rows(i)("赤血球下限") & "'"
                    '==================================================
                    '血色素量
                    '==================================================
                    strSQL &= ", '" & PeriodCheck(dtCheckupPrint.Rows(i)("血色素量"), 1) & "'"
                    strSQL &= ", '" & WhichUpDown(dtCheckupPrint.Rows(i)("血色素量"), dtCheckupPrint.Rows(i)("血色素量上限"), dtCheckupPrint.Rows(i)("血色素量下限")) & "'"
                    strSQL &= ", '" & PeriodCheck(dtCheckupPrint.Rows(i)("血色素量上限"), 1) & "'"
                    strSQL &= ", '" & PeriodCheck(dtCheckupPrint.Rows(i)("血色素量下限"), 1) & "'"
                    '==================================================
                    '空腹時血糖
                    '==================================================
                    strSQL &= ", '" & dtCheckupPrint.Rows(i)("空腹時血糖") & "'"
                    strSQL &= ", '" & WhichUpDown(dtCheckupPrint.Rows(i)("空腹時血糖"), dtCheckupPrint.Rows(i)("空腹時血糖上限"), dtCheckupPrint.Rows(i)("空腹時血糖下限")) & "'"
                    strSQL &= ", '" & dtCheckupPrint.Rows(i)("空腹時血糖上限") & "'"
                    strSQL &= ", '" & dtCheckupPrint.Rows(i)("空腹時血糖下限") & "'"
                    '==================================================
                    '随時血糖
                    '==================================================
                    strSQL &= ", '" & dtCheckupPrint.Rows(i)("随時血糖") & "'"
                    strSQL &= ", '" & WhichUpDown(dtCheckupPrint.Rows(i)("随時血糖"), dtCheckupPrint.Rows(i)("随時血糖上限"), dtCheckupPrint.Rows(i)("随時血糖下限")) & "'"
                    strSQL &= ", '" & dtCheckupPrint.Rows(i)("随時血糖上限") & "'"
                    strSQL &= ", '" & dtCheckupPrint.Rows(i)("随時血糖下限") & "'"
                    '==================================================
                    'HbA1c
                    '==================================================
                    strSQL &= ", '" & PeriodCheck(dtCheckupPrint.Rows(i)("HbA1c"), 1) & "'"
                    strSQL &= ", '" & WhichUpDown(dtCheckupPrint.Rows(i)("HbA1c"), dtCheckupPrint.Rows(i)("HbA1c上限"), dtCheckupPrint.Rows(i)("HbA1c下限")) & "'"
                    strSQL &= ", '" & PeriodCheck(dtCheckupPrint.Rows(i)("HbA1c上限"), 1) & "'"
                    strSQL &= ", '" & PeriodCheck(dtCheckupPrint.Rows(i)("HbA1c下限"), 1) & "'"
                    '==================================================
                    'その他
                    '==================================================
                    strSQL &= ", '" & dtCheckupPrint.Rows(i)("受診検査機関名称") & "'"
                    '会場局名称(「人間ドック省略」の場合は「他の健診機関の結果利用による省略」をセット)
                    If dtCheckupPrint.Rows(i)("会場局名称") = "人間ドック省略" Then
                        strSQL &= ", '他の健診機関の結果利用による省略'"
                    Else
                        strSQL &= ", '" & dtCheckupPrint.Rows(i)("会場局名称").ToString.Replace("'", "''") & "'"
                    End If
                    strSQL &= ", '" & dtCheckupPrint.Rows(i)("総合判定").ToString.Replace("'", "''") & "'"
                    strSQL &= ", '" & dtCheckupPrint.Rows(i)("健診実施医師名").ToString.Replace("'", "''") & "'"
                    strSQL &= ", '" & dtCheckupPrint.Rows(i)("判定医師名").ToString.Replace("'", "''") & "'"
                    '判定日付(yyyyMMddをyyyy/MM/ddに変換してセットする)
                    strSQL &= ", '" & Date.Parse(Format(CInt(dtCheckupPrint.Rows(i)("判定日付")), "0000/00/00")) & "'"
                    '==================================================
                    '判定(値が「未実施（不要）」の場合は空欄にする
                    '==================================================
                    strSQL &= ", '" & IIf(dtCheckupPrint.Rows(i)("視力判定") = "未実施（不要）", "", dtCheckupPrint.Rows(i)("視力判定")).ToString.Replace("'", "''") & "'"
                    strSQL &= ", '" & IIf(dtCheckupPrint.Rows(i)("聴力判定") = "未実施（不要）", "", dtCheckupPrint.Rows(i)("聴力判定")).ToString.Replace("'", "''") & "'"
                    strSQL &= ", '" & IIf(dtCheckupPrint.Rows(i)("血圧判定") = "未実施（不要）", "", dtCheckupPrint.Rows(i)("血圧判定")).ToString.Replace("'", "''") & "'"
                    strSQL &= ", '" & IIf(dtCheckupPrint.Rows(i)("尿糖判定") = "未実施（不要）", "", dtCheckupPrint.Rows(i)("尿糖判定")).ToString.Replace("'", "''") & "'"
                    strSQL &= ", '" & IIf(dtCheckupPrint.Rows(i)("尿蛋白判定") = "未実施（不要）", "", dtCheckupPrint.Rows(i)("尿蛋白判定")).ToString.Replace("'", "''") & "'"
                    strSQL &= ", '" & IIf(dtCheckupPrint.Rows(i)("血中脂質判定") = "未実施（不要）", "", dtCheckupPrint.Rows(i)("血中脂質判定")).ToString.Replace("'", "''") & "'"
                    strSQL &= ", '" & IIf(dtCheckupPrint.Rows(i)("肝機能判定") = "未実施（不要）", "", dtCheckupPrint.Rows(i)("肝機能判定")).ToString.Replace("'", "''") & "'"
                    strSQL &= ", '" & IIf(dtCheckupPrint.Rows(i)("腎機能判定") = "未実施（不要）", "", dtCheckupPrint.Rows(i)("腎機能判定")).ToString.Replace("'", "''") & "'"
                    strSQL &= ", '" & IIf(dtCheckupPrint.Rows(i)("尿酸判定") = "未実施（不要）", "", dtCheckupPrint.Rows(i)("尿酸判定")).ToString.Replace("'", "''") & "'"
                    strSQL &= ", '" & IIf(dtCheckupPrint.Rows(i)("血液判定") = "未実施（不要）", "", dtCheckupPrint.Rows(i)("血液判定")).ToString.Replace("'", "''") & "'"
                    strSQL &= ", '" & IIf(dtCheckupPrint.Rows(i)("血糖判定") = "未実施（不要）", "", dtCheckupPrint.Rows(i)("血糖判定")).ToString.Replace("'", "''") & "'"
                    strSQL &= ", '" & IIf(dtCheckupPrint.Rows(i)("胸部X線判定結果") = "未実施（不要）", "", dtCheckupPrint.Rows(i)("胸部X線判定結果")).ToString.Replace("'", "''") & "'"
                    strSQL &= ", '" & IIf(dtCheckupPrint.Rows(i)("心電図判定結果") = "未実施（不要）", "", dtCheckupPrint.Rows(i)("心電図判定結果")).ToString.Replace("'", "''") & "'"
                    strSQL &= ", '" & IIf(dtCheckupPrint.Rows(i)("総合成績判定") = "未実施（不要）", "", dtCheckupPrint.Rows(i)("総合成績判定")).ToString.Replace("'", "''") & "'"
                    '==================================================
                    'その他
                    '==================================================
                    strSQL &= ", '" & dtCheckupPrint.Rows(i)("就業区分").ToString.Replace("'", "''") & "'"
                    '==================================================
                    '改行を生かす項目
                    '==================================================
                    strSQL &= ", '" & dtCheckupPrint.Rows(i)("胸部X線所見").ToString.Replace("\n", vbNewLine).Replace("'", "''") & "'"
                    strSQL &= ", '" & dtCheckupPrint.Rows(i)("胸部X線判定").ToString.Replace("\n", vbNewLine).Replace("'", "''") & "'"
                    strSQL &= ", '" & dtCheckupPrint.Rows(i)("心電図所見").ToString.Replace("\n", vbNewLine).Replace("'", "''") & "'"
                    strSQL &= ", '" & dtCheckupPrint.Rows(i)("心電図判定").ToString.Replace("\n", vbNewLine).Replace("'", "''") & "'"
                    strSQL &= ", '" & dtCheckupPrint.Rows(i)("既往歴").ToString.Replace("\n", vbNewLine).Replace("'", "''") & "'"
                    strSQL &= ", '" & dtCheckupPrint.Rows(i)("自覚症状").ToString.Replace("\n", vbNewLine).Replace("'", "''") & "'"
                    strSQL &= ", '" & dtCheckupPrint.Rows(i)("診察所見").ToString.Replace("\n", vbNewLine).Replace("'", "''") & "'"
                    strSQL &= ", '" & dtCheckupPrint.Rows(i)("総合コメント").ToString.Replace("\n", vbNewLine).Replace("'", "''") & "'"
                    strSQL &= ", '" & dtCheckupPrint.Rows(i)("産業医の意見").ToString.Replace("\n", vbNewLine).Replace("'", "''") & "'"
                    '==================================================
                    'その他
                    '==================================================
                    'QRコード
                    'QRコードの算出(システムID(15)＋帳票種別ID(1)＋エラーフラグ(1))
                    strQRCode = dtCheckupPrint.Rows(i)("システムID") & "4" & iErrorFlag.ToString   '←エラーフラグ付加
                    '2017/07/13
                    'チェックデジット付与を取りやめ
                    'strCD = ""
                    'blnResult = Modulus10(strQRCodeWithoutCD, 4, strCD)
                    'strQRCode = strQRCodeWithoutCD & strCD
                    strSQL &= ", '" & strQRCode & "'"

                    strSQL &= ")"
                    sqlProcess.DB_UPDATE(strSQL)

                Next i
                WriteLstResult(lstResult, "判定票印刷へのINSERT終了")

                '==================================================
                'リーフレット印刷
                '==================================================
                'システムID単位で枚数が異なるため、OMRを特定するためにシステムID単位での一覧を作成し
                'システムID内でループさせて枚数を特定する
                'リーフレット無効のものは除外する
                'If dtOffice.Rows(iRow)("会社コード") = "2001" And dtOffice.Rows(iRow)("所属事業所コード") = "970270" Then
                '	MessageBox.Show("ヒット")
                'End If
                WriteLstResult(lstResult, "リーフレット印刷へのINSERT開始")
                strSQL = "SELECT T1.システムID "
                strSQL &= "FROM T_リーフレット AS T1 LEFT OUTER JOIN "
                strSQL &= "T_判定票管理 AS T2 ON T1.ロットID = T2.ロットID "
                strSQL &= "WHERE T1.ロットID = '" & strLotID & "' "
                strSQL &= "AND T1.会社コード = '" & dtOffice.Rows(iRow)("会社コード") & "' "
                strSQL &= "AND T1.所属事業所コード = '" & dtOffice.Rows(iRow)("所属事業所コード") & "' "
                strSQL &= "AND T2.リーフレット無効 != 1 "
                strSQL &= "GROUP BY T1.システムID, T1.所属部名, T1.所属課名, T1.社員コード "
                strSQL &= "ORDER BY CASE WHEN ISNULL(T1.所属部名, '') = '' THEN 1 ELSE 0 END, "
                strSQL &= "T1.所属部名, "
                strSQL &= "CASE WHEN ISNULL(T1.所属課名, '') = '' THEN 1 ELSE 0 END, "
                strSQL &= "T1.所属課名, T1. 社員コード"
                Dim dtLeafletSystemID As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)

                For iSystemID As Integer = 0 To dtLeafletSystemID.Rows.Count - 1
                    'システムIDで回す
                    strSQL = "SELECT T1.ロットID, T1.レコード番号, T1.システムID, T1.会社, T1.所属事業所, "
                    strSQL &= "T1.所属部名 + '　' + T1.所属課名 AS 所属部課名, "
                    strSQL &= "T1.氏名姓 + ' ' + T1.氏名名 + '　様' AS 氏名, "
                    strSQL &= "T2.会社名 AS 局所会社名, T3.健康管理施設名, T3.郵便番号, T3.住所, T3.電話番号, "
                    strSQL &= "T4.年度, T1.帳票タイプ, T4.判定票CSV, T4.リーフレットCSV, "
                    strSQL &= "ISNULL(T4.要修正日時, '1900/01/01') AS 要修正日時, ISNULL(T4.修正済日時, '1900/01/01') AS 修正済日時 "
                    strSQL &= "FROM T_リーフレット AS T1 INNER JOIN "
                    strSQL &= "M_局所 AS T2 ON T1.会社コード = T2.会社コード AND T1.所属事業所コード = T2.局所コード INNER JOIN "
                    strSQL &= "M_健康管理施設 AS T3 ON T2.健康管理施設コード = T3.健康管理施設コード INNER JOIN "
                    strSQL &= "T_判定票管理 AS T4 ON T1.ロットID = T4.ロットID AND T1.レコード番号 = T4.レコード番号 INNER JOIN "
                    strSQL &= "M_帳票タイプ AS T5 ON T1.帳票タイプ = T5.帳票タイプ "
                    strSQL &= "WHERE T1.ロットID = '" & strLotID & "' "
                    strSQL &= "AND T1.システムID = '" & dtLeafletSystemID.Rows(iSystemID)("システムID") & "' "
                    strSQL &= "AND T4.リーフレット無効 != 1 "
                    strSQL &= "ORDER BY T5.ID"
                    Dim dtLeafletPrint As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)

                    'ここで初めてT_リーフレット印刷にINSERT
                    For i As Integer = 0 To dtLeafletPrint.Rows.Count - 1
                        ''リーフレットシーケンスが63だった場合0にリセット
                        'If iLeafletSeq = 63 Then
                        '    iLeafletSeq = 0
                        'Else
                        '    iLeafletSeq += 1
                        'End If

                        '==================================================
                        '要修正日時に日付が入っていて、修正済日時に日付が入っていないものはエラーフラグ＝1としてQRコードにセットする
                        'それ以外はエラーフラグ＝0
                        Dim iErrorFlag As Integer = 0
                        If dtLeafletPrint.Rows(i)("要修正日時") <> "1900/01/01" And dtLeafletPrint.Rows(i)("修正済日時") = "1900/01/01" Then
                            '要修正日時に日付が入っていて、修正済日時に日付が入っていない場合は、エラーが解消されていない
                            '更に「T_判定票_不備内容」のCSVファイル項目にリーフレットのCSVファイル名があるか調べて1件でも存在すればエラーフラグを立てる
                            strSQL = "SELECT COUNT(*) FROM T_判定票_不備内容 "
                            strSQL &= "WHERE ロットID = '" & strLotID & "' "
                            strSQL &= "AND レコード番号 = " & dtLeafletPrint.Rows(i)("レコード番号") & " "
                            strSQL &= "AND CSVファイル = '" & dtLeafletPrint.Rows(i)("リーフレットCSV") & "'"
                            If sqlProcess.DB_EXECUTE_SCALAR(strSQL) > 0 Then
                                '不備内容にレコードがあった
                                iErrorFlag = 1
                            Else
                                iErrorFlag = 0
                            End If

                        Else
                            iErrorFlag = 0
                        End If
                        '==================================================
                        '該当ロットIDの現在の印刷SEQのマックス値を取得して+1したものをINSERTする
                        strSQL = "SELECT ISNULL(MAX(印刷SEQ), 0) + 1 "
                        strSQL &= "FROM T_リーフレット印刷 "
                        strSQL &= "WHERE ロットID = '" & strLotID & "'"
                        Dim iPrintSeq As Integer = sqlProcess.DB_EXECUTE_SCALAR(strSQL)

                        strSQL = "INSERT INTO T_リーフレット印刷 (ロットID, レコード番号, 印刷SEQ, トータルSEQ, カレントSEQ, 先頭マーク, システムID, 会社, 所属事業所, 所属部課名, "
                        strSQL &= "氏名, 局所会社名, 健康管理施設名, 郵便番号, 住所, 電話番号, 年度, 帳票タイプ, 結果値1, 結果値2, 結果値3, "
                        strSQL &= "BOC, EOC, PAR, WAS1, WAS2, WAS3, WAS4, WAS5, WAS6, QRコード) VALUES("
                        strSQL &= "'" & strLotID & "'"
                        strSQL &= ", " & dtLeafletPrint.Rows(i)("レコード番号")
                        strSQL &= ", " & iPrintSeq  '印刷SEQ
                        strSQL &= ", " & dtLeafletPrint.Rows.Count 'トータルSEQ
                        strSQL &= ", " & i + 1  'カレントSEQ
                        '先頭マーク
                        If i + 1 = 1 Then
                            '先頭
                            strSQL &= ", '●'"
                        Else
                            strSQL &= ", ''"
                        End If

                        strSQL &= ", '" & dtLeafletPrint.Rows(i)("システムID") & "'"
                        '会社コードが「1005」「6001」の場合は、会社名は印刷しない
                        If dtOffice.Rows(iRow)("会社コード") = "1005" Or
                                    dtOffice.Rows(iRow)("会社コード") = "6001" Then
                            strSQL &= ", ''"
                        Else
                            strSQL &= ", '" & dtLeafletPrint.Rows(i)("会社") & "'"
                        End If
                        strSQL &= ", '" & dtLeafletPrint.Rows(i)("所属事業所").ToString.Replace("'", "''") & "'"
                        strSQL &= ", '" & dtLeafletPrint.Rows(i)("所属部課名").ToString.Trim().Replace("'", "''") & "'"  'どちらか一方がない場合があるのでスペースをトリミングする
                        strSQL &= ", '" & dtLeafletPrint.Rows(i)("氏名").ToString.Replace("'", "''") & "'"
                        strSQL &= ", '" & dtLeafletPrint.Rows(i)("局所会社名").ToString.Replace("'", "''") & "'"
                        strSQL &= ", '" & dtLeafletPrint.Rows(i)("健康管理施設名").ToString.Replace("'", "''") & "'"
                        strSQL &= ", '" & dtLeafletPrint.Rows(i)("郵便番号").ToString.Replace("'", "''") & "'"
                        strSQL &= ", '" & dtLeafletPrint.Rows(i)("住所").ToString.Replace("'", "''") & "'"
                        strSQL &= ", '" & dtLeafletPrint.Rows(i)("電話番号").ToString.Replace("'", "''") & "'"
                        strSQL &= ", '" & dtLeafletPrint.Rows(i)("年度").ToString.Replace("'", "''") & "'"
                        strSQL &= ", '" & dtLeafletPrint.Rows(i)("帳票タイプ").ToString.Replace("'", "''") & "'"
                        Dim strValue1 As String = ""
                        Dim strValue2 As String = ""
                        Dim strValue3 As String = ""
                        blnResult = GetResultValue(dtLeafletPrint.Rows(i)("帳票タイプ"), strLotID, dtLeafletPrint.Rows(i)("システムID"), strValue1, strValue2, strValue3)
                        strSQL &= ", '" & strValue1 & "'"
                        strSQL &= ", '" & strValue2 & "'"
                        strSQL &= ", '" & strValue3 & "'"
                        Dim strBOC As String = ""
                        Dim strEOC As String = ""
                        Dim strPAR As String = ""
                        Dim strWAS1 As String = ""
                        Dim strWAS2 As String = ""
                        Dim strWAS3 As String = ""
                        Dim strWAS4 As String = ""
                        Dim strWAS5 As String = ""
                        Dim strWAS6 As String = ""
                        '2017/07/11
                        'ラベル連番を付与した後にOMRの連番処理を行うためここでは何もしない
                        'Dim iStart As Integer = 0
                        'Dim iEnd As Integer = 0
                        ''BOC、EOCはかぶることがあるので(1枚のとき)別に判断する
                        ''BOC判定
                        'If i = 0 Then
                        '    '初回ループだった場合、開始ページ
                        '    iStart = 1
                        'Else
                        '    iStart = 0
                        'End If
                        ''EOC判定
                        'If i = dtLeafletPrint.Rows.Count - 1 Then
                        '    '最終ループだった場合、終了ページ
                        '    iEnd = 1
                        'Else
                        '    iEnd = 0
                        'End If
                        'blnResult = GetOMR(dtLeafletPrint.Rows.Count, iLeafletSeq, iStart, iEnd,
                        '                       strBOC, strEOC, strPAR, strWAS1, strWAS2, strWAS3, strWAS4, strWAS5, strWAS6)
                        strSQL &= ", '" & strBOC & "'"
                        strSQL &= ", '" & strEOC & "'"
                        strSQL &= ", '" & strPAR & "'"
                        strSQL &= ", '" & strWAS1 & "'"
                        strSQL &= ", '" & strWAS2 & "'"
                        strSQL &= ", '" & strWAS3 & "'"
                        strSQL &= ", '" & strWAS4 & "'"
                        strSQL &= ", '" & strWAS5 & "'"
                        strSQL &= ", '" & strWAS6 & "'"
                        'QRコードの算出(システムID(15)＋帳票種別ID(1)＋エラーフラグ(1))
                        strQRCode = dtLeafletPrint.Rows(i)("システムID") & "5" & iErrorFlag.ToString & (i + 1).ToString   '←エラーフラグ付加※カレントSEQ付加
                        '2017/07/13
                        'チェックデジット付与を取りやめ
                        'strCD = ""
                        'blnResult = Modulus10(strQRCodeWithoutCD, 5, strCD)
                        'strQRCode = strQRCodeWithoutCD & strCD

                        strSQL &= ", '" & strQRCode & "'"   'QRコード
                        strSQL &= ")"
                        sqlProcess.DB_UPDATE(strSQL)
                    Next i

                Next iSystemID
                WriteLstResult(lstResult, "リーフレット印刷へのINSERT終了")

            Next iRow

            '==================================================
            '2017/06/30
            'T_印刷管理にラベル連番を付与する
            '重量ヘッダ(降順)、判定票枚数(降順)、会社コード、所属事業所コード、印刷ID
            '==================================================
            WriteLstResult(lstResult, "ラベル連番の付与開始")

            strSQL = "UPDATE T_印刷管理 SET ラベル連番 = NewNo "
            strSQL &= "FROM T_印刷管理 AS T1, "
            strSQL &= "(SELECT CAST(ROW_NUMBER() OVER (PARTITION BY ロットID ORDER BY "
            strSQL &= "重量ヘッダ DESC, 判定票枚数 DESC, リーフレット枚数 DESC, 会社コード, 所属事業所コード, 印刷ID) AS CHAR) AS NewNo, "
            strSQL &= "ロットID, 会社コード, 所属事業所コード, 印刷ID, 重量ヘッダ "
            strSQL &= "FROM T_印刷管理) AS T2 "
            strSQL &= "WHERE T1.ロットID = T2.ロットID "
            strSQL &= "AND T1.会社コード = T2.会社コード "
            strSQL &= "AND T1.所属事業所コード = T2.所属事業所コード "
            strSQL &= "AND T1.印刷ID = T2.印刷ID "
            strSQL &= "AND T1.重量ヘッダ = T2.重量ヘッダ "
            strSQL &= "AND T2.ロットID = '" & strLotID & "'"
            sqlProcess.DB_UPDATE(strSQL)
            WriteLstResult(lstResult, "ラベル連番の付与終了")

            WriteLstResult(lstResult, "リーフレットOMR連番の再振り処理開始")
            '2017/07/10
            'OMR連番はラベル連番が確定した段階で再振りする
            'strSQL = "SELECT T3.ロットID, T3.レコード番号, T3.印刷SEQ, T3.トータルSEQ, T3.カレントSEQ "
            'strSQL &= "FROM T_印刷管理 AS T1 INNER JOIN "
            'strSQL &= "T_判定票管理 AS T2 ON T1.ロットID = T2.ロットID "
            'strSQL &= "AND T1.会社コード = T2.会社コード "
            'strSQL &= "AND T1.所属事業所コード = T2.所属事業所コード INNER JOIN "
            'strSQL &= "T_リーフレット印刷 AS T3 ON T2.ロットID = T3.ロットID "
            'strSQL &= "AND T2.レコード番号 = T3.レコード番号 "
            'strSQL &= "WHERE T1.ロットID = '" & strLotID & "' "
            'strSQL &= "ORDER BY T1.ラベル連番, T3.印刷SEQ"
            strSQL = "SELECT T2.ロットID, T2.レコード番号, T2.印刷SEQ, T2.トータルSEQ, T2.カレントSEQ "
            strSQL &= "FROM T_印刷ソート AS T1 INNER JOIN "
            strSQL &= "T_リーフレット印刷 AS T2 ON T1.ロットID = T2.ロットID "
            strSQL &= "AND T1.レコード番号 = T2.レコード番号 INNER JOIN "
            strSQL &= "T_印刷管理 AS T3 ON T1.ロットID = T3.ロットID "
            strSQL &= "AND T1.会社コード = T3.会社コード "
            strSQL &= "AND T1.所属事業所コード = T3.所属事業所コード "
            strSQL &= "AND T1.印刷ID = T3.印刷ID "
            strSQL &= "WHERE T1.ロットID = '" & strLotID & "' "
            strSQL &= "AND T1.帳票種別ID = 5 "  'リーフレット指定
            '========================================
            '2017/08/08
            'トータルSEQが6以上のものはOMR付与から除外する
            '========================================
            strSQL &= "AND T2.トータルSEQ BETWEEN 1 AND 5 "
            strSQL &= "ORDER BY T3.ラベル連番, T2.印刷SEQ"

            Dim dtOMR As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
            iLeafletSeq = 0
            For iOMR As Integer = 0 To dtOMR.Rows.Count - 1
                'リーフレットシーケンスが63だった場合0にリセット
                '※初回は必ず0なのでインクリメントしないように0だった場合も0とする
                If iOMR = 0 Then
                    iLeafletSeq = 0
                ElseIf iLeafletSeq = 63 Then
                    iLeafletSeq = 0
                Else
                    iLeafletSeq += 1
                End If

                Dim strBOC As String = ""
                Dim strEOC As String = ""
                Dim strPAR As String = ""
                Dim strWAS1 As String = ""
                Dim strWAS2 As String = ""
                Dim strWAS3 As String = ""
                Dim strWAS4 As String = ""
                Dim strWAS5 As String = ""
                Dim strWAS6 As String = ""
                Dim iStart As Integer = 0
                Dim iEnd As Integer = 0

                'BOC判定
                If dtOMR.Rows(iOMR)("カレントSEQ") = 1 Then
                    '初回ページ
                    iStart = 1
                Else
                    iStart = 0
                End If
                'EOC判定
                If dtOMR.Rows(iOMR)("トータルSEQ") = dtOMR.Rows(iOMR)("カレントSEQ") Then
                    'トータルSEQとカレントSEQが同一の場合は最終ページ
                    iEnd = 1
                Else
                    iEnd = 0
                End If
                Dim blnResult As Boolean = GetOMR(dtOMR.Rows.Count, iLeafletSeq, iStart, iEnd,
                                               strBOC, strEOC, strPAR, strWAS1, strWAS2, strWAS3, strWAS4, strWAS5, strWAS6)
                strSQL = "UPDATE T_リーフレット印刷 SET "
                strSQL &= "BOC = '" & strBOC & "', "
                strSQL &= "EOC = '" & strEOC & "', "
                strSQL &= "PAR = '" & strPAR & "', "
                strSQL &= "WAS1 = '" & strWAS1 & "', "
                strSQL &= "WAS2 = '" & strWAS2 & "', "
                strSQL &= "WAS3 = '" & strWAS3 & "', "
                strSQL &= "WAS4 = '" & strWAS4 & "', "
                strSQL &= "WAS5 = '" & strWAS5 & "', "
                strSQL &= "WAS6 = '" & strWAS6 & "' "
                strSQL &= "WHERE ロットID = '" & strLotID & "' "
                strSQL &= "AND レコード番号 = " & dtOMR.Rows(iOMR)("レコード番号") & " "
                strSQL &= "AND 印刷SEQ = " & dtOMR.Rows(iOMR)("印刷SEQ")
                sqlProcess.DB_UPDATE(strSQL)

            Next

			WriteLstResult(lstResult, "リーフレットOMR連番の再振り処理終了")

			'2018/04/17
			'所属事業所コード単位でQRコードに連番を振る処理を追加
			WriteLstResult(lstResult, "QRコード内連番の再振り処理開始")
			ReSwingQR(strLotID)
			WriteLstResult(lstResult, "QRコード内連番の再振り処理終了")

			'2018/08/10
			'リーフレットが6枚以上ある社員レコードをT_リーフ6チェックにコピーする
			WriteLstResult(lstResult, "リーフレット6データ抽出処理開始")
			ReSwingLeaf6(strLotID)
			WriteLstResult(lstResult, "リーフレット6データ抽出処理終了")

			WriteLstResult(lstResult, "印刷準備処理完了")
			OutputImportLog(lstResult, strOutputFolder, "_Preparation_")

        Catch ex As Exception

            Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & ex.StackTrace)
            MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally

            sqlProcess.Close()

        End Try

    End Sub

	''' <summary>
	''' リーフ6チェック用テーブルへのデータINSERT
	''' </summary>
	''' <param name="strLotID"></param>
	Private Sub ReSwingLeaf6(ByVal strLotID As String)

		Dim strSQL As String = ""
		Dim sqlProcess As New SQLProcess

		Try
			'該当ロットIDのデータをリーフ6チェックより削除
			strSQL = "DELETE FROM T_リーフ6チェック "
			strSQL &= "WHERE ロットID = '" & strLotID & "'"
			sqlProcess.DB_UPDATE(strSQL)

			strSQL = "INSERT INTO T_リーフ6チェック "
			strSQL &= "SELECT T2.ロットID, T2.レコード番号, T1.会社コード, T1.所属事業所コード, T1.印刷ID, T2.印刷SEQ, "
			strSQL &= "T2.トータルSEQ, T2.カレントSEQ, T3.ラベル連番, T3.重量ヘッダ, T2.帳票タイプ, T2.QRコード, 0, NULL, '' "
			strSQL &= "FROM T_印刷ソート AS T1 INNER JOIN "
			strSQL &= "T_リーフレット印刷 AS T2 ON T1.ロットID = T2.ロットID "
			strSQL &= "AND T1.レコード番号 = T2.レコード番号 INNER JOIN "
			strSQL &= "T_印刷管理 AS T3 ON T1.ロットID = T3.ロットID "
			strSQL &= "AND T1.会社コード = T3.会社コード "
			strSQL &= "AND T1.所属事業所コード = T3.所属事業所コード "
			strSQL &= "AND T1.印刷ID = T3.印刷ID "
			strSQL &= "WHERE T1.ロットID = '" & strLotID & "' "
			strSQL &= "AND T1.帳票種別ID = 5 "
			strSQL &= "AND T2.トータルSEQ >= 6 "
			strSQL &= "ORDER BY T3.ラベル連番, T2.印刷SEQ"
			sqlProcess.DB_UPDATE(strSQL)

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & ex.StackTrace)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		Finally

			sqlProcess.Close()

		End Try

	End Sub

	''' <summary>
	''' QRコードに所属事業所コード単位の連番を付与したものをセットする
	''' </summary>
	''' <param name="strLotID"></param>
	Private Sub ReSwingQR(ByVal strLotID As String)

		Dim strSQL As String = ""
		Dim sqlProcess As New SQLProcess

		Try
			'ロットID内の会社コード、所属事業所コード、印刷IDでグルーピングしたものを取得する
			'T_印刷ソートの該当所属事業所コードの印刷ID、帳票種別ID、ページ数でソートし、4桁連番を各レコードに付加する
			strSQL = "SELECT 会社コード, 所属事業所コード, 印刷ID "
			strSQL &= "FROM T_印刷ソート "
			strSQL &= "WHERE ロットID = '" & strLotID & "' "
			strSQL &= "GROUP BY 会社コード, 所属事業所コード, 印刷ID "
			strSQL &= "ORDER BY 会社コード, 所属事業所コード, 印刷ID"
			Dim dtQRRoot As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
			For iQRRoot As Integer = 0 To dtQRRoot.Rows.Count - 1
				strSQL = "SELECT ロットID, 会社コード, 所属事業所コード, 印刷ID, ページ数, レコード番号, システムID, 帳票種別ID, QR "
				strSQL &= "FROM T_印刷ソート "
				strSQL &= "WHERE ロットID = '" & strLotID & "' "
				strSQL &= "AND 会社コード = '" & dtQRRoot.Rows(iQRRoot)("会社コード") & "' "
				strSQL &= "AND 所属事業所コード = '" & dtQRRoot.Rows(iQRRoot)("所属事業所コード") & "' "
				strSQL &= "AND 印刷ID = " & dtQRRoot.Rows(iQRRoot)("印刷ID") & " "
				strSQL &= "ORDER BY 印刷ID, 帳票種別ID, ページ数"
				Dim dt As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)

				Dim iTotalCount As Integer = 0  '所属事業所コード、印刷ID単位の連番付与用カウンタ
				For iRow As Integer = 0 To dt.Rows.Count - 1
					iTotalCount += 1
					'帳票種別IDごとに仕様に沿った形で4桁連番を付加する
					Select Case dt.Rows(iRow)("帳票種別ID")
						Case 0
							'ラベル
							'先頭5文字目で分離
							Dim strOldQR As String = dt.Rows(iRow)("QR")
							Dim strQRUp As String = Strings.Left(strOldQR, 5)
							Dim strQRDown As String = Strings.Right(strOldQR, strOldQR.Length - strQRUp.Length)
							Dim strNewQR As String = strQRUp & "-" & iTotalCount.ToString("0000") & "-" & strQRDown
							'UPDATEはT_印刷ソートのみ
							strSQL = "UPDATE T_印刷ソート SET QR = '" & strNewQR & "' "
							strSQL &= "WHERE ロットID = '" & strLotID & "' "
							strSQL &= "AND 会社コード = '" & dt.Rows(iRow)("会社コード") & "' "
							strSQL &= "AND 所属事業所コード = '" & dt.Rows(iRow)("所属事業所コード") & "' "
							strSQL &= "AND 印刷ID = " & dt.Rows(iRow)("印刷ID") & " "
							strSQL &= "AND 帳票種別ID = 0"
							sqlProcess.DB_UPDATE(strSQL)
						Case 1
							'挨拶状
							'先頭5文字目で分離
							Dim strOldQR As String = dt.Rows(iRow)("QR")
							Dim strQRUp As String = Strings.Left(strOldQR, 5)
							Dim strQRDown As String = Strings.Right(strOldQR, strOldQR.Length - strQRUp.Length)
							Dim strNewQR As String = strQRUp & "-" & iTotalCount.ToString("0000") & "-" & strQRDown
							'UPDATEはT_印刷ソートのみ
							strSQL = "UPDATE T_印刷ソート SET QR = '" & strNewQR & "' "
							strSQL &= "WHERE ロットID = '" & strLotID & "' "
							strSQL &= "AND 会社コード = '" & dt.Rows(iRow)("会社コード") & "' "
							strSQL &= "AND 所属事業所コード = '" & dt.Rows(iRow)("所属事業所コード") & "' "
							strSQL &= "AND 印刷ID = " & dt.Rows(iRow)("印刷ID") & " "
							strSQL &= "AND 帳票種別ID = 1"
							sqlProcess.DB_UPDATE(strSQL)
						Case 2
							'対象者一覧
							'先頭5文字目で分離
							Dim strOldQR As String = dt.Rows(iRow)("QR")
							Dim strQRUp As String = Strings.Left(strOldQR, 5)
							Dim strQRDown As String = Strings.Right(strOldQR, strOldQR.Length - strQRUp.Length)
							Dim strNewQR As String = strQRUp & "-" & iTotalCount.ToString("0000") & "-" & strQRDown
							'UPDATEはT_印刷ソートのみ
							strSQL = "UPDATE T_印刷ソート SET QR = '" & strNewQR & "' "
							strSQL &= "WHERE ロットID = '" & strLotID & "' "
							strSQL &= "AND 会社コード = '" & dt.Rows(iRow)("会社コード") & "' "
							strSQL &= "AND 所属事業所コード = '" & dt.Rows(iRow)("所属事業所コード") & "' "
							strSQL &= "AND 印刷ID = " & dt.Rows(iRow)("印刷ID") & " "
							strSQL &= "AND ページ数 = " & dt.Rows(iRow)("ページ数") & " "
							strSQL &= "AND 帳票種別ID = 2"
							sqlProcess.DB_UPDATE(strSQL)
						Case 3
							'保健指導対象者名簿
							'先頭5文字目で分離
							Dim strOldQR As String = dt.Rows(iRow)("QR")
							Dim strQRUp As String = Strings.Left(strOldQR, 5)
							Dim strQRDown As String = Strings.Right(strOldQR, strOldQR.Length - strQRUp.Length)
							Dim strNewQR As String = strQRUp & "-" & iTotalCount.ToString("0000") & "-" & strQRDown
							'UPDATEはT_印刷ソートのみ
							strSQL = "UPDATE T_印刷ソート SET QR = '" & strNewQR & "' "
							strSQL &= "WHERE ロットID = '" & strLotID & "' "
							strSQL &= "AND 会社コード = '" & dt.Rows(iRow)("会社コード") & "' "
							strSQL &= "AND 所属事業所コード = '" & dt.Rows(iRow)("所属事業所コード") & "' "
							strSQL &= "AND 印刷ID = " & dt.Rows(iRow)("印刷ID") & " "
							strSQL &= "AND ページ数 = " & dt.Rows(iRow)("ページ数") & " "
							strSQL &= "AND 帳票種別ID = 3"
							sqlProcess.DB_UPDATE(strSQL)
						Case 4
							'判定票
							'先頭16文字目で分離
							Dim strOldQR As String = dt.Rows(iRow)("QR")
							Dim strQRUp As String = Strings.Left(strOldQR, 16)
							Dim strQRDown As String = Strings.Right(strOldQR, strOldQR.Length - strQRUp.Length)
							Dim strNewQR As String = strQRUp & "-" & iTotalCount.ToString("0000") & "-" & strQRDown
							'UPDATEはT_印刷ソート、T_判定票印刷
							strSQL = "UPDATE T_印刷ソート SET QR = '" & strNewQR & "' "
							strSQL &= "WHERE ロットID = '" & strLotID & "' "
							strSQL &= "AND 会社コード = '" & dt.Rows(iRow)("会社コード") & "' "
							strSQL &= "AND 所属事業所コード = '" & dt.Rows(iRow)("所属事業所コード") & "' "
							strSQL &= "AND 印刷ID = " & dt.Rows(iRow)("印刷ID") & " "
							strSQL &= "AND ページ数 = " & dt.Rows(iRow)("ページ数") & " "
							strSQL &= "AND レコード番号 = " & dt.Rows(iRow)("レコード番号") & " "
							strSQL &= "AND 帳票種別ID = 4"
							sqlProcess.DB_UPDATE(strSQL)
							'T_判定票印刷
							strSQL = "UPDATE T_判定票印刷 SET QRコード = '" & strNewQR & "' "
							strSQL &= "WHERE ロットID = '" & strLotID & "' "
							strSQL &= "AND レコード番号 = " & dt.Rows(iRow)("レコード番号")
							sqlProcess.DB_UPDATE(strSQL)
						Case 5
							'リーフレット
							'先頭16文字目で分離
							Dim strOldQR As String = dt.Rows(iRow)("QR")
							Dim strQRUp As String = Strings.Left(strOldQR, 16)
							Dim strQRDown As String = Strings.Right(strOldQR, strOldQR.Length - strQRUp.Length)
							Dim strNewQR As String = strQRUp & "-" & iTotalCount.ToString("0000") & "-" & strQRDown
							'UPDATEはT_印刷ソート、T_リーフレット印刷
							'T_印刷ソート内のリーフレットは1枚めのみ
							strSQL = "UPDATE T_印刷ソート SET QR = '" & strNewQR & "' "
							strSQL &= "WHERE ロットID = '" & strLotID & "' "
							strSQL &= "AND 会社コード = '" & dt.Rows(iRow)("会社コード") & "' "
							strSQL &= "AND 所属事業所コード = '" & dt.Rows(iRow)("所属事業所コード") & "' "
							strSQL &= "AND 印刷ID = " & dt.Rows(iRow)("印刷ID") & " "
							strSQL &= "AND ページ数 = " & dt.Rows(iRow)("ページ数") & " "
							strSQL &= "AND レコード番号 = " & dt.Rows(iRow)("レコード番号") & " "
							strSQL &= "AND 帳票種別ID = 5"
							sqlProcess.DB_UPDATE(strSQL)
							'T_リーフレット印刷内は2枚目以降も対象となるためレコード番号で回す
							strSQL = "SELECT レコード番号, カレントSEQ, QRコード "
							strSQL &= "FROM T_リーフレット印刷 "
							strSQL &= "WHERE ロットID = '" & strLotID & "' "
							strSQL &= "AND レコード番号 = " & dt.Rows(iRow)("レコード番号") & " "
							strSQL &= "ORDER BY レコード番号, カレントSEQ"
							Dim dtLeafQR As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
							'先頭のリーフレットはT_印刷ソートでUPDATEした値と同一のため、-1してQRコードをUPDATEしていく
							iTotalCount -= 1
							For iLeafQR As Integer = 0 To dtLeafQR.Rows.Count - 1
								'リーフレットはここでもカウンタを回す
								iTotalCount += 1
								strOldQR = dtLeafQR.Rows(iLeafQR)("QRコード")
								strQRUp = Strings.Left(strOldQR, 16)
								strQRDown = Strings.Right(strOldQR, strOldQR.Length - strQRUp.Length)
								strNewQR = strQRUp & "-" & iTotalCount.ToString("0000") & "-" & strQRDown
								strSQL = "UPDATE T_リーフレット印刷 SET QRコード = '" & strNewQR & "' "
								strSQL &= "WHERE ロットID = '" & strLotID & "' "
								strSQL &= "AND レコード番号 = " & dtLeafQR.Rows(iLeafQR)("レコード番号") & " "
								strSQL &= "AND カレントSEQ = " & dtLeafQR.Rows(iLeafQR)("カレントSEQ")
								sqlProcess.DB_UPDATE(strSQL)
							Next
					End Select
				Next
			Next

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & ex.StackTrace)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		Finally

			sqlProcess.Close()

		End Try

	End Sub

	''' <summary>
	''' 不備内容修正時、個別データ修正
	''' </summary>
	''' <param name="strLotID"></param>
	''' <param name="iRecordNumber"></param>
	''' <remarks>T_判定票、T_リーフレットの値は修正済とみなす</remarks>
	Public Sub PrintPreparationIndividual(ByVal strLotID As String, ByVal iRecordNumber As Integer)

        Dim sqlProcess As New SQLProcess
        Dim strSQL As String = ""
        XmlSettings.LoadFromXmlFile()
        Dim dt As DataTable = Nothing
		Dim strQRCode As String = ""
		Dim strCheckupQR As String = ""
		Dim strLeafletQR As String = ""

		Try
			'判定票
			'2018/05/07
			'T_印刷ソートからQRコードを取得しておき、判定票印刷、リーフレット印刷に流用する
			strSQL = "SELECT QR FROM T_印刷ソート "
			strSQL &= "WHERE ロットID = '" & strLotID & "' "
			strSQL &= "AND レコード番号 = " & iRecordNumber & " "
			strSQL &= "AND 帳票種別ID = 4"
			Dim dtCheckupQR As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
			If dtCheckupQR.Rows.Count > 0 Then
				strCheckupQR = dtCheckupQR.Rows(0)("QR")
			Else
				strCheckupQR = ""
			End If
			'リーフレット
			strSQL = "SELECT QR FROM T_印刷ソート "
			strSQL &= "WHERE ロットID = '" & strLotID & "' "
			strSQL &= "AND レコード番号 = " & iRecordNumber & " "
			strSQL &= "AND 帳票種別ID = 5"
			Dim dtLeafletQR As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
			If dtLeafletQR.Rows.Count > 0 Then
				strLeafletQR = dtLeafletQR.Rows(0)("QR")
			Else
				strLeafletQR = ""
			End If

			'2018/05/07
			'T_印刷ソート.QRは既に更新済みなので廃止
			'strSQL = "SELECT T1.ロットID, T1.レコード番号, T1.システムID, T2.会社, T2.所属事業所, T1.所属部名, T1.所属課名, T2.氏名姓 + ' ' + T2.氏名名 AS 氏名, "
			'         strSQL &= "T2.受診日, T3.変換健診種別 AS 健診種別, T2.就業区分, T1.判定票CSV, T1.リーフレットCSV, "
			'         strSQL &= "ISNULL(T1.要修正日時, '1900/01/01') AS 要修正日時, ISNULL(T1.修正済日時, '1900/01/01') AS 修正済日時 "
			'         strSQL &= "FROM T_判定票管理 AS T1 INNER JOIN "
			'         strSQL &= "T_判定票 AS T2 ON T1.ロットID = T2.ロットID AND T1.レコード番号 = T2.レコード番号 INNER JOIN "
			'         strSQL &= "M_健診種別 AS T3 ON T1.健診種別 = T3.健診種別 "
			'         strSQL &= "WHERE T1.ロットID = '" & strLotID & "' "
			'         strSQL &= "AND T1.レコード番号 = " & iRecordNumber & " "

			'Dim dtCheckupList As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
			'If dtCheckupList.Rows.Count > 0 Then
			'             'QRコードの生成
			'             '判定票
			'             strQRCode = dtCheckupList.Rows(0)("システムID") & "4" & "0" 'エラーフラグを必ず取り下げる
			'             'T_印刷ソートのQRコード書き換え
			'             strSQL = "UPDATE T_印刷ソート SET QR = '" & strQRCode & "' "
			'             strSQL &= "WHERE ロットID = '" & strLotID & "' "
			'             strSQL &= "AND レコード番号 = " & iRecordNumber & " "
			'             strSQL &= "AND 帳票種別ID = 4"
			'             sqlProcess.DB_UPDATE(strSQL)
			'         End If

			''リーフレット
			'strSQL = "SELECT T1.ロットID, T1.レコード番号, T1.システムID, T3.判定票CSV, T3.リーフレットCSV, "
			'         strSQL &= "ISNULL(要修正日時, '1900/01/01') AS 要修正日時, "
			'         strSQL &= "ISNULL(修正済日時, '1900/01/01') AS 修正済日時 "
			'         strSQL &= "FROM T_判定票 AS T1 INNER JOIN "
			'         strSQL &= "T_リーフレット AS T2 ON T1.ロットID = T2.ロットID "
			'         strSQL &= "AND T1.レコード番号 = T2.レコード番号 INNER JOIN "
			'         strSQL &= "T_判定票管理 AS T3 ON T1.ロットID = T3.ロットID "
			'         strSQL &= "AND T1.レコード番号 = T3.レコード番号 "
			'         strSQL &= "WHERE T1.ロットID = '" & strLotID & "' "
			'         strSQL &= "AND T1.レコード番号 = " & iRecordNumber & " "
			'         strSQL &= "AND T3.リーフレット無効 != 1"
			'         Dim dtLeaf As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
			'         If dtLeaf.Rows.Count > 0 Then
			'             'QRコードの生成
			'             'リーフレット
			'             strQRCode = dtLeaf.Rows(0)("システムID") & "5" & "0" & "1"  'リーフレット(5)、エラーフラグ(0)、カレントSEQ(1固定)
			'             'T_印刷ソートのQRコード書き換え
			'             strSQL = "UPDATE T_印刷ソート SET QR = '" & strQRCode & "' "
			'             strSQL &= "WHERE ロットID = '" & strLotID & "' "
			'             strSQL &= "AND レコード番号 = " & iRecordNumber & " "
			'             strSQL &= "AND 帳票種別ID = 5"
			'             sqlProcess.DB_UPDATE(strSQL)
			'         End If

			'T_判定票印刷へのINSERT
			'該当レコードを削除して再生成する
			strSQL = "DELETE FROM T_判定票印刷 "
            strSQL &= "WHERE ロットID = '" & strLotID & "' "
            strSQL &= "AND レコード番号 = " & iRecordNumber
            sqlProcess.DB_UPDATE(strSQL)

            'T_判定票から該当レコード番号を抽出
            strSQL = "SELECT T1.ロットID, T1.レコード番号, T1.システムID, T1.氏名セイ + ' ' + T1.氏名メイ AS 氏名カナ, T1.氏名姓 + ' ' + T1.氏名名 AS 氏名, "
            strSQL &= "T2.受診年齢, T1.会社, T1.所属事業所, T1.所属部名, T1.所属課名, T1.役職名, T1.性別, T1.採用年月日, T1.生年月日, T3.変換健診種別 AS 健診種別, T1.受診日, "
            strSQL &= "T1.身長, T1.体重, T1.体重上限, T1.体重下限, T1.BMI, T1.BMI上限, T1.BMI下限, T1.腹囲, T1.腹囲上限, T1.腹囲下限, T1.視力裸眼右, T1.視力裸眼左, "
            strSQL &= "T1.視力矯正右, T1.視力矯正左, T1.聴力右1000, T1.聴力右4000, T1.聴力左1000, T1.聴力左4000, T1.聴力その他, T1.血圧1回収縮期, T1.血圧1回収縮期上限, "
            strSQL &= "T1.血圧1回収縮期下限, T1.血圧1回拡張期, T1.血圧1回拡張期上限, T1.血圧1回拡張期下限, T1.尿糖定性, T1.尿蛋白定性, T1.総コレステロール, "
            strSQL &= "T1.総コレステロール上限, T1.総コレステロール下限, T1.HDLコレステロール, T1.HDLコレステロール上限, T1.HDLコレステロール下限, "
            strSQL &= "T1.中性脂肪, T1.中性脂肪上限, T1.中性脂肪下限, T1.LDLコレステロール, T1.LDLコレステロール上限, T1.LDLコレステロール下限, "
            strSQL &= "T1.GOT, T1.GOT上限, T1.GOT下限, T1.GPT, T1.GPT上限, T1.GPT下限, T1.ガンマGTP, T1.ガンマGTP上限, T1.ガンマGTP下限, "
            strSQL &= "T1.クレアチニン, T1.クレアチニン上限, T1.クレアチニン下限, T1.尿酸, T1.尿酸上限, T1.尿酸下限, T1.赤血球, T1.赤血球上限, T1.赤血球下限, "
            strSQL &= "T1.血色素量, T1.血色素量上限, T1.血色素量下限, T1.空腹時血糖, T1.空腹時血糖上限, T1.空腹時血糖下限, T1.随時血糖, T1.随時血糖上限, T1.随時血糖下限, "
            strSQL &= "T1.HbA1c, T1.HbA1c上限, T1.HbA1c下限, 受診検査機関名称, T1.会場局名称, T1.総合判定, 健診実施医師名, T1.判定医師名, T1.判定日付, "
            strSQL &= "T1.視力判定, T1.聴力判定, T1.血圧判定, T1.尿糖判定, T1.尿蛋白判定, T1.血中脂質判定, T1.肝機能判定, T1.腎機能判定, T1.尿酸判定, T1.血液判定, "
            strSQL &= "T1.血糖判定, T1.胸部X線判定結果, T1.心電図判定結果, T1.総合成績判定, T1.就業区分, T1.胸部X線所見, T1.胸部X線判定, T1.心電図所見, T1.心電図判定, "
            strSQL &= "T1.既往歴, T1.自覚症状, T1.診察所見, T1.総合コメント, T1.産業医の意見, "
            strSQL &= "T2.判定票CSV, T2.リーフレットCSV, ISNULL(T2.要修正日時, '1900/01/01') AS 要修正日時, ISNULL(T2.修正済日時, '1900/01/01') AS 修正済日時 "
            strSQL &= "FROM T_判定票 AS T1 INNER JOIN "
            strSQL &= "T_判定票管理 AS T2 ON T1.ロットID = T2.ロットID AND T1.レコード番号 = T2.レコード番号 INNER JOIN "
            strSQL &= "M_健診種別 AS T3 ON T1.健診種別 = T3.健診種別 "
            strSQL &= "WHERE T1.ロットID = '" & strLotID & "'"
            strSQL &= "AND T1.レコード番号 = " & iRecordNumber
            'strSQL &= "AND T1.所属事業所コード = '" & dtOffice.Rows(iRow)("所属事業所コード") & "' "
            'strSQL &= "ORDER BY CASE WHEN ISNULL(T1.所属部名, '') = '' THEN 1 ELSE 0 END, "
            'strSQL &= "T1.所属部名, "
            'strSQL &= "CASE WHEN ISNULL(T1.所属課名, '') = '' THEN 1 ELSE 0 END, "
            'strSQL &= "T1.所属課名, T1.社員コード"
            Dim dtCheckupPrint As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)

            If dtCheckupPrint.Rows.Count > 0 Then
                'T_判定票印刷へのINSERT
                strSQL = "INSERT INTO T_判定票印刷 (ロットID, レコード番号, システムID, 氏名カナ, 氏名, 受診年齢, 会社, 所属事業所, 所属部名, 所属課名, 役職名, 性別, 採用年月日, "
                strSQL &= "生年月日, 健診種別, 受診日, 身長, 体重, 体重記号, 体重上限, 体重下限, BMI, BMI記号, BMI上限, BMI下限, 腹囲, 腹囲記号, 腹囲上限, 腹囲下限, "
                strSQL &= "視力裸眼右, 視力裸眼左, 視力矯正右, 視力矯正左, 聴力右1000, 聴力右4000, 聴力左1000, 聴力左4000, 聴力その他, 血圧1回収縮期, 血圧1回収縮期記号, "
                strSQL &= "血圧1回収縮期上限, 血圧1回収縮期下限, 血圧1回拡張期, 血圧1回拡張期記号, 血圧1回拡張期上限, 血圧1回拡張期下限, 尿糖定性, 尿蛋白定性, "
                strSQL &= "総コレステロール, 総コレステロール記号, 総コレステロール上限, 総コレステロール下限, HDLコレステロール, HDLコレステロール記号, HDLコレステロール上限, "
                strSQL &= "HDLコレステロール下限, 中性脂肪, 中性脂肪記号, 中性脂肪上限, 中性脂肪下限, LDLコレステロール, LDLコレステロール記号, LDLコレステロール上限, "
                strSQL &= "LDLコレステロール下限, GOT, GOT記号, GOT上限, GOT下限, GPT, GPT記号, GPT上限, GPT下限, ガンマGTP, ガンマGTP記号, ガンマGTP上限, ガンマGTP下限, "
                strSQL &= "クレアチニン, クレアチニン記号, クレアチニン上限, クレアチニン下限, 尿酸, 尿酸記号, 尿酸上限, 尿酸下限, 赤血球, 赤血球記号, 赤血球上限, 赤血球下限, "
                strSQL &= "血色素量, 血色素量記号, 血色素量上限, 血色素量下限, 空腹時血糖, 空腹時血糖記号, 空腹時血糖上限, 空腹時血糖下限, 随時血糖, 随時血糖記号, 随時血糖上限, "
                strSQL &= "随時血糖下限, HbA1c, HbA1c記号, HbA1c上限, HbA1c下限, 受診検査機関名称, 会場局名称, 総合判定, 健診実施医師名, 判定医師名, 判定日付, "
                strSQL &= "視力判定, 聴力判定, 血圧判定, 尿糖判定, 尿蛋白判定, 血中脂質判定, 肝機能判定, 腎機能判定, 尿酸判定, 血液判定, 血糖判定, 胸部X線判定結果, 心電図判定結果, "
                strSQL &= "総合成績判定, 就業区分, 胸部X線所見, 胸部X線判定, 心電図所見, 心電図判定, 既往歴, 自覚症状, 診察所見, 総合コメント, 産業医の意見, QRコード) VALUES("
                strSQL &= "'" & strLotID & "'"  'ロットID
                strSQL &= ", " & dtCheckupPrint.Rows(0)("レコード番号").ToString.Replace("'", "''")  'レコード番号
                strSQL &= ", '" & dtCheckupPrint.Rows(0)("システムID").ToString.Replace("'", "''") & "'"    'システムID
                strSQL &= ", '" & VisualBasic.Japanese.Kanaxs.Kana.ToHankakuKana(dtCheckupPrint.Rows(0)("氏名カナ")).ToString.Replace("'", "''") & "'"    '氏名カナ、半角カナに変換
                strSQL &= ", '" & dtCheckupPrint.Rows(0)("氏名").ToString.Replace("'", "''") & "'"    '氏名
                strSQL &= ", '" & dtCheckupPrint.Rows(0)("受診年齢").ToString.Replace("'", "''") & "歳'"
                strSQL &= ", '" & dtCheckupPrint.Rows(0)("会社").ToString.Replace("'", "''") & "'"
                strSQL &= ", '" & dtCheckupPrint.Rows(0)("所属事業所").ToString.Replace("'", "''") & "'"
                strSQL &= ", '" & dtCheckupPrint.Rows(0)("所属部名").ToString.Replace("'", "''") & "'"
                strSQL &= ", '" & dtCheckupPrint.Rows(0)("所属課名").ToString.Replace("'", "''") & "'"
                strSQL &= ", '" & dtCheckupPrint.Rows(0)("役職名").ToString.Replace("'", "''") & "'"
                strSQL &= ", '" & dtCheckupPrint.Rows(0)("性別").ToString.Replace("'", "''") & "'"
                strSQL &= ", '" & dtCheckupPrint.Rows(0)("採用年月日").ToString.Replace("'", "''") & "'"
                strSQL &= ", '" & dtCheckupPrint.Rows(0)("生年月日").ToString.Replace("'", "''") & "'"
                strSQL &= ", '" & dtCheckupPrint.Rows(0)("健診種別").ToString.Replace("'", "''") & "'"
                strSQL &= ", '" & dtCheckupPrint.Rows(0)("受診日").ToString.Replace("'", "''") & "'"
                strSQL &= ", '" & PeriodCheck(dtCheckupPrint.Rows(0)("身長"), 1) & "'"
                '==================================================
                '体重
                '==================================================
                strSQL &= ", '" & PeriodCheck(dtCheckupPrint.Rows(0)("体重"), 1) & "'"
                strSQL &= ", '" & WhichUpDown(dtCheckupPrint.Rows(0)("体重"), dtCheckupPrint.Rows(0)("体重上限"), dtCheckupPrint.Rows(0)("体重下限")) & "'"
                strSQL &= ", '" & PeriodCheck(dtCheckupPrint.Rows(0)("体重上限"), 1) & "'"
                strSQL &= ", '" & PeriodCheck(dtCheckupPrint.Rows(0)("体重下限"), 1) & "'"
                '==================================================
                'BMI
                '==================================================
                strSQL &= ", '" & PeriodCheck(dtCheckupPrint.Rows(0)("BMI"), 1) & "'"
                strSQL &= ", '" & WhichUpDown(dtCheckupPrint.Rows(0)("BMI"), dtCheckupPrint.Rows(0)("BMI上限"), dtCheckupPrint.Rows(0)("BMI下限")) & "'"
                strSQL &= ", '" & PeriodCheck(dtCheckupPrint.Rows(0)("BMI上限"), 1) & "'"
                strSQL &= ", '" & PeriodCheck(dtCheckupPrint.Rows(0)("BMI下限"), 1) & "'"
                '==================================================
                '腹囲
                '==================================================
                strSQL &= ", '" & PeriodCheck(dtCheckupPrint.Rows(0)("腹囲"), 1) & "'"
                strSQL &= ", '" & WhichUpDown(dtCheckupPrint.Rows(0)("腹囲"), dtCheckupPrint.Rows(0)("腹囲上限"), dtCheckupPrint.Rows(0)("腹囲下限")) & "'"
                strSQL &= ", '" & PeriodCheck(dtCheckupPrint.Rows(0)("腹囲上限"), 1) & "'"
                strSQL &= ", '" & PeriodCheck(dtCheckupPrint.Rows(0)("腹囲下限"), 1) & "'"
                '==================================================
                '視力
                '==================================================
                strSQL &= ", '" & PeriodCheck(dtCheckupPrint.Rows(0)("視力裸眼右"), 1) & "'"
                strSQL &= ", '" & PeriodCheck(dtCheckupPrint.Rows(0)("視力裸眼左"), 1) & "'"
                strSQL &= ", '" & PeriodCheck(dtCheckupPrint.Rows(0)("視力矯正右"), 1) & "'"
                strSQL &= ", '" & PeriodCheck(dtCheckupPrint.Rows(0)("視力矯正左"), 1) & "'"
                '==================================================
                '聴力
                '==================================================
                strSQL &= ", '" & dtCheckupPrint.Rows(0)("聴力右1000") & "'"
                strSQL &= ", '" & dtCheckupPrint.Rows(0)("聴力右4000") & "'"
                strSQL &= ", '" & dtCheckupPrint.Rows(0)("聴力左1000") & "'"
                strSQL &= ", '" & dtCheckupPrint.Rows(0)("聴力左4000") & "'"
                strSQL &= ", '" & dtCheckupPrint.Rows(0)("聴力その他") & "'"
                '==================================================
                '血圧
                '==================================================
                strSQL &= ", '" & dtCheckupPrint.Rows(0)("血圧1回収縮期") & "'"
                strSQL &= ", '" & WhichUpDown(dtCheckupPrint.Rows(0)("血圧1回収縮期"), dtCheckupPrint.Rows(0)("血圧1回収縮期上限"), dtCheckupPrint.Rows(0)("血圧1回収縮期下限")) & "'"
                strSQL &= ", '" & dtCheckupPrint.Rows(0)("血圧1回収縮期上限") & "'"
                strSQL &= ", '" & dtCheckupPrint.Rows(0)("血圧1回収縮期下限") & "'"

                strSQL &= ", '" & dtCheckupPrint.Rows(0)("血圧1回拡張期") & "'"
                strSQL &= ", '" & WhichUpDown(dtCheckupPrint.Rows(0)("血圧1回拡張期"), dtCheckupPrint.Rows(0)("血圧1回拡張期上限"), dtCheckupPrint.Rows(0)("血圧1回拡張期下限")) & "'"
                strSQL &= ", '" & dtCheckupPrint.Rows(0)("血圧1回拡張期上限") & "'"
                strSQL &= ", '" & dtCheckupPrint.Rows(0)("血圧1回拡張期下限") & "'"
                '==================================================
                '尿
                '==================================================
                strSQL &= ", '" & dtCheckupPrint.Rows(0)("尿糖定性").ToString.Replace("'", "''") & "'"
                strSQL &= ", '" & dtCheckupPrint.Rows(0)("尿蛋白定性").ToString.Replace("'", "''") & "'"
                '==================================================
                '総コレステロール
                '==================================================
                strSQL &= ", '" & dtCheckupPrint.Rows(0)("総コレステロール") & "'"
                strSQL &= ", '" & WhichUpDown(dtCheckupPrint.Rows(0)("総コレステロール"), dtCheckupPrint.Rows(0)("総コレステロール上限"), dtCheckupPrint.Rows(0)("総コレステロール下限")) & "'"
                strSQL &= ", '" & dtCheckupPrint.Rows(0)("総コレステロール上限") & "'"
                strSQL &= ", '" & dtCheckupPrint.Rows(0)("総コレステロール下限") & "'"
                '==================================================
                'HDLコレステロール
                '==================================================
                strSQL &= ", '" & dtCheckupPrint.Rows(0)("HDLコレステロール") & "'"
                strSQL &= ", '" & WhichUpDown(dtCheckupPrint.Rows(0)("HDLコレステロール"), dtCheckupPrint.Rows(0)("HDLコレステロール上限"), dtCheckupPrint.Rows(0)("HDLコレステロール下限")) & "'"
                strSQL &= ", '" & dtCheckupPrint.Rows(0)("HDLコレステロール上限") & "'"
                strSQL &= ", '" & dtCheckupPrint.Rows(0)("HDLコレステロール下限") & "'"
                '==================================================
                '中性脂肪
                '==================================================
                strSQL &= ", '" & dtCheckupPrint.Rows(0)("中性脂肪") & "'"
                strSQL &= ", '" & WhichUpDown(dtCheckupPrint.Rows(0)("中性脂肪"), dtCheckupPrint.Rows(0)("中性脂肪上限"), dtCheckupPrint.Rows(0)("中性脂肪下限")) & "'"
                strSQL &= ", '" & dtCheckupPrint.Rows(0)("中性脂肪上限") & "'"
                strSQL &= ", '" & dtCheckupPrint.Rows(0)("中性脂肪下限") & "'"
                '==================================================
                'LDLコレステロール
                '==================================================
                strSQL &= ", '" & dtCheckupPrint.Rows(0)("LDLコレステロール") & "'"
                strSQL &= ", '" & WhichUpDown(dtCheckupPrint.Rows(0)("LDLコレステロール"), dtCheckupPrint.Rows(0)("LDLコレステロール上限"), dtCheckupPrint.Rows(0)("LDLコレステロール下限")) & "'"
                strSQL &= ", '" & dtCheckupPrint.Rows(0)("LDLコレステロール上限") & "'"
                strSQL &= ", '" & dtCheckupPrint.Rows(0)("LDLコレステロール下限") & "'"
                '==================================================
                'GOT
                '==================================================
                strSQL &= ", '" & dtCheckupPrint.Rows(0)("GOT") & "'"
                strSQL &= ", '" & WhichUpDown(dtCheckupPrint.Rows(0)("GOT"), dtCheckupPrint.Rows(0)("GOT上限"), dtCheckupPrint.Rows(0)("GOT下限")) & "'"
                strSQL &= ", '" & dtCheckupPrint.Rows(0)("GOT上限") & "'"
                strSQL &= ", '" & dtCheckupPrint.Rows(0)("GOT下限") & "'"
                '==================================================
                'GPT
                '==================================================
                strSQL &= ", '" & dtCheckupPrint.Rows(0)("GPT") & "'"
                strSQL &= ", '" & WhichUpDown(dtCheckupPrint.Rows(0)("GPT"), dtCheckupPrint.Rows(0)("GPT上限"), dtCheckupPrint.Rows(0)("GPT下限")) & "'"
                strSQL &= ", '" & dtCheckupPrint.Rows(0)("GPT上限") & "'"
                strSQL &= ", '" & dtCheckupPrint.Rows(0)("GPT下限") & "'"
                '==================================================
                'ガンマGTP
                '==================================================
                strSQL &= ", '" & dtCheckupPrint.Rows(0)("ガンマGTP") & "'"
                strSQL &= ", '" & WhichUpDown(dtCheckupPrint.Rows(0)("ガンマGTP"), dtCheckupPrint.Rows(0)("ガンマGTP上限"), dtCheckupPrint.Rows(0)("ガンマGTP下限")) & "'"
                strSQL &= ", '" & dtCheckupPrint.Rows(0)("ガンマGTP上限") & "'"
                strSQL &= ", '" & dtCheckupPrint.Rows(0)("ガンマGTP下限") & "'"
                '==================================================
                'クレアチニン
                '==================================================
                strSQL &= ", '" & PeriodCheck(dtCheckupPrint.Rows(0)("クレアチニン"), 2) & "'"
                strSQL &= ", '" & WhichUpDown(dtCheckupPrint.Rows(0)("クレアチニン"), dtCheckupPrint.Rows(0)("クレアチニン上限"), dtCheckupPrint.Rows(0)("クレアチニン下限")) & "'"
                strSQL &= ", '" & PeriodCheck(dtCheckupPrint.Rows(0)("クレアチニン上限"), 2) & "'"
                strSQL &= ", '" & PeriodCheck(dtCheckupPrint.Rows(0)("クレアチニン下限"), 2) & "'"
                '==================================================
                '尿酸
                '==================================================
                strSQL &= ", '" & PeriodCheck(dtCheckupPrint.Rows(0)("尿酸"), 1) & "'"
                strSQL &= ", '" & WhichUpDown(dtCheckupPrint.Rows(0)("尿酸"), dtCheckupPrint.Rows(0)("尿酸上限"), dtCheckupPrint.Rows(0)("尿酸下限")) & "'"
                strSQL &= ", '" & PeriodCheck(dtCheckupPrint.Rows(0)("尿酸上限"), 1) & "'"
                strSQL &= ", '" & PeriodCheck(dtCheckupPrint.Rows(0)("尿酸下限"), 1) & "'"
                '==================================================
                '赤血球
                '==================================================
                strSQL &= ", '" & dtCheckupPrint.Rows(0)("赤血球") & "'"
                strSQL &= ", '" & WhichUpDown(dtCheckupPrint.Rows(0)("赤血球"), dtCheckupPrint.Rows(0)("赤血球上限"), dtCheckupPrint.Rows(0)("赤血球下限")) & "'"
                strSQL &= ", '" & dtCheckupPrint.Rows(0)("赤血球上限") & "'"
                strSQL &= ", '" & dtCheckupPrint.Rows(0)("赤血球下限") & "'"
                '==================================================
                '血色素量
                '==================================================
                strSQL &= ", '" & PeriodCheck(dtCheckupPrint.Rows(0)("血色素量"), 1) & "'"
                strSQL &= ", '" & WhichUpDown(dtCheckupPrint.Rows(0)("血色素量"), dtCheckupPrint.Rows(0)("血色素量上限"), dtCheckupPrint.Rows(0)("血色素量下限")) & "'"
                strSQL &= ", '" & PeriodCheck(dtCheckupPrint.Rows(0)("血色素量上限"), 1) & "'"
                strSQL &= ", '" & PeriodCheck(dtCheckupPrint.Rows(0)("血色素量下限"), 1) & "'"
                '==================================================
                '空腹時血糖
                '==================================================
                strSQL &= ", '" & dtCheckupPrint.Rows(0)("空腹時血糖") & "'"
                strSQL &= ", '" & WhichUpDown(dtCheckupPrint.Rows(0)("空腹時血糖"), dtCheckupPrint.Rows(0)("空腹時血糖上限"), dtCheckupPrint.Rows(0)("空腹時血糖下限")) & "'"
                strSQL &= ", '" & dtCheckupPrint.Rows(0)("空腹時血糖上限") & "'"
                strSQL &= ", '" & dtCheckupPrint.Rows(0)("空腹時血糖下限") & "'"
                '==================================================
                '随時血糖
                '==================================================
                strSQL &= ", '" & dtCheckupPrint.Rows(0)("随時血糖") & "'"
                strSQL &= ", '" & WhichUpDown(dtCheckupPrint.Rows(0)("随時血糖"), dtCheckupPrint.Rows(0)("随時血糖上限"), dtCheckupPrint.Rows(0)("随時血糖下限")) & "'"
                strSQL &= ", '" & dtCheckupPrint.Rows(0)("随時血糖上限") & "'"
                strSQL &= ", '" & dtCheckupPrint.Rows(0)("随時血糖下限") & "'"
                '==================================================
                'HbA1c
                '==================================================
                strSQL &= ", '" & PeriodCheck(dtCheckupPrint.Rows(0)("HbA1c"), 1) & "'"
                strSQL &= ", '" & WhichUpDown(dtCheckupPrint.Rows(0)("HbA1c"), dtCheckupPrint.Rows(0)("HbA1c上限"), dtCheckupPrint.Rows(0)("HbA1c下限")) & "'"
                strSQL &= ", '" & PeriodCheck(dtCheckupPrint.Rows(0)("HbA1c上限"), 1) & "'"
                strSQL &= ", '" & PeriodCheck(dtCheckupPrint.Rows(0)("HbA1c下限"), 1) & "'"
                '==================================================
                'その他
                '==================================================
                strSQL &= ", '" & dtCheckupPrint.Rows(0)("受診検査機関名称") & "'"
                '会場局名称(「人間ドック省略」の場合は「他の健診機関の結果利用による省略」をセット)
                If dtCheckupPrint.Rows(0)("会場局名称") = "人間ドック省略" Then
                    strSQL &= ", '他の健診機関の結果利用による省略'"
                Else
                    strSQL &= ", '" & dtCheckupPrint.Rows(0)("会場局名称").ToString.Replace("'", "''") & "'"
                End If
                strSQL &= ", '" & dtCheckupPrint.Rows(0)("総合判定").ToString.Replace("'", "''") & "'"
                strSQL &= ", '" & dtCheckupPrint.Rows(0)("健診実施医師名").ToString.Replace("'", "''") & "'"
                strSQL &= ", '" & dtCheckupPrint.Rows(0)("判定医師名").ToString.Replace("'", "''") & "'"
                '判定日付(yyyyMMddをyyyy/MM/ddに変換してセットする)
                strSQL &= ", '" & Date.Parse(Format(CInt(dtCheckupPrint.Rows(0)("判定日付")), "0000/00/00")) & "'"
                '==================================================
                '判定(値が「未実施（不要）」の場合は空欄にする
                '==================================================
                strSQL &= ", '" & IIf(dtCheckupPrint.Rows(0)("視力判定") = "未実施（不要）", "", dtCheckupPrint.Rows(0)("視力判定")).ToString.Replace("'", "''") & "'"
                strSQL &= ", '" & IIf(dtCheckupPrint.Rows(0)("聴力判定") = "未実施（不要）", "", dtCheckupPrint.Rows(0)("聴力判定")).ToString.Replace("'", "''") & "'"
                strSQL &= ", '" & IIf(dtCheckupPrint.Rows(0)("血圧判定") = "未実施（不要）", "", dtCheckupPrint.Rows(0)("血圧判定")).ToString.Replace("'", "''") & "'"
                strSQL &= ", '" & IIf(dtCheckupPrint.Rows(0)("尿糖判定") = "未実施（不要）", "", dtCheckupPrint.Rows(0)("尿糖判定")).ToString.Replace("'", "''") & "'"
                strSQL &= ", '" & IIf(dtCheckupPrint.Rows(0)("尿蛋白判定") = "未実施（不要）", "", dtCheckupPrint.Rows(0)("尿蛋白判定")).ToString.Replace("'", "''") & "'"
                strSQL &= ", '" & IIf(dtCheckupPrint.Rows(0)("血中脂質判定") = "未実施（不要）", "", dtCheckupPrint.Rows(0)("血中脂質判定")).ToString.Replace("'", "''") & "'"
                strSQL &= ", '" & IIf(dtCheckupPrint.Rows(0)("肝機能判定") = "未実施（不要）", "", dtCheckupPrint.Rows(0)("肝機能判定")).ToString.Replace("'", "''") & "'"
                strSQL &= ", '" & IIf(dtCheckupPrint.Rows(0)("腎機能判定") = "未実施（不要）", "", dtCheckupPrint.Rows(0)("腎機能判定")).ToString.Replace("'", "''") & "'"
                strSQL &= ", '" & IIf(dtCheckupPrint.Rows(0)("尿酸判定") = "未実施（不要）", "", dtCheckupPrint.Rows(0)("尿酸判定")).ToString.Replace("'", "''") & "'"
                strSQL &= ", '" & IIf(dtCheckupPrint.Rows(0)("血液判定") = "未実施（不要）", "", dtCheckupPrint.Rows(0)("血液判定")).ToString.Replace("'", "''") & "'"
                strSQL &= ", '" & IIf(dtCheckupPrint.Rows(0)("血糖判定") = "未実施（不要）", "", dtCheckupPrint.Rows(0)("血糖判定")).ToString.Replace("'", "''") & "'"
                strSQL &= ", '" & IIf(dtCheckupPrint.Rows(0)("胸部X線判定結果") = "未実施（不要）", "", dtCheckupPrint.Rows(0)("胸部X線判定結果")).ToString.Replace("'", "''") & "'"
                strSQL &= ", '" & IIf(dtCheckupPrint.Rows(0)("心電図判定結果") = "未実施（不要）", "", dtCheckupPrint.Rows(0)("心電図判定結果")).ToString.Replace("'", "''") & "'"
                strSQL &= ", '" & IIf(dtCheckupPrint.Rows(0)("総合成績判定") = "未実施（不要）", "", dtCheckupPrint.Rows(0)("総合成績判定")).ToString.Replace("'", "''") & "'"
                '==================================================
                'その他
                '==================================================
                strSQL &= ", '" & dtCheckupPrint.Rows(0)("就業区分").ToString.Replace("'", "''") & "'"
                '==================================================
                '改行を生かす項目
                '==================================================
                strSQL &= ", '" & dtCheckupPrint.Rows(0)("胸部X線所見").ToString.Replace("\n", vbNewLine).Replace("'", "''") & "'"
                strSQL &= ", '" & dtCheckupPrint.Rows(0)("胸部X線判定").ToString.Replace("\n", vbNewLine).Replace("'", "''") & "'"
                strSQL &= ", '" & dtCheckupPrint.Rows(0)("心電図所見").ToString.Replace("\n", vbNewLine).Replace("'", "''") & "'"
                strSQL &= ", '" & dtCheckupPrint.Rows(0)("心電図判定").ToString.Replace("\n", vbNewLine).Replace("'", "''") & "'"
                strSQL &= ", '" & dtCheckupPrint.Rows(0)("既往歴").ToString.Replace("\n", vbNewLine).Replace("'", "''") & "'"
                strSQL &= ", '" & dtCheckupPrint.Rows(0)("自覚症状").ToString.Replace("\n", vbNewLine).Replace("'", "''") & "'"
                strSQL &= ", '" & dtCheckupPrint.Rows(0)("診察所見").ToString.Replace("\n", vbNewLine).Replace("'", "''") & "'"
                strSQL &= ", '" & dtCheckupPrint.Rows(0)("総合コメント").ToString.Replace("\n", vbNewLine).Replace("'", "''") & "'"
                strSQL &= ", '" & dtCheckupPrint.Rows(0)("産業医の意見").ToString.Replace("\n", vbNewLine).Replace("'", "''") & "'"
				'==================================================
				'その他
				'==================================================
				'QRコード
				'QRコードの算出(システムID(15)＋帳票種別ID(1)＋エラーフラグ(1))
				'2018/05/07
				'QRコードは再計算せずにあらかじめT_印刷ソートから取得しておいた値をセットする
				'strQRCode = dtCheckupPrint.Rows(0)("システムID") & "4" & "0"
				'            strSQL &= ", '" & strQRCode & "'"
				strSQL &= ", '" & strCheckupQR & "'"

				strSQL &= ")"
                sqlProcess.DB_UPDATE(strSQL)

                'T_リーフレット印刷
                strSQL = "SELECT システムID "
                strSQL &= "FROM T_リーフレット "
                strSQL &= "WHERE ロットID = '" & strLotID & "' "
                strSQL &= "AND レコード番号 = " & iRecordNumber
                Dim dtLeafletSystemID As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
                If dtLeafletSystemID.Rows.Count > 0 Then
                    strSQL = "SELECT T1.ロットID, T1.レコード番号, T1.システムID, T1.会社, T1.所属事業所, "
                    strSQL &= "T1.所属部名 + '　' + T1.所属課名 AS 所属部課名, "
                    strSQL &= "T1.氏名姓 + ' ' + T1.氏名名 + '　様' AS 氏名, "
                    strSQL &= "T2.会社名 AS 局所会社名, T3.健康管理施設名, T3.郵便番号, T3.住所, T3.電話番号, "
                    strSQL &= "T4.年度, T1.帳票タイプ, T4.判定票CSV, T4.リーフレットCSV, "
                    strSQL &= "ISNULL(T4.要修正日時, '1900/01/01') AS 要修正日時, ISNULL(T4.修正済日時, '1900/01/01') AS 修正済日時 "
                    strSQL &= "FROM T_リーフレット AS T1 INNER JOIN "
                    strSQL &= "M_局所 AS T2 ON T1.会社コード = T2.会社コード AND T1.所属事業所コード = T2.局所コード INNER JOIN "
                    strSQL &= "M_健康管理施設 AS T3 ON T2.健康管理施設コード = T3.健康管理施設コード INNER JOIN "
                    strSQL &= "T_判定票管理 AS T4 ON T1.ロットID = T4.ロットID AND T1.レコード番号 = T4.レコード番号 INNER JOIN "
                    strSQL &= "M_帳票タイプ AS T5 ON T1.帳票タイプ = T5.帳票タイプ "
                    strSQL &= "WHERE T1.ロットID = '" & strLotID & "' "
                    strSQL &= "AND T1.システムID = '" & dtLeafletSystemID.Rows(0)("システムID") & "' "
                    strSQL &= "AND T4.リーフレット無効 != 1 "
                    strSQL &= "ORDER BY T5.ID"
                    Dim dtLeafletPrint As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)

                    '帳票タイプ単位の処理
                    For i As Integer = 0 To dtLeafletPrint.Rows.Count - 1
                        '必要項目のみUPDATEする
                        strSQL = "UPDATE T_リーフレット印刷 SET "
                        strSQL &= "システムID = '" & dtLeafletSystemID.Rows(0)("システムID") & "'"
                        strSQL &= ", 所属事業所 = '" & dtLeafletPrint.Rows(i)("所属事業所").ToString.Replace("'", "''") & "'"
                        strSQL &= ", 所属部課名 = '" & dtLeafletPrint.Rows(i)("所属部課名").ToString.Trim().Replace("'", "''") & "'"
                        strSQL &= ", 氏名 = '" & dtLeafletPrint.Rows(i)("氏名").ToString.Replace("'", "''") & "'"
                        strSQL &= ", 局所会社名 = '" & dtLeafletPrint.Rows(i)("局所会社名").ToString.Replace("'", "''") & "'"
                        strSQL &= ", 健康管理施設名 = '" & dtLeafletPrint.Rows(i)("健康管理施設名").ToString.Replace("'", "''") & "'"
                        strSQL &= ", 郵便番号 = '" & dtLeafletPrint.Rows(i)("郵便番号").ToString.Replace("'", "''") & "'"
                        strSQL &= ", 住所 = '" & dtLeafletPrint.Rows(i)("住所").ToString.Replace("'", "''") & "'"
                        strSQL &= ", 電話番号 = '" & dtLeafletPrint.Rows(i)("電話番号").ToString.Replace("'", "''") & "'"
                        strSQL &= ", 年度 = '" & dtLeafletPrint.Rows(i)("年度").ToString.Replace("'", "''") & "'"
                        strSQL &= ", 帳票タイプ = '" & dtLeafletPrint.Rows(i)("帳票タイプ").ToString.Replace("'", "''") & "'"
                        Dim strValue1 As String = ""
                        Dim strValue2 As String = ""
                        Dim strValue3 As String = ""
                        Dim blnResult As Boolean = GetResultValue(dtLeafletPrint.Rows(i)("帳票タイプ"), strLotID, dtLeafletPrint.Rows(i)("システムID"), strValue1, strValue2, strValue3)
                        strSQL &= ", 結果値1 = '" & strValue1 & "'"
                        strSQL &= ", 結果値2 = '" & strValue2 & "'"
						strSQL &= ", 結果値3 = '" & strValue3 & "' "
						'2018/05/07
						'QRコードは更新対象としない
						'strQRCode = dtLeafletPrint.Rows(i)("システムID") & "5" & "0" & (i + 1).ToString 'エラーフラグ0固定、カレントSEQ付加
						'strSQL &= ", QRコード = '" & strQRCode & "' "
						strSQL &= "WHERE ロットID = '" & strLotID & "' "
                        strSQL &= "AND レコード番号 = " & iRecordNumber & " "
                        strSQL &= "AND 帳票タイプ = '" & dtLeafletPrint.Rows(i)("帳票タイプ") & "'"
                        sqlProcess.DB_UPDATE(strSQL)

                    Next

                End If

            End If

        Catch ex As Exception

            Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & ex.StackTrace)
            MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally

            sqlProcess.Close()

        End Try

    End Sub

    ''' <summary>
    ''' 上限下限を判断して「↑」「↓」を返す
    ''' </summary>
    ''' <param name="strValue"></param>
    ''' <param name="strUp"></param>
    ''' <param name="strDown"></param>
    ''' <param name="iPeriod"></param>
    ''' <returns></returns>
    Private Function WhichUpDown(ByVal strValue As String, ByVal strUp As String, ByVal strDown As String) As String

        '上限値、下限値が設定されていない、又は結果値が空白の場合は空欄を返す
        If IsNull(strUp) And IsNull(strDown) Then
            '上限値、下限値共に設定されていない
            Return ""
        ElseIf IsNull(strValue) Then
            '結果値が設定されていない
            Return ""
        End If

        If IsNull(strUp) Then
            '上限値だけがNULL
            '下限値のみ比較する
            If Double.Parse(strValue) < Double.Parse(strDown) Then
                '下限より小さい
                Return "↓"
            Else
                '範囲内
                Return ""
            End If
        ElseIf IsNull(strDown) Then
            '下限値だけがNULL
            '上限値のみ比較する
            If Double.Parse(strValue) > Double.Parse(strUp) Then
                '上限より大きい
                Return "↑"
            Else
                '範囲内
                Return ""
            End If
        Else
            'どちらも値があった場合
            If Double.Parse(strValue) > Double.Parse(strUp) Then
                '上限より大きい
                Return "↑"
            ElseIf Double.Parse(strValue) < Double.Parse(strDown) Then
                '下限より小さい
                Return "↓"
            Else
                '範囲内
                Return ""
            End If

        End If

    End Function

    ''' <summary>
    ''' 帳票タイプからリーフレットに出力するべき値を取得する
    ''' </summary>
    ''' <param name="strType"></param>
    ''' <param name="strValue1"></param>
    ''' <param name="strValue2"></param>
    ''' <param name="strVAlue3"></param>
    ''' <returns></returns>
    Private Function GetResultValue(ByVal strType As String, ByVal strLotID As String, ByVal strSystemID As String, ByRef strValue1 As String, ByRef strValue2 As String, ByRef strVAlue3 As String) As Boolean

        Dim sqlProcess As New SQLProcess
        Dim strSQL As String = ""

		'2018/10/02
		'かんぽ生命用帳票タイプ（肝機能5、血糖5、脂質5、尿酸5、貧血5）の追加
		Try
            '帳票タイプによって、結果値1、結果値2、結果値3に入る値を変える
            Select Case strType
                Case "血圧3", "血圧4"
                    strSQL = "SELECT 血圧1回拡張期, 血圧1回収縮期 FROM T_リーフレット "
                    strSQL &= "WHERE ロットID = '" & strLotID & "' "
                    strSQL &= "AND システムID = '" & strSystemID & "' "
                    strSQL &= "AND 帳票タイプ = '" & strType & "'"
                    Dim dtValue As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
                    strValue1 = dtValue.Rows(0)("血圧1回収縮期")  '結果値1が収縮期
                    strValue2 = dtValue.Rows(0)("血圧1回拡張期")
                    strVAlue3 = ""

				Case "血糖3", "血糖4", "血糖5"
					strSQL = "SELECT HbA1c, 空腹時血糖, 随時血糖 FROM T_リーフレット "
                    strSQL &= "WHERE ロットID = '" & strLotID & "' "
                    strSQL &= "AND システムID = '" & strSystemID & "' "
                    strSQL &= "AND 帳票タイプ = '" & strType & "'"
                    Dim dtValue As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
					strValue1 = dtValue.Rows(0)("HbA1c")
					'2018/06/19
					'文言に(空腹)(随時)を付与
					If IsNull(dtValue.Rows(0)("空腹時血糖")) Then
						'空腹時血糖がNULLの場合のみ随時血糖を採用する
						strValue2 = "(随時) " & dtValue.Rows(0)("随時血糖")
					Else
						strValue2 = "(空腹) " & dtValue.Rows(0)("空腹時血糖")
					End If
                    strVAlue3 = ""

				Case "脂質3", "脂質4", "脂質5"
					strSQL = "SELECT LDLコレステロール, HDLコレステロール, 中性脂肪 FROM T_リーフレット "
                    strSQL &= "WHERE ロットID = '" & strLotID & "' "
                    strSQL &= "AND システムID = '" & strSystemID & "' "
                    strSQL &= "AND 帳票タイプ = '" & strType & "'"
                    Dim dtValue As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
                    strValue1 = dtValue.Rows(0)("LDLコレステロール")
                    strValue2 = dtValue.Rows(0)("HDLコレステロール")
                    strVAlue3 = dtValue.Rows(0)("中性脂肪")

				Case "肝機能3", "肝機能4", "肝機能5"
					strSQL = "SELECT GOT, GPT, ガンマGTP FROM T_リーフレット "
                    strSQL &= "WHERE ロットID = '" & strLotID & "' "
                    strSQL &= "AND システムID = '" & strSystemID & "' "
                    strSQL &= "AND 帳票タイプ = '" & strType & "'"
                    Dim dtValue As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
                    strValue1 = dtValue.Rows(0)("GOT")
                    strValue2 = dtValue.Rows(0)("GPT")
                    strVAlue3 = dtValue.Rows(0)("ガンマGTP")

				Case "貧血3", "貧血4", "貧血5"
					strSQL = "SELECT 血色素量 FROM T_リーフレット "
                    strSQL &= "WHERE ロットID = '" & strLotID & "' "
                    strSQL &= "AND システムID = '" & strSystemID & "' "
                    strSQL &= "AND 帳票タイプ = '" & strType & "'"
                    Dim dtValue As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
                    strValue1 = dtValue.Rows(0)("血色素量")
                    strValue2 = ""
                    strVAlue3 = ""

				Case "尿酸3", "尿酸4", "尿酸5"
					strSQL = "SELECT 尿酸 FROM T_リーフレット "
                    strSQL &= "WHERE ロットID = '" & strLotID & "' "
                    strSQL &= "AND システムID = '" & strSystemID & "' "
                    strSQL &= "AND 帳票タイプ = '" & strType & "'"
                    Dim dtValue As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
                    strValue1 = dtValue.Rows(0)("尿酸")
                    strValue2 = ""
                    strVAlue3 = ""

					'2018/07/31
					'腎機能、BMI、BMIMAPの追加
				Case "腎機能3"
					strSQL = "SELECT クレアチニン FROM T_リーフレット "
					strSQL &= "WHERE ロットID = '" & strLotID & "' "
					strSQL &= "AND システムID = '" & strSystemID & "' "
					strSQL &= "AND 帳票タイプ = '" & strType & "'"
					Dim dtValue As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
					strValue1 = dtValue.Rows(0)("クレアチニン")
					strValue2 = ""
					strVAlue3 = ""

				Case "BMI"
					strSQL = "SELECT BMI FROM T_リーフレット "
					strSQL &= "WHERE ロットID = '" & strLotID & "' "
					strSQL &= "AND システムID = '" & strSystemID & "' "
					strSQL &= "AND 帳票タイプ = '" & strType & "'"
					Dim dtValue As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
					strValue1 = dtValue.Rows(0)("BMI")
					strValue2 = ""
					strVAlue3 = ""

				Case "BMIMAP"
					strValue1 = ""
					strValue2 = ""
					strVAlue3 = ""

			End Select

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
    ''' トータルページ、シーケンスからOMRを抽出する
    ''' </summary>
    ''' <param name="iTotal"></param>
    ''' <param name="iSeq">1～32までの通番</param>
    ''' <param name="iStart">スタート：1、それ以外：0</param>
    ''' <param name="iEnd">エンド：1、それ以外：0</param>
    ''' <param name="strBOC"></param>
    ''' <param name="strEOC"></param>
    ''' <param name="strPAR"></param>
    ''' <param name="strWAS1"></param>
    ''' <param name="strWAS2"></param>
    ''' <param name="strWAS3"></param>
    ''' <param name="strWAS4"></param>
    ''' <param name="strWAS5"></param>
    ''' <param name="strWAS6"></param>
    ''' <returns></returns>
    Private Function GetOMR(ByVal iTotal As Integer, ByVal iSeq As Integer, ByVal iStart As Integer, ByVal iEnd As Integer,
                            ByRef strBOC As String, ByRef strEOC As String, ByRef strPAR As String,
                            ByRef strWAS1 As String, ByRef strWAS2 As String, ByRef strWAS3 As String,
                            ByRef strWAS4 As String, ByRef strWAS5 As String, ByRef strWAS6 As String) As Boolean

        'シーケンスを2進数変換
        Dim strBin As String = DecToBin(iSeq)
        Dim iTotalFlag As Integer = 0   'フラグの立っている本数を保持する
        'BOC
        If iStart = 1 Then
            strBOC = "|"
            iTotalFlag += 1
        Else
            strBOC = ""
        End If
        'EOC
        If iEnd = 1 Then
            strEOC = "|"
            iTotalFlag += 1
        Else
            strEOC = ""
        End If

        '2進数を1の位から回し「1」が立っていたら文字列「|」をセットする
        For iPosition As Integer = strBin.Length To 1 Step -1
            Select Case iPosition
                Case 6
                    'WAS1
                    If Strings.Mid(strBin, iPosition, 1) = "1" Then
                        strWAS1 = "|"
                        iTotalFlag += 1
                    Else
                        strWAS1 = ""
                    End If

                Case 5
                    'WAS2
                    If Strings.Mid(strBin, iPosition, 1) = "1" Then
                        strWAS2 = "|"
                        iTotalFlag += 1
                    Else
                        strWAS2 = ""
                    End If

                Case 4
                    'WAS3
                    If Strings.Mid(strBin, iPosition, 1) = "1" Then
                        strWAS3 = "|"
                        iTotalFlag += 1
                    Else
                        strWAS3 = ""
                    End If

                Case 3
                    'WAS4
                    If Strings.Mid(strBin, iPosition, 1) = "1" Then
                        strWAS4 = "|"
                        iTotalFlag += 1
                    Else
                        strWAS4 = ""
                    End If

                Case 2
                    'WAS5
                    If Strings.Mid(strBin, iPosition, 1) = "1" Then
                        strWAS5 = "|"
                        iTotalFlag += 1
                    Else
                        strWAS5 = ""
                    End If

                Case 1
                    'WAS6
                    If Strings.Mid(strBin, iPosition, 1) = "1" Then
                        strWAS6 = "|"
                        iTotalFlag += 1
                    Else
                        strWAS6 = ""
                    End If

            End Select

        Next

        'フラグ総数を2で割った余りが1だった場合、PARを立てる
        If iTotalFlag Mod 2 = 1 Then
            strPAR = "|"
        Else
            strPAR = ""
        End If

        Return True

        'Dim sqlProcess As New SQLProcess
        'Dim strSQL As String = ""

        'Try
        '	strSQL = "SELECT 枚数, シーケンス, BOC, EOC, PAR, WAS1, WAS2, WAS3 FROM M_OMR "
        '	strSQL &= "WHERE 枚数 = " & iTotal & " "
        '	strSQL &= "AND シーケンス = " & iSeq
        '	Dim dtOMR As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
        '	strBOC = dtOMR.Rows(0)("BOC")
        '	strEOC = dtOMR.Rows(0)("EOC")
        '	strPAR = dtOMR.Rows(0)("PAR")
        '	strWAS1 = dtOMR.Rows(0)("WAS1")
        '	strWAS2 = dtOMR.Rows(0)("WAS2")
        '	strWAS3 = dtOMR.Rows(0)("WAS3")
        '	Return True

        'Catch ex As Exception

        '	Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & ex.StackTrace)
        '	MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '	Return False

        'Finally

        '	sqlProcess.Close()

        'End Try

    End Function

    ''' <summary>
    ''' T_複数封筒計算にINSERTする
    ''' </summary>
    ''' <param name="strLotID"></param>
    ''' <param name="iRecordNumber"></param>
    ''' <param name="iSeq"></param>
    ''' <param name="iPrintID"></param>
    ''' <param name="iFormCategory"></param>
    ''' <param name="dblLabel"></param>
    ''' <param name="dblCheckupList"></param>
    ''' <param name="dblLeafletList"></param>
    ''' <param name="dblCheckup"></param>
    ''' <param name="dblTotal"></param>
    Private Sub MultiEnvelopeInsert(ByVal strLotID As String, ByVal iRecordNumber As Integer, ByVal iSeq As Integer, ByVal iPrintID As Integer, ByVal iFormCategory As Integer, ByVal dblLabel As Double, ByVal dblCheckupList As Double, ByVal dblLeafletList As Double, ByVal dblCheckup As Double, ByVal dblTotal As Double)

        Dim sqlProcess As New SQLProcess
        Dim strSQL As String = ""

        Try
            '初回ループは必ずラベルレコードを追加
            strSQL = "INSERT INTO T_複数封筒計算 (ロットID, レコード番号, シーケンス, 印刷ID, 帳票種別ID, ラベル重量, 対象者一覧重量, 保健指導名簿重量, 判定票重量, 累積重量) VALUES("
            strSQL &= "'" & strLotID & "'"  'ロットID
            strSQL &= ", " & iRecordNumber 'レコード番号、0固定
            strSQL &= ", " & iSeq 'シーケンス(事業所内での通番)
            strSQL &= ", " & iPrintID   '印刷ID
            strSQL &= ", " & iFormCategory  '帳票種別ID
            strSQL &= ", " & dblLabel 'ラベルの重量
            strSQL &= ", " & dblCheckupList '対象者一覧の重量
            strSQL &= ", " & dblLeafletList '対象者名簿の重量
            strSQL &= ", " & dblCheckup '判定票(リーフレット込)の重量
            strSQL &= ", " & dblTotal '累積重量
            strSQL &= ")"
            sqlProcess.DB_UPDATE(strSQL)

        Catch ex As Exception

            Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & ex.StackTrace)
            MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally

            sqlProcess.Close()

        End Try

    End Sub

    ''' <summary>
    ''' ラベル印刷
    ''' </summary>
    ''' <param name="strLotID"></param>
    ''' <param name="blnPrintWeightHeader"></param>
    ''' <param name="strWeightHeader"></param>
    ''' <param name="iFrom">ラベル連番FROM</param>
    ''' <param name="iTo">ラベル連番TO</param>
    Public Sub PrintLabel(ByVal strLotID As String, ByVal blnPrintWeightHeader As Boolean, ByVal strWeightHeader As String, ByVal iFrom As Integer, ByVal iTo As Integer)

        Dim sqlProcess As New SQLProcess
        Dim strSQL As String = ""

        '現在の通常使うプリンタ名を取得
        'プリンタ名の取得
        'Finallyで通常使うプリンタを戻す
        Dim strDefaultPrinter As String = pd.PrinterSettings.PrinterName
        XmlSettings.LoadFromXmlFile()
        'プリンタドライバの切り替え
        SetDefaultPrinter(XmlSettings.Instance.Printer_Label)

        Try
            'strSQL = "SELECT T1.ロットID, T1.会社コード, T1.所属事業所コード, T3.会社名 AS 会社, T3.局所名 AS 所属事業所, "
            'strSQL &= "T2.印刷ID, T2.分数, T1.重量ヘッダ, T4.備考 AS 封筒サイズ, T1.ラベル連番, T2.QR "
            'strSQL &= "FROM T_印刷管理 AS T1 INNER JOIN "
            'strSQL &= "T_印刷ソート AS T2 ON T1.ロットID = T2.ロットID AND T1.会社コード = T2.会社コード "
            'strSQL &= "AND T1.所属事業所コード = T2.所属事業所コード AND T1.印刷ID = T2.印刷ID INNER JOIN "
            'strSQL &= "M_局所 AS T3 ON T1.会社コード = T3.会社コード AND T1.所属事業所コード = T3.局所コード INNER JOIN "
            'strSQL &= "M_重量ヘッダ AS T4 ON T1.重量ヘッダ = T4.重量ヘッダ "
            'strSQL &= "WHERE T2.帳票種別ID = 0 "
            'strSQL &= "AND T1.ロットID = '" & strLotID & "' "
            strSQL = "SELECT T1.ロットID, T1.会社コード, T4.会社名, T1.所属事業所コード, T4.局所名, "
            strSQL &= "T4.郵便番号, T4.住所, T1.QR, T2.重量ヘッダ, T3.備考 AS 封筒サイズ, T2.ラベル連番, T1.分数 "
            strSQL &= "FROM T_印刷ソート AS T1 INNER JOIN "
            strSQL &= "T_印刷管理 AS T2 ON T1.ロットID = T2.ロットID "
            strSQL &= "AND T1.会社コード = T2.会社コード "
            strSQL &= "AND T1.所属事業所コード = T2.所属事業所コード "
            strSQL &= "AND T1.印刷ID = T2.印刷ID INNER JOIN "
            strSQL &= "M_重量ヘッダ AS T3 ON T2.重量ヘッダ = T3.重量ヘッダ INNER JOIN "
            strSQL &= "M_局所 AS T4 ON T1.会社コード = T4.会社コード "
            strSQL &= "AND T1.所属事業所コード = T4.局所コード "
            strSQL &= "WHERE T1.ロットID = '" & strLotID & "' "
            strSQL &= "AND T1.帳票種別ID = 0 "
            strSQL &= "AND T2.ラベル連番 BETWEEN " & iFrom & " AND " & iTo & " "

            If blnPrintWeightHeader Then
                '重量ヘッダ単位
                If strWeightHeader = "全て" Then
                    'ロット内の全てのラベルなので検索条件の追加は無し
                Else
                    strSQL &= "AND T2.重量ヘッダ = '" & strWeightHeader & "' "
                End If
            Else
                '個別印刷
                '2次元配列を回す

            End If
            strSQL &= "ORDER BY T2.ラベル連番"
            '印刷処理
            Print(strSQL, PrintCategory.Label)

        Catch ex As Exception

            Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & ex.StackTrace)
            MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally

            sqlProcess.Close()
            '設定されていた通常使うプリンタに戻す
            SetDefaultPrinter(strDefaultPrinter)

        End Try

    End Sub

    ''' <summary>
    ''' 判定票印刷
    ''' </summary>
    ''' <param name="strLotID">対象ロットID</param>
    Public Sub PrintCheckup(ByVal strLotID As String, ByVal blnPrintWeightHeader As Boolean, ByVal strWeightHeader As String, Optional ByVal iRecordNumber As Integer = 0)

        Dim sqlProcess As New SQLProcess
        Dim strSQL As String = ""
        Dim dt As DataTable = Nothing

        '現在の通常使うプリンタ名を取得
        'プリンタ名の取得
        'Finallyで通常使うプリンタを戻す
        Dim strDefaultPrinter As String = pd.PrinterSettings.PrinterName
        XmlSettings.LoadFromXmlFile()
        'プリンタドライバの切り替え
        SetDefaultPrinter(XmlSettings.Instance.Printer_Result)

        Try

            If iRecordNumber = 0 Then
                'ロットID単位の全印刷
                'ロットID
                'ソート順
                '	重量ヘッダ(H～A順)
                '	会社コード
                '	所属事業所コード
                '	所属部名(NULLは最後)
                '	所属課名(NULLは最後)
                '	社員コード

                '印刷順
                '印刷ID単位
                '	対象者一覧(緑紙)
                '	保健指導名簿(緑紙)
                '	判定票(白紙)
                '	リーフレット(白紙)

                'T_印刷管理内の対象ロットを重量ヘッダ、会社コード、所属事業所コードを考慮して回す
                strSQL = "SELECT ロットID, 会社コード, 所属事業所コード, 印刷ID, 重量ヘッダ, ラベル連番 "
                strSQL &= "FROM T_印刷管理 "
                strSQL &= "WHERE ロットID = '" & strLotID & "' "
                If blnPrintWeightHeader Then
                    '重量ヘッダ単位
                    If strWeightHeader = "全て" Then
                        'ロット内の全てのラベルなので検索条件の追加は無し
                        ''==================================================
                        ''2017/07/20
                        ''緊急対応
                        'strSQL &= "AND ラベル連番 BETWEEN 128 AND 134 "
                        ''==================================================
                    Else
                        strSQL &= "AND 重量ヘッダ = '" & strWeightHeader & "' "
                        ''==================================================
                        ''2017/07/20
                        ''緊急対応
                        'strSQL &= "AND ラベル連番 BETWEEN 18 AND 25 "
                        ''==================================================
                    End If
                Else
                    '個別印刷
                    '2次元配列を回す

                End If

                ''==================================================
                ''※テスト用、本番前にコメントアウト！
                'strSQL &= "AND 会社コード = '2001' "
                'strSQL &= "AND 所属事業所コード = '970270' "
                ''==================================================
                strSQL &= "ORDER BY ラベル連番"
                'strSQL &= "ORDER BY 重量ヘッダ DESC, 会社コード, 所属事業所コード"
                Dim dtPrintManage As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
                Dim strHeaderSheet As String = ""   '前回ヘッダシート格納用
                Dim strImportDate As String = strLotID.Substring(0, 8)  'ロットIDの先頭8桁(インポート日)を取得する

                For iRow As Integer = 0 To dtPrintManage.Rows.Count - 1
                    '会社コード、所属事業所コード、重量ヘッダ単位で回す
                    '==================================================
                    '重量ヘッダシート印刷
                    '==================================================
                    If Not dtPrintManage.Rows(iRow)("重量ヘッダ") = strHeaderSheet Then
                        '前回ヘッダと相違していたらヘッダシートを印刷する
                        'リーフレットは件数、枚数を0とする
                        strSQL = "SELECT '" & strImportDate & "' AS インポート日, T3.重量ヘッダ, T3.対象者一覧, T3.保健指導名簿, T3.判定票枚数, T3.判定票件数, "
                        '総枚数には重量ヘッダ(1枚分)を加算する
                        strSQL &= "T3.リーフレット枚数, T3.リーフレット件数, T3.総枚数 + 1 AS 総枚数, T3.判定票枚数 AS 枚数, "
                        strSQL &= "T3.判定票件数 AS 件数, "
                        strSQL &= "(SELECT COUNT(重量ヘッダ) FROM T_印刷管理 "
                        strSQL &= "WHERE ロットID = '" & strLotID & "' "
                        strSQL &= "AND 重量ヘッダ = '" & dtPrintManage.Rows(iRow)("重量ヘッダ") & "') AS 通数 "
                        strSQL &= "FROM (SELECT T1.重量ヘッダ, "
                        strSQL &= "ISNULL(SUM(CASE WHEN T2.帳票種別ID = 2 THEN 1 ELSE 0 END), 0) AS 対象者一覧, "
                        strSQL &= "ISNULL(SUM(CASE WHEN T2.帳票種別ID = 3 THEN 1 ELSE 0 END), 0) AS 保健指導名簿, "
                        strSQL &= "ISNULL(SUM(CASE WHEN T2.帳票種別ID = 4 THEN 1 ELSE 0 END), 0) AS 判定票枚数, "
                        strSQL &= "ISNULL(SUM(CASE WHEN T2.帳票種別ID = 4 THEN 1 ELSE 0 END), 0) AS 判定票件数, "
                        strSQL &= "0 AS リーフレット件数, "
                        strSQL &= "0 AS リーフレット枚数, "
                        strSQL &= "COUNT(T1.ロットID) AS 総枚数, "
                        strSQL &= "COUNT(T1.重量ヘッダ) AS 通数 "
                        strSQL &= "FROM T_印刷管理 AS T1 INNER JOIN "
                        strSQL &= "T_印刷ソート AS T2 ON T1.ロットID = T2.ロットID AND T1.会社コード = T2.会社コード "
                        strSQL &= "AND T1.所属事業所コード = T2.所属事業所コード AND T1.印刷ID = T2.印刷ID "
                        strSQL &= "WHERE T1.ロットID = '" & strLotID & "' "
                        strSQL &= "AND T2.帳票種別ID != 0 " 'ラベル以外
                        strSQL &= "AND T2.帳票種別ID != 5 " 'リーフレットを除外
                        strSQL &= "AND T1.重量ヘッダ = '" & dtPrintManage.Rows(iRow)("重量ヘッダ") & "' "
                        strSQL &= "GROUP BY T1.重量ヘッダ) AS T3"

                        '==================================================
                        ''判定票、リーフレット全ての件数を抽出するSQL文
                        'strSQL = "SELECT T3.重量ヘッダ, T3.対象者一覧, T3.保健指導名簿, T3.判定票枚数, T3.判定票件数, "
                        'strSQL &= "T3.リーフレット枚数, T3.リーフレット件数, T3.総枚数 + 1 AS 総枚数, T3.判定票枚数 + T3.リーフレット枚数 AS 枚数, "
                        'strSQL &= "T3.判定票件数 + T3.リーフレット件数 AS 件数 "
                        'strSQL &= "FROM (SELECT T1.重量ヘッダ, "
                        'strSQL &= "ISNULL(SUM(CASE WHEN T2.帳票種別ID = 2 THEN 1 ELSE 0 END), 0) AS 対象者一覧, "
                        'strSQL &= "ISNULL(SUM(CASE WHEN T2.帳票種別ID = 3 THEN 1 ELSE 0 END), 0) AS 保健指導名簿, "
                        'strSQL &= "ISNULL(SUM(CASE WHEN T2.帳票種別ID = 4 THEN 1 ELSE 0 END), 0) AS 判定票枚数, "
                        'strSQL &= "ISNULL(SUM(CASE WHEN T2.帳票種別ID = 4 THEN 1 ELSE 0 END), 0) AS 判定票件数, "
                        'strSQL &= "(SELECT ISNULL(COUNT(A1.カウント), 0) FROM ("
                        'strSQL &= "SELECT COUNT(システムID) AS カウント FROM T_印刷ソート AS T4 INNER JOIN "
                        'strSQL &= "T_判定票管理 AS T5 ON T4.ロットID = T5.ロットID AND T4.レコード番号 = T5.レコード番号 "
                        'strSQL &= "WHERE 帳票種別ID = 5 AND ロットID = '" & strLotID & "' "
                        'strSQL &= "AND T5.リーフレット無効 = 0 "
                        'strSQL &= "GROUP BY システムID) AS A1"
                        'strSQL &= ") AS リーフレット件数, "
                        'strSQL &= "(SELECT ISNULL(SUM(A1.カウント), 0) FROM ("
                        'strSQL &= "SELECT COUNT(システムID) AS カウント FROM T_印刷ソート AS T4 INNER JOIN "
                        'strSQL &= "T_判定票管理 AS T5 ON T4.ロットID = T5.ロットID AND T4.レコード番号 = T5.レコード番号 "
                        'strSQL &= "WHERE 帳票種別ID = 5 AND ロットID = '" & strLotID & "' "
                        'strSQL &= "AND T5.リーフレット無効 = 0 "
                        'strSQL &= "GROUP BY システムID) AS A1 "
                        'strSQL &= ") AS リーフレット枚数, "
                        'strSQL &= "COUNT(T1.ロットID) AS 総枚数 "
                        'strSQL &= "FROM T_印刷管理 AS T1 INNER JOIN "
                        'strSQL &= "T_印刷ソート AS T2 ON T1.ロットID = T2.ロットID AND T1.会社コード = T2.会社コード "
                        'strSQL &= "AND T1.所属事業所コード = T2.所属事業所コード AND T1.印刷ID = T2.印刷ID "
                        'strSQL &= "WHERE T1.ロットID = '" & strLotID & "' "
                        'strSQL &= "AND T2.帳票種別ID != 0 " 'ラベル以外
                        'strSQL &= "AND T1.重量ヘッダ = '" & dtPrintManage.Rows(iRow)("重量ヘッダ") & "' "
                        'strSQL &= "GROUP BY T1.重量ヘッダ) AS T3"
                        '==================================================
                        dt = sqlProcess.DB_SELECT_DATATABLE(strSQL)
                        If dt.Rows.Count > 0 Then
                            '結果があった場合印刷
                            Print(strSQL, PrintCategory.WeightHeader)

                        End If
                    End If
                    '==================================================
                    '対象者一覧印刷
                    '==================================================
                    strSQL = "SELECT T1.ロットID, T1.会社コード, T1.所属事業所コード, T1.印刷ID, T1.ページ数, T1.レコード番号, "
                    strSQL &= "T1.会社, T1.所属事業所, T1.所属部名, T1.所属課名, T1.氏名, T1.受診日, T1.健診種別, T1.意見書発行, T1.判定票要押印, T3.QR AS QRコード, T4.ラベル連番 "
                    strSQL &= "FROM T_対象者一覧印刷 AS T1 INNER JOIN "
                    strSQL &= "T_判定票管理 AS T2 ON T1.ロットID = T2.ロットID AND T1.レコード番号 = T2.レコード番号 LEFT OUTER JOIN "
                    strSQL &= "T_印刷ソート AS T3 ON T1.ロットID = T3.ロットID AND T1.会社コード = T3.会社コード AND T1.所属事業所コード = T3.所属事業所コード "
                    strSQL &= "AND T1.印刷ID = T3.印刷ID AND T1.ページ数 = T3.ページ数 INNER JOIN "
                    strSQL &= "T_印刷管理 AS T4 ON T1.ロットID = T4.ロットID AND T1.会社コード = T4.会社コード "
                    strSQL &= "AND T1.所属事業所コード = T4.所属事業所コード AND T1.印刷ID = T4.印刷ID "
                    strSQL &= "WHERE T1.ロットID = '" & strLotID & "' "
                    strSQL &= "AND T1.会社コード = '" & dtPrintManage.Rows(iRow)("会社コード") & "' "
                    strSQL &= "AND T1.所属事業所コード = '" & dtPrintManage.Rows(iRow)("所属事業所コード") & "' "
                    strSQL &= "AND T1.印刷ID = " & dtPrintManage.Rows(iRow)("印刷ID") & " "
                    strSQL &= "AND T3.帳票種別ID = 2 "
                    strSQL &= "ORDER BY CASE WHEN ISNULL(T1.所属部名, '') = '' THEN 1 ELSE 0 END, "
                    strSQL &= "T1.所属部名, "
                    strSQL &= "CASE WHEN ISNULL(T1.所属課名, '') = '' THEN 1 ELSE 0 END, "
                    strSQL &= "T1.所属課名, T2.社員コード"
                    dt = sqlProcess.DB_SELECT_DATATABLE(strSQL)
                    If dt.Rows.Count > 0 Then
                        '印刷処理
                        Print(strSQL, PrintCategory.CheckupList)

                    End If

                    '==================================================
                    '保健指導名簿印刷
                    '==================================================
                    strSQL = "SELECT T1.ロットID, T1.会社コード, T1.所属事業所コード, T1.印刷ID, T1.ページ数, T1.レコード番号, "
                    strSQL &= "T1.会社, T1.所属事業所, T1.所属部名, T1.所属課名, T1.社員コード, T1.氏名, T1.帳票タイプ, T2.QR AS QRコード, T3.ラベル連番 "
                    strSQL &= "FROM T_保健指導名簿印刷 AS T1 LEFT OUTER JOIN "
                    strSQL &= "T_印刷ソート AS T2 ON T1.ロットID = T2.ロットID AND T1.会社コード = T2.会社コード "
                    strSQL &= "AND T1.所属事業所コード = T2.所属事業所コード AND T1.印刷ID = T2.印刷ID AND T1.ページ数 = T2.ページ数 INNER JOIN "
                    strSQL &= "T_印刷管理 AS T3 ON T1.ロットID = T3.ロットID AND T1.会社コード = T3.会社コード "
                    strSQL &= "AND T1.所属事業所コード = T3.所属事業所コード AND T1.印刷ID = T3.印刷ID "
                    strSQL &= "WHERE T1.ロットID = '" & strLotID & "' "
                    strSQL &= "AND T1.会社コード = '" & dtPrintManage.Rows(iRow)("会社コード") & "' "
                    strSQL &= "AND T1.所属事業所コード = '" & dtPrintManage.Rows(iRow)("所属事業所コード") & "' "
                    strSQL &= "AND T1.印刷ID = " & dtPrintManage.Rows(iRow)("印刷ID") & " "
                    strSQL &= "AND T2.帳票種別ID = 3 "
                    strSQL &= "ORDER BY CASE WHEN ISNULL(T1.所属部名, '') = '' THEN 1 ELSE 0 END, "
                    strSQL &= "T1.所属部名, "
                    strSQL &= "CASE WHEN ISNULL(T1.所属課名, '') = '' THEN 1 ELSE 0 END, "
                    strSQL &= "T1.所属課名, T1.社員コード"

                    'strSQL = "SELECT ロットID, 会社コード, 所属事業所コード, 印刷ID, ページ数, レコード番号, "
                    'strSQL &= "会社, 所属事業所, 所属部名, 所属課名, 社員コード, 氏名, 帳票タイプ "
                    'strSQL &= "FROM T_保健指導名簿印刷 "
                    'strSQL &= "WHERE ロットID = '" & strLotID & "' "
                    'strSQL &= "AND 会社コード = '" & dtPrintManage.Rows(iRow)("会社コード") & "' "
                    'strSQL &= "AND 所属事業所コード = '" & dtPrintManage.Rows(iRow)("所属事業所コード") & "' "
                    'strSQL &= "AND 印刷ID = " & dtPrintManage.Rows(iRow)("印刷ID") & " "
                    'strSQL &= "ORDER BY CASE WHEN ISNULL(所属部名, '') = '' THEN 1 ELSE 0 END, "
                    'strSQL &= "CASE WHEN ISNULL(所属課名, '') = '' THEN 1 ELSE 0 END, "
                    'strSQL &= "所属課名, 社員コード"
                    dt = sqlProcess.DB_SELECT_DATATABLE(strSQL)
                    If dt.Rows.Count > 0 Then
						'印刷処理
						Print(strSQL, PrintCategory.LeafletList, , dtPrintManage.Rows(iRow)("会社コード"))

					End If

                    '==================================================
                    '判定票印刷
                    '==================================================
                    '2019/04/24
                    '1枚単位でテンプレートが変わる可能性があるためはじめにソート用のDataTableを作成して
                    '1枚単位でプリントに飛ばす
                    strSQL = "SELECT T1.ロットID, T1.レコード番号 "
                    strSQL &= "FROM T_判定票印刷 AS T1 INNER JOIN "
                    strSQL &= "T_印刷ソート AS T2 ON T1.ロットID = T2.ロットID AND T1.レコード番号 = T2.レコード番号 INNER JOIN "
                    strSQL &= "T_判定票管理 AS T3 ON T1.ロットID = T3.ロットID AND T1.レコード番号 = T3.レコード番号 INNER JOIN "
                    strSQL &= "T_印刷管理 AS T4 ON T2.ロットID = T4.ロットID AND T2.会社コード = T4.会社コード "
                    strSQL &= "AND T2.所属事業所コード = T4.所属事業所コード AND T2.印刷ID = T4.印刷ID "
                    strSQL &= "WHERE T1.ロットID = '" & strLotID & "' "
                    strSQL &= "AND T2.会社コード = '" & dtPrintManage.Rows(iRow)("会社コード") & "' "
                    strSQL &= "AND T2.所属事業所コード = '" & dtPrintManage.Rows(iRow)("所属事業所コード") & "' "
                    strSQL &= "AND T2.印刷ID = " & dtPrintManage.Rows(iRow)("印刷ID") & " "
                    strSQL &= "AND T2.帳票種別ID = 4 "
                    strSQL &= "ORDER BY CASE WHEN ISNULL(T1.所属部名, '') = '' THEN 1 ELSE 0 END, "
                    strSQL &= "T1.所属部名, "
                    strSQL &= "CASE WHEN ISNULL(T1.所属課名, '') = '' THEN 1 ELSE 0 END, "
                    strSQL &= "T1.所属課名, T3.社員コード"
                    dt = sqlProcess.DB_SELECT_DATATABLE(strSQL)
                    '1レコードずつ回す
                    For i As Integer = 0 To dt.Rows.Count - 1
                        strSQL = "SELECT T1.ロットID, T1.レコード番号, T1.システムID, T1.氏名カナ, T1.氏名, T1.会社, T1.所属事業所, "
                        strSQL &= "T1.所属部名, T1.所属課名, T1.役職名, T1.性別, T1.採用年月日, T1.生年月日, T1.受診年齢, T1.健診種別, T1.受診日, T1.身長, T1.体重, "
                        strSQL &= "T1.体重記号, T1.体重上限, T1.体重下限, T1.BMI, T1.BMI記号, T1.BMI上限, T1.BMI下限, T1.腹囲, T1.腹囲記号, T1.腹囲上限, T1.腹囲下限, "
                        strSQL &= "T1.視力裸眼右, T1.視力裸眼左, T1.視力矯正右, T1.視力矯正左, T1.聴力右1000, T1.聴力右4000, T1.聴力左1000, T1.聴力左4000, "
                        strSQL &= "T1.聴力その他, T1.血圧1回収縮期, T1.血圧1回収縮期記号, T1.血圧1回収縮期上限, T1.血圧1回収縮期下限, "
                        strSQL &= "T1.血圧1回拡張期, T1.血圧1回拡張期記号, T1.血圧1回拡張期上限, T1.血圧1回拡張期下限, T1.尿糖定性, T1.尿蛋白定性, "
                        strSQL &= "T1.総コレステロール, T1.総コレステロール記号, T1.総コレステロール上限, T1.総コレステロール下限, "
                        strSQL &= "T1.HDLコレステロール, T1.HDLコレステロール記号, T1.HDLコレステロール上限, T1.HDLコレステロール下限, "
                        strSQL &= "T1.中性脂肪, T1.中性脂肪記号, T1.中性脂肪上限, T1.中性脂肪下限, "
                        strSQL &= "T1.LDLコレステロール, T1.LDLコレステロール記号, T1.LDLコレステロール上限, T1.LDLコレステロール下限, "
                        strSQL &= "T1.GOT, T1.GOT記号, T1.GOT上限, T1.GOT下限, T1.GPT, T1.GPT記号, T1.GPT上限, T1.GPT下限, "
                        strSQL &= "T1.ガンマGTP, T1.ガンマGTP記号, T1.ガンマGTP上限, T1.ガンマGTP下限, "
                        strSQL &= "T1.クレアチニン, T1.クレアチニン記号, T1.クレアチニン上限, T1.クレアチニン下限, "
                        strSQL &= "T1.尿酸, T1.尿酸記号, T1.尿酸上限, T1.尿酸下限, T1.赤血球, T1.赤血球記号, T1.赤血球上限, T1.赤血球下限, "
                        strSQL &= "T1.血色素量, T1.血色素量記号, T1.血色素量上限, T1.血色素量下限, "
                        strSQL &= "T1.空腹時血糖, T1.空腹時血糖記号, T1.空腹時血糖上限, T1.空腹時血糖下限, "
                        strSQL &= "T1.随時血糖, T1.随時血糖記号, T1.随時血糖上限, T1.随時血糖下限, T1.HbA1c, T1.HbA1c記号, T1.HbA1c上限, T1.HbA1c下限, "
                        strSQL &= "T1.受診検査機関名称, T1.会場局名称, T1.総合判定, T1.健診実施医師名, T1.判定医師名, T1.判定日付, T1.視力判定, T1.聴力判定, "
                        strSQL &= "T1.血圧判定, T1.尿糖判定, T1.尿蛋白判定, T1.血中脂質判定, T1.肝機能判定, T1.腎機能判定, T1.尿酸判定, T1.血液判定, "
                        strSQL &= "T1.血糖判定, T1.胸部X線判定結果, T1.心電図判定結果, T1.総合成績判定, T1.就業区分, T1.胸部X線所見, T1.胸部X線判定, "
                        strSQL &= "T1.心電図所見, T1.心電図判定, T1.既往歴, T1.自覚症状, T1.診察所見, T1.総合コメント, T1.産業医の意見, T1.QRコード, T4.ラベル連番, "
                        '2019/04/24
                        '3項目追加
                        strSQL &= "T3.年度, ISNULL(T6.印影画像パス, '') AS 産業医印影, ISNULL(T7.印影画像パス, '') AS 判定医印影 "
                        strSQL &= "FROM T_判定票印刷 AS T1 INNER JOIN "
                        strSQL &= "T_印刷ソート AS T2 ON T1.ロットID = T2.ロットID AND T1.レコード番号 = T2.レコード番号 INNER JOIN "
                        strSQL &= "T_判定票管理 AS T3 ON T1.ロットID = T3.ロットID AND T1.レコード番号 = T3.レコード番号 INNER JOIN "
                        strSQL &= "T_印刷管理 AS T4 ON T2.ロットID = T4.ロットID AND T2.会社コード = T4.会社コード "
                        strSQL &= "AND T2.所属事業所コード = T4.所属事業所コード AND T2.印刷ID = T4.印刷ID LEFT OUTER JOIN "
                        '2019/04/24
                        '3テーブル追加
                        strSQL &= "T_医師 AS T5 ON T1.ロットID = T5.ロットID AND T1.レコード番号 = T5.レコード番号 LEFT OUTER JOIN "
                        strSQL &= "M_産業医 AS T6 ON T5.産業医ID = T6.産業医ID LEFT OUTER JOIN "
                        strSQL &= "M_判定医 AS T7 ON T5.判定医ID = T7.判定医ID "
                        strSQL &= "WHERE T1.ロットID = '" & strLotID & "' "
                        strSQL &= "AND T1.レコード番号 = " & dt.Rows(i)("レコード番号") & " "
                        strSQL &= "AND T2.印刷ID = " & dtPrintManage.Rows(iRow)("印刷ID") & " "
                        strSQL &= "AND T2.帳票種別ID = 4 "
                        Dim dtPrint As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
                        If dtPrint.Rows.Count > 0 Then
                            '2019/05/07
                            '年度が「2019」以降の場合は新テンプレートとする
                            If CInt(dtPrint.Rows(0)("年度")) >= 2019 Then
                                '印刷処理
                                Print(strSQL, PrintCategory.Checkup, , , "result2019.flxr")
                            Else
                                '印刷処理
                                Print(strSQL, PrintCategory.Checkup)
                            End If

                        End If
                    Next
                    If dt.Rows.Count > 0 Then
                        '判定票印刷日時書き込み
                        WritePrintDate(strLotID, PrintCategory.Checkup, 0, dtPrintManage.Rows(iRow)("会社コード"), dtPrintManage.Rows(iRow)("所属事業所コード"), dtPrintManage.Rows(iRow)("印刷ID"))
                        '該当の会社コード、所属事業所コード、印刷IDすべてのチェックフラグを取り下げる
                        strSQL = "UPDATE T_印刷ソート SET チェックフラグ = 0 "
                        strSQL &= "WHERE ロットID = '" & strLotID & "' "
                        strSQL &= "AND 会社コード = '" & dtPrintManage.Rows(iRow)("会社コード") & "' "
                        strSQL &= "AND 所属事業所コード = '" & dtPrintManage.Rows(iRow)("所属事業所コード") & "' "
                        strSQL &= "AND 印刷ID = " & dtPrintManage.Rows(iRow)("印刷ID")
                        sqlProcess.DB_UPDATE(strSQL)
                    End If

                    strHeaderSheet = dtPrintManage.Rows(iRow)("重量ヘッダ")


                    'strSQL = "SELECT T1.ロットID, T1.レコード番号, T1.システムID, T1.氏名カナ, T1.氏名, T1.会社, T1.所属事業所, "
                    'strSQL &= "T1.所属部名, T1.所属課名, T1.役職名, T1.性別, T1.採用年月日, T1.生年月日, T1.受診年齢, T1.健診種別, T1.受診日, T1.身長, T1.体重, "
                    'strSQL &= "T1.体重記号, T1.体重上限, T1.体重下限, T1.BMI, T1.BMI記号, T1.BMI上限, T1.BMI下限, T1.腹囲, T1.腹囲記号, T1.腹囲上限, T1.腹囲下限, "
                    'strSQL &= "T1.視力裸眼右, T1.視力裸眼左, T1.視力矯正右, T1.視力矯正左, T1.聴力右1000, T1.聴力右4000, T1.聴力左1000, T1.聴力左4000, "
                    'strSQL &= "T1.聴力その他, T1.血圧1回収縮期, T1.血圧1回収縮期記号, T1.血圧1回収縮期上限, T1.血圧1回収縮期下限, "
                    'strSQL &= "T1.血圧1回拡張期, T1.血圧1回拡張期記号, T1.血圧1回拡張期上限, T1.血圧1回拡張期下限, T1.尿糖定性, T1.尿蛋白定性, "
                    'strSQL &= "T1.総コレステロール, T1.総コレステロール記号, T1.総コレステロール上限, T1.総コレステロール下限, "
                    'strSQL &= "T1.HDLコレステロール, T1.HDLコレステロール記号, T1.HDLコレステロール上限, T1.HDLコレステロール下限, "
                    'strSQL &= "T1.中性脂肪, T1.中性脂肪記号, T1.中性脂肪上限, T1.中性脂肪下限, "
                    'strSQL &= "T1.LDLコレステロール, T1.LDLコレステロール記号, T1.LDLコレステロール上限, T1.LDLコレステロール下限, "
                    'strSQL &= "T1.GOT, T1.GOT記号, T1.GOT上限, T1.GOT下限, T1.GPT, T1.GPT記号, T1.GPT上限, T1.GPT下限, "
                    'strSQL &= "T1.ガンマGTP, T1.ガンマGTP記号, T1.ガンマGTP上限, T1.ガンマGTP下限, "
                    'strSQL &= "T1.クレアチニン, T1.クレアチニン記号, T1.クレアチニン上限, T1.クレアチニン下限, "
                    'strSQL &= "T1.尿酸, T1.尿酸記号, T1.尿酸上限, T1.尿酸下限, T1.赤血球, T1.赤血球記号, T1.赤血球上限, T1.赤血球下限, "
                    'strSQL &= "T1.血色素量, T1.血色素量記号, T1.血色素量上限, T1.血色素量下限, "
                    'strSQL &= "T1.空腹時血糖, T1.空腹時血糖記号, T1.空腹時血糖上限, T1.空腹時血糖下限, "
                    'strSQL &= "T1.随時血糖, T1.随時血糖記号, T1.随時血糖上限, T1.随時血糖下限, T1.HbA1c, T1.HbA1c記号, T1.HbA1c上限, T1.HbA1c下限, "
                    'strSQL &= "T1.受診検査機関名称, T1.会場局名称, T1.総合判定, T1.健診実施医師名, T1.判定医師名, T1.判定日付, T1.視力判定, T1.聴力判定, "
                    'strSQL &= "T1.血圧判定, T1.尿糖判定, T1.尿蛋白判定, T1.血中脂質判定, T1.肝機能判定, T1.腎機能判定, T1.尿酸判定, T1.血液判定, "
                    'strSQL &= "T1.血糖判定, T1.胸部X線判定結果, T1.心電図判定結果, T1.総合成績判定, T1.就業区分, T1.胸部X線所見, T1.胸部X線判定, "
                    'strSQL &= "T1.心電図所見, T1.心電図判定, T1.既往歴, T1.自覚症状, T1.診察所見, T1.総合コメント, T1.産業医の意見, T1.QRコード, T4.ラベル連番 "
                    'strSQL &= "FROM T_判定票印刷 AS T1 INNER JOIN "
                    'strSQL &= "T_印刷ソート AS T2 ON T1.ロットID = T2.ロットID AND T1.レコード番号 = T2.レコード番号 INNER JOIN "
                    'strSQL &= "T_判定票管理 AS T3 ON T1.ロットID = T3.ロットID AND T1.レコード番号 = T3.レコード番号 INNER JOIN "
                    'strSQL &= "T_印刷管理 AS T4 ON T2.ロットID = T4.ロットID AND T2.会社コード = T4.会社コード "
                    'strSQL &= "AND T2.所属事業所コード = T4.所属事業所コード AND T2.印刷ID = T4.印刷ID "
                    'strSQL &= "WHERE T1.ロットID = '" & strLotID & "' "
                    'strSQL &= "AND T2.会社コード = '" & dtPrintManage.Rows(iRow)("会社コード") & "' "
                    'strSQL &= "AND T2.所属事業所コード = '" & dtPrintManage.Rows(iRow)("所属事業所コード") & "' "
                    'strSQL &= "AND T2.印刷ID = " & dtPrintManage.Rows(iRow)("印刷ID") & " "
                    'strSQL &= "AND T2.帳票種別ID = 4 "
                    'strSQL &= "ORDER BY CASE WHEN ISNULL(T1.所属部名, '') = '' THEN 1 ELSE 0 END, "
                    'strSQL &= "T1.所属部名, "
                    'strSQL &= "CASE WHEN ISNULL(T1.所属課名, '') = '' THEN 1 ELSE 0 END, "
                    'strSQL &= "T1.所属課名, T3.社員コード"
                    'dt = sqlProcess.DB_SELECT_DATATABLE(strSQL)
                    'If dt.Rows.Count > 0 Then
                    '    '印刷処理
                    '    Print(strSQL, PrintCategory.Checkup)
                    '    '判定票印刷日時書き込み
                    '    WritePrintDate(strLotID, PrintCategory.Checkup, 0, dtPrintManage.Rows(iRow)("会社コード"), dtPrintManage.Rows(iRow)("所属事業所コード"), dtPrintManage.Rows(iRow)("印刷ID"))
                    '    '該当の会社コード、所属事業所コード、印刷IDすべてのチェックフラグを取り下げる
                    '    strSQL = "UPDATE T_印刷ソート SET チェックフラグ = 0 "
                    '    strSQL &= "WHERE ロットID = '" & strLotID & "' "
                    '    strSQL &= "AND 会社コード = '" & dtPrintManage.Rows(iRow)("会社コード") & "' "
                    '    strSQL &= "AND 所属事業所コード = '" & dtPrintManage.Rows(iRow)("所属事業所コード") & "' "
                    '    strSQL &= "AND 印刷ID = " & dtPrintManage.Rows(iRow)("印刷ID")
                    '    sqlProcess.DB_UPDATE(strSQL)
                    'End If

                    'strHeaderSheet = dtPrintManage.Rows(iRow)("重量ヘッダ")
                    'Application.DoEvents()
                Next
            Else
                ''※保留
                ''レコード番号指定の単体印刷
                ''==================================================
                ''判定票印刷(レコード番号単位)
                ''==================================================
                'strSQL = "SELECT T1.ロットID, T1.レコード番号, T1.システムID, T1.氏名カナ, T1.氏名, T1.会社, T1.所属事業所, "
                'strSQL &= "T1.所属部名, T1.所属課名, T1.役職名, T1.性別, T1.採用年月日, T1.生年月日, T1.受診年齢, T1.健診種別, T1.受診日, T1.身長, T1.体重, "
                'strSQL &= "T1.体重記号, T1.体重上限, T1.体重下限, T1.BMI, T1.BMI記号, T1.BMI上限, T1.BMI下限, T1.腹囲, T1.腹囲記号, T1.腹囲上限, T1.腹囲下限, "
                'strSQL &= "T1.視力裸眼右, T1.視力裸眼左, T1.視力矯正右, T1.視力矯正左, T1.聴力右1000, T1.聴力右4000, T1.聴力左1000, T1.聴力左4000, "
                'strSQL &= "T1.聴力その他, T1.血圧1回収縮期, T1.血圧1回収縮期記号, T1.血圧1回収縮期上限, T1.血圧1回収縮期下限, "
                'strSQL &= "T1.血圧1回拡張期, T1.血圧1回拡張期記号, T1.血圧1回拡張期上限, T1.血圧1回拡張期下限, T1.尿糖定性, T1.尿蛋白定性, "
                'strSQL &= "T1.総コレステロール, T1.総コレステロール記号, T1.総コレステロール上限, T1.総コレステロール下限, "
                'strSQL &= "T1.HDLコレステロール, T1.HDLコレステロール記号, T1.HDLコレステロール上限, T1.HDLコレステロール下限, "
                'strSQL &= "T1.中性脂肪, T1.中性脂肪記号, T1.中性脂肪上限, T1.中性脂肪下限, "
                'strSQL &= "T1.LDLコレステロール, T1.LDLコレステロール記号, T1.LDLコレステロール上限, T1.LDLコレステロール下限, "
                'strSQL &= "T1.GOT, T1.GOT記号, T1.GOT上限, T1.GOT下限, T1.GPT, T1.GPT記号, T1.GPT上限, T1.GPT下限, "
                'strSQL &= "T1.ガンマGTP, T1.ガンマGTP記号, T1.ガンマGTP上限, T1.ガンマGTP下限, "
                'strSQL &= "T1.クレアチニン, T1.クレアチニン記号, T1.クレアチニン上限, T1.クレアチニン下限, "
                'strSQL &= "T1.尿酸, T1.尿酸記号, T1.尿酸上限, T1.尿酸下限, T1.赤血球, T1.赤血球記号, T1.赤血球上限, T1.赤血球下限, "
                'strSQL &= "T1.血色素量, T1.血色素量記号, T1.血色素量上限, T1.血色素量下限, "
                'strSQL &= "T1.空腹時血糖, T1.空腹時血糖記号, T1.空腹時血糖上限, T1.空腹時血糖下限, "
                'strSQL &= "T1.随時血糖, T1.随時血糖記号, T1.随時血糖上限, T1.随時血糖下限, T1.HbA1c, T1.HbA1c記号, T1.HbA1c上限, T1.HbA1c下限, "
                'strSQL &= "T1.受診検査機関名称, T1.会場局名称, T1.総合判定, T1.健診実施医師名, T1.判定医師名, T1.判定日付, T1.視力判定, T1.聴力判定, "
                'strSQL &= "T1.血圧判定, T1.尿糖判定, T1.尿蛋白判定, T1.血中脂質判定, T1.肝機能判定, T1.腎機能判定, T1.尿酸判定, T1.血液判定, "
                'strSQL &= "T1.血糖判定, T1.胸部X線判定結果, T1.心電図判定結果, T1.総合成績判定, T1.就業区分, T1.胸部X線所見, T1.胸部X線判定, "
                'strSQL &= "T1.心電図所見, T1.心電図判定, T1.既往歴, T1.自覚症状, T1.診察所見, T1.総合コメント, T1.産業医の意見, T1.QRコード "
                'strSQL &= "FROM T_判定票印刷 AS T1 "
                'strSQL &= "WHERE T1.ロットID = '" & strLotID & "' "
                'strSQL &= "AND T1.レコード番号 = " & iRecordNumber
                'dt = sqlProcess.DB_SELECT_DATATABLE(strSQL)
                'If dt.Rows.Count > 0 Then
                '    '印刷処理
                '    Print(strSQL, PrintCategory.Checkup)
                '    '判定票印刷日時書き込み
                '    WritePrintDate(strLotID, PrintCategory.Checkup, iRecordNumber)

                'End If

            End If

            'MessageBox.Show("印刷が完了しました", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception

            Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & ex.StackTrace)
            MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally

            sqlProcess.Close()
            '設定されていた通常使うプリンタに戻す
            SetDefaultPrinter(strDefaultPrinter)

        End Try

    End Sub

    ''' <summary>
    ''' 判定票 所属事業所単位印刷
    ''' </summary>
    ''' <param name="strLotID"></param>
    Public Sub PrintCheckupOffice(ByVal strLotID As String)

        Dim sqlProcess As New SQLProcess
        Dim strSQL As String = ""
        Dim dt As DataTable = Nothing

        '現在の通常使うプリンタ名を取得
        'プリンタ名の取得
        'Finallyで通常使うプリンタを戻す
        Dim strDefaultPrinter As String = pd.PrinterSettings.PrinterName
        XmlSettings.LoadFromXmlFile()
        'プリンタドライバの切り替え
        SetDefaultPrinter(XmlSettings.Instance.Printer_Result)

        Try
            'T_印刷管理は「T_印刷管理個別」を参照する
            strSQL = "SELECT ロットID, 会社コード, 所属事業所コード, 印刷ID, 重量ヘッダ, ラベル連番 "
            strSQL &= "FROM T_印刷管理個別 "
            strSQL &= "WHERE ロットID = '" & strLotID & "' "
            strSQL &= "ORDER BY ラベル連番"
            Dim dtPrintManage As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
            Dim strHeaderSheet As String = ""   '前回ヘッダシート格納用
            Dim strImportDate As String = strLotID.Substring(0, 8)  'ロットIDの先頭8桁(インポート日)を取得する

            For iRow As Integer = 0 To dtPrintManage.Rows.Count - 1
                '会社コード、所属事業所コード、重量ヘッダ単位で回す
                '==================================================
                '重量ヘッダシート印刷
                '==================================================
                If Not dtPrintManage.Rows(iRow)("重量ヘッダ") = strHeaderSheet Then
                    '前回減っだと相違していたらヘッダシートを印刷する
                    'リーフレットは件数、枚数を0とする
                    strSQL = "SELECT '" & strImportDate & "' AS インポート日, T3.重量ヘッダ, T3.対象者一覧, T3.保健指導名簿, T3.判定票枚数, T3.判定票件数, "
                    '総枚数には重量ヘッダ(1枚分)を加算する
                    strSQL &= "T3.リーフレット枚数, T3.リーフレット件数, T3.総枚数 + 1 AS 総枚数, T3.判定票枚数 AS 枚数, "
                    strSQL &= "T3.判定票件数 AS 件数, "
                    strSQL &= "(SELECT COUNT(重量ヘッダ) FROM T_印刷管理個別 "
                    strSQL &= "WHERE ロットID = '" & strLotID & "' "
                    strSQL &= "AND 重量ヘッダ = '" & dtPrintManage.Rows(iRow)("重量ヘッダ") & "') AS 通数 "
                    strSQL &= "FROM (SELECT T1.重量ヘッダ, "
                    strSQL &= "ISNULL(SUM(CASE WHEN T2.帳票種別ID = 2 THEN 1 ELSE 0 END), 0) AS 対象者一覧, "
                    strSQL &= "ISNULL(SUM(CASE WHEN T2.帳票種別ID = 3 THEN 1 ELSE 0 END), 0) AS 保健指導名簿, "
                    strSQL &= "ISNULL(SUM(CASE WHEN T2.帳票種別ID = 4 THEN 1 ELSE 0 END), 0) AS 判定票枚数, "
                    strSQL &= "ISNULL(SUM(CASE WHEN T2.帳票種別ID = 4 THEN 1 ELSE 0 END), 0) AS 判定票件数, "
                    strSQL &= "0 AS リーフレット枚数, "
                    strSQL &= "0 AS リーフレット件数, "
                    strSQL &= "COUNT(T1.ロットID) AS 総枚数, "
                    strSQL &= "COUNT(T1.重量ヘッダ) AS 通数 "
                    strSQL &= "FROM T_印刷管理個別 AS T1 INNER JOIN "
                    strSQL &= "T_印刷ソート AS T2 ON T1.ロットID = T2.ロットID AND T1.会社コード = T2.会社コード "
                    strSQL &= "AND T1.所属事業所コード = T2.所属事業所コード AND T1.印刷ID = T2.印刷ID "
                    strSQL &= "WHERE T1.ロットID = '" & strLotID & "' "
                    strSQL &= "AND T2.帳票種別ID != 0 " 'ラベル以外
                    strSQL &= "AND T2.帳票種別ID != 5 " 'リーフレットを除外
                    strSQL &= "AND T1.重量ヘッダ = '" & dtPrintManage.Rows(iRow)("重量ヘッダ") & "' "
                    strSQL &= "GROUP BY T1.重量ヘッダ) AS T3"
                    dt = sqlProcess.DB_SELECT_DATATABLE(strSQL)
                    If dt.Rows.Count > 0 Then
                        '結果があった場合印刷
                        Print(strSQL, PrintCategory.WeightHeader)
                    End If

                End If
                '==================================================
                '対象者一覧印刷
                '==================================================
                strSQL = "SELECT T1.ロットID, T1.会社コード, T1.所属事業所コード, T1.印刷ID, T1.ページ数, T1.レコード番号, "
                strSQL &= "T1.会社, T1.所属事業所, T1.所属部名, T1.所属課名, T1.氏名, T1.受診日, T1.健診種別, T1.意見書発行, T1.判定票要押印, T3.QR AS QRコード, T4.ラベル連番 "
                strSQL &= "FROM T_対象者一覧印刷 AS T1 INNER JOIN "
                strSQL &= "T_判定票管理 AS T2 ON T1.ロットID = T2.ロットID AND T1.レコード番号 = T2.レコード番号 LEFT OUTER JOIN "
                strSQL &= "T_印刷ソート AS T3 ON T1.ロットID = T3.ロットID AND T1.会社コード = T3.会社コード AND T1.所属事業所コード = T3.所属事業所コード "
                strSQL &= "AND T1.印刷ID = T3.印刷ID AND T1.ページ数 = T3.ページ数 INNER JOIN "
                strSQL &= "T_印刷管理個別 AS T4 ON T1.ロットID = T4.ロットID AND T1.会社コード = T4.会社コード "
                strSQL &= "AND T1.所属事業所コード = T4.所属事業所コード AND T1.印刷ID = T4.印刷ID "
                strSQL &= "WHERE T1.ロットID = '" & strLotID & "' "
                strSQL &= "AND T1.会社コード = '" & dtPrintManage.Rows(iRow)("会社コード") & "' "
                strSQL &= "AND T1.所属事業所コード = '" & dtPrintManage.Rows(iRow)("所属事業所コード") & "' "
                strSQL &= "AND T1.印刷ID = " & dtPrintManage.Rows(iRow)("印刷ID") & " "
                strSQL &= "AND T3.帳票種別ID = 2 "
                strSQL &= "ORDER BY CASE WHEN ISNULL(T1.所属部名, '') = '' THEN 1 ELSE 0 END, "
                strSQL &= "T1.所属部名, "
                strSQL &= "CASE WHEN ISNULL(T1.所属課名, '') = '' THEN 1 ELSE 0 END, "
                strSQL &= "T1.所属課名, T2.社員コード"
                dt = sqlProcess.DB_SELECT_DATATABLE(strSQL)
                If dt.Rows.Count > 0 Then
                    '印刷処理
                    Print(strSQL, PrintCategory.CheckupList)

                End If

                '==================================================
                '保健指導名簿印刷
                '==================================================
                strSQL = "SELECT T1.ロットID, T1.会社コード, T1.所属事業所コード, T1.印刷ID, T1.ページ数, T1.レコード番号, "
                strSQL &= "T1.会社, T1.所属事業所, T1.所属部名, T1.所属課名, T1.社員コード, T1.氏名, T1.帳票タイプ, T2.QR AS QRコード, T3.ラベル連番 "
                strSQL &= "FROM T_保健指導名簿印刷 AS T1 LEFT OUTER JOIN "
                strSQL &= "T_印刷ソート AS T2 ON T1.ロットID = T2.ロットID AND T1.会社コード = T2.会社コード "
                strSQL &= "AND T1.所属事業所コード = T2.所属事業所コード AND T1.印刷ID = T2.印刷ID AND T1.ページ数 = T2.ページ数 INNER JOIN "
                strSQL &= "T_印刷管理個別 AS T3 ON T1.ロットID = T3.ロットID AND T1.会社コード = T3.会社コード "
                strSQL &= "AND T1.所属事業所コード = T3.所属事業所コード AND T1.印刷ID = T3.印刷ID "
                strSQL &= "WHERE T1.ロットID = '" & strLotID & "' "
                strSQL &= "AND T1.会社コード = '" & dtPrintManage.Rows(iRow)("会社コード") & "' "
                strSQL &= "AND T1.所属事業所コード = '" & dtPrintManage.Rows(iRow)("所属事業所コード") & "' "
                strSQL &= "AND T1.印刷ID = " & dtPrintManage.Rows(iRow)("印刷ID") & " "
                strSQL &= "AND T2.帳票種別ID = 3 "
                strSQL &= "ORDER BY CASE WHEN ISNULL(T1.所属部名, '') = '' THEN 1 ELSE 0 END, "
                strSQL &= "T1.所属部名, "
                strSQL &= "CASE WHEN ISNULL(T1.所属課名, '') = '' THEN 1 ELSE 0 END, "
                strSQL &= "T1.所属課名, T1.社員コード"
                dt = sqlProcess.DB_SELECT_DATATABLE(strSQL)
                If dt.Rows.Count > 0 Then
					'印刷処理
					Print(strSQL, PrintCategory.LeafletList, , dtPrintManage.Rows(iRow)("会社コード"))

				End If

                '==================================================
                '判定票印刷
                '==================================================
                '2019/04/24
                '1枚単位でテンプレートが変わる可能性があるためはじめにソート用のDataTableを作成して
                '1枚単位でプリントに飛ばす
                strSQL = "SELECT T1.ロットID, T1.レコード番号 "
                strSQL &= "FROM T_判定票印刷 AS T1 INNER JOIN "
                strSQL &= "T_印刷ソート AS T2 ON T1.ロットID = T2.ロットID AND T1.レコード番号 = T2.レコード番号 INNER JOIN "
                strSQL &= "T_判定票管理 AS T3 ON T1.ロットID = T3.ロットID AND T1.レコード番号 = T3.レコード番号 INNER JOIN "
                strSQL &= "T_印刷管理個別 AS T4 ON T2.ロットID = T4.ロットID AND T2.会社コード = T4.会社コード "
                strSQL &= "AND T2.所属事業所コード = T4.所属事業所コード AND T2.印刷ID = T4.印刷ID "
                strSQL &= "WHERE T1.ロットID = '" & strLotID & "' "
                strSQL &= "AND T2.会社コード = '" & dtPrintManage.Rows(iRow)("会社コード") & "' "
                strSQL &= "AND T2.所属事業所コード = '" & dtPrintManage.Rows(iRow)("所属事業所コード") & "' "
                strSQL &= "AND T2.印刷ID = " & dtPrintManage.Rows(iRow)("印刷ID") & " "
                strSQL &= "AND T2.帳票種別ID = 4 "
                strSQL &= "ORDER BY CASE WHEN ISNULL(T1.所属部名, '') = '' THEN 1 ELSE 0 END, "
                strSQL &= "T1.所属部名, "
                strSQL &= "CASE WHEN ISNULL(T1.所属課名, '') = '' THEN 1 ELSE 0 END, "
                strSQL &= "T1.所属課名, T3.社員コード"
                dt = sqlProcess.DB_SELECT_DATATABLE(strSQL)
                '1レコードずつ回す
                For i As Integer = 0 To dt.Rows.Count - 1
                    strSQL = "SELECT T1.ロットID, T1.レコード番号, T1.システムID, T1.氏名カナ, T1.氏名, T1.会社, T1.所属事業所, "
                    strSQL &= "T1.所属部名, T1.所属課名, T1.役職名, T1.性別, T1.採用年月日, T1.生年月日, T1.受診年齢, T1.健診種別, T1.受診日, T1.身長, T1.体重, "
                    strSQL &= "T1.体重記号, T1.体重上限, T1.体重下限, T1.BMI, T1.BMI記号, T1.BMI上限, T1.BMI下限, T1.腹囲, T1.腹囲記号, T1.腹囲上限, T1.腹囲下限, "
                    strSQL &= "T1.視力裸眼右, T1.視力裸眼左, T1.視力矯正右, T1.視力矯正左, T1.聴力右1000, T1.聴力右4000, T1.聴力左1000, T1.聴力左4000, "
                    strSQL &= "T1.聴力その他, T1.血圧1回収縮期, T1.血圧1回収縮期記号, T1.血圧1回収縮期上限, T1.血圧1回収縮期下限, "
                    strSQL &= "T1.血圧1回拡張期, T1.血圧1回拡張期記号, T1.血圧1回拡張期上限, T1.血圧1回拡張期下限, T1.尿糖定性, T1.尿蛋白定性, "
                    strSQL &= "T1.総コレステロール, T1.総コレステロール記号, T1.総コレステロール上限, T1.総コレステロール下限, "
                    strSQL &= "T1.HDLコレステロール, T1.HDLコレステロール記号, T1.HDLコレステロール上限, T1.HDLコレステロール下限, "
                    strSQL &= "T1.中性脂肪, T1.中性脂肪記号, T1.中性脂肪上限, T1.中性脂肪下限, "
                    strSQL &= "T1.LDLコレステロール, T1.LDLコレステロール記号, T1.LDLコレステロール上限, T1.LDLコレステロール下限, "
                    strSQL &= "T1.GOT, T1.GOT記号, T1.GOT上限, T1.GOT下限, T1.GPT, T1.GPT記号, T1.GPT上限, T1.GPT下限, "
                    strSQL &= "T1.ガンマGTP, T1.ガンマGTP記号, T1.ガンマGTP上限, T1.ガンマGTP下限, "
                    strSQL &= "T1.クレアチニン, T1.クレアチニン記号, T1.クレアチニン上限, T1.クレアチニン下限, "
                    strSQL &= "T1.尿酸, T1.尿酸記号, T1.尿酸上限, T1.尿酸下限, T1.赤血球, T1.赤血球記号, T1.赤血球上限, T1.赤血球下限, "
                    strSQL &= "T1.血色素量, T1.血色素量記号, T1.血色素量上限, T1.血色素量下限, "
                    strSQL &= "T1.空腹時血糖, T1.空腹時血糖記号, T1.空腹時血糖上限, T1.空腹時血糖下限, "
                    strSQL &= "T1.随時血糖, T1.随時血糖記号, T1.随時血糖上限, T1.随時血糖下限, T1.HbA1c, T1.HbA1c記号, T1.HbA1c上限, T1.HbA1c下限, "
                    strSQL &= "T1.受診検査機関名称, T1.会場局名称, T1.総合判定, T1.健診実施医師名, T1.判定医師名, T1.判定日付, T1.視力判定, T1.聴力判定, "
                    strSQL &= "T1.血圧判定, T1.尿糖判定, T1.尿蛋白判定, T1.血中脂質判定, T1.肝機能判定, T1.腎機能判定, T1.尿酸判定, T1.血液判定, "
                    strSQL &= "T1.血糖判定, T1.胸部X線判定結果, T1.心電図判定結果, T1.総合成績判定, T1.就業区分, T1.胸部X線所見, T1.胸部X線判定, "
                    strSQL &= "T1.心電図所見, T1.心電図判定, T1.既往歴, T1.自覚症状, T1.診察所見, T1.総合コメント, T1.産業医の意見, T1.QRコード, T4.ラベル連番, "
                    '2019/04/24
                    '3項目追加
                    strSQL &= "T3.年度, ISNULL(T6.印影画像パス, '') AS 産業医印影, ISNULL(T7.印影画像パス, '') AS 判定医印影 "
                    strSQL &= "FROM T_判定票印刷 AS T1 INNER JOIN "
                    strSQL &= "T_印刷ソート AS T2 ON T1.ロットID = T2.ロットID AND T1.レコード番号 = T2.レコード番号 INNER JOIN "
                    strSQL &= "T_判定票管理 AS T3 ON T1.ロットID = T3.ロットID AND T1.レコード番号 = T3.レコード番号 INNER JOIN "
                    strSQL &= "T_印刷管理個別 AS T4 ON T2.ロットID = T4.ロットID AND T2.会社コード = T4.会社コード "
                    strSQL &= "AND T2.所属事業所コード = T4.所属事業所コード AND T2.印刷ID = T4.印刷ID LEFT OUTER JOIN "
                    '2019/04/24
                    '3テーブル追加
                    strSQL &= "T_医師 AS T5 ON T1.ロットID = T5.ロットID AND T1.レコード番号 = T5.レコード番号 LEFT OUTER JOIN "
                    strSQL &= "M_産業医 AS T6 ON T5.産業医ID = T6.産業医ID LEFT OUTER JOIN "
                    strSQL &= "M_判定医 AS T7 ON T5.判定医ID = T7.判定医ID "
                    strSQL &= "WHERE T1.ロットID = '" & strLotID & "' "
                    strSQL &= "AND T1.レコード番号 = " & dt.Rows(i)("レコード番号")
                    strSQL &= "AND T2.印刷ID = " & dtPrintManage.Rows(iRow)("印刷ID") & " "
                    strSQL &= "AND T2.帳票種別ID = 4 "
                    Dim dtPrint As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
                    If dtPrint.Rows.Count > 0 Then
                        '2019/06/19
                        '年度が「2019」以降の場合は新テンプレートとする
                        If CInt(dtPrint.Rows(0)("年度")) >= 2019 Then
                            '印刷処理
                            Print(strSQL, PrintCategory.Checkup, , , "result2019.flxr")
                        Else
                            '印刷処理
                            Print(strSQL, PrintCategory.Checkup)
                        End If

                    End If
                Next
                If dt.Rows.Count > 0 Then
                    '判定票印刷日時書き込み
                    WritePrintDate(strLotID, PrintCategory.Checkup, 0, dtPrintManage.Rows(iRow)("会社コード"), dtPrintManage.Rows(iRow)("所属事業所コード"), dtPrintManage.Rows(iRow)("印刷ID"))
                    '該当の会社コード、所属事業所コード、印刷IDすべてのチェックフラグを取り下げる
                    strSQL = "UPDATE T_印刷ソート SET チェックフラグ = 0 "
                    strSQL &= "WHERE ロットID = '" & strLotID & "' "
                    strSQL &= "AND 会社コード = '" & dtPrintManage.Rows(iRow)("会社コード") & "' "
                    strSQL &= "AND 所属事業所コード = '" & dtPrintManage.Rows(iRow)("所属事業所コード") & "' "
                    strSQL &= "AND 印刷ID = " & dtPrintManage.Rows(iRow)("印刷ID")
                    sqlProcess.DB_UPDATE(strSQL)
                End If

                strHeaderSheet = dtPrintManage.Rows(iRow)("重量ヘッダ")


                'strSQL = "SELECT T1.ロットID, T1.レコード番号, T1.システムID, T1.氏名カナ, T1.氏名, T1.会社, T1.所属事業所, "
                'strSQL &= "T1.所属部名, T1.所属課名, T1.役職名, T1.性別, T1.採用年月日, T1.生年月日, T1.受診年齢, T1.健診種別, T1.受診日, T1.身長, T1.体重, "
                'strSQL &= "T1.体重記号, T1.体重上限, T1.体重下限, T1.BMI, T1.BMI記号, T1.BMI上限, T1.BMI下限, T1.腹囲, T1.腹囲記号, T1.腹囲上限, T1.腹囲下限, "
                'strSQL &= "T1.視力裸眼右, T1.視力裸眼左, T1.視力矯正右, T1.視力矯正左, T1.聴力右1000, T1.聴力右4000, T1.聴力左1000, T1.聴力左4000, "
                'strSQL &= "T1.聴力その他, T1.血圧1回収縮期, T1.血圧1回収縮期記号, T1.血圧1回収縮期上限, T1.血圧1回収縮期下限, "
                'strSQL &= "T1.血圧1回拡張期, T1.血圧1回拡張期記号, T1.血圧1回拡張期上限, T1.血圧1回拡張期下限, T1.尿糖定性, T1.尿蛋白定性, "
                'strSQL &= "T1.総コレステロール, T1.総コレステロール記号, T1.総コレステロール上限, T1.総コレステロール下限, "
                'strSQL &= "T1.HDLコレステロール, T1.HDLコレステロール記号, T1.HDLコレステロール上限, T1.HDLコレステロール下限, "
                'strSQL &= "T1.中性脂肪, T1.中性脂肪記号, T1.中性脂肪上限, T1.中性脂肪下限, "
                'strSQL &= "T1.LDLコレステロール, T1.LDLコレステロール記号, T1.LDLコレステロール上限, T1.LDLコレステロール下限, "
                'strSQL &= "T1.GOT, T1.GOT記号, T1.GOT上限, T1.GOT下限, T1.GPT, T1.GPT記号, T1.GPT上限, T1.GPT下限, "
                'strSQL &= "T1.ガンマGTP, T1.ガンマGTP記号, T1.ガンマGTP上限, T1.ガンマGTP下限, "
                'strSQL &= "T1.クレアチニン, T1.クレアチニン記号, T1.クレアチニン上限, T1.クレアチニン下限, "
                'strSQL &= "T1.尿酸, T1.尿酸記号, T1.尿酸上限, T1.尿酸下限, T1.赤血球, T1.赤血球記号, T1.赤血球上限, T1.赤血球下限, "
                'strSQL &= "T1.血色素量, T1.血色素量記号, T1.血色素量上限, T1.血色素量下限, "
                'strSQL &= "T1.空腹時血糖, T1.空腹時血糖記号, T1.空腹時血糖上限, T1.空腹時血糖下限, "
                'strSQL &= "T1.随時血糖, T1.随時血糖記号, T1.随時血糖上限, T1.随時血糖下限, T1.HbA1c, T1.HbA1c記号, T1.HbA1c上限, T1.HbA1c下限, "
                'strSQL &= "T1.受診検査機関名称, T1.会場局名称, T1.総合判定, T1.健診実施医師名, T1.判定医師名, T1.判定日付, T1.視力判定, T1.聴力判定, "
                'strSQL &= "T1.血圧判定, T1.尿糖判定, T1.尿蛋白判定, T1.血中脂質判定, T1.肝機能判定, T1.腎機能判定, T1.尿酸判定, T1.血液判定, "
                'strSQL &= "T1.血糖判定, T1.胸部X線判定結果, T1.心電図判定結果, T1.総合成績判定, T1.就業区分, T1.胸部X線所見, T1.胸部X線判定, "
                'strSQL &= "T1.心電図所見, T1.心電図判定, T1.既往歴, T1.自覚症状, T1.診察所見, T1.総合コメント, T1.産業医の意見, T1.QRコード, T4.ラベル連番 "
                'strSQL &= "FROM T_判定票印刷 AS T1 INNER JOIN "
                'strSQL &= "T_印刷ソート AS T2 ON T1.ロットID = T2.ロットID AND T1.レコード番号 = T2.レコード番号 INNER JOIN "
                'strSQL &= "T_判定票管理 AS T3 ON T1.ロットID = T3.ロットID AND T1.レコード番号 = T3.レコード番号 INNER JOIN "
                'strSQL &= "T_印刷管理個別 AS T4 ON T2.ロットID = T4.ロットID AND T2.会社コード = T4.会社コード "
                'strSQL &= "AND T2.所属事業所コード = T4.所属事業所コード AND T2.印刷ID = T4.印刷ID "
                'strSQL &= "WHERE T1.ロットID = '" & strLotID & "' "
                'strSQL &= "AND T2.会社コード = '" & dtPrintManage.Rows(iRow)("会社コード") & "' "
                'strSQL &= "AND T2.所属事業所コード = '" & dtPrintManage.Rows(iRow)("所属事業所コード") & "' "
                'strSQL &= "AND T2.印刷ID = " & dtPrintManage.Rows(iRow)("印刷ID") & " "
                'strSQL &= "AND T2.帳票種別ID = 4 "
                'strSQL &= "ORDER BY CASE WHEN ISNULL(T1.所属部名, '') = '' THEN 1 ELSE 0 END, "
                'strSQL &= "T1.所属部名, "
                'strSQL &= "CASE WHEN ISNULL(T1.所属課名, '') = '' THEN 1 ELSE 0 END, "
                'strSQL &= "T1.所属課名, T3.社員コード"
                'dt = sqlProcess.DB_SELECT_DATATABLE(strSQL)
                'If dt.Rows.Count > 0 Then
                '    '印刷処理
                '    Print(strSQL, PrintCategory.Checkup)
                '    '判定票印刷日時書き込み
                '    WritePrintDate(strLotID, PrintCategory.Checkup, 0, dtPrintManage.Rows(iRow)("会社コード"), dtPrintManage.Rows(iRow)("所属事業所コード"), dtPrintManage.Rows(iRow)("印刷ID"))
                '    '該当の会社コード、所属事業所コード、印刷IDすべてのチェックフラグを取り下げる
                '    strSQL = "UPDATE T_印刷ソート SET チェックフラグ = 0 "
                '    strSQL &= "WHERE ロットID = '" & strLotID & "' "
                '    strSQL &= "AND 会社コード = '" & dtPrintManage.Rows(iRow)("会社コード") & "' "
                '    strSQL &= "AND 所属事業所コード = '" & dtPrintManage.Rows(iRow)("所属事業所コード") & "' "
                '    strSQL &= "AND 印刷ID = " & dtPrintManage.Rows(iRow)("印刷ID")
                '    sqlProcess.DB_UPDATE(strSQL)
                'End If

                'strHeaderSheet = dtPrintManage.Rows(iRow)("重量ヘッダ")

            Next

        Catch ex As Exception

            Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & ex.StackTrace)
            MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally

            sqlProcess.Close()
            '設定されていた通常使うプリンタに戻す
            SetDefaultPrinter(strDefaultPrinter)

        End Try

    End Sub

    ''' <summary>
    ''' リーフレット印刷
    ''' </summary>
    ''' <param name="strLotID">対象ロットID</param>
    ''' <param name="iRecordNumber">単体で印刷したいときにレコード番号を指定する</param>
    Public Sub PrintLeaflet(ByVal strLotID As String, ByVal blnPrintWeightHeader As Boolean, ByVal strWeightHeader As String, Optional ByVal iRecordNumber As Integer = 0)

        Dim sqlProcess As New SQLProcess
        Dim strSQL As String = ""
        Dim dt As DataTable = Nothing

        '現在の通常使うプリンタ名を取得
        'プリンタ名の取得
        'Finallyで通常使うプリンタを戻す
        Dim strDefaultPrinter As String = pd.PrinterSettings.PrinterName
        XmlSettings.LoadFromXmlFile()
        'プリンタドライバの切り替え
        SetDefaultPrinter(XmlSettings.Instance.Printer_Leaflet)

        Try
			'==================================================
			'2018/08/30
			'6枚以上のリーフレットを先から出力するように変更
			'==================================================
			'2017/08/09
			'一社員6枚組のリーフレットの印刷
			strSQL = "SELECT T1.ロットID, T1.会社コード, T1.所属事業所コード, T1.印刷ID, T1.重量ヘッダ, T1.ラベル連番 "
			strSQL &= "FROM T_印刷管理 AS T1 INNER JOIN "
			strSQL &= "T_印刷ソート AS T2 ON T1.ロットID = T2.ロットID "
			strSQL &= "AND T1.会社コード = T2.会社コード "
			strSQL &= "AND T1.所属事業所コード = T2.所属事業所コード "
			strSQL &= "AND T1.印刷ID = T2.印刷ID "
			strSQL &= "WHERE T1.ロットID = '" & strLotID & "' "
			strSQL &= "AND T2.枚数 >= 6 "
			If blnPrintWeightHeader Then
				'重量ヘッダ単位
				If strWeightHeader = "全て" Then
					'検索条件の追加はなし
				Else
					strSQL &= "AND T1.重量ヘッダ = '" & strWeightHeader & "' "
				End If
			End If
			strSQL &= "GROUP BY T1.ロットID, T1.会社コード, T1.所属事業所コード, T1.印刷ID, T1.重量ヘッダ, T1.ラベル連番 "
			strSQL &= "ORDER BY T1.ラベル連番"
			Dim dtLeaf6Header As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)

			Dim strHeaderSheet6 As String = ""
			For iRow As Integer = 0 To dtLeaf6Header.Rows.Count - 1
				'一社員でリーフレットが6枚存在する重量ヘッダ単位で回す
				'==================================================
				'重量ヘッダシート印刷
				'==================================================
				'1レコードでも存在したら重量ヘッダシート出力判断
				If Not dtLeaf6Header.Rows(iRow)("重量ヘッダ") = strHeaderSheet6 Then
					'前回ヘッダと相違していたらヘッダシートを印刷する
					strSQL = "SELECT '" & strLotID.Substring(0, 8) & "' AS インポート日, T3.重量ヘッダ, T3.対象者一覧, T3.保健指導名簿, T3.判定票枚数, T3.判定票件数, "
					strSQL &= "T3.リーフレット枚数, T3.リーフレット件数, T3.総枚数 + 1 AS 総枚数, T3.リーフレット枚数 AS 枚数, "
					strSQL &= "T3.リーフレット件数 AS 件数, "
					strSQL &= "(SELECT COUNT(重量ヘッダ) FROM T_印刷管理 "
					strSQL &= "WHERE ロットID = '" & strLotID & "' "
					'リーフレットの存在する通数のみ合算
					strSQL &= "AND 重量ヘッダ = '" & dtLeaf6Header.Rows(iRow)("重量ヘッダ") & "' AND リーフレット枚数 > 0) AS 通数 "
					strSQL &= "FROM (SELECT T1.重量ヘッダ, "
					strSQL &= "0 AS 対象者一覧, "
					strSQL &= "0 AS 保健指導名簿, "   '判定票の方で出力されるので0
					'strSQL &= "ISNULL(SUM(CASE WHEN T2.帳票種別ID = 3 THEN 1 ELSE 0 END), 0) AS 保健指導名簿, "
					strSQL &= "0 AS 判定票枚数, "
					strSQL &= "0 AS 判定票件数, "
					strSQL &= "ISNULL(SUM(CASE WHEN T2.帳票種別ID = 5 THEN T2.枚数 ELSE 0 END), 0) AS リーフレット枚数, "
					strSQL &= "ISNULL(SUM(CASE WHEN T2.帳票種別ID = 5 THEN 1 ELSE 0 END), 0) AS リーフレット件数, "
					strSQL &= "ISNULL(SUM(CASE WHEN T2.帳票種別ID = 5 THEN T2.枚数 ELSE 0 END), 0) AS 総枚数 "
					strSQL &= "FROM T_印刷管理 AS T1 INNER JOIN "
					strSQL &= "T_印刷ソート AS T2 ON T1.ロットID = T2.ロットID AND T1.会社コード = T2.会社コード "
					strSQL &= "AND T1.所属事業所コード = T2.所属事業所コード AND T1.印刷ID = T2.印刷ID "
					strSQL &= "WHERE T1.ロットID = '" & strLotID & "' "
					strSQL &= "AND T2.帳票種別ID != 0 " 'ラベル以外
					strSQL &= "AND T2.帳票種別ID != 2 " '対象者一覧を除外
					strSQL &= "AND T2.帳票種別ID != 4 " '判定票を除外
					'2017/08/09
					'一社員6枚組のみ検索する
					strSQL &= "AND T2.枚数 >= 6 "
					strSQL &= "AND T1.重量ヘッダ = '" & dtLeaf6Header.Rows(iRow)("重量ヘッダ") & "' "
					strSQL &= "GROUP BY T1.重量ヘッダ) AS T3"

					dt = sqlProcess.DB_SELECT_DATATABLE(strSQL)
					If dt.Rows.Count > 0 Then
						'結果があった場合印刷
						Print(strSQL, PrintCategory.WeightHeaderHand)

					End If

				End If
				'==================================================
				'リーフレット印刷
				'==================================================
				strSQL = "SELECT T1.ロットID, T1.レコード番号 "
				strSQL &= "FROM T_リーフレット印刷 AS T1 INNER JOIN "
				strSQL &= "T_印刷ソート AS T2 ON T1.ロットID = T2.ロットID AND T1.レコード番号 = T2.レコード番号 INNER JOIN "
				strSQL &= "T_判定票管理 AS T3 ON T1.ロットID = T3.ロットID AND T1.レコード番号 = T3.レコード番号 "
				strSQL &= "WHERE T1.ロットID = '" & strLotID & "' "
				strSQL &= "AND T2.会社コード = '" & dtLeaf6Header.Rows(iRow)("会社コード") & "' "
				strSQL &= "AND T2.所属事業所コード = '" & dtLeaf6Header.Rows(iRow)("所属事業所コード") & "' "
				strSQL &= "AND T2.印刷ID = " & dtLeaf6Header.Rows(iRow)("印刷ID") & " "
				strSQL &= "AND T3.リーフレット無効 = 0 "    'リーフレット無効が立っているものは印刷対象としない
				'2017/08/09
				'一社員6枚組以上のみ検索
				strSQL &= "AND T2.枚数 >= 6 "
				strSQL &= "GROUP BY T1.ロットID, T1.レコード番号, T3.所属部名, T3.所属課名, T3.社員コード "
				'strSQL &= "ORDER BY CASE WHEN ISNULL(T1.所属部課名, '') = '' THEN 1 ELSE 0 END, "
				'strSQL &= "T1.所属部課名, "
				strSQL &= "ORDER BY CASE WHEN ISNULL(T3.所属部名, '') = '' THEN 1 ELSE 0 END, "
				strSQL &= "T3.所属部名, "
				strSQL &= "CASE WHEN ISNULL(T3.所属課名, '') = '' THEN 1 ELSE 0 END, "
				strSQL &= "T3.所属課名, T3.社員コード"
				Dim dtLeaflet6 As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
				'DATATABLEを回して帳票タイプ単位で印刷する
				For i As Integer = 0 To dtLeaflet6.Rows.Count - 1
					strSQL = "SELECT T1.帳票タイプ FROM T_リーフレット印刷 AS T1 INNER JOIN "
					strSQL &= "M_帳票タイプ AS T2 ON T1.帳票タイプ = T2.帳票タイプ "
					strSQL &= "WHERE T1.ロットID = '" & strLotID & "' "
					strSQL &= "AND T1.レコード番号 = " & dtLeaflet6.Rows(i)("レコード番号")
					Dim dtFormType6 As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)

					For iFormType As Integer = 0 To dtFormType6.Rows.Count - 1
						'特定した帳票タイプを1つずつSQL文にしてプリントする
						strSQL = "SELECT T1.ロットID, T1.レコード番号, T1.システムID, T1.会社, T1.所属事業所, T1.所属部課名, "
						strSQL &= "T1.氏名, T1.局所会社名, T1.健康管理施設名, T1.郵便番号, T1.住所, T1.電話番号, T1.年度, "
						'2018/06/11
						'受診日を[yyyy/M/d]に変換する
						strSQL &= "FORMAT(CONVERT(DATE, T4.受診日), 'yyyy年M月d日') AS 受診日, "
						strSQL &= "T1.帳票タイプ, T1.結果値1, T1.結果値2, T1.結果値3, T1.BOC, T1.EOC, T1.PAR, "
						strSQL &= "T1.WAS1, T1.WAS2, T1.WAS3, T1.WAS4, T1.WAS5, T1.WAS6, T1.QRコード, T3.ラベル連番, T1.先頭マーク, "
						strSQL &= "CONVERT(VARCHAR, T1.トータルSEQ) + '-' + CONVERT(VARCHAR, T1.カレントSEQ) AS ページ "
						strSQL &= "FROM T_リーフレット印刷 AS T1 INNER JOIN "
						strSQL &= "T_印刷ソート AS T2 ON T1.ロットID = T2.ロットID "
						strSQL &= "AND T1.レコード番号 = T2.レコード番号 INNER JOIN "
						strSQL &= "T_印刷管理 AS T3 ON T2.ロットID = T3.ロットID "
						strSQL &= "AND T2.会社コード = T3.会社コード "
						strSQL &= "AND T2.所属事業所コード = T3.所属事業所コード "
						strSQL &= "AND T2.印刷ID = T3.印刷ID INNER JOIN "
						'==================================================
						'2018/06/11
						strSQL &= "T_リーフレット AS T4 ON T1.ロットID = T4.ロットID "
						strSQL &= "AND T1.レコード番号 = T4.レコード番号 "
						'==================================================
						strSQL &= "WHERE T1.ロットID = '" & strLotID & "' "
						strSQL &= "AND T1.レコード番号 = " & dtLeaflet6.Rows(i)("レコード番号") & " "
						strSQL &= "AND T2.印刷ID = " & dtLeaf6Header.Rows(iRow)("印刷ID") & " "
						strSQL &= "AND T1.帳票タイプ = '" & dtFormType6.Rows(iFormType)("帳票タイプ") & "' "
						strSQL &= "GROUP BY T1.ロットID, T1.レコード番号, T1.システムID, T1.会社, T1.所属事業所, T1.所属部課名, T1.氏名, "
						strSQL &= "T1.局所会社名, T1.健康管理施設名, T1.郵便番号, T1.住所, T1.電話番号, T1.年度, T4.受診日, T1.帳票タイプ, "
						strSQL &= "T1.結果値1, T1.結果値2, T1.結果値3, T1.BOC, T1.EOC, T1.PAR, T1.WAS1, T1.WAS2, T1.WAS3, "
						strSQL &= "T1.WAS4, T1.WAS5, T1.WAS6, T1.QRコード, T3.ラベル連番, T1.先頭マーク, T1.トータルSEQ, T1.カレントSEQ "
						'印刷処理
						Print(strSQL, PrintCategory.Leaflet, dtFormType6.Rows(iFormType)("帳票タイプ"))
						'2018/08/13
						'T_リーフ6チェックからチェックフラグを外す
						strSQL = "UPDATE T_リーフ6チェック SET チェックフラグ = 0 "
						strSQL &= "WHERE ロットID = '" & strLotID & "' "
						strSQL &= "AND レコード番号 = " & dtLeaflet6.Rows(i)("レコード番号") & " "
						strSQL &= "AND 帳票タイプ = '" & dtFormType6.Rows(iFormType)("帳票タイプ") & "'"
						sqlProcess.DB_UPDATE(strSQL)

					Next
					'該当レコード番号の印刷が終了した段階でT_印刷管理の「リーフレット印刷日時」を更新する
					WritePrintDate(strLotID, PrintCategory.Leaflet, dtLeaflet6.Rows(i)("レコード番号"), dtLeaf6Header.Rows(iRow)("会社コード"), dtLeaf6Header.Rows(iRow)("所属事業所コード"), dtLeaf6Header.Rows(iRow)("印刷ID"))
					'該当の会社コード、所属事業所コード、印刷IDすべてのチェックフラグを取り下げる
					strSQL = "UPDATE T_印刷ソート SET チェックフラグ = 0 "
					strSQL &= "WHERE ロットID = '" & strLotID & "' "
					strSQL &= "AND 会社コード = '" & dtLeaf6Header.Rows(iRow)("会社コード") & "' "
					strSQL &= "AND 所属事業所コード = '" & dtLeaf6Header.Rows(iRow)("所属事業所コード") & "' "
					strSQL &= "AND 印刷ID = " & dtLeaf6Header.Rows(iRow)("印刷ID")
					sqlProcess.DB_UPDATE(strSQL)

					strHeaderSheet6 = dtLeaf6Header.Rows(iRow)("重量ヘッダ")

				Next
			Next
			'==================================================

			If iRecordNumber = 0 Then
                'ロットID単位の全印刷
                'ロットID
                'ソート順
                '	重量ヘッダ(H～A順)
                '	会社コード
                '	所属事業所コード
                '	所属部名(NULLは最後)
                '	所属課名(NULLは最後)
                '	社員コード
                'テンプレートが変動するため、基本1枚1キュー

                'T_印刷管理内の対象ロットを重量ヘッダ、会社コード、所属事業所コードを考慮して回す
                strSQL = "SELECT ロットID, 会社コード, 所属事業所コード, 印刷ID, 重量ヘッダ, ラベル連番 "
                strSQL &= "FROM T_印刷管理 "
                strSQL &= "WHERE ロットID = '" & strLotID & "' "
                If blnPrintWeightHeader Then
                    '重量ヘッダ単位
                    If strWeightHeader = "全て" Then
                        'ロット内のすべてのラベルなので検索条件の追加は無し
                        ''==================================================
                        ''2017/07/20
                        ''緊急対応
                        'strSQL &= "AND ラベル連番 = 24 "
                        ''==================================================
                    Else
                        strSQL &= "AND 重量ヘッダ = '" & strWeightHeader & "' "
                    End If
                Else
                    '個別印刷
                    '2次元配列を回す

                End If
                ''==================================================
                ''※テスト用、本番前にコメントアウト！
                'strSQL &= "AND 会社コード = '2001' "
                'strSQL &= "AND 所属事業所コード = '970270' "
                ''==================================================
                strSQL &= "ORDER BY ラベル連番"
                'strSQL &= "ORDER BY 重量ヘッダ DESC, 会社コード, 所属事業所コード"
                Dim dtPrintManage As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
                Dim strHeaderSheet As String = ""   '前回ヘッダシート格納用
                Dim strImportDate As String = strLotID.Substring(0, 8)  'ロットIDの先頭8桁(インポート日)を取得する

                For iRow As Integer = 0 To dtPrintManage.Rows.Count - 1
                    '会社コード、所属事業所コード、重量ヘッダ単位で回す
                    '==================================================
                    '重量ヘッダシート印刷
                    '==================================================
                    '1レコードでも存在したら重量ヘッダシート出力判断
                    If Not dtPrintManage.Rows(iRow)("重量ヘッダ") = strHeaderSheet Then
                        '前回ヘッダと相違していたらヘッダシートを印刷する
                        strSQL = "SELECT '" & strImportDate & "' AS インポート日, T3.重量ヘッダ, T3.対象者一覧, T3.保健指導名簿, T3.判定票枚数, T3.判定票件数, "
                        strSQL &= "T3.リーフレット枚数, T3.リーフレット件数, T3.総枚数 + 1 AS 総枚数, T3.リーフレット枚数 AS 枚数, "
                        strSQL &= "T3.リーフレット件数 AS 件数, "
                        strSQL &= "(SELECT COUNT(重量ヘッダ) FROM T_印刷管理 "
                        strSQL &= "WHERE ロットID = '" & strLotID & "' "
                        'リーフレットの存在する通数のみ合算
                        strSQL &= "AND 重量ヘッダ = '" & dtPrintManage.Rows(iRow)("重量ヘッダ") & "' AND リーフレット枚数 > 0) AS 通数 "
                        strSQL &= "FROM (SELECT T1.重量ヘッダ, "
                        strSQL &= "0 AS 対象者一覧, "
                        strSQL &= "0 AS 保健指導名簿, "   '判定票の方で出力されるので0
                        'strSQL &= "ISNULL(SUM(CASE WHEN T2.帳票種別ID = 3 THEN 1 ELSE 0 END), 0) AS 保健指導名簿, "
                        strSQL &= "0 AS 判定票枚数, "
                        strSQL &= "0 AS 判定票件数, "
                        strSQL &= "ISNULL(SUM(CASE WHEN T2.帳票種別ID = 5 THEN T2.枚数 ELSE 0 END), 0) AS リーフレット枚数, "
                        strSQL &= "ISNULL(SUM(CASE WHEN T2.帳票種別ID = 5 THEN 1 ELSE 0 END), 0) AS リーフレット件数, "
                        strSQL &= "ISNULL(SUM(CASE WHEN T2.帳票種別ID = 5 THEN T2.枚数 ELSE 0 END), 0) AS 総枚数 "
                        'strSQL &= "(SELECT ISNULL(COUNT(A1.カウント), 0) FROM ("
                        'strSQL &= "SELECT COUNT(システムID) AS カウント FROM T_印刷ソート AS T4 INNER JOIN "
                        'strSQL &= "T_判定票管理 AS T5 ON T4.ロットID = T5.ロットID AND T4.レコード番号 = T5.レコード番号 "
                        'strSQL &= "WHERE 帳票種別ID = 5 AND ロットID = '" & strLotID & "' "
                        'strSQL &= "AND T5.リーフレット無効 = 0 "
                        'strSQL &= "GROUP BY システムID) AS A1"
                        'strSQL &= ") AS リーフレット件数, "
                        'strSQL &= "(SELECT ISNULL(SUM(A1.カウント), 0) FROM ("
                        'strSQL &= "SELECT COUNT(システムID) AS カウント FROM T_印刷ソート AS T4 INNER JOIN "
                        'strSQL &= "T_判定票管理 AS T5 ON T4.ロットID = T5.ロットID AND T4.レコード番号 = T5.レコード番号 "
                        'strSQL &= "WHERE 帳票種別ID = 5 AND ロットID = '" & strLotID & "' "
                        'strSQL &= "AND T5.リーフレット無効 = 0 "
                        'strSQL &= "GROUP BY システムID) AS A1 "
                        'strSQL &= ") AS リーフレット枚数, "
                        'strSQL &= "COUNT(T1.ロットID) AS 総枚数 "
                        strSQL &= "FROM T_印刷管理 AS T1 INNER JOIN "
                        strSQL &= "T_印刷ソート AS T2 ON T1.ロットID = T2.ロットID AND T1.会社コード = T2.会社コード "
                        strSQL &= "AND T1.所属事業所コード = T2.所属事業所コード AND T1.印刷ID = T2.印刷ID "
                        strSQL &= "WHERE T1.ロットID = '" & strLotID & "' "
                        strSQL &= "AND T2.帳票種別ID != 0 " 'ラベル以外
                        strSQL &= "AND T2.帳票種別ID != 2 " '対象者一覧を除外
                        strSQL &= "AND T2.帳票種別ID != 4 " '判定票を除外
                        '2017/08/09
                        '一社員6枚組のリーフレットを除外する
                        strSQL &= "AND T2.枚数 BETWEEN 1 AND 5 "
                        strSQL &= "AND T1.重量ヘッダ = '" & dtPrintManage.Rows(iRow)("重量ヘッダ") & "' "
                        strSQL &= "GROUP BY T1.重量ヘッダ) AS T3"

                        dt = sqlProcess.DB_SELECT_DATATABLE(strSQL)
                        If dt.Rows.Count > 0 Then
							'結果があった場合印刷
							'Using sw As New System.IO.StreamWriter("C:\JPTemp\07_TEMP\PrintProcess.log", True, System.Text.Encoding.GetEncoding("Shift-JIS"))
							'	sw.WriteLine(strSQL)
							'End Using
							Print(strSQL, PrintCategory.WeightHeader)

						End If
                    End If
                    '==================================================
                    'リーフレット印刷
                    '==================================================
                    strSQL = "SELECT T1.ロットID, T1.レコード番号 "
                    strSQL &= "FROM T_リーフレット印刷 AS T1 INNER JOIN "
                    strSQL &= "T_印刷ソート AS T2 ON T1.ロットID = T2.ロットID AND T1.レコード番号 = T2.レコード番号 INNER JOIN "
                    strSQL &= "T_判定票管理 AS T3 ON T1.ロットID = T3.ロットID AND T1.レコード番号 = T3.レコード番号 "
                    strSQL &= "WHERE T1.ロットID = '" & strLotID & "' "
                    strSQL &= "AND T2.会社コード = '" & dtPrintManage.Rows(iRow)("会社コード") & "' "
                    strSQL &= "AND T2.所属事業所コード = '" & dtPrintManage.Rows(iRow)("所属事業所コード") & "' "
                    strSQL &= "AND T2.印刷ID = " & dtPrintManage.Rows(iRow)("印刷ID") & " "
                    strSQL &= "AND T3.リーフレット無効 = 0 "    'リーフレット無効が立っているものは印刷対象としない
                    '2017/08/09
                    '一社員6枚組のリーフレットを除外する
                    strSQL &= "AND T2.枚数 BETWEEN 1 AND 5 "
                    strSQL &= "GROUP BY T1.ロットID, T1.レコード番号, T3.所属部名, T3.所属課名, T3.社員コード "
                    'strSQL &= "ORDER BY CASE WHEN ISNULL(T1.所属部課名, '') = '' THEN 1 ELSE 0 END, "
                    'strSQL &= "T1.所属部課名, "
                    strSQL &= "ORDER BY CASE WHEN ISNULL(T3.所属部名, '') = '' THEN 1 ELSE 0 END, "
                    strSQL &= "T3.所属部名, "
                    strSQL &= "CASE WHEN ISNULL(T3.所属課名, '') = '' THEN 1 ELSE 0 END, "
                    strSQL &= "T3.所属課名, T3.社員コード"
                    Dim dtLeaflet As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
                    'DATATABLEを回して帳票タイプ単位で印刷する
                    For i As Integer = 0 To dtLeaflet.Rows.Count - 1
                        'システムID単位の帳票タイプをリスト化してそれぞれSQL文を作成してプリント処理に行く
                        'strSQL = "SELECT T1.帳票タイプ FROM "
                        'strSQL &= "T_リーフレット印刷 AS T1 INNER JOIN "
                        'strSQL &= "T_印刷ソート AS T2 ON T1.ロットID = T2.ロットID AND T1.レコード番号 = T2.レコード番号 INNER JOIN "
                        'strSQL &= "T_判定票管理 AS T3 ON T1.ロットID = T3.ロットID AND T1.レコード番号 = T3.レコード番号 INNER JOIN "
                        'strSQL &= "T_印刷管理 AS T4 ON T2.ロットID = T4.ロットID AND T2.会社コード = T4.会社コード AND T2.所属事業所コード = T4.所属事業所コード AND T2.印刷ID = T4.印刷ID INNER JOIN "
                        'strSQL &= "M_帳票タイプ AS T5 ON T1.帳票タイプ = T5.帳票タイプ "
                        'strSQL &= "WHERE T1.ロットID = '" & strLotID & "' "
                        'strSQL &= "AND T1.レコード番号 = " & dtLeaflet.Rows(i)("レコード番号") & " "
                        'strSQL &= "AND T2.会社コード = '" & dtPrintManage.Rows(iRow)("会社コード") & "' "
                        'strSQL &= "AND T2.所属事業所コード = '" & dtPrintManage.Rows(iRow)("所属事業所コード") & "' "
                        'strSQL &= "AND T2.印刷ID = " & dtPrintManage.Rows(iRow)("印刷ID") & " "
                        'strSQL &= "AND T3.リーフレット無効 = 0 "    'リーフレット無効が立っているものは印刷対象としない
                        'strSQL &= "GROUP BY T1.ロットID, T1.レコード番号, T1.システムID, T1.会社, T1.所属事業所, T1.所属部課名, T1.氏名, "
                        'strSQL &= "T1.局所会社名, T1.健康管理施設名, T1.郵便番号, T1.住所, T1.電話番号, T1.年度, T1.帳票タイプ, "
                        'strSQL &= "T1.結果値1, T1.結果値2, T1.結果値3, T1.BOC, T1.EOC, T1.PAR, T1.WAS1, T1.WAS2, T1.WAS3, T1.WAS4, T1.WAS5, T1.WAS6, "
                        'strSQL &= "T1.QRコード, T4.ラベル連番, T1.先頭マーク, T1.トータルSEQ, T1.カレントSEQ, T5.ID "
                        'strSQL &= "ORDER BY T5.ID"
                        strSQL = "SELECT T1.帳票タイプ FROM T_リーフレット印刷 AS T1 INNER JOIN "
                        strSQL &= "M_帳票タイプ AS T2 ON T1.帳票タイプ = T2.帳票タイプ "
                        strSQL &= "WHERE T1.ロットID = '" & strLotID & "' "
                        strSQL &= "AND T1.レコード番号 = " & dtLeaflet.Rows(i)("レコード番号")
                        Dim dtFormType As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)

                        '対象ロット番号、レコード番号のリーフレットが取得される。帳票タイプごとに複数レコードあり
                        For iFormType As Integer = 0 To dtFormType.Rows.Count - 1
							'特定した帳票タイプを1つずつSQL文にしてプリントする
							'帳票タイプごとに回す
							'strSQL = "SELECT T1.ロットID, T1.レコード番号, T1.システムID, T1.会社, T1.所属事業所, T1.所属部課名, T1.氏名, "
							'strSQL &= "T1.局所会社名, T1.健康管理施設名, T1.郵便番号, T1.住所, T1.電話番号, T1.年度, T1.帳票タイプ, "
							'strSQL &= "T1.結果値1, T1.結果値2, T1.結果値3, T1.BOC, T1.EOC, T1.PAR, T1.WAS1, T1.WAS2, T1.WAS3, T1.WAS4, T1.WAS5, T1.WAS6, "
							'strSQL &= "T1.QRコード, T4.ラベル連番, T1.先頭マーク, "
							'strSQL &= "CONVERT(VARCHAR, T1.トータルSEQ) + '-' + CONVERT(VARCHAR, T1.カレントSEQ) AS ページ "
							'strSQL &= "FROM T_リーフレット印刷 AS T1 INNER JOIN "
							'strSQL &= "T_印刷ソート AS T2 ON T1.ロットID = T2.ロットID AND T1.レコード番号 = T2.レコード番号 INNER JOIN "
							'strSQL &= "T_判定票管理 AS T3 ON T1.ロットID = T3.ロットID AND T1.レコード番号 = T3.レコード番号 INNER JOIN "
							'strSQL &= "T_印刷管理 AS T4 ON T2.ロットID = T4.ロットID AND T2.会社コード = T4.会社コード "
							'strSQL &= "AND T2.所属事業所コード = T4.所属事業所コード AND T2.印刷ID = T4.印刷ID INNER JOIN "
							'strSQL &= "M_帳票タイプ AS T5 ON T1.帳票タイプ = T5.帳票タイプ "
							'strSQL &= "WHERE T1.ロットID = '" & strLotID & "' "
							'strSQL &= "AND T1.レコード番号 = " & dtLeaflet.Rows(i)("レコード番号") & " "
							'strSQL &= "AND T2.会社コード = '" & dtPrintManage.Rows(iRow)("会社コード") & "' "
							'strSQL &= "AND T2.所属事業所コード = '" & dtPrintManage.Rows(iRow)("所属事業所コード") & "' "
							'strSQL &= "AND T2.印刷ID = " & dtPrintManage.Rows(iRow)("印刷ID") & " "
							'strSQL &= "AND T3.リーフレット無効 = 0 "    'リーフレット無効が立っているものは印刷対象としない
							'strSQL &= "AND T1.帳票タイプ = '" & dtFormType.Rows(iFormType)("帳票タイプ") & "' "
							'strSQL &= "GROUP BY T1.ロットID, T1.レコード番号, T1.システムID, T1.会社, T1.所属事業所, T1.所属部課名, T1.氏名, "
							'strSQL &= "T1.局所会社名, T1.健康管理施設名, T1.郵便番号, T1.住所, T1.電話番号, T1.年度, T1.帳票タイプ, "
							'strSQL &= "T1.結果値1, T1.結果値2, T1.結果値3, T1.BOC, T1.EOC, T1.PAR, T1.WAS1, T1.WAS2, T1.WAS3, T1.WAS4, T1.WAS5, T1.WAS6, "
							'strSQL &= "T1.QRコード, T4.ラベル連番, T1.先頭マーク, T1.トータルSEQ, T1.カレントSEQ, T5.ID "
							'strSQL &= "ORDER BY T5.ID"

							'2018/06/11
							'[T_リーフレット.受診日]を追加
							strSQL = "SELECT T1.ロットID, T1.レコード番号, T1.システムID, T1.会社, T1.所属事業所, T1.所属部課名, "
							strSQL &= "T1.氏名, T1.局所会社名, T1.健康管理施設名, T1.郵便番号, T1.住所, T1.電話番号, T1.年度, "
							'2018/06/11
							'受診日を[yyyy/M/d]に変換する
							strSQL &= "FORMAT(CONVERT(DATE, T4.受診日), 'yyyy年M月d日') AS 受診日, "
							strSQL &= "T1.帳票タイプ, T1.結果値1, T1.結果値2, T1.結果値3, T1.BOC, T1.EOC, T1.PAR, "
							strSQL &= "T1.WAS1, T1.WAS2, T1.WAS3, T1.WAS4, T1.WAS5, T1.WAS6, T1.QRコード, T3.ラベル連番, T1.先頭マーク, "
                            strSQL &= "CONVERT(VARCHAR, T1.トータルSEQ) + '-' + CONVERT(VARCHAR, T1.カレントSEQ) AS ページ "
                            strSQL &= "FROM T_リーフレット印刷 AS T1 INNER JOIN "
                            strSQL &= "T_印刷ソート AS T2 ON T1.ロットID = T2.ロットID "
                            strSQL &= "AND T1.レコード番号 = T2.レコード番号 INNER JOIN "
                            strSQL &= "T_印刷管理 AS T3 ON T2.ロットID = T3.ロットID "
                            strSQL &= "AND T2.会社コード = T3.会社コード "
                            strSQL &= "AND T2.所属事業所コード = T3.所属事業所コード "
							strSQL &= "AND T2.印刷ID = T3.印刷ID INNER JOIN "
							'==================================================
							'2018/06/11
							strSQL &= "T_リーフレット AS T4 ON T1.ロットID = T4.ロットID "
							strSQL &= "AND T1.レコード番号 = T4.レコード番号 "
							'==================================================
							strSQL &= "WHERE T1.ロットID = '" & strLotID & "' "
							strSQL &= "AND T1.レコード番号 = " & dtLeaflet.Rows(i)("レコード番号") & " "
                            strSQL &= "AND T2.印刷ID = " & dtPrintManage.Rows(iRow)("印刷ID") & " "
                            strSQL &= "AND T1.帳票タイプ = '" & dtFormType.Rows(iFormType)("帳票タイプ") & "' "
                            strSQL &= "GROUP BY T1.ロットID, T1.レコード番号, T1.システムID, T1.会社, T1.所属事業所, T1.所属部課名, T1.氏名, "
							strSQL &= "T1.局所会社名, T1.健康管理施設名, T1.郵便番号, T1.住所, T1.電話番号, T1.年度, T4.受診日, T1.帳票タイプ, "
							strSQL &= "T1.結果値1, T1.結果値2, T1.結果値3, T1.BOC, T1.EOC, T1.PAR, T1.WAS1, T1.WAS2, T1.WAS3, "
                            strSQL &= "T1.WAS4, T1.WAS5, T1.WAS6, T1.QRコード, T3.ラベル連番, T1.先頭マーク, T1.トータルSEQ, T1.カレントSEQ "
							'印刷処理
							'Using sw As New System.IO.StreamWriter("C:\JPTemp\07_TEMP\PrintProcess.log", True, System.Text.Encoding.GetEncoding("Shift-JIS"))
							'	sw.WriteLine(strSQL)
							'End Using
							Print(strSQL, PrintCategory.Leaflet, dtFormType.Rows(iFormType)("帳票タイプ"))

						Next

                    Next
                    '会社コード、所属事業所コード内の印刷が終了した段階でT_印刷管理の「リーフレット印刷日時」を更新する
                    'リーフレット印刷日時書き込み
                    WritePrintDate(strLotID, PrintCategory.Leaflet, 0, dtPrintManage.Rows(iRow)("会社コード"), dtPrintManage.Rows(iRow)("所属事業所コード"), dtPrintManage.Rows(iRow)("印刷ID"))
                    '該当の会社コード、所属事業所コード、印刷IDすべてのチェックフラグを取り下げる
                    strSQL = "UPDATE T_印刷ソート SET チェックフラグ = 0 "
                    strSQL &= "WHERE ロットID = '" & strLotID & "' "
                    strSQL &= "AND 会社コード = '" & dtPrintManage.Rows(iRow)("会社コード") & "' "
                    strSQL &= "AND 所属事業所コード = '" & dtPrintManage.Rows(iRow)("所属事業所コード") & "' "
                    strSQL &= "AND 印刷ID = " & dtPrintManage.Rows(iRow)("印刷ID")
                    sqlProcess.DB_UPDATE(strSQL)

                    strHeaderSheet = dtPrintManage.Rows(iRow)("重量ヘッダ")
                    'Application.DoEvents()
                Next

            Else
                '※保留
                ''レコード番号指定の単体印刷
                ''==================================================
                ''リーフレット印刷(レコード番号単位)
                ''==================================================
                'strSQL = "SELECT ロットID, レコード番号, システムID, 会社, 所属事業所, 所属部課名, 氏名, "
                'strSQL &= "局所会社名, 健康管理施設名, 郵便番号, 住所, 電話番号, 年度, 帳票タイプ, "
                'strSQL &= "結果値1, 結果値2, 結果値3, BOC, EOC, PAR, WAS1, WAS2, WAS3, WAS4, WAS5, WAS6, "
                'strSQL &= "QRコード "
                'strSQL &= "FROM T_リーフレット印刷 "
                'strSQL &= "WHERE ロットID = '" & strLotID & "' "
                'strSQL &= "AND レコード番号 = " & iRecordNumber
                'dt = sqlProcess.DB_SELECT_DATATABLE(strSQL)
                ''DATATABLEを回して帳票タイプ単位で印刷する
                'For i As Integer = 0 To dt.Rows.Count - 1
                '    '帳票タイプごとに回す
                '    '印刷処理
                '    Print(strSQL, PrintCategory.Leaflet, dt.Rows(i)("帳票タイプ"))
                '    'リーフレット印刷日時書き込み
                '    WritePrintDate(strLotID, PrintCategory.Leaflet, iRecordNumber)

                'Next

            End If

		Catch ex As Exception

            Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & ex.StackTrace)
            MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally

            sqlProcess.Close()
            '設定されていた通常使うプリンタに戻す
            SetDefaultPrinter(strDefaultPrinter)

        End Try

    End Sub

    ''' <summary>
    ''' リーフレット 所属事業所単位印刷
    ''' </summary>
    ''' <param name="strLotID"></param>
    Public Sub PrintLeafletOffice(ByVal strLotID As String)

        Dim sqlProcess As New SQLProcess
        Dim strSQL As String = ""
        Dim dt As DataTable = Nothing

        '現在の通常使うプリンタ名を取得
        'プリンタ名の取得
        'Finallyで通常使うプリンタを戻す
        Dim strDefaultPrinter As String = pd.PrinterSettings.PrinterName
        XmlSettings.LoadFromXmlFile()
        'プリンタドライバの切り替え
        SetDefaultPrinter(XmlSettings.Instance.Printer_Leaflet)

        Try
			'==================================================
			'2018/08/30
			'6枚以上のリーフレットを先から出力するように変更
			'==================================================
			'2017/08/09
			'一社員6枚組のリーフレットの印刷
			strSQL = "SELECT T1.ロットID, T1.会社コード, T1.所属事業所コード, T1.印刷ID, T1.重量ヘッダ, T1.ラベル連番 "
			strSQL &= "FROM T_印刷管理個別 AS T1 INNER JOIN "
			strSQL &= "T_印刷ソート AS T2 ON T1.ロットID = T2.ロットID "
			strSQL &= "AND T1.会社コード = T2.会社コード "
			strSQL &= "AND T1.所属事業所コード = T2.所属事業所コード "
			strSQL &= "AND T1.印刷ID = T2.印刷ID "
			strSQL &= "WHERE T1.ロットID = '" & strLotID & "' "
			strSQL &= "AND T2.枚数 >= 6 "
			strSQL &= "GROUP BY T1.ロットID, T1.会社コード, T1.所属事業所コード, T1.印刷ID, T1.重量ヘッダ, T1.ラベル連番 "
			strSQL &= "ORDER BY T1.ラベル連番"
			Dim dtLeaf6Header As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)

			Dim strHeaderSheet6 As String = ""
			For iRow As Integer = 0 To dtLeaf6Header.Rows.Count - 1
				'一社員でリーフレットが6枚以上存在する重量ヘッダ単位で回す
				'==================================================
				'重量ヘッダシート印刷
				'==================================================
				'1レコードでも存在したら重量ヘッダシート出力判断
				If Not dtLeaf6Header.Rows(iRow)("重量ヘッダ") = strHeaderSheet6 Then
					'前回ヘッダと相違していたらヘッダシートを印刷する
					strSQL = "SELECT '" & strLotID.Substring(0, 8) & "' AS インポート日, T3.重量ヘッダ, T3.対象者一覧, T3.保健指導名簿, T3.判定票枚数, T3.判定票件数, "
					strSQL &= "T3.リーフレット枚数, T3.リーフレット件数, T3.総枚数 + 1 AS 総枚数, T3.リーフレット枚数 AS 枚数, "
					strSQL &= "T3.リーフレット件数 AS 件数, "
					strSQL &= "(SELECT COUNT(重量ヘッダ) FROM T_印刷管理個別 "
					strSQL &= "WHERE ロットID = '" & strLotID & "' "
					'リーフレットの存在する通数のみ合算
					strSQL &= "AND 重量ヘッダ = '" & dtLeaf6Header.Rows(iRow)("重量ヘッダ") & "' AND リーフレット枚数 > 0) AS 通数 "
					strSQL &= "FROM (SELECT T1.重量ヘッダ, "
					strSQL &= "0 AS 対象者一覧, "
					strSQL &= "0 AS 保健指導名簿, "   '判定票の方で出力されるので0
					'strSQL &= "ISNULL(SUM(CASE WHEN T2.帳票種別ID = 3 THEN 1 ELSE 0 END), 0) AS 保健指導名簿, "
					strSQL &= "0 AS 判定票枚数, "
					strSQL &= "0 AS 判定票件数, "
					strSQL &= "ISNULL(SUM(CASE WHEN T2.帳票種別ID = 5 THEN T2.枚数 ELSE 0 END), 0) AS リーフレット枚数, "
					strSQL &= "ISNULL(SUM(CASE WHEN T2.帳票種別ID = 5 THEN 1 ELSE 0 END), 0) AS リーフレット件数, "
					strSQL &= "ISNULL(SUM(CASE WHEN T2.帳票種別ID = 5 THEN T2.枚数 ELSE 0 END), 0) AS 総枚数 "
					strSQL &= "FROM T_印刷管理個別 AS T1 INNER JOIN "
					strSQL &= "T_印刷ソート AS T2 ON T1.ロットID = T2.ロットID AND T1.会社コード = T2.会社コード "
					strSQL &= "AND T1.所属事業所コード = T2.所属事業所コード AND T1.印刷ID = T2.印刷ID "
					strSQL &= "WHERE T1.ロットID = '" & strLotID & "' "
					strSQL &= "AND T2.帳票種別ID != 0 " 'ラベル以外
					strSQL &= "AND T2.帳票種別ID != 2 " '対象者一覧を除外
					strSQL &= "AND T2.帳票種別ID != 4 " '判定票を除外
					'2017/08/09
					'一社員6枚組のみ検索する
					strSQL &= "AND T2.枚数 >= 6 "
					strSQL &= "AND T1.重量ヘッダ = '" & dtLeaf6Header.Rows(iRow)("重量ヘッダ") & "' "
					strSQL &= "GROUP BY T1.重量ヘッダ) AS T3"

					dt = sqlProcess.DB_SELECT_DATATABLE(strSQL)
					If dt.Rows.Count > 0 Then
						'結果があった場合印刷
						Print(strSQL, PrintCategory.WeightHeaderHand)

					End If

				End If
				'==================================================
				'リーフレット印刷
				'==================================================
				strSQL = "SELECT T1.ロットID, T1.レコード番号 "
				strSQL &= "FROM T_リーフレット印刷 AS T1 INNER JOIN "
				strSQL &= "T_印刷ソート AS T2 ON T1.ロットID = T2.ロットID AND T1.レコード番号 = T2.レコード番号 INNER JOIN "
				strSQL &= "T_判定票管理 AS T3 ON T1.ロットID = T3.ロットID AND T1.レコード番号 = T3.レコード番号 "
				strSQL &= "WHERE T1.ロットID = '" & strLotID & "' "
				strSQL &= "AND T2.会社コード = '" & dtLeaf6Header.Rows(iRow)("会社コード") & "' "
				strSQL &= "AND T2.所属事業所コード = '" & dtLeaf6Header.Rows(iRow)("所属事業所コード") & "' "
				strSQL &= "AND T2.印刷ID = " & dtLeaf6Header.Rows(iRow)("印刷ID") & " "
				strSQL &= "AND T3.リーフレット無効 = 0 "    'リーフレット無効が立っているものは印刷対象としない
				'2017/08/09
				'一社員6枚組のみ検索
				strSQL &= "AND T2.枚数 >= 6 "
				strSQL &= "GROUP BY T1.ロットID, T1.レコード番号, T3.所属部名, T3.所属課名, T3.社員コード "
				'strSQL &= "ORDER BY CASE WHEN ISNULL(T1.所属部課名, '') = '' THEN 1 ELSE 0 END, "
				'strSQL &= "T1.所属部課名, "
				strSQL &= "ORDER BY CASE WHEN ISNULL(T3.所属部名, '') = '' THEN 1 ELSE 0 END, "
				strSQL &= "T3.所属部名, "
				strSQL &= "CASE WHEN ISNULL(T3.所属課名, '') = '' THEN 1 ELSE 0 END, "
				strSQL &= "T3.所属課名, T3.社員コード"
				Dim dtLeaflet6 As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
				'DATATABLEを回して帳票タイプ単位で印刷する
				For i As Integer = 0 To dtLeaflet6.Rows.Count - 1
					strSQL = "SELECT T1.帳票タイプ FROM T_リーフレット印刷 AS T1 INNER JOIN "
					strSQL &= "M_帳票タイプ AS T2 ON T1.帳票タイプ = T2.帳票タイプ "
					strSQL &= "WHERE T1.ロットID = '" & strLotID & "' "
					strSQL &= "AND T1.レコード番号 = " & dtLeaflet6.Rows(i)("レコード番号")
					Dim dtFormType6 As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)

					For iFormType As Integer = 0 To dtFormType6.Rows.Count - 1
						'特定した帳票タイプを1つずつSQL文にしてプリントする
						strSQL = "SELECT T1.ロットID, T1.レコード番号, T1.システムID, T1.会社, T1.所属事業所, T1.所属部課名, "
						strSQL &= "T1.氏名, T1.局所会社名, T1.健康管理施設名, T1.郵便番号, T1.住所, T1.電話番号, T1.年度, "
						'2018/06/11
						'受診日を[yyyy/M/d]に変換する
						strSQL &= "FORMAT(CONVERT(DATE, T4.受診日), 'yyyy年M月d日') AS 受診日, "
						strSQL &= "T1.帳票タイプ, T1.結果値1, T1.結果値2, T1.結果値3, T1.BOC, T1.EOC, T1.PAR, "
						strSQL &= "T1.WAS1, T1.WAS2, T1.WAS3, T1.WAS4, T1.WAS5, T1.WAS6, T1.QRコード, T3.ラベル連番, T1.先頭マーク, "
						strSQL &= "CONVERT(VARCHAR, T1.トータルSEQ) + '-' + CONVERT(VARCHAR, T1.カレントSEQ) AS ページ "
						strSQL &= "FROM T_リーフレット印刷 AS T1 INNER JOIN "
						strSQL &= "T_印刷ソート AS T2 ON T1.ロットID = T2.ロットID "
						strSQL &= "AND T1.レコード番号 = T2.レコード番号 INNER JOIN "
						strSQL &= "T_印刷管理個別 AS T3 ON T2.ロットID = T3.ロットID "
						strSQL &= "AND T2.会社コード = T3.会社コード "
						strSQL &= "AND T2.所属事業所コード = T3.所属事業所コード "
						strSQL &= "AND T2.印刷ID = T3.印刷ID INNER JOIN "
						'==================================================
						'2018/06/11
						strSQL &= "T_リーフレット AS T4 ON T1.ロットID = T4.ロットID "
						strSQL &= "AND T1.レコード番号 = T4.レコード番号 "
						'==================================================
						strSQL &= "WHERE T1.ロットID = '" & strLotID & "' "
						strSQL &= "AND T1.レコード番号 = " & dtLeaflet6.Rows(i)("レコード番号") & " "
						strSQL &= "AND T2.印刷ID = " & dtLeaf6Header.Rows(iRow)("印刷ID") & " "
						strSQL &= "AND T1.帳票タイプ = '" & dtFormType6.Rows(iFormType)("帳票タイプ") & "' "
						strSQL &= "GROUP BY T1.ロットID, T1.レコード番号, T1.システムID, T1.会社, T1.所属事業所, T1.所属部課名, T1.氏名, "
						strSQL &= "T1.局所会社名, T1.健康管理施設名, T1.郵便番号, T1.住所, T1.電話番号, T1.年度, T4.受診日, T1.帳票タイプ, "
						strSQL &= "T1.結果値1, T1.結果値2, T1.結果値3, T1.BOC, T1.EOC, T1.PAR, T1.WAS1, T1.WAS2, T1.WAS3, "
						strSQL &= "T1.WAS4, T1.WAS5, T1.WAS6, T1.QRコード, T3.ラベル連番, T1.先頭マーク, T1.トータルSEQ, T1.カレントSEQ "
						'印刷処理
						Print(strSQL, PrintCategory.Leaflet, dtFormType6.Rows(iFormType)("帳票タイプ"))

					Next
					'該当レコード番号の印刷が終了した段階でT_印刷管理の「リーフレット印刷日時」を更新する
					WritePrintDate(strLotID, PrintCategory.Leaflet, dtLeaflet6.Rows(i)("レコード番号"), dtLeaf6Header.Rows(iRow)("会社コード"), dtLeaf6Header.Rows(iRow)("所属事業所コード"), dtLeaf6Header.Rows(iRow)("印刷ID"))
					'該当の会社コード、所属事業所コード、印刷IDすべてのチェックフラグを取り下げる
					strSQL = "UPDATE T_印刷ソート SET チェックフラグ = 0 "
					strSQL &= "WHERE ロットID = '" & strLotID & "' "
					strSQL &= "AND 会社コード = '" & dtLeaf6Header.Rows(iRow)("会社コード") & "' "
					strSQL &= "AND 所属事業所コード = '" & dtLeaf6Header.Rows(iRow)("所属事業所コード") & "' "
					strSQL &= "AND 印刷ID = " & dtLeaf6Header.Rows(iRow)("印刷ID")
					sqlProcess.DB_UPDATE(strSQL)

					strHeaderSheet6 = dtLeaf6Header.Rows(iRow)("重量ヘッダ")

				Next
			Next
			'==================================================

			'T_印刷管理内の対象ロットを重量ヘッダ、会社コード、所属事業所コードを考慮して回す
			strSQL = "SELECT ロットID, 会社コード, 所属事業所コード, 印刷ID, 重量ヘッダ, ラベル連番 "
            strSQL &= "FROM T_印刷管理個別 "
            strSQL &= "WHERE ロットID = '" & strLotID & "' "
            strSQL &= "ORDER BY ラベル連番"

            Dim dtPrintManage As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
            Dim strHeaderSheet As String = ""   '前回ヘッダシート格納用
            Dim strImportDate As String = strLotID.Substring(0, 8)  'ロットIDの先頭8桁(インポート日)を取得する

            For iRow As Integer = 0 To dtPrintManage.Rows.Count - 1
                '会社コード、所属事業所コード、重量ヘッダ単位で回す
                '==================================================
                '重量ヘッダシート印刷
                '==================================================
                '1レコードでも存在したら重量ヘッダシート出力判断
                If Not dtPrintManage.Rows(iRow)("重量ヘッダ") = strHeaderSheet Then
                    '前回ヘッダと相違していたらヘッダシートを印刷する
                    strSQL = "SELECT '" & strImportDate & "' AS インポート日, T3.重量ヘッダ, T3.対象者一覧, T3.保健指導名簿, T3.判定票枚数, T3.判定票件数, "
                    strSQL &= "T3.リーフレット枚数, T3.リーフレット件数, T3.総枚数 + 1 AS 総枚数, T3.リーフレット枚数 AS 枚数, "
                    strSQL &= "T3.リーフレット件数 AS 件数, "
					strSQL &= "(SELECT COUNT(重量ヘッダ) FROM T_印刷管理個別 "
					strSQL &= "WHERE ロットID = '" & strLotID & "' "
                    'リーフレットの存在する通数のみ合算
                    strSQL &= "AND 重量ヘッダ = '" & dtPrintManage.Rows(iRow)("重量ヘッダ") & "' AND リーフレット枚数 > 0) AS 通数 "
                    strSQL &= "FROM (SELECT T1.重量ヘッダ, "
                    strSQL &= "0 AS 対象者一覧, "
                    strSQL &= "0 AS 保健指導名簿, "   '判定票の方で出力されるので0
                    'strSQL &= "ISNULL(SUM(CASE WHEN T2.帳票種別ID = 3 THEN 1 ELSE 0 END), 0) AS 保健指導名簿, "
                    strSQL &= "0 AS 判定票枚数, "
                    strSQL &= "0 AS 判定票件数, "
                    strSQL &= "ISNULL(SUM(CASE WHEN T2.帳票種別ID = 5 THEN T2.枚数 ELSE 0 END), 0) AS リーフレット枚数, "
                    strSQL &= "ISNULL(SUM(CASE WHEN T2.帳票種別ID = 5 THEN 1 ELSE 0 END), 0) AS リーフレット件数, "
                    strSQL &= "ISNULL(SUM(CASE WHEN T2.帳票種別ID = 5 THEN T2.枚数 ELSE 0 END), 0) AS 総枚数 "
                    strSQL &= "FROM T_印刷管理個別 AS T1 INNER JOIN "
                    strSQL &= "T_印刷ソート AS T2 ON T1.ロットID = T2.ロットID AND T1.会社コード = T2.会社コード "
                    strSQL &= "AND T1.所属事業所コード = T2.所属事業所コード AND T1.印刷ID = T2.印刷ID "
                    strSQL &= "WHERE T1.ロットID = '" & strLotID & "' "
                    strSQL &= "AND T2.帳票種別ID != 0 " 'ラベル以外
                    strSQL &= "AND T2.帳票種別ID != 2 " '対象者一覧を除外
                    strSQL &= "AND T2.帳票種別ID != 4 " '判定票を除外
                    '2017/08/09
                    '一社員6枚組のリーフレットを除外する
                    strSQL &= "AND T2.枚数 BETWEEN 1 AND 5 "
                    strSQL &= "AND T1.重量ヘッダ = '" & dtPrintManage.Rows(iRow)("重量ヘッダ") & "' "
                    strSQL &= "GROUP BY T1.重量ヘッダ) AS T3"

                    dt = sqlProcess.DB_SELECT_DATATABLE(strSQL)
                    If dt.Rows.Count > 0 Then
                        '結果があった場合印刷
                        Print(strSQL, PrintCategory.WeightHeader)

                    End If

                End If

                '==================================================
                'リーフレット印刷
                '==================================================
                strSQL = "SELECT T1.ロットID, T1.レコード番号 "
                strSQL &= "FROM T_リーフレット印刷 AS T1 INNER JOIN "
                strSQL &= "T_印刷ソート AS T2 ON T1.ロットID = T2.ロットID AND T1.レコード番号 = T2.レコード番号 INNER JOIN "
                strSQL &= "T_判定票管理 AS T3 ON T1.ロットID = T3.ロットID AND T1.レコード番号 = T3.レコード番号 "
                strSQL &= "WHERE T1.ロットID = '" & strLotID & "' "
                strSQL &= "AND T2.会社コード = '" & dtPrintManage.Rows(iRow)("会社コード") & "' "
                strSQL &= "AND T2.所属事業所コード = '" & dtPrintManage.Rows(iRow)("所属事業所コード") & "' "
                strSQL &= "AND T2.印刷ID = " & dtPrintManage.Rows(iRow)("印刷ID") & " "
                strSQL &= "AND T3.リーフレット無効 = 0 "    'リーフレット無効が立っているものは印刷対象としない
                '2017/08/09
                '一社員6枚組のリーフレットを除外する
                strSQL &= "AND T2.枚数 BETWEEN 1 AND 5 "
                strSQL &= "GROUP BY T1.ロットID, T1.レコード番号, T3.所属部名, T3.所属課名, T3.社員コード "
                strSQL &= "ORDER BY CASE WHEN ISNULL(T3.所属部名, '') = '' THEN 1 ELSE 0 END, "
                strSQL &= "T3.所属部名, "
                strSQL &= "CASE WHEN ISNULL(T3.所属課名, '') = '' THEN 1 ELSE 0 END, "
                strSQL &= "T3.所属課名, T3.社員コード"
                Dim dtLeaflet As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
                'DATATABLEを回して帳票タイプ単位で印刷する
                For i As Integer = 0 To dtLeaflet.Rows.Count - 1
                    strSQL = "SELECT T1.帳票タイプ FROM T_リーフレット印刷 AS T1 INNER JOIN "
                    strSQL &= "M_帳票タイプ AS T2 ON T1.帳票タイプ = T2.帳票タイプ "
                    strSQL &= "WHERE T1.ロットID = '" & strLotID & "' "
                    strSQL &= "AND T1.レコード番号 = " & dtLeaflet.Rows(i)("レコード番号")
                    Dim dtFormType As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)

                    '対象ロット番号、レコード番号のリーフレットが取得される。帳票タイプごとに複数レコードあり
                    For iFormType As Integer = 0 To dtFormType.Rows.Count - 1
						'特定した帳票タイプを1つずつSQL文にしてプリントする
						'帳票タイプごとに回す
						'2018/06/11
						'[T_リーフレット.受診日]を追加
						strSQL = "SELECT T1.ロットID, T1.レコード番号, T1.システムID, T1.会社, T1.所属事業所, T1.所属部課名, "
						strSQL &= "T1.氏名, T1.局所会社名, T1.健康管理施設名, T1.郵便番号, T1.住所, T1.電話番号, T1.年度, "
						'2018/06/11
						'受診日を[yyyy/M/d]に変換する
						strSQL &= "FORMAT(CONVERT(DATE, T4.受診日), 'yyyy年M月d日') AS 受診日, "
						strSQL &= "T1.帳票タイプ, T1.結果値1, T1.結果値2, T1.結果値3, T1.BOC, T1.EOC, T1.PAR, "
                        strSQL &= "T1.WAS1, T1.WAS2, T1.WAS3, T1.WAS4, T1.WAS5, T1.WAS6, T1.QRコード, T3.ラベル連番, T1.先頭マーク, "
                        strSQL &= "CONVERT(VARCHAR, T1.トータルSEQ) + '-' + CONVERT(VARCHAR, T1.カレントSEQ) AS ページ "
                        strSQL &= "FROM T_リーフレット印刷 AS T1 INNER JOIN "
                        strSQL &= "T_印刷ソート AS T2 ON T1.ロットID = T2.ロットID "
                        strSQL &= "AND T1.レコード番号 = T2.レコード番号 INNER JOIN "
                        strSQL &= "T_印刷管理個別 AS T3 ON T2.ロットID = T3.ロットID "
                        strSQL &= "AND T2.会社コード = T3.会社コード "
                        strSQL &= "AND T2.所属事業所コード = T3.所属事業所コード "
						strSQL &= "AND T2.印刷ID = T3.印刷ID INNER JOIN "
						'==================================================
						'2018/06/11
						strSQL &= "T_リーフレット AS T4 ON T1.ロットID = T4.ロットID "
						strSQL &= "AND T1.レコード番号 = T4.レコード番号 "
						'==================================================
						strSQL &= "WHERE T1.ロットID = '" & strLotID & "' "
						strSQL &= "AND T1.レコード番号 = " & dtLeaflet.Rows(i)("レコード番号") & " "
                        strSQL &= "AND T2.印刷ID = " & dtPrintManage.Rows(iRow)("印刷ID") & " "
                        strSQL &= "AND T1.帳票タイプ = '" & dtFormType.Rows(iFormType)("帳票タイプ") & "' "
                        strSQL &= "GROUP BY T1.ロットID, T1.レコード番号, T1.システムID, T1.会社, T1.所属事業所, T1.所属部課名, T1.氏名, "
						strSQL &= "T1.局所会社名, T1.健康管理施設名, T1.郵便番号, T1.住所, T1.電話番号, T1.年度, T4.受診日, T1.帳票タイプ, "
						strSQL &= "T1.結果値1, T1.結果値2, T1.結果値3, T1.BOC, T1.EOC, T1.PAR, T1.WAS1, T1.WAS2, T1.WAS3, "
                        strSQL &= "T1.WAS4, T1.WAS5, T1.WAS6, T1.QRコード, T3.ラベル連番, T1.先頭マーク, T1.トータルSEQ, T1.カレントSEQ "
                        '印刷処理
                        Print(strSQL, PrintCategory.Leaflet, dtFormType.Rows(iFormType)("帳票タイプ"))

                    Next

                Next
                '会社コード、所属事業所コード内の印刷が終了した段階でT_印刷管理の「リーフレット印刷日時」を更新する
                'リーフレット印刷日時書き込み
                WritePrintDate(strLotID, PrintCategory.Leaflet, 0, dtPrintManage.Rows(iRow)("会社コード"), dtPrintManage.Rows(iRow)("所属事業所コード"), dtPrintManage.Rows(iRow)("印刷ID"))
                '該当の会社コード、所属事業所コード、印刷IDすべてのチェックフラグを取り下げる
                strSQL = "UPDATE T_印刷ソート SET チェックフラグ = 0 "
                strSQL &= "WHERE ロットID = '" & strLotID & "' "
                strSQL &= "AND 会社コード = '" & dtPrintManage.Rows(iRow)("会社コード") & "' "
                strSQL &= "AND 所属事業所コード = '" & dtPrintManage.Rows(iRow)("所属事業所コード") & "' "
                strSQL &= "AND 印刷ID = " & dtPrintManage.Rows(iRow)("印刷ID")
                sqlProcess.DB_UPDATE(strSQL)

                strHeaderSheet = dtPrintManage.Rows(iRow)("重量ヘッダ")
                'Application.DoEvents()

            Next

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & ex.StackTrace)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally

            sqlProcess.Close()
            '設定されていた通常使うプリンタに戻す
            SetDefaultPrinter(strDefaultPrinter)

        End Try

    End Sub

    ''' <summary>
    ''' 印刷処理
    ''' </summary>
    ''' <param name="strSQL"></param>
    ''' <param name="prtCategory"></param>
    ''' <param name="strLeafletPattern"></param>
    ''' <param name="strCompanyCode">会社コード</param>
    ''' <param name="strPrintTemplate">印刷テンプレートファイル名</param>
    ''' <remarks>2018/10/02 かんぽ生命対応で会社コードオプションを追加
    '''          2019/04/24 2018年以前と2019年以降でテンプレートを分岐させる処理を追加</remarks>
    Public Sub Print(ByVal strSQL As String, ByVal prtCategory As PrintCategory, Optional ByVal strLeafletPattern As String = "", Optional ByVal strCompanyCode As String = "", Optional ByVal strPrintTemplate As String = "result.flxr")

        ''==================================================
        ''デバッグ用(この囲み以外はコメントアウトする)
        'Using sw As New System.IO.StreamWriter("C:\開発\MSiC\JP健診2017\E\JPTemp\02_Out\20190521\test.txt", True, System.Text.Encoding.GetEncoding("Shift-JIS"))
        '    Select Case prtCategory
        '        Case PrintCategory.Label
        '            sw.WriteLine("ラベル" & vbTab & strSQL)
        '        Case PrintCategory.WeightHeader
        '            sw.WriteLine("重量ヘッダ" & vbTab & strSQL)
        '        Case PrintCategory.WeightHeaderHand
        '            sw.WriteLine("重量ヘッダ手封入" & vbTab & strSQL)
        '        Case PrintCategory.CheckupList
        '            sw.WriteLine("対象者一覧" & vbTab & strSQL)
        '        Case PrintCategory.CheckupListIndividual
        '            sw.WriteLine("対象者一覧（個別）" & vbTab & strSQL)
        '        Case PrintCategory.LeafletList
        '            sw.WriteLine("個人指導対象者名簿" & vbTab & strSQL)
        '        Case PrintCategory.LeafletListIndividual
        '            sw.WriteLine("個人指導対象者名簿（個別" & vbTab & strSQL)
        '        Case PrintCategory.Checkup
        '            sw.WriteLine("判定票" & vbTab & strSQL)
        '        Case PrintCategory.Leaflet
        '            sw.WriteLine("リーフレット" & vbTab & strSQL)
        '    End Select
        'End Using
        ''ここまで
        ''==================================================

        Dim strConnectionString As String = ""
        XmlSettings.LoadFromXmlFile()
        Dim C1FlexReport1 As New C1FlexReport

        '現在の通常使うプリンタ名を取得
        Dim pd As New System.Drawing.Printing.PrintDocument
        'プリンタ名の取得
        'Finallyで通常使うプリンタを戻す
        Dim strDefaultPrinter As String = pd.PrinterSettings.PrinterName

        Try
            '接続文字列を作成する
            strConnectionString = "Provider=SQLOLEDB.1;"
            strConnectionString &= "Password=" & XmlSettings.Instance.Password & ";"
            strConnectionString &= "Persist Security Info=True;"
            strConnectionString &= "User ID=" & XmlSettings.Instance.UserID & ";"
            strConnectionString &= "Initial Catalog=" & XmlSettings.Instance.InitialCatalog & ";"
            strConnectionString &= "Data Source=" & XmlSettings.Instance.DataSource
            '印刷オプションのインスタンス
            Dim print_option As C1.Win.C1Document.C1PrintOptions = New C1.Win.C1Document.C1PrintOptions()
            print_option.PrinterSettings = New System.Drawing.Printing.PrinterSettings()

            '==================================================
            ''新コード
            ''プリンタドライバの切り替え
            'SetDefaultPrinter(XmlSettings.Instance.Printer_Result)
            '==================================================

            Select Case prtCategory

                Case PrintCategory.Label
                    'ラベル印刷
                    C1FlexReport1.Load(Application.StartupPath & "\Template\others.flxr", "ラベル")
                    '接続文字列、SQL文の設定
                    C1FlexReport1.DataSource.ConnectionString = strConnectionString
                    C1FlexReport1.DataSource.RecordSource = strSQL
                    C1FlexReport1.Render()

                    'プリンタドライバの切り替え
                    '現在のプリンタドライバ名と同一の場合は切り替え処理を行わない
                    If strDefaultPrinter <> XmlSettings.Instance.Printer_Label Then
                        SetDefaultPrinter(XmlSettings.Instance.Printer_Label)
                    End If
                    '印刷方向を縦向きにする
                    print_option.PrinterSettings.DefaultPageSettings.Landscape = False  '縦向き
                    '給紙トレイを変更する
                    'トレイのインデックスが0以上の場合のみトレイ変更する
                    If XmlSettings.Instance.LabelTray >= 0 Then
                        print_option.PrinterSettings.DefaultPageSettings.PaperSource = print_option.PrinterSettings.PaperSources.Item(XmlSettings.Instance.LabelTray)    'トレイ1※対象者一覧のトレイと同一
                    End If

                    isPrinting = True   '印刷中フラグを設定
                    C1FlexReport1.Print(print_option)   '印刷処理

                Case PrintCategory.WeightHeader
                    '重量ヘッダ
                    C1FlexReport1.Load(Application.StartupPath & "\Template\others.flxr", "重量ヘッダ")
                    '接続文字列、SQL文の設定
                    C1FlexReport1.DataSource.ConnectionString = strConnectionString
                    C1FlexReport1.DataSource.RecordSource = strSQL
                    C1FlexReport1.Render()

                    ''==================================================
                    ''従来のコード
                    ''プリンタドライバの切り替え
                    'SetDefaultPrinter(XmlSettings.Instance.Printer_Sentlist)
                    ''印刷方向を縦向きにする
                    'print_option.PrinterSettings.DefaultPageSettings.Landscape = False  '縦向き
                    '==================================================
                    'プリンタドライバの切り替え
                    '現在のプリンタドライバ名と同一の場合は切り替え処理を行わない
                    If strDefaultPrinter <> XmlSettings.Instance.Printer_Header Then
                        SetDefaultPrinter(XmlSettings.Instance.Printer_Header)
                    End If
                    '新コード
                    '給紙トレイを変更する
                    print_option.PrinterSettings.DefaultPageSettings.Landscape = False  '縦向き
                    'トレイのインデックスが0以上の場合のみトレイ変更する
                    If XmlSettings.Instance.HeaderTray >= 0 Then
                        print_option.PrinterSettings.DefaultPageSettings.PaperSource = print_option.PrinterSettings.PaperSources.Item(XmlSettings.Instance.HeaderTray)    'トレイ1※対象者一覧のトレイと同一
                    End If
                    '2019/05/22
                    'モノクロ設定
                    print_option.PrinterSettings.DefaultPageSettings.Color = False

                    '==================================================

                    isPrinting = True   '印刷中フラグを設定
                    C1FlexReport1.Print(print_option)   '印刷処理

                Case PrintCategory.WeightHeaderHand
                    '重量ヘッダ(手封入)
                    C1FlexReport1.Load(Application.StartupPath & "\Template\others.flxr", "重量ヘッダHAND")
                    '接続文字列、SQL文の設定
                    C1FlexReport1.DataSource.ConnectionString = strConnectionString
                    C1FlexReport1.DataSource.RecordSource = strSQL
                    C1FlexReport1.Render()

                    ''==================================================
                    ''従来のコード
                    ''プリンタドライバの切り替え
                    'SetDefaultPrinter(XmlSettings.Instance.Printer_Sentlist)
                    ''印刷方向を縦向きにする
                    'print_option.PrinterSettings.DefaultPageSettings.Landscape = False  '縦向き
                    '==================================================
                    'プリンタドライバの切り替え
                    '現在のプリンタドライバ名と同一の場合は切り替え処理を行わない
                    If strDefaultPrinter <> XmlSettings.Instance.Printer_Header Then
                        SetDefaultPrinter(XmlSettings.Instance.Printer_Header)
                    End If
                    '新コード
                    '給紙トレイを変更する
                    print_option.PrinterSettings.DefaultPageSettings.Landscape = False  '縦向き
                    'トレイのインデックスが0以上の場合のみトレイ変更する
                    If XmlSettings.Instance.HeaderTray >= 0 Then
                        print_option.PrinterSettings.DefaultPageSettings.PaperSource = print_option.PrinterSettings.PaperSources.Item(XmlSettings.Instance.HeaderTray)    'トレイ1※対象者一覧のトレイと同一
                    End If
                    '2019/05/22
                    'モノクロ設定
                    print_option.PrinterSettings.DefaultPageSettings.Color = False

                    '==================================================

                    isPrinting = True   '印刷中フラグを設定
                    C1FlexReport1.Print(print_option)   '印刷処理

                Case PrintCategory.CheckupList
                    '対象者一覧
                    C1FlexReport1.Load(Application.StartupPath & "\Template\result.flxr", "対象者一覧")
                    '接続文字列、SQL文の設定
                    C1FlexReport1.DataSource.ConnectionString = strConnectionString
                    C1FlexReport1.DataSource.RecordSource = strSQL
                    C1FlexReport1.Render()

                    ''==================================================
                    ''従来のコード
                    ''プリンタドライバの切り替え
                    'SetDefaultPrinter(XmlSettings.Instance.Printer_Sentlist)
                    ''印刷方向を縦向きにする
                    'print_option.PrinterSettings.DefaultPageSettings.Landscape = False  '縦向き
                    '==================================================
                    'プリンタドライバの切り替え
                    '現在のプリンタドライバ名と同一の場合は切り替え処理を行わない
                    If strDefaultPrinter <> XmlSettings.Instance.Printer_Sentlist Then
                        SetDefaultPrinter(XmlSettings.Instance.Printer_Sentlist)
                    End If
                    '新コード
                    '給紙トレイを変更する
                    print_option.PrinterSettings.DefaultPageSettings.Landscape = False  '縦向き
                    'トレイのインデックスが0以上の場合のみトレイ変更する
                    If XmlSettings.Instance.ResultTray >= 0 Then
                        print_option.PrinterSettings.DefaultPageSettings.PaperSource = print_option.PrinterSettings.PaperSources.Item(XmlSettings.Instance.SentlistTray)    'トレイ1
                    End If
                    '2019/05/22
                    'モノクロ設定
                    print_option.PrinterSettings.DefaultPageSettings.Color = False

                    '==================================================

                    isPrinting = True   '印刷中フラグを設定
                    C1FlexReport1.Print(print_option)   '印刷処理

                Case PrintCategory.CheckupListIndividual
                    '対象者一覧個別
                    C1FlexReport1.Load(Application.StartupPath & "\Template\result.flxr", "対象者一覧_個別")
                    '接続文字列、SQL文の設定
                    C1FlexReport1.DataSource.ConnectionString = strConnectionString
                    C1FlexReport1.DataSource.RecordSource = strSQL
                    C1FlexReport1.Render()

                    ''==================================================
                    ''従来のコード
                    ''プリンタドライバの切り替え
                    'SetDefaultPrinter(XmlSettings.Instance.Printer_Sentlist)
                    ''印刷方向を縦向きにする
                    'print_option.PrinterSettings.DefaultPageSettings.Landscape = False  '縦向き
                    '==================================================
                    'プリンタドライバの切り替え
                    '現在のプリンタドライバ名と同一の場合は切り替え処理を行わない
                    If strDefaultPrinter <> XmlSettings.Instance.Printer_Sentlist Then
                        SetDefaultPrinter(XmlSettings.Instance.Printer_Sentlist)
                    End If
                    '新コード
                    '給紙トレイを変更する
                    print_option.PrinterSettings.DefaultPageSettings.Landscape = False  '縦向き
                    'トレイのインデックスが0以上の場合のみトレイ変更する
                    If XmlSettings.Instance.ResultTray >= 0 Then
                        print_option.PrinterSettings.DefaultPageSettings.PaperSource = print_option.PrinterSettings.PaperSources.Item(XmlSettings.Instance.SentlistTray)    'トレイ1
                    End If
                    '2019/05/22
                    'モノクロ設定
                    print_option.PrinterSettings.DefaultPageSettings.Color = False

                    '==================================================

                    isPrinting = True   '印刷中フラグを設定
                    C1FlexReport1.Print(print_option)   '印刷処理

                Case PrintCategory.LeafletList
                    '保健指導対象者名簿
                    '2018/10/02
                    'かんぽ生命かどうかの判断
                    If strCompanyCode = XmlSettings.Instance.KanpoCode Then
                        C1FlexReport1.Load(Application.StartupPath & "\Template\result.flxr", "保健指導名簿_かんぽ")
                    Else
                        C1FlexReport1.Load(Application.StartupPath & "\Template\result.flxr", "保健指導名簿")
                    End If
                    '接続文字列、SQL文の設定
                    C1FlexReport1.DataSource.ConnectionString = strConnectionString
                    C1FlexReport1.DataSource.RecordSource = strSQL
                    C1FlexReport1.Render()

                    '==================================================
                    ''従来のコード
                    ''プリンタドライバの切り替え
                    'SetDefaultPrinter(XmlSettings.Instance.Printer_Sentlist)
                    ''印刷方向を縦向きにする
                    'print_option.PrinterSettings.DefaultPageSettings.Landscape = True  '横向き
                    '==================================================
                    'プリンタドライバの切り替え
                    '現在のプリンタドライバ名と同一の場合は切り替え処理を行わない
                    If strDefaultPrinter <> XmlSettings.Instance.Printer_SentLeaflet Then
                        SetDefaultPrinter(XmlSettings.Instance.Printer_SentLeaflet)
                    End If
                    '新コード
                    '給紙トレイを変更する
                    print_option.PrinterSettings.DefaultPageSettings.Landscape = True  '横向き
                    'トレイのインデックスが0以上の場合のみトレイ変更する
                    If XmlSettings.Instance.SentLeafletTray >= 0 Then
                        print_option.PrinterSettings.DefaultPageSettings.PaperSource = print_option.PrinterSettings.PaperSources.Item(XmlSettings.Instance.SentLeafletTray)    'トレイ1
                    End If
                    '2019/05/22
                    'モノクロ設定
                    print_option.PrinterSettings.DefaultPageSettings.Color = False

                    '==================================================

                    isPrinting = True   '印刷中フラグを設定
                    C1FlexReport1.Print(print_option)   '印刷処理

                Case PrintCategory.LeafletListIndividual
                    '保健指導対象者名簿個別
                    '2018/10/02
                    'かんぽ生命かどうかの判断
                    If strCompanyCode = XmlSettings.Instance.KanpoCode Then
                        C1FlexReport1.Load(Application.StartupPath & "\Template\result.flxr", "保健指導名簿_かんぽ_個別")
                    Else
                        C1FlexReport1.Load(Application.StartupPath & "\Template\result.flxr", "保健指導名簿_個別")
                    End If
                    '接続文字列、SQL文の設定
                    C1FlexReport1.DataSource.ConnectionString = strConnectionString
                    C1FlexReport1.DataSource.RecordSource = strSQL
                    C1FlexReport1.Render()

                    '==================================================
                    ''従来のコード
                    ''プリンタドライバの切り替え
                    'SetDefaultPrinter(XmlSettings.Instance.Printer_Sentlist)
                    ''印刷方向を縦向きにする
                    'print_option.PrinterSettings.DefaultPageSettings.Landscape = True  '横向き
                    '==================================================
                    'プリンタドライバの切り替え
                    '現在のプリンタドライバ名と同一の場合は切り替え処理を行わない
                    If strDefaultPrinter <> XmlSettings.Instance.Printer_SentLeaflet Then
                        SetDefaultPrinter(XmlSettings.Instance.Printer_SentLeaflet)
                    End If
                    '新コード
                    '給紙トレイを変更する
                    print_option.PrinterSettings.DefaultPageSettings.Landscape = True  '横向き
                    'トレイのインデックスが0以上の場合のみトレイ変更する
                    If XmlSettings.Instance.SentLeafletTray >= 0 Then
                        print_option.PrinterSettings.DefaultPageSettings.PaperSource = print_option.PrinterSettings.PaperSources.Item(XmlSettings.Instance.SentLeafletTray)    'トレイ1
                    End If
                    '2019/05/22
                    'モノクロ設定
                    print_option.PrinterSettings.DefaultPageSettings.Color = False

                    '==================================================

                    isPrinting = True   '印刷中フラグを設定
                    C1FlexReport1.Print(print_option)   '印刷処理

                Case PrintCategory.Checkup
                    '判定票
                    '2019/04/24
                    'テンプレートファイルの分岐を追加
                    C1FlexReport1.Load(Application.StartupPath & "\Template\" & strPrintTemplate, "判定票")
                    '接続文字列、SQL文の設定
                    C1FlexReport1.DataSource.ConnectionString = strConnectionString
                    C1FlexReport1.DataSource.RecordSource = strSQL
                    C1FlexReport1.Render()

                    ''==================================================
                    ''従来のコード
                    ''プリンタドライバの切り替え
                    'SetDefaultPrinter(XmlSettings.Instance.Printer_Result)
                    ''印刷方向を縦向きにする
                    'print_option.PrinterSettings.DefaultPageSettings.Landscape = True  '横向き
                    '==================================================
                    'プリンタドライバの切り替え
                    '現在のプリンタドライバ名と同一の場合は切り替え処理を行わない
                    If strDefaultPrinter <> XmlSettings.Instance.Printer_Result Then
                        SetDefaultPrinter(XmlSettings.Instance.Printer_Result)
                    End If
                    '新コード
                    '給紙トレイを変更する
                    print_option.PrinterSettings.DefaultPageSettings.Landscape = True  '横向き
                    'トレイのインデックスが0以上の場合のみトレイ変更する
                    If XmlSettings.Instance.ResultTray >= 0 Then
                        print_option.PrinterSettings.DefaultPageSettings.PaperSource = print_option.PrinterSettings.PaperSources.Item(XmlSettings.Instance.ResultTray)    '給紙台
                    End If
                    '2019/05/22
                    'カラー設定
                    print_option.PrinterSettings.DefaultPageSettings.Color = True
                    '==================================================

                    isPrinting = True   '印刷中フラグを設定
                    C1FlexReport1.Print(print_option)   '印刷処理

                Case PrintCategory.Leaflet
                    'リーフレット
                    'テンプレートの決定
                    Dim strReportCategory As String = "R_" & strLeafletPattern
                    C1FlexReport1.Load(Application.StartupPath & "\Template\leaflet.flxr", strReportCategory)
                    '接続文字列、SQL文の設定
                    C1FlexReport1.DataSource.ConnectionString = strConnectionString
                    C1FlexReport1.DataSource.RecordSource = strSQL
                    C1FlexReport1.Render()

                    '==================================================
                    ''従来のコード
                    ''プリンタドライバの切り替え
                    'SetDefaultPrinter(XmlSettings.Instance.Printer_Sentlist)
                    ''印刷方向を縦向きにする
                    'print_option.PrinterSettings.DefaultPageSettings.Landscape = True  '横向き
                    '==================================================
                    'プリンタドライバの切り替え
                    '現在のプリンタドライバ名と同一の場合は切り替え処理を行わない
                    If strDefaultPrinter <> XmlSettings.Instance.Printer_Leaflet Then
                        SetDefaultPrinter(XmlSettings.Instance.Printer_Leaflet)
                    End If
                    '新コード
                    '給紙トレイを変更する
                    print_option.PrinterSettings.DefaultPageSettings.Landscape = True  '横向き
                    'トレイのインデックスが0以上の場合のみトレイ変更する
                    If XmlSettings.Instance.LeafletTray >= 0 Then
                        print_option.PrinterSettings.DefaultPageSettings.PaperSource = print_option.PrinterSettings.PaperSources.Item(XmlSettings.Instance.LeafletTray)    '給紙台
                    End If
                    '2019/05/22
                    'カラー設定
                    print_option.PrinterSettings.DefaultPageSettings.Color = True

                    '==================================================

                    isPrinting = True   '印刷中フラグを設定
                    C1FlexReport1.Print(print_option)   '印刷処理

            End Select

        Catch ex As Exception

            Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & ex.StackTrace)
            MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally

            C1FlexReport1.Clear()
            ''設定されていた通常使うプリンタに戻す
            'SetDefaultPrinter(strDefaultPrinter)

        End Try

    End Sub

    ''' <summary>
    ''' 通常使うプリンタに設定する
    ''' </summary>
    ''' <param name="printerName"></param>
    Private Sub SetDefaultPrinter(ByVal printerName As String)
        'WshNetworkオブジェクトを作成する
        Dim t As Type = Type.GetTypeFromProgID("WScript.Network")
        Dim wshNetwork As Object = Activator.CreateInstance(t)
        'SetDefaultPrinterメソッドを呼び出す
        t.InvokeMember("SetDefaultPrinter",
            System.Reflection.BindingFlags.InvokeMethod,
            Nothing, wshNetwork, New Object() {printerName})

    End Sub

    ''' <summary>
    ''' FlexReport長時間動作時
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub C1FlexReport1_LongOperation(sender As Object, e As C1.Win.LongOperationEventArgs)

        If isPrinting Then
            If Not e.CanCancel And e.Complete = 1 Then
                '印刷終了時の処理
                MessageBox.Show("印刷が完了しました", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information)
                isPrinting = False
            End If
        End If

    End Sub

    ''' <summary>
    ''' 該当レポートをPDFに保存する
    ''' </summary>
    ''' <param name="strLotID"></param>
    Private Sub SavePDF(ByVal C1FlexReport1 As C1.Win.FlexReport.C1FlexReport, ByVal strLotID As String, ByVal strReportName As String, ByVal prtCategory As PrintCategory)

        Dim filter As New C1.Win.C1Document.Export.PdfFilter
        filter.ShowOptions = False
        Dim strFileName As String = ""
        Dim strPDFPath As String = My.Forms.frmPrint.txtPDFPath.Text & "\" & strLotID
        If Not System.IO.Directory.Exists(strPDFPath) Then
            My.Computer.FileSystem.CreateDirectory(strPDFPath)
        End If

        Select Case prtCategory
            Case PrintCategory.Label
                For i As Integer = 1 To 9999
                    strFileName = My.Forms.frmPrint.txtPDFPath.Text & "\" & strLotID & "_ラベル_" & i.ToString("0000") & ".pdf"
                    If Not System.IO.File.Exists(strFileName) Then
                        Exit For
                    End If
                Next
                'エクスポートするファイル名と保存先を指定する
                filter.FileName = strReportName + strFileName
                'エクスポートする
                C1FlexReport1.RenderToFilter(filter)

            Case PrintCategory.WeightHeader
                For i As Integer = 1 To 9999
                    strFileName = My.Forms.frmPrint.txtPDFPath.Text & "\" & strLotID & "_重量ヘッダ_" & i.ToString("0000") & ".pdf"
                    If Not System.IO.File.Exists(strFileName) Then
                        Exit For
                    End If
                Next
                'エクスポートするファイル名と保存先を指定する
                filter.FileName = strReportName + strFileName
                'エクスポートする
                C1FlexReport1.RenderToFilter(filter)

            Case PrintCategory.CheckupList
                For i As Integer = 1 To 9999
                    strFileName = My.Forms.frmPrint.txtPDFPath.Text & "\" & strLotID & "_対象者一覧_" & i.ToString("0000") & ".pdf"
                    If Not System.IO.File.Exists(strFileName) Then
                        Exit For
                    End If
                Next
                'エクスポートするファイル名と保存先を指定する
                filter.FileName = strReportName + strFileName
                'エクスポートする
                C1FlexReport1.RenderToFilter(filter)

            Case PrintCategory.LeafletList
                For i As Integer = 1 To 9999
                    strFileName = My.Forms.frmPrint.txtPDFPath.Text & "\" & strLotID & "_保健指導名簿_" & i.ToString("0000") & ".pdf"
                    If Not System.IO.File.Exists(strFileName) Then
                        Exit For
                    End If
                Next
                'エクスポートするファイル名と保存先を指定する
                filter.FileName = strReportName + strFileName
                'エクスポートする
                C1FlexReport1.RenderToFilter(filter)

            Case PrintCategory.Checkup
                For i As Integer = 1 To 9999
                    strFileName = My.Forms.frmPrint.txtPDFPath.Text & "\" & strLotID & "_判定票_" & i.ToString("0000") & ".pdf"
                    If Not System.IO.File.Exists(strFileName) Then
                        Exit For
                    End If
                Next
                'エクスポートするファイル名と保存先を指定する
                filter.FileName = strReportName + strFileName
                'エクスポートする
                C1FlexReport1.RenderToFilter(filter)

            Case PrintCategory.Leaflet
                For i As Integer = 1 To 9999
                    strFileName = My.Forms.frmPrint.txtPDFPath.Text & "\" & strLotID & "_リーフレット_" & i.ToString("0000") & ".pdf"
                    If Not System.IO.File.Exists(strFileName) Then
                        Exit For
                    End If
                Next
                'エクスポートするファイル名と保存先を指定する
                filter.FileName = strReportName + strFileName
                'エクスポートする
                C1FlexReport1.RenderToFilter(filter)

        End Select

    End Sub

    ''' <summary>
    ''' 判定票印刷日時、リーフレット印刷日時更新処理
    ''' </summary>
    ''' <param name="strLotID"></param>
    ''' <param name="prtCategory"></param>
    ''' <param name="iRecordNumber"></param>
    ''' <param name="strCompanyCode"></param>
    ''' <param name="strOfficeCode"></param>
    ''' <param name="iPrintID"></param>
    Private Sub WritePrintDate(ByVal strLotID As String, ByVal prtCategory As PrintCategory, Optional ByVal iRecordNumber As Integer = 0, Optional ByVal strCompanyCode As String = "", Optional ByVal strOfficeCode As String = "", Optional ByVal iPrintID As Integer = 1)

        Dim sqlProcess As New SQLProcess
        Dim strSQL As String = ""

        Try
            Dim strPrintDate As String = Date.Now.ToString("yyyy/MM/dd HH:mm:ss")
            '==================================================
            '判定票管理
            strSQL = "UPDATE T_判定票管理 SET "
            Select Case prtCategory
                Case PrintCategory.Checkup
                    strSQL &= "判定票印刷日時 = '" & strPrintDate & "' "
                Case PrintCategory.Leaflet
                    strSQL &= "リーフレット印刷日時 = '" & strPrintDate & "' "
            End Select
            strSQL &= "WHERE ロットID = '" & strLotID & "' "

            If iRecordNumber <> 0 Then
                '個別印刷時
                strSQL &= "AND レコード番号 = " & iRecordNumber
            Else
                '全印刷時
                strSQL &= "AND 会社コード = '" & strCompanyCode & "' "
                strSQL &= "AND 所属事業所コード = '" & strOfficeCode & "' "
            End If
            sqlProcess.DB_UPDATE(strSQL)
            '==================================================
            '印刷管理
            strSQL = "UPDATE T_印刷管理 SET "
            Select Case prtCategory
                Case PrintCategory.Checkup
                    strSQL &= "判定票印刷日時 = '" & strPrintDate & "' "
                Case PrintCategory.Leaflet
                    strSQL &= "リーフレット印刷日時 = '" & strPrintDate & "' "
            End Select
            strSQL &= "WHERE ロットID = '" & strLotID & "' "
            '2017/08/09
            'T_印刷管理は事業所単位なのでレコード番号では更新できない
            '必ず会社コード等で更新する
            '全印刷時
            strSQL &= "AND 会社コード = '" & strCompanyCode & "' "
            strSQL &= "AND 所属事業所コード = '" & strOfficeCode & "' "
            strSQL &= "AND 印刷ID = " & iPrintID
            'If iRecordNumber <> 0 Then
            '	'個別印刷時
            '	strSQL &= "AND レコード番号 = " & iRecordNumber
            'Else
            '	'全印刷時
            '	strSQL &= "AND 会社コード = '" & strCompanyCode & "' "
            '	strSQL &= "AND 所属事業所コード = '" & strOfficeCode & "' "
            '	strSQL &= "AND 印刷ID = " & iPrintID
            'End If
            sqlProcess.DB_UPDATE(strSQL)

        Catch ex As Exception

            Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & ex.StackTrace)
            MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		Finally

			sqlProcess.Close()

		End Try

	End Sub

	''' <summary>
	''' 指定したドキュメントの印刷が開始されるまで待機する
	''' </summary>
	''' <param name="printerName">印刷を行うプリンタ名</param>
	''' <param name="timeOut">タイムアウト(ms)0を指定すると無制限に待機する</param>
	''' <param name="fileName">印刷の開始を待機するドキュメント名を指定する</param>
	''' <param name="extention">印刷の開始を待機するドキュメントの拡張子を指定する。大文字小文字は区別されない</param>
	''' <param name="includes">印刷の開始を待機するドキュメント名に含まれる文字列を指定する。アルファベットが含まれる場合、大文字小文字は区別される</param>
	''' <remarks>ジョブ名とfileNameが完全に一致するか、ジョブ名にincludesで指定した文字列がすべて含まれているジョブの印刷開始を待機する</remarks>
	Private Sub WaitForPrint(ByVal printerName As String, ByVal timeOut As Long, ByVal fileName As String, ByVal extention As String, ByVal ParamArray includes() As String)

		Dim logid As Integer = Now.Millisecond

		Dim includesString As String = String.Empty
		For Each include As String In includes
			If (includesString.Length > 0) Then includesString += ", "
			includesString += include
		Next
		Dim arguments As String = String.Empty
		arguments += String.Format("printername : {0}", printerName) & vbCrLf
		arguments += String.Format("timeOut : {0}", timeOut) & vbCrLf
		arguments += String.Format("fileName : {0}", fileName) & vbCrLf
		arguments += String.Format("extention : {0}", extention) & vbCrLf
		arguments += String.Format("includes : {0}", includes) & vbCrLf

		Try
            'Console.WriteLine("プリンタ : {0} の印刷開始を待機します(タイムアウト : {1} ms)" & vbCrLf & "引数 : {2}", printerName, timeOut, arguments)

            'プリンタのキューを取得し、指定されたジョブが開始されるまで待機
            Using queue As PrintQueue = GetPrintQueue(printerName)
				'タイムアウト計測用タイマ
				Dim st As New Stopwatch()

				'印刷が開始されたことを示すフラグ
				Dim spooling As Boolean = False
				Dim printing As Boolean = False

				'タイムアウトが設定されていればタイマをスタート
				If (timeOut > 0) Then st.Start()

				Dim jobFound As Boolean = False
				Dim targetJob As PrintSystemJobInfo = Nothing

				Do Until (printing = True)
					'CPUリソースを占有しないようにスリープ
					'System.Threading.Thread.Sleep(QUEUE_POLLING_INTERVAL)
					System.Threading.Thread.Sleep(5000)
					Application.DoEvents()

					'タイムアウト判定
					If (st.ElapsedMilliseconds > timeOut) Then
						If (jobFound = True) Then
							Try
								targetJob.Cancel()

							Catch ex As Exception
								'ジョブキャンセル時の例外は無視
							End Try
						End If
						Throw New TimeoutException("操作がタイムアウトしました", New Exception(arguments))
					End If
					'まずはキューからジョブを検索する
					If (jobFound = False) Then
						'キュー内のジョブを列挙
						queue.Refresh()
						Dim jobs As PrintJobInfoCollection = queue.GetPrintJobInfoCollection()

                        'Console.WriteLine("ジョブの列挙を開始する")

                        For Each job As Printing.PrintSystemJobInfo In jobs
							If (job IsNot Nothing AndAlso job.Submitter = Environment.UserName) Then
                                'Console.WriteLine("{0} : {1}", job.Name, job.JobStatus)

                                '拡張しおよびファイル名に含まれる文字列から、監視対象のジョブを特定する
                                If (String.IsNullOrEmpty(extention) = True OrElse job.Name.ToLower.EndsWith(extention.ToLower) = True) Then
									Dim includesFound As Boolean = True
									For Each match As String In includes
										If (job.Name.Contains(match) = False) Then
											includesFound = False
											Exit For
										End If
									Next

									'ジョブ名とfileNameの一致を確認
									Dim fileNameFound As Boolean = job.Name.Trim.Equals(fileName.Trim)

									'ジョブ名とfileNameが完全に一致するか、ジョブ名にincludesで指定した文字列がすべて含まれていればOK
									jobFound = (includesFound Or fileNameFound)

								Else
									jobFound = False
								End If

								If (jobFound = True) Then
									targetJob = job
                                    'Console.WriteLine("印刷対象のジョブ「{0}」が見つかりました。ステータス : {1}", job.Name, job.JobStatus)
                                    Exit For
								End If
							End If
						Next
                        'Console.WriteLine("ジョブの列挙が終了しました")
                    End If

					If (jobFound = True) Then
						targetJob.Refresh()
                        'Console.WriteLine("印刷対象のジョブ「{0}」を監視しています。ステータス : {1}", targetJob.Name, targetJob.JobStatus)

                        If ((targetJob.JobStatus And PrintJobStatus.Retained) = PrintJobStatus.Retained OrElse
								(targetJob.JobStatus And PrintJobStatus.Completed) = PrintJobStatus.Completed OrElse
								(targetJob.JobStatus And PrintJobStatus.Deleted) = PrintJobStatus.Deleted
								) Then
							'印刷が開始された
							printing = True
                            'Console.WriteLine("プリンタ : {0} で {1} の印刷が開始されました。jobStatus : {2}", printerName, targetJob.Name, targetJob.JobStatus)

                        ElseIf ((targetJob.JobStatus And PrintJobStatus.Error) = PrintJobStatus.Error) Then
							Throw New ApplicationException("印刷中にエラーが発生しました")
						ElseIf ((targetJob.JobStatus And PrintJobStatus.Spooling) = PrintJobStatus.Spooling) Then
							spooling = True
						ElseIf (targetJob.JobStatus = PrintJobStatus.None AndAlso spooling = True) Then
							'一度Spooling状態となってからNoneになったジョブは、
							'「スプール済みでプリンタの都合で待たされている」と判断できるため印刷開始とみなす
							printing = True
                            'Console.WriteLine("プリンタ : {0} で {1} の印刷が開始されました。JobStatus : {2}", printerName, targetJob.Name, targetJob.JobStatus)
                        End If

					End If

				Loop

			End Using

		Catch ex As Exception

            'Console.WriteLine(ex)
            Throw

		End Try

	End Sub

	''' <summary>
	''' 指定したプリンタのキューを取得する
	''' </summary>
	''' <param name="printerName">プリンタ名</param>
	''' <returns>指定したプリンタのキューを表す</returns>
	Private Function GetPrintQueue(ByVal printerName As String) As PrintQueue

		Dim server As New LocalPrintServer()
		Return New PrintQueue(server, printerName, 2)

	End Function

End Module