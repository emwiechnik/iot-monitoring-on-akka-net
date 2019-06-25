namespace IoTMonitor.Messages
{
    public abstract class BaseMessage
    {
        public long RequestId { get; }

        protected BaseMessage(long requestId)
        {
            RequestId = requestId;
        }
    }
}