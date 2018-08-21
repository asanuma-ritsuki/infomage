Imports Leadtools

Public Class frmEntry

#Region "プライベート変数"

	'''' <summary>
	'''' スタイル列挙体
	'''' </summary>
	'''' <remarks></remarks>
	'Friend Enum GridStyleName
	'    StyleDefault
	'    StyleTarget
	'    StyleLink
	'End Enum

	'Private frm As frmMain = CType(Me.Owner, frmMain)

#End Region

#Region "フォームイベント"

	''' <summary>
	''' フォームロード時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub frmEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.Text = My.Application.Info.ProductName.ToString & " Ver." &
            My.Application.Info.Version.ToString & " - [エントリ]"
        Me.CaptionDisplayMode = StatusDisplayMode.None

        XmlSettings.LoadFromXmlFile()
        Me.Left = XmlSettings.Instance.LocEntryX
        Me.Top = XmlSettings.Instance.LocEntryY
        Me.Width = XmlSettings.Instance.SizeEntryX
        Me.Height = XmlSettings.Instance.SizeEntryY

    End Sub

    ''' <summary>
    ''' フォームキーダウン時
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub frmEntry_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown, C1FGridMokuji.KeyDown

		Dim frm As frmMain = CType(Me.Owner, frmMain)

		Try
            'どの修飾キー(Shift、Ctrl、Alt)が押されているか
            If (Control.ModifierKeys And Keys.Shift) = Keys.Shift Then
                'Shiftキー

            ElseIf (Control.ModifierKeys And Keys.Control) = Keys.Control Then
                'Ctrlキー
                Select Case e.KeyCode

                    Case Keys.F

                        frm.rivImage.ScaleFactor = 1.0F
                        'frm.rivImage.SizeMode = RasterPaintSizeMode.Fit

                    Case Keys.Add
                        '拡大
                        frm.rivImage.ScaleFactor *= 1.2F

                    Case Keys.Subtract
                        '縮小
                        frm.rivImage.ScaleFactor *= 0.8F

                End Select

            ElseIf (Control.ModifierKeys And Keys.Alt) = Keys.Alt Then
                'Alt

            Else

                Select Case e.KeyCode

                    Case Keys.Enter
                        '項目移動 Enterキー
                        'ボタン上では無効
                        If TypeOf Me.ActiveControl Is Button Then
                            Exit Select
                        End If

                        Dim forward As Boolean = e.Modifiers <> Keys.Shift
                        Me.SelectNextControl(Me.ActiveControl, forward, True, True, True)

                        e.Handled = True

                    Case Keys.Home
						'先頭画像へ
						LinkPasteProcess.MoveImageTop(frm.C1FGridResult)
						e.Handled = True

                    Case Keys.F1
						'前画像へ
						LinkPasteProcess.MoveImagePrev(frm.C1FGridResult)
						e.Handled = True

                    Case Keys.F2
						'次画像へ
						LinkPasteProcess.MoveImageNext(frm.C1FGridResult)
						e.Handled = True

                    Case Keys.F5
						'リンク設定
						LinkPasteProcess.SetLink(frm.C1FGridResult, Me.C1FGridMokuji, LinkFromTo.LinkFrom)
						'SetLink()
						e.Handled = True
                    Case Keys.F6
						'リンク削除
						LinkPasteProcess.DelLink(frm.C1FGridResult, Me.C1FGridMokuji, LinkFromTo.LinkFrom)
						'DelLink()
						e.Handled = True
                    Case Keys.F9
						'リンクTO設定
						LinkPasteProcess.SetLink(frm.C1FGridResult, Me.C1FGridMokuji, LinkFromTo.LinkTo)
						'SetLinkTo()
						e.Handled = True
                    Case Keys.F10
						'リンクTO削除
						LinkPasteProcess.DelLink(frm.C1FGridResult, Me.C1FGridMokuji, LinkFromTo.LinkTo)
						'DelLinkTo()
						e.Handled = True
                    Case Keys.End
						'末尾画像へ
						LinkPasteProcess.MoveImageBottom(frm.C1FGridResult)
						e.Handled = True
                    Case Keys.Up
						'目次のカーソルを1レコード戻す
						LinkPasteProcess.PrevMokuji(Me.C1FGridMokuji)
						e.Handled = True
                    Case Keys.Down
						'目次のカーソルを1レコードすすめる
						LinkPasteProcess.NextMokuji(Me.C1FGridMokuji)
						e.Handled = True
                End Select

            End If

        Catch ex As Exception

            Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message)
            MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    ''' <summary>
    ''' フォームクロージング時
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub frmEntry_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

        XmlSettings.LoadFromXmlFile()
        If Me.WindowState = FormWindowState.Normal Then
            'ウィンドウ状態：通常
            XmlSettings.Instance.LocEntryX = Me.Left
            XmlSettings.Instance.LocEntryY = Me.Top
            XmlSettings.Instance.SizeEntryX = Me.Width
            XmlSettings.Instance.SizeEntryY = Me.Height
        Else
            'ウィンドウ状態：最大化または最小化
            XmlSettings.Instance.LocEntryX = Me.RestoreBounds.Left
            XmlSettings.Instance.LocEntryY = Me.RestoreBounds.Top
            XmlSettings.Instance.SizeEntryX = Me.RestoreBounds.Width
            XmlSettings.Instance.SizeEntryY = Me.RestoreBounds.Height
        End If
        XmlSettings.Instance.State = Me.WindowState

        XmlSettings.SaveToXmlFile()

    End Sub

#End Region

