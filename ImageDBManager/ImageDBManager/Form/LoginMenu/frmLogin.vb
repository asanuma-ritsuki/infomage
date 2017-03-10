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
	Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click

		Dim strSQL As String = ""
		Dim sqlProcess As New SQLProcess
		XmlSettings.LoadFromXmlFile()

		Try

			Dim iEmployeeID As Integer = CInt(Me.cmbUser.SelectedValue)
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
	''' ログインボタン押下時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click

		If MessageBox.Show("アプリケーションを終了します" & vbNewLine & "よろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
			Application.Exit()
		End If

	End Sub

	''' <summary>
	''' 拠点変更時
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

	Private Sub TextBox_Enter(sender As Object, e As EventArgs) Handles txtPassword.Enter

		CType(sender, TextBox).BackColor = Color.LightPink
		CType(sender, TextBox).SelectAll()

	End Sub

	Private Sub TextBox_Leave(sender As Object, e As EventArgs) Handles txtPassword.Leave

		CType(sender, TextBox).BackColor = System.Drawing.SystemColors.Window

	End Sub
#End Region

#Region "プライベートメソッド"

	Private Sub Initialize()

		CaptionDisplayMode = StatusDisplayMode.TitleOnly
		Me.lblScreenName.Text = "ログイン"

		Dim sqlProcess As New SQLProcess
		Dim strSQL As String = ""

		Try
			strSQL = "SELECT 生産グループID, 生産グループ FROM M_生産グループ "
			strSQL &= "ORDER BY 生産グループID"
			Dim dt As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
			Dim elmGroup() As CElement = Nothing
			Me.cmbGroup.DataSource = Nothing
			ReDim Preserve elmGroup(0)
			elmGroup(0) = New CElement
			elmGroup(0).ID = 0
			elmGroup(0).NAME = "拠点を選択"

			For iGroup As Integer = 0 To dt.Rows.Count - 1
				ReDim Preserve elmGroup(iGroup + 1)
				elmGroup(iGroup + 1) = New CElement
				elmGroup(iGroup + 1).ID = dt.Rows(iGroup)("生産グループID")
				elmGroup(iGroup + 1).NAME = dt.Rows(iGroup)("生産グループ")
			Next

			Me.cmbGroup.DisplayMember = "NAME"
			Me.cmbGroup.ValueMember = "ID"
			Me.cmbGroup.DataSource = elmGroup
			Me.cmbGroup.SelectedIndex = 0

			UpdateUser()

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		Finally

			sqlProcess.Close()

		End Try

	End Sub

	''' <summary>
	''' ユーザー名コンボボックスの更新
	''' </summary>
	Private Sub UpdateUser()

		If Me.cmbGroup.SelectedIndex = 0 Then
			Me.cmbUser.Enabled = False
			Exit Sub
		Else
			Me.cmbUser.Enabled = True
		End If

		Dim sqlProcess As New SQLProcess
		Dim strSQL As String = ""

		Try
			strSQL = "SELECT 従業員ID, 従業員名 FROM M_従業員 "
			strSQL &= "WHERE 生産グループID = " & Me.cmbGroup.SelectedValue & " "
			strSQL &= "AND 有効フラグ = 1 "
			strSQL &= "ORDER BY 生産グループID, 従業員区分ID, 従業員名"
			Dim dt As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)

			If dt.Rows.Count = 0 Then
				Me.cmbUser.DataSource = Nothing
				Me.cmbUser.Enabled = False
				Exit Sub
			End If

			Dim elmUser() As CElement = Nothing
			Me.cmbUser.DataSource = Nothing
			ReDim Preserve elmUser(0)
			elmUser(0) = New CElement
			elmUser(0).ID = 0
			elmUser(0).NAME = "ユーザー名を選択"

			For iUser As Integer = 0 To dt.Rows.Count - 1
				ReDim Preserve elmUser(iUser + 1)
				elmUser(iUser + 1) = New CElement
				elmUser(iUser + 1).ID = dt.Rows(iUser)("従業員ID")
				elmUser(iUser + 1).NAME = dt.Rows(iUser)("従業員名")
			Next

			Me.cmbUser.DisplayMember = "NAME"
			Me.cmbUser.ValueMember = "ID"
			Me.cmbUser.DataSource = elmUser
			Me.cmbUser.SelectedIndex = 0

			Me.txtPassword.Text = ""

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		Finally

			sqlProcess.Close()

		End Try

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