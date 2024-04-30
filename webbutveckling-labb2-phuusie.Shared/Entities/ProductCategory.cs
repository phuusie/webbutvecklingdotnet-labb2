using System.ComponentModel.DataAnnotations;

namespace webbutveckling_labb2_phuusie.Shared.Entities;

public class ProductCategory
{
    [Key]
    public int CategoryId { get; set; }

    public string Name { get; set; }

}