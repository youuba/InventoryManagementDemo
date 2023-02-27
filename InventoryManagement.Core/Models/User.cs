using System;
using System.Collections.Generic;

namespace InventoryManagement.Core.Models;

public partial class User
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Email { get; set; } = null!;

    public bool IsAdmin { get; set; }
}
