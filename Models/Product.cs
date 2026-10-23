using System;
using System.Collections.Generic;

namespace _1_2.Models;

public partial class Product
{
    public short Id { get; set; }

    public int IdCategorie { get; set; }

    public int IdPodcategorie { get; set; }

    public string Image { get; set; } = null!;

    public string Name { get; set; } = null!;

    public int IdManufacturers { get; set; }

    public string Description { get; set; } = null!;

    public string Compound { get; set; } = null!;

    public decimal Price { get; set; }

    public virtual Category IdCategorieNavigation { get; set; } = null!;

    public virtual Manufacturer IdManufacturersNavigation { get; set; } = null!;

    public virtual Podcategory IdPodcategorieNavigation { get; set; } = null!;

    public virtual ICollection<StocksItem> StocksItems { get; set; } = new List<StocksItem>();
}
