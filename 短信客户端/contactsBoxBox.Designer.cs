namespace 短信客户端
{
    partial class contactsBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(contactsBox));
            this.dataGridViewContacts = new System.Windows.Forms.DataGridView();
            this.upPage = new System.Windows.Forms.Button();
            this.nextPage = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.page = new System.Windows.Forms.TextBox();
            this.num = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewContacts)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewContacts
            // 
            this.dataGridViewContacts.AllowUserToOrderColumns = true;
            this.dataGridViewContacts.AllowUserToResizeColumns = false;
            this.dataGridViewContacts.AllowUserToResizeRows = false;
            this.dataGridViewContacts.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewContacts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewContacts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.num,
            this.name,
            this.phone,
            this.id});
            this.dataGridViewContacts.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewContacts.Name = "dataGridViewContacts";
            this.dataGridViewContacts.RowHeadersVisible = false;
            this.dataGridViewContacts.RowTemplate.Height = 23;
            this.dataGridViewContacts.Size = new System.Drawing.Size(515, 203);
            this.dataGridViewContacts.TabIndex = 0;
         //   this.dataGridViewContacts.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewMessage_CellClick);
            // 
            // upPage
            // 
            this.upPage.Location = new System.Drawing.Point(87, 209);
            this.upPage.Name = "upPage";
            this.upPage.Size = new System.Drawing.Size(75, 23);
            this.upPage.TabIndex = 1;
            this.upPage.Text = "上一页";
            this.upPage.UseVisualStyleBackColor = true;
            this.upPage.Click += new System.EventHandler(this.upPage_Click);
            // 
            // nextPage
            // 
            this.nextPage.Location = new System.Drawing.Point(425, 209);
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
            this.label1.Location = new System.Drawing.Point(199, 214);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "第";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(345, 214);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "页";
            // 
            // page
            // 
            this.page.Location = new System.Drawing.Point(234, 211);
            this.page.Name = "page";
            this.page.Size = new System.Drawing.Size(95, 21);
            this.page.TabIndex = 7;
            this.page.Text = "1";
            // 
            // num
            // 
            this.num.HeaderText = "编号";
            this.num.Name = "num";
            this.num.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.num.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.num.Width = 60;
            // 
            // name
            // 
            this.name.HeaderText = "姓名";
            this.name.Name = "name";
            this.name.Width = 150;
            // 
            // phone
            // 
            this.phone.HeaderText = "电话";
            this.phone.Name = "phone";
            this.phone.Width = 300;
            // 
            // id
            // 
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.Visible = false;
            // 
            // contactsBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 327);
            this.Controls.Add(this.page);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nextPage);
            this.Controls.Add(this.upPage);
            this.Controls.Add(this.dataGridViewContacts);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "contactsBox";
            this.Text = "messageBox";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewContacts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewContacts;
        private System.Windows.Forms.Button upPage;
        private System.Windows.Forms.Button nextPage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox page;
        private System.Windows.Forms.DataGridViewCheckBoxColumn num;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn phone;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
    }
}