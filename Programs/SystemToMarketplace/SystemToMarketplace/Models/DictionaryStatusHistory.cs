using System;
using System.Collections.Generic;

namespace SystemToMarketplace.Models;

public partial class DictionaryStatusHistory
{
    public int DictionaryStatusHistoryId { get; set; }

    public string TitleStatus { get; set; } = null!;

    public virtual ICollection<StatusHistoryOrderId> StatusHistoryOrderIds { get; set; } = new List<StatusHistoryOrderId>();
}
