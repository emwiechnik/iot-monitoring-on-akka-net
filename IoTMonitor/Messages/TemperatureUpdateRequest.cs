using IoTMonitor.ValueObjects;

namespace IoTMonitor.Messages
{
    public sealed class TemperatureUpdateRequest: BaseMessage
    {
        public Temperature NewTemperature { get; }

        public TemperatureUpdateRequest(long requestId, Temperature newTemperature): base(requestId)
        {
            NewTemperature = newTemperature;
        }
    }
}
