Public Class frmOutput

#Region "フォームイベント"

	''' <summary>
	''' フォームロード時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub frmOutput_Load(sender As Object, e As EventArgs) Handles MyBase.Load

		Me.Text = My.Application.Info.ProductName & " Ver." &
			My.Application.Info.Version.ToString & " - [CSV出力画面]"
		Me.KeyPreview = True
		CaptionDisplayMode = StatusDisplayMode.TitleOnly

		Initialize()

	End Sub

	''' <summary>
	''' フォームクロージング
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub frmImport_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

		XmlSettings.LoadFromXmlFile()
		'XmlSettings.Instance.ImportExcelFile = Me.txtImportExcel.Text
		'XmlSettings.Instance.ImportSaveFolder = Me.txtSaveFolder.Text
		XmlSettings.Instance.OutputFolder = Me.txtOutputFolder.Text
		XmlSettings.Instance.ImportLogFolder = Me.txtLogFolder.Text
		XmlSettings.SaveToXmlFile()

	End Sub

#End Region

#Region "オブジェクトイベント"

	''' <summary>
	''' 閉じるボタン押下時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
		Me.Close()
	End Sub

	''' <summary>
	''' テキストボックスドラッグエンター時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub txtOutputFolder_DragEnter(sender As Object, e As DragEventArgs) Handles txtOutputFolder.DragEnter, txtLogFolder.DragEnter
		If e.Data.GetDataPresent(DataFormats.FileDrop) Then
			e.Effect = DragDropEffects.Copy
		Else
			e.Effect = DragDropEffects.None
		End If
	End Sub

	''' <summary>
	''' 出力フォルダドラッグドロップ時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub txtOutputFolder_DragDrop(sender As Object, e As DragEventArgs) Handles txtOutputFolder.DragDrop

		Dim strFiles As String() = CType(e.Data.GetData(DataFormats.FileDrop, False), String())
		If System.IO.Directory.Exists(strFiles(0)) Then
			Me.txtOutputFolder.Text = strFiles(0)
		End If

	End Sub

	''' <summary>
	''' ログフォルダドラッグドロップ時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub txtLogFolder_DragDrop(sender As Object, e As DragEventArgs) Handles txtLogFolder.DragDrop

		Dim strFiles As String() = CType(e.Data.GetData(DataFormats.FileDrop, False), String())
		If System.IO.Directory.Exists(strFiles(0)) Then
			Me.txtLogFolder.Text = strFiles(0)
		End If

	End Sub

	''' <summary>
	''' 出力フォルダブラウズボタン押下時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub btnOutputFolderBrowse_Click(sender As Object, e As EventArgs) Handles btnOutputFolderBrowse.Click

		Me.txtOutputFolder.Text = FolderBrowse(Me.txtOutputFolder.Text)

	End Sub

	''' <summary>
	''' ログ保存先フォルダブラウズボタン押下時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub btnLogFolderBrowse_Click(sender As Object, e As EventArgs) Handles btnLogFolderBrowse.Click

		Me.txtLogFolder.Text = FolderBrowse(Me.txtLogFolder.Text)

	End Sub

	''' <summary>
	''' 出力ボタン押下時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub btnOutput_Click(sender As Object, e As EventArgs) Handles btnOutput.Click

		'フォルダチェック
		If Not System.IO.Directory.Exists(Me.txtOutputFolder.Text) Then
			MessageBox.Show("CSVファイルを出力するフォルダを指定してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Exit Sub
		End If
		If Not System.IO.Directory.Exists(Me.txtLogFolder.Text) Then
			MessageBox.Show("ログを保存するフォルダを指定してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Exit Sub
		End If

		If MessageBox.Show("該当ロットIDのCSVを出力します" & vbNewLine & "よろしいですか？" & vbNewLine & "ロットID：" & Me.txtLotID.Text, "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
			Exit Sub
		End If

		EnableControls(Me, False)
		Me.lstResult.Items.Clear()

		Try

			If OutputData(Me.txtLotID.Text, Me.lstResult) Then
				'データ移行が成功したときのみデータ出力へ
				If Not System.IO.Directory.Exists(Me.txtOutputFolder.Text & "\" & Me.txtLotID.Text) Then
					My.Computer.FileSystem.CreateDirectory(Me.txtOutputFolder.Text & "\" & Me.txtLotID.Text)
				End If
				OutputCSV(Me.txtLotID.Text, Me.lstResult, Me.txtOutputFolder.Text & "\" & Me.txtLotID.Text)
			Else
				MessageBox.Show("出力用テーブルへの移行に失敗しました", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
				Exit Sub
			End If

			OutputListLog(Me.lstResult, Me.txtLogFolder.Text & "\" & Me.txtLotID.Text, "CSV出力", Me.txtOffice.Text, Me.txtLotID.Text)
			MessageBox.Show("CSVファイルの作成が完了しました", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information)

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & ex.StackTrace)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		Finally

			EnableControls(Me, True)

		End Try

	End Sub

#End Region

#Region "プライベートメソッド"

	''' <summary>
	''' 初期化処理
	''' </summary>
	Private Sub Initialize()

		Me.btnBack.Text = "閉じる"
		XmlSettings.LoadFromXmlFile()
		Me.txtOutputFolder.Text = XmlSettings.Instance.OutputFolder
		Me.txtLogFolder.Text = XmlSettings.Instance.ImportLogFolder

	End Sub

#End Region

End Class