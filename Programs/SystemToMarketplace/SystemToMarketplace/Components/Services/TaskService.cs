namespace AutomathetionService.Services
{
    public class TaskService
    {
        public List<TaskModel> Tasks { get; set; } = new();

        public TaskService()
        {
            InitializeTasks();
        }

        private void InitializeTasks()
        {
            Tasks.Add(new TaskModel
            {
                Id = 1,
                Title = "Сборка заказа",
                TimeLeft = "5 hours 15 minutes",
                Priority = "high",
                ProductName = "Электросамокат Xiaomi Mi Electric Scooter 4 Pro",
                Article = "XMSJ04PRO",
                Warehouse = "№2",
                Marketplace = "VALUED",
                Quantity = 2,
                OrderNumber = "#784-ABT",
                Shelf = "2",
                Rack = "24",
                Status = "new",
                Instructions = "1. Найти товар по указанному местоположению\n2. Упаковать в транспортную упаковку\n3. Прикрепить стикер с номером заказа #784-ABT",
                WorkDescription = "Сборка товара для дальнейшей передачи в доставку",
                CreatedAt = new DateTime(2025, 10, 9, 23, 41, 0)
            });

            Tasks.Add(new TaskModel
            {
                Id = 2,
                Title = "Сборка заказа",
                TimeLeft = "15 hours 30 minutes",
                Priority = "high",
                Warehouse = "№1",
                Status = "new",
                Marketplace = "VALUED",
            });

            Tasks.Add(new TaskModel
            {
                Id = 3,
                Title = "Сборка заказа",
                TimeLeft = "15 hours 30 minutes",
                Priority = "high",
                Warehouse = "№1",
                Marketplace = "VALUED",
                Status = "new",
            });

            Tasks.Add(new TaskModel
            {
                Id = 4,
                Title = "Сборка заказа",
                TimeLeft = "15 hours 30 minutes",
                Marketplace = "VALUED",
                Warehouse = "№1",
                Priority = "high",
                Status = "new",
            });

            Tasks.Add(new TaskModel
            {
                Id = 5,
                Title = "Сборка заказа",
                TimeLeft = "23 hours 53 minutes",
                Priority = "high",
                Marketplace = "VALUED",
                Warehouse = "№1",
                Status = "new",

            });
            Tasks.Add(new TaskModel
            {
                Id = 6,
                Title = "Сборка заказа",
                TimeLeft = "23 hours 53 minutes",
                Priority = "medium",
                Warehouse = "№2",
                Marketplace = "VALUED",
                Status = "new",

            });
            Tasks.Add(new TaskModel
            {
                Id = 7,
                Title = "Сборка заказа",
                TimeLeft = "23 hours 53 minutes",
                Priority = "medium",
                Marketplace = "VALUED",
                Warehouse = "№2",
                Status = "new",

            });
            Tasks.Add(new TaskModel
            {
                Id = 8,
                Title = "Сборка заказа",
                TimeLeft = "23 hours 53 minutes",
                Priority = "low",
                Marketplace = "VALUED",
                Warehouse = "№1",
                Status = "new",

            });
        }

        public TaskModel GetTask(int id)
        {
            return Tasks.FirstOrDefault(t => t.Id == id);
        }

        public void CompleteTask(int id)
        {
            var task = Tasks.FirstOrDefault(t => t.Id == id);
            if (task != null)
            {
                Tasks.Remove(task);
            }
        }
    }
}
