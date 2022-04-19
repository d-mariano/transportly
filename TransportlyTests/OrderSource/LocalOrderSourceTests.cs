using Xunit;
using Transportly.OrderSource;
using System.Collections.Generic;

namespace TransportlyTests
{
    public class LocalOrderSourceTests
    {
        [Fact]
        public void TestGetOrders()
        {
            IOrderSource orderSource = new LocalOrderSource();
            List<Order> orders = orderSource.GetOrders();
            Assert.Equal(96, orders.Count);
            Assert.Equal("order-001", orders[0].Id);
            Assert.Equal("YYZ", orders[0].Destination);
            Assert.Equal("order-099", orders[95].Id);
            Assert.Equal("YVR", orders[95].Destination);
        }
    }
}
