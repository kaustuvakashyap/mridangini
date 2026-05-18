namespace BackendMridangini.eShop.Core.Cart.Exception;

public class InsufficientStockException : System.Exception
{
    /**
     * <summary>Initializes a new instance of the <see cref="InsufficientStockException"/> class.</summary>
     * <param name="productId">The unique identifier of the product.</param>
     * <param name="requestedQuantity">The quantity requested.</param>
     * <param name="availableStock">The available stock.</param>
     */
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