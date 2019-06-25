namespace IoTMonitor.Messages
{
    public sealed class SensorRegistrationRequest: BaseMessage
    {
        public string FloorId { get; }
        public string SensorId { get; }

        public SensorRegistrationRequest(long requestId, string floorId, string sensorId) : base(requestId)
        {
            FloorId = floorId;
            SensorId = sensorId;
        }
    }
}
