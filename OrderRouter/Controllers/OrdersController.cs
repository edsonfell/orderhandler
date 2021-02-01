using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using Models;
using services;
using System.Linq;

namespace Controllers
{
    [ApiController]
    [Route("/orders")]
    public class OrdersController : ControllerBase
    {
        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Order>> Post(
            [FromBody] Order newOrder)
            {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                
                // Creating a new and unique order id
                newOrder.OrderId = OrdersHandlerService.OrderIdGerator();
                
                // Setting the same order id to all of it products, so the kitchen 
                // will be able to handle them all.
                newOrder.Products.Select(o => {o.OrderId = newOrder.OrderId; return o;}).ToList();
                
                // Ensuring that the property "IsReady" won't be set as true
                newOrder.IsReady = false;

                //Send the order to kicken
                OrdersHandlerService.SendToKitchen(newOrder);

                return Ok("Thanks for your order!");
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Bad Request. Try again later" });
            }
        }
    }
}