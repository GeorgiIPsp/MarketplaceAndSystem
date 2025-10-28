using System;
using System.Collections.Generic;

namespace Marketplace.Models;

public partial class Task
{
    public int TaskId { get; set; }

    public int? EmployeeId { get; set; }

    public string Description { get; set; } = null!;

    public string Priority { get; set; } = null!;

    public int OrderItemsId { get; set; }

    public double? ActualHourseWork { get; set; }

    public int WarehouseId { get; set; }

    public virtual Employee? Employee { get; set; }

    public virtual OrderItem OrderItems { get; set; } = null!;

    public virtual ICollection<TaskHistory> TaskHistories { get; set; } = new List<TaskHistory>();

    public virtual Warehouse Warehouse { get; set; } = null!;
}
