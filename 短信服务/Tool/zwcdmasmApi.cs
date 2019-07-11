using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
namespace 短信服务.Tool
{
    class zwcdmasmApi
    {
        [DllImport("zwssmdll.dll", EntryPoint = "regmodule", CallingConvention = CallingConvention.StdCall)]
        public static extern void RegModule(string serial);

        [DllImport("zwssmdll.dll", EntryPoint = "initsms", CallingConvention = CallingConvention.StdCall)]
        public static extern void InitSMS();

        [DllImport("zwssmdll.dll", EntryPoint = "initcomm", CallingConvention = CallingConvention.StdCall)]
        public static extern void InitComm();

        [DllImport("zwssmdll.dll", EntryPoint = "startcomm", CallingConvention = CallingConvention.StdCall)]
        public static extern void StartComm(string com);

        [DllImport("zwssmdll.dll", EntryPoint = "stopcomm", CallingConvention = CallingConvention.StdCall)]
        public static extern void StopComm();

        [DllImport("zwssmdll.dll", EntryPoint = "settip", CallingConvention = CallingConvention.StdCall)]
        public static extern void SetTip(byte tip);
    
        [DllImport("zwssmdll.dll", EntryPoint = "getstatus", CallingConvention = CallingConvention.StdCall)]
        public static extern string GetStatus();
        
        //[DllImport("zwssmdll.dll", EntryPoint = "clrstatus", CallingConvention = CallingConvention.StdCall)]
        //public static extern string ClrStatus(string s);

        [DllImport("zwssmdll.dll", EntryPoint = "getrevsm", CallingConvention = CallingConvention.StdCall)]
        public static extern string GetRevSM();

        [DllImport("zwssmdll.dll", EntryPoint = "clrrevsm", CallingConvention = CallingConvention.StdCall)]
        public static extern void ClrRevSM(string s);

        [DllImport("zwssmdll.dll", EntryPoint = "sendsm", CallingConvention = CallingConvention.StdCall)]
        public static extern void SendSM(string phonenum, string sm);

        [DllImport("zwssmdll.dll", EntryPoint = "sendcnsm", CallingConvention = CallingConvention.StdCall)]
        public static extern void SendCNSM(string phonenum, string sm);

        [DllImport("zwssmdll.dll", EntryPoint = "setsvrnumber", CallingConvention = CallingConvention.StdCall)]
        public static extern void SetSvrNumber(string number);

        [DllImport("zwssmdll.dll", EntryPoint = "stopsms", CallingConvention = CallingConvention.StdCall)]
        public static extern void StopSMS();


    }
}
