using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using Xunit;

using Transportly;
using Transportly.FlightSource;
using Transportly.OrderSource;

namespace TransportlyTests
{
    public class FlightLoaderTests
    {
        [Fact]
        public void Test_GenerateOrderItineraries_Prints_Flight_Schedule_And_Order_Itineraries_For_Orders_With_Flights()
        {
            var consoleOutStringWriter = new StringWriter();
            Console.SetOut(consoleOutStringWriter);

            string expectedConsoleOut = "Flight Schedule:\n"
                + "Flight: 1, departure: YUL, arrival: YYZ, day: 1\n"
                + "Flight: 2, departure: YUL, arrival: YYC, day: 1\n"
                + "Flight: 3, departure: YUL, arrival: YVR, day: 2\n"
                + "\nOrder Itineraries:\n"
                + "order: order-001, flightNumber: 1, departure: YUL, arrival: YYZ, day: 1\n"
                + "order: order-002, flightNumber: 2, departure: YUL, arrival: YYC, day: 1\n"
                + "order: order-003, flightNumber: 3, departure: YUL, arrival: YVR, day: 2\n\n";

            var flightSourceMock = new Mock<IFlightSource>();
            flightSourceMock.Setup(p => p.GetFlights()).Returns(new List<Flight> {
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
                    day: 2,
                    source: "YUL",
                    destination: "YVR"
                )
            });

            var orderSourceMock = new Mock<IOrderSource>();
            orderSourceMock.Setup(p => p.GetOrders()).Returns(new List<Order> {
                new Order("order-001", "YYZ"),
                new Order("order-002", "YYC"),
                new Order("order-003", "YVR")
            });

            FlightLoader flightLoader = new FlightLoader(
                flightSourceMock.Object,
                orderSourceMock.Object
            );
            flightLoader.GenerateOrderItineraries();

            Assert.Equal(
                expectedConsoleOut,
                consoleOutStringWriter.ToString()
            );
        }

        [Fact]
        public void Test_GenerateOrderItineraries_Does_Not_Assign_Non_Existing_Flights_To_Orders()
        {
            var consoleOutStringWriter = new StringWriter();
            Console.SetOut(consoleOutStringWriter);

            string expectedConsoleOut = "Flight Schedule:\n"
                + "Flight: 1, departure: YUL, arrival: YYZ, day: 1\n"
                + "Flight: 2, departure: YUL, arrival: YYC, day: 1\n"
                + "Flight: 3, departure: YUL, arrival: YVR, day: 2\n"
                + "\nOrder Itineraries:\n"
                + "order: order-001, flightNumber: 1, departure: YUL, arrival: YYZ, day: 1\n"
                + "order: order-002, flightNumber: 2, departure: YUL, arrival: YYC, day: 1\n"
                + "order: order-003, flightNumber: not scheduled\n\n";

            var flightSourceMock = new Mock<IFlightSource>();
            flightSourceMock.Setup(p => p.GetFlights()).Returns(new List<Flight> {
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
                    day: 2,
                    source: "YUL",
                    destination: "YVR"
                )
            });

            var orderSourceMock = new Mock<IOrderSource>();
            orderSourceMock.Setup(p => p.GetOrders()).Returns(new List<Order> {
                new Order("order-001", "YYZ"),
                new Order("order-002", "YYC"),
                new Order("order-003", "YYE")
            });

            FlightLoader flightLoader = new FlightLoader(
                flightSourceMock.Object,
                orderSourceMock.Object
            );
            flightLoader.GenerateOrderItineraries();

