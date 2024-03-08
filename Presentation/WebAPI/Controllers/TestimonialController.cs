using Application.Features.Mediator.Testimonials.Commands.Create;
using Application.Features.Mediator.Testimonials.Commands.Delete;
using Application.Features.Mediator.Testimonials.Commands.Update;
using Application.Features.Mediator.Testimonials.Queries.GetById;
using Application.Features.Mediator.Testimonials.Queries.GetList;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TestimonialController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> TestimonialList()
        {
            var values = await _mediator.Send(new GetListTestimonialQuery());

            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTestimonial(int id)
        {
            GetByIdTestimonialQuery getByIdTestimonial = new() { Id = id };

            var value = await _mediator.Send(getByIdTestimonial);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreatedTestimonialCommand createdTestimonialCommand)
        {
            CreatedTestimonialResponse response = await _mediator.Send(createdTestimonialCommand);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdatedTestimonialCommand updateTestimonialCommand)
        {
            UpdatedTestimonialResponse response = await _mediator.Send(updateTestimonialCommand);

            return Ok(response);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            DeletedTestimonialCommand deletedTestimonialCommand = new() { Id = id };
            DeletedTestimonialResponse response = await _mediator.Send(deletedTestimonialCommand);

            return Ok(response);
        }
    }
}
