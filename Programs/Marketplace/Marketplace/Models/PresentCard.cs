using System;
using System.Collections.Generic;

namespace Marketplace.Models;

public partial class PresentCard
{
    public int PresentCardId { get; set; }

    public int SellerId { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Brand { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public byte[] Images { get; set; } = null!;

    public bool IsAvailable { get; set; }

    public virtual ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual ICollection<ProductAttributeValue> ProductAttributeValues { get; set; } = new List<ProductAttributeValue>();

    public virtual ICollection<ProductPlace> ProductPlaces { get; set; } = new List<ProductPlace>();

    public virtual ICollection<ProductPrice> ProductPrices { get; set; } = new List<ProductPrice>();

    public virtual Seller Seller { get; set; } = null!;
}
