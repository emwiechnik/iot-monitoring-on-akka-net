namespace IoTMonitor.Messages
{
    public sealed class TemperatureUpdateResponse: BaseMessage
    {
        public TemperatureUpdateResponse(long requestId) : base(requestId)
        {
        }
    }
}
