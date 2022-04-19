using System.Collections.Generic;
using Transportly.OrderSource;

namespace Transportly.FlightSource
{
    public class Flight
    {
        public const int MaximumOrders = 20;
        public readonly int FlightNumber;
        public readonly int Day;
        public readonly string Source;
        public readonly string Destination;
        public List<Order> Orders { get; } = new List<Order>();

        public Flight(
            int flightNumber, int day, string source, string destination
        )
        {
            FlightNumber = flightNumber;
            Day = day;
            Source = source;
            Destination = destination;
        }

        override public string ToString()
        {
            return $"Flight: {FlightNumber}" +
                $", departure: {Source}" +
                $", arrival: {Destination}" +
                $", day: {Day}";
        }

        public bool LoadOrder(Order order)
        {
            if (Orders.Count == MaximumOrders)
            {
                return false;
            }
            Orders.Add(order);
            return true;
        }
    }
}
