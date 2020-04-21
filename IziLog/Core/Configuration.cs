using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IziLog
{
    public static class Configuration
    {

        private static string _PathToLogFile;

        public static int DelayBeforeRecord = 10;

        public static int DelayBetweenRecord = 20;

        public static string PathToLogFile
        {
            get
            {
                if (_PathToLogFile == null) throw new NullReferenceException();
                else return _PathToLogFile;
            }
            set { _PathToLogFile = value; }
        }
    }
}
