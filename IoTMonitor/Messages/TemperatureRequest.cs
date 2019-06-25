namespace IoTMonitor.Messages
{
    public sealed class TemperatureRequest: BaseMessage
    {
        public TemperatureRequest(long requestId) : base(requestId)
        {
        }
    }
}
