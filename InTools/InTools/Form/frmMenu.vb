Public Class frmMenu
#Region "フォームイベント"
    ''' <summary>
    ''' ロード時
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub frmMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = My.Application.Info.ProductName.ToString & " Ver." & My.Application.Info.Version.ToString

        'Me.btnScanLogChk.Region = New Region(RoundEdge(btnScanLogChk, 20))
        'Me.btnRemove.Region = New Region(RoundEdge(btnRemove, 20))
        'Me.btnRecovery.Region = New Region(RoundEdge(btnRecovery, 20))
        'Me.btnAlibi.Region = New Region(RoundEdge(btnAlibi, 20))
        'Me.btnConvert.Region = New Region(RoundEdge(btnConvert, 20))
        'Me.btnFlag.Region = New Region(RoundEdge(btnFlag, 20))
        'Me.btnRename.Region = New Region(RoundEdge(btnRename, 20))
        'Me.btnDisk.Region = New Region(RoundEdge(btnDisk, 20))
        'Me.btnOpenCheck.Region = New Region(RoundEdge(btnOpenCheck, 20))

        Me.fgrMenu.Styles.Add("Normal")
        Me.fgrMenu.Styles("Normal").Margins.Left = 20
        Me.fgrMenu.Cols(0).Style = Me.fgrMenu.Styles("Normal")

        Me.fgrMenu.Styles.Add("MouseOver")
        'Me.fgrMenu.Styles("MouseOver").BackColor = Color.FromArgb(&HB7, &HDB, &HFF)
        Me.fgrMenu.Styles("MouseOver").BackColor = Color.White
        Me.fgrMenu.Styles("MouseOver").ForeColor = Color.Black

        Me.fgrMenu.SetCellImage(0, 0, My.Resources.GetPath)
        Me.fgrMenu.SetCellImage(1, 0, My.Resources.Inspection)
        Me.fgrMenu.SetCellImage(2, 0, My.Resources.Recover)
        Me.fgrMenu.SetCellImage(3, 0, My.Resources.barcode)
        Me.fgrMenu.SetCellImage(4, 0, CreateGrayscaleImage(My.Resources.rotate))
        Me.fgrMenu.SetCellImage(5, 0, My.Resources.Replace)
        Me.fgrMenu.SetCellImage(6, 0, My.Resources.convert)
        Me.fgrMenu.SetCellImage(7, 0, CreateGrayscaleImage(My.Resources.entry))
        Me.fgrMenu.SetCellImage(8, 0, CreateGrayscaleImage(My.Resources.Rename))
        Me.fgrMenu.SetCellImage(9, 0, My.Resources.DiskMaker_ICON)
        Me.fgrMenu.SetCellImage(10, 0, My.Resources.Check)

        Me.fgrMenu.Rows(0)(0) = "  " & "パス取得" & " ver." & My.Settings.Ver_GetPath
        Me.fgrMenu.Rows(1)(0) = "  " & "スキャンログ検査" & " ver." & My.Settings.Ver_ScanLogChk
        Me.fgrMenu.Rows(2)(0) = "  " & "リカバリー" & " ver." & My.Settings.Ver_Recovery
        Me.fgrMenu.Rows(3)(0) = "  " & "BC読取" & " ver." & My.Settings.Ver_BCRead
        Me.fgrMenu.Rows(4)(0) = "  " & "回転・白紙削除" & " ver." & My.Settings.Ver_Rotate
        Me.fgrMenu.Rows(5)(0) = "  " & "アリバイ発行・差し替え" & " ver." & My.Settings.Ver_Replace
        Me.fgrMenu.Rows(6)(0) = "  " & "画像変換" & " ver." & My.Settings.Ver_Convert
        Me.fgrMenu.Rows(7)(0) = "  " & "エントリー" & " ver." & My.Settings.Ver_Entry
        Me.fgrMenu.Rows(8)(0) = "  " & "リネーム" & " ver." & My.Settings.Ver_Rename
        Me.fgrMenu.Rows(9)(0) = "  " & "ディスク振り分け" & " ver." & My.Settings.Ver_Disk
        Me.fgrMenu.Rows(10)(0) = "  " & "画像情報出力" & " ver." & My.Settings.Ver_OpenCheck

        '更新履歴を取得
        Me.fgrChangeLog.Styles.Normal.WordWrap = True
        Dim lines As String() = My.Resources.更新履歴.Split(vbCrLf)
        For i As Integer = 0 To lines.Count - 1
            Me.fgrChangeLog.Rows.Count += 1
            Me.fgrChangeLog.Rows(i)(0) = lines(i).Replace(vbLf, "")
        Next

    End Sub

    ''' <summary>
    ''' クローズ時
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub frmMenu_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Application.Exit()
    End Sub
