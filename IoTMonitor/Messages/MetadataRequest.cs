namespace IoTMonitor.Messages
{
    public sealed class MetadataRequest
    {
        public MetadataRequest(long requestId)
        {
            RequestId = requestId;
        }

        public long RequestId { get; }
    }
}