#Region "オブジェクトイベント"

    ''' <summary>
    ''' 目次部グリッドダブルクリック時
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub C1FGridMokuji_DoubleClick(sender As System.Object, e As System.EventArgs) Handles C1FGridMokuji.DoubleClick

        If Me.C1FGridMokuji.Row < 1 Then
            Exit Sub
        End If

		ViewEditorMokuji()
		Dim frm As frmMain = CType(Me.Owner, frmMain)
		LinkPasteProcess.ViewFlagInfo(frm.C1FGridFlag, CInt(frm.cmbBookletID.SelectedValue))

	End Sub

    ''' <summary>
    ''' 目次部グリッドキーダウン時
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub C1FGridMokuji_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles C1FGridMokuji.KeyDown
        'Enterキーのみ補足
        If e.KeyCode <> Keys.Enter Then
            Exit Sub
        End If

        ViewEditorMokuji()

    End Sub

    ''' <summary>
    ''' 目次部グリッドのマウスクリック前
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub C1FGridMokuji_BeforeMouseDown(sender As System.Object, e As C1.Win.C1FlexGrid.BeforeMouseDownEventArgs) Handles C1FGridMokuji.BeforeMouseDown

        '右クリック時
        If e.Button = MouseButtons.Right Then
            'クリックされた位置を取得
            Dim h As C1.Win.C1FlexGrid.HitTestInfo
            h = Me.C1FGridMokuji.HitTest(e.X, e.Y)
            'カレントセルを移動
            If h.Row < 1 Or h.Column < 1 Then
                '行列どちらかが0より少ない場合
                Me.toolSetLink.Enabled = False
                Me.toolDelLink.Enabled = False
                Me.toolSetLinkTo.Enabled = False
                Me.toolDelLinkTo.Enabled = False
                Exit Sub
            Else
                Me.C1FGridMokuji.Row = h.Row
                Me.C1FGridMokuji.Col = h.Column
                Me.toolSetLink.Enabled = True
                Me.toolDelLink.Enabled = True
                Me.toolSetLinkTo.Enabled = True
                Me.toolDelLinkTo.Enabled = True
            End If

        End If

    End Sub

#End Region


