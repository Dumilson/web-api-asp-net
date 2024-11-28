namespace OrderManager.Models;

public class OrderModel
{
    public Guid Id { get; set; }
    public Guid ClientID { get; set; }
    public decimal Total { get; set; }
    public string? Status { get; set; }

    public OrderModel() { }


    public OrderModel(Guid clientId, decimal total, string? status)
    {
        Id = new Guid();
        ClientID = clientId;
        Total = total;
        Status = status;
    }

    public void ChangeStatus(string? status)
    {
        Status = status;
    }
}