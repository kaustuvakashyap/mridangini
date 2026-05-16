namespace BackendMridangini.eShop.Core.Cart.Exception;


using BackendMridangini.eShop.Core.Cart.Entities;


public class InvalidCartStateTransitionException : System.Exception
{
    /**
     * <summary>Initializes a new instance of the <see cref="InvalidCartStateTransitionException"/> class.</summary>
     * <param name="currentState">The current state of the cart.</param>
     * <param name="attemptedAction">The action that was attempted.</param>
     */
    public InvalidCartStateTransitionException(
        CartState currentState,
        string attemptedAction)
        : base(
            $"Cannot perform action '{attemptedAction}' " +
            $"while cart is in '{currentState}' state.")
    {
    }
}