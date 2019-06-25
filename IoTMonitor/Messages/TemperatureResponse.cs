using IoTMonitor.ValueObjects;

namespace IoTMonitor.Messages
{
    public sealed class TemperatureResponse: BaseMessage
    {
        public Temperature Temperature { get; }

        public TemperatureResponse(long requestId, Temperature temperature): base(requestId)
        {
            Temperature = temperature;
        }
    }
}
