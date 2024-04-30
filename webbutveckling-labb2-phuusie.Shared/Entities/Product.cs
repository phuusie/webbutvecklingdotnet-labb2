using System.ComponentModel.DataAnnotations;

namespace webbutveckling_labb2_phuusie.Shared.Entities;

public class Product
{
    [Key]
    public int ProductId { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public double Price { get; set; }

    public int? CategoryId { get; set; }

    public ProductCategory? Category { get; set; }

    public string? Image { get; set; }

    public bool IsInStorage { get; set; }
}