#End Region
#Region "オブジェクトイベント"
    Private Sub fgrMenu_MouseHover(sender As Object, e As EventArgs) Handles fgrMenu.MouseHover, fgrChangeLog.MouseHover
        Dim FlexGrid As C1.Win.C1FlexGrid.C1FlexGrid = CType(sender, C1.Win.C1FlexGrid.C1FlexGrid)
        FlexGrid.Focus()
    End Sub

    Private Sub flex_MouseEnterCell(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.RowColEventArgs) Handles fgrMenu.MouseEnterCell
        ' セル内にマウスポインタが入ればスタイルを設定
        Me.fgrMenu.SetCellStyle(e.Row, e.Col, fgrMenu.Styles("MouseOver"))
    End Sub
    Private Sub flex_MouseLeaveCell(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.RowColEventArgs) Handles fgrMenu.MouseLeaveCell
        ' セルから出た際にスタイルを削除
        Me.fgrMenu.SetCellStyle(e.Row, e.Col, CType(Nothing, C1.Win.C1FlexGrid.CellStyle))
    End Sub

    ''' <summary>
    ''' グリッドクリック時
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub fgrMenu_Click(sender As Object, e As EventArgs) Handles fgrMenu.Click
        Select Case Me.fgrMenu.Row
            Case 0
                Dim f As New frmGetPath
                f.Show()
                Me.Hide()
            Case 1

                '二重起動をチェックする
                If Diagnostics.Process.GetProcessesByName("変換").Length > 1 Then
                    'すでに起動していると判断して終了
                    MessageBox.Show("多重起動はできません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End If

                Dim f As New frmScanLogChk
                f.Show()
                Me.Hide()
            Case 2
                Dim f As New frmRecovery
                f.Show()
                Me.Hide()
            Case 3
                Dim f As New frmBCRead
                f.Show()
                Me.Hide()
            Case 4
                'Dim f As New frmRemove
                'f.Show()
                'Me.Hide()
            Case 5
                Dim f As New frmAlibi
                f.Show()
                Me.Hide()
            Case 6
                Dim f As New frmConverter
                f.Show()
                Me.Hide()
            Case 7
                'Dim f As New 
                'f.Show()
                'Me.Hide()
            Case 8
                'Dim f As New frmRename
                'f.Show()
                'Me.Hide()
            Case 9
                Dim f As New frmDisk
                f.Show()
                Me.Hide()
            Case 10
                Dim f As New frmOpenCheck
                f.Show()
                Me.Hide()
        End Select
    End Sub

    ''' <summary>
    ''' 接続設定
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub C1Command1_Click_1(sender As Object, e As C1.Win.C1Command.ClickEventArgs) Handles C1Command1.Click
        Dim f As New frmSQLSetting()
        AddHandler f.FormClosed, AddressOf Connect_FormClosed
        f.Show()
    End Sub
    ''' <summary>
    ''' SQL設定フォームがとじたとき
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Connect_FormClosed(sender As Object, e As FormClosedEventArgs)
        Dim f As frmSQLSetting = DirectCast(sender, frmSQLSetting)
    End Sub
#End Region
#Region "プライベートメソッド"
    ''' <summary>
    ''' 角丸
    ''' </summary>
    ''' <param name="Button"></param>
    ''' <returns></returns>
    Private Function RoundEdge(ByVal Button As Button, ByVal Round As Integer) As Drawing2D.GraphicsPath
        Dim p As New Drawing2D.GraphicsPath

        p.StartFigure()
        p.AddArc(New Rectangle(0, 0, Round, Round), 180, 90)
        p.AddLine(Round, 0, Button.Width - Round, 0)
        p.AddArc(New Rectangle(Button.Width - Round, 0, Round, Round), -90, 90)
        p.AddLine(Button.Width, Round, Button.Width, Button.Height - Round)
        p.AddArc(New Rectangle(Button.Width - Round, Button.Height - Round, Round, Round), 0, 90)
        p.AddLine(Button.Width - Round, Button.Height, Round, Button.Height)
        p.AddArc(New Rectangle(0, Button.Height - Round, Round, Round), 90, 90)

        p.CloseFigure()
        Return p
    End Function

    ''' <summary>
    ''' 指定した画像からグレースケール画像を作成する
    ''' </summary>
    ''' <param name="img">基の画像</param>
    ''' <returns>作成されたグレースケール画像</returns>
    Public Shared Function CreateGrayscaleImage(ByVal img As Image) As Image
        'グレースケールの描画先となるImageオブジェクトを作成
        Dim newImg As New Bitmap(img.Width, img.Height)
        'newImgのGraphicsオブジェクトを取得
        Dim g As Graphics = Graphics.FromImage(newImg)

        'ColorMatrixオブジェクトの作成
        'グレースケールに変換するための行列を指定する
        Dim cm As New System.Drawing.Imaging.ColorMatrix(New Single()() _
            {New Single() {0.3086F, 0.3086F, 0.3086F, 0, 0},
             New Single() {0.6094F, 0.6094F, 0.6094F, 0, 0},
             New Single() {0.082F, 0.082F, 0.082F, 0, 0},
             New Single() {0, 0, 0, 1, 0},
             New Single() {0, 0, 0, 0, 1}})
        'ImageAttributesオブジェクトの作成
        Dim ia As New System.Drawing.Imaging.ImageAttributes()
        'ColorMatrixを設定する
        ia.SetColorMatrix(cm)

        'ImageAttributesを使用してグレースケールを描画
        g.DrawImage(img, New Rectangle(0, 0, img.Width, img.Height),
                    0, 0, img.Width, img.Height, GraphicsUnit.Pixel, ia)

        'リソースを解放する
        g.Dispose()

        Return newImg
    End Function
#End Region

End Class