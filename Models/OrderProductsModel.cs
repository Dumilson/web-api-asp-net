namespace OrderManager.Models;

public class OrderProductsModel
{

    public Guid Id { get; set; }
    public Guid OrderId { get; set; }
    public Guid ProductId { get; set; }

    public int Quantity { get; set; }

    public OrderProductsModel(){}

    public OrderProductsModel(Guid orderId, Guid productId, int quantity)
    {
        Id = Guid.NewGuid();
        OrderId = orderId;
        ProductId = productId;
        Quantity = quantity;
    }
}
