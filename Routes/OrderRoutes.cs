using OrderManager.Repositories;
using OrderManager.Request;

namespace OrderManager.Routes;

public static class OrderRoutes
{
    public static void OrderRoute(this WebApplication app)
    {
        var routes = app.MapGroup("orders");

        routes.MapGet("", async (OrderRepository repo) =>
        {
            var orders = await repo.getAllOrders();
            return Results.Ok(orders);
        });

        routes.MapPost("", (OrderRequest req, OrderRepository repo) =>
        {
            repo.Create(req);
            return Results.Ok("Ok");
        });
    }
}