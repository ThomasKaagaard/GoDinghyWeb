using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Xml;

namespace GoDinghy.app.Classes.Helpers
{
    public class LogfileHelper
    {

        public static void MemberLog(string user, string function)
        {
            StreamWriter writer = null;
            StringBuilder strBuilder = null;
            var dir = AppDomain.CurrentDomain.BaseDirectory + "/App_Data/Logs"; 
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            var path = Path.Combine(dir, "Login-out-log") + ".txt";
            strBuilder = new StringBuilder();
            strBuilder.AppendLine(function + " - " + DateTime.Now + " BY: " + user);

            writer = new StreamWriter(path, true);
            writer.Write(strBuilder);
            writer.Close();
        }

        
    }
}