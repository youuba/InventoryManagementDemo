using System;
using System.Collections.Generic;

namespace InventoryManagement.Core.Models;

public partial class Customer
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? Address { get; set; }

    public virtual ICollection<Order> Orders { get; } = new List<Order>();
}
