using System;
using System.Collections.Generic;

namespace _1_2.Models;

public partial class Order
{
    public short Id { get; set; }

    public DateOnly Date { get; set; }

    public short IdUser { get; set; }

    public virtual User IdUserNavigation { get; set; } = null!;

    public virtual ICollection<ProductsOrder> ProductsOrders { get; set; } = new List<ProductsOrder>();
}
