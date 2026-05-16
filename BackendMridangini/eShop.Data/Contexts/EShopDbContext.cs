using BackendMridangini.eShop.Core.Cart.Entities; 
using Microsoft.EntityFrameworkCore; 
using BackendMridangini.eShop.Core.Products.Entities;
using BackendMridangini.eShop.Core.Auth.Entities;
namespace BackendMridangini.eShop.Data.Contexts;


/**
 * <summary>Represents the database context for the eShop application.</summary>
 * <remarks>
 * This context manages the database connection and provides access to the entities in the eShop application.
 * It includes DbSet properties for Carts, CartItems, Products, and Users.
 * The OnModelCreating method is overridden to apply entity configurations from the assembly.
 * This context is used by the repositories to perform CRUD operations on the database.
 * </remarks>
 */

public class EShopDbContext : DbContext
{
    public EShopDbContext(DbContextOptions<EShopDbContext> options) : base(options)
    {} 
    public DbSet<Cart> Carts { get; set; } 
    public DbSet<CartItem> CartItems { get; set; } 
    public DbSet<Product> Products { get; set; }
    public DbSet<User> Users { get; set; }
    protected override void OnModelCreating( ModelBuilder modelBuilder) 
    { base.OnModelCreating(modelBuilder); 
        modelBuilder.ApplyConfigurationsFromAssembly( typeof(EShopDbContext).Assembly); 
    }
}