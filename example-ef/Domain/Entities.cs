namespace Domain;

public class Order
{
    public int Id { get; set; }
    public string OrderNumber { get; set; } = String.Empty;
    public int? CustomerId { get; set; }
    public virtual Customer? Customer { get; set; }
    public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    public DateTime OrderDate { get; set; }
}

public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<Order> Orders { get; set; } = new List<Order>();
}

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
}

public class OrderItem
{
    public int Id { get; set; }
    public int? OrderId { get; set; }
    public virtual Order? Order { get; set; }
    public int? ProductId { get; set; }
    public virtual Product? Product { get; set; }
    public int Quantity { get; set; }
}