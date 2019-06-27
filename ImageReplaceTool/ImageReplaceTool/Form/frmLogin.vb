Imports System.Runtime.InteropServices

Public Class frmLogin

#Region "プライベート変数"

	Private _LoginItem As String

#End Region

#Region "プロパティ"

	''' <summary>
	''' 案件情報の読み書き
	''' </summary>
	''' <returns></returns>
	Public Property LoginItem()
		Get
			Return _LoginItem
		End Get
		Set(value)
			_LoginItem = value
		End Set
	End Property

#End Region

#Region "フォームイベント"

	''' <summary>
	''' フォームロード時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load

		Me.Text = My.Application.Info.ProductName & " Ver." &
			My.Application.Info.Version.ToString & " - [ログイン]"

		'コマンドライン引数の取得
		Dim cmds() As String
		cmds = System.Environment.GetCommandLineArgs()
		'取得した配列のはじめの要素は必ず実行ファイル本体となるため
		'要素数が2であれば引数付きで実行したことがわかる
		If cmds.Count = 2 Then
			LoginItem = cmds(1)
		End If

		Me.KeyPreview = True
		CaptionDisplayMode = StatusDisplayMode.None
		Initialize()

	End Sub

	''' <summary>
	''' フォームキーダウンイベント
	''' </summary>
	''' <param name="e"></param>
	''' <remarks></remarks>
	Protected Overrides Sub OnKeyDown(e As System.Windows.Forms.KeyEventArgs)
		'Enterキーで項目移動。ボタン上では無効。Alt+Enterは無視する
		If TypeOf Me.ActiveControl Is Button Then
			Exit Sub
		End If

		If e.KeyCode = Keys.Enter And Not e.Alt Then

			Dim forward As Boolean = e.Modifiers <> Keys.Shift
			Me.SelectNextControl(Me.ActiveControl, forward, True, True, True)

			e.Handled = True

		End If

	End Sub

#End Region

#Region "オブジェクトイベント"

	''' <summary>
	''' 従業員区分インデックス変更時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub cmbCategory_SelectedIndexChanged(sender As Object, e As EventArgs)

		Me.txtPassword.Text = ""
		'M_従業員から値を取得する
		Dim strSQL As String = ""
		Dim sqlProcess As New SQLProcess
		XmlSettings.LoadFromXmlFile()

		Try
			strSQL = "SELECT 従業員ID, 従業員名 "
			strSQL &= "FROM " & XmlSettings.Instance.TablePrefix & ".[M_従業員] "
			strSQL &= "WHERE 従業員区分ID = " & Me.cmbCategory.SelectedValue & " "
			strSQL &= "AND 有効フラグ = 1 "
			strSQL &= "ORDER BY 従業員区分ID, 従業員名"
			Dim dt As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
			SetComboValue(Me.cmbName, dt, False)
			If Me.cmbName.Items.Count = 0 Then
				Exit Sub
			End If
			Me.cmbName.SelectedIndex = 0

			'従業員名をテキスト入力可能形式にしてオートコンプリートを実装する
			Me.cmbName.AutoCompleteMode = AutoCompleteMode.SuggestAppend
			'コンボボックスのアイテムをオートコンプリートの選択候補とする
			Me.cmbName.AutoCompleteSource = AutoCompleteSource.ListItems

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & ex.StackTrace)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		Finally

			sqlProcess.Close()

		End Try

	End Sub

	''' <summary>
	''' 終了ボタン押下時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click, menuExit.Click

		If MessageBox.Show("アプリケーションを終了します" & vbNewLine & "よろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
			Exit Sub
		Else
			Application.Exit()
		End If

	End Sub

	''' <summary>
	''' ログインボタン押下時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click

		Dim strSQL As String = ""
		Dim sqlProcess As New SQLProcess
		XmlSettings.LoadFromXmlFile()

		Try
			Dim iEmployeeID As Integer = CInt(Me.cmbName.SelectedValue)
			Dim strPassword As String = Me.txtPassword.Text

			strSQL = "SELECT 従業員ID, 従業員名, 従業員区分ID "
			strSQL &= "FROM " & XmlSettings.Instance.TablePrefix & ".[M_従業員] "
			strSQL &= "WHERE 従業員ID = " & iEmployeeID & " "
			strSQL &= "AND パスワード = '" & strPassword & "'"
			Dim dt As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
			'レコードが存在したらログイン成功
			If dt.Rows.Count = 1 Then
				'MessageBox.Show("ログイン成功" & vbNewLine & dt.Rows(0)("従業員ID") & vbNewLine & dt.Rows(0)("従業員名"))
				'ログイン成功
				'ログイン情報をアプリケーション終了まで保持する
				m_LoginUser.UserID = dt.Rows(0)("従業員ID")
				m_LoginUser.UserName = dt.Rows(0)("従業員名")
				Dim iManage As Integer() = {1, 2, 6, 7, 11, 12}
				If iManage.Contains(dt.Rows(0)("従業員区分ID")) Then
					'該当の従業員区分がどれか合致していたら
					m_LoginUser.ManageFlag = True
				Else
					m_LoginUser.ManageFlag = False
				End If
				m_LoginUser.LoginItem = LoginItem()

				Dim frmNextForm As New frmMainMenu
				m_Context.SetNextContext(frmNextForm)
			Else
				MessageBox.Show("ログインに失敗しました", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
				Me.txtPassword.Text = ""
				Me.txtPassword.Select()

			End If

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & ex.StackTrace)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		Finally

			sqlProcess.Close()

		End Try

	End Sub

	''' <summary>
	''' 接続設定
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub menuConnection_Click(sender As Object, e As EventArgs) Handles menuConnection.Click

		Dim f As New frmConnectionProperty
		f.ShowDialog(Me)

	End Sub


#End Region

#Region "プライベートメソッド"

	''' <summary>
	''' 初期化処理
	''' </summary>
	Private Sub Initialize()

		Dim strSQL As String = ""
		Dim sqlProcess As New SQLProcess
		XmlSettings.LoadFromXmlFile()

		Try
			'M_従業員区分の参照
			If IsNull(LoginItem()) Then
				'NULLの場合は管理者（社員）のみログイン可能
				strSQL = "SELECT 従業員区分ID, 従業員区分 "
				strSQL &= "FROM " & XmlSettings.Instance.TablePrefix & ".[M_従業員区分] "
				strSQL &= "WHERE 従業員区分ID BETWEEN 1 AND 2 "
				strSQL &= "OR 従業員区分ID BETWEEN 6 AND 7 "
				strSQL &= "OR 従業員区分ID BETWEEN 11 AND 12 "
				strSQL &= "ORDER BY 従業員区分ID"
			Else
				'全ての従業員区分
				strSQL = "SELECT 従業員区分ID, 従業員区分 "
				strSQL &= "FROM " & XmlSettings.Instance.TablePrefix & ".[M_従業員区分] "
				strSQL &= "ORDER BY 従業員区分ID"
			End If
			Dim dt As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
			SetComboValue(Me.cmbCategory, dt, True)
			Me.cmbCategory.SelectedIndex = 0

			AddHandler cmbCategory.SelectedIndexChanged, AddressOf cmbCategory_SelectedIndexChanged

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & ex.StackTrace)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		Finally

			sqlProcess.Close()

		End Try

	End Sub

	'Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

	'	If MessageBox.Show("開始します", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
	'		Exit Sub
	'	End If

	'	Dim strPath As String = "\\hydra\01_制作Gr\04_スポット案件\20190128_181141011_寺田倉庫_工学院大学\14_meibo_chk\txt\大学院\" & Me.TextBox1.Text
	'	Dim strFiles As String() = GetFilesMostDeep(strPath, {"*.txt"})
	'	Dim strOutLog As String = "\\hydra\01_制作Gr\04_スポット案件\20190128_181141011_寺田倉庫_工学院大学\zz_log\2回目"

	'	Using sw As New System.IO.StreamWriter(strOutLog & "\14_meibo_chk_大学院_" & Me.TextBox1.Text & ".txt", False, System.Text.Encoding.GetEncoding("Shift-JIS"))

	'		For Each strFile As String In strFiles
	'			If System.IO.Path.GetFileNameWithoutExtension(strFile).Length = 8 Then
	'				Continue For
	'			End If

	'			Using sr As New System.IO.StreamReader(strFile, System.Text.Encoding.GetEncoding("Shift-JIS"))
	'				Dim strItem01 As String = Me.TextBox1.Text
	'				Dim strItem02 As String = Strings.Mid(System.IO.Path.GetFileNameWithoutExtension(strFile), 9, 3)
	'				Dim strReadItem As String = sr.ReadLine()
	'				If strReadItem Is Nothing Then
	'					strReadItem = ""
	'				End If
	'				Dim strWriteLine As String = strReadItem & vbTab & strItem01 & vbTab & strItem02
	'				sw.WriteLine(strWriteLine)
	'			End Using
	'		Next

	'	End Using

	'	MessageBox.Show("終了しました", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information)

	'End Sub

#End Region

End Class