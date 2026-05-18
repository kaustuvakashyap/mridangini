using BackendMridangini.eShop.Core.Products.Entities;
using BackendMridangini.eShop.Core.Products.Interfaces;
using BackendMridangini.eShop.Data.Contexts;

using Microsoft.EntityFrameworkCore;

namespace BackendMridangini.eShop.Data.Repositories;
/**
 * <summary>Represents a repository for managing product data.</summary>
 * <remarks>
 * This repository provides methods for retrieving, creating, updating, and soft-deleting products in the
 * database. It implements the IProductRepository interface, which defines the contract for product data access operations.
 * The repository uses Entity Framework Core for data access and includes methods for searching and counting products based on various criteria.
 * </remarks>
 */

public class ProductRepository : IProductRepository
{
    /**
     * <summary>The database context used for accessing product data.</summary>
     */
    private readonly EShopDbContext _db;

    public ProductRepository(
        EShopDbContext db)
    {
        _db = db;
    }

    /**
     * <summary>Retrieves all active products from the database.</summary>
     * <returns>A list of active products.</returns>
     */
    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        return await _db.Products
            .Where(p => p.IsActive)
            .ToListAsync();
    }
    
    /**
     * <summary>Retrieves a product by its unique identifier.</summary>
     * <param name="id">The unique identifier of the product.</param>
     * <returns>The product with the specified ID, or null if not found.</returns>
     * <remarks>The logic works by querying the database for a product with the specified ID and active status.</remarks>
     */
    public async Task<Product?> GetByIdAsync(Guid id)
    {
        return await _db.Products
            .FirstOrDefaultAsync(p =>
                p.Id == id &&
                p.IsActive);
    }
    /**
     * <summary>Searches for products based on various criteria.</summary>
     * <param name="search">The search term for filtering products.</param>
     * <param name="categoryId">The category ID for filtering products.</param>
     * <param name="minPrice">The minimum price for filtering products.</param>
     * <param name="maxPrice">The maximum price for filtering products.</param>
     * <param name="inStock">A value indicating whether to filter for products that are in stock.</param>
     * <param name="sortBy">The property by which to sort the results.</param>
     * <param name="descending">A value indicating whether to sort in descending order.</param>
     * <param name="page">The page number of the results to retrieve.</param>
     * <param name="pageSize">The number of results to retrieve per page.</param>
     * <returns>A list of products matching the search criteria.</returns>
     * <remarks>The logic is as follows:
     * 1. Start with all active products.
     * 2. Apply search filters based on the provided criteria.
     * 3. Sort the results based on the specified property and order.
     * 4. Paginate the results based on the page number and page size.
     * </remarks>
     */
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

    /**
     * <summary>Counts the number of products matching the specified criteria.</summary>
     * <param name="search">The search term for filtering products.</param>
     * <param name="categoryId">The category ID for filtering products.</param>
     * <param name="minPrice">The minimum price for filtering products.</param>
     * <param name="maxPrice">The maximum price for filtering products.</param>
     * <param name="inStock">A value indicating whether to filter for products that are in stock.</param>
     * <returns>The number of products matching the criteria.</returns>
     * <remarks>The logic is as follows:
     * 1. Start with all active products.
     * 2. Apply search filters based on the provided criteria.
     * 3. Count the results based on the specified property and order.
     *
     * These are the local variables involved:
     * - query: An IQueryable<Product> that represents the filtered set of products based on the search criteria.
     * </remarks>
     */
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

    /**
     * <summary>Creates a new product in the database.</summary>
     * <param name="product">The product to create.</param>
     * <returns>The created product with its assigned ID.</returns>
      * <remarks>The logic works as follows:
     * 1. Set the CreatedAtUtc and UpdatedAtUtc properties to the current UTC time.
     * 2. Add the product to the database context.
     * 3. Save the changes to the database.
     * 4. Return the created product, which now includes its assigned ID.
     * </remarks>
     */
    public async Task<Product> CreateAsync(
        Product product)
    {
        product.CreatedAtUtc = DateTime.UtcNow;

        product.UpdatedAtUtc = DateTime.UtcNow;

        await _db.Products.AddAsync(product);

        await _db.SaveChangesAsync();

        return product;
    }
    
    /**
     * <summary>Updates an existing product in the database.</summary>
     * <param name="product">The product to update, which must already exist in the database.</param>
     * <returns>A task representing the asynchronous operation.</returns>
     * <remarks>The logic works as follows:
     * 1. Set the UpdatedAtUtc property to the current UTC time.
     * 2. Update the product in the database context.
     * 3. Save the changes to the database.
     * 4. If a DbUpdateConcurrencyException occurs, it indicates that the product was modified by another user,
     * and an exception is thrown to notify the caller of the concurrency conflict.
     * </remarks>
     */
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
    
    
    /**
     * <summary>Soft-deletes a product by marking it as inactive.</summary>
     * <param name="id">The unique identifier of the product to soft-delete.</param>
     * <returns>A task representing the asynchronous operation.</returns>
     * <remarks>The logic works as follows:
     * 1. Retrieve the product with the specified ID from the database.
     * 2. If the product is not found, throw a KeyNotFoundException.
     * 3. If the product is found, set its IsActive property to false and update the UpdatedAtUtc property to the current UTC time.
     * 4. Save the changes to the database, effectively marking the product as inactive without permanently deleting it from the database.
     * </remarks>
     */
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

    /**
     * <summary>Applies sorting to the product query based on the specified property and order.</summary>
     * <param name="query">The IQueryable<Product> to which sorting will be applied.</param>
     * <param name="sortBy">The property by which to sort the products (e.g., "name", "price", "stock").</param>
     * <param name="descending">A value indicating whether to sort in descending order.</param>
     * <returns>An IQueryable<Product> with the applied sorting.</returns>
     * <remarks>The logic works as follows:
     * 1. The method checks the value of the sortBy parameter and applies the appropriate sorting to the query based on the specified property.
     * 2. If sortBy is "name", the products are sorted by their Name property.
     * 3. If sortBy is "price", the products are sorted by their Price property.
     * 4. If sortBy is "stock", the products are sorted by their Stock property.
     * 5. If sortBy is null or does not match any of the specified properties, the products are sorted by their Name property by default.
     * 6. The sorting order (ascending or descending) is determined by the value of the descending parameter.
     * </remarks>
     */
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