using Logger.Loggers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger
{
    public interface IAppender
    {
        void Append(string dateTime, ReportLevels reportLevel, string message);
        ReportLevels ReportLevel { get; set; }
        bool CanAppend(ReportLevels reportLevel);
    }
}
