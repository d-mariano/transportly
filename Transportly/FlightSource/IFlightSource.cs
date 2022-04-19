using System.Collections.Generic;

namespace Transportly.FlightSource
{
    public interface IFlightSource
    {
        List<Flight> GetFlights();
    }
}
