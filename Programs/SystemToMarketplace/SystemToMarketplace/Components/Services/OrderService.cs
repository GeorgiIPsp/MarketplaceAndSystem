

using static SystemToMarketplace.Components.Pages.Orders;

namespace AutomathetionService.Services
{
    public class OrderService
    {
        public List<Order> Orders { get; set; } = new();

        public OrderService()
        {
            GenerateSampleOrders();
        }

        private void GenerateSampleOrders()
        {
            var random = new Random();
            var customers = new[] { "Иван Семенов", "Анна Петрова", "Сергей Иванов", "Мария Сидорова", "Алексей Козлов" };
            var statuses = new[] { "Оформлен", "Принят в работу", "Доставлен", "В сборке", "В доставке"  };

            for (int i = 1; i <= 20; i++)
            {
                Orders.Add(new Order
                {
                    Id = i,
                    CustomerName = customers[random.Next(customers.Length)],
                    Amount = random.Next(1000, 50000),
                    Marketplace = "VALUED",
                    Warehouse = "№1",
                    Status = statuses[random.Next(statuses.Length)],
                    OrderDate = DateTime.Now.AddDays(-random.Next(0, 30))
                });
            }
        }
    }
}
