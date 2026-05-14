using BackendMridangini.eShop.Core.Auth.Entities;

namespace BackendMridangini.eShop.Core.Auth.Interfaces;

public interface IUserRepository
{
    Task<User?> GetByEmailAsync(string email);

    Task CreateAsync(User user);
}