Public Class frmAbortDialog

#Region "フォームイベント"

    ''' <summary>
    ''' フォームロード時
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub frmImageFlagDialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.Text = My.Application.Info.ProductName.ToString & " Ver." &
            My.Application.Info.Version.ToString & " - [中断理由選択]"

        Initialize()

    End Sub

#End Region

#Region "オブジェクトイベント"

    ''' <summary>
    ''' OKボタン押下時
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click

        If Me.cmbFlag.SelectedIndex < 0 Then
            MessageBox.Show("中断理由を選択してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Me.DialogResult = DialogResult.Cancel
			Exit Sub
		End If

        CType(Me.Owner, frmMain).iAbortID = Me.cmbFlag.SelectedValue
        Me.DialogResult = DialogResult.Yes

	End Sub

    ''' <summary>
    ''' キャンセルボタン押下時
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click

        Me.DialogResult = DialogResult.Cancel

	End Sub

#End Region

#Region "プライベートメソッド"

    ''' <summary>
    ''' 初期化処理
    ''' </summary>
    Private Sub Initialize()

        Dim strSQL As String = ""
        Dim sqlProcess As New SQLProcess
        Dim frm As frmMain = CType(Me.Owner, frmMain)

        Try
            strSQL = "SELECT フラグID, フラグ FROM M_フラグ "
            strSQL &= "WHERE 種別ID = 10 "
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

            Me.cmbFlag.SelectedIndex = -1

        Catch ex As Exception

            Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message)
            MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally

            sqlProcess.Close()

        End Try

    End Sub

#End Region

End Class