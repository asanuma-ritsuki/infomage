Public Class frmSelectGroup

#Region "フォームイベント"

	''' <summary>
	''' フォームロード時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub frmSelectGroup_Load(sender As Object, e As EventArgs) Handles MyBase.Load

		Me.Text = My.Application.Info.ProductName & " Ver." &
			My.Application.Info.Version.ToString & " - [自治体選択]"

		'キー入力を受け付ける
		Me.KeyPreview = True

		Initialize()

	End Sub

#End Region

#Region "プライベートメソッド"

	''' <summary>
	''' 初期化処理
	''' </summary>
	Private Sub Initialize()

		CaptionDisplayMode = StatusDisplayMode.None
		Dim strSQL As String = ""
		Dim sqlProcess As New SQLProcess

		Try
			strSQL = "SELECT 都道府県コード, 都道府県名 FROM M_都道府県 "
			strSQL &= "ORDER BY 都道府県コード"
			Dim dt As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)

			SetComboValue(Me.cmbPrefectures, dt, True, True)

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & ex.StackTrace)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		Finally

			sqlProcess.Close()

		End Try

	End Sub

	''' <summary>
	''' 都道府県名を検索条件にして検索した値をグリッドにセットする
	''' </summary>
	Private Sub SearchGrid()

		Dim strSQL As String = ""
		Dim sqlProcess As New SQLProcess

		Try

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & ex.StackTrace)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		Finally

			sqlProcess.Close()

		End Try

	End Sub

#End Region

End Class