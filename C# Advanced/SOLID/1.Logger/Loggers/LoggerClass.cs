using Logger.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Loggers
{
    public class LoggerClass : ILogger
    {
        private readonly IAppender[] appenders;
        public LoggerClass(params IAppender[] appenders)
        {
            this.appenders = appenders;
        }

        public void Critical(string date, string message)
        {
            AppendToAppenders(date, ReportLevels.Critical, message);
        }

        public void Error(string date, string message)
        {
            AppendToAppenders(date, ReportLevels.Error, message);
        }

        public void Fatal(string date, string message)
        {
            AppendToAppenders(date, ReportLevels.Fatal, message);
        }

        public void Info(string date, string message)
        {
            AppendToAppenders(date, ReportLevels.Info, message);
        }

        public void Warning(string date, string message)
        {
            AppendToAppenders(date, ReportLevels.Warning, message);
        }
        private void AppendToAppenders(string date, ReportLevels reportLevel, string message)
        {
            foreach (var item in appenders)
            {
                if (item.CanAppend(reportLevel))
                {
                    item.Append(date, reportLevel, message);
                }
            }
        }
    }
}
