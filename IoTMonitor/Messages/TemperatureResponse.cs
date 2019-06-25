using IoTMonitor.ValueObjects;

namespace IoTMonitor.Messages
{
    public class TemperatureResponse
    {
        public long RequestId { get; }
        public Temperature Temperature { get; }

        public TemperatureResponse(long requestId, Temperature temperature)
        {
            RequestId = requestId;
            Temperature = temperature;
        }
    }
}
