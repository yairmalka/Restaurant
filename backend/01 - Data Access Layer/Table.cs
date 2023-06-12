using System;
using System.Collections.Generic;

namespace Restaurant;

public partial class Table
{
    public int TableId { get; set; }

    public int? TableNumber { get; set; }

    public bool? TableAvailable { get; set; }

    public int TableNumOfSeats { get; set; }

    public virtual ICollection<Order> Orders { get; } = new List<Order>();
}
