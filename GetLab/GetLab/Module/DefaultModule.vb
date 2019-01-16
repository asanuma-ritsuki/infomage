Imports System.Text

Module DefaultModule

#Region "NULLチェック用関数"

    ''' <summary>
    ''' NULL判定用関数
    ''' </summary>
    ''' <param name="text">対象文字列</param>
    ''' <returns>TRUE:NULL、FALSE:NULLでない</returns>
    ''' <remarks></remarks>
    <System.Diagnostics.DebuggerStepThrough()> _
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

#End Region

#Region "初期化ファイル文字列型読み書き用関数"

    ' ''' <summary>
    ' ''' iniファイルから文字列を読み込む
    ' ''' </summary>
    ' ''' <param name="AppName">カテゴリ名</param>
    ' ''' <param name="KeyName">キー名</param>
    ' ''' <returns>カテゴリ、キーに合った値</returns>
    ' ''' <remarks></remarks>
    '<System.Diagnostics.DebuggerStepThrough()> _
    Public Function strGetProfile(ByVal AppName As String, ByVal KeyName As String) As String

        Dim ret As Integer
        Dim strBuffer As StringBuilder = New StringBuilder(256)
        Dim strIniFileName As String = My.Application.Info.AssemblyName & ".ini"

        ret = WinAPI.GetPrivateProfileString(AppName, KeyName, "", strBuffer, 256, Application.StartupPath & "\" & strIniFileName)
        Return strBuffer.ToString

    End Function

    ' ''' <summary>
    ' ''' iniファイルに文字列を書き込む
    ' ''' </summary>
    ' ''' <param name="AppName"></param>
    ' ''' <param name="KeyName"></param>
    ' ''' <param name="strWriteString"></param>
    ' ''' <remarks></remarks>
    '<System.Diagnostics.DebuggerStepThrough()> _
    Public Sub strPutProfile(ByVal AppName As String, _
                             ByVal KeyName As String, _
                             ByVal strWriteString As String)

        Dim ret As Integer
        Dim strIniFileName As String = My.Application.Info.AssemblyName & ".ini"

        ret = WinAPI.WritePrivateProfileString(AppName, KeyName, strWriteString, Application.StartupPath & "\" & strIniFileName)

    End Sub

#End Region

#Region "例外処理内容をログファイルに吐き出す"

    <System.Diagnostics.DebuggerStepThrough()> _
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

#End Region

#Region "CSVファイルハンドリング"

    ' ''' <summary>
    ' ''' CSVファイルをC1FlexGrid経由で保存する
    ' ''' </summary>
    ' ''' <param name="C1FGridResult"></param>
    ' ''' <param name="strFileName"></param>
    ' ''' <remarks></remarks>
    '<System.Diagnostics.DebuggerStepThrough()> _
    'Public Sub OutputCSVFile(ByVal C1FGridResult As C1FlexGrid, ByVal strFileName As String)

    '    Try

    '        'SaveFileDialogクラスのインスタンスを作成
    '        Dim sfd As New SaveFileDialog()
    '        'ファイル名の初期値を指定する
    '        sfd.FileName = strFileName
    '        'フォルダの初期値を指定する
    '        'sfd.InitialDirectory = "C:\"
    '        '[ファイルの種類]に表示される選択肢を指定する
    '        sfd.Filter = "CSVファイル(*.csv;*.txt)|*.csv;*.txt|すべてのファイル(*.*)|*.*"
    '        '[ファイルの種類]の初期値をインデックスで指定する
    '        sfd.FilterIndex = 1
    '        'タイトルを設定する
    '        sfd.Title = "CSVファイルの保存"
    '        'ダイアログボックスを閉じる前に現在のディレクトリを復元できるようにする
    '        sfd.RestoreDirectory = True
    '        'すでに存在するファイル名を指定したとき警告する
    '        'デフォルトでTrueなので指定する必要はない
    '        sfd.OverwritePrompt = True

    '        'ダイアログを表示する
    '        If sfd.ShowDialog() = DialogResult.OK Then
    '            'OKボタンがクリックされたら
    '            Dim iRow As Integer = C1FGridResult.Rows.Count
    '            Dim iCurrent As Integer = 0
    '            Dim iCount As Integer = 0
    '            Dim strWriteLine As String = ""

    '            C1FGridResult.SaveGrid(sfd.FileName, FileFormatEnum.TextComma, FileFlags.VisibleOnly, System.Text.Encoding.GetEncoding("Shift-JIS"))

    '            MessageBox.Show(C1FGridResult.Rows.Count - 1 & "件出力しました。", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information)

    '        End If

    '    Catch ex As Exception

    '        Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message)
    '        MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

    '    End Try

    'End Sub

    ''' <summary>
    ''' 配列内のデータをCSVファイルに出力する
    ''' </summary>
    ''' <param name="strItems">CSV出力するための配列</param>
    ''' <param name="strFileName">出力ファイルのフルパス</param>
    ''' <remarks></remarks>
    <System.Diagnostics.DebuggerStepThrough()> _
    Public Sub OutputCSVFileFromDB(ByVal strItems() As String, ByVal strFileName As String)

        Try

            Dim strWriteLine As String = ""

            Using sw As New System.IO.StreamWriter(strFileName, True, System.Text.Encoding.GetEncoding("Shift-JIS"))

                For i As Integer = 0 To strItems.Count - 1

                    If i = 0 Then
                        '先頭要素であったら
                        strWriteLine = """" & strItems(i) & """"
                    Else
                        strWriteLine &= ",""" & strItems(i) & """"
                    End If

                Next

                sw.WriteLine(strWriteLine)

            End Using

        Catch ex As Exception

            Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message)
            MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    ''' <summary>
    ''' ファイルのレコード数をカウントする
    ''' </summary>
    ''' <param name="strFileName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function GetLinesOfTextFile(ByVal strFileName As String) As Integer

        Dim sr As New System.IO.StreamReader(strFileName)
        Dim LineCount As Integer

        While (sr.Peek() >= 0)
            sr.ReadLine()
            LineCount += 1
        End While

        Return LineCount

    End Function

#End Region

#Region "Shift-JISで表現できるか判定"

    ''' <summary>
    ''' Shift-JISで表現できるか判別する
    ''' </summary>
    ''' <param name="text">対象文字列</param>
    ''' <returns>TRUE:表現できる、FALSE:表現できない</returns>
    ''' <remarks></remarks>
    <System.Diagnostics.DebuggerStepThrough()> _
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

#End Region

#Region "リストボックス表示用関数"

    Public Enum ResultMark
        InformationMark
        DoingMark
        WarningMark
        ErrorMark
    End Enum

    ''' <summary>
    ''' リストボックスに実行状況を書き込む
    ''' </summary>
    ''' <param name="lstResult">対象ListBox</param>
    ''' <param name="strLog">文字列</param>
    ''' <param name="ResultMark">結果マーク</param>
    ''' <remarks></remarks>
    <System.Diagnostics.DebuggerStepThrough()> _
    Public Sub WriteLstResult(ByVal lstResult As ListBox, ByVal strLog As String, Optional ByVal ResultMark As ResultMark = DefaultModule.ResultMark.InformationMark)

        Try
            Dim strMark As String = ""
            Application.DoEvents()
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
            lstResult.Items.Add(strMark & Date.Now.ToString("yyyy/MM/dd hh:mm:ss") & vbTab & strLog)
            'リストボックスの最終行を選択
            lstResult.SetSelected(lstResult.Items.Count - 1, True)
            Application.DoEvents()

        Catch ex As Exception

            Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message)
            MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub

#End Region

#Region "コモンダイアログボックス"

    ''' <summary>
    ''' ファイルを開くダイアログボックス(jpg)
    ''' </summary>
    ''' <param name="txtFile"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function FileBrowse(ByVal txtFile As System.Windows.Forms.TextBox, ByVal strFilter As String) As String
        'OpenFileDialogクラスのインスタンスを作成
        Dim ofd As New OpenFileDialog()

        '初めのファイル名を指定する
        '初めに「ファイル名」で表示される文字列を指定する
        If IsNull(txtFile.Text) Then
            ofd.FileName = ""
        Else
            ofd.FileName = System.IO.Path.GetFileName(txtFile.Text)
        End If

        '初めに表示されるフォルダを指定する
        '指定しない(空の文字列)と現在のディレクトリが表示される
        If IsNull(txtFile.Text) Then
            ofd.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
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
    ''' ファイルを開くダイアログボックス(すべてのファイル)
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function FileBrowseCSV() As String
        'OpenFileDialogクラスのインスタンスを作成
        Dim ofd As New OpenFileDialog()

        ofd.FileName = ""

        '初めに表示されるフォルダを指定する
        '指定しない(空の文字列)と現在のディレクトリが表示される
        ofd.InitialDirectory = ""

        '[ファイルの種類]に表示される選択肢を指定する
        '指定しないとすべてのファイルが表示される
        ofd.Filter = "すべてのファイル(*.*)|*.*"
        ofd.FilterIndex = 0
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
            Return ""
        End If

    End Function

    ''' <summary>
    ''' フォルダを開くコモンダイアログボックスを表示する
    ''' </summary>
    ''' <param name="txtFolder"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.Diagnostics.DebuggerStepThrough()> _
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

#End Region

#Region "フォルダ以下のファイルを最下層まで検索または取得する"

    ''' <summary>
    ''' 指定した検索パターンに一致するファイルを最下層まで検索し全て返す
    ''' </summary>
    ''' <param name="strRootPath">検索を開始する最上層のディレクトリへのパス</param>
    ''' <param name="strPattern">パス内のファイル名と対応させる検索文字列</param>
    ''' <returns>検索パターンに一致したすべてのファイルパス</returns>
    ''' <remarks></remarks>
    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function GetFilesMostDeep(ByVal strRootPath As String, ByVal strPattern As String) As String()

        Dim hStringCollection As New System.Collections.Specialized.StringCollection()

        'このディレクトリ内のすべてのファイルを検索する
        For Each strFilePath As String In System.IO.Directory.GetFiles(strRootPath, strPattern)
            hStringCollection.Add(strFilePath)
        Next strFilePath

        'このディレクトリ内のすべてのサブディレクトリを検索する(再帰)
        For Each strDirPath As String In System.IO.Directory.GetDirectories(strRootPath)
            Dim strFilePathes As String() = GetFilesMostDeep(strDirPath, strPattern)

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

#End Region

#Region "ログファイル出力"

    ''' <summary>
    ''' インポートログを出力する
    ''' </summary>
    ''' <param name="lstResult">対象ListBox</param>
    ''' <param name="strOutputFolder">出力フォルダ</param>
    ''' <param name="strSign">ファイル名をわかりやすくするためのサインを指定する</param>
    ''' <remarks>yyyyMMdd_Import_XXの形式で出力する(XXは数字)</remarks>
    <System.Diagnostics.DebuggerStepThrough()> _
    Public Sub OutputImportLog(ByVal lstResult As ListBox, ByVal strOutputFolder As String, ByVal strSign As String)

        Dim strDate As String = Date.Now.ToString("yyyyMMdd")
        Dim strOutputImportLog As String = ""

        For i As Integer = 1 To 99
            'ファイルが存在した場合、ファイルの末尾番号を1ずつインクリメントする
            strOutputImportLog = strOutputFolder & "\" & strDate & strSign & i.ToString("00") & ".log"
            If System.IO.File.Exists(strOutputImportLog) = False Then
                '存在しなかったらそのファイル名を採用
                Dim sw As New System.IO.StreamWriter(strOutputImportLog, False, System.Text.Encoding.GetEncoding("Shift-JIS"))
                'テキストの書き込み
                For j As Integer = 0 To lstResult.Items.Count - 1
                    sw.WriteLine(lstResult.Items(j))
                Next
                sw.Close()
                Exit For
            End If
        Next

        'WriteLstResult(lstResult, "ログ保存：" & strOutputImportLog, ResultMark.InformationMark)

    End Sub
    ''' <summary>
    ''' エラーログを出力する
    ''' </summary>
    ''' <param name="lstResult">対象ListBox</param>
    ''' <param name="Array">対象配列</param>
    ''' <param name="strOutputFolder">出力フォルダ</param>
    ''' <param name="strSign">ファイル名をわかりやすくするためのサインを指定する</param>
    ''' <remarks>yyyyMMdd_Import_XXの形式で出力する(XXは数字)</remarks>
    <System.Diagnostics.DebuggerStepThrough()> _
    Public Sub OutputErrorLog(ByVal lstResult As ListBox, ByVal Array As ArrayList, ByVal strOutputFolder As String, ByVal strSign As String, Optional ByVal strSign2 As String = "")

        Dim strDate As String = Date.Now.ToString("yyyyMMdd")
        Dim strOutputImportLog As String = ""

        For i As Integer = 1 To 99
            'ファイルが存在した場合、ファイルの末尾番号を1ずつインクリメントする
            strOutputImportLog = strOutputFolder & "\" & strDate & strSign & i.ToString("00") & strSign2 & ".log"
            If System.IO.File.Exists(strOutputImportLog) = False Then
                '存在しなかったらそのファイル名を採用
                Dim sw As New System.IO.StreamWriter(strOutputImportLog, False, System.Text.Encoding.GetEncoding("Shift-JIS"))
                'テキストの書き込み
                For Each j As String In Array
                    sw.WriteLine(j)
                Next
                sw.Close()
                Exit For
            End If
        Next

        'WriteLstResult(lstResult, "ログ保存：" & strOutputImportLog, ResultMark.InformationMark)

    End Sub

    ''' <summary>
    ''' 全体的なログを出力する
    ''' </summary>
    ''' <param name="strWriteLine">書き込む文字列</param>
    ''' <param name="strFileName">書き込むファイル</param>
    ''' <remarks></remarks>
    <System.Diagnostics.DebuggerStepThrough()> _
    Public Sub OutputWholeLog(ByVal strWriteLine As String, ByVal strFileName As String)

        Using sw As New System.IO.StreamWriter(strFileName, True, System.Text.Encoding.GetEncoding("Shift-JIS"))

            sw.WriteLine(strWriteLine)

        End Using

    End Sub

#End Region

#Region "小数点部切捨て用関数"

    ''' <summary>
    ''' 切捨て
    ''' </summary>
    ''' <param name="value">対象の数値</param>
    ''' <param name="position">切捨て位置</param>
    ''' <returns>切り捨てられた数値</returns>
    ''' <remarks></remarks>
    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function Truncate(ByVal value As Decimal, ByVal position As Integer) As Decimal

        Dim result As Decimal

        result = Math.Truncate((value * Math.Pow(10, position))) / Math.Pow(10, position)

        Return result

    End Function

#End Region

#Region "コントロールの使用可否を切り替える"

    ''' <summary>
    ''' コントロールの使用可否を切り替える
    ''' </summary>
    ''' <param name="frmForm">対象フォーム</param>
    ''' <param name="ControlEnabled">True：使用可能、False：使用不可</param>
    ''' <remarks></remarks>
    <System.Diagnostics.DebuggerStepThrough()> _
    Public Sub EnableControls(ByVal frmForm As Form, ByVal ControlEnabled As Boolean)

        Try
            For Each oControl As Control In frmForm.Controls
                oControl.Enabled = ControlEnabled
            Next

        Catch ex As Exception

            Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message)
            MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

#End Region

End Module
