﻿Imports C1.C1Excel
'Imports Excel = Microsoft.Office.Interop.Excel

Module ExcelProcess

	Public Enum ExcelOutputCategory
		DataIncomplete = 1  'データ不備内容
		WeightCount = 2    '重量ヘッダ単位件数
		FacilityCount = 3    '就業判定票_施設別件数
		CheckupTargetList = 4   '就業判定票 対象者一覧
		OfficeList = 5   '発送先事業所一覧
		Succession = 6  '後納票
		WorkOrder = 7   '作業票
	End Enum

	''' <summary>
	''' DATATABLEの内容を指定テンプレートに書き込んで指定エクセルファイルに出力する
	''' </summary>
	''' <param name="enumCategory"></param>
	''' <param name="strSaveFile"></param>
	''' <param name="dt"></param>
	''' <param name="strOutputDate"></param>
	''' <param name="dtCheckup"></param>
	''' <param name="dtLeaflet"></param>
	''' <param name="dt2">後納票出力時に2シート目のDATATABLEを保持する</param>
	''' <param name="dtBMI"></param>
	''' <param name="iFacilityCount"></param>
	''' <param name="iCheckupDefect"></param>
	''' <param name="iLeafDefect"></param>
	''' <param name="iLeafDupe"></param>
	''' <param name="iTargetList"></param>
	''' <returns></returns>
	Public Function WriteExcelFile(ByVal enumCategory As ExcelOutputCategory, ByVal strSaveFile As String, ByVal dt As DataTable, ByVal strOutputDate As String,
								   Optional ByVal dtCheckup As DataTable = Nothing, Optional ByVal dtLeaflet As DataTable = Nothing,
								   Optional ByVal dt2 As DataTable = Nothing, Optional ByVal dtBMI As DataTable = Nothing, Optional ByVal iFacilityCount As Integer = 0,
								   Optional ByVal iCheckupDefect As Integer = 0, Optional ByVal iLeafDefect As Integer = 0, Optional ByVal iLeafDupe As Integer = 0,
								   Optional ByVal iTargetList As Integer = 0) As Boolean

		XmlSettings.LoadFromXmlFile()
		Dim strTemplate As String = ""

		Try

			Dim wb As New C1XLBook  'ワークブックのインスタンス

			'データ不備内容スタイル
			Dim styleDataIncomplete As New XLStyle(wb)
			With styleDataIncomplete
				.Font = New Font("ＭＳ ゴシック", 11, FontStyle.Regular)
				.AlignVert = XLAlignVertEnum.Center
				.BorderTop = XLLineStyleEnum.Thin   '細線
				.BorderRight = XLLineStyleEnum.Thin
				.BorderBottom = XLLineStyleEnum.Thin
				.BorderLeft = XLLineStyleEnum.Thin
			End With
			'対象者一覧用スタイル
			Dim styleCheckupTargetList As New XLStyle(wb)
			With styleCheckupTargetList
				.Font = New Font("Meiryo UI", 10, FontStyle.Regular)
				.AlignVert = XLAlignVertEnum.Center
				.BorderTop = XLLineStyleEnum.Thin   '細線
				.BorderRight = XLLineStyleEnum.Thin
				.BorderBottom = XLLineStyleEnum.Thin
				.BorderLeft = XLLineStyleEnum.Thin
			End With
			'施設別スタイル
			Dim styleFacilityCount As New XLStyle(wb)
			With styleFacilityCount
				.Font = New Font("ＭＳ ゴシック", 11, FontStyle.Regular)
				.AlignVert = XLAlignVertEnum.Center
				.BorderTop = XLLineStyleEnum.Thin   '細線
				.BorderRight = XLLineStyleEnum.Thin
				.BorderBottom = XLLineStyleEnum.Thin
				.BorderLeft = XLLineStyleEnum.Thin
			End With
			'発送先事業所一覧スタイル
			Dim styleOfficeList As New XLStyle(wb)
			With styleOfficeList
				.Font = New Font("Meiryo UI", 10, FontStyle.Regular)
				.AlignVert = XLAlignVertEnum.Center
				.BorderTop = XLLineStyleEnum.Thin   '細線
				.BorderRight = XLLineStyleEnum.Thin
				.BorderBottom = XLLineStyleEnum.Thin
				.BorderLeft = XLLineStyleEnum.Thin
			End With
			'後納票スタイル
			Dim styleSuccesion As New XLStyle(wb)
			With styleSuccesion
				.Font = New Font("ＭＳ Ｐゴシック", 11, FontStyle.Regular)
				.AlignVert = XLAlignVertEnum.Center
				.BorderTop = XLLineStyleEnum.Thin   '細線
				.BorderRight = XLLineStyleEnum.Thin
				.BorderBottom = XLLineStyleEnum.Thin
				.BorderLeft = XLLineStyleEnum.Thin
			End With

			Select Case enumCategory

				Case ExcelOutputCategory.DataIncomplete
					'データ不備内容
					strTemplate = Application.StartupPath & "\Template\" & XmlSettings.Instance.ExcelDataIncomplete
					wb.Load(strTemplate)    'テンプレートエクセルを読み込む
					Dim sheet As XLSheet = wb.Sheets(0) '先頭のシートを指定

					'出力日付の出力
					sheet(2, 19).Value = strOutputDate
					'各レコードの出力
					Dim iRow As Integer = 0
					For iRow = 0 To dt.Rows.Count - 1
						sheet.Rows(iRow + 5).Height = 330
						For iCol As Integer = 0 To 19
							sheet(iRow + 5, iCol).Style = styleDataIncomplete
						Next
						sheet(iRow + 5, 0).Value = dt.Rows(iRow)("連番")
						sheet(iRow + 5, 1).Value = dt.Rows(iRow)("会社コード")
						sheet(iRow + 5, 2).Value = dt.Rows(iRow)("所属事業所コード")
						sheet(iRow + 5, 3).Value = dt.Rows(iRow)("健診種別")
						sheet(iRow + 5, 4).Value = dt.Rows(iRow)("会場局名")
						sheet(iRow + 5, 5).Value = dt.Rows(iRow)("会社")
						sheet(iRow + 5, 6).Value = dt.Rows(iRow)("所属事業所")
						sheet(iRow + 5, 7).Value = dt.Rows(iRow)("社員コード")
						sheet(iRow + 5, 8).Value = dt.Rows(iRow)("性別")
						sheet(iRow + 5, 9).Value = dt.Rows(iRow)("生年月日")
						sheet(iRow + 5, 10).Value = dt.Rows(iRow)("氏名姓")
						sheet(iRow + 5, 11).Value = dt.Rows(iRow)("氏名名")
						sheet(iRow + 5, 12).Value = dt.Rows(iRow)("採用年月日")
						sheet(iRow + 5, 13).Value = dt.Rows(iRow)("受診日")
						sheet(iRow + 5, 14).Value = dt.Rows(iRow)("健康管理施設名")
						sheet(iRow + 5, 15).Value = dt.Rows(iRow)("不備項目")
						sheet(iRow + 5, 16).Value = dt.Rows(iRow)("不備内容")
						sheet(iRow + 5, 17).Value = dt.Rows(iRow)("修正内容")
						sheet(iRow + 5, 18).Value = CDate(dt.Rows(iRow)("インポート日時")).ToString("yyyy/MM/dd HH:mm:ss")
						sheet(iRow + 5, 19).Value = dt.Rows(iRow)("CSVファイル")
					Next

				Case ExcelOutputCategory.WeightCount
					'重量ヘッダ単位件数
					strTemplate = Application.StartupPath & "\Template\" & XmlSettings.Instance.ExcelWeightCount
					wb.Load(strTemplate)    'テンプレートエクセルを読み込む
					Dim sheet As XLSheet = wb.Sheets(0) '先頭のシートを指定
					'各レコードの出力
					Dim iRow As Integer = 0
					For iRow = 0 To dt.Rows.Count - 1
						sheet(iRow + 1, 0).Value = dt.Rows(iRow)("ヘッダ")
						sheet(iRow + 1, 1).Value = dt.Rows(iRow)("ラベル連番")
						sheet(iRow + 1, 2).Value = CInt(dt.Rows(iRow)("ラベル"))
						sheet(iRow + 1, 3).Value = CInt(dt.Rows(iRow)("対象者"))
						sheet(iRow + 1, 4).Value = CInt(dt.Rows(iRow)("保健指導"))
						sheet(iRow + 1, 5).Value = CInt(dt.Rows(iRow)("判定票"))
						sheet(iRow + 1, 6).Value = CInt(dt.Rows(iRow)("リーフ件"))
						sheet(iRow + 1, 7).Value = CInt(dt.Rows(iRow)("リーフ枚"))
						sheet(iRow + 1, 8).Value = CInt(dt.Rows(iRow)("リーフ6件"))
						sheet(iRow + 1, 9).Value = CInt(dt.Rows(iRow)("リーフ重複件"))
						sheet(iRow + 1, 10).Value = CInt(dt.Rows(iRow)("リーフ重複枚"))
						sheet(iRow + 1, 11).Value = CInt(dt.Rows(iRow)("不備"))
						sheet(iRow + 1, 12).Value = CInt(dt.Rows(iRow)("修正"))
					Next

				Case ExcelOutputCategory.FacilityCount
					'就業判定票_施設別件数
					strTemplate = Application.StartupPath & "\Template\" & XmlSettings.Instance.ExcelFacilityCount
					wb.Load(strTemplate)    'テンプレートエクセルを読み込む
					Dim sheet As XLSheet = wb.Sheets(0) '先頭のシートを指定

					'出力日付の出力
					sheet(1, 0).Value = strOutputDate
					'各レコードの出力
					Dim iRow As Integer = 0
					For iRow = 0 To dt.Rows.Count - 1
						sheet.Rows(iRow + 3).Height = 300
						For iCol As Integer = 0 To 4
							sheet(iRow + 3, iCol).Style = styleDataIncomplete
						Next
						sheet(iRow + 3, 0).Value = CInt(dt.Rows(iRow)("連番"))
						sheet(iRow + 3, 1).Value = dt.Rows(iRow)("健康管理施設コード")
						sheet(iRow + 3, 2).Value = dt.Rows(iRow)("健康管理施設名")
						sheet(iRow + 3, 3).Value = dt.Rows(iRow)("略称")
						sheet(iRow + 3, 4).Value = CInt(dt.Rows(iRow)("件数"))
					Next

					''値を取得した行インデックスより後の行を削除する
					'For iRow = iRow + 1 To 10000
					'	sheet.Rows.RemoveAt(iRow + 3)
					'Next

				Case ExcelOutputCategory.CheckupTargetList
					'就業判定票_対象者一覧
					strTemplate = Application.StartupPath & "\Template\" & XmlSettings.Instance.ExcelCheckupTargetList
					wb.Load(strTemplate)    'テンプレートエクセルを読み込む
					Dim sheet As XLSheet = wb.Sheets(0) '先頭のシートを指定
					'sheet.DefaultRowHeight = 600

					'出力日付の出力
					sheet(3, 0).Value = strOutputDate
					'各レコードの出力
					Dim iRow As Integer = 0

					For iRow = 0 To dt.Rows.Count - 1
						For iCol As Integer = 0 To 8
							sheet(iRow + 5, iCol).Style = styleCheckupTargetList
						Next
						sheet.Rows(iRow + 5).Height = 600
						sheet(iRow + 5, 0).Value = CInt(dt.Rows(iRow)("連番"))
						sheet(iRow + 5, 1).Value = dt.Rows(iRow)("社員コード")
						sheet(iRow + 5, 2).Value = dt.Rows(iRow)("氏名")
						sheet(iRow + 5, 3).Value = dt.Rows(iRow)("会社コード")
						sheet(iRow + 5, 4).Value = dt.Rows(iRow)("会社")
						sheet(iRow + 5, 5).Value = dt.Rows(iRow)("局所名")
						sheet(iRow + 5, 6).Value = dt.Rows(iRow)("所属部")
						sheet(iRow + 5, 7).Value = dt.Rows(iRow)("所属課")
						sheet(iRow + 5, 8).Value = dt.Rows(iRow)("リーフレット該当項目")
					Next

					''値を取得した行インデックスより後の行を削除する
					'For iRow2 As Integer = iRow + 1 To 5000
					'	sheet.Rows.RemoveAt(5)
					'Next

					'Console.WriteLine("ダミー")

				Case ExcelOutputCategory.OfficeList
					'発送先事業所一覧
					strTemplate = Application.StartupPath & "\Template\" & XmlSettings.Instance.ExcelOfficeList
					wb.Load(strTemplate)    'テンプレートエクセルを読み込む
					Dim sheet As XLSheet = wb.Sheets(0) '先頭のシートを指定

					'出力日付の出力
					sheet(3, 0).Value = strOutputDate
					'各レコードの出力
					Dim iRow As Integer = 0
					For iRow = 0 To dt.Rows.Count - 1
						For iCol As Integer = 0 To 10
							sheet(iRow + 5, iCol).Style = styleOfficeList
						Next
						sheet.Rows(iRow + 5).Height = 360
						sheet(iRow + 5, 0).Value = CInt(dt.Rows(iRow)("連番"))
						sheet(iRow + 5, 1).Value = dt.Rows(iRow)("会社名")
						sheet(iRow + 5, 2).Value = dt.Rows(iRow)("局所名")
						sheet(iRow + 5, 3).Value = dt.Rows(iRow)("会社コード")
						sheet(iRow + 5, 4).Value = dt.Rows(iRow)("局所コード")
						sheet(iRow + 5, 5).Value = dt.Rows(iRow)("郵便番号")
						sheet(iRow + 5, 6).Value = dt.Rows(iRow)("住所")
						sheet(iRow + 5, 7).Value = CInt(dt.Rows(iRow)("件数"))
						sheet(iRow + 5, 8).Value = CInt(dt.Rows(iRow)("郵便物の個数"))
						sheet(iRow + 5, 9).Value = dt.Rows(iRow)("所属会場局")
						sheet(iRow + 5, 10).Value = dt.Rows(iRow)("担当健康管理施設")
					Next

					''値を取得した行インデックスより後の行を削除する
					'For iRow = iRow + 1 To 20000
					'	sheet.Rows.RemoveAt(iRow + 5)
					'Next

				Case ExcelOutputCategory.Succession
					'後納票
					strTemplate = Application.StartupPath & "\Template\" & XmlSettings.Instance.ExcelSuccession
					wb.Load(strTemplate)    'テンプレートエクセルを読み込む
					Dim sheet As XLSheet = wb.Sheets(0) '後納票シートを指定
					Dim sheet2 As XLSheet = wb.Sheets(1) '後納票差出明細シートを指定
					Dim iRow As Integer = 0

					'後納票シート
					'出力日付の出力
					sheet(0, 5).Value = StrConv(strOutputDate, VbStrConv.Wide)
					'宛先と日付印イメージの読み込み
					Dim strDestImage As String = Application.StartupPath & "\Template\差出人宛先.png"
					Dim strMark As String = Application.StartupPath & "\Template\日付印.png"
					Dim imgDest As Image = Image.FromFile(strDestImage)
					Dim imgMark As Image = Image.FromFile(strMark)
					sheet(4, 1).Value = imgMark
					sheet(4, 4).Value = imgDest

					'各レコードの出力
					For iRow = 0 To dt.Rows.Count - 1
						sheet(iRow + 15, 1).Value = dt.Rows(iRow)("郵便物の種類")
						sheet(iRow + 15, 2).Value = dt.Rows(iRow)("特殊取扱書類")
						sheet(iRow + 15, 3).Value = dt.Rows(iRow)("重量")
						sheet(iRow + 15, 4).Value = CInt(dt.Rows(iRow)("差出通数"))
						sheet(iRow + 15, 5).Value = CInt(dt.Rows(iRow)("一通の料金"))
						sheet(iRow + 15, 6).Value = CInt(dt.Rows(iRow)("合計金額"))
						sheet(iRow + 15, 7).Value = dt.Rows(iRow)("備考")
					Next

					'後納票差出明細シート
					'出力日付の出力
					sheet2(3, 0).Value = strOutputDate

					'各レコードの出力
					For iRow = 0 To dt2.Rows.Count - 1
						sheet2.Rows(iRow + 5).Height = 300
						For iCol As Integer = 0 To 4
							sheet2(iRow + 5, iCol).Style = styleSuccesion
						Next
						sheet2(iRow + 5, 0).Value = dt2.Rows(iRow)("連番")
						sheet2(iRow + 5, 1).Value = dt2.Rows(iRow)("宛先")
						sheet2(iRow + 5, 2).Value = dt2.Rows(iRow)("局所名")
						sheet2(iRow + 5, 3).Value = dt2.Rows(iRow)("料金")
						sheet2(iRow + 5, 4).Value = ""
					Next

					''値を取得した行インデックスより後の行を削除する
					'For iRow = iRow + 1 To 10000
					'	sheet2.Rows.RemoveAt(iRow + 5)
					'Next

				Case ExcelOutputCategory.WorkOrder
					'作業票
					strTemplate = Application.StartupPath & "\Template\" & XmlSettings.Instance.ExcelWorkOrder
					wb.Load(strTemplate)    'テンプレートエクセルを読み込む
					Dim sheet As XLSheet = wb.Sheets("Sheet1")
					'各レコードの出力
					Dim iRow As Integer = 0
					'データがないヘッダも出力するためヘッダの配列で回す
					Dim strHeads As String() = {"A", "B", "C", "D", "E", "F", "G", "H"}
					For iHead As Integer = 0 To strHeads.Length - 1
						Dim strHead As String = strHeads(iHead)
						Dim blnData As Boolean = False  'ヘッダのデータが有ったかどうか
						For iRow = 0 To dt.Rows.Count - 1
							If strHead = dt.Rows(iRow)("ヘッダ") Then
								sheet(iHead + 1, 0).Value = dt.Rows(iRow)("ヘッダ")
								sheet(iHead + 1, 1).Value = dt.Rows(iRow)("ラベル連番")
								sheet(iHead + 1, 2).Value = CInt(dt.Rows(iRow)("ラベル"))
								sheet(iHead + 1, 3).Value = CInt(dt.Rows(iRow)("対象者"))
								sheet(iHead + 1, 4).Value = CInt(dt.Rows(iRow)("保健指導"))
								sheet(iHead + 1, 5).Value = CInt(dt.Rows(iRow)("判定票"))
								sheet(iHead + 1, 10).Value = CInt(dt.Rows(iRow)("リーフ6件"))
								'2018/08/02
								'リーフ6枚の追加
								sheet(iHead + 1, 11).Value = CInt(dt.Rows(iRow)("リーフ6枚"))
								sheet(iHead + 1, 12).Value = CInt(dt.Rows(iRow)("リーフ重複件"))
								sheet(iHead + 1, 13).Value = CInt(dt.Rows(iRow)("リーフ重複枚"))
								'2018/03/30
								'不備、修正済を各DATATABLEから取得する
								'sheet(iHead + 1, 11).Value = CInt(dt.Rows(iRow)("不備"))
								'sheet(iHead + 1, 12).Value = CInt(dt.Rows(iRow)("修正"))
								Dim iFubi As Integer = 0
								Dim iSumi As Integer = 0
								'2018/08/02
								'BMIの件数をセット
								Dim iBMI As Integer = 0
								Select Case dt.Rows(iRow)("ヘッダ")
									Case "A"
										iFubi = CInt(dtCheckup.Rows(0)("A")) + CInt(dtLeaflet.Rows(0)("A"))
										iSumi = CInt(dtCheckup.Rows(0)("A修正済")) + CInt(dtLeaflet.Rows(0)("A修正済"))
										If dtBMI.Rows.Count = 0 Then
											iBMI = 0
										Else
											iBMI = CInt(dtBMI.Rows(0)("ABMI"))
										End If
									Case "B"
										iFubi = CInt(dtCheckup.Rows(0)("B")) + CInt(dtLeaflet.Rows(0)("B"))
										iSumi = CInt(dtCheckup.Rows(0)("B修正済")) + CInt(dtLeaflet.Rows(0)("B修正済"))
										If dtBMI.Rows.Count = 0 Then
											iBMI = 0
										Else
											iBMI = CInt(dtBMI.Rows(0)("BBMI"))
										End If
									Case "C"
										iFubi = CInt(dtCheckup.Rows(0)("C")) + CInt(dtLeaflet.Rows(0)("C"))
										iSumi = CInt(dtCheckup.Rows(0)("C修正済")) + CInt(dtLeaflet.Rows(0)("C修正済"))
										If dtBMI.Rows.Count = 0 Then
											iBMI = 0
										Else
											iBMI = CInt(dtBMI.Rows(0)("CBMI"))
										End If
									Case "D"
										iFubi = CInt(dtCheckup.Rows(0)("D")) + CInt(dtLeaflet.Rows(0)("D"))
										iSumi = CInt(dtCheckup.Rows(0)("D修正済")) + CInt(dtLeaflet.Rows(0)("D修正済"))
										If dtBMI.Rows.Count = 0 Then
											iBMI = 0
										Else
											iBMI = CInt(dtBMI.Rows(0)("DBMI"))
										End If
									Case "E"
										iFubi = CInt(dtCheckup.Rows(0)("E")) + CInt(dtLeaflet.Rows(0)("E"))
										iSumi = CInt(dtCheckup.Rows(0)("E修正済")) + CInt(dtLeaflet.Rows(0)("E修正済"))
										If dtBMI.Rows.Count = 0 Then
											iBMI = 0
										Else
											iBMI = CInt(dtBMI.Rows(0)("EBMI"))
										End If
									Case "F"
										iFubi = CInt(dtCheckup.Rows(0)("F")) + CInt(dtLeaflet.Rows(0)("F"))
										iSumi = CInt(dtCheckup.Rows(0)("F修正済")) + CInt(dtLeaflet.Rows(0)("F修正済"))
										If dtBMI.Rows.Count = 0 Then
											iBMI = 0
										Else
											iBMI = CInt(dtBMI.Rows(0)("FBMI"))
										End If
									Case "G"
										iFubi = CInt(dtCheckup.Rows(0)("G")) + CInt(dtLeaflet.Rows(0)("G"))
										iSumi = CInt(dtCheckup.Rows(0)("G修正済")) + CInt(dtLeaflet.Rows(0)("G修正済"))
										If dtBMI.Rows.Count = 0 Then
											iBMI = 0
										Else
											iBMI = CInt(dtBMI.Rows(0)("GBMI"))
										End If
									Case "H"
										iFubi = CInt(dtCheckup.Rows(0)("H")) + CInt(dtLeaflet.Rows(0)("H"))
										iSumi = CInt(dtCheckup.Rows(0)("H修正済")) + CInt(dtLeaflet.Rows(0)("H修正済"))
										If dtBMI.Rows.Count = 0 Then
											iBMI = 0
										Else
											iBMI = CInt(dtBMI.Rows(0)("HBMI"))
										End If
								End Select
								sheet(iHead + 1, 14).Value = iFubi
								sheet(iHead + 1, 15).Value = iSumi
								'2018/08/02
								'リーフBMI件、リーフBMI枚(件×2)をセット
								sheet(iHead + 1, 8).Value = iBMI
								sheet(iHead + 1, 9).Value = iBMI * 2
								'BMI件数、枚数をリーフ件、枚から減算してセットする
								'2018/08/21
								'減算せずにトータルをセットするように変更
								sheet(iHead + 1, 6).Value = CInt(dt.Rows(iRow)("リーフ件"))
								sheet(iHead + 1, 7).Value = CInt(dt.Rows(iRow)("リーフ枚"))
								blnData = True
								Exit For
							End If
						Next
						If Not blnData Then
							'対象のヘッダがDATATABLE内になかったら空レコードを作成
							sheet(iHead + 1, 0).Value = strHead
							sheet(iHead + 1, 1).Value = ""
							sheet(iHead + 1, 2).Value = ""
							sheet(iHead + 1, 3).Value = ""
							sheet(iHead + 1, 4).Value = ""
							sheet(iHead + 1, 5).Value = ""
							sheet(iHead + 1, 6).Value = ""
							sheet(iHead + 1, 7).Value = ""
							sheet(iHead + 1, 8).Value = ""
							sheet(iHead + 1, 9).Value = ""
							sheet(iHead + 1, 10).Value = ""
							sheet(iHead + 1, 11).Value = ""
							sheet(iHead + 1, 12).Value = ""
							sheet(iHead + 1, 13).Value = ""
							sheet(iHead + 1, 14).Value = ""
							sheet(iHead + 1, 15).Value = ""
						End If
						blnData = False
					Next

					'入庫日、発送日、局所数、健康管理施設数をセット
					'dt2に入庫日、発送日、局所数を取得しておく
					sheet(12, 1).Value = CDate(CDate(dt2.Rows(0)("インポート日時")).ToString("yyyy/MM/dd"))
					sheet(13, 1).Value = CDate(dt2.Rows(0)("発送日"))
					sheet(14, 1).Value = dt2.Rows(0)("ZIPファイル")
					sheet(15, 1).Value = iCheckupDefect
					sheet(16, 1).Value = iLeafDefect
					sheet(17, 1).Value = iLeafDupe
					sheet(18, 1).Value = iTargetList
					sheet(19, 1).Value = CInt(dt2.Rows(0)("局所数"))
					sheet(20, 1).Value = iFacilityCount

			End Select

			'wb.Load(strTemplate)    'テンプレートエクセルを読み込む
			''Dim sheet As XLSheet = wb.Sheets(0) '先頭のシートを指定
			'Dim i As Integer    'TryParse用変数

			'For iRow As Integer = 0 To dt.Rows.Count - 1
			'	sheet(iRow + 1, 0).Value = dt.Rows(iRow)("レコード番号")
			'	sheet(iRow + 1, 1).Value = dt.Rows(iRow)("表示用")
			'	If Integer.TryParse(dt.Rows(iRow)("行番号"), i) Then
			'		sheet(iRow + 1, 2).Value = CInt(dt.Rows(iRow)("行番号"))
			'	Else
			'		sheet(iRow + 1, 2).Value = dt.Rows(iRow)("行番号")
			'	End If
			'	sheet(iRow + 1, 3).Value = dt.Rows(iRow)("県名")
			'	sheet(iRow + 1, 4).Value = dt.Rows(iRow)("資料名")
			'	sheet(iRow + 1, 5).Value = dt.Rows(iRow)("副題")
			'	sheet(iRow + 1, 6).Value = dt.Rows(iRow)("対象年")
			'	sheet(iRow + 1, 7).Value = dt.Rows(iRow)("刊行者名")
			'	sheet(iRow + 1, 8).Value = dt.Rows(iRow)("刊行年月")
			'	If Integer.TryParse(dt.Rows(iRow)("分類1"), i) Then
			'		sheet(iRow + 1, 9).Value = CInt(dt.Rows(iRow)("分類1"))
			'	Else
			'		sheet(iRow + 1, 9).Value = dt.Rows(iRow)("分類1")
			'	End If
			'	If Integer.TryParse(dt.Rows(iRow)("分類2"), i) Then
			'		sheet(iRow + 1, 10).Value = CInt(dt.Rows(iRow)("分類2"))
			'	Else
			'		sheet(iRow + 1, 10).Value = dt.Rows(iRow)("分類2")
			'	End If
			'	If Integer.TryParse(dt.Rows(iRow)("分類番号"), i) Then
			'		sheet(iRow + 1, 11).Value = CInt(dt.Rows(iRow)("分類番号"))
			'	Else
			'		sheet(iRow + 1, 11).Value = dt.Rows(iRow)("分類番号")
			'	End If
			'	sheet(iRow + 1, 12).Value = dt.Rows(iRow)("項目")
			'	If Integer.TryParse(dt.Rows(iRow)("番号1"), i) Then
			'		sheet(iRow + 1, 13).Value = CInt(dt.Rows(iRow)("番号1"))
			'	Else
			'		sheet(iRow + 1, 13).Value = dt.Rows(iRow)("番号1")
			'	End If
			'	sheet(iRow + 1, 14).Value = dt.Rows(iRow)("タイトル1")
			'	If Integer.TryParse(dt.Rows(iRow)("番号2"), i) Then
			'		sheet(iRow + 1, 15).Value = CInt(dt.Rows(iRow)("番号2"))
			'	Else
			'		sheet(iRow + 1, 15).Value = dt.Rows(iRow)("番号2")
			'	End If
			'	sheet(iRow + 1, 16).Value = dt.Rows(iRow)("タイトル2")
			'	If Integer.TryParse(dt.Rows(iRow)("番号3"), i) Then
			'		sheet(iRow + 1, 17).Value = CInt(dt.Rows(iRow)("番号3"))
			'	Else
			'		sheet(iRow + 1, 17).Value = dt.Rows(iRow)("番号3")
			'	End If
			'	sheet(iRow + 1, 18).Value = dt.Rows(iRow)("タイトル3")
			'	If Integer.TryParse(dt.Rows(iRow)("番号4"), i) Then
			'		sheet(iRow + 1, 19).Value = CInt(dt.Rows(iRow)("番号4"))
			'	Else
			'		sheet(iRow + 1, 19).Value = dt.Rows(iRow)("番号4")
			'	End If
			'	sheet(iRow + 1, 20).Value = dt.Rows(iRow)("タイトル4")
			'	If Integer.TryParse(dt.Rows(iRow)("番号5"), i) Then
			'		sheet(iRow + 1, 21).Value = CInt(dt.Rows(iRow)("番号5"))
			'	Else
			'		sheet(iRow + 1, 21).Value = dt.Rows(iRow)("番号5")
			'	End If
			'	sheet(iRow + 1, 22).Value = dt.Rows(iRow)("タイトル5")
			'	sheet(iRow + 1, 23).Value = dt.Rows(iRow)("フォルダ名")
			'	sheet(iRow + 1, 24).Value = dt.Rows(iRow)("リンク")
			'	sheet(iRow + 1, 25).Value = dt.Rows(iRow)("リンクTO")

			'Next

			wb.Save(strSaveFile, FileFormat.OpenXml)
			Return True

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & ex.StackTrace)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Return False

		End Try

	End Function

	'''' <summary>
	'''' エクセルにパスワードを設定する
	'''' </summary>
	'''' <param name="strExcelFile"></param>
	'''' <param name="strPassword"></param>
	'Public Sub SetPassword(ByVal strExcelFile As String, ByVal strPassword As String)

	'	'Excelオブジェクト
	'	Dim oExcel As New Excel.Application
	'	'ブックを開く
	'	Dim oBook As Excel.Workbook = oExcel.Workbooks.Open(strExcelFile)

	'	Try
	'		'ブックにパスワードをかけて保存する
	'		oBook.Password = strPassword
	'		oBook.Save()

	'	Catch ex As Exception

	'		Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & ex.StackTrace)
	'		MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

	'	Finally
	'		'終了処理
	'		oBook.Close(False)
	'		oBook = Nothing
	'		oExcel.Quit()
	'		oExcel = Nothing

	'	End Try
	'End Sub

	'Public Sub UnsetPassword(ByVal strExcelFile As String, ByVal strPassword As String)

	'	'Excelオブジェクト
	'	Dim oExcel As New Excel.Application
	'	'ブックを開く
	'	Dim oBook As Excel.Workbook = oExcel.Workbooks.Open(strExcelFile,,,, strPassword)

	'	Try
	'		'ブックにパスワードをかけて保存する
	'		oBook.Password = ""
	'		oBook.Save()

	'	Catch ex As Exception

	'		Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & ex.StackTrace)
	'		MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

	'	Finally
	'		'終了処理
	'		oBook.Close(False)
	'		oBook = Nothing
	'		oExcel.Quit()
	'		oExcel = Nothing

	'	End Try
	'End Sub

	''' <summary>
	''' 対象エクセルファイルから必要必要なレコードを取得してDATATABLEに格納して返す
	''' </summary>
	''' <param name="strExcelFile"></param>
	''' <param name="iStartRec"></param>
	''' <returns></returns>
	Public Function ReadExcel(ByVal strExcelFile As String, ByVal iStartRec As Integer) As DataTable

		Dim wb As New C1XLBook

		Try
			wb.Load(strExcelFile)
			Dim sheet As XLSheet = wb.Sheets(0) '先頭のシートを指定

			'DATATABLEの作成
			Dim ds As New DataSet()
			Dim dt As New DataTable()
			'データ型一覧
			'Type.GetType("System.String")
			'Type.GetType("System.Int32")
			'Type.GetType("System.Boolean")
			'Type.GetType("System.DateTime")
			'Type.GetType("System.Decimal")

			'項目の追加
			dt.Columns.Add("発令日", Type.GetType("System.String"))
			dt.Columns.Add("辞令", Type.GetType("System.String"))
			dt.Columns.Add("ユーザーID", Type.GetType("System.String"))
			dt.Columns.Add("利用者名称", Type.GetType("System.String"))
			dt.Columns.Add("利用者名称カナ", Type.GetType("System.String"))
			dt.Columns.Add("役職コード", Type.GetType("System.String"))
			dt.Columns.Add("組織コード1", Type.GetType("System.String"))
			dt.Columns.Add("組織コード2", Type.GetType("System.String"))
			dt.Columns.Add("組織コード3", Type.GetType("System.String"))
			dt.Columns.Add("組織コード4", Type.GetType("System.String"))
			dt.Columns.Add("組織コード5", Type.GetType("System.String"))
			dt.Columns.Add("海外", Type.GetType("System.String"))
			dt.Columns.Add("管理者権限", Type.GetType("System.String"))
			dt.Columns.Add("部門管理者権限", Type.GetType("System.String"))
			Dim strColName As String() = {"ID", "発令日", "辞令", "ユーザーID", "利用者名称", "利用者名称カナ", "役職コード",
			"組織コード1", "組織コード2", "組織コード3", "組織コード4", "組織コード5", "海外", "管理者権限", "部門管理者権限"}

			For iRow As Integer = iStartRec To 1000
				'発令日に値がない場合ブレークする
				If IsNull(sheet(iRow, 1).Value) Then
					Exit For
				End If
				'カラムで回す
				Dim row As DataRow = dt.NewRow()
				For iCol As Integer = 1 To 14
					row(strColName(iCol)) = IIf(IsNull(sheet(iRow, iCol).Value), "", sheet(iRow, iCol).Value)
				Next
				dt.Rows.Add(row)
			Next
			'すべて格納し終えたらDATASETにDATATABLEを追加する
			ds.Tables.Add(dt)
			dt.TableName = "DT_異動情報"
			Return dt

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & ex.StackTrace)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Return Nothing

		Finally

			wb.Dispose()

		End Try

	End Function

End Module