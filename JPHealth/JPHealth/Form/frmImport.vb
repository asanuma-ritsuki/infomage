Imports Microsoft.VisualBasic.FileIO

Public Class frmImport

#Region "プライベート変数"

	Private Enum LogicCategory
		Checkup
		Leaflet
	End Enum

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
		'設定ファイルより読み込む
		XmlSettings.LoadFromXmlFile()
		Me.txtImportFrom.Text = XmlSettings.Instance.ImportFromFolder
		Me.txtImportTo.Text = XmlSettings.Instance.ImportToFolder
		Me.txtLogFolder.Text = XmlSettings.Instance.ImportLogFolder
		Me.CaptionDisplayMode = StatusDisplayMode.None

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
	Private Sub TextBox_Enter(sender As Object, e As EventArgs) Handles txtImportFrom.Enter, txtImportTo.Enter, txtLogFolder.Enter

		CType(sender, TextBox).BackColor = Color.LightGreen
		CType(sender, TextBox).SelectAll()

	End Sub

	''' <summary>
	''' テキストボックスリーブ時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub txtImportFrom_Leave(sender As Object, e As EventArgs) Handles txtImportFrom.Leave, txtImportTo.Leave, txtLogFolder.Leave

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

		If MessageBox.Show("インポートを開始します" & vbNewLine & "よろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
			Exit Sub
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
		Dim strLogFolder As String = Trim(Me.txtLogFolder.Text)

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

		Try
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
				'保存先フォルダに同名のフォルダが有るか確認
				If System.IO.Directory.Exists(strImportToFolder & "\" & System.IO.Path.GetFileNameWithoutExtension(strFile)) Then
					'存在したら対象外
					WriteLstResult(Me.lstResult, System.IO.Path.GetFileName(strFile) & " 取り込み済ZIPファイルです(取込対象外)")
				Else
					'存在しなかったら対象
					ReDim Preserve strTargetFiles(iCount)
					strTargetFiles(iCount) = strFile
					iCount += 1
					WriteLstResult(Me.lstResult, System.IO.Path.GetFileName(strFile) & " OK")
				End If
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
				If ExtractZIP(strFile, strDestFolder) Then
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

					WriteLstResult(Me.lstResult, "判定票CSV読み込み")
					WriteLstResult(Me.lstResult, "判定票CSV：" & strCheckupCSV(0))
					WriteLstResult(Me.lstResult, "レコードインポート(データチェック)")

					Using parser As New TextFieldParser(strCheckupCSV(0), System.Text.Encoding.GetEncoding("Shift-JIS"))

						parser.TextFieldType = FieldType.Delimited
						parser.SetDelimiters(",")   'カンマ区切り

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
									'受診日の年度の4月1日を起算日とする
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

							'会場局名、健康管理施設名をM_局所から取得する
							strSQL = "SELECT 会場局名, 健康管理施設名 FROM M_局所 "
							strSQL &= "WHERE 会社コード = '" & row(2) & "' "
							strSQL &= "AND 局所コード = '" & row(3) & "'"
							Dim dtKyokusho As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)

							'===============================================================
							'必須項目チェック
							For iCol As Integer = 0 To row.Count - 1
								Select Case iCol
									Case 0, 1, 2, 3, 4, 5, 9, 10, 11, 12, 13, 15, 16, 17, 135, 136, 137, 138, 143, 144,
										 171, 172, 173, 174, 181

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
											strSQL &= "氏名姓, 氏名名, 採用年月日, 受診日, 会場局名, 健康管理施設名, 不備項目, 不備内容, 修正内容, インポート日時, "
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
											strSQL &= ", '" & System.IO.Path.GetFileName(strCheckupCSV(0)) & "'"    'CSVファイル
											strSQL &= ", 0)"    '修正済フラグ
											sqlProcess.DB_UPDATE(strSQL)

										End If
								End Select
							Next
							'===============================================================
							'小数点桁数チェック
							For iCol As Integer = 0 To row.Count - 1
								'NULLの場合はスルー
								If IsNull(row(iCol)) Then
									Continue For
								End If
								Dim blnError As Boolean = False
								Select Case iCol
									Case 18, 20, 22, 23, 25, 27, 28, 30, 32, 33, 106, 108, 109, 116, 118, 119, 131, 133, 134
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

									Case 34, 35, 36, 37, 101, 103, 104
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
									strSQL &= "氏名姓, 氏名名, 採用年月日, 受診日, 会場局名, 健康管理施設名, 不備項目, 不備内容, 修正内容, インポート日時, "
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
									strSQL &= ", '" & System.IO.Path.GetFileName(strCheckupCSV(0)) & "'"    'CSVファイル
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
									'会社、所属事業所、氏名セイ、氏名メイ、氏名姓、氏名名、受診検査機関名称、会場局名称、健診実施医師名、意見を述べた医師、判定医師名
									Case 4, 5, 9, 10, 11, 12, 136, 138, 141, 142, 143

										For j As Integer = 0 To strSJISErrorCheck.Count - 1
											If row(iCol).IndexOf(strSJISErrorCheck(j)) >= 0 Then
												'存在した場合True
												blnExistError = True
											End If
										Next

								End Select

								If blnExistError Then
									'Shift-JISで表現できない文字が混在していたら
									iIncompleteCount += 1

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
									strSQL &= "氏名姓, 氏名名, 採用年月日, 受診日, 会場局名, 健康管理施設名, 不備項目, 不備内容, 修正内容, インポート日時, "
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
									strSQL &= ", '" & System.IO.Path.GetFileName(strCheckupCSV(0)) & "'"    'CSVファイル
									strSQL &= ", 0)"    '修正済フラグ
									sqlProcess.DB_UPDATE(strSQL)

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
								strSQL &= ", '" & row(iCol).Replace("'", "''") & "'"
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

						Using parser As New TextFieldParser(strLeafletCSV(0), System.Text.Encoding.GetEncoding("Shift-JIS"))

							parser.TextFieldType = FieldType.Delimited
							parser.SetDelimiters(",")   'カンマ区切り

							parser.HasFieldsEnclosedInQuotes = True 'データ内にデリミタがあっても区切らない
							parser.TrimWhiteSpace = False   '空白を削除しない

							iRecCountLeaflet = 0

							parser.ReadFields() 'ヘッダ行を読み飛ばす
							'最終行まで読み込み
							While Not parser.EndOfData

								Dim row As String() = parser.ReadFields()   '１行読み込み、項目を配列に代入
								'エラーチェック後、該当ロットID、システムIDのレコード番号をT_判定票管理から取得してT_リーフレットに値をINSERTしていく
								'エラーチェック用にT_判定票の項目名を全て取得しておく
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
								strSQL = "SELECT レコード番号 FROM T_判定票管理 "
								strSQL &= "WHERE ロットID = '" & strLotID & "' "
								strSQL &= "AND システムID = '" & row(0) & "'"
								dt = sqlProcess.DB_SELECT_DATATABLE(strSQL)
								If dt.Rows.Count = 0 Then
									WriteLstResult(Me.lstResult, "判定表に紐付かないリーフレットあり", ResultMark.WarningMark)
									Continue While
								End If
								Dim iRecNumber As Integer = dt.Rows(0)("レコード番号")
								'===============================================================
								'重複チェック
								'ロットID、システムID、帳票タイプが同一のレコードが既に存在していたら重複とする
								strSQL = "SELECT COUNT(*) FROM T_リーフレット "
								strSQL &= "WHERE ロットID = '" & strLotID & "' "
								strSQL &= "AND システムID = '" & row(0) & "' "
								strSQL &= "AND 帳票タイプ = '" & row(108) & "'"
								If sqlProcess.DB_EXECUTE_SCALAR(strSQL) > 0 Then
									'レコードが存在していたら重複
									iDuplicateCount += 1
									WriteLstResult(Me.lstResult, "重複レコードを検知しました。(" & iDuplicateCount & ")", ResultMark.WarningMark)
									WriteLstResult(Me.lstResult, "会社コード：" & row(2) & " 所属事業所コード：" & row(3) & " 社員コード：" & row(1), ResultMark.WarningMark)
									'リーフレットが重複した場合は、対象システムIDのリーフレット出力は行わないため
									'T_判定票管理.リーフレット無効フラグを立てる
									strSQL = "UPDATE T_判定票管理 SET "
									strSQL &= "要修正日時 = '" & strImportDateTime & "'"
									strSQL &= ", 修正済日時 = NULL "
									strSQL &= ", リーフレット無効 = 1 "
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
									strSQL &= "氏名姓, 氏名名, 採用年月日, 受診日, 会場局名, 健康管理施設名, 不備項目, 不備内容, 修正内容, インポート日時, "
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
									strSQL &= ", '" & XmlSettings.Instance.DataDupe & "'"    '不備内容(レコード重複のためなし)
									strSQL &= ", ''"    '修正内容(デフォルト'')
									strSQL &= ", '" & strImportDateTime & "'"   'インポート日時
									strSQL &= ", '" & System.IO.Path.GetFileName(strLeafletCSV(0)) & "'"    'CSVファイル
									strSQL &= ", 0)"    '修正済フラグ
									sqlProcess.DB_UPDATE(strSQL)

								End If

								'===============================================================
								'必須項目チェック
								For iCol As Integer = 0 To row.Count - 1
									Select Case iCol
										Case 0, 1, 2, 3, 4, 5, 9, 10, 11, 12, 13, 15, 16, 17,
										 97, 98, 99, 100, 101, 102, 103, 108

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
												strSQL &= "氏名姓, 氏名名, 採用年月日, 受診日, 会場局名, 健康管理施設名, 不備項目, 不備内容, 修正内容, インポート日時, "
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
										Case 64, 66, 67, 74, 76, 77, 89, 91, 92
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
										strSQL &= "氏名姓, 氏名名, 採用年月日, 受診日, 会場局名, 健康管理施設名, 不備項目, 不備内容, 修正内容, インポート日時, "
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
									'会社、所属事業所、氏名セイ、氏名メイ、氏名姓、氏名名
										Case 4, 5, 9, 10, 11, 12

											For j As Integer = 0 To strSJISErrorCheck.Count - 1
												If row(iCol).IndexOf(strSJISErrorCheck(j)) >= 0 Then
													'存在した場合True
													blnExistError = True
												End If
											Next

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
										strSQL &= "氏名姓, 氏名名, 採用年月日, 受診日, 会場局名, 健康管理施設名, 不備項目, 不備内容, 修正内容, インポート日時, "
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
								'T_リーフレットテーブルに実データを書き込む
								strSQL = "INSERT INTO T_リーフレット ("
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
				'リーフレット無効が立っていたら判定表のみの重量
				If dt.Rows(iRow)("リーフレット無効") = 1 Then
					strSQL = "UPDATE T_判定票管理 SET 重量 = " & dblCheckupWeight
					strSQL &= ", リーフレット枚数 = 0 "
					strSQL &= "WHERE ロットID = '" & dt.Rows(iRow)("ロットID") & "' "
					strSQL &= "AND レコード番号 = " & dt.Rows(iRow)("レコード番号")
					sqlProcess.DB_UPDATE(strSQL)
				Else
					'そうでない場合は、該当ロットID、レコード番号で「T_リーフレット」内を検索し、該当枚数の重量を加算する
					strSQL = "SELECT COUNT(*) FROM T_リーフレット "
					strSQL &= "WHERE ロットID = '" & dt.Rows(iRow)("ロットID") & "' "
					strSQL &= "AND レコード番号 = " & dt.Rows(iRow)("レコード番号")
					Dim iLeafletSheet As Integer = sqlProcess.DB_EXECUTE_SCALAR(strSQL)
					'リーフレット枚数が0の場合は、T_判定票.リーフレット無効を0とする
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
						'リーフレットカウントが0だった場合、判定表のみの重量とする
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
				'WriteLstResult(Me.lstResult, "エクセルファイルに出力します。", ResultMark.WarningMark)
				'エクセル出力処理(保留)

			End If

			'重複レコード件数を出力
			WriteLstResult(Me.lstResult, "重複レコード" & vbTab & iDuplicateCount & "件")

			'各ZIPファイルのインポート件数を出力
			Dim iTotalCountCheckup As Integer = 0
			Dim iTotalCountLeaflet As Integer = 0
			For i As Integer = 0 To strTargetFiles.Count - 1
				'判定票件数
				WriteLstResult(Me.lstResult, strTargetFiles(i) & vbTab & iTargetRecordCountCheckup(i) & "件")
				iTotalCountCheckup += iTargetRecordCountCheckup(i)
				'リーフレット件数
				If Not iTargetRecordCountLeaflet Is Nothing Then
					WriteLstResult(Me.lstResult, strTargetFiles(i) & vbTab & iTargetRecordCountLeaflet(i) & "件")
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

			OutputImportLog(Me.lstResult, strLogFolder, "_Import_")

			MessageBox.Show("インポート処理が終了しました", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information)

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		Finally

			sqlProcess.Close()
			EnableControls(Me, True)

		End Try

	End Sub

	''' <summary>
	''' データ削除(テスト用)
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub btnDeleteTest_Click(sender As Object, e As EventArgs) Handles btnDeleteTest.Click

		If MessageBox.Show("全てのテーブル内容を削除します" & vbNewLine & "よろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
			Exit Sub
		End If

		Dim sqlProcess As New SQLProcess
		Dim strSQL As String = ""

		Try
			strSQL = "DELETE FROM T_判定票"
			sqlProcess.DB_UPDATE(strSQL)
			strSQL = "DELETE FROM T_判定票管理"
			sqlProcess.DB_UPDATE(strSQL)
			strSQL = "DELETE FROM T_リーフレット"
			sqlProcess.DB_UPDATE(strSQL)
			strSQL = "DELETE FROM T_判定票_不備内容"
			sqlProcess.DB_UPDATE(strSQL)

			MessageBox.Show("削除処理が終了しました", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information)

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		Finally

			sqlProcess.Close()

		End Try
	End Sub

	Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click

		If IsNull(Me.txtLotID.Text) Then
			MessageBox.Show("ロットIDを入力してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Exit Sub
		End If

		PrintPreparation(Me.txtLotID.Text)

	End Sub

#End Region

#Region "プライベートメソッド"

#End Region
End Class