using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IziLog.Records
{
    public abstract class Record
    {
        public Record(string Message)
        {
            this.Message = Message;
        }
        
        public abstract string TypeName { get; set; }

        public abstract string Message { get; set; }
    }
}
