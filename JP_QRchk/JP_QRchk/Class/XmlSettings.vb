Imports System
Imports System.IO
Imports System.Text
Imports System.Runtime.Serialization
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Windows.Forms
Imports Microsoft.Win32

<System.Diagnostics.DebuggerStepThrough()> _
<Serializable()> _
Public Class XmlSettings

#Region "�v���C�x�[�g�ϐ�"

    '�ݒ��ۑ�����t�B�[���h
    '�t�H�[���S��
    Private _LocationX As Integer   '�t�H�[���ʒuX
    Private _LocationY As Integer   '�t�H�[���ʒuY
    Private _SizeX As Integer   '�t�H�[����
    Private _SizeY As Integer   '�t�H�[������
    Private _State As Integer   '�ő剻�E�ŏ������
    Private _ApplicationName As String  '�A�v���P�[�V������
    Private _LoginCategory As Integer   '��ƍH���̃C���f�b�N�X�i�[�p
    '����
    Private _ManageTable As String  '�Ǘ��e�[�u����
    Private _AccessFilePath As String   '�Ǘ��f�[�^�p�X
    Private _ManageSynchroOutputFolder As String    '�Ǘ��f�[�^�����o�̓t�H���_
    '�ڎ�����
    Private _PreparationFolder As String    '�ڎ������Q�ƃt�H���_
    Private _PreparationOutputFolder As String  '�ڎ������o�̓t�H���_
    '�ڎ����́E�C���|�[�g
    Private _InputFolder As String    '�ڎ����̓t�H���_
    Private _MokujiImportFile As String '�ڎ��f�[�^�t�@�C��
    Private _MokujiImportOutputFolder As String   '�ڎ��f�[�^�p���O�t�H���_
    '�ڎ����i
    Private _InspectionFolder As String   '�ڎ����i�t�H���_
    Private _BookmarkFolder As String   '������t�H���_
    '�T���l�C��
    Private _ThumbnailFolder As String    '�T���l�C���Q�ƃt�H���_
    Private _ThumbnailOutputFolder As String    '�T���l�C���o�̓t�H���_
    '�T���l�C���쐻
    Private _ThumbCreateFolder As String    '�T���l�C���쐻�Q�ƃt�H���_
    Private _ThumbCreateOutputFolder As String  '�T���l�C���쐻�o�̓t�H���_
    '�ڎ��o��
    Private _MokujiExportOutputFolder As String '�ڎ��o�͗p�t�H���_
    '�R�[�h�`�F�b�N
    Private _CodeCheckFile As String    '�R�[�h�`�F�b�N�Ώۃt�@�C��
    Private _CodeCheckOutputFolder As String    '�R�[�h�`�F�b�N�p�o�̓t�H���_
    'SQLServer�ڑ��p
    Private _DataSource As String
    Private _InitialCatalog As String
    Private _UserID As String
    Private _Password As String

#End Region

