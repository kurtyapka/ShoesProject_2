using System;
using System.Collections.Generic;

namespace _1_2.Models;

public partial class StocksItem
{
    public short Id { get; set; }

    public short IdProduct { get; set; }

    public short IdSize { get; set; }

    public int Count { get; set; }

    public virtual Product IdProductNavigation { get; set; } = null!;

    public virtual Size IdSizeNavigation { get; set; } = null!;

    public virtual ICollection<ProductsOrder> ProductsOrders { get; set; } = new List<ProductsOrder>();
}
