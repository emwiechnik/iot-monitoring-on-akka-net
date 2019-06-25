using System;
using System.Collections.Generic;
using System.Text;

namespace IoTMonitor.Messages
{
    public class RequestTemperature
    {
        public long RequestId { get; }
        public RequestTemperature(long requestId)
        {
            RequestId = requestId;
        }
    }
}
