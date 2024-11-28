using OrderManager.Repositories;

namespace OrderManager.Routes;

public static class UserRoutes
{
    public static void UserRoute(this WebApplication app)
    {
            var routes = app.MapGroup("clients").WithName("clients");
            routes.MapGet("", async (ClientRepository repo) =>
            {
                var users = await repo.GetClientsAsync();
                return Results.Ok(users);
            });
    }
}