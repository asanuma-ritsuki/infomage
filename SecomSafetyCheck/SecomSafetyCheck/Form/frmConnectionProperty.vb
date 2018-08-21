Imports C1.Win.C1Themes

Public Class frmConnectionProperty

#Region "フォームイベント"

	''' <summary>
	''' フォームロード時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub frmConnectionProperty_Load(sender As Object, e As EventArgs) Handles MyBase.Load

		Me.Text = My.Application.Info.ProductName & " Ver." &
			My.Application.Info.Version.ToString & " - [接続設定]"

		'For Each themeName As String In C1ThemeController.GetThemes()
		'	Me.ComboBox1.Items.Add(themeName)
		'Next
		'Me.ComboBox1.SelectedIndex = 0

		Dim theme As C1Theme = C1ThemeController.GetThemeByName("Office2010Black", False)
		C1ThemeController.ApplyThemeToControlTree(Me, theme)

		XmlSettings.LoadFromXmlFile()
		Me.txtAccessFile.Text = XmlSettings.Instance.AccessFile

	End Sub


#End Region

#Region "オブジェクトイベント"

	''' <summary>
	''' 適用ボタン押下時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click

		If System.IO.File.Exists(Me.txtAccessFile.Text) Then
			If MessageBox.Show("Accessファイル名を保存します" & vbNewLine & "よろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
				Exit Sub
			End If
		Else
			MessageBox.Show("Accessファイルが存在しません", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Exit Sub
		End If
		XmlSettings.LoadFromXmlFile()
		XmlSettings.Instance.AccessFile = Me.txtAccessFile.Text
		XmlSettings.SaveToXmlFile()
		Me.Close()

	End Sub

	''' <summary>
	''' キャンセルボタン押下時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
		Me.Close()
	End Sub

	Private Sub txtAccessFile_DragEnter(sender As Object, e As DragEventArgs) Handles txtAccessFile.DragEnter

		If e.Data.GetDataPresent(DataFormats.FileDrop) Then
			e.Effect = DragDropEffects.Copy
		Else
			e.Effect = DragDropEffects.None
		End If

	End Sub

	Private Sub txtAccessFile_DragDrop(sender As Object, e As DragEventArgs) Handles txtAccessFile.DragDrop

		Dim strFiles As String() = CType(e.Data.GetData(DataFormats.FileDrop, False), String())
		Dim txtFile As TextBox = CType(sender, TextBox)

		If System.IO.File.Exists(strFiles(0)) Then

			If System.IO.Path.GetExtension(strFiles(0)) = ".mdb" Then
				txtFile.Text = strFiles(0)
			Else
				MessageBox.Show("Accessファイル(*.mdb)を指定してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
				Exit Sub
			End If
			'Else
			'	If System.IO.Directory.Exists(strFiles(0)) Then
			'		txtFile.Text = strFiles(0)
			'	End If
		End If

	End Sub

#End Region
End Class