using PublicApi;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace 短信客户端.Tool
{
    public class SMTcpClient
    {
        System.Net.Sockets.TcpClient tcp;
        MessageTool mt;
        public SMTcpClient()
        {
            try
            {
                tcp = new System.Net.Sockets.TcpClient();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                Application.Exit();
            }
        }
        public event Action<SM> Receive;
        public void Start()
        {
           tcp.Connect(ConfigurationManager.AppSettings["address"], int.Parse(ConfigurationManager.AppSettings["port"]));
            mt = new MessageTool(tcp);
            mt.Receive += Receive;
        }
        public void SendMessage(SM sm)
        {
            mt.Send(sm);
        }
        public void Stop()
        {
            if (tcp != null) tcp.Close();
        }
    }
}
