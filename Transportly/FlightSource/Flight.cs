namespace Transportly.FlightSource
{
    public class Flight
    {
        public readonly int FlightNumber;
        public readonly int Day;
        public readonly string Source;
        public readonly string Destination;

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
    }
}
