using Microsoft.EntityFrameworkCore;
using OrderManager.Models;

namespace OrderManager.Data;

public class ClientContext : DbContext
{
    public ClientContext(DbContextOptions<ClientContext> options) : base(options)
    {
    }

    public DbSet<ClientModel> Clients { get; set; }
}