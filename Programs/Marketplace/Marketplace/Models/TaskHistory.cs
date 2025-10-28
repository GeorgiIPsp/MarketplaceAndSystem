using System;
using System.Collections.Generic;

namespace Marketplace.Models;

public partial class TaskHistory
{
    public int HistoryId { get; set; }

    public int TaskId { get; set; }

    public int StatusTaskId { get; set; }

    public DateTime ChangedAt { get; set; }

    public virtual TaskCompletionStatus StatusTask { get; set; } = null!;

    public virtual Task Task { get; set; } = null!;
}
