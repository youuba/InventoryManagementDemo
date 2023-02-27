using System;
using System.Collections.Generic;

namespace InventoryManagement.Core.Models;

public partial class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public decimal Price { get; set; }

    public int Quantity { get; set; }

    public int CategoryId { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<Inventory> Inventories { get; } = new List<Inventory>();

    public virtual ICollection<OrderItem> OrderItems { get; } = new List<OrderItem>();

    public virtual ICollection<Supplier> Suppliers { get; } = new List<Supplier>();
}
