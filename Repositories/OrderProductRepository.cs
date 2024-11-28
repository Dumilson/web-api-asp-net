using Microsoft.EntityFrameworkCore;
using OrderManager.Data;
using OrderManager.Models;

namespace OrderManager.Repositories
{
    public class OrderProductRepository
    {
        private readonly OrderProductContext _context;

        public OrderProductRepository(OrderProductContext context)
        {
            _context = context;
        }

        
        public async Task CreateProductAsync(Guid orderId, Guid productId, int quantity)
        {
            var createOrderProduct = new OrderProductsModel(orderId, productId, quantity);
            await _context.OrderProducts.AddAsync(createOrderProduct);
            await _context.SaveChangesAsync(); 
        } 
    }


}
