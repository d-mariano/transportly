using System;
using System.Collections.Generic;

using Transportly.FlightSource;
using Transportly.OrderSource;

namespace Transportly
{
    public class FlightLoader
    {
        private readonly IFlightSource FlightSource;
        private readonly IOrderSource OrderSource;
        private List<Flight> Flights;
        private List<Order> Orders;

        public FlightLoader(IFlightSource flightSource, IOrderSource orderSource)
        {
            FlightSource = flightSource;
            OrderSource = orderSource;
        }

        public void GenerateOrderItineraries()
        {
            this.FetchFlightSchedule();
            this.PrintFlightSchedule();
            this.FetchOrders();
            this.AssignOrdersToFlights();
            this.PrintOrders();
        }

        private void FetchFlightSchedule()
        {
            Flights = FlightSource.GetFlights();
        }

        private void FetchOrders()
        {
            Orders = OrderSource.GetOrders();
        }

        private void AssignOrdersToFlights()
        {
            foreach (Order order in Orders)
            {
                foreach (Flight flight in Flights)
                {
                    if (
                        order.Destination == flight.Destination
                        && flight.LoadOrder(order)
                    )
                    {
                        order.AssignFlight(flight);
                        break;
                    }
                }
            }
        }

        private void PrintFlightSchedule()
        {
            Console.WriteLine("Flight Schedule:");
            foreach (Flight flight in Flights)
            {
                Console.WriteLine(flight);
            }
            Console.WriteLine();
        }

        private void PrintOrders()
        {
            Console.WriteLine("Order Itineraries:");
            foreach (Order order in Orders)
            {
                Console.WriteLine(order);
            }
            Console.WriteLine();
        }

    }
}
