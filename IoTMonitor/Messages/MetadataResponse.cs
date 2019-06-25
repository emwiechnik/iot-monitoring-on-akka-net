using System;
using System.Collections.Generic;
using System.Text;

namespace IoTMonitor.Messages
{
    public sealed class MetadataResponse
    {
        public long RequestId { get; }
        public string FloorId { get; }
        public string SensorId { get; }

        public MetadataResponse(long requestId, string floorId, string sensorId)
        {
            RequestId = requestId;
            FloorId = floorId;
            SensorId = sensorId;
        }
    }
}
