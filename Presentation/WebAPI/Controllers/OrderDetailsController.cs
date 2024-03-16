using Application.Features.Mediator.OrderDetails.Commands.Create;
using Application.Features.Mediator.OrderDetails.Commands.Delete;
using Application.Features.Mediator.OrderDetails.Commands.Update;
using Application.Features.Mediator.OrderDetailsDetails.Commands.Create;
using Application.Features.Mediator.OrderDetailsDetails.Queries.GetList;
using Application.OrderDetailss.Mediator.OrderDetails.Commands.Update;
using Application.OrderDetailss.Mediator.OrderDetails.Queries.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class OrderDetailsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderDetailsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> OrderDetailsList()
        {
            var values = await _mediator.Send(new GetListOrderDetailsQuery());

            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderDetails(int id)
        {
            GetByIdOrderDetailsQuery getByIdOrderDetails = new() { Id = id };

            var value = await _mediator.Send(getByIdOrderDetails);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreatedOrderDetailsCommand createdOrderDetailsCommand)
        {
            CreatedOrderDetailsResponse response = await _mediator.Send(createdOrderDetailsCommand);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdatedOrderDetailsCommand updateOrderDetailsCommand)
        {
            UpdatedOrderDetailsResponse response = await _mediator.Send(updateOrderDetailsCommand);

            return Ok(response);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            DeletedOrderDetailsCommand deletedOrderDetailsCommand = new() { Id = id };
            DeletedOrderDetailsResponse response = await _mediator.Send(deletedOrderDetailsCommand);

            return Ok(response);
        }
     
    }
}
