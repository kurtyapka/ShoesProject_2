namespace _1_2.Models;

public partial class Order
{
    public short Id { get; set; }

    public DateOnly Date { get; set; }

    public short IdUser { get; set; }

    public virtual User User { get; set; } = null!;

    public virtual ICollection<ProductsOrder> ProductsOrders { get; set; } = new List<ProductsOrder>();
}
