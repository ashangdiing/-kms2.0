using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace 短信服务.Tool
{
    public class SMSAPI : IDisposable
    {
        public event Action<string> ReceiveMessage;
        public event Action<string> ReceiveCallId;
        System.Timers.Timer t = new System.Timers.Timer(500);
        public SMSAPI()
        {
            t.Elapsed += t_Elapsed;
            t.AutoReset = true;
            t.Enabled = false;
        }

        void t_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            string msg = GetRevSM();
            string[] msgs;
            string phone = "未知号码";
            if (!string.IsNullOrEmpty(msg))
            {
                if (ReceiveMessage != null)
                {
                    ReceiveMessage(msg);
                    msgs = msg.Split('\n');
                    if (!string.IsNullOrEmpty(msgs[0]))
                    {
                        phone = msgs[0];
                    }
                  //  addMesage2DataBase(phone, msgs[2], 0, 1);
                }
                if (ReceiveCallId != null)
                {
                    ReceiveCallId(GetStatus());
                }
            }
            ClrRevSM();
        }
        public void Dispose()
        {
            t.Enabled = false;
        }
        public void RegModule()
        {
            zwcdmasmApi.RegModule("zwdigital");
        }
        public string GetRevSM()
        {
            return zwcdmasmApi.GetRevSM();
        }
        public void ClrRevSM()
        {
            zwcdmasmApi.ClrRevSM(string.Empty);
        }
        public string GetStatus()
        {
            string msg = "commReturnMess:"+zwcdmasmApi.GetStatus();
            //zwcdmasmApi.ClrStatus(string.Empty);
            return msg;
        }
        public string InitSMS()
        {
            zwcdmasmApi.InitSMS();
            t.Enabled = true;
            return "-----" + GetStatus();
        }
        public string InitComm()
        {
            zwcdmasmApi.InitComm();
            return "InitComm";
        }
        public string InitComm(string com)
        {
            zwcdmasmApi.SetTip(0);
            zwcdmasmApi.StartComm(com);
            return zwcdmasmApi.GetStatus();
        }
        public void StopComm()
        {
            zwcdmasmApi.StopComm();
        }
        public void SetTip(byte tip)
        {
            zwcdmasmApi.SetTip(tip);
        }
        public string SendSM(string phonenum, string sm)
        {
            try
            {
                zwcdmasmApi.SendSM(phonenum, sm);
            }
            catch { }
            return GetStatus();
        }
        public string SendCNSM(string phonenum, string sm)
        {
            try
            {
                zwcdmasmApi.SendCNSM(phonenum, sm);
              //  addMesage2DataBase(phonenum, sm, 1, 0);
                //using (Sbw.DbClient.DbClient Client = new Sbw.DbClient.DbClient())
                //{
                //    Client.AddParameter("@number", phonenum);
               //     Client.AddParameter("@message", sm);
               //     Client.ExecuteNonQuery("insert into SMS(number,[message])value(@number,@message)");
               // }
            }
            catch { }
            return GetStatus();
        }
        public void SetSvrNumber(string number)
        {
            zwcdmasmApi.SetSvrNumber(number);
        }
        public void StopSMS()
        {
            t.Enabled = false;
            zwcdmasmApi.StopSMS();
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
                if(command!=null)
                command.Dispose();
                if (connection != null) connection.Dispose();
            }
            return num;
        }

    }
}
