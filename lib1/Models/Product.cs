public class Product
{
    public Product()
    {
        Orders = new HashSet<Order>();
    }

    // Primary Key
    public int ProductID { get; set; }

    public string? Name { get; set; }

    public byte[]? Photo { get; set; }

    // Navigation Property
    public virtual ICollection<Order> Orders { get; set; }
}