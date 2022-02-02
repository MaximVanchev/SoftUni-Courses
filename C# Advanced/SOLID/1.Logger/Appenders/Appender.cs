using Logger.Loggers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Appenders
{
    public abstract class Appender : IAppender
    {
        private ReportLevels reportLevels;
        protected readonly ILayout layout;
        public Appender(ILayout layout)
        {
            this.layout = layout;
        }

        public ReportLevels ReportLevel { get => reportLevels; set => reportLevels = value; }

        public abstract void Append(string dateTime, ReportLevels reportLevel, string message);

        public bool CanAppend(ReportLevels reportLevel)
        {
            return reportLevels <= reportLevel;
        }
    }
}
