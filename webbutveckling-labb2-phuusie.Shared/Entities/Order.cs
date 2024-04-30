using System.ComponentModel.DataAnnotations;

namespace webbutveckling_labb2_phuusie.Shared.Entities;

public class Order
{
    [Key]
    public int OrderId { get; set; }

    public int CustomerId { get; set; }

    public Customer Customer { get; set; }

    public IEnumerable<OrderProduct> OrderedProducts { get; set; }

}