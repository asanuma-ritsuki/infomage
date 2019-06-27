Imports ClosedXML.Excel

Public Class frmCheckupManage

#Region "フォームイベント"

    ''' <summary>
    ''' フォームロード時
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub frmCheckupManage_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.Text = My.Application.Info.ProductName & " Ver." &
            My.Application.Info.Version.ToString & " - [判定票管理]"

        Initialize()

    End Sub

#End Region

#Region "オブジェクトイベント"

    ''' <summary>
    ''' ロットコンボボックスインデックス変更時
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub cmbLotID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbLotID.SelectedIndexChanged

        SearchLotInfo()

    End Sub

    ''' <summary>
    ''' 戻るボタン押下時
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click

        BackScreen()

    End Sub

    ''' <summary>
    ''' 印刷ボタン押下時
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click

        '2017/11/07
        '重量ヘッダ単位件数グリッドが１レコードもない場合は印刷ボタンを押せないようにする
        If Me.C1FGridHeader.Rows.Count = 1 Then
            MessageBox.Show("該当ロットは印刷準備処理を行っていません" & vbNewLine & "ロットID：" & Me.cmbLotID.SelectedValue, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        '印刷画面を閉じたときに選択していたロットIDを復元する
        Dim strLotID As String = Me.cmbLotID.SelectedValue
        Dim f As New frmPrint
        f.LotID = Me.cmbLotID.SelectedValue
        f.ShowDialog()
        'SearchGrid()
        UpdateImportDate()
        Me.cmbLotID.SelectedValue = strLotID
        'SearchGrid(Me.cmbLotID.SelectedValue)
        'SearchGridWeight(Me.cmbLotID.SelectedValue)
        'SearchGridDefect(Me.cmbLotID.SelectedValue)
        'SearchLotInfo()

    End Sub

    ''' <summary>
    ''' インポートボタン押下時
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnImport_Click(sender As Object, e As EventArgs) Handles btnImport.Click

        'インポート画面を閉じたときに選択していたロットIDを復元する
        Dim strLotID As String = Me.cmbLotID.SelectedValue
        Dim f As New frmImport
        f.LotID = Me.cmbLotID.SelectedValue
        f.ShowDialog()
        'SearchGrid()
        UpdateImportDate()
        Me.cmbLotID.SelectedValue = strLotID
        'SearchGrid(Me.cmbLotID.SelectedValue)
        'SearchGridWeight(Me.cmbLotID.SelectedValue)
        'SearchGridDefect(Me.cmbLotID.SelectedValue)
        'SearchLotInfo()

    End Sub

    ''' <summary>
    ''' 発送日更新ボタン押下時
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnSendDateUpdate_Click(sender As Object, e As EventArgs) Handles btnSendDateUpdate.Click

        Dim dtSendDate As Date = Me.dtpSendDate.Value
        Dim iDiff As Integer = DateDiff(DateInterval.Day, Date.Today, dtSendDate)

        If iDiff < 0 Then
            '本日より前の発送日を指定した場合はエラーとする
            MessageBox.Show("発送日には過去の日付を設定できません", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Dim sqlProcess As New SQLProcess
        Dim strSQL As String = ""

        Try
            '今現在の発送日を取得
            strSQL = "SELECT 発送日 FROM T_ロット管理 "
            strSQL &= "WHERE ロットID = '" & Me.cmbLotID.SelectedValue & "'"
            Dim dtOldSendDate As Date = CDate(sqlProcess.DB_EXECUTE_SCALAR(strSQL))
            '新旧の発送日が同一だった場合何もしない
            iDiff = DateDiff(DateInterval.Day, dtOldSendDate, Me.dtpSendDate.Value)
            If iDiff = 0 Then
                '同日だった
                Exit Sub
            Else
                If MessageBox.Show("発送日を指定された日付に更新します" & vbNewLine & "[" & dtOldSendDate & "] → [" & Me.dtpSendDate.Value & "]" & vbNewLine & "よろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                    Exit Sub
                End If
                'UPDATE
                strSQL = "UPDATE T_ロット管理 SET 発送日 = '" & Me.dtpSendDate.Value & "' "
                strSQL &= "WHERE ロットID = '" & Me.cmbLotID.SelectedValue & "'"
                sqlProcess.DB_UPDATE(strSQL)

                MessageBox.Show("発送日を更新しました" & vbNewLine & "[" & Me.dtpSendDate.Value & "]", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If

        Catch ex As Exception

            Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & ex.StackTrace)
            MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally

            sqlProcess.Close()

        End Try


    End Sub

    ''' <summary>
    ''' 帳票出力ボタン押下時
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnListOutput_Click(sender As Object, e As EventArgs) Handles btnListOutput.Click

        If Not System.IO.Directory.Exists(Me.txtOutputFolder.Text) Then
            MessageBox.Show("存在する出力フォルダを指定してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        UpdateProgress()
        '後納票にチェックが入っている場合、QRチェックがすべて終わっているか確認する
        If Me.chkSuccessDate.Checked Then
			If Not Me.ProgressBar1.Value = Me.ProgressBar1.Maximum Or Not Me.ProgressBar2.Value = Me.ProgressBar2.Maximum Then
				'最大値と現在値が同一でなかった場合、チェック未了のため出力できないようにする
				MessageBox.Show("QRチェックがすべて完了していないため後納票は出力できません" & vbNewLine & "後納票出力のチェックを外して他の帳票を出力してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
				Exit Sub
			End If
		End If

        'チェックボックスがすべてオフの場合はエラーとする
        If Not Me.chkTargetListDate.Checked And Not Me.chkOfficeListDate.Checked And
                Not Me.chkFacilityCountDate.Checked And Not chkSuccessDate.Checked Then
            MessageBox.Show("出力する帳票のチェックボックスにチェックをしてください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Dim strMessage As String = "チェックした帳票を出力します" & vbNewLine & vbNewLine
        strMessage &= IIf(Me.chkTargetListDate.Checked, "対象者一覧" & vbNewLine, "")
        strMessage &= IIf(Me.chkOfficeListDate.Checked, "事業所一覧" & vbNewLine, "")
        strMessage &= IIf(Me.chkFacilityCountDate.Checked, "施設別件数" & vbNewLine, "")
        strMessage &= IIf(Me.chkSuccessDate.Checked, "後納票" & vbNewLine, "")
        strMessage &= "よろしいですか？"
        If MessageBox.Show(strMessage, "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
            Exit Sub
        End If

        XmlSettings.LoadFromXmlFile()
        XmlSettings.Instance.VariousOutputFolder = Me.txtOutputFolder.Text
        XmlSettings.SaveToXmlFile()

        Dim sqlProcess As New SQLProcess
        Dim strSQL As String = ""
        Dim strSaveFile As String = ""
        Dim strSaveFolder As String = ""

        Dim strOutputFolder As String = Me.txtOutputFolder.Text & "\" & Me.dtpSendDate.Value.ToString("yyyyMMdd")
        If Not System.IO.Directory.Exists(strOutputFolder) Then
            '発送日フォルダが存在しなかった場合作成する
            My.Computer.FileSystem.CreateDirectory(strOutputFolder)
        End If

        EnableControls(Me, False)

        Try
            '==================================================
            '対象者一覧
            '==================================================
            If Me.chkTargetListDate.Checked Then
                '該当の健康管理施設コードを列挙する
                strSQL = "SELECT T2.健康管理施設コード, T3.略称 "
                strSQL &= "FROM T_判定票管理 AS T1 INNER JOIN "
                strSQL &= "M_局所 AS T2 ON T1.会社コード = T2.会社コード "
                strSQL &= "AND T1.所属事業所コード = T2.局所コード INNER JOIN "
                strSQL &= "M_健康管理施設 AS T3 ON T2.健康管理施設コード = T3.健康管理施設コード "
                strSQL &= "WHERE ロットID = '" & Me.cmbLotID.SelectedValue & "' "
                strSQL &= "GROUP BY T2.健康管理施設コード, T3.略称 "
                strSQL &= "ORDER BY T2.健康管理施設コード"
                Dim dt As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)

                For iRow As Integer = 0 To dt.Rows.Count - 1
                    '1健康管理施設で回す
                    strSQL = "SELECT ROW_NUMBER() OVER (PARTITION BY T3.健康管理施設コード "
                    strSQL &= "ORDER BY T1.会社コード, T1.所属事業所コード, "
                    strSQL &= "CASE WHEN ISNULL(T1.所属部名, '') = '' THEN 1 ELSE 0 END, "
                    strSQL &= "T1.所属部名, "
                    strSQL &= "CASE WHEN ISNULL(T1.所属課名, '') = '' THEN 1 ELSE 0 END, "
                    strSQL &= "T1.所属課名, T1.社員コード) AS 連番, "
                    strSQL &= "T1.社員コード, T2.氏名, T1.会社コード, T2.会社, T2.所属事業所 AS 局所名, "
                    strSQL &= "T1.所属部名 AS 所属部, T1.所属課名 AS 所属課, "
                    strSQL &= "ISNULL(T4.帳票タイプ, '') AS リーフレット該当項目 "
                    strSQL &= "FROM T_判定票管理 AS T1 INNER JOIN "
                    strSQL &= "T_判定票印刷 AS T2 ON T1.ロットID = T2.ロットID AND T1.レコード番号 = T2.レコード番号 INNER JOIN "
                    strSQL &= "M_局所 AS T3 ON T1.会社コード = T3.会社コード AND T1.所属事業所コード = T3.局所コード LEFT OUTER JOIN "
                    strSQL &= "T_保健指導名簿印刷 AS T4 ON T1.ロットID = T4.ロットID AND T1.レコード番号 = T4.レコード番号 "
                    strSQL &= "WHERE T1.ロットID = '" & Me.cmbLotID.SelectedValue & "' "
                    strSQL &= "AND T3.健康管理施設コード = '" & dt.Rows(iRow)("健康管理施設コード") & "' "
                    strSQL &= "ORDER BY T1.会社コード, T1.所属事業所コード, "
                    strSQL &= "CASE WHEN ISNULL(T1.所属部名, '') = '' THEN 1 ELSE 0 END, "
                    strSQL &= "T1.所属部名, "
                    strSQL &= "CASE WHEN ISNULL(T1.所属課名, '') = '' THEN 1 ELSE 0 END, "
                    strSQL &= "T1.所属課名, T1.社員コード "
                    Dim dtFacility As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)

                    strSaveFile = dt.Rows(iRow)("略称") & "_就業判定票 対象者一覧_" & Me.dtpSendDate.Value.ToString("yyyyMMdd") & ".xlsx"
                    strSaveFolder = strOutputFolder & "\就業判定票 対象者一覧"
                    If Not System.IO.Directory.Exists(strSaveFolder) Then
                        My.Computer.FileSystem.CreateDirectory(strSaveFolder)
                    End If
                    ExcelProcess.WriteExcelFile(ExcelOutputCategory.CheckupTargetList, strSaveFolder & "\" & strSaveFile, dtFacility, "発送日：" & Me.dtpSendDate.Value.ToString("yyyy年M月d日"))
                    SetPassword(strSaveFolder & "\" & strSaveFile, XmlSettings.Instance.ExcelPassword)
                Next
                '出力日時の更新
                strSQL = "UPDATE T_ロット管理 "
                strSQL &= "SET 出力日時_対象者一覧 = '" & Date.Now.ToString("yyyy/MM/dd HH:mm:ss") & "' "
                strSQL &= "WHERE ロットID = '" & Me.cmbLotID.SelectedValue & "'"
                sqlProcess.DB_UPDATE(strSQL)

            End If

            '==================================================
            '発送先事業所一覧
            '==================================================
            If Me.chkOfficeListDate.Checked Then

                strSQL = "SELECT ROW_NUMBER() OVER (PARTITION BY 1 "
                strSQL &= "ORDER BY A1.健康管理施設コード, A1.会場局コード, A1.会社コード) AS 連番, "
                strSQL &= "A1.会社名, A1.局所名, A1.会社コード, A1.局所コード, A1.郵便番号, A1.住所, A1.件数, "
                strSQL &= "COUNT(A1.会社名) AS 郵便物の個数, A1.会場局名 AS 所属会場局, A1.健康管理施設名 AS 担当健康管理施設 "
                strSQL &= "FROM (SELECT T1.ロットID, T2.会社名, T2.局所名, T1.会社コード, T1.所属事業所コード AS 局所コード, "
                strSQL &= "T1.印刷ID, T2.郵便番号, T2.住所, COUNT(T1.所属事業所コード) AS 件数, "
                strSQL &= "T2.会場局コード, T2.会場局名, T2.健康管理施設コード, T2.健康管理施設名 "
                strSQL &= "FROM T_印刷管理 AS T1 INNER JOIN "
                strSQL &= "M_局所 AS T2 ON T1.会社コード = T2.会社コード AND T1.所属事業所コード = T2.局所コード INNER JOIN "
                strSQL &= "M_健康管理施設 AS T3 ON T2.健康管理施設コード = T3.健康管理施設コード INNER JOIN "
                strSQL &= "T_判定票管理 AS T4 ON T1.ロットID = T4.ロットID AND T1.会社コード = T4.会社コード AND T1.所属事業所コード = T4.所属事業所コード "
                strSQL &= "WHERE T1.ロットID = '" & Me.cmbLotID.SelectedValue & "' "
                strSQL &= "GROUP BY T1.ロットID, T1.会社コード, T1.所属事業所コード, T1.印刷ID, T2.会社名, T2.局所名, "
                strSQL &= "T2.郵便番号, T2.住所, T2.会場局コード, T2.会場局名, T2.健康管理施設コード, T2.健康管理施設名 "
                strSQL &= ") AS A1 "
                strSQL &= "WHERE A1.ロットID = '" & Me.cmbLotID.SelectedValue & "' "
                strSQL &= "GROUP BY A1.ロットID, A1.会社名, A1.局所名, A1.会社コード, A1.局所コード, "
                strSQL &= "A1.郵便番号, A1.住所, A1.件数, A1.会場局コード, A1.会場局名, "
                strSQL &= "A1.健康管理施設コード, A1.健康管理施設名 "
                strSQL &= "ORDER BY A1.健康管理施設コード, A1.会場局コード, A1.会社コード, A1.局所コード"
                Dim dtOffice As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)

                strSaveFile = "発送先事業所一覧_" & Me.dtpSendDate.Value.ToString("yyyyMMdd") & ".xlsx"
                strSaveFolder = strOutputFolder & "\発送先事業所一覧"
                If Not System.IO.Directory.Exists(strSaveFolder) Then
                    My.Computer.FileSystem.CreateDirectory(strSaveFolder)
                End If
                ExcelProcess.WriteExcelFile(ExcelOutputCategory.OfficeList, strSaveFolder & "\" & strSaveFile, dtOffice, "発送日：" & Me.dtpSendDate.Value.ToString("yyyy年M月d日"))
                SetPassword(strSaveFolder & "\" & strSaveFile, XmlSettings.Instance.ExcelPassword)

                '出力日時の更新
                strSQL = "UPDATE T_ロット管理 "
                strSQL &= "SET 出力日時_事業所一覧 = '" & Date.Now.ToString("yyyy/MM/dd HH:mm:ss") & "' "
                strSQL &= "WHERE ロットID = '" & Me.cmbLotID.SelectedValue & "'"
                sqlProcess.DB_UPDATE(strSQL)

            End If

            '==================================================
            '就業判定票 施設別件数
            '==================================================
            If Me.chkFacilityCountDate.Checked Then
                strSQL = "SELECT ROW_NUMBER() OVER (PARTITION BY 1 "
                strSQL &= "ORDER BY T2.健康管理施設コード) AS 連番, "
                strSQL &= "T2.健康管理施設コード, T3.健康管理施設名, T3.略称, COUNT(*) AS 件数 "
                strSQL &= "FROM T_判定票管理 AS T1 INNER JOIN "
                strSQL &= "M_局所 AS T2 ON T1.会社コード = T2.会社コード "
                strSQL &= "AND T1.所属事業所コード = T2.局所コード INNER JOIN "
                strSQL &= "M_健康管理施設 AS T3 ON T2.健康管理施設コード = T3.健康管理施設コード "
                strSQL &= "WHERE ロットID = '" & Me.cmbLotID.SelectedValue & "' "
                strSQL &= "GROUP BY T2.健康管理施設コード, T3.健康管理施設名, T3.略称 "
                strSQL &= "ORDER BY T2.健康管理施設コード"
                Dim dtFacility As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)

                strSaveFile = "就業判定票_健康管理施設別件数_" & Me.dtpSendDate.Value.ToString("yyyyMMdd") & ".xlsx"
                strSaveFolder = strOutputFolder & "\健康管理施設別件数"
                If Not System.IO.Directory.Exists(strSaveFolder) Then
                    My.Computer.FileSystem.CreateDirectory(strSaveFolder)
                End If
                ExcelProcess.WriteExcelFile(ExcelOutputCategory.FacilityCount, strSaveFolder & "\" & strSaveFile, dtFacility, "発送日：" & Me.dtpSendDate.Value.ToString("yyyy年M月d日"))
                SetPassword(strSaveFolder & "\" & strSaveFile, XmlSettings.Instance.ExcelPassword)

                '出力日時の更新
                strSQL = "UPDATE T_ロット管理 "
                strSQL &= "SET 出力日時_施設別件数 = '" & Date.Now.ToString("yyyy/MM/dd HH:mm:ss") & "' "
                strSQL &= "WHERE ロットID = '" & Me.cmbLotID.SelectedValue & "'"
                sqlProcess.DB_UPDATE(strSQL)

            End If

            '==================================================
            '後納票
            '==================================================
            If Me.chkSuccessDate.Checked Then
                '後納票シート
                strSQL = "SELECT T2.重量ヘッダ, T2.郵便物の種類, T2.特殊取扱書類, T2.重量, "
                strSQL &= "COUNT(T1.重量ヘッダ) AS 差出通数, "
                strSQL &= "T2.郵送 + T2.特定記録 AS 一通の料金, "
                strSQL &= "COUNT(T1.重量ヘッダ) * (T2.郵送 + T2.特定記録) AS 合計金額, "
                strSQL &= "T2.規格 AS 備考 "
                strSQL &= "FROM T_印刷管理 AS T1 INNER JOIN "
                strSQL &= "M_重量ヘッダ AS T2 ON T1.重量ヘッダ = T2.重量ヘッダ "
                strSQL &= "WHERE T1.ロットID = '" & Me.cmbLotID.SelectedValue & "' "
                strSQL &= "GROUP BY T2.重量ヘッダ, T2.郵便物の種類, T2.特殊取扱書類, T2.重量, "
                strSQL &= "T2.郵送, T2.特定記録, T2.規格 "
                strSQL &= "ORDER BY T2.重量ヘッダ"
                Dim dtSuccess As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
                '後納票差出明細シート
                strSQL = "SELECT ROW_NUMBER() OVER (PARTITION BY 1 "
                strSQL &= "ORDER BY T1.ラベル連番) AS 連番, "
                strSQL &= "T2.会社名 AS 宛先, T2.局所名, T3.郵送 + T3.特定記録 AS 料金 "
                strSQL &= "FROM T_印刷管理 AS T1 INNER JOIN "
                strSQL &= "M_局所 AS T2 ON T1.会社コード = T2.会社コード "
                strSQL &= "AND T1.所属事業所コード = T2.局所コード INNER JOIN "
                strSQL &= "M_重量ヘッダ AS T3 ON T1.重量ヘッダ = T3.重量ヘッダ "
                strSQL &= "WHERE ロットID = '" & Me.cmbLotID.SelectedValue & "' "
                strSQL &= "ORDER BY T1.ラベル連番"
                Dim dtSuccess2 As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)

                strSaveFile = "後納票_" & Me.dtpSendDate.Value.ToString("yyyyMMdd") & ".xlsx"
                strSaveFolder = strOutputFolder & "\後納票"
                If Not System.IO.Directory.Exists(strSaveFolder) Then
                    My.Computer.FileSystem.CreateDirectory(strSaveFolder)
                End If
				ExcelProcess.WriteExcelFile(ExcelOutputCategory.Succession, strSaveFolder & "\" & strSaveFile, dtSuccess, "発送日：" & Me.dtpSendDate.Value.ToString("yyyy年M月d日"), Nothing, Nothing, dtSuccess2)

				'出力日時の更新
				strSQL = "UPDATE T_ロット管理 "
                strSQL &= "SET 出力日時_後納票 = '" & Date.Now.ToString("yyyy/MM/dd HH:mm:ss") & "' "
                strSQL &= "WHERE ロットID = '" & Me.cmbLotID.SelectedValue & "'"
                sqlProcess.DB_UPDATE(strSQL)

                'チェックログの出力
                strSaveFile = "チェックログ_" & dtpSendDate.Value.ToString("yyyyMMdd") & ".log"
                Using sw As New System.IO.StreamWriter(strSaveFolder & "\" & strSaveFile, False, System.Text.Encoding.GetEncoding("Shift-JIS"))
                    Dim strHeader As String = "ロットID" & vbTab & "ラベル連番" & vbTab & "重量ヘッダ" & vbTab & "印刷ID" & vbTab & "帳票種別" & vbTab & "出力順" & vbTab & "リーフ枚数" & vbTab &
                        "会社コード" & vbTab & "所属事業所コード" & vbTab & "会社" & vbTab & "所属事業所" & vbTab & "所属部名" & vbTab & "所属課名" & vbTab & "システムID" & vbTab & "氏名" & vbTab &
                        "QRコード" & vbTab & "レコード番号" & vbTab & "帳票種別ID" & vbTab & "判定票印刷日時" & vbTab & "リーフレット印刷日時" & vbTab & "チェック日時" & vbTab & "作業者"
                    sw.WriteLine(strHeader)

                    strSQL = "SELECT T1.ロットID, T5.ラベル連番, T5.重量ヘッダ, T5.印刷ID, T2.帳票種別, T1.ページ数 AS 出力順, T1.枚数 AS リーフ枚数, "
                    strSQL &= "ISNULL(T4.会社コード, '') AS 会社コード, ISNULL(T4.所属事業所コード, '') AS 所属事業所コード, ISNULL(T3.会社, '') AS 会社, "
                    strSQL &= "ISNULL(T3.所属事業所, '') AS 所属事業所, ISNULL(T3.所属部名, '') AS 所属部名, ISNULL(T3.所属課名, '') AS 所属課名, "
                    strSQL &= "T1.システムID, ISNULL(T3.氏名, '') AS 氏名, T1.QR AS QRコード, T1.レコード番号, T1.帳票種別ID, "
                    strSQL &= "ISNULL(T4.判定票印刷日時, '') AS 判定票印刷日時, ISNULL(T4.リーフレット印刷日時, '') AS リーフレット印刷日時, "
                    strSQL &= "ISNULL(T1.チェック日時, '') AS チェック日時, ISNULL(T1.作業者, '') AS 作業者 "
                    strSQL &= "FROM T_印刷ソート AS T1 INNER JOIN "
                    strSQL &= "M_帳票種別 AS T2 ON T1.帳票種別ID = T2.帳票種別ID LEFT OUTER JOIN "
                    strSQL &= "T_判定票印刷 AS T3 ON T1.ロットID = T3.ロットID "
                    strSQL &= "AND T1.レコード番号 = T3.レコード番号 LEFT OUTER JOIN "
                    strSQL &= "T_判定票管理 AS T4 ON T1.ロットID = T4.ロットID "
                    strSQL &= "AND T1.レコード番号 = T4.レコード番号 INNER JOIN "
                    strSQL &= "T_印刷管理 AS T5 ON T1.ロットID = T5.ロットID "
                    strSQL &= "AND T1.会社コード = T5.会社コード "
                    strSQL &= "AND T1.所属事業所コード = T5.所属事業所コード "
                    strSQL &= "AND T1.印刷ID = T5.印刷ID "
                    strSQL &= "WHERE T1.ロットID = '" & Me.cmbLotID.SelectedValue & "' "
                    strSQL &= "ORDER BY T5.ラベル連番, T1.帳票種別ID, T1.ページ数"
                    Dim dt As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)

                    Dim strWriteLine As String = ""
                    For iRow As Integer = 0 To dt.Rows.Count - 1
                        strWriteLine = dt.Rows(iRow)("ロットID")
                        strWriteLine &= vbTab & dt.Rows(iRow)("ラベル連番")
                        strWriteLine &= vbTab & dt.Rows(iRow)("重量ヘッダ")
                        strWriteLine &= vbTab & dt.Rows(iRow)("印刷ID")
                        strWriteLine &= vbTab & dt.Rows(iRow)("帳票種別")
                        strWriteLine &= vbTab & dt.Rows(iRow)("出力順")
                        strWriteLine &= vbTab & dt.Rows(iRow)("リーフ枚数")
                        strWriteLine &= vbTab & dt.Rows(iRow)("会社コード")
                        strWriteLine &= vbTab & dt.Rows(iRow)("所属事業所コード")
                        strWriteLine &= vbTab & dt.Rows(iRow)("会社")
                        strWriteLine &= vbTab & dt.Rows(iRow)("所属事業所")
                        strWriteLine &= vbTab & dt.Rows(iRow)("所属部名")
                        strWriteLine &= vbTab & dt.Rows(iRow)("所属課名")
                        strWriteLine &= vbTab & dt.Rows(iRow)("システムID")
                        strWriteLine &= vbTab & dt.Rows(iRow)("氏名")
                        strWriteLine &= vbTab & dt.Rows(iRow)("QRコード")
                        strWriteLine &= vbTab & dt.Rows(iRow)("レコード番号")
                        strWriteLine &= vbTab & dt.Rows(iRow)("帳票種別ID")
                        strWriteLine &= vbTab & IIf(dt.Rows(iRow)("判定票印刷日時") = "1900/01/01", "", CDate(dt.Rows(iRow)("判定票印刷日時")).ToString("yyyy/MM/dd HH:mm:ss"))
                        strWriteLine &= vbTab & IIf(dt.Rows(iRow)("リーフレット印刷日時") = "1900/01/01", "", CDate(dt.Rows(iRow)("リーフレット印刷日時")).ToString("yyyy/MM/dd HH:mm:ss"))
                        strWriteLine &= vbTab & IIf(dt.Rows(iRow)("チェック日時") = "1900/01/01", "", CDate(dt.Rows(iRow)("チェック日時")).ToString("yyyy/MM/dd HH:mm:ss"))
                        strWriteLine &= vbTab & dt.Rows(iRow)("作業者")
                        sw.WriteLine(strWriteLine)
                    Next

                End Using

            End If

            MessageBox.Show("帳票出力が完了しました", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information)
            SearchLotInfo()

        Catch ex As Exception

            Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & ex.StackTrace)
            MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally

            sqlProcess.Close()
            EnableControls(Me, True)

        End Try

        'Dim strSaveFile As String = "データ不備内容_" & Me.dtpSendDate.Value.ToString("yyyyMMdd") & ".xlsx"
        'ExcelProcess.WriteExcelFile(ExcelOutputCategory.DataIncomplete, Me.txtOutputFolder.Text & "\" & strSaveFile, )

    End Sub

    ''' <summary>
    ''' 出力フォルダテキストボックスドラッグエンター時
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub txtOutputFolder_DragEnter(sender As Object, e As DragEventArgs) Handles txtOutputFolder.DragEnter

        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        Else
            e.Effect = DragDropEffects.None
        End If

    End Sub

    ''' <summary>
    ''' 出力フォルダテキストボックスドラッグドロップ時
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub txtOutputFolder_DragDrop(sender As Object, e As DragEventArgs) Handles txtOutputFolder.DragDrop

        Dim strFiles As String() = CType(e.Data.GetData(DataFormats.FileDrop, False), String())
        Dim txtFile As TextBox = CType(sender, TextBox)

        If System.IO.File.Exists(strFiles(0)) Then
            txtFile.Text = System.IO.Path.GetDirectoryName(strFiles(0))
        Else
            If System.IO.Directory.Exists(strFiles(0)) Then
                txtFile.Text = strFiles(0)
            End If
        End If

    End Sub

    ''' <summary>
    ''' 不備エクセルインポートテキストボックスドラッグエンター時
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub txtExcelFile_DragEnter(sender As Object, e As DragEventArgs) Handles txtExcelFile.DragEnter

        'If e.Data.GetDataPresent(DataFormats.FileDrop) Then
        '    e.Effect = DragDropEffects.Copy
        'Else
        '    e.Effect = DragDropEffects.None
        'End If
        e.Effect = DragDropEffects.Copy
    End Sub

    ''' <summary>
    ''' 不備エクセルインポートテキストボックスドラッグドロップ時
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub txtExcelFile_DragDrop(sender As Object, e As DragEventArgs) Handles txtExcelFile.DragDrop

        Dim strFiles As String() = CType(e.Data.GetData(DataFormats.FileDrop, False), String())
        Dim txtFile As TextBox = CType(sender, TextBox)

        If System.IO.File.Exists(strFiles(0)) Then
            If System.IO.Path.GetExtension(strFiles(0)) = ".xlsx" Then
                txtFile.Text = strFiles(0)
            End If
        End If

    End Sub

    ''' <summary>
    ''' 出力フォルダブラウズボタン押下時
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnOutputFolderBrowse_Click(sender As Object, e As EventArgs) Handles btnOutputFolderBrowse.Click

        Me.txtOutputFolder.Text = FolderBrowse(Me.txtOutputFolder)

    End Sub

    ''' <summary>
    ''' 不備エクセルインポートブラウズボタン押下時
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnExcelFileBrowse_Click(sender As Object, e As EventArgs) Handles btnExcelFileBrowse.Click

        Me.txtExcelFile.Text = FileBrowse(Me.txtExcelFile, "Excelファイル(*.xlsx)|*.xlsx")

    End Sub

    ''' <summary>
    ''' データ不備内容値コピーボタン押下時
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnCopy_Click(sender As Object, e As EventArgs) Handles btnCopy.Click

        'すべてのレコードにチェックがついていたら警告を出す
        Dim blnUnChecked As Boolean = False
        For iRow As Integer = 1 To Me.C1FGridDefect.Rows.Count - 1
            If Me.C1FGridDefect(iRow, "修正済フラグ") = False Then
                blnUnChecked = True
            End If
        Next
        If Not blnUnChecked Then
            '全てのレコードがチェックされている
            If MessageBox.Show("全てのレコードが修正済です" & vbNewLine & "続行しますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                Exit Sub
            End If
        End If

        If MessageBox.Show("不備内容の値を修正内容にコピーします" & vbNewLine & "よろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
            Exit Sub
        End If

		'2018/01/15
		'文字数超過エラーの場合は()内のみコピーする
		XmlSettings.LoadFromXmlFile()
		For iRow As Integer = 1 To Me.C1FGridDefect.Rows.Count - 1
			'修正内容の値がNULLの場合のみコピー
			If IsNull(Me.C1FGridDefect(iRow, "修正内容")) Then
				Dim strValue As String = Me.C1FGridDefect(iRow, "不備内容")
				Dim iResult As Integer = strValue.IndexOf(XmlSettings.Instance.DataExceed)
				If iResult >= 0 Then
					'ヒットしたら文字数超過エラー
					Dim iStart As Integer = strValue.IndexOf("(")   '0からの開始位置
					Dim iEnd As Integer = strValue.LastIndexOf(")") '0からの終了位置
					Dim strResult As String = strValue.Substring(iStart + 1, iEnd - iStart - 1)

					Me.C1FGridDefect(iRow, "修正内容") = strResult

				Else

					Me.C1FGridDefect(iRow, "修正内容") = Me.C1FGridDefect(iRow, "不備内容")

				End If

			End If

		Next

    End Sub

    ''' <summary>
    ''' データ不備内容更新ボタン押下時
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        '修正内容がNULLのレコードが1レコードでも存在したら警告する
        Dim iNullCount As Integer = 0
        For iRow As Integer = 1 To Me.C1FGridDefect.Rows.Count - 1
            If IsNull(Me.C1FGridDefect(iRow, "修正内容")) Then
                iNullCount += 1
            End If
        Next
        If iNullCount > 0 Then
            If MessageBox.Show("修正内容が入力されていないレコードが存在します" & vbNewLine & "続行しますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.No Then
                Exit Sub
            End If
        End If

        'すべてのレコードにチェックがついていたら警告を出す
        Dim blnUnChecked As Boolean = False
        For iRow As Integer = 1 To Me.C1FGridDefect.Rows.Count - 1
            If Me.C1FGridDefect(iRow, "修正済フラグ") = False Then
                blnUnChecked = True
            End If
        Next
        If Not blnUnChecked Then
            '全てのレコードがチェックされている
            If MessageBox.Show("全てのレコードが修正済です" & vbNewLine & "続行しますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                Exit Sub
            End If
        End If

        If MessageBox.Show("入力された修正内容に更新します" & vbNewLine & "よろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
            Exit Sub
        End If

        Dim sqlProcess As New SQLProcess
        Dim strSQL As String = ""

        Try
            'T_判定票管理.修正済日時、T_判定票_不備内容.修正済フラグの値を更新する
            For iRow As Integer = 1 To Me.C1FGridDefect.Rows.Count - 1
                'CSVファイルの[Checkup][Leaflet]によって枝分かれ
                Dim strCSV As String = Me.C1FGridDefect(iRow, "CSVファイル")
                If strCSV.IndexOf("Checkup") >= 0 Then
					'判定票
					'修正内容に値があるか
					'If IsNull(Me.C1FGridDefect(iRow, "修正内容")) Or
					'    Me.C1FGridDefect(iRow, "不備内容") = Me.C1FGridDefect(iRow, "修正内容") Then
					'同一の場合、または値がない場合は修正済日時と修正済フラグのみ更新する
					If Me.C1FGridDefect(iRow, "不備内容") = Me.C1FGridDefect(iRow, "修正内容") Then

					Else
						'2018/01/22
						'値が同一でなかった場合、T_判定票内の該当項目を更新する
						strSQL = "UPDATE T_判定票 SET " & Me.C1FGridDefect(iRow, "不備項目") & " = '" & Me.C1FGridDefect(iRow, "修正内容") & "' "
                        strSQL &= "WHERE ロットID = '" & Me.C1FGridDefect(iRow, "ロットID") & "' "
                        strSQL &= "AND レコード番号 = " & Me.C1FGridDefect(iRow, "レコード番号")
                        sqlProcess.DB_UPDATE(strSQL)
                    End If

                    'T_判定票管理
                    strSQL = "UPDATE T_判定票管理 SET 修正済日時 = '" & Date.Now.ToString("yyyy/MM/dd HH:mm:ss") & "' "
                    strSQL &= "WHERE ロットID = '" & Me.C1FGridDefect(iRow, "ロットID") & "' "
                    strSQL &= "AND レコード番号 = " & Me.C1FGridDefect(iRow, "レコード番号")
                    sqlProcess.DB_UPDATE(strSQL)
                    'T_判定票_不備内容
                    strSQL = "UPDATE T_判定票_不備内容 SET 修正済フラグ = 1, "
                    strSQL &= "修正内容 = '" & Me.C1FGridDefect(iRow, "修正内容") & "' "
                    strSQL &= "WHERE ロットID = '" & Me.C1FGridDefect(iRow, "ロットID") & "' "
                    strSQL &= "AND レコード番号 = " & Me.C1FGridDefect(iRow, "レコード番号") & " "
                    strSQL &= "AND 不備項目 = '" & Me.C1FGridDefect(iRow, "不備項目") & "'"
                    sqlProcess.DB_UPDATE(strSQL)

                    'QRコードの書き換え
                    strSQL = "SELECT QR FROM T_印刷ソート "
                    strSQL &= "WHERE ロットID = '" & Me.C1FGridDefect(iRow, "ロットID") & "' "
                    strSQL &= "AND レコード番号 = " & Me.C1FGridDefect(iRow, "レコード番号") & " "
                    strSQL &= "AND 帳票種別ID = 4"
                    Dim dt As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
                    If dt.Rows.Count > 0 Then
                        Dim strQR As String = dt.Rows(0)("QR")
                        '末尾の数値が1だった場合0に書き換える
                        If strQR.Substring(strQR.Length - 1, 1) = "1" Then
                            'T_印刷ソート
                            Dim strQRUpdate As String = ""
                            strQRUpdate = strQR.Substring(0, strQR.Length - 1) & "0"    '末尾1文字を削った値に0を追加する
                            strSQL = "UPDATE T_印刷ソート SET QR = '" & strQRUpdate & "' "
                            strSQL &= "WHERE ロットID = '" & Me.C1FGridDefect(iRow, "ロットID") & "' "
                            strSQL &= "AND レコード番号 = " & Me.C1FGridDefect(iRow, "レコード番号") & " "
                            strSQL &= "AND 帳票種別ID = 4"
                            sqlProcess.DB_UPDATE(strSQL)
                            'T_判定票印刷
                            strSQL = "UPDATE T_判定票印刷 SET QRコード = '" & strQRUpdate & "' "
                            strSQL &= "WHERE ロットID = '" & Me.C1FGridDefect(iRow, "ロットID") & "' "
                            strSQL &= "AND レコード番号 = " & Me.C1FGridDefect(iRow, "レコード番号") & " "
                            sqlProcess.DB_UPDATE(strSQL)
                        End If
                    End If

                    '印刷準備個別処理
                    PrintPreparationIndividual(Me.C1FGridDefect(iRow, "ロットID"), Me.C1FGridDefect(iRow, "レコード番号"))

                Else
					'リーフレット
					'修正内容に値があるか
					'If IsNull(Me.C1FGridDefect(iRow, "修正内容")) Or
					'    Me.C1FGridDefect(iRow, "不備内容") = Me.C1FGridDefect(iRow, "修正内容") Then
					'値がない、または同一の場合は修正済日時と修正済フラグのみ更新する
					If Me.C1FGridDefect(iRow, "不備内容") = Me.C1FGridDefect(iRow, "修正内容") Then

					ElseIf Me.C1FGridDefect(iRow, "修正内容") = "印刷対象外" Then
						'印刷対象外の場合はすでに修正済となっているため何もしない
						Continue For
					Else
						'値が同一でなかった場合T_リーフレット内の該当項目を更新する
						strSQL = "UPDATE T_リーフレット SET " & Me.C1FGridDefect(iRow, "不備項目") & " = '" & Me.C1FGridDefect(iRow, "修正内容") & "' "
                        strSQL &= "WHERE ロットID = '" & Me.C1FGridDefect(iRow, "ロットID") & "' "
                        strSQL &= "AND レコード番号 = " & Me.C1FGridDefect(iRow, "レコード番号") & " "
                        strSQL &= "AND 帳票タイプ = '" & Me.C1FGridDefect(iRow, "帳票タイプ") & "'"
                        sqlProcess.DB_UPDATE(strSQL)
                    End If
                    'T_判定票管理
                    strSQL = "UPDATE T_判定票管理 SET 修正済日時 = '" & Date.Now.ToString("yyyy/MM/dd HH:mm:ss") & "' "
                    strSQL &= "WHERE ロットID = '" & Me.C1FGridDefect(iRow, "ロットID") & "' "
                    strSQL &= "AND レコード番号 = " & Me.C1FGridDefect(iRow, "レコード番号")
                    sqlProcess.DB_UPDATE(strSQL)
					'T_判定票_不備内容
					strSQL = "UPDATE T_判定票_不備内容 SET 修正済フラグ = 1, "
					strSQL &= "修正内容 = '" & Me.C1FGridDefect(iRow, "修正内容") & "' "
					strSQL &= "WHERE ロットID = '" & Me.C1FGridDefect(iRow, "ロットID") & "' "
					strSQL &= "AND レコード番号 = " & Me.C1FGridDefect(iRow, "レコード番号") & " "
					strSQL &= "AND 不備項目 = '" & Me.C1FGridDefect(iRow, "不備項目") & "' "
					strSQL &= "AND 帳票タイプ = '" & Me.C1FGridDefect(iRow, "帳票タイプ") & "'"
                    sqlProcess.DB_UPDATE(strSQL)

                    'QRコードの書き換え
                    strSQL = "SELECT QR FROM T_印刷ソート "
                    strSQL &= "WHERE ロットID = '" & Me.C1FGridDefect(iRow, "ロットID") & "' "
                    strSQL &= "AND レコード番号 = " & Me.C1FGridDefect(iRow, "レコード番号") & " "
                    strSQL &= "AND 帳票種別ID = 5 "
                    Dim dt As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
                    If dt.Rows.Count > 0 Then
                        Dim strQR As String = dt.Rows(0)("QR")
                        '末尾から2文字目の数値が1だった場合0に書き換える
                        If strQR.Substring(strQR.Length - 2, 1) = "1" Then
                            'T_印刷ソート
                            Dim strQRUpdate As String = ""
                            strQRUpdate = strQR.Substring(0, strQR.Length - 2) & "0" & strQR.Substring(strQR.Length - 1, 1)    '末尾から2文字を削った値に0を追加し、末尾の文字列を結合する
                            strSQL = "UPDATE T_印刷ソート SET QR = '" & strQRUpdate & "' "
                            strSQL &= "WHERE ロットID = '" & Me.C1FGridDefect(iRow, "ロットID") & "' "
                            strSQL &= "AND レコード番号 = " & Me.C1FGridDefect(iRow, "レコード番号") & " "
                            strSQL &= "AND 帳票種別ID = 5"
                            sqlProcess.DB_UPDATE(strSQL)
                            'T_リーフレット印刷
                            'リーフレットが同一レコードで複数レコードあった場合はすべてのレコードを更新する
                            strSQL = "SELECT 帳票タイプ, QRコード FROM T_リーフレット印刷 "
                            strSQL &= "WHERE ロットID = '" & Me.C1FGridDefect(iRow, "ロットID") & "' "
                            strSQL &= "AND レコード番号 = " & Me.C1FGridDefect(iRow, "レコード番号")
                            Dim dtLeafUpdate As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
							For iLeafUpdate As Integer = 0 To dtLeafUpdate.Rows.Count - 1
								Dim strLeafQR As String = dtLeafUpdate.Rows(iLeafUpdate)("QRコード")
								strQRUpdate = strLeafQR.Substring(0, strLeafQR.Length - 2) & "0" & strLeafQR.Substring(strLeafQR.Length - 1, 1)    '末尾から2文字を削った値に0を追加し、末尾の文字列を結合する

								strSQL = "UPDATE T_リーフレット印刷 SET QRコード = '" & strQRUpdate & "' "
								strSQL &= "WHERE ロットID = '" & Me.C1FGridDefect(iRow, "ロットID") & "' "
								strSQL &= "AND レコード番号 = " & Me.C1FGridDefect(iRow, "レコード番号") & " "
								sqlProcess.DB_UPDATE(strSQL)
							Next
							'2018/08/10
							'T_リーフ6チェックのQRコード書き換えを追加
							'リーフレットが同一レコードで複数レコードあった場合はすべてのレコードを更新する
							strSQL = "SELECT 帳票タイプ, QRコード FROM T_リーフ6チェック "
							strSQL &= "WHERE ロットID = '" & Me.C1FGridDefect(iRow, "ロットID") & "' "
							strSQL &= "AND レコード番号 = " & Me.C1FGridDefect(iRow, "レコード番号") & " "
							Dim dtLeaf6Update As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
							For iLeaf6Update As Integer = 0 To dtLeaf6Update.Rows.Count - 1
								Dim strLeaf6QR As String = dtLeaf6Update.Rows(iLeaf6Update)("QRコード")
								strQRUpdate = strLeaf6QR.Substring(0, strLeaf6QR.Length - 2) & "0" & strLeaf6QR.Substring(strLeaf6QR.Length - 1, 1)    '末尾から2文字を削った値に0を追加し、末尾の文字列を結合する

								strSQL = "UPDATE T_リーフ6チェック SET QRコード = '" & strQRUpdate & "' "
								strSQL &= "WHERE ロットID = '" & Me.C1FGridDefect(iRow, "ロットID") & "' "
								strSQL &= "AND レコード番号 = " & Me.C1FGridDefect(iRow, "レコード番号") & " "
								sqlProcess.DB_UPDATE(strSQL)
							Next
						End If
                    End If

                    PrintPreparationIndividual(Me.C1FGridDefect(iRow, "ロットID"), Me.C1FGridDefect(iRow, "レコード番号"))

                End If
            Next

            MessageBox.Show("修正内容を更新しました", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information)

            'SearchGridDefect(Me.cmbLotID.SelectedValue)
            SearchLotInfo()

        Catch ex As Exception

            Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & ex.StackTrace)
            MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally

            sqlProcess.Close()

        End Try
    End Sub

    ''' <summary>
    ''' テキストボックスエンター時
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub txtOutputFolder_Enter(sender As Object, e As EventArgs) Handles txtOutputFolder.Enter, txtExcelFile.Enter

        CType(sender, TextBox).BackColor = Color.LightGreen
        CType(sender, TextBox).SelectAll()

    End Sub

    ''' <summary>
    ''' テキストボックスリーブ時
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub txtOutputFolder_Leave(sender As Object, e As EventArgs) Handles txtOutputFolder.Leave, txtExcelFile.Leave

        CType(sender, TextBox).BackColor = System.Drawing.SystemColors.Window

    End Sub

    ''' <summary>
    ''' 事業所別出力ボタン押下時
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnOfficeOut_Click(sender As Object, e As EventArgs) Handles btnOfficeOut.Click

        OutputCSVFile(Me.C1FGridResult, Me.txtOutputFolder.Text & "\事業所別件数_" & Me.dtpSendDate.Value.ToString("yyyyMMdd"))

    End Sub

    ''' <summary>
    ''' 重量ヘッダ出力ボタン押下時
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnWeightOut_Click(sender As Object, e As EventArgs) Handles btnWeightOut.Click

        OutputCSVFile(Me.C1FGridHeader, Me.txtOutputFolder.Text & "\重量ヘッダ別件数_" & Me.dtpSendDate.Value.ToString("yyyyMMdd"))

    End Sub

    ''' <summary>
    ''' 不備内容出力ボタン押下時
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnIncompleteOut_Click(sender As Object, e As EventArgs) Handles btnIncompleteOut.Click
        '日付はインポート日
        OutputCSVFile(Me.C1FGridDefect, Me.txtOutputFolder.Text & "\不備内容_" & Me.cmbLotID.SelectedValue.ToString.Substring(0, 8) & ".csv")

    End Sub

    ''' <summary>
    ''' 不備エクセルインポートボタン押下時
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnExcelImport_Click(sender As Object, e As EventArgs) Handles btnExcelImport.Click

        If Not System.IO.File.Exists(Me.txtExcelFile.Text) Then
            MessageBox.Show("存在するデータ不備内容エクセルを指定して下さい", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If MessageBox.Show("指定された不備内容エクセルファイルより修正内容をインポートします" & vbNewLine & "よろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
            Exit Sub
        End If

        XmlSettings.LoadFromXmlFile()
        'パスワードを解除する
        UnsetPassword(Me.txtExcelFile.Text, XmlSettings.Instance.ExcelPassword)
        Using wb As New XLWorkbook(Me.txtExcelFile.Text)

            Dim ws As IXLWorksheet = wb.Worksheet("不備内容")
            '行で回して、会社コードがNULLの場合抜ける
            For i As Integer = 6 To 10000
                If IsNull(ws.Cell(i, 2).Value) Then
                    Exit For
                End If
                '修正内容が「印刷対象外」の場合はスキップする
                If ws.Cell(i, 18).Value = "印刷対象外" Then
                    Continue For
                End If
                '不備内容グリッドを走査して該当レコードの修正内容を書き換える
                For iRow As Integer = 1 To Me.C1FGridDefect.Rows.Count - 1

					If ws.Cell(i, 2).Value = Me.C1FGridDefect(iRow, "会社コード") And
							ws.Cell(i, 3).Value = Me.C1FGridDefect(iRow, "局所コード") And
							ws.Cell(i, 8).Value = Me.C1FGridDefect(iRow, "社員コード") And
							ws.Cell(i, 16).Value = Me.C1FGridDefect(iRow, "不備項目") And
							ws.Cell(i, 17).Value = Me.C1FGridDefect(iRow, "不備内容") Then
						Me.C1FGridDefect(iRow, "修正内容") = ws.Cell(i, 18).Value
					End If
				Next
            Next
        End Using

        'パスワードを設定し直す
        SetPassword(Me.txtExcelFile.Text, XmlSettings.Instance.ExcelPassword)

        MessageBox.Show("修正内容をインポートしました", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

#End Region

#Region "プライベートメソッド"

    ''' <summary>
    ''' 初期化処理
    ''' </summary>
    Private Sub Initialize()

        RemoveHandler cmbLotID.SelectedIndexChanged, AddressOf cmbLotID_SelectedIndexChanged
        UpdateImportDate()
        AddHandler cmbLotID.SelectedIndexChanged, AddressOf cmbLotID_SelectedIndexChanged

        Me.cmbLotID.SelectedIndex = 0
        '終了ボタンのテキストを「戻る」にする
        Me.btnBack.Text = "戻る"
        'コンピュータ名の表示
        Me.lblUser.Text = My.Computer.Name
        'Me.lblProgress.Text = ""

        XmlSettings.LoadFromXmlFile()
		Me.txtOutputFolder.Text = XmlSettings.Instance.VariousOutputFolder  '保存フォルダ
		'判定票管理画面のプロパティ反映
		Me.Left = XmlSettings.Instance.CheckupLocationX
		Me.Top = XmlSettings.Instance.CheckupLocationY
		Me.Width = XmlSettings.Instance.CheckupSizeX
		Me.Height = XmlSettings.Instance.CheckupSizeY
		Me.WindowState = XmlSettings.Instance.CheckupState

	End Sub

    ''' <summary>
    ''' メインメニューへ戻る
    ''' </summary>
    Private Sub BackScreen()

		XmlSettings.LoadFromXmlFile()
		If Me.WindowState = FormWindowState.Normal Then
			XmlSettings.Instance.CheckupLocationX = Me.Left
			XmlSettings.Instance.CheckupLocationY = Me.Top
			XmlSettings.Instance.CheckupSizeX = Me.Width
			XmlSettings.Instance.CheckupSizeY = Me.Height
			XmlSettings.Instance.CheckupState = Me.WindowState
		Else
			XmlSettings.Instance.CheckupLocationX = Me.RestoreBounds.Left
			XmlSettings.Instance.CheckupLocationY = Me.RestoreBounds.Top
			XmlSettings.Instance.CheckupSizeX = Me.RestoreBounds.Width
			XmlSettings.Instance.CheckupSizeY = Me.RestoreBounds.Height
			XmlSettings.Instance.CheckupState = Me.WindowState
		End If
		XmlSettings.SaveToXmlFile()

		Dim f As New frmMainMenu
        m_Context.SetNextContext(f)

    End Sub

    ''' <summary>
    ''' 該当コンボボックスへインポート日時をセットする
    ''' </summary>
    Private Sub UpdateImportDate()

        Dim sqlProcess As New SQLProcess
        Dim strSQL As String = ""

        Try
            strSQL = "SELECT ロットID, インポート日時 FROM T_ロット管理 "
            strSQL &= "WHERE 削除フラグ = 0 "
            strSQL &= "ORDER BY ロットID DESC"
            Dim dt As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
            SetComboValue(Me.cmbLotID, dt, False)

        Catch ex As Exception

            Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & ex.StackTrace)
            MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally

            sqlProcess.Close()

        End Try

    End Sub

    ''' <summary>
    ''' インポート内容データ表示
    ''' </summary>
    ''' <param name="strLotID"></param>
    Private Sub SearchGrid(ByVal strLotID As String)

        Dim sqlProcess As New SQLProcess
        Dim strSQL As String = ""

        Me.C1FGridResult.ClearFilter()
        Me.C1FGridResult.Rows.Count = 1

        Try
            strSQL = "SELECT T1.会社コード, T1.所属事業所コード AS 局所コード, T2.会社名, T2.局所名, "
            strSQL &= "COUNT(T1.システムID) AS 判定票件数, "
            strSQL &= "SUM(CASE WHEN T1.リーフレット枚数 = 0 OR リーフレット無効 = 1 THEN 0 ELSE 1 END) AS リーフ件数, "
            strSQL &= "SUM(CASE WHEN T1.リーフレット枚数 = 0 OR リーフレット無効 = 1 THEN 0 ELSE T1.リーフレット枚数 END) AS リーフ枚数, "
            strSQL &= "SUM(T1.重量) AS 重量, "
            strSQL &= "MAX(ISNULL(T1.要修正日時, '1900/01/01')) AS 要修正日時, "
            strSQL &= "MAX(ISNULL(T1.修正済日時, '1900/01/01')) AS 修正済日時, "
            strSQL &= "MAX(ISNULL(T1.判定票印刷日時, '1900/01/01')) AS 判定票印刷日時, "
            strSQL &= "MAX(ISNULL(T1.リーフレット印刷日時, '1900/01/01')) AS リーフレット印刷日時 "
            strSQL &= "FROM T_判定票管理 AS T1 INNER JOIN "
            strSQL &= "M_局所 AS T2 ON T1.会社コード = T2.会社コード "
            strSQL &= "AND T1.所属事業所コード = T2.局所コード "
            strSQL &= "WHERE T1.ロットID = '" & strLotID & "' "
            strSQL &= "GROUP BY T1.会社コード, T1.所属事業所コード, T2.会社名, T2.局所名 "
            strSQL &= "ORDER BY T1.会社コード, T1.所属事業所コード"
            Dim dt As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)

            Dim iRecordCount As Integer = 0
            Dim iOfficeCount As Integer = 0   '事業所数
            Dim iCheckupCount As Integer = 0    '判定票件数
            Dim iLeafletCount As Integer = 0    'リーフレット件数
            Dim iLeafletSheet As Integer = 0    'リーフレット枚数

            Me.C1FGridResult.BeginUpdate()
            For iRow As Integer = 0 To dt.Rows.Count - 1
                iRecordCount += 1
                Me.C1FGridResult.Rows.Count = iRecordCount + 1
                Me.C1FGridResult(iRecordCount, "No") = iRecordCount
                Me.C1FGridResult(iRecordCount, "会社コード") = dt.Rows(iRow)("会社コード")
                Me.C1FGridResult(iRecordCount, "局所コード") = dt.Rows(iRow)("局所コード")
                Me.C1FGridResult(iRecordCount, "会社名") = dt.Rows(iRow)("会社名")
                Me.C1FGridResult(iRecordCount, "局所名") = dt.Rows(iRow)("局所名")
                Me.C1FGridResult(iRecordCount, "判定票件数") = dt.Rows(iRow)("判定票件数")
                Me.C1FGridResult(iRecordCount, "リーフ件数") = dt.Rows(iRow)("リーフ件数")
                Me.C1FGridResult(iRecordCount, "リーフ枚数") = dt.Rows(iRow)("リーフ枚数")
                Me.C1FGridResult(iRecordCount, "重量") = dt.Rows(iRow)("重量")
                Me.C1FGridResult(iRecordCount, "要修正日時") = IIf(dt.Rows(iRow)("要修正日時") = "1900/01/01", "", dt.Rows(iRow)("要修正日時"))
                Me.C1FGridResult(iRecordCount, "修正済日時") = IIf(dt.Rows(iRow)("修正済日時") = "1900/01/01", "", dt.Rows(iRow)("修正済日時"))
                Me.C1FGridResult(iRecordCount, "判定票印刷日時") = IIf(dt.Rows(iRow)("判定票印刷日時") = "1900/01/01", "", dt.Rows(iRow)("判定票印刷日時"))
                Me.C1FGridResult(iRecordCount, "リーフレット印刷日時") = IIf(dt.Rows(iRow)("リーフレット印刷日時") = "1900/01/01", "", dt.Rows(iRow)("リーフレット印刷日時"))

                iOfficeCount += 1
                iCheckupCount += dt.Rows(iRow)("判定票件数")
                iLeafletCount += dt.Rows(iRow)("リーフ件数")
                iLeafletSheet += dt.Rows(iRow)("リーフ枚数")
            Next
            Me.C1FGridResult.EndUpdate()

            'グリッド内の各件数をステータスバーに表示する
            Me.lblProgress.Text = "事業所数：" & iOfficeCount & "：判定票件数：" & iCheckupCount & "：リーフ件数：" & iLeafletCount & "：リーフ枚数：" & iLeafletSheet

            ChangeBackColor()

        Catch ex As Exception

            Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & ex.StackTrace)
            MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally

            sqlProcess.Close()

        End Try

    End Sub

    ''' <summary>
    ''' 重量ヘッダデータ表示
    ''' </summary>
    ''' <param name="strLotID"></param>
    Private Sub SearchGridWeight(ByVal strLotID As String)

        Dim sqlProcess As New SQLProcess
        Dim strSQL As String = ""

        Me.C1FGridHeader.Rows.Count = 1

        Try
			'strSQL = "SELECT T2.重量ヘッダ AS ヘッダ, "
			'strSQL &= "CONVERT(VARCHAR, MIN(T2.ラベル連番)) + '～' + CONVERT(VARCHAR, MAX(T2.ラベル連番)) AS ラベル連番, "
			'strSQL &= "SUM(CASE WHEN T1.帳票種別ID = 0 THEN 1 ELSE 0 END) AS ラベル, "
			'strSQL &= "SUM(CASE WHEN T1.帳票種別ID = 2 THEN 1 ELSE 0 END) AS 対象者, "
			'strSQL &= "SUM(CASE WHEN T1.帳票種別ID = 3 THEN 1 ELSE 0 END) AS 保健指導, "
			'strSQL &= "SUM(CASE WHEN T1.帳票種別ID = 4 THEN 1 ELSE 0 END) AS 判定票, "
			'strSQL &= "SUM(CASE WHEN T1.帳票種別ID = 5 AND T1.枚数 < 6 THEN 1 ELSE 0 END) AS リーフ件, "
			'strSQL &= "SUM(CASE WHEN T1.帳票種別ID = 5 AND T1.枚数 < 6 THEN T1.枚数 ELSE 0 END) AS リーフ枚, "
			'strSQL &= "SUM(CASE WHEN T1.枚数 = 6 THEN 1 ELSE 0 END) AS リーフ6件, "
			'strSQL &= "SUM(CASE WHEN T3.リーフレット無効 = 1 AND T3.リーフレット枚数 > 0 THEN 1 ELSE 0 END) AS リーフ重複件, "
			'strSQL &= "SUM(CASE WHEN T3.リーフレット無効 = 1 AND T3.リーフレット枚数 > 0 THEN T3.リーフレット枚数 ELSE 0 END) AS リーフ重複枚, "
			'strSQL &= "SUM(CASE WHEN ISNULL(T3.要修正日時, '') != '' THEN 1 ELSE 0 END) AS 不備, "
			'strSQL &= "SUM(CASE WHEN ISNULL(T3.要修正日時, '') != '' AND ISNULL(T3.修正済日時, '') != '' THEN 1 ELSE 0 END) AS 修正 "
			'strSQL &= "FROM T_印刷ソート AS T1 INNER JOIN "
			'strSQL &= "T_印刷管理 AS T2 ON T1.ロットID = T2.ロットID AND T1.会社コード = T2.会社コード "
			'strSQL &= "AND T1.所属事業所コード = T2.所属事業所コード "
			'strSQL &= "AND T1.印刷ID = T2.印刷ID LEFT OUTER JOIN "
			'strSQL &= "T_判定票管理 AS T3 ON T1.ロットID = T3.ロットID "
			'strSQL &= "AND T1.レコード番号 = T3.レコード番号 "
			'strSQL &= "WHERE T1.ロットID = '" & strLotID & "' "
			'strSQL &= "GROUP BY T2.重量ヘッダ "
			'strSQL &= "ORDER BY T2.重量ヘッダ"
			strSQL = "SELECT T2.重量ヘッダ AS ヘッダ, "
			strSQL &= "CONVERT(VARCHAR, MIN(T2.ラベル連番)) + '～' + CONVERT(VARCHAR, MAX(T2.ラベル連番)) AS ラベル連番, "
			strSQL &= "SUM(CASE WHEN T1.帳票種別ID = 0 THEN 1 ELSE 0 END) AS ラベル, "
			strSQL &= "SUM(CASE WHEN T1.帳票種別ID = 2 THEN 1 ELSE 0 END) AS 対象者, "
			strSQL &= "SUM(CASE WHEN T1.帳票種別ID = 3 THEN 1 ELSE 0 END) AS 保健指導, "
			strSQL &= "SUM(CASE WHEN T1.帳票種別ID = 4 THEN 1 ELSE 0 END) AS 判定票, "
			'2018/08/15
			'リーフ件、リーフ枚は6枚未満だけではなく全てのリーフ数を出力するように変更
			'strSQL &= "SUM(CASE WHEN T1.帳票種別ID = 5 AND T1.枚数 < 6 THEN 1 ELSE 0 END) AS リーフ件, "
			'strSQL &= "SUM(CASE WHEN T1.帳票種別ID = 5 AND T1.枚数 < 6 THEN T1.枚数 ELSE 0 END) AS リーフ枚, "
			strSQL &= "SUM(CASE WHEN T1.帳票種別ID = 5 THEN 1 ELSE 0 END) AS リーフ件, "
			strSQL &= "SUM(CASE WHEN T1.帳票種別ID = 5 THEN T1.枚数 ELSE 0 END) AS リーフ枚, "
			'2018/07/31
			'T1.枚数 = 6ではなく6以上に変更、リーフ6枚の追加
			''strSQL &= "SUM(CASE WHEN T1.枚数 = 6 THEN 1 ELSE 0 END) AS リーフ6件, "
			strSQL &= "SUM(CASE WHEN T1.枚数 >= 6 THEN 1 ELSE 0 END) AS リーフ6件, "
			strSQL &= "SUM(CASE WHEN T1.枚数 >= 6 THEN T1.枚数 ELSE 0 END) AS リーフ6枚, "
			'2018/04/03
			'重複したリーフレットは全て「T_リーフレット_重複」に退避されているためT1.帳票種別ID = 5では結びつかないため
			'リーフレット重複件数、枚数はT1.帳票種別ID = 4(判定票)で結びつける
			strSQL &= "SUM(CASE WHEN T3.リーフ重複枚数 > 0 AND T1.帳票種別ID = 4 THEN 1 ELSE 0 END) AS リーフ重複件, "
			strSQL &= "SUM(CASE WHEN T3.リーフ重複枚数 > 0 AND T1.帳票種別ID = 4 THEN T3.リーフ重複枚数 ELSE 0 END) AS リーフ重複枚 "
			strSQL &= "FROM T_印刷ソート AS T1 INNER JOIN "
			strSQL &= "T_印刷管理 AS T2 ON T1.ロットID = T2.ロットID AND T1.会社コード = T2.会社コード "
			strSQL &= "AND T1.所属事業所コード = T2.所属事業所コード AND T1.印刷ID = T2.印刷ID LEFT OUTER JOIN "
			strSQL &= "(SELECT A1.ロットID, A1.レコード番号, ISNULL(A2.リーフ重複枚数, 0) AS リーフ重複枚数 "
			strSQL &= "FROM T_判定票管理 AS A1 LEFT OUTER JOIN "
			strSQL &= "(SELECT ロットID, レコード番号, COUNT(社員コード) AS リーフ重複枚数 "
			strSQL &= "FROM T_判定票_不備内容 "
			strSQL &= "WHERE CSVファイル LIKE 'Leaflet%' "
			strSQL &= "AND 修正内容 = '印刷対象外' "
			strSQL &= "GROUP BY ロットID, レコード番号) AS A2 ON A1.ロットID = A2.ロットID "
			strSQL &= "AND A1.レコード番号 = A2.レコード番号) AS T3 ON T1.ロットID = T3.ロットID "
			strSQL &= "AND T1.レコード番号 = T3.レコード番号 "
			strSQL &= "WHERE T1.ロットID = '" & strLotID & "' "
			strSQL &= "GROUP BY T2.重量ヘッダ "
			strSQL &= "ORDER BY T2.重量ヘッダ"

			Dim dt As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)

			'2018/03/30
			'重量ヘッダ単位の不備、修正済件数を別途取得する
			'判定票、リーフレット別々に取得して、グリッドにセットする際に合算する
			'判定票
			strSQL = "SELECT ISNULL(SUM(CASE WHEN A1.重量ヘッダ = 'A' THEN 1 ELSE 0 END), 0) AS 'A', "
			strSQL &= "ISNULL(SUM(CASE WHEN A1.重量ヘッダ = 'B' THEN 1 ELSE 0 END), 0) AS 'B', "
			strSQL &= "ISNULL(SUM(CASE WHEN A1.重量ヘッダ = 'C' THEN 1 ELSE 0 END), 0) AS 'C', "
			strSQL &= "ISNULL(SUM(CASE WHEN A1.重量ヘッダ = 'D' THEN 1 ELSE 0 END), 0) AS 'D', "
			strSQL &= "ISNULL(SUM(CASE WHEN A1.重量ヘッダ = 'E' THEN 1 ELSE 0 END), 0) AS 'E', "
			strSQL &= "ISNULL(SUM(CASE WHEN A1.重量ヘッダ = 'F' THEN 1 ELSE 0 END), 0) AS 'F', "
			strSQL &= "ISNULL(SUM(CASE WHEN A1.重量ヘッダ = 'G' THEN 1 ELSE 0 END), 0) AS 'G', "
			strSQL &= "ISNULL(SUM(CASE WHEN A1.重量ヘッダ = 'H' THEN 1 ELSE 0 END), 0) AS 'H', "
			strSQL &= "ISNULL(SUM(CASE WHEN A1.重量ヘッダ = 'A' AND A1.修正済フラグ = 1 THEN 1 ELSE 0 END), 0) AS 'A修正済', "
			strSQL &= "ISNULL(SUM(CASE WHEN A1.重量ヘッダ = 'B' AND A1.修正済フラグ = 1 THEN 1 ELSE 0 END), 0) AS 'B修正済', "
			strSQL &= "ISNULL(SUM(CASE WHEN A1.重量ヘッダ = 'C' AND A1.修正済フラグ = 1 THEN 1 ELSE 0 END), 0) AS 'C修正済', "
			strSQL &= "ISNULL(SUM(CASE WHEN A1.重量ヘッダ = 'D' AND A1.修正済フラグ = 1 THEN 1 ELSE 0 END), 0) AS 'D修正済', "
			strSQL &= "ISNULL(SUM(CASE WHEN A1.重量ヘッダ = 'E' AND A1.修正済フラグ = 1 THEN 1 ELSE 0 END), 0) AS 'E修正済', "
			strSQL &= "ISNULL(SUM(CASE WHEN A1.重量ヘッダ = 'F' AND A1.修正済フラグ = 1 THEN 1 ELSE 0 END), 0) AS 'F修正済', "
			strSQL &= "ISNULL(SUM(CASE WHEN A1.重量ヘッダ = 'G' AND A1.修正済フラグ = 1 THEN 1 ELSE 0 END), 0) AS 'G修正済', "
			strSQL &= "ISNULL(SUM(CASE WHEN A1.重量ヘッダ = 'H' AND A1.修正済フラグ = 1 THEN 1 ELSE 0 END), 0) AS 'H修正済' "
			strSQL &= "FROM (SELECT T3.重量ヘッダ, T1.ロットID, T1.レコード番号, T1.修正済フラグ, T2.会社コード, T2.所属事業所コード, T2.印刷ID "
			strSQL &= "FROM T_判定票_不備内容 AS T1 INNER JOIN "
			strSQL &= "T_印刷ソート AS T2 ON T1.ロットID = T2.ロットID "
			strSQL &= "AND T1.レコード番号 = T2.レコード番号 INNER JOIN "
			strSQL &= "T_印刷管理 AS T3 ON T2.ロットID = T3.ロットID "
			strSQL &= "AND T2.会社コード = T3.会社コード "
			strSQL &= "AND T2.所属事業所コード = T3.所属事業所コード "
			strSQL &= "AND T2.印刷ID = T3.印刷ID "
			strSQL &= "WHERE T1.ロットID = '" & strLotID & "' "
			strSQL &= "AND T1.CSVファイル LIKE 'Checkup%' "
			strSQL &= "GROUP BY T1.ロットID, T1.レコード番号, T1.修正済フラグ, T2.会社コード, T2.所属事業所コード, T2.印刷ID, T3.重量ヘッダ "
			strSQL &= ") AS A1"
			Dim dtCheckup As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)

			'リーフレット
			strSQL = "SELECT ISNULL(SUM(CASE WHEN A1.重量ヘッダ = 'A' THEN 1 ELSE 0 END), 0) AS 'A', "
			strSQL &= "ISNULL(SUM(CASE WHEN A1.重量ヘッダ = 'B' THEN 1 ELSE 0 END), 0) AS 'B', "
			strSQL &= "ISNULL(SUM(CASE WHEN A1.重量ヘッダ = 'C' THEN 1 ELSE 0 END), 0) AS 'C', "
			strSQL &= "ISNULL(SUM(CASE WHEN A1.重量ヘッダ = 'D' THEN 1 ELSE 0 END), 0) AS 'D', "
			strSQL &= "ISNULL(SUM(CASE WHEN A1.重量ヘッダ = 'E' THEN 1 ELSE 0 END), 0) AS 'E', "
			strSQL &= "ISNULL(SUM(CASE WHEN A1.重量ヘッダ = 'F' THEN 1 ELSE 0 END), 0) AS 'F', "
			strSQL &= "ISNULL(SUM(CASE WHEN A1.重量ヘッダ = 'G' THEN 1 ELSE 0 END), 0) AS 'G', "
			strSQL &= "ISNULL(SUM(CASE WHEN A1.重量ヘッダ = 'H' THEN 1 ELSE 0 END), 0) AS 'H', "
			strSQL &= "ISNULL(SUM(CASE WHEN A1.重量ヘッダ = 'A' AND A1.修正済フラグ = 1 THEN 1 ELSE 0 END), 0) AS 'A修正済', "
			strSQL &= "ISNULL(SUM(CASE WHEN A1.重量ヘッダ = 'B' AND A1.修正済フラグ = 1 THEN 1 ELSE 0 END), 0) AS 'B修正済', "
			strSQL &= "ISNULL(SUM(CASE WHEN A1.重量ヘッダ = 'C' AND A1.修正済フラグ = 1 THEN 1 ELSE 0 END), 0) AS 'C修正済', "
			strSQL &= "ISNULL(SUM(CASE WHEN A1.重量ヘッダ = 'D' AND A1.修正済フラグ = 1 THEN 1 ELSE 0 END), 0) AS 'D修正済', "
			strSQL &= "ISNULL(SUM(CASE WHEN A1.重量ヘッダ = 'E' AND A1.修正済フラグ = 1 THEN 1 ELSE 0 END), 0) AS 'E修正済', "
			strSQL &= "ISNULL(SUM(CASE WHEN A1.重量ヘッダ = 'F' AND A1.修正済フラグ = 1 THEN 1 ELSE 0 END), 0) AS 'F修正済', "
			strSQL &= "ISNULL(SUM(CASE WHEN A1.重量ヘッダ = 'G' AND A1.修正済フラグ = 1 THEN 1 ELSE 0 END), 0) AS 'G修正済', "
			strSQL &= "ISNULL(SUM(CASE WHEN A1.重量ヘッダ = 'H' AND A1.修正済フラグ = 1 THEN 1 ELSE 0 END), 0) AS 'H修正済' "
			strSQL &= "FROM (SELECT T3.重量ヘッダ, T1.ロットID, T1.レコード番号, T1.修正済フラグ, T2.会社コード, T2.所属事業所コード, T2.印刷ID "
			strSQL &= "FROM T_判定票_不備内容 AS T1 INNER JOIN "
			strSQL &= "T_印刷ソート AS T2 ON T1.ロットID = T2.ロットID "
			strSQL &= "AND T1.レコード番号 = T2.レコード番号 INNER JOIN "
			strSQL &= "T_印刷管理 AS T3 ON T2.ロットID = T3.ロットID "
			strSQL &= "AND T2.会社コード = T3.会社コード "
			strSQL &= "AND T2.所属事業所コード = T3.所属事業所コード "
			strSQL &= "AND T2.印刷ID = T3.印刷ID "
			strSQL &= "WHERE T1.ロットID = '" & strLotID & "' "
			strSQL &= "AND T1.CSVファイル LIKE 'Leaflet%' "
			strSQL &= "GROUP BY T1.ロットID, T1.レコード番号, T1.修正済フラグ, T2.会社コード, T2.所属事業所コード, T2.印刷ID, T3.重量ヘッダ "
			strSQL &= ") AS A1"
			Dim dtLeaflet As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)

			'2018/07/31
			'BMI件数を重量ヘッダ単位で取得する
			'A～Hの件数を格納する配列を作成する
			strSQL = "SELECT ISNULL(SUM(CASE WHEN T1.重量ヘッダ = 'A' THEN 1 ELSE 0 END), 0) AS ABMI, "
			strSQL &= "ISNULL(SUM(CASE WHEN T1.重量ヘッダ = 'B' THEN 1 ELSE 0 END), 0) AS BBMI, "
			strSQL &= "ISNULL(SUM(CASE WHEN T1.重量ヘッダ = 'C' THEN 1 ELSE 0 END), 0) AS CBMI, "
			strSQL &= "ISNULL(SUM(CASE WHEN T1.重量ヘッダ = 'D' THEN 1 ELSE 0 END), 0) AS DBMI, "
			strSQL &= "ISNULL(SUM(CASE WHEN T1.重量ヘッダ = 'E' THEN 1 ELSE 0 END), 0) AS EBMI, "
			strSQL &= "ISNULL(SUM(CASE WHEN T1.重量ヘッダ = 'F' THEN 1 ELSE 0 END), 0) AS FBMI, "
			strSQL &= "ISNULL(SUM(CASE WHEN T1.重量ヘッダ = 'G' THEN 1 ELSE 0 END), 0) AS GBMI, "
			strSQL &= "ISNULL(SUM(CASE WHEN T1.重量ヘッダ = 'H' THEN 1 ELSE 0 END), 0) AS HBMI "
			strSQL &= "FROM T_印刷管理 AS T1 INNER JOIN "
			strSQL &= "T_印刷ソート AS T2 ON T1.ロットID = T2.ロットID "
			strSQL &= "AND T1.会社コード = T2.会社コード "
			strSQL &= "AND T1.所属事業所コード = T2.所属事業所コード "
			strSQL &= "AND T1.印刷ID = T2.印刷ID INNER JOIN "
			strSQL &= "T_リーフレット印刷 AS T3 ON T1.ロットID = T3.ロットID "
			strSQL &= "AND T2.システムID = T3.システムID "
			strSQL &= "WHERE T1.ロットID = '" & strLotID & "' "
			strSQL &= "AND T2.帳票種別ID = 5 "
			strSQL &= "AND T3.帳票タイプ = 'BMI'"
			'strSQL &= "GROUP BY T1.重量ヘッダ"
			Dim dtBMI As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)

			Dim iRecordCount As Integer = 0
            Me.C1FGridHeader.BeginUpdate()
            For iRow As Integer = 0 To dt.Rows.Count - 1
                iRecordCount += 1
                Me.C1FGridHeader.Rows.Count = iRecordCount + 1
                Me.C1FGridHeader(iRecordCount, "No") = iRecordCount
                Me.C1FGridHeader(iRecordCount, "ヘッダ") = dt.Rows(iRow)("ヘッダ")
                Me.C1FGridHeader(iRecordCount, "ラベル連番") = dt.Rows(iRow)("ラベル連番")
                Me.C1FGridHeader(iRecordCount, "ラベル") = dt.Rows(iRow)("ラベル")
                Me.C1FGridHeader(iRecordCount, "対象者") = dt.Rows(iRow)("対象者")
                Me.C1FGridHeader(iRecordCount, "保健指導") = dt.Rows(iRow)("保健指導")
                Me.C1FGridHeader(iRecordCount, "判定票") = dt.Rows(iRow)("判定票")
                Me.C1FGridHeader(iRecordCount, "リーフ件") = dt.Rows(iRow)("リーフ件")
                Me.C1FGridHeader(iRecordCount, "リーフ枚") = dt.Rows(iRow)("リーフ枚")
				Me.C1FGridHeader(iRecordCount, "リーフ6件") = dt.Rows(iRow)("リーフ6件")
				'2018/08/01
				'リーフ6枚の追加
				Me.C1FGridHeader(iRecordCount, "リーフ6枚") = dt.Rows(iRow)("リーフ6枚")
				Me.C1FGridHeader(iRecordCount, "リーフ重複件") = dt.Rows(iRow)("リーフ重複件")
                Me.C1FGridHeader(iRecordCount, "リーフ重複枚") = dt.Rows(iRow)("リーフ重複枚")
				'Me.C1FGridHeader(iRecordCount, "不備") = dt.Rows(iRow)("不備")
				'Me.C1FGridHeader(iRecordCount, "修正") = dt.Rows(iRow)("修正")
				'2018/03/30
				'不備、修正済を各DATATABLEから取得する
				Dim iFubi As Integer = 0
				Dim iSumi As Integer = 0
				'2018/08/01
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
				Me.C1FGridHeader(iRecordCount, "不備") = iFubi
				Me.C1FGridHeader(iRecordCount, "修正") = iSumi
				'2018/08/01
				'リーフBMI件、リーフBMI枚(件×2)をセット
				Me.C1FGridHeader(iRecordCount, "リーフBMI件") = iBMI
				Me.C1FGridHeader(iRecordCount, "リーフBMI枚") = iBMI * 2
				'2018/08/15
				'リーフ件、リーフ枚は合計数を出力するように変更したため減算しない
				''BMI件数、枚数をリーフ件、枚から減算する
				'Me.C1FGridHeader(iRecordCount, "リーフ件") -= iBMI
				'Me.C1FGridHeader(iRecordCount, "リーフ枚") -= iBMI * 2

			Next
            Me.C1FGridHeader.EndUpdate()

            '小計スタイルの設定
            Dim cs As C1.Win.C1FlexGrid.CellStyle
            cs = Me.C1FGridHeader.Styles(C1.Win.C1FlexGrid.CellStyleEnum.GrandTotal)
            cs.BackColor = Color.LightPink
            cs.ForeColor = Color.Black

            Me.C1FGridHeader.Subtotal(C1.Win.C1FlexGrid.AggregateEnum.Clear)
			For i As Integer = 5 To 18
				'項目のインデックスで回す
				Me.C1FGridHeader.Subtotal(C1.Win.C1FlexGrid.AggregateEnum.Sum, -1, -1, i, "合計")
			Next
			If Me.C1FGridHeader.Rows.Count > 1 Then
                Me.C1FGridHeader(C1FGridHeader.Rows.Count - 1, "ラベル連番") = "合計"
            End If

        Catch ex As Exception

            Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & ex.StackTrace)
            MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally

            sqlProcess.Close()

        End Try

    End Sub

    ''' <summary>
    ''' 不備内容データ表示
    ''' </summary>
    ''' <param name="strLotID"></param>
    Private Sub SearchGridDefect(ByVal strLotID As String)

        Dim sqlProcess As New SQLProcess
        Dim strSQL As String = ""

        Me.C1FGridDefect.Rows.Count = 1

        Try
            strSQL = "SELECT ロットID, レコード番号, 修正済フラグ, 会社コード, 所属事業所コード AS 局所コード, 社員コード, "
            strSQL &= "氏名姓 + ' ' + 氏名名 AS 氏名, 不備項目, 不備内容, 修正内容, CSVファイル, 帳票タイプ "
            strSQL &= "FROM T_判定票_不備内容 "
            strSQL &= "WHERE ロットID = '" & strLotID & "' "
            strSQL &= "ORDER BY 会社コード, 所属事業所コード, 社員コード"
            Dim dt As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)

            Dim iRecordCount As Integer = 0
            Me.C1FGridDefect.BeginUpdate()
            For iRow As Integer = 0 To dt.Rows.Count - 1
                iRecordCount += 1
                Me.C1FGridDefect.Rows.Count = iRecordCount + 1
                Me.C1FGridDefect(iRecordCount, "No") = iRecordCount
                Me.C1FGridDefect(iRecordCount, "ロットID") = dt.Rows(iRow)("ロットID")
                Me.C1FGridDefect(iRecordCount, "レコード番号") = dt.Rows(iRow)("レコード番号")
                Me.C1FGridDefect(iRecordCount, "修正済フラグ") = dt.Rows(iRow)("修正済フラグ")
                Me.C1FGridDefect(iRecordCount, "会社コード") = dt.Rows(iRow)("会社コード")
                Me.C1FGridDefect(iRecordCount, "局所コード") = dt.Rows(iRow)("局所コード")
                Me.C1FGridDefect(iRecordCount, "社員コード") = dt.Rows(iRow)("社員コード")
                Me.C1FGridDefect(iRecordCount, "氏名") = dt.Rows(iRow)("氏名")
                Me.C1FGridDefect(iRecordCount, "不備項目") = dt.Rows(iRow)("不備項目")
                Me.C1FGridDefect(iRecordCount, "不備内容") = dt.Rows(iRow)("不備内容")
                Me.C1FGridDefect(iRecordCount, "修正内容") = dt.Rows(iRow)("修正内容")
                Me.C1FGridDefect(iRecordCount, "CSVファイル") = dt.Rows(iRow)("CSVファイル")
                Me.C1FGridDefect(iRecordCount, "帳票タイプ") = dt.Rows(iRow)("帳票タイプ")
            Next
            Me.C1FGridDefect.EndUpdate()

            ChangeBackColorDefect()

        Catch ex As Exception

            Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & ex.StackTrace)
            MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally

            sqlProcess.Close()

        End Try

    End Sub

    ''' <summary>
    ''' インポート内容グリッドの背景色を条件によって変更する
    ''' </summary>
    Private Sub ChangeBackColor()

        'カスタムスタイルを作成する
        With Me.C1FGridResult
            '削除スタイル
            .Styles.Add("StyleDelete")
            .Styles("StyleDelete").BackColor = Color.LightSlateGray
            .Styles("StyleDelete").ForeColor = Color.White
            '修正済スタイル
            .Styles.Add("StyleChange")
            .Styles("StyleChange").BackColor = Color.White
            .Styles("StyleChange").ForeColor = Color.Black
            '要修正スタイル
            .Styles.Add("StyleIncomplete")
            .Styles("StyleIncomplete").BackColor = Color.Yellow
            .Styles("StyleIncomplete").ForeColor = Color.Black
            '印刷済スタイル
            .Styles.Add("StyleComplete")
            .Styles("StyleComplete").BackColor = Color.LightGreen
            .Styles("StyleComplete").ForeColor = Color.Black
        End With

        Me.C1FGridResult.BeginUpdate()

        For i As Integer = 1 To Me.C1FGridResult.Rows.Count - 1
            '判定票印刷日時、リーフレット印刷日時のいずれかがNULL
            If IsNull(Me.C1FGridResult(i, "判定票印刷日時")) Or IsNull(Me.C1FGridResult(i, "リーフレット印刷日時")) Then
                '修正済日時がNULL
                If IsNull(Me.C1FGridResult(i, "修正済日時")) Then
                    '要修正日時がNULL
                    If IsNull(Me.C1FGridResult(i, "要修正日時")) Then
                        'すべてNULL
                        Me.C1FGridResult.Rows(i).Style = Me.C1FGridResult.Styles("StyleChange")
                    Else
                        '要修正日時がNULLでない
                        Me.C1FGridResult.Rows(i).Style = Me.C1FGridResult.Styles("StyleIncomplete")
                    End If
                Else
                    '修正済日時がNULLでない
                    Me.C1FGridResult.Rows(i).Style = Me.C1FGridResult.Styles("StyleChange")
                End If
            Else
                '判定票、リーフレット共に印刷が完了している
                Me.C1FGridResult.Rows(i).Style = Me.C1FGridResult.Styles("StyleComplete")
            End If
        Next

        Me.C1FGridResult.EndUpdate()

    End Sub

    ''' <summary>
    ''' 不備内容グリッドの背景色を条件によって変更する
    ''' </summary>
    Private Sub ChangeBackColorDefect()

        'カスタムスタイルを作成する
        With Me.C1FGridDefect

            '修正済スタイル
            .Styles.Add("StyleChange")
            .Styles("StyleChange").BackColor = Color.DeepSkyBlue
            .Styles("StyleChange").ForeColor = Color.Black
            '要修正スタイル
            .Styles.Add("StyleIncomplete")
            .Styles("StyleIncomplete").BackColor = Color.Yellow
            .Styles("StyleIncomplete").ForeColor = Color.Black

        End With

        Me.C1FGridDefect.BeginUpdate()

        For i As Integer = 1 To Me.C1FGridDefect.Rows.Count - 1

            If Me.C1FGridDefect(i, "修正済フラグ") = True Then
                '修正済
                Me.C1FGridDefect.Rows(i).Style = Me.C1FGridDefect.Styles("StyleChange")
            Else
                '要修正
                Me.C1FGridDefect.Rows(i).Style = Me.C1FGridDefect.Styles("StyleIncomplete")
            End If
        Next

        Me.C1FGridDefect.EndUpdate()

    End Sub

	''' <summary>
	''' QRチェック件数更新
	''' '手差しリーフレット件数更新
	''' </summary>
	Private Sub UpdateProgress()

        Dim sqlProcess As New SQLProcess
        Dim strSQL As String = ""

        Try
            strSQL = "SELECT COUNT(*) AS 全数, "
            strSQL &= "ISNULL(SUM(CASE WHEN チェックフラグ = 1 THEN 1 ELSE 0 END), 0) AS 終了 "
            strSQL &= "FROM T_印刷ソート "
            strSQL &= "WHERE ロットID = '" & Me.cmbLotID.SelectedValue & "'"
            Dim dt As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)

            Me.ProgressBar1.Maximum = dt.Rows(0)("全数")
            Me.ProgressBar1.Value = dt.Rows(0)("終了")
            Me.lblCheckProgress.Text = dt.Rows(0)("終了") & " / " & dt.Rows(0)("全数")

			'2018/08/13
			'手差しリーフレット
			strSQL = "SELECT COUNT(*) AS 全数, "
			strSQL &= "ISNULL(SUM(CASE WHEN チェックフラグ = 1 THEN 1 ELSE 0 END), 0) AS 終了 "
			strSQL &= "FROM T_リーフ6チェック "
			strSQL &= "WHERE ロットID = '" & Me.cmbLotID.SelectedValue & "'"
			dt = sqlProcess.DB_SELECT_DATATABLE(strSQL)

			Me.ProgressBar2.Maximum = dt.Rows(0)("全数")
			Me.ProgressBar2.Value = dt.Rows(0)("終了")
			Me.lblHandCheckProgress.Text = dt.Rows(0)("終了") & " / " & dt.Rows(0)("全数")

		Catch ex As Exception

            Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & ex.StackTrace)
            MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally

            sqlProcess.Close()

        End Try

    End Sub

    ''' <summary>
    ''' 対象ロットの情報を取得する
    ''' </summary>
    Private Sub SearchLotInfo()

        Dim sqlProcess As New SQLProcess
        Dim strSQL As String = ""

        Try
            '2017/08/22
            'メイン画面のロット選択時に必ず実行計画のキャッシュをクリアする
            strSQL = "DBCC FREEPROCCACHE"
            sqlProcess.DB_EXECUTE_SCALAR(strSQL)

            strSQL = "SELECT 発送日, 判定票CSV, リーフレットCSV, "
            strSQL &= "ISNULL(出力日時_対象者一覧, '1900/01/01') AS 出力日時_対象者一覧, "
            strSQL &= "ISNULL(出力日時_事業所一覧, '1900/01/01') AS 出力日時_事業所一覧, "
            strSQL &= "ISNULL(出力日時_施設別件数, '1900/01/01') AS 出力日時_施設別件数, "
            strSQL &= "ISNULL(出力日時_後納票, '1900/01/01') AS 出力日時_後納票 "
            strSQL &= "FROM T_ロット管理 "
            strSQL &= "WHERE ロットID = '" & Me.cmbLotID.SelectedValue & "'"
            Dim dt As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
            If dt.Rows.Count = 1 Then
                'ロットが存在した
                Me.dtpSendDate.Value = CDate(dt.Rows(0)("発送日"))
                Me.txtCheckupCSV.Text = dt.Rows(0)("判定票CSV")
                Me.txtLeafletCSV.Text = dt.Rows(0)("リーフレットCSV")
                Me.txtTargetListDate.Text = IIf(dt.Rows(0)("出力日時_対象者一覧") = "1900/01/01", "", dt.Rows(0)("出力日時_対象者一覧"))
                Me.txtOfficeListDate.Text = IIf(dt.Rows(0)("出力日時_事業所一覧") = "1900/01/01", "", dt.Rows(0)("出力日時_事業所一覧"))
                Me.txtFacilityCountDate.Text = IIf(dt.Rows(0)("出力日時_施設別件数") = "1900/01/01", "", dt.Rows(0)("出力日時_施設別件数"))
                Me.txtSuccessDate.Text = IIf(dt.Rows(0)("出力日時_後納票") = "1900/01/01", "", dt.Rows(0)("出力日時_後納票"))
            End If

            '各種帳票チェックボックスを解除
            Me.chkTargetListDate.Checked = False
            Me.chkSuccessDate.Checked = False
            Me.chkOfficeListDate.Checked = False
            Me.chkFacilityCountDate.Checked = False

            SearchGrid(Me.cmbLotID.SelectedValue)
            SearchGridWeight(Me.cmbLotID.SelectedValue)
            SearchGridDefect(Me.cmbLotID.SelectedValue)
            UpdateProgress()

        Catch ex As Exception

            Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & ex.StackTrace)
            MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally

            sqlProcess.Close()

        End Try

    End Sub

#End Region

End Class