#Region "ContextMenu"

    ''' <summary>
    ''' 目次部コンテキストメニュー[リンク設定]
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub toolSetLink_Click(sender As System.Object, e As System.EventArgs) Handles toolSetLink.Click

		Dim frm As frmMain = CType(Me.Owner, frmMain)
		LinkPasteProcess.SetLink(frm.C1FGridResult, Me.C1FGridMokuji, LinkFromTo.LinkFrom)
		'SetLink()

	End Sub

    ''' <summary>
    ''' 目次部コンテキストメニュー[リンク削除]
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub toolDelLink_Click(sender As System.Object, e As System.EventArgs) Handles toolDelLink.Click

		Dim frm As frmMain = CType(Me.Owner, frmMain)
		LinkPasteProcess.DelLink(frm.C1FGridResult, Me.C1FGridMokuji, LinkFromTo.LinkFrom)
		'DelLink()

	End Sub

    ''' <summary>
    ''' 目次部コンテキストメニュー[リンクTO設定]
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub toolSetLinkTo_Click(sender As System.Object, e As System.EventArgs) Handles toolSetLinkTo.Click

		Dim frm As frmMain = CType(Me.Owner, frmMain)
		LinkPasteProcess.SetLink(frm.C1FGridResult, Me.C1FGridMokuji, LinkFromTo.LinkTo)
		'SetLinkTo()

	End Sub

    ''' <summary>
    ''' 目次部コンテキストメニュー[リンクTO削除]
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub toolDelLinkTo_Click(sender As System.Object, e As System.EventArgs) Handles toolDelLinkTo.Click

		Dim frm As frmMain = CType(Me.Owner, frmMain)
		LinkPasteProcess.DelLink(frm.C1FGridResult, Me.C1FGridMokuji, LinkFromTo.LinkTo)
		'DelLinkTo()

	End Sub

    ''' <summary>
    ''' レコード移動後イベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub C1FGridMokuji_AfterDragRow(sender As Object, e As C1.Win.C1FlexGrid.DragRowColEventArgs) Handles C1FGridMokuji.AfterDragRow

		LinkPasteProcess.GridRenumber(Me.C1FGridMokuji)

	End Sub

	''' <summary>
	''' 目次部グリッドのセル変更時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub C1FGridMokuji_EnterCell(sender As Object, e As EventArgs) Handles C1FGridMokuji.EnterCell

		If Me.C1FGridMokuji.Rows.Count <= 1 Then
			Exit Sub
		End If

		Dim frm As frmMain = CType(Me.Owner, frmMain)
		Dim iRow As Integer = Me.C1FGridMokuji.Row
		'MessageBox.Show(Me.C1FGridMokuji(iRow, "表示用"))
		frm.C1FGridDoc(1, "No") = 1
		frm.C1FGridDoc(1, "項目名") = "表示用"
		frm.C1FGridDoc(1, "内容") = Me.C1FGridMokuji(iRow, "表示用")

		frm.C1FGridDoc(2, "No") = 2
		frm.C1FGridDoc(2, "項目名") = "県名"
		frm.C1FGridDoc(2, "内容") = Me.C1FGridMokuji(iRow, "県名")

		frm.C1FGridDoc(3, "No") = 3
		frm.C1FGridDoc(3, "項目名") = "資料名"
		frm.C1FGridDoc(3, "内容") = Me.C1FGridMokuji(iRow, "資料名")

		frm.C1FGridDoc(4, "No") = 4
		frm.C1FGridDoc(4, "項目名") = "副題"
		frm.C1FGridDoc(4, "内容") = Me.C1FGridMokuji(iRow, "副題")

		frm.C1FGridDoc(5, "No") = 5
		frm.C1FGridDoc(5, "項目名") = "対象年"
		frm.C1FGridDoc(5, "内容") = Me.C1FGridMokuji(iRow, "対象年")

		frm.C1FGridDoc(6, "No") = 6
		frm.C1FGridDoc(6, "項目名") = "刊行者名"
		frm.C1FGridDoc(6, "内容") = Me.C1FGridMokuji(iRow, "刊行者名")

		frm.C1FGridDoc(7, "No") = 7
		frm.C1FGridDoc(7, "項目名") = "刊行年月"
		frm.C1FGridDoc(7, "内容") = Me.C1FGridMokuji(iRow, "刊行年月")

		'元データの読込
		Dim strSQL As String = ""
		Dim sqlProcess As New SQLProcess

		Try
			Me.C1FGridOriginal.Rows.Count = 1
			If IsNull(Me.C1FGridMokuji(iRow, "レコード番号")) Then
				Exit Sub
			End If
			strSQL = "SELECT 分類番号, 項目, 番号1, タイトル1, 番号2, タイトル2, 番号3, タイトル3, 番号4, タイトル4, 番号5, タイトル5 "
			strSQL &= "FROM T_目次比較 "
			strSQL &= "WHERE レコード番号 = '" & Me.C1FGridMokuji(iRow, "レコード番号") & "'"
			Dim dt As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
			If dt.Rows.Count = 0 Then
				Exit Sub
			End If

			Me.C1FGridOriginal.Rows.Count = 13

			Me.C1FGridOriginal(1, "No") = 1
			Me.C1FGridOriginal(1, "項目名") = "番号"
			Me.C1FGridOriginal(1, "内容") = dt.Rows(0)("分類番号")

			Me.C1FGridOriginal(2, "No") = 2
			Me.C1FGridOriginal(2, "項目名") = "項目"
			Me.C1FGridOriginal(2, "内容") = dt.Rows(0)("項目")

			Me.C1FGridOriginal(3, "No") = 3
			Me.C1FGridOriginal(3, "項目名") = "番号1"
			Me.C1FGridOriginal(3, "内容") = dt.Rows(0)("番号1")
			Me.C1FGridOriginal(4, "No") = 4
			Me.C1FGridOriginal(4, "項目名") = "タイトル1"
			Me.C1FGridOriginal(4, "内容") = dt.Rows(0)("タイトル1")

			Me.C1FGridOriginal(5, "No") = 5
			Me.C1FGridOriginal(5, "項目名") = "番号2"
			Me.C1FGridOriginal(5, "内容") = dt.Rows(0)("番号2")
			Me.C1FGridOriginal(6, "No") = 6
			Me.C1FGridOriginal(6, "項目名") = "タイトル2"
			Me.C1FGridOriginal(6, "内容") = dt.Rows(0)("タイトル2")

			Me.C1FGridOriginal(7, "No") = 7
			Me.C1FGridOriginal(7, "項目名") = "番号3"
			Me.C1FGridOriginal(7, "内容") = dt.Rows(0)("番号3")
			Me.C1FGridOriginal(8, "No") = 8
			Me.C1FGridOriginal(8, "項目名") = "タイトル3"
			Me.C1FGridOriginal(8, "内容") = dt.Rows(0)("タイトル3")

			Me.C1FGridOriginal(9, "No") = 9
			Me.C1FGridOriginal(9, "項目名") = "番号4"
			Me.C1FGridOriginal(9, "内容") = dt.Rows(0)("番号4")
			Me.C1FGridOriginal(10, "No") = 10
			Me.C1FGridOriginal(10, "項目名") = "タイトル4"
			Me.C1FGridOriginal(10, "内容") = dt.Rows(0)("タイトル4")

			Me.C1FGridOriginal(11, "No") = 11
			Me.C1FGridOriginal(11, "項目名") = "番号5"
			Me.C1FGridOriginal(11, "内容") = dt.Rows(0)("番号5")
			Me.C1FGridOriginal(12, "No") = 12
			Me.C1FGridOriginal(12, "項目名") = "タイトル5"
			Me.C1FGridOriginal(12, "内容") = dt.Rows(0)("タイトル5")

		Catch ex As Exception

			Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message)
			MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

		Finally

			sqlProcess.Close()

		End Try
	End Sub


#End Region

