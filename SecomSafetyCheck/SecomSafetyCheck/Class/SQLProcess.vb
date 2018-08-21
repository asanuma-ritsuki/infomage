Imports System.Data.OleDb
Imports Microsoft.VisualBasic.ControlChars

<System.Diagnostics.DebuggerStepThrough()>
Public Class SQLProcess

#Region "パブリック宣言"

	Dim con As OleDbConnection
	Dim cmd As OleDbCommand
	Dim dr As OleDbDataReader = Nothing

#End Region

#Region "インスタンス"

	''' <summary>
	''' コンストラクタ
	''' </summary>
	''' <param name="strAccessFile"></param>
	Public Sub New(ByVal strAccessFile As String)
		'Access接続確認
		Initialize(strAccessFile)

	End Sub

	''' <summary>
	''' デストラクタ
	''' </summary>
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
	''' Accessデータベースの接続
	''' </summary>
	''' <param name="strAccessFile"></param>
	Private Sub Initialize(ByVal strAccessFile As String)

		Try
			con = New OleDbConnection
			'接続文字列の設定
			'con.ConnectionString =
			'	"Provider=Microsoft.Jet.OLEDB.4.0;" &
			'	"Data Source=" & Quote & strAccessFile & Quote & ";"
			con.ConnectionString =
				"Provider=Microsoft.Jet.OLEDB.4.0;" &
				"Data Source=" & Quote & strAccessFile & Quote & ";"

			con.Open()

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & ex.StackTrace)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		End Try

	End Sub

#End Region

#Region "パブリックメソッド"

	''' <summary>
	''' UPDATE文
	''' </summary>
	''' <param name="strSQL"></param>
	Public Sub DB_UPDATE(ByVal strSQL As String)

		Dim sqlTran As OleDbTransaction
		sqlTran = con.BeginTransaction()

		cmd = New OleDbCommand(strSQL, con)
		cmd.CommandTimeout = 600
		cmd.Transaction = sqlTran

		Try
			cmd.ExecuteNonQuery()
			sqlTran.Commit()    'コミット

		Catch ex As Exception

			sqlTran.Rollback()  'ロールバック
			Dim strExceptionMessage As String = "発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & "例外タイプ：" & ex.GetType.Name & vbNewLine & "例外内容：" & ex.Message
			strExceptionMessage &= vbNewLine & "SQL文：" & strSQL
			Call OutputLogFile(strExceptionMessage)
			MessageBox.Show(strExceptionMessage, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

			End

		End Try

	End Sub

	''' <summary>
	''' SQL文の結果より単一の値を取得
	''' </summary>
	''' <param name="strSQL"></param>
	''' <returns></returns>
	Public Function DB_EXECUTE_SCALAR(ByVal strSQL As String) As Object

		Try
			cmd = New OleDbCommand(strSQL, con)
			Return cmd.ExecuteScalar()

		Catch ex As Exception

			Dim strExceptionMessage As String = "発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & "例外タイプ：" & ex.GetType.Name & vbNewLine & "例外内容：" & ex.Message
			strExceptionMessage &= vbNewLine & "SQL文：" & strSQL
			Call OutputLogFile(strExceptionMessage)
			MessageBox.Show(strExceptionMessage, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

			Return Nothing

		End Try

	End Function

	''' <summary>
	''' DATATABLE取得用関数
	''' </summary>
	''' <param name="strSQL"></param>
	''' <returns></returns>
	Public Function DB_SELECT_DATATABLE(ByVal strSQL As String) As DataTable

		Try
			Dim da As OleDbDataAdapter = New OleDbDataAdapter(strSQL, con)
			Dim dt As New DataTable

			da.Fill(dt)

			Return dt

		Catch ex As Exception

			Dim strExceptionMessage As String = "発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & "例外タイプ：" & ex.GetType.Name & vbNewLine & "例外内容：" & ex.Message
			strExceptionMessage &= vbNewLine & "SQL文：" & strSQL
			Call OutputLogFile(strExceptionMessage)
			MessageBox.Show(strExceptionMessage, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

			Return Nothing

		End Try

	End Function

#End Region

End Class
