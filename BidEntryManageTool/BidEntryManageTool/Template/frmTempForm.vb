Imports System.Runtime.InteropServices

Public Class frmTempForm

#Region "変数宣言"

	''' <summary>
	''' ステータスバーの表示形式
	''' </summary>
	Public Enum StatusDisplayMode
		None    '表示なし
		TitleOnly   '画面名のみ
		ShowAll '全て表示
	End Enum

	Protected m_Context As AppContext = AppContext.GetInstance
	Private m_BackFormID As String = "frmMainMenu"

#End Region

#Region "WIN32API"

	Protected Overrides Sub WndProc(ByRef m As Message)

		'閉じるボタン使用不可
		Const WM_SYSCOMMAND As Integer = &H112
		Const SC_CLOSE As Integer = &HF060
		'フォームドラッグでウィンドウを移動用
		Const WM_NCHITTEST As Integer = &H84
		Const HTCLIENT As Integer = 1
		Const HTCAPTION As Integer = 2

		'閉じるボタンを無効にする
		If m.Msg = WM_SYSCOMMAND And m.WParam.ToInt32() = SC_CLOSE Then
			Return
		End If

		MyBase.WndProc(m)

		'マウスポインタがクライアント領域にあるか
		If m.Msg = WM_NCHITTEST And m.Result.ToInt32() = HTCLIENT Then
			'マウスがタイトルバーにあるふりをする
			m.Result = New IntPtr(HTCAPTION)
		End If

	End Sub

	<DllImport("USER32.DLL")>
	Private Shared Function _
		GetSystemMenu(ByVal hWnd As IntPtr, ByVal bRevert As Integer) As IntPtr
	End Function

	<DllImport("USER32.DLL")>
	Private Shared Function _
		RemoveMenu(ByVal hMenu As IntPtr, ByVal nPosition As Integer, ByVal wFlags As Integer) As Integer
	End Function

	Private Shared SC_CLOSE As Integer = &H60
	Private Shared MF_BYCOMMAND As Integer = &H0

#End Region

#Region "プロパティ"

	Public Property CaptionDisplayMode() As StatusDisplayMode
		Get
			If C1StatusBar1.Visible = True Then
				Return StatusDisplayMode.ShowAll
			Else
				Return StatusDisplayMode.None
			End If
		End Get
		Set(value As StatusDisplayMode)
			Select Case value
				Case StatusDisplayMode.None
					'表示なし
					C1StatusBar1.Visible = False
				Case StatusDisplayMode.ShowAll
					'全て表示
					C1StatusBar1.Visible = True
			End Select
		End Set

	End Property

#End Region

#Region "フォームイベント"

	''' <summary>
	''' フォームロード時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub frmTempForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

		'テーマを適用
		'Dim theme As C1Theme = C1ThemeController.GetThemeByName("Windows8Gray", False)
		'Dim theme As C1Theme = C1ThemeController.GetThemeByName("ExpressionDark", False)
		'C1ThemeController.ApplyThemeToControlTree(Me, theme)

		'DisplayLoginUser()
		'日付の取得
		Me.Timer1.Start()
		'Me.lblDate.Text = Date.Now.ToString("yyyy/MM/dd")
		'コンピュータ名の表示
		Me.lblUser.Text = My.Computer.Name

		'閉じるボタンを無効にする
		Dim hMenu As IntPtr = GetSystemMenu(Me.Handle, 0)
		RemoveMenu(hMenu, SC_CLOSE, MF_BYCOMMAND)
		'キー入力を受け付ける
		Me.KeyPreview = True

	End Sub

	''' <summary>
	''' フォームキーダウンイベント
	''' </summary>
	''' <param name="e"></param>
	Protected Overrides Sub OnKeyDown(e As KeyEventArgs)
		'Enterキーで項目移動。ボタン上では無効。Alt+Enterは無視する
		If TypeOf Me.ActiveControl Is Button Then
			Exit Sub
		End If

		If e.KeyCode = Keys.Enter And Not e.Alt Then

			Dim forward As Boolean = e.Modifiers <> Keys.Shift
			Me.SelectNextControl(Me.ActiveControl, forward, True, True, True)

			e.Handled = True

		End If

	End Sub

#End Region

#Region "プライベートメソッド"

	'''' <summary>
	'''' ステータスバーにユーザー名を表示する
	'''' </summary>
	'Private Sub DisplayLoginUser()

	'	UserName = m_LoginUser.UserName

	'End Sub

	''' <summary>
	''' ステータスバーに時刻を表示する
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
		Me.lblDate.Text = Date.Now.ToString("yyyy/MM/dd HH:mm:ss")
	End Sub

#End Region


End Class