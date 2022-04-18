using System;
using Transportly.FlightSource;

namespace Transportly
{
    public class FlightLoader
    {
        private readonly IFlightSource FlightSource;
        private Flight[] Flights;

        public FlightLoader(IFlightSource flightSource)
        {
            FlightSource = flightSource;
        }

        public void LoadFlightSchedule()
        {
            Flights = FlightSource.GetFlights();
            this.PrintFlightSchdule();
        }

        public void PrintFlightSchdule()
        {
            foreach (Flight flight in Flights)
            {
                Console.WriteLine(flight);
            }
        }

    }
}
