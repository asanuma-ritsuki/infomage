Imports System.Text
Imports C1.Win.C1FlexGrid
Imports C1.C1Zip
Imports Microsoft.WindowsAPICodePack

<System.Diagnostics.DebuggerStepThrough()>
Module DefaultModule

	''' <summary>
	''' リストボックス用マーク列挙体
	''' </summary>
	Public Enum ResultMark
		InformationMark
		DoingMark
		WarningMark
		ErrorMark
	End Enum

	''' <summary>
	''' リストボックスに結果マーク込みで文字列を書き込む
	''' </summary>
	''' <param name="lstResult"></param>
	''' <param name="strLog"></param>
	''' <param name="ResultMark"></param>
	Public Sub WriteLstResult(ByVal lstResult As ListBox, ByVal strLog As String, Optional ByVal ResultMark As ResultMark = ResultMark.InformationMark)

		Try

			Dim strMark As String = ""

			Select Case ResultMark
				Case ResultMark.InformationMark
					strMark = "○"
				Case ResultMark.DoingMark
					strMark = "→"
				Case ResultMark.WarningMark
					strMark = "△"
				Case ResultMark.ErrorMark
					strMark = "×"
			End Select

			'時間と文字列をリストボックスに表示
			lstResult.Items.Add(strMark & Date.Now.ToString("yyyy/MM/dd HH:mm:ss") & vbTab & strLog)
			'リストボックスの最終行を選択
			lstResult.SetSelected(lstResult.Items.Count - 1, True)
			Application.DoEvents()

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & ex.StackTrace)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		End Try

	End Sub

	''' <summary>
	''' NULL判定
	''' </summary>
	''' <param name="text"></param>
	''' <returns></returns>
	Public Function IsNull(ByVal text As String) As Boolean
		'Nothing判定
		If IsNothing(text) Then
			Return True
		End If
		'空文字判定
		If text Is String.Empty Then
			Return True
		End If
		'""文字判定
		If text.Trim = "" Then
			Return True
		End If

		'何も引っかからなかったら
		Return False

	End Function

	''' <summary>
	''' 例外処理内容をログファイルに書き込む
	''' </summary>
	''' <param name="strExceptionMessage"></param>
	Public Sub OutputLogFile(ByVal strExceptionMessage As String)

		Dim strLogFile As String = Application.StartupPath & "\ExceptionLog\Exception.log"
		Dim strLogFolder As String = System.IO.Path.GetDirectoryName(strLogFile)
		Dim sw As System.IO.StreamWriter

		If Not System.IO.Directory.Exists(strLogFolder) Then
			System.IO.Directory.CreateDirectory(strLogFolder)
		End If

		sw = New System.IO.StreamWriter(strLogFile, True, System.Text.Encoding.GetEncoding("Shift-JIS"))

		sw.WriteLine("[ " & Date.Now & " ]")
		sw.WriteLine(strExceptionMessage)
		sw.Close()

	End Sub

	''' <summary>
	''' ファイルのレコード数をカウントする
	''' </summary>
	''' <param name="strFileName"></param>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Function GetLinesOfTextFile(ByVal strFileName As String) As Integer

		Dim sr As New System.IO.StreamReader(strFileName)
		Dim LineCount As Integer

		While (sr.Peek() >= 0)
			sr.ReadLine()
			LineCount += 1
		End While

		Return LineCount

	End Function

	''' <summary>
	''' Shift-JISで表現できるか判別する
	''' </summary>
	''' <param name="text">対象文字列</param>
	''' <returns>TRUE:表現できる、FALSE:表現できない</returns>
	''' <remarks></remarks>
	Public Function IsShiftJISOnlyText(ByVal text As String) As Boolean

		Dim encoderFallback As New EncoderExceptionFallback
		Dim decoderFallback As New DecoderExceptionFallback
		Dim sjis As Encoding = Encoding.GetEncoding("Shift_JIS", encoderFallback, decoderFallback)

		Try

			Dim bytes As Byte() = sjis.GetBytes(text)

		Catch fbex As EncoderFallbackException
			'Shift-JISで表現できなかった場合、ここに飛ぶ
			Return False

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & ex.StackTrace)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Return False

		End Try

		Return True

	End Function

	''' <summary>
	''' ファイルを開くダイアログボックス
	''' </summary>
	''' <param name="txtFile"></param>
	''' <param name="strFilter"></param>
	''' <returns>フィルタの記述例：JPEGイメージ(*.jpg)|*.jpg|すべてのファイル(*.*)|*.*</returns>
	Public Function FileBrowse(ByVal txtFile As System.Windows.Forms.TextBox, ByVal strFilter As String) As String

		Dim ofd As New OpenFileDialog()
		'はじめのファイル名を指定する
		'はじめに「ファイル名」で表示される文字列を指定する
		If IsNull(txtFile.Text) Then
			ofd.FileName = ""
		Else
			ofd.FileName = System.IO.Path.GetFileName(txtFile.Text)
		End If

		'はじめに表示されるフォルダを指定する
		If IsNull(txtFile.Text) Then
			ofd.FileName = ""
		Else
			ofd.InitialDirectory = System.IO.Path.GetDirectoryName(txtFile.Text)
		End If

		'[ファイルの種類]に表示される選択肢を指定する
		'指定しないとすべてのファイルが表示される
		ofd.Filter = strFilter
		ofd.FilterIndex = 1
		'タイトルを設定する
		ofd.Title = "ファイルを選択してください"
		'ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする
		ofd.RestoreDirectory = True
		'存在しないファイルの名前が指定されたとき警告を表示する
		'デフォルトでTrue
		ofd.CheckFileExists = True
		'存在しないパスが指定されたとき警告を表示する
		'デフォルトでTrue
		ofd.CheckPathExists = True

		'ダイアログを表示する
		If ofd.ShowDialog() = DialogResult.OK Then
			'OKボタンがクリックされたとき
			Return ofd.FileName
		Else
			Return txtFile.Text
		End If

	End Function

	''' <summary>
	''' フォルダを開くコモンダイアログボックスを表示する
	''' </summary>
	''' <param name="txtFolder"></param>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Function FolderBrowse(ByVal txtFolder As System.Windows.Forms.TextBox) As String
		'FolderBrowseDialogクラスのインスタンスを作成
		Dim fbd As New FolderBrowserDialog
		'上部に表示する説明テキストを指定する
		fbd.Description = "フォルダを選択してください。"
		'テキストボックスがNULLだった場合、デスクトップをデフォルトに
		'指定されていた場合、そのフォルダをデフォルトに設定する
		If IsNull(txtFolder.Text) Then
			fbd.RootFolder = Environment.SpecialFolder.Desktop
		Else
			fbd.SelectedPath = txtFolder.Text
		End If

		'ダイアログを表示する
		If fbd.ShowDialog() = DialogResult.OK Then
			'選択されたフォルダを表示する
			Return fbd.SelectedPath
		Else
			Return txtFolder.Text
		End If

	End Function

	''' <summary>
	''' フォルダを開くコモンダイアログボックスを表示する(WindowsAPICodePack使用)
	''' </summary>
	''' <param name="strFolder"></param>
	''' <returns></returns>
	Public Function FolderBrowse(ByVal strFolder As String) As String
		Dim ofd As New Dialogs.CommonOpenFileDialog("フォルダ選択")
		'フォルダ選択モードにする
		ofd.IsFolderPicker = True
		'初期フォルダ
		ofd.InitialDirectory = strFolder

		If ofd.ShowDialog() = Dialogs.CommonFileDialogResult.Ok Then
			Return ofd.FileName
		Else
			If IsNull(strFolder) Then
				Return ""
			Else
				Return strFolder
			End If
		End If

	End Function

	''' <summary>
	''' 指定した検索パターンに一致するファイルを最下層まで検索し全て返す
	''' </summary>
	''' <param name="strRootPath">検索を開始する最上層のディレクトリへのパス</param>
	''' <param name="strPatterns">パス内のファイル名と対応させる検索文字列の配列</param>
	''' <returns>検索パターンに一致したすべてのファイルパス</returns>
	''' <remarks></remarks>
	Public Function GetFilesMostDeep(ByVal strRootPath As String, ByVal strPatterns() As String) As String()

		Dim hStringCollection As New System.Collections.Specialized.StringCollection()

		'このディレクトリ内のすべてのファイルを検索する
		For Each strFilePath As String In System.IO.Directory.GetFiles(strRootPath, "*")
			For Each strPattern As String In strPatterns

				If "*" & System.IO.Path.GetExtension(strFilePath) = strPattern Then
					hStringCollection.Add(strFilePath)
				End If
			Next

		Next strFilePath

		'このディレクトリ内のすべてのサブディレクトリを検索する(再帰)
		For Each strDirPath As String In System.IO.Directory.GetDirectories(strRootPath)
			Dim strFilePathes As String() = GetFilesMostDeep(strDirPath, strPatterns)

			'条件に合致したファイルがあった場合は、ArrayListに加える
			If Not strFilePathes Is Nothing Then
				hStringCollection.AddRange(strFilePathes)
			End If
		Next strDirPath

		'StringCollectionを1次元のString配列にして返す
		Dim strReturns As String() = New String(hStringCollection.Count - 1) {}
		hStringCollection.CopyTo(strReturns, 0)

		Return strReturns

	End Function

	''' <summary>
	''' リストボックスに表示されている文字列をログファイルとして保存する
	''' </summary>
	''' <param name="lstResult">対象ListBox</param>
	''' <param name="strOutputFolder">出力フォルダ</param>
	''' <param name="strSign">ファイル名をわかりやすくするためのサインを指定する</param>
	''' <remarks>yyyyMMdd_Import_XXの形式で出力する(XXは数字)</remarks>
	Public Sub OutputImportLog(ByVal lstResult As ListBox, ByVal strOutputFolder As String, ByVal strSign As String, Optional ByVal strSign2 As String = "")

		Dim strDate As String = Date.Now.ToString("yyyyMMdd_HHmmss")
		Dim strOutputImportLog As String = strOutputFolder & "\" & strDate & strSign & strSign2 & ".log"
		Using sw As New System.IO.StreamWriter(strOutputImportLog, False, System.Text.Encoding.GetEncoding("Shift-JIS"))
			'テキストの書き込み
			For j As Integer = 0 To lstResult.Items.Count - 1
				sw.WriteLine(lstResult.Items(j))
			Next

		End Using

		'For i As Integer = 1 To 99
		'	'ファイルが存在した場合、ファイルの末尾番号を1ずつインクリメントする
		'	strOutputImportLog = strOutputFolder & "\" & strDate & strSign & i.ToString("00") & strSign2 & ".log"
		'	If System.IO.File.Exists(strOutputImportLog) = False Then
		'		'存在しなかったらそのファイル名を採用
		'		Dim enc As System.Text.Encoding = New System.Text.UTF8Encoding(False)
		'		Dim sw As New System.IO.StreamWriter(strOutputImportLog, False, enc)
		'		'テキストの書き込み
		'		For j As Integer = 0 To lstResult.Items.Count - 1
		'			sw.WriteLine(lstResult.Items(j))
		'		Next
		'		sw.Close()
		'		Exit For
		'	End If
		'Next

		WriteLstResult(lstResult, "ログ保存：" & strOutputImportLog, ResultMark.InformationMark)

	End Sub

	''' <summary>
	''' リストボックスに表示されている文字列をログファイルとして保存する
	''' </summary>
	''' <param name="lstResult">対象のリストボックス</param>
	''' <param name="strOutputFolder">出力フォルダ</param>
	''' <param name="strSign">出力種別</param>
	''' <param name="strSign2">事業所ID</param>
	''' <param name="strLotID">ロットID</param>
	Public Sub OutputListLog(ByVal lstResult As ListBox, ByVal strOutputFolder As String, ByVal strSign As String, ByVal strSign2 As String, ByVal strLotID As String)

		If Not System.IO.Directory.Exists(strOutputFolder) Then
			My.Computer.FileSystem.CreateDirectory(strOutputFolder)
		End If
		Dim strOutputFile As String = strOutputFolder & "\" & strSign & "_" & strSign2 & "_" & strLotID & ".log"
		Using sw As New System.IO.StreamWriter(strOutputFile, False, System.Text.Encoding.GetEncoding("Shift-JIS"))
			'テキストの書き込み
			For j As Integer = 0 To lstResult.Items.Count - 1
				sw.WriteLine(lstResult.Items(j))
			Next

		End Using

	End Sub

	''' <summary>
	''' 指定CSVファイルにC1FlexGridの内容を保存する
	''' </summary>
	''' <param name="C1FGridResult"></param>
	''' <param name="strFileName"></param>
	''' <remarks></remarks>
	Public Sub OutputCSVFile(ByVal C1FGridResult As C1FlexGrid, ByVal strFileName As String)

		Try

			'SaveFileDialogクラスのインスタンスを作成
			Dim sfd As New SaveFileDialog()
			'ファイル名の初期値を指定する
			sfd.FileName = System.IO.Path.GetFileName(strFileName)
			'フォルダの初期値を指定する
			'sfd.InitialDirectory = "C:\"
			'[ファイルの種類]に表示される選択肢を指定する
			sfd.Filter = "CSVファイル(*.csv;*.txt)|*.csv;*.txt|すべてのファイル(*.*)|*.*"
			'[ファイルの種類]の初期値をインデックスで指定する
			sfd.FilterIndex = 1
			'タイトルを設定する
			sfd.Title = "CSVファイルの保存"
			'ダイアログボックスを閉じる前に現在のディレクトリを復元できるようにする
			sfd.RestoreDirectory = True
			'既に存在するファイル名を指定したとき警告する
			'デフォルトでTrueなので指定する必要はない
			sfd.OverwritePrompt = True

			'ダイアログを表示する
			If sfd.ShowDialog() = DialogResult.OK Then
				'OKボタンがクリックされたとき
				'Dim iRow As Integer = C1FGridResult.Rows.Count
				'Dim iCurrent As Integer = 0
				'Dim iCount As Integer = 0
				'Dim strWriteLine As String = ""
				C1FGridResult.SaveGrid(sfd.FileName, FileFormatEnum.TextTab, FileFlags.IncludeFixedCells + FileFlags.VisibleOnly, System.Text.Encoding.GetEncoding("Shift-JIS"))

				MessageBox.Show(C1FGridResult.Rows.Count - 1 & "件出力しました。", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information)

			End If

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & ex.StackTrace)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		End Try

	End Sub

	''' <summary>
	''' コンボボックスにDATATABLEの値をセットする
	''' </summary>
	''' <param name="cmb">対象コンボボックス</param>
	''' <param name="dt">DATATABLE(カラム0＝ID、カラム1＝NAME)</param>
	''' <param name="IsAll">全て項目を追加するか</param>
	Public Sub SetComboValue(ByVal cmb As ComboBox, ByVal dt As DataTable, Optional ByVal IsAll As Boolean = True)

		Dim elm() As CElement = Nothing
		If IsAll Then
			ReDim Preserve elm(0)
			elm(0) = New CElement
			elm(0).ID = "0"
			elm(0).NAME = "全て"

			For iRow As Integer = 0 To dt.Rows.Count - 1
				ReDim Preserve elm(iRow + 1)
				elm(iRow + 1) = New CElement
				elm(iRow + 1).ID = dt.Rows(iRow)(0)
				elm(iRow + 1).NAME = dt.Rows(iRow)(1)
			Next

		Else
			'「全て」なし
			For iRow As Integer = 0 To dt.Rows.Count - 1
				ReDim Preserve elm(iRow)
				elm(iRow) = New CElement
				elm(iRow).ID = dt.Rows(iRow)(0)
				elm(iRow).NAME = dt.Rows(iRow)(1)
			Next

		End If


		cmb.DisplayMember = "NAME"
		cmb.ValueMember = "ID"
		cmb.DataSource = elm

		cmb.SelectedIndex = -1

	End Sub

	''' <summary>
	''' コントロールの使用可否を切り替える
	''' </summary>
	''' <param name="frmForm">対象フォーム</param>
	''' <param name="ControlEnabled">True：使用可能、False：使用不可</param>
	''' <remarks></remarks>
	Public Sub EnableControls(ByVal frmForm As Form, ByVal ControlEnabled As Boolean)

		Try
			For Each oControl As Control In frmForm.Controls
				oControl.Enabled = ControlEnabled
			Next

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & ex.StackTrace)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		End Try

	End Sub

	''' <summary>
	''' 解凍処理
	''' </summary>
	''' <param name="sourceZIP"></param>
	''' <param name="destFolder"></param>
	''' <param name="strPasswordDate"></param>
	''' <returns></returns>
	Public Function ExtractZIP(ByVal sourceZIP As String, ByVal destFolder As String, ByVal strPasswordDate As String) As Boolean

		XmlSettings.LoadFromXmlFile()
		'固定文字＋日付８桁
		'Jp-Mbp@yyyyMMdd
		Dim strPassword As String = XmlSettings.Instance.ZipPassword & strPasswordDate

		Try
			'C1ZipFileオブジェクトの作成
			Dim zipFile As New C1ZipFile
			zipFile.Open(sourceZIP)
			'すべてのファイルを指定フォルダに解凍する
			zipFile.Password = strPassword
			zipFile.Entries.ExtractFolder(destFolder)

			Return True

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & ex.StackTrace)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Return False

		End Try

	End Function

	''' <summary>
	''' 日付から年度を求める
	''' </summary>
	''' <param name="strDate"></param>
	''' <returns></returns>
	Public Function GetBusinessYear(ByVal strDate As String) As Integer

		Dim iBusinessYear As Integer = Year(DateAdd(DateInterval.Month, -3, Date.Parse(strDate)))
		Return iBusinessYear

	End Function

	''' <summary>
	''' 営業日の日数分日付をずらす
	''' </summary>
	''' <param name="dtDate"></param>
	''' <param name="iDiff"></param>
	''' <returns></returns>
	Public Function getBusinessDay(ByVal dtDate As Date, ByVal iDiff As Integer) As Date

		Dim dtWorkDate As Date = dtDate

		'iDiffの日数が0になるまで繰り返す
		Do Until iDiff = 0
			'土日祝日かどうか評価する前に日付を1日進める
			dtWorkDate = dtWorkDate.AddDays(1)

			If IsHoliday(dtWorkDate) Then
				'祝日だった場合、何もしない

			Else
				'祝日じゃなかった場合、iDiffをマイナスする
				iDiff -= 1
			End If
		Loop

		Return dtWorkDate

	End Function

	''' <summary>
	''' 土日祝日判定
	''' </summary>
	''' <param name="dtDate"></param>
	''' <returns>TRUE：土日祝日、FALSE：平日</returns>
	Public Function IsHoliday(ByVal dtDate As Date) As Boolean

		Dim iWeek As Integer = Weekday(dtDate)
		Dim blnReturn As Boolean = False

		If iWeek = 1 Or iWeek = 7 Then
			blnReturn = True
		Else
			'土曜日、日曜日でない場合、M_祝日テーブルを参照して祝日稼働か判定する
			Dim strSQL As String = ""
			Dim sqlProcess As New SQLProcess

			Try
				strSQL = "SELECT 祝日 FROM M_祝日 "
				strSQL &= "WHERE 祝日 = '" & dtDate.ToString("yyyy/MM/dd") & "'"
				Dim dt As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
				If dt.Rows.Count > 0 Then
					'レコードが存在したら祝日
					blnReturn = True
				Else
					blnReturn = False
				End If

			Catch ex As Exception

				Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & ex.StackTrace)
				MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

			Finally

				sqlProcess.Close()

			End Try

		End If

		Return blnReturn

	End Function

	''' <summary>
	''' 満年齢を求める
	''' </summary>
	''' <param name="dtDate"></param>
	''' <returns></returns>
	Public Function GetAge(ByVal dtBirthDate As DateTime, ByVal dtDate As DateTime) As Integer

		Return ((dtDate.Year * 10000 + dtDate.Month * 100 + dtDate.Day) - (dtBirthDate.Year * 10000 + dtBirthDate.Month * 100 + dtBirthDate.Day)) \ 10000

	End Function

	''' <summary>
	''' 小数点以下を指定された順位まで付与する
	''' NULLの場合は空文字を返す
	''' </summary>
	''' <param name="strValue"></param>
	''' <param name="iPoint"></param>
	''' <returns></returns>
	Public Function PeriodCheck(ByVal strValue As String, ByVal iPoint As Integer) As String

		If IsNull(strValue) Then
			Return ""
		End If

		Select Case iPoint
			Case 1
				'小数点第一位まで
				Return Double.Parse(strValue).ToString("0.0")

			Case 2
				'小数点第二位まで
				Return Double.Parse(strValue).ToString("0.00")

			Case Else

				Return ""
		End Select

	End Function

	''' <summary>
	''' コンピュータにインストールされているプリンタを取得して該当コンボボックスにセットする
	''' </summary>
	''' <param name="cmbComboBox"></param>
	Public Sub SetPrinters(ByVal cmbComboBox As ComboBox)

		cmbComboBox.Items.Clear()
		For Each strPrinter As String In System.Drawing.Printing.PrinterSettings.InstalledPrinters
			cmbComboBox.Items.Add(strPrinter)
		Next

		If cmbComboBox.Items.Count > 0 Then
			cmbComboBox.SelectedIndex = 0
		End If

	End Sub

End Module
