namespace BackendMridangini.eShop.Core.Cart.Interfaces;

using BackendMridangini.eShop.Core.Cart.Entities;


public interface ICartRepository
{
    Task<Cart?> GetByIdAsync(Guid cartId);

    Task<Cart?> GetByUserIdAsync(Guid userId);

    Task CreateAsync(Cart cart);

    Task UpdateAsync(Cart cart);

    Task DeleteAsync(Cart cart);

    Task SaveChangesAsync();
}