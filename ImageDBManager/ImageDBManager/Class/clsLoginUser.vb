Public Class LoginUser

	Private Shared theInstance As LoginUser = New LoginUser

#Region "インスタンス"

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

#End Region

#Region "プライベート変数"

	Private UserID_ As String   'ユーザーID
	Private UserName_ As String 'ユーザー名
	Private ManageFlag_ As Boolean  '管理者フラグ

#End Region

#Region "プロパティ"

	''' <summary>
	''' ユーザーIDの入出力
	''' </summary>
	''' <returns></returns>
	Public Property UserID() As String
		Get
			Return UserID_
		End Get
		Set(value As String)
			UserID_ = value
		End Set
	End Property

	''' <summary>
	''' ユーザー名の入出力
	''' </summary>
	''' <returns></returns>
	Public Property UserName() As String
		Get
			Return UserName_
		End Get
		Set(value As String)
			UserName_ = value
		End Set
	End Property

	''' <summary>
	''' 管理者フラグの入出力
	''' </summary>
	''' <returns></returns>
	Public Property ManageFlag() As Boolean
		Get
			Return ManageFlag_
		End Get
		Set(value As Boolean)
			ManageFlag_ = value
		End Set
	End Property

#End Region

End Class
