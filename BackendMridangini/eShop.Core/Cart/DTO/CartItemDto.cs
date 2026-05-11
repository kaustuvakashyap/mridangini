namespace BackendMridangini.eShop.Core.Cart.DTO;

public class CartItemDto
{
    public Guid Id { get; set; }

    public Guid ProductId { get; set; }

    public int Quantity { get; set; }
}