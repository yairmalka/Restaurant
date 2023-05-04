using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public class OrderLogic
    {
        // public find all customer orders
        // getOrderByID
        // getAllOrders

        ProductLogic productLogic;

        public  OrderLogic(ProductLogic productLogic)
        {
            this.productLogic = productLogic;
        }

        public OrderModel MakeAreservation(List<ProductModel> productsToOrder)
        {
            Order newOrder = new Order();
            foreach(ProductModel product in productsToOrder)
            {
                productID = 
            }
            // TO DO: if dine in order get suitble free table from tables, if not free table think what to do
            newOrder.OrderDate = DateTime.Now;
            return new OrderModel();
        }


    }
}
