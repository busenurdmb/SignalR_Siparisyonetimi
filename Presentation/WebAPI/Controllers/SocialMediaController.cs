using Application.Features.Mediator.SocialMedias.Commands.Create;
using Application.Features.Mediator.SocialMedias.Commands.Delete;
using Application.Features.Mediator.SocialMedias.Commands.Update;
using Application.Features.Mediator.SocialMedias.Queries.GetById;
using Application.Features.Mediator.SocialMedias.Queries.GetList;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SocialMediaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> SocialMediaList()
        {
            var values = await _mediator.Send(new GetListSocialMediaQuery());

            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSocialMedia(int id)
        {
            GetByIdSocialMediaQuery getByIdSocialMedia = new() { Id = id };

            var value = await _mediator.Send(getByIdSocialMedia);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreatedSocialMediaCommand createdSocialMediaCommand)
        {
            CreatedSocialMediaResponse response = await _mediator.Send(createdSocialMediaCommand);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdatedSocialMediaCommand updateSocialMediaCommand)
        {
            UpdatedSocialMediaResponse response = await _mediator.Send(updateSocialMediaCommand);

            return Ok(response);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            DeletedSocialMediaCommand deletedSocialMediaCommand = new() { Id = id };
            DeletedSocialMediaResponse response = await _mediator.Send(deletedSocialMediaCommand);

            return Ok(response);
        }
    }
}
