Imports System
Imports System.IO
Imports System.Globalization

<System.Diagnostics.DebuggerStepThrough()>
Public Class AppContext
	Inherits ApplicationContext

	Private Shared instance_ As AppContext = New AppContext

	Private Sub New()
		MyBase.New()
	End Sub

	Public Shared Function GetInstance() As AppContext
		Return instance_
	End Function

	Public Sub SetNextContext(ByVal mainForm As Form, Optional ByVal toHide As Boolean = False)

		Dim tempForm As Form = Me.MainForm
		Dim orgCur As Cursor = Cursor.Current
		Cursor.Current = Cursors.WaitCursor

		Me.MainForm = mainForm

		If toHide Then
			Try
				If Not tempForm Is Nothing Then
					tempForm.Hide()
				End If
			Catch ex As Exception

				Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message)
				MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

			End Try
		Else
			Try

				tempForm.Close()

			Catch ex As Exception

				Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message)
				MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

			End Try
		End If

		Me.MainForm.Show()
		tempForm = Nothing
		Cursor.Current = orgCur

	End Sub
End Class

''' <summary>
''' メインルーチン
''' </summary>
Public Class clsWinApp

	Private Shared MyMutex As System.Threading.Mutex

	<STAThread()> Public Shared Sub Main()
		'ビジュアルスタイルを有効にする
		Application.EnableVisualStyles()

		Initialize()

	End Sub

	''' <summary>
	''' 例外ハンドラ
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Public Shared Sub OnThreadException(ByVal sender As Object, ByVal e As Threading.ThreadExceptionEventArgs)

		CatchException(e.Exception)
		Application.Exit()

	End Sub

	''' <summary>
	''' 意図的にキャッチしない例外を全て処理する
	''' </summary>
	''' <param name="ex"></param>
	Public Shared Sub CatchException(ByVal ex As Exception)

		Dim message As String
		XmlSettings.LoadFromXmlFile()

		message = "システムエラーが発生しました" & vbNewLine & vbNewLine & "Exception=" & ex.GetType.Name & vbNewLine & "Message=" & ex.Message
		MessageBox.Show(message, XmlSettings.Instance.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Error)

	End Sub

	Private Shared Sub Initialize()

		XmlSettings.LoadFromXmlFile()

		MyMutex = New System.Threading.Mutex(False, XmlSettings.Instance.ApplicationName)

		If MyMutex.WaitOne(0, False) = False Then

			MessageBox.Show("多重起動はできません", XmlSettings.Instance.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Error)
			Exit Sub

		End If

		Dim context As AppContext = AppContext.GetInstance
		context.MainForm = New frmMain
		Application.Run(context)

	End Sub

End Class
