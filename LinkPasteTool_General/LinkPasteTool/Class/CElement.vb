
''' <summary>
''' コンボボックスに表示用mの次列と内部IDを保持させるクラス
''' </summary>
<System.Diagnostics.DebuggerStepThrough>
Public Class CElement

    Private m_ID As String '内部ID
    Private m_Name As String    '表示用文字列

    ''' <summary>
    ''' 表示用文字列はToStringをオーバーライドして取得する
    ''' </summary>
    ''' <returns></returns>
    Public Overrides Function ToString() As String
        Return NAME
    End Function

    ''' <summary>
    ''' 実際の値
    ''' (ValueMemberに設定する文字列と同名にする)
    ''' </summary>
    ''' <returns></returns>
    Public Property ID() As String
        Get
            Return m_ID
        End Get
        Set(value As String)
            m_ID = value
        End Set
    End Property

    ''' <summary>
    ''' 表示名称
    ''' (DisplayMemberに設定する文字列と同名にする
    ''' </summary>
    ''' <returns></returns>
    Public Property NAME() As String
        Get
            Return m_Name
        End Get
        Set(value As String)
            m_Name = value
        End Set
    End Property

End Class
