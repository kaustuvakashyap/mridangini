using BackendMridangini.eShop.Core.Products.DTOs;
namespace BackendMridangini.eShop.Core.Products.Interfaces;

public interface IProductService
{
    
    Task<IEnumerable<ProductDto>> GetProductsAsync(
        ProductQueryDto query);

    Task<int> CountProductsAsync(
        ProductQueryDto query);

    Task<ProductDto?> GetProductByIdAsync(Guid id);

    Task<ProductDto> CreateProductAsync(
        CreateProductDto dto);

    Task UpdateProductAsync(
        Guid id,
        UpdateProductDto dto);

    Task DeleteProductAsync(Guid id);
}
