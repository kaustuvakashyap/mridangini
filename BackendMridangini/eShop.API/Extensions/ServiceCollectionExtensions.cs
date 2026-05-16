using BackendMridangini.eShop.Core.Cart.Interfaces;
using BackendMridangini.eShop.Core.Cart.Services;
using BackendMridangini.eShop.Core.Cart.StateMachine;
using BackendMridangini.eShop.Core.Products.Interfaces;
using BackendMridangini.eShop.Data.Repositories;
using BackendMridangini.eShop.Core.Auth.Interfaces;
using BackendMridangini.eShop.Core.Auth.Services;

namespace BackendMridangini.eShop.API.Extensions;
/**
 * <summary>Provides extension methods for configuring application services.</summary>
 * <remarks>
 * This class contains extension methods for the IServiceCollection interface, allowing for the registration of application services
 * in a centralized and organized manner. The AddApplicationServices method registers the necessary services for the eShop application,
 * including repositories, services, and state machines. This promotes a clean separation of concerns and makes
 * it easier to manage dependencies throughout the application.
 * </remarks>
 */

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