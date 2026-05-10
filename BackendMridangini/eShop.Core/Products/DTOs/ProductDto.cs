using BackendMridangini.eShop.Core.Products.Entities;

namespace BackendMridangini.eShop.Core.Products.DTOs;

public class ProductDto
{
    public string Name { get; set; } = string.Empty;
    
    public Guid Id {get; set;}

    public string Description { get; set; } = string.Empty;

    public decimal Price { get; set; }

    public int Stock { get; set; }

    public CategoryEnum CategoryId { get; set; }
    public int StockCount { get; set; }
    public bool InStock { get; set; }
}
