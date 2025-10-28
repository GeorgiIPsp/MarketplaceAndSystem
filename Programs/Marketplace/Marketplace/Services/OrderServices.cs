using yyy.Services;
namespace yyy.Services
{
    public class OrderServices
    {
        private readonly IProductService _productService;

        public OrderServices(IProductService productService)
        {
            _productService = productService;
        }

        List<Dictionary_Status_History> statusDictionary = new List<Dictionary_Status_History>
        {
            new Dictionary_Status_History { dictionary_status_history_id = 1, title_status = "Новый" },
            new Dictionary_Status_History { dictionary_status_history_id = 2, title_status = "В обработке" },
            new Dictionary_Status_History { dictionary_status_history_id = 3, title_status = "Доставляется" },
            new Dictionary_Status_History { dictionary_status_history_id = 4, title_status = "Завершен" },
            new Dictionary_Status_History { dictionary_status_history_id = 5, title_status = "Отменен" }
        };

        public List<Order> orders = new List<Order>
        {
            new Order { order_id = 1, order_date = DateTime.Now.AddDays(-5), total_amount = 1500, user_id = 1 },
            new Order { order_id = 2, order_date = DateTime.Now.AddDays(-10), total_amount = 2300, user_id = 1 },
            new Order { order_id = 3, order_date = DateTime.Now.AddDays(-1), total_amount = 1200, user_id = 1 },
            new Order { order_id = 4, order_date = DateTime.Now.AddHours(-3), total_amount = 950, user_id = 1 },
            new Order { order_id = 5, order_date = DateTime.Now.AddHours(-2), total_amount = 450, user_id = 1 }
        };

        List<Dictionary_Status_History_Order> statusHistory = new List<Dictionary_Status_History_Order>
        {
            new Dictionary_Status_History_Order { Dictionary_status_history_order_id = 3, order_id = 3, dictionary_status_history_id = 2, date_edit = DateTime.Now.AddHours(-12) },
            new Dictionary_Status_History_Order { Dictionary_status_history_order_id = 4, order_id = 4, dictionary_status_history_id = 3, date_edit = DateTime.Now.AddHours(-2) },
            new Dictionary_Status_History_Order { Dictionary_status_history_order_id = 1, order_id = 1, dictionary_status_history_id = 4, date_edit = DateTime.Now.AddDays(-4) },
            new Dictionary_Status_History_Order { Dictionary_status_history_order_id = 2, order_id = 2, dictionary_status_history_id = 4, date_edit = DateTime.Now.AddDays(-9) },
            new Dictionary_Status_History_Order { Dictionary_status_history_order_id = 2, order_id = 5, dictionary_status_history_id = 2, date_edit = DateTime.Now.AddDays(-9) }
        };

        List<OrderItems> orderItems = new List<OrderItems>
        {
            new OrderItems { order_id = 1, present_card_id = 1, quantity = 2 },
            new OrderItems { order_id = 1, present_card_id = 2, quantity = 1 },
            new OrderItems { order_id = 2, present_card_id = 3, quantity = 1 },
            new OrderItems { order_id = 2, present_card_id = 4, quantity = 3 },
            new OrderItems { order_id = 3, present_card_id = 1, quantity = 1 },
            new OrderItems { order_id = 3, present_card_id = 2, quantity = 2 },
            new OrderItems { order_id = 4, present_card_id = 3, quantity = 1 },
            new OrderItems { order_id = 4, present_card_id = 4, quantity = 1 },
            new OrderItems { order_id = 5, present_card_id = 1, quantity = 1 }
        };

        public async Task<List<OrderWithStatus>> GetCompletedOrdersAsync(int userId)
        {
            var completeOrders = new List<OrderWithStatus>();
            try
            {
                var products = await _productService.GetProductsAsync();

                foreach (var order in orders)
                {
                    string orderStatus = "";

                    // Сначала находим статус заказа
                    foreach (var statusHistiryItem in statusHistory)
                    {
                        foreach (var dictionary in statusDictionary)
                        {
                            if (order.order_id == statusHistiryItem.order_id &&
                                statusHistiryItem.dictionary_status_history_id == dictionary.dictionary_status_history_id)
                            {
                                if (dictionary.title_status == "Завершен" || dictionary.title_status == "Отменен")
                                {
                                    orderStatus = dictionary.title_status;
                                    break;
                                }
                            }
                        }
                        if (!string.IsNullOrEmpty(orderStatus)) break;
                    }

                    // Если заказ имеет нужный статус, собираем все его товары
                    if (!string.IsNullOrEmpty(orderStatus))
                    {
                        // Создаем заказ со статусом
                        OrderWithStatus item = new OrderWithStatus
                        {
                            order_id = order.order_id,
                            order_date = order.order_date,
                            total_amount = order.total_amount,
                            user_id = order.user_id,
                            Status = orderStatus
                        };

                        // Добавляем товары к заказу
                        foreach (var order_item in orderItems)
                        {
                            if (order.order_id == order_item.order_id)
                            {
                                foreach (var product in products)
                                {
                                    if (order_item.present_card_id == product.Id)
                                    {
                                        // Используем напрямую данные из Product
                                        item.Products.Add(product);
                                        item.Quantities.Add(order_item.quantity);
                                        break;
                                    }
                                }
                            }
                        }

                        completeOrders.Add(item);
                    }
                }
                return completeOrders;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
                return new List<OrderWithStatus>();
            }
        }

