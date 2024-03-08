using Application.Features.Mediator.Abouts.Commands.Create;
using Application.Features.Mediator.Abouts.Commands.Delete;
using Application.Features.Mediator.Abouts.Commands.Update;
using Application.Features.Mediator.Abouts.Queries.GetById;
using Application.Features.Mediator.Abouts.Queries.GetList;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AboutController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> AboutList()
        {
            var values = await _mediator.Send(new GetListAboutQuery());
            
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAbout(int id)
        {
            GetByIdAboutQuery getByIdAbout= new() { Id = id };

            var value = await _mediator.Send(getByIdAbout);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreatedAboutCommand createdAboutCommand)
        {
            CreatedAboutResponse response = await _mediator.Send(createdAboutCommand);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update( UpdateAboutCommand updateAboutCommand)
        {
            UpdateAboutResponse response = await _mediator.Send(updateAboutCommand);

            return Ok(response);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            DeleteAboutResponse response = await _mediator.Send(new DeleteAboutCommand(id));

            return Ok(response);
        }

    }
}
