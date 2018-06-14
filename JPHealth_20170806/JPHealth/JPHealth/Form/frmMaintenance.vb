Public Class frmMaintenance

#Region "フォームイベント"

	''' <summary>
	''' フォームロード時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub frmMaintenance_Load(sender As Object, e As EventArgs) Handles MyBase.Load

		Me.Text = My.Application.Info.ProductName & " Ver." &
			My.Application.Info.Version.ToString & " - [印刷]"

		Initialize()

	End Sub


#End Region

#Region "オブジェクトイベント"

	''' <summary>
	''' テキストボックスドラッグエンター時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub txt_DragEnter(sender As Object, e As DragEventArgs) Handles txtOfficeCSV.DragEnter, txtBackupFolder.DragEnter

		If e.Data.GetDataPresent(DataFormats.FileDrop) Then
			e.Effect = DragDropEffects.Copy
		Else
			e.Effect = DragDropEffects.None
		End If

	End Sub

	''' <summary>
	''' テキストボックスドラッグドロップ時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub txt_DragDrop(sender As Object, e As DragEventArgs) Handles txtOfficeCSV.DragDrop, txtBackupFolder.DragDrop

		Dim strFiles As String() = CType(e.Data.GetData(DataFormats.FileDrop, False), String())
		Dim txtFile As TextBox = CType(sender, TextBox)

		If System.IO.Directory.Exists(strFiles(0)) Then
			txtFile.Text = strFiles(0)
			Exit Sub
		End If

		If System.IO.File.Exists(strFiles(0)) Then
			txtFile.Text = strFiles(0)
		End If

	End Sub

	''' <summary>
	''' 局所CSVブラウズボタン押下時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub btnOutputFolderBrowse_Click(sender As Object, e As EventArgs) Handles btnOutputFolderBrowse.Click

		Me.txtOfficeCSV.Text = FileBrowse(Me.txtOfficeCSV, "*.csv")

	End Sub

	''' <summary>
	''' 戻るボタン押下時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click

		XmlSettings.LoadFromXmlFile()
		XmlSettings.Instance.OfficeCSV = Me.txtOfficeCSV.Text
		XmlSettings.Instance.BackupFolder = Me.txtBackupFolder.Text
		XmlSettings.SaveToXmlFile()

		BackScreen()

	End Sub

	''' <summary>
	''' 一般タブブラウズボタン押下時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub btnBackupBrowse_Click(sender As Object, e As EventArgs) Handles btnBackupBrowse.Click

		Me.txtBackupFolder.Text = FolderBrowse(Me.txtBackupFolder)

	End Sub

	''' <summary>
	''' バックアップボタン押下時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub btnBackup_Click(sender As Object, e As EventArgs) Handles btnBackup.Click

		If MessageBox.Show("データベースのバックアップ処理を行います" & vbNewLine & "よろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
			Exit Sub
		End If

		Dim sqlProcess As New SQLProcess
		Dim strSQL As String = ""

		Try
			EnableControls(Me, False)
			strSQL = "BACKUP DATABASE JPHealth TO DISK='" & Me.txtBackupFolder.Text & "\" & Date.Now.ToString("yyyyMMdd_HHmmss") & ".bak' WITH INIT"
			Dim str As Object = sqlProcess.DB_EXECUTE_SCALAR(strSQL)

			MessageBox.Show("バックアップ処理が終了しました", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information)
			EnableControls(Me, True)

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		Finally

			sqlProcess.Close()

		End Try

	End Sub

#End Region

#Region "プライベートメソッド"

	''' <summary>
	''' メインメニューへ戻る
	''' </summary>
	Private Sub BackScreen()

		Dim f As New frmMainMenu
		m_Context.SetNextContext(f)

	End Sub

	''' <summary>
	''' 初期化処理
	''' </summary>
	Private Sub Initialize()

		CaptionDisplayMode = StatusDisplayMode.None

		XmlSettings.LoadFromXmlFile()
		Me.txtOfficeCSV.Text = XmlSettings.Instance.OfficeCSV
		Me.txtBackupFolder.Text = XmlSettings.Instance.BackupFolder

		'各グリッドの表示
		SearchOffice()
		SearchFacility()
		SearchMedicalEx()
		SearchWeight()
		SearchWeightHeader()
		SearchHoliday()
		SearchFormEx()
		SearchLot()

	End Sub

	''' <summary>
	''' 局所マスタ表示
	''' </summary>
	Private Sub SearchOffice()

		Dim sqlProcess As New SQLProcess
		Dim strSQL As String = ""
		Dim dt As DataTable = Nothing
		Dim iRecordCount As Integer = 0

		Try
			'==================================================
			'局所マスタ
			'==================================================
			strSQL = "SELECT 会社コード, 会社名, 局所コード, 局所名, 郵便番号, 住所, 電話番号, 健康管理施設コード, "
			strSQL &= "健康管理施設名, 会場局コード, 会場局名 "
			strSQL &= "FROM M_局所 "
			strSQL &= "ORDER BY 会社コード, 局所コード"
			dt = sqlProcess.DB_SELECT_DATATABLE(strSQL)
			iRecordCount = 0
			Me.C1FGridOffice.BeginUpdate()
			For iRow As Integer = 0 To dt.Rows.Count - 1
				iRecordCount += 1
				Me.C1FGridOffice.Rows.Count = iRecordCount + 1
				Me.C1FGridOffice(iRecordCount, "No") = iRecordCount
				Me.C1FGridOffice(iRecordCount, "会社コード") = dt.Rows(iRow)("会社コード")
				Me.C1FGridOffice(iRecordCount, "会社名") = dt.Rows(iRow)("会社名")
				Me.C1FGridOffice(iRecordCount, "局所コード") = dt.Rows(iRow)("局所コード")
				Me.C1FGridOffice(iRecordCount, "局所名") = dt.Rows(iRow)("局所名")
				Me.C1FGridOffice(iRecordCount, "郵便番号") = dt.Rows(iRow)("郵便番号")
				Me.C1FGridOffice(iRecordCount, "住所") = dt.Rows(iRow)("住所")
				Me.C1FGridOffice(iRecordCount, "電話番号") = dt.Rows(iRow)("電話番号")
				Me.C1FGridOffice(iRecordCount, "健康管理施設コード") = dt.Rows(iRow)("健康管理施設コード")
				Me.C1FGridOffice(iRecordCount, "健康管理施設名") = dt.Rows(iRow)("健康管理施設名")
				Me.C1FGridOffice(iRecordCount, "会場局コード") = dt.Rows(iRow)("会場局コード")
				Me.C1FGridOffice(iRecordCount, "会場局名") = dt.Rows(iRow)("会場局名")
			Next
			Me.C1FGridOffice.EndUpdate()
			'==================================================
			'除外リスト
			'==================================================
			strSQL = "SELECT ID, 対象種別, 対象項目, 入力値 "
			strSQL &= "FROM M_除外リスト "
			strSQL &= "ORDER BY ID"
			dt = sqlProcess.DB_SELECT_DATATABLE(strSQL)
			iRecordCount = 0
			Me.C1FGridExclusion.BeginUpdate()
			For iRow As Integer = 0 To dt.Rows.Count - 1
				iRecordCount += 1
				Me.C1FGridExclusion.Rows.Count = iRecordCount + 1
				Me.C1FGridExclusion(iRecordCount, "No") = iRecordCount
				Me.C1FGridExclusion(iRecordCount, "ID") = dt.Rows(iRow)("ID")
				Me.C1FGridExclusion(iRecordCount, "対象種別") = dt.Rows(iRow)("対象種別")
				Me.C1FGridExclusion(iRecordCount, "対象項目") = dt.Rows(iRow)("対象項目")
				Me.C1FGridExclusion(iRecordCount, "入力値") = dt.Rows(iRow)("入力値")
			Next
			Me.C1FGridExclusion.EndUpdate()

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		Finally

			sqlProcess.Close()

		End Try

	End Sub

	''' <summary>
	''' 健康管理施設マスタ表示
	''' </summary>
	Private Sub SearchFacility()

		Dim sqlProcess As New SQLProcess
		Dim strSQL As String = ""
		Dim dt As DataTable = Nothing
		Dim iRecordCount As Integer = 0

		Try
			strSQL = "SELECT 健康管理施設コード, 健康管理施設名, 略称, 郵便番号, 住所, 電話番号 "
			strSQL &= "FROM M_健康管理施設 "
			strSQL &= "ORDER BY 健康管理施設コード"
			dt = sqlProcess.DB_SELECT_DATATABLE(strSQL)

			Me.C1FGridFacility.BeginUpdate()
			For iRow As Integer = 0 To dt.Rows.Count - 1
				iRecordCount += 1
				Me.C1FGridFacility.Rows.Count = iRecordCount + 1
				Me.C1FGridFacility(iRecordCount, "No") = iRecordCount
				Me.C1FGridFacility(iRecordCount, "健康管理施設コード") = dt.Rows(iRow)("健康管理施設コード")
				Me.C1FGridFacility(iRecordCount, "健康管理施設名") = dt.Rows(iRow)("健康管理施設名")
				Me.C1FGridFacility(iRecordCount, "略称") = dt.Rows(iRow)("略称")
				Me.C1FGridFacility(iRecordCount, "郵便番号") = dt.Rows(iRow)("郵便番号")
				Me.C1FGridFacility(iRecordCount, "住所") = dt.Rows(iRow)("住所")
				Me.C1FGridFacility(iRecordCount, "電話番号") = dt.Rows(iRow)("電話番号")
			Next
			Me.C1FGridFacility.EndUpdate()

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		Finally

			sqlProcess.Close()

		End Try

	End Sub

	''' <summary>
	''' 健診種別、帳票タイプ
	''' </summary>
	Private Sub SearchMedicalEx()

		Dim sqlProcess As New SQLProcess
		Dim strSQL As String = ""
		Dim dt As DataTable = Nothing
		Dim iRecordCount As Integer = 0

		Try
			'==================================================
			'健診種別
			'==================================================
			strSQL = "SELECT 健診種別ID, 健診種別, 変換健診種別 "
			strSQL &= "FROM M_健診種別 "
			strSQL &= "ORDER BY 健診種別ID"
			dt = sqlProcess.DB_SELECT_DATATABLE(strSQL)

			iRecordCount = 0
			Me.C1FGridMedicalEx.BeginUpdate()
			For iRow As Integer = 0 To dt.Rows.Count - 1
				iRecordCount += 1
				Me.C1FGridMedicalEx.Rows.Count = iRecordCount + 1
				Me.C1FGridMedicalEx(iRecordCount, "No") = iRecordCount
				Me.C1FGridMedicalEx(iRecordCount, "健診種別ID") = dt.Rows(iRow)("健診種別ID")
				Me.C1FGridMedicalEx(iRecordCount, "健診種別") = dt.Rows(iRow)("健診種別")
				Me.C1FGridMedicalEx(iRecordCount, "変換健診種別") = dt.Rows(iRow)("変換健診種別")
			Next
			Me.C1FGridMedicalEx.EndUpdate()

			'==================================================
			'帳票タイプ
			'==================================================
			strSQL = "SELECT ID, 帳票タイプ, 変換帳票タイプ "
			strSQL &= "FROM M_帳票タイプ "
			strSQL &= "ORDER BY ID"
			dt = sqlProcess.DB_SELECT_DATATABLE(strSQL)

			iRecordCount = 0
			Me.C1FGridFormType.BeginUpdate()
			For iRow As Integer = 0 To dt.Rows.Count - 1
				iRecordCount += 1
				Me.C1FGridFormType.Rows.Count = iRecordCount + 1
				Me.C1FGridFormType(iRecordCount, "No") = iRecordCount
				Me.C1FGridFormType(iRecordCount, "ID") = dt.Rows(iRow)("ID")
				Me.C1FGridFormType(iRecordCount, "帳票タイプ") = dt.Rows(iRow)("帳票タイプ")
				Me.C1FGridFormType(iRecordCount, "変換帳票タイプ") = dt.Rows(iRow)("変換帳票タイプ")
			Next
			Me.C1FGridFormType.EndUpdate()

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		Finally

			sqlProcess.Close()

		End Try

	End Sub

	''' <summary>
	''' 重量マスタ表示
	''' </summary>
	Private Sub SearchWeight()

		Dim sqlProcess As New SQLProcess
		Dim strSQL As String = ""
		Dim dt As DataTable = Nothing
		Dim iRecordCount As Integer = 0

		Try
			strSQL = "SELECT 重量ID, 帳票種別ID, 帳票種別詳細, 名称, 枚数, 重量, 備考 "
			strSQL &= "FROM M_重量 "
			strSQL &= "ORDER BY 重量ID"
			dt = sqlProcess.DB_SELECT_DATATABLE(strSQL)

			iRecordCount = 0
			Me.C1FGridWeight.BeginUpdate()
			For iRow As Integer = 0 To dt.Rows.Count - 1
				iRecordCount += 1
				Me.C1FGridWeight.Rows.Count = iRecordCount + 1
				Me.C1FGridWeight(iRecordCount, "No") = iRecordCount
				Me.C1FGridWeight(iRecordCount, "重量ID") = dt.Rows(iRow)("重量ID")
				Me.C1FGridWeight(iRecordCount, "帳票種別ID") = dt.Rows(iRow)("帳票種別ID")
				Me.C1FGridWeight(iRecordCount, "帳票種別詳細") = dt.Rows(iRow)("帳票種別詳細")
				Me.C1FGridWeight(iRecordCount, "名称") = dt.Rows(iRow)("名称")
				Me.C1FGridWeight(iRecordCount, "枚数") = dt.Rows(iRow)("枚数")
				Me.C1FGridWeight(iRecordCount, "重量") = dt.Rows(iRow)("重量")
				Me.C1FGridWeight(iRecordCount, "備考") = dt.Rows(iRow)("備考")
			Next
			Me.C1FGridWeight.EndUpdate()

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		Finally

			sqlProcess.Close()

		End Try

	End Sub

	''' <summary>
	''' 重量ヘッダマスタ表示
	''' </summary>
	Private Sub SearchWeightHeader()

		Dim sqlProcess As New SQLProcess
		Dim strSQL As String = ""
		Dim dt As DataTable = Nothing
		Dim iRecordCount As Integer = 0

		Try
			strSQL = "SELECT 重量ヘッダ, 郵便物の種類, 特殊取扱書類, 重量, 郵送, 特定記録, 総重量, "
			strSQL &= "重量FROM, 重量TO, 封筒種別, 規格, 備考 "
			strSQL &= "FROM M_重量ヘッダ "
			strSQL &= "ORDER BY 重量ヘッダ"
			dt = sqlProcess.DB_SELECT_DATATABLE(strSQL)

			iRecordCount = 0
			Me.C1FGridWeightHeader.BeginUpdate()
			For iRow As Integer = 0 To dt.Rows.Count - 1
				iRecordCount += 1
				Me.C1FGridWeightHeader.Rows.Count = iRecordCount + 1
				Me.C1FGridWeightHeader(iRecordCount, "No") = iRecordCount
				Me.C1FGridWeightHeader(iRecordCount, "重量ヘッダ") = dt.Rows(iRow)("重量ヘッダ")
				Me.C1FGridWeightHeader(iRecordCount, "郵便物の種類") = dt.Rows(iRow)("郵便物の種類")
				Me.C1FGridWeightHeader(iRecordCount, "特殊取扱書類") = dt.Rows(iRow)("特殊取扱書類")
				Me.C1FGridWeightHeader(iRecordCount, "重量") = dt.Rows(iRow)("重量")
				Me.C1FGridWeightHeader(iRecordCount, "郵送") = dt.Rows(iRow)("郵送")
				Me.C1FGridWeightHeader(iRecordCount, "特定記録") = dt.Rows(iRow)("特定記録")
				Me.C1FGridWeightHeader(iRecordCount, "総重量") = dt.Rows(iRow)("総重量")
				Me.C1FGridWeightHeader(iRecordCount, "重量FROM") = dt.Rows(iRow)("重量FROM")
				Me.C1FGridWeightHeader(iRecordCount, "重量TO") = dt.Rows(iRow)("重量TO")
				Me.C1FGridWeightHeader(iRecordCount, "封筒種別") = dt.Rows(iRow)("封筒種別")
				Me.C1FGridWeightHeader(iRecordCount, "規格") = dt.Rows(iRow)("規格")
				Me.C1FGridWeightHeader(iRecordCount, "備考") = dt.Rows(iRow)("備考")
			Next
			Me.C1FGridWeightHeader.EndUpdate()

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		Finally

			sqlProcess.Close()

		End Try

	End Sub

	''' <summary>
	''' 祝日マスタ表示
	''' </summary>
	Private Sub SearchHoliday()

		Dim sqlProcess As New SQLProcess
		Dim strSQL As String = ""
		Dim dt As DataTable = Nothing
		Dim iRecordCount As Integer = 0

		Try
			strSQL = "SELECT 祝日, 備考 "
			strSQL &= "FROM M_祝日 "
			strSQL &= "ORDER BY 祝日"
			dt = sqlProcess.DB_SELECT_DATATABLE(strSQL)

			iRecordCount = 0
			Me.C1FGridHoliday.BeginUpdate()
			For iRow As Integer = 0 To dt.Rows.Count - 1
				iRecordCount += 1
				Me.C1FGridHoliday.Rows.Count = iRecordCount + 1
				Me.C1FGridHoliday(iRecordCount, "No") = iRecordCount
				Me.C1FGridHoliday(iRecordCount, "祝日") = dt.Rows(iRow)("祝日")
				Me.C1FGridHoliday(iRecordCount, "備考") = dt.Rows(iRow)("備考")
			Next
			Me.C1FGridHoliday.EndUpdate()

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		Finally

			sqlProcess.Close()

		End Try

	End Sub

	''' <summary>
	''' 帳票種別マスタ表示
	''' </summary>
	Private Sub SearchFormEx()

		Dim sqlProcess As New SQLProcess
		Dim strSQL As String = ""
		Dim dt As DataTable = Nothing
		Dim iRecordCount As Integer = 0

		Try
			strSQL = "SELECT 帳票種別ID, 帳票種別, 備考 "
			strSQL &= "FROM M_帳票種別 "
			strSQL &= "ORDER BY 帳票種別ID"
			dt = sqlProcess.DB_SELECT_DATATABLE(strSQL)

			iRecordCount = 0
			Me.C1FGridFormEx.BeginUpdate()
			For iRow As Integer = 0 To dt.Rows.Count - 1
				iRecordCount += 1
				Me.C1FGridFormEx.Rows.Count = iRecordCount + 1
				Me.C1FGridFormEx(iRecordCount, "No") = iRecordCount
				Me.C1FGridFormEx(iRecordCount, "帳票種別ID") = dt.Rows(iRow)("帳票種別ID")
				Me.C1FGridFormEx(iRecordCount, "帳票種別") = dt.Rows(iRow)("帳票種別")
				Me.C1FGridFormEx(iRecordCount, "備考") = dt.Rows(iRow)("備考")
			Next
			Me.C1FGridFormEx.EndUpdate()

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		Finally

			sqlProcess.Close()

		End Try

	End Sub

	''' <summary>
	''' ロットマスタ表示
	''' </summary>
	Private Sub SearchLot()

		Dim sqlProcess As New SQLProcess
		Dim strSQL As String = ""
		Dim dt As DataTable = Nothing
		Dim iRecordCount As Integer = 0

		Try
			strSQL = "SELECT 削除フラグ, ロットID, 発送日, 判定票CSV, リーフレットCSV, "
			strSQL &= "CASE WHEN ISNULL(インポート日時, '') = '1900/01/01' THEN '' ELSE インポート日時 END AS インポート日時, "
			strSQL &= "CASE WHEN ISNULL(出力日時_対象者一覧, '') = '1900/01/01' THEN '' ELSE 出力日時_対象者一覧 END AS 出力日時_対象者一覧, "
			strSQL &= "CASE WHEN ISNULL(出力日時_事業所一覧, '') = '1900/01/01' THEN '' ELSE 出力日時_事業所一覧 END AS 出力日時_事業所一覧, "
			strSQL &= "CASE WHEN ISNULL(出力日時_施設別件数, '') = '1900/01/01' THEN '' ELSE 出力日時_施設別件数 END AS 出力日時_施設別件数, "
			strSQL &= "CASE WHEN ISNULL(出力日時_後納票, '') = '1900/01/01' THEN '' ELSE 出力日時_後納票 END AS 出力日時_後納票 "
			strSQL &= "FROM T_ロット管理 "
			strSQL &= "ORDER BY ロットID DESC"
			dt = sqlProcess.DB_SELECT_DATATABLE(strSQL)

			iRecordCount = 0
			Me.C1FGridLotManage.BeginUpdate()
			For iRow As Integer = 0 To dt.Rows.Count - 1
				iRecordCount += 1
				Me.C1FGridLotManage.Rows.Count = iRecordCount + 1
				Me.C1FGridLotManage(iRecordCount, "No") = iRecordCount
				If dt.Rows(iRow)("削除フラグ") = 0 Then
					Me.C1FGridLotManage(iRecordCount, "削除フラグ") = False
				Else
					Me.C1FGridLotManage(iRecordCount, "削除フラグ") = True
				End If
				Me.C1FGridLotManage(iRecordCount, "ロットID") = dt.Rows(iRow)("ロットID")
				Me.C1FGridLotManage(iRecordCount, "発送日") = CDate(dt.Rows(iRow)("発送日")).ToString("yyyy/MM/dd")
				Me.C1FGridLotManage(iRecordCount, "判定票CSV") = dt.Rows(iRow)("判定票CSV")
				Me.C1FGridLotManage(iRecordCount, "リーフレットCSV") = dt.Rows(iRow)("リーフレットCSV")
				Me.C1FGridLotManage(iRecordCount, "インポート日時") = IIf(dt.Rows(iRow)("インポート日時") = "1900/01/01", "", dt.Rows(iRow)("インポート日時"))
				Me.C1FGridLotManage(iRecordCount, "対象者一覧出力") = IIf(dt.Rows(iRow)("出力日時_対象者一覧") = "1900/01/01", "", dt.Rows(iRow)("出力日時_対象者一覧"))
				Me.C1FGridLotManage(iRecordCount, "事業所一覧出力") = IIf(dt.Rows(iRow)("出力日時_事業所一覧") = "1900/01/01", "", dt.Rows(iRow)("出力日時_事業所一覧"))
				Me.C1FGridLotManage(iRecordCount, "施設別件数出力") = IIf(dt.Rows(iRow)("出力日時_施設別件数") = "1900/01/01", "", dt.Rows(iRow)("出力日時_施設別件数"))
				Me.C1FGridLotManage(iRecordCount, "後納票出力") = IIf(dt.Rows(iRow)("出力日時_後納票") = "1900/01/01", "", dt.Rows(iRow)("出力日時_後納票"))
			Next
			Me.C1FGridLotManage.EndUpdate()

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		Finally

			sqlProcess.Close()

		End Try

	End Sub

#End Region

End Class