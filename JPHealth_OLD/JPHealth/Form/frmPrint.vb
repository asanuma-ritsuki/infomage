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

		If Not System.IO.Directory.Exists(Me.txtPDFPath.Text) Then
			MessageBox.Show("有効なPDF出力先フォルダを選択してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Exit Sub
		End If

		If MessageBox.Show("選択対象を印刷します" & vbNewLine & "インポート日時：" & Me.cmbLotID.SelectedItem.ToString & vbNewLine & "印刷対象：" & Me.cmbPrintClass.SelectedItem.ToString & vbNewLine & "よろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
			Exit Sub
		End If

		XmlSettings.LoadFromXmlFile()
		XmlSettings.Instance.Printer_Sentlist = Me.txtSentlist.Text
		XmlSettings.Instance.Printer_Result = Me.txtResult.Text
		XmlSettings.Instance.Printer_Leaflet = Me.txtLeaflet.Text
		XmlSettings.SaveToXmlFile()

		Select Case Me.cmbPrintClass.SelectedIndex
			Case 0
				'ラベル
				MessageBox.Show("ラベル印刷")
				PrintLabel(Me.cmbLotID.SelectedValue)

			Case 1
				'重量ヘッダシート、対象者一覧、保健指導名簿、判定票
				MessageBox.Show("就業判定票印刷")
				PrintCheckup(Me.cmbLotID.SelectedValue)
			Case 2
				'重量ヘッダ、リーフレット
				MessageBox.Show("リーフレット印刷")
				PrintLeaflet(Me.cmbLotID.SelectedValue)
		End Select

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

#End Region

End Class