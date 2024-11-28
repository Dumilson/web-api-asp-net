using Microsoft.EntityFrameworkCore;
using OrderManager.Data;
using OrderManager.Models;
using OrderManager.Request;

namespace OrderManager.Repositories;

public class OrderRepository
{
    private readonly OrderContext _context;
    private readonly OrderProductRepository _orderProductRepository;

    public OrderRepository(OrderContext context, OrderProductRepository orderProductRepository)
    {
        _context = context;
        _orderProductRepository = _orderProductRepository;
    }


    public async Task<List<OrderModel>> getAllOrders()
    {
        var cars = await _context.Orders.ToListAsync();
        return cars;
    }

    public void Create(OrderRequest order)
    {

        var orderPayload = new OrderModel(order.ClientID, 10, "Pendente");
        foreach (var item in order.Items)
        {
            _orderProductRepository.CreateProduct(orderPayload.Id, item.ItemID, item.Quantity);
        }
        _context.Add(orderPayload);
        _context.SaveChanges();
    }
}