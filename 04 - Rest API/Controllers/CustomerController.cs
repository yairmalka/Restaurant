using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Restaurant
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        public CustomerLogic customerLogic;

        public CustomerController(CustomerLogic customerLogic)
        {
            this.customerLogic = customerLogic;
        }

        [HttpGet]
        public IActionResult GetAllCustomers()
        {
            try
            {
                List<CustomerModel> customers = new List<CustomerModel>();
                customers = customerLogic.GetAllCustomers();
                return Ok(customers);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        [HttpGet]
        [Route("{custumerID}")]
        public IActionResult GetCustomer(int custumerID) 
        {
            try
            {
                CustomerModel customer = customerLogic.GetCustomer(custumerID);
                return Ok(customer);
            }

            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public IActionResult AddCustomer(CustomerModel customer)
        {
            try
            {
                CustomerModel customerToAdd = customerLogic.AddCustomer(customer);
                return Created("api/Customers/" + customerToAdd.CustomerId, customerToAdd);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

    }
}