            Assert.Equal(
                expectedConsoleOut,
                consoleOutStringWriter.ToString()
            );
        }

        [Fact]
        public void Test_GenerateOrderItineraries_Does_Not_Assign_Full_Flights_To_Orders()
        {
            var consoleOutStringWriter = new StringWriter();
            Console.SetOut(consoleOutStringWriter);

            string expectedConsoleOut = "Flight Schedule:\n"
                + "Flight: 1, departure: YUL, arrival: YYZ, day: 1\n"
                + "\nOrder Itineraries:\n"
                + "order: order-001, flightNumber: 1, departure: YUL, arrival: YYZ, day: 1\n"
                + "order: order-002, flightNumber: 1, departure: YUL, arrival: YYZ, day: 1\n"
                + "order: order-003, flightNumber: 1, departure: YUL, arrival: YYZ, day: 1\n"
                + "order: order-004, flightNumber: 1, departure: YUL, arrival: YYZ, day: 1\n"
                + "order: order-005, flightNumber: 1, departure: YUL, arrival: YYZ, day: 1\n"
                + "order: order-006, flightNumber: 1, departure: YUL, arrival: YYZ, day: 1\n"
                + "order: order-007, flightNumber: 1, departure: YUL, arrival: YYZ, day: 1\n"
                + "order: order-008, flightNumber: 1, departure: YUL, arrival: YYZ, day: 1\n"
                + "order: order-009, flightNumber: 1, departure: YUL, arrival: YYZ, day: 1\n"
                + "order: order-010, flightNumber: 1, departure: YUL, arrival: YYZ, day: 1\n"
                + "order: order-011, flightNumber: 1, departure: YUL, arrival: YYZ, day: 1\n"
                + "order: order-012, flightNumber: 1, departure: YUL, arrival: YYZ, day: 1\n"
                + "order: order-013, flightNumber: 1, departure: YUL, arrival: YYZ, day: 1\n"
                + "order: order-014, flightNumber: 1, departure: YUL, arrival: YYZ, day: 1\n"
                + "order: order-015, flightNumber: 1, departure: YUL, arrival: YYZ, day: 1\n"
                + "order: order-016, flightNumber: 1, departure: YUL, arrival: YYZ, day: 1\n"
                + "order: order-017, flightNumber: 1, departure: YUL, arrival: YYZ, day: 1\n"
                + "order: order-018, flightNumber: 1, departure: YUL, arrival: YYZ, day: 1\n"
                + "order: order-019, flightNumber: 1, departure: YUL, arrival: YYZ, day: 1\n"
                + "order: order-020, flightNumber: 1, departure: YUL, arrival: YYZ, day: 1\n"
                + "order: order-021, flightNumber: not scheduled\n\n";

            var flightSourceMock = new Mock<IFlightSource>();
            flightSourceMock.Setup(p => p.GetFlights()).Returns(new List<Flight> {
                new Flight(
                    flightNumber: 1,
                    day: 1,
                    source: "YUL",
                    destination: "YYZ"
                )
            });

            var orderSourceMock = new Mock<IOrderSource>();
            orderSourceMock.Setup(p => p.GetOrders()).Returns(new List<Order> {
                new Order("order-001", "YYZ"),
                new Order("order-002", "YYZ"),
                new Order("order-003", "YYZ"),
                new Order("order-004", "YYZ"),
                new Order("order-005", "YYZ"),
                new Order("order-006", "YYZ"),
                new Order("order-007", "YYZ"),
                new Order("order-008", "YYZ"),
                new Order("order-009", "YYZ"),
                new Order("order-010", "YYZ"),
                new Order("order-011", "YYZ"),
                new Order("order-012", "YYZ"),
                new Order("order-013", "YYZ"),
                new Order("order-014", "YYZ"),
                new Order("order-015", "YYZ"),
                new Order("order-016", "YYZ"),
                new Order("order-017", "YYZ"),
                new Order("order-018", "YYZ"),
                new Order("order-019", "YYZ"),
                new Order("order-020", "YYZ"),
                new Order("order-021", "YYZ")
            });

            FlightLoader flightLoader = new FlightLoader(
                flightSourceMock.Object,
                orderSourceMock.Object
            );
            flightLoader.GenerateOrderItineraries();

            Assert.Equal(
                expectedConsoleOut,
                consoleOutStringWriter.ToString()
            );
        }
    }
}
