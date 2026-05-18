using BackendMridangini.eShop.Core.Products.Entities;
using BackendMridangini.eShop.Core.Products.Interfaces;

namespace BackendMridangini.eShop.Data.Mock;

public class MockProductRepository : IProductRepository
{
    private static readonly List<Product> Products =
    [
        new()
        {
            Id = Guid.NewGuid(),
            Name = "Mridanga",
            Description = "A Hindu Percussion Instrument",
            Price = 4999.99m,
            Stock = 12,
            IsActive = true,
            TypeCategory = CategoryEnum.Membranophone,
            CreatedAtUtc = DateTime.UtcNow,
            UpdatedAtUtc = DateTime.UtcNow
        },

        new()
        {
            Id = Guid.NewGuid(),
            Name = "Mohor Xingor Pepa",
            Description = "An Assamese Wind Instrument",
            Price = 2499.50m,
            Stock = 20,
            IsActive = true,
            TypeCategory = CategoryEnum.Aerophone,
            CreatedAtUtc = DateTime.UtcNow,
            UpdatedAtUtc = DateTime.UtcNow
        }
    ];

    public Task<IEnumerable<Product>> GetAllAsync()
    {
        return Task.FromResult(Products.AsEnumerable());
    }

    public Task<Product?> GetByIdAsync(Guid id)
    {
        var product = Products.FirstOrDefault(p => p.Id == id);

        return Task.FromResult(product);
    }

    public Task<IEnumerable<Product>> SearchAsync(
        string? search,
        CategoryEnum? categoryId,
        decimal? minPrice,
        decimal? maxPrice,
        bool? inStock,
        string? sortBy,
        bool descending,
        int page,
        int pageSize)
    {
        IEnumerable<Product> query = Products;

        if (!string.IsNullOrWhiteSpace(search))
        {
            query = query.Where(p => p.Name.Contains(search, StringComparison.OrdinalIgnoreCase));
        }

        if (categoryId.HasValue)
        {
            query = query.Where(p => p.TypeCategory == categoryId.Value);
        }

        if (minPrice.HasValue)
        {
            query = query.Where(p => p.Price >= minPrice.Value);
        }

        if (maxPrice.HasValue)
        {
            query = query.Where(p => p.Price <= maxPrice.Value);
        }

        if (inStock.HasValue)
        {
            query = inStock.Value
                    ? query.Where(p => p.Stock > 0) 
                    : query.Where(p => p.Stock <= 0);
        }

        query = sortBy?.ToLower() switch
        {
            "price" => descending
                ? query.OrderByDescending(p => p.Price)
                : query.OrderBy(p => p.Price),

            "name" => descending
                ? query.OrderByDescending(p => p.Name)
                : query.OrderBy(p => p.Name),

            _ => query.OrderBy(p => p.Name)
        };

        query = query
            .Skip((page - 1) * pageSize)
            .Take(pageSize);

        return Task.FromResult(query);
    }

    public Task<int> CountAsync(string? search,
        CategoryEnum? categoryId,
        decimal? minPrice,
        decimal? maxPrice,
        bool? inStock)
    {
        IEnumerable<Product> query = Products;

        if (!string.IsNullOrWhiteSpace(search))
        {
            query = query.Where(p =>
                p.Name.Contains(search,
                    StringComparison.OrdinalIgnoreCase));
        }

        return Task.FromResult(query.Count());
    }

    public Task<Product> CreateAsync(Product product)
    {
        product.Id = Guid.NewGuid();

        product.CreatedAtUtc = DateTime.UtcNow;

        product.UpdatedAtUtc = DateTime.UtcNow;

        Products.Add(product);

        return Task.FromResult(product);
    }

    public Task UpdateAsync(Product product)
    {
        var existing = Products.FirstOrDefault(
            p => p.Id == product.Id);

        if (existing is null)
        {
            return Task.CompletedTask;
        }

        existing.Name = product.Name;
        existing.Description = product.Description;
        existing.Price = product.Price;
        existing.Stock = product.Stock;
        existing.TypeCategory = product.TypeCategory;
        existing.UpdatedAtUtc = DateTime.UtcNow;

        return Task.CompletedTask;
    }

    public Task SoftDeleteAsync(Guid id)
    {
        var product = Products.FirstOrDefault(
            p => p.Id == id);

        if (product is null) return Task.CompletedTask;
        product.IsActive = false;
        product.UpdatedAtUtc = DateTime.UtcNow;

        return Task.CompletedTask;
    }
}
