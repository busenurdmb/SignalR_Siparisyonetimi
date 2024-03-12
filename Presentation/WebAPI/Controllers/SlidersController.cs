using Application.Features.Mediator.Sliders.Commands.Create;
using Application.Features.Mediator.Sliders.Commands.Delete;
using Application.Features.Mediator.Sliders.Commands.Update;
using Application.Features.Mediator.Sliders.Queries.GetById;
using Application.Features.Mediator.Sliders.Queries.GetList;
using Application.Features.Mediator.Sliders.Commands.Delete;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SlidersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SlidersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> SliderList()
        {
            var values = await _mediator.Send(new GetListSliderQuery());

            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSlider(int id)
        {
            GetByIdSliderQuery getByIdSlider = new() { Id = id };

            var value = await _mediator.Send(getByIdSlider);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreatedSliderCommand createdSliderCommand)
        {
            CreatedSliderResponse response = await _mediator.Send(createdSliderCommand);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdatedSliderCommand updateSliderCommand)
        {
            UpdatedSliderResponse response = await _mediator.Send(updateSliderCommand);

            return Ok(response);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            DeletedSliderCommand deletedSliderCommand = new() { Id = id };
            DeletedSliderResponse response = await _mediator.Send(deletedSliderCommand);

            return Ok(response);
        }

    }
}
