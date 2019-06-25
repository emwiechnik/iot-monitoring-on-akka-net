using Akka.Actor;
using IoTMonitor.Messages;
using IoTMonitor.ValueObjects;

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
                case MetadataRequest m:
                    Sender.Tell(new MetadataResponse(m.RequestId, _floorId, _sensorId));
                    break;
                case TemperatureRequest m:
                    Sender.Tell(new TemperatureResponse(m.RequestId, _lastRecordedTemperature));
                    break;
                case TemperatureUpdateRequest m:
                    _lastRecordedTemperature = m.NewTemperature;
                    Sender.Tell(new TemperatureUpdateResponse(m.RequestId));
                    break;
                default:
                    break;
            }
        }

        public static Props Props(string floorId, string sensorId) => 
            Akka.Actor.Props.Create(() => new TemperatureSensor(floorId, sensorId));
    }
}
