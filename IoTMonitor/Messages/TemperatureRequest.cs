using System;
using System.Collections.Generic;
using System.Text;

namespace IoTMonitor.Messages
{
    public class TemperatureRequest
    {
        public long RequestId { get; }
        public TemperatureRequest(long requestId)
        {
            RequestId = requestId;
        }
    }
}
