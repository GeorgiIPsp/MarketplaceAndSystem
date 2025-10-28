using System;
using System.Collections.Generic;

namespace SystemToMarketplace.Models;

public partial class UserMarket
{
    public int IdUser { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public bool IsActive { get; set; }

    public string LastName { get; set; } = null!;

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
