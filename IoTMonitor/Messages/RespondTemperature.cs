using IoTMonitor.ValueTypes;

namespace IoTMonitor.Messages
{
    public class RespondTemperature
    {
        public long RequestId { get; }
        public Temperature Temperature { get; }

        public RespondTemperature(long requestId, Temperature temperature)
        {
            RequestId = requestId;
            Temperature = temperature;
        }
    }
}
