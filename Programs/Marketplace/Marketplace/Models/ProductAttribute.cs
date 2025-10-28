using System;
using System.Collections.Generic;

namespace Marketplace.Models;

public partial class ProductAttribute
{
    public int AttributeId { get; set; }

    public string Name { get; set; } = null!;

    public string Unit { get; set; } = null!;

    public string DataType { get; set; } = null!;

    public virtual ICollection<ProductAttributeCategory> ProductAttributeCategories { get; set; } = new List<ProductAttributeCategory>();
}
