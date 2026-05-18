using BackendMridangini.eShop.Core.Auth.Entities;

namespace BackendMridangini.eShop.Core.Auth.Interfaces;

/**
 * <summary>Defines the user repository contract.</summary>
 * <remarks>
 * This interface defines the contract for the user repository, which handles data access operations for user entities.
 * </remarks>
 */
public interface IUserRepository
{
    Task<User?> GetByEmailAsync(string email);

    Task CreateAsync(User user);
}