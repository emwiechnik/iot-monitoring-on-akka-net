using Akka.TestKit.Xunit2;
using IoTMonitor.Actors;
using IoTMonitor.Messages;
using IoTMonitor.ValueTypes;
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
            sensor.Tell(new MetadataRequest(parameters.RequestId), probe.Ref);

            var received = probe.ExpectMsg<MetadataResponse>();

            // Assert
            Assert.Equal(parameters.RequestId, received.RequestId);
            Assert.Equal(parameters.FloorId, received.FloorId);
            Assert.Equal(parameters.SensorId, received.SensorId);
        }

        [Fact]
        public void Start_With_No_Recorded_Temperature()
        {
            // Arrange
            var probe = CreateTestProbe();

            var parameters = new { FloorId = "A", SensorId = "123", RequestId = 1 };

            var sensor = Sys.ActorOf(TemperatureSensor.Props(parameters.FloorId, parameters.SensorId));

            // Act
            sensor.Tell(new TemperatureRequest(parameters.RequestId), probe.Ref);

            var received = probe.ExpectMsg<TemperatureResponse>();

            // Assert
            Assert.Null(received.Temperature);
        }

        [Fact]
        public void Confirm_Temperature_Got_Updated()
        {
            // Arrange
            var probe = CreateTestProbe();

            var parameters = new { FloorId = "A", SensorId = "123", RequestId = 1, NewTemperature = new Temperature(100) };

            var sensor = Sys.ActorOf(TemperatureSensor.Props(parameters.FloorId, parameters.SensorId));

            // Act
            sensor.Tell(new TemperatureUpdateRequest(parameters.RequestId, parameters.NewTemperature), probe.Ref);

            var received = probe.ExpectMsg<TemperatureUpdateResponse>();

            // Assert
            Assert.NotNull(received.Temperature);
            Assert.Equal(parameters.NewTemperature.Value, received.Temperature.Value);
        }
    }
}
