using Application.Features.Mediator.Orders.Queries.GetActiveOrderCount;
using Application.Features.Mediator.Orders.Queries.GetLastOrderPrice;
using Application.Features.Mediator.Orders.Queries.GetOrderCount;
using Application.Features.Mediator.Products.Queries.GetTotalPriceByDrinkCategory;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("TotalOrderCount")]
        public async Task<IActionResult> TotalOrderCount()
        {
            var values = await _mediator.Send(new GetOrderCountQuery());

            return Ok(values);
           
        }
        
        [HttpGet("ActiveOrderCount")]
        public async Task<IActionResult> ActiveOrderCount()
        {
            var values = await _mediator.Send(new GetActiveOrderCountQuery());

            return Ok(values);
        }
        [HttpGet("LastOrderPrice")]
        public async Task<IActionResult> LastOrderPrice()
        {
            var values = await _mediator.Send(new GetLastOrderPriceQuery());

            return Ok(values);
        }
    }
}
