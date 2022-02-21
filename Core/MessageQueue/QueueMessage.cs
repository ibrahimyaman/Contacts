namespace Core.MessageQueue
{
    public class QueueMessage<TSending, TProc>
    {
        public TProc Proccess { get; set; }
        public TSending Data { get; set; }
    }
}
