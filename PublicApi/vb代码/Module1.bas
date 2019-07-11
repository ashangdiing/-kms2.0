Attribute VB_Name = "modMemory"
'Attribute VB_Name = "modMemory"
 ' =============================================================================
 ' �����ڴ� API
 ' =============================================================================
 Private Declare Sub CopyMemory _
                     Lib "kernel32" Alias _
                     "RtlMoveMemory" _
                     (Destination As Any, _
                      Source As Any, _
                      ByVal length As Long)
                     
 ' =============================================================================
 ' ���ݳ���
 ' =============================================================================
 Public Enum e_BinaryData
     DefineByte = 1                          '  8 λ����
     DefineWord = 2                          ' 16 λ����
     DefineDoubleWord = 4                    ' 32 λ����
     DefineQuadWord = 8                      ' 64 λ����
 End Enum

 ' ����ֱ�Ӷ� MemPointer ָ����ڴ�
 ' �ú� Asm һ�����ֽ������� (DB, DW, DD, DX)
 Function ReadMem(ByVal MemPointer As Long, _
                  SizeInBytes As e_BinaryData)
     Select Case SizeInBytes
         Case DefineByte
             Dim DB As Byte
             CopyMemory DB, ByVal MemPointer, 1
             ReadMem = DB
         Case DefineWord
             Dim DW As Integer
             CopyMemory DW, ByVal MemPointer, 2
             ReadMem = DW
         Case DefineDoubleWord
             Dim DD As Long
             CopyMemory DD, ByVal MemPointer, 4
             ReadMem = DD
         Case DefineQuadWord
             Dim DX As Double
             CopyMemory DX, ByVal MemPointer, 8
             ReadMem = DX
     End Select
 End Function

 ' ����ֱ��д MemPointer ָ����ڴ�
 ' �ú� Asm һ�����ֽ������� (DB, DW, DD, DX)
 Sub WriteMem(ByVal MemPointer As Long, _
              SizeInBytes As e_BinaryData, _
              ByVal DataToWrite)
     CopyMemory ByVal MemPointer, VarPtr(DataToWrite), SizeInBytes
 End Sub



