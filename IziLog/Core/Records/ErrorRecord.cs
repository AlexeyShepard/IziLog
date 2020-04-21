
namespace IziLog.Records
{
    public class ErrorRecord : Record
    {
        public ErrorRecord(string Message) : base(Message) { }
        public override string TypeName { get; set; } = "ERROR";
        public override string Message { get; set; }
    }
}
