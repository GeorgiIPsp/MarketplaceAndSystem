using System;
using System.Collections.Generic;

namespace SystemToMarketplace.Models;

public partial class WorkLog
{
    public int WorkLogId { get; set; }

    public int EmployeeId { get; set; }

    public DateOnly WorkDate { get; set; }

    public double HoursSpent { get; set; }

    public int QuantityTask { get; set; }

    public virtual Employee Employee { get; set; } = null!;
}
