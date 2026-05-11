using BackendMridangini.eShop.Core.Cart.Entities;

namespace BackendMridangini.eShop.Core.Cart.DTO;

public class CartDto
{
    public Guid Id { get; set; }

    public CartState State { get; set; }

    public IEnumerable<CartItemDto> Items { get; set; }
        = [];
}