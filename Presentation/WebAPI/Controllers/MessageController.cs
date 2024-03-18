using Application.Features.Mediator.Mesages.Commands.Create;
using Application.Features.Mediator.Mesages.Commands.Delete;
using Application.Features.Mediator.Mesages.Commands.Update;
using Application.Features.Mediator.Mesages.Queries.GetById;
using Application.Features.Mediator.Mesages.Queries.GetByList;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MessageController : ControllerBase
	{
		private readonly IMediator _mediator;

		public MessageController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]
		public async Task<IActionResult> MessageList()
		{
			var values = await _mediator.Send(new GetListMessageQuery());

			return Ok(values);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetMessage(int id)
		{
			GetByIdMessageQuery getByIdMessage = new() { Id = id };

			var value = await _mediator.Send(getByIdMessage);
			return Ok(value);
		}

		[HttpPost]
		public async Task<IActionResult> Add(CreatedMessageCommand createdMessageCommand)
		{
			CreatedMessageResponse response = await _mediator.Send(createdMessageCommand);
			return Ok(response);
		}

		[HttpPut]
		public async Task<IActionResult> Update(UpdatedMessageCommand updateMessageCommand)
		{
			UpdatedMessageResponse response = await _mediator.Send(updateMessageCommand);

			return Ok(response);
		}
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			DeletedMessageCommand deletedMessageCommand = new() { Id = id };
			DeletedMessageResponse response = await _mediator.Send(deletedMessageCommand);

			return Ok(response);
		}

	}
}
