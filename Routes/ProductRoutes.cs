using OrderManager.Repositories;

namespace OrderManager.Routes;

public static class ProductRoutes
{
    public static void ProductRoute(this WebApplication app)
    {
        var routes = app.MapGroup("products").WithName("products");;

        app.MapGet("", async (ProductRepository repo) =>
        {
            var allProducts = await repo.GetAllProducts();
            return Results.Ok(allProducts);
        });
    }
}