namespace webbutveckling_labb2_phuusie.Shared.Entities;

public class OrderProduct
{
    public int Id { get; set; }

    public int OrderId { get; set; }

    public int ProductId { get; set; }

    public Product Product { get; set; }

}