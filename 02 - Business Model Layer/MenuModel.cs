using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public class MenuModel
    {
        public int MenuItemId { get; set; }

        public int? CategoryId { get; set; }

        public string? MenuItemName { get; set; }

        public string? MenuItemDescription { get; set; }

        public int? MenuItemPrice { get; set; }

        public MenuModel(Menu menu)
        {
            this.MenuItemId = menu.MenuItemId;
            this.CategoryId = menu.CategoryId;
            this.MenuItemName = menu.MenuItemName;
            this.MenuItemDescription = menu.MenuItemDescription;
            this.MenuItemPrice = menu.MenuItemPrice;
        }

        public MenuModel() { }

    }


}

