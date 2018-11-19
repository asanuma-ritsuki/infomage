Imports iText.Kernel.Pdf

Public Class frmMain

#Region "フォームイベント"

	''' <summary>
	''' フォームロード時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load

		Me.Text = My.Application.Info.ProductName & " Ver." &
			My.Application.Info.Version.ToString

		XmlSettings.LoadFromXmlFile()
		Me.txtHeaderFile.Text = XmlSettings.Instance.HeaderFile
		Me.txtWorkFolder.Text = XmlSettings.Instance.WorkFolder
		Me.txtOutputFolder.Text = XmlSettings.Instance.OutputFolder
		Me.txtLogFolder.Text = XmlSettings.Instance.LogFolder
		Me.txtFlagString.Text = XmlSettings.Instance.FlagString

	End Sub

	''' <summary>
	''' フォームクロージング
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub frmMain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

		If MessageBox.Show("アプリケーションを終了します" & vbNewLine & "よろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
			e.Cancel = True
		Else
			XmlSettings.LoadFromXmlFile()
			XmlSettings.Instance.HeaderFile = Me.txtHeaderFile.Text
			XmlSettings.Instance.WorkFolder = Me.txtWorkFolder.Text
			XmlSettings.Instance.OutputFolder = Me.txtOutputFolder.Text
			XmlSettings.Instance.LogFolder = Me.txtLogFolder.Text
			XmlSettings.Instance.FlagString = Me.txtFlagString.Text
			XmlSettings.SaveToXmlFile()
		End If

	End Sub

#End Region

#Region "オブジェクトイベント"

	''' <summary>
	''' テキストボックスドラッグエンター時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub txt_DragEnter(sender As Object, e As DragEventArgs) Handles txtWorkFolder.DragEnter, txtOutputFolder.DragEnter, txtLogFolder.DragEnter, txtHeaderFile.DragEnter
		If e.Data.GetDataPresent(DataFormats.FileDrop) Then
			e.Effect = DragDropEffects.Copy
		Else
			e.Effect = DragDropEffects.None
		End If

	End Sub

	''' <summary>
	''' ヘッダファイルドロップ時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub txtHeaderFile_DragDrop(sender As Object, e As DragEventArgs) Handles txtHeaderFile.DragDrop

		Dim strFiles As String() = CType(e.Data.GetData(DataFormats.FileDrop, False), String())
		If System.IO.File.Exists(strFiles(0)) Then
			Me.txtHeaderFile.Text = strFiles(0)
		End If

	End Sub

	''' <summary>
	''' 作業フォルダドロップ時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub txtWorkFolder_DragDrop(sender As Object, e As DragEventArgs) Handles txtWorkFolder.DragDrop

		Dim strFiles As String() = CType(e.Data.GetData(DataFormats.FileDrop, False), String())
		If System.IO.Directory.Exists(strFiles(0)) Then
			Me.txtWorkFolder.Text = strFiles(0)
		End If

	End Sub

	''' <summary>
	''' 出力フォルダドロップ時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub txtOutputFolder_DragDrop(sender As Object, e As DragEventArgs) Handles txtOutputFolder.DragDrop

		Dim strFiles As String() = CType(e.Data.GetData(DataFormats.FileDrop, False), String())
		If System.IO.Directory.Exists(strFiles(0)) Then
			Me.txtOutputFolder.Text = strFiles(0)
		End If

	End Sub

	''' <summary>
	''' ログフォルダドロップ時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub txtLogFolder_DragDrop(sender As Object, e As DragEventArgs) Handles txtLogFolder.DragDrop

		Dim strFiles As String() = CType(e.Data.GetData(DataFormats.FileDrop, False), String())
		If System.IO.Directory.Exists(strFiles(0)) Then
			Me.txtLogFolder.Text = strFiles(0)
		End If

	End Sub

#End Region

#Region "オブジェクトイベント"

	''' <summary>
	''' 実行ボタン押下時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub btnRun_Click(sender As Object, e As EventArgs) Handles btnRun.Click

		If Not System.IO.File.Exists(Me.txtHeaderFile.Text) Then
			MessageBox.Show("ヘッダファイルが指定されていません", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Exit Sub
		End If
		If Not System.IO.Directory.Exists(Me.txtWorkFolder.Text) Then
			MessageBox.Show("作業フォルダが指定されていません", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Exit Sub
		End If
		If Not System.IO.Directory.Exists(Me.txtOutputFolder.Text) Then
			MessageBox.Show("出力フォルダが指定されていません", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Exit Sub
		End If
		If Not System.IO.Directory.Exists(Me.txtLogFolder.Text) Then
			MessageBox.Show("ログ保存フォルダが指定されていません", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Exit Sub
		End If

		If MessageBox.Show("PDF出力処理を開始します" & vbNewLine & "よろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
			Exit Sub
		End If

		Dim strSQL As String = ""
		Dim sqlProcess As New SQLProcess

		Try
			Dim strHeaderFile As String = Me.txtHeaderFile.Text
			Dim strWorkFolder As String = Me.txtWorkFolder.Text
			Dim strOutputFolder As String = Me.txtOutputFolder.Text
			Dim strLogFolder As String = Me.txtLogFolder.Text

			Me.lstResult.Items.Clear()
			WriteLstResult(Me.lstResult, "ヘッダファイル：" & System.IO.Path.GetFileName(strHeaderFile))
			WriteLstResult(Me.lstResult, "作業フォルダ：" & strWorkFolder)
			WriteLstResult(Me.lstResult, "出力フォルダ：" & strOutputFolder)
			WriteLstResult(Me.lstResult, "ログフォルダ：" & strLogFolder)
			WriteLstResult(Me.lstResult, "拡大率：" & Me.numPercent.Value & "％")
			WriteLstResult(Me.lstResult, "フラグ文字：" & Me.txtFlagString.Text)
			WriteLstResult(Me.lstResult, "PDF出力処理開始")

			WriteLstResult(Me.lstResult, "作業フォルダ内のフォルダを削除")
			Dim strSubFolders As IEnumerable(Of String) = System.IO.Directory.EnumerateDirectories(Me.txtWorkFolder.Text, "*", System.IO.SearchOption.TopDirectoryOnly)
			For Each strSubFolder As String In strSubFolders
				My.Computer.FileSystem.DeleteDirectory(strSubFolder, FileIO.DeleteDirectoryOption.DeleteAllContents)
			Next

			WriteLstResult(Me.lstResult, "DB内データ削除開始")
			strSQL = "DELETE FROM T_ヘッダ情報"
			sqlProcess.DB_UPDATE(strSQL)
			strSQL = "DELETE FROM T_ファイル情報"
			sqlProcess.DB_UPDATE(strSQL)
			WriteLstResult(Me.lstResult, "DB内データ削除完了")

			WriteLstResult(Me.lstResult, "ヘッダ情報インポート開始")
			Dim iRecCount As Integer = 0
			Using parser As New CSVParser(strHeaderFile, System.Text.Encoding.GetEncoding("Shift_JIS"))
				parser.Delimiter = vbTab    'タブ区切り
				parser.HasFieldsEnclosedInQuotes = True
				parser.TrimWhiteSpace = False

				iRecCount = 0

				parser.ReadFields() 'ヘッダ行を読み飛ばす
				'最終行まで読み込み
				While Not parser.EndOfData
					iRecCount += 1
					Dim row As String() = parser.ReadFields()   '1行読み込み、項目を配列に代入
					'T_ヘッダ情報に書き込み
					strSQL = "INSERT INTO T_ヘッダ情報(ID, フォルダ名, 巻, 号, 年, 月) VALUES("
					strSQL &= iRecCount 'ID
					strSQL &= ", '" & row(0) & "'"  'フォルダ名
					strSQL &= ", " & row(1) '巻
					strSQL &= ", " & row(2) '号
					strSQL &= ", " & row(3) '年
					strSQL &= ", " & row(4) & ")" '月
					sqlProcess.DB_UPDATE(strSQL)

				End While

			End Using
			WriteLstResult(Me.lstResult, "ヘッダ情報インポート完了：" & iRecCount & "レコード")

			WriteLstResult(Me.lstResult, "ファイル情報インポート開始")
			'T_ヘッダ情報のフォルダ名以下のTIFファイルを全て列挙してT_ファイル情報に書き込む
			strSQL = "SELECT ID, フォルダ名, 巻, 号, 年, 月 "
			strSQL &= "FROM T_ヘッダ情報 "
			strSQL &= "ORDER BY ID"
			Dim dt As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)

			iRecCount = 0
			Dim iPDFSeq As Integer = 0
			Dim strBeforeFolder As String = ""
			Dim blnIsSecond As Boolean = False  '2ファイル目ならTrue
			Dim blnFlagString As Boolean = False
			For iRow As Integer = 0 To dt.Rows.Count - 1
				Dim strFiles As String() = GetFilesMostDeep(dt.Rows(iRow)("フォルダ名"), {"*.tif"})
				Dim iRecNumber As Integer = 0
				For i As Integer = 0 To strFiles.Length - 1
					iRecCount += 1
					iRecNumber += 1
					strSQL = "INSERT INTO T_ファイル情報(ID, レコード番号, ファイルパス, フラグ文字, PDFシーケンス, 変換フォルダ, 変換ファイル名) VALUES("
					strSQL &= dt.Rows(iRow)("ID")   'ID
					strSQL &= ", " & iRecNumber 'レコード番号
					strSQL &= ", '" & strFiles(i) & "'" 'ファイルパス
					'フラグ文字
					Dim strFlagString As String = Strings.Right(System.IO.Path.GetFileNameWithoutExtension(strFiles(i)), 1)
					If strFlagString = Me.txtFlagString.Text Then
						strSQL &= ", '" & Me.txtFlagString.Text & "'"
						'フラグ文字あり
						blnFlagString = True
					Else
						'フラグ文字なし
						blnFlagString = False
						strSQL &= ", ''"
					End If
					'==================================================
					'PDFシーケンス(2段組は2ファイルで1シーケンス、1段組は1ファイルで1シーケンス)
					'フォルダ区切りでシーケンスをリセット
					If Not strBeforeFolder = System.IO.Path.GetDirectoryName(strFiles(i)) Then
						'前のフォルダと相違していたらPDFシーケンスをリセット
						iPDFSeq = 0
						blnIsSecond = False
					End If
					If Not blnIsSecond Then
						'1ファイル目
						'フラグ文字が存在していたら1ファイルで完結
						If blnFlagString Then
							'1段組
							blnIsSecond = False
						Else
							'2段組
							blnIsSecond = True
						End If
						iPDFSeq += 1
					Else
						'2ファイル目
						'フラグ文字が存在していたらPDFシーケンスをインクリメント
						blnIsSecond = False '必ずFalse
						If blnFlagString Then
							'1段組
							iPDFSeq += 1
						Else
							'2段組
							'PDFシーケンスはインクリメント市内
						End If
					End If
					strBeforeFolder = System.IO.Path.GetDirectoryName(strFiles(i))
					strSQL &= ", " & iPDFSeq
					'==================================================
					strSQL &= ", '', '')"   '変換フォルダ、変換ファイル名
					sqlProcess.DB_UPDATE(strSQL)
				Next
			Next

			WriteLstResult(Me.lstResult, "ファイル情報インポート完了：" & iRecCount & "レコード")

			WriteLstResult(Me.lstResult, "画像拡大処理開始")
			strSQL = "SELECT ID, レコード番号, ファイルパス "
			strSQL &= "FROM T_ファイル情報 "
			strSQL &= "ORDER BY ID, レコード番号"
			dt = sqlProcess.DB_SELECT_DATATABLE(strSQL)

			iRecCount = 0
			For iRow As Integer = 0 To dt.Rows.Count - 1
				'画像の拡大処理
				'元画像のフォルダをバラバラにして下位2フォルダを結合する
				iRecCount += 1
				Dim strFolders As String() = dt.Rows(iRow)("ファイルパス").ToString.Split("\")
				Dim strTIFFile As String = System.IO.Path.GetFileName(dt.Rows(iRow)("ファイルパス"))
				Dim strFolder As String = strFolders(strFolders.Length - 3) & "\" & strFolders(strFolders.Length - 2)
				Dim strConvertFolder As String = strWorkFolder & "\" & strFolder
				If Not System.IO.Directory.Exists(strConvertFolder) Then
					My.Computer.FileSystem.CreateDirectory(strConvertFolder)
				End If
				Dim strConvertFile As String = strConvertFolder & "\" & strTIFFile
				'Magick.NETで読み込み
				Dim img As New ImageMagick.MagickImage(dt.Rows(iRow)("ファイルパス").ToString)
				Dim dblPercent As Double = CDbl(Me.numPercent.Value)
				img.Resize(New ImageMagick.Percentage(dblPercent))  'リサイズ
				img.Write(strConvertFile)
				img.Dispose()

				'作業ファイルパスの保存
				strSQL = "UPDATE T_ファイル情報 SET 変換フォルダ = '" & strConvertFolder & "' "
				strSQL &= ", 変換ファイル名 = '" & strTIFFile & "' "
				strSQL &= "WHERE ID = " & dt.Rows(iRow)("ID") & " "
				strSQL &= "AND レコード番号 = " & dt.Rows(iRow)("レコード番号")
				sqlProcess.DB_UPDATE(strSQL)
				WriteLstResult(Me.lstResult, strConvertFile)

			Next

			WriteLstResult(Me.lstResult, "画像拡大処理完了：" & iRecCount & "ファイル")

			WriteLstResult(Me.lstResult, "シングルPDF作成開始")
			'変換フォルダ単位でループさせて、フラグ文字が無いものは2段、あるものは1段でシングルPFDを出力する
			strSQL = "SELECT T2.ID, T1.変換フォルダ, T2.巻, T2.号 "
			strSQL &= "FROM T_ファイル情報 AS T1 INNER JOIN "
			strSQL &= "T_ヘッダ情報 AS T2 ON T1.ID = T2.ID "
			strSQL &= "GROUP BY T2.ID, T1.変換フォルダ, T2.巻, T2.号 "
			strSQL &= "ORDER BY T2.ID, T1.変換フォルダ"
			dt = sqlProcess.DB_SELECT_DATATABLE(strSQL)

			iRecCount = 0
			Dim iBeforeID As Integer = 0    'PDFファイルのシーケンスリセット用ID
			Dim iFileSeq As Integer = 0 'ファイル連番のシーケンス
			For iRow As Integer = 0 To dt.Rows.Count - 1
				'各フォルダ単位でPDFシーケンスの最大値を取得する
				'PDFシーケンスで回し、FlexReportにてPDFを作成する
				strSQL = "SELECT 変換フォルダ, フラグ文字, PDFシーケンス "
				strSQL &= "FROM T_ファイル情報 "
				strSQL &= "WHERE 変換フォルダ = '" & dt.Rows(iRow)("変換フォルダ") & "' "
				strSQL &= "GROUP BY 変換フォルダ, フラグ文字, PDFシーケンス "
				strSQL &= "ORDER BY 変換フォルダ, PDFシーケンス"
				Dim dtSeq As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)

				Dim strConnectionString As String = ""
				XmlSettings.LoadFromXmlFile()
				Dim C1FlexReport1 As New C1.Win.FlexReport.C1FlexReport
				'接続文字列を作成する
				strConnectionString = "Provider=SQLOLEDB.1;"
				strConnectionString &= "Password=" & XmlSettings.Instance.Password & ";"
				strConnectionString &= "Persist Security Info=True;"
				strConnectionString &= "User ID=" & XmlSettings.Instance.UserID & ";"
				strConnectionString &= "Initial Catalog=" & XmlSettings.Instance.InitialCatalog & ";"
				strConnectionString &= "Data Source=" & XmlSettings.Instance.DataSource

				'出力フォルダの作成
				If Not iBeforeID = CInt(dt.Rows(iRow)("ID")) Then
					'前回IDと今回IDが相違していたら、記事シーケンスを1にする
					iFileSeq = 1
				Else
					iFileSeq += 1
				End If
				Dim strConvertFolders As String() = dt.Rows(iRow)("変換フォルダ").ToString.Split("\")
				'冊子フォルダの中に記事フォルダを作成する
				Dim strArticle As String = "da_hogakushinpo" & CInt(dt.Rows(iRow)("巻")).ToString("000") & CInt(dt.Rows(iRow)("号")).ToString("00") & "a" & iFileSeq.ToString("0000")
				Dim strPDFOutFolder As String = strOutputFolder & "\PDF\" & strConvertFolders(strConvertFolders.Length - 2) & "\" & strArticle
				If Not System.IO.Directory.Exists(strPDFOutFolder) Then
					My.Computer.FileSystem.CreateDirectory(strPDFOutFolder)
				End If

				For iSeq As Integer = 0 To dtSeq.Rows.Count - 1

					strSQL = "SELECT T2.変換フォルダ + '\' + T2.変換ファイル名 AS ImagePath, "
					strSQL &= "'法学新報 第' + CONVERT(VARCHAR, T1.巻) + '巻第' + CONVERT(VARCHAR, T1.号) + '号(' + CONVERT(VARCHAR, T1.年) + '年' + CONVERT(VARCHAR, T1.月) + '月発行)所収記事' AS ヘッダ, "
					strSQL &= "'中央大学史資料集　第29集' AS フッタ "
					strSQL &= "FROM T_ヘッダ情報 AS T1 INNER JOIN "
					strSQL &= "T_ファイル情報 AS T2 ON T1.ID = T2.ID "
					strSQL &= "WHERE T2.変換フォルダ = '" & dt.Rows(iRow)("変換フォルダ") & "' "
					strSQL &= "AND T2.PDFシーケンス = " & dtSeq.Rows(iSeq)("PDFシーケンス")
					'フラグ文字が存在するかで分岐
					Dim strWriteLine As String = ""
					If Me.txtFlagString.Text = dtSeq.Rows(iSeq)("フラグ文字") Then
						'フラグ文字あり
						'1段組のテンプレート
						C1FlexReport1.Load(Application.StartupPath & "\法学新報掲載記事.flxr", "法学新報掲載記事_1")
						strWriteLine = "1段組："
					Else
						'フラグ文字なし
						'2段組のテンプレート
						C1FlexReport1.Load(Application.StartupPath & "\法学新報掲載記事.flxr", "法学新報掲載記事_2")
						strWriteLine = "2段組："
					End If
					C1FlexReport1.DataSource.ConnectionString = strConnectionString
					C1FlexReport1.DataSource.RecordSource = strSQL

					OutputPDF(C1FlexReport1, strPDFOutFolder & "\" & (iSeq + 1).ToString("0000") & ".pdf")
					strWriteLine &= strPDFOutFolder & "\" & (iSeq + 1).ToString("0000") & ".pdf"
					WriteLstResult(Me.lstResult, strWriteLine)
					'C1FlexReport1.Clear()

				Next
				iBeforeID = CInt(dt.Rows(iRow)("ID"))

			Next

			WriteLstResult(Me.lstResult, "シングルPDF作成完了")

			WriteLstResult(Me.lstResult, "変換元ファイルのリネーム処理開始")
			strSQL = "SELECT T1.ID, T1.ファイルパス, T1.変換フォルダ, T2.巻, T2.号 "
			strSQL &= "FROM T_ファイル情報 AS T1 INNER JOIN "
			strSQL &= "T_ヘッダ情報 AS T2 ON T1.ID = T2.ID "
			strSQL &= "ORDER BY T1.ID, T1.レコード番号"
			dt = sqlProcess.DB_SELECT_DATATABLE(strSQL)

			Dim strBeforeBooklet As String = ""
			Dim strBeforeArticle As String = ""
			Dim iArticleSeq As Integer = 0
			iFileSeq = 0
			For iRow As Integer = 0 To dt.Rows.Count - 1
				Dim strConvertFolders As String() = dt.Rows(iRow)("変換フォルダ").ToString.Split("\")
				'冊子フォルダの中に記事フォルダを作成する
				If strBeforeArticle = strConvertFolders(strConvertFolders.Length - 2) & "\" & strConvertFolders(strConvertFolders.Length - 1) Then
					'前回フォルダと同じ
					iFileSeq += 1
				Else
					'フォルダ名相違
					'冊子が変わっていたらリセット
					If strBeforeBooklet = strConvertFolders(strConvertFolders.Length - 2) Then
						'冊子は変わっていなかったので記事のみインクリメント
						iArticleSeq += 1
						iFileSeq = 1
					Else
						'冊子が変わっていたので冊子、記事ともにリセット
						iArticleSeq = 1
						iFileSeq = 1
					End If
				End If
				Dim strArticle As String = "da_hogakushinpo" & CInt(dt.Rows(iRow)("巻")).ToString("000") & CInt(dt.Rows(iRow)("号")).ToString("00") & "a" & iArticleSeq.ToString("0000") & "a" & iFileSeq.ToString("0000") & ".tif"
				Dim strTIFOutFolder As String = strOutputFolder & "\TIF\" & strConvertFolders(strConvertFolders.Length - 2) & "\" & strConvertFolders(strConvertFolders.Length - 1)
				If Not System.IO.Directory.Exists(strTIFOutFolder) Then
					My.Computer.FileSystem.CreateDirectory(strTIFOutFolder)
				End If
				'ファイルコピー
				Dim strOrgFile As String = dt.Rows(iRow)("ファイルパス")
				Dim strDestFile As String = strTIFOutFolder & "\" & strArticle
				My.Computer.FileSystem.CopyFile(strOrgFile, strDestFile, True)
				strBeforeBooklet = strConvertFolders(strConvertFolders.Length - 2)
				strBeforeArticle = strConvertFolders(strConvertFolders.Length - 2) & "\" & strConvertFolders(strConvertFolders.Length - 1)  '冊子名\記事名
			Next

			WriteLstResult(Me.lstResult, "変換元ファイルのリネーム処理完了")
			WriteLstResult(Me.lstResult, "PDF出力処理完了")

			OutputListLog(Me.lstResult, strLogFolder, "PDF出力処理", Date.Now.ToString("yyyyMMddHHmmss"))

			MessageBox.Show("PDF出力処理が完了しました", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information)

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & ex.StackTrace)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		Finally

			sqlProcess.Close()

		End Try

	End Sub

#End Region

#Region "プライベートメソッド"

	''' <summary>
	''' PDF出力
	''' </summary>
	''' <param name="C1FlexReport1"></param>
	''' <param name="strOutputFile"></param>
	Private Sub OutputPDF(ByVal C1FlexReport1 As C1.Win.FlexReport.C1FlexReport, ByVal strOutputFile As String)

		Dim filter As New C1.Win.C1Document.Export.PdfFilter
		filter.PdfACompatible = True
		filter.ShowOptions = False
		If Not System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(strOutputFile)) Then
			My.Computer.FileSystem.CreateDirectory(System.IO.Path.GetDirectoryName(strOutputFile))
		End If
		filter.FileName = strOutputFile
		C1FlexReport1.RenderToFilter(filter)

	End Sub

	'''' <summary>
	'''' マルチPDF作成(PDF/A-1A)
	'''' </summary>
	'''' <param name="strTargetFolder"></param>
	'Private Sub CreateMultiPDF(ByVal strTargetFolder As String)

	'	Dim strOutPDFPath As String = System.IO.Path.GetDirectoryName(strTargetFolder) & System.IO.Path.GetFileName(strTargetFolder)
	'	Dim strDir As String = System.IO.Path.GetDirectoryName(strTargetFolder)
	'	Dim strList As New List(Of String)

	'	Dim objITextDoc As iText.Pdfa.PdfADocument = Nothing
	'	Dim objPDFCopy As PdfCopy = Nothing

	'	Try
	'		objITextDoc = New Pdfa.PdfADocument()
	'		objPDFCopy = New PdfCopy(objITextDoc, New System.IO.FileStream(strOutPDFPath, System.IO.FileMode.Create))

	'		objITextDoc.Open()
	'		objPDFCopy.SetPdfVersion(PdfCopy.PDF_VERSION_1_7)   'PDFバージョンの指定
	'		objPDFCopy.SetTagged()

	'		'objPDFCopy.set
	'		'出力するPDFのプロパティを設定
	'		'objITextDoc.AddKeywords("キーワードです。")
	'		'objITextDoc.AddAuthor("zero0nine.com")
	'		'objITextDoc.AddTitle("結合したPDFファイルです。")
	'		'objITextDoc.AddCreator("PDFファイル結合くん")
	'		'objITextDoc.AddSubject("結合したPDFファイル")

	'		'リストのソート
	'		strList.Sort()
	'		'ファイルのループ
	'		For Each strPdfList As String In strList
	'			Dim objPdfReader As New PdfReader(strPdfList)   '結合元のPDFファイル読込
	'			objPDFCopy.AddDocument(objPdfReader)    '結合元のPDFファイルを追加（全ページ）
	'			objPdfReader.Close()
	'		Next

	'	Catch ex As Exception

	'		MessageBox.Show(ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

	'	Finally

	'		objITextDoc.Close()
	'		objPDFCopy.Close()

	'	End Try

	'End Sub

#End Region
End Class
