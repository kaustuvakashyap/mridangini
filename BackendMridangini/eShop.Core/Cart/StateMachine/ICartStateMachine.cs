namespace BackendMridangini.eShop.Core.Cart.StateMachine;

using BackendMridangini.eShop.Core.Cart.Entities;


public interface ICartStateMachine
{
    void AddItem(Cart cart);

    void RemoveItem(Cart cart);

    void Checkout(Cart cart);

    void PaymentSucceeded(Cart cart);

    void PaymentFailed(Cart cart);
}