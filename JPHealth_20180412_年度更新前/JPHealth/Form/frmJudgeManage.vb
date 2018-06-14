Imports C1.Win.C1FlexGrid


Public Class frmJudgeManage

#Region "フォームイベント"

	''' <summary>
	''' フォームロード時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub frmJudgeManage_Load(sender As Object, e As EventArgs) Handles MyBase.Load

		Me.Text = My.Application.Info.ProductName & " Ver." &
			My.Application.Info.Version.ToString & " - [判定票管理]"

		Initialize()
		SearchGrid()

	End Sub

#End Region

#Region "オブジェクトイベント"

	Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click

		BackScreen()

	End Sub

	''' <summary>
	''' インポート日付From選択後
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub dtpImportFrom_CloseUp(sender As Object, e As EventArgs) Handles dtpImportFrom.CloseUp

		Me.txtImportFrom.Text = Strings.Format(Me.dtpImportFrom.Value, "yyyy/MM/dd")

	End Sub

	Private Sub dtpImportTo_CloseUp(sender As Object, e As EventArgs) Handles dtpImportTo.CloseUp

		Me.txtImportTo.Text = Strings.Format(Me.dtpImportTo.Value, "yyyy/MM/dd")

	End Sub

	''' <summary>
	''' インポート日クリアボタン押下時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click

		Me.txtImportFrom.Text = ""
		Me.txtImportTo.Text = ""

	End Sub

	''' <summary>
	''' 検索ボタン押下時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click

		SearchGrid()
		Me.lblProgress.Text = Me.C1FGridResult.Rows.Count - 1 & "件"

	End Sub

	''' <summary>
	''' TextBoxアクティブ時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub TextBox_Enter(sender As Object, e As EventArgs) Handles txtLimitedCode.Enter, txtLimitedCode.Enter, txtJudgeCSV.Enter, txtLeafCSV.Enter

		CType(sender, TextBox).BackColor = Color.LightGreen
		CType(sender, TextBox).SelectAll()

	End Sub

	''' <summary>
	''' TextBoxリーブ時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub TextBox_Leave(sender As Object, e As EventArgs) Handles txtLimitedCode.Leave, txtLimitedCode.Leave, txtJudgeCSV.Leave, txtLeafCSV.Leave

		CType(sender, TextBox).BackColor = System.Drawing.SystemColors.Window

	End Sub

	''' <summary>
	''' CSV出力ボタン押下時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub btnOutputCSV_Click(sender As Object, e As EventArgs) Handles btnOutputCSV.Click

		OutputCSVFile(Me.C1FGridResult, Date.Now.ToString("yyyyMMdd") & "_検索結果.csv")

	End Sub

	''' <summary>
	''' インポートボタン押下時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub btnImport_Click(sender As Object, e As EventArgs) Handles btnImport.Click

		Dim f As New frmImport
		f.ShowDialog()
		SearchGrid()

	End Sub

	''' <summary>
	''' 修正記録ボタン押下時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub btnVariousOutput_Click(sender As Object, e As EventArgs) Handles btnVariousOutput.Click

		Dim f As New frmVariousOutput
		f.ShowDialog()
		SearchGrid()

	End Sub

	''' <summary>
	''' 印刷ボタン押下時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click

		Dim f As New frmPrint
		f.ShowDialog()
		SearchGrid()

	End Sub


#End Region

