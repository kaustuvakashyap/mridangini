namespace BackendMridangini.eShop.Core.Cart.DTO;

/**
 * <summary>Represents the data transfer object for a cart item.</summary>
 * <remarks>
 * This DTO is used to transfer cart item data between the application layers.
 * It contains the cart item ID, the associated product ID, and the quantity of the product in the cart.
 * The Id property is used to uniquely identify each cart item,
 * while the ProductId property links the cart item to a specific product in the inventory.
 * The Quantity property indicates how many units of the product are in the cart.
 * </remarks>
 */
public class CartItemDto
{
    public Guid Id { get; set; }

    public Guid ProductId { get; set; }

    public int Quantity { get; set; }
}