using Xunit;
using Transportly.FlightSource;
using Transportly.OrderSource;

namespace TransportlyTests
{
    public class OrderTests
    {
        [Fact]
        public void TestOrderToStringWithFlight()
        {
            Flight flight = new Flight(
                flightNumber: 1,
                day: 1,
                source: "YUL",
                destination: "YYZ"
            );

            Order order = new Order("order-001", "YYZ");
            order.AssignFlight(flight);

            Assert.Equal(
                "order: order-001, flightNumber: 1, departure: YUL, arrival: YYZ, day: 1",
                order.ToString()
            );
        }

        [Fact]
        public void TestOrderToStringWithoutFlight()
        {
            Order order = new Order("order-001", "YYZ");
            Assert.Equal(
                "order: order-001, flightNumber: not scheduled",
                order.ToString()
            );
        }
    }
}