#Region "MenuStrip"

	''' <summary>
	''' [移動][先頭画像]
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub toolTop_Click(sender As Object, e As EventArgs) Handles toolTop.Click

		Dim frm As frmMain = CType(Me.Owner, frmMain)
		LinkPasteProcess.MoveImageTop(frm.C1FGridResult)

	End Sub

    ''' <summary>
    ''' [移動][前画像]
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub toolPrev_Click(sender As Object, e As EventArgs) Handles toolPrev.Click

		Dim frm As frmMain = CType(Me.Owner, frmMain)
		LinkPasteProcess.MoveImagePrev(frm.C1FGridResult)

	End Sub

    ''' <summary>
    ''' [移動][次画像]
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub toolNext_Click(sender As Object, e As EventArgs) Handles toolNext.Click

		Dim frm As frmMain = CType(Me.Owner, frmMain)
		LinkPasteProcess.MoveImageNext(frm.C1FGridResult)

	End Sub

    ''' <summary>
    ''' [移動][最終画像]
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub toolBottom_Click(sender As Object, e As EventArgs) Handles toolBottom.Click

		Dim frm As frmMain = CType(Me.Owner, frmMain)
		LinkPasteProcess.MoveImageBottom(frm.C1FGridResult)

	End Sub

    ''' <summary>
    ''' [表示][縮小]
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub toolReduction_Click(sender As Object, e As EventArgs) Handles toolReduction.Click

		Dim frm As frmMain = CType(Me.Owner, frmMain)
		frm.rivImage.ScaleFactor *= 0.8F

    End Sub

    ''' <summary>
    ''' [表示][拡大]
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub toolMagnification_Click(sender As Object, e As EventArgs) Handles toolMagnification.Click

		Dim frm As frmMain = CType(Me.Owner, frmMain)
		frm.rivImage.ScaleFactor *= 1.2F

    End Sub

    ''' <summary>
    ''' [表示][フィット]
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub toolFit_Click(sender As Object, e As EventArgs) Handles toolFit.Click

		Dim frm As frmMain = CType(Me.Owner, frmMain)
		frm.rivImage.ScaleFactor = 1.0F
        frm.rivImage.SizeMode = RasterPaintSizeMode.Fit

    End Sub

    ''' <summary>
    ''' [編集][行の挿入]
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub toolInsert_Click(sender As Object, e As EventArgs) Handles toolInsert.Click

        If Me.C1FGridMokuji.Rows.Count = 1 Then
            '1レコードもデータがない場合は追加
            Me.C1FGridMokuji.Rows.Count = 2
            Me.C1FGridMokuji.Select(1, 1)
			'追加フラグを立てる
			Me.C1FGridMokuji(1, "フラグID") = 4
			Me.C1FGridMokuji(1, "フラグ") = "追加"
			Me.C1FGridMokuji(1, "備考") = "4.追加"
			LinkPasteProcess.ChangeBackColor(Me.C1FGridMokuji, 1, LinkPasteProcess.GridStyleName.StyleTarget)
			'ChangeBackColorMokuji(1, GridStyleName.StyleTarget)
		Else
			'選択されているレコードの上に行を挿入
			Me.C1FGridMokuji.Rows.Insert(Me.C1FGridMokuji.Row)
			'追加フラグを立てる
			Me.C1FGridMokuji(Me.C1FGridMokuji.Row - 1, "フラグID") = 4
			Me.C1FGridMokuji(Me.C1FGridMokuji.Row - 1, "フラグ") = "追加"
			Me.C1FGridMokuji(Me.C1FGridMokuji.Row - 1, "備考") = "4.追加"
			LinkPasteProcess.ChangeBackColor(Me.C1FGridMokuji, Me.C1FGridMokuji.Row - 1, LinkPasteProcess.GridStyleName.StyleTarget)
			'ChangeBackColorMokuji(Me.C1FGridMokuji.Row - 1, GridStyleName.StyleTarget)
		End If

		LinkPasteProcess.GridRenumber(Me.C1FGridMokuji)

	End Sub

    ''' <summary>
    ''' [編集][行の追加]
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub toolAdd_Click(sender As Object, e As EventArgs) Handles toolAdd.Click

        If Me.C1FGridMokuji.Rows.Count = 1 Then
            '1レコードもデータがない場合は追加
            Me.C1FGridMokuji.Rows.Count = 2
            Me.C1FGridMokuji.Select(1, 1)
			'追加フラグを立てる
			Me.C1FGridMokuji(1, "フラグID") = 4
			Me.C1FGridMokuji(1, "フラグ") = "追加"
			Me.C1FGridMokuji(1, "備考") = "4.追加"
			LinkPasteProcess.ChangeBackColor(Me.C1FGridMokuji, 1, LinkPasteProcess.GridStyleName.StyleTarget)
			'ChangeBackColorMokuji(1, GridStyleName.StyleTarget)
		Else
			'選択されているレコードの下に行を挿入
			Me.C1FGridMokuji.Rows.Insert(Me.C1FGridMokuji.Row + 1)
			'追加フラグを立てる
			Me.C1FGridMokuji(Me.C1FGridMokuji.Row + 1, "フラグID") = 4
			Me.C1FGridMokuji(Me.C1FGridMokuji.Row + 1, "フラグ") = "追加"
			Me.C1FGridMokuji(Me.C1FGridMokuji.Row + 1, "備考") = "4.追加"
			LinkPasteProcess.ChangeBackColor(Me.C1FGridMokuji, Me.C1FGridMokuji.Row + 1, LinkPasteProcess.GridStyleName.StyleTarget)
			'ChangeBackColorMokuji(Me.C1FGridMokuji.Row + 1, GridStyleName.StyleTarget)
		End If

		LinkPasteProcess.GridRenumber(Me.C1FGridMokuji)

	End Sub

    ''' <summary>
    ''' [編集][リンクFROM設定]
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub menuSetLink_Click(sender As Object, e As EventArgs) Handles menuSetLink.Click

		Dim frm As frmMain = CType(Me.Owner, frmMain)
		LinkPasteProcess.SetLink(frm.C1FGridResult, Me.C1FGridMokuji, LinkFromTo.LinkFrom)
		'SetLink()

	End Sub

    ''' <summary>
    ''' [編集][リンクFROM削除]
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub menuDelLink_Click(sender As Object, e As EventArgs) Handles menuDelLink.Click

		Dim frm As frmMain = CType(Me.Owner, frmMain)
		LinkPasteProcess.DelLink(frm.C1FGridResult, Me.C1FGridMokuji, LinkFromTo.LinkFrom)
		'DelLink()

	End Sub

    ''' <summary>
    ''' [編集][リンクTO設定]
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub menuSetLinkTo_Click(sender As Object, e As EventArgs) Handles menuSetLinkTo.Click

		Dim frm As frmMain = CType(Me.Owner, frmMain)
		LinkPasteProcess.SetLink(frm.C1FGridResult, Me.C1FGridMokuji, LinkFromTo.LinkTo)
		'SetLinkTo()

	End Sub

    ''' <summary>
    ''' [編集][リンクTO削除]
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub menuDelLinkTo_Click(sender As Object, e As EventArgs) Handles menuDelLinkTo.Click

		Dim frm As frmMain = CType(Me.Owner, frmMain)
		LinkPasteProcess.DelLink(frm.C1FGridResult, Me.C1FGridMokuji, LinkFromTo.LinkTo)
		'DelLinkTo()

	End Sub

    ''' <summary>
    ''' [編集][修正]
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub toolEdit_Click(sender As Object, e As EventArgs) Handles toolEdit.Click

        If Me.C1FGridMokuji.Row < 1 Then
            Exit Sub
        End If

        ViewEditorMokuji()

    End Sub

