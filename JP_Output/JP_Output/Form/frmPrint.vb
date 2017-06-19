Imports C1.Win.FlexReport
Imports C1.Win

Public Class frmPrint

#Region "プライベート変数"
    Private isPrinting As Boolean = False
    Private flxrPath As String = System.Windows.Forms.Application.StartupPath & "\flxr"
#End Region

#Region "フォームイベント"
    ''' <summary>
    ''' ロード時
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub frmKekka_hyou_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        '文字列リソースを取り出す
        Me.txtSentlist.Text = My.Resources.sentlist_driver
        Me.txtResult.Text = My.Resources.result_driver
        Me.txtLeaflet.Text = My.Resources.leaflet_driver

        '判定表選択
        Me.cmbPrintType.SelectedIndex = 0
    End Sub

    ''' <summary>
    ''' 印刷開始
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnStart_Click(sender As System.Object, e As System.EventArgs) Handles btnStart.Click
        'レポートを読込
        Dim C1FlexReport1 As New C1FlexReport()
        C1FlexReport1.Load(flxrPath & "\leaflet.flxr", "R_肝機能3")
        C1FlexReport1.Render()

        'ドライブ切り替え
        SetDefaultPrinter(Me.txtLeaflet.Text)

        Dim print_option As C1.Win.C1Document.C1PrintOptions = New C1.Win.C1Document.C1PrintOptions()
        print_option.PrinterSettings = New System.Drawing.Printing.PrinterSettings()
        print_option.PrinterSettings.DefaultPageSettings.Landscape = True

        isPrinting = True
        C1FlexReport1.Print(print_option)


    End Sub
#End Region

#Region "プライベートメソッド"
    ''' <summary>
    ''' 「通常使うプリンタ」に設定する
    ''' </summary>
    ''' <param name="printerName">プリンタ名</param>
    Public Sub SetDefaultPrinter(ByVal printerName As String)
        'WshNetworkオブジェクトを作成する
        Dim t As Type = Type.GetTypeFromProgID("WScript.Network")
        Dim wshNetwork As Object = Activator.CreateInstance(t)
        'SetDefaultPrinterメソッドを呼び出す
        t.InvokeMember("SetDefaultPrinter", _
            System.Reflection.BindingFlags.InvokeMethod, _
            Nothing, wshNetwork, New Object() {printerName})
    End Sub

    ''' <summary>
    ''' 印刷終了時イベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub C1FlexReport1_LongOperation(sender As Object, e As LongOperationEventArgs)
        If isPrinting Then
            If Not e.CanCancel And e.Complete = 1 Then
                ' 印刷終了時の処理
                MessageBox.Show("印刷が完了しました")
                isPrinting = False
            End If
        End If
    End Sub
#End Region

End Class