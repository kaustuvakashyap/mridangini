namespace BackendMridangini.eShop.Core.Auth.Entities;

/**
 * <summary>Represents a user in the system.</summary>
 * <remarks>
 * This entity represents a user account in the application.
 * It contains information about the user's identity, authentication details, and role.
 * </remarks>
 */
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
/**
 * <summary>Defines the roles that a user can have in the system.</summary>
 * <remarks>
 * This enumeration defines the different roles that a user can have in the application.
 * The User role represents a regular user with limited permissions, while the Admin role represents a user
 * with elevated permissions who can manage the application and perform administrative tasks.
 * The role of a user determines what actions they are allowed to perform within the application.
 * </remarks>
 */
public enum UserRole
{
    User = 0,
    Admin = 1
}