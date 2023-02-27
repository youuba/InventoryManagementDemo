using System;
using System.Collections.Generic;

namespace InventoryManagement.Core.Models;

public partial class Supplier
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Address { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<Product> Products { get; } = new List<Product>();
}
