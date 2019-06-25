namespace IoTMonitor.Messages
{
    public sealed class MetadataRequest: BaseMessage
    {
        public MetadataRequest(long requestId) : base(requestId)
        {
        }
    }
}
