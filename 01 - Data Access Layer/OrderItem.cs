using System;
using System.Collections.Generic;

namespace Restaurant;

public partial class OrderItem
{
    public int OrderItemId { get; set; }

    public int OrderId { get; set; }

    public int ProductId { get; set; }

    public int? Quantity { get; set; }

    public int? Price { get; set; }

    public string? SpecialRequests { get; set; }

    public virtual Order Order { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
