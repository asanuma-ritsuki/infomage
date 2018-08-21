Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.IO
Imports ImageMagick

Public Class Form1

#Region "プライベート変数"

	Private blnCancel As Boolean = False

#End Region

#Region "フォームイベント"

	''' <summary>
	''' フォームロード時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

		Me.Text = My.Application.Info.ProductName & " Ver." & My.Application.Info.Version.ToString

		Me.KeyPreview = True
		Initialize()

	End Sub

#End Region

#Region "オブジェクトイベント"

	''' <summary>
	''' 固定値を設定する
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
		'固定値を設定する
		Me.txtTargetPath.Enabled = Me.RadioButton1.Checked
		Me.txtOutPath.Enabled = Me.RadioButton1.Checked
		Me.txtTitle.Enabled = Me.RadioButton1.Checked
		Me.txtAuthor.Enabled = Me.RadioButton1.Checked
		Me.txtSubTitle.Enabled = Me.RadioButton1.Checked
		Me.txtKeyword.Enabled = Me.RadioButton1.Checked
		'CSVを参照して設定する
		Me.txtCSVFile.Enabled = Not Me.RadioButton1.Checked
		'TIF画像にプロパティを設定する
		Me.txtTIFTargetPath.Enabled = Not Me.RadioButton1.Checked
		Me.cmbTIFTitle.Enabled = Not Me.RadioButton1.Checked
		Me.txtTIFSubject.Enabled = Not Me.RadioButton1.Checked
		Me.txtTIFAuthor.Enabled = Not Me.RadioButton1.Checked
	End Sub

	''' <summary>
	''' CSVを参照して設定する
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
		'固定値を設定する
		Me.txtTargetPath.Enabled = Not Me.RadioButton2.Checked
		Me.txtOutPath.Enabled = Not Me.RadioButton2.Checked
		Me.txtTitle.Enabled = Not Me.RadioButton2.Checked
		Me.txtAuthor.Enabled = Not Me.RadioButton2.Checked
		Me.txtSubTitle.Enabled = Not Me.RadioButton2.Checked
		Me.txtKeyword.Enabled = Not Me.RadioButton2.Checked
		'CSVを参照して設定する
		Me.txtCSVFile.Enabled = Me.RadioButton2.Checked
		'TIF画像にプロパティを設定する
		Me.txtTIFTargetPath.Enabled = Not Me.RadioButton2.Checked
		Me.cmbTIFTitle.Enabled = Not Me.RadioButton2.Checked
		Me.txtTIFSubject.Enabled = Not Me.RadioButton2.Checked
		Me.txtTIFAuthor.Enabled = Not Me.RadioButton2.Checked
	End Sub

	''' <summary>
	''' TIF画像にプロパティを設定する
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton3.CheckedChanged
		'固定値を設定する
		Me.txtTargetPath.Enabled = Not Me.RadioButton3.Checked
		Me.txtOutPath.Enabled = Not Me.RadioButton3.Checked
		Me.txtTitle.Enabled = Not Me.RadioButton3.Checked
		Me.txtAuthor.Enabled = Not Me.RadioButton3.Checked
		Me.txtSubTitle.Enabled = Not Me.RadioButton3.Checked
		Me.txtKeyword.Enabled = Not Me.RadioButton3.Checked
		'CSVを参照して設定する
		Me.txtCSVFile.Enabled = Not Me.RadioButton3.Checked
		'TIF画像にプロパティを設定する
		Me.txtTIFTargetPath.Enabled = Me.RadioButton3.Checked
		Me.cmbTIFTitle.Enabled = Me.RadioButton3.Checked
		Me.txtTIFSubject.Enabled = Me.RadioButton3.Checked
		Me.txtTIFAuthor.Enabled = Me.RadioButton3.Checked
	End Sub

	''' <summary>
	''' 開始ボタン押下時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click

		Me.ProgressBar1.Value = 0
		Me.lblProgress.Text = "0 / 0"

		If Me.RadioButton1.Checked Then
			'固定値を設定する
			If Not System.IO.Directory.Exists(Me.txtTargetPath.Text) Then
				MessageBox.Show("対象フォルダを指定してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
				Exit Sub
			End If
			If Not System.IO.Directory.Exists(Me.txtOutPath.Text) Then
				MessageBox.Show("出力フォルダを指定してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
				Exit Sub
			End If
			If MessageBox.Show("対象フォルダ以下の全てのPDFの文書プロパティを書き換えます" & vbNewLine & "よろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
				Exit Sub
			End If

			blnCancel = False
			Me.btnStart.Enabled = False
			Me.btnStop.Enabled = True

			Dim strFiles As String() = GetFilesMostDeep(Me.txtTargetPath.Text, {"*.pdf"})
			Me.ProgressBar1.Maximum = strFiles.Count
			Me.ProgressBar1.Value = 0
			Me.lblProgress.Text = "0 / " & strFiles.Count

			For Each strFile As String In strFiles

				If blnCancel Then
					If MessageBox.Show("処理を中断します" & vbNewLine & "よろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
						Me.btnStart.Enabled = True
						Me.btnStop.Enabled = False
						Exit Sub
					End If
				End If
				Application.DoEvents()

				Dim reader As New PdfReader(strFile)
				Dim strOutFile As String = Me.txtOutPath.Text & "\" & System.IO.Path.GetFileName(strFile)
				If Not System.IO.Directory.Exists(Me.txtOutPath.Text) Then
					My.Computer.FileSystem.CreateDirectory(Me.txtOutPath.Text)
				End If
				Dim stamper As New PdfStamper(reader, New FileStream(strOutFile, FileMode.Create))
				Dim newInfo As Dictionary(Of String, String) = reader.Info
				'タイトル
				If newInfo.ContainsKey("Title") Then
					newInfo("Title") = Me.txtTitle.Text
				Else
					newInfo.Add("Title", Me.txtTitle.Text)
				End If
				'作成者
				If newInfo.ContainsKey("Author") Then
					newInfo("Author") = Me.txtAuthor.Text
				Else
					newInfo.Add("Author", Me.txtAuthor.Text)
				End If
				'サブタイトル
				If newInfo.ContainsKey("Subject") Then
					newInfo("Subject") = Me.txtSubTitle.Text
				Else
					newInfo.Add("Subject", Me.txtSubTitle.Text)
				End If
				'キーワード
				If newInfo.ContainsKey("Keywords") Then
					newInfo("Keywords") = Me.txtKeyword.Text
				Else
					newInfo.Add("Keywords", Me.txtKeyword.Text)
				End If
				stamper.MoreInfo = newInfo

				stamper.FormFlattening = True
				stamper.Close()
				reader.Close()

				Me.ProgressBar1.Value += 1
				Me.lblProgress.Text = Me.ProgressBar1.Value & " / " & strFiles.Count

			Next
		ElseIf Me.RadioButton2.Checked Then
			'CSVを参照して設定する
			If Not System.IO.File.Exists(Me.txtCSVFile.Text) Then
				MessageBox.Show("CSVファイルを指定してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
				Exit Sub
			End If
			If MessageBox.Show("指定されたCSVファイルの値をもとにPDFの文書プロパティを書き換えます" & vbNewLine & "よろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
				Exit Sub
			End If

			blnCancel = False
			Me.btnStart.Enabled = False
			Me.btnStop.Enabled = True
			Dim iRecCount As Integer = 0
			Dim iTotalCount As Integer = 0

			'トータルカウントの取得
			Using parser As New CSVParser(Me.txtCSVFile.Text, System.Text.Encoding.GetEncoding("Shift-JIS"))
				parser.Delimiter = ","
				parser.HasFieldsEnclosedInQuotes = True
				parser.TrimWhiteSpace = False
				While Not parser.EndOfData
					iTotalCount += 1
					parser.ReadFields()
				End While
			End Using

			Me.ProgressBar1.Maximum = iTotalCount
			Me.lblProgress.Text = "0 / " & iTotalCount

			Using parser As New CSVParser(Me.txtCSVFile.Text, System.Text.Encoding.GetEncoding("Shift-JIS"))
				parser.Delimiter = ","
				parser.HasFieldsEnclosedInQuotes = True
				parser.TrimWhiteSpace = False
				While Not parser.EndOfData
					Application.DoEvents()

					If blnCancel Then
						If MessageBox.Show("処理を中断します" & vbNewLine & "よろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
							Me.btnStart.Enabled = True
							Me.btnStop.Enabled = False
							Exit Sub
						End If
					End If

					Dim row As String() = parser.ReadFields()
					If row.Count = 5 Then
						'4項目の場合はTIF確定
						'Using bmp As New Bitmap(row(0))
						'	'タイトル
						'	Dim pi As Imaging.PropertyItem = bmp.GetPropertyItem(40091)
						'	pi.Value = System.Text.Encoding.Unicode.GetBytes(row(2))
						'	bmp.SetPropertyItem(pi)
						'	'件名
						'	pi = bmp.GetPropertyItem(40095)
						'	pi.Value = System.Text.Encoding.Unicode.GetBytes(row(3))
						'	bmp.SetPropertyItem(pi)
						'	'作成者
						'	pi = bmp.GetPropertyItem(40093)
						'	pi.Value = System.Text.Encoding.Unicode.GetBytes(row(4))
						'	bmp.SetPropertyItem(pi)
						'	bmp.Save(row(1))
						'	bmp.Dispose()
						'End Using

						''Magick.NETを使用してEXIF情報を操作する
						'Using image As New MagickImage(row(0))
						'	Dim profile As New ExifProfile()
						'	'profile.SetValue(ExifTag.ImageDescription, System.Text.Encoding.Unicode.GetBytes(row(2)))
						'	profile.SetValue(ExifTag.ImageDescription, row(2))
						'	profile.SetValue(ExifTag.XPSubject, System.Text.Encoding.Unicode.GetBytes(row(3)))
						'	'profile.SetValue(ExifTag.Artist, System.Text.Encoding.Unicode.GetBytes(row(4)))
						'	profile.SetValue(ExifTag.Artist, row(4))
						'	image.AddProfile(profile)
						'	image.Write(row(1))
						'End Using

						'Using image2 As New MagickImage(row(1))
						'	Dim myMagickExif As ExifProfile = image2.GetExifProfile()
						'	If Not myMagickExif Is Nothing Then
						'		Dim str As String = ""
						'		For Each exifValue In myMagickExif.Values
						'			str &= exifValue.Tag & "（"
						'			str &= exifValue.DataType & "）"
						'			str &= exifValue.ToString() & "\n"
						'		Next
						'		MessageBox.Show(str)
						'	End If
						'End Using

					Else
						'それ以外はPDF
						Dim reader As New PdfReader(row(0))
						Dim strOutFile As String = row(1) & "\" & System.IO.Path.GetFileName(row(0))
						If Not System.IO.Directory.Exists(row(1)) Then
							My.Computer.FileSystem.CreateDirectory(row(1))
						End If
						Dim stamper As New PdfStamper(reader, New FileStream(strOutFile, FileMode.Create))
						Dim newInfo As Dictionary(Of String, String) = reader.Info
						'タイトル
						If newInfo.ContainsKey("Title") Then
							newInfo("Title") = row(2)
						Else
							newInfo.Add("Title", row(2))
						End If
						'作成者
						If newInfo.ContainsKey("Author") Then
							newInfo("Author") = row(3)
						Else
							newInfo.Add("Author", row(3))
						End If
						'サブタイトル
						If newInfo.ContainsKey("Subject") Then
							newInfo("Subject") = row(4)
						Else
							newInfo.Add("Subject", row(4))
						End If
						'キーワード
						If newInfo.ContainsKey("Keywords") Then
							newInfo("Keywords") = row(5)
						Else
							newInfo.Add("Keywords", row(5))
						End If
						stamper.MoreInfo = newInfo

						stamper.FormFlattening = True
						stamper.Close()
						reader.Close()

					End If

					Me.ProgressBar1.Value += 1
					Me.lblProgress.Text = Me.ProgressBar1.Value & " / " & iTotalCount

				End While

			End Using
		Else
			'TIF EXIF編集
			'ExifToolを使用してバッチファイルを作成し、実行する
			If Not System.IO.Directory.Exists(Me.txtTIFTargetPath.Text) Then
				MessageBox.Show("対象フォルダを指定してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
				Exit Sub
			End If
			If MessageBox.Show("対象フォルダ以下の全てのTIF画像のプロパティを書き換えます" & vbNewLine & "よろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
				Exit Sub
			End If

			blnCancel = False
			Me.btnStart.Enabled = False
			Me.btnStop.Enabled = True
			Dim iRecCount As Integer = 0
			Dim iTotalCount As Integer = 0

			Dim strFiles As String() = GetFilesMostDeep(Me.txtTIFTargetPath.Text, {"*.tif"})
			Me.ProgressBar1.Maximum = strFiles.Count
			Me.ProgressBar1.Value = 0
			Me.lblProgress.Text = "0 / " & strFiles.Count
			Dim strWriteLine As String = ""

			'BOM無しUTF-8で書き込む(上書き)
			Using sw As New System.IO.StreamWriter(Application.StartupPath & "\convert.csv", False)
				'ヘッダの書き込み
				strWriteLine = Chr(34) & "SourceFile" & Chr(34) & "," &
					Chr(34) & "Artist" & Chr(34) & "," &
					Chr(34) & "Title" & Chr(34) & "," &
					Chr(34) & "XPSubject" & Chr(34) & "," &
					Chr(34) & "Make" & Chr(34) & "," &
					Chr(34) & "Model" & Chr(34) & "," &
					Chr(34) & "Software" & Chr(34)
				sw.WriteLine(strWriteLine)
			End Using

			'親パス格納用
			Dim strParentPath As String = ""
			For Each strFile As String In strFiles
				If blnCancel Then
					If MessageBox.Show("処理を中断します" & vbNewLine & "よろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
						Me.btnStart.Enabled = True
						Me.btnStop.Enabled = False
						Exit Sub
					End If
				End If
				Application.DoEvents()
				If Not strParentPath = System.IO.Path.GetDirectoryName(strFile) And Not IsNull(strParentPath) Then
					'コマンドライン実行
					StartProcess(strParentPath)

					'BOM無しUTF-8で書き込む(上書き)
					'CSVファイルを初期化する
					Using sw As New System.IO.StreamWriter(Application.StartupPath & "\convert.csv", False)
						'ヘッダの書き込み
						strWriteLine = Chr(34) & "SourceFile" & Chr(34) & "," &
							Chr(34) & "Artist" & Chr(34) & "," &
							Chr(34) & "Title" & Chr(34) & "," &
							Chr(34) & "XPSubject" & Chr(34) & "," &
							Chr(34) & "Make" & Chr(34) & "," &
							Chr(34) & "Model" & Chr(34) & "," &
							Chr(34) & "Software" & Chr(34)
						sw.WriteLine(strWriteLine)
					End Using

				End If
				'TIF画像パス、作成者、タイトル、件名をCSVファイルに書き込む(追記)
				Using sw As New System.IO.StreamWriter(Application.StartupPath & "\convert.csv", True)

					If Me.cmbTIFTitle.SelectedIndex = 0 Then
						'親パスをタイトルとする
						strWriteLine = Chr(34) & strFile & Chr(34) & "," &
							Chr(34) & Me.txtTIFAuthor.Text & Chr(34) & "," &
							Chr(34) & System.IO.Path.GetFileName(System.IO.Path.GetDirectoryName(strFile)) & Chr(34) & "," &
							Chr(34) & Me.txtTIFSubject.Text & Chr(34) & "," &
							Chr(34) & " " & Chr(34) & "," &
							Chr(34) & " " & Chr(34) & "," &
							Chr(34) & " " & Chr(34)
						sw.WriteLine(strWriteLine)
					Else
						'固定値
						strWriteLine = Chr(34) & strFile & Chr(34) & "," &
							Chr(34) & Me.txtTIFAuthor.Text & Chr(34) & "," &
							Chr(34) & Me.cmbTIFTitle.Text & Chr(34) & "," &
							Chr(34) & Me.txtTIFSubject.Text & Chr(34) & "," &
							Chr(34) & " " & Chr(34) & "," &
							Chr(34) & " " & Chr(34) & "," &
							Chr(34) & " " & Chr(34)
						sw.WriteLine(strWriteLine)
					End If
				End Using
				strParentPath = System.IO.Path.GetDirectoryName(strFile)
				Me.ProgressBar1.Value += 1
				Me.lblProgress.Text = Me.ProgressBar1.Value & " / " & strFiles.Count
			Next
			'コマンドライン実行
			StartProcess(strParentPath)

		End If

		MessageBox.Show("処理が完了しました", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information)
		Me.btnStart.Enabled = True
		Me.btnStop.Enabled = False

	End Sub

	''' <summary>
	''' 中断ボタン押下時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub btnStop_Click(sender As Object, e As EventArgs) Handles btnStop.Click

		blnCancel = True

	End Sub

	''' <summary>
	''' 対象フォルダDragEnter
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub txt_DragEnter(sender As Object, e As DragEventArgs) Handles txtTargetPath.DragEnter, txtOutPath.DragEnter, txtTIFTargetPath.DragEnter

		If e.Data.GetDataPresent(DataFormats.FileDrop) Then
			e.Effect = DragDropEffects.Copy
		Else
			e.Effect = DragDropEffects.None
		End If

	End Sub

	''' <summary>
	''' 対象フォルダDragDrop
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub txt_DragDrop(sender As Object, e As DragEventArgs) Handles txtTargetPath.DragDrop, txtOutPath.DragDrop, txtTIFTargetPath.DragDrop

		Dim strFiles As String() = CType(e.Data.GetData(DataFormats.FileDrop, False), String())
		Dim txtFile As TextBox = CType(sender, TextBox)

		If System.IO.File.Exists(strFiles(0)) Then
			txtFile.Text = System.IO.Path.GetDirectoryName(strFiles(0))
		Else
			If System.IO.Directory.Exists(strFiles(0)) Then
				txtFile.Text = strFiles(0)
			Else
				'MessageBox.Show("該当のフォルダが存在しません", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
				'Exit Sub
			End If
		End If

	End Sub

	''' <summary>
	''' CSVファイルDragEnter
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub txtCSVFile_DragEnter(sender As Object, e As DragEventArgs) Handles txtCSVFile.DragEnter

		If e.Data.GetDataPresent(DataFormats.FileDrop) Then
			e.Effect = DragDropEffects.Copy
		Else
			e.Effect = DragDropEffects.None
		End If

	End Sub

	''' <summary>
	''' CSVファイルDragDrop
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub txtCSVFile_DragDrop(sender As Object, e As DragEventArgs) Handles txtCSVFile.DragDrop

		Dim strFiles As String() = CType(e.Data.GetData(DataFormats.FileDrop, False), String())
		Dim txtFile As TextBox = CType(sender, TextBox)

		If System.IO.File.Exists(strFiles(0)) And System.IO.Path.GetExtension(strFiles(0)) = ".csv" Then
			txtFile.Text = strFiles(0)
		Else
			If System.IO.Directory.Exists(strFiles(0)) Then
				txtFile.Text = strFiles(0)
			Else
				'MessageBox.Show("該当のフォルダが存在しません", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
				'Exit Sub
			End If
		End If

	End Sub

	''' <summary>
	''' フォームクロージング時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

		If MessageBox.Show("アプリケーションを終了します" & vbNewLine & "よろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
			e.Cancel = True
		Else
			XmlSettings.LoadFromXmlFile()
			XmlSettings.Instance.TargetPath = Me.txtTargetPath.Text
			XmlSettings.Instance.OutPath = Me.txtOutPath.Text
			XmlSettings.Instance.Title = Me.txtTitle.Text
			XmlSettings.Instance.Author = Me.txtAuthor.Text
			XmlSettings.Instance.SubTitle = Me.txtSubTitle.Text
			XmlSettings.Instance.Keywords = Me.txtKeyword.Text
			XmlSettings.Instance.CSVFile = Me.txtCSVFile.Text
			XmlSettings.Instance.TIFTargetPath = Me.txtTIFTargetPath.Text
			XmlSettings.Instance.TIFSubject = Me.txtTIFSubject.Text
			XmlSettings.Instance.TIFAuthor = Me.txtTIFAuthor.Text
			XmlSettings.SaveToXmlFile()
		End If
	End Sub

#End Region

#Region "プライベートメソッド"

	''' <summary>
	''' 初期化処理
	''' </summary>
	Private Sub Initialize()
		Me.txtTargetPath.Enabled = Me.RadioButton1.Checked
		Me.txtOutPath.Enabled = Me.RadioButton1.Checked
		Me.txtTitle.Enabled = Me.RadioButton1.Checked
		Me.txtAuthor.Enabled = Me.RadioButton1.Checked
		Me.txtSubTitle.Enabled = Me.RadioButton1.Checked
		Me.txtKeyword.Enabled = Me.RadioButton1.Checked

		Me.txtCSVFile.Enabled = Not Me.RadioButton1.Checked
		Me.btnStop.Enabled = False

		Me.cmbTIFTitle.SelectedIndex = 0
		Me.lblProgress.Text = "0 / 0"

		XmlSettings.LoadFromXmlFile()
		Me.txtTargetPath.Text = XmlSettings.Instance.TargetPath
		Me.txtOutPath.Text = XmlSettings.Instance.OutPath
		Me.txtTitle.Text = XmlSettings.Instance.Title
		Me.txtAuthor.Text = XmlSettings.Instance.Author
		Me.txtSubTitle.Text = XmlSettings.Instance.SubTitle
		Me.txtKeyword.Text = XmlSettings.Instance.Keywords
		Me.txtCSVFile.Text = XmlSettings.Instance.CSVFile
		Me.txtTIFTargetPath.Text = XmlSettings.Instance.TIFTargetPath
		Me.txtTIFSubject.Text = XmlSettings.Instance.TIFSubject
		Me.txtTIFAuthor.Text = XmlSettings.Instance.TIFAuthor

	End Sub

	''' <summary>
	''' 所定のコマンドラインを実行する
	''' </summary>
	Private Sub StartProcess(ByVal strParentPath As String)

		Dim p As New System.Diagnostics.Process()
		p.StartInfo.FileName = System.Environment.GetEnvironmentVariable("ComSpec")
		'出力を読み取れるようにする
		p.StartInfo.UseShellExecute = False
		p.StartInfo.RedirectStandardOutput = True
		p.StartInfo.RedirectStandardInput = False
		'ウィンドウを表示しないようにする
		p.StartInfo.CreateNoWindow = True
		'コマンドラインを指定（"/c"は実行後閉じるために必要）
		p.StartInfo.Arguments = "/c " & Application.StartupPath & "\exiftool.exe -overwrite_original -csv=convert.csv " & strParentPath
		p.Start()
		Dim strResults As String = p.StandardOutput.ReadToEnd()
		'プロセス終了まで待機する
		'WaitForExitはReadToEndの後である必要がある
		'(親プロセス、子プロセスでブロック防止の為)
		p.WaitForExit()
		p.Close()

	End Sub

#End Region

End Class
