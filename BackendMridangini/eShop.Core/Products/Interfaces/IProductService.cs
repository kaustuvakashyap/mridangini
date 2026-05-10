using BackendMridangini.eShop.Core.Products.DTOs;
namespace BackendMridangini.eShop.Core.Products.Interfaces;

public interface IProductService
{
    /** Tasks are asynchronous operatios that can return a value
     * <summary> a async function that return an IEnumerable ProductDto </summary>
     * <param name="query"> This is a GetProductAsync DTO query Object</param>
    **/
    Task<IEnumerable<ProductDto>> GetProductsAsync(ProductQueryDto query);
    
    
    /**
     * <summary>Async Function that takes in a Product ID and gets returns a ProductDTO</summary>
     * <param name="id"> GUID Id</param>
     */
    Task<ProductDto?> GetProductByIdAsync(Guid id);
    
    /**
     * <summary> Creates Product</summary>
     * <param name="dto"> Takes create product DTO</param>
     */
    Task<ProductDto> CreateProductAsync(CreateProductDto dto);
    
    /**
     * <summary>Update Products using ID, takes UpdateProductDto as one of the params</summary>\
     * <param name="id"> ID</param>
     * <param name="dto"> takes UpdateProductDto</param>
     */
    Task UpdateProductAsync(Guid id, UpdateProductDto dto);
    
    
    /**
     * <summary>Delete product using ID</summary>
     * <param name="id">GUID id </param>
     */
    Task DeleteProductAsync(Guid id);
}
