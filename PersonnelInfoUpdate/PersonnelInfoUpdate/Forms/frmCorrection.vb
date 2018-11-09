Public Class frmCorrection

#Region "フォームイベント"

	''' <summary>
	''' フォームロード時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub frmCorrection_Load(sender As Object, e As EventArgs) Handles MyBase.Load

		Me.Text = My.Application.Info.ProductName & " Ver." &
			My.Application.Info.Version.ToString & " - [不備修正画面]"
		Me.KeyPreview = True
		CaptionDisplayMode = StatusDisplayMode.TitleOnly

		Initialize()

	End Sub

	''' <summary>
	''' フォームクロージング
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub frmCorrection_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
		'全ての不備が修正されていたら修正済日時を書き込む
		Dim strSQL As String = ""
		Dim sqlProcess As New SQLProcess

		Try
			strSQL = "SELECT COUNT(*) FROM T_不備内容 "
			strSQL &= "WHERE ロットID = '" & Me.txtLotID.Text & "' "
			strSQL &= "AND 修正済フラグ = 0 AND 対象外 = 0"
			If sqlProcess.DB_EXECUTE_SCALAR(strSQL) = 0 Then
				'全て修正されていた
				strSQL = "UPDATE T_ロット管理 SET "
				strSQL &= "修正済日時 = '" & Date.Now & "' "
				strSQL &= "WHERE ロットID = '" & Me.txtLotID.Text & "'"
				sqlProcess.DB_UPDATE(strSQL)
			End If

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & ex.StackTrace)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		Finally

			sqlProcess.Close()

		End Try

	End Sub


#End Region

