using BackendMridangini.eShop.Core.Cart.Entities;

namespace BackendMridangini.eShop.Core.Cart.DTO;

/**
 * <summary>Represents the data transfer object for a shopping cart.</summary>
 * <remarks>
 * This DTO is used to transfer cart data between the application layers.
 * It contains the cart ID, its current state, and a list of items in the cart.
 * The Items property is initialized to an empty list to ensure it is never null.
 * </remarks>
 */
public class CartDto
{
    public Guid Id { get; set; }

    public CartState State { get; set; }

    public IEnumerable<CartItemDto> Items { get; set; }
        = [];
}