#Region "�v���p�e�B"

    '�ݒ�̃v���p�e�B
    ''' <summary>
    ''' �t�H�[���ʒuX
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property LocationX() As Integer
        Get
            Return _LocationX
        End Get
        Set(value As Integer)
            _LocationX = value
        End Set
    End Property
    ''' <summary>
    ''' �t�H�[���ʒuY
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property LocationY() As Integer
        Get
            Return _LocationY
        End Get
        Set(value As Integer)
            _LocationY = value
        End Set
    End Property
    ''' <summary>
    ''' �t�H�[����
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SizeX() As Integer
        Get
            Return _SizeX
        End Get
        Set(value As Integer)
            _SizeX = value
        End Set
    End Property
    ''' <summary>
    ''' �t�H�[������
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SizeY() As Integer
        Get
            Return _SizeY
        End Get
        Set(value As Integer)
            _SizeY = value
        End Set
    End Property
    ''' <summary>
    ''' �ő剻�E�ŏ������
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property State() As Integer
        Get
            Return _State
        End Get
        Set(value As Integer)
            _State = value
        End Set
    End Property
    ''' <summary>
    ''' �A�v���P�[�V������
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ApplicationName() As String
        Get
            Return _ApplicationName
        End Get
        Set(value As String)
            _ApplicationName = value
        End Set
    End Property
    ''' <summary>
    ''' ��ƍH���̃C���f�b�N�X
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property LoginCategory() As Integer
        Get
            Return _LoginCategory
        End Get
        Set(value As Integer)
            _LoginCategory = value
        End Set
    End Property
    ''' <summary>
    ''' �Ǘ��e�[�u����
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ManageTable() As String
        Get
            Return _ManageTable
        End Get
        Set(value As String)
            _ManageTable = value
        End Set
    End Property
    ''' <summary>
    ''' �Ǘ��f�[�^�p�X
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property AccessFilePath() As String
        Get
            Return _AccessFilePath
        End Get
        Set(value As String)
            _AccessFilePath = value
        End Set
    End Property
    ''' <summary>
    ''' �Ǘ��f�[�^�����o�̓t�H���_
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ManageSynchroOutputFolder() As String
        Get
            Return _ManageSynchroOutputFolder
        End Get
        Set(value As String)
            _ManageSynchroOutputFolder = value
        End Set
    End Property
    ''' <summary>
    ''' �ڎ������Q�ƃt�H���_
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property PreparationFolder() As String
        Get
            Return _PreparationFolder
        End Get
        Set(value As String)
            _PreparationFolder = value
        End Set
    End Property
    ''' <summary>
    ''' �ڎ������o�̓t�H���_
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property PreparationOutputFolder() As String
        Get
            Return _PreparationOutputFolder
        End Get
        Set(value As String)
            _PreparationOutputFolder = value
        End Set
    End Property
    ''' <summary>
    ''' �ڎ����̓t�H���_
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property InputFolder() As String
        Get
            Return _InputFolder
        End Get
        Set(value As String)
            _InputFolder = value
        End Set
    End Property
    ''' <summary>
    ''' �ڎ��f�[�^�t�@�C��
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property MokujiImportFile() As String
        Get
            Return _MokujiImportFile
        End Get
        Set(value As String)
            _MokujiImportFile = value
        End Set
    End Property
    ''' <summary>
    ''' �ڎ��f�[�^�o�̓t�H���_
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property MokujiImportOutputFolder() As String
        Get
            Return _MokujiImportOutputFolder
        End Get
        Set(value As String)
            _MokujiImportOutputFolder = value
        End Set
    End Property
    ''' <summary>
    ''' �ڎ����i�t�H���_
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property InspectionFolder() As String
        Get
            Return _InspectionFolder
        End Get
        Set(value As String)
            _InspectionFolder = value
        End Set
    End Property
    ''' <summary>
    ''' ������t�H���_
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property BookmarkFolder() As String
        Get
            Return _BookmarkFolder
        End Get
        Set(value As String)
            _BookmarkFolder = value
        End Set
    End Property
    ''' <summary>
    ''' �T���l�C���Q�ƃt�H���_
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ThumbnailFolder() As String
        Get
            Return _ThumbnailFolder
        End Get
        Set(value As String)
            _ThumbnailFolder = value
        End Set
    End Property
    ''' <summary>
    ''' �T���l�C���o�̓t�H���_
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ThumbnailOutputFolder() As String
        Get
            Return _ThumbnailOutputFolder
        End Get
        Set(value As String)
            _ThumbnailOutputFolder = value
        End Set
    End Property
    ''' <summary>
    ''' �T���l�C���쐻�Q�ƃt�H���_
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ThumbCreateFolder() As String
        Get
            Return _ThumbCreateFolder
        End Get
        Set(value As String)
            _ThumbCreateFolder = value
        End Set
    End Property
    ''' <summary>
    ''' �T���l�C���쐻�o�̓t�H���_
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ThumbCreateOutputFolder() As String
        Get
            Return _ThumbCreateOutputFolder
        End Get
        Set(value As String)
            _ThumbCreateOutputFolder = value
        End Set
    End Property
    ''' <summary>
    ''' �ڎ��o��
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property MokujiExportOutputFolder() As String
        Get
            Return _MokujiExportOutputFolder
        End Get
        Set(value As String)
            _MokujiExportOutputFolder = value
        End Set
    End Property
    ''' <summary>
    ''' �R�[�h�`�F�b�N�Ώۃt�@�C��
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property CodeCheckFile() As String
        Get
            Return _CodeCheckFile
        End Get
        Set(value As String)
            _CodeCheckFile = value
        End Set
    End Property
    ''' <summary>
    ''' �R�[�h�`�F�b�N�p�o�̓t�H���_
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property CodeCheckOutputFolder() As String
        Get
            Return _CodeCheckOutputFolder
        End Get
        Set(value As String)
            _CodeCheckOutputFolder = value
        End Set
    End Property
    ''' <summary>
    ''' DataSource
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property DataSource() As String
        Get
            Return _DataSource
        End Get
        Set(value As String)
            _DataSource = value
        End Set
    End Property
    ''' <summary>
    ''' InitialCatalog
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property InitialCatalog() As String
        Get
            Return _InitialCatalog
        End Get
        Set(value As String)
            _InitialCatalog = value
        End Set
    End Property
    ''' <summary>
    ''' UserID
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property UserID() As String
        Get
            Return _UserID
        End Get
        Set(value As String)
            _UserID = value
        End Set
    End Property
    ''' <summary>
    ''' Password
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Password() As String
        Get
            Return _Password
        End Get
        Set(value As String)
            _Password = value
        End Set
    End Property

#End Region

#Region "�R���X�g���N�^"

    Public Sub New()

        'SQLServer�ڑ��p
        _DataSource = My.Settings.DataSource
        _InitialCatalog = My.Settings.DataBase
        _UserID = My.Settings.UserID
        _Password = My.Settings.PW

        'XML�t�@�C�������݂��Ă�����ǂݍ���
        'LoadFromXmlFile()

    End Sub

#End Region

#Region "�C���X�^���X"

    'XmlSettings�N���X�̂����ЂƂ̃C���X�^���X
    <NonSerialized()> _
    Private Shared _instance As XmlSettings
    <System.Xml.Serialization.XmlIgnore()> _
    Public Shared Property Instance() As XmlSettings
        Get
            If _instance Is Nothing Then
                _instance = New XmlSettings
            End If
            Return _instance
        End Get
        Set(value As XmlSettings)
            _instance = value
        End Set
    End Property

#End Region

#Region "�ݒ�̓ǂݏ���"

    ''' <summary>
    ''' �ݒ��XML�t�@�C������ǂݍ��ݕ�������
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Sub LoadFromXmlFile()

        Dim p As String = GetSettingPath()
        If Not System.IO.File.Exists(p) Then
            Exit Sub
        End If
        Dim sr As New StreamReader(p, New UTF8Encoding(False))
        Dim xs As New System.Xml.Serialization.XmlSerializer(GetType(XmlSettings))
        '�ǂݍ���ŋt�V���A��������
        Dim obj As Object = xs.Deserialize(sr)
        sr.Close()

        Instance = CType(obj, XmlSettings)

    End Sub

    ''' <summary>
    ''' ���݂̐ݒ��XML�t�@�C���ɕۑ�����
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Sub SaveToXmlFile()

        Dim p As String = GetSettingPath()
        If Not System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(p)) Then
            My.Computer.FileSystem.CreateDirectory(System.IO.Path.GetDirectoryName(p))
        End If
        Dim sw As New StreamWriter(p, False, New UTF8Encoding(False))
        Dim xs As New System.Xml.Serialization.XmlSerializer(GetType(XmlSettings))
        '�V���A�������ď�������
        xs.Serialize(sw, Instance)
        sw.Close()

    End Sub


    ''' <summary>
    ''' �ݒ���o�C�i���t�@�C������ǂݍ��ݕ�������
    ''' </summary>
    Public Shared Sub LoadFromBinaryFile()
        Dim p As String = GetSettingPath()

        Dim fs As New FileStream(p, FileMode.Open, FileAccess.Read)
        Dim bf As New BinaryFormatter
        '�ǂݍ���ŋt�V���A��������
        Dim obj As Object = bf.Deserialize(fs)
        fs.Close()

        Instance = CType(obj, XmlSettings)
    End Sub

    ''' <summary>
    ''' ���݂̐ݒ���o�C�i���t�@�C���ɕۑ�����
    ''' </summary>
    Public Shared Sub SaveToBinaryFile()
        Dim p As String = GetSettingPath()

        Dim fs As New FileStream(p, FileMode.Create, FileAccess.Write)
        Dim bf As New BinaryFormatter
        '�V���A�������ď�������
        bf.Serialize(fs, Instance)
        fs.Close()
    End Sub

    ''' <summary>
    ''' �ݒ�����W�X�g������ǂݍ��ݕ�������
    ''' </summary>
    Public Shared Sub LoadFromRegistry()
        Dim bf As New BinaryFormatter
        '���W�X�g������ǂݍ���
        Dim reg As RegistryKey = GetSettingRegistry()
        Dim bs As Byte() = CType(reg.GetValue(""), Byte())
        '�t�V���A�������ĕ���
        Dim ms As New MemoryStream(bs, False)
        Instance = CType(bf.Deserialize(ms), XmlSettings)
        '����
        ms.Close()
        reg.Close()
    End Sub

    ''' <summary>
    ''' ���݂̐ݒ�����W�X�g���ɕۑ�����
    ''' </summary>
    Public Shared Sub SaveToRegistry()
        Dim ms As New MemoryStream
        Dim bf As New BinaryFormatter
        '�V���A��������MemoryStream�ɏ�������
        bf.Serialize(ms, Instance)
        '���W�X�g���֕ۑ�����
        Dim reg As RegistryKey = GetSettingRegistry()
        reg.SetValue("", ms.ToArray())
        '����
        ms.Close()
        reg.Close()
    End Sub

    ''' <summary>
    ''' �C���X�^���X�̓��e��ۑ����ĉ������
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Sub Dispose()

        SaveToXmlFile()
        Instance = Nothing

    End Sub

#End Region

#Region "�v���C�x�[�g���\�b�h"

    ''' <summary>
    ''' XML�t�@�C���̕ۑ�����擾����
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function GetSettingPath() As String

        'Dim p As String = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), _
        '                               Application.CompanyName + "\" + Application.ProductName _
        '                               + "\" + "Settings.xml")
        Dim p As String = Application.StartupPath & "\Settings.xml"

        Return p

    End Function

    ''' <summary>
    ''' ���W�X�g���̕ۑ���L�[���擾����
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function GetSettingRegistry() As RegistryKey

        Dim reg As RegistryKey = Registry.CurrentUser.CreateSubKey(("Software\" + Application.CompanyName + _
                                                                    "\" + Application.ProductName))
        Return reg

    End Function

#End Region

End Class
