Public Class LoginUser

	Private Shared theInstance As New LoginUser

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

	Private _UserID As Integer
	Private _User As String
	Private _BackFormID As String

	''' <summary>
	''' ユーザーIDの入出力
	''' </summary>
	''' <returns></returns>
	Public Property UserID() As Integer
		Get
			Return _UserID
		End Get
		Set(value As Integer)
			_UserID = value
		End Set
	End Property

	''' <summary>
	''' 作業者の入出力
	''' </summary>
	''' <returns></returns>
	Public Property User() As String
		Get
			Return _User
		End Get
		Set(value As String)
			_User = value
		End Set
	End Property

	''' <summary>
	''' 遷移先のフォーム名の入出力
	''' </summary>
	''' <returns></returns>
	Public Property BackFormID() As String
		Get
			Return _BackFormID
		End Get
		Set(value As String)
			_BackFormID = value
		End Set
	End Property

End Class
