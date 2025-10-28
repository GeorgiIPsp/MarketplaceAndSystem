using System;
using System.Collections.Generic;

namespace Marketplace.Models;

public partial class StatusHistoryOrderId
{
    public int StatusHistoryId { get; set; }

    public int OrderId { get; set; }

    public int DictionaryStatusHistoryId { get; set; }

    public DateTime DateEdit { get; set; }

    public virtual DictionaryStatusHistory DictionaryStatusHistory { get; set; } = null!;

    public virtual Order Order { get; set; } = null!;
}