#Region "プライベートメソッド"

	''' <summary>
	''' 初期化処理
	''' </summary>
	Private Sub Initialize()

		Dim sqlProcess As New SQLProcess
		Dim strSQL As String = ""

		Try
			'会社コードコンボボックスに値をセットする
			strSQL = "SELECT 会社コード AS ID, 会社コード AS NAME FROM M_局所 "
			strSQL &= "GROUP BY 会社コード "
			strSQL &= "ORDER BY 会社コード"
			Dim dt As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
			SetComboValue(Me.cmbCompanyCode, dt)

			'インポート日From、Toの日付を本日に
			Me.txtImportFrom.Text = Strings.Format(Date.Now, "yyyy/MM/dd")
			Me.txtImportTo.Text = Strings.Format(Date.Now, "yyyy/MM/dd")
			'終了ボタンのテキストを「戻る」にする
			Me.btnBack.Text = "戻る"
			'コンピュータ名の表示
			Me.lblUser.Text = My.Computer.Name
			Me.lblProgress.Text = ""

			ClearValue()

		Catch ex As Exception

            Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & ex.StackTrace)
            MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally

            sqlProcess.Close()

        End Try

    End Sub

    ''' <summary>
    ''' メインメニューへ戻る
    ''' </summary>
    Private Sub BackScreen()

        Dim f As New frmMainMenu
        m_Context.SetNextContext(f)

    End Sub
    ''' <summary>
    ''' 検索処理
    ''' </summary>
    Private Sub SearchGrid()

        Dim sqlProcess As New SQLProcess
        Dim strSQL As String = ""
        Me.C1FGridResult.Rows.Count = 1

        Try
            Dim strWhere As String = " WHERE "
            strSQL = "SELECT インポート日時, 判定票CSV, 会社コード, 所属事業所コード AS 局所コード, 社員コード, "
            strSQL &= "ISNULL(要修正日時, '1900/01/01') AS 要修正日時, ISNULL(修正済日時, '1900/01/01') AS 修正済日時, "
            strSQL &= "ISNULL(判定票印刷日時, '1900/01/01') AS 判定票印刷日時, ISNULL(リーフレット印刷日時, '1900/01/01') AS リーフレット印刷日時, "
            strSQL &= "ISNULL(完了日時, '1900/01/01') AS 完了日時, ISNULL(削除日時, '1900/01/01') AS 削除日時, "
            strSQL &= "重量, ロットID, レコード番号 "
            strSQL &= "FROM T_判定票管理 "
            '検索条件
            'インポート日時
            If IsNull(Me.txtImportFrom.Text) = False And IsNull(Me.txtImportTo.Text) Then
                'Fromのみ入力
                strSQL &= strWhere & "インポート日時 >= '" & Me.txtImportFrom.Text & " 00:00:00'"
                strWhere = " AND "
            ElseIf IsNull(Me.txtImportFrom.Text) And IsNull(Me.txtImportTo.Text) = False Then
                'Toのみ入力
                strSQL &= strWhere & "インポート日時 <= '" & Me.txtImportTo.Text & " 23:59:59'"
            ElseIf IsNull(Me.txtImportFrom.Text) = False And IsNull(Me.txtImportTo.Text) = False Then
                'どちらも入力されている
                strSQL &= strWhere & "インポート日時 BETWEEN '" & Me.txtImportFrom.Text & " 00:00:00' AND '" & Me.txtImportTo.Text & " 23:59:59'"
                strWhere = " AND "
            End If
            '会社コード
            If Me.cmbCompanyCode.SelectedIndex <> 0 Then
                '全て以外を選択した場合
                strSQL &= strWhere & "会社コード = '" & Me.cmbCompanyCode.SelectedItem & "'"
                strWhere = " AND "
            End If
            '局所コード
            If Not IsNull(Me.txtLimitedCode.Text) Then
                '入力されていたら
                strSQL &= strWhere & "所属事業所コード LIKE '%" & Trim(Me.txtLimitedCode.Text) & "%'"
                strWhere = " AND "
            End If
            '社員コード
            If Not IsNull(Me.txtEmployeeCode.Text) Then
                '入力されていたら
                strSQL &= strWhere & "社員コード LIKE '%" & Trim(Me.txtEmployeeCode.Text) & "%'"
                strWhere = " AND "
            End If
            '判定票CSV
            If Not IsNull(Me.txtJudgeCSV.Text) Then
                '入力されていたら
                strSQL &= strWhere & "判定票CSV LIKE '%" & Trim(Me.txtJudgeCSV.Text) & "%'"
                strWhere = " AND "
            End If
            'リーフレットCSV
            If Not IsNull(Me.txtLeafCSV.Text) Then
                '入力されていたら
                strSQL &= strWhere & "リーフレットCSV LIKE '%" & Trim(Me.txtLeafCSV.Text) & "%'"
                strWhere = " AND "
            End If
            '要修正フラグ
            If Me.cmbDoEdit.SelectedIndex = 1 Then
                'フラグあり
                strSQL &= strWhere & "ISNULL(要修正日時, '1900/01/01') != '1900/01/01'"
                strWhere = " AND "
            ElseIf Me.cmbDoEdit.SelectedIndex = 2 Then
                'フラグなし
                strSQL &= strWhere & "ISNULL(要修正日時, '1900/01/01') = '1900/01/01'"
                strWhere = " AND "
            End If
            '修正済フラグ
            If Me.cmbCorrected.SelectedIndex = 1 Then
                'フラグあり
                strSQL &= strWhere & "ISNULL(修正済日時, '1900/01/01') != '1900/01/01'"
                strWhere = " AND "
            ElseIf Me.cmbCorrected.SelectedIndex = 2 Then
                'フラグなし
                strSQL &= strWhere & "ISNULL(修正済日時, '1900/01/01') = '1900/01/01'"
                strWhere = " AND "
            End If
            '判定票印刷フラグ
            If Me.cmbCheckupPrinted.SelectedIndex = 1 Then
                'フラグあり
                strSQL &= strWhere & "ISNULL(判定票印刷日時, '1900/01/01') != '1900/01/01'"
                strWhere = " AND "
            ElseIf Me.cmbCheckupPrinted.SelectedIndex = 2 Then
                'フラグなし
                strSQL &= strWhere & "ISNULL(判定票印刷日時, '1900/01/01') = '1900/01/01'"
                strWhere = " AND "
            End If
            'リーフレット印刷フラグ
            If Me.cmbLeafletPrinted.SelectedIndex = 1 Then
                'フラグあり
                strSQL &= strWhere & "ISNULL(リーフレット印刷日時, '1900/01/01') != '1900/01/01'"
                strWhere = " AND "
            ElseIf Me.cmbLeafletPrinted.SelectedIndex = 2 Then
                'フラグなし
                strSQL &= strWhere & "ISNULL(リーフレット印刷日時, '1900/01/01') = '1900/01/01'"
                strWhere = " AND "
            End If
            '完了フラグ
            If Me.cmbCompleted.SelectedIndex = 1 Then
                'フラグあり
                strSQL &= strWhere & "ISNULL(完了日時, '1900/01/01') != '1900/01/01'"
                strWhere = " AND "
            ElseIf Me.cmbCompleted.SelectedIndex = 2 Then
                'フラグなし
                strSQL &= strWhere & "ISNULL(完了日時, '1900/01/01') = '1900/01/01'"
                strWhere = " AND "
            End If
            '削除フラグ
            If Me.cmbDeleted.SelectedIndex = 1 Then
                'フラグあり
                strSQL &= strWhere & "ISNULL(削除日時, '1900/01/01') != '1900/01/01'"
                strWhere = " AND "
            ElseIf Me.cmbDeleted.SelectedIndex = 2 Then
                'フラグなし
                strSQL &= strWhere & "ISNULL(削除日時, '1900/01/01') = '1900/01/01'"
                strWhere = " AND "
            End If

            strSQL &= " ORDER BY インポート日時, 会社コード, 所属事業所コード, 社員コード"

            Dim dt As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
            Dim iRecordCount As Integer = 0

            Me.C1FGridResult.BeginUpdate()
            For iRow As Integer = 0 To dt.Rows.Count - 1
                iRecordCount += 1
                Me.C1FGridResult.Rows.Count = iRecordCount + 1
                Me.C1FGridResult(iRecordCount, "インポート日時") = dt.Rows(iRow)("インポート日時")
                Me.C1FGridResult(iRecordCount, "判定票CSV") = dt.Rows(iRow)("判定票CSV")
                Me.C1FGridResult(iRecordCount, "会社コード") = dt.Rows(iRow)("会社コード")
                Me.C1FGridResult(iRecordCount, "局所コード") = dt.Rows(iRow)("局所コード")
                Me.C1FGridResult(iRecordCount, "社員コード") = dt.Rows(iRow)("社員コード")
                Me.C1FGridResult(iRecordCount, "要修正日時") = IIf(dt.Rows(iRow)("要修正日時") = "1900/01/01", "", dt.Rows(iRow)("要修正日時"))
                Me.C1FGridResult(iRecordCount, "修正済日時") = IIf(dt.Rows(iRow)("修正済日時") = "1900/01/01", "", dt.Rows(iRow)("修正済日時"))
                Me.C1FGridResult(iRecordCount, "判定票印刷日時") = IIf(dt.Rows(iRow)("判定票印刷日時") = "1900/01/01", "", dt.Rows(iRow)("判定票印刷日時"))
                Me.C1FGridResult(iRecordCount, "リーフレット印刷日時") = IIf(dt.Rows(iRow)("リーフレット印刷日時") = "1900/01/01", "", dt.Rows(iRow)("リーフレット印刷日時"))
                Me.C1FGridResult(iRecordCount, "完了日時") = IIf(dt.Rows(iRow)("完了日時") = "1900/01/01", "", dt.Rows(iRow)("完了日時"))
                Me.C1FGridResult(iRecordCount, "削除日時") = IIf(dt.Rows(iRow)("削除日時") = "1900/01/01", "", dt.Rows(iRow)("削除日時"))
                Me.C1FGridResult(iRecordCount, "重量") = dt.Rows(iRow)("重量")
                Me.C1FGridResult(iRecordCount, "ロットID") = dt.Rows(iRow)("ロットID")
                Me.C1FGridResult(iRecordCount, "レコード番号") = dt.Rows(iRow)("レコード番号")

            Next
            Me.C1FGridResult.EndUpdate()

        Catch ex As Exception

            Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & ex.StackTrace)
            MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally

            sqlProcess.Close()

        End Try

    End Sub

    ''' <summary>
    ''' 各ステータス毎の件数を取得する
    ''' </summary>
    Private Sub SearchCount()

        'C1FGridCountの初期化
        Me.C1FGridCount.Rows.Count = 2
        Me.C1FGridCount(1, 0) = "総件数"   '行ヘッダの項目名をセットする

        Dim sqlProcess As New SQLProcess
        Dim strSQL As String = ""

        Try
            '総件数を取得
            strSQL = "SELECT COUNT(インポート日時) FROM T_判定票管理"
            Dim iTotalCount As Integer = sqlProcess.DB_EXECUTE_SCALAR(strSQL)
            ''n日経過件数
            ''インポート日時以外NULLのレコードをインポート日時単位でグルーピングしカウントを取る
            ''エクスポート日時は考慮しない
            'strSQL = "SELECT インポート日時, COUNT(インポート日時) FROM " & Me.ManageTable & " "
            'strSQL &= "WHERE ISNULL(インポート日時, '') != '' AND ISNULL(要修正日時, '') = '' AND ISNULL(修正済日時, '') = '' "
            'strSQL &= "AND ISNULL(完了日時, '') = '' AND ISNULL(削除日時, '') = '' "
            'strSQL &= "GROUP BY インポート日時"
            'Dim dtToday As Date = Date.Now
            'Dim iIncompleteCount As Integer = 0

            'dr = sqlProcess.DB_SELECT_READER(strSQL)
            'Do While dr.Read()
            '	Dim dtImportDate As Date = dr.GetDateTime(0)
            '	If DateDiff("d", dtToday, getBusinessDay(dtImportDate, CInt(strGetProfile("Day", "Alert")))) <= 0 Then
            '		'本日以降経過していたら
            '		iIncompleteCount += dr.GetInt32(1)
            '	End If
            'Loop
            'dr.Close()
            ''修正済日時までNULLでないレコードをインポート日時単位でグルーピングしカウントを取る
            ''エクスポート日時は考慮しない
            'strSQL = "SELECT インポート日時, COUNT(インポート日時) FROM " & Me.ManageTable & " "
            'strSQL &= "WHERE ISNULL(修正済日時, '') != '' "
            'strSQL &= "AND ISNULL(完了日時, '') = '' AND ISNULL(削除日時, '') = '' "
            'strSQL &= "GROUP BY インポート日時"

            'dr = sqlProcess.DB_SELECT_READER(strSQL)
            'Do While dr.Read()
            '	Dim dtImportDate As Date = dr.GetDateTime(0)
            '	If DateDiff("d", dtToday, getBusinessDay(dtImportDate, CInt(strGetProfile("Day", "Alert")))) <= 0 Then
            '		'本日以降経過していたら
            '		iIncompleteCount += dr.GetInt32(1)
            '	End If
            'Loop
            'dr.Close()

            '要修正件数(修正済日時がNULLのレコードのみ)
            strSQL = "SELECT COUNT(要修正日時) FROM T_判定票管理 "
            strSQL &= "WHERE ISNULL(要修正日時, '1900/01/01') != '1900/01/01 AND ISNULL(修正済日時, '1900/01/01') = '1900/01/01' "
            strSQL &= "AND ISNULL(判定票印刷日時, '1900/01/01') = '1900/01/01' AND ISNULL(完了日時, '1900/01/01) = '1900/01/01 "
            strSQL &= "AND ISNULL(削除日時, '1900/01/01') = '1900/01/01'"
            Dim iDoCorrectCount As Integer = sqlProcess.DB_EXECUTE_SCALAR(strSQL)
            '修正済件数
            '印刷日時、完了日時は考慮しない
            strSQL = "SELECT COUNT(修正済日時) FROM T_判定票管理 "
            strSQL &= "WHERE ISNULL(修正済日時, '1900/01/01') != '1900/01/01' "
            strSQL &= "AND ISNULL(削除日時, '1900/01/01') = '1900/01/01'"
            Dim iCorrectedCount As Integer = sqlProcess.DB_EXECUTE_SCALAR(strSQL)
            '修正記録出力件数
            strSQL = "SELECT COUNT(修正記録出力) FROM T_判定票管理 "
            strSQL &= "WHERE 修正記録出力 = 1 AND ISNULL(削除日時, '1900/01/01') = '1900/01/01'"
            Dim iCorrectedOutputCount As Integer = sqlProcess.DB_EXECUTE_SCALAR(strSQL)
            '印刷可能件数
            strSQL = "SELECT COUNT(インポート日時) FROM T_判定票管理 "
            strSQL &= "WHERE ISNULL(要修正日時, '1900/01/01') = '1900/01/01' AND ISNULL(修正済日時, '1900/01/01') = '1900/01/01' "
            strSQL &= "AND ISNULL(判定票印刷日時, '1900/01/01') = '1900/01/01' AND ISNULL(完了日時, '1900/01/01') = '1900/01/01' "
            strSQL &= "AND ISNULL(削除日時, '1900/01/01') = '1900/01/01'"
            Dim iCanPrintCount As Integer = sqlProcess.DB_EXECUTE_SCALAR(strSQL)
            '印刷件数
            '完了日時は考慮しない
            strSQL = "SELECT COUNT(判定票印刷日時) FROM T_判定票管理 "
            strSQL &= "WHERE ISNULL(判定票印刷日時, '1900/01/01) != '1900/01/01 AND ISNULL(削除日時, '1900/01/01') = '1900/01/01'"
            Dim iPrintedCount As Integer = sqlProcess.DB_EXECUTE_SCALAR(strSQL)
            '完了件数
            strSQL = "SELECET COUNT(完了日時) FROM T_判定票管理 "
            strSQL &= "WHERE ISNULL(完了日時, '1900/01/01') != '1900/01/01' AND ISNULL(削除日時, '1900/01/01') = '1900/01/01'"
            Dim iCompletedCount As Integer = sqlProcess.DB_EXECUTE_SCALAR(strSQL)
            '削除件数
            strSQL = "SELECT COUNT(削除日時) FROM T_判定票管理 "
            strSQL &= "WHERE ISNULL(削除日時, '1900/01/01') != '1900/01/01'"
            Dim iDeletedCount As Integer = sqlProcess.DB_EXECUTE_SCALAR(strSQL)

            'C1FGridCountに値をセット
            Me.C1FGridCount(1, 1) = iTotalCount '総件数
            Me.C1FGridCount(1, 2) = iDoCorrectCount '要修正件数
            Me.C1FGridCount(1, 3) = iCorrectedCount '修正済件数
            Me.C1FGridCount(1, 4) = iCorrectedOutputCount   '修正記録出力件数
            Me.C1FGridCount(1, 5) = iCanPrintCount  '印刷可能件数
            Me.C1FGridCount(1, 6) = iPrintedCount   '印刷済件数
            Me.C1FGridCount(1, 7) = iCompletedCount '完了件数
            Me.C1FGridCount(1, 8) = iDeletedCount   '削除件数

            '各セルにスタイルを設定
            Dim styleTotal As CellStyle = Me.C1FGridCount.Styles.Add("Total")
            styleTotal.ForeColor = Color.Black
            styleTotal.BackColor = Color.White
            'Dim styleIncomplete As CellStyle = Me.C1FGridCount.Styles.Add("Incomplete")
            'styleIncomplete.ForeColor = Color.White
            'styleIncomplete.BackColor = Color.Red
            Dim styleDoCorrect As CellStyle = Me.C1FGridCount.Styles.Add("DoCorrect")
            styleDoCorrect.ForeColor = Color.Black
            styleDoCorrect.BackColor = Color.Yellow
            Dim styleCorrected As CellStyle = Me.C1FGridCount.Styles.Add("Corrected")
            styleCorrected.ForeColor = Color.Black
            styleCorrected.BackColor = Color.White
            Dim styleCorrectedOutput As CellStyle = Me.C1FGridCount.Styles.Add("CorrectedOutput")
            styleCorrectedOutput.ForeColor = Color.Black
            styleCorrectedOutput.BackColor = Color.White
            Dim styleCanExport As CellStyle = Me.C1FGridCount.Styles.Add("CanPrint")
            styleCanExport.ForeColor = Color.Black
            styleCanExport.BackColor = Color.White
            Dim styleExported As CellStyle = Me.C1FGridCount.Styles.Add("Printed")
            styleExported.ForeColor = Color.Black
            styleExported.BackColor = Color.LightGreen
            Dim styleCompleted As CellStyle = Me.C1FGridCount.Styles.Add("Completed")
            styleCompleted.ForeColor = Color.Black
            styleCompleted.BackColor = Color.DeepSkyBlue
            Dim styleDeleted As CellStyle = Me.C1FGridCount.Styles.Add("Deleted")
            styleDeleted.ForeColor = Color.White
            styleDeleted.BackColor = Color.LightSlateGray

            Me.C1FGridCount.Cols(1).Style = Me.C1FGridCount.Styles("Total")
            'Me.C1FGridCount.Cols(2).Style = Me.C1FGridCount.Styles("Incomplete")
            Me.C1FGridCount.Cols(2).Style = Me.C1FGridCount.Styles("DoCorrect")
            Me.C1FGridCount.Cols(3).Style = Me.C1FGridCount.Styles("Corrected")
            Me.C1FGridCount.Cols(4).Style = Me.C1FGridCount.Styles("CorrectedOutput")
            Me.C1FGridCount.Cols(5).Style = Me.C1FGridCount.Styles("CanExport")
            Me.C1FGridCount.Cols(6).Style = Me.C1FGridCount.Styles("Exported")
            Me.C1FGridCount.Cols(7).Style = Me.C1FGridCount.Styles("Completed")
            Me.C1FGridCount.Cols(8).Style = Me.C1FGridCount.Styles("Deleted")

        Catch ex As Exception

            Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & ex.StackTrace)
            MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		Finally

			sqlProcess.Close()

		End Try

	End Sub

	''' <summary>
	''' 入力内容を初期化する
	''' </summary>
	Private Sub ClearValue()

		Me.txtImportFrom.Text = Strings.Format(Me.dtpImportFrom.Value, "yyyy/MM/dd")
		Me.txtImportTo.Text = Strings.Format(Me.dtpImportTo.Value, "yyyy/MM/dd")
		Me.cmbCompanyCode.SelectedIndex = 0
		Me.txtLimitedCode.Text = ""
		Me.txtEmployeeCode.Text = ""
		Me.txtJudgeCSV.Text = ""
		Me.txtLeafCSV.Text = ""
		Me.cmbDoEdit.SelectedIndex = 0
		Me.cmbCorrected.SelectedIndex = 0
		Me.cmbCheckupPrinted.SelectedIndex = 0
		Me.cmbLeafletPrinted.SelectedIndex = 0
		Me.cmbCompleted.SelectedIndex = 0
		Me.cmbDeleted.SelectedIndex = 0

	End Sub

	''' <summary>
	''' ステータスによってグリッドのレコードの背景色を変更する
	''' </summary>
	Private Sub ChangeBackColor()

		'カスタムスタイルを作成する
		With C1FGridResult

			'削除スタイル
			.Styles.Add("StyleDelete")
			.Styles("StyleDelete").BackColor = Color.LightSlateGray
			.Styles("StyleDelete").ForeColor = Color.White
			'完了スタイル
			.Styles.Add("StyleComplete")
			.Styles("StyleComplete").BackColor = Color.DeepSkyBlue
			.Styles("StyleComplete").ForeColor = Color.Black
			''n日経過スタイル
			'.Styles.Add("StyleNDay")
			'.Styles("StyleNDay").BackColor = Color.Red
			'.Styles("StyleNDay").ForeColor = Color.White
			'印刷スタイル
			.Styles.Add("StylePrint")
			.Styles("StylePrint").BackColor = Color.LightGreen
			.Styles("StylePrint").ForeColor = Color.Black
			'修正済スタイル
			.Styles.Add("StyleChange")
			.Styles("StyleChange").BackColor = Color.White
			.Styles("StyleChange").ForeColor = Color.Black
			'要修正スタイル
			.Styles.Add("StyleIncomplete")
			.Styles("StyleIncomplete").BackColor = Color.Yellow
			.Styles("StyleIncomplete").ForeColor = Color.Black

		End With

		For iRow As Integer = 0 To Me.C1FGridResult.Rows.Count - 1
			'削除日がNULL
			If IsNull(Me.C1FGridResult(iRow, "削除日時")) Then
				'完了日がNULL
				If IsNull(Me.C1FGridResult(iRow, "完了日時")) Then
					'印刷日がNULL
					If IsNull(Me.C1FGridResult(iRow, "判定票印刷日時")) Then
						'修正済日時がNULL
						If IsNull(Me.C1FGridResult(iRow, "修正済日時")) Then
							'要修正日時がNULL
							If IsNull(Me.C1FGridResult(iRow, "要修正日時")) Then
								'全てNULL
								Me.C1FGridResult.Rows(iRow).Style = Me.C1FGridResult.Styles("StyleChange")
							Else
								'要修正日時がNULLでない
								Me.C1FGridResult.Rows(iRow).Style = Me.C1FGridResult.Styles("StyleIncomplete")
							End If
						Else
							'修正済日時がNULLでない
							Me.C1FGridResult.Rows(iRow).Style = Me.C1FGridResult.Styles("StyleChange")
						End If
					Else
						'印刷日がNULLでない
						Me.C1FGridResult.Rows(iRow).Style = Me.C1FGridResult.Styles("StylePrint")
					End If
				Else
					'完了日がNULLでない
					Me.C1FGridResult.Rows(iRow).Style = Me.C1FGridResult.Styles("StyleComplete")
				End If
			Else
				'削除日がNULLでない
				Me.C1FGridResult.Rows(iRow).Style = Me.C1FGridResult.Styles("StyleDelete")
			End If
		Next

	End Sub

	'''' <summary>
	'''' ステータスでFlexGridの背景色を変更するプロシージャ
	'''' </summary>
	'''' <remarks></remarks>
	'Private Sub ChangeBackColor2()

	'	'カスタムスタイルを作成する
	'	With C1FGridResult

	'		'削除スタイル
	'		.Styles.Add("StyleDelete")
	'		.Styles("StyleDelete").BackColor = Color.LightSlateGray
	'		.Styles("StyleDelete").ForeColor = Color.White
	'		'完了スタイル
	'		.Styles.Add("StyleComplete")
	'		.Styles("StyleComplete").BackColor = Color.DeepSkyBlue
	'		.Styles("StyleComplete").ForeColor = Color.Black
	'		'n日経過スタイル
	'		.Styles.Add("StyleNDay")
	'		.Styles("StyleNDay").BackColor = Color.Red
	'		.Styles("StyleNDay").ForeColor = Color.White
	'		'エクスポートスタイル
	'		.Styles.Add("StyleExport")
	'		.Styles("StyleExport").BackColor = Color.LightGreen
	'		.Styles("StyleExport").ForeColor = Color.Black
	'		'修正済スタイル
	'		.Styles.Add("StyleChange")
	'		.Styles("StyleChange").BackColor = Color.White
	'		.Styles("StyleChange").ForeColor = Color.Black
	'		'要修正スタイル
	'		.Styles.Add("StyleIncomplete")
	'		.Styles("StyleIncomplete").BackColor = Color.Yellow
	'		.Styles("StyleIncomplete").ForeColor = Color.Black

	'	End With



	'	Dim dtToday As Date = Date.Now  '本日を取得

	'	'1レコード目はヘッダなので2レコード目(1)から開始
	'	For i As Integer = 1 To Me.C1FGridResult.Rows.Count - 1
	'		'削除日がNULL
	'		If IsNull(Me.C1FGridResult(i, 10).ToString) Then
	'			'完了日がNULL
	'			If IsNull(Me.C1FGridResult(i, 9).ToString) Then
	'				'インポート日からn日後経過していない
	'				If DateDiff("d", dtToday, getBusinessDay(CDate(Me.C1FGridResult(i, 1).ToString), CInt(strGetProfile("Day", "Alert")))) > 0 Then
	'					'エクスポート日がNULL
	'					If IsNull(Me.C1FGridResult(i, 8).ToString) Then
	'						'修正済日時がNULL
	'						If IsNull(Me.C1FGridResult(i, 7).ToString) Then
	'							'要修正日時がNULL
	'							If IsNull(Me.C1FGridResult(i, 6).ToString) Then
	'								'全てNULL
	'								Me.C1FGridResult.Rows(i).Style = Me.C1FGridResult.Styles("StyleChange")
	'							Else
	'								'要修正日時がNULLでない
	'								Me.C1FGridResult.Rows(i).Style = Me.C1FGridResult.Styles("StyleIncomplete")
	'							End If

	'						Else
	'							'修正済日時がNULLでない
	'							Me.C1FGridResult.Rows(i).Style = Me.C1FGridResult.Styles("StyleChange")
	'						End If

	'					Else
	'						'エクスポート日がNULLでない
	'						Me.C1FGridResult.Rows(i).Style = Me.C1FGridResult.Styles("StyleExport")
	'					End If

	'				Else
	'					'インポート日からn日経過している
	'					If IsNull(Me.C1FGridResult(i, 6).ToString) = False And IsNull(Me.C1FGridResult(i, 7).ToString) Then
	'						'要修正日時に値が入っていて修正済日時がNULLであった場合
	'						Me.C1FGridResult.Rows(i).Style = Me.C1FGridResult.Styles("StyleIncomplete")
	'					Else
	'						'それ以外は全て赤
	'						Me.C1FGridResult.Rows(i).Style = Me.C1FGridResult.Styles("StyleNDay")
	'					End If

	'				End If

	'			Else
	'				'完了日がNULLでない
	'				Me.C1FGridResult.Rows(i).Style = Me.C1FGridResult.Styles("StyleComplete")
	'			End If

	'		Else
	'			'削除日がNULLでない
	'			Me.C1FGridResult.Rows(i).Style = Me.C1FGridResult.Styles("StyleDelete")
	'		End If

	'	Next

	'End Sub

#End Region

End Class