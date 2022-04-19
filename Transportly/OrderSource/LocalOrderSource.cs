using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Transportly.OrderSource
{
    public class LocalOrderSource : IOrderSource
    {
        public const string FilePath = "coding-assigment-orders.json";
        
        public List<Order> GetOrders()
        {
            List<Order> orders = new List<Order>();

            string jsonString = File.ReadAllText(FilePath);
            var orderDicts = JsonSerializer.Deserialize<Dictionary<string, Dictionary<string, string>>>(jsonString);

            foreach(KeyValuePair<string, Dictionary<string, string>> order in orderDicts)
            {
                orders.Add(new Order(id: order.Key, destination: order.Value["destination"]));
            }

            return orders;
        }
    }
}
