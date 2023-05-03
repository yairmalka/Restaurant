using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public class ProductModel
    {
        public int ProductId { get; set; }

        public int? CategoryId { get; set; }

        public string? ProductName { get; set; }

        public string? ProductDescription { get; set; }

        public int? ProductPrice { get; set; }

        public ProductModel(Product product)
        {
            this.ProductId = product.ProductId;
            this.CategoryId = product.CategoryId;
            this.ProductName = product.ProductName;
            this.ProductDescription = product.ProductDescription;
            this.ProductPrice = product.ProductPrice;
        }

        public ProductModel() { }

    }


}

