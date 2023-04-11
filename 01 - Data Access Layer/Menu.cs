using System;
using System.Collections.Generic;

namespace Restaurant;

public partial class Menu
{
    public int MenuItemId { get; set; }

    public int? CategoryId { get; set; }

    public string? MenuItemName { get; set; }

    public string? MenuItemDescription { get; set; }

    public int? MenuItemPrice { get; set; }

    public virtual Category? Category { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; } = new List<OrderItem>();
}
