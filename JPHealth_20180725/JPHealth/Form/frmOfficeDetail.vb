Public Class frmOfficeDetail

#Region "フォームイベント"

	''' <summary>
	''' フォームロード時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub frmOfficeDetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load

		Me.Text = My.Application.Info.ProductName & " Ver." &
			My.Application.Info.Version.ToString & " - [事業所詳細]"

		Initialize()

	End Sub

#End Region

#Region "オブジェクトイベント"

	''' <summary>
	''' 閉じるボタン押下時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click

		Me.Close()

	End Sub

	''' <summary>
	''' 全チェックボタン押下時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub btnAllSelect_Click(sender As Object, e As EventArgs) Handles btnAllSelect.Click

		If Me.C1FGridResult.Rows.Count > 1 Then
			For iRow As Integer = 1 To Me.C1FGridResult.Rows.Count - 1
				If Me.C1FGridResult.Rows(iRow).Visible = True Then
					'フィルタで見えているレコードのみ対象とする
					Me.C1FGridResult(iRow, "CHK") = True
				End If
			Next
		End If

	End Sub

	''' <summary>
	''' 全解除ボタン押下時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub btnAllUnSelect_Click(sender As Object, e As EventArgs) Handles btnAllUnSelect.Click

		If Me.C1FGridResult.Rows.Count > 1 Then
			For iRow As Integer = 1 To Me.C1FGridResult.Rows.Count - 1
				Me.C1FGridResult(iRow, "CHK") = False
			Next
		End If

	End Sub

	''' <summary>
	''' 選択チェックボタン押下時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub btnSelectCheck_Click(sender As Object, e As EventArgs) Handles btnSelectCheck.Click

		Dim r As C1.Win.C1FlexGrid.Row

		For Each r In C1FGridResult.Rows.Selected
			If r.Visible = True Then
				'フィルタで見えているレコードのみ対象とする
				Me.C1FGridResult(r.Index, "CHK") = True
			End If
		Next

	End Sub

	''' <summary>
	''' 印刷ボタン押下時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click

		'チェックフラグ確認
		Dim iChecked As Integer = 0
		For iRow As Integer = 1 To Me.C1FGridResult.Rows.Count - 1
			If Me.C1FGridResult(iRow, "CHK") Then
				iChecked += 1
			End If
		Next
		If iChecked = 0 Then
			MessageBox.Show("下段グリッドより印刷対象にチェックを入れてください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Exit Sub
		End If

        If MessageBox.Show("選択対象を印刷します" & vbNewLine & "※既にQRコードチェックを行っていた場合はフラグが取り下げられます" & vbNewLine & "よろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
            Exit Sub
        End If

        Dim f As frmPrint = CType(Me.Owner, frmPrint)

		XmlSettings.LoadFromXmlFile()
		XmlSettings.Instance.Printer_Header = f.cmbPrinterHeader.SelectedItem
		XmlSettings.Instance.Printer_Label = f.cmbPrinterLabel.SelectedItem
		XmlSettings.Instance.Printer_Sentlist = f.cmbPrinterSentlist.SelectedItem
		XmlSettings.Instance.Printer_SentLeaflet = f.cmbPrinterSentLeaflet.SelectedItem
		XmlSettings.Instance.Printer_Result = f.cmbPrinterResult.SelectedItem
		XmlSettings.Instance.Printer_Leaflet = f.cmbPrinterLeaflet.SelectedItem
		XmlSettings.Instance.HeaderTray = f.cmbHeaderTray.SelectedIndex
		XmlSettings.Instance.LabelTray = f.cmbLabelTray.SelectedIndex
		XmlSettings.Instance.SentlistTray = f.cmbSentlistTray.SelectedIndex
		XmlSettings.Instance.SentLeafletTray = f.cmbSentLeafletTray.SelectedIndex
		XmlSettings.Instance.ResultTray = f.cmbResultTray.SelectedIndex
		XmlSettings.Instance.LeafletTray = f.cmbLeafletTray.SelectedIndex
		XmlSettings.SaveToXmlFile()

		Dim sqlProcess As New SQLProcess
		Dim strSQL As String = ""
		Dim dt As DataTable = Nothing

		Try

			For iRow As Integer = 1 To Me.C1FGridResult.Rows.Count - 1

				If Me.C1FGridResult(iRow, "CHK") = False Then
					Continue For
				End If

                Select Case Me.C1FGridResult(iRow, "帳票種別ID")
                    Case 2
                        '対象者一覧
                        strSQL = "SELECT T1.ロットID, T1.会社コード, T1.所属事業所コード, T1.印刷ID, T1.ページ数, T1.レコード番号, "
                        strSQL &= "T1.会社, T1.所属事業所, T1.所属部名, T1.所属課名, T1.氏名, T1.受診日, T1.健診種別, T1.意見書発行, "
                        strSQL &= "T1.判定票要押印, T3.QR AS QRコード, T4.ラベル連番, T3.分数 "
                        strSQL &= "FROM T_対象者一覧印刷 AS T1 INNER JOIN "
                        strSQL &= "T_判定票管理 AS T2 ON T1.ロットID = T2.ロットID "
                        strSQL &= "AND T1.レコード番号 = T2.レコード番号 LEFT OUTER JOIN "
                        strSQL &= "T_印刷ソート AS T3 ON T1.ロットID = T3.ロットID "
                        strSQL &= "AND T1.会社コード = T3.会社コード "
                        strSQL &= "AND T1.所属事業所コード = T3.所属事業所コード "
                        strSQL &= "AND T1.印刷ID = T3.印刷ID "
                        strSQL &= "AND T1.ページ数 = T3.ページ数 INNER JOIN "
                        strSQL &= "T_印刷管理 AS T4 ON T1.ロットID = T4.ロットID "
                        strSQL &= "AND T1.会社コード = T4.会社コード "
                        strSQL &= "AND T1.所属事業所コード = T4.所属事業所コード "
                        strSQL &= "AND T1.印刷ID = T4.印刷ID "
                        strSQL &= "WHERE T1.ロットID = '" & Me.txtLotID.Text & "' "
                        strSQL &= "AND T1.会社コード = '" & Me.txtCompanyCode.Text & "' "
                        strSQL &= "AND T1.所属事業所コード = '" & Me.txtOfficeCode.Text & "' "
                        strSQL &= "AND T1.印刷ID = " & Me.txtPrintID.Text & " "
                        strSQL &= "AND T3.帳票種別ID = 2 "  '対象者一覧
                        strSQL &= "AND T1.ページ数 = " & Me.C1FGridResult(iRow, "出力順") & " "
                        strSQL &= "ORDER BY CASE WHEN ISNULL(T1.所属部名, '') = '' THEN 1 ELSE 0 END, "
                        strSQL &= "T1.所属部名, "
                        strSQL &= "CASE WHEN ISNULL(T1.所属課名, '') = '' THEN 1 ELSE 0 END, "
                        strSQL &= "T1.所属課名, T2.社員コード"
                        dt = sqlProcess.DB_SELECT_DATATABLE(strSQL)
                        If dt.Rows.Count > 0 Then
                            '印刷処理
                            PrintProcess.Print(strSQL, PrintCategory.CheckupListIndividual)
                        End If
                    Case 3
                        '保健指導名簿
                        strSQL = "SELECT T1.ロットID, T1.会社コード, T1.所属事業所コード, T1.印刷ID, T1.ページ数, "
                        strSQL &= "T1.レコード番号, T1.会社, T1.所属事業所, T1.所属部名, T1.所属課名, T1.社員コード, "
                        strSQL &= "T1.氏名, T1.帳票タイプ, T2.QR AS QRコード, T3.ラベル連番, T2.分数 "
                        strSQL &= "FROM T_保健指導名簿印刷 AS T1 LEFT OUTER JOIN "
                        strSQL &= "T_印刷ソート AS T2 ON T1.ロットID = T2.ロットID "
                        strSQL &= "AND T1.会社コード = T2.会社コード "
                        strSQL &= "AND T1.所属事業所コード = T2.所属事業所コード "
                        strSQL &= "AND T1.印刷ID = T2.印刷ID "
                        strSQL &= "AND T1.ページ数 = T2.ページ数 INNER JOIN "
                        strSQL &= "T_印刷管理 AS T3 ON T1.ロットID = T3.ロットID "
                        strSQL &= "AND T1.会社コード = T3.会社コード "
                        strSQL &= "AND T1.所属事業所コード = T3.所属事業所コード "
                        strSQL &= "AND T1.印刷ID = T3.印刷ID "
                        strSQL &= "WHERE T1.ロットID = '" & Me.txtLotID.Text & "' "
                        strSQL &= "AND T1.会社コード = '" & Me.txtCompanyCode.Text & "' "
                        strSQL &= "AND T1.所属事業所コード = '" & Me.txtOfficeCode.Text & "' "
                        strSQL &= "AND T1.印刷ID = " & Me.txtPrintID.Text & " "
                        strSQL &= "AND T2.帳票種別ID = 3 "  '保健指導名簿
                        strSQL &= "AND T1.ページ数 = " & Me.C1FGridResult(iRow, "出力順") & " "
                        strSQL &= "ORDER BY CASE WHEN ISNULL(T1.所属部名, '') = '' THEN 1 ELSE 0 END, "
                        strSQL &= "T1.所属部名, "
                        strSQL &= "CASE WHEN ISNULL(T1.所属課名, '') = '' THEN 1 ELSE 0 END, "
                        strSQL &= "T1.所属課名, T1.社員コード"
                        dt = sqlProcess.DB_SELECT_DATATABLE(strSQL)
                        If dt.Rows.Count > 0 Then
                            '印刷処理
                            PrintProcess.Print(strSQL, PrintCategory.LeafletListIndividual)
                        End If
                    Case 4
                        '判定票
                        strSQL = "SELECT T1.ロットID, T1.レコード番号, T1.システムID, T1.氏名カナ, T1.氏名, T1.会社, "
                        strSQL &= "T1.所属事業所, T1.所属部名, T1.所属課名, T1.役職名, T1.性別, T1.採用年月日, T1.生年月日, "
                        strSQL &= "T1.受診年齢, T1.健診種別, T1.受診日, T1.身長, T1.体重, T1.体重記号, T1.体重上限, T1.体重下限, "
                        strSQL &= "T1.BMI, T1.BMI記号, T1.BMI上限, T1.BMI下限, T1.腹囲, T1.腹囲記号, T1.腹囲上限, T1.腹囲下限, "
                        strSQL &= "T1.視力裸眼右, T1.視力裸眼左, T1.視力矯正右, T1.視力矯正左, T1.聴力右1000, T1.聴力右4000, "
                        strSQL &= "T1.聴力左1000, T1.聴力左4000, T1.聴力その他, T1.血圧1回収縮期, T1.血圧1回収縮期記号, "
                        strSQL &= "T1.血圧1回収縮期上限, T1.血圧1回収縮期下限, T1.血圧1回拡張期, T1.血圧1回拡張期記号, "
                        strSQL &= "T1.血圧1回拡張期上限, T1.血圧1回拡張期下限, T1.尿糖定性, T1.尿蛋白定性, T1.総コレステロール, "
                        strSQL &= "T1.総コレステロール記号, T1.総コレステロール上限, T1.総コレステロール下限, T1.HDLコレステロール, "
                        strSQL &= "T1.HDLコレステロール記号, T1.HDLコレステロール上限, T1.HDLコレステロール下限, T1.中性脂肪, "
                        strSQL &= "T1.中性脂肪記号, T1.中性脂肪上限, T1.中性脂肪下限, T1.LDLコレステロール, T1.LDLコレステロール記号, "
                        strSQL &= "T1.LDLコレステロール上限, T1.LDLコレステロール下限, T1.GOT, T1.GOT記号, T1.GOT上限, T1.GOT下限, "
                        strSQL &= "T1.GPT, T1.GPT記号, T1.GPT上限, T1.GPT下限, T1.ガンマGTP, T1.ガンマGTP記号, T1.ガンマGTP上限, "
                        strSQL &= "T1.ガンマGTP下限, T1.クレアチニン, T1.クレアチニン記号, T1.クレアチニン上限, T1.クレアチニン下限, "
                        strSQL &= "T1.尿酸, T1.尿酸記号, T1.尿酸上限, T1.尿酸下限, T1.赤血球, T1.赤血球記号, T1.赤血球上限, "
                        strSQL &= "T1.赤血球下限, T1.血色素量, T1.血色素量記号, T1.血色素量上限, T1.血色素量下限, T1.空腹時血糖, "
                        strSQL &= "T1.空腹時血糖記号, T1.空腹時血糖上限, T1.空腹時血糖下限, T1.随時血糖, T1.随時血糖記号, "
                        strSQL &= "T1.随時血糖上限, T1.随時血糖下限, T1.HbA1c, T1.HbA1c記号, T1.HbA1c上限, T1.HbA1c下限, "
                        strSQL &= "T1.受診検査機関名称, T1.会場局名称, T1.総合判定, T1.健診実施医師名, T1.判定医師名, T1.判定日付, "
                        strSQL &= "T1.視力判定, T1.聴力判定, T1.血圧判定, T1.尿糖判定, T1.尿蛋白判定, T1.血中脂質判定, T1.肝機能判定, "
                        strSQL &= "T1.腎機能判定, T1.尿酸判定, T1.血液判定, T1.血糖判定, T1.胸部X線判定結果, T1.心電図判定結果, "
                        strSQL &= "T1.総合成績判定, T1.就業区分, T1.胸部X線所見, T1.胸部X線判定, T1.心電図所見, T1.心電図判定, "
                        strSQL &= "T1.既往歴, T1.自覚症状, T1.診察所見, T1.総合コメント, T1.産業医の意見, T1.QRコード, T4.ラベル連番 "
                        strSQL &= "FROM T_判定票印刷 AS T1 INNER JOIN "
                        strSQL &= "T_印刷ソート AS T2 ON T1.ロットID = T2.ロットID "
                        strSQL &= "AND T1.レコード番号 = T2.レコード番号 INNER JOIN "
                        strSQL &= "T_判定票管理 AS T3 ON T1.ロットID = T3.ロットID "
                        strSQL &= "AND T1.レコード番号 = T3.レコード番号 INNER JOIN "
                        strSQL &= "T_印刷管理 AS T4 ON T2.ロットID = T4.ロットID "
                        strSQL &= "AND T2.会社コード = T4.会社コード "
                        strSQL &= "AND T2.所属事業所コード = T4.所属事業所コード "
                        strSQL &= "AND T2.印刷ID = T4.印刷ID "
                        strSQL &= "WHERE T1.ロットID = '" & Me.txtLotID.Text & "' "
                        strSQL &= "AND T1.システムID = '" & Me.C1FGridResult(iRow, "システムID") & "' "
                        strSQL &= "AND T2.会社コード = '" & Me.txtCompanyCode.Text & "' "
                        strSQL &= "AND T2.所属事業所コード = '" & Me.txtOfficeCode.Text & "' "
                        strSQL &= "AND T2.印刷ID = " & Me.txtPrintID.Text & " "
                        strSQL &= "AND T2.帳票種別ID = 4 "  '判定票
                        strSQL &= "AND T2.ページ数 = " & Me.C1FGridResult(iRow, "出力順") & " "
                        strSQL &= "ORDER BY CASE WHEN ISNULL(T1.所属部名, '') = '' THEN 1 ELSE 0 END, "
                        strSQL &= "T1.所属部名, "
                        strSQL &= "CASE WHEN ISNULL(T1.所属課名, '') = '' THEN 1 ELSE 0 END, "
                        strSQL &= "T1.所属課名, T3.社員コード"
                        dt = sqlProcess.DB_SELECT_DATATABLE(strSQL)
                        If dt.Rows.Count > 0 Then
                            '印刷処理
                            PrintProcess.Print(strSQL, PrintCategory.Checkup)
                        End If
                    Case 5
                        'リーフレット
                        'レコード番号は特定されているので、該当社員の帳票タイプを列挙してそれぞれ印刷する
                        strSQL = "SELECT T1.帳票タイプ FROM T_リーフレット印刷 AS T1 INNER JOIN "
                        strSQL &= "M_帳票タイプ AS T2 ON T1.帳票タイプ = T2.帳票タイプ "
                        strSQL &= "WHERE T1.ロットID = '" & Me.txtLotID.Text & "' "
                        strSQL &= "AND T1.レコード番号 = " & Me.C1FGridResult(iRow, "レコード番号")
                        Dim dtFormType As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)

                        For iFormType As Integer = 0 To dtFormType.Rows.Count - 1
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
                            strSQL &= "T_印刷管理 AS T3 ON T2.ロットID = T3.ロットID "
                            strSQL &= "AND T2.会社コード = T3.会社コード "
                            strSQL &= "AND T2.所属事業所コード = T3.所属事業所コード "
							strSQL &= "AND T2.印刷ID = T3.印刷ID INNER JOIN "
							'==================================================
							'2018/06/11
							strSQL &= "T_リーフレット AS T4 ON T1.ロットID = T4.ロットID "
							strSQL &= "AND T1.レコード番号 = T4.レコード番号 "
							'==================================================
							strSQL &= "WHERE T1.ロットID = '" & Me.txtLotID.Text & "' "
							strSQL &= "AND T1.レコード番号 = " & Me.C1FGridResult(iRow, "レコード番号") & " "
                            strSQL &= "AND T2.印刷ID = " & Me.txtPrintID.Text & " "
                            strSQL &= "AND T1.帳票タイプ = '" & dtFormType.Rows(iFormType)("帳票タイプ") & "' "
                            strSQL &= "GROUP BY T1.ロットID, T1.レコード番号, T1.システムID, T1.会社, T1.所属事業所, T1.所属部課名, T1.氏名, "
							strSQL &= "T1.局所会社名, T1.健康管理施設名, T1.郵便番号, T1.住所, T1.電話番号, T1.年度, T4.受診日, T1.帳票タイプ, "
							strSQL &= "T1.結果値1, T1.結果値2, T1.結果値3, T1.BOC, T1.EOC, T1.PAR, T1.WAS1, T1.WAS2, T1.WAS3, "
                            strSQL &= "T1.WAS4, T1.WAS5, T1.WAS6, T1.QRコード, T3.ラベル連番, T1.先頭マーク, T1.トータルSEQ, T1.カレントSEQ"
                            '印刷処理
                            Print(strSQL, PrintCategory.Leaflet, dtFormType.Rows(iFormType)("帳票タイプ"))

                        Next
                End Select

            Next

            'T_印刷ソートの該当会社コード、所属事業所コードのチェックフラグを取り下げる
            strSQL = "UPDATE T_印刷ソート SET "
            strSQL &= "チェックフラグ = 0 "
            'strSQL &= "チェック日時 = NULL, "
            'strSQL &= "作業者 = '' "
            strSQL &= "WHERE ロットID = '" & Me.txtLotID.Text & "' "
            strSQL &= "AND 会社コード = '" & Me.txtCompanyCode.Text & "' "
            strSQL &= "AND 所属事業所コード = '" & Me.txtOfficeCode.Text & "'"
            sqlProcess.DB_UPDATE(strSQL)

            MessageBox.Show("印刷処理が完了しました", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information)

		Catch ex As Exception

            Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & ex.StackTrace)
            MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally

            sqlProcess.Close()

        End Try

    End Sub

	'''' <summary>
	'''' グリッドダブルクリック時
	'''' </summary>
	'''' <param name="sender"></param>
	'''' <param name="e"></param>
	'Private Sub C1FGridResult_DoubleClick(sender As Object, e As EventArgs) Handles C1FGridResult.DoubleClick

	'	Dim iIndex As Integer = Me.C1FGridResult.Row
	'	'帳票単位でSQL文を成形
	'	Dim sqlProcess As New SQLProcess
	'	Dim strSQL As String = ""
	'	Dim dt As DataTable = Nothing

	'	Dim strConnectionString As String = ""
	'	XmlSettings.LoadFromXmlFile()
	'	Dim C1FlexReport1 As New C1.Win.FlexReport.C1FlexReport
	'	Dim f As New frmPrintPreview

	'	Try
	'		'接続文字列を作成する
	'		strConnectionString = "Provider=SQLOLEDB.1;"
	'		strConnectionString &= "Password=" & XmlSettings.Instance.Password & ";"
	'		strConnectionString &= "Persist Security Info=True;"
	'		strConnectionString &= "User ID=" & XmlSettings.Instance.UserID & ";"
	'		strConnectionString &= "Initial Catalog=" & XmlSettings.Instance.InitialCatalog & ";"
	'		strConnectionString &= "Data Source=" & XmlSettings.Instance.DataSource

	'		Select Case Me.C1FGridResult(iIndex, "帳票種別ID")
	'			Case 2
	'				'対象者一覧
	'				strSQL = "SELECT T1.ロットID, T1.会社コード, T1.所属事業所コード, T1.印刷ID, T1.ページ数, T1.レコード番号, "
	'				strSQL &= "T1.会社, T1.所属事業所, T1.所属部名, T1.所属課名, T1.氏名, T1.受診日, T1.健診種別, T1.意見書発行, "
	'				strSQL &= "T1.判定票要押印, T3.QR AS QRコード, T4.ラベル連番, T3.分数 "
	'				strSQL &= "FROM T_対象者一覧印刷 AS T1 INNER JOIN "
	'				strSQL &= "T_判定票管理 AS T2 ON T1.ロットID = T2.ロットID "
	'				strSQL &= "AND T1.レコード番号 = T2.レコード番号 LEFT OUTER JOIN "
	'				strSQL &= "T_印刷ソート AS T3 ON T1.ロットID = T3.ロットID "
	'				strSQL &= "AND T1.会社コード = T3.会社コード "
	'				strSQL &= "AND T1.所属事業所コード = T3.所属事業所コード "
	'				strSQL &= "AND T1.印刷ID = T3.印刷ID "
	'				strSQL &= "AND T1.ページ数 = T3.ページ数 INNER JOIN "
	'				strSQL &= "T_印刷管理 AS T4 ON T1.ロットID = T4.ロットID "
	'				strSQL &= "AND T1.会社コード = T4.会社コード "
	'				strSQL &= "AND T1.所属事業所コード = T4.所属事業所コード "
	'				strSQL &= "AND T1.印刷ID = T4.印刷ID "
	'				strSQL &= "WHERE T1.ロットID = '" & Me.txtLotID.Text & "' "
	'				strSQL &= "AND T1.会社コード = '" & Me.txtCompanyCode.Text & "' "
	'				strSQL &= "AND T1.所属事業所コード = '" & Me.txtOfficeCode.Text & "' "
	'				strSQL &= "AND T1.印刷ID = " & Me.txtPrintID.Text & " "
	'				strSQL &= "AND T3.帳票種別ID = 2 "  '対象者一覧
	'				strSQL &= "AND T1.ページ数 = " & Me.C1FGridResult(iIndex, "出力順") & " "
	'				strSQL &= "ORDER BY CASE WHEN ISNULL(T1.所属部名, '') = '' THEN 1 ELSE 0 END, "
	'				strSQL &= "T1.所属部名, "
	'				strSQL &= "CASE WHEN ISNULL(T1.所属課名, '') = '' THEN 1 ELSE 0 END, "
	'				strSQL &= "T1.所属課名, T2.社員コード"

	'				C1FlexReport1.Load(Application.StartupPath & "\Template\result.flxr", "対象者一覧")
	'				'接続文字列、SQL文の設定
	'				C1FlexReport1.DataSource.ConnectionString = strConnectionString
	'				C1FlexReport1.DataSource.RecordSource = strSQL
	'				'frmPrintPreviewのC1FlexViewerに代入
	'				f.C1FlexViewer1.DocumentSource = C1FlexReport1

	'			Case 3
	'				'保健指導名簿
	'				strSQL = "SELECT T1.ロットID, T1.会社コード, T1.所属事業所コード, T1.印刷ID, T1.ページ数, "
	'				strSQL &= "T1.レコード番号, T1.会社, T1.所属事業所, T1.所属部名, T1.所属課名, T1.社員コード, "
	'				strSQL &= "T1.氏名, T1.帳票タイプ, T2.QR AS QRコード, T3.ラベル連番, T2.分数 "
	'				strSQL &= "FROM T_保健指導名簿印刷 AS T1 LEFT OUTER JOIN "
	'				strSQL &= "T_印刷ソート AS T2 ON T1.ロットID = T2.ロットID "
	'				strSQL &= "AND T1.会社コード = T2.会社コード "
	'				strSQL &= "AND T1.所属事業所コード = T2.所属事業所コード "
	'				strSQL &= "AND T1.印刷ID = T2.印刷ID "
	'				strSQL &= "AND T1.ページ数 = T2.ページ数 INNER JOIN "
	'				strSQL &= "T_印刷管理 AS T3 ON T1.ロットID = T3.ロットID "
	'				strSQL &= "AND T1.会社コード = T3.会社コード "
	'				strSQL &= "AND T1.所属事業所コード = T3.所属事業所コード "
	'				strSQL &= "AND T1.印刷ID = T3.印刷ID "
	'				strSQL &= "WHERE T1.ロットID = '" & Me.txtLotID.Text & "' "
	'				strSQL &= "AND T1.会社コード = '" & Me.txtCompanyCode.Text & "' "
	'				strSQL &= "AND T1.所属事業所コード = '" & Me.txtOfficeCode.Text & "' "
	'				strSQL &= "AND T1.印刷ID = " & Me.txtPrintID.Text & " "
	'				strSQL &= "AND T2.帳票種別ID = 3 "  '保健指導名簿
	'				strSQL &= "AND T1.ページ数 = " & Me.C1FGridResult(iIndex, "出力順") & " "
	'				strSQL &= "ORDER BY CASE WHEN ISNULL(T1.所属部名, '') = '' THEN 1 ELSE 0 END, "
	'				strSQL &= "T1.所属部名, "
	'				strSQL &= "CASE WHEN ISNULL(T1.所属課名, '') = '' THEN 1 ELSE 0 END, "
	'				strSQL &= "T1.所属課名, T1.社員コード"

	'				C1FlexReport1.Load(Application.StartupPath & "\Template\result.flxr", "保健指導名簿")
	'				'接続文字列、SQL文の設定
	'				C1FlexReport1.DataSource.ConnectionString = strConnectionString
	'				C1FlexReport1.DataSource.RecordSource = strSQL
	'				'frmPrintPreviewのC1FlexViewerに代入
	'				f.C1FlexViewer1.DocumentSource = C1FlexReport1

	'			Case 4
	'				'判定票
	'				strSQL = "SELECT T1.ロットID, T1.レコード番号, T1.システムID, T1.氏名カナ, T1.氏名, T1.会社, "
	'				strSQL &= "T1.所属事業所, T1.所属部名, T1.所属課名, T1.役職名, T1.性別, T1.採用年月日, T1.生年月日, "
	'				strSQL &= "T1.受診年齢, T1.健診種別, T1.受診日, T1.身長, T1.体重, T1.体重記号, T1.体重上限, T1.体重下限, "
	'				strSQL &= "T1.BMI, T1.BMI記号, T1.BMI上限, T1.BMI下限, T1.腹囲, T1.腹囲記号, T1.腹囲上限, T1.腹囲下限, "
	'				strSQL &= "T1.視力裸眼右, T1.視力裸眼左, T1.視力矯正右, T1.視力矯正左, T1.聴力右1000, T1.聴力右4000, "
	'				strSQL &= "T1.聴力左1000, T1.聴力左4000, T1.聴力その他, T1.血圧1回収縮期, T1.血圧1回収縮期記号, "
	'				strSQL &= "T1.血圧1回収縮期上限, T1.血圧1回収縮期下限, T1.血圧1回拡張期, T1.血圧1回拡張期記号, "
	'				strSQL &= "T1.血圧1回拡張期上限, T1.血圧1回拡張期下限, T1.尿糖定性, T1.尿蛋白定性, T1.総コレステロール, "
	'				strSQL &= "T1.総コレステロール記号, T1.総コレステロール上限, T1.総コレステロール下限, T1.HDLコレステロール, "
	'				strSQL &= "T1.HDLコレステロール記号, T1.HDLコレステロール上限, T1.HDLコレステロール下限, T1.中性脂肪, "
	'				strSQL &= "T1.中性脂肪記号, T1.中性脂肪上限, T1.中性脂肪下限, T1.LDLコレステロール, T1.LDLコレステロール記号, "
	'				strSQL &= "T1.LDLコレステロール上限, T1.LDLコレステロール下限, T1.GOT, T1.GOT記号, T1.GOT上限, T1.GOT下限, "
	'				strSQL &= "T1.GPT, T1.GPT記号, T1.GPT上限, T1.GPT下限, T1.ガンマGTP, T1.ガンマGTP記号, T1.ガンマGTP上限, "
	'				strSQL &= "T1.ガンマGTP下限, T1.クレアチニン, T1.クレアチニン記号, T1.クレアチニン上限, T1.クレアチニン下限, "
	'				strSQL &= "T1.尿酸, T1.尿酸記号, T1.尿酸上限, T1.尿酸下限, T1.赤血球, T1.赤血球記号, T1.赤血球上限, "
	'				strSQL &= "T1.赤血球下限, T1.血色素量, T1.血色素量記号, T1.血色素量上限, T1.血色素量下限, T1.空腹時血糖, "
	'				strSQL &= "T1.空腹時血糖記号, T1.空腹時血糖上限, T1.空腹時血糖下限, T1.随時血糖, T1.随時血糖記号, "
	'				strSQL &= "T1.随時血糖上限, T1.随時血糖下限, T1.HbA1c, T1.HbA1c記号, T1.HbA1c上限, T1.HbA1c下限, "
	'				strSQL &= "T1.受診検査機関名称, T1.会場局名称, T1.総合判定, T1.健診実施医師名, T1.判定医師名, T1.判定日付, "
	'				strSQL &= "T1.視力判定, T1.聴力判定, T1.血圧判定, T1.尿糖判定, T1.尿蛋白判定, T1.血中脂質判定, T1.肝機能判定, "
	'				strSQL &= "T1.腎機能判定, T1.尿酸判定, T1.血液判定, T1.血糖判定, T1.胸部X線判定結果, T1.心電図判定結果, "
	'				strSQL &= "T1.総合成績判定, T1.就業区分, T1.胸部X線所見, T1.胸部X線判定, T1.心電図所見, T1.心電図判定, "
	'				strSQL &= "T1.既往歴, T1.自覚症状, T1.診察所見, T1.総合コメント, T1.産業医の意見, T1.QRコード, T4.ラベル連番 "
	'				strSQL &= "FROM T_判定票印刷 AS T1 INNER JOIN "
	'				strSQL &= "T_印刷ソート AS T2 ON T1.ロットID = T2.ロットID "
	'				strSQL &= "AND T1.レコード番号 = T2.レコード番号 INNER JOIN "
	'				strSQL &= "T_判定票管理 AS T3 ON T1.ロットID = T3.ロットID "
	'				strSQL &= "AND T1.レコード番号 = T3.レコード番号 INNER JOIN "
	'				strSQL &= "T_印刷管理 AS T4 ON T2.ロットID = T4.ロットID "
	'				strSQL &= "AND T2.会社コード = T4.会社コード "
	'				strSQL &= "AND T2.所属事業所コード = T4.所属事業所コード "
	'				strSQL &= "AND T2.印刷ID = T4.印刷ID "
	'				strSQL &= "WHERE T1.ロットID = '" & Me.txtLotID.Text & "' "
	'				strSQL &= "AND T1.システムID = '" & Me.C1FGridResult(iIndex, "システムID") & "' "
	'				strSQL &= "AND T2.会社コード = '" & Me.txtCompanyCode.Text & "' "
	'				strSQL &= "AND T2.所属事業所コード = '" & Me.txtOfficeCode.Text & "' "
	'				strSQL &= "AND T2.印刷ID = " & Me.txtPrintID.Text & " "
	'				strSQL &= "AND T2.帳票種別ID = 4 "  '判定票
	'				strSQL &= "AND T2.ページ数 = " & Me.C1FGridResult(iIndex, "出力順") & " "
	'				strSQL &= "ORDER BY CASE WHEN ISNULL(T1.所属部名, '') = '' THEN 1 ELSE 0 END, "
	'				strSQL &= "T1.所属部名, "
	'				strSQL &= "CASE WHEN ISNULL(T1.所属課名, '') = '' THEN 1 ELSE 0 END, "
	'				strSQL &= "T1.所属課名, T3.社員コード"

	'				C1FlexReport1.Load(Application.StartupPath & "\Template\result.flxr", "判定票")
	'				'接続文字列、SQL文の設定
	'				C1FlexReport1.DataSource.ConnectionString = strConnectionString
	'				C1FlexReport1.DataSource.RecordSource = strSQL
	'				'frmPrintPreviewのC1FlexViewerに代入
	'				f.C1FlexViewer1.DocumentSource = C1FlexReport1

	'			Case 5
	'				'リーフレット
	'				'レコード番号は特定されているので、該当社員の帳票タイプを列挙して追加する
	'				strSQL = "SELECT T1.帳票タイプ FROM T_リーフレット印刷 AS T1 INNER JOIN "
	'				strSQL &= "M_帳票タイプ AS T2 ON T1.帳票タイプ = T2.帳票タイプ "
	'				strSQL &= "WHERE T1.ロットID = '" & Me.txtLotID.Text & "' "
	'				strSQL &= "AND T1.レコード番号 = " & Me.C1FGridResult(iIndex, "レコード番号")
	'				Dim dtFormType As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
	'				Dim pages As New List(Of System.Drawing.Imaging.Metafile)

	'				For iFormType As Integer = 0 To dtFormType.Rows.Count - 1
	'					'帳票タイプごとに回す
	'					strSQL = "SELECT T1.ロットID, T1.レコード番号, T1.システムID, T1.会社, T1.所属事業所, T1.所属部課名, "
	'					strSQL &= "T1.氏名, T1.局所会社名, T1.健康管理施設名, T1.郵便番号, T1.住所, T1.電話番号, T1.年度, "
	'					strSQL &= "T1.帳票タイプ, T1.結果値1, T1.結果値2, T1.結果値3, T1.BOC, T1.EOC, T1.PAR, "
	'					strSQL &= "T1.WAS1, T1.WAS2, T1.WAS3, T1.WAS4, T1.WAS5, T1.WAS6, T1.QRコード, T3.ラベル連番, T1.先頭マーク, "
	'					strSQL &= "CONVERT(VARCHAR, T1.トータルSEQ) + '-' + CONVERT(VARCHAR, T1.カレントSEQ) AS ページ "
	'					strSQL &= "FROM T_リーフレット印刷 AS T1 INNER JOIN "
	'					strSQL &= "T_印刷ソート AS T2 ON T1.ロットID = T2.ロットID "
	'					strSQL &= "AND T1.レコード番号 = T2.レコード番号 INNER JOIN "
	'					strSQL &= "T_印刷管理 AS T3 ON T2.ロットID = T3.ロットID "
	'					strSQL &= "AND T2.会社コード = T3.会社コード "
	'					strSQL &= "AND T2.所属事業所コード = T3.所属事業所コード "
	'					strSQL &= "AND T2.印刷ID = T3.印刷ID "
	'					strSQL &= "WHERE T1.ロットID = '" & Me.txtLotID.Text & "' "
	'					strSQL &= "AND T1.レコード番号 = " & Me.C1FGridResult(iIndex, "レコード番号") & " "
	'					strSQL &= "AND T2.印刷ID = " & Me.txtPrintID.Text & " "
	'					strSQL &= "AND T1.帳票タイプ = '" & dtFormType.Rows(iFormType)("帳票タイプ") & "' "
	'					strSQL &= "GROUP BY T1.ロットID, T1.レコード番号, T1.システムID, T1.会社, T1.所属事業所, T1.所属部課名, T1.氏名, "
	'					strSQL &= "T1.局所会社名, T1.健康管理施設名, T1.郵便番号, T1.住所, T1.電話番号, T1.年度, T1.帳票タイプ, "
	'					strSQL &= "T1.結果値1, T1.結果値2, T1.結果値3, T1.BOC, T1.EOC, T1.PAR, T1.WAS1, T1.WAS2, T1.WAS3, "
	'					strSQL &= "T1.WAS4, T1.WAS5, T1.WAS6, T1.QRコード, T3.ラベル連番, T1.先頭マーク, T1.トータルSEQ, T1.カレントSEQ"

	'					'Dim strReportCategory As String = "R_" & dtFormType.Rows(iFormType)("帳票タイプ")
	'					'C1FlexReport1.Load(Application.StartupPath & "\Template\leaflet.flxr", strReportCategory)
	'					''接続文字列、SQL文の設定
	'					'C1FlexReport1.DataSource.ConnectionString = strConnectionString
	'					'C1FlexReport1.DataSource.RecordSource = strSQL
	'					'C1FlexReport1.Render()
	'					'For iPage As Integer = 0 To C1FlexReport1.PageCount - 1
	'					'	pages.AddRange(C1FlexReport1.GetPageImage(iPage))
	'					'Next

	'				Next

	'				'frmPrintPreviewのC1FlexViewerに代入
	'				'f.C1FlexViewer1.DocumentSource = CType(pages, C1.Win.C1Document.C1Document)

	'		End Select

	'		f.Show(Me)

	'	Catch ex As Exception

	'		Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & ex.StackTrace)
	'		MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

	'	Finally

	'		sqlProcess.Close()

	'	End Try

	'End Sub

#End Region

#Region "プライベートメソッド"

	''' <summary>
	''' 初期化処理	
	''' </summary>
	Private Sub Initialize()

        CaptionDisplayMode = StatusDisplayMode.None
        SearchGrid()

    End Sub

    ''' <summary>
    ''' グリッド表示
    ''' </summary>
    Private Sub SearchGrid()

        Dim sqlProcess As New SQLProcess
        Dim strSQL As String = ""

        Try
            'T_印刷ソートから印刷順を保持してレコードを列挙する
            strSQL = "SELECT T1.ロットID, T2.帳票種別, T1.ページ数 AS 出力順, T1.枚数 AS リーフ枚数, "
            strSQL &= "T1.システムID, ISNULL(T3.氏名, '') AS 氏名, T1.QR, T1.レコード番号, T1.帳票種別ID "
            strSQL &= "FROM T_印刷ソート AS T1 INNER JOIN "
            strSQL &= "M_帳票種別 AS T2 ON T1.帳票種別ID = T2.帳票種別ID LEFT OUTER JOIN "
            strSQL &= "T_判定票印刷 AS T3 ON T1.ロットID = T3.ロットID AND T1.レコード番号 = T3.レコード番号 "
            strSQL &= "WHERE T1.ロットID = '" & Me.txtLotID.Text & "' "
            strSQL &= "AND T1.会社コード = '" & Me.txtCompanyCode.Text & "' "
            strSQL &= "AND T1.所属事業所コード = '" & Me.txtOfficeCode.Text & "' "
            strSQL &= "AND T1.帳票種別ID != 0 "
            strSQL &= "AND T1.印刷ID = " & Me.txtPrintID.Text & " "
            strSQL &= "ORDER BY T1.帳票種別ID, T1.ページ数"
            Dim dt As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)

            Dim iRec As Integer = 0
            For iRow As Integer = 0 To dt.Rows.Count - 1
                iRec += 1
                Me.C1FGridResult.Rows.Count = iRec + 1
                Me.C1FGridResult(iRec, "No") = iRec
                Me.C1FGridResult(iRec, "CHK") = False
                Me.C1FGridResult(iRec, "帳票種別") = dt.Rows(iRow)("帳票種別")
                Me.C1FGridResult(iRec, "出力順") = dt.Rows(iRow)("出力順")
                Me.C1FGridResult(iRec, "リーフ枚数") = dt.Rows(iRow)("リーフ枚数")
                Me.C1FGridResult(iRec, "システムID") = dt.Rows(iRow)("システムID")
                Me.C1FGridResult(iRec, "氏名") = dt.Rows(iRow)("氏名")
                Me.C1FGridResult(iRec, "QRコード") = dt.Rows(iRow)("QR")
                Me.C1FGridResult(iRec, "レコード番号") = dt.Rows(iRow)("レコード番号")
                Me.C1FGridResult(iRec, "帳票種別ID") = dt.Rows(iRow)("帳票種別ID")
            Next

        Catch ex As Exception

            Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & ex.StackTrace)
            MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		Finally

			sqlProcess.Close()

		End Try

	End Sub

#End Region

End Class