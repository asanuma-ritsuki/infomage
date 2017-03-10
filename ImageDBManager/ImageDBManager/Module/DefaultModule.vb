Imports System.Text

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

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message)
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

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message)
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

		Dim strDate As String = Date.Now.ToString("yyyyMMdd")
		Dim strOutputImportLog As String = ""

		For i As Integer = 1 To 99
			'ファイルが存在した場合、ファイルの末尾番号を1ずつインクリメントする
			strOutputImportLog = strOutputFolder & "\" & strDate & strSign & i.ToString("00") & strSign2 & ".log"
			If System.IO.File.Exists(strOutputImportLog) = False Then
				'存在しなかったらそのファイル名を採用
				Dim enc As System.Text.Encoding = New System.Text.UTF8Encoding(False)
				Dim sw As New System.IO.StreamWriter(strOutputImportLog, False, enc)
				'テキストの書き込み
				For j As Integer = 0 To lstResult.Items.Count - 1
					sw.WriteLine(lstResult.Items(j))
				Next
				sw.Close()
				Exit For
			End If
		Next

		WriteLstResult(lstResult, "ログ保存：" & strOutputImportLog, ResultMark.InformationMark)

	End Sub

	''' <summary>
	''' 営業日の日数分日付をずらす
	''' </summary>
	''' <param name="dtDate"></param>
	''' <param name="iDiff"></param>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Function getBusinessDay(ByVal dtDate As Date, ByVal iDiff As Integer) As Date

		Dim dtWorkDate As Date = dtDate

		'iDiffの日数が0になるまで繰り返す
		Do Until iDiff = 0
			If IsHoliday(dtWorkDate) Then
				'祝日だったらdtDateのみ進める
				dtWorkDate = dtWorkDate.AddDays(1)
			Else
				'祝日じゃなかったらiDiffを1マイナスしてdtDateを進める
				iDiff -= 1
				dtWorkDate = dtWorkDate.AddDays(1)
			End If
		Loop

		Return dtWorkDate

	End Function

	''' <summary>
	''' 土日祝日判定
	''' </summary>
	''' <param name="dtDate"></param>
	''' <returns></returns>
	''' <remarks></remarks>
	Private Function IsHoliday(ByVal dtDate As Date) As Boolean

		Dim iWeek As Integer = Weekday(dtDate)
		Dim boolReturn As Boolean = False

		If iWeek = 1 Or iWeek = 7 Then
			boolReturn = True
		Else
			'土曜日、日曜日でない場合M_祝日テーブルを参照して祝日かどうか判定する
			Dim strSQL As String = ""
			strSQL = "SELECT 祝日 FROM M_祝日 "
			strSQL &= "WHERE 祝日 = '" & dtDate.ToString("yyyy/MM/dd") & "'"
			Dim sqlProcess As New SQLProcess
			Dim dr As System.Data.SqlClient.SqlDataReader = sqlProcess.DB_SELECT_READER(strSQL)
			'レコードが存在したら祝日
			If dr.HasRows Then
				boolReturn = True
			Else
				boolReturn = False
			End If
			dr.Close()
			sqlProcess.Close()
		End If

		Return boolReturn

	End Function

End Module
