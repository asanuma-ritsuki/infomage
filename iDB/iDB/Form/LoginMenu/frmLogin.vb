Imports C1.Win.C1Input

Public Class frmLogin

#Region "フォームイベント"

	''' <summary>
	''' フォームロード
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load

		Me.Text = My.Application.Info.ProductName.ToString & " Ver." &
			My.Application.Info.Version.ToString & " - [ログイン]"

		Initialize()

	End Sub

#End Region

#Region "オブジェクトイベント"

	''' <summary>
	''' 終了ボタン押下時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
		'※Application.Exitだとうまくいかない
		'TargetParameterCountExceptionが発生
		If MessageBox.Show("アプリケーションを終了します" & vbNewLine & "よろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
			Me.Close()
		End If

	End Sub

	'''' <summary>
	'''' フォームクロージング
	'''' </summary>
	'''' <param name="sender"></param>
	'''' <param name="e"></param>
	'Private Sub frmLogin_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

	'	If MessageBox.Show("アプリケーションを終了します。" & vbNewLine & "よろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
	'		e.Cancel = True
	'	End If

	'End Sub

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

			Dim iEmployeeID As Integer = CInt(Me.cmbUserID.SelectedItem)
			Dim strPassword As String = Me.txtPassword.Text

			strSQL = "SELECT 従業員ID, 従業員名 FROM M_従業員 "
			strSQL &= "WHERE 従業員ID = " & iEmployeeID & " AND "
			strSQL &= "パスワード = '" & strPassword & "'"
			Dim dt As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)

			If dt.Rows.Count = 1 Then
				'ログイン成功
				'※権限で画面遷移を操作するコードを入れる
				'プロジェクト管理画面へ
				Dim frmNextForm As New frmProjectManage
				m_LoginUser.UserID = iEmployeeID    '従業員ID
				m_LoginUser.UserName = dt.Rows(0)("従業員名")   '従業員名
				m_Context.SetNextContext(frmNextForm)
			Else
				'ログイン失敗
				MessageBox.Show("ログインに失敗しました", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
				Me.txtPassword.Text = ""
				Me.txtPassword.Select()
			End If

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		Finally

			sqlProcess.Close()

		End Try

	End Sub

	''' <summary>
	''' 生産グループ変更時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub cmbGroup_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbGroup.SelectedIndexChanged

		UpdateUser()

	End Sub

	''' <summary>
	''' 接続設定ボタン押下時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub btnConnectionProperty_Click(sender As Object, e As EventArgs) Handles btnConnectionProperty.Click

		Dim f As New frmConnectionProperty
		f.ShowDialog(Me)

	End Sub

	''' <summary>
	''' 更新履歴ボタン押下時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub btnUpdateHistory_Click(sender As Object, e As EventArgs) Handles btnUpdateHistory.Click

		ViewHistory()

	End Sub


#End Region

#Region "プライベートメソッド"

	''' <summary>
	''' 初期化処理
	''' </summary>
	Private Sub Initialize()

		CaptionDisplayMode = StatusDisplayMode.TitleOnly
		Me.lblScreenName.Text = "ログイン"

		Dim sqlProcess As New SQLProcess
		Dim strSQL As String = ""

		Try
			'strSQL = "SELECT 接続先ID, 接続先 FROM M_接続先 "
			'strSQL &= "ORDER BY 接続先ID"
			'Dim dt As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)

			'Me.cmbConnectionPlace.TextDetached = True   'TrueにしないとValueMemberがテキストボックスにセットされてしまう
			'Me.cmbConnectionPlace.ItemsDataSource = dt
			'Me.cmbConnectionPlace.ItemsDisplayMember = "接続先"
			'Me.cmbConnectionPlace.ItemsValueMember = "接続先ID"
			'Me.cmbConnectionPlace.SelectedIndex = 0

			strSQL = "SELECT 生産グループID, 生産グループ FROM M_生産グループ "
			strSQL &= "ORDER BY 生産グループID"
			Dim dt As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
			Me.cmbGroup.TextDetached = True
			Me.cmbGroup.ItemsDataSource = dt
			Me.cmbGroup.ItemsDisplayMember = "生産グループ"
			Me.cmbGroup.ItemsValueMember = "生産グループID"
			Me.cmbGroup.SelectedIndex = 0

			'UpdateSection()
			UpdateUser()

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		Finally

			sqlProcess.Close()

		End Try

	End Sub

	'''' <summary>
	'''' 接続先コンボボックスの値変更時に処理する
	'''' </summary>
	'Private Sub UpdateSection()

	'	Me.cmbGroup.ItemsDataSource = Nothing
	'	Me.cmbGroup.Text = ""
	'	If Me.cmbConnectionPlace.SelectedItem Is Nothing Then
	'		Exit Sub
	'	End If

	'	Dim sqlProcess As New SQLProcess
	'	Dim strSQL As String = ""
	'	XmlSettings.LoadFromXmlFile()

	'	Try
	'		'10：i-system
	'		'20：ローカル
	'		If Me.cmbConnectionPlace.SelectedItem = 10 Then
	'			'i-system接続
	'			strSQL = "SELECT 従業員区分ID, 従業員区分 FROM " & XmlSettings.Instance.TablePrefix & "M_従業員区分 "
	'			strSQL &= "UNION SELECT 0, '選択してください' "
	'			strSQL &= "ORDER BY 従業員区分ID"
	'			Dim dt As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)

	'			Me.cmbGroup.ItemsDataSource = dt
	'			Me.cmbGroup.ItemsDisplayMember = "従業員区分"
	'			Me.cmbGroup.ItemsValueMember = "従業員区分ID"
	'			Me.cmbGroup.SelectedIndex = 0

	'		Else
	'			'ローカル
	'			strSQL = "SELECT 従業員区分ID, 従業員区分 FROM M_従業員区分 "
	'			strSQL &= "UNION SELECT 0, '選択してください' "
	'			strSQL &= "ORDER BY 従業員区分ID"
	'			Dim dt As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)

	'			Me.cmbGroup.ItemsDataSource = dt
	'			Me.cmbGroup.ItemsDisplayMember = "従業員区分"
	'			Me.cmbGroup.ItemsValueMember = "従業員区分ID"
	'			Me.cmbGroup.SelectedIndex = 0

	'		End If

	'		Me.txtPassword.Text = ""

	'	Catch ex As Exception

	'		Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message)
	'		MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

	'	Finally

	'		sqlProcess.Close()

	'	End Try

	'End Sub

	Private Sub UpdateUser()

		Me.cmbUserID.ItemsDataSource = Nothing
		Me.cmbUserID.Text = ""

		Dim sqlProcess As New SQLProcess
		Dim strSQL As String = ""
		XmlSettings.LoadFromXmlFile()

		If Me.cmbGroup.SelectedItem Is Nothing Then
			Exit Sub
		End If

		Try

			strSQL = "SELECT 従業員ID, 従業員名 FROM M_従業員 "
			strSQL &= "WHERE 生産グループID = " & Me.cmbGroup.SelectedItem & " "
			strSQL &= "AND 有効フラグ = 1 "
			strSQL &= "ORDER BY 生産グループID, 従業員区分ID, 従業員名"
			Dim dt As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)

			If dt.Rows.Count >= 1 Then
				Me.cmbUserID.ItemsDataSource = dt
				Me.cmbUserID.ItemsDisplayMember = "従業員名"
				Me.cmbUserID.ItemsValueMember = "従業員ID"
				Me.cmbUserID.SelectedIndex = 0
			End If

			''10：i-system
			''20：ローカル
			'If Me.cmbConnectionPlace.SelectedItem = 10 Then
			'	'i-system接続
			'	strSQL = "SELECT 従業員ID, 従業員名 FROM " & XmlSettings.Instance.TablePrefix & "M_従業員 "
			'	strSQL &= "WHERE 従業員区分ID = " & Me.cmbGroup.SelectedItem & " "
			'	strSQL &= "AND 有効フラグ = 1 "
			'	strSQL &= "ORDER BY 従業員区分ID, 従業員名"
			'	Dim dt As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)

			'	Me.cmbUserID.ItemsDataSource = dt
			'	Me.cmbUserID.ItemsDisplayMember = "従業員名"
			'	Me.cmbUserID.ItemsValueMember = "従業員ID"
			'	Me.cmbUserID.SelectedIndex = 0

			'Else
			'	'ローカル
			'	strSQL = "SELECT 従業員ID, 従業員名 FROM M_従業員 "
			'	strSQL &= "WHERE 従業員区分ID = " & Me.cmbGroup.SelectedItem & " "
			'	strSQL &= "AND 有効フラグ = 1 "
			'	strSQL &= "ORDER BY 従業員区分ID, 従業員名"
			'	Dim dt As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)

			'	Me.cmbUserID.ItemsDataSource = dt
			'	Me.cmbUserID.ItemsDisplayMember = "従業員名"
			'	Me.cmbUserID.ItemsValueMember = "従業員ID"
			'	Me.cmbUserID.SelectedIndex = 0

			'End If

			Me.txtPassword.Text = ""

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		Finally

			sqlProcess.Close()

		End Try

	End Sub

	''' <summary>
	''' テキストボックスエンター時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub C1TextBox_Enter(sender As Object, e As EventArgs) Handles txtPassword.Enter

		CType(sender, C1TextBox).BackColor = Color.LightPink
		CType(sender, C1TextBox).SelectAll()

	End Sub

	''' <summary>
	''' テキストボックスリーブ時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub C1TextBox_Leave(sender As Object, e As EventArgs) Handles txtPassword.Leave

		CType(sender, C1TextBox).BackColor = Color.White

	End Sub

	Private Sub ViewHistory()

		Dim strUpdateHistory As String = Application.StartupPath & "\UpateHistory.txt"
		If System.IO.File.Exists(strUpdateHistory) Then
			'更新ファイルが存在した
			System.Diagnostics.Process.Start(strUpdateHistory)
		Else
			'存在しなかった
			MessageBox.Show("更新履歴ファイルが見つかりませんでした", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Exit Sub
		End If

	End Sub

#End Region

End Class