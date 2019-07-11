using PublicApi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using 短信服务.Tool;

namespace 短信服务
{
    public partial class MSMManage : Form
    {
       public Thread sendServiceThread,reportTheread;
        SMSAPI api;
        MSMListener ms;
        public MSMManage()
        {
            InitializeComponent();
        }

        void api_ReceiveCallId(string obj)
        {
            this.Invoke(new Action<string>((str) =>
            {
                txt_CallId.AppendText(str + "\r\n");
            }), obj);
        }

        void api_ReceiveMessage(string obj)
        {
            this.Invoke(new Action<string>((str) =>
            {
                txt_MSG.AppendText(str + "\r\n");
                SM sm = new SM();
                string[] s = str.Split('\n');
                sm.Type = "msg";
                sm.Number = s[0];
                sm.Message = s[2];
                ms.Receive(sm);
            }), obj);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string comPort = comsSelect.SelectedItem.ToString();
            txt_Message.Text = comPort;
            MessageBox.Show(comPort);
            api_ReceiveCallId(api.InitComm(comPort));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            api_ReceiveCallId(api.InitSMS());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            api_ReceiveCallId(api.SendCNSM(txt_Number.Text, txt_Message.Text));
            SM sm = new SM();
            sm.Type = "msg";
            sm.Number = txt_Number.Text;
            sm.Message = txt_Message.Text;
            tools.log.Debug("测试短信已发送");

            ms.Receive(sm);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            api.RegModule();
        }
        /// <summary>
        /// 测试方法没有任何使用
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        private void Test(SM sm)
        {
            api_ReceiveCallId(api.SendCNSM(sm.Number, sm.Message));
            this.Invoke(new Action<string>((s) =>
            {
                txt_MSG.AppendText(s + "\r\n");
            }), sm.Number + sm.Message);
        }
        private void MSMManage_Load(object sender, EventArgs e)
        {
            api = new SMSAPI();
            api.ReceiveMessage += api_ReceiveMessage;
            api.ReceiveCallId += api_ReceiveCallId;
            Thread th = new Thread(() => {
                ms = new MSMListener();
                ms.Start(Test);//客户端发送消息后展示到窗体上
                //ms.Start(api.SendCNSM);
            });
            th.TrySetApartmentState(ApartmentState.STA);
             th.Start();
        }

        private void MSMManage_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (api != null)
            {
                api.StopSMS();
            }
            if (ms != null) ms.Stop();

            System.Environment.Exit(0);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (api != null) api.StopSMS();
            if (ms != null) ms.Stop();
            Application.Exit();
        }
     
        bool serviceSta = false;
        private void startServer_Click(object sender, EventArgs e)
        {

            if (serviceSta == true)
            {
                serviceSta = false;
                startService.Text = "服务已关闭";
               
            }
            else { serviceSta = true;
            startService.Text = "服务已开启";
            
            }
            if (sendServiceThread != null)
                return;
              sendServiceThread = new Thread(() =>
            {
                while (serviceSta)
                {
                    SMSDB smddb = new SMSDB();
                    List<SMSBean> lsms = smddb.queryMessage();
                    foreach (SMSBean sb in lsms)
                    {

                        api_ReceiveCallId(api.SendCNSM(sb.number, sb.message));
                        tools.log.Debug("已发送<<" + sb.toString());
                        this.Invoke(new Action<string>((s) =>
                        {
                            txt_MSG.AppendText(s + "\r\n");
                        }), sb.number + sb.message);

                        smddb.updateMessage(sb.id);
                    }

                   
                    System.Threading.Thread.Sleep(1000);
                }
            });
            sendServiceThread.TrySetApartmentState(ApartmentState.STA);
            sendServiceThread.Start();
            /*
            reportTheread = new Thread(() =>
            {
                while (serviceSta)
                {
                    reporttask r = new reporttask();
                    r.reportTask();
                    System.Threading.Thread.Sleep(2000);
                }
            });
            reportTheread.TrySetApartmentState(ApartmentState.STA);
            sendServiceThread.Start();
            */
        }
    }
}
