
namespace IziLog.Records
{
    public class InfoRecord : Record
    {
        public InfoRecord(string Message) : base(Message) { }
        public override string TypeName { get; set; } = "INFO";
        public override string Message { get; set; }
    }
}
