﻿using Microsoft.AspNetCore.Mvc;
using Microservices.OrderServices.Models;
using Microservices.OrderServices.Service_Layer;

namespace Microservices.OrderServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrders(string Username)
        {
            var orders = await _orderService.GetAllOrdersAsync(Username);
            if (orders == null)
            {
                return NotFound();
            }
            return Ok(orders);
        }

        [HttpGet("getDataUser/{Username}/{id}")]
        public async Task<IActionResult> GetOrderById(string Username,int id)
        {
            var order = await _orderService.GetOrderByIdAsync(Username,id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateOrder([FromBody] OrderModel orderModel)
        {
            try
            {
               var result= await _orderService.CreateOrderAsync(orderModel);
                return result? Ok():BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("{id}/updateStatus")]
        public async Task<IActionResult> UpdateOrderStatus(string Username,int id, [FromBody] string status)
        {
           var result= await _orderService.UpdateOrderStatusAsync(Username,id, status);
            return result? Ok():BadRequest();
        }
    }
}
