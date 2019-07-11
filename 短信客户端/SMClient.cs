using PublicApi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using 短信客户端.Tool;

namespace 短信客户端
{
    public partial class SMClient : Form
    {
        public SMClient()
        {
            InitializeComponent();
        }
        SMTcpClient Client;
        private void SMClient_Load(object sender, EventArgs e)
        {
            Client = new SMTcpClient();
            Client.Receive += Client_Receive;
            try{
           Client.Start();
            }
                catch(Exception ex){
                    MessageBox.Show(ex.Message);
                }
            wb_Msg.Url = new Uri(System.AppDomain.CurrentDomain.BaseDirectory + "Message.html");
        }
        [System.Runtime.InteropServices.DllImport("user32.dll", EntryPoint = "SetForegroundWindow")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);
        void Client_Receive(SM obj)
        {
            if (this.Visible == false) {
                this.Show();
                this.WindowState = FormWindowState.Normal;
               
                SetForegroundWindow(this.Handle);
            }
            this.Invoke(new Action<SM>((msg) =>
            {
                wb_Msg.Document.InvokeScript("AddMessage", new object[] { msg.Number, msg.Message, "0" });
            }), obj);
        }

        private void btn_Send_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_Number.Text))
            {
                MessageBox.Show("请输入发送的电话号码！"); return;
            }
            if (string.IsNullOrEmpty(txt_Send.Text))
            {
                MessageBox.Show("请输入发送的消息！"); return;
            }
            string[] number = Regex.Split(txt_Number.Text, "[^\\d]");
            foreach (string item in number)
            {
                if (!string.IsNullOrEmpty(item.Trim()))
                {
                    SM sm = new SM();
                    sm.Type = "msg";
                    sm.Number = item.Trim();
                    sm.Message = txt_Send.Text;
                    Client.SendMessage(sm);
                    wb_Msg.Document.InvokeScript("AddMessage", new object[] { item.Trim(), txt_Send.Text, "1" });
                    //Thread.Sleep(1000);
                }
            }
            //MessageBox.Show("发送成功！");
        }

        private void SMClient_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Client != null) Client.Stop();
        }
        public messageBox mb;
        private void showMessage_Click(object sender, EventArgs e)
        {
            if (mb == null) {
                mb = new messageBox();
               
            }
            mb.ShowDialog();

        }

        private void SMClient_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)    //最小化到系统托盘
            {
                notifyIcon1.Visible = true;    //显示托盘图标
                this.Hide();    //隐藏窗口
            }
        }

        private void close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void callMain_Click(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                return;
            this.Show();
            this.WindowState = FormWindowState.Normal;
            SetForegroundWindow(this.Handle);
        }

        private void callHistory_Click(object sender, EventArgs e)
        {
            if (mb == null)
            {
                mb = new messageBox();

            }
            mb.ShowDialog();
        }
        public contactsBox cb;
        private void callContacts_Click(object sender, EventArgs e)
        {
            if (cb == null)
            {
                cb = new contactsBox();

            }
            cb.ShowDialog();
        }
    }
}
