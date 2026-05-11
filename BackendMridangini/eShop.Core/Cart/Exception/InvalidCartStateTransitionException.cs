namespace BackendMridangini.eShop.Core.Cart.Exception;


using BackendMridangini.eShop.Core.Cart.Entities;


public class InvalidCartStateTransitionException : System.Exception
{
    public InvalidCartStateTransitionException(
        CartState currentState,
        string attemptedAction)
        : base(
            $"Cannot perform action '{attemptedAction}' " +
            $"while cart is in '{currentState}' state.")
    {
    }
}