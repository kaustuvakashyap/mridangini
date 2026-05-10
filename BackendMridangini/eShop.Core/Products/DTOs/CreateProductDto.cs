using BackendMridangini.eShop.Core.Products.Entities;

namespace BackendMridangini.eShop.Core.Products.DTOs;

public class CreateProductDto
{

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public decimal Price { get; set; }

    public int Stock { get; set; }

    public CategoryEnum CategoryId { get; set; }
}
