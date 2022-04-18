using Transportly.FlightSource;

namespace Transportly.OrderSource
{
    public class Order
    {
        readonly string OrderId;
        public Flight Flight;

        public Order(string orderId)
        {
            OrderId = orderId;
        }

        public void AssignFlight(Flight flight) {
            Flight = flight;
        }

        public override string ToString()
        {
            if(Flight == null) {
                return $"order: {OrderId}, flightNumber: not scheduled";
            }
            return $"order: {OrderId}" +
                $", flightNumber: {Flight.FlightNumber}" +
                $", departure: {Flight.Source}" +
                $", arrival: {Flight.Destination}" +
                $", day: {Flight.Day}";
        }
    }
}
