using Microsoft.EntityFrameworkCore;
using OrderManager.Data;
using OrderManager.Models;
using OrderManager.Request;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrderManager.Repositories
{
    public class OrderRepository
    {
        private readonly OrderContext _context;
        private readonly OrderProductRepository _orderProductRepository;
        private readonly ProductRepository _productRepository;

        public OrderRepository(OrderContext context, OrderProductRepository orderProductRepository,
            ProductRepository productRepository)
        {
            _context = context;
            _orderProductRepository = orderProductRepository;
            _productRepository = productRepository;
        }

        public async Task<List<OrderModel>> GetAllOrdersAsync()
        {
            var orders = _context.Orders;

            /*Include(o => o.Products)
            .ThenInclude(p => p.Name);      */

            return await orders.ToListAsync();
        }

        public async Task<OrderModel> getOrder(Guid id)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(o => o.Id == id);


            /*.Include(o => o.Products)
            .FirstOrDefaultAsync(o => o.Id == id);  */
            return order;
        }

        public async Task UpdateOrderStatusPeriodicallyAsync(OrderModel order)
        {
            
            var updateInterval = TimeSpan.FromSeconds(5);
            while (order.Status != "Concluído")
            {
                await Task.Delay(updateInterval);
                order.Status = "Em Processamento"; 

                _context.Orders.Update(order);
                await _context.SaveChangesAsync();
                if (order.Status == "Em Processamento")
                {
                    order.Status = "Concluído";
                    await _context.SaveChangesAsync();
                }
            }
        }

        public async Task CreateAsync(OrderRequest order)
        {

            
            
            decimal total = 0;
            var orderPayload = new OrderModel(order.ClientID, 10, "Pendente");

            var orderItems = new List<OrderProductsModel>();
            foreach (var item in order.Items)
            {
                var product = await _productRepository.GetProductById(item.ItemID);

                if (product == null)
                {
                    throw new InvalidOperationException($"Produto com ID {item.ItemID} não encontrado.");
                }

                total += product.Price * item.Quantity;

                var orderItem = new OrderProductsModel(orderPayload.Id, item.ItemID, item.Quantity);
                orderItems.Add(orderItem);

            }

            await _context.Orders.AddAsync(orderPayload);
            await _context.SaveChangesAsync();
        }
    }


}