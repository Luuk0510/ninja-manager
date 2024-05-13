using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ninja_manager.Models;

public partial class Ninja
{
    public int Id { get; set; }

    [StringLength(50, ErrorMessage = "Name cannot be longer than 50 characters.")]
    public string Name { get; set; } = null!;

    [Range(0, 9999.99, ErrorMessage = "Gold cannot be greater than 9999")]
    public double Gold { get; set; }

    public virtual ICollection<Inventory> Inventories { get; set; } = new List<Inventory>();
}
