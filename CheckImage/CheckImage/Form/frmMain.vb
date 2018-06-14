Imports Leadtools
Imports Leadtools.Codecs

Public Class frmMain

#Region "プライベート変数"

	Private codecs As RasterCodecs
	Private _cancel As Boolean = False

#End Region

#Region "フォームイベント"

	''' <summary>
	''' フォームロード時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load

		Me.Text = My.Application.Info.ProductName.ToString & " Ver." &
			My.Application.Info.Version.ToString

		Initialize()

	End Sub

	''' <summary>
	''' フォームクロージング
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub frmMain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

		If MessageBox.Show("アプリケーションを終了します" & vbNewLine & "よろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
			e.Cancel = True
			Exit Sub

		Else
			XmlSettings.LoadFromXmlFile()
			XmlSettings.Instance.SrcFolder = Me.txtSrcFolder.Text
			XmlSettings.Instance.OfferCSV = Me.txtOfferCSV.Text
			XmlSettings.Instance.OutFolder = Me.txtOutFolder.Text
			XmlSettings.Instance.JpegSizeFrom = Me.numJpegSizeFrom.Value
			XmlSettings.Instance.JpegSizeTo = Me.numJpegSizeTo.Value
			If Me.WindowState = FormWindowState.Maximized Then
				XmlSettings.Instance.State = FormWindowState.Maximized
				Me.WindowState = FormWindowState.Normal
			Else
				XmlSettings.Instance.State = FormWindowState.Normal
			End If
			XmlSettings.Instance.LocationX = Me.Location.X
			XmlSettings.Instance.LocationY = Me.Location.Y
			XmlSettings.Instance.SizeX = Me.Size.Width
			XmlSettings.Instance.SizeY = Me.Size.Height

			'使用カメラ
			Dim strCameras As String = ""
			Dim iIndex As Integer = 0
			For Each iCamera As Integer In Me.checkedList.CheckedIndices()
				iIndex += 1
				If iIndex = 1 Then
					strCameras = iCamera.ToString()
				Else
					strCameras &= ":" & iCamera.ToString()
				End If
			Next
			XmlSettings.Instance.Camera = strCameras
			XmlSettings.SaveToXmlFile()
		End If

	End Sub

#End Region

#Region "プライベートメソッド"

	''' <summary>
	''' 初期化処理
	''' </summary>
	''' <remarks></remarks>
	Private Sub Initialize()

		'LEADTOOLS17.5ライセンスキーの組み込み
		RasterSupport.SetLicense(Application.StartupPath & "\LEAD175ImgSuite.lic", "+sxwXvpT1JbgbQ7DAdF9k8WRWcBnLgwIjN2a3sVpuzOIoMTYIWPT13qYg3qhCnFE")
		'RasterCodecsの初期化
		'入出力ライブラリの起動に必要なデータを初期化する
		codecs = New RasterCodecs

		'カメラマスタのセット
		ViewCamera()

		'設定ファイルの読み込み
		XmlSettings.LoadFromXmlFile()
		Me.txtSrcFolder.Text = XmlSettings.Instance.SrcFolder()
		Me.txtOfferCSV.Text = XmlSettings.Instance.OfferCSV()
		Me.txtOutFolder.Text = XmlSettings.Instance.OutFolder()
		Me.numJpegSizeFrom.Value = XmlSettings.Instance.JpegSizeFrom()
		Me.numJpegSizeTo.Value = XmlSettings.Instance.JpegSizeTo()
		If Not IsNull(XmlSettings.Instance.Camera) Then
			Dim strCameras As String() = XmlSettings.Instance.Camera.Split(":"c)
			For Each strCamera As String In strCameras
				Me.checkedList.SetItemChecked(CInt(strCamera), True)
			Next
		End If
		Me.Location = New Point(XmlSettings.Instance.LocationX, XmlSettings.Instance.LocationY)
		Me.Size = New Size(XmlSettings.Instance.SizeX, XmlSettings.Instance.SizeY)
		Me.WindowState = XmlSettings.Instance.State
		Me.numSerialDigit.Value = XmlSettings.Instance.SerialDigit
		Me.numSerialFrom.Value = XmlSettings.Instance.SerialFrom
		Me.chkFileSerial.Checked = True

		Me.lblProgress.Text = "0 / 0"
		EnableControls(True)

	End Sub

	''' <summary>
	''' 画像ファイルよりEXIF情報を取得する
	''' </summary>
	''' <param name="strFile"></param>
	''' <param name="strMake"></param>
	''' <param name="strModel"></param>
	''' <returns></returns>
	Private Function GetComments(ByVal strFile As String, ByRef strMake As String, ByRef strModel As String) As Boolean

		Dim comment As RasterCommentMetadata
		Try
			'Make
			comment = codecs.ReadComment(strFile, 1, RasterCommentMetadataType.Make)
			If Not comment Is Nothing Then
				strMake = comment.ToAscii()
			Else
				strMake = ""
			End If

			'Model
			comment = codecs.ReadComment(strFile, 1, RasterCommentMetadataType.Model)
			If Not comment Is Nothing Then
				strModel = comment.ToAscii()
			Else
				strModel = ""
			End If

			Return True

		Catch ex As Exception

			WriteLstResult(Me.lstResult, "カメラ情報の取得に失敗：" & strFile, ResultMark.ErrorMark)
			Return False

		End Try

		'Dim tifComments As RasterCommentMetadataType() =
		'	{
		'		RasterCommentMetadataType.Make,
		'		RasterCommentMetadataType.Model,
		'		RasterCommentMetadataType.ColorSpace
		'	}


		'For Each tifComment As RasterCommentMetadataType In tifComments
		'	Dim comment As RasterCommentMetadata = codecs.ReadComment(strFile, 1, tifComment)
		'	If Not comment Is Nothing Then

		'		Dim dataType As RasterCommentMetadataDataType = RasterCommentMetadata.GetDataType(comment.Type)

		'		Dim byteData As Byte()
		'		Dim shortData As Short()
		'		Dim rationalData As RasterMetadataRational()
		'		Dim urationalData As RasterMetadataURational()

		'		Select Case dataType
		'			Case RasterCommentMetadataDataType.Ascii
		'				Console.WriteLine(comment.ToAscii())

		'			Case RasterCommentMetadataDataType.Byte
		'				byteData = comment.ToByte()
		'				Dim i As Integer = 0
		'				Do While i < byteData.Length
		'					Console.Write("{0:X} ", byteData(i))
		'					i += 1
		'				Loop
		'				Console.WriteLine()

		'			Case RasterCommentMetadataDataType.Int16
		'				shortData = comment.ToInt16()
		'				Dim i As Integer = 0
		'				Do While i < shortData.Length
		'					Console.Write("{0:X} ", shortData(i))
		'					i += 1
		'				Loop
		'				Console.WriteLine()

		'			Case RasterCommentMetadataDataType.Rational
		'				rationalData = comment.ToRational()
		'				Dim i As Integer = 0
		'				Do While i < rationalData.Length
		'					Console.Write("{0}/{1) ", rationalData(i).Numerator, rationalData(i).Denominator)
		'					i += 1
		'				Loop
		'				Console.WriteLine()

		'			Case RasterCommentMetadataDataType.URational
		'				urationalData = comment.ToURational()
		'				Dim i As Integer = 0
		'				Do While i < urationalData.Length
		'					Console.Write("{0}/{1) ", urationalData(i).Numerator, urationalData(i).Denominator)
		'					i += 1
		'				Loop
		'				Console.WriteLine()
		'		End Select

		'	End If
		'Next
	End Function

	''' <summary>
	''' カラースペースの取得
	''' </summary>
	''' <param name="strFile"></param>
	''' <returns></returns>
	Private Function GetColorSpace(ByVal strFile As String) As String
		'2018/05/25
		'ImageMagickだと合成画像など大きいサイズの画像読み込み時にエラーとなってしまう
		'ファイルの先頭数メガを読み込んで「Adobe RGB」や「sRGB IEC61966-2.1」等の
		'文言を検索して判断するように変更
		'Dim img As ImageMagick.MagickImage = Nothing
		Dim strResult As String = ""

		Try
			'該当ファイルを開く
			Dim fs As New System.IO.FileStream(strFile, System.IO.FileMode.Open, System.IO.FileAccess.Read)
			'指定バイト数をバイト型配列に格納する
			Dim iBytes As Integer = 1024000 '1メガ
			Dim bs(iBytes - 1) As Byte
			'ファイルの内容をはじめから指定バイト数分読み込む
			fs.Read(bs, 0, bs.Length)
			fs.Close()
			'バイト型配列を文字列に変換して、色空間情報が格納されているか確認する
			Dim str As String = System.Text.Encoding.GetEncoding("Shift-JIS").GetString(bs)

			If str.IndexOf("Adobe RGB") >= 0 Then
				'Adobe RGB
				strResult = "AdobeRGB"
			ElseIf str.IndexOf("sRGB IEC61966-2.1") >= 0 Then
				'sRGB
				strResult = "sRGB"
			Else
				'その他
				strResult = "その他"
			End If

			'img = New ImageMagick.MagickImage(strFile)
			'Dim target As ImageMagick.ColorProfile = img.GetColorProfile()

			''テスト
			''ICCCheck(target)

			'If target Is Nothing Then
			'	'NULLの場合はその他
			'	strResult = "その他"
			'ElseIf target = ImageMagick.ColorProfile.AdobeRGB1998 Then
			'	'AdobeRGB
			'	strResult = "AdobeRGB"
			'ElseIf target = ImageMagick.ColorProfile.SRGB Then
			'	'sRGB
			'	strResult = "sRGB"
			'	'ElseIf target.ColorSpace = 23 Then
			'	'	'sRGB
			'	'	strResult = "sRGB"
			'Else
			'	'その他
			'	'バイト型配列を文字列に変換して「sRGB IEC61966-2.1」という文言が存在するか調べる
			'	Dim targetbyte As Byte() = target.ToByteArray()
			'	Dim str = System.Text.Encoding.GetEncoding("Shift-JIS").GetString(targetbyte)
			'	If str.IndexOf("sRGB IEC61966-2.1") >= 0 Then
			'		'sRGB
			'		strResult = "sRGB"
			'	Else
			'		strResult = "その他"
			'	End If

			'End If

			Return strResult

		Catch ex As Exception
			MessageBox.Show(ex.Message)
			WriteLstResult(Me.lstResult, "カラープロファイルの取得に失敗：" & strFile, ResultMark.ErrorMark)
			Return ""

			'Finally

			'	img.Dispose()

		End Try

	End Function

	''' <summary>
	''' コントロールの有効無効切り替え
	''' </summary>
	''' <param name="bool"></param>
	Private Sub EnableControls(ByVal bool As Boolean)

		Me.txtSrcFolder.Enabled = bool
		Me.txtOfferCSV.Enabled = bool
		Me.txtOutFolder.Enabled = bool
		Me.numJpegSizeFrom.Enabled = bool
		Me.numJpegSizeTo.Enabled = bool
		Me.chkFileSerial.Enabled = bool
		Me.numSerialDigit.Enabled = bool
		Me.numSerialFrom.Enabled = bool
		Me.btnStart.Enabled = bool
		Me.btnCancel.Enabled = Not bool

	End Sub

	''' <summary>
	''' メイングリッドに判定を書き込む
	''' </summary>
	''' <param name="iIndex"></param>
	''' <param name="blnJudge"></param>
	Private Sub WriteJudge(ByVal iIndex As Integer, ByVal blnJudge As Boolean)

		If blnJudge Then
			'○
			If Me.C1FGridResult(iIndex, "判定") = "×" Then
				'×の場合は更新しない
			Else
				Me.C1FGridResult(iIndex, "判定") = "○"
			End If
		Else
			'×
			'必ず×
			Me.C1FGridResult(iIndex, "判定") = "×"
		End If

	End Sub

	''' <summary>
	''' カメラマスタをグリッドにセットする
	''' </summary>
	Private Sub ViewCamera()

		Me.C1FGridCamera.Rows.Count = 1

		'実行ファイルのフォルダ直下の「CameraList.txt」を参照して一覧をグリッドにセットする
		Dim strCameraList As String = Application.StartupPath() & "\CameraList.txt"
		Dim iRecCount As Integer = 0

		Using parser As New CSVParser(strCameraList, System.Text.Encoding.GetEncoding("Shift-JIS"))
			parser.Delimiter = vbTab
			parser.HasFieldsEnclosedInQuotes = True
			parser.TrimWhiteSpace = False
			iRecCount = 0
			'最終行まで読み込み
			While Not parser.EndOfData
				iRecCount += 1
				Dim row As String() = parser.ReadFields()
				Dim iIndex As Integer = Me.C1FGridCamera.Rows.Count
				Me.C1FGridCamera.Rows.Count = iIndex + 1
				Me.C1FGridCamera(iIndex, "No") = iIndex
				Me.C1FGridCamera(iIndex, "モデル") = row(0)
				Me.C1FGridCamera(iIndex, "製造元") = row(1)
				Me.C1FGridCamera(iIndex, "長辺") = row(2)
				Me.C1FGridCamera(iIndex, "短辺") = row(3)
				'チェックリストボックスにも追加
				Me.checkedList.Items.Add(row(0))
			End While
		End Using
		WriteLstResult(Me.lstResult, "カメラリスト読み込み終了：" & iRecCount & "レコード")

		'Dim iIndex As Integer = Me.C1FGridCamera.Rows.Count
		'Me.C1FGridCamera.Rows.Count = iIndex + 1
		'Me.C1FGridCamera(iIndex, "No") = iIndex
		'Me.C1FGridCamera(iIndex, "モデル") = "P65+"
		'Me.C1FGridCamera(iIndex, "製造元") = "Phase One"
		'Me.C1FGridCamera(iIndex, "長辺") = 8984
		'Me.C1FGridCamera(iIndex, "短辺") = 6732

		'iIndex = Me.C1FGridCamera.Rows.Count
		'Me.C1FGridCamera.Rows.Count = iIndex + 1
		'Me.C1FGridCamera(iIndex, "No") = iIndex
		'Me.C1FGridCamera(iIndex, "モデル") = "IQ3 80MP"
		'Me.C1FGridCamera(iIndex, "製造元") = "Phase One"
		'Me.C1FGridCamera(iIndex, "長辺") = 10320
		'Me.C1FGridCamera(iIndex, "短辺") = 7752

		'iIndex = Me.C1FGridCamera.Rows.Count
		'Me.C1FGridCamera.Rows.Count = iIndex + 1
		'Me.C1FGridCamera(iIndex, "No") = iIndex
		'Me.C1FGridCamera(iIndex, "モデル") = "IQ180"
		'Me.C1FGridCamera(iIndex, "製造元") = "Phase One"
		'Me.C1FGridCamera(iIndex, "長辺") = 10328
		'Me.C1FGridCamera(iIndex, "短辺") = 7760

		'iIndex = Me.C1FGridCamera.Rows.Count
		'Me.C1FGridCamera.Rows.Count = iIndex + 1
		'Me.C1FGridCamera(iIndex, "No") = iIndex
		'Me.C1FGridCamera(iIndex, "モデル") = "Credo 80"
		'Me.C1FGridCamera(iIndex, "製造元") = "Leaf"
		'Me.C1FGridCamera(iIndex, "長辺") = 10328
		'Me.C1FGridCamera(iIndex, "短辺") = 7760

		'iIndex = Me.C1FGridCamera.Rows.Count
		'Me.C1FGridCamera.Rows.Count = iIndex + 1
		'Me.C1FGridCamera(iIndex, "No") = iIndex
		'Me.C1FGridCamera(iIndex, "モデル") = "IQ1 100MP"
		'Me.C1FGridCamera(iIndex, "製造元") = "Phase One"
		'Me.C1FGridCamera(iIndex, "長辺") = 11608
		'Me.C1FGridCamera(iIndex, "短辺") = 8708

		'iIndex = Me.C1FGridCamera.Rows.Count
		'Me.C1FGridCamera.Rows.Count = iIndex + 1
		'Me.C1FGridCamera(iIndex, "No") = iIndex
		'Me.C1FGridCamera(iIndex, "モデル") = "Canon EOS 5DS"
		'Me.C1FGridCamera(iIndex, "製造元") = "Canon"
		'Me.C1FGridCamera(iIndex, "長辺") = 8688
		'Me.C1FGridCamera(iIndex, "短辺") = 5792

		'iIndex = Me.C1FGridCamera.Rows.Count
		'Me.C1FGridCamera.Rows.Count = iIndex + 1
		'Me.C1FGridCamera(iIndex, "No") = iIndex
		'Me.C1FGridCamera(iIndex, "モデル") = "Canon EOS 5D Mark II"
		'Me.C1FGridCamera(iIndex, "製造元") = "Canon"
		'Me.C1FGridCamera(iIndex, "長辺") = 5616
		'Me.C1FGridCamera(iIndex, "短辺") = 3744

		'iIndex = Me.C1FGridCamera.Rows.Count
		'Me.C1FGridCamera.Rows.Count = iIndex + 1
		'Me.C1FGridCamera(iIndex, "No") = iIndex
		'Me.C1FGridCamera(iIndex, "モデル") = "NIKON D800"
		'Me.C1FGridCamera(iIndex, "製造元") = "NIKON CORPORATION"
		'Me.C1FGridCamera(iIndex, "長辺") = 7360
		'Me.C1FGridCamera(iIndex, "短辺") = 4912

	End Sub

#End Region

#Region "オブジェクトイベント"

	''' <summary>
	''' DragEnter
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub txtFolder_DragEnter(sender As Object, e As DragEventArgs) Handles txtSrcFolder.DragEnter, txtOutFolder.DragEnter, txtOfferCSV.DragEnter

		If e.Data.GetDataPresent(DataFormats.FileDrop) Then
			e.Effect = DragDropEffects.Copy
		Else
			e.Effect = DragDropEffects.None
		End If

	End Sub

	''' <summary>
	''' フォルダ選択DragDrop
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub txtFolder_DragDrop(sender As Object, e As DragEventArgs) Handles txtSrcFolder.DragDrop, txtOutFolder.DragDrop

		Dim txt As TextBox = CType(sender, TextBox)

		Dim strFileName As String() = CType(e.Data.GetData(DataFormats.FileDrop, False), String())
		If System.IO.Directory.Exists(strFileName(0)) Then
			txt.Text = strFileName(0)
		ElseIf System.IO.File.Exists(strFileName(0)) Then
			txt.Text = System.IO.Path.GetDirectoryName(strFileName(0))
		Else
			txt.Text = ""
		End If

	End Sub

	''' <summary>
	''' ファイル選択DragDrop
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub txtOfferCSV_DragDrop(sender As Object, e As DragEventArgs) Handles txtOfferCSV.DragDrop

		Dim txt As TextBox = CType(sender, TextBox)

		Dim strFileName As String() = CType(e.Data.GetData(DataFormats.FileDrop, False), String())
		If System.IO.File.Exists(strFileName(0)) Then
			txt.Text = strFileName(0)
		Else
			txt.Text = ""
		End If

	End Sub

	''' <summary>
	''' 開始ボタン押下時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click

		If Not System.IO.Directory.Exists(Me.txtSrcFolder.Text) Then
			MessageBox.Show("画像が格納されている親パスを指定して下さい", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Exit Sub
		End If
		If Not System.IO.Directory.Exists(Me.txtOutFolder.Text) Then
			MessageBox.Show("出力先のパスを指定して下さい", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Exit Sub
		End If
		If Me.checkedList.CheckedItems.Count = 0 Then
			MessageBox.Show("使用カメラを最低１つ選択して下さい", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Exit Sub
		End If
		If Me.numJpegSizeFrom.Value > Me.numJpegSizeTo.Value Then
			MessageBox.Show("JPEGサイズのFromToが逆転しています", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Exit Sub
		End If

		If Not System.IO.File.Exists(Me.txtOfferCSV.Text) Then
			If MessageBox.Show("提供データが存在しません" & vbNewLine & "フォルダチェックを行わずに進めますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
				Exit Sub
			End If
		End If
		If MessageBox.Show("画像チェックを開始します" & "よろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
			Exit Sub
		End If

		Dim strDateNow As String = Date.Now.ToString("yyyyMMdd_HHmmss")

		EnableControls(False)
		_cancel = False
		WriteLstResult(Me.lstResult, "処理開始")
		WriteLstResult(Me.lstResult, "対象フォルダ：" & Me.txtSrcFolder.Text)
		Dim blnOfferCSV As Boolean = False  '提供データが有るかどうか
		If System.IO.File.Exists(Me.txtOfferCSV.Text) Then
			WriteLstResult(Me.lstResult, "提供データCSV：" & Me.txtOfferCSV.Text)
			blnOfferCSV = True
		Else
			WriteLstResult(Me.lstResult, "提供データCSV：なし")
		End If
		If Not Me.chkFileSerial.Checked Then
			WriteLstResult(Me.lstResult, "ファイル連番チェックを行わない")
		End If

		Dim strFiles As String() = GetFilesMostDeep(Me.txtSrcFolder.Text, {"*.tiff", "*.tif", "*.jpg"})

		Me.ProgressBar1.Maximum = strFiles.Length
		Me.ProgressBar1.Minimum = 0
		Me.ProgressBar1.Value = 0

		Me.C1FGridResult.Rows.Count = 1
		Me.C1FGridFolder.Rows.Count = 1
		Me.C1FGridOffer.Rows.Count = 1

		'提供データCSVの読み込み
		If blnOfferCSV Then
			WriteLstResult(Me.lstResult, "提供データCSV読み込み開始")
			Dim iRecCountOffer As Integer = 0
			Using parser As New CSVParser(Me.txtOfferCSV.Text, System.Text.Encoding.GetEncoding("Shift-JIS"))
				parser.Delimiter = ","
				parser.HasFieldsEnclosedInQuotes = True
				parser.TrimWhiteSpace = False
				iRecCountOffer = 0
				'最終行まで読み込み
				While Not parser.EndOfData
					iRecCountOffer += 1
					Dim row As String() = parser.ReadFields()
					Dim iIndex As Integer = Me.C1FGridOffer.Rows.Count
					Me.C1FGridOffer.Rows.Count = iIndex + 1
					Me.C1FGridOffer(iIndex, "No") = iIndex
					Me.C1FGridOffer(iIndex, "文献コード") = row(0)
					Me.C1FGridOffer(iIndex, "使用済") = False
				End While

			End Using
			WriteLstResult(Me.lstResult, "提供データCSV読み込み終了：" & iRecCountOffer & "レコード")
		End If

		WriteLstResult(Me.lstResult, "イメージ情報取得・チェック開始")

		Dim strBeforeFolder As String = ""  '前のフォルダ名を格納する
		Dim iFolderSerial As Integer = Me.numSerialFrom.Value    'フォルダ単位の連番
		For Each strFile As String In strFiles
			Application.DoEvents()
			Me.ProgressBar1.Value += 1
			Me.lblProgress.Text = Me.ProgressBar1.Value & " / " & strFiles.Length

			If _cancel Then
				If MessageBox.Show("処理を中断しますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
					EnableControls(True)
					Exit Sub
				Else
					_cancel = False
				End If
			End If

			Try
				'フォルダ情報を書き込む
				Dim strFolderName As String = System.IO.Path.GetFileName(System.IO.Path.GetDirectoryName(strFile))
				If strBeforeFolder = strFolderName Then
					Dim iHit As Integer = Me.C1FGridFolder.FindRow(strFolderName, 1, 1, False)
					'ファイル数をインクリメント
					Me.C1FGridFolder(iHit, "ファイル数") += 1
					'フォルダ単位の連番をインクリメント
					iFolderSerial += 1
				Else
					'相違していたら新規レコード
					Dim iIndexOffer As Integer = Me.C1FGridFolder.Rows.Count
					Me.C1FGridFolder.Rows.Count = iIndexOffer + 1
					Me.C1FGridFolder(iIndexOffer, "No") = iIndexOffer
					Me.C1FGridFolder(iIndexOffer, "フォルダ名") = strFolderName
					Me.C1FGridFolder(iIndexOffer, "ファイル数") = 1
					'==================================================
					'提供データ側に存在したらチェックを入れる(提供データなしの場合スルー)
					'==================================================
					If blnOfferCSV Then

						Dim iHit As Integer = Me.C1FGridOffer.FindRow(strFolderName, 1, 1, False)
						If iHit = -1 Then
							'ヒットしなかった
							WriteLstResult(Me.lstResult, "提供データに存在しないフォルダを検出しました", ResultMark.WarningMark)
							Me.C1FGridFolder(iIndexOffer, "ステータス") = IIf(IsNull(Me.C1FGridFolder(iIndexOffer, "ステータス")), "提供データに存在しない", Me.C1FGridFolder(iIndexOffer, "ステータス") & "、提供データに存在しない")
						Else
							'ヒットした
							Me.C1FGridOffer(iHit, "使用済") = True
						End If

					End If
					'フォルダ単位の連番をリセット
					iFolderSerial = Me.numSerialFrom.Value
				End If
				strBeforeFolder = strFolderName

				'画像情報を書き込む
				Dim info As CodecsImageInfo = codecs.GetInformation(strFile, True)

				Dim iIndex As Integer = Me.C1FGridResult.Rows.Count
				Me.C1FGridResult.Rows.Count = iIndex + 1
				Me.C1FGridResult.Select(iIndex, 0)  'レコードを作成したらすぐフォーカス移動
				Me.C1FGridResult(iIndex, "No") = iIndex
				Me.C1FGridResult(iIndex, "判定") = ""
				Me.C1FGridResult(iIndex, "フルパス") = strFile
				Me.C1FGridResult(iIndex, "親フォルダ") = strFolderName
				Me.C1FGridResult(iIndex, "ファイル名") = System.IO.Path.GetFileName(strFile)
				'ファイルサイズの取得
				Dim fi As New System.IO.FileInfo(strFile)
				Me.C1FGridResult(iIndex, "ファイルサイズ") = fi.Length
				'==================================================
				'JPEGのサイズ指定チェック
				'==================================================
				If System.IO.Path.GetExtension(strFile) = ".jpg" Then
					If Me.numJpegSizeFrom.Value > fi.Length Or Me.numJpegSizeTo.Value < fi.Length Then
						'FromToの範囲内でなかった
						WriteLstResult(Me.lstResult, "JPEGファイルサイズエラー：" & System.IO.Path.GetFileName(strFile), ResultMark.WarningMark)
						Me.C1FGridResult(iIndex, "ステータス") = IIf(IsNull(Me.C1FGridResult(iIndex, "ステータス")), "JPEGサイズエラー", Me.C1FGridResult(iIndex, "ステータス") & "、JPEGサイズエラー")
						WriteJudge(iIndex, False)
					Else
						'範囲内だった
						WriteJudge(iIndex, True)
					End If

				End If

				'カメラ情報
				Dim strMake As String = ""
				Dim strModel As String = ""
				If GetComments(strFile, strMake, strModel) Then
					Me.C1FGridResult(iIndex, "カメラ") = strModel
				Else
					Me.C1FGridResult(iIndex, "カメラ") = ""
				End If
				'==================================================
				'カメラ一覧でチェックの入ったカメラかどうかチェック
				'==================================================
				Dim blnCameraGood As Boolean = False
				For Each strCamera As String In Me.checkedList.CheckedItems
					If strModel.IndexOf(strCamera) >= 0 Then
						'見つかった
						blnCameraGood = True
					End If
				Next
				If Not blnCameraGood Then
					'見つからなかった
					WriteLstResult(Me.lstResult, "指定されたカメラを使用していません：" & System.IO.Path.GetFileName(strFile), ResultMark.WarningMark)
					Me.C1FGridResult(iIndex, "ステータス") = IIf(IsNull(Me.C1FGridResult(iIndex, "ステータス")), "使用カメラエラー", Me.C1FGridResult(iIndex, "ステータス") & "、使用カメラエラー")
					WriteJudge(iIndex, False)
				Else
					WriteJudge(iIndex, True)
				End If

				Me.C1FGridResult(iIndex, "高さ") = info.Height
				Me.C1FGridResult(iIndex, "幅") = info.Width
				'==================================================
				'カメラに対応した画角が採用されているかチェック
				'カメラが存在しなかったらチェックを行わない
				'==================================================
				Dim iCameraIndex As Integer = Me.C1FGridCamera.FindRow(strModel, 1, 1, False)
				If iCameraIndex >= 0 Then
					'カメラがヒットしたので高さ幅チェックを行う
					'高さ
					If Me.C1FGridCamera(iCameraIndex, "長辺") = info.Height Or
						Me.C1FGridCamera(iCameraIndex, "短辺") = info.Height Then
						WriteJudge(iIndex, True)
					Else
						WriteLstResult(Me.lstResult, "高さが不正です：" & System.IO.Path.GetFileName(strFile), ResultMark.WarningMark)
						Me.C1FGridResult(iIndex, "ステータス") = IIf(IsNull(Me.C1FGridResult(iIndex, "ステータス")), "高さエラー", Me.C1FGridResult(iIndex, "ステータス") & "、高さエラー")
						WriteJudge(iIndex, False)
					End If
					'幅
					If Me.C1FGridCamera(iCameraIndex, "長辺") = info.Width Or
						Me.C1FGridCamera(iCameraIndex, "短辺") = info.Width Then
						WriteJudge(iIndex, True)
					Else
						WriteLstResult(Me.lstResult, "幅が不正です：" & System.IO.Path.GetFileName(strFile), ResultMark.WarningMark)
						Me.C1FGridResult(iIndex, "ステータス") = IIf(IsNull(Me.C1FGridResult(iIndex, "ステータス")), "幅エラー", Me.C1FGridResult(iIndex, "ステータス") & "、幅エラー")
						WriteJudge(iIndex, False)
					End If

				End If

				Me.C1FGridResult(iIndex, "解像度") = info.XResolution
				Me.C1FGridResult(iIndex, "色空間") = GetColorSpace(strFile)
				'==================================================
				'正規の色空間を使用しているかチェック
				'==================================================
				Select Case Me.C1FGridResult(iIndex, "色空間")
					Case "AdobeRGB"
						If System.IO.Path.GetExtension(strFile).ToLower = ".tif" Then
							WriteJudge(iIndex, True)
						Else
							WriteLstResult(lstResult, "想定と違う色空間を使用しています：" & System.IO.Path.GetFileName(strFile), ResultMark.WarningMark)
							Me.C1FGridResult(iIndex, "ステータス") = IIf(IsNull(Me.C1FGridResult(iIndex, "ステータス")), "色空間エラー", Me.C1FGridResult(iIndex, "ステータス") & "、色空間エラー")
							WriteJudge(iIndex, False)
						End If
					Case "sRGB"
						If System.IO.Path.GetExtension(strFile).ToLower = ".jpg" Then
							WriteJudge(iIndex, True)
						Else
							WriteLstResult(lstResult, "想定と違う色空間を使用しています：" & System.IO.Path.GetFileName(strFile), ResultMark.WarningMark)
							Me.C1FGridResult(iIndex, "ステータス") = IIf(IsNull(Me.C1FGridResult(iIndex, "ステータス")), "色空間エラー", Me.C1FGridResult(iIndex, "ステータス") & "、色空間エラー")
							WriteJudge(iIndex, False)
						End If
					Case Else
						WriteLstResult(Me.lstResult, "色空間が不正です", ResultMark.WarningMark)
						Me.C1FGridResult(iIndex, "ステータス") = IIf(IsNull(Me.C1FGridResult(iIndex, "ステータス")), "色空間エラー", Me.C1FGridResult(iIndex, "ステータス") & "、色空間エラー")
						WriteJudge(iIndex, False)
				End Select
				'==================================================
				'ファイル名の末尾が必ず00000であるかどうか確認する
				'==================================================
				Dim strSerial As String = Strings.Right(System.IO.Path.GetFileNameWithoutExtension(strFile), Me.numSerialDigit.Value)
				Dim strZero As String = ""
				'ファイル連番チェック時のみ
				If Me.chkFileSerial.Checked Then
					'桁数分だけ0を追加して文字列を作成する
					For i As Integer = 1 To Me.numSerialDigit.Value
						strZero &= "0"
					Next
					If strSerial = iFolderSerial.ToString(strZero) Then
						WriteJudge(iIndex, True)
					Else
						'相違していたらエラー
						WriteLstResult(Me.lstResult, "ファイル連番相違を検出しました：" & System.IO.Path.GetFileName(strFile), ResultMark.WarningMark)
						Me.C1FGridResult(iIndex, "ステータス") = IIf(IsNull(Me.C1FGridResult(iIndex, "ステータス")), "ファイル連番相違", Me.C1FGridResult(iIndex, "ステータス") & "、ファイル連番相違")
						WriteJudge(iIndex, False)
					End If
				End If

			Catch ex As Exception

				WriteLstResult(Me.lstResult, "ファイル情報取得失敗：" & strFile)

			End Try

		Next

		Dim strLogFile As String = Me.txtOutFolder.Text & "\" & strDateNow & "_進捗状況.log"
		Dim strImageAllFile As String = Me.txtOutFolder.Text & "\" & strDateNow & "_イメージ情報(全体).csv"
		Dim strImageNoGoodFile As String = Me.txtOutFolder.Text & "\" & strDateNow & "_イメージ情報(エラー).csv"
		Dim strFolderFile As String = Me.txtOutFolder.Text & "\" & strDateNow & "_フォルダ情報.csv"
		Dim strUseOfferFile As String = Me.txtOutFolder.Text & "\" & strDateNow & "_提供データ使用状況.csv"
		WriteLstResult(Me.lstResult, "各種ログ出力開始")
		OutputCSVFile(Me.C1FGridResult, strImageAllFile)
		OutputCSVFile(Me.C1FGridFolder, strFolderFile)
		OutputCSVFile(Me.C1FGridOffer, strUseOfferFile)
		OutputCSVFileNoGood(Me.C1FGridResult, strImageNoGoodFile)
		WriteLstResult(Me.lstResult, "各種ログ出力終了")

		WriteLstResult(Me.lstResult, "イメージ情報取得・チェック終了")
		OutputImportLog(Me.lstResult, strLogFile)

		MessageBox.Show("処理が終了しました", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information)
		EnableControls(True)

	End Sub

	''' <summary>
	''' キャンセルボタン押下時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
		_cancel = True
	End Sub

	''' <summary>
	''' カラープロファイルテスト用
	''' </summary>
	''' <param name="target"></param>
	''' <returns></returns>
	Private Function ICCCheck(ByVal target As ImageMagick.ColorProfile) As Boolean

		'ICCファイルの読み込み
		Dim fs As New System.IO.FileStream(Application.StartupPath & "\sRGB.icm", IO.FileMode.Open, IO.FileAccess.Read)
		'バイト型配列に読み込む
		Dim bs(fs.Length - 1) As Byte
		fs.Read(bs, 0, bs.Length)
		fs.Close()
		'バイト型配列の比較
		Dim targetbyte As Byte() = target.ToByteArray()
		Dim fsw As New System.IO.FileStream(Me.txtOutFolder.Text & "\test.icc", IO.FileMode.Create, IO.FileAccess.Write)
		fsw.Write(targetbyte, 0, targetbyte.Length)
		fsw.Close()
		Dim isEqual As Boolean = True
		If Object.ReferenceEquals(targetbyte, bs) Then
			'同一のインスタンスのときは、同じとする
			isEqual = True
		ElseIf targetbyte Is Nothing OrElse bs Is Nothing OrElse targetbyte.Length <> bs.Length Then
			'どちらかがNULLか、要素数が異なるときは、同じではない
			isEqual = False
		Else
			'１つ１つの要素が等しいかを調べる
			For i As Integer = 0 To targetbyte.Length - 1
				'targetbyteの要素のEqualsメソッドで、bsの要素と等しいか調べる
				If Not targetbyte(i).Equals(bs(i)) Then
					'１つでも等しくない要素があれば、同じではない
					isEqual = False
					Exit For
				End If
			Next
		End If
		MessageBox.Show(isEqual)
		'If System.Linq.Enumerable.SequenceEqual(targetbyte, bs) Then
		'	'sRGB
		'	MessageBox.Show("sRGB")
		'Else
		'	MessageBox.Show("AdobeRGB")
		'End If

		Return isEqual

	End Function

	''' <summary>
	''' ファイル連番チェック状態変更時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub chkFileSerial_CheckedChanged(sender As Object, e As EventArgs) Handles chkFileSerial.CheckedChanged

		Me.numSerialDigit.Enabled = Me.chkFileSerial.Checked
		Me.numSerialFrom.Enabled = Me.chkFileSerial.Checked

	End Sub

#End Region

End Class