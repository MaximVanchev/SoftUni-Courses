using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Layouts
{
    public class XmlLayout : ILayout
    {
        public string LayoutString(string dateTime, string reportLevel, string message)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<log>");
            sb.AppendLine($"<date>{dateTime}</date>");
            sb.AppendLine($"<level>{reportLevel}</level>");
            sb.AppendLine($"<message>{message}</message>");
            sb.AppendLine("</log>");
            return sb.ToString();
        }
    }
}
