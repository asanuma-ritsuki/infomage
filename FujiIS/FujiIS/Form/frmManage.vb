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

End Class