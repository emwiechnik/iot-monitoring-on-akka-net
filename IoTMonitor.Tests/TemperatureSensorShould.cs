using Akka.TestKit.Xunit2;
using IoTMonitor.Actors;
using IoTMonitor.Messages;
using Xunit;

namespace IoTMonitor.Tests
{
    public class TemperatureSensorShould : TestKit
    {
        [Fact]
        public void Initialize_Sensor_MetaData()
        {
            // Arrange
            var probe = CreateTestProbe();

            var parameters = new { FloorId = "A", SensorId = "123", RequestId = 1 };

            var sensor = Sys.ActorOf(TemperatureSensor.Props(parameters.FloorId, parameters.SensorId));

            // Act
            sensor.Tell(new RequestMetadata(parameters.RequestId), probe.Ref);

            var received = probe.ExpectMsg<RespondMetadata>();

            // Assert
            Assert.Equal(parameters.RequestId, received.RequestId);
            Assert.Equal(parameters.FloorId, received.FloorId);
            Assert.Equal(parameters.SensorId, received.SensorId);
        }
    }
}