#Region "オブジェクトイベント"

	''' <summary>
	''' 閉じるボタン押下時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
		Me.Close()
	End Sub

	''' <summary>
	''' 組織コード1インデックス変更時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub cmbOrg1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbOrg1.SelectedIndexChanged

		Me.cmbOrg2.Items.Clear()
		Me.cmbOrg3.Items.Clear()
		Me.cmbOrg4.Items.Clear()

		Dim strSQL As String = ""
		Dim sqlProcess As New SQLProcess

		Try
			'選択された組織コード1をもとに組織コード2のコンボボックスに値をセットする
			Dim strItems As String() = Me.cmbOrg1.Text.Split("_")
			strSQL = "SELECT 組織名称 + '_' + 組織コード AS 組織 FROM M_組織情報 "
			strSQL &= "WHERE 第1階層組織コード = '" & strItems(strItems.Count - 1) & "' "
			strSQL &= "AND 第2階層組織コード = '' "
			strSQL &= "ORDER BY 組織コード"
			Dim dt As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
			For iRow As Integer = 0 To dt.Rows.Count - 1
				Me.cmbOrg2.Items.Add(dt.Rows(iRow)("組織"))
			Next

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & ex.StackTrace)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		Finally

			sqlProcess.Close()

		End Try

	End Sub

	''' <summary>
	''' 組織コード2インデックス変更時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub cmbOrg2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbOrg2.SelectedIndexChanged

		Me.cmbOrg3.Items.Clear()
		Me.cmbOrg4.Items.Clear()

		Dim strSQL As String = ""
		Dim sqlProcess As New SQLProcess

		Try
			'選択された組織コード1、2をもとに組織コード3のコンボボックスに値をセットする
			Dim strItems1 As String() = Me.cmbOrg1.Text.Split("_")
			Dim strItems2 As String() = Me.cmbOrg2.Text.Split("_")
			strSQL = "SELECT 組織名称 + '_' + 組織コード AS 組織 FROM M_組織情報 "
			strSQL &= "WHERE 第1階層組織コード = '" & strItems1(strItems1.Count - 1) & "' "
			strSQL &= "AND 第2階層組織コード = '" & strItems2(strItems2.Count - 1) & "' "
			strSQL &= "AND 第3階層組織コード = '' "
			strSQL &= "ORDER BY 組織コード"
			Dim dt As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
			For iRow As Integer = 0 To dt.Rows.Count - 1
				Me.cmbOrg3.Items.Add(dt.Rows(iRow)("組織"))
			Next

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & ex.StackTrace)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		Finally

			sqlProcess.Close()

		End Try

	End Sub

	''' <summary>
	''' 組織コード3インデックス変更時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub cmbOrg3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbOrg3.SelectedIndexChanged

		Me.cmbOrg4.Items.Clear()

		Dim strSQL As String = ""
		Dim sqlProcess As New SQLProcess

		Try
			'選択された組織コード1、2、3をもとに組織コード4のコンボボックスに値をセットする
			Dim strItems1 As String() = Me.cmbOrg1.Text.Split("_")
			Dim strItems2 As String() = Me.cmbOrg2.Text.Split("_")
			Dim strItems3 As String() = Me.cmbOrg3.Text.Split("_")
			strSQL = "SELECT 組織名称 + '_' + 組織コード AS 組織 FROM M_組織情報 "
			strSQL &= "WHERE 第1階層組織コード = '" & strItems1(strItems1.Count - 1) & "' "
			strSQL &= "AND 第2階層組織コード = '" & strItems2(strItems2.Count - 1) & "' "
			strSQL &= "AND 第3階層組織コード = '" & strItems3(strItems3.Count - 1) & "' "
			strSQL &= "ORDER BY 組織コード"
			Dim dt As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
			For iRow As Integer = 0 To dt.Rows.Count - 1
				Me.cmbOrg4.Items.Add(dt.Rows(iRow)("組織"))
			Next

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & ex.StackTrace)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		Finally

			sqlProcess.Close()

		End Try

	End Sub

	''' <summary>
	''' グリッドクリック
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub C1FGridResult_Click(sender As Object, e As EventArgs) Handles C1FGridResult.Click

		Dim iIndex As Integer = Me.C1FGridResult.Row
		Dim strSQL As String = ""
		Dim sqlProcess As New SQLProcess

		'コンボボックスを初期化しておく
		Me.cmbResignation.SelectedIndex = -1
		Me.cmbPostCode.SelectedIndex = -1
		Me.cmbOrg1.SelectedIndex = -1
		Me.cmbOrg2.SelectedIndex = -1
		Me.cmbOrg3.SelectedIndex = -1
		Me.cmbOrg4.SelectedIndex = -1
		Me.cmbOrg5.SelectedIndex = -1
		'ボーダーラインの初期化
		Me.dtpDate.BorderColor = SystemColors.WindowFrame
		Me.cmbResignation.BorderColor = SystemColors.WindowFrame
		Me.txtUserID.BorderColor = SystemColors.WindowFrame
		Me.txtName.BorderColor = SystemColors.WindowFrame
		Me.txtNameKana.BorderColor = SystemColors.WindowFrame
		Me.cmbPostCode.BorderColor = SystemColors.WindowFrame
		Me.cmbOrg1.BorderColor = SystemColors.WindowFrame
		Me.cmbOrg2.BorderColor = SystemColors.WindowFrame
		Me.cmbOrg3.BorderColor = SystemColors.WindowFrame
		Me.cmbOrg4.BorderColor = SystemColors.WindowFrame
		Me.cmbOrg5.BorderColor = SystemColors.WindowFrame

		Try
			strSQL = "SELECT ロットID, レコード番号, シーケンス, 発令日, 辞令, ユーザーID, 利用者名称, 利用者名称カナ, 役職コード, "
			strSQL &= "組織コード1, 組織コード2, 組織コード3, 組織コード4, 組織コード5, 不備項目, 不備説明, 不備内容, 修正内容, 修正済フラグ, 対象外 "
			strSQL &= "FROM T_不備内容 "
			strSQL &= "WHERE ロットID = '" & Me.txtLotID.Text & "' "
			strSQL &= "AND レコード番号 = " & Me.C1FGridResult(iIndex, "レコード番号") & " "
			strSQL &= "AND シーケンス = " & Me.C1FGridResult(iIndex, "シーケンス")
			Dim dt As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
			If dt.Rows.Count > 0 Then
				Me.txtRemarks.Text = dt.Rows(0)("不備説明")
				Me.dtpDate.Text = dt.Rows(0)("発令日")
				Me.cmbResignation.Text = dt.Rows(0)("辞令")
				Me.txtUserID.Text = dt.Rows(0)("ユーザーID")
				Me.txtName.Text = dt.Rows(0)("利用者名称")
				Me.txtNameKana.Text = dt.Rows(0)("利用者名称カナ")
				Me.cmbPostCode.Text = dt.Rows(0)("役職コード")
				Me.cmbOrg1.Text = dt.Rows(0)("組織コード1")
				Me.cmbOrg2.Text = dt.Rows(0)("組織コード2")
				Me.cmbOrg3.Text = dt.Rows(0)("組織コード3")
				Me.cmbOrg4.Text = dt.Rows(0)("組織コード4")
				Me.cmbOrg5.Text = dt.Rows(0)("組織コード5")
				Me.chkNotTarget.Checked = dt.Rows(0)("対象外")
			End If
			'該当の不備項目の背景色を変える
			'一度すべての項目を使用不可にして、該当項目だけ使用可能に変更する
			'===一時廃止===
			'Me.dtpDate.Enabled = False
			'Me.cmbResignation.Enabled = False
			'Me.txtUserID.Enabled = False
			'Me.txtName.Enabled = False
			'Me.txtNameKana.Enabled = False
			'Me.cmbPostCode.Enabled = False
			'Me.cmbOrg1.Enabled = False
			'Me.cmbOrg2.Enabled = False
			'Me.cmbOrg3.Enabled = False
			'Me.cmbOrg4.Enabled = False
			'Me.cmbOrg5.Enabled = False
			Select Case Me.C1FGridResult(iIndex, "不備項目")
				Case "ユーザーID"
					Me.txtUserID.Enabled = True
					Me.txtUserID.BorderColor = Color.Red
				Case "発令日"
					Me.dtpDate.Enabled = True
					Me.dtpDate.BorderColor = Color.Red
				Case "辞令"
					Me.cmbResignation.Enabled = True
					Me.cmbResignation.BorderColor = Color.Red
				Case "利用者名称"
					Me.txtName.Enabled = True
					Me.txtName.BorderColor = Color.Red
				Case "利用者名称カナ"
					Me.txtNameKana.Enabled = True
					Me.txtNameKana.BorderColor = Color.Red
				Case "役職コード"
					Me.cmbPostCode.Enabled = True
					Me.cmbPostCode.BorderColor = Color.Red
				Case "役職コード1"
					Me.cmbOrg1.Enabled = True
					Me.cmbOrg2.Enabled = True
					Me.cmbOrg3.Enabled = True
					Me.cmbOrg4.Enabled = True
					Me.cmbOrg5.Enabled = True
					Me.cmbOrg1.BorderColor = Color.Red
				Case "役職コード2"
					Me.cmbOrg1.Enabled = True
					Me.cmbOrg2.Enabled = True
					Me.cmbOrg3.Enabled = True
					Me.cmbOrg4.Enabled = True
					Me.cmbOrg5.Enabled = True
					Me.cmbOrg2.BorderColor = Color.Red
				Case "役職コード3"
					Me.cmbOrg1.Enabled = True
					Me.cmbOrg2.Enabled = True
					Me.cmbOrg3.Enabled = True
					Me.cmbOrg4.Enabled = True
					Me.cmbOrg5.Enabled = True
					Me.cmbOrg3.BorderColor = Color.Red
				Case "役職コード4"
					Me.cmbOrg1.Enabled = True
					Me.cmbOrg2.Enabled = True
					Me.cmbOrg3.Enabled = True
					Me.cmbOrg4.Enabled = True
					Me.cmbOrg5.Enabled = True
					Me.cmbOrg4.BorderColor = Color.Red
				Case "役職コード5"
					Me.cmbOrg1.Enabled = True
					Me.cmbOrg2.Enabled = True
					Me.cmbOrg3.Enabled = True
					Me.cmbOrg4.Enabled = True
					Me.cmbOrg5.Enabled = True
					Me.cmbOrg5.BorderColor = Color.Red
				Case Else
					'Me.dtpDate.Enabled = False
					'Me.cmbResignation.Enabled = False
					'Me.txtUserID.Enabled = False
					'Me.txtName.Enabled = False
					'Me.txtNameKana.Enabled = False
					'Me.cmbPostCode.Enabled = False
					'Me.cmbOrg1.Enabled = False
					'Me.cmbOrg2.Enabled = False
					'Me.cmbOrg3.Enabled = False
					'Me.cmbOrg4.Enabled = False
					'Me.cmbOrg5.Enabled = False

			End Select
			Me.btnUpdate.Enabled = False

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & ex.StackTrace)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		Finally

			sqlProcess.Close()

		End Try

	End Sub

	''' <summary>
	''' チェックボタン押下時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub btnCheck_Click(sender As Object, e As EventArgs) Handles btnCheck.Click

		Dim iIndex As Integer = Me.C1FGridResult.Row
		If DataCheckCorrection(Me, Me.txtLotID.Text, Me.C1FGridResult(iIndex, "レコード番号"), Me.C1FGridResult(iIndex, "シーケンス")) Then
			'正常終了
			MessageBox.Show("修正データに問題はありませんでした" & vbNewLine & "修正内容を更新してください", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information)
			Me.btnUpdate.Enabled = True
		Else
			'異常終了
			MessageBox.Show("修正データにエラーが発生しています" & vbNewLine & "エラー項目を修正して再度チェックしてください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Me.btnUpdate.Enabled = False
		End If
	End Sub

	''' <summary>
	''' 更新ボタン押下時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click

		If MessageBox.Show("修正内容を更新します" & vbNewLine & "よろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
			Exit Sub
		End If

		Dim strSQL As String = ""
		Dim sqlProcess As New SQLProcess
		Dim iIndex As Integer = Me.C1FGridResult.Row
		'修正内容を特定する
		Dim strCorrectionData As String = ""
		Dim strItemName As String = ""
		Select Case Me.C1FGridResult(iIndex, "不備項目")
			Case "発令日"
				strCorrectionData = Me.dtpDate.Text
				strItemName = "発令日"
			Case "辞令"
				strCorrectionData = Me.cmbResignation.Text
				strItemName = "辞令"
			Case "ユーザーID"
				strCorrectionData = Me.txtUserID.Text
				strItemName = "ユーザーID"
			Case "利用者名称"
				strCorrectionData = Me.txtName.Text
				strItemName = "利用者名称"
			Case "利用者名称カナ"
				strCorrectionData = Me.txtNameKana.Text
				strItemName = "利用者名称カナ"
			Case "役職コード"
				strCorrectionData = Me.cmbPostCode.Text
				strItemName = "役職コード"
			Case "組織コード1"
				strCorrectionData = Me.cmbOrg1.Text
				strItemName = "組織コード1"
			Case "組織コード2"
				strCorrectionData = Me.cmbOrg2.Text
				strItemName = "組織コード2"
			Case "組織コード3"
				strCorrectionData = Me.cmbOrg3.Text
				strItemName = "組織コード3"
			Case "組織コード4"
				strCorrectionData = Me.cmbOrg4.Text
				strItemName = "組織コード4"
			Case "組織コード5"
				strCorrectionData = Me.cmbOrg5.Text
				strItemName = "組織コード5"
		End Select

		Try
			'対象外にチェックが付いていたら対象外項目だけ1を立てる
			If Me.chkNotTarget.Checked Then
				'対象外の場合は、同一レコード番号のシーケンス全てに対して対象外のフラグを立てる
				strSQL = "UPDATE T_不備内容 SET "
				strSQL &= "対象外 = 1 "
				strSQL &= "WHERE ロットID = '" & Me.txtLotID.Text & "' "
				strSQL &= "AND レコード番号 = " & Me.C1FGridResult(iIndex, "レコード番号")
				'strSQL &= "AND シーケンス = " & Me.C1FGridResult(iIndex, "シーケンス")
				sqlProcess.DB_UPDATE(strSQL)
			Else
				strSQL = "UPDATE T_不備内容 SET "
				strSQL &= "発令日 = '" & Me.dtpDate.Text & "'"
				strSQL &= ", 辞令 = '" & Me.cmbResignation.Text & "'"
				strSQL &= ", ユーザーID = '" & Me.txtUserID.Text & "'"
				strSQL &= ", 利用者名称 = '" & Me.txtName.Text & "'"
				strSQL &= ", 利用者名称カナ = '" & Me.txtNameKana.Text & "'"
				strSQL &= ", 役職コード = '" & Me.cmbPostCode.Text & "'"
				strSQL &= ", 組織コード1 = '" & Me.cmbOrg1.Text & "'"
				strSQL &= ", 組織コード2 = '" & Me.cmbOrg2.Text & "'"
				strSQL &= ", 組織コード3 = '" & Me.cmbOrg3.Text & "'"
				strSQL &= ", 組織コード4 = '" & Me.cmbOrg4.Text & "'"
				strSQL &= ", 組織コード5 = '" & Me.cmbOrg5.Text & "'"
				strSQL &= ", 修正内容 = '" & strCorrectionData & "'"
				strSQL &= ", 修正済フラグ = 1"
				strSQL &= ", 対象外 = 0 "
				strSQL &= "WHERE ロットID = '" & Me.txtLotID.Text & "' "
				strSQL &= "AND レコード番号 = " & Me.C1FGridResult(iIndex, "レコード番号") & " "
				strSQL &= "AND シーケンス = " & Me.C1FGridResult(iIndex, "シーケンス")
				sqlProcess.DB_UPDATE(strSQL)
				'異動情報の更新
				strSQL = "UPDATE T_異動情報 SET "
				strSQL &= "発令日 = '" & Me.dtpDate.Text & "'"
				strSQL &= ", 辞令 = '" & Me.cmbResignation.Text & "'"
				strSQL &= ", ユーザーID = '" & Me.txtUserID.Text & "'"
				strSQL &= ", 利用者名称 = '" & Me.txtName.Text & "'"
				strSQL &= ", 利用者名称カナ = '" & Me.txtNameKana.Text & "'"
				strSQL &= ", 役職コード = '" & Me.cmbPostCode.Text & "'"
				strSQL &= ", 組織コード1 = '" & Me.cmbOrg1.Text & "'"
				strSQL &= ", 組織コード2 = '" & Me.cmbOrg2.Text & "'"
				strSQL &= ", 組織コード3 = '" & Me.cmbOrg3.Text & "'"
				strSQL &= ", 組織コード4 = '" & Me.cmbOrg4.Text & "'"
				strSQL &= ", 組織コード5 = '" & Me.cmbOrg5.Text & "'"
				strSQL &= "WHERE ロットID = '" & Me.txtLotID.Text & "' "
				strSQL &= "AND レコード番号 = " & Me.C1FGridResult(iIndex, "レコード番号") & " "
				sqlProcess.DB_UPDATE(strSQL)
				'strSQL = "UPDATE T_異動情報 SET "
				'strSQL &= strItemName & " = '" & strCorrectionData & "' "
				'strSQL &= "WHERE ロットID = '" & Me.txtLotID.Text & "' "
				'strSQL &= "AND レコード番号 = " & Me.C1FGridResult(iIndex, "レコード番号")
				'sqlProcess.DB_UPDATE(strSQL)
			End If

			SearchGrid(iIndex)

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & ex.StackTrace)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		Finally

			sqlProcess.Close()

		End Try

	End Sub

	''' <summary>
	''' 対象外チェックボックスチェック変更時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub chkNotTarget_CheckedChanged(sender As Object, e As EventArgs) Handles chkNotTarget.CheckedChanged

		If Me.chkNotTarget.Checked Then
			'チェックの有無にかかわらず更新ボタンが押せるようにする
			Me.btnUpdate.Enabled = True
		Else
			Me.btnUpdate.Enabled = True
		End If
	End Sub


#End Region

#Region "プライベートメソッド"

	''' <summary>
	''' 初期化処理
	''' </summary>
	Private Sub Initialize()

		Me.btnBack.Text = "閉じる"
		Me.btnUpdate.Enabled = False

		Dim strSQL As String = ""
		Dim sqlProcess As New SQLProcess

		Try
			'辞令のセット
			strSQL = "SELECT 辞令 FROM M_辞令 "
			strSQL &= "ORDER BY 辞令ID"
			Dim dt As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
			For iRow As Integer = 0 To dt.Rows.Count - 1
				Me.cmbResignation.Items.Add(dt.Rows(iRow)("辞令"))
			Next
			'役職コードのセット
			strSQL = "SELECT 役職名称 + '_' + 役職コード AS 役職 FROM M_役職 "
			strSQL &= "ORDER BY 役職コード"
			dt = sqlProcess.DB_SELECT_DATATABLE(strSQL)
			For iRow As Integer = 0 To dt.Rows.Count - 1
				Me.cmbPostCode.Items.Add(dt.Rows(iRow)("役職"))
			Next
			'組織コード1をセット
			strSQL = "SELECT 組織名称 + '_' + 組織コード AS 組織 FROM M_組織情報 "
			strSQL &= "WHERE 第1階層組織コード = '' "
			strSQL &= "ORDER BY 組織コード"
			dt = sqlProcess.DB_SELECT_DATATABLE(strSQL)
			For iRow As Integer = 0 To dt.Rows.Count - 1
				Me.cmbOrg1.Items.Add(dt.Rows(iRow)("組織"))
			Next

			SearchGrid()

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & ex.StackTrace)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		Finally

			sqlProcess.Close()

		End Try
	End Sub

	''' <summary>
	''' グリッドの内容を取得する
	''' </summary>
	Private Sub SearchGrid(Optional ByVal iIndex As Integer = 0)

		Dim strSQL As String = ""
		Dim sqlProcess As New SQLProcess
		Me.C1FGridResult.Rows.Count = 1

		Try
			strSQL = "SELECT ロットID, レコード番号, シーケンス, 発令日, 辞令, ユーザーID, 利用者名称, 利用者名称カナ, "
			strSQL &= "不備項目, 不備説明, 不備内容, 修正内容, 修正済フラグ, 対象外 "
			strSQL &= "FROM T_不備内容 "
			strSQL &= "WHERE ロットID = '" & Me.txtLotID.Text & "' "
			strSQL &= "ORDER BY レコード番号, シーケンス"
			Dim dt As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
			Dim iCount As Integer = 0
			For iRow As Integer = 0 To dt.Rows.Count - 1
				iCount += 1
				Me.C1FGridResult.Rows.Count = iCount + 1
				Me.C1FGridResult(iCount, "No") = iCount
				Me.C1FGridResult(iCount, "レコード番号") = dt.Rows(iRow)("レコード番号")
				Me.C1FGridResult(iCount, "シーケンス") = dt.Rows(iRow)("シーケンス")
				Me.C1FGridResult(iCount, "発令日") = dt.Rows(iRow)("発令日")
				Me.C1FGridResult(iCount, "辞令") = dt.Rows(iRow)("辞令")
				Me.C1FGridResult(iCount, "ユーザーID") = dt.Rows(iRow)("ユーザーID")
				Me.C1FGridResult(iCount, "利用者名称") = dt.Rows(iRow)("利用者名称")
				Me.C1FGridResult(iCount, "利用者名称カナ") = dt.Rows(iRow)("利用者名称カナ")
				Me.C1FGridResult(iCount, "不備項目") = dt.Rows(iRow)("不備項目")
				Me.C1FGridResult(iCount, "不備説明") = dt.Rows(iRow)("不備説明")
				Me.C1FGridResult(iCount, "不備内容") = dt.Rows(iRow)("不備内容")
				Me.C1FGridResult(iCount, "修正内容") = dt.Rows(iRow)("修正内容")
				Me.C1FGridResult(iCount, "修正済") = IIf(dt.Rows(iRow)("修正済フラグ"), 1, 0)
				Me.C1FGridResult(iCount, "対象外") = IIf(dt.Rows(iRow)("対象外"), 1, 0)
			Next

			Me.C1FGridResult.Row = iIndex

			ChangeBackColor()

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & ex.StackTrace)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		Finally

			sqlProcess.Close()

		End Try

	End Sub

	''' <summary>
	''' グリッドの背景色を条件によって変更する
	''' </summary>
	Private Sub ChangeBackColor()
		'カスタムスタイルを作成する
		With Me.C1FGridResult
			'修正済スタイル
			.Styles.Add("StyleChange")
			.Styles("StyleChange").BackColor = Color.White
			.Styles("StyleChange").ForeColor = Color.Black
			'要修正スタイル
			.Styles.Add("StyleIncomplete")
			.Styles("StyleIncomplete").BackColor = Color.Yellow
			.Styles("StyleIncomplete").ForeColor = Color.Black
			'削除スタイル
			.Styles.Add("StyleDelete")
			.Styles("StyleDelete").BackColor = Color.LightSlateGray
			.Styles("StyleDelete").ForeColor = Color.White

			Me.C1FGridResult.BeginUpdate()

			For i As Integer = 1 To Me.C1FGridResult.Rows.Count - 1
				'対象外がチェックされているか
				If Not Me.C1FGridResult(i, "対象外") Then
					'修正済みがチェックされているか
					If Not Me.C1FGridResult(i, "修正済") Then
						'全てNULL(要修正)
						Me.C1FGridResult.Rows(i).Style = Me.C1FGridResult.Styles("StyleIncomplete")
					Else
						'修正済
						Me.C1FGridResult.Rows(i).Style = Me.C1FGridResult.Styles("StyleChange")
					End If
				Else
					'対象外
					Me.C1FGridResult.Rows(i).Style = Me.C1FGridResult.Styles("StyleDelete")
				End If
			Next

			Me.C1FGridResult.EndUpdate()
		End With

	End Sub

#End Region

End Class