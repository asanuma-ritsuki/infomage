Imports System.Data.SqlClient

Public Class frmConnectionSetting

#Region "フォームイベント"

	''' <summary>
	''' フォームロード時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub frmConnectionSetting_Load(sender As Object, e As EventArgs) Handles MyBase.Load

		Me.Text = My.Application.Info.ProductName & " Ver." &
			My.Application.Info.Version.ToString & " - [接続設定]"

		XmlSettings.LoadFromXmlFile()
		Dim strConnectionString As String = ""

		Try
			'各オブジェクトに値を代入
			Me.txtServer.Text = XmlSettings.Instance.DataSource
			Me.txtInitialCatalog.Text = XmlSettings.Instance.InitialCatalog
			Me.txtLogin.Text = XmlSettings.Instance.UserID
			Me.txtPassword.Text = XmlSettings.Instance.Password

			strConnectionString = "Data Source=" & Me.txtServer.Text & ";" &
			"Initial Catalog=" & Me.txtInitialCatalog.Text & ";" &
			"Persist Security Info=True;" &
			"User ID=" & Me.txtLogin.Text & ";" &
			"Password=************"

			Me.txtResult.Text = strConnectionString

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & ex.StackTrace)
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

		XmlSettings.LoadFromXmlFile()

		Try

			XmlSettings.Instance.DataSource = Me.txtServer.Text
			XmlSettings.Instance.InitialCatalog = Me.txtInitialCatalog.Text
			XmlSettings.Instance.UserID = Me.txtLogin.Text
			XmlSettings.Instance.Password = Me.txtPassword.Text
			XmlSettings.SaveToXmlFile()

			Me.Close()

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & ex.StackTrace)
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
		XmlSettings.LoadFromXmlFile()

		Try
			strConnectionString = "Data Source=" & Me.txtServer.Text & ";" &
				"Initial Catalog=" & Me.txtInitialCatalog.Text & ";" &
				"Persist Security Info=True;" &
				"User ID=" & XmlSettings.Instance.UserID & ";" &
				"Password=" & XmlSettings.Instance.Password

			'接続文字列の設定
			con.ConnectionString = strConnectionString
			'データベースを開く
			con.Open()
			con.Close()

			MessageBox.Show("接続テストに成功しました", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information)

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & ex.StackTrace)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
			MessageBox.Show("接続テストに失敗しました。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		End Try

	End Sub

	''' <summary>
	''' TextBoxアクティブ時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	''' <remarks></remarks>
	Private Sub TextBox_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtServer.Enter,
																								  txtInitialCatalog.Enter,
																								  txtLogin.Enter,
																								  txtPassword.Enter
		CType(sender, TextBox).SelectAll()

	End Sub

	''' <summary>
	''' テキストボックス値変更時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub txt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
		Handles txtServer.TextChanged, txtInitialCatalog.TextChanged, txtLogin.TextChanged, txtPassword.TextChanged

		Dim strConnectionString As String

		strConnectionString = "Data Source=" & Me.txtServer.Text & ";" &
			"Initial Catalog=" & Me.txtInitialCatalog.Text & ";" &
			"Persist Security Info=True;" &
			"User ID=" & Me.txtLogin.Text & ";" &
			"Password=**********"

		Me.txtResult.Text = strConnectionString

	End Sub

#End Region

End Class