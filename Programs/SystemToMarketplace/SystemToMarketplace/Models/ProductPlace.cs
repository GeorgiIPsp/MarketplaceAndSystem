using System;
using System.Collections.Generic;

namespace SystemToMarketplace.Models;

public partial class ProductPlace
{
    public int IdProductPlace { get; set; }

    public int PresentCardId { get; set; }

    public int IdWarehouse { get; set; }

    public string Shelving { get; set; } = null!;

    public string Shelf { get; set; } = null!;

    public int Quantity { get; set; }

    public virtual Warehouse IdWarehouseNavigation { get; set; } = null!;

    public virtual PresentCard PresentCard { get; set; } = null!;
}
