using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Intrinsics.X86;

namespace InventoryManagement.Core.Models;

public partial class OrderItem
{
    public int OrderId { get; set; }
    public int ProductId { get; set; }

    public int Quantity { get; set; }

    public virtual Order Order { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
