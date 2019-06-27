Imports System.Data.SqlClient

Public Class SQLProcess

#Region "パブリック宣言"

    Dim con As SqlConnection
    Dim cmd As SqlCommand
    Dim dr As SqlDataReader = Nothing

#End Region

#Region "インスタンス"

    ''' <summary>
    ''' コンストラクタ
    ''' </summary>
    ''' <remarks></remarks>
    <System.Diagnostics.DebuggerStepThrough()> _
    Public Sub New()

        'SQLServer接続確認
        Initialize()

    End Sub

    ''' <summary>
    ''' デストラクタ
    ''' </summary>
    ''' <remarks></remarks>
    <System.Diagnostics.DebuggerStepThrough()> _
    Public Sub Close()

        If Not cmd Is Nothing Then
            cmd.Dispose()
        End If
        If Not dr Is Nothing Then
            dr.Close()
        End If
        con.Close()

    End Sub

#End Region

#Region "プライベートメソッド"

    ''' <summary>
    ''' コネクション確立
    ''' </summary>
    ''' <remarks></remarks>
    <System.Diagnostics.DebuggerStepThrough()> _
    Public  Sub Initialize()

        'Dim settings As Settings = settings.GetInstance
        XmlSettings.LoadFromXmlFile()

        Try
            con = New SqlConnection
            '接続文字列の設定
            'con.ConnectionString = _
            '    "Data Source=" & settings.DataSource & ";" & _
            '    "Initial Catalog=" & settings.InitialCatalog & ";" & _
            '    "Persist Security Info=True;" & _
            '    "User ID=" & settings.UserID & ";" & _
            '    "Password=" & settings.Password

            'mysettingsから取得
            con.ConnectionString =
                "Data Source=" & My.Settings.DataSource & ";" &
                "Initial Catalog=" & My.Settings.DataBase & ";" &
                "Persist Security Info=True;" &
                "User ID=" & My.Settings.UserID & ";" &
                "Password=" & My.Settings.PW

            ''Windows認証
            'con.ConnectionString = _
            '    "Data Source = " & settings.DataSource & ";" & _
            '    "Initial Catalog = " & settings.InitialCatalog & ";" & _
            '    "Integrated Security = SSPI"

            'データベースを開く
            con.Open()

        Catch ex As Exception

            Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message)
            MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

#End Region

#Region "パブリックメソッド"

    ''' <summary>
    ''' SELECT文発行用関数
    ''' </summary>
    ''' <param name="strSQL">SELECT文</param>
    ''' <returns>データリーダー型オブジェクト</returns>
    ''' <remarks></remarks>
    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function DB_SELECT_READER(ByVal strSQL As String) As SqlClient.SqlDataReader

        Try

            cmd = New SqlClient.SqlCommand(strSQL, con)
            cmd.CommandTimeout = 600
            dr = cmd.ExecuteReader

            Return dr

        Catch ex As Exception

            Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message)
            MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & vbNewLine & strSQL, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' INSERT、DELETE、UPDATE文発行用関数
    ''' </summary>
    ''' <param name="strSQL">SQL文</param>
    ''' <remarks>トランザクションを作成し、ロールバックできるようにしている</remarks>
    <System.Diagnostics.DebuggerStepThrough()> _
    Public Sub DB_UPDATE(ByVal strSQL As String)

        Dim sqlTran As SqlTransaction   'トランザクション

        sqlTran = con.BeginTransaction()

        cmd = New SqlCommand(strSQL, con)
        cmd.Transaction = sqlTran

        Try

            cmd.ExecuteNonQuery()
            cmd.CommandTimeout = 600
            sqlTran.Commit()    'コミット

        Catch ex As Exception

            sqlTran.Rollback()  'ロールバック
            Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message)
            MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & vbNewLine & strSQL, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    ''' <summary>
    ''' DATASET取得用関数
    ''' </summary>
    ''' <param name="strSQL"></param>
    ''' <param name="srcTable"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function DB_SELECT_DATASET(ByVal strSQL As String, ByVal srcTable As String) As DataSet

        Try

            Dim da As SqlDataAdapter = New SqlDataAdapter(strSQL, con)
            Dim ds As DataSet = New DataSet()
            da.Fill(ds, srcTable)

            Return ds

        Catch ex As Exception

            Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message)
            MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & vbNewLine & strSQL, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' SQL文の結果より単一の値を取得
    ''' </summary>
    ''' <param name="strSQL"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function DB_EXECUTE_SCALAR(ByVal strSQL As String) As Object

        Try

            cmd = New SqlClient.SqlCommand(strSQL, con)

            Return cmd.ExecuteScalar()

        Catch ex As Exception

            Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message)
            MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & vbNewLine & strSQL, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' DATATABLE取得用関数
    ''' </summary>
    ''' <param name="strSQL"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function DB_SELECT_DATATABLE(ByVal strSQL As String) As DataTable

        Try

            Dim da As SqlDataAdapter = New SqlDataAdapter(strSQL, con)
            Dim dt As New DataTable

            da.Fill(dt)

            Return dt

        Catch ex As Exception

            Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message)
            MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & vbNewLine & strSQL, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Return Nothing

        End Try

    End Function

#End Region

End Class
