namespace AutomathetionService.Services
{
    public class TaskModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Priority { get; set; } = string.Empty; // high, medium, low
        public string TimeLeft { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public bool IsCompleted { get; set; } = false;

        // Детали задачи
        public string ProductName { get; set; } = string.Empty;
        public string Article { get; set; } = string.Empty;
        public string Warehouse { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public string OrderNumber { get; set; } = string.Empty;
        public string Shelf { get; set; } = string.Empty;
        public string Rack { get; set; } = string.Empty;
        public string Instructions { get; set; } = string.Empty;
        public string WorkDescription { get; set; } = string.Empty;
        public string Status { get; set; } = "new";
        public string Marketplace {  get; set; } = string.Empty;
    }
}
