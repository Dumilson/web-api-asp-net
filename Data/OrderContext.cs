using Microsoft.EntityFrameworkCore;
using OrderManager.Models;

namespace OrderManager.Data;

public class OrderContext : DbContext
{
    public OrderContext(DbContextOptions<OrderContext> options) : base(options)
    {
    }

    public DbSet<OrderModel> Orders { get; set; }
}