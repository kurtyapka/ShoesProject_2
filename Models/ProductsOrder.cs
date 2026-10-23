using System;
using System.Collections.Generic;

namespace _1_2.Models;

public partial class ProductsOrder
{
    public int Id { get; set; }

    public short IdOrder { get; set; }

    public short IdStockItem { get; set; }

    public short Count { get; set; }

    public virtual Order IdOrderNavigation { get; set; } = null!;

    public virtual StocksItem IdStockItemNavigation { get; set; } = null!;
}
