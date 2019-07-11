using PublicApi;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace 短信服务.Tool
{
    public class MSMListener
    {
        private bool start = true;
        private TcpListener tcpListener;
        private event Action<SM> ReceiveMessage;
        public void Receive(SM msg)
        {
            if (ReceiveMessage != null)
            {
                ReceiveMessage(msg);
            }
        }
        public void Start(Action<SM> send)
        {
            try
            {
                tcpListener.Start();
                while (start)
                {
                    TcpClient tcpClient = tcpListener.AcceptTcpClient();
                    MessageTool tool = new MessageTool(tcpClient);
                    ReceiveMessage += tool.Send;
                    tool.End((s) =>
                    {
                        ReceiveMessage += tool.Send;
                    });
                    tool.Receive += send;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Application.Exit();
            }
        }
        public MSMListener()
        {
            IPAddress ipAddress = IPAddress.Any;
            tcpListener = new TcpListener(ipAddress, int.Parse(System.Configuration.ConfigurationManager.AppSettings["port"]));
           
        }
        public void Stop()
        {
            start = false;
            try { tcpListener.Stop(); }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public int addMesage2DataBase(string number, string mesage, int state, int isRead)
        {
            SqlConnection connection = null;
            SqlCommand command = null; int num = 0;
            try
            {
                //   SqlConnection connection = new SqlConnection("server= 127.0.0.1;uid=sa;pwd=esun5005;database=crmrun");
                connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Default"].ConnectionString);
                connection.Open();
                command = new SqlCommand();
                command.Connection = connection;
                command.Parameters.Add(new SqlParameter("number", number));
                command.Parameters.Add(new SqlParameter("mesage", mesage));
                command.Parameters.Add(new SqlParameter("state", state));
                command.Parameters.Add(new SqlParameter("isRead", isRead));
                command.CommandText = "insert into SMS(number,message,state,isRead) values(@number,@mesage,@state,@isRead)";

                num = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (command != null)
                    command.Dispose();
                if (connection != null) connection.Dispose();
            }
            return num;
        }
    }
}
