using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using TestTask.Domain.Models;
using TestTask.WebApi.Contracts;
using TestTask.WebApi.Contracts.Requests;
using TestTask.WebApi.Contracts.Responses;
using TestTask.WebApi.Services;

namespace TestTask.WebApi.Controllers
{
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ISingleOrderService singleOrderService;
        private readonly IMapper mapper;

        public OrderController(ISingleOrderService orderService, IMapper mapper)
        {
            this.singleOrderService = orderService;
            this.mapper = mapper;
        }

        [HttpGet(ApiRoutes.Orders.Get)]
        public async Task<IActionResult> GetSingle()
        {
            var order = await singleOrderService.GetSingleOrder();
            if (order == null)
            {
                return NotFound();
            }

            var orderResponse = mapper.Map<Order, SingleOrderResponse>(order);

            return Ok(orderResponse);
        }

        [HttpPut(ApiRoutes.Orders.UpdateSingle)]
        [Consumes(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> UpdateSingle([FromBody] UpdateSingleOrderRequest orderRequest)
        {
            var order = mapper.Map<UpdateSingleOrderRequest, Order>(orderRequest);
            var updated = await singleOrderService.UpdateSingleOrder(order);
            if (!updated)
            {
                return NotFound();
            }

            order = await singleOrderService.GetSingleOrder();
            var orderResponse = mapper.Map<Order, SingleOrderResponse>(order);

            return Ok(orderResponse);
        }
    }
}
