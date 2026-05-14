using BackendMridangini.eShop.Core.Auth.DTOs;
using BackendMridangini.eShop.Core.Auth.Interfaces;

using Microsoft.AspNetCore.Mvc;

namespace BackendMridangini.eShop.API.Controllers;

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