Imports System.IO
Imports System.Text

Public Class CSVParser
    Implements IDisposable

#Region "プロパティ変数"

    Private _sr As StreamReader 'CSVファイルの読み込みストリーム
    Private _state As State = State.None    '現在の読み込み状況
    Private _lineNumber As Integer  'CSVファイルの現在処理中のレコード番号
    Private _delimiter As String    '区切り文字
    Private _trimWhiteSpace As Boolean  'フィールドの前後からスペースを削除するか

#End Region

#Region "コンストラクタ"

    ''' <summary>
    ''' コンストラクタ
    ''' </summary>
    ''' <param name="filename"></param>
    ''' <param name="enc"></param>
    Public Sub New(ByVal filename As String, ByVal enc As Encoding)
        _sr = New StreamReader(filename, enc)
        _state = State.Beginning
        _lineNumber = 0
    End Sub

    ''' <summary>
    ''' ストリームを閉じる
    ''' </summary>
    Public Sub Close()
        _sr.Close()
    End Sub

#End Region

#Region "プロパティ"

    ''' <summary>
    ''' 区切り文字
    ''' </summary>
    ''' <returns></returns>
    Public Property Delimiter() As String
        Get
            Return _delimiter
        End Get
        Set(value As String)
            If value.Length <> 1 Then Throw New ArgumentException("1char only")
            _delimiter = value
        End Set
    End Property

    ''' <summary>
    ''' 現在処理中のCSVデータのレコード番号
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property LineNumber() As Integer
        Get
            Return _lineNumber
        End Get
    End Property

    ''' <summary>
    ''' フィールドを引用符("")で囲み、改行文字、区切り文字を含めることが出来るか
    ''' フィールドを引用符で囲まない場合は、このクラスを使用してはいけない
    ''' </summary>
    ''' <returns></returns>
    Public Property HasFieldsEnclosedInQuotes() As Boolean
        Get
            Return True
        End Get
        Set(value As Boolean)
            If value = False Then Throw New ApplicationException("not support")
        End Set
    End Property

    ''' <summary>
    ''' フィールドの前後からスペースを削除するか
    ''' </summary>
    ''' <returns></returns>
    Public Property TrimWhiteSpace() As Boolean
        Get
            Return _trimWhiteSpace
        End Get
        Set(value As Boolean)
            _trimWhiteSpace = value
        End Set
    End Property

    ''' <summary>
    ''' データの終りか
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property EndOfData() As Boolean
        Get
            Return _sr.EndOfStream
        End Get
    End Property

#End Region

#Region "パブリックメソッド"

    ''' <summary>
    ''' 1行読み込み
    ''' </summary>
    ''' <returns></returns>
    Public Function ReadFields() As String()
        '処理レコード番号を加算
        _lineNumber += 1
        '行データを取得
        Dim rows As List(Of String) = New List(Of String)
        Dim buf As String = ""
        Do While True
            '最初に1行読み込み、2回目の場合は最初のデータに2行目を追加
            buf &= _sr.ReadLine()
            '区切り文字で分割する
            rows = ReadFieldsInternal(buf)
            '区切り文字が閉じていなければ、次の行を追加(ループ)
            '区切り文字が閉じていれば、行読み込み完了
            Select Case _state
                Case State.FindQuote, State.InQuote : buf &= vbNewLine
                Case Else : Exit Do
            End Select
        Loop

        If _trimWhiteSpace Then
            Dim trimRows As List(Of String) = New List(Of String)
            For Each row As String In rows
                '文字列の前後からダブルクオートを削除して空白文字を削除する
                trimRows.Add(row.Trim("""").Trim())
            Next
            Return trimRows.ToArray()
        Else
            Dim trimRows As List(Of String) = New List(Of String)
            For Each row As String In rows
                '文字列の前後からダブルクオートを削除する
                trimRows.Add(row.Trim(""""))
            Next
            Return trimRows.ToArray()
        End If

    End Function

#End Region

#Region "プライベートメソッド"

    Private Function ReadFieldsInternal(ByVal buf As String) As List(Of String)
        '求める列値リスト
        Dim rows As List(Of String) = New List(Of String)
        'ステータスの初期化
        _state = State.Beginning
        '1文字ずつチェックして、列値リストへ追加していく
        Dim row As String = ""
        Dim pos As Integer
        For pos = 0 To buf.Length - 1
            Dim nextChar As String = buf.Substring(pos, 1)
            '読込状況により、列の値を設定する
            Select Case _state
                Case State.Beginning
                    row = ReadForStateBeginning(row, nextChar)
                Case State.WaitInput
                    row = ReadForStateWaitInput(row, nextChar)
                Case State.FindQuote
                    row = ReadForStateFindQuote(row, nextChar)
                Case State.FindQuoteDouble
                    row = ReadForStateFindQuoteDouble(row, nextChar)
                Case State.InQuote
                    row = ReadForStateInQuote(row, nextChar)
                Case State.FindQuoteInQuote
                    row = ReadForStateFindQuoteInQuote(row, nextChar)
            End Select

            '読込み状況により、ループを抜ける
            Select Case _state
                Case State.FindCrLf 'データの終了
                    _state = State.Beginning
                    Exit For
                Case State.FindComma '列の終了
                    Call rows.Add(row)
                    row = ""
                    _state = State.Beginning
                Case State.InvalidChar
                    Throw New ApplicationException("書式が不正です。 LineNumber=" & _lineNumber)
            End Select

        Next

        '引用符の連続を見つけた場合の処理
        If _state = State.FindQuoteDouble Then
            row &= Chr(34)
        End If
        '最後の値を追加する
        Call rows.Add(row)
        '列値リストを返す
        Return rows

    End Function

    ''' <summary>
    ''' 初回入力待ち状態での Read
    ''' "ABC","D""EF","GHI"
    ''' ^
    ''' </summary>
    ''' <param name="row">現在の列の値</param>
    ''' <param name="nextChar">次の1文字</param>
    ''' <returns></returns>
    Private Function ReadForStateBeginning(ByVal row As String, ByVal nextChar As String) As String

        Select Case nextChar
            Case vbCr '改行を見つけた
                _state = State.FindCr
            Case _delimiter '区切り文字を見つけた
                _state = State.FindComma
            Case Chr(34) '引用符を見つけた
                _state = State.FindQuote
            Case Else 'その他の文字
                _state = State.WaitInput
                row &= nextChar
        End Select

        Return row

    End Function

    ''' <summary>
    ''' 入力待ち状態での Read
    ''' ReadForStateBeginning()と同じ、分かりやすくするために記述？
    ''' "ABC","D""EF","GHI"
    ''' ^
    ''' </summary>
    ''' <param name="row">現在の列の値</param>
    ''' <param name="nextChar">次の1文字</param>
    ''' <returns></returns>
    Private Function ReadForStateWaitInput(ByVal row As String, ByVal nextChar As String) As String

        Select Case nextChar
            Case vbCr '改行を見つけた
                _state = State.FindCr
            Case _delimiter '区切り文字を見つけた
                _state = State.FindComma
            Case Chr(34) '引用符を見つけた
                _state = State.FindQuote
            Case Else
                row &= nextChar
        End Select

        Return row

    End Function

    ''' <summary>
    ''' 引用符を発見した状態での Read
    ''' "ABC","D""EF","GHI"
    '''  ^
    ''' </summary>
    ''' <param name="row">現在の列の値</param>
    ''' <param name="nextChar">次の1文字</param>
    ''' <returns></returns>
    Private Function ReadForStateFindQuote(ByVal row As String, ByVal nextChar As String) As String

        Select Case nextChar
            Case Chr(34) '引用符を見つけた(引用符の連続)
                _state = State.FindQuoteDouble
            Case Else
                _state = State.InQuote
                row &= nextChar
        End Select

        Return row

    End Function

    ''' <summary>
    ''' 引用符の連続を発見した状態での Read
    ''' "ABC","D""EF","GHI"
    '''		   ^
    ''' </summary>
    ''' <param name="row">現在の列の値</param>
    ''' <param name="nextChar">次の1文字</param>
    ''' <returns></returns>
    Private Function ReadForStateFindQuoteDouble(ByVal row As String, ByVal nextChar As String) As String

        Select Case nextChar
            Case vbCr
                _state = State.FindCr
                row &= Chr(34)
            Case _delimiter
                _state = State.FindComma
                row &= Chr(34)
            Case Chr(34)
                _state = State.FindQuote
                row &= Chr(34)
            Case Else
                _state = State.WaitInput
                row &= Chr(34) & nextChar
        End Select

        Return row

    End Function

    ''' <summary>
    ''' 引用符の中で入力待ち状態での Read
    ''' </summary>
    ''' <param name="row">現在の列の値</param>
    ''' <param name="nextChar">次の1文字</param>
    ''' <returns></returns>
    Private Function ReadForStateInQuote(ByVal row As String, ByVal nextChar As String) As String

        Select Case nextChar
            Case Chr(34)
                _state = State.FindQuoteInQuote
            Case Else
                row &= nextChar
        End Select

        Return row

    End Function

    ''' <summary>
    ''' 引用符の中で引用符を発見した状態での Read
    ''' "ABC","D""EF","GHI"
    '''	  ^  ^		  ^
    ''' </summary>
    ''' <param name="row">現在の列の値</param>
    ''' <param name="nextChar">次の1文字</param>
    ''' <returns></returns>
    Private Function ReadForStateFindQuoteInQuote(ByVal row As String, ByVal nextChar As String) As String

        Select Case nextChar
            Case vbCr '改行を見つけた
                _state = State.FindCr
            Case _delimiter 'カンマを見つけた
                _state = State.FindComma
            Case Chr(34) '引用符を見つけた
                _state = State.InQuote
                row &= Chr(34)
            Case Else '引用符を閉じた後は、カンマか改行
                _state = State.InvalidChar
        End Select

        Return row

    End Function

    ''' <summary>
    ''' 読込み状態
    ''' </summary>
    Private Enum State
        ''' <summary>読み込み開始前</summary>
        None = 0
        ''' <summary>初期状態の入力待ち</summary>
        Beginning = 1
        ''' <summary>入力待ち</summary>
        WaitInput = 2
        ''' <summary>引用符を発見</summary>
        FindQuote = 3
        ''' <summary>引用符の連続を発見</summary>
        FindQuoteDouble = 4
        ''' <summary>引用符の中で入力待ち</summary>
        InQuote = 5
        ''' <summary>引用符の中で引用符を発見</summary>
        FindQuoteInQuote = 6
        ''' <summary>カンマを発見</summary>
        FindComma = 7
        ''' <summary>Cr を発見</summary>
        FindCr = 8
        ''' <summary>CrLf を発見</summary>
        FindCrLf = 9
        ''' <summary>無効な文字を発見</summary>
        InvalidChar = 255

    End Enum

