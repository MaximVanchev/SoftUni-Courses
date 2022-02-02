using Logger.Loggers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Logger.Appenders
{
    public class FileAppender : Appender
    {
        private ILogFile logFile;
        public FileAppender(ILayout layout, ILogFile logFile)
            : base(layout)
        {
            this.logFile = logFile;
        }

        public override void Append(string dateTime, ReportLevels reportLevel, string message)
        {
            string content = layout.LayoutString(dateTime, reportLevel.ToString(), message) + Environment.NewLine;
            logFile.Write(content);
        }
    }
}
