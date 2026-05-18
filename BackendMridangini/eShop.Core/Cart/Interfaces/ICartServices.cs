using BackendMridangini.eShop.Core.Cart.DTO;

namespace BackendMridangini.eShop.Core.Cart.Interfaces;

public interface ICartService
{
    Task<CartDto> GetCartAsync(Guid userId);

    Task<CartDto> AddItemAsync(
        Guid userId,
        AddCartItemDto dto);

    Task<CartDto> UpdateItemQuantityAsync(
        Guid userId,
        Guid cartItemId,
        int quantity);

    Task<CartDto> RemoveItemAsync(
        Guid userId,
        Guid cartItemId);

    Task CheckoutAsync(Guid userId);
}