Public Class frmMain

#Region "フォームイベント"

	''' <summary>
	''' フォームロード時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load

		Me.Text = My.Application.Info.ProductName & " Ver." &
			My.Application.Info.Version.ToString

		XmlSettings.LoadFromXmlFile()
		Me.txtCSVFile.Text = XmlSettings.Instance.CSVFile
		Me.txtParentFolder.Text = XmlSettings.Instance.ParentFolder
		Me.txtOutputFolder.Text = XmlSettings.Instance.OutputFolder
		Me.txtLogFolder.Text = XmlSettings.Instance.LogFolder
		Me.numYStart.Value = XmlSettings.Instance.YStart

	End Sub

	''' <summary>
	''' フォームクロージング
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub frmMain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

		If MessageBox.Show("アプリケーションを終了します" & vbNewLine & "よろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
			e.Cancel = True
		Else
			XmlSettings.LoadFromXmlFile()
			XmlSettings.Instance.CSVFile = Me.txtCSVFile.Text
			XmlSettings.Instance.ParentFolder = Me.txtParentFolder.Text
			XmlSettings.Instance.OutputFolder = Me.txtOutputFolder.Text
			XmlSettings.Instance.LogFolder = Me.txtLogFolder.Text
			XmlSettings.Instance.YStart = Me.numYStart.Value
			XmlSettings.SaveToXmlFile()
		End If

	End Sub

#End Region

#Region "オブジェクトイベント"

	''' <summary>
	''' テキストボックスドラッグエンター時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub txt_DragEnter(sender As Object, e As DragEventArgs) Handles txtCSVFile.DragEnter, txtParentFolder.DragEnter, txtOutputFolder.DragEnter, txtLogFolder.DragEnter

		If e.Data.GetDataPresent(DataFormats.FileDrop) Then
			e.Effect = DragDropEffects.Copy
		Else
			e.Effect = DragDropEffects.None
		End If

	End Sub

	''' <summary>
	''' CSVファイルドロップ時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub txtCSVFile_DragDrop(sender As Object, e As DragEventArgs) Handles txtCSVFile.DragDrop

		Dim strFiles As String() = CType(e.Data.GetData(DataFormats.FileDrop, False), String())
		If System.IO.File.Exists(strFiles(0)) Then
			Me.txtCSVFile.Text = strFiles(0)
		End If

	End Sub

	''' <summary>
	''' 親フォルダドロップ時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub txtParentFolder_DragDrop(sender As Object, e As DragEventArgs) Handles txtParentFolder.DragDrop

		Dim strFiles As String() = CType(e.Data.GetData(DataFormats.FileDrop, False), String())
		If System.IO.Directory.Exists(strFiles(0)) Then
			Me.txtParentFolder.Text = strFiles(0)
		End If

	End Sub

	''' <summary>
	''' 出力フォルダドロップ時
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
	''' ログフォルダドロップ時
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
	''' 実行ボタン押下時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub btnRun_Click(sender As Object, e As EventArgs) Handles btnRun.Click

		If Not System.IO.File.Exists(Me.txtCSVFile.Text) Then
			MessageBox.Show("CSVファイルが指定されていません", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Exit Sub
		End If
		If Not System.IO.Directory.Exists(Me.txtParentFolder.Text) Then
			MessageBox.Show("親フォルダが指定されていません", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Exit Sub
		End If
		If Not System.IO.Directory.Exists(Me.txtOutputFolder.Text) Then
			MessageBox.Show("出力フォルダが指定されていません", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Exit Sub
		End If
		If Not System.IO.Directory.Exists(Me.txtLogFolder.Text) Then
			MessageBox.Show("ログ保存フォルダが指定されていません", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Exit Sub
		End If

		If MessageBox.Show("キャプション挿入処理を開始します" & vbNewLine & "よろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
			Exit Sub
		End If

		EnableControls(Me, False)

		Dim strCSVFile As String = Me.txtCSVFile.Text
		Dim strParentFolder As String = Me.txtParentFolder.Text
		Dim strOutputFolder As String = Me.txtOutputFolder.Text
		Dim strLogFolder As String = Me.txtLogFolder.Text

		Try
			Me.lstResult.Items.Clear()
			WriteLstResult(Me.lstResult, "CSVファイル：" & System.IO.Path.GetFileName(strCSVFile))
			WriteLstResult(Me.lstResult, "親フォルダ：" & strParentFolder)
			WriteLstResult(Me.lstResult, "出力フォルダ：" & strOutputFolder)
			WriteLstResult(Me.lstResult, "ログフォルダ：" & strLogFolder)
			WriteLstResult(Me.lstResult, "Y軸起点：" & Me.numYStart.Value)

			Dim iRecCount As Integer = 0
			Using parser As New CSVParser(strCSVFile, System.Text.Encoding.GetEncoding("Shift_JIS"))
				parser.Delimiter = vbTab    'タブ区切り
				parser.HasFieldsEnclosedInQuotes = True
				parser.TrimWhiteSpace = False

				iRecCount = 0

				parser.ReadFields() 'ヘッダ業を読み飛ばす
				'最終行まで読み込み
				While Not parser.EndOfData
					iRecCount += 1
					Dim row As String() = parser.ReadFields()
					'子フォルダ以下の画像ファイルをすべて配列に列挙する
					Dim strFiles As String() = GetFilesMostDeep(strParentFolder & "\" & row(0), {"*.tif"})

				End While
			End Using

		Catch ex As Exception

			MessageBox.Show(ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		Finally

			EnableControls(Me, True)

		End Try
	End Sub

#End Region

End Class
