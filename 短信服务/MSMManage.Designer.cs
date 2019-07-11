namespace 短信服务
{
    partial class MSMManage
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MSMManage));
            this.txt_MSG = new System.Windows.Forms.TextBox();
            this.txt_CallId = new System.Windows.Forms.TextBox();
            this.btn_OpenConn = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btn_Send = new System.Windows.Forms.Button();
            this.txt_Number = new System.Windows.Forms.TextBox();
            this.txt_Message = new System.Windows.Forms.TextBox();
            this.btn_Reg = new System.Windows.Forms.Button();
            this.txt_Reg = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.comsSelect = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.startService = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txt_MSG
            // 
            this.txt_MSG.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_MSG.BackColor = System.Drawing.SystemColors.Window;
            this.txt_MSG.Location = new System.Drawing.Point(94, 334);
            this.txt_MSG.Multiline = true;
            this.txt_MSG.Name = "txt_MSG";
            this.txt_MSG.ReadOnly = true;
            this.txt_MSG.Size = new System.Drawing.Size(895, 89);
            this.txt_MSG.TabIndex = 0;
            // 
            // txt_CallId
            // 
            this.txt_CallId.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_CallId.BackColor = System.Drawing.SystemColors.Window;
            this.txt_CallId.Location = new System.Drawing.Point(94, 128);
            this.txt_CallId.Multiline = true;
            this.txt_CallId.Name = "txt_CallId";
            this.txt_CallId.ReadOnly = true;
            this.txt_CallId.Size = new System.Drawing.Size(907, 200);
            this.txt_CallId.TabIndex = 1;
            // 
            // btn_OpenConn
            // 
            this.btn_OpenConn.Location = new System.Drawing.Point(428, 12);
            this.btn_OpenConn.Name = "btn_OpenConn";
            this.btn_OpenConn.Size = new System.Drawing.Size(75, 23);
            this.btn_OpenConn.TabIndex = 2;
            this.btn_OpenConn.Text = "打开连接";
            this.btn_OpenConn.UseVisualStyleBackColor = true;
            this.btn_OpenConn.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(550, 11);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(126, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "初始化短信模块";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btn_Send
            // 
            this.btn_Send.Location = new System.Drawing.Point(885, 18);
            this.btn_Send.Name = "btn_Send";
            this.btn_Send.Size = new System.Drawing.Size(75, 23);
            this.btn_Send.TabIndex = 4;
            this.btn_Send.Text = "发送";
            this.btn_Send.UseVisualStyleBackColor = true;
            this.btn_Send.Click += new System.EventHandler(this.button3_Click);
            // 
            // txt_Number
            // 
            this.txt_Number.Location = new System.Drawing.Point(772, 18);
            this.txt_Number.Name = "txt_Number";
            this.txt_Number.Size = new System.Drawing.Size(98, 21);
            this.txt_Number.TabIndex = 5;
            this.txt_Number.Text = "18627283312";
            // 
            // txt_Message
            // 
            this.txt_Message.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Message.Location = new System.Drawing.Point(94, 78);
            this.txt_Message.Multiline = true;
            this.txt_Message.Name = "txt_Message";
            this.txt_Message.Size = new System.Drawing.Size(898, 44);
            this.txt_Message.TabIndex = 6;
            this.txt_Message.Text = "测试短信";
            // 
            // btn_Reg
            // 
            this.btn_Reg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Reg.Location = new System.Drawing.Point(142, 12);
            this.btn_Reg.Name = "btn_Reg";
            this.btn_Reg.Size = new System.Drawing.Size(75, 23);
            this.btn_Reg.TabIndex = 7;
            this.btn_Reg.Text = "注册";
            this.btn_Reg.UseVisualStyleBackColor = true;
            this.btn_Reg.Click += new System.EventHandler(this.button4_Click);
            // 
            // txt_Reg
            // 
            this.txt_Reg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Reg.Location = new System.Drawing.Point(12, 14);
            this.txt_Reg.Name = "txt_Reg";
            this.txt_Reg.Size = new System.Drawing.Size(124, 21);
            this.txt_Reg.TabIndex = 8;
            this.txt_Reg.Text = "zwdigital";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(691, 16);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "注销";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // comsSelect
            // 
            this.comsSelect.FormattingEnabled = true;
            this.comsSelect.Items.AddRange(new object[] {
            "com1",
            "com2",
            "com3",
            "com4",
            "com5",
            "com6",
            "com7",
            "com8"});
            this.comsSelect.Location = new System.Drawing.Point(301, 13);
            this.comsSelect.Name = "comsSelect";
            this.comsSelect.Size = new System.Drawing.Size(121, 20);
            this.comsSelect.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(223, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 11;
            this.label1.Text = "com口选择：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 12;
            this.label2.Text = "测试短信类容：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 198);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 13;
            this.label3.Text = "输出信息：";
            // 
            // startService
            // 
            this.startService.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.startService.Location = new System.Drawing.Point(26, 41);
            this.startService.Name = "startService";
            this.startService.Size = new System.Drawing.Size(75, 23);
            this.startService.TabIndex = 14;
            this.startService.Text = "开始服务";
            this.startService.UseVisualStyleBackColor = true;
            this.startService.Click += new System.EventHandler(this.startServer_Click);
            // 
            // MSMManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1001, 424);
            this.Controls.Add(this.startService);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comsSelect);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txt_Reg);
            this.Controls.Add(this.btn_Reg);
            this.Controls.Add(this.txt_Message);
            this.Controls.Add(this.txt_Number);
            this.Controls.Add(this.btn_Send);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btn_OpenConn);
            this.Controls.Add(this.txt_CallId);
            this.Controls.Add(this.txt_MSG);
            this.Name = "MSMManage";
            this.Text = "短信服务端";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MSMManage_FormClosing);
            this.Load += new System.EventHandler(this.MSMManage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_MSG;
        private System.Windows.Forms.TextBox txt_CallId;
        private System.Windows.Forms.Button btn_OpenConn;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btn_Send;
        private System.Windows.Forms.TextBox txt_Number;
        private System.Windows.Forms.TextBox txt_Message;
        private System.Windows.Forms.Button btn_Reg;
        private System.Windows.Forms.TextBox txt_Reg;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ComboBox comsSelect;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button startService;

    }
}

