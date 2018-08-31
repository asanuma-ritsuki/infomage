Imports System.Drawing.Printing

Public Class frmPrint

#Region "プロパティ"

	Dim _LotID As String

	''' <summary>
	''' ロットIDの入出力
	''' </summary>
	''' <returns></returns>
	Public Property LotID As String
		Get
			Return _LotID
		End Get
		Set(value As String)
			_LotID = value
		End Set
	End Property

#End Region

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
		XmlSettings.Instance.Printer_Header = Me.cmbPrinterHeader.SelectedItem
		XmlSettings.Instance.Printer_Label = Me.cmbPrinterLabel.SelectedItem
		XmlSettings.Instance.Printer_Sentlist = Me.cmbPrinterSentlist.SelectedItem
		XmlSettings.Instance.Printer_SentLeaflet = Me.cmbPrinterSentLeaflet.SelectedItem
		XmlSettings.Instance.Printer_Result = Me.cmbPrinterResult.SelectedItem
		XmlSettings.Instance.Printer_Leaflet = Me.cmbPrinterLeaflet.SelectedItem
		XmlSettings.Instance.HeaderTray = Me.cmbHeaderTray.SelectedIndex
		XmlSettings.Instance.LabelTray = Me.cmbLabelTray.SelectedIndex
		XmlSettings.Instance.SentlistTray = Me.cmbSentlistTray.SelectedIndex
		XmlSettings.Instance.SentLeafletTray = Me.cmbSentLeafletTray.SelectedIndex
		XmlSettings.Instance.ResultTray = Me.cmbResultTray.SelectedIndex
		XmlSettings.Instance.LeafletTray = Me.cmbLeafletTray.SelectedIndex

		If Me.WindowState = FormWindowState.Normal Then
			XmlSettings.Instance.PrintLocationX = Me.Left
			XmlSettings.Instance.PrintLocationY = Me.Top
			XmlSettings.Instance.PrintSizeX = Me.Width
			XmlSettings.Instance.PrintSizeY = Me.Height
			XmlSettings.Instance.PrintState = Me.WindowState
		Else
			XmlSettings.Instance.PrintLocationX = Me.RestoreBounds.Left
			XmlSettings.Instance.PrintLocationY = Me.RestoreBounds.Top
			XmlSettings.Instance.PrintSizeX = Me.RestoreBounds.Width
			XmlSettings.Instance.PrintSizeY = Me.RestoreBounds.Height
			XmlSettings.Instance.PrintState = Me.WindowState
		End If

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

			'ラベル連番をラベルFromToにセット
			strSQL = "SELECT MIN(ラベル連番) AS ラベルFROM, MAX(ラベル連番) AS ラベルTO "
			strSQL &= "FROM T_印刷管理 "
			strSQL &= "WHERE ロットID = '" & Me.cmbLotID.SelectedValue & "'"
			Dim dtLabelNum As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
			Me.numLabelFrom.Maximum = dtLabelNum.Rows(0)("ラベルTO")   '最大値を設定
			Me.numLabelTo.Maximum = dtLabelNum.Rows(0)("ラベルTO") '最大値を設定
			Me.numLabelFrom.Value = dtLabelNum.Rows(0)("ラベルFROM")
			Me.numLabelTo.Value = dtLabelNum.Rows(0)("ラベルTO")
			'==================================================
			'グリッドの表示
			SearchGrid()

		Catch ex As Exception

            Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & ex.StackTrace)
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

		Dim iChecked As Integer = 0
		If Me.chkSelectedPrint.Checked Then
			'個別印刷
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
							   "選択件数：" & iChecked & "件" & vbNewLine & "よろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
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

        EnableControls(Me, False)

        XmlSettings.LoadFromXmlFile()
        XmlSettings.Instance.Printer_Header = Me.cmbPrinterHeader.SelectedItem
        XmlSettings.Instance.Printer_Label = Me.cmbPrinterLabel.SelectedItem
        XmlSettings.Instance.Printer_Sentlist = Me.cmbPrinterSentlist.SelectedItem
        XmlSettings.Instance.Printer_SentLeaflet = Me.cmbPrinterSentLeaflet.SelectedItem
        XmlSettings.Instance.Printer_Result = Me.cmbPrinterResult.SelectedItem
        XmlSettings.Instance.Printer_Leaflet = Me.cmbPrinterLeaflet.SelectedItem
        XmlSettings.Instance.HeaderTray = Me.cmbHeaderTray.SelectedIndex
        XmlSettings.Instance.LabelTray = Me.cmbLabelTray.SelectedIndex
        XmlSettings.Instance.SentlistTray = Me.cmbSentlistTray.SelectedIndex
        XmlSettings.Instance.SentLeafletTray = Me.cmbSentLeafletTray.SelectedIndex
        XmlSettings.Instance.ResultTray = Me.cmbResultTray.SelectedIndex
        XmlSettings.Instance.LeafletTray = Me.cmbLeafletTray.SelectedIndex
        XmlSettings.SaveToXmlFile()

        Dim sqlProcess As New SQLProcess
        Dim strSQL As String = ""

        Try

            Select Case Me.cmbPrintClass.SelectedIndex
                Case 0
                    'ラベル
                    'MessageBox.Show("ラベル印刷")
                    PrintLabel(Me.cmbLotID.SelectedValue, blnPrintWeightHeader, Me.cmbWeightHeader.SelectedItem.ToString, Me.numLabelFrom.Value, Me.numLabelTo.Value)

                Case 1
                    '重量ヘッダシート、対象者一覧、保健指導名簿、判定票
                    'MessageBox.Show("就業判定票印刷")
                    If Not blnPrintWeightHeader Then
                        '個別印刷のため「T_印刷管理個別」に該当所属事業所をコピーする
                        strSQL = "DELETE FROM T_印刷管理個別 "
                        sqlProcess.DB_UPDATE(strSQL)

                        For iRow As Integer = 1 To Me.C1FGridResult.Rows.Count - 1
                            'チェックがついているレコードをT_印刷管理個別にコピーする
                            If Me.C1FGridResult(iRow, "CHK") = True Then
                                strSQL = "INSERT INTO T_印刷管理個別 "
                                strSQL &= "SELECT ロットID, 会社コード, 所属事業所コード, 印刷ID, 重量ヘッダ, ラベル連番, "
                                strSQL &= "判定票枚数, リーフレット枚数, 判定票印刷日時, リーフレット印刷日時 "
                                strSQL &= "FROM T_印刷管理 "
                                strSQL &= "WHERE ロットID = '" & Me.cmbLotID.SelectedValue & "' "
                                strSQL &= "AND 会社コード = '" & Me.C1FGridResult(iRow, "会社コード") & "' "
                                strSQL &= "AND 所属事業所コード = '" & Me.C1FGridResult(iRow, "局所コード") & "' "
                                strSQL &= "AND 印刷ID = " & Me.C1FGridResult(iRow, "印刷ID")
                                sqlProcess.DB_UPDATE(strSQL)
                            End If
                        Next
                        '個別印刷(所属事業所単位)
                        PrintCheckupOffice(Me.cmbLotID.SelectedValue)

                    Else
                        '重量ヘッダ単位印刷(全印刷)
                        PrintCheckup(Me.cmbLotID.SelectedValue, blnPrintWeightHeader, Me.cmbWeightHeader.SelectedItem.ToString)

                    End If
                Case 2
                    '重量ヘッダ、リーフレット
                    'MessageBox.Show("リーフレット印刷")
                    If Not blnPrintWeightHeader Then
                        '個別印刷のため「T_印刷管理個別」に該当所属事業所をコピーする
                        strSQL = "DELETE FROM T_印刷管理個別 "
                        sqlProcess.DB_UPDATE(strSQL)

                        For iRow As Integer = 1 To Me.C1FGridResult.Rows.Count - 1
                            'チェックがついているレコードをT_印刷管理個別にコピーする
                            If Me.C1FGridResult(iRow, "CHK") = True Then
                                strSQL = "INSERT INTO T_印刷管理個別 "
                                strSQL &= "SELECT ロットID, 会社コード, 所属事業所コード, 印刷ID, 重量ヘッダ, ラベル連番, "
                                strSQL &= "判定票枚数, リーフレット枚数, 判定票印刷日時, リーフレット印刷日時 "
                                strSQL &= "FROM T_印刷管理 "
                                strSQL &= "WHERE ロットID = '" & Me.cmbLotID.SelectedValue & "' "
                                strSQL &= "AND 会社コード = '" & Me.C1FGridResult(iRow, "会社コード") & "' "
                                strSQL &= "AND 所属事業所コード = '" & Me.C1FGridResult(iRow, "局所コード") & "' "
                                strSQL &= "AND 印刷ID = " & Me.C1FGridResult(iRow, "印刷ID")
                                sqlProcess.DB_UPDATE(strSQL)
                            End If
                        Next
                        '個別印刷(所属事業所単位)
                        PrintLeafletOffice(Me.cmbLotID.SelectedValue)

                    Else
                        '重量ヘッダ単位印刷(全印刷)
                        PrintLeaflet(Me.cmbLotID.SelectedValue, blnPrintWeightHeader, Me.cmbWeightHeader.SelectedItem.ToString)

                    End If
            End Select

			If blnPrintWeightHeader Then
				'重量ヘッダ単位
				MessageBox.Show("印刷処理が完了しました" & vbNewLine & "インポート日時：" & Me.cmbLotID.SelectedItem.ToString & vbNewLine & "印刷対象：" & cmbPrintClass.SelectedItem.ToString & vbNewLine &
						"重量ヘッダ：" & Me.cmbWeightHeader.SelectedItem.ToString, "確認", MessageBoxButtons.OK, MessageBoxIcon.Information)

			Else
				'個別
				MessageBox.Show("選択対象の印刷が完了しました" & vbNewLine & "インポート日時：" & Me.cmbLotID.SelectedItem.ToString & vbNewLine & "印刷対象：" & Me.cmbPrintClass.SelectedItem.ToString & vbNewLine &
						"選択件数：" & iChecked & "件", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information)

			End If

			EnableControls(Me, True)
            SearchGrid()

        Catch ex As Exception

            Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & ex.StackTrace)
            MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally

            sqlProcess.Close()

        End Try


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
    ''' プリンタ名変更時
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub cmbPrinter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPrinterHeader.SelectedIndexChanged,
        cmbPrinterLabel.SelectedIndexChanged, cmbPrinterSentlist.SelectedIndexChanged, cmbPrinterSentLeaflet.SelectedIndexChanged,
        cmbPrinterResult.SelectedIndexChanged, cmbPrinterLeaflet.SelectedIndexChanged

        Dim cmb As ComboBox = CType(sender, ComboBox)
        Dim cmbTrayCombo As ComboBox = Nothing

        Dim prtDoc As New PrintDocument
        prtDoc.PrinterSettings.PrinterName = cmb.SelectedItem

        Select Case cmb.Name
            Case "cmbPrinterHeader"
                cmbTrayCombo = CType(Me.cmbHeaderTray, ComboBox)
            Case "cmbPrinterLabel"
                cmbTrayCombo = CType(Me.cmbLabelTray, ComboBox)
            Case "cmbPrinterSentlist"
                cmbTrayCombo = CType(Me.cmbSentlistTray, ComboBox)
            Case "cmbPrinterSentLeaflet"
                cmbTrayCombo = CType(Me.cmbSentLeafletTray, ComboBox)
            Case "cmbPrinterResult"
                cmbTrayCombo = CType(Me.cmbResultTray, ComboBox)
            Case "cmbPrinterLeaflet"
                cmbTrayCombo = CType(Me.cmbLeafletTray, ComboBox)
        End Select

        cmbTrayCombo.Items.Clear()
        For i As Integer = 0 To prtDoc.PrinterSettings.PaperSources.Count - 1
            cmbTrayCombo.Items.Add(prtDoc.PrinterSettings.PaperSources.Item(i).SourceName)
        Next

        If cmbTrayCombo.Items.Count > 0 Then
            cmbTrayCombo.SelectedIndex = 0
        End If

    End Sub

    ''' <summary>
    ''' 所属事業所グリッドダブルクリック時
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub C1FGridResult_DoubleClick(sender As Object, e As EventArgs) Handles C1FGridResult.DoubleClick
        '所属事業所詳細画面
        Dim f As New frmOfficeDetail
        Dim iIndex As Integer = Me.C1FGridResult.Row

        f.txtLotID.Text = Me.cmbLotID.SelectedValue
        f.txtCompanyCode.Text = Me.C1FGridResult(iIndex, "会社コード")
        f.txtCompany.Text = Me.C1FGridResult(iIndex, "会社名")
        f.txtOfficeCode.Text = Me.C1FGridResult(iIndex, "局所コード")
        f.txtOffice.Text = Me.C1FGridResult(iIndex, "局所名")
        f.txtPrintID.Text = Me.C1FGridResult(iIndex, "印刷ID")
        f.txtLabelNumber.Text = Me.C1FGridResult(iIndex, "ラベル連番")
        f.ShowDialog(Me)

    End Sub

    ''' <summary>
    ''' 印刷対象コンボボックスインデックス変更時
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub cmbPrintClass_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPrintClass.SelectedIndexChanged
        'ラベルが選択されたらラベル印刷範囲FromToを使用可能にする
        If Me.cmbPrintClass.SelectedItem = "ラベル" Then
            Me.numLabelFrom.Enabled = True
            Me.numLabelTo.Enabled = True
        Else
            Me.numLabelFrom.Enabled = False
            Me.numLabelTo.Enabled = False
        End If
    End Sub

    ''' <summary>
    ''' テキストボックスエンター時
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Text_Enter(sender As Object, e As EventArgs) Handles txtPDFPath.Enter

        CType(sender, TextBox).BackColor = Color.LightGreen
        CType(sender, TextBox).SelectAll()

    End Sub

    ''' <summary>
    ''' テキストボックスリーブ時
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub txtPDFPath_Leave(sender As Object, e As EventArgs) Handles txtPDFPath.Leave

        CType(sender, TextBox).BackColor = System.Drawing.SystemColors.Window

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
            'Me.cmbLotID.SelectedIndex = 0
            Me.cmbLotID.SelectedValue = LotID()

            'プリンタドライバの列挙
            SetPrinters(Me.cmbPrinterHeader)
            SetPrinters(Me.cmbPrinterLabel)
            SetPrinters(Me.cmbPrinterSentlist)
            SetPrinters(Me.cmbPrinterSentLeaflet)
            SetPrinters(Me.cmbPrinterResult)
            SetPrinters(Me.cmbPrinterLeaflet)
            'それぞれのプリンタドライバとトレイを選択
            Me.cmbPrinterHeader.SelectedItem = XmlSettings.Instance.Printer_Header
            Me.cmbPrinterLabel.SelectedItem = XmlSettings.Instance.Printer_Label
            Me.cmbPrinterSentlist.SelectedItem = XmlSettings.Instance.Printer_Sentlist
            Me.cmbPrinterSentLeaflet.SelectedItem = XmlSettings.Instance.Printer_SentLeaflet
            Me.cmbPrinterResult.SelectedItem = XmlSettings.Instance.Printer_Result
            Me.cmbPrinterLeaflet.SelectedItem = XmlSettings.Instance.Printer_Leaflet
            'トレイはインデックス範囲外の場合は未選択とする
            Me.cmbHeaderTray.SelectedIndex = IIf(Me.cmbHeaderTray.Items.Count - 1 < XmlSettings.Instance.HeaderTray, -1, XmlSettings.Instance.HeaderTray)
            Me.cmbLabelTray.SelectedIndex = IIf(Me.cmbLabelTray.Items.Count - 1 < XmlSettings.Instance.LabelTray, -1, XmlSettings.Instance.LabelTray)
            Me.cmbSentlistTray.SelectedIndex = IIf(Me.cmbSentlistTray.Items.Count - 1 < XmlSettings.Instance.SentlistTray, -1, XmlSettings.Instance.SentlistTray)
            Me.cmbSentLeafletTray.SelectedIndex = IIf(Me.cmbSentLeafletTray.Items.Count - 1 < XmlSettings.Instance.SentLeafletTray, -1, XmlSettings.Instance.SentLeafletTray)
            Me.cmbResultTray.SelectedIndex = IIf(Me.cmbResultTray.Items.Count - 1 < XmlSettings.Instance.ResultTray, -1, XmlSettings.Instance.ResultTray)
            Me.cmbLeafletTray.SelectedIndex = IIf(Me.cmbLeafletTray.Items.Count - 1 < XmlSettings.Instance.LeafletTray, -1, XmlSettings.Instance.LeafletTray)

            Me.numLabelFrom.Enabled = False
            Me.numLabelTo.Enabled = False

			'印刷画面のプロパティ反映
			XmlSettings.LoadFromXmlFile()
			Me.Left = XmlSettings.Instance.PrintLocationX
			Me.Top = XmlSettings.Instance.PrintLocationY
			Me.Width = XmlSettings.Instance.PrintSizeX
			Me.Height = XmlSettings.Instance.PrintSizeY
			Me.WindowState = XmlSettings.Instance.PrintState

		Catch ex As Exception

            Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & ex.StackTrace)
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

        Me.C1FGridResult.ClearFilter()
        Me.C1FGridResult.Rows.Count = 1

        Try
            Dim strLotID As String = Me.cmbLotID.SelectedValue
            'グリッドへの値のセット
            'strSQL = "SELECT T1.ロットID, T1.会社コード, T1.所属事業所コード, T2.会社名, T2.局所名, T1.印刷ID, T1.重量ヘッダ, "
            'strSQL &= "T1.ラベル連番, T1.判定票枚数, T1.リーフレット枚数 "
            'strSQL &= "FROM T_印刷管理 AS T1 INNER JOIN "
            'strSQL &= "M_局所 AS T2 ON T1.会社コード = T2.会社コード AND T1.所属事業所コード = T2.局所コード "
            'strSQL &= "WHERE ロットID = '" & strLotID & "' "
            'strSQL &= "ORDER BY ラベル連番"
            strSQL = "SELECT T1.ロットID, T1.会社コード, T1.所属事業所コード, T2.会社名, T2.局所名, "
            strSQL &= "T1.印刷ID, T1.重量ヘッダ, T1.ラベル連番, T1.判定票枚数, T1.リーフレット枚数 AS リーフレット件数, "
            strSQL &= "SUM(T3.枚数) AS リーフレット枚数, "
            strSQL &= "ISNULL(T1.判定票印刷日時, '1900/01/01') AS 判定票印刷日時, "
            strSQL &= "ISNULL(T1.リーフレット印刷日時, '1900/01/01') AS リーフレット印刷日時 "
            strSQL &= "FROM T_印刷管理 AS T1 INNER JOIN "
            strSQL &= "M_局所 AS T2 ON T1.会社コード = T2.会社コード AND T1.所属事業所コード = T2.局所コード INNER JOIN "
            strSQL &= "T_印刷ソート AS T3 ON T1.ロットID = T3.ロットID AND T1.会社コード = T3.会社コード "
            strSQL &= "AND T1.所属事業所コード = T3.所属事業所コード AND T1.印刷ID = T3.印刷ID "
            strSQL &= "WHERE T1.ロットID = '" & strLotID & "' "
            strSQL &= "GROUP BY T1.ロットID, T1.会社コード, T1.所属事業所コード, T2.会社名, T2.局所名, "
            strSQL &= "T1.印刷ID, T1.重量ヘッダ, T1.ラベル連番, T1.判定票枚数, T1.リーフレット枚数, "
            strSQL &= "T1.判定票印刷日時, T1.リーフレット印刷日時 "
            strSQL &= "ORDER BY T1.ラベル連番"
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
                Me.C1FGridResult(iRecordCount, "リーフ件数") = dt.Rows(iRow)("リーフレット件数")
                Me.C1FGridResult(iRecordCount, "リーフ枚数") = dt.Rows(iRow)("リーフレット枚数")
                Me.C1FGridResult(iRecordCount, "判定票印刷日時") = IIf(dt.Rows(iRow)("判定票印刷日時") = "1900/01/01", "", dt.Rows(iRow)("判定票印刷日時"))
                Me.C1FGridResult(iRecordCount, "リーフレット印刷日時") = IIf(dt.Rows(iRow)("リーフレット印刷日時") = "1900/01/01", "", dt.Rows(iRow)("リーフレット印刷日時"))
            Next
            Me.C1FGridResult.EndUpdate()

            ChangeBackColor()

            '重量ヘッダコンボボックスへの値のセット
            strSQL = "SELECT 重量ヘッダ, 重量ヘッダ AS VALUE FROM T_印刷管理 "
            strSQL &= "WHERE ロットID = '" & strLotID & "' "
            strSQL &= "GROUP BY 重量ヘッダ "
            strSQL &= "ORDER BY 重量ヘッダ"
            dt = sqlProcess.DB_SELECT_DATATABLE(strSQL)
            SetComboValue(Me.cmbWeightHeader, dt, True)
            Me.cmbWeightHeader.SelectedIndex = 0

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
				Me.C1FGridResult.Rows(i).Style = Me.C1FGridResult.Styles("StyleChange")
			Else
				'判定票、リーフレット共に印刷が完了している
				Me.C1FGridResult.Rows(i).Style = Me.C1FGridResult.Styles("StyleComplete")
			End If
		Next

		Me.C1FGridResult.EndUpdate()

	End Sub

#End Region

End Class