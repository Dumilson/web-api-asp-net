using Microsoft.EntityFrameworkCore;
using OrderManager.Data;
using OrderManager.Models;

namespace OrderManager.Repositories;

public class ClientRepository
{
    private readonly ClientContext _context;
    public ClientRepository(ClientContext context)
    {
        _context = context;
    }

    public async Task<List<ClientModel>> GetClientsAsync()
    {
        var users = await _context.Clients.ToListAsync();
        return users;
    }
}