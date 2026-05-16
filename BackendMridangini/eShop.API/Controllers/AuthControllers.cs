using BackendMridangini.eShop.Core.Auth.DTOs;
using BackendMridangini.eShop.Core.Auth.Interfaces;

using Microsoft.AspNetCore.Mvc;

namespace BackendMridangini.eShop.API.Controllers;

/**
 * <summary>Represents the authentication controller for handling user authentication operations.</summary>
 * <remarks>
 * This controller provides endpoints for user registration and login.
 * It uses the IAuthService to perform the necessary authentication logic.
 * The Register endpoint allows new users to create an account, while the Login endpoint allows existing users to authenticate and receive a token for subsequent requests.
 * The controller is decorated with the ApiController attribute to enable automatic model validation and response formatting, and it is routed to "api/v1/auth" for versioning purposes.
 * </remarks>
 */
[ApiController]
[Route("api/v1/auth")]
public class AuthController
    : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(
        IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(
        [FromBody] RegisterDto dto)
    {
        await _authService.RegisterAsync(dto);

        return StatusCode(201);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(
        [FromBody] LoginDto dto)
    {
        var response =
            await _authService.LoginAsync(dto);

        return Ok(response);
    }
}