using BackendMridangini.eShop.Core.Cart.Entities;
using BackendMridangini.eShop.Core.Cart.Interfaces;
using BackendMridangini.eShop.Data.Contexts;

using Microsoft.EntityFrameworkCore;

namespace BackendMridangini.eShop.Data.Repositories;

/**
 * <summary>Repository class for managing cart data operations.</summary>
 * <remarks>
 * This class implements the ICartRepository interface and provides methods for retrieving, creating, updating,
 * and deleting cart entities from the database. It uses Entity Framework Core for data access and interacts with the EShopDbContext.
 * The methods include:
 *  - GetByIdAsync: Retrieves a cart by its unique identifier.
 *  - GetByUserIdAsync: Retrieves a cart associated with a specific user.
 *  - CreateAsync: Creates a new cart.
 *  - UpdateAsync: Updates an existing cart.
 *  - DeleteAsync: Deletes a cart.
 *  - SaveChangesAsync: Saves changes to the data store.
 * </remarks>
 */

//  Task in C# is a promise that is an asynchronous operation.
//  calling an asynchronous method that returns a Task, it will execute the method asynchronously and
// return a Task object that you can await to get the result once the operation is complete.
// this basically means: if I promise a async op to return a value, you can use Task<T> where T is the type of the value being returned.

public class CartRepository : ICartRepository
{
    private readonly EShopDbContext _context;

    /**
     * <summary>Initializes the DB context for the cart method </summary>
     * <param name="context"> type : EshopDbContext</param>
     */
    public CartRepository(EShopDbContext context)
    {
        _context = context;
    }
    
    /**<summary>Retrieves a cart by its unique identifier.</summary>
     * <param name="cartId">The unique identifier of the cart.</param>
     * <returns>The cart if found; otherwise, null.</returns> 
     */
    public async Task<Cart?> GetByIdAsync(Guid cartId)
    {
        return await _context.Carts
            .Include(c => c.Items)
            .FirstOrDefaultAsync(c => c.Id == cartId);
    }

    /**
     * <summary>Retrieves a cart associated with a specific user.</summary>
     * <param name="userId">The unique identifier of the user.</param>
     * <returns>The cart if found; otherwise, null.</returns>
     */
    public async Task<Cart?> GetByUserIdAsync(Guid userId)
    {
        return await _context.Carts
            .Include(c => c.Items)
            .FirstOrDefaultAsync(c => c.UserId == userId);
    }
    
    /**
     * <summary>Creates a new cart.</summary>
     * <param name="cart">The cart to create.</param>
     * 
     */
    public async Task CreateAsync(Cart cart)
    {
        await _context.Carts.AddAsync(cart);
    }

    /**
    * <summary>Updates an existing cart.</summary>
    * <param name="cart">The cart to update.</param>
    */
    public Task UpdateAsync(Cart cart)
    {
        _context.Carts.Update(cart);

        return Task.CompletedTask;
    }

    /**
     * <summary>Deletes a cart.</summary>
     * <param name="cart">The cart to delete.</param>
     */
    public Task DeleteAsync(Cart cart)
    {
        _context.Carts.Remove(cart);

        return Task.CompletedTask;
    }

    /**
     * <summary>Saves changes to the data store.</summary>
     */
    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}