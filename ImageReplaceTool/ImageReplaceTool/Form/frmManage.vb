Public Class frmManage

#Region "フォームイベント"

	''' <summary>
	''' フォームロード時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub frmManage_Load(sender As Object, e As EventArgs) Handles MyBase.Load

		Me.Text = My.Application.Info.ProductName & " Ver." &
			My.Application.Info.Version.ToString & " - [管理]"

		Initialize()

	End Sub

#End Region

#Region "オブジェクトイベント"

	''' <summary>
	''' 戻るボタン押下時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click

		If MessageBox.Show("メインメニューに戻ります" & vbNewLine & "よろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

			Dim frmNextForm As New frmMainMenu
			m_Context.SetNextContext(frmNextForm)

		End If

	End Sub

	''' <summary>
	''' 案件名コンボボックスインデックス変更時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub cmbName_SelectedIndexChanged(sender As Object, e As EventArgs)

		Dim strSQL As String = ""
		Dim sqlProcess As New SQLProcess
		'MessageBox.Show(Me.cmbName.SelectedIndex)

		Try
			strSQL = "SELECT 登録フォルダ, 備考 FROM M_案件管理 "
			strSQL &= "WHERE 受付ID = '" & Me.cmbName.SelectedValue & "'"
			Dim dt As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
			If dt.Rows.Count > 0 Then
				Me.txtParentFolder.Text = dt.Rows(0)("登録フォルダ")
				Me.txtRemarks.Text = dt.Rows(0)("備考")
			End If
			SearchGrid01()

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & ex.StackTrace)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		Finally

			sqlProcess.Close()

		End Try

	End Sub

	''' <summary>
	''' 案件名コンボボックスフォーカス消失時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub cmbName_Leave(sender As Object, e As EventArgs) Handles cmbName.Leave
		'新規案件名入力後はSelectedIndexを通らないためフォーカス消失時にグリッドの値を初期化する
		Select Case Me.cmbName.SelectedIndex
			Case < 0
				Me.C1FGrid01.Rows.Count = 1
				'ショートカット名に案件名を表示させる
				Me.txtShorcut.Text = Me.cmbName.Text
				Me.txtRemarks.Text = ""
				Me.txtParentFolder.Text = ""
				'未登録の案件はフォルダ指定できるようにする
				Me.txtParentFolder.Enabled = True
			Case 0
				Me.C1FGrid01.Rows.Count = 1
				Me.txtShorcut.Text = ""
				Me.txtRemarks.Text = ""
				Me.txtParentFolder.Text = ""
				Me.txtParentFolder.Enabled = False
			Case Else
				'ショートカット名に案件名を表示させる
				Me.txtShorcut.Text = Me.cmbName.SelectedItem.ToString
				'登録済みの案件はフォルダ指定できないようにする
				Me.txtParentFolder.Enabled = False
		End Select

	End Sub

	''' <summary>
	''' 画像親フォルダドラッグエンター
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub txtParentFolder_DragEnter(sender As Object, e As DragEventArgs) Handles txtParentFolder.DragEnter

		'コントロール内にドラッグされた時実行される
		If e.Data.GetDataPresent(DataFormats.FileDrop) Then
			'ドラッグされたデータ形式を調べ、ファイルの時はコピーとする
			e.Effect = DragDropEffects.Copy
		Else
			'ファイル以外は受け付けない
			e.Effect = DragDropEffects.None
		End If

	End Sub

	''' <summary>
	''' 画像親フォルダドラッグドロップ
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub txtParentFolder_DragDrop(sender As Object, e As DragEventArgs) Handles txtParentFolder.DragDrop

		'コントロール内にドロップされた時実行される
		'ドロップされたファイル名を取得する
		Dim strFolders As String() = CType(e.Data.GetData(DataFormats.FileDrop, False), String())
		'フォルダの存在チェックをしてテキストボックスにセットする
		'フォルダのみ
		If System.IO.Directory.Exists(strFolders(0)) Then

			Me.txtParentFolder.Text = strFolders(0)

		ElseIf System.IO.File.Exists(strFolders(0)) Then
			'ドラッグされたのがファイルだったら上位フォルダをセット
			Me.txtParentFolder.Text = System.IO.Path.GetDirectoryName(strFolders(0))

		End If

	End Sub

	''' <summary>
	''' ロット表示ボタン押下時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub btnLotView_Click(sender As Object, e As EventArgs) Handles btnLotView.Click

		Dim blnNew As Boolean = Nothing

		Select Case Me.cmbName.SelectedIndex
			Case < 0
				'新規
				If MessageBox.Show("ロット(ファイル直下のフォルダ名)を列挙します" & vbNewLine & "よろしいですか？(新規)", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
					Exit Sub
				Else
					blnNew = True
				End If
			Case 0
				'未選択
				MessageBox.Show("案件を選択するか新規案件名を入力してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
				Exit Sub
			Case Else
				'更新
				If MessageBox.Show("ロット(ファイル直下のフォルダ名)を列挙します" & vbNewLine & "よろしいですか？(更新)", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
					Exit Sub
				Else
					blnNew = False
				End If

		End Select

		SearchLot(Me.txtParentFolder.Text, blnNew)

		MessageBox.Show("ロットIDの列挙が完了しました", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information)

	End Sub

	''' <summary>
	''' 登録ボタン押下時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click

		Dim blnNew As Boolean = Nothing

		Select Case Me.cmbName.SelectedIndex
			Case < 0
				'案件も新規
				If MessageBox.Show("案件名を登録した後に、列挙されたロットIDを登録します" & vbNewLine & "よろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
					Exit Sub
				Else
					blnNew = True
				End If

			Case 0
				MessageBox.Show("案件を選択するか新規案件名を入力してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
				Exit Sub
			Case Else
				If MessageBox.Show("列挙された新規ロットIDを登録します" & vbNewLine & "よろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
					Exit Sub
				Else
					blnNew = False
				End If
		End Select

		Dim strSQL As String = ""
		Dim sqlProcess As New SQLProcess

		Try
			Dim strReceiptID As String = ""
			If blnNew Then
				'新規案件
				'案件登録
				strReceiptID = Date.Now.ToString("yyyyMMddHHmmss")
				strSQL = "INSERT INTO M_案件管理(受付ID, 案件名, 登録フォルダ, 登録者, 登録日, 終了日, 備考) VALUES("
				strSQL &= "'" & strReceiptID & "'"
				strSQL &= ", '" & Me.cmbName.Text & "'"
				strSQL &= ", '" & Me.txtParentFolder.Text & "'"
				strSQL &= ", '" & m_LoginUser.UserName & "'"
				strSQL &= ", '" & Date.Now.ToString("yyyy/MM/dd") & "'"
				strSQL &= ", NULL"
				strSQL &= ", '" & Me.txtRemarks.Text & "')"
				sqlProcess.DB_UPDATE(strSQL)
			Else
				'受付IDだけ取得
				strReceiptID = Me.cmbName.SelectedValue
			End If
			'ロットID登録
			'グリッドをループさせて登録状況が「新規」のもののみINSERT
			For iRow As Integer = 1 To Me.C1FGrid01.Rows.Count - 1
				If Me.C1FGrid01(iRow, "登録状況") = "新規" Then
					strSQL = "INSERT INTO T_ロット管理(受付ID, ロットID, フルパス, イメージ数, 入力数, 差替え数, コマ抜け数, 正常数, "
					strSQL &= "最終入力者, 入力中, 進捗状況) VALUES("
					strSQL &= "'" & strReceiptID & "'"
					strSQL &= ", '" & Me.C1FGrid01(iRow, "ロットID") & "'"
					strSQL &= ", '" & Me.C1FGrid01(iRow, "フルパス") & "'"
					strSQL &= ", " & Me.C1FGrid01(iRow, "イメージ数")
					strSQL &= ", 0, 0, 0, 0, '', 0, '開始前')"
					sqlProcess.DB_UPDATE(strSQL)
				End If
			Next

			MessageBox.Show("登録が完了しました" & vbNewLine & "(" & strReceiptID & ")", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information)

			RemoveHandler cmbName.SelectedIndexChanged, AddressOf cmbName_SelectedIndexChanged
			'案件一覧をコンボボックスにセットする
			strSQL = "SELECT 受付ID, 案件名 "
			strSQL &= "FROM M_案件管理 "
			strSQL &= "ORDER BY 受付ID DESC"
			Dim dt As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
			SetComboValue(Me.cmbName, dt, True)
			Me.cmbName.SelectedIndex = 0
			'オートコンプリートモードの設定
			Me.cmbName.AutoCompleteMode = AutoCompleteMode.SuggestAppend
			Me.cmbName.AutoCompleteSource = AutoCompleteSource.ListItems
			'セットし終わってからコンボボックスのイベントを有効にする
			AddHandler cmbName.SelectedIndexChanged, AddressOf cmbName_SelectedIndexChanged
			Me.cmbName.SelectedValue = strReceiptID

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & ex.StackTrace)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		Finally

			sqlProcess.Close()

		End Try

	End Sub

	''' <summary>
	''' ショートカット作成ボタン押下時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub btnCreateShortcut_Click(sender As Object, e As EventArgs) Handles btnCreateShortcut.Click

		If MessageBox.Show("選択されている案件のショートカットをデスクトップに作成します" & vbNewLine & "よろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
			Exit Sub
		End If

		Dim strShortcutPath As String = System.IO.Path.Combine(
			Environment.GetFolderPath(System.Environment.SpecialFolder.DesktopDirectory),
			Me.txtShorcut.Text & ".lnk")
		'ショートカットのリンク先と結びつける引数
		Dim strTargetPath As String = Application.ExecutablePath
		Dim strArgument As String = Me.cmbName.SelectedValue
		'WshShellを作成
		'参照設定のIWshRuntimeLibraryを選択し、IWshRuntimeLibraryのプロパティをプロパティウインドウに表示させる。
		'プロパティの中に「相互運用機能型の埋め込み」という項目があるので、この値をFalseにする。
		Dim shell As New IWshRuntimeLibrary.WshShell()
		'ショートカットパスを指定して、WshShortcutを作成
		Dim shortcut As IWshRuntimeLibrary.IWshShortcut = DirectCast(shell.CreateShortcut(strShortcutPath), IWshRuntimeLibrary.IWshShortcut)
		'リンク先
		shortcut.TargetPath = strTargetPath
		'コマンドパラメータ(リンク先)の後ろにつく
		shortcut.Arguments = strArgument
		'作業フォルダ
		shortcut.WorkingDirectory = Application.StartupPath
		''ショートカットキー(ホットキー)
		'shortcut.Hotkey = "Ctrl+Alt+Shift+F12"
		'実行時の大きさ 1が通常、3が最大化、7が最小化
		shortcut.WindowStyle = 1
		'コメント
		shortcut.Description = Me.txtShorcut.Text
		'アイコンのパス 自分のEXEファイルのインデックス0のアイコン
		shortcut.IconLocation = Application.ExecutablePath + ",0"

		'ショートカットを作成
		shortcut.Save()

		MessageBox.Show("ショートカットを作成しました。", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information)

		'後始末
		System.Runtime.InteropServices.Marshal.ReleaseComObject(shortcut)

	End Sub

	'==================================================
	'CSV出力
	'==================================================

	''' <summary>
	''' 出力フォルダドラッグエンター時
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
	''' 出力フォルダドラッグドロップ時
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
			Else
				'MessageBox.Show("該当のフォルダが存在しません", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
				'Exit Sub
			End If
		End If

	End Sub

	''' <summary>
	''' 出力ボタン押下時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub btnOutput_Click(sender As Object, e As EventArgs) Handles btnOutput.Click

		If Me.cmbSeparater.SelectedIndex < 0 Then
			MessageBox.Show("区切り文字を選択してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Exit Sub
		End If
		If Not System.IO.Directory.Exists(Me.txtOutputFolder.Text) Then
			MessageBox.Show("出力フォルダを指定してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Exit Sub
		End If
		If Me.C1FGrid03.Row < 1 Then
			MessageBox.Show("出力する案件を選択してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Exit Sub
		End If
		Dim iIndex As Integer = Me.C1FGrid03.Row
		Dim strReceiptID As String = Me.C1FGrid03(iIndex, "受付ID") & "：" & Me.C1FGrid03(iIndex, "案件名")
		Dim strItemName As String = IIf(Me.chkItemName.Checked, "項目名：付加する", "項目名：付加しない")
		Dim strIncrement As String = IIf(Me.chkIncrement.Checked, "通し番号：付加する", "通し番号：付加しない")
		Dim strDoubleQuote As String = IIf(Me.chkDoubleQuote.Checked, "ダブルクオート：くくる", "ダブルクオート：くくらない")

		If MessageBox.Show("選択された案件を出力します" & vbNewLine &
						   "よろしいですか？" & vbNewLine & vbNewLine &
						   strReceiptID & vbNewLine &
						   strItemName & vbNewLine &
						   strIncrement & vbNewLine &
						   strDoubleQuote, "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
			Exit Sub
		End If

		'==================================================
		'出力処理
		'==================================================
		Dim strFileName As String = ""
		If Me.cmbSeparater.SelectedIndex = 0 Then
			'カンマ
			strFileName = Me.C1FGrid03(iIndex, "受付ID") & "_" & Me.C1FGrid03(iIndex, "案件名") & "_" & Date.Now.ToString("yyyyMMddHHmmss") & ".csv"
		Else
			'タブ
			strFileName = Me.C1FGrid03(iIndex, "受付ID") & "_" & Me.C1FGrid03(iIndex, "案件名") & "_" & Date.Now.ToString("yyyyMMddHHmmss") & ".txt"
		End If
		Dim strOutputFile As String = Me.txtOutputFolder.Text & "\" & strFileName

		Dim strSQL As String = ""
		Dim sqlProcess As New SQLProcess

		Try

			strSQL = "SELECT ファイル名, 差替え, コマ抜け, 正常 "
			strSQL &= "FROM T_エントリー "
			strSQL &= "WHERE 受付ID = '" & Me.C1FGrid03(iIndex, "受付ID") & "' "
			strSQL &= "ORDER BY ロットID, レコード番号"
			Dim dt As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
			Dim strWriteLine As String = ""

			Using sw As New System.IO.StreamWriter(strOutputFile, False, System.Text.Encoding.GetEncoding("Shift-JIS"))
				'==================================================
				'項目名付与
				'区切り文字
				If Me.cmbSeparater.SelectedIndex = 0 Then
					'カンマ
					If Me.chkItemName.Checked Then
						'する
						'ダブルクオートで括るか
						If Me.chkDoubleQuote.Checked Then
							'くくる
							'連番付与
							If Me.chkIncrement.Checked Then
								'する
								strWriteLine = Chr(34) & "No." & Chr(34) & "," & Chr(34) & "ファイル名" & Chr(34) & "," & Chr(34) & "差替え" & Chr(34) & "," & Chr(34) & "コマ抜け" & Chr(34) & "," & Chr(34) & "正常" & Chr(34)
							Else
								'しない
								strWriteLine = Chr(34) & "ファイル名" & Chr(34) & "," & Chr(34) & "差替え" & Chr(34) & "," & Chr(34) & "コマ抜け" & Chr(34) & "," & Chr(34) & "正常" & Chr(34)
							End If
						Else
							'くくらない
							'連番付与
							If Me.chkIncrement.Checked Then
								'する
								strWriteLine = "No.,ファイル名,差替え,コマ抜け,正常"
							Else
								'しない
								strWriteLine = "ファイル名,差替え,コマ抜け,正常"
							End If
						End If
					End If

				Else
					'タブ
					If Me.chkItemName.Checked Then
						'する
						'ダブルクオートで括るか
						If Me.chkDoubleQuote.Checked Then
							'くくる
							'連番付与
							If Me.chkIncrement.Checked Then
								'する
								strWriteLine = Chr(34) & "No." & Chr(34) & vbTab & Chr(34) & "ファイル名" & Chr(34) & vbTab & Chr(34) & "差替え" & Chr(34) & vbTab & Chr(34) & "コマ抜け" & Chr(34) & vbTab & Chr(34) & "正常" & Chr(34)
							Else
								'しない
								strWriteLine = Chr(34) & "No." & Chr(34) & vbTab & "ファイル名" & Chr(34) & vbTab & "差替え" & Chr(34) & vbTab & "コマ抜け" & Chr(34) & vbTab & "正常" & Chr(34)
							End If
						Else
							'くくらない
							'連番付与
							If Me.chkIncrement.Checked Then
								'する
								strWriteLine = "No." & vbTab & "ファイル名" & vbTab & "差替え" & vbTab & "コマ抜け" & vbTab & "正常"
							Else
								'しない
								strWriteLine = "ファイル名" & vbTab & "差替え" & vbTab & "コマ抜け" & vbTab & "正常"
							End If
						End If
					End If

				End If
				sw.WriteLine(strWriteLine)
				'==================================================

				For iRow As Integer = 0 To dt.Rows.Count - 1

					'区切り文字
					If Me.cmbSeparater.SelectedIndex = 0 Then
						'カンマ
						'ダブルクオートで括るか
						If Me.chkDoubleQuote.Checked Then
							'くくる
							'連番付与
							If Me.chkIncrement.Checked Then
								'する
								strWriteLine = Chr(34) & iRow + 1 & Chr(34)
								strWriteLine &= "," & Chr(34) & dt.Rows(iRow)("ファイル名") & Chr(34)
								strWriteLine &= "," & Chr(34) & dt.Rows(iRow)("差替え") & Chr(34)
								strWriteLine &= "," & Chr(34) & dt.Rows(iRow)("コマ抜け") & Chr(34)
								strWriteLine &= "," & Chr(34) & dt.Rows(iRow)("正常") & Chr(34)
							Else
								'しない
								strWriteLine = Chr(34) & dt.Rows(iRow)("ファイル名") & Chr(34)
								strWriteLine &= "," & Chr(34) & dt.Rows(iRow)("差替え") & Chr(34)
								strWriteLine &= "," & Chr(34) & dt.Rows(iRow)("コマ抜け") & Chr(34)
								strWriteLine &= "," & Chr(34) & dt.Rows(iRow)("正常") & Chr(34)
							End If
						Else
							'くくらない
							'連番付与
							If Me.chkIncrement.Checked Then
								'する
								strWriteLine = iRow + 1
								strWriteLine &= "," & dt.Rows(iRow)("ファイル名")
								strWriteLine &= "," & dt.Rows(iRow)("差替え")
								strWriteLine &= "," & dt.Rows(iRow)("コマ抜け")
								strWriteLine &= "," & dt.Rows(iRow)("正常")
							Else
								'しない
								strWriteLine &= "," & dt.Rows(iRow)("ファイル名")
								strWriteLine &= "," & dt.Rows(iRow)("差替え")
								strWriteLine &= "," & dt.Rows(iRow)("コマ抜け")
								strWriteLine &= "," & dt.Rows(iRow)("正常")
							End If
						End If
					Else
						'タブ
						'ダブルクオートで括るか
						If Me.chkDoubleQuote.Checked Then
							'くくる
							'連番付与
							If Me.chkIncrement.Checked Then
								'する
								strWriteLine = Chr(34) & iRow + 1 & Chr(34)
								strWriteLine &= vbTab & Chr(34) & dt.Rows(iRow)("ファイル名") & Chr(34)
								strWriteLine &= vbTab & Chr(34) & dt.Rows(iRow)("差替え") & Chr(34)
								strWriteLine &= vbTab & Chr(34) & dt.Rows(iRow)("コマ抜け") & Chr(34)
								strWriteLine &= vbTab & Chr(34) & dt.Rows(iRow)("正常") & Chr(34)
							Else
								'しない
								strWriteLine &= vbTab & Chr(34) & dt.Rows(iRow)("ファイル名") & Chr(34)
								strWriteLine &= vbTab & Chr(34) & dt.Rows(iRow)("差替え") & Chr(34)
								strWriteLine &= vbTab & Chr(34) & dt.Rows(iRow)("コマ抜け") & Chr(34)
								strWriteLine &= vbTab & Chr(34) & dt.Rows(iRow)("正常") & Chr(34)
							End If
						Else
							'くくらない
							'連番付与
							If Me.chkIncrement.Checked Then
								'する
								strWriteLine = iRow + 1
								strWriteLine &= vbTab & dt.Rows(iRow)("ファイル名")
								strWriteLine &= vbTab & dt.Rows(iRow)("差替え")
								strWriteLine &= vbTab & dt.Rows(iRow)("コマ抜け")
								strWriteLine &= vbTab & dt.Rows(iRow)("正常")
							Else
								'しない
								strWriteLine &= vbTab & dt.Rows(iRow)("ファイル名")
								strWriteLine &= vbTab & dt.Rows(iRow)("差替え")
								strWriteLine &= vbTab & dt.Rows(iRow)("コマ抜け")
								strWriteLine &= vbTab & dt.Rows(iRow)("正常")
							End If
						End If
					End If
					sw.WriteLine(strWriteLine)

				Next

			End Using
			'出力後に終了日をセットする
			strSQL = "UPDATE M_案件管理 SET 終了日 = '" & Date.Now.ToString("yyyy/MM/dd") & "' "
			strSQL &= "WHERE 受付ID = '" & Me.C1FGrid03(iIndex, "受付ID") & "'"
			sqlProcess.DB_UPDATE(strSQL)

			MessageBox.Show("出力処理が完了しました", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information)
			SearchGrid03()

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & ex.StackTrace)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		Finally

			SQLProcess.Close()

		End Try


	End Sub

	''' <summary>
	''' 解除ボタン押下時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub btnUnlock_Click(sender As Object, e As EventArgs) Handles btnUnlock.Click

		Dim strSQL As String = ""
		Dim sqlProcess As New SQLProcess

		Try
			If Me.C1FGrid02.Row <= 0 Then
				MessageBox.Show("ログイン状態を解除するレコードを選択してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
				Exit Sub
			End If

			If MessageBox.Show("選択しているログインレコードを解除します" & vbNewLine & "よろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
				Exit Sub
			End If

			Dim iIndex As Integer = Me.C1FGrid02.Row

			strSQL = "UPDATE T_ロット管理 SET 入力中 = 0 "
			strSQL &= "WHERE 受付ID = '" & Me.C1FGrid02(iIndex, "受付ID") & "' "
			strSQL &= "AND ロットID = '" & Me.C1FGrid02(iIndex, "ロットID") & "'"
			sqlProcess.DB_UPDATE(strSQL)

			SearchGrid02()

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
	''' グリッドにロット情報を表示する
	''' </summary>
	''' <param name="strParentFolder"></param>
	''' <param name="blnNew"></param>
	Private Sub SearchLot(ByVal strParentFolder As String, ByVal blnNew As Boolean)

		If Not blnNew Then
			'更新のみ登録済みロットを表示する
			SearchGrid01()
		End If

		'対象親フォルダを走査してグリッドにセットする
		'更新の場合、すでに登録されているロットであった場合は登録対象としない
		Dim strPatterns As String() = {"*.jpg", "*. tif", "*.pdf"}
		Dim strFiles As String() = GetFilesMostDeep(strParentFolder, strPatterns)
		Dim iNo As Integer = 0
		If Me.C1FGrid01.Rows.Count = 1 Then
			'1レコードも存在しなかったら
			iNo += 1
		Else
			iNo = Me.C1FGrid01(Me.C1FGrid01.Rows.Count - 1, "No")
		End If

		For Each strFile In strFiles
			'ファイルのフルパスから直下フォルダ名を取得する
			Dim strFullPath As String = System.IO.Path.GetDirectoryName(strFile)
			Dim strLotID As String = System.IO.Path.GetFileName(strFullPath)
			'まずグリッドをループさせてロットID、フルパスが合致するものがないかチェック
			Dim blnRecExist As Boolean = False
			For i As Integer = 1 To Me.C1FGrid01.Rows.Count - 1
				If Me.C1FGrid01(i, "ロットID") = strLotID And Me.C1FGrid01(i, "フルパス") = strFullPath Then
					blnRecExist = True
					Continue For
				End If
			Next

			If blnRecExist Then
				'ロットID、フルパスが合致するレコードが存在していたら
				'このレコードはスルー
				Continue For
			End If
			'該当のフルパスをロットIDがグリッドに存在するか確認
			Dim iIndex As Integer = Me.C1FGrid01.FindRow(strLotID, 1, 1, False, True, False)
			If iIndex > 0 Then
				'ヒットした
				'フルパスもヒットしていたらスルー
				If Not Me.C1FGrid01(iIndex, "フルパス") = strFullPath Then
					'フルパスがヒットしなかったら「対象外」として表示させる
					Me.C1FGrid01.Rows.Count += 1
					iNo += 1
					Dim iRow As Integer = Me.C1FGrid01.Rows.Count - 1   '登録するインデックス
					Me.C1FGrid01(iRow, "No") = iNo
					Me.C1FGrid01(iRow, "ロットID") = strLotID
					Me.C1FGrid01(iRow, "登録状況") = "対象外"
					Dim strFilesChild As String() = GetFilesMostDeep(System.IO.Path.GetDirectoryName(strFile), strPatterns)
					Me.C1FGrid01(iRow, "イメージ数") = strFilesChild.Count
					Me.C1FGrid01(iRow, "フルパス") = System.IO.Path.GetDirectoryName(strFile)
				End If
			Else
				'ヒットしなかったら新規レコード
				Me.C1FGrid01.Rows.Count += 1
				iNo += 1
				Dim iRow As Integer = Me.C1FGrid01.Rows.Count - 1   '登録するインデックス
				Me.C1FGrid01(iRow, "No") = iNo
				Me.C1FGrid01(iRow, "ロットID") = strLotID
				Me.C1FGrid01(iRow, "登録状況") = "新規"
				Dim strFilesChild As String() = GetFilesMostDeep(System.IO.Path.GetDirectoryName(strFile), strPatterns)
				Me.C1FGrid01(iRow, "イメージ数") = strFilesChild.Count
				Me.C1FGrid01(iRow, "フルパス") = System.IO.Path.GetDirectoryName(strFile)

			End If
		Next

		ChangeBackColor()

	End Sub

	''' <summary>
	''' 初期化処理
	''' </summary>
	Private Sub Initialize()

		Me.lblUser.Text = m_LoginUser.UserName
		Me.lblManage.Text = IIf(m_LoginUser.ManageFlag = True, "管理者", "入力者")

		Dim strSQL As String = ""
		Dim sqlProcess As New SQLProcess

		Try
			'案件一覧をコンボボックスにセットする
			strSQL = "SELECT 受付ID, 案件名 "
			strSQL &= "FROM M_案件管理 "
			strSQL &= "ORDER BY 受付ID DESC"
			Dim dt As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
			SetComboValue(Me.cmbName, dt, True)
			Me.cmbName.SelectedIndex = 0
			'オートコンプリートモードの設定
			Me.cmbName.AutoCompleteMode = AutoCompleteMode.SuggestAppend
			Me.cmbName.AutoCompleteSource = AutoCompleteSource.ListItems

			SearchGrid02()
			SearchGrid03()
			Me.cmbSeparater.SelectedIndex = 0

			'セットし終わってからコンボボックスのイベントを有効にする
			AddHandler cmbName.SelectedIndexChanged, AddressOf cmbName_SelectedIndexChanged

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & ex.StackTrace)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		Finally

			sqlProcess.Close()

		End Try

	End Sub

	''' <summary>
	''' 案件登録・編集グリッド
	''' </summary>
	Private Sub SearchGrid01()

		Dim strSQL As String = ""
		Dim sqlProcess As New SQLProcess

		Try
			strSQL = "SELECT 受付ID, ロットID, '登録済' AS 登録状況, フルパス "
			strSQL &= "FROM T_ロット管理 "
			strSQL &= "WHERE 受付ID = '" & Me.cmbName.SelectedValue & "' "
			strSQL &= "ORDER BY ロットID"
			Dim dt As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
			Me.C1FGrid01.Rows.Count = 1
			Dim iRecCount As Integer = 0
			'値参照用変数
			Dim iImage As Integer = 0

			For iRow As Integer = 0 To dt.Rows.Count - 1
				'カウント
				CountItems(dt.Rows(iRow)("受付ID"), dt.Rows(iRow)("ロットID"), dt.Rows(iRow)("フルパス"), iImage)
				iRecCount += 1
				Me.C1FGrid01.Rows.Count += 1
				Me.C1FGrid01(iRecCount, "No") = iRecCount
				Me.C1FGrid01(iRecCount, "ロットID") = dt.Rows(iRow)("ロットID")
				Me.C1FGrid01(iRecCount, "登録状況") = dt.Rows(iRow)("登録状況")
				Me.C1FGrid01(iRecCount, "イメージ数") = iImage
				Me.C1FGrid01(iRecCount, "フルパス") = dt.Rows(iRow)("フルパス")

			Next
			Me.C1FGrid01.Row = -1
			ChangeBackColor()

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & ex.StackTrace)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		Finally

			sqlProcess.Close()

		End Try

	End Sub

	''' <summary>
	''' ログイン状況グリッド
	''' </summary>
	Private Sub SearchGrid02()

		Dim strSQL As String = ""
		Dim sqlProcess As New SQLProcess

		Try
			strSQL = "SELECT T1.受付ID, T2.案件名, T1.ロットID, T1.最終入力者 AS 入力者, T1.フルパス "
			strSQL &= "FROM T_ロット管理 AS T1 INNER JOIN "
			strSQL &= "M_案件管理 AS T2 ON T1.受付ID = T2.受付ID "
			strSQL &= "WHERE T1.入力中 = 1 "
			strSQL &= "ORDER BY T1.受付ID DESC, T1.ロットID"
			Dim dt As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
			Dim iRecCount As Integer = 0

			For iRow As Integer = 0 To dt.Rows.Count - 1
				iRecCount += 1
				Me.C1FGrid02.Rows.Count = iRecCount + 1
				Me.C1FGrid02(iRecCount, "No") = iRecCount
				Me.C1FGrid02(iRecCount, "受付ID") = dt.Rows(iRow)("受付ID")
				Me.C1FGrid02(iRecCount, "案件名") = dt.Rows(iRow)("案件名")
				Me.C1FGrid02(iRecCount, "ロットID") = dt.Rows(iRow)("ロットID")
				Me.C1FGrid02(iRecCount, "入力者") = dt.Rows(iRow)("入力者")
				Me.C1FGrid02(iRecCount, "フルパス") = dt.Rows(iRow)("フルパス")
			Next

			Me.C1FGrid02.Row = -1

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & ex.StackTrace)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		Finally

			sqlProcess.Close()

		End Try

	End Sub

	''' <summary>
	''' CSV出力グリッド
	''' </summary>
	Private Sub SearchGrid03()

		Dim strSQL As String = ""
		Dim sqlProcess As New SQLProcess

		Try
			strSQL = "SELECT 受付ID, 案件名, 登録フォルダ, 登録者, 登録日, ISNULL(終了日, '1900/01/01') AS 終了日, 備考 "
			strSQL &= "FROM M_案件管理 "
			strSQL &= "ORDER BY 受付ID DESC"
			Dim dt As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
			Dim iRecCount As Integer = 0

			For iRow As Integer = 0 To dt.Rows.Count - 1
				iRecCount += 1
				Me.C1FGrid03.Rows.Count = iRecCount + 1
				Me.C1FGrid03(iRecCount, "No") = iRecCount
				Me.C1FGrid03(iRecCount, "受付ID") = dt.Rows(iRow)("受付ID")
				Me.C1FGrid03(iRecCount, "案件名") = dt.Rows(iRow)("案件名")
				Me.C1FGrid03(iRecCount, "登録フォルダ") = dt.Rows(iRow)("登録フォルダ")
				Me.C1FGrid03(iRecCount, "登録者") = dt.Rows(iRow)("登録者")
				Me.C1FGrid03(iRecCount, "登録日") = CDate(dt.Rows(iRow)("登録日")).ToString("yyyy/MM/dd")
				Me.C1FGrid03(iRecCount, "終了日") = IIf(dt.Rows(iRow)("終了日") = "1900/01/01", "", CDate(dt.Rows(iRow)("終了日")).ToString("yyyy/MM/dd"))
				Me.C1FGrid03(iRecCount, "備考") = dt.Rows(iRow)("備考")
			Next

			Me.C1FGrid03.Row = -1
			ChangeBackColor03()

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & ex.StackTrace)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		Finally

			sqlProcess.Close()

		End Try

	End Sub

	''' <summary>
	''' イメージ数をカウントする
	''' </summary>
	''' <param name="strReceiptID"></param>
	''' <param name="strLotID"></param>
	''' <param name="strFullPath"></param>
	''' <param name="iImage"></param>
	Private Sub CountItems(ByVal strReceiptID As String, ByVal strLotID As String, ByVal strFullPath As String,
						   ByRef iImage As Integer)

		Dim strPatterns As String() = {"*.jpg", "*.tif", "*.pdf"}
		Dim strFiles As String() = GetFilesMostDeep(strFullPath, strPatterns)
		iImage = strFiles.Count

	End Sub

	''' <summary>
	''' グリッド内の登録状況によって背景色を変更する
	''' </summary>
	Private Sub ChangeBackColor()

		'カスタムスタイルを作成する
		With Me.C1FGrid01
			'登録済み
			.Styles.Add("StyleRegist")
			.Styles("StyleRegist").BackColor = Color.LightSkyBlue
			.Styles("StyleRegist").ForeColor = Color.Black
			'新規
			.Styles.Add("StyleNew")
			.Styles("StyleNew").BackColor = Color.LightCoral
			.Styles("StyleNew").ForeColor = Color.Black
			'対象外
			.Styles.Add("StyleNotCover")
			.Styles("StyleNotCover").BackColor = Color.LightSlateGray
			.Styles("StyleNotCover").ForeColor = Color.White
		End With

		Me.C1FGrid01.BeginUpdate()

		For iRow As Integer = 1 To Me.C1FGrid01.Rows.Count - 1

			Select Case Me.C1FGrid01(iRow, "登録状況")
				Case "登録済"
					Me.C1FGrid01.Rows(iRow).Style = Me.C1FGrid01.Styles("StyleRegist")
				Case "新規"
					Me.C1FGrid01.Rows(iRow).Style = Me.C1FGrid01.Styles("StyleNew")
				Case "対象外"
					Me.C1FGrid01.Rows(iRow).Style = Me.C1FGrid01.Styles("StyleNotCover")
			End Select
		Next

		Me.C1FGrid01.EndUpdate()

	End Sub

	Private Sub ChangeBackColor03()

		'カスタムスタイルを作成する
		With Me.C1FGrid03
			'出力可能
			.Styles.Add("StyleNormal")
			.Styles("StyleNormal").BackColor = Color.White
			.Styles("StyleNormal").ForeColor = Color.Black
			'終了日あり
			.Styles.Add("StyleFinish")
			.Styles("StyleFinish").BackColor = Color.LightSlateGray
			.Styles("StyleFinish").ForeColor = Color.White
		End With

		Me.C1FGrid03.BeginUpdate()

		For iRow As Integer = 1 To Me.C1FGrid03.Rows.Count - 1

			Select Case Me.C1FGrid03(iRow, "終了日")
				Case ""
					Me.C1FGrid03.Rows(iRow).Style = Me.C1FGrid03.Styles("StyleNormal")
				Case Else
					Me.C1FGrid03.Rows(iRow).Style = Me.C1FGrid03.Styles("StyleFinish")
			End Select
		Next

		Me.C1FGrid03.EndUpdate()

	End Sub

#End Region

End Class