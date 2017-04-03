Imports Leadtools
Imports Leadtools.Codecs
Imports Leadtools.WinForms
Imports Leadtools.Drawing
Imports Leadtools.ImageProcessing

Public Class frmMain

#Region "プライベート変数"

	Private m_BackFormID As String = "frmLogin"
	'グリッドを点滅させるためのタイマーフラグ
	Private blnTimer As Boolean = True
	'点滅させる行を保持
	Private iFlashRow As Integer = 0
	'画像をロードするためのRasterCodecsオブジェクト
	Private codecs As RasterCodecs

	'Rasterイメージプロパティ構造体
	Private Structure ImageProperty
		Private _sngZoom As Single    '拡大率
		Private _idegrees As Integer  '角度
		Private _Angle As Integer     '角度×100
		Private _Flags As RotateCommandFlags  'Rotateコマンド内容
		Private _FillColor As RasterColor '余白塗りつぶし色
		Private _CurrentPage As Integer '現在のページ
		Private _TotalPages As Integer   '総ページ数

		''' <summary>
		''' 画像の祝率を取得及び、設定をする
		''' </summary>
		''' <value></value>
		''' <returns></returns>
		''' <remarks></remarks>
		Public Property sngZoom() As Single
			Get
				Return _sngZoom
			End Get
			Set(value As Single)
				_sngZoom = value
			End Set
		End Property

		''' <summary>
		''' 画像の回転角度を取得及び、設定をする
		''' </summary>
		''' <value></value>
		''' <returns></returns>
		''' <remarks></remarks>
		Public Property Degrees() As Integer
			Get
				Return _idegrees
			End Get
			Set(value As Integer)
				_idegrees = value
			End Set
		End Property

		''' <summary>
		''' 角度×100を取得及び、設定をする
		''' </summary>
		''' <value></value>
		''' <returns></returns>
		''' <remarks></remarks>
		Public Property Angle() As Integer
			Get
				Return _Angle
			End Get
			Set(value As Integer)
				_Angle = value
			End Set
		End Property

		''' <summary>
		''' Rotateコマンド内容を取得及び、設定をする
		''' </summary>
		''' <value></value>
		''' <returns></returns>
		''' <remarks></remarks>
		Public Property Flags() As RotateCommandFlags
			Get
				Return _Flags
			End Get
			Set(value As RotateCommandFlags)
				_Flags = value
			End Set
		End Property

		''' <summary>
		''' 余白塗りつぶし色を取得及び、設定をする
		''' </summary>
		''' <value></value>
		''' <returns></returns>
		''' <remarks></remarks>
		Public Property FillColor() As RasterColor
			Get
				Return _FillColor
			End Get
			Set(value As RasterColor)
				_FillColor = value
			End Set
		End Property

		''' <summary>
		''' 現在のページを取得及び、設定をする
		''' </summary>
		''' <value></value>
		''' <returns></returns>
		''' <remarks></remarks>
		Public Property CurrentPage() As Integer
			Get
				Return _CurrentPage
			End Get
			Set(value As Integer)
				_CurrentPage = value
			End Set
		End Property

		''' <summary>
		''' 総ページ数を取得及び、設定をする
		''' </summary>
		''' <value></value>
		''' <returns></returns>
		''' <remarks></remarks>
		Public Property TotalPages() As Integer
			Get
				Return _TotalPages
			End Get
			Set(value As Integer)
				_TotalPages = value
			End Set
		End Property

	End Structure

	''' <summary>
	''' スタイル列挙体
	''' </summary>
	''' <remarks></remarks>
	Friend Enum GridStyleName
		StyleDefault
		StyleTarget
		StyleLink
	End Enum

	''' <summary>
	''' ページ移動列挙体
	''' </summary>
	''' <remarks></remarks>
	Friend Enum enumPageMove
		MoveTop
		MovePrev
		MoveNext
		MoveBottom
	End Enum

	'Rotate用変数
	Private Shared _initialAngle As Integer = 0
	Private Shared _initialFlags As RotateCommandFlags = RotateCommandFlags.None
	Private Shared _initialFillColor As RasterColor = New RasterColor(0, 0, 0)

	'構造体を作成
	Private ip As ImageProperty

	'1次処理か2次処理かを保持する
	Private _iLinkProcess As Integer

	''' <summary>
	''' 処理内容
	''' </summary>
	''' <returns></returns>
	Public Property LinkProcess() As Integer
		Get
			Return _iLinkProcess
		End Get
		Set(value As Integer)
			_iLinkProcess = value
			'リンク処理の回次をラベルに表示する
			Select Case value
				Case 1
					Me.lblLinkProcess.Text = "1次"
					Me.lblLinkProcess.BackColor = Color.DeepSkyBlue
				Case 2
					Me.lblLinkProcess.Text = "2次"
					Me.lblLinkProcess.BackColor = Color.LightCoral
				Case Else
					Me.lblLinkProcess.Text = ""
					Me.lblLinkProcess.BackColor = SystemColors.Control
			End Select
		End Set
	End Property

#End Region

