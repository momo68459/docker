 public class Order
{
    // Primary Key
    public int OrderId { get; set; }

    // Foreign Key to Customer
    public int CustomerID { get; set; }

    // Foreign Key to Product
    public int? ProductID { get; set; }

    public DateTime OrderDate { get; set; }

    public int Quantity { get; set; }

    public decimal UnitPrice { get; set; }

    // Navigation Properties
    public virtual Customer? Customer { get; set; }

    public virtual Product? Product { get; set; }
}