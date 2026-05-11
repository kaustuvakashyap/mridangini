using BackendMridangini.eShop.Core.Cart.Entities;
using BackendMridangini.eShop.Core.Cart.Interfaces;
using BackendMridangini.eShop.Data.Contexts;

using Microsoft.EntityFrameworkCore;

namespace BackendMridangini.eShop.Data.Repositories;

public class CartRepository : ICartRepository
{
    private readonly EShopDbContext _context;

    public CartRepository(EShopDbContext context)
    {
        _context = context;
    }

    public async Task<Cart?> GetByIdAsync(Guid cartId)
    {
        return await _context.Carts
            .Include(c => c.Items)
            .FirstOrDefaultAsync(c => c.Id == cartId);
    }

    public async Task<Cart?> GetByUserIdAsync(Guid userId)
    {
        return await _context.Carts
            .Include(c => c.Items)
            .FirstOrDefaultAsync(c => c.UserId == userId);
    }

    public async Task CreateAsync(Cart cart)
    {
        await _context.Carts.AddAsync(cart);
    }

    public Task UpdateAsync(Cart cart)
    {
        _context.Carts.Update(cart);

        return Task.CompletedTask;
    }

    public Task DeleteAsync(Cart cart)
    {
        _context.Carts.Remove(cart);

        return Task.CompletedTask;
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}