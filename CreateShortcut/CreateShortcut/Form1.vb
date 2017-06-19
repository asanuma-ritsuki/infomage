Public Class Form1
	Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

		If Not System.IO.File.Exists(Me.txtAccessFile.Text) Then
			MessageBox.Show("アクセスファイルが指定されていません", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Exit Sub
		ElseIf Me.txtShortcut.Text = "" Then
			MessageBox.Show("ショートカット名が入力されていません", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Exit Sub
		End If

		If MessageBox.Show("保存フォルダにショートカットを作成します" & vbNewLine & "よろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
			Exit Sub
		End If

		Try
			'参照設定の「COM」タブより「Windows Script Host Object Model」を参照追加する

			Dim strShortcutPath As String = Me.txtSaveFolder.Text & "\" & Me.txtShortcut.Text & ".lnk"  '作成するショートカットのパス
			'ショートカット作成に必要な情報を集める
			Dim strTargetPath As String = Application.ExecutablePath    '実行ファイル名 ※Application.ExecutablePathで実行中のEXEファイルのフルパスを取得する
			Dim strArgment As String = Me.txtAccessFile.Text

			'WshShellを作成
			'参照設定のIWshRuntimeLibraryを選択し、IWshRuntimeLibraryのプロパティをプロパティウインドウに表示させる。
			'プロパティの中に「相互運用機能型の埋め込み」という項目があるので、この値をFalseにする。
			Dim shell As New IWshRuntimeLibrary.WshShell()
			'ショートカットのパスを指定して、WshShortcutを作成
			Dim shortcut As IWshRuntimeLibrary.IWshShortcut = DirectCast(shell.CreateShortcut(strShortcutPath), IWshRuntimeLibrary.IWshShortcut)
			With shortcut
				.TargetPath = strTargetPath 'リンク先
				.Arguments = strArgment 'コマンドパラメータ(リンク先)の後ろにつける文言 ※この例はAccessファイル
				.WorkingDirectory = Application.StartupPath '作業フォルダ
				.WindowStyle = 1    '実行時のウィンドウスタイル 通常：1、最大化：3、最小化：7
				.Description = Me.txtShortcut.Text  'コメント
				.IconLocation = Application.ExecutablePath + ",0"   'アイコンのパス この例では自分のEXEファイルのインデックス0のアイコン
				.Save() 'ショートカットの作成
			End With

			MessageBox.Show("ショートカットを作成しました", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information)

			'後始末
			System.Runtime.InteropServices.Marshal.ReleaseComObject(shortcut)

		Catch ex As Exception

			MessageBox.Show(ex.Message)

		End Try

	End Sub

End Class
