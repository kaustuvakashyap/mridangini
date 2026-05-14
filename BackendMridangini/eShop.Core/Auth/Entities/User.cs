namespace BackendMridangini.eShop.Core.Auth.Entities;

public class User
{
    public Guid Id { get; set; }

    public string Email { get; set; }
        = string.Empty;

    public string PasswordHash { get; set; }
        = string.Empty;

    public UserRole Role { get; set; }
        = UserRole.User;

    public DateTime CreatedAtUtc { get; set; }
        = DateTime.UtcNow;
}

public enum UserRole
{
    User = 0,
    Admin = 1
}