using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace 短信服务.Tool
{
   public class SMSDB
    {
       OracleDataReader messages;
        List<SMSBean> lsms;
  //     System.Environment.SetEnvironmentVarible("NLS_LANG "," SIMPLIFIED CHINESE_CHINA.ZHS16GBK");

//数据库操作
        public List<SMSBean> queryMessage()
        {
            SMSBean smsb; lsms = new List<SMSBean>();
            OracleConnection connection = null;
            OracleCommand command = null;
            try
            {
                //   SqlConnection connection = new SqlConnection("server= 127.0.0.1;uid=sa;pwd=esun5005;database=crmrun");
                connection = new OracleConnection(System.Configuration.ConfigurationManager.ConnectionStrings["oracle"].ConnectionString);
                //  System.Configuration.ConfigurationManager.ConnectionStrings["Default"].ConnectionString = "";
               // System.Environment.SetEnvironmentVariable("nls_lang", "AMERICAN_AMERICA.WE8ISO8859P1"); 
                System.Environment.SetEnvironmentVariable("nls_lang", "SIMPLIFIED CHINESE_CHINA.WE8ISO8859P1", EnvironmentVariableTarget.Process);  
  
                connection.Open();
                command = new OracleCommand();
                command.Connection = connection;
               // command.Parameters.Add(new SqlParameter("begin", begin));
                //command.Parameters.Add(new SqlParameter("end", end));

                command.CommandText = " SELECT  * from SMSSend where state=0 order by id desc ";

                messages = command.ExecuteReader();
                while (messages.Read())
                {
                    smsb = new SMSBean();
                    smsb.id = Convert.ToInt64(messages["id"].ToString());
                    smsb.number = messages["phonenumber"].ToString();
                    smsb.message = System.Text.Encoding.Default.GetString(System.Text.Encoding.GetEncoding("iso-8859-1").GetBytes(messages["message"].ToString()));
                    smsb.message =  messages["message"].ToString();
                   
                    smsb.state = Convert.ToInt32(messages["state"].ToString());
                    smsb.comm = Convert.ToInt32(messages["comm"].ToString());
                    lsms.Add(smsb);
                }
                return lsms;
            }
            catch (Exception ex)
            {
               // MessageBox.Show(ex.Message);
                tools.log.Debug("queryMessage报错：" + ex.Message);
                return lsms;
            }
            finally
            {
              
                if (command != null)
                    command.Dispose();
                if (connection != null) connection.Dispose();
            }

        }





        public void updateMessage(long id)
        {

            OracleConnection connection = null;
            OracleCommand command = null;
            try
            {


                //   SqlConnection connection = new SqlConnection("server= 127.0.0.1;uid=sa;pwd=esun5005;database=crmrun");
                connection = new OracleConnection(System.Configuration.ConfigurationManager.ConnectionStrings["oracle"].ConnectionString);
                connection.Open();
                command = new OracleCommand();
                command.Connection = connection;
                command.Parameters.Add(new OracleParameter(":id", id));
                //  command.Parameters.Add(new SqlParameter("isRead", isRead));

                command.CommandText = " update SMSSend set state=1 where id=:id";

                command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                tools.log.Debug("updateMessage报错：" + ex.Message);
            }
            finally
            {
                if (command != null)
                    command.Dispose();
                if (connection != null) connection.Dispose();
            }

        }






    }
}
