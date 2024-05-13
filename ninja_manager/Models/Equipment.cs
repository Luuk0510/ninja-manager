using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ninja_manager.Models;

public partial class Equipment
{
    public int Id { get; set; }

    public string CategoryName { get; set; } = null!;

    [StringLength(50, ErrorMessage = "Name cannot be longer than 50 characters.")]
    public string Name { get; set; } = null!;

    [Range(-999, 999, ErrorMessage = "Strength cannot be greater than 999.")]
    public int Strength { get; set; }

    [Range(-999, 999, ErrorMessage = "Intelligence cannot be greater than 999.")]
    public int Intelligence { get; set; }

    [Range(-999, 999, ErrorMessage = "Agility cannot be greater than 999.")]
    public int Agility { get; set; }

    [Range(-999, 999.99, ErrorMessage = "Gold cannot be greater than 999.")]
    public double Gold { get; set; }

    public virtual Categorie CategoryNameNavigation { get; set; } = null!;

    public virtual ICollection<Inventory> Inventories { get; set; } = new List<Inventory>();
}
