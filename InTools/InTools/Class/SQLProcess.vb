Imports System.Data.SqlClient

Public Class SQLProcess

#Region "�p�u���b�N�錾"

    Dim con As SqlConnection
    Dim cmd As SqlCommand
    Dim dr As SqlDataReader = Nothing

#End Region

#Region "�C���X�^���X"

    ''' <summary>
    ''' �R���X�g���N�^
    ''' </summary>
    ''' <remarks></remarks>
    <System.Diagnostics.DebuggerStepThrough()> _
    Public Sub New()

        'SQLServer�ڑ��m�F
        Initialize()

    End Sub

    ''' <summary>
    ''' �f�X�g���N�^
    ''' </summary>
    ''' <remarks></remarks>
    <System.Diagnostics.DebuggerStepThrough()> _
    Public Sub Close()

        If Not cmd Is Nothing Then
            cmd.Dispose()
        End If
        If Not dr Is Nothing Then
            dr.Close()
        End If
        con.Close()

    End Sub

#End Region

#Region "�v���C�x�[�g���\�b�h"

    ''' <summary>
    ''' �R�l�N�V�����m��
    ''' </summary>
    ''' <remarks></remarks>
    <System.Diagnostics.DebuggerStepThrough()> _
    Public  Sub Initialize()

        'Dim settings As Settings = settings.GetInstance
        XmlSettings.LoadFromXmlFile()

        Try
            con = New SqlConnection
            '�ڑ�������̐ݒ�
            'con.ConnectionString = _
            '    "Data Source=" & settings.DataSource & ";" & _
            '    "Initial Catalog=" & settings.InitialCatalog & ";" & _
            '    "Persist Security Info=True;" & _
            '    "User ID=" & settings.UserID & ";" & _
            '    "Password=" & settings.Password

            'mysettings����擾
            con.ConnectionString =
                "Data Source=" & My.Settings.DataSource & ";" &
                "Initial Catalog=" & My.Settings.DataBase & ";" &
                "Persist Security Info=True;" &
                "User ID=" & My.Settings.UserID & ";" &
                "Password=" & My.Settings.PW

            ''Windows�F��
            'con.ConnectionString = _
            '    "Data Source = " & settings.DataSource & ";" & _
            '    "Initial Catalog = " & settings.InitialCatalog & ";" & _
            '    "Integrated Security = SSPI"

            '�f�[�^�x�[�X���J��
            con.Open()

        Catch ex As Exception

            Call OutputLogFile("�����ꏊ�F" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message)
            MessageBox.Show("�����ꏊ�F" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message, "�G���[", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

#End Region

#Region "�p�u���b�N���\�b�h"

    ''' <summary>
    ''' SELECT�����s�p�֐�
    ''' </summary>
    ''' <param name="strSQL">SELECT��</param>
    ''' <returns>�f�[�^���[�_�[�^�I�u�W�F�N�g</returns>
    ''' <remarks></remarks>
    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function DB_SELECT_READER(ByVal strSQL As String) As SqlClient.SqlDataReader

        Try

            cmd = New SqlClient.SqlCommand(strSQL, con)
            cmd.CommandTimeout = 600
            dr = cmd.ExecuteReader

            Return dr

        Catch ex As Exception

            Call OutputLogFile("�����ꏊ�F" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message)
            MessageBox.Show("�����ꏊ�F" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & vbNewLine & strSQL, "�G���[", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' INSERT�ADELETE�AUPDATE�����s�p�֐�
    ''' </summary>
    ''' <param name="strSQL">SQL��</param>
    ''' <remarks>�g�����U�N�V�������쐬���A���[���o�b�N�ł���悤�ɂ��Ă���</remarks>
    <System.Diagnostics.DebuggerStepThrough()> _
    Public Sub DB_UPDATE(ByVal strSQL As String)

        Dim sqlTran As SqlTransaction   '�g�����U�N�V����

        sqlTran = con.BeginTransaction()

        cmd = New SqlCommand(strSQL, con)
        cmd.Transaction = sqlTran

        Try

            cmd.ExecuteNonQuery()
            cmd.CommandTimeout = 600
            sqlTran.Commit()    '�R�~�b�g

        Catch ex As Exception

            sqlTran.Rollback()  '���[���o�b�N
            Call OutputLogFile("�����ꏊ�F" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message)
            MessageBox.Show("�����ꏊ�F" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & vbNewLine & strSQL, "�G���[", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    ''' <summary>
    ''' DATASET�擾�p�֐�
    ''' </summary>
    ''' <param name="strSQL"></param>
    ''' <param name="srcTable"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function DB_SELECT_DATASET(ByVal strSQL As String, ByVal srcTable As String) As DataSet

        Try

            Dim da As SqlDataAdapter = New SqlDataAdapter(strSQL, con)
            Dim ds As DataSet = New DataSet()
            da.Fill(ds, srcTable)

            Return ds

        Catch ex As Exception

            Call OutputLogFile("�����ꏊ�F" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message)
            MessageBox.Show("�����ꏊ�F" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & vbNewLine & strSQL, "�G���[", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' SQL���̌��ʂ��P��̒l���擾
    ''' </summary>
    ''' <param name="strSQL"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function DB_EXECUTE_SCALAR(ByVal strSQL As String) As Object

        Try

            cmd = New SqlClient.SqlCommand(strSQL, con)

            Return cmd.ExecuteScalar()

        Catch ex As Exception

            Call OutputLogFile("�����ꏊ�F" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message)
            MessageBox.Show("�����ꏊ�F" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & vbNewLine & strSQL, "�G���[", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' DATATABLE�擾�p�֐�
    ''' </summary>
    ''' <param name="strSQL"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function DB_SELECT_DATATABLE(ByVal strSQL As String) As DataTable

        Try

            Dim da As SqlDataAdapter = New SqlDataAdapter(strSQL, con)
            Dim dt As New DataTable

            da.Fill(dt)

            Return dt

        Catch ex As Exception

            Call OutputLogFile("�����ꏊ�F" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message)
            MessageBox.Show("�����ꏊ�F" & Reflection.MethodBase.GetCurrentMethod.Name & vbNewLine & ex.Message & vbNewLine & vbNewLine & strSQL, "�G���[", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Return Nothing

        End Try

    End Function

#End Region

End Class
