using System;
using System.Collections.Generic;

namespace SystemToMarketplace.Models;

public partial class TaskCompletionStatus
{
    public int StatusTaskId { get; set; }

    public string TitleStatusId { get; set; } = null!;

    public virtual ICollection<TaskHistory> TaskHistories { get; set; } = new List<TaskHistory>();
}
