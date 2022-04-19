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

        public void LoadFlight()
        {
            this.LoadFlightSchedule();
            this.PrintFlightSchdule();
        }

        private void LoadFlightSchedule()
        {
            Flights = FlightSource.GetFlights();
        }

        private void PrintFlightSchdule()
        {
            foreach (Flight flight in Flights)
            {
                Console.WriteLine(flight);
            }
        }

    }
}
