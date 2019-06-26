using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Akka.Actor;
using Akka.Util.Internal;
using IoTMonitor.Messages;

namespace IoTMonitor.Actors
{
    public class Floor: UntypedActor
    {
        private readonly string _floorId;
        private readonly Dictionary<string, IActorRef> _sensors;

        public Floor(string floorId)
        {
            _floorId = floorId;
            _sensors = new Dictionary<string, IActorRef>();
        }

        protected override void OnReceive(object message)
        {
            switch (message)
            {
                case SensorRegistrationRequest m when string.Equals(m.FloorId, _floorId, StringComparison.OrdinalIgnoreCase):
                    if (_sensors.TryGetValue(m.SensorId, out IActorRef actor))
                    {
                        actor.Forward(m);
                    }
                    else
                    {
                        var newSensorActor = Context.ActorOf(TemperatureSensor.Props(m.FloorId, m.SensorId), $"TemperatureSensor{m.SensorId}");
                        Context.Watch(newSensorActor);
                        newSensorActor.Forward(m);
                        _sensors.Add(m.SensorId, newSensorActor);
                    }
                    break;
                case TemperatureSensorIdsRequest m:
                    Sender.Tell(new TemperatureSensorIdsResponse(m.RequestId, _sensors.Select(s => s.Key).ToHashSet()));
                    break;
                case Terminated m:
                    var terminatedSensor = _sensors.First(s => s.Value == m.ActorRef);
                    _sensors.Remove(terminatedSensor.Key);
                    break;
                default:
                    Unhandled(message);
                    break;
            }
        }

        public static Props Props(string floorId) => Akka.Actor.Props.Create(() => new Floor(floorId));
    }
}
