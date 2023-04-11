using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public class CustomerModel
    {
        public int CustomerId { get; set; }
        public string? CustomerName { get; set; }
        public string? CustomerEmail { get; set; }
        public string? CustomerPhoneNumber { get; set; }

        public CustomerModel(Customer customer)
        {
            this.CustomerId = customer.CustomerId;
            this.CustomerName = customer.CustomerName;
            this.CustomerEmail = customer.CustomerEmail;
            this.CustomerPhoneNumber = customer.CustomerPhoneNumber;
        }

        public CustomerModel() {}
    }
}