#Region "フォームイベント"

	''' <summary>
	''' フォームロード時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load

		Me.Text = My.Application.Info.ProductName & " Ver." &
			My.Application.Info.Version.ToString
		Me.KeyPreview = True    'キー入力を受け付ける

		Initialize()
		ClearValue()

	End Sub

	''' <summary>
	''' フォームキーダウンイベント
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	''' <remarks>C1FGridResultのキーダウンイベントも同様の動作とする</remarks>
	Private Sub frmMain_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown, C1FGridResult.KeyDown

		Try
			'どの修飾キー(Shift、Ctrl、Alt)が押されているか
			If (Control.ModifierKeys And Keys.Shift) = Keys.Shift Then
				'Shiftキー

			ElseIf (Control.ModifierKeys And Keys.Control) = Keys.Control Then
				'Ctrlキー
				Select Case e.KeyCode

					Case Keys.F

						Me.rivImage.ScaleFactor = 1.0F
						Me.rivImage.SizeMode = RasterPaintSizeMode.Fit

					Case Keys.Add
						'拡大
						Me.rivImage.ScaleFactor *= 1.2F

					Case Keys.Subtract
						'縮小
						Me.rivImage.ScaleFactor *= 0.8F

				End Select

			ElseIf (Control.ModifierKeys And Keys.Alt) = Keys.Alt Then
				'Alt

			Else

				Select Case e.KeyCode

					Case Keys.Enter
						'項目移動 Enterキー
						'ボタン上では無効
						If TypeOf Me.ActiveControl Is Button Then
							Exit Select
						End If

						Dim forward As Boolean = e.Modifiers <> Keys.Shift
						Me.SelectNextControl(Me.ActiveControl, forward, True, True, True)

						e.Handled = True

					Case Keys.Home
						'先頭画像へ
						MoveImageTop()
						e.Handled = True

					Case Keys.PageUp
						'前画像へ
						MoveImagePrev()
						e.Handled = True

					Case Keys.PageDown
						'次画像へ
						MoveImageNext()
						e.Handled = True

					Case Keys.End
						'末尾画像へ
						MoveImageBottom()
						e.Handled = True

				End Select

			End If

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		End Try

	End Sub

#End Region

#Region "オブジェクトイベント"

	''' <summary>
	''' 戻るボタン押下時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	''' <remarks></remarks>
	Private Sub btnBack_Click(sender As System.Object, e As System.EventArgs) Handles btnBack.Click

		If MessageBox.Show("アプリケーションを終了します" & vbNewLine & "よろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
			Exit Sub
		End If

		Dim strSQL As String = ""
		Dim sqlProcess As New SQLProcess

		Try
			Dim strHostName As String = My.Computer.Name
			strSQL = "UPDATE M_冊子 SET 処理端末 = '' "
			strSQL &= "WHERE 処理端末 = '" & strHostName & "'"
			sqlProcess.DB_UPDATE(strSQL)

			'If m_BackFormID = "frmMainMenu" Then

			'	Dim frmNextForm As New frmMainMenu
			'	m_Context.SetNextContext(frmNextForm)
			'Else
			'	'他のフォームへ戻る場合個々に記述

			'End If
			XmlSettings.LoadFromXmlFile()
			XmlSettings.SaveToXmlFile()

			Me.Close()

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		Finally

			sqlProcess.Close()

		End Try

	End Sub

	''' <summary>
	''' 開始ボタン押下時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	''' <remarks></remarks>
	Private Sub btnStart_Click(sender As System.Object, e As System.EventArgs) Handles btnStart.Click

		If Me.cmbBookletID.SelectedIndex < 0 Then
			MessageBox.Show("冊子IDを選択してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Exit Sub
		End If

		Dim strSQL As String = ""
		Dim sqlProcess As New SQLProcess

		Try
			Dim strBookletID As String = Me.cmbBookletID.SelectedValue
			'該当冊子IDが他端末で運用されていないかチェックする
			strSQL = "SELECT 処理端末 FROM M_冊子 "
			strSQL &= "WHERE ID = '" & strBookletID & "'"
			Dim strProcessPC As String = sqlProcess.DB_EXECUTE_SCALAR(strSQL)
			If Not IsNull(strProcessPC) And Not strProcessPC = My.Computer.Name Then
				'端末名がNULLでない、もしくは端末名が自身の端末でなかった場合処理ができないようにする
				MessageBox.Show("該当冊子IDは他の端末で処理中です。" & vbNewLine & "処理端末：" & strProcessPC, "確認", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Exit Sub
			End If

			'参照フォルダ、冊子IDで冊子フォルダを特定して該当のファイル名をファイルリストに列挙する
			strSQL = "SELECT ID FROM M_冊子 "
			strSQL &= "WHERE ID = '" & strBookletID & "'"
			Dim dt As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
			If dt.Rows.Count = 0 Then
				MessageBox.Show("該当の冊子IDが存在しません", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
				Exit Sub
			End If

			'パスを作成する
			XmlSettings.LoadFromXmlFile()
			Dim strTargetPath As String = XmlSettings.Instance.ImagePath & "\" & dt.Rows(0)("ID")
			'パスの存在確認
			If Not System.IO.Directory.Exists(strTargetPath) Then
				MessageBox.Show("画像ファイル参照フォルダが存在しません" & vbNewLine & "参照フォルダを確認してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
				Exit Sub
			End If

			'Dim strCheck As String = Me.cmbBibliography.SelectedItem.ToString
			If Strings.Left(Me.cmbBookletID.SelectedItem.ToString, 2) = "■■" Then

				Dim result As DialogResult = vbCancel
				result = MessageBox.Show("既に終了している冊子IDです。該当するボタンを押下してください" & vbNewLine & "※1次リンク付け処理→「はい」" & vbNewLine & "※2次リンク付け処理→「いいえ」" & vbNewLine & "※処理を行わない→「キャンセル」", "確認", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3)
				Select Case result
					Case vbYes
						'1次
						LinkProcess = 1
						'一度終了したら中断させないようにする（終了日が消えてしまうため）
						'終了ボタンのみ使用可能に
						Me.btnFinish.Enabled = True
						Me.btnAbort.Enabled = False
					Case vbNo
						'2次
						LinkProcess = 2
						'一度終了したら中断させないようにする（終了日が消えてしまうため）
						'終了ボタンのみ使用可能に
						Me.btnFinish.Enabled = True
						Me.btnAbort.Enabled = False
					Case vbCancel
						'キャンセル
						LinkProcess = 0
						Exit Sub
				End Select
			ElseIf Strings.Left(Me.cmbBookletID.SelectedItem.ToString, 2) = "■□" Then
				'2次処理確定
				LinkProcess = 2
				'If MessageBox.Show("既に終了している冊子IDです" & vbNewLine & "再度処理を行いますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
				'	Exit Sub
				'End If
				'終了ボタン、中断ボタンを使用可能に
				Me.btnFinish.Enabled = True
				Me.btnAbort.Enabled = True
			Else
				'1次処理確定
				LinkProcess = 1
				'終了ボタン、中断ボタンを使用可能に
				Me.btnFinish.Enabled = True
				Me.btnAbort.Enabled = True

			End If

			'開始日時、処理端末の保存
			strSQL = "UPDATE M_冊子 SET 開始日時 = '" & Date.Now.ToString("yyyy/MM/dd HH:mm:ss") & "', "
			strSQL &= "処理端末 = N'" & My.Computer.Name & "' "
			strSQL &= "WHERE ID = '" & Me.cmbBookletID.SelectedValue & "'"
			'Console.WriteLine(strSQL)
			sqlProcess.DB_UPDATE(strSQL)

			SearchGrid()

			Me.C1FGridResult.Focus()
			Me.btnStart.Enabled = False

			'冊子IDコンボボックスを使用不可にする
			Me.cmbBookletID.Enabled = False

			Me.C1FGridMokuji.Enabled = True

			Me.rivImage.Visible = True

			'冊子名欄に「冊子名」「巻号」「Vol.」「No.」を表示する
			strSQL = "SELECT 冊子名 + ' ' + 年号 + ' ' + Vol + ' ' + No AS 冊子名 FROM M_冊子 "
			strSQL &= "WHERE ID = '" & Me.cmbBookletID.SelectedValue & "'"
			Dim strBookletName As String = sqlProcess.DB_EXECUTE_SCALAR(strSQL)
			Me.txtBookletName.Text = strBookletName

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		Finally

			sqlProcess.Close()

		End Try


	End Sub

	''' <summary>
	''' 中断ボタン押下時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub btnAbort_Click(sender As Object, e As EventArgs) Handles btnAbort.Click

		If MessageBox.Show("該当冊子IDのリンク付け処理を中断します" & vbNewLine & "よろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
			Exit Sub
		End If

		Dim strSQL As String = ""
		Dim sqlProcess As New SQLProcess

		Try
			'目次データの書き込み
			If RegistData() Then
				'目次データ書き込み成功
				'終了日を取り下げる
				'2017/03/22
				'1次の場合は「終了日時」、2時の場合は「終了日時2次」
				If LinkProcess = 1 Then
					strSQL = "UPDATE M_冊子 SET 終了日時 = NULL "
					strSQL &= "WHERE ID = '" & Me.cmbBookletID.SelectedValue & "'"
				ElseIf LinkProcess = 2 Then
					strSQL = "UPDATE M_冊子 SET 終了日時2次 = NULL "
					strSQL &= "WHERE ID = '" & Me.cmbBookletID.SelectedValue & "'"
				End If
				sqlProcess.DB_UPDATE(strSQL)

				EnumBookletID() '冊子IDの再列挙、再選択
				ClearValue()

			Else
				'目次データ書き込み失敗
				MessageBox.Show("データベースへの書き込みに失敗しました" & vbNewLine & "システム管理者に問い合わせてください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
				Exit Sub

			End If

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		Finally

			sqlProcess.Close()

		End Try

	End Sub

	''' <summary>
	''' FlexGrid EnterCell時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	''' <remarks></remarks>
	Private Sub C1FGridResult_EnterCell(sender As System.Object, e As System.EventArgs)

		Try

			Dim iIndex As Integer = Me.C1FGridResult.Row
			If iIndex < 1 Then
				Exit Sub
			End If

			SelectImage(iIndex)

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		End Try

	End Sub

	''' <summary>
	''' RasterImageViewerダブルクリック時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	''' <remarks></remarks>
	Private Sub rivImage_DoubleClick(sender As System.Object, e As System.EventArgs) Handles rivImage.DoubleClick

		Me.rivImage.ScaleFactor = 1.0F
		Me.rivImage.SizeMode = RasterPaintSizeMode.Fit

	End Sub

	''' <summary>
	''' 終了ボタン押下時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	''' <remarks></remarks>
	Private Sub btnFinish_Click(sender As System.Object, e As System.EventArgs) Handles btnFinish.Click

		'リンクが全てのレコードに貼られているかチェック
		'リンクチェックは1次処理のみ
		If LinkProcess = 1 Then

			Dim blnNoLink As Boolean = False
			'リンクの貼られていない目次タイトルを列挙する
			Dim strMokujiTitle As String = vbNewLine
			For iRow As Integer = 1 To Me.C1FGridMokuji.Rows.Count - 1
				If IsNull(Me.C1FGridMokuji(iRow, "リンク")) Then
					'リンク項目に値がない場合はフラグを立てて最終行まで検査する
					strMokujiTitle &= Me.C1FGridMokuji(iRow, "目次タイトル") & vbNewLine
					blnNoLink = True
				End If
			Next
			If blnNoLink Then
				'リンクの貼られていないレコードが存在した
				MessageBox.Show("リンクの貼られていない目次タイトルが存在します" & vbNewLine & "再度リンクを確認してください" & vbNewLine & strMokujiTitle, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning)
				If MessageBox.Show("リンクを貼らなくても良い場合は「はい」を押下してください", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = DialogResult.No Then
					Exit Sub
				End If

			End If

		End If

		If MessageBox.Show("該当冊子IDのリンク付け処理を終了します" & vbNewLine & "よろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
			Exit Sub
		End If

		Dim strSQL As String = ""
		Dim sqlProcess As New SQLProcess

		Try
			'目次データの書き込み
			If RegistData() Then
				'目次データ書き込み成功
				'冊子マスタの終了日を更新
				'1次処理「終了日時」、2次処理「終了日時2次」
				If LinkProcess = 1 Then
					strSQL = "UPDATE M_冊子 SET 終了日時 = '" & Date.Now.ToString("yyyy/MM/dd HH:mm:ss") & "' "
					strSQL &= "WHERE ID = '" & Me.cmbBookletID.SelectedValue & "'"
				ElseIf LinkProcess = 2 Then
					strSQL = "UPDATE M_冊子 SET 終了日時2次 = '" & Date.Now.ToString("yyyy/MM/dd HH:mm:ss") & "' "
					strSQL &= "WHERE ID = '" & Me.cmbBookletID.SelectedValue & "'"
				End If
				sqlProcess.DB_UPDATE(strSQL)

				EnumBookletID() '冊子IDの再列挙、再選択
				ClearValue()

			Else
				'目次データ書き込み失敗
				MessageBox.Show("データベースへの書き込みに失敗しました" & vbNewLine & "システム管理者に問い合わせてください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
				Exit Sub

			End If

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		Finally

			sqlProcess.Close()

		End Try

	End Sub

	''' <summary>
	''' 目次部グリッドダブルクリック時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	''' <remarks></remarks>
	Private Sub C1FGridMokuji_DoubleClick(sender As System.Object, e As System.EventArgs) Handles C1FGridMokuji.DoubleClick, toolEdit.Click

		If Me.C1FGridMokuji.Row < 1 Then
			Exit Sub
		End If

		ViewEditorMokuji()

	End Sub

	''' <summary>
	''' 目次部グリッドキーダウン時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	''' <remarks></remarks>
	Private Sub C1FGridMokuji_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles C1FGridMokuji.KeyDown
		'Enterキーのみ補足
		If e.KeyCode <> Keys.Enter Then
			Exit Sub
		End If

		ViewEditorMokuji()

	End Sub

	''' <summary>
	''' 目次部グリッドのマウスクリック前
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	''' <remarks></remarks>
	Private Sub C1FGridMokuji_BeforeMouseDown(sender As System.Object, e As C1.Win.C1FlexGrid.BeforeMouseDownEventArgs) Handles C1FGridMokuji.BeforeMouseDown

		'右クリック時
		If e.Button = MouseButtons.Right Then
			'クリックされた位置を取得
			Dim h As C1.Win.C1FlexGrid.HitTestInfo
			h = Me.C1FGridMokuji.HitTest(e.X, e.Y)
			'カレントセルを移動
			If h.Row < 1 Or h.Column < 1 Then
				'行列どちらかが0より少ない場合
				Me.toolSetLink.Enabled = False
				Me.toolDelLink.Enabled = False
				Exit Sub
			Else
				Me.C1FGridMokuji.Row = h.Row
				Me.C1FGridMokuji.Col = h.Column
				Me.toolSetLink.Enabled = True
				Me.toolDelLink.Enabled = True
			End If

		End If

	End Sub

	'''' <summary>
	'''' 冊子IDコンボボックス値変更時
	'''' </summary>
	'''' <param name="sender"></param>
	'''' <param name="e"></param>
	'Private Sub cmbBookletID_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbBookletID.SelectedIndexChanged

	'	SearchGrid()

	'End Sub

#End Region

#Region "MenuStrip"

	Private Sub toolBack_Click(sender As System.Object, e As System.EventArgs) Handles toolBack.Click

		If MessageBox.Show("アプリケーションを終了します" & vbNewLine & "よろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
			Exit Sub
		End If

		Dim strSQL As String = ""
		Dim sqlProcess As New SQLProcess

		Try
			Dim strHostName As String = My.Computer.Name
			strSQL = "UPDATE M_冊子 SET 処理端末 = '' "
			strSQL &= "WHERE 処理端末 = '" & strHostName & "'"
			sqlProcess.DB_UPDATE(strSQL)

			'If m_BackFormID = "frmLogin" Then

			'	Dim frmNextForm As New frmMainMenu
			'	m_Context.SetNextContext(frmNextForm)
			'Else
			'	'他のフォームへ戻る場合個々に記述

			'End If
			XmlSettings.LoadFromXmlFile()
			XmlSettings.SaveToXmlFile()

			Me.Close()

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		Finally

			sqlProcess.Close()

		End Try

	End Sub

	''' <summary>
	''' [ファイル][参照フォルダ]
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	''' <remarks></remarks>
	Private Sub toolReference_Click(sender As System.Object, e As System.EventArgs) Handles toolReference.Click

		Dim frm As New frmBrowse
		frm.ShowDialog()

	End Sub

	''' <summary>
	''' [移動][先頭画像]
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	''' <remarks></remarks>
	Private Sub toolTop_Click(sender As System.Object, e As System.EventArgs) Handles toolTop.Click

		MoveImageTop()

	End Sub

	''' <summary>
	''' [移動][前画像]
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	''' <remarks></remarks>
	Private Sub toolPrev_Click(sender As System.Object, e As System.EventArgs) Handles toolPrev.Click

		MoveImagePrev()

	End Sub

	''' <summary>
	''' [移動][次画像]
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	''' <remarks></remarks>
	Private Sub toolNext_Click(sender As System.Object, e As System.EventArgs) Handles toolNext.Click

		MoveImageNext()

	End Sub

	''' <summary>
	''' [移動][最終画像]
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	''' <remarks></remarks>
	Private Sub toolBottom_Click(sender As System.Object, e As System.EventArgs) Handles toolBottom.Click

		MoveImageBottom()

	End Sub

	''' <summary>
	''' [表示][縮小]
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	''' <remarks></remarks>
	Private Sub toolReduction_Click(sender As System.Object, e As System.EventArgs) Handles toolReduction.Click

		Me.rivImage.ScaleFactor *= 0.8F

	End Sub

	''' <summary>
	''' [表示][拡大]
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	''' <remarks></remarks>
	Private Sub toolMagnification_Click(sender As System.Object, e As System.EventArgs) Handles toolMagnification.Click

		Me.rivImage.ScaleFactor *= 1.2F

	End Sub

	''' <summary>
	''' [表示][フィット]
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	''' <remarks></remarks>
	Private Sub toolFit_Click(sender As System.Object, e As System.EventArgs) Handles toolFit.Click

		Me.rivImage.ScaleFactor = 1.0F
		Me.rivImage.SizeMode = RasterPaintSizeMode.Fit

	End Sub

	''' <summary>
	''' [表示][左回転]
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	''' <remarks></remarks>
	Private Sub toolRotateLeft_Click(sender As System.Object, e As System.EventArgs) Handles toolRotateLeft.Click

		ImageRotate(-90, True)

	End Sub

	''' <summary>
	''' [表示][右回転]
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	''' <remarks></remarks>
	Private Sub toolRotateRight_Click(sender As System.Object, e As System.EventArgs) Handles toolRotateRight.Click

		ImageRotate(90, True)

	End Sub

	''' <summary>
	''' [編集][リンク設定]
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click

		SetLink()

	End Sub

	''' <summary>
	''' [編集][リンク削除]
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub リンク削除ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles リンク削除ToolStripMenuItem.Click

		DelLink()

	End Sub


#End Region

#Region "StatusStrip"

	''' <summary>
	''' 先頭画像へ
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	''' <remarks></remarks>
	Private Sub btnImageTop_Click(sender As System.Object, e As System.EventArgs) Handles btnImageTop.Click

		MoveImageTop()

	End Sub

	''' <summary>
	''' 前の画像へ
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	''' <remarks></remarks>
	Private Sub btnImagePrev_Click(sender As System.Object, e As System.EventArgs) Handles btnImagePrev.Click

		MoveImagePrev()

	End Sub

	''' <summary>
	''' 次の画像へ
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	''' <remarks></remarks>
	Private Sub btnImageNext_Click(sender As System.Object, e As System.EventArgs) Handles btnImageNext.Click

		MoveImageNext()

	End Sub

	''' <summary>
	''' 末尾の画像へ
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	''' <remarks></remarks>
	Private Sub btnImageBottom_Click(sender As System.Object, e As System.EventArgs) Handles btnImageBottom.Click

		MoveImageBottom()

	End Sub

	''' <summary>
	''' 左へ90度回転
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	''' <remarks></remarks>
	Private Sub btnRotateLeft_Click(sender As System.Object, e As System.EventArgs) Handles btnRotateLeft.Click

		ImageRotate(-90, True)

	End Sub

	''' <summary>
	''' 右へ90度回転
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	''' <remarks></remarks>
	Private Sub btnRotateRight_Click(sender As System.Object, e As System.EventArgs) Handles btnRotateRight.Click

		ImageRotate(90, True)

	End Sub

	''' <summary>
	''' 20％縮小
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	''' <remarks></remarks>
	Private Sub btnReduction_Click(sender As System.Object, e As System.EventArgs) Handles btnReduction.Click

		Me.rivImage.ScaleFactor *= 0.8F

	End Sub

	''' <summary>
	''' 20％拡大
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	''' <remarks></remarks>
	Private Sub btnMagnification_Click(sender As System.Object, e As System.EventArgs) Handles btnMagnification.Click

		Me.rivImage.ScaleFactor *= 1.2F

	End Sub

	''' <summary>
	''' フィット
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	''' <remarks></remarks>
	Private Sub btnFit_Click(sender As System.Object, e As System.EventArgs) Handles btnFit.Click

		Me.rivImage.ScaleFactor = 1.0F
		Me.rivImage.SizeMode = RasterPaintSizeMode.Fit

	End Sub

#End Region

#Region "ContextMenu"

	''' <summary>
	''' 目次部コンテキストメニュー[リンク設定]
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	''' <remarks></remarks>
	Private Sub toolSetLink_Click(sender As System.Object, e As System.EventArgs) Handles toolSetLink.Click

		SetLink()

	End Sub

	''' <summary>
	''' 目次部コンテキストメニュー[リンク削除]
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	''' <remarks></remarks>
	Private Sub toolDelLink_Click(sender As System.Object, e As System.EventArgs) Handles toolDelLink.Click

		DelLink()

	End Sub

	''' <summary>
	''' 行の挿入
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	''' <remarks></remarks>
	Private Sub toolInsert_Click(sender As System.Object, e As System.EventArgs) Handles toolInsert.Click

		'2017/03/22
		'2次の場合は機能させない
		If LinkProcess = 2 Then
			MessageBox.Show("2次処理はリンク終端の編集のみ可能です", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Exit Sub
		End If

		If Not Me.C1FGridMokuji.Enabled Then
			MessageBox.Show("冊子IDを選択して開始ボタンを押下してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Exit Sub
		End If

		If Me.C1FGridMokuji.Rows.Count = 1 Then
			'1レコードもデータがない場合は追加
			Me.C1FGridMokuji.Rows.Count = 2
			Me.C1FGridMokuji.Select(1, 1)
		Else
			'選択されているレコードの上に行を挿入
			Me.C1FGridMokuji.Rows.Insert(Me.C1FGridMokuji.Row)
		End If

		GridRenumber(Me.C1FGridMokuji)

	End Sub

	''' <summary>
	''' 行の削除
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	''' <remarks></remarks>
	Private Sub toolDelete_Click(sender As System.Object, e As System.EventArgs) Handles toolDelete.Click

		'2017/03/22
		'2次の場合は機能させない
		If LinkProcess = 2 Then
			MessageBox.Show("2次処理はリンク終端の編集のみ可能です", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Exit Sub
		End If

		If Not Me.C1FGridMokuji.Enabled Then
			MessageBox.Show("冊子IDを選択して開始ボタンを押下してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Exit Sub
		End If

		If Me.C1FGridMokuji.Row < 1 Then
			MessageBox.Show("削除したいレコードを選択してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Exit Sub
		End If

		Me.C1FGridMokuji.Rows.Remove(Me.C1FGridMokuji.Row)

		GridRenumber(Me.C1FGridMokuji)

	End Sub

	''' <summary>
	''' 行の追加
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	''' <remarks></remarks>
	Private Sub toolAdd_Click(sender As System.Object, e As System.EventArgs) Handles toolAdd.Click

		'2017/03/22
		'2次の場合は機能させない
		If LinkProcess = 2 Then
			MessageBox.Show("2次処理はリンク終端の編集のみ可能です", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Exit Sub
		End If

		If Not Me.C1FGridMokuji.Enabled Then
			MessageBox.Show("冊子IDを選択して開始ボタンを押下してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Exit Sub
		End If

		If Me.C1FGridMokuji.Rows.Count = 1 Then
			'1レコードもデータがない場合は追加
			Me.C1FGridMokuji.Rows.Count = 2
			Me.C1FGridMokuji.Select(1, 1)
		Else
			'選択されているレコードの下に行を挿入
			Me.C1FGridMokuji.Rows.Insert(Me.C1FGridMokuji.Row + 1)
		End If

		GridRenumber(Me.C1FGridMokuji)

	End Sub

	''' <summary>
	''' レコード移動後イベント
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub C1FGridMokuji_AfterDragRow(sender As Object, e As C1.Win.C1FlexGrid.DragRowColEventArgs) Handles C1FGridMokuji.AfterDragRow

		GridRenumber(Me.C1FGridMokuji)

	End Sub

	''' <summary>
	''' 管理画面
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub toolManage_Click(sender As Object, e As EventArgs) Handles toolManage.Click

		Dim frm As New frmManage
		m_Context.SetNextContext(frm)

	End Sub

#End Region

#Region "プライベートメソッド"

	''' <summary>
	''' 初期化処理
	''' </summary>
	Private Sub Initialize()

		Dim strSQL As String = ""
		Dim sqlProcess As New SQLProcess

		Try
			''該当端末を処理端末から取り除く
			'Dim strHostName As String = My.Computer.Name
			'strSQL = "UPDATE M_冊子 SET 処理端末 = '' "
			'strSQL &= "WHERE 処理端末 = '" & strHostName & "'"
			'sqlProcess.DB_UPDATE(strSQL)

			Me.lblBookletID.Text = ""   '冊子ID
			Me.lblImageCount.Text = ""  'イメージカウント

			EnumBookletID() '冊子IDの再列挙、再選択

			'LEADTOOLS17.5ライセンスキーの組み込み
			RasterSupport.SetLicense(Application.StartupPath & "\LEAD175ImgSuite.lic", "+sxwXvpT1JbgbQ7DAdF9k8WRWcBnLgwIjN2a3sVpuzOIoMTYIWPT13qYg3qhCnFE")
			RasterSupport.SetLicense(Application.StartupPath & "\LEAD175PDFRead.lic", "GL/iTglRN/ENEQvqOhAf1Z9QTPE2TPnSKBIV46X+rLrYLjpOwntMtnq5nDOWh+skhCe196Z5xK/6f/eatnC7zYlWLKBkYEdBuTw3Kd5JE66jNVn08HpvVdJjz9YAT+77V8P70s5whFv4rFKlzZ/zN3CUmyNeEpoav9oOfSTE2s4heejvh/VZ3BMI8dnR4SRdHumqwebWJSeee9zhTWmU1ubSjEjJSG/HHgfAExQHiKUc5SiwTe2MMBCDdagF3yz10sD8WhkQ/PiIAh5cD+GSUmXHdY3VgW/I6LlwY8vXQfqH/a8a9+79ite7Hye71P6Aqmw3fYX4jJgHioqMxatL2A8NJz5rPzgqPBc817V1qZ8AcaM/LIWnGPHGVqBeIgCjydQlvEjknm9i2Jny83+T3ETq2Sg5YBY1P8+3ccQcY+Xae/KdK6/L7EoYFeq3NAf6mHLN3rK5zOT7uBfHTfVNJQ==")
			'RasterCodecsの初期化
			'入出力ライブラリの起動に必要なデータを初期化する
			codecs = New RasterCodecs
			'ディスプレイモードをバイキュービック法でアンチエイリアス処理をして描画プロパティに適用
			Dim properties As New RasterPaintProperties()
			properties = RasterPaintProperties.Default
			properties.PaintDisplayMode = RasterPaintDisplayModeFlags.Bicubic
			Me.rivImage.PaintProperties = properties

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		Finally

			sqlProcess.Close()

		End Try

	End Sub

	''' <summary>
	''' 冊子IDを列挙し、選択されていた項目を選択し直す
	''' </summary>
	Private Sub EnumBookletID()

		Dim strSQL As String = ""
		Dim sqlProcess As New SQLProcess

		Try
			'選択されているインデックスを取得
			Dim iIndex As Integer = Me.cmbBookletID.SelectedIndex

			'冊子ID一覧をコンボボックスに列挙する
			'終了日時がNULLでないものは冊子IDの先頭にチェック「■」を付加する
			strSQL = "SELECT ID, CASE WHEN ISNULL(終了日時, '') = '1900/01/01' THEN '□□ ' + ID ELSE (CASE WHEN ISNULL(終了日時2次, '') = '1900/01/01' THEN '■□ ' + ID ELSE '■■ ' + ID END) END AS 冊子ID表示 "
			strSQL &= "FROM M_冊子 "
			strSQL &= "GROUP BY ID, 終了日時, 終了日時2次 "
			strSQL &= "ORDER BY ID"
			Dim dt As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
			Dim elmBookletID() As CElement = Nothing
			For iBookletID As Integer = 0 To dt.Rows.Count - 1
				ReDim Preserve elmBookletID(iBookletID)
				elmBookletID(iBookletID) = New CElement
				elmBookletID(iBookletID).ID = dt.Rows(iBookletID)("ID")
				elmBookletID(iBookletID).NAME = dt.Rows(iBookletID)("冊子ID表示")
			Next
			Me.cmbBookletID.DisplayMember = "NAME"
			Me.cmbBookletID.ValueMember = "ID"
			Me.cmbBookletID.DataSource = elmBookletID
			Me.cmbBookletID.SelectedIndex = -1

			'選択していたインデックスを復元
			Me.cmbBookletID.SelectedIndex = iIndex

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		Finally

			sqlProcess.Close()

		End Try

	End Sub

	''' <summary>
	''' FlexGrid選択時に画像をRasterImageViewerに表示する
	''' </summary>
	''' <param name="iIndex"></param>
	''' <remarks></remarks>
	Private Sub SelectImage(ByVal iIndex As Integer)

		Try
			'インデックスが0以下の場合処理させない
			If iIndex <= 0 Then
				Exit Sub
			End If
			'FlextGridの行数以上のインデックスであった場合は抜ける
			If Me.C1FGridResult.Rows.Count <= iIndex Then
				Exit Sub
			End If

			'現在の画像のスクロール一を取得
			Dim ptScrollPosition As Point = Me.rivImage.ScrollPosition
			'RasterImageViewerに表示されているイメージ一を取得
			Dim strFileName As String = Me.C1FGridResult(iIndex, "パス")
			'前回の画像の倍率を取得
			ip.sngZoom = Me.rivImage.ScaleFactor
			'ファイルをロードする
			Dim tempImage As RasterImage = Nothing
			'シングルイメージ
			ip.TotalPages = 1
			ip.CurrentPage = 1
			tempImage = codecs.Load(strFileName)

			''色深度の取得
			'Dim iBitsPerPixel = tempImage.BitsPerPixel
			''画像が2値の場合のみアンチエイリアス処理をかける
			'If iBitsPerPixel = 1 Then
			'	'テンポラリイメージを8ビットグレイスケールに変換する
			'	Dim command As New ImageProcessing.GrayscaleCommand()
			'	command.BitsPerPixel = 8
			'	command.Run(tempImage)
			'End If
			'画像ビューアに設定する
			Me.rivImage.Image = tempImage
			'前回の画像の倍率を反映する
			Me.rivImage.ScaleFactor = ip.sngZoom
			'現在の画像に前回のスクロール位置を反映する
			Me.rivImage.ScrollPosition = ptScrollPosition
			''前回の回転角度を反映する
			'ImageRotate(ip.Degrees)

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		End Try

	End Sub

	''' <summary>
	''' 先頭の画像へ
	''' </summary>
	''' <remarks></remarks>
	Private Sub MoveImageTop()

		If Me.C1FGridResult.Rows.Count <= 1 Then
			'画像が1つもなかったら
			Exit Sub
		End If

		Me.C1FGridResult.Row = 1

	End Sub

	''' <summary>
	''' 前の画像へ
	''' </summary>
	''' <remarks></remarks>
	Private Sub MoveImagePrev()

		If Me.C1FGridResult.Rows.Count <= 1 Then
			Exit Sub
		End If

		If Me.C1FGridResult.Row > 1 Then
			Me.C1FGridResult.Row = Me.C1FGridResult.Row - 1
		Else
			Me.C1FGridResult.Row = 1
		End If

	End Sub

	''' <summary>
	''' 次の画像へ
	''' </summary>
	''' <remarks></remarks>
	Private Sub MoveImageNext()

		If Me.C1FGridResult.Rows.Count <= 1 Then
			Exit Sub
		End If

		If Me.C1FGridResult.Row < Me.C1FGridResult.Rows.Count - 1 Then
			Me.C1FGridResult.Row = Me.C1FGridResult.Row + 1
		Else
			Me.C1FGridResult.Row = Me.C1FGridResult.Rows.Count - 1
		End If

	End Sub

	''' <summary>
	''' 末尾の画像へ
	''' </summary>
	''' <remarks></remarks>
	Private Sub MoveImageBottom()

		If Me.C1FGridResult.Rows.Count <= 1 Then
			Exit Sub
		End If

		Me.C1FGridResult.Row = Me.C1FGridResult.Rows.Count - 1

	End Sub

	''' <summary>
	''' 画像を回転する
	''' </summary>
	''' <param name="degrees">回転角度</param>
	''' <param name="degreesCheck">回転時、回転角度を加算するか否か(デフォルト：加算しない)</param>
	''' <remarks></remarks>
	Private Sub ImageRotate(ByVal degrees As Integer, Optional ByVal degreesCheck As Boolean = False)
		'アングルの指定(90度)
		ip.Angle = degrees * 100    '角度x100
		'Flagsの初期化
		ip.Flags = RotateCommandFlags.None
		'回転することによってキャンバスサイズをリサイズする
		ip.Flags = ip.Flags Or RotateCommandFlags.Resize
		'バイキュービック法で回転
		ip.Flags = ip.Flags Or RotateCommandFlags.Bicubic
		ip.FillColor = New RasterColor(255, 255, 255)

		_initialAngle = ip.Angle
		_initialFlags = ip.Flags
		_initialFillColor = ip.FillColor
		'コマンドオブジェクトの作成
		Dim command As IRasterCommand = Nothing
		command = New RotateCommand(ip.Angle, ip.Flags, ip.FillColor)
		'角度変数に加算する
		If degreesCheck Then
			ip.Degrees += degrees
		End If

		If (Not command Is Nothing) Then
			RunCommand(command)
		End If

	End Sub

	''' <summary>
	''' FlexGridの背景色を変更する(1行単位)
	''' </summary>
	''' <param name="iRow"></param>
	''' <param name="iGridStyleName"></param>
	''' <remarks></remarks>
	Private Sub ChangeBackColor(ByVal iRow As Integer, ByVal iGridStyleName As GridStyleName)
		'カスタムスタイルを作成する
		With C1FGridResult
			'デフォルトスタイル
			.Styles.Add("StyleDefault")
			.Styles("StyleDefault").BackColor = Color.White
			.Styles("StyleDefault").ForeColor = Color.Black
			'目次スタイル
			.Styles.Add("StyleTarget")
			.Styles("StyleTarget").BackColor = Color.LightSlateGray
			.Styles("StyleTarget").ForeColor = Color.Black
			'リンクスタイル
			.Styles.Add("StyleLink")
			.Styles("StyleLink").BackColor = Color.LightCoral
			.Styles("StyleLink").ForeColor = Color.Black

		End With

		Select Case iGridStyleName

			Case GridStyleName.StyleDefault
				'デフォルト
				Me.C1FGridResult.Rows(iRow).Style = Me.C1FGridResult.Styles("StyleDefault")

			Case GridStyleName.StyleTarget
				'目次
				Me.C1FGridResult.Rows(iRow).Style = Me.C1FGridResult.Styles("StyleTarget")

			Case GridStyleName.StyleLink
				'リンク
				Me.C1FGridResult.Rows(iRow).Style = Me.C1FGridResult.Styles("StyleLink")

		End Select

	End Sub

	''' <summary>
	''' FlexGridの背景色を変更する(1行単位)(目次部)
	''' </summary>
	''' <param name="iRow"></param>
	''' <param name="iGridStyleName"></param>
	''' <remarks></remarks>
	Private Sub ChangeBackColorMokuji(ByVal iRow As Integer, ByVal iGridStyleName As GridStyleName)
		'カスタムスタイルを作成する
		With C1FGridMokuji
			'デフォルトスタイル
			.Styles.Add("StyleDefault")
			.Styles("StyleDefault").BackColor = Color.White
			.Styles("StyleDefault").ForeColor = Color.Black
			'目次スタイル
			.Styles.Add("StyleTarget")
			.Styles("StyleTarget").BackColor = Color.LightSlateGray
			.Styles("StyleTarget").ForeColor = Color.Black
			'リンクスタイル
			.Styles.Add("StyleLink")
			.Styles("StyleLink").BackColor = Color.LightCoral
			.Styles("StyleLink").ForeColor = Color.Black

		End With

		Select Case iGridStyleName

			Case GridStyleName.StyleDefault
				'デフォルト
				Me.C1FGridMokuji.Rows(iRow).Style = Me.C1FGridMokuji.Styles("StyleDefault")

			Case GridStyleName.StyleTarget
				'目次
				Me.C1FGridMokuji.Rows(iRow).Style = Me.C1FGridMokuji.Styles("StyleTarget")

			Case GridStyleName.StyleLink
				'リンク
				Me.C1FGridMokuji.Rows(iRow).Style = Me.C1FGridMokuji.Styles("StyleLink")

		End Select

	End Sub

	''' <summary>
	''' 目次部のグリッドのセルの背景色を変更する
	''' </summary>
	''' <param name="iRow"></param>
	''' <param name="iCol"></param>
	''' <param name="iGridStyleName"></param>
	Private Sub ChangeCellBackColor(ByVal iRow As Integer, ByVal iCol As Integer, ByVal iGridStyleName As GridStyleName)
		'カスタムスタイルを作成する
		Dim StyleDefault As C1.Win.C1FlexGrid.CellStyle = Me.C1FGridMokuji.Styles.Add("StyleDefault")
		StyleDefault.BackColor = Color.White
		StyleDefault.ForeColor = Color.Black
		Dim StyleLink As C1.Win.C1FlexGrid.CellStyle = Me.C1FGridMokuji.Styles.Add("StyleLink")
		StyleLink.BackColor = Color.LightCoral
		StyleLink.ForeColor = Color.Black

		Select Case iGridStyleName
			Case GridStyleName.StyleDefault
				'デフォルト
				Me.C1FGridMokuji.SetCellStyle(iRow, iCol, StyleDefault)

			Case GridStyleName.StyleLink
				'リンク
				Me.C1FGridMokuji.SetCellStyle(iRow, iCol, StyleLink)

		End Select

	End Sub

	''' <summary>
	''' RasterImageのコマンドを受け取る
	''' </summary>
	''' <param name="command"></param>
	''' <remarks></remarks>
	Private Sub RunCommand(ByVal command As IRasterCommand)

		Try
			'中心を保持できるように、フロータの位置を保存する
			Dim oldFloaterCenter As Point = New Point(0, 0)
			If Me.rivImage.FloaterVisible AndAlso (Not Me.rivImage.FloaterImage Is Nothing) Then
				oldFloaterCenter = Me.rivImage.FloaterPosition
				Dim rect As System.Drawing.Rectangle = ConvertRect(Me.rivImage.FloaterImage.GetRegionBounds(Nothing))
				oldFloaterCenter.Offset(CInt(rect.Right / 2), CInt(rect.Bottom / 2))
			End If

			command.Run(Me.rivImage.Image)

			If Me.rivImage.FloaterVisible AndAlso (Not Me.rivImage.FloaterImage Is Nothing) Then
				Dim newFloaterCenter As Point = Me.rivImage.FloaterPosition
				newFloaterCenter.Offset(CInt(Me.rivImage.FloaterImage.Width / 2), CInt(Me.rivImage.FloaterImage.Height / 2))
				'中心を保持するようにフロータの位置を移動する
				Dim floaterPosition As Point = Me.rivImage.FloaterPosition
				floaterPosition.Offset(oldFloaterCenter.X - newFloaterCenter.X, oldFloaterCenter.Y - newFloaterCenter.Y)
				Me.rivImage.FloaterPosition = floaterPosition
			End If

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		End Try

	End Sub

	''' <summary>
	''' LeadRectをRectangleに変換する
	''' </summary>
	''' <param name="rc"></param>
	''' <returns></returns>
	''' <remarks></remarks>
	Private Function ConvertRect(ByVal rc As LeadRect) As Rectangle

		Return Rectangle.FromLTRB(rc.Left, rc.Top, rc.Right, rc.Bottom)

	End Function

	''' <summary>
	''' ファイルリストを列挙する
	''' </summary>
	Private Sub SearchGrid()

		Dim strSQL As String = ""
		Dim sqlProcess As New SQLProcess

		Try
			RemoveHandler C1FGridResult.EnterCell, AddressOf C1FGridResult_EnterCell
			Me.C1FGridResult.Rows.Count = 1
			'パス内のJPEG及びPDFを全て取得する
			Dim strBookletID As String = Me.cmbBookletID.SelectedValue
			strSQL = "SELECT ID FROM M_冊子 "
			strSQL &= "WHERE ID = '" & strBookletID & "'"
			Dim dt As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
			'パスを作成する
			XmlSettings.LoadFromXmlFile()
			Dim strTargetPath As String = XmlSettings.Instance.ImagePath & "\" & dt.Rows(0)("ID")
			Dim strImageFiles As String() = GetFilesMostDeep(strTargetPath, {"*.jpg", "*.pdf"})
			Array.Sort(Of String)(strImageFiles)

			'C1FGridResultに列挙
			Dim iRecordCount As Integer = 0
			For Each strFile As String In strImageFiles
				iRecordCount += 1
				Me.C1FGridResult.Rows.Count = iRecordCount + 1
				Me.C1FGridResult(iRecordCount, "No") = iRecordCount
				Me.C1FGridResult(iRecordCount, "ファイル名") = System.IO.Path.GetFileNameWithoutExtension(strFile)
				Me.C1FGridResult(iRecordCount, "パス") = strFile
			Next
			'リンクフラグの反映
			'該当冊子IDのレコードが、M_冊子になかったらスルー
			strSQL = "SELECT COUNT(ID) FROM T_目次 "
			strSQL &= "WHERE ID = '" & strBookletID & "'"
			If CInt(sqlProcess.DB_EXECUTE_SCALAR(strSQL)) > 0 Then
				'1件以上のレコードが存在した
				strSQL = "SELECT リンク FROM T_目次 "
				strSQL &= "WHERE ID = '" & strBookletID & "' "
				strSQL &= "ORDER BY レコード番号"
				Dim dtFileName As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
				Dim iIndex As Integer = 0
				For iRow As Integer = 0 To dtFileName.Rows.Count - 1
					'頭から検索を行う
					iIndex = Me.C1FGridResult.FindRow(dtFileName.Rows(iRow)("リンク"), 1, 1, False)    'ファイル名項目を検索
					If iIndex < 0 Then
						'検索ヒットしなかったら抜ける
						Continue For
					Else
						'ヒットしたリンク項目をTrueにする
						Me.C1FGridResult(iIndex, "リンク") = True
						'スタイルを変更する
						ChangeBackColor(iIndex, GridStyleName.StyleLink)
					End If
				Next
			End If

			'目次内容をC1FGridMokujiに表示させる
			strSQL = "SELECT 目次タイトル, 著者名, リンク, リンクTO, 備考 FROM T_目次 "
			strSQL &= "WHERE ID = '" & strBookletID & "' "
			strSQL &= "ORDER BY レコード番号"
			dt = sqlProcess.DB_SELECT_DATATABLE(strSQL)
			iRecordCount = 0
			For iRow As Integer = 0 To dt.Rows.Count - 1
				iRecordCount += 1
				Me.C1FGridMokuji.Rows.Count = iRecordCount + 1
				Me.C1FGridMokuji(iRecordCount, "No") = iRecordCount
				Me.C1FGridMokuji(iRecordCount, "目次タイトル") = dt.Rows(iRow)("目次タイトル")
				Me.C1FGridMokuji(iRecordCount, "著者名") = dt.Rows(iRow)("著者名")
				Me.C1FGridMokuji(iRecordCount, "リンク") = dt.Rows(iRow)("リンク")
				Me.C1FGridMokuji(iRecordCount, "リンクTO") = dt.Rows(iRow)("リンクTO")
				Me.C1FGridMokuji(iRecordCount, "備考") = dt.Rows(iRow)("備考")
				'高さを自動判定する
				Me.C1FGridMokuji.AutoSizeRow(iRecordCount)
			Next

			'ステータスバーに画像数を表示
			Me.lblImageCount.Text = iRecordCount.ToString & "images"

			AddHandler C1FGridResult.EnterCell, AddressOf C1FGridResult_EnterCell
			'AddHandler C1FGridMokuji.EnterCell, AddressOf C1FGridMokuji_EnterCell

			If Me.C1FGridResult.Rows.Count > 1 Then
				Me.C1FGridResult.Row = 1
				SelectImage(1)
			End If

			'ファイル列挙終了時に開始ボタンを有効化する
			Me.btnStart.Enabled = True

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		Finally

			sqlProcess.Close()
			Me.btnStart.Enabled = True

		End Try

	End Sub

	''' <summary>
	''' 値を初期化する
	''' </summary>
	Private Sub ClearValue()

		Me.C1FGridResult.Rows.Count = 1
		Me.C1FGridMokuji.Rows.Count = 1
		Me.cmbBookletID.Enabled = True
		Me.btnStart.Enabled = True
		Me.btnFinish.Enabled = False
		Me.btnAbort.Enabled = False
		Me.txtBookletName.Text = ""

		Me.lblImageCount.Text = ""
		Me.rivImage.Visible = False
		Me.C1FGridMokuji.Enabled = False

		'処理内容を初期化
		LinkProcess = 0

		'値初期化時に処理端末をリセットする
		Dim strSQL As String = ""
		Dim sqlProcess As New SQLProcess

		Try
			strSQL = "UPDATE M_冊子 SET 処理端末 = N'' "
			strSQL &= "WHERE 処理端末 = '" & My.Computer.Name & "'"
			sqlProcess.DB_UPDATE(strSQL)

		Catch ex As Exception


			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		Finally

			sqlProcess.Close()

		End Try

	End Sub

	''' <summary>
	''' 目次編集エディターを表示する
	''' </summary>
	Private Sub ViewEditorMokuji()

		Dim iRow As Integer = Me.C1FGridMokuji.Row
		Dim iCol As Integer = Me.C1FGridMokuji.Col

		If iRow < 1 Then
			Exit Sub
		End If

		Dim strSQL As String = ""
		Dim sqlProcess As New SQLProcess

		Try
			Dim frm As New frmEditorMokuji
			Dim iTargetRow As Integer = 0

			Select Case iCol
				Case 1, 2
					'2017/03/22
					'処理回次によって分岐
					If LinkProcess = 1 Then
						'1次
						'目次タイトル、著者名編集
						frm.txtItemEdit.ImeMode = ImeMode.Hiragana
						frm.txtItemEdit.Text = Me.C1FGridMokuji(iRow, iCol)
						frm.ShowDialog(Me)
					Else
						'1次以外は編集できないようにする
						'2017/03/22
						'2次の場合は機能させない
						If LinkProcess = 2 Then
							MessageBox.Show("2次処理はリンク終端の編集のみ可能です", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
							Exit Sub
						End If
					End If
				Case 3
					'リンク
					'リンク画像を表示する
					If IsNull(Me.C1FGridMokuji(iRow, iCol)) Then
						Exit Sub
					End If
					Dim iResultIndex As Integer = Me.C1FGridResult.FindRow(Me.C1FGridMokuji(iRow, iCol), 1, 1, False)
					Me.C1FGridResult.Row = iResultIndex
					'2次のときだけ前レコードの編集すべきセルの色を赤くする
					If LinkProcess = 2 Then
						'一度全てのリンク終端のスタイルをデフォルトに戻す
						For i As Integer = 1 To Me.C1FGridMokuji.Rows.Count - 1
							ChangeCellBackColor(i, iCol + 1, GridStyleName.StyleDefault)
						Next
						'前レコードのリンク値がNULLの場合は遡って探す
						For i As Integer = iRow - 1 To 1 Step -1
							If Not IsNull(Me.C1FGridMokuji(i, "リンク")) Then
								iTargetRow = i
								Exit For
							End If
						Next
						'セルの色を赤色にする
						ChangeCellBackColor(iTargetRow, iCol + 1, GridStyleName.StyleLink)  'リンク開始の次のカラムなので＋１
					End If
				Case 4
					'2次のときだけ編集可能に
					If LinkProcess = 2 Then
						frm.txtItemEdit.ImeMode = ImeMode.NoControl
						frm.txtItemEdit.Text = Me.C1FGridMokuji(iRow, iCol)
						frm.ShowDialog(Me)
					End If
				Case 5
					'備考
					frm.txtItemEdit.ImeMode = ImeMode.NoControl
					frm.txtItemEdit.Text = Me.C1FGridMokuji(iRow, iCol)
					frm.ShowDialog(Me)
			End Select

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		Finally

			sqlProcess.Close()

		End Try

	End Sub

	''' <summary>
	''' 連番を振り直す
	''' </summary>
	''' <param name="C1FGrid"></param>
	''' <remarks></remarks>
	Private Sub GridRenumber(ByVal C1FGrid As C1.Win.C1FlexGrid.C1FlexGrid)

		For iRow As Integer = 1 To Me.C1FGridMokuji.Rows.Count - 1
			Me.C1FGridMokuji(iRow, "No") = iRow
		Next

	End Sub

	''' <summary>
	''' リンクを設定する
	''' </summary>
	Private Sub SetLink()

		'2017/03/22
		'2次の場合は機能させない
		If LinkProcess = 2 Then
			MessageBox.Show("2次処理はリンク終端の編集のみ可能です", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Exit Sub
		End If

		'今現在選択されているファイル名をリンク部分にセットする
		Dim iIndex As Integer = 0

		Dim iRow As Integer = Me.C1FGridMokuji.Row
		Dim iTargetRow As Integer = 0
		'===================================================================
		'2017/03/21
		'前レコードより数値が若い場合はエラーとする
		If iRow > 1 Then
			'1レコード目はチェックしない
			'前レコードのリンク値がNULLの場合は遡ってリンクを探す
			For i As Integer = iRow - 1 To 1 Step -1
				If Not IsNull(Me.C1FGridMokuji(i, "リンク")) Then
					iTargetRow = i
					Exit For
				End If
			Next
			'If IsNull(Me.C1FGridMokuji(iRow - 1, "リンク")) Then
			'	MessageBox.Show("上から順にリンクを埋めてください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
			'	Exit Sub
			'End If
			'iTargetRowが0の場合は初回リンクとみなしてスキップする
			If iTargetRow > 0 Then
				Dim iFileNo As Integer = CInt(Me.C1FGridResult(Me.C1FGridResult.Row, "ファイル名"))  '選択されているファイル名の数値化
				'Dim iBeforeLink As Integer = CInt(Me.C1FGridMokuji(iRow - 1, "リンク"))    '目次部の選択されているレコードの前のレコードのリンク番号を数値化
				Dim iBeforeLink As Integer = CInt(Me.C1FGridMokuji(iTargetRow, "リンク"))    '目次部の選択されているレコードの前のレコードのリンク番号を数値化
				If iBeforeLink > iFileNo Then
					'これからリンクを貼ろうとしている値が前レコードのリンク数値より小さかったらエラーとする
					MessageBox.Show("前レコードのリンクより前のファイルのリンクを貼ろうとしています" & vbNewLine & "リンクが正しいか見直してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
					Exit Sub
				End If
			End If
		End If
		'===================================================================

		If IsNull(Me.C1FGridMokuji(iRow, "リンク")) Then
			Me.C1FGridMokuji(iRow, "リンク") = Me.C1FGridResult(Me.C1FGridResult.Row, "ファイル名")
		Else
			'NULLでなかったらファイルリストのリンクフラグを取り下げる
			iIndex = Me.C1FGridResult.FindRow(Me.C1FGridMokuji(iRow, "リンク"), 1, 1, False)
			Me.C1FGridResult(iIndex, "リンク") = False
			ChangeBackColor(iIndex, GridStyleName.StyleDefault)
			Me.C1FGridMokuji(iRow, "リンク") = Me.C1FGridResult(Me.C1FGridResult.Row, "ファイル名")
		End If

		iIndex = Me.C1FGridResult.FindRow(Me.C1FGridMokuji(iRow, "リンク"), 1, 1, False)
		Me.C1FGridResult(iIndex, "リンク") = True

		'===================================================================
		'2017/03/21
		'前レコードのリンクTOに現在レコードのリンク-1の値をセットする
		'前レコードのリンクと現レコードのリンクの値が同一の場合は、前レコードのリンクTOも同一にする
		If iRow > 1 Then
			'1レコード目はチェックしない
			'iTargetRowが0の場合は初回リンクとみなしてスキップする
			If iTargetRow > 0 Then
				'現在レコードのリンク値を取得
				'If Me.C1FGridMokuji(iRow - 1, "リンク") = Me.C1FGridMokuji(iRow, "リンク") Then
				'	Me.C1FGridMokuji(iRow - 1, "リンクTO") = Me.C1FGridMokuji(iRow, "リンク")
				If Me.C1FGridMokuji(iTargetRow, "リンク") = Me.C1FGridMokuji(iRow, "リンク") Then
					Me.C1FGridMokuji(iTargetRow, "リンクTO") = Me.C1FGridMokuji(iRow, "リンク")
				Else
					Dim iLinkValue As Integer = CInt(Me.C1FGridMokuji(iRow, "リンク")) - 1
					'Me.C1FGridMokuji(iRow - 1, "リンクTO") = iLinkValue.ToString("0000")
					Me.C1FGridMokuji(iTargetRow, "リンクTO") = iLinkValue.ToString("0000")
				End If
				'最終レコードの場合、リンクTOに最終ファイルをセットする
				If Me.C1FGridMokuji.Row = Me.C1FGridMokuji.Rows.Count - 1 Then
					Me.C1FGridMokuji(iRow, "リンクTO") = Me.C1FGridResult(Me.C1FGridResult.Rows.Count - 1, "ファイル名")
				End If
			End If

		End If
		'===================================================================

		'FlashingGrid()

		'Do Until Me.Timer1.Enabled = False
		'    Application.DoEvents()
		'Loop
		ChangeBackColor(iIndex, GridStyleName.StyleLink)
		'LinkCheck(iRow)

		'目次の行を1レコードすすめる
		NextMokuji()

	End Sub

	''' <summary>
	''' リンクを削除する
	''' </summary>
	Private Sub DelLink()

		'2017/03/22
		'2次の場合は機能させない
		If LinkProcess = 2 Then
			MessageBox.Show("2次処理はリンク終端の編集のみ可能です", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Exit Sub
		End If

		'現在行のリンク項目を削除
		Dim iRow As Integer = Me.C1FGridMokuji.Row
		'リンクがNULLだった場合、処理を抜ける
		If IsNull(Me.C1FGridMokuji(iRow, "リンク")) Then
			Exit Sub
		End If
		Dim iIndex As Integer = Me.C1FGridResult.FindRow(Me.C1FGridMokuji(iRow, "リンク"), 1, 1, False)
		Me.C1FGridResult(iIndex, "リンク") = False
		ChangeBackColor(iIndex, GridStyleName.StyleDefault)
		Me.C1FGridMokuji(iRow, "リンク") = ""

		'FlashingGrid()

	End Sub

	''' <summary>
	''' 次の目次タイトルを選択する
	''' </summary>
	Private Sub NextMokuji()

		If Me.C1FGridMokuji.Row = Me.C1FGridMokuji.Rows.Count - 1 Then
			'最終行だった場合何もしない
			Exit Sub
		End If

		Me.C1FGridMokuji.Row += 1

	End Sub

	''' <summary>
	''' 目次データをデータベースに保存する
	''' </summary>
	''' <returns></returns>
	Private Function RegistData() As Boolean

		Dim strSQL As String = ""
		Dim sqlProcess As New SQLProcess

		Try
			'目次テーブルのバックアップ
			Dim strHostName As String = My.Computer.Name    '端末名
			Dim strBookletID As String = Me.cmbBookletID.SelectedValue  '冊子ID
			Dim strBackupDate As String = Date.Now.ToString("yyyy/MM/dd HH:mm:ss")
			strSQL = "SELECT ISNULL(MAX(履歴ID), 0) + 1 AS 履歴ID FROM T_目次バックアップ"
			Dim strRirekiID As String = sqlProcess.DB_EXECUTE_SCALAR(strSQL)
			'グリッドより1レコードずつINSERTする
			For iRow As Integer = 1 To Me.C1FGridMokuji.Rows.Count - 1
				strSQL = "INSERT INTO T_目次バックアップ (履歴ID, 履歴ID連番, 端末名, ID, レコード番号, 目次タイトル, 著者名, リンク, リンクTO, 備考, 登録日時) "
				strSQL &= "VALUES("
				strSQL &= strRirekiID   '履歴ID
				strSQL &= ", " & iRow   '履歴ID連番
				strSQL &= ", N'" & strHostName & "'"    '端末名
				strSQL &= ", N'" & strBookletID & "'"   '冊子ID
				strSQL &= ", " & iRow   'レコード番号
				Dim strTitle As String = Me.C1FGridMokuji.Rows(iRow)("目次タイトル")
				If IsNull(strTitle) Then
					strSQL &= ", N''"
				Else
					strSQL &= ", N'" & strTitle.Replace("'", "''") & "'"
				End If
				'strSQL &= ", N'" & IIf(IsNull(Me.C1FGridMokuji.Rows(iRow)("目次タイトル")), Me.C1FGridMokuji.Rows(iRow)("目次タイトル"), Me.C1FGridMokuji.Rows(iRow)("目次タイトル").ToString.Replace("'", "''")) & "'"  'シングルクォートは重複させる
				strSQL &= ", N'" & Me.C1FGridMokuji.Rows(iRow)("著者名") & "'"
				strSQL &= ", N'" & Me.C1FGridMokuji.Rows(iRow)("リンク") & "'"
				strSQL &= ", N'" & Me.C1FGridMokuji.Rows(iRow)("リンクTO") & "'"
				strSQL &= ", N'" & Me.C1FGridMokuji.Rows(iRow)("備考") & "'"  '備考
				strSQL &= ", '" & strBackupDate & "')"   '登録日時
				sqlProcess.DB_UPDATE(strSQL)
			Next

			'データベース上の実データを削除して、グリッドのデータをINSERT
			strSQL = "DELETE FROM T_目次 WHERE ID = '" & strBookletID & "'"
			sqlProcess.DB_UPDATE(strSQL)
			strSQL = "INSERT INTO T_目次 (ID, レコード番号, 目次タイトル, 著者名, リンク, リンクTO, 備考) "
			strSQL &= "SELECT ID, レコード番号, 目次タイトル, 著者名, リンク, リンクTO, 備考 FROM T_目次バックアップ "
			strSQL &= "WHERE 履歴ID = " & strRirekiID & " "
			strSQL &= "ORDER BY 履歴ID連番"
			sqlProcess.DB_UPDATE(strSQL)

			Return True

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Return False

		Finally

			sqlProcess.Close()

		End Try

	End Function

#End Region

End Class