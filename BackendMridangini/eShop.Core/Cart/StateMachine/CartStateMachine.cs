namespace BackendMridangini.eShop.Core.Cart.StateMachine;

using BackendMridangini.eShop.Core.Cart.Entities;
using BackendMridangini.eShop.Core.Cart.Exception;


public class CartStateMachine : ICartStateMachine
{
    public void AddItem(Cart cart)
    {
        switch (cart.State)
        {
            case CartState.Empty:
                cart.State = CartState.Active;
                break;

            case CartState.Active:
                break;

            case CartState.Locked:
                throw new InvalidCartStateTransitionException(
                    cart.State,
                    nameof(AddItem));

            case CartState.Cleared:
                cart.State = CartState.Active;
                break;

            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    public void RemoveItem(Cart cart)
    {
        switch (cart.State)
        {
            case CartState.Active:

                if (!cart.Items.Any())
                {
                    cart.State = CartState.Empty;
                }

                break;

            case CartState.Locked:
                throw new InvalidCartStateTransitionException(
                    cart.State,
                    nameof(RemoveItem));

            default:
                throw new InvalidCartStateTransitionException(
                    cart.State,
                    nameof(RemoveItem));
        }
    }

    public void Checkout(Cart cart)
    {
        switch (cart.State)
        {
            case CartState.Active:
                cart.State = CartState.Locked;
                break;

            default:
                throw new InvalidCartStateTransitionException(
                    cart.State,
                    nameof(Checkout));
        }
    }

    public void PaymentSucceeded(Cart cart)
    {
        switch (cart.State)
        {
            case CartState.Locked:
                cart.State = CartState.Cleared;
                break;

            default:
                throw new InvalidCartStateTransitionException(
                    cart.State,
                    nameof(PaymentSucceeded));
        }
    }

    public void PaymentFailed(Cart cart)
    {
        switch (cart.State)
        {
            case CartState.Locked:
                cart.State = CartState.Active;
                break;

            default:
                throw new InvalidCartStateTransitionException(
                    cart.State,
                    nameof(PaymentFailed));
        }
    }
}