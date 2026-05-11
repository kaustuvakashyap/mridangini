namespace BackendMridangini.eShop.Core.Cart.DTO;

public class AddCartItemDto
{
    public Guid ProductId { get; set; }

    public int Quantity { get; set; }
}