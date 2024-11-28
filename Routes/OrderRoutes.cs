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
            var orders = await repo.GetAllOrdersAsync();
            return Results.Ok(orders);
        });


        routes.MapGet("{id:guid}", async (Guid id, OrderRepository repo) =>
        {
            var orders = await repo.getOrder(id);
            return Results.Ok(orders);
        });



        routes.MapPost("", async (OrderRequest req, OrderRepository repo, ClientRepository client) =>
        {
            var clients =   client.GetClientById(req.ClientID);
            if (clients == null)
            {
                return Results.NotFound("Cliente não econtrado");
            }

            var saveOrder =  repo.CreateAsync(req);
            return Results.Ok(req);
        });
    }
}