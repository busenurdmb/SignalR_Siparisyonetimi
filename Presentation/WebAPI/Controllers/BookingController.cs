using Application.Features.Mediator.Bookings.Commands.Create;
using Application.Features.Mediator.Bookings.Commands.Delete;
using Application.Features.Mediator.Bookings.Commands.Update;
using Application.Features.Mediator.Bookings.Queries.GetById;
using Application.Features.Mediator.Bookings.Queries.GetList;

using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BookingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> BookingList()
        {
            var values = await _mediator.Send(new GetListBookingQuery());

            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBooking(int id)
        {
          GetByIdBookingQuery getByIdBooking = new() { Id = id };

            var value = await _mediator.Send(getByIdBooking);
            return Ok(value);
    }

    [HttpPost]
        public async Task<IActionResult> Add(CreatedBookingCommand createdBookingCommand)
        {
            CreatedBookingResponse response = await _mediator.Send(createdBookingCommand);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateBookingCommand updateBookingCommand)
        {
            UpdateBookingResponse response = await _mediator.Send(updateBookingCommand);

            return Ok(response);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            DeleteBookingResponse response = await _mediator.Send(new DeleteBookingCommand(id));

            return Ok(response);
        }
    }
}
