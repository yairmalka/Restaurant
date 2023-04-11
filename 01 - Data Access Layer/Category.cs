using System;
using System.Collections.Generic;

namespace Restaurant;

public partial class Category
{
    public int CategoryId { get; set; }

    public string? CategoryName { get; set; }

    public virtual ICollection<Menu> Menus { get; } = new List<Menu>();
}
