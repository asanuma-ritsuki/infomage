Public Class frmImageFlagDialog

#Region "プライベート変数"

    ''' <summary>
    ''' スタイル列挙体
    ''' </summary>
    ''' <remarks></remarks>
    Friend Enum GridStyleName
        StyleDefault
        StyleTarget
        StyleLink
    End Enum

#End Region

#Region "フォームイベント"

    ''' <summary>
    ''' フォームロード時
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub frmImageFlagDialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.Text = My.Application.Info.ProductName.ToString & " Ver." &
            My.Application.Info.Version.ToString & " - [ファイル削除理由選択]"

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
			MessageBox.Show("削除理由を選択してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Exit Sub
		End If

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
    ''' 初期化処理
    ''' </summary>
    Private Sub Initialize()

        Dim strSQL As String = ""
        Dim sqlProcess As New SQLProcess
        Dim frm As frmMain = CType(Me.Owner, frmMain)

        Try
			strSQL = "SELECT フラグID, CONVERT(NVARCHAR, フラグID) + '.' + フラグ AS フラグ FROM M_フラグ "
			strSQL &= "WHERE 種別ID = 30 "
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

            '既にフラグが立っている場合は、自動でセットする
            If IsNull(frm.C1FGridResult(frm.C1FGridResult.Row, "フラグID")) Then
                Me.cmbFlag.SelectedIndex = -1
            Else
                Me.cmbFlag.SelectedValue = frm.C1FGridResult(frm.C1FGridResult.Row, "フラグID").ToString
            End If

        Catch ex As Exception

            Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message)
            MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally

            sqlProcess.Close()

        End Try

    End Sub

    ''' <summary>
    ''' 入力値を確定する
    ''' </summary>
    ''' <returns></returns>
    Private Function RegistValue() As Boolean

        Dim frm As frmMain = CType(Me.Owner, frmMain)

        Try
            Dim iRow As Integer = frm.C1FGridResult.Row

            'フラグの設定
            frm.C1FGridResult(iRow, "削除") = True
            frm.C1FGridResult(iRow, "フラグID") = Me.cmbFlag.SelectedValue
            ChangeBackColor(iRow, GridStyleName.StyleTarget)

            Return True

        Catch ex As Exception

            Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message)
            MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False

        End Try

    End Function

    ''' <summary>
    ''' FlexGridの背景色を変更する(1行単位)
    ''' </summary>
    ''' <param name="iRow"></param>
    ''' <param name="iGridStyleName"></param>
    ''' <remarks></remarks>
    Private Sub ChangeBackColor(ByVal iRow As Integer, ByVal iGridStyleName As GridStyleName)

        Dim frm As frmMain = CType(Me.Owner, frmMain)

        'カスタムスタイルを作成する
        With frm.C1FGridResult
            'デフォルトスタイル
            .Styles.Add("StyleDefault")
            .Styles("StyleDefault").BackColor = Color.White
            .Styles("StyleDefault").ForeColor = Color.Black
            '目次スタイル
            .Styles.Add("StyleTarget")
            .Styles("StyleTarget").BackColor = Color.LightSlateGray
            .Styles("StyleTarget").ForeColor = Color.Black
            'リンクスタイル
            .Styles.Add("StyleLink")
            .Styles("StyleLink").BackColor = Color.LightCoral
            .Styles("StyleLink").ForeColor = Color.Black

        End With

        Select Case iGridStyleName

            Case GridStyleName.StyleDefault
                'デフォルト
                frm.C1FGridResult.Rows(iRow).Style = frm.C1FGridResult.Styles("StyleDefault")

            Case GridStyleName.StyleTarget
                '目次
                frm.C1FGridResult.Rows(iRow).Style = frm.C1FGridResult.Styles("StyleTarget")

            Case GridStyleName.StyleLink
                'リンク
                frm.C1FGridResult.Rows(iRow).Style = frm.C1FGridResult.Styles("StyleLink")

        End Select

    End Sub

#End Region
End Class