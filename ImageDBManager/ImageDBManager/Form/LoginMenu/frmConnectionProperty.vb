Imports System.Data.SqlClient

Public Class frmConnectionProperty

#Region "フォームイベント"

	Private Sub frmConnectionProperty_Load(sender As Object, e As EventArgs) Handles MyBase.Load

		Me.Text = "接続設定"
		CaptionDisplayMode = StatusDisplayMode.TitleOnly

		XmlSettings.LoadFromXmlFile()
		Dim strConnectionString As String = ""

		Try
			'各オブジェクトに値を代入
			Me.txtServer.Text = XmlSettings.Instance.DataSource
			Me.txtInitialCatalog.Text = XmlSettings.Instance.InitialCatalog
			Me.txtUser.Text = XmlSettings.Instance.UserID
			Me.txtPassword.Text = XmlSettings.Instance.Password

			strConnectionString = "Data Source=" & Me.txtServer.Text & ";" &
				"Initial Catalog=" & Me.txtInitialCatalog.Text & ";" &
				"Persist Security Info=True;" &
				"User ID=" & Me.txtUser.Text & ";" &
				"Password=********"

			Me.txtResult.Text = strConnectionString

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		End Try

	End Sub

#End Region

#Region "オブジェクトイベント"

	''' <summary>
	''' キャンセルボタン押下時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click

		Me.Close()

	End Sub

	''' <summary>
	''' OKボタン押下時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click

		Try

			XmlSettings.LoadFromXmlFile()
			XmlSettings.Instance.DataSource = Me.txtServer.Text
			XmlSettings.Instance.InitialCatalog = Me.txtInitialCatalog.Text
			XmlSettings.Instance.UserID = Me.txtUser.Text
			XmlSettings.Instance.Password = Me.txtPassword.Text

			XmlSettings.SaveToXmlFile()

			Me.Close()

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Me.Close()

		End Try

	End Sub

	''' <summary>
	''' 接続テストボタン押下時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub btnTest_Click(sender As Object, e As EventArgs) Handles btnTest.Click

		Dim con As New SqlConnection
		Dim strConnectionString As String = ""

		Try

			strConnectionString = "Data Source=" & Me.txtServer.Text & ";" &
				"Initial Catalog=" & Me.txtInitialCatalog.Text & ";" &
				"User ID=" & Me.txtUser.Text & ";" &
				"Password=" & Me.txtPassword.Text

			'接続文字列の設定
			con.ConnectionString = strConnectionString
			'データベースを開く
			con.Open()
			con.Close()

			MessageBox.Show("接続テストに成功しました", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information)

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
			MessageBox.Show("接続テストに失敗しました", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Information)

		End Try

	End Sub

	''' <summary>
	''' テキストボックスアクティブ時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub TextBox_Enter(ByVal sender As Object, e As EventArgs) Handles txtServer.Enter,
			txtInitialCatalog.Enter, txtUser.Enter, txtPassword.Enter

		CType(sender, TextBox).BackColor = Color.LightPink
		CType(sender, TextBox).SelectAll()

	End Sub

	''' <summary>
	''' テキストボックスリーブ時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub TextBox_Leave(ByVal sender As Object, e As EventArgs) Handles txtServer.Leave,
			txtInitialCatalog.Leave, txtUser.Leave, txtPassword.Leave

		CType(sender, TextBox).BackColor = Color.White

	End Sub

	''' <summary>
	''' 接続文字列テキストボックス変更時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub txt_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtServer.TextChanged,
			txtInitialCatalog.TextChanged, txtUser.TextChanged, txtPassword.TextChanged

		Dim strConnectionString As String = ""

		strConnectionString = "Data Source=" & Me.txtServer.Text & ";" &
				"Initial Catalog=" & Me.txtInitialCatalog.Text & ";" &
				"Persist Security Info=True;" &
				"User ID=" & Me.txtUser.Text & ";" &
				"Password=********"

		Me.txtResult.Text = strConnectionString

	End Sub

#End Region

End Class