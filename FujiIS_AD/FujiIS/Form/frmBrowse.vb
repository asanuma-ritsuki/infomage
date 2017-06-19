Public Class frmBrowse

#Region "フォームイベント"

	''' <summary>
	''' フォームロード時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub frmBrowse_Load(sender As Object, e As EventArgs) Handles MyBase.Load

		Me.Text = My.Application.Info.ProductName.ToString & " Ver." &
			My.Application.Info.Version.ToString & " - [フォルダ参照]"

		XmlSettings.LoadFromXmlFile()
		Me.txtImagePath.Text = XmlSettings.Instance.ImagePath

	End Sub

#End Region

#Region "オブジェクトイベント"

	''' <summary>
	''' ブラウズボタン押下時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click

		Dim fbd As New FolderBrowserDialog

		fbd.Description = "リンク付けする画像パスの親フォルダを指定してください"
		fbd.RootFolder = Environment.SpecialFolder.Desktop

		If IsNull(Me.txtImagePath.Text) Or Not System.IO.Directory.Exists(Me.txtImagePath.Text) Then
			fbd.SelectedPath = "C:\"
		Else
			fbd.SelectedPath = Me.txtImagePath.Text
		End If

		fbd.ShowNewFolderButton = False

		'ダイアログ表示
		If fbd.ShowDialog(Me) = DialogResult.OK Then
			Me.txtImagePath.Text = fbd.SelectedPath
		End If

	End Sub

	''' <summary>
	''' OKボタン押下時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click

		'設定ファイルに書き込む
		XmlSettings.LoadFromXmlFile()
		XmlSettings.Instance.ImagePath = Me.txtImagePath.Text
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

	''' <summary>
	''' DragEnter時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub txtImagePath_DragEnter(sender As Object, e As DragEventArgs) Handles txtImagePath.DragEnter
		'コントロール内にドラッグされたとき実行される
		If e.Data.GetDataPresent(DataFormats.FileDrop) Then
			'ドラッグされたデータ形式を調べ、ファイルのときはコピーとする
			e.Effect = DragDropEffects.Copy
		Else
			'ファイル以外は受け付けない
			e.Effect = DragDropEffects.None
		End If

	End Sub

	''' <summary>
	''' DragDrop時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub txtImagePath_DragDrop(sender As Object, e As DragEventArgs) Handles txtImagePath.DragDrop
		'コントロール内にドロップされたとき実行される
		'ドロップされたフォルダ名を取得する
		Dim strFolders As String() = CType(e.Data.GetData(DataFormats.FileDrop, False), String())
		'第1要素をテキストボックスにセットする
		'ファイルがドロップされても最終フォルダまでをセットする
		If System.IO.Directory.Exists(strFolders(0)) Then
			Me.txtImagePath.Text = strFolders(0)
		End If
	End Sub

#End Region

End Class