using Microsoft.EntityFrameworkCore;
using OrderManager.Models;

namespace OrderManager.Data;

public class ProductContext : DbContext
{
    public ProductContext(DbContextOptions<ProductContext> options) : base(options)
    {
    }

    public DbSet<ProductModel> Products { get; set; }
}