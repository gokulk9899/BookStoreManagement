using AutoMapper;
using BookStoreManagement.WebApi.Dtos;
using BookStoreManagement.WebApi.Models;
using BookStoreManagement.WebApi.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookStoreManagement.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly IUnitOfWork unitWork;
        private readonly IMapper mapper;

        public OrderController(IUnitOfWork unitWork,IMapper mapper)
        {
            this.unitWork = unitWork;
            this.mapper = mapper;
        }

        private int GetUserIdFromToken()
        {
            return int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
        }
        

        // GET: api/<OrderController>
        //[HttpGet("GetOrderById")]
        //public async Task<IActionResult> GetOrdersById(int userId)
        //{
        //    var orders = await unitWork.orderRepository.GetOrderByIdAsync(userId);
        //    var ordersDto = mapper.Map<List<OrderDto>>(orders);
        //    return Ok(ordersDto);
        //}

        [HttpGet("GetOrders")]
        public async Task<IActionResult> GetOrders()
        {
            var userId = GetUserIdFromToken();
            var orders = await unitWork.orderRepository.GetOrderByIdAsync(userId);
            var ordersDto = mapper.Map<List<OrderDto>>(orders);
            return Ok(ordersDto);
        }


        // POST api/<OrderController>
        [HttpPost("AddToCart")]
        public async Task<IActionResult> AddToCart(OrderDto orderDto)
        {
            orderDto.UserId = GetUserIdFromToken();//this fetch userid from token....it would have thrown error here.. as null..
            //orderDto.UserId = 3;// i already did this.. so only i hardcoded userId here..
            var order = mapper.Map<Order>(orderDto);
            unitWork.orderRepository.AddToCart(order);
            await unitWork.SaveAsync();
            return Ok("Created");
        }

        // PUT api/<OrderController>/5
        [HttpPut("UpdateOrder/{id}")]
        public async Task<IActionResult> UpdateOrder(int id,OrderDto orderDto)
        {
            var orderFromContext = await unitWork.orderRepository.FindOrder(id);
            mapper.Map(orderDto, orderFromContext);
            await unitWork.SaveAsync();
            return Ok();
        }

        [HttpPatch("UpdateQuantity")]
        public async Task<IActionResult> UpdateQuantity(int id, OrderDto orderDto)
        {
            var orderFromContext = await unitWork.orderRepository.FindOrder(id);
            orderFromContext.Quantity = orderDto.Quantity;
            unitWork.orderRepository.EditOrderQuantity(orderFromContext);
            await unitWork.SaveAsync();
            return Ok();
        }

        // DELETE api/<OrderController>/5
        [HttpDelete("DeleteOrderById")]
        public async Task<IActionResult> DeleteOrder(int orderId)
        {
            var orderFromContext = await unitWork.orderRepository.FindOrder(orderId);
            unitWork.orderRepository.DeleteOrder(orderFromContext);
            //unitWork.SaveAsync();
            return Ok();
        }
    }
}
