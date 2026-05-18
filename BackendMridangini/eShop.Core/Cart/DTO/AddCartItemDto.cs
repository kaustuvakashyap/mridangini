namespace BackendMridangini.eShop.Core.Cart.DTO;

/**
 * <summary>Represents the data transfer object for adding a cart item.</summary>
 * <remarks>
 * This DTO is used when a client wants to add an item to the shopping cart.
 * It contains the product ID and the quantity to be added.
 * </remarks>
 */
public class AddCartItemDto
{
    public Guid ProductId { get; set; }

    public int Quantity { get; set; }
}