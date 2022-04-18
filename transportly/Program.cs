using Transportly.FlightSource;

namespace Transportly
{
    class Program
    {
        static void Main(string[] args)
        {
            FlightLoader flightLoader = new FlightLoader(new LocalFlightSource());
            flightLoader.LoadFlightSchedule();
        }

    }
}
