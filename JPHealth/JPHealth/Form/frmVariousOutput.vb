Public Class frmVariousOutput

#Region "フォームイベント"

	''' <summary>
	''' フォームロード時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub frmVariousOutput_Load(sender As Object, e As EventArgs) Handles MyBase.Load

		Me.Text = My.Application.Info.ProductName & " Ver." &
			My.Application.Info.Version.ToString & " - [各種出力]"

		Initialize()

	End Sub

#End Region

#Region "オブジェクトイベント"

	''' <summary>
	''' 閉じるボタン押下時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click

		XmlSettings.LoadFromXmlFile()
		XmlSettings.Instance.VariousOutputFolder = Me.txtOutputFolder.Text
		XmlSettings.SaveToXmlFile()

		Me.Close()

	End Sub

	''' <summary>
	''' インポート日時値変更時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub cmbLotID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbLotID.SelectedIndexChanged

		Dim strLotID As String = Me.cmbLotID.SelectedValue
		Dim sqlProcess As New SQLProcess
		Dim strSQL As String = ""

		Try
			strSQL = "SELECT T2.重量ヘッダ, T2.重量, COUNT(T1.重量ヘッダ) AS 差出通数, "
			strSQL &= "T2.郵送 + T2.特定記録 AS 一通の料金, "
			strSQL &= "COUNT(T1.重量ヘッダ) * (T2.郵送 + T2.特定記録) AS 合計金額 "
			strSQL &= "FROM T_印刷管理 AS T1 INNER JOIN "
			strSQL &= "M_重量ヘッダ AS T2 ON T1.重量ヘッダ = T2.重量ヘッダ "
			strSQL &= "WHERE ロットID = '" & strLotID & "' "
			strSQL &= "GROUP BY T2.重量ヘッダ, T2.重量, T2.郵送, T2.特定記録 "
			strSQL &= "ORDER BY T2.重量ヘッダ"
			Dim dt As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
			Dim iRecordCount As Integer = 0
			'発送通数情報表示
			For iRow As Integer = 0 To dt.Rows.Count - 1
				iRecordCount += 1
				Me.C1FGridNumber.Rows.Count = iRecordCount + 1
				Me.C1FGridNumber(iRecordCount, "No") = iRecordCount
				Me.C1FGridNumber(iRecordCount, "重量ヘッダ") = dt.Rows(iRow)("重量ヘッダ")
				Me.C1FGridNumber(iRecordCount, "重量") = dt.Rows(iRow)("重量")
				Me.C1FGridNumber(iRecordCount, "差出通数") = dt.Rows(iRow)("差出通数")
				Me.C1FGridNumber(iRecordCount, "一通の料金") = dt.Rows(iRow)("一通の料金")
				Me.C1FGridNumber(iRecordCount, "合計金額") = dt.Rows(iRow)("合計金額")
			Next

		Catch ex As Exception

            Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & ex.StackTrace)
            MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally

            sqlProcess.Close()

        End Try

    End Sub


#End Region

#Region "プライベートメソッド"

    '初期化処理
    Private Sub Initialize()

        CaptionDisplayMode = StatusDisplayMode.None
        'インポート日時コンボボックスのイベントを殺す
        RemoveHandler cmbLotID.SelectedIndexChanged, AddressOf cmbLotID_SelectedIndexChanged

        '設定ファイルを読み込む
        XmlSettings.LoadFromXmlFile()
        Me.txtOutputFolder.Text = XmlSettings.Instance.VariousOutputFolder

        Dim sqlProcess As New SQLProcess
        Dim strSQL As String = ""

        Try
            strSQL = "SELECT ロットID, インポート日時 FROM T_判定票管理 "
            strSQL &= "GROUP BY ロットID, インポート日時 "
            strSQL &= "ORDER BY ロットID DESC, インポート日時"
            Dim dt As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
            SetComboValue(Me.cmbLotID, dt, False)

            'インポート日時コンボボックスのイベントを生かす
            AddHandler cmbLotID.SelectedIndexChanged, AddressOf cmbLotID_SelectedIndexChanged
            Me.cmbLotID.SelectedIndex = 0

        Catch ex As Exception

            Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & ex.StackTrace)
            MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		Finally

			sqlProcess.Close()

		End Try
	End Sub

#End Region
End Class