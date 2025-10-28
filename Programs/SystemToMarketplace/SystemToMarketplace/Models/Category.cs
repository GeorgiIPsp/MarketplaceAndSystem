using System;
using System.Collections.Generic;

namespace SystemToMarketplace.Models;

public partial class Category
{
    public int CategoryId { get; set; }

    public string Name { get; set; } = null!;

    public int Level { get; set; }

    public virtual ICollection<ProductAttributeCategory> ProductAttributeCategories { get; set; } = new List<ProductAttributeCategory>();
}
