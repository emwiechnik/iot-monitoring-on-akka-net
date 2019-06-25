using System;
using System.Collections.Generic;
using System.Text;

namespace IoTMonitor.Messages
{
    public sealed class RespondMetadata
    {
        public long RequestId { get; }
        public string FloorId { get; }
        public string SensorId { get; }

        public RespondMetadata(long requestId, string floorId, string sensorId)
        {
            RequestId = requestId;
            FloorId = floorId;
            SensorId = sensorId;
        }
    }
}
