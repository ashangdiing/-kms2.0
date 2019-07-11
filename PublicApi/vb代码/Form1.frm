VERSION 5.00
Object = "{648A5603-2C6E-101B-82B6-000000000014}#1.1#0"; "MSCOMM32.OCX"
Begin VB.Form Form1 
   Caption         =   "短信模块测试程序"
   ClientHeight    =   6390
   ClientLeft      =   60
   ClientTop       =   345
   ClientWidth     =   7980
   LinkTopic       =   "Form1"
   ScaleHeight     =   6390
   ScaleWidth      =   7980
   StartUpPosition =   3  '窗口缺省
   Begin VB.CommandButton Command1 
      Caption         =   "直接打开串口"
      Height          =   495
      Left            =   2280
      TabIndex        =   12
      Top             =   2760
      Width           =   1335
   End
   Begin VB.Timer Timer1 
      Enabled         =   0   'False
      Interval        =   1000
      Left            =   6960
      Top             =   1320
   End
   Begin MSCommLib.MSComm MSComm1 
      Left            =   5400
      Top             =   360
      _ExtentX        =   1005
      _ExtentY        =   1005
      _Version        =   393216
      CommPort        =   2
      DTREnable       =   -1  'True
   End
   Begin VB.ComboBox com_Combo 
      Height          =   300
      ItemData        =   "Form1.frx":0000
      Left            =   1080
      List            =   "Form1.frx":0022
      TabIndex        =   11
      Text            =   "COM1"
      Top             =   2880
      Width           =   1095
   End
   Begin VB.CommandButton exit_Command 
      Caption         =   "退出"
      Height          =   495
      Left            =   6360
      TabIndex        =   10
      Top             =   5400
      Width           =   1215
   End
   Begin VB.CommandButton ensend_Command 
      Caption         =   "字符发送"
      Height          =   495
      Left            =   4560
      TabIndex        =   9
      Top             =   5400
      Width           =   1095
   End
   Begin VB.CommandButton cnsend_Command 
      Caption         =   "中文发送"
      Height          =   495
      Left            =   2760
      TabIndex        =   8
      Top             =   5400
      Width           =   1215
   End
   Begin VB.TextBox number_Text 
      Height          =   375
      Left            =   840
      TabIndex        =   7
      Text            =   "13916277990"
      Top             =   5400
      Width           =   1575
   End
   Begin VB.TextBox send_Text 
      Height          =   1575
      Left            =   720
      TabIndex        =   6
      Text            =   "准备发送的信息"
      Top             =   3480
      Width           =   5655
   End
   Begin VB.CommandButton init_Command 
      Caption         =   "初始化"
      Height          =   495
      Left            =   6720
      TabIndex        =   5
      Top             =   2760
      Width           =   1095
   End
   Begin VB.CommandButton comclose_Command 
      Caption         =   "关闭串口"
      Height          =   495
      Left            =   4920
      TabIndex        =   4
      Top             =   2760
      Width           =   1335
   End
   Begin VB.CommandButton comopen_Command 
      Caption         =   "打开串口"
      Height          =   495
      Left            =   3720
      TabIndex        =   3
      Top             =   2760
      Width           =   1095
   End
   Begin VB.TextBox get_Text 
      Height          =   1455
      Left            =   720
      TabIndex        =   2
      Text            =   "接收到的信息"
      Top             =   1080
      Width           =   5535
   End
   Begin VB.CommandButton reg_Command 
      Caption         =   "软件注册"
      Height          =   495
      Left            =   3120
      TabIndex        =   1
      Top             =   240
      Width           =   1335
   End
   Begin VB.TextBox reg_Text 
      Height          =   375
      Left            =   720
      TabIndex        =   0
      Text            =   "请输入注册码"
      Top             =   360
      Width           =   1575
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Private Declare Sub regmodule Lib "zwssmdll.dll" (ByVal serial As String)
Private Declare Sub initsms Lib "zwssmdll.dll" ()
Private Declare Sub initcomm Lib "zwssmdll.dll" ()
Private Declare Sub startcomm Lib "zwssmdll.dll" (ByVal com As String)
Private Declare Sub stopcomm Lib "zwssmdll.dll" ()
Private Declare Sub settip Lib "zwssmdll.dll" (ByVal tip As Byte)
Private Declare Function getstatus Lib "zwssmdll.dll" () As Long
Private Declare Function getrevsm Lib "zwssmdll.dll" () As Long
Private Declare Sub clrrevsm Lib "zwssmdll.dll" (ByVal s As String)
Private Declare Sub sendsm Lib "zwssmdll.dll" (ByVal phonenum As String, ByVal sm As String)
Private Declare Sub sendcnsm Lib "zwssmdll.dll" (ByVal phonenum As String, ByVal sm As String)
Private Declare Sub setsvrnumber Lib "zwssmdll.dll" (ByVal number As String)


Private Sub cnsend_Command_Click()
'发送中文短信
Call sendcnsm(number_Text, send_Text.Text)
End Sub



Private Sub Command1_Click()
'直接打开串口
'If MSComm1.PortOpen = True Then
   'MSComm1.PortOpen = False
'End If

Call startcomm(com_Combo.Text)
End Sub

Private Sub comopen_Command_Click()
'打开串口
Call initcomm
End Sub

Private Sub ensend_Command_Click()
'发送字符短信
Call sendsm(number_Text, send_Text.Text)
End Sub

Private Sub exit_Command_Click()
Call stopcomm
Unload Me
End Sub

Private Sub Form_Load()
'设置是否提示
Call settip(1)
End Sub

Private Sub Form_Unload(Cancel As Integer)
'关闭串口
Call stopcomm
End Sub

Private Sub init_Command_Click()
'初始化模块，开始定时查询手机短信
Timer1.Enabled = True
Call initsms
End Sub

Private Sub reg_Command_Click()
Call regmodule(reg_Text.Text)
End Sub

Private Sub Timer1_Timer()
Dim l_status As Long
Dim l_revsm As Long
Dim s As String

l_status = getstatus    '获取模块状态函数返回的地址
If l_status <> 0 Then
   s = ReadMem(l_status, DefineWord) '读取该地址内容
   get_Text.Text = get_Text.Text & s

End If



l_revsm = getrevsm
If l_revsm <> 0 Then
   s = ReadMem(l_revsm, DefineWord)
   get_Text.Text = get_Text.Text & s
End If



End Sub
