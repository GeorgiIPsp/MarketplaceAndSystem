using System;
using System.Collections.Generic;

namespace SystemToMarketplace.Models;

public partial class Warehouse
{
    public int WarehouseId { get; set; }

    public string Type { get; set; } = null!;

    public int? SellerId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public virtual ICollection<ProductPlace> ProductPlaces { get; set; } = new List<ProductPlace>();

    public virtual Seller? Seller { get; set; }

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
}
