

Public Class frmDiskSize
    Private MaxDiskFreeSize As Long = 0
    'ロード時
    Private Sub frmDiskSize_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim strDiskType = My.Settings.Disk_DiskType
        Me.gbDiskSize.Text = strDiskType & "のサイズ設定"
        Select Case strDiskType
            Case 2
                MaxDiskFreeSize = 50050629632
            Case 1
                MaxDiskFreeSize = 4706074624
            Case 0
                MaxDiskFreeSize = 736958464
        End Select
        Me.lblByte.Text = MaxDiskFreeSize
        Me.txtFreeSpace.Text = MaxDiskFreeSize

        '初期パーセンテージ
        nudPercentage.Value = My.Settings.Disk_Parcentage

    End Sub

    'パーセンテージ変更時
    Private Sub nudPercentage_ValueChanged(sender As System.Object, e As System.EventArgs) Handles nudPercentage.ValueChanged, nudPercentage.KeyUp   '動的に変更させる場合?
        If Me.txtFreeSpace.Text = "" Then
            MaxDiskFreeSize = 0
        Else
            MaxDiskFreeSize = CLng(Me.txtFreeSpace.Text)
        End If
        Me.lblByte.Text = Math.Truncate(MaxDiskFreeSize * (nudPercentage.Value / 100))
        If Me.lblByte.Text >= 1073741824 Then
            '最大容量が1GB以上の場合
            Me.txtVisualByte.Text = Format(CType(Me.lblByte.Text, Long) / 1024 / 1024 / 1024, "0.00")
            Me.lblUnit.Text = "GB"
        ElseIf Me.lblByte.Text >= 1048576 Then
            '最大容量が1MB以上の場合
            Me.txtVisualByte.Text = Format(CType(Me.lblByte.Text, Long) / 1024 / 1024, "0.00")
            Me.lblUnit.Text = "MB"
        Else
            Me.txtVisualByte.Text = Format(CType(Me.lblByte.Text, Long) / 1024, "0.00")
            Me.lblUnit.Text = "KB"
        End If
    End Sub
    'Private Sub nudPercentage_Validated(sender As System.Object, e As System.EventArgs) Handles nudPercentage.Validated
    '    If CType(nudPercentage.Value, String) = "" Then
    '        MessageBox.Show("パーセンテージがブランクです。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
    '    End If
    'End Sub

    'ディスク容量変更時
    Private Sub txtFreeSpace_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtFreeSpace.TextChanged
        Dim d As Long
        If Long.TryParse(Me.txtFreeSpace.Text, d) Then
            If Me.txtFreeSpace.Text > 100000000000 Then
                MessageBox.Show("デイスクサイズは100000000000以下に設定してください。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Me.txtFreeSpace.Text = 1
            ElseIf Me.txtFreeSpace.Text <= 0 Then
                MessageBox.Show("デイスクサイズは1以上に設定してください。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Else
                MaxDiskFreeSize = CType(Me.txtFreeSpace.Text, Long)
            End If

        Else
            MessageBox.Show("デイスクサイズは数値を設定してください。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Me.txtFreeSpace.Text = 1
            MaxDiskFreeSize = CType(Me.txtFreeSpace.Text, Long)
        End If

        Me.lblByte.Text = Math.Truncate(MaxDiskFreeSize * (nudPercentage.Value / 100))
        If MaxDiskFreeSize >= 1073741824 Then
            '最大容量が1GB以上の場合
            Me.txtVisualByte.Text = Format(CType(Me.lblByte.Text, Long) / 1024 / 1024 / 1024, "0.00")
            Me.lblUnit.Text = "GB"
        ElseIf MaxDiskFreeSize >= 1048576 Then
            '最大容量が1MB以上の場合
            Me.txtVisualByte.Text = Format(CType(Me.lblByte.Text, Long) / 1024 / 1024, "0.00")
            Me.lblUnit.Text = "MB"
        Else
            Me.txtVisualByte.Text = Format(CType(Me.lblByte.Text, Long) / 1024, "0.00")
            Me.lblUnit.Text = "KB"
        End If
    End Sub

    'OKボタン押下時
    Private Sub btnDiskSizeOK_Click(sender As System.Object, e As System.EventArgs) Handles btnDiskSizeOK.Click
        'リストボックス内の項目を配列に変換する。
        My.Settings.Disk_DiskSize = Me.lblByte.Text
        My.Settings.Disk_Parcentage = Me.nudPercentage.Value
        Dim stDiskSize As String = String.Format("{0:#,0}", Long.Parse(My.Settings.Disk_DiskSize))
        frmDisk.lblDiskSize.Text = stDiskSize
        My.Settings.Save()
        Close()
    End Sub
End Class