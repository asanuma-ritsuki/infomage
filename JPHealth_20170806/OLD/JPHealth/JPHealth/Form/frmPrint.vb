Public Class frmPrint

#Region "フォームイベント"

	''' <summary>
	''' フォームロード時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub frmPrint_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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
	Private Sub txtPDFPath_DragEnter(sender As Object, e As DragEventArgs) Handles txtPDFPath.DragEnter

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
	Private Sub txtPDFPath_DragDrop(sender As Object, e As DragEventArgs) Handles txtPDFPath.DragDrop

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
	''' PDF出力フォルダブラウズボタン押下時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub btnPDFPathBrowse_Click(sender As Object, e As EventArgs) Handles btnPDFPathBrowse.Click

		Me.txtPDFPath.Text = FolderBrowse(Me.txtPDFPath)

	End Sub

    ''' <summary>
    ''' 閉じるボタン押下時
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click

        XmlSettings.LoadFromXmlFile()
        XmlSettings.Instance.SentlistTray = Me.cmbSentlistTray.SelectedIndex
        XmlSettings.Instance.ResultTray = Me.cmbResultTray.SelectedIndex
        XmlSettings.Instance.LeafletTray = Me.cmbLeafletTray.SelectedIndex
        XmlSettings.Instance.PDFPath = Me.txtPDFPath.Text
		XmlSettings.SaveToXmlFile()

		Me.Close()

	End Sub

	''' <summary>
	''' インポート日時インデックス変更時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub cmbLotID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbLotID.SelectedIndexChanged

		Dim strLotID As String = Me.cmbLotID.SelectedValue
		Dim sqlProcess As New SQLProcess
		Dim strSQL As String = ""

        Try
            '==================================================
            'ロット単位の集計結果表示
            strSQL = "SELECT ISNULL(SUM(CASE WHEN 帳票種別ID = 0 THEN 1 ELSE 0 END), 0) AS ラベル, "
            strSQL &= "ISNULL(SUM(CASE WHEN 帳票種別ID = 2 THEN 1 ELSE 0 END), 0) AS 対象者一覧, "
            strSQL &= "ISNULL(SUM(CASE WHEN 帳票種別ID = 3 THEN 1 ELSE 0 END), 0) AS 保健指導名簿, "
            strSQL &= "ISNULL(SUM(CASE WHEN 帳票種別ID = 4 THEN 1 ELSE 0 END), 0) AS 就業判定票 "
            'strSQL &= "ISNULL(SUM(CASE WHEN T1.帳票種別ID = 5 AND T2.リーフレット枚数 <= 5 THEN 1 ELSE 0 END), 0) AS リーフレット, "
            'strSQL &= "ISNULL(SUM(CASE WHEN T1.帳票種別ID = 5 AND T2.リーフレット枚数 >= 6 THEN 1 ELSE 0 END), 0) AS リーフレット6 "
            strSQL &= "FROM T_印刷ソート "
            'strSQL &= "T_判定票管理 As T2 On T1.ロットID = T2.ロットID And T1.レコード番号 = T2.レコード番号 "
            strSQL &= "WHERE ロットID = '" & strLotID & "'"
            Dim dt As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
            '必ず1レコード取得
            Me.txtCountLabel.Text = dt.Rows(0)("ラベル")
            Me.txtCountCheckupList.Text = dt.Rows(0)("対象者一覧")
            Me.txtCountLeafletList.Text = dt.Rows(0)("保健指導名簿")
            Me.txtCountCheckup.Text = dt.Rows(0)("就業判定票")

            'リーフレットは5枚以下と6枚以上で分ける
            strSQL = "SELECT ISNULL(SUM(CASE WHEN T2.リーフレット枚数 <= 5 THEN 1 ELSE 0 END), 0) AS リーフレット, "
            strSQL &= "ISNULL(SUM(CASE WHEN T2.リーフレット枚数 >= 6 THEN 1 ELSE 0 END), 0) AS リーフレット6 "
            strSQL &= "FROM T_印刷ソート AS T1 INNER JOIN "
            strSQL &= "T_判定票管理 AS T2 ON T1.ロットID = T2.ロットID AND T1.レコード番号 = T2.レコード番号 "
            strSQL &= "WHERE T1.ロットID = '" & strLotID & "' "
            strSQL &= "AND T1.帳票種別ID = 5"
            dt = sqlProcess.DB_SELECT_DATATABLE(strSQL)
            Me.txtCountLeaflet.Text = dt.Rows(0)("リーフレット")
            Me.txtCountLeaflet6.Text = dt.Rows(0)("リーフレット6")
            '==================================================
            'グリッドの表示
            SearchGrid()

        Catch ex As Exception

            Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message)
            MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally

            sqlProcess.Close()

		End Try

	End Sub

	''' <summary>
	''' 印刷ボタン押下時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click

		If Me.cmbPrintClass.SelectedIndex < 0 Then
			MessageBox.Show("印刷対象を選択してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Exit Sub
		End If

        'If Not System.IO.Directory.Exists(Me.txtPDFPath.Text) Then
        '	MessageBox.Show("有効なPDF出力先フォルダを選択してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '	Exit Sub
        'End If
        Dim blnPrintWeightHeader As Boolean = True  'TRUE：重量ヘッダ単位、FALSE：個別印刷

        If Me.chkSelectedPrint.Checked Then
            '個別印刷
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

            If MessageBox.Show("選択対象を印刷します" & vbNewLine & "インポート日時：" & Me.cmbLotID.SelectedItem.ToString & vbNewLine & "印刷対象：" & Me.cmbPrintClass.SelectedItem.ToString & vbNewLine &
                               "選択件数：" & iChecked & "件" & vbNewLine & "※個別選択した場合、重量ヘッダは出力されません" & vbNewLine & "よろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                Exit Sub
            End If

            blnPrintWeightHeader = False    '個別印刷
        Else
            '重量単位の印刷
            If Me.cmbWeightHeader.SelectedIndex < 0 Then
                MessageBox.Show("重量ヘッダを選択してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            If MessageBox.Show("選択対象を印刷します" & vbNewLine & "インポート日時：" & Me.cmbLotID.SelectedItem.ToString & vbNewLine & "印刷対象：" & Me.cmbPrintClass.SelectedItem.ToString & vbNewLine &
                               "重量ヘッダ：" & Me.cmbWeightHeader.SelectedItem.ToString & vbNewLine & "よろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                Exit Sub
            End If

            blnPrintWeightHeader = True '重量ヘッダ単位印刷
        End If

        XmlSettings.LoadFromXmlFile()
		XmlSettings.Instance.Printer_Sentlist = Me.txtSentlist.Text
		XmlSettings.Instance.Printer_Result = Me.txtResult.Text
		XmlSettings.Instance.Printer_Leaflet = Me.txtLeaflet.Text
		XmlSettings.Instance.SentlistTray = Me.cmbSentlistTray.SelectedItem
		XmlSettings.Instance.ResultTray = Me.cmbResultTray.SelectedItem
		XmlSettings.Instance.LeafletTray = Me.cmbLeafletTray.SelectedItem
		XmlSettings.SaveToXmlFile()

		Select Case Me.cmbPrintClass.SelectedIndex
			Case 0
                'ラベル
                'MessageBox.Show("ラベル印刷")
                PrintLabel(Me.cmbLotID.SelectedValue, blnPrintWeightHeader, Me.cmbWeightHeader.SelectedItem.ToString)

            Case 1
                '重量ヘッダシート、対象者一覧、保健指導名簿、判定票
                'MessageBox.Show("就業判定票印刷")
                PrintCheckup(Me.cmbLotID.SelectedValue, blnPrintWeightHeader, Me.cmbWeightHeader.SelectedItem.ToString)
            Case 2
                '重量ヘッダ、リーフレット
                'MessageBox.Show("リーフレット印刷")
                PrintLeaflet(Me.cmbLotID.SelectedValue, blnPrintWeightHeader, Me.cmbWeightHeader.SelectedItem.ToString)
        End Select

        MessageBox.Show("印刷処理が完了しました" & vbNewLine & "インポート日時：" & Me.cmbLotID.SelectedItem.ToString & vbNewLine & "印刷対象：" & cmbPrintClass.SelectedItem.ToString & vbNewLine &
                        "重量ヘッダ：" & Me.cmbWeightHeader.SelectedItem.ToString, "確認", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    ''' <summary>
    ''' 全チェックボタン押下時
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnAllSelect_Click(sender As Object, e As EventArgs) Handles btnAllSelect.Click

        If Me.C1FGridResult.Rows.Count > 1 Then
            For iRow As Integer = 1 To Me.C1FGridResult.Rows.Count - 1
                Me.C1FGridResult(iRow, "CHK") = True
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
            Me.C1FGridResult(r.Index, "CHK") = True
        Next

    End Sub


#End Region

#Region "プライベートメソッド"

    ''' <summary>
    ''' 初期化処理
    ''' </summary>
    Private Sub Initialize()

		CaptionDisplayMode = StatusDisplayMode.None
		'インポート日時コンボボックスのイベントを殺す
		RemoveHandler cmbLotID.SelectedIndexChanged, AddressOf cmbLotID_SelectedIndexChanged

		'設定ファイルより読み込む
		XmlSettings.LoadFromXmlFile()
		Me.txtSentlist.Text = XmlSettings.Instance.Printer_Sentlist
		Me.txtResult.Text = XmlSettings.Instance.Printer_Result
		Me.txtLeaflet.Text = XmlSettings.Instance.Printer_Leaflet
        Me.cmbSentlistTray.SelectedIndex = XmlSettings.Instance.SentlistTray
        Me.cmbResultTray.SelectedIndex = XmlSettings.Instance.ResultTray
        Me.cmbLeafletTray.SelectedIndex = XmlSettings.Instance.LeafletTray
        Me.txtPDFPath.Text = XmlSettings.Instance.PDFPath

		Dim sqlProcess As New SQLProcess
		Dim strSQL As String = ""

		Try
			strSQL = "SELECT ロットID, インポート日時 FROM T_判定票管理 "
			strSQL &= "GROUP BY ロットID, インポート日時 "
			strSQL &= "ORDER BY ロットID DESC, インポート日時"
			Dim dt As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
			SetComboValue(Me.cmbLotID, dt, False)

			'インポート日時コンボボックスのイベントを生かす
			AddHandler cmbLotID.SelectedIndexChanged, AddressOf cmbLotID_SelectedIndexChanged
			Me.cmbLotID.SelectedIndex = 0

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		Finally

			sqlProcess.Close()

		End Try

	End Sub

    ''' <summary>
    ''' 該当ロットの各事業所単位の情報をグリッドに表示させる
    ''' また、重量ヘッダコンボボックスに該当のヘッダをセットする
    ''' </summary>
    Private Sub SearchGrid()

        Dim sqlProcess As New SQLProcess
        Dim strSQL As String = ""

        Try
            Dim strLotID As String = Me.cmbLotID.SelectedValue
            'グリッドへの値のセット
            strSQL = "SELECT T1.ロットID, T1.会社コード, T1.所属事業所コード, T2.会社名, T2.局所名, T1.印刷ID, T1.重量ヘッダ, "
            strSQL &= "T1.ラベル連番, T1.判定票枚数, T1.リーフレット枚数 "
            strSQL &= "FROM T_印刷管理 AS T1 INNER JOIN "
            strSQL &= "M_局所 AS T2 ON T1.会社コード = T2.会社コード AND T1.所属事業所コード = T2.局所コード "
            strSQL &= "WHERE ロットID = '" & strLotID & "' "
            strSQL &= "ORDER BY ラベル連番"
            Dim dt As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)

            Dim iRecordCount As Integer = 0

            Me.C1FGridResult.BeginUpdate()
            For iRow As Integer = 0 To dt.Rows.Count - 1
                iRecordCount += 1
                Me.C1FGridResult.Rows.Count = iRecordCount + 1
                Me.C1FGridResult(iRecordCount, "No") = iRecordCount
                Me.C1FGridResult(iRecordCount, "会社コード") = dt.Rows(iRow)("会社コード")
                Me.C1FGridResult(iRecordCount, "局所コード") = dt.Rows(iRow)("所属事業所コード")
                Me.C1FGridResult(iRecordCount, "会社名") = dt.Rows(iRow)("会社名")
                Me.C1FGridResult(iRecordCount, "局所名") = dt.Rows(iRow)("局所名")
                Me.C1FGridResult(iRecordCount, "印刷ID") = dt.Rows(iRow)("印刷ID")
                Me.C1FGridResult(iRecordCount, "重量ヘッダ") = dt.Rows(iRow)("重量ヘッダ")
                Me.C1FGridResult(iRecordCount, "ラベル連番") = dt.Rows(iRow)("ラベル連番")
                Me.C1FGridResult(iRecordCount, "判定票") = dt.Rows(iRow)("判定票枚数")
                Me.C1FGridResult(iRecordCount, "リーフレット") = dt.Rows(iRow)("リーフレット枚数")
            Next
            Me.C1FGridResult.EndUpdate()

            '重量ヘッダコンボボックスへの値のセット
            strSQL = "SELECT 重量ヘッダ, 重量ヘッダ AS VALUE FROM T_印刷管理 "
            strSQL &= "WHERE ロットID = '" & strLotID & "' "
            strSQL &= "GROUP BY 重量ヘッダ "
            strSQL &= "ORDER BY 重量ヘッダ"
            dt = sqlProcess.DB_SELECT_DATATABLE(strSQL)
            SetComboValue(Me.cmbWeightHeader, dt, True)
            Me.cmbWeightHeader.SelectedIndex = 0

        Catch ex As Exception

            Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message)
            MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally

            sqlProcess.Close()

        End Try

    End Sub

#End Region

End Class