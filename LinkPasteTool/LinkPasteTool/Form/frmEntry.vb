Imports Leadtools

Public Class frmEntry

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
                        MoveImageTop()
                        e.Handled = True

                    Case Keys.F1
                        '前画像へ
                        MoveImagePrev()
                        e.Handled = True

                    Case Keys.F2
                        '次画像へ
                        MoveImageNext()
                        e.Handled = True

                    Case Keys.F5
                        'リンク設定
                        SetLink()
                        e.Handled = True
                    Case Keys.F6
                        'リンク削除
                        DelLink()
                        e.Handled = True
                    Case Keys.F9
                        'リンクTO設定
                        SetLinkTo()
                        e.Handled = True
                    Case Keys.F10
                        'リンクTO削除
                        DelLinkTo()
                        e.Handled = True
                    Case Keys.End
                        '末尾画像へ
                        MoveImageBottom()
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

        SetLink()

    End Sub

    ''' <summary>
    ''' 目次部コンテキストメニュー[リンク削除]
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub toolDelLink_Click(sender As System.Object, e As System.EventArgs) Handles toolDelLink.Click

        DelLink()

    End Sub

    ''' <summary>
    ''' 目次部コンテキストメニュー[リンクTO設定]
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub toolSetLinkTo_Click(sender As System.Object, e As System.EventArgs) Handles toolSetLinkTo.Click

        SetLinkTo()

    End Sub

    ''' <summary>
    ''' 目次部コンテキストメニュー[リンクTO削除]
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub toolDelLinkTo_Click(sender As System.Object, e As System.EventArgs) Handles toolDelLinkTo.Click

        DelLinkTo()

    End Sub

    ''' <summary>
    ''' レコード移動後イベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub C1FGridMokuji_AfterDragRow(sender As Object, e As C1.Win.C1FlexGrid.DragRowColEventArgs) Handles C1FGridMokuji.AfterDragRow

        GridRenumber(Me.C1FGridMokuji)

    End Sub

#End Region

