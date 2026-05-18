using BackendMridangini.eShop.Core.Auth.DTOs;

namespace BackendMridangini.eShop.Core.Auth.Interfaces;

/**
 * <summary>Defines the authentication service contract.</summary>
 * <remarks>
 * This interface defines the contract for the authentication service, which handles user registration and login functionality.
 * </remarks>
 */
public interface IAuthService
{
    Task RegisterAsync(RegisterDto dto);

    Task<AuthResponseDto> LoginAsync(LoginDto dto);
}