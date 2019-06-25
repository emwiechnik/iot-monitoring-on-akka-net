using Akka.Actor;
using IoTMonitor.Messages;

namespace IoTMonitor.Actors
{
    public class TemperatureSensor: UntypedActor
    {
        private readonly string _floorId;
        private readonly string _sensorId;

        public TemperatureSensor(string floorId, string sensorId)
        {
            _floorId = floorId;
            _sensorId = sensorId;
        }

        protected override void OnReceive(object message)
        {
            switch (message)
            {
                case RequestMetadata m:
                    Sender.Tell(new RespondMetadata(m.RequestId, _floorId, _sensorId));
                    break;
                default:
                    break;
            }
        }

        public static Props Props(string floorId, string sensorId) => 
            Akka.Actor.Props.Create(() => new TemperatureSensor(floorId, sensorId));
    }
}
