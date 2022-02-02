using Logger.Appenders;
using Logger.Interfaces;
using Logger.Layouts;
using Logger.Loggers;
using System;

namespace Logger
{
    public class Program
    {
        static void Main(string[] args)
        {
            var simpleLayout = new SimpleLayout();
            var consoleAppender = new ConsoleAppender(simpleLayout);
            var file = new LogFile();
            var fileAppender = new FileAppender(simpleLayout, file);
            var logger = new LoggerClass(consoleAppender, fileAppender);
            logger.Error("3 / 26 / 2015 2:08:11 PM", "Error parsing JSON.");
            logger.Info("3 / 26 / 2015 2:08:11 PM", "User Pesho successfully registered.");
        }
    }
}
