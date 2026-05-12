using BackendMridangini.eShop.Core.Cart.Entities; 
using Microsoft.EntityFrameworkCore; 
using BackendMridangini.eShop.Core.Products.Entities;
namespace BackendMridangini.eShop.Data.Contexts;



public class EShopDbContext : DbContext
{
    public EShopDbContext(DbContextOptions<EShopDbContext> options) : base(options)
    {
    } 
    public DbSet<Cart> Carts { get; set; } 
    public DbSet<CartItem> CartItems { get; set; } 
    public DbSet<Product> Products { get; set; }
    protected override void OnModelCreating( ModelBuilder modelBuilder) 
    { base.OnModelCreating(modelBuilder); 
        modelBuilder.ApplyConfigurationsFromAssembly( typeof(EShopDbContext).Assembly); 
    }
}