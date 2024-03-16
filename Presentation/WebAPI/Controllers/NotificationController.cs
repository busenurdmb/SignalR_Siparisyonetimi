using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.Features.Mediator.Notifications.Queries.GetList;
using Application.Features.Mediator.Notifications.Queries.GetById;
using Application.Features.Mediator.Notifications.Commands.Create;
using Application.Features.Mediator.Notifications.Commands.Update;
using Application.Features.Mediator.Notifications.Commands.Delete;
using Application.Features.Mediator.Notifications.Queries.NotificationCountByStatusFalse;

using Application.Features.Mediator.Notifications.Commands.NotificationStatusChangeToTrue;
using Application.Features.Mediator.Notifications.Commands.NotificationStatusChangeToFalse;

namespace WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	
	public class NotificationController : ControllerBase
	{
		private readonly IMediator _mediator;

		public NotificationController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]
		public async Task<IActionResult> NotificationList()
		{
			var values = await _mediator.Send(new GetListNotificationQuery());

			return Ok(values);
		}
		[HttpGet("NotificationCountByStatusFalse")]
		public async Task<IActionResult> NotificationCount()
		{
			var value = await _mediator.Send(new NotificationCountByStatusFalseQuery());
			return Ok(value);
		}
		//[HttpGet("GetAllNotificationByFalse")]
		//public async Task<IActionResult> GetAllNotificationByFalse()
		//{
		//	var value = await _mediator.Send(new GetAllNotificationByFalseQuery());
		//	return Ok(value);
		//}
		[HttpGet("{id}")]
		public async Task<IActionResult> GetNotification(int id)
		{
			GetByIdNotificationQuery getByIdNotification = new() { Id = id };

			var value = await _mediator.Send(getByIdNotification);
			return Ok(value);
		}

		[HttpPost]
		public async Task<IActionResult> Add(CreatedNotificationCommand createdNotificationCommand)
		{
			CreatedNotificationResponse response = await _mediator.Send(createdNotificationCommand);
			return Ok(response);
		}

		[HttpPut]
		public async Task<IActionResult> Update(UpdatedNotificationCommand updateNotificationCommand)
		{
			UpdatedNotificationResponse response = await _mediator.Send(updateNotificationCommand);

			return Ok(response);
		}
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			DeletedNotificationCommand deletedNotificationCommand = new() { Id = id };
			DeletedNotificationResponse response = await _mediator.Send(deletedNotificationCommand);

			return Ok(response);
		}

        [HttpGet("NotificationStatusChangeToTrue/{id}")]
        public async Task<IActionResult> NotificationStatusChangeToTrue(int id)
        {
            NotificationStatusChangeToTrueCommand notificationStatusChangeToTrueCommand = new() { NotificationID = id };
             NotificationStatusChangeToTrueResponse response =await _mediator.Send(notificationStatusChangeToTrueCommand);
            return Ok(response);
          
        }
        [HttpGet("NotificationStatusChangeToFalse/{id}")]
        public async Task<IActionResult> NotificationStatusChangeToFalse(int id)
        {
            NotificationStatusChangeToFalseCommand notificationStatusChangeToFalseCommand = new() { NotificationID = id };
            NotificationStatusChangeToFalseResponse response = await _mediator.Send(notificationStatusChangeToFalseCommand);
            return Ok(response);
        }
        
    }
}
