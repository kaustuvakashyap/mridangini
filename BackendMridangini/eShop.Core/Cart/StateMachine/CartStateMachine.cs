namespace BackendMridangini.eShop.Core.Cart.StateMachine;

using Entities;
using Exception;


/**
 * <summary>
 * Represents the state machine for managing the state of a shopping cart.
 * </summary>
 *  <remarks>
 * The CartStateMachine class implements the ICartStateMachine interface and defines the behavior of the shopping cart based on its current state.
 * It handles state transitions for adding items, removing items, checking out, and processing payment results.
 * The state machine ensures that the cart transitions between states in a valid manner and throws exceptions for invalid state transitions.
 * </remarks>
 */
public class CartStateMachine : ICartStateMachine
{
    /**
     * <summary> * Adds an item to the cart and updates the cart state accordingly.
     * </summary>
     * <param name="cart">The cart to which the item is being added.</param>
     */
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
                throw new InvalidCartStateTransitionException(cart.State,
                    nameof(AddItem));

            case CartState.Cleared:
                cart.State = CartState.Active;
                break;

            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    /**
     * <summary> * Removes an item from the cart and updates the cart state accordingly.
     * </summary>
     * <param name="cart">The cart from which the item is being removed.</param>
     */
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

    /**
     * <summary>Initiates the checkout process for the cart and updates the cart state accordingly.
     * </summary>
     * <param name="cart">The cart for which to initiate checkout.</param>
     */
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

    /**
     * <summary>Processes a successful payment for the cart and updates the cart state accordingly.
     * </summary>
     * <param name="cart">The cart for which the payment succeeded.</param>
     */
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

    /*
     * <summary>Processes a failed payment for the cart and updates the cart state accordingly.
     * </summary>
     * <param name="cart">The cart for which the payment failed.</param>
     */
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