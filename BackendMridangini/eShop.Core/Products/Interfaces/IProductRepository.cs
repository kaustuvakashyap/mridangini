using BackendMridangini.eShop.Core.Products.Entities;
namespace BackendMridangini.eShop.Core.Products.Interfaces;


public interface IProductRepository
{
    Task<IEnumerable<Entities.Products>> GetAllAsync(); //to be used later if necessary

    Task<Entities.Products?> GetByIdAsync(Guid id);

    Task<IEnumerable<Entities.Products>> SearchAsync(
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

    Task<Entities.Products> CreateAsync(Entities.Products product);

    Task UpdateAsync(Entities.Products product);

    Task SoftDeleteAsync(Guid id);
}
