using Logger.Interfaces;
using Logger.Loggers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Appenders
{
    class ConsoleAppender : Appender
    {
        public ConsoleAppender(ILayout layout)
            : base(layout)
        {

        }
        public override void Append(string dateTime, ReportLevels reportLevel, string message)
        {
            Console.WriteLine(layout.LayoutString(dateTime, reportLevel.ToString(), message));
        }
    }
}