        public async Task<List<OrderWithStatus>> GetCurrentOrdersAsync(int userId)
        {
            var currentOrders = new List<OrderWithStatus>();
            try
            {
                var products = await _productService.GetProductsAsync();

                foreach (var order in orders)
                {
                    string orderStatus = "";

                    // Сначала находим статус заказа
                    foreach (var statusHistiryItem in statusHistory)
                    {
                        foreach (var dictionary in statusDictionary)
                        {
                            if (order.order_id == statusHistiryItem.order_id &&
                                statusHistiryItem.dictionary_status_history_id == dictionary.dictionary_status_history_id)
                            {
                                if (dictionary.title_status == "Новый" || dictionary.title_status == "В обработке" || dictionary.title_status == "Доставляется")
                                {
                                    orderStatus = dictionary.title_status;
                                    break;
                                }
                            }
                        }
                        if (!string.IsNullOrEmpty(orderStatus)) break;
                    }

                    // Если заказ имеет нужный статус, собираем все его товары
                    if (!string.IsNullOrEmpty(orderStatus))
                    {
                        // Создаем заказ со статусом
                        OrderWithStatus item = new OrderWithStatus
                        {
                            order_id = order.order_id,
                            order_date = order.order_date,
                            total_amount = order.total_amount,
                            user_id = order.user_id,
                            Status = orderStatus
                        };

                        // Добавляем товары к заказу
                        foreach (var order_item in orderItems)
                        {
                            if (order.order_id == order_item.order_id)
                            {
                                foreach (var product in products)
                                {
                                    if (order_item.present_card_id == product.Id)
                                    {
                                        // Используем напрямую данные из Product
                                        item.Products.Add(product);
                                        item.Quantities.Add(order_item.quantity);
                                        break;
                                    }
                                }
                            }
                        }

                        currentOrders.Add(item);
                    }
                }
                return currentOrders;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
                return new List<OrderWithStatus>();
            }
        }
        public async Task<int> CreateOrder(int userId, List<CartItem> cartItems, decimal totalAmount)
        {
            try
            {
                // Генерируем новый ID заказа
                int newOrderId = orders.Count > 0 ? orders.Max(o => o.order_id) + 1 : 1;

                // Создаем заказ
                var newOrder = new Order
                {
                    order_id = newOrderId,
                    user_id = userId,
                    order_date = DateTime.Now,
                    total_amount = (float)totalAmount
                };
                orders.Add(newOrder);

                // Добавляем товары заказа
                foreach (var cartItem in cartItems)
                {
                    var orderItem = new OrderItems
                    {
                        order_id = newOrderId,
                        present_card_id = cartItem.product_id,
                        quantity = cartItem.quantity
                    };
                    orderItems.Add(orderItem);
                }

                // Добавляем статус "Новый"
                int newStatusHistoryId = statusHistory.Count > 0 ?
                    statusHistory.Max(sh => sh.Dictionary_status_history_order_id) + 1 : 1;

                var statusHistoryItem = new Dictionary_Status_History_Order
                {
                    Dictionary_status_history_order_id = newStatusHistoryId,
                    order_id = newOrderId,
                    dictionary_status_history_id = 2, // "Новый"
                    date_edit = DateTime.Now
                };
                statusHistory.Add(statusHistoryItem);

                // Сохраняем в localStorage
                

                return newOrderId;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка создания заказа: {ex.Message}");
                return -1;
            }
        }
    }

    public class OrderWithStatus
    {
        public int order_id { get; set; }
        public int user_id { get; set; }
        public DateTime order_date { get; set; }
        public float total_amount { get; set; }
        public string Status { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();
        public List<int> Quantities { get; set; } = new List<int>();
    }
}