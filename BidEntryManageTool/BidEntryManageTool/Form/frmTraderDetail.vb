Public Class frmTraderDetail

#Region "プライベート変数"

	Private _InnerNumber As String

#End Region

#Region "プロパティ"

	''' <summary>
	''' 内部番号の値を読み込みまたは設定する
	''' </summary>
	''' <returns></returns>
	Public Property InnerNumber() As String
		Get
			Return _InnerNumber
		End Get
		Set(value As String)
			_InnerNumber = value
		End Set
	End Property


#End Region

#Region "フォームイベント"

	''' <summary>
	''' フォームロード時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub frmTraderDetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load

		Me.Text = My.Application.Info.ProductName & " Ver." &
			My.Application.Info.Version.ToString & " - [業者登録]"

		'キー入力を受け付ける
		Me.KeyPreview = True

		Initialize()

	End Sub

#End Region

#Region "オブジェクトイベント"

	Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click

		CType(Me.Owner, frmOperation).Visible = True
		Me.Close()

	End Sub

#End Region

#Region "プライベートメソッド"

	''' <summary>
	''' 初期化処理
	''' </summary>
	Private Sub Initialize()

		Me.btnBack.Text = "戻る"

	End Sub

	''' <summary>
	''' 年度をセット
	''' </summary>
	Private Sub ViewYear()

		Dim strSQL As String = ""
		Dim sqlProcess As New SQLProcess

		Try
			strSQL = "SELECT 年度 FROM M_年度 "
			strSQL &= "ORDER BY 年度ID"
			Dim dt As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)

			For iRow As Integer = 0 To dt.Rows.Count - 1

			Next
		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & ex.StackTrace)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		Finally

			sqlProcess.Close()

		End Try

	End Sub

#End Region
End Class