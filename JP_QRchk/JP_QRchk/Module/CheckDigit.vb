Module CheckDigit

	''' <summary>
	''' ���W�����X10�E�F�C�g3�ɂČv�Z�����`�F�b�N�f�W�b�g�l��Ԃ�
	''' </summary>
	''' <param name="strNumber">�`�F�b�N�f�W�b�g�����߂鐔�l</param>
	''' <param name="iFormCategory">���[���ID</param>
	''' <param name="strReturn">�Q�ƌ^�F�`�F�b�N�f�W�b�g�̈ꌅ�̐��l</param>
	''' <returns>TRUE�F�����AFALSE�F���s</returns>
	'''	<remarks>
	'''		1.�E��������3�������ĉ��Z
	'''		2.�����������Z
	'''		3.(1)+(2)����
	'''		4.�ꌅ�ڂ�10������������l
	'''		5.�ꌅ�ڂ�0�̏ꍇ��0
	'''	</remarks>
	Public Function Modulus10(ByVal strNumber As String, ByVal iFormCategory As Integer, ByRef strReturn As String) As Boolean

		Dim iOddTotal As Integer = 0    '����̉��Z�l
		Dim iEvenTotal As Integer = 0   '�������̉��Z�l

		'���[��ʂɂ���Ď}������
		Select Case iFormCategory
			Case 0
				'���x��
				'11��
				'�����񒷃`�F�b�N
				If Not strNumber.Length = 15 Then
					Return False
				End If

			Case 2, 3
				'�Ώێ҈ꗗ�A�ی��w���ΏێҖ���
				'15��
				'�����񒷃`�F�b�N
				If Not strNumber.Length = 15 Then
					Return False
				End If

            Case 4
                '����[
                '16��
                '�����񒷃`�F�b�N
                If Not strNumber.Length = 17 Then
                    Return False
                End If
            Case 5
                '���[�t���b�g
                '17��
                '�����񒷃`�F�b�N
                If Not strNumber.Length = 18 Then
                    Return False
                End If
        End Select

		'������������3�������Ȃ�����Z���Ă���
		For i As Integer = strNumber.Length To 1 Step -2

			iOddTotal += CInt(Strings.Mid(strNumber, i, 1)) * 3
			'���Z������ɒl��1�ȉ��������ꍇFor���𔲂���
			If i <= 1 Then
				Exit For
			End If
		Next
		'�����̈�O��������������Z���Ă���
		For j As Integer = strNumber.Length - 1 To 1 Step -2

			iEvenTotal += CInt(Strings.Mid(strNumber, j, 1))
			'���Z������ɒl��1�ȉ��������ꍇFor���𔲂���
			If j <= 1 Then
				Exit For
			End If
		Next

		'�ŏI���𕶎��񉻂��ĂЂƂ����ڂ��擾�����l������10�����Z����
		'�ЂƂ����ڂ�0�̏ꍇ��0��Ԃ�
		Dim iTotal As Integer = iOddTotal + iEvenTotal
		Dim iBeforeCD As Integer = CInt(Strings.Right(iTotal.ToString, 1))

		If iBeforeCD = 0 Then
			strReturn = "0"
		Else
			strReturn = (10 - iBeforeCD).ToString
		End If

		Return True

	End Function

End Module
