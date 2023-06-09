﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public class OrderItemModel
    {
        public int OrderItemId { get; set; }

        public int OrderId { get; set; }

        public int ProductID { get; set; }

        public int? QuantityUserOrderd { get; set; }

        public int? Price { get; set; }

        public string? SpecialRequests { get; set; }


        public OrderItemModel(OrderItem orderItem)
        {
            this.OrderItemId = orderItem.OrderItemId;
            this.OrderId = orderItem.OrderId;
            this.ProductID = orderItem.ProductId;
            this.QuantityUserOrderd = orderItem.Quantity;
            this.Price = orderItem.Price;
            this.SpecialRequests = orderItem.SpecialRequests;
        }

        public OrderItemModel() { }
    }
}
