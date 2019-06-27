<System.Diagnostics.DebuggerStepThrough()>
Public Class LoginUser

	Private Shared theInstance As LoginUser = New LoginUser

	Private Sub New()
		'Newを禁止する
	End Sub

	''' <summary>
	''' インスタンスを取得する
	''' </summary>
	''' <returns></returns>
	Public Shared Function GetInstance() As LoginUser
		Return theInstance
	End Function

	Private _UserID As String
	Private _UserName As String
	Private _ManageFlag As Boolean
	Private _LoginItem As String    'ログイン時の引数（受付ID）

	''' <summary>
	''' ユーザーIDの入出力
	''' </summary>
	''' <returns></returns>
	Public Property UserID() As String
		Get
			Return _UserID
		End Get
		Set(value As String)
			_UserID = value
		End Set
	End Property

	''' <summary>
	''' ユーザー名の入出力
	''' </summary>
	''' <returns></returns>
	Public Property UserName() As String
		Get
			Return _UserName
		End Get
		Set(value As String)
			_UserName = value
		End Set
	End Property

	''' <summary>
	''' 管理者フラグの入出力
	''' </summary>
	''' <returns></returns>
	Public Property ManageFlag() As Boolean
		Get
			Return _ManageFlag
		End Get
		Set(value As Boolean)
			_ManageFlag = value
		End Set
	End Property

	''' <summary>
	''' ログイン時の受付IDの入出力
	''' </summary>
	''' <returns></returns>
	Public Property LoginItem() As String
		Get
			Return _LoginItem
		End Get
		Set(value As String)
			_LoginItem = value
		End Set
	End Property

End Class
