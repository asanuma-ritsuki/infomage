Imports C1.Win.C1FlexGrid
Imports System.Globalization

Public Class frmMainMenu

#Region "プライベート変数"

	Private _LoginItem As String = ""

#End Region

#Region "プロパティ"

	''' <summary>
	''' 案件情報の読み書き
	''' </summary>
	''' <returns></returns>
	Public Property LoginItem()
		Get
			Return _LoginItem
		End Get
		Set(value)
			_LoginItem = value
		End Set
	End Property

#End Region

#Region "フォームイベント"

	''' <summary>
	''' フォームロード時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub frmMainMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load

		Me.Text = My.Application.Info.ProductName & " Ver." &
			My.Application.Info.Version.ToString & " - [メインメニュー]"

		Initialize()

	End Sub

#End Region

#Region "オブジェクトイベント"

	'''' <summary>
	'''' C1FlexGridオーナー描画時
	'''' </summary>
	'''' <param name="sender"></param>
	'''' <param name="e"></param>
	'Private Sub C1FGridResult_OwnerDrawCell(sender As Object, e As OwnerDrawCellEventArgs) Handles C1FGridResult.OwnerDrawCell

	'	If Not Me.C1FGridResult.Cols(e.Col).UserData Is Nothing AndAlso e.Row >= Me.C1FGridResult.Rows.Fixed Then
	'		Dim value As Double
	'		If Double.TryParse(Me.C1FGridResult.GetDataDisplay(e.Row, e.Col), NumberStyles.Any, CultureInfo.CurrentCulture, value) Then
	'			'バーの拡張幅を計算する
	'			Dim rc As Rectangle = e.Bounds
	'			Dim max As Double = CType(Me.C1FGridResult.Cols(e.Col).UserData, Double)
	'			rc.Width = CType((System.Math.Floor(Me.C1FGridResult.Cols(e.Col).WidthDisplay * value / max)), Integer)

	'			'背景を描画する
	'			e.DrawCell(DrawCellFlags.Background Or DrawCellFlags.Border)

	'			'バーを描画する
	'			rc.Inflate(-2, -2)
	'			e.Graphics.FillRectangle(Brushes.Gold, rc)
	'			rc.Inflate(-1, -1)
	'			e.Graphics.FillRectangle(Brushes.LightGoldenrodYellow, rc)

	'			'セルの内容を描画する
	'			e.DrawCell(DrawCellFlags.Content)
	'		End If
	'	End If
	'   End Sub


#End Region

#Region "プライベートメソッド"

	''' <summary>
	''' 初期化処理
	''' </summary>
	Private Sub Initialize()
		''==================================================
		''棒グラフ描画準備
		''各数値列にスケール情報をアタッチする
		'Dim r1 As Integer = Me.C1FGridResult.Rows.Fixed
		'Dim r2 As Integer = Me.C1FGridResult.Rows.Count - 1
		'Dim s As String = Nothing
		'Dim barCols() As String = New String() {"進捗状況"}

		'For Each s In barCols
		'	Dim col As Column = Me.C1FGridResult.Cols(s)
		'	Dim max As Double = Me.C1FGridResult.Aggregate(AggregateEnum.Max, r1, col.Index, r2, col.Index)
		'	col.UserData = max
		'Next
		''オーナー描画モードにする
		'Me.C1FGridResult.DrawMode = DrawModeEnum.OwnerDraw
		''==================================================

		'案件情報が存在していた場合は、案件名を検索してコンボボックスをロックする
		'管理者関係のオブジェクトを使用不可とする
		If Not IsNull(LoginItem()) Then
			'案件情報が存在した

		Else
			'案件情報が存在しない

		End If


	End Sub

#End Region

End Class