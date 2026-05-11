namespace BackendMridangini.eShop.Core.Cart.Exception;

public class InsufficientStockException : System.Exception
{
    public InsufficientStockException(
        Guid productId,
        int requestedQuantity,
        int availableStock)
        : base(
            $"Insufficient stock for product '{productId}'. " +
            $"Requested: {requestedQuantity}, " +
            $"Available: {availableStock}.")
    {
    }
}