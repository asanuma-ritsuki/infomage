Public Class frmTraderDetail

#Region "プライベート変数"

	Private _InnerNumber As String
	Private _IsNew As Boolean

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

	''' <summary>
	''' 新規追加か、更新かを判断する
	''' </summary>
	''' <returns></returns>
	Public Property IsNew() As Boolean
		Get
			Return _IsNew
		End Get
		Set(value As Boolean)
			_IsNew = value
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

	''' <summary>
	''' 戻るボタン押下時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click

		CType(Me.Owner, frmOperation).Visible = True
		Me.Close()

	End Sub

	''' <summary>
	''' 業者選択ボタン押下時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub btnTraderSelect_Click(sender As Object, e As EventArgs) Handles btnTraderSelect.Click

		Dim f As New frmSelectTrader
		f.ShowDialog(Me)

	End Sub

	''' <summary>
	''' 新規登録ボタン押下時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub btnRegist_Click(sender As Object, e As EventArgs) Handles btnRegist.Click
		'入力チェック
		'業者名
		If IsNull(txtTraderName.Text) Then
			MessageBox.Show("業者名を入力してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Me.txtTraderName.Focus()
			Me.txtTraderName.SelectAll()
			Exit Sub
		End If
		'有効年度
		If Me.cmbYear.SelectedItems.Count = 0 Then
			MessageBox.Show("有効年度を1つ以上選択してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Me.cmbYear.Focus()
			Exit Sub
		End If
		'有効期間
		If IsDBNull(Me.dtpEffectiveFrom.Value) Then
			'From
			MessageBox.Show("有効期間の開始日を選択してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Me.dtpEffectiveFrom.Focus()
			Exit Sub
		ElseIf IsDBNull(Me.dtpEffectiveTo.Value) Then
			'To
			MessageBox.Show("有効期間の終了日を選択してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Me.dtpEffectiveTo.Focus()
			Exit Sub
		Else
			'FromとToの日付が逆転していたら
			Dim dtFrom As Date = CDate(Me.dtpEffectiveFrom.Value)
			Dim dtTo As Date = CDate(Me.dtpEffectiveTo.Value)
			Dim iCompare As Integer = DateTime.Compare(dtFrom, dtTo)
			If iCompare > 0 Then
				'ToよりFromのほうが後なのでエラー
				MessageBox.Show("有効期間の日付が逆転しています", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
				Me.dtpEffectiveFrom.Focus()
				Exit Sub
			End If
		End If

		If MessageBox.Show("入力した内容で業者を登録します" & vbNewLine & "よろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
			Exit Sub
		End If

		Dim strSQL As String = ""
		Dim sqlProcess As New SQLProcess

		Try
			'履歴番号の特定
			strSQL = "SELECT "
		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & ex.StackTrace)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		Finally

			sqlProcess.Close()

		End Try


	End Sub


#End Region

#Region "プライベートメソッド"

	''' <summary>
	''' 初期化処理
	''' </summary>
	Private Sub Initialize()

		Me.btnBack.Text = "戻る"
		Dim strSQL As String = ""
		Dim sqlProcess As New SQLProcess

		Try
			'都道府県名の取得
			strSQL = "SELECT T2.都道府県コード, T2.都道府県名 "
			strSQL &= "FROM M_自治体 AS T1 INNER JOIN "
			strSQL &= "M_都道府県 AS T2 ON T1.都道府県コード = T2.都道府県コード "
			strSQL &= "WHERE T1.業者フラグ = 1 "
			strSQL &= "GROUP BY T2.都道府県コード, T2.都道府県名 "
			strSQL &= "ORDER BY T2.都道府県コード"
			Dim dt As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
			SetComboValue(Me.cmbPrefectures, dt, False, True)
			'年度一覧の取得
			ViewYear()

			'新規登録か更新かで処理を分岐させる
			If IsNew() Then
				'新規登録
				Me.btnUpdate.Visible = False    '更新ボタンを非表示にする
				Me.btnDelete.Visible = False    '削除ボタンを非表示にする

			Else
				'更新
				'内部番号をもとに各コントロールに値をセットする

			End If

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & ex.StackTrace)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		Finally

			sqlProcess.Close()

		End Try

	End Sub

	''' <summary>
	''' 年度をセット
	''' </summary>
	Private Sub ViewYear()

		Dim strSQL As String = ""
		Dim sqlProcess As New SQLProcess

		Try
			strSQL = "SELECT 年度ID, 年度 FROM M_年度 "
			strSQL &= "ORDER BY 年度ID"
			Dim dt As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)

			Me.cmbYear.BindingInfo.DataSource = dt
			Me.cmbYear.BindingInfo.DisplayMemberPath = "年度"

			Me.cmbYear.SelectAllCaption = "すべての項目を選択する"
			Me.cmbYear.UnselectAllCaption = "すべての項目を選択解除する"

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & ex.StackTrace)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		Finally

			sqlProcess.Close()

		End Try

	End Sub

	Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
		For i As Integer = 0 To Me.cmbYear.SelectedItems.Count - 1
			MessageBox.Show(Me.cmbYear.SelectedItems(i).Value)
		Next
	End Sub

#End Region
End Class