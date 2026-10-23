using System;
using System.Collections.Generic;

namespace _1_2.Models;

public partial class Manufacturer
{
    public int Id { get; set; }

    public string ManufacturerName { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
