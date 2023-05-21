using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Restaurant
{

    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        public OrderLogic orderLogic;
        public OrderController(OrderLogic orderLogic)
        {
            this.orderLogic = orderLogic;
        }

        [HttpPost]
        public IActionResult AddanOrder(OrderInputModel orderInput)
        {
            try
            {
                OrderModel newOrder = orderLogic.AddanOrder(orderInput);
                return Created("api/Order/" + newOrder.OrderId, newOrder);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
