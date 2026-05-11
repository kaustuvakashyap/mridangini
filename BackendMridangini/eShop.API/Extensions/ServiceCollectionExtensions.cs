using BackendMridangini.eShop.Core.Cart.Interfaces;
using BackendMridangini.eShop.Core.Cart.Services;
using BackendMridangini.eShop.Core.Cart.StateMachine;
using BackendMridangini.eShop.Data.Repositories;

namespace BackendMridangini.eShop.API.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection
        AddApplicationServices(
            this IServiceCollection services)
    {
        services.AddScoped<ICartRepository, CartRepository>();

        services.AddScoped<ICartService, CartService>();

        services.AddScoped<ICartStateMachine, CartStateMachine>();

        return services;
    }
}