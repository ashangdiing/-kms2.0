using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Text;

namespace 短信服务.Tool
{
    class reporttask
    {

        public void reportTask()
        {
            int total=0;

            OracleConnection connection = null;
            OracleCommand command = null;
            try
            {


                //   SqlConnection connection = new SqlConnection("server= 127.0.0.1;uid=sa;pwd=esun5005;database=crmrun");
                connection = new OracleConnection(System.Configuration.ConfigurationManager.ConnectionStrings["oracle"].ConnectionString);
                connection.Open();
                command = new OracleCommand();
                command.Connection = connection;
               // command.Parameters.Add(new OracleParameter(":id", id));
                //  command.Parameters.Add(new SqlParameter("isRead", isRead));

                command.CommandText = "procedureManyidu";
                command.CommandType = CommandType.StoredProcedure;
                total=command.ExecuteNonQuery();
                tools.log.Debug("影响行数：" +total);
            }
            catch (Exception ex)
            {
                tools.log.Debug("执行任务报错：" + ex.Message);
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
