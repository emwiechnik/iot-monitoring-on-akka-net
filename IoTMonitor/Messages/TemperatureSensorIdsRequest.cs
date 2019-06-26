namespace IoTMonitor.Messages
{
    public sealed class TemperatureSensorIdsRequest : BaseMessage
    {
        public TemperatureSensorIdsRequest(long requestId) : base(requestId)
        {
        }
    }
}
