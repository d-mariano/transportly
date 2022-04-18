using Xunit;
using Transportly.FlightSource;

namespace TransportlyTests
{
    public class FlightTests
    {
        [Fact]
        public void TestFlightToString()
        {
            Flight flight = new Flight(
                flightNumber: 1,
                day: 1,
                source: "YUL",
                destination: "YYZ"
            );

            Assert.Equal(
                "Flight: 1, departure: YUL, arrival: YYZ, day: 1",
                flight.ToString()
            );
        }
    }
}
