Imports System.Text
Imports Microsoft.VisualBasic.FileIO

Public Class frmMain
#Region "フォームオブジェクト"
    ''' <summary>
    ''' ロード時
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = My.Application.Info.ProductName.ToString & " Ver." & My.Application.Info.Version.ToString

        Doing(False)

        Me.txtProvideData.Text = My.Settings.ParentFolder
        Me.dtpIraibi.Value = Date.Now.Date
    End Sub
    ''' <summary>
    ''' クローズ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub frmMain_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        My.Settings.ParentFolder = Me.txtParentFolder.Text
    End Sub
#End Region
#Region "オブジェクトイベント"
    ''' <summary>
    ''' ドラッグエンター
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub txtBefore_DragEnter(sender As Object, e As DragEventArgs) Handles txtParentFolder.DragEnter
        Dim strFile As String() = CType(e.Data.GetData(DataFormats.FileDrop, False), String())
        Dim txtControl As TextBox = CType(sender, TextBox)

        If System.IO.Directory.Exists(strFile(0)) Then
            'ドラッグされたデータ形式を調べ、フォルダの時はコピーとする
            e.Effect = DragDropEffects.Copy
        Else
            e.Effect = DragDropEffects.None
        End If

    End Sub

    ''' <summary>
    ''' ドラッグドロップ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub txtBefore_DragDrop(sender As Object, e As DragEventArgs) Handles txtParentFolder.DragDrop
        'コントロール内にドロップされた時実行される
        Dim strFile As String() = CType(e.Data.GetData(DataFormats.FileDrop, False), String())
        Dim txtControl As TextBox = CType(sender, TextBox)

        'フォルダが存在するか確認する
        If System.IO.Directory.Exists(strFile(0)) Then
            'フォルダが存在していたらテキストボックスに値を表示させる
            txtControl.Text = strFile(0)
        Else
            'フォルダが存在しなかったら何もしない
            MessageBox.Show("ドロップされたオブジェクトはフォルダではありません")
        End If

    End Sub

    ''' <summary>
    ''' '依頼日変更時
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub dtpIraibi_ValueChanged(sender As Object, e As EventArgs) Handles dtpIraibi.ValueChanged
        Dim WorkFolder As String = Me.dtpIraibi.Value.ToString("yyyyMMdd")
        Me.txtProvideData.Text = "00_提供データ\" & WorkFolder & "三井倉庫様提供データ.TXT"
        Me.txtIkkatsu.Text = "00_提供データ\一括登録リスト"
        Me.txtImageFolder.Text = "11_image"
        Me.txtEntryData.Text = "21_entry\出力データ\" & WorkFolder & ".csv"
        Me.txtLogFolder.Text = "zz_log"
        Me.txtOutputFolder.Text = "99_納品"
    End Sub

    ''' <summary>
    ''' 実行ボタン押下
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click
        If Not System.IO.Directory.Exists(Me.txtParentFolder.Text & "\") Then
            MessageBox.Show("親フォルダが存在しません。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If Me.dtpIraibi.Value.DayOfWeek <> 2 Or Me.dtpIraibi.Value > Date.Now.Date Then
            If MessageBox.Show("依頼日が本日以前の火曜日ではありませんがよろしいですか。", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.No Then
                Exit Sub
            End If

        End If

        Dim WorkFolder As String = Me.dtpIraibi.Value.ToString("yyyyMMdd")
        Dim ProvideFile As String = Me.txtParentFolder.Text & "\" & WorkFolder & "\" & Me.txtProvideData.Text
        Dim IkkatsuDir As String = Me.txtParentFolder.Text & "\" & WorkFolder & "\" & Me.txtIkkatsu.Text
        Dim ImageDir As String = Me.txtParentFolder.Text & "\" & WorkFolder & "\" & Me.txtImageFolder.Text
        Dim EntryFile As String = Me.txtParentFolder.Text & "\" & WorkFolder & "\" & Me.txtEntryData.Text
        Dim LogDir As String = Me.txtParentFolder.Text & "\" & WorkFolder & "\" & Me.txtLogFolder.Text
        Dim OutputDir As String = Me.txtParentFolder.Text & "\" & WorkFolder & "\" & Me.txtOutputFolder.Text

        If Not System.IO.File.Exists(ProvideFile) Then
            MessageBox.Show("提供データが存在しません。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        If Not System.IO.Directory.Exists(IkkatsuDir & "\") Then
            MessageBox.Show("一括登録フォルダが存在しません。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        If Not System.IO.Directory.Exists(ImageDir & "\") Then
            MessageBox.Show("イメージフォルダが存在しません。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        If Not System.IO.Directory.Exists(LogDir & "\") Then
            MessageBox.Show("ログ出力フォルダが存在しません。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        If Not System.IO.Directory.Exists(OutputDir & "\") Then
            MessageBox.Show("イメージ出力フォルダが存在しません。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If


        Doing(True)

        'イメージパス取得
        Dim Extensions As String() = New String() {"*.tif"}
        Dim files As String() = GetFilesMostDeep(ImageDir, Extensions)
        Dim strDateTime As String = System.DateTime.Now.ToString("yyyyMMddHHmmss")

        '出力フォルダ
        Dim outputFolder As String = OutputDir & "\ININJO\" & Me.dtpIraibi.Value.ToString("yyyy年M月d日")

        'カウント
        Dim fileCount As Integer = 0

        'ログ用配列
        Dim BCLog As New ArrayList
        Dim NotBCLog As New ArrayList
        Dim IkkatsuLog As New ArrayList
        Dim ChkDigitErrLog As New ArrayList

        Dim sqlProcess As New SQLProcess
        Dim strSQL As String = ""
		Try
			strSQL = "DELETE FROM T_提供データ"
			sqlProcess.DB_UPDATE(strSQL)
			strSQL = "DELETE FROM T_一括登録データ"
			sqlProcess.DB_UPDATE(strSQL)
			strSQL = "DELETE FROM T_入力データ"
			sqlProcess.DB_UPDATE(strSQL)
			strSQL = "DELETE FROM T_BC無しデータ"
			sqlProcess.DB_UPDATE(strSQL)
			'提供データ登録
			strSQL = "BULK INSERT T_提供データ"
			strSQL &= " FROM '" & ProvideFile.Replace("Y:\", "\\hydra\01_制作Gr\") & "'"
			strSQL &= " With(FIELDTERMINATOR = ',',ROWTERMINATOR = '\n')"
			sqlProcess.DB_UPDATE(strSQL)
			'エントリデータ登録
			'文字コード(ここでは、Shift JIS)
			Dim enc As System.Text.Encoding = System.Text.Encoding.GetEncoding("shift_jis")
			'行ごとの配列として、テキストファイルの中身をすべて読み込む
			Dim Rows As String() = {}
			If Not System.IO.File.Exists(EntryFile) Then
				If MessageBox.Show("エントリーデータが存在しません。" & vbNewLine & "よろしいですか？", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.No Then
					Doing(False)
					Exit Sub
				End If
			Else
				Rows = System.IO.File.ReadAllLines(EntryFile, enc)
			End If
			Dim RowCount As Integer = 0
			For i As Integer = 0 To Rows.Count - 1
				Dim Row As String = Rows(i)
				Dim splRow As String() = Row.Split(",")
				If splRow(0) = "No." Or splRow(0) = "イメージパス" Then
					Continue For
				End If
				Dim d As Double
				Dim iniCol As Integer = IIf(Double.TryParse(splRow(0), d), 1, 0)

				Dim Path As String = splRow(iniCol)
				Dim CustomerCode As String = splRow(iniCol + 1)
				Dim FileName As String = System.IO.Path.GetFileNameWithoutExtension(Path)
				RowCount += 1
				strSQL = "INSERT INTO T_BC無しデータ"
				strSQL &= " VALUES('" & RowCount & "','" & FileName & "','" & CustomerCode & "')"
				sqlProcess.DB_UPDATE(strSQL)
			Next


			Me.ProgressBar.Minimum = 0
			Me.ProgressBar.Value = 0
			Me.ProgressBar.Maximum = files.Count
			Me.lblMax.Text = Me.ProgressBar.Maximum

			For i As Integer = 0 To files.Count - 1
				fileCount += 1
				Dim FilePath As String = files(i)
				Dim FileName As String = System.IO.Path.GetFileNameWithoutExtension(FilePath)
				Dim InputData As String = FileName.Split("_")(1)
				Dim BCFlag As Boolean = IIf(InputData = "", False, True)
				If BCFlag = False Then
					'BCが無い場合InputDataをDBから取得
					strSQL = "SELECT 顧客コード FROM T_BC無しデータ"
					strSQL &= " WHERE ファイル名 = '" & FileName & "'"
					Dim dtInputData As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
					If dtInputData.Rows.Count = 0 Then
						MessageBox.Show("BCなし分の入力値が存在しません。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning)
						Exit Sub
					End If
					InputData = dtInputData.Rows(0)("顧客コード")
				End If


				Dim CustomerCode As String = EditCustomerCode(InputData)
				Dim OldCustomerCode As String = InputData.Replace("C", "").Replace("-", "")

				If OldCustomerCode.Length = 12 Then
					If OldCustomerCode <> CustomerCode Then
						ChkDigitErrLog.Add(OldCustomerCode)
						CustomerCode = OldCustomerCode
					End If
				End If

				'重複チェック
				strSQL = "SELECT COUNT(*) FROM T_入力データ"
				strSQL &= " WHERE 顧客コード = '" & CustomerCode & "'"
				Dim Edaban As Integer = sqlProcess.DB_EXECUTE_SCALAR(strSQL)


				'DB書き込み
				strSQL = "INSERT INTO T_入力データ"
				strSQL &= " VALUES('" & fileCount & "','" & CustomerCode & "','" & Edaban & "')"
				sqlProcess.DB_UPDATE(strSQL)

				'存在チェック
				strSQL = "SELECT COUNT(*) FROM T_提供データ"
				strSQL &= " WHERE 顧客コード = '" & CustomerCode & "'"
				Dim MatchCount As Integer = sqlProcess.DB_EXECUTE_SCALAR(strSQL)
				If BCFlag = True Then
					'BCあり分
					If MatchCount >= 1 Then
						BCLog.Add(CustomerCode & vbTab & CustomerCode)
					Else
						BCLog.Add(CustomerCode & vbTab & "")
					End If
				ElseIf BCFlag = False Then
					'BCなし分
					If MatchCount >= 1 Then
						NotBCLog.Add(CustomerCode & vbTab & CustomerCode)
					Else
						NotBCLog.Add(CustomerCode & vbTab & "")
					End If
				Else
					MessageBox.Show("イメージフォルダ直下は[BCあり分]と[BCなし分]フォルダのみにしてください。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
					Exit Sub
				End If

				'リネームコピー
				If Not System.IO.Directory.Exists(outputFolder) Then
					System.IO.Directory.CreateDirectory(outputFolder)
				End If
				System.IO.File.Copy(FilePath, outputFolder & "\" & CustomerCode & IIf(Edaban = 0, "", "_" & Edaban) & ".tif")

				'進捗
				Me.ProgressBar.Value = fileCount
				Me.lblValue.Text = Me.ProgressBar.Value
				System.Windows.Forms.Application.DoEvents()
			Next

			'一括登録データ登録
			Dim Ikkatsufiles As String() = GetFilesMostDeep(IkkatsuDir, {"*.txt"})
			Dim IkkatsuID As Integer = 0

			For i As Integer = 0 To Ikkatsufiles.Count - 1
				Dim FileName As String = System.IO.Path.GetFileNameWithoutExtension(Ikkatsufiles(i))
				Dim MotoCustomerCode As String = EditCustomerCode(FileName)

				Dim lines As IEnumerable(Of String) = System.IO.File.ReadLines(Ikkatsufiles(i))

				Me.ProgressBar.Minimum = 0
				Me.ProgressBar.Value = 0
				Me.ProgressBar.Maximum = lines.Count
				Me.lblMax.Text = Me.ProgressBar.Maximum
				Dim LineCount As Integer = 0

				For Each line In lines
					Dim CustomerCode As String = EditCustomerCode(line)
					Dim OldCustomerCode As String = line.Replace("C", "").Replace("-", "")

					If OldCustomerCode.Length = 12 Then
						If OldCustomerCode <> CustomerCode Then
							ChkDigitErrLog.Add(OldCustomerCode)
							CustomerCode = OldCustomerCode
						End If
					End If

					LineCount += 1
					IkkatsuID += 1

					'すでに元顧客コード内に存在しているかを確認
					strSQL = "SELECT COUNT(*) FROM T_入力データ"
					strSQL &= " WHERE 顧客コード = '" & CustomerCode & "'"
					Dim iniEdaban As Integer = sqlProcess.DB_EXECUTE_SCALAR(strSQL)

					'すでに一括データ内に存在しているかを確認
					strSQL = "SELECT COUNT(*) FROM T_一括登録データ"
					strSQL &= " WHERE 先顧客コード = '" & CustomerCode & "'"
					Dim cntEdaban As Integer = sqlProcess.DB_EXECUTE_SCALAR(strSQL) + iniEdaban

					strSQL = "INSERT INTO T_一括登録データ(ID,元顧客コード,先顧客コード,枝番)"
					strSQL &= " SELECT '" & IkkatsuID & "','" & MotoCustomerCode & "','" & CustomerCode & "','" & cntEdaban & "'"
					sqlProcess.DB_UPDATE(strSQL)
					'進捗
					Me.ProgressBar.Value = LineCount
					Me.lblValue.Text = Me.ProgressBar.Value
					System.Windows.Forms.Application.DoEvents()
				Next
			Next

			'一括登録処理
			strSQL = "SELECT T_入力データ.顧客コード,T_入力データ.枝番 AS 入力枝番, T_一括登録データ.先顧客コード, T_一括登録データ.枝番 AS 一括枝番"
			strSQL &= " FROM T_入力データ INNER JOIN T_一括登録データ"
			strSQL &= " ON T_入力データ.顧客コード =  T_一括登録データ.元顧客コード"
			Dim dtIkkatsu As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
			For iRow As Integer = 0 To dtIkkatsu.Rows.Count - 1

				'存在チェック
				strSQL = "SELECT COUNT(*) FROM T_提供データ"
				strSQL &= " WHERE 顧客コード = '" & dtIkkatsu.Rows(iRow)("先顧客コード") & "'"
				Dim MatchCount As Integer = sqlProcess.DB_EXECUTE_SCALAR(strSQL)

				If MatchCount >= 1 Then
					IkkatsuLog.Add(dtIkkatsu.Rows(iRow)("先顧客コード") & vbTab & dtIkkatsu.Rows(iRow)("先顧客コード"))
				Else
					IkkatsuLog.Add(dtIkkatsu.Rows(iRow)("先顧客コード") & vbTab & "")
				End If


				Dim srcFileName As String = dtIkkatsu.Rows(iRow)("顧客コード") & IIf(dtIkkatsu.Rows(iRow)("入力枝番") <> 0, "_" & dtIkkatsu.Rows(iRow)("入力枝番"), "") & ".tif"
				Dim dstFileName As String = dtIkkatsu.Rows(iRow)("先顧客コード") & IIf(dtIkkatsu.Rows(iRow)("一括枝番") <> 0, "_" & dtIkkatsu.Rows(iRow)("一括枝番"), "") & ".tif"

				System.IO.File.Copy(outputFolder & "\" & srcFileName, outputFolder & "\" & dstFileName)

			Next

			'ソート
			ChkDigitErrLog.Sort()
			BCLog.Sort()
			NotBCLog.Sort()
			IkkatsuLog.Sort()

			Dim chkDigitErrLogName As String = LogDir & "\チェックディジットエラー_" & strDateTime & ".txt"
			Dim BCLogName As String = LogDir & "\BCあり分_" & strDateTime & ".txt"
			Dim NotBCLogName As String = LogDir & "\BCなし分_" & strDateTime & ".txt"
			Dim IkkatsuLogName As String = LogDir & "\一括登録分_" & strDateTime & ".txt"

			For i As Integer = 0 To ChkDigitErrLog.Count - 1
				WriteLog(chkDigitErrLogName, ChkDigitErrLog(i))
			Next
			For i As Integer = 0 To BCLog.Count - 1
				WriteLog(BCLogName, BCLog(i))
			Next
			For i As Integer = 0 To NotBCLog.Count - 1
				WriteLog(NotBCLogName, NotBCLog(i))
			Next
			For i As Integer = 0 To IkkatsuLog.Count - 1
				WriteLog(IkkatsuLogName, IkkatsuLog(i))
			Next

			If ChkDigitErrLog.Count = 0 Then
				WriteLog(chkDigitErrLogName, "" & vbTab & "なし")
			End If
			If BCLog.Count = 0 Then
				WriteLog(BCLogName, "" & vbTab & "なし")
			End If
			If NotBCLog.Count = 0 Then
				WriteLog(NotBCLogName, "" & vbTab & "なし")
			End If
			If IkkatsuLog.Count = 0 Then
				WriteLog(IkkatsuLogName, "" & vbTab & "なし")
			End If

			MessageBox.Show("出力が完了しました。", "完了", MessageBoxButtons.OK, MessageBoxIcon.Information)
		Catch ex As Exception
			MessageBox.Show(ex.Message)
		Finally
			sqlProcess.Close()
		End Try

		Doing(False)
	End Sub

#End Region

#Region "プライベートメソッド"
    ''' <summary>
    ''' 実行中処理
    ''' </summary>
    Private Sub Doing(ByVal DoingFlag As Boolean)
        Me.txtParentFolder.Enabled = Not DoingFlag
        Me.dtpIraibi.Enabled = Not DoingFlag
        Me.btnStart.Enabled = Not DoingFlag
    End Sub

    ''' <summary>
    ''' ログ書き込み
    ''' </summary>
    ''' <param name="LogFileName"></param>
    ''' <param name="strWriteLog"></param>
    Private Sub WriteLog(ByVal LogFileName As String, ByVal strWriteLog As String)
        Dim sw As New System.IO.StreamWriter(LogFileName,
            True,
            System.Text.Encoding.GetEncoding("shift_jis"))
        sw.WriteLine(strWriteLog)
        '閉じる
        sw.Close()
    End Sub

    ''' <summary>
    ''' 顧客コード整形
    ''' </summary>
    ''' <param name="srcCustomerCode"></param>
    Private Function EditCustomerCode(ByVal srcCustomerCode As String) As String
        srcCustomerCode = srcCustomerCode.Replace("C", "").Replace("-", "")
        If srcCustomerCode.Length < 11 Then
            For j As Integer = 0 To 10 - srcCustomerCode.Length
                srcCustomerCode &= "0"
            Next
        End If

        'チェックデジット
        Dim Modulas11Num As String = ""
        Dim ResCheckDegit As Boolean = modulus.Modulus11(srcCustomerCode.Substring(0, 11), Modulas11Num)
        If srcCustomerCode.Length = 11 Then
            srcCustomerCode &= Modulas11Num
        End If

        Return srcCustomerCode

    End Function

#End Region

End Class
