using Akka.Actor;

namespace IoTMonitor.Messages
{
    public sealed class SensorRegistrationResponse: BaseMessage
    {
        public IActorRef SensorReference { get; }

        public SensorRegistrationResponse(long requestId, IActorRef sensorReference) : base(requestId)
        {
            SensorReference = sensorReference;
        }
    }
}
