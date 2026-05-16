namespace BackendMridangini.eShop.Core.Cart.Interfaces;

using BackendMridangini.eShop.Core.Cart.Entities;

/**
 * <remarks>
 * Repository interface for managing Cart entities. Provides methods for retrieving, creating, updating, and deleting carts.
 * This interface abstracts the data access layer, allowing for different implementations. Its methods include:
 *  - GetByIdAsync: Retrieves a cart by its unique identifier.
 *  - GetByUserIdAsync: Retrieves a cart associated with a specific user.
 *  - CreateAsync: Creates a new cart.
 *  - UpdateAsync: Updates an existing cart.
 *  - DeleteAsync: Deletes a cart.
 *  - SaveChangesAsync: Saves changes to the data store.
 * </remarks>
 */
public interface ICartRepository
{
    Task<Cart?> GetByIdAsync(Guid cartId);

    Task<Cart?> GetByUserIdAsync(Guid userId);

    Task CreateAsync(Cart cart);

    Task UpdateAsync(Cart cart);

    Task DeleteAsync(Cart cart);

    Task SaveChangesAsync();
}