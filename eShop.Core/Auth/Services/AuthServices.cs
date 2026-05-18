using BackendMridangini.eShop.Core.Auth.DTOs;
using BackendMridangini.eShop.Core.Auth.Entities;
using BackendMridangini.eShop.Core.Auth.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace BackendMridangini.eShop.Core.Auth.Services;

/* JWT stands for : JSON Web Token, which is a compact, URL-safe means of representing claims to be transferred between two parties.
 * This is how JWT works in formally and briefly:
 * 1. The client sends a login request with credentials (email and password).
 * 2. The server validates the credentials and, if valid, generates a JWT token containing user information and claims.
 * 3. The server sends the JWT token back to the client in the response.
 * 4. The client stores the JWT token and includes it in the Authorization header of subsequent requests to protected endpoints.
 * 5. The server validates the JWT token on each request to ensure the user is authenticated and authorized to access the requested resource.
 * 6. If the token is valid, the server processes the request and returns the appropriate response;
 *    if the token is invalid or expired, the server returns an unauthorized error.
 * 7. The client can log out by deleting the stored JWT token, effectively ending the session.
 */

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly IConfiguration _configuration;

    /**
     * <summary>Initializes a new instance of the <see cref="AuthService"/> class.</summary>
     * <param name="userRepository">The user repository for data access operations.</param>
     * <param name="configuration">The configuration for accessing JWT settings.</param>
     */
    public AuthService(
        IUserRepository userRepository,
        IConfiguration configuration)
    {
        _userRepository = userRepository;

        _configuration = configuration;
    }

    /**
     * <summary>Registers a new user with the provided registration details.</summary>
     * <param name="dto">The registration details, including email and password.</param>\
     * <remarks>The logic works in the following way:
     * 1. Check if a user with the provided email already exists.
     * 2. If not, hash the password and create a new user.
     * </remarks>
     */
    public async Task RegisterAsync( RegisterDto dto)
    {
        var existingUser =
            await _userRepository.GetByEmailAsync(dto.Email);

        if (existingUser is not null)
        {
            throw new Exception(
                "A user with this email already exists.");
        }
        /*
         * BCrypt is a password hashing algorithm that uses a salt to protect against rainbow table attacks and
         * is computationally intensive to mitigate brute-force attacks
         */
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

    /**
     * <summary>Authenticates a user with the provided login details and returns an authentication response.</summary>
     * <param name="dto">The login details, including email and password.</param>
      * <returns>An authentication response containing the access token.</returns>
     * <remarks>The logic works in the following way:
     * 1. Retrieve the user by email.
     * 2. If the user exists, verify the password.
     * 3. If the password is valid, generate a JWT token and return it in the response.
     * 4. If any step fails, throw an exception indicating invalid credentials.
     * </remarks>
     */
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
    
    /**
     * <summary>Generates a JWT token for the authenticated user.</summary>
     * <param name="user">The authenticated user for whom the token is being generated.</param>
     * <returns>A JWT token string that can be used for authentication in subsequent requests.</returns>
     * <remarks>The token includes claims for the user's ID, email, and role,
     * and is signed using a symmetric security key derived from the application's configuration settings.
     * The token is set to expire after 1 hour.</remarks>
     */
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