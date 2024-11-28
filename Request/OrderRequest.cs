namespace OrderManager.Request;

public record Item(Guid ItemID, int Quantity);
public record OrderRequest(Guid ClientID, List<Item> Items);