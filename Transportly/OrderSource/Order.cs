using Transportly.FlightSource;

namespace Transportly.OrderSource
{
    public class Order
    {
        public readonly string Id;
        public readonly string Destination;
        public Flight Flight;

        public Order(string id, string destination)
        {
            Id = id;
            Destination = destination;
        }

        public void AssignFlight(Flight flight) {
            Flight = flight;
        }

        public override string ToString()
        {
            if(Flight == null) {
                return $"order: {Id}, flightNumber: not scheduled";
            }
            return $"order: {Id}" +
                $", flightNumber: {Flight.FlightNumber}" +
                $", departure: {Flight.Source}" +
                $", arrival: {Flight.Destination}" +
                $", day: {Flight.Day}";
        }
    }
}
