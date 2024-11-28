using Microsoft.EntityFrameworkCore;
using OrderManager.Models;

namespace OrderManager.Data;

public class OrderProductContext : DbContext
{
    public OrderProductContext(DbContextOptions<OrderProductContext> options)
        : base(options)
    {
    }

    public DbSet<OrderProductsModel> OrderProducts { get; set; }
}