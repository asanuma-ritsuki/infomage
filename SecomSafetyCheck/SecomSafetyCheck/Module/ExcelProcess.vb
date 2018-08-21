Imports C1.C1Excel
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
	''' 料金按分表出力
	''' </summary>
	''' <param name="strSaveFile"></param>
	''' <param name="dt"></param>
	''' <param name="dtDate"></param>
	''' <returns></returns>
	Public Function WriteExcel(ByVal strSaveFile As String, ByVal dt As DataTable, ByVal dtDate As Date) As Boolean

		Dim strTemplate As String = ""

		Try
			Dim wb As New C1XLBook  'ワークブックのインスタンス

			'スタイルの設定
			Dim styleDivision As New XLStyle(wb)
			With styleDivision
				.Font = New Font("ＭＳ Ｐゴシック", 11, FontStyle.Regular)
				.AlignVert = XLAlignVertEnum.Center
				.BorderTop = XLLineStyleEnum.Thin   '細線
				.BorderRight = XLLineStyleEnum.Thin
				.BorderBottom = XLLineStyleEnum.Thin
				.BorderLeft = XLLineStyleEnum.Thin
			End With

			strTemplate = Application.StartupPath & "\Template\Template.xlsx"
			wb.Load(strTemplate)    'テンプレートエクセルを読み込む
			Dim sheet As XLSheet = wb.Sheets(0) '戦闘のシートを指定

			'ヘッダのセット
			sheet(0, 1).Value = dtDate.ToString("yyyy") & "年" & dtDate.ToString("MM") & "月分セコム安否確認サービス　各社利用料（" & dtDate.ToString("MM") & "月" & dtDate.ToString("dd") & "日現在登録基準）"
			'各レコードの出力
			For iRow As Integer = 0 To dt.Rows.Count - 1
				Select Case iRow
					Case 0
						'社員数
						For iCol As Integer = 5 To 11
							sheet(3, iCol).Value = dt.Rows(iRow)(iCol - 3)
						Next
					Case 1
						'事業所数
						For iCol As Integer = 5 To 11
							sheet(4, iCol).Value = dt.Rows(iRow)(iCol - 3)
						Next
					Case 2
						'管理者数
						For iCol As Integer = 5 To 11
							sheet(5, iCol).Value = dt.Rows(iRow)(iCol - 3)
						Next
					Case 3
						'部門管理者数
						For iCol As Integer = 5 To 11
							sheet(7, iCol).Value = dt.Rows(iRow)(iCol - 3)
						Next
					Case 4
						'あんぴくん
						For iCol As Integer = 5 To 11
							sheet(9, iCol).Value = dt.Rows(iRow)(iCol - 3)
						Next
					Case 5
						'あんぴくん代行送信
						For iCol As Integer = 5 To 11
							sheet(10, iCol).Value = dt.Rows(iRow)(iCol - 3)
						Next

				End Select
			Next

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

End Module
