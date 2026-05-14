using BackendMridangini.eShop.Core.Cart.Interfaces;
using BackendMridangini.eShop.Core.Cart.Services;
using BackendMridangini.eShop.Core.Cart.StateMachine;
using BackendMridangini.eShop.Core.Products.Interfaces;
using BackendMridangini.eShop.Data.Repositories;
using BackendMridangini.eShop.Core.Auth.Interfaces;
using BackendMridangini.eShop.Core.Auth.Services;

namespace BackendMridangini.eShop.API.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection
        AddApplicationServices(
            this IServiceCollection services)
    {
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<ICartRepository, CartRepository>();

        services.AddScoped<ICartService, CartService>();

        services.AddScoped<ICartStateMachine, CartStateMachine>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IAuthService, AuthService>();
        

        return services;
    }
}