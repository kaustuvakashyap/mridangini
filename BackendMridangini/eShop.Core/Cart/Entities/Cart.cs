namespace BackendMridangini.eShop.Core.Cart.Entities;


public class Cart
{
    public Guid Id { get; init; }

    public Guid UserId { get; set; }

    public CartState State { get; set; }
        = CartState.Empty;

    public ICollection<CartItem> Items { get; set; }
        = new List<CartItem>();

    public DateTime CreatedAtUtc { get; set; }
        = DateTime.UtcNow;

    public DateTime UpdatedAtUtc { get; set; }
        = DateTime.UtcNow;
}