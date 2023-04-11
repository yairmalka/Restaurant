using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public class CustomerLogic: BaseLogic
    {
        public List<CustomerModel> GetAllCustomers()
        {
            return db.Customers.Select(c => new CustomerModel(c)).ToList();
        }

        public CustomerModel GetCustomer(int id)
        {
            var customerModel = db.Customers.Select(c=> new CustomerModel(c)).FirstOrDefault();
            if (customerModel == null)
                throw new NotFoundException($"Customer with id {id} not found");
            return customerModel;

        }

        public CustomerModel AddCustomer(CustomerModel customerModel)
        {
            Customer customer = new Customer
            {
                CustomerName = customerModel.CustomerName,
                CustomerEmail = customerModel.CustomerEmail,
                CustomerPhoneNumber = customerModel.CustomerPhoneNumber
            };

            db.Customers.Add(customer);
            db.SaveChanges();
            customerModel.CustomerId = customer.CustomerId;
            return new CustomerModel(customer);
        }

        public CustomerModel EditCustomer(CustomerModel customerModel)
        {
            var customer = db.Customers.FirstOrDefault(c => c.CustomerId == customerModel.CustomerId);
            if (customer == null)
                throw new NotFoundException($"customer with id {customerModel.CustomerId} not found");

            if(customerModel.CustomerName != null)
                customer.CustomerName = customerModel.CustomerName;

            if(customerModel.CustomerEmail != null)
                customer.CustomerEmail = customerModel.CustomerEmail;

            if(customerModel.CustomerPhoneNumber != null)
                customer.CustomerPhoneNumber = customerModel.CustomerPhoneNumber;

            db.SaveChanges();
            return new CustomerModel(customer);
        }
    }
}
