using Application.Features.Mediator.Notifications.Commands.Create;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Notifications.Commands.Create
{
	
	public class CreatedNotificationCommand : IRequest<CreatedNotificationResponse>
	{
		public string Type { get; set; }
		public string Icon { get; set; }
		public string Description { get; set; }
		public DateTime Date { get; set; }
		public bool Status { get; set; }

		public class CreatedNotificationCommandHandler : IRequestHandler<CreatedNotificationCommand, CreatedNotificationResponse>
		{
			private readonly INotificationRepository _NotificationRepository;
			private readonly IMapper _mapper;

			public CreatedNotificationCommandHandler(INotificationRepository NotificationRepository, IMapper mapper)
			{
				_NotificationRepository = NotificationRepository;
				_mapper = mapper;
			}

			public async Task<CreatedNotificationResponse> Handle(CreatedNotificationCommand request, CancellationToken cancellationToken)
			{
				var Notification = _mapper.Map<Notification>(request);
				await _NotificationRepository.CreateAsync(Notification);
				return _mapper.Map<CreatedNotificationResponse>(Notification);
			}
		}
	}
}
