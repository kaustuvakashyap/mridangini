using BackendMridangini.eShop.Core.Products.Entities;
using BackendMridangini.eShop.Core.Products.Interfaces;

namespace BackendMridangini.eShop.Data.Mock;

public class MockProductRepository : IProductRepository
{
    private static readonly List<Products> _products =
    [
        new Products
        {
            Id = Guid.NewGuid(),
            Name = "Mridanga",
            Description = "A Hindu Percussion Instrument",
            Price = 4999.99m,
            Stock = 12,
            IsActive = true,
            CategoryId = Guid.NewGuid(),
            CreatedAtUtc = DateTime.UtcNow,
            UpdatedAtUtc = DateTime.UtcNow
        },

        new Products
        {
            Id = Guid.NewGuid(),
            Name = "Mohor Xingor Pepa",
            Description = "An Assamese Wind Instrument",
            Price = 2499.50m,
            Stock = 20,
            IsActive = true,
            CategoryId = Guid.NewGuid(),
            CreatedAtUtc = DateTime.UtcNow,
            UpdatedAtUtc = DateTime.UtcNow
        }
    ];

    public Task<IEnumerable<Products>> GetAllAsync()
    {
        return Task.FromResult(_products.AsEnumerable());
    }

    public Task<Products?> GetByIdAsync(Guid id)
    {
        var product = _products.FirstOrDefault(p => p.Id == id);

        return Task.FromResult(product);
    }

    public Task<IEnumerable<Products>> SearchAsync(
        string? search,
        Guid? categoryId,
        decimal? minPrice,
        decimal? maxPrice,
        bool? inStock,
        string? sortBy,
        bool descending,
        int page,
        int pageSize)
    {
        IEnumerable<Products> query = _products;

        if (!string.IsNullOrWhiteSpace(search))
        {
            query = query.Where(p =>
                p.Name.Contains(search,
                    StringComparison.OrdinalIgnoreCase));
        }

        if (categoryId.HasValue)
        {
            query = query.Where(p =>
                p.CategoryId == categoryId.Value);
        }

        if (minPrice.HasValue)
        {
            query = query.Where(p =>
                p.Price >= minPrice.Value);
        }

        if (maxPrice.HasValue)
        {
            query = query.Where(p =>
                p.Price <= maxPrice.Value);
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

    public Task<int> CountAsync(
        string? search,
        Guid? categoryId,
        decimal? minPrice,
        decimal? maxPrice,
        bool? inStock)
    {
        IEnumerable<Products> query = _products;

        if (!string.IsNullOrWhiteSpace(search))
        {
            query = query.Where(p =>
                p.Name.Contains(search,
                    StringComparison.OrdinalIgnoreCase));
        }

        return Task.FromResult(query.Count());
    }

    public Task<Products> CreateAsync(Products product)
    {
        product.Id = Guid.NewGuid();

        product.CreatedAtUtc = DateTime.UtcNow;

        product.UpdatedAtUtc = DateTime.UtcNow;

        _products.Add(product);

        return Task.FromResult(product);
    }

    public Task UpdateAsync(Products product)
    {
        var existing = _products.FirstOrDefault(
            p => p.Id == product.Id);

        if (existing is null)
        {
            return Task.CompletedTask;
        }

        existing.Name = product.Name;
        existing.Description = product.Description;
        existing.Price = product.Price;
        existing.Stock = product.Stock;
        existing.CategoryId = product.CategoryId;
        existing.UpdatedAtUtc = DateTime.UtcNow;

        return Task.CompletedTask;
    }

    public Task SoftDeleteAsync(Guid id)
    {
        var product = _products.FirstOrDefault(
            p => p.Id == id);

        if (product is not null)
        {
            product.IsActive = false;
            product.UpdatedAtUtc = DateTime.UtcNow;
        }

        return Task.CompletedTask;
    }
}
