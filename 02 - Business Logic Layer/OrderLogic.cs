using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public class OrderLogic: BaseLogic
    {
        // public find all customer orders
        // getOrderByID
        // getAllOrders

        ProductLogic productLogic;
        CustomerLogic customerLogic;
        TableLogic tableLogic;

        public OrderLogic(ProductLogic productLogic, CustomerLogic customerLogic, TableLogic tableLogic)
        {
            this.productLogic = productLogic;
            this.customerLogic = customerLogic;
            this.tableLogic = tableLogic;
        }
        
        public OrderModel AddanOrder(OrderInputModel orderInput)
        {
            Order newOrder = new Order();

            newOrder.CustomerId = customerLogic.GetCustomerIDbyPhoneNumber(orderInput.Customer.CustomerPhoneNumber);
            newOrder.OrderDate = DateTime.Now;
            if (orderInput.OrderType.Equals("TAKE AWAY") || orderInput.OrderType.Equals("SELF PICKUP"))
                newOrder.TableId = null;
            else
            {
                newOrder.TableId = tableLogic.AssignFreeTable(orderInput.NumOfSeats);
                newOrder.OrderType = orderInput.OrderType; // (DINE IN)
            }

            db.Orders.Add(newOrder);
            db.SaveChanges();

            for( int i = 0; i< orderInput.ProductsToOrder.Count; i++)
            {
                var orderItem = new OrderItem()
                {
                    OrderId = newOrder.OrderId,
                    ProductId = orderInput.ProductsToOrder[i].ProductId,
                    Quantity = orderInput.ProductsToOrder[i].Quantity,
                    Price = orderInput.ProductsToOrder[i].ProductPrice,
                    SpecialRequests = orderInput.SpecialRequests[i]
                };

                db.OrderItems.Add(orderItem);
            }

            db.SaveChanges ();

            return new OrderModel(newOrder);
        }


    }
}
