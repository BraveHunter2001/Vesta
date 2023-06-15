using Backend.DAL.Interfaces;
using Backend.DAL.Repositories;
using Backend.DTO;
using Backend.Exceptions;
using Backend.Models;
using Backend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        
        private readonly OrderService _orderService;

        public OrderController(OrderService service)
        {
            _orderService = service;
        }

        /// <summary>
        /// Get all order.
        /// </summary>
        /// <returns>List Orders</returns>
        /// <response code="200">Retuns all order</response>
        [HttpGet]
        [Route("all")]
        public async Task<ActionResult<ListOrders>> Orders()
        {
            ListOrders orders = await _orderService.GetAllOrdersAsync();
            return Ok(orders);
        }

        /// <summary>
        ///  Get order by id
        /// </summary>
        /// <param name="id">Order's id</param>
        /// <returns>Order</returns>
        /// <response code="200">Return order</response>
        /// <response code= "404"> Order not found</response>
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Order>> GetOrderById( int id)
        {
            Order order;
            try
            {
                order = await _orderService.GetOrderByIdAsync(id);
            }
            catch (OrderNotFoundException e)
            {
                return BadRequest(e.Message);
            }

            return Ok(order);
        }
        /// <summary>
        /// Create order
        /// </summary>
        /// <param name="createdOrder">Structure of create order</param>
        /// <returns></returns>
        /// <response code="201">Order successful created</response>
        [HttpPost]
        [Route("createOrder")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateOrder([FromBody] CreatedOrder createdOrder)
        {
           
            Order order = await _orderService.CreateOrderAsync(createdOrder);
            return CreatedAtAction("Orders", order);
        }

        /// <summary>
        /// Delete order by id
        /// </summary>
        /// <param name="id">Order's id</param>
        /// <returns></returns>
        /// <response code="200">Order successful deleted</response>
        /// <response code= "404"> Order not found</response>
        [HttpDelete]       
        [Route("delete")]
        public async Task<IActionResult> DeleteOrder([FromBody]int id)
        {
            try
            {
                await _orderService.DeleteOrderAsync(id);
            }
            catch (OrderNotFoundException e)
            {
                return BadRequest(e.Message);
            }
            return Ok("Order successful delete");
        }
    }
}
