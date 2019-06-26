using System.Runtime.InteropServices.ComTypes;
using Akka.Actor;
using Akka.TestKit.Xunit2;
using IoTMonitor.Actors;
using IoTMonitor.Messages;
using IoTMonitor.ValueObjects;
using Xunit;

namespace IoTMonitor.Tests
{
    public class FloorShould : TestKit
    {
        [Fact]
        public void Register_New_Temperature_Sensor_When_It_Does_Not_Exist_Yet()
        {
            var probe = CreateTestProbe();

            var floor = Sys.ActorOf(Floor.Props("A"));

            floor.Tell(new SensorRegistrationRequest(1, "A", "123"), probe.Ref);
            var received = probe.ExpectMsg<SensorRegistrationResponse>();

            Assert.Equal(1, received.RequestId);

            var sensorActor = probe.LastSender;
            sensorActor.Tell(new TemperatureUpdateRequest(2, new Temperature(100)), probe.Ref);
            probe.ExpectMsg<TemperatureUpdateResponse>();

        }

        [Fact]
        public void Return_Existing_Temperature_Sensor_When_ReRegistering_Same_Sensor()
        {
            var probe = CreateTestProbe();

            var floor = Sys.ActorOf(Floor.Props("A"));

            floor.Tell(new SensorRegistrationRequest(1, "A", "123"), probe.Ref);
            var received = probe.ExpectMsg<SensorRegistrationResponse>();

            Assert.Equal(1, received.RequestId);

            var firstSensor = probe.LastSender;

            floor.Tell(new SensorRegistrationRequest(2, "A", "123"), probe.Ref);
            received = probe.ExpectMsg<SensorRegistrationResponse>();

            Assert.Equal(2, received.RequestId);

            var secondSensor = probe.LastSender;

            Assert.Equal(firstSensor, secondSensor);
        }

        [Fact]
        public void Not_Register_Sensor_If_Floor_Does_Not_Match()
        {
            var probe = CreateTestProbe();
            var eventStreamProbe = CreateTestProbe();

            var floor = Sys.ActorOf(Floor.Props("A"));
            Sys.EventStream.Subscribe(eventStreamProbe, typeof(Akka.Event.UnhandledMessage));

            floor.Tell(new SensorRegistrationRequest(1, "B", "123"), probe.Ref);
            probe.ExpectNoMsg();

            var unhandled = eventStreamProbe.ExpectMsg<Akka.Event.UnhandledMessage>();

            Assert.IsType<SensorRegistrationRequest>(unhandled.Message);
        }
    }
}
