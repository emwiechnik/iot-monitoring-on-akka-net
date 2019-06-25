namespace IoTMonitor.Messages
{
    public class TemperatureUpdateResponse
    {
        public long RequestId { get; }

        public TemperatureUpdateResponse(long requestId)
        {
            RequestId = requestId;
        }
    }
}
