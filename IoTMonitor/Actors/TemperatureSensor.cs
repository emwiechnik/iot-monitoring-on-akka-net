using Akka.Actor;
using IoTMonitor.Messages;
using IoTMonitor.ValueTypes;

namespace IoTMonitor.Actors
{
    public class TemperatureSensor: UntypedActor
    {
        private readonly string _floorId;
        private readonly string _sensorId;
        private Temperature _lastRecordedTemperature;

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
                case RequestTemperature m:
                    Sender.Tell(new RespondTemperature(m.RequestId, _lastRecordedTemperature));
                    break;
                default:
                    break;
            }
        }

        public static Props Props(string floorId, string sensorId) => 
            Akka.Actor.Props.Create(() => new TemperatureSensor(floorId, sensorId));
    }
}
