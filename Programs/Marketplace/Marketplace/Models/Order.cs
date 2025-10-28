using System;
using System.Collections.Generic;

namespace Marketplace.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public int UserId { get; set; }

    public DateTime OrderDate { get; set; }

    public double TotalAmount { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual ICollection<StatusHistoryOrderId> StatusHistoryOrderIds { get; set; } = new List<StatusHistoryOrderId>();

    public virtual UserMarket User { get; set; } = null!;
}