#End Region

#Region "プライベートメソッド"

	'''' <summary>
	'''' フラグ情報をグリッドにセットする
	'''' </summary>
	'Private Sub ViewFlagInfo()

	'       Dim strSQL As String = ""
	'       Dim sqlProcess As New SQLProcess
	'       Dim frm As frmMain = CType(Me.Owner, frmMain)
	'       Dim iBookletID As Integer = CInt(frm.cmbBookletID.SelectedValue)

	'       Try
	'           'フラグ情報を取得
	'           strSQL = "SELECT T1.ファイル名, T1.レコード番号, T2.フラグ, T2.種別ID "
	'           strSQL &= "FROM T_フラグ AS T1 INNER JOIN "
	'           strSQL &= "M_フラグ AS T2 ON T1.種別ID = T2.種別ID AND T1.フラグID = T2.フラグID "
	'           strSQL &= "WHERE 管理ID = " & iBookletID
	'           Dim dt As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
	'           Dim iRecordCount As Integer = 0
	'           For iRow As Integer = 0 To dt.Rows.Count - 1
	'               iRecordCount += 1
	'               frm.C1FGridFlag.Rows.Count = iRecordCount + 1
	'               frm.C1FGridFlag(iRecordCount, "No") = iRecordCount
	'               frm.C1FGridFlag(iRecordCount, "ファイル名") = dt.Rows(iRow)("ファイル名")
	'               frm.C1FGridFlag(iRecordCount, "レコード番号") = dt.Rows(iRow)("レコード番号")
	'               frm.C1FGridFlag(iRecordCount, "フラグ") = dt.Rows(iRow)("フラグ")
	'               frm.C1FGridFlag(iRecordCount, "種別ID") = dt.Rows(iRow)("種別ID")
	'           Next

	'       Catch ex As Exception

	'           Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message)
	'           MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

	'       Finally

	'           sqlProcess.Close()

	'       End Try

	'   End Sub

	'''' <summary>
	'''' FlexGridの背景色を変更する(1行単位)(目次部)
	'''' </summary>
	'''' <param name="iRow"></param>
	'''' <param name="iGridStyleName"></param>
	'''' <remarks></remarks>
	'Private Sub ChangeBackColorMokuji(ByVal iRow As Integer, ByVal iGridStyleName As GridStyleName)
	'       'カスタムスタイルを作成する
	'       With C1FGridMokuji
	'           'デフォルトスタイル
	'           .Styles.Add("StyleDefault")
	'           .Styles("StyleDefault").BackColor = Color.White
	'           .Styles("StyleDefault").ForeColor = Color.Black
	'           '目次スタイル
	'           .Styles.Add("StyleTarget")
	'           .Styles("StyleTarget").BackColor = Color.LightSlateGray
	'           .Styles("StyleTarget").ForeColor = Color.Black
	'           'リンクスタイル
	'           .Styles.Add("StyleLink")
	'           .Styles("StyleLink").BackColor = Color.LightCoral
	'           .Styles("StyleLink").ForeColor = Color.Black

	'       End With

	'       Select Case iGridStyleName

	'           Case GridStyleName.StyleDefault
	'               'デフォルト
	'               Me.C1FGridMokuji.Rows(iRow).Style = Me.C1FGridMokuji.Styles("StyleDefault")

	'           Case GridStyleName.StyleTarget
	'               '目次
	'               Me.C1FGridMokuji.Rows(iRow).Style = Me.C1FGridMokuji.Styles("StyleTarget")

	'           Case GridStyleName.StyleLink
	'               'リンク
	'               Me.C1FGridMokuji.Rows(iRow).Style = Me.C1FGridMokuji.Styles("StyleLink")

	'       End Select

	'   End Sub

	'''' <summary>
	'''' 目次部のグリッドのセルの背景色を変更する
	'''' </summary>
	'''' <param name="iRow"></param>
	'''' <param name="iCol"></param>
	'''' <param name="iGridStyleName"></param>
	'Private Sub ChangeCellBackColor(ByVal iRow As Integer, ByVal iCol As Integer, ByVal iGridStyleName As GridStyleName)
	'       'カスタムスタイルを作成する
	'       Dim StyleDefault As C1.Win.C1FlexGrid.CellStyle = Me.C1FGridMokuji.Styles.Add("StyleDefault")
	'       StyleDefault.BackColor = Color.White
	'       StyleDefault.ForeColor = Color.Black
	'       Dim StyleLink As C1.Win.C1FlexGrid.CellStyle = Me.C1FGridMokuji.Styles.Add("StyleLink")
	'       StyleLink.BackColor = Color.LightCoral
	'       StyleLink.ForeColor = Color.Black

	'       Select Case iGridStyleName
	'           Case GridStyleName.StyleDefault
	'               'デフォルト
	'               Me.C1FGridMokuji.SetCellStyle(iRow, iCol, StyleDefault)

	'           Case GridStyleName.StyleLink
	'               'リンク
	'               Me.C1FGridMokuji.SetCellStyle(iRow, iCol, StyleLink)

	'       End Select

	'   End Sub

	''' <summary>
	''' 目次編集エディターを表示する
	''' </summary>
	Private Sub ViewEditorMokuji()

        Dim iRow As Integer = Me.C1FGridMokuji.Row
        Dim iCol As Integer = Me.C1FGridMokuji.Col

        If iRow < 1 Then
            Exit Sub
        End If

        Dim strSQL As String = ""
        Dim sqlProcess As New SQLProcess

        Try
			Dim frm As frmMain = CType(Me.Owner, frmMain)
			Dim iTargetRow As Integer = 0

            Select Case iCol
				Case 19, 21, 23, 25, 27, 29
					'項目、タイトル1～5
					Dim frmMokuji As New frmEditorMokuji
                    frmMokuji.txtItemEdit.ImeMode = ImeMode.Hiragana
                    frmMokuji.txtItemEdit.Text = Me.C1FGridMokuji(iRow, iCol)
                    frmMokuji.ShowDialog(Me)

					''2017/03/22
					''処理回次によって分岐
					'If LinkProcess = 1 Then
					'    '1次
					'    '目次タイトル、著者名編集
					'    frm.txtItemEdit.ImeMode = ImeMode.Hiragana
					'    frm.txtItemEdit.Text = Me.C1FGridMokuji(iRow, iCol)
					'    frm.ShowDialog(Me)
					'Else
					'    '1次以外は編集できないようにする
					'    '2017/03/22
					'    '2次の場合は機能させない
					'    If LinkProcess = 2 Then
					'        MessageBox.Show("2次処理はリンク終端の編集のみ可能です", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
					'        Exit Sub
					'    End If
					'End If
				Case 18, 20, 22, 24, 26, 28
					'分類番号、番号1～番号5
					Dim frmMokuji As New frmEditorMokuji
                    frmMokuji.txtItemEdit.ImeMode = ImeMode.NoControl
                    frmMokuji.txtItemEdit.Text = Me.C1FGridMokuji(iRow, iCol)
                    frmMokuji.ShowDialog(Me)

				Case 6, 7
					'リンク、リンクTO
					'リンク画像を表示する

					If IsNull(Me.C1FGridMokuji(iRow, iCol)) Then
                        Exit Sub
                    End If
                    Dim iResultIndex As Integer = frm.C1FGridResult.FindRow(Me.C1FGridMokuji(iRow, iCol), 1, 1, False)
                    frm.C1FGridResult.Row = iResultIndex
					''2次のときだけ前レコードの編集すべきセルの色を赤くする
					'If LinkProcess = 2 Then
					'    '一度全てのリンク終端のスタイルをデフォルトに戻す
					'    For i As Integer = 1 To Me.C1FGridMokuji.Rows.Count - 1
					'        ChangeCellBackColor(i, iCol + 1, GridStyleName.StyleDefault)
					'    Next
					'    '前レコードのリンク値がNULLの場合は遡って探す
					'    For i As Integer = iRow - 1 To 1 Step -1
					'        If Not IsNull(Me.C1FGridMokuji(i, "リンク")) Then
					'            iTargetRow = i
					'            Exit For
					'        End If
					'    Next
					'    'セルの色を赤色にする
					'    ChangeCellBackColor(iTargetRow, iCol + 1, GridStyleName.StyleLink)  'リンク開始の次のカラムなので＋１
					'End If
					'Case 4
					'    '2次のときだけ編集可能に
					'    If LinkProcess = 2 Then
					'        frmMokuji.txtItemEdit.ImeMode = ImeMode.NoControl
					'        frmMokuji.txtItemEdit.Text = Me.C1FGridMokuji(iRow, iCol)
					'        frmMokuji.ShowDialog(Me)
					'    End If
					'Case 5
					'    '備考
					'    frmMokuji.txtItemEdit.ImeMode = ImeMode.NoControl
					'    frmMokuji.txtItemEdit.Text = Me.C1FGridMokuji(iRow, iCol)
					'    frmMokuji.ShowDialog(Me)
				Case 30
					'備考
					'コンボボックス付きのエディターを開く
					Dim frmRemarks As New frmEditorRemarks
                    frmRemarks.txtItemEdit.ImeMode = ImeMode.Hiragana
                    frmRemarks.txtItemEdit.Text = Me.C1FGridMokuji(iRow, iCol)
                    frmRemarks.ShowDialog(Me)

            End Select

            'フラグIDに値が入っていたらレコードの背景色を変更する
            If Not CInt(Me.C1FGridMokuji(iRow, "フラグID")) = 0 And Not IsNull(Me.C1FGridMokuji(iRow, "フラグID")) Then
				LinkPasteProcess.ChangeBackColor(Me.C1FGridMokuji, iRow, LinkPasteProcess.GridStyleName.StyleTarget)
				'ChangeBackColorMokuji(iRow, GridStyleName.StyleTarget)
			Else
				LinkPasteProcess.ChangeBackColor(Me.C1FGridMokuji, iRow, LinkPasteProcess.GridStyleName.StyleDefault)
				'ChangeBackColorMokuji(iRow, GridStyleName.StyleDefault)
			End If

        Catch ex As Exception

            Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message)
            MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally

            sqlProcess.Close()

        End Try

    End Sub

	''''' <summary>
	''''' 連番を振り直す
	''''' </summary>
	''''' <param name="C1FGrid"></param>
	''''' <remarks></remarks>
	''Private Sub GridRenumber(ByVal C1FGrid As C1.Win.C1FlexGrid.C1FlexGrid)

	''    For iRow As Integer = 1 To Me.C1FGridMokuji.Rows.Count - 1
	''        Me.C1FGridMokuji(iRow, "No") = iRow
	''    Next

	''End Sub

	'''' <summary>
	'''' 先頭画像へ
	'''' </summary>
	'Private Sub MoveImageTop()

	'       Dim frm As frmMain = CType(Me.Owner, frmMain)

	'       If frm.C1FGridResult.Rows.Count <= 1 Then
	'           '画像が1つもなかったら
	'           Exit Sub
	'       End If

	'       frm.C1FGridResult.Row = 1

	'   End Sub

	'''' <summary>
	'''' 前の画像へ
	'''' </summary>
	'''' <remarks></remarks>
	'Private Sub MoveImagePrev()

	'	'Dim frm As frmMain = CType(Me.Owner, frmMain)

	'	If frm.C1FGridResult.Rows.Count <= 1 Then
	'           Exit Sub
	'       End If

	'       If frm.C1FGridResult.Row > 1 Then
	'           frm.C1FGridResult.Row = frm.C1FGridResult.Row - 1
	'       Else
	'           frm.C1FGridResult.Row = 1
	'       End If

	'   End Sub

	'   ''' <summary>
	'   ''' 次の画像へ
	'   ''' </summary>
	'   ''' <remarks></remarks>
	'   Private Sub MoveImageNext()

	'	'Dim frm As frmMain = My.Forms.frmMain
	'	'Dim frm As frmMain = CType(Me.Owner, frmMain)

	'	If frm.C1FGridResult.Rows.Count <= 1 Then
	'           Exit Sub
	'       End If

	'       If frm.C1FGridResult.Row < frm.C1FGridResult.Rows.Count - 1 Then
	'           frm.C1FGridResult.Row = frm.C1FGridResult.Row + 1
	'       Else
	'           frm.C1FGridResult.Row = frm.C1FGridResult.Rows.Count - 1
	'       End If

	'   End Sub

	'''' <summary>
	'''' 末尾の画像へ
	'''' </summary>
	'''' <remarks></remarks>
	'Private Sub MoveImageBottom()

	'	'Dim frm As frmMain = CType(Me.Owner, frmMain)

	'	If frm.C1FGridResult.Rows.Count <= 1 Then
	'           Exit Sub
	'       End If

	'       frm.C1FGridResult.Row = frm.C1FGridResult.Rows.Count - 1

	'   End Sub

	'   ''' <summary>
	'   ''' リンクを設定する
	'   ''' </summary>
	'   Private Sub SetLink()

	'	Dim frm As frmMain = CType(Me.Owner, frmMain)
	'	LinkPasteProcess.SetLink(frm.C1FGridResult, Me.C1FGridMokuji, LinkFromTo.LinkFrom)

	'	''今現在選択されているファイル名をリンク部分にセットする
	'	'Dim iIndex As Integer = 0

	'	'      Dim iRow As Integer = Me.C1FGridMokuji.Row
	'	'      Dim iTargetRow As Integer = 0

	'	''===================================================================
	'	''前レコードより数値が若い場合は警告を出す
	'	'If iRow > 1 Then
	'	'	'1レコード目はチェックしない
	'	'	'前レコードのリンク値がNULLの場合は遡ってリンクを探す
	'	'	For i As Integer = iRow - 1 To 1 Step -1
	'	'		If Not IsNull(Me.C1FGridMokuji(i, "リンク")) Then
	'	'			iTargetRow = i
	'	'			Exit For
	'	'		End If
	'	'	Next
	'	'	'If IsNull(Me.C1FGridMokuji(iRow - 1, "リンク")) Then
	'	'	'	MessageBox.Show("上から順にリンクを埋めてください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
	'	'	'	Exit Sub
	'	'	'End If
	'	'	'iTargetRowが0の場合は初回リンクとみなしてスキップする
	'	'	If iTargetRow > 0 Then
	'	'		Dim iFileNo As Integer = CInt(frm.C1FGridResult(frm.C1FGridResult.Row, "ファイル名"))  '選択されているファイル名の数値化
	'	'		Dim iBeforeLink As Integer = CInt(Me.C1FGridMokuji(iTargetRow, "リンク"))    '目次部の選択されているレコードの前のレコードのリンク番号を数値化
	'	'		If iBeforeLink > iFileNo Then
	'	'			'これからリンクを貼ろうとしている値が前レコードのリンク数値より小さかった場合、警告を出す
	'	'			MessageBox.Show("前レコードのリンクより前のファイルのリンクを貼ろうとしています" & vbNewLine & "リンクが正しいか見直してください", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning)
	'	'			'Exit Sub
	'	'		End If
	'	'	End If
	'	'End If
	'	''===================================================================

	'	''削除フラグが立っている場合はエラーとする
	'	''If frm.C1FGridResult(frm.C1FGridResult.Row, "削除") = True Then
	'	''	MessageBox.Show("削除フラグが立っているためリンクに設定できません", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
	'	''	Exit Sub
	'	''End If

	'	'If IsNull(Me.C1FGridMokuji(iRow, "リンク")) Then
	'	'          Me.C1FGridMokuji(iRow, "リンク") = frm.C1FGridResult(frm.C1FGridResult.Row, "ファイル名")
	'	'          'リンクTOにも同様の値をセットする
	'	'          Me.C1FGridMokuji(iRow, "リンクTO") = frm.C1FGridResult(frm.C1FGridResult.Row, "ファイル名")
	'	'      Else
	'	'          'NULLでなかったらファイルリストのリンクフラグを取り下げる
	'	'          iIndex = frm.C1FGridResult.FindRow(Me.C1FGridMokuji(iRow, "リンク"), 1, 1, False)
	'	'          frm.C1FGridResult(iIndex, "リンク") = False
	'	'          ChangeBackColor(iIndex, GridStyleName.StyleDefault)
	'	'          Me.C1FGridMokuji(iRow, "リンク") = frm.C1FGridResult(frm.C1FGridResult.Row, "ファイル名")
	'	'          'リンクTOにも同様の値をセットする
	'	'          Me.C1FGridMokuji(iRow, "リンクTO") = frm.C1FGridResult(frm.C1FGridResult.Row, "ファイル名")
	'	'      End If

	'	'      iIndex = frm.C1FGridResult.FindRow(Me.C1FGridMokuji(iRow, "リンク"), 1, 1, False)
	'	'      frm.C1FGridResult(iIndex, "リンク") = True

	'	'      ChangeBackColor(iIndex, GridStyleName.StyleLink)

	'	'      '目次の行を1レコードすすめる
	'	'      NextMokuji()

	'End Sub

	'''' <summary>
	'''' リンクを削除する
	'''' </summary>
	'Private Sub DelLink()

	'	''2017/03/22
	'	''2次の場合は機能させない
	'	'If LinkProcess = 2 Then
	'	'    MessageBox.Show("2次処理はリンク終端の編集のみ可能です", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
	'	'    Exit Sub
	'	'End If
	'	Dim frm As frmMain = CType(Me.Owner, frmMain)
	'	LinkPasteProcess.DelLink(frm.C1FGridResult, Me.C1FGridMokuji, LinkFromTo.LinkFrom)

	'	''現在行のリンク項目を削除
	'	'Dim iRow As Integer = Me.C1FGridMokuji.Row
	'	'      'リンクがNULLだった場合、処理を抜ける
	'	'      If IsNull(Me.C1FGridMokuji(iRow, "リンク")) Then
	'	'          Exit Sub
	'	'      End If
	'	'      Dim iIndex As Integer = frm.C1FGridResult.FindRow(Me.C1FGridMokuji(iRow, "リンク"), 1, 1, False)
	'	'      frm.C1FGridResult(iIndex, "リンク") = False
	'	'      ChangeBackColor(iIndex, GridStyleName.StyleDefault)
	'	'      Me.C1FGridMokuji(iRow, "リンク") = ""

	'	'FlashingGrid()

	'End Sub

	'''' <summary>
	'''' リンク終りをセットする
	'''' </summary>
	'Private Sub SetLinkTo()

	'	Dim frm As frmMain = CType(Me.Owner, frmMain)
	'	LinkPasteProcess.SetLink(frm.C1FGridResult, Me.C1FGridMokuji, LinkFromTo.LinkTo)

	'	'Dim iRow As Integer = Me.C1FGridMokuji.Row

	'	''削除フラグが立っている場合はエラーとする
	'	''If frm.C1FGridResult(iRow, "削除") = True Then
	'	''	MessageBox.Show("削除フラグが立っているためリンクに設定できません", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
	'	''	Exit Sub
	'	''End If

	'	'Me.C1FGridMokuji(iRow, "リンクTO") = frm.C1FGridResult(frm.C1FGridResult.Row, "ファイル名")

	'	''目次の行を1レコードすすめる
	'	'NextMokuji()

	'End Sub

	'''' <summary>
	'''' リンク終りを削除する
	'''' </summary>
	'Private Sub DelLinkTo()

	'	Dim frm As frmMain = CType(Me.Owner, frmMain)
	'	LinkPasteProcess.DelLink(frm.C1FGridResult, Me.C1FGridMokuji, LinkFromTo.LinkTo)

	'	'Dim iRow As Integer = Me.C1FGridMokuji.Row
	'	'      Me.C1FGridMokuji(iRow, "リンクTO") = ""

	'End Sub

	'''' <summary>
	'''' 次の目次タイトルを選択する
	'''' </summary>
	'Private Sub NextMokuji()

	'    If Me.C1FGridMokuji.Row = Me.C1FGridMokuji.Rows.Count - 1 Then
	'        '最終行だった場合何もしない
	'        Exit Sub
	'    End If

	'    Me.C1FGridMokuji.Row += 1

	'End Sub

	'''' <summary>
	'''' 前の目次タイトルを選択する
	'''' </summary>
	'Private Sub PrevMokuji()

	'    If Me.C1FGridMokuji.Row = 1 Then
	'        '先頭行だった場合何もしない
	'        Exit Sub
	'    End If

	'    Me.C1FGridMokuji.Row -= 1

	'End Sub

	'''' <summary>
	'''' FlexGridの背景色を変更する(1行単位)
	'''' </summary>
	'''' <param name="iRow"></param>
	'''' <param name="iGridStyleName"></param>
	'''' <remarks></remarks>
	'Private Sub ChangeBackColor(ByVal iRow As Integer, ByVal iGridStyleName As GridStyleName)

	'    Dim frm As frmMain = CType(Me.Owner, frmMain)

	'    'カスタムスタイルを作成する
	'    With frm.C1FGridResult
	'        'デフォルトスタイル
	'        .Styles.Add("StyleDefault")
	'        .Styles("StyleDefault").BackColor = Color.White
	'        .Styles("StyleDefault").ForeColor = Color.Black
	'        '目次スタイル
	'        .Styles.Add("StyleTarget")
	'        .Styles("StyleTarget").BackColor = Color.LightSlateGray
	'        .Styles("StyleTarget").ForeColor = Color.Black
	'        'リンクスタイル
	'        .Styles.Add("StyleLink")
	'        .Styles("StyleLink").BackColor = Color.LightCoral
	'        .Styles("StyleLink").ForeColor = Color.Black

	'    End With

	'    Select Case iGridStyleName

	'        Case GridStyleName.StyleDefault
	'            'デフォルト
	'            frm.C1FGridResult.Rows(iRow).Style = frm.C1FGridResult.Styles("StyleDefault")

	'        Case GridStyleName.StyleTarget
	'            '目次
	'            frm.C1FGridResult.Rows(iRow).Style = frm.C1FGridResult.Styles("StyleTarget")

	'        Case GridStyleName.StyleLink
	'            'リンク
	'            frm.C1FGridResult.Rows(iRow).Style = frm.C1FGridResult.Styles("StyleLink")

	'    End Select

	'End Sub

#End Region

End Class