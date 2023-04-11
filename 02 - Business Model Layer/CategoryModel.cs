using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public class CategoryModel
    {
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }

        public CategoryModel(Category category)
        {
            CategoryId = category.CategoryId;
            CategoryName = category.CategoryName;
        }
        public CategoryModel() { }
    }
}
