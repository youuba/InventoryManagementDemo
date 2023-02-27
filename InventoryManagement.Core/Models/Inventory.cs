using System;
using System.Collections.Generic;

namespace InventoryManagement.Core.Models;

public partial class Inventory
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public int StockLevel { get; set; }

    public int MinStockLevel { get; set; }

    public virtual Product Product { get; set; } = null!;
}
