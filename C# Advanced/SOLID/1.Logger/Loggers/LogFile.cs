using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Logger.Loggers
{
    public class LogFile : ILogFile
    {
        private string filePath = "../../../log.txt";
        public int Size => File.ReadAllText(filePath).Where(x => char.IsLetter(x)).Sum(x => x);

        public void Write(string content)
        {
            File.AppendAllText(filePath, content);
        }
    }
}
