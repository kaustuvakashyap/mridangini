using BackendMridangini.eShop.Core.Products.Entities;
using BackendMridangini.eShop.Core.Products.Interfaces;
using BackendMridangini.eShop.Data.Contexts;

using Microsoft.EntityFrameworkCore;

namespace BackendMridangini.eShop.Data.Repositories;

public class ProductRepository
    : IProductRepository
{
    private readonly EShopDbContext _db;

    public ProductRepository(
        EShopDbContext db)
    {
        _db = db;
    }

    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        return await _db.Products
            .Where(p => p.IsActive)
            .ToListAsync();
    }

    public async Task<Product?> GetByIdAsync(Guid id)
    {
        return await _db.Products
            .FirstOrDefaultAsync(p =>
                p.Id == id &&
                p.IsActive);
    }

    public async Task<IEnumerable<Product>> SearchAsync(
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
        IQueryable<Product> query =
            _db.Products
                .Where(p => p.IsActive);

        if (!string.IsNullOrWhiteSpace(search))
        {
            var lowered = search.ToLower();

            query = query.Where(p =>
                p.Name.ToLower().Contains(lowered) ||
                p.Description.ToLower().Contains(lowered));
        }

        if (categoryId.HasValue)
        {
            query = query.Where(p =>
                p.TypeCategory == categoryId.Value);
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

        query = ApplySorting(
            query,
            sortBy,
            descending);

        return await query
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    public async Task<int> CountAsync(
        string? search,
        CategoryEnum? categoryId,
        decimal? minPrice,
        decimal? maxPrice,
        bool? inStock)
    {
        IQueryable<Product> query =
            _db.Products
                .Where(p => p.IsActive);

        if (!string.IsNullOrWhiteSpace(search))
        {
            var lowered = search.ToLower();

            query = query.Where(p =>
                p.Name.ToLower().Contains(lowered) ||
                p.Description.ToLower().Contains(lowered));
        }

        if (categoryId.HasValue)
        {
            query = query.Where(p =>
                p.TypeCategory == categoryId.Value);
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

        return await query.CountAsync();
    }

    public async Task<Product> CreateAsync(
        Product product)
    {
        product.CreatedAtUtc = DateTime.UtcNow;

        product.UpdatedAtUtc = DateTime.UtcNow;

        await _db.Products.AddAsync(product);

        await _db.SaveChangesAsync();

        return product;
    }

    public async Task UpdateAsync(
        Product product)
    {
        product.UpdatedAtUtc = DateTime.UtcNow;

        _db.Products.Update(product);

        try
        {
            await _db.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            throw new Exception(
                "Product was modified by another user.");
        }
    }

    public async Task SoftDeleteAsync(
        Guid id)
    {
        var product = await _db.Products
            .FirstOrDefaultAsync(p => p.Id == id);

        if (product is null)
        {
            throw new KeyNotFoundException(
                "Product not found.");
        }

        product.IsActive = false;

        product.UpdatedAtUtc = DateTime.UtcNow;

        await _db.SaveChangesAsync();
    }

    private static IQueryable<Product> ApplySorting(
        IQueryable<Product> query,
        string? sortBy,
        bool descending)
    {
        return (sortBy?.ToLower()) switch
        {
            "name" => descending
                ? query.OrderByDescending(p => p.Name)
                : query.OrderBy(p => p.Name),

            "price" => descending
                ? query.OrderByDescending(p => p.Price)
                : query.OrderBy(p => p.Price),

            "stock" => descending
                ? query.OrderByDescending(p => p.Stock)
                : query.OrderBy(p => p.Stock),

            _ => query.OrderBy(p => p.Name)
        };
    }
}