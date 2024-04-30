using webbutveckling_labb2_phuusie.Shared.Entities;

namespace webbutveckling_labb2_phuusie.Shared.DTOs.OrderDTOs;

public class GetOrderProductsDto
{
    public int Id { get; set; }

    public int OrderId { get; set; }

    public int ProductId { get; set; }

    public Product Product { get; set; }
}