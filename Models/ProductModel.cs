namespace OrderManager.Models;

public class ProductModel
{
    
    public Guid Id { get; set; }
    public string? Name { get; set; }
    
    public decimal Price { get; set; }

    public OrderModel Order { get; set; }

    public ProductModel(){}
    public ProductModel(string? name, decimal price)
    {
        Id = Guid.NewGuid();
        Name = name;
        Price = price;
    }
}