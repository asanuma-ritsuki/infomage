Imports C1.Win.C1FlexGrid

Module LinkPasteProcess

#Region "プライベート変数"

	''' <summary>
	''' スタイル列挙体
	''' </summary>
	''' <remarks></remarks>
	Friend Enum GridStyleName
		StyleDefault
		StyleTarget
		StyleLink
		StyleFinish
		StyleUpdate
		StyleDifference
	End Enum

	Friend Enum LinkFromTo
		LinkFrom
		LinkTo
	End Enum

#End Region

#Region "パブリックメソッド"

	''' <summary>
	''' ファイルリスト、目次グリッドの選択業をもとにリンク設定を行う
	''' </summary>
	''' <param name="C1FGridResult">ファイルリストのグリッド</param>
	''' <param name="C1FGridMokuji">目次部のグリッド</param>
	''' <param name="LinkPlace">リンク始めかリンク終りを指定</param>
	Public Sub SetLink(ByVal C1FGridResult As C1FlexGrid, ByVal C1FGridMokuji As C1FlexGrid, ByVal LinkPlace As LinkFromTo)
		'今現在選択されているファイル名をリンク部分にセットする
		Dim iIndex As Integer = 0

		Dim iRow As Integer = C1FGridMokuji.Row '選択されている目次レコードのインデックス
		Dim iImageRow As Integer = C1FGridResult.Row    '選択されているイメージファイルのインデックス
		Dim iTargetRow As Integer = 0
		Dim strFileName As String = C1FGridResult(iImageRow, "ファイル名")   '選択されているファイル名

		Select Case LinkPlace
			Case LinkFromTo.LinkFrom
				'リンク始め
				'===================================================================
				'ファイルリスト部の選択されているレコードの削除フラグが立っている場合はエラーとする
				If C1FGridResult(iImageRow, "削除") = True Then
					MessageBox.Show("削除フラグが立っているためリンクに設定できません", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
					Exit Sub
				End If
				'===================================================================
				'前レコードより数値が若い場合は警告を出す
				If iRow > 1 Then
					'1レコード目はチェックしない
					'前レコードのリンク値がNULLの場合は遡ってリンクを探す
					For i As Integer = iRow - 1 To 1 Step -1
						If Not IsNull(C1FGridMokuji(i, "リンク")) Then
							iTargetRow = i
							Exit For
						End If
					Next

					'iTargetRowが0の場合は初回リンクとみなしスキップする
					If iTargetRow > 0 Then
						Dim iFileNo As Integer = CInt(strFileName)    '選択されているファイル名の数値化
						Dim iBeforeLink As Integer = CInt(C1FGridMokuji(iTargetRow, "リンク")) '目次部の選択されているレコードの前のレコードのリンク番号を数値化
						If iBeforeLink > iFileNo Then
							'これからリンクを貼ろうとしている値が前レコードのリンク数値より小さかった場合、警告を出す
							MessageBox.Show("前レコードのリンクより前のファイルのリンクを貼ろうとしています" & vbNewLine & "リンクが正しいか見直してください", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning)
						End If
					End If
				End If
				'===================================================================
				'リンク設定
				C1FGridMokuji(iRow, "リンク") = strFileName
				'リンクTOにも同様の値をセットする
				C1FGridMokuji(iRow, "リンクTO") = strFileName
				'ファイルリストのリンクフラグを立てる
				C1FGridResult(iImageRow, "リンク") = True
				'ファイルリストの選択レコードの背景色を変更する
				ChangeBackColor(C1FGridResult, iImageRow, GridStyleName.StyleLink)

			Case LinkFromTo.LinkTo
				'リンク終り
				C1FGridMokuji(iRow, "リンクTO") = strFileName

		End Select

		NextMokuji(C1FGridMokuji)

	End Sub

	''' <summary>
	''' リンクを削除する
	''' </summary>
	''' <param name="C1FGridResult">ファイルリストのグリッド</param>
	''' <param name="C1FGridMokuji">目次部のグリッド</param>
	''' <param name="LinkPlace">リンク始めかリンク終りを指定</param>
	Public Sub DelLink(ByVal C1FGridResult As C1FlexGrid, ByVal C1FGridMokuji As C1FlexGrid, ByVal LinkPlace As LinkFromTo)

		'現在行のリンクを削除
		Dim iRow As Integer = C1FGridMokuji.Row

		Select Case LinkPlace
			Case LinkFromTo.LinkFrom
				'リンク始め
				'リンクがNULLだった場合、処理を抜ける
				If IsNull(C1FGridMokuji(iRow, "リンク")) Then
					Exit Sub
				End If
				'対象のファイル名をファイルリストから検索してリンクフラグを取り下げる
				Dim iIndex As Integer = C1FGridResult.FindRow(C1FGridMokuji(iRow, "リンク"), 1, 1, False)

				C1FGridResult(iIndex, "リンク") = False
				ChangeBackColor(C1FGridResult, iIndex, GridStyleName.StyleDefault)
				'目次部のリンク設定を削除する
				C1FGridMokuji(iRow, "リンク") = ""

			Case LinkFromTo.LinkTo
				'リンク終り
				C1FGridMokuji(iRow, "リンクTO") = ""

		End Select

	End Sub

	Public Sub ViewFlagInfo(ByVal C1FG As C1FlexGrid, ByVal iManageID As Integer)

		Dim strSQL As String = ""
		Dim sqlProcess As New SQLProcess

		Try
			'フラグ情報を取得
			strSQL = "SELECT T3.種別, T1.ファイル名, T1.レコード番号, T2.フラグ, T2.種別ID, ISNULL(T1.管理者確認, 0) AS 確認 "
			strSQL &= "FROM T_フラグ AS T1 INNER JOIN "
			strSQL &= "M_フラグ AS T2 ON T1.種別ID = T2.種別ID AND T1.フラグID = T2.フラグID INNER JOIN "
			strSQL &= "M_種別 AS T3 ON T1.種別ID = T3.種別ID "
			strSQL &= "WHERE 管理ID = " & iManageID & " "
			strSQL &= "ORDER BY T1.種別ID, T1.連番"
			Dim dt As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
			C1FG.Rows.Count = dt.Rows.Count + 1

			Dim iRecordCount As Integer = 0
			For iRow As Integer = 0 To dt.Rows.Count - 1
				iRecordCount += 1
				C1FG(iRecordCount, "No") = iRecordCount
				C1FG(iRecordCount, "種別") = dt.Rows(iRow)("種別")
				C1FG(iRecordCount, "ファイル名") = dt.Rows(iRow)("ファイル名")
				C1FG(iRecordCount, "レコード番号") = dt.Rows(iRow)("レコード番号")
				C1FG(iRecordCount, "フラグ") = dt.Rows(iRow)("フラグ")
				C1FG(iRecordCount, "種別ID") = dt.Rows(iRow)("種別ID")
				C1FG(iRecordCount, "確認") = dt.Rows(iRow)("確認")
				'確認項目にチェックが入っていたら背景色を変える
				If C1FG(iRecordCount, "確認") = True Then
					LinkPasteProcess.ChangeBackColor(C1FG, iRecordCount, GridStyleName.StyleFinish)
				Else
					LinkPasteProcess.ChangeBackColor(C1FG, iRecordCount, GridStyleName.StyleLink)
				End If
			Next

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		Finally

			sqlProcess.Close()

		End Try

	End Sub

	''' <summary>
	''' FlexGridの背景色を変更する(1行単位)
	''' </summary>
	''' <param name="iRow"></param>
	''' <param name="iGridStyleName"></param>
	''' <remarks></remarks>
	Public Sub ChangeBackColor(ByVal C1FG As C1FlexGrid, ByVal iRow As Integer, ByVal iGridStyleName As GridStyleName)
		'カスタムスタイルを作成する
		With C1FG
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
			'完了スタイル
			.Styles.Add("StyleFinish")
			.Styles("StyleFinish").BackColor = Color.LightSkyBlue
			.Styles("StyleFinish").ForeColor = Color.Black
		End With

		Select Case iGridStyleName

			Case GridStyleName.StyleDefault
				'デフォルト
				C1FG.Rows(iRow).Style = C1FG.Styles("StyleDefault")

			Case GridStyleName.StyleTarget
				'目次
				C1FG.Rows(iRow).Style = C1FG.Styles("StyleTarget")

			Case GridStyleName.StyleLink
				'リンク
				C1FG.Rows(iRow).Style = C1FG.Styles("StyleLink")

			Case GridStyleName.StyleFinish
				'完了
				C1FG.Rows(iRow).Style = C1FG.Styles("StyleFinish")
		End Select

	End Sub

	''' <summary>
	''' 単一セルの背景色を変更する
	''' </summary>
	''' <param name="C1FG"></param>
	''' <param name="iRow"></param>
	''' <param name="iCol"></param>
	''' <param name="iGridStyleName"></param>
	Public Sub ChangeCellBackColor(ByVal C1FG As C1FlexGrid, ByVal iRow As Integer, ByVal iCol As Integer, ByVal iGridStyleName As GridStyleName)
		'カスタムスタイルを作成する
		'デフォルトスタイル
		Dim styleDefault As C1.Win.C1FlexGrid.CellStyle = C1FG.Styles.Add("CellStyleDefault")
		styleDefault.BackColor = Color.White
		styleDefault.ForeColor = Color.Black
		'目次スタイル
		Dim styleTarget As C1.Win.C1FlexGrid.CellStyle = C1FG.Styles.Add("CellStyleTarget")
		styleTarget.BackColor = Color.LightSlateGray
		styleTarget.ForeColor = Color.Black
		'リンクスタイル
		Dim styleLink As C1.Win.C1FlexGrid.CellStyle = C1FG.Styles.Add("CellStyleLink")
		styleLink.BackColor = Color.LightCoral
		styleLink.ForeColor = Color.Black
		'完了スタイル
		Dim styleFinish As C1.Win.C1FlexGrid.CellStyle = C1FG.Styles.Add("CellStyleFinish")
		styleFinish.BackColor = Color.LightSkyBlue
		styleFinish.ForeColor = Color.Black
		'編集後スタイル
		Dim styleUpdate As C1.Win.C1FlexGrid.CellStyle = C1FG.Styles.Add("CellStyleUpdate")
		styleUpdate.BackColor = Color.MediumTurquoise
		styleUpdate.ForeColor = Color.Black
		'相違スタイル
		Dim styleDifference As C1.Win.C1FlexGrid.CellStyle = C1FG.Styles.Add("CellStyleDifference")
		styleDifference.BackColor = Color.White
		styleDifference.ForeColor = Color.Red

		Select Case iGridStyleName
			Case GridStyleName.StyleDefault
				'デフォルト
				C1FG.SetCellStyle(iRow, iCol, styleDefault)

			Case GridStyleName.StyleTarget
				'ターゲット
				C1FG.SetCellStyle(iRow, iCol, styleTarget)

			Case GridStyleName.StyleLink
				'リンク
				C1FG.SetCellStyle(iRow, iCol, styleLink)

			Case GridStyleName.StyleFinish
				'完了
				C1FG.SetCellStyle(iRow, iCol, styleFinish)
			Case GridStyleName.StyleUpdate
				'編集後
				C1FG.SetCellStyle(iRow, iCol, styleUpdate)
			Case GridStyleName.StyleDifference
				'相違
				C1FG.SetCellStyle(iRow, iCol, styleDifference)

		End Select

	End Sub

	''' <summary>
	''' グリッドの連番を振り直す
	''' </summary>
	''' <param name="C1FG"></param>
	Public Sub GridRenumber(ByVal C1FG As C1FlexGrid)

		For iRow As Integer = 1 To C1FG.Rows.Count - 1
			C1FG(iRow, 0) = iRow
		Next

	End Sub

	''' <summary>
	''' 先頭画像へ
	''' </summary>
	''' <param name="C1FG"></param>
	Public Sub MoveImageTop(ByVal C1FG As C1FlexGrid)

		If C1FG.Rows.Count <= 1 Then
			'画像が1つもなかったら
			Exit Sub
		End If

		C1FG.Row = 1

	End Sub

	''' <summary>
	''' 前の画像へ
	''' </summary>
	''' <param name="C1FG"></param>
	Public Sub MoveImagePrev(ByVal C1FG As C1FlexGrid)

		If C1FG.Rows.Count <= 1 Then
			'画像が1つもなかったら
			Exit Sub
		End If

		If C1FG.Row > 1 Then
			C1FG.Row = C1FG.Row - 1
		Else
			C1FG.Row = 1
		End If

	End Sub

	''' <summary>
	''' 次の画像へ
	''' </summary>
	''' <param name="C1FG"></param>
	Public Sub MoveImageNext(ByVal C1FG As C1FlexGrid)

		If C1FG.Rows.Count <= 1 Then
			Exit Sub
		End If

		If C1FG.Row < C1FG.Rows.Count - 1 Then
			C1FG.Row = C1FG.Row + 1
		Else
			C1FG.Row = C1FG.Rows.Count - 1
		End If

	End Sub

	''' <summary>
	''' 末尾の画像へ
	''' </summary>
	''' <param name="C1FG"></param>
	Public Sub MoveImageBottom(ByVal C1FG As C1FlexGrid)

		If C1FG.Rows.Count <= 1 Then
			Exit Sub
		End If

		C1FG.Row = C1FG.Rows.Count - 1

	End Sub

	''' <summary>
	''' 目次レコードを1レコードすすめる
	''' </summary>
	''' <param name="C1FG"></param>
	Public Sub NextMokuji(ByVal C1FG As C1FlexGrid)

		If C1FG.Row = C1FG.Rows.Count - 1 Then
			'最終行だった場合何もしない
			Exit Sub
		End If

		C1FG.Row += 1

	End Sub

	''' <summary>
	''' 目次レコードを1レコード戻す
	''' </summary>
	''' <param name="C1FG"></param>
	Public Sub PrevMokuji(ByVal C1FG As C1FlexGrid)

		If C1FG.Row = 1 Then
			'先頭行だった場合何もしない
			Exit Sub
		End If

		C1FG.Row -= 1

	End Sub

#End Region

End Module
