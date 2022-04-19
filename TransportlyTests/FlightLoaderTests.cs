using Moq;
using System;
using System.IO;
using Xunit;
using Transportly;
using Transportly.FlightSource;

namespace TransportlyTests
{
    public class FlightLoaderTests
    {
        [Fact]
        public void Test_LoadFlightSchedule_Prints_Flight_Schedule()
        {
            var consoleOutStringWriter = new StringWriter();
            Console.SetOut(consoleOutStringWriter);

            string expectedConsoleOut = "Flight: 1, departure: YUL, arrival: YYZ, day: 1\n"
                + "Flight: 2, departure: YUL, arrival: YYC, day: 1\n"
                + "Flight: 3, departure: YUL, arrival: YVR, day: 1\n";

            Flight[] flights = new Flight[] {
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
                )
            };
            var flightSourceMock = new Mock<IFlightSource>();
            flightSourceMock.Setup(p => p.GetFlights()).Returns(flights);
            FlightLoader flightLoader = new FlightLoader(flightSourceMock.Object);
            flightLoader.LoadFlight();

            Assert.Equal(
                expectedConsoleOut,
                consoleOutStringWriter.ToString()
            );
        }
    }
}
