Imports System.Threading.Tasks

Module PlaySound
	'サウンドを再生するWin32 APIの宣言
	<Flags()>
	Public Enum PlaySoundFlags
		SND_SYNC = &H0
		SND_ASYNC = &H1
		SND_NODEFAULT = &H2
		SND_MEMORY = &H4
		SND_LOOP = &H8
		SND_NOSTOP = &H10
		SND_NOWAIT = &H2000
		SND_ALIAS = &H10000
		SND_ALIAS_ID = &H110000
		SND_FILENAME = &H20000
		SND_RESOURCE = &H40004
		SND_PURGE = &H40
		SND_APPLICATION = &H80
	End Enum
	<System.Runtime.InteropServices.DllImport("winmm.dll",
		CharSet:=System.Runtime.InteropServices.CharSet.Auto)>
	Private Function PlaySound(ByVal pszSound As IntPtr,
	ByVal hmod As IntPtr, ByVal fdwSound As PlaySoundFlags) As Boolean
	End Function

	Private gcHandle As System.Runtime.InteropServices.GCHandle
	Private waveBuffer As Byte() = Nothing

	'Waveを再生する
	Public Sub PlayWaveSound(ByVal strm As System.IO.Stream)
		If Not (waveBuffer Is Nothing) Then
			StopWaveSound()
		End If
		'byte配列にする
		waveBuffer = New Byte(strm.Length) {}
		strm.Read(waveBuffer, 0, waveBuffer.Length)

		'GCによって移動されないようにする
		gcHandle = System.Runtime.InteropServices.GCHandle.Alloc(
			waveBuffer, System.Runtime.InteropServices.GCHandleType.Pinned)

		'非同期再生する
		PlaySound(gcHandle.AddrOfPinnedObject(), IntPtr.Zero,
			PlaySoundFlags.SND_MEMORY Or PlaySoundFlags.SND_ASYNC)
	End Sub

	'再生中のWaveを停止する
	Public Sub StopWaveSound()
		If waveBuffer Is Nothing Then
			Return
		End If

		'再生しているWAVEを停止する
		PlaySound(IntPtr.Zero, IntPtr.Zero, PlaySoundFlags.SND_PURGE)

		'解放する
		gcHandle.Free()
		waveBuffer = Nothing
	End Sub
	''' <summary>
	''' メイン
	''' </summary>
	Sub Main2()
		' タスクを作成する。
		Dim t As New Task(AddressOf action1)
		' タスクを開始。
		t.Start()
		' タスクの終了を待機する。
		t.Wait()
		'#If DEBUG Then
		'        Console.ReadKey()
		'#End If
	End Sub

	''' <summary>
	''' タスクメソッド
	''' </summary>
	Sub action1()
		'オーディオリソースを取り出す
		Dim strm As System.IO.Stream = My.Resources.alert
		'再生する
		PlayWaveSound(strm)

		strm.Close()
	End Sub
End Module


