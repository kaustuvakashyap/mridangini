namespace BackendMridangini.eShop.Core.Products.Controllers;
using eShop.Core.Products.DTOs;
using eShop.Core.Products.Interfaces;
using Microsoft.AspNetCore.Mvc;



[ApiController]
[Route("api/v1/products")]
public class ProductsController : ControllerBase
{
    private readonly IProductService _service;

    public ProductsController(
        IProductService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetProducts(
        [FromQuery] ProductQueryDto query)
    {
        var result =
            await _service.GetProductsAsync(query);

        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetProductById(
        Guid id)
    {
        var product =
            await _service.GetProductByIdAsync(id);

        if (product is null)
        {
            return NotFound(new
            {
                error = new
                {
                    code = "PRODUCT_NOT_FOUND",
                    message = "Product not found."
                }
            });
        }

        return Ok(product);
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct(
        [FromBody] CreateProductDto dto)
    {
        var created =
            await _service.CreateProductAsync(dto);

        return CreatedAtAction(
            nameof(GetProductById),
            new { id = created.Id },
            created);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateProduct(
        Guid id,
        [FromBody] UpdateProductDto dto)
    {
        await _service.UpdateProductAsync(id, dto);

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteProduct(
        Guid id)
    {
        await _service.DeleteProductAsync(id);

        return NoContent();
    }
}
