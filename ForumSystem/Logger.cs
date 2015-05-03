using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ForumSystem
{
    class Logger
    {
        private static StreamWriter log;

        public Logger()
        {
            Logger.log = new StreamWriter("log.txt");
        }

        public static void logError(string toWrite)
        {
            string line = String.Format("{0} Error: {1}",System.DateTime.Now,toWrite);
            log.WriteLine(line);
        }

        public static void logDebug(string toWrite)
        {
            string line = String.Format("{0} Debug: {1}", System.DateTime.Now, toWrite);
            log.WriteLine(line);
        }

        public static void shutDown()
        {
            log.Close();
        }
    }
}
