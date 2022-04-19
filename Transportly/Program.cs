using Transportly.FlightSource;
using Transportly.OrderSource;

namespace Transportly
{
    class Program
    {
        static void Main(string[] args)
        {
            FlightLoader flightLoader = new FlightLoader(
                new LocalFlightSource(),
                new LocalOrderSource()
            );
            flightLoader.GenerateOrderItineraries();
        }

    }
}
