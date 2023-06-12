using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public class OrderModel
    {
        public int OrderId { get; set; }

        public int? TableId { get; set; }

        public string? OrderType { get; set; }

        public int? CustomerId { get; set; }

        public DateTime? OrderDate { get; set; }


        public OrderModel(Order order)
        {
            OrderId = order.OrderId;
            TableId = order.TableId;
            OrderType = order.OrderType;
            CustomerId = order.CustomerId;
            OrderDate = order.OrderDate;
        }

        public OrderModel() { }

    }
}
