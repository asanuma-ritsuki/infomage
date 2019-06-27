Public Class frmExtension
    'ロード時
    Private Sub frmExtension_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Text = My.Application.Info.ProductName.ToString & " Ver." & _
        My.Application.Info.Version.ToString

        'Const DEF_VAL As Long = 0
        'Dim iniFileName As String = Application.StartupPath & "\ImProperty.ini" 'INIファイル名
        Dim aryInExtensions As String() = My.Settings.Disk_InExtension.Split(","c)
        For i As Integer = 0 To aryInExtensions.Length - 1
            Me.lstInExtension.Items.Add(aryInExtensions(i))
        Next
        Dim aryOutExtensions As String() = My.Settings.Disk_OutExtension.Split(","c)
        For i As Integer = 0 To aryOutExtensions.Length - 1
            If Not aryOutExtensions(i) = "" And Not lstInExtension.Items.Contains(aryOutExtensions(i)) Then
                Me.lstOutExtension.Items.Add(aryOutExtensions(i))
            End If
        Next
    End Sub
    'OK押下時
    Private Sub btnExtensionOk_Click(sender As System.Object, e As System.EventArgs) Handles btnExtensionOK.Click
        'リストボックス内の項目を配列に変換する。
        Dim aryInExtensions As String() = ArrayList.Adapter(Me.lstInExtension.Items).ToArray(GetType(String))
        Dim strInExtensions As String = String.Join(",", aryInExtensions)
        My.Settings.Disk_InExtension = strInExtensions
        Dim aryOutExtensions As String() = ArrayList.Adapter(Me.lstOutExtension.Items).ToArray(GetType(String))
        Dim strOutExtensions As String = String.Join(",", aryOutExtensions)
        My.Settings.Disk_OutExtension = strOutExtensions
        My.Settings.Save()
        Close()

    End Sub


    '追加ボタン押下時
    Private Sub btnAdd_Click(sender As System.Object, e As System.EventArgs) Handles btnAdd.Click

        Dim AddExtension As String = ""
        If Not Me.txtAdd.Text = "" Then
            If Me.txtAdd.Text.Substring(0, 1) = "." Then
                'ドットが既に付いている場合
                AddExtension = "*" & Me.txtAdd.Text
            Else
                'ドットがついていない場合
                AddExtension = "*." & Me.txtAdd.Text
            End If
        Else
            AddExtension = ""
        End If


        If Not AddExtension = "" And Not lstInExtension.Items.Contains(AddExtension) Then
            Me.lstInExtension.Items.Add(AddExtension)
            Me.txtAdd.Text = ""
        Else
            MessageBox.Show("ブランクもしくは既存の拡張子のため追加できません。")
        End If
    End Sub

    '→ボタン押下時
    Private Sub btnIn_Click(sender As System.Object, e As System.EventArgs) Handles btnIn.Click

        Dim SelectedExtension As String = lstInExtension.SelectedItem
        If Not SelectedExtension = "" Then
            Me.lstOutExtension.Items.Add(SelectedExtension)
            Dim index As Integer = lstInExtension.SelectedIndex
            Me.lstInExtension.Items.RemoveAt(index)
        End If

    End Sub

    '←ボタン押下時
    Private Sub btnOut_Click(sender As System.Object, e As System.EventArgs) Handles btnOut.Click
        Dim SelectedExtension As String = lstOutExtension.SelectedItem
        If Not SelectedExtension = "" Then
            Me.lstInExtension.Items.Add(SelectedExtension)
            Dim index As Integer = lstOutExtension.SelectedIndex
            Me.lstOutExtension.Items.RemoveAt(index)
        End If

    End Sub

    'Deleteボタン押下時
    Private Sub btnDelete_Click(sender As System.Object, e As System.EventArgs) Handles btnDel.Click
        If Not lstInExtension.SelectedIndex = -1 Then
            Me.lstInExtension.Items.RemoveAt(lstInExtension.SelectedIndex)
        ElseIf Not lstOutExtension.SelectedIndex = -1 Then
            Me.lstOutExtension.Items.RemoveAt(lstOutExtension.SelectedIndex)
        End If
    End Sub
End Class