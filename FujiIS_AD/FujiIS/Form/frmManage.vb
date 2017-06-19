Public Class frmManage

	''' <summary>
	''' フォームロード時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub frmManage_Load(sender As Object, e As EventArgs) Handles MyBase.Load

		Me.Text = My.Application.Info.ProductName & " Ver." &
			My.Application.Info.Version.ToString
		CaptionDisplayMode = StatusDisplayMode.None
		Me.lblResult.Text = ""

	End Sub

	Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click

		Dim frm As New frmMain
		m_Context.SetNextContext(frm)

	End Sub

	''' <summary>
	''' 情報収集(追加分)押下時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub btnAddRun_Click(sender As Object, e As EventArgs) Handles btnAddRun.Click

		If Not System.IO.Directory.Exists(Me.txtImagePath.Text) Then
			MessageBox.Show("元フォルダを指定してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Exit Sub
		End If
		If Not System.IO.Directory.Exists(Me.txtSaveFolder.Text) Then
			MessageBox.Show("先フォルダを指定してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Exit Sub
		End If
		If Me.cmbExt.SelectedIndex < 0 Then
			MessageBox.Show("対象の拡張子を選択してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Exit Sub
		End If

		If MessageBox.Show("データの情報収集(追加分)を開始します" & vbNewLine & "よろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
			Exit Sub
		End If

		Dim strSQL As String = ""
		Dim sqlProcess As New SQLProcess

		Try
			strSQL = "DELETE FROM T_出力追加分"
			sqlProcess.DB_UPDATE(strSQL)

			Dim strLogFile As String = Me.txtSaveFolder.Text & "\" & Date.Now.ToString("yyyyMMdd_HHmmss") & "_情報収集_追加分.log"

			Dim enc As System.Text.Encoding = New System.Text.UTF8Encoding(False)
			Dim sw As New System.IO.StreamWriter(strLogFile, False, enc)

			Me.lblResult.Text = "カウント用ファイルリスト作成中…"
			Application.DoEvents()
			'各冊子ID単位で全てのファイルを列挙してT_カウントに格納する
			strSQL = "DELETE FROM T_カウント追加分"
			sqlProcess.DB_UPDATE(strSQL)
			strSQL = "SELECT ID FROM M_冊子追加分 ORDER BY ID"
			Dim dtBooklet As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
			Dim strExt As String() = {"*" & Me.cmbExt.SelectedItem}

			For iRow As Integer = 0 To dtBooklet.Rows.Count - 1
				Dim strFiles As String() = GetFilesMostDeep(Me.txtImagePath.Text & "\" & dtBooklet.Rows(iRow)("ID"), strExt)
				For Each strFile As String In strFiles
					strSQL = "INSERT INTO T_カウント追加分 ( ID, ファイル名, カウント) "
					strSQL &= "VALUES(N'" & dtBooklet.Rows(iRow)("ID") & "', N'" & System.IO.Path.GetFileNameWithoutExtension(strFile) & "', 0)"
					sqlProcess.DB_UPDATE(strSQL)
				Next
			Next

			Me.lblResult.Text = "必要情報の列挙、DBへのINSERT中…"
			Application.DoEvents()

			'M_冊子追加分、T_目次追加分から必要情報を抜き出す
			strSQL = "SELECT ID, レコード番号, 冊子名, 目次タイトル, 著者名, リンク, リンクTO, 備考 FROM "
			strSQL &= "(SELECT T1.ID, T2.レコード番号, "
			strSQL &= "T1.冊子名 + ' ' + T1.年号 + ' ' + T1.Vol + ' ' + T1.No AS 冊子名, "
			strSQL &= "T2.目次タイトル, T2.著者名, T2.リンク, T2.リンクTO, T2.備考, "
			strSQL &= "CASE WHEN T2.目次タイトル = '' THEN 1 ELSE 0 END AS 不要レコード, "
			strSQL &= "CASE WHEN T2.目次タイトル = '表紙' AND T2.リンク = '' THEN 1 ELSE 0 END AS 不要表紙, "
			strSQL &= "CASE WHEN T2.目次タイトル = '広告' AND T2.リンク = '' THEN 1 ELSE 0 END AS 不要広告, "
			strSQL &= "CASE WHEN T2.リンク = '' AND T2.備考 = '9' THEN 1 ELSE 0 END AS フラグ9 "
			strSQL &= "FROM M_冊子追加分 AS T1 INNER JOIN "
			strSQL &= "T_目次追加分 AS T2 ON T1.ID = T2.ID) AS A1 "
			strSQL &= "WHERE A1.不要レコード = 0 AND A1.不要表紙 = 0 AND A1.不要広告 = 0 AND A1.フラグ9 = 0 "
			strSQL &= "ORDER BY A1.ID, A1.レコード番号"
			Dim dt As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)

			Dim iTotalCount As Integer = 0  'トータル連番
			Dim iFolderNo As Integer = CInt(Me.txtInitialFolder.Text)    'フォルダ番号※目次タイトルが変わったらインクリメント

			'DATATABLEを回してリンク～リンクTOのファイルを該当冊子IDから探して、存在したらT_出力にINSERTする
			Dim strBeforeRemarks As String = "" '前回備考と今回備考が共に「広告」であり、リンクが当該レコードの-1だった場合、インクリメントしない
			Dim iBeforeLink As Integer = 0

			For iRow As Integer = 0 To dt.Rows.Count - 1
				'リンクとリンクTOを取得する
				Dim strLink As String = dt.Rows(iRow)("リンク")
				Dim strLinkTo As String = dt.Rows(iRow)("リンクTO")

				'FromとToのファイルが存在するか確認
				If Not IsNull(strLink) Then
					If Me.cmbExt.SelectedItem = ".pdf" Then
						'※PDFファイル名用
						If Not System.IO.File.Exists(Me.txtImagePath.Text & "\" & dt.Rows(iRow)("ID") & "\" & dt.Rows(iRow)("ID") & "_" & dt.Rows(iRow)("リンク") & Me.cmbExt.SelectedItem) Then
							sw.WriteLine("ファイルが存在しない(FROM)：" & dt.Rows(iRow)("ID") & "_" & dt.Rows(iRow)("リンク") & Me.cmbExt.SelectedItem)
						End If
					Else
						'JPGファイル名用
						If Not System.IO.File.Exists(Me.txtImagePath.Text & "\" & dt.Rows(iRow)("ID") & "\" & dt.Rows(iRow)("リンク") & Me.cmbExt.SelectedItem) Then
							sw.WriteLine("ファイルが存在しない(FROM)：" & dt.Rows(iRow)("ID") & "：" & dt.Rows(iRow)("リンク") & Me.cmbExt.SelectedItem)
						End If
					End If
				End If
				If Not IsNull(strLinkTo) Then
					If Me.cmbExt.SelectedItem = ".pdf" Then
						'※PDFファイル名用
						If Not System.IO.File.Exists(Me.txtImagePath.Text & "\" & dt.Rows(iRow)("ID") & "\" & dt.Rows(iRow)("ID") & "_" & dt.Rows(iRow)("リンクTO") & Me.cmbExt.SelectedItem) Then
							sw.WriteLine("ファイルが存在しない(TO)：" & dt.Rows(iRow)("ID") & "_" & dt.Rows(iRow)("リンク") & Me.cmbExt.SelectedItem)
						End If
					Else
						'JPGファイル名用
						If Not System.IO.File.Exists(Me.txtImagePath.Text & "\" & dt.Rows(iRow)("ID") & "\" & dt.Rows(iRow)("リンクTO") & Me.cmbExt.SelectedItem) Then
							sw.WriteLine("ファイルが存在しない(TO)：" & dt.Rows(iRow)("ID") & "：" & dt.Rows(iRow)("リンクTO") & Me.cmbExt.SelectedItem)
						End If
					End If
				End If

				'リンクが貼られていなかったら「対象イメージ無」フラグをたてて1レコードのみINSERT
				If IsNull(strLink) Then
					'リンクが無い
					'フォルダ番号はインクリメントしない
					sw.WriteLine("リンク無し：" & dt.Rows(iRow)("ID") & "：" & dt.Rows(iRow)("目次タイトル"))
					'1レコードのみINSERT
					'元ファイル名、フォルダ番号、ファイル名、ハイパーリンクは空文字にし、対象イメージ無フラグを立てる
					iTotalCount += 1
					Dim cho As String = ""
					If IsNull(dt.Rows(iRow)("著者名")) Then
						'NULLだったらハイフン
						cho = "-"
					Else
						cho = dt.Rows(iRow)("著者名")
					End If
					InsertDataAdd(iTotalCount, dt.Rows(iRow)("ID"), dt.Rows(iRow)("レコード番号"),
							   dt.Rows(iRow)("冊子名"), dt.Rows(iRow)("目次タイトル") & "　(※リンク無し)", cho,
							   "", "", "", "", 1)
				Else
					'フォルダ番号のインクリメント
					'前回備考と今回備考が共に「広告」であり、前レコードのリンクが-1だった場合インクリメントしない
					Console.WriteLine(dt.Rows(iRow)("リンク"))
					Dim iCurrentLink As Integer = IIf(IsNull(dt.Rows(iRow)("リンク")) = False, CInt(dt.Rows(iRow)("リンク")), 0)
					If strBeforeRemarks = "広告" And dt.Rows(iRow)("備考") = "広告" And iCurrentLink = iBeforeLink + 1 Then

					Else
						iFolderNo += 1
					End If
					'リンクあり、リンクTOに必ず値がある前提
					'FromToの全てのファイルの存在確認をして存在していたら配列に入れていく
					Dim iLink As Integer = CInt(strLink)
					Dim iLinkTo As Integer = CInt(strLinkTo)
					Dim lstFiles As New List(Of String)

					For iFile As Integer = iLink To iLinkTo
						'存在確認
						If Me.cmbExt.SelectedItem = ".pdf" Then
							'※PDFファイル名用
							If System.IO.File.Exists(Me.txtImagePath.Text & "\" & dt.Rows(iRow)("ID") & "\" & dt.Rows(iRow)("ID") & "_" & iFile.ToString("0000") & Me.cmbExt.SelectedItem) Then
								'存在したらコレクションへ追加
								lstFiles.Add(dt.Rows(iRow)("ID") & "_" & iFile.ToString("0000"))
							End If
						Else
							'JPGファイル名用
							If System.IO.File.Exists(Me.txtImagePath.Text & "\" & dt.Rows(iRow)("ID") & "\" & iFile.ToString("0000") & Me.cmbExt.SelectedItem) Then
								'存在したらコレクションへ追加
								lstFiles.Add(iFile.ToString("0000"))
							End If
						End If
					Next
					'列挙したファイル数分T_出力にINSERTしていく
					For i As Integer = 0 To lstFiles.Count - 1
						iTotalCount += 1
						'列挙したファイルが1ファイルの場合は「分子/分母」の表記はいらない
						Dim strTitle As String = ""
						If lstFiles.Count = 1 Then
							strTitle = dt.Rows(iRow)("目次タイトル")
						Else
							strTitle = dt.Rows(iRow)("目次タイトル") & "　" & (i + 1).ToString & "/" & lstFiles.Count.ToString
						End If
						Dim cho As String = ""
						If IsNull(dt.Rows(iRow)("著者名")) Then
							'NULLだったらハイフン
							cho = "-"
						Else
							cho = dt.Rows(iRow)("著者名")
						End If
						InsertDataAdd(iTotalCount, dt.Rows(iRow)("ID"), dt.Rows(iRow)("レコード番号"),
							   dt.Rows(iRow)("冊子名"), strTitle, cho,
							   lstFiles(i), iFolderNo.ToString("000000"), (i + 1).ToString("000"), Me.txtSaveFolder.Text & "\" & Me.txtSubFolder.Text & "\" & iFolderNo.ToString("000000"), 0)

						'T_カウントのID、ファイル名が合致したレコードのカウントをインクリメントする
						strSQL = "UPDATE T_カウント追加分 SET カウント += 1 "
						strSQL &= "WHERE ID = '" & dt.Rows(iRow)("ID") & "' "
						strSQL &= "AND ファイル名 = '" & lstFiles(i) & "'"
						sqlProcess.DB_UPDATE(strSQL)
					Next
				End If

			If dt.Rows(iRow)("備考") = "広告" Then
				strBeforeRemarks = dt.Rows(iRow)("備考")
				iBeforeLink = IIf(IsNull(dt.Rows(iRow)("リンク")) = False, CInt(dt.Rows(iRow)("リンク")), 0)
			Else
				strBeforeRemarks = ""
				iBeforeLink = 0
			End If

		Next

			sw.Close()

			MessageBox.Show("処理が完了しました", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information)

		Catch ex As Exception

		Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message)
		MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		Finally

		sqlProcess.Close()
		Me.lblResult.Text = ""

		End Try

	End Sub

	''' <summary>
	''' 情報収集ボタン押下時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub btnRun_Click(sender As Object, e As EventArgs) Handles btnRun.Click

		If Not System.IO.Directory.Exists(Me.txtImagePath.Text) Then
			MessageBox.Show("元フォルダを指定してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Exit Sub
		End If
		If Not System.IO.Directory.Exists(Me.txtSaveFolder.Text) Then
			MessageBox.Show("先フォルダを指定してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Exit Sub
		End If
		If Me.cmbExt.SelectedIndex < 0 Then
			MessageBox.Show("対象の拡張子を選択してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Exit Sub
		End If

		If MessageBox.Show("データの情報収集を開始します" & vbNewLine & "よろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
			Exit Sub
		End If

		Dim strSQL As String = ""
		Dim sqlProcess As New SQLProcess

		Try
			strSQL = "DELETE FROM T_出力"
			sqlProcess.DB_UPDATE(strSQL)

			Dim strLogFile As String = Me.txtSaveFolder.Text & "\" & Date.Now.ToString("yyyyMMdd_HHmmss") & "_情報収集.log"

			Dim enc As System.Text.Encoding = New System.Text.UTF8Encoding(False)
			Dim sw As New System.IO.StreamWriter(strLogFile, False, enc)

			Me.lblResult.Text = "カウント用ファイルリスト作成中…"
			Application.DoEvents()
			'各冊子ID単位で全てのファイルを列挙してT_カウントに格納する
			strSQL = "DELETE FROM T_カウント"
			sqlProcess.DB_UPDATE(strSQL)
			strSQL = "SELECT ID FROM M_冊子 ORDER BY ID"
			Dim dtBooklet As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
			Dim strExt As String() = {"*" & Me.cmbExt.SelectedItem}

			For iRow As Integer = 0 To dtBooklet.Rows.Count - 1
				Dim strFiles As String() = GetFilesMostDeep(Me.txtImagePath.Text & "\" & dtBooklet.Rows(iRow)("ID"), strExt)
				For Each strFile As String In strFiles
					strSQL = "INSERT INTO T_カウント (ID, ファイル名, カウント) "
					strSQL &= "VALUES(N'" & dtBooklet.Rows(iRow)("ID") & "', N'" & System.IO.Path.GetFileNameWithoutExtension(strFile) & "', 0)"
					sqlProcess.DB_UPDATE(strSQL)
				Next
			Next

			Me.lblResult.Text = "必要情報の列挙、DBへのINSERT中…"
			Application.DoEvents()

			'M_冊子、T_目次から必要情報を抜き出す
			strSQL = "SELECT ID, レコード番号, 冊子名, 目次タイトル, 著者名, リンク, リンクTO, 備考 FROM "
			strSQL &= "(SELECT T1.ID, T2.レコード番号, "
			strSQL &= "T1.冊子名 + ' ' + T1.年号 + ' ' + T1.Vol + ' ' + T1.No AS 冊子名, "
			strSQL &= "T2.目次タイトル, T2.著者名, T2.リンク, T2.リンクTO, T2.備考, "
			strSQL &= "CASE WHEN T2.目次タイトル = '' THEN 1 ELSE 0 END AS 不要レコード, "
			strSQL &= "CASE WHEN T2.目次タイトル = '表紙' AND T2.リンク = '' THEN 1 ELSE 0 END AS 不要表紙, "
			strSQL &= "CASE WHEN T2.目次タイトル = '広告' AND T2.リンク = '' THEN 1 ELSE 0 END AS 不要広告, "
			strSQL &= "CASE WHEN T2.リンク = '' AND T2.備考 = '9' THEN 1 ELSE 0 END AS フラグ9 "
			strSQL &= "FROM M_冊子 AS T1 INNER JOIN "
			strSQL &= "T_目次 AS T2 ON T1.ID = T2.ID) AS A1 "
			strSQL &= "WHERE A1.不要レコード = 0 AND A1.不要表紙 = 0 AND A1.不要広告 = 0 AND A1.フラグ9 = 0 "
			strSQL &= "ORDER BY A1.ID, A1.レコード番号"
			Dim dt As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)

			Dim iTotalCount As Integer = 0  'トータル連番
			Dim iFolderNo As Integer = 0    'フォルダ番号※目次タイトルが変わったらインクリメント

			'DATATABLEを回してリンク～リンクTOのファイルを該当冊子IDから探して、存在したらT_出力にINSERTする
			For iRow As Integer = 0 To dt.Rows.Count - 1
				'リンクとリンクTOを取得する
				Dim strLink As String = dt.Rows(iRow)("リンク")
				Dim strLinkTo As String = dt.Rows(iRow)("リンクTO")

				'FromとToのファイルが存在するか確認
				If Not IsNull(strLink) Then
					If Me.cmbExt.SelectedItem = ".pdf" Then
						'※PDFファイル名用
						If Not System.IO.File.Exists(Me.txtImagePath.Text & "\" & dt.Rows(iRow)("ID") & "\" & dt.Rows(iRow)("ID") & "_" & dt.Rows(iRow)("リンク") & Me.cmbExt.SelectedItem) Then
							sw.WriteLine("ファイルが存在しない(FROM)：" & dt.Rows(iRow)("ID") & "_" & dt.Rows(iRow)("リンク") & Me.cmbExt.SelectedItem)
						End If
					Else
						'JPGファイル名用
						If Not System.IO.File.Exists(Me.txtImagePath.Text & "\" & dt.Rows(iRow)("ID") & "\" & dt.Rows(iRow)("リンク") & Me.cmbExt.SelectedItem) Then
							sw.WriteLine("ファイルが存在しない(FROM)：" & dt.Rows(iRow)("ID") & "：" & dt.Rows(iRow)("リンク") & Me.cmbExt.SelectedItem)
						End If
					End If
				End If
				If Not IsNull(strLinkTo) Then
					If Me.cmbExt.SelectedItem = ".pdf" Then
						'※PDFファイル名用
						If Not System.IO.File.Exists(Me.txtImagePath.Text & "\" & dt.Rows(iRow)("ID") & "\" & dt.Rows(iRow)("ID") & "_" & dt.Rows(iRow)("リンクTO") & Me.cmbExt.SelectedItem) Then
							sw.WriteLine("ファイルが存在しない(TO)：" & dt.Rows(iRow)("ID") & "_" & dt.Rows(iRow)("リンク") & Me.cmbExt.SelectedItem)
						End If
					Else
						'JPGファイル名用
						If Not System.IO.File.Exists(Me.txtImagePath.Text & "\" & dt.Rows(iRow)("ID") & "\" & dt.Rows(iRow)("リンクTO") & Me.cmbExt.SelectedItem) Then
							sw.WriteLine("ファイルが存在しない(TO)：" & dt.Rows(iRow)("ID") & "：" & dt.Rows(iRow)("リンクTO") & Me.cmbExt.SelectedItem)
						End If
					End If
				End If

				'リンクが貼られていなかったら「対象イメージ無」フラグをたてて1レコードのみINSERT
				If IsNull(strLink) Then
					'リンクが無い
					'フォルダ番号はインクリメントしない
					sw.WriteLine("リンク無し：" & dt.Rows(iRow)("ID") & "：" & dt.Rows(iRow)("目次タイトル"))
					'1レコードのみINSERT
					'元ファイル名、フォルダ番号、ファイル名、ハイパーリンクは空文字にし、対象イメージ無フラグを立てる
					iTotalCount += 1
					Dim cho As String = ""
					If IsNull(dt.Rows(iRow)("著者名")) Then
						'NULLだったらハイフン
						cho = "-"
					Else
						cho = dt.Rows(iRow)("著者名")
					End If
					InsertData(iTotalCount, dt.Rows(iRow)("ID"), dt.Rows(iRow)("レコード番号"),
							   dt.Rows(iRow)("冊子名"), dt.Rows(iRow)("目次タイトル") & "　(※リンク無し)", cho,
							   "", "", "", "", 1)
				Else
					'フォルダ番号のインクリメント
					iFolderNo += 1
					'リンクあり、リンクTOに必ず値がある前提
					'FromToの全てのファイルの存在確認をして存在していたら配列に入れていく
					Dim iLink As Integer = CInt(strLink)
					Dim iLinkTo As Integer = CInt(strLinkTo)
					Dim lstFiles As New List(Of String)

					For iFile As Integer = iLink To iLinkTo
						'存在確認
						If Me.cmbExt.SelectedItem = ".pdf" Then
							'※PDFファイル名用
							If System.IO.File.Exists(Me.txtImagePath.Text & "\" & dt.Rows(iRow)("ID") & "\" & dt.Rows(iRow)("ID") & "_" & iFile.ToString("0000") & Me.cmbExt.SelectedItem) Then
								'存在したらコレクションへ追加
								lstFiles.Add(dt.Rows(iRow)("ID") & "_" & iFile.ToString("0000"))
							End If
						Else
							'JPGファイル名用
							If System.IO.File.Exists(Me.txtImagePath.Text & "\" & dt.Rows(iRow)("ID") & "\" & iFile.ToString("0000") & Me.cmbExt.SelectedItem) Then
								'存在したらコレクションへ追加
								lstFiles.Add(iFile.ToString("0000"))
							End If
						End If
					Next
					'列挙したファイル数分T_出力にINSERTしていく
					For i As Integer = 0 To lstFiles.Count - 1
						iTotalCount += 1
						'列挙したファイルが1ファイルの場合は「分子/分母」の表記はいらない
						Dim strTitle As String = ""
						If lstFiles.Count = 1 Then
							strTitle = dt.Rows(iRow)("目次タイトル")
						Else
							strTitle = dt.Rows(iRow)("目次タイトル") & "　" & (i + 1).ToString & "/" & lstFiles.Count.ToString
						End If
						Dim cho As String = ""
						If IsNull(dt.Rows(iRow)("著者名")) Then
							'NULLだったらハイフン
							cho = "-"
						Else
							cho = dt.Rows(iRow)("著者名")
						End If
						InsertData(iTotalCount, dt.Rows(iRow)("ID"), dt.Rows(iRow)("レコード番号"),
							   dt.Rows(iRow)("冊子名"), strTitle, cho,
							   lstFiles(i), iFolderNo.ToString("000000"), (i + 1).ToString("000"), Me.txtSaveFolder.Text & "\" & Me.txtSubFolder.Text & "\" & iFolderNo.ToString("000000"), 0)

						'T_カウントのID、ファイル名が合致したレコードのカウントをインクリメントする
						strSQL = "UPDATE T_カウント SET カウント += 1 "
						strSQL &= "WHERE ID = '" & dt.Rows(iRow)("ID") & "' "
						strSQL &= "AND ファイル名 = '" & lstFiles(i) & "'"
						sqlProcess.DB_UPDATE(strSQL)
					Next
				End If
			Next

			sw.Close()

			MessageBox.Show("処理が完了しました", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information)

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		Finally

			sqlProcess.Close()
			Me.lblResult.Text = ""

		End Try

	End Sub

	''' <summary>
	''' 出力(追加分)ボタン押下時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub btnAddOutput_Click(sender As Object, e As EventArgs) Handles btnAddOutput.Click

		If Not System.IO.Directory.Exists(Me.txtImagePath.Text) Then
			MessageBox.Show("元フォルダを指定してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Exit Sub
		End If
		If Not System.IO.Directory.Exists(Me.txtSaveFolder.Text) Then
			MessageBox.Show("先フォルダを指定してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Exit Sub
		End If
		If Me.cmbExt.SelectedIndex < 0 Then
			MessageBox.Show("対象の拡張子を選択してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Exit Sub
		End If

		If MessageBox.Show("データの出力(追加分)を開始します" & vbNewLine & "よろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
			Exit Sub
		End If

		Dim strSQL As String = ""
		Dim sqlProcess As New SQLProcess

		Try
			Me.lblResult.Text = "ファイルの振り分け、リスト出力中…"
			Application.DoEvents()

			'T_出力を基に画像振り分け、テキスト出力開始
			strSQL = "SELECT 連番, ID, 冊子名, 目次タイトル, 著者名, 元ファイル名, フォルダ番号, ファイル名, ハイパーリンク, 対象イメージ無 "
			strSQL &= "FROM T_出力追加分 "
			strSQL &= "ORDER BY 連番"
			Dim dt As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
			Dim strOutFile As String = Me.txtSaveFolder.Text & "\" & Date.Now.ToString("yyyyMMdd_HHmmss") & "_納品物(追加分).txt"
			Dim enc As System.Text.Encoding = New System.Text.UTF8Encoding(False)
			Dim swOut As New System.IO.StreamWriter(strOutFile, False, enc)
			Dim strLogFile As String = Me.txtSaveFolder.Text & "\" & Date.Now.ToString("yyyyMMdd_HHmmss") & "_出力(追加分).log"
			Dim sw As New System.IO.StreamWriter(strLogFile, False, enc)
			Dim strImageFolder As String = Me.txtImagePath.Text
			Dim strOutFolder As String = Me.txtSaveFolder.Text

			Dim strWriteLine As String = ""

			For iRow As Integer = 0 To dt.Rows.Count - 1
				'If dt.Rows(iRow)("対象イメージ無") = 1 Then

				'	'End If
				If Not System.IO.File.Exists(strImageFolder & "\" & dt.Rows(iRow)("ID") & "\" & dt.Rows(iRow)("元ファイル名") & Me.cmbExt.SelectedItem) Then
					'存在しなかった
					'sw.WriteLine("ファイル振り分け時：元ファイルなし：" & dt.Rows(iRow)("ID") & "：" & dt.Rows(iRow)("目次タイトル") & "：" & dt.Rows(iRow)("元ファイル名"))

					'テキスト出力
					strWriteLine = dt.Rows(iRow)("連番")
					strWriteLine &= vbTab & dt.Rows(iRow)("冊子名")
					'If dt.Rows(iRow)("対象イメージ無") = 1 Then
					'	strWriteLine &= vbTab & dt.Rows(iRow)("目次タイトル") & "　(※リンク無し)"
					'Else
					'	strWriteLine &= vbTab & dt.Rows(iRow)("目次タイトル")
					'End If
					strWriteLine &= vbTab & dt.Rows(iRow)("目次タイトル")
					strWriteLine &= vbTab & dt.Rows(iRow)("著者名")
					strWriteLine &= vbTab & ""  'フォルダ番号
					strWriteLine &= vbTab & ""  'ファイル名
					strWriteLine &= vbTab & ""  'ハイパーリンク
					swOut.WriteLine(strWriteLine)

				Else
					'存在した
					'======================================================================
					'ファイル振り分け
					Dim strCurrentFolder As String = strOutFolder & "\" & Me.txtSubFolder.Text & "\" & dt.Rows(iRow)("フォルダ番号")
					Dim strCurrentFile As String = strCurrentFolder & "\" & dt.Rows(iRow)("フォルダ番号") & "_" & dt.Rows(iRow)("ファイル名") & Me.cmbExt.SelectedItem
					Dim strOldFile As String = Me.txtImagePath.Text & "\" & dt.Rows(iRow)("ID") & "\" & dt.Rows(iRow)("元ファイル名") & Me.cmbExt.SelectedItem
					If Not System.IO.Directory.Exists(strCurrentFolder & "\" & dt.Rows(iRow)("フォルダ番号")) Then
						My.Computer.FileSystem.CreateDirectory(strCurrentFolder)
					End If
					'ファイルコピー
					My.Computer.FileSystem.CopyFile(strOldFile, strCurrentFile, False)
					'======================================================================

					'テキスト出力
					strWriteLine = dt.Rows(iRow)("連番")
					strWriteLine &= vbTab & dt.Rows(iRow)("冊子名")
					'If dt.Rows(iRow)("対象イメージ無") = 1 Then
					'	strWriteLine &= vbTab & dt.Rows(iRow)("目次タイトル") & "　(対象イメージ無し)"
					'Else
					'	strWriteLine &= vbTab & dt.Rows(iRow)("目次タイトル")
					'End If
					strWriteLine &= vbTab & dt.Rows(iRow)("目次タイトル")
					strWriteLine &= vbTab & dt.Rows(iRow)("著者名")
					strWriteLine &= vbTab & dt.Rows(iRow)("フォルダ番号")
					strWriteLine &= vbTab & dt.Rows(iRow)("フォルダ番号") & "_" & dt.Rows(iRow)("ファイル名")
					strWriteLine &= vbTab & dt.Rows(iRow)("ハイパーリンク")
					swOut.WriteLine(strWriteLine)

				End If
				''テキスト出力
				'Dim strWriteLine As String = ""
				'strWriteLine = dt.Rows(iRow)("冊子名")
				'If dt.Rows(iRow)("対象イメージ無") = 1 Then
				'	strWriteLine &= vbTab & dt.Rows(iRow)("目次タイトル") & "　(対象イメージ無し)"
				'Else
				'	strWriteLine &= vbTab & dt.Rows(iRow)("目次タイトル")
				'End If
				'strWriteLine &= vbTab & dt.Rows(iRow)("著者名")
				'strWriteLine &= vbTab & dt.Rows(iRow)("フォルダ番号")
				'strWriteLine &= vbTab & dt.Rows(iRow)("フォルダ番号") & "_" & dt.Rows(iRow)("ファイル名")
				'strWriteLine &= vbTab & dt.Rows(iRow)("ハイパーリンク")
				'swOut.WriteLine(strWriteLine)
			Next

			swOut.Close()
			sw.Close()

			MessageBox.Show("処理が完了しました", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information)

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		Finally

			sqlProcess.Close()
			Me.lblResult.Text = ""

		End Try

	End Sub

	''' <summary>
	''' 出力ボタン押下時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub btnOutput_Click(sender As Object, e As EventArgs) Handles btnOutput.Click

		If Not System.IO.Directory.Exists(Me.txtImagePath.Text) Then
			MessageBox.Show("元フォルダを指定してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Exit Sub
		End If
		If Not System.IO.Directory.Exists(Me.txtSaveFolder.Text) Then
			MessageBox.Show("先フォルダを指定してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Exit Sub
		End If
		If Me.cmbExt.SelectedIndex < 0 Then
			MessageBox.Show("対象の拡張子を選択してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Exit Sub
		End If

		If MessageBox.Show("データの出力を開始します" & vbNewLine & "よろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
			Exit Sub
		End If

		Dim strSQL As String = ""
		Dim sqlProcess As New SQLProcess

		Try
			Me.lblResult.Text = "ファイルの振り分け、リスト出力中…"
			Application.DoEvents()

			'T_出力を基に画像振り分け、テキスト出力開始
			strSQL = "SELECT 連番, ID, 冊子名, 目次タイトル, 著者名, 元ファイル名, フォルダ番号, ファイル名, ハイパーリンク, 対象イメージ無 "
			strSQL &= "FROM T_出力 "
			strSQL &= "ORDER BY 連番"
			Dim dt As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
			Dim strOutFile As String = Me.txtSaveFolder.Text & "\" & Date.Now.ToString("yyyyMMdd_HHmmss") & "_納品物.txt"
			Dim enc As System.Text.Encoding = New System.Text.UTF8Encoding(False)
			Dim swOut As New System.IO.StreamWriter(strOutFile, False, enc)
			Dim strLogFile As String = Me.txtSaveFolder.Text & "\" & Date.Now.ToString("yyyyMMdd_HHmmss") & "_出力.log"
			Dim sw As New System.IO.StreamWriter(strLogFile, False, enc)
			Dim strImageFolder As String = Me.txtImagePath.Text
			Dim strOutFolder As String = Me.txtSaveFolder.Text

			Dim strWriteLine As String = ""

			For iRow As Integer = 0 To dt.Rows.Count - 1
				'If dt.Rows(iRow)("対象イメージ無") = 1 Then

				'	'End If
				If Not System.IO.File.Exists(strImageFolder & "\" & dt.Rows(iRow)("ID") & "\" & dt.Rows(iRow)("元ファイル名") & Me.cmbExt.SelectedItem) Then
					'存在しなかった
					'sw.WriteLine("ファイル振り分け時：元ファイルなし：" & dt.Rows(iRow)("ID") & "：" & dt.Rows(iRow)("目次タイトル") & "：" & dt.Rows(iRow)("元ファイル名"))

					'テキスト出力
					strWriteLine = dt.Rows(iRow)("連番")
					strWriteLine &= vbTab & dt.Rows(iRow)("冊子名")
					'If dt.Rows(iRow)("対象イメージ無") = 1 Then
					'	strWriteLine &= vbTab & dt.Rows(iRow)("目次タイトル") & "　(※リンク無し)"
					'Else
					'	strWriteLine &= vbTab & dt.Rows(iRow)("目次タイトル")
					'End If
					strWriteLine &= vbTab & dt.Rows(iRow)("目次タイトル")
					strWriteLine &= vbTab & dt.Rows(iRow)("著者名")
					strWriteLine &= vbTab & ""  'フォルダ番号
					strWriteLine &= vbTab & ""  'ファイル名
					strWriteLine &= vbTab & ""  'ハイパーリンク
					swOut.WriteLine(strWriteLine)

				Else
					'存在した
					'======================================================================
					'ファイル振り分け
					Dim strCurrentFolder As String = strOutFolder & "\" & Me.txtSubFolder.Text & "\" & dt.Rows(iRow)("フォルダ番号")
					Dim strCurrentFile As String = strCurrentFolder & "\" & dt.Rows(iRow)("フォルダ番号") & "_" & dt.Rows(iRow)("ファイル名") & Me.cmbExt.SelectedItem
					Dim strOldFile As String = Me.txtImagePath.Text & "\" & dt.Rows(iRow)("ID") & "\" & dt.Rows(iRow)("元ファイル名") & Me.cmbExt.SelectedItem
					If Not System.IO.Directory.Exists(strCurrentFolder & "\" & dt.Rows(iRow)("フォルダ番号")) Then
						My.Computer.FileSystem.CreateDirectory(strCurrentFolder)
					End If
					'ファイルコピー
					My.Computer.FileSystem.CopyFile(strOldFile, strCurrentFile, False)
					'======================================================================

					'テキスト出力
					strWriteLine = dt.Rows(iRow)("連番")
					strWriteLine &= vbTab & dt.Rows(iRow)("冊子名")
					'If dt.Rows(iRow)("対象イメージ無") = 1 Then
					'	strWriteLine &= vbTab & dt.Rows(iRow)("目次タイトル") & "　(対象イメージ無し)"
					'Else
					'	strWriteLine &= vbTab & dt.Rows(iRow)("目次タイトル")
					'End If
					strWriteLine &= vbTab & dt.Rows(iRow)("目次タイトル")
					strWriteLine &= vbTab & dt.Rows(iRow)("著者名")
					strWriteLine &= vbTab & dt.Rows(iRow)("フォルダ番号")
					strWriteLine &= vbTab & dt.Rows(iRow)("フォルダ番号") & "_" & dt.Rows(iRow)("ファイル名")
					strWriteLine &= vbTab & dt.Rows(iRow)("ハイパーリンク")
					swOut.WriteLine(strWriteLine)

				End If
				''テキスト出力
				'Dim strWriteLine As String = ""
				'strWriteLine = dt.Rows(iRow)("冊子名")
				'If dt.Rows(iRow)("対象イメージ無") = 1 Then
				'	strWriteLine &= vbTab & dt.Rows(iRow)("目次タイトル") & "　(対象イメージ無し)"
				'Else
				'	strWriteLine &= vbTab & dt.Rows(iRow)("目次タイトル")
				'End If
				'strWriteLine &= vbTab & dt.Rows(iRow)("著者名")
				'strWriteLine &= vbTab & dt.Rows(iRow)("フォルダ番号")
				'strWriteLine &= vbTab & dt.Rows(iRow)("フォルダ番号") & "_" & dt.Rows(iRow)("ファイル名")
				'strWriteLine &= vbTab & dt.Rows(iRow)("ハイパーリンク")
				'swOut.WriteLine(strWriteLine)
			Next

			swOut.Close()
			sw.Close()

			MessageBox.Show("処理が完了しました", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information)

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		Finally

			sqlProcess.Close()
			Me.lblResult.Text = ""

		End Try

	End Sub

	Private Sub InsertData(ByVal ren As Integer, ByVal strID As String, ByVal rec As Integer,
						   ByVal strBooklet As String, ByVal strTitle As String, ByVal cho As String, ByVal moto As String,
						   ByVal strFolder As String, ByVal strFile As String, ByVal hyper As String,
						   ByVal noimage As Integer)

		Dim strSQL As String = ""
		Dim sqlProcess As New SQLProcess

		Try
			strSQL = "INSERT INTO T_出力 (連番, ID, レコード番号, 冊子名, 目次タイトル, 著者名, 元ファイル名, フォルダ番号, ファイル名, ハイパーリンク, 対象イメージ無) "
			strSQL &= "VALUES("
			strSQL &= ren   '連番
			strSQL &= ", N'" & strID & "'"  'ID
			strSQL &= ", " & rec    'レコード番号
			strSQL &= ", N'" & strBooklet & "'" '冊子名
			strSQL &= ", N'" & strTitle.Replace("'", "''") & "'"   '目次タイトル
			strSQL &= ", N'" & cho & "'"    '著者名
			strSQL &= ", N'" & moto & "'"   '元ファイル名
			strSQL &= ", N'" & strFolder & "'"  'フォルダ番号
			strSQL &= ", N'" & strFile & "'"    'ファイル名
			strSQL &= ", N'" & hyper & "'"  'ハイパーリンク
			strSQL &= ", " & noimage & ")"  '対象イメージ無フラグ
			sqlProcess.DB_UPDATE(strSQL)

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		Finally

			sqlProcess.Close()

		End Try
	End Sub

	''' <summary>
	''' データ挿入(追加分)
	''' </summary>
	''' <param name="ren"></param>
	''' <param name="strID"></param>
	''' <param name="rec"></param>
	''' <param name="strBooklet"></param>
	''' <param name="strTitle"></param>
	''' <param name="cho"></param>
	''' <param name="moto"></param>
	''' <param name="strFolder"></param>
	''' <param name="strFile"></param>
	''' <param name="hyper"></param>
	''' <param name="noimage"></param>
	Private Sub InsertDataAdd(ByVal ren As Integer, ByVal strID As String, ByVal rec As Integer,
						   ByVal strBooklet As String, ByVal strTitle As String, ByVal cho As String, ByVal moto As String,
						   ByVal strFolder As String, ByVal strFile As String, ByVal hyper As String,
						   ByVal noimage As Integer)

		Dim strSQL As String = ""
		Dim sqlProcess As New SQLProcess

		Try
			strSQL = "INSERT INTO T_出力追加分 (連番, ID, レコード番号, 冊子名, 目次タイトル, 著者名, 元ファイル名, フォルダ番号, ファイル名, ハイパーリンク, 対象イメージ無) "
			strSQL &= "VALUES("
			strSQL &= ren   '連番
			strSQL &= ", N'" & strID & "'"  'ID
			strSQL &= ", " & rec    'レコード番号
			strSQL &= ", N'" & strBooklet & "'" '冊子名
			strSQL &= ", N'" & strTitle.Replace("'", "''") & "'"   '目次タイトル
			strSQL &= ", N'" & cho & "'"    '著者名
			strSQL &= ", N'" & moto & "'"   '元ファイル名
			strSQL &= ", N'" & strFolder & "'"  'フォルダ番号
			strSQL &= ", N'" & strFile & "'"    'ファイル名
			strSQL &= ", N'" & hyper & "'"  'ハイパーリンク
			strSQL &= ", " & noimage & ")"  '対象イメージ無フラグ
			sqlProcess.DB_UPDATE(strSQL)

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		Finally

			sqlProcess.Close()

		End Try

	End Sub

	Private Sub btnFinalOutput_Click(sender As Object, e As EventArgs) Handles btnFinalOutput.Click

		If Not System.IO.Directory.Exists(Me.txtImagePath.Text) Then
			MessageBox.Show("元フォルダを指定してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Exit Sub
		End If
		If Not System.IO.Directory.Exists(Me.txtSaveFolder.Text) Then
			MessageBox.Show("先フォルダを指定してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Exit Sub
		End If
		If Me.cmbExt.SelectedIndex < 0 Then
			MessageBox.Show("対象の拡張子を選択してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Exit Sub
		End If

		If MessageBox.Show("最終出力を開始します" & vbNewLine & "よろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
			Exit Sub
		End If

		Dim strSQL As String = ""
		Dim sqlProcess As New SQLProcess

		Try
			Me.lblResult.Text = "ファイルの振り分け、リスト出力中…"
			Application.DoEvents()

			Dim strOutFile As String = Me.txtSaveFolder.Text & "\" & Date.Now.ToString("yyyyMMdd_HHmmss") & "_納品物.txt"
			Dim enc As System.Text.Encoding = New System.Text.UTF8Encoding(False)
			Dim swOut As New System.IO.StreamWriter(strOutFile, False, enc)
			'Dim strLogFile As String = Me.txtSaveFolder.Text & "\" & Date.Now.ToString("yyyyMMdd_HHmmss") & "_出力.log"
			'Dim sw As New System.IO.StreamWriter(strLogFile, False, enc)
			Dim strImageFolder As String = Me.txtImagePath.Text
			Dim strOutFolder As String = Me.txtSaveFolder.Text

			Dim strWriteLine As String = ""

			strSQL = "SELECT 連番, 冊子名, 目次タイトル, 著者名, フォルダ番号, リンクファイル名, ハイパーリンク "
			strSQL &= "FROM T_出力最終 "
			strSQL &= "ORDER BY 連番"
			Dim dt As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)

			For iRow As Integer = 0 To dt.Rows.Count - 1
				strWriteLine = dt.Rows(iRow)("連番")
				strWriteLine &= vbTab & dt.Rows(iRow)("冊子名")
				strWriteLine &= vbTab & dt.Rows(iRow)("目次タイトル")
				strWriteLine &= vbTab & dt.Rows(iRow)("著者名")
				strWriteLine &= vbTab & dt.Rows(iRow)("フォルダ番号")
				strWriteLine &= vbTab & dt.Rows(iRow)("リンクファイル名")
				strWriteLine &= vbTab & dt.Rows(iRow)("ハイパーリンク")
				swOut.WriteLine(strWriteLine)
			Next

			swOut.Close()
			MessageBox.Show("処理が終了しました", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information)

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		Finally

			sqlProcess.Close()

		End Try

	End Sub

	Private Sub btnRename_Click(sender As Object, e As EventArgs) Handles btnRename.Click

		If MessageBox.Show("開始します" & vbNewLine & "よろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
			Exit Sub
		End If

		Dim strSQL As String = ""
		Dim sqlProcess As New SQLProcess
		Dim strSrcFolder As String = "\\hydra\01_制作Gr\04_スポット案件\20170201_161241005_富士フィルムIS\31_PDF変換"

		Try
			strSQL = "SELECT ID, 元ファイル名, リンクファイル名, ハイパーリンク "
			strSQL &= "FROM T_目次広告 "
			strSQL &= "WHERE 対象イメージ無 = 0 AND (ID BETWEEN '0101' AND '0106')"
			Dim dt As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)

			For iRow As Integer = 0 To dt.Rows.Count - 1
				Dim strPDFFile As String = strSrcFolder & "\" & dt.Rows(iRow)("ID") & "\" & dt.Rows(iRow)("元ファイル名") & ".pdf"
				If Not System.IO.File.Exists(strPDFFile) Then
					MessageBox.Show("ファイルが存在しません", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
					Exit Sub
				End If
				Dim strDestFile As String = dt.Rows(iRow)("ハイパーリンク") & "\" & dt.Rows(iRow)("リンクファイル名") & ".pdf"

				If Not System.IO.File.Exists(strDestFile) Then
					MessageBox.Show("コピー先ファイルが存在しません", "絵エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
					Exit Sub
				Else
					My.Computer.FileSystem.CopyFile(strPDFFile, strDestFile, True)
				End If
			Next

			MessageBox.Show("処理が終了しました", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information)

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		Finally

			SQLProcess.Close()

		End Try

	End Sub

	Private Sub btnFinalRun_Click(sender As Object, e As EventArgs) Handles btnFinalRun.Click

		If Not System.IO.Directory.Exists(Me.txtImagePath.Text) Then
			MessageBox.Show("元フォルダを指定してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Exit Sub
		End If
		If Not System.IO.Directory.Exists(Me.txtSaveFolder.Text) Then
			MessageBox.Show("先フォルダを指定してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Exit Sub
		End If
		If Me.cmbExt.SelectedIndex < 0 Then
			MessageBox.Show("対象の拡張子を選択してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Exit Sub
		End If

		If MessageBox.Show("データの情報収集を開始します" & vbNewLine & "よろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
			Exit Sub
		End If

		Dim strSQL As String = ""
		Dim sqlProcess As New SQLProcess

		Try
			strSQL = "DELETE FROM T_出力最終"
			sqlProcess.DB_UPDATE(strSQL)

			Dim strLogFile As String = Me.txtSaveFolder.Text & "\" & Date.Now.ToString("yyyyMMdd_HHmmss") & "_出力最終.log"

			Dim enc As System.Text.Encoding = New System.Text.UTF8Encoding(False)
			Dim sw As New System.IO.StreamWriter(strLogFile, False, enc)

			Me.lblResult.Text = "カウント用ファイルリスト作成中…"
			Application.DoEvents()

			'IDの取得
			strSQL = "SELECT ID FROM M_冊子広告 "
			strSQL &= "ORDER BY ID"
			Dim dtID As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)

			Dim iTotalCount As Integer = 0  'トータル連番
			Dim iFolderNo As Integer = 0    'フォルダ番号

			For iID As Integer = 0 To dtID.Rows.Count - 1
				'1ID中のフォルダ番号を列挙する
				strSQL = "SELECT フォルダ番号 FROM T_目次広告 "
				strSQL &= "WHERE ID = '" & dtID.Rows(iID)("ID") & "' "
				strSQL &= "AND ISNULL(フォルダ番号, '') != '' "
				strSQL &= "GROUP BY フォルダ番号 "
				strSQL &= "ORDER BY フォルダ番号"
				Dim dtFolderNo As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)

				For iFolder As Integer = 0 To dtFolderNo.Rows.Count - 1
					'フォルダ番号単位で表紙、記事、広告、その他の順にレコードを作成していく
					'表紙、記事(広告、その他以外)
					strSQL = "SELECT 連番, ID, レコード番号, 冊子名, 目次タイトル, 著者名, 元ファイル名, フォルダ番号, ファイル名, リンクファイル名, ハイパーリンク, 対象イメージ無, 備考, うるる備考 "
					strSQL &= "FROM T_目次広告 "
					strSQL &= "WHERE ID = '" & dtID.Rows(iID)("ID") & "' "
					strSQL &= "AND フォルダ番号 = '" & dtFolderNo.Rows(iFolder)("フォルダ番号") & "' "
					strSQL &= "AND 目次タイトル NOT LIKE '広告%' "
					strSQL &= "AND 目次タイトル NOT LIKE 'その他%' "
					strSQL &= "ORDER BY レコード番号, 連番"
					Dim dt As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
					'If dtID.Rows(iID)("ID") = "0016" Then
					'	Dim i As Integer = 0
					'End If

					'1レコードでもヒットしたらフォルダ番号をインクリメント
					If dt.Rows.Count > 0 Then
						iFolderNo += 1
					End If

					'リンク無しレコードを除去したレコード数を取得する
					strSQL = "SELECT COUNT(*) FROM T_目次広告 "
					strSQL &= "WHERE ID = '" & dtID.Rows(iID)("ID") & "' "
					strSQL &= "AND フォルダ番号 = '" & dtFolderNo.Rows(iFolder)("フォルダ番号") & "' "
					strSQL &= "AND 目次タイトル NOT LIKE '広告%' "
					strSQL &= "AND 目次タイトル NOT LIKE 'その他%' "
					strSQL &= "AND 対象イメージ無 = 0"
					Dim iRecTotal As Integer = sqlProcess.DB_EXECUTE_SCALAR(strSQL) '分母
					Dim iRec As Integer = 0 '分子

					'Dim iNoTarget As Integer = 0
					For iRow As Integer = 0 To dt.Rows.Count - 1
						'対象イメージ無カウントを取り、ファイル名の命名時に減算する
						'記事の塊
						'連番をインクリメント
						iTotalCount += 1

						'連番、フォルダ番号、ファイル名、リンクファイル名、ハイパーリンクを書き換えながらT_出力最終にINSERTする
						strSQL = "INSERT INTO T_出力最終 (連番, ID, レコード番号, 冊子名, 目次タイトル, 著者名, 元ファイル名, フォルダ番号, ファイル名, リンクファイル名, ハイパーリンク, 対象イメージ無, 備考, うるる備考) "
						strSQL &= "VALUES("
						strSQL &= iTotalCount   '連番
						strSQL &= ", N'" & dtID.Rows(iID)("ID") & "'"    'ID
						strSQL &= ", " & dt.Rows(iRow)("レコード番号")    'レコード番号
						strSQL &= ", N'" & dt.Rows(iRow)("冊子名") & "'"   '冊子名
						'対象イメージ無の有無によって分岐
						'目次タイトルのダブルクォート対応
						Dim strTitle As String = dt.Rows(iRow)("目次タイトル")
						If Not IsNull(strTitle) Then
							strTitle = strTitle.Replace("'", "''")
						End If
						If dt.Rows(iRow)("対象イメージ無") = 0 Then
							If iRecTotal = 1 Then
								'1レコードの場合は分割数は追記しない
								iRec = 1
								strSQL &= ", N'" & DeleteNum(strTitle) & "'" '分割数なし目次タイトル
							Else
								'複数レコードとなる場合は対象イメージ無を覗いた分割数を追記する
								iRec += 1
								strSQL &= ", N'" & DeleteNum(strTitle) & "　" & iRec & "/" & iRecTotal & "'"    '分割数あり目次タイトル
							End If
							strSQL &= ", N'" & dt.Rows(iRow)("著者名") & "'"   '著者名
							strSQL &= ", N'" & dt.Rows(iRow)("元ファイル名") & "'"    '元ファイル名
							strSQL &= ", N'" & iFolderNo.ToString("000000") & "'"   'フォルダ番号
							strSQL &= ", N'" & iRec.ToString("000") & "'" 'ファイル名(iNoTargetを減算する)
							strSQL &= ", N'" & iFolderNo.ToString("000000") & "_" & iRec.ToString("000") & "'"    'リンクファイル名
							strSQL &= ", N'" & Me.txtSaveFolder.Text & "\" & Me.txtSubFolder.Text & "\" & iFolderNo.ToString("000000") & "'"    'ハイパーリンク

							'ファイルコピー
							Dim strSrcFile As String = dt.Rows(iRow)("ハイパーリンク") & "\" & dt.Rows(iRow)("リンクファイル名") & Me.cmbExt.SelectedItem
							Dim strDestFile As String = Me.txtSaveFolder.Text & "\" & Me.txtSubFolder.Text & "\" & iFolderNo.ToString("000000") & "\" & iFolderNo.ToString("000000") & "_" & iRec.ToString("000") & Me.cmbExt.SelectedItem
							If Not System.IO.File.Exists(strSrcFile) Then
								MessageBox.Show("元ファイルが見つかりません" & vbNewLine & strSrcFile, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
								Exit Sub
							End If
							If Not System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(strDestFile)) Then
								My.Computer.FileSystem.CreateDirectory(System.IO.Path.GetDirectoryName(strDestFile))
							End If
							My.Computer.FileSystem.CopyFile(strSrcFile, strDestFile)
							sw.WriteLine(strSrcFile & vbTab & "→" & vbTab & strDestFile)

							'If Not System.IO.File.Exists(strDestFile) Then
							'	MessageBox.Show("先ファイルが見つかりません" & vbNewLine & strDestFile, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
							'	Exit Sub
							'End If
						Else
							'対象イメージ無＝1の場合は、iNoTargetをインクリメントして、該当項目は空白
							'iNoTarget += 1
							strSQL &= ", N'" & DeleteNum(strTitle) & "'" '分割数なし目次タイトル
							strSQL &= ", N'" & dt.Rows(iRow)("著者名") & "'"   '著者名
							strSQL &= ", N''"   '元ファイル名
							strSQL &= ", N''"   'フォルダ番号
							strSQL &= ", N''"   'ファイル名
							strSQL &= ", N''"   'リンクファイル名
							strSQL &= ", N''"   'ハイパーリンク
						End If
						strSQL &= ", " & IIf(dt.Rows(iRow)("対象イメージ無") = False, 0, 1)   '対象イメージ無
						strSQL &= ", N'" & dt.Rows(iRow)("備考") & "'"    '備考
						strSQL &= ", N'" & dt.Rows(iRow)("うるる備考") & "')"    'うるる備考
						sqlProcess.DB_UPDATE(strSQL)
					Next
					'広告
					strSQL = "SELECT 連番, ID, レコード番号, 冊子名, 目次タイトル, 著者名, 元ファイル名, フォルダ番号, ファイル名, リンクファイル名, ハイパーリンク, 対象イメージ無, 備考, うるる備考 "
					strSQL &= "FROM T_目次広告 "
					strSQL &= "WHERE ID = '" & dtID.Rows(iID)("ID") & "' "
					strSQL &= "AND フォルダ番号 = '" & dtFolderNo.Rows(iFolder)("フォルダ番号") & "' "
					strSQL &= "AND 目次タイトル LIKE '広告%' "
					strSQL &= "ORDER BY レコード番号, 連番"
					dt = sqlProcess.DB_SELECT_DATATABLE(strSQL)
					'1レコードでもヒットしたらフォルダ番号をインクリメント
					If dt.Rows.Count > 0 Then
						iFolderNo += 1
					End If
					For iRow As Integer = 0 To dt.Rows.Count - 1
						'記事の塊
						'連番をインクリメント
						iTotalCount += 1
						'連番、フォルダ番号、ファイル名、リンクファイル名、ハイパーリンクを書き換えながらT_出力最終にINSERTする
						strSQL = "INSERT INTO T_出力最終 (連番, ID, レコード番号, 冊子名, 目次タイトル, 著者名, 元ファイル名, フォルダ番号, ファイル名, リンクファイル名, ハイパーリンク, 対象イメージ無, 備考, うるる備考) "
						strSQL &= "VALUES("
						strSQL &= iTotalCount   '連番
						strSQL &= ", N'" & dtID.Rows(iID)("ID") & "'"    'ID
						strSQL &= ", " & dt.Rows(iRow)("レコード番号")    'レコード番号
						strSQL &= ", N'" & dt.Rows(iRow)("冊子名") & "'"   '冊子名
						Dim strTitle As String = dt.Rows(iRow)("目次タイトル")
						If Not IsNull(strTitle) Then
							strTitle = strTitle.Replace("'", "''")
						End If
						strSQL &= ", N'" & DeleteNum(strTitle) & "'" '分割数なし目次タイトル
						strSQL &= ", N'" & dt.Rows(iRow)("著者名") & "'"   '著者名
						strSQL &= ", N'" & dt.Rows(iRow)("元ファイル名") & "'"    '元ファイル名
						strSQL &= ", N'" & iFolderNo.ToString("000000") & "'"   'フォルダ番号
						strSQL &= ", N'" & (iRow + 1).ToString("000") & "'" 'ファイル名
						strSQL &= ", N'" & iFolderNo.ToString("000000") & "_" & (iRow + 1).ToString("000") & "'"  'リンクファイル名
						strSQL &= ", N'" & Me.txtSaveFolder.Text & "\" & Me.txtSubFolder.Text & "\" & iFolderNo.ToString("000000") & "'"    'ハイパーリンク
						strSQL &= ", " & IIf(dt.Rows(iRow)("対象イメージ無") = False, 0, 1)   '対象イメージ無
						strSQL &= ", N'" & dt.Rows(iRow)("備考") & "'"    '備考
						strSQL &= ", N'" & dt.Rows(iRow)("うるる備考") & "')"    'うるる備考
						sqlProcess.DB_UPDATE(strSQL)

						'ファイルコピー
						Dim strSrcFile As String = dt.Rows(iRow)("ハイパーリンク") & "\" & dt.Rows(iRow)("リンクファイル名") & Me.cmbExt.SelectedItem
						Dim strDestFile As String = Me.txtSaveFolder.Text & "\" & Me.txtSubFolder.Text & "\" & iFolderNo.ToString("000000") & "\" & iFolderNo.ToString("000000") & "_" & (iRow + 1).ToString("000") & Me.cmbExt.SelectedItem
						If Not System.IO.File.Exists(strSrcFile) Then
							MessageBox.Show("元ファイルが見つかりません" & vbNewLine & strSrcFile, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
							Exit Sub
						End If
						If Not System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(strDestFile)) Then
							My.Computer.FileSystem.CreateDirectory(System.IO.Path.GetDirectoryName(strDestFile))
						End If
						My.Computer.FileSystem.CopyFile(strSrcFile, strDestFile)
						sw.WriteLine(strSrcFile & vbTab & "→" & vbTab & strDestFile)
					Next
					'その他
					strSQL = "SELECT 連番, ID, レコード番号, 冊子名, 目次タイトル, 著者名, 元ファイル名, フォルダ番号, ファイル名, リンクファイル名, ハイパーリンク, 対象イメージ無, 備考, うるる備考 "
					strSQL &= "FROM T_目次広告 "
					strSQL &= "WHERE ID = '" & dtID.Rows(iID)("ID") & "' "
					strSQL &= "AND フォルダ番号 = '" & dtFolderNo.Rows(iFolder)("フォルダ番号") & "' "
					strSQL &= "AND 目次タイトル LIKE 'その他%' "
					strSQL &= "ORDER BY レコード番号, 連番"
					dt = sqlProcess.DB_SELECT_DATATABLE(strSQL)
					'1レコードでもヒットしたらフォルダ番号をインクリメント
					If dt.Rows.Count > 0 Then
						iFolderNo += 1
					End If
					For iRow As Integer = 0 To dt.Rows.Count - 1
						'記事の塊
						'連番をインクリメント
						iTotalCount += 1
						'連番、フォルダ番号、ファイル名、リンクファイル名、ハイパーリンクを書き換えながらT_出力最終にINSERTする
						strSQL = "INSERT INTO T_出力最終 (連番, ID, レコード番号, 冊子名, 目次タイトル, 著者名, 元ファイル名, フォルダ番号, ファイル名, リンクファイル名, ハイパーリンク, 対象イメージ無, 備考, うるる備考) "
						strSQL &= "VALUES("
						strSQL &= iTotalCount   '連番
						strSQL &= ", N'" & dtID.Rows(iID)("ID") & "'"    'ID
						strSQL &= ", " & dt.Rows(iRow)("レコード番号")    'レコード番号
						strSQL &= ", N'" & dt.Rows(iRow)("冊子名") & "'"   '冊子名
						Dim strTitle As String = dt.Rows(iRow)("目次タイトル")
						If Not IsNull(strTitle) Then
							strTitle = strTitle.Replace("'", "''")
						End If
						strSQL &= ", N'" & DeleteNum(strTitle) & "'" '分割数なし目次タイトル
						strSQL &= ", N'" & dt.Rows(iRow)("著者名") & "'"   '著者名
						strSQL &= ", N'" & dt.Rows(iRow)("元ファイル名") & "'"    '元ファイル名
						strSQL &= ", N'" & iFolderNo.ToString("000000") & "'"   'フォルダ番号
						strSQL &= ", N'" & (iRow + 1).ToString("000") & "'" 'ファイル名
						strSQL &= ", N'" & iFolderNo.ToString("000000") & "_" & (iRow + 1).ToString("000") & "'"  'リンクファイル名
						strSQL &= ", N'" & Me.txtSaveFolder.Text & "\" & Me.txtSubFolder.Text & "\" & iFolderNo.ToString("000000") & "'"    'ハイパーリンク
						strSQL &= ", " & IIf(dt.Rows(iRow)("対象イメージ無") = False, 0, 1)   '対象イメージ無
						strSQL &= ", N'" & dt.Rows(iRow)("備考") & "'"    '備考
						strSQL &= ", N'" & dt.Rows(iRow)("うるる備考") & "')"    'うるる備考
						sqlProcess.DB_UPDATE(strSQL)

						'ファイルコピー
						Dim strSrcFile As String = dt.Rows(iRow)("ハイパーリンク") & "\" & dt.Rows(iRow)("リンクファイル名") & Me.cmbExt.SelectedItem
						Dim strDestFile As String = Me.txtSaveFolder.Text & "\" & Me.txtSubFolder.Text & "\" & iFolderNo.ToString("000000") & "\" & iFolderNo.ToString("000000") & "_" & (iRow + 1).ToString("000") & Me.cmbExt.SelectedItem
						If Not System.IO.File.Exists(strSrcFile) Then
							MessageBox.Show("元ファイルが見つかりません" & vbNewLine & strSrcFile, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
							Exit Sub
						End If
						If Not System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(strDestFile)) Then
							My.Computer.FileSystem.CreateDirectory(System.IO.Path.GetDirectoryName(strDestFile))
						End If
						My.Computer.FileSystem.CopyFile(strSrcFile, strDestFile)
						sw.WriteLine(strSrcFile & vbTab & "→" & vbTab & strDestFile)
					Next
				Next
			Next

			sw.Close()
			MessageBox.Show("情報収集が終了しました", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information)

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		Finally

			sqlProcess.Close()
			Me.lblResult.Text = ""

		End Try
	End Sub

	''' <summary>
	''' 文字列中の末尾の「　n/n」を除去する
	''' </summary>
	''' <param name="strTitle"></param>
	Private Function DeleteNum(ByVal strTitle As String) As String

		If IsNull(strTitle) Then
			Return ""
			Exit Function
		End If

		Dim strReturn As String = strTitle
		'50/50までに対応
		For x As Integer = 50 To 1 Step -1
			For y As Integer = 50 To 1 Step -1
				strReturn = strReturn.Replace("　" & x & "/" & y, "")
			Next
		Next

		Return strReturn

	End Function

End Class