using Microsoft.EntityFrameworkCore;
using OrderManager.Data;
using OrderManager.Models;

namespace OrderManager.Repositories;

public class ProductRepository
{
    private readonly ProductContext _context;

    public ProductRepository(ProductContext context)
    {
        _context = context;
    }

    public async Task<List<ProductModel>> GetAllProducts()
    {
        var products = await _context.Products.ToListAsync();
        return products;
    }

    public async Task<ProductModel> GetProductById(Guid id)
    {
        var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
        return product;
    }
}