using Application.Features.Mediator.Discounts.Commands.Create;
using Application.Features.Mediator.Discounts.Commands.Delete;
using Application.Features.Mediator.Discounts.Commands.Update;
using Application.Features.Mediator.Discounts.Queries.GetById;
using Application.Features.Mediator.Discounts.Queries.GetList;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DiscountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> DiscountList()
        {
            var values = await _mediator.Send(new GetListDiscountQuery());

            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDiscount(int id)
        {
            GetByIdDiscountQuery getByIdDiscount = new() { Id = id };

            var value = await _mediator.Send(getByIdDiscount);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreatedDiscountCommand createdDiscountCommand)
        {
            CreatedDiscountResponse response = await _mediator.Send(createdDiscountCommand);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdatedDiscountCommand updateDiscountCommand)
        {
            UpdatedDiscountResponse response = await _mediator.Send(updateDiscountCommand);

            return Ok(response);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            DeletedDiscountCommand deletedDiscountCommand = new() { Id = id };
            DeletedDiscountResponse response = await _mediator.Send(deletedDiscountCommand);

            return Ok(response);
        }
    }
}
