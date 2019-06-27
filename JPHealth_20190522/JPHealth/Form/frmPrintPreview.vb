Imports C1.Win.C1FlexGrid
Imports C1.Win.FlexReport

Public Class frmPrintPreview

#Region "プライベート変数"

	Private _tabPageManager As TabPageManager

#End Region

#Region "フォームイベント"

	''' <summary>
	''' フォームロード時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub frmPrintPreview_Load(sender As Object, e As EventArgs) Handles MyBase.Load

		Me.Text = My.Application.Info.ProductName & " Ver." &
			My.Application.Info.Version.ToString & " - [印刷プレビュー]"

		Initialize()
		ViewPreview()

	End Sub

#End Region

#Region "オブジェクトイベント"

	Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click

		Me.Close()

	End Sub

#End Region

#Region "プライベートメソッド"

	Private Sub Initialize()

		Me.lblProgress.Visible = False
		Me.LabelHost1.Visible = False
		Me.LabelHost2.Visible = False
		Me.LabelHost3.Visible = False
		Me.LabelHost4.Visible = False
		Me.RibbonLabel1.Visible = False
		Me.RibbonLabel2.Visible = False
		Me.RibbonLabel3.Visible = False
		Me.RibbonLabel4.Visible = False
		Me.RibbonSeparator1.Visible = False
		Me.RibbonSeparator4.Visible = False
		Me.RibbonSeparator5.Visible = False
		Me.RibbonSeparator6.Visible = False
		Me.RibbonSeparator7.Visible = False

		Me.btnBack.Text = "閉じる"

		'CaptionDisplayMode = StatusDisplayMode.None

		'一般以外のTabPageを非表示にする
		_tabPageManager = New TabPageManager(Me.TabControl1)
		For i As Integer = 1 To Me.TabControl1.TabPages.Count - 1
			_tabPageManager.ChangeTabPageVisible(i, False)
		Next

	End Sub

	''' <summary>
	''' プレビューの表示
	''' </summary>
	Private Sub ViewPreview()
		'リーフレット以外はタブは一つ
		Dim frm As frmOfficeDetail = CType(Me.Owner, frmOfficeDetail)
		Dim flxReport As C1FlexReport = Nothing
		Dim strSQL As String = ""
		Dim sqlProcess As New SQLProcess
		XmlSettings.LoadFromXmlFile()
		Dim strConnectionString As String = ""
		'接続文字列を作成する
		strConnectionString = "Provider=SQLOLEDB.1;"
		strConnectionString &= "Password=" & XmlSettings.Instance.Password & ";"
		strConnectionString &= "Persist Security Info=True;"
		strConnectionString &= "User ID=" & XmlSettings.Instance.UserID & ";"
		strConnectionString &= "Initial Catalog=" & XmlSettings.Instance.InitialCatalog & ";"
		strConnectionString &= "Data Source=" & XmlSettings.Instance.DataSource

		Try
			Dim dt As DataTable

			Select Case frm.C1FGridResult(frm.C1FGridResult.Row, "帳票種別ID")
				Case 2
					'対象者一覧
					Me.tab01.Text = "対象者一覧"
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
					strSQL &= "WHERE T1.ロットID = '" & frm.txtLotID.Text & "' "
					strSQL &= "AND T1.会社コード = '" & frm.txtCompanyCode.Text & "' "
					strSQL &= "AND T1.所属事業所コード = '" & frm.txtOfficeCode.Text & "' "
					strSQL &= "AND T1.印刷ID = " & frm.txtPrintID.Text & " "
					strSQL &= "AND T3.帳票種別ID = 2 "  '対象者一覧
					strSQL &= "AND T1.ページ数 = " & frm.C1FGridResult(frm.C1FGridResult.Row, "出力順") & " "
					strSQL &= "ORDER BY CASE WHEN ISNULL(T1.所属部名, '') = '' THEN 1 ELSE 0 END, "
					strSQL &= "T1.所属部名, "
					strSQL &= "CASE WHEN ISNULL(T1.所属課名, '') = '' THEN 1 ELSE 0 END, "
					strSQL &= "T1.所属課名, T2.社員コード"
					dt = sqlProcess.DB_SELECT_DATATABLE(strSQL)
					If dt.Rows.Count > 0 Then
						'プレビュー表示
						Dim C1FlexReport1 As New C1FlexReport
						C1FlexReport1.Load(Application.StartupPath & "\Template\result.flxr", "対象者一覧")
						'接続文字列、SQL文の設定
						C1FlexReport1.DataSource.ConnectionString = strConnectionString
						C1FlexReport1.DataSource.RecordSource = strSQL
						'C1FlexReport1.Render()
						'Me.C1FlexViewer1.RotateView = C1.Win.FlexViewer.FlexViewerRotateView.Rotation90Clockwise
						Me.C1FlexViewer1.DocumentSource = C1FlexReport1

					End If

				Case 3
					'保健指導対象者名簿
					Me.tab01.Text = "保健指導対象者名簿"
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
					strSQL &= "WHERE T1.ロットID = '" & frm.txtLotID.Text & "' "
					strSQL &= "AND T1.会社コード = '" & frm.txtCompanyCode.Text & "' "
					strSQL &= "AND T1.所属事業所コード = '" & frm.txtOfficeCode.Text & "' "
					strSQL &= "AND T1.印刷ID = " & frm.txtPrintID.Text & " "
					strSQL &= "AND T2.帳票種別ID = 3 "  '保健指導名簿
					strSQL &= "AND T1.ページ数 = " & frm.C1FGridResult(frm.C1FGridResult.Row, "出力順") & " "
					strSQL &= "ORDER BY CASE WHEN ISNULL(T1.所属部名, '') = '' THEN 1 ELSE 0 END, "
					strSQL &= "T1.所属部名, "
					strSQL &= "CASE WHEN ISNULL(T1.所属課名, '') = '' THEN 1 ELSE 0 END, "
					strSQL &= "T1.所属課名, T1.社員コード"
					dt = sqlProcess.DB_SELECT_DATATABLE(strSQL)
					If dt.Rows.Count > 0 Then
						'プレビュー表示
						Dim C1FlexReport1 As New C1FlexReport
						'2018/10/01
						'かんぽ生命とそれ以外でテンプレートを分岐させる
						If frm.txtCompanyCode.Text = XmlSettings.Instance.KanpoCode Then
							'かんぽ生命
							C1FlexReport1.Load(Application.StartupPath & "\Template\result.flxr", "保健指導名簿_かんぽ")
						Else
							C1FlexReport1.Load(Application.StartupPath & "\Template\result.flxr", "保健指導名簿")
						End If
						'接続文字列、SQL文の設定
						C1FlexReport1.DataSource.ConnectionString = strConnectionString
						C1FlexReport1.DataSource.RecordSource = strSQL
						Me.C1FlexViewer1.DocumentSource = C1FlexReport1
					End If

				Case 4
					'判定票
					Me.tab01.Text = "就業判定票"
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
                    strSQL &= "T1.既往歴, T1.自覚症状, T1.診察所見, T1.総合コメント, T1.産業医の意見, T1.QRコード, T4.ラベル連番, "
                    '2019/05/07
                    '3項目追加
                    strSQL &= "T3.年度, ISNULL(T6.印影画像パス, '') AS 産業医印影, ISNULL(T7.印影画像パス, '') AS 判定医印影 "
                    strSQL &= "FROM T_判定票印刷 AS T1 INNER JOIN "
                    strSQL &= "T_印刷ソート AS T2 ON T1.ロットID = T2.ロットID "
					strSQL &= "AND T1.レコード番号 = T2.レコード番号 INNER JOIN "
					strSQL &= "T_判定票管理 AS T3 ON T1.ロットID = T3.ロットID "
					strSQL &= "AND T1.レコード番号 = T3.レコード番号 INNER JOIN "
					strSQL &= "T_印刷管理 AS T4 ON T2.ロットID = T4.ロットID "
					strSQL &= "AND T2.会社コード = T4.会社コード "
					strSQL &= "AND T2.所属事業所コード = T4.所属事業所コード "
                    strSQL &= "AND T2.印刷ID = T4.印刷ID LEFT OUTER JOIN "
                    '2019/05/07
                    '3テーブル追加
                    strSQL &= "T_医師 AS T5 ON T1.ロットID = T5.ロットID AND T1.レコード番号 = T5.レコード番号 LEFT OUTER JOIN "
                    strSQL &= "M_産業医 AS T6 ON T5.産業医ID = T6.産業医ID LEFT OUTER JOIN "
                    strSQL &= "M_判定医 AS T7 ON T5.判定医ID = T7.判定医ID "
                    strSQL &= "WHERE T1.ロットID = '" & frm.txtLotID.Text & "' "
                    strSQL &= "AND T1.システムID = '" & frm.C1FGridResult(frm.C1FGridResult.Row, "システムID") & "' "
					strSQL &= "AND T2.会社コード = '" & frm.txtCompanyCode.Text & "' "
					strSQL &= "AND T2.所属事業所コード = '" & frm.txtOfficeCode.Text & "' "
					strSQL &= "AND T2.印刷ID = " & frm.txtPrintID.Text & " "
					strSQL &= "AND T2.帳票種別ID = 4 "  '判定票
					strSQL &= "AND T2.ページ数 = " & frm.C1FGridResult(frm.C1FGridResult.Row, "出力順") & " "
					strSQL &= "ORDER BY CASE WHEN ISNULL(T1.所属部名, '') = '' THEN 1 ELSE 0 END, "
					strSQL &= "T1.所属部名, "
					strSQL &= "CASE WHEN ISNULL(T1.所属課名, '') = '' THEN 1 ELSE 0 END, "
					strSQL &= "T1.所属課名, T3.社員コード"
					dt = sqlProcess.DB_SELECT_DATATABLE(strSQL)
					If dt.Rows.Count > 0 Then
						'プレビュー表示
						Dim C1FlexReport1 As New C1FlexReport
                        '2019/05/07
                        '年度が「2019」以降の場合は新テンプレートとする
                        If dt.Rows(0)("年度") = "2019" Then
                            C1FlexReport1.Load(Application.StartupPath & "\Template\result2019.flxr", "判定票")
                        Else
                            C1FlexReport1.Load(Application.StartupPath & "\Template\result.flxr", "判定票")
                        End If
                        '接続文字列、SQL文の設定
                        C1FlexReport1.DataSource.ConnectionString = strConnectionString
						C1FlexReport1.DataSource.RecordSource = strSQL
						Me.C1FlexViewer1.DocumentSource = C1FlexReport1
					End If

				Case 5
					'リーフレット
					'レコード番号は特定されているので、該当社員の帳票タイプを列挙してそれぞれ印刷する
					strSQL = "SELECT T1.帳票タイプ FROM T_リーフレット印刷 AS T1 INNER JOIN "
					strSQL &= "M_帳票タイプ AS T2 ON T1.帳票タイプ = T2.帳票タイプ "
					strSQL &= "WHERE T1.ロットID = '" & frm.txtLotID.Text & "' "
					strSQL &= "AND T1.レコード番号 = " & frm.C1FGridResult(frm.C1FGridResult.Row, "レコード番号")
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
						strSQL &= "WHERE T1.ロットID = '" & frm.txtLotID.Text & "' "
						strSQL &= "AND T1.レコード番号 = " & frm.C1FGridResult(frm.C1FGridResult.Row, "レコード番号") & " "
						strSQL &= "AND T2.印刷ID = " & frm.txtPrintID.Text & " "
						strSQL &= "AND T1.帳票タイプ = '" & dtFormType.Rows(iFormType)("帳票タイプ") & "' "
						strSQL &= "GROUP BY T1.ロットID, T1.レコード番号, T1.システムID, T1.会社, T1.所属事業所, T1.所属部課名, T1.氏名, "
						strSQL &= "T1.局所会社名, T1.健康管理施設名, T1.郵便番号, T1.住所, T1.電話番号, T1.年度, T4.受診日, T1.帳票タイプ, "
						strSQL &= "T1.結果値1, T1.結果値2, T1.結果値3, T1.BOC, T1.EOC, T1.PAR, T1.WAS1, T1.WAS2, T1.WAS3, "
						strSQL &= "T1.WAS4, T1.WAS5, T1.WAS6, T1.QRコード, T3.ラベル連番, T1.先頭マーク, T1.トータルSEQ, T1.カレントSEQ"
						dt = sqlProcess.DB_SELECT_DATATABLE(strSQL)

						If dt.Rows.Count = 0 Then
							Exit Sub
						End If

						Select Case iFormType
							Case 0
								'tab01
								Me.tab01.Text = dtFormType.Rows(iFormType)("帳票タイプ")
								'プレビュー表示
								Dim C1FlexReport1 As New C1FlexReport
								Dim strReportCategory As String = "R_" & dtFormType.Rows(iFormType)("帳票タイプ")
								C1FlexReport1.Load(Application.StartupPath & "\Template\leaflet.flxr", strReportCategory)
								'接続文字列、SQL文の設定
								C1FlexReport1.DataSource.ConnectionString = strConnectionString
								C1FlexReport1.DataSource.RecordSource = strSQL
								Me.C1FlexViewer1.DocumentSource = C1FlexReport1

							Case 1
								'tab02
								Me.tab02.Text = dtFormType.Rows(iFormType)("帳票タイプ")
								'プレビュー表示
								Dim C1FlexReport2 As New C1FlexReport
								Dim strReportCategory As String = "R_" & dtFormType.Rows(iFormType)("帳票タイプ")
								C1FlexReport2.Load(Application.StartupPath & "\Template\leaflet.flxr", strReportCategory)
								'接続文字列、SQL文の設定
								C1FlexReport2.DataSource.ConnectionString = strConnectionString
								C1FlexReport2.DataSource.RecordSource = strSQL
								Me.C1FlexViewer2.DocumentSource = C1FlexReport2
								_tabPageManager.ChangeTabPageVisible(iFormType, True)
							Case 2
								'tab03
								Me.tab03.Text = dtFormType.Rows(iFormType)("帳票タイプ")
								'プレビュー表示
								Dim C1FlexReport3 As New C1FlexReport
								Dim strReportCategory As String = "R_" & dtFormType.Rows(iFormType)("帳票タイプ")
								C1FlexReport3.Load(Application.StartupPath & "\Template\leaflet.flxr", strReportCategory)
								'接続文字列、SQL文の設定
								C1FlexReport3.DataSource.ConnectionString = strConnectionString
								C1FlexReport3.DataSource.RecordSource = strSQL
								Me.C1FlexViewer3.DocumentSource = C1FlexReport3
								_tabPageManager.ChangeTabPageVisible(iFormType, True)

							Case 3
								'tab04
								Me.tab04.Text = dtFormType.Rows(iFormType)("帳票タイプ")
								'プレビュー表示
								Dim C1FlexReport4 As New C1FlexReport
								Dim strReportCategory As String = "R_" & dtFormType.Rows(iFormType)("帳票タイプ")
								C1FlexReport4.Load(Application.StartupPath & "\Template\leaflet.flxr", strReportCategory)
								'接続文字列、SQL文の設定
								C1FlexReport4.DataSource.ConnectionString = strConnectionString
								C1FlexReport4.DataSource.RecordSource = strSQL
								Me.C1FlexViewer4.DocumentSource = C1FlexReport4
								_tabPageManager.ChangeTabPageVisible(iFormType, True)

							Case 4
								'tab05
								Me.tab05.Text = dtFormType.Rows(iFormType)("帳票タイプ")
								'プレビュー表示
								Dim C1FlexReport5 As New C1FlexReport
								Dim strReportCategory As String = "R_" & dtFormType.Rows(iFormType)("帳票タイプ")
								C1FlexReport5.Load(Application.StartupPath & "\Template\leaflet.flxr", strReportCategory)
								'接続文字列、SQL文の設定
								C1FlexReport5.DataSource.ConnectionString = strConnectionString
								C1FlexReport5.DataSource.RecordSource = strSQL
								Me.C1FlexViewer5.DocumentSource = C1FlexReport5
								_tabPageManager.ChangeTabPageVisible(iFormType, True)

							Case 5
								'tab06
								Me.tab06.Text = dtFormType.Rows(iFormType)("帳票タイプ")
								'プレビュー表示
								Dim C1FlexReport6 As New C1FlexReport
								Dim strReportCategory As String = "R_" & dtFormType.Rows(iFormType)("帳票タイプ")
								C1FlexReport6.Load(Application.StartupPath & "\Template\leaflet.flxr", strReportCategory)
								'接続文字列、SQL文の設定
								C1FlexReport6.DataSource.ConnectionString = strConnectionString
								C1FlexReport6.DataSource.RecordSource = strSQL
								Me.C1FlexViewer6.DocumentSource = C1FlexReport6
								_tabPageManager.ChangeTabPageVisible(iFormType, True)

							Case 6
								'tab07
								Me.tab07.Text = dtFormType.Rows(iFormType)("帳票タイプ")
								'プレビュー表示
								Dim C1FlexReport7 As New C1FlexReport
								Dim strReportCategory As String = "R_" & dtFormType.Rows(iFormType)("帳票タイプ")
								C1FlexReport7.Load(Application.StartupPath & "\Template\leaflet.flxr", strReportCategory)
								'接続文字列、SQL文の設定
								C1FlexReport7.DataSource.ConnectionString = strConnectionString
								C1FlexReport7.DataSource.RecordSource = strSQL
								Me.C1FlexViewer7.DocumentSource = C1FlexReport7
								_tabPageManager.ChangeTabPageVisible(iFormType, True)

							Case 7
								'tab08
								Me.tab08.Text = dtFormType.Rows(iFormType)("帳票タイプ")
								'プレビュー表示
								Dim C1FlexReport8 As New C1FlexReport
								Dim strReportCategory As String = "R_" & dtFormType.Rows(iFormType)("帳票タイプ")
								C1FlexReport8.Load(Application.StartupPath & "\Template\leaflet.flxr", strReportCategory)
								'接続文字列、SQL文の設定
								C1FlexReport8.DataSource.ConnectionString = strConnectionString
								C1FlexReport8.DataSource.RecordSource = strSQL
								Me.C1FlexViewer8.DocumentSource = C1FlexReport8
								_tabPageManager.ChangeTabPageVisible(iFormType, True)

							Case 8
								'tab09
								Me.tab09.Text = dtFormType.Rows(iFormType)("帳票タイプ")
								'プレビュー表示
								Dim C1FlexReport9 As New C1FlexReport
								Dim strReportCategory As String = "R_" & dtFormType.Rows(iFormType)("帳票タイプ")
								C1FlexReport9.Load(Application.StartupPath & "\Template\leaflet.flxr", strReportCategory)
								'接続文字列、SQL文の設定
								C1FlexReport9.DataSource.ConnectionString = strConnectionString
								C1FlexReport9.DataSource.RecordSource = strSQL
								Me.C1FlexViewer9.DocumentSource = C1FlexReport9
								_tabPageManager.ChangeTabPageVisible(iFormType, True)

						End Select

					Next

			End Select

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & ex.StackTrace)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		Finally

			sqlProcess.Close()

		End Try

	End Sub

#End Region

End Class