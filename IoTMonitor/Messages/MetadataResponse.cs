﻿namespace IoTMonitor.Messages
{
    public sealed class MetadataResponse: BaseMessage
    {
        public string FloorId { get; }
        public string SensorId { get; }

        public MetadataResponse(long requestId, string floorId, string sensorId) : base(requestId)
        {
            FloorId = floorId;
            SensorId = sensorId;
        }
    }
}
