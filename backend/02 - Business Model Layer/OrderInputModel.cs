using System;
using System.Collections.Generic;

namespace Restaurant
{
    public class OrderInputModel
    {
        public List<ProductModel> ProductsToOrder { get; set; }
        public List<string> SpecialRequests { get; set; }
        public CustomerModel Customer { get; set; }
        public string OrderType { get; set; }
        public int NumOfSeats { get; set; }
    }
}