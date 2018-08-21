Imports Microsoft.VisualBasic.FileIO

Public Class frmImport

#Region "プライベート変数"

	Private Enum LogicCategory
		Checkup
		Leaflet
	End Enum

#End Region

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
	Private Sub frmImport_Load(sender As Object, e As EventArgs) Handles MyBase.Load

		Me.Text = My.Application.Info.ProductName & " Ver." &
			My.Application.Info.Version.ToString & " - [インポート]"

        Initialize()
        UpdateImportDate()

    End Sub

#End Region

#Region "オブジェクトイベント"

	''' <summary>
	''' 閉じるボタン押下時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click

		XmlSettings.LoadFromXmlFile()
		XmlSettings.Instance.ImportFromFolder = Me.txtImportFrom.Text
		XmlSettings.Instance.ImportToFolder = Me.txtImportTo.Text
		XmlSettings.Instance.ImportLogFolder = Me.txtLogFolder.Text
		XmlSettings.SaveToXmlFile()

		Me.Close()

	End Sub

	''' <summary>
	''' インポート元フォルダブラウズボタン押下時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	''' <remarks></remarks>
	Private Sub btnImportFromBrowse_Click(sender As System.Object, e As System.EventArgs) Handles btnImportFromBrowse.Click

		Me.txtImportFrom.Text = FolderBrowse(Me.txtImportFrom)

	End Sub

	''' <summary>
	''' 保存フォルダブラウズボタン押下時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	''' <remarks></remarks>
	Private Sub btnImportToBrowse_Click(sender As System.Object, e As System.EventArgs) Handles btnImportToBrowse.Click

		Me.txtImportTo.Text = FolderBrowse(Me.txtImportTo)

	End Sub

	''' <summary>
	''' ログ保存先フォルダブラウズ
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	''' <remarks></remarks>
	Private Sub btnLogFolderBrowse_Click(sender As System.Object, e As System.EventArgs) Handles btnLogFolderBrowse.Click

		Me.txtLogFolder.Text = FolderBrowse(Me.txtLogFolder)

	End Sub

	''' <summary>
	''' テキストボックスドラッグエンター時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub TextBox_DragEnter(sender As Object, e As DragEventArgs) Handles txtImportFrom.DragEnter, txtImportTo.DragEnter, txtLogFolder.DragEnter

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
	Private Sub TextBox_DragDrop(sender As Object, e As DragEventArgs) Handles txtImportFrom.DragDrop, txtImportTo.DragDrop, txtLogFolder.DragDrop

		Dim strFiles As String() = CType(e.Data.GetData(DataFormats.FileDrop, False), String())
		Dim txtFile As TextBox = CType(sender, TextBox)

		If System.IO.File.Exists(strFiles(0)) Then
			txtFile.Text = System.IO.Path.GetDirectoryName(strFiles(0))
		Else
			If System.IO.Directory.Exists(strFiles(0)) Then
				txtFile.Text = strFiles(0)
			Else
				'MessageBox.Show("該当のフォルダが存在しません", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
				'Exit Sub
			End If
		End If

	End Sub

    ''' <summary>
    ''' テキストボックスエンター時
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub TextBox_Enter(sender As Object, e As EventArgs) Handles txtImportFrom.Enter, txtImportTo.Enter, txtLogFolder.Enter, txtPasswordDate.Enter

        CType(sender, TextBox).BackColor = Color.LightGreen
        CType(sender, TextBox).SelectAll()

    End Sub

	''' <summary>
	''' テキストボックスリーブ時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub Text_Leave(sender As Object, e As EventArgs) Handles txtImportFrom.Leave, txtImportTo.Leave, txtLogFolder.Leave, txtPasswordDate.Leave

		CType(sender, TextBox).BackColor = System.Drawing.SystemColors.Window

	End Sub

	''' <summary>
	''' インポートボタン押下時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub btnImport_Click(sender As Object, e As EventArgs) Handles btnImport.Click

		'フォルダチェック
		If Not System.IO.Directory.Exists(Me.txtImportFrom.Text) Then
			MessageBox.Show("インポート元フォルダを指定してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Exit Sub
		End If
		If Not System.IO.Directory.Exists(Me.txtImportTo.Text) Then
			MessageBox.Show("保存先フォルダを指定してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Exit Sub
		End If
		If Not System.IO.Directory.Exists(Me.txtLogFolder.Text) Then
			MessageBox.Show("ログフォルダを指定してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Exit Sub
		End If
		'リストボックスのクリア
		Me.lstResult.Items.Clear()

        '2017/09/29
        '再処理チェックボックスにチェックが入っていた場合は、重複チェックを行わない
        If Not Me.chkReProcess.Checked Then
            '通常処理
            If MessageBox.Show("インポートを開始します" & vbNewLine & "よろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                Exit Sub
            End If
        Else
            '再処理
            If MessageBox.Show("再処理にチェックが入っています" & vbNewLine & "リーフレットの重複チェックを行いません" & vbNewLine & "よろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                Exit Sub
            End If
            If MessageBox.Show("インポートを開始します" & vbNewLine & "よろしいですか？" & vbNewLine & "※再処理", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                Exit Sub
            End If
        End If

        EnableControls(Me, False)
        Me.lstResult.Items.Clear()

        'インポート日時を取得
        Dim dateImportDate As DateTime = DateTime.Now
		Dim strImportDateTime As String = dateImportDate.ToString("yyyy/MM/dd HH:mm:ss")  'yyyy/MM/dd HH:mm:ss
		'保存フォルダ作成用
		Dim strImportDate As String = Date.Now.ToString("yyyyMMdd")
		'インポート元フォルダ
		Dim strImportFromFolder As String = Trim(Me.txtImportFrom.Text)
		'保存先フォルダ
		Dim strImportToFolder As String = Trim(Me.txtImportTo.Text) & "\" & strImportDate
		'ログ保存先フォルダ
		Dim strLogFolder As String = Trim(Me.txtLogFolder.Text) & "\" & strImportDate

		Dim strSaveFile As String = ""  '出力エクセルファイル
		Dim strSaveFolder As String = ""    '出力エクセルフォルダ

		'インポート開始
		WriteLstResult(Me.lstResult, "インポート開始")
		WriteLstResult(Me.lstResult, "インポート元フォルダ：" & strImportFromFolder)
		WriteLstResult(Me.lstResult, "保存先フォルダ：" & strImportToFolder)
		If Not System.IO.Directory.Exists(strImportToFolder) Then
			System.IO.Directory.CreateDirectory(strImportToFolder)
			WriteLstResult(Me.lstResult, "フォルダ作成：" & strImportToFolder)
		End If

		Dim iCount As Integer = 0
		Dim strTargetFiles(0) As String '取込対象ファイルパスの配列
        Dim sqlProcess As New SQLProcess
        Dim dt As DataTable = Nothing
        Dim strSQL As String = ""
		Dim strLotID As String = dateImportDate.ToString("yyyyMMddHHmmss")    'ロットIDを作成

		XmlSettings.LoadFromXmlFile()

        ''========================================
        ''テスト
        ''重量ヘッダ単位件数出力
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
        'strSQL &= "SUM(CASE WHEN T3.リーフレット無効 = 1 AND T3.リーフレット枚数 > 0 THEN T3.リーフレット枚数 ELSE 0 END) AS リーフ重複枚 "
        'strSQL &= "FROM T_印刷ソート AS T1 INNER JOIN "
        'strSQL &= "T_印刷管理 AS T2 ON T1.ロットID = T2.ロットID AND T1.会社コード = T2.会社コード "
        'strSQL &= "AND T1.所属事業所コード = T2.所属事業所コード AND T1.印刷ID = T2.印刷ID LEFT OUTER JOIN "
        'strSQL &= "T_判定票管理 AS T3 ON T1.ロットID = T3.ロットID AND T1.レコード番号 = T3.レコード番号 "
        'strSQL &= "WHERE T1.ロットID = '20170726174419' "
        'strSQL &= "GROUP BY T2.重量ヘッダ "
        'strSQL &= "ORDER BY T2.重量ヘッダ"
        'Dim dtWeightCount2 As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
        'strSaveFile = "重量ヘッダ単位件数_" & Me.dtpSendDate.Value.ToString("yyyyMMdd") & ".xlsx"
        'strSaveFolder = strImportToFolder & "\重量ヘッダ単位件数"
        'If Not System.IO.Directory.Exists(strSaveFolder) Then
        '	My.Computer.FileSystem.CreateDirectory(strSaveFolder)
        'End If
        'ExcelProcess.WriteExcelFile(ExcelOutputCategory.WeightCount, strSaveFolder & "\" & strSaveFile, dtWeightCount2, "")
        'WriteLstResult(Me.lstResult, "エクセルファイル出力完了：" & strSaveFile, ResultMark.InformationMark)
        ''========================================

        Try
            '2017/10/27
            '文字コード判別用Listの作成
            Dim lstCode As New List(Of String)
            strSQL = "SELECT コード16 FROM M_文字コード "
            strSQL &= "ORDER BY ID"
            Dim dtCode As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
            For iCode As Integer = 0 To dtCode.Rows.Count - 1
                lstCode.Add(dtCode.Rows(iCode)("コード16"))
            Next

            'ZIP解凍処理
            WriteLstResult(Me.lstResult, "解凍処理開始")
            'ZIPファイル取得
            WriteLstResult(Me.lstResult, "ZIPファイル確認")
            Dim strFilePathes As String() = GetFilesMostDeep(strImportFromFolder, {"*.zip"})
            If strFilePathes.Count = 0 Then
                MessageBox.Show("ZIPファイルが見つかりませんでした", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
                WriteLstResult(Me.lstResult, "ZIPファイルが見つかりませんでした")
                Exit Sub
            End If
            For Each strFile As String In strFilePathes
                WriteLstResult(Me.lstResult, strFile)
            Next
            WriteLstResult(Me.lstResult, strFilePathes.Count & "個のZIPファイルを確認")

            '既に取り込んでいるZIPファイルかどうか確認
            WriteLstResult(Me.lstResult, "重複取り込み確認")

            For Each strFile As String In strFilePathes
                '該当CSVファイルが既にDBに存在するか確認
                strSQL = "SELECT COUNT(*) FROM T_ロット管理 "
                strSQL &= "WHERE ZIPファイル = '" & System.IO.Path.GetFileName(strFile) & "' "
                strSQL &= "AND 削除フラグ = 0"
                If sqlProcess.DB_EXECUTE_SCALAR(strSQL) > 0 Then
                    '同名のCSVファイルが存在したら対象外
                    WriteLstResult(Me.lstResult, System.IO.Path.GetFileName(strFile) & " 取り込み済ZIPファイルです(取込対象外)")
                Else
                    '存在しなかったら対象
                    ReDim Preserve strTargetFiles(iCount)
                    strTargetFiles(iCount) = strFile
                    iCount += 1
                    WriteLstResult(Me.lstResult, System.IO.Path.GetFileName(strFile) & " OK")
                End If

                ''保存先フォルダに同名のフォルダが有るか確認
                'If System.IO.Directory.Exists(strImportToFolder & "\" & System.IO.Path.GetFileNameWithoutExtension(strFile)) Then
                '	'存在したら対象外
                '	WriteLstResult(Me.lstResult, System.IO.Path.GetFileName(strFile) & " 取り込み済ZIPファイルです(取込対象外)")
                'Else
                '	'存在しなかったら対象
                '	ReDim Preserve strTargetFiles(iCount)
                '	strTargetFiles(iCount) = strFile
                '	iCount += 1
                '	WriteLstResult(Me.lstResult, System.IO.Path.GetFileName(strFile) & " OK")
                'End If
            Next
            '対象ファイルが無かった場合アボート
            If strTargetFiles(0) = Nothing Then
                MessageBox.Show("取り込みするZIPファイルがありませんでした", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
                WriteLstResult(Me.lstResult, "取り込みするZIPファイルがありませんでした")
                Exit Sub
            End If

            Dim iIncompleteCount As Integer = 0 '要修正となったレコード数をカウントする
            Dim iDuplicateCount As Integer = 0   '重複のカウント

            'ZIPファイル内のCSVレコード数を格納する変数
            Dim iTargetRecordCountCheckup() As Integer = Nothing
            Dim iTargetRecordCountLeaflet() As Integer = Nothing
            Dim iFileCountCheckup As Integer = 0
            Dim iFileCountLeaflet As Integer = 0
            Dim iRecCountCheckup As Integer = 0
            Dim iRecCountLeaflet As Integer = 0

            For Each strFile As String In strTargetFiles
                Application.DoEvents()

                Dim strDestFolder As String = strImportToFolder & "\" & System.IO.Path.GetFileNameWithoutExtension(strFile)

                My.Computer.FileSystem.CreateDirectory(strDestFolder)
                WriteLstResult(Me.lstResult, "フォルダ作成：" & strDestFolder)
                '解凍処理
                WriteLstResult(Me.lstResult, "解凍処理")
                If ExtractZIP(strFile, strDestFolder, Me.txtPasswordDate.Text) Then
                    '解凍処理成功
                    WriteLstResult(Me.lstResult, "解凍処理成功")
                    WriteLstResult(Me.lstResult, "解凍フォルダ：" & strDestFolder)
                    '==================================================
                    '判定票CSVファイルインポート処理
                    '==================================================
                    '文言：Checkupが付与されているファイルを探して読み込む(判定票CSV)
                    Dim strCheckupCSV As System.Collections.ObjectModel.ReadOnlyCollection(Of String) =
                        My.Computer.FileSystem.GetFiles(strDestFolder, SearchOption.SearchAllSubDirectories, "Checkup*.csv")
                    'My.Computer.FileSystem.FindInFiles(strDestFolder, "Checkup", False, SearchOption.SearchAllSubDirectories, New String() {"*.csv"})
                    '文言：Leafletが付与されているファイルを探して読み込む(リーフレットCSV)
                    Dim strLeafletCSV As System.Collections.ObjectModel.ReadOnlyCollection(Of String) =
                        My.Computer.FileSystem.GetFiles(strDestFolder, SearchOption.SearchAllSubDirectories, "Leaflet*.csv")
                    'My.Computer.FileSystem.FindInFiles(strDestFolder, "Leaflet", False, SearchOption.SearchAllSubDirectories, New String() {"*.csv"})
                    If strCheckupCSV.Count = 0 Then
                        MessageBox.Show("判定票CSVがありませんでした", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        WriteLstResult(Me.lstResult, "判定票CSVがありませんでした", ResultMark.WarningMark)
                        Exit Sub
                    End If

                    '==================================================
                    'ロット管理テーブルへのINSERT
                    '==================================================
                    'T_ロット管理にレコードを追加する
                    'この時点で判定票CSVとリーフレットCSVが確定する
                    '念のためレコードの存在確認をしてからINSERTする

                    '2017/09/01
                    'ZIPファイルが存在した時点でCSVファイルは重複チェックしないように変更
                    strSQL = "INSERT INTO T_ロット管理(ロットID, 発送日, ZIPファイル, 判定票CSV, リーフレットCSV, "
                    strSQL &= "インポート日時, 削除フラグ) VALUES ("
                    strSQL &= "'" & strLotID & "', "    'ロットID
                    strSQL &= "'" & Me.dtpSendDate.Value.ToString("yyyy/MM/dd") & "', " '発送日
                    strSQL &= "'" & System.IO.Path.GetFileName(strFile) & "', " 'ZIPファイル
                    strSQL &= "'" & System.IO.Path.GetFileName(strCheckupCSV(0)) & "', "    '判定票CSV
                    'リーフレットCSVは存在した場合のみ
                    If strLeafletCSV.Count > 0 Then
                        strSQL &= "'" & System.IO.Path.GetFileName(strLeafletCSV(0)) & "', "
                    Else
                        strSQL &= "'', "
                    End If
                    strSQL &= "'" & strImportDateTime & "', "   'インポート日時
                    strSQL &= "0)"  '削除フラグ
                    sqlProcess.DB_UPDATE(strSQL)

                    '               strSQL = "SELECT COUNT(*) FROM T_ロット管理 "
                    'strSQL &= "WHERE 判定票CSV = '" & System.IO.Path.GetFileName(strCheckupCSV(0)) & "' "
                    'strSQL &= "AND 削除フラグ = 0"
                    '               If sqlProcess.DB_EXECUTE_SCALAR(strSQL) = 0 Then
                    '                   '存在しなかった場合のみINSERT
                    '               Else
                    '                   '同一CSVファイル名が存在しているので処理を中断する
                    '                   MessageBox.Show("既にインポートしているCSVファイルのため" & vbNewLine & System.IO.Path.GetFileName(strCheckupCSV(0)), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

                    '               End If
                    '==================================================

                    WriteLstResult(Me.lstResult, "判定票CSV読み込み")
                    WriteLstResult(Me.lstResult, "判定票CSV：" & strCheckupCSV(0))
                    WriteLstResult(Me.lstResult, "レコードインポート(データチェック)")

                    Using parser As New CSVParser(strCheckupCSV(0), System.Text.Encoding.GetEncoding("Shift-JIS"))

                        'parser.TextFieldType = FieldType.Delimited
                        'parser.SetDelimiters(",")   'カンマ区切り
                        parser.Delimiter = ","  'カンマ区切り

                        parser.HasFieldsEnclosedInQuotes = True 'データ内にデリミタがあっても区切らない
                        parser.TrimWhiteSpace = False   '空白を削除しない

                        iRecCountCheckup = 0

                        parser.ReadFields() 'ヘッダ行を読み飛ばす
                        '最終行まで読み込み
                        While Not parser.EndOfData
                            'レコード番号の最大値を取得
                            strSQL = "SELECT ISNULL(MAX(レコード番号), 0) + 1 FROM T_判定票管理 "
                            strSQL &= "WHERE ロットID = '" & strLotID & "'"
                            Dim iRecNumber As Integer = sqlProcess.DB_EXECUTE_SCALAR(strSQL)

                            Dim row As String() = parser.ReadFields()   '1行読み込み、項目を配列に代入

                            'T_判定票管理テーブルに関連情報を書き込む
                            strSQL = "INSERT INTO T_判定票管理 (ロットID, レコード番号, システムID, 会社コード, 所属事業所コード, 所属部名, 所属課名, 社員コード, "
                            strSQL &= "健診種別, 年度, 受診年齢, インポート日時, 判定票CSV, リーフレットCSV, 修正記録出力, 事業所一覧出力, 対象者一覧出力, リーフレット無効, リーフレット枚数, 重量, 備考) VALUES("
                            strSQL &= "'" & strLotID & "'"  'ロットID
                            strSQL &= ", " & iRecNumber 'レコード番号
                            strSQL &= ", '" & row(0) & "'"  'システムID
                            strSQL &= ", '" & row(2) & "'"  '会社コード
                            strSQL &= ", '" & row(3) & "'"  '所属事業所コード
                            strSQL &= ", '" & row(6) & "'"  '所属部名
                            strSQL &= ", '" & row(7) & "'"  '所属課名
                            strSQL &= ", '" & row(1) & "'"  '社員コード
                            strSQL &= ", '" & row(16) & "'" '健診種別
                            '年度、受診年齢
                            '受診日(17)、採用年月日(14)のいずれか後の日付を起算日として使用して年度を算出する
                            '※受診年齢は生年月日(15)をもとに該当する年度の4月1日を起算日として算出する
                            '採用年月日はNULL許容
                            If IsNull(row(14)) Then
                                '採用年月日がNULLの場合は必ず受診日を起算日とする
                                strSQL &= ", '" & GetBusinessYear(row(17)).ToString & "'"   '年度
                                '受診日の年度の4月1日を起算日とする
                                Dim dtBirthDate As DateTime = DateTime.Parse(row(15))
                                Dim dtTargetDate As DateTime = DateTime.Parse(GetBusinessYear(row(17)).ToString & "/04/01")
                                strSQL &= ", " & GetAge(dtBirthDate, dtTargetDate)  '受診年齢
                            Else
                                'NULLでない場合
                                Dim iParse As Integer = Date.Compare(Date.Parse(row(14)), Date.Parse(row(17)))
                                If iParse > 0 Then
                                    '採用年月日のほうが後
                                    strSQL &= ", '" & GetBusinessYear(row(14)).ToString & "'"   '年度
									'採用年月日の年度の4月1日を起算日とする
									Dim dtBirthDate As DateTime = DateTime.Parse(row(15))
                                    Dim dtTargetDate As DateTime = DateTime.Parse(GetBusinessYear(row(14)).ToString & "/04/01")
                                    strSQL &= ", " & GetAge(dtBirthDate, dtTargetDate)  '受診年齢
                                Else
                                    'それ以外は受診日を起算日とする
                                    strSQL &= ", '" & GetBusinessYear(row(17)).ToString & "'"   '年度
                                    '受診日の年度の4月1日を起算日とする
                                    Dim dtBirthDate As DateTime = DateTime.Parse(row(15))
                                    Dim dtTargetDate As DateTime = DateTime.Parse(GetBusinessYear(row(17)).ToString & "/04/01")
                                    strSQL &= ", " & GetAge(dtBirthDate, dtTargetDate)  '受診年齢
                                End If
                            End If

                            strSQL &= ", '" & strImportDateTime & "'"   'インポート日時
                            strSQL &= ", '" & System.IO.Path.GetFileName(strCheckupCSV(0)) & "'"    '判定票CSV
                            If strLeafletCSV.Count = 0 Then
                                strSQL &= ", ''"    'リーフレットCSVなし
                            Else
                                strSQL &= ", '" & System.IO.Path.GetFileName(strLeafletCSV(0)) & "'"    'リーフレットCSV
                            End If
                            strSQL &= ", 0, 0, 0, 0, 0"    '修正記録出力、事業所一覧出力、対象者一覧出力、リーフレット無効、リーフレット枚数
                            strSQL &= ", 0, '')"    '重量、備考
                            sqlProcess.DB_UPDATE(strSQL)

                            'エラーチェック用にT_判定票の項目名を全て取得しておく
                            strSQL = "SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS "
                            strSQL &= "WHERE TABLE_NAME = 'T_判定票' "
                            strSQL &= "ORDER BY ORDINAL_POSITION"
                            dt = sqlProcess.DB_SELECT_DATATABLE(strSQL)
                            Dim strColumnName As String() = Nothing
                            For i As Integer = 0 To dt.Rows.Count - 1
                                ReDim Preserve strColumnName(i)
                                strColumnName(i) = dt.Rows(i)("COLUMN_NAME")
                            Next

                            ''会場局名、健康管理施設名をM_局所から取得する
                            'strSQL = "SELECT 会場局名, 健康管理施設名 FROM M_局所 "
                            'strSQL &= "WHERE 会社コード = '" & row(2) & "' "
                            'strSQL &= "AND 局所コード = '" & row(3) & "'"
                            'Dim dtKyokusho As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)

                            '===============================================================
                            '必須項目チェック
                            For iCol As Integer = 0 To row.Count - 1
                                Select Case iCol
                                    Case 0, 1, 2, 3, 4, 5, 9, 10, 11, 12, 13, 15, 16, 17, 135, 136, 137, 143, 144,
                                         171, 172, 173, 174, 181
                                        '2017/08/18
                                        '会場局名称（結果値）(138)の必須項目チェックを外す

                                        If NullCheck(row(iCol)) Then
                                            'NULLだったら
                                            iIncompleteCount += 1
                                            WriteLstResult(Me.lstResult, "必須項目にNULLを検知しました(" & iIncompleteCount & ")", ResultMark.WarningMark)
                                            WriteLstResult(Me.lstResult, "会社コード：" & row(2) & " 所属事業所コード：" & row(3) & " 社員コード：" & row(1) & " 項目名：" & strColumnName(iCol + 2), ResultMark.WarningMark)

                                            WriteNoGoodRecord(strImportDateTime, row, strLotID, iRecNumber,
                                                              strColumnName(iCol + 2), strCheckupCSV(0),
                                                              ErrorCategory.NullCheck)

                                        End If

                                        'If IsNull(row(iCol)) Then

                                        '	'NULLだったら
                                        '	iIncompleteCount += 1
                                        '	WriteLstResult(Me.lstResult, "必須項目にNULLを検知しました(" & iIncompleteCount & ")", ResultMark.WarningMark)
                                        '	WriteLstResult(Me.lstResult, "会社コード：" & row(2) & " 所属事業所コード：" & row(3) & " 社員コード：" & row(1) & " 項目名：" & strColumnName(iCol + 2), ResultMark.WarningMark)

                                        '	strSQL = "UPDATE T_判定票管理 SET "
                                        '	strSQL &= "要修正日時 = '" & strImportDateTime & "'"
                                        '	strSQL &= ", 修正済日時 = NULL "
                                        '	strSQL &= "WHERE ロットID = '" & strLotID & "'"
                                        '	strSQL &= "AND レコード番号 = " & iRecNumber
                                        '	sqlProcess.DB_UPDATE(strSQL)

                                        '	'データ不備レコード情報をT_判定票_不備内容に書き込む
                                        '	strSQL = "SELECT ISNULL(MAX(シーケンス), 0) + 1 FROM T_判定票_不備内容 "
                                        '	strSQL &= "WHERE ロットID = '" & strLotID & "' "
                                        '	strSQL &= "AND レコード番号 = " & iRecNumber
                                        '	Dim iSeq As Integer = sqlProcess.DB_EXECUTE_SCALAR(strSQL)
                                        '	strSQL = "INSERT INTO T_判定票_不備内容 (ロットID, レコード番号, シーケンス, 不備種別, 会社コード, "
                                        '	strSQL &= "所属事業所コード, 健診種別, 会社, 所属事業所, 社員コード, 性別, 生年月日, "
                                        '	strSQL &= "氏名姓, 氏名名, 採用年月日, 受診日, 会場局名, 健康管理施設名, 不備項目, 不備内容, 修正内容, インポート日時, "
                                        '	strSQL &= "CSVファイル, 修正済フラグ) VALUES("
                                        '	strSQL &= "'" & strLotID & "'"  'ロットID
                                        '	strSQL &= ", " & iRecNumber 'レコード番号
                                        '	strSQL &= ", " & iSeq   'シーケンス
                                        '	strSQL &= ", 1" '不備種別(1：必須項目NULL)
                                        '	strSQL &= ", '" & row(2) & "'"  '会社コード
                                        '	strSQL &= ", '" & row(3) & "'"  '所属事業所コード
                                        '	strSQL &= ", '" & row(16) & "'" '健診種別
                                        '	strSQL &= ", '" & row(4) & "'"  '会社
                                        '	strSQL &= ", '" & row(5) & "'"  '所属事業所
                                        '	strSQL &= ", '" & row(1) & "'"  '社員コード
                                        '	strSQL &= ", '" & row(13) & "'" '性別
                                        '	strSQL &= ", '" & row(15) & "'" '生年月日
                                        '	strSQL &= ", '" & row(11) & "'" '氏名姓
                                        '	strSQL &= ", '" & row(12) & "'" '氏名名
                                        '	strSQL &= ", '" & row(14) & "'" '採用年月日
                                        '	strSQL &= ", '" & row(17) & "'" '受診日
                                        '	'レコードが存在したら「会場局名」「健康管理施設名」をセットする
                                        '	If dtKyokusho.Rows.Count > 0 Then
                                        '		strSQL &= ", '" & dtKyokusho.Rows(0)("会場局名") & "'"  '会場局名
                                        '		strSQL &= ", '" & dtKyokusho.Rows(0)("健康管理施設名") & "'"   '健康管理施設名
                                        '	Else
                                        '		strSQL &= ", '', ''"
                                        '	End If
                                        '	strSQL &= ", '" & strColumnName(iCol + 2) & "'"   '不備項目(ロットID、レコード番号があるので項目名は+2する)
                                        '	strSQL &= ", '" & XmlSettings.Instance.DataRequired & "'" '不備内容(必須項目)
                                        '	strSQL &= ", ''"    '修正内容(デフォルト'')
                                        '	strSQL &= ", '" & strImportDateTime & "'"   'インポート日時
                                        '	strSQL &= ", '" & System.IO.Path.GetFileName(strCheckupCSV(0)) & "'"    'CSVファイル
                                        '	strSQL &= ", 0)"    '修正済フラグ
                                        '	sqlProcess.DB_UPDATE(strSQL)

                                        'End If
                                End Select
                            Next
                            '===============================================================
                            '小数点桁数チェック
                            '2017/06/22
                            '小数点が所定の桁数なくても不備として挙げないように変更
                            'DOUBLE型に変換できるかのみチェックする
                            For iCol As Integer = 0 To row.Count - 1
                                'NULLの場合はスルー
                                If IsNull(row(iCol)) Then
                                    Continue For
                                End If
                                Dim blnError As Boolean = False
                                Select Case iCol
                                    Case 18, 20, 22, 23, 25, 27, 28, 30, 32, 33, 106, 108, 109, 116, 118, 119, 131, 133, 134

                                        blnError = Not NumericCheck(row(iCol))
                                        ''小数点第一位まで必要な項目
                                        ''Double型に変換できるか確認
                                        'Dim d As Double
                                        'If Not Double.TryParse(row(iCol), d) Then
                                        '	blnError = True
                                        'End If
                                        'If Strings.Mid(row(iCol), row(iCol).Length - 1, 1) = "." Then
                                        '	'右から2文字目がピリオド(小数点)であった
                                        'Else
                                        '	'ピリオドじゃなかった
                                        '	blnError = True
                                        'End If

                                    Case 34, 35, 36, 37, 101, 103, 104

                                        blnError = Not NumericCheck(row(iCol))
                                        ''小数点第二位まで必要な項目
                                        ''Double型に変換できるか確認
                                        'Dim d As Double
                                        'If Not Double.TryParse(row(iCol), d) Then
                                        '	blnError = True
                                        'End If
                                        'If Strings.Mid(row(iCol), row(iCol).Length - 2, 1) = "." Then
                                        '	'右から3文字目がピリオド(小数点)であった
                                        'Else
                                        '	'ピリオドじゃなかった
                                        '	blnError = True
                                        'End If
                                End Select
                                'エラーフラグが立っていたら不備内容に書き込む
                                If blnError Then

                                    iIncompleteCount += 1
                                    WriteLstResult(Me.lstResult, "数値に変換できませんでした(" & iIncompleteCount & ")", ResultMark.WarningMark)
                                    WriteLstResult(Me.lstResult, "会社コード：" & row(2) & " 所属事業所コード：" & row(3) & " 社員コード：" & row(1) & " 項目名：" & strColumnName(iCol + 2), ResultMark.WarningMark)

                                    WriteNoGoodRecord(strImportDateTime, row, strLotID, iRecNumber,
                                                      strColumnName(iCol + 2), strCheckupCSV(0),
                                                      ErrorCategory.NullCheck)

                                    'strSQL = "UPDATE T_判定票管理 SET "
                                    'strSQL &= "要修正日時 = '" & strImportDateTime & "'"
                                    'strSQL &= ", 修正済日時 = NULL "
                                    'strSQL &= "WHERE ロットID = '" & strLotID & "'"
                                    'strSQL &= "AND レコード番号 = " & iRecNumber
                                    'sqlProcess.DB_UPDATE(strSQL)

                                    ''データ不備レコード情報をT_判定票_不備内容に書き込む
                                    'strSQL = "SELECT ISNULL(MAX(シーケンス), 0) + 1 FROM T_判定票_不備内容 "
                                    'strSQL &= "WHERE ロットID = '" & strLotID & "' "
                                    'strSQL &= "AND レコード番号 = " & iRecNumber
                                    'Dim iSeq As Integer = sqlProcess.DB_EXECUTE_SCALAR(strSQL)
                                    'strSQL = "INSERT INTO T_判定票_不備内容 (ロットID, レコード番号, シーケンス, 不備種別, 会社コード, "
                                    'strSQL &= "所属事業所コード, 健診種別, 会社, 所属事業所, 社員コード, 性別, 生年月日, "
                                    'strSQL &= "氏名姓, 氏名名, 採用年月日, 受診日, 会場局名, 健康管理施設名, 不備項目, 不備内容, 修正内容, インポート日時, "
                                    'strSQL &= "CSVファイル, 修正済フラグ) VALUES("
                                    'strSQL &= "'" & strLotID & "'"  'ロットID
                                    'strSQL &= ", " & iRecNumber 'レコード番号
                                    'strSQL &= ", " & iSeq   'シーケンス
                                    'strSQL &= ", 4" '不備種別(4：小数点位置不正)
                                    'strSQL &= ", '" & row(2) & "'"  '会社コード
                                    'strSQL &= ", '" & row(3) & "'"  '所属事業所コード
                                    'strSQL &= ", '" & row(16) & "'" '健診種別
                                    'strSQL &= ", '" & row(4) & "'"  '会社
                                    'strSQL &= ", '" & row(5) & "'"  '所属事業所
                                    'strSQL &= ", '" & row(1) & "'"  '社員コード
                                    'strSQL &= ", '" & row(13) & "'" '性別
                                    'strSQL &= ", '" & row(15) & "'" '生年月日
                                    'strSQL &= ", '" & row(11) & "'" '氏名姓
                                    'strSQL &= ", '" & row(12) & "'" '氏名名
                                    'strSQL &= ", '" & row(14) & "'" '採用年月日
                                    'strSQL &= ", '" & row(17) & "'" '受診日
                                    ''レコードが存在したら「会場局名」「健康管理施設名」をセットする
                                    'If dtKyokusho.Rows.Count > 0 Then
                                    '	strSQL &= ", '" & dtKyokusho.Rows(0)("会場局名") & "'"  '会場局名
                                    '	strSQL &= ", '" & dtKyokusho.Rows(0)("健康管理施設名") & "'"   '健康管理施設名
                                    'Else
                                    '	strSQL &= ", '', ''"
                                    'End If
                                    'strSQL &= ", '" & strColumnName(iCol + 2) & "'"   '不備項目(ロットID、レコード番号があるので項目名は+2する)
                                    'strSQL &= ", '" & XmlSettings.Instance.DataDigit & "'" '不備内容(小数点位置不正)
                                    'strSQL &= ", ''"    '修正内容(デフォルト'')
                                    'strSQL &= ", '" & strImportDateTime & "'"   'インポート日時
                                    'strSQL &= ", '" & System.IO.Path.GetFileName(strCheckupCSV(0)) & "'"    'CSVファイル
                                    'strSQL &= ", 0)"    '修正済フラグ
                                    'sqlProcess.DB_UPDATE(strSQL)

                                End If
                            Next
                            '===============================================================
                            'フィールド単位でShift-JISで表現できるかチェック
                            For iCol As Integer = 0 To row.Count - 1
                                'SJISで表現できない文字を設定ファイルより読み込む（"･"、"・"、"?"、"？")
                                Dim strSJISErrorCheck() As String = XmlSettings.Instance.SJISErrorCheck.Split(",")
                                '参照するエラー文字がなかった場合For文を抜ける
                                If strSJISErrorCheck.Length = 1 And IsNull(strSJISErrorCheck(0)) Then
                                    Exit For
                                End If

                                Dim blnExistError As Boolean = False
                                '配列の各要素ごとに、該当の文字が存在するかチェックする
                                '特定項目のみチェック
                                Select Case iCol
                                    '氏名セイ、氏名メイ、氏名姓、氏名名、受診検査機関名称、会場局名称、健診実施医師名、意見を述べた医師、判定医師名
                                    Case 9, 10, 11, 12, 136, 138, 141, 142, 143
                                        '禁則文字チェック
                                        For j As Integer = 0 To strSJISErrorCheck.Count - 1
                                            If row(iCol).IndexOf(strSJISErrorCheck(j)) >= 0 Then
                                                '存在した場合True
                                                blnExistError = True
                                            End If
                                        Next

                                        '2017/10/26
                                        '文字コードチェック
                                        If Not blnExistError Then
                                            If Not StringCodeCheck(row(iCol), lstCode) Then
                                                '登録されている文字コード以外が存在した
                                                blnExistError = True
                                            End If
                                        End If

                                    Case 4
                                        '会社項目、除外リストを参照して該当していたら不備項目として挙げない
                                        For j As Integer = 0 To strSJISErrorCheck.Count - 1
                                            If row(iCol).IndexOf(strSJISErrorCheck(j)) >= 0 Then
                                                'さらに除外リストを参照する
                                                strSQL = "SELECT COUNT(*) FROM M_除外リスト "
                                                strSQL &= "WHERE 対象項目 = '会社' "
                                                strSQL &= "AND 入力値 = '" & row(iCol) & "'"
                                                If sqlProcess.DB_EXECUTE_SCALAR(strSQL) = 0 Then
                                                    'M_除外リストに無かった場合、不備とする
                                                    blnExistError = True
                                                End If

                                            End If
                                        Next

                                        '2017/10/26
                                        '文字コードチェック
                                        If Not blnExistError Then
                                            If Not StringCodeCheck(row(iCol), lstCode) Then
                                                '登録されている文字コード以外が存在した
                                                blnExistError = True
                                            End If
                                        End If

                                    Case 5
                                        '所属事業所、除外リストを参照して該当していたら不備項目として挙げない
                                        For j As Integer = 0 To strSJISErrorCheck.Count - 1
                                            If row(iCol).IndexOf(strSJISErrorCheck(j)) >= 0 Then
                                                'さらに除外リストを参照する
                                                strSQL = "SELECT COUNT(*) FROM M_除外リスト "
                                                strSQL &= "WHERE 対象項目 = '所属事業所' "
                                                strSQL &= "AND 入力値 = '" & row(iCol) & "'"
                                                If sqlProcess.DB_EXECUTE_SCALAR(strSQL) = 0 Then
                                                    'M_除外リストに無かった場合、不備とする
                                                    blnExistError = True
                                                End If

                                            End If
                                        Next

                                        '2017/10/26
                                        '文字コードチェック
                                        If Not blnExistError Then
                                            If Not StringCodeCheck(row(iCol), lstCode) Then
                                                '登録されている文字コード以外が存在した
                                                blnExistError = True
                                            End If
                                        End If

                                End Select

                                If blnExistError Then
                                    'Shift-JISで表現できない文字が混在していたら
                                    iIncompleteCount += 1

                                    WriteLstResult(Me.lstResult, "シフトJISで表現できないフィールドを検知しました(" & iIncompleteCount & ")", ResultMark.WarningMark)
                                    WriteLstResult(Me.lstResult, "会社コード：" & row(2) & " 所属事業所コード：" & row(3) & " 社員コード：" & row(1) & " 項目名：" & strColumnName(iCol + 2), ResultMark.WarningMark)

                                    WriteNoGoodRecord(strImportDateTime, row, strLotID, iRecNumber,
                                                      strColumnName(iCol + 2), strCheckupCSV(0),
                                                      ErrorCategory.SJISCheck, row(iCol))

                                    'strSQL = "UPDATE T_判定票管理 SET "
                                    'strSQL &= "要修正日時 = '" & strImportDateTime & "'"
                                    'strSQL &= ", 修正済日時 = NULL "
                                    'strSQL &= "WHERE ロットID = '" & strLotID & "' "
                                    'strSQL &= "AND レコード番号 = " & iRecNumber
                                    'sqlProcess.DB_UPDATE(strSQL)

                                    ''データ不備レコード情報をT_判定票_不備内容に書き込む
                                    'strSQL = "SELECT ISNULL(MAX(シーケンス), 0) + 1 FROM T_判定票_不備内容 "
                                    'strSQL &= "WHERE ロットID = '" & strLotID & "' "
                                    'strSQL &= "AND レコード番号 = " & iRecNumber
                                    'Dim iSeq As Integer = sqlProcess.DB_EXECUTE_SCALAR(strSQL)
                                    'strSQL = "INSERT INTO T_判定票_不備内容 (ロットID, レコード番号, シーケンス, 不備種別, 会社コード, "
                                    'strSQL &= "所属事業所コード, 健診種別, 会社, 所属事業所, 社員コード, 性別, 生年月日, "
                                    'strSQL &= "氏名姓, 氏名名, 採用年月日, 受診日, 会場局名, 健康管理施設名, 不備項目, 不備内容, 修正内容, インポート日時, "
                                    'strSQL &= "CSVファイル, 修正済フラグ) VALUES("
                                    'strSQL &= "'" & strLotID & "'"  'ロットID
                                    'strSQL &= ", " & iRecNumber 'レコード番号
                                    'strSQL &= ", " & iSeq   'シーケンス
                                    'strSQL &= ", 2" '不備種別(2：Shift-JISで表現できないデータ)
                                    'strSQL &= ", '" & row(2) & "'"  '会社コード
                                    'strSQL &= ", '" & row(3) & "'"  '所属事業所コード
                                    'strSQL &= ", '" & row(16) & "'" '健診種別
                                    'strSQL &= ", '" & row(4) & "'"  '会社
                                    'strSQL &= ", '" & row(5) & "'"  '所属事業所
                                    'strSQL &= ", '" & row(1) & "'"  '社員コード
                                    'strSQL &= ", '" & row(13) & "'" '性別
                                    'strSQL &= ", '" & row(15) & "'" '生年月日
                                    'strSQL &= ", '" & row(11) & "'" '氏名姓
                                    'strSQL &= ", '" & row(12) & "'" '氏名名
                                    'strSQL &= ", '" & row(14) & "'" '採用年月日
                                    'strSQL &= ", '" & row(17) & "'" '受診日
                                    ''レコードが存在したら「会場局名」「健康管理施設名」をセットする
                                    'If dtKyokusho.Rows.Count > 0 Then
                                    '	strSQL &= ", '" & dtKyokusho.Rows(0)("会場局名") & "'"  '会場局名
                                    '	strSQL &= ", '" & dtKyokusho.Rows(0)("健康管理施設名") & "'"   '健康管理施設名
                                    'Else
                                    '	strSQL &= ", '', ''"
                                    'End If
                                    'strSQL &= ", '" & strColumnName(iCol + 2) & "'"   '不備項目(ロットID、レコード番号があるので項目名は+2する)
                                    'strSQL &= ", '" & row(iCol) & "'" '不備内容(データを取得する)
                                    'strSQL &= ", ''"    '修正内容(デフォルト'')
                                    'strSQL &= ", '" & strImportDateTime & "'"   'インポート日時
                                    'strSQL &= ", '" & System.IO.Path.GetFileName(strCheckupCSV(0)) & "'"    'CSVファイル
                                    'strSQL &= ", 0)"    '修正済フラグ
                                    'sqlProcess.DB_UPDATE(strSQL)

                                End If
                            Next

							'===============================================================
							'2018/01/11
							'各項目の文字数チェック処理を追加

							'M_文字数テーブルをDATATABLEで保持しておく
							strSQL = "SELECT 項目ID, バイト数 FROM M_文字数 "
							strSQL &= "WHERE 項目種別 = 1 " '項目種別：1＝判定票
							strSQL &= "ORDER BY 項目ID"
							Dim dtStringLen As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
							For iCol As Integer = 0 To row.Count - 1
								'NULLの場合はスルー
								If IsNull(row(iCol)) Then
									Continue For
								End If
								Dim blnError As Boolean = False
								'インポートデータのカラムで回して該当する要素(項目ID)が存在した場合に文字数チェックを行う
								'バイト数が0の場合はスルーする
								Dim iLength As Integer = 0
								Dim strFilter As String = "項目ID = " & iCol
								Dim foundRows As DataRow() = dtStringLen.Select(strFilter)
								For iRow As Integer = 0 To foundRows.Length - 1
									'複数ヒットすることはないが念のためiRow=0のときのみ処理する
									If iRow = 0 Then
										iLength = foundRows(iRow)(1)
										If iLength > 0 Then
											'取得した文字数が0より大きい
											If VBStrings.LenB(row(iCol)) > iLength Then
												'指定バイトより文字列数が大きい場合はエラー
												blnError = True
											End If
										Else
											Exit For
										End If
									Else
										'1レコード目以外は全てループを抜ける
										Exit For
									End If
								Next

								If blnError Then
									'エラーが発生した場合
									iIncompleteCount += 1

									WriteLstResult(Me.lstResult, "指定文字数を超過するフィールドを検知しました(" & iIncompleteCount & ")", ResultMark.WarningMark)
									WriteLstResult(Me.lstResult, "会社コード：" & row(2) & " 所属事業所コード：" & row(3) & " 社員コード：" & row(1) & " 項目名：" & strColumnName(iCol + 2), ResultMark.WarningMark)

									WriteNoGoodRecord(strImportDateTime, row, strLotID, iRecNumber,
													  strColumnName(iCol + 2), strCheckupCSV(0),
													  ErrorCategory.ExceedCheck, row(iCol))

								End If
							Next

							'===============================================================
							'T_判定票テーブルに実データを書き込む
							strSQL = "INSERT INTO T_判定票 ("
                            For iCol As Integer = 0 To strColumnName.Count - 1
                                If iCol = 0 Then
                                    strSQL &= strColumnName(iCol)
                                ElseIf iCol = strColumnName.Count - 1 Then
                                    '最終項目はカッコで閉じる
                                    strSQL &= ", " & strColumnName(iCol) & ") VALUES("
                                Else
                                    strSQL &= ", " & strColumnName(iCol)
                                End If
                            Next

                            strSQL &= "'" & strLotID & "'"  'ロットID
                            strSQL &= ", " & iRecNumber 'レコード番号
                            For iCol As Integer = 0 To row.Count - 1
                                'シングルクォート「'」が文字列中に発生するとSQL文が破錠してしまうため「''」に置換する
                                'strSQL &= ", '" & row(iCol).Replace("'", "''") & "'"
                                'カラム内の改行は「\n」に変換する
                                strSQL &= ", '" & row(iCol).Replace("'", "''").Replace(vbNewLine, "\n") & "'"
                            Next
                            strSQL &= ")"
                            sqlProcess.DB_UPDATE(strSQL)

                            iRecCountCheckup += 1

                        End While

                        WriteLstResult(Me.lstResult, "インポート終了：" & strCheckupCSV(0))
                        WriteLstResult(Me.lstResult, iRecCountCheckup & "件インポートしました")
                        iFileCountCheckup += 1

                    End Using
                    WriteLstResult(Me.lstResult, "--------------------------------------------------------------------------------", ResultMark.InformationMark)

                    '==================================================
                    'リーフレットCSVファイルインポート処理
                    '==================================================
                    If strLeafletCSV.Count = 0 Then
                        WriteLstResult(Me.lstResult, "リーフレットCSVがありませんでした")
                    Else
                        WriteLstResult(Me.lstResult, "リーフレットCSV読み込み")
                        WriteLstResult(Me.lstResult, "リーフレットCSV：" & strLeafletCSV(0))
                        WriteLstResult(Me.lstResult, "レコードインポート(データチェック)")
                        '2017/09/29
                        '再処理時は重複チェックを行わない
                        If Me.chkReProcess.Checked Then
							WriteLstResult(Me.lstResult, "※再処理(重複チェックを行なわない)")
						End If

                        Using parser As New CSVParser(strLeafletCSV(0), System.Text.Encoding.GetEncoding("Shift-JIS"))

                            'parser.TextFieldType = FieldType.Delimited
                            'parser.SetDelimiters(",")   'カンマ区切り
                            parser.Delimiter = ","  'カンマ区切り

                            parser.HasFieldsEnclosedInQuotes = True 'データ内にデリミタがあっても区切らない
                            parser.TrimWhiteSpace = False   '空白を削除しない

                            iRecCountLeaflet = 0

                            parser.ReadFields() 'ヘッダ行を読み飛ばす
                            '最終行まで読み込み
                            While Not parser.EndOfData

                                Dim row As String() = parser.ReadFields()   '１行読み込み、項目を配列に代入
								'エラーチェック後、該当ロットID、システムIDのレコード番号をT_判定票管理から取得してT_リーフレットに値をINSERTしていく
								'エラーチェック用にT_リーフレットの項目名を全て取得しておく
								strSQL = "SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS "
                                strSQL &= "WHERE TABLE_NAME = 'T_リーフレット' "
                                strSQL &= "ORDER BY ORDINAL_POSITION"
                                dt = sqlProcess.DB_SELECT_DATATABLE(strSQL)
                                Dim strColumnName As String() = Nothing
                                For i As Integer = 0 To dt.Rows.Count - 1
                                    ReDim Preserve strColumnName(i)
                                    strColumnName(i) = dt.Rows(i)("COLUMN_NAME")
                                Next

                                '会場局名、健康管理施設名をM_局所から取得する
                                strSQL = "SELECT 会場局名, 健康管理施設名 FROM M_局所 "
                                strSQL &= "WHERE 会社コード = '" & row(2) & "' "
                                strSQL &= "AND 局所コード = '" & row(3) & "'"
                                Dim dtKyokusho As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)

                                'T_判定票管理からレコード番号を特定しておく
                                strSQL = "SELECT レコード番号, 年度 FROM T_判定票管理 "
                                strSQL &= "WHERE ロットID = '" & strLotID & "' "
                                strSQL &= "AND システムID = '" & row(0) & "'"
                                dt = sqlProcess.DB_SELECT_DATATABLE(strSQL)
                                If dt.Rows.Count = 0 Then
                                    WriteLstResult(Me.lstResult, "判定表に紐付かないリーフレットを検知しました", ResultMark.WarningMark)
                                    WriteLstResult(Me.lstResult, "会社コード：" & row(2) & " 所属事業所コード：" & row(3) & " 社員コード：" & row(1), ResultMark.WarningMark)
                                    Continue While
                                End If
                                Dim iRecNumber As Integer = dt.Rows(0)("レコード番号")
                                Dim strTargetYear As String = dt.Rows(0)("年度")
								'===============================================================
								'重複チェック
								'年度、システムID、帳票タイプが同一のレコードが既に存在していたら重複とする
								'2017/09/29
								'再処理時は重複チェックを行わない
								'2018/03/30
								'同一社員コードで重複するリーフレットと重複しないリーフレットが混在する際の対応
								Dim blnDuplicate As Boolean = False

								If Not Me.chkReProcess.Checked Then
									'再処理チェックボックスにチェックされていなかったら重複チェックを行う
									strSQL = "SELECT COUNT(*) FROM T_リーフレット AS T1 INNER JOIN "
									strSQL &= "T_判定票管理 AS T2 ON T1.ロットID = T2.ロットID "
									strSQL &= "AND T1.レコード番号 = T2.レコード番号 INNER JOIN "
									strSQL &= "T_ロット管理 AS T3 ON T1.ロットID = T3.ロットID "
									strSQL &= "WHERE T2.年度 = '" & strTargetYear & "' "
									strSQL &= "AND T1.システムID = '" & row(0) & "' "
									strSQL &= "AND T1.帳票タイプ = '" & row(108) & "' "
									'2018/05/31
									'受診日を重複条件に追加
									strSQL &= "AND T1.受診日 = '" & row(17) & "' "
									'T_ロット管理の削除フラグが立っているものは対象外
									strSQL &= "AND T3.削除フラグ = 0"

									'strSQL = "SELECT COUNT(*) FROM T_リーフレット "
									'strSQL &= "WHERE ロットID = '" & strLotID & "' "
									'strSQL &= "AND システムID = '" & row(0) & "' "
									'strSQL &= "AND 帳票タイプ = '" & row(108) & "'"

									If sqlProcess.DB_EXECUTE_SCALAR(strSQL) > 0 Then
										'===============================================================
										'2017/07/21
										'リーフレット重複の場合は、修正済日時をすぐセットして、修正済フラグも立てる
										'===============================================================

										'レコードが存在していたら重複
										iDuplicateCount += 1
										WriteLstResult(Me.lstResult, "重複レコードを検知しました。(" & iDuplicateCount & ")", ResultMark.WarningMark)
										WriteLstResult(Me.lstResult, "会社コード：" & row(2) & " 所属事業所コード：" & row(3) & " 社員コード：" & row(1), ResultMark.WarningMark)

										'2018/03/30
										'一時的なリーフレット重複フラグを立てておく
										blnDuplicate = True

										'リーフレットが重複した場合は、対象システムIDのリーフレット出力は行わないため
										'T_判定票管理.リーフレット無効フラグを立てる
										strSQL = "UPDATE T_判定票管理 SET "
										strSQL &= "要修正日時 = '" & strImportDateTime & "'"
										strSQL &= ", 修正済日時 = '" & strImportDateTime & "'"   '※修正済日時も同時にセットする

										'2018/03/30
										'有効無効混在時のためここではリーフレット無効フラグを立てない
										'strSQL &= ", リーフレット無効 = 1 "
										strSQL &= "WHERE ロットID = '" & strLotID & "'"
										strSQL &= "AND レコード番号 = " & iRecNumber
										sqlProcess.DB_UPDATE(strSQL)

										'データ不備レコード情報をT_判定票_不備内容に書き込む
										'WriteNoGoodRecord(strImportDate, row, strLotID, iRecNumber,)

										strSQL = "SELECT ISNULL(MAX(シーケンス), 0) + 1 FROM T_判定票_不備内容 "
										strSQL &= "WHERE ロットID = '" & strLotID & "' "
										strSQL &= "AND レコード番号 = " & iRecNumber
										Dim iSeq As Integer = sqlProcess.DB_EXECUTE_SCALAR(strSQL)
										strSQL = "INSERT INTO T_判定票_不備内容 (ロットID, レコード番号, シーケンス, 不備種別, 会社コード, "
										strSQL &= "所属事業所コード, 健診種別, 会社, 所属事業所, 社員コード, 性別, 生年月日, "
										strSQL &= "氏名姓, 氏名名, 帳票タイプ, 採用年月日, 受診日, 会場局名, 健康管理施設名, 不備項目, 不備内容, 修正内容, インポート日時, "
										strSQL &= "CSVファイル, 修正済フラグ) VALUES("
										strSQL &= "'" & strLotID & "'"  'ロットID
										strSQL &= ", " & iRecNumber 'レコード番号
										strSQL &= ", " & iSeq   'シーケンス
										strSQL &= ", 3" '不備種別(3：重複レコード)
										strSQL &= ", '" & row(2) & "'"  '会社コード
										strSQL &= ", '" & row(3) & "'"  '所属事業所コード
										strSQL &= ", '" & row(16) & "'" '健診種別
										strSQL &= ", '" & row(4) & "'"  '会社
										strSQL &= ", '" & row(5) & "'"  '所属事業所
										strSQL &= ", '" & row(1) & "'"  '社員コード
										strSQL &= ", '" & row(13) & "'" '性別
										strSQL &= ", '" & row(15) & "'" '生年月日
										strSQL &= ", '" & row(11) & "'" '氏名姓
										strSQL &= ", '" & row(12) & "'" '氏名名
										strSQL &= ", '" & row(108) & "'"    '帳票タイプ
										strSQL &= ", '" & row(14) & "'" '採用年月日
										strSQL &= ", '" & row(17) & "'" '受診日
										'レコードが存在したら「会場局名」「健康管理施設名」をセットする
										If dtKyokusho.Rows.Count > 0 Then
											strSQL &= ", '" & dtKyokusho.Rows(0)("会場局名") & "'"  '会場局名
											strSQL &= ", '" & dtKyokusho.Rows(0)("健康管理施設名") & "'"   '健康管理施設名
										Else
											strSQL &= ", '', ''"
										End If
										strSQL &= ", ''"    '不備項目(レコード重複のためなし)
										strSQL &= ", '" & XmlSettings.Instance.DataDupe & "(" & row(108) & ")'"    '不備内容
										strSQL &= ", '印刷対象外'"    '修正内容(デフォルト'印刷対象外')
										strSQL &= ", '" & strImportDateTime & "'"   'インポート日時
										strSQL &= ", '" & System.IO.Path.GetFileName(strLeafletCSV(0)) & "'"    'CSVファイル
										strSQL &= ", 1)"    '修正済フラグ※同時にフラグを立てる
										sqlProcess.DB_UPDATE(strSQL)

									End If

								End If

								'===============================================================
								'必須項目チェック
								For iCol As Integer = 0 To row.Count - 1
                                    Select Case iCol
                                        Case 0, 1, 2, 3, 4, 5, 9, 10, 11, 12, 13, 15, 16, 17, 103, 108

                                            If IsNull(row(iCol)) Then

                                                'NULLだったら
                                                iIncompleteCount += 1
                                                WriteLstResult(Me.lstResult, "必須項目にNULLを検知しました(" & iIncompleteCount & ")", ResultMark.WarningMark)
                                                WriteLstResult(Me.lstResult, "会社コード：" & row(2) & " 所属事業所コード：" & row(3) & " 社員コード：" & row(1) & " 項目名：" & strColumnName(iCol + 2), ResultMark.WarningMark)

                                                strSQL = "UPDATE T_判定票管理 SET "
                                                strSQL &= "要修正日時 = '" & strImportDateTime & "'"
                                                strSQL &= ", 修正済日時 = NULL "
                                                strSQL &= "WHERE ロットID = '" & strLotID & "'"
                                                strSQL &= "AND レコード番号 = " & iRecNumber
                                                sqlProcess.DB_UPDATE(strSQL)

                                                'データ不備レコード情報をT_判定票_不備内容に書き込む
                                                strSQL = "SELECT ISNULL(MAX(シーケンス), 0) + 1 FROM T_判定票_不備内容 "
                                                strSQL &= "WHERE ロットID = '" & strLotID & "' "
                                                strSQL &= "AND レコード番号 = " & iRecNumber
                                                Dim iSeq As Integer = sqlProcess.DB_EXECUTE_SCALAR(strSQL)
                                                strSQL = "INSERT INTO T_判定票_不備内容 (ロットID, レコード番号, シーケンス, 不備種別, 会社コード, "
                                                strSQL &= "所属事業所コード, 健診種別, 会社, 所属事業所, 社員コード, 性別, 生年月日, "
                                                strSQL &= "氏名姓, 氏名名, 帳票タイプ, 採用年月日, 受診日, 会場局名, 健康管理施設名, 不備項目, 不備内容, 修正内容, インポート日時, "
                                                strSQL &= "CSVファイル, 修正済フラグ) VALUES("
                                                strSQL &= "'" & strLotID & "'"  'ロットID
                                                strSQL &= ", " & iRecNumber 'レコード番号
                                                strSQL &= ", " & iSeq   'シーケンス
                                                strSQL &= ", 1" '不備種別(1：必須項目NULL)
                                                strSQL &= ", '" & row(2) & "'"  '会社コード
                                                strSQL &= ", '" & row(3) & "'"  '所属事業所コード
                                                strSQL &= ", '" & row(16) & "'" '健診種別
                                                strSQL &= ", '" & row(4) & "'"  '会社
                                                strSQL &= ", '" & row(5) & "'"  '所属事業所
                                                strSQL &= ", '" & row(1) & "'"  '社員コード
                                                strSQL &= ", '" & row(13) & "'" '性別
                                                strSQL &= ", '" & row(15) & "'" '生年月日
                                                strSQL &= ", '" & row(11) & "'" '氏名姓
                                                strSQL &= ", '" & row(12) & "'" '氏名名
                                                strSQL &= ", '" & row(108) & "'"    '帳票タイプ
                                                strSQL &= ", '" & row(14) & "'" '採用年月日
                                                strSQL &= ", '" & row(17) & "'" '受診日
                                                'レコードが存在したら「会場局名」「健康管理施設名」をセットする
                                                If dtKyokusho.Rows.Count > 0 Then
                                                    strSQL &= ", '" & dtKyokusho.Rows(0)("会場局名") & "'"  '会場局名
                                                    strSQL &= ", '" & dtKyokusho.Rows(0)("健康管理施設名") & "'"   '健康管理施設名
                                                Else
                                                    strSQL &= ", '', ''"
                                                End If
                                                strSQL &= ", '" & strColumnName(iCol + 2) & "'"   '不備項目(ロットID、レコード番号があるので項目名は+2する)
                                                strSQL &= ", '" & XmlSettings.Instance.DataRequired & "'" '不備内容(必須項目)
                                                strSQL &= ", ''"    '修正内容(デフォルト'')
                                                strSQL &= ", '" & strImportDateTime & "'"   'インポート日時
                                                strSQL &= ", '" & System.IO.Path.GetFileName(strLeafletCSV(0)) & "'"    'CSVファイル
                                                strSQL &= ", 0)"    '修正済フラグ
                                                sqlProcess.DB_UPDATE(strSQL)

                                            End If
                                    End Select
                                Next
                                '===============================================================
                                '小数点桁数チェック
                                For iCol As Integer = 0 To row.Count - 1
                                    Dim blnError As Boolean = False
                                    'NULLだった場合はスルー
                                    If IsNull(row(iCol)) Then
                                        Continue For
                                    End If
									Select Case iCol
										'2018/07/30
										'チェック項目に「BMI」(109)を追加
										Case 64, 66, 67, 74, 76, 77, 89, 91, 92, 109
											'小数点第一位まで必要な項目
											'Double型に変換できるか確認
											Dim d As Double
											If Not Double.TryParse(row(iCol), d) Then
												blnError = True
											End If
											If Strings.Mid(row(iCol), row(iCol).Length - 1, 1) = "." Then
												'右から2文字目がピリオド(小数点)であった
											Else
												'ピリオドじゃなかった
												blnError = True
											End If

										Case 59, 61, 62
											'小数点第二位まで必要な項目
											'Double型に変換できるか確認
											Dim d As Double
											If Not Double.TryParse(row(iCol), d) Then
												blnError = True
											End If
											If Strings.Mid(row(iCol), row(iCol).Length - 2, 1) = "." Then
												'右から3文字目がピリオド(小数点)であった
											Else
												'ピリオドじゃなかった
												blnError = True
											End If
									End Select
									'エラーフラグが立っていたら不備内容に書き込む
									If blnError Then

                                        'NULLだったら
                                        iIncompleteCount += 1
                                        WriteLstResult(Me.lstResult, "小数点位置不正を検知しました(" & iIncompleteCount & ")", ResultMark.WarningMark)
                                        WriteLstResult(Me.lstResult, "会社コード：" & row(2) & " 所属事業所コード：" & row(3) & " 社員コード：" & row(1) & " 項目名：" & strColumnName(iCol + 2), ResultMark.WarningMark)

                                        strSQL = "UPDATE T_判定票管理 SET "
                                        strSQL &= "要修正日時 = '" & strImportDateTime & "'"
                                        strSQL &= ", 修正済日時 = NULL "
                                        strSQL &= "WHERE ロットID = '" & strLotID & "'"
                                        strSQL &= "AND レコード番号 = " & iRecNumber
                                        sqlProcess.DB_UPDATE(strSQL)

                                        'データ不備レコード情報をT_判定票_不備内容に書き込む
                                        strSQL = "SELECT ISNULL(MAX(シーケンス), 0) + 1 FROM T_判定票_不備内容 "
                                        strSQL &= "WHERE ロットID = '" & strLotID & "' "
                                        strSQL &= "AND レコード番号 = " & iRecNumber
                                        Dim iSeq As Integer = sqlProcess.DB_EXECUTE_SCALAR(strSQL)
                                        strSQL = "INSERT INTO T_判定票_不備内容 (ロットID, レコード番号, シーケンス, 不備種別, 会社コード, "
                                        strSQL &= "所属事業所コード, 健診種別, 会社, 所属事業所, 社員コード, 性別, 生年月日, "
                                        strSQL &= "氏名姓, 氏名名, 帳票タイプ, 採用年月日, 受診日, 会場局名, 健康管理施設名, 不備項目, 不備内容, 修正内容, インポート日時, "
                                        strSQL &= "CSVファイル, 修正済フラグ) VALUES("
                                        strSQL &= "'" & strLotID & "'"  'ロットID
                                        strSQL &= ", " & iRecNumber 'レコード番号
                                        strSQL &= ", " & iSeq   'シーケンス
                                        strSQL &= ", 4" '不備種別(4：小数点位置不正)
                                        strSQL &= ", '" & row(2) & "'"  '会社コード
                                        strSQL &= ", '" & row(3) & "'"  '所属事業所コード
                                        strSQL &= ", '" & row(16) & "'" '健診種別
                                        strSQL &= ", '" & row(4) & "'"  '会社
                                        strSQL &= ", '" & row(5) & "'"  '所属事業所
                                        strSQL &= ", '" & row(1) & "'"  '社員コード
                                        strSQL &= ", '" & row(13) & "'" '性別
                                        strSQL &= ", '" & row(15) & "'" '生年月日
                                        strSQL &= ", '" & row(11) & "'" '氏名姓
                                        strSQL &= ", '" & row(12) & "'" '氏名名
                                        strSQL &= ", '" & row(108) & "'"    '帳票タイプ
                                        strSQL &= ", '" & row(14) & "'" '採用年月日
                                        strSQL &= ", '" & row(17) & "'" '受診日
                                        'レコードが存在したら「会場局名」「健康管理施設名」をセットする
                                        If dtKyokusho.Rows.Count > 0 Then
                                            strSQL &= ", '" & dtKyokusho.Rows(0)("会場局名") & "'"  '会場局名
                                            strSQL &= ", '" & dtKyokusho.Rows(0)("健康管理施設名") & "'"   '健康管理施設名
                                        Else
                                            strSQL &= ", '', ''"
                                        End If
                                        strSQL &= ", '" & strColumnName(iCol + 2) & "'"   '不備項目(ロットID、レコード番号があるので項目名は+2する)
                                        strSQL &= ", '" & XmlSettings.Instance.DataDigit & "'" '不備内容(小数点位置不正)
                                        strSQL &= ", ''"    '修正内容(デフォルト'')
                                        strSQL &= ", '" & strImportDateTime & "'"   'インポート日時
                                        strSQL &= ", '" & System.IO.Path.GetFileName(strLeafletCSV(0)) & "'"    'CSVファイル
                                        strSQL &= ", 0)"    '修正済フラグ
                                        sqlProcess.DB_UPDATE(strSQL)

                                    End If
                                Next
                                '===============================================================
                                'フィールド単位でShift-JISで表現できるかチェック
                                For iCol As Integer = 0 To row.Count - 1
                                    'SJISで表現できない文字を設定ファイルより読み込む
                                    Dim strSJISErrorCheck() As String = XmlSettings.Instance.SJISErrorCheck.Split(",")
                                    '参照するエラー文字がなかった場合For文を抜ける
                                    If strSJISErrorCheck.Length = 1 And IsNull(strSJISErrorCheck(0)) Then
                                        Exit For
                                    End If

                                    Dim blnExistError As Boolean = False
                                    '配列の各要素ごとに、該当の文字が存在するかチェックする
                                    '特定項目のみチェック
                                    Select Case iCol
                                    '氏名セイ、氏名メイ、氏名姓、氏名名
                                        Case 9, 10, 11, 12

                                            For j As Integer = 0 To strSJISErrorCheck.Count - 1
                                                If row(iCol).IndexOf(strSJISErrorCheck(j)) >= 0 Then
                                                    '存在した場合True
                                                    blnExistError = True
                                                End If
                                            Next

                                            '2017/10/26
                                            '文字コードチェック
                                            If Not blnExistError Then
                                                If Not StringCodeCheck(row(iCol), lstCode) Then
                                                    '登録されている文字コード以外が存在した
                                                    blnExistError = True
                                                End If
                                            End If

                                        Case 4
                                            '会社、除外リストを参照して該当していたら不備項目として挙げない
                                            For j As Integer = 0 To strSJISErrorCheck.Count - 1
                                                If row(iCol).IndexOf(strSJISErrorCheck(j)) >= 0 Then
                                                    'さらに除外リストを参照する
                                                    strSQL = "SELECT COUNT(*) FROM M_除外リスト "
                                                    strSQL &= "WHERE 対象項目 = '会社' "
                                                    strSQL &= "AND 入力値 = '" & row(iCol) & "'"
                                                    If sqlProcess.DB_EXECUTE_SCALAR(strSQL) = 0 Then
                                                        'M_除外リストになかった場合、不備とする
                                                        blnExistError = True
                                                    End If
                                                End If
                                            Next

                                            '2017/10/26
                                            '文字コードチェック
                                            If Not blnExistError Then
                                                If Not StringCodeCheck(row(iCol), lstCode) Then
                                                    '登録されている文字コード以外が存在した
                                                    blnExistError = True
                                                End If
                                            End If

                                        Case 5
                                            '所属事業所、除外リストを参照して該当していたら不備項目として挙げない
                                            For j As Integer = 0 To strSJISErrorCheck.Count - 1
                                                If row(iCol).IndexOf(strSJISErrorCheck(j)) >= 0 Then
                                                    'さらに除外リストを参照する
                                                    strSQL = "SELECT COUNT(*) FROM M_除外リスト "
                                                    strSQL &= "WHERE 対象項目 = '所属事業所' "
                                                    strSQL &= "AND 入力値 = '" & row(iCol) & "'"
                                                    If sqlProcess.DB_EXECUTE_SCALAR(strSQL) = 0 Then
                                                        'M_除外リストになかった場合、不備とする
                                                        blnExistError = True
                                                    End If
                                                End If
                                            Next

                                            '2017/10/26
                                            '文字コードチェック
                                            If Not blnExistError Then
                                                If Not StringCodeCheck(row(iCol), lstCode) Then
                                                    '登録されている文字コード以外が存在した
                                                    blnExistError = True
                                                End If
                                            End If

                                    End Select

                                    If blnExistError Then
                                        'Shift-JISで表現できない文字が混在していたら
                                        iIncompleteCount += 1
                                        ''会場局名、健康管理施設名をM_局所から取得する
                                        'strSQL = "SELECT 会場局名, 健康管理施設名 FROM M_局所 "
                                        'strSQL &= "WHERE 会社コード = '" & row(2) & "' "
                                        'strSQL &= "AND 局所コード = '" & row(3) & "'"
                                        'Dim dtKyokusho As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)

                                        WriteLstResult(Me.lstResult, "シフトJISで表現できないフィールドを検知しました(" & iIncompleteCount & ")", ResultMark.WarningMark)
                                        WriteLstResult(Me.lstResult, "会社コード：" & row(2) & " 所属事業所コード：" & row(3) & " 社員コード：" & row(1) & " 項目名：" & strColumnName(iCol + 2), ResultMark.WarningMark)

                                        strSQL = "UPDATE T_判定票管理 SET "
                                        strSQL &= "要修正日時 = '" & strImportDateTime & "'"
                                        strSQL &= ", 修正済日時 = NULL "
                                        strSQL &= "WHERE ロットID = '" & strLotID & "' "
                                        strSQL &= "AND レコード番号 = " & iRecNumber
                                        sqlProcess.DB_UPDATE(strSQL)

                                        'データ不備レコード情報をT_判定票_不備内容に書き込む
                                        strSQL = "SELECT ISNULL(MAX(シーケンス), 0) + 1 FROM T_判定票_不備内容 "
                                        strSQL &= "WHERE ロットID = '" & strLotID & "' "
                                        strSQL &= "AND レコード番号 = " & iRecNumber
                                        Dim iSeq As Integer = sqlProcess.DB_EXECUTE_SCALAR(strSQL)
                                        strSQL = "INSERT INTO T_判定票_不備内容 (ロットID, レコード番号, シーケンス, 不備種別, 会社コード, "
                                        strSQL &= "所属事業所コード, 健診種別, 会社, 所属事業所, 社員コード, 性別, 生年月日, "
                                        strSQL &= "氏名姓, 氏名名, 帳票タイプ, 採用年月日, 受診日, 会場局名, 健康管理施設名, 不備項目, 不備内容, 修正内容, インポート日時, "
                                        strSQL &= "CSVファイル, 修正済フラグ) VALUES("
                                        strSQL &= "'" & strLotID & "'"  'ロットID
                                        strSQL &= ", " & iRecNumber 'レコード番号
                                        strSQL &= ", " & iSeq   'シーケンス
                                        strSQL &= ", 2" '不備種別(2：Shift-JISで表現できないデータ)
                                        strSQL &= ", '" & row(2) & "'"  '会社コード
                                        strSQL &= ", '" & row(3) & "'"  '所属事業所コード
                                        strSQL &= ", '" & row(16) & "'" '健診種別
                                        strSQL &= ", '" & row(4) & "'"  '会社
                                        strSQL &= ", '" & row(5) & "'"  '所属事業所
                                        strSQL &= ", '" & row(1) & "'"  '社員コード
                                        strSQL &= ", '" & row(13) & "'" '性別
                                        strSQL &= ", '" & row(15) & "'" '生年月日
                                        strSQL &= ", '" & row(11) & "'" '氏名姓
                                        strSQL &= ", '" & row(12) & "'" '氏名名
                                        strSQL &= ", '" & row(108) & "'"    '帳票タイプ
                                        strSQL &= ", '" & row(14) & "'" '採用年月日
                                        strSQL &= ", '" & row(17) & "'" '受診日
                                        'レコードが存在したら「会場局名」「健康管理施設名」をセットする
                                        If dtKyokusho.Rows.Count > 0 Then
                                            strSQL &= ", '" & dtKyokusho.Rows(0)("会場局名") & "'"  '会場局名
                                            strSQL &= ", '" & dtKyokusho.Rows(0)("健康管理施設名") & "'"   '健康管理施設名
                                        Else
                                            strSQL &= ", '', ''"
                                        End If
                                        strSQL &= ", '" & strColumnName(iCol + 2) & "'"   '不備項目(ロットID、レコード番号があるので項目名は+2する)
                                        strSQL &= ", '" & row(iCol) & "'" '不備内容(データを取得する)
                                        strSQL &= ", ''"    '修正内容(デフォルト'')
                                        strSQL &= ", '" & strImportDateTime & "'"   'インポート日時
                                        strSQL &= ", '" & System.IO.Path.GetFileName(strLeafletCSV(0)) & "'"    'CSVファイル
                                        strSQL &= ", 0)"    '修正済フラグ
                                        sqlProcess.DB_UPDATE(strSQL)

                                    End If
                                Next

								'===============================================================
								'2018/01/15
								'各項目の文字数チェック処理を追加

								'M_文字数テーブルをDATATABLEで保持しておく
								strSQL = "SELECT 項目ID, バイト数 FROM M_文字数 "
								strSQL &= "WHERE 項目種別 = 2 " '項目種別：2＝リーフレット
								strSQL &= "ORDER BY 項目ID"
								Dim dtStringLen As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
								For iCol As Integer = 0 To row.Count - 1
									'NULLの場合はスルー
									If IsNull(row(iCol)) Then
										Continue For
									End If
									Dim blnError As Boolean = False
									'インポートデータのカラムで回して該当する要素(項目ID)が存在した場合に文字数チェックを行う
									'バイト数が0の場合はスルーする
									Dim iLength As Integer = 0
									Dim strFilter As String = "項目ID = " & iCol
									Dim foundRows As DataRow() = dtStringLen.Select(strFilter)
									For iRow As Integer = 0 To foundRows.Length - 1
										'複数ヒットすることはないが念のためiRow=0のときのみ処理する
										If iRow = 0 Then
											iLength = foundRows(iRow)(1)
											If iLength > 0 Then
												'取得した文字数が0より大きい
												If VBStrings.LenB(row(iCol)) > iLength Then
													'指定バイト数より文字列数が大きい場合はエラー
													blnError = True
												End If
											Else
												Exit For
											End If
										Else
											'1レコード目以外はすべてループを抜ける
											Exit For
										End If
									Next

									If blnError Then
										'エラーが発生した場合
										iIncompleteCount += 1

										WriteLstResult(Me.lstResult, "指定文字数を超過するフィールドを検知しました(" & iIncompleteCount & ")", ResultMark.WarningMark)
										WriteLstResult(Me.lstResult, "会社コード：" & row(2) & " 所属事業所コード：" & row(3) & " 社員コード：" & row(1) & " 項目名：" & strColumnName(iCol + 2), ResultMark.WarningMark)

										strSQL = "UPDATE T_判定票管理 SET "
										strSQL &= "要修正日時 = '" & strImportDateTime & "'"
										strSQL &= ", 修正済日時 = NULL "
										strSQL &= "WHERE ロットID = '" & strLotID & "'"
										strSQL &= "AND レコード番号 = " & iRecNumber
										sqlProcess.DB_UPDATE(strSQL)

										'データ不備レコード情報をT_判定票_不備内容に書き込む
										strSQL = "SELECT ISNULL(MAX(シーケンス), 0) + 1 FROM T_判定票_不備内容 "
										strSQL &= "WHERE ロットID = '" & strLotID & "' "
										strSQL &= "AND レコード番号 = " & iRecNumber
										Dim iSeq As Integer = sqlProcess.DB_EXECUTE_SCALAR(strSQL)
										strSQL = "INSERT INTO T_判定票_不備内容 (ロットID, レコード番号, シーケンス, 不備種別, 会社コード, "
										strSQL &= "所属事業所コード, 健診種別, 会社, 所属事業所, 社員コード, 性別, 生年月日, "
										strSQL &= "氏名姓, 氏名名, 帳票タイプ, 採用年月日, 受診日, 会場局名, 健康管理施設名, 不備項目, 不備内容, 修正内容, インポート日時, "
										strSQL &= "CSVファイル, 修正済フラグ) VALUES("
										strSQL &= "'" & strLotID & "'"  'ロットID
										strSQL &= ", " & iRecNumber 'レコード番号
										strSQL &= ", " & iSeq   'シーケンス
										strSQL &= ", 5" '不備種別(5：文字数超過)
										strSQL &= ", '" & row(2) & "'"  '会社コード
										strSQL &= ", '" & row(3) & "'"  '所属事業所コード
										strSQL &= ", '" & row(16) & "'" '健診種別
										strSQL &= ", '" & row(4) & "'"  '会社
										strSQL &= ", '" & row(5) & "'"  '所属事業所
										strSQL &= ", '" & row(1) & "'"  '社員コード
										strSQL &= ", '" & row(13) & "'" '性別
										strSQL &= ", '" & row(15) & "'" '生年月日
										strSQL &= ", '" & row(11) & "'" '氏名姓
										strSQL &= ", '" & row(12) & "'" '氏名名
										strSQL &= ", '" & row(108) & "'"    '帳票タイプ
										strSQL &= ", '" & row(14) & "'" '採用年月日
										strSQL &= ", '" & row(17) & "'" '受診日
										'レコードが存在したら「会場局名」「健康管理施設名」をセットする
										If dtKyokusho.Rows.Count > 0 Then
											strSQL &= ", '" & dtKyokusho.Rows(0)("会場局名") & "'"  '会場局名
											strSQL &= ", '" & dtKyokusho.Rows(0)("健康管理施設名") & "'"   '健康管理施設名
										Else
											strSQL &= ", '', ''"
										End If
										strSQL &= ", '" & strColumnName(iCol + 2) & "'"   '不備項目(ロットID、レコード番号があるので項目名は+2する)
										strSQL &= ", '" & XmlSettings.Instance.DataExceed & "(" & row(iCol) & ")'"  '文字数超過
										strSQL &= ", ''"    '修正内容(デフォルト'')
										strSQL &= ", '" & strImportDateTime & "'"   'インポート日時
										strSQL &= ", '" & System.IO.Path.GetFileName(strLeafletCSV(0)) & "'"    'CSVファイル
										strSQL &= ", 0)"    '修正済フラグ
										sqlProcess.DB_UPDATE(strSQL)

									End If
								Next
								'===============================================================
								'T_リーフレットテーブルに実データを書き込む
								'2018/03/30
								'リーフレット重複フラグが立っている場合は「T_リーフレット_重複」テーブルに格納する
								If blnDuplicate Then
									'重複
									strSQL = "INSERT INTO T_リーフレット_重複 ("
								Else
									strSQL = "INSERT INTO T_リーフレット ("
								End If

								For iCol As Integer = 0 To strColumnName.Count - 1
									If iCol = 0 Then
										strSQL &= strColumnName(iCol)
									ElseIf iCol = strColumnName.Count - 1 Then
										'最終項目はカッコで閉じる
										strSQL &= ", " & strColumnName(iCol) & ") VALUES("
									Else
										strSQL &= ", " & strColumnName(iCol)
									End If
								Next

								strSQL &= "'" & strLotID & "'"  'ロットID
                                strSQL &= ", " & iRecNumber 'レコード番号
                                For iCol As Integer = 0 To row.Count - 1
                                    'シングルクォート「'」が文字列中に発生するとSQL文が破錠してしまうため「''」に置換する
                                    'カラム内の改行は「\n」に変換する
                                    strSQL &= ", '" & row(iCol).Replace("'", "''").Replace(vbNewLine, "\n") & "'"
                                Next
                                strSQL &= ")"
                                sqlProcess.DB_UPDATE(strSQL)

								'===============================================================
								'2018/07/30
								'「BMI」のみ「BMIカロリーマップ(BMIMAP)」のレコードを追加でINSERTする
								If row(108) = "BMI" Then
									'リーフレット重複フラグが立っている場合は「T_リーフレット_重複」テーブルに格納する
									If blnDuplicate Then
										'重複
										strSQL = "INSERT INTO T_リーフレット_重複 ("
									Else
										strSQL = "INSERT INTO T_リーフレット ("
									End If

									For iCol As Integer = 0 To strColumnName.Count - 1
										If iCol = 0 Then
											strSQL &= strColumnName(iCol)
										ElseIf iCol = strColumnName.Count - 1 Then
											'最終項目はカッコで閉じる
											strSQL &= ", " & strColumnName(iCol) & ") VALUES("
										Else
											strSQL &= ", " & strColumnName(iCol)
										End If
									Next

									strSQL &= "'" & strLotID & "'"  'ロットID
									strSQL &= ", " & iRecNumber 'レコード番号
									For iCol As Integer = 0 To row.Count - 1
										'シングルクォート「'」が文字列中に発生するとSQL文が破錠してしまうため「''」に置換する
										'カラム内の改行は「\n」に変換する
										'帳票タイプは「BMIMAP」に書き換える
										If iCol = 108 Then
											'帳票タイプだった
											strSQL &= ", 'BMIMAP'"
										Else
											strSQL &= ", '" & row(iCol).Replace("'", "''").Replace(vbNewLine, "\n") & "'"
										End If
									Next
									strSQL &= ")"
									sqlProcess.DB_UPDATE(strSQL)
								End If
								'===============================================================

								iRecCountLeaflet += 1

                            End While

                            WriteLstResult(Me.lstResult, "インポート終了：" & strLeafletCSV(0))
                            WriteLstResult(Me.lstResult, iRecCountLeaflet & "件インポートしました")
                            iFileCountLeaflet += 1

                        End Using
                        WriteLstResult(Me.lstResult, "--------------------------------------------------------------------------------", ResultMark.InformationMark)

                    End If

                Else
                    '解凍処理失敗
                    WriteLstResult(Me.lstResult, "解凍処理失敗", ResultMark.ErrorMark)
                    System.IO.Directory.Delete(strDestFolder, True)
                    WriteLstResult(Me.lstResult, "関連フォルダ削除：" & strDestFolder)
                    WriteLstResult(Me.lstResult, "--------------------------------------------------------------------------------", ResultMark.InformationMark)

                End If

                'このZIPファイル内のレコードカウントを取得
                If iFileCountCheckup > 0 Then
                    ReDim Preserve iTargetRecordCountCheckup(iFileCountCheckup - 1)
                    iTargetRecordCountCheckup(iFileCountCheckup - 1) = iRecCountCheckup
                End If
                If iFileCountLeaflet > 0 Then
                    ReDim Preserve iTargetRecordCountLeaflet(iFileCountLeaflet - 1)
                    iTargetRecordCountLeaflet(iFileCountLeaflet - 1) = iRecCountLeaflet
                End If

                '2017/10/03
                'ZIPファイルを出力フォルダに移動するように変更
                WriteLstResult(Me.lstResult, "ZIPファイル移動：" & strDestFolder)
                My.Computer.FileSystem.MoveFile(strFile, strDestFolder & "\" & System.IO.Path.GetFileName(strFile), True)

                WriteLstResult(Me.lstResult, "================================================================================", ResultMark.InformationMark)

            Next

            WriteLstResult(Me.lstResult, "判定票レコード単位の重量を計算中...", ResultMark.DoingMark)
            '各レコードの重量計算を行う
            'リーフレットが無いレコードは、「リーフレット無効」項目を立てる
            '既に「リーフレット無効」が立っているレコードは、判定票のみの重量とする
            strSQL = "SELECT 重量 FROM M_重量 "
            strSQL &= "WHERE 帳票種別ID = 4"
            '判定票の重量を取得
            Dim dblCheckupWeight As Double = sqlProcess.DB_EXECUTE_SCALAR(strSQL)

            strSQL = "SELECT ロットID, レコード番号, リーフレット無効 FROM T_判定票管理 "
            strSQL &= "WHERE ロットID = '" & strLotID & "' "
            strSQL &= "ORDER BY ロットID, レコード番号"
            dt = sqlProcess.DB_SELECT_DATATABLE(strSQL)
            For iRow As Integer = 0 To dt.Rows.Count - 1
                Dim iRec As Integer = dt.Rows(iRow)("レコード番号")
                Console.WriteLine(dt.Rows(iRow)("リーフレット無効"))
                'リーフレット無効が立っていたら判定表のみの重量
                '2017/07/19
                'リーフレット無効が立っていてもリーフレット枚数を取得する
                '※重量は判定票のみとする
                If dt.Rows(iRow)("リーフレット無効") = True Then
                    strSQL = "SELECT COUNT(*) FROM T_リーフレット "
                    strSQL &= "WHERE ロットID = '" & dt.Rows(iRow)("ロットID") & "' "
                    strSQL &= "AND レコード番号 = " & dt.Rows(iRow)("レコード番号")
                    Dim iLeafletSheet As Integer = sqlProcess.DB_EXECUTE_SCALAR(strSQL)

                    strSQL = "UPDATE T_判定票管理 SET 重量 = " & dblCheckupWeight
                    strSQL &= ", リーフレット枚数 = " & iLeafletSheet & " "
                    strSQL &= "WHERE ロットID = '" & dt.Rows(iRow)("ロットID") & "' "
                    strSQL &= "AND レコード番号 = " & dt.Rows(iRow)("レコード番号")
                    sqlProcess.DB_UPDATE(strSQL)
                Else
                    'そうでない場合は、該当ロットID、レコード番号で「T_リーフレット」内を検索し、該当枚数の重量を加算する
                    strSQL = "SELECT COUNT(*) FROM T_リーフレット "
                    strSQL &= "WHERE ロットID = '" & dt.Rows(iRow)("ロットID") & "' "
                    strSQL &= "AND レコード番号 = " & dt.Rows(iRow)("レコード番号")
                    Dim iLeafletSheet As Integer = sqlProcess.DB_EXECUTE_SCALAR(strSQL)
                    'リーフレット枚数が0の場合は、T_判定票.リーフレット無効を1とする
                    If iLeafletSheet > 0 Then
                        '枚数毎の重量をM_重量より取得する
                        strSQL = "SELECT 重量 FROM M_重量 "
                        strSQL &= "WHERE 帳票種別ID = 5 "
                        strSQL &= "AND 枚数 = " & iLeafletSheet
                        Dim dblLeafletWeight As Double = sqlProcess.DB_EXECUTE_SCALAR(strSQL)
                        Dim dblWeight As Double = dblLeafletWeight + dblCheckupWeight   '枚数毎の重量＋判定票の重量
                        strSQL = "UPDATE T_判定票管理 SET 重量 = " & dblWeight
                        strSQL &= ", リーフレット枚数 = " & iLeafletSheet & " "
                        strSQL &= "WHERE ロットID = '" & dt.Rows(iRow)("ロットID") & "' "
                        strSQL &= "AND レコード番号 = " & dt.Rows(iRow)("レコード番号")
                        sqlProcess.DB_UPDATE(strSQL)
                    Else
                        'リーフレットカウントが0だった場合、判定票のみの重量とする
                        'リーフレット無効フラグを立てる
                        strSQL = "UPDATE T_判定票管理 SET 重量 = " & dblCheckupWeight
                        strSQL &= ", リーフレット無効 = 1 "
                        strSQL &= ", リーフレット枚数 = 0 "
                        strSQL &= "WHERE ロットID = '" & dt.Rows(iRow)("ロットID") & "' "
                        strSQL &= "AND レコード番号 = " & dt.Rows(iRow)("レコード番号")
                        sqlProcess.DB_UPDATE(strSQL)

                    End If
                End If
            Next
            WriteLstResult(Me.lstResult, "判定票レコード単位の重量を計算終了")

            'データ不備が１件でもあった場合、判定票データ不備内容.xlsxに内容を書き出す
            If iIncompleteCount > 0 Or iDuplicateCount > 0 Then

                WriteLstResult(Me.lstResult, "データ不備が" & iIncompleteCount & "件見つかりました。", ResultMark.WarningMark)
                WriteLstResult(Me.lstResult, "レコード重複が" & iDuplicateCount & "件見つかりました。", ResultMark.WarningMark)

                'エクセル出力処理(保留)
                '不備内容をエクセルに出力
                strSQL = "SELECT ROW_NUMBER() OVER (PARTITION BY 1 ORDER BY CSVファイル, レコード番号, シーケンス) AS 連番, "
                strSQL &= "会社コード, 所属事業所コード, 健診種別, 会場局名, 会社, 所属事業所, 社員コード, 性別, 生年月日, "
                strSQL &= "氏名姓, 氏名名, 採用年月日, 受診日, 健康管理施設名, 不備項目, 不備内容, 修正内容, "
                strSQL &= "インポート日時, CSVファイル "
                strSQL &= "FROM T_判定票_不備内容 "
                strSQL &= "WHERE ロットID = '" & strLotID & "'"
                Dim dtDataIncomplete As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
                strSaveFile = "データ不備内容_" & strLotID.Substring(0, 8) & ".xlsx"
                strSaveFolder = strImportToFolder & "\データ不備内容"
                If Not System.IO.Directory.Exists(strSaveFolder) Then
                    My.Computer.FileSystem.CreateDirectory(strSaveFolder)
                End If
                '2017/09/29
                '同日に複数のロットを流すと不備内容エクセルファイルが上書きされてしまうため
                '2つ目以降はファイル名の末尾に「_2」と付ける
                If System.IO.File.Exists(strSaveFolder & "\" & strSaveFile) Then
                    For i As Integer = 2 To 99
                        strSaveFile = "データ不備内容_" & strLotID.Substring(0, 8) & "_" & i & ".xlsx"
                        If Not System.IO.File.Exists(strSaveFolder & "\" & strSaveFile) Then
                            Exit For
                        End If
                    Next
                End If
                ExcelProcess.WriteExcelFile(ExcelOutputCategory.DataIncomplete, strSaveFolder & "\" & strSaveFile, dtDataIncomplete, "出力日付：" & Date.Now.ToString("yyyy/MM/dd"))
                SetPassword(strSaveFolder & "\" & strSaveFile, XmlSettings.Instance.ExcelPassword)
                WriteLstResult(Me.lstResult, "エクセルファイル出力完了：" & strSaveFile, ResultMark.InformationMark)
            End If

            '重複レコード件数を出力
            WriteLstResult(Me.lstResult, "重複レコード" & vbTab & iDuplicateCount & "件")

            '各ZIPファイルのインポート件数を出力
            Dim iTotalCountCheckup As Integer = 0
            Dim iTotalCountLeaflet As Integer = 0
            For i As Integer = 0 To strTargetFiles.Count - 1
                '判定票件数
                WriteLstResult(Me.lstResult, strTargetFiles(i) & "：判定票：" & vbTab & iTargetRecordCountCheckup(i) & "件")
                iTotalCountCheckup += iTargetRecordCountCheckup(i)
                'リーフレット件数
                If Not iTargetRecordCountLeaflet Is Nothing Then
                    WriteLstResult(Me.lstResult, strTargetFiles(i) & "：リーフレット：" & vbTab & iTargetRecordCountLeaflet(i) & "件")
                    'リーフレットは件数が1件以上の場合インクリメント
                    If iTargetRecordCountLeaflet(i) > 0 Then
                        iTotalCountLeaflet += iTargetRecordCountLeaflet(i)
                    End If
                Else
                    'リーフレットCSVがなかった場合はカウント0
                    iTotalCountLeaflet = 0
                End If
            Next

            WriteLstResult(Me.lstResult, "総計(判定票)" & vbTab & iFileCountCheckup & "ファイル" & vbTab & iTotalCountCheckup & "件")
            WriteLstResult(Me.lstResult, "総計(リーフレット)" & vbTab & iFileCountLeaflet & "ファイル" & vbTab & iTotalCountLeaflet & "件")

            If Not System.IO.Directory.Exists(strLogFolder) Then
                My.Computer.FileSystem.CreateDirectory(strLogFolder)
            End If
            OutputImportLog(Me.lstResult, strLogFolder, "_Import_")

            '===============================================================
            '印刷準備処理
            '===============================================================
            '不備件数を取得して続行するかどうか判断を促す
            strSQL = "SELECT COUNT(*) FROM T_判定票_不備内容 "
            strSQL &= "WHERE ロットID = '" & strLotID & "'"
            Dim iNoGoodCount As Integer = sqlProcess.DB_EXECUTE_SCALAR(strSQL)
            If iNoGoodCount > 0 Then
                If MessageBox.Show(iNoGoodCount & "件の不備が見つかりました" & vbNewLine & "印刷準備処理を続行しますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                    MessageBox.Show("準備ができ次第、インポート日を選択して「印刷準備」ボタンを押下してください", "確認", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    Me.lstResult.Items.Clear()
                    WriteLstResult(Me.lstResult, "印刷準備処理開始(" & strLotID & ")")
                    PrintPreparation(strLotID, Me.lstResult, Me.txtLogFolder.Text)

                    '2017/10/03
                    '作業票に差し替え
                    '               '重量ヘッダ単位件数出力
                    '               strSaveFile = "重量ヘッダ単位件数_" & strImportDate & ".xlsx"
                    'strSaveFolder = strImportToFolder & "\重量ヘッダ単位件数"
                    strSaveFile = "作業票_" & strImportDate & ".xlsx"
                    strSaveFolder = strImportToFolder & "\作業票"
                    If Not System.IO.Directory.Exists(strSaveFolder) Then
                        My.Computer.FileSystem.CreateDirectory(strSaveFolder)
                    End If
                    WeightHeaderToExcel(strSaveFolder & "\" & strSaveFile, strLotID)
                    WriteLstResult(Me.lstResult, "作業票出力完了：" & strSaveFolder & "\" & strSaveFile, ResultMark.InformationMark)
                End If
            Else
                '不備がなかった場合、続けて印刷準備処理を行う
                Me.lstResult.Items.Clear()
                WriteLstResult(Me.lstResult, "印刷準備処理開始(" & strLotID & ")")
                PrintPreparation(strLotID, Me.lstResult, strLogFolder)

                '2017/10/03
                '作業票に差し替え
                '            '重量ヘッダ単位件数出力
                '            strSaveFile = "重量ヘッダ単位件数_" & strImportDate & ".xlsx"
                'strSaveFolder = strImportToFolder & "\重量ヘッダ単位件数"
                strSaveFile = "作業票_" & strImportDate & ".xlsx"
                strSaveFolder = strImportToFolder & "\作業票"
                If Not System.IO.Directory.Exists(strSaveFolder) Then
                    My.Computer.FileSystem.CreateDirectory(strSaveFolder)
                End If
                WeightHeaderToExcel(strSaveFolder & "\" & strSaveFile, strLotID)
                WriteLstResult(Me.lstResult, "作業票出力完了：" & strSaveFolder & "\" & strSaveFile, ResultMark.InformationMark)
            End If

            MessageBox.Show("インポート処理が終了しました", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception

            Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & ex.StackTrace)
            MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally

            sqlProcess.Close()
            UpdateImportDate()
            EnableControls(Me, True)

        End Try

	End Sub

	''' <summary>
	''' データ削除(テスト用)
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub btnDeleteTest_Click(sender As Object, e As EventArgs) Handles btnDeleteTest.Click

        Dim frm As New frmPassword
        If frm.ShowDialog(Me) = DialogResult.Cancel Then
            Exit Sub
        End If

        Dim strLotID As String = Me.cmbLotID.SelectedValue

        If MessageBox.Show("指定されたロットIDを削除対象とします" & vbNewLine & "よろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
            Exit Sub
        End If
        'If MessageBox.Show("指定されたロットID[" & strLotID & "]の全てのテーブル内容を削除します" & vbNewLine & "よろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
        '    Exit Sub
        'End If

        Dim sqlProcess As New SQLProcess
		Dim strSQL As String = ""

		Try
			strSQL = "UPDATE T_ロット管理 SET 削除フラグ = 1 "
			strSQL &= "WHERE ロットID = '" & Me.cmbLotID.SelectedValue & "'"
			sqlProcess.DB_UPDATE(strSQL)

			MessageBox.Show("削除対象処理が終了しました", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information)

			UpdateImportDate()

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & ex.StackTrace)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		Finally

			sqlProcess.Close()

		End Try
	End Sub

	''' <summary>
	''' 該当ロットの各テーブルデータを完全削除する
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub btnDelete2_Click(sender As Object, e As EventArgs) Handles btnDelete2.Click

		Dim strLotID As String = Me.cmbLotID.SelectedValue

		If MessageBox.Show("指定されたロットIDを完全削除します" & vbNewLine & "よろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
			Exit Sub
		End If

		If MessageBox.Show("本当によろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
			Exit Sub
		End If

		Dim sqlProcess As New SQLProcess
		Dim strSQL As String = ""

		Try
			strSQL = "DELETE FROM T_判定票 "
			strSQL &= "WHERE ロットID = '" & strLotID & "'"
			sqlProcess.DB_UPDATE(strSQL)
			strSQL = "DELETE FROM T_判定票管理 "
			strSQL &= "WHERE ロットID = '" & strLotID & "'"
			sqlProcess.DB_UPDATE(strSQL)
			strSQL = "DELETE FROM T_リーフレット "
			strSQL &= "WHERE ロットID = '" & strLotID & "'"
			sqlProcess.DB_UPDATE(strSQL)
			strSQL = "DELETE FROM T_リーフレット_重複 "
			strSQL &= "WHERE ロットID = '" & strLotID & "'"
			sqlProcess.DB_UPDATE(strSQL)
			strSQL = "DELETE FROM T_判定票_不備内容 "
			strSQL &= "WHERE ロットID = '" & strLotID & "'"
			sqlProcess.DB_UPDATE(strSQL)
			strSQL = "DELETE FROM T_印刷管理 "
			strSQL &= "WHERE ロットID = '" & strLotID & "'"
			sqlProcess.DB_UPDATE(strSQL)
			strSQL = "DELETE FROM T_印刷ソート "
			strSQL &= "WHERE ロットID = '" & strLotID & "'"
			sqlProcess.DB_UPDATE(strSQL)
			strSQL = "DELETE FROM T_判定票印刷 "
			strSQL &= "WHERE ロットID = '" & strLotID & "'"
			sqlProcess.DB_UPDATE(strSQL)
			strSQL = "DELETE FROM T_リーフレット印刷 "
			strSQL &= "WHERE ロットID = '" & strLotID & "'"
			sqlProcess.DB_UPDATE(strSQL)
			strSQL = "DELETE FROM T_対象者一覧印刷 "
			strSQL &= "WHERE ロットID = '" & strLotID & "'"
			sqlProcess.DB_UPDATE(strSQL)
			strSQL = "DELETE FROM T_保健指導名簿印刷 "
			strSQL &= "WHERE ロットID = '" & strLotID & "'"
			sqlProcess.DB_UPDATE(strSQL)
			strSQL &= "DELETE FROM T_複数封筒計算 "
			strSQL &= "WHERE ロットID = '" & strLotID & "'"
			sqlProcess.DB_UPDATE(strSQL)
			strSQL &= "DELETE FROM T_ロット管理 "
			strSQL &= "WHERE ロットID = '" & strLotID & "'"
			sqlProcess.DB_UPDATE(strSQL)

			MessageBox.Show("該当ロットの各種テーブルを削除しました", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information)

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & ex.StackTrace)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		Finally

			sqlProcess.Close()

		End Try

	End Sub


	''' <summary>
	''' 印刷準備処理
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub btnPrintPreparation_Click(sender As Object, e As EventArgs) Handles btnPrintPreparation.Click

        If IsNull(Me.cmbLotID.SelectedValue) Then
            MessageBox.Show("ロットIDを選択してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Dim sqlProcess As New SQLProcess
        Dim strSQL As String = ""

        Try
            '2017/09/05
            '該当ロットが既にT_印刷管理テーブルに存在していたら警告を出す
            strSQL = "SELECT COUNT(*) FROM T_印刷管理 "
            strSQL &= "WHERE ロットID = '" & Me.cmbLotID.SelectedValue & "'"

            If CInt(sqlProcess.DB_EXECUTE_SCALAR(strSQL)) > 0 Then
                If MessageBox.Show("既に印刷準備が完了しているロットです" & vbNewLine & "再度印刷準備処理を行いますか？" & vbNewLine & "インポート日時：" & Me.cmbLotID.SelectedItem.ToString, "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                    Exit Sub
                End If
            End If
            If MessageBox.Show("印刷前準備処理を開始します" & vbNewLine & "よろしいですか？" & vbNewLine & "インポート日時：" & Me.cmbLotID.SelectedItem.ToString, "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                Exit Sub
            End If

            EnableControls(Me, False)

            '保存フォルダ作成用
            'Dim strImportDate As String = Me.dtpSendDate.Value.ToString("yyyyMMdd")
            Dim strImportDate As String = Me.cmbLotID.SelectedValue.ToString.Substring(0, 8)
            '保存先フォルダ
            Dim strImportToFolder As String = Trim(Me.txtImportTo.Text) & "\" & strImportDate
            If Not System.IO.Directory.Exists(strImportToFolder) Then
                My.Computer.FileSystem.CreateDirectory(strImportToFolder)
            End If
            'ログ保存先フォルダ
            Dim strLogFolder As String = Trim(Me.txtLogFolder.Text) & "\" & strImportDate
            If Not System.IO.Directory.Exists(strLogFolder) Then
                My.Computer.FileSystem.CreateDirectory(strLogFolder)
            End If

            Dim strSaveFile As String = ""  '出力エクセルファイル
            Dim strSaveFolder As String = ""    '出力エクセルフォルダ
            '印刷準備処理
            PrintPreparation(Me.cmbLotID.SelectedValue, Me.lstResult, strLogFolder)

            ''重量ヘッダ単位件数出力
            'strSaveFile = "重量ヘッダ単位件数_" & strImportDate & ".xlsx"
            'strSaveFolder = strImportToFolder & "\重量ヘッダ単位件数"
            '2017/10/03
            '作業票と差し替え
            strSaveFile = "作業票_" & strImportDate & ".xlsx"
            strSaveFolder = strImportToFolder & "\作業票"
            If Not System.IO.Directory.Exists(strSaveFolder) Then
                My.Computer.FileSystem.CreateDirectory(strSaveFolder)
            End If
            WeightHeaderToExcel(strSaveFolder & "\" & strSaveFile, Me.cmbLotID.SelectedValue)
            WriteLstResult(Me.lstResult, "作業票出力完了：" & strSaveFolder & "\" & strSaveFile, ResultMark.InformationMark)

            MessageBox.Show("印刷準備処理が完了しました", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception

            Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & ex.StackTrace)
            MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally

            sqlProcess.Close()
            EnableControls(Me, True)

        End Try

    End Sub

    ''' <summary>
    ''' 作業票出力ボタン押下時
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnOutWorkOrder_Click(sender As Object, e As EventArgs) Handles btnOutWorkOrder.Click

        If MessageBox.Show("選択されているロットの作業表を出力します" & vbNewLine & "よろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
            Exit Sub
        End If

        Dim strLotID As String = Me.cmbLotID.SelectedValue
        '保存フォルダ作成用
        Dim strImportDate As String = Strings.Left(Me.cmbLotID.SelectedValue, 8)    'ロットIDの先頭8桁
        '保存先フォルダ
        Dim strImportToFolder As String = Trim(Me.txtImportTo.Text) & "\" & strImportDate
        Dim strSaveFile As String = ""  '出力エクセルファイル
        Dim strSaveFolder As String = ""    '出力エクセルフォルダ
        strSaveFile = "作業票_" & strImportDate & ".xlsx"
        strSaveFolder = strImportToFolder & "\作業票"
        If Not System.IO.Directory.Exists(strSaveFolder) Then
            My.Computer.FileSystem.CreateDirectory(strSaveFolder)
        End If
        WeightHeaderToExcel(strSaveFolder & "\" & strSaveFile, strLotID)

        MessageBox.Show("作業票を出力しました" & vbNewLine & strSaveFolder & "\" & strSaveFile, "確認", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

#End Region

#Region "プライベートメソッド"

    ''' <summary>
    ''' 初期化処理
    ''' </summary>
    Private Sub Initialize()

        '設定ファイルより読み込む
        XmlSettings.LoadFromXmlFile()
        Me.txtImportFrom.Text = XmlSettings.Instance.ImportFromFolder
        Me.txtImportTo.Text = XmlSettings.Instance.ImportToFolder
        Me.txtLogFolder.Text = XmlSettings.Instance.ImportLogFolder
        'パスワード用日付をセット(本日８桁)
        Me.txtPasswordDate.Text = Date.Now.ToString("yyyyMMdd")
		CaptionDisplayMode = StatusDisplayMode.None

		'デフォルト発送日をセット
		Dim dtImportDate As Date = Date.Today
		Me.dtpSendDate.Value = getBusinessDay(dtImportDate, 4)  '(本日含めて)5営業日進める

		''インポート日時コンボボックスのイベントを殺す
		'RemoveHandler cmbLotID.SelectedIndexChanged, AddressOf cmbLotID_SelectedIndexChanged

		'Dim sqlProcess As New SQLProcess
		'Dim strSQL As String = ""

		'Try
		'    strSQL = "SELECT ロットID, インポート日時 FROM T_判定票管理 "
		'    strSQL &= "GROUP BY ロットID, インポート日時 "
		'    strSQL &= "ORDER BY ロットID DESC, インポート日時"
		'    Dim dt As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
		'    SetComboValue(Me.cmbLotID, dt, False)

		'    ''インポート日時コンボボックスのイベントを生かす
		'    'AddHandler cmbLotID.SelectedIndexChanged, AddressOf cmbLotID_SelectedIndexChanged
		'    Me.cmbLotID.SelectedIndex = 0

		'Catch ex As Exception

		'    Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & ex.StackTrace)
		'    MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		'Finally

		'    sqlProcess.Close()

		'End Try

	End Sub

	''' <summary>
	''' インポート日時取得
	''' </summary>
	Private Sub UpdateImportDate()

		Dim sqlProcess As New SQLProcess
		Dim strSQL As String = ""

		Try
			strSQL = "SELECT ロットID, インポート日時 FROM T_ロット管理 "
			strSQL &= "WHERE 削除フラグ = 0 "
			strSQL &= "GROUP BY ロットID, インポート日時 "
			strSQL &= "ORDER BY ロットID DESC, インポート日時"
			Dim dt As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
			SetComboValue(Me.cmbLotID, dt, False)

			Me.cmbLotID.SelectedValue = LotID()

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & ex.StackTrace)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		Finally

			sqlProcess.Close()

		End Try
	End Sub

	''' <summary>
	''' 対象ロットIDの重量ヘッダ単位の件数をエクセルに出力する
	''' </summary>
	''' <param name="strExcelFile"></param>
	''' <param name="strLotID"></param>
	Private Sub WeightHeaderToExcel(ByVal strExcelFile As String, ByVal strLotID As String)

		Dim sqlProcess As New SQLProcess
		Dim strSQL As String = ""

		Try
			'重量ヘッダ単位件数出力
			'2018/03/30
			'不備、修正がうまく出力されないので別途DATATABLEを作成する
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
			'strSQL &= "AND T1.所属事業所コード = T2.所属事業所コード AND T1.印刷ID = T2.印刷ID LEFT OUTER JOIN "
			'strSQL &= "T_判定票管理 AS T3 ON T1.ロットID = T3.ロットID AND T1.レコード番号 = T3.レコード番号 "
			'strSQL &= "WHERE T1.ロットID = '" & strLotID & "' "
			'strSQL &= "GROUP BY T2.重量ヘッダ "
			'strSQL &= "ORDER BY T2.重量ヘッダ"
			strSQL = "SELECT T2.重量ヘッダ AS ヘッダ, "
			strSQL &= "CONVERT(VARCHAR, MIN(T2.ラベル連番)) + '～' + CONVERT(VARCHAR, MAX(T2.ラベル連番)) AS ラベル連番, "
			strSQL &= "SUM(CASE WHEN T1.帳票種別ID = 0 THEN 1 ELSE 0 END) AS ラベル, "
			strSQL &= "SUM(CASE WHEN T1.帳票種別ID = 2 THEN 1 ELSE 0 END) AS 対象者, "
			strSQL &= "SUM(CASE WHEN T1.帳票種別ID = 3 THEN 1 ELSE 0 END) AS 保健指導, "
			strSQL &= "SUM(CASE WHEN T1.帳票種別ID = 4 THEN 1 ELSE 0 END) AS 判定票, "
			strSQL &= "SUM(CASE WHEN T1.帳票種別ID = 5 AND T1.枚数 < 6 THEN 1 ELSE 0 END) AS リーフ件, "
			strSQL &= "SUM(CASE WHEN T1.帳票種別ID = 5 AND T1.枚数 < 6 THEN T1.枚数 ELSE 0 END) AS リーフ枚, "
			'2018/08/02
			'T1.枚数 = 6ではなく6以上に変更、リーフ6枚の追加
			'strSQL &= "SUM(CASE WHEN T1.枚数 = 6 THEN 1 ELSE 0 END) AS リーフ6件, "
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
			Dim dtWeightCount As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)

			'2018/03/30
			'重量ヘッダ単位の不備、修正済件数を別途取得する
			'判定票、リーフレット別々に取得して、グリッドにセットする際に合算する
			'判定票(不備、修正)
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

			'リーフレット(不備、修正)
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

			'入庫日、発送日、ZIPファイル、局所数の取得
			strSQL = "SELECT A1.インポート日時, A1.発送日, A1.ZIPファイル, COUNT(A1.カウント) AS 局所数 "
            strSQL &= "FROM (SELECT T1.インポート日時, T1.発送日, T1.ZIPファイル, COUNT(T3.会社コード) AS カウント "
            strSQL &= "FROM T_ロット管理 AS T1 INNER JOIN "
            strSQL &= "T_判定票管理 AS T2 ON T1.ロットID = T2.ロットID INNER JOIN "
            strSQL &= "M_局所 AS T3 ON T2.会社コード = T3.会社コード AND T2.所属事業所コード = T3.局所コード "
            strSQL &= "WHERE T1.ロットID = '" & strLotID & "' "
            strSQL &= "GROUP BY T1.インポート日時, T1.発送日, T1.ZIPファイル, T3.会社コード, T3.局所コード) AS A1 "
            strSQL &= "GROUP BY A1.インポート日時, A1.発送日, A1.ZIPファイル"
            Dim dtLocalCount As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
            '健康管理施設数の取得
            strSQL = "SELECT COUNT(*) AS 健康管理施設数 "
            strSQL &= "FROM (SELECT COUNT(T3.健康管理施設コード) AS カウント "
            strSQL &= "FROM T_ロット管理 AS T1 INNER JOIN "
            strSQL &= "T_判定票管理 AS T2 ON T1.ロットID = T2.ロットID INNER JOIN "
            strSQL &= "M_局所 AS T3 ON T2.会社コード = T3.会社コード AND T2.所属事業所コード = T3.局所コード "
            strSQL &= "WHERE T1.ロットID = '" & strLotID & "' "
            strSQL &= "GROUP BY T3.健康管理施設コード) AS A1"
            Dim iFacilityCount As Integer = sqlProcess.DB_EXECUTE_SCALAR(strSQL)
            '判定票不備件数
            strSQL = "SELECT COUNT(*) FROM T_判定票_不備内容 "
            strSQL &= "WHERE CSVファイル LIKE 'Checkup%' "
            strSQL &= "AND ロットID = '" & strLotID & "'"
            Dim iCheckupDefect As Integer = sqlProcess.DB_EXECUTE_SCALAR(strSQL)
            'リーフレット不備、リーフレット重複
            strSQL = "SELECT ISNULL(SUM(CASE WHEN 修正内容 = '印刷対象外' THEN 0 ELSE 1 END), 0) AS リーフレット不備, "
            strSQL &= "ISNULL(SUM(CASE WHEN 修正内容 = '印刷対象外' THEN 1 ELSE 0 END), 0) AS リーフレット重複 "
            strSQL &= "FROM T_判定票_不備内容 "
            strSQL &= "WHERE CSVファイル LIKE 'Leaflet%' "
            strSQL &= "AND ロットID = '" & strLotID & "'"
            Dim dtLeafletDefect As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
            Dim iLeafDefect As Integer = dtLeafletDefect.Rows(0)("リーフレット不備")
            Dim iLeafDupe As Integer = dtLeafletDefect.Rows(0)("リーフレット重複")
            '対象者一覧ファイル数
            strSQL = "SELECT COUNT(*) AS 対象者一覧件数 FROM "
            strSQL &= "(SELECT T2.健康管理施設コード, T3.略称 "
            strSQL &= "FROM T_判定票管理 AS T1 INNER JOIN "
            strSQL &= "M_局所 AS T2 ON T1.会社コード = T2.会社コード "
            strSQL &= "AND T1.所属事業所コード = T2.局所コード INNER JOIN "
            strSQL &= "M_健康管理施設 AS T3 ON T2.健康管理施設コード = T3.健康管理施設コード "
            strSQL &= "WHERE ロットID = '" & strLotID & "' "
            strSQL &= "GROUP BY T2.健康管理施設コード, T3.略称) AS A1"
            Dim iTargetList As Integer = sqlProcess.DB_EXECUTE_SCALAR(strSQL)

			ExcelProcess.WriteExcelFile(ExcelOutputCategory.WorkOrder, strExcelFile, dtWeightCount, "",
										dtCheckup, dtLeaflet, dtLocalCount, dtBMI, iFacilityCount, iCheckupDefect, iLeafDefect, iLeafDupe, iTargetList)

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & ex.StackTrace)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		Finally

			sqlProcess.Close()

		End Try
	End Sub

    ''' <summary>
    ''' シフトJISのコード範囲内か、また文字がセットされているアドレスか
    ''' </summary>
    ''' <param name="strString"></param>
    ''' <param name="lstCode">作成済みの文字コードList</param>
    ''' <returns></returns>
    Private Function StringCodeCheck(ByVal strSource As String, ByVal lstCode As List(Of String)) As Boolean

        Dim enc As System.Text.Encoding = System.Text.Encoding.GetEncoding("Shift-JIS")

        Try

            For Each c As Char In strSource
                Dim blnNormal As Boolean = False
                'strSQL = "SELECT COUNT(*) FROM M_文字コード "
                '該当文字の16進数を作成
                Dim byteArr As Byte() = enc.GetBytes(c)
                Dim strResult As String = ""
                For Each byteStr As Byte In byteArr

                    strResult &= DecToHex(byteStr).ToUpper()

                Next
                'List内に存在するか
                For Each strCode As String In lstCode
                    If strResult = strCode Then
                        blnNormal = True
                    End If
                Next

                If blnNormal Then
                    '見つかった場合次のループへ
                    Continue For
                Else
                    '見つからなかった
                    Return False
                End If

            Next

            'Dim iCount As Integer = sqlProcess.DB_EXECUTE_SCALAR(strSQL)
            'If iCount = strSource.Length Then
            '    '全ての文字コードが該当した
            '    Return True
            'Else
            '    '1つ以上の文字が該当から外れた
            '    Return False
            'End If

            Return True

        Catch ex As Exception

            Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & ex.StackTrace)
            MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False

        End Try

    End Function

#End Region

End Class