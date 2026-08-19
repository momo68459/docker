using System.ComponentModel.DataAnnotations;

public class Customer
{
    public Customer()
    {
        // 初始化集合屬性，避免在使用時出現 NullReferenceException
        Orders = new HashSet<Order>();
    }

    // Primary Key
    public int? CustomerID { get; set; }

    public string? Name { get; set; }

    public string? Photo { get; set; }

    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime Birthday { get; set; }

    // Navigation Property
    public virtual ICollection<Order> Orders { get; set; }
}

    
