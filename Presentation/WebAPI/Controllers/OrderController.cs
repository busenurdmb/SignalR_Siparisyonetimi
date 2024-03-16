using Application.Features.Mediator.Orders.Commands.Create;
using Application.Features.Mediator.Orders.Queries.GetList;
using Application.Features.Mediator.Orders.Queries.GetActiveOrderCount;
using Application.Features.Mediator.Orders.Queries.GetLastOrderPrice;
using Application.Features.Mediator.Orders.Queries.GetOrderCount;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.Features.Mediator.Orders.Commands.Update;
using Application.Orders.Mediator.Orders.Queries.GetById;
using Application.Features.Mediator.Orders.Commands.Delete;

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
        [HttpGet]
        public async Task<IActionResult> OrderList()
        {
            var values = await _mediator.Send(new GetListOrderQuery());

            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrder(int id)
        {
            GetByIdOrderQuery getByIdOrder = new() { Id = id };

            var value = await _mediator.Send(getByIdOrder);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreatedOrderCommand createdOrderCommand)
        {
            CreatedOrderResponse response = await _mediator.Send(createdOrderCommand);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdatedOrderCommand updateOrderCommand)
        {
            UpdatedOrderResponse response = await _mediator.Send(updateOrderCommand);

            return Ok(response);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            DeletedOrderCommand deletedOrderCommand = new() { Id = id };
            DeletedOrderResponse response = await _mediator.Send(deletedOrderCommand);

            return Ok(response);
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
