using OrderManager.Data;
using OrderManager.Models;

namespace OrderManager.Repositories;

public class OrderProductRepository
{
    private readonly OrderProductContext _context;

    public OrderProductRepository(OrderProductContext context)
    {
        _context = context;
    }

    public void CreateProduct(Guid orderId, Guid productId, int quantity)
    {
        var createOrderProduct = new OrderProductsModel(orderId, productId, quantity);
        _context.OrderProducts.Add(createOrderProduct);
        _context.SaveChanges();
    }
}