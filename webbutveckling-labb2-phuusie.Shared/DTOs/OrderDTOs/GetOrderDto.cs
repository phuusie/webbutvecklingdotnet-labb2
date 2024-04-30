using webbutveckling_labb2_phuusie.Shared.Entities;

namespace webbutveckling_labb2_phuusie.Shared.DTOs.OrderDTOs;

public class GetOrderDto
{
    public int OrderId { get; set; }

    public int CustomerId { get; set; }

    public Customer Customer { get; set; }

    public List<OrderProduct> OrderedProducts { get; set; }

}