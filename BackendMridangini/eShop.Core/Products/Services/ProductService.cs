namespace BackendMridangini.eShop.Core.Products.Services;

using Common.Model;
using DTOs;
using Entities;
using Interfaces;
    
/**
 * <summary>ProductService inherits from IProductService and implements methods from the interface such as
 * </summary>
 */
public class ProductService(IProductRepository repository) : IProductService
{
    /**
     * <summary>GetProductAsync() returns an Enumerable ProductDto aka Return products</summary>
     * <param name="query"> takes in a Product QueryDto</param>
     */
    public async Task<IEnumerable<ProductDto>> GetProductsAsync(ProductQueryDto query)
    {
        query.Page = Math.Max(query.Page, 1);
        query.PageSize = Math.Clamp(query.PageSize, 1, 100);

        var products = await repository.SearchAsync(
            query.Search,
            query.CategoryId,
            query.MinPrice,
            query.MaxPrice,
            query.InStock,
            query.SortBy,
            query.Descending,
            query.Page,
            query.PageSize);

        var totalCount = await repository.CountAsync(
            query.Search,
            query.CategoryId,
            query.MinPrice,
            query.MaxPrice,
            query.InStock);

        var dtoList = products.Select(MapToDto);

        return new PagedResult<ProductDto>
        {
            Data = dtoList,
            Meta = new PaginationMeta
            {
                CurrentPage = query.Page,
                PageSize = query.PageSize,
                TotalCount = totalCount,
                TotalPages = (int)Math.Ceiling(totalCount / (double)query.PageSize)
            }
        };
    }

  
    /**
     * <summary>Fetches Products by Product ID. returns a Product DTO</summary>
     * <param name="id"> Type: Guid, identifies product by ID</param>
     * <returns>ProductDto Object product </returns>
     */
    public async Task<ProductDto?>GetProductByIdAsync(Guid id)
    {
        var product = await repository.GetByIdAsync(id);
        if (product is null || !product.IsActive)  return null;
        return MapToDto(product);
    }
    
    /**
     * <summary>Creates a Product and returns ProductDto</summary>
     * <param name="dto"> Takes a CreateProductDto object as argument</param>
     * <returns>ProductDto Object</returns>
     */
    public async Task<ProductDto> CreateProductAsync(CreateProductDto dto)
    {
        ValidatePrice(dto.Price);
        ValidateStock(dto.Stock);
        var product = new Products
        {
            Name = dto.Name,
            Description = dto.Description,
            Price = dto.Price,
            Stock = dto.Stock,
            TypeCategory = dto.CategoryId,
            IsActive = true
        };

        var created = await repository.CreateAsync(product);
        return MapToDto(created);
    }

    /**
     * <summary>Updates Existing Product in Catalogue</summary>
     * <param name="id"> The Guid ID</param>
     * <param name="dto"> Object of UpdateProduct DTO</param>
     * <returns>No returns</returns>
     */
    public async Task UpdateProductAsync(Guid id, UpdateProductDto dto)
    {
        ValidatePrice(dto.Price);
        ValidateStock(dto.Stock);
        var existing =
            await repository.GetByIdAsync(id);

        if (existing is null) throw new Exception("Product not found.");

        existing.Name = dto.Name;
        existing.Description = dto.Description;
        existing.Price = dto.Price;
        existing.Stock = dto.Stock;
        existing.TypeCategory = dto.CategoryId;
        existing.UpdatedAtUtc = DateTime.UtcNow;

        await repository.UpdateAsync(existing);
    }

    public async Task DeleteProductAsync(Guid id)
    {
        await repository.SoftDeleteAsync(id);
    }

    /**
     * <summary>Maps Object Data to DTOs</summary>
     * <param name="product">Take object of type Product</param>
     * <returns>Returns a Product DTO object</returns>
     */
    private static ProductDto MapToDto(Products product)
    {
        return new ProductDto
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            StockCount = product.Stock,
            InStock = product.Stock > 0,
            CategoryId = product.TypeCategory
        };
    }

    private static void ValidatePrice(decimal price)
    {
        if (price < 0) throw new Exception("Price cannot be negative.");
    }

    private static void ValidateStock(int stock)
    {
        if (stock < 0) throw new Exception("Stock cannot be negative.");
    }
}
