using ECommerceApp.DTOs;
using ECommerceApp.Repositories;
using ECommerceApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController(IOrderService orderService) : ControllerBase
    {
        
        // GET: api/order/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDto>> GetOrderById(int id)
        {
            try
            {
                var order = await orderService.GetOrderById(id);
                return Ok(order);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        // GET: api/order/user/{userId}
        [HttpGet("user/{userId}")]
        public async Task<ActionResult<OrderDto>> GetOrdersByUserId(int userId)
        {
            try
            {
                var orders = await orderService.GetOrdersByUserId(userId);
                return Ok(orders);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        // POST: api/order
        [HttpPost]
        public async Task<ActionResult> PlaceOrder(int userId)
        {
            try
            {
                await orderService.AddOrder(userId);
                return Ok("Order placed successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

     
    }
}
