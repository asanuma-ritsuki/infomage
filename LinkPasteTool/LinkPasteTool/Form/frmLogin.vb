Public Class frmLogin

#Region "フォームイベント"

	''' <summary>
	''' フォームロード時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load

		Me.Text = My.Application.Info.ProductName.ToString & " Ver." &
			My.Application.Info.Version.ToString & " - [ログイン]"
		CaptionDisplayMode = StatusDisplayMode.None

		Initialize()

	End Sub

#End Region

#Region "オブジェクトイベント"

	''' <summary>
	''' OKボタン押下時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click

		If Me.cmbUser.SelectedIndex < 0 Then
			MessageBox.Show("ユーザーを選択してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Exit Sub
		End If

		Dim strSQL As String = ""
		Dim sqlProcess As New SQLProcess

		Try

			If Me.cmbUser.SelectedValue >= 99 Then
				'管理者でログイン

				strSQL = "SELECT COUNT(ユーザー名) FROM M_ユーザー "
				strSQL &= "WHERE ユーザー名 = '" & Me.cmbUser.SelectedItem.ToString & "' "
				strSQL &= "AND パスワード = '" & Me.txtPassword.Text & "'"
				If CInt(sqlProcess.DB_EXECUTE_SCALAR(strSQL)) > 0 Then

					m_LoginUser.UserID = CInt(Me.cmbUser.SelectedValue)
					m_LoginUser.User = Me.cmbUser.SelectedItem.ToString
					Dim frm As New frmManage
					m_Context.SetNextContext(frm)

				Else

					MessageBox.Show("パスワードが違います", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
					Exit Sub

				End If

			Else
				'管理者以外でログイン
				m_LoginUser.UserID = CInt(Me.cmbUser.SelectedValue)
				m_LoginUser.User = Me.cmbUser.SelectedItem.ToString
				Dim frm As New frmMain
				m_Context.SetNextContext(frm)

			End If

			'指定されたユーザーのログインフラグを立てる
			strSQL = "UPDATE M_ユーザー SET ログインフラグ = 1 "
			strSQL &= "WHERE ユーザーID = " & m_LoginUser.UserID
			sqlProcess.DB_UPDATE(strSQL)

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		Finally

			sqlProcess.Close()

		End Try

		'Dim frm As frmMain = CType(Me.Owner, frmMain)
		'frm.lblUser.Text = Me.cmbUser.SelectedItem.ToString
		'Me.Close()

	End Sub

	''' <summary>
	''' 終了ボタン押下時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click

		If MessageBox.Show("アプリケーションを終了します" & vbNewLine & "よろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

			Dim strSQL As String = ""
			Dim sqlProcess As New SQLProcess

			Try
				strSQL = "UPDATE M_ユーザー SET ログインフラグ = 0 "
				strSQL &= "WHERE ユーザーID = " & m_LoginUser.UserID
				sqlProcess.DB_UPDATE(strSQL)

			Catch ex As Exception

				Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message)
				MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

			Finally

				sqlProcess.Close()

			End Try

			Application.Exit()
		End If

	End Sub

	''' <summary>
	''' ユーザー名コンボボックスインデックス変更時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub cmbUser_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbUser.SelectedIndexChanged

		If Me.cmbUser.SelectedIndex < 0 Then
			Exit Sub
		End If

		If Me.cmbUser.SelectedValue >= 99 Then
			Me.txtPassword.Enabled = True
		Else
			Me.txtPassword.Enabled = False
		End If
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
			'ユーザー名の列挙
			strSQL = "SELECT ユーザーID, ユーザー名 FROM M_ユーザー "
			strSQL &= "WHERE ログインフラグ = 0 "
			strSQL &= "ORDER BY ユーザーID"
			Dim dt As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)

			SetComboValue(Me.cmbUser, dt, False)

			Me.txtPassword.Enabled = False

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		Finally

			sqlProcess.Close()

		End Try
	End Sub

    ''' <summary>
    ''' ツールメニュー[ファイル][終了]
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub menuExit_Click(sender As Object, e As EventArgs) Handles menuExit.Click

        If MessageBox.Show("アプリケーションを終了します" & vbNewLine & "よろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Application.Exit()
        End If
    End Sub

    Private Sub menuConnection_Click(sender As Object, e As EventArgs) Handles menuConnection.Click

        Dim f As New frmConnectionProperty
        f.ShowDialog(Me)

    End Sub

#End Region
End Class