#Region "MenuStrip"

    ''' <summary>
    ''' [移動][先頭画像]
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub toolTop_Click(sender As Object, e As EventArgs) Handles toolTop.Click

        MoveImageTop()

    End Sub

    ''' <summary>
    ''' [移動][前画像]
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub toolPrev_Click(sender As Object, e As EventArgs) Handles toolPrev.Click

        MoveImagePrev()

    End Sub

    ''' <summary>
    ''' [移動][次画像]
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub toolNext_Click(sender As Object, e As EventArgs) Handles toolNext.Click

        MoveImageNext()

    End Sub

    ''' <summary>
    ''' [移動][最終画像]
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub toolBottom_Click(sender As Object, e As EventArgs) Handles toolBottom.Click

        MoveImageBottom()

    End Sub

    ''' <summary>
    ''' [表示][縮小]
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub toolReduction_Click(sender As Object, e As EventArgs) Handles toolReduction.Click

        Dim frm As frmMain = CType(Me.Owner, frmMain)
        frm.rivImage.ScaleFactor += 0.8F

    End Sub

    ''' <summary>
    ''' [表示][拡大]
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub toolMagnification_Click(sender As Object, e As EventArgs) Handles toolMagnification.Click

        Dim frm As frmMain = CType(Me.Owner, frmMain)
        frm.rivImage.ScaleFactor += 1.2F

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
        Else
            '選択されているレコードの上に行を挿入
            Me.C1FGridMokuji.Rows.Insert(Me.C1FGridMokuji.Row)
        End If

        GridRenumber(Me.C1FGridMokuji)

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
        Else
            '選択されているレコードの下に行を挿入
            Me.C1FGridMokuji.Rows.Insert(Me.C1FGridMokuji.Row + 1)
        End If

        GridRenumber(Me.C1FGridMokuji)

    End Sub

    ''' <summary>
    ''' [編集][リンクFROM設定]
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub menuSetLink_Click(sender As Object, e As EventArgs) Handles menuSetLink.Click

        SetLink()

    End Sub

    ''' <summary>
    ''' [編集][リンクFROM削除]
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub menuDelLink_Click(sender As Object, e As EventArgs) Handles menuDelLink.Click

        DelLink()

    End Sub

    ''' <summary>
    ''' [編集][リンクTO設定]
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub menuSetLinkTo_Click(sender As Object, e As EventArgs) Handles menuSetLinkTo.Click

        SetLinkTo()

    End Sub

    ''' <summary>
    ''' [編集][リンクTO削除]
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub menuDelLinkTo_Click(sender As Object, e As EventArgs) Handles menuDelLinkTo.Click

        DelLinkTo()

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

    ''' <summary>
    ''' FlexGridの背景色を変更する(1行単位)(目次部)
    ''' </summary>
    ''' <param name="iRow"></param>
    ''' <param name="iGridStyleName"></param>
    ''' <remarks></remarks>
    Private Sub ChangeBackColorMokuji(ByVal iRow As Integer, ByVal iGridStyleName As GridStyleName)
        'カスタムスタイルを作成する
        With C1FGridMokuji
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
                Me.C1FGridMokuji.Rows(iRow).Style = Me.C1FGridMokuji.Styles("StyleDefault")

            Case GridStyleName.StyleTarget
                '目次
                Me.C1FGridMokuji.Rows(iRow).Style = Me.C1FGridMokuji.Styles("StyleTarget")

            Case GridStyleName.StyleLink
                'リンク
                Me.C1FGridMokuji.Rows(iRow).Style = Me.C1FGridMokuji.Styles("StyleLink")

        End Select

    End Sub

    ''' <summary>
    ''' 目次部のグリッドのセルの背景色を変更する
    ''' </summary>
    ''' <param name="iRow"></param>
    ''' <param name="iCol"></param>
    ''' <param name="iGridStyleName"></param>
    Private Sub ChangeCellBackColor(ByVal iRow As Integer, ByVal iCol As Integer, ByVal iGridStyleName As GridStyleName)
        'カスタムスタイルを作成する
        Dim StyleDefault As C1.Win.C1FlexGrid.CellStyle = Me.C1FGridMokuji.Styles.Add("StyleDefault")
        StyleDefault.BackColor = Color.White
        StyleDefault.ForeColor = Color.Black
        Dim StyleLink As C1.Win.C1FlexGrid.CellStyle = Me.C1FGridMokuji.Styles.Add("StyleLink")
        StyleLink.BackColor = Color.LightCoral
        StyleLink.ForeColor = Color.Black

        Select Case iGridStyleName
            Case GridStyleName.StyleDefault
                'デフォルト
                Me.C1FGridMokuji.SetCellStyle(iRow, iCol, StyleDefault)

            Case GridStyleName.StyleLink
                'リンク
                Me.C1FGridMokuji.SetCellStyle(iRow, iCol, StyleLink)

        End Select

    End Sub

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
            Dim frmMokuji As New frmEditorMokuji
            Dim frm As frmMain = CType(Me.Owner, frmMain)
            Dim iTargetRow As Integer = 0

            Select Case iCol
                Case 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16
                    '番号1～タイトル5、備考
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
                Case 2, 3
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
            End Select

        Catch ex As Exception

            Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message)
            MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally

            sqlProcess.Close()

        End Try

    End Sub

    ''' <summary>
    ''' 連番を振り直す
    ''' </summary>
    ''' <param name="C1FGrid"></param>
    ''' <remarks></remarks>
    Private Sub GridRenumber(ByVal C1FGrid As C1.Win.C1FlexGrid.C1FlexGrid)

        For iRow As Integer = 1 To Me.C1FGridMokuji.Rows.Count - 1
            Me.C1FGridMokuji(iRow, "No") = iRow
        Next

    End Sub

    ''' <summary>
    ''' 先頭画像へ
    ''' </summary>
    Private Sub MoveImageTop()

        Dim frm As frmMain = CType(Me.Owner, frmMain)

        If frm.C1FGridResult.Rows.Count <= 1 Then
            '画像が1つもなかったら
            Exit Sub
        End If

        frm.C1FGridResult.Row = 1

    End Sub

    ''' <summary>
    ''' 前の画像へ
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub MoveImagePrev()

        Dim frm As frmMain = CType(Me.Owner, frmMain)

        If frm.C1FGridResult.Rows.Count <= 1 Then
            Exit Sub
        End If

        If frm.C1FGridResult.Row > 1 Then
            frm.C1FGridResult.Row = frm.C1FGridResult.Row - 1
        Else
            frm.C1FGridResult.Row = 1
        End If

    End Sub

    ''' <summary>
    ''' 次の画像へ
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub MoveImageNext()

        'Dim frm As frmMain = My.Forms.frmMain
        Dim frm As frmMain = CType(Me.Owner, frmMain)

        If frm.C1FGridResult.Rows.Count <= 1 Then
            Exit Sub
        End If

        If frm.C1FGridResult.Row < frm.C1FGridResult.Rows.Count - 1 Then
            frm.C1FGridResult.Row = frm.C1FGridResult.Row + 1
        Else
            frm.C1FGridResult.Row = frm.C1FGridResult.Rows.Count - 1
        End If

    End Sub

    ''' <summary>
    ''' 末尾の画像へ
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub MoveImageBottom()

        Dim frm As frmMain = CType(Me.Owner, frmMain)

        If frm.C1FGridResult.Rows.Count <= 1 Then
            Exit Sub
        End If

        frm.C1FGridResult.Row = frm.C1FGridResult.Rows.Count - 1

    End Sub

    ''' <summary>
    ''' リンクを設定する
    ''' </summary>
    Private Sub SetLink()

        Dim frm As frmMain = CType(Me.Owner, frmMain)
        '今現在選択されているファイル名をリンク部分にセットする
        Dim iIndex As Integer = 0

        Dim iRow As Integer = Me.C1FGridMokuji.Row
        Dim iTargetRow As Integer = 0

        If IsNull(Me.C1FGridMokuji(iRow, "リンク")) Then
            Me.C1FGridMokuji(iRow, "リンク") = frm.C1FGridResult(frm.C1FGridResult.Row, "ファイル名")
            'リンクTOにも同様の値をセットする
            Me.C1FGridMokuji(iRow, "リンクTO") = frm.C1FGridResult(frm.C1FGridResult.Row, "ファイル名")
        Else
            'NULLでなかったらファイルリストのリンクフラグを取り下げる
            iIndex = frm.C1FGridResult.FindRow(Me.C1FGridMokuji(iRow, "リンク"), 1, 1, False)
            frm.C1FGridResult(iIndex, "リンク") = False
            ChangeBackColor(iIndex, GridStyleName.StyleDefault)
            Me.C1FGridMokuji(iRow, "リンク") = frm.C1FGridResult(frm.C1FGridResult.Row, "ファイル名")
            'リンクTOにも同様の値をセットする
            Me.C1FGridMokuji(iRow, "リンクTO") = frm.C1FGridResult(frm.C1FGridResult.Row, "ファイル名")
        End If

        iIndex = frm.C1FGridResult.FindRow(Me.C1FGridMokuji(iRow, "リンク"), 1, 1, False)
        frm.C1FGridResult(iIndex, "リンク") = True

        ChangeBackColor(iIndex, GridStyleName.StyleLink)

        '目次の行を1レコードすすめる
        NextMokuji()

    End Sub

    ''' <summary>
    ''' リンクを削除する
    ''' </summary>
    Private Sub DelLink()

        ''2017/03/22
        ''2次の場合は機能させない
        'If LinkProcess = 2 Then
        '    MessageBox.Show("2次処理はリンク終端の編集のみ可能です", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    Exit Sub
        'End If
        Dim frm As frmMain = CType(Me.Owner, frmMain)

        '現在行のリンク項目を削除
        Dim iRow As Integer = Me.C1FGridMokuji.Row
        'リンクがNULLだった場合、処理を抜ける
        If IsNull(Me.C1FGridMokuji(iRow, "リンク")) Then
            Exit Sub
        End If
        Dim iIndex As Integer = frm.C1FGridResult.FindRow(Me.C1FGridMokuji(iRow, "リンク"), 1, 1, False)
        frm.C1FGridResult(iIndex, "リンク") = False
        ChangeBackColor(iIndex, GridStyleName.StyleDefault)
        Me.C1FGridMokuji(iRow, "リンク") = ""

        'FlashingGrid()

    End Sub

    ''' <summary>
    ''' リンク終りをセットする
    ''' </summary>
    Private Sub SetLinkTo()

        Dim frm As frmMain = CType(Me.Owner, frmMain)
        Dim iRow As Integer = Me.C1FGridMokuji.Row
        Me.C1FGridMokuji(iRow, "リンクTO") = frm.C1FGridResult(frm.C1FGridResult.Row, "ファイル名")

    End Sub

    ''' <summary>
    ''' リンク終りを削除する
    ''' </summary>
    Private Sub DelLinkTo()

        Dim iRow As Integer = Me.C1FGridMokuji.Row
        Me.C1FGridMokuji(iRow, "リンクTO") = ""

    End Sub

    ''' <summary>
    ''' 次の目次タイトルを選択する
    ''' </summary>
    Private Sub NextMokuji()

        If Me.C1FGridMokuji.Row = Me.C1FGridMokuji.Rows.Count - 1 Then
            '最終行だった場合何もしない
            Exit Sub
        End If

        Me.C1FGridMokuji.Row += 1

    End Sub

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