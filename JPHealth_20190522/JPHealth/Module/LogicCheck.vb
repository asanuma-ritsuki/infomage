Module LogicCheck

	Public Enum ErrorCategory
		NullCheck
		NumericCheck
		SJISCheck
        ExceedCheck '文字数超過
        ImprintError = 6    '印影不備
    End Enum

	''' <summary>
	''' NULLチェック
	''' </summary>
	''' <param name="strValue">TRUE：NULL、FALSE：NULLでない</param>
	''' <returns></returns>
	Public Function NullCheck(ByVal strValue As String) As Boolean

		If IsNull(strValue) Then
			Return True
		Else
			Return False
		End If
	End Function

	''' <summary>
	''' 数値型(Double)に変換できるかチェック
	''' </summary>
	''' <param name="strValue"></param>
	''' <returns></returns>
	Public Function NumericCheck(ByVal strValue As String) As Boolean
		'Double型に変換できるか確認
		Dim d As Double
		If Not Double.TryParse(strValue, d) Then
			Return False
		Else
			Return True
		End If

	End Function

    ''' <summary>
    ''' T_判定票_不備内容にレコードを書き込む
    ''' </summary>
    ''' <param name="strImportDateTime"></param>
    ''' <param name="row"></param>
    ''' <param name="strLotID"></param>
    ''' <param name="iRecordNumber"></param>
    ''' <param param name="strColName"></param>
    ''' <param name="strCSVFile"></param>
    ''' <param name="ErrorCheck"></param>
    ''' <param name="strValue"></param>
    Public Sub WriteNoGoodRecord(ByVal strImportDateTime As String, ByVal row() As String, ByVal strLotID As String,
                                 ByVal iRecordNumber As Integer, ByVal strColName As String, ByVal strCSVFile As String,
                                 ByVal ErrorCheck As ErrorCategory, Optional ByVal strValue As String = "")

        Dim sqlProcess As New SQLProcess
        Dim strSQL As String = ""
        Dim dt As DataTable = Nothing
        XmlSettings.LoadFromXmlFile()

        Try
            '会場局名、健康管理施設名をM_局所から取得する
            strSQL = "SELECT 会場局名, 健康管理施設名 FROM M_局所 "
            strSQL &= "WHERE 会社コード = '" & row(2) & "' "
            strSQL &= "AND 局所コード = '" & row(3) & "'"
            Dim dtKyokusho As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)

            '要修正日時の更新
            strSQL = "UPDATE T_判定票管理 SET "
            strSQL &= "要修正日時 = '" & strImportDateTime & "'"
            strSQL &= ", 修正済日時 = NULL "
            strSQL &= "WHERE ロットID = '" & strLotID & "'"
            strSQL &= "AND レコード番号 = " & iRecordNumber
            sqlProcess.DB_UPDATE(strSQL)

            'データ不備レコード情報をT_判定票_不備内容に書き込む
            strSQL = "SELECT ISNULL(MAX(シーケンス), 0) + 1 FROM T_判定票_不備内容 "
            strSQL &= "WHERE ロットID = '" & strLotID & "' "
            strSQL &= "AND レコード番号 = " & iRecordNumber
            Dim iSeq As Integer = sqlProcess.DB_EXECUTE_SCALAR(strSQL)
            strSQL = "INSERT INTO T_判定票_不備内容 (ロットID, レコード番号, シーケンス, 不備種別, 会社コード, "
            strSQL &= "所属事業所コード, 健診種別, 会社, 所属事業所, 社員コード, 性別, 生年月日, "
            strSQL &= "氏名姓, 氏名名, 帳票タイプ, 採用年月日, 受診日, 会場局名, 健康管理施設名, 不備項目, 不備内容, 修正内容, インポート日時, "
            strSQL &= "CSVファイル, 修正済フラグ) VALUES("
            strSQL &= "'" & strLotID & "'"  'ロットID
            strSQL &= ", " & iRecordNumber 'レコード番号
            strSQL &= ", " & iSeq   'シーケンス
            strSQL &= ", " & ErrorCheck + 1 '不備種別(エラーカテゴリに1を足した数)
            strSQL &= ", '" & row(2) & "'"  '会社コード
            strSQL &= ", '" & row(3) & "'"  '所属事業所コード
            strSQL &= ", '" & row(16) & "'" '健診種別
            strSQL &= ", '" & row(4) & "'"  '会社
            strSQL &= ", '" & row(5) & "'"  '所属事業所
            strSQL &= ", '" & row(1) & "'"  '社員コード
            strSQL &= ", '" & row(13) & "'" '性別
            strSQL &= ", '" & row(15) & "'" '生年月日
            strSQL &= ", '" & row(11) & "'" '氏名姓
            strSQL &= ", '" & row(12) & "'" '氏名名
            strSQL &= ", ''"    '帳票タイプ(判定票の場合は常に空文字)
            strSQL &= ", '" & row(14) & "'" '採用年月日
            strSQL &= ", '" & row(17) & "'" '受診日
            'レコードが存在したら「会場局名」「健康管理施設名」をセットする
            If dtKyokusho.Rows.Count > 0 Then
                strSQL &= ", '" & dtKyokusho.Rows(0)("会場局名") & "'"  '会場局名
                strSQL &= ", '" & dtKyokusho.Rows(0)("健康管理施設名") & "'"   '健康管理施設名
            Else
                strSQL &= ", '', ''"
            End If
            strSQL &= ", '" & strColName & "'"   '不備項目(ロットID、レコード番号があるので項目名は+2する)
            Select Case ErrorCheck
                Case ErrorCategory.NullCheck
                    strSQL &= ", '" & XmlSettings.Instance.DataRequired & "'" '不備内容(必須項目)
                Case ErrorCategory.NumericCheck
                    strSQL &= ", '" & XmlSettings.Instance.DataDigit & "'" '不備内容(数値不正)
                Case ErrorCategory.SJISCheck
                    strSQL &= ", '" & strValue & "'"    '不備内容(実データを書き込む)
                Case ErrorCategory.ExceedCheck
                    strSQL &= ", '" & XmlSettings.Instance.DataExceed & "(" & strValue & ")'"   '文字数超過
            End Select
            strSQL &= ", ''"    '修正内容(デフォルト'')
            strSQL &= ", '" & strImportDateTime & "'"   'インポート日時
            strSQL &= ", '" & System.IO.Path.GetFileName(strCSVFile) & "'"    'CSVファイル
            strSQL &= ", 0)"    '修正済フラグ
            sqlProcess.DB_UPDATE(strSQL)

        Catch ex As Exception

            Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & ex.StackTrace)
            MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally

            sqlProcess.Close()

        End Try

    End Sub

    ''' <summary>
    ''' 医師の種別列挙体
    ''' </summary>
    Public Enum ImprintErrorDoctor
        SangyouDoctor = 0
        HanteiDoctor = 1
    End Enum

    ''' <summary>
    ''' 不備内容をT_判定票_不備内容テーブルに書き込む（印影不備）
    ''' </summary>
    ''' <param name="strLotID"></param>
    ''' <param name="iRecordNo"></param>
    Public Sub WriteNoGoodImprint(ByVal strLotID As String, ByVal iRecordNo As Integer, ByVal strDoctor As String, ByVal ImprintError As ImprintErrorDoctor)

        Dim strSQL As String = ""
        Dim sqlProcess As New SQLProcess
        XmlSettings.LoadFromXmlFile()

        Try
            '必要情報の取得
            strSQL = "SELECT T1.ロットID, T1.レコード番号, T1.会社コード, T1.所属事業所コード, T1.健診種別, "
            strSQL &= "T1.会社, T1.所属事業所, T1.社員コード, T1.性別, T1.生年月日, T1.氏名姓, T1.氏名名, "
            strSQL &= "T1.採用年月日, T1.受診日, T2.会場局名, T2.健康管理施設名, "
            strSQL &= "T3.インポート日時, T3.判定票CSV "
            strSQL &= "FROM T_判定票 AS T1 INNER JOIN "
            strSQL &= "M_局所 AS T2 ON T1.会社コード = T2.会社コード AND T1.所属事業所コード = T2.局所コード INNER JOIN "
            strSQL &= "T_判定票管理 AS T3 ON T1.ロットID = T3.ロットID AND T1.レコード番号 = T3.レコード番号 "
            strSQL &= "WHERE T1.ロットID = '" & strLotID & "' "
            strSQL &= "AND T1.レコード番号 = " & iRecordNo
            Dim dt As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
            'ロットID内シーケンスの取得
            strSQL = "SELECT ISNULL(MAX(シーケンス), 0) + 1 FROM T_判定票_不備内容 "
            strSQL &= "WHERE ロットID = '" & strLotID & "' "
            strSQL &= "AND レコード番号 = " & iRecordNo
            Dim iSeq As Integer = sqlProcess.DB_EXECUTE_SCALAR(strSQL)
            'T_判定票_不備内容にINSERT
            strSQL = "INSERT INTO T_判定票_不備内容(ロットID, レコード番号, シーケンス, 不備種別, 会社コード, "
            strSQL &= "所属事業所コード, 健診種別, 会社, 所属事業所, 社員コード, 性別, 生年月日, "
            strSQL &= "氏名姓, 氏名名, 帳票タイプ, 採用年月日, 受診日, 会場局名, 健康管理施設名, 不備項目, 不備内容, 修正内容, インポート日時, "
            strSQL &= "CSVファイル, 修正済フラグ) VALUES("
            strSQL &= "'" & strLotID & "'"  'ロットID
            strSQL &= ", " & iRecordNo  'レコード番号
            strSQL &= ", " & iSeq   'シーケンス
            strSQL &= ", " & ErrorCategory.ImprintError '不備種別(印影不備)
            strSQL &= ", '" & dt.Rows(0)("会社コード") & "'"
            strSQL &= ", '" & dt.Rows(0)("所属事業所コード") & "'"
            strSQL &= ", '" & dt.Rows(0)("健診種別") & "'"
            strSQL &= ", '" & dt.Rows(0)("会社") & "'"
            strSQL &= ", '" & dt.Rows(0)("所属事業所") & "'"
            strSQL &= ", '" & dt.Rows(0)("社員コード") & "'"
            strSQL &= ", '" & dt.Rows(0)("性別") & "'"
            strSQL &= ", '" & dt.Rows(0)("生年月日") & "'"
            strSQL &= ", '" & dt.Rows(0)("氏名姓") & "'"
            strSQL &= ", '" & dt.Rows(0)("氏名名") & "'"
            strSQL &= ", ''"    '帳票タイプ
            strSQL &= ", '" & dt.Rows(0)("採用年月日") & "'"
            strSQL &= ", '" & dt.Rows(0)("受診日") & "'"
            strSQL &= ", '" & dt.Rows(0)("会場局名") & "'"
            strSQL &= ", '" & dt.Rows(0)("健康管理施設名") & "'"
            '不備項目
            If ImprintError = ImprintErrorDoctor.SangyouDoctor Then
                strSQL &= ", '産業医'"
            Else
                strSQL &= ", '判定医'"
            End If
            strSQL &= ", '" & XmlSettings.Instance.ImprintError & "(" & strDoctor & ")'"    '不備内容
            strSQL &= ", '印刷対象外'"   '修正内容
            strSQL &= ", '" & dt.Rows(0)("インポート日時") & "'"
            strSQL &= ", '" & dt.Rows(0)("判定票CSV") & "'"
            strSQL &= ", 1)"    '修正済フラグ
            sqlProcess.DB_UPDATE(strSQL)

        Catch ex As Exception

            Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & ex.StackTrace)
            MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally

            sqlProcess.Close()

        End Try

    End Sub

    ''' <summary>
    ''' 不備内容をT_判定票_不備内容テーブルに書き込む（印影不備）（リーフレット用）
    ''' </summary>
    ''' <param name="strLotID"></param>
    ''' <param name="iRecordNo"></param>
    Public Sub WriteNoGoodImprintLeaflet(ByVal strLotID As String, ByVal iRecordNo As Integer, ByVal strDoctor As String, ByVal ImprintError As ImprintErrorDoctor, ByVal strListType As String)

        Dim strSQL As String = ""
        Dim sqlProcess As New SQLProcess
        XmlSettings.LoadFromXmlFile()

        Try
            '必要情報の取得
            '既に判定票の方は印影不備テーブルに移動されているため「T_判定票_印影不備」「T_判定票管理_印影不備」で検索する
            strSQL = "SELECT T1.ロットID, T1.レコード番号, T1.会社コード, T1.所属事業所コード, T1.健診種別, "
            strSQL &= "T1.会社, T1.所属事業所, T1.社員コード, T1.性別, T1.生年月日, T1.氏名姓, T1.氏名名, "
            strSQL &= "T1.採用年月日, T1.受診日, T2.会場局名, T2.健康管理施設名, "
            strSQL &= "T3.インポート日時, リーフレットCSV "
            strSQL &= "FROM T_判定票_印影不備 AS T1 INNER JOIN "
            strSQL &= "M_局所 AS T2 ON T1.会社コード = T2.会社コード AND T1.所属事業所コード = T2.局所コード INNER JOIN "
            strSQL &= "T_判定票管理_印影不備 AS T3 ON T1.ロットID = T3.ロットID AND T1.レコード番号 = T3.レコード番号 "
            strSQL &= "WHERE T1.ロットID = '" & strLotID & "' "
            strSQL &= "AND T1.レコード番号 = " & iRecordNo
            Dim dt As DataTable = sqlProcess.DB_SELECT_DATATABLE(strSQL)
            'ロットID内シーケンスの取得
            strSQL = "SELECT ISNULL(MAX(シーケンス), 0) + 1 FROM T_判定票_不備内容 "
            strSQL &= "WHERE ロットID = '" & strLotID & "' "
            strSQL &= "AND レコード番号 = " & iRecordNo
            Dim iSeq As Integer = sqlProcess.DB_EXECUTE_SCALAR(strSQL)
            'T_判定票_不備内容にINSERT
            strSQL = "INSERT INTO T_判定票_不備内容(ロットID, レコード番号, シーケンス, 不備種別, 会社コード, "
            strSQL &= "所属事業所コード, 健診種別, 会社, 所属事業所, 社員コード, 性別, 生年月日, "
            strSQL &= "氏名姓, 氏名名, 帳票タイプ, 採用年月日, 受診日, 会場局名, 健康管理施設名, 不備項目, 不備内容, 修正内容, インポート日時, "
            strSQL &= "CSVファイル, 修正済フラグ) VALUES("
            strSQL &= "'" & strLotID & "'"  'ロットID
            strSQL &= ", " & iRecordNo  'レコード番号
            strSQL &= ", " & iSeq   'シーケンス
            strSQL &= ", " & ErrorCategory.ImprintError '不備種別(印影不備)
            strSQL &= ", '" & dt.Rows(0)("会社コード") & "'"
            strSQL &= ", '" & dt.Rows(0)("所属事業所コード") & "'"
            strSQL &= ", '" & dt.Rows(0)("健診種別") & "'"
            strSQL &= ", '" & dt.Rows(0)("会社") & "'"
            strSQL &= ", '" & dt.Rows(0)("所属事業所") & "'"
            strSQL &= ", '" & dt.Rows(0)("社員コード") & "'"
            strSQL &= ", '" & dt.Rows(0)("性別") & "'"
            strSQL &= ", '" & dt.Rows(0)("生年月日") & "'"
            strSQL &= ", '" & dt.Rows(0)("氏名姓") & "'"
            strSQL &= ", '" & dt.Rows(0)("氏名名") & "'"
            strSQL &= ", '" & strListType & "'"   '帳票タイプ
            strSQL &= ", '" & dt.Rows(0)("採用年月日") & "'"
            strSQL &= ", '" & dt.Rows(0)("受診日") & "'"
            strSQL &= ", '" & dt.Rows(0)("会場局名") & "'"
            strSQL &= ", '" & dt.Rows(0)("健康管理施設名") & "'"
            '不備項目
            If ImprintError = ImprintErrorDoctor.SangyouDoctor Then
                strSQL &= ", '産業医'"
            Else
                strSQL &= ", '判定医'"
            End If
            strSQL &= ", '" & XmlSettings.Instance.ImprintError & "(" & strDoctor & ")'"    '不備内容
            strSQL &= ", '印刷対象外'"   '修正内容
            strSQL &= ", '" & dt.Rows(0)("インポート日時") & "'"
            strSQL &= ", '" & dt.Rows(0)("リーフレットCSV") & "'"
            strSQL &= ", 1)"    '修正済フラグ
            sqlProcess.DB_UPDATE(strSQL)

        Catch ex As Exception

            Call OutputLogFile("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & ex.StackTrace)
            MessageBox.Show("発生場所：" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally

            sqlProcess.Close()

        End Try

    End Sub

End Module
