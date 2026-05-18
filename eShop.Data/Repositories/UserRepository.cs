using BackendMridangini.eShop.Core.Auth.Entities;
using BackendMridangini.eShop.Core.Auth.Interfaces;
using BackendMridangini.eShop.Data.Contexts;

using Microsoft.EntityFrameworkCore;

namespace BackendMridangini.eShop.Data.Repositories;

public class UserRepository
    : IUserRepository
{
    private readonly EShopDbContext _db;

    public UserRepository(
        EShopDbContext db)
    {
        _db = db;
    }

    public async Task<User?> GetByEmailAsync(
        string email)
    {
        return await _db.Users
            .FirstOrDefaultAsync(u =>
                u.Email.ToLower() == email.ToLower());
    }

    public async Task CreateAsync(
        User user)
    {
        await _db.Users.AddAsync(user);

        await _db.SaveChangesAsync();
    }
}