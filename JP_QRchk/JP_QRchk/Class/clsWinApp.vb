Public Class clsWinApp

    ''' <summary>
    ''' メインルーチン
    ''' </summary>
    ''' <remarks></remarks>
    <STAThread()> Public Shared Sub Main()

        'ビジュアルスタイルを有効にする
        Application.EnableVisualStyles()

        '二重起動をチェックする
        If Diagnostics.Process.GetProcessesByName( _
            Diagnostics.Process.GetCurrentProcess.ProcessName).Length > 1 Then
            'すでに起動していると判断して終了
            MessageBox.Show("多重起動はできません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Application.Run(New frmBCRead())

    End Sub

End Class
