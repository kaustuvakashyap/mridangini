namespace BackendMridangini.eShop.Core.Products.Services;

using Common.Model;
using DTOs;
using Entities;
using Interfaces;
    

public class ProductService(IProductRepository repository) : IProductService
{
    public async Task<IEnumerable<ProductDto>> GetProductsAsync(ProductQueryDto query)
    {
        query.Page = Math.Max(query.Page, 1);

        query.PageSize = Math.Clamp(
            query.PageSize,
            1,
            100);

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

                TotalPages =
                    (int)Math.Ceiling(
                        totalCount /
                        (double)query.PageSize)
            }
        };
    }

    public Task<int> CountProductsAsync(ProductQueryDto query)
    {
        throw new NotImplementedException();
    }

    public async Task<ProductDto?>
        GetProductByIdAsync(Guid id)
    {
        var product = await repository.GetByIdAsync(id);

        if (product is null || !product.IsActive)
        {
            return null;
        }

        return MapToDto(product);
    }

    public async Task<ProductDto>
        CreateProductAsync(CreateProductDto dto)
    {
        ValidatePrice(dto.Price);

        ValidateStock(dto.Stock);

        var product = new Products
        {
            Name = dto.Name,
            Description = dto.Description,
            Price = dto.Price,
            Stock = dto.Stock,
            CategoryId = dto.CategoryId,
            IsActive = true
        };

        var created =
            await repository.CreateAsync(product);

        return MapToDto(created);
    }

    public async Task UpdateProductAsync(
        Guid id,
        UpdateProductDto dto)
    {
        ValidatePrice(dto.Price);

        ValidateStock(dto.Stock);

        var existing =
            await repository.GetByIdAsync(id);

        if (existing is null)
        {
            throw new Exception("Product not found.");
        }

        existing.Name = dto.Name;
        existing.Description = dto.Description;
        existing.Price = dto.Price;
        existing.Stock = dto.Stock;
        existing.CategoryId = dto.CategoryId;
        existing.UpdatedAtUtc = DateTime.UtcNow;

        await repository.UpdateAsync(existing);
    }

    public async Task DeleteProductAsync(Guid id)
    {
        await repository.SoftDeleteAsync(id);
    }

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

            CategoryId = product.CategoryId
        };
    }

    private static void ValidatePrice(decimal price)
    {
        if (price < 0)
        {
            throw new Exception(
                "Price cannot be negative.");
        }
    }

    private static void ValidateStock(int stock)
    {
        if (stock < 0)
        {
            throw new Exception(
                "Stock cannot be negative.");
        }
    }
}
