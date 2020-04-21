
namespace IziLog.Records
{
    public class WarningRecord : Record
    {
        public WarningRecord(string Message) : base(Message) { }  
        public override string TypeName { get; set; } = "WARNING";
        public override string Message { get; set; }
    }
}
