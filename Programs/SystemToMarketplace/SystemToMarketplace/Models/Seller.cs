using System;
using System.Collections.Generic;

namespace SystemToMarketplace.Models;

public partial class Seller
{
    public int SellerId { get; set; }

    public string CompanyName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Inn { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<PresentCard> PresentCards { get; set; } = new List<PresentCard>();

    public virtual ICollection<Warehouse> Warehouses { get; set; } = new List<Warehouse>();
}
