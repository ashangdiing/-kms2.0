using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace 短信客户端
{
    public partial class messageBox : Form
    {
        public messageBox()
        {
            InitializeComponent();
            showMessage();
        }

        private void showMessage()
        {
            int begin, end,pageSize=15;
            begin = (Convert.ToInt32(page.Text) - 1) * pageSize;
            end = begin + pageSize;
            queryMessage(begin,end);
            
        }
        public void readerDataBase(){
        
        }
        public  void creatRow(){
            if (dataGridViewMessage.Rows.Count != 0)
            {
                dataGridViewMessage.Rows.Clear();
            }
          
            if (!messages.HasRows) {
                return;
            }
            DataGridViewRow dgvr;
            DataGridViewTextBoxCell dgvtbNum;
            DataGridViewTextBoxCell dgvtbPhone;
            DataGridViewTextBoxCell dgvtbMessage;
            DataGridViewTextBoxCell dgvtbDateTime;
            DataGridViewTextBoxCell dgvtbState;
            DataGridViewTextBoxCell dgvbDetails;
            while( messages.Read()){
                dgvr = new DataGridViewRow();
                dgvtbNum = new DataGridViewTextBoxCell();
                dgvtbNum.Value = messages["num"];
                dgvtbPhone = new DataGridViewTextBoxCell();
                dgvtbPhone.Value = messages["phone"];
                dgvtbMessage = new DataGridViewTextBoxCell();
                dgvtbMessage.Value = messages["message"];
                dgvtbDateTime = new DataGridViewTextBoxCell();
                dgvtbDateTime.Value = messages["dateTime"];
                dgvtbState = new DataGridViewTextBoxCell();
                dgvtbState.Value = messages["state"];

                dgvbDetails = new DataGridViewTextBoxCell();
                 dgvbDetails.Value = messages["id"];
                
                 if (Convert.ToBoolean(messages["isRead"])) {
                     dgvr.DefaultCellStyle.ForeColor = System.Drawing.Color.Red;   
                 }
                dgvr.Cells.AddRange(new DataGridViewCell[]{
                    dgvtbNum,
            dgvtbPhone,
            dgvtbMessage,
            dgvtbDateTime,
            dgvtbState,
            dgvbDetails
                     });
                this.dataGridViewMessage.Rows.Add(dgvr);
            }


           
        }


        SqlDataReader messages;
        public void  queryMessage( int begin, int end)
        {

            SqlConnection connection = null;
            SqlCommand command = null; 
            try
            {
                //   SqlConnection connection = new SqlConnection("server= 127.0.0.1;uid=sa;pwd=esun5005;database=crmrun");
                connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Default"].ConnectionString);
              //  System.Configuration.ConfigurationManager.ConnectionStrings["Default"].ConnectionString = "";
              
                connection.Open();
                command = new SqlCommand();
                command.Connection = connection;
                command.Parameters.Add(new SqlParameter("begin", begin));
                command.Parameters.Add(new SqlParameter("end", end));

                command.CommandText = " SELECT  * from (SELECT row_number() over(order by id desc ) as num,id,number as phone,message,case  state  when '0' then '发送' when '1' then '接收'  end as state,datetime as dateTime,isRead  from SMS ) temp where num between  @begin and @end";

                 messages = command.ExecuteReader();
                 creatRow();
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
            
        }
        public void updateMessage(int id)
        {

            SqlConnection connection = null;
            SqlCommand command = null;
            try
            {


                //   SqlConnection connection = new SqlConnection("server= 127.0.0.1;uid=sa;pwd=esun5005;database=crmrun");
                connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Default"].ConnectionString);
                connection.Open();
                command = new SqlCommand();
                command.Connection = connection;
                command.Parameters.Add(new SqlParameter("id", id));
              //  command.Parameters.Add(new SqlParameter("isRead", isRead));

                command.CommandText = " update SMS set isRead=0 where id=@id";

               command.ExecuteNonQuery();
               
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

        }

        private void upPage_Click(object sender, EventArgs e)
        {
            int pageTemp;
            pageTemp = Convert.ToInt32(page.Text);
            if (pageTemp < 2) {
                page.Text = "1";
            }
            else page.Text = Convert.ToString(pageTemp - 1);
            showMessage();
        }

        private void nextPage_Click(object sender, EventArgs e)
        {
            int pageTemp;
            pageTemp = Convert.ToInt32(page.Text);
           page.Text = Convert.ToString(pageTemp +1);
            showMessage();
        }
        public details detaialsBox = new details();
        private void dataGridViewMessage_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) {
                DataGridViewRow row = dataGridViewMessage.Rows[e.RowIndex];
                //if (column is DataGridViewButtonColumn) { }

                string phone = row.Cells["phone"].Value.ToString();
                string message="";
                if (!string.IsNullOrEmpty(row.Cells["message"].Value.ToString()))
                {
                     message = row.Cells["message"].Value.ToString();
                }
                string dateTIme = row.Cells["dateTIme"].Value.ToString();
                string state = row.Cells["state"].Value.ToString();
                string id = row.Cells["id"].Value.ToString();
            //    MessageBox.Show(phone + "---" + id);
               // return;
                if(detaialsBox!=null){
                    detaialsBox = new details();
                    System.Windows.Forms.TextBox phoneTextBox = detaialsBox.Controls["phone"] as System.Windows.Forms.TextBox;
                    System.Windows.Forms.TextBox messageTextBox = detaialsBox.Controls["message"] as System.Windows.Forms.TextBox;
                    System.Windows.Forms.TextBox dateTImeTextBox = detaialsBox.Controls["dateTIme"] as System.Windows.Forms.TextBox;
                    System.Windows.Forms.TextBox stateTextBox = detaialsBox.Controls["state"] as System.Windows.Forms.TextBox;
                    System.Windows.Forms.TextBox idTextBox = detaialsBox.Controls["id"] as System.Windows.Forms.TextBox;
                  
                    phoneTextBox.Text = phone;
                    messageTextBox.Text = message;
                    dateTImeTextBox.Text = dateTIme;
                    stateTextBox.Text = state;
                    detaialsBox.Show();
                    updateMessage(Convert.ToInt32(id));
                    row.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;   
                }
            
            }
        }


    }
}
