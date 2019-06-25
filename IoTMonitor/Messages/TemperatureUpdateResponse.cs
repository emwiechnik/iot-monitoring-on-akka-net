using IoTMonitor.ValueTypes;

namespace IoTMonitor.Messages
{
    public class TemperatureUpdateResponse
    {
        public long RequestId { get; }
        public Temperature Temperature { get; }

        public TemperatureUpdateResponse(long requestId, Temperature temperature)
        {
            RequestId = requestId;
            Temperature = temperature;
        }
    }
}
