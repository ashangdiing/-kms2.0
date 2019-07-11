Attribute VB_Name = "modMemory"
'Attribute VB_Name = "modMemory"
 ' =============================================================================
 ' 复制内存 API
 ' =============================================================================
 Private Declare Sub CopyMemory _
                     Lib "kernel32" Alias _
                     "RtlMoveMemory" _
                     (Destination As Any, _
                      Source As Any, _
                      ByVal length As Long)
                     
 ' =============================================================================
 ' 数据长度
 ' =============================================================================
 Public Enum e_BinaryData
     DefineByte = 1                          '  8 位数据
     DefineWord = 2                          ' 16 位数据
     DefineDoubleWord = 4                    ' 32 位数据
     DefineQuadWord = 8                      ' 64 位数据
 End Enum

 ' 允许直接读 MemPointer 指向的内存
 ' 用和 Asm 一样的字节数定义 (DB, DW, DD, DX)
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

 ' 允许直接写 MemPointer 指向的内存
 ' 用和 Asm 一样的字节数定义 (DB, DW, DD, DX)
 Sub WriteMem(ByVal MemPointer As Long, _
              SizeInBytes As e_BinaryData, _
              ByVal DataToWrite)
     CopyMemory ByVal MemPointer, VarPtr(DataToWrite), SizeInBytes
 End Sub



