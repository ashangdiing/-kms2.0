using System;
using System.Collections.Generic;
using System.Text;

namespace 短信服务.Tool
{
  public  class SMSBean
    {
        public  long id;
        public string number;
        public string message;
        public int state;
        public DateTime datetime;
       public int isRead ;
       public int comm=1;
       public string toString() {
           return "id>" + id + "    号码>" + number + "   发送内容>" + message + "   com口>" + comm;
       }
    }
}
