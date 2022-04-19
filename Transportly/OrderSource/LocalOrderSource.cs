namespace Transportly.OrderSource
{
    public class LocalOrderSource : IOrderSource
    {
        public Order[] GetOrders()
        {
            return new Order[] { };
        }
    }
}
