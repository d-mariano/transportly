using System.Collections.Generic;

namespace Transportly.OrderSource
{
    public interface IOrderSource
    {
        List<Order> GetOrders();
    }
}
