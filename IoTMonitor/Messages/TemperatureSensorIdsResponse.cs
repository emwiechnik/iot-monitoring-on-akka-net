using System.Collections.Generic;

namespace IoTMonitor.Messages
{
    public sealed class TemperatureSensorIdsResponse : BaseMessage
    {
        public ISet<string> Ids { get; }

        public TemperatureSensorIdsResponse(long requestId, ISet<string> ids) : base(requestId)
        {
            Ids = ids;
        }
    }
}
