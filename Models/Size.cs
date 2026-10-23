using System;
using System.Collections.Generic;

namespace _1_2.Models;

public partial class Size
{
    public short Id { get; set; }

    public decimal Size1 { get; set; }

    public virtual ICollection<StocksItem> StocksItems { get; set; } = new List<StocksItem>();
}
