using IoTMonitor.ValueObjects;

namespace IoTMonitor.Messages
{
    public class TemperatureUpdateRequest
    {
        public long RequestId { get; }
        public Temperature NewTemperature { get; }

        public TemperatureUpdateRequest(long requestId, Temperature newTemperature)
        {
            RequestId = requestId;
            NewTemperature = newTemperature;
        }
    }
}
