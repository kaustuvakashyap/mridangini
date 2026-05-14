using BackendMridangini.eShop.Core.Auth.DTOs;

namespace BackendMridangini.eShop.Core.Auth.Interfaces;

public interface IAuthService
{
    Task RegisterAsync(RegisterDto dto);

    Task<AuthResponseDto> LoginAsync(LoginDto dto);
}