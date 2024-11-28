using Microsoft.EntityFrameworkCore;
using OrderManager.Data;
using OrderManager.Models;
using OrderManager.Repositories;
using OrderManager.Routes;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<OrderRepository>();
builder.Services.AddScoped<OrderProductRepository>();
builder.Services.AddScoped<ProductRepository>();
builder.Services.AddScoped<ClientRepository>();
ConfigureDbContext<OrderContext>(builder.Services);
ConfigureDbContext<OrderProductContext>(builder.Services);
ConfigureDbContext<ProductContext>(builder.Services);
ConfigureDbContext<ClientContext>(builder.Services);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.OrderRoute();
app.ProductRoute();
app.UserRoute();

app.UseHttpsRedirection();
app.Run();
return;

void ConfigureDbContext<TContext>(IServiceCollection services) where TContext : DbContext
{
    services.AddDbContext<TContext>(x =>
        x.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionDefault")));
}

