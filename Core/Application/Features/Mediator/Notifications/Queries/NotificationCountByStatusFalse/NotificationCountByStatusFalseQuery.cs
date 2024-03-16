using Application.Features.Mediator.Notifications.Queries.NotificationCountByStatusFalse;
using Application.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Notifications.Queries.NotificationCountByStatusFalse
{
	
	public class NotificationCountByStatusFalseQuery : IRequest<NotificationCountByStatusFalseResponse>
	{
		public class NotificationCountByStatusFalseQueryHandler : IRequestHandler<NotificationCountByStatusFalseQuery, NotificationCountByStatusFalseResponse>
		{
			private readonly INotificationRepository _NotificationRepository;
			private readonly IMapper _mapper;

			public NotificationCountByStatusFalseQueryHandler(INotificationRepository NotificationRepository, IMapper mapper)
			{
				_NotificationRepository = NotificationRepository;
				_mapper = mapper;
			}

			public async Task<NotificationCountByStatusFalseResponse> Handle(NotificationCountByStatusFalseQuery request, CancellationToken cancellationToken)
			{
				int Notification = _NotificationRepository.NotificationCountByStatusFalse();

				return _mapper.Map<NotificationCountByStatusFalseResponse>(Notification);
			}
		}
	}
}
