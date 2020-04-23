using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using IziLog.Records;

namespace IziLog
{
    public static class Logger
    {
        
        public static void Log(Record Record)
        {
            Thread.Sleep(Configuration.DelayBeforeRecord);
            Task LogTask = new Task(() => LogProcess(Record));
            LogTask.Start();
        }
        
        private static void LogProcess(Record Record)
        {
            try
            {
                if (IsLogExist())
                {               
                    DateTime CurrentTime = DateTime.Now;
                    string RecordContent = "";                 
                    RecordContent += CurrentTime.ToString("dd.MM.yyyy H:mm:ss.fffffff") + " | ";
                    RecordContent += Record.TypeName + " |";
                    RecordContent += " " + Record.Message + "\n";

                    LoggerServer.AddToQueue(RecordContent);
                }
                else
                {
                    CreateFile();
                    Log(Record);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }           
        }

        private static bool IsLogExist()
        {
            return File.Exists(Configuration.PathToLogFile);
        }

        private static void CreateFile()
        {
            try
            {
                TimeSpan Offset = new TimeSpan(Configuration.FileRotation, 0, 0, 0);

                DateTime TimeToDelete = DateTime.Now - Offset;

                File.Delete("C:\\ProgramData\\LOM\\Lom_" + TimeToDelete.ToString("yyyy-MM-dd") + ".log");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
           
            try
            {                          
                
                using (FileStream FileStream = new FileStream(Configuration.PathToLogFile, FileMode.OpenOrCreate)) { }

                Log(new InfoRecord("Создание файла конфигурации"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}    
