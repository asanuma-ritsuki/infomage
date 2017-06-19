Public Class frmEditorMokuji

#Region "フォームイベント"

	''' <summary>
	''' フォームロード時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub frmEditorMokuji_Load(sender As Object, e As EventArgs) Handles MyBase.Load

		Me.Text = My.Application.Info.ProductName.ToString & " Ver." &
			My.Application.Info.Version.ToString & " - [目次部編集]"

		Me.txtItemEdit.SelectAll()

	End Sub

#End Region

#Region "オブジェクトイベント"

	''' <summary>
	''' 編集テキストボックスキーダウンイベント
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub txtItemEdit_KeyDown(sender As Object, e As KeyEventArgs) Handles txtItemEdit.KeyDown

		If e.KeyCode = Keys.Enter Then

			If RegistValue() Then
				Me.Close()
			End If

		ElseIf e.KeyCode = Keys.Escape Then

			Me.Close()

		End If

	End Sub

	''' <summary>
	''' OKボタン押下時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click

		If RegistValue() Then
			Me.Close()
		End If

	End Sub

	''' <summary>
	''' キャンセルボタン押下時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click

		Me.Close()

	End Sub

#End Region

#Region "プライベートメソッド"

	''' <summary>
	''' 入力値を確定する
	''' </summary>
	Private Function RegistValue() As Boolean

		''編集元が「リンクTO」だった場合、4桁の0埋め数値以外受け付けない
		'If CType(Me.Owner, frmMain).C1FGridMokuji.Col = 4 Then
		'	If Not Trim(Me.txtItemEdit.Text).Length = 4 Then
		'		MessageBox.Show("4桁の数値を入力してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
		'		Return False
		'	ElseIf Not IsNumeric(Trim(Me.txtItemEdit.Text)) Then
		'		MessageBox.Show("4桁の数値を入力してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
		'		Return False
		'	End If
		'End If

		Dim iRow As Integer = CType(Me.Owner, frmMain).C1FGridMokuji.Row
		Dim iCol As Integer = CType(Me.Owner, frmMain).C1FGridMokuji.Col
		CType(Me.Owner, frmMain).C1FGridMokuji(iRow, iCol) = Trim(Me.txtItemEdit.Text)
		CType(Me.Owner, frmMain).C1FGridMokuji.AutoSizeRow(iRow)
		Return True

	End Function

#End Region

End Class