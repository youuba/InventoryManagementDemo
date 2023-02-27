using System;
using System.Collections.Generic;

namespace InventoryManagement.Core.Models;

public partial class Order
{
    public int Id { get; set; }

    public int CustomerId { get; set; }

    public DateTime OrderDate { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual ICollection<OrderItem> OrderItems { get; } = new List<OrderItem>();
}
