namespace BackendMridangini.eShop.Core.Products.DTOs;

public class ProductQueryDto
{
    public string? Search { get; set; }

    public Guid? CategoryId { get; set; }

    public decimal? MinPrice { get; set; }

    public decimal? MaxPrice { get; set; }

    public bool? InStock { get; set; }

    public string? SortBy { get; set; }

    public bool Descending { get; set; } = false;

    public int Page { get; set; } = 1;

    public int PageSize { get; set; } = 20;
}