#End Region

#Region "IDisposable Support"
    Private disposedValue As Boolean ' 重複する呼び出しを検出するには

    ' IDisposable
    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not disposedValue Then
            If disposing Then
                ' TODO: マネージ状態を破棄します (マネージ オブジェクト)。
            End If

            ' TODO: アンマネージ リソース (アンマネージ オブジェクト) を解放し、下の Finalize() をオーバーライドします。
            ' TODO: 大きなフィールドを null に設定します。
        End If
        disposedValue = True
    End Sub

    ' TODO: 上の Dispose(disposing As Boolean) にアンマネージ リソースを解放するコードが含まれる場合にのみ Finalize() をオーバーライドします。
    'Protected Overrides Sub Finalize()
    '    ' このコードを変更しないでください。クリーンアップ コードを上の Dispose(disposing As Boolean) に記述します。
    '    Dispose(False)
    '    MyBase.Finalize()
    'End Sub

    ' このコードは、破棄可能なパターンを正しく実装できるように Visual Basic によって追加されました。
    Public Sub Dispose() Implements IDisposable.Dispose
        _sr.Dispose()
        ' このコードを変更しないでください。クリーンアップ コードを上の Dispose(disposing As Boolean) に記述します。
        Dispose(True)
        ' TODO: 上の Finalize() がオーバーライドされている場合は、次の行のコメントを解除してください。
        ' GC.SuppressFinalize(Me)
    End Sub
#End Region

End Class
