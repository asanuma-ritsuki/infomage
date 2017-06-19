Imports Leadtools
Imports Leadtools.Codecs
Imports Leadtools.WinForms
Imports Leadtools.Drawing
Imports Leadtools.ImageProcessing

Public Class frmMain

#Region "プライベート変数"

	Public m_BackFormID As String = "frmMain"
	'グリッドを点滅させるためのタイマーフラグ
	Private blnTimer As Boolean = True
    '点滅させる行を保持
    Private iFlashRow As Integer = 0
    '画像をロードするためのRasterCodecsオブジェクト
    Private codecs As RasterCodecs

	'Private frm As frmEntry = My.Forms.frmEntry 'エントリフォームのインスタンス
	'Private frm As New frmEntry 'エントリフォームのインスタンス

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

    Dim _iAbortID As Integer = 0
    ''' <summary>
    '''中断時のフラグIDのやり取り
    ''' </summary>
    ''' <returns></returns>
    Public Property iAbortID() As Integer
        Get
            Return _iAbortID
        End Get
        Set(value As Integer)
            _iAbortID = value
        End Set
    End Property

	Dim _Password As String = ""

	''' <summary>
	''' パスワードのやり取り
	''' </summary>
	''' <returns></returns>
	Public Property Password() As String
		Get
			Return _Password
		End Get
		Set(value As String)
			_Password = value
		End Set
	End Property

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

	'管理者かどうか
	Private _blnAdmin As Boolean = False
	Private _iManageID As Integer

	''' <summary>
	''' 管理者かどうかのフラグの入出力
	''' </summary>
	''' <returns></returns>
	Public Property IsAdmin() As Boolean
		Get
			Return _blnAdmin
		End Get
		Set(value As Boolean)
			_blnAdmin = value
		End Set
	End Property

	''' <summary>
	''' 管理IDの入出力
	''' </summary>
	''' <returns></returns>
	Public Property ManageID() As Integer
		Get
			Return _iManageID
		End Get
		Set(value As Integer)
			_iManageID = value
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

		'If Not m_LoginUser.BackFormID = "frmManage" Then
		'	Dim frm As New frmLogin
		'	frm.ShowDialog(Me)
		'End If

		'クラスからログインユーザー取得
		Me.lblUser.Text = m_LoginUser.User

		Initialize()
		ClearValue(True)
		AdminStart()    '管理者権限のユーザー判定
		Restart()

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
						LinkPasteProcess.MoveImageTop(Me.C1FGridResult)
						'MoveImageTop()
						e.Handled = True

                    Case Keys.PageUp
						'前画像へ
						LinkPasteProcess.MoveImagePrev(Me.C1FGridResult)
						e.Handled = True

                    Case Keys.PageDown
						'次画像へ
						LinkPasteProcess.MoveImageNext(Me.C1FGridResult)
						e.Handled = True

                    Case Keys.End
						'末尾画像へ
						LinkPasteProcess.MoveImageBottom(Me.C1FGridResult)
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

		If IsAdmin Then
			'管理者
			If MessageBox.Show("管理画面へ戻ります" & vbNewLine & "よろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
				Exit Sub
			End If
		Else
			'作業者
			If MessageBox.Show("アプリケーションを終了します" & vbNewLine & "よろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
				Exit Sub
			End If
		End If

		Dim strSQL As String = ""
        Dim sqlProcess As New SQLProcess
		Dim strHostName As String = My.Computer.Name

		XmlSettings.LoadFromXmlFile()
		If Me.WindowState = FormWindowState.Normal Then
			'ウィンドウ状態：通常
			XmlSettings.Instance.LocationX = Me.Left
			XmlSettings.Instance.LocationY = Me.Top
			XmlSettings.Instance.SizeX = Me.Width
			XmlSettings.Instance.SizeY = Me.Height
		Else
			'ウィンドウ状態：最大化または最小化
			XmlSettings.Instance.LocationX = Me.RestoreBounds.Left
			XmlSettings.Instance.LocationY = Me.RestoreBounds.Top
			XmlSettings.Instance.SizeX = Me.RestoreBounds.Width
			XmlSettings.Instance.SizeY = Me.RestoreBounds.Height
		End If
		XmlSettings.Instance.State = Me.WindowState

		XmlSettings.SaveToXmlFile()

		Try
			'管理者かどうかで分岐
			If IsAdmin Then
				'管理者
				'既に他端末が登録されていたら更新しない
				strSQL = "SELECT COUNT(*) FROM M_管理表 "
				strSQL &= "WHERE 管理ID = " & Me.cmbBookletID.SelectedValue & " "
				strSQL &= "AND 処理端末 = '" & strHostName & "'"
				If CInt(sqlProcess.DB_EXECUTE_SCALAR(strSQL)) = 1 Then
					'自身の端末が登録されていたら空文字に更新する
					strSQL = "UPDATE M_管理表 SET 処理端末 = '' "
					strSQL &= "WHERE 処理端末 = '" & strHostName & "'"
					sqlProcess.DB_UPDATE(strSQL)
				End If

				'管理画面へ戻る
				CType(Me.Owner, frmManage).Visible = True
				My.Forms.frmEntry.Close()
				Me.Close()

			Else
				'作業者
				strSQL = "UPDATE M_管理表 SET 処理端末 = '' "
				strSQL &= "WHERE 処理端末 = '" & strHostName & "'"
				sqlProcess.DB_UPDATE(strSQL)

				'ログインフラグを取り下げる
				strSQL = "UPDATE M_ユーザー SET ログインフラグ = 0 "
				strSQL &= "WHERE ユーザーID = " & m_LoginUser.UserID
				sqlProcess.DB_UPDATE(strSQL)

				Me.Close()

			End If


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
            MessageBox.Show("フォルダを選択してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Dim strSQL As String = ""
        Dim sqlProcess As New SQLProcess

        Try
            Dim strBookletID As String = Me.cmbBookletID.SelectedValue
			'該当フォルダが他端末で運用されていないかチェックする
			'管理者の場合はチェックしない
			If Not IsAdmin Then

				strSQL = "SELECT 処理端末 FROM M_管理表 "
				strSQL &= "WHERE 管理ID = '" & strBookletID & "'"
				Dim strProcessPC As String = sqlProcess.DB_EXECUTE_SCALAR(strSQL)
				If Not IsNull(strProcessPC) And Not strProcessPC = My.Computer.Name Then
					'端末名がNULLでない、もしくは端末名が自身の端末でなかった場合処理ができないようにする
					MessageBox.Show("該当フォルダは他の端末で処理中です。" & vbNewLine & "処理端末：" & strProcessPC, "確認", MessageBoxButtons.OK, MessageBoxIcon.Hand)
					Exit Sub
				End If

			End If

			'参照フォルダ、フォルダ名で該当フォルダを特定して該当のファイル名をファイルリストに列挙する
			strSQL = "SELECT M番号, 仮フォルダ FROM M_管理表 "
			strSQL &= "WHERE 管理ID = '" & strBookletID & "'"
            Dim dt As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
            If dt.Rows.Count = 0 Then
                MessageBox.Show("該当のフォルダが存在しません", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            'パスを作成する
            XmlSettings.LoadFromXmlFile()
			Dim strTargetPath As String = XmlSettings.Instance.ImagePath & "\" & dt.Rows(0)("M番号") & "\" & dt.Rows(0)("仮フォルダ")
			'パスの存在確認
			If Not System.IO.Directory.Exists(strTargetPath) Then
                MessageBox.Show("画像ファイル参照フォルダが存在しません" & vbNewLine & "参照フォルダを確認してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

			'=============================================================
			'管理者かそうでないかで分岐する
			If IsAdmin Then
				'管理者
				'処理端末の保存
				'既に他端末が登録されていたら更新しない
				strSQL = "SELECT COUNT(*) FROM M_管理表 "
				strSQL &= " WHERE 管理ID = " & Me.cmbBookletID.SelectedValue & " "
				strSQL &= "AND ISNULL(処理端末, '') != ''"
				If CInt(sqlProcess.DB_EXECUTE_SCALAR(strSQL)) = 0 Then
					'登録されていなかった場合更新する
					strSQL = "UPDATE M_管理表 SET 処理端末 = N'" & My.Computer.Name & "' "
					strSQL &= "WHERE 管理ID = " & Me.cmbBookletID.SelectedValue
					sqlProcess.DB_UPDATE(strSQL)
				End If

				'無条件で保留ボタンを使用できなくする
				Me.btnAbort.Enabled = False
				Me.btnFinish.Enabled = True

			Else
				'作業者
				Dim result As DialogResult = vbCancel
				If Strings.Left(Me.cmbBookletID.SelectedItem.ToString, 2) = "■■" Then

					result = MessageBox.Show("既に終了しているフォルダです。該当するボタンを押下してください" & vbNewLine & "※1次リンク付け処理→「はい」" & vbNewLine & "※2次リンク付け処理→「いいえ」" & vbNewLine & "※処理を行わない→「キャンセル」", "確認", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3)
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
					'2次初回でも1次での運用ができるようにする
					result = MessageBox.Show("既に終了しているフォルダです。該当するボタンを押下してください" & vbNewLine & "※1次リンク付け処理→「はい」" & vbNewLine & "※2次リンク付け処理→「いいえ」" & vbNewLine & "※処理を行わない→「キャンセル」", "確認", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3)
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
							'中断、終了ボタンを使用可能に
							Me.btnFinish.Enabled = True
							Me.btnAbort.Enabled = True
						Case vbCancel
							'キャンセル
							LinkProcess = 0
							Exit Sub
					End Select
				Else
					'1次処理確定
					LinkProcess = 1
					'終了ボタン、中断ボタンを使用可能に
					Me.btnFinish.Enabled = True
					Me.btnAbort.Enabled = True

				End If

				'開始日時、処理端末の保存
				strSQL = "UPDATE M_管理表 SET 開始日時 = '" & Date.Now.ToString("yyyy/MM/dd HH:mm:ss") & "', "
				strSQL &= "処理端末 = N'" & My.Computer.Name & "', "
				'処理ユーザーの書き込み
				strSQL &= "処理ユーザー = N'" & m_LoginUser.User & "' "
				strSQL &= "WHERE 管理ID = '" & Me.cmbBookletID.SelectedValue & "'"
				'Console.WriteLine(strSQL)
				sqlProcess.DB_UPDATE(strSQL)

			End If

			'エントリーフォームを表示させる
			ViewEntryForm()

            SearchGrid()

            Me.C1FGridResult.Focus()
            Me.btnStart.Enabled = False

			'県名、フォルダ選択コンボボックスを使用不可にする
			Me.cmbPrefecture.Enabled = False
			Me.cmbBookletID.Enabled = False

			Dim frm As frmEntry = My.Forms.frmEntry
			frm.C1FGridMokuji.Enabled = True

            Me.rivImage.Visible = True

			''冊子名欄に「冊子名」「巻号」「Vol.」「No.」を表示する
			'strSQL = "SELECT 冊子名 + ' ' + 年号 + ' ' + Vol + ' ' + No AS 冊子名 FROM M_冊子 "
			'strSQL &= "WHERE ID = '" & Me.cmbBookletID.SelectedValue & "'"
			'Dim strBookletName As String = sqlProcess.DB_EXECUTE_SCALAR(strSQL)
			'Me.txtBookletName.Text = strBookletName

			If frm.C1FGridMokuji.Rows.Count <= 1 Then
				Exit Sub
			End If

			'Dim frm As frmMain = CType(Me.Owner, frmMain)
			Dim iRow As Integer = frm.C1FGridMokuji.Row
			'MessageBox.Show(Me.C1FGridMokuji(iRow, "表示用"))
			Me.C1FGridDoc(1, "内容") = frm.C1FGridMokuji(iRow, "表示用")
			Me.C1FGridDoc(2, "内容") = frm.C1FGridMokuji(iRow, "県名")
			Me.C1FGridDoc(3, "内容") = frm.C1FGridMokuji(iRow, "資料名")
			Me.C1FGridDoc(4, "内容") = frm.C1FGridMokuji(iRow, "副題")
			Me.C1FGridDoc(5, "内容") = frm.C1FGridMokuji(iRow, "対象年")
			Me.C1FGridDoc(6, "内容") = frm.C1FGridMokuji(iRow, "刊行者名")
			Me.C1FGridDoc(7, "内容") = frm.C1FGridMokuji(iRow, "刊行年月")

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

		''ダイアログを表示し結果が返ってくるのを待つ
		'Dim f As New frmAbortDialog
		'Dim result As System.Windows.Forms.DialogResult = f.ShowDialog(Me)

		'If result = DialogResult.Cancel Then
		'    Exit Sub
		'End If

		If MessageBox.Show("該当フォルダのリンク付け処理を保留にします" & vbNewLine & "※該当フォルダは管理者以外、作業ができなくなります" & vbNewLine & "よろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
			Exit Sub
		End If

		Dim strSQL As String = ""
        Dim sqlProcess As New SQLProcess
		Dim frm As frmEntry = My.Forms.frmEntry

		'保留フラグを立てる
		iAbortID = 1

		Try
            '中断フラグが既に存在していた場合を考慮して削除する
            strSQL = "DELETE FROM T_フラグ "
            strSQL &= "WHERE 管理ID = " & Me.cmbBookletID.SelectedValue & " "
            strSQL &= "AND 種別ID = 10"
            sqlProcess.DB_UPDATE(strSQL)
            '中断フラグのIDの書き込み
            strSQL = "SELECT ISNULL(MAX(連番), 0) + 1 FROM T_フラグ "
            strSQL &= "WHERE 管理ID = " & Me.cmbBookletID.SelectedValue
            Dim iSeq As Integer = sqlProcess.DB_EXECUTE_SCALAR(strSQL)
            strSQL = "INSERT INTO T_フラグ (管理ID, 連番, 種別ID, フラグID, ファイル名, レコード番号) "
            strSQL &= "VALUES(" & Me.cmbBookletID.SelectedValue '管理ID
            strSQL &= ", " & iSeq   '連番
            strSQL &= ", 10"    '種別ID
            strSQL &= ", " & iAbortID   'フラグID
            strSQL &= ", N'', N'')" 'ファイル名、レコード番号はNULL
            sqlProcess.DB_UPDATE(strSQL)

            '目次データの書き込み
            If RegistData() Then
                '目次データ書き込み成功
                '終了日を取り下げる
                '2017/03/22
                '1次の場合は「終了日時」、2次の場合は「終了日時2次」
                If LinkProcess = 1 Then
                    strSQL = "UPDATE M_管理表 SET 終了日時 = NULL "
                    strSQL &= "WHERE 管理ID = '" & Me.cmbBookletID.SelectedValue & "'"
                ElseIf LinkProcess = 2 Then
                    strSQL = "UPDATE M_管理表 SET 終了日時2次 = NULL "
                    strSQL &= "WHERE 管理ID = '" & Me.cmbBookletID.SelectedValue & "'"
                End If
                sqlProcess.DB_UPDATE(strSQL)

				ClearValue()
				EnumBookletID() 'フォルダの再列挙、再選択
				frm.Close() 'エントリフォームを閉じる

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
            '画像の表示
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

		Dim frm As frmEntry = My.Forms.frmEntry

		'リンクが全てのレコードに貼られているかチェック
		'リンクチェックは1次処理のみ
		If LinkProcess = 1 Then

			Dim blnNoLink As Boolean = False
			'リンクの貼られていない目次タイトルを列挙する
			Dim strMokujiTitle As String = vbNewLine
			For iRow As Integer = 1 To frm.C1FGridMokuji.Rows.Count - 1
				If IsNull(frm.C1FGridMokuji(iRow, "リンク")) And frm.C1FGridMokuji(iRow, "フラグID") = 0 Then
					'リンク項目に値がない場合はフラグを立てて最終行まで検査する
					strMokujiTitle &= frm.C1FGridMokuji(iRow, "タイトル1") & vbNewLine
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

		'管理者かどうかで分岐する
		If IsAdmin Then
			'管理者
			Dim result As DialogResult = vbCancel
			'result = MessageBox.Show("該当フォルダの管理者確認を完了します。該当するボタンを押下してください" & vbNewLine & "※全てのフラグを確認済にして完了→「はい」" & vbNewLine & "※チェックしたフラグのみ確認済にして完了→「いいえ」" & vbNewLine & "※作業画面に戻る→「キャンセル」", "確認", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3)
			result = MessageBox.Show("該当フォルダの管理者確認を完了します。" & vbNewLine & "全てのフラグが「管理者確認済」となります。" & vbNewLine & "よろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)

			Dim strSQL As String = ""
			Dim sqlProcess As New SQLProcess
			Dim strHostName As String = My.Computer.Name

			Try
				Select Case result
					Case vbYes
						'該当フォルダの全てのフラグを確認済みにする
						'終了日は記録しないで完了する
						If RegistData() Then
							strSQL = "UPDATE T_フラグ SET 管理者確認 = 1 "
							strSQL &= "WHERE 管理ID = " & Me.cmbBookletID.SelectedValue
							sqlProcess.DB_UPDATE(strSQL)
						End If
					Case vbNo
						'いいえの場合は抜ける
						Exit Sub

				End Select

				XmlSettings.LoadFromXmlFile()
				If Me.WindowState = FormWindowState.Normal Then
					'ウィンドウ状態：通常
					XmlSettings.Instance.LocationX = Me.Left
					XmlSettings.Instance.LocationY = Me.Top
					XmlSettings.Instance.SizeX = Me.Width
					XmlSettings.Instance.SizeY = Me.Height
				Else
					'ウィンドウ状態：最大化または最小化
					XmlSettings.Instance.LocationX = Me.RestoreBounds.Left
					XmlSettings.Instance.LocationY = Me.RestoreBounds.Top
					XmlSettings.Instance.SizeX = Me.RestoreBounds.Width
					XmlSettings.Instance.SizeY = Me.RestoreBounds.Height
				End If
				XmlSettings.Instance.State = Me.WindowState

				XmlSettings.SaveToXmlFile()

				'既に他端末が登録されていたら更新しない
				strSQL = "SELECT COUNT(*) FROM M_管理表 "
				strSQL &= "WHERE 管理ID = " & Me.cmbBookletID.SelectedValue & " "
				strSQL &= "AND 処理端末 = '" & strHostName & "'"
				If CInt(sqlProcess.DB_EXECUTE_SCALAR(strSQL)) = 1 Then
					'自身の端末が登録されていたら空文字に更新する
					strSQL = "UPDATE M_管理表 SET 処理端末 = '' "
					strSQL &= "WHERE 処理端末 = '" & strHostName & "'"
					sqlProcess.DB_UPDATE(strSQL)
				End If

				'管理画面へ戻る
				CType(Me.Owner, frmManage).Visible = True
				My.Forms.frmEntry.Close()
				Me.Close()

			Catch ex As Exception

				Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message)
				MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

			Finally

				sqlProcess.Close()

			End Try
		Else
			'作業者
			'If MessageBox.Show("該当フォルダのリンク付け処理を終了します" & vbNewLine & "よろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
			'	Exit Sub
			'End If
			Dim result As DialogResult = vbCancel
			result = MessageBox.Show("該当フォルダのリンク付け処理を終了、または中断します。該当するボタンを押下してください" & vbNewLine & "※該当フォルダを完了する→「はい」" & vbNewLine & "※該当フォルダを中断する（アプリの終了）→「いいえ」" & vbNewLine & "※作業画面に戻る→「キャンセル」", "確認", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3)

			Dim strSQL As String = ""
			Dim sqlProcess As New SQLProcess

			Try
				Select Case result
					Case vbYes
						'終了日時を記録して完了する
						'目次データの書き込み
						If RegistData() Then
							'目次データ書き込み成功
							'冊子マスタの終了日を更新
							'1次処理「終了日時」、2次処理「終了日時2次」
							If LinkProcess = 1 Then
								strSQL = "UPDATE M_管理表 SET 終了日時 = '" & Date.Now.ToString("yyyy/MM/dd HH:mm:ss") & "' "
								strSQL &= "WHERE 管理ID = " & Me.cmbBookletID.SelectedValue
							ElseIf LinkProcess = 2 Then
								strSQL = "UPDATE M_管理表 SET 終了日時2次 = '" & Date.Now.ToString("yyyy/MM/dd HH:mm:ss") & "' "
								strSQL &= "WHERE 管理ID = " & Me.cmbBookletID.SelectedValue
							End If
							sqlProcess.DB_UPDATE(strSQL)
							'管理表フラグを取り下げる
							strSQL = "DELETE FROM T_フラグ "
							strSQL &= "WHERE 管理ID = " & Me.cmbBookletID.SelectedValue & " "
							strSQL &= "AND 種別ID = 10"
							sqlProcess.DB_UPDATE(strSQL)

							EnumBookletID() 'フォルダの再列挙、再選択
							ClearValue()
							frm.Close() 'エントリフォームを閉じる

						Else
							'目次データ書き込み失敗
							MessageBox.Show("データベースへの書き込みに失敗しました" & vbNewLine & "システム管理者に問い合わせてください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
							Exit Sub

						End If

					Case vbNo
						'終了日を設定せず、端末名を残して終了
						If RegistData() Then
							'目次データ書き込み成功
							''冊子マスタの終了日を更新
							''1次処理「終了日時」、2次処理「終了日時2次」
							'If LinkProcess = 1 Then
							'	strSQL = "UPDATE M_管理表 SET 終了日時 = '" & Date.Now.ToString("yyyy/MM/dd HH:mm:ss") & "' "
							'	strSQL &= "WHERE 管理ID = " & Me.cmbBookletID.SelectedValue
							'ElseIf LinkProcess = 2 Then
							'	strSQL = "UPDATE M_管理表 SET 終了日時2次 = '" & Date.Now.ToString("yyyy/MM/dd HH:mm:ss") & "' "
							'	strSQL &= "WHERE 管理ID = " & Me.cmbBookletID.SelectedValue
							'End If
							'sqlProcess.DB_UPDATE(strSQL)
							''管理表フラグを取り下げる
							'strSQL = "DELETE FROM T_フラグ "
							'strSQL &= "WHERE 管理ID = " & Me.cmbBookletID.SelectedValue & " "
							'strSQL &= "AND 種別ID = 10"
							'sqlProcess.DB_UPDATE(strSQL)

							'EnumBookletID() 'フォルダの再列挙、再選択
							'ClearValue()

							'ログインフラグの取り下げ
							strSQL = "UPDATE M_ユーザー SET ログインフラグ = 0 "
							strSQL &= "WHERE ユーザーID = " & m_LoginUser.UserID
							sqlProcess.DB_UPDATE(strSQL)

							frm.Close() 'エントリフォームを閉じる
							Me.Close()
						Else
							'目次データ書き込み失敗
							MessageBox.Show("データベースへの書き込みに失敗しました" & vbNewLine & "システム管理者に問い合わせてください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
							Exit Sub

						End If


					Case vbCancel
						'キャンセルの場合は抜ける
						Exit Sub
				End Select

			Catch ex As Exception

				Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message)
				MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

			Finally

				sqlProcess.Close()

			End Try

		End If




	End Sub

	''' <summary>
	''' フラグ情報グリッドダブルクリック時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub C1FGridFlag_DoubleClick(sender As Object, e As EventArgs) Handles C1FGridFlag.DoubleClick

		Dim iRow As Integer = Me.C1FGridFlag.Row
		Dim iCol As Integer = Me.C1FGridFlag.Col

		If iRow < 1 Then
			Exit Sub
		End If

		'対象セルがNULLの場合は抜ける
		If IsNull(Me.C1FGridFlag(iRow, iCol)) Then
			Exit Sub
		End If

		Select Case iCol
			Case 2  'ファイル名
				'ファイルリストよりファイル名を検索してレコードを移動する
				Dim iIndex As Integer = Me.C1FGridResult.FindRow(Me.C1FGridFlag(iRow, iCol), 1, 1, False)
				Me.C1FGridResult.Row = iIndex
			Case 3  'レコード番号
				'目次部のレコード番号を検索してレコードを移動する
				Dim frm As frmEntry = My.Forms.frmEntry
				Dim iIndex As Integer = frm.C1FGridMokuji.FindRow(Me.C1FGridFlag(iRow, iCol), 1, 3, False)
				frm.C1FGridMokuji.Row = iIndex
		End Select
	End Sub


#End Region

#Region "Menu Strip"

	''' <summary>
	''' [ファイル][終了]
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub toolBack_Click(sender As System.Object, e As System.EventArgs) Handles toolBack.Click

        If MessageBox.Show("アプリケーションを終了します" & vbNewLine & "よろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
            Exit Sub
        End If

        Dim strSQL As String = ""
        Dim sqlProcess As New SQLProcess

        Try
            Dim strHostName As String = My.Computer.Name
            strSQL = "UPDATE M_管理表 SET 処理端末 = '' "
            strSQL &= "WHERE 処理端末 = '" & strHostName & "'"
            sqlProcess.DB_UPDATE(strSQL)

			'ログインフラグを取り下げる
			strSQL = "UPDATE M_ユーザー SET ログインフラグ = 0 "
			strSQL &= "WHERE ユーザーID = " & m_LoginUser.UserID
			sqlProcess.DB_UPDATE(strSQL)

			XmlSettings.LoadFromXmlFile()
            If Me.WindowState = FormWindowState.Normal Then
                'ウィンドウ状態：通常
                XmlSettings.Instance.LocationX = Me.Left
                XmlSettings.Instance.LocationY = Me.Top
                XmlSettings.Instance.SizeX = Me.Width
                XmlSettings.Instance.SizeY = Me.Height
            Else
                'ウィンドウ状態：最大化または最小化
                XmlSettings.Instance.LocationX = Me.RestoreBounds.Left
                XmlSettings.Instance.LocationY = Me.RestoreBounds.Top
                XmlSettings.Instance.SizeX = Me.RestoreBounds.Width
                XmlSettings.Instance.SizeY = Me.RestoreBounds.Height
            End If
            XmlSettings.Instance.State = Me.WindowState

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

		LinkPasteProcess.MoveImageTop(Me.C1FGridResult)

	End Sub

    ''' <summary>
    ''' [移動][前画像]
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub toolPrev_Click(sender As System.Object, e As System.EventArgs) Handles toolPrev.Click

		LinkPasteProcess.MoveImagePrev(Me.C1FGridResult)

	End Sub

    ''' <summary>
    ''' [移動][次画像]
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub toolNext_Click(sender As System.Object, e As System.EventArgs) Handles toolNext.Click

		LinkPasteProcess.MoveImageNext(Me.C1FGridResult)

	End Sub

    ''' <summary>
    ''' [移動][最終画像]
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub toolBottom_Click(sender As System.Object, e As System.EventArgs) Handles toolBottom.Click

		LinkPasteProcess.MoveImageBottom(Me.C1FGridResult)

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
    ''' 行の挿入
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub toolInsert_Click(sender As Object, e As EventArgs) Handles toolInsert.Click

		''2017/03/22
		''2次の場合は機能させない
		'If LinkProcess = 2 Then
		'    MessageBox.Show("2次処理はリンク終端の編集のみ可能です", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
		'    Exit Sub
		'End If
		Dim frm As frmEntry = My.Forms.frmEntry

		If Not frm.C1FGridMokuji.Enabled Then
            MessageBox.Show("フォルダを選択して開始ボタンを押下してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If frm.C1FGridMokuji.Rows.Count = 1 Then
            '1レコードもデータがない場合は追加
            frm.C1FGridMokuji.Rows.Count = 2
			frm.C1FGridMokuji.Select(1, 1)
			'追加フラグを立てる
			frm.C1FGridMokuji(1, "フラグID") = 4
			frm.C1FGridMokuji(1, "フラグ") = "追加"
			frm.C1FGridMokuji(1, "備考") = "4.追加"
			LinkPasteProcess.ChangeBackColor(frm.C1FGridMokuji, 1, LinkPasteProcess.GridStyleName.StyleTarget)
			'ChangeBackColorMokuji(1, GridStyleName.StyleTarget)
		Else
			'選択されているレコードの上に行を挿入
			frm.C1FGridMokuji.Rows.Insert(frm.C1FGridMokuji.Row)
			'追加フラグを立てる
			frm.C1FGridMokuji(frm.C1FGridMokuji.Row - 1, "フラグID") = 4
			frm.C1FGridMokuji(frm.C1FGridMokuji.Row - 1, "フラグ") = "追加"
			frm.C1FGridMokuji(frm.C1FGridMokuji.Row - 1, "備考") = "4.追加"
			LinkPasteProcess.ChangeBackColor(frm.C1FGridMokuji, frm.C1FGridMokuji.Row - 1, LinkPasteProcess.GridStyleName.StyleTarget)
			'ChangeBackColorMokuji(frm.C1FGridMokuji.Row - 1, GridStyleName.StyleTarget)
		End If

		LinkPasteProcess.GridRenumber(frm.C1FGridMokuji)

	End Sub

    ''' <summary>
    ''' 行の削除
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub toolDelete_Click(sender As System.Object, e As System.EventArgs) Handles toolDelete.Click

		''2017/03/22
		''2次の場合は機能させない
		'If LinkProcess = 2 Then
		'    MessageBox.Show("2次処理はリンク終端の編集のみ可能です", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
		'    Exit Sub
		'End If
		Dim frm As frmEntry = My.Forms.frmEntry

		If Not frm.C1FGridMokuji.Enabled Then
            MessageBox.Show("フォルダを選択して開始ボタンを押下してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If frm.C1FGridMokuji.Row < 1 Then
            MessageBox.Show("削除したいレコードを選択してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        frm.C1FGridMokuji.Rows.Remove(frm.C1FGridMokuji.Row)

		LinkPasteProcess.GridRenumber(frm.C1FGridMokuji)

	End Sub

    ''' <summary>
    ''' 行の追加
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub toolAdd_Click(sender As System.Object, e As System.EventArgs) Handles toolAdd.Click

		''2017/03/22
		''2次の場合は機能させない
		'If LinkProcess = 2 Then
		'    MessageBox.Show("2次処理はリンク終端の編集のみ可能です", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
		'    Exit Sub
		'End If
		Dim frm As frmEntry = My.Forms.frmEntry

		If Not frm.C1FGridMokuji.Enabled Then
            MessageBox.Show("フォルダを選択して開始ボタンを押下してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If frm.C1FGridMokuji.Rows.Count = 1 Then
            '1レコードもデータがない場合は追加
            frm.C1FGridMokuji.Rows.Count = 2
            frm.C1FGridMokuji.Select(1, 1)
			'追加フラグを立てる
			frm.C1FGridMokuji(1, "フラグID") = 4
			frm.C1FGridMokuji(1, "フラグ") = "追加"
			frm.C1FGridMokuji(1, "備考") = "4.追加"
			LinkPasteProcess.ChangeBackColor(frm.C1FGridMokuji, 1, LinkPasteProcess.GridStyleName.StyleTarget)
			'ChangeBackColorMokuji(1, GridStyleName.StyleTarget)
		Else
			'選択されているレコードの下に行を挿入
			frm.C1FGridMokuji.Rows.Insert(frm.C1FGridMokuji.Row + 1)
			'追加フラグを立てる
			frm.C1FGridMokuji(frm.C1FGridMokuji.Row + 1, "フラグID") = 4
			frm.C1FGridMokuji(frm.C1FGridMokuji.Row + 1, "フラグ") = "追加"
			frm.C1FGridMokuji(frm.C1FGridMokuji.Row + 1, "備考") = "4.追加"
			LinkPasteProcess.ChangeBackColor(frm.C1FGridMokuji, frm.C1FGridMokuji.Row + 1, LinkPasteProcess.GridStyleName.StyleTarget)
			'ChangeBackColorMokuji(frm.C1FGridMokuji.Row + 1, GridStyleName.StyleTarget)
		End If

		LinkPasteProcess.GridRenumber(frm.C1FGridMokuji)

	End Sub

    ''' <summary>
    ''' [編集][リンクFROM設定]
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub toolSetLink_Click(sender As Object, e As EventArgs) Handles toolSetLink.Click

		Dim frm As frmEntry = My.Forms.frmEntry
		LinkPasteProcess.SetLink(Me.C1FGridResult, frm.C1FGridMokuji, LinkFromTo.LinkFrom)
		'SetLink()

	End Sub

    ''' <summary>
    ''' [編集][リンクFROM削除]
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub toolDelLink_Click(sender As Object, e As EventArgs) Handles toolDelLink.Click

		Dim frm As frmEntry = My.Forms.frmEntry
		LinkPasteProcess.DelLink(Me.C1FGridResult, frm.C1FGridMokuji, LinkFromTo.LinkFrom)
		'DelLink()

	End Sub

    ''' <summary>
    ''' [編集][リンクTO設定]
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub toolSetLinkTo_Click(sender As Object, e As EventArgs) Handles toolSetLinkTo.Click

		Dim frm As frmEntry = My.Forms.frmEntry
		LinkPasteProcess.SetLink(Me.C1FGridResult, frm.C1FGridMokuji, LinkFromTo.LinkTo)
		'SetLinkTo()

	End Sub

    ''' <summary>
    ''' [編集][リンクTO削除]
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub toolDelLinkTo_Click(sender As Object, e As EventArgs) Handles toolDelLinkTo.Click

		Dim frm As frmEntry = My.Forms.frmEntry
		LinkPasteProcess.DelLink(Me.C1FGridResult, frm.C1FGridMokuji, LinkFromTo.LinkTo)
		'DelLinkTo()

	End Sub

    ''' <summary>
    ''' 管理画面
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub toolManage_Click(sender As Object, e As EventArgs) Handles toolManage.Click

		Dim f As New frmToManageDialog
		Dim result As DialogResult = f.ShowDialog(Me)

		Select Case result
			Case vbOK
				If Password = "yushodo" Then
					m_LoginUser.BackFormID = "frmMain"
					Dim frm As New frmManage
					m_Context.SetNextContext(frm)
				Else
					MessageBox.Show("パスワードが違います", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
					Exit Sub
				End If
			Case vbCancel
				Exit Sub
		End Select

	End Sub

#End Region

#Region "Status Strip"

	''' <summary>
	''' 先頭画像へ
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	''' <remarks></remarks>
	Private Sub btnImageTop_Click(sender As System.Object, e As System.EventArgs) Handles btnImageTop.Click

		LinkPasteProcess.MoveImageTop(Me.C1FGridResult)

	End Sub

    ''' <summary>
    ''' 前の画像へ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnImagePrev_Click(sender As System.Object, e As System.EventArgs) Handles btnImagePrev.Click

		LinkPasteProcess.MoveImagePrev(Me.C1FGridResult)

	End Sub

    ''' <summary>
    ''' 次の画像へ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnImageNext_Click(sender As System.Object, e As System.EventArgs) Handles btnImageNext.Click

		LinkPasteProcess.MoveImageNext(Me.C1FGridResult)

	End Sub

    ''' <summary>
    ''' 末尾の画像へ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnImageBottom_Click(sender As System.Object, e As System.EventArgs) Handles btnImageBottom.Click

		LinkPasteProcess.MoveImageBottom(Me.C1FGridResult)

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

    ''' <summary>
    ''' 県名コンボボックスインデックス変更時
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub cmbPrefecture_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPrefecture.SelectedIndexChanged

        EnumBookletID()

    End Sub

    ''' <summary>
    ''' ファイル情報グリッドのマウスクリック前
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub C1FGridResult_BeforeMouseDown(sender As Object, e As C1.Win.C1FlexGrid.BeforeMouseDownEventArgs) Handles C1FGridResult.BeforeMouseDown

        '右クリック時
        If e.Button = MouseButtons.Right Then
            'クリックされた位置を取得
            Dim h As C1.Win.C1FlexGrid.HitTestInfo
            h = Me.C1FGridResult.HitTest(e.X, e.Y)
            'カレントセルを移動
            Me.C1FGridResult.Row = h.Row
            If h.Row < 1 Or h.Column < 1 Then
                '行列どちらかが0より少ない場合
                Me.menuDelImage.Enabled = False
                Me.menuSetImage.Enabled = False
            Else
                '削除フラグが立っているか
                If Me.C1FGridResult(h.Row, "削除") = True Then
                    '削除フラグが立っていた
                    '取り下げだけ有効
                    Me.menuDelImage.Enabled = False
                    Me.menuSetImage.Enabled = True
                Else
                    '削除フラグが立っていない
                    'リンクフラグが立っているか
                    If Me.C1FGridResult(h.Row, "リンク") = True Then
                        'リンクフラグが立っていた
                        '無効
                        Me.menuDelImage.Enabled = False
                        Me.menuSetImage.Enabled = False
                    Else
                        'リンクフラグが立っていない
                        '削除フラグ設定だけ有効
                        Me.menuDelImage.Enabled = True
                        Me.menuSetImage.Enabled = False
                    End If
                End If
            End If
        End If
    End Sub

    ''' <summary>
    ''' コンテキストメニュー[削除フラグ設定]
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub menuDelImage_Click(sender As Object, e As EventArgs) Handles menuDelImage.Click

        'コンボボックス付きの選択ウィンドウを開く
        Dim frm As New frmImageFlagDialog
        frm.ShowDialog(Me)

    End Sub

    ''' <summary>
    ''' コンテキストメニュー[削除フラグ削除]
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub menuSetImage_Click(sender As Object, e As EventArgs) Handles menuSetImage.Click

        Dim iRow As Integer = Me.C1FGridResult.Row
        Me.C1FGridResult(iRow, "削除") = False
		Me.C1FGridResult(iRow, "フラグID") = 0
		LinkPasteProcess.ChangeBackColor(Me.C1FGridResult, iRow, LinkPasteProcess.GridStyleName.StyleDefault)
		'ChangeBackColor(iRow, GridStyleName.StyleDefault)

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

            XmlSettings.LoadFromXmlFile()
            Me.Left = XmlSettings.Instance.LocationX
            Me.Top = XmlSettings.Instance.LocationY
            Me.Width = XmlSettings.Instance.SizeX
            Me.Height = XmlSettings.Instance.SizeY

            Me.WindowState = XmlSettings.Instance.State

			'ユーザー名の表示
			Me.lblUser.Text = m_LoginUser.User

			EnumPrefecture()    '県名コンボボックスに都道府県を列挙
            'EnumBookletID() 'フォルダの再列挙、再選択

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

			'管理者の場合は、終了ボタンを戻るボタンにする
			'フラグ一覧グリッドの「確認」項目を可視化する
			If IsAdmin Then
				Me.btnBack.Text = "戻る"
				Me.C1FGridFlag.Cols("確認").Visible = True
			Else
				Me.C1FGridFlag.Cols("確認").Visible = False
			End If

		Catch ex As Exception

            Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message)
            MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally

            sqlProcess.Close()

        End Try

    End Sub

    ''' <summary>
    ''' 県名コンボボックスに都道府県を列挙する
    ''' </summary>
    Private Sub EnumPrefecture()

        Dim strSQL As String = ""
        Dim sqlProcess As New SQLProcess

		Try
			'中断の復帰処理や管理者画面からの遷移時に県名が引っかからない場合があるため
			'M_都道府県内に「検索用」項目を追加し対応
			strSQL = "SELECT 検索用, 都道府県番号 + ' ' + 都道府県名 AS 番号県名 FROM M_都道府県 "
			strSQL &= "ORDER BY 都道府県番号"
			Dim dt As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
			Dim elmPrefecture() As CElement = Nothing
			For iPrefecture As Integer = 0 To dt.Rows.Count - 1
				ReDim Preserve elmPrefecture(iPrefecture)
				elmPrefecture(iPrefecture) = New CElement
				elmPrefecture(iPrefecture).ID = dt.Rows(iPrefecture)("検索用")
				elmPrefecture(iPrefecture).NAME = dt.Rows(iPrefecture)("番号県名")
			Next
			Me.cmbPrefecture.DisplayMember = "NAME"
			Me.cmbPrefecture.ValueMember = "ID"
			Me.cmbPrefecture.DataSource = elmPrefecture
			Me.cmbPrefecture.SelectedIndex = -1

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

        '県名コンボボックスが未選択の場合は機能させない
        If Me.cmbPrefecture.SelectedIndex = -1 Then
            Exit Sub
        End If

        Dim strSQL As String = ""
        Dim sqlProcess As New SQLProcess

        Try
            '選択されているインデックスを取得
            Dim iIndex As Integer = Me.cmbBookletID.SelectedIndex

            'フォルダ一覧をコンボボックスに列挙する
            '終了日時がNULLでないものはフォルダの先頭にチェック「■」を付加する
            strSQL = "SELECT 管理ID, CASE WHEN ISNULL(終了日時, '') = '1900/01/01' THEN '□□ ' + 納品フォルダ ELSE (CASE WHEN ISNULL(終了日時2次, '') = '1900/01/01' THEN '■□ ' + 納品フォルダ ELSE '■■ ' + 納品フォルダ END) END AS 納品フォルダ "
            strSQL &= "FROM M_管理表 "
			strSQL &= "WHERE 県名 LIKE '%" & Me.cmbPrefecture.SelectedValue & "%' "
			'中断中、あるいは作業中のフォルダは表示させないようにする
			'※開始日時あり、終了日時なし、端末名あり
			'表示させる条件は、開始日時なし OR 開始日時あり、終了日時あり OR 開始日時あり、処理端末が自分
			Dim strHostName As String = My.Computer.Name
			strSQL &= "AND NOT (ISNULL(開始日時, '') != '1900/01/01' AND ISNULL(終了日時, '') = '1900/01/01' AND ISNULL(処理端末, '') != '') OR 処理端末 = '" & strHostName & "' "
			'strSQL &= "AND (ISNULL(開始日時, '') = '1900/01/01' OR ISNULL(開始日時, '') != '1900/01/01' AND ISNULL(終了日時, '') != '1900/01/01') OR (ISNULL(開始日時, '') != '1900/01/01' AND 処理端末 = '" & strHostName & "') "
			strSQL &= "ORDER BY 管理ID"
            Dim dt As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
            Dim elmBookletID() As CElement = Nothing
            For iBookletID As Integer = 0 To dt.Rows.Count - 1
                ReDim Preserve elmBookletID(iBookletID)
                elmBookletID(iBookletID) = New CElement
                elmBookletID(iBookletID).ID = dt.Rows(iBookletID)("管理ID")
                elmBookletID(iBookletID).NAME = dt.Rows(iBookletID)("納品フォルダ")
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
            'tempImage = codecs.Load(strFileName)
            Me.rivImage.Image = codecs.Load(strFileName)

            ''色深度の取得
            'Dim iBitsPerPixel = tempImage.BitsPerPixel
            ''画像が2値の場合のみアンチエイリアス処理をかける
            'If iBitsPerPixel = 1 Then
            '	'テンポラリイメージを8ビットグレイスケールに変換する
            '	Dim command As New ImageProcessing.GrayscaleCommand()
            '	command.BitsPerPixel = 8
            '	command.Run(tempImage)
            'End If
            ''画像ビューアに設定する
            'Me.rivImage.Image = tempImage
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

	'''' <summary>
	'''' 先頭の画像へ
	'''' </summary>
	'''' <remarks></remarks>
	'Private Sub MoveImageTop()

	'    If Me.C1FGridResult.Rows.Count <= 1 Then
	'        '画像が1つもなかったら
	'        Exit Sub
	'    End If

	'    Me.C1FGridResult.Row = 1

	'End Sub

	'''' <summary>
	'''' 前の画像へ
	'''' </summary>
	'''' <remarks></remarks>
	'Private Sub MoveImagePrev()

	'    If Me.C1FGridResult.Rows.Count <= 1 Then
	'        Exit Sub
	'    End If

	'    If Me.C1FGridResult.Row > 1 Then
	'        Me.C1FGridResult.Row = Me.C1FGridResult.Row - 1
	'    Else
	'        Me.C1FGridResult.Row = 1
	'    End If

	'End Sub

	'''' <summary>
	'''' 次の画像へ
	'''' </summary>
	'''' <remarks></remarks>
	'Private Sub MoveImageNext()

	'    If Me.C1FGridResult.Rows.Count <= 1 Then
	'        Exit Sub
	'    End If

	'    If Me.C1FGridResult.Row < Me.C1FGridResult.Rows.Count - 1 Then
	'        Me.C1FGridResult.Row = Me.C1FGridResult.Row + 1
	'    Else
	'        Me.C1FGridResult.Row = Me.C1FGridResult.Rows.Count - 1
	'    End If

	'End Sub

	'''' <summary>
	'''' 末尾の画像へ
	'''' </summary>
	'''' <remarks></remarks>
	'Private Sub MoveImageBottom()

	'       If Me.C1FGridResult.Rows.Count <= 1 Then
	'           Exit Sub
	'       End If

	'       Me.C1FGridResult.Row = Me.C1FGridResult.Rows.Count - 1

	'   End Sub

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

	'  ''' <summary>
	'  ''' FlexGridの背景色を変更する(1行単位)(目次部)
	'  ''' </summary>
	'  ''' <param name="iRow"></param>
	'  ''' <param name="iGridStyleName"></param>
	'  ''' <remarks></remarks>
	'  Private Sub ChangeBackColorMokuji(ByVal iRow As Integer, ByVal iGridStyleName As GridStyleName)
	''Dim frm As frmEntry = My.Forms.frmEntry

	''カスタムスタイルを作成する
	'With frm.C1FGridMokuji
	'          'デフォルトスタイル
	'          .Styles.Add("StyleDefault")
	'          .Styles("StyleDefault").BackColor = Color.White
	'          .Styles("StyleDefault").ForeColor = Color.Black
	'          '目次スタイル
	'          .Styles.Add("StyleTarget")
	'          .Styles("StyleTarget").BackColor = Color.LightSlateGray
	'          .Styles("StyleTarget").ForeColor = Color.Black
	'          'リンクスタイル
	'          .Styles.Add("StyleLink")
	'          .Styles("StyleLink").BackColor = Color.LightCoral
	'          .Styles("StyleLink").ForeColor = Color.Black

	'      End With

	'      Select Case iGridStyleName

	'          Case GridStyleName.StyleDefault
	'              'デフォルト
	'              frm.C1FGridMokuji.Rows(iRow).Style = frm.C1FGridMokuji.Styles("StyleDefault")

	'          Case GridStyleName.StyleTarget
	'              '目次
	'              frm.C1FGridMokuji.Rows(iRow).Style = frm.C1FGridMokuji.Styles("StyleTarget")

	'          Case GridStyleName.StyleLink
	'              'リンク
	'              frm.C1FGridMokuji.Rows(iRow).Style = frm.C1FGridMokuji.Styles("StyleLink")

	'      End Select

	'  End Sub

	'''' <summary>
	'''' FlexGridの背景色を変更する(1行単位)
	'''' </summary>
	'''' <param name="iRow"></param>
	'''' <param name="iGridStyleName"></param>
	'''' <remarks></remarks>
	'Private Sub ChangeBackColor(ByVal iRow As Integer, ByVal iGridStyleName As GridStyleName)
	'       'カスタムスタイルを作成する
	'       With C1FGridResult
	'           'デフォルトスタイル
	'           .Styles.Add("StyleDefault")
	'           .Styles("StyleDefault").BackColor = Color.White
	'           .Styles("StyleDefault").ForeColor = Color.Black
	'           '目次スタイル
	'           .Styles.Add("StyleTarget")
	'           .Styles("StyleTarget").BackColor = Color.LightSlateGray
	'           .Styles("StyleTarget").ForeColor = Color.Black
	'           'リンクスタイル
	'           .Styles.Add("StyleLink")
	'           .Styles("StyleLink").BackColor = Color.LightCoral
	'           .Styles("StyleLink").ForeColor = Color.Black

	'       End With

	'       Select Case iGridStyleName

	'           Case GridStyleName.StyleDefault
	'               'デフォルト
	'               Me.C1FGridResult.Rows(iRow).Style = Me.C1FGridResult.Styles("StyleDefault")

	'           Case GridStyleName.StyleTarget
	'               '目次
	'               Me.C1FGridResult.Rows(iRow).Style = Me.C1FGridResult.Styles("StyleTarget")

	'           Case GridStyleName.StyleLink
	'               'リンク
	'               Me.C1FGridResult.Rows(iRow).Style = Me.C1FGridResult.Styles("StyleLink")

	'       End Select

	'   End Sub

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
		Dim frm As frmEntry = My.Forms.frmEntry

		Try
            RemoveHandler C1FGridResult.EnterCell, AddressOf C1FGridResult_EnterCell
            Me.C1FGridResult.Rows.Count = 1
			'パス内の画像ファイルを全て取得する
			'同時に管理表の備考も取得する
			Dim iBookletID As Integer = Me.cmbBookletID.SelectedValue
			strSQL = "SELECT M番号, 仮フォルダ, 備考 FROM M_管理表 "
			strSQL &= "WHERE 管理ID = '" & Me.cmbBookletID.SelectedValue & "'"
			Dim dt As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)

			'備考の反映
			Dim strRemarks As String = dt.Rows(0)("備考").ToString.Replace("\n", vbNewLine)
			Me.txtRemarks.Text = strRemarks

			'パスを作成する
			XmlSettings.LoadFromXmlFile()
			Dim strTargetPath As String = XmlSettings.Instance.ImagePath & "\" & dt.Rows(0)("M番号") & "\" & dt.Rows(0)("仮フォルダ")
			Dim strImageFiles As String() = GetFilesMostDeep(strTargetPath, {"*.jpg", "*.pdf", "*.tif"})
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
            strSQL = "SELECT COUNT(管理ID) FROM T_目次 "
            strSQL &= "WHERE 管理ID = " & iBookletID
            If CInt(sqlProcess.DB_EXECUTE_SCALAR(strSQL)) > 0 Then
                '1件以上のレコードが存在した
                strSQL = "SELECT リンク FROM T_目次 "
                strSQL &= "WHERE 管理ID = " & iBookletID
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
                        'ヒットしたらリンク項目をTrueにする
                        Me.C1FGridResult(iIndex, "リンク") = True
						'スタイルを変更する
						LinkPasteProcess.ChangeBackColor(Me.C1FGridResult, iIndex, LinkPasteProcess.GridStyleName.StyleLink)
						'ChangeBackColor(iIndex, GridStyleName.StyleLink)
					End If
                Next
            End If

            '削除フラグの反映
            strSQL = "SELECT COUNT(管理ID) FROM T_フラグ "
            strSQL &= "WHERE 管理ID = " & iBookletID & " "
            strSQL &= "AND 種別ID = 30"
            If CInt(sqlProcess.DB_EXECUTE_SCALAR(strSQL)) > 0 Then
                '1件以上のレコードが存在した
                strSQL = "SELECT ファイル名, フラグID FROM T_フラグ "
                strSQL &= "WHERE 管理ID = " & iBookletID & " "
                strSQL &= "AND 種別ID = 30"
                Dim dtFileName As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
                Dim iIndex As Integer = 0
                For iRow As Integer = 0 To dtFileName.Rows.Count - 1
                    '頭から検索を行う
                    iIndex = Me.C1FGridResult.FindRow(dtFileName.Rows(iRow)("ファイル名"), 1, 1, False)  'ファイル名を検索
                    If iIndex < 0 Then
                        '検索ヒットしなかったら抜ける
                        Continue For
                    Else
                        'ヒットしたら削除項目をTrueにする
                        Me.C1FGridResult(iIndex, "削除") = True
                        'フラグIDをセット
                        Me.C1FGridResult(iIndex, "フラグID") = dtFileName.Rows(iRow)("フラグID")
						'スタイルを変更する
						LinkPasteProcess.ChangeBackColor(Me.C1FGridResult, iIndex, LinkPasteProcess.GridStyleName.StyleTarget)
						'ChangeBackColor(iIndex, GridStyleName.StyleTarget)
					End If
                Next
            End If

			'資料情報を取得
			'目次単位で値を変更するようにしたため、初期段階では空レコードを追加しておく
			'strSQL = "SELECT 表示用, 県名, 資料名, 副題, 対象年, 刊行者名, 刊行年月 "
			'         strSQL &= "FROM M_資料 "
			'         strSQL &= "WHERE 管理ID = '" & Me.cmbBookletID.SelectedValue & "' "
			'         dt = sqlProcess.DB_SELECT_DATATABLE(strSQL)
			iRecordCount = 0
            If dt.Rows.Count = 1 Then
                iRecordCount += 1
                Me.C1FGridDoc.Rows.Count = 8

                For iRow As Integer = 1 To 7

                    Select Case iRow
                        Case 1
                            Me.C1FGridDoc(iRow, "No") = iRow
                            Me.C1FGridDoc(iRow, "項目名") = "表示用"
							Me.C1FGridDoc(iRow, "内容") = ""
						Case 2
                            Me.C1FGridDoc(iRow, "No") = iRow
                            Me.C1FGridDoc(iRow, "項目名") = "県名"
							Me.C1FGridDoc(iRow, "内容") = ""
						Case 3
                            Me.C1FGridDoc(iRow, "No") = iRow
                            Me.C1FGridDoc(iRow, "項目名") = "資料名"
							Me.C1FGridDoc(iRow, "内容") = ""
						Case 4
                            Me.C1FGridDoc(iRow, "No") = iRow
                            Me.C1FGridDoc(iRow, "項目名") = "副題"
							Me.C1FGridDoc(iRow, "内容") = ""
						Case 5
                            Me.C1FGridDoc(iRow, "No") = iRow
                            Me.C1FGridDoc(iRow, "項目名") = "対象年"
							Me.C1FGridDoc(iRow, "内容") = ""
						Case 6
                            Me.C1FGridDoc(iRow, "No") = iRow
                            Me.C1FGridDoc(iRow, "項目名") = "刊行者名"
							Me.C1FGridDoc(iRow, "内容") = ""
						Case 7
                            Me.C1FGridDoc(iRow, "No") = iRow
                            Me.C1FGridDoc(iRow, "項目名") = "刊行年月"
							Me.C1FGridDoc(iRow, "内容") = ""
					End Select

                Next

            Else
                Me.C1FGridDoc.Rows.Count = 1
            End If

			'フラグ情報を取得
			LinkPasteProcess.ViewFlagInfo(Me.C1FGridFlag, CInt(Me.cmbBookletID.SelectedValue))

			'目次フォームに目次内容を表示させる
			strSQL = "SELECT T1.管理ID, T1.連番, T1.レコード番号, T1.表示用, T1.行番号, T1.リンク, T1.リンクTO, T2.フラグID, T2.フラグ, "
			strSQL &= "T1.県名, T1.資料名, T1.副題, T1.対象年, T1.刊行者名, T1.刊行年月, T1.分類1, T1.分類2, T1.分類番号, T1.項目, "
			strSQL &= "T1.番号1, T1.タイトル1, T1.番号2, T1.タイトル2, T1.番号3, T1.タイトル3, T1.番号4, T1.タイトル4, T1.番号5, T1.タイトル5, T1.備考 "
			strSQL &= "FROM T_目次 AS T1 INNER JOIN "
			strSQL &= "M_フラグ AS T2 ON T1.フラグID = T2.フラグID "
            strSQL &= "AND T2.種別ID = 20 "
			strSQL &= "WHERE T1.管理ID = " & Me.cmbBookletID.SelectedValue & " "
			strSQL &= "ORDER BY T1.連番"
			dt = sqlProcess.DB_SELECT_DATATABLE(strSQL)
            iRecordCount = 0
            frm.C1FGridMokuji.BeginUpdate()
			For iRow As Integer = 0 To dt.Rows.Count - 1
				iRecordCount += 1
				frm.C1FGridMokuji.Rows.Count = iRecordCount + 1
				frm.C1FGridMokuji(iRecordCount, "No") = iRecordCount
				frm.C1FGridMokuji(iRecordCount, "管理ID") = dt.Rows(iRow)("管理ID")
				frm.C1FGridMokuji(iRecordCount, "連番") = dt.Rows(iRow)("連番")
				frm.C1FGridMokuji(iRecordCount, "レコード番号") = dt.Rows(iRow)("レコード番号")
				frm.C1FGridMokuji(iRecordCount, "表示用") = dt.Rows(iRow)("表示用")
				frm.C1FGridMokuji(iRecordCount, "行番号") = dt.Rows(iRow)("行番号")
				frm.C1FGridMokuji(iRecordCount, "リンク") = dt.Rows(iRow)("リンク")
				frm.C1FGridMokuji(iRecordCount, "リンクTO") = dt.Rows(iRow)("リンクTO")
				'リンクフラグが「該当イメージ無し(5)」だった場合は、フラグ無し(0)を表示させる
				'※完了時にフラグID=5が残りっぱなしになるおそれがあるため
				If dt.Rows(iRow)("フラグID") = 5 Then
					frm.C1FGridMokuji(iRecordCount, "フラグID") = 0
					frm.C1FGridMokuji(iRecordCount, "フラグ") = ""
				Else
					frm.C1FGridMokuji(iRecordCount, "フラグID") = dt.Rows(iRow)("フラグID")
					frm.C1FGridMokuji(iRecordCount, "フラグ") = dt.Rows(iRow)("フラグ")
				End If

				frm.C1FGridMokuji(iRecordCount, "県名") = dt.Rows(iRow)("県名")
				frm.C1FGridMokuji(iRecordCount, "資料名") = dt.Rows(iRow)("資料名")
				frm.C1FGridMokuji(iRecordCount, "副題") = dt.Rows(iRow)("副題")
				frm.C1FGridMokuji(iRecordCount, "対象年") = dt.Rows(iRow)("対象年")
				frm.C1FGridMokuji(iRecordCount, "刊行者名") = dt.Rows(iRow)("刊行者名")
				frm.C1FGridMokuji(iRecordCount, "刊行年月") = dt.Rows(iRow)("刊行年月")
				frm.C1FGridMokuji(iRecordCount, "分類1") = dt.Rows(iRow)("分類1")
				frm.C1FGridMokuji(iRecordCount, "分類2") = dt.Rows(iRow)("分類2")
				frm.C1FGridMokuji(iRecordCount, "分類番号") = dt.Rows(iRow)("分類番号")
				frm.C1FGridMokuji(iRecordCount, "項目") = dt.Rows(iRow)("項目")
				frm.C1FGridMokuji(iRecordCount, "番号1") = dt.Rows(iRow)("番号1")
				frm.C1FGridMokuji(iRecordCount, "タイトル1") = dt.Rows(iRow)("タイトル1")
				frm.C1FGridMokuji(iRecordCount, "番号2") = dt.Rows(iRow)("番号2")
				frm.C1FGridMokuji(iRecordCount, "タイトル2") = dt.Rows(iRow)("タイトル2")
				frm.C1FGridMokuji(iRecordCount, "番号3") = dt.Rows(iRow)("番号3")
				frm.C1FGridMokuji(iRecordCount, "タイトル3") = dt.Rows(iRow)("タイトル3")
				frm.C1FGridMokuji(iRecordCount, "番号4") = dt.Rows(iRow)("番号4")
				frm.C1FGridMokuji(iRecordCount, "タイトル4") = dt.Rows(iRow)("タイトル4")
				frm.C1FGridMokuji(iRecordCount, "番号5") = dt.Rows(iRow)("番号5")
				frm.C1FGridMokuji(iRecordCount, "タイトル5") = dt.Rows(iRow)("タイトル5")
				frm.C1FGridMokuji(iRecordCount, "備考") = dt.Rows(iRow)("備考")
				frm.C1FGridMokuji(iRecordCount, "変更フラグ") = 0

				'管理者であり、変更フラグが立っていたらT_目次比較から該当レコードを取得して、相違しているセルの
				'スタイルを「相違スタイル」にする
				'=========================================================
				If IsAdmin Then
					'管理者
					strSQL = "SELECT COUNT(*) FROM T_フラグ "
					strSQL &= "WHERE 管理ID = " & dt.Rows(iRow)("管理ID")
					strSQL &= "AND 連番 = " & dt.Rows(iRow)("連番")
					strSQL &= "AND 種別ID = 40"   '変更フラグは種別ID＝40
					If CInt(sqlProcess.DB_EXECUTE_SCALAR(strSQL)) > 0 Then
						'変更フラグが存在した
						strSQL = "SELECT 分類番号, 項目, 番号1, タイトル1, 番号2, タイトル2, 番号3, タイトル3, "
						strSQL &= "番号4, タイトル4, 番号5, タイトル5 "
						strSQL &= "FROM T_目次比較 "
						strSQL &= "WHERE レコード番号 = '" & dt.Rows(iRow)("レコード番号") & "'"
						Dim dtDifference As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
						If dtDifference.Rows.Count > 0 Then
							'分類番号
							If Not dt.Rows(iRow)("分類番号") = dtDifference.Rows(0)("分類番号") Then
								LinkPasteProcess.ChangeCellBackColor(frm.C1FGridMokuji, iRecordCount, 18, LinkPasteProcess.GridStyleName.StyleDifference)
							End If
							'項目
							If Not dt.Rows(iRow)("項目") = dtDifference.Rows(0)("項目") Then
								LinkPasteProcess.ChangeCellBackColor(frm.C1FGridMokuji, iRecordCount, 19, LinkPasteProcess.GridStyleName.StyleDifference)
							End If
							'番号１
							If Not dt.Rows(iRow)("番号1") = dtDifference.Rows(0)("番号1") Then
								LinkPasteProcess.ChangeCellBackColor(frm.C1FGridMokuji, iRecordCount, 20, LinkPasteProcess.GridStyleName.StyleDifference)
							End If
							'タイトル１
							If Not dt.Rows(iRow)("タイトル1") = dtDifference.Rows(0)("タイトル1") Then
								LinkPasteProcess.ChangeCellBackColor(frm.C1FGridMokuji, iRecordCount, 21, LinkPasteProcess.GridStyleName.StyleDifference)
							End If
							'番号2
							If Not dt.Rows(iRow)("番号2") = dtDifference.Rows(0)("番号2") Then
								LinkPasteProcess.ChangeCellBackColor(frm.C1FGridMokuji, iRecordCount, 22, LinkPasteProcess.GridStyleName.StyleDifference)
							End If
							'タイトル2
							If Not dt.Rows(iRow)("タイトル2") = dtDifference.Rows(0)("タイトル2") Then
								LinkPasteProcess.ChangeCellBackColor(frm.C1FGridMokuji, iRecordCount, 23, LinkPasteProcess.GridStyleName.StyleDifference)
							End If
							'番号3
							If Not dt.Rows(iRow)("番号3") = dtDifference.Rows(0)("番号3") Then
								LinkPasteProcess.ChangeCellBackColor(frm.C1FGridMokuji, iRecordCount, 24, LinkPasteProcess.GridStyleName.StyleDifference)
							End If
							'タイトル3
							If Not dt.Rows(iRow)("タイトル3") = dtDifference.Rows(0)("タイトル3") Then
								LinkPasteProcess.ChangeCellBackColor(frm.C1FGridMokuji, iRecordCount, 25, LinkPasteProcess.GridStyleName.StyleDifference)
							End If
							'番号4
							If Not dt.Rows(iRow)("番号4") = dtDifference.Rows(0)("番号4") Then
								LinkPasteProcess.ChangeCellBackColor(frm.C1FGridMokuji, iRecordCount, 26, LinkPasteProcess.GridStyleName.StyleDifference)
							End If
							'タイトル4
							If Not dt.Rows(iRow)("タイトル4") = dtDifference.Rows(0)("タイトル4") Then
								LinkPasteProcess.ChangeCellBackColor(frm.C1FGridMokuji, iRecordCount, 27, LinkPasteProcess.GridStyleName.StyleDifference)
							End If
							'番号5
							If Not dt.Rows(iRow)("番号5") = dtDifference.Rows(0)("番号5") Then
								LinkPasteProcess.ChangeCellBackColor(frm.C1FGridMokuji, iRecordCount, 28, LinkPasteProcess.GridStyleName.StyleDifference)
							End If
							'タイトル5
							If Not dt.Rows(iRow)("タイトル5") = dtDifference.Rows(0)("タイトル5") Then
								LinkPasteProcess.ChangeCellBackColor(frm.C1FGridMokuji, iRecordCount, 29, LinkPasteProcess.GridStyleName.StyleDifference)
							End If
						End If
					End If
				End If

				'高さを自動判定する
				frm.C1FGridMokuji.AutoSizeRow(iRecordCount)

				'フラグIDに値が入っていたらレコードの背景色を変更する
				If Not CInt(frm.C1FGridMokuji(iRecordCount, "フラグID")) = 0 Then
					LinkPasteProcess.ChangeBackColor(frm.C1FGridMokuji, iRecordCount, LinkPasteProcess.GridStyleName.StyleTarget)
					'ChangeBackColorMokuji(iRecordCount, GridStyleName.StyleTarget)
				Else
					LinkPasteProcess.ChangeBackColor(frm.C1FGridMokuji, iRecordCount, LinkPasteProcess.GridStyleName.StyleDefault)
					'ChangeBackColorMokuji(iRecordCount, GridStyleName.StyleDefault)
				End If

			Next

			'各目次レコードに変更フラグを付与する
			strSQL = "SELECT 連番, フラグID FROM T_フラグ "
			strSQL &= "WHERE 管理ID = " & Me.cmbBookletID.SelectedValue & " "
			strSQL &= "AND 種別ID = 40"
			dt = sqlProcess.DB_SELECT_DATATABLE(strSQL)

			For iRow As Integer = 0 To dt.Rows.Count - 1
				'連番項目を検索
				Dim iHit As Integer = frm.C1FGridMokuji.FindRow(dt.Rows(iRow)("連番"), 1, 2, False)
				If iHit > 0 Then
					frm.C1FGridMokuji(iHit, "変更フラグ") = 1
				End If
			Next

			frm.C1FGridMokuji.AutoSizeCols()
            frm.C1FGridMokuji.EndUpdate()

            'ステータスバーに画像数を表示
            Me.lblImageCount.Text = (Me.C1FGridResult.Rows.Count - 1).ToString & "images"

            AddHandler C1FGridResult.EnterCell, AddressOf C1FGridResult_EnterCell

            If Me.C1FGridResult.Rows.Count > 1 Then
                Me.C1FGridResult.Row = 1
                SelectImage(1)
            End If

			''ファイル列挙終了時に開始ボタンを有効化する
			'Me.btnStart.Enabled = True

		Catch ex As Exception

            Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message)
            MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally

            sqlProcess.Close()
            Me.btnStart.Enabled = True

        End Try

    End Sub

	'''' <summary>
	'''' フラグ情報をグリッドにセットする
	'''' </summary>
	'Private Sub ViewFlagInfo()

	'    Dim strSQL As String = ""
	'    Dim sqlProcess As New SQLProcess
	'    Dim iBookletID As Integer = CInt(Me.cmbBookletID.SelectedValue)

	'    Try
	'        'フラグ情報を取得
	'        strSQL = "SELECT T3.種別, T1.ファイル名, T1.レコード番号, T2.フラグ, T2.種別ID "
	'        strSQL &= "FROM T_フラグ AS T1 INNER JOIN "
	'        strSQL &= "M_フラグ AS T2 ON T1.種別ID = T2.種別ID AND T1.フラグID = T2.フラグID INNER JOIN "
	'        strSQL &= "M_種別 AS T3 ON T1.種別ID = T3.種別ID "
	'        strSQL &= "WHERE 管理ID = " & iBookletID & " "
	'        strSQL &= "ORDER BY T1.種別ID, T1.連番"
	'        Dim dt As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
	'        Dim iRecordCount As Integer = 0
	'        For iRow As Integer = 0 To dt.Rows.Count - 1
	'            iRecordCount += 1
	'            Me.C1FGridFlag.Rows.Count = iRecordCount + 1
	'            Me.C1FGridFlag(iRecordCount, "No") = iRecordCount
	'            Me.C1FGridFlag(iRecordCount, "種別") = dt.Rows(iRow)("種別")
	'            Me.C1FGridFlag(iRecordCount, "ファイル名") = dt.Rows(iRow)("ファイル名")
	'            Me.C1FGridFlag(iRecordCount, "レコード番号") = dt.Rows(iRow)("レコード番号")
	'            Me.C1FGridFlag(iRecordCount, "フラグ") = dt.Rows(iRow)("フラグ")
	'            Me.C1FGridFlag(iRecordCount, "種別ID") = dt.Rows(iRow)("種別ID")
	'        Next

	'    Catch ex As Exception

	'        Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message)
	'        MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

	'    Finally

	'        sqlProcess.Close()

	'    End Try

	'End Sub

	''' <summary>
	''' 値を初期化する
	''' </summary>
	Private Sub ClearValue(Optional ByVal blnAbort As Boolean = False)

		Dim frm As frmEntry = My.Forms.frmEntry

		Me.C1FGridResult.Rows.Count = 1
		Me.C1FGridDoc.Rows.Count = 1
		Me.C1FGridFlag.Rows.Count = 1
		frm.C1FGridMokuji.Rows.Count = 1

		Me.cmbPrefecture.Enabled = True
		Me.cmbBookletID.Enabled = True
		Me.btnStart.Enabled = True
		Me.btnFinish.Enabled = False
		Me.btnAbort.Enabled = False

		Me.lblImageCount.Text = ""
		Me.rivImage.Visible = False
		frm.C1FGridMokuji.Enabled = False

		Me.txtRemarks.Text = ""

		'処理内容を初期化
		LinkProcess = 0

		'中断の場合は処理端末を削除しない
		If Not blnAbort Then

			'値初期化時に処理端末をリセットする
			Dim strSQL As String = ""
			Dim sqlProcess As New SQLProcess

			Try
				strSQL = "UPDATE M_管理表 SET 処理端末 = N'' "
				strSQL &= "WHERE 処理端末 = '" & My.Computer.Name & "'"
				sqlProcess.DB_UPDATE(strSQL)

			Catch ex As Exception


				Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message)
				MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

			Finally

				sqlProcess.Close()

			End Try

		End If

	End Sub

	Private Sub ViewEntryForm()

        Try
			'エントリーフォームが表示されているか検証する
			If My.Forms.frmEntry.Visible = False Then

				With My.Forms.frmEntry
					.StartPosition = FormStartPosition.CenterScreen
					.Owner = Me '常に親ウィンドウの手前に表示
					'管理者か運用者かで分岐
					If IsAdmin Then
						'管理者
						'元データを表示させる
						.GroupBox1.Width = 300
					Else
						'運用者
						'元データを隠す
						.GroupBox1.Width = 0
					End If
					.Show(Me)
				End With
			End If

		Catch ex As Exception

            Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message)
            MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub

	'   ''' <summary>
	'   ''' リンクを設定する
	'   ''' </summary>
	'   Private Sub SetLink()

	'	''2017/03/22
	'	''2次の場合は機能させない
	'	'If LinkProcess = 2 Then
	'	'    MessageBox.Show("2次処理はリンク終端の編集のみ可能です", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
	'	'    Exit Sub
	'	'End If

	'	'Dim frm As frmEntry = My.Forms.frmEntry
	'	LinkPasteProcess.SetLink(Me.C1FGridResult, frm.C1FGridMokuji, LinkFromTo.LinkFrom)

	'	''今現在選択されているファイル名をリンク部分にセットする
	'	'Dim iIndex As Integer = 0

	'	'      Dim iRow As Integer = frm.C1FGridMokuji.Row
	'	'      Dim iTargetRow As Integer = 0
	'	''===================================================================
	'	''前レコードより数値が若い場合は警告を出す
	'	'If iRow > 1 Then
	'	'	'1レコード目はチェックしない
	'	'	'前レコードのリンク値がNULLの場合は遡ってリンクを探す
	'	'	For i As Integer = iRow - 1 To 1 Step -1
	'	'		If Not IsNull(frm.C1FGridMokuji(i, "リンク")) Then
	'	'			iTargetRow = i
	'	'			Exit For
	'	'		End If
	'	'	Next
	'	'	'If IsNull(Me.C1FGridMokuji(iRow - 1, "リンク")) Then
	'	'	'	MessageBox.Show("上から順にリンクを埋めてください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
	'	'	'	Exit Sub
	'	'	'End If
	'	'	'iTargetRowが0の場合は初回リンクとみなしてスキップする
	'	'	If iTargetRow > 0 Then
	'	'		Dim iFileNo As Integer = CInt(Me.C1FGridResult(Me.C1FGridResult.Row, "ファイル名"))  '選択されているファイル名の数値化
	'	'		Dim iBeforeLink As Integer = CInt(frm.C1FGridMokuji(iTargetRow, "リンク"))    '目次部の選択されているレコードの前のレコードのリンク番号を数値化
	'	'		If iBeforeLink > iFileNo Then
	'	'			'これからリンクを貼ろうとしている値が前レコードのリンク数値より小さかった場合、警告を出す
	'	'			MessageBox.Show("前レコードのリンクより前のファイルのリンクを貼ろうとしています" & vbNewLine & "リンクが正しいか見直してください", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning)
	'	'			'Exit Sub
	'	'		End If
	'	'	End If
	'	'End If
	'	''===================================================================

	'	''削除フラグが立っている場合はエラーとする
	'	''If Me.C1FGridResult(Me.C1FGridResult.Row, "削除") = True Then
	'	''	MessageBox.Show("削除フラグが立っているためリンクに設定できません", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
	'	''	Exit Sub
	'	''End If

	'	'If IsNull(frm.C1FGridMokuji(iRow, "リンク")) Then
	'	'          frm.C1FGridMokuji(iRow, "リンク") = Me.C1FGridResult(Me.C1FGridResult.Row, "ファイル名")
	'	'          'リンクTOにも同様の値をセットする
	'	'          frm.C1FGridMokuji(iRow, "リンクTO") = Me.C1FGridResult(Me.C1FGridResult.Row, "ファイル名")
	'	'      Else
	'	'          'NULLでなかったらファイルリストのリンクフラグを取り下げる
	'	'          iIndex = Me.C1FGridResult.FindRow(frm.C1FGridMokuji(iRow, "リンク"), 1, 1, False)
	'	'          Me.C1FGridResult(iIndex, "リンク") = False
	'	'          ChangeBackColor(iIndex, GridStyleName.StyleDefault)
	'	'          frm.C1FGridMokuji(iRow, "リンク") = Me.C1FGridResult(Me.C1FGridResult.Row, "ファイル名")
	'	'          'リンクTOにも同様の値をセットする
	'	'          frm.C1FGridMokuji(iRow, "リンクTO") = Me.C1FGridResult(Me.C1FGridResult.Row, "ファイル名")
	'	'      End If

	'	'      iIndex = Me.C1FGridResult.FindRow(frm.C1FGridMokuji(iRow, "リンク"), 1, 1, False)
	'	'      Me.C1FGridResult(iIndex, "リンク") = True

	'	'      ''===================================================================
	'	'      ''2017/03/21
	'	'      ''前レコードのリンクTOに現在レコードのリンク-1の値をセットする
	'	'      ''前レコードのリンクと現レコードのリンクの値が同一の場合は、前レコードのリンクTOも同一にする
	'	'      'If iRow > 1 Then
	'	'      '    '1レコード目はチェックしない
	'	'      '    'iTargetRowが0の場合は初回リンクとみなしてスキップする
	'	'      '    If iTargetRow > 0 Then
	'	'      '        '現在レコードのリンク値を取得
	'	'      '        'If Me.C1FGridMokuji(iRow - 1, "リンク") = Me.C1FGridMokuji(iRow, "リンク") Then
	'	'      '        '	Me.C1FGridMokuji(iRow - 1, "リンクTO") = Me.C1FGridMokuji(iRow, "リンク")
	'	'      '        If Me.C1FGridMokuji(iTargetRow, "リンク") = Me.C1FGridMokuji(iRow, "リンク") Then
	'	'      '            Me.C1FGridMokuji(iTargetRow, "リンクTO") = Me.C1FGridMokuji(iRow, "リンク")
	'	'      '        Else
	'	'      '            Dim iLinkValue As Integer = CInt(Me.C1FGridMokuji(iRow, "リンク")) - 1
	'	'      '            'Me.C1FGridMokuji(iRow - 1, "リンクTO") = iLinkValue.ToString("0000")
	'	'      '            Me.C1FGridMokuji(iTargetRow, "リンクTO") = iLinkValue.ToString("0000")
	'	'      '        End If
	'	'      '        '最終レコードの場合、リンクTOに最終ファイルをセットする
	'	'      '        If Me.C1FGridMokuji.Row = Me.C1FGridMokuji.Rows.Count - 1 Then
	'	'      '            Me.C1FGridMokuji(iRow, "リンクTO") = Me.C1FGridResult(Me.C1FGridResult.Rows.Count - 1, "ファイル名")
	'	'      '        End If
	'	'      '    End If

	'	'      'End If
	'	'      ''===================================================================

	'	'      'FlashingGrid()

	'	'      'Do Until Me.Timer1.Enabled = False
	'	'      '    Application.DoEvents()
	'	'      'Loop
	'	'      ChangeBackColor(iIndex, GridStyleName.StyleLink)
	'	'      'LinkCheck(iRow)

	'	'      '目次の行を1レコードすすめる
	'	'      NextMokuji()

	'End Sub

	'''' <summary>
	'''' リンクを削除する
	'''' </summary>
	'Private Sub DelLink()

	'	''2017/03/22
	'	''2次の場合は機能させない
	'	'If LinkProcess = 2 Then
	'	'    MessageBox.Show("2次処理はリンク終端の編集のみ可能です", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
	'	'    Exit Sub
	'	'End If
	'	'Dim frm As frmEntry = My.Forms.frmEntry
	'	LinkPasteProcess.DelLink(Me.C1FGridResult, frm.C1FGridMokuji, LinkFromTo.LinkFrom)

	'	''現在行のリンク項目を削除
	'	'Dim iRow As Integer = frm.C1FGridMokuji.Row
	'	'      'リンクがNULLだった場合、処理を抜ける
	'	'      If IsNull(frm.C1FGridMokuji(iRow, "リンク")) Then
	'	'          Exit Sub
	'	'      End If
	'	'      Dim iIndex As Integer = Me.C1FGridResult.FindRow(frm.C1FGridMokuji(iRow, "リンク"), 1, 1, False)
	'	'      Me.C1FGridResult(iIndex, "リンク") = False
	'	'      ChangeBackColor(iIndex, GridStyleName.StyleDefault)
	'	'      frm.C1FGridMokuji(iRow, "リンク") = ""

	'	'FlashingGrid()

	'End Sub

	'''' <summary>
	'''' リンク終りをセットする
	'''' </summary>
	'Private Sub SetLinkTo()

	'	'Dim frm As frmEntry = My.Forms.frmEntry
	'	LinkPasteProcess.SetLink(Me.C1FGridResult, frm.C1FGridMokuji, LinkFromTo.LinkTo)

	'	'Dim iRow As Integer = frm.C1FGridMokuji.Row

	'	''削除フラグが立っている場合はエラーとする
	'	''If Me.C1FGridResult(Me.C1FGridResult.Row, "削除") = True Then
	'	''	MessageBox.Show("削除フラグが立っているためリンクに設定できません", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
	'	''	Exit Sub
	'	''End If

	'	'frm.C1FGridMokuji(iRow, "リンクTO") = Me.C1FGridResult(Me.C1FGridResult.Row, "ファイル名")

	'End Sub

	'''' <summary>
	'''' リンク終りを削除する
	'''' </summary>
	'Private Sub DelLinkTo()

	'	'Dim frm As frmEntry = My.Forms.frmEntry
	'	LinkPasteProcess.DelLink(Me.C1FGridResult, frm.C1FGridMokuji, LinkFromTo.LinkTo)

	'	'Dim iRow As Integer = frm.C1FGridMokuji.Row
	'	'      frm.C1FGridMokuji(iRow, "リンクTO") = ""

	'End Sub

	'''' <summary>
	'''' 次の目次タイトルを選択する
	'''' </summary>
	'Private Sub NextMokuji()

	'    Dim frm As frmEntry = My.Forms.frmEntry

	'    If frm.C1FGridMokuji.Row = frm.C1FGridMokuji.Rows.Count - 1 Then
	'        '最終行だった場合何もしない
	'        Exit Sub
	'    End If

	'    frm.C1FGridMokuji.Row += 1

	'End Sub

	''' <summary>
	''' 目次データをデータベースに保存する
	''' </summary>
	''' <returns></returns>
	Private Function RegistData() As Boolean

        Dim strSQL As String = ""
        Dim sqlProcess As New SQLProcess
		Dim frm As frmEntry = My.Forms.frmEntry

		Try
            '目次テーブルのバックアップ
            Dim strHostName As String = My.Computer.Name    '端末名
            Dim iBookletID As Integer = CInt(Me.cmbBookletID.SelectedValue)  '管理ID
            Dim strBackupDate As String = Date.Now.ToString("yyyy/MM/dd HH:mm:ss")
            strSQL = "SELECT ISNULL(MAX(履歴ID), 0) + 1 AS 履歴ID FROM T_目次バックアップ"
            Dim strRirekiID As String = sqlProcess.DB_EXECUTE_SCALAR(strSQL)
            Dim strTitle As String = ""

            'フラグデータの削除
            '管理表のフラグデータは削除しない
            strSQL = "DELETE FROM T_フラグ "
            strSQL &= "WHERE 管理ID = " & iBookletID & " "
            strSQL &= "AND 種別ID != 10"
            sqlProcess.DB_UPDATE(strSQL)

			'グリッドより1レコードずつINSERTする
			For iRow As Integer = 1 To frm.C1FGridMokuji.Rows.Count - 1
				'連番項目がなかった場合、データ変更検証をスキップする
				If IsNull(frm.C1FGridMokuji(iRow, "連番")) Then

				Else
					'グリッド内のデータとT_目次内のデータの相違を確かめて相違していたら変更フラグを立てる
					strSQL = "SELECT 分類番号, 項目, 番号1, タイトル1, 番号2, タイトル2, 番号3, タイトル3, 番号4, タイトル4, 番号5, タイトル5 "
					strSQL &= "FROM T_目次 "
					strSQL &= "WHERE 管理ID = " & iBookletID & " "
					strSQL &= "AND 連番 = " & frm.C1FGridMokuji(iRow, "連番")
					Dim dt As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
					If dt.Rows(0)("分類番号") = frm.C1FGridMokuji(iRow, "分類番号") And
						dt.Rows(0)("項目") = frm.C1FGridMokuji(iRow, "項目") And
						dt.Rows(0)("番号1") = frm.C1FGridMokuji(iRow, "番号1") And
						dt.Rows(0)("タイトル1") = frm.C1FGridMokuji(iRow, "タイトル1") And
						dt.Rows(0)("番号2") = frm.C1FGridMokuji(iRow, "番号2") And
						dt.Rows(0)("タイトル2") = frm.C1FGridMokuji(iRow, "タイトル2") And
						dt.Rows(0)("番号3") = frm.C1FGridMokuji(iRow, "番号3") And
						dt.Rows(0)("タイトル3") = frm.C1FGridMokuji(iRow, "タイトル3") And
						dt.Rows(0)("番号4") = frm.C1FGridMokuji(iRow, "番号4") And
						dt.Rows(0)("タイトル4") = frm.C1FGridMokuji(iRow, "タイトル4") And
						dt.Rows(0)("番号5") = frm.C1FGridMokuji(iRow, "番号5") And
						dt.Rows(0)("タイトル5") = frm.C1FGridMokuji(iRow, "タイトル5") Then
						'全て合致した
					Else
						'合致しない項目があったら変更フラグを立てる
						'※新しく振り直した連番でフラグ情報を書き込む
						'連番の最大値＋1を取得
						strSQL = "SELECT ISNULL(MAX(登録連番), 0) + 1 FROM T_フラグ "
						strSQL &= "WHERE 管理ID = " & iBookletID
						Dim iMax As Integer = CInt(sqlProcess.DB_EXECUTE_SCALAR(strSQL))

						Dim strRecordNo As String = frm.C1FGridMokuji(iRow, "レコード番号")
						Dim iFlagID As Integer = 1
						strSQL = "INSERT INTO T_フラグ (管理ID, 登録連番, 連番, 種別ID, フラグID, ファイル名, レコード番号, 管理者確認) "
						strSQL &= "VALUES (" & iBookletID   '管理ID
						strSQL &= ", " & iMax   '登録連番
						strSQL &= ", " & iRow   '振り直した連番
						strSQL &= ", 40"    '種別ID
						strSQL &= ", " & iFlagID    'フラグID
						strSQL &= ", N''"   'ファイル名
						strSQL &= ", N'" & strRecordNo & "', 0)"    'レコード番号、管理者確認
						sqlProcess.DB_UPDATE(strSQL)

					End If

				End If

				strSQL = "INSERT INTO T_目次バックアップ (履歴ID, 履歴ID連番, 端末名, 管理ID, 連番, レコード番号, 表示用, 行番号, 県名, 資料名, 副題, 対象年, 刊行者名, 刊行年月, 分類1, 分類2, 分類番号, 項目, "
				strSQL &= "番号1, タイトル1, 番号2, タイトル2, 番号3, タイトル3, 番号4, タイトル4, 番号5, タイトル5, フォルダ名, リンク, リンクTO, 備考, フラグID, 登録日時) "
				strSQL &= "VALUES("
				strSQL &= strRirekiID   '履歴ID
				strSQL &= ", " & iRow   '履歴ID連番
				strSQL &= ", N'" & strHostName & "'"    '端末名
				strSQL &= ", " & iBookletID   '管理ID
				strSQL &= ", " & iRow   '振り直した連番
				strSQL &= ", N'" & frm.C1FGridMokuji.Rows(iRow)("レコード番号") & "'"   'レコード番号
				strSQL &= ", N'" & frm.C1FGridMokuji.Rows(iRow)("表示用") & "'"
				strSQL &= ", " & IIf(IsNull(frm.C1FGridMokuji.Rows(iRow)("行番号")), 0, frm.C1FGridMokuji.Rows(iRow)("行番号"))
				strSQL &= ", N'" & frm.C1FGridMokuji.Rows(iRow)("県名") & "'"
				strSQL &= ", N'" & frm.C1FGridMokuji.Rows(iRow)("資料名") & "'"
				strSQL &= ", N'" & frm.C1FGridMokuji.Rows(iRow)("副題") & "'"
				strSQL &= ", N'" & frm.C1FGridMokuji.Rows(iRow)("対象年") & "'"
				strSQL &= ", N'" & frm.C1FGridMokuji.Rows(iRow)("刊行者名") & "'"
				strSQL &= ", N'" & frm.C1FGridMokuji.Rows(iRow)("刊行年月") & "'"
				strSQL &= ", N'" & frm.C1FGridMokuji.Rows(iRow)("分類1") & "'"
				strSQL &= ", N'" & frm.C1FGridMokuji.Rows(iRow)("分類2") & "'"
				strSQL &= ", N'" & frm.C1FGridMokuji.Rows(iRow)("分類番号") & "'"
				strSQL &= ", N'" & frm.C1FGridMokuji.Rows(iRow)("項目") & "'"
				strSQL &= ", N'" & frm.C1FGridMokuji.Rows(iRow)("番号1") & "'"
				'各タイトルにシングルクォートが入っていたときの対処
				strTitle = frm.C1FGridMokuji.Rows(iRow)("タイトル1")
				If IsNull(strTitle) Then
					strSQL &= ", N''"
				Else
					strSQL &= ", N'" & strTitle.Replace("'", "''") & "'"
				End If
				strSQL &= ", N'" & frm.C1FGridMokuji.Rows(iRow)("番号2") & "'"
				strTitle = frm.C1FGridMokuji.Rows(iRow)("タイトル2")
				If IsNull(strTitle) Then
					strSQL &= ", N''"
				Else
					strSQL &= ", N'" & strTitle.Replace("'", "''") & "'"
				End If
				strSQL &= ", N'" & frm.C1FGridMokuji.Rows(iRow)("番号3") & "'"
				strTitle = frm.C1FGridMokuji.Rows(iRow)("タイトル3")
				If IsNull(strTitle) Then
					strSQL &= ", N''"
				Else
					strSQL &= ", N'" & strTitle.Replace("'", "''") & "'"
				End If
				strSQL &= ", N'" & frm.C1FGridMokuji.Rows(iRow)("番号4") & "'"
				strTitle = frm.C1FGridMokuji.Rows(iRow)("タイトル4")
				If IsNull(strTitle) Then
					strSQL &= ", N''"
				Else
					strSQL &= ", N'" & strTitle.Replace("'", "''") & "'"
				End If
				strSQL &= ", N'" & frm.C1FGridMokuji.Rows(iRow)("番号5") & "'"
				strTitle = frm.C1FGridMokuji.Rows(iRow)("タイトル5")
				If IsNull(strTitle) Then
					strSQL &= ", N''"
				Else
					strSQL &= ", N'" & strTitle.Replace("'", "''") & "'"
				End If
				strSQL &= ", N''"   'フォルダ名

				strSQL &= ", N'" & frm.C1FGridMokuji.Rows(iRow)("リンク") & "'"
				strSQL &= ", N'" & frm.C1FGridMokuji.Rows(iRow)("リンクTO") & "'"
				strSQL &= ", N'" & frm.C1FGridMokuji.Rows(iRow)("備考") & "'"  '備考
				strSQL &= ", N'" & frm.C1FGridMokuji.Rows(iRow)("フラグID") & "'"
				strSQL &= ", '" & strBackupDate & "')"   '登録日時
				sqlProcess.DB_UPDATE(strSQL)

				'フラグデータの書き込み(目次部)
				If Not IsNull(frm.C1FGridMokuji(iRow, "フラグID")) And Not CInt(frm.C1FGridMokuji(iRow, "フラグID")) = 0 Then
					'NULLではない、もしくは0でない場合
					'連番の最大値＋1を取得
					strSQL = "SELECT ISNULL(MAX(登録連番), 0) + 1 FROM T_フラグ "
					strSQL &= "WHERE 管理ID = " & iBookletID
					Dim iMax As Integer = CInt(sqlProcess.DB_EXECUTE_SCALAR(strSQL))    '登録連番

					Dim strRecordNo As String = frm.C1FGridMokuji(iRow, "レコード番号")
					Dim iFlagID As Integer = CInt(frm.C1FGridMokuji(iRow, "フラグID"))
					strSQL = "INSERT INTO T_フラグ (管理ID, 登録連番, 連番, 種別ID, フラグID, ファイル名, レコード番号, 管理者確認) "
					strSQL &= "VALUES (" & iBookletID   '管理ID
					strSQL &= ", " & iMax   '登録連番
					strSQL &= ", " & iRow   '振り直した連番
					strSQL &= ", 20"    '種別ID
					strSQL &= ", " & iFlagID    'フラグID
					strSQL &= ", N''"   'ファイル名
					strSQL &= ", N'" & strRecordNo & "', 0)"    'レコード番号、管理者確認
					sqlProcess.DB_UPDATE(strSQL)
				ElseIf IsNull(frm.C1FGridMokuji(iRow, "リンク")) Or IsNull(frm.C1FGridMokuji(iRow, "リンクTO")) Then
					'フラグが立っていないのにリンクがない場合は「該当イメージ無し」
					strSQL = "SELECT ISNULL(MAX(登録連番), 0) + 1 FROM T_フラグ "
					strSQL &= "WHERE 管理ID = " & iBookletID
					Dim iMax As Integer = CInt(sqlProcess.DB_EXECUTE_SCALAR(strSQL))

					Dim strRecordNo As String = frm.C1FGridMokuji(iRow, "レコード番号")
					Dim iFlagID As Integer = 5  '該当イメージ無し
					strSQL = "INSERT INTO T_フラグ (管理ID, 登録連番, 連番, 種別ID, フラグID, ファイル名, レコード番号, 管理者確認) "
					strSQL &= "VALUES (" & iBookletID   '管理ID
					strSQL &= ", " & iMax   '登録連番
					strSQL &= ", " & iRow   '振り直した連番
					strSQL &= ", 20"    '種別ID
					strSQL &= ", " & iFlagID    'フラグID
					strSQL &= ", N''"   'ファイル名
					strSQL &= ", N'" & strRecordNo & "', 0)"    'レコード番号、管理者確認
					sqlProcess.DB_UPDATE(strSQL)
					'T_目次バックアップのフラグIDを該当イメージ無し(5)にする
					strSQL = "UPDATE T_目次バックアップ SET フラグID = " & iFlagID & " "
					strSQL &= "WHERE 履歴ID = " & strRirekiID & " "
					strSQL &= "AND 管理ID = " & iBookletID & " "
					strSQL &= "AND 連番 = " & iRow
					sqlProcess.DB_UPDATE(strSQL)
				End If
			Next

			'画像ファイル部のフラグ書き込み
			For iRow As Integer = 1 To Me.C1FGridResult.Rows.Count - 1
                If Not IsNull(Me.C1FGridResult(iRow, "フラグID")) And Not CInt(Me.C1FGridResult(iRow, "フラグID")) = 0 Then
					'NULLではない、もしくは0でない場合
					'連番の最大値＋1を取得
					strSQL = "SELECT ISNULL(MAX(登録連番), 0) + 1 FROM T_フラグ "
					strSQL &= "WHERE 管理ID = " & iBookletID
                    Dim iMax As Integer = CInt(sqlProcess.DB_EXECUTE_SCALAR(strSQL))

                    Dim strFileName As String = Me.C1FGridResult(iRow, "ファイル名")
                    Dim iFlagID As Integer = CInt(Me.C1FGridResult(iRow, "フラグID"))
					strSQL = "INSERT INTO T_フラグ (管理ID, 登録連番, 連番, 種別ID, フラグID, ファイル名, レコード番号, 管理者確認) "
					strSQL &= "VALUES (" & iBookletID   '管理ID
					strSQL &= ", " & iMax   '登録連番
					strSQL &= ", 0" '連番
					strSQL &= ", 30"    '種別ID
                    strSQL &= ", " & iFlagID    'フラグID
                    strSQL &= ", N'" & strFileName & "'"    'ファイル名
					strSQL &= ", N'', 0)"   'レコード番号、管理者確認
					sqlProcess.DB_UPDATE(strSQL)
                End If
            Next

			'管理表の備考をUPDATE
			Dim strRemarks As String = Me.txtRemarks.Text.Replace(vbNewLine, "\n")
			strSQL = "UPDATE M_管理表 SET 備考 = N'" & strRemarks & "' "
			strSQL &= "WHERE 管理ID = " & iBookletID
			sqlProcess.DB_UPDATE(strSQL)

			'データベース上の実データを削除して、グリッドのデータをINSERT
			strSQL = "DELETE FROM T_目次 WHERE 管理ID = " & iBookletID
            sqlProcess.DB_UPDATE(strSQL)
			strSQL = "INSERT INTO T_目次 (管理ID, 連番, レコード番号, 表示用, 行番号, 県名, 資料名, 副題, 対象年, 刊行者名, 刊行年月, 分類1, 分類2, 分類番号, 項目, "
			strSQL &= "番号1, タイトル1, 番号2, タイトル2, 番号3, タイトル3, 番号4, タイトル4, 番号5, タイトル5, フォルダ名, リンク, リンクTO, 備考, フラグID) "
			strSQL &= "SELECT 管理ID, 連番, レコード番号, 表示用, 行番号, 県名, 資料名, 副題, 対象年, 刊行者名, 刊行年月, 分類1, 分類2, 分類番号, 項目, "
			strSQL &= "番号1, タイトル1, 番号2, タイトル2, 番号3, タイトル3, 番号4, タイトル4, 番号5, タイトル5, フォルダ名, リンク, リンクTO, 備考, フラグID FROM T_目次バックアップ "
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

	'''' <summary>
	'''' 連番を振り直す
	'''' </summary>
	'''' <param name="C1FGrid"></param>
	'''' <remarks></remarks>
	'Private Sub GridRenumber(ByVal C1FGrid As C1.Win.C1FlexGrid.C1FlexGrid)

	'    Dim frm As frmEntry = My.Forms.frmEntry

	'    For iRow As Integer = 1 To frm.C1FGridMokuji.Rows.Count - 1
	'        frm.C1FGridMokuji(iRow, "No") = iRow
	'    Next

	'End Sub

	''' <summary>
	''' 中断中のフォルダを再開させる
	''' </summary>
	Private Sub Restart()

		'管理者フラグが立っていた場合スルー
		If IsAdmin Then
			Exit Sub
		End If

		Dim strSQL As String = ""
		Dim sqlProcess As New SQLProcess

		Try
			Dim strHostName As String = My.Computer.Name
			'strSQL = "SELECT 管理ID, 県名, 仮フォルダ, CASE WHEN ISNULL(終了日時, '') = '1900/01/01' THEN '□□ ' + 納品フォルダ ELSE (CASE WHEN ISNULL(終了日時2次, '') = '1900/01/01' THEN '■□ ' + 納品フォルダ ELSE '■■ ' + 納品フォルダ END) END AS 納品フォルダ FROM M_管理表 "
			strSQL = "SELECT 管理ID, 県名, 仮フォルダ FROM M_管理表 "
			strSQL &= "WHERE 処理端末 = '" & strHostName & "'"
			Dim dt As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)

			If dt.Rows.Count = 0 Then
				Exit Sub
			End If

			'端末名が記録されているレコードがあったら再開する
			'県名を選択（頭3文字は除外）
			Dim strPrefecture As String = Strings.Mid(dt.Rows(0)("県名"), 4)
			''県名でM_都道府県を検索
			'strSQL = "SELECT 都道府県番号 + ' ' + 都道府県名 FROM M_都道府県 "
			'strSQL &= "WHERE 都道府県名 = '" & strPrefecture & "'"
			'Dim strPrefectureNo As String = sqlProcess.DB_EXECUTE_SCALAR(strSQL)

			Me.cmbPrefecture.SelectedValue = strPrefecture   '県名
			Application.DoEvents()
			'納品フォルダを選択
			'strSQL = "SELECT 管理ID, CASE WHEN ISNULL(終了日時, '') = '1900/01/01' THEN '□□ ' + 納品フォルダ ELSE (CASE WHEN ISNULL(終了日時2次, '') = '1900/01/01' THEN '■□ ' + 納品フォルダ ELSE '■■ ' + 納品フォルダ END) END AS 納品フォルダ "
			'strSQL &= "FROM M_管理表 "
			'strSQL &= "WHERE 県名 LIKE '%" & strPrefecture & "%' "
			'strSQL &= "AND "
			'dt = sqlProcess.DB_SELECT_DATATABLE(strSQL)

			Me.cmbBookletID.SelectedValue = dt.Rows(0)("管理ID").ToString
			Application.DoEvents()
			'開始ボタンを押下
			Me.btnStart.PerformClick()

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		Finally

			sqlProcess.Close()

		End Try

	End Sub

	''' <summary>
	''' 管理者側の開始動作
	''' </summary>
	Private Sub AdminStart()

		Dim strSQL As String = ""
		Dim sqlProcess As New SQLProcess

		Try
			If Not IsAdmin Then
				Exit Sub
			End If

			strSQL = "SELECT 管理ID, 県名 FROM M_管理表 "
			strSQL &= "WHERE 管理ID = " & ManageID
			Dim dt As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)

			Dim strPrefecture As String = Strings.Mid(dt.Rows(0)("県名"), 4)
			Me.cmbPrefecture.SelectedValue = strPrefecture  '県名
			Application.DoEvents()
			Me.cmbBookletID.SelectedValue = ManageID.ToString
			Application.DoEvents()
			'開始ボタンを押下
			Me.btnStart.PerformClick()

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		Finally

			sqlProcess.Close()

		End Try

	End Sub

#End Region

End Class