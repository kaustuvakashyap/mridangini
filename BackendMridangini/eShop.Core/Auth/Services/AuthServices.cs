using BackendMridangini.eShop.Core.Auth.DTOs;
using BackendMridangini.eShop.Core.Auth.Entities;
using BackendMridangini.eShop.Core.Auth.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace BackendMridangini.eShop.Core.Auth.Services;

public class AuthService
    : IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly IConfiguration _configuration;

    public AuthService(
        IUserRepository userRepository,
        IConfiguration configuration)
    {
        _userRepository = userRepository;

        _configuration = configuration;
    }

    public async Task RegisterAsync(
        RegisterDto dto)
    {
        var existingUser =
            await _userRepository.GetByEmailAsync(dto.Email);

        if (existingUser is not null)
        {
            throw new Exception(
                "A user with this email already exists.");
        }

        var passwordHash =
            BCrypt.Net.BCrypt.HashPassword(dto.Password);

        var user = new User
        {
            Email = dto.Email,
            PasswordHash = passwordHash,
            Role = UserRole.User
        };

        await _userRepository.CreateAsync(user);
    }

    public async Task<AuthResponseDto> LoginAsync(
        LoginDto dto)
    {
        var user =
            await _userRepository.GetByEmailAsync(dto.Email);

        if (user is null)
        {
            throw new Exception(
                "Invalid email or password.");
        }

        var passwordValid =
            BCrypt.Net.BCrypt.Verify(
                dto.Password,
                user.PasswordHash);

        if (!passwordValid)
        {
            throw new Exception(
                "Invalid email or password.");
        }

        var token = GenerateToken(user);

        return new AuthResponseDto
        {
            AccessToken = token
        };
    }
    
    private string GenerateToken(User user)
    {
        var key =
            _configuration["Jwt:Key"]
            ?? throw new Exception("JWT Key missing.");

        var issuer =
            _configuration["Jwt:Issuer"];

        var audience =
            _configuration["Jwt:Audience"];

        var securityKey =
            new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(key));

        var credentials =
            new SigningCredentials(
                securityKey,
                SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(
                JwtRegisteredClaimNames.Sub,
                user.Id.ToString()),

            new Claim(
                JwtRegisteredClaimNames.Email,
                user.Email),

            new Claim(
                ClaimTypes.Role,
                user.Role.ToString())
        };

        var token = new JwtSecurityToken(
            issuer: issuer,
            audience: audience,
            claims: claims,
            expires: DateTime.UtcNow.AddHours(1),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler()
            .WriteToken(token);
    }
}