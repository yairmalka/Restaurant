using System;
using System.Collections.Generic;

namespace Restaurant;

public partial class Order
{
    public int OrderId { get; set; }

    public int? TableId { get; set; }

    public string? OrderType { get; set; }

    public int? CustomerId { get; set; }

    public DateTime? OrderDate { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; } = new List<OrderItem>();

    public virtual ICollection<Review> Reviews { get; } = new List<Review>();

    public virtual Table? Table { get; set; }
}
