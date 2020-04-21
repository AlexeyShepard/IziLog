using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IziLog
{
    public class LoggerServer
    {
        private static Queue<string> RecordsQueue = new Queue<string>(10000000);

        public static void AddToQueue(string RecordContent)
        {
            RecordsQueue.Enqueue(RecordContent);  
        }

        public static string GetRecord()
        {
            return RecordsQueue.Dequeue();
        }

        public static void Start()
        {
            Task ServerTask = new Task(() => ServerWork());
            ServerTask.Start();
        }

        public static void ServerWork()
        {
            while (true)
            {
                Thread.Sleep(Configuration.DelayBetweenRecord);                
                if (RecordsQueue.Count != 0) WriteRecordToLog(GetRecord());
            }
        }

        private static void WriteRecordToLog(string RecordContent)
        {
            using (FileStream FileStream = new FileStream(Configuration.PathToLogFile, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite))
            {
                FileStream.Seek(0, SeekOrigin.End);

                byte[] array = Encoding.Default.GetBytes(RecordContent);

                FileStream.Write(array, 0, array.Length);
            }
        }
    }
}
