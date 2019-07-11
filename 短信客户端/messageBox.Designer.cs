namespace 短信客户端
{
    partial class messageBox
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(messageBox));
            this.dataGridViewMessage = new System.Windows.Forms.DataGridView();
            this.num = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.message = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateTIme = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.state = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.upPage = new System.Windows.Forms.Button();
            this.nextPage = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.page = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMessage)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewMessage
            // 
            this.dataGridViewMessage.AllowUserToAddRows = false;
            this.dataGridViewMessage.AllowUserToDeleteRows = false;
            this.dataGridViewMessage.AllowUserToResizeColumns = false;
            this.dataGridViewMessage.AllowUserToResizeRows = false;
            this.dataGridViewMessage.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewMessage.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMessage.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.num,
            this.phone,
            this.message,
            this.dateTIme,
            this.state,
            this.id});
            this.dataGridViewMessage.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewMessage.Name = "dataGridViewMessage";
            this.dataGridViewMessage.ReadOnly = true;
            this.dataGridViewMessage.RowHeadersVisible = false;
            this.dataGridViewMessage.RowTemplate.Height = 23;
            this.dataGridViewMessage.Size = new System.Drawing.Size(865, 287);
            this.dataGridViewMessage.TabIndex = 0;
            this.dataGridViewMessage.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewMessage_CellClick);
            // 
            // num
            // 
            this.num.HeaderText = "编号";
            this.num.Name = "num";
            this.num.ReadOnly = true;
            this.num.Width = 60;
            // 
            // phone
            // 
            this.phone.HeaderText = "电话";
            this.phone.Name = "phone";
            this.phone.ReadOnly = true;
            this.phone.Width = 150;
            // 
            // message
            // 
            this.message.HeaderText = "类容";
            this.message.Name = "message";
            this.message.ReadOnly = true;
            this.message.Width = 450;
            // 
            // dateTIme
            // 
            this.dateTIme.HeaderText = "日期";
            this.dateTIme.Name = "dateTIme";
            this.dateTIme.ReadOnly = true;
            // 
            // state
            // 
            this.state.HeaderText = "接受/发送";
            this.state.Name = "state";
            this.state.ReadOnly = true;
            // 
            // id
            // 
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // upPage
            // 
            this.upPage.Location = new System.Drawing.Point(317, 294);
            this.upPage.Name = "upPage";
            this.upPage.Size = new System.Drawing.Size(75, 23);
            this.upPage.TabIndex = 1;
            this.upPage.Text = "上一页";
            this.upPage.UseVisualStyleBackColor = true;
            this.upPage.Click += new System.EventHandler(this.upPage_Click);
            // 
            // nextPage
            // 
            this.nextPage.Location = new System.Drawing.Point(682, 293);
            this.nextPage.Name = "nextPage";
            this.nextPage.Size = new System.Drawing.Size(75, 23);
            this.nextPage.TabIndex = 3;
            this.nextPage.Text = "下一页";
            this.nextPage.UseVisualStyleBackColor = true;
            this.nextPage.Click += new System.EventHandler(this.nextPage_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(423, 299);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "第";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(547, 299);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "页";
            // 
            // page
            // 
            this.page.Location = new System.Drawing.Point(446, 290);
            this.page.Name = "page";
            this.page.Size = new System.Drawing.Size(95, 21);
            this.page.TabIndex = 7;
            this.page.Text = "1";
            // 
            // messageBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(875, 316);
            this.Controls.Add(this.page);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nextPage);
            this.Controls.Add(this.upPage);
            this.Controls.Add(this.dataGridViewMessage);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "messageBox";
            this.Text = "messageBox";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMessage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewMessage;
        private System.Windows.Forms.Button upPage;
        private System.Windows.Forms.Button nextPage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox page;
        private System.Windows.Forms.DataGridViewTextBoxColumn num;
        private System.Windows.Forms.DataGridViewTextBoxColumn phone;
        private System.Windows.Forms.DataGridViewTextBoxColumn message;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateTIme;
        private System.Windows.Forms.DataGridViewTextBoxColumn state;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
    }
}