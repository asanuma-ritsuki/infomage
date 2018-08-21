Public Class frmEditorRemarks


#Region "フォームイベント"

    ''' <summary>
    ''' フォームロード時
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub frmEditorRemarks_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.Text = My.Application.Info.ProductName.ToString & " Ver." &
            My.Application.Info.Version.ToString & " - [目次部備考編集]"

        Me.txtItemEdit.SelectAll()
        Initialize()

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

    ''' <summary>
    ''' フラグ内容インデックス変更時
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub cmbFlag_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbFlag.SelectedIndexChanged

        If Me.cmbFlag.SelectedIndex < 0 Then
            Exit Sub
        End If
        Me.txtItemEdit.Text = Me.cmbFlag.SelectedItem.ToString

    End Sub


#End Region

#Region "プライベートメソッド"

    ''' <summary>
    ''' 入力値を確定する
    ''' </summary>
    ''' <returns></returns>
    Private Function RegistValue() As Boolean

        Dim frm As frmEntry = CType(Me.Owner, frmEntry)

        Try

            Dim iRow As Integer = frm.C1FGridMokuji.Row
            Dim iCol As Integer = frm.C1FGridMokuji.Col
            frm.C1FGridMokuji(iRow, iCol) = Trim(Me.txtItemEdit.Text)
            frm.C1FGridMokuji.AutoSizeRow(iRow)
            'フラグの設定
            frm.C1FGridMokuji(iRow, "フラグID") = Me.cmbFlag.SelectedValue
            frm.C1FGridMokuji(iRow, "フラグ") = Me.cmbFlag.SelectedItem.ToString

            Return True

        Catch ex As Exception

            Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message)
            MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False

        End Try

    End Function

    ''' <summary>
    ''' 初期化処理
    ''' </summary>
    Private Sub Initialize()

        Dim strSQL As String = ""
        Dim sqlProcess As New SQLProcess
        Dim frm As frmEntry = CType(Me.Owner, frmEntry)

        Try
            RemoveHandler cmbFlag.SelectedIndexChanged, AddressOf cmbFlag_SelectedIndexChanged

			strSQL = "SELECT フラグID, CASE WHEN フラグID = 0 THEN フラグ ELSE CONVERT(NVARCHAR, フラグID) + '.' + フラグ END AS フラグ FROM M_フラグ "
			strSQL &= "WHERE 種別ID = 20 AND (フラグID = 0 OR フラグID = 1 OR フラグID = 2 OR フラグID = 9) "
			strSQL &= "ORDER BY フラグID"
            Dim dt As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
            Dim elmFlag() As CElement = Nothing

            For iRow As Integer = 0 To dt.Rows.Count - 1
                ReDim Preserve elmFlag(iRow)
                elmFlag(iRow) = New CElement
                elmFlag(iRow).ID = dt.Rows(iRow)("フラグID")
                elmFlag(iRow).NAME = dt.Rows(iRow)("フラグ")
            Next
            Me.cmbFlag.DisplayMember = "NAME"
            Me.cmbFlag.ValueMember = "ID"
            Me.cmbFlag.DataSource = elmFlag

            '既にフラグIDが立っている場合は、自動でセットする
            If IsNull(frm.C1FGridMokuji(frm.C1FGridMokuji.Row, "フラグID")) Then
                Me.cmbFlag.SelectedIndex = -1
            Else
                Me.cmbFlag.SelectedValue = frm.C1FGridMokuji(frm.C1FGridMokuji.Row, "フラグID").ToString
            End If

            AddHandler cmbFlag.SelectedIndexChanged, AddressOf cmbFlag_SelectedIndexChanged
        Catch ex As Exception

            Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message)
            MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally

            sqlProcess.Close()

        End Try

    End Sub

#End Region

End Class