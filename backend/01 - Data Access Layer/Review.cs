using System;
using System.Collections.Generic;

namespace Restaurant;

public partial class Review
{
    public int ReviewId { get; set; }

    public int? CustomerId { get; set; }

    public int? OrderId { get; set; }

    public DateTime? ReviewDate { get; set; }

    public int? ReviewRating { get; set; }

    public string? ReviewData { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual Order? Order { get; set; }
}
