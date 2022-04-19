namespace Transportly.FlightSource 
{
    public class LocalFlightSource : IFlightSource
    {
        public Flight[] GetFlights() {
            return new Flight[] {
                new Flight(
                    flightNumber: 1,
                    day: 1,
                    source: "YUL",
                    destination: "YYZ"
                ),
                new Flight(
                    flightNumber: 2,
                    day: 1,
                    source: "YUL",
                    destination: "YYC"
                ),
                new Flight(
                    flightNumber: 3,
                    day: 1,
                    source: "YUL",
                    destination: "YVR"
                ),

                new Flight(
                    flightNumber: 4,
                    day: 2,
                    source: "YUL",
                    destination: "YYZ"
                ),
                new Flight(
                    flightNumber: 5,
                    day: 2,
                    source: "YUL",
                    destination: "YYC"
                ),
                new Flight(
                    flightNumber: 6,
                    day: 2,
                    source: "YUL",
                    destination: "YVR"
                )
            };
        }
    }
}
