Imports System.Security.Permissions

Public Class frmBCRead

#Region "パブリック変数"
    'SQL定義(SQLサーバー)
    Public strSQL_SER As String = ""
    Public sqlProcess_SER As New SQLProcess
#End Region
#Region "プライベート変数"
    Private CloseEnable As Boolean = True
    Private Lot As String = ""
    Private Enum DocuTypes
        ラベル
        封筒
        対象者一覧
        保健指導対象者名簿
        判定票
        リーフレット
    End Enum

    Private LabelQR As String = ""
    Private CompanyCode As String = ""
    Private OfficeCode As String = ""
    Private EnvelopeNo As String = ""
    Private EnvelopeTotal As String = ""

#End Region
#Region "フォームイベント"
    ''' <summary>
    ''' フォームロード時
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub frmMain_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Text = My.Application.Info.ProductName.ToString & " Ver." & _
        My.Application.Info.Version.ToString

        ' カスタムスタイルを追加
        Me.fgrLabel.Styles.Add("Doing")
        Me.fgrLabel.Styles("Doing").BackColor = Color.LightYellow
        Me.fgrLabel.Styles.Add("Done")
        Me.fgrLabel.Styles("Done").BackColor = Color.LightGray
        Me.fgrBCRead.Styles.Add("Done")
        Me.fgrBCRead.Styles("Done").BackColor = Color.LightGray

        Me.prgLot.Style = ProgressBarStyle.Continuous

        ComboBoxUpdate()
        Me.txtScan.Focus()
        StartMethod(False)
    End Sub

    ''' <summary>
    ''' フォームクローズ時
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub frmBCRead_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If CloseEnable = False Then
            MessageBox.Show("ロットを終了させてください", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            e.Cancel = True
        ElseIf MessageBox.Show("終了します。" & vbNewLine & "よろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
            e.Cancel = True
        End If
    End Sub
    ''' <summary>
    ''' キー操作
    ''' </summary>
    ''' <param name="keyData"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected Overrides Function ProcessDialogKey(keyData As Keys) As Boolean
        'Returnキーが押されているか調べる
        'AltかCtrlキーが押されている時は、本来の動作をさせる
        If ((keyData And Keys.KeyCode) = Keys.Return) AndAlso _
            ((keyData And (Keys.Alt Or Keys.Control)) = Keys.None) Then
            'Tabキーを押した時と同じ動作をさせる
            'Shiftキーが押されている時は、逆順にする
            Me.ProcessTabKey((keyData And Keys.Shift) <> Keys.Shift)
            '本来の処理はさせない
            Return True
        End If

        Return MyBase.ProcessDialogKey(keyData)
    End Function

    ''' <summary>
    ''' ショートカットキーイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub frmMain_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.F12
                btnStart.PerformClick()
        End Select
    End Sub

    ''' <summary>
    ''' SQL設定フォームがとじたとき
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Form2_FormClosed(sender As Object, e As FormClosedEventArgs)
        Dim f2 As frmSQLSetting = DirectCast(sender, frmSQLSetting)
        ComboBoxUpdate()
        Me.txtScan.Focus()

    End Sub
#End Region
#Region "オブジェクトイベント"

    ''' <summary>
    ''' SQL接続設定ボタン
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnSQL_Click(sender As System.Object, e As System.EventArgs) Handles btnSQL.Click
        'Form2を作成する
        Dim f2 As New frmSQLSetting()
        'FormClosedイベントハンドラを追加
        AddHandler f2.FormClosed, AddressOf Form2_FormClosed
        '.NET Framework 1.1以前では、Closedイベントを使う
        'AddHandler f2.Closed, AddressOf Form2_Closed
        '表示する
        f2.Show()
    End Sub

    ''' <summary>
    ''' 開始ボタン
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnStart_Click(sender As System.Object, e As System.EventArgs) Handles btnStart.Click
        If Me.cmbLotSelect.Text = "" Then
            MessageBox.Show("ロットが選択されていません", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        If MessageBox.Show("ロット" & Me.cmbLotSelect.Text & "の読取を開始します" & vbNewLine & "よろしいですか。", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
            StartMethod(True)
        End If
        Me.txtScan.Focus()
    End Sub
    ''' <summary>
    ''' 終了ボタン
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnClear_Click(sender As System.Object, e As System.EventArgs) Handles btnEnd.Click
        If Me.fgrBCRead.Rows.Count > 1 Then
            Dim NextRow As Integer = Me.fgrBCRead.FindRow(0, 1, 4, True, True, False)
            If NextRow < 0 Then
                Confirm(True)
                StartMethod(False)
            Else
                If MessageBox.Show("最後まで読み取られていない封筒の値は破棄されます。" & vbNewLine & "よろしいですか。", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                    StartMethod(False)
                End If
            End If
        Else
            StartMethod(False)
        End If

        Me.txtScan.Focus()
    End Sub

    ''' <summary>
    ''' BC読み取り時
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub txtScan_Validating(sender As System.Object, e As System.ComponentModel.CancelEventArgs) Handles txtScan.Validating
        If Not IsNull(Me.txtScan.Text) Then
            'QRコード
            Dim QR As String = Me.txtScan.Text
            'QR桁数
            Dim QRLength As Integer = Me.txtScan.TextLength
            '帳票種別
            Dim DocuType As Integer = 0
            'CD
            Dim CD As Integer = QR.Substring(QRLength - 1)
            'CD生成値
            Dim returnCD As Integer = 0
            'CD抜きQRコード
            Dim QR_withoutCD As String = QR.Substring(0, QRLength - 1)

            '次の突合レコード
            Dim NextRow As Integer = Me.fgrBCRead.FindRow(0, 1, 4, True, True, False)

            '2017/07/13
            'Ritsuki Asanuma
            'チェックデジットを撤廃する(システムID、所属事業所コード内にアルファベットが混在していたため)
            'ラベル、対象者一覧、保健指導名簿＝13～15桁(所属事業所コードが4～6桁で可変となったため)
            '桁数で判断
            Select Case QRLength

                Case 17, 18
                    '判定票、リーフレット
                    DocuType = QR.Substring(15, 1)

                Case Else
                    'ラベル、対象者一覧、保健指導名簿
                    DocuType = QR.Substring(4, 1)

            End Select

            ''桁数で判別
            'Select Case QRLength
            '    Case 16
            '        DocuType = QR.Substring(10, 1)
            '        If CheckDigit.Modulus10(QR_withoutCD, DocuType, returnCD) = True Then
            '            If returnCD <> CD Then
            '                MessageBox.Show("CDエラーです。" & vbNewLine & "再度QRコードを読み込んで下さい(" & returnCD & ")", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error)
            '                Me.txtScan.Text = ""
            '                Me.txtScan.Focus()
            '                Exit Sub
            '            End If
            '        Else
            '            MessageBox.Show("CDエラーです。" & vbNewLine & "再度QRコードを読み込んで下さい(" & returnCD & ")", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error)
            '            Me.txtScan.Text = ""
            '            Me.txtScan.Focus()
            '            Exit Sub

            '        End If
            '    Case 18, 19
            '        DocuType = QR.Substring(15, 1)
            '        If CheckDigit.Modulus10(QR_withoutCD, DocuType, returnCD) = True Then
            '            If returnCD <> CD Then
            '                MessageBox.Show("CDエラーです。" & vbNewLine & "再度QRコードを読み込んで下さい(" & returnCD & ")", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error)
            '                Me.txtScan.Text = ""
            '                Me.txtScan.Focus()
            '                Exit Sub
            '            End If
            '        Else
            '            MessageBox.Show("CDエラーです。" & vbNewLine & "再度QRコードを読み込んで下さい(" & returnCD & ")", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error)
            '            Me.txtScan.Text = ""
            '            Me.txtScan.Focus()
            '            Exit Sub
            '        End If
            '    Case Else
            '        MessageBox.Show("桁数エラーです。" & vbNewLine & "再度QRコードを読み込んで下さい", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error)
            '        Me.txtScan.Text = ""
            '        Me.txtScan.Focus()
            '        Exit Sub
            'End Select
            Select Case DocuType
                Case 0
                    'ラベル
                    '読み込んでいる状態でラベルを読んだ場合
                    If Me.fgrBCRead.Rows.Count > 1 Then
                        If NextRow < 0 Then
                            Confirm(True)
                            clear()
                        ElseIf NextRow > 0 Then
                            If MessageBox.Show("読み込んでいないレコードが存在します。" & "現在の情報を破棄してこのラベルを読み込みますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                                clear()
                            Else
                                Me.txtScan.Text = ""
                                Me.txtScan.Focus()
                                Exit Sub
                            End If
                        End If
                    End If

                    LabelQR = QR
                    '2017/07/13
                    'Ritsuki Asanuma
                    'コード体系変更により取得する桁数を変更する
                    CompanyCode = QR.Substring(0, 4)
                    'OfficeCode = QR.Substring(4, 6)
                    'EnvelopeNo = QR.Substring(11, 2)
                    EnvelopeNo = QR.Substring(5, 2)
                    'EnvelopeTotal = QR.Substring(13, 2)
                    EnvelopeTotal = QR.Substring(7, 2)
                    OfficeCode = QR.Substring(9)    'インデックス9から最後まで

                    '帳票カウント
                    Dim strSQL_count As String = "SELECT COUNT(*) FROM T_印刷ソート"
                    strSQL_count &= " WHERE ロットID = '" & Me.cmbLotSelect.Text & "'"
                    strSQL_count &= " AND 会社コード = '" & CompanyCode & "'"
                    strSQL_count &= " AND 所属事業所コード = '" & OfficeCode & "'"
                    strSQL_count &= " AND 印刷ID = " & CInt(EnvelopeNo)
                    strSQL_SER = strSQL_count & " AND 帳票種別ID = " & DocuTypes.対象者一覧
                    Dim ResultListCount As Integer = sqlProcess_SER.DB_EXECUTE_SCALAR(strSQL_SER)
                    strSQL_SER = strSQL_count & " AND 帳票種別ID = " & DocuTypes.判定票
                    Dim ResultCount As Integer = sqlProcess_SER.DB_EXECUTE_SCALAR(strSQL_SER)
                    strSQL_SER = strSQL_count & " AND 帳票種別ID = " & DocuTypes.保健指導対象者名簿
                    Dim LeafletListCount As Integer = sqlProcess_SER.DB_EXECUTE_SCALAR(strSQL_SER)
                    strSQL_SER = strSQL_count & " AND 帳票種別ID = " & DocuTypes.リーフレット
                    Dim LeafletCount As Integer = sqlProcess_SER.DB_EXECUTE_SCALAR(strSQL_SER)

                    strSQL_SER = strSQL_count & " AND チェックフラグ = 0"
                    Dim NotyetCount As Integer = sqlProcess_SER.DB_EXECUTE_SCALAR(strSQL_SER)

                    '封筒内レコード取得
                    strSQL_SER = "SELECT M1.帳票種別, T1.QR, T1.チェックフラグ,T2.氏名姓, T2.氏名名 FROM T_印刷ソート AS T1"
                    strSQL_SER &= " INNER JOIN M_帳票種別 AS M1 ON T1.帳票種別ID = M1.帳票種別ID"
                    strSQL_SER &= " LEFT OUTER JOIN T_判定票 AS T2 ON T1.所属事業所コード = T2.所属事業所コード"
                    strSQL_SER &= " AND T1.会社コード = T2.会社コード"
                    strSQL_SER &= " AND T1.ロットID = T2.ロットID"
                    strSQL_SER &= " AND  T1.システムID = T2.システムID"
                    strSQL_SER &= " AND T1.レコード番号 = T2.レコード番号"
                    strSQL_SER &= " WHERE T1.ロットID = '" & Me.cmbLotSelect.Text & "'"
                    strSQL_SER &= " AND T1.会社コード = '" & CompanyCode & "'"
                    strSQL_SER &= " AND T1.所属事業所コード = '" & OfficeCode & "'"
                    strSQL_SER &= " AND T1.印刷ID = " & CInt(EnvelopeNo)
                    strSQL_SER &= " AND T1.帳票種別ID != " & DocuTypes.ラベル
                    strSQL_SER &= " ORDER BY T1.帳票種別ID, T1.ページ数"
                    Dim tblDocuList As DataTable = sqlProcess_SER.DB_SELECT_DATATABLE(strSQL_SER)

                    '存在しないラベルの場合
                    If ResultListCount = 0 Then
                        MessageBox.Show("該当ロット内に存在しないラベルです。" & vbNewLine & "管理者に報告してください。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Me.txtScan.Text = ""
                        Me.txtScan.Focus()
                        Exit Sub
                    End If

                    Me.lblTotal_rl.Text = ResultListCount
                    Me.lblTotal_r.Text = ResultCount
                    Me.lblTotal_ll.Text = LeafletListCount
                    Me.lblTotal_l.Text = LeafletCount

                    Me.fgrBCRead.BeginUpdate()
                    For i As Integer = 0 To tblDocuList.Rows.Count - 1
                        'フレックスグリッド更新
                        Me.fgrBCRead.Rows.Count += 1
                        Dim fgrRowsCount As Integer = fgrBCRead.Rows.Count - 1
                        Me.fgrBCRead(fgrRowsCount, "No") = fgrRowsCount
                        Me.fgrBCRead(fgrRowsCount, "QRコード") = tblDocuList.Rows(i)("QR")
                        Me.fgrBCRead(fgrRowsCount, "帳票種別") = tblDocuList.Rows(i)("帳票種別")
                        If tblDocuList.Rows(i)("帳票種別") = "リーフレット" Or tblDocuList.Rows(i)("帳票種別") = "判定票" Then
                            Me.fgrBCRead(fgrRowsCount, "氏名") = tblDocuList.Rows(i)("氏名姓") & " " & tblDocuList.Rows(i)("氏名名")
                        End If
                        Me.fgrBCRead(fgrRowsCount, "読込チェック") = tblDocuList.Rows(i)("チェックフラグ")
                        If tblDocuList.Rows(i)("チェックフラグ") = 1 Then
                            Me.fgrBCRead.Rows(fgrRowsCount).Style = Me.fgrBCRead.Styles("Done")
                        End If
                    Next
                    Me.fgrBCRead.EndUpdate()

                    '列幅を最大桁にあわせる
                    Me.fgrBCRead.AutoSizeCol(0)
                    Me.fgrBCRead.AutoSizeCol(1)
                    Me.fgrBCRead.AutoSizeCol(2)
                    Me.fgrBCRead.AutoSizeCol(3)

                    LotInfoUpdate()
                    ProgressUpdate()

                    '既に読取り済みのラベルの場合
                    If NotyetCount = 0 Then
                        If MessageBox.Show("読み込み済みのラベルです。" & "データを破棄して再度読み込み直しますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                            Confirm(False)
                            Me.fgrBCRead.Rows.Count = 1
                            Me.fgrBCRead.BeginUpdate()
                            For i As Integer = 0 To tblDocuList.Rows.Count - 1
                                'フレックスグリッド更新
                                Me.fgrBCRead.Rows.Count += 1
                                Dim fgrRowsCount As Integer = fgrBCRead.Rows.Count - 1
                                Me.fgrBCRead(fgrRowsCount, "No") = fgrRowsCount
                                Me.fgrBCRead(fgrRowsCount, "QRコード") = tblDocuList.Rows(i)("QR")
                                Me.fgrBCRead(fgrRowsCount, "帳票種別") = tblDocuList.Rows(i)("帳票種別")
                                Me.fgrBCRead(fgrRowsCount, "読込チェック") = 0
                            Next
                            Me.fgrBCRead.EndUpdate()
                            LotInfoUpdate()
                            ProgressUpdate()
                        Else
                            clear()
                            Me.txtScan.Text = ""
                            Me.txtScan.Focus()
                            Exit Sub
                        End If
                    End If

                Case Else
                    'ラベル以外
                    If Me.fgrBCRead.Rows.Count = 1 Then
                        MessageBox.Show("ラベルから読み込んで下さい", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Me.txtScan.Text = ""
                        Me.txtScan.Focus()
                        Exit Sub
                    Else
                        Dim LoopFlag As Boolean = True
                        While LoopFlag = True
                            If NextRow < 0 Then

                                Me.txtScan.BackColor = Color.Red
                                PlaySound.Main()
                                If MessageBox.Show("リスト外のQRコードです" & vbNewLine & "管理者に報告し、「はい」を押下してください。", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                                    Me.txtScan.Text = ""
                                    Me.txtScan.Focus()
                                    LoopFlag = False
                                    Me.txtScan.BackColor = Color.LightYellow
                                    Exit Sub
                                End If
                            Else
                                LoopFlag = False
                            End If
                        End While


                        Dim NextQR As String = Me.fgrBCRead(NextRow, "QRコード")
                        'スクロール
                        Me.fgrBCRead.TopRow = NextRow
                        Me.fgrBCRead.Select(NextRow, 0)



                        '読み込んだQRとリストを突合する。
                        If NextQR = Me.txtScan.Text Then
                            Me.fgrBCRead(NextRow, "読込チェック") = 1
                            Me.fgrBCRead.Rows(NextRow).Style = Me.fgrBCRead.Styles("Done")
                            System.Windows.Forms.Application.DoEvents()
                            Select Case DocuType
                                Case 2
                                    Me.lblCount_rl.Text = CInt(Me.lblCount_rl.Text) + 1
                                Case 3
                                    Me.lblCount_ll.Text = CInt(Me.lblCount_ll.Text) + 1
                                Case 4
                                    Me.lblCount_r.Text = CInt(Me.lblCount_r.Text) + 1
                                Case 5
                                    Me.lblCount_l.Text = CInt(Me.lblCount_l.Text) + 1
                            End Select
                        Else
                            Me.txtScan.BackColor = Color.Red
                            PlaySound.Main()

                            LoopFlag = True
                            While LoopFlag = True
                                If MessageBox.Show("リストと一致しないQRコードです" & vbNewLine & "管理者に報告し、「はい」を押下してください。", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                                    Me.txtScan.Text = ""
                                    Me.txtScan.Focus()
                                    LoopFlag = False
                                    Me.txtScan.BackColor = Color.LightYellow
                                    Exit Sub
                                End If
                            End While
                        End If
                    End If
            End Select
            Me.txtScan.Text = ""
            Me.txtScan.Focus()
        End If
    End Sub

#End Region
#Region "プライベートメソッド"
    ''' <summary>
    ''' ロット開始・終了
    ''' </summary>
    ''' <param name="StartEnd"></param>
    ''' <remarks></remarks>
    Private Sub StartMethod(ByVal StartEnd As Boolean)
        'txtScanフォーム/終了ボタンを有効化
        Me.txtScan.Enabled = StartEnd
        Me.btnEnd.Enabled = StartEnd
        'cmbLotSelect/開始ボタンを無効化
        Me.cmbLotSelect.Enabled = Not StartEnd
        Me.btnStart.Enabled = Not StartEnd
        CloseEnable = Not StartEnd
        Me.btnSQL.Enabled = Not StartEnd
        Lot = Me.cmbLotSelect.Text

        If StartEnd = False Then
            Me.txtScan.BackColor = Color.LightGray
            Me.fgrLabel.Rows.Count = 1
            Me.txtLotProgress.Text = "0/0"
            Me.txtLabelProgress.Text = "0/0"

            Me.prgLot.Maximum = 0
            Me.prgLot.Minimum = 0
            Me.prgLot.Value = 0

            Me.prgLabel.Maximum = 0
            Me.prgLabel.Minimum = 0
            Me.prgLabel.Value = 0
        Else
            Me.txtScan.BackColor = Color.LightYellow
            ProgressUpdate()
            LotInfoUpdate()
        End If
        clear()
    End Sub
    ''' <summary>
    ''' DB書込み
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Confirm(ByVal chkFlag As Boolean)
        strSQL_SER = "UPDATE T_印刷ソート"
        If chkFlag = True Then
            strSQL_SER &= " SET チェックフラグ = 1"
        Else
            strSQL_SER &= " SET チェックフラグ = 0"
        End If
        strSQL_SER &= " WHERE ロットID = '" & Me.cmbLotSelect.Text & "'"
        strSQL_SER &= " AND 会社コード = '" & CompanyCode & "'"
        strSQL_SER &= " AND 所属事業所コード = '" & OfficeCode & "'"
        strSQL_SER &= " AND 印刷ID = " & CInt(EnvelopeNo)
        Try
            sqlProcess_SER.DB_UPDATE(strSQL_SER)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "SQLエラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    ''' <summary>
    ''' ラベル情報クリア
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub clear()
        '封筒情報初期化
        Me.lblCount_rl.Text = 0
        Me.lblCount_r.Text = 0
        Me.lblCount_ll.Text = 0
        Me.lblCount_l.Text = 0
        Me.lblTotal_l.Text = 0
        Me.lblTotal_ll.Text = 0
        Me.lblTotal_r.Text = 0
        Me.lblTotal_rl.Text = 0
        Me.fgrBCRead.Rows.Count = 1
        LabelQR = ""
        CompanyCode = ""
        OfficeCode = ""
        EnvelopeNo = ""
        EnvelopeTotal = ""
    End Sub
    ''' <summary>
    ''' ロット内情報更新
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LotInfoUpdate()
        'ロット内ラベル情報取得
        strSQL_SER = "SELECT T1.チェックフラグ,T1.QR, M1.会社名, M1.局所名, T1.印刷ID, T2.重量ヘッダ"
        strSQL_SER &= " FROM T_印刷ソート AS T1"
        strSQL_SER &= " INNER JOIN M_局所 AS M1 ON T1.会社コード = M1.会社コード"
        strSQL_SER &= " AND T1.所属事業所コード = M1.局所コード"
        strSQL_SER &= " INNER JOIN T_印刷管理 AS T2 ON T1.ロットID = T2.ロットID"
        strSQL_SER &= " AND T1.会社コード = T2.会社コード"
        strSQL_SER &= " AND T1.所属事業所コード = T2.所属事業所コード"
        strSQL_SER &= " AND T1.印刷ID = T2.印刷ID"
        strSQL_SER &= " WHERE (T1.ロットID = '" & Lot & "')"
        strSQL_SER &= " AND (T1.帳票種別ID = " & DocuTypes.ラベル & ")"
        strSQL_SER &= " GROUP BY T1.チェックフラグ,T1.QR, M1.会社名, M1.局所名, T1.印刷ID, T2.重量ヘッダ,T2.ラベル連番"
        strSQL_SER &= " ORDER BY T2.ラベル連番"
        '↑ラベル内件数をソート規則に入れる
        Dim tblLabelList As DataTable = sqlProcess_SER.DB_SELECT_DATATABLE(strSQL_SER)

        Me.fgrLabel.Rows.Count = 1
        Me.fgrLabel.BeginUpdate()
        For i As Integer = 0 To tblLabelList.Rows.Count - 1
            'フレックスグリッド更新
            Me.fgrLabel.Rows.Count += 1
            Dim fgrRowsCount As Integer = fgrLabel.Rows.Count - 1
            Me.fgrLabel(fgrRowsCount, "No") = fgrRowsCount
            Me.fgrLabel(fgrRowsCount, "chk") = tblLabelList.Rows(i)("チェックフラグ")
            Me.fgrLabel(fgrRowsCount, "QRコード") = tblLabelList.Rows(i)("QR")
            Me.fgrLabel(fgrRowsCount, "重量") = tblLabelList.Rows(i)("重量ヘッダ")
            Me.fgrLabel(fgrRowsCount, "会社名") = tblLabelList.Rows(i)("会社名")
            Me.fgrLabel(fgrRowsCount, "事業所名") = tblLabelList.Rows(i)("局所名")
            Me.fgrLabel(fgrRowsCount, "印刷ID") = tblLabelList.Rows(i)("印刷ID")

            '読み込み中のラベル
            If tblLabelList.Rows(i)("QR") = LabelQR Then
                Me.fgrLabel.Rows(fgrRowsCount).Style = Me.fgrLabel.Styles("Doing")
            End If
            '終了した封筒
            If IIf(tblLabelList.Rows(i)("チェックフラグ") Is DBNull.Value, 0, tblLabelList.Rows(i)("チェックフラグ")) = 1 Then
                Me.fgrLabel.Rows(fgrRowsCount).Style = Me.fgrLabel.Styles("Done")
            End If

        Next
        Me.fgrLabel.EndUpdate()
        '列幅を最大桁にあわせる
        Me.fgrLabel.AutoSizeCol(0)
        Me.fgrLabel.AutoSizeCol(1)
        Me.fgrLabel.AutoSizeCol(2)
        Me.fgrLabel.AutoSizeCol(3)
        Me.fgrLabel.AutoSizeCol(4)
        Me.fgrLabel.AutoSizeCol(5)
        Me.fgrLabel.AutoSizeCol(6)
        'スクロール
        Dim LabelRow As Integer = Me.fgrLabel.FindRow(LabelQR, 1, 2, True, True, False)
        Me.fgrLabel.TopRow = LabelRow
        Me.fgrLabel.Select(LabelRow, 0)
    End Sub
    ''' <summary>
    ''' 進捗更新
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ProgressUpdate()
        strSQL_SER = "SELECT SUM(チェックフラグ) AS 完了件数,"
        strSQL_SER &= " COUNT(*) AS 総件数,"
        strSQL_SER &= " SUM(CASE WHEN 帳票種別ID = 0 AND チェックフラグ = 1 THEN 1 ELSE 0 END) AS 完了通数,"
        strSQL_SER &= " SUM(CASE WHEN 帳票種別ID = 0 THEN 1 ELSE 0 END) AS 総通数"
        strSQL_SER &= " FROM T_印刷ソート"
        strSQL_SER &= " WHERE ロットID = '" & Lot & "'"
        Dim tblProgress As DataTable = sqlProcess_SER.DB_SELECT_DATATABLE(strSQL_SER)

        Dim DoneLabel As Integer = CInt(IIf(tblProgress.Rows(0)("完了通数") Is DBNull.Value, 0, tblProgress.Rows(0)("完了通数")))
        Dim SumLabel As Integer = CInt(IIf(tblProgress.Rows(0)("総通数") Is DBNull.Value, 0, tblProgress.Rows(0)("総通数")))
        Dim DoneDoc As Integer = CInt(IIf(tblProgress.Rows(0)("完了件数") Is DBNull.Value, 0, tblProgress.Rows(0)("完了件数")))
        Dim SumDoc As Integer = CInt(IIf(tblProgress.Rows(0)("総件数") Is DBNull.Value, 0, tblProgress.Rows(0)("総件数")))

        Me.txtLotProgress.Text = DoneLabel & "/" & SumLabel
        Me.txtLabelProgress.Text = DoneDoc & "/" & SumDoc

        Me.prgLot.Maximum = SumLabel
        Me.prgLot.Minimum = 0
        Me.prgLot.Value = DoneLabel

        Me.prgLabel.Maximum = SumDoc
        Me.prgLabel.Minimum = 0
        Me.prgLabel.Value = DoneDoc

    End Sub

    ''' <summary>
    ''' ロット選択用コンボボックスの更新
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ComboBoxUpdate()
        Try
            'コンボボックスにロット情報を入力
            strSQL_SER = "SELECT ロットID FROM T_印刷ソート"
            strSQL_SER &= " GROUP BY ロットID"
            strSQL_SER &= " ORDER BY ロットID DESC"
            Dim dtLot As DataTable = sqlProcess_SER.DB_SELECT_DATATABLE(strSQL_SER)
            For i As Integer = 0 To dtLot.Rows.Count - 1
                'strSQL_SER = "SELECT COUNT(*) AS 件数"
                'strSQL_SER &= " FROM T_印刷ソート AS T1"
                'strSQL_SER &= " WHERE (T1.ロットID = '" & Lot & "')"
                'strSQL_SER &= " AND (T1.帳票種別ID = " & DocuTypes.ラベル & ")"
                'strSQL_SER &= " AND T1.チェックフラグ = 1"
                'Dim doneLabel As Integer = sqlProcess_SER.DB_EXECUTE_SCALAR(strSQL_SER)

                Me.cmbLotSelect.Items.Add(dtLot.Rows(i)("ロットID"))
            Next
            Me.cmbLotSelect.SelectedIndex = 0
        Catch ex As Exception
            MessageBox.Show(ex.Message, "SQLエラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
#End Region

End Class
