using BackendMridangini.eShop.Core.Products.Entities;
namespace BackendMridangini.eShop.Core.Products.Interfaces;


public interface IProductRepository
{
    Task<IEnumerable<Entities.Product>> GetAllAsync(); //to be used later if necessary

    Task<Entities.Product?> GetByIdAsync(Guid id);

    Task<IEnumerable<Entities.Product>> SearchAsync(
        string? search,
        CategoryEnum? categoryId,
        decimal? minPrice,
        decimal? maxPrice,
        bool? inStock,
        string? sortBy,
        bool descending,
        int page,
        int pageSize);

    Task<int> CountAsync(string? search,
        CategoryEnum? categoryId,
        decimal? minPrice,
        decimal? maxPrice,
        bool? inStock);

    Task<Entities.Product> CreateAsync(Entities.Product product);

    Task UpdateAsync(Entities.Product product);

    Task SoftDeleteAsync(Guid id);
}
