using BackendMridangini.eShop.Core.Cart.DTO;
using BackendMridangini.eShop.Core.Cart.Entities;
using BackendMridangini.eShop.Core.Cart.Exception;
using BackendMridangini.eShop.Core.Cart.Interfaces;
using BackendMridangini.eShop.Core.Cart.StateMachine;
using BackendMridangini.eShop.Core.Products.Interfaces;

namespace BackendMridangini.eShop.Core.Cart.Services;

public class CartService : ICartService
{
    private readonly ICartRepository _cartRepository;

    private readonly IProductRepository _productRepository;

    private readonly ICartStateMachine _stateMachine;

    public CartService(
        ICartRepository cartRepository,
        IProductRepository productRepository,
        ICartStateMachine stateMachine)
    {
        _cartRepository = cartRepository;

        _productRepository = productRepository;

        _stateMachine = stateMachine;
    }

    public async Task<CartDto> GetCartAsync(Guid userId)
    {
        var cart = await _cartRepository.GetByUserIdAsync(userId);

        if (cart is null)
        {
            cart = new Entities.Cart
            {
                UserId = userId
            };

            await _cartRepository.CreateAsync(cart);

            await _cartRepository.SaveChangesAsync();
        }

        return MapToDto(cart);
    }

    public async Task<CartDto> AddItemAsync(
        Guid userId,
        AddCartItemDto dto)
    {
        var cart = await _cartRepository.GetByUserIdAsync(userId);

        if (cart is null)
        {
            cart = new Entities.Cart
            {
                UserId = userId
            };

            await _cartRepository.CreateAsync(cart);
        }

        var product = await _productRepository.GetByIdAsync(dto.ProductId);

        if (product is null)
        {
            throw new KeyNotFoundException(
                $"Product '{dto.ProductId}' not found.");
        }

        if (dto.Quantity > product.Stock)
        {
            throw new InsufficientStockException(
                product.Id,
                dto.Quantity,
                product.Stock);
        }

        _stateMachine.AddItem(cart);

        var existingItem = cart.Items
            .FirstOrDefault(i => i.ProductId == dto.ProductId);

        if (existingItem is not null)
        {
            existingItem.Quantity += dto.Quantity;
        }
        else
        {
            cart.Items.Add(new CartItem
            {
                ProductId = dto.ProductId,
                Quantity = dto.Quantity
            });
        }

        cart.UpdatedAtUtc = DateTime.UtcNow;

        await _cartRepository.UpdateAsync(cart);

        await _cartRepository.SaveChangesAsync();

        return MapToDto(cart);
    }

    public async Task<CartDto> UpdateItemQuantityAsync(
        Guid userId,
        Guid cartItemId,
        int quantity)
    {
        var cart = await _cartRepository.GetByUserIdAsync(userId)
            ?? throw new KeyNotFoundException("Cart not found.");

        var item = cart.Items
            .FirstOrDefault(i => i.Id == cartItemId)
            ?? throw new KeyNotFoundException("Cart item not found.");

        var product = await _productRepository
            .GetByIdAsync(item.ProductId);

        if (product is null)
        {
            throw new KeyNotFoundException(
                $"Product '{item.ProductId}' not found.");
        }

        if (quantity > product.Stock)
        {
            throw new InsufficientStockException(
                product.Id,
                quantity,
                product.Stock);
        }

        item.Quantity = quantity;

        cart.UpdatedAtUtc = DateTime.UtcNow;

        await _cartRepository.UpdateAsync(cart);

        await _cartRepository.SaveChangesAsync();

        return MapToDto(cart);
    }

    public async Task<CartDto> RemoveItemAsync(
        Guid userId,
        Guid cartItemId)
    {
        var cart = await _cartRepository.GetByUserIdAsync(userId)
            ?? throw new KeyNotFoundException("Cart not found.");

        var item = cart.Items
            .FirstOrDefault(i => i.Id == cartItemId)
            ?? throw new KeyNotFoundException("Cart item not found.");

        cart.Items.Remove(item);

        _stateMachine.RemoveItem(cart);

        cart.UpdatedAtUtc = DateTime.UtcNow;

        await _cartRepository.UpdateAsync(cart);

        await _cartRepository.SaveChangesAsync();

        return MapToDto(cart);
    }

    public async Task CheckoutAsync(Guid userId)
    {
        var cart = await _cartRepository.GetByUserIdAsync(userId)
            ?? throw new KeyNotFoundException("Cart not found.");

        _stateMachine.Checkout(cart);

        cart.UpdatedAtUtc = DateTime.UtcNow;

        await _cartRepository.UpdateAsync(cart);

        await _cartRepository.SaveChangesAsync();
    }

    private static CartDto MapToDto(Entities.Cart cart)
    {
        return new CartDto
        {
            Id = cart.Id,

            State = cart.State,

            Items = cart.Items.Select(i => new CartItemDto
            {
                Id = i.Id,
                ProductId = i.ProductId,
                Quantity = i.Quantity
            })
        };
    }
}