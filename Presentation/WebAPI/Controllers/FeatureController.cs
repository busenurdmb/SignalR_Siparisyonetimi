using Application.Features.Mediator.Features.Commands.Create;
using Application.Features.Mediator.Features.Commands.Delete;
using Application.Features.Mediator.Features.Commands.Update;
using Application.Features.Mediator.Features.Queries.GetById;
using Application.Features.Mediator.Features.Queries.GetList;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FeatureController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> FeatureList()
        {
            var values = await _mediator.Send(new GetListFeatureQuery());

            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFeature(int id)
        {
            GetByIdFeatureQuery getByIdFeature = new() { Id = id };

            var value = await _mediator.Send(getByIdFeature);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreatedFeatureCommand createdFeatureCommand)
        {
            CreatedFeatureResponse response = await _mediator.Send(createdFeatureCommand);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdatedFeatureCommand updateFeatureCommand)
        {
            UpdatedFeatureResponse response = await _mediator.Send(updateFeatureCommand);

            return Ok(response);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            DeletedFeatureCommand deletedFeatureCommand = new() { Id = id };
            DeletedFeatureResponse response = await _mediator.Send(deletedFeatureCommand);

            return Ok(response);
        }
    